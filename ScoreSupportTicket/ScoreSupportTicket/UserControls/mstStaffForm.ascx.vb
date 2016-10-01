Imports XCS.Process.Master
Imports XCS.Data.Table
Imports System.Data
Imports XCS.Data.Common.Utilities

Partial Class UserControls_mstStaffForm
    Inherits System.Web.UI.UserControl

    Public Event SaveComplete(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event CloseClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Public Event ValidAlert()

    Public WriteOnly Property PageName() As String
        Set(ByVal value As String)
            lblPageName.Text = value
        End Set
    End Property
    Public WriteOnly Property ShowClose() As Boolean
        Set(ByVal value As Boolean)
            rwClose.Visible = value
        End Set
    End Property

    Public ReadOnly Property TextUserName() As TextBox
        Get
            Return txtUserName.TxtBox
        End Get
    End Property

    Public Sub SetProjectList()
        Dim trans As New XCS.Process.Common.DbTransProcess
        trans.CreateTransaction()
        Dim Proc As New StaffFormProcess
        Dim dt As DataTable
        If FunctionProcess.GetConfigValue(Constant.SysConfigName.AdminID, trans) = Func.GetLogOnUser.ID Then
            dt = Proc.GetProjectList(trans)
        Else
            dt = Proc.GetProjectList(trans)


            'Dim dts As DataTable = Proc.GetProjectStaff(Func.GetLogOnUser.ID, trans)
            'If dts.Rows.Count > 0 Then
            '    dt = New DataTable
            '    dt.Columns.Add("id")
            '    dt.Columns.Add("project_name")
            '    For i As Integer = 0 To dts.Rows.Count - 1
            '        Dim dr = dt.NewRow
            '        dr("id") = dts.Rows(i)("project_id")
            '        Dim pjData As ProjectData = Proc.GetProjectData(dts.Rows(i)("project_id"), trans)
            '        dr("project_name") = pjData.PROJECT_CODE & ": " & pjData.PROJECT_NAME
            '        dt.Rows.Add(dr)
            '    Next
            'End If
        End If
        trans.CommitTransaction()
        chkProjectList.DataSource = dt
        chkProjectList.DataTextField = "project_name"
        chkProjectList.DataValueField = "id"
        chkProjectList.DataBind()
    End Sub

    Public Sub ClearForm()
        txtID.Text = ""
        txtUserName.Text = ""
        txtPwd.Text = ""
        txtConfirmPwd.Text = ""
        txtStaffName.Text = ""
        txtPositionName.Text = ""
        txtDivisionName.Text = ""
        chkRaise.Checked = True
        chkAcceptAssign.Checked = True
        chkClose.Checked = True
        chkActive.Checked = True

        For i As Integer = 0 To chkProjectList.Items.Count - 1
            chkProjectList.Items(i).Selected = False
        Next
    End Sub


    Protected Sub imgClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgClose.Click
        ClearForm()
        RaiseEvent CloseClick(sender, e)
    End Sub

    Private Sub SetStaffData(ByVal vID As Long)
        If vID <> 0 Then
            Dim trans As New XCS.Process.Common.DbTransProcess
            trans.CreateTransaction()
            Dim Proc As New StaffFormProcess
            Dim sData As New StaffData
            sData = Proc.GetStaffData(vID, trans)
            txtID.Text = sData.ID
            txtUserName.Text = sData.USERNAME
            txtPwd.Text = sData.PWD
            txtConfirmPwd.Text = sData.PWD
            txtStaffName.Text = sData.STAFFNAME
            txtPositionName.Text = sData.POSITION_NAME
            txtDivisionName.Text = sData.DIVISION_NAME
            chkRaise.Checked = IIf(sData.CAN_RAISE = "Y", True, False)
            chkAcceptAssign.Checked = IIf(sData.CAN_ACCEPT_ASSIGNMENT = "Y", True, False)
            chkClose.Checked = IIf(sData.CAN_CLOSE = "Y", True, False)
            chkActive.Checked = IIf(sData.ACTIVE = "Y", True, False)

            For i As Integer = 0 To chkProjectList.Items.Count - 1
                Dim dt As DataTable = Proc.GetProjectStaff(vID, trans)
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        If chkProjectList.Items(i).Value = dr("project_id") Then
                            chkProjectList.Items(i).Selected = True
                            If FunctionProcess.GetConfigValue(Constant.SysConfigName.AdminID, trans) = Func.GetLogOnUser.ID Or FunctionProcess.GetConfigValue(Constant.SysConfigName.PrapojID, trans) = Func.GetLogOnUser.ID Then
                                chkProjectList.Items(i).Enabled = True
                            Else
                                chkProjectList.Items(i).Enabled = False
                            End If
                        End If
                    Next
                End If
            Next
            trans.CommitTransaction()
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim sData As New StaffData
        sData.ID = IIf(txtID.Text.Trim = "", 0, txtID.Text)
        sData.USERNAME = txtUserName.Text.Trim
        sData.PWD = txtPwd.Text.Trim
        sData.STAFFNAME = txtStaffName.Text.Trim
        sData.POSITION_NAME = txtPositionName.Text.Trim
        sData.DIVISION_NAME = txtDivisionName.Text.Trim
        sData.CAN_RAISE = IIf(chkRaise.Checked, "Y", "N")
        sData.CAN_ACCEPT_ASSIGNMENT = IIf(chkAcceptAssign.Checked, "Y", "N")
        sData.CAN_CLOSE = IIf(chkClose.Checked, "Y", "N")
        sData.ACTIVE = IIf(chkActive.Checked, "Y", "N")

        If ValidateData(sData) = True Then

            Dim pDt As New DataTable
            pDt.Columns.Add("project_id")
            For i As Integer = 0 To chkProjectList.Items.Count - 1
                If chkProjectList.Items(i).Selected = True Then
                    Dim dr As DataRow = pDt.NewRow
                    dr("project_id") = chkProjectList.Items(i).Value
                    pDt.Rows.Add(dr)
                End If
            Next

            Dim Proc As New StaffFormProcess
            If Proc.SaveStaffData(Page.User.Identity.Name, sData, pDt) = True Then
                SetStaffData(Proc.StaffID)
                RaiseEvent SaveComplete(sender, e)
            Else
                'popMessage1.ShowMessage(UserControl_popMessage.MsgType.Exclamation, Proc.ErrorMessage, "Save Data")
                Func.SetAlert(Proc.ErrorMessage, Me.Page, txtUserName.ClientID)
            End If
        End If

    End Sub

    Private Function ValidateData(ByVal data As StaffData) As Boolean
        Dim ret As Boolean = True
        If data.USERNAME = "" Then
            ret = False
            'popMessage1.ShowMessage(UserControl_popMessage.MsgType.Exclamation, "กรุณากรอกชื่อเข้าระบบ", "Validate Data")
            Func.SetAlert("กรุณากรอกชื่อเข้าระบบ", Me.Page, txtUserName.ClientID)
            'txtUserName.ValidationText = "กรุณากรอกชื่อเข้าระบบ"
        ElseIf data.PWD = "" And data.ID = 0 Then
            ret = False
            'popMessage1.ShowMessage(UserControl_popMessage.MsgType.Exclamation, "กรุณากรอกรหัสผ่าน", "Validate Data")
            Func.SetAlert("กรุณากรอกรหัสผ่าน", Me.Page, txtPwd.ClientID)
            'txtPwd.ValidationText = "กรุณากรอกรหัสผ่าน"
        ElseIf txtConfirmPwd.Text <> txtPwd.Text Then
            ret = False
            'popMessage1.ShowMessage(UserControl_popMessage.MsgType.Exclamation, "การยืนยันรหัสผ่านไม่ถูกต้อง", "Validate Data")
            Func.SetAlert("การยืนยันรหัสผ่านไม่ถูกต้อง", Me.Page, txtConfirmPwd.ClientID)
            'txtConfirmPwd.Text = "การยืนยันรหัสผ่านไม่ถูกต้อง"
        ElseIf data.STAFFNAME = "" Then
            ret = False
            'popMessage1.ShowMessage(UserControl_popMessage.MsgType.Exclamation, "ชื่อผู้ใช้", "Validate Data")
            Func.SetAlert("กรุณากรอกชื่อผู้ใช้", Me.Page, txtStaffName.ClientID)
            'txtStaffName.ValidationText = "กรุณากรอกชื่อผู้ใช้"
        Else
            Dim Proc As New StaffFormProcess
            If Proc.chkDupStaff(data) = False Then
                ret = False
                'popMessage1.ShowMessage(UserControl_popMessage.MsgType.Exclamation, "ข้อมูลซ้ำ", "Validate Data")
                Func.SetAlert("ข้อมูลซ้ำ", Me.Page, txtUserName.ClientID)
                'txtUserName.ValidationText = "ชื่อเข้าระบบซ้ำ"
            End If
        End If

        RaiseEvent ValidAlert()

        Return ret
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            If Request("id") IsNot Nothing Then
                SetStaffData(Request("id"))
            End If
        End If
    End Sub
End Class
