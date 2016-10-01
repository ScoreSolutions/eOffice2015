Imports XCS.Data.Common
Imports XCS.DAL.Common
Imports XCS.Data.Table
Imports XCS.DAL.Table
Imports XCS.Data.Common.Utilities
Imports XCS.DAL.Common.Utilities
Imports XCS.Process.Master
Imports System.Reflection
Imports exc = Microsoft.Office.Interop.Excel

Namespace Common
    Public Class SummaryProcess

        Public Function GetProjectList(ByVal UserID As String, ByVal trans As TransactionDB) As DataTable
            Dim lDAL As New ProjectDAL
            Dim sql As String = "select pj.id, pj.project_code + '-'+ pj.project_name project_name "
            sql += " from TRACKINGLOG_project_staff ps"
            sql += " inner join TRACKINGLOG_project pj on pj.id=ps.project_id"
            sql += " inner join TRACKINGLOG_staff st on st.id=ps.staff_id"
            sql += " where st.username = '" + UserID + "'"
            Return lDAL.GetListBySql(sql, "pj.project_name", trans.Trans)
        End Function

        Public Function GetSummaryList(ByVal ProjectID As Long, ByVal trans As TransactionDB) As DataTable
            Dim sql As String = ""
            sql += " select md.module_name, md.module_order,"
            sql += " sum(case il.priority when 'H' then 1 else 0 end) height,"
            sql += " sum(case il.priority when 'M' then 1 else 0 end) medium,"
            sql += " sum(case il.priority when 'L' then 1 else 0 end) low "
            sql += " from TRACKINGLOG_issue_tracking_log il"
            sql += " inner join TRACKINGLOG_module md on md.id=il.module_id"
            sql += " where il.status_id= " & FunctionProcess.GetConfigValue(Constant.SysConfigName.StatusOpen, trans)
            sql += " and il.project_id = " & ProjectID & " and il.closed_date is null "
            sql += " group by md.module_name,md.module_order "
            sql += " order by md.module_order "

            Dim dal As New IssueTrackingLogDAL
            Dim ret As DataTable = dal.GetListBySql(sql, "", trans.Trans)
            ret.Columns.Add("total")
            If ret.Rows.Count > 0 Then
                For i As Int16 = 0 To ret.Rows.Count - 1
                    ret.Rows(i)("total") = ret.Rows(i)("height") + ret.Rows(i)("medium") + ret.Rows(i)("low")
                Next
            End If
            Return ret
        End Function

        Public Function GetSummaryDetail(ByVal ProjectID As Long, ByVal trans As TransactionDB) As DataTable
            Dim sql As String = ""
            sql += " select md.module_name, md.module_order, count(il.id) total,"
            sql += " sum(case il.status_id when '" & FunctionProcess.GetConfigValue(Constant.SysConfigName.StatusClose, trans) & "'  then 1 else 0 end) closed,"
            sql += " sum(case il.status_id when '" & FunctionProcess.GetConfigValue(Constant.SysConfigName.StatusOpen, trans) & "'  then 1 else 0 end) opened,"
            sql += " sum(case when il.status_id = '" & FunctionProcess.GetConfigValue(Constant.SysConfigName.StatusOpen, trans) & "' and il.type_id = '" & FunctionProcess.GetConfigValue(Constant.SysConfigName.TypeDefect, trans) & "'  then 1 else 0 end) defect_open,"
            sql += " sum(case when il.status_id = '" & FunctionProcess.GetConfigValue(Constant.SysConfigName.StatusOpen, trans) & "' and il.type_id = '" & FunctionProcess.GetConfigValue(Constant.SysConfigName.TypeIssue, trans) & "'  then 1 else 0 end) issue_open"
            sql += " from TRACKINGLOG_issue_tracking_log il"
            sql += " inner join TRACKINGLOG_module md on md.id=il.module_id"
            sql += " where  il.project_id = " & ProjectID
            sql += " group by md.module_name,md.module_order "
            sql += " order by md.module_order "

            Dim dal As New IssueTrackingLogDAL
            Dim ret As DataTable = dal.GetListBySql(sql, "", Nothing)

            Return ret
        End Function

        Public Function GetDetailList(ByVal ProjectID As Long, ByVal trans As TransactionDB) As DataTable
            Dim sql As String = ""
            sql += " select il.id, il.log_no,il.log_desc, md.module_name, md.module_order, t.type_name,"
            sql += " case il.priority when 'H' then 'Height' when 'M' then 'Medium' when 'L' then 'Low' end priority,"
            sql += " s.status_name,st.staffname raised_by, il.raised_on, il.create_on"
            sql += " from TRACKINGLOG_issue_tracking_log il"
            sql += " inner join TRACKINGLOG_module md on md.id=il.module_id"
            sql += " inner join TRACKINGLOG_log_type t on t.id=il.type_id"
            sql += " inner join TRACKINGLOG_log_status s on s.id=il.status_id"
            sql += " inner join TRACKINGLOG_staff st on st.username = il.raised_by"
            sql += " where  il.project_id = " & ProjectID
            sql += " and il.status_id <> " & FunctionProcess.GetConfigValue(Constant.SysConfigName.StatusClose, trans)
            sql += " order by md.module_order, il.log_no "

            Dim dal As New IssueTrackingLogDAL
            Dim ret As DataTable = dal.GetListBySql(sql, "", Nothing)
            If ret.Rows.Count > 0 Then
                For i As Integer = 0 To ret.Rows.Count - 1
                    ret.Rows(i)("log_no") = Convert.ToDateTime(ret.Rows(i)("create_on")).ToString("yyyy", New Globalization.CultureInfo("en-US")) & ret.Rows(i)("log_no").ToString.PadLeft(4, "0")
                Next
            End If

            Return ret
        End Function

        Public Sub ExportToExcel(ByVal dt As DataTable)
            'Response.ClearContent()
            'Response.Buffer = True
            'Response.ContentType = "application/ms-excel"
            'Response.AddHeader("content-disposition", "attachment;filename=MyFiles.xls")
            'Me.EnableViewState = False

            'Dim sw As New System.IO.StringWriter()
            'Dim htw As New System.Web.UI.HtmlTextWriter(sw)
            'GridView1.DataSource = dt
            'GridView1.DataBind()
            'GridView1.RenderControl(htw)
            'Response.Write(sw.ToString)
            'Response.End()

            Try
                If dt.Rows.Count > 0 Then
                    System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")

                    Dim resApp As New exc.Application
                    Dim resBook As exc._Workbook = resApp.Workbooks.Add(Missing.Value)
                    Dim resSheet As exc._Worksheet = resBook.ActiveSheet
                    For j As Integer = 0 To dt.Columns.Count - 1
                        resSheet.Rows.Cells(1, j + 1) = dt.Columns(j).ColumnName
                    Next

                    Dim i As Integer = 0
                    Dim n As Integer = 0
                    For i = 0 To dt.Rows.Count - 1
                        For n = 0 To dt.Columns.Count - 1
                            resSheet.Rows.Cells(i + 2, n + 1) = dt.Rows(i)(dt.Columns(n).ColumnName).ToString().Trim()
                        Next
                    Next
                    Dim excRang As exc.Range = resSheet.Range(resSheet.Rows.Cells(1, 1), resSheet.Rows.Cells(i + 1, n + 1))
                    excRang.EntireColumn.AutoFit()
                    resApp.Visible = True
                    'resApp.UserControl = True
                    resApp.SaveWorkspace("D:\MyProject\TrackingLog\TrackingLog\Bin\MyExcelFile.xls")
                    resApp.Application.Quit()
                    resBook = Nothing
                    resSheet = Nothing
                End If
            Catch ex As Exception

            End Try

        End Sub
    End Class
End Namespace
