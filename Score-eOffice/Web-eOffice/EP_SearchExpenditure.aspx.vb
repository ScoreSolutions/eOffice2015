Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports Constants.Expenditure

Partial Class EP_SearchExpenditure
    Inherits System.Web.UI.Page

    Dim MyConn As New SqlConnection(WebConfigurationManager.ConnectionStrings("MyConn").ToString)
    Dim func As New EtimesheetSystem

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ShowProject()
            ddlProject_SelectedIndexChanged(sender, e)
            'SetExpenditureList("")
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

            If txtDateFrom.DateValue.Year <> 1 Then
                filter &= " and convert(varchar(8),ep.request_date,112) >= '" & txtDateFrom.GetDateCondition & "' " & vbNewLine
            End If
            If txtDateTo.DateValue.Year <> 1 Then
                filter &= " and convert(varchar(8),ep.request_date,112) <= '" & txtDateTo.GetDateCondition & "' " & vbNewLine
            End If

            Dim status As String = ""
            For i As Integer = 0 To chkStatus.Items.Count - 1
                If chkStatus.Items(i).Selected = True Then
                    If status = "" Then
                        status = chkStatus.Items(i).Value
                    Else
                        status += "," & chkStatus.Items(i).Value
                    End If
                End If
            Next
            If status <> "" Then
                filter &= " and ep.expenditure_status in(" & status & ")" & vbNewLine
            End If

            SetExpenditureList(filter)
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.ToString()
        End Try

    End Sub

    Sub SetExpenditureList(ByVal wh As String)
        Dim sql As String = "select ep.id,p.project_name, pb.billing_name " & vbNewLine
        sql &= ",ep.request_id, convert(varchar(10),ep.request_date,103) as request_date, " & vbNewLine
        sql &= " case expenditure_status " & vbNewLine
        sql += "    when " & ExpenditureStatus.Entered & " then 'Entered' " & vbNewLine
        sql += "    when " & ExpenditureStatus.WaitForApproval & " then 'Wait for Approval'" & vbNewLine
        sql &= "    when " & ExpenditureStatus.ApproveByPM & " then 'Approve by PM' " & vbNewLine
        sql += "    when " & ExpenditureStatus.RejectByPM & " then 'Reject By PM' " & vbNewLine
        sql += "    when " & ExpenditureStatus.WaitForClearBill & " then 'Wait for Clear Bill'" & vbNewLine
        sql += "    when " & ExpenditureStatus.RejectByCostcontroller & " then 'Reject By Costcontroller'" & vbNewLine
        sql &= "    when " & ExpenditureStatus.Finished & " then 'Finish' end as expenditure_status_name,ep.expenditure_status," & vbNewLine
        sql += " et.expense_type_desc, "
        sql += " isnull((select sum(item_amt) from eOFFICE_EXPENDITURE_ITEM where eoffice_expenditure_id=ep.id),0) total_amt,"
        sql += " (select count(id) from eOFFICE_EXPENDITURE_ATTATCHMENT where eoffice_expenditure_id=ep.id) attatchment"
        sql &= " from eOFFICE_EXPENDITURE ep " & vbNewLine
        sql &= " inner join eOFFICE_PROJECT_BILLING pb on ep.eoffice_project_billing_id = pb.id " & vbNewLine
        sql &= " inner join eOFFICE_PROJECT p on pb.project_id = p.id " & vbNewLine
        sql &= " inner join eOFFICE_USER U on ep.user_id=U.id " & vbNewLine
        sql += " inner join eOFFICE_EXPENSE_TYPE et on et.id=ep.eoffice_expense_type_id " & vbNewLine
        sql += " where u.username = '" & Session("username") & "' " & wh
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
            Dim lblExpenditureStatus As String = CType(e.Item.FindControl("lblExpenditureStatus"), Label).Text

            Dim btnSelect As Button = CType(e.Item.FindControl("btnSelect"), Button)
            Dim btnSend As Button = CType(e.Item.FindControl("btnSend"), Button)
            Dim btnDelete As Button = CType(e.Item.FindControl("btnDelete"), Button)
            Dim btnView As Button = CType(e.Item.FindControl("btnView"), Button)

            btnSelect.Visible = False
            btnSend.Visible = False
            btnDelete.Visible = False
            btnView.Visible = False

            If lblExpenditureStatus = 0 Then
                btnDelete.Visible = True
            End If

            If lblExpenditureStatus = 0 Or lblExpenditureStatus = 3 Or lblExpenditureStatus = 5 Then
                btnSelect.Visible = True
                btnSend.Visible = True
            End If

            If lblExpenditureStatus = 1 Or lblExpenditureStatus = 2 Or lblExpenditureStatus = 4 Or lblExpenditureStatus = 6 Then
                btnView.Visible = True
            End If
        End If
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

    Sub rptTsDetailList_ItemCommand(ByVal o As Object, ByVal e As RepeaterCommandEventArgs) Handles rptTsDetailList.ItemCommand
        Dim id As String = CType(e.CommandSource, Button).CommandArgument
        Dim CommandName As String = CType(e.CommandSource, Button).CommandName
        lblError.Visible = False
        If CommandName.ToUpper = "EditEP".ToUpper Then
            Response.Redirect("EP_CreateExpenditure.aspx?id=" & id & "")
        End If

        If CommandName.ToUpper = "SendEP".ToUpper Then
            Dim Sql As String = "update eOFFICE_EXPENDITURE"
            Sql += " set expenditure_status='1'"
            Sql += " where id='" & id & "' and expenditure_status='0'"
            If func.ExecuteSQL(Sql) = True Then
                If SaveExpenditureStatusLog(Session("username"), id, "1", "Wait for Approval") = True Then
                    btnSearch_Click(Nothing, Nothing)

                    lblError.CssClass = "successBox"
                    lblError.Text = "Expenditure has been send successfully."
                    lblError.Visible = True

                    email.ExpenditureSendMailApprove(id)
                End If
            End If
        End If

        If CommandName.ToUpper = "DeleteEP".ToUpper Then
            Dim Sql As String = "delete from eOFFICE_EXPENDITURE_STATUS_LOG where eoffice_expenditure_id='" & id & "'"
            Dim ret As Boolean = func.ExecuteSQL(Sql)
            If ret = True Then
                Sql = "delete from eOFFICE_EXPENDITURE_ITEM where eoffice_expenditure_id='" & id & "'"
                ret = func.ExecuteSQL(Sql)
            End If

            If ret = True Then
                Sql = "delete from eOFFICE_EXPENDITURE_ATTATCHMENT where eoffice_expenditure_id='" & id & "'"
                ret = func.ExecuteSQL(Sql)
            End If

            If ret = True Then
                Sql = "delete from eOFFICE_EXPENDITURE where id = '" & id & "' "
                ret = func.ExecuteSQL(Sql)
            End If

            If ret = True Then
                btnSearch_Click(o, e)

                lblError.CssClass = "successBox"
                lblError.Text = "Expenditure has been delete successfully."
                lblError.Visible = True
            Else
                lblError.CssClass = "errorBox"
                lblError.Text = "Error Delete Expenditure"
                lblError.Visible = True
            End If
        End If

        If CommandName.ToUpper = "ViewEP".ToUpper Then
            Response.Redirect("EP_ViewExpenditureDetail.aspx?id=" & id)
        End If
    End Sub


End Class
