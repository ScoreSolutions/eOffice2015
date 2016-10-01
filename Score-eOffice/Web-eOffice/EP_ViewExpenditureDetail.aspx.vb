Imports System.Data
Imports System.Data.SqlClient
Imports Constants
Imports Constants.Expenditure

Partial Class EP_ViewExpenditureDetail
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim Conf As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/")
    Dim MyConn As New SqlConnection(Conf.ConnectionStrings.ConnectionStrings("MyConn").ToString)
    Dim func As New EtimesheetSystem

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim ExpenditureID As String = ""
            If Request("token") IsNot Nothing Then
                If Session("token_data") = Request("token") Then
                    Dim sql As String = "select t.eoffice_user_id,t.token_data, t.return_page, t.ref_id,t.current_status "
                    sql += " from eOFFICE_EMAIL_TOKEN t "
                    sql += " inner join eOFFICE_EXPENDITURE e on e.id=t.ref_id"
                    sql += " where t.token_data='" & Request("token") & "'"
                    sql += " and e.expenditure_status=t.current_status"
                    sql += " and t.return_page='EP_ViewExpenditureDetail.aspx'"

                    Dim dt As New DataTable
                    dt = func.GetDatatable(sql)
                    If dt.Rows.Count > 0 Then
                        ExpenditureID = dt.Rows(0)("ref_id")
                    Else
                        Response.Redirect("login.aspx")
                    End If
                    dt.Dispose()
                Else
                    Response.Redirect("login.aspx")
                End If
            Else
                ExpenditureID = Request.QueryString("id")
            End If

            If ExpenditureID <> "" Then
                SetExpenditureDetail(ExpenditureID)
            End If
        End If
    End Sub

    Sub SetExpenditureDetail(ByVal ExpenditureID As String)
        Dim dt As New DataTable
        dt = GetExpenditureData(ExpenditureID)
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)

            lblRequestID.Text = dr("request_id")
            lblProjectName.Text = dr("project_name")
            lblProjectBillingName.Text = dr("billing_name")
            lblRequestDate.Text = Convert.ToDateTime(dr("request_date")).ToString("dd/MM/yyyy", New Globalization.CultureInfo("en-US"))
            lblExpenseType.Text = dr("expense_type_desc")
            lblExpenditureStatus.Text = dr("expenditure_status_name")

            lblID.Text = dr("id")
            lblStatus.Text = dr("expenditure_status")


            SetExpenditureItem(ExpenditureID)
            SetExpenditureAttachFile(ExpenditureID)

            pnlComment.Visible = False
            If lblStatus.Text = ExpenditureStatus.WaitForApproval Then
                If dr("pm_user_id") = Session("user_id") Then
                    pnlComment.Visible = True
                End If
            ElseIf lblStatus.Text = ExpenditureStatus.ApproveByPM Then
                If dr("cost_control_user_id") = Session("user_id") Then
                    pnlComment.Visible = True
                End If
            ElseIf lblStatus.Text = ExpenditureStatus.WaitForClearBill Then
                Dim dtR As DataTable = func.GetUserResponsibilityList(Session("username"))
                dtR.DefaultView.RowFilter = "id='" & Responsibility.Accounting & "'"
                If dtR.DefaultView.Count > 0 Then
                    pnlComment.Visible = True
                End If
                dtR.Dispose()
            End If
        End If
        dt.Dispose()
    End Sub

    Private Sub SetExpenditureItem(ByVal ExpenditureID As String)
        Dim sql As String = "select epi.id, eit.expense_item_type_desc,epi.item_desc," & vbNewLine
        sql += " epi.item_invoice_date,epi.item_amt" & vbNewLine
        sql += " from eOFFICE_EXPENDITURE_ITEM epi" & vbNewLine
        sql += " inner join eOFFICE_EXPENSE_ITEM_TYPE eit on eit.id=epi.eoffice_expense_item_type_id" & vbNewLine
        sql += " where eoffice_expenditure_id='" & ExpenditureID & "'"
        Dim dt As New DataTable
        dt = func.GetDatatable(sql)
        If dt.Rows.Count > 0 Then
            Dim TotAmt As Double = 0
            For Each dr As DataRow In dt.Rows
                TotAmt += Convert.ToDouble(dr("item_amt"))
            Next

            rptItem.DataSource = dt
            rptItem.DataBind()

            'Repeater1.Controls[repeater1.Controls.Count - 1].Controls[0].FindControl("ctrlID");
            Dim lblTotalAmt As Label = DirectCast(rptItem.Controls(rptItem.Controls.Count - 1).Controls(0).FindControl("lblTotalAmt"), Label)
            lblTotalAmt.Text = Format(TotAmt, "#,##0.00")

        End If
        dt.Dispose()
    End Sub

    Private Sub SetExpenditureAttachFile(ByVal ExpenditureID As String)
        Dim sql As String = "select epa.id,epa.file_name"
        sql += " from eOFFICE_EXPENDITURE_ATTATCHMENT epa"
        sql += " where eoffice_expenditure_id='" & ExpenditureID & "'"

        Dim dt As New DataTable
        dt = func.GetDatatable(sql)
        If dt.Rows.Count > 0 Then
            rptAttachFile.DataSource = dt
            rptAttachFile.DataBind()
        Else
            'dt = New DataTable
            'dt.Columns.Add("id")
            'dt.Columns.Add("file_name")

            'Dim dr As DataRow = dt.NewRow
            'dr("id") = ""
            'dr("file_name") = "No Attach File"
            'dt.Rows.Add(dr)

            'rptAttachFile.DataSource = dt
            'rptAttachFile.DataBind()
            rptAttachFile.Visible = False
        End If
        dt.Dispose()
    End Sub


    Function GetExpenditureData(ByVal ExpenditureID As String) As DataTable
        Dim sql As String = "select ep.id,ep.request_id, ep.request_date, pb.billing_name,p.project_name," & vbNewLine
        sql += " et.expense_type_desc," & vbNewLine
        sql += " case expenditure_status " & vbNewLine
        sql += "     when 0 then 'Entered' " & vbNewLine
        sql += "     when 1 then 'Wait for Approval'" & vbNewLine
        sql += "     when 2 then 'Approve by PM' " & vbNewLine
        sql += "     when 3 then 'Reject By PM' " & vbNewLine
        sql += "     when 4 then 'Wait for Clear Bill'" & vbNewLine
        sql += "     when 5 then 'Reject By Costcontroller'" & vbNewLine
        sql += "     when 6 then 'Finish' end as expenditure_status_name,ep.expenditure_status, " & vbNewLine
        sql += " p.pm_user_id, p.cost_control_user_id "
        sql += " from eOFFICE_EXPENDITURE ep" & vbNewLine
        sql += " inner join eOFFICE_PROJECT_BILLING pb on pb.id=ep.eoffice_project_billing_id" & vbNewLine
        sql += " inner join eOFFICE_PROJECT p on p.id=pb.project_id" & vbNewLine
        sql += " inner join eOFFICE_EXPENSE_TYPE et on et.id=ep.eoffice_expense_type_id" & vbNewLine
        sql += " where ep.id='" & ExpenditureID & "'" & vbNewLine

        Dim dt As New DataTable
        dt = func.GetDatatable(sql)
        Return dt
    End Function

    Protected Sub butApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butApprove.Click
        Dim ExpenditureID As String = lblID.Text
        func.checkConn(MyConn)
        Dim objTrans As SqlTransaction
        objTrans = MyConn.BeginTransaction
        Dim sql As String = ""
        Dim cmd As New SqlCommand
        cmd.Connection = MyConn
        cmd.Transaction = objTrans

        lblError.Visible = False
        Select Case lblStatus.Text
            Case ExpenditureStatus.WaitForApproval
                Try
                    sql = " Update eOFFICE_EXPENDITURE "
                    sql += " set expenditure_status = '" & ExpenditureStatus.ApproveByPM & "' "
                    sql += " where id ='" & ExpenditureID & "' and expenditure_status = '" & ExpenditureStatus.WaitForApproval & "'"
                    cmd.CommandText = sql
                    If cmd.ExecuteNonQuery() > 0 Then
                        sql = "insert into eOFFICE_EXPENDITURE_STATUS_LOG (id,created_date,created_by,eoffice_expenditure_id,expenditure_status,status_comment) "
                        sql &= " values((select isnull(max(id)+1,1) from eOFFICE_EXPENDITURE_STATUS_LOG),GETDATE(),'" & Session("username") & "','" & ExpenditureID & "','" & ExpenditureStatus.ApproveByPM & "','" & txtApproveText.Text & "')"
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()
                    End If
                    objTrans.Commit()

                    lblError.CssClass = "successBox"
                    lblError.Text = "Complete"
                    lblError.Visible = True
                    pnlComment.Visible = False

                    email.ExpenditureSendMailCostController(ExpenditureID)
                Catch ex As Exception
                    objTrans.Rollback()
                    lblError.Text = ex.ToString()
                    lblError.Visible = True
                    Exit Sub
                End Try
            Case ExpenditureStatus.ApproveByPM
                Try
                    sql = " Update eOFFICE_EXPENDITURE "
                    sql += " set expenditure_status = '" & ExpenditureStatus.WaitForClearBill & "' "
                    sql += " where id ='" & ExpenditureID & "' and expenditure_status = '" & ExpenditureStatus.ApproveByPM & "'"
                    cmd.CommandText = sql
                    If cmd.ExecuteNonQuery() > 0 Then
                        sql = "insert into eOFFICE_EXPENDITURE_STATUS_LOG (id,created_date,created_by,eoffice_expenditure_id,expenditure_status,status_comment) "
                        sql &= " values((select isnull(max(id)+1,1) from eOFFICE_EXPENDITURE_STATUS_LOG),GETDATE(),'" & Session("username") & "','" & ExpenditureID & "','" & ExpenditureStatus.WaitForClearBill & "','" & txtApproveText.Text & "')"
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()
                    End If
                    objTrans.Commit()

                    lblError.CssClass = "successBox"
                    lblError.Text = "Complete"
                    lblError.Visible = True
                    pnlComment.Visible = False

                    email.ExpenditureSendMailAccounting(ExpenditureID)
                Catch ex As Exception
                    objTrans.Rollback()
                    lblError.Text = ex.ToString()
                    lblError.Visible = True
                    Exit Sub
                End Try
            Case ExpenditureStatus.WaitForClearBill
                Try
                    sql = " Update eOFFICE_EXPENDITURE "
                    sql += " set expenditure_status = '" & ExpenditureStatus.Finished & "' "
                    sql += " where id ='" & ExpenditureID & "' and expenditure_status = '" & ExpenditureStatus.WaitForClearBill & "'"
                    cmd.CommandText = sql
                    If cmd.ExecuteNonQuery() > 0 Then
                        sql = "insert into eOFFICE_EXPENDITURE_STATUS_LOG (id,created_date,created_by,eoffice_expenditure_id,expenditure_status,status_comment) "
                        sql &= " values((select isnull(max(id)+1,1) from eOFFICE_EXPENDITURE_STATUS_LOG),GETDATE(),'" & Session("username") & "','" & ExpenditureID & "','" & ExpenditureStatus.Finished & "','" & txtApproveText.Text & "')"
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()
                    End If
                    objTrans.Commit()

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
        Dim ExpenditureID As String = lblID.Text
        func.checkConn(MyConn)
        Dim objTrans As SqlTransaction
        objTrans = MyConn.BeginTransaction
        Dim sql As String = ""
        Dim cmd As New SqlCommand
        cmd.Connection = MyConn
        cmd.Transaction = objTrans

        lblError.Visible = False
        Select Case lblStatus.Text
            Case ExpenditureStatus.WaitForApproval
                Try
                    sql = " Update eOFFICE_EXPENDITURE "
                    sql += " set expenditure_status = '" & ExpenditureStatus.RejectByPM & "' "
                    sql += " where id ='" & ExpenditureID & "' and expenditure_status='" & ExpenditureStatus.WaitForApproval & "'"
                    cmd.CommandText = sql
                    If cmd.ExecuteNonQuery() > 0 Then
                        sql = "insert into eOFFICE_EXPENDITURE_STATUS_LOG (id,created_date,created_by,eoffice_expenditure_id,expenditure_status,status_comment) "
                        sql &= " values((select isnull(max(id)+1,1) from eOFFICE_EXPENDITURE_STATUS_LOG),GETDATE(),'" & Session("username") & "','" & ExpenditureID & "','" & ExpenditureStatus.RejectByPM & "','" & txtApproveText.Text & "')"
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()
                    End If
                    objTrans.Commit()

                    lblError.CssClass = "successBox"
                    lblError.Text = "Complete"
                    lblError.Visible = True
                    pnlComment.Visible = False

                    Dim MailSubject As String = "Expenditure Reject by Project Manager"
                    email.ExpenditureSendMailReject(ExpenditureID, MailSubject)
                Catch ex As Exception
                    objTrans.Rollback()
                    lblError.Text = ex.ToString()
                    lblError.Visible = True
                    Exit Sub
                End Try
            Case ExpenditureStatus.ApproveByPM
                Try
                    sql = " Update eOFFICE_EXPENDITURE "
                    sql += " set expenditure_status = '" & ExpenditureStatus.RejectByCostcontroller & "' "
                    sql += " where id ='" & ExpenditureID & "' and expenditure_status='" & ExpenditureStatus.ApproveByPM & "'"
                    cmd.CommandText = sql
                    If cmd.ExecuteNonQuery() > 0 Then
                        sql = "insert into eOFFICE_EXPENDITURE_STATUS_LOG (id,created_date,created_by,eoffice_expenditure_id,expenditure_status,status_comment) "
                        sql &= " values((select isnull(max(id)+1,1) from eOFFICE_EXPENDITURE_STATUS_LOG),GETDATE(),'" & Session("username") & "','" & ExpenditureID & "','" & ExpenditureStatus.RejectByCostcontroller & "','" & txtApproveText.Text & "')"
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()
                    End If
                    objTrans.Commit()

                    lblError.CssClass = "successBox"
                    lblError.Text = "Complete"
                    lblError.Visible = True
                    pnlComment.Visible = False

                    Dim MailSubject As String = "Expenditure Reject by Cost Controller "
                    email.ExpenditureSendMailReject(ExpenditureID, MailSubject)
                Catch ex As Exception
                    objTrans.Rollback()
                    lblError.Text = ex.ToString()
                    lblError.Visible = True
                    Exit Sub
                End Try
        End Select

    End Sub

    

    
End Class
