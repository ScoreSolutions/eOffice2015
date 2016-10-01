Imports System.Data
Imports System.Data.SqlClient
Imports Constants.ETimeSheet

Partial Class ET_ViewTimeSheetDetail
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim Conf As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/")
    Dim MyConn As New SqlConnection(Conf.ConnectionStrings.ConnectionStrings("MyConn").ToString)
    Dim func As New EtimesheetSystem

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim TimeSheetID As String = ""
            If Request("token") IsNot Nothing Then
                If Session("token_data") = Request("token") Then
                    Dim sql As String = "select t.eoffice_user_id,t.token_data, t.return_page, t.ref_id,t.current_status "
                    sql += " from eOFFICE_EMAIL_TOKEN t "
                    sql += " inner join eOFFICE_TIMESHEET e on e.id=t.ref_id"
                    sql += " where t.token_data='" & Request("token") & "'"
                    sql += " and e.timesheet_status=t.current_status"
                    sql += " and t.return_page='ET_ViewTimeSheetDetail.aspx'"

                    Dim dt As New DataTable
                    dt = func.GetDatatable(sql)
                    If dt.Rows.Count > 0 Then
                        TimeSheetID = dt.Rows(0)("ref_id")
                    Else
                        Response.Redirect("login.aspx")
                    End If
                    dt.Dispose()
                Else
                    Response.Redirect("login.aspx")
                End If
            Else
                TimeSheetID = Request.QueryString("id")
            End If

            If TimeSheetID <> "" Then
                SetTimeSheetDetail(TimeSheetID)
            End If
        End If
    End Sub

    Sub SetTimeSheetDetail(ByVal TimeSheetID As String)
        Dim TSDt As New DataTable
        TSDt = GetTimeSheetDetail(TimeSheetID)
        If TSDt.Rows.Count > 0 Then
            Dim dr As DataRow = TSDt.Rows(0)
            lblID.Text = TimeSheetID
            lblName.Text = TSDt.Rows(0)("name").ToString
            lblDepartment.Text = TSDt.Rows(0)("department_desc").ToString
            lblPosition.Text = TSDt.Rows(0)("position_desc").ToString
            lblProjectName.Text = TSDt.Rows(0)("project_name").ToString
            lblBillingName.Text = TSDt.Rows(0)("billing_name").ToString
            lblProjectManager.Text = TSDt.Rows(0)("pmname").ToString
            lblAccount.Text = TSDt.Rows(0)("account_code").ToString
            lblContactPerson.Text = TSDt.Rows(0)("contact_person").ToString
            lblContactMobile.Text = TSDt.Rows(0)("contact_mobile").ToString
            lblLocation.Text = TSDt.Rows(0)("branch_name").ToString
            lblWorkingDate.Text = TSDt.Rows(0)("WorkingDate").ToString
            lblETimeSheetStatus.Text = TSDt.Rows(0)("timesheet_status").ToString
            lblETimeSheetStatusName.Text = TSDt.Rows(0)("timesheet_status_name")

            rptDetail1.DataSource = TSDt
            rptDetail1.DataBind()

            pnlComment.Visible = False
            If lblETimeSheetStatus.Text = TimeSheetStatus.WaitForApproval Then
                If dr("pm_user_id") = Session("user_id") Then
                    pnlComment.Visible = True
                End If
            ElseIf lblETimeSheetStatus.Text = TimeSheetStatus.ApproveByPM Then
                If dr("cost_control_user_id") = Session("user_id") Then
                    pnlComment.Visible = True
                End If
            End If
        End If

        Dim TSLogDt As New DataTable
        TSLogDt = GetTimeSheetLog(TimeSheetID)
        rptDetail2.DataSource = TSLogDt
        rptDetail2.DataBind()
    End Sub

    Function GetTimeSheetDetail(ByVal TimeSheetID As String) As DataTable
        Dim sql As String = "select U.name + ' ' + U.surname as name,D.department_desc,P.position_desc,"
        sql &= " PB.billing_name, ts.pm_user_id, U2.name + ' ' + U2.surname as pmname,AC.account_code,contact_person,"
        sql &= " contact_mobile,AB.branch_name,convert(varchar(10),start_time,103) as WorkingDate,"
        sql &= " convert(varchar(5),start_time,108) as start_time,convert(varchar(5),end_time,108) as end_time,"
        sql &= " case TS.project_phase when 1 then 'Sale' when 2 then 'Develop' when 3 then 'Deploy' when 4 then 'Support' end Phase,"
        sql &= " TS.timesheet_detail,PJ.project_name,ts.timesheet_status, pj.cost_control_user_id, "
        sql += " case ts.timesheet_status "
        sql += "    when '" & TimeSheetStatus.Entered & "' then 'Entered'"
        sql += "    when '" & TimeSheetStatus.WaitForApproval & "' then 'Wait for Approval'"
        sql += "    when '" & TimeSheetStatus.ApproveByPM & "' then 'Approve by PM' "
        sql += "    when '" & TimeSheetStatus.RejectByPM & "' then 'Reject by PM' "
        sql += "    when '" & TimeSheetStatus.Finished & "' then 'Finished' "
        sql += "    when '" & TimeSheetStatus.RejectByCostcontroller & "' then 'Reject by Cost Controller'"
        sql += " end timesheet_status_name"
        sql &= " from eOFFICE_TIMESHEET TS"
        sql &= " left Join eOFFICE_USER U on TS.user_id = U.id"
        sql &= " left Join eOFFICE_DEPARTMENT D on U.department_id = D.id"
        sql &= " left Join eOFFICE_POSITION P on U.position_id =P.id"
        sql &= " left Join eOFFICE_PROJECT_BILLING PB on TS.project_billing_id=PB.id"
        sql &= " left Join eOFFICE_PROJECT PJ on PB.project_id=PJ.id"
        sql &= " left Join eOFFICE_USER U2 on TS.pm_user_id=U2.id"
        sql &= " left Join eOFFICE_ACCOUNT_BRANCH AB on TS.account_branch_id =AB.id"
        sql &= " left Join eOFFICE_ACCOUNT AC on pj.account_id=AC.id"
        sql &= " where TS.ID ='" & TimeSheetID & "'"
        func.checkConn(MyConn)
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim dt As New DataTable
        da.Fill(dt)
        Return dt
    End Function

    Function GetTimeSheetLog(ByVal TimeSheetID As String) As DataTable
        Dim sql As String = "select CONVERT(varchar(10),TSLog.created_date,103) + ' ' + CONVERT(varchar,TSLog.created_date,108) as LogDate, name + ' ' + surname as name,"
        sql &= " case Timesheet_Status when 0 then 'Entered' when 1 then 'Wait for Approval' when 2 then 'Approve by PM' "
        sql &= " when 3 then 'Reject by PM' when 4 then 'Finished' when 5 then 'Reject by Cost Controller' end status,status_comment"
        sql &= " from eOFFICE_TIMESHEET_STATUS_LOG TSLog Left Join eOFFICE_USER U on TSLog.created_by=U.username"
        sql &= " where eoffice_timesheet_id ='" & TimeSheetID & "'"
        func.checkConn(MyConn)
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim dt As New DataTable
        da.Fill(dt)
        Return dt
    End Function

    Protected Sub butApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butApprove.Click
        Dim TimeSheetID As String = lblID.Text
        func.checkConn(MyConn)
        Dim objTrans As SqlTransaction
        objTrans = MyConn.BeginTransaction
        Dim sql As String = ""
        Dim cmd As New SqlCommand
        cmd.Connection = MyConn
        cmd.Transaction = objTrans
        Select Case lblETimeSheetStatus.Text
            Case TimeSheetStatus.WaitForApproval
                Try
                    sql = " Update eOFFICE_TIMESHEET set timesheet_status = '" & TimeSheetStatus.ApproveByPM & "' where id ='" & TimeSheetID & "' and timesheet_status = '" & TimeSheetStatus.WaitForApproval & "'"
                    cmd.CommandText = sql
                    If cmd.ExecuteNonQuery() > 0 Then
                        sql = "insert into eOFFICE_TIMESHEET_STATUS_LOG (created_date,created_by,eoffice_timesheet_id,timesheet_status,status_comment) "
                        sql &= " values(GETDATE(),'" & Session("username") & "','" & TimeSheetID & "','" & TimeSheetStatus.ApproveByPM & "','" & txtApproveText.Text & "')"
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()

                        objTrans.Commit()

                        SetTimeSheetDetail(TimeSheetID)

                        lblError.CssClass = "successBox"
                        lblError.Text = "Complete"
                        lblError.Visible = True
                        pnlComment.Visible = False

                        email.ETimeSheetSendMailCostController(TimeSheetID)
                    Else
                        objTrans.Rollback()
                    End If
                Catch ex As Exception
                    objTrans.Rollback()
                    lblError.Text = ex.ToString()
                    lblError.Visible = True
                    Exit Sub
                End Try
            Case TimeSheetStatus.ApproveByPM
                Try
                    sql = " Update eOFFICE_TIMESHEET set timesheet_status = '" & TimeSheetStatus.Finished & "' where id ='" & TimeSheetID & "' and timesheet_status = '" & TimeSheetStatus.ApproveByPM & "'"
                    cmd.CommandText = sql
                    If cmd.ExecuteNonQuery() > 0 Then
                        sql = "insert into eOFFICE_TIMESHEET_STATUS_LOG (created_date,created_by,eoffice_timesheet_id,timesheet_status,status_comment) "
                        sql &= " values(GETDATE(),'" & Session("username") & "','" & TimeSheetID & "','" & TimeSheetStatus.Finished & "','" & txtApproveText.Text & "')"
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()
                    End If
                    objTrans.Commit()

                    SetTimeSheetDetail(TimeSheetID)

                    lblError.CssClass = "successBox"
                    lblError.Text = "Complete"
                    lblError.Visible = True
                    pnlComment.Visible = False
                Catch ex As Exception
                    objTrans.Rollback()
                    lblError.Text = ex.ToString()
                    lblError.Visible = True
                    Exit Sub
                End Try
        End Select
    End Sub

    Protected Sub btnReject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReject.Click
        Dim TimeSheetID As String = Request.QueryString("id")
        func.checkConn(MyConn)
        Dim objTrans As SqlTransaction
        objTrans = MyConn.BeginTransaction
        Dim sql As String = ""
        Dim cmd As New SqlCommand
        cmd.Connection = MyConn
        cmd.Transaction = objTrans
        Select Case lblETimeSheetStatus.Text
            Case TimeSheetStatus.WaitForApproval
                Try
                    sql = " Update eOFFICE_TIMESHEET set timesheet_status = '" & TimeSheetStatus.RejectByPM & "' where id ='" & TimeSheetID & "' and timesheet_status='" & TimeSheetStatus.WaitForApproval & "'"
                    cmd.CommandText = sql
                    If cmd.ExecuteNonQuery() > 0 Then
                        sql = "insert into eOFFICE_TIMESHEET_STATUS_LOG (created_date,created_by,eoffice_timesheet_id,timesheet_status,status_comment) "
                        sql &= " values(GETDATE(),'" & Session("username") & "','" & TimeSheetID & "','" & TimeSheetStatus.RejectByPM & "','" & txtRejectText.Text & "')"
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()
                    End If
                    objTrans.Commit()

                    lblError.CssClass = "successBox"
                    lblError.Text = "Complete"
                    lblError.Visible = True
                    pnlComment.Visible = False

                    Dim mailsubject As String = "E Timesheet Reject by Project Manager"
                    Dim detail As String = "Please review and edit eTimesheet"
                    email.ETimeSheetSendMailReject(TimeSheetID, mailsubject, detail)

                Catch ex As Exception
                    objTrans.Rollback()
                    lblError.Text = ex.ToString()
                    lblError.Visible = True
                    Exit Sub
                End Try
            Case TimeSheetStatus.ApproveByPM
                Try
                    sql = " Update eOFFICE_TIMESHEET set timesheet_status = '" & TimeSheetStatus.RejectByCostcontroller & "' where id ='" & TimeSheetID & "' and timesheet_status='" & TimeSheetStatus.ApproveByPM & "'"
                    cmd.CommandText = sql
                    If cmd.ExecuteNonQuery() > 0 Then
                        sql = "insert into eOFFICE_TIMESHEET_STATUS_LOG (created_date,created_by,eoffice_timesheet_id,timesheet_status,status_comment) "
                        sql &= " values(GETDATE(),'" & Session("username") & "','" & TimeSheetID & "','" & TimeSheetStatus.RejectByCostcontroller & "','" & txtRejectText.Text & "')"
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()
                    End If
                    objTrans.Commit()

                    lblError.CssClass = "successBox"
                    lblError.Text = " Complete"
                    lblError.Visible = True
                    pnlComment.Visible = False

                    Dim mailsubject As String = "E Timesheet Reject by Cost Controller "
                    Dim detail As String = "Please review and edit eTimesheet"
                    email.ETimeSheetSendMailReject(TimeSheetID, mailsubject, detail)
                Catch ex As Exception
                    objTrans.Rollback()
                    lblError.Text = ex.ToString()
                    lblError.Visible = True
                    Exit Sub
                End Try
        End Select
    End Sub
End Class
