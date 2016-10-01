<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MainPage.aspx.vb" Inherits="WebTarget.MainPage" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
                               
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
      
        function explainSelection() {
            var searchString = "";

            if (window.document.selection) {
                var rng = window.document.selection.createRange();
                searchString = rng.text;
            }
            else if (window.getSelection) {
                searchString = window.getSelection().toString();
            }
            if (searchString) {        
                localStorage.setItem('Label1', searchString)
                var urlSearchString = "searchpage.aspx?text= "+localStorage.getItem('Label1');
                radopen(urlSearchString)
            }
        }
        function LabelHover() {
        document.getElementById('Label2').style.visibility = 'visible';
          }
        function Labelleave() {
            document.getElementById('Label2').style.visibility = 'hidden';
        }
    </script>
    <style type="text/css">
        .xlink {cursor:pointer}
        .auto-style1 {
            width: 100%;
            height: 205px;
        }
        .auto-style5 {
            width: 45%;
            background-color: #FFFFFF;
            text-align: left;
            vertical-align: top;
        }

        .auto-style6 {
            width: 1%;
            background-color: #FFFFFF;
        }
        
        .auto-style8 {
            width: 4%;
            background-color: #FFFFFF;
        }
        
        </style>
</head>
<body style="background-color:white">
    <form id="form1" runat="server" method="get">
    <p style="font-size: large; color: #00CC00; text-align: left; background-color: #515151;">
        <strong style="color: #b6ff00">Summary</strong></p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <telerik:RadWindowManager ID="RadWindowManager1" Title="ข้อมูล TICKET CODE" runat="server" width="381px" height="370px">
        </telerik:RadWindowManager>
         
          <asp:HiddenField ID="hid_Ticker" runat="server" Value="0" />       
         
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style8" >
                    &nbsp;</td>
                <td class="auto-style5" >
                    <asp:Image ID="Image3" runat="server" Height="60px" ImageUrl="~/Image/km_03.png" Width="435px" />
                </td>
                <td class="auto-style6" rowspan="2" style="background-color:#CCCC00;" >&nbsp;</td>
                <td class="auto-style5">
                    <asp:Image ID="Image2" runat="server" Height="60px" ImageUrl="~/Image/time_03.png" Width="375px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style8" >
                    &nbsp;</td>
                <td class="auto-style5" >
                     <div id="textDiv" style="font: 1em/1.2em 'Arial', sans-serif;">
                            <asp:UpdatePanel runat="server">
            <ContentTemplate>
                    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" Height="184px" AllowPaging="True" BorderColor="#66CCFF" BorderStyle="None" Skin="Sunset">

<MasterTableView>
<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>
   
<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
    <Columns>
        <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="Knowlege Data Search...">
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# bind("resolved") %>'></asp:Label>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
    </Columns>
</MasterTableView>

                        <ItemStyle Font-Size="Medium" />

<FilterMenu EnableTheming="True">
<CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
</FilterMenu>
                    </telerik:RadGrid>
                </ContentTemplate>
                </asp:UpdatePanel>
                         </div>
                </td>
                <td class="auto-style5" style="vertical-align:top;">
                   
         <asp:UpdatePanel ID="UP_Timer" runat="server" RenderMode="Inline" UpdateMode="Always">          
            <ContentTemplate>
              <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="False"  GridLines="None" Height="429px" AllowPaging="True" Width="380px" HorizontalAlign="Center" BorderColor="#66CCFF" BorderStyle="None" PageSize="9" style="margin-right: 0px" Skin="Hay">
<MasterTableView>
<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
    <Columns>
        <telerik:GridTemplateColumn HeaderText="Ticket Code" UniqueName="TemplateColumn">
            <ItemTemplate>
               <p ondblclick="explainSelection()"><asp:Label ID="Label2" runat="server" Text='<%# bind("ticket_code") %>' CssClass="xlink"></asp:Label></p>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn HeaderText="Time Left" UniqueName="TemplateColumn1" DataField="column">
            <ItemTemplate>
                &nbsp;<asp:Label ID="Label4" runat="server" Text='<%# Bind("create_on") %>' Width="57px" Height="19px" ForeColor="#0099FF"></asp:Label>
                -&#160;&#160;&#160; <asp:Label ID="lblTime" runat="server" Text='<%# bind("branch_sla") %>' Width="57px" Height="19px" ForeColor="Red"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text=" นาฬิกา" ForeColor="Red" ></asp:Label>
            <asp:Label ID="Label5" runat="server" Text='<%# bind("ticket_id") %>'  Visible="false"></asp:Label></ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn HeaderText="Status" UniqueName="TemplateColumn1" DataField="column">
            <ItemTemplate>
                <asp:Label ID="Label6" runat="server" Text='<%# Bind("statusticket_name") %>' Width="57px" Height="19px" ForeColor="#0099FF"></asp:Label>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
    </Columns>
</MasterTableView>

                  <ItemStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" BorderStyle="None" />

<FilterMenu EnableTheming="True">
<CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
</FilterMenu>
              </telerik:RadGrid>
                <asp:Timer ID="Timer1" runat="server" Interval="1000" />
               </ContentTemplate>
        </asp:UpdatePanel>
                    
            
                </td>
            </tr>
            </table>
        <br />
</form>
    </body>

        