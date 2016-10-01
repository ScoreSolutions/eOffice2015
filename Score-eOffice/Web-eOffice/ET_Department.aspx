<%@ Page Language="VB" MasterPageFile="~/MasterPage_Basic.master" AutoEventWireup="false" CodeFile="ET_Department.aspx.vb" Inherits="ET_Department" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <center>

 <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
 <ContentTemplate>
<TABLE class="dataTable" cellPadding=0 width=400 align=center border=1><TBODY><TR><TD style="HEIGHT: 17px" class="dataTableHeader" align=center>Add New Department</TD></TR><TR><TD style="HEIGHT: 84px" class="dataTableCell"><TABLE align=center><TBODY><TR><TD></TD><TD align=left><asp:Label id="lblId" runat="server" Visible="False" Width="136px"></asp:Label></TD><TD align=left></TD></TR><TR><TD>
    Department Abb</TD><TD align=left>
        <asp:TextBox ID="txt_Name_Abb" runat="server" CssClass="textboxRequired" 
            MaxLength="50" Width="150px"></asp:TextBox>
    </TD><TD align=left>&nbsp;</TD></TR>
    <tr>
        <td>
            Department:</td>
        <td align="left">
            <asp:TextBox ID="txt_Name_Dep" runat="server" CssClass="textboxRequired" 
                MaxLength="100" Width="150px"></asp:TextBox>
        </td>
        <td align="left">
            &nbsp;</td>
    </tr>
    <TR><TD>Active</TD><TD align=left>
        <asp:CheckBox ID="ckb_Department" runat="server" />
        </TD><TD align=left>
            <asp:Button ID="btnDSave" runat="server" Text="Save" Width="52px" />
            <asp:Button ID="btnDUpdate" runat="server" Text="Update" Width="52px" />
        </TD></TR>
    <tr>
        <td>
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>
    </TBODY></TABLE></TD></TR></TBODY></TABLE>
     <asp:Label ID="lblError1" runat="server" CssClass="errorBox" Visible="False" Width="400px"></asp:Label><br />
     <BR /><asp:GridView id="GridView1" runat="server" Width="395px" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="ID" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5" GridLines="None" ForeColor="#333333" CellPadding="4" AutoGenerateColumns="False" AllowPaging="True" OnRowUpdating="GridView1_RowUpdating">
<Columns>
<asp:TemplateField HeaderText="Department"><EditItemTemplate>
<asp:Label ID="Label3" runat="server"  Text='<%# Eval("department_desc") %>'></asp:Label>       
</EditItemTemplate>

<ItemStyle Width="315px" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
<ItemTemplate>
<asp:Label ID="Label3" runat="server"  Text='<%# Bind("department_desc") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField ShowHeader="False" HeaderText="Edit">
<ItemTemplate>
<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Update"
Text="Edit" />
</ItemTemplate>
<ControlStyle Width="40px" BorderStyle=Solid BorderWidth="1px" BorderColor="Silver" />
<ItemStyle Width="40px" HorizontalAlign="Center" VerticalAlign="Top" />
</asp:TemplateField>

<asp:TemplateField ShowHeader="False" HeaderText="Delete">
<ItemTemplate>
<asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete"
Text="Delete" OnClientClick = "return confirm('Are you sure you want to delete ?');" CommandArgument = "<%# Container.DataItemIndex %>"/>
</ItemTemplate>
<ControlStyle Width="45px" BorderStyle=Solid BorderWidth="1px" BorderColor="Silver" />
 <ItemStyle Width="40px" HorizontalAlign="Center" VerticalAlign="Top" />
</asp:TemplateField>
</Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="Black" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#5D7B9D" ForeColor="White" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView> <BR /><BR /><TABLE id="TABLE1" class="dataTable" cellPadding=0 width=400 align=center border=1><TBODY><TR><TD style="HEIGHT: 17px" class="dataTableHeader" align=center>Add New Position</TD></TR><TR><TD style="HEIGHT: 84px" class="dataTableCell"><TABLE align=center><TBODY><TR><TD></TD><TD align=left><asp:Label id="lblId_pos" runat="server" Visible="False" Width="136px"></asp:Label></TD><TD style="WIDTH: 113px" align=left></TD></TR><TR><TD>
         Position:</TD><TD align=left>
             <asp:TextBox ID="txt_name_pos" runat="server" CssClass="textboxRequired" 
                 MaxLength="100" Width="150px"></asp:TextBox>
         </TD><TD style="WIDTH: 113px" align=left></TD></TR><TR><TD align=right>Active:</TD><TD align=left>
         <asp:CheckBox ID="ckb_Position" runat="server" />
         </TD><TD style="WIDTH: 113px" align=left>
             <asp:Button ID="btnDSave2" runat="server" Text="Save" Width="52px" />
             <asp:Button ID="btnDUpdate2" runat="server" Text="Update" Width="52px" />
         </TD></TR><TR><TD align=right></TD><TD align=left></TD><TD style="WIDTH: 113px" align=left></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
     <asp:Label ID="errorbox2" runat="server" CssClass="errorBox" Visible="False" Width="400px"></asp:Label><br />
     <BR /><asp:GridView id="GridView2" runat="server" Width="395px" OnRowDeleting="GridView2_RowDeleting" DataKeyNames="ID" OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="5" GridLines="None" ForeColor="#333333" CellPadding="4" AutoGenerateColumns="False" AllowPaging="True" OnRowUpdating="GridView2_RowUpdating">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>

<asp:TemplateField HeaderText="Position"><EditItemTemplate>
<asp:Label ID="Label2" runat="server"  Text='<%# Eval("Position_desc") %>'></asp:Label>       
</EditItemTemplate>

<ItemStyle Width="315px" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
<ItemTemplate>
<asp:Label ID="Label2" runat="server"  Text='<%# Bind("Position_desc") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Edit" ShowHeader="False">
<ControlStyle BorderStyle="Solid" Width="40px" BorderWidth="1px" BorderColor="Silver"></ControlStyle>

<ItemStyle Width="40px" HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
<ItemTemplate>
<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Update"
Text="Edit" />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete" ShowHeader="False">
<ControlStyle BorderStyle="Solid" Width="45px" BorderWidth="1px" BorderColor="Silver"></ControlStyle>

<ItemStyle Width="40px" HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
<ItemTemplate>
<asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete"
Text="Delete" OnClientClick = "return confirm('Are you sure you want to delete ?');" CommandArgument = "<%# Container.DataItemIndex %>"/>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="Black"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#5D7B9D" ForeColor="White" HorizontalAlign="Right"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> 
</ContentTemplate>
        </asp:UpdatePanel>


        &nbsp;</center>
    <center>
        &nbsp;&nbsp;</center>
    <center>
        &nbsp;</center>
    <center>
        &nbsp;</center>
</asp:Content>

