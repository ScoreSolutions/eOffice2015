Option Strict Off
Option Explicit On
Imports system.data
Imports system.data.sqlclient

Partial Class _AddNewUser
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim Conf As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/")
    Dim MyConn As New SqlConnection(Conf.ConnectionStrings.ConnectionStrings("MyConn").ToString)
    Dim last_parent As String = ""
    Dim func As New EtimesheetSystem

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Master.Page.Title = "ADD USER"
        If Not IsPostBack() Then
            ShowPreName()
            ShowGroupMenu()
            showUser()
            Show_Data_Dep()
            Show_Data_pos()
        End If
        lblError.Visible = False
    End Sub

    Sub ShowPreName()
        func.BindDropDownlist(Me.DrpPreName, "-1", "-Select-", "id", "Prename_desc", "Select * from eOFFICE_PRENAME")
    End Sub

    Sub ShowGroupMenu()
        func.BindDropDownlist(Me.drpGroupShow, "-1", "-Select-", "id", "group_name", "select id,group_name_en as group_name from eOFFICE_USER_GROUP order by id")
    End Sub

    Sub Show_Data_Dep()
        sql = "Select Id,Department_Desc from eOFFICE_DEPARTMENT order by Department_Desc "
        func.BindDropDownlist(Me.ddl_Dep, "-1", "-Select-", "id", "Department_Desc", sql)
    End Sub

    Sub Show_Data_pos()
        sql = "Select id,Position_desc from eOFFICE_POSITION  order by Position_desc "
        func.BindDropDownlist(Me.ddl_pos, "-1", "-Select-", "id", "Position_desc", sql)
    End Sub
    
    Sub showUser()
        func.checkConn(MyConn)
        sql = " select a.*,b.group_name_en as group_name,p.position_desc from eOFFICE_USER a inner join eOFFICE_USER_GROUP b on a.group_id=b.id"
        sql &= " left join eOFFICE_POSITION p on a.position_id = p.id "
        sql &= " order by group_name,Name"
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet
        da.Fill(ds)
        rptShowUser.DataSource = ds
        rptShowUser.DataBind()
    End Sub

    Sub clear()
        txtFirstName.Text = ""
        txtLastName.Text = ""
        txtUserName.Text = ""
        drpGroupShow.SelectedValue = -1
        DrpPreName.SelectedValue = -1
        ddl_Dep.SelectedValue = -1
        ddl_pos.SelectedValue = -1
        txtEmployee_Id.Text = ""
        txtEmployee_Id.Text = ""
        txtemail.Text = ""
        txtmobile.Text = ""
        lblID.Text = 0
        txtUserName.Enabled = True
        txtPass.Text = ""
        txtPass1.Text = ""
        txtPass.Enabled = True
        txtPass1.Enabled = True
        txtStartDate.TxtBox.Text = ""
        txtEndDate.TxtBox.Text = ""
        lblError.Text = ""
        lblError.Visible = False
    End Sub

   
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        func.checkConn(MyConn, "c")
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            '## Start Validate ##
            lblError.Visible = True
            lblError.Text = ""
            lblError.CssClass = "errorBox"
            Dim gUser As String = ""
            Dim gPass As String = ""
            Select Case func.FixData(txtUserName.Text)
                Case "''"
                    gUser = "yes"
                Case ""
                    gUser = "yes"
                Case "'"
                    gUser = "yes"
                Case "''''"
                    gUser = "yes"
            End Select

            Select Case func.FixData(txtPass.Text)
                Case "''"
                    gPass = "yes"
                Case ""
                    gPass = "yes"
                Case "'"
                    gPass = "yes"
                Case "''''"
                    gPass = "yes"
            End Select

            If func.FixData(txtEmployee_Id.Text.Trim) = "" Or func.FixData(txtEmployee_Id.Text.Trim) = "''" Then
                lblError.Text = "Please Enter your Employee ID"
                txtEmployee_Id.Text = ""
                txtEmployee_Id.Focus()
            ElseIf DrpPreName.SelectedValue = -1 Then
                lblError.Text = "Please Enter your Pre Name"
            ElseIf func.FixData(txtFirstName.Text.Trim) = "" Or func.FixData(txtFirstName.Text.Trim) = "''" Then
                lblError.Text = "Please Enter your First name"
                txtFirstName.Text = ""
                txtFirstName.Focus()
            ElseIf func.FixData(txtLastName.Text.Trim) = "" Or func.FixData(txtLastName.Text.Trim) = "''" Then
                lblError.Text = "Please Enter your Last name"
                txtLastName.Text = ""
                txtLastName.Focus()
            ElseIf ddl_Dep.SelectedValue = -1 Then
                lblError.Text = "Please select Department for the Process"
            ElseIf ddl_pos.SelectedValue = "" Then
                lblError.Text = "Please select Position for the Process"
            ElseIf txtStartDate.GetDateToSave = "NULL" Then
                lblError.Text = "Please Enter your Start Date"
            ElseIf drpGroupShow.SelectedValue = -1 Then
                lblError.Text = "Please Enter your Group"
            ElseIf InStr(txtemail.Text, "@") = 0 Then
                lblError.Text = "Email is incorect format"
                txtemail.Focus()
            ElseIf func.FixData(txtUserName.Text.Trim) = "" Or gUser = "yes" Then
                lblError.Text = "Please Enter your Username"
                txtUserName.Text = ""
                txtUserName.Focus()
            ElseIf func.FixData(txtPass.Text) <> func.FixData(txtPass1.Text) Or gPass = "yes" And lblID.Text = "0" Then
                lblError.Text = "Password is blank or not match"
                txtPass.Focus()
            End If

            If lblError.Text <> "" Then
                Exit Sub
            End If

            Dim ds As New DataSet
            sql = "select Employee_Id from eOFFICE_USER where Employee_Id ='" & func.FixData(txtEmployee_Id.Text) & "' and id <> '" & func.FixData(lblID.Text) & "'"
            ds = func.Getdataset(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                lblError.CssClass = "errorBox"
                lblError.Text = "This employee id already have in system"
                Exit Sub
            End If

            ds = New DataSet
            sql = "select email from eOFFICE_USER where email ='" & func.FixData(txtemail.Text) & "' and id <> '" & func.FixData(lblID.Text) & "'"
            ds = func.Getdataset(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                lblError.CssClass = "errorBox"
                lblError.Text = "This email already have in system"
                Exit Sub
            End If
            '## End Validate ##


            If lblID.Text = "0" Then
                func.checkConn(MyConn)
                If func.dataExists("eOFFICE_USER", "username", func.FixData(CStr(txtUserName.Text))) Then
                    lblError.Text = "This username already have in system"
                    Exit Sub
                End If

                sql = " insert into eOFFICE_USER (PreName_Id,Employee_Id,name,surname,username,password,group_id,"
                sql &= " Department_Id,Position_Id,created_by,created_date,Member_Type,start_date,end_date,email,mobile_no,chg_pwd_first_login) values "
                sql &= "(" & IIf(DrpPreName.SelectedValue = -1, "NULL", DrpPreName.SelectedValue) & ""
                sql &= ",'" & txtEmployee_Id.Text & "'"
                sql &= ",'" & func.FixData(CStr(txtFirstName.Text)) & "'"
                sql &= ",'" & func.FixData(CStr(txtLastName.Text)) & "'"
                sql &= ",'" & func.FixData(CStr(Trim(txtUserName.Text))) & "'"
                sql &= ",'" & func.FixData(func.EnCripPwd(txtPass.Text)) & "'"
                sql &= "," & IIf(drpGroupShow.SelectedValue = -1, "NULL", "'" & drpGroupShow.SelectedValue & "'") & ""
                sql &= "," & IIf(ddl_Dep.SelectedValue = -1, "NULL", "  '" & ddl_Dep.SelectedValue & "'") & ""
                sql &= "," & IIf(ddl_pos.SelectedValue = -1, "NULL", "  '" & ddl_pos.SelectedValue & "'") & ""
                sql &= ",'" & Session("username") & "'"
                sql &= ",GETDATE(),'Human'"
                sql &= "," & txtStartDate.GetDateToSave & ""
                sql &= "," & txtEndDate.GetDateToSave & ""
                sql &= ",'" & func.FixData(CStr(txtemail.Text)) & "'"
                sql &= ",'" & func.FixData(CStr(txtmobile.Text)) & "','Y')"
                Dim cmd As New SqlCommand(sql, MyConn)
                cmd.ExecuteNonQuery()

            Else

                func.checkConn(MyConn)
                sql = "update eOFFICE_USER set PreName_ID =" & IIf(DrpPreName.SelectedIndex = 0, "NULL", "'" & DrpPreName.SelectedValue & "'") & ""
                sql &= ",Employee_Id = '" & CStr(func.FixData(txtEmployee_Id.Text.Trim)) & "'"
                sql &= ",Name = '" & CStr(func.FixData(txtFirstName.Text.Trim)) & "'"
                sql &= ",SurName= '" & CStr(func.FixData(txtLastName.Text.Trim)) & "'"
                sql &= ",group_id= " & IIf(drpGroupShow.SelectedValue = -1, "NULL", "'" & drpGroupShow.SelectedValue & "'") & ""
                sql &= ",Department_Id= " & IIf(ddl_Dep.SelectedValue = -1, "NULL", "  '" & ddl_Dep.SelectedValue & "'") & ""
                sql &= ",Position_Id= " & IIf(ddl_pos.SelectedValue = -1, "NULL", "  '" & ddl_pos.SelectedValue & "'") & ""
                sql &= ",email='" & CStr(func.FixData(txtemail.Text)) & "'"
                sql &= ",mobile_no='" & CStr(func.FixData(txtmobile.Text)) & "'"
                sql &= ",start_date=" & txtStartDate.GetDateToSave & ""
                sql &= ",end_date=" & txtEndDate.GetDateToSave & ""
                sql &= ",updated_by='" & Session("username") & "',updated_date=GETDATE()"
                sql &= " where username= '" & CStr(func.FixData(txtUserName.Text.Trim)) & "'"
                Dim cmd As New SqlCommand(sql, MyConn)
                cmd.ExecuteNonQuery()

            End If
            clear()
            showUser()
            lblError.CssClass = "successBox"
            lblError.Text = "User has been add successfully."
            lblError.Visible = True

        Catch ex As Exception
            lblError.Text = ex.ToString()
        End Try
    End Sub

    Sub EditDelete(ByVal o As Object, ByVal e As RepeaterCommandEventArgs) Handles rptShowUser.ItemCommand
        Dim id As String = CType(e.CommandSource, Button).CommandArgument
        Dim comn As String = CType(e.CommandSource, Button).CommandName
        func.checkConn(MyConn, "o")
        If comn.ToUpper = "EDIT" Then
            lblError.Visible = False
            sql = "select * from eOFFICE_USER where id= '" & id & "' "
            Dim da As New SqlDataAdapter(sql, MyConn)
            Dim ds As New DataSet
            da.Fill(ds)
            lblID.Text = ds.Tables(0).Rows(0)("Id")
            txtEmployee_Id.Text = ds.Tables(0).Rows(0)("Employee_Id")
            txtFirstName.Text = ds.Tables(0).Rows(0)("Name")
            txtLastName.Text = ds.Tables(0).Rows(0)("SurName")
            txtUserName.Text = ds.Tables(0).Rows(0)("Username")
            txtemail.Text = ds.Tables(0).Rows(0).Item("email").ToString
            txtmobile.Text = ds.Tables(0).Rows(0).Item("mobile_no").ToString
            txtUserName.Enabled = False
            txtPass.Enabled = False
            txtPass1.Enabled = False
           
            Try
                DrpPreName.SelectedValue = ds.Tables(0).Rows(0)("PreName_ID")
            Catch ex As Exception
                DrpPreName.SelectedValue = -1
            End Try

            Try
                drpGroupShow.SelectedValue = ds.Tables(0).Rows(0)("group_id")
            Catch ex As Exception
                drpGroupShow.SelectedValue = -1
            End Try

            Try
                ddl_Dep.SelectedValue = ds.Tables(0).Rows(0).Item("Department_Id").ToString
            Catch ex As Exception
                ddl_Dep.SelectedValue = -1
            End Try
            Try
                ddl_pos.SelectedValue = ds.Tables(0).Rows(0).Item("Position_Id").ToString
            Catch ex As Exception
                ddl_pos.SelectedValue = -1
            End Try

            Try
                txtStartDate.DateValue = ds.Tables(0).Rows(0).Item("start_date").ToString
            Catch ex As Exception
                txtStartDate.TxtBox.Text = ""
            End Try

            Try
                txtEndDate.DateValue = ds.Tables(0).Rows(0).Item("end_date").ToString
            Catch ex As Exception
                txtEndDate.TxtBox.Text = ""
            End Try

        ElseIf comn = "Delete" Then
            sql = "delete from eOFFICE_USER where id = '" & id & "' "
            Dim cmd As New SqlCommand(sql, MyConn)
            cmd.ExecuteNonQuery()
            lblError.CssClass = "successBox"
            lblError.Text = "User has been delete successfully."
            lblError.Visible = True
            clear()
        End If

        showUser()
    End Sub

    Protected Sub btnCancle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancle.Click
        clear()
    End Sub
End Class
