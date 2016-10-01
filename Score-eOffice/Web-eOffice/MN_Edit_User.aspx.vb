Option Strict Off
Option Explicit On
Imports system.data
Imports system.data.sqlclient
Partial Class _edit_user
	Inherits System.Web.UI.Page
    Dim sql As String
    Dim Conf As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/")
    Dim MyConn As New SqlConnection(Conf.ConnectionStrings.ConnectionStrings("MyConn").ToString)
    Dim last_parent As String = ""
    Dim func As New EtimesheetSystem
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            ShowGroupMenu()
            showMenuList()
            showUser()
            btnCancel.Visible = False
            rptUbaMenu.Visible = False
            btnShowHide.Text = "Show"
            phEditUser.Visible = False
        End If

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim ds As New DataSet
        If txtID.Text <> "" And txtFirstName.Text <> "" And txtLastName.Text <> "" Then
            sql = "select Employee_Id from OF_Member where Employee_Id ='" & func.FixData(txtID.Text) & "' and member_id <> '" & func.FixData(lblID.Text) & "'"
            ds = func.Getdataset(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                lblError.CssClass = "errorBox"
                lblError.Text = "รหัสพนักงานซ้ำกับพนักงานท่านอื่น"
            Else

        If func.FixData(txtID.Text.Trim) = "" Then
            lblError.CssClass = "errorBox"
            lblError.Text = "Please Enter your employee_id"
        ElseIf func.FixData(txtFirstName.Text.Trim) = "" Then
            lblError.CssClass = "errorBox"
            lblError.Text = "Please Enter your first name"
        ElseIf func.FixData(txtLastName.Text.Trim) = "" Then
            lblError.CssClass = "errorBox"
            lblError.Text = "Please Enter your Last name"
        ElseIf drpGroupShow.SelectedValue = "" Then
            lblError.CssClass = "errorBox"
                    lblError.Text = "Please select group for the Process"
                ElseIf ddl_dep.SelectedValue = "" Then
                    lblError.CssClass = "errorBox"
                    lblError.Text = "Please select Department for the Process"
                ElseIf ddl_pos.SelectedValue = "" Then
                    lblError.CssClass = "errorBox"
                    lblError.Text = "Please select Position for the Process"
        Else
            lblError.CssClass = "successBox"
            lblError.Text = "update successfully"
            Dim tmp As String = ""
            For i As Integer = 0 To chkSelectedMenu.Items.Count - 1
                If tmp = "" Then
                    tmp = chkSelectedMenu.Items(i).Value
                Else
                    tmp &= "," & chkSelectedMenu.Items(i).Value
                End If
            Next
            func.checkConn(MyConn)
            sql = "update Of_Member set Employee_Id = '" & CStr(func.FixData(txtID.Text.Trim)) & "',Name = '" & CStr(func.FixData(txtFirstName.Text.Trim)) & "',SurName= '" & CStr(func.FixData(txtLastName.Text.Trim)) & "' , group_id= '" & drpGroupShow.SelectedValue & "' "
                    sql &= ",allow_menu = '" & CStr(tmp) & "',last_update_info = '" & Date.Now & "',Department_Id= '" & ddl_dep.SelectedValue & "',Position_Id= '" & ddl_pos.SelectedValue & "'  where username= '" & CStr(func.FixData(txtUserName.Text.Trim)) & "'"
            Dim cmd As New SqlCommand(sql, MyConn)
            cmd.ExecuteNonQuery()
            lblError.Visible = True
            showUser()
            rptShowUser.Visible = True
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtUserName.Text = ""
                    drpGroupShow.SelectedValue = ""
            phEditUser.Visible = False
            lblDelete.CssClass = "successBox"
            lblDelete.Visible = True
                    lblDelete.Text = " Update successfully"

                End If
            End If
        End If
        If lblError.Text <> "" Then
            lblError.Visible = True
        End If


    End Sub
    Sub ShowGroupMenu()
        func.checkConn(MyConn)
        'sql = "select group_id,case when group_name_en is null or group_name_en ='' then isnull( group_name_th,'UnKnown') else group_name_en end as group_name from uba_user_group order by group_id"
        sql = "select group_id,group_name_en as group_name from Of_user_group order by group_id "
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet
        da.Fill(ds)
        drpGroupShow.DataSource = ds
        drpGroupShow.DataTextField = "group_name"
        drpGroupShow.DataValueField = "group_id"
        drpGroupShow.DataBind()
        Dim tmp As New ListItem("----", "")
        drpGroupShow.Items.Insert(0, tmp)

    End Sub
    Sub showUser()
        Dim where As String = ""
        If IsNumeric(Request.QueryString("group_id")) Then
            where = "where a.group_id='" & Request.QueryString("group_id") & "' "
        End If
        func.checkConn(MyConn)
        'sql = "select a.*,case when b.group_name_en is null or group_name_en ='' then isnull(group_name_th,'Unknown') else group_name_en end as group_name from uba_user a inner join uba_user_group b on a.group_id=b.group_id " & where
        sql = "select a.*,b.group_name_en as group_name from Of_Member a inner join Of_user_group b on a.group_id = b.group_id " & where
        sql &= " order by group_name,Name"
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet
        da.Fill(ds)
        rptShowUser.DataSource = ds
        rptShowUser.DataBind()
    End Sub
    Sub showMenuList()
        'sql = "select * from uba_menu where parent_id>0 and menu_id<> 25 order by menu_id"
        sql = "SELECT a.*, b.menu_text AS parent_name FROM Of_menu a LEFT OUTER JOIN Of_menu b ON a.parent_id = b.menu_id "
        sql &= "WHERE a.parent_id <> 0 AND a.parent_id <> '-1' order by a.parent_id"
        func.checkConn(MyConn, "o")
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet()
        da.Fill(ds)
        rptUbaMenu.DataSource = ds
        rptUbaMenu.DataBind()
    End Sub

    Sub EditDelete(ByVal o As Object, ByVal e As RepeaterCommandEventArgs) Handles rptShowUser.ItemCommand
        Show_Data_Dep()
        Dim id As String = CType(e.CommandSource, Button).CommandArgument
        Dim comn As String = CType(e.CommandSource, Button).CommandName
        func.checkConn(MyConn, "o")
        If comn.ToUpper = "EDIT" Then
            lblError.Visible = False
            sql = "select * from Of_Member where Member_id= '" & id & "' "
            Dim da As New SqlDataAdapter(sql, MyConn)
            Dim ds As New DataSet
            Dim chkArraySelect() As String
            da.Fill(ds)
            lblID.Text = ds.Tables(0).Rows(0)("Member_Id")
            txtID.Text = ds.Tables(0).Rows(0)("Employee_Id")
            txtFirstName.Text = ds.Tables(0).Rows(0)("Name")
            txtLastName.Text = ds.Tables(0).Rows(0)("SurName")
            txtUserName.Text = ds.Tables(0).Rows(0)("Username")
            drpGroupShow.SelectedValue = ds.Tables(0).Rows(0)("group_id")
            If ds.Tables(0).Rows(0).Item("Department_Id").ToString = "" Then
                ddl_dep.SelectedValue = "0"
            Else
                ddl_dep.SelectedValue = ds.Tables(0).Rows(0).Item("Department_Id").ToString
                Show_Data_pos()
                Try
                    ddl_pos.SelectedValue = ds.Tables(0).Rows(0).Item("Position_Id").ToString
                Catch ex As Exception

                End Try

            End If
            If ds.Tables(0).Rows(0)("allow_menu") = "*" Then
                sql = "select menu_id from Of_menu where parent_id>0 and menu_id<>25"
                Dim da1 As New SqlDataAdapter(sql, MyConn)
                Dim ds1 As New DataSet
                da1.Fill(ds1)
                'chkSelectedMenu.DataTextField = "menu_id"
                chkSelectedMenu.DataValueField = "menu_id"
                chkSelectedMenu.DataSource = ds1
            Else
                chkArraySelect = Split(ds.Tables(0).Rows(0)("allow_menu"), ",")
                chkSelectedMenu.DataSource = chkArraySelect
            End If

            chkSelectedMenu.DataBind()

            btnSave.Visible = True
            btnCancel.Visible = True
            rptShowUser.Visible = False
            rptUbaMenu.Visible = False
            btnShowHide.Text = "show"
            phEditUser.Visible = True
            lblDelete.Visible = False
            btnSave.CommandArgument = id
            btnSave.CommandName = "UPDATE"
            showMenuList()


        ElseIf comn = "Delete" Then
            sql = "delete from of_Member where Member_id = '" & id & "' "
            Dim cmd As New SqlCommand(sql, MyConn)
            cmd.ExecuteNonQuery()
            btnSave.Visible = False
            lblDelete.CssClass = "successBox"
            lblDelete.Visible = True
            lblDelete.Text = " Delete successfully"
            phEditUser.Visible = False

        End If
        showUser()
    End Sub

    Protected Sub ShowHide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowHide.Click
        rptUbaMenu.Visible = Not rptUbaMenu.Visible
        If rptUbaMenu.Visible Then
            btnShowHide.Text = "Hide"
        Else
            btnShowHide.Text = "Show"
        End If
        showMenuList()
    End Sub

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

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        func.checkConn(MyConn, "c")
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("MN_Edit_User.aspx")
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
    Protected Sub drpGroupShow_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpGroupShow.SelectedIndexChanged
        Dim chkArraySelect() As String
        func.checkConn(MyConn, "o")
        If Not drpGroupShow.SelectedIndex = 0 Then
            sql = "select * from of_user_group where group_id = '" & drpGroupShow.SelectedValue & "' "
            Dim da As New SqlDataAdapter(sql, MyConn)
            Dim ds As New DataSet
            da.Fill(ds)
            chkArraySelect = Split(ds.Tables(0).Rows(0)("group_menu"), ",")
            chkSelectedMenu.DataSource = chkArraySelect
        Else
            chkSelectedMenu.DataSource = ""
        End If
        chkSelectedMenu.DataBind()
        showMenuList()
        rptUbaMenu.Visible = True
        btnShowHide.Text = "Hide"
    End Sub
    Protected Sub ddl_Dep_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_dep.SelectedIndexChanged
        Show_Data_pos()
    End Sub
    Sub Show_Data_Dep()
        sql = "Select  '' as Department_Id,'-select-' as Department_Dec Union  Select Department_Id,Department_Dec from OF_Department order by Department_Dec "
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            ddl_Dep.Items.Clear()
            ddl_Dep.DataSource = ds.Tables(0)
            ddl_Dep.DataTextField = "Department_Dec"
            ddl_Dep.DataValueField = "Department_Id"
            ddl_Dep.DataBind()
        End If
    End Sub
    Sub Show_Data_pos()
        sql = "Select  '' as Position_id,'-select-' as Position_dec Union  Select Position_id,Position_dec from OF_position where Department_Id = '" & ddl_Dep.SelectedValue & "' order by Position_dec "
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            ddl_pos.Items.Clear()
            ddl_pos.DataSource = ds.Tables(0)
            ddl_pos.DataTextField = "Position_dec"
            ddl_pos.DataValueField = "Position_id"
            ddl_pos.DataBind()
        End If
    End Sub
End Class

