<%@ Control Language="VB" AutoEventWireup="false" CodeFile="mstFormControl.ascx.vb" Inherits="UserControls_mstFormControl" %>
<%@ Register src="cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc1" %>
<%@ Register src="txtBox.ascx" tagname="txtBox" tagprefix="uc2" %>
<%@ Register src="cmbMasterTableForm.ascx" tagname="cmbMasterTableForm" tagprefix="uc3" %>
<uc1:cmbComboBox ID="cmbComboBox1" runat="server" DefaultDisplay="------Select" />
<asp:Button ID="btnAdd" runat="server" Text="Add New" Width="70" CssClass="zButton" />
<uc2:txtBox ID="txtMasterTableName" runat="server" Visible="false" Text="LOG_TYPE" />
<uc2:txtBox ID="txtRefMasterID" runat="server" Visible="false" />


<uc3:cmbMasterTableForm ID="cmbMasterTableForm1" runat="server" />