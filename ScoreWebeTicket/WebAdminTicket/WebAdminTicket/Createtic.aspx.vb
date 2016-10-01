Imports Telerik.Web.UI
Imports System.Data.SqlClient
Imports System.IO

Public Class WebForm5
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Support-TicketConnectionString").ConnectionString)
    Dim Cmd As New SqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      
    End Sub

    Public Function Max_Ticket_Code(ByVal _max As String) As String 'ฟังก์ชั่นสร้าง ticket id อัตโนมัส
        Dim _maxx As String = ""
        Dim _MAX_TIC As String = "select convert(varchar(50),MAX(convert(int,SUBSTRING(ticket_code,2,LEN(ticket_code))))+1) from TICKET_TICKET"
        Dim cmd As New SqlCommand(_MAX_TIC, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        da.Fill(dt)
        con.Close()
        _maxx = dt.Rows(0)(0).ToString()
        Return _maxx

    End Function
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtdesc.Text = "" Or txtmail.Text = "" Or txtperson.Text = "" Or txtrname.Text = "" Or txtrtell.Text = "" Or txttell.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Information is not complete');", True)
        Else
            Dim Tickit_Code As String = "select convert(varchar(50),MAX(convert(int,SUBSTRING(ticket_code,2,LEN(ticket_code))))+1) from TICKET_TICKET"
            Dim _MaxTic As String = "T"
            _MaxTic += Max_Ticket_Code("")

            con.Open()
            Dim a As String
            a = Server.MapPath("~/TICKETFILE/" + Date.Now.ToLongDateString)
            Dim di As DirectoryInfo = New DirectoryInfo(a)
            If Directory.Exists(a) = False Then 'เช็คว่ามีโฟรเดอร์เก็บไฟล์อยู่แล้วหรือไม่
                di.Create()
                Dim countfile As Integer = 1
                For Each f As UploadedFile In RadUpload1.UploadedFiles 'อัพโหลดไฟล์ตามจำนวนจาก Radupload
                    f.SaveAs(a & "/" & f.GetName(), True)

                    Dim su As Integer
                    su = f.GetName().Count

                    Dim su1 As String
                    su1 = (Microsoft.VisualBasic.Right(su, 4))

                    My.Computer.FileSystem.GetFiles(a)

                    Dim check As String = _
                    System.IO.Path.GetExtension(f.GetName())


                    Dim ch As String
                    ch = (Microsoft.VisualBasic.Right(check, 3))
                    Session(countfile & "ch") = ch
                    Session(countfile & "fname") = f.GetName()
                    countfile += 1
                Next


                Dim sql As String = "insert into TICKET_TICKET(create_by,create_on,account_id,project_id,branch_id,contact_name,contact_tell,contact_email,raise_name,raise_tell,ticket_code,ticket_description,statusticket_id,statuscus_id,branch_sla) " & _
                        "  values('" & Session("state") & "',Getdate(),(select account_id from ticket_account where account_name = '" & DropDownList4.Text & "'),(select id from ticket_project where project_code = '" & DropDownList1.Text & "'),(select branch_id from ticket_branch where branch_name = '" & DropDownList2.Text & "'),'" & txtperson.Text & "','" & txttell.Text & "','" & txtmail.Text & "','" & txtrname.Text & "','" & txtrtell.Text & "','" & _MaxTic & "','" & txtdesc.Text & "','" & 1 & "','" & 2 & "',(select branch_sla from ticket_branch where branch_id = '" & DropDownList2.SelectedValue & "'))"
                With Cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Connection = con
                    .ExecuteNonQuery()
                End With


                If countfile <= 1 Then
                    Session("pathfile") = ""
                    Dim sql1 As String = "insert into TICKET_ISSUE_ATTACH_FILE(create_by,create_on,file_name,file_extention,ticket_id,path_folder) " & _
                                "  values('" & Session("state") & "',Getdate(),'','',(select ticket_id from TICKET_TICKET where contact_name = '" & txtperson.Text & "'),'" & Session("pathfile") & "')"
                    With Cmd
                        .CommandType = CommandType.Text
                        .CommandText = sql1
                        .Connection = con
                        .ExecuteNonQuery()
                    End With
                Else
                    Session("pathfile") = Date.Now.ToLongDateString
                    For i As Integer = 1 To countfile - 1
                        Dim sql1 As String = "insert into TICKET_ISSUE_ATTACH_FILE(create_by,create_on,file_name,file_extention,ticket_id,path_folder) " & _
                                "  values('" & Session("state") & "',Getdate(),'" & Session(i & "fname") & "','" & Session(i & "ch") & "',(select ticket_id from TICKET_TICKET where contact_name = '" & txtperson.Text & "'),'" & Session("pathfile") & "')"
                        With Cmd
                            .CommandType = CommandType.Text
                            .CommandText = sql1
                            .Connection = con
                            .ExecuteNonQuery()
                        End With
                    Next
                End If

            Else
                Dim countfile As Integer = 1
                For Each f As UploadedFile In RadUpload1.UploadedFiles
                    f.SaveAs(a & "/" & f.GetName(), True)

                    Dim su As Integer
                    su = f.GetName().Count

                    Dim su1 As String
                    su1 = (Microsoft.VisualBasic.Right(su, 4))

                    My.Computer.FileSystem.GetFiles(a)

                    Dim check As String = _
                    System.IO.Path.GetExtension(f.GetName())


                    Dim ch As String
                    ch = (Microsoft.VisualBasic.Right(check, 3))
                    Session(countfile & "ch") = ch
                    Session(countfile & "fname") = f.GetName()
                    countfile += 1
                Next

                Dim sql As String = "insert into TICKET_TICKET(create_by,create_on,account_id,project_id,branch_id,contact_name,contact_tell,contact_email,raise_name,raise_tell,ticket_code,ticket_description,statusticket_id,statuscus_id,branch_sla) " & _
                        "  values('" & Session("state") & "',Getdate(),(select account_id from ticket_account where account_name = '" & DropDownList4.Text & "'),(select id from ticket_project where project_code = '" & DropDownList1.Text & "'),(select branch_id from ticket_branch where branch_name = '" & DropDownList2.SelectedItem.ToString & "' and branch_id = '" & DropDownList2.SelectedValue & "'),'" & txtperson.Text & "','" & txttell.Text & "','" & txtmail.Text & "','" & txtrname.Text & "','" & txtrtell.Text & "','" & _MaxTic & "','" & txtdesc.Text & "','" & 1 & "','" & 2 & "',(select branch_sla from ticket_branch where branch_id = '" + DropDownList2.SelectedValue + "'))"
                With Cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Connection = con
                    .ExecuteNonQuery()
                End With

                If countfile < 1 Then
                    Session("pathfile") = ""
                    Dim sql1 As String = "insert into TICKET_ISSUE_ATTACH_FILE(create_by,create_on,file_name,file_extention,ticket_id,path_folder) " & _
                                "  values('" & Session("state") & "',Getdate(),'','',(select ticket_id from TICKET_TICKET where contact_name = '" & txtperson.Text & "'),'" & Session("pathfile") & "')"
                    With Cmd
                        .CommandType = CommandType.Text
                        .CommandText = sql1
                        .Connection = con
                        .ExecuteNonQuery()
                    End With
                Else
                    Session("pathfile") = Date.Now.ToLongDateString
                    For i As Integer = 1 To countfile - 1
                        Dim sql1 As String = "insert into TICKET_ISSUE_ATTACH_FILE(create_by,create_on,file_name,file_extention,ticket_id,path_folder) " & _
                                "  values('" & Session("state") & "',Getdate(),'" & Session(i & "fname") & "','" & Session(i & "ch") & "',(select ticket_id from TICKET_TICKET where ticket_code = '" & _MaxTic & "'),'" & Session("pathfile") & "')"
                        With Cmd
                            .CommandType = CommandType.Text
                            .CommandText = sql1
                            .Connection = con
                            .ExecuteNonQuery()
                        End With
                    Next
                End If

            End If

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Insert Complete');window.location='" + Request.ApplicationPath + "/Createtic.aspx';", True)
            con.Close()

        End If

    End Sub
    Protected Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        Response.Redirect("Createtic.aspx")
    End Sub
    Public Sub ClearTextBox(ByVal root As Control)
        For Each ctrl As Control In root.Controls
            ClearTextBox(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            End If
        Next ctrl
    End Sub
    Protected Sub DropDownList4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList4.SelectedIndexChanged

        Session("ddvalue") = DropDownList4.SelectedValue
        DropDownList1.DataSource = projectcode(Session("ddvalue"))
        DropDownList1.DataTextField = "project_code"
        DropDownList1.DataValueField = "project_code"
        DropDownList1.DataBind()

        DropDownList2.DataSource = branchname(Session("ddvalue"))
        DropDownList2.DataTextField = "branch_name"
        DropDownList2.DataValueField = "branch_id"
        DropDownList2.DataBind()

    End Sub
    Public Function projectcode(ByVal wh) As DataSet 'ฟังก์ชั่นดึงข้อมูลลง dropdrow project
        Dim ds As New DataSet
        Dim AccountName As String = ""
        Dim sql As String = "select project_code from TICKET_PROJECT where account_id = (select account_id from TICKET_ACCOUNT where account_name = '" & wh & "')"
        Dim cmd As New SqlCommand(sql, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(ds)
        con.Close()
        Return ds
    End Function
    Public Function branchname(ByVal wh) As DataSet 'ฟังก์ชั่นดึงข้อมูลลง dropdrow branch
        Dim ds As New DataSet
        Dim sql As String = "select branch_name,branch_id from TICKET_BRANCH where account_id = (select account_id from TICKET_ACCOUNT where account_name = '" & wh & "')"
        Dim cmd As New SqlCommand(sql, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(ds)
        con.Close()
        Return ds
    End Function
    Protected Sub txtrtell_TextChanged(sender As Object, e As EventArgs) Handles txtrtell.TextChanged
        If IsNumeric(txtrtell.Text) = False Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Number only');", True)
            txtrtell.Text = ""
        End If
    End Sub
    Protected Sub txttell_TextChanged(sender As Object, e As EventArgs) Handles txttell.TextChanged
        If IsNumeric(txttell.Text) = False Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Number only');", True)
            txttell.Text = ""
        End If
    End Sub
End Class