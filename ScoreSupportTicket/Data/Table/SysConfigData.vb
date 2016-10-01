
Namespace Table
    'Represents a transaction for SYSCONFIG table Data.
    '[Create by  on March, 18 2011]
    Public Class SysConfigData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1, 1, 1)
        Dim _UPDATE_BY As String = ""
        Dim _UPDATE_ON As DateTime = New DateTime(1, 1, 1)
        Dim _CONFIG_NAME As String = ""
        Dim _CONFIG_VALUE As String = ""
        Dim _CONFIG_DESC As String = ""

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
        Public Property CONFIG_NAME() As String
            Get
                Return _CONFIG_NAME
            End Get
            Set(ByVal value As String)
                _CONFIG_NAME = value
            End Set
        End Property
        Public Property CONFIG_VALUE() As String
            Get
                Return _CONFIG_VALUE
            End Get
            Set(ByVal value As String)
                _CONFIG_VALUE = value
            End Set
        End Property
        Public Property CONFIG_DESC() As String
            Get
                Return _CONFIG_DESC
            End Get
            Set(ByVal value As String)
                _CONFIG_DESC = value
            End Set
        End Property
    End Class
End Namespace