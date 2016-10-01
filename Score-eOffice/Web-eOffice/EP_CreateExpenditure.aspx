<%@ Page Language="VB" MasterPageFile="~/MasterPage_Basic.master" AutoEventWireup="false" CodeFile="EP_CreateExpenditure.aspx.vb" Inherits="EP_CreateExpenditure" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc1" %>
<%@ Register src="UserControls/ctlBrowseFileStream.ascx" tagname="ctlBrowseFileStream" tagprefix="uc2" %>
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
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <table id="Table3" bgcolor="#cccccc" border="0" cellpadding="5" cellspacing="1" width="100%">
        <tr>
            <td align="left" style="width: 196px">
                <strong>Expenditure</strong>
            </td>
            <td align="left" width="244">
                &nbsp;&nbsp;
            </td>
            <td align="right" valign="top" width="130">
                &nbsp;
            </td>
            <td align="left" valign="top" style="width: 304px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                Request ID :
            </td>
            <td align="left" bgcolor="#ffffff" width="244">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblRequestID" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                &nbsp;</td>
            <td align="left" bgcolor="#ffffff" valign="middle" style="width: 304px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                Date :</td>
            <td align="left" bgcolor="#ffffff" width="244">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                         <table cellpadding="0" cellspacing="0" >
                             <tr>
                                 <td>
                                 <uc1:txtDate ID="txtDate" runat="server"  />
                                 </td>
                                 <td>
                                 <asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                 </td>
                             </tr>
                         </table>
 
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                &nbsp;</td>
            <td align="left" bgcolor="#ffffff" valign="top" style="width: 304px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                Project Name :</td>
            <td align="left" bgcolor="#ffffff" width="244">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlProject" runat="server" Width="200px" DataTextField="Project_code"
                            DataValueField="Id" AutoPostBack="True">
                        </asp:DropDownList>
                         <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                &nbsp;</td>
            <td align="left" bgcolor="#ffffff" valign="middle" style="width: 304px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" bgcolor="#e9e9e9" style="width: 196px">
                Project Billing Name :
            </td>
            <td align="left" bgcolor="#ffffff" width="244">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlBillingName" runat="server" Width="200px" DataTextField="Billing_Name"
                            DataValueField="Id">
                        </asp:DropDownList>
                         <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                &nbsp;</td>
            <td align="left" bgcolor="#ffffff" valign="top" style="width: 304px">
                
            </td>
        </tr>
        
        <tr>
            <td align="left" bgcolor="#e9e9e9" valign="top" style="width: 196px">
                Expense Type :</td>
            <td align="left" bgcolor="#ffffff" valign="top" width="244">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlExpenseType" runat="server" Width="200px" DataTextField="expense_type_desc"
                            DataValueField="Id">
                        </asp:DropDownList>
                         <asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="left" bgcolor="#e9e9e9" valign="top" width="130">
                &nbsp;
            </td>
            <td align="left" bgcolor="#ffffff" valign="top" style="width: 304px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 30px; background-color: white; width: 196px;">
            </td>
            <td align="left" colspan="3" style="height: 30px; background-color: white;">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblID" runat="server" Visible="false">0</asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <center>
     <asp:UpdatePanel ID="UpdatePanel13" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblError" runat="server" Visible="false" Width="400" CssClass="errorBox" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
    <div id="tabs">
        <ul>
            <li><a href="#tabsListItem">List Item</a></li>
            <li><a href="#tabsAttactFile">Attach File</a></li>
        </ul>
        <div id="tabsListItem">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="ButtonAdd" runat="server" Text="Add" />
                    <br /> <br />
                    <asp:GridView ID="gvListItem" DataKeyNames="no" runat="server" AutoGenerateColumns="false" Width="100%"
                        ShowFooter="false" HeaderStyle-Font-Bold="true" >
                        <RowStyle CssClass="dataTableCell" />
                        <HeaderStyle CssClass="dataTableSubHeader" />
                        <AlternatingRowStyle CssClass="altdataTableCell" />
                        <Columns>
                            <asp:BoundField DataField="no" HeaderText="No" ReadOnly="true">
                                <HeaderStyle Width="30px" HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Type" ItemStyle-Width="210px" >
                                <ItemTemplate>
                                    <asp:Label ID="lblItemTypeName" runat="server" Text='<%#Eval("eoffice_expense_item_type_name") %>' />
                                    <asp:Label ID="lblItemTypeID" runat="server" Text='<%#Eval("eoffice_expense_item_type_id") %>' Visible="false" />
                                    <asp:Label ID="lblItemID" runat="server" Text='<%#Eval("id") %>' Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("item_desc") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Invoice Date" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" >
                                <ItemTemplate>
                                    <asp:Label ID="lblInvoiceDate" runat="server" Text='<%#Eval("item_invoice_date") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount" ItemStyle-Width="80px" >
                                <ItemStyle HorizontalAlign="Center" />
                                <FooterStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("item_amt") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="#" >
                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                                <FooterStyle HorizontalAlign="Center" Width="120px" />
                                <ItemTemplate>
                                    <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" />
                                    <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" CommandArgument='<%#Eval("no") %>' Text="Delete" CssClass="buttonCritical" OnClientClick="return confirm('Are you sure you want to delete?');"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    
                    <asp:Panel ID="Panel1" runat="server" Width="550px" >
                        <table id="Table1" width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
                            style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
                            <tr style="background-color: #cccccc; color: #000000; font-size: 14px; font-weight: bold;">
                                <td align="left" bgcolor="#cccccc">Expenditure Item</td>
                                <td align="right" bgcolor="#cccccc">
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/closePopup.png" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <table border="0"  cellpadding="0" cellspacing="2" width="95%" align="center" >
                                        <tr>
                                            <td colspan="2">&nbsp;
                                                <asp:Label ID="lblExpenditureItemID" runat="server" Text="0" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="left" >Type : <span style="color:red">*</span> </td>
                                            <td width="70%" align="left" >
                                                <asp:DropDownList ID="ddlItemType" runat="server" Width="200px"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" >Description : <span style="color:red">*</span></td>
                                            <td align="left" >
                                                <asp:TextBox ID="txtItemDescription" runat="server" TextMode="MultiLine" Height="50px" Width="200px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" >Invoice Date : <span style="color:red">*</span></td>
                                            <td align="left" >
                                                <uc1:txtDate ID="txtItemInvoiceDate" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" >Amount : <span style="color:red">*</span></td>
                                            <td align="left" >
                                                <asp:TextBox ID="txtItemAmount" Width="60px" runat="server" MaxLength="8"/>
                                                (THB)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td align="left" >
                                                <asp:Label ID="lblItemError" runat="server" Visible="false" CssClass="errorBox" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td align="left" >
                                                  <asp:Button ID="btnItemSave" runat="server" CssClass="buttonCreate" Text="Save" Width="51px" />                      
                                                  &nbsp;
                                                  <asp:Button ID="btnItemCancel" runat="server" CssClass="buttonCancel" Text="Cancel" />                      
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                        </table>
                    </asp:Panel>
                    
                    <asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
                    <cc1:ModalPopupExtender ID="popAddListItem" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
                        BackgroundCssClass="modalBackground" DropShadow="true">
                    </cc1:ModalPopupExtender>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="tabsAttactFile">
         <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <uc2:ctlBrowseFileStream ID="ctlBrowseFileStream1" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <center>
        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
            <ContentTemplate>
                <br />
                <asp:Button ID="butSave" runat="server" CssClass="buttonCreate" Text="Save" Width="51px" />&nbsp;
                <asp:Button ID="butCancel" runat="server" CausesValidation="False" CssClass="buttonCancel" Text="Cancel" />&nbsp;
                <asp:Button ID="butSend" runat="server" CssClass="buttonCreate" Text="Send" Width="51px" Visible="false" />&nbsp;
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>

