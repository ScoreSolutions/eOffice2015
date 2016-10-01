<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlBrowseFileStream.ascx.vb" Inherits="UserControls_ctlBrowseFileStream" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <cc1:AsyncFileUpload ID="FileBrowse" runat="server" Width="250px" Height ="24px" CssClass="" 
            FailedValidation="False" UploaderStyle="Traditional" />
        </td>
        <td>
            <asp:Button ID="btnUpload" runat="server" Text="Upload" />
        </td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:GridView ID="gvListFile" runat="server" AutoGenerateColumns="false" Width="100%"
                ShowFooter="false" HeaderStyle-Font-Bold="true" >
                <RowStyle CssClass="dataTableCell" />
                <HeaderStyle CssClass="dataTableSubHeader" />
                <AlternatingRowStyle CssClass="altdataTableCell" />
                <Columns>
                    <asp:BoundField DataField="no" HeaderText="No" ReadOnly="true">
                        <HeaderStyle Width="30px" HorizontalAlign="Center" />
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="File Name" ItemStyle-Width="210px" >
                        <ItemTemplate>
                            <asp:Label ID="lblFileName" runat="server" Text='<%#Eval("file_name") %>' />
                            <asp:Label ID="lblFileID" runat="server" Text='<%#Eval("id") %>' Visible="false" />
                            <asp:Label ID="lblTempFilePath" runat="server" Text='<%#Eval("temp_file_path") %>' Visible="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="#" >
                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                        <FooterStyle HorizontalAlign="Center" Width="120px" />
                        <ItemTemplate>
                            <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" CssClass="buttonCritical" OnClientClick="return confirm('Are you sure you want to delete?');"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>

