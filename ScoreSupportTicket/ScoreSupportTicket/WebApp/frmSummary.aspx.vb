Imports System.Web.Security
Imports XCS.Data.Common
Imports XCS.Process.Common
Imports System.Data
Imports System.Reflection
Imports exc = Microsoft.Office.Interop.Excel

Partial Class WebApp_frmSummary
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            If Func.ChkLogin() = False Then
                Response.Redirect(FormsAuthentication.LoginUrl)
            End If
            Dim frm As Template_MasterPage
            frm = Me.Master
            frm.SetPageName("Summary Page")

            Dim trans As New DbTransProcess
            trans.CreateTransaction()
            Dim Proj As New SummaryProcess
            Dim dt As DataTable = Proj.GetProjectList(Func.GetUserName(), trans)
            If dt.Rows.Count > 0 Then
                cmbProject.SetItemList(dt, "project_name", "id")
                SetSummaryList(trans)
            End If
            trans.CommitTransaction()
        End If

    End Sub

    Protected Sub lnkLogNo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("frmIssueForm.aspx?id=" & sender.CommandArgument)
    End Sub

    Protected Sub lnkPrintCR_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim scr As String = "<script language='javascript' >"
        scr += " window.open('../WebApp/frmCRForm.aspx?id=" & sender.CommandArgument & "', '_blank', 'height=650,left=600,location=no,menubar=yes,toolbar=no,status=no,resizable=yes,scrollbars=yes', true);"
        scr += " </script>"

        ScriptManager.RegisterStartupScript(Me, GetType(String), "CrForm", scr, False)
    End Sub

    Public Sub SetSummaryList(ByVal trans As DbTransProcess)
        Dim ds As New DataSet

        Dim Proc As New SummaryProcess
        Dim dtSL As DataTable = Proc.GetSummaryList(cmbProject.SelectedValue, trans)
        GridView1.DataSource = dtSL
        GridView1.DataBind()
        ds.Tables.Add(dtSL)

        GridView2.DataSource = Proc.GetSummaryDetail(cmbProject.SelectedValue, trans)
        GridView2.DataBind()

        GridView3.DataSource = Proc.GetDetailList(cmbProject.SelectedValue, trans)
        GridView3.DataBind()

        Session("SummarySession") = ds
    End Sub

    Protected Sub cmbProject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProject.SelectedIndexChanged
        Dim trans As New DbTransProcess
        trans.CreateTransaction()
        SetSummaryList(trans)
        trans.CommitTransaction()
    End Sub

    Public Sub ExportToExcel(ByVal dt As DataTable)
        Dim gd As New DataGrid
        Dim sw As New System.IO.StringWriter()
        Dim htw As New System.Web.UI.HtmlTextWriter(sw)
        gd.DataSource = dt.DataSet
        gd.DataBind()
        gd.RenderControl(htw)

        Response.ContentType = "application/vnd.ms-excel"
        Me.EnableViewState = False
        Response.Write(sw.ToString)
        Response.End()

        'Try
        '    If dt.Rows.Count > 0 Then
        '        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")

        '        Dim resApp As New exc.Application
        '        Dim resBook As exc._Workbook = resApp.Workbooks.Add(Missing.Value)
        '        Dim resSheet As exc._Worksheet = resBook.ActiveSheet
        '        For j As Integer = 0 To dt.Columns.Count - 1
        '            resSheet.Rows.Cells(1, j + 1) = dt.Columns(j).ColumnName
        '        Next

        '        Dim i As Integer = 0
        '        Dim n As Integer = 0
        '        For i = 0 To dt.Rows.Count - 1
        '            For n = 0 To dt.Columns.Count - 1
        '                resSheet.Rows.Cells(i + 2, n + 1) = dt.Rows(i)(dt.Columns(n).ColumnName).ToString().Trim()
        '            Next
        '        Next
        '        Dim excRang As exc.Range = resSheet.Range(resSheet.Rows.Cells(1, 1), resSheet.Rows.Cells(i + 1, n + 1))
        '        excRang.EntireColumn.AutoFit()
        '        resApp.Visible = True
        '        'resApp.UserControl = True
        '        resApp.SaveWorkspace("D:\MyProject\TrackingLog\TrackingLog\Bin\MyExcelFile.xls")
        '        resApp.Application.Quit()
        '        resBook = Nothing
        '        resSheet = Nothing
        '    End If
        'Catch ex As Exception

        'End Try

    End Sub
    

    Protected Sub imgSummaryOpenExportExcel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSummaryOpenExportExcel.Click
        'Dim ds As DataSet = Session("SummarySession")

        'If ds.Tables(0) IsNot Nothing Then
        '    'Dim proc As New SummaryProcess
        '    ExportToExcel(ds.Tables(0))
        'End If

        Response.Redirect("../Reports/rptSummaryOpen.aspx")


    End Sub
End Class
