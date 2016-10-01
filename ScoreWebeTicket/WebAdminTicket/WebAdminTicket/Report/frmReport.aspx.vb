Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmReport
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Support-TicketConnectionString").ConnectionString)
    Private Function Data() As DataSet 'ฟังก์ชั่น สร้าง Dataset เพื่อเอาไปใช้ใน report1.rpt
        Dim sql As String = "select TICKET_TICKET.ticket_code,TICKET_PROJECT.project_name,TICKET_BRANCH.branch_name,TICKET_TICKET.ticket_description,TICKET_TICKET.assign_to,TICKET_TICKET.resolved,TICKET_TICKET.create_on,TICKET_TICKET.close_on from TICKET_TICKET join TICKET_PROJECT on TICKET_TICKET.project_id=TICKET_PROJECT.id join TICKET_BRANCH on TICKET_TICKET.branch_id=TICKET_BRANCH.branch_id"
        Dim cmd As New SqlCommand(sql, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        con.Close()

        ds.Tables(0).TableName = "dsDialy"

        ds.WriteXmlSchema("D:\dsDialy.xsd")


        Return ds
    End Function

#Region "Declare Class & Variable"
    Private rpt As New ReportDocument
#End Region

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Me.lblReportName.Text = "" Then
            Me.lblReportName.Text = Session("ReportName")
        End If

        If Not Page.IsPostBack() Then
            If Not IsNothing(Request.QueryString("ReportName")) Then 'รับค่าจาก หน้า Report จาก url
                Session("ReportName") = Request.QueryString("ReportName")
                Response.Redirect("frmReport.aspx")
            End If

            PopulateData()
        Else
            Me.CrystalReportViewer1.ReportSource = Session(Me.lblReportName.Text & "rpt")
        End If
    End Sub
    Public Sub PopulateData() 'ฟังก์ชั่น Load ไฟล์ Report
        Try
            rpt.Load(Server.MapPath("..\Report\" & Me.lblReportName.Text & ".rpt"))
            Dim mDSReport As New DataSet '

            If Not IsNothing(Session("dsReport")) Then
                mDSReport = Session("dsReport")
            End If
            With mDSReport
                For i As Integer = 0 To .Tables.Count - 1
                    rpt.Database.Tables(.Tables(i).TableName).SetDataSource(.Tables(i))
                Next
            End With
            Session(Me.lblReportName.Text & "rpt") = rpt
            CrystalReportViewer1.ReportSource = Session(Me.lblReportName.Text & "rpt")
            CrystalReportViewer1.Zoom(100)
        Catch ex As Exception
            Me.lblFeedBack.Text = ex.Message
        Finally
        End Try
    End Sub
End Class