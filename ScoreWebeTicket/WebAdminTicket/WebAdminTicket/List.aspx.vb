Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class List
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Support-TicketConnectionString").ConnectionString)
    Dim Cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            RadGrid1.DataSource = Data()
            RadGrid1.DataBind()
        End If

    End Sub
    Private Function Data() As DataSet 'function call ticket data
        Dim text As String = "SELECT TICKET_TICKET.create_by,TICKET_TICKET.create_on,TICKET_ACCOUNT.account_name,TICKET_PROJECT.project_code,TICKET_BRANCH.branch_name,TICKET_TICKET.ticket_code,TICKET_TICKET.assign_by,TICKET_TICKET.assign_on,TICKET_STATUS_TICKET.statusticket_name,TICKET_STATUS_CUSTOMER.statuscus_name,TICKET_TICKET.ticket_id from TICKET_TICKET left join TICKET_ACCOUNT on TICKET_TICKET.account_id = TICKET_ACCOUNT.account_id left join TICKET_PROJECT on TICKET_TICKET.project_id=TICKET_PROJECT.id left join TICKET_BRANCH on TICKET_TICKET.branch_id=TICKET_BRANCH.branch_id left join TICKET_STATUS_TICKET on TICKET_TICKET.statusticket_id=TICKET_STATUS_TICKET.statusticket_id left join TICKET_STATUS_CUSTOMER on TICKET_TICKET.statuscus_id=TICKET_STATUS_CUSTOMER.statuscus_id;"
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
    Protected Sub RadGrid1_ItemCommand(source As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand

        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
            If e.CommandName = "openfile" Then
                Dim tkid As Label = e.Item.FindControl("Label1") 'find ticket id and send in url
                Dim strScripth As String = "window.open('./selectfile.aspx?ticketid=" + tkid.Text + "','width=500px,height=750px');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", strScripth, True)
            End If
        End If
    End Sub
End Class