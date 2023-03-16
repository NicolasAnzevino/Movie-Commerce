<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PeliculaControl.ascx.cs" Inherits="Movie_Commerce.PeliculaControl" %>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
<script src="https://code.jquery.com/jquery-3.6.3.min.js"></script>
<asp:Panel ID="panelPelicula" runat="server" Height="345px" Width="283px" BorderStyle="Solid" BorderWidth="1px" style="margin-left:10px;margin-top:10px;">
    &nbsp;
    <br />
    &nbsp;
    <asp:Image ID="imgPelicula" runat="server" Height="204px" Width="260px" BorderStyle="Solid" BorderWidth="1px" />
    <br />
    &nbsp;
    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="X-Large" style="margin-left:5px;"></asp:Label>
    &nbsp;<asp:Label ID="lblID" runat="server" Font-Bold="True" Font-Size="X-Large" style="margin-left:5px;" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="lblComprar" runat="server" BackColor="White" ForeColor="#00CC00" Text="Agregado al Carrito" style="margin-left:5px;margin-bottom:5px;" Visible="False"></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Ver" CssClass="btn form-control-sm btn-info" style="margin-left:5px;margin-bottom:45px;" OnClick="Button1_Click"/>
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Añadir al carrito" CssClass="btn form-control-sm btn-warning" style="margin-left:75px;margin-bottom:45px;" />
</asp:Panel>

