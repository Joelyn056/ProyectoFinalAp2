﻿using System;
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
    public partial class cUsuarios : BasePage
    {
        Expression<Func<Usuarios, bool>> filtro;// = p => true;
        Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
        public static List<Usuarios> listUsuarios { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuariosReportViewer.ProcessingMode = ProcessingMode.Local;
                UsuariosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ReporteUsuarios.rdlc");
                UsuariosReportViewer.AsyncRendering = true;

                FInicialTextBox.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
                FFinalTextBox.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");

                listUsuarios = repositorio.GetList(x => true);
            }
        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
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
                    filtro = p => true; /*&& p.Fecha >= desde && p.Fecha <= hasta*/
                    break;

                case 1://UsuarioId
                    id = ToInt(BuscarTextBox.Text);
                    filtro = (p => p.UsuarioId == id && p.Fecha >= desde && p.Fecha <= hasta);
                    break;

                case 2://fecha
                    DateTime date = DateTime.Parse(BuscarTextBox.Text);
                    filtro = (x => x.Fecha == date);
                    break;

                case 3://Usuario
                    filtro = (p => p.Usuario.Contains(BuscarTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta);
                    break;              

                case 4: // NombreUsuario
                    filtro = (p => p.NombreUsuario.Equals(BuscarTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta);
                    break;

                //case 5: // Contraseña
                //    filtro = (p => p.Contraseña.Equals(BuscarTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta);
                //    break;

            }

            listUsuarios = repositorio.GetList(filtro);
            UsuarioGridView.DataSource = listUsuarios;
            UsuarioGridView.DataBind();
        }

        public static List<Usuarios> RetornarUsuarios()
        {
            return listUsuarios;
        }

        UsuarioReportViewer.LocalReport.DataSources.Clear();

            UsuarioReportViewer.LocalReport.DataSources.Add(
                new ReportDataSource(
                    "Cliente",
                    UsuariosBLL.GetList<Usuarios>(filtro)));
            UsuarioReportViewer.LocalReport.Refresh();

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Report",
                            "$(function() { openReport(); });", true);
    }
}