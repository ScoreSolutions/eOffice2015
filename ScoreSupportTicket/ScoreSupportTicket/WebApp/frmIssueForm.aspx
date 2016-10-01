<%@ Page Title="" Language="VB" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="false" CodeFile="frmIssueForm.aspx.vb" Inherits="WebApp_frmIssueForm" %>
<%@ Register src="../UserControls/cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../UserControls/txtBox.ascx" tagname="txtBox" tagprefix="uc3" %>
<%@ Register src="../UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc4" %>
<%@ Register src="../UserControls/mstFormControl.ascx" tagname="mstFormControl" tagprefix="uc2" %>
<%@ Register src="../UserControls/cmbStaffTable.ascx" tagname="cmbStaffTable" tagprefix="uc5" %>
<%@ Register src="../UserControls/popMessage.ascx" tagname="popMessage" tagprefix="uc6" %>
<%@ Register src="../UserControls/ctlRichTextBox.ascx" tagname="ctlRichTextBox" tagprefix="uc7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="100%" border="0" cellpadding="0" cellspacing="0" >
    <tr >
        <td valign="top" >
            
            <cc1:TabContainer ID="TabContainer1" runat="server"  Width="100%" >
                <cc1:TabPanel ID="tblIssueLoggerZone" runat="server" Width="100%" Height="100%" >
                    <HeaderTemplate><b>Issue Logger Zone</b></HeaderTemplate>
                    <ContentTemplate >
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" valign="top">
                            <tr>
                                <td align="right">Project : </td>
                                <td align="left" colspan="3"><uc1:cmbComboBox ID="cmbProject" runat="server" AutoPosBack="true" Width="380" DefaultDisplay="------Select" /></td>
                            </tr>
                            <tr>
                                <td align="right">Log No :</td>
                                <td align="left">
                                    <uc3:txtBox ID="txtAddLogNo" runat="server" TextAlign="AlignCenter" TextType="TextView"  Visible="false" />
                                    <uc3:txtBox ID="txtLogNo" runat="server" TextAlign="AlignCenter" TextType="TextView" Text="NEW" />
                                    <font color="red">Auto</font>
                                    <asp:HiddenField ID="txtID" runat="server" />
                                </td>
                                <td align="left" colspan="2" rowspan="11" valign="top" >
                                    
                                    <cc1:TabContainer ID="ctlFile" runat="server" >
                                        <cc1:TabPanel ID="tplDesc" runat="server" Width="100%" Height="100%" >
                                            <HeaderTemplate>Description</HeaderTemplate>
                                            <ContentTemplate>
                                                <uc7:ctlRichTextBox ID="txtAddDesc" runat="server" Width="100%" Height="100%" IsNotNull="false" />
                                            </ContentTemplate>
                                        </cc1:TabPanel>
                                        <cc1:TabPanel runat="server" Width="100%" Height="100%" ID="trBrowseFile"  >
                                            <HeaderTemplate>Attach File</HeaderTemplate>
                                            <ContentTemplate>
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                                                    <tr>
                                                        <td width="20%" align="right">File Name :&nbsp;</td>
                                                        <td width="80%">
                                                            <cc1:AsyncFileUpload ID="FileBrowse" runat="server" Width="300px" FailedValidation="False" />
                                                            <asp:Label ID="lblFileLimit" runat="server" Font-Italic="true" Text="Limit 10Mb"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">Description :&nbsp;</td>
                                                        <td><uc3:txtBox ID="txtFileDesc" runat="server" Width="300" IsNotNull="true" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td><asp:Button ID="btnUpload" runat="server" Text="Upload"  /></td>
                                                    </tr>
                                                    <tr><td colspan="2">&nbsp;</td></tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:GridView ID="gvFileList" runat="server" 
                                                                AutoGenerateColumns="False" BackColor="White" PageSize="20" 
                                                                BorderColor="#999999" BorderWidth="1px" CellPadding="1" 
                                                                CssClass="GridViewStyle" GridLines="Vertical" >
                                                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="id" HeaderText="id">
                                                                        <ControlStyle CssClass="zHidden" />
                                                                        <FooterStyle CssClass="zHidden" />
                                                                        <HeaderStyle CssClass="zHidden" />
                                                                        <ItemStyle CssClass="zHidden" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="File Name" SortExpression="file_name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFileName" runat="server" ></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Width="180px" />
                                                                        <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField  DataField="file_desc" HeaderText="Description" >
                                                                        <ItemStyle Width="250px" HorizontalAlign="Left"></ItemStyle>
                                                                        <HeaderStyle Width="250px" HorizontalAlign="Center"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Command" >
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="lnkDelete" OnClick="lnkDelete_Click" runat="server" ImageUrl="~/Images/icn_close.png" CommandArgument='<%# Bind("id")  %>' ToolTip="Delete"
                                                                             OnClientClick="return confirm('Are you sure?');" ></asp:ImageButton>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Width="80px" />
                                                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                                                <AlternatingRowStyle BackColor="Gainsboro" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </cc1:TabPanel>
                                    </cc1:TabContainer>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Ref Request No :</td>
                                <td align="left">
                                    <uc3:txtBox ID="txtRefReqNo" runat="server" TextAlign="AlignCenter"  />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Type : </td>
                                <td align="left">
                                    <uc2:mstFormControl ID="cmbAddType" runat="server" MasterTableName="LOG_TYPE" Width="200"
                                    IsNotNull="true" PageName="Log Type" LabelMasterName="Type Name" ShowAddNewButton="false"  />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Open Status : </td>
                                <td align="left">
                                    <uc2:mstFormControl ID="cmbAddStatus" runat="server" MasterTableName="LOG_STATUS" Width="200"
                                    IsNotNull="true" PageName="Log Status" LabelMasterName="Status Name" ShowAddNewButton="false" AutoPostBack="true" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" >Priority : </td>
                                <td align="left" ><uc1:cmbComboBox ID="cmbAddPriority" runat="server" Width="200" /></td>
                            </tr>
                            <tr>
                                <td align="right" >State : </td>
                                <td align="left" >
                                    <uc2:mstFormControl ID="cmbAddState" runat="server" MasterTableName="LOG_STATE" Width="200"
                                    IsNotNull="false" PageName="Log State" LabelMasterName="State Name" ShowAddNewButton="false"  />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Module : </td>
                                <td align="left">
                                    <uc2:mstFormControl ID="cmbAddModule" runat="server" MasterTableName="MODULE" Width="200"
                                    IsNotNull="true" PageName="Module" LabelMasterName="Module Name"  AutoPostBack="true" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Screen : </td>
                                <td align="left">
                                    <uc2:mstFormControl ID="cmbAddScreen" runat="server" MasterTableName="SCREEN" Width="200"
                                    IsNotNull="false" PageName="Screen" LabelMasterName="Screen Name"  />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" >Instance : </td>
                                <td align="left" ><uc3:txtBox ID="txtAddInstance" runat="server" Width="200" /></td>
                            </tr>
                            <tr>
                                <td align="right" >Changes Approve :</td>
                                <td align="left" >
                                    <asp:RadioButtonList ID="chkAddChangeRequest" runat="server" RepeatDirection="Horizontal" >
                                        <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                        <asp:ListItem Value="N" Text="No" Selected></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" >Comment : </td>
                                <td align="left" >
                                    <uc3:txtBox ID="txtAddComment" runat="server" TextMode="MultiLine" Height="60" Width="330px" IsNotNull="false"  />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="15%">Raised By :</td>
                                <td align="left" width="35%"><uc5:cmbStaffTable ID="cmbAddRaiseBy" runat="server" IsNotNull="true" PageName="Raise By" FieldName="RAISED_BY" DefaultValue="" Width="200" /></td>
                                <td align="right" width="15%">Raised Date :</td>
                                <td align="left" width="35%"><uc4:txtDate ID="txtAddRaiseDate" runat="server" DefaultCurrentDate="true" IsNotNull="true" /></td>
                            </tr>
                            <tr>
                                <td align="right">Assign To : </td>
                                <td align="left"><uc5:cmbStaffTable ID="cmbAddAssignTo" runat="server" PageName="Assign To" FieldName="ASSIGNED_TO" DefaultValue="" IsNotNull="false" Width="200" /></td>
                                <td align="right">Assign Date : </td>
                                <td align="left"><uc4:txtDate ID="txtAddAssignDate" runat="server" DefaultCurrentDate="true" /></td>
                            </tr>
                            <tr>
                                <td align="right">Expected Date : </td>
                                <td align="left" colspan="3">
                                    <uc4:txtDate ID="txtAddExpectedDate" runat="server" DefaultCurrentDate="true" IsNotNull="true" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Close By : </td>
                                <td align="left"><uc5:cmbStaffTable ID="cmbAddCloseBy" runat="server" PageName="Clase By" FieldName="CLOSED_BY" DefaultValue="" IsNotNull="false" Width="200" Enabled="false" ShowAddNewButton="false" /></td>
                                <td align="right">Close Date : </td>
                                <td align="left"><uc4:txtDate ID="txtAddCloseDate" runat="server" VisibleImg="false" /></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="tblResolutionZone" runat="server" Width="100%" Height="100%">
                    <HeaderTemplate><b>Resolution Zone</b></HeaderTemplate>
                    <ContentTemplate>
                         <table border="1" cellpadding="0" cellspacing="0" width="100%" valign="top">
                            <tr>
                                <td width="15%" align="right">Est'd Fixed Date :</td>
                                <td width="35%" align="left"><uc4:txtDate ID="txtEstimateFixedDate" runat="server" /></td>
                                <td width="50%" align="left" >Resolution :</td>
                            </tr>
                            <tr>
                                <td align="right">Current Status :</td>
                                <td align="left">
                                    <uc2:mstFormControl ID="cmbResolvedStatus" runat="server" MasterTableName="RESOLVED_STATUS" Width="200"
                                    IsNotNull="false" PageName="Resolved Status" LabelMasterName="Current Name" ShowAddNewButton="false" />
                                </td>
                                <td align="left" rowspan="5">
                                    <uc7:ctlRichTextBox ID="ctlResolution" runat="server" Width="100%" Height="100%" IsNotNull="false" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Complexity Level :</td>
                                <td align="left"><uc1:cmbComboBox ID="cmbComplexityLevel" runat="server" Width="200" IsNotNull="false" IsDefaultValue="true" DefaultValue="" DefaultDisplay="-----Select" /></td>
                            </tr>
                            <tr>
                                <td align="right">Comments :</td>
                                <td align="left">
                                    <uc3:txtBox ID="txtResolveComment" runat="server" TextMode="MultiLine" Height="60px" Width="330px" IsNotNull="false"  />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Resolved Date :</td>
                                <td align="left"><uc4:txtDate ID="txtResolveDate" runat="server" /></td>
                            </tr>
                            <tr height="100px">
                                <td align="right" colspan="2" >&nbsp;</td>
                            </tr>
                         </table>
                    </ContentTemplate>
                </cc1:TabPanel>
            </cc1:TabContainer>
        </td>
    </tr>
    <tr>
        <td align="center" >
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="zButton" Width="130px" Height="50px" Font-Size="Large" />
        </td>
    </tr>
</table>

<uc6:popMessage ID="popSaveComplete" runat="server" />
<uc6:popMessage ID="popErr" runat="server" />
</asp:Content>




