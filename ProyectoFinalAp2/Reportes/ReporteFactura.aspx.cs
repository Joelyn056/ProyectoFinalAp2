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
                FactutaReportViewer.ProcessingMode = ProcessingMode.Local;
                FactutaReportViewer.Reset();
                FactutaReportViewer.LocalReport.ReportPath = Server.MapPath(@"~/Reportes/ReporteFactura.rdlc");
                FactutaReportViewer.LocalReport.DataSources.Clear();
                FactutaReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", cClientes.listClientes));
                FactutaReportViewer.LocalReport.Refresh();

            }
        }
    }
}