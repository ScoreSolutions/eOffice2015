Imports XCS.Process.Master
Imports XCS.Data.Table
Imports System.Data
Imports XCS.Process.Common

Partial Class WebApp_frmProject
    Inherits System.Web.UI.Page


    Protected Sub lnkProjectCode_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Response.Redirect("../WebApp/frmUserForm.aspx?id=" & sender.CommandArgument & "&time=" & Today.Now.Millisecond)
        FillData(sender.CommandArgument)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            SetProjectList()
        End If
    End Sub

    Private Sub SetProjectList()
        Dim proc As New ProjectFormProcess
        Dim trans As New XCS.Process.Common.DbTransProcess
        trans.CreateTransaction()
        Dim dt As DataTable = proc.GetProjectList("1=1", "project_code", trans)
        If dt.Rows.Count > 0 Then
            dt.Columns.Add("no")
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = (i + 1)
            Next
        End If
        trans.CommitTransaction()
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateData() = True Then
            Dim data As New ProjectData
            data.ID = IIf(txtID.Value.Trim = "", "0", txtID.Value)
            data.PROJECT_CODE = txtProjectCode.Text
            data.PROJECT_NAME = txtProjectName.Text
            data.CONTRACT_NO = txtContractNo.Text
            data.CUSTOMER_NAME = txtCustomerName.Text
            data.START_YEAR = txtStartYear.Text
            data.PROJECT_DESC = txtProjectDesc.Text

            Dim proc As New ProjectFormProcess
            If proc.SaveProject(data, Func.GetLogOnUser.USERNAME) Then
                txtID.Value = proc.ID
                SetProjectList()
                Func.SetAlert("บันทึกข้อมูเรียบร้อย", Me, txtProjectCode.ClientID)
            End If

        End If
    End Sub

    Private Sub FillData(ByVal vID As Long)
        Dim trans As New DbTransProcess
        trans.CreateTransaction()
        Dim proc As New ProjectFormProcess
        Dim data As ProjectData = proc.GetProjectData(vID, trans)
        txtID.Value = data.ID
        txtProjectCode.Text = data.PROJECT_CODE
        txtProjectName.Text = data.PROJECT_NAME
        txtContractNo.Text = data.CONTRACT_NO
        txtCustomerName.Text = data.CUSTOMER_NAME
        txtStartYear.Text = data.START_YEAR.Trim
        txtProjectDesc.Text = data.PROJECT_DESC
        trans.CommitTransaction()
    End Sub

    Private Function ValidateData() As Boolean
        Dim ret = True
        If txtProjectCode.Text.Trim = "" Then
            ret = False
            Func.SetAlert("กรุณาระบุรหัสโครงการ", Me, txtProjectCode.ClientID)
        ElseIf txtProjectName.Text.Trim = "" Then
            ret = False
            Func.SetAlert("กรุณาระบุชื่อโครงการ", Me, txtProjectName.ClientID)
        ElseIf txtStartYear.Text.Trim = "" Then
            ret = False
            Func.SetAlert("กรุณาระบุปีที่เริ่มโครงการ", Me, txtStartYear.ClientID)
        ElseIf txtContractNo.Text.Trim = "" Then
            ret = False
            Func.SetAlert("กรุณาระบุเลขที่สัญญา", Me, txtContractNo.ClientID)
        ElseIf txtCustomerName.Text.Trim = "" Then
            ret = False
            Func.SetAlert("กรุณาระบุชื่อลูกค้า", Me, txtCustomerName.ClientID)
        End If
        Return ret
    End Function
End Class
