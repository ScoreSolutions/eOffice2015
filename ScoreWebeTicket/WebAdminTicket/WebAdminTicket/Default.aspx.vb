Imports System.Data.SqlClient

Public Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("state") = Nothing Then
            Me.Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "myUniqueKey", "self.parent.location='Login.aspx';", True)
        End If
    End Sub
End Class