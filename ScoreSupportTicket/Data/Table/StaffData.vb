
Namespace Table
    'Represents a transaction for STAFF table Data.
    '[Create by  on March, 8 2011]
    Public Class StaffData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1, 1, 1)
        Dim _UPDATE_BY As String = ""
        Dim _UPDATE_ON As DateTime = New DateTime(1, 1, 1)
        Dim _USERNAME As String = ""
        Dim _PWD As String = ""
        Dim _STAFFNAME As String = ""
        Dim _POSITION_NAME As String = ""
        Dim _DIVISION_NAME As String = ""
        Dim _CAN_RAISE As String = ""
        Dim _CAN_ACCEPT_ASSIGNMENT As String = ""
        Dim _CAN_CLOSE As String = ""
        Dim _ACTIVE As String = ""

        'Generate Field Property 
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
        Public Property CREATE_BY() As String
            Get
                Return _CREATE_BY
            End Get
            Set(ByVal value As String)
                _CREATE_BY = value
            End Set
        End Property
        Public Property CREATE_ON() As DateTime
            Get
                Return _CREATE_ON
            End Get
            Set(ByVal value As DateTime)
                _CREATE_ON = value
            End Set
        End Property
        Public Property UPDATE_BY() As String
            Get
                Return _UPDATE_BY
            End Get
            Set(ByVal value As String)
                _UPDATE_BY = value
            End Set
        End Property
        Public Property UPDATE_ON() As DateTime
            Get
                Return _UPDATE_ON
            End Get
            Set(ByVal value As DateTime)
                _UPDATE_ON = value
            End Set
        End Property
        Public Property USERNAME() As String
            Get
                Return _USERNAME
            End Get
            Set(ByVal value As String)
                _USERNAME = value
            End Set
        End Property
        Public Property PWD() As String
            Get
                Return _PWD
            End Get
            Set(ByVal value As String)
                _PWD = value
            End Set
        End Property
        Public Property STAFFNAME() As String
            Get
                Return _STAFFNAME
            End Get
            Set(ByVal value As String)
                _STAFFNAME = value
            End Set
        End Property
        Public Property POSITION_NAME() As String
            Get
                Return _POSITION_NAME
            End Get
            Set(ByVal value As String)
                _POSITION_NAME = value
            End Set
        End Property
        Public Property DIVISION_NAME() As String
            Get
                Return _DIVISION_NAME
            End Get
            Set(ByVal value As String)
                _DIVISION_NAME = value
            End Set
        End Property
        Public Property CAN_RAISE() As String
            Get
                Return _CAN_RAISE
            End Get
            Set(ByVal value As String)
                _CAN_RAISE = value
            End Set
        End Property
        Public Property CAN_ACCEPT_ASSIGNMENT() As String
            Get
                Return _CAN_ACCEPT_ASSIGNMENT
            End Get
            Set(ByVal value As String)
                _CAN_ACCEPT_ASSIGNMENT = value
            End Set
        End Property
        Public Property CAN_CLOSE() As String
            Get
                Return _CAN_CLOSE
            End Get
            Set(ByVal value As String)
                _CAN_CLOSE = value
            End Set
        End Property
        Public Property ACTIVE() As String
            Get
                Return _ACTIVE
            End Get
            Set(ByVal value As String)
                _ACTIVE = value
            End Set
        End Property
    End Class
End Namespace