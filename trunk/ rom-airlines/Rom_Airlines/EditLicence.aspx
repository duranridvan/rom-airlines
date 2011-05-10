<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditLicence.aspx.cs" Inherits="Rom_Airlines.EditLicence" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        
    <table class="style1">
    <tr>
            <td colspan="2" align="right">
                <asp:LinkButton ID="menuButton" runat="server" BorderStyle="Outset" 
                    CausesValidation="False" Font-Bold="True" Font-Overline="False" 
                    Font-Strikeout="False" PostBackUrl="~/menu.aspx">Menu</asp:LinkButton>
            </td>
        </tr>
            <tr>
                <td colspan="3">
                    <h1 style="text-align: center">
            Edit Licence</h1></td>
            </tr>
            <tr>
                <td>
                    Name</td>
                <td>
                    <asp:TextBox ID="nameBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="changenamebutton" runat="server" 
                        onclick="changenamebutton_Click" Text="Change" />
                </td>
            </tr>
            <tr>
                <td>
                    Covered Models</td>
                <td>
                    &nbsp;</td>
                <td>
                    Other Models</td>
            </tr>
            <tr>
                <td rowspan="2">
                    <asp:ListBox ID="hasBox" runat="server" Height="200px" 
                         Width="100px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
                <td>
                    <asp:Button ID="addButton" runat="server" Text="Add" 
                        onclick="addButton_Click" />
                </td>
                <td rowspan="2">
                    <asp:ListBox ID="otherBox" runat="server" Height="200px" Width="100px" 
                        SelectionMode="Multiple" 
                        onselectedindexchanged="otherBox_SelectedIndexChanged">
                    </asp:ListBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="removeButton" runat="server" Text="Remove" 
                        onclick="removeButton_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
