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
            if(!IsPostBack)
            {

            }
        }

        private Clientes LlenaClase()
        {
            Clientes clientes = new Clientes();

            clientes.ClienteId = ToInt(ClienteIdTextBox.Text);
            clientes.Nombres = NombreTextBox.Text;
            clientes.Edad = EdadTextBox.Text;
            clientes.Sexo = SexoDropDownList.SelectedValue;
            clientes.Ciudad = CiudadTextBox.Text;
            clientes.Telefono = TelefonoTextBox.Text;
            clientes.Celular = CelularTextBox.Text;
            clientes.Email = EmailTextBox.Text;
            clientes.Fecha = DateTime.Now.Date;

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
                {
                    CallModal("Este cliente no existe");
                    Limpiar();
                }

                   
            }
            else
            {
                CallModal("No hay resultado");
                Limpiar();
            }
        }

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarLinkButton_Click(object sender, EventArgs e)
        {
             Repositorio<Clientes> rep = new Repositorio<Clientes>();
             Clientes c = rep.Buscar(ToInt(ClienteIdTextBox.Text));               
               

            if(Page.IsValid && isRefresh ==  false)
            {
                
                if(c == null)
                   
                {                   
                    if(rep.Guardar(LlenaClase()))
                    {
                        
                        CallModal("Se guardo el cliente");
                        Limpiar();
                    }
                    else
                    {
                        
                        CallModal("No se pudo guardar el cliente");
                        Limpiar();
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

            if(c != null)
            {               
                if (rep.Eliminar(ToInt(ClienteIdTextBox.Text)))
                {
                    CallModal("Se elimino el cliente");
                    Limpiar();
                }
                else
                    CallModal("El cliente no pudo ser elimiando");
                   Limpiar();

            }
        }
    }
}