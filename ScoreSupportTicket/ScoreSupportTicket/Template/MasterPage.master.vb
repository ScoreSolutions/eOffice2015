Imports XCS.Data.Common.Utilities
Imports XCS.Process.Common
Imports XCS.Process.Master

Partial Class Template_MasterPage
    Inherits System.Web.UI.MasterPage

    Public Sub SetPageName(ByVal value As String)
        lblPageName.Text = value
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMenuList.Text = SetMenuList()
        lblUserLogin.Text = "User : " & Func.GetLogOnUser.STAFFNAME
    End Sub

    Private Function SetMenuList() As String
        Dim trans As New DbTransProcess
        trans.CreateTransaction()
        Dim ret As String = ""
        ret += "<a href='../WebApp/frmSummary.aspx?time=" & DateTime.Now.Millisecond & "' >Summary</a>"
        ret += " | <a href='../WebApp/frmIssueList.aspx?time=" & DateTime.Now.Millisecond & "' >IssueList</a>"
        ret += " | <a href='../WebApp/frmIssueForm.aspx?time=" & DateTime.Now.Millisecond & "' >NewIssue</a>"
        ret += " | <a href='../WebApp/frmProject.aspx?time=" & DateTime.Now.Millisecond & "' >Project</a>"
        If FunctionProcess.GetConfigValue(Constant.SysConfigName.AdminID, trans) = Func.GetLogOnUser.ID Or FunctionProcess.GetConfigValue(Constant.SysConfigName.PrapojID, trans) = Func.GetLogOnUser.ID Then
            ret += " | <a href='../WebApp/frmUserList.aspx?time=" & DateTime.Now.Millisecond & "' >User</a>"
        Else
            ret += " | <a href='../WebApp/frmUserForm.aspx?id=" & Func.GetLogOnUser.ID & "&time=" & DateTime.Now.Millisecond & "' >User</a>"
        End If
        trans.CommitTransaction()
        Return ret
    End Function
End Class

