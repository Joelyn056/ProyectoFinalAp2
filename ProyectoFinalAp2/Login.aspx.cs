using BLL;
using Entidades;
using ProyectoFinalAp2.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalAp2
{
    public partial class LogIn : BasePage
    {
        Usuarios usuarios = new Usuarios();
        Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
        List<Usuarios> userList = new List<Usuarios>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                usuarioTextBox.Focus();
            }
        }

        protected void LoginLinkButton_Click(object sender, EventArgs e)
        {
            userList = repositorio.GetList(u => u.Usuario.Equals(usuarioTextBox.Text) && u.Contrasena.Equals(passTextBox.Text));
            usuarios = (userList != null && userList.Count > 0 ? userList[0] : null);

            if (usuarios != null)
                FormsAuthentication.RedirectFromLoginPage(usuarios.NombreUsuario, true);
            else
                CallModal("No Existe este Usuario");
            

        }
    }
}