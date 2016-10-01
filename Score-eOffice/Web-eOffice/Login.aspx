<%@ Page Language="VB" MasterPageFile="~/MasterPageLogin.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

<table width="250" border="1"  align="center" cellpadding="0" class="dataTable" style="height: 184px" >
  <tr class="dataTableCell">
    <td style="width: 244px" bgcolor="#ccccff" >Please Login </td>
  </tr>
  <tr class="dataTableCell">
    <td style="width: 244px; height: 161px;" >
    <br />
<br />

        <table align ="center" class="dataTable">
        <tr  class="dataTableCell"><td>Username:</td><td align="left" style="width: 159px"><asp:TextBox  Width="150" ID="txtusername"  MaxLength="20" runat ="server" TabIndex="0"/></td></tr>
        <tr  class="dataTableCell"><td>Password:</td><td align="left" style="width: 159px"><asp:textbox  Width="150" id ="txtpassword" TextMode="Password"   maxlength="20" runat="server" TabIndex="1"/></td></tr>
        <tr  class="dataTableCell"><td colspan="2" align="center" style="height: 26px"><asp:Button ID ="btnlogin" Text="login" runat="server" CssClass="butNormal" TabIndex="2" /></td></tr>
        <tr  class="dataTableCell"><td colspan ="2" align="center"><asp:Label id="lblInvalid" runat ="server" CssClass="txtErr" ></asp:Label></td></tr>
        </table>

<br />
    </td>
  </tr>
</table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

