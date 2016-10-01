Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class Report
    Inherits System.Web.UI.Page

#Region "Declare & Para"
    Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Support-TicketConnectionString").ConnectionString)
    Dim Cmd As New SqlCommand
#End Region

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If DropDownList1.SelectedValue = "0" Then 'export button
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Please Select Report.');", True)
        ElseIf DropDownList1.SelectedValue = "1" Then
            Dim startd As String
            startd = ddYs.Text + "/"
            startd += ddMs.Text + "/"
            startd += ddDs.Text

            Dim endd As String
            endd = ddYe.Text + "/"
            endd += ddMe.Text + "/"
            endd += ddDe.Text

            SendREport(startd, endd) 'call function report 
        ElseIf DropDownList1.SelectedValue = "2" Then
            SendREportpro(ddpro.SelectedValue)

        ElseIf DropDownList1.SelectedValue = "3" Then
            SendREportsup(ddsup.SelectedValue)
        End If
    End Sub
    Private Sub SendREport(ByVal startd As String, ByVal endd As String) 'function sql select for report by date
        Dim sql As String = "select TICKET_TICKET.ticket_code,TICKET_PROJECT.project_name,TICKET_BRANCH.branch_name,TICKET_TICKET.ticket_description,TICKET_TICKET.assign_to,TICKET_TICKET.resolved,TICKET_TICKET.create_on,TICKET_TICKET.close_on from TICKET_TICKET join TICKET_PROJECT on TICKET_TICKET.project_id=TICKET_PROJECT.id join TICKET_BRANCH on TICKET_TICKET.branch_id=TICKET_BRANCH.branch_id where CONVERT(DATE, TICKET_TICKET.create_on, 103) BETWEEN '" & startd & "' AND '" & endd & "'"
        Dim cmd As New SqlCommand(sql, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        con.Close()

        ds.Tables(0).TableName = "dsDialy"
        Session("dsReport") = ds

        Dim strScripth As String = "window.open('Report/frmReport.aspx?ReportName=Report1',config='height=100%,widht=100%');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", strScripth, True)
    End Sub
    Private Sub SendREportpro(ByVal value As String) 'function sql select for report by project
        Dim sql As String = "select TICKET_TICKET.ticket_code,TICKET_PROJECT.project_name,TICKET_BRANCH.branch_name,TICKET_TICKET.ticket_description,TICKET_TICKET.assign_to,TICKET_TICKET.resolved,TICKET_TICKET.create_on,TICKET_TICKET.close_on from TICKET_TICKET join TICKET_PROJECT on TICKET_TICKET.project_id=TICKET_PROJECT.id join TICKET_BRANCH on TICKET_TICKET.branch_id=TICKET_BRANCH.branch_id where TICKET_TICKET.project_id = '" & value & "'"
        Dim cmd As New SqlCommand(sql, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        con.Close()

        ds.Tables(0).TableName = "dsDialy"
        Session("dsReport") = ds

        Dim strScripth As String = "window.open('Report/frmReport.aspx?ReportName=Report1',config='height=100%,widht=100%');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", strScripth, True)

    End Sub
    Private Sub SendREportsup(ByVal value As String) 'function sql select for report by support
        Dim sql As String = "select TICKET_TICKET.ticket_code,TICKET_PROJECT.project_name,TICKET_BRANCH.branch_name,TICKET_TICKET.ticket_description,TICKET_TICKET.assign_to,TICKET_TICKET.resolved,TICKET_TICKET.create_on,TICKET_TICKET.close_on from TICKET_TICKET join TICKET_PROJECT on TICKET_TICKET.project_id=TICKET_PROJECT.id join TICKET_BRANCH on TICKET_TICKET.branch_id=TICKET_BRANCH.branch_id where TICKET_TICKET.assign_to = '" & value & "'"
        Dim cmd As New SqlCommand(sql, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        con.Close()

        ds.Tables(0).TableName = "dsDialy"
        Session("dsReport") = ds

        Dim strScripth As String = "window.open('Report/frmReport.aspx?ReportName=Report1',config='height=100%,widht=100%');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", strScripth, True)

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        If DropDownList1.SelectedValue = "1" Then
            Label2.Visible = True
            Label1.Text = "Start Date"
            Label1.Visible = True
            btnExport.Visible = True
            ddDe.Visible = True
            ddMe.Visible = True
            ddYe.Visible = True
            ddDs.Visible = True
            ddMs.Visible = True
            ddYs.Visible = True
            ddpro.Visible = False
            ddsup.Visible = False
        ElseIf DropDownList1.SelectedValue = "2" Then
            ddpro.Visible = True
            btnExport.Visible = True       
            Label1.Text = "Select Project Name"
            Label1.Visible = True

            ddsup.Visible = False
            Label2.Visible = False
            ddDe.Visible = False
            ddMe.Visible = False
            ddYe.Visible = False
            ddDs.Visible = False
            ddMs.Visible = False
            ddYs.Visible = False
        ElseIf DropDownList1.SelectedValue = "3" Then
            ddsup.Visible = True
            btnExport.Visible = True
            Label1.Text = "Select Support Name"
            Label1.Visible = True

            ddpro.Visible = False
            Label2.Visible = False
            ddDe.Visible = False
            ddMe.Visible = False
            ddYe.Visible = False
            ddDs.Visible = False
            ddMs.Visible = False
            ddYs.Visible = False
        End If

    End Sub

End Class