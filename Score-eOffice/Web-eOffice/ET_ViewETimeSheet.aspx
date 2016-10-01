<%@ Page Language="VB" MasterPageFile="~/MasterPage_Basic.master" AutoEventWireup="false"
    CodeFile="ET_ViewETimeSheet.aspx.vb" Inherits="ET_ViewETimeSheet" Title="Untitled Page" %>

<%@ Register Src="UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 451px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <center>
        <div style="width: 700px;" >
            <table width="700" border="1" align="center" cellpadding="0" class="dataTable">
                <tr>
                    <td align="center" class="dataTableHeader">
                        View eTimeSheet
                    </td>
                </tr>
                <tr>
                    <td class="dataTableCell">
                        <table align="center">
                            <tr>
                                <td align="left">
                                    &nbsp;</td>
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
                                    &nbsp;</td>
                                <td style="width: 111px" align="left">
                                    Project Billing No :
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
                                    &nbsp;</td>
                                <td style="width: 111px" align="left">
                                    Date :
                                </td>
                                <td align="left" class="style1">
                                    <table cellspacing=0 cellpadding=0>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                    <ContentTemplate>
                                                        <uc1:txtDate ID="txtDateFrom" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td>
                                                To
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
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
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">
                                    Phase :
                                </td>
                                <td align="left" class="style1">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <asp:RadioButtonList ID="rdiPhase" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1" Text="Sale"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Develop"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Deploy"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="Support"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">
                                    Status :
                                </td>
                                <td align="left" class="style1">
                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                        <ContentTemplate>
                                            <asp:CheckBoxList ID="chkStatus" runat="server" RepeatColumns="2">
                                                <asp:ListItem Value="0">Entered</asp:ListItem>
                                                <asp:ListItem Value="1">Wait for Approval</asp:ListItem>
                                                <asp:ListItem Value="2">Approve by PM</asp:ListItem>
                                                <asp:ListItem Value="3">Finish</asp:ListItem>
                                                <asp:ListItem Value="4">Reject By PM</asp:ListItem>
                                                <asp:ListItem Value="5">Reject By Costcontroller</asp:ListItem>
                                            </asp:CheckBoxList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    &nbsp;</td>
                                <td align="left" valign="top">
                                    &nbsp;
                                </td>
                                <td align="left" class="style1">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
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
                <asp:Label ID="lblError" runat="server" Width="400" CssClass="errorBox" Visible=false />
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
    <asp:UpdatePanel ID="UpdatePanel15" runat="server">
        <ContentTemplate>
            <asp:Repeater ID="rptTsDetailList" runat="server">
                <HeaderTemplate>
                    <table align="center" class="dataTable" width="100%" border="1">
                        <tr>
                            <td colspan="9" align="center" class="dataTableHeader">
                                eTimeSheet List
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
                                Status
                            </td>
                            <td style="width:200px">
                                #
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr align="center" class="dataTableCell">
                        <td>
                            <%#Container.ItemIndex + 1%>
                        </td>
                        <td align="left">
                            <%#Container.DataItem("project_name")%>
                        </td>
                        <td align="left">
                            <%#Container.DataItem("billing_name")%>
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
                            <asp:Label ID="Label9" runat="server" Text='<%#Container.DataItem("timesheet_detail")%>'  Width="200px"></asp:Label>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("Status")%>
                        </td>
                        <td align="left">
                            <asp:Button CssClass="buttonCreate" ID="btnSelect" CausesValidation="false" Text="  Edit  "
                                runat="server" CommandArgument='<%#container.dataitem("Id") %>' CommandName="SelectTS" Width="60px"/>
                            <asp:Button ID="btnSend" CausesValidation="false" Text="  Send  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="SendTS" Width="60px"/>
                            <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CssClass="butDelete"
                                Text="Delete" CommandArgument='<%#container.dataitem("Id") %>' Width="60px" CommandName="DeleteTS" OnClientClick="return confirm('Are you sure you want to delete?');"/>
                            <asp:Button ID="btnView" CausesValidation="false" Text="  View  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="ViewTS" Width="60px"/>
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
                        <td align="left">
                            <%#Container.DataItem("project_name")%>
                        </td>
                        <td align="left">
                            <%#Container.DataItem("billing_name")%>
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
                            <asp:Label ID="Label9" runat="server" Text='<%#Container.DataItem("timesheet_detail")%>'  Width="200px"></asp:Label>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("Status")%>
                        </td>
                        <td align="left">
                            <asp:Button CssClass="buttonCreate" ID="btnSelect" CausesValidation="false" Text="  Edit  "
                                runat="server" CommandArgument='<%#container.dataitem("Id") %>' CommandName="SelectTS" Width="60px"/>
                            <asp:Button ID="btnSend" CausesValidation="false" Text="  Send  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="SendTS" Width="60px"/>
                            <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CssClass="butDelete"
                                Text="Delete" CommandArgument='<%#container.dataitem("Id") %>' Width="60px" CommandName="DeleteTS" OnClientClick="return confirm('Are you sure you want to delete?');"/>
                            <asp:Button ID="btnView" CausesValidation="false" Text="  View  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="ViewTS" Width="60px"/>
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
