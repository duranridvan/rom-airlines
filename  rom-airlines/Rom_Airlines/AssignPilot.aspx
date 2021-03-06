﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignPilot.aspx.cs" Inherits="Rom_Airlines.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">

        .style1
        {
            width: 100%;
        }
        .style4
        {
            height: 24px;
            width: 170px;
        }
        .style2
        {
            height: 24px;
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
                <td class="style3" colspan="2">
                   <b>Assign Pilot</b></td>
            </tr>
            <tr>
                <td class="style4">
                    Select Pilot</td>
                <td class="style2">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Date:</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click1" 
                        style="height: 26px" Text="Ok" ValidationGroup="apilot" />
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="RequiredFieldValidator" 
                        ValidationGroup="apilot">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                        runat="server" ControlToValidate="TextBox1" Display="Dynamic" 
                        ErrorMessage="YYYY-MM-DD" 
                        ValidationExpression="^(19|20)\d\d-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])" 
                        ValidationGroup="apilot">YYYY-MM-DD</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Select Flight No</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Assign" 
                        ValidationGroup="apilot" />
                </td>
            </tr>
        </table>
    
    <div>
    
    </div>
    </form>
</body>
</html>
