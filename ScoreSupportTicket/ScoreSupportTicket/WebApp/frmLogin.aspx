<%@ Page Title="" Language="VB" MasterPageFile="~/Template/LoginMasterPage.master" AutoEventWireup="false" CodeFile="frmLogin.aspx.vb" Inherits="WebApp_frmLogin" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Visible="false" ></asp:TextBox>
                    <asp:Login ID="Login1" runat="server"  Width="100%" >
                        <LayoutTemplate>
                            <table width="380" cellpadding="0" cellspacing="0" 
                                style="border: 3px solid #C0C0C0; background-color:#ffffff; " align="center">
                                <tr>
                                    <td style="width:100px; padding: 3px 3px 3px 3px;" align="center"><img src="../Images/keys.png" /></td>
                                    <td valign="top">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td colspan="2" style="height:15px">&nbsp;
                                                </td>
                                            </tr>
                                            <tr style="height:25px">
                                                <td style="width:100px" align=right>
                                                     <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">ชื่อเข้าระบบ :</asp:Label>
                                                </td>
                                                <td style="width:150px;padding: 3px 3px 3px 3px">
                                                                <asp:TextBox ID="UserName" runat="server" CssClass="zTextbox" Width="130px"></asp:TextBox>&nbsp;
                                                    <font style="color:red">*</font></td>
                                            </tr>
                                            <tr style="height:25px">
                                                <td align=right>
                                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">รหัสผ่าน :</asp:Label>
                                                </td>
                                                <td style="padding: 3px 3px 3px 3px">
                                                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="zTextbox" Width="130px"></asp:TextBox>&nbsp;
                                                    <font style="color:red">*</font></td>
                                            </tr>
                                            <tr style="height: 25px">
                                                <td align="right" style="width: 80px">
                                                </td>
                                                <td style="padding-right: 3px; padding-left: 3px; padding-bottom: 3px; padding-top: 3px">
                                                                <asp:CheckBox ID="RememberMe" runat="server" Text="จดจำการเข้าระบบ" Visible="false" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height:15px" align="center">
                                        <hr size="1" style=" border-style:solid; border-width:1px; height:0px; color:#3399FF; width:95%;" />
                                        <span style="color:red"><asp:Literal ID="FailureText" runat="server" EnableViewState="False" Visible="False"></asp:Literal></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="right">
                                                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="ลงชื่อเข้าใช้" ValidationGroup="Login1" CssClass="zButton" Font-Bold="True" />
                                                            &nbsp;&nbsp;&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height:15px">
                                    
                                    </td>
                                </tr>
                            </table>            
                        </LayoutTemplate>
                    </asp:Login>
                     <cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1" BackgroundCssClass="modalBackground" DropShadow="true">
                     </cc1:ModalPopupExtender>
                        <asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
                        <asp:Panel ID="Panel1" runat="server" Width="100%">
                            <table width="400" bgcolor="#ffffff" style="border: solid 1px 1px 1px 1px #ff0000" id="tbError" runat="server" visible="false">
                                <tr>
                                    <td style="height:100px;" valign="middle" align="center">
                                        <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        <br />
                                        <br />
                                        <asp:Button ID="btnClose" runat="server" CssClass="zButton" 
                                            Text="ปิด" Width="50px" /></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
        </td>
    </tr>
</table>

</asp:Content>

