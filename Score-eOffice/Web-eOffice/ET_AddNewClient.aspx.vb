Option Strict Off
Option Explicit On
Imports system.data
Imports system.data.sqlclient

Partial Class _ET_AddNewClient
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim Conf As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/")
    Dim MyConn As New SqlConnection(Conf.ConnectionStrings.ConnectionStrings("MyConn").ToString)
    Dim last_parent As String = ""
    Dim func As New EtimesheetSystem
    Sub rptSelect(ByVal o As Object, ByVal e As RepeaterCommandEventArgs) Handles rptShowClient.ItemCommand
        Dim id As String = CType(e.CommandSource, Button).CommandArgument
        Dim comn As String = CType(e.CommandSource, Button).CommandName
        'Dim li_i As Int16
        ClearAllMessage()

        Dim li_RecCount As Int16
        li_RecCount = func.CmdSQL("Select Count(id) from eOFFICE_ACCOUNT ")
        If li_RecCount > 0 Then
            sql = ""
            func.checkConn(MyConn, "o")
            If comn.ToUpper = "SELECT" Then
                LoadAccount(id)
                GetContactPersonList()
                GetBranchList()
                GetProjectList()
                SetVisibleBut("SELECT")
            ElseIf comn.ToUpper = "DELETE" Then
                Dim sql As String = "delete from eOFFICE_ACCOUNT where id='" & id & "'"
                If func.ExecuteSQL(sql) = True Then
                    ClearAllMessage()
                    lblError.Text = "Record has been delete."
                    lblError.Visible = True
                End If
            End If
        Else
            ClearLoader()
            lblError.CssClass = "errorBox"
            lblError.Text = "Record not Found."
            SetVisibleBut("CANCEL")
            lblError.Visible = True
        End If
        func.BindControl(rptShowClient, 0, lblTempSQL.Text & " Order by a.account_name ")

        ClearContactForm()
        ClearBranchForm()
        ClearProjectForm()
    End Sub
    Sub SetVisibleBut(ByVal Mode As String)
        'Select Case UCase(Mode)
        '    Case "QUERY", "CANCEL", "DELETE", "SHOWALL"
        '        Me.butQuery.Visible = True
        '        Me.butSave.Visible = True
        '    Case "SAVE", "SELECT", "UPDATE"
        '        Me.butQuery.Visible = False
        '        Me.butSave.Visible = True
        'End Select

        Me.butQuery.Visible = True
        Me.butSave.Visible = True
    End Sub

    Private Sub LoadAccount(ByVal prm_Id As Int16)
        sql = "Select * from eOFFICE_ACCOUNT Where id=" & prm_Id
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet
        da.Fill(ds)
        lblAccountId.Text = func.fixNull(ds.Tables(0).Rows(0)("id"), "")
        txtAccountCode.Text = func.fixNull(ds.Tables(0).Rows(0)("account_code"), "")
        txtAccountName.Text = func.fixNull(ds.Tables(0).Rows(0)("account_Name"), "")
        txtAddress.Text = func.fixNull(ds.Tables(0).Rows(0)("account_Address"), "")
        If Convert.IsDBNull(ds.Tables(0).Rows(0)("account_province_id")) = False Then
            ddlProvince.SelectedValue = ds.Tables(0).Rows(0)("account_province_id")
        Else
            ddlProvince.SelectedValue = 0
        End If
        ddlProvince_SelectedIndexChanged(Nothing, Nothing)

        If Convert.IsDBNull(ds.Tables(0).Rows(0)("account_district_id")) = False Then
            ddlDistrict.SelectedValue = ds.Tables(0).Rows(0)("account_district_id")
        Else
            ddlDistrict.SelectedValue = 0
        End If
        ddlDistrict_SelectedIndexChanged(Nothing, Nothing)

        If Convert.IsDBNull(ds.Tables(0).Rows(0)("account_subdistrict_id")) = False Then ddlSubdistrict.SelectedValue = ds.Tables(0).Rows(0)("account_subdistrict_id") 'SetSubDistrict(Convert.ToInt64(ds.Tables(0).Rows(0)("account_subdistrict_id")))
        txtPostcode.Text = func.fixNull(ds.Tables(0).Rows(0)("account_postcode"))
        txtEmail.Text = func.fixNull(ds.Tables(0).Rows(0)("account_Email"), "")
        txtTelNo.Text = func.fixNull(ds.Tables(0).Rows(0)("account_tel_no"), "")
        txtFaxNo.Text = func.fixNull(ds.Tables(0).Rows(0)("account_fax_no"), "")
        txtMobile.Text = func.fixNull(ds.Tables(0).Rows(0)("account_mobile_no"), "")
    End Sub

    'Private Sub SetSubDistrict(ByVal SubdistrictID As Long)
    '    Dim sql As String = "select d.ms_province_id, d.id district_id, s.id subdistrict_id "
    '    sql += " from ms_subdistrict s"
    '    sql += " inner join ms_district d on d.id=s.ms_district_id "
    '    sql += " where s.id='" & SubdistrictID & "'"

    '    Dim dt As New DataTable
    '    dt = func.GetDatatable(sql)
    '    If dt.Rows.Count > 0 Then
    '        ddlProvince.SelectedValue = Convert.ToInt64(dt.Rows(0)("ms_province_id"))
    '        ddlProvince_SelectedIndexChanged(Nothing, Nothing)

    '        ddlDistrict.SelectedValue = Convert.ToInt64(dt.Rows(0)("district_id"))
    '        ddlDistrict_SelectedIndexChanged(Nothing, Nothing)

    '        ddlSubdistrict.SelectedValue = Convert.ToInt64(dt.Rows(0)("subdistrict_id"))
    '    End If
    '    dt.Dispose()

    'End Sub

    Private Sub ClearLoader()
        lblAccountId.Text = "0"
        txtAccountCode.Text = ""
        txtAccountName.Text = ""
        txtAddress.Text = ""
        ddlProvince.SelectedValue = "0"
        ddlProvince_SelectedIndexChanged(Nothing, Nothing)
        txtPostcode.Text = ""
        txtEmail.Text = ""
        txtTelNo.Text = ""
        txtFaxNo.Text = ""
        txtMobile.Text = ""
        lblError.Visible = False
    End Sub

    Private Function GetProvinceID() As String
        Dim ret As String = "NULL"
        If ddlProvince.SelectedValue > "0" Then
            ret = "'" & ddlProvince.SelectedValue & "'"
        End If
        Return ret
    End Function
    Private Function GetDistictID() As String
        Dim ret As String = "NULL"
        If ddlDistrict.SelectedValue > "0" Then
            ret = "'" & ddlDistrict.SelectedValue & "'"
        End If
        Return ret
    End Function
    Private Function GetSubdistictID() As String
        Dim ret As String = "NULL"
        If ddlSubdistrict.SelectedValue > "0" Then
            ret = "'" & ddlSubdistrict.SelectedValue & "'"
        End If
        Return ret
    End Function

    Protected Sub butSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butSave.Click
        Dim IsSaveSuccess As Boolean = False
        If lblAccountId.Text.Trim = "0" Then
            Dim Sql As String = "insert into eOFFICE_ACCOUNT (created_by,created_date,account_code,account_name,"
            Sql += " account_address, account_province_id,account_district_id, account_subdistrict_id,account_postcode,account_email,account_tel_no,account_fax_no,account_mobile_no)"
            Sql += " values('" & Session("username") & "',getdate(),'" & func.FixData(txtAccountCode.Text) & "','" & func.FixData(txtAccountName.Text) & "',"
            Sql += " '" & func.FixData(txtAddress.Text) & "'," & GetProvinceID() & "," & GetDistictID() & "," & GetSubdistictID() & ",'" & func.FixData(txtPostcode.Text) & "','" & func.FixData(txtEmail.Text) & "','" & func.FixData(txtTelNo.Text) & "','" & func.FixData(txtFaxNo.Text) & "','" & func.FixData(txtMobile.Text) & "')"

            If func.ExecuteSQL(Sql) = True Then
                Sql = "select IDENT_CURRENT('eOFFICE_ACCOUNT') maxID"
                Dim dt As New DataTable
                dt = func.GetDatatable(Sql)
                If dt.Rows.Count = 1 Then
                    If Convert.IsDBNull(dt.Rows(0)("MaxID")) = False Then
                        Dim MaxID As Long = Convert.ToInt64(dt.Rows(0)("MaxID"))
                        lblAccountId.Text = MaxID
                        butShowAll_Click(Nothing, Nothing)
                        LoadAccount(MaxID)
                        IsSaveSuccess = True
                    End If
                End If
                dt.Dispose()
            End If
        Else
            Dim sql As String = "update eoffice_account "
            sql += " set updated_by = '" & Session("username") & "'"
            sql += ", updated_date=getdate()"
            sql += ", account_code='" & func.FixData(txtAccountCode.Text) & "'"
            sql += ", account_name='" & func.FixData(txtAccountName.Text) & "'"
            sql += ", account_address = '" & func.FixData(txtAddress.Text) & "'"
            sql += ", account_province_id = " & GetProvinceID()
            sql += ", account_district_id = " & GetDistictID()
            sql += ", account_subdistrict_id = " & GetSubdistictID()
            sql += ", account_postcode = '" & func.FixData(txtPostcode.Text) & "'"
            sql += ", account_email = '" & func.FixData(txtEmail.Text) & "'"
            sql += ", account_tel_no = '" & func.FixData(txtTelNo.Text) & "'"
            sql += ", account_fax_no = '" & func.FixData(txtFaxNo.Text) & "'"
            sql += ", account_mobile_no = '" & func.FixData(txtMobile.Text) & "'"
            sql += " where id='" & lblAccountId.Text & "'"

            If func.ExecuteSQL(sql) = True Then
                Dim AccountID As Long = lblAccountId.Text
                butShowAll_Click(Nothing, Nothing)
                LoadAccount(AccountID)
                IsSaveSuccess = True
            End If
        End If

        If IsSaveSuccess = True Then
            ClearAllMessage()

            lblError.Text = "Record has been save successfully."
            lblError.Visible = True
        End If
    End Sub

    Protected Sub rptShowClient_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptShowClient.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblID As Label = DirectCast(e.Item.FindControl("lblAccuntListID"), Label)
            Dim dt As New DataTable
            dt = func.GetDatatable("select id from eOFFICE_ACCOUNT_CONTACT where account_id='" & lblID.Text & "'")
            If dt.Rows.Count > 0 Then
                Dim btnDel As Button = DirectCast(e.Item.FindControl("butDelete"), Button)
                btnDel.Visible = False
            Else
                dt = func.GetDatatable("select id from eOFFICE_ACCOUNT_BRANCH where account_id='" & lblID.Text & "'")
                If dt.Rows.Count > 0 Then
                    Dim btnDel As Button = DirectCast(e.Item.FindControl("butDelete"), Button)
                    btnDel.Visible = False
                Else
                    dt = func.GetDatatable("select id from eOFFICE_PROJECT where account_id='" & lblID.Text & "'")
                    If dt.Rows.Count > 0 Then
                        Dim btnDel As Button = DirectCast(e.Item.FindControl("butDelete"), Button)
                        btnDel.Visible = False
                    End If
                End If
            End If

            dt.Dispose()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            func.BindDropDownlist(ddlProvince, "0", "--Select--", "id", "province_name", "select id, province_name from ms_province where active_status='Y' order by province_name")
            ddlProvince_SelectedIndexChanged(Nothing, Nothing)
            'ddlDistrict_SelectedIndexChanged(Nothing, Nothing)

            txtEmail.Attributes.Add("onKeypress", "return validateEmail(this,event);")
            txtPostcode.Attributes.Add("onKeypress", "return validateNumericOnly(this,event);")
            txtMobile.Attributes.Add("onKeypress", "return validateNumericOnly(this,event);")

            butShowAll_Click(Nothing, Nothing)

            'Ini for Contact Person
            func.BindDropDownlist(ddlContactPrename, "-1", "--Select--", "id", "prename_desc", "select id, prename_desc from eOFFICE_PRENAME where prename_type='Human' order by prename_desc")
            txtContactMobile.Attributes.Add("onKeypress", "return validateNumericOnly(this,event);")

            'Ini for Branch
            func.BindDropDownlist(ddlBranchProvince, "0", "--Select--", "id", "province_name", "select id, province_name from ms_province where active_status='Y' order by province_name")
            ddlBranchProvince_SelectedIndexChanged(Nothing, Nothing)
            txtBranchEmail.Attributes.Add("onKeypress", "return validateEmail(this,event);")
            txtBranchPostcode.Attributes.Add("onKeypress", "return validateNumericOnly(this,event);")
            txtBranchMobileNo.Attributes.Add("onKeypress", "return validateNumericOnly(this,event);")

            'Ini for Project
            txtProjectElapsedTime.Attributes.Add("onKeypress", "return validateNumericOnly(this,event);")

            'Ini for Project Manager Name
            Dim uSql As String = "select id, name + ' ' + surname staff_name " & vbNewLine
            uSql += " from eOFFICE_USER " & vbNewLine
            uSql += " where convert(varchar(8),getdate(),112) between convert(varchar(8),start_date,112) and convert(varchar(8),isnull(end_date,getdate()),112) " & vbNewLine
            uSql += " order by name,surname"
            func.BindDropDownlist(ddlProjectManagerName, "", "--Select--", "id", "staff_name", uSql)

            func.BindDropDownlist(ddlProjectCostControlName, "", "--Select--", "id", "staff_name", uSql)
        End If
    End Sub

    Protected Sub butShowAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butShowAll.Click
        ClearLoader()
        sql = "SELECT a.* FROM  eOFFICE_ACCOUNT a Where 1=1 "
        lblTempSQL.Text = sql
        func.BindControl(rptShowClient, 0, sql & " Order by a.account_Name")
        rptShowClient.Visible = True
    End Sub

    Function MakeQery() As String
        Dim TempStrWhere As String = ""
        MakeQery = "SELECT a.* "
        MakeQery += " FROM  eOFFICE_ACCOUNT a  "
        MakeQery += " left join ms_subdistrict s on s.id=a.account_subdistrict_id"
        MakeQery += " left join ms_district d on d.id=s.ms_district_id"
        'MakeQery += " left join ms_province p on p.id=d.ms_province_id"
        MakeQery += " Where 1=1 "

        If txtAccountCode.Text.Trim <> "" Or txtAddress.Text.Trim <> "" Or txtAccountName.Text.Trim <> "" Or ddlProvince.SelectedValue <> "0" Or ddlDistrict.SelectedValue <> "0" Or ddlSubdistrict.SelectedValue <> "0" Or txtPostcode.Text.Trim <> "" Or txtEmail.Text.Trim <> "" Or txtTelNo.Text.Trim <> "" Or txtFaxNo.Text.Trim <> "" Or txtMobile.Text.Trim <> "" Then
            If txtAccountCode.Text <> "" Then
                TempStrWhere = TempStrWhere & " And a.account_code like '%" & func.FixData(txtAccountCode.Text) & "%'"
            End If
            If txtAccountName.Text <> "" Then
                TempStrWhere = TempStrWhere & " And a.account_name like '%" & func.FixData(txtAccountName.Text) & "%'"
            End If
            If txtAddress.Text <> "" Then
                TempStrWhere = TempStrWhere & " And a.account_address like '%" & func.FixData(txtAddress.Text) & "%'"
            End If
            If ddlProvince.SelectedValue <> "0" Then
                TempStrWhere = TempStrWhere & " And d.ms_province_id = '" & func.FixData(ddlProvince.SelectedValue) & "'"
            End If
            If ddlDistrict.SelectedValue <> "0" Then
                TempStrWhere = TempStrWhere & " And s.ms_district_id = '" & func.FixData(ddlDistrict.SelectedValue) & "'"
            End If
            If ddlSubdistrict.SelectedValue <> "0" Then
                TempStrWhere = TempStrWhere & " And a.account_subdistrict_id = '" & func.FixData(ddlSubdistrict.SelectedValue) & "'"
            End If
            If txtEmail.Text <> "" Then
                TempStrWhere = TempStrWhere & " And a.account_email like '%" & func.FixData(txtEmail.Text) & "%'"
            End If
            If txtTelNo.Text <> "" Then
                TempStrWhere = TempStrWhere & " And a.account_tel_no like '%" & func.FixData(txtTelNo.Text) & "%'"
            End If
            If txtFaxNo.Text <> "" Then
                TempStrWhere = TempStrWhere & " And a.account_fax_no like '%" & func.FixData(txtFaxNo.Text) & "%'"
            End If
            If txtMobile.Text <> "" Then
                TempStrWhere = TempStrWhere & " And a.account_mobile_no like '%" & func.FixData(txtMobile.Text) & "%'"
            End If
            MakeQery = MakeQery & TempStrWhere
        End If
    End Function
    Protected Sub butQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butQuery.Click
        sql = MakeQery()
        lblTempSQL.Text = sql
        func.BindControl(rptShowClient, 0, sql)
        SetVisibleBut("QUERY")
        lblError.Visible = False
        rptShowClient.Visible = True
    End Sub

    'Protected Sub txtMobile_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMobile.Init
    '    txtMobile.Attributes.Add("onkeypress", "if (event.keyCode < 45 || event.keyCode > 57 && (event.keyCode!=35)) event.returnValue = false;")
    'End Sub

    Protected Sub ddlProvince_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProvince.SelectedIndexChanged
        If ddlProvince.SelectedValue = "0" Then
            ddlDistrict.Items.Clear()
            ddlDistrict.Items.Add(New ListItem("--Select--", "0"))

            ddlDistrict_SelectedIndexChanged(Nothing, Nothing)
        Else
            func.BindDropDownlist(ddlDistrict, "0", "--Select--", "id", "district_name", "select id, district_name from ms_district where ms_province_id='" & ddlProvince.SelectedValue & "' and active_status='Y' order by district_name")
            ddlDistrict_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Protected Sub ddlDistrict_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDistrict.SelectedIndexChanged
        If ddlDistrict.SelectedValue = "0" Then
            ddlSubdistrict.Items.Clear()
            ddlSubdistrict.Items.Add(New ListItem("--Select--", "0"))
        Else
            func.BindDropDownlist(ddlSubdistrict, "0", "--Select--", "id", "subdistrict_name", "select id, subdistrict_name from ms_subdistrict where ms_district_id='" & ddlDistrict.SelectedValue & "' and active_status='Y' order by subdistrict_name")
        End If
    End Sub

    Private Sub ClearAllMessage()
        lblError.Text = ""
        lblError.Visible = False

        lblContactMessage.Text = ""
        lblContactMessage.Visible = False

        lblProjectMessage.Text = ""
        lblProjectMessage.Visible = False

        lblBranchMessage.Text = ""
        lblBranchMessage.Visible = False
    End Sub

#Region "Contact Person"
    Private Function GetPrenameID() As String
        Dim ret As String = "NULL"
        If ddlContactPrename.SelectedValue > "-1" Then
            ret = "'" & ddlContactPrename.SelectedValue & "'"
        End If
        Return ret
    End Function

    Protected Sub btnSaveContact_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveContact.Click
        If lblAccountId.Text = "0" Then
            lblContactMessage.Text = "Please Save Account Data"
            lblContactMessage.Visible = True
            Exit Sub
        End If

        If lblContactPersonID.Text = "0" Then
            Dim sql As String = "insert into eOFFICE_ACCOUNT_CONTACT (created_by,created_date,account_id,prename_id,"
            sql += "first_name,last_name,nickname,position_name,email,mobile)"
            sql += " values('" & Session("username") & "',getdate(),'" & lblAccountId.Text & "'," & GetPrenameID() & ","
            sql += " '" & func.FixData(txtContactFirstName.Text) & "','" & func.FixData(txtContactLastName.Text) & "','" & func.FixData(txtContactNickname.Text) & "',"
            sql += " '" & func.FixData(txtContactPositionName.Text) & "','" & func.FixData(txtContactEmail.Text) & "','" & func.FixData(txtContactMobile.Text) & "')"
            If func.ExecuteSQL(sql) = True Then
                ClearAllMessage()
                lblContactMessage.Text = "Record has been save successfully."
                lblContactMessage.Visible = True

                ClearContactForm()
                GetContactPersonList()
            End If
        Else
            Dim sql As String = "update eOFFICE_ACCOUNT_CONTACT"
            sql += " set updated_by='" & Session("username") & "'"
            sql += ", updated_date=getdate()"
            sql += ", account_id='" & lblAccountId.Text & "'"
            sql += ", prename_id='" & ddlContactPrename.SelectedValue & "'"
            sql += ", first_name = '" & func.FixData(txtContactFirstName.Text) & "'"
            sql += ", last_name = '" & func.FixData(txtContactLastName.Text) & "'"
            sql += ", nickname = '" & func.FixData(txtContactNickname.Text) & "'"
            sql += ", position_name = '" & func.FixData(txtContactPositionName.Text) & "'"
            sql += ", email = '" & func.FixData(txtContactEmail.Text) & "'"
            sql += ", mobile = '" & func.FixData(txtMobile.Text) & "'"
            sql += " where id= '" & lblContactPersonID.Text & "'"

            If func.ExecuteSQL(sql) = True Then
                ClearAllMessage()
                lblContactMessage.Text = "Record has been save successfully."
                lblContactMessage.Visible = True

                ClearContactForm()
                GetContactPersonList()
            End If
        End If
    End Sub

    Private Sub ClearContactForm()
        lblContactPersonID.Text = "0"
        ddlContactPrename.SelectedValue = "-1"
        txtContactFirstName.Text = ""
        txtContactLastName.Text = ""
        txtContactNickname.Text = ""
        txtContactPositionName.Text = ""
        txtContactEmail.Text = ""
        txtContactMobile.Text = ""
    End Sub

    Private Sub GetContactPersonList()
        Dim sql As String = "select ac.id, isnull(p.prename_desc,'')+ac.first_name + ' ' + ac.last_name contact_person_name,"
        sql += " ac.nickname, ac.position_name, ac.email, ac.mobile"
        sql += " from eOFFICE_ACCOUNT_CONTACT ac"
        sql += " left join eOFFICE_PRENAME p on p.id=ac.prename_id"
        sql += " where ac.account_id='" & lblAccountId.Text & "'"
        sql += " order by ac.first_name, ac.last_name"

        Dim dt As New DataTable
        dt = func.GetDatatable(sql)
        If dt.Rows.Count > 0 Then
            dt.Columns.Add("no")
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = (i + 1)
            Next
            gvContactPersonList.DataSource = dt
            gvContactPersonList.DataBind()
        Else
            gvContactPersonList.DataSource = Nothing
            gvContactPersonList.DataBind()
        End If
        dt.Dispose()
    End Sub

    Protected Sub gvContactPersonList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvContactPersonList.RowCommand
        If e.CommandName = "Select" Then
            Dim sql As String = "select ac.id,ac.prename_id,ac.first_name,ac.last_name,ac.nickname,ac.position_name,ac.email,ac.mobile "
            sql += " from eOFFICE_ACCOUNT_CONTACT ac"
            sql += " where ac.id ='" & e.CommandArgument & "'"

            Dim dt As New DataTable
            dt = func.GetDatatable(sql)
            If dt.Rows.Count > 0 Then
                ClearContactForm()

                Dim dr As DataRow = dt.Rows(0)
                lblContactPersonID.Text = dr("id")
                ddlContactPrename.SelectedValue = dr("prename_id")
                txtContactFirstName.Text = dr("first_name")
                txtContactLastName.Text = dr("last_name")
                If Convert.IsDBNull(dr("nickname")) = False Then txtContactNickname.Text = dr("nickname")
                If Convert.IsDBNull(dr("position_name")) = False Then txtContactPositionName.Text = dr("position_name")
                If Convert.IsDBNull(dr("email")) = False Then txtContactEmail.Text = dr("email")
                If Convert.IsDBNull(dr("mobile")) = False Then txtContactMobile.Text = dr("mobile")
            End If
            dt.Dispose()
        ElseIf e.CommandName = "Delete" Then
            Dim sql As String = "delete from eOFFICE_ACCOUNT_CONTACT where id='" & e.CommandArgument & "'"
            If func.ExecuteSQL(sql) = True Then
                ClearAllMessage()
                lblContactMessage.Text = "Record has been delete successfully."
                lblContactMessage.Visible = True

                ClearContactForm()
                GetContactPersonList()
            End If
        End If
    End Sub
    Protected Sub gvContactPersonList_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvContactPersonList.RowDeleting

    End Sub

#End Region

#Region "Project"
    Protected Sub btnSaveProject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveProject.Click
        If lblAccountId.Text = "0" Then
            lblProjectMessage.Text = "Please Save Account Data"
            lblProjectMessage.Visible = True
            Exit Sub
        End If

        Dim sql As String = ""
        If lblProjectID.Text = "0" Then
            sql = "insert into eOFFICE_PROJECT (created_by,created_date,account_id,"
            sql += "project_code,project_name,start_date,elapsed_time,active_status,pm_user_id,cost_control_user_id)"
            sql += " values('" & Session("username") & "',getdate(),'" & lblAccountId.Text & "',"
            sql += " '" & func.FixData(txtProjectCode.Text) & "','" & func.FixData(txtProjectName.Text) & "'," & txtProjectStartDate.GetDateToSave & "," & IIf(txtProjectElapsedTime.Text.Trim = "", "NULL", "'" & func.FixData(txtProjectElapsedTime.Text) & "'") & ",'Y',"
            sql += " '" & ddlProjectManagerName.SelectedValue & "','" & ddlProjectCostControlName.SelectedValue & "')"
        Else
            sql = "update eOFFICE_PROJECT"
            sql += " set account_id='" & lblAccountId.Text & "'"
            sql += ", project_code = '" & func.FixData(txtProjectCode.Text) & "'"
            sql += ", project_name = '" & func.FixData(txtProjectName.Text) & "'"
            sql += ", start_date = " & txtProjectStartDate.GetDateToSave
            sql += ", elapsed_time = " & IIf(txtProjectElapsedTime.Text.Trim = "", "NULL", "'" & txtProjectElapsedTime.Text & "'")
            sql += ", pm_user_id= '" & ddlProjectManagerName.SelectedValue & "'"
            sql += ", cost_control_user_id = '" & ddlProjectCostControlName.SelectedValue & "'"
            sql += ", updated_by = '" & Session("username") & "'"
            sql += ", updated_date = getdate()"
            sql += " where id='" & lblProjectID.Text & "'"
        End If

        If func.ExecuteSQL(sql) = True Then
            ClearProjectForm()

            ClearAllMessage()
            lblProjectMessage.Text = "Record has been save successfully."
            lblProjectMessage.Visible = True

            GetProjectList()
        End If
    End Sub

    Private Sub ClearProjectForm()
        lblProjectID.Text = "0"
        txtProjectCode.Text = ""
        txtProjectName.Text = ""
        txtProjectStartDate.DateValue = New Date(1, 1, 1)
        txtProjectElapsedTime.Text = ""
        ddlProjectManagerName.SelectedValue = ""
        ddlProjectCostControlName.SelectedValue = ""
    End Sub

    Private Sub GetProjectList()
        Dim sql As String = "select id,project_code,project_name,convert(varchar(10),start_date,103) start_date,elapsed_time "
        sql += " from eOFFICE_PROJECT"
        sql += " where account_id='" & lblAccountId.Text & "'"
        sql += " order by project_code"
        Dim dt As New DataTable
        dt = func.GetDatatable(sql)
        If dt.Rows.Count > 0 Then
            dt.Columns.Add("no")
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = (i + 1)
            Next

            gvProjectList.DataSource = dt
            gvProjectList.DataBind()
        Else
            gvProjectList.DataSource = Nothing
            gvProjectList.DataBind()
        End If
        dt.Dispose()
    End Sub

    Protected Sub gvProjectList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvProjectList.RowCommand
        If e.CommandName = "Select" Then
            Dim sql As String = "select id,project_code,project_name,start_date,elapsed_time, pm_user_id,cost_control_user_id "
            sql += " from eOFFICE_PROJECT"
            sql += " where id='" & e.CommandArgument & "'"

            Dim dt As New DataTable
            dt = func.GetDatatable(sql)
            If dt.Rows.Count > 0 Then
                ClearProjectForm()

                Dim dr As DataRow = dt.Rows(0)
                lblProjectID.Text = dr("id")
                txtProjectCode.Text = dr("project_code")
                txtProjectName.Text = dr("project_name")
                If Convert.IsDBNull(dr("start_date")) = False Then txtProjectStartDate.DateValue = Convert.ToDateTime(dr("start_date"))
                If Convert.IsDBNull(dr("elapsed_time")) = False Then txtProjectElapsedTime.Text = dr("elapsed_time")
                ddlProjectManagerName.SelectedValue = dr("pm_user_id")
                ddlProjectCostControlName.SelectedValue = dr("cost_control_user_id")
            End If
            dt.Dispose()

            ClearAllMessage()
        ElseIf e.CommandName = "Delete" Then
            Dim sql As String = "delete from eOFFICE_PROJECT where id='" & e.CommandArgument & "'"
            If func.ExecuteSQL(sql) = True Then
                ClearProjectForm()

                ClearAllMessage()
                lblProjectMessage.Text = "Record has been delete successfully."
                lblProjectMessage.Visible = True

                GetProjectList()
            End If
        End If
    End Sub

    Protected Sub gvProjectList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvProjectList.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim grv As GridViewRow = e.Row
            Dim ProjectID As String = grv.Cells(5).Text

            Dim sql As String = "select top 1 id from eOFFICE_PROJECT_BILLING where project_id='" & ProjectID & "'"
            Dim dt As New DataTable
            dt = func.GetDatatable(sql)
            If dt.Rows.Count > 0 Then
                Dim btnDel As Button = DirectCast(grv.FindControl("butProjectDelete"), Button)
                btnDel.Visible = False
            End If
            dt.Dispose()
        End If
    End Sub

    Protected Sub gvProjectList_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvProjectList.RowDeleting

    End Sub
#End Region

#Region "Branch"

    Protected Sub btnSaveBranch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveBranch.Click

        If lblAccountId.Text = "0" Then
            lblBranchMessage.Text = "Please Save Account Data"
            lblBranchMessage.Visible = True
            Exit Sub
        End If

        Dim sql As String = ""
        If lblBranchID.Text = "0" Then
            sql = "insert into eOFFICE_ACCOUNT_BRANCH(created_by,created_date,account_id,"
            sql += "branch_code,branch_name,branch_address,"
            sql += "branch_province_id,branch_district_id,branch_subdistrict_id,branch_postcode,"
            sql += "branch_email,branch_tel_no,branch_fax_no,branch_mobile_no,branch_contact_name)"
            sql += " values('" & Session("username") & "',getdate(),'" & lblAccountId.Text & "',"
            sql += " '" & func.FixData(txtBranchCode.Text) & "','" & func.FixData(txtBranchName.Text) & "','" & func.FixData(txtBranchAddress.Text) & "',"
            sql += " " & IIf(ddlBranchProvince.SelectedValue = "0", "NULL", "'" & ddlBranchProvince.SelectedValue & "'") & ","
            sql += " " & IIf(ddlBranchDistrict.SelectedValue = "0", "NULL", "'" & ddlBranchDistrict.SelectedValue & "'") & ","
            sql += " " & IIf(ddlBranchSubdistrict.SelectedValue = "0", "NULL", "'" & ddlBranchSubdistrict.SelectedValue & "'") & ","
            sql += " '" & func.FixData(txtBranchPostcode.Text) & "',"
            sql += " '" & func.FixData(txtBranchEmail.Text) & "',"
            sql += " '" & func.FixData(txtBranchTelNo.Text) & "',"
            sql += " '" & func.FixData(txtBranchFaxNo.Text) & "',"
            sql += " '" & func.FixData(txtBranchMobileNo.Text) & "',"
            sql += " '" & func.FixData(txtBranchContactName.Text) & "' "
            sql += ")"
        Else
            sql = "update eOFFICE_ACCOUNT_BRANCH"
            sql += " set updated_by='" & Session("username") & "'"
            sql += ", updated_date=getdate()"
            sql += ", account_id='" & lblAccountId.Text & "'"
            sql += ", branch_code='" & func.FixData(txtBranchCode.Text) & "'"
            sql += ", branch_name='" & func.FixData(txtBranchName.Text) & "'"
            sql += ", branch_address='" & func.FixData(txtBranchAddress.Text) & "'"
            sql += ", branch_province_id= " & IIf(ddlBranchProvince.SelectedValue = "0", "NULL", "'" & ddlBranchProvince.SelectedValue & "'")
            sql += ", branch_district_id= " & IIf(ddlBranchDistrict.SelectedValue = "0", "NULL", "'" & ddlBranchDistrict.SelectedValue & "'")
            sql += ", branch_subdistrict_id= " & IIf(ddlBranchSubdistrict.SelectedValue = "0", "NULL", "'" & ddlBranchSubdistrict.SelectedValue & "'")
            sql += ", branch_postcode= '" & func.FixData(txtBranchPostcode.Text) & "'"
            sql += ", branch_email= '" & func.FixData(txtBranchEmail.Text) & "'"
            sql += ", branch_tel_no= '" & func.FixData(txtBranchTelNo.Text) & "'"
            sql += ", branch_fax_no= '" & func.FixData(txtBranchFaxNo.Text) & "'"
            sql += ", branch_mobile_no= '" & func.FixData(txtBranchMobileNo.Text) & "'"
            sql += ", branch_contact_name= '" & func.FixData(txtBranchContactName.Text) & "' "
            sql += " where id='" & lblBranchID.Text & "'"
        End If

        If func.ExecuteSQL(sql) = True Then
            ClearBranchForm()
            ClearAllMessage()

            lblBranchMessage.Text = "Record has been save successfully."
            lblBranchMessage.Visible = True

            GetBranchList()
        End If
    End Sub

    Private Sub ClearBranchForm()
        lblBranchID.Text = "0"
        txtBranchCode.Text = ""
        txtBranchName.Text = ""
        txtBranchEmail.Text = ""
        txtBranchTelNo.Text = ""
        txtBranchFaxNo.Text = ""
        txtBranchMobileNo.Text = ""
        txtBranchContactName.Text = ""
        txtBranchAddress.Text = ""
        ddlBranchProvince.SelectedValue = "0"
        ddlBranchProvince_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Protected Sub ddlBranchProvince_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranchProvince.SelectedIndexChanged
        If ddlBranchProvince.SelectedValue = "0" Then
            ddlBranchDistrict.Items.Clear()
            ddlBranchDistrict.Items.Add(New ListItem("--Select--", "0"))
            ddlBranchDistrict_SelectedIndexChanged(Nothing, Nothing)
        Else
            func.BindDropDownlist(ddlBranchDistrict, "0", "--Select--", "id", "district_name", "select id, district_name from ms_district where ms_province_id='" & ddlBranchProvince.SelectedValue & "' and active_status='Y' order by district_name")
            ddlBranchDistrict_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Protected Sub ddlBranchDistrict_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranchDistrict.SelectedIndexChanged
        If ddlBranchDistrict.SelectedValue = "0" Then
            ddlBranchSubdistrict.Items.Clear()
            ddlBranchSubdistrict.Items.Add(New ListItem("--Select--", "0"))
        Else
            func.BindDropDownlist(ddlBranchSubdistrict, "0", "--Select--", "id", "subdistrict_name", "select id, subdistrict_name from ms_subdistrict where ms_district_id='" & ddlBranchDistrict.SelectedValue & "' and active_status='Y' order by subdistrict_name")
        End If
    End Sub

    Private Sub GetBranchList()
        Dim sql As String = "select ab.id,ab.branch_code,ab.branch_name, isnull(p.province_name,'') province_name, "
        sql += " ab.branch_email, ab.branch_tel_no, ab.branch_mobile_no, ab.branch_contact_name"
        sql += " from eOFFICE_ACCOUNT_BRANCH ab"
        sql += " left join MS_PROVINCE p on p.id=ab.branch_province_id"
        sql += " where ab.account_id='" & lblAccountId.Text & "'"

        Dim dt As New DataTable
        dt = func.GetDatatable(sql)
        If dt.Rows.Count > 0 Then
            dt.Columns.Add("no")
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = (i + 1)
            Next

            gvBranchList.DataSource = dt
            gvBranchList.DataBind()
        Else
            gvBranchList.DataSource = Nothing
            gvBranchList.DataBind()
        End If
        dt.Dispose()
    End Sub

    Protected Sub gvBranchList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvBranchList.RowCommand
        If e.CommandName = "Select" Then
            Dim sql As String = "select ab.id,ab.branch_code,ab.branch_name, ab.branch_address, ab.branch_province_id,ab.branch_district_id,ab.branch_subdistrict_id, "
            sql += " ab.branch_email, ab.branch_tel_no, ab.branch_fax_no, ab.branch_mobile_no, ab.branch_postcode, ab.branch_contact_name"
            sql += " from eOFFICE_ACCOUNT_BRANCH ab"
            sql += " where ab.id='" & e.CommandArgument & "'"

            Dim dt As New DataTable
            dt = func.GetDatatable(sql)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                ClearBranchForm()

                lblBranchID.Text = dr("id")
                txtBranchCode.Text = dr("branch_code")
                txtBranchName.Text = dr("branch_name")
                If Convert.IsDBNull(dr("branch_email")) = False Then txtBranchEmail.Text = dr("branch_email")
                If Convert.IsDBNull(dr("branch_tel_no")) = False Then txtBranchTelNo.Text = dr("branch_tel_no")
                If Convert.IsDBNull(dr("branch_fax_no")) = False Then txtBranchFaxNo.Text = dr("branch_fax_no")
                If Convert.IsDBNull(dr("branch_mobile_no")) = False Then txtBranchMobileNo.Text = dr("branch_mobile_no")
                If Convert.IsDBNull(dr("branch_address")) = False Then txtBranchAddress.Text = dr("branch_address")
                If Convert.IsDBNull(dr("branch_postcode")) = False Then txtBranchPostcode.Text = dr("branch_postcode")
                If Convert.IsDBNull(dr("branch_contact_name")) = False Then txtBranchContactName.Text = dr("branch_contact_name")
                If Convert.IsDBNull(dr("branch_province_id")) = False Then
                    ddlBranchProvince.SelectedValue = dr("branch_province_id")
                    ddlBranchProvince_SelectedIndexChanged(Nothing, Nothing)
                End If
                If Convert.IsDBNull(dr("branch_district_id")) = False Then
                    ddlBranchDistrict.SelectedValue = dr("branch_district_id")
                    ddlBranchDistrict_SelectedIndexChanged(Nothing, Nothing)
                End If
                If Convert.IsDBNull(dr("branch_subdistrict_id")) = False Then
                    ddlBranchSubdistrict.SelectedValue = dr("branch_subdistrict_id")
                End If
            End If
        ElseIf e.CommandName = "Delete" Then
            Dim sql As String = "delete from eOFFICE_ACCOUNT_BRANCH where id='" & e.CommandArgument & "'"
            If func.ExecuteSQL(sql) = True Then
                ClearBranchForm()
                ClearAllMessage()

                lblBranchMessage.Text = "Record has been delete successfully."
                lblBranchMessage.Visible = True

                GetBranchList()
            End If
        End If
    End Sub

    Protected Sub gvBranchList_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvBranchList.RowDeleting

    End Sub

#End Region




End Class

