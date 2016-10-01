<%@ Control Language="VB" AutoEventWireup="false" CodeFile="popMessage.ascx.vb" Inherits="UserControl_popMessage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<cc1:ModalPopupExtender ID="popMessage"  runat="server" PopupControlID="pnlMessage" DropShadow="true"  TargetControlID="btntest" ></cc1:ModalPopupExtender>
<asp:Panel ID="pnlMessage"  runat="server" CssClass="modalPopupSearch" style="display:none"  Width="400px" Height="210px" ScrollBars="None"  >
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td class="popHead" style="Height:30px"><asp:Label ID="lblPopupName" runat="server" ForeColor="White" Font-Size="Small" Font-Bold="true" Text="Validate Data" ></asp:Label></td>
        </tr>
        <tr>
            <td><hr style="size:1px" />
            </td>
        </tr>
        <tr>
            <td>
                <fieldset style="padding:10px;">
                    <legend style="font-weight:bold"></legend>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr style="height:30px">
                            <td style="width:30%; padding-right:10px; text-align:left" rowspan="2">
                                <asp:Image ID="imgIcon" runat="server" ImageUrl="~/Images/icon_exclamation.jpg" />
                            </td>
                            <td style="width:70%">&nbsp;</td>
                        </tr>
                        <tr style="height:30px">
                            <td valign="top"><asp:Label ID="lblMessage" runat="server" Font-Size="Medium" Text=""></asp:Label></td>
                        </tr>
                        <tr style="height:15px">
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr style="height:30px">
                            <td colspan="2"  style="text-align:center">
                                <asp:Button ID="btnOK" runat="server" Text="OK" Visible="false" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" />
                                <asp:Button ID="btnYes" runat="server" Text="Yes" Visible="false" />
                                <asp:Button ID="btnNo" runat="server" Text="No" Visible="false" />
                            </td>
                        </tr>
                        <tr style="height:15px">
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </fieldset>     
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Button ID="btntest" runat="server" Text="test" CssClass="zHidden" />
