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
    public partial class ReporteProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ProductoReporteViewer.ProcessingMode = ProcessingMode.Local;
                ProductoReporteViewer.Reset();
                ProductoReporteViewer.LocalReport.ReportPath = Server.MapPath(@"~/Reportes/ReporteProducto.rdlc");
                ProductoReporteViewer.LocalReport.DataSources.Clear();
                ProductoReporteViewer.LocalReport.DataSources.Add(new ReportDataSource("Producto", cProducto.listProductos));
                ProductoReporteViewer.LocalReport.Refresh();
            }
        }
    }
}