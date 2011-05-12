<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reservations.aspx.cs" Inherits="Rom_Airlines.reservations" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <h1 class="style1">
        View
        Reservations</h1>
    <form id="form1" runat="server">
    <div style="text-align: right">
    <asp:LinkButton ID="menuButton" runat="server" BorderStyle="Outset" 
                    CausesValidation="False" Font-Bold="True" Font-Overline="False" 
                    Font-Strikeout="False" PostBackUrl="~/menu.aspx" 
            style="text-align: center">Menu</asp:LinkButton>
            </div>
            <div>
    <center>
       <asp:GridView ID="resView" runat="server">
        </asp:GridView>
    </center>
    </div>
    </form>
</body>
</html>
