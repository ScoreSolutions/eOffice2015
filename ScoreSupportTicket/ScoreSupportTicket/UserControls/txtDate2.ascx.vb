
Partial Class UserControls_txtDate2
    Inherits System.Web.UI.UserControl

    Public Delegate Sub SelectedDateEvent(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event SelectedDateChanged As SelectedDateEvent

    Dim _IsNotNull As Boolean = False
    Dim _DefaultCurrentDate As Boolean = False
    Public Property DefaultCurrentDate() As Boolean
        Get
            Return _DefaultCurrentDate
        End Get
        Set(ByVal value As Boolean)
            _DefaultCurrentDate = value
        End Set
    End Property
    Public ReadOnly Property CalendarClientID() As String
        Get
            Return Me.ClientID
        End Get
    End Property

    Public Property DateValue() As DateTime
        Get
            Return GetDate()
        End Get
        Set(ByVal value As DateTime)
            SetDate(value)
        End Set
    End Property

    Public Property IsNotNull() As Boolean
        Get
            Return _IsNotNull
        End Get
        Set(ByVal value As Boolean)
            _IsNotNull = value
        End Set
    End Property

    Private Function GetDate() As Date
        If txtDay.Text.Trim() <> "" And txtMonth.Text.Trim() And txtYear.Text.Trim() Then
            Dim value As String = txtDay.Text.PadLeft(2, "0") & txtMonth.Text.PadLeft(2, "0") & txtYear.Text.PadLeft(4, "0")
            Return DateTime.ParseExact(value, "dd/MM/yyyy", Nothing)
        Else
            Return New Date()
        End If
    End Function
    Private Sub SetDate(ByVal DateValue As DateTime)
        If DateValue.Year = 1 Then
            txtDay.Text = ""
            txtMonth.Text = ""
            txtYear.Text = ""
        Else
            txtDay.Text = DateValue.ToString("dd")
            txtMonth.Text = DateValue.ToString("MM")
            txtYear.Text = DateValue.ToString("yyyy")
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            If _IsNotNull = False Then
                Label1.Visible = False
            Else
                Label1.Visible = True
            End If

            If _DefaultCurrentDate = True Then
                txtDay.Text = DateTime.Today.ToString("dd")
                txtMonth.Text = DateTime.Today.ToString("MM")
                txtYear.Text = DateTime.Today.ToString("yyyy")
            End If

        End If
    End Sub

End Class
