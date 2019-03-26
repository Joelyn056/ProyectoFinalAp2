<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="ProyectoFinalAp2.UI.Registrarse.rUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta http-equiv="author" content="Jose Manuel"/>
    <meta name="viewport" content="width=device-width, intial-scale=1" />
    <title></title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" integrity="sha384-hWVjflwFxL6sNzntih27bfxkr27PmbbK/iSvJ+a4+0owXq79v+lsFkW54bOGbiDQ" crossorigin="anonymous">
    <link href="../../Content/toastr.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.6.3.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js" integrity="sha384-smHYKdLADwkXOn1EmN1qk/HfnUcbVRZyYmZ4qpPea6sjB/pTJ0euyQp0Mk8ck+5T" crossorigin="anonymous"></script>
    <script src="../../Scripts/toastr.js"></script>
    <script>
        function passLenght(sender, args) {
            if (args.Value.length < 6)
                args.IsValid = false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="card">
                <div class="card-header text-white text-center bg-success">
                    <h3>Crear Cuenta</h3>
                </div>
        
                <!--Card body-->
                <div class="card-body">
                    <!--Usuario-->
                    <div class="form-group row justify-content-center">   
                        <asp:Label ID="Label3" CssClass="col-lg-2 col-form-label" runat="server" Text="Usuario">Usuario:</asp:Label>
                        <div class="col-lg-4">
                            <asp:TextBox TextMode="Number" CssClass="form-control" ID="UsuarioTextBox" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-lg-1">
                            <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-secondary" runat="server" CausesValidation="False">
                                <span class="fas fa-search"></span>
                                Buscar
                            </asp:LinkButton>
                        </div>
                    </div>

                    <!--Nombre-->
                    <div class="form-group row justify-content-center">
                        <asp:Label ID="Label2" CssClass="col-lg-2 col-form-label" runat="server" Text="UserName">Nombre:</asp:Label>
                        <div class="col-lg-4">
                            <asp:TextBox CssClass="form-control" ID="NombreTextBox" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-lg-1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="error" 
                                ControlToValidate="NombreTextBox" 
                                runat="server" 
                                ErrorMessage="Debe ingresar un nombre de usuario" 
                                Display="Dynamic" 
                                Text="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <!--Password-->
                    <div class="form-group row justify-content-center">
                        <asp:Label ID="ContraseñaLabel" CssClass="col-lg-2 col-form-label" runat="server" Text="Contraseña">Contraseña:</asp:Label>
                        <div class="col-lg-4">
                            <asp:TextBox CssClass="form-control" TextMode="Password" ID="ContraseñaTextBox" runat="server"></asp:TextBox>
            
                        </div>
                        <div class="col-lg-1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                               ValidationGroup="Guardar" CssClass="error" 
                                ControlToValidate="ContraseñaTextBox" 
                                Display="Dynamic" 
                                Text="*" 
                                runat="server" 
                                ErrorMessage="Debe ingresar una contraseña"></asp:RequiredFieldValidator>

                            <asp:CustomValidator ID="CustomValidator1" CssClass="error" 
                                ControlToValidate="ContraseñaTextBox" 
                                Text="*" 
                                Display="Dynamic" 
                                runat="server" 
                                ErrorMessage="La contraseña debe contener mas de 6 caracteres" 
                                ClientValidationFunction="passLenght">
                            </asp:CustomValidator>
                        </div>
                    </div>

                    <!--confirmar Contraseña-->
                    <div class="form-group row justify-content-center">
                        <asp:Label ID="ConfirmarLabel1" CssClass="col-lg-2 col-form-label" runat="server" Text="Confirmar">Confirmar:</asp:Label>
                        <div class="col-lg-4">
                            <asp:TextBox CssClass="form-control" AutoCompleteType="Disabled" TextMode="Password" ID="ConfirmarTextBox" runat="server"></asp:TextBox>
            
                        </div>
                        <div class="col-lg-1"> 
                            
                       <asp:CustomValidator ID="CustomValidator2" CssClass="error" 
                                ControlToValidate="ContraseñaTextBox"
                                 ForeColor="Red"
                                Text="*" 
                                Display="Dynamic" 
                                runat="server" 
                                ErrorMessage="La contraseña debe contener mas de 6 caracteres" 
                                ClientValidationFunction="passLenght">
                            </asp:CustomValidator>

                           <%-- <asp:CustomValidator ID="CustomValidator2"  
                                ControlToValidate="ConfirmarTextBox" 
                                Text="*" 
                                Display="Dynamic" 
                                runat="server" 
                                ErrorMessage="La contraseña no coinciden"                                
                                OnServerValidate="CustomValidator1_ServerValidate">
                            </asp:CustomValidator>--%>
                        <%--</div>--%>
                    </div>
                <!--Card body end-->
                </div>
        
                <!--Card footer-->
                <div class="card-footer">
                    <!--Buttons controls-->
                    <div class="form-group row justify-content-center">
                        <div class="col-lg-1 mr-1">
                            <asp:LinkButton ID="NuevoLinkButton" CssClass="btn btn-primary" runat="server" CausesValidation="False" >
                                <span class="fas fa-plus"></span>
                                Nuevo
                            </asp:LinkButton>
                        </div>
                        <div class="col-lg-1 mr-3">
                            <asp:LinkButton ID="GuardarLinkButton" CssClass="btn btn-success" runat="server" >
                                <span class="fas fa-save"></span>
                                Guardar
                            </asp:LinkButton>
                        </div>
                        <div class="col-lg-1 mr-3">
                            <asp:LinkButton ID="EliminarLinkButton" CssClass="btn btn-danger" runat="server" CausesValidation="False">
                                <span class="fa fa-trash-alt"></span>
                                Eliminar
                            </asp:LinkButton>
                        </div>      
                    </div>
                <!--Card footer end-->
                </div>
            </div>
  
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
        </div>
    </form>
</body>
</html>