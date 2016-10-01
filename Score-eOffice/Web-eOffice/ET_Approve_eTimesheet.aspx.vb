Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Partial Class ET_Approve_eTimesheet
    Inherits System.Web.UI.Page

    Dim MyConn As New SqlConnection(WebConfigurationManager.ConnectionStrings("MyConn").ToString)
    Dim func As New EtimesheetSystem

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ShowProject()
            ddlProject_SelectedIndexChanged(sender, e)
            ShowStaff()

            SetTimeSheetListWaitingForApprv("")
            SetTimeSheetListApprvByPM("")
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

    Sub ShowStaff()
        Dim Sql As String = "select name + ' ' + surname as name,id from eOFFICE_USER order by name,surname"
        func.BindControl(ddlStaff, 1, Sql)
    End Sub

    Protected Sub ddlProject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProject.SelectedIndexChanged
        ShowBillingName(ddlProject, ddlBillingName)
    End Sub

    Sub SetTimeSheetListWaitingForApprv(ByVal wh As String)
        Dim sql As String = "select eOFFICE_TIMESHEET.id,eOFFICE_PROJECT.project_name as project_name, eOFFICE_PROJECT_BILLING.billing_name as billing_name"
        sql &= ",convert(varchar(10),start_time,103) as TSDate, convert(varchar(5),start_time,108) +' - ' +convert(varchar(5),end_time,108) as TSTime ,"
        sql &= "case project_phase when 1 then 'Sale' when 2 then 'Develop' when 3 then 'Deploy' when 4 then 'Support'  end as phase ,timesheet_detail,"
        sql &= " case timesheet_status when 0 then 'Entered' when 1 then 'Wait for Approval'"
        sql &= " when 2 then 'Approve by PM' when 3 then 'Reject by PM' when 4 then 'Finished'"
        sql &= " when 5 then 'Reject by Cost Controller' end as status,timesheet_status,U2.name + ' ' + U2.surname as staff "
        sql &= " from eOFFICE_TIMESHEET "
        sql &= " inner join eOFFICE_PROJECT_BILLING on eOFFICE_TIMESHEET.project_billing_id = eOFFICE_PROJECT_BILLING.id "
        sql &= " inner join eOFFICE_PROJECT on eOFFICE_PROJECT_BILLING.project_id = eOFFICE_PROJECT.id "
        sql &= " inner join eOFFICE_USER U1 on eOFFICE_TIMESHEET.pm_user_id=U1.id"
        sql &= " inner join eOFFICE_USER U2 on eOFFICE_TIMESHEET.user_id=U2.id"
        sql &= " where timesheet_status =1 and U1.username='" & Session("username") & "' " & wh
        func.checkConn(MyConn)
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            rptTsDetailListWaitingForApprv.DataSource = dt
            rptTsDetailListWaitingForApprv.DataBind()
        Else
            'lblError.Visible = True
            'lblError.Text = "data not found!(Wait for Approval)"

            rptTsDetailListWaitingForApprv.DataSource = Nothing
            rptTsDetailListWaitingForApprv.DataBind()
        End If

    End Sub

    Sub rptTsDetailListWaitingForApprv_ItemCommand(ByVal o As Object, ByVal e As RepeaterCommandEventArgs) Handles rptTsDetailListWaitingForApprv.ItemCommand
        Dim id As String = CType(e.CommandSource, Button).CommandArgument
        Dim CommandName As String = CType(e.CommandSource, Button).CommandName
        If CommandName.ToUpper = "ViewTS".ToUpper Then
            Response.Redirect("ET_ViewTimeSheetDetail.aspx?id=" & id & "&type=3")
        End If
    End Sub

    Sub SetTimeSheetListApprvByPM(ByVal wh As String)
        Dim sql As String = "select eOFFICE_TIMESHEET.id,eOFFICE_PROJECT.project_name as project_name, eOFFICE_PROJECT_BILLING.billing_name as billing_name"
        sql &= ",convert(varchar(10),start_time,103) as TSDate, convert(varchar(5),start_time,108) +' - ' +convert(varchar(5),end_time,108) as TSTime ,"
        sql &= "case project_phase when 1 then 'Sale' when 2 then 'Develop' when 3 then 'Deploy' when 4 then 'Support'  end as phase ,timesheet_detail,"
        sql &= " case timesheet_status when 0 then 'Entered' when 1 then 'Wait for Approval'"
        sql &= " when 2 then 'Approve by PM' when 3 then 'Reject by PM' when 4 then 'Finished'"
        sql &= " when 5 then 'Reject by Cost Controller' end as status,timesheet_status,U2.name + ' ' + U2.surname as staff "
        sql &= " from eOFFICE_TIMESHEET "
        sql &= " inner join eOFFICE_PROJECT_BILLING on eOFFICE_TIMESHEET.project_billing_id = eOFFICE_PROJECT_BILLING.id "
        sql &= " inner join eOFFICE_PROJECT on eOFFICE_PROJECT_BILLING.project_id = eOFFICE_PROJECT.id "
        sql &= " inner join eOFFICE_USER U1 on eOFFICE_PROJECT.cost_control_user_id=U1.id"
        sql &= " inner join eOFFICE_USER U2 on eOFFICE_TIMESHEET.user_id=U2.id"
        sql &= " where timesheet_status =2 and U1.username='" & Session("username") & "' " & wh
        func.checkConn(MyConn)
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            rptTsDetailListApprvByPM.DataSource = dt
            rptTsDetailListApprvByPM.DataBind()
        Else
            'lblError.Visible = True
            'lblError.Text = "data not found!(Approve by PM )"

            rptTsDetailListApprvByPM.DataSource = Nothing
            rptTsDetailListApprvByPM.DataBind()
        End If

    End Sub

    Sub rptTsDetailListApprvByPM_ItemCommand(ByVal o As Object, ByVal e As RepeaterCommandEventArgs) Handles rptTsDetailListApprvByPM.ItemCommand
        Dim id As String = CType(e.CommandSource, Button).CommandArgument
        Dim CommandName As String = CType(e.CommandSource, Button).CommandName
        If CommandName.ToUpper = "ViewTS".ToUpper Then
            Response.Redirect("ET_ViewTimeSheetDetail.aspx?id=" & id & "&type=3")
        End If
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

            If ddlStaff.SelectedIndex > 0 Then
                filter &= "and user_id ='" & ddlStaff.SelectedValue & "'"
            End If

            SetTimeSheetListWaitingForApprv(filter)
            SetTimeSheetListApprvByPM(filter)
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.ToString()
        End Try
    End Sub
End Class
