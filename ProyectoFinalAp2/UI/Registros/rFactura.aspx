<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rFactura.aspx.cs" Inherits="ProyectoFinalAp2.UI.Registros.rFactura" %>

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
        <!--Card header-->
        <div class="card-header text-white text-center bg-success">
            <h3>Facturacion</h3>
        </div>

        <!--Card body-->
        <div class="card-body">

            <%--<div class="card card-register mx-auto mt-5">
                <div class="card-header text-uppercase text-center text-primary">Facturacion</div>
                <div class="card-body">--%>

            <div class="form-row">
                <%--FacturaId--%>
                <div class="form-group col-md-1">
                    <asp:Label Text="FacturaId" runat="server" />
                    <asp:TextBox ID="FacturaIdTextBox" class="form-control input-sm" TextMode="Number" runat="server" placeholder="0"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVId" ValidationGroup="Buscar" ControlToValidate="FacturaIdTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                </div>

                <%--Fecha--%>
                <div class="form-group col-md-3">
                    <asp:Label Text="Fecha" runat="server" />
                    <asp:TextBox ID="FechaTextBox" class="form-control input-sm" TextMode="Date" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVFFecha" ValidationGroup="Guardar" ControlToValidate="FechaTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <div class="col-lg-1 p-0">
                    <asp:LinkButton ID="BuscarLinkButton" CausesValidation="false" CssClass="btn btn-primary mt-4" runat="server" OnClick="BuscarLinkButton_Click1">
                                <span class="fas fa-search"></span>
                                     Buscar
                    </asp:LinkButton>
                </div>
            </div>
            <div class="form-row">
                <%--Cliente--%>
                <div class="form-group col-md-3">
                    <asp:Label Text="Cliente" runat="server" />
                    <asp:DropDownList ID="ClienteDropDownList" AutoPostBack="true" class="form-control input-sm" runat="server">
                        <asp:ListItem Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ClienteDropDownList" ValidationGroup="Guardar" SetFocusOnError="true" runat="server" ErrorMessage="Cliente: Seleccione un cliente" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <%--Producto--%>
                <div class="form-group col-md-3">
                    <asp:Label Text="Producto" runat="server" />
                    <asp:DropDownList ID="ProductoDropDownList" AutoPostBack="true" OnSelectedIndexChanged="ProductoDropDownList_SelectedIndexChanged" CssClass="form-control" runat="server">
                        <asp:ListItem Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ProductoDropDownList" ValidationGroup="Guardar" ErrorMessage="Producto: Seleccione un producto" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>

                <%--Precio--%>
                <div class="form-group col-md-1">
                    <asp:Label Text="Precio" runat="server" />
                    <asp:TextBox ID="PrecioTextBox" class="form-control input-sm" AutoPostBack="true" ReadOnly="true" AutoCompleteType="Disabled" TextMode="Number" runat="server" placeholder="0"></asp:TextBox>
                </div>

                <%--Cantidad--%>
                <div class="form-group col-md-1">
                    <asp:Label Text="Cantidad" runat="server" />
                    <asp:TextBox ID="CantidadTextBox" class="form-control input-sm" AutoPostBack="true" AutoCompleteType="Disabled" TextMode="Number" runat="server" placeholder="0" OnTextChanged="CantidadTextBox_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="Agregar" ControlToValidate="CantidadTextBox" ErrorMessage="No Hay Cantidad"></asp:RequiredFieldValidator>
                </div>

                <%--Importe--%>
                <div class="form-group col-md-1">
                    <asp:Label Text="Importe" runat="server" />
                    <asp:TextBox ID="ImporteTextBox" class="form-control input-sm" AutoPostBack="true" OnTextChanged="ImporteTextBox_TextChanged" AutoCompleteType="Disabled" TextMode="Number" runat="server" placeholder="0"></asp:TextBox>
                </div>
       
                <!--Añadir boton-->
                <div class="col-lg-1 ">
                    <asp:LinkButton ID="AddLinkButton" CssClass="btn btn-primary mt-4" runat="server" OnClick="AddLinkButton_Click">
                          <span class="fas fa-plus"></span>
                          Agregar
                    </asp:LinkButton>
                </div>

                <%--Remober fila--%>
                <div class="col-lg-1 ">
                    <asp:LinkButton ID="RemoberLinkButton" CssClass="btn btn-danger mt-4" runat="server" OnClick="LinkButton1_Click" >
                          <span class="fas fa-times"></span>
                          Remover
                    </asp:LinkButton>
                </div>

            </div>
            <!--Grid-->
            <div class="row justify-content-center">
                <div class="col-lg-11">
                    <asp:GridView ID="FacturaGridView" OnPageIndexChanging="FacturaGridView_PageIndexChanging" runat="server"  CellPadding="4" AllowPaging="true" PageSize="7" ForeColor="#333333" GridLines="None" class="table table-condensed table-bordered table-responsive-lg" AutoGenerateColumns="False">
                        <%--  <asp:GridView ID="FacturaGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="FacturaGridView_SelectedIndexChanged">--%>
                        <%--<asp:GridView ID="FacturaGridView" runat="server" AllowPaging="True" PageSize="7" CssClass="table table-striped table-hover table-responsive-lg" AutoGenerateColumns="False" OnPageIndexChanging="ClientesGridView_PageIndexChanging" OnRowCancelingEdit="FacturaGridView_RowCancelingEdit" OnRowEditing="FacturaGridView_RowEditing" OnRowUpdating="FacturaGridView_RowUpdating">--%>
                        <Columns>
                            <asp:CommandField ControlStyle-CssClass="btn btn-secondary" ButtonType="Button"/>  <%-- ShowEditButton="True"--%> 
                            <asp:BoundField DataField="FacturaId" HeaderText="FacturaId" ReadOnly="True" />
                            <asp:BoundField DataField="ProductoId" HeaderText="ProductoId" ReadOnly="True" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" ReadOnly="True" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ReadOnly="True" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" ReadOnly="True" />
                            <asp:BoundField DataField="Importe" HeaderText="Importe" ReadOnly="True" />

                        </Columns>
                    </asp:GridView>
                </div>
            </div>


            <!--Monto-->
            <div class="form-group row justify-content-end">
                <asp:Label ID="Label4" CssClass="col-lg-1 col-form-label" runat="server" Text="Monto">Monto:</asp:Label>
                <div class="col-lg-2 mr-5 ">
                    <asp:TextBox ID="MontoTextBox" CssClass="form-control input-sm" AutoPostBack="true" ReadOnly="true" TextMode="Number" runat="server" OnTextChanged="MontoTextBox_TextChanged"></asp:TextBox>
                </div>
            </div>


            <!--Card body end-->
           

                <!--Card footer-->
            <div class="card-footer">

                <!--Butones-->

                <div class="row justify-content-center">

                    <!--Nuevo-->
                    <div class="form-group">
                        <asp:LinkButton ID="NuevoButton" CssClass="btn btn-primary mt-4" OnClick="NuevoButton_Click" runat="server">
                            <span class="fas fa-plus"></span>
                            Nuevo
                        </asp:LinkButton>

                        <!--Guardar-->
                        <asp:LinkButton ID="GuardarButton2" CssClass="btn btn-success mt-4" OnClick="GuardarButton2_Click" runat="server">
                            <span class="fas fa-save"></span>
                            Guardar
                        </asp:LinkButton>

                        <!--Eliminar-->
                        <asp:LinkButton ID="EliminarButton3" CssClass="btn btn-danger mt-4" OnClick="EliminarButton3_Click" runat="server">
                            <span class="fas fa-trash-alt"></span>
                            Eliminar
                        </asp:LinkButton>

                           <!--Imprimir-->       
                <asp:LinkButton ID="ImprimirButton" CssClass="btn btn-warning mt-4" runat="server" OnClick="ImprimirButton_Click">
                            <span class="fas fa-print"></span>
                            Imprimir
                </asp:LinkButton>
                    </div>
            </div>

        </div>
      </div>

    </div>

    <!--Report Modal-->
    <div class="modal fade" id="reportModal" role="dialog" runat="server">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <!--Body-->
                <div class="modal-body">
                    <rsweb:ReportViewer ID="rFacturaReportViewer" Width="100%" runat="server">
                        <ServerReport ReportPath="" ReportServerUrl="" />
                    </rsweb:ReportViewer>
                </div>

                <!--Footer-->
                <div class="modal-footer">
                    <button class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <%--</div>--%>

    <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false" runat="server" />
</asp:Content>
