﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Rom_Airlines.Default" %>

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
    <div>
    
        <table class="style1">
            <tr>
                <td colspan="2">
                    ROM Airlines</td>
            </tr>
            <tr>
                <td>
                    e-mail</td>
                <td>
                    <asp:TextBox ID="emailBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    password</td>
                <td>
                    <asp:TextBox ID="passwordBox" runat="server" 
                        TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="signinButton" runat="server" Text="Sign In" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
