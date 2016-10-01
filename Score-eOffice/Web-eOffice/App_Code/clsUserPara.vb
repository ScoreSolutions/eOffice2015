Imports Microsoft.VisualBasic

<Serializable()> Public Class clsUserPara
    Dim _ID As Long = 0
    Dim _EMPLOYEE_ID As String = ""
    Dim _NAME As String = ""
    Dim _SURNAME As String = ""
    Dim _STAFF_NAME As String = ""
    Dim _DEPARTMENT_ID As Long = 0
    Dim _DEPARTMENT_ABB As String = ""
    Dim _DEPARTMENT_DESC As String = ""
    Dim _POSITION_ID As Long = 0
    Dim _POSITION_DESC As String = ""
    Dim _EMAIL As String = ""
    Dim _USERNAME As String = ""
    Dim _GROUP_ID As Long = 0
    Dim _GROUP_NAME_EN As String = ""
    Dim _GROUP_NAME_TH As String = ""

    Public Property ID() As Long
        Get
            Return _ID
        End Get
        Set(ByVal value As Long)
            _ID = value
        End Set
    End Property
    Public Property EMPLOYEE_ID() As String
        Get
            Return _EMPLOYEE_ID.Trim
        End Get
        Set(ByVal value As String)
            _EMPLOYEE_ID = value
        End Set
    End Property
    Public Property NAME() As String
        Get
            Return _NAME.Trim
        End Get
        Set(ByVal value As String)
            _NAME = value
        End Set
    End Property
    Public Property SURNAME() As String
        Get
            Return _SURNAME.Trim
        End Get
        Set(ByVal value As String)
            _SURNAME = value
        End Set
    End Property
    Public Property STAFF_NAME() As String
        Get
            Return _STAFF_NAME.Trim
        End Get
        Set(ByVal value As String)
            _STAFF_NAME = value
        End Set
    End Property
    Public Property DEPARTMENT_ID() As Long
        Get
            Return _DEPARTMENT_ID
        End Get
        Set(ByVal value As Long)
            _DEPARTMENT_ID = value
        End Set
    End Property
    Public Property DEPARTMENT_ABB() As String
        Get
            Return _DEPARTMENT_ABB.Trim
        End Get
        Set(ByVal value As String)
            _DEPARTMENT_ABB = value
        End Set
    End Property
    Public Property DEPARTMENT_DESC() As String
        Get
            Return _DEPARTMENT_DESC.Trim
        End Get
        Set(ByVal value As String)
            _DEPARTMENT_DESC = value
        End Set
    End Property
    Public Property POSITION_ID() As Long
        Get
            Return _POSITION_ID
        End Get
        Set(ByVal value As Long)
            _POSITION_ID = value
        End Set
    End Property

    Public Property POSITION_DESC() As String
        Get
            Return _POSITION_DESC.Trim
        End Get
        Set(ByVal value As String)
            _POSITION_DESC = value
        End Set
    End Property

    Public Property EMAIL() As String
        Get
            Return _EMAIL.Trim
        End Get
        Set(ByVal value As String)
            _EMAIL = value
        End Set
    End Property

    Public Property USERNAME() As String
        Get
            Return _USERNAME.Trim
        End Get
        Set(ByVal value As String)
            _USERNAME = value
        End Set
    End Property

    Public Property GROUP_ID() As Long
        Get
            Return _GROUP_ID
        End Get
        Set(ByVal value As Long)
            _GROUP_ID = value
        End Set
    End Property

    Public Property GROUP_NAME_EN() As String
        Get
            Return _GROUP_NAME_EN.Trim
        End Get
        Set(ByVal value As String)
            _GROUP_NAME_EN = value
        End Set
    End Property
    Public Property GROUP_NAME_TH() As String
        Get
            Return _GROUP_NAME_TH.Trim
        End Get
        Set(ByVal value As String)
            _GROUP_NAME_TH = value
        End Set
    End Property
End Class
