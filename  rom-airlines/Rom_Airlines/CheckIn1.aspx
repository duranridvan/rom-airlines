﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckIn1.aspx.cs" Inherits="Rom_Airlines.CheckIn1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 105px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td colspan="3">
                    Online Check In</td>
            </tr>
            <tr>
                <td class="style2">
                    Reservation ID:</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="351px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Go" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>