using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoFinalAp2.App_Code;
using Entidades;
using BLL;

namespace ProyectoFinalAp2.UI.Registros
{
    public partial class rProductos : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void Limpiar()
        {
            ProductoIdTextBox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            DescripcionTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            GananciaTextBox.Text = string.Empty;
            InventarioTextBox.Text = string.Empty;
        }

        private Productos LlenaClase()
        {
            Productos producto = new Productos();

            producto.ProductoId = ToInt(ProductoIdTextBox.Text);
            producto.FechaRegistro = ToDateTime(FechaTextBox.Text);
            producto.Descripcion = DescripcionTextBox.Text;
            producto.Costo = ToDecimal(CostoTextBox.Text);
            producto.Precio = ToDecimal(PrecioTextBox.Text);
            producto.Ganancias = ToDecimal(GananciaTextBox.Text);
            producto.Inventario = ToInt(InventarioTextBox.Text);

            return producto;
                 
        }

        private void LlenaCampo(Productos p)
        {
            ProductoIdTextBox.Text = p.ProductoId.ToString();
            FechaTextBox.Text = p.FechaRegistro.ToString("yyyy-MM-dd");
            DescripcionTextBox.Text = p.Descripcion;
            CostoTextBox.Text = p.Costo.ToString();
            PrecioTextBox.Text = p.Precio.ToString();
            GananciaTextBox.Text = p.Ganancias.ToString();
            InventarioTextBox.Text = p.Inventario.ToString();

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {

            if (!isRefresh)
            {
                Repositorio<Productos> rep = new Repositorio<Productos>();
                Productos p = rep.Buscar(ToInt(ProductoIdTextBox.Text));

                if (p != null)
                {
                    LlenaCampo(p);
                }
                else
                {
                    CallModal("Este producto no existe");
                    Limpiar();
                }               

            }

        }

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarLinkButton_Click(object sender, EventArgs e)
        {
            if(Page.IsValid && isRefresh == false)
            {
                Repositorio<Productos> rep = new Repositorio<Productos>();
                Productos p = rep.Buscar(ToInt(ProductoIdTextBox.Text));
                if(p == null)
                {
                    if(rep.Guardar(LlenaClase()))
                    {
                        CallModal("Se guardo el producto");
                        Limpiar();

                    }
                }
                else
                {
                    if(rep.Modificar(LlenaClase()))
                    {
                        CallModal("Se Modifico el producto");
                        Limpiar();
                    }
                }

            }
        }

        protected void EliminarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Productos> rep = new Repositorio<Productos>();
            Productos p = rep.Buscar(ToInt(ProductoIdTextBox.Text));

            if(p != null)
            {
                if (rep.Eliminar(ToInt(ProductoIdTextBox.Text)))
                {
                    CallModal("Se eliminado el producto");
                    Limpiar();

                }
                else
                    CallModal("No se pudo eliminar el producto");
                    Limpiar();
            }
        }

        protected void CostoCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(ToDecimal(CostoTextBox.Text) > ToDecimal(PrecioTextBox.Text))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void PrecioCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ToDecimal(PrecioTextBox.Text) > ToDecimal(PrecioTextBox.Text))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void PrecioTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CostoTextBox.Text != "" && PrecioTextBox.Text != "")
            {
                var ganancia = ProductosBLL.CalcularGanancias(ToDecimal(PrecioTextBox.Text), ToDecimal(CostoTextBox.Text));

                GananciaTextBox.Text = ganancia.ToString();
            }
            else
                GananciaTextBox.Text = "";
        }

        protected void GananciaTextBox_TextChanged(object sender, EventArgs e)
        {
            if (GananciaTextBox.Text != "")
            {
                var precio = ProductosBLL.CalcularPrecio(ToDecimal(CostoTextBox.Text), ToDecimal(GananciaTextBox.Text));
            }
            else
                PrecioTextBox.Text = "";
        }
    }
}