Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports Constants
Imports Constants.Expenditure


Partial Class EP_ApproveExpenditure
    Inherits System.Web.UI.Page

    Dim MyConn As New SqlConnection(WebConfigurationManager.ConnectionStrings("MyConn").ToString)
    Dim func As New EtimesheetSystem

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ShowProject()
            ddlProject_SelectedIndexChanged(sender, e)

            ShowStaffName()
            SetExpenditureList("")
        End If
    End Sub

    Sub ShowProject()
        Dim Sql As String = "Select id,project_code from eOFFICE_PROJECT where active_status='Y' order by project_code "
        func.BindControl(Me.ddlProject, 1, Sql)
    End Sub

    Sub ShowBillingName(ByVal ddlP As DropDownList, ByVal ddlB As DropDownList)
        Dim Sql As String = "Select Id,Billing_Name from eOFFICE_PROJECT_BILLING where project_id ='" & ddlP.SelectedValue & "'  order by Billing_Name "
        func.BindControl(ddlB, 1, Sql)
    End Sub

    Sub ShowStaffName()
        Dim sql As String = "select id, name + ' ' + surname staff_name from eOFFICE_USER "
        sql += " where convert(varchar(8),getdate(),112) between convert(varchar(8),start_date,112) and convert(varchar(8),isnull(end_date,getdate()),112) "
        sql += " order by name,surname"
        func.BindControl(ddlStaffName, 1, sql)
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
                filter &= " and pb.project_id='" & ddlProject.SelectedValue & "'" & vbNewLine
            End If

            If ddlBillingName.SelectedIndex > 0 Then
                filter &= " and ep.eoffice_project_billing_id ='" & ddlBillingName.SelectedValue & "'" & vbNewLine
            End If

            If ddlStaffName.SelectedIndex > 0 Then
                filter += " and ep.user_id='" & ddlStaffName.SelectedValue & "'" & vbNewLine
            End If

            If txtDateFrom.DateValue.Year <> 1 Then
                filter &= " and convert(varchar(8),ep.request_date,112) >= '" & txtDateFrom.GetDateCondition & "' " & vbNewLine
            End If
            If txtDateTo.DateValue.Year <> 1 Then
                filter &= " and convert(varchar(8),ep.request_date,112) <= '" & txtDateTo.GetDateCondition & "' " & vbNewLine
            End If

            SetExpenditureList(filter)
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.ToString()
        End Try

    End Sub

    Sub SetExpenditureList(ByVal wh As String)
        Dim sql As String = "select ep.id,p.project_name, pb.billing_name " & vbNewLine
        sql &= ",ep.request_id, convert(varchar(10),ep.request_date,103) as request_date, et.expense_type_desc, " & vbNewLine
        sql += " isnull((select sum(item_amt) from eOFFICE_EXPENDITURE_ITEM where eoffice_expenditure_id=ep.id),0) total_amt," & vbNewLine
        sql += " (select count(id) from eOFFICE_EXPENDITURE_ATTATCHMENT where eoffice_expenditure_id=ep.id) attatchment," & vbNewLine
        sql += " u.name + ' ' + u.surname staff_name " & vbNewLine
        sql &= " from eOFFICE_EXPENDITURE ep " & vbNewLine
        sql &= " inner join eOFFICE_PROJECT_BILLING pb on ep.eoffice_project_billing_id = pb.id " & vbNewLine
        sql &= " inner join eOFFICE_PROJECT p on pb.project_id = p.id " & vbNewLine
        sql &= " inner join eOFFICE_USER U on ep.user_id=U.id " & vbNewLine
        sql += " inner join eOFFICE_EXPENSE_TYPE et on et.id=ep.eoffice_expense_type_id " & vbNewLine


        'Expenditure Wait for Approve List
        Dim whT As String = " where p.pm_user_id = '" & Session("user_id") & "' "
        whT += " and ep.expenditure_status = '" & ExpenditureStatus.WaitForApproval & "'" & wh
        func.checkConn(MyConn)
        Dim da As New SqlDataAdapter(sql + whT, MyConn)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            rptWaitForApproveList.DataSource = dt
            rptWaitForApproveList.DataBind()
        Else
            rptWaitForApproveList.DataSource = Nothing
            rptWaitForApproveList.DataBind()
        End If


        'Expenditure Approved by PM
        whT = " where p.cost_control_user_id = '" & Session("user_id") & "' "
        whT += " and ep.expenditure_status = '" & ExpenditureStatus.ApproveByPM & "'" & wh
        func.checkConn(MyConn)
        da = New SqlDataAdapter(sql + whT, MyConn)
        dt = New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            rptApprovedByPM.DataSource = dt
            rptApprovedByPM.DataBind()
        Else
            rptApprovedByPM.DataSource = Nothing
            rptApprovedByPM.DataBind()
        End If


        'Expenditure Wait for Clear Bill
        Dim dtR As DataTable = func.GetUserResponsibilityList(Session("username"))
        dtR.DefaultView.RowFilter = "id='" & Responsibility.Accounting & "'"
        If dtR.DefaultView.Count > 0 Then
            whT = " where ep.expenditure_status = '" & ExpenditureStatus.WaitForClearBill & "' " & wh
            func.checkConn(MyConn)
            da = New SqlDataAdapter(sql + whT, MyConn)
            dt = New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                rptWaitForClearBill.DataSource = dt
                rptWaitForClearBill.DataBind()
            Else
                rptWaitForClearBill.DataSource = Nothing
                rptWaitForClearBill.DataBind()
            End If
        End If
        dtR.Dispose()



        da.Dispose()
        dt.Dispose()
    End Sub

    Private Function SaveExpenditureStatusLog(ByVal UserName As String, ByVal vID As String, ByVal StatusLog As String, ByVal StatusComment As String) As Boolean
        Dim sql As String = "insert into eOFFICE_EXPENDITURE_STATUS_LOG(id,created_by,created_date,"
        sql += "eoffice_expenditure_id,expenditure_status,status_comment)"
        sql += " values((select isnull(max(id)+1,1) from eOFFICE_EXPENDITURE_STATUS_LOG),'" & UserName & "',getdate(),"
        sql += " '" & vID & "','" & StatusLog & "','" & StatusComment & "')"
        Dim ret As Boolean = func.ExecuteSQL(sql)
        If ret = False Then
            lblError.Text = "Error SaveExpenditureStatusLog SQL :" & sql
            lblError.ForeColor = Drawing.Color.Red
        End If
        Return ret
    End Function


    Private Sub SetRepeaterItemCommand(ByVal e As RepeaterCommandEventArgs)
        Dim id As String = CType(e.CommandSource, Button).CommandArgument
        Dim CommandName As String = CType(e.CommandSource, Button).CommandName
        lblError.Visible = False

        If CommandName.ToUpper = "ViewEP".ToUpper Then
            Response.Redirect("EP_ViewExpenditureDetail.aspx?id=" & id)
        End If
    End Sub

    Sub rptWaitForApproveList_ItemCommand(ByVal o As Object, ByVal e As RepeaterCommandEventArgs) Handles rptWaitForApproveList.ItemCommand
        SetRepeaterItemCommand(e)
    End Sub

    Protected Sub rptApprovedByPM_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptApprovedByPM.ItemCommand
        SetRepeaterItemCommand(e)
    End Sub

    Protected Sub rptWaitForClearBill_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptWaitForClearBill.ItemCommand
        SetRepeaterItemCommand(e)
    End Sub
End Class
