﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeReservation.aspx.cs" Inherits="Rom_Airlines.MakeReservation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style5
        {
        }
        .style9
        {
            width: 121px;
            height: 46px;
        }
        .style10
        {
            width: 224px;
            height: 47px;
        }
        .style11
        {
            width: 268435296px;
        }
        .style13
        {
            width: 268435408px;
            height: 47px;
        }
        .style14
        {
        }
        .style15
        {
            height: 46px;
            width: 158px;
            text-align: center;
        }
        .style17
        {
            height: 54px;
        }
        .style18
        {
            height: 46px;
        }
        .style19
        {
            height: 46px;
            width: 268435296px;
        }
        .style20
        {
            height: 47px;
        }
        .style21
        {
            width: 158px;
            height: 47px;
        }
        .style22
        {
            width: 121px;
        }
        .style23
        {
            height: 54px;
            width: 268435296px;
        }
        .style24
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
        <tr>
            <td colspan="6" class="style24">
                <h1>
                    Make Reservation</h1>
            </td>
        </tr>
            <tr>
                <td colspan="6" class="style24">
                    <p style="text-align: right">
                    <asp:LinkButton ID="LinkButton1" runat="server" BorderStyle="Outset" 
                    CausesValidation="False" Font-Bold="True" Font-Overline="False" 
                    Font-Strikeout="False" PostBackUrl="~/default.aspx?logout=1">Logout</asp:LinkButton>
                <asp:LinkButton ID="menuButton" runat="server" BorderStyle="Outset" 
                    CausesValidation="False" Font-Bold="True" Font-Overline="False" 
                    Font-Strikeout="False" PostBackUrl="~/default.aspx">Back</asp:LinkButton>
                    </p>
                </td>
            </tr>
            <tr>
                <td class="style17" colspan="3">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                        <asp:ListItem Value="1">One Way</asp:ListItem>
                        <asp:ListItem Value="2">Round Trip</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style23" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:DropDownList ID="From" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="style20" colspan="2">
                    <asp:DropDownList ID="To" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="style21">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Departure Date:&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="style13" colspan="2">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style18" colspan="2">
                    Number Of Passengers&nbsp;:</td>
                <td class="style9">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td class="style15">
&nbsp;<asp:Label ID="Label1" runat="server" style="text-align: center" Text="Return Date:"></asp:Label>
                </td>
                <td class="style19" colspan="2">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5" colspan="2">
                    &nbsp;</td>
                <td class="style22">
                    &nbsp;</td>
                <td class="style14" colspan="2">
                    &nbsp;</td>
                <td class="style11">
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Search" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
