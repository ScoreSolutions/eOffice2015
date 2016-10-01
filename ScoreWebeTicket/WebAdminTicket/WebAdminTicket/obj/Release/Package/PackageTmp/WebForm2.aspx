<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm2.aspx.vb" Inherits="WebTarget.WebForm2" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
                               
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <style type="text/css">
        <!--
        .style1 {
            color: #e65019;
        }
        -->
    </style>
    <script type="text/javascript">
        $(function () {

            var crd = new Date();
            $('#date1').val(crd);

        });
        </script>
    </head>
    <body style="margin: 0; padding: 0;">
        <table align="center" border="1" cellpadding="0" cellspacing="0" width="600">
            <tr>
            <td align="center" bgcolor="#70bbd9" style="padding: 40px 0 30px 0;"><img src="http://192.168.1.107:8080/Image/logo.jpg" alt="Creating Email Magic" width="599px" height="150px" style="display: block;" /></td>
          
            </tr>
            <tr>
                <td bgcolor="#ffffff" style="padding: 40px 30px 40px 30px;">
                    <table width="100%" border="1" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="51%">Ticket Number : T001 </td>

                            <td width="49%" align="right"><p id="date1"></p></td>
                        </tr>
                        <tr>
                            <td style="padding: 20px 0 30px 0;" colspan="3">
                                <p>ÁÕ»Ñ­ËÒ........................</p>
                                <p>&nbsp;</p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <table border="1" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td width="260" valign="top">
                                            <table border="1" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <img src="http://192.168.1.107:8080/Image/เจ้าหน้าที่และการแก้ไขปัญหา.jpg" alt="" width="259" height="140" style="display: block;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="143" style="padding: 25px 0 0 0;">
                                                        <p>àÇÅÒ·Õèãªé............................................</p>
                                                        <p>àÇÅ·Õè·Õè»Ô´</p>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="font-size: 0; line-height: 0;" width="20">&nbsp;  </td>
                                        <td width="260" valign="top">
                                            <table border="1" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <img src="http://192.168.1.107:8080/Image/แก้ไขปันหา.jpg" alt="" width="259" height="140" style="display: block;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 25px 0 0 0;">
                                                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. In tempus adipiscing felis, sit amet blandit ipsum volutpat sed. Morbi porttitor, eget accumsan dictum, nisi libero ultricies ipsum, in posuere mauris neque at erat.</p>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>Open Date : 11 ¡Ñ¹ÂÒÂ¹ ¾.È. 2557</td>
                            <td width="49%">Close Date : 11 ¡Ñ¹ÂÒÂ¹ ¾.È. 2557</td>

                        </tr>
                    </table>
                </td>
             
            </tr>
            <tr>
                <td bgcolor="#ee4c50" style="padding: 30px 30px 30px 30px;"><a href="www.scoresolutions.co.th">Confirm</a></td>
          
            </tr>
        </table>
    </body>
</html>