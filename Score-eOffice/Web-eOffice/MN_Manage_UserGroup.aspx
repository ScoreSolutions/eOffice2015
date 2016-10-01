<%@ Page Language="VB" Debug="true" AutoEventWireup="false" MasterPageFile="MasterPage_Basic.master"
    CodeFile="MN_Manage_UserGroup.aspx.vb" EnableEventValidation="false" Inherits="_Manage_UserGroup" %>

<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="cphMain">

    <script type="text/javascript" src="__js/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="__js/jquery-ui.js"></script>
    <link href="__css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script>
        $(function() {
            $("#tabs").tabs();
        });
    </script>

    <br />
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
            <td style="width:50%" valign="top">
                <table width="400" border="1" align="center" cellpadding="0" class="dataTable">
                    <tr>
                        <td colspan="2" align="center" class="dataTableHeader">
                            User Group
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" align="right" class="dataTableSubHeader">
                            Name (English)
                        </td>
                        <td width="50%" class="dataTableCell" align="left">
                            <asp:TextBox CssClass="textboxRequired" Width="150" ID="txtNameEn" MaxLength="20"
                                runat="server" onKeyPress="validateEnglish(this, event);" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="dataTableSubHeader">
                            Name (Thai)
                        </td>
                        <td class="dataTableCell" align="left">
                            <asp:TextBox CssClass="textBox" Width="150" ID="txtNameTh" MaxLength="20" runat="server"
                                onKeyPress="validateThai(this, event);" />
                        </td>
                    </tr>
                    <tr>
                        <td class="dataTableSubHeader" align="right">
                            Active
                        </td>
                        <td class="dataTableCell" align="left">
                            <asp:CheckBox ID="ckbUserGroup" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <table align="center">
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btnSave" Text="Add" runat="server" CssClass="buttonNormal" />
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="buttonWarning" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                    <asp:Label Width="400" ID="lblShowMessage" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width:50%" valign="top">
                <asp:Repeater runat="server" ID="rptGroupShow">
                    <HeaderTemplate>
                        <br />
                        <table align="center" class="dataTable" width="400" border="1">
                            <tr>
                                <td colspan="3" align="center" class="dataTableHeader">
                                    VIEW GROUP
                                </td>
                            </tr>
                            <tr align="center" class="dataTableSubHeader">
                                <td>
                                    No.
                                </td>
                                <td>
                                    Group Name
                                </td>
                                <td>
                                    Edit/Delete
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="dataTableCell">
                            <td align="center">
                                <%#Container.ItemIndex + 1%>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;<%#Container.DataItem("group_name")%>
                            </td>
                            <td align="right">
                                <asp:Button CssClass="buttonNormal" ID="btnEdit" Text="Edit" runat="server" CommandArgument='<%#Container.DataItem("ID")%>'
                                    CommandName="Edit" />&nbsp;<asp:Button CssClass="buttonCritical" ID="btnDelete" Text="Delete"
                                        runat="server" CommandArgument='<%#Container.DataItem("ID")%>' CommandName="Delete"
                                        OnClientClick="return confirm('Are you sure you want to delete?');" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="altDataTableCell">
                            <td align="center">
                                <%#Container.ItemIndex + 1%>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;<%#Container.DataItem("group_name")%>
                            </td>
                            <td align="right">
                                <asp:Button CssClass="buttonNormal" ID="btnEdit" Text="Edit" runat="server" CommandArgument='<%#Container.DataItem("ID")%>'
                                    CommandName="Edit" />&nbsp;<asp:Button CssClass="buttonCritical" ID="btnDelete" Text="Delete"
                                        runat="server" CommandArgument='<%#Container.DataItem("ID")%>' CommandName="Delete"
                                        OnClientClick="return confirm('Are you sure you want to delete?');" />
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            
            
            
            
            </td>
        </tr>
    </table>
    
    <br />
    <div id="tabs">
        <ul>
            <li><a href="#tabsMenu">Menu</a></li>
            <li><a href="#tabsResponsibility">Responsibility</a></li>
        </ul>
        <div id="tabsMenu">
            <table align="center" class="dataTable" width="400">
                <tr class="dataTableHeader">
                    <td colspan="3">
                        <table width="100%" align="center">
                            <tr>
                                <td align="center">
                                    Default Access For This Group
                                </td>
                                <td align="right">
                                   <%-- <asp:Button ID="btnShowHide" runat="server" Text="Hide" CssClass="buttonNormal" />--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="dataTableSubHeader" align="center">
                    <td>
                    </td>
                    <td>
                        SubMenu
                    </td>
                    <td>
                        MainMenu
                    </td>
                </tr>
                <asp:Repeater runat="server" ID="rptUbaMenu">
                    <ItemTemplate>
                        <tr>
                            <td class="dataTableCell" align="center">
                                <asp:CheckBox ID="chkMenu" runat="server" value='<%#Container.DataItem("ID")%>' OnCheckedChanged="checkedChanged" />
                            </td>
                            <td class="dataTableCell" runat="server" id="td2">
                                &nbsp;&nbsp;<%#Container.DataItem("menu_text")%>
                            </td>
                            <td class="dataTableCell" runat="server" id="td3">
                                &nbsp;&nbsp;<%#Container.DataItem("parent_name")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr>
                            <td class="altDataTableCell" align="center">
                                <asp:CheckBox ID="chkMenu" runat="server" value='<%#Container.DataItem("ID")%>' OnCheckedChanged="checkedChanged" />
                            </td>
                            <td class="altDataTableCell" runat="server" id="td2">
                                &nbsp;&nbsp;<%#Container.DataItem("menu_text")%>
                            </td>
                            <td class="altDataTableCell" runat="server" id="td3">
                                &nbsp;&nbsp;<%#Container.DataItem("parent_name")%>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <div id="tabsResponsibility">
            <table align="center" class="dataTable" width="400">
                <tr class="dataTableHeader">
                    <td colspan="2">
                        <table width="100%" align="center">
                            <tr>
                                <td align="center">
                                    Role Responsibility For This Group
                                </td>
                                <td align="right">
                                   
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="dataTableSubHeader" align="center">
                    <td>
                    </td>
                    <td>
                        Responsilibity
                    </td>
                </tr>
                <asp:Repeater runat="server" ID="rptResponsibility">
                    <ItemTemplate>
                        <tr>
                            <td class="dataTableCell" align="center">
                                <asp:CheckBox ID="chkResponsibility" runat="server" value='<%#Container.DataItem("id")%>' OnCheckedChanged="chkResponsibility_Changed" />
                            </td>
                            <td class="dataTableCell" runat="server" id="td2">
                                &nbsp;&nbsp;<%#Container.DataItem("responsibility_name")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr>
                            <td class="altDataTableCell" align="center">
                                <asp:CheckBox ID="chkResponsibility" runat="server" value='<%#Container.DataItem("id")%>' OnCheckedChanged="chkResponsibility_Changed" />
                            </td>
                            <td class="altDataTableCell" runat="server" id="td2">
                                &nbsp;&nbsp;<%#Container.DataItem("responsibility_name")%>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
            </table>
        
        </div>
    </div>
    <br />
    
    
    <center>
        </center>
    <br />
    <asp:CheckBoxList ID="chkSelectedMenu" runat="server" Visible="false" />
     <asp:CheckBoxList ID="chkSelectedUser" runat="server" Visible="false" />
     <asp:CheckBoxList ID="chkSelectedResponsibility" runat="server" Visible="false" />
</asp:Content>
