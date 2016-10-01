Imports OfficeOpenXml
Imports System.IO

Public Class Form1

    

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetProjectList()
    End Sub

    Private Sub SetProjectList()
        Dim dt As New DataTable
        Dim sql As String = "select id,project_code "
        sql += " from eoffice_project "
        sql += " order by project_code"

        dt = ConnectDB.SqlDB.ExecuteTable(sql)
        If dt.Rows.Count > 0 Then
            cbProject.DisplayMember = "project_code"
            cbProject.ValueMember = "id"
            cbProject.DataSource = dt
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            Using ep As New ExcelPackage
                

                Dim sqlS As String = "exec SP_ProjectManhourSummary '" & cbProject.SelectedValue & "'"
                Dim dtS As New DataTable
                dtS = ConnectDB.SqlDB.ExecuteTable(sqlS)
                If dtS.Rows.Count > 0 Then
                    GenerateExcelSummary(ep, dtS)
                End If
                dtS.Dispose()

                Dim sqlR As String = "exec SP_ProjectManhourRawData '" & cbProject.SelectedValue & "'"
                Dim dtR As New DataTable
                dtR = ConnectDB.SqlDB.ExecuteTable(sqlR)
                If dtR.Rows.Count > 0 Then
                    GenerateExcelRawData(ep, dtR)
                End If
                dtR.Dispose()

                Dim FilePath As String = Application.StartupPath & "\" & cbProject.Text & ".xlsx"
                If File.Exists(FilePath) = True Then
                    File.Delete(FilePath)
                End If

                Dim b() As Byte = ep.GetAsByteArray
                File.WriteAllBytes(FilePath, b)
            End Using

            MessageBox.Show("Export Complete")
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        
    End Sub
    Private Function GetFormatTimeFromSec(ByVal TimeSec As Integer) As String
        'แปลงเวลาจากวินาทีไปเป็น HH:mm:ss
        Dim tHour As Integer = 0
        Dim tMin As Integer = 0
        Dim tSec As Integer = 0
        If TimeSec >= 3600 Then
            tHour = Math.Floor(TimeSec / 3600) 'ชม.
            tMin = Math.Floor((TimeSec - (tHour * 3600)) / 60) ' นาที
            tSec = (TimeSec - (tHour * 3600)) Mod 60
        Else
            tMin = Math.Floor(TimeSec / 60)
            tSec = TimeSec Mod 60
        End If

        Return tHour.ToString.PadLeft(2, "0") & ":" & tMin.ToString.PadLeft(2, "0") & ":" & tSec.ToString.PadLeft(2, "0")
    End Function

    Private Function GetSecFromTimeFormat(ByVal TimeFormat As String) As Integer
        'แปลงเวลาในรูปแบบ HH:mm:ss ไปเป็นวินาที

        Dim ret As Int32 = 0
        If TimeFormat.Trim <> "" Then
            Dim tmp() As String = Split(TimeFormat, ":")
            Dim TimeSec As Integer = 0
            If Convert.ToInt64(tmp(0)) > 0 Then
                TimeSec += (Convert.ToInt64(tmp(0)) * 60 * 60)
            End If
            If Convert.ToInt64(tmp(1)) > 0 Then
                TimeSec += (Convert.ToInt64(tmp(1)) * 60)
            End If
            ret = TimeSec + Convert.ToInt32(tmp(2))
        End If
        Return ret
    End Function
    Private Sub GenerateExcelSummary(ByVal ep As ExcelPackage, ByVal dtS As DataTable)
        Dim sh As ExcelWorksheet = ep.Workbook.Worksheets.Add("Summary")
        sh.TabColor = System.Drawing.ColorTranslator.FromWin32(RGB(29, 213, 23))
        sh.Cells("A1").Value = "Manhour Summary for " & cbProject.Text
        SetReportNameColor(sh.Cells("A1"))

        Dim HeaderRow As Integer = 2
        sh.Cells("A" & HeaderRow).Value = "Project"
        sh.Cells("B" & HeaderRow).Value = "Billing"
        sh.Cells("C" & HeaderRow).Value = "PO No"
        sh.Cells("D" & HeaderRow).Value = "Employee"
        sh.Cells("E" & HeaderRow).Value = "Position"
        sh.Cells("F" & HeaderRow).Value = "Phase"
        sh.Cells("G" & HeaderRow).Value = "Manhour"
        SetHeaderColor(sh.Cells("A" & HeaderRow & ":G" & HeaderRow))

        Dim dtB As New DataTable
        dtB = dtS.DefaultView.ToTable(True, "project_code", "billing_name", "ref_po_no")
        If dtB.Rows.Count > 0 Then
            Dim TotWorkTime As Long = 0

            Dim i As Integer = HeaderRow + 1   'Current Row
            For Each drB As DataRow In dtB.Rows
                dtS.DefaultView.RowFilter = "project_code='" & drB("project_code") & "' and billing_name='" & drB("billing_name") & "' and ref_po_no='" & drB("ref_po_no") & "'"
                If dtS.DefaultView.Count > 0 Then
                    Dim SumWorkTime As Long = 0
                    For Each dr As DataRowView In dtS.DefaultView
                        sh.Cells("A" & i).Value = drB("project_code")
                        sh.Cells("B" & i).Value = drB("billing_name")
                        sh.Cells("C" & i).Value = drB("ref_po_no")
                        sh.Cells("D" & i).Value = dr("staff_name")
                        sh.Cells("E" & i).Value = dr("position_desc")
                        sh.Cells("F" & i).Value = dr("project_phase_name")

                        If Convert.ToInt64(dr("work_second")) > 0 Then
                            sh.Cells("G" & i).Value = GetFormatTimeFromSec(Convert.ToInt64(dr("work_second")))
                        End If
                        SumWorkTime += Convert.ToInt64(dr("work_second"))
                        TotWorkTime += Convert.ToInt64(dr("work_second"))

                        i += 1
                    Next

                    sh.Cells(i, 1, i, 6).Merge = True
                    sh.Cells("A" & i).Value = "Total Billing " & drB("billing_name")
                    sh.Cells("G" & i).Value = GetFormatTimeFromSec(SumWorkTime)
                    SetBillingTotalRow(sh.Cells("A" & i & ":G" & i))
                    i += 1
                End If
            Next

            sh.Cells(i, 1, i, 6).Merge = True
            sh.Cells("A" & i).Value = "Total Project " & cbProject.Text
            sh.Cells("G" & i).Value = GetFormatTimeFromSec(TotWorkTime)
            SetProjectTotalRow(sh.Cells("A" & i & ":G" & i))
            SetCellBorder(sh.Cells("A" & HeaderRow & ":G" & i))
        End If
    End Sub

    Private Sub GenerateExcelRawData(ByVal ep As ExcelPackage, ByVal dtR As DataTable)
        Dim sh As ExcelWorksheet = ep.Workbook.Worksheets.Add("RawData")
        sh.TabColor = System.Drawing.ColorTranslator.FromWin32(RGB(29, 213, 23))
        sh.Cells("A1").Value = "Manhour Detail for " & cbProject.Text
        SetReportNameColor(sh.Cells("A1"))

        Dim HeaderRow As Integer = 2
        sh.Cells("A" & HeaderRow).Value = "Project"
        sh.Cells("B" & HeaderRow).Value = "Billing"
        sh.Cells("C" & HeaderRow).Value = "PO No"
        sh.Cells("D" & HeaderRow).Value = "Employee"
        sh.Cells("E" & HeaderRow).Value = "Position"
        sh.Cells("F" & HeaderRow).Value = "Phase"
        sh.Cells("G" & HeaderRow).Value = "Work Date"
        sh.Cells("H" & HeaderRow).Value = "Description"
        sh.Cells("I" & HeaderRow).Value = "Start Time"
        sh.Cells("J" & HeaderRow).Value = "End Time"
        sh.Cells("K" & HeaderRow).Value = "Manhour"
        SetHeaderColor(sh.Cells("A" & HeaderRow & ":K" & HeaderRow))

        Dim dtB As New DataTable
        dtB = dtR.DefaultView.ToTable(True, "project_code", "billing_name", "ref_po_no")
        If dtB.Rows.Count > 0 Then
            Dim TotProject As Long = 0

            Dim i As Integer = HeaderRow + 1
            For Each drB As DataRow In dtB.Rows
                Dim TotBilling As Long = 0
                Dim dtE As New DataTable
                dtR.DefaultView.RowFilter = "project_code='" & drB("project_code") & "' and billing_name='" & drB("billing_name") & "'"
                dtE = dtR.DefaultView.ToTable(True, "project_code", "billing_name", "ref_po_no", "staff_name", "position_desc")  ' .RowFilter = "project_code='" & drB("project_code") & "' and billing_name='" & drB("billing_name") & "'"
                If dtE.Rows.Count > 0 Then
                    For Each drE As DataRow In dtE.Rows
                        Dim TotStaff As Long = 0
                        dtR.DefaultView.RowFilter = "project_code='" & drB("project_code") & "' and billing_name='" & drB("billing_name") & "' and staff_name='" & drE("staff_name") & "' and position_desc = '" & drE("position_desc") & "'"
                        If dtR.DefaultView.Count > 0 Then
                            For Each dr As DataRowView In dtR.DefaultView
                                sh.Cells("A" & i).Value = drB("project_code")
                                sh.Cells("B" & i).Value = drB("billing_name")
                                sh.Cells("C" & i).Value = drB("ref_po_no")
                                sh.Cells("D" & i).Value = drE("staff_name")
                                sh.Cells("E" & i).Value = drE("position_desc")
                                sh.Cells("F" & i).Value = dr("project_phase_name")
                                sh.Cells("G" & i).Value = Convert.ToDateTime(dr("start_time")).ToString("dd/MM/yyyy", New Globalization.CultureInfo("en-US"))
                                sh.Cells("H" & i).Value = dr("manhour_desc")
                                sh.Cells("I" & i).Value = Convert.ToDateTime(dr("start_time")).ToString("HH:mm tt")
                                sh.Cells("J" & i).Value = Convert.ToDateTime(dr("end_time")).ToString("HH:mm tt")

                                If Convert.ToInt64(dr("work_time")) > 0 Then
                                    sh.Cells("K" & i).Value = GetFormatTimeFromSec(Convert.ToInt64(dr("work_time")))
                                End If
                                TotStaff += Convert.ToInt64(dr("work_time"))
                                TotBilling += Convert.ToInt64(dr("work_time"))
                                TotProject += Convert.ToInt64(dr("work_time"))
                                i += 1
                            Next
                            dtR.DefaultView.RowFilter = ""

                            sh.Cells(i, 4, i, 10).Merge = True
                            sh.Cells("D" & i).Value = "Total " & drE("staff_name")
                            sh.Cells("K" & i).Value = GetFormatTimeFromSec(TotStaff)
                            SetStaffTotalRow(sh.Cells("A" & i & ":K" & i))
                            i += 1
                        End If
                    Next
                End If

                sh.Cells(i, 2, i, 10).Merge = True
                sh.Cells("B" & i).Value = "Total Billing " & drB("billing_name")
                sh.Cells("K" & i).Value = GetFormatTimeFromSec(TotBilling)
                SetBillingTotalRow(sh.Cells("A" & i & ":K" & i))
                i += 1
            Next

            sh.Cells(i, 1, i, 10).Merge = True
            sh.Cells("A" & i).Value = "Total Project " & cbProject.Text
            sh.Cells("K" & i).Value = GetFormatTimeFromSec(TotProject)
            SetProjectTotalRow(sh.Cells("A" & i & ":K" & i))
            SetCellBorder(sh.Cells("A" & HeaderRow & ":K" & i))
        End If
    End Sub

    Private Sub SetReportNameColor(ByVal CellRange As ExcelRange)
        Using CellsColor As ExcelRange = CellRange
            CellsColor.Style.Font.Bold = True
            CellsColor.Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
            CellsColor.Style.Font.Size = "18"
            CellsColor.Style.Font.Color.SetColor(Color.Black)
        End Using
    End Sub

    Private Sub SetHeaderColor(ByVal CellRange As ExcelRange)
        Using CellsColor As ExcelRange = CellRange
            CellsColor.Style.Font.Bold = True
            CellsColor.Style.Fill.PatternType = Style.ExcelFillStyle.Solid
            CellsColor.Style.Fill.BackgroundColor.SetColor(Color.YellowGreen)
            CellsColor.Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
            CellsColor.Style.Font.Color.SetColor(Color.White)
        End Using
    End Sub

    Private Sub SetStaffTotalRow(ByVal CellRange As ExcelRange)
        Using CellsColor As ExcelRange = CellRange
            CellsColor.Style.Font.Bold = True
            CellsColor.Style.Fill.PatternType = Style.ExcelFillStyle.Solid
            CellsColor.Style.Fill.BackgroundColor.SetColor(Color.LightBlue)
            CellsColor.Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
            CellsColor.Style.Font.Color.SetColor(Color.Black)
        End Using
    End Sub

    Private Sub SetBillingTotalRow(ByVal CellRange As ExcelRange)
        Using CellsColor As ExcelRange = CellRange
            CellsColor.Style.Font.Bold = True
            CellsColor.Style.Fill.PatternType = Style.ExcelFillStyle.Solid
            CellsColor.Style.Fill.BackgroundColor.SetColor(Color.LightGray)
            CellsColor.Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
            CellsColor.Style.Font.Color.SetColor(Color.Black)
        End Using
    End Sub

    Private Sub SetProjectTotalRow(ByVal CellRange As ExcelRange)
        Using CellsColor As ExcelRange = CellRange
            CellsColor.Style.Font.Bold = True
            CellsColor.Style.Fill.PatternType = Style.ExcelFillStyle.Solid
            CellsColor.Style.Fill.BackgroundColor.SetColor(Color.Gray)
            CellsColor.Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
            CellsColor.Style.Font.Color.SetColor(Color.Black)
        End Using
    End Sub

    Private Sub SetCellBorder(ByVal CellRange As ExcelRange)
        Using shRange As ExcelRange = CellRange
            shRange.AutoFitColumns()

            shRange.Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
            shRange.Style.Border.Left.Style = Style.ExcelBorderStyle.Thin
            shRange.Style.Border.Right.Style = Style.ExcelBorderStyle.Thin
            shRange.Style.Border.Bottom.Style = Style.ExcelBorderStyle.Thin
        End Using
    End Sub
End Class
