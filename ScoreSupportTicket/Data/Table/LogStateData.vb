
Namespace Table
    'Represents a transaction for LOG_STATE table Data.
    '[Create by  on March, 8 2011]
    Public Class LogStateData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1, 1, 1)
        Dim _UPDATE_BY As String = ""
        Dim _UPDATE_ON As DateTime = New DateTime(1, 1, 1)
        Dim _STATE_NAME As String = ""
        Dim _STATE_DESC As String = ""
        Dim _STATE_ORDER As Long = 0
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
        Public Property STATE_NAME() As String
            Get
                Return _STATE_NAME
            End Get
            Set(ByVal value As String)
                _STATE_NAME = value
            End Set
        End Property
        Public Property STATE_DESC() As String
            Get
                Return _STATE_DESC
            End Get
            Set(ByVal value As String)
                _STATE_DESC = value
            End Set
        End Property
        Public Property STATE_ORDER() As Long
            Get
                Return _STATE_ORDER
            End Get
            Set(ByVal value As Long)
                _STATE_ORDER = value
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