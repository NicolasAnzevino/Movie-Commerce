<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormError.aspx.cs" Inherits="Movie_Commerce.FormError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <asp:Image ID="img_error" runat="server" Height="30px" ImageUrl="https://www.freeiconspng.com/thumbs/error-icon/error-icon-4.png" Width="31px" />
            <asp:Label ID="lbl_Error_titulo" runat="server" Font-Bold="True" Text="Se ha producido un error"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lbl_Error_desc" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btn_volver" runat="server" Height="32px" OnClick="btn_salir_Click" style="margin-left: 0px; margin-right: 24px" Text="Regresar" Width="80px" />
        </div>
    </form>
</body>
</html>
