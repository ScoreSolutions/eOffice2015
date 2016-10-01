
Imports XCS.Data.Common
Imports XCS.DAL.Common.Utilities
Imports XCS.DAL.Table
Imports XCS.Data.Table

Namespace Common

    Public Class IssueFormProcess
        Dim _err As String = ""
        Dim _ID As Long = 0

        Public ReadOnly Property ID() As Long
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property
        Public Function SaveIssueTrackingLog(ByVal data As IssueTrackingLogData, ByVal UserID As String) As Boolean
            Dim trans As New TransactionDB
            trans.CreateTransaction()

            Dim iDAL As New IssueTrackingLogDAL
            If data.ID <> 0 Then
                iDAL.GetDataByPK(data.ID, trans.Trans)
            End If
            iDAL.PROJECT_ID = data.PROJECT_ID
            iDAL.LOG_NO = data.LOG_NO
            iDAL.REF_REQUEST_NO = data.REF_REQUEST_NO
            iDAL.TYPE_ID = data.TYPE_ID
            iDAL.LOG_DESC = data.LOG_DESC
            iDAL.STATE_ID = data.STATE_ID
            iDAL.STATUS_ID = data.STATUS_ID
            iDAL.PRIORITY = data.PRIORITY
            iDAL.LOG_INSTANCE = data.LOG_INSTANCE
            iDAL.SCREEN_ID = data.SCREEN_ID
            iDAL.MODULE_ID = data.MODULE_ID
            iDAL.RAISED_BY = data.RAISED_BY
            iDAL.RAISED_ON = data.RAISED_ON
            iDAL.CHANGE_APPROVE = data.CHANGE_APPROVE
            iDAL.COMMENTS = data.COMMENTS
            iDAL.ASSIGNED_TO = data.ASSIGNED_TO
            iDAL.ASSIGNED_DATE = data.ASSIGNED_DATE
            iDAL.EXPECTED_CLOSED_DATE = data.EXPECTED_CLOSED_DATE
            iDAL.CLOSED_BY = data.CLOSED_BY
            iDAL.CLOSED_DATE = data.CLOSED_DATE
            iDAL.ESTIMATE_FIXED_DATE = data.ESTIMATE_FIXED_DATE
            iDAL.RESOLVE_STATUS_ID = data.RESOLVE_STATUS_ID
            iDAL.COMPLEXITY_LEVEL = data.COMPLEXITY_LEVEL
            iDAL.RESOLVED_COMMENT = data.RESOLVED_COMMENT
            iDAL.RESOLVED_DATE = data.RESOLVED_DATE
            iDAL.RESOLUTION = data.RESOLUTION

            Dim ret As Boolean = True
            If iDAL.ID <> 0 Then
                ret = iDAL.UpdateByPK(UserID, trans.Trans)
            Else
                ret = iDAL.InsertData(UserID, trans.Trans)
            End If
            If ret = True Then
                _ID = iDAL.ID
                trans.CommitTransaction()
            Else
                _err = iDAL.ErrorMessage
                trans.RollbackTransaction()
            End If

            Return ret
        End Function

        Public Function SaveAttachFile(ByVal data As IssueLogAttachFileData, ByVal UserID As String) As Boolean
            Dim ret As Boolean = True

            Dim trans As New TransactionDB
            trans.CreateTransaction()
            Try
                Dim aDal As New IssueLogAttachFileDAL
                If data.ID <> 0 Then
                    aDal.ChkDataByPK(data.ID, trans.Trans)
                End If

                aDal.ISSUE_TRACKING_LOG_ID = data.ISSUE_TRACKING_LOG_ID
                aDal.FILE_NAME = data.FILE_NAME
                aDal.FILE_DESC = data.FILE_DESC
                aDal.FILE_EXTENTION = data.FILE_EXTENTION

                If data.ID <> 0 Then
                    ret = aDal.UpdateByPK(UserID, trans.Trans)
                Else
                    ret = aDal.InsertData(UserID, trans.Trans)
                End If

                If ret = True Then
                    trans.CommitTransaction()
                Else
                    _err = aDal.ErrorMessage
                    trans.RollbackTransaction()
                End If

            Catch ex As Exception
                _err = ex.Message
                trans.RollbackTransaction()
            End Try

            Return ret
        End Function

        Public Function GenLogNo(ByVal ProjectID As Long) As String
            Dim vYear As String = DateTime.Now.ToString("yyyy", New Globalization.CultureInfo("en-US"))

            Dim iDAL As New IssueTrackingLogDAL
            Dim dt As DataTable = iDAL.GetListBySql("select max(log_no) log_no from TRACKINGLOG_issue_tracking_log where project_id = " & ProjectID & " and convert(varchar(4),create_on,112)='" & vYear & "'", "", Nothing)
            If Convert.IsDBNull(dt.Rows(0)("log_no")) = False Then
                Return CInt(dt.Rows(0)("log_no")) + 1
            Else
                Return "1"
            End If

        End Function

        Public Function GetIssueDataByID(ByVal vID As Long, ByVal trans As TransactionDB) As IssueTrackingLogData
            Dim lDAL As New IssueTrackingLogDAL
            Return lDAL.GetDataByPK(vID, trans.Trans)
        End Function

        Public Function GetProjectList(ByVal UserID As String) As DataTable
            Dim lDAL As New ProjectDAL
            Dim sql As String = "select pj.id, pj.project_code + ' : ' + pj.project_name project_name "
            sql += " from TRACKINGLOG_project_staff ps"
            sql += " inner join TRACKINGLOG_project pj on pj.id=ps.project_id"
            sql += " inner join TRACKINGLOG_staff st on st.id=ps.staff_id"
            sql += " where st.username = '" + UserID + "'"
            Dim trans As New TransactionDB
            trans.CreateTransaction()
            Dim dt As DataTable = lDAL.GetListBySql(sql, "pj.project_name", trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetProjectData(ByVal ProjectID As Long, ByVal trans As TransactionDB) As ProjectData
            Dim pDal As New ProjectDAL
            Dim pData As ProjectData = pDal.GetDataByPK(ProjectID, trans.Trans)
            Return pData
        End Function

        Public Function GetLastFileName(ByVal LogData As IssueTrackingLogData) As String
            Dim trans As New TransactionDB
            trans.CreateTransaction()
            Dim ret As String = ""
            Dim sql As String = ""
            sql += "select ia.id ia_id, pj.project_code"
            sql += " from  TRACKINGLOG_ISSUE_LOG_ATTACH_FILE ia "
            sql += " inner join TRACKINGLOG_ISSUE_TRACKING_LOG al on al.id=ia.issue_tracking_log_id "
            sql += " inner join TRACKINGLOG_PROJECT pj on pj.id=al.project_id"
            sql += " where al.id = " & LogData.ID

            Dim iDal As New IssueTrackingLogDAL
            Dim dt As DataTable = iDal.GetListBySql(sql, "", trans.Trans)
            If dt.Rows.Count > 0 Then
                Dim vProjectCode = dt.Rows(0)("project_code")
                Dim iSql As String = ""
                iSql += " select top 1 REPLACE(ia.file_name, SUBSTRING(ia.file_name,1,LEN(pj.project_code)+LEN(il.log_no)+1)+'-','') running"
                iSql += " from TRACKINGLOG_ISSUE_LOG_ATTACH_FILE ia"
                iSql += " inner join TRACKINGLOG_ISSUE_TRACKING_LOG il on il.id=ia.issue_tracking_log_id"
                iSql += " inner join TRACKINGLOG_PROJECT pj on pj.id=il.project_id"
                iSql += " where SUBSTRING(ia.file_name,1,LEN(pj.project_code)+LEN(il.log_no)+1) = '" & vProjectCode & "' + '-' + '" & LogData.LOG_NO & "'"
                iSql += " order by running desc "

                Dim iDt As DataTable = iDal.GetListBySql(iSql, "", trans.Trans)
                If iDt.Rows.Count > 0 Then
                    ret = vProjectCode & "-" & LogData.LOG_NO & "-" & (Convert.ToDouble(iDt.Rows(0)("running") + 1)).ToString.PadLeft(3, "0")
                Else
                    ret = vProjectCode & "-" & LogData.LOG_NO & "-001"
                End If
            Else
                Dim pjData As ProjectData = GetProjectData(LogData.PROJECT_ID, trans)
                ret = pjData.PROJECT_CODE & "-" & LogData.LOG_NO & "-001"
            End If
            trans.CommitTransaction()
            Return ret
        End Function

        Public Function GetFileList(ByVal LogID As Long) As DataTable
            Dim dal As New IssueLogAttachFileDAL
            Dim trans As New TransactionDB
            trans.CreateTransaction()
            Dim dt As DataTable = dal.GetDataList("issue_tracking_log_id = " & LogID, "file_name", trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function DeleteAttachFile(ByVal vID As Long) As Boolean
            Dim ret As Boolean = True
            Dim trans As New TransactionDB
            trans.CreateTransaction()
            Try
                Dim dal As New IssueLogAttachFileDAL
                dal.GetDataByPK(vID, trans.Trans)
                ret = dal.DeleteByPK(trans.Trans)
                If ret = True Then
                    trans.CommitTransaction()
                Else
                    _err = dal.ErrorMessage
                    trans.RollbackTransaction()
                End If
            Catch ex As Exception
                ret = False
                _err = ex.Message
                trans.RollbackTransaction()
            End Try

            Return ret
        End Function

        Public Function GetAttachData(ByVal vID As Long, ByVal trans As TransactionDB) As IssueLogAttachFileData
            Dim dal As New IssueLogAttachFileDAL
            Return dal.GetDataByPK(vID, trans.Trans)
        End Function
    End Class
End Namespace
