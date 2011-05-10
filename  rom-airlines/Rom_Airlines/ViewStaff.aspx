﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewStaff.aspx.cs" Inherits="Rom_Airlines.ViewStaff" %>

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
            View Staff</h1>
    
    </div>
            <div class="style1">
    
                <asp:LinkButton ID="menuButton" runat="server" BorderStyle="Outset" 
                    CausesValidation="False" Font-Bold="True" Font-Overline="False" 
                    Font-Strikeout="False" PostBackUrl="~/menu.aspx">Menu</asp:LinkButton>
    </div>
    
    <div style="text-align: center">
    
    
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Search" />
        </p>
    
    </div>
    <div style="text-align: center">
    
        <p>
            <asp:GridView ID="StaffView" runat="server" 
                onselectedindexchanged="GridView1_SelectedIndexChanged" 
                AutoGenerateDeleteButton="True" AutoGenerateEditButton="True"
                OnRowEditing="StaffView_RowEditing" OnRowDeleting="StaffView_RowDeleting">
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                onselecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
        </p>
    
    </div>
    <div style="text-align: center">
    
        <p>
    
                <asp:LinkButton ID="menuButton0" runat="server" BorderStyle="Outset" 
                    CausesValidation="False" Font-Bold="True" Font-Overline="False" 
                    Font-Strikeout="False" PostBackUrl="~/addeditstaff.aspx">Add</asp:LinkButton>
        </p>
    
    </div>
    </form>
</body>
</html>
