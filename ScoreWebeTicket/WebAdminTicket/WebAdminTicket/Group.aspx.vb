Imports System.Web.Services
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports Telerik.Web.UI

Public Class Group
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Support-TicketConnectionString").ConnectionString)
    Dim Cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("state") = Nothing Then
            Response.Write("<script>alert('Will have to login before')</script>")
            Response.Write("<script>window.location.href='Login.aspx';</script>")
        End If
        If Not Page.IsPostBack Then
            RadGrid1.DataSource = Data() 'bind data from table group to gridview1
            RadGrid1.DataBind()
        End If
    End Sub
    <WebMethod()> _
    Public Shared Function GetAutoCompleteData(ByVal username As String) As List(Of String) 'function auto complete textbox role
        Dim result As New List(Of String)()
        Using con As New SqlConnection("Data Source=SCOREDB01;Initial Catalog=Support-Ticket;Persist Security Info=True;User ID=sa;Password=1qaz@WSX")
            Using cmd As New SqlCommand("select role_name from TICKET_ROLE where role_name LIKE '%'+@SearchText+'%'", con)
                con.Open()
                cmd.Parameters.AddWithValue("@SearchText", username)
                Dim dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    result.Add(dr("role_name").ToString())
                End While
                Return result
            End Using
        End Using
    End Function
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.Open() 'check information repeat from role girdview
        For i As Integer = 0 To RadGrid2.Items.Count - 1
            Dim strvalue As String = RadGrid2.Items(i).Item("column").Text
         If txtSearch.Text = strvalue Then
                Session("chkgrid") = 1
                Exit For
            End If
            Session("chkgrid") = 2
        Next

        If Session("chkgrid") = 1 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Your information is repeat');", True)
            txtSearch.Text = ""
            Return
        Else

            Dim sq As String = "Select role_name from TICKET_ROLE"
            Dim cmd1 As New SqlCommand(sq, con)
            Dim da As New SqlDataAdapter(cmd1)
            Dim ds As New DataSet()
            da.Fill(ds)
            Dim idsel As String

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                idsel = (ds.Tables(0).Rows(i).Item("role_name").ToString) 'check information repeat with database from role girdview
                If txtSearch.Text = idsel Then
                    Session("val") = txtSearch.Text
                Else
                    Session("noval") = txtSearch.Text
                End If
            Next

            If Session("val") <> "" Then
                Dim dt As New DataTable
                dt.Columns.Add("column")
                Dim dr As DataRow

                For i1 As Integer = 0 To RadGrid2.Items.Count - 1
                    dr = dt.NewRow
                    dr.Item("column") = RadGrid2.Items(i1).Item("column").Text
                    dt.Rows.Add(dr)
                Next
                dr = dt.NewRow
                dr.Item("column") = Session("val")
                dt.Rows.Add(dr)
                RadGrid2.DataSource = dt
                RadGrid2.DataBind()
                Session("dtt") = dt
            ElseIf Session("noval") <> "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Your information is not complete');", True)
                txtSearch.Focus()
            End If
            txtSearch.Text = ""
            Session("val") = ""
            Session("noval") = ""
        End If
    End Sub
    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        con.Open()
        Dim chn As String
        chn = "Select group_code,group_name from TICKET_USER_GROUP where group_code = '" & txtcode.Text & "' or group_name = '" & txtname.Text & "'"
        Dim cmd As New SqlCommand(chn, con)

        Dim chk As SqlDataReader = cmd.ExecuteReader
        If chk.Read = True Then 'check groupcode repeat with database 
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('This Group code or Group name is repeat.');", True)
            txtcode.Text = ""
            txtname.Text = ""
        Else
            chk.Close()
            Dim chstr As Integer = RadGrid2.Items.Count

            If txtcode.Text = "" Or txtname.Text = "" Or chstr = 0 Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "AlertBox", "alert('Your infomation is not complete.');", True)
            Else 'insert group
                Dim sql As String = "Insert Into TICKET_USER_GROUP(create_by,create_on,group_code,group_name) " & _
                                   "Values('" & Session("state") & "',Getdate(),'" & txtcode.Text & "','" & txtname.Text & "')"
                With cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Connection = con
                    .ExecuteNonQuery()
                End With

                For i As Integer = 0 To RadGrid2.Items.Count - 1 'for insert information in gridview follow count
                    Try

                        Dim strvalue As String = RadGrid2.Items(i).Item("column").Text

                        Dim sql1 As String = "insert into TICKET_GROUP_ROLE(usergroup_id,role_id) " & _
                                      "Values((select usergroup_id from ticket_user_group where group_code = '" & txtcode.Text & "'),(select role_id from ticket_role where role_name = '" & strvalue & "'))"
                        With cmd
                            .CommandType = CommandType.Text
                            .CommandText = sql1
                            .Connection = con
                            .ExecuteNonQuery()
                        End With

                    Catch ex As Exception
                        ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "AlertBox", "alert('Duplicate Code.');", True)
                    End Try
                Next
                con.Close()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Insert Complete.'); window.location='" + Request.ApplicationPath + "/Group.aspx';", True)
            End If
        End If
    End Sub
    Private Function Data() As DataSet 'function get infomation from user group for bind to grid
        Dim text As String = "SELECT ROW_NUMBER() OVER(ORDER BY usergroup_id DESC) AS Row,usergroup_id,create_by,create_on,update_by,update_on,group_code,group_name FROM TICKET_USER_GROUP "
        Dim cmd As New SqlCommand(text, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        con.Close()
        Return ds
    End Function
    Protected Sub RadGrid1_EditCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid1.EditCommand
        RadGrid1.DataSource = Data()
        RadGrid1.DataBind()
    End Sub
    Protected Sub RadGrid1_DeleteCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid1.DeleteCommand
        con.Open() 'delete gridview item group selected
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
            If e.CommandName = "Delete" Then
                Dim gid As Label = e.Item.FindControl("Label19")
                Dim sq As String = "select TICKET_USER_GROUP.usergroup_id from TICKET_USER_GROUP join TICKET_STAFF on TICKET_USER_GROUP.usergroup_id = TICKET_STAFF.usergroup_id"
                Dim cmd1 As New SqlCommand(sq, con)
                Dim da As New SqlDataAdapter(cmd1)
                Dim ds As New DataSet()
                da.Fill(ds)
                Dim idsel As String
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1 'check group have user using 
                    idsel = (ds.Tables(0).Rows(i).Item("usergroup_id").ToString)
                    If gid.Text = idsel Then
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Cannot delete! This staff using in other table.'); window.location='" + Request.ApplicationPath + "/Group.aspx';", True)
                        Return
                    End If
                Next
                'can delete 
                Dim sql As String = "DELETE FROM TICKET_GROUP_ROLE Where usergroup_id = '" + gid.Text + "'"
                With Cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Connection = con
                    .ExecuteNonQuery()
                End With

                Dim sql1 As String = "DELETE FROM TICKET_USER_GROUP Where usergroup_id = '" + gid.Text + "'"
                With Cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql1
                    .Connection = con
                    .ExecuteNonQuery()
                End With
        con.Close()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Delete Complete.'); window.location='" + Request.ApplicationPath + "/Group.aspx';", True)
            End If
        End If
    End Sub
    Protected Sub RadGrid1_UpdateCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid1.UpdateCommand
        con.Open() 'update gridview group
        Dim la As TextBox = e.Item.FindControl("Textbox19")
        Dim f As TextBox = e.Item.FindControl("Textbox1")
        Dim ff As TextBox = e.Item.FindControl("Textbox2")
        Dim ff1 As TextBox = e.Item.FindControl("Textbox3")
        Dim ff3 As TextBox = e.Item.FindControl("Textbox5")
        Dim ff4 As TextBox = e.Item.FindControl("Textbox6")
        If ff3.Text = "" Or ff4.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Information not complete.'); window.location='" + Request.ApplicationPath + "/Group.aspx';", True)
        Else
            ff1.Text = Session("state")
            Dim chn As String
            chn = "Select group_name from TICKET_USER_GROUP where group_name = '" & ff4.Text & "'"
            Dim cmd As New SqlCommand(chn, con)
            Dim chk As SqlDataReader = cmd.ExecuteReader
            If chk.HasRows = False Then 'check update repeat
                chk.Close()
                Dim sql As String = "UPDATE TICKET_USER_GROUP SET update_by = '" + ff1.Text + "',update_on = GetDate(),group_code = '" + ff3.Text + "',group_name = '" + ff4.Text + "' where usergroup_id = '" + la.Text + "'"
                With cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Connection = con
                    .ExecuteNonQuery()
                End With
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Update Complete.'); window.location='" + Request.ApplicationPath + "/Group.aspx';", True)
            Else
                chk.Close()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Update repeat.'); window.location='" + Request.ApplicationPath + "/Group.aspx';", True)
            End If
        End If       
    End Sub
    Protected Sub RadGrid1_PageIndexChanged(source As Object, e As GridPageChangedEventArgs) Handles RadGrid1.PageIndexChanged
        RadGrid1.CurrentPageIndex = e.NewPageIndex
        RadGrid1.DataSource = Data()
        RadGrid1.DataBind()
    End Sub
    Protected Sub RadGrid1_CancelCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid1.CancelCommand
        RadGrid1.DataSource = Data()
        RadGrid1.DataBind()
    End Sub
    Protected Sub RadGrid2_DeleteCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid2.DeleteCommand
        Dim item As GridDataItem = e.Item 'delete gridview item role
        Dim ID As String = item("column").Text
        Dim table As DataTable = CType(Session("dtt"), DataTable)
        If table IsNot Nothing Then
            table.Rows(item.ItemIndex).Delete()
            table.AcceptChanges()
            RadGrid2.DataSource = table
            RadGrid2.DataBind()
        End If
    End Sub
    Protected Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        Response.Redirect("Group.aspx")
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