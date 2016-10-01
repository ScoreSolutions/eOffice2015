<%@ Page Title="" Language="VB" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="false" CodeFile="frmUserForm.aspx.vb" Inherits="WebApp_frmUserForm" %>

<%@ Register src="../UserControls/mstStaffForm.ascx" tagname="mstStaffForm" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%"  >
        <tr>
            <td width="100%" align="center">
                <br />
                <br />
                <uc1:mstStaffForm ID="mstStaffForm1" runat="server" ShowClose="false" />
            </td>
        </tr>
    </table>
</asp:Content>

