Imports XCS.Process.Master
Imports System.Data

Partial Class WebApp_frmUserList
    Inherits System.Web.UI.Page

    Protected Sub lnkUserName_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("../WebApp/frmUserForm.aspx?id=" & sender.CommandArgument & "&time=" & Today.Now.Millisecond)
    End Sub

    Private Sub SearchData()
        Dim whText As String = " 1 = 1 "  'ไม่ต้องกแสดง Admin ในรายการ
        If txtStaffName.Text.Trim <> "" Then
            whText += " and staffname like '%" & txtStaffName.Text.Trim & "%'"
        End If
        If txtPositionName.Text.Trim <> "" Then
            whText += " and position_name like '%" & txtPositionName.Text.Trim & "%'"
        End If
        If txtDivisionName.Text.Trim <> "" Then
            whText += " and division_name like '%" & txtDivisionName.Text.Trim & "%'"
        End If

        Dim trans As New XCS.Process.Common.DbTransProcess
        trans.CreateTransaction()

        pcTop.SetMainGridView(GridView1)
        Dim Proc As New StaffListProcess
        Dim dt As DataTable = Proc.SearchData(whText, trans)
        GridView1.DataSource = dt
        GridView1.DataBind()
        pcTop.Update(dt.Rows.Count)
        trans.CommitTransaction()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            If Func.ChkLogin() = False Then
                Response.Redirect(FormsAuthentication.LoginUrl)
            End If

            Dim frm As Template_MasterPage
            frm = Me.Master
            frm.SetPageName("User List")

            SearchData()
        End If
    End Sub

    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        GridView1.PageIndex = pcTop.SelectPageIndex
        SearchData()
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SearchData()
    End Sub

    Protected Sub likNewUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles likNewUser.Click
        Response.Redirect("../WebApp/frmUserForm.aspx?id=0")
    End Sub
End Class
