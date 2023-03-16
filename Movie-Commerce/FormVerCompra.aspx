<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormVerCompra.aspx.cs" Inherits="Movie_Commerce.FormVerCompra" %>

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
              <asp:LinkButton ID="linklblMenuVendedor" runat="server" class="nav-link" CommandName="Menú Vendedor" Visible="False" OnClick="linklblMenuVendedor_Click" >Menú Vendedor</asp:LinkButton>
          </li>
          <li class="nav-item">
              <asp:LinkButton ID="linklblVerMisCompras" runat="server" class="nav-link" OnClick="linklblVerMisCompras_Click" Visible="False" >Ver mis Compras</asp:LinkButton>
          </li>
          <li class="nav-item">
              <asp:LinkButton ID="linklblCarrito" runat="server" class="nav-link active" Visible="False" OnClick="linklblCarrito_Click" >Ver Carrito</asp:LinkButton>
          </li>
        <li class="nav-item">
              <asp:LinkButton ID="linklblRegistrarse" runat="server" class="nav-link" OnClick="linklblRegistrarse_Click" Visible="False" CommandName="Registrarse" >Registrarse</asp:LinkButton>
          </li>
          <li class="nav-item">
              <asp:LinkButton ID="linklblCerrarSesion" runat="server" class="nav-link" OnClick="linklblCerrarSesion_Click" CommandName="Cerrar Sesion" Visible="False" >Cerrar Sesión</asp:LinkButton>
          </li>
      </ul>
    </header>
           <br />
        <asp:Button Text="Regresar" ID="BtnAgregar" CssClass="btn btn-success form-control-sm" style="margin-left: 123px;" runat="server" OnClick="BtnAgregar_Click" Height="39px" Width="108px" />
        <br />
        <div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gvPeliculas" class="table table-borderless table-hover" style="margin-left:95px;" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="91px" Width="888px" DataKeyNames="Codigo de Pelicula">
                    <Columns>
                        <asp:BoundField DataField="Codigo de Pelicula" HeaderText="Codigo de Pelicula" SortExpression="Codigo de Pelicula" ReadOnly="True" />
                        <asp:BoundField DataField="Pelicula" HeaderText="Pelicula" SortExpression="Pelicula" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                        <asp:TemplateField HeaderText="Imagen">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Imagen") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="150px" Width="150px" ImageUrl='<%# "data:Image/jpg;base64," + Convert.ToBase64String((byte [])Eval("Imagen")) %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Movie-CommerceConnectionString %>" SelectCommand="SELECT 'Codigo de Pelicula' = Peli_Codigo, 'Pelicula' = Peli_Nombre, 'Precio' = Peli_Precio, 'Imagen' = Peli_Imagen FROM Pelicula JOIN Venta_Detalle on (VentaD_Peli_Codigo = Peli_Codigo and VentaD_User_Codigo = @UID AND VentaD_Venta_Codigo = @VID)">                    <SelectParameters>
                        <asp:SessionParameter Name="UID" SessionField="UID" DefaultValue="1" />
                        <asp:SessionParameter DefaultValue="" Name="VID" SessionField="VID" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
        <br />
    </form>
</body>
</html>