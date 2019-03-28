<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="ProyectoFinalAp2.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Iniciar Session</title>
    <meta name="viewport" content="width=device-width" /> 
    <meta charset="utf-8" />
    
    <link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
    
    <link rel="icon" type="image/png" href="/Content/Login/images/icons/favicon.ico"/>
    <link href="/Content/Login/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/Login/fonts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="/Content/Login/fonts/iconic/css/material-design-iconic-font.min.css" rel="stylesheet" />
    <link href="/Content/Login/vendor/animate/animate.css" rel="stylesheet" />
    <link href="/Content/Login/vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" />
    <link href="/Content/Login/vendor/animsition/css/animsition.min.css" rel="stylesheet" />
    <link href="/Content/Login/vendor/select2/select2.min.css" rel="stylesheet" />
    <link href="/Content/Login/vendor/daterangepicker/daterangepicker.css" rel="stylesheet" />	
    <link href="/Content/Login/css/util.css" rel="stylesheet" />
    <link href="/Content/Login/css/main.css" rel="stylesheet" />

</head>
<body>
	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100 p-t-85 p-b-20">
				<form runat="server" class="login100-form validate-form">
					<span class="login100-form-title p-b-70">
						Bienvenidos
					</span>
					<span class="login100-form-avatar">
					<%--	<img src="/Content/Login/images/Tienda.jpg" alt="AVATAR">--%>
					</span>

					<div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate = "Enter username">
						<%--<input class="input100" type="text" name="username">--%>
                        <asp:TextBox AutoCompleteType="Disabled" CssClass="input100" ID="usuarioTextBox" runat="server" />
						<span class="focus-input100" data-placeholder="Nombre Usuario"></span>
					</div>

					<div class="wrap-input100 validate-input m-b-50" data-validate="Enter password">
						<%--<input class="input100" type="password" name="pass">--%>
                        <asp:TextBox AutoCompleteType="Disabled" CssClass="input100" TextMode="Password" ID="passTextBox" runat="server" />
						<span class="focus-input100" data-placeholder="Contraseña"></span>
					</div>

					<div class="container-login100-form-btn">
                        <asp:LinkButton Text="Login" ID="LoginLinkButton" OnClick="LoginLinkButton_Click" CssClass="login100-form-btn" runat="server" />
					
					</div>

					<%--<ul class="login-more p-t-190">
						<li class="m-b-8">
							<span class="txt1">
								Forgot
							</span>

							<a href="#" class="txt2">
								Username / Password?
							</a>
						</li>

						<li>
							<span class="txt1">
								Don’t have an account?
							</span>

							<a href="#" class="txt2">
								Sign up
							</a>
						</li>
					</ul>--%>
				</form>
			</div>
		</div>
	</div>
	

	<div id="dropDownSelect1"></div>
	
<!--===============================================================================================-->
	<script src="/Content/Login/vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="/Content/Login/vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="/Content/Login/vendor/bootstrap/js/popper.js"></script>
	<script src="/Content/Login/vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="/Content/Login/vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="/Content/Login/vendor/daterangepicker/moment.min.js"></script>
	<script src="/Content/Login/vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="/Content/Login/vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="/Content/Login/js/main.js"></script>
    

</body>
</html>
