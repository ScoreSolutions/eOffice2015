
Namespace Table
    'Represents a transaction for SCREEN table Data.
    '[Create by  on March, 8 2011]
    Public Class ScreenData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1, 1, 1)
        Dim _UPDATE_BY As String = ""
        Dim _UPDATE_ON As DateTime = New DateTime(1, 1, 1)
        Dim _SCREEN_CODE As String = ""
        Dim _SCREEN_NAME As String = ""
        Dim _SCREEN_DESC As String = ""
        Dim _MODULE_ID As Long = 0
        Dim _SCREEN_ORDER As Long = 0

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
        Public Property SCREEN_CODE() As String
            Get
                Return _SCREEN_CODE
            End Get
            Set(ByVal value As String)
                _SCREEN_CODE = value
            End Set
        End Property
        Public Property SCREEN_NAME() As String
            Get
                Return _SCREEN_NAME
            End Get
            Set(ByVal value As String)
                _SCREEN_NAME = value
            End Set
        End Property
        Public Property SCREEN_DESC() As String
            Get
                Return _SCREEN_DESC
            End Get
            Set(ByVal value As String)
                _SCREEN_DESC = value
            End Set
        End Property
        Public Property MODULE_ID() As Long
            Get
                Return _MODULE_ID
            End Get
            Set(ByVal value As Long)
                _MODULE_ID = value
            End Set
        End Property
        Public Property SCREEN_ORDER() As Long
            Get
                Return _SCREEN_ORDER
            End Get
            Set(ByVal value As Long)
                _SCREEN_ORDER = value
            End Set
        End Property
    End Class
End Namespace