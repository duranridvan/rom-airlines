<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPassenger.aspx.cs" Inherits="Rom_Airlines.AddPassenger" %>

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
            width: 127px;
        }
        .style3
        {
            width: 127px;
            height: 43px;
        }
        .style4
        {
            height: 43px;
        }
        .style5
        {
            width: 41px;
        }
        .style6
        {
            height: 43px;
            width: 41px;
        }
        .style7
        {
            width: 137px;
        }
        .style8
        {
            height: 43px;
            width: 137px;
        }
        .style9
        {
            width: 81px;
        }
        .style10
        {
            height: 43px;
            width: 81px;
        }
        .style11
        {
            width: 127px;
            height: 36px;
        }
        .style12
        {
            width: 41px;
            height: 36px;
        }
        .style13
        {
            width: 137px;
            height: 36px;
        }
        .style14
        {
            width: 81px;
            height: 36px;
        }
        .style15
        {
            height: 36px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: right">
                <asp:LinkButton ID="menuButton" runat="server" BorderStyle="Outset" 
                    CausesValidation="False" Font-Bold="True" Font-Overline="False" 
                    Font-Strikeout="False" PostBackUrl="~/default.aspx?logout=1">Logout</asp:LinkButton>
                    </div>
    <div>
    <p>
        <asp:HyperLink ID="LinkSchedule" runat="server" 
            NavigateUrl="/MakeReservation.aspx">Schedule</asp:HyperLink>
    &nbsp;&gt; 
        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/MRAvailibity.aspx" runat="server">Availibility</asp:HyperLink>
         &gt; Add Passenger</p>
        <table class="style1">
            <tr>
                <td class="style2">
                    Make Reservation</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    Passenger 1</td>
                <td class="style6">
                    Name</td>
                <td class="style8">
                    <asp:TextBox ID="NameBox1" runat="server" Height="32px" Width="131px"></asp:TextBox>
                </td>
                <td class="style10">
                    &nbsp;&nbsp;&nbsp;&nbsp; Birthday&nbsp;</td>
                <td class="style4" colspan="2">
                    <asp:TextBox ID="DBox1" runat="server" Height="32px" Width="131px"></asp:TextBox>
                    (YYYY-MM-DD)</td>
            </tr>
            <tr>
                <td class="style3">
                    Passenger 2</td>
                <td class="style6">
                    Name</td>
                <td class="style8">
                    <asp:TextBox ID="NameBox2" runat="server" Height="32px" Width="131px"></asp:TextBox>
                </td>
                <td class="style10">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Birthday</td>
                <td class="style4" colspan="2">
                    <asp:TextBox ID="DBox2" runat="server" Height="32px" Width="131px"></asp:TextBox>
                    (YYYY-MM-DD)</td>
            </tr>
            <tr>
                <td class="style3">
                    Passenger 3</td>
                <td class="style6">
                    Name</td>
                <td class="style8">
                    <asp:TextBox ID="NameBox3" runat="server" Height="32px" Width="131px"></asp:TextBox>
                </td>
                <td class="style10">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Birthday</td>
                <td class="style4" colspan="2">
                    <asp:TextBox ID="DBox3" runat="server" Height="32px" Width="131px"></asp:TextBox>
                    (YYYY-MM-DD)</td>
            </tr>
            <tr>
                <td class="style11">
                </td>
                <td class="style12">
                </td>
                <td class="style13">
                </td>
                <td class="style14">
                </td>
                <td class="style15">
                </td>
                <td class="style15">
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                        Text="Continue" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
