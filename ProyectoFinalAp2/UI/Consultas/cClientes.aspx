<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cClientes.aspx.cs" Inherits="ProyectoFinalAp2.UI.Consultas.cClientes" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function openReport() {
            $("#<%=reportModal.ClientID%>").modal({
                backdrop: 'static',
                keyboard: false
            }); 
            $("#<%=reportModal.ClientID%>").modal("show");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">
    <div class="card">
        <div class="card-header text-white text-center bg-success">
            <h3>Consulta de clientes</h3>
        </div>

        <!--Car body-->
        <div class="card-body">

            <!--Rango fecha-->
            <div class="form-group row justify-content-center">
                <div class="col-lg-4">
                    <asp:Label ID="Label1" runat="server" Text="Fecha-inicio">Desde:</asp:Label>
                    <asp:TextBox ID="FInicialTextBox" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-2"></div>
                <div class="col-lg-4">
                    <asp:Label ID="Label2" runat="server" Text="Fecha-inicial">Hasta:</asp:Label>
                    <asp:TextBox ID="FFinalTextBox" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                </div>

            </div>

            <!--Filtro-->
            <div class="row justify-content-center">
                <div class="col-lg-4">
                    <asp:Label ID="FiltroLabel"  runat="server" Text="Filtrar-por"> Filtro: </asp:Label>
                    <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>ClienteId</asp:ListItem>
                        <asp:ListItem>Nombres</asp:ListItem>
                        <asp:ListItem>Edad</asp:ListItem>
                        <asp:ListItem>Sexo</asp:ListItem>
                        <asp:ListItem>Ciudad</asp:ListItem>
                        <asp:ListItem>Telefono</asp:ListItem>
                        <asp:ListItem>Celular</asp:ListItem>
                        <asp:ListItem>Email</asp:ListItem>
                    </asp:DropDownList>
                </div>  
                <div class="col-lg-1"></div>
                <div class="col-lg-4">
                    <asp:Label ID="BuscarLabel" runat="server" Text="Buscar">Buscar:</asp:Label>
                    <asp:TextBox ID="BuscarTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1 p-0">
                    <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-secondary mt-4" runat="server" OnClick="BuscarLinkButton_Click"> <span class="fas fa-search"></span>Buscar </asp:LinkButton>
                </div>
            </div>

            <!--Grid-->
            <div class="row justify-content-center mt-3">
                <div class="col-lg-11">       
                    <asp:GridView ID="ClientesGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                   <%-- <asp:GridView ID="ClientesGridView" runat="server" AllowPaging="true" PageSize="7" CssClass="table table-striped table-hover table-responsive-lg" AutoGenerateColumns="False" OnPageIndexChanging="ClientesGridView_PageIndexChanging">--%>
                        <Columns>
                            <asp:BoundField DataField="ClienteId" HeaderText="ClienteId" />
                            <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                            <asp:BoundField DataField="Edad" HeaderText="Edad" />
                            <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
                            <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                            <asp:BoundField DataField="Celular" HeaderText="Celular" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                        </Columns>    
                    </asp:GridView>
                </div>
            </div>

            <!--Imprmir-->
            <div class="row justify-content-end">
                <div class="col-lg-2">
                    <asp:LinkButton ID="ImprimirLinkButton" CssClass=" btn btn-warning" runat="server" OnClick="ImprimirLinkButton_Click"> 
                        <span class="fas fa-print"></span>
                        Imprimi
                    </asp:LinkButton>
                </div>
            </div>
        </div>  
        <!--end card-->
    </div>

    <!--Report Modal-->
    <div class="modal fade" id="reportModal"  role="dialog" runat="server">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <!--Body-->
                <div class="modal-body">
                    <rsweb:reportviewer ID="ClienteReportViewer" Width="100%" runat="server">
                        <ServerReport ReportPath=""  ReportServerUrl=""/>
                    </rsweb:reportviewer>
                </div>

                <!--Footer-->
                <div class="modal-footer">
                    <button class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
