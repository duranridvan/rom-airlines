<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Rom_Airlines.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
    
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/rom.jpg" />
                    </div>
                    <div>
              
        <br />
        <br />
    
    
    <table align="center">
        <tr>
            <td><li>
                Email</li></td>
            <td colspan="2">
                <asp:TextBox ID="usernameBox" runat="server" MaxLength="50"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="usernameValidator" runat="server" 
                    ControlToValidate="usernameBox" ErrorMessage="Enter Username">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><li>
                Password
            </li></td>
            <td colspan="2">
                <asp:TextBox ID="passwordBox" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
            </td>
            <td>
                    <asp:RequiredFieldValidator ID="passwordValidator" runat="server" 
                        ErrorMessage="Enter Password" ControlToValidate="passwordBox">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                &nbsp;</td>
            <td colspan="2" align="right"><asp:Button 
                    ID="loginButton" runat="server" Text="Sign In" onclick="loginAut" 
                    onclientclick="loginAut" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="signUpButton" runat="server" onclick="signUpButton_Click" 
                    Text="SignUp" CausesValidation="False" />
            </td>
            <td align="right">
                <asp:Button ID="resButton" runat="server" CausesValidation="False" 
                    onclick="resButton_Click" Text="Make Reservation" />
            </td>
            <td colspan="2" align="right">
                <asp:Button ID="checkinbutton" runat="server" CausesValidation="False" 
                    onclick="checkinbutton_Click" Text="Online Check In" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="errorLabel" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </td>
        </tr>
    </table>
    
    
    
    
    
    
    
    
    </div>
    </form>
</body>
</html>
