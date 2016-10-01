<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Createtic.aspx.vb" Inherits="WebTarget.WebForm5" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel ="stylesheet" href ="mbcsmbmcp.css" type ="text/css" />
    <%--<script type="text/javascript">
        function validateRadUpload1(source, args) {
            args.IsValid = $find("<%# RadUpload1.ClientID %>").validateExtensions();
    }
</script>--%>
   
     <style type="text/css">

         .auto-style5 {
             width: 809px;
             text-align: left;
             vertical-align:top;
         }
         
         .auto-style11 {
             width: 1366px;
         }
         .auto-style1 {
             height: 272px;
             width: 1169px;
         }

         .auto-style20 {
             text-align: left;
         }

         .auto-style21 {
             text-align: right;
             width: 284px;
         }

         .auto-style22 {
             width: 270px;
             text-align: left;
         }
         .auto-style23 {
             width: 270px;
             text-align: left;
             height: 27px;
         }
         .auto-style24 {
             height: 23px;
             width: 270px;
             text-align: left;
         }

         .auto-style25 {
             width: 85px;
             text-align: left;
             vertical-align: top;
         }

         .auto-style26 {
             text-align: right;
             width: 284px;
             height: 4px;
         }

         .auto-style27 {
             text-align: right;
             width: 284px;
             height: 27px;
         }

         </style>
    
</head>
<body style="background-color:white">
    <form id="form1" runat="server" style="vertical-align:top">

         <script type="text/javascript">
             //var hash = {
             //    'xls': 1,
             //    'xlsx': 1,
             //    'txt': 1,

             //};

             function check_extension(filename, submitId) {
                 var hash = '.xls,.xlsx,.txt';
                 var re = /\..+$/;
                 var ext = filename.match(re);
                 var submitEl = document.getElementById(submitId);
                 //alert(ext);
                 //alert(hash.indexOf(ext));
                 if (hash.indexOf(ext) > 0) {
                     submitEl.disabled = false;
                     return true;
                 } else {
                     alert("Invalid filename, please select another file");
                     submitEl.disabled = true;

                     return false;
                 }
             }
        </script>


     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <%--<input type="file" name="FILENAME"  size="20" onchange="check_extension(this.value,'upload');"/>
<input type="submit" id="upload" name="upload" value="Attach" disabled="disabled" />--%>
       <p style="font-size: large; color: #00CC00; text-align: left; background-color: #515151;"><strong style="color: #b6ff00">CREATE TICKET</strong></p>
         <asp:UpdatePanel runat="server"><ContentTemplate>
         <table class="auto-style1">
        <tr>
            <td style="text-align: left" class="auto-style11">
                
   
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style21" ><strong>Account Name</strong></td>
                        <td class="auto-style22">
                            <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource4" DataTextField="account_name" DataValueField="account_name" Height="23px" style="margin-left: 0px" Width="166px" AutoPostBack="True" AppendDataBoundItems="true">
                                <asp:ListItem Selected="True">Select Account</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Support-TicketConnectionString %>" SelectCommand="SELECT [account_name] FROM [TICKET_ACCOUNT]"></asp:SqlDataSource>
                        </td>
                        <td class="auto-style25" rowspan="10">
                            <strong>Description</strong></td>
                        <td class="auto-style5" rowspan="10">
                            <asp:TextBox ID="txtdesc" runat="server" Height="158px" Width="344px" TextMode="MultiLine" ></asp:TextBox>
                            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="Button2" runat="server" Text="Save" Width="68px" BackColor="#FF9933" Height="26px" />
&nbsp;
                <asp:Button ID="btnclear" runat="server" Text="Clear" Width="65px" BackColor="#FF9933" Height="25px" />
                        </td>
                        <td class="auto-style20" rowspan="10">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style21" ><strong>Project Code</strong></td>
                        <td class="auto-style22">
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="23px" style="margin-left: 0px" Width="166px">
                                <asp:ListItem Selected="True">Select Project</asp:ListItem>
                            </asp:DropDownList>                
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Support-TicketConnectionString %>" SelectCommand="SELECT [project_code] FROM [TICKET_PROJECT]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style21" ><strong>Branch Name</strong></td>
                        <td class="auto-style22">
                            <asp:DropDownList ID="DropDownList2" runat="server" Height="23px" style="margin-left: 0px" Width="166px">
                                <asp:ListItem Selected="True">Select Branch</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Support-TicketConnectionString %>" SelectCommand="SELECT [branch_id], [branch_name] FROM [TICKET_BRANCH]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style27"><strong>Raise Name</strong></td>
                        <td class="auto-style23">
                            <asp:TextBox ID="txtrname" runat="server" Height="16px" Width="156px" MaxLength="20" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style21"><strong>Raise Phone</strong></td>
                        <td class="auto-style24">
                            <asp:TextBox ID="txtrtell" runat="server" Height="16px" Width="156px" MaxLength="20" AutoPostBack="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style21"><strong>Contact Person</strong></td>
                        <td class="auto-style24">
                            <asp:TextBox ID="txtperson" runat="server" Width="156px" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style21"><strong>Contact Phone </strong></td>
                        <td class="auto-style24">
                            <asp:TextBox ID="txttell" runat="server" Width="157px" Height="19px" AutoPostBack="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style21"><strong>Contact Email</strong></td>
                        <td class="auto-style24">
                            <asp:TextBox ID="txtmail" runat="server" Height="16px" Width="156px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style26" style="vertical-align:top;"><strong>Attachment</strong></td>
                        <td class="auto-style22" rowspan="2">
                            <telerik:RadUpload ID="RadUpload1" Runat="server" ControlObjectsVisibility="RemoveButtons, AddButton, DeleteSelectedButton">
                            </telerik:RadUpload>
                            <br />
                          <%-- <asp:CustomValidator runat="server" ID="CustomValidator1" Display="Dynamic" ClientValidationFunction="validateRadUpload1()"
    OnServerValidate="CustomValidator1_ServerValidate">        
    Invalid extension.
</asp:CustomValidator>--%>
&nbsp;
                                                         
                   
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style21">&nbsp;</td>
                    </tr>
                </table>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;
                 <br />                
            </td>
        </tr>
        </table> 
             </ContentTemplate></asp:UpdatePanel> 
    </form>
</body>
</html>
