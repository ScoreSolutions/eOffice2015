Option Strict Off
Option Explicit On
Imports system.data
Imports system.data.sqlclient
Partial Class ET_Department
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim Conf As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/")
    Dim MyConn As New SqlConnection(Conf.ConnectionStrings.ConnectionStrings("MyConn").ToString)
    Dim func As New EtimesheetSystem

    ReadOnly Property ppMember_Id() As Integer
        Get
            Return Session("Member_Id") & ""
        End Get
    End Property

    Sub btnDSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDSave.Click
        If func.FixData(txt_Name_Abb.Text) = "" Then
            lblError1.Visible = True
            lblError1.CssClass = "errorBox"
            lblError1.Text = "Please enter department abb"
            'txt_Name_Abb.Text = ""
            txt_Name_Abb.Focus()
        ElseIf func.FixData(txt_Name_Dep.Text) = "" Then
            lblError1.Visible = True
            lblError1.CssClass = "errorBox"
            lblError1.Text = "Please enter department"
            'txt_Name_Dep.Text = ""
            txt_Name_Dep.Focus()
        ElseIf CheckDuplicate("eOFFICE_DEPARTMENT", "department_abb", func.FixData(txt_Name_Abb.Text), 0) = True Then
            lblError1.Visible = True
            lblError1.CssClass = "errorBox"
            lblError1.Text = "Please enter department  duplicate"
            'txt_Name_Abb.Text = ""
            txt_Name_Abb.Focus()
        ElseIf CheckDuplicate("eOFFICE_DEPARTMENT", "department_desc", func.FixData(txt_Name_Dep.Text), 0) = True Then
            lblError1.Visible = True
            lblError1.CssClass = "errorBox"
            lblError1.Text = "Please enter department desc duplicate"
            'txt_Name_Dep.Text = ""
            txt_Name_Dep.Focus()
        Else
            Try
                sql = "INSERT INTO eOFFICE_DEPARTMENT(department_abb,department_desc,active_status,created_by,created_date) VALUES('" & func.FixData(Me.txt_Name_Abb.Text) & "','" & func.FixData(Me.txt_Name_Dep.Text) & "','" & IIf(ckb_Department.Checked = True, "Y", "N") & "'," & ppMember_Id & ",(select GETDATE()))"
                func.CmdSQL(sql)
                lblError1.CssClass = "successBox"
                lblError1.Text = "New department has been add successfully."
                lblError1.Visible = True
                txt_Name_Abb.Text = ""
                txt_Name_Dep.Text = ""
                ckb_Department.Checked = False
                txt_Name_Abb.Focus()
                Show_Data()
                Exit Sub
            Catch ex As Exception
                ' ClientScript.RegisterStartupScript(Me.GetType(), "Alert", "alert('Can not insert!');", True)
                lblError1.Visible = True
                lblError1.CssClass = "errorBox"
                lblError1.Text = "Can not insert!"
            End Try
        End If

    End Sub

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

    Sub Show_Data()
        sql = "Select * from eOFFICE_DEPARTMENT order by Id DESC "
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
        End If
    End Sub
    Sub Show_Data_Position()
        'sql = "Select OF_position.Position_id,OF_Department.Department_Desc,OF_position.Position_dec from OF_Department inner join OF_position on OF_Department.Department_Id = OF_position.Department_Id order by OF_position.Position_id DESC "
        sql = " SELECT  "
        sql &= " P.ID,"
        sql &= " P.Position_desc"
        sql &= " FROM eOFFICE_POSITION P"
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            GridView2.DataSource = ds.Tables(0)
            GridView2.DataBind()
        End If
    End Sub
    

    Sub UpdatePanel1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdatePanel1.Load
        If Not Page.IsPostBack Then
            Show_Data()
            Show_Data_Position()
        End If
    End Sub

    Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        Show_Data()
    End Sub

    Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs)
        Dim sID As String = GridView1.DataKeys(e.RowIndex).Value
        sql = "Select Id from eOFFICE_USER where Department_Id = '" & sID & "' "
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count = 0 Then
            sql = "Delete  eOFFICE_DEPARTMENT where Id = '" & sID & "'"
            func.CmdSQL(sql)
            lblError1.CssClass = "successBox"
            lblError1.Text = "Delete department has been add successfully."
            lblError1.Visible = True
            Show_Data()
        Else
            'ClientScript.RegisterStartupScript(Me.GetType(), "Alert", "alert('Can not delete this Record !');", True)
            lblError1.Visible = True
            lblError1.CssClass = "errorBox"
            lblError1.Text = "Can not delete this Record !"
        End If
 
    End Sub

    Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs)
        Dim sID As String = GridView1.DataKeys(e.RowIndex).Value
        sql = "Select * from eOFFICE_DEPARTMENT where Id = '" & sID & "' "
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            txt_Name_Abb.Text = ds.Tables(0).Rows(0).Item("Department_abb").ToString
            txt_Name_Dep.Text = ds.Tables(0).Rows(0).Item("Department_Desc").ToString
            If ds.Tables(0).Rows(0).Item("active_status").ToString = "Y" Then
                ckb_Department.Checked = True
            Else
                ckb_Department.Checked = False
            End If

            lblId.Text = ds.Tables(0).Rows(0).Item("ID").ToString
            btnDUpdate.Visible = True
            btnDSave.Visible = False
        End If

    End Sub

    Sub btnDUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDUpdate.Click
        If func.FixData(txt_Name_Abb.Text) = "" Then
            lblError1.Visible = True
            lblError1.CssClass = "errorBox"
            lblError1.Text = "Please enter department"
            'txt_Name_Abb.Text = ""
            txt_Name_Abb.Focus()
        ElseIf func.FixData(txt_Name_Dep.Text) = "" Then
            lblError1.Visible = True
            lblError1.CssClass = "errorBox"
            lblError1.Text = "Please enter department"
            'txt_Name_Dep.Text = ""
            txt_Name_Dep.Focus()
        ElseIf CheckDuplicate("eOFFICE_DEPARTMENT", "department_abb", func.FixData(txt_Name_Abb.Text), lblId.Text) = True Then
            lblError1.Visible = True
            lblError1.CssClass = "errorBox"
            lblError1.Text = "Please enter department  duplicate"
            'txt_Name_Abb.Text = ""
            txt_Name_Abb.Focus()
        ElseIf CheckDuplicate("eOFFICE_DEPARTMENT", "department_desc", func.FixData(txt_Name_Dep.Text), lblId.Text) = True Then
            lblError1.Visible = True
            lblError1.CssClass = "errorBox"
            lblError1.Text = "Please enter department desc duplicate"
            'txt_Name_Dep.Text = ""
            txt_Name_Dep.Focus()

        Else
            Try
                sql = "Update eOFFICE_DEPARTMENT "
                sql += "Set Department_abb= '" & func.FixData(txt_Name_Abb.Text) & "' "
                sql += ", Department_Desc = '" & func.FixData(txt_Name_Dep.Text) & "' "
                sql += ", Active_status = '" & IIf(ckb_Department.Checked = True, "Y", "N") & "'"
                sql += ", updated_by = '" & ppMember_Id & "' "
                sql += ", updated_date = (select GETDATE())"
                sql += " where Id = '" & lblId.Text & "'  "
                func.CmdSQL(sql)
                lblError1.CssClass = "successBox"
                lblError1.Text = "Update department has been add successfully."
                lblError1.Visible = True
                txt_Name_Dep.Text = ""
                txt_Name_Abb.Text = ""
                ckb_Department.Checked = False
                lblId.Text = ""
                Show_Data()
                btnDUpdate.Visible = False
                btnDSave.Visible = True
            Catch ex As Exception
                'ClientScript.RegisterStartupScript(Me.GetType(), "Alert", "alert('Can not update this Record!');", True)
                lblError1.Visible = True
                lblError1.CssClass = "errorBox"
                lblError1.Text = "Can not update this Record!"
            End Try
        End If
    End Sub

    Sub btnDSave2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDSave2.Click
        If func.FixData(txt_name_pos.Text) = "" Then
            errorbox2.Visible = True
            errorbox2.CssClass = "errorBox"
            errorbox2.Text = "Please enter position"
            ' txt_name_pos.Text = ""
            txt_name_pos.Focus()
        ElseIf CheckDuplicate("eOFFICE_POSITION", "Position_desc", func.FixData(txt_name_pos.Text), 0) = True Then
            errorbox2.Visible = True
            errorbox2.CssClass = "errorBox"
            errorbox2.Text = "Please enter position  duplicate"
            ' txt_name_pos.Text = ""
            txt_name_pos.Focus()
        Else
            Try
                sql = "INSERT INTO eOFFICE_POSITION(Position_desc,created_by,created_date) VALUES('" & func.FixData(Me.txt_name_pos.Text) & "'," & ppMember_Id & ",(select GETDATE()) )"
                func.CmdSQL(sql)
                errorbox2.CssClass = "successBox"
                errorbox2.Text = "New position has been add successfully."
                errorbox2.Visible = True
                txt_name_pos.Text = ""
                ckb_Position.Checked = False
                Show_Data_Position()
            Catch ex As Exception
                ClientScript.RegisterStartupScript(Me.GetType(), "Alert", "alert('Can not insert!');", True)
                errorbox2.CssClass = "errorBox"
                errorbox2.Text = "Can not insert!"
                errorbox2.Visible = True

            End Try
        End If
    End Sub

    Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        GridView2.PageIndex = e.NewPageIndex
        Show_Data_Position()
    End Sub
    Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs)
        Dim sID As String = GridView2.DataKeys(e.RowIndex).Value
        sql = "Select id from eOFFICE_USER where Position_id = '" & sID & "' "
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count = 0 Then
            sql = "Delete  eOFFICE_POSITION where id = '" & sID & "'"
            func.CmdSQL(sql)
            errorbox2.CssClass = "successBox"
            errorbox2.Text = "Delete position has been add successfully."
            errorbox2.Visible = True
            Show_Data_Position()
        Else
            ' ClientScript.RegisterStartupScript(Me.GetType(), "Alert", "alert('Can not delete this Record !');", True)
            errorbox2.CssClass = "errorBox"
            errorbox2.Text = "Can not delete this Record !"
            errorbox2.Visible = True
        End If

    End Sub

    Sub GridView2_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs)
        Dim sID As String = GridView2.DataKeys(e.RowIndex).Value
        sql = "Select * from eOFFICE_POSITION where id = '" & sID & "' "
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            txt_name_pos.Text = ds.Tables(0).Rows(0).Item("Position_desc").ToString
            lblId_pos.Text = ds.Tables(0).Rows(0).Item("ID").ToString
            If ds.Tables(0).Rows(0).Item("active_status").ToString = "Y" Then
                ckb_Position.Checked = True
            Else
                ckb_Position.Checked = False
            End If
            ' Dl_Dep.SelectedValue = ds.Tables(0).Rows(0).Item("Department_Id").ToString

            btnDUpdate2.Visible = True
            btnDSave2.Visible = False
        End If
    End Sub
    Sub btnDUpdate2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDUpdate2.Click
        If func.FixData(txt_name_pos.Text) = "" Then
            errorbox2.Visible = True
            errorbox2.CssClass = "errorBox"
            errorbox2.Text = "Please enter position"
            'txt_name_pos.Text = ""
            txt_name_pos.Focus()
        ElseIf CheckDuplicate("eOFFICE_POSITION", "Position_desc", func.FixData(txt_name_pos.Text), lblId_pos.Text) = True Then
            errorbox2.Visible = True
            errorbox2.CssClass = "errorBox"
            errorbox2.Text = "Please enter position  duplicate"
            'txt_name_pos.Text = ""
            txt_name_pos.Focus()
        Else
            Try
                sql = "Update eOFFICE_POSITION "
                sql += "Set Position_Desc= '" & func.FixData(txt_name_pos.Text) & "' "
                sql += ", Active_status = '" & IIf(ckb_Position.Checked = True, "Y", "N") & "'"
                sql += ", updated_by = '" & ppMember_Id & "' "
                sql += ", updated_date = (select GETDATE())"
                sql += " where Id = '" & lblId_pos.Text & "'  "
                func.CmdSQL(sql)
                errorbox2.CssClass = "successBox"
                errorbox2.Text = "Update position has been add successfully."
                errorbox2.Visible = True
                txt_name_pos.Text = ""
                ckb_Position.Checked = False
                Show_Data_Position()
                btnDUpdate2.Visible = False
                btnDSave2.Visible = True
            Catch ex As Exception
                'ClientScript.RegisterStartupScript(Me.GetType(), "Alert", "alert('Can not update this Record!');", True)
                errorbox2.CssClass = "errorBox"
                errorbox2.Text = "Can not update this Record!"
                errorbox2.Visible = True
            End Try
        End If
    End Sub
    Function DepId(ByVal name As String) As String
        DepId = ""
        Dim SQL As String = ""
        SQL = "SELECT     Id"
        SQL &= " FROM         eOFFICE_DEPARTMENT"
        SQL &= " Where Department_Desc = '" & name & "'"
        Dim da As New SqlDataAdapter(SQL, MyConn)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            DepId = ds.Tables(0).Rows(0).Item(0).ToString()
        End If
    End Function

End Class
