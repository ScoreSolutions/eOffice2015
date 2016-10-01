Imports XCS.Process.Common
Imports System.Data

Partial Class TestPage
    Inherits System.Web.UI.Page

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        InitView()
        MyBase.OnInit(e)
    End Sub
    Private Sub InitView()
        If Me.IsPostBack = False Then
            Dim url As String = "http://localhost:64303/TrackingLog/TestAjaxControl.aspx"
            ddlProject.SourceURL = url
            ddlModule.SourceURL = url
            ddlScreen.SourceURL = url

            ddlProject.Observers.Add(ddlModule)
            ddlModule.Observers.Add(ddlScreen)
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Text = ddlScreen.SelectedItem.Text
    End Sub
End Class
