<%@ Page Language="VB" MasterPageFile="~/MasterPage_Basic.master" AutoEventWireup="false"
    CodeFile="ET_ProjectBilling.aspx.vb" Inherits="ET_ProjectBilling" Title="Untitled Page" %>

<%@ Register Src="UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <table width="500" border="1" align="center" cellpadding="0" class="dataTable">
                    <tr>
                        <td align="center" class="dataTableHeader">
                            Project Billing
                        </td>
                    </tr>
                    <tr>
                        <td class="dataTableCell">
                            <table align="center">
                                <tr>
                                    <td>
                                        Account:
                                    </td>
                                    <td align="left">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlAccount" runat="server" Width="250px" DataTextField="Account_name"
                                                    DataValueField="id" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Project:
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlProject" runat="server" Width="250px" DataTextField="project_name"
                                                    DataValueField="id">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 111px">
                                        Billing Name:
                                    </td>
                                    <td align="left" style="width: 159px">
                                        <asp:TextBox CssClass="textboxRequired" Width="250" ID="txtBillingName" MaxLength="255"
                                            runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 111px">
                                        PO No:
                                    </td>
                                    <td align="left" style="width: 159px">
                                        <asp:TextBox CssClass="textboxRequired" Width="150" ID="txtPONo" MaxLength="20" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 111px">
                                        PO Date:
                                    </td>
                                    <td align="left" style="width: 159px">
                                        <uc1:txtDate ID="txtPODate" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <center>
                    <br />
                    <br />
                    <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="buttonCreate" Width="49px" />
                    &nbsp;<asp:Button ID="btnCancle" Text="Cancle" runat="server" CssClass="buttonNormal" />
                    <br />
                    <br />
                </center>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Repeater ID="rptShowProjectBilling" runat="server">
                    <HeaderTemplate>
                        <table align="center" class="dataTable" width="800" border="1">
                            <tr>
                                <td colspan="7" align="center" class="dataTableHeader">
                                    Project Billing List
                                </td>
                            </tr>
                            <tr align="center" class="dataTableSubHeader">
                                <td>
                                    No.
                                </td>
                                <td>
                                    Account
                                </td>
                                <td>
                                    Project
                                </td>
                                <td>
                                    Billing Name
                                </td>
                                <td>
                                    PO No
                                </td>
                                <td>
                                    PO Date
                                </td>
                                <td>
                                    Edit/Delete
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr align="center" class="dataTableCell">
                            <td align="center">
                                <%#Container.ItemIndex + 1%>
                            </td>
                            <td align="left">
                                <%#Container.DataItem("account_name")%>
                            </td>
                            <td align="left">
                                <%#Container.DataItem("project_name")%>
                            </td>
                            <td align="left">
                                <%#Container.DataItem("billing_name")%>
                            </td>
                            <td align="left">
                                <%#Container.DataItem("ref_po_no")%>
                            </td>
                             <td align="left">
                                <%#Container.DataItem("str_po_date")%>
                            </td>
                            <td align="left">
                                <asp:Button CssClass="buttonNormal" ID="btnEdit" Text="Edit" runat="server" CommandArgument='<%#container.dataitem("id") %>'
                                    CommandName="Edit" />&nbsp;<asp:Button CssClass="buttonCritical" ID="btnDelete" Text="Delete"
                                        runat="server" CommandArgument='<%#container.dataitem("id") %>' CommandName="Delete"
                                        OnClientClick="return confirm('Are you sure you want to delete?');" />
                               
                                <asp:Label ID="lblpjBillingID" runat="server" Text='<%#Container.DataItem("id")%>' Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr align="center" class="altdataTableCell">
                            <td align="center">
                                <%#Container.ItemIndex + 1%>
                            </td>
                            <td align="left">
                                <%#Container.DataItem("account_name")%>
                            </td>
                            <td align="left">
                                <%#Container.DataItem("project_name")%>
                            </td>
                            <td align="left">
                                <%#Container.DataItem("billing_name")%>
                            </td>
                            <td align="left">
                                <%#Container.DataItem("ref_po_no")%>
                            </td>
                             <td align="left">
                                <%#Container.DataItem("str_po_date")%>
                            </td>
                            <td align="left">
                                <asp:Button CssClass="buttonNormal" ID="btnEdit" Text="Edit" runat="server" CommandArgument='<%#container.dataitem("id") %>'
                                    CommandName="Edit" />&nbsp;<asp:Button CssClass="buttonCritical" ID="btnDelete" Text="Delete"
                                        runat="server" CommandArgument='<%#container.dataitem("id") %>' CommandName="Delete"
                                        OnClientClick="return confirm('Are you sure you want to delete?');" />
                                        
                             <asp:Label ID="lblpjBillingID" runat="server" Text='<%#Container.DataItem("id")%>' Visible="false"></asp:Label>           
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
    <center>
        <br />
     <asp:Label ID="lblID" runat="server" Visible="False">0</asp:Label><br />
        <asp:Label ID="lblError" runat="server" Visible="false" Width="400" CssClass="errorBox" />
        <br />
        <br />
    </center>
</asp:Content>
