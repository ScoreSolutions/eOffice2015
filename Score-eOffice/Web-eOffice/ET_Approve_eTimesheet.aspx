<%@ Page Language="VB" MasterPageFile="~/MasterPage_Basic.master" AutoEventWireup="false"
    CodeFile="ET_Approve_eTimesheet.aspx.vb" Inherits="ET_Approve_eTimesheet" Title="Untitled Page" %>

<%@ Register Src="UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <center>
        <div style="width: 700px">
            <table width="700" border="1" align="center" cellpadding="0" class="dataTable">
                <tr>
                    <td align="center" class="dataTableHeader">
                        Approve eTimeSheet
                    </td>
                </tr>
                <tr>
                    <td class="dataTableCell">
                        <table align="center">
                            <tr>
                                <td align="left">
                                    Project :
                                </td>
                                <td align="left" class="style1">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlProject" runat="server" Width="200px" DataTextField="project_name"
                                                DataValueField="id" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 111px" align="left">
                                    Billing :
                                </td>
                                <td align="left" class="style1">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlBillingName" runat="server" Width="200px" DataTextField="Billing_Name"
                                                DataValueField="Id">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 111px" align="left">
                                    Staff Name :
                                </td>
                                <td align="left" class="style1">
                                    <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlStaff" runat="server" Width="200px" DataTextField="Name"
                                                DataValueField="Id">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 111px" align="left">
                                    Date :
                                </td>
                                <td align="left" class="style1">
                                    <table cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                    <ContentTemplate>
                                                        <uc1:txtDate ID="txtDateFrom" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td>
                                                To
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                    <ContentTemplate>
                                                        <uc1:txtDate ID="txtDateTo" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    &nbsp;
                                </td>
                                <td align="left" class="style1">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <center>
                                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnSearch" runat="server" CausesValidation="False" Text="Search" />&nbsp;
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </center>
    <br />
    <center>
        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblError" runat="server" Width="400" CssClass="errorBox" Visible="false" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
    <asp:UpdatePanel ID="UpdatePanel15" runat="server">
        <ContentTemplate>
            <asp:Repeater ID="rptTsDetailListWaitingForApprv" runat="server">
                <HeaderTemplate>
                    <table align="center" class="dataTable" width="100%" border="1">
                        <tr>
                            <td colspan="9" align="center" class="dataTableHeader">
                                Wait For Approval
                            </td>
                        </tr>
                        <tr align="center" class="dataTableSubHeader">
                            <td>
                                No.
                            </td>
                            <td>
                                Project
                            </td>
                            <td>
                                Billing
                            </td>
                            <td>
                                Staff
                            </td>
                            <td>
                                Date
                            </td>
                            <td>
                                Time
                            </td>
                            <td>
                                Phase
                            </td>
                            <td>
                                Task Detail
                            </td>
                            <td>
                                #
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr align="center" class="dataTableCell">
                        <td>
                            <%#Container.ItemIndex + 1%>
                        </td>
                        <td>
                            <%#Container.DataItem("project_name")%>
                        </td>
                        <td align="left">
                            <%#Container.DataItem("billing_name")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("Staff")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("TSDate")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("TSTime")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("phase")%>
                        </td>
                        <td align="left" style="word-wrap: break-word; width: 200px" valign="top">
                            <%-- <%#Replace(Replace(Container.DataItem("timesheet_detail"), vbNewLine, "<br>"), " ", "&nbsp;")%>--%>
                            <%#Container.DataItem("timesheet_detail")%>
                        </td>
                        <td align="center">
                            <asp:Button ID="btnView" CausesValidation="false" Text="  View  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="ViewTS" />
                            <asp:Label ID="lbltimesheet_status" runat="server" Text='<%#container.dataitem("timesheet_status") %>'
                                Visible="false"></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr align="center" class="dataTableCell">
                        <td>
                            <%#Container.ItemIndex + 1%>
                        </td>
                        <td>
                            <%#Container.DataItem("project_name")%>
                        </td>
                        <td align="left">
                            <%#Container.DataItem("billing_name")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("Staff")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("TSDate")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("TSTime")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("phase")%>
                        </td>
                        <td align="left" style="word-wrap: break-word; width: 200px" valign="top">
                            <%#Container.DataItem("timesheet_detail")%>
                        </td>
                        <td align="center">
                            <asp:Button ID="btnView" CausesValidation="false" Text="  View  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="ViewTS" />
                            <asp:Label ID="lbltimesheet_status" runat="server" Text='<%#container.dataitem("timesheet_status") %>'
                                Visible="false"></asp:Label>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    <tr align="center" class="dataTableSubHeader">
                    </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <asp:Repeater ID="rptTsDetailListApprvByPM" runat="server">
                <HeaderTemplate>
                    <table align="center" class="dataTable" width="100%" border="1">
                        <tr>
                            <td colspan="9" align="center" class="dataTableHeader">
                                Approve By PM
                            </td>
                        </tr>
                        <tr align="center" class="dataTableSubHeader">
                            <td>
                                No.
                            </td>
                            <td>
                                Project
                            </td>
                            <td>
                                Billing
                            </td>
                            <td>
                                Staff
                            </td>
                            <td>
                                Date
                            </td>
                            <td>
                                Time
                            </td>
                            <td>
                                Phase
                            </td>
                            <td>
                                Task Detail
                            </td>
                            <td>
                                #
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr align="center" class="dataTableCell">
                        <td>
                            <%#Container.ItemIndex + 1%>
                        </td>
                        <td>
                            <%#Container.DataItem("project_name")%>
                        </td>
                        <td align="left">
                            <%#Container.DataItem("billing_name")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("Staff")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("TSDate")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("TSTime")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("phase")%>
                        </td>
                        <td align="left" style="word-wrap: break-word; width: 200px" valign="top">
                            <%-- <%#Replace(Replace(Container.DataItem("timesheet_detail"), vbNewLine, "<br>"), " ", "&nbsp;")%>--%>
                            <%#Container.DataItem("timesheet_detail")%>
                        </td>
                        <td align="center">
                            <asp:Button ID="btnView" CausesValidation="false" Text="  View  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="ViewTS" />
                            <asp:Label ID="lbltimesheet_status" runat="server" Text='<%#container.dataitem("timesheet_status") %>'
                                Visible="false"></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr align="center" class="dataTableCell">
                        <td>
                            <%#Container.ItemIndex + 1%>
                        </td>
                        <td>
                            <%#Container.DataItem("project_name")%>
                        </td>
                        <td align="left">
                            <%#Container.DataItem("billing_name")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("Staff")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("TSDate")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("TSTime")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("phase")%>
                        </td>
                        <td align="left" style="word-wrap: break-word; width: 200px" valign="top">
                            <%#Container.DataItem("timesheet_detail")%>
                        </td>
                        <td align="center">
                            <asp:Button ID="btnView" CausesValidation="false" Text="  View  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="ViewTS" />
                            <asp:Label ID="lbltimesheet_status" runat="server" Text='<%#container.dataitem("timesheet_status") %>'
                                Visible="false"></asp:Label>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    <tr align="center" class="dataTableSubHeader">
                    </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
