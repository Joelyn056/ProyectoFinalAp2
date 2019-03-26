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
                            <asp:Label Text="FacturaId" class="text-primary" runat="server" />
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
                            <asp:LinkButton ID="BuscarLinkButton" CausesValidation="false" CssClass="btn btn-primary mt-4" runat="server" >
                                <span class="fas fa-search"></span>
                                     Buscar
                            </asp:LinkButton>
                        </div>

                        <div class="form-row">
                            <%--Cliente--%>
                            <div class="form-group col-md-3">
                                <asp:Label Text="Cliente" runat="server" />
                                <asp:DropDownList ID="ClienteDropDownList" AutoPostBack="true" class="form-control input-sm" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                                <asp:CustomValidator ID="CVClientes" runat="server" ErrorMessage="Seleccione Un Cliente" ControlToValidate="ClienteDropDownList" ValidationGroup="Guardar" ForeColor="Red" Display="Dynamic" OnServerValidate="CVClientes_ServerValidate"></asp:CustomValidator>
                            </div>
                            <%--Producto--%>
                            <div class="form-group col-md-3">
                                <asp:Label Text="Producto" runat="server" />
                                <asp:DropDownList ID="ProductoDropDownList" CssClass="form-control" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                                   <asp:CustomValidator ID="CVProducto" runat="server" ErrorMessage="Seleccione Un Producto" ControlToValidate="ProductoDropDownList" ValidationGroup="Agregar" ForeColor="Red" Display="Dynamic" OnServerValidate="CVProducto_ServerValidate"></asp:CustomValidator>
                            </div>

                            <%--Precio--%>
                            <div class="form-group col-md-1">
                                <asp:Label Text="Precio" runat="server" />
                                 <asp:TextBox ID="PrecioTextBox" class="form-control input-sm" AutoPostBack="true" AutoCompleteType="Disabled" TextMode="Number" runat="server" placeholder="0"></asp:TextBox>
                            </div>

                            <%--Cantidad--%>
                            <div class="form-group col-md-1">
                                <asp:Label Text="Cantidad" runat="server" />
                                <asp:TextBox ID="CantidadTextBox" class="form-control input-sm" AutoPostBack="true" AutoCompleteType="Disabled" TextMode="Number" runat="server" placeholder="0"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="Agregar" ControlToValidate="CantidadTextBox" ErrorMessage="No Hay Cantidad"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="CVCantidad" ForeColor="Red" Display="Dynamic" runat="server" ValidationGroup="Agregar" ControlToValidate="CantidadTextBox" ErrorMessage="Cantidad Invalida" OnServerValidate="CVCantidad_ServerValidate"></asp:CustomValidator>
                            </div>

                            <%--Importe--%>
                            <div class="form-group col-md-1">
                                <asp:Label Text="Importe" runat="server" />
                                <asp:TextBox ID="ImporteTextBox" class="form-control input-sm" AutoPostBack="true" AutoCompleteType="Disabled" TextMode="Number" runat="server" placeholder="0" OnTextChanged="ImporteTextBox_TextChanged" ></asp:TextBox>
                                <asp:CustomValidator ID="CVImporte" ForeColor="Red" Display="Dynamic" runat="server" ValidationGroup="Agregar" ControlToValidate="ImporteTextBox" ErrorMessage="No Hay Importe Para Agregar" OnServerValidate="CVImporte_ServerValidate" ></asp:CustomValidator>
                            </div>



                            <%-- <!--FacturaId-->
            <div class="form-group row justify-content-center">
                <asp:Label ID="Label1" CssClass="col-lg-2 col-form-label mr-2" runat="server" Text="FacturaId">FacturaId:</asp:Label>
                <div class="col-lg-4">
                    <asp:TextBox ID="FacturaIdTextBox" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                    <asp:LinkButton ID="BuscarLinkButton" CausesValidation="false" CssClass="btn btn-primary" runat="server">
                        <span class="fas fa-search"></span>
                        Buscar
                    </asp:LinkButton>
                </div>
                <div class="form-group row justify-content-center"></div>
                <asp:Label ID="Label2" CssClass="col-lg-2 col-form-label" runat="server" Text="Fecha">Fecha:</asp:Label>
                <div class="col-lg-3 p-0">
                    <asp:TextBox ID="FechaTextBox" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                </div>
            </div>

            <!--clienteId-->
           
            <div class="form-group row justify-content-cente">
                <asp:Label ID="Label3" CssClass="col-lg-2 col-form-label mr-2" runat="server" Text="ClienteId">ClienteId:</asp:Label>
                <div class="col-lg-2"<%-- style="left: 0px; top: 0px"--%>
                            <%-- <asp:DropDownList ID="ClienteDropDownList" CssClass="form-control" runat="server">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>--%>

                            <%--Producto--%>
                            <%--<div class="form-group col-md-3">
                <asp:Label ID="Label5" CssClass="form-control input-sm" Text="Producto" runat="server">Producto:</asp:Label>
                <div class="col-lg-4 ">
                    <asp:DropDownList ID="ProductoDropDownList" CssClass="form-control" runat="server">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ProductoDropDownList" Text="*" runat="server" ErrorMessage="Debe seleccionar un producto"></asp:RequiredFieldValidator>
                             
                </div>
            </div>--%>

                            <%--Precio--%>

                            <%-- <div class="form-group col-md-3">
                <asp:Label Text="Precio" runat="server" />
                <asp:TextBox ID="PrecioTextBox" class="form-control input-sm" AutoPostBack="true" ReadOnly="true" TextMode="Number" runat="server" placeholder="0"></asp:TextBox>
            </div>--%>

                            <%--Cantidad--%>
                            <%--  <div class=" form-group col-md-1 <%--form-inline--%> <%--row justify-content-center--%>
                            <%-- <asp:Label ID="Label6" CssClass="col-form-label" runat="server" Text="Cantidad">Cantidad:</asp:Label>
                <div class="col-lg-2 p-0" style="left: 0px; top: 0px">
                    <asp:TextBox ID="CantidadTextBox" TextMode="Number" CssClass="form-group col-md-1" ReadOnly="false" runat="server"></asp:TextBox>
                </div>
            </div>--%>

                            <%--Importe--%>
                            <%--  <div class="form-group row justify-content-end">
                <asp:Label ID="Label7" CssClass="col-lg-1 col-form-label" runat="server" Text="Importe">Importe:</asp:Label>
                <div class="col-lg-3 mr-5">
                    <asp:TextBox ID="ImporteTextBox" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
            </div>--%>


                            <!--Añadir boton-->
                            <div class="col-lg-1 ">
                                <asp:LinkButton ID="AddLinkButton" CssClass="btn btn-primary mt-4" runat="server" OnClick="AddLinkButton_Click">
                          <span class="fas fa-plus"></span>
                          Add
                                </asp:LinkButton>
                            </div>


                            <!--Grid-->
                            <div class="row justify-content-center">
                                <div class="col-lg-11">
                                    <asp:GridView ID="FacturaGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="FacturaGridView_SelectedIndexChanged">
                                        <%--<asp:GridView ID="FacturaGridView" runat="server" AllowPaging="True" PageSize="7" CssClass="table table-striped table-hover table-responsive-lg" AutoGenerateColumns="False" OnPageIndexChanging="ClientesGridView_PageIndexChanging" OnRowCancelingEdit="FacturaGridView_RowCancelingEdit" OnRowEditing="FacturaGridView_RowEditing" OnRowUpdating="FacturaGridView_RowUpdating">--%>
                                        <Columns>
                                            <asp:CommandField ControlStyle-CssClass="btn btn-secondary" ButtonType="Button" ShowEditButton="True" />
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
                            <div class="form-group col-md-3">
                                <asp:Label ID="Label4" CssClass="col-lg-1 col-form-label" runat="server" Text="Monto">Monto:</asp:Label>
                                <div class="col-lg-6 ">
                                    <asp:TextBox ID="MontoTextBox" CssClass="form-control input-sm" AutoPostBack="true" ReadOnly="true" TextMode="Number" runat="server"></asp:TextBox>
                                </div>
                              </div>
                           

                            <!--Card body end-->
                        </div>

                        <!--Card footer-->
                        <div class="card-footer">

                            <!--Butones-->

                        <div class="row justify-content-center">
                            <div class="form-group">
                                <asp:LinkButton ID="NuevoButton" CssClass="btn btn-primary mt-4" runat="server" >
                            <span class="fas fa-plus"></span>
                            Nuevo
                                </asp:LinkButton>

                                <asp:LinkButton ID="GuardarButton2" CssClass="btn btn-success mt-4" runat="server"  >
                            <span class="fas fa-save"></span>
                            Guardar
                                </asp:LinkButton>

                                <asp:LinkButton ID="EliminarButton3" CssClass="btn btn-danger mt-4" runat="server"  >
                            <span class="fas fa-trash-alt"></span>
                            Eliminar
                                </asp:LinkButton>
                            </div>
                        </div>

                             <asp:LinkButton ID="ImprimirButton" CssClass="btn btn-warning mt-4" runat="server" >
                            <span class="fas fa-print"></span>
                            Imprimir
                                </asp:LinkButton>
                        </div>

                    </div>



                           <%-- <div class="card-footer">--%>
                                <!--Nuevo-->
<%--                                <div class="justify-content-start">
                                    
                                    <asp:LinkButton ID="NuevoLinkButton" CssClass="btn btn-primary" runat="server" CausesValidation="False">
                                   <span class="fas fa-plus"></span>
                                     Nuevo
                                    </asp:LinkButton>
                                </div>--%>

                                <!--Guardar-->
                              <%--  <div class="justify-content-star">
                                    <asp:LinkButton ID="GuardarLinkButton" CssClass="btn btn-success" runat="server">
                                     <span class="fas fa-save"></span>
                                  Guardar
                                    </asp:LinkButton>
                                </div>--%>

                                <!--Eliminar-->
                                <%--<div class="justify-content-star">
                                    <asp:LinkButton ID="EliminarLinkButton" CssClass="btn btn-danger" runat="server" CausesValidation="False">
                                   <span class="fas fa-trash-alt"></span>
                                 Eliminar
                                    </asp:LinkButton>
                                </div>--%>

                                <!--Imprimir-->
                              <%--  <div class="col-lg-1 mr-3">
                                    <asp:LinkButton ID="ImprimirLinkButton" CssClass="btn btn-warning" runat="server" CausesValidation="False">
                                   <span class="fas fa-print"></span>
                                 Imprimir
                                    </asp:LinkButton>
                                </div>


                            </div>--%>

                            <!--Card footer end-->
                        <%--</div>--%>
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
        </div>
          
              <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false" runat="server" />
</asp:Content>
