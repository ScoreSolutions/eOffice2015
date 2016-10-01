<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="searchpage.aspx.vb" Inherits="WebTarget.searchpage" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title> 
    <script type="text/javascript">
        function seLection() {                    
            document.getElementById("Label1").innerText = localStorage.getItem('Label1');
           Click();
        }  
        function myFunction() {//get ticket code to show on label
            var a = document.getElementById("button");            
            document.getElementById("Label1").innerText = localStorage.getItem('Label1');
        }
       </script>    
    <style type="text/css">
        .auto-style1 {
            width: 351px;
            height: 280px;
        }
        .auto-style2 {
            width: 99%;
            height: 274px;
        }
        .auto-style3 {
            width: 103px;
            text-align: center;
            color: #000000;
            font-weight: bold;
        }
        .auto-style10 {
            width: 103px;
            height: 30px;
            text-align: center;
        }
        .auto-style11 {
            height: 30px;
            text-align: left;
        }
        .auto-style14 {
            vertical-align:top;
            width: 103px;
            height: 109px;
            text-align: center;
            color: #000000;
            font-weight: bold;
        }
        .auto-style15 {
            vertical-align:top;
            height: 109px;
            text-align: left;
        }
        .auto-style16 {
            text-align: left;
        }
        .auto-style17 {
            color: #CC0000;
        }
        .auto-style18 {
            text-align: left;
            color: #CC0000;
            font-weight: bold;
        }
        .auto-style19 {
            width: 103px;
            height: 30px;
            text-align: center;
            color: #000000;
            font-weight: bold;
        }
        .auto-style20 {
            font-weight: bold;
        }
        .auto-style21 {
            color: #000000;
            font-weight: 700;
        }
    </style>
</head>
<body class="auto-style1" onload="seLection()" style="background-color:yellowgreen">
    <form id="form1" runat="server">
  
        <table class="auto-style1" style="background-color:skyblue;border:groove;">
            <tr>
                <td style="vertical-align:top">
                   
                  
                    <table class="auto-style2" style="border:medium">
                        <tr>
                            <td class="auto-style10">
                    <asp:Label ID="Label1" runat="server" style="text-align: center" Text="Label" CssClass="auto-style20" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
                            </td>
                            <td class="auto-style18">Details</td>
                        </tr>
                        <tr>
                            <td class="auto-style19">Project Code</td>
                            <td class="auto-style11">
                                <asp:Label ID="Label2" runat="server" Text='<%# bind("TICKET_PROJECT.project_code") %>' CssClass="auto-style21"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style19">Branch Name</td>
                            <td class="auto-style11">
                                <asp:Label ID="Label3" runat="server" Text='<%# bind("TICKET_BRANCH.branch_name") %>' CssClass="auto-style21"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">Description</td>
                            <td class="auto-style15">
                                <asp:TextBox ID="TextBox1" runat="server" Height="93px" TextMode="MultiLine" Width="215px" CssClass="auto-style17" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style19">Ticket Status</td>
                            <td class="auto-style11">
                                <asp:Label ID="Label5" runat="server" Text='<%# bind("TICKET_STATUS_TICKET.statusticket_name") %>' CssClass="auto-style21"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Assign To</td>
                            <td class="auto-style16">
                                <asp:Label ID="Label6" runat="server" Text='<%# bind("TICKET_TICKET.assign_to") %>' CssClass="auto-style21"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>  
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
   
    </form>
</body>
</html>
