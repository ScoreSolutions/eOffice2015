Namespace ConnectDB

    <Serializable()> Public Class LoginSession
        Dim _LOGIN_HISTORY_ID As Long = 0
        Dim _USERNAME As String = ""
        Dim _FIRST_NAME As String = ""
        Dim _LAST_NAME As String = ""

        Public Property LOGIN_HISTORY_ID() As Long
            Get
                Return _LOGIN_HISTORY_ID
            End Get
            Set(ByVal value As Long)
                _LOGIN_HISTORY_ID = value
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
        Public Property FIRST_NAME As String
            Get
                Return _FIRST_NAME.Trim
            End Get
            Set(value As String)
                _FIRST_NAME = value
            End Set
        End Property
        Public Property LAST_NAME As String
            Get
                Return _LAST_NAME.Trim
            End Get
            Set(value As String)
                _LAST_NAME = value
            End Set
        End Property



    End Class

End Namespace

