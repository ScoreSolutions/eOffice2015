<%@ Page Language="VB" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="false" CodeFile="frmProject.aspx.vb" Inherits="WebApp_frmProject" title="Untitled Page" %>
<%@ Register src="../UserControls/txtBox.ascx" tagname="txtBox" tagprefix="uc1" %>
<%@ Register src="../UserControls/PageControl.ascx" tagname="PageControl" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="80%" align="center">
        <tr height="25px">
            <td width="20%" align="right">รหัสโครงการ :&nbsp;</td>
            <td width="30%" align="left"><uc1:txtBox ID="txtProjectCode" runat="server" IsNotNull="true" /></td>
            <td width="20%" align="right">ปีที่เริ่มโครงการ(พ.ศ.) :&nbsp;</td>
            <td width="30%" align="left"><uc1:txtBox ID="txtStartYear" runat="server" TextKey="TextInt" MaxLength="4" IsNotNull="true" /></td>
        </tr>
        <tr height="25px">
            <td align="right">ชื่อโครงการ :&nbsp;</td>
            <td><uc1:txtBox ID="txtProjectName" runat="server" IsNotNull="true" /></td>
            <td align="right">เลขที่สัญญา :&nbsp;</td>
            <td><uc1:txtBox ID="txtContractNo" runat="server" IsNotNull="true" /></td>
        </tr>
        <tr height="25px">
            <td align="right">ชื่อลูกค้า :&nbsp;</td>
            <td colspan="3" ><uc1:txtBox ID="txtCustomerName" runat="server" Width="550px" IsNotNull="true" /></td>
        </tr>
        <tr height="25px">
            <td align="right">รายละเอียดโครงการ :&nbsp;</td>
            <td colspan="3" ><uc1:txtBox ID="txtProjectDesc" runat="server" Height="50px" Width="550px" TextMode="MultiLine" /></td>
        </tr>
        <tr>
            <td >&nbsp;</td>
            <td >
                <asp:HiddenField ID="txtID" runat="server" />
                <asp:Button ID="btnSave" runat="server" CssClass="zButton" Text="บันทึก" Width="80px" />
            </td>
        </tr>
    </table>
<br /><br />
    <uc2:PageControl ID="pcTop" runat="server" />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" PageSize="20" 
        BorderColor="#999999" BorderWidth="1px" CellPadding="1" 
        CssClass="GridViewStyle" GridLines="Vertical" Width="100%" >
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id">
                <ControlStyle CssClass="zHidden" />
                <FooterStyle CssClass="zHidden" />
                <HeaderStyle CssClass="zHidden" />
                <ItemStyle CssClass="zHidden" />
            </asp:BoundField>
            <asp:BoundField  DataField="no" HeaderText="NO" >
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Width="30px" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Project Code" SortExpression="project_code">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkProjectCode" OnClick="lnkProjectCode_Click" runat="server" Text='<%# Bind("project_code") %>' CommandArgument='<%# Bind("id")  %>'></asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle Width="60px" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="60px" />
            </asp:TemplateField>
            <asp:BoundField DataField="project_name" HeaderText="Project Name" SortExpression="project_name">
                <HeaderStyle Width="150px" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" Width="150px" />
            </asp:BoundField>
            <asp:BoundField DataField="customer_name"  HeaderText="Customer Name" SortExpression="customer_name" >
                <HeaderStyle Width="120px" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="start_year" HeaderText="Start Year" SortExpression="start_year">
                <HeaderStyle Width="30px" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Right" Width="30px" />
            </asp:BoundField>
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

