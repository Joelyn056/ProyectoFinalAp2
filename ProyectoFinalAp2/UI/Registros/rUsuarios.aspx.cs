using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using ProyectoFinalAp2.App_Code;
using BLL;

namespace ProyectoFinalAp2.UI.Registros
{
    public partial class rUsuarios : BasePage
    {
        string condicion = "Seleccione";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {               
                LlenarDropDown();
                FechaTextBox.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
                int id = ToInt(Request.QueryString["id"]);

                if(id >0)
                {
                    Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
                    var usuario = repositorio.Buscar(id);

                    if (usuario == null)
                        CallModal("No Hay Resultado");
                    else
                        LlenaCampos(usuario);
                }
            }

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
            Usuarios usuarios = repositorio.Buscar(ToInt(UsuarioIdTextBox.Text));

            if(IsValid)
            {
                if (usuarios != null)
                {
                    Limpiar();
                    LlenaCampos(usuarios);
                }
                else
                {
                   Limpiar();
                   CallModal("Este usuario no exite");                 
                }
            }
        }


        private void LlenarDropDown()
        {


            TipoUsuarioDropDownList.DataSource = Enum.GetValues(typeof(TipoUsuario));
            TipoUsuarioDropDownList.AppendDataBoundItems = true;
            TipoUsuarioDropDownList.DataBind();

        }


        private Usuarios LlenaClase()
        {
            Usuarios usuarios = new Usuarios();

            usuarios.UsuarioId = ToInt(UsuarioIdTextBox.Text);
            DateTime.Parse(FechaTextBox.Text);
            usuarios.NombreUsuario = NombreTextBox.Text;
            usuarios.Contrasena = ContraseñaTextBox.Text;
            usuarios.TipoUsuario = TipoUsuarioDropDownList.Text;

            return usuarios;
        }

        private void LlenaCampos(Usuarios usuarios)
        {
            UsuarioIdTextBox.Text = usuarios.UsuarioId.ToString();
            FechaTextBox.Text = usuarios.Fecha.ToString();
            NombreTextBox.Text = usuarios.NombreUsuario;
            TipoUsuarioDropDownList.Text = usuarios.TipoUsuario;
            ContraseñaTextBox.Text = usuarios.Contrasena;
        }

        private void Limpiar()
        {
            UsuarioIdTextBox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.ToString("dd-MM-yyyy");
            NombreTextBox.Text = string.Empty;
            TipoUsuarioDropDownList.SelectedIndex = 0;
            ContraseñaTextBox.Text = string.Empty;
            ConfirmarTextBox.Text = string.Empty;

        }

        protected void CustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
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

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Equals(condicion))
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarLinkButton_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                Repositorio<Usuarios> rep = new Repositorio<Usuarios>();


                if (ToInt(UsuarioIdTextBox.Text) == 0)
                {
                    if (rep.Guardar(LlenaClase()))
                    {
                        CallModal("Se guardo el producto");
                        Limpiar();

                    }
                }
                else
                {
                    if (rep.Modificar(LlenaClase()))
                    {
                        CallModal("Se Modifico la cuenta");
                        Limpiar();
                    }
                }

            }
        }

        protected void EliminarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> rep = new Repositorio<Usuarios>();
            Usuarios p = rep.Buscar(ToInt(UsuarioIdTextBox.Text));

            if (p != null)
            {
                if (rep.Eliminar(ToInt(UsuarioIdTextBox.Text)))
                {
                    CallModal("Se a eliminado el producto");
                    Limpiar();

                }
                else
                    CallModal("No se pudo eliminar el producto");
                Limpiar();
            }
        }
    }
}