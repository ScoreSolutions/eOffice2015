<%@ Page Title="" Language="VB" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="false" CodeFile="frmIssueList.aspx.vb" Inherits="WebApp_frmIssueList" %>

<%@ Register src="../UserControls/cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc1" %>
<%@ Register src="../UserControls/PageControl.ascx" tagname="PageControl" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../UserControls/txtBox.ascx" tagname="txtBox" tagprefix="uc3" %>
<%@ Register src="../UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc4" %>
<%@ Register src="../UserControls/txtDate2.ascx" tagname="txtDate2" tagprefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<style>
    .divChk
    {
        border-color:Black;
        background-color:White;
        width:150px;height:200px;
        overflow:scroll;
    }
</style>

<table border="0" cellpadding="1" cellspacing="1" align="center" >
    <tr>
        <td align="right">Project : </td>
        <td align="left"><uc1:cmbComboBox ID="cmbProject" runat="server" IsNotNull="false" AutoPosBack="true" Width="220" DefaultDisplay="---Select" /></td>
        <td rowspan="7" valign="top">
            <asp:TextBox ID="txtSortField" runat="server" Visible="False" ></asp:TextBox>
            <asp:TextBox ID="txtSortDir" runat="server" Visible="False" ></asp:TextBox>
            <div class="divChk" >
                <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                    <tr><td>Type :</td></tr>
                    <tr>
                        <td>
                            <asp:CheckBoxList ID="chkType" runat="server" RepeatLayout="Table" RepeatDirection="Vertical" >
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
        <td rowspan="7" valign="top">
            <div class="divChk" >
                <table border="0" cellpadding="0" cellspacing="0" >
                    <tr><td>Status :</td></tr>
                    <tr>
                        <td>
                            <asp:CheckBoxList ID="chkStatus" runat="server" RepeatLayout="Table" RepeatDirection="Vertical" BackColor="White" >
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
        <td rowspan="7" valign="top">
            <div class="divChk" >
                <table border="0" cellpadding="0" cellspacing="0" >
                    <tr><td>Priority :</td></tr>
                    <tr>
                        <td>
                            <asp:CheckBoxList ID="chkPriority" runat="server" RepeatLayout="Table" RepeatDirection="Vertical" BackColor="White" >
                                <asp:ListItem Value="L" Text="Low"></asp:ListItem>
                                <asp:ListItem Value="M" Text="Medium"></asp:ListItem>
                                <asp:ListItem Value="H" Text="Height"></asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                </table>
             </div>
        </td>
        <td rowspan="7" valign="top">
            <div class="divChk" >
                <table border="0" cellpadding="0" cellspacing="0" >
                    <tr><td>State :</td></tr>
                    <tr>
                        <td>
                            <asp:CheckBoxList ID="chkState" runat="server" RepeatLayout="Table" RepeatDirection="Vertical" BackColor="White"  >
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                </table>
             </div>
        </td>
    </tr>
    <tr>
        <td align="right">Module : </td>
        <td align="left"><uc1:cmbComboBox ID="cmbModule" runat="server" IsNotNull="false" AutoPosBack="true" Width="220" DefaultDisplay="---Select" /></td>
    </tr>
    <tr>
        <td align="right">Screen : </td>
        <td><uc1:cmbComboBox ID="cmbScreen" runat="server" IsNotNull="false" Width="220" DefaultDisplay="---Select" /></td>
    </tr>
    <tr>
        <td align="right">Raised On : </td>
        <td>
            <uc4:txtDate ID="txtRaisedOnFrom" runat="server" IsNotNull="false" />&nbsp;- 
            <uc4:txtDate ID="txtRaisedOnTo" runat="server" IsNotNull="false" />
        </td>
    </tr>
    <tr>
        <td align="right">Assign Date : </td>
        <td>
            <uc4:txtDate ID="txtAssignDateFrom" runat="server" IsNotNull="false" />&nbsp;- 
            <uc4:txtDate ID="txtAssignDateTo" runat="server" IsNotNull="false" />
        </td>
    </tr>
    <tr>
        <td align="right">Expected Date : </td>
        <td>
            <uc4:txtDate ID="txtExpectedDateFrom" runat="server" IsNotNull="false" />&nbsp;- 
            <uc4:txtDate ID="txtExpectedDateTo" runat="server" IsNotNull="false" />
        </td>
    </tr>
    <tr>
        <td align="right">Closed Date : </td>
        <td>
            <uc4:txtDate ID="txtClosedDateFrom" runat="server" IsNotNull="false" />&nbsp;- 
            <uc4:txtDate ID="txtClosedDateTo" runat="server" IsNotNull="false" />
        </td>
    </tr>
    <tr>
        <td align="right">Order By : </td>
        <td>
            <uc1:cmbComboBox ID="cmbOrderBy" runat="server" IsNotNull="false" Width="220" AutoPosBack="true" />
        </td>
        <td colspan="6">
            <asp:RadioButtonList ID="rdiOrderDirection" runat="server" RepeatLayout="Table" RepeatDirection="Horizontal" Enabled="false">
                <asp:ListItem Text="Asc" Selected Value="A"></asp:ListItem>
                <asp:ListItem Text="Desc" Value="D"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td >&nbsp;</td>
        <td colspan="6" align="center" >
            <asp:Button ID="btnSearch" runat="server" CssClass="zButton" Text="ค้นหา" Width="80px" />
        </td>
    </tr>
</table>
<uc2:PageControl ID="pcTop" runat="server" />
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
    AllowSorting="True" AutoGenerateColumns="False" BackColor="White" PageSize="20" 
    BorderColor="#999999" BorderWidth="1px" CellPadding="1" 
    CssClass="GridViewStyle" GridLines="Vertical" Width="2000" >
    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
    <Columns>
        <asp:BoundField DataField="id" HeaderText="id">
            <ControlStyle CssClass="zHidden" />
            <FooterStyle CssClass="zHidden" />
            <HeaderStyle CssClass="zHidden" />
            <ItemStyle CssClass="zHidden" />
        </asp:BoundField>
        <asp:BoundField  DataField="no" HeaderText="NO" >
            <ItemStyle Width="40px" HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Width="40px" HorizontalAlign="Center"></HeaderStyle>
        </asp:BoundField>
        <asp:BoundField DataField="project_code" HeaderText="Project" SortExpression="project_code">
            <HeaderStyle Width="80px" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="80px" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Log No" SortExpression="log_no">
            <ItemTemplate>
                <asp:LinkButton ID="lnkLogNo" OnClick="lnkLogNo_Click" runat="server" Text='<%# Bind("log_no") %>' CommandArgument='<%# Bind("id")  %>'></asp:LinkButton>
            </ItemTemplate>
            <HeaderStyle Width="60px" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="60px" />
        </asp:TemplateField>
        <asp:BoundField DataField="type_name" HeaderText="Type" SortExpression="type_name">
            <HeaderStyle Width="80px" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="80px" />
        </asp:BoundField>
        <asp:BoundField DataField="log_desc" HtmlEncode="False" HeaderText="Description" >
            <HeaderStyle Width="300px" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" Width="200px" />
        </asp:BoundField>
        <asp:BoundField DataField="status_name" HeaderText="Status" SortExpression="status_name">
            <HeaderStyle Width="80px" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" Width="80px" />
        </asp:BoundField>
        <asp:BoundField DataField="priority" HeaderText="Priority" SortExpression="priority">
            <HeaderStyle Width="60px" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" Width="60px" />
        </asp:BoundField>
        <asp:BoundField DataField="state_name" HeaderText="State" SortExpression="state_name">
            <HeaderStyle Width="60px" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" Width="60px" />
        </asp:BoundField>
        <asp:BoundField DataField="log_instance" HeaderText="Instance" SortExpression="log_instance">
            <HeaderStyle Width="80px" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" Width="80px" />
        </asp:BoundField>
        <asp:BoundField DataField="screen_name" HeaderText="Screen" SortExpression="screen_name">
            <HeaderStyle Width="80px" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" Width="80px" />
        </asp:BoundField>
        <asp:BoundField DataField="module_name" HeaderText="Module" SortExpression="module_name">
            <HeaderStyle Width="80px" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" Width="80px" />
        </asp:BoundField>
        <asp:BoundField DataField="staff_raise" HeaderText="Raided By" SortExpression="staff_raise">
            <HeaderStyle Width="80px"  HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" Width="80px" />
        </asp:BoundField>
        <asp:BoundField DataField="raised_date" HeaderText="Raised Date" DataFormatString="{0:dd/MM/yyyy}" SortExpression="raised_date">
            <HeaderStyle Width="80px"  HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" Width="80px" />
        </asp:BoundField>
        <asp:BoundField DataField="change_approve" HeaderText="Change Request" SortExpression="change_approve">
            <HeaderStyle Width="60px"  HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="60px" />
        </asp:BoundField>
        <asp:BoundField DataField="comments" HeaderText="Comments" SortExpression="comments">
            <HeaderStyle Width="100px"  HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" Width="100px" />
        </asp:BoundField>
        <asp:BoundField DataField="staff_assign_to" HeaderText="Assigned To" SortExpression="staff_assign_to">
            <HeaderStyle Width="80px"  HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" Width="80px" />
        </asp:BoundField>
        <asp:BoundField DataField="assigned_date" HeaderText="Assigned Date" DataFormatString="{0:dd/MM/yyyy}" SortExpression="assigned_date">
            <HeaderStyle Width="80px" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" Width="80px" />
        </asp:BoundField>
        <asp:BoundField DataField="expected_closed_date" HeaderText="Expected Close Date" DataFormatString="{0:dd/MM/yyyy}" SortExpression="expected_closed_date">
            <HeaderStyle Width="80px" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" Width="80px" />
        </asp:BoundField>
        
        <asp:BoundField DataField="staff_close" HeaderText="Closed By" SortExpression="staff_close">
            <HeaderStyle Width="80px" />
            <ItemStyle HorizontalAlign="Left" Width="80px" />
        </asp:BoundField>
        <asp:BoundField DataField="closed_date" HeaderText="Closed Date" DataFormatString="{0:dd/MM/yyyy}" SortExpression="closed_date">
            <HeaderStyle Width="80px" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" Width="80px" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="พิมพ์" >
            <ItemTemplate>
                <asp:LinkButton ID="lnkPrintCR" OnClick="lnkPrintCR_Click" runat="server" Text='CR' CommandArgument='<%# Bind("id")  %>' ></asp:LinkButton>
            </ItemTemplate><HeaderStyle Width="60px" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="60px" />
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
    <EmptyDataTemplate >
        <table width ="100%" border="1">
            <tr>
                <td align="left">
                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="***ไม่พบข้อมูล***"></asp:Label>
                </td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
    <AlternatingRowStyle BackColor="#DCDCDC" />
    <PagerSettings Visible="False" />
</asp:GridView>   

</asp:Content>

