
Namespace Table
    'Represents a transaction for PROJECT_STAFF table Data.
    '[Create by  on March, 11 2011]
    Public Class ProjectStaffData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1, 1, 1)
        Dim _UPDATE_BY As String = ""
        Dim _UPDATE_ON As DateTime = New DateTime(1, 1, 1)
        Dim _STAFF_ID As Long = 0
        Dim _PROJECT_ID As Long = 0

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
        Public Property STAFF_ID() As Long
            Get
                Return _STAFF_ID
            End Get
            Set(ByVal value As Long)
                _STAFF_ID = value
            End Set
        End Property
        Public Property PROJECT_ID() As Long
            Get
                Return _PROJECT_ID
            End Get
            Set(ByVal value As Long)
                _PROJECT_ID = value
            End Set
        End Property
    End Class
End Namespace