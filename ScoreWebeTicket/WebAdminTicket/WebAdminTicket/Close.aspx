<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Close.aspx.vb" Inherits="WebTarget.Close" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>
<head>
    <title>Send Mail</title>
    </head>
<body>
	<form id="form1" runat="server">
	<asp:Panel id="pnlForm" runat="server" style="text-align: right">
	    <p style="font-size: large; color: #00CC00; text-align: left; background-color: #515151;">
            <strong style="color: #b6ff00">CLOSE TICKET</strong><asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </p>
        <asp:Button ID="Button2" runat="server" BackColor="#993300" BorderStyle="None" Font-Bold="True" Text="Close Ticket"/>
	    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" GridLines="None" style="text-align: center"><mastertableview><rowindicatorcolumn><HeaderStyle Width="20px" /></rowindicatorcolumn><expandcollapsecolumn><HeaderStyle Width="20px" /></expandcollapsecolumn>
            <Columns>
                <telerik:GridTemplateColumn HeaderText="T-Code" UniqueName="TemplateColumn" DataField="ticket_code">
                    <ItemTemplate >
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ticket_code")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="60px" /></telerik:GridTemplateColumn>           
                <telerik:GridTemplateColumn HeaderText="Resolved" UniqueName="TemplateColumn1" DataField="resolved" >
                    <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("resolved")%>' ></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="450px" />
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Cus-mail" UniqueName="TemplateColumn2" DataField="email_customer" >
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("email_customer")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="350px" />
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="TemplateColumn3" HeaderText="Sendmail">
                    <ItemTemplate>
                        <asp:ImageButton ID="Button1" runat="server" Height="37px" style="text-align: center" Width="105px" CommandName="Select" BorderStyle="None" ImageUrl="~/Image/sendmail.png"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </telerik:GridTemplateColumn>
            </Columns></mastertableview><filtermenu enabletheming="True"><collapseanimation duration="200" type="OutQuint" /></filtermenu></telerik:RadGrid>
	    <telerik:RadWindowManager ID="RadWindowManager1" runat="server"></telerik:RadWindowManager>
	    <br />
         </asp:Panel>
	    <asp:Label ID="lblPathEmail" runat="server"></asp:Label>
	</form>
</body>
