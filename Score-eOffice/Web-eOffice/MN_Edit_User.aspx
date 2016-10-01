<%@ Page Language="VB" AutoEventWireup="false"  MasterPageFile="MasterPage_Basic.master" CodeFile="MN_Edit_User.aspx.vb" Inherits="_edit_user" %>
<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="cphMain">
    <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label><br />
<asp:PlaceHolder id ="phEditUser" runat = "server">
<table width="400" border="1" align="center"   cellpadding="0"  class="dataTable">
  <tr>
    <td align ="center" class="dataTableHeader">Edit User </td>
  </tr>
  <tr>
    <td class="dataTableCell">
        <table align ="center">
        <tr><td>Employee Id:</td><td align="left"><asp:TextBox cssclass="textboxRequired" Width="150" ID="txtID"  MaxLength="20" runat ="server" /></td></tr>
        <tr><td>First Name:</td><td align="left"><asp:TextBox cssclass="textboxRequired" Width="150" ID="txtFirstName"  MaxLength="20" runat ="server" /></td></tr>
        <tr ><td>Last Name:</td><td align="left"><asp:TextBox cssclass="textboxRequired" Width="150" ID="txtLastName"  MaxLength="20" runat ="server" /></td></tr>
        <tr ><td>User name:</td><td align="left"><asp:TextBox cssclass="textboxReadOnly" Width="150" ID="txtUserName"  MaxLength="20" runat ="server"  ReadOnly="true" /></td></tr>
        <tr ><td>User Group:</td><td align="left"><asp:DropDownList ID="drpGroupShow" runat="server" AutoPostBack ="true" /></td></tr>
         <tr ><td>User Department:</td><td align="left"><asp:DropDownList ID="ddl_dep" runat="server" AutoPostBack ="true" /></td></tr>
          <tr ><td>User Position:</td><td align="left"><asp:DropDownList ID="ddl_pos" runat="server" AutoPostBack ="true" /></td></tr>

        </table>
    </td>
  </tr>

</table>
<table align="center" class ="dataTable" width="400">
    <tr class ="dataTableHeader"><td colspan="3" > 
        <table width ="100%" align="left">
            <tr><td  align="center" >Allow Access to these Menu</td><td align="right"> <asp:button ID="btnShowHide" runat="server" Text="Hide" CssClass="buttonNormal" /></td>
            </tr>
        </table>
        </td>

    </tr>
    <tr class="dataTableSubHeader" align="center">
        <td  ></td>
        <td >SubMenu</td>
        <td >MainMenu</td>
    </tr>
    
<asp:Repeater runat ="server" id="rptUbaMenu">
<ItemTemplate>
    <tr>
        <td class ="dataTableCell" align="center"><asp:CheckBox ID="chkMenu" runat="server"  value='<%#Container.DataItem("menu_id")%>'  OnCheckedChanged="checkedChanged"/></td>
        <td class ="dataTableCell"  runat="server" id="td2">&nbsp;&nbsp;<%#Container.DataItem("menu_text")%></td>
        <td class ="dataTableCell"  runat="server" id="td3">&nbsp;&nbsp;<%#Container.DataItem("parent_name")%></td>
    </tr>
</ItemTemplate>
<AlternatingItemTemplate>
    <tr>
        <td class ="altDataTableCell" align="center"><asp:CheckBox ID="chkMenu" runat="server"  value='<%#Container.DataItem("menu_id")%>'  OnCheckedChanged="checkedChanged"/></td>
        <td class ="altDataTableCell"  runat="server" id="td2">&nbsp;&nbsp;<%#Container.DataItem("menu_text")%></td>
        <td class ="altDataTableCell"  runat="server" id="td3">&nbsp;&nbsp;<%#Container.DataItem("parent_name")%></td>
    </tr>
</AlternatingItemTemplate>
</asp:Repeater>
    <tr>
        <td colspan =3 align ="center" >
        <table><tr>
            <td><asp:Button ID ="btnSave" Text="Update" runat="server" CssClass="buttonNormal" /></td>
            <td><asp:button id ="btnCancel" text="Cancel " runat="server" CssClass="buttonWarning" /> </td>
        </tr></table>
        </td>
    </tr>

</table>
<center><asp:label ID ="lblError" runat = "server" Visible = "false" Width ="400" CssClass = "errorBox" /> <br /><br /></center>
</asp:PlaceHolder>

<asp:Repeater  ID = "rptShowUser" runat = "server">

<HeaderTemplate>
    <table align="center" class ="dataTable" width="400" border="1">
    <tr>
    <td colspan="5"  align ="center" class ="dataTableHeader">Edit User </td>
    </tr>
    <tr  align ="center"  class ="dataTableSubHeader">
        <td>No.</td>
        <td>First Name</td>
        <td>Last Name</td>
        <td>Group Name</td>
        <td>Edit/Delete</td>
              
    </tr>
</HeaderTemplate>

<ItemTemplate>
    <tr    class ="dataTableCell">
        <td align ="center"><%#Container.ItemIndex + 1%></td>
        <td align ="left"><%#Container.DataItem("name")%></td>
        <td align ="left"><%#Container.DataItem("surname")%></td>
        <td align ="center"><%#Container.DataItem("group_name")%></td>
        <td align="right"><asp:Button CssClass ="buttonNormal" ID="btnEdit" text ="Edit" runat ="server" CommandArgument='<%#container.dataitem("Member_id") %>' CommandName="Edit"/>&nbsp;<asp:Button CssClass ="buttonCritical" ID="btnDelete" text="Delete" runat ="server" CommandArgument='<%#container.dataitem("Member_id") %>' CommandName="Delete" OnClientClick ="return confirm('Are you sure you want to delete?');" /></td>
        
    </tr>
</ItemTemplate>
<AlternatingItemTemplate>
    <tr class ="altdataTableCell">
        <td align ="center"><%#Container.ItemIndex + 1%></td>
        <td align ="left"><%#Container.DataItem("name")%></td>
        <td align ="left"><%#Container.DataItem("surname")%></td>
        <td align ="center"><%#Container.DataItem("group_name")%></td>
        <td align="right"><asp:Button CssClass ="buttonNormal" ID="btnEdit" text ="Edit" runat ="server" CommandArgument='<%#container.dataitem("Member_id") %>' CommandName="Edit"/>&nbsp;<asp:Button CssClass ="buttonCritical" ID="btnDelete" text="Delete" runat ="server" CommandArgument='<%#container.dataitem("Member_id") %>' CommandName="Delete" OnClientClick ="return confirm('Are you sure you want to delete?');" /></td>
        
    </tr>
</AlternatingItemTemplate>

<FooterTemplate>
</table>
</FooterTemplate>
</asp:Repeater>
<center><asp:Label  width ="400" id="lblDelete" runat ="server" Visible="false" CssClass="successBox" /></center>


<asp:checkBoxList ID="chkSelectedMenu" runat="server" Visible="false"/>

</asp:Content>

