﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seeAssignment.aspx.cs" Inherits="Rom_Airlines.seeAssignment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <h1>
            <asp:Label ID="HeaderLabel" runat="server" Text="See Assignment"></asp:Label>
        </h1>
    
    </div>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    </form>
</body>
</html>
