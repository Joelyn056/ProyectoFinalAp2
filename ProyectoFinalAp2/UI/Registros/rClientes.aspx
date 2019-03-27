<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rClientes.aspx.cs" Inherits="ProyectoFinalAp2.UI.Registros.rClientes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">
    <div class="card">
   
      <div class="card-header text-white text-center bg-success">
        <h3>Registro de clientes</h3>
    </div>

    <!--Card body-->
    <div class="card-body">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>

                <!--ClienteId-->
                <div class="form-group row justify-content-center">
                    <asp:Label ID="Label1" CssClass="col-lg-2 col-form-label mr-2" runat="server" Text="ClienteId">ClienteId:</asp:Label>
                    <div class="col-lg-4">
                        <asp:TextBox TextMode="Number" CssClass="form-control" ID="ClienteIdTextBox" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-1">
                        <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-secondary" runat="server" CausesValidation="False" OnClick="BuscarLinkButton_Click">
                <span class="fas fa-search"></span>
                 Buscar
             </asp:LinkButton>
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

                <!--Edad-->
                <div class="form-group row justify-content-center">
                    <asp:Label ID="Label9" CssClass="col-lg-2 col-form-label mr-2" runat="server" Text="Edad">Edad:</asp:Label>
                    <div class="col-lg-4">
                        <asp:TextBox ID="EdadTextBox" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="*" Display="Dynamic" ErrorMessage="Edad: Debe introducir su edad" ControlToValidate="EdadTextBox">*</asp:RequiredFieldValidator>

                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="EdadTextBox" Display="Dynamic" Text="*" MinimumValue="0" MaximumValue="99999"
                            ErrorMessage="La edad ingresada no es valida" Type="Integer"></asp:RangeValidator>
                    </div>
                </div>

                <!--Sexo-->
                <div class="form-group row justify-content-center">
                    <asp:Label ID="Label3" CssClass="col-lg-2 col-form-label mr-2" runat="server" Text="Sexo">Sexo:</asp:Label>
                    <div class="col-lg-4">
                        <asp:DropDownList ID="SexoDropDownList" CssClass="form-control" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Masculino</asp:ListItem>
                            <asp:ListItem>Femenino</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-1">
                        <asp:RequiredFieldValidator ControlToValidate="SexoDropDownList" ID="RequiredFieldValidator4" runat="server" Text="*" Display="Dynamic"
                            ErrorMessage="Sexo: debe indicar su sexo"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <!--Ciudad-->
                <div class="form-group row justify-content-center">
                    <asp:Label ID="Label4" CssClass="col-lg-2 col-form-label mr-2" runat="server" Text="Ciudad">Ciudad:</asp:Label>
                    <div class="col-lg-4">
                        <asp:TextBox ID="CiudadTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*" Display="Dynamic" ErrorMessage="Ciudad: Debe introducir una ciudad"
                            ControlToValidate="CiudadTextBox"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <!--Telefono-->
                <div class="form-group row justify-content-center">
                    <asp:Label ID="Label5" CssClass="col-lg-2 col-form-label mr-2" runat="server" Text="Telefono">Telefono:</asp:Label>
                    <div class="col-lg-4">
                        <asp:TextBox CssClass="form-control" ID="TelefonoTextBox" runat="server"></asp:TextBox>
                        <ajaxtoolkit:maskededitextender id="TelefonoMEE" targetcontrolid="TelefonoTextBox" mask="999-999-9999" runat="server" clearmaskonlostfocus="False" autocomplete="True" />
                    </div>
                    <div class="col-lg-1">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TelefonoTextBox" Text="*"
                            ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" ErrorMessage="Telefono: El numero de telefono no es valido" Display="Dynamic">*</asp:RegularExpressionValidator>
                    </div>
                </div>

                <!--Celular-->
                <div class="form-group row justify-content-center">
                    <asp:Label ID="Label6" CssClass="col-lg-2 col-form-label mr-2" runat="server" Text="Celular">Celular:</asp:Label>
                    <div class="col-lg-4">
                        <asp:TextBox CssClass="form-control" ID="CelularTextBox" runat="server"></asp:TextBox>
                        <ajaxToolkit:maskededitextender id="CelularMEE" targetcontrolid="CelularTextBox" mask="999-999-9999" runat="server" clearmaskonlostfocus="False" autocomplete="True" />
                    </div>
                    <div class="col-lg-1">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="CelularTextBox" Text="*" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"
                            ErrorMessage="Celular: El numero de celular no es valido" Display="Dynamic">*</asp:RegularExpressionValidator>
                    </div>
                </div>

                <!--Email-->
                <div class="form-group row justify-content-center">
                    <asp:Label ID="Label7" CssClass="col-lg-2 col-form-label mr-2" runat="server" Text="Email">Email:</asp:Label>
                    <div class="col-lg-4">
                        <asp:TextBox ID="EmailTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-1">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="EmailTextBox" Text="*" ErrorMessage="Email: El correo que a introducido no es valido"
                            Display="Dynamic"   ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                  </div>
                <!--Fin de los campos-->

                </div>
               </div>
            </ContentTemplate>
     
<%--                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="GuardarLinkButton" />
                    <asp:AsyncPostBackTrigger ControlID="EliminarLinkButton" />
                    <asp:AsyncPostBackTrigger ControlID="NuevoLinkButton" />
                    <asp:AsyncPostBackTrigger ControlID="BuscarLinkButton"/>
                </Triggers>--%>
            </asp:UpdatePanel>

         <!--Card body end-->
        </div>

     <!--Card footer-->
        <div class="card-footer">

             <!--Butones-->
            <div class="form-group row justify-content-center">
                <!--Nuevo-->
                <div class="col-lg-1 mr-1">
                    <asp:LinkButton ID="NuevoLinkButton" CssClass="btn btn-primary" runat="server" OnClick="NuevoLinkButton_Click" CausesValidation="False">
                        <span class="fas fa-plus"></span>
                        Nuevo
                    </asp:LinkButton>
                </div>

                <!--Guardar-->
                <div class="col-lg-1 mr-3">
                    <asp:LinkButton ID="GuardarLinkButton" CssClass="btn btn-success" OnClick="GuardarLinkButton_Click" runat="server">
                        <span class="fas fa-save"></span>
                        Guardar
                    </asp:LinkButton>
                </div>

                <!--Eliminar-->
                <div class="col-lg-1 mr-3">
                    <asp:LinkButton ID="EliminarLinkButton" CssClass="btn btn-danger" OnClick="EliminarLinkButton_Click" runat="server" CausesValidation="False">
                        <span class="fas fa-trash-alt"></span>
                        Eliminar
                    </asp:LinkButton>
                </div>
            </div>

        <!--Card footer end-->
        </div>

    <!--Card end-->
    </div>
    
    <!--Validation summary-->


</asp:Content>
