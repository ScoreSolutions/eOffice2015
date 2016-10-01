<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PageControl.ascx.vb" Inherits="UserControls_PageControl" %>
<table cellpadding="0" cellspacing="0" border="0" width="100%" id="TABLE1" style="background-color: #f5f5f5">
    <tr>
        <td style="padding-top:3px; padding-bottom:3px; width:300px">
            <asp:LinkButton ID="lnbBack" runat="server" OnClick="lnbBack_Click">[<]</asp:LinkButton>
            หน้าที่
            <asp:DropDownList ID="cmbPage" runat="server" CssClass="zComboBox" Width="50px" AutoPostBack="True" OnSelectedIndexChanged="cmbPage_SelectedIndexChanged">
            </asp:DropDownList>
            จาก
            <asp:Label ID="lblTotalPage" runat="server"></asp:Label>
            หน้า 
            <asp:LinkButton ID="lnbNext" runat="server" OnClick="lnbNext_Click">[>]</asp:LinkButton>
        </td>
        <td style="padding-top:3px; padding-bottom:3px; padding-right:5px" align="right">
            <asp:Label ID="lblSummary" runat="server"></asp:Label>
        </td>
    </tr>
</table>
