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
            <td colspan="4" align="right">
                <asp:LinkButton ID="menuButton" runat="server" BorderStyle="Outset" 
                    CausesValidation="False" Font-Bold="True" Font-Overline="False" 
                    Font-Strikeout="False" PostBackUrl="~/default.aspx">Back</asp:LinkButton>
            </td>
            <td align="right">
                &nbsp;</td>
        </tr>
        
            <tr>
                <td colspan="4">
                    Sign Up</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Name</td>
                <td class="style3">
                    <asp:TextBox ID="nameBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="nameBox" ErrorMessage="RequiredFieldValidator" 
                        ValidationGroup="sup">*</asp:RequiredFieldValidator>
                </td>
                <td class="style3">
                    &nbsp;</td>
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="emailBox" ErrorMessage="RequiredFieldValidator" 
                        ValidationGroup="sup">*</asp:RequiredFieldValidator>
                </td>
                <td class="style3">
                    Confirm E-Mail</td>
                <td class="style3">
                    <asp:TextBox ID="emailCBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="emailCBox" ErrorMessage="RequiredFieldValidator" 
                        ValidationGroup="sup">*</asp:RequiredFieldValidator>
                </td>
                <td class="style3">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="emailBox" ControlToValidate="emailCBox" Display="Dynamic" 
                        ErrorMessage="CompareValidator" ValidationGroup="sup">email does not match</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Password</td>
                <td class="style3">
                    <asp:TextBox ID="passwordBox" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="passwordBox" ErrorMessage="RequiredFieldValidator" 
                        ValidationGroup="sup">*</asp:RequiredFieldValidator>
                </td>
                <td class="style3">
                    Confirm Password</td>
                <td class="style3">
                    <asp:TextBox ID="passwordCBox" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="passwordCBox" ErrorMessage="RequiredFieldValidator" 
                        ValidationGroup="sup">*</asp:RequiredFieldValidator>
                </td>
                <td class="style3">
                    <asp:CompareValidator ID="CompareValidator2" runat="server" 
                        ControlToCompare="passwordBox" ControlToValidate="passwordCBox" 
                        ErrorMessage="CompareValidator" ValidationGroup="sup">password does not match</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Phone</td>
                <td class="style3">
                    <asp:TextBox ID="phoneBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="phoneBox" ErrorMessage="RequiredFieldValidator" 
                        ValidationGroup="sup">*</asp:RequiredFieldValidator>
                </td>
                <td class="style3">
                    &nbsp;</td>
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="birthdayBox" ErrorMessage="RequiredFieldValidator" 
                        ValidationGroup="sup">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="birthdayBox" ErrorMessage="RegularExpressionValidator" 
                        ValidationExpression="^(19|20)\d\d-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])" 
                        ValidationGroup="sup">YYYY-MM-DD</asp:RegularExpressionValidator>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Button ID="Button1" runat="server" Text="Clear" onclick="Button1_Click1" 
                        CausesValidation="False" />
                </td>
                <td class="style3">
                    <asp:Button ID="Button2" runat="server" Text="Sign Up" 
                        onclick="Button2_Click" ValidationGroup="sup" />
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
