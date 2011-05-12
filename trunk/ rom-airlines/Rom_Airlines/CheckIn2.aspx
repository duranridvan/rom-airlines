<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckIn2.aspx.cs" Inherits="Rom_Airlines.CheckIn2" %>

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
            height: 23px;
            text-align: center;
        }
        .style3
        {
            height: 137px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <h1>
                    Online Check In</h1>
    
    </div>
    <table class="style1">
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td colspan="2" class="style3">
                            <center><asp:GridView ID="Flight1Grid" runat="server">
                            </asp:GridView></center>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="Passengers1Grid" runat="server" 
                                AutoGenerateSelectButton="True" style="margin-right: 0px">
                                <Columns>
                                    <asp:BoundField HeaderText="Seat" />
                                </Columns>
                                <EmptyDataTemplate>
                                    Seat
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="Seats1List" runat="server">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            <asp:GridView ID="Passengers2Grid" runat="server" 
                                AutoGenerateSelectButton="True">
                                <Columns>
                                    <asp:BoundField HeaderText="Seat" />
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="Seats2List" runat="server">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Button ID="Button1" runat="server" style="text-align: right" 
                    Text="Complete Check-in" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
