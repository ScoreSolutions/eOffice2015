Imports System.Data
Imports System.Data.SqlClient
Imports Newtonsoft
Imports Newtonsoft.Json
Imports System.Xml
Imports System.IO
Imports System.Net

Partial Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim objConn As New SqlConnection(ConfigurationManager.ConnectionStrings("Con-ticket").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        Try
            Dim Type As String = Request.QueryString("Type")
            Dim _id As String = Request.QueryString("ticket_id")
            Dim strSql As String

            Dim spname As String = ""
            Dim tres As String = ""
            Dim tsta As String = ""
            Dim tno As String = ""
            Dim ttid As String = ""
            Dim mail As String = ""
            Dim asby As String = ""
            Dim ason As String = ""
            Dim asto As String = ""
            Dim astoMA As String = ""
            Dim asres As String = ""
            Dim reso As String = ""
            Dim cusname As String = ""
            Dim cusphone As String = ""
            Dim cusmail As String = ""
            Dim tkid As String = ""
            Dim stau As String = ""
            Dim state As String = ""

            spname = Request.QueryString("spn")
            tres = Request.QueryString("tr")
            tsta = Request.QueryString("ts")
            tno = Request.QueryString("tn")
            ttid = Request.QueryString("ttid")

            mail = Request.QueryString("mail")

            asby = Request.QueryString("asby")
            ason = Request.QueryString("ason")
            asto = Request.QueryString("asto")
            asres = Request.QueryString("asres")
            stau = Request.QueryString("stau")

            astoMA = Request.QueryString("astoMA")

            reso = Request.QueryString("reso")
            cusname = Request.QueryString("cusname")
            cusphone = Request.QueryString("cusphone")
            cusmail = Request.QueryString("cusmail")
            tkid = Request.QueryString("tkid")
            state = Request.QueryString("state")

            Try
                If objConn.State = ConnectionState.Closed Then objConn.Open()
                '---------------------------------- Query Command ------------------------------------
                Dim objAdapter As New SqlDataAdapter(strSql, objConn)
                Dim Ds As New DataSet
                Dim strResult As String = String.Empty

                Select Case Type
                    Case "user" 'MainAcitity.class used for login
                        strSql = "Select username,pwd from TICKET_STAFF where active = 'Y'"
                        objAdapter = New SqlDataAdapter(strSql, objConn)
                        objAdapter.Fill(Ds, "id")
                        strResult = JsonConvert.SerializeObject(Ds.Tables("id"), Newtonsoft.Json.Formatting.Indented)

                    Case "specialist" 'Mainmenu.class used for check staff of project
                        strSql = "select distinct s.username from TICKET_STAFF s inner join TICKET_PROJECT tp on tp.staff_id=s.id"
                        objAdapter = New SqlDataAdapter(strSql, objConn)
                        objAdapter.Fill(Ds, "id")
                        strResult = JsonConvert.SerializeObject(Ds.Tables("id"), Newtonsoft.Json.Formatting.Indented)

                    Case "ticket" 'Menu_status1.class used for display on listview
                        strSql = "Select TICKET_TICKET.ticket_id,TICKET_TICKET.create_on,TICKET_ACCOUNT.account_name,TICKET_TICKET.ticket_description,CONVERT (varchar(30),TICKET_TICKET.create_on,101)as create_on,TICKET_TICKET.statusticket_id,TICKET_STATUS_TICKET.statusticket_name,TICKET_TICKET.ticket_code,TICKET_PROJECT.project_code,TICKET_BRANCH.branch_name from TICKET_TICKET join TICKET_ACCOUNT on TICKET_TICKET.account_id = TICKET_ACCOUNT.account_id join TICKET_STATUS_TICKET on TICKET_TICKET.statusticket_id = TICKET_STATUS_TICKET.statusticket_id join TICKET_PROJECT on TICKET_TICKET.project_id = TICKET_PROJECT.id join TICKET_BRANCH on TICKET_TICKET.branch_id = TICKET_BRANCH.branch_id"
                        objAdapter = New SqlDataAdapter(strSql, objConn)
                        objAdapter.Fill(Ds, "ticket_id")
                        strResult = JsonConvert.SerializeObject(Ds.Tables("ticket_id"), Newtonsoft.Json.Formatting.Indented)

                        'Case "ticket1"
                        '    strSql = "select tt.ticket_id,tt.create_on,ta.account_name,tt.ticket_description,CONVERT (varchar(30),tt.create_on,101)as create_on,tst.statusticket_id,tst.statusticket_name,tt.ticket_code,tp.project_code,tb.branch_name from TICKET_STAFF s inner join ticket_group_role gr on gr.usergroup_id=s.usergroup_id inner join TICKET_PROJECT_ROLE pr on pr.role_id=gr.role_id inner join TICKET_TICKET tt on tt.project_id=pr.project_id inner join TICKET_ACCOUNT ta on tt.account_id=ta.account_id inner join TICKET_STATUS_TICKET tst on tt.statusticket_id=tst.statusticket_id inner join TICKET_PROJECT tp on tt.project_id=tp.id inner join TICKET_BRANCH tb on tt.branch_id=tb.branch_id where s.staffname='" & spname & "'"
                        '    objAdapter = New SqlDataAdapter(strSql, objConn)
                        '    'Dim Ds As New DataSet
                        '    objAdapter.Fill(Ds, "ticket_id")
                        '    strResult = JsonConvert.SerializeObject(Ds.Tables("ticket_id"), Newtonsoft.Json.Formatting.Indented)

                    Case "ticket2" 'Menu_task1.class used for display on listview
                        strSql = "select distinct tt.ticket_id,tt.create_on,ta.account_name,tt.ticket_description,CONVERT (varchar(30),tt.create_on,101)as create_on,tst.statusticket_id,tst.statusticket_name,tt.ticket_code,tp.project_code,tb.branch_name from TICKET_STAFF s inner join ticket_group_role gr on gr.usergroup_id=s.usergroup_id inner join TICKET_PROJECT_ROLE pr on pr.role_id=gr.role_id inner join TICKET_TICKET tt on tt.project_id=pr.project_id inner join TICKET_ACCOUNT ta on tt.account_id=ta.account_id inner join TICKET_STATUS_TICKET tst on tt.statusticket_id=tst.statusticket_id inner join TICKET_PROJECT tp on tt.project_id=tp.id inner join TICKET_BRANCH tb on tt.branch_id=tb.branch_id where tp.staff_id = (select id from TICKET_STAFF where username ='" & spname & "')"
                        objAdapter = New SqlDataAdapter(strSql, objConn)
                        objAdapter.Fill(Ds, "ticket_id")
                        strResult = JsonConvert.SerializeObject(Ds.Tables("ticket_id"), Newtonsoft.Json.Formatting.Indented)

                    Case "tkspec" 'Menu_task3.class used for display staff on listview 
                        strSql = "select create_by,resolve,status_specialist,note from TICKET_TICKET_SPECIALIST where ticket_id = '" + tkid + "'"
                        objAdapter = New SqlDataAdapter(strSql, objConn)
                        objAdapter.Fill(Ds, "ticketspecialist_id")
                        strResult = JsonConvert.SerializeObject(Ds.Tables("ticketspecialist_id"), Newtonsoft.Json.Formatting.Indented)

                    Case "Support" 'Menu_viewissue3.class used for send status support and resolve
                        Dim chn As String
                        chn = "Select ticket_id from TICKET_TICKET_SPECIALIST where create_by = '" & spname & "' and ticket_id = (select ticket_id from TICKET_TICKET where ticket_code = '" & ttid & "')"
                        Dim cmd As New SqlCommand(chn, objConn)
                        Dim chk As SqlDataReader = cmd.ExecuteReader
                        If chk.Read = False Then
                            chk.Close()
                            Dim strSql3 As String = String.Empty
                            Dim strSql4 As String = String.Empty
                            strSql3 = "INSERT INTO TICKET_TICKET_SPECIALIST (create_by,create_on,resolve,status_specialist,note,ticket_id) " & _
                                "VALUES ('" & spname.Replace("_", " ") & "',GetDate(),'" & tres.Replace("_", " ") & "','" & tsta & "','" & tno.Replace("_", " ") & "',(select ticket_id from TICKET_TICKET where ticket_code = '" & ttid & "'))"
                            Dim objCmd As New SqlCommand(strSql3, objConn)
                            objCmd.ExecuteNonQuery()
                            strSql4 = "UPDATE TICKET_TICKET SET statusticket_id = 2 where ticket_code = '" & ttid & "'"
                            Dim objCmd1 As New SqlCommand(strSql4, objConn)
                            objCmd1.ExecuteNonQuery()
                        End If

                        'Case "CustomerMail"
                        '    Dim strSql4 As String = String.Empty
                        '    strSql4 = "UPDATE TICKET_TICKET SET email_customer = '" + mail + "'"
                        '    Dim objCmd As New SqlCommand(strSql4, objConn)
                        '    objCmd.ExecuteNonQuery()

                    Case "Assignto" 'Menu_task4.class used for send assign to support
                        Dim strSql4 As String = String.Empty
                        Dim strSql5 As String = String.Empty
                        strSql4 = "UPDATE TICKET_TICKET SET assign_by = '" + asby + "',assign_on = GetDate(),assign_to = '" + asto + "',assign_resolved = (select resolve from TICKET_TICKET_SPECIALIST where create_by = '" + asres + "' and ticket_id = '" + ttid + "'),statusticket_id = '3' where ticket_id = '" + ttid + "'"
                        Dim objCmd As New SqlCommand(strSql4, objConn)
                        objCmd.ExecuteNonQuery()
                        strSql5 = "UPDATE TICKET_TICKET SET statusticket_id = 3 where ticket_id = '" & ttid & "'"
                        Dim objCmd1 As New SqlCommand(strSql5, objConn)
                        objCmd1.ExecuteNonQuery()

                    Case "staff" 'Menu_task4.class used for display staffname and resolve on spinner
                        strSql = "Select create_by,resolve from TICKET_TICKET_SPECIALIST where ticket_id = '" & tkid & "'"
                        objAdapter = New SqlDataAdapter(strSql, objConn)
                        objAdapter.Fill(Ds, "ticketspecialist_id")
                        strResult = JsonConvert.SerializeObject(Ds.Tables("ticketspecialist_id"), Newtonsoft.Json.Formatting.Indented)

                    Case "myassign" 'Menu_Myassign.class used for display on listview
                        strSql = "Select TICKET_TICKET.ticket_id,TICKET_ACCOUNT.account_name,TICKET_TICKET.ticket_description,TICKET_TICKET.create_on,TICKET_TICKET.statusticket_id,TICKET_PROJECT.project_name,TICKET_BRANCH.branch_name,TICKET_TICKET.assign_resolved,TICKET_TICKET.branch_sla from TICKET_TICKET join TICKET_ACCOUNT on TICKET_TICKET.account_id = TICKET_ACCOUNT.account_id join  TICKET_PROJECT on TICKET_TICKET.project_id = TICKET_PROJECT.id join TICKET_BRANCH on TICKET_TICKET.branch_id = TICKET_BRANCH.branch_id where TICKET_TICKET.assign_to = '" & astoMA & "'and statusticket_id <> 4"
                        objAdapter = New SqlDataAdapter(strSql, objConn)
                        objAdapter.Fill(Ds, "ticket_id")
                        strResult = JsonConvert.SerializeObject(Ds.Tables("ticket_id"), Newtonsoft.Json.Formatting.Indented)

                    Case "cusdetail" 'Menu_Myassign.class used on page 3
                        Dim strSql4 As String = String.Empty
                        Dim strSql5 As String = String.Empty
                        strSql4 = "UPDATE TICKET_TICKET SET resolved = '" + reso + "',customer_name = '" + cusname + "',customer_phone = '" + cusphone + "',email_customer = '" + cusmail + "',statusticket_id = '4' where ticket_id = '" + tkid + "'"
                        Dim objCmd As New SqlCommand(strSql4, objConn)
                        objCmd.ExecuteNonQuery()
                        strSql5 = "UPDATE TICKET_TICKET SET statusticket_id = 4 where ticket_id = '" & tkid & "'"
                        Dim objCmd1 As New SqlCommand(strSql5, objConn)
                        objCmd1.ExecuteNonQuery()

                    Case "mailconfirm" 'HTML confirm used
                        Dim strSql4 As String = String.Empty
                        strSql = "UPDATE TICKET_TICKET SET statuscus_id = '" + state + "' where ticket_code = '" + tkid + "'"
                        Dim objCmd As New SqlCommand(strSql, objConn)
                        objCmd.ExecuteNonQuery()

                        Exit Select

                End Select

                Response.Write("{    ""Ticket"": " & strResult & "  }")

            Catch ex As Exception
                Response.Write("False")
            End Try

        Catch ex As Exception
            Response.Write("False")
        End Try

    End Sub

End Class