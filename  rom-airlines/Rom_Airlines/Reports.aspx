<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="Rom_Airlines.Reports" %>

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
            width: 302px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <h1>
            Reports</h1>
    
    </div>
    <table class="style1" border="1">
        <tr>
            <td class="style2">
                Number of flights that each pilot attended:</td>
            <td>
                <asp:GridView ID="Report1" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style2">
                # of passengers that flied between any two city, between dates<br />
&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;and
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <br />
                <center> <asp:Button ID="Button1" runat="server" Text="Show" 
                        onclick="Button1_Click" /> </center>
            </td>
            <td>
                <asp:GridView ID="Report2" runat="server">
                </asp:GridView>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
