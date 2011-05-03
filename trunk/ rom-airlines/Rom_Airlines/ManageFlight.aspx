﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageFlight.aspx.cs" Inherits="Rom_Airlines.ManageFlight" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <h1>
            Manage Flights</h1>
    
    </div>
    <table class="style1">
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Flight No: "></asp:Label>
                <asp:TextBox ID="FlightNo" runat="server"></asp:TextBox>
            </td>
            <td colspan="2">
                <asp:Label ID="Label2" runat="server" Text="Date:"></asp:Label>
                <asp:TextBox ID="Date" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Select Plane:"></asp:Label>
                <asp:DropDownList ID="SelectPlane" runat="server">
                </asp:DropDownList>
            </td>
            <td colspan="2">
                <asp:Label ID="Label4" runat="server" Text="Departure: "></asp:Label>
                <asp:DropDownList ID="SelectDeparture" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Landing: "></asp:Label>
                <asp:DropDownList ID="SelectLanding" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:Button ID="Button1" runat="server" Text="Search" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridFlights" runat="server" AutoGenerateDeleteButton="True" 
                    AutoGenerateEditButton="True" OnRowEditing="GridFlights_RowEditing"
                    OnRowDeleting="GridFlights_RowDeleting">
                </asp:GridView>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
