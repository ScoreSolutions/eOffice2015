Imports System.Data

Partial Class Reports_rptSummaryOpen
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            Dim ds As DataSet = Session("SummarySession")
            If ds IsNot Nothing Then
                ExportToExcel(ds.Tables(0))
                Response.Redirect("../WebApp/frmSummary.aspx?time=" & Today.Now.Millisecond)
            End If
        End If
        
    End Sub

    Public Sub ExportToExcel(ByVal dt As DataTable)
        Dim gd As New DataGrid
        Dim sw As New System.IO.StringWriter()
        Dim htw As New System.Web.UI.HtmlTextWriter(sw)
        gd.DataSource = dt
        gd.DataBind()
        gd.RenderControl(htw)

        Response.ContentType = "application/vnd.ms-excel"
        Me.EnableViewState = False
        Response.Write(sw.ToString)
        Response.End()
    End Sub
End Class
