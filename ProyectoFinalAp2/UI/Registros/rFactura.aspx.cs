using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BLL;
using ProyectoFinalAp2.App_Code;
using Microsoft.Reporting.WebForms;


namespace ProyectoFinalAp2.UI.Registros
{
    public partial class rFactura : BasePage
    {
        private Facturas facturas = new Facturas();
        private Repositorio<Clientes> repositorioCliente = new Repositorio<Clientes>();
        private Repositorio<Productos> repositorioProducto = new Repositorio<Productos>();

        private FacturaRepositorio FacturaRepositorio = new FacturaRepositorio();
        private List<FacturaDetalles> detalles = new List<FacturaDetalles>();

        string condicion = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EnableViewState = true;
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                ViewState.Add("Detalle", detalles);
                ViewState.Add("Factura", facturas);

                LlenarDropDownListProductos();
                LlenarDropDownListClientes();
            }
            else
            {            
                detalles = (List<FacturaDetalles>)ViewState["Detalle"];
                //facturas = (Facturas)ViewState["Factura"];
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
            facturas.Fecha = ToDateTime(FechaTextBox.Text);
            facturas.ClienteId = ToInt(ClienteDropDownList.SelectedValue);
            facturas.Total = ToDecimal(MontoTextBox.Text);
            facturas.Detalle = detalles;

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
            FacturaGridView.DataBind();///nueva linea
            //ViewState["Detalle"] = null;


        }

        private void LlenarCampo(Facturas facturas)
        {
            //ClienteDropDownList.SelectedValue = facturas.ClienteId.ToString();
            //FacturaGridView.DataSource = facturas.Detalle;
            //FacturaGridView.DataBind();
            //MontoTextBox.Text = facturas.Total.ToString();


            ClienteDropDownList.DataSource = repositorioProducto.GetList(x => true);
            ProductoDropDownList.DataValueField = "ProductoId";
            ProductoDropDownList.DataTextField = "Descripcion";
            ProductoDropDownList.AppendDataBoundItems = true;
            ProductoDropDownList.DataBind();
            FiltrarPrecio();
        }


        private void LlenarDropDownListProductos()
        {
            ProductoDropDownList.DataSource = repositorioProducto.GetList(x => true);
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
            foreach (var item in facturas.Detalle)
                //(List<FacturaDetalles>)ViewState["Detalle"])
            {

                monto += FacturasBLL.CalcularSubTotal(item.Importe);
            }

            return MontoTextBox.Text = monto.ToString();
        }
        

        protected void BuscarLinkButton_Click1(object sender, EventArgs e)
        {
            if (!isRefresh)
            {
                Repositorio<Facturas> rep = new Repositorio<Facturas>();
                Facturas f = rep.Buscar(ToInt(FacturaIdTextBox.Text));

                if (f != null)             
                {
                    LlenarCampo(f);
                    Limpiar();
                }  
                else
                {
                    CallModal("Esta factura no Existe");
                    Limpiar();
                }
                
            }
        }
        
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton2_Click(object sender, EventArgs e)
        {
            //Repositorio<Facturas> repositorio = new Repositorio<Facturas>();
            FacturaRepositorio repositorio = new FacturaRepositorio();
            Facturas factura = repositorio.Buscar(ToInt(FacturaIdTextBox.Text));

            if (IsValid)
            {
                factura = FacturaRepositorio.Buscar(ToInt(FacturaIdTextBox.Text));

                if (factura == null)
                {
                    if(repositorio.Guardar(LlenaClase()))
                    {

                     CallModal("Factura Guardada");
                     Limpiar();
                    }
                    else
                    {
                        CallModal("No se pudo guardar la Factura");
                        Limpiar();
                    }

                }
                else
                {
                    if (repositorio.Modificar(LlenaClase()))
                    {
                        CallModal("Factura Modificada");
                        Limpiar();
                    }
                    else
                    {
                        CallModal("No se modifico");
                        Limpiar();
                    }
                }

            }
           
        }

        protected void EliminarButton3_Click(object sender, EventArgs e)
        {
            GridViewRow grid = FacturaGridView.SelectedRow;
            List<FacturaDetalles> lista = (List<FacturaDetalles>)ViewState["Detalle"];
            Repositorio<Facturas> repositorio = new Repositorio<Facturas>();
           Facturas factura = repositorio.Buscar(ToInt(FacturaIdTextBox.Text));

            if (IsValid)
            {
                if(factura != null)
                {
                    FacturaRepositorio.Eliminar(factura.FacturaId);
                    //ViewState["Detalle"] = lista;
                    FacturaGridView.DataSource = ViewState["Detalle"];
                    FacturaGridView.DataBind();
                    CallModal("Factura Eliminada");
                    Limpiar();
                }
                else
                {
                    CallModal("No se Elimino la factura");
                    Limpiar();
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

     
        protected void AddLinkButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
               
                detalles.Add(new FacturaDetalles(
                    0,
                    ToInt(FacturaIdTextBox.Text),
                    ToInt(ProductoDropDownList.SelectedValue),
                    ProductoDropDownList.SelectedItem.ToString(),
                    ToInt(CantidadTextBox.Text),
                    ToDecimal(PrecioTextBox.Text),
                    ToDecimal(ImporteTextBox.Text)                 
                    ));
                           
                ViewState["Detalle"] = detalles;
                //this.BindGrid();
                FacturaGridView.DataSource = detalles;
                FacturaGridView.DataBind();
               
            }
        }

        protected void FacturaGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FacturaGridView.DataSource = ViewState["Factura"];
            FacturaGridView.PageIndex = e.NewPageIndex;
            FacturaGridView.DataBind();
        }

        protected void ProductoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarPrecio();
        }

        protected void CantidadTextBox_TextChanged(object sender, EventArgs e)
        {
            ImporteTextBox.Text = FacturasBLL.CalcularImporte(ToDecimal(CantidadTextBox.Text), ToDecimal(PrecioTextBox.Text)).ToString();
        }

        protected void MontoTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        
        

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //if(FacturaGridView.Rows.Count > 0  && FacturaGridView.CurrentRow ! == null )
            //{
            //    List<FacturaDetalles> detalles = (List<FacturaDetalles>)FacturaGridView.DataSource;
            //    detalles.RemoveAt(FacturaGridView.CurrentRow.Index);

            //} 
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Reportes/ReporteFactura.aspx");
        }
    }
}