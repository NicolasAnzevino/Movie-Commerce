<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormABMVendedor.aspx.cs" Inherits="Movie_Commerce.FormABMVendedor" %>

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
<body>
    <form id="form1" runat="server">
    <header class="d-flex flex-wrap justify-content-center py-3 mb-4 border-bottom">
        <a class="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-dark text-decoration-none"><span class="fs-4" style="margin-left:22px;" onclick="None">🍿Movie-Commerce</span>      </a>

      <ul class="nav nav-pills">
          <li class="nav-item">
              <asp:LinkButton ID="linklblInicio" runat="server" class="nav-link" Visible="False" CommandName="Inicio" OnClick="linklblInicio_Click" >Inicio</asp:LinkButton>
          </li>
         <li class="nav-item">
              <asp:LinkButton ID="linklblVerProductos" runat="server" class="nav-link" Visible="False" CommandName="Ver Productos" OnClick="linklblVerProductos_Click" >Ver Productos</asp:LinkButton>
          </li>
          <li class="nav-item">
              <asp:LinkButton ID="linklblMenuAdministrador" runat="server" class="nav-link active" Visible="False" CommandName="Menú Administrador" CommandArgument="Agregar Vendedor" OnClick="linklblMenuAdministrador_Click" >Menú Administrador</asp:LinkButton>
          </li>
          <li class="nav-item">
              <asp:LinkButton ID="linklblMenuVendedor" runat="server" class="nav-link active" CommandName="Menú Vendedor" Visible="False" OnClick="linklblMenuVendedor_Click" >Menú Vendedor</asp:LinkButton>
          </li>
          <li class="nav-item">
              <asp:LinkButton ID="linklblVerMisCompras" runat="server" class="nav-link" OnClick="linklblVerMisCompras_Click" Visible="False" >Ver mis Compras</asp:LinkButton>
          </li>
          <li class="nav-item">
              <asp:LinkButton ID="linklblCarrito" runat="server" class="nav-link" Visible="False" OnClick="linklblCarrito_Click" >Ver Carrito</asp:LinkButton>
          </li>
        <li class="nav-item">
              <asp:LinkButton ID="linklblRegistrarse" runat="server" class="nav-link" OnClick="linklblRegistrarse_Click" Visible="False" CommandName="Registrarse" >Registrarse</asp:LinkButton>
          </li>
          <li class="nav-item">
              <asp:LinkButton ID="linklblCerrarSesion" runat="server" class="nav-link" OnClick="linklblCerrarSesion_Click" CommandName="Cerrar Sesion" Visible="False" >Cerrar Sesión</asp:LinkButton>
          </li>
      </ul>
    </header>
        <div class="form-control" style="width:265px; margin-left:568px;">
<%--                    <div class="col-md-6 text-center mb-5">--%>
                        <asp:Label class="h3" style="margin-left:34px;font-size:large;" ID="lblTitulo" runat="server">Agregar</asp:Label>
                        <p></p>
   <%--                 </div>--%>
                    <div>   
                        <asp:Label ID="lblID" runat="server" Text="ID"></asp:Label>
                        <asp:TextBox ID="TextBoxID" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <p></p>
                    <div>   
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                        <asp:TextBox ID="TextBoxUsuario" runat="server" CssClass="form-control" placeholder="Nombre de Usuario"></asp:TextBox>
                    </div>
                    <p></p>
                    <div>
                        <asp:Label ID="lblPassword" runat="server" Text="Contraseña:"></asp:Label>
                        <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="TextBoxxCPassword" runat="server" CssClass="form-control" placeholder="Confirma Contraseña" TextMode="Password"></asp:TextBox>
                    </div>
                    <hr />
                    <div>
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre" ForeColor="Black"></asp:Label>
                        <asp:TextBox ID="TextBoxNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblApellido" runat="server" Text="Apellido" ForeColor="Black"></asp:Label>
                        <asp:TextBox ID="TextBoxApellido" runat="server" CssClass="form-control" placeholder="Apellido"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblDNI" runat="server" Text="Documento" ForeColor="Black"></asp:Label>
                        <asp:TextBox ID="TextBoxDNI" runat="server" CssClass="form-control" placeholder="Nº Documento" MaxLength="8"></asp:TextBox>
                    </div>
                    <hr />
                    <div class="row">
                        <asp:Button ID="btnRegistrarse" CssClass="btn btn-primary btn-dark" runat="server" Text="Agregar" style="width: 80%; height: 80%; margin-left:22px;" OnClick="btnRegistrarse_Click"/>
                    </div>
                    <br />
                    <div class="row">
                        <asp:Button ID="btnRegresar" CssClass="btn btn-primary btn-dark" runat="server" Text="Regresar" style="width: 80%; height: 80%; margin-left:22px;" OnClick="btnRegresar_Click" />
                    </div>
                </div>
    </form>
</body>
</html>