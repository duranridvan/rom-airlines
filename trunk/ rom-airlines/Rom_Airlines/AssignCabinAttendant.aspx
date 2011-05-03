<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignCabinAttendant.aspx.cs" Inherits="Rom_Airlines.AssignCabinAttendant" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 24px;
        }
        .style3
        {
        }
        .style4
        {
            height: 24px;
            width: 170px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style3" colspan="2">
                   <b>Assign Cabin Attendant</b></td>
            </tr>
            <tr>
                <td class="style4">
                    Select Cabin Attendant</td>
                <td class="style2">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Date:</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click1" 
                        style="height: 26px" Text="Ok" />
&nbsp;(YYYY-MM-DD)</td>
            </tr>
            <tr>
                <td class="style3">
                    Select Flight No</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Assign" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
