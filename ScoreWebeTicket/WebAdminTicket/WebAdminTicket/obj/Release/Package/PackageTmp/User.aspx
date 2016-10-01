<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="User.aspx.vb" Inherits="WebTarget.WebForm1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns='http://www.w3.org/1999/xhtml'>
<head runat="server">
<title></title>
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style12 {
            width: 33px;
        }
        .auto-style14 {
            text-align: left;
        }
        .auto-style16 {
            width: 383px;
            text-align: right;
        }
        .auto-style22 {
            width: 33px;
            text-align: right;
        }
        .auto-style26 {
            text-align: left;
            }
        .auto-style27 {
            width: 33px;
            height: 23px;
        }
        .auto-style28 {
            width: 383px;
            text-align: right;
            height: 23px;
        }
        .auto-style29 {
            text-align: left;
            height: 23px;
        }
        .auto-style36 {
            text-align: left;
            width: 67px;
        }
        .auto-style39 {
            text-align: left;
            width: 67px;
            height: 23px;
        }
        .auto-style40 {
            width: 67px;
        }
        .auto-style41 {
            text-align: left;
            width: 277px;
        }
        .auto-style42 {
            text-align: left;
            width: 277px;
            height: 23px;
        }
        .auto-style43 {
            width: 33px;
            text-align: right;
            height: 9px;
        }
        .auto-style44 {
            width: 383px;
            text-align: right;
            height: 9px;
        }
        .auto-style45 {
            text-align: left;
            width: 277px;
            height: 9px;
        }
        .auto-style46 {
            text-align: left;
            width: 67px;
            height: 9px;
        }
        .auto-style47 {
            text-align: left;
            height: 9px;
        }
        .auto-style48 {
            text-align: left;
            width: 107px;
            height: 9px;
        }
        .auto-style49 {
            text-align: left;
            width: 107px;
        }
        .auto-style50 {
            width: 107px;
        }
        .auto-style51 {
            text-align: left;
            width: 107px;
            height: 23px;
        }
    </style>
            
     
</head>
<body>
<form id="form1" runat="server">
<div style="text-align: center">
  
    <p style="font-size: large; color: #00CC00; text-align: left;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <p style="font-size: large; color: #00CC00; text-align: left; background-color: #515151;">
            <strong style="color: #b6ff00">User</strong>
        </p>
    </p>
    <table class="auto-style2">
        <tr>
            <td class="auto-style43"></td>
            <td class="auto-style44">&nbsp;Username
        <asp:TextBox ID="txtname" runat="server" Height="23px" style="text-align: left" AutoPostBack="True" MaxLength="20"></asp:TextBox>
                </td>
            <td class="auto-style48">
                &nbsp;<asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td class="auto-style46">Full Name </td>
            <td class="auto-style45">
        <asp:TextBox ID="txtstaff" runat="server" Height="23px" style="text-align: left" AutoPostBack="True" MaxLength="50"></asp:TextBox>
                <asp:Label ID="Label16" runat="server" ForeColor="Red"></asp:Label>
                </td>
            <td class="auto-style47">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style22">&nbsp;</td>
            <td class="auto-style16">&nbsp;<asp:Label ID="Label7" runat="server" Text="Password"></asp:Label>
                &nbsp;<asp:TextBox ID="txtpass" runat="server" Height="23px" TextMode="Password" MaxLength="20"></asp:TextBox>
                </td>
            <td class="auto-style50" style="text-align: left">
                &nbsp;</td>
             <td class="auto-style36">Position </td>
             <td class="auto-style41">
        <asp:TextBox ID="txtposition" runat="server" Height="23px" style="text-align: left" MaxLength="20"></asp:TextBox>
                </td>
             <td class="auto-style14">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style22">&nbsp;</td>
            <td class="auto-style16">&nbsp;<asp:Label ID="Label8" runat="server" Text="ConfirmPassword"></asp:Label>
&nbsp;<asp:TextBox ID="txtconf" runat="server" Height="23px" style="margin-left: 0px" TextMode="Password" MaxLength="20"></asp:TextBox>
                </td>
            <td class="auto-style49">
                <asp:Label ID="Label15" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td class="auto-style36">Usergroup </td>
            <td class="auto-style41">
                &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="group_name" DataValueField="group_name" Height="24px" Width="173px" AutoPostBack="True" AppendDataBoundItems="true">
                    <asp:ListItem value="">Select Group</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Support-TicketConnectionString %>" SelectCommand="SELECT [group_name] FROM [TICKET_USER_GROUP]"></asp:SqlDataSource>
                </td>
            <td class="auto-style14">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style27"></td>
            <td class="auto-style28">
                <asp:CheckBox ID="CheckBox4" runat="server" Text="Active" />
            </td>
            <td class="auto-style51">
                </td>
            <td class="auto-style39">
                </td>
            <td class="auto-style42">
                </td>
            <td class="auto-style29">
                </td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style16">
                    <br />
                    <asp:Button ID="btnsave" runat="server" BackColor="#FF9933" BorderColor="#FF9933" Text="Save" Width="91px" />
                    &nbsp;<asp:Button ID="btnclear" runat="server" BackColor="#FF9933" BorderColor="#FF9933" Text="Clear" Width="91px" />
                    &nbsp;<br />
                    <br />
                    </td>
            <td class="auto-style50">
                    &nbsp;</td>
            <td class="auto-style40" style="text-align: left">
&nbsp;
                    </td>
            <td class="auto-style41">
                    &nbsp;</td>
            <td class="auto-style26">
                    &nbsp;</td>
        </tr>
    </table>
     <asp:UpdatePanel runat="server" >
           <ContentTemplate>

                <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" GridLines="None">
            <MasterTableView >
<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
            <Columns>
                   <telerik:GridTemplateColumn HeaderText="No" DataField="id" UniqueName="id">                                                                  
                   <EditItemTemplate><asp:TextBox ID="TextBox1" runat="server" Text='<%# bind("id") %>' Enabled="False"></asp:TextBox></EditItemTemplate><ItemTemplate >                         
                           <asp:Label ID="Label9" runat="server" Text='<%# Eval("id")%>' visible="false"></asp:Label>
                         <asp:Label ID="lblNo" runat="server" Text='<%# Eval("Row")%>'></asp:Label>
                       </ItemTemplate><HeaderStyle HorizontalAlign="Center" /></telerik:GridTemplateColumn>
                   <telerik:GridTemplateColumn HeaderText="Username" UniqueName="TemplateColumn1" DataField="username">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox2" runat="server" Text='<%# bind("username") %>' Enabled="False"></asp:TextBox>
                       </EditItemTemplate>
                         <ItemTemplate >                          
                           <asp:Label ID="Label10" runat="server" Text='<%# Eval("username")%>'></asp:Label>
                       </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" />
                   </telerik:GridTemplateColumn>
                   <telerik:GridTemplateColumn HeaderText="Staff Name" UniqueName="TemplateColumn2" DataField="staffname">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox3" runat="server" Text='<%# bind("staffname") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate >                         
                           <asp:Label ID="Label11" runat="server" Text='<%# Eval("staffname")%>'></asp:Label>
                       </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" />
                   </telerik:GridTemplateColumn>
                   <telerik:GridTemplateColumn HeaderText="Position" UniqueName="TemplateColumn3" DataField="position_name">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox4" runat="server" Text='<%# bind("position_name") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate >                         
                           <asp:Label ID="Label12" runat="server" Text='<%# Eval("position_name")%>'></asp:Label>
                       </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" />
                   </telerik:GridTemplateColumn>
                   <telerik:GridTemplateColumn HeaderText="Active" UniqueName="TemplateColumn4" DataField="active">
                       <EditItemTemplate>
                           <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="16px" style="text-align: left" Width="76px">
                               <asp:ListItem Value="Y" Selected ="True">Yes</asp:ListItem>
                               <asp:ListItem Value="N">No</asp:ListItem>
                           </asp:RadioButtonList>
                       </EditItemTemplate>
                       <ItemTemplate >                         
                           <asp:Label ID="Label13" runat="server" Text='<%# Eval("active")%>'></asp:Label>
                       </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" />
                   </telerik:GridTemplateColumn>
                    <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="Delete" CommandName="Delete" ButtonType="ImageButton" ImageUrl="Image/empty_bin.png" ConfirmText="Are you sure you want to delete the selected row?">
                </telerik:GridButtonColumn>
                     <telerik:GridButtonColumn UniqueName="EditColumn" Text="Edit" CommandName="Edit" ButtonType="ImageButton" ImageUrl="Image/edit.png">
                </telerik:GridButtonColumn>
            </Columns>
          </MasterTableView>

<FilterMenu EnableTheming="True">
<CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
</FilterMenu>
    </telerik:RadGrid>
       
               </ContentTemplate>
         </asp:UpdatePanel>
        &nbsp;&nbsp;&nbsp;

</div>
</form>
</body>
</html>