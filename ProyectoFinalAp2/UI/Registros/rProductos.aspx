<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rProductos.aspx.cs" Inherits="ProyectoFinalAp2.UI.Registros.rProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">
    <div class="card">

        <div class="card-header text-white text-center bg-success">
            <h3>Registro de Productos</h3>
        </div>

        <!--Card body-->
        <div class="card-body">

            <!--ProductoId-->
            <div class="form-group row justify-content-center">
                <asp:Label ID="Label1" CssClass="col-lg-2 col-form-label mr-2" runat="server" Text="ProductoId">ProductoId:</asp:Label>
                <div class="col-lg-4">
                    <asp:TextBox TextMode="Number" CssClass="form-control" ID="ProductoIdTextBox" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                    <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-secondary" runat="server" CausesValidation="False"> 
                        <span class="fas fa-search"></span> Buscar </asp:LinkButton>
                </div>
            </div>

            <!--Fecha-->
            <div class="form-group row justify-content-center">
                <asp:Label ID="Label3" CssClass="col-lg-2 col-form-label" Text="Fecha" runat="server">Fecha:</asp:Label>
                <div class="col-lg-4">
                    <asp:TextBox ID="FechaTextBox" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                </div>
            </div>


            <!--Descripcion-->
            <div class="form-group row justify-content-center">
                <asp:Label ID="Label2" CssClass="col-lg-2 col-form-label mr-2" runat="server" Text="Descripcion">Descripción:</asp:Label>
                <div class="col-lg-4">
                    <asp:TextBox ID="DescripcionTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" Display="Dynamic" ErrorMessage="Descripcion: Debe introducir una Descripcion"
                        ControlToValidate="DescripcionTextBox"></asp:RequiredFieldValidator>
                </div>
            </div>

            <!--Costo-->
            <div class="form-group row justify-content-center">
                <asp:Label ID="Label4" CssClass="col-lg-2 col-form-label" runat="server">Costo:</asp:Label>
                <div class="col-lg-4">
                    <asp:TextBox ID="CostoTextBox" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*" Display="Dynamic" ErrorMessage="Nombre: Debe ingresar un costo" ControlToValidate="CostoTextBox">*</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CostoCustomValidator1" runat="server" ControlToValidate="CostoTextBox" ValidationGroup="Guardar" Display="Dynamic" ErrorMessage="El Costo No Puede Ser Mayor Que El Precio" OnServerValidate="CostoCustomValidator_ServerValidate"></asp:CustomValidator>
                </div>
            </div>
         
            <!--Precio-->
            <div class="form-group row justify-content-center">
                <asp:Label ID="Label5" CssClass="col-lg-2 col-form-label" runat="server">Precio:</asp:Label>
                <div class="col-lg-4">
                    <asp:TextBox ID="PrecioTextBox" CssClass="form-control" runat="server" OnTextChanged="PrecioTextBox_TextChanged"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" TextMode="Number" runat="server" Text="*" ValidationGroup="Guardar" Display="Dynamic" ErrorMessage="Nombre: Debe ingresar un Precio" ControlToValidate="PrecioTextBox">*</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="PrecioCustomValidator" runat="server" ControlToValidate="PrecioTextBox" ValidationGroup="Guardar"  Display="Dynamic" ErrorMessage="El Precio No Puede Ser Menor Que El Costo" OnServerValidate="PrecioCustomValidator_ServerValidate"></asp:CustomValidator>
                </div>
            </div>

            <!--Ganancia-->

            <div class="form-group row justify-content-center">
                <asp:Label ID="Label7" CssClass="col-lg-2 col-form-label" TextMode="Number" runat="server">Ganancia:</asp:Label>
                <div class="col-lg-2">
                    <asp:TextBox ID="GananciaTextBox" CssClass="form-control" ReadOnly="true" runat="server" OnTextChanged="GananciaTextBox_TextChanged"></asp:TextBox>
                </div>

            </div>

            <!--Inventario-->

<%--            <div class="form-group row justify-content-center">
                <asp:Label ID="Label6" CssClass="col-lg-2 col-form-label" TextMode="Number" runat="server">Inventario:</asp:Label>
                <div class="col-lg-2">
                    <asp:TextBox ID="InventarioTextBox" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
            </div>--%>

            <!--Card body end-->
        </div>

        <!--Card footer-->
        <div class="card-footer">

            <!--Butones-->
            <div class="form-group row justify-content-center">
                <!--Nuevo-->
                <div class="col-lg-1 mr-1">
                    <asp:LinkButton ID="NuevoLinkButton" CssClass="btn btn-primary" runat="server" CausesValidation="False"> 
                        <span class="fas fa-plus">
                        </span> Nuevo </asp:LinkButton>
                </div>

                <!--Guardar-->
                <div class="col-lg-1 mr-3">
                    <asp:LinkButton ID="GuardarLinkButton" CssClass="btn btn-success" runat="server"> 
                        <span class="fas fa-save">
                       </span> Guardar </asp:LinkButton>
                </div>

                <!--Eliminar-->
                <div class="col-lg-1 mr-3">
                    <asp:LinkButton ID="EliminarLinkButton" CssClass="btn btn-danger" runat="server" CausesValidation="False"> 
                        <span class="fas fa-trash-alt">
                        </span> Eliminar </asp:LinkButton>
                </div>
            </div>

            <!--Card footer end-->
        </div>

        <!--Card end-->
    </div>

</asp:Content>
