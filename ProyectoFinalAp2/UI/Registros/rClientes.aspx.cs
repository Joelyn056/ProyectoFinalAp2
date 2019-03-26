using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;
using ProyectoFinalAp2.App_Code;

namespace ProyectoFinalAp2.UI.Registros
{
    public partial class rClientes : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private Clientes LlenaClase()
        {
            Clientes clientes = new Clientes();

            clientes.ClienteId = ToInt(ClienteIdTextBox.Text);
            clientes.Nombres = NombreTextBox.Text;
            clientes.Edad = int.Parse(EdadTextBox.Text);
            clientes.Sexo = SexoDropDownList.SelectedValue;
            clientes.Ciudad = CiudadTextBox.Text;
            clientes.Telefono = TelefonoTextBox.Text;
            clientes.Celular = CelularTextBox.Text;
            clientes.Email = EmailTextBox.Text;

            return clientes;
                            
        }

        private void Limpiar()
        {
            ClienteIdTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            EdadTextBox.Text = string.Empty;
            SexoDropDownList.SelectedIndex = 0;
            CiudadTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CelularTextBox.Text= string.Empty;
            EmailTextBox.Text = string.Empty;
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            if(!isRefresh)
            {
                Repositorio<Clientes> rep = new Repositorio<Clientes>();
                Clientes c = rep.Buscar(ToInt(ClienteIdTextBox.Text));

                if (c != null)
                {
                    NombreTextBox.Text = c.Nombres;
                    EdadTextBox.Text = c.Edad.ToString();
                    SexoDropDownList.SelectedValue = c.Sexo;
                    CiudadTextBox.Text = c.Ciudad;
                    TelefonoTextBox.Text = c.Telefono;
                    CelularTextBox.Text = c.Celular;
                    EmailTextBox.Text = c.Email;

                }
                else
                    CallModal("Este cliente no existe");
                    Limpiar();
            }
        }

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarLinkButton_Click(object sender, EventArgs e)
        {
            if(Page.IsValid && isRefresh ==  false)
            {
                Repositorio<Clientes> rep = new Repositorio<Clientes>();
                Clientes c = rep.Buscar(ToInt(ClienteIdTextBox.Text));               
               
                if(c == null)
                    /*(ToInt(ClienteIdTextBox.Text) == 0)*/
                {
                    //if(ClientesBLL.Guardar<Clientes>(LlenaClase))
                    if(rep.Guardar(LlenaClase()))
                    {
                        Limpiar();
                        CallModal("Se guardo el cliente");
                    }
                    else
                    {
                        Limpiar();
                        CallModal("No se pudo guardar el cliente");
                    }

                }
                else
                {
                    if (rep.Modificar(LlenaClase()))
                    {
                        CallModal("Se modifico el cliente");
                    }
                    else
                        CallModal("No se pudo modificar el cliente");
                }                                                        
            }           
        }

        protected void EliminarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Clientes> rep = new Repositorio<Clientes>();
            Clientes c = rep.Buscar(ToInt(ClienteIdTextBox.Text));

            if(!isRefresh)
            {
                //if(ClientesBLL.Eliminar<Clientes>(ClienteIdTextBox.Text)))
                if (rep.Eliminar(ToInt(ClienteIdTextBox.Text)))
                {
                    CallModal("Se elimino el cliente");
                    Limpiar();
                }
                else
                    CallModal("El cliente no pudo ser elimiando");


            }
        }
    }
}