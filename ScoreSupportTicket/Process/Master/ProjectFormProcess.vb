Imports System.Data
Imports XCS.Data.Table
Imports XCS.DAL.Table
Imports XCS.DAL.Common.Utilities

Namespace Master
    Public Class ProjectFormProcess
        Dim _err As String
        Dim _ID As Long

        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property
        Public ReadOnly Property ID() As Long
            Get
                Return _ID
            End Get
        End Property

        Public Function GetProjectList(ByVal whText As String, ByVal orderBy As String, ByVal trans As TransactionDB) As DataTable
            Dim dal As New ProjectDAL
            Return dal.GetDataList(whText, orderBy, trans.Trans)
        End Function
        Public Function GetProjectData(ByVal vID As Long, ByVal trans As TransactionDB) As ProjectData
            Dim dal As New ProjectDAL
            Return dal.GetDataByPK(vID, trans.Trans)
        End Function

        Public Function SaveProject(ByVal data As ProjectData, ByVal UserID As String) As Boolean
            Dim ret As Boolean = False
            Dim trans As New TransactionDB
            trans.CreateTransaction()

            Dim dal As New ProjectDAL
            If data.ID <> 0 Then
                dal.GetDataByPK(data.ID, trans.Trans)
            End If

            dal.PROJECT_CODE = data.PROJECT_CODE
            dal.PROJECT_NAME = data.PROJECT_NAME
            dal.CONTRACT_NO = data.CONTRACT_NO
            dal.CUSTOMER_NAME = data.CUSTOMER_NAME
            dal.START_YEAR = data.START_YEAR
            dal.PROJECT_DESC = data.PROJECT_DESC

            If data.ID <> 0 Then
                ret = dal.UpdateByPK(UserID, trans.Trans)
            Else
                ret = dal.InsertData(UserID, trans.Trans)
            End If

            If ret = True Then
                _ID = dal.ID
                trans.CommitTransaction()
            Else
                _err = dal.ErrorMessage
                trans.RollbackTransaction()
            End If

            Return ret
        End Function
    End Class
End Namespace
