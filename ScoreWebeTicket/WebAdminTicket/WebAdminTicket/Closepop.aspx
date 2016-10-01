<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Closepop.aspx.vb" Inherits="WebTarget.Closepop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">เลือก Ticket ที่ต้องการปิด</td>
                <td style="text-align: left">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" >
                        <asp:ListItem>Select Ticket</asp:ListItem>
                    </asp:DropDownList>
&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="Confrim" Height="22px" />
                </td>
            </tr>
            </table>
    </center>
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Support-TicketConnectionString %>" SelectCommand="SELECT [ticket_code] FROM [TICKET_TICKET]"></asp:SqlDataSource>
    </form>
</body>
</html>
