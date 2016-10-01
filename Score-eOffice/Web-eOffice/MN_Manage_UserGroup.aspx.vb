Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports System.Data
Partial Class _Manage_UserGroup
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim func As New EtimesheetSystem
    Dim Conf As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/")
    Dim MyConn As New SqlConnection(Conf.ConnectionStrings.ConnectionStrings("MyConn").ToString)

    ReadOnly Property ppMember_Id() As Integer
        Get
            Return Session("Member_Id") & ""
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Master.Page.Title = "Manage Group"
        If Not IsPostBack() Then
            showMenuList()
            'showUserList()
            showGroup()
            showResponsibility()
            btnCancel.Visible = False

        End If
        lblShowMessage.Visible = False
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If func.FixData(txtNameEn.Text.Trim) = "" Then
            lblShowMessage.Visible = True
            lblShowMessage.CssClass = "errorBox"
            lblShowMessage.Text = "Group Name English is blank"
        ElseIf CheckDuplicate("eOFFICE_USER_GROUP", "group_name_en", func.FixData(txtNameEn.Text.Trim), IIf(Val(btnSave.CommandArgument) > 0, btnSave.CommandArgument, 0)) And btnSave.CommandName.ToUpper <> "UPDATE" Then
            lblShowMessage.Visible = True
            lblShowMessage.CssClass = "errorBox"
            lblShowMessage.Text = "This group name en already have in system"
        ElseIf CheckDuplicate("eOFFICE_USER_GROUP", "group_name_th", func.FixData(txtNameTh.Text.Trim), IIf(Val(btnSave.CommandArgument) > 0, btnSave.CommandArgument, 0)) And btnSave.CommandName.ToUpper <> "UPDATE" Then
            lblShowMessage.Visible = True
            lblShowMessage.CssClass = "errorBox"
            lblShowMessage.Text = "This group name th already have in system"
        Else
            func.checkConn(MyConn)
            Dim cmd As New SqlCommand(sql, MyConn)
            Dim tmp As String = ""
            Dim tmpUser As String = ""
            For i As Integer = 0 To chkSelectedMenu.Items.Count - 1
                If tmp = "" Then
                    tmp = chkSelectedMenu.Items(i).Value
                Else
                    tmp &= "," & chkSelectedMenu.Items(i).Value
                End If
            Next
            For i As Integer = 0 To chkSelectedUser.Items.Count - 1
                If tmpUser = "" Then
                    tmpUser = chkSelectedUser.Items(i).Value
                Else
                    tmpUser &= "," & chkSelectedUser.Items(i).Value
                End If
            Next

            Dim GroupID As Long = 0

            Dim Command As String = btnSave.CommandName
            Dim msg As String = ""
            If btnSave.CommandName = "UPDATE" Then
                sql = "Update eOFFICE_USER_GROUP "
                sql += "Set group_menu= '" & CStr(tmp) & "' "
                sql += ", group_name_en= '" & func.FixData(CStr(txtNameEn.Text)) & "' "
                sql += ", group_name_th= '" & func.FixData(CStr(txtNameTh.Text)) & "' "
                sql += ", Active_status = '" & IIf(ckbUserGroup.Checked = True, "Y", "N") & "'"
                sql += ", updated_by = '" & ppMember_Id & "' "
                sql += ", updated_date = (select GETDATE())"
                sql += " where Id = '" & btnSave.CommandArgument & "';  "
                If tmpUser <> "" Then
                    sql += " Update eOFFICE_USER"
                    sql += " Set group_id= '" & btnSave.CommandArgument & "' "
                    sql += " Where id in (" & tmpUser & ");"
                End If
                btnSave.Text = "Add"
                btnSave.CommandName = "Add"
                btnCancel.Visible = False
                msg = "Group has been update successfully"
                GroupID = btnSave.CommandArgument
            Else
                sql = "Insert eOFFICE_USER_GROUP(group_menu,group_name_en,group_name_th,active_status,created_by,created_date) values ("
                sql += "'" & CStr(tmp) & "' "
                sql += ",'" & func.FixData(CStr(txtNameEn.Text)) & "' "
                sql += ",'" & func.FixData(CStr(txtNameTh.Text)) & "' "
                sql += ",'" & IIf(ckbUserGroup.Checked = True, "Y", "N") & "'"
                sql += ",'" & ppMember_Id & "' "
                sql += ",(select GETDATE())  )"
                msg = "Group has been add successfully"
            End If
            cmd.CommandText = sql
            If cmd.ExecuteNonQuery() > 0 Then
                If Command <> "UPDATE" Then
                    GroupID = GetLastID()
                End If

                If GroupID > 0 Then
                    If SaveRoleResponsibility(GroupID) = True Then
                        txtNameEn.Text = ""
                        txtNameTh.Text = ""
                        ckbUserGroup.Checked = False

                        lblShowMessage.Visible = True
                        lblShowMessage.CssClass = "successBox"
                        chkSelectedMenu.Items.Clear()
                        chkSelectedUser.Items.Clear()
                        showGroup()
                        showMenuList()
                        'showUserList()
                        lblShowMessage.Text = msg
                    End If
                End If
            End If
        End If

    End Sub

    Public Function GetLastID() As Long
        Dim ret As Long
        Dim Sql As String = "select IDENT_CURRENT('eOFFICE_USER_GROUP') lastID "
        Dim dt As DataTable = func.GetDatatable(Sql)
        If Convert.IsDBNull(dt.Rows(0)("lastID")) = False Then
            ret = Convert.ToInt64(dt.Rows(0)("lastID").ToString())
        Else
            ret = 1
        End If

        Return ret
    End Function

    Private Function SaveRoleResponsibility(ByVal GroupID As Long) As Boolean
        Dim ret As Boolean = True
        Dim dSql As String = "delete from eOFFICE_GROUP_RESPONSIBILITY where eoffice_user_group_id='" & GroupID & "'"
        If func.ExecuteSQL(dSql) = True Then
            For i As Integer = 0 To chkSelectedResponsibility.Items.Count - 1
                If chkSelectedResponsibility.Items(i).Value > 0 Then
                    Dim sql As String = " insert into eOFFICE_GROUP_RESPONSIBILITY (created_by, created_date, eoffice_user_group_id, eoffice_responsibility_id)"
                    sql += " values('" & ppMember_Id & "',getdate(),'" & GroupID & "','" & chkSelectedResponsibility.Items(i).Value & "')"

                    ret = func.ExecuteSQL(sql)
                    If ret = False Then
                        Exit For
                    End If
                End If
            Next
        End If
        Return ret
    End Function

    Sub showGroup()
        'sql = " select ID,case when group_name_en is null or group_name_en='' then isnull(group_name_th,'UnKnown')else group_name_en end as group_name from eOFFICE_USER_GROUP order by ID "
        sql = " select id,case when group_name_en is null or group_name_en='' then isnull(group_name_th,'UnKnown')else group_name_en end as group_name from eOFFICE_USER_GROUP order by id "
        func.checkConn(MyConn, "o")
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet()
        da.Fill(ds)
        rptGroupShow.DataSource = ds
        rptGroupShow.DataBind()
    End Sub
    Sub showMenuList()
        'sql = "select * from uba_menu where parent_id>0 and ID<> 25 order by ID"

        'sql = "SELECT a.*, b.menu_text AS parent_name FROM eOFFICE_MENU a LEFT OUTER JOIN eOFFICE_MENU b ON a.parent_id = b.ID "
        'sql &= "WHERE a.parent_id <> 0 AND a.parent_id <> '-1' "
        sql = " SELECT a.*, b.menu_text AS parent_name FROM eOFFICE_MENU a LEFT OUTER JOIN eOFFICE_MENU b ON a.parent_id = b.id "
        sql &= " WHERE a.parent_id <> 0 AND a.parent_id <> '-1' and a.active_status='Y'"
        sql &= " ORDER BY b.menu_text, a.menu_text"
        func.checkConn(MyConn, "o")
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet()
        da.Fill(ds)
        rptUbaMenu.DataSource = ds
        rptUbaMenu.DataBind()
    End Sub

    Sub showResponsibility()
        Dim sql As String = "select id, responsibility_name"
        sql += " from eoffice_responsibility "
        sql += " where active_status='Y'"
        sql += " order by responsibility_name"
        Dim dt As New DataTable
        dt = func.GetDatatable(sql)
        If dt.Rows.Count > 0 Then
            rptResponsibility.DataSource = dt
            rptResponsibility.DataBind()
        End If
        dt.Dispose()
    End Sub


    'Sub showUserList()
    '    sql = " select O.ID,"
    '    sql &= " employee_id, "
    '    sql &= " isnull(P.prename_desc,'') + Name + ' ' + surname  as FullName"
    '    sql &= " from eOFFICE_USER O"
    '    sql &= " left join eOFFICE_PRENAME P ON O.prename_id = p.id"
    '    func.checkConn(MyConn, "o")
    '    Dim da As New SqlDataAdapter(sql, MyConn)
    '    Dim ds As New DataSet()
    '    da.Fill(ds)
    '    rptUser.DataSource = ds
    '    rptUser.DataBind()
    'End Sub


    Sub EditDelete(ByVal o As Object, ByVal e As RepeaterCommandEventArgs) Handles rptGroupShow.ItemCommand
        Dim id As String = CType(e.CommandSource, Button).CommandArgument
        Dim comn As String = CType(e.CommandSource, Button).CommandName
        Dim chkArrayEdit() As String
        func.checkConn(MyConn, "o")
        If comn.ToUpper = "EDIT" Then
            sql = "select * from eOFFICE_USER_GROUP where ID= '" & id & "' "
            Dim da As New SqlDataAdapter(sql, MyConn)
            Dim ds As New DataSet
            da.Fill(ds)
            txtNameEn.Text = ds.Tables(0).Rows(0)("group_name_en")
            If Not IsDBNull(ds.Tables(0).Rows(0)("group_name_th")) Then txtNameTh.Text = ds.Tables(0).Rows(0)("group_name_th")
            If ds.Tables(0).Rows(0).Item("active_status").ToString = "Y" Then
                ckbUserGroup.Checked = True
            Else
                ckbUserGroup.Checked = False
            End If
            If ds.Tables(0).Rows(0)("group_menu") = "*" Then
                sql = "select ID from eOFFICE_MENU where parent_id>0 and ID<>25"
                Dim da1 As New SqlDataAdapter(sql, MyConn)
                Dim ds1 As New DataSet
                da1.Fill(ds1)
                'chkSelectedMenu.DataTextField = "ID"
                chkSelectedMenu.DataValueField = "ID"
                chkSelectedMenu.DataSource = ds1
            Else
                chkArrayEdit = Split(ds.Tables(0).Rows(0)("group_menu"), ",")
                chkSelectedMenu.DataSource = chkArrayEdit
                chkSelectedUser.DataSource = Split(getUserIDArray(id), ",")
            End If
            chkSelectedMenu.DataBind()
            chkSelectedUser.DataBind()


            'Fill Data to Role Responsibility
            Dim rSql As String = "select eoffice_responsibility_id "
            rSql += " from eOFFICE_GROUP_RESPONSIBILITY "
            rSql += " where eoffice_user_group_id = '" & id & "'"
            Dim dt As New DataTable
            dt = func.GetDatatable(rSql)
            If dt.Rows.Count > 0 Then
                chkSelectedResponsibility.DataValueField = "eoffice_responsibility_id"
                chkSelectedResponsibility.DataSource = dt
                chkSelectedResponsibility.DataBind()
            End If
            dt.Dispose()



            btnSave.Text = "Update"

            btnSave.CommandArgument = id
            btnSave.CommandName = "UPDATE"
            btnCancel.Visible = True
            showMenuList()
            'showUserList()
            showResponsibility()
        ElseIf comn = "Delete" Then

            If func.dataExists("eOFFICE_USER", "group_id", CStr(id)) = True Then
                func.checkConn(MyConn, "o")
                sql = "select * from eOFFICE_USER where group_id= '" & id & "' "
                Dim da As New SqlDataAdapter(sql, MyConn)
                Dim ds As New DataSet
                da.Fill(ds)

                If ds.Tables(0).Rows.Count > 0 Then
                    lblShowMessage.Text = "<br>Canot Delete Group <br>cause: There are users in the system belong to this group <br><br>" 'the users are listed below
                    'lblShowMessage.Text &= "user_id = " & ds.Tables(0).Rows(0)("user_id") & "  " & "username = " & ds.Tables(0).Rows(0)("username") & "   "
                    lblShowMessage.Text &= "<a href=edit_user.aspx?ID=" & id & ">Click here</a> to Edit/delete user"
                    lblShowMessage.Text &= "<br><br>"
                    lblShowMessage.Visible = True
                    lblShowMessage.CssClass = "errorBox"
                End If
                ds.Dispose()
                da.Dispose()
            Else
                sql = "Select Id from eOFFICE_USER where group_Id = '" & id & "' "
                Dim da As New SqlDataAdapter(sql, MyConn)
                Dim ds As New DataSet
                da.Fill(ds)
                If ds.Tables(0).Rows.Count = 0 Then
                    sql = "delete from eOFFICE_USER_GROUP where ID= '" & id & "' "
                    Dim cmd As New SqlCommand(sql, MyConn)
                    cmd.ExecuteNonQuery()
                    btnSave.Text = "Add"
                    'rptUbaMenu.Visible = False

                    lblShowMessage.Visible = True
                    lblShowMessage.CssClass = "successBox"
                    lblShowMessage.Text = "Delete successfully"
                Else
                    lblShowMessage.Visible = True
                    lblShowMessage.CssClass = "errorBox"
                    lblShowMessage.Text = "Can not delete this Record !"
                End If

                showGroup()
            End If

        End If
    End Sub

    'Sub fillGroupResponsibility()
    '    Dim sql As String = "select eoffice_responsibility_id "
    '    sql += " from eOFFICE_GROUP_RESPONSIBILITY"
    '    Dim dt As New DataTable
    '    dt = func.GetDatatable(sql)
    '    If dt.Rows.Count > 0 Then
    '        For Each rdt As RepeaterItem In rptResponsibility.Items
    '            If rdt.ItemType = ListItemType.Item Or rdt.ItemType = ListItemType.AlternatingItem Then
    '                Dim chkResponsibility As CheckBox = DirectCast(rdt.FindControl("chkResponsibility"), CheckBox)
    '                chkResponsibility.Check()
    '                dt.DefaultView.RowFilter = "eoffice_responsibility_id='" & chkResponsibility.Checked & "'"
    '            End If
    '        Next
    '    End If
    '    dt.Dispose()
    'End Sub

    Sub checkedChanged(ByVal o As Object, ByVal e As EventArgs)
        Dim chk As CheckBox = CType(o, CheckBox)
        If chk.Checked = True Then
            If chkSelectedMenu.Items.IndexOf(chkSelectedMenu.Items.FindByValue(chk.Attributes("value"))) < 0 Then
                chkSelectedMenu.Items.Add(chk.Attributes("value"))
            End If
        Else
            Response.Write(chk.ToolTip)
            chkSelectedMenu.Items.RemoveAt(chkSelectedMenu.Items.IndexOf(chkSelectedMenu.Items.FindByValue(chk.Attributes("value"))))
        End If
    End Sub

    Sub chkResponsibility_Changed(ByVal sender As Object, ByVal e As EventArgs)
        Dim chk As CheckBox = CType(sender, CheckBox)
        If chk.Checked = True Then
            If chkSelectedResponsibility.Items.IndexOf(chkSelectedResponsibility.Items.FindByValue(chk.Attributes("value"))) < 0 Then
                chkSelectedResponsibility.Items.Add(chk.Attributes("value"))
            End If
        Else
            Response.Write(chk.ToolTip)
            chkSelectedResponsibility.Items.RemoveAt(chkSelectedResponsibility.Items.IndexOf(chkSelectedResponsibility.Items.FindByValue(chk.Attributes("value"))))
        End If
    End Sub

    Sub checkedUserChanged(ByVal o As Object, ByVal e As EventArgs)

        Dim chk As CheckBox = CType(o, CheckBox)
        If chk.Checked = True Then
            If chkSelectedUser.Items.IndexOf(chkSelectedUser.Items.FindByValue(chk.Attributes("value"))) < 0 Then
                chkSelectedUser.Items.Add(chk.Attributes("value"))
            End If
        Else
            Response.Write(chk.ToolTip)
            chkSelectedUser.Items.RemoveAt(chkSelectedUser.Items.IndexOf(chkSelectedUser.Items.FindByValue(chk.Attributes("value"))))
        End If
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        func.checkConn(MyConn, "c")
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("MN_Manage_UserGroup.aspx")
    End Sub

    Protected Sub rptUbaMenu_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptUbaMenu.ItemDataBound
        Dim item As RepeaterItem = e.Item
        If item.ItemType = ListItemType.Item Or item.ItemType = ListItemType.AlternatingItem Then
            Dim chk As CheckBox = CType(item.FindControl("chkMenu"), CheckBox)
            If chkSelectedMenu.Items.IndexOf(chkSelectedMenu.Items.FindByValue(chk.Attributes("value"))) >= 0 Then
                chk.Checked = True
            End If
        End If
    End Sub

    'Protected Sub rptUser_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptUser.ItemDataBound
    '    Dim item As RepeaterItem = e.Item
    '    If item.ItemType = ListItemType.Item Or item.ItemType = ListItemType.AlternatingItem Then
    '        Dim chk As CheckBox = CType(item.FindControl("chkUser"), CheckBox)
    '        If chkSelectedUser.Items.IndexOf(chkSelectedUser.Items.FindByValue(chk.Attributes("value"))) >= 0 Then
    '            chk.Checked = True
    '        End If
    '    End If
    'End Sub

    Function CheckDuplicate(ByVal Tablename As String, ByVal columName As String, ByVal Value As String, ByVal Id As String) As Boolean
        sql = "Select * from " & Tablename & " where id <> " & Id & " and " & columName & " = '" & Value & "'"
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Function getUserIDArray(ByVal Id As String) As String
        sql = "select * from eOFFICE_USER where group_id=" & Id
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet
        da.Fill(ds)
        Dim tmpUser As String = ""
        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                If tmpUser = "" Then
                    tmpUser = ds.Tables(0).Rows.Item(i)("ID")
                Else
                    tmpUser &= "," & ds.Tables(0).Rows.Item(i)("ID")
                End If
            Next
            Return tmpUser
        Else
            Return ""
        End If
    End Function


    Protected Sub rptResponsibility_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptResponsibility.ItemDataBound
        Dim item As RepeaterItem = e.Item
        If item.ItemType = ListItemType.Item Or item.ItemType = ListItemType.AlternatingItem Then
            Dim chk As CheckBox = CType(item.FindControl("chkResponsibility"), CheckBox)
            If chkSelectedResponsibility.Items.IndexOf(chkSelectedResponsibility.Items.FindByValue(chk.Attributes("value"))) >= 0 Then
                chk.Checked = True
            End If
        End If
    End Sub
End Class
