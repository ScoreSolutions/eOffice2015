<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="leftpane.aspx.vb" Inherits="WebTarget.leftpane" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 227px;
            height: 27px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
       <asp:UpdatePanel runat="server">
            <ContentTemplate>
        <img alt="" class="auto-style1" src="Image/calendar.png" /><br />
                <telerik:RadCalendar ID="RadCalendar1" Runat="server" AutoPostBack="True" CultureInfo="th-TH" font-names="Arial,Verdana,Tahoma" forecolor="Black" Height="183px" SelectedDate="" style="border-color: #ececec" ViewSelectorText="x" Width="215px" Skin="Black" SelectedDayStyle-BorderColor="#3333ff" SelectedDayStyle-ForeColor="Yellow" SelectedDayStyle-BackColor="#ff0000">
                 
                   
                    <DayStyle ForeColor="#FF6600" /><OtherMonthDayStyle BackColor="#FFCC66" BorderStyle="None" />
                    <SelectedDayStyle BackColor="Red" BorderColor="#3333FF" ForeColor="Yellow" />
                </telerik:RadCalendar>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
    
        
    
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" GridLines="None" Width="211px">
<MasterTableView>
<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
    <Columns>
        <telerik:GridTemplateColumn UniqueName="TemplateColumn" DataField="ticket_code" HeaderText="All tickets created">
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# bind("ticket_code") %>'></asp:Label>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        
        <telerik:GridTemplateColumn UniqueName="TemplateColumn1" HeaderText="BY">
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# bind("create_by") %>'></asp:Label>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        
    </Columns>
</MasterTableView>

<FilterMenu EnableTheming="True">
<CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
</FilterMenu>
        </telerik:RadGrid>
                </ContentTemplate>
             </asp:UpdatePanel>
    
       
    
    </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
