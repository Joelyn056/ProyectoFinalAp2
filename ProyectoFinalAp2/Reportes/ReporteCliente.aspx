﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteCliente.aspx.cs" Inherits="ProyectoFinalAp2.Reportes.ReporteCliente" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>     
        html, body, form, #div1{
            height: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div1">
           <%---ScriptManager---%>
            <asp:ScriptManager runat="server"></asp:ScriptManager>

            <rsweb:ReportViewer ID="ClientesReporteViewer" runat="server"  Height="800px" Width="1000px" ProcessingMode="Remote">
                <ServerReport ReportPath="" ReportServerUrl="" />
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
