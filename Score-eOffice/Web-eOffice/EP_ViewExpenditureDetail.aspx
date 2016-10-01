<%@ Page Language="VB" MasterPageFile="~/MasterPage_Basic.master" AutoEventWireup="false"
    CodeFile="EP_ViewExpenditureDetail.aspx.vb" Inherits="EP_ViewExpenditureDetail" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 191px;
            height: 15px;
        }
        .style2
        {
            height: 15px;
        }
        .style3
        {
            width: 191px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <table border="0" cellpadding="5" cellspacing="1" width="100%">
        <tr>
            <td align="left" colspan="4" bgcolor="#cccccc">
                <strong>Expenditure</strong>
            </td>
        </tr>
        <tr>
            <td>
                <table id="Table3" bgcolor="#cccccc" border="0" cellpadding="0" cellspacing="1" width="600px">
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" style="width: 20%">Request ID :</td>
                        <td align="left" bgcolor="#ffffff" style="width: 50%">
                            <asp:Label ID="lblRequestID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" valign="top" style="width: 15%">Project Name :</td>
                        <td align="left" bgcolor="#ffffff" valign="middle" style="width: 15%">
                            <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" >Project Billing Name :</td>
                        <td align="left" bgcolor="#ffffff" >
                            <asp:Label ID="lblProjectBillingName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" valign="top" >Date :</td>
                        <td align="left" bgcolor="#ffffff" valign="middle" >
                            <asp:Label ID="lblRequestDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" >Expense Type :</td>
                        <td align="left" bgcolor="#ffffff" >
                            <asp:Label ID="lblExpenseType" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" >Expenditure Status :</td>
                        <td align="left" bgcolor="#ffffff" >
                            <asp:Label ID="lblExpenditureStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;
                            <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblStatus" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4" bgcolor="#cccccc">
                <strong>List Item</strong>
            </td>
        </tr>
        <tr>
            <td>
                <table id="Table2" bgcolor="#cccccc" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" >
                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                <ContentTemplate>
                                    <asp:Repeater ID="rptItem" runat="server">
                                        <HeaderTemplate>
                                            <table align="center" class="dataTable" width="100%" border="1">
                                                <tr align="center" class="dataTableSubHeader">
                                                    <td style="width:50px">
                                                        No.
                                                    </td>
                                                    <td style="width:150px">
                                                        Type
                                                    </td>
                                                    <td>
                                                        Description
                                                    </td>
                                                    <td style="width:80px">
                                                        Invoice Date
                                                    </td>
                                                    <td style="width:80px">
                                                        Amount
                                                    </td>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr align="center" class="dataTableCell">
                                                <td>
                                                    <%#Container.ItemIndex + 1%>
                                                </td>
                                                <td>
                                                    <%#Container.DataItem("expense_item_type_desc")%>
                                                </td>
                                                
                                                <td align="left">
                                                    <asp:Label ID="Label9" runat="server" Text='<%#Container.DataItem("item_desc")%>'  Width="200px"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <%#Convert.ToDateTime(Container.DataItem("item_invoice_date")).ToString("dd/MM/yyyy", New Globalization.CultureInfo("en-US"))%>
                                                </td>
                                                <td align="right">
                                                    <%#Format(Container.DataItem("item_amt"), "#,##0.00")%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr align="center" class="dataTableCell">
                                                <td>
                                                    <%#Container.ItemIndex + 1%>
                                                </td>
                                                <td>
                                                    <%#Container.DataItem("expense_item_type_desc")%>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label9" runat="server" Text='<%#Container.DataItem("item_desc")%>'  Width="200px"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <%#Convert.ToDateTime(Container.DataItem("item_invoice_date")).ToString("dd/MM/yyyy", New Globalization.CultureInfo("en-US"))%>
                                                </td>
                                                <td align="right">
                                                    <%#Format(Container.DataItem("item_amt"), "#,##0.00")%>
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                        <FooterTemplate>
                                            <tr align="center" class="dataTableSubHeader">
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>รวมเป็นเงิน</td>
                                                <td>&nbsp;</td>
                                                <td align="right">
                                                    <asp:Label ID="lblTotalAmt" runat="server" ></asp:Label>
                                                </td>
                                            </tr>
                                         </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        
        
        <tr>
            <td align="left" colspan="4" bgcolor="#cccccc">
                <strong>Attach File</strong>
            </td>
        </tr>
        <tr>
            <td>
                <table id="Table1" bgcolor="#cccccc" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" >
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Repeater ID="rptAttachFile" runat="server">
                                        <HeaderTemplate>
                                            <table align="center" class="dataTable" width="100%" border="1">
                                                <tr align="center" class="dataTableSubHeader">
                                                    <td style="width:50px">
                                                        No.
                                                    </td>
                                                    <td>
                                                        File
                                                    </td>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr align="center" class="dataTableCell">
                                                <td>
                                                    <%#Container.ItemIndex + 1%>
                                                </td>
                                                <td align="left" >
                                                    <%#Container.DataItem("file_name")%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr align="center" class="dataTableCell">
                                                <td>
                                                    <%#Container.ItemIndex + 1%>
                                                </td>
                                                <td align="left" >
                                                    <%#Container.DataItem("file_name")%>
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
                        </td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                
                <asp:Panel ID="pnlComment" runat="server">
                    <table id="Table7" bgcolor="#cccccc" border="0" cellpadding="5" cellspacing="1" width="100%">
                        <tr>
                            <td align="left" bgcolor="#e9e9e9" style="width: 80%">
                                Comment :
                            </td>
                            <td bgcolor="#e9e9e9">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" bgcolor="#e9e9e9" >
                                <asp:TextBox ID="txtApproveText" runat="server" Width="98%" MaxLength="200"></asp:TextBox>
                            </td>
                            <td bgcolor="#e9e9e9">
                                <asp:Button ID="butApprove" runat="server" CssClass="buttonCreate" Text="Approve"
                                    Width="56px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" bgcolor="#e9e9e9" >
                                <asp:TextBox ID="txtRejectText" runat="server" Width="98%" MaxLength="200"></asp:TextBox>
                            </td>
                            <td bgcolor="#e9e9e9">
                                <asp:Button ID="btnReject" runat="server" CssClass="butDelete" Text="Reject" Width="56px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

            </td>
        </tr>
        <tr>
            <td>
                <center>
                    <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblError" runat="server" Width="400" CssClass="errorBox" Visible="false" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </center>
            </td>
        </tr>
    </table>
</asp:Content>
