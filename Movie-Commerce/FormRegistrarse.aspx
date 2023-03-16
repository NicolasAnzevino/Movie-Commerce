<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormRegistrarse.aspx.cs" Inherits="Movie_Commerce.FormRegistrarse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.3.min.js"></script>
    <link href="Recursos/styles.css" rel="stylesheet" />
    <title></title>
</head>
<body class="bg-light">    
    <div class="wrapper">
        <div class="wrapper"> 
            <form id="form1" runat="server">
                <div class="form-control">
                    <div class="col-md-6 text-center mb-5">
                        <asp:Label class="h3" ID="lblRegister" runat="server">  Registrate</asp:Label>
                    </div>
                    <div>   
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
                        <asp:TextBox ID="TextBoxUsuario" runat="server" CssClass="form-control" placeholder="Nombre de Usuario"></asp:TextBox>
                    </div>
                    <br />
                    <div>
                        <asp:Label ID="lblPassword" runat="server" Text="Contraseña:"></asp:Label>
                        <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="TextBoxxCPassword" runat="server" CssClass="form-control" placeholder="Confirma Contraseña" TextMode="Password"></asp:TextBox>
                    </div>
                    <hr />
                    <div>
                        <asp:Label ID="lblPersonales" runat="server" Text="Datos Personales" ForeColor="Black"></asp:Label>
                        <asp:TextBox ID="TextBoxNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="TextBoxApellido" runat="server" CssClass="form-control" placeholder="Apellido"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="TextBoxDNI" runat="server" CssClass="form-control" placeholder="Nº Documento" MaxLength="8"></asp:TextBox>
                    </div>
                    <hr />
                    <div class="row">
                        <asp:Button ID="btnRegistrarse" CssClass="btn btn-primary btn-dark" runat="server" Text="Registrarse" OnClick="btnRegistrarse_Click" />
                    </div>
                    <br />
                    <div class="row">
                        <asp:Button ID="btnRegresar" CssClass="btn btn-primary btn-dark" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
                    </div>
                </div>
            </form>
        </div>
    </div>    
</body>
</html>
