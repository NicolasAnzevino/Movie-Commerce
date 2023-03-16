<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormABMPelicula.aspx.cs" Inherits="Movie_Commerce.FormABMPelicula" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet"/>
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
<div class="form-control" style="width:427px; margin-left:485px;">
                        <asp:Label class="h3" style="margin-left:55px;font-size:large;align-self:center;" ID="lblTitulo" runat="server">Agregar Película</asp:Label>
                        <p></p>
                    <div style="float:left;" >  
                        <asp:Label ID="lblID" runat="server" Text="ID"></asp:Label>
                        <asp:TextBox ID="TextBoxID" runat="server" CssClass="form-control" style="width:70px;" Enabled="False"></asp:TextBox>
                        <%--                    <p></p>  --%><%--                        <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="TextBoxNombre" runat="server" CssClass="form-control" placeholder="Nombre de Pelicula" style="width:300px;"></asp:TextBox>--%>
                    </div>
                    <div style="float:right;">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="TextBoxNombre" runat="server" CssClass="form-control" placeholder="Nombre de Pelicula" style="width:277px;"></asp:TextBox>
                    </div>
                    <p></p>
                    <br />
                    <br />
                    <br />
                    <p></p>
                    <div></div>
                    <div> 
                        <p></p>
                        <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxDescripcion" runat="server" CssClass="form-control" Height="50px" TextMode="MultiLine" placeholder="Habia una vez.." ></asp:TextBox>
                    </div>
                    <p></p>
                    <div>   
                        <asp:Label ID="lblPrecio" runat="server" Text="Precio"></asp:Label>
                        <asp:TextBox ID="TextBoxPrecio" runat="server" CssClass="form-control" placeholder="$0.00" style="width:130px;" TextMode="Number"></asp:TextBox>
                    </div>
                    <p>
                        <asp:RangeValidator ID="RangeValidatorPrecio" runat="server" ControlToValidate="TextBoxPrecio" ErrorMessage="Debe ingresar un valor entre 0 y 9999" ForeColor="Red" MaximumValue="9999" MinimumValue="0"></asp:RangeValidator>
                        </p>
                    <div>   
                        <asp:ScriptManager runat="server" ID="SM1"/>
                        <asp:Label ID="lblImagen" runat="server" Text="Imagen"></asp:Label>
                        <br />
                        <asp:FileUpload ID="FileUploadImagen" runat="server" ClientIDMode="Static" onchange="this.form.submit()" />
                        <br />
                        <asp:Image ID="Image1" runat="server" style="margin-left:5px;margin-top:10px;" Height="192px" Width="129px" BorderStyle="Solid" BorderWidth="1px"/>
                    </div>
                    <hr />
                    <asp:Label ID="lblTituloGeneros" runat="server" Text="Géneros"></asp:Label>
                    <asp:Label ID="lblTituloGeneros2" runat="server" Text="Todos los Géneros" style="margin-left:190px;"></asp:Label>
                    <div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:ListBox ID="lbGenerosPelicula" runat="server" Height="95px" Width="140px"></asp:ListBox>
                            <asp:ListBox ID="lbGenerosPelicula0" runat="server" Height="95px" Width="140px" style="margin-left:111px;"></asp:ListBox>
                            <ul style="margin-left:-5px;margin-top:8px;margin-right:-45px;">
                            <asp:Button ID="Button2" runat="server" Text="Agregar" style="margin-left:100px;margin-bottom:30px;" OnClick="Button2_Click"/>
                            <asp:Button ID="Button1" runat="server" Text="Quitar" OnClick="Button1_Click"/> 
                        </ul>                
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>
                    <hr />
                    <div class="row">
                        <asp:Button ID="btnRegistrarse" CssClass="btn btn-primary btn-dark" runat="server" Text="Agregar Pelicula" style="width:90%; height: 80%; margin-left:22px;" OnClick="btnAgregarPelicula_Click"/>
                    </div>
                    <br />
                    <div class="row">
                        <asp:Button ID="btnRegresar" CssClass="btn btn-primary btn-dark" runat="server" Text="Regresar" style="width: 90%; height: 80%; margin-left:22px;" OnClick="btnRegresar_Click" />
                    </div>
                </div>
    </form>
</body>
</html>
