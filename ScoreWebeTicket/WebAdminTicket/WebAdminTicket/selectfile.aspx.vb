Imports System.Data.SqlClient
Imports System.Security.Permissions
Imports Telerik.Web.UI

Public Class selectfile
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Support-TicketConnectionString").ConnectionString)
    Dim Cmd As New SqlCommand
    Private Function Data(ByVal str As String) As DataSet 'function find data from url parameter
        Dim text As String = "SELECT file_name from TICKET_ISSUE_ATTACH_FILE where ticket_id = '" + str + "'"
        Dim cmd As New SqlCommand(text, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        con.Close()
        Return ds
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tkid As String = Request.QueryString("ticketid") 'get parameter from url
        Session("tkid") = tkid

        If Page.IsPostBack = False Then
            RadGrid1.DataSource = Data(tkid) 'bind data from parameter
            RadGrid1.DataBind()
        End If

    End Sub

    Protected Sub RadGrid1_ItemCommand(source As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        Dim finame As Label = e.Item.FindControl("Label2") 'find file name .....
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
            If e.CommandName = "openfile" Then
                con.Open()
                'open file from path and file name....
                Dim text1 As String = "SELECT path_folder from TICKET_ISSUE_ATTACH_FILE where ticket_id = '" + Session("tkid") + "' and file_name = '" + finame.Text + "'"
                Dim cmd1 As New SqlCommand(text1, con)
                Dim da1 As New SqlDataAdapter(cmd1)
                Dim ds1 As New DataSet()
                da1.Fill(ds1)
                Dim chk As SqlDataReader = cmd1.ExecuteReader

                If (chk.Read = False) Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Cannot find file in This Ticket.');", True)
                Else
                    Try
                        Dim strPath As String = "http://" & HttpContext.Current.Request.Url.Host & "/WebTicket/TICKETFILE/" + ds1.Tables(0).Rows(0)(0).ToString + "/" + finame.Text
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "window.open('" & strPath & "');", True)
                    Catch ex As Exception
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('File no have in directory.');", True)
                    End Try

                End If
            End If
        End If
    End Sub
End Class