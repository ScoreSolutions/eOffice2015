Imports Microsoft.VisualBasic

<Serializable()> Public Class clsUserAuthorizedPara
    Dim _CheckUserAuthorized As Boolean = False
    Dim _UserPara As New clsUserPara

    Public Property CheckUserAuthorized() As Boolean
        Get
            Return _CheckUserAuthorized
        End Get
        Set(ByVal value As Boolean)
            _CheckUserAuthorized = value
        End Set
    End Property
    Public Property UserPara() As clsUserPara
        Get
            Return _UserPara
        End Get
        Set(ByVal value As clsUserPara)
            _UserPara = value
        End Set
    End Property
End Class
