<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Rom_Airlines.Payment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <h1>
            Make Reservation</h1>
    
    </div>
    <div style="text-align: right">
                <asp:LinkButton ID="menuButton" runat="server" BorderStyle="Outset" 
                    CausesValidation="False" Font-Bold="True" Font-Overline="False" 
                    Font-Strikeout="False" PostBackUrl="~/default.aspx?logout=1">Logout</asp:LinkButton>
                    </div>
    <asp:LinkButton ID="LinkButton1" runat="server">Schedule</asp:LinkButton>
&nbsp;&gt;
    <asp:LinkButton ID="LinkButton2" runat="server">Availibility</asp:LinkButton>
&nbsp;&gt;
    <asp:LinkButton ID="LinkButton3" runat="server">Passengers</asp:LinkButton>
&nbsp;&gt; Payment<asp:GridView ID="FlightGrid" runat="server">
    </asp:GridView>
    <br />
    <asp:GridView ID="PassengerGrid" runat="server">
    </asp:GridView>
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text=" Pay Now" />
    <br />
    </form>
</body>
</html>
