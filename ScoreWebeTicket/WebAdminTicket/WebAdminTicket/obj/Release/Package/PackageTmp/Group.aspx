<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Group.aspx.vb"  Inherits="WebTarget.Group" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script> 
<script type="text/javascript">
    $(document).ready(function () {
        SearchText();
    });
    function SearchText() {
        $(".autosuggest").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "Group.aspx/GetAutoCompleteData",
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
            margin-left: 40px;
        }
        #txtSearch1 {
            width: 166px;
            margin-left: 40px;
        }
        .auto-style15 {
            width: 358px;
            }
        .auto-style16 {
         width: 6px;
     }
        
.RadGrid_Black
{
	border:1px solid #1c1c1c;
}

.RadGrid_Black
{
	font:11px "segoe ui",arial,sans-serif;
}

.RadGrid_Black
{
	outline-color:#858585;
}

.RadGrid_Black
{
	background:#313131;
	color:#858585;
}

.RadGrid_Black
{
	border:1px solid #1c1c1c;
}

.RadGrid_Black
{
	font:11px "segoe ui",arial,sans-serif;
}

.RadGrid_Black
{
	outline-color:#858585;
}

.RadGrid_Black
{
	background:#313131;
	color:#858585;
}

.MasterTable_Black
{
	border-collapse:separate !important;
}

.MasterTable_Black
{
	font:11px "segoe ui",arial,sans-serif;
}

.RadGrid_Black *
{
	outline-color:#858585;
}

.MasterTable_Black
{
	border-collapse:separate !important;
}

.MasterTable_Black
{
	font:11px "segoe ui",arial,sans-serif;
}

.RadGrid_Black *
{
	outline-color:#858585;
}

.GridHeader_Black
{
	color:#006a96;
	text-decoration:none;
}

.GridHeader_Black
{
	border-top:1px solid #3e3e3e;
	border-bottom:1px solid #171717;
	background:url('mvwres://Telerik.Web.UI, Version=2008.2.826.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Black.Grid.sprite.gif') 0 0 repeat-x #202020;
	padding:9px 7px 10px 11px;
	text-align:left;
	font-size:1.2em;
	font-weight:normal;
}

.GridHeader_Black
{
	color:#006a96;
	text-decoration:none;
}

.GridHeader_Black
{
	border-top:1px solid #3e3e3e;
	border-bottom:1px solid #171717;
	background:url('mvwres://Telerik.Web.UI, Version=2008.2.826.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Black.Grid.sprite.gif') 0 0 repeat-x #202020;
	padding:9px 7px 10px 11px;
	text-align:left;
	font-size:1.2em;
	font-weight:normal;
}

.GridPager_Black
{
	color:#aaa;
}

.GridPager_Black
{
	line-height:26px;
}

.GridPager_Black
{
	color:#aaa;
}

.GridPager_Black
{
	line-height:26px;
}

.PagerLeft_Black
{
	float:left;
}

.PagerLeft_Black
{
	float:left;
}

.RadGrid_Black .rgPagePrev
{
	background-position:4px -992px;
}

.RadGrid_Black .rgPagePrev
{
	width:16px;
	height:16px;
	border:0;
	padding:0;
	background-color:transparent;
	background-image:url('mvwres://Telerik.Web.UI, Version=2008.2.826.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Black.Grid.sprite.gif');
	background-repeat:no-repeat;
	vertical-align:middle;
	cursor:pointer;
}

.RadGrid_Black .rgPagePrev
{
	background-position:4px -992px;
}

.RadGrid_Black .rgPagePrev
{
	width:16px;
	height:16px;
	border:0;
	padding:0;
	background-color:transparent;
	background-image:url('mvwres://Telerik.Web.UI, Version=2008.2.826.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Black.Grid.sprite.gif');
	background-repeat:no-repeat;
	vertical-align:middle;
	cursor:pointer;
}

.RadGrid_Black .rgPageNext
{
	background-position:-20px -992px;
}

.RadGrid_Black .rgPageNext
{
	width:16px;
	height:16px;
	border:0;
	padding:0;
	background-color:transparent;
	background-image:url('mvwres://Telerik.Web.UI, Version=2008.2.826.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Black.Grid.sprite.gif');
	background-repeat:no-repeat;
	vertical-align:middle;
	cursor:pointer;
}

.RadGrid_Black .rgPageNext
{
	background-position:-20px -992px;
}

.RadGrid_Black .rgPageNext
{
	width:16px;
	height:16px;
	border:0;
	padding:0;
	background-color:transparent;
	background-image:url('mvwres://Telerik.Web.UI, Version=2008.2.826.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Black.Grid.sprite.gif');
	background-repeat:no-repeat;
	vertical-align:middle;
	cursor:pointer;
}

.PagerRight_Black
{
	float:right;
}

.PagerRight_Black
{
	float:right;
}

        </style>
</head>
<body>
    
<form id="form1" runat="server">
   
<div style="text-align: center; height: 565px;">
  
    <p style="font-size: large; color: #00CC00; text-align: left;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </p>
    <p style="font-size: large; color: #00CC00; text-align: left; background-color: #515151;">
        <strong style="color: #b6ff00">Group</strong></p>
    <table width="100%" height="100%">
        <tr>
            <td class="auto-style16" ></td>
            <td class="auto-style15" valign="top" rowspan="4" ><br />
&nbsp;Group&nbsp; Code :&nbsp; <asp:TextBox ID="txtcode" runat="server" Height="23px" style="text-align: left" MaxLength="12"></asp:TextBox>
                &nbsp; 
                <br />
                Group Name : <asp:TextBox ID="txtname" runat="server" Height="23px" MaxLength="20"></asp:TextBox>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Role : &nbsp;&nbsp;<asp:TextBox ID="txtSearch" class="autosuggest" runat="server" Height="22px" style="margin-left: 2px" Width="149px" MaxLength="20"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" BorderStyle="None" Height="29px" Text="Add" Width="31px" />
                <br />
                
                   <center> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 

                    <telerik:RadGrid ID="RadGrid2" runat="server" AllowPaging="True"  AutoGenerateColumns="False" GridLines="None" Height="232px" Skin="Black" Width="211px">
                        <MasterTableView>
                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn>
                                <HeaderStyle Width="500px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="Role" DataField="column">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn UniqueName="DelteColumn" CommandName="Delete" ImageUrl="Image/Delete.png" ConfirmText="Are you sure you want to delete the selected row?" ButtonType="ImageButton">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                        <FilterMenu EnableTheming="True">
                            <CollapseAnimation Duration="200" Type="OutQuint" />
                        </FilterMenu>
                    </telerik:RadGrid>
                               
                       <br />
                </center>
                &nbsp;&nbsp;&nbsp; <asp:Button ID="btnsave" runat="server" BackColor="#FF9933" BorderColor="#FF9933" Text="Save" Width="91px" />
    
                &nbsp;<asp:Button ID="btnclear" runat="server" BackColor="#FF9933" BorderColor="#FF9933" Text="Clear" Width="91px" />
    
                <br />
    
                <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;
    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        
                </td>
            <td valign="top" style="text-align: left">
                <br />
                 <asp:UpdatePanel runat="server" >
           <ContentTemplate>
                          
                   <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" GridLines="None" PageSize="13">
<MasterTableView>
<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
    <Columns>
        <telerik:GridTemplateColumn HeaderText="No" UniqueName="TemplateColumn6" DataField="usergroup_id">
            <EditItemTemplate>
                           <asp:TextBox ID="TextBox19" runat="server" Text='<%# Bind("usergroup_id")%>' Enabled="False"></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate >                         
                           <asp:Label ID="Label19" runat="server" Text='<%# Eval("usergroup_id")%>' visible="false"></asp:Label>
                           <asp:Label ID="lblNo" runat="server" Text='<%# Eval("Row")%>'></asp:Label>
                       </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" />
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn HeaderText="Cre-by" UniqueName="TemplateColumn" DataField="create_by">
            <EditItemTemplate>
                           <asp:TextBox ID="TextBox1" runat="server" Text='<%# bind("create_by") %>' Enabled="False"></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate >                         
                           <asp:Label ID="Label9" runat="server" Text='<%# eval("create_by") %>'></asp:Label>
                       </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" />
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn HeaderText="Cre-On" UniqueName="TemplateColumn1" DataField="create_on">
            <EditItemTemplate>
                           <asp:TextBox ID="TextBox2" runat="server" Text='<%# bind("create_on") %>' Enabled="False"></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate >                         
                           <asp:Label ID="Label10" runat="server" Text='<%# eval("create_on") %>'></asp:Label>
                       </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" width="130px"/>
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn HeaderText="Up-by" UniqueName="TemplateColumn2" DataField="update_by">
            <EditItemTemplate>
                           <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("update_by")%>' Enabled="False"></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate >                         
                           <asp:Label ID="Label11" runat="server" Text='<%# Eval("update_by")%>'></asp:Label>
                       </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" />
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn HeaderText="Up-On" UniqueName="TemplateColumn3" DataField="update_on">
            <EditItemTemplate>
                           <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("update_on")%>' Enabled="False"></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate >                         
                           <asp:Label ID="Label12" runat="server" Text='<%# Eval("update_on")%>'></asp:Label>
                       </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" />
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn HeaderText="G-Code" UniqueName="TemplateColumn4" DataField="group_code">
            <EditItemTemplate>
                           <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("group_code")%>' Enabled="False"></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate >                         
                           <asp:Label ID="Label13" runat="server" Text='<%# Eval("group_code")%>'></asp:Label>
                       </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center" />
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn HeaderText="G-Name" UniqueName="TemplateColumn5" DataField="group_name">
            <EditItemTemplate>
                           <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("group_name")%>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate >                         
                           <asp:Label ID="Label14" runat="server" Text='<%# Eval("group_name")%>'></asp:Label>
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
                
                   </td>
        </tr>
        </table>
    
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;

</div>
    
</form>
               
</body>
</html>
