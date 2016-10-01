<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cmbStaffTable.ascx.vb" Inherits="UserControls_cmbStaffTable" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc1" %>
<%@ Register src="txtBox.ascx" tagname="txtBox" tagprefix="uc2" %>
<%@ Register src="mstStaffForm.ascx" tagname="mstStaffForm" tagprefix="uc3" %>

<uc1:cmbComboBox ID="cmbComboBox1" runat="server" DefaultDisplay="------Select" />
<asp:Button ID="btnAdd" runat="server" Text="Add New" Width="70" CssClass="zButton" />
<uc2:txtBox ID="txtFldName" runat="server" Visible="false" />
<uc2:txtBox ID="txtProjectID" runat="server" Visible="false" />

<cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1" BackgroundCssClass="modalBackground" DropShadow="true">
</cc1:ModalPopupExtender>
    <asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    <asp:Panel ID="Panel1" runat="server" Width="100%">
        <uc3:mstStaffForm ID="mstStaffForm1" runat="server" />
    </asp:Panel>

