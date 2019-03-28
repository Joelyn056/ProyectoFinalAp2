using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using ProyectoFinalAp2.UI.Consultas;


namespace ProyectoFinalAp2.Reportes
{
    public partial class ReporteProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductosReportViewer.ProcessingMode = ProcessingMode.Local;
                ProductosReportViewer.Reset();
                ProductosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~/Reportes/ReporteProductos.rdlc");
                ProductosReportViewer.LocalReport.DataSources.Clear();
                ProductosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", cProductos.listProductos));
                ProductosReportViewer.LocalReport.Refresh();

            }
        }
    }
}