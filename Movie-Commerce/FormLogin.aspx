<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormLogin.aspx.cs" Inherits="Movie_Commerce.FormLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.3.min.js"></script>
    <link href="Recursos/styles.css" rel="stylesheet" />
    <title>Iniciar Sesión</title>
</head>
<body class="bg-light">    
    <div class="wrapper">
        <div class="wrapper"> 
            <form id="form1" runat="server">
                <div class="imagen">
                </div>
                <div class="form-control">
                    <div class="col-md-6 text-center mb-5">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Recursos/laugau.png" Height="206px" Width="218px" BorderStyle="None" />
                    </div>
                    <div>
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
                        <asp:TextBox ID="TextBoxUsuario" runat="server" CssClass="form-control" placeholder="Nombre de Usuario"></asp:TextBox>
                    </div>
                    <br />
                    <div>
                        <asp:Label ID="lblPassword" runat="server" Text="Contraseña:"></asp:Label>
                        <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                    </div>
                    <hr />
                    <div class="row">
                        <asp:Button ID="btnIngresar" CssClass="btn btn-primary btn-dark" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" style="width: 80%; height: 80%; margin-left:22px;" />
                    </div>
                    <asp:Label ID="lblIncorrecto" runat="server" Text="Usuario y/o contraseña incorrectos" ForeColor="Red"></asp:Label>
                    <br />
                    <div>
                        <asp:Label ID="lblRegistrarse" runat="server" Text="¿No tienes cuenta?"></asp:Label>
                        <asp:LinkButton ID="linkbtnRegistrarse" runat="server" OnClick="linkbtnRegistrarse_Click">¡Registrate!</asp:LinkButton>
                    </div>
                    <div class="row">
                        <asp:LinkButton ID="linkbtnGuest" runat="server" OnClick="linkbtnGuest_Click">Ingresar como Invitado</asp:LinkButton>
                    </div>
                    <hr />
                </div>
            </form>
        </div>
    </div>    
</body>
</html>
