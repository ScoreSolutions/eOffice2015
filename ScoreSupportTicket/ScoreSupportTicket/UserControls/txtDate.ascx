<%@ Control Language="VB" AutoEventWireup="false" CodeFile="txtDate.ascx.vb" Inherits="UserControls_txtDate" %>
<asp:TextBox ID="TextBox1" runat="server" AutoPostBack="false" CssClass="TextView" Width="80"  ></asp:TextBox>
<a href="#" onClick="NewCssCal('<%=TextBox1.ClientID %>','DDMMYYYY')" style="text-decoration:none" >
    <img src="../Images/btn_calendar.png" width="19" height="19" border="0" id="ImageButton1" runat="server" style="vertical-align:baseline;" />
</a>
<asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
<asp:Label ID="lblValidText" runat="server" Text="" ForeColor="Red"></asp:Label>
