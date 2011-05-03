<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditAirport.aspx.cs" Inherits="Rom_Airlines.AddEditAirport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td colspan="2">
                    Manage Airport</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Airport Name</td>
                <td>
                    <asp:TextBox ID="nameBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Select City</td>
                <td>
                    <asp:DropDownList ID="cityList" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="addButton" runat="server" Text="Add" 
                        onclick="addButton_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
