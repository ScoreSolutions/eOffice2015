<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="List.aspx.vb" Inherits="WebTarget.List" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style type="text/css">
        #txtSearch0 {
            width: 181px;
        }
        #txtSearch {
            width: 166px;
            margin-left: 40px;
        }
        #txtSearch1 {
            width: 166px;
            margin-left: 40px;
        }
        .auto-style15 {
    }
        .auto-style16 {
         width: 6px;
     }
        </style>
</head>
<body>
<form id="form1" runat="server">
<div style="text-align: center; height: 565px;">
  
    <p style="font-size: large; color: #00CC00; text-align: left;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </p>
    <p style="font-size: large; color: #00CC00; text-align: left; background-color: #515151;">
        <strong style="color: #b6ff00">TICKET LIST</strong></p>
    <table width="100%" height="100%">
        <tr>
            <td class="auto-style16" ></td>
            <td class="auto-style15" valign="top" rowspan="4" >
                <br />
                   <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" AutoGenerateColumns="False" AllowPaging="True">
                       <MasterTableView>
            <RowIndicatorColumn>
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="create_by" HeaderStyle-HorizontalAlign="Center" HeaderText="Cre-By" SortExpression="create_by">
<HeaderStyle HorizontalAlign="Center" ></HeaderStyle>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="create_on" HeaderStyle-HorizontalAlign="Center" HeaderText="Cre-On" SortExpression="create_on">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="account_name" HeaderStyle-HorizontalAlign="Center" HeaderText="Ac-Name" SortExpression="account_name">
<HeaderStyle HorizontalAlign="Center" ></HeaderStyle>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="project_code" HeaderStyle-HorizontalAlign="Center" HeaderText="Pro-Code" SortExpression="project_code">
<HeaderStyle HorizontalAlign="Center" width="80px"></HeaderStyle>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="branch_name" HeaderStyle-HorizontalAlign="Center" HeaderText="Bra-Name" SortExpression="branch_name">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ticket_code" HeaderStyle-HorizontalAlign="Center" HeaderText="Tic-Code" SortExpression="ticket_code">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="assign_by" HeaderStyle-HorizontalAlign="Center" HeaderText="Ass-By" SortExpression="assign_by">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="assign_on" HeaderStyle-HorizontalAlign="Center" HeaderText="Ass-On" SortExpression="assign_on">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="statusticket_name" HeaderStyle-HorizontalAlign="Center" HeaderText="Tic-Status" SortExpression="statusticket_name">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="statuscus_name" HeaderStyle-HorizontalAlign="Center" HeaderText="Cus-Status" SortExpression="statuscus_name">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="Ticket-File" UniqueName="TemplateColumn">
                    <ItemTemplate>
                        <asp:ImageButton ID="Button1" runat="server" BorderStyle="None" Height="42px" CommandName="openfile" Text="Open File" Width="78px" ImageUrl="~/Image/warehouse.png" />
                        <br />
                        <asp:Label ID="Label1" runat="server" Text='<%# eval("ticket_id") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>

<FilterMenu EnableTheming="True">
<CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
</FilterMenu>
                </telerik:RadGrid>
                        
                </td>
        </tr>
        </table>
    
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;

</div>
</form>
</body>
</html>