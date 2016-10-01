Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class ET_ProjectBilling
    Inherits System.Web.UI.Page
    Dim MyConn As New SqlConnection(WebConfigurationManager.ConnectionStrings("MyConn").ToString)
    Dim func As New EtimesheetSystem

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ShowAccount()
            ddlAccount_SelectedIndexChanged(sender, e)
            ShowProjectBilling()
        End If
    End Sub

    Sub ShowAccount()
        Dim Sql As String = "Select Id,Account_name from eOFFICE_ACCOUNT order by Account_name "
        func.BindControl(Me.ddlAccount, 1, Sql)
    End Sub

    Sub ShowProject()
        Dim Sql As String = "Select Id,Project_name from eOFFICE_PROJECT where account_id='" & ddlAccount.SelectedValue & "' and active_status='Y' order by Project_name "
        func.BindControl(Me.ddlProject, 1, Sql)
    End Sub

    Sub ClearForm()
        ddlAccount.SelectedIndex = 0
        ddlProject.SelectedIndex = 0
        txtBillingName.Text = ""
        txtPONo.Text = ""
        txtPODate.TxtBox.Text = ""
        lblID.Text = "0"
        lblError.Visible = False
        lblError.Text = ""
    End Sub

    Sub ShowProjectBilling()
        Dim filter As String = ""
        If ddlAccount.SelectedIndex > 0 Then
            filter = " and account_id='" & ddlAccount.SelectedValue & "'"
        End If

        Dim sql As String = "select B.*,convert(varchar(10),B.ref_po_date,103) as str_po_date,A.account_name,P.project_name from eOFFICE_PROJECT_BILLING B "
        sql &= " Inner Join eOFFICE_PROJECT P ON B.project_id=P.id "
        sql &= " Inner Join eOFFICE_ACCOUNT A ON P.account_id =A.id where 1=1 " & filter & " order by A.account_name,P.project_name,billing_name"
        func.checkConn(MyConn)
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet
        da.Fill(ds)
        rptShowProjectBilling.DataSource = ds
        rptShowProjectBilling.DataBind()
    End Sub

    Protected Sub btnCancle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancle.Click
        ClearForm()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        lblError.Visible = True
        lblError.Text = ""
        lblError.CssClass = "errorBox"
        Try
            If ddlAccount.SelectedIndex = 0 Then
                lblError.Text = "Please Enter Account"
                Exit Sub
            ElseIf ddlProject.SelectedIndex = 0 Then
                lblError.Text = "Please Enter Project"
                Exit Sub
            ElseIf txtBillingName.Text = "" Then
                lblError.Text = "Please Enter Billing Name"
                txtBillingName.Focus()
                Exit Sub
                'ElseIf txtPONo.Text.Trim = "" Then
                '    lblError.Text = "Please Enter PO No"
                '    txtPONo.Focus()
                '    Exit Sub
                'ElseIf txtPODate.TxtBox.Text = "" Then
                '    lblError.Text = "Please Enter PO Date"
                '    Exit Sub
            End If

            Dim ds As New DataSet
            Dim Sql As String = "select top 1 id "
            Sql += " from eOFFICE_PROJECT_BILLING "
            Sql += " where billing_name ='" & func.FixData(txtBillingName.Text) & "' "
            Sql += " and project_id = '" & ddlProject.SelectedValue & "'"
            Sql += " and id <> '" & func.FixData(lblID.Text) & "'"
            ds = func.Getdataset(Sql)
            If ds.Tables(0).Rows.Count > 0 Then
                lblError.CssClass = "errorBox"
                lblError.Text = "This billing already have in system"
                Exit Sub
            End If

            func.checkConn(MyConn)
            If lblID.Text = "0" Then
                Sql = "insert into eOFFICE_PROJECT_BILLING(project_id,billing_name,ref_po_no,ref_po_date,created_by,created_date)"
                Sql &= " values('" & ddlProject.SelectedValue & "','" & txtBillingName.Text.Trim() & "'"
                Sql &= ",'" & txtPONo.Text.Trim() & "'," & txtPODate.GetDateToSave() & ",'" & Session("username") & "',GETDATE())"
            Else
                Sql = "Update eOFFICE_PROJECT_BILLING Set "
                Sql &= " project_id ='" & ddlProject.SelectedValue & "'"
                Sql &= ",billing_name ='" & txtBillingName.Text.Trim() & "'"
                Sql &= ",ref_po_no ='" & txtPONo.Text.Trim() & "'"
                Sql &= ",ref_po_date = " & txtPODate.GetDateToSave() & ""
                Sql &= ",updated_by='" & Session("username") & "',updated_date=GETDATE()"
                Sql &= " where id ='" & lblID.Text & "'"
            End If
            Dim cmd As New SqlCommand(Sql, MyConn)
            cmd.ExecuteNonQuery()

            ClearForm()
            ShowProjectBilling()
            lblError.CssClass = "successBox"
            lblError.Text = "Project Billing has been add successfully."
        Catch ex As Exception
            lblError.Text = ex.ToString()
        End Try

    End Sub

    Protected Sub ddlAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAccount.SelectedIndexChanged
        ShowProject()
        ShowProjectBilling()
    End Sub

    Sub EditDelete(ByVal o As Object, ByVal e As RepeaterCommandEventArgs) Handles rptShowProjectBilling.ItemCommand
        Dim id As String = CType(e.CommandSource, Button).CommandArgument
        If e.CommandName.ToUpper = "EDIT" Then
            lblError.Visible = False
            Dim Sql As String = "select B.*,p.account_id from eOFFICE_PROJECT_BILLING B "
            Sql &= " Inner Join eOFFICE_PROJECT P ON B.project_id=P.id "
            Sql &= " Inner Join eOFFICE_ACCOUNT A ON P.account_id =A.id where B.id= '" & id & "' "
            Dim da As New SqlDataAdapter(Sql, MyConn)
            Dim dt As New DataTable
            da.Fill(dt)
            lblID.Text = dt.Rows(0)("Id")

            Try
                ddlAccount.SelectedValue = dt.Rows(0)("account_id").ToString
                ddlAccount_SelectedIndexChanged(o, e)
            Catch ex As Exception
                ddlAccount.SelectedIndex = 0
            End Try

            Try
                ddlProject.SelectedValue = dt.Rows(0)("project_id").ToString
            Catch ex As Exception
                ddlProject.SelectedIndex = 0
            End Try

            txtBillingName.Text = dt.Rows(0)("billing_name").ToString
            txtPONo.Text = dt.Rows(0)("ref_po_no").ToString
            Try
                txtPODate.DateValue = dt.Rows(0)("ref_po_date")
            Catch ex As Exception
                txtPODate.TxtBox.Text = ""
            End Try

           
        ElseIf e.CommandName.ToUpper = "DELETE" Then
            func.checkConn(MyConn)
            Dim Sql As String = "delete from eOFFICE_PROJECT_BILLING where id = '" & id & "' "
            Dim cmd As New SqlCommand(Sql, MyConn)
            cmd.ExecuteNonQuery()
            lblError.CssClass = "successBox"
            lblError.Text = "Project Billing has been delete successfully."
            lblError.Visible = True
            ClearForm()
        End If

        ShowProjectBilling()
    End Sub

    Protected Sub rptShowProjectBilling_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptShowProjectBilling.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item) Or _
            (e.Item.ItemType = ListItemType.AlternatingItem) Then
            Dim id As String = CType(e.Item.FindControl("lblpjBillingID"), Label).Text
            Dim btn As Button = CType(e.Item.FindControl("btnDelete"), Button)
            Dim Sql As String = "select project_billing_id from eOFFICE_PROJECT_MANHOUR where project_billing_id ='" & id & "'"
            Dim da As New SqlDataAdapter(Sql, MyConn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                btn.Visible = False
            End If
        End If


    End Sub

End Class
