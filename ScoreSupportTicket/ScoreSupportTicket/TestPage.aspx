<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TestPage.aspx.vb" Inherits="TestPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControl" Namespace="AjaxControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Project :
        <cc2:ajaxdropdownlist id="ddlProject" 
				runat="server" DataValueField="id" DataTextField="text" LookupName="Project" Width="176px">
		</cc2:ajaxdropdownlist> <br />
		Module :
		<cc2:ajaxdropdownlist id="ddlModule" 
				runat="server" DataValueField="id" DataTextField="text" LookupName="Module" Width="176px">
		</cc2:ajaxdropdownlist> <br />
		Screen :
		<cc2:ajaxdropdownlist id="ddlScreen" 
				runat="server" DataValueField="id" DataTextField="text" LookupName="Screen" Width="176px">
		</cc2:ajaxdropdownlist>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Button" /><asp:TextBox ID="TextBox1"
        runat="server"></asp:TextBox>
    </form>
</body>
</html>
