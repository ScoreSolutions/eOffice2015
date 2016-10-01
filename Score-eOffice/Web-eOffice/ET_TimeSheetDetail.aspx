<%@ Page Language="VB" MasterPageFile="~/MasterPage_Basic.master" AutoEventWireup="false"
    CodeFile="ET_TimeSheetDetail.aspx.vb" Inherits="_ET_TimeSheetDetail"%>
    
<%@ Register Src="UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc1" %>
<%@ Register Src="UserControls/txtTime.ascx" TagName="txtTime" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <table id="Table3" bgcolor="#cccccc" border="0" cellpadding="5" cellspacing="1" width="100%">
        <tr>
            <td align="left" style="width: 196px">
                <strong>Project Detail</strong>
            </td>
            <td align="left" width="244">
                &nbsp;&nbsp;
            </td>
            <td align="right" valign="top" width="130">
                &nbsp;
            </td>
            <td align="left" valign="top" style="width: 304px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                Project Name :
            </td>
            <td align="left" bgcolor="#ffffff" width="244">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlProject" runat="server" Width="200px" DataTextField="project_name"
                            DataValueField="id" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                Project Billing No :
            </td>
            <td align="left" bgcolor="#ffffff" valign="middle" style="width: 304px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlBillingName" runat="server" Width="200px" DataTextField="Billing_Name"
                            DataValueField="Id">
                        </asp:DropDownList>
                         <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                Select Location :
            </td>
            <td align="left" bgcolor="#ffffff" width="244">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlLocation" runat="server" Width="200px" DataTextField="Branch_Name"
                            DataValueField="Id">
                        </asp:DropDownList>
                         <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                Contact Person :
            </td>
            <td align="left" bgcolor="#ffffff" valign="top" style="width: 304px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtContactPerson" runat="server" Width="200px" MaxLength="200"></asp:TextBox>
                         <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                Project Manager :
            </td>
            <td align="left" bgcolor="#ffffff" width="244">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblProjectManager" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                Contact Mobile:
            </td>
            <td align="left" bgcolor="#ffffff" valign="top" style="width: 304px">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtContactMobile" runat="server" Width="200px" MaxLength="10"></asp:TextBox>
                         <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="left" bgcolor="#e9e9e9" valign="top" style="width: 196px">
                &nbsp;
            </td>
            <td align="left" bgcolor="#ffffff" valign="top" width="244">
                &nbsp;
            </td>
            <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                &nbsp;
            </td>
            <td align="left" bgcolor="#ffffff" valign="top" style="width: 304px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 30px; background-color: white; width: 196px;">
            </td>
            <td align="left" colspan="3" style="height: 30px; background-color: white;">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblID" runat="server" Visible="false">0</asp:Label>
                        <asp:Label ID="lblPmUserID" runat="server" Visible="false">0</asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 196px;">
                <strong>Task Details :</strong>&nbsp;
            </td>
            <td align="left" colspan="3">
            </td>
        </tr>
        <tr>
            <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                Working Date :
            </td>
            <td align="left" bgcolor="#ffffff" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                         <table cellpadding=0 cellspacing=0>
                             <tr>
                                 <td>
                                 <uc1:txtDate ID="txtDate" runat="server" />
                                 </td>
                                 <td>
                                 <asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                 </td>
                             </tr>
                         </table>
 
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                Working period :
            </td>
            <td align="left" bgcolor="#ffffff" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <uc2:txtTime ID="txtStartTime" runat="server" />
                        &nbsp;To&nbsp;
                        <uc2:txtTime ID="txtEndTime" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                Subject :</td>
            <td align="left" bgcolor="#ffffff" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSubject" runat="server" Width="251px" MaxLength="200"></asp:TextBox>
                         <asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="left" bgcolor="#e9e9e9" style="width: 196px; height: 22px;">
                Phase:
            </td>
            <td align="left" bgcolor="#ffffff" colspan="3" valign="top" style="height: 22px">
               
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <table cellpadding=0 cellspacing=0>
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="rdiPhase" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1" Text="Sale"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Develop"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Deploy"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Support"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                <asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                         
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
        </tr>
        <tr>
            <td align="left" bgcolor="#e9e9e9" valign="top" style="height: 150px; width: 196px;">
                Details :
            </td>
            <td align="left" bgcolor="#ffffff" colspan="3" valign="top" style="height: 150px">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDetail" runat="server" Height="150px" TextMode="MultiLine" Width="504px"
                            BackColor="White"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 196px">
            </td>
            <td align="left" colspan="3" style="padding-left:200px">
            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                <ContentTemplate>
                    <asp:Button ID="butSave" runat="server" CssClass="buttonCreate" Text="Save" Width="51px" />&nbsp;<asp:Button
                        ID="butCancel" runat="server" CausesValidation="False" CssClass="buttonCancel"
                        Text="Cancel" />&nbsp;
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
    </table>
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
                            <td colspan="8" align="center" class="dataTableHeader">
                                Tasks Detail Lists
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
                        <td align="left">
                            <asp:Button CssClass="buttonCreate" ID="btnSelect" CausesValidation="false" Text="  Edit  "
                                runat="server" CommandArgument='<%#container.dataitem("Id") %>'
                                CommandName="SelectTS" Width="60px" />
                            <asp:Button ID="btnSend" CausesValidation="false" Text="  Send  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="SendTS"  Width="60px"/>
                            <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CssClass="butDelete"
                                Text="Delete" CommandArgument='<%#container.dataitem("Id") %>'
                                CommandName="DeleteTS"  Width="60px" OnClientClick="return confirm('Are you sure you want to delete?');" />
                            <asp:Button ID="btnView" CausesValidation="false" Text="  View  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="ViewTS"  Width="60px"/>
                            <asp:Label ID="lbltimesheet_status" runat="server" Text='<%#container.dataitem("timesheet_status") %>'  Visible="false"></asp:Label>
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
                        <td align="left">
                            <asp:Button CssClass="buttonCreate" ID="btnSelect" CausesValidation="false" Text="  Edit  "
                                runat="server" CommandArgument='<%#container.dataitem("Id") %>'
                                CommandName="SelectTS"  Width="60px"/>
                            <asp:Button ID="btnSend" CausesValidation="false" Text="  Send  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="SendTS"  Width="60px"/>
                            <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CssClass="butDelete"
                                Text="Delete" CommandArgument='<%#container.dataitem("Id") %>'
                                CommandName="DeleteTS"  Width="60px" OnClientClick="return confirm('Are you sure you want to delete?');"/>
                            <asp:Button ID="btnView" CausesValidation="false" Text="  View  " runat="server"
                                CommandArgument='<%#container.dataitem("Id") %>' CommandName="ViewTS"  Width="60px"/>
                           <asp:Label ID="lbltimesheet_status" runat="server" Text='<%#container.dataitem("timesheet_status") %>' Visible="false"></asp:Label>
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
