Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Net.Mail
Imports Microsoft.VisualBasic
Imports System.Web.Configuration.WebConfigurationManager

Public Class email
    Private Shared MyConn As New SqlConnection(ConnectionStrings("MyConn").ToString)
    Private Shared func As New EtimesheetSystem

    Private Shared Function SendEmail(ByVal MailTo As String, ByVal MailSubject As String, ByVal MailBody As String) As Boolean
        Try
            Dim SMTPMailFrom As String = ConfigurationManager.AppSettings("SMTPMailFrom").ToString()
            Dim SMTPServer As String = ConfigurationManager.AppSettings("SMTPServer").ToString()
            Dim SMTPPassword As String = ConfigurationManager.AppSettings("SMTPPassword").ToString()
            Dim MailPort As String = ConfigurationManager.AppSettings("MailPort").ToString()
            Dim MailSSL As String = ConfigurationManager.AppSettings("MailSSL").ToString()

            Dim MailMsg As New MailMessage
            MailMsg.From = New MailAddress(SMTPMailFrom)
            Dim strMail() As String = MailTo.Replace(",", ";").Split(";")
            For i As Integer = 0 To strMail.Length - 1
                MailMsg.To.Add(New MailAddress(strMail(i).Trim()))
            Next

            MailMsg.Subject = MailSubject
            MailMsg.Body = MailBody

            MailMsg.IsBodyHtml = True
            MailMsg.From = New MailAddress(SMTPMailFrom, SMTPMailFrom, System.Text.Encoding.GetEncoding("iso-8859-11"))
            'MailMsg.Headers.Add("Reply-To", "nongnuch@scoresolutions.com")

            'Dim att As New Net.Mail.Attachment("D:\Desert.jpg")
            'att.ContentId = "ATTIMG1"
            'MailMsg.Attachments.Add(att)

            Dim SmtpMail As New SmtpClient(SMTPServer)
            SmtpMail.EnableSsl = MailSSL
            SmtpMail.Port = MailPort
            SmtpMail.Credentials = New Net.NetworkCredential(SMTPMailFrom, SMTPPassword)
            SmtpMail.Send(MailMsg)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#Region "E Timesheet"
    Public Shared Function SendEmailETimeSheet(ByVal Email As String, _
                                                ByVal ToName As String, _
                                                ByVal MailSubject As String, _
                                                ByVal detail As String, _
                                                ByVal MailToken As String) As Boolean
        Try
            Return SendEmail(Email, MailSubject, MailDetail_SendTimeSheet(ToName, detail, MailToken))
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Shared Function MailDetail_SendTimeSheet(ByVal ToName As String, ByVal Detail As String, ByVal MailToken As String) As String
        ' ISSender Y = sender, ISSender N = pm or cost controller
        ' Type 1 = when close redirect to etimesheetdetail.aspx, Type 3 = when close redirect to pm/costcontroller approve page

        Dim MailReturn As String = ConfigurationManager.AppSettings("MailReturn").ToString()
        Dim strBody As New StringBuilder
        strBody.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%'>")
        strBody.Append("    <tr>")
        strBody.Append("        <td>Dear Khun " & ToName & "</td> </br>")
        strBody.Append("    </tr>")
        strBody.Append("    <tr>")
        strBody.Append("         <td style='padding-left:50px;'>" & Detail & "</td> </br>")
        strBody.Append("    </tr>")
        strBody.Append("    <tr>")
        strBody.Append("        <td >For more information please  <a href='" & MailReturn & "ET_ViewTimeSheetDetail.aspx?token=" & System.Web.HttpUtility.UrlEncode(MailToken) & "' target='_blank' >Click Here</a> </td>")
        strBody.Append("    </tr>")
        strBody.Append("    <tr>")
        strBody.Append("    </tr>")
        strBody.Append("</table>")
        Return strBody.ToString
    End Function


    Public Shared Function ETimeSheetSendMailApprove(ByVal TimeSheetID As String) As Boolean
        Dim SendNotComplete As Integer = 0
        Try
            Dim sql As String = "select ts.id, ts.user_id, u1.username, U2.email,U1.name + ' ' + U1.surname as sendername,"
            sql += " U2.name + ' ' + U2.surname as ProjectManager_Name, ts.timesheet_status  "
            sql &= " from eOFFICE_TIMESHEET  TS"
            sql &= " inner join eOFFICE_USER U1 on TS.user_id =U1.id "
            sql &= " inner join eOFFICE_USER U2 on TS.pm_user_id =U2.id "
            sql &= " where TS.id='" & TimeSheetID & "'"
            func.checkConn(MyConn)
            Dim da As New SqlDataAdapter(sql, MyConn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim toemail As String = dt.Rows(0)("email").ToString()
                Dim sendername As String = dt.Rows(0)("sendername").ToString()
                Dim pm_name As String = dt.Rows(0)("ProjectManager_Name").ToString
                Dim MailToken As String = SaveMailToken(dt.Rows(0)("id"), dt.Rows(0)("user_id"), dt.Rows(0)("username"), dt.Rows(0)("timesheet_status"), "ET_ViewTimeSheetDetail.aspx")

                If MailToken.Trim <> "" Then
                    If toemail <> "" And sendername <> "" Then
                        Dim mailsubject As String = "E Timesheet Wait for Project Manager Approval(" & sendername & ")"
                        Dim detail As String = "Please review and approve eTimesheet"
                        Dim ret As Boolean = SendEmailETimeSheet(toemail, pm_name, mailsubject, detail, MailToken)

                        If ret = False Then
                            ret = SendEmailETimeSheet(toemail, pm_name, mailsubject, detail, MailToken)
                            If ret = False Then
                                SendNotComplete = 1
                            End If
                        End If
                    Else
                        SendNotComplete = 1
                    End If
                Else
                    SendNotComplete = 1
                End If
            Else
                SendNotComplete = 1
            End If
        Catch ex As Exception
            SendNotComplete = 1
        End Try

        Return IIf(SendNotComplete = 0, True, False)

    End Function

    Public Shared Function ETimeSheetSendMailCostController(ByVal TimeSheetID As String) As Boolean
        Dim SendNotComplete As Integer = 0
        Try
            Dim sql As String = "select ts.id, ts.user_id,su.username, U.email,u.name + ' ' + u.surname as cost_control_name, "
            sql += " su.name + ' ' + su.surname sendername,ts.timesheet_status "
            sql += "  from eOFFICE_TIMESHEET TS"
            sql &= " Inner  join eOFFICE_PROJECT_BILLING PB on TS.project_billing_id=PB.id"
            sql &= " Inner  Join eOFFICE_PROJECT PJ on PB.project_id=PJ.id"
            sql &= " Inner  join eOFFICE_USER U on PJ.cost_control_user_id=U.id"
            sql += " inner join eOFFICE_USER su on su.id=ts.user_id"
            sql &= " where  TS.id ='" & TimeSheetID & "'"
            func.checkConn(MyConn)
            Dim da As New SqlDataAdapter(sql, MyConn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim toemail As String = dt.Rows(0)("email").ToString()
                Dim sendername As String = dt.Rows(0)("sendername")
                Dim costCtlname As String = dt.Rows(0)("cost_control_name").ToString
                Dim MailToken As String = SaveMailToken(dt.Rows(0)("id"), dt.Rows(0)("user_id"), dt.Rows(0)("username"), dt.Rows(0)("timesheet_status"), "ET_ViewTimeSheetDetail.aspx")

                If MailToken.Trim <> "" Then
                    If toemail <> "" And costCtlname <> "" Then
                        Dim mailsubject As String = "E Timesheet Wait for Cost Controller Approval(" & sendername & ")"
                        Dim detail As String = "Please review and approve eTimesheet"
                        Dim ret As Boolean = email.SendEmailETimeSheet(toemail, costCtlname, mailsubject, detail, MailToken)
                        If ret = False Then
                            ret = email.SendEmailETimeSheet(toemail, costCtlname, mailsubject, detail, MailToken)
                            If ret = False Then
                                SendNotComplete = 1
                            End If
                        End If
                    Else
                        SendNotComplete = 1
                    End If
                Else
                    SendNotComplete = 1
                End If
            Else
                SendNotComplete = 1
            End If
        Catch ex As Exception
            SendNotComplete = 1
        End Try

        Return IIf(SendNotComplete = 0, True, False)

    End Function

    Public Shared Function ETimeSheetSendMailReject(ByVal TimeSheetID As String, ByVal mailsubject As String, ByVal detail As String) As Boolean

        Dim SendNotComplete As Integer = 0
        Try

            Dim sql As String = "select ts.id, ts.user_id,su.username,su.name + ' ' + su.surname sendername, U.email, ts.timesheet_status "
            sql += " from eOFFICE_TIMESHEET TS "
            sql += " Inner join eOFFICE_USER U on TS.user_id=U.id "
            sql &= " where  TS.id='" & TimeSheetID & "'"
            func.checkConn(MyConn)
            Dim da As New SqlDataAdapter(sql, MyConn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim toemail As String = dt.Rows(0)("email").ToString()
                Dim sendername As String = dt.Rows(0)("sendername")
                Dim MailToken As String = SaveMailToken(dt.Rows(0)("id"), dt.Rows(0)("user_id"), dt.Rows(0)("username"), dt.Rows(0)("timesheet_status"), "ET_ViewTimeSheetDetail.aspx")

                If MailToken.Trim <> "" Then
                    If toemail <> "" And sendername <> "" Then
                        Dim ret As Boolean = email.SendEmailETimeSheet(toemail, sendername, mailsubject, detail, MailToken)
                        If ret = False Then
                            ret = email.SendEmailETimeSheet(toemail, sendername, mailsubject, detail, MailToken)
                            If ret = False Then
                                SendNotComplete = 1
                            End If
                        End If
                    Else
                        SendNotComplete = 1
                    End If
                Else
                    SendNotComplete = 1
                End If
            Else
                SendNotComplete = 1
            End If
        Catch ex As Exception
            SendNotComplete = 1
        End Try

        Return IIf(SendNotComplete = 0, True, False)

    End Function

#End Region

    Private Shared Function SaveMailToken(ByVal vID As String, ByVal vUserID As String, ByVal vUserName As String, ByVal vStatus As String, ByVal ReturnPage As String) As String
        Dim ret As String = ""
        Try
            Dim ets As New EtimesheetSystem
            Dim TokenData As String = ets.EnCripPwd(DateTime.Now.ToString("yyyyMMddhhmmssfff"))

            Dim sql As String = "insert into eOFFICE_EMAIL_TOKEN(created_by,created_date,eoffice_user_id,token_data,current_status,return_page,ref_id)"
            sql += " values('" & vUserName & "',getdate(),'" & vUserID & "','" & TokenData & "','" & vStatus & "','" & ReturnPage & "','" & vID & "')"

            If ets.ExecuteSQL(sql) = True Then
                ret = TokenData
            End If
            ets = Nothing
        Catch ex As Exception
            ret = ""
        End Try
        Return ret
    End Function

#Region "Expenditure"
    
    Private Shared Function MailDetail_SendExpenditure(ByVal ToName As String, ByVal Detail As String, ByVal MailToken As String) As String
        ' ISSender Y = sender, ISSender N = pm or cost controller
        ' Type 1 = when close redirect to etimesheetdetail.aspx, Type 3 = when close redirect to pm/costcontroller approve page

        Dim MailReturn As String = ConfigurationManager.AppSettings("MailReturn").ToString()
        Dim strBody As New StringBuilder
        strBody.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%'>")
        strBody.Append("    <tr>")
        strBody.Append("        <td>Dear Khun " & ToName & "</td> </br>")
        strBody.Append("    </tr>")
        strBody.Append("    <tr>")
        strBody.Append("         <td style='padding-left:50px;'>" & Detail & "</td> </br>")
        strBody.Append("    </tr>")
        strBody.Append("    <tr>")
        strBody.Append("        <td >For more information please  <a href='" & MailReturn & "EP_ViewExpenditureDetail.aspx?token=" & System.Web.HttpUtility.UrlEncode(MailToken) & "' target='_blank' >Click Here</a> </td>")
        strBody.Append("    </tr>")
        strBody.Append("    <tr>")
        strBody.Append("    </tr>")
        strBody.Append("</table>")
        Return strBody.ToString
    End Function



    

    

#Region "Expenditure Send Mail"
    Public Shared Function ExpenditureSendMailApprove(ByVal ExpenditureID As String) As Boolean
        Dim SendNotComplete As Integer = 0
        Try
            Dim sql As String = "select ex.id, su.name + ' ' + su.surname sendername, pu.name + ' ' + pu.surname project_manager_name, pu.email, ex.user_id,su.username, ex.expenditure_status "
            sql += " from eOFFICE_EXPENDITURE ex"
            sql += " inner join eOFFICE_PROJECT_BILLING pb on pb.id=ex.eoffice_project_billing_id"
            sql += " inner join eOFFICE_PROJECT p on p.id=pb.project_id"
            sql += " inner join eOFFICE_USER su on su.id=ex.user_id"
            sql += " inner join eOFFICE_USER pu on pu.id=p.pm_user_id"
            sql += " where ex.id='" & ExpenditureID & "'"
            func.checkConn(MyConn)
            Dim da As New SqlDataAdapter(sql, MyConn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim toemail As String = dt.Rows(0)("email").ToString()
                Dim sendername As String = dt.Rows(0)("sendername").ToString()
                Dim pm_name As String = dt.Rows(0)("project_manager_name").ToString

                If toemail <> "" And sendername <> "" Then
                    Dim mailsubject As String = "E Expenditure Wait for Project Manager Approval(" & sendername & ")"
                    Dim detail As String = "Please review and approve eExpenditure"
                    Dim MailToken As String = SaveMailToken(dt.Rows(0)("id"), dt.Rows(0)("user_id"), dt.Rows(0)("username"), dt.Rows(0)("expenditure_status"), "EP_ViewExpenditureDetail.aspx")

                    If MailToken.Trim <> "" Then
                        Dim MainBody As String = MailDetail_SendExpenditure(pm_name, detail, MailToken)
                        Dim ret As Boolean = email.SendEmail(toemail, mailsubject, MainBody)
                        If ret = False Then
                            ret = email.SendEmail(toemail, mailsubject, MainBody)
                            If ret = False Then
                                SendNotComplete = 1
                            End If
                        End If
                    End If
                End If
            Else
                SendNotComplete = 1
            End If
        Catch ex As Exception
            SendNotComplete = 1
        End Try

        Return IIf(SendNotComplete = 0, True, False)

    End Function

    Public Shared Function ExpenditureSendMailCostController(ByVal ExpenditureID As String) As Boolean
        Dim SendNotComplete As Integer = 0
        Try
            Dim sql As String = "select ex.id, su.name + ' ' + su.surname sendername, cu.name + ' ' + cu.surname cost_control_name, cu.email, ex.user_id,su.username, ex.expenditure_status "
            sql += " from eOFFICE_EXPENDITURE ex"
            sql += " inner join eOFFICE_PROJECT_BILLING pb on pb.id=ex.eoffice_project_billing_id"
            sql += " inner join eOFFICE_PROJECT p on p.id=pb.project_id"
            sql += " inner join eOFFICE_USER su on su.id=ex.user_id"
            sql += " inner join eOFFICE_USER cu on cu.id=p.cost_control_user_id"
            sql += " where ex.id='" & ExpenditureID & "'"
            func.checkConn(MyConn)
            Dim da As New SqlDataAdapter(sql, MyConn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim toemail As String = dt.Rows(0)("email").ToString()
                Dim sendername As String = dt.Rows(0)("sendername").ToString()
                Dim cost_control_name As String = dt.Rows(0)("cost_control_name").ToString
                Dim MailToken As String = SaveMailToken(dt.Rows(0)("id"), dt.Rows(0)("user_id"), dt.Rows(0)("username"), dt.Rows(0)("expenditure_status"), "EP_ViewExpenditureDetail.aspx")

                If MailToken.Trim <> "" Then
                    If toemail <> "" And sendername <> "" Then
                        Dim mailsubject As String = "Expenditure Wait for Cost Controller Approval (" & sendername & ")"
                        Dim detail As String = "Please review and approve Expenditure"

                        Dim MainBody As String = MailDetail_SendExpenditure(cost_control_name, detail, MailToken)
                        Dim ret As Boolean = email.SendEmail(toemail, mailsubject, MainBody)
                        If ret = False Then
                            ret = email.SendEmail(toemail, mailsubject, MainBody)
                            If ret = False Then
                                SendNotComplete = 1
                            End If
                        End If
                    End If
                Else
                    SendNotComplete = 1
                End If
            Else
                SendNotComplete = 1
            End If
        Catch ex As Exception
            SendNotComplete = 1
        End Try

        Return IIf(SendNotComplete = 0, True, False)

    End Function

    Public Shared Function ExpenditureSendMailAccounting(ByVal ExpenditureID As String) As Boolean
        Dim SendNotComplete As Integer = 0
        Try
            Dim sql As String = "select ex.id, su.name + ' ' + su.surname sendername , ex.user_id, su.username, ex.expenditure_status"
            sql += " from eOFFICE_EXPENDITURE ex"
            sql += " inner join eOFFICE_USER su on su.id=ex.user_id"
            sql += " where ex.id='" & ExpenditureID & "'"
            func.checkConn(MyConn)
            Dim da As New SqlDataAdapter(sql, MyConn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim sendername As String = dt.Rows(0)("sendername").ToString()
                Dim AccountingName As String = ""
                Dim toemail As String = ""


                Dim aDt As New DataTable
                aDt = func.GetUserListByResponsibility(Constants.Responsibility.Accounting)
                If aDt.Rows.Count > 0 Then
                    Dim aDr As DataRow = aDt.Rows(0)
                    If Convert.IsDBNull(aDr("email")) = False Then toemail = aDr("email")
                    If Convert.IsDBNull(aDr("staff_name")) = False Then AccountingName = aDr("staff_name")
                    Dim MailToken As String = SaveMailToken(aDr("id"), aDr("user_id"), aDr("username"), aDr("expenditure_status"), "EP_ViewExpenditureDetail.aspx")
                    If MailToken <> "" Then
                        If toemail <> "" And sendername <> "" Then
                            Dim mailsubject As String = "Expenditure Wait for Cost Controller Approval (" & sendername & ")"
                            Dim detail As String = "Please review and approve Expenditure"

                            Dim MainBody As String = MailDetail_SendExpenditure(AccountingName, detail, MailToken)
                            Dim ret As Boolean = email.SendEmail(toemail, mailsubject, MainBody)
                            If ret = False Then
                                ret = email.SendEmail(toemail, mailsubject, MainBody)
                                If ret = False Then
                                    SendNotComplete = 1
                                End If
                            End If
                        End If
                    Else
                        SendNotComplete = 1
                    End If
                Else
                    SendNotComplete = 1
                End If
                aDt.Dispose()
            Else
                SendNotComplete = 1
            End If
        Catch ex As Exception
            SendNotComplete = 1
        End Try

        Return IIf(SendNotComplete = 0, True, False)

    End Function

    Public Shared Function ExpenditureSendMailReject(ByVal ExpenditureID As String, ByVal MailSubject As String) As Boolean
        Dim SendNotComplete As Integer = 0
        Try
            Dim sql As String = "select ex.id, u.email, u.name + ' ' + u.surname staff_name,ex.user_id,u.username,ex.expenditure_status "
            sql += " from eOFFICE_EXPENDITURE ex "
            sql += " Inner join eOFFICE_USER u on ex.user_id=u.id "
            sql &= " where  ex.id='" & ExpenditureID & "'"
            func.checkConn(MyConn)
            Dim da As New SqlDataAdapter(sql, MyConn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim toemail As String = dt.Rows(0)("email").ToString()
                Dim receivename As String = dt.Rows(0)("staff_name")
                Dim MailToken As String = SaveMailToken(dt.Rows(0)("id"), dt.Rows(0)("user_id"), dt.Rows(0)("username"), dt.Rows(0)("expenditure_status"), "EP_ViewExpenditureDetail.aspx")

                If MailToken <> "" Then
                    If toemail <> "" And receivename <> "" Then
                        Dim detail As String = "Please review and edit eTimesheet"

                        Dim MainBody As String = MailDetail_SendExpenditure(receivename, detail, MailToken)
                        Dim ret As Boolean = email.SendEmail(toemail, MailSubject, MainBody)
                        If ret = False Then
                            ret = email.SendEmail(toemail, MailSubject, detail)
                            If ret = False Then
                                SendNotComplete = 1
                            End If
                        End If
                    Else
                        SendNotComplete = 1
                    End If
                Else
                    SendNotComplete = 1
                End If
            Else
                SendNotComplete = 1
            End If
        Catch ex As Exception
            SendNotComplete = 1
        End Try

        Return IIf(SendNotComplete = 0, True, False)

    End Function
#End Region
#End Region



End Class
