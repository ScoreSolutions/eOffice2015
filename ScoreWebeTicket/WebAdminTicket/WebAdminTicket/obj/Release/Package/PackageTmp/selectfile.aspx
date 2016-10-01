<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="selectfile.aspx.vb" Inherits="WebTarget.selectfile" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title> 
   
    <style type="text/css">
        .auto-style1 {
            width: 747px;
            height: 700px;
        }
        </style>
</head>
<body class="auto-style1">
    <form id="form1" runat="server">
  <center>
        <table class="auto-style1" style="border:groove;">
            <tr>
                <td style="vertical-align:top">     
                    
                     <center>
                   <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" Width="265px">
                       <MasterTableView>
            <RowIndicatorColumn>
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridTemplateColumn HeaderText="File - Name" UniqueName="TemplateColumn1">
                     <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# eval("file_name") %>'></asp:Label>
                         </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Ticket-File" UniqueName="TemplateColumn">
                    <ItemTemplate>
                        <asp:ImageButton ID="Button1" runat="server" BorderStyle="None" Height="39px" CommandName="openfile" Text="Open File" Width="78px" ImageUrl="~/Image/look.png" />
                        <asp:Label ID="Label1" runat="server" Text='<%# eval("file_name") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>

<FilterMenu EnableTheming="True">
<CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
</FilterMenu>
                </telerik:RadGrid>
                     </center>   
                    
                </td>
            </tr>
        </table> 
      </center> 
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
   
    </form>
</body>
</html>
