using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoFinalAp2.App_Code;
using Microsoft.Reporting.WebForms;
using Entidades;
using BLL;
using System.Linq.Expressions;
using System.Globalization;



namespace ProyectoFinalAp2.UI.Consultas
{
    public partial class cFactura : BasePage
    {
        Expression<Func<Facturas, bool>> filtro; /*= x => true*/
        Repositorio<Facturas> repositorio = new Repositorio<Facturas>();
        public static List<Facturas> listFacturas { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FacturaReportViewer.ProcessingMode = ProcessingMode.Local;
                FacturaReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ReporteFactura.rdlc");
                FacturaReportViewer.LocalReport.DataSources.Clear();
                FacturaReportViewer.LocalReport.DataSources.Add(new ReportDataSource("FacturaDataSet", cFactura.listFacturas));
                FacturaReportViewer.LocalReport.Refresh();
                FacturaReportViewer.AsyncRendering = true;

                FInicialTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                FFinalTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

                listFacturas = repositorio.GetList(x => true);
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
                    filtro = p => true && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 1://FacturaId
                    id = ToInt(BuscarTextBox.Text);
                    filtro = (p => p.FacturaId == id && p.Fecha >= desde && p.Fecha <= hasta);
                    break;

                case 2://fecha
                    DateTime date = DateTime.Parse(BuscarTextBox.Text);
                    filtro = (x => x.Fecha == date);
                    break;

                case 3://ClienteId
                    id = ToInt(BuscarLinkButton.Text);
                    filtro = (p => p.ClienteId == id && p.Fecha >= desde && p.Fecha <= hasta);
                    break;

                //case 4: //Monto
                //    decimal monto = ToDecimal(BuscarLinkButton.Text);
                //    filtro = p => p.ClienteId.Equals(monto) && p.Fecha >=  desde && p.Fecha <= hasta;
              

            }

            listFacturas = repositorio.GetList(filtro);
            FacturaGridView.DataSource = listFacturas;
            FacturaGridView.DataBind();
        }

        public static List<Facturas> RetornarClientes()
        {
            return listFacturas;
        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Reportes/ReporteFactura.aspx");
        }
    }
}