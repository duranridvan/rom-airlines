<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="Rom_Airlines._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 691px;
            float: left;
        }
        .style2
        {
            width: 178px;
        }
        .style3
        {
            width: 165px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table align="center" class="style1">
            <tr>
                <td colspan="4">
                    Sign Up</td>
            </tr>
            <tr>
                <td class="style2">
                    Name</td>
                <td class="style3">
                    <asp:TextBox ID="nameBox" runat="server"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    E-Mail</td>
                <td class="style3">
                    <asp:TextBox ID="emailBox" runat="server"></asp:TextBox>
                </td>
                <td class="style3">
                    Confirm E-Mail</td>
                <td class="style3">
                    <asp:TextBox ID="emailCBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Password</td>
                <td class="style3">
                    <asp:TextBox ID="passwordBox" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td class="style3">
                    Confirm Password</td>
                <td class="style3">
                    <asp:TextBox ID="passwordCBox" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Phone</td>
                <td class="style3">
                    <asp:TextBox ID="phoneBox" runat="server"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Birthday</td>
                <td class="style3">
                    <asp:TextBox ID="birthdayBox" runat="server"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Button ID="Button1" runat="server" Text="Clear" />
                </td>
                <td class="style3">
                    <asp:Button ID="Button2" runat="server" Text="Sign Up" 
                        onclick="Button2_Click" />
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
