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
    public partial class ReporteCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientesReporteViewer.ProcessingMode = ProcessingMode.Local;
                ClientesReporteViewer.Reset();
                ClientesReporteViewer.LocalReport.ReportPath = Server.MapPath(@"~/Reportes/ReporteClientes.rdlc");
                ClientesReporteViewer.LocalReport.DataSources.Clear();
                ClientesReporteViewer.LocalReport.DataSources.Add(new ReportDataSource("ClientesDataSet", cClientes.listClientes));
                ClientesReporteViewer.LocalReport.Refresh();

                

            }
        }
    }
}