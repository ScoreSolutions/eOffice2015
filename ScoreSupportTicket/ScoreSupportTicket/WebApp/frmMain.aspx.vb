Imports System.Web.Security
Imports XCS.Data.Common

Partial Class WebApp_frmMain
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            If Func.ChkLogin() = False Then
                Response.Redirect(FormsAuthentication.LoginUrl)
            End If
            Dim frm As Template_MasterPage
            frm = Me.Master
            frm.SetPageName("Main Page")

            SetSummaryList()
        End If
    End Sub

    Public Sub SetSummaryList()

    End Sub
End Class
