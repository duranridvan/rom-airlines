﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewStaff.aspx.cs" Inherits="Rom_Airlines.ViewStaff" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <h1>
            View Staff</h1>
    
    </div>
    <div style="text-align: center">
    
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Search" />
        </p>
    
    </div>
    <div style="text-align: center">
    
        <p>
            <asp:GridView ID="StaffView" runat="server" DataSourceID="SqlDataSource1" 
                onselectedindexchanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                onselecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
        </p>
    
    </div>
    </form>
</body>
</html>
