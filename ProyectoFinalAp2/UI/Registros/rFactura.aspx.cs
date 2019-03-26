using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BLL;
using ProyectoFinalAp2.App_Code;


namespace ProyectoFinalAp2.UI.Registros
{
    public partial class rFactura : BasePage
    {
        private Facturas facturas = new Facturas();
        private Repositorio<Clientes> repositorioCliente = new Repositorio<Clientes>();
        private Repositorio<Productos> repositorioProducto = new Repositorio<Productos>();

        private FacturaRepositorio FacturaRepositorio = new FacturaRepositorio();
        private List<FacturaDetalles> detalles = new List<FacturaDetalles>();

        string condicion = "[Seleccione]";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("dd-MM-yyyy");

                ViewState["Detalle"] = new FacturaDetalles();
                LlenarDropDownListProductos();
                LlenarDropDownListClientes();
            }

        }

        private void FiltrarPrecio()
        {
            if (ProductoDropDownList.Text != condicion)
            {
                int id = Convert.ToInt32(ProductoDropDownList.SelectedValue);
                PrecioTextBox.Text = repositorioProducto.Buscar(id).Precio.ToString();
            }
            else
            {
                PrecioTextBox.Text = "";
            }
        }

        protected void BindGrid()
        {
            FacturaGridView.DataSource = ((Facturas)ViewState["Factura"]).Detalle;
            FacturaGridView.DataBind();
        }

        private List<FacturaDetalles> ListaVacia()
        {
            List<FacturaDetalles> facturas = new List<FacturaDetalles>();
            facturas.Add(new FacturaDetalles());

            return facturas;
        }

        private Facturas LlenaClase()
        {
            facturas.FacturaId = ToInt(FacturaIdTextBox.Text);
            DateTime.Parse(FechaTextBox.Text);
            facturas.ClienteId = ToInt(ClienteDropDownList.SelectedValue);
            facturas.Total = ToDecimal(MontoTextBox.Text);
            facturas.Detalle = (List<FacturaDetalles>)ViewState["Detalle"];

            return facturas;
        }

        private void Limpiar()
        {
            FacturaIdTextBox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.ToString("dd-MM-yyyy");
            ClienteDropDownList.SelectedIndex = 0;
            ProductoDropDownList.SelectedIndex = 0;
            CantidadTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            ImporteTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;           
            FacturaGridView.DataSource = null;
            ViewState["Detalle"] = null;


        }

        private void LlenarCampo(Facturas facturas)
        {
            ClienteDropDownList.DataSource = repositorioProducto.GetList(x => x.Inventario > 0);
            ProductoDropDownList.DataValueField = "ProductoId";
            ProductoDropDownList.DataTextField = "Descripcion";
            ProductoDropDownList.AppendDataBoundItems = true;
            ProductoDropDownList.DataBind();
            FiltrarPrecio();
        }


        private void LlenarDropDownListProductos()
        {
            ProductoDropDownList.DataSource = repositorioProducto.GetList(x => x.Inventario > 0);
            ProductoDropDownList.DataValueField = "ProductoId";
            ProductoDropDownList.DataTextField = "Descripcion";
            ProductoDropDownList.AppendDataBoundItems = true;
            ProductoDropDownList.DataBind();
            FiltrarPrecio();

        }

        private void LlenarDropDownListClientes()
        {
            ClienteDropDownList.DataSource = repositorioCliente.GetList(x => true);
            ClienteDropDownList.DataValueField = "ClienteId";
            ClienteDropDownList.DataTextField = "Nombres";
            ClienteDropDownList.AppendDataBoundItems = true;
            ClienteDropDownList.DataBind();
        }

        private string SubTotal()
        {
            decimal monto = 0;
            foreach (var item in (List<FacturaDetalles>) ViewState["Detalle"] )
            {

                monto += FacturasBLL.CalcularSubTotal(item.Importe);
            }

            return MontoTextBox.Text = monto.ToString();
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            if(! isRefresh)
            {
                facturas = FacturaRepositorio.Buscar(ToInt(FacturaIdTextBox.Text));

                if(facturas != null)
                {
                    CallModal("Se encontro la factura");
                    LlenarCampo(facturas);
                }
                else
                {
                    CallModal("No hay resultado");
                }
            }
        }

        protected void CVClientes_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Equals(condicion))
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        protected void CVProducto_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Equals(condicion))
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        protected void CVCantidad_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Equals(0))
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        protected void CVImporte_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Equals(0))
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        protected void ImporteTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ImporteTextBox.Text != "")
                MontoTextBox.Text = FacturasBLL.CalcularSubTotal(ToDecimal(ImporteTextBox.Text)).ToString();
            else
                MontoTextBox.Text = "";
        }

        protected void FacturaGridView_PageIndexChanging(object sender, EventArgs e)
        {
            FacturaGridView.DataSource = ViewState["Factura"];
            FacturaGridView.PageIndex = e.NewPageIndex;
            FacturaGridView.DataBind();
        }

        protected void AddLinkButton_Click(object sender, EventArgs e)
        {
            if (facturas != null)
            {
                if (facturas.Detalle.Exists(x => x.ProductoId.Equals(ToInt(ProductoDropDownList.SelectedValue))))
                {
                    var producto = facturas.Detalle.Where(x => x.ProductoId.Equals(ToInt(ProductoDropDownList.SelectedValue)));

                }

                if (((FacturaDetalles)ViewState["Detalle"]).Id != 0)
                {
                    facturas.Detalle.Add(new FacturaDetalles(((FacturaDetalles)ViewState["Detalle"]).Id, facturas.FacturaId,ToInt(ProductoDropDownList.SelectedValue), 
                        ProductoDropDownList.Text,ToInt(CantidadTextBox.Text), ToDecimal(PrecioTextBox.Text), ToDecimal(ImporteTextBox.Text)));
                }
                else
                    facturas.Detalle.Add(new FacturaDetalles(0, facturas.FacturaId, ToInt(ProductoDropDownList.SelectedValue), ProductoDropDownList.SelectedItem.ToString(), 
                        ToInt(CantidadTextBox.Text), ToDecimal(PrecioTextBox.Text), ToDecimal(ImporteTextBox.Text)));
                ViewState["Detalle"] = new FacturaDetalles();
            }
            else
            {
                facturas.Detalle.Add(new FacturaDetalles(0, 0, ToInt(ProductoDropDownList.SelectedValue), ProductoDropDownList.SelectedItem.ToString(),
                    ToInt(CantidadTextBox.Text), ToDecimal(PrecioTextBox.Text), ToDecimal(ImporteTextBox.Text)));
                ViewState["Detalle"] = facturas.Detalle;
            }
            SubTotal();
            FacturaGridView.DataSource = ViewState["Detalle"];
            FacturaGridView.DataBind();
        }

        protected void FacturaGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FacturaGridView.DataSource = ViewState["Factura"];
            FacturaGridView.PageIndex = e.NewPageIndex;
            FacturaGridView.DataBind();
        }

    }
}