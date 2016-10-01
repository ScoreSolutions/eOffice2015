<%@ Page Language="VB" MasterPageFile="~/MasterPage_Basic.master" AutoEventWireup="false"
    CodeFile="EP_ApproveExpenditure.aspx.vb" Inherits="EP_ApproveExpenditure" Title="Untitled Page" %>

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
                        Approve Expenditure
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
                                    Staff Name :
                                </td>
                                <td align="left" class="style1">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlStaffName" runat="server" Width="200px" DataTextField="staff_name"
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
            <asp:Repeater ID="rptWaitForApproveList" runat="server">
                <HeaderTemplate>
                    <table align="center" class="dataTable" width="100%" border="1">
                        <tr>
                            <td colspan="10" align="center" class="dataTableHeader">
                                Expenditure Wait for Approval
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
                            <td>Staff Name</td>
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
                            <td style="width:80px">
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
                        <td align="left">
                            <%#Container.DataItem("staff_name")%>
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
                        <td align="left"  >
                            <asp:Button ID="btnView" CausesValidation="false" Text="  View  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="ViewEP" Width="60px"/>
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
                        <td align="left">
                            <%#Container.DataItem("staff_name")%>
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
                        <td align="left"  >
                            <asp:Button ID="btnView" CausesValidation="false" Text="  View  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="ViewEP" Width="60px"/>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    <tr align="center" class="dataTableSubHeader">
                    </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            
            <br />
            <br />
            
            
            <asp:Repeater ID="rptApprovedByPM" runat="server">
                <HeaderTemplate>
                    <table align="center" class="dataTable" width="100%" border="1">
                        <tr>
                            <td colspan="10" align="center" class="dataTableHeader">
                                Expenditure Approved by PM
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
                            <td>Staff Name</td>
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
                            <td style="width:80px">
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
                        <td align="left">
                            <%#Container.DataItem("staff_name")%>
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
                        <td align="left"  >
                            <asp:Button ID="btnView" CausesValidation="false" Text="  View  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="ViewEP" Width="60px"/>
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
                        <td align="left">
                            <%#Container.DataItem("staff_name")%>
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
                        <td align="left"  >
                            <asp:Button ID="btnView" CausesValidation="false" Text="  View  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="ViewEP" Width="60px"/>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    <tr align="center" class="dataTableSubHeader">
                    </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            
            <br />
            <br />
            
            <asp:Repeater ID="rptWaitForClearBill" runat="server">
                <HeaderTemplate>
                    <table align="center" class="dataTable" width="100%" border="1">
                        <tr>
                            <td colspan="10" align="center" class="dataTableHeader">
                                Expenditure Wait for Clear Bill
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
                            <td>Staff Name</td>
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
                            <td style="width:80px">
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
                        <td align="left">
                            <%#Container.DataItem("staff_name")%>
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
                        <td align="left"  >
                            <asp:Button ID="btnView" CausesValidation="false" Text="  View  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="ViewEP" Width="60px"/>
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
                        <td align="left">
                            <%#Container.DataItem("staff_name")%>
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
                        <td align="left"  >
                            <asp:Button ID="btnView" CausesValidation="false" Text="  View  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="ViewEP" Width="60px"/>
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
