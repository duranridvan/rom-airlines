<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editLicencePilot.aspx.cs" Inherits="Rom_Airlines.editLicencePilot" %>

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
                <td colspan="3">
                    Edit Licences of Pilot</td>
            </tr>
            <tr>
                <td>
                    Select Pilot</td>
                <td>
                    <asp:DropDownList ID="pilotList" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="listButton" runat="server" onclick="listButton_Click" 
                        Text="List" />
                </td>
            </tr>
            <tr>
                <td>
                    Licences of Pilot</td>
                <td>
                    &nbsp;</td>
                <td>
                    Other Licences</td>
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
                        SelectionMode="Multiple">
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
