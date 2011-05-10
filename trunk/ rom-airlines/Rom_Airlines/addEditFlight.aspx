<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addEditFlight.aspx.cs" Inherits="Rom_Airlines.addEditFlight" %>

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
            <td colspan="6" align="right">
                <asp:LinkButton ID="menuButton" runat="server" BorderStyle="Outset" 
                    CausesValidation="False" Font-Bold="True" Font-Overline="False" 
                    Font-Strikeout="False" PostBackUrl="~/manageflight.aspx">Back</asp:LinkButton>
            </td>
        </tr>
            <tr>
                <td colspan="6">
                    Add/Edit Flight</td>
            </tr>
            <tr>
                <td colspan="2">
                    Flight No</td>
                <td colspan="2">
                    <asp:TextBox ID="flightidBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    Date</td>
                <td>
                    <asp:TextBox ID="dateBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Plane:</td>
                <td>
                    <asp:DropDownList ID="planeList" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    Departure</td>
                <td>
                    <asp:DropDownList ID="departureList" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    Landing</td>
                <td>
                    <asp:DropDownList ID="landingList" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    Time</td>
                <td>
                    <asp:TextBox ID="deptTimeBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    Time</td>
                <td>
                    <asp:TextBox ID="landTimeBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td colspan="2">
                    <asp:Button ID="addeditbutton" runat="server" Text="Add" 
                        onclick="addeditbutton_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
