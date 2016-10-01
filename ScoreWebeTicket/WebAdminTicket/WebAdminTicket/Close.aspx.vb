Imports System.Net.Mail
Imports System.IO
Imports System.Data.SqlClient
Imports Telerik.Web.UI


Public Class Close
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Support-TicketConnectionString").ConnectionString)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            RadGrid1.DataSource = Data() 'binddata ลง gridview
            RadGrid1.DataBind()
        End If
    End Sub
    Private Function Data() As DataSet 'ฟังก์ชั่น ดึงข้อมูลมาใส่ gridview
        Dim text As String = "SELECT ticket_code,resolved,email_customer from TICKET_TICKET"
        Dim cmd As New SqlCommand(text, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        con.Close()
        Return ds
    End Function
    Protected Sub RadGrid1_ItemCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand

        Dim mailcus As Label = e.Item.FindControl("Label3") 'กำหนดตัวแปลรับค่าอีเมล์ของลูกค้าที่อยู่ใน gridview
        Dim tkcode As Label = e.Item.FindControl("Label1") 'กำหนดตัวแปลรับค่า Ticket code ของลูกค้าที่อยู่ใน gridview
        Dim send As New SM.Service1
        '------------------------------------------------
        'เช็คว่าสถานะว่า Ticketcode นี้ถูกส่งเมลรึยัง
        con.Open()
        Dim chn As String
        chn = "Select statuscus_id from TICKET_Ticket where ticket_id = (select ticket_id from TICKET_TICKET where ticket_code = '" & tkcode.Text & "')"
        Dim cmd1 As New SqlCommand(chn, con)
        Dim da1 As New SqlDataAdapter(cmd1)
        Dim ds1 As New DataSet()
        da1.Fill(ds1)
        If ds1.Tables(0).Rows(0)(0) = 1 Or ds1.Tables(0).Rows(0)(0) = 3 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('This Ticket is sended');", True)
            Return
        End If
        '-----------------------------------------------

        '-----------------------------------------------
        'จอยข้อมูลที่จะใช้ส่งไปพร้อมกับเมล์ให้ลูกค้า
        Dim sq As String
        sq = "Select TICKET_TICKET.ticket_code,TICKET_TICKET.create_on,TICKET_TICKET.ticket_description,TICKET_TICKET.resolved,TICKET_STAFF.staffname from TICKET_TICKET join TICKET_STAFF on TICKET_TICKET.assign_to = TICKET_STAFF.username where TICKET_TICKET.ticket_code = '" & tkcode.Text & "' "
        Dim cmd As New SqlCommand(sq, con)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        If mailcus.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Cannot Send because Data not complete.');", True)
        Else
            Dim ticketnum As String = ds.Tables(0).Rows(0)(0).ToString
            Dim timestart As String = ds.Tables(0).Rows(0)(1).ToString
            Dim tkdesc As String = ds.Tables(0).Rows(0)(2).ToString
            Dim resolve As String = ds.Tables(0).Rows(0)(3).ToString
            Dim name As String = ds.Tables(0).Rows(0)(4).ToString

            Dim StrWer As StreamWriter = Nothing
            Try 'เขียน html file เพื่อใช้ส่งเมล์
                Dim host As String = "http://" & HttpContext.Current.Request.Url.Host & "/WebTicket/Email/confirmmail.html"
                Session("host") = host
                Dim a As String = Server.MapPath("~/Email/" & "confirmmail.html")
                Session("a") = a
                Dim pic1 As String = "http://" & HttpContext.Current.Request.Url.Host & "/WebTicket/Image/logo.jpg"
                Dim pic2 As String = "http://" & HttpContext.Current.Request.Url.Host & "/WebTicket/Image/howto.jpg"
                Dim pic3 As String = "http://" & HttpContext.Current.Request.Url.Host & "/WebTicket/Image/edit.jpg"
                StrWer = File.CreateText(a)
                StrWer.WriteLine(" <html>")
                StrWer.WriteLine(" <head>")
                StrWer.WriteLine(" <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />")
                StrWer.WriteLine(" </head>")
                StrWer.WriteLine(" <body>")
                StrWer.WriteLine(" <table align='center' border='1' cellpadding='0' cellspacing='0' width='600'> ")
                StrWer.WriteLine("    <tr>")
                StrWer.WriteLine("        <td align='center' bgcolor='#70bbd9' style='padding: 40px 0 30px 0;'><img src='" & pic1 & "' alt='Creating Email Magic' width='650px' height='150px' style='display: block;'/></td> ")
                StrWer.WriteLine("    </tr>")
                StrWer.WriteLine("    <tr>")
                StrWer.WriteLine("        <td bgcolor='#ffffff' style='padding: 40px 30px 40px 30px;'>")
                StrWer.WriteLine("    <table width='100%' border='1' align='center' cellpadding='0' cellspacing='0'>")
                StrWer.WriteLine("    <tr>")
                StrWer.WriteLine("         <td width='51%'>Ticket Number : " & ticketnum & " </td>")
                StrWer.WriteLine("         <td width='49%' align='right'>" & Now & "</p></td>")
                StrWer.WriteLine("    </tr>")
                StrWer.WriteLine("    <tr>")
                StrWer.WriteLine("    <td style='padding: 20px 0 30px 0;' colspan='3'>")
                StrWer.WriteLine("    <p>รายละเอียดของปัญหา</p><textarea rows='6' cols='100' disabled>" & tkdesc & "</textarea>")
                StrWer.WriteLine("    <p>&nbsp;</p>")
                StrWer.WriteLine("    </td>")
                StrWer.WriteLine("    </tr>")
                StrWer.WriteLine("    <tr>")
                StrWer.WriteLine("    <td colspan='2'>")
                StrWer.WriteLine("    <table border='0' cellpadding='0' cellspacing='0' width='100%'>")
                StrWer.WriteLine("    <tr>")
                StrWer.WriteLine("     <td width='271' valign='top'>")
                StrWer.WriteLine("     <table border='1' cellpadding='0' cellspacing='0' width='100%'>")
                StrWer.WriteLine("      <tr>")
                StrWer.WriteLine("    <td>")
                StrWer.WriteLine("    <img src='" & pic2 & "' width='100%' height='100%' style='display: block;' />")
                StrWer.WriteLine("    </td>")
                StrWer.WriteLine("    </tr>")
                StrWer.WriteLine("    <tr>")
                StrWer.WriteLine("     <td height='135px' style='padding: 25px 0 0 0;vertical-align:top;'>")
                StrWer.WriteLine("    <p>ชื่อ</p><textarea rows='4' cols='40' disabled> " & name & "</textarea>")
                StrWer.WriteLine("     </td>")
                StrWer.WriteLine("    </tr>")
                StrWer.WriteLine("    </table>")
                StrWer.WriteLine("     <td width='260' valign='top'>")
                StrWer.WriteLine("     <table border='1' cellpadding='0' cellspacing='0' width='100%'>")
                StrWer.WriteLine("    <tr>")
                StrWer.WriteLine("    <td>")
                StrWer.WriteLine("    <img src='" & pic3 & "' width='100%' height='100%' style='display: block;' />")
                StrWer.WriteLine("    </td>")
                StrWer.WriteLine("    </tr>")
                StrWer.WriteLine("     <tr>")
                StrWer.WriteLine("    <td height='135px' style='padding: 25px 0 0 0;vertical-align:top;'>")
                StrWer.WriteLine("    <p>วิธีแก้ปัญหา</p><textarea rows='4' cols='40' disabled>" & resolve & "</textarea>")
                StrWer.WriteLine("    </td></tr>")
                StrWer.WriteLine("   </table>")
                StrWer.WriteLine("	 </td></tr>")
                StrWer.WriteLine("	 </table></td></tr>")
                StrWer.WriteLine("	 <tr>")
                StrWer.WriteLine("	 <td>เวลาเริ่ม Ticket " & timestart & "</td>")
                StrWer.WriteLine("	 <td width='49%'>เวลาปิด Ticket " & Now & "</td>")
                StrWer.WriteLine("	  </tr></table></td> </tr><tr>")
                StrWer.WriteLine("	 <td bgcolor='#ee4c50' style='padding: 30px 30px 30px 30px;'><a href='192.168.1.107/ws_tk/?type=mailconfirm&state=1&tkid=" & ticketnum & "'>Confirm</a>   <a href='192.168.1.107/ws_tk/?type=mailconfirm&state=3&tkid=" & ticketnum & "'>No Confirm</a></td>")
                StrWer.WriteLine("	 </tr></table>")
                StrWer.WriteLine(" </body>")
                StrWer.WriteLine(" </html>")
                StrWer.Close()

                Dim strReturn1 As String = send.SendEmail(host, mailcus.Text)
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('" & strReturn1 & ":" & mailcus.Text & "');alert('Send Email Complete.');", True)

                'อัพเดทสถานะ ticket หลังจากทำการส่งเมล์ไปแล้ว
                Dim sql As String = "UPDATE TICKET_TICKET SET statusticket_id = '4',close_by = '" & Session("state") & "',close_on = GetDate() where ticket_code = '" & tkcode.Text & "' "
                con.Open()
                With cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Connection = con
                    .ExecuteNonQuery()
                End With
                con.Close()
            Catch ex As Exception
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('" & Session("host") & ":" & mailcus.Text & "':" & Session("a") & "');alert('Send Email Complete.');", True)
            End Try
        End If
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'ป๊อบอัพ หน้า close ticket เพื่อไปปิด ticket สำหรับลูกค้าที่แก้ปัญหาเองได้แล้ว
        Dim strScripth As String = "window.open('./Closepop.aspx');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", strScripth, True)
    End Sub
End Class