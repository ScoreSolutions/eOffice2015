
Namespace Table
    'Represents a transaction for ISSUE_LOG_ATTACH_FILE table Data.
    '[Create by  on March, 19 2011]
    Public Class IssueLogAttachFileData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1, 1, 1)
        Dim _UPDATE_BY As String = ""
        Dim _UPDATE_ON As DateTime = New DateTime(1, 1, 1)
        Dim _ISSUE_TRACKING_LOG_ID As Long = 0
        Dim _FILE_NAME As String = ""
        Dim _FILE_DESC As String = ""
        Dim _FILE_EXTENTION As String = ""

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
        Public Property ISSUE_TRACKING_LOG_ID() As Long
            Get
                Return _ISSUE_TRACKING_LOG_ID
            End Get
            Set(ByVal value As Long)
                _ISSUE_TRACKING_LOG_ID = value
            End Set
        End Property
        Public Property FILE_NAME() As String
            Get
                Return _FILE_NAME
            End Get
            Set(ByVal value As String)
                _FILE_NAME = value
            End Set
        End Property
        Public Property FILE_DESC() As String
            Get
                Return _FILE_DESC
            End Get
            Set(ByVal value As String)
                _FILE_DESC = value
            End Set
        End Property
        Public Property FILE_EXTENTION() As String
            Get
                Return _FILE_EXTENTION
            End Get
            Set(ByVal value As String)
                _FILE_EXTENTION = value
            End Set
        End Property
    End Class
End Namespace