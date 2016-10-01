Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.Services
Imports Telerik.Web.UI

Partial Public Class WebForm3
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Support-TicketConnectionString").ConnectionString)
    Dim Cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("state") = Nothing Then
            Response.Write("<script>alert('Will have to login before')</script>")
            Response.Write("<script>window.location.href='Login.aspx';</script>")
        End If
        If Not Page.IsPostBack Then
            RadGrid2.DataSource = Data()
            RadGrid2.DataBind()
        End If
    End Sub
    <WebMethod()> _
    Public Shared Function GetAutoCompleteData(ByVal username As String) As List(Of String) 'function autocomplete project
        Dim result As New List(Of String)()
        Using con As New SqlConnection("Data Source=SCOREDB01;Initial Catalog=Support-Ticket;Persist Security Info=True;User ID=sa;Password=1qaz@WSX")
            Using cmd As New SqlCommand("select project_code from TICKET_PROJECT where project_code LIKE '%'+@SearchText+'%'", con)
                con.Open()
                cmd.Parameters.AddWithValue("@SearchText", username)
                Dim dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    result.Add(dr("project_code").ToString())
                End While
                Return result
            End Using
        End Using
    End Function
    <WebMethod()> _
    Public Shared Function GetAutoCompleteData1(ByVal username As String) As List(Of String) 'function autocomplete respon
        Dim result As New List(Of String)()
        Using con As New SqlConnection("Data Source=SCOREDB01;Initial Catalog=Support-Ticket;Persist Security Info=True;User ID=sa;Password=1qaz@WSX")
            Using cmd As New SqlCommand("select respon_name from TICKET_RESPONSIBILITY where respon_name LIKE '%'+@SearchText1+'%'", con)
                con.Open()
                cmd.Parameters.AddWithValue("@SearchText1", username)
                Dim dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    result.Add(dr("respon_name").ToString())
                End While
                Return result
            End Using
        End Using
    End Function
    Private Function Data() As DataSet 'function select data for gridview role
        Dim text As String = "SELECT ROW_NUMBER() OVER(ORDER BY role_id DESC) AS Row,role_id,create_by,create_on,update_by,update_on,role_code,role_name FROM TICKET_ROLE "
        Dim cmd As New SqlCommand(text, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        con.Close()
        Return ds
    End Function
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click 'button add respon on gridview
        For i As Integer = 0 To RadGrid1.Items.Count - 1
            Dim strvalue As String = RadGrid1.Items(i).Item("column").Text
            If txtSearch1.Text = strvalue Then 'check item select repeat with gridview 
                Session("chkgridr") = 1
                Exit For
            End If
            Session("chkgridr") = 2
        Next

        If Session("chkgridr") = 1 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Your infomation is repeat');", True)
            txtSearch1.Text = ""
            Return
        Else

            Dim sq As String = "Select respon_name from TICKET_RESPONSIBILITY"
            Dim cmd1 As New SqlCommand(sq, con)
            Dim da As New SqlDataAdapter(cmd1)
            Dim ds As New DataSet()
            da.Fill(ds)
            Dim idsel As String

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                idsel = (ds.Tables(0).Rows(i).Item("respon_name").ToString) 'check item select repeat with database 
                If txtSearch1.Text = idsel Then
                    Session("valr") = txtSearch1.Text
                Else
                    Session("novalr") = txtSearch1.Text
                End If
            Next

            If Session("valr") <> "" Then 'add item to gridview
                Dim dt As New DataTable
                dt.Columns.Add("column")
                Dim dr As DataRow

                For i1 As Integer = 0 To RadGrid1.Items.Count - 1
                    dr = dt.NewRow
                    dr.Item("column") = RadGrid1.Items(i1).Item("column").Text
                    dt.Rows.Add(dr)
                Next
                dr = dt.NewRow
                dr.Item("column") = Session("valr")
                dt.Rows.Add(dr)
                RadGrid1.DataSource = dt
                RadGrid1.DataBind()
                Session("dtr1") = dt
            ElseIf Session("novalr") <> "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Your infomation is repeat');", True)
                txtSearch1.Focus()
            End If
            txtSearch1.Text = ""
            Session("valr") = ""
            Session("novalr") = ""
        End If
    End Sub
    Public Function DataSearchgridproject(ByVal s1 As String) As DataSet 'search project from edit role
        Dim sq As String
        sq = "select ROW_NUMBER() OVER(ORDER BY id DESC) AS Row,tp.id,tp.project_code,tp.project_name,tp.project_desc from TICKET_PROJECT tp inner join TICKET_PROJECT_ROLE tpr on tp.id = tpr.project_id inner join TICKET_ROLE tr on tr.role_id = tpr.role_id where"
        sq += " tr.role_id = '" & s1 & "'"
        Dim cmd As New SqlCommand(sq, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        con.Close()
        Return ds
    End Function
    Protected Sub RadGrid1_PageIndexChanged(source As Object, e As GridPageChangedEventArgs) Handles RadGrid1.PageIndexChanged
        RadGrid1.CurrentPageIndex = e.NewPageIndex
        RadGrid1.DataSource = txtSearch1.Text
        RadGrid1.DataBind()
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For i As Integer = 0 To RadGrid3.Items.Count - 1
            Dim strvalue As String = RadGrid3.Items(i).Item("column").Text
            If txtSearch.Text = strvalue Then 'check item in gridview project repeat
                Session("chkgridrr") = 1
                Exit For
            End If
            Session("chkgridrr") = 2
        Next

        If Session("chkgridrr") = 1 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Your infomation is repeat');", True)
            txtSearch.Text = ""
            Return
        Else
            Dim sq As String = "Select project_code from TICKET_PROJECT"
            Dim cmd1 As New SqlCommand(sq, con)
            Dim da As New SqlDataAdapter(cmd1)
            Dim ds As New DataSet()
            da.Fill(ds)
            Dim idsel As String

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                idsel = (ds.Tables(0).Rows(i).Item("project_code").ToString)
                If txtSearch.Text = idsel Then 'check project code selected repeat with database ..
                    Session("valrr") = txtSearch.Text
                Else
                    Session("novalrr") = txtSearch.Text
                End If
            Next

            If Session("valrr") <> "" Then 'add item in gridview project
                Dim dt As New DataTable
                dt.Columns.Add("column")
                Dim dr As DataRow

                For i1 As Integer = 0 To RadGrid3.Items.Count - 1
                    dr = dt.NewRow
                    dr.Item("column") = RadGrid3.Items(i1).Item("column").Text
                    dt.Rows.Add(dr)
                Next
                dr = dt.NewRow
                dr.Item("column") = Session("valrr")
                dt.Rows.Add(dr)
                RadGrid3.DataSource = dt
                RadGrid3.DataBind()
                Session("dtr2") = dt
            ElseIf Session("novalrr") <> "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Your infomation is repeat');", True)
                txtSearch.Focus()
            End If
            txtSearch.Text = ""
            Session("valrr") = ""
            Session("novalrr") = ""
        End If
    End Sub
    Protected Sub RadGrid3_PageIndexChanged(source As Object, e As GridPageChangedEventArgs) Handles RadGrid3.PageIndexChanged
        RadGrid3.CurrentPageIndex = e.NewPageIndex
        RadGrid3.DataSource = txtSearch.Text
        RadGrid3.DataBind()
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        con.Open()
        Dim chn As String 'find code and name
        chn = "Select role_code,role_name from TICKET_ROLE where role_code = '" & txtcode.Text & "'or role_name = '" & txtname.Text & "'"
        Dim cmd As New SqlCommand(chn, con)

        Dim chk As SqlDataReader = cmd.ExecuteReader
        If chk.Read = True Then 'check code and name repeat
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('This Rolecode or Rolename is repeat.');", True)
            txtname.Text = ""
        Else
            chk.Close()
            Dim chg1 As Integer = RadGrid1.Items.Count
            Dim chg3 As Integer = RadGrid3.Items.Count
            If txtcode.Text = "" Or txtname.Text = "" Or chg1 = 0 Or chg3 = 0 Then 'check textbox = ""
                ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "AlertBox", "alert('Information is not complete.');", True)
            Else
                'insert role
                Dim sql As String = "Insert Into TICKET_ROLE (create_by,create_on,role_code,role_name) " & _
                                   "Values('" & Session("state") & "',Getdate(),'" & txtcode.Text & "','" & txtname.Text & "')"
                If con.State = ConnectionState.Closed Then con.Open()
                With cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Connection = con
                    .ExecuteNonQuery()
                End With
                For i As Integer = 0 To RadGrid1.Items.Count - 1
                    Try
                        Dim strvalue As String = RadGrid1.Items(i).Item("column").Text 'insert item in gridview respon

                        Dim sql1 As String = "insert into TICKET_ROLE_RESPONSIBILITY(respon_id,role_id) " & _
                                      "Values((select respon_id from TICKET_RESPONSIBILITY where respon_name = '" & strvalue & "'),(select role_id from ticket_role where role_name = '" & txtname.Text & "'))"
                        With cmd
                            .CommandType = CommandType.Text
                            .CommandText = sql1
                            .Connection = con
                            .ExecuteNonQuery()
                        End With
                    Catch ex As Exception
                        ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "AlertBox", "alert('Error! Please try again.');", True)
                    End Try
                Next

                For i1 As Integer = 0 To RadGrid3.Items.Count - 1
                    Try
                        Dim strvalue1 As String = RadGrid3.Items(i1).Item("column").Text 'insert item in gridview project

                        Dim sql2 As String = "insert into TICKET_PROJECT_ROLE(project_id,role_id) " & _
                                            "Values((select id from TICKET_PROJECT where project_code = '" & strvalue1 & "'),(select role_id from ticket_role where role_name = '" & txtname.Text & "'))"
                        With cmd
                            .CommandType = CommandType.Text
                            .CommandText = sql2
                            .Connection = con
                            .ExecuteNonQuery()
                        End With
                    Catch ex As Exception
                        ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "AlertBox", "alert('Error! Please try again.');", True)
                    End Try
                Next
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Insert Complete.'); window.location='" + Request.ApplicationPath + "/Role.aspx';", True)
                con.Close()
            End If
        End If
    End Sub

    Protected Sub RadGrid2_EditCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid2.EditCommand
        Dim rid As Label = e.Item.FindControl("Label9") 'edit button girdview Role
        Session("rid") = rid.Text
        'RadGrid4.DataSource = DataSearchgridproject("24")
        'RadGrid4.DataBind()
        'RadGrid3.Visible = False
        RadGrid2.DataSource = Data()
        RadGrid2.DataBind()
    End Sub

    Protected Sub RadGrid2_DeleteCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid2.DeleteCommand
        con.Open()
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
            If e.CommandName = "Delete" Then
                Dim rid As Label = e.Item.FindControl("Label9")
                Dim sq As String = "select TICKET_ROLE_RESPONSIBILITY.role_id from TICKET_ROLE_RESPONSIBILITY join TICKET_GROUP_ROLE on TICKET_ROLE_RESPONSIBILITY.role_id = TICKET_GROUP_ROLE.role_id"
                Dim cmd1 As New SqlCommand(sq, con)
                Dim da As New SqlDataAdapter(cmd1)
                Dim ds As New DataSet()
                da.Fill(ds)
                Dim idsel As String
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    idsel = (ds.Tables(0).Rows(i).Item("role_id").ToString) 'check role_id select using in group role and respon
                    If rid.Text = idsel Then
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Cannot delete! This staff using in other table.'); window.location='" + Request.ApplicationPath + "/Role.aspx';", True)
                        Return
                    End If
                Next
                'delete role id in TICKET_GROUP_ROLE
                Dim sql As String = "DELETE FROM TICKET_GROUP_ROLE Where role_id = '" + rid.Text + "'"
                With Cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Connection = con
                    .ExecuteNonQuery()
                End With
                'delete role id in TICKET_PROJECT_ROLE
                Dim sql1 As String = "DELETE FROM TICKET_PROJECT_ROLE Where role_id = '" + rid.Text + "'"
                With Cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql1
                    .Connection = con
                    .ExecuteNonQuery()
                End With
                'delete role id in TICKET_ROLE_RESPONSIBILITY
                Dim sql2 As String = "DELETE FROM TICKET_ROLE_RESPONSIBILITY Where role_id = '" + rid.Text + "'"
                With Cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql2
                    .Connection = con
                    .ExecuteNonQuery()
                End With
                'delete role id in TICKET_ROLE
                Dim sql3 As String = "DELETE FROM TICKET_ROLE Where role_id = '" + rid.Text + "'"
                With Cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql3
                    .Connection = con
                    .ExecuteNonQuery()
                End With
                con.Close()           
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Delete Complete.'); window.location='" + Request.ApplicationPath + "/Role.aspx';", True)
            End If
        End If
    End Sub

    Protected Sub RadGrid2_UpdateCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid2.UpdateCommand
        con.Open()
        Dim f As TextBox = e.Item.FindControl("Textbox1") 'find textbox in template gridview
        Dim ff As TextBox = e.Item.FindControl("Textbox2")
        Dim ff1 As TextBox = e.Item.FindControl("Textbox3")
        Dim ff2 As TextBox = e.Item.FindControl("Textbox4")
        Dim ff3 As TextBox = e.Item.FindControl("Textbox5")
        Dim ff4 As TextBox = e.Item.FindControl("Textbox6")
        Dim ff5 As TextBox = e.Item.FindControl("Textbox7")
        If ff3.Text = "" Or ff5.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Information not complete.'); window.location='" + Request.ApplicationPath + "/Role.aspx';", True)
        Else
            Dim chn As String
            chn = "Select role_name from TICKET_ROLE where role_name = '" & ff5.Text & "'"
            Dim cmd As New SqlCommand(chn, con)
            Dim chk As SqlDataReader = cmd.ExecuteReader
            If chk.HasRows = False Then 'check role name not repeat and update
                chk.Close()
                Dim sql As String = "UPDATE TICKET_ROLE SET update_by = '" + ff1.Text + "',update_on = GetDate(),role_name = '" + ff5.Text + "' where role_id = " + f.Text + ""
                With cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Connection = con
                    .ExecuteNonQuery()
                End With
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Update Complete.'); window.location='" + Request.ApplicationPath + "/Role.aspx';", True)
            Else
                chk.Close()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Update repeat.'); window.location='" + Request.ApplicationPath + "/Role.aspx';", True)
            End If
        End If

    End Sub

    Protected Sub RadGrid2_PageIndexChanged(source As Object, e As GridPageChangedEventArgs) Handles RadGrid2.PageIndexChanged
        RadGrid2.CurrentPageIndex = e.NewPageIndex
        RadGrid2.DataSource = Data()
        RadGrid2.DataBind()
    End Sub

    Protected Sub RadGrid2_CancelCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid2.CancelCommand
        RadGrid2.DataSource = Data()
        RadGrid2.DataBind()
    End Sub

    Protected Sub RadGrid1_DeleteCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid1.DeleteCommand
        Dim item As GridDataItem = e.Item 'delete item in gridview respon
        Dim ID As String = item("column").Text
        Dim table As DataTable = CType(Session("dtr1"), DataTable)
        If table IsNot Nothing Then
            table.Rows(item.ItemIndex).Delete()
            table.AcceptChanges()
            RadGrid1.DataSource = table
            RadGrid1.DataBind()
        End If
    End Sub

    Protected Sub RadGrid3_DeleteCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid3.DeleteCommand
        Dim item As GridDataItem = e.Item 'delete item in gridview project
        Dim ID As String = item("column").Text
        Dim table As DataTable = CType(Session("dtr2"), DataTable)
        If table IsNot Nothing Then
            table.Rows(item.ItemIndex).Delete()
            table.AcceptChanges()
            RadGrid3.DataSource = table
            RadGrid3.DataBind()
        End If
    End Sub

    Protected Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        Response.Redirect("Role.aspx")
    End Sub
    Public Sub ClearTextBox(ByVal root As Control)
        For Each ctrl As Control In root.Controls
            ClearTextBox(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            End If
        Next ctrl
    End Sub
End Class