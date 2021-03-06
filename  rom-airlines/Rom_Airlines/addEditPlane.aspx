﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addEditPlane.aspx.cs" Inherits="Rom_Airlines.addEditPlane" %>

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
                    Font-Strikeout="False" PostBackUrl="~/manageplane.aspx">Back</asp:LinkButton>
            </td>
        </tr>
                <td colspan="2">
                    Add/Edit Plane</td>
            </tr>
            <tr>
                <td>
                    Name</td>
                <td>
                    <asp:TextBox ID="nameBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="nameBox" ErrorMessage="enter name" ValidationGroup="aplane">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Model</td>
                <td>
                    <asp:DropDownList ID="planeModelList" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="planeModelList" ErrorMessage="select model" 
                        ValidationGroup="aplane">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="addeditbutton" runat="server" onclick="addeditbutton_Click" 
                        Text="Add" ValidationGroup="aplane" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
