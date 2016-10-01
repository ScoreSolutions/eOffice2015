<%@ Control Language="VB" AutoEventWireup="false" CodeFile="txtDate2.ascx.vb" Inherits="UserControls_txtDate2" %>


<%@ Register src="txtBox.ascx" tagname="txtBox" tagprefix="uc1" %>

<uc1:txtBox ID="txtDay" runat="server" Width="15" TextKey="TextInt" />/
<uc1:txtBox ID="txtMonth" runat="server" Width="15" TextKey="TextInt" />/
<uc1:txtBox ID="txtYear" runat="server" Width="40" TextKey="TextInt" />
<asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>





