Imports XCS.Data.Table
Imports XCS.Process.Master
Imports XCS.Process.Common

Partial Class UserControls_cmbMasterTableForm
    Inherits System.Web.UI.UserControl

    Public Event CommitChange(ByVal sender As Object, ByVal e As System.EventArgs)

    Public WriteOnly Property PageName() As String
        Set(ByVal value As String)
            lblPageName.Text = value
        End Set
    End Property
    Public WriteOnly Property MasterName() As String
        Set(ByVal value As String)
            lblMasterName.Text = value
        End Set
    End Property
    Public WriteOnly Property MasterTableName() As String
        Set(ByVal value As String)
            txtMasterTableName.Text = value
        End Set
    End Property
    Public WriteOnly Property ProjectID() As Long
        Set(ByVal value As Long)
            cmbProject.SelectedValue = value
        End Set
    End Property
    Public WriteOnly Property RefProjectID() As String
        Set(ByVal value As String)
            txtRefProjectID.Text = value
        End Set
    End Property

    Public Sub Show(ByVal id As Long)
        Dim trans As New DbTransProcess
        trans.CreateTransaction()
        If id = 0 Then
            ClearForm()
        End If
        If txtMasterTableName.Text = "SCREEN" Then
            Dim Proc As New FormControlProcess
            cmbModule.SetItemList(Proc.GetModuleList(txtRefProjectID.Text, trans), "module_name", "id")
        ElseIf txtMasterTableName.Text = "MODULE" Then
            Dim Proc As New FormControlProcess
            cmbProject.SetItemList(Proc.GetProjectList(Func.GetUserName, trans), "project_name", "id")
        End If
        trans.CommitTransaction()
        zPop.Show()
    End Sub

    Private Sub ClearForm()
        cmbModule.SelectedValue = "0"
        txtCode.Text = ""
        txtName.Text = ""
        txtID.Text = 0
        txtDesc.Text = ""
        txtOrder.Text = ""
        chkActive.Checked = True
    End Sub

    Protected Sub imgClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgClose.Click
        zPop.Hide()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtMasterTableName.Text = "LOG_TYPE" Then
            Dim lData As New LogTypeData
            lData.ID = IIf(txtID.Text.Trim = "", 0, txtID.Text)
            lData.TYPE_NAME = txtName.Text.Trim
            lData.TYPE_DESC = txtDesc.Text.Trim
            lData.TYPE_ORDER = IIf(txtOrder.Text.Trim = "", 0, txtOrder.Text.Trim)
            lData.ACTIVE = IIf(chkActive.Checked = True, "Y", "N")

            If ValidateLogType(lData) = True Then
                Dim Proc As New FormControlProcess
                If Proc.SaveLogType(lData, Page.User.Identity.Name) = True Then
                    RaiseEvent CommitChange(sender, e)
                Else
                    popMessage1.ShowMessage(UserControl_popMessage.MsgType.Exclamation, Proc.ErrorMessage, "Invalid Data")
                End If
            Else
                zPop.Show()
            End If

        ElseIf txtMasterTableName.Text = "LOG_STATUS" Then
            Dim lData As New LogStatusData
            lData.ID = IIf(txtID.Text.Trim = "", 0, txtID.Text)
            lData.STATUS_NAME = txtName.Text.Trim
            lData.STATUS_DESC = txtDesc.Text.Trim
            lData.STATUS_ORDER = IIf(txtOrder.Text.Trim = "", 0, txtOrder.Text.Trim)
            lData.ACTIVE = IIf(chkActive.Checked = True, "Y", "N")

            If ValidateLogStatus(lData) = True Then
                Dim Proc As New FormControlProcess
                If Proc.SaveLogStatus(lData, Page.User.Identity.Name) = True Then
                    RaiseEvent CommitChange(sender, e)
                Else
                    popMessage1.ShowMessage(UserControl_popMessage.MsgType.Exclamation, Proc.ErrorMessage, "Invalid Data")
                End If
            Else
                zPop.Show()
            End If

        ElseIf txtMasterTableName.Text = "RESOLVED_STATUS" Then
            Dim lData As New ResolvedStatusData
            lData.ID = IIf(txtID.Text.Trim = "", 0, txtID.Text)
            lData.STATUS_NAME = txtName.Text.Trim
            lData.STATUS_DESC = txtDesc.Text.Trim
            lData.STATUS_ORDER = IIf(txtOrder.Text.Trim = "", 0, txtOrder.Text.Trim)
            lData.ACTIVE = IIf(chkActive.Checked = True, "Y", "N")

            If ValidateResolvedStatus(lData) = True Then
                Dim Proc As New FormControlProcess
                If Proc.SaveResolvedStatus(lData, Func.GetUserName) = True Then
                    RaiseEvent CommitChange(sender, e)
                Else
                    popMessage1.ShowMessage(UserControl_popMessage.MsgType.Exclamation, Proc.ErrorMessage, "Invalid Data")
                End If
            Else
                zPop.Show()
            End If

        ElseIf txtMasterTableName.Text = "LOG_STATE" Then
            Dim lData As New LogStateData
            lData.ID = IIf(txtID.Text.Trim = "", 0, txtID.Text)
            lData.STATE_NAME = txtName.Text.Trim
            lData.STATE_DESC = txtDesc.Text.Trim
            lData.STATE_ORDER = IIf(txtOrder.Text.Trim = "", 0, txtOrder.Text.Trim)
            lData.ACTIVE = IIf(chkActive.Checked = True, "Y", "N")

            If ValidateLogState(lData) = True Then
                Dim Proc As New FormControlProcess
                If Proc.SaveLogState(lData, Page.User.Identity.Name) = True Then
                    RaiseEvent CommitChange(sender, e)
                Else
                    popMessage1.ShowMessage(UserControl_popMessage.MsgType.Exclamation, Proc.ErrorMessage, "Invalid Data")
                End If
            Else
                zPop.Show()
            End If
        ElseIf txtMasterTableName.Text = "SCREEN" Then
            Dim sData As New ScreenData
            sData.ID = IIf(txtID.Text.Trim = "", 0, txtID.Text)
            sData.MODULE_ID = cmbModule.SelectedValue
            sData.SCREEN_CODE = txtCode.Text.Trim
            sData.SCREEN_NAME = txtName.Text.Trim
            sData.SCREEN_DESC = txtDesc.Text.Trim
            sData.SCREEN_ORDER = IIf(txtOrder.Text.Trim = "", 0, txtOrder.Text.Trim)

            If ValidateScreen(sData) = True Then
                Dim Proc As New FormControlProcess
                If Proc.SaveScreen(sData, Page.User.Identity.Name) = True Then
                    RaiseEvent CommitChange(sender, e)
                Else
                    popMessage1.ShowMessage(UserControl_popMessage.MsgType.Exclamation, Proc.ErrorMessage, "Invalid Data")
                End If
            Else
                zPop.Show()
            End If
        ElseIf txtMasterTableName.Text = "MODULE" Then
            Dim mData As New ModuleData
            mData.ID = IIf(txtID.Text.Trim = "", 0, txtID.Text)
            mData.PROJECT_ID = cmbProject.SelectedValue
            mData.MODULE_CODE = txtCode.Text.Trim
            mData.MODULE_NAME = txtName.Text.Trim
            mData.MODULE_DESC = txtDesc.Text.Trim
            mData.MODULE_ORDER = IIf(txtOrder.Text.Trim = "", 0, txtOrder.Text.Trim)

            If ValidateModule(mData) = True Then
                Dim Proc As New FormControlProcess
                If Proc.SaveModule(mData, Page.User.Identity.Name) = True Then
                    RaiseEvent CommitChange(sender, e)
                Else
                    popMessage1.ShowMessage(UserControl_popMessage.MsgType.Exclamation, Proc.ErrorMessage, "Invalid Data")
                End If
            Else
                zPop.Show()
            End If
        End If
    End Sub
    Private Function ValidateModule(ByVal data As ModuleData) As Boolean
        Dim ret As Boolean = True
        If cmbProject.SelectedValue = "0" Then
            cmbProject.ValidateText = "กรุณาเลือกชื่อโครงการ"
            cmbProject.Focus()
        ElseIf data.MODULE_CODE.Trim = "" Then
            txtCode.ValidationText = "กรุณากรอกรหัสของโมดูล"
            txtCode.Focus()
        ElseIf data.MODULE_NAME.Trim = "" Then
            txtName.ValidationText = "กรุณากรอกชื่อของโมดูล"
            txtName.Focus()
        ElseIf data.MODULE_ORDER = 0 Then
            txtOrder.ValidationText = "กรุณากรอกลำดับ"
            txtOrder.Focus()
        Else
            Dim Proc As New FormControlProcess
            ret = Proc.chkDupModule(data)
            If ret = False Then
                txtName.ValidationText = Proc.ErrorMessage
                txtName.Focus()
            End If
        End If
        Return ret
    End Function
    Private Function ValidateScreen(ByVal data As ScreenData) As Boolean
        Dim ret As Boolean = True
        If data.MODULE_ID = 0 Then
            cmbModule.ValidateText = "กรุณาเลือกโมดูล"
            cmbModule.Focus()
        ElseIf data.SCREEN_CODE.Trim = "" Then
            txtCode.ValidationText = "กรุณากรอกรหัสของหน้าจอ"
            txtCode.Focus()
        ElseIf data.SCREEN_NAME.Trim = "" Then
            txtName.ValidationText = "กรุณากรอกชื่อของหน้าจอ"
            txtName.Focus()
        ElseIf data.SCREEN_ORDER = 0 Then
            txtOrder.ValidationText = "กรุณากรอกลำดับ"
            txtOrder.Focus()
        Else
            Dim Proc As New FormControlProcess
            ret = Proc.chkDupScreen(data)
            If ret = False Then
                txtName.ValidationText = Proc.ErrorMessage
                txtName.Focus()
            End If
        End If
        Return ret
    End Function
    Private Function ValidateLogState(ByVal data As LogStateData) As Boolean
        Dim ret As Boolean = True
        If data.STATE_NAME.Trim = "" Then
            txtName.ValidationText = "กรุณากรอกชื่อสถานะ"
            txtName.Focus()
        ElseIf data.STATE_ORDER = 0 Then
            txtOrder.ValidationText = "กรุณากรอกลำดับ"
            txtOrder.Focus()
        Else
            Dim Proc As New FormControlProcess
            ret = Proc.chkDupLogState(data)
            If ret = False Then
                txtName.ValidationText = Proc.ErrorMessage
                txtName.Focus()
            End If
        End If
        Return ret
    End Function
    Private Function ValidateLogType(ByVal data As LogTypeData) As Boolean
        Dim ret As Boolean = True
        If data.TYPE_NAME.Trim = "" Then
            ret = False
            txtName.ValidationText = "กรุณากรอกชื่อประเภท"
            txtName.Focus()
        ElseIf data.TYPE_ORDER = 0 Then
            ret = False
            txtOrder.ValidationText = "กรุณากรอกลำดับ"
            txtOrder.Focus()
        Else
            Dim Proc As New FormControlProcess
            ret = Proc.chkDupLogType(data)
            If ret = False Then
                txtName.ValidationText = Proc.ErrorMessage
                txtName.Focus()
            End If
        End If

        Return ret
    End Function
    Private Function ValidateResolvedStatus(ByVal data As ResolvedStatusData) As Boolean
        Dim ret As Boolean = True
        If data.STATUS_NAME.Trim = "" Then
            ret = False
            txtName.ValidationText = "กรุณากรอกสถานะ"
            txtName.Focus()
        ElseIf data.STATUS_ORDER = 0 Then
            ret = False
            txtOrder.ValidationText = "กรุณากรอกลำดับ"
            txtOrder.Focus()
        Else
            Dim Proc As New FormControlProcess
            ret = Proc.chkDupResolveStatus(data)
            If ret = False Then
                txtName.ValidationText = Proc.ErrorMessage
                txtName.Focus()
            End If
        End If

        Return ret
    End Function
    Private Function ValidateLogStatus(ByVal data As LogStatusData) As Boolean
        Dim ret As Boolean = True
        If data.STATUS_NAME.Trim = "" Then
            ret = False
            txtName.ValidationText = "กรุณากรอกสถานะ"
            txtName.Focus()
        ElseIf data.STATUS_ORDER = 0 Then
            ret = False
            txtOrder.ValidationText = "กรุณากรอกลำดับ"
            txtOrder.Focus()
        Else
            Dim Proc As New FormControlProcess
            ret = Proc.chkDupLogStatus(data)
            If ret = False Then
                txtName.ValidationText = Proc.ErrorMessage
                txtName.Focus()
            End If
        End If

        Return ret
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If txtMasterTableName.Text = "LOG_TYPE" Then
            rwCode.Visible = False
        ElseIf txtMasterTableName.Text = "LOG_STATUS" Then
            rwCode.Visible = False
        ElseIf txtMasterTableName.Text = "RESOLVED_STATUS" Then
            rwCode.Visible = False
        ElseIf txtMasterTableName.Text = "LOG_STATE" Then
            rwCode.Visible = False
        ElseIf txtMasterTableName.Text = "SCREEN" Then
            rwModuleID.Visible = True
            rwActive.Visible = False
        ElseIf txtMasterTableName.Text = "MODULE" Then
            rwActive.Visible = False
            rwProjectID.Visible = True
        End If
    End Sub
End Class
