<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignCheckInOfficer.aspx.cs" Inherits="Rom_Airlines.AssignCheckInOfficer" %>

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
            height: 51px;
            width: 170px;
        }
        .style2
        {
            height: 51px;
        }
        </style>
</head>
<body>
    <form id="form2" runat="server">
    
        <table class="style1">
        <tr>
            <td colspan="2" align="right">
                <asp:LinkButton ID="menuButton" runat="server" BorderStyle="Outset" 
                    CausesValidation="False" Font-Bold="True" Font-Overline="False" 
                    Font-Strikeout="False" PostBackUrl="~/menu.aspx">Menu</asp:LinkButton>
            </td>
        </tr>
            <tr>
                <td class="style3" colspan="2">
                    Assign Check-In Officer</td>
            </tr>
            <tr>
                <td class="style4">
                    Select&nbsp; Check-In Officer</td>
                <td class="style2">
                    <asp:DropDownList ID="OfficerList" runat="server" Height="16px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Select Airport</td>
                <td class="style2">
                    <asp:DropDownList ID="AirportList" runat="server">
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
    
    </form>
</body>
</html>
