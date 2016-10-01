<%@ Page Language="vb" AutoEventWireup="false"  CodeBehind="Role.aspx.vb" Inherits="WebTarget.WebForm3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
<link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script> 
<script type="text/javascript">
    $(document).ready(function () {
        SearchText();
        SearchText1();
    });
    function SearchText1() {
        $(".autosuggest1").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "Role.aspx/GetAutoCompleteData1",
                    data: "{'username':'" + document.getElementById('txtSearch1').value + "'}",                  
                    dataType: "json",
                    success: function (data) {
                        response(data.d);
                    },
                    error: function (result) {
                        alert("Error");
                    }
                });
            }
        });
    }
    function SearchText() {
        $(".autosuggest").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "Role.aspx/GetAutoCompleteData",
                    data: "{'username':'" + document.getElementById('txtSearch').value + "'}",
                    dataType: "json",
                    success: function (data) {
                        response(data.d);
                    },
                    error: function (result) {
                        alert("Error");
                    }
                });
            }
        });
    }
</script>  
    <style type="text/css">
        #txtSearch0 {
            width: 181px;
        }
        #txtSearch {
            width: 166px;
            margin-left: 0px;
        }
        #txtSearch1 {
            width: 166px;
            margin-left: 40px;
        }
        .auto-style4 {
            width: 49px;
            height: 915px;
        }
        .auto-style15 {
            width: 254px;
            height: 915px;
        }
        .auto-style16 {
            height: 915px;
        }
        </style>
</head>
<body>
<form id="form1" runat="server">
<div style="text-align: left;">
  
    <p style="font-size: large; color: #00CC00; text-align: left; text-decoration: underline;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </p>
    <p style="font-size: large; color: #00CC00; text-align: left; background-color: #515151;">
        <strong style="color: #b6ff00">Role</strong></p>
    <table width="100%">
        <tr>
            <td class="auto-style4" ></td>
            <td class="auto-style15" valign="top" rowspan="4" ><br />
&nbsp; Role Code : <asp:TextBox ID="txtcode" runat="server" Height="23px" style="text-align: left" MaxLength="12"></asp:TextBox>
                &nbsp;<br />
&nbsp;Role Name
                :
        <asp:TextBox ID="txtname" runat="server" Height="23px" Rows="12"></asp:TextBox>
                <br />
    
                <br />
               <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Height="23px" SelectedIndex="0" Width="301px" Skin="Black" style="margin-left: 0px; text-align: center;" BackColor="#292929">
            <tabs>
                <telerik:RadTab runat="server" Text="Responsibility" PageViewID="RadPageView1" Font-Size="15pt" Selected="True">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Project Code" PageViewID="RadPageView2" Font-Size="15pt">
                </telerik:RadTab>
            </tabs>
    </telerik:RadTabStrip>
        
    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="300px" SelectedIndex="1" style="margin-left: 0px" Height="16px" BorderStyle="None">
        <telerik:RadPageView ID="RadPageView1" runat="server" Width="300px" Selected="true" BorderColor="#FF6600" Height="350px" BackColor="#1F1F1F">
            <asp:TextBox ID="txtSearch1" runat="server" class="autosuggest1" size="12" type="text" MaxLength="20"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" Text="Add" />
            <br />
            <br />
                <center>
                    <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" GridLines="None" Height="232px" Skin="Black" Width="243px">
                        <MasterTableView>
                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn>
                                <HeaderStyle Width="500px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="Responsbility" DataField="column">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ImageUrl="Image/Delete.png" ConfirmText="Are you sure you want to delete the selected row?" UniqueName="column1">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                        <FilterMenu EnableTheming="True">
                            <CollapseAnimation Duration="200" Type="OutQuint" />
                        </FilterMenu>
                    </telerik:RadGrid>
                </center>         
            <br />
            <br />
            <br />
</telerik:RadPageView>
     
        <telerik:RadPageView ID="RadPageView2" runat="server" Width="300px" style="text-align: center" BorderColor="#FF6600" Height="350px" BackColor="#1F1F1F">
            <asp:Textbox ID="txtSearch" runat="server" class="autosuggest" type="text" size="12" MaxLength="20" />
            <asp:Button ID="Button2" runat="server" Text="Add" />
            <br />
            <br />
               <center>
            <telerik:RadGrid ID="RadGrid3" runat="server" AllowPaging="True"  AutoGenerateColumns="False" GridLines="None" Height="232px" Skin="Black" Width="243px">
                <MasterTableView>
                    <RowIndicatorColumn>
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn>
                        <HeaderStyle Width="500px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn HeaderText="Project" DataField="column">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ImageUrl="Image/Delete.png" ConfirmText="Are you sure you want to delete the selected row?" UniqueName="column1">
                        </telerik:GridButtonColumn>
                    </Columns>
                </MasterTableView>
                <FilterMenu EnableTheming="True">
                    <CollapseAnimation Duration="200" Type="OutQuint" />
                </FilterMenu>
            </telerik:RadGrid></center>
            <br />
</telerik:RadPageView>
    </telerik:RadMultiPage>
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnsave" runat="server" BackColor="#FF9933" BorderColor="#FF9933" Text="Save" Width="91px" style="height: 26px" /> <asp:Button ID="btnclear" runat="server" BackColor="#FF9933" BorderColor="#FF9933" Text="Clear" Width="91px" />
            </td>
            <td valign="top" style="text-align: left" class="auto-style16">
                <br />
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" PageSize="17">
<MasterTableView>
<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
    <Columns>
        <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="No" DataField="role_id">
            <EditItemTemplate>
                           <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("role_id")%>' Enabled="False"></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate >                         
                           <asp:Label ID="Label9" runat="server" Text='<%# Eval("role_id")%>' visible="false"></asp:Label>
                           <asp:Label ID="lblNo" runat="server" Text='<%# Eval("Row")%>'></asp:Label>
                       </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" />
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn UniqueName="TemplateColumn1" HeaderText="Create" DataField="create_by">
            <EditItemTemplate>
                           <asp:TextBox ID="TextBox2" runat="server" Text='<%# bind("create_by") %>' Enabled="False"></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate >                         
                           <asp:Label ID="Label10" runat="server" Text='<%# eval("create_by") %>'></asp:Label>
                       </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" />
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn UniqueName="TemplateColumn2" HeaderText="Create On" DataField="create_on">
            <EditItemTemplate>
                           <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("create_on")%>' Enabled="False"></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate >                         
                           <asp:Label ID="Label11" runat="server" Text='<%# Eval("create_on")%>'></asp:Label>
                       </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" />
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn UniqueName="TemplateColumn3" HeaderText="Update" DataField="update_by">
            <EditItemTemplate>
                           <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("update_by")%>' Enabled="False"></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate >                         
                           <asp:Label ID="Label12" runat="server" Text='<%# Eval("update_by")%>'></asp:Label>
                       </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" />
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn UniqueName="TemplateColumn4" HeaderText="Update On" DataField="update_on">
            <EditItemTemplate>
                           <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("update_on")%>' Enabled="False"></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate >                         
                           <asp:Label ID="Label13" runat="server" Text='<%# Eval("update_on")%>'></asp:Label>
                       </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" />
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn UniqueName="TemplateColumn5" HeaderText="R-Code" DataField="role_code">
            <EditItemTemplate>
                           <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("role_code")%>' Enabled="False"></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate >                         
                           <asp:Label ID="Label14" runat="server" Text='<%# Eval("role_code")%>'></asp:Label>
                       </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" />
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn UniqueName="TemplateColumn6" HeaderText="R-Name" DataField="role_name">
            <EditItemTemplate>
                           <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("role_name")%>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate >                         
                           <asp:Label ID="Label15" runat="server" Text='<%# Eval("role_name")%>'></asp:Label>
                       </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" />
        </telerik:GridTemplateColumn>
         <telerik:GridButtonColumn UniqueName="DelteColumn" Text="Delete"  CommandName="Delete" ButtonType="ImageButton" ImageUrl="Image/empty_bin.png" ConfirmText="Are you sure you want to delete the selected row?">
        </telerik:GridButtonColumn>
        <telerik:GridButtonColumn UniqueName="EditColumn" Text="Edit"  CommandName="Edit" ButtonType="ImageButton" ImageUrl="Image/edit.png">
        </telerik:GridButtonColumn>
    </Columns>
</MasterTableView>

<FilterMenu EnableTheming="True">
<CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
</FilterMenu>
                </telerik:RadGrid>
                           </ContentTemplate>
                </asp:UpdatePanel>
                <br />
    
                   </td>
        </tr>      
        </table>             
</div>
</form>
</body>
</html>
