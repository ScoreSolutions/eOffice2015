Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Partial Class EP_CreateExpenditure
    Inherits System.Web.UI.Page
    Dim Conf As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/")
    Dim MyConn As New SqlConnection(Conf.ConnectionStrings.ConnectionStrings("MyConn").ToString)
    Dim func As New EtimesheetSystem

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ShowProject()
            ShowExpenseType(ddlExpenseType)
            ddlProject_SelectedIndexChanged(sender, e)
            SetListItem(Nothing)

            txtItemAmount.Attributes.Add("onKeypress", "return ChkMinusDbl(this,event);")
            txtItemAmount.Attributes.Add("style", "text-align:right;")

            If Request("id") IsNot Nothing Then
                FillData(Request("id"))
            End If
        End If
    End Sub

    Private Sub FillData(ByVal vID As String)
        Try
            Dim sql As String = "select ep.request_id,ep.request_date,ep.eoffice_project_billing_id,ep.user_id,ep.eoffice_expense_type_id,ep.expenditure_status, pb.project_id"
            sql += " from eOFFICE_EXPENDITURE ep "
            sql += " inner join eOFFICE_PROJECT_BILLING pb on pb.id=ep.eoffice_project_billing_id"
            sql += " where ep.id='" & vID & "'"
            Dim dt As New DataTable
            dt = func.GetDatatable(sql)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                lblID.Text = vID
                lblRequestID.Text = dr("request_id")
                txtDate.DateValue = Convert.ToDateTime(dr("request_date"))
                ddlProject.SelectedValue = dr("project_id")
                ddlProject_SelectedIndexChanged(Nothing, Nothing)

                ddlBillingName.SelectedValue = dr("eoffice_project_billing_id")
                ddlExpenseType.SelectedValue = dr("eoffice_expense_type_id")

                Dim dtI As New DataTable
                sql = "select epi.id, epi.eoffice_expense_item_type_id, eit.expense_item_type_desc as eoffice_expense_item_type_name, "
                sql += " epi.item_desc, epi.item_invoice_date, epi.item_amt"
                sql += " from eOFFICE_EXPENDITURE_ITEM epi"
                sql += " inner join eOFFICE_EXPENSE_ITEM_TYPE eit on eit.id=epi.eoffice_expense_item_type_id"
                sql += " where epi.eoffice_expenditure_id='" & vID & "'"
                dtI = func.GetDatatable(sql)
                If dtI.Rows.Count > 0 Then
                    dtI.Columns.Add("no")
                    SetListItem(dtI)
                End If

                ctlBrowseFileStream1.SetFileList(vID)
            End If
            dt.Dispose()
        Catch ex As Exception

        End Try
    End Sub

#Region "Sub&Function"
    Sub ShowProject()
        Dim sql As String = "select id,project_code from eOFFICE_PROJECT where active_status='Y' order by project_code "
        func.BindControl(Me.ddlProject, 1, sql)
    End Sub

    Sub ShowBillingName()
        Dim Sql As String = "Select Id,Billing_Name from eOFFICE_PROJECT_BILLING where project_id ='" & ddlProject.SelectedValue & "'  order by Billing_Name "
        func.BindControl(Me.ddlBillingName, 1, Sql)
    End Sub

    Sub ShowExpenseType(ByVal ddl As DropDownList)
        Dim Sql As String = "select id,expense_type_desc from eOFFICE_EXPENSE_TYPE where active_status='Y'  order by expense_type_desc "
        func.BindControl(ddl, 1, Sql)
    End Sub

    Function GetExpenseItemType() As DataTable
        Dim Sql As String = "select * from("
        Sql &= " select 0 seq, 0 as id,'-Select-' as expense_item_type_desc"
        Sql &= " union"
        Sql &= " select 1 seq, id,expense_item_type_desc "
        Sql += " from eOFFICE_EXPENSE_ITEM_TYPE "
        Sql += " where active_status='Y') T "
        Sql += " order by seq,expense_item_type_desc"
        func.checkConn(MyConn)
        Dim da As New SqlDataAdapter(Sql, MyConn)
        Dim dt As New DataTable
        da.Fill(dt)
        Return dt
    End Function

    Private Function GetListItem() As DataTable
        Dim dt As New DataTable
        With dt
            .Columns.Add(New DataColumn("no"))
            .Columns.Add(New DataColumn("id"))
            .Columns.Add(New DataColumn("eoffice_expense_item_type_name"))
            .Columns.Add(New DataColumn("eoffice_expense_item_type_id"))
            .Columns.Add(New DataColumn("item_desc"))
            .Columns.Add(New DataColumn("item_invoice_date"))
            .Columns.Add(New DataColumn("item_amt"))
        End With


        For i As Integer = 0 To gvListItem.Rows.Count - 1
            Dim no As String = ""
            Dim lblExpenditureItemID As Label
            Dim lblItemTypeName As Label
            Dim lblItemTypeID As Label
            Dim lblDescription As Label
            Dim lblInvoiceDate As Label
            Dim lblAmount As Label
            With gvListItem.Rows(i)
                no = .Cells(0).Text
                lblExpenditureItemID = DirectCast(.FindControl("lblItemID"), Label)
                lblItemTypeName = DirectCast(.FindControl("lblItemTypeName"), Label)
                lblItemTypeID = DirectCast(.FindControl("lblItemTypeID"), Label)
                lblDescription = DirectCast(.FindControl("lblDescription"), Label)
                lblInvoiceDate = DirectCast(.FindControl("lblInvoiceDate"), Label)
                lblAmount = DirectCast(.FindControl("lblAmount"), Label)
            End With

            If lblItemTypeName.Text <> "" And lblItemTypeID.Text <> "" And lblDescription.Text <> "" And lblInvoiceDate.Text <> "" And lblAmount.Text <> "" Then
                Dim dr As DataRow = dt.NewRow
                dr("no") = no
                dr("id") = lblExpenditureItemID.Text
                dr("eoffice_expense_item_type_name") = lblItemTypeName.Text
                dr("eoffice_expense_item_type_id") = lblItemTypeID.Text
                dr("item_desc") = lblDescription.Text
                dr("item_invoice_date") = lblInvoiceDate.Text 'New Date(lblInvoiceDate.Text.Substring(6, 4), lblInvoiceDate.Text.Substring(3, 2), lblInvoiceDate.Text.Substring(0, 2))
                dr("item_amt") = lblAmount.Text
                dt.Rows.Add(dr)
            End If
        Next
        Return dt
    End Function

    Sub SetListItem(ByVal dt As DataTable)
        If dt IsNot Nothing Then
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("no") = i + 1
                Next

                gvListItem.DataSource = dt
                gvListItem.DataBind()
            Else
                Dim dr As DataRow = dt.NewRow
                dt.Rows.Add(dr)
                gvListItem.DataSource = dt
                gvListItem.DataBind()
            End If
        Else
            dt = New DataTable
            dt = GetListItem()
            Dim dr As DataRow = dt.NewRow
            dt.Rows.Add(dr)
            gvListItem.DataSource = dt
            gvListItem.DataBind()
        End If
        dt.Dispose()
    End Sub

    'Sub UpdateListItem(ByVal no As String, ByVal newdt As DataTable)
    '    Dim dt As New DataTable
    '    dt = GetListItem()

    '    For i As Integer = 0 To gvListItem.Rows.Count - 1
    '        Dim strNo As String = dt.Rows(i)("no")
    '        If strNo <> no Then
    '            Dim lblTypeName As Label
    '            Dim lblTypeID As Label
    '            Dim lblDescription As Label
    '            Dim lblInvoiceDate As Label
    '            Dim lblAmount As Label
    '            With gvListItem.Rows(i)
    '                lblTypeName = DirectCast(.FindControl("lblTypeName"), Label)
    '                lblTypeID = DirectCast(.FindControl("lblTypeID"), Label)
    '                lblDescription = DirectCast(.FindControl("lblDescription"), Label)
    '                lblInvoiceDate = DirectCast(.FindControl("lblInvoiceDate"), Label)
    '                lblAmount = DirectCast(.FindControl("lblAmount"), Label)
    '            End With

    '            Dim dr As DataRow = dt.NewRow
    '            dr("eoffice_expense_item_type_name") = lblTypeName.Text
    '            dr("eoffice_expense_item_type_id") = lblTypeID.Text
    '            dr("item_desc") = lblDescription.Text
    '            dr("item_invoice_date") = lblInvoiceDate.Text 'New Date(lblInvoiceDate.Text.Substring(6, 4), lblInvoiceDate.Text.Substring(3, 2), lblInvoiceDate.Text.Substring(0, 2))
    '            dr("item_amt") = lblAmount.Text
    '            dt.Rows.Add(dr)
    '        Else
    '            If newdt IsNot Nothing AndAlso newdt.Rows.Count > 0 Then
    '                With newdt.Rows(0)
    '                    Dim dr As DataRow = dt.NewRow
    '                    dr("eoffice_expense_item_type_name") = .Item("eoffice_expense_item_type_name").ToString
    '                    dr("eoffice_expense_item_type_id") = .Item("eoffice_expense_item_type_id").ToString
    '                    dr("item_desc") = .Item("item_desc").ToString
    '                    dr("item_invoice_date") = .Item("item_invoice_date").ToString
    '                    dr("item_amt") = .Item("item_amt").ToString
    '                    dt.Rows.Add(dr)
    '                End With
    '            End If
    '        End If
    '    Next

    '    For i As Integer = 0 To dt.Rows.Count - 1
    '        dt.Rows(i)("no") = i + 1
    '    Next

    '    gvListItem.DataSource = dt
    '    gvListItem.DataBind()
    'End Sub

    'Sub DeleteListItem(ByVal no As String)
    '    Dim dt As New DataTable
    '    dt = GetListItem()


    '    Dim dr As DataRow
    '    For i As Integer = 0 To dt.Rows.Count - 1
    '        Dim lblTypeName As Label
    '        Dim lblTypeID As Label
    '        Dim lblDescription As Label
    '        Dim lblInvoiceDate As Label
    '        Dim lblAmount As Label
    '        Dim strNo As String = dt.Rows(i)("no")
    '        'With gvListItem.Rows(i)
    '        '    strNo = .Cells(0).Text
    '        '    lblTypeName = DirectCast(.FindControl("lblTypeName"), Label)
    '        '    lblTypeID = DirectCast(.FindControl("lblTypeID"), Label)
    '        '    lblDescription = DirectCast(.FindControl("lblDescription"), Label)
    '        '    lblInvoiceDate = DirectCast(.FindControl("lblInvoiceDate"), Label)
    '        '    lblAmount = DirectCast(.FindControl("lblAmount"), Label)
    '        'End With

    '        'If strNo <> no Then
    '        '    dr = dt.NewRow
    '        '    dr("eoffice_expense_item_type_name") = 
    '        '    dr("eoffice_expense_item_type_id") = lblTypeID.Text
    '        '    dr("item_desc") = lblDescription.Text
    '        '    dr("item_invoice_date") = lblInvoiceDate.Text 'New Date(lblInvoiceDate.Text.Substring(6, 4), lblInvoiceDate.Text.Substring(3, 2), lblInvoiceDate.Text.Substring(0, 2))
    '        '    dr("item_amt") = lblAmount.Text
    '        '    dt.Rows.Add(dr)
    '        'End If
    '    Next

    '    If dt.Rows.Count > 0 Then
    '        For i As Integer = 0 To dt.Rows.Count - 1
    '            dt.Rows(i)("no") = i + 1
    '        Next
    '        gvListItem.DataSource = dt
    '        gvListItem.DataBind()
    '    Else
    '        dr = dt.NewRow
    '        dt.Rows.Add(dr)
    '        gvListItem.DataSource = dt
    '        gvListItem.DataBind()
    '        'Dim columnCount As Integer = gvListItem.Rows(0).Cells.Count
    '        'gvListItem.Rows(0).Cells.Clear()
    '        'gvListItem.Rows(0).Cells.Add(New TableCell)
    '        'gvListItem.Rows(0).Cells(0).ColumnSpan = columnCount
    '        'gvListItem.Rows(0).Cells(0).Text = "No Records Found."
    '    End If

    'End Sub
#End Region

    Protected Sub ddlProject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProject.SelectedIndexChanged
        ShowBillingName()
    End Sub

    Protected Sub gvListItem_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvListItem.RowCommand
        If e.CommandName.Equals("AddNew") Then
            Dim ddlTypeName As DropDownList
            Dim txtDescription As TextBox
            Dim txtInvoiceDate As UserControls_txtDate
            Dim txtAmount As TextBox
            With gvListItem.FooterRow
                ddlTypeName = DirectCast(.FindControl("ddlGVExpenseType"), DropDownList)
                txtDescription = DirectCast(.FindControl("txtDescription"), TextBox)
                txtInvoiceDate = DirectCast(.FindControl("txtInvoiceDate"), UserControls_txtDate)
                txtAmount = DirectCast(.FindControl("txtAmount"), TextBox)
            End With

            lblError.Visible = False
            If ddlTypeName.SelectedIndex = 0 Then
                lblError.Visible = True
                lblError.Text = "กรุณาระบุ Type"
                gvListItem.EditIndex = -1
                Exit Sub
            End If
            If txtDescription.Text = "" Then
                lblError.Visible = True
                lblError.Text = "กรุณาระบุ Description"
                gvListItem.EditIndex = -1
            End If
            If txtInvoiceDate.DateValue.Year = 1 Then
                lblError.Visible = True
                lblError.Text = "กรุณาระบุ Invoice Date"
                gvListItem.EditIndex = -1
                Exit Sub
            End If

            If txtAmount.Text = "" Then
                lblError.Visible = True
                lblError.Text = "กรุณาระบุ Amount"
                gvListItem.EditIndex = -1
                Exit Sub
            End If

            Dim dt As New DataTable
            With dt
                .Columns.Add(New DataColumn("no"))
                .Columns.Add(New DataColumn("id"))
                .Columns.Add(New DataColumn("eoffice_expense_item_type_name"))
                .Columns.Add(New DataColumn("eoffice_expense_item_type_id"))
                .Columns.Add(New DataColumn("item_desc"))
                .Columns.Add(New DataColumn("item_invoice_date"))
                .Columns.Add(New DataColumn("item_amt"))
            End With
            Dim dr As DataRow
            dr = dt.NewRow
            dr("id") = "0"
            dr("eoffice_expense_item_type_name") = ddlTypeName.SelectedItem.Text
            dr("eoffice_expense_item_type_id") = ddlTypeName.SelectedValue
            dr("item_desc") = txtDescription.Text
            dr("item_invoice_date") = txtInvoiceDate.Text 'New Date(txtInvoiceDate.Text.Substring(6, 4), txtInvoiceDate.Text.Substring(3, 2), txtInvoiceDate.Text.Substring(0, 2))
            dr("item_amt") = txtAmount.Text
            dt.Rows.Add(dr)
        End If
    End Sub

    Protected Sub gvListItem_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvListItem.RowDataBound
        If e.Row.RowType = DataControlRowType.Footer Then
            Dim ddlGVExpenseType As DropDownList = DirectCast(e.Row.FindControl("ddlGVExpenseType"), DropDownList)
            If ddlGVExpenseType IsNot Nothing Then
                Dim dt As New DataTable
                dt = GetExpenseItemType()
                If dt.Rows.Count > 0 Then
                    ddlGVExpenseType.DataTextField = "expense_item_type_desc"
                    ddlGVExpenseType.DataValueField = "id"
                    ddlGVExpenseType.DataSource = dt
                    ddlGVExpenseType.DataBind()
                End If
                dt.Dispose()
            End If
        End If

        If e.Row.RowState = DataControlRowState.Edit Then
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim ddlGVExpenseType As DropDownList = DirectCast(e.Row.FindControl("ddlGVExpenseType"), DropDownList)
                Dim dtt As New DataTable
                dtt = GetExpenseItemType()
                If dtt.Rows.Count > 0 Then
                    ddlGVExpenseType.DataSource = dtt
                    ddlGVExpenseType.DataBind()
                End If
                dtt.Dispose()
            End If
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim ButtonDelete As Button = DirectCast(e.Row.FindControl("ButtonDelete"), Button)
            Dim ButtonEdit As Button = DirectCast(e.Row.FindControl("ButtonEdit"), Button)

            Dim no As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "no"))
            If no.Trim <> "" Then
                If ButtonDelete IsNot Nothing Then
                    ButtonDelete.Attributes.Add("onclick", (Convert.ToString("javascript:return deleteConfirm('") & no) + "')")
                End If
            Else
                ButtonDelete.Visible = False
                ButtonEdit.Visible = False
            End If
        End If
    End Sub

    'Protected Sub gvListItem_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvListItem.RowDeleting
    '    Dim id As String = gvListItem.DataKeys(e.RowIndex).Values("no").ToString()
    '    DeleteListItem(id)
    'End Sub

    'Protected Sub gvListItem_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvListItem.RowEditing
    '    gvListItem.EditIndex = e.NewEditIndex

    '    Dim dt As New DataTable
    '    dt = GetListItem()
    '    gvListItem.DataSource = dt
    '    gvListItem.DataBind()
    '    dt.Dispose()


    '    gvListItem.FooterRow.Visible = False

    '    'SetListItem(GetListItem())
    'End Sub

    'Protected Sub gvListItem_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvListItem.RowUpdating
    '    Dim no As String = gvListItem.DataKeys(e.RowIndex).Values("no").ToString()

    '    Dim dt As New DataTable
    '    With dt
    '        .Columns.Add(New DataColumn("no"))
    '        .Columns.Add(New DataColumn("eoffice_expense_item_type_name"))
    '        .Columns.Add(New DataColumn("eoffice_expense_item_type_id"))
    '        .Columns.Add(New DataColumn("item_desc"))
    '        .Columns.Add(New DataColumn("item_invoice_date"))
    '        .Columns.Add(New DataColumn("item_amt"))
    '    End With

    '    Dim ddlTypeName As DropDownList
    '    Dim txtDescription As TextBox
    '    Dim txtInvoiceDate As UserControls_txtDate
    '    Dim txtAmount As TextBox
    '    With gvListItem.Rows(e.RowIndex)
    '        ddlTypeName = DirectCast(.FindControl("ddlGVExpenseType"), DropDownList)
    '        txtDescription = DirectCast(.FindControl("txtDescription"), TextBox)
    '        txtInvoiceDate = DirectCast(.FindControl("txtInvoiceDate"), UserControls_txtDate)
    '        txtAmount = DirectCast(.FindControl("txtAmount"), TextBox)
    '    End With
    '    lblError.Visible = False
    '    If ddlTypeName.SelectedIndex = 0 Then
    '        lblError.Visible = True
    '        lblError.Text = "กรุณาระบุ Type"
    '        Exit Sub
    '    End If

    '    If txtInvoiceDate.TxtBox.Text = "" Then
    '        lblError.Visible = True
    '        lblError.Text = "กรุณาระบุ Invoice Date"
    '        Exit Sub
    '    End If

    '    If txtAmount.Text = "" Then
    '        lblError.Visible = True
    '        lblError.Text = "กรุณาระบุ Amount"
    '        Exit Sub
    '    End If

    '    Dim dr As DataRow
    '    dr = dt.NewRow
    '    dr("eoffice_expense_item_type_name") = ddlTypeName.SelectedItem.Text
    '    dr("eoffice_expense_item_type_id") = ddlTypeName.SelectedValue
    '    dr("item_desc") = txtDescription.Text
    '    dr("item_invoice_date") = txtInvoiceDate.TxtBox.Text 'New Date(lblInvoiceDate.Text.Substring(6, 4), lblInvoiceDate.Text.Substring(3, 2), lblInvoiceDate.Text.Substring(0, 2))
    '    dr("item_amt") = txtAmount.Text
    '    dt.Rows.Add(dr)

    '    'Dim dt As New DataTable
    '    'dt = GetListItem()
    '    'gvListItem.DataSource = dt
    '    'gvListItem.DataBind()
    '    'dt.Dispose()

    '    gvListItem.EditIndex = -1
    '    'UpdateListItem(no, dt)
    'End Sub

    Protected Sub ButtonAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAdd.Click
        Dim dt As New DataTable
        dt = GetExpenseItemType()
        If dt.Rows.Count > 0 Then
            ddlItemType.DataTextField = "expense_item_type_desc"
            ddlItemType.DataValueField = "id"
            ddlItemType.DataSource = dt
            ddlItemType.DataBind()
        End If
        dt.Dispose()

        popAddListItem.Show()
    End Sub

    Private Function ValidateItem() As Boolean
        If ddlItemType.SelectedValue = "0" Then
            lblItemError.Text = "กรุณาเลือก Type"
            lblItemError.Visible = True
            Return False
        End If
        If txtItemDescription.Text.Trim = "" Then
            lblItemError.Text = "กรุณาระบุ Description"
            lblItemError.Visible = True
            Return False
        End If
        If txtItemInvoiceDate.DateValue.Year = 1 Then
            lblItemError.Text = "กรุณาเลือก Invoice Date"
            lblItemError.Visible = True
            Return False
        End If
        If txtItemAmount.Text.Trim = "" Then
            lblItemError.Text = "กรุณาระบุ Amount"
            lblItemError.Visible = True
            Return False
        End If

        Return True
    End Function

    Private Sub ClearItemForm()
        lblExpenditureItemID.Text = "0"
        ddlItemType.SelectedValue = "0"
        txtItemDescription.Text = ""
        txtItemInvoiceDate.ClearDate()
        txtItemAmount.Text = ""
        lblItemError.Visible = False
        butSend.Visible = False
    End Sub

    Protected Sub btnItemSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnItemSave.Click
        If ValidateItem() = True Then
            Dim dt As DataTable = GetListItem()
            Dim dr As DataRow = dt.NewRow
            dr("id") = lblExpenditureItemID.Text
            dr("eoffice_expense_item_type_name") = ddlItemType.SelectedItem.Text
            dr("eoffice_expense_item_type_id") = ddlItemType.SelectedValue
            dr("item_desc") = txtItemDescription.Text
            dr("item_invoice_date") = txtItemInvoiceDate.DateValue.ToString("dd/MM/yyyy", New Globalization.CultureInfo("en-US"))
            dr("item_amt") = txtItemAmount.Text
            dt.Rows.Add(dr)

            SetListItem(dt)
            ClearItemForm()
        Else
            popAddListItem.Show()
        End If
    End Sub

    Protected Sub gvListItem_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvListItem.RowDeleting
        Dim dt As DataTable = GetListItem()
        Dim ItemID As String = dt.Rows(e.RowIndex)("id")
        If ItemID > 0 Then
            Dim dSql As String = "delete from eOFFICE_EXPENDITURE_ITEM where id='" & ItemID & "'"
            func.ExecuteSQL(dSql)
        End If

        dt.Rows.RemoveAt(e.RowIndex)

        SetListItem(dt)
    End Sub

    Private Function ValidateExpenditure() As Boolean
        If ddlProject.SelectedValue = "0" Then
            lblError.Visible = True
            lblError.Text = "กรุณาเลือก Project Name"
            Return False
        End If
        If ddlBillingName.SelectedValue = "0" Then
            lblError.Visible = True
            lblError.Text = "กรุณาเลือก Project Billing Name"
            Return False
        End If
        If txtDate.DateValue.Year = 1 Then
            lblError.Visible = True
            lblError.Text = "กรุณาเลือก Date"
            Return False
        End If
        If ddlExpenseType.SelectedItem.Value = "0" Then
            lblError.Visible = True
            lblError.Text = "กรุณาเลือก Expense Type"
            Return False
        End If

        Dim dt As DataTable = GetListItem()
        If dt.Rows.Count = 0 Then
            lblError.Visible = True
            lblError.Text = "กรุณาระบุ List Item"
            dt.Dispose()
            Return False
        End If
        dt.Dispose()
        lblError.Visible = False

        Return True
    End Function

    Private Function CreateRequestID() As String
        Dim ret As String = ""
        Dim Prefix As String = "Req" & DateTime.Now.ToString("yyyyMM")
        Dim dt As New DataTable
        Dim sql As String = "select top 1 e.request_id"
        sql += " from eOFFICE_EXPENDITURE e"
        sql += " where CHARINDEX('" & Prefix & "',e.request_id,0)>0"
        sql += " and convert(varchar(6),e.request_date,112)='" & DateTime.Now.ToString("yyyyMM") & "'"
        sql += " order by e.request_id desc"
        dt = func.GetDatatable(sql)
        If dt.Rows.Count > 0 Then
            Try
                Dim MaxID As Int16 = Convert.ToInt16(dt.Rows(0)("request_id").ToString.Replace(Prefix, ""))
                ret = Prefix & (MaxID + 1).ToString.PadLeft(4, "0")
            Catch ex As Exception
                ret = Prefix & "0001"
            End Try
        Else
            ret = Prefix & "0001"
        End If
        dt.Dispose()

        Return ret
    End Function

    Protected Sub butSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butSave.Click
        If ValidateExpenditure() = True Then
            If Session("user_id") IsNot Nothing Then
                Dim UserID As String = Session("user_id")
                Dim UserName As String = Session("username")
                Dim sql As String = ""
                Dim vID As String = ""
                If lblID.Text = "0" Then
                    lblRequestID.Text = CreateRequestID()

                    sql = "insert into eOFFICE_EXPENDITURE(id,created_by,created_date,request_id,request_date,"
                    sql += "eoffice_project_billing_id,user_id,eoffice_expense_type_id,expenditure_status)"
                    sql += " OUTPUT INSERTED.ID"
                    sql += " values((select isnull(max(id)+1,1) from eOFFICE_EXPENDITURE), '" & UserName & "',getdate(),'" & lblRequestID.Text & "',getdate(),"
                    sql += " '" & ddlBillingName.SelectedValue & "','" & UserID & "','" & ddlExpenseType.SelectedItem.Value & "','0')"
                    vID = func.ExecuteScalar(sql)
                    If SaveExpenditureStatusLog(UserName, vID, "0", "Entered") = False Then
                        vID = ""
                    End If
                Else
                    sql = "update eOFFICE_EXPENDITURE"
                    sql += " set eoffice_expense_type_id='" & ddlExpenseType.SelectedItem.Value & "',"
                    sql += " eoffice_project_billing_id='" & ddlBillingName.SelectedValue & "'"
                    sql += " where id='" & lblID.Text & "'"
                    If func.ExecuteSQL(sql) = True Then
                        vID = lblID.Text
                    End If
                End If

                If vID <> "" Then
                    If SaveListItem(vID, UserName) = True Then
                        Dim IsSave As Boolean = False
                        Dim fDt As DataTable = ctlBrowseFileStream1.GetFileList()
                        If fDt.Rows.Count > 0 Then
                            IsSave = SaveListFile(vID, UserName, fDt)
                        Else
                            IsSave = True
                        End If

                        If IsSave = True Then
                            lblID.Text = vID

                            lblError.Text = "Save Complete"
                            lblError.ForeColor = Drawing.Color.Blue

                            SetExpenditureStatus(vID)
                        End If
                    End If
                Else
                    lblError.Text = "Error Save Expenditure SQL:" & sql
                    lblError.ForeColor = Drawing.Color.Red
                End If
                lblError.Visible = True
            Else
                Session.RemoveAll()
                Response.Redirect("../Login.aspx?rnd=" & DateTime.Now.Millisecond)
            End If

        End If
    End Sub

    Private Sub SetExpenditureStatus(ByVal vID As String)
        Dim dt As New DataTable
        dt = func.GetDatatable("select expenditure_status from eoffice_expenditure where id='" & vID & "'")
        If dt.Rows.Count > 0 Then
            Select Case dt.Rows(0)("expenditure_status")
                Case 0, 3, 5
                    SetObjectStatus(True)
                Case Else
                    SetObjectStatus(False)
            End Select
        End If
        dt.Dispose()
    End Sub

    Private Sub SetObjectStatus(ByVal vStatus As Boolean)
        txtDate.VisibleImg = vStatus
        ddlProject.Enabled = vStatus
        ddlBillingName.Enabled = vStatus
        ddlExpenseType.Enabled = vStatus
        ButtonAdd.Visible = vStatus
        For Each grv As GridViewRow In gvListItem.Rows
            Dim ButtonEdit As Button = DirectCast(grv.FindControl("ButtonEdit"), Button)
            Dim ButtonDelete As Button = DirectCast(grv.FindControl("ButtonDelete"), Button)
            ButtonEdit.Visible = vStatus
            ButtonDelete.Visible = vStatus
        Next

        ctlBrowseFileStream1.EnabledUpload = vStatus

        butSave.Visible = vStatus
        butSend.Visible = vStatus
        butCancel.Visible = vStatus
    End Sub

    Private Function SaveListFile(ByVal vID As String, ByVal UserName As String, ByVal FileDT As DataTable) As Boolean
        Dim ret As Boolean = False
        Try
            Dim dSql As String = "delete from eOFFICE_EXPENDITURE_ATTATCHMENT where eoffice_expenditure_id='" & vID & "'"
            func.ExecuteSQL(dSql)

            For Each fDr As DataRow In FileDT.Rows
                If IO.File.Exists(fDr("temp_file_path")) = True Then
                    Dim fInfo As IO.FileInfo = DirectCast(fDr("file_prop"), IO.FileInfo)

                    Dim sql As String = "insert into eOFFICE_EXPENDITURE_ATTATCHMENT(id,created_by,created_date,"
                    sql += " eoffice_expenditure_id, file_name, file_ext, file_byte)"
                    sql += " values((select isnull(max(id)+1,1) from eOFFICE_EXPENDITURE_ATTATCHMENT),'" & UserName & "',getdate(),"
                    sql += " '" & vID & "','" & fDr("file_name") & "','" & fInfo.Extension & "',@_file_byte)"

                    Dim p As New SqlParameter("@_file_byte", SqlDbType.Image, fInfo.Length)
                    p.Value = IO.File.ReadAllBytes(fInfo.FullName)

                    If func.ExecuteSQL(sql, p) = False Then
                        lblError.Text = "Error SaveListFile SQL:" & sql
                        lblError.ForeColor = Drawing.Color.Red
                        ret = False
                    Else
                        ret = True
                    End If
                Else
                    lblError.Text = "No Temp File"
                    lblError.ForeColor = Drawing.Color.Red
                    ret = False
                End If

                If ret = False Then
                    Exit For
                End If
            Next
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

    Private Function SaveListItem(ByVal vID As String, ByVal UserName As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim dSql As String = "delete from eOFFICE_EXPENDITURE_ITEM where eoffice_expenditure_id='" & vID & "'"
            func.ExecuteSQL(dSql)

            Dim lDt As DataTable = GetListItem()
            For Each lDr As DataRow In lDt.Rows
                Dim Sql As String = "insert into eOFFICE_EXPENDITURE_ITEM(id,created_by,created_date,eoffice_expenditure_id,eoffice_expense_item_type_id,"
                Sql += " item_desc,item_invoice_date,item_amt)"
                Sql += " values((select isnull(max(id)+1,1) from eOFFICE_EXPENDITURE_ITEM), '" & UserName & "',getdate(),'" & vID & "','" & lDr("eoffice_expense_item_type_id") & "',"
                Sql += " '" & func.FixData(lDr("item_desc")) & "','" & func.FixDate(lDr("item_invoice_date").ToString) & "','" & lDr("item_amt") & "')"

                ret = func.ExecuteSQL(Sql)
                If ret = False Then
                    lblError.Text = "Error SaveListItem SQL:" & Sql
                    lblError.ForeColor = Drawing.Color.Red
                    Exit For
                End If
            Next
            lDt.Dispose()
        Catch ex As Exception

        End Try

        Return ret
    End Function

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

    Protected Sub butSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butSend.Click
        If lblID.Text.Trim > 0 Then
            Dim Sql As String = "update eOFFICE_EXPENDITURE"
            Sql += " set expenditure_status='1'"
            Sql += " where id='" & lblID.Text & "' and expenditure_status='0' "
            If func.ExecuteSQL(Sql) = True Then
                If SaveExpenditureStatusLog(Session("username"), lblID.Text, "1", "Wait for Approval") = True Then
                    SetExpenditureStatus(lblID.Text)
                    lblError.Text = "Send Complete"
                    lblError.ForeColor = Drawing.Color.Blue
                    lblError.Visible = True

                    email.ExpenditureSendMailApprove(lblID.Text)
                End If
            End If
        End If
        
    End Sub

    Protected Sub butCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butCancel.Click
        ClearItemForm()
    End Sub

    Protected Sub gvListItem_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvListItem.RowEditing

    End Sub
End Class
