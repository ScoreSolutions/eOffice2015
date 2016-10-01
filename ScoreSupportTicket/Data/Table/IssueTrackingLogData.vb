
Namespace Table
    'Represents a transaction for ISSUE_TRACKING_LOG table Data.
    '[Create by  on March, 27 2011]
    Public Class IssueTrackingLogData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1, 1, 1)
        Dim _UPDATE_BY As String = ""
        Dim _UPDATE_ON As DateTime = New DateTime(1, 1, 1)
        Dim _PROJECT_ID As Long = 0
        Dim _LOG_NO As Long = 0
        Dim _REF_REQUEST_NO As String = ""
        Dim _TYPE_ID As Long = 0
        Dim _LOG_DESC As String = ""
        Dim _STATUS_ID As Long = 0
        Dim _PRIORITY As String = ""
        Dim _STATE_ID As Long = 0
        Dim _LOG_INSTANCE As String = ""
        Dim _SCREEN_ID As Long = 0
        Dim _MODULE_ID As Long = 0
        Dim _RAISED_BY As String = ""
        Dim _RAISED_ON As DateTime = New DateTime(1, 1, 1)
        Dim _CHANGE_APPROVE As String = ""
        Dim _COMMENTS As String = ""
        Dim _ASSIGNED_TO As String = ""
        Dim _ASSIGNED_DATE As DateTime = New DateTime(1, 1, 1)
        Dim _EXPECTED_CLOSED_DATE As DateTime = New DateTime(1, 1, 1)
        Dim _CLOSED_BY As String = ""
        Dim _CLOSED_DATE As DateTime = New DateTime(1, 1, 1)
        Dim _ESTIMATE_FIXED_DATE As DateTime = New DateTime(1, 1, 1)
        Dim _RESOLVE_STATUS_ID As Long = Nothing
        Dim _COMPLEXITY_LEVEL As String = ""
        Dim _RESOLUTION As String = ""
        Dim _RESOLVED_DATE As DateTime = New DateTime(1, 1, 1)
        Dim _RESOLVED_COMMENT As String = ""

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
        Public Property PROJECT_ID() As Long
            Get
                Return _PROJECT_ID
            End Get
            Set(ByVal value As Long)
                _PROJECT_ID = value
            End Set
        End Property
        Public Property LOG_NO() As Long
            Get
                Return _LOG_NO
            End Get
            Set(ByVal value As Long)
                _LOG_NO = value
            End Set
        End Property
        Public Property REF_REQUEST_NO() As String
            Get
                Return _REF_REQUEST_NO
            End Get
            Set(ByVal value As String)
                _REF_REQUEST_NO = value
            End Set
        End Property
        Public Property TYPE_ID() As Long
            Get
                Return _TYPE_ID
            End Get
            Set(ByVal value As Long)
                _TYPE_ID = value
            End Set
        End Property
        Public Property LOG_DESC() As String
            Get
                Return _LOG_DESC
            End Get
            Set(ByVal value As String)
                _LOG_DESC = value
            End Set
        End Property
        Public Property STATUS_ID() As Long
            Get
                Return _STATUS_ID
            End Get
            Set(ByVal value As Long)
                _STATUS_ID = value
            End Set
        End Property
        Public Property PRIORITY() As String
            Get
                Return _PRIORITY
            End Get
            Set(ByVal value As String)
                _PRIORITY = value
            End Set
        End Property
        Public Property STATE_ID() As Long
            Get
                Return _STATE_ID
            End Get
            Set(ByVal value As Long)
                _STATE_ID = value
            End Set
        End Property
        Public Property LOG_INSTANCE() As String
            Get
                Return _LOG_INSTANCE
            End Get
            Set(ByVal value As String)
                _LOG_INSTANCE = value
            End Set
        End Property
        Public Property SCREEN_ID() As Long
            Get
                Return _SCREEN_ID
            End Get
            Set(ByVal value As Long)
                _SCREEN_ID = value
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
        Public Property RAISED_BY() As String
            Get
                Return _RAISED_BY
            End Get
            Set(ByVal value As String)
                _RAISED_BY = value
            End Set
        End Property
        Public Property RAISED_ON() As DateTime
            Get
                Return _RAISED_ON
            End Get
            Set(ByVal value As DateTime)
                _RAISED_ON = value
            End Set
        End Property
        Public Property CHANGE_APPROVE() As String
            Get
                Return _CHANGE_APPROVE
            End Get
            Set(ByVal value As String)
                _CHANGE_APPROVE = value
            End Set
        End Property
        Public Property COMMENTS() As String
            Get
                Return _COMMENTS
            End Get
            Set(ByVal value As String)
                _COMMENTS = value
            End Set
        End Property
        Public Property ASSIGNED_TO() As String
            Get
                Return _ASSIGNED_TO
            End Get
            Set(ByVal value As String)
                _ASSIGNED_TO = value
            End Set
        End Property
        Public Property ASSIGNED_DATE() As DateTime
            Get
                Return _ASSIGNED_DATE
            End Get
            Set(ByVal value As DateTime)
                _ASSIGNED_DATE = value
            End Set
        End Property
        Public Property EXPECTED_CLOSED_DATE() As DateTime
            Get
                Return _EXPECTED_CLOSED_DATE
            End Get
            Set(ByVal value As DateTime)
                _EXPECTED_CLOSED_DATE = value
            End Set
        End Property
        Public Property CLOSED_BY() As String
            Get
                Return _CLOSED_BY
            End Get
            Set(ByVal value As String)
                _CLOSED_BY = value
            End Set
        End Property
        Public Property CLOSED_DATE() As DateTime
            Get
                Return _CLOSED_DATE
            End Get
            Set(ByVal value As DateTime)
                _CLOSED_DATE = value
            End Set
        End Property
        Public Property ESTIMATE_FIXED_DATE() As DateTime
            Get
                Return _ESTIMATE_FIXED_DATE
            End Get
            Set(ByVal value As DateTime)
                _ESTIMATE_FIXED_DATE = value
            End Set
        End Property
        Public Property RESOLVE_STATUS_ID() As Long
            Get
                Return _RESOLVE_STATUS_ID
            End Get
            Set(ByVal value As Long)
                _RESOLVE_STATUS_ID = value
            End Set
        End Property
        Public Property COMPLEXITY_LEVEL() As String
            Get
                Return _COMPLEXITY_LEVEL
            End Get
            Set(ByVal value As String)
                _COMPLEXITY_LEVEL = value
            End Set
        End Property
        Public Property RESOLUTION() As String
            Get
                Return _RESOLUTION
            End Get
            Set(ByVal value As String)
                _RESOLUTION = value
            End Set
        End Property
        Public Property RESOLVED_DATE() As DateTime
            Get
                Return _RESOLVED_DATE
            End Get
            Set(ByVal value As DateTime)
                _RESOLVED_DATE = value
            End Set
        End Property
        Public Property RESOLVED_COMMENT() As String
            Get
                Return _RESOLVED_COMMENT
            End Get
            Set(ByVal value As String)
                _RESOLVED_COMMENT = value
            End Set
        End Property
    End Class
End Namespace