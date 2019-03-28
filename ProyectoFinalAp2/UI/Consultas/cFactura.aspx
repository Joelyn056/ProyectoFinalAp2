<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cFactura.aspx.cs" Inherits="ProyectoFinalAp2.UI.Consultas.cFactura" %>

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
            <h3>Consulta de facturas</h3>
        </div>

        <!--Card body-->
        <div class="card-body">
            <!--Rango de fechas-->
            <div class="form-group row justify-content-center">
                <div class="col-lg-4">
                    <asp:Label ID="Label1" runat="server" Text="Fecha-inicio">Desde:</asp:Label>
                    <asp:TextBox ID="FInicialTextBox" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-4">
                    <asp:Label ID="Label2" runat="server" Text="Fecha-inicial">Hasta:</asp:Label>
                    <asp:TextBox ID="FFinalTextBox" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                </div>
            </div>

            <!--Filtro-->
            <div class="row justify-content-center">
                <div class="col-lg-4">
                    <asp:Label ID="FiltroLabel"  runat="server" Text="Filtrar-por">
                        Filtro:
                    </asp:Label>
                    <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>FacturaId</asp:ListItem>
                        <asp:ListItem>Fecha</asp:ListItem>
                        <asp:ListItem>ClienteId</asp:ListItem>
                        <asp:ListItem>Descripcion</asp:ListItem>
                        <asp:ListItem>Cantidad</asp:ListItem>
                        <asp:ListItem>Precio</asp:ListItem>
                        <asp:ListItem>Monto</asp:ListItem>                                         
                    </asp:DropDownList>
                </div>  

                <div class="col-lg-1"></div>
                <div class="col-lg-4">
                    <asp:Label ID="BuscarLabel" runat="server" Text="Buscar">Buscar:</asp:Label>
                    <asp:TextBox ID="BuscarTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1 p-0">
                    <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-secondary mt-4" runat="server" OnClick="BuscarLinkButton_Click">
                        <span class="fas fa-search"></span>
                        Buscar
                    </asp:LinkButton>
                </div>
            </div>

            <!--Grid-->
            <div class="row justify-content-center mt-3">
                <div class="col-lg-11">     
                      <asp:GridView ID="FacturaGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <%--<asp:GridView ID="FacturaGridView" runat="server" AllowPaging="true" PageSize="7" CssClass="table table-striped table-hover table-responsive-lg" AutoGenerateColumns="False" OnPageIndexChanging="FacturaGridView_PageIndexChanging">--%>
                        <Columns>
                            <asp:BoundField DataField="FacturaId" HeaderText="FacturaId" />
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                            <asp:BoundField DataField="ClienteId" HeaderText="ClienteId" />
                           <%-- <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />--%>
                           <%-- <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" />
                            <asp:BoundField DataField="Monto" HeaderText="Monto" />--%>


                        </Columns>    
                    </asp:GridView>
                </div>
            </div>

            <!--Imprmir-->
            <div class="row justify-content-end">
                <div class="col-lg-2">
                    <asp:LinkButton ID="ImprimirLinkButton" CssClass="btn btn-warning" runat="server" OnClick="ImprimirLinkButton_Click" >
                        <span class="fas fa-print"></span>
                        Imprimir
                    </asp:LinkButton>
                </div>
            </div>
        <!--Card body end-->
        </div>
    </div>

    <!--Report Modal-->
    <div class="modal fade" id="reportModal"  role="dialog" runat="server">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <!--Body-->
                <div class="modal-body">
                    <rsweb:ReportViewer ID="FacturaReportViewer" Width="100%" runat="server">
                        <ServerReport ReportPath=""  ReportServerUrl=""/>
                    </rsweb:ReportViewer>
                </div>

                <!--Footer-->
                <div class="modal-footer">
                    <button class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
