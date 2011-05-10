<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignPilot.aspx.cs" Inherits="Rom_Airlines.WebForm1" %>

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
                        style="height: 26px" Text="Ok" />
&nbsp;(YYYY-MM-DD)</td>
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
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Assign" />
                </td>
            </tr>
        </table>
    
    <div>
    
    </div>
    </form>
</body>
</html>
