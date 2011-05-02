﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addeditstaff.aspx.cs" Inherits="Rom_Airlines.addeditstaff" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            float: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table align="center" class="style1">
            <tr>
                <td colspan="4">
                    <asp:Label ID="headerLabel" runat="server" Text="Add Staff"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Name</td>
                <td>
                    <asp:TextBox ID="nameBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    TC Id No</td>
                <td>
                    <asp:TextBox ID="tcidBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Email</td>
                <td>
                    <asp:TextBox ID="emailBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    Confirm Email</td>
                <td>
                    <asp:TextBox ID="emailCBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Password</td>
                <td>
                    <asp:TextBox ID="passwordBox" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    Confirm Password</td>
                <td>
                    <asp:TextBox ID="passwordCBox" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Phone</td>
                <td>
                    <asp:TextBox ID="phoneBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    Staff Type</td>
                <td>
                    <asp:DropDownList ID="staffTypeSelection" runat="server">
                        <asp:ListItem Value="0">System Admin</asp:ListItem>
                        <asp:ListItem Value="1">Sales Officer</asp:ListItem>
                        <asp:ListItem Value="2">Cabin Attendant</asp:ListItem>
                        <asp:ListItem Value="3">Pilot</asp:ListItem>
                        <asp:ListItem Value="4">Check In Officer</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Birthday</td>
                <td>
                    <asp:TextBox ID="birthdayBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    Salary</td>
                <td>
                    <asp:TextBox ID="salaryBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="clearDeleteButton" runat="server" Text="Clear" />
                </td>
                <td colspan="2">
                    <asp:Button ID="addEditButton" runat="server" Text="Create" 
                        onclick="addEditButton_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
