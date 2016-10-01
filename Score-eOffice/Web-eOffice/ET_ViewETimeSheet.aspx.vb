Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports Constants.ETimeSheet

Partial Class ET_ViewETimeSheet
    Inherits System.Web.UI.Page

    Dim MyConn As New SqlConnection(WebConfigurationManager.ConnectionStrings("MyConn").ToString)
    Dim func As New EtimesheetSystem

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ShowProject()
            ddlProject_SelectedIndexChanged(sender, e)
            SetTimeSheetList("")
        End If
    End Sub

    Sub ShowProject()
        Dim Sql As String = "Select id,project_name from eOFFICE_PROJECT order by project_name "
        func.BindControl(Me.ddlProject, 1, Sql)
    End Sub

    Sub ShowBillingName(ByVal ddlP As DropDownList, ByVal ddlB As DropDownList)
        Dim Sql As String = "Select Id,Billing_Name from eOFFICE_PROJECT_BILLING where project_id ='" & ddlP.SelectedValue & "'  order by Billing_Name "
        func.BindControl(ddlB, 1, Sql)
    End Sub

    Protected Sub ddlProject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProject.SelectedIndexChanged
        ShowBillingName(ddlProject, ddlBillingName)
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lblError.Visible = False
        lblError.Text = ""
        Try
            Dim filter As String = ""
            If ddlProject.SelectedIndex > 0 Then
                filter &= " and project_id='" & ddlProject.SelectedValue & "'"
            End If

            If ddlBillingName.SelectedIndex > 0 Then
                filter &= " and project_billing_id ='" & ddlBillingName.SelectedValue & "'"
            End If

            If txtDateFrom.TxtBox.Text <> "" AndAlso txtDateTo.TxtBox.Text <> "" Then
                filter &= " and (convert(varchar(10),start_time,103) between '" & txtDateFrom.TxtBox.Text & "' and '" & txtDateTo.TxtBox.Text & "')"
            End If

            If rdiPhase.SelectedValue <> "" Then
                filter &= " and project_phase ='" & rdiPhase.SelectedValue & "'"
            End If

            Dim status As String = ""
            For i As Integer = 0 To chkStatus.Items.Count - 1
                If chkStatus.Items(i).Selected = True Then
                    status &= chkStatus.Items(i).Value & ","
                End If
            Next
            If status <> "" Then
                status = status.Substring(0, status.Length - 1)
                filter &= " and timesheet_status in(" & status & ")"
            End If

            SetTimeSheetList(filter)
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.ToString()
        End Try

    End Sub

    Sub SetTimeSheetList(ByVal wh As String)
        Dim sql As String = "select eOFFICE_TIMESHEET.id,eOFFICE_PROJECT.project_name as project_name, eOFFICE_PROJECT_BILLING.billing_name as billing_name"
        sql &= ",convert(varchar(10),start_time,103) as TSDate, convert(varchar(5),start_time,108) +' - ' +convert(varchar(5),end_time,108) as TSTime ,"
        sql &= "case project_phase when 1 then 'Sale' when 2 then 'Develop' when 3 then 'Deploy' when 4 then 'Support'  end as phase ,timesheet_detail,"
        sql += " case timesheet_status "
        sql += "    when '" & TimeSheetStatus.Entered & "' then 'Entered'"
        sql += "    when '" & TimeSheetStatus.WaitForApproval & "' then 'Wait for Approval'"
        sql += "    when '" & TimeSheetStatus.ApproveByPM & "' then 'Approve by PM' "
        sql += "    when '" & TimeSheetStatus.RejectByPM & "' then 'Reject by PM' "
        sql += "    when '" & TimeSheetStatus.Finished & "' then 'Finished' "
        sql += "    when '" & TimeSheetStatus.RejectByCostcontroller & "' then 'Reject by Cost Controller'"
        sql += " end status,"
        sql += " timesheet_status"
        sql &= " from eOFFICE_TIMESHEET "
        sql &= " inner join eOFFICE_PROJECT_BILLING on eOFFICE_TIMESHEET.project_billing_id = eOFFICE_PROJECT_BILLING.id "
        sql &= " inner join eOFFICE_PROJECT on eOFFICE_PROJECT_BILLING.project_id = eOFFICE_PROJECT.id "
        sql &= " inner join eOFFICE_USER U on eOFFICE_TIMESHEET.user_id=U.id where username = '" & Session("username") & "' " & wh
        func.checkConn(MyConn)
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then

            rptTsDetailList.DataSource = dt
            rptTsDetailList.DataBind()
        Else
         
            lblError.Visible = True
            lblError.Text = "data not found!"

            rptTsDetailList.DataSource = Nothing
            rptTsDetailList.DataBind()
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

    Sub rptTsDetailList_ItemCommand(ByVal o As Object, ByVal e As RepeaterCommandEventArgs) Handles rptTsDetailList.ItemCommand
        Dim id As String = CType(e.CommandSource, Button).CommandArgument
        Dim CommandName As String = CType(e.CommandSource, Button).CommandName
        If CommandName.ToUpper = "SelectTS".ToUpper Then
            Response.Redirect("ET_TimeSheetDetail.aspx?id=" & id & "")
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
                sql = " Update eOFFICE_TIMESHEET set timesheet_status = 1 where id ='" & id & "'"
                cmd.CommandText = sql
                If cmd.ExecuteNonQuery() > 0 Then
                    sql = "insert into eOFFICE_TIMESHEET_STATUS_LOG (created_date,created_by,eoffice_timesheet_id,timesheet_status,status_comment) "
                    sql &= " values(GETDATE(),'" & Session("username") & "','" & id & "',1,'')"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                End If
                objTrans.Commit()
                SetTimeSheetList("")
            Catch ex As Exception
                objTrans.Rollback()
                lblError.Text = ex.ToString()
                lblError.Visible = True
                Exit Sub
            End Try

            If email.ETimeSheetSendMailApprove(id) Then
                lblError.Text = ""
                lblError.CssClass = "successBox"
                lblError.Text = "Send Complete"
                lblError.Visible = True
            End If

        End If

        If CommandName.ToUpper = "DeleteTS".ToUpper Then
            func.checkConn(MyConn)
            Dim Sql As String = "delete from eOFFICE_TIMESHEET where id = '" & id & "' "
            Dim cmd As New SqlCommand(Sql, MyConn)
            cmd.ExecuteNonQuery()
            lblError.CssClass = "successBox"
            lblError.Text = "Time Sheet has been delete successfully."
            lblError.Visible = True

            btnSearch_Click(o, e)
        End If

        If CommandName.ToUpper = "ViewTS".ToUpper Then
            Response.Redirect("ET_ViewTimeSheetDetail.aspx?id=" & id & "&type=2")
        End If
    End Sub

    
End Class
