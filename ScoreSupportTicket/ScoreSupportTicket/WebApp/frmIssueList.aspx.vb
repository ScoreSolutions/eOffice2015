Imports XCS.Process.Common
Imports XCS.Data.Common
Imports System.Data

Partial Class WebApp_frmIssueList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            If Func.ChkLogin() = False Then
                Response.Redirect(FormsAuthentication.LoginUrl)
            End If

            Dim frm As Template_MasterPage
            frm = Me.Master
            frm.SetPageName("Issue Log")

            SetCombo()
            SetOrderBy()
        End If
    End Sub

    Protected Sub lnkPrintCR_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim scr As String = "<script language='javascript' >"
        scr += " window.open('../WebApp/frmCRForm.aspx?id=" & sender.CommandArgument & "', '_blank', 'height=650,left=600,location=no,menubar=yes,toolbar=no,status=no,resizable=yes,scrollbars=yes', true);"
        scr += " </script>"

        ScriptManager.RegisterStartupScript(Me, GetType(String), "CrForm", scr, False)
    End Sub

    Public Sub SetOrderBy()
        cmbOrderBy.SetItemList("---Select", "")
        cmbOrderBy.SetItemList("Raised Date", "raised_on")
        cmbOrderBy.SetItemList("Assign Date", "assigned_date")
        cmbOrderBy.SetItemList("Expected Date", "expected_closed_date")
        cmbOrderBy.SetItemList("Closed Date", "closed_date")
        cmbOrderBy.SetItemList("Type", "type_name")
        cmbOrderBy.SetItemList("Status", "status_name")
        cmbOrderBy.SetItemList("Priority", "priority")
        cmbOrderBy.SetItemList("State", "state_name")
    End Sub

    Private Sub CheckAll(ByVal chk As CheckBoxList)
        If chk.Items.Count > 0 Then
            For i As Integer = 0 To chk.Items.Count - 1
                chk.Items(i).Selected = True
            Next
        End If
    End Sub

    Private Sub SetCombo()
        Dim trans As New DbTransProcess
        trans.CreateTransaction()
        Dim Proc As New IssueListProcess
        cmbProject.SetItemList(Proc.GetProjectList(Func.GetUserName(), trans), "project_name", "id")

        'Checkbox Type
        Dim dtT As DataTable = Proc.GetTypeList(trans)
        chkType.DataSource = dtT
        chkType.DataTextField = "type_name"
        chkType.DataValueField = "id"
        chkType.DataBind()
        CheckAll(chkType)

        'Checkbox Status
        Dim dtS As DataTable = Proc.GetStatusList(trans)
        chkStatus.DataSource = dtS
        chkStatus.DataTextField = "status_name"
        chkStatus.DataValueField = "id"
        chkStatus.DataBind()
        CheckAll(chkStatus)

        'Checkbox State
        Dim dtSt As DataTable = Proc.GetStateList(trans)
        chkState.DataSource = dtSt
        chkState.DataTextField = "state_name"
        chkState.DataValueField = "id"
        chkState.DataBind()
        CheckAll(chkState)

        CheckAll(chkPriority)
        trans.CommitTransaction()
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        txtSortDir.Text = ""
        txtSortField.Text = ""
        SearchData()
    End Sub

    Private Sub SearchData()
        Dim whText As String = ""
        If cmbProject.SelectedValue <> "0" Then
            whText += " and il.project_id = '" & cmbProject.SelectedValue & "'"
        End If
        If cmbModule.SelectedValue <> "0" Then
            whText += " and il.module_id = '" & cmbModule.SelectedValue & "'"
        End If
        If cmbScreen.SelectedValue <> "0" Then
            whText += " and il.screen_id = '" & cmbScreen.SelectedValue & "'"
        End If
        If txtRaisedOnFrom.TxtBox.Text.Trim <> "" Then
            whText += " and convert(varchar(8),il.raised_on,112) >= '" & txtRaisedOnFrom.GetDateCondition & "'"
        End If
        If txtRaisedOnTo.TxtBox.Text.Trim <> "" Then
            whText += " and convert(varchar(8),il.raised_on,112) <= '" & txtRaisedOnTo.GetDateCondition & "'"
        End If
        If txtAssignDateFrom.TxtBox.Text.Trim <> "" Then
            whText += " and convert(varchar(8), il.assigned_date,112) >= '" & txtAssignDateFrom.GetDateCondition & "'"
        End If
        If txtAssignDateTo.TxtBox.Text.Trim <> "" Then
            whText += " and convert(varchar(8), il.assigned_date,112) <= '" & txtAssignDateTo.GetDateCondition & "'"
        End If
        If txtExpectedDateFrom.TxtBox.Text.Trim <> "" Then
            whText += " and convert(varchar(8), il.expected_closed_date,112) >= '" & txtExpectedDateFrom.GetDateCondition & "'"
        End If
        If txtExpectedDateTo.TxtBox.Text.Trim <> "" Then
            whText += " and convert(varchar(8), il.expected_closed_date,112) <= '" & txtExpectedDateTo.GetDateCondition & "'"
        End If
        If txtClosedDateFrom.TxtBox.Text.Trim <> "" Then
            whText += " and convert(varchar(8),il.closed_date,112) >= '" & txtClosedDateFrom.GetDateCondition & "'"
        End If
        If txtClosedDateTo.TxtBox.Text.Trim <> "" Then
            whText += " and convert(varchar(8),il.closed_date,112) <= '" & txtClosedDateTo.GetDateCondition & "'"
        End If

        Dim chkTypeValue As String = ""
        For i As Integer = 0 To chkType.Items.Count - 1
            If chkType.Items(i).Selected = True Then
                If chkTypeValue = "" Then
                    chkTypeValue = chkType.Items(i).Value
                Else
                    chkTypeValue += "," & chkType.Items(i).Value
                End If
            End If
        Next
        If chkTypeValue <> "" Then
            whText += " and il.type_id in (" & chkTypeValue & ")"
        Else
            whText += " and il.type_id in (null)"
        End If

        Dim chkStatusValue As String = ""
        For i As Integer = 0 To chkStatus.Items.Count - 1
            If chkStatus.Items(i).Selected Then
                If chkStatusValue = "" Then
                    chkStatusValue = chkStatus.Items(i).Value
                Else
                    chkStatusValue += "," & chkStatus.Items(i).Value
                End If
            End If
        Next
        If chkStatusValue <> "" Then
            whText += " and il.status_id in (" & chkStatusValue & ")"
        Else
            whText += " and il.status_id in (null)"
        End If

        Dim chkPriorityValue As String = ""
        For i As Integer = 0 To chkPriority.Items.Count - 1
            If chkPriority.Items(i).Selected Then
                If chkPriorityValue = "" Then
                    chkPriorityValue = Chr(39) & chkPriority.Items(i).Value & Chr(39)
                Else
                    chkPriorityValue += ",'" & chkPriority.Items(i).Value & Chr(39)
                End If
            End If
        Next
        If chkPriorityValue <> "" Then
            whText += " and il.priority in (" & chkPriorityValue & ")"
        Else
            whText += " and il.priority in (null)"
        End If

        Dim chkStateValue As String = ""
        For i As Integer = 0 To chkState.Items.Count - 1
            If chkState.Items(i).Selected Then
                If chkStateValue = "" Then
                    chkStateValue = chkState.Items(i).Value
                Else
                    chkStateValue += "," & chkState.Items(i).Value
                End If
            End If
        Next
        If chkStateValue <> "" Then
            whText += " and il.state_id in (" & chkStateValue & ")"
        Else
            whText += " and il.state_id in (null)"
        End If


        Dim orderBy As String = ""
        If cmbOrderBy.SelectedValue <> "" Then
            orderBy = cmbOrderBy.SelectedValue & " " & IIf(rdiOrderDirection.SelectedValue = "A", "asc", "desc")
        End If

        If txtSortField.Text.Trim <> "" Then
            orderBy = txtSortField.Text & " " & txtSortDir.Text
        End If

        pcTop.SetMainGridView(GridView1)
        Dim trans As New DbTransProcess
        trans.CreateTransaction()
        Dim Proc As New IssueListProcess
        Dim dt As DataTable = Proc.SearchData(whText, orderBy, Page.User.Identity.Name, trans)
        If dt.Rows.Count > 0 Then
            dt.Columns.Add("NO")
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("NO") = i + 1
                dt.Rows(i)("log_no") = Convert.ToDateTime(dt.Rows(i)("create_on")).ToString("yyyy", New Globalization.CultureInfo("en-US")) & dt.Rows(i)("log_no").ToString.PadLeft(4, "0")
            Next
            GridView1.DataSource = dt
        Else
            GridView1.DataSource = Nothing
        End If
        GridView1.DataBind()
        pcTop.Update(dt.Rows.Count)
        trans.CommitTransaction()
    End Sub

    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        GridView1.PageIndex = pcTop.SelectPageIndex
        SearchData()
    End Sub

    Protected Sub cmbProject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProject.SelectedIndexChanged
        Dim Proc As New IssueListProcess
        Dim trans As New DbTransProcess
        trans.CreateTransaction()
        cmbModule.SetItemList(Proc.GetModuleList(cmbProject.SelectedValue, trans), "module_name", "id")
        trans.CommitTransaction()
    End Sub

    Protected Sub cmbModule_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbModule.SelectedIndexChanged
        Dim Proc As New IssueListProcess
        Dim trans As New DbTransProcess
        trans.CreateTransaction()
        cmbScreen.SetItemList(Proc.GetScreenList(cmbModule.SelectedValue, trans), "screen_name", "id")
        trans.CommitTransaction()
    End Sub

    Protected Sub cmbOrderBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOrderBy.SelectedIndexChanged
        If cmbOrderBy.SelectedValue <> "" Then
            rdiOrderDirection.Enabled = True
        Else
            rdiOrderDirection.SelectedValue = "A"
            rdiOrderDirection.Enabled = False
        End If
    End Sub

    Protected Sub lnkLogNo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("frmIssueForm.aspx?id=" & sender.CommandArgument)
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        If txtSortField.Text = e.SortExpression Then
            txtSortDir.Text = IIf(txtSortDir.Text.Trim = "", "Desc", IIf(txtSortDir.Text.Trim = "Asc", "Desc", "Asc"))
        Else
            txtSortField.Text = e.SortExpression
            txtSortDir.Text = "Desc"
        End If
        SearchData()
    End Sub
End Class
