﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagePlane.aspx.cs" Inherits="Rom_Airlines.ManagePlanes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <h1>
            Manage Planes</h1>
    
    </div>
    
        <div class="style1">
    
                <asp:LinkButton ID="menuButton" runat="server" BorderStyle="Outset" 
                    CausesValidation="False" Font-Bold="True" Font-Overline="False" 
                    Font-Strikeout="False" PostBackUrl="~/menu.aspx">Menu</asp:LinkButton>
    </div>
    <asp:GridView ID="GridPlanes" runat="server" style="text-align: center" 
                AutoGenerateDeleteButton="True" AutoGenerateEditButton="True"
                OnRowEditing="GridPlanes_RowEditing" OnRowDeleting="GridPlanes_RowDeleting">
    </asp:GridView>
    <br />
    <p style="text-align: center">
        <asp:LinkButton ID="menuButton0" runat="server" BorderStyle="Outset" 
            CausesValidation="False" Font-Bold="True" Font-Overline="False" 
            Font-Strikeout="False" PostBackUrl="~/addeditplane.aspx">Add</asp:LinkButton>
    </p>
    </form>
</body>
</html>
