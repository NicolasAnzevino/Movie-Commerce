<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActionCard.ascx.cs" Inherits="Movie_Commerce.ActionCard" %>

<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
<script src="https://code.jquery.com/jquery-3.6.3.min.js"></script>

<div style="background-color:#EBEBEB; height: 133px; width: 324px">
    <div style="height: 131px; width: 320px;" >
        <div style="height: 74px; width: 320px">
            <asp:Image ID="Image1" runat="server" style="margin-left:2px; margin-right:2px;" Height="68px" Width="320px" ImageAlign="Baseline" />
        </div>
        <div style="height: 33px; width: 320px">
            <asp:Button ID="Button1" runat="server" class="btn btn-primary" style="margin-left:5px;" Height="54px" Width="310px" />
        </div>
    </div>
</div>

