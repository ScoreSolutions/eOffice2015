Imports XCS.Data.Table
Imports XCS.DAL.Table
Namespace Common

    Public Class LoginProcess
        Dim _err As String = ""
        Dim stDAL As StaffDAL
        Public ReadOnly Property ErrorMessage()
            Get
                Return _err
            End Get
        End Property
        Public Function Login(ByVal username As String, ByVal pwd As String) As Boolean
            
            Dim ret As Boolean = False
            If username.Trim = "" Then
                _err = "กรุณาระบุชื่อเข้าระบบ"
            ElseIf pwd.Trim = "" Then
                _err = "กรุณาระบุรหัสผ่าน"
            Else
                'stDAL = New StaffDAL
                'stDAL.GetDataByUSERNAME(username, trans.Trans)
                'If (stDAL.HaveData = True) Then
                '    If stDAL.PWD <> pwd Then
                '        _err = "รหัสผ่านไม่ถูกต้อง"
                '    Else
                '        ret = True
                '    End If
                'Else
                '    _err = IIf(stDAL.ErrorMessage = "", "ไม่พบชื่อผู้ใช้", stDAL.ErrorMessage)
                'End If

                Dim ws As New eOfficeWebServiceAPI.eOFFICEWebServiceAPI
                'ws.Url = "http://localhost/eoffice2014/eOFFICEWebServiceAPI.asmx?WSDL"
                'ws.Timeout = 20000  '20 วินาที

                Dim cls As eOfficeWebServiceAPI.clsUserAuthorizedPara = CheckLoginWebServiceTimeOut(ws, username, pwd)
                If cls.CheckUserAuthorized = True Then
                    ret = True

                    stDAL = New StaffDAL
                    stDAL.GetDataByUSERNAME(username, Nothing)

                    stDAL.USERNAME = username
                    stDAL.PWD = pwd
                    stDAL.STAFFNAME = cls.UserPara.STAFF_NAME
                    stDAL.POSITION_NAME = cls.UserPara.POSITION_DESC
                    stDAL.DIVISION_NAME = cls.UserPara.DEPARTMENT_DESC
                    stDAL.CAN_RAISE = "Y"
                    stDAL.CAN_ACCEPT_ASSIGNMENT = "Y"
                    stDAL.CAN_CLOSE = "Y"
                    stDAL.ACTIVE = "Y"

                    Dim trans As New DbTransProcess
                    trans.CreateTransaction()
                    Dim re As Boolean = False
                    If stDAL.ID > 0 Then
                        re = stDAL.UpdateByPK(username, trans.Trans)
                    Else
                        re = stDAL.InsertData(username, trans.Trans)
                    End If
                    If ret = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                        _err = stDAL.ErrorMessage
                    End If
                Else
                    _err = "ไม่พบชื่อผู้ใช้"
                End If
            End If
            'trans.CommitTransaction()
            Return ret
        End Function

        Private Function CheckLoginWebServiceTimeOut(ws As eOfficeWebServiceAPI.eOFFICEWebServiceAPI, username As String, pwd As String) As eOfficeWebServiceAPI.clsUserAuthorizedPara

            Dim cls As New eOfficeWebServiceAPI.clsUserAuthorizedPara
            Try
                cls = ws.CheckAuthorizeUser(username, pwd)
            Catch ex As Exception
                Try
                    cls = ws.CheckAuthorizeUser(username, pwd)
                Catch ex1 As Exception
                    Try
                        cls = ws.CheckAuthorizeUser(username, pwd)
                    Catch ex2 As Exception
                        cls = New eOfficeWebServiceAPI.clsUserAuthorizedPara
                    End Try
                End Try
            End Try
            Return cls
        End Function


        Public Function GetStaffData() As StaffData
            Dim trans As New DbTransProcess
            trans.CreateTransaction()
            Dim uData As StaffData = New StaffData
            If stDAL IsNot Nothing And stDAL.HaveData Then
                uData = New StaffData
                uData = stDAL.GetDataByPK(stDAL.ID, trans.Trans)
            End If
            trans.CommitTransaction()
            Return uData
        End Function

        'Public Function GetStaffData(ByVal UserName As String) As StaffData
        '    Dim sDAL As New StaffDAL
        '    Return sDAL.GetDataByUSERNAME(UserName, Nothing)
        'End Function
    End Class
End Namespace
