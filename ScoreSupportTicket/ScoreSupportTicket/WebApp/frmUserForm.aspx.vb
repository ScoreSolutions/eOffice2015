Imports XCS.Process.Common
Partial Class WebApp_frmUserForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            If Func.ChkLogin() = False Then
                Response.Redirect(FormsAuthentication.LoginUrl)
            End If
            Dim frm As Template_MasterPage
            frm = Me.Master
            frm.SetPageName("User Form")
            Dim trans As New DbTransProcess
            trans.CreateTransaction()
            mstStaffForm1.SetProjectList()
            trans.CommitTransaction()
        End If
    End Sub

    Protected Sub mstStaffForm1_SaveComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles mstStaffForm1.SaveComplete
        Func.SetAlert("บันทึกข้อมูลเรียบร้อย", Me, mstStaffForm1.TextUserName.ClientID)
    End Sub
End Class
