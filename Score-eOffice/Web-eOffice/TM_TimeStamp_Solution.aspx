<%@ Page Language="VB" MasterPageFile="~/MasterPage_Basic.master" AutoEventWireup="false"
    CodeFile="TM_TimeStamp_Solution.aspx.vb" Inherits="TM_TimeStamp_solution" %>

<%@ Register Src="UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc1" %>
<%@ Register Src="UserControls/txtTime.ascx" TagName="txtTime" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <script type="text/javascript" src="__js/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="__js/jquery-ui.js"></script>
    <link href="__css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script>
        $(function() {
            $("#tabs").tabs();
        });
    </script>


    <center>
        <table width="500" border="1" align="center" cellpadding="0" class="dataTable">
            <tr>
                <td align="center" class="dataTableHeader">
                    Manhour
                </td>
            </tr>
            <tr>
                <td class="dataTableCell">
                    <table align="center">
                        <tr>
                            <td align="left">
                                Account:
                            </td>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlAccount" runat="server" Width="150px" DataTextField="Account_name"
                                            DataValueField="id" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 111px" align="left">
                                Project:
                            </td>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlProject" runat="server" Width="150px" DataTextField="project_name"
                                            DataValueField="id" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 111px" align="left">
                                Billing Name:
                            </td>
                            <td align="left" style="width: 159px">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlBillingName" runat="server" Width="150px" DataTextField="billing_name"
                                            DataValueField="id">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" >Phase:</td>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButton ID="rdiPhaseSale" runat="server" Text="&nbsp;Sale" GroupName="ProjectPhase" AutoPostBack="true" />
                                        <asp:RadioButton ID="rdiPhaseDevelop" runat="server" Text="&nbsp;Develop" GroupName="ProjectPhase" AutoPostBack="true" />
                                        <asp:RadioButton ID="rdiPhaseDeploy" runat="server" Text="&nbsp;Deploy" GroupName="ProjectPhase" AutoPostBack="true" />
                                        <asp:RadioButton ID="rdiPhaseSupport" runat="server" Text="&nbsp;Support" GroupName="ProjectPhase" AutoPostBack="true" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td  align="left">
                                Date:
                            </td>
                            <td align="left" style="width: 159px">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <uc1:txtDate ID="txtDate" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Start Time:
                            </td>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <uc2:txtTime ID="txtStartTime" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                End Time:
                            </td>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <uc2:txtTime ID="txtEndTime" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Description:
                            </td>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtDescription" runat="server" MaxLength="300" Rows="5" TextMode="MultiLine"
                                            Width="320px" ToolTip="Max 300 ตัวอักษร"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr><td colspan="2">&nbsp;</td></tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
    <center>
        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblID" runat="server" Visible="False">0</asp:Label><br />
                <asp:Label ID="lblError" runat="server" Visible="false" Width="400" CssClass="errorBox" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
    <center>
        <br />
        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="buttonCreate" Width="49px" />
                &nbsp;<asp:Button ID="btnCancle" Text="Cancle" runat="server" CssClass="buttonNormal" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
    </center>
    
    <div id="tabs">
        <ul>
            <li><a href="#tabsSearch">Search Manhours</a></li>
        </ul>
        <div id="tabsSearch">
            <center>
                <table>
                    <tr>
                        <td>User:</td>
                        <td colspan="4">
                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlSearchUser" runat="server" DataTextField="staff_name" DataValueField="id" 
                                    Enabled="false" Width="250px" >
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>Project:</td>
                        <td colspan="4">
                            <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlSearchProject" runat="server" DataTextField="project_code" DataValueField="id" 
                                    Width="250px" AutoPostBack="true" >
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>Billing Name:</td>
                        <td colspan="4">
                            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlSearchBilling" runat="server" DataTextField="billing_name" DataValueField="id" 
                                    Width="250px" >
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>Month:</td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlMonth" runat="server" DataTextField="Month" DataValueField="No">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblYear" Text="Year:"></asp:Label>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlYear" runat="server" DataTextField="Year" DataValueField="No">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="ButView" runat="server" Text="View" /><br />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:Repeater ID="rptShowManhour" runat="server">
                            <HeaderTemplate>
                                <table align="center" class="dataTable" width="1000px" border="1" >
                                    <tr>
                                        <td colspan="9" align="center" class="dataTableHeader">
                                            Manhour List
                                        </td>
                                    </tr>
                                    <tr align="center" class="dataTableSubHeader">
                                        <td style="width:30px">No.</td>
                                        <td>User</td>
                                        <td>Account</td>
                                        <td>Project</td>
                                        <td>Billing Name</td>
                                        <td style="width:80px">Start Time</td>
                                        <td style="width:80px">End Time</td>
                                        <td>Description</td>
                                        <td style="width:120px">Edit/Delete</td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr align="center" class="dataTableCell">
                                    <td align="center" valign="top">
                                        <%#Container.ItemIndex + 1%>
                                    </td>
                                    <td align="left" valign="top">
                                        <%#Container.DataItem("staff_name")%>
                                    </td>
                                    <td align="left" valign="top">
                                        <%#Container.DataItem("account_name")%>
                                    </td>
                                    <td align="left" valign="top">
                                        <%#Container.DataItem("project_name")%>
                                    </td>
                                    <td align="left" valign="top">
                                        <%#Container.DataItem("billing_name")%>
                                    </td>
                                    <td valign="top" align="center">
                                        <%#Container.DataItem("start_date_time")%>
                                    </td>
                                    <td valign="top" align="center">
                                        <%#Container.DataItem("end_date_time")%>
                                    </td>
                                    <td align="left" style="word-wrap: break-word; width: 200px" valign="top">
                                        <%#Container.DataItem("manhour_desc")%>
                                    </td>
                                    <td align="center" valign="top">
                                        <asp:Button CssClass="buttonNormal" ID="btnEdit" Text="Edit" runat="server" CommandArgument='<%#container.dataitem("id") %>'
                                            CommandName="Edit" />&nbsp;<asp:Button CssClass="buttonCritical" ID="btnDelete" Text="Delete"
                                                runat="server" CommandArgument='<%#container.dataitem("id") %>' CommandName="Delete"
                                                OnClientClick="return confirm('Are you sure you want to delete?');" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr align="center" class="altdataTableCell">
                                    <td align="center" valign="top">
                                        <%#Container.ItemIndex + 1%>
                                    </td>
                                    <td align="left" valign="top">
                                        <%#Container.DataItem("staff_name")%>
                                    </td>
                                    <td align="left" valign="top">
                                        <%#Container.DataItem("account_name")%>
                                    </td>
                                    <td align="left" valign="top">
                                        <%#Container.DataItem("project_name")%>
                                    </td>
                                    <td align="left" valign="top">
                                        <%#Container.DataItem("billing_name")%>
                                    </td>
                                    <td align="left" valign="top">
                                        <%#Container.DataItem("start_date_time")%>
                                    </td>
                                    <td align="left" valign="top">
                                        <%#Container.DataItem("end_date_time")%>
                                    </td>
                                    <td align="left" style="word-wrap: break-word; width: 200px" valign="top">
                                        <%#Container.DataItem("manhour_desc")%>
                                    </td>
                                    <td align="center" valign="top" valign="top">
                                        <asp:Button CssClass="buttonNormal" ID="btnEdit" Text="Edit" runat="server" CommandArgument='<%#container.dataitem("id") %>'
                                            CommandName="Edit" />&nbsp;<asp:Button CssClass="buttonCritical" ID="btnDelete" Text="Delete"
                                                runat="server" CommandArgument='<%#container.dataitem("id") %>' CommandName="Delete"
                                                OnClientClick="return confirm('Are you sure you want to delete?');" />
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <table>
                    <br />
                </table>
                <br />
                <table>
                </table>
                <iframe width="174" height="189" name="gToday:normal:agenda.js:::utf-8" id="gToday:normal:agenda.js:::utf-8"
                    src="__js/Calendar/normal/ipopeng.htm" scrolling="no" frameborder="0" style="visibility: visible;
                    z-index: 999; position: absolute; top: -500px; left: -500px;"></iframe>
            </center>
        </div>
    </div>
    
</asp:Content>
