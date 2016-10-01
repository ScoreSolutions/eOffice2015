Imports XCS.DAL.Common.Utilities
Imports XCS.DAL.Table
Imports XCS.Data.Table

Namespace Master
    Public Class FormControlProcess
        Dim _err As String = ""
        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property

        Public Function GetLogTypeList(ByVal trans As TransactionDB) As DataTable
            Dim lDAL As New LogTypeDAL
            Return lDAL.GetDataList("active='Y'", "type_order", trans.Trans)
        End Function

        Public Function GetLogStatusList(ByVal trans As TransactionDB) As DataTable
            Dim lDAL As New LogStatusDAL
            Return lDAL.GetDataList("active='Y'", "status_order", trans.Trans)
        End Function
        Public Function GetResolvedStatusList(ByVal trans As TransactionDB) As DataTable
            Dim rDAL As New ResolvedStatusDAL
            Return rDAL.GetDataList("active='Y'", "status_order", trans.Trans)
        End Function

        Public Function GetLogStateList(ByVal trans As TransactionDB) As DataTable
            Dim lDAL As New LogStateDAL
            Return lDAL.GetDataList("active='Y'", "state_order", trans.Trans)
        End Function

        Public Function GetScreenList(ByVal ModuleID As Long, ByVal trans As TransactionDB) As DataTable
            Dim lDAL As New ScreenDAL
            Return lDAL.GetDataList("module_id = " & ModuleID, "screen_order", trans.Trans)
        End Function
        Public Function GetModuleList(ByVal ProjectID As Long, ByVal trans As TransactionDB) As DataTable
            Dim lDAL As New ModuleDAL
            Return lDAL.GetDataList("project_id = " & ProjectID, "module_order", trans.Trans)
        End Function
        Public Function GetProjectList(ByVal UserID As String, ByVal trans As TransactionDB) As DataTable
            'Dim lDAL As New ProjectDAL
            'Return lDAL.GetDataList("1=1", "project_name", Nothing)

            Dim lDAL As New ProjectDAL
            Dim sql As String = "select pj.id, pj.project_name "
            sql += " from TRACKINGLOG_project_staff ps"
            sql += " inner join TRACKINGLOG_project pj on pj.id=ps.project_id"
            sql += " inner join TRACKINGLOG_staff st on st.id=ps.staff_id"
            sql += " where st.username = '" + UserID + "'"
            Return lDAL.GetListBySql(sql, "pj.project_name", trans.Trans)
        End Function

        Public Function SaveScreen(ByVal data As ScreenData, ByVal UserID As String) As Boolean
            Dim trans As New TransactionDB
            trans.CreateTransaction()

            Dim sDAL As New ScreenDAL

            If data.ID <> 0 Then
                sDAL.GetDataByPK(data.ID, trans.Trans)
            End If
            sDAL.MODULE_ID = data.MODULE_ID
            sDAL.SCREEN_CODE = data.SCREEN_CODE
            sDAL.SCREEN_NAME = data.SCREEN_NAME
            sDAL.SCREEN_DESC = data.SCREEN_DESC
            sDAL.SCREEN_ORDER = data.SCREEN_ORDER

            Dim ret As Boolean = True
            If sDAL.ID = 0 Then
                ret = sDAL.InsertData(UserID, trans.Trans)
            Else
                ret = sDAL.UpdateByPK(UserID, trans.Trans)
            End If

            If ret = True Then
                trans.CommitTransaction()
            Else
                _err = sDAL.ErrorMessage
                trans.RollbackTransaction()
            End If

            Return ret

        End Function

        Public Function chkDupScreen(ByVal data As ScreenData) As Boolean
            Dim ret As Boolean = True
            Dim trans As New TransactionDB
            trans.CreateTransaction()
            Dim sDAL As New ScreenDAL

            If sDAL.ChkDataBySCREEN_NAME(data.SCREEN_NAME, trans.Trans) = True Then
                _err = "ชื่อหน้าจอซ้ำ"
                ret = False
            Else
                If sDAL.ChkDataByMODULE_ID_SCREEN_ORDER(data.MODULE_ID, data.SCREEN_ORDER, trans.Trans) = True Then
                    _err = "ลำดับที่ซ้ำ"
                    ret = False
                End If
            End If

            trans.CommitTransaction()

            Return ret
        End Function

        Public Function SaveModule(ByVal data As ModuleData, ByVal UserID As String) As Boolean
            Dim trans As New TransactionDB
            trans.CreateTransaction()

            Dim mDAL As New ModuleDAL

            If data.ID <> 0 Then
                mDAL.GetDataByPK(data.ID, trans.Trans)
            End If

            mDAL.PROJECT_ID = data.PROJECT_ID
            mDAL.MODULE_CODE = data.MODULE_CODE
            mDAL.MODULE_NAME = data.MODULE_NAME
            mDAL.MODULE_DESC = data.MODULE_DESC
            mDAL.MODULE_ORDER = data.MODULE_ORDER

            Dim ret As Boolean = True
            If mDAL.ID = 0 Then
                ret = mDAL.InsertData(UserID, trans.Trans)
            Else
                ret = mDAL.UpdateByPK(UserID, trans.Trans)
            End If

            If ret = True Then
                trans.CommitTransaction()
            Else
                _err = mDAL.ErrorMessage
                trans.RollbackTransaction()
            End If

            Return ret

        End Function

        Public Function chkDupModule(ByVal data As ModuleData) As Boolean
            Dim ret As Boolean = True
            Dim trans As New TransactionDB
            trans.CreateTransaction()
            Dim mDAL As New ModuleDAL

            If mDAL.ChkDataByMODULE_NAME_PROJECT_ID(data.MODULE_NAME, data.PROJECT_ID, trans.Trans) = True Then
                _err = "ชื่อโมดูลซ้ำ"
                ret = False
            Else
                If mDAL.ChkDataByMODULE_ORDER_PROJECT_ID(data.MODULE_ORDER, data.PROJECT_ID, trans.Trans) = True Then
                    _err = "ลำดับที่ซ้ำ"
                    ret = False
                End If
            End If

            trans.CommitTransaction()

            Return ret
        End Function

        Public Function SaveLogType(ByVal data As LogTypeData, ByVal UserID As String) As Boolean
            Dim trans As New TransactionDB
            trans.CreateTransaction()

            Dim lDAL As New LogTypeDAL

            If data.ID <> 0 Then
                lDAL.GetDataByPK(data.ID, trans.Trans)
            End If

            lDAL.TYPE_NAME = data.TYPE_NAME
            lDAL.TYPE_DESC = data.TYPE_DESC
            lDAL.TYPE_ORDER = data.TYPE_ORDER
            lDAL.ACTIVE = data.ACTIVE

            Dim ret As Boolean = True
            If lDAL.ID = 0 Then
                ret = lDAL.InsertData(UserID, trans.Trans)
            Else
                ret = lDAL.UpdateByPK(UserID, trans.Trans)
            End If

            If ret = True Then
                trans.CommitTransaction()
            Else
                _err = lDAL.ErrorMessage
                trans.RollbackTransaction()
            End If

            Return ret

        End Function

        Public Function chkDupLogType(ByVal data As LogTypeData) As Boolean
            Dim ret As Boolean = True
            Dim trans As New TransactionDB
            trans.CreateTransaction()
            Dim lDAL As New LogTypeDAL

            If lDAL.ChkDataByTYPE_NAME(data.TYPE_NAME, trans.Trans) = True Then
                _err = "ประเภทซ้ำ"
                ret = False
            Else
                If lDAL.ChkDataByTYPE_ORDER(data.TYPE_ORDER, trans.Trans) = True Then
                    _err = "ลำดับที่ซ้ำ"
                    ret = False
                End If
            End If

            trans.CommitTransaction()

            Return ret
        End Function

        Public Function SaveLogStatus(ByVal data As LogStatusData, ByVal UserID As String) As Boolean
            Dim trans As New TransactionDB
            trans.CreateTransaction()

            Dim lDAL As New LogStatusDAL

            If data.ID <> 0 Then
                lDAL.GetDataByPK(data.ID, trans.Trans)
            End If

            lDAL.STATUS_NAME = data.STATUS_NAME
            lDAL.STATUS_DESC = data.STATUS_DESC
            lDAL.STATUS_ORDER = data.STATUS_ORDER
            lDAL.ACTIVE = data.ACTIVE

            Dim ret As Boolean = True
            If lDAL.ID = 0 Then
                ret = lDAL.InsertData(UserID, trans.Trans)
            Else
                ret = lDAL.UpdateByPK(UserID, trans.Trans)
            End If

            If ret = True Then
                trans.CommitTransaction()
            Else
                _err = lDAL.ErrorMessage
                trans.RollbackTransaction()
            End If

            Return ret

        End Function

        Public Function SaveResolvedStatus(ByVal data As ResolvedStatusData, ByVal UserID As String) As Boolean
            Dim trans As New TransactionDB
            trans.CreateTransaction()

            Dim lDAL As New ResolvedStatusDAL

            If data.ID <> 0 Then
                lDAL.GetDataByPK(data.ID, trans.Trans)
            End If

            lDAL.STATUS_NAME = data.STATUS_NAME
            lDAL.STATUS_DESC = data.STATUS_DESC
            lDAL.STATUS_ORDER = data.STATUS_ORDER
            lDAL.ACTIVE = data.ACTIVE

            Dim ret As Boolean = True
            If lDAL.ID = 0 Then
                ret = lDAL.InsertData(UserID, trans.Trans)
            Else
                ret = lDAL.UpdateByPK(UserID, trans.Trans)
            End If

            If ret = True Then
                trans.CommitTransaction()
            Else
                _err = lDAL.ErrorMessage
                trans.RollbackTransaction()
            End If

            Return ret
        End Function

        Public Function chkDupResolveStatus(ByVal data As ResolvedStatusData) As Boolean
            Dim ret As Boolean = True
            Dim trans As New TransactionDB
            trans.CreateTransaction()
            Dim lDAL As New ResolvedStatusDAL

            If lDAL.ChkDataBySTATUS_NAME(data.STATUS_NAME, trans.Trans) = True Then
                _err = "สถานะซ้ำ"
                ret = False
            Else
                If lDAL.ChkDataBySTATUS_ORDER(data.STATUS_ORDER, trans.Trans) = True Then
                    _err = "ลำดับที่ซ้ำ"
                    ret = False
                End If
            End If

            trans.CommitTransaction()

            Return ret
        End Function
        Public Function chkDupLogStatus(ByVal data As LogStatusData) As Boolean
            Dim ret As Boolean = True
            Dim trans As New TransactionDB
            trans.CreateTransaction()
            Dim lDAL As New LogStatusDAL

            If lDAL.ChkDataBySTATUS_NAME(data.STATUS_NAME, trans.Trans) = True Then
                _err = "สถานะซ้ำ"
                ret = False
            Else
                If lDAL.ChkDataBySTATUS_ORDER(data.STATUS_ORDER, trans.Trans) = True Then
                    _err = "ลำดับที่ซ้ำ"
                    ret = False
                End If
            End If

            trans.CommitTransaction()

            Return ret
        End Function

        Public Function SaveLogState(ByVal data As LogStateData, ByVal UserID As String) As Boolean
            Dim trans As New TransactionDB
            trans.CreateTransaction()

            Dim lDAL As New LogStateDAL

            If data.ID <> 0 Then
                lDAL.GetDataByPK(data.ID, trans.Trans)
            End If

            lDAL.STATE_NAME = data.STATE_NAME
            lDAL.STATE_DESC = data.STATE_DESC
            lDAL.STATE_ORDER = data.STATE_ORDER
            lDAL.ACTIVE = data.ACTIVE

            Dim ret As Boolean = True
            If lDAL.ID = 0 Then
                ret = lDAL.InsertData(UserID, trans.Trans)
            Else
                ret = lDAL.UpdateByPK(UserID, trans.Trans)
            End If

            If ret = True Then
                trans.CommitTransaction()
            Else
                _err = lDAL.ErrorMessage
                trans.RollbackTransaction()
            End If

            Return ret

        End Function

        Public Function chkDupLogState(ByVal data As LogStateData) As Boolean
            Dim ret As Boolean = True
            Dim trans As New TransactionDB
            trans.CreateTransaction()
            Dim lDAL As New LogStateDAL

            If lDAL.ChkDataBySTATE_NAME(data.STATE_NAME, trans.Trans) = True Then
                _err = "สถานะซ้ำ"
                ret = False
            Else
                If lDAL.ChkDataBySTATE_ORDER(data.STATE_ORDER, trans.Trans) = True Then
                    _err = "ลำดับที่ซ้ำ"
                    ret = False
                End If
            End If

            trans.CommitTransaction()

            Return ret
        End Function
    End Class
End Namespace
