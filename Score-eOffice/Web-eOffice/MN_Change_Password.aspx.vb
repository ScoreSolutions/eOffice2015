Option Strict Off
Imports System.Data
Imports System.data.sqlclient

Partial Class _change_password
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim conf As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/")
    Dim Myconn As New SqlConnection(conf.ConnectionStrings.ConnectionStrings("MyConn").ToString)
    Dim func As New EtimesheetSystem
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Master.Page.Title = "Change Password"
        func.checkConn(Myconn, "o")
        sql = "select * from eOFFICE_USER where Id = '" & func.FixData(Session("Member_Id")) & "' "
        Dim da As New SqlDataAdapter(sql, Myconn)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            txtUserName.Text = ds.Tables(0).Rows(0)("username")
        Else
            lblError.Text = "Username '" & func.FixData(Session("fname")) & "' does not exists"
            lblError.CssClass = "errorBox"
            lblError.Visible = True
        End If

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        func.checkConn(Myconn, "c")
    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        sql = "select * from eOFFICE_USER where Id = '" & func.FixData(Session("Member_Id")) & "' "
        func.checkConn(Myconn, "o")
        Dim da As New SqlDataAdapter(sql, Myconn)
        Dim ds As New DataSet
        da.Fill(ds)

        Dim OldPassword As String = func.EnCripPwd(txtOldPass.Text.Trim)
        Dim NewPassword As String = func.EnCripPwd(txtNewPass.Text)

        lblError.Text = ""
        If func.FixData(OldPassword) <> ds.Tables(0).Rows(0)("password") Or func.FixData(txtOldPass.Text.Trim) = "" Then
            lblError.Text = "Old Password is blank or wrong password"
        ElseIf func.FixData(txtNewPass.Text) <> func.FixData(txtNewPass1.Text) Or txtNewPass.Text = "" Then
            lblError.Text = "New Password is blank or not math"

        End If
        If lblError.Text <> "" Then
            lblError.Visible = True
        Else
            sql = "update eOFFICE_USER set password= '" & func.FixData(NewPassword) & "' "
            sql &= ",chg_pwd_first_login='N'  where username ='" & func.FixData(txtUserName.Text) & "' and password ='" & func.FixData(OldPassword) & "' "
            Dim cmd As New SqlCommand(sql, Myconn)
            cmd.ExecuteNonQuery()
            'lblError.CssClass() = "successBox"
            'lblError.Text = ""
            'lblError.Visible = True

            Response.Redirect("Logout.aspx?ChangePassword=Y")
        End If

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("MN_Change_Password.aspx")
    End Sub
End Class
