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
    public partial class cClientes : BasePage
    {
        Expression<Func<Clientes, bool>> filtro /*= x => true*/;
        
        Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
        public static List<Clientes> listClientes { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClienteReportViewer.ProcessingMode = ProcessingMode.Local;
                ClienteReportViewer.Reset();
                ClienteReportViewer.LocalReport.ReportPath = Server.MapPath(@"../Reportes/ReporteClientes.rdlc");
                ClienteReportViewer.LocalReport.DataSources.Clear();
                ClienteReportViewer.LocalReport.DataSources.Add(new ReportDataSource("ClientesDataSet", cClientes.listClientes));
                ClienteReportViewer.LocalReport.Refresh();
                FInicialTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                FFinalTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

                listClientes = repositorio.GetList(x => true);
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

                case 1://ClienteId
                    id = ToInt(BuscarTextBox.Text);
                    filtro = (p => p.ClienteId == id && p.Fecha >= desde && p.Fecha <= hasta);
                    break;

                case 2://Nombres
                    filtro = (p => p.Nombres.Contains(BuscarTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta);
                    break;

                case 3://Edad
                    //id = ToInt(BuscarTextBox.Text);
                    filtro = (p => p.Edad.Equals(BuscarTextBox.Text));
                    break;

                case 4: // sexo
                    filtro = (p => p.Sexo.Equals(BuscarTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta);
                    break;

                case 5: // ciudad
                    filtro = (p => p.Ciudad.Contains(BuscarTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta);
                    break;

                case 6: // Telefono
                    filtro = (p => p.Telefono.Contains(BuscarTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta);
                    break;

                case 7: // celular
                    filtro = (p => p.Sexo.Contains(BuscarTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta);
                    break;

                case 8: // Email
                    filtro =( p => p.Email.Contains(BuscarTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta);
                    break;
            }

            listClientes = repositorio.GetList(filtro);
            ClientesGridView.DataSource = listClientes;
            ClientesGridView.DataBind();
        }

        public static List<Clientes> RetornarClientes()
        {
            return listClientes;
        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Reportes/ReporteCliente.aspx");

            //ClienteReportViewer.LocalReport.DataSources.Clear();

            //ClienteReportViewer.LocalReport.DataSources.Add(
            //    new ReportDataSource(
            //        "Cliente",
            //        ClientesBLL.GetList<Clientes>(filtro)));
            //ClienteReportViewer.LocalReport.Refresh();

            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Report",
            //                "$(function() { openReport(); });", true);
        }
    }
}