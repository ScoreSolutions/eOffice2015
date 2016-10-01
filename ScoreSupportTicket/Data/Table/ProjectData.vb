
Namespace Table
    'Represents a transaction for PROJECT table Data.
    '[Create by  on March, 11 2011]
    Public Class ProjectData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1, 1, 1)
        Dim _UPDATE_BY As String = ""
        Dim _UPDATE_ON As DateTime = New DateTime(1, 1, 1)
        Dim _PROJECT_CODE As String = ""
        Dim _PROJECT_NAME As String = ""
        Dim _CUSTOMER_NAME As String = ""
        Dim _START_YEAR As String = ""
        Dim _CONTRACT_NO As String = ""
        Dim _PROJECT_DESC As String = ""

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
        Public Property PROJECT_CODE() As String
            Get
                Return _PROJECT_CODE
            End Get
            Set(ByVal value As String)
                _PROJECT_CODE = value
            End Set
        End Property
        Public Property PROJECT_NAME() As String
            Get
                Return _PROJECT_NAME
            End Get
            Set(ByVal value As String)
                _PROJECT_NAME = value
            End Set
        End Property
        Public Property CUSTOMER_NAME() As String
            Get
                Return _CUSTOMER_NAME
            End Get
            Set(ByVal value As String)
                _CUSTOMER_NAME = value
            End Set
        End Property
        Public Property START_YEAR() As String
            Get
                Return _START_YEAR
            End Get
            Set(ByVal value As String)
                _START_YEAR = value
            End Set
        End Property
        Public Property CONTRACT_NO() As String
            Get
                Return _CONTRACT_NO
            End Get
            Set(ByVal value As String)
                _CONTRACT_NO = value
            End Set
        End Property
        Public Property PROJECT_DESC() As String
            Get
                Return _PROJECT_DESC
            End Get
            Set(ByVal value As String)
                _PROJECT_DESC = value
            End Set
        End Property
    End Class
End Namespace