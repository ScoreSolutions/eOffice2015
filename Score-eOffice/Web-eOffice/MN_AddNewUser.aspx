<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="MasterPage_Basic.master"
    CodeFile="MN_AddNewUser.aspx.vb" Inherits="_AddNewUser" %>
    <%@ Register src="UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc1" %>

<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="cphMain">
  
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <table width="400" border="1" align="center" cellpadding="0" class="dataTable">
                    <tr>
                        <td align="center" class="dataTableHeader">
                            User Information
                        </td>
                    </tr>
                    <tr>
                        <td class="dataTableCell">
                            <table align="center">
                                <tr>
                                    <td style="width: 111px">
                                        Employee Id:
                                    </td>
                                    <td align="left" style="width: 159px">
                                        <asp:TextBox CssClass="textboxRequired" Width="150" ID="txtEmployee_Id" MaxLength="20"
                                            runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 111px">
                                        Pre Name:
                                    </td>
                                    <td align="left" style="width: 159px">
                                        <asp:DropDownList ID="DrpPreName" runat="server" DataTextField="Prename_Desc" DataValueField="Id"
                                            Width="150px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 111px">
                                        First Name:
                                    </td>
                                    <td align="left" style="width: 159px">
                                        <asp:TextBox CssClass="textboxRequired" Width="150" ID="txtFirstName" MaxLength="20"
                                            runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 111px">
                                        Last Name:
                                    </td>
                                    <td align="left" style="width: 159px">
                                        <asp:TextBox CssClass="textboxRequired" Width="150" ID="txtLastName" MaxLength="20"
                                            runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Select Group:
                                    </td>
                                    <td align="left">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="drpGroupShow" runat="server" AutoPostBack="true" DataValueField="Id"
                                                    DataTextField="group_name" Width="150px" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Department:
                                    </td>
                                    <td align="left">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddl_Dep" runat="server" Width="150px" 
                                                    DataTextField="department_desc" DataValueField="id">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Position:
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddl_pos" runat="server" Width="150px" 
                                                    DataTextField="position_desc" DataValueField="id">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        email:
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                               <asp:TextBox runat="server"  Width="150" ID="txtemail" MaxLength="50" ></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        Mobile:
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                               <asp:TextBox  runat="server" Width="150" ID="txtmobile" MaxLength="10" 
                                                    onkeypress="validateNumericOnly(this,event);"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        Start Date:
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                               <uc1:txtDate ID="txtStartDate" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        End Date:
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                               <uc1:txtDate ID="txtEndDate" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <table width="400" border="1" align="center" cellpadding="0" class="dataTable">
                    <tr>
                        <td align="center" class="dataTableHeader">
                            Login Information
                        </td>
                    </tr>
                    <tr>
                        <td class="dataTableCell">
                            <table align="center">
                                <tr>
                                    <td style="width: 111px">
                                        Username:
                                    </td>
                                    <td align="left" style="width: 159px">
                                        <asp:TextBox CssClass="textboxRequired" Width="150" ID="txtUserName" MaxLength="20"
                                            runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 111px">
                                        Password:
                                    </td>
                                    <td align="left" style="width: 159px">
                                        <asp:TextBox CssClass="textboxRequired" Width="150" ID="txtPass" MaxLength="20" runat="server"
                                            TextMode="Password" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 111px">
                                        Re-Type Password:
                                    </td>
                                    <td align="left" style="width: 159px">
                                        <asp:TextBox CssClass="textboxRequired" Width="150" ID="txtPass1" MaxLength="20"
                                            runat="server" TextMode="Password" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <center>
                    <br />
                    <br />
                    <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="buttonCreate" 
                        Width="49px" />
                &nbsp;<asp:Button ID="btnCancle" Text="Cancle" runat="server" 
                        CssClass="buttonNormal" />
                </center>
            </td>
            <td valign="top">
            
                <asp:Repeater ID="rptShowUser" runat="server">
                    <HeaderTemplate>
                        <table align="center" class="dataTable" width="600" border="1">
                            <tr>
                                <td colspan="6" align="center" class="dataTableHeader">
                                    User List
                                </td>
                            </tr>
                            <tr align="center" class="dataTableSubHeader">
                                <td>
                                    No.
                                </td>
                                <td>
                                    First Name
                                </td>
                                <td>
                                    Last Name
                                </td>
                                 <td>
                                    Position Name
                                </td>
                                <td>
                                    Group Name
                                </td>
                                 <td>
                                    Edit/Delete
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr align="center" class="dataTableCell">
                            <td align="center">
                                <%#Container.ItemIndex + 1%>
                            </td>
                            <td align="left">
                                <%#Container.DataItem("Name")%>
                            </td>
                            <td align="left">
                                <%#container.dataitem("SurName") %>
                            </td>
                            <td align="left">
                                <%#Container.DataItem("position_desc")%>
                            </td>
                            <td align="left">
                                <%#container.dataitem("group_name") %>
                            </td>
                            <td align="center">
                             <asp:Button CssClass ="buttonNormal" ID="btnEdit" text ="Edit" runat ="server" CommandArgument='<%#container.dataitem("id") %>' CommandName="Edit"/>&nbsp;<asp:Button CssClass ="buttonCritical" ID="btnDelete" text="Delete" runat ="server" CommandArgument='<%#container.dataitem("id") %>' CommandName="Delete" OnClientClick ="return confirm('Are you sure you want to delete?');" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr align="center" class="altdataTableCell">
                            <td align="center">
                                <%#Container.ItemIndex + 1%>
                            </td>
                            <td align="left">
                                <%#container.DataItem("Name") %>
                            </td>
                            <td align="left">
                                <%#container.dataitem("Surname") %>
                            </td>
                            <td align="left">
                                <%#Container.DataItem("position_desc")%>
                            </td>
                            <td align="left">
                                <%#container.dataitem("group_name") %>
                            </td>
                             <td align="center"><asp:Button CssClass ="buttonNormal" ID="btnEdit" text ="Edit" runat ="server" CommandArgument='<%#container.dataitem("id") %>' CommandName="Edit"/>&nbsp;<asp:Button CssClass ="buttonCritical" ID="btnDelete" text="Delete" runat ="server" CommandArgument='<%#container.dataitem("id") %>' CommandName="Delete" OnClientClick ="return confirm('Are you sure you want to delete?');" /></td>
                        </tr>
                    </AlternatingItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            
            
            </td>
        </tr>
    </table>
    <%--<%#container.dataitem("group_name") %>--%>
    
    <center>
        <br />
     <asp:Label ID="lblID" runat="server" Visible="False">0</asp:Label><br />
        <asp:Label ID="lblError" runat="server" Visible="false" Width="400" CssClass="errorBox" />
        <br />
        <br />
    </center>
    
   <%-- <%#Container.ItemIndex + 1%> --%>
</asp:Content>
