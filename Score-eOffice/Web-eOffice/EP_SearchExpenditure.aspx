<%@ Page Language="VB" MasterPageFile="~/MasterPage_Basic.master" AutoEventWireup="false"
    CodeFile="EP_SearchExpenditure.aspx.vb" Inherits="EP_SearchExpenditure" Title="Untitled Page" %>

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
                        Search Expenditure
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
                                            <asp:DropDownList ID="ddlProject" runat="server" Width="200px" DataTextField="project_code"
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
                                    &nbsp;</td>
                                <td style="width: 111px" align="left">
                                    Date :
                                </td>
                                <td align="left" class="style1">
                                    <table cellspacing="0" cellpadding="0" >
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
                                    Status :
                                </td>
                                <td align="left" class="style1">
                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                        <ContentTemplate>
                                            <asp:CheckBoxList ID="chkStatus" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" >
                                                <asp:ListItem Value="0">Entered</asp:ListItem>
                                                <asp:ListItem Value="1">Wait for Approval</asp:ListItem>
                                                <asp:ListItem Value="2">Approve by PM</asp:ListItem>
                                                <asp:ListItem Value="3">Reject By PM</asp:ListItem>
                                                <asp:ListItem Value="4">Wait for Clear Bill</asp:ListItem>
                                                <asp:ListItem Value="5">Reject By Costcontroller</asp:ListItem>
                                                <asp:ListItem Value="6">Finish</asp:ListItem>
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
                <asp:Label ID="lblError" runat="server" Width="400" CssClass="errorBox" Visible="false" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
    <asp:UpdatePanel ID="UpdatePanel15" runat="server">
        <ContentTemplate>
            <asp:Repeater ID="rptTsDetailList" runat="server">
                <HeaderTemplate>
                    <table align="center" class="dataTable" width="100%" border="1">
                        <tr>
                            <td colspan="10" align="center" class="dataTableHeader">
                                Expenditure List
                            </td>
                        </tr>
                        <tr align="center" class="dataTableSubHeader">
                            <td>
                                No.
                            </td>
                            <td>
                                Request ID
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
                                Expense Type
                            </td>
                            <td>
                                Total Amount
                            </td>
                            <td>
                                Attatchment
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
                        <td>
                            <%#Container.DataItem("request_id")%>
                        </td>
                        <td align="left">
                            <%#Container.DataItem("project_name")%>
                        </td>
                        <td align="left">
                            <%#Container.DataItem("billing_name")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("request_date")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("expense_type_desc")%>
                        </td>
                        <td align="right">
                            <%#Format(Container.DataItem("total_amt"), "#,##0.00")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("attatchment")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("expenditure_status_name")%>
                        </td>
                        <td align="left">
                            <asp:Button CssClass="buttonCreate" ID="btnSelect" CausesValidation="false" Text="  Edit  "
                                runat="server" CommandArgument='<%#container.dataitem("Id") %>' CommandName="EditEP" Width="60px"/>
                            <asp:Button ID="btnSend" CausesValidation="false" Text="  Send  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="SendEP" Width="60px"/>
                            <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CssClass="butDelete"
                                Text="Delete" CommandArgument='<%#container.dataitem("Id") %>' Width="60px" CommandName="DeleteEP" OnClientClick="return confirm('Are you sure you want to delete?');"/>
                            <asp:Button ID="btnView" CausesValidation="false" Text="  View  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="ViewEP" Width="60px"/>
                            <asp:Label ID="lblExpenditureStatus" runat="server" Text='<%#container.dataitem("expenditure_status") %>'
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
                            <%#Container.DataItem("request_id")%>
                        </td>
                        <td align="left">
                            <%#Container.DataItem("project_name")%>
                        </td>
                        <td align="left">
                            <%#Container.DataItem("billing_name")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("request_date")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("expense_type_desc")%>
                        </td>
                        <td align="right">
                            <%#Format(Container.DataItem("total_amt"), "#,##0.00")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("attatchment")%>
                        </td>
                        <td align="center">
                            <%#Container.DataItem("expenditure_status_name")%>
                        </td>
                        <td align="left">
                            <asp:Button CssClass="buttonCreate" ID="btnSelect" CausesValidation="false" Text="  Edit  "
                                runat="server" CommandArgument='<%#container.dataitem("Id") %>' CommandName="EditEP" Width="60px"/>
                            <asp:Button ID="btnSend" CausesValidation="false" Text="  Send  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="SendEP" Width="60px"/>
                            <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CssClass="butDelete"
                                Text="Delete" CommandArgument='<%#container.dataitem("Id") %>' Width="60px" CommandName="DeleteEP" OnClientClick="return confirm('Are you sure you want to delete?');"/>
                            <asp:Button ID="btnView" CausesValidation="false" Text="  View  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="ViewEP" Width="60px"/>
                            <asp:Label ID="lblExpenditureStatus" runat="server" Text='<%#container.dataitem("expenditure_status") %>'
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
