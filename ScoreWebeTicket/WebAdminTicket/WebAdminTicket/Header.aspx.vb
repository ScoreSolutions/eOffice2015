Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Collections.Generic
Imports Telerik.Web.UI

Partial Public Class Header
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("state") = Nothing Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "AlertBox", "alert('Please Login.');window.location='" + Request.ApplicationPath + "~/login.aspx';", True)
        End If

    End Sub
    <WebMethod()> _
    Public Shared Function GetAutoCompleteData(ByVal username As String) As List(Of String)
        Dim result As New List(Of String)()
        Using con As New SqlConnection("Data Source=SCOREDB01;Initial Catalog=Support-Ticket;Persist Security Info=True;User ID=sa;Password=1qaz@WSX")
            Using cmd As New SqlCommand("select ticket_description from TICKET_TICKET where ticket_description LIKE '%'+@SearchText+'%'", con)
                con.Open()
                cmd.Parameters.AddWithValue("@SearchText", username)
                Dim dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    result.Add(dr("ticket_description").ToString())
                End While
                Return result
            End Using
        End Using
    End Function
    Protected Sub rbShowDialog_Click(sender As Object, e As EventArgs) Handles rbShowDialog.Click, rbShowDialog.Click, rbShowDialog.Click
        Session("grid") = txtSearch.Text
    End Sub
End Class