using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalAp2.App_Code
{
    public class BasePage : Page
    {
        public BasePage()
        {

        }

        public bool refreshState;
        public bool isRefresh;

        protected override void LoadViewState(object savedState)
        {
            object[] AllStates = (object[])savedState;
            base.LoadViewState(AllStates[0]);
            refreshState = bool.Parse(AllStates[1].ToString());
            if (Session["ISREFRESH"] != null && Session["ISREFRESH"] != "")
                isRefresh = (refreshState == (bool)Session["ISREFRESH"]);
        }

        protected override object SaveViewState()
        {
            Session["ISREFRESH"] = refreshState;
            object[] AllStates = new object[3];
            AllStates[0] = base.SaveViewState();
            AllStates[1] = !(refreshState);
            return AllStates;
        }

        protected void CallModal(string mensaje)
        {
            Label label = (Label)Master.FindControl("MessageLabel");
            if (label != null)
                label.Text = mensaje;

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert",
                            "$(function() { openModal(); });", true);
        }

        protected int ToInt(string text)
        {
            return (string.IsNullOrWhiteSpace(text)) ? 0 : int.Parse(text);
        }

        protected decimal ToDecimal(string text)
        {
            return (string.IsNullOrWhiteSpace(text)) ? 0 : decimal.Parse(text);
        }

        protected void ShowMessage(string type, string message)
        {
            ScriptManager.RegisterStartupScript(
                this,
                typeof(Page),
                "toastr_message",
                script: "toastr['" + type + "']('" + message + "');",
                addScriptTags: true);
        }
    }
}