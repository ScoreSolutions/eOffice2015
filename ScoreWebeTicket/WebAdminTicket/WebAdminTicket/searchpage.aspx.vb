Imports System.Data.SqlClient
Imports System.Security.Permissions

Public Class searchpage
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Support-TicketConnectionString").ConnectionString)
    Dim Cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim text1 As String = Request.QueryString("text") 'get para from url in MainPage

        Dim sq As String
        sq = "Select TICKET_PROJECT.project_code,TICKET_BRANCH.branch_name,TICKET_TICKET.ticket_description,TICKET_STATUS_TICKET.statusticket_name,TICKET_TICKET.assign_to from TICKET_TICKET join TICKET_PROJECT on TICKET_TICKET.project_id = TICKET_PROJECT.id join TICKET_BRANCH on TICKET_TICKET.branch_id = TICKET_BRANCH.branch_id join TICKET_STATUS_TICKET on TICKET_TICKET.statusticket_id = TICKET_STATUS_TICKET.statusticket_id where TICKET_TICKET.ticket_code='" & text1.Replace(" ", "") & "' "
        Dim cmd As New SqlCommand(sq, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)

        Label2.Text = ds.Tables(0).Rows(0)(0).ToString 'add data to label 
        Label3.Text = ds.Tables(0).Rows(0)(1).ToString 'add data to label 
        TextBox1.Text = ds.Tables(0).Rows(0)(2).ToString 'add data to label 
        Label5.Text = ds.Tables(0).Rows(0)(3).ToString 'add data to label 
        If ds.Tables(0).Rows(0)(4).ToString = "" Then 'add data to label 
            Label6.Text = "ยังไม่มีการ Assign"
        Else
            Label6.Text = ds.Tables(0).Rows(0)(4).ToString
        End If
        con.Close()

    End Sub
End Class