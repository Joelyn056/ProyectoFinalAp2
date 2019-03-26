<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoFinalAp2.UI.Login.Login" %>

<!DOCTYPE html>

<link href="../../Content/Login%20Style/style.css" rel="stylesheet" />

<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
<!------ Include the above in your HEAD tag ---------->

<div class="wrapper fadeInDown">
  <div id="formContent">
      
    <!-- Tabs Titles -->
       
    <!-- Icon -->
    <div class="fadeIn first">
       <%--<img src="" id="icon" alt="User Icon" />--%>
      <h1>Evolution Fitness</h1>
    </div>

    <!-- Login Form -->
    
    <form>
      <input type="text" id="login" class="fadeIn second" name="login" placeholder="username">
      <input type="text" id="password" class="fadeIn third" name="login" placeholder="password">
      <input type="submit" class="fadeIn fourth" value="Log In">
        <div id="formFooter">
            <a class="underlineHover"  runat="server" href="~/UI/Registrarse/rUsuarios.aspx">Create Acount</a>
        </div>                  
    </form>
  </div>
    
</div>

