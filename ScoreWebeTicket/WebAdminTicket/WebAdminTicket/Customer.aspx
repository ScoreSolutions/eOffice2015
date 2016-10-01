<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Customer.aspx.vb" Inherits="WebTarget.Customer" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style2 {
            width: 100%;
            height: 118px;
        }
        .auto-style22 {
            text-align: center;
            height: 236px;
        }
        .auto-style23 {
        }
        .auto-style18 {
            font-size: large;
            text-align: left;
            height: 9px;
            width: 369px;
        }
        .auto-style16 {
            width: 125px;
            text-align: right;
        }
        .tabstrip {
            margin-bottom: 0;
        }
        .auto-style27 {
            width: 100%;
            color: #0099FF;
        }
        .auto-style38 {
            color: #000000;
            background-color: #4B4B4B;
        }
        .auto-style39 {
            width: 85px;
        }
        .auto-style46 {
            width: 45px;
            text-align: right;
            height: 12px;
        }
        .auto-style47 {
            width: 125px;
            text-align: right;
            height: 12px;
        }
        .auto-style48 {
            width: 45px;
            text-align: right;
            height: 9px;
        }
        .auto-style49 {
            width: 125px;
            text-align: right;
            height: 9px;
        }
        .auto-style55 {
            text-align: left;
            width: 369px;
        }
        .auto-style62 {
            width: 29px;
        }
        .auto-style66 {
            width: 29px;
            height: 9px;
        }
        .auto-style68 {
            height: 9px;
        }
        .auto-style70 {
            width: 29px;
            height: 6px;
        }
        .auto-style72 {
            height: 6px;
        }
        .auto-style75 {
            width: 70px;
            text-align: right;
            height: 24px;
        }
        .auto-style76 {
            width: 53px;
            height: 24px;
        }
        .auto-style77 {
            height: 24px;
        }
        .auto-style80 {
            width: 53px;
        }
        .auto-style83 {
            height: 24px;
            width: 68px;
        }
        .auto-style84 {
            width: 68px;
        }
        .auto-style103 {
            width: 70px;
            text-align: right;
            height: 6px;
        }
        .auto-style104 {
            width: 70px;
            text-align: right;
            height: 9px;
        }
        .auto-style110 {
            width: 70px;
            text-align: right;
        }
        .auto-style114 {
            width: 68px;
            text-align: right;
        }
        .auto-style115 {
            width: 159px;
            text-align: right;
            color: #0099FF;
            height: 24px;
        }
        .auto-style116 {
            width: 159px;
            text-align: right;
            color: #0099FF;
        }
        .auto-style117 {
            width: 85px;
            height: 24px;
        }
        .auto-style118 {
            width: 48px;
            text-align: right;
            height: 12px;
        }
        .auto-style119 {
            width: 48px;
            text-align: right;
            height: 9px;
        }
        .auto-style120 {
            text-align: center;
            height: 236px;
            width: 48px;
        }
        .auto-style121 {
            width: 48px;
        }
        .auto-style122 {
            width: 45px;
        }
        .breakWord 
{  
   max-width: 80px !important;  
   word-break: break-all !important;  
   word-wrap: break-word !important;  
   vertical-align: top;  
   line-height: 10px;  
}  
        .breakWord120  
{  
   max-width: 120px !important;  
   word-break: break-all !important;  
   word-wrap: break-word !important;  
   vertical-align: top;  
   line-height: 15px;  
}  
        </style>
 </head>
<body>
<form id="form1" runat="server">
<div style="height: 224px">
  
    <p style="font-size: large; color: #00CC00; text-align: left;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
    </p>
    <p style="font-size: large; text-align: left;" class="auto-style38">
        <strong style="color: #b6ff00">ACCOUNT</strong></p>
    <table class="auto-style2">
        <tr>
            <td class="auto-style118">&nbsp;</td>
            <td class="auto-style46"></td>
            <td class="auto-style47">&nbsp;Account Code&nbsp;&nbsp; </td>
            <td class="auto-style55">
        <asp:TextBox ID="txtcode" runat="server" Height="23px" style="text-align: left; margin-left: 0px;"></asp:TextBox>
                </td>
            <td class="auto-style23" rowspan="4" valign="top">

    <telerik:RadGrid ID="RadGrid4" runat="server" AllowPaging="True" AutoGenerateColumns="False" GridLines="None" style="margin-top: 0px" PageSize="18" width="400px">
        <MasterTableView>
            <RowIndicatorColumn>
                <HeaderStyle Width="10px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="10px" />
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridTemplateColumn UniqueName="TemplateColumn2" DataField="account_id" HeaderText="No" >
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("account_id")%>' Enabled="False"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("account_id")%>' Visible="false"></asp:Label>
                        <asp:Label ID="lblNo" runat="server" Text='<%# Eval("Row")%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="TemplateColumn" DataField="account_code" HeaderText="Acc-Code">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("account_code")%>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("account_code")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center"/>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="TemplateColumn1" DataField="account_name" HeaderText="Acc-Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("account_name")%>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("account_name")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="None" HorizontalAlign="Center" />
                </telerik:GridTemplateColumn>
                <telerik:GridButtonColumn ButtonType="ImageButton" ImageUrl="Image/empty_bin.png" UniqueName="column" CommandName="Delete" ConfirmText="Are you sure you want to delete the selected row?">
                    <HeaderStyle BorderStyle="None" width="15px"/>
                </telerik:GridButtonColumn>
                <telerik:GridButtonColumn ButtonType="ImageButton" ImageUrl="Image/edit.png" UniqueName="column1" CommandName="Edit">
                    <HeaderStyle BorderStyle="None" width="15px"/>
                </telerik:GridButtonColumn>    
            </Columns>
        </MasterTableView>
        <FilterMenu EnableTheming="True">
            <CollapseAnimation Duration="200" Type="OutQuint" />
        </FilterMenu>
    </telerik:RadGrid>
                    <br />
                
                <br />
                
                <br />
                
                    </td>
        </tr>
        <tr>
            <td class="auto-style119">&nbsp;</td>
            <td class="auto-style48"></td>
            <td class="auto-style49">&nbsp; Account Name&nbsp;&nbsp; </td>
            <td class="auto-style18">
        <asp:TextBox ID="txtname" runat="server" Height="23px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="auto-style120">
                    &nbsp;</td>
            <td class="auto-style22" colspan="3">
                    <br />
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" SelectedIndex="2" Font-Size="X-Large" Skin="Black" Height="26px" Width="100%" BackColor="#2B2B2B">
            <Tabs>
                <telerik:RadTab runat="server" Font-Size="20pt" Text="Branch" PageViewID="RadPageView1" Width="33%">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Contact Person" PageViewID="RadPageView2" Font-Size="20pt" Width="33%">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Project" PageViewID="RadPageView3" Font-Size="20pt" Selected="True" Width="33%">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%"  BackColor="#ccffff" SelectedIndex="2"><telerik:RadPageView ID="RadPageView1" runat="server" BackColor="#4E4E4E" Selected="true" Width="100%"><br /><table class="auto-style27"><tr><td class="auto-style115">Code :</td><td class="auto-style117"><asp:TextBox ID="txtbcode" runat="server" Width="110px" MaxLength="20"></asp:TextBox></td><td class="auto-style77"></td>
                    </tr>
                    <tr><td class="auto-style116">Name :</td><td class="auto-style39"><asp:TextBox ID="txtbname" runat="server" Width="110px" MaxLength="20"></asp:TextBox></td><td>&#160;</td></tr><tr><td class="auto-style116">SLA :</td><td class="auto-style39"><asp:TextBox ID="txtbsla" runat="server" Width="110px" MaxLength="10"></asp:TextBox></td><td style="text-align: left"><asp:Button ID="Button1" runat="server" BackColor="#CC0000" BorderStyle="None" style="background-color: #3366FF" Text="Add" Width="53px" /></td>
                    </tr>
                </table>
                <br /><center><telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" GridLines="None" Height="232px" PageSize="9" Skin="Black" Visible="False" Width="100%">
                     <ClientSettings>
                <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="true" FrozenColumnsCount="2"></Scrolling>
            </ClientSettings>
                    <mastertableview TableLayout="Fixed">
                        <rowindicatorcolumn>                        
                            </rowindicatorcolumn>
                            <expandcollapsecolumn>
                            </expandcollapsecolumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="column" HeaderText="Code" ItemStyle-CssClass="breakWord" >
                                     <HeaderStyle Width="30%" Wrap="true" />
                                <ItemStyle Width="30%" Wrap="true" VerticalAlign="Top" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="column1" HeaderText="Name" ItemStyle-CssClass="breakWord" >
                                     <HeaderStyle Width="30%" Wrap="true" />
                                <ItemStyle Width="30%" Wrap="true" VerticalAlign="Top" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="column2 " HeaderText="SLA" ItemStyle-CssClass="breakWord" >
                                    <HeaderStyle Width="30%" Wrap="true" />
                                <ItemStyle Width="30%" Wrap="true" VerticalAlign="Top" />
                                </telerik:GridBoundColumn>
                   
                                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ImageUrl="Image/Delete.png" UniqueName="DelteColumn">                            
                                    <HeaderStyle Wrap="true" />
                                 <ItemStyle VerticalAlign="Top" HorizontalAlign="center" />
                                </telerik:GridButtonColumn>
                   
                            </Columns>
                        </mastertableview>
                        <filtermenu enabletheming="True"><collapseanimation duration="200" type="OutQuint" />
                        </filtermenu>
                    </telerik:RadGrid>
                </center>
                <center><telerik:RadGrid ID="RadGrid7" runat="server" AutoGenerateColumns="False" GridLines="None" Width="400px">
                    <mastertableview>
                        <rowindicatorcolumn>
<HeaderStyle Width="20px"></HeaderStyle>
</rowindicatorcolumn>
<expandcollapsecolumn>
<HeaderStyle Width="20px"></HeaderStyle>
</expandcollapsecolumn>
    <Columns>
        <telerik:GridTemplateColumn DataField="branch_id" HeaderText="No" UniqueName="TemplateColumn">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox7" runat="server" Enabled="false" Text='<%# Bind("branch_id")%>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label4" runat="server" Text='<%# Bind("branch_id")%>'></asp:Label>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn HeaderText="B-Code" UniqueName="TemplateColumn1">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("branch_code")%>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label5" runat="server" Text='<%# Bind("branch_code")%>'></asp:Label>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn HeaderText="B-Name" UniqueName="TemplateColumn2">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("branch_name")%>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label6" runat="server" Text='<%# Bind("branch_name")%>'></asp:Label>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn HeaderText="Acc-No" UniqueName="TemplateColumn3">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox10" runat="server" Enabled="false" Text='<%# Bind("account_id")%>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label7" runat="server" Text='<%# Bind("account_id")%>'></asp:Label>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmText="Are you sure you want to delete the selected row?" ImageUrl="Image/empty_bin.png" UniqueName="column">
                    <HeaderStyle BorderStyle="None" width="15px" />
                </telerik:GridButtonColumn>
                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Edit" ImageUrl="Image/edit.png" UniqueName="column1">
                    <HeaderStyle BorderStyle="None" width="15px" />
                </telerik:GridButtonColumn>   
    </Columns>
</mastertableview>

<filtermenu enabletheming="True"><collapseanimation duration="200" type="OutQuint"></collapseanimation>
</filtermenu>
                    
                </telerik:RadGrid>
                    </center>
            </telerik:RadPageView><telerik:RadPageView ID="RadPageView2" runat="server" BackColor="#565656" Width="100%"><br /><table class="auto-style27"><tr><td class="auto-style103">Code :</td><td class="auto-style70"><asp:TextBox ID="txtconC" runat="server" Width="110px" MaxLength="12"></asp:TextBox></td><td class="auto-style103">Tel :</td><td class="auto-style72" style="text-align: left"><asp:TextBox ID="txtconT" runat="server" Width="110px" MaxLength="20"></asp:TextBox></td></tr><tr><td class="auto-style104">Name :</td><td class="auto-style66"><asp:TextBox ID="txtconN" runat="server" Width="110px" MaxLength="20"></asp:TextBox></td>
    <td class="auto-style104">E-Mail :</td>
    <td class="auto-style68" style="text-align: left"><asp:TextBox ID="txtconE" runat="server" MaxLength="50" Width="110px"></asp:TextBox></td></tr><tr><td class="auto-style110">&#160;</td><td class="auto-style62">&#160;</td><td class="auto-style110" style="text-align: left">&#160;</td><td style="text-align: left"><asp:Button ID="Button2" runat="server" BackColor="#CC0000" BorderStyle="None" style="background-color: #3366FF" Text="Add" Width="53px" /></td>
                    </tr>
                    <tr><td class="auto-style110">&#160;</td><td class="auto-style62">&#160;</td><td class="auto-style110" style="text-align: center">&#160;</td><td style="text-align: left">&#160;</td></tr></table><center><telerik:RadGrid ID="RadGrid5" runat="server" AllowPaging="True" AutoGenerateColumns="False" GridLines="None" Height="232px" PageSize="9" Skin="Black" Visible="False" Width="100%">
                              <ClientSettings>
                <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="true" FrozenColumnsCount="2"></Scrolling>
            </ClientSettings>
                        <mastertableview TableLayout="Fixed"><rowindicatorcolumn>    
                         <HeaderStyle Width="20px" />
                        </rowindicatorcolumn>
                        <expandcollapsecolumn>
                            <HeaderStyle Width="20px" />
                        </expandcollapsecolumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="column" HeaderText="Code" ItemStyle-CssClass="breakWord">
                                <HeaderStyle Width="20%" Wrap="true" />
                                <ItemStyle Width="20%" Wrap="true" VerticalAlign="Top" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="column1" HeaderText="Name" ItemStyle-CssClass="breakWord">
                                <HeaderStyle Width="20%" Wrap="true" />
                                <ItemStyle Width="20%" Wrap="true" VerticalAlign="Top" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="column2 " HeaderText="Tell" ItemStyle-CssClass="breakWord">
                               <HeaderStyle Width="20%" Wrap="true" />
                                <ItemStyle Width="20%" Wrap="true" VerticalAlign="Top" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="column3" HeaderText="E-mail" ItemStyle-CssClass="breakWord">
                               <HeaderStyle Width="30%" Wrap="true" />
                                <ItemStyle Width="30%" Wrap="true" VerticalAlign="Top" />
                            </telerik:GridBoundColumn>
                             <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ImageUrl="Image/Delete.png" UniqueName="DelteColumn">                      
                                 <HeaderStyle Wrap="true" />
                                 <ItemStyle VerticalAlign="Top" HorizontalAlign="center" />
                                </telerik:GridButtonColumn>
                        </Columns>
                    </mastertableview>
                    <filtermenu enabletheming="True"><collapseanimation duration="200" type="OutQuint" />
                    </filtermenu>
                </telerik:RadGrid>
                    </center>
                <center><telerik:RadGrid ID="RadGrid8" runat="server" AutoGenerateColumns="False" GridLines="None" Width="500px"><MasterTableView><RowIndicatorColumn>
<HeaderStyle Width="20px" />
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px" />
</ExpandCollapseColumn>
    <Columns>
        <telerik:GridTemplateColumn HeaderText="No" UniqueName="TemplateColumn">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Enabled="false" Text='<%# Bind("contact_id")%>'></asp:TextBox></EditItemTemplate><ItemTemplate>
                <asp:Label ID="Label8" runat="server" Text='<%# Bind("contact_id")%>'></asp:Label></ItemTemplate></telerik:GridTemplateColumn><telerik:GridTemplateColumn HeaderText="C-Code" UniqueName="TemplateColumn1">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("contact_code")%>'></asp:TextBox></EditItemTemplate><ItemTemplate>
                <asp:Label ID="Label9" runat="server" Text='<%# Bind("contact_code")%>'></asp:Label></ItemTemplate></telerik:GridTemplateColumn><telerik:GridTemplateColumn HeaderText="C-Name" UniqueName="TemplateColumn2">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("contact_name")%>'></asp:TextBox></EditItemTemplate><ItemTemplate>
                <asp:Label ID="Label10" runat="server" Text='<%# Bind("contact_name")%>'></asp:Label></ItemTemplate></telerik:GridTemplateColumn><telerik:GridTemplateColumn HeaderText="C-Tell" UniqueName="TemplateColumn2">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("contact_tell")%>'></asp:TextBox></EditItemTemplate><ItemTemplate>
                <asp:Label ID="Label17" runat="server" Text='<%# Bind("contact_tell")%>'></asp:Label></ItemTemplate></telerik:GridTemplateColumn><telerik:GridTemplateColumn HeaderText="C-Mail" UniqueName="TemplateColumn2">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox21" runat="server" Text='<%# Bind("contact_email")%>'></asp:TextBox></EditItemTemplate><ItemTemplate>
                <asp:Label ID="Label18" runat="server" Text='<%# Bind("contact_email")%>'></asp:Label></ItemTemplate></telerik:GridTemplateColumn><telerik:GridTemplateColumn HeaderText="Acc-No" UniqueName="TemplateColumn3">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox14" runat="server" Enabled="false" Text='<%# Bind("account_id")%>'></asp:TextBox></EditItemTemplate><ItemTemplate>
                <asp:Label ID="Label11" runat="server" Text='<%# Bind("account_id")%>'></asp:Label></ItemTemplate></telerik:GridTemplateColumn><telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmText="Are you sure you want to delete the selected row?" ImageUrl="Image/empty_bin.png" UniqueName="column">
                    <HeaderStyle BorderStyle="None" width="15px" />
                </telerik:GridButtonColumn>
                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Edit" ImageUrl="Image/edit.png" UniqueName="column1">
                    <HeaderStyle BorderStyle="None" width="15px" />
                </telerik:GridButtonColumn>   
    </Columns>
</MasterTableView>

<FilterMenu EnableTheming="True"><CollapseAnimation Duration="200" Type="OutQuint" />
</FilterMenu>
                    
                </telerik:RadGrid>
                    </center>
            </telerik:RadPageView><telerik:RadPageView ID="RadPageView3" runat="server" BackColor="#525252" Width="100%"><br /><table class="auto-style27"><tr><td class="auto-style110">Code :</td><td class="auto-style80"><asp:TextBox ID="txtpoC" runat="server" Width="110px" MaxLength="20"></asp:TextBox></td><td class="auto-style114">Sup :</td><td style="text-align: left"><asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="staffname" DataValueField="staffname" Height="24px" Width="131px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr><td class="auto-style110" valign="top">Name :</td><td class="auto-style80" valign="top"><asp:TextBox ID="txtpoN" runat="server" Width="110px" MaxLength="20"></asp:TextBox></td><td class="auto-style114" valign="top">&#160;&#160;&#160;Desc :</td><td style="text-align: left"><asp:TextBox ID="txtpoD" runat="server" Height="41px" TextMode="MultiLine" Width="120px" MaxLength="500"></asp:TextBox></td></tr><tr><td class="auto-style75"></td>
                        <td class="auto-style76"></td>
                        <td class="auto-style83" style="text-align: left">&#160;</td><td class="auto-style77" style="text-align: left"><asp:Button ID="Button3" runat="server" BackColor="#CC0000" BorderStyle="None" style="background-color: #3366FF" Text="Add" Width="53px" /></td>
                    </tr>
                    <tr><td class="auto-style110">&#160;</td><td class="auto-style80">&#160;</td><td class="auto-style84" style="text-align: left">&#160;</td><td style="text-align: left">&#160;</td></tr></table><center><telerik:RadGrid ID="RadGrid6" runat="server" AllowPaging="True" AutoGenerateColumns="False" GridLines="None" Height="232px" PageSize="9" Skin="Black" Visible="False" Width="100%">
               <ClientSettings>
                <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="true" FrozenColumnsCount="2"></Scrolling>
            </ClientSettings>
                          <AlternatingItemStyle />
    <mastertableview TableLayout="Fixed"><rowindicatorcolumn>
                            <HeaderStyle />
                        </rowindicatorcolumn>
                        <expandcollapsecolumn>
                            <HeaderStyle />
                        </expandcollapsecolumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="column" HeaderText="Code"  ItemStyle-CssClass="breakWord">
                                <HeaderStyle Width="15%" Wrap="true" />
                                <ItemStyle Width="15%" Wrap="true" VerticalAlign="Top" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="column1" HeaderText="Name"  ItemStyle-CssClass="breakWord">
                                <HeaderStyle Width="20%" Wrap="true" />
                                <ItemStyle Width="20%" Wrap="true" VerticalAlign="Top" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="column2 " HeaderText="Description"  ItemStyle-CssClass="breakWord120">
                                <HeaderStyle Width="40%" Wrap="true" />
                                <ItemStyle Width="35%" Wrap="true" VerticalAlign="Top" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="column3" HeaderText="Suppervisor"  ItemStyle-CssClass="breakWord">
                                <HeaderStyle Width="20%" Wrap="true" />
                                <ItemStyle Width="20%" Wrap="true" VerticalAlign="Top" />
                            </telerik:GridBoundColumn>
                             <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ImageUrl="Image/Delete.png" UniqueName="DelteColumn">
                                 <HeaderStyle />
                                 <ItemStyle Wrap="true" VerticalAlign="Top" HorizontalAlign="center" />
                                </telerik:GridButtonColumn>
                        </Columns>
                    </mastertableview>
                    <activeitemstyle width="20px" />
    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                    <filtermenu enabletheming="True"><collapseanimation duration="200" type="OutQuint" />
                    </filtermenu>
                </telerik:RadGrid>
                    </center>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Support-TicketConnectionString %>" SelectCommand="SELECT [staffname] FROM [TICKET_STAFF]"></asp:SqlDataSource>
                <center><telerik:RadGrid ID="RadGrid9" runat="server" AutoGenerateColumns="False" GridLines="None" Width="400px"><MasterTableView><RowIndicatorColumn>
<HeaderStyle Width="20px" />
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px" />
</ExpandCollapseColumn>
    <Columns>
        <telerik:GridTemplateColumn HeaderText="No" UniqueName="TemplateColumn">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox19" runat="server" Enabled="false" Text='<%# Bind("id")%>'></asp:TextBox></EditItemTemplate><ItemTemplate>
                <asp:Label ID="Label16" runat="server" Text='<%# Bind("id")%>'></asp:Label></ItemTemplate></telerik:GridTemplateColumn><telerik:GridTemplateColumn HeaderText="P-Code" UniqueName="TemplateColumn">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("project_code")%>'></asp:TextBox></EditItemTemplate><ItemTemplate>
                <asp:Label ID="Label12" runat="server" Text='<%# Bind("project_code")%>'></asp:Label></ItemTemplate></telerik:GridTemplateColumn><telerik:GridTemplateColumn HeaderText="P-Name" UniqueName="TemplateColumn1">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("project_name")%>'></asp:TextBox></EditItemTemplate><ItemTemplate>
                <asp:Label ID="Label13" runat="server" Text='<%# Bind("project_name")%>'></asp:Label></ItemTemplate></telerik:GridTemplateColumn><telerik:GridTemplateColumn HeaderText="P-Desc" UniqueName="TemplateColumn2">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox17" runat="server" Text='<%# Bind("project_desc")%>'></asp:TextBox></EditItemTemplate><ItemTemplate>
                <asp:Label ID="Label14" runat="server" Text='<%# Bind("project_desc")%>'></asp:Label></ItemTemplate></telerik:GridTemplateColumn><telerik:GridTemplateColumn HeaderText="Acc-No" UniqueName="TemplateColumn3">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox18" runat="server" Enabled="false" Text='<%# Bind("account_id")%>'></asp:TextBox></EditItemTemplate><ItemTemplate>
                <asp:Label ID="Label15" runat="server" Text='<%# Bind("account_id")%>'></asp:Label></ItemTemplate></telerik:GridTemplateColumn><telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmText="Are you sure you want to delete the selected row?" ImageUrl="Image/empty_bin.png" UniqueName="column">
                    <HeaderStyle BorderStyle="None" width="15px" />
                </telerik:GridButtonColumn>
                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Edit" ImageUrl="Image/edit.png" UniqueName="column1">
                    <HeaderStyle BorderStyle="None" width="15px" />
                </telerik:GridButtonColumn>   
    </Columns>
</MasterTableView>

<FilterMenu EnableTheming="True"><CollapseAnimation Duration="200" Type="OutQuint" />
</FilterMenu>
                    
                </telerik:RadGrid>
                    </center>
            </telerik:RadPageView></telerik:RadMultiPage>
            </td>
        </tr>
        <tr>
            <td class="auto-style121">&nbsp;</td>
            <td class="auto-style122">&nbsp;</td>
            <td class="auto-style16">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnsave" runat="server" BackColor="#FF9933" BorderColor="#FF9933" Text="Save" Width="91px" />
                    </td>
            <td class="auto-style55">
                    <asp:Button ID="btnclear" runat="server" BackColor="#FF9933" BorderColor="#FF9933" Text="Clear" Width="91px" />
                </td>
        </tr>
    </table>
            <br />
            <br />
</div>
    
        
</form>
</body>
</html>
