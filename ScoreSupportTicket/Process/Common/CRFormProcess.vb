Imports XCS.DAL.Table
Imports XCS.DAL.Common
Imports XCS.Data.Table
Namespace Common
    Public Class CRFormProcess
        Public Function GetFunctionalArea(ByVal vLogID As Long, ByVal trans As XCS.DAL.Common.Utilities.TransactionDB) As String
            Dim ret As String = ""
            Dim dt As New DataTable
            Dim sql As String = ""
            sql += " select m.module_name + '<br />' + s.screen_name function_area "
            sql += " from TRACKINGLOG_ISSUE_TRACKING_LOG t"
            sql += " left join TRACKINGLOG_MODULE m on t.module_id=m.id"
            sql += " left join TRACKINGLOG_SCREEN s on t.screen_id=s.id"
            sql += " where t.id= " & vLogID

            Dim lnq As New IssueTrackingLogDAL
            dt = lnq.GetListBySql(sql, "", trans.Trans)

            If dt.Rows.Count > 0 Then
                ret = dt.Rows(0)("function_area")
                dt.Dispose()
                dt = Nothing
            End If

            Return ret
        End Function
    End Class
End Namespace

