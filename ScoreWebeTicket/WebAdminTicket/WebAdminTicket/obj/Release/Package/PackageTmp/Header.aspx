<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Header.aspx.vb" Inherits="WebTarget.Header" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
<link rel ="stylesheet" href ="mbcsmbmcp.css" type ="text/css" />
<link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script> 
<script type="text/javascript">
    $(document).ready(function () {
        SearchText();
    });
    function SearchText() {
        $(".autosuggest").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "Header.aspx/GetAutoCompleteData",
                    data: "{'username':'" + document.getElementById('txtSearch').value + "'}",
                    dataType: "json",
                    success: function (data) {
                        response(data.d);
                    },
                    error: function (result) {
                        alert("Error");
                    }
                });
            }
        });
    }
     function confirmNavigation() {
          <% Session("statususer") = "2"%>
         return confirm('Please Confirm To Logout');
     }
</script>  
    
     <style type="text/css">

        html {min-height:100%
}

        body {
	background-image: -webkit-gradient(
	linear,
	left top,
	left bottom,
	color-stop(0, #2A2A2A),
	color-stop(0.55, #2A2A2A)
);
background-image: -o-linear-gradient(bottom, #2A2A2A 0%, #2A2A2A 55%);
background-image: -moz-linear-gradient(bottom, #2A2A2A 0%, #2A2A2A 55%);
background-image: -webkit-linear-gradient(bottom, #2A2A2A 0%, #2A2A2A 55%);
background-image: -ms-linear-gradient(bottom, #2A2A2A 0%, #2A2A2A 55%);
background-image: linear-gradient(to bottom, #2A2A2A 0%, #2A2A2A 55%);
}
        .auto-style1 {
            width: 103%;
             height: 26px;
             margin-right: 2px;
             margin-bottom: 0px;
         }
                           	 
      
        .content {
          vertical-align:top;
            width: 100%;
	background-image: -webkit-gradient(
	linear,
	left top,
	left bottom,
	color-stop(0.07, #2A2A2A),
	color-stop(0.55, #2A2A2A)
);
background-image: -o-linear-gradient(bottom, #2A2A2A 7%, #2A2A2A 55%);
background-image: -moz-linear-gradient(bottom, #2A2A2A 7%, #2A2A2A 55%);
background-image: -webkit-linear-gradient(bottom, #2A2A2A 7%, #2A2A2A 55%);
background-image: -ms-linear-gradient(bottom, #2A2A2A 7%, #2A2A2A 55%);
background-image: linear-gradient(to bottom, #2A2A2A 7%, #2A2A2A 55%);
border-radius:10px;
}
        
        .center{
            width :100%;
            height :309px;
            
        }

         .auto-style6 {
             width: 20px;
             height: 141px;
         }

         #form1 {
             font-weight: 700;
         }

         .auto-style7 {
             width: 490px;
         }

         .auto-style8 {
             width: 134px;
         }

    </style>
</head>
<body>
   <form id="form1" runat="server">
       <div>
          <table class="auto-style1" align="center">
           <tr>
            <td class="auto-style8" style="vertical-align:top" rowspan="2">
                <asp:Image ID="Image1" runat="server" Height="92px" ImageUrl="~/Image/logo.png" Width="213px" />
                <br />
                 </td>
            <td class="auto-style7" style="vertical-align:top; text-align: center;" rowspan="2">
                <br />
                        <asp:TextBox ID="txtSearch" runat="server" Height="16px" Width="351px" BackColor="#FFFF66" style="margin-left: 0px" BorderStyle="None" class="autosuggest"></asp:TextBox>
                        <asp:Button ID="rbShowDialog" runat="server" Text="Search" Width="67px" Height="18px" BackColor="#A5DA03" Font-Bold="True" ForeColor="#3366FF" BorderStyle="None" OnClick="rbShowDialog_click" OnClientClick="window.open('MainPage.aspx', 'contentPane');"/>
                        </td>
        </tr>
        <tr>
             <td style="vertical-align:top" class="auto-style6"><ul id="mbmcpebul_table" class="mbmcpebul_menulist css_menu" style="width: 493px; height: 44px;">
  <li class="topitem spaced_li first_button"><div class="buttonbg gradient_button gradient40"><div class="arrow"><a style="color:red;font-size:large">Admin ▼</a></div></div>
  <ul class="gradient_menu gradient116">
  <li class="gradient_menuitem gradient29 last_item"><asp:Hyperlink ID="HyperLink2" runat="server" NavigateUrl="~/Login.aspx" Target="_parent" OnClick="return confirmNavigation();">Logout</asp:Hyperlink></li>
  </ul></li>
  <li class="topitem spaced_li"><div class="buttonbg gradient_button gradient40" style="width: 110px;"><div class="arrow"><a href="MainPage.aspx" target="contentPane" >Summary</a></div></div></li>
  <li class="topitem spaced_li"><div class="buttonbg gradient_button gradient40" style="width: 127px;"><div class="arrow"><a >Master Data▼</a></div></div>
  <ul class="gradient_menu gradient145">
  <li class="gradient_menuitem gradient29 first_item"><a title="" href="User.aspx" target="contentPane">User</a></li>
  <li class="gradient_menuitem gradient29"><a title="" href="Group.aspx" target="contentPane">Group</a></li>
  <li class="gradient_menuitem gradient29"><a title="" href="Role.aspx" target="contentPane">Role</a></li>
  <li class="gradient_menuitem gradient29 last_item"><a title="" href="Customer.aspx" target="contentPane">Account</a></li>
  </ul></li>
  <li class="topitem spaced_li"><div class="buttonbg gradient_button gradient40" style="width: 114px;"><div class="arrow"><a >Management▼</a></div></div>
  <ul class="gradient_menu gradient58">
  <li class="gradient_menuitem gradient29 first_item"><a title="" href="createtic.aspx" target="contentPane">Create</a></li>
      <li class="gradient_menuitem gradient29"><a title="" href="list.aspx" target="contentPane">List</a></li>
      <li class="gradient_menuitem gradient29"><a title="" href="Close.aspx" target="contentPane">Close</a></li>
  <li class="gradient_menuitem gradient29 last_item"><a title="" href="report.aspx" target="contentPane" >Report</a></li>
  </ul></li>
</ul>
   <script type="text/javascript" src="mbjsmbmcp.js"></script>
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 &nbsp;<br />
                 <br />
             </td>
        </tr>
 </table>  
    </div>
    </form>
    
</body>
</html>
