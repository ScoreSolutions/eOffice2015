
Partial Class frmTable
    Inherits System.Web.UI.Page

    Protected Sub DeleteTest(RowID As String)
        Page.ClientScript.RegisterStartupScript(Me.GetType(),
                "alert", "alert('Deletecomplete:" & RowID & "');", True)
    End Sub
End Class
