<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="WebTarget.WebForm6" ValidateRequest = "false" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style type="text/css">
        .auto-style63 {
            width: 1024px;
            height: 768px;
        }
        .auto-style66 {
            width: 185px;
        }
        .auto-style78 {
            height: 286px;
            width: 185px;
        }
        .auto-style80 {
            height: 286px;
        }
        .auto-style81 {
            height: 286px;
            width: 646px;
        }
        .auto-style83 {
            width: 646px;
        }
        .auto-style84 {
            width: 99%;
            height: 250px;
        }
        .auto-style86 {
            width: 201px;
            text-align: center;
        }
        .auto-style87 {
            color: #FFFFFF;
            font-size: large;
        }
        .auto-style88 {
            width: 201px;
            text-align: right;
            height: 36px;
        }
        .auto-style89 {
            width: 309px;
            height: 36px;
            text-align: left;
        }
        .auto-style90 {
            width: 309px;
        }
        .auto-style91 {
            height: 227px;
            width: 185px;
        }
        .auto-style92 {
            height: 227px;
            width: 646px;
        }
        .auto-style93 {
            height: 227px;
        }
        .auto-style94 {
            width: 201px;
            text-align: left;
            color: #FFFFFF;
            font-size: x-large;
            height: 79px;
        }
        .auto-style95 {
            width: 309px;
            height: 79px;
        }
        .auto-style96 {
            font-size: xx-large;
        }
         .txtbox
        {
            border-top-left-radius: 20px;
            border-top-right-radius: 20px;
            border-bottom-left-radius: 20px;
            border-bottom-right-radius: 20px;
        }
    </style>
        </style>
</head>
   
<body style="background-image:url('Image/Login/01-login.gif'); background-repeat:no-repeat;background-color:#BABABA; height: 769px;background-position:center">
    <center>
    
    <form id="form1" runat="server">
    
    <table class="auto-style63">
        <tr>
            <td class="auto-style78"></td>
            <td class="auto-style81">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td class="auto-style80"></td>
        </tr>
        <tr>
            <td class="auto-style91"></td>
            <td class="auto-style92" >
                <asp:UpdatePanel runat="server"><ContentTemplate>
                <table  class="auto-style84" style="background-repeat:no-repeat;background-image:url(Image/Login/lg-n.png)">
                    <tr>
                        <td class="auto-style94" style="vertical-align:top"><strong style="vertical-align:top; text-align: right;">&nbsp;&nbsp; <span class="auto-style96">LOGIN</span></strong></td>
                        <td class="auto-style95"></td>
                        <td rowspan="3">
                            
                            <asp:ImageButton ID="btnlogin" runat="server" Height="211px" ImageUrl="Image/Login/login_08.png" Width="95px" />
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style88"><strong><span class="auto-style87">Username :</span><br class="auto-style87" />
                            </strong>&nbsp;<strong><br class="auto-style87" />
                            <span class="auto-style87">Password :</span></strong></td>
                        <td class="auto-style89">
                            <asp:TextBox ID="txtuser" Class="txtbox"  runat="server" MaxLength="12" Width="163px" AutoPostBack="True" ></asp:TextBox>
                            <br />
                            <br />
                            <asp:TextBox ID="txtpass" Class="txtbox" runat="server" MaxLength="12" TextMode="Password" Width="163px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style86">&nbsp;</td>
                        <td class="auto-style90">&nbsp;</td>
                    </tr>
                </table>
                    </ContentTemplate></asp:UpdatePanel>
            </td>
            <td class="auto-style93"></td>
        </tr>
        <tr>
            <td class="auto-style66">&nbsp;</td>
            <td class="auto-style83">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </form>
        </center>
</body>
</html>
