Imports System.Data
Imports XCS.Process.Master
Imports XCS.Process.Common

Partial Class UserControls_mstFormControl
    Inherits System.Web.UI.UserControl

    Public Event SelectedIndexChange(ByVal sender As Object, ByVal e As System.EventArgs)

    Public Property IsNotNull() As Boolean
        Get
            Return cmbComboBox1.IsNotNull
        End Get
        Set(ByVal value As Boolean)
            cmbComboBox1.IsNotNull = value
        End Set
    End Property
    Public Property MasterTableName() As String
        Get
            Return txtMasterTableName.Text
        End Get
        Set(ByVal value As String)
            txtMasterTableName.Text = value
            cmbMasterTableForm1.MasterTableName = value
        End Set
    End Property

    Public WriteOnly Property PageName() As String
        Set(ByVal value As String)
            cmbMasterTableForm1.PageName = value
        End Set
    End Property
    Public WriteOnly Property LabelMasterName() As String
        Set(ByVal value As String)
            cmbMasterTableForm1.MasterName = value
        End Set
    End Property
    Public WriteOnly Property RefMasterID() As String
        Set(ByVal value As String)
            txtRefMasterID.Text = value
        End Set
    End Property
    Public WriteOnly Property RefProjectID() As String
        Set(ByVal value As String)
            cmbMasterTableForm1.RefProjectID = value
        End Set
    End Property
    Public Property AutoPostBack() As Boolean
        Get
            Return cmbComboBox1.AutoPosBack
        End Get
        Set(ByVal value As Boolean)
            cmbComboBox1.AutoPosBack = value
        End Set
    End Property
    Public Property SelectedValue() As String
        Get
            Return cmbComboBox1.SelectedValue
        End Get
        Set(ByVal value As String)
            cmbComboBox1.SelectedValue = value
        End Set
    End Property
    Public ReadOnly Property SelectedText() As String
        Get
            Return cmbComboBox1.SelectedText
        End Get
    End Property
    Public WriteOnly Property ValidateText() As String
        Set(ByVal value As String)
            cmbComboBox1.ValidateText = value
        End Set
    End Property
    Public Property Enabled() As Boolean
        Get
            Return cmbComboBox1.Enabled
        End Get
        Set(ByVal value As Boolean)
            cmbComboBox1.Enabled = value
            btnAdd.Visible = value
        End Set
    End Property
    Public Property ShowAddNewButton() As Boolean
        Get
            Return btnAdd.Visible
        End Get
        Set(ByVal value As Boolean)
            btnAdd.Visible = value
        End Set
    End Property
    Public WriteOnly Property Width() As Unit
        Set(ByVal value As Unit)
            cmbComboBox1.Width = value
        End Set
    End Property
    Public WriteOnly Property DefaultValue() As String
        Set(ByVal value As String)
            cmbComboBox1.DefaultValue = value
        End Set
    End Property


    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        cmbMasterTableForm1.Show(0)
    End Sub

    Protected Sub cmbMasterTableForm1_CommitChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMasterTableForm1.CommitChange
        SetCombo()
    End Sub

    Public Sub SetCombo()
        Dim trans As New DbTransProcess
        trans.CreateTransaction()
        Dim Proc As New FormControlProcess
        If txtMasterTableName.Text = "LOG_TYPE" Then
            cmbComboBox1.SetItemList(Proc.GetLogTypeList(trans), "type_name", "id")
        ElseIf txtMasterTableName.Text = "LOG_STATUS" Then
            cmbComboBox1.SetItemList(Proc.GetLogStatusList(trans), "status_name", "id")
        ElseIf txtMasterTableName.Text = "LOG_STATE" Then
            cmbComboBox1.SetItemList(Proc.GetLogStateList(trans), "state_name", "id")
        ElseIf txtMasterTableName.Text = "SCREEN" Then
            cmbComboBox1.SetItemList(Proc.GetScreenList(IIf(txtRefMasterID.Text.Trim = "", 0, txtRefMasterID.Text), trans), "screen_name", "id")
        ElseIf txtMasterTableName.Text = "MODULE" Then
            cmbComboBox1.SetItemList(Proc.GetModuleList(txtRefMasterID.Text, trans), "module_name", "id")
        ElseIf txtMasterTableName.Text = "RESOLVED_STATUS" Then
            cmbComboBox1.SetItemList(Proc.GetResolvedStatusList(trans), "status_name", "id")
        End If
        trans.CommitTransaction()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            SetCombo()
        End If
    End Sub

    Protected Sub cmbComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbComboBox1.SelectedIndexChanged
        RaiseEvent SelectedIndexChange(sender, e)
    End Sub
End Class
