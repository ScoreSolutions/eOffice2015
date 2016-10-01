Imports XCS.DAL.Common.Utilities
Imports XCS.DAL.Table
Imports XCS.Data.Table

Namespace Master

    Public Class StaffFormProcess
        Dim _err As String = ""
        Dim _StaffID As Long = 0
        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property
        Public ReadOnly Property StaffID() As Long
            Get
                Return _StaffID
            End Get
        End Property
        Public Function chkDupStaff(ByVal data As StaffData) As Boolean
            Dim ret As Boolean = True
            Dim trans As New TransactionDB
            trans.CreateTransaction()

            Dim sDAL As New StaffDAL
            If sDAL.ChkDataByUSERNAME(data.USERNAME, trans.Trans) = True Then
                If data.ID <> sDAL.ID Then
                    ret = False
                End If
            Else
                If sDAL.ChkDataBySTAFFNAME(data.STAFFNAME, trans.Trans) = True Then
                    If data.ID <> sDAL.ID Then
                        ret = False
                    End If
                End If
            End If
            trans.CommitTransaction()
            Return ret
        End Function
        Public Function SaveStaffData(ByVal UserID As String, ByVal data As StaffData, ByVal chkProj As DataTable) As Boolean
            Dim ret As Boolean = True
            Dim trans As New TransactionDB
            trans.CreateTransaction()

            Dim sDAL As New StaffDAL
            If data.ID <> 0 Then
                sDAL.GetDataByPK(data.ID, trans.Trans)
            Else
                sDAL.PWD = data.PWD
            End If
            sDAL.USERNAME = data.USERNAME
            sDAL.STAFFNAME = data.STAFFNAME
            sDAL.POSITION_NAME = data.POSITION_NAME
            sDAL.DIVISION_NAME = data.DIVISION_NAME
            sDAL.CAN_RAISE = data.CAN_RAISE
            sDAL.CAN_ACCEPT_ASSIGNMENT = data.CAN_ACCEPT_ASSIGNMENT
            sDAL.CAN_CLOSE = data.CAN_CLOSE
            sDAL.ACTIVE = data.ACTIVE

            If sDAL.ID = 0 Then
                ret = sDAL.InsertData(UserID, trans.Trans)
            Else
                ret = sDAL.UpdateByPK(UserID, trans.Trans)
            End If

            If ret = True Then
                Dim psDal As New ProjectStaffDAL
                Dim dt As DataTable = psDal.GetDataList("staff_id = " & sDAL.ID, "", trans.Trans)
                For i As Integer = 0 To dt.Rows.Count - 1
                    ret = psDal.DeleteByPROJECT_ID_STAFF_ID(dt.Rows(i)("project_id"), sDAL.ID, trans.Trans)
                    If ret = False Then
                        _err = psDal.ErrorMessage
                        Exit For
                    End If
                Next

                If ret = True Then
                    If chkProj.Rows.Count > 0 Then
                        For i As Integer = 0 To chkProj.Rows.Count - 1
                            'Dim psDal As New ProjectStaffDAL
                            Dim HaveData As Boolean = psDal.ChkDataByPROJECT_ID_STAFF_ID(chkProj.Rows(i)("project_id"), sDAL.ID, trans.Trans)
                            psDal.STAFF_ID = sDAL.ID
                            psDal.PROJECT_ID = chkProj.Rows(i)("project_id")

                            If HaveData = True Then
                                ret = psDal.DeleteByPK(Nothing)
                                If ret = False Then
                                    _err = psDal.ErrorMessage
                                    Exit For
                                End If
                            End If

                            ret = psDal.InsertData(UserID, trans.Trans)
                            If ret = False Then
                                _err = psDal.ErrorMessage
                                Exit For
                            End If
                        Next
                    End If
                    If ret = True Then
                        _StaffID = sDAL.ID
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                    End If
                Else
                    _err = psDal.ErrorMessage
                    trans.RollbackTransaction()
                End If
            Else
                _err = sDAL.ErrorMessage
                trans.RollbackTransaction()
            End If

            Return ret
        End Function

        Public Function GetStaffList(ByVal whText As String, ByVal trans As TransactionDB) As DataTable
            Dim sDal As New StaffDAL
            Dim sql As String = "select st.username, st.staffname "
            sql += " from TRACKINGLOG_project_staff ps"
            sql += " inner join TRACKINGLOG_staff st on st.id=ps.staff_id"
            sql += " inner join TRACKINGLOG_project pj on pj.id=ps.project_id"
            sql += " where " & whText
            sql += " order by staffname"
            Return sDal.GetListBySql(sql, "", trans.Trans)
        End Function
        Public Function GetProjectStaff(ByVal StaffID As Long, ByVal trans As TransactionDB) As DataTable
            Dim psDAL As New ProjectStaffDAL
            Return psDAL.GetDataList("staff_id = " & StaffID, "", trans.Trans)
        End Function

        Public Function GetProjectList(ByVal trans As TransactionDB) As DataTable
            Dim lDAL As New ProjectDAL
            Dim sql As String = "select pj.id, pj.project_code + ' : ' + pj.project_name project_name "
            sql += " from TRACKINGLOG_project pj "
            Return lDAL.GetListBySql(sql, "pj.project_code,pj.project_name", trans.Trans)
        End Function

        Public Function GetProjectData(ByVal projectID As Long, ByVal trans As TransactionDB) As ProjectData
            Dim dal As New ProjectDAL
            Return dal.GetDataByPK(projectID, trans.Trans)
        End Function
        Public Function GetStaffData(ByVal vID As Long, ByVal trans As TransactionDB) As StaffData
            Dim dal As New StaffDAL
            Return dal.GetDataByPK(vID, trans.Trans)
        End Function
        Public Function GetStaffData(ByVal vUserName As String, ByVal trans As TransactionDB) As StaffData
            Dim dal As New StaffDAL
            Return dal.GetDataByUSERNAME(vUserName, trans.Trans)
        End Function
    End Class
End Namespace
