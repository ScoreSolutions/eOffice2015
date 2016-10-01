Imports System.Data.SqlClient

Partial Public Class MainPage
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Support-TicketConnectionString").ConnectionString)
    Dim StartTime As DateTime
    Dim CurrentTime As DateTime
    Dim Cmd As New SqlCommand
    Dim strArraylist As New ArrayList
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("state") = Nothing Then
            Response.Write("<script>alert('Will have to login before')</script>")
            Response.Write("<script>window.location.href='Login.aspx';</script>")
        End If
        If Not IsPostBack Then
            If Session("grid") <> "" Then
                RadGrid1.DataSource = DataWithSearchText(Session("grid"))
                RadGrid1.DataBind()
            End If

            RadGrid2.DataSource = Data()
            RadGrid2.DataBind()


            For i As Integer = 0 To RadGrid2.Items.Count - 1
                Dim lbltime As Label = RadGrid2.Items.Item(i).FindControl("lblTime")
                Dim lbltimeset As Label = RadGrid2.Items.Item(i).FindControl("label4")
                If lbltime.Text > 0 Then
                    Dim Dt As Date = Convert.ToDateTime(lbltimeset.Text)
                    StartTime = Dt.AddMinutes(lbltime.Text).ToString("HH:mm:ss")
                    CurrentTime = StartTime.ToString
                    lbltime.Text = CurrentTime.ToString("HH:mm:ss").ToString
                Else
                    lbltime.Text = "OVERTIME"
                End If
            Next
        End If
        con.Close()

    End Sub
    Private Function Data() As DataSet
        Dim text As String = "SELECT TICKET_TICKET.ticket_id,CONVERT(VARCHAR(50),create_on,108) as create_on,TICKET_TICKET.ticket_code,TICKET_TICKET.branch_sla,TICKET_STATUS_TICKET.statusticket_name FROM TICKET_TICKET join TICKET_STATUS_TICKET on TICKET_TICKET.statusticket_id = TICKET_STATUS_TICKET.statusticket_id where TICKET_TICKET.statusticket_id = '1' or TICKET_TICKET.statusticket_id = '2' or TICKET_TICKET.statusticket_id = '3'"
        Dim cmd As New SqlCommand(text, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        con.Close()
        Return ds
    End Function
    Public Function DataWithSearchText(ByVal s1 As String) As DataSet
        Dim sq As String
        sq = "Select resolved from TICKET_TICKET where "
        sq += "ticket_description Like '%" & Session("grid") & "%'"     
        Dim cmd As New SqlCommand(sq, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()      
        da.Fill(ds)
        con.Close()
        Return ds
    End Function
    Protected Sub RadGrid2_PageIndexChanged(source As Object, e As Telerik.Web.UI.GridPageChangedEventArgs)
        RadGrid2.CurrentPageIndex = e.NewPageIndex
        RadGrid2.DataSource = Data()
        RadGrid2.DataBind()
    End Sub  
    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        con.Open()
        Try
            For i As Integer = 0 To RadGrid2.Items.Count - 1
                Dim lbltimeset As Label = RadGrid2.Items.Item(i).FindControl("label4")
                Dim lbltime As Label = RadGrid2.Items.Item(i).FindControl("lblTime")
                If Val(lbltime.Text) > 0 Then
                    CurrentTime = CDate(lbltime.Text).AddSeconds(-1)
                    lbltime.Text = CurrentTime.ToString("HH:mm:ss").ToString
                    If (lbltimeset.Text = lbltime.Text) Then
                        lbltime.Text = "TIMEOUT"
                        Dim sql As String = "UPDATE TICKET_TICKET SET branch_sla = '0' where ticket_id = " + DirectCast(RadGrid2.Items.Item(i).FindControl("label5"), Label).Text + ""
                        With Cmd
                            .CommandType = CommandType.Text
                            .CommandText = sql
                            .Connection = con
                            .ExecuteNonQuery()
                        End With
                    End If
                    ' Else
                    'Dim strKEEP As String = "ID:" & lbltime.Text
                    'strArraylist.Add(lbltime.Text)
                End If
            Next
            'Session("KeepTime") = strArraylist
        Catch ex As Exception

        End Try
    End Sub

  
End Class