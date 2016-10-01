Imports System.IO

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Try
                Dim TempPath As String = Server.MapPath("TempExpenditureUpload") & "\" & Request.UserHostAddress
                If Directory.Exists(TempPath) = True Then
                    Directory.Delete(TempPath, True)
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class
