<%@ Control Language="VB" AutoEventWireup="false" CodeFile="mstStaffForm.ascx.vb" Inherits="UserControls_mstStaffForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="txtBox.ascx" tagname="txtBox" tagprefix="uc1" %>
<%@ Register src="cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc3" %>


    <table id="Table1" width="800" border="1" cellpadding="0" cellspacing="0" bgcolor="#ffffff" style="border: solid 1px 1px 1px 1px #ff0000" runat="server" >
        <tr id="rwClose" runat="server" >
            <td colspan="3" >
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr style="background-color:#3399FF">
                        <td><asp:Label ID="lblPageName" runat="server" ></asp:Label></td>
                        <td align="right">
                            <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../Images/icn_close.png" />
                        </td>
                    </tr>
                    <tr><td colspan="2">&nbsp;</td></tr>
                </table>
            </td>
        </tr>
        <tr >
            <td align="right" width="20%">ชื่อเข้าระบบ : </td>
            <td align="left" width="40%">
                <uc1:txtBox ID="txtUserName" runat="server" TextType="TextBox" IsNotNull="true" />
                <uc1:txtBox ID="txtID" runat="server" Visible="false" />
            </td>
            <td align="left" width="40%">Work in Project :</td>
        </tr>
        <tr >
            <td align="right">รหัสผ่าน : </td>
            <td align="left">
                <uc1:txtBox ID="txtPwd" runat="server" TextType="TextBox" TextMode="Password" IsNotNull="true" />
            </td>
            <td rowspan="8" valign="top" align="left" >
                <asp:CheckBoxList ID="chkProjectList" runat="server" RepeatLayout="Table" RepeatDirection="Vertical"  >
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr >
            <td align="right">ยืนยันรหัสผ่าน : </td>
            <td align="left">
                <uc1:txtBox ID="txtConfirmPwd" runat="server" TextType="TextBox" TextMode="Password" />
            </td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
        <tr >
            <td align="right">ชื่อผู้ใช้ : </td>
            <td align="left">
                <uc1:txtBox ID="txtStaffName" runat="server" TextType="TextBox" IsNotNull="true" />
            </td>
        </tr>
        <tr >
            <td align="right">ตำแหน่ง : </td>
            <td align="left">
                <uc1:txtBox ID="txtPositionName" runat="server" TextType="TextBox" />
            </td>
        </tr>
        <tr >
            <td align="right">หน่วยงาน : </td>
            <td align="left">
                <uc1:txtBox ID="txtDivisionName" runat="server" TextType="TextBox" />
            </td>
        </tr>
        <tr>
            <td align="right">กำหนดสิทธิ์ : </td>
            <td align="left">
                <asp:CheckBox ID="chkRaise" runat="server" Checked="true"  Text="ผู้แจ้งปัญหา" />
                <asp:CheckBox ID="chkAcceptAssign" runat="server" Checked="true"  Text="ผู้ดำเนินการแก้ไข" /> <br />
                <asp:CheckBox ID="chkClose" runat="server" Checked="true"  Text="ผู้ปิด Issue" />
            </td>
        </tr>
        <tr>
            <td align="right">&nbsp;</td>
            <td align="left">
                <asp:CheckBox ID="chkActive" runat="server" Checked="true"  Text="Active" />
            </td>
        </tr>
        <tr style="height:35px" >
            <td align="right">&nbsp;</td>
            <td align="left" colspan="2" ><asp:Button ID="btnSave" runat="server" Text="Save" Width="60" /></td>
        </tr>
    </table>

