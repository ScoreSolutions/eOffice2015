<%@ Page Language="VB" MasterPageFile="~/MasterPage_Basic.master" AutoEventWireup="false"
    CodeFile="ET_ViewTimeSheetDetail.aspx.vb" Inherits="ET_ViewTimeSheetDetail" Title="Untitled Page" %>

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
                <strong>Time Sheet Document No :</strong>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table id="Table3" bgcolor="#cccccc" border="0" cellpadding="5" cellspacing="1" width="100%">
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                            Name :</td>
                        <td align="left" bgcolor="#ffffff" width="244">
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                        <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                            Account :</td>
                        <td align="left" bgcolor="#ffffff" valign="middle" style="width: 304px">
                            <asp:Label ID="lblAccount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                            Department :</td>
                        <td align="left" bgcolor="#ffffff" width="244">
                            <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                        </td>
                        <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                            Contact Person :</td>
                        <td align="left" bgcolor="#ffffff" valign="middle" style="width: 304px">
                            <asp:Label ID="lblContactPerson" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                            Position :</td>
                        <td align="left" bgcolor="#ffffff" width="244">
                            <asp:Label ID="lblPosition" runat="server"></asp:Label>
                        </td>
                        <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                            Contact Mobile :</td>
                        <td align="left" bgcolor="#ffffff" valign="middle" style="width: 304px">
                            <asp:Label ID="lblContactMobile" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                            Project Name :</td>
                        <td align="left" bgcolor="#ffffff" width="244">
                            <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                        </td>
                        <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                            Location :</td>
                        <td align="left" bgcolor="#ffffff" valign="middle" style="width: 304px">
                            <asp:Label ID="lblLocation" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                            Billing Name :</td>
                        <td align="left" bgcolor="#ffffff" width="244">
                            <asp:Label ID="lblBillingName" runat="server"></asp:Label>
                        </td>
                        <td align="left" bgcolor="#e9e9e9" >
                            E Timesheet Status :</td>
                        <td align="left" bgcolor="#ffffff" >
                            <asp:Label ID="lblETimeSheetStatusName" runat="server"></asp:Label>
                            <asp:Label ID="lblETimeSheetStatus" runat="server" Visible="false" ></asp:Label>
                            <asp:Label ID="lblID" runat="server" Visible="false" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                            Project Manager :</td>
                        <td align="left" bgcolor="#ffffff" width="244">
                <asp:Label ID="lblProjectManager" runat="server"></asp:Label>
                        </td>
                        <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                            &nbsp;</td>
                        <td align="left" bgcolor="#ffffff" valign="middle" style="width: 304px">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table id="Table1" bgcolor="#cccccc" border="0" cellpadding="5" cellspacing="1" width="100%">
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                            Working Date :</td>
                        <td align="left" bgcolor="#ffffff" width="244">
                <asp:Label ID="lblWorkingDate" runat="server"></asp:Label>
                        </td>
                        <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                            User Signature :</td>
                        <td align="left" bgcolor="#ffffff" valign="middle" style="width: 304px">
                <asp:Label ID="lblUserSignature" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                            &nbsp;
                        </td>
                        <td align="left" bgcolor="#ffffff" width="244">
                            &nbsp;
                        </td>
                        <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                            &nbsp;
                        </td>
                        <td align="left" bgcolor="#ffffff" valign="middle" style="width: 304px">
                            &nbsp;
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td>
                <table id="Table2" bgcolor="#cccccc" border="0" cellpadding="5" cellspacing="1" width="100%">
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" >
                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                <ContentTemplate>
                                    <asp:Repeater ID="rptDetail1" runat="server">
                                        <HeaderTemplate>
                                            <table align="center" class="dataTable" width="100%" border="1">
                                                <tr>
                                                   <%-- <td colspan="8" align="center" class="dataTableHeader">
                                                        Tasks Detail Lists
                                                    </td>--%>
                                                </tr>
                                                <tr align="center" class="dataTableSubHeader">
                                                   <%-- <td>
                                                        No.
                                                    </td>--%>
                                                    <td>
                                                        Time
                                                    </td>
                                                    <td>
                                                        Phase
                                                    </td>
                                                    <td>
                                                        Task Detail
                                                    </td>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr align="center" class="dataTableCell">
                                                <%--<td>
                                                    <%#Container.ItemIndex + 1%>
                                                </td>--%>
                                                <td>
                                                    <%#Container.DataItem("Start_Time")%> - <%#Container.DataItem("End_Time")%>
                                                </td>
                                                <td align="left">
                                                    <%#Container.DataItem("Phase")%>
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="Label9" runat="server" Text='<%#Container.DataItem("timesheet_detail")%>'  Width="200px"></asp:Label>
                                                </td>
                                                
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr align="center" class="dataTableCell">
                                                <%--<td>
                                                    <%#Container.ItemIndex + 1%>
                                                </td>--%>
                                                 <td>
                                                    <%#Container.DataItem("Start_Time")%> - <%#Container.DataItem("End_Time")%>
                                                </td>
                                                <td align="left">
                                                    <%#Container.DataItem("Phase")%>
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="Label9" runat="server" Text='<%#Container.DataItem("timesheet_detail")%>'  Width="200px"></asp:Label>
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
                <table id="Table4" bgcolor="#cccccc" border="0" cellpadding="5" cellspacing="1" width="100%">
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                            Authorized By :</td>
                        <td align="left" bgcolor="#ffffff" width="244">
                           
                <asp:Label ID="lblAuthorizedBy" runat="server"></asp:Label>
                           
                        </td>
                         <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                            &nbsp;
                        </td>
                        <td align="left" bgcolor="#ffffff" valign="middle" style="width: 304px">
                            &nbsp;
                        </td>
                    </tr>
                    
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table id="Table5" bgcolor="#cccccc" border="0" cellpadding="5" cellspacing="1" width="100%">
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                            Note/Remark :</td>
                        <td align="left" bgcolor="#ffffff"  width="244">
                           
                <asp:Label ID="lblRemark" runat="server"></asp:Label>
                           
                        </td>
                         <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                            &nbsp;
                        </td>
                        <td align="left" bgcolor="#ffffff" valign="middle" style="width: 304px">
                            &nbsp;
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td>
                <table id="Table6" bgcolor="#cccccc" border="0" cellpadding="5" cellspacing="1" width="100%">
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                            Office User Only</td>
                        <td align="left" bgcolor="#ffffff" width="244">
                            &nbsp;
                        </td>
                        <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                            &nbsp;
                        </td>
                        <td align="left" bgcolor="#ffffff" valign="middle" style="width: 304px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                            &nbsp;
                            Approved By :</td>
                        <td align="left" bgcolor="#ffffff" width="244">
                <asp:Label ID="lblApprovedBy" runat="server"></asp:Label>
                        </td>
                        <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                            &nbsp;
                        </td>
                        <td align="left" bgcolor="#ffffff" valign="middle" style="width: 304px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                            &nbsp;
                            Prepared By :</td>
                        <td align="left" bgcolor="#ffffff" width="244">
                <asp:Label ID="lblPreparedBy" runat="server"></asp:Label>
                        </td>
                        <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                            &nbsp;
                        </td>
                        <td align="left" bgcolor="#ffffff" valign="middle" style="width: 304px">
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
                            <td align="left" bgcolor="#e9e9e9" style="width: 80px">
                                Comment :
                            </td>
                            <td bgcolor="#e9e9e9">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" bgcolor="#e9e9e9" style="width: 80px">
                                <asp:TextBox ID="txtApproveText" runat="server" Width="577px" MaxLength="200"></asp:TextBox>
                            </td>
                            <td bgcolor="#e9e9e9">
                                <asp:Button ID="butApprove" runat="server" CssClass="buttonCreate" Text="Approve"
                                    Width="56px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" bgcolor="#e9e9e9" style="width: 80px">
                                <asp:TextBox ID="txtRejectText" runat="server" Width="577px" MaxLength="200"></asp:TextBox>
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
                <table id="Table8" bgcolor="#cccccc" border="0" cellpadding="5" cellspacing="1" 
                    width="100%">
                    <tr>
                        <td align="left" bgcolor="#e9e9e9" >
                            <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                <ContentTemplate>
                                    <asp:Repeater ID="rptDetail2" runat="server">
                                        <HeaderTemplate>
                                            <table align="center" class="dataTable" width="100%" border="1">
                                                <tr>
                                                    <td colspan="8" align="center" class="dataTableHeader">
                                                        Status Tracking
                                                    </td>
                                                </tr>
                                                <tr align="center" class="dataTableSubHeader">
                                                   <%-- <td>
                                                        No.
                                                    </td>--%>
                                                    <td>
                                                        Date
                                                    </td>
                                                    <td>
                                                        Action By
                                                    </td>
                                                    <td>
                                                        Status
                                                    </td>
                                                    <td>
                                                        Comment
                                                    </td>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr align="center" class="dataTableCell">
                                                <%--<td>
                                                    <%#Container.ItemIndex + 1%>
                                                </td>--%>
                                                <td>
                                                    <%#Container.DataItem("LogDate")%>
                                                </td>
                                                <td align="left">
                                                    <%#Container.DataItem("name")%>
                                                </td>
                                                <td align="center">
                                                    <%#Container.DataItem("Status")%>
                                                </td>
                                                <td align="center">
                                                    <%#Container.DataItem("Status_Comment")%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr align="center" class="dataTableCell">
                                                <%--<td>
                                                    <%#Container.ItemIndex + 1%>
                                                </td>--%>
                                                <td>
                                                    <%#Container.DataItem("LogDate")%>
                                                </td>
                                                <td align="left">
                                                    <%#Container.DataItem("name")%>
                                                </td>
                                                <td align="center">
                                                    <%#Container.DataItem("Status")%>
                                                </td>
                                                <td align="center">
                                                    <%#Container.DataItem("Status_Comment")%>
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
                </table>
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
