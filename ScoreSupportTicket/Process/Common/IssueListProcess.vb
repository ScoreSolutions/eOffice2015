
Imports XCS.Data.Common
Imports XCS.DAL.Common.Utilities
Imports XCS.DAL.Table
Imports XCS.Data.Table

Namespace Common
    Public Class IssueListProcess
        Public Function SearchData(ByVal whText As String, ByVal orderBy As String, ByVal UserID As String, ByVal trans As TransactionDB) As DataTable
            Dim dt As DataTable
            Dim sql As String = ""
            sql += "select il.id, pj.project_code, il.log_no,lt.type_name, il.log_desc, ls.status_name, "
            sql += " case il.priority when 'H' then 'HEIGHT' when 'M' then 'MEDIUM' when 'L' then 'LOW' end priority, "
            sql += " tt.state_name, il.log_instance, sc.screen_name, md.module_name, "
            sql += " str.staffname staff_raise, il.raised_on raised_date, "
            sql += " il.change_approve, "
            sql += " il.comments, sta.staffname staff_assign_to,il.assigned_date ,"
            sql += " il.expected_closed_date, "
            sql += " stc.staffname staff_close, il.closed_date,il.create_on"
            sql += " from TRACKINGLOG_issue_tracking_log il"
            sql += " inner join TRACKINGLOG_log_type lt on lt.id=il.type_id"
            sql += " inner join TRACKINGLOG_log_status ls on ls.id=il.status_id"
            sql += " inner join TRACKINGLOG_project pj on pj.id=il.project_id"
            sql += " left join TRACKINGLOG_log_state tt on tt.id=il.state_id"
            sql += " left join TRACKINGLOG_screen sc on sc.id=il.screen_id"
            sql += " left join TRACKINGLOG_module md on md.id=il.module_id"
            sql += " inner join TRACKINGLOG_staff str on str.username=il.raised_by"
            sql += " left join TRACKINGLOG_staff sta on sta.username=il.assigned_to"
            sql += " left join TRACKINGLOG_staff stc on stc.username=il.closed_by"
            sql += " where il.project_id in (select ps.project_id from TRACKINGLOG_project_staff ps inner join TRACKINGLOG_staff s on s.id=ps.staff_id where s.username = '" & UserID & "') "
            sql += whText

            Dim iDAL As New IssueTrackingLogDAL
            dt = iDAL.GetListBySql(sql, orderBy, trans.Trans)
            Return dt
        End Function

        Public Function GetProjectList(ByVal UserID As String, ByVal trans As TransactionDB) As DataTable
            Dim lDAL As New ProjectDAL
            Dim sql As String = "select pj.id, pj.project_code + ' : ' + pj.project_name project_name "
            sql += " from TRACKINGLOG_project_staff ps"
            sql += " inner join TRACKINGLOG_project pj on pj.id=ps.project_id"
            sql += " inner join TRACKINGLOG_staff st on st.id=ps.staff_id"
            sql += " where st.username = '" + UserID + "'"
            Dim dt As DataTable = lDAL.GetListBySql(sql, "pj.project_name", trans.Trans)
            Return dt
        End Function

        Public Function GetStatusList(ByVal trans As TransactionDB) As DataTable
            Dim dal As New LogStatusDAL
            Dim dt As DataTable = dal.GetDataList("1=1", "status_order", trans.Trans)
            Return dt
        End Function

        Public Function GetModuleList(ByVal ProjectID As Long, ByVal trans As TransactionDB) As DataTable
            Dim dal As New ModuleDAL
            Return dal.GetDataList("project_id = " & ProjectID, "module_order", trans.Trans)
        End Function

        Public Function GetTypeList(ByVal trans As TransactionDB) As DataTable
            Dim dal As New LogTypeDAL
            Return dal.GetDataList("1=1", "type_order", trans.Trans)
        End Function

        Public Function GetStateList(ByVal trans As TransactionDB) As DataTable
            Dim dal As New LogStateDAL
            Return dal.GetDataList("1=1", "state_order", trans.Trans)
        End Function

        Public Function GetScreenList(ByVal ModuleID As Long, ByVal trans As TransactionDB) As DataTable
            Dim dal As New ScreenDAL
            Return dal.GetDataList("module_id = " & ModuleID, "screen_order", trans.Trans)
        End Function
    End Class
End Namespace
