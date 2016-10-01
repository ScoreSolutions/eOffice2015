<%@ Page Title="" Language="VB" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="false" CodeFile="frmUserList.aspx.vb" Inherits="WebApp_frmUserList" %>
<%@ Register src="../UserControls/PageControl.ascx" tagname="PageControl" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../UserControls/txtBox.ascx" tagname="txtBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="likNewUser" runat="server">New User</asp:LinkButton>
<br />
    <table border="0" cellpadding="0" cellspacing="0" width="50%" align="center">
        <tr height="30px">
            <td width="30%" align="right">Staff Name :&nbsp;</td>
            <td width="70%" align="left">
                <uc1:txtBox ID="txtStaffName" runat="server" />
            </td>
        </tr>
        <tr height="30px">
            <td align="right">Position :&nbsp;</td>
            <td><uc1:txtBox ID="txtPositionName" runat="server" /></td>
        </tr>
        <tr height="30px">
            <td align="right">Division :&nbsp;</td>
            <td><uc1:txtBox ID="txtDivisionName" runat="server" /></td>
        </tr>
        <tr>
            <td >&nbsp;</td>
            <td >
                <asp:Button ID="btnSearch" runat="server" CssClass="zButton" Text="ค้นหา" Width="80px" />
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
                <ItemStyle Width="40px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Width="40px" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Username" SortExpression="username">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkUserName" OnClick="lnkUserName_Click" runat="server" Text='<%# Bind("username") %>' CommandArgument='<%# Bind("id")  %>'></asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle Width="60px" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="60px" />
            </asp:TemplateField>
            <asp:BoundField DataField="staffname" HeaderText="Staff Name" SortExpression="staffname">
                <HeaderStyle Width="80px" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="position_name"  HeaderText="Position" >
                <HeaderStyle Width="100px" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="division_name" HeaderText="Division" SortExpression="division_name">
                <HeaderStyle Width="100px" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="can_raise" HeaderText="Raise Issue" SortExpression="can_raise">
                <HeaderStyle Width="30px" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="can_accept_assignment" HeaderText="Accept Issue" SortExpression="can_accept_assignment">
                <HeaderStyle Width="30px" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="can_close" HeaderText="Close Issue" SortExpression="can_close">
                <HeaderStyle Width="30px" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="active" HeaderText="Active" SortExpression="active">
                <HeaderStyle Width="30px" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="50px" />
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

