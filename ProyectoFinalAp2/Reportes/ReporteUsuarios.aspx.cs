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
    public partial class ReporteUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuariosReportViewer.ProcessingMode = ProcessingMode.Local;
                UsuariosReportViewer.Reset();
                UsuariosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~/Reportes/ReporteUsuarios.rdlc");
                UsuariosReportViewer.LocalReport.DataSources.Clear();
                UsuariosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", cUsuarios.listUsuarios));
                UsuariosReportViewer.LocalReport.Refresh();

            }
        }
    }
}