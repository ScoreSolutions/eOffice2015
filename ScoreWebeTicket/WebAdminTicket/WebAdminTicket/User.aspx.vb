Imports System.Data.SqlClient
Imports Telerik.Web.UI
Partial Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Support-TicketConnectionString").ConnectionString)
    Dim Cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("state") = Nothing Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "AlertBox", "alert('Please Login.');", True)
            Response.Redirect("Login.aspx")
        End If
        If Not IsPostBack Then
            RadGrid1.DataSource = Data() 'get data() from function to gridview
            RadGrid1.DataBind()
        End If
    End Sub
    Private Function Data() As DataSet 'select table TICKET_STAFF
        Dim text As String = "SELECT ROW_NUMBER() OVER(ORDER BY id DESC) AS Row,id,username,staffname,position_name,active FROM TICKET_STAFF "
        Dim cmd As New SqlCommand(text, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        con.Close()
        Return ds
    End Function
    Protected Sub RadGrid1_PageIndexChanged(source As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGrid1.PageIndexChanged
        RadGrid1.CurrentPageIndex = e.NewPageIndex
        RadGrid1.DataSource = Data()
        RadGrid1.DataBind()
    End Sub
    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        con.Open()
        Dim chn As String 'check username repeat..
        chn = "Select username,staffname,status_staff from TICKET_STAFF where username = '" & txtname.Text & "'or staffname = '" & txtstaff.Text & "'"
        Dim cmd As New SqlCommand(chn, con)

        Dim chk As SqlDataReader = cmd.ExecuteReader
        If chk.Read = True Then 'check...
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Username or Staffname is repeat Please try again.');", True)
            txtname.Text = ""
            txtstaff.Text = ""
            Dim chn2 As String = ""
            If chn2 = "" Then
                chn2 = "select status_staff where username = '" & txtname.Text & "' and status_staff = '2'"
                Dim cmd2 As New SqlCommand(chn2, con)
                Dim chk2 As SqlDataReader = cmd.ExecuteReader
                If chk2.Read = True Then 'check status online or offline
                    MsgBox("sadass")
                End If
            End If
        Else
            chk.Close()
            If txtname.Text = "" Or txtpass.Text = "" Or txtconf.Text = "" Or txtstaff.Text = "" Or txtposition.Text = "" Or DropDownList1.SelectedItem.ToString = "Select Group" Then 'check select group
                ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "AlertBox", "alert('Information is not complete.');", True)
            ElseIf txtconf.Text = txtpass.Text Then
                Dim val4 As String = ""
                If CheckBox4.Checked = True Then 'check active selected or not
                    val4 = "Y"
                Else
                    val4 = "N"
                End If
                'insert new user 
                Dim sql As String = "Insert Into TICKET_STAFF(create_by,create_on,update_by,update_on,username,pwd,staffname,position_name,active,usergroup_id,status_staff) " & _
                    "  Values('" & "Admin" & "',Getdate(),'" & "Admin" & "',Getdate(),'" & Session("user") & "','" & txtpass.Text & "','" & txtstaff.Text & "','" & txtposition.Text & "','" & val4 & "',(select usergroup_id from TICKET_USER_GROUP where group_name = '" & DropDownList1.Text & "'),'2')"
                With cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Connection = con
                    .ExecuteNonQuery()
                End With
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Save Complete.'); window.location='" + Request.ApplicationPath + "/User.aspx';", True)
                con.Close()
            Else
                Label15.Text = "Pass not match"
                txtconf.Focus()
            End If
        End If

    End Sub
    Protected Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        Response.Redirect("User.aspx")
    End Sub
    Public Sub ClearTextBox(ByVal root As Control)
        For Each ctrl As Control In root.Controls
            ClearTextBox(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            End If
        Next ctrl
    End Sub
    Protected Sub RadGrid1_DeleteCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid1.DeleteCommand
        con.Open()
        Dim user_id As Label = e.Item.FindControl("Label9") 'find id user will delete
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
            If e.CommandName = "Delete" Then
                Dim sq As String = "Select TICKET_STAFF.id from TICKET_STAFF join TICKET_PROJECT on TICKET_STAFF.id = TICKET_PROJECT.staff_id"
                Dim cmd1 As New SqlCommand(sq, con)
                Dim da As New SqlDataAdapter(cmd1)
                Dim ds As New DataSet()
                da.Fill(ds)
                Dim idsel As String
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    idsel = (ds.Tables(0).Rows(i).Item("id").ToString)
                    If user_id.Text = idsel Then 'check user using in other table
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Cannot delete! This staff using in other table.'); window.location='" + Request.ApplicationPath + "/User.aspx';", True)
                        Return
                    End If
                Next
                'delete user
                Dim sql As String = "DELETE FROM TICKET_STAFF Where id = '" + user_id.Text + "'"
                With Cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Connection = con
                    .ExecuteNonQuery()
                End With
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Delete Complete.'); window.location='" + Request.ApplicationPath + "/User.aspx';", True)
            End If
        End If
    End Sub
    Protected Sub RadGrid1_EditCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid1.EditCommand
        RadGrid1.DataSource = Data()
        RadGrid1.DataBind()
    End Sub
    Protected Sub RadGrid1_UpdateCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid1.UpdateCommand
        con.Open()
        Dim f As TextBox = e.Item.FindControl("Textbox1") 'find data in textbox templete itemstyle
        Dim ff As TextBox = e.Item.FindControl("Textbox2")
        Dim ff1 As TextBox = e.Item.FindControl("Textbox3")
        Dim ff2 As TextBox = e.Item.FindControl("Textbox4")
        Dim chk1 As RadioButtonList = e.Item.FindControl("RadioButtonList1")

        If ff.Text = "" Or ff1.Text = "" Or ff2.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Information not complete'); window.location='" + Request.ApplicationPath + "/User.aspx';", True)
        Else
            Dim chn As String 'check data is repeat...
            chn = "Select staffname from TICKET_STAFF where staffname = '" & ff1.Text & "'"
            Dim cmd As New SqlCommand(chn, con)

            Dim chk As SqlDataReader = cmd.ExecuteReader
            If chk.HasRows = False Then 'can delete
                chk.Close()
                Dim sql As String = "UPDATE TICKET_STAFF SET staffname = '" + ff1.Text + "',position_name = '" + ff2.Text + "',active = '" + chk1.Text + "' where id = " + f.Text + ""
                With cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Connection = con
                    .ExecuteNonQuery()
                End With
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Update Complete.'); window.location='" + Request.ApplicationPath + "/User.aspx';", True)
            ElseIf chk1.Text <> "" Then 'check textbox update not empty and update...
                chk.Close()
                Dim sql As String = "UPDATE TICKET_STAFF SET active = '" + chk1.Text + "' where id = " + f.Text + ""
                With cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Connection = con
                    .ExecuteNonQuery()
                End With
                Response.Redirect("User.aspx")
            Else
                chk.Close()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Update Repeat.'); window.location='" + Request.ApplicationPath + "/User.aspx';", True)
            End If
        End If
    End Sub
    Protected Sub RadGrid1_CancelCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid1.CancelCommand
        RadGrid1.DataSource = Data()
        RadGrid1.DataBind()
    End Sub
    Protected Sub txtname_TextChanged(sender As Object, e As EventArgs) Handles txtname.TextChanged
        Dim chn As String 'chech textbox username repeat or not ......
        chn = "Select username from TICKET_STAFF where username = '" & txtname.Text & "'"
        Dim cmd As New SqlCommand(chn, con)
        con.Open()

        Dim chk As SqlDataReader = cmd.ExecuteReader
        If chk.Read = True Then
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "User is repeat"
            txtname.Text = ""
        Else
            Label1.ForeColor = Drawing.Color.Green
            Label1.Text = "User can use"
            con.Close()
        End If
        Session("user") = txtname.Text
    End Sub

    Protected Sub txtstaff_TextChanged(sender As Object, e As EventArgs) Handles txtstaff.TextChanged
        Dim chn As String 'check textbox staff name repeat or not...
        chn = "Select staffname from TICKET_STAFF where staffname = '" & txtstaff.Text & "'"
        Dim cmd As New SqlCommand(chn, con)
        con.Open()

        Dim chk As SqlDataReader = cmd.ExecuteReader
        If chk.Read = True Then
            Label16.ForeColor = Drawing.Color.Red
            Label16.Text = "Staff is repeat"
            txtname.Text = ""
        Else
            Label16.ForeColor = Drawing.Color.Green
            Label16.Text = "Staff can use"
            con.Close()
        End If
        Session("user") = txtname.Text
    End Sub

End Class