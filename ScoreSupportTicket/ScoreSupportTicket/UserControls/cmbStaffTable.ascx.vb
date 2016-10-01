Imports XCS.Process.Master

Partial Class UserControls_cmbStaffTable
    Inherits System.Web.UI.UserControl

    Public Event SelectedIndexChange(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event SaveComplete(ByVal sender As Object, ByVal e As System.EventArgs)

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
    Public Property AutoPostBack() As Boolean
        Get
            Return cmbComboBox1.AutoPosBack
        End Get
        Set(ByVal value As Boolean)
            cmbComboBox1.AutoPosBack = value
        End Set
    End Property
    Public Property IsNotNull() As Boolean
        Get
            Return cmbComboBox1.IsNotNull
        End Get
        Set(ByVal value As Boolean)
            cmbComboBox1.IsNotNull = value
        End Set
    End Property
    Public Property DefaultValue() As String
        Get
            Return cmbComboBox1.DefaultValue
        End Get
        Set(ByVal value As String)
            cmbComboBox1.DefaultValue = value
        End Set
    End Property
    Public WriteOnly Property ValidationText() As String
        Set(ByVal value As String)
            cmbComboBox1.ValidateText = value
        End Set
    End Property

    Public WriteOnly Property PageName() As String
        Set(ByVal value As String)
            mstStaffForm1.PageName = value
        End Set
    End Property

    Public WriteOnly Property FieldName() As FldName
        Set(ByVal value As FldName)
            txtFldName.Text = value
        End Set
    End Property
    Public WriteOnly Property ProjectID() As String
        Set(ByVal value As String)
            txtProjectID.Text = value
        End Set
    End Property
    Public WriteOnly Property Width() As Unit
        Set(ByVal value As Unit)
            cmbComboBox1.Width = value
        End Set
    End Property
    Public Property Enabled() As Boolean
        Get
            Return cmbComboBox1.Enabled
        End Get
        Set(ByVal value As Boolean)
            cmbComboBox1.Enabled = value
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

    Protected Sub cmbComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbComboBox1.SelectedIndexChanged
        RaiseEvent SelectedIndexChange(sender, e)
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Show(0)
    End Sub


    Public Sub Show(ByVal id As Long)
        If id = 0 Then
            mstStaffForm1.ClearForm()
        End If

        mstStaffForm1.SetProjectList()
        zPop.Show()
    End Sub

    Protected Sub mstStaffForm1_CloseClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles mstStaffForm1.CloseClick
        zPop.Hide()
    End Sub

    Protected Sub mstStaffForm1_SaveComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles mstStaffForm1.SaveComplete
        'SetCombo()
        zPop.Hide()
        RaiseEvent SaveComplete(sender, e)
    End Sub

    Public Enum FldName
        RAISED_BY = 1
        ASSIGNED_TO = 2
        CLOSED_BY = 3
    End Enum

    Public Sub SetCombo()
        Dim trans As New XCS.Process.Common.DbTransProcess
        trans.CreateTransaction()
        Dim Proc As New StaffFormProcess
        Dim whText As String = " and ps.project_id = '" & txtProjectID.Text & "'"
        If txtFldName.Text = FldName.RAISED_BY Then
            cmbComboBox1.SetItemList(Proc.GetStaffList("st.can_raise = 'Y'" & whText, trans), "staffname", "username")
        ElseIf txtFldName.Text = FldName.ASSIGNED_TO Then
            cmbComboBox1.SetItemList(Proc.GetStaffList("st.can_accept_assignment = 'Y'" & whText, trans), "staffname", "username")
        ElseIf txtFldName.Text = FldName.CLOSED_BY Then
            cmbComboBox1.SetItemList(Proc.GetStaffList("st.can_close = 'Y'" & whText, trans), "staffname", "username")
        End If
        trans.CommitTransaction()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            SetCombo()
        End If
    End Sub

    Protected Sub mstStaffForm1_ValidAlert() Handles mstStaffForm1.ValidAlert
        zPop.Show()
    End Sub
End Class
