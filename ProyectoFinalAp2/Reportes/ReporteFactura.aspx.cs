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
    public partial class ReporteFactura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                FacturaReportViewer.ProcessingMode = ProcessingMode.Local;
                FacturaReportViewer.Reset();
                FacturaReportViewer.LocalReport.ReportPath = Server.MapPath(@"~/Reportes/ReporteFactura.rdlc");
                FacturaReportViewer.LocalReport.DataSources.Clear();
                FacturaReportViewer.LocalReport.DataSources.Add(new ReportDataSource("ProductoDataSet", cFactura.listFacturas));
                FacturaReportViewer.LocalReport.Refresh();

            }
        }
    }
}