<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cmbMasterTableForm.ascx.vb" Inherits="UserControls_cmbMasterTableForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="txtBox.ascx" tagname="txtBox" tagprefix="uc1" %>
<%@ Register src="popMessage.ascx" tagname="popMessage" tagprefix="uc2" %>
<%@ Register src="cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc3" %>

<cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1" BackgroundCssClass="modalBackground" DropShadow="true">
</cc1:ModalPopupExtender>
    <asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    <asp:Panel ID="Panel1" runat="server" Width="100%">
    <table id="Table1" width="600" border="1" cellpadding="0" cellspacing="0" bgcolor="#ffffff" style="border: solid 1px 1px 1px 1px #ff0000" runat="server" >
        <tr>
            <td colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr style="background-color:#3399FF">
                        <td><asp:Label ID="lblPageName" runat="server" ></asp:Label></td>
                        <td align="right">
                            <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../Images/icn_close.png" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="rwProjectID" runat="server" visible="false" >
            <td align="right" >Project : </td>
            <td align="left" >
                <uc3:cmbComboBox ID="cmbProject" runat="server" Width="250px" />
            </td>
        </tr>
        <tr id="rwModuleID" runat="server" visible="false" >
            <td align="right" >Module : </td>
            <td align="left" >
                <uc3:cmbComboBox ID="cmbModule" runat="server" Width="250px" />
            </td>
        </tr>
        <tr id="rwCode" runat="server" >
            <td align="right" width="30%">Code : </td>
            <td align="left" width="60%">
                <uc1:txtBox ID="txtCode" runat="server" TextType="TextBox" Width="100px" />
            </td>
        </tr>
        <tr>
            <td align="right"><asp:Label ID="lblMasterName" runat="server" ></asp:Label> : </td>
            <td align="left">
                <uc1:txtBox ID="txtName" runat="server" TextType="TextBox" Width="250px" IsNotNull="true" />
                <uc1:txtBox ID="txtMasterTableName" runat="server" Visible="false" />
                <uc1:txtBox ID="txtID" runat="server" Visible="false" />
                <uc1:txtBox ID="txtRefProjectID" runat="server" Visible="false" />
            </td>
        </tr>
        <tr>
            <td align="right">Description : </td>
            <td align="left"><uc1:txtBox ID="txtDesc" runat="server" TextMode="MultiLine" Height="50px" Width="250px" /></td>
        </tr>
        <tr>
            <td align="right">Order : </td>
            <td align="left"><uc1:txtBox ID="txtOrder" runat="server" TextKey="TextInt" IsNotNull="true" Width="50px" /></td>
        </tr>
        <tr id="rwActive" runat="server">
            <td align="right">&nbsp;</td>
            <td align="left"><asp:CheckBox ID="chkActive" runat="server" Checked="true"  Text="Active" /></td>
        </tr>
        <tr style="height:35px" >
            <td align="right">&nbsp;</td>
            <td align="left"><asp:Button ID="btnSave" runat="server" Text="Save" Width="60" /></td>
        </tr>
    </table>
    </asp:Panel>


<uc2:popMessage ID="popMessage1" runat="server" />
