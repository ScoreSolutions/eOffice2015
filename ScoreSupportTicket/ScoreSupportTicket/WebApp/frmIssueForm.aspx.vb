Imports XCS.Process.Common
Imports XCS.Process.Master
Imports XCS.Data.Table
Imports XCS.Data.Common
Imports XCS.Data.Common.Utilities
Imports System.IO
Imports System.Text


Partial Class WebApp_frmIssueForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            Dim trans As New DbTransProcess
            trans.CreateTransaction()
            If Func.ChkLogin() = False Then
                Response.Redirect(FormsAuthentication.LoginUrl)
            End If

            Dim frm As Template_MasterPage
            frm = Me.Master
            frm.SetPageName("Issue Log")

            SetComboProject()
            SetComboPriority()
            SetComboLevel()

            

            If Func.GetConfigValue(Constant.SysConfigName.AdminID, trans) <> Func.GetLogOnUser.ID Then
                cmbAddRaiseBy.ShowAddNewButton = False
                cmbAddAssignTo.ShowAddNewButton = False
                cmbAddCloseBy.ShowAddNewButton = False
            End If
            trans.CommitTransaction()
        End If
    End Sub

    Private Sub SetComboProject()
        Dim Proc As New IssueFormProcess
        cmbProject.SetItemList(Proc.GetProjectList(Page.User.Identity.Name), "project_name", "id")
        cmbAddModule.RefMasterID = cmbProject.SelectedValue
    End Sub

    Private Sub SetComboPriority()
        cmbAddPriority.SetItemList("Low", "L")
        cmbAddPriority.SetItemList("Medium", "M")
        cmbAddPriority.SetItemList("Height", "H")
    End Sub
    Private Sub SetComboLevel()
        cmbComplexityLevel.SetItemList("------Select", "")
        cmbComplexityLevel.SetItemList("Low", "L")
        cmbComplexityLevel.SetItemList("Medium", "M")
        cmbComplexityLevel.SetItemList("Height", "H")
    End Sub

    Protected Sub cmbAddModule_SelectedIndexChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAddModule.SelectedIndexChange
        cmbAddScreen.RefMasterID = cmbAddModule.SelectedValue
        cmbAddScreen.SetCombo()
    End Sub

    Private Sub ClearValidate()
        cmbProject.ValidateText = ""
        cmbAddType.ValidateText = ""
        txtAddDesc.ValidationText = ""
        cmbAddStatus.ValidateText = ""
        cmbAddState.ValidateText = ""
        cmbAddModule.ValidateText = ""
        cmbAddScreen.ValidateText = ""
        cmbAddRaiseBy.ValidationText = ""
        txtAddRaiseDate.ValidateText = ""
        txtAddExpectedDate.ValidateText = ""
        txtAddCloseDate.ValidateText = ""
        cmbAddCloseBy.ValidationText = ""
    End Sub

    Private Function ValidateData() As Boolean
        Dim ret As Boolean = True
        ClearValidate()
        If cmbProject.SelectedValue = "0" Then
            ret = False
            'cmbProject.ValidateText = "กรุณาเลือกโครงการ"
            Func.SetAlert("กรุณาเลือกโครงการ", Me, cmbProject.ClientID)
        ElseIf cmbAddType.SelectedValue = "0" Then
            ret = False
            cmbAddType.ValidateText = "กรุณาเลือกประเภท"
            'Func.SetAlert("กรุณาเลือกประเภท", Me)
        ElseIf txtAddDesc.Text.Trim = "" Then
            ret = False
            txtAddDesc.ValidationText = "กรุณากรอกรายละเอียด"
            'Func.SetAlert("กรุณากรอกรายละเอียด", Me)
        ElseIf cmbAddStatus.SelectedValue = "0" Then
            ret = False
            cmbAddStatus.ValidateText = "กรุณาเลือกสถานะ"
            'Func.SetAlert("กรุณาเลือกสถานะ", Me)
            'ElseIf cmbAddState.SelectedValue = "0" Then
            '    ret = False
            '    cmbAddState.ValidateText = "กรุณาเลือกสถานะ"
            '    'Func.SetAlert("กรุณาเลือกสถานะ", Me)
        ElseIf cmbAddModule.SelectedValue = "0" Then
            ret = False
            cmbAddModule.ValidateText = "กรุณาเลือกโมดูล"
            'Func.SetAlert("กรุณาเลือกโมดูล", Me)
            'ElseIf cmbAddScreen.SelectedValue = "0" Then
            '    ret = False
            '    cmbAddScreen.ValidateText = "กรุณาเลือกหน้าจอ"
            '    'Func.SetAlert("กรุณาเลือกหน้าจอ", Me)
        ElseIf cmbAddRaiseBy.SelectedValue = "" Then
            ret = False
            cmbAddRaiseBy.ValidationText = "กรุณาเลือกผู้แจ้งปัญหา"
            'Func.SetAlert("กรุณาเลือกผู้แจ้งปัญหา", Me)
        ElseIf txtAddRaiseDate.TxtBox.Text = "" Then
            ret = False
            txtAddRaiseDate.ValidateText = "กรุณาเลือกวันที่แจ้งปัญหา"
            'Func.SetAlert("กรุณาเลือกวันที่แจ้งปัญหา", Me)
        ElseIf txtAddExpectedDate.TxtBox.Text = "" Then
            ret = False
            txtAddExpectedDate.ValidateText = "กรุณาเลือกวันที่คาดว่าจะเสร็จ"
            'Func.SetAlert("กรุณาเลือกวันที่คาดว่าจะเสร็จ", Me)
        Else
            Dim trans As New XCS.Process.Common.DbTransProcess
            trans.CreateTransaction()
            If cmbAddStatus.SelectedValue = Func.GetConfigValue(Constant.SysConfigName.StatusClose, trans) Then
                If txtAddCloseDate.TxtBox.Text = "" Then
                    ret = False
                    txtAddCloseDate.ValidateText = "กรุณาเลือกวันที่ปิด"
                    'Func.SetAlert("กรุณาเลือกวันที่ปิด", Me)
                ElseIf cmbAddCloseBy.SelectedValue = "" Then
                    ret = False
                    cmbAddCloseBy.ValidationText = "กรุณาเลือกผู้ปิด"
                    'Func.SetAlert("กรุณาเลือกผู้ปิด", Me)
                End If
            End If
            trans.CommitTransaction()
        End If

        Return ret
    End Function

    Private Function GetLogData() As IssueTrackingLogData
        Dim iData As New IssueTrackingLogData
        iData.ID = IIf(txtID.Value = "", 0, txtID.Value)
        iData.PROJECT_ID = cmbProject.SelectedValue
        iData.LOG_NO = IIf(iData.ID = 0, GenLogNO(), txtAddLogNo.Text)
        iData.REF_REQUEST_NO = txtRefReqNo.Text.Trim
        iData.TYPE_ID = cmbAddType.SelectedValue
        iData.LOG_DESC = txtAddDesc.Text
        iData.STATUS_ID = cmbAddStatus.SelectedValue
        iData.PRIORITY = cmbAddPriority.SelectedValue
        iData.STATE_ID = cmbAddState.SelectedValue
        iData.LOG_INSTANCE = txtAddInstance.Text
        iData.SCREEN_ID = cmbAddScreen.SelectedValue
        iData.MODULE_ID = cmbAddModule.SelectedValue
        iData.RAISED_BY = cmbAddRaiseBy.SelectedValue
        iData.RAISED_ON = txtAddRaiseDate.DateValue
        iData.CHANGE_APPROVE = chkAddChangeRequest.SelectedValue
        iData.COMMENTS = txtAddComment.Text
        iData.ASSIGNED_TO = cmbAddAssignTo.SelectedValue
        iData.ASSIGNED_DATE = txtAddAssignDate.DateValue
        iData.EXPECTED_CLOSED_DATE = txtAddExpectedDate.DateValue
        iData.CLOSED_BY = cmbAddCloseBy.SelectedValue
        iData.CLOSED_DATE = txtAddCloseDate.DateValue

        iData.ESTIMATE_FIXED_DATE = txtEstimateFixedDate.DateValue
        iData.RESOLVE_STATUS_ID = cmbResolvedStatus.SelectedValue
        iData.COMPLEXITY_LEVEL = cmbComplexityLevel.SelectedValue
        iData.RESOLVED_COMMENT = txtResolveComment.Text
        iData.RESOLVED_DATE = txtResolveDate.DateValue
        iData.RESOLUTION = ctlResolution.Text

        Return iData
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If ValidateData() = True Then
            Dim Proc As New IssueFormProcess
            If Proc.SaveIssueTrackingLog(GetLogData(), Func.GetUserName) = True Then
                SetData(Proc.ID)
                'popSaveComplete.ShowMessage(UserControl_popMessage.MsgType.Information, "บันทึกข้อมูลเรียบร้อย", "Save Complete")
                Func.SetAlert("บันทึกข้อมูลเรียบร้อย", Me)
            Else
                'popErr.ShowMessage(UserControl_popMessage.MsgType.Exclamation, Proc.ErrorMessage, "Error")
                Func.SetAlert(Proc.ErrorMessage, Me)
            End If
        End If
    End Sub

    Private Function GenLogNO() As String
        Dim Proc As New IssueFormProcess
        Return Proc.GenLogNo(cmbProject.SelectedValue)
    End Function

    Private Sub SetData(ByVal vID As Long)
        If vID <> 0 Then
            Dim trans As New DbTransProcess
            trans.CreateTransaction()

            Dim Proc As New IssueFormProcess
            Dim lData As New IssueTrackingLogData
            lData = Proc.GetIssueDataByID(vID, trans)
            'trans.CommitTransaction()

            txtID.Value = lData.ID
            cmbProject.SelectedValue = lData.PROJECT_ID
            Dim vYear As String = lData.CREATE_ON.ToString("yyyy", New Globalization.CultureInfo("en-US"))

            txtAddLogNo.Text = IIf(lData.LOG_NO = 0, "NEW", lData.LOG_NO)
            txtLogNo.Text = IIf(lData.LOG_NO = 0, "NEW", vYear & lData.LOG_NO.ToString.PadLeft(4, "0"))
            txtRefReqNo.Text = lData.REF_REQUEST_NO
            cmbAddType.SelectedValue = lData.TYPE_ID
            txtAddDesc.Text = lData.LOG_DESC
            cmbAddStatus.SelectedValue = lData.STATUS_ID
            cmbAddPriority.SelectedValue = lData.PRIORITY
            cmbAddState.SelectedValue = lData.STATE_ID
            txtAddInstance.Text = lData.LOG_INSTANCE

            cmbAddModule.RefMasterID = lData.PROJECT_ID
            cmbAddModule.SetCombo()
            cmbAddModule.SelectedValue = lData.MODULE_ID

            cmbAddScreen.RefMasterID = lData.MODULE_ID
            cmbAddScreen.SetCombo()
            cmbAddScreen.SelectedValue = lData.SCREEN_ID

            cmbAddRaiseBy.ProjectID = lData.PROJECT_ID
            cmbAddRaiseBy.SetCombo()
            cmbAddRaiseBy.SelectedValue = lData.RAISED_BY

            txtAddRaiseDate.DateValue = IIf(lData.ID = 0, IIf(txtAddRaiseDate.DefaultCurrentDate = True, DateTime.Now, New Date()), lData.RAISED_ON)
            'chkAddChangeRequest.SelectedValue = IIf(lData.CHANGE_APPROVE = "Y", True, False)
            chkAddChangeRequest.SelectedValue = lData.CHANGE_APPROVE
            txtAddComment.Text = lData.COMMENTS

            cmbAddAssignTo.ProjectID = lData.PROJECT_ID
            cmbAddAssignTo.SetCombo()
            cmbAddAssignTo.SelectedValue = lData.ASSIGNED_TO
            txtAddAssignDate.DateValue = IIf(lData.ID = 0, IIf(txtAddAssignDate.DefaultCurrentDate = True, DateTime.Now, New Date()), lData.ASSIGNED_DATE)
            txtAddExpectedDate.DateValue = lData.EXPECTED_CLOSED_DATE

            cmbAddCloseBy.ProjectID = lData.PROJECT_ID
            cmbAddCloseBy.SetCombo()
            cmbAddCloseBy.SelectedValue = lData.CLOSED_BY
            txtAddCloseDate.DateValue = lData.CLOSED_DATE

            txtEstimateFixedDate.DateValue = lData.ESTIMATE_FIXED_DATE
            cmbResolvedStatus.SelectedValue = lData.RESOLVE_STATUS_ID
            cmbComplexityLevel.SelectedValue = lData.COMPLEXITY_LEVEL
            txtResolveComment.Text = lData.RESOLVED_COMMENT
            txtResolveDate.DateValue = lData.RESOLVED_DATE
            ctlResolution.Text = lData.RESOLUTION


            Dim uData As LoggedOnStaffData = Func.GetLogOnUser
            If lData.CREATE_BY.ToUpper <> uData.USERNAME.ToUpper Then
                txtRefReqNo.TextType = UserControls_txtBox.TextboxType.TextView
                cmbAddType.Enabled = False
                cmbAddStatus.Enabled = False
                cmbAddPriority.Enabled = False
                cmbAddState.Enabled = False
                cmbAddModule.Enabled = False
                cmbAddScreen.Enabled = False
                txtAddInstance.TextType = UserControls_txtBox.TextboxType.TextView
                chkAddChangeRequest.Enabled = False
                txtAddComment.TextType = UserControls_txtBox.TextboxType.TextView
                cmbAddRaiseBy.Enabled = False
                cmbAddAssignTo.Enabled = False
                txtAddRaiseDate.VisibleImg = False
                txtAddAssignDate.VisibleImg = False
                txtAddExpectedDate.VisibleImg = False
                cmbAddCloseBy.Enabled = False
                txtAddCloseDate.VisibleImg = False
                txtAddDesc.Enabled = False
            End If
            If lData.ASSIGNED_TO.ToUpper <> uData.USERNAME.ToUpper Then
                txtAddExpectedDate.VisibleImg = False
                cmbResolvedStatus.Enabled = False
                cmbComplexityLevel.Enabled = False
                txtResolveComment.Enabled = False
                txtResolveDate.VisibleImg = False
                ctlResolution.Enabled = False
            End If
            If uData.CAN_CLOSE = "Y" Then
                cmbAddStatus.Enabled = True
                cmbAddCloseBy.Enabled = True
                txtAddCloseDate.VisibleImg = True
            End If

            trans.CommitTransaction()
        Else
            'Default
            txtID.Value = vID
            txtAddLogNo.Text = "NEW"
            txtAddRaiseDate.DateValue = IIf(txtAddRaiseDate.DefaultCurrentDate = True, DateTime.Now, New Date())
            txtAddAssignDate.DateValue = IIf(txtAddAssignDate.DefaultCurrentDate = True, DateTime.Now, New Date())
        End If

        SetFileList(txtID.Value)
    End Sub


    Protected Sub cmbProject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProject.SelectedIndexChanged
        cmbAddModule.RefMasterID = cmbProject.SelectedValue
        cmbAddModule.SetCombo()

        cmbAddScreen.RefProjectID = cmbProject.SelectedValue

        cmbAddRaiseBy.ProjectID = cmbProject.SelectedValue
        cmbAddRaiseBy.SetCombo()
        cmbAddAssignTo.ProjectID = cmbProject.SelectedValue
        cmbAddAssignTo.SetCombo()
        cmbAddCloseBy.ProjectID = cmbProject.SelectedValue
        cmbAddCloseBy.SetCombo()
    End Sub



    Protected Sub lnkDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim trans As New DbTransProcess
        trans.CreateTransaction()
        Dim Proc As New IssueFormProcess
        Dim aData As New IssueLogAttachFileData
        aData = Proc.GetAttachData(sender.CommandArgument, trans)
        trans.CommitTransaction()
        If Proc.DeleteAttachFile(sender.CommandArgument) = False Then
            popErr.ShowMessage(UserControl_popMessage.MsgType.Exclamation, Proc.ErrorMessage, "Delete Error")
        Else
            If File.Exists(Func.GetUploadPath() & aData.FILE_NAME & "." & aData.FILE_EXTENTION) Then
                File.Delete(Func.GetUploadPath() & aData.FILE_NAME & "." & aData.FILE_EXTENTION)
            End If
            SetFileList(txtID.Value)
        End If
    End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click

        'If FileBrowse.HasFile = True Then
        If Session("TmpFileData") IsNot Nothing Then
            Dim fData As New TmpFileUploadData
            fData = Session("TmpFileData")

            Dim aData As New IssueLogAttachFileData
            aData.ISSUE_TRACKING_LOG_ID = IIf(txtID.Value = "", 0, txtID.Value)
            aData.FILE_NAME = GenFileName()
            aData.FILE_DESC = txtFileDesc.Text
            aData.FILE_EXTENTION = fData.FileExtent 'GetFileExtent(FileBrowse.FileName)

            Dim Proj As New IssueFormProcess
            If Proj.SaveAttachFile(aData, Func.GetUserName) = True Then
                Dim fs As FileStream
                Dim byteData() As Byte
                byteData = fData.TmpFileByte

                fs = New FileStream(Func.GetUploadPath & aData.FILE_NAME & "." & aData.FILE_EXTENTION, FileMode.CreateNew)
                fs.Write(byteData, 0, byteData.Length)
                fs.Close()

                Session.Contents.Remove("TmpFileData")
                'FileBrowse.SaveAs(Func.GetUploadPath() & aData.FILE_NAME & "." & aData.FILE_EXTENTION)
                SetFileList(txtID.Value)
            Else
                popErr.ShowMessage(UserControl_popMessage.MsgType.Exclamation, Proj.ErrorMessage, "Error")
            End If
        End If
        'End If
    End Sub
    Private Sub SetFileList(ByVal LogID As Long)
        If LogID <> 0 Then
            'ctlFile.Tabs(1).Visible = False
            trBrowseFile.Visible = True

            txtFileDesc.Text = ""
            Dim Proj As New IssueFormProcess
            gvFileList.DataSource = Proj.GetFileList(LogID)
            gvFileList.DataBind()
        Else
            trBrowseFile.Visible = False
        End If
    End Sub

    Private Function GenFileName() As String
        Dim Proc As New IssueFormProcess
        Return Proc.GetLastFileName(GetLogData())

    End Function

    Private Function GetFileExtent(ByVal FileName As String) As String
        Dim file() As String = Split(FileName, ".")
        Return file(file.Length - 1)
    End Function

    Const ListCellID As Integer = 0
    Const ListCellLinkName As Integer = 1

    Protected Sub gvFileList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvFileList.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblLinkName As Label = e.Row.Cells(ListCellLinkName).FindControl("lblFileName")
            Dim Proc As New IssueFormProcess
            Dim data As New IssueLogAttachFileData
            Dim trans As New DbTransProcess
            trans.CreateTransaction()
            data = Proc.GetAttachData(e.Row.Cells(ListCellID).Text, trans)
            trans.CommitTransaction()
            lblLinkName.Text = "<a href='http://" & Func.GetImageUrl(Request) & data.FILE_NAME & "." & data.FILE_EXTENTION & "?time=" & Today.Now.ToString("HH:mm:ss") & "' target='_blank' >" & data.FILE_NAME & "." & data.FILE_EXTENTION & "</a>"
        End If
    End Sub

    Protected Sub FileBrowse_UploadedComplete(ByVal sender As Object, ByVal e As AjaxControlToolkit.AsyncFileUploadEventArgs) Handles FileBrowse.UploadedComplete
        'If FileBrowse.FileBytes().Length <= 10 * 1024 * 1024 Then
        If e.state = AjaxControlToolkit.AsyncFileUploadState.Success Then
            Dim fData As New TmpFileUploadData
            fData.TmpFileByte = FileBrowse.FileBytes
            fData.FileExtent = GetFileExtent(FileBrowse.FileName)
            'Session.Timeout = 60
            Session("TmpFileData") = fData
        End If
        'Else
        'FileBrowse.BackColor = Drawing.Color.Red
        'e.state = AjaxControlToolkit.AsyncFileUploadState.Failed
        'End If
    End Sub
    Private Sub SetSelectStaff()
        Dim cmbRaiseByVal As String = cmbAddRaiseBy.SelectedValue
        cmbAddRaiseBy.SetCombo()
        cmbAddRaiseBy.SelectedValue = cmbRaiseByVal

        Dim cmbAssignToVal As String = cmbAddAssignTo.SelectedValue
        cmbAddAssignTo.SetCombo()
        cmbAddAssignTo.SelectedValue = cmbAssignToVal

        Dim cmbCloseByVal As String = cmbAddCloseBy.SelectedValue
        cmbAddCloseBy.SetCombo()
        cmbAddCloseBy.SelectedValue = cmbCloseByVal
    End Sub

    Protected Sub cmbAddRaiseBy_SaveComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAddRaiseBy.SaveComplete
        SetSelectStaff()
    End Sub

    Protected Sub cmbAddAssignTo_SaveComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAddAssignTo.SaveComplete
        SetSelectStaff()
    End Sub

    Protected Sub cmbAddCloseBy_SaveComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAddCloseBy.SaveComplete
        SetSelectStaff()
    End Sub

    Protected Sub FileBrowse_UploadedFileError(ByVal sender As Object, ByVal e As AjaxControlToolkit.AsyncFileUploadEventArgs) Handles FileBrowse.UploadedFileError
        lblFileLimit.BackColor = Drawing.Color.Red
    End Sub

    Protected Sub cmbAddStatus_SelectedIndexChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAddStatus.SelectedIndexChange
        Dim trans As New DbTransProcess
        trans.CreateTransaction()
        If cmbAddStatus.SelectedValue = FunctionProcess.GetConfigValue(Constant.SysConfigName.StatusClose, trans) Then
            cmbAddCloseBy.Enabled = True
            cmbAddCloseBy.ShowAddNewButton = True
            txtAddCloseDate.VisibleImg = True
        Else
            cmbAddCloseBy.SelectedValue = cmbAddCloseBy.DefaultValue
            cmbAddCloseBy.Enabled = False
            cmbAddCloseBy.ShowAddNewButton = False
            txtAddCloseDate.DateValue = New Date
            txtAddCloseDate.VisibleImg = False
        End If
        trans.CommitTransaction()
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If IsPostBack = False Then
            If Request.QueryString("id") IsNot Nothing Then
                'If Session("LogID") <> "" Then
                SetData(Request.QueryString("id"))
                cmbProject.Enabled = False
            Else
                SetData(0)
            End If
        End If
    End Sub
End Class
