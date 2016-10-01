<%@ Page Language="VB" AutoEventWireup="false"  MasterPageFile="MasterPage_Basic.master" CodeFile="ET_AddNewClient.aspx.vb" Inherits="_ET_AddNewClient" %>
<%@ Register src="UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="__js/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="__js/jquery-ui.js"></script>
    <link href="__css/jquery-ui.css" rel="stylesheet" type="text/css" />
    
    <script>
      $(function() {
        $("#tabs").tabs();
      });
  </script>
</asp:Content>
<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="cphMain">
<br />
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td width="30%">
            <br />
            <asp:UpdatePanel ID="AccountUpdatePanel" runat="server">
                <ContentTemplate>
                    <table border="1"  align="center" cellpadding="0" class="dataTable"  style="text-align: center">
                      <tr>
                        <td align ="center" class="dataTableHeader" >Account
                        </td>
                      </tr>
                      <tr>
                        <td class="dataTableCell" style="width: 400px">
                              <table align ="center" border="0" width="100%">
                                    <tr>
                                      <td style="width: 150px">&nbsp;</td>
                                      <td align="left" style="width: 150px">
                                          <asp:Label ID="lblAccountId" runat="server" Width="136px" Visible="False" Text="0" ></asp:Label></td>
                                      <td align="left" >
                                          <asp:Label ID="lblTempSQL" runat="server" Visible="False" Width="1px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="right" >Account Code:</td>
                                        <td align="left" >
                                            <asp:TextBox cssclass="textboxRequired" Width="200px" ID="txtAccountCode"  MaxLength="100" runat ="server" />
                                        </td>
                                        <td align="left" >
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAccountCode"
                                                ErrorMessage="*" ValidationGroup="ACCOUNT" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" >Account Name:</td>
                                        <td align="left" >
                                            <asp:TextBox cssclass="textboxRequired" Width="200px" ID="txtAccountName"  MaxLength="100" runat="server" />
                                        </td>
                                        <td align="left" >
                                            <asp:RequiredFieldValidator ID="vldAccountName" runat="server" ControlToValidate="txtAccountName"
                                                ErrorMessage="*" ValidationGroup="ACCOUNT" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr >
                                        <td align="right" >Address:</td>
                                        <td align="left" colspan="2" valign="top">
                                            <asp:TextBox cssclass="textboxNormal" Width="200" ID="txtAddress"  MaxLength="255" runat ="server" TextMode="MultiLine" Height="60px" BackColor="White" />
                                            
                                        </td>
                                    </tr>
                                    <tr >
                                        <td align="right" >Province :</td>
                                        <td align="left" colspan="2" valign="top">
                                            <asp:DropDownList ID="ddlProvince" runat="server" Width="200" AutoPostBack="true" ></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr >
                                        <td align="right" >District :</td>
                                        <td align="left" colspan="2" valign="top">
                                            <asp:DropDownList ID="ddlDistrict" runat="server" Width="200" AutoPostBack="true" ></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr >
                                        <td align="right" >Subdistrict :</td>
                                        <td align="left" colspan="2" valign="top">
                                            <asp:DropDownList ID="ddlSubdistrict" runat="server" Width="200"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                          <td align="right" >Postcode:</td>
                                          <td align="left" >
                                              <asp:TextBox cssclass="textboxNormal" Width="200" ID="txtPostcode"  MaxLength="5" runat ="server" /></td>
                                          <td align="left">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                          <td align="right" >Email:</td>
                                          <td align="left" >
                                              <asp:TextBox cssclass="textboxNormal" Width="200" ID="txtEmail"  MaxLength="50" runat ="server" /></td>
                                          <td align="left">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                            ErrorMessage="*" ValidationGroup="ACCOUNT" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr >
                                        <td align="right" >Tel No:</td>
                                        <td align="left" >
                                            <asp:TextBox cssclass="textboxNormal" Width="200" ID="txtTelNo"  MaxLength="50" runat ="server" />
                                        </td>
                                        <td align="left" ></td>
                                    </tr>
                                    <tr >
                                        <td align="right" >Fax No:</td>
                                        <td align="left" >
                                            <asp:TextBox cssclass="textboxNormal" Width="200" ID="txtFaxNo"  MaxLength="50" runat ="server" />
                                        </td>
                                        <td align="left" ></td>
                                    </tr>
                                    <tr >
                                        <td align="right" >Mobile No:</td>
                                        <td align="left" >
                                            <asp:TextBox cssclass="textboxNormal" Width="200" ID="txtMobile"  MaxLength="50" runat ="server" />
                                        </td>
                                        <td align="left" ></td>
                                    </tr>
                                    <tr >
                                        <td >&nbsp;</td>
                                        <td >&nbsp;</td>
                                        <td >&nbsp;</td>
                                    </tr>
                              </table>
                        </td>
                      </tr>
                    </table>
                    <center>
                        <br />
                        <asp:Button ID ="butQuery" Text="Search" runat="server" CssClass="buttonQuery" CausesValidation="False" />
                        <asp:Button ID ="butSave" Text="Save" runat="server" ValidationGroup="ACCOUNT"  CssClass="buttonCreate" />
                        <br />
                        <br />
                        <asp:label ID ="lblError" runat = "server" Visible = "false" Width ="400" CssClass = "errorBox"  /> <br />
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td width="70%" align="center" valign="top">
            <asp:Button ID ="butShowAll" Text="View All Account" runat="server" CssClass="buttonNormal" CausesValidation="False" /></center>
            <br />
            <asp:Repeater  ID = "rptShowClient" runat = "server">
                <HeaderTemplate>
                    <table align="center" class ="dataTable" width="95%" border="1">
                        <tr  align ="center"  class ="dataTableSubHeader">
                            <td Width ="5%">No.</td>
                            <td Width ="38%">Account Name</td>
                            <td Width ="20%">E Mail</td>
                            <td Width ="10%">Tel No</td>
                            <td Width ="10%">Mobile No</td>
                            <td Width ="17%">#</td>  
                        </tr>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr class ="dataTableCell">
                        <td align ="center"><%#Container.ItemIndex + 1%></td>
                        <td align ="left"><%#Container.DataItem("account_Name")%></td>
                        <td align ="left">&nbsp;<%#Container.DataItem("account_email")%></td>
                        <td align ="left">&nbsp;<%#Container.DataItem("account_tel_no")%></td>
                        <td align ="left">&nbsp;<%#Container.DataItem("account_mobile_no")%></td>
                        <td align="left">
                            <asp:Button CssClass ="buttonSelect" ID="butSelect" CausesValidation=false  text="Select" runat ="server" CommandArgument='<%#container.dataitem("Id") %>' CommandName="Select"/>
                            <asp:Button CssClass ="buttonCritical" ID="butDelete" CausesValidation=false  text="Delete" runat ="server" CommandArgument='<%#container.dataitem("Id") %>' CommandName="Delete"/>
                            <asp:Label ID="lblAccuntListID" runat="server" Text='<%#container.dataitem("Id") %>' Visible="false" ></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr  align ="center"  class ="altdataTableCell">
                        <td align ="center"><%#Container.ItemIndex + 1%></td>
                        <td align ="left">&nbsp;<%#Container.DataItem("account_Name")%></td>
                        <td align ="left">&nbsp;<%#Container.DataItem("account_email")%></td>
                        <td align ="left">&nbsp;<%#Container.DataItem("account_tel_no")%></td>
                        <td align ="left">&nbsp;<%#Container.DataItem("account_mobile_no")%></td>
                        <td align="left">
                            <asp:Button CssClass ="buttonSelect" ID="butSelect" CausesValidation=false text ="Select" runat ="server" CommandArgument='<%#container.dataitem("Id") %>' CommandName="Select"/>
                            <asp:Button CssClass ="buttonCritical" ID="butDelete" CausesValidation=false  text="Delete" runat ="server" CommandArgument='<%#container.dataitem("Id") %>' CommandName="Delete"/>
                            <asp:Label ID="lblAccuntListID" runat="server" Text='<%#container.dataitem("Id") %>' Visible="false" ></asp:Label>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <div id="tabs">
              <ul>
                <li><a href="#tabsContactPerson">Contact Person</a></li>
                <li><a href="#tabsBranch">Branch</a></li>
                <li><a href="#tabsProject">Project</a></li>
              </ul>
              <div id="tabsContactPerson">
                    <asp:UpdatePanel ID="upContact" runat="server">
                        <ContentTemplate>
                            <table align ="center" border="0" width="40%" class="dataTableCell" valign="center" >
                                <tr >
                                  <td align="left" style="width: 100px">
                                      <asp:Label ID="lblContactPersonID" runat="server"  Visible="False" Text="0" ></asp:Label></td>
                                  <td align="left" style="width: 75px">&nbsp;</td>
                                  <td>&nbsp;</td>
                                </tr>
                                <tr >
                                    <td align="right" >Pre Name:</td>
                                    <td align="left" >
                                        <asp:DropDownList ID="ddlContactPrename" runat="server" Width="250"  ></asp:DropDownList>
                                    </td>
                                    <td align="left" >
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" >First Name:</td>
                                    <td align="left" >
                                        <asp:TextBox cssclass="textboxRequired" Width="250px" ID="txtContactFirstName"  MaxLength="100" runat="server" />
                                    </td>
                                    <td align="left" >
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContactFirstName"
                                            ErrorMessage="*" ValidationGroup="CONTACT" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td align="right" >Last Name:</td>
                                    <td align="left" >
                                        <asp:TextBox cssclass="textboxRequired" Width="250px" ID="txtContactLastName"  MaxLength="100" runat="server" />
                                    </td>
                                    <td align="left" >
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtContactLastName"
                                            ErrorMessage="*" ValidationGroup="CONTACT" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td align="right" >Nickname:</td>
                                    <td align="left" >
                                        <asp:TextBox cssclass="textboxNormal" Width="250px" ID="txtContactNickname"  MaxLength="100" runat="server" />
                                    </td>
                                    <td align="left" ></td>
                                </tr>
                                <tr>
                                    <td align="right" >Position:</td>
                                    <td align="left" >
                                        <asp:TextBox cssclass="textboxNormal" Width="250px" ID="txtContactPositionName"  MaxLength="100" runat="server" />
                                    </td>
                                    <td align="left" ></td>
                                </tr>
                                <tr>
                                      <td align="right" >Email:</td>
                                      <td align="left" >
                                          <asp:TextBox cssclass="textboxNormal" Width="250" ID="txtContactEmail"  MaxLength="100" runat ="server" /></td>
                                      <td align="left">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtContactEmail"
                                        ErrorMessage="*" ValidationGroup="CONTACT" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr >
                                    <td align="right" >Mobile:</td>
                                    <td align="left" >
                                        <asp:TextBox cssclass="textboxNormal" Width="250" ID="txtContactMobile"  MaxLength="50" runat ="server" />
                                    </td>
                                    <td align="left" ></td>
                                </tr>
                            </table>
                            <center>
                                <br />
                                <asp:Button ID ="btnSaveContact" Text="Save" runat="server" ValidationGroup="CONTACT" CssClass="buttonCreate" />
                                <br />
                                <br />
                                <asp:label ID ="lblContactMessage" runat = "server" Visible = "false" Width ="400" CssClass = "errorBox"  /> <br />
                            </center>
                            
                            <asp:GridView ID="gvContactPersonList" runat="server" AutoGenerateColumns="False" 
                                AllowSorting="false"  Width="100%" AllowPaging="false"  >
                                <RowStyle CssClass="dataTableCell" />
                                <PagerSettings Visible="false" />
                                <HeaderStyle CssClass="dataTableSubHeader" />
                                <AlternatingRowStyle CssClass="altdataTableCell" />
                                <Columns> 
                                    <asp:BoundField DataField="no" HeaderText="No" >
                                        <HeaderStyle Width="30px" HorizontalAlign="Center"  />
                                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="contact_person_name" HeaderText="Name" HtmlEncode="false"  >
                                        <HeaderStyle HorizontalAlign="Center"  />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nickname" HeaderText="Nickname"  HtmlEncode="false" >
                                        <HeaderStyle Width="50px" HorizontalAlign="Center"  />
                                        <ItemStyle Width="50px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="position_name" HeaderText="Position" >
                                        <HeaderStyle Width="180px" HorizontalAlign="Center"  />
                                        <ItemStyle Width="180px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="email" HeaderText="Email"  >
                                        <HeaderStyle Width="250px" HorizontalAlign="Center"  />
                                        <ItemStyle Width="250px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="mobile" HeaderText="Mobile" >
                                        <HeaderStyle Width="100px" HorizontalAlign="Center"  />
                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="id" >
                                        <ControlStyle CssClass="zHidden" />
                                        <FooterStyle CssClass="zHidden" />
                                        <HeaderStyle CssClass="zHidden" />
                                        <ItemStyle CssClass="zHidden" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="#" >
                                        <ItemTemplate>
                                            <asp:Button CssClass ="buttonSelect" ID="butContactSelect" CausesValidation=false text ="Select" runat ="server" CommandArgument='<%#container.dataitem("id") %>' CommandName="Select"/>
                                            <asp:Button CssClass ="buttonCritical" ID="butContactDelete" CausesValidation=false  text="Delete" runat ="server" CommandArgument='<%#container.dataitem("Id") %>' OnClientClick="return confirm('Are you sure?');" CommandName="Delete"/>
                                        </ItemTemplate>
                                        <ItemStyle Width="140px" HorizontalAlign="Center" />
                                        <HeaderStyle Width="140px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
              </div>
              <div id="tabsBranch">
                    <asp:UpdatePanel ID="upBranch" runat="server">
                        <ContentTemplate>
                            <table align ="center" border="0" width="70%" class="dataTableCell" valign="center" >
                                <tr >
                                  <td align="left" style="width: 15%">
                                      <asp:Label ID="lblBranchID" runat="server"  Visible="False" Text="0" ></asp:Label></td>
                                  <td align="left" style="width:25%">&nbsp;</td>
                                  <td style="width:2%">&nbsp;</td>
                                  <td align="left" style="width:15%">&nbsp;</td>
                                  <td align="left" style="width:25%">&nbsp;</td>
                                  <td style="width:2%">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="right" >Branch Code:</td>
                                    <td align="left" >
                                        <asp:TextBox cssclass="textboxRequired" Width="200px" ID="txtBranchCode"  MaxLength="50" runat="server" />
                                    </td>
                                    <td align="left" >
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtBranchCode"
                                            ErrorMessage="*" ValidationGroup="BRANCH" SetFocusOnError="True"  ></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="right" >Branch Address:</td>
                                    <td align="left" >
                                        <asp:TextBox cssclass="textboxNormal" Width="200px" ID="txtBranchAddress"  MaxLength="50" runat="server" />
                                    </td>
                                    <td align="left" >&nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="right" >Branch Name:</td>
                                    <td align="left" >
                                        <asp:TextBox cssclass="textboxRequired" Width="200px" ID="txtBranchName"  MaxLength="255" runat="server" />
                                    </td>
                                    <td align="left" >
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtBranchName"
                                            ErrorMessage="*" ValidationGroup="BRANCH" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="right" >Province :</td>
                                    <td align="left" colspan="2" valign="top">
                                        <asp:DropDownList ID="ddlBranchProvince" runat="server" Width="200" AutoPostBack="true" ></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" >Email:</td>
                                    <td align="left" >
                                        <asp:TextBox cssclass="textboxNormal" Width="200" ID="txtBranchEmail"  MaxLength="50" runat ="server" /></td>
                                    </td>
                                    <td align="left" >
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail"
                                            ErrorMessage="*" ValidationGroup="BRANCH" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </td>
                                    <td align="right" >District :</td>
                                    <td align="left" colspan="2" valign="top">
                                        <asp:DropDownList ID="ddlBranchDistrict" runat="server" Width="200" AutoPostBack="true" ></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr >
                                    <td align="right" >Tel No:</td>
                                    <td align="left" >
                                        <asp:TextBox cssclass="textboxNormal" Width="200" ID="txtBranchTelNo"  MaxLength="50" runat ="server" />
                                    </td>
                                    <td align="left" ></td>
                                    <td align="right" >Subdistrict :</td>
                                    <td align="left" colspan="2" valign="top">
                                        <asp:DropDownList ID="ddlBranchSubdistrict" runat="server" Width="200"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr >
                                    <td align="right" >Fax No:</td>
                                    <td align="left" >
                                        <asp:TextBox cssclass="textboxNormal" Width="200" ID="txtBranchFaxNo"  MaxLength="50" runat ="server" />
                                    </td>
                                    <td align="left" ></td>
                                    <td align="right" >Postcode:</td>
                                    <td align="left" >
                                        <asp:TextBox cssclass="textboxNormal" Width="200px" ID="txtBranchPostcode"  MaxLength="50" runat="server" />
                                    </td>
                                    <td align="left" >&nbsp;</td>
                                </tr>
                                <tr >
                                    <td align="right" >Mobile No:</td>
                                    <td align="left" >
                                        <asp:TextBox cssclass="textboxNormal" Width="200" ID="txtBranchMobileNo"  MaxLength="50" runat ="server" />
                                    </td>
                                    <td align="left" ></td>
                                    <td align="right" >Contact Name:</td>
                                    <td align="left" >
                                        <asp:TextBox cssclass="textboxNormal" Width="200px" ID="txtBranchContactName"  MaxLength="100" runat="server" />
                                    </td>
                                    <td align="left" ></td>
                                </tr>
                            </table>
                            <center>
                                <br />
                                <asp:Button ID ="btnSaveBranch" Text="Save" runat="server" ValidationGroup="BRANCH" CssClass="buttonCreate" />
                                <br />
                                <br />
                                <asp:label ID ="lblBranchMessage" runat = "server" Visible = "false" Width ="400" CssClass = "errorBox"  /> <br />
                            </center>
                            
                            
                            <asp:GridView ID="gvBranchList" runat="server" AutoGenerateColumns="False" 
                                AllowSorting="false"  Width="100%" AllowPaging="false"  >
                                <RowStyle CssClass="dataTableCell" />
                                <PagerSettings Visible="false" />
                                <HeaderStyle CssClass="dataTableSubHeader" />
                                <AlternatingRowStyle CssClass="altdataTableCell" />
                                <Columns> 
                                    <asp:BoundField DataField="no" HeaderText="No" >
                                        <HeaderStyle Width="30px" HorizontalAlign="Center"  />
                                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="branch_code" HeaderText="Branch Code" HtmlEncode="false"  >
                                        <HeaderStyle HorizontalAlign="Center" Width="50px"   />
                                        <ItemStyle HorizontalAlign="Left" Width="50px"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="branch_name" HeaderText="Branch Name"  HtmlEncode="false" >
                                        <HeaderStyle HorizontalAlign="Center"  />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="province_name" HeaderText="Province" >
                                        <HeaderStyle Width="100px" HorizontalAlign="Center"  />
                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="branch_email" HeaderText="Email"  >
                                        <HeaderStyle Width="250px" HorizontalAlign="Center"  />
                                        <ItemStyle Width="250px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="branch_tel_no" HeaderText="Tel" >
                                        <HeaderStyle Width="100px" HorizontalAlign="Center"  />
                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="branch_mobile_no" HeaderText="Mobile" >
                                        <HeaderStyle Width="80px" HorizontalAlign="Center"  />
                                        <ItemStyle Width="80px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="branch_contact_name" HeaderText="Contact Name" >
                                        <HeaderStyle Width="100px" HorizontalAlign="Center"  />
                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="id" >
                                        <ControlStyle CssClass="zHidden" />
                                        <FooterStyle CssClass="zHidden" />
                                        <HeaderStyle CssClass="zHidden" />
                                        <ItemStyle CssClass="zHidden" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="#" >
                                        <ItemTemplate>
                                            <asp:Button CssClass ="buttonSelect" ID="butContactSelect" CausesValidation=false text ="Select" runat ="server" CommandArgument='<%#container.dataitem("id") %>' CommandName="Select"/>
                                            <asp:Button CssClass ="buttonCritical" ID="butContactDelete" CausesValidation=false  text="Delete" runat ="server" CommandArgument='<%#container.dataitem("Id") %>' OnClientClick="return confirm('Are you sure?');" CommandName="Delete"/>
                                        </ItemTemplate>
                                        <ItemStyle Width="140px" HorizontalAlign="Center" />
                                        <HeaderStyle Width="140px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>
              </div>
              <div id="tabsProject">
                <asp:UpdatePanel ID="upProject" runat="server">
                    <ContentTemplate>
                        <table align ="center" border="0" width="60%" class="dataTableCell" valign="center" >
                            <tr >
                              <td align="left" style="width: 180px">
                                  <asp:Label ID="lblProjectID" runat="server"  Visible="False" Text="0" ></asp:Label></td>
                              <td align="left" style="width: 100px">&nbsp;</td>
                              <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" >Project Code:</td>
                                <td align="left" >
                                    <asp:TextBox cssclass="textboxRequired" Width="250px" ID="txtProjectCode"  MaxLength="50" runat="server" />
                                </td>
                                <td align="left" >
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtProjectCode"
                                        ErrorMessage="*" ValidationGroup="PROJECT" SetFocusOnError="True"  ></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" >Project Name:</td>
                                <td align="left" >
                                    <asp:TextBox cssclass="textboxRequired" Width="250px" ID="txtProjectName"  MaxLength="255" runat="server" />
                                </td>
                                <td align="left" >
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtProjectName"
                                        ErrorMessage="*" ValidationGroup="PROJECT" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" >Start Date:</td>
                                <td align="left" >
                                    <uc1:txtDate ID="txtProjectStartDate" runat="server" />
                                </td>
                                <td align="left" ></td>
                            </tr>
                            <tr>
                                <td align="right" >Elapsed Time:</td>
                                <td align="left" >
                                    <asp:TextBox cssclass="textboxNormal" Width="80px" ID="txtProjectElapsedTime"  MaxLength="10" runat="server" />
                                    <asp:Label ID="lblElapsedTime" runat="server" Text="Day(s)" ></asp:Label>
                                </td>
                                <td align="left" >
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="right" >Project Manager Name:</td>
                                <td align="left" >
                                    <asp:DropDownList ID="ddlProjectManagerName" runat="server" Width="250"  ></asp:DropDownList>
                                </td>
                                <td align="left" >
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlProjectManagerName"
                                        ErrorMessage="*" ValidationGroup="PROJECT" SetFocusOnError="True" ></asp:RequiredFieldValidator></td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" >Cost Controller Name:</td>
                                <td align="left" >
                                    <asp:DropDownList ID="ddlProjectCostControlName" runat="server" Width="250"  ></asp:DropDownList>
                                </td>
                                <td align="left" >
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlProjectManagerName"
                                        ErrorMessage="*" ValidationGroup="PROJECT" SetFocusOnError="True"  ></asp:RequiredFieldValidator></td>
                                </td>
                            </tr>
                        </table>
                        <center>
                            <br />
                            <asp:Button ID ="btnSaveProject" Text="Save" runat="server" ValidationGroup="PROJECT" CssClass="buttonCreate" />
                            <br />
                            <br />
                            <asp:label ID ="lblProjectMessage" runat = "server" Visible = "false" Width ="400" CssClass = "errorBox"  /> <br />
                        </center>
                        
                        <asp:GridView ID="gvProjectList" runat="server" AutoGenerateColumns="False" 
                            AllowSorting="false"  Width="100%" AllowPaging="false"  >
                            <RowStyle CssClass="dataTableCell" />
                            <PagerSettings Visible="false" />
                            <HeaderStyle CssClass="dataTableSubHeader" />
                            <AlternatingRowStyle CssClass="altdataTableCell" />
                            <Columns> 
                                <asp:BoundField DataField="no" HeaderText="No" >
                                    <HeaderStyle Width="30px" HorizontalAlign="Center"  />
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="project_code" HeaderText="Project Code" HtmlEncode="false"  >
                                    <HeaderStyle HorizontalAlign="Center" Width="80px"  />
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="project_name" HeaderText="Project Name"  HtmlEncode="false" >
                                    <HeaderStyle  HorizontalAlign="Center"  />
                                    <ItemStyle  HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="start_date" HeaderText="Start Date"  >
                                    <HeaderStyle Width="80px" HorizontalAlign="Center"  />
                                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="elapsed_time" HeaderText="Elapsed Time(Days)"  >
                                    <HeaderStyle Width="80px" HorizontalAlign="Center"  />
                                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id" >
                                    <ControlStyle CssClass="zHidden" />
                                    <FooterStyle CssClass="zHidden" />
                                    <HeaderStyle CssClass="zHidden" />
                                    <ItemStyle CssClass="zHidden" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="#" >
                                    <ItemTemplate>&nbsp;
                                        <asp:Button CssClass ="buttonSelect" ID="butProjectSelect" CausesValidation="false" text ="Select" runat ="server" CommandArgument='<%#container.dataitem("id") %>' CommandName="Select"/>
                                        <asp:Button CssClass ="buttonCritical" ID="butProjectDelete" CausesValidation="false"  text="Delete" runat ="server" CommandArgument='<%#container.dataitem("Id") %>' OnClientClick="return confirm('Are you sure?');" CommandName="Delete"/>
                                    </ItemTemplate>
                                    <ItemStyle Width="140px" HorizontalAlign="Left" />
                                    <HeaderStyle Width="140px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
              </div>
            </div>
        </td>
    </tr>
</table>
</asp:Content>

