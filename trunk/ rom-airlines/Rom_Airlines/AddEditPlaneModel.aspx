<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditPlaneModel.aspx.cs" Inherits="Rom_Airlines.AddEditPlaneModel" %>

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
            <td colspan="2" align="right">
                <asp:LinkButton ID="menuButton" runat="server" BorderStyle="Outset" 
                    CausesValidation="False" Font-Bold="True" Font-Overline="False" 
                    Font-Strikeout="False" PostBackUrl="~/manageplanemodel.aspx">Back</asp:LinkButton>
            </td>
        </tr>
            <tr>
                <td colspan="2">
                    Add/Edit Plane Model</td>
            </tr>
            <tr>
                <td>
                    Name</td>
                <td>
                    <asp:TextBox ID="nameBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Economy Class Capacity</td>
                <td>
                    <asp:TextBox ID="econBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Bussinness Class Capacity</td>
                <td>
                    <asp:TextBox ID="bussBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    First Class Capacity</td>
                <td>
                    <asp:TextBox ID="firstBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="addEditButton" runat="server" Text="Add" 
                        onclick="addEditButton_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
