<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmReport.aspx.vb" Inherits="WebTarget.frmReport" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />

        <asp:Label ID="lblReportName" runat="server"></asp:Label>
        <asp:Label ID="lblFeedBack" runat="server"></asp:Label>
    </form>
</body>
</html>
