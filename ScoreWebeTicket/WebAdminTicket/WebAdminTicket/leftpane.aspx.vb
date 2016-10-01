Imports System.Data.SqlClient
Imports System.Globalization
Imports Telerik.Web.UI

Public Class leftpane
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Support-TicketConnectionString").ConnectionString)
    Dim Cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub
    Public Function DataWithSearchText(ByVal s1 As String) As DataSet 'function search ticket 

        Dim sq As String
        sq = "Select ticket_code,create_by from TICKET_TICKET where "
        If Label1.Text <> "" Then
            sq += "CONVERT(VARCHAR(30),create_on,101) = '" & s1 & "'"
            Dim cmd As New SqlCommand(sq, con)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()

            da.Fill(ds)
            con.Close()
            Return ds
        End If
    End Function

    'Private Sub RadCalendar1_Init(sender As Object, e As EventArgs) Handles RadCalendar1.Init
    'จะทำให้มันแสดง ticket โดยแสดงเป็น carleda select จาก เวลาที่สร้าง
    '    Dim sq As String
    '    sq = "Select create_on from TICKET_TICKET where "
    '    sq += "statusticket_id = '1'"
    '    Dim cmd As New SqlCommand(sq, con)
    '    con.Open()
    '    Dim da As New SqlDataAdapter(cmd)
    '    Dim ds As New DataSet()
    '    da.Fill(ds)

    '    Dim i As Integer
    '    For i = 0 To ds.Tables(0).Rows.Count - 1
    '        Dim a As New Telerik.Web.UI.RadCalendarDay(RadCalendar1)
    '        a.Date = ds.Tables(0).Rows(i)(0).ToString()
    '        RadCalendar1.SpecialDays.Add(a.ToString("yyyy-MM/dd"))
    '    Next

    'End Sub
    Protected Sub RadCalendar1_SelectionChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDatesEventArgs) Handles RadCalendar1.SelectionChanged     
        'find ticket from data of calendar
        Dim s As String = RadCalendar1.SelectedDate.Date.ToString("MM/dd/yyyy", New CultureInfo("en-US"))
        RadGrid1.DataSource = (DataWithSearchText(s))
        RadGrid1.DataBind()
    End Sub
End Class