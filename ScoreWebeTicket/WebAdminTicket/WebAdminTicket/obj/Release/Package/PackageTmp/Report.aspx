<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Report.aspx.vb" Inherits="WebTarget.Report" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>   
    <style type="text/css">
        .auto-style1 {
            width: 98%;
            height: 36px;
        }
        .auto-style2 {
            width: 359px;
            text-align: right;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <p style="font-size: large; color: #00CC00; text-align: left; background-color: #515151;">
            Report Ticket<telerik:RadWindowManager ID="RadWindowManager1" runat="server"  width="500px" height="500px">
            </telerik:RadWindowManager>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </p>
    <div style="text-align: left; margin-left: 200px;">
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Support-TicketConnectionString %>" SelectCommand="SELECT [project_name],[id] FROM [TICKET_PROJECT]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Support-TicketConnectionString %>" SelectCommand="SELECT [assign_to] FROM [TICKET_TICKET]"></asp:SqlDataSource>
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <asp:DropDownList ID="DropDownList1" runat="server" Height="23px" Width="250px" AutoPostBack="True" style="text-align: left">
            <asp:ListItem Value="0">เลือกประเภทรายงาน</asp:ListItem>
            <asp:ListItem Value="1">รายงานสรุปปัญหาตามวันที่</asp:ListItem>
            <asp:ListItem Value="2">รายงานสรุปปัญหาตามโปรเจค</asp:ListItem>
            <asp:ListItem Value="3">รายงานสรุปปัญหาตามผู้ที่แก้ไข</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style2" style="vertical-align:top"><table class="auto-style1">
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label1" runat="server" Text="Start Date" Visible="False"></asp:Label>
        <asp:DropDownList ID="ddpro" runat="server" style="text-align: right" Visible="False" DataSourceID="SqlDataSource1" DataTextField="project_name" DataValueField="id">
        </asp:DropDownList>
        <asp:DropDownList ID="ddsup" runat="server" style="text-align: right" Visible="False" DataSourceID="SqlDataSource2" DataTextField="assign_to" DataValueField="assign_to">
        </asp:DropDownList>
                            <asp:DropDownList ID="ddDs" runat="server" Height="21px" Width="49px" Visible="False">
                            <asp:ListItem>Day</asp:ListItem>
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                            <asp:ListItem>24</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                            <asp:ListItem>26</asp:ListItem>
                            <asp:ListItem>27</asp:ListItem>
                            <asp:ListItem>28</asp:ListItem>
                            <asp:ListItem>29</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>31</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddMs" runat="server" Visible="False">
                                <asp:ListItem>Month</asp:ListItem>
                                <asp:ListItem>01</asp:ListItem>
                                <asp:ListItem>02</asp:ListItem>
                                <asp:ListItem>03</asp:ListItem>
                                <asp:ListItem>04</asp:ListItem>
                                <asp:ListItem>05</asp:ListItem>
                                <asp:ListItem>06</asp:ListItem>
                                <asp:ListItem>07</asp:ListItem>
                                <asp:ListItem>08</asp:ListItem>
                                <asp:ListItem>09</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddYs" runat="server" Visible="False">
                                <asp:ListItem>Year</asp:ListItem>
                                <asp:ListItem>2014</asp:ListItem>
                                <asp:ListItem>2015</asp:ListItem>
                                <asp:ListItem>2016</asp:ListItem>
                                <asp:ListItem>2017</asp:ListItem>
                                <asp:ListItem>2018</asp:ListItem>
                                <asp:ListItem>2019</asp:ListItem>
                                <asp:ListItem>2020</asp:ListItem>
                                <asp:ListItem>2021</asp:ListItem>
                                <asp:ListItem>2022</asp:ListItem>
                                <asp:ListItem>2023</asp:ListItem>
                                <asp:ListItem>2024</asp:ListItem>
                                <asp:ListItem>2025</asp:ListItem>
                                <asp:ListItem>2026</asp:ListItem>
                                <asp:ListItem>2027</asp:ListItem>
                                <asp:ListItem>2028</asp:ListItem>
                                <asp:ListItem>2029</asp:ListItem>
                                <asp:ListItem>2030</asp:ListItem>
                            </asp:DropDownList>
&nbsp;<br />
                                <asp:Label ID="Label2" runat="server" Text="End Date" Visible="False"></asp:Label>
                                <asp:DropDownList ID="ddDe" runat="server" Visible="False">
                             <asp:ListItem>Day</asp:ListItem>
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                            <asp:ListItem>24</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                            <asp:ListItem>26</asp:ListItem>
                            <asp:ListItem>27</asp:ListItem>
                            <asp:ListItem>28</asp:ListItem>
                            <asp:ListItem>29</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>31</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddMe" runat="server" Visible="False">
                                <asp:ListItem>Month</asp:ListItem>
                                <asp:ListItem>01</asp:ListItem>
                                <asp:ListItem>02</asp:ListItem>
                                <asp:ListItem>03</asp:ListItem>
                                <asp:ListItem>04</asp:ListItem>
                                <asp:ListItem>05</asp:ListItem>
                                <asp:ListItem>06</asp:ListItem>
                                <asp:ListItem>07</asp:ListItem>
                                <asp:ListItem>08</asp:ListItem>
                                <asp:ListItem>09</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddYe" runat="server" Visible="False">
                                <asp:ListItem>Year</asp:ListItem>
                                <asp:ListItem>2014</asp:ListItem>
                                <asp:ListItem>2015</asp:ListItem>
                                <asp:ListItem>2016</asp:ListItem>
                                <asp:ListItem>2017</asp:ListItem>
                                <asp:ListItem>2018</asp:ListItem>
                                <asp:ListItem>2019</asp:ListItem>
                                <asp:ListItem>2020</asp:ListItem>
                                <asp:ListItem>2021</asp:ListItem>
                                <asp:ListItem>2022</asp:ListItem>
                                <asp:ListItem>2023</asp:ListItem>
                                <asp:ListItem>2024</asp:ListItem>
                                <asp:ListItem>2025</asp:ListItem>
                                <asp:ListItem>2026</asp:ListItem>
                                <asp:ListItem>2027</asp:ListItem>
                                <asp:ListItem>2028</asp:ListItem>
                                <asp:ListItem>2029</asp:ListItem>
                                <asp:ListItem>2030</asp:ListItem>
                                </asp:DropDownList>
                            &nbsp;<br />
                                <asp:Button ID="btnExport" runat="server" Text="Export" Visible="False"/>
                                &nbsp;&nbsp; </td>
                    </tr>
                    </table>
                </td>
                <td style="vertical-align:top; text-align: left;">
                    <table class="auto-style1">
                        <tr>
                            <td style="text-align: left">
                                &nbsp;
                                <br />
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
            </tr>
        </table>
    
    </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
