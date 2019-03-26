using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using Microsoft; /// Le falta .Reporting.WenForms;

namespace ProyectoFinalAp2
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //UserMenu.InnerText = " " + Page.User.Identity.Name;
            //LogOutLink.CausesValidation = false;
        }

        protected void LogutAn_ServerClick(object sender, EventArgs e)
        {
            //FormsAuthentication.SignOut();
            //Response.Redirect("~/UI/Login/Login.aspx");
        }
    }
}