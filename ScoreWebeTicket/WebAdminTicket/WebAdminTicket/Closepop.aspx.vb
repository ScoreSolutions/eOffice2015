Imports System.Data.SqlClient

Public Class Closepop
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Support-TicketConnectionString").ConnectionString)
    Dim Cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack = True Then
            DropDownList1.DataSource = projectcode()
            DropDownList1.DataTextField = "ticket_code"
            DropDownList1.DataValueField = "ticket_code"
            DropDownList1.DataBind()
        End If
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'อัพเดทสถานะ ticket ที่เลือกให้เป็นสถานะปิด
        If DropDownList1.Text = "select" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Please select.'); window.location='" + Request.ApplicationPath + "/Closepop.aspx';", True)
        Else
            con.Open()
            Dim sql As String = "UPDATE TICKET_TICKET SET statusticket_id = '" & 4 & "',close_on = GetDate(),close_by = '" & Session("state") & "' where ticket_code = '" + DropDownList1.Text + "'"
            With Cmd
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = con
                .ExecuteNonQuery()
            End With
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Update Complete.'); window.location='" + Request.ApplicationPath + "/Closepop.aspx';", True)
        End If
    End Sub
    Public Function projectcode() As DataSet 'ฟังก์ชั่น ดึงข้อมูล Ticket ที่ยังไม่ได้มีการปิด
        Dim ds As New DataSet
        Dim sql As String = "select ticket_code from TICKET_TICKET where statusticket_id != '4'"
        Dim cmd As New SqlCommand(sql, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(ds)
        con.Close()
        Return ds
    End Function
End Class