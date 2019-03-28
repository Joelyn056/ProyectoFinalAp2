using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoFinalAp2.App_Code;
using Entidades;
using BLL;
using System.Linq.Expressions;
using Microsoft.Reporting.WebForms;
using System.Globalization;


namespace ProyectoFinalAp2.UI.Consultas
{
    public partial class cProductos : BasePage
    {
        Expression<Func<Productos, bool>> filtro; // = p => true;
        Repositorio<Productos> repositorio = new Repositorio<Productos>();

        public static List<Productos> listProductos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClienteReportViewer.ProcessingMode = ProcessingMode.Local;
                ClienteReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ReporteProducto.rdlc");
                ClienteReportViewer.AsyncRendering = true;

                FInicialTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                FFinalTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

                listProductos = repositorio.GetList(x => true);
            }

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            DateTime desde = Convert.ToDateTime(FInicialTextBox.Text);
            DateTime hasta = Convert.ToDateTime(FFinalTextBox.Text);

            if (hasta.Date < desde.Date)
            {
                CallModal("No Sera Posible Hacer Una Consulta Si El Rango Hasta Es Menor Que El Desde!!");
                return;
            }

            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = p => true && p.FechaRegistro >= desde && p.FechaRegistro <= hasta;
                    break;

                case 1://ProductoId
                    id = ToInt(BuscarTextBox.Text);
                    filtro = (p => p.ProductoId == id && p.FechaRegistro >= desde && p.FechaRegistro <= hasta);
                    break;

                case 2://Descripcion
                    filtro = (p => p.Descripcion.Contains(BuscarTextBox.Text) && p.FechaRegistro >= desde && p.FechaRegistro <= hasta);
                    break;

                case 3://fecha
                    DateTime date = DateTime.Parse(BuscarTextBox.Text);
                    filtro = (x => x.FechaRegistro == date);
                    break;

                case 4: // Costo
                    filtro = (p => p.Costo.Equals(BuscarTextBox.Text) && p.FechaRegistro >= desde && p.FechaRegistro <= hasta);
                    break;

                case 5: // Precio
                    filtro = (p => p.Precio.Equals(BuscarTextBox.Text) && p.FechaRegistro >= desde && p.FechaRegistro <= hasta);
                    break;

                case 6: // Ganancias
                    filtro = (p => p.Ganancias.Equals(BuscarTextBox.Text) && p.FechaRegistro >= desde && p.FechaRegistro <= hasta);
                    break;

            }

            listProductos = repositorio.GetList(filtro);
            ProductoGridView.DataSource = listProductos;
            ProductoGridView.DataBind();
        }

        public static List<Productos> retornarProducto()
        {
            return listProductos;
        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Reportes/ReporteProductos.aspx");

            //ProductoReportViewer.LocalReport.DataSources.Clear();

            //ProductoReportViewer.LocalReport.DataSources.Add(
            //    new ReportDataSource(
            //        "Cliente",
            //        ProductosBLL.GetList<Productos>(filtro)));
            //ProductoReportViewer.LocalReport.Refresh();

            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Report",
            //                "$(function() { openReport(); });", true);
        }
    }
}