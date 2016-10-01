<%@ Page Title="" Language="VB" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="false" CodeFile="frmMain.aspx.vb" Inherits="WebApp_frmMain" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../UserControls/cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width:50%"  >
                <uc1:cmbComboBox ID="cmbProject" runat="server" IsNotNull="false" AutoPosBack="true" Width="220" DefaultDisplay="---Select" />
                <asp:GridView ID="GridView1" runat="server" 
                    AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#999999" BorderWidth="1px" CellPadding="1" 
                    CssClass="GridViewStyle" GridLines="Vertical" Width="2000" >
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField  DataField="module_name" HeaderText="Module" >
                            <ItemStyle Width="120px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="120px" HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="height" HeaderText="Height" >
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="medium" HeaderText="Medium" >
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="low" HeaderText="Low" >
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="total" HeaderText="Total" >
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
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
            <td style="width:50%"></td>
        </tr>
    </table>
</asp:Content>

