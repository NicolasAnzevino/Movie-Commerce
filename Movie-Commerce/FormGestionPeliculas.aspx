<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormGestionPeliculas.aspx.cs" Inherits="Movie_Commerce.FormGestionPeliculas" %>

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
        <div class="mx-auto align-content-center" style="width:400px;">
            <h2 style="margin-left:45px;">    Listado de Películas</h2>
        </div>
        <br />
           <asp:Button Text="Agregar" ID="BtnAgregar" CssClass="btn btn-success form-control-sm" style="margin-left: 123px;" runat="server" OnClick="BtnAgregar_Click" />
        <div class="container">
            <div class="row">
                <%--                <div class="align-self-baseline" style="align-items:flex-start; margin-right:100px; margin-left:1px;">
                    <asp:Button Text="Agregar" ID="BtnAgregar" CssClass="btn btn-success form-control-sm" runat="server" OnClick="BtnAgregar_Click" />
                </div>--%>
            </div>
        </div>
        <br />
        <div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gvPeliculas" class="table table-borderless table-hover" style="margin-left:95px;" AutoGenerateColumns="False" DataKeyNames="Codigo" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:Button Text="Ver" CssClass="btn form-control-sm btn-info" runat="server" ID="BtnVer" OnClick="BtnVer_Click" />
                                <asp:Button Text="Modificar" CssClass="btn form-control-sm btn-warning" runat="server" ID="BtnModificar" OnClick="BtnModificar_Click" />
                                <asp:Button Text="Eliminar" CssClass="btn form-control-sm btn-danger" runat="server" ID="BtnEliminar" OnClick="BtnEliminar_Click" />                           
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Codigo" HeaderText="Codigo" ReadOnly="True" SortExpression="Codigo" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Movie-CommerceConnectionString %>" SelectCommand="SELECT 'Codigo'=[Peli_Codigo], 'Nombre'=[Peli_Nombre], 'Precio'= [Peli_Precio],'Imagen' =[Peli_Imagen] FROM [Pelicula]"></asp:SqlDataSource>
            </div>
        </div>

    </form>
</body>
</html>
