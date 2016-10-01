
Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub Login_Click(Source As Object, E As EventArgs)
        Response.Redirect("frmDashboard.aspx?RowIDmenu=1")
    End Sub
End Class
