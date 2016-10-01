<%@ Page Language="VB" AutoEventWireup="false"  MasterPageFile="MasterPage_Basic.master" CodeFile="MN_Change_Password.aspx.vb" Inherits="_change_password" %>
<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="cphMain">
<br />
<table width="400" border="1"  align="center" cellpadding="0"  class="dataTable">
  <tr>
    <td align ="center" class="dataTableHeader">Change Password </td>
  </tr>
  <tr>
    <td class="dataTableCell">
        <table align ="center" >
        <tr ><td>User name:</td><td align="left"><asp:TextBox cssclass="textboxReadOnly" Width="150" ID="txtUserName"  MaxLength="20" runat ="server" ReadOnly="true"/></td></tr>
        <tr ><td>Old Password:</td><td align="left"><asp:TextBox CssClass="textboxRequired" Width="150" ID="txtOldPass"  MaxLength="20" runat ="server" TextMode="Password"   /></td></tr>
        <tr ><td>New Password:</td><td align="left"><asp:TextBox CssClass="textboxRequired" Width="150" ID="txtNewPass"  MaxLength="20" runat ="server" TextMode="Password"  /></td></tr>
        <tr ><td>Re-type New Password:</td><td align="left"><asp:TextBox CssClass="textboxRequired" Width="150" ID="txtNewPass1"  MaxLength="20" runat ="server" TextMode="Password"  /></td></tr>
            
        </table>
    </td>
  </tr>
  <tr class="altDataTableCell">
    <td colspan ="2" align="center" ><asp:Button ID="btnOK" runat="server" Text="Save"   CssClass="buttonCreate" />&nbsp;&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel"  /></td>
    
  </tr>
</table>
<center><asp:Label Width="400" ID="lblError" runat ="server" Visible = "false" CssClass="errorBox" /></center>
</asp:Content>

