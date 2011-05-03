﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MRAvailibity.aspx.cs" Inherits="Rom_Airlines.MRAvailibity" %>

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
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <h1>
            Make Reservation</h1>
    
    </div>
    <p>
        <asp:HyperLink ID="LinkSchedule" runat="server" NavigateUrl="/">Schedule</asp:HyperLink>
    &nbsp;&gt; Availibility</p>
    <table class="style1">
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Previous Day" />
            </td>
            <td style="text-align: center">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged">
                </asp:GridView>
            </td>
            <td style="text-align: right">
                <asp:Button ID="Button3" runat="server" Text="Next Day" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Previous Day" />
            </td>
            <td style="text-align: center">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateSelectButton="True">
                </asp:GridView>
            </td>
            <td style="text-align: right">
                <asp:Button ID="Button4" runat="server" Text="Next Day" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
