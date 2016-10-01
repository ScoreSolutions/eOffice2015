Imports System.Data.SqlClient
Imports System.Data
Partial Class MasterPage_Basic_sub
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim func As New EtimesheetSystem
        Dim ls_FileName As String = Session("SubFileName")
        If Not func.CheckLogin(Session("login_state")) Then Response.Redirect("login.aspx")
        If Not func.checkPerm(ls_FileName, Session("menu"), lblheaderMenulink) Then
            If Not ls_FileName.ToLower = "default.aspx" Then
                Response.Redirect("default.aspx")
            End If
        End If
        func.showMenu(mnHolder, Session("menu"))

    End Sub
End Class