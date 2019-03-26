using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;
using ProyectoFinalAp2.App_Code;

namespace ProyectoFinalAp2.UI.Registrarse
{
    public partial class rUsuarios : BasePage
    {
        protected Usuarios usuarios = new Usuarios();
        protected Repositorio<Usuarios> rep = new Repositorio<Usuarios>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void Limpiar()
        {
            UsuarioTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            ContraseñaTextBox.Text = string.Empty;
            ConfirmarTextBox.Text = string.Empty;
        }

        private Usuarios LlenaClase()
        {

            ToInt(UsuarioTextBox.Text);
            usuarios.Usuario = UsuarioTextBox.Text;
            usuarios.Contrasena = ContraseñaTextBox.Text;

            return usuarios;

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            if (!isRefresh)
            {
                Usuarios u = new Repositorio<Usuarios>().Buscar(ToInt(UsuarioTextBox.Text));
                if (u != null)
                {
                    NombreTextBox.Text = u.NombreUsuario;
                }
                else
                    ShowMessage("warning", "Este usuario no existe");
            }
        }

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void EliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (!isRefresh)
            {
                Repositorio<Usuarios> rep = new Repositorio<Usuarios>();
                if (rep.Eliminar(ToInt(UsuarioTextBox.Text)))
                {
                    ShowMessage("success", "El usuario a sido eliminado.");
                    Limpiar();
                }
                else
                    ShowMessage("warning", "El usuario no pudo ser eliminado.");
            }
        }

        protected void GuardarLinkButton_Click(object sender, EventArgs e)
        {
            if(Page.IsValid && isRefresh == false)
            {
                //Repositorio<Usuarios> rep = new Repositorio<Usuarios>();
                //Usuarios u = rep.Buscar(ToInt(UsuarioTextBox.Text));

                if(IsValid)
                {
                    if (rep.Guardar(LlenaClase()))
                    {
                        Limpiar();
                        ShowMessage("success", "El usuario a sigo guardado");
                        ShowMessage("info", " Ahora sera redireccionado..");
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                        "setTimeout(function() { window.location.replace('../../UI/Login/Login.aspx') }, 3000);", true);
                    }
                    else
                    {
                        Limpiar();
                        ShowMessage("warning", "El usuario no pudo ser guardado.");
                    }
                }
                //else
                //{
                //    if (UsuariosBLL.Modificar<Usuarios>(LlenaClase()))
                //        ShowMessage("success", "El usuario a sido modificado.");
                //    else
                //        ShowMessage("warning", "El usuario no pudo ser modificado.");
                //}

            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(ConfirmarTextBox.Text != ContraseñaTextBox.Text)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}