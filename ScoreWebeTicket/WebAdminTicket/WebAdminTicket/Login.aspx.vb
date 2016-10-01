Imports System.Data.SqlClient
Public Class WebForm6
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Support-TicketConnectionString").ConnectionString)
    Protected Sub Page_Load(sender As Object, e As EventArgs)
        If Not Page.IsPostBack = True Then
            If Session("state") <> "" Then 'check username login 
                Dim cmd As New SqlCommand
                Dim rd As SqlDataReader
                cmd.Connection = con
                con.Open()
                cmd.CommandText = "select username,status_staff from TICKET_STAFF where username = '" & Session("state") & "'"
                rd = cmd.ExecuteReader
                If rd.HasRows = True Then
                    rd.Close()
                    Response.Redirect("Default.aspx")
                End If
                con.Close()
            End If
        End If
    End Sub
    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles btnlogin.Click

        'check input symbol on textbox user and password
        Dim user As String = System.Text.RegularExpressions.Regex.Replace(txtuser.Text, "[^a-zA-Z0-9]", "").Replace("<", "").Replace(">", "")
        Dim pass As String = System.Text.RegularExpressions.Regex.Replace(txtpass.Text, "[^a-zA-Z0-9]", "").Replace("<", "").Replace(">", "")

        'check username is Active
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "select username,pwd from TICKET_STAFF where username = '" & user & "' and pwd = '" & pass & "' and active = 'Y'"
        rd = cmd.ExecuteReader

        If rd.HasRows Then
            rd.Close() 'find status staff online or offline
            Dim sqluser As String = "select status_staff from TICKET_STAFF where username = '" & user & "'"
            Dim cmduser As New SqlCommand(sqluser, con)
            Dim dauser As New SqlDataAdapter(cmduser)
            Dim dsuser As New DataSet()
            dauser.Fill(dsuser)
            If dsuser.Tables(0).Rows(0)(0).ToString = "2" Then '2 is offline and update status to 1 for online

                Dim sqlstate1 As String = "UPDATE TICKET_STAFF SET status_staff = '1' where username = '" + user + "'"
                Dim cmdstate1 As New SqlCommand
                With cmdstate1
                    .CommandType = CommandType.Text
                    .CommandText = sqlstate1
                    .Connection = con
                    .ExecuteNonQuery()
                End With
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('This User is online.');", True)
                Return
            End If
            'find usergroup id of username login
            Dim sql As String = "select usergroup_id from TICKET_STAFF where username = '" & txtuser.Text & "'"
            Dim cmd1 As New SqlCommand(sql, con)
            Dim da As New SqlDataAdapter(cmd1)
            Dim ds As New DataSet()
            da.Fill(ds)
            'find role id of usergroup id of username
            Dim sql1 As String = "select role_id from TICKET_GROUP_ROLE where usergroup_id = '" & ds.Tables(0).Rows(0)(0).ToString & "'"
            Dim cmd2 As New SqlCommand(sql1, con)
            Dim da1 As New SqlDataAdapter(cmd2)
            Dim ds1 As New DataSet()
            da1.Fill(ds1)
            'find respon id of role id of usergroup id of username
            Dim sql2 As String = "select respon_id from TICKET_ROLE_RESPONSIBILITY where role_id = '" & ds1.Tables(0).Rows(0)(0).ToString & "'"
            Dim cmd4 As New SqlCommand(sql2, con)
            Dim da2 As New SqlDataAdapter(cmd4)
            Dim ds2 As New DataSet()
            da2.Fill(ds2)

            'check respon 1-4 is admin can login website
            If ds2.Tables(0).Rows(0)(0).ToString = "1" Then
                Dim ch1 As String = ds2.Tables(0).Rows(0)(0).ToString
                If ds2.Tables(0).Rows(1)(0).ToString = "4" Then
                    Dim ch2 As String = ds2.Tables(0).Rows(1)(0).ToString
                    If ch1 = "1" And ch2 = "4" Then
                        Session("state") = txtuser.Text
                        Response.Redirect("Default.aspx")
                    Else
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Please try again.');", True)
                    End If
                Else
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "script", "alert('User not support')", True)
                End If
            ElseIf ds2.Tables(0).Rows(0)(0).ToString = "4" Then 'check respon 4-1 is admin can login website
                Dim ch1 As String = ds2.Tables(0).Rows(0)(0).ToString
                If ds2.Tables(0).Rows(1)(0).ToString = "1" Then
                    Dim ch2 As String = ds2.Tables(0).Rows(1)(0).ToString
                    If ch1 = "4" And ch2 = "1" Then
                        Session("state") = txtuser.Text
                        Response.Redirect("Default.aspx")
                    Else
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Please try again.');", True)
                    End If
                Else
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "script", "alert('User not support')", True)
                End If
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "script", "alert('User not support')", True)
            End If
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "script", "alert('Username of password wrong')", True)
        End If
    End Sub

    Private Sub WebForm6_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("statususer") = "2" Then 'update status staff to offline after logout 
            Dim sql As String = "UPDATE TICKET_STAFF SET status_staff = '2' where username = '" & Session("state") & "' "
            con.Open()
            Dim cmd As New SqlCommand(sql, con)
            With cmd
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = con
                .ExecuteNonQuery()
            End With
            Session("statususer") = ""
            Session("state") = ""
            con.Close()
        End If
    End Sub
End Class