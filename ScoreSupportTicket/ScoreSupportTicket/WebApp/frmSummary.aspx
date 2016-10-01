<%@ Page Title="" Language="VB" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="false" CodeFile="frmSummary.aspx.vb" Inherits="WebApp_frmSummary" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../UserControls/cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="100%"  >
    <tr><td>&nbsp;</td></tr>
    <tr>
        <td align="center">Project : 
            <uc1:cmbComboBox ID="cmbProject" runat="server" IsNotNull="false" AutoPosBack="true" Width="300" IsDefaultValue="false" />
        </td>
    </tr>
    <tr><td>&nbsp;</td></tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" Width="100%">
    <tr>
        <td style="width:45%" valign="top" >Summary(Open)
            <asp:ImageButton ID="imgSummaryOpenExportWord" runat="server" ImageUrl="~/Images/icon_word.jpg" Width="16" ToolTip="Export to Word" Visible="false" />
            <asp:ImageButton ID="imgSummaryOpenExportExcel" runat="server" ImageUrl="~/Images/icon_excel.jpg" Width="16" ToolTip="Export to Excel" Visible="false" />
            <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="False" BackColor="White"
                BorderColor="#999999" BorderWidth="1px" CellPadding="1" 
                CssClass="GridViewStyle" GridLines="Vertical"  >
                <RowStyle BackColor="#EEEEEE" ForeColor="Black"  />
                <Columns>
                    <asp:BoundField  DataField="module_name" HeaderText="Module" >
                        <ItemStyle Width="150px" HorizontalAlign="Left"></ItemStyle>
                        <HeaderStyle Width="150px" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="height" HeaderText="Height" >
                        <HeaderStyle Width="60px" />
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="medium" HeaderText="Medium" >
                        <HeaderStyle Width="60px" />
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="low" HeaderText="Low" >
                        <HeaderStyle Width="60px" />
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="total" HeaderText="Total" >
                        <HeaderStyle Width="60px" />
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
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
            </asp:GridView>   
        </td>
        <td style="width:55%" valign="top" >Summary(All Status)
            <asp:GridView ID="GridView2" runat="server" 
                AutoGenerateColumns="False" BackColor="White"
                BorderColor="#999999" BorderWidth="1px" CellPadding="1" 
                CssClass="GridViewStyle" GridLines="Vertical"  >
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <Columns>
                    <asp:BoundField  DataField="module_name" HeaderText="Module" >
                        <ItemStyle Width="150px" HorizontalAlign="Left"></ItemStyle>
                        <HeaderStyle Width="150px" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="total" HeaderText="Total" >
                        <HeaderStyle Width="60px" />
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="closed" HeaderText="Closed" >
                        <HeaderStyle Width="60px" />
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="opened" HeaderText="Open" >
                        <HeaderStyle Width="60px" />
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="defect_open" HeaderText="Defect(Open)" >
                        <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="issue_open" HeaderText="Issue(Open)" >
                        <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
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
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">Detail(Open)
            <asp:GridView ID="GridView3" runat="server" 
                AutoGenerateColumns="False" BackColor="White"
                BorderColor="#999999" BorderWidth="1px" CellPadding="1" 
                CssClass="GridViewStyle" GridLines="Vertical" Width="100%" >
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField HeaderText="Log No" SortExpression="log_no">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkLogNo" OnClick="lnkLogNo_Click" runat="server" Text='<%# Bind("log_no") %>' CommandArgument='<%# Bind("id")  %>'></asp:LinkButton>
                        </ItemTemplate><HeaderStyle Width="60px" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </asp:TemplateField>
                    <asp:BoundField HtmlEncode="False" DataField="log_desc" HeaderText="Description" >
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField  DataField="module_name" HeaderText="Module" >
                        <ItemStyle Width="150px" HorizontalAlign="Left"></ItemStyle>
                        <HeaderStyle Width="150px" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="type_name" HeaderText="Type" >
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="priority" HeaderText="Priority" >
                        <HeaderStyle Width="60px" />
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="status_name" HeaderText="Status" >
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="raised_by" HeaderText="Raised By" >
                        <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}" DataField="raised_on"  HeaderText="Raised Date">
                        <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle Width="80px" HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="พิมพ์" SortExpression="log_no">
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
                                <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="***ไม่พบข้อมูล***"></asp:Label></td></tr></table></EmptyDataTemplate><SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="#DCDCDC" />
            </asp:GridView>
        </td>
    </tr>
</table>
</asp:Content>

