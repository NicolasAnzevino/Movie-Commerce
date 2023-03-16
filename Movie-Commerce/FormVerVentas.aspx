<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormVerVentas.aspx.cs" Inherits="Movie_Commerce.FormVerVentas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet"/>
        <script src="https://code.jquery.com/jquery-3.6.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <header class="d-flex flex-wrap justify-content-center py-3 mb-4 border-bottom">
      <a class="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-dark text-decoration-none">
        <%--<svg class="bi me-2" width="40" height="32"><use xlink:href="#bootstrap"></use></svg>--%>
        <span class="fs-4" style="margin-left:22px;" onclick="None">  🍿Movie-Commerce</span>      </a>

      <ul class="nav nav-pills">
          <li class="nav-item">
              <asp:LinkButton ID="linklblInicio" runat="server" class="nav-link" Visible="False" CommandName="Inicio" OnClick="linklblInicio_Click" >Inicio</asp:LinkButton>
          </li>
         <li class="nav-item">
              <asp:LinkButton ID="linklblVerProductos" runat="server" class="nav-link" Visible="False" CommandName="Ver Productos" OnClick="linklblVerProductos_Click" >Ver Productos</asp:LinkButton>
          </li>
          <li class="nav-item">
              <asp:LinkButton ID="linklblMenuAdministrador" runat="server" class="nav-link" Visible="False" CommandName="Menú Administrador" CommandArgument="Agregar Vendedor" OnClick="linklblMenuAdministrador_Click" >Menú Administrador</asp:LinkButton>
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
<div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gvPeliculas" class="table table-borderless table-hover" style="margin-left:95px;" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="16px" Width="888px" DataKeyNames="Codigo">
                    <Columns>
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:Button Text="Ver" CssClass="btn form-control-sm btn-info" runat="server" ID="BtnVer" OnClick="BtnVer_Click" />                      
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" InsertVisible="False" ReadOnly="True" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                        <asp:BoundField DataField="Cantidad de Peliculas" HeaderText="Cantidad de Peliculas" SortExpression="Cantidad de Peliculas" ReadOnly="True" />
                        <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Movie-CommerceConnectionString %>" SelectCommand="SELECT 'Codigo' = Venta_Codigo, 'Fecha' = Venta_Fecha, 'Cantidad de Peliculas' = count(ventad_codigo), 'Total' = Venta_Total, 'Usuario' = User_Nombre From Venta JOIN Venta_Detalle on (VentaD_Venta_Codigo = Venta_codigo) JOIN Usuario on (user_codigo = venta_user_codigo) GROUP BY Venta_codigo, Venta_Fecha, Venta_Total, User_Nombre">
                </asp:SqlDataSource>
            </div>
        </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
