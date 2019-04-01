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
            ProductosReporteViewer.ProcessingMode = ProcessingMode.Local;
            ProductosReporteViewer.Reset();
            ProductosReporteViewer.LocalReport.ReportPath = Server.MapPath(@"~/Reportes/ReporteProductos.rdlc");
            ProductosReporteViewer.LocalReport.DataSources.Clear();
            ProductosReporteViewer.LocalReport.DataSources.Add(new ReportDataSource("ProductosDataSet", cClientes.listClientes));
            ProductosReporteViewer.LocalReport.Refresh();

        }
    }
}