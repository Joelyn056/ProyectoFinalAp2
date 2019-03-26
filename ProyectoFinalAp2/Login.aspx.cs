using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;



namespace ProyectoFinalAp2.UI.Login
{
    public partial class Login : Page
    {

        private Usuarios usuarios = new Usuarios();
        private Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
        List<Usuarios> userList = new List<Usuarios>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void loginAccess(object sender, EventArgs e)
        {
            userList = repositorio.GetList(u=> u.Usuario== login && u.Contrasena ==  )
        }

    }
}