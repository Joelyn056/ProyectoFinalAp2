<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="ProyectoFinalAp2.UI.Registros.rUsuarios" %>

<asp:content id="Content1" contentplaceholderid="head" runat="server">
</asp:content>

<asp:content id="Content2" contentplaceholderid="MainContentCP" runat="server">
    <div class="card">

        <div class="card-header text-white text-center bg-success">
        <h3>Registro de Usuarios</h3>
    </div>

    <!--Card body-->
    <div class="card-body">
        
                 <!--UsuarioId-->
                <div class="form-group row justify-content-center">
                    <asp:Label ID="Label1" CssClass="col-lg-2 col-form-label mr-2" runat="server" Text="UsuarioId">UsuarioId:</asp:Label>
                    <div class="col-lg-4">
                        <asp:TextBox TextMode="Number" CssClass="form-control" ID="UsuarioIdTextBox" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-1">
                        <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-secondary" runat="server" CausesValidation="False" OnClick="BuscarLinkButton_Click1">
                <span class="fas fa-search"></span>
                 Buscar
             </asp:LinkButton>
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

                <!--Nombre-->
                <div class="form-group row justify-content-center">
                    <asp:Label ID="Label2" CssClass="col-lg-2 col-form-label mr-2" runat="server" Text="Nombres">Nombres:</asp:Label>
                    <div class="col-lg-4">
                        <asp:TextBox ID="NombreTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" Display="Dynamic"
                            ErrorMessage="Nombre: Debe ingresar su nombre" ControlToValidate="NombreTextBox">*</asp:RequiredFieldValidator>
                    </div>
                </div>

                <!--Contraseña-->
                <div class="form-group row justify-content-center">
                    <asp:Label ID="Label4" CssClass="col-lg-2 col-form-label mr-2" runat="server"  Text="Contraseña">Contraseña:</asp:Label>
                    <div class="col-lg-4">
                        <asp:TextBox ID="ContraseñaTextBox" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                            ErrorMessage="*" ValidationGroup="Guardar" ControlToValidate="ContraseñaTextBox"></asp:RequiredFieldValidator>
                    </div>
                </div>



                  <!--Confirmar Contraseña-->
                <div class="form-group row justify-content-center">
                    <asp:Label ID="Label5" CssClass="col-lg-2 col-form-label mr-2" runat="server"  Text="Confirmar">Confirmar :</asp:Label>
                    <div class="col-lg-4">
                        <asp:TextBox ID="ConfirmarTextBox" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  Display="Dynamic"
                           ErrorMessage="*" ControlToValidate="ConfirmarTextBox"></asp:RequiredFieldValidator>

                        <asp:CustomValidator ID="CustomValidator" runat="server" ControlToValidate="ConfirmarTextBox" ValidationGroup="Guardar" ForeColor="Red" Display="Dynamic" ErrorMessage="La Contraseña No Coinciden" OnServerValidate="CustomValidator_ServerValidate"></asp:CustomValidator>
                    </div>
                </div>

           <!--Tipo Usuario-->
                <div class="form-group row justify-content-center">
                    <asp:Label ID="Label6" CssClass="col-lg-2 col-form-label mr-2" runat="server" Text="Tipo Usuario">Tipo Usuario:</asp:Label>
                    <div class="col-lg-4">
                        <asp:DropDownList ID="TipoUsuarioDropDownList" CssClass="form-control" runat="server">
                            <asp:ListItem></asp:ListItem>                        
                        </asp:DropDownList>
                         <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TipoUsuarioDropDownList"
                             ValidationGroup="Guardar" ForeColor="Red" Display="Dynamic" ErrorMessage="Seleccione  " OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                    </div>
                    
                </div>
   
         <!--Card body end-->
        </div>

        <!--Card footer-->
        <div class="card-footer">

            <!--Butones-->
            <div class="form-group row justify-content-center">
                <!--Nuevo-->
                <div class="col-lg-1 mr-1">
                    <asp:LinkButton ID="NuevoLinkButton" CssClass="btn btn-primary" runat="server" CausesValidation="False" OnClick="NuevoLinkButton_Click">
                        <span class="fas fa-plus"></span>
                        Nuevo
                    </asp:LinkButton>
                </div>

                <!--Guardar-->
                <div class="col-lg-1 mr-3">
                    <asp:LinkButton ID="GuardarLinkButton" CssClass="btn btn-success" runat="server" OnClick="GuardarLinkButton_Click">
                        <span class="fas fa-save"></span>
                        Guardar
                    </asp:LinkButton>
                </div>

                <!--Eliminar-->
                <div class="col-lg-1 mr-3">
                    <asp:LinkButton ID="EliminarLinkButton" CssClass="btn btn-danger" runat="server" CausesValidation="False" OnClick="EliminarLinkButton_Click">
                        <span class="fas fa-trash-alt"></span>
                        Eliminar
                    </asp:LinkButton>
                </div>
            </div>

            <!--Card footer end-->
        </div>

        <!--Card end-->
    </div>



</asp:content>
