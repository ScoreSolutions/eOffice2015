Option Strict Off
Option Explicit On
Imports system.data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Constants.ETimeSheet

Partial Class _ET_TimeSheetDetail
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim Conf As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/")
    Dim MyConn As New SqlConnection(Conf.ConnectionStrings.ConnectionStrings("MyConn").ToString)
    Dim func As New EtimesheetSystem
  

#Region "Sub&Function"
    Sub ShowProject()
        Dim sql As String = "select id,project_name from eOFFICE_PROJECT where active_status='Y'"
        func.BindControl(Me.ddlProject, 1, sql)
    End Sub

    Sub ShowBillingName()
        Dim Sql As String = "Select Id,Billing_Name from eOFFICE_PROJECT_BILLING where project_id ='" & ddlProject.SelectedValue & "'  order by Billing_Name "
        func.BindControl(Me.ddlBillingName, 1, Sql)
    End Sub

    Sub ShowBranch()
        Dim Sql As String = "select id,branch_code,branch_name from eOFFICE_ACCOUNT_BRANCH "
        Sql += " where account_id=(select distinct account_id from eOFFICE_PROJECT where id='" & ddlProject.SelectedValue & "') order by branch_name"
        func.BindControl(Me.ddlLocation, 1, Sql)
    End Sub

    Function GetProjectManager(ByVal projectid As String) As DataTable
        Dim sql As String = "select id,name + ' ' + surname as name from eOFFICE_USER where id =(select pm_user_id from eOFFICE_PROJECT where id='" & projectid & "')"
        func.checkConn(MyConn)
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim dt As New DataTable
        da.Fill(dt)
        Return dt
    End Function

    Function GetTimeSheetDocNo(ByVal objCmd As SqlCommand) As String
        Dim sql As String = "select convert(varchar(10),GETDATE(),112) + REPLACE(STR(isnull(max(substring(timesheet_docno,9,4)),0) + 1, 4), SPACE(1), '0') DocNo from eOFFICE_TIMESHEET"
        sql &= " where substring(timesheet_docno,1,6)= substring(convert(varchar(10),GETDATE(),112),1,6)"
        objCmd.CommandText = sql
        Dim da As New SqlDataAdapter(objCmd)
        Dim dt As New DataTable
        da.Fill(dt)
        Dim TimeSheetDocNo As String = ""
        If dt.Rows.Count > 0 Then
            TimeSheetDocNo = dt.Rows(0)("DocNo").ToString()
        End If
        Return TimeSheetDocNo
    End Function

    Sub SetTimeSheetList(ByVal wh As String)
        Dim sql As String = "select eOFFICE_TIMESHEET.id,eOFFICE_PROJECT.project_name as project_name, eOFFICE_PROJECT_BILLING.billing_name as billing_name"
        sql &= ",convert(varchar(10),start_time,103) as TSDate, convert(varchar(5),start_time,108) +' - ' +convert(varchar(5),end_time,108) as TSTime ,"
        sql &= "case project_phase when 1 then 'Sale' when 2 then 'Develop' when 3 then 'Deploy' when 4 then 'Support'  end as phase ,timesheet_detail,timesheet_status "
        sql &= " from eOFFICE_TIMESHEET "
        sql &= " inner join eOFFICE_PROJECT_BILLING on eOFFICE_TIMESHEET.project_billing_id = eOFFICE_PROJECT_BILLING.id "
        sql &= " inner join eOFFICE_PROJECT on eOFFICE_PROJECT_BILLING.project_id = eOFFICE_PROJECT.id"
        sql &= " inner join eOFFICE_USER U on eOFFICE_TIMESHEET.user_id=U.id where username = '" & Session("username") & "' " & wh
        func.checkConn(MyConn)
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim dt As New DataTable
        da.Fill(dt)
        rptTsDetailList.DataSource = dt
        rptTsDetailList.DataBind()
    End Sub

    Sub SetTimeSheetDetail(ByVal timesheet_id As String)
        Dim sql As String = "select eOFFICE_TIMESHEET.id,timesheet_docno,project_billing_id,eOFFICE_TIMESHEET.pm_user_id,account_branch_id,"
        sql &= " contact_person,contact_mobile,timesheet_subject,convert(varchar(5),start_time,108) as start_time,convert(varchar(5),end_time,108) as end_time,"
        sql &= " convert(varchar(10),start_time,103) as TSDate ,project_phase,timesheet_detail,"
        sql &= " timesheet_status,eOFFICE_PROJECT_BILLING.project_id from eOFFICE_TIMESHEET "
        sql &= " inner join eOFFICE_PROJECT_BILLING on eOFFICE_TIMESHEET.project_billing_id = eOFFICE_PROJECT_BILLING.id"
        sql &= " inner join eOFFICE_PROJECT on eOFFICE_PROJECT_BILLING.project_id = eOFFICE_PROJECT.id where eOFFICE_TIMESHEET.id='" & timesheet_id & "'"
        func.checkConn(MyConn)
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            Try
                ddlProject.SelectedValue = dt.Rows(0)("project_id").ToString
                ddlProject_SelectedIndexChanged(Nothing, Nothing)
            Catch ex As Exception
                ddlProject.SelectedIndex = 0
            End Try
            Try
                ddlBillingName.SelectedValue = dt.Rows(0)("project_billing_id").ToString
            Catch ex As Exception
                ddlBillingName.SelectedIndex = 0
            End Try
            Try
                ddlLocation.SelectedValue = dt.Rows(0)("account_branch_id").ToString
            Catch ex As Exception
                ddlLocation.SelectedIndex = 0
            End Try
            Try
                rdiPhase.SelectedValue = dt.Rows(0)("project_phase").ToString
            Catch ex As Exception
                rdiPhase.SelectedIndex = 0
            End Try
            Try
                txtDate.TxtBox.Text = dt.Rows(0)("TSDate").ToString
            Catch ex As Exception
                txtDate.TxtBox.Text = ""
            End Try
            Try
                txtStartTime.TxtBox.Text = dt.Rows(0)("start_time").ToString
            Catch ex As Exception
                txtStartTime.TxtBox.Text = ""
            End Try
            Try
                txtEndTime.TxtBox.Text = dt.Rows(0)("end_time").ToString
            Catch ex As Exception
                txtEndTime.TxtBox.Text = ""
            End Try

            txtContactPerson.Text = dt.Rows(0)("contact_person").ToString
            txtContactMobile.Text = dt.Rows(0)("contact_mobile").ToString

            Dim dtPM As New DataTable
            dtPM = GetProjectManager(dt.Rows(0)("project_id").ToString)
            If dtPM.Rows.Count > 0 Then
                lblProjectManager.Text = dtPM.Rows(0)("name").ToString
                lblPmUserID.Text = dtPM.Rows(0)("id").ToString
            End If

            lblID.Text = dt.Rows(0)("id").ToString
            txtSubject.Text = dt.Rows(0)("timesheet_subject").ToString
            txtDetail.Text = dt.Rows(0)("timesheet_detail").ToString
        End If
    End Sub

    Sub ClearForm()
        ddlProject.SelectedIndex = 0
        ddlBillingName.SelectedIndex = 0
        ddlLocation.SelectedIndex = 0
        txtContactPerson.Text = ""
        lblProjectManager.Text = ""
        lblID.Text = "0"
        lblPmUserID.Text = ""
        txtDate.TxtBox.Text = ""
        txtStartTime.TxtBox.Text = ""
        txtEndTime.TxtBox.Text = ""
        txtSubject.Text = ""
        txtContactMobile.Text = ""
        For i As Integer = 0 To rdiPhase.Items.Count - 1
            rdiPhase.Items(i).Selected = False
        Next

        txtDetail.Text = ""
        lblError.Visible = False
        lblError.Text = ""
    End Sub

    Function Validate() As Boolean
        If ddlProject.SelectedIndex = 0 Then
            lblError.Visible = True
            lblError.Text = "กรุณาระบุ Project"
            Return False
        End If

        If ddlBillingName.SelectedIndex = 0 Then
            lblError.Visible = True
            lblError.Text = "กรุณาระบุ Billing"
            Return False
        End If

        If ddlLocation.SelectedIndex = 0 Then
            lblError.Visible = True
            lblError.Text = "กรุณาระบุ Location"
            Return False
        End If

        If txtContactPerson.Text = "" Then
            lblError.Visible = True
            lblError.Text = "กรุณาระบุ Contact Person"
            Return False
        End If

        If txtContactMobile.Text = "" Then
            lblError.Visible = True
            lblError.Text = "กรุณาระบุ Contact Mobile"
            Return False
        End If

        If txtDate.TxtBox.Text = "" Then
            lblError.Visible = True
            lblError.Text = "กรุณาระบุ Working Date"
            Return False
        End If

        If txtStartTime.TxtBox.Text = "" Then
            lblError.Visible = True
            lblError.Text = "กรุณาระบุ Start Time"
            Return False
        End If

        If txtEndTime.TxtBox.Text = "" Then
            lblError.Visible = True
            lblError.Text = "กรุณาระบุ End Time"
            Return False
        End If

        If txtSubject.Text = "" Then
            lblError.Visible = True
            lblError.Text = "กรุณาระบุ Subject"
            Return False
        End If

       

        Dim isChecked As Boolean = False
        For i As Integer = 0 To rdiPhase.Items.Count - 1
            If rdiPhase.Items(i).Selected = True Then
                isChecked = True
                Exit For
            End If
        Next
        If isChecked = False Then
            lblError.Visible = True
            lblError.Text = "กรุณาระบุ Phase"
            Return False
        End If

        Return True
    End Function

    'Function SendMail(ByVal TimeSheetID As String) As Boolean
    '    Dim SMTPMailFrom As String = ConfigurationManager.AppSettings("SMTPMailFrom").ToString()
    '    Dim SMTPServer As String = ConfigurationManager.AppSettings("SMTPServer").ToString()
    '    Dim SMTPPassword As String = ConfigurationManager.AppSettings("SMTPPassword").ToString()
    '    Dim MailPort As String = ConfigurationManager.AppSettings("MailPort").ToString()
    '    Dim MailSSL As String = ConfigurationManager.AppSettings("MailSSL").ToString()

    '    Dim SendNotComplete As Integer = 0
    '    Try
    '        Dim sql As String = "select U2.email,U1.name + ' ' + U1.surname as sendername,U2.name + ' ' + U2.surname as ProjectManager_Name  "
    '        sql &= " from eOFFICE_TIMESHEET  TS"
    '        sql &= " inner join eOFFICE_USER U1 on TS.user_id =U1.id "
    '        sql &= " inner join eOFFICE_USER U2 on TS.pm_user_id =U2.id "
    '        sql &= " where TS.id='" & TimeSheetID & "'"
    '        func.checkConn(MyConn)
    '        Dim da As New SqlDataAdapter(sql, MyConn)
    '        Dim dt As New DataTable
    '        da.Fill(dt)
    '        If dt.Rows.Count > 0 Then
    '            Dim toemail As String = dt.Rows(0)("email").ToString()
    '            Dim sendername As String = dt.Rows(0)("sendername").ToString()
    '            Dim pm_name As String = dt.Rows(0)("ProjectManager_Name").ToString

    '            If toemail <> "" And sendername <> "" Then
    '                Dim mailsubject As String = "E Timesheet Wait for Approval(" & sendername & ")"
    '                Dim detail As String = "Please review and approve eTimesheet"
    '                Dim ret As Boolean = email.SendEmailETimeSheet(toemail, pm_name, mailsubject, detail, TimeSheetID, "N", "3")

    '                If ret = False Then
    '                    ret = email.SendEmailETimeSheet(toemail, pm_name, mailsubject, detail, TimeSheetID, "N", "3")
    '                    If ret = False Then
    '                        SendNotComplete = 1
    '                    End If
    '                End If
    '            End If
    '        Else
    '            SendNotComplete = 1
    '        End If
    '    Catch ex As Exception
    '        SendNotComplete = 1
    '    End Try

    '    Return IIf(SendNotComplete = 0, True, False)

    'End Function

#End Region



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ShowProject()
            SetTimeSheetList("")
            ddlProject_SelectedIndexChanged(sender, e)
            txtContactMobile.Attributes.Add("onKeypress", "return validateNumericOnly(this,event);")

            If Not Request.QueryString("id") Is Nothing AndAlso Request.QueryString("id").ToString <> "" Then
                SetTimeSheetDetail(Request.QueryString("id"))
            End If
        End If
    End Sub

    Protected Sub ddlProject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProject.SelectedIndexChanged
        ShowBillingName()
        ShowBranch()
        Dim dt As New DataTable
        dt = GetProjectManager(ddlProject.SelectedValue)
        If dt.Rows.Count > 0 Then
            lblProjectManager.Text = dt.Rows(0)("name").ToString
            lblPmUserID.Text = dt.Rows(0)("id").ToString
        End If

    End Sub

    Protected Sub butSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butSave.Click
        If Validate() = False Then
            Exit Sub
        End If

        func.checkConn(MyConn)
        Dim objTrans As SqlTransaction
        objTrans = MyConn.BeginTransaction

        Try
            Dim username As String = Session("username")
            Dim timesheet_docno As String = ""
            Dim project_billing_id As String = ddlBillingName.SelectedValue
            Dim pm_user_id As String = lblPmUserID.Text
            Dim account_branch_id As String = ddlLocation.SelectedValue
            Dim contact_person As String = txtContactPerson.Text.Trim
            Dim contact_mobile As String = txtContactMobile.Text.Trim
            Dim timesheet_subject As String = txtSubject.Text.Trim
            Dim workingDate As String = txtDate.DateValue.Year & "-" & txtDate.DateValue.Month & "-" & txtDate.DateValue.Day
            Dim start_time As String = workingDate & " " & txtStartTime.TxtBox.Text & ":00"
            Dim end_time As String = workingDate & " " & txtEndTime.TxtBox.Text & ":00"
            Dim project_phase As String = rdiPhase.SelectedValue
            Dim timesheet_detail As String = txtDetail.Text.Trim
            Dim timesheet_status As String = "0"
            Dim userid As String = Session("user_id")

            Dim sql As String = ""
            Dim cmd As New SqlCommand
            cmd.Connection = MyConn
            cmd.Transaction = objTrans
            Dim timesheet_id As String
            If lblID.Text = "0" Then
                timesheet_docno = GetTimeSheetDocNo(cmd)
                sql = " Insert into eOFFICE_TIMESHEET(id,created_by,created_date,timesheet_docno,project_billing_id,pm_user_id,account_branch_id,"
                sql &= " contact_person,contact_mobile,timesheet_subject,start_time,end_time,project_phase,timesheet_detail,"
                sql &= " timesheet_status,user_id) OUTPUT INSERTED.ID"
                sql &= " values((select isnull(max(id),0) + 1 from eOFFICE_TIMESHEET),'" & username & "',GETDATE(),'" & timesheet_docno & "','" & project_billing_id & "'"
                sql &= ",'" & pm_user_id & "','" & account_branch_id & "','" & contact_person & "','" & contact_mobile & "'"
                sql &= ",'" & timesheet_subject & "','" & start_time & "','" & end_time & "','" & project_phase & "','" & timesheet_detail & "','" & timesheet_status & "','" & userid & "')"
                cmd.CommandText = sql
                timesheet_id = cmd.ExecuteScalar()
            Else
                sql = " Update eOFFICE_TIMESHEET Set updated_by='" & username & "',updated_date = GETDATE()"
                sql &= " ,project_billing_id ='" & project_billing_id & "',pm_user_id ='" & pm_user_id & "',account_branch_id ='" & account_branch_id & "'"
                sql &= " ,contact_person ='" & contact_person & "',contact_mobile ='" & contact_mobile & "',timesheet_subject ='" & timesheet_subject & "'"
                sql &= " ,start_time ='" & start_time & "',end_time ='" & end_time & "',project_phase ='" & project_phase & "',timesheet_detail ='" & timesheet_detail & "'"
                sql &= "  where id= '" & lblID.Text & "'"
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                timesheet_id = lblID.Text
            End If

            sql = "insert into eOFFICE_TIMESHEET_STATUS_LOG (created_date,created_by,eoffice_timesheet_id,timesheet_status,status_comment) "
            sql &= " values(GETDATE(),'" & username & "','" & timesheet_id & "','" & timesheet_status & "','')"
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            objTrans.Commit()
            ClearForm()


            SetTimeSheetList("")
            lblError.Visible = True
            lblError.CssClass = "successBox"
            lblError.Text = "Time Sheet has been add successfully."
        Catch ex As Exception
            objTrans.Rollback()
            lblError.Visible = True
            lblError.Text = ex.ToString()
        End Try

    End Sub

    Sub rptTsDetailList_ItemCommand(ByVal o As Object, ByVal e As RepeaterCommandEventArgs) Handles rptTsDetailList.ItemCommand
        Dim id As String = CType(e.CommandSource, Button).CommandArgument
        Dim CommandName As String = CType(e.CommandSource, Button).CommandName
        If CommandName.ToUpper = "SelectTS".ToUpper Then
            ClearForm()
            SetTimeSheetDetail(id)
        End If


        If CommandName.ToUpper = "SendTS".ToUpper Then
       
            func.checkConn(MyConn)
            Dim objTrans As SqlTransaction
            objTrans = MyConn.BeginTransaction
            Dim sql As String = ""
            Dim cmd As New SqlCommand
            cmd.Connection = MyConn
            cmd.Transaction = objTrans
            Try
                sql = " Update eOFFICE_TIMESHEET set timesheet_status = '" & TimeSheetStatus.WaitForApproval & "' where id ='" & id & "' and timesheet_status='" & TimeSheetStatus.Entered & "'"
                cmd.CommandText = sql
                If cmd.ExecuteNonQuery() > 0 Then
                    sql = "insert into eOFFICE_TIMESHEET_STATUS_LOG (created_date,created_by,eoffice_timesheet_id,timesheet_status,status_comment) "
                    sql &= " values(GETDATE(),'" & Session("username") & "','" & id & "','" & TimeSheetStatus.WaitForApproval & "','')"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                End If
                objTrans.Commit()
                SetTimeSheetList("")

                lblError.Text = ""

                lblError.Visible = True
                lblError.CssClass = "successBox"
                lblError.Text = "Send Complete"

                email.ETimeSheetSendMailApprove(id)
            Catch ex As Exception
                objTrans.Rollback()
                lblError.Text = ex.ToString()
                Exit Sub
            End Try
        End If

        If CommandName.ToUpper = "DeleteTS".ToUpper Then
            func.checkConn(MyConn)
            Dim Sql As String = "delete from eOFFICE_TIMESHEET where id = '" & id & "' "
            Dim cmd As New SqlCommand(Sql, MyConn)
            cmd.ExecuteNonQuery()
            ClearForm()
            lblError.CssClass = "successBox"
            lblError.Text = "Time Sheet has been delete successfully."
            lblError.Visible = True

            ClearForm()
            SetTimeSheetList("")
        End If

        If CommandName.ToUpper = "ViewTS".ToUpper Then
            Response.Redirect("ET_ViewTimeSheetDetail.aspx?id=" & id & "&type=1")
        End If
    End Sub

    Protected Sub rptTsDetailList_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptTsDetailList.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item) Or _
           (e.Item.ItemType = ListItemType.AlternatingItem) Then
            Dim timesheet_status As String = CType(e.Item.FindControl("lbltimesheet_status"), Label).Text

            Dim btnSelect As Button = CType(e.Item.FindControl("btnSelect"), Button)
            Dim btnSend As Button = CType(e.Item.FindControl("btnSend"), Button)
            Dim btnDelete As Button = CType(e.Item.FindControl("btnDelete"), Button)
            Dim btnView As Button = CType(e.Item.FindControl("btnView"), Button)

            btnSelect.Visible = False
            btnSend.Visible = False
            btnDelete.Visible = False
            btnView.Visible = False

            If timesheet_status = 0 Then
                btnDelete.Visible = True
            End If

            If timesheet_status = 0 Or timesheet_status = 3 Or timesheet_status = 5 Then
                btnSelect.Visible = True
                btnSend.Visible = True
            End If

            If timesheet_status = 1 Or timesheet_status = 2 Or timesheet_status = 4 Then
                btnView.Visible = True
            End If

        End If
    End Sub


    Protected Sub butCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butCancel.Click
        ClearForm()
    End Sub

End Class
