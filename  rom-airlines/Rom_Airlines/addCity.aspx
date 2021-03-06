﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addCity.aspx.cs" Inherits="Rom_Airlines.addCity" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="style1">
        <tr>
            <td colspan="2" align="right">
                <asp:LinkButton ID="menuButton" runat="server" BorderStyle="Outset" 
                    CausesValidation="False" Font-Bold="True" Font-Overline="False" 
                    Font-Strikeout="False" PostBackUrl="~/menu.aspx">Menu</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Add City</td>
        </tr>
        <tr>
            <td>
                City Name</td>
            <td>
                <asp:TextBox ID="nameBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="nameBox" ErrorMessage="City name must be entered" 
                    ValidationGroup="city">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="addButton" runat="server" onclick="addButton_Click1" 
                    Text="Add" ValidationGroup="city" />
            </td>
        </tr>
    </table>
    <div>
    
    </div>
    </form>
</body>
</html>
