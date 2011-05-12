<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addEditFlight.aspx.cs" Inherits="Rom_Airlines.addEditFlight" %>

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
            <td colspan="6" align="right">
                <asp:LinkButton ID="menuButton" runat="server" BorderStyle="Outset" 
                    CausesValidation="False" Font-Bold="True" Font-Overline="False" 
                    Font-Strikeout="False" PostBackUrl="~/manageflight.aspx">Back</asp:LinkButton>
            </td>
        </tr>
            <tr>
                <td colspan="6">
                    Add/Edit Flight</td>
            </tr>
            <tr>
                <td colspan="2">
                    Flight No</td>
                <td colspan="2">
                    <asp:TextBox ID="flightidBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="flightidBox" ErrorMessage="enter flight no" 
                        ValidationGroup="aflight">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    Date</td>
                <td>
                    <asp:TextBox ID="dateBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="dateBox" ErrorMessage="enter date" ValidationGroup="aflight">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="dateBox" ErrorMessage="YYYY-MM-DD" 
                        ValidationExpression="^(19|20)\d\d-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])" 
                        ValidationGroup="aflight">YYYY-MM-DD</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Plane:</td>
                <td>
                    <asp:DropDownList ID="planeList" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="planeList" ErrorMessage="Select plane" 
                        ValidationGroup="aflight">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    Departure</td>
                <td>
                    <asp:DropDownList ID="departureList" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="departureList" ErrorMessage="select airport" 
                        ValidationGroup="aflight">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    Landing</td>
                <td>
                    <asp:DropDownList ID="landingList" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="landingList" ErrorMessage="select airport" 
                        ValidationGroup="aflight">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    Time</td>
                <td>
                    <asp:TextBox ID="deptTimeBox" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                        ControlToValidate="deptTimeBox" ErrorMessage="hh:mm" 
                        ValidationExpression="^((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [AP]M))$|^([01]\d|2[0-3])(:[0-5]\d){1,2}" 
                        ValidationGroup="aflight">*</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="deptTimeBox" ErrorMessage="enter time" 
                        ValidationGroup="aflight">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    Time</td>
                <td>
                    <asp:TextBox ID="landTimeBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="landTimeBox" ErrorMessage="enter time" 
                        ValidationGroup="aflight">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                        ControlToValidate="landTimeBox" ErrorMessage="hh:mm" 
                        ValidationExpression="^((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [AP]M))$|^([01]\d|2[0-3])(:[0-5]\d){1,2}" 
                        ValidationGroup="aflight">hh:mm</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td colspan="2">
                    <asp:Button ID="addeditbutton" runat="server" Text="Add" 
                        onclick="addeditbutton_Click" ValidationGroup="aflight" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
