Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Image
Imports System.Web.UI

Namespace eTimeSheet
    Public Class MyConnectionStr
        Dim Conf As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/")
        Public SrtCon As String = Conf.ConnectionStrings.ConnectionStrings("MyConn").ToString
        'Public SrtCon As String = "server=203.150.224.91;database=scoresolutions;uid=scoresolutions;pwd=scs1034"
        'Public SrtCon As String = "server=(local);database=EOffice;uid=sa;pwd=sa"   'Max Pool Size=500
        Function Opendata(ByVal strcon As String, ByRef conn As SqlConnection)
            Dim Thong As String = SrtCon
            If conn.State = ConnectionState.Open Then Return True
            conn.ConnectionString = Thong
            conn.Open()
            Return True
        End Function


        Function numlink(ByVal numrecord As Integer, ByVal num_row_show As Int16, ByVal pagestart As String, ByRef linkgoto As String, ByRef StartRecode As Int16, ByRef EndRecord As Int16)
            If numrecord = 0 Then
                linkgoto = 0
                Return 0
            End If
            Dim count_page As Integer = 0
            If numrecord > num_row_show Then
                count_page = numrecord \ num_row_show
                If numrecord Mod num_row_show > 0 Then
                    count_page = count_page + 1
                End If
            Else
                count_page = 1
            End If
            '****************************************************************
            Dim start_num As Integer
            'numlink=แสดงตัวเลขจำนวนหน้าต่างๆ
            If linkgoto = "" Then
                Return False
            End If
            'ทำลิ้งไปยังหน้าคต่าง
            Dim strcount As String = ""
            Dim xj As Int16 = 1
            For i As Int16 = 1 To count_page
                If i = xj * 25 Then
                    xj = xj + 1
                    strcount &= "|<br>"
                End If
                If i = 1 Then
                    strcount = "<a href='" & linkgoto & "?page=" & i & "'>" & i & "</a>"
                Else
                    strcount = strcount & "|<a href='" & linkgoto & "?page=" & i & "'>" & i & "</a>"
                End If

            Next
            linkgoto = strcount
            'กำนหด start record'/*/*/*/*/* กำหนดช่วงการแสดง
            If pagestart = "" Then
                StartRecode = 0
            Else
                Dim a As Integer = Val(pagestart)
                start_num = (a - 1) * num_row_show
                StartRecode = start_num
            End If
            'กำหนดสิ้นสุด
            Dim end_num As Integer = 0
            If numrecord - start_num < num_row_show Then
                end_num = numrecord - start_num
            Else
                end_num = num_row_show
            End If
            EndRecord = end_num + StartRecode
            Return True
        End Function
        Function numlink(ByVal numrecord As Integer, ByVal num_row_show As Int16, ByVal pagestart As String, ByRef linkgoto As String, ByRef StartRecode As Int16, ByRef EndRecord As Int16, ByVal data1 As String)
            If numrecord = 0 Then
                linkgoto = 0
                Return 0
            End If
            Dim count_page As Integer = 0
            If numrecord > num_row_show Then
                count_page = numrecord \ num_row_show
                If numrecord Mod num_row_show > 0 Then
                    count_page = count_page + 1
                End If
            Else
                count_page = 1
            End If
            '****************************************************************
            Dim start_num As Integer
            If linkgoto = "" Then
                Return False
            End If
            'ทำลิ้งไปยังหน้าคต่าง
            Dim strcount As String = ""
            Dim xj As Int16 = 1
            For i As Int16 = 1 To count_page
                If i = xj * 25 Then
                    xj = xj + 1
                    strcount &= "|<br>"
                End If
                If i = 1 Then
                    strcount = "<a href='" & linkgoto & "?page=" & i & "&data1=" & data1 & "'>" & i & "</a>"
                Else
                    strcount = strcount & "|<a href='" & linkgoto & "?page=" & i & "&data1=" & data1 & "'>" & i & "</a>"
                End If
            Next
            linkgoto = strcount
            'กำนหด start record
            If pagestart = "" Then
                StartRecode = 0
            Else
                Dim a As Integer = Val(pagestart)
                start_num = (a - 1) * num_row_show
                StartRecode = start_num
            End If
            'กำหนดสิ้นสุด
            Dim end_num As Integer = 0
            If numrecord - start_num < num_row_show Then
                end_num = numrecord - start_num
            Else
                end_num = num_row_show
            End If
            EndRecord = end_num + StartRecode
            Return True
        End Function

        Function ch_null(ByVal data As DBNull) As String
            Return "-"
        End Function
        Function ch_null(ByVal data As String) As String
            Return Trim(data)
        End Function
        Function ch_null(ByVal data As Integer) As String
            Return data
        End Function
        Function ch_null(ByVal data As Double) As String
            Return data
        End Function
        Function ch_null(ByVal data As Date) As String
            Dim a As String = data.Day
            Dim b As String = data.Month
            Dim c As String
            If data.Year > 2500 Then
                c = data.Year - 543
            Else
                c = data.Year
            End If
            c = a & "/" & b & "/" & c
            Return c
        End Function


        Function open_window(ByVal data As String, ByVal strurl As String) As String
            Dim str As String = "<a href=javascript:void(window.open('" & strurl & "','popup','width=600,height=400,top=0,left=0,scrollbar=yes'))>" & data & "</a>"
            Return str
        End Function
        Function gotorefresh(ByVal url As String) As String
            Dim str As String = "<script language='javascript'>eval(parent.location ='" & url & "');</script>"
            Return str
        End Function
        Function alert(ByVal stralert As String) As String
            Dim str As String = "<script language='javascript'>alert('" & stralert & "');</script>"
            Return str
        End Function
        Function new_window(ByVal str As String) As String
            Dim strx As String = "<script language='javascript'>window.open('" & str & "')</script>"
            Return strx
        End Function
    End Class
    Public Class MysqlCommand
        Inherits MyConnectionStr
        Function Cmd(ByVal Ls_SrtSql As String) As Double
            Dim li_cmdType As Integer
            Cmd = 0
            li_cmdType = 0
            Ls_SrtSql = " " & Ls_SrtSql
            If InStr(1, Ls_SrtSql, " UPDATE ", 1) > 0 And li_cmdType = 0 Then li_cmdType = 1
            If InStr(1, Ls_SrtSql, " INSERT ", 1) > 0 And li_cmdType = 0 Then li_cmdType = 1
            If InStr(1, Ls_SrtSql, " DELETE ", 1) > 0 And li_cmdType = 0 Then li_cmdType = 1
            If InStr(1, Ls_SrtSql, "COUNT(", 1) > 0 Or InStr(1, Ls_SrtSql, "COUNT (", 1) > 0 And li_cmdType = 0 Then li_cmdType = 2
            If (InStr(1, Ls_SrtSql, "SUM(", 1) > 0 Or InStr(1, Ls_SrtSql, "SUM (", 1) > 0 And li_cmdType = 0) Then li_cmdType = 2
            If (InStr(1, Ls_SrtSql, "MAX(", 1) > 0 Or InStr(1, Ls_SrtSql, "MAX (", 1) > 0 And li_cmdType = 0) Then li_cmdType = 2
            If (InStr(1, Ls_SrtSql, "MIN(", 1) > 0 Or InStr(1, Ls_SrtSql, "MAX (", 1) > 0 And li_cmdType = 0) Then li_cmdType = 2
            If li_cmdType <> 0 Then
                Dim Con As New SqlConnection(SrtCon)
                If Con.State <> ConnectionState.Open Then
                    Con.Open()
                End If
                Dim MySQLcommand As New SqlCommand(Ls_SrtSql, Con)
                Select Case li_cmdType
                    Case 1 : MySQLcommand.ExecuteNonQuery()
                    Case 2 : Cmd = MySQLcommand.ExecuteScalar()
                End Select
                Con.Close()
            End If
        End Function
        Function CmdStr(ByVal Ls_SrtSql As String) As Object
            Dim li_cmdType As Integer
            CmdStr = 0
            li_cmdType = 0
            Ls_SrtSql = " " & Ls_SrtSql
            If InStr(1, Ls_SrtSql, " UPDATE ", 1) > 0 And li_cmdType = 0 Then li_cmdType = 1
            If InStr(1, Ls_SrtSql, " INSERT ", 1) > 0 And li_cmdType = 0 Then li_cmdType = 1
            If InStr(1, Ls_SrtSql, " DELETE ", 1) > 0 And li_cmdType = 0 Then li_cmdType = 1
            If InStr(1, Ls_SrtSql, "COUNT(", 1) > 0 Or InStr(1, Ls_SrtSql, "COUNT (", 1) > 0 And li_cmdType = 0 Then li_cmdType = 2
            If (InStr(1, Ls_SrtSql, "SUM(", 1) > 0 Or InStr(1, Ls_SrtSql, "SUM (", 1) > 0 And li_cmdType = 0) Then li_cmdType = 2
            If (InStr(1, Ls_SrtSql, "MAX(", 1) > 0 Or InStr(1, Ls_SrtSql, "MAX (", 1) > 0 And li_cmdType = 0) Then li_cmdType = 2
            If (InStr(1, Ls_SrtSql, "MIN(", 1) > 0 Or InStr(1, Ls_SrtSql, "MAX (", 1) > 0 And li_cmdType = 0) Then li_cmdType = 2
            If li_cmdType <> 0 Then
                Dim Con As New SqlConnection(SrtCon)
                If Con.State <> ConnectionState.Open Then
                    Con.Open()
                End If
                Dim MySQLcommand As New SqlCommand(Ls_SrtSql, Con)
                Select Case li_cmdType
                    Case 1 : MySQLcommand.ExecuteNonQuery()
                    Case 2 : CmdStr = MySQLcommand.ExecuteScalar()
                End Select
                Con.Close()
            End If
        End Function
        Function GetRunNumber(ByVal Number_Desc As String) As Integer
            Dim Con As New SqlConnection(SrtCon)
            If Con.State <> ConnectionState.Open Then
                Con.Open()
            End If
            Dim MySQLcommand As New SqlCommand("Update OF_RunNumber Set RunNumber = RunNumber +1 Where Runnumber_Desc='" & Number_Desc & "'", Con)
            Dim MySQLcommand2 As New SqlCommand("Select Max(RunNumber)-1 From OF_RunNumber Where Runnumber_Desc='" & Number_Desc & "'", Con)
            MySQLcommand.ExecuteScalar()
            GetRunNumber = MySQLcommand2.ExecuteScalar()
            Con.Close()
        End Function

        Function getMoneytype(ByRef strxoil As Double, ByVal strproid As String) As String
            Dim sql As String = "SELECT     OF_Ex_Currency.Currency_Detail, OF_ExpenditureProject_deatail.Xoil"
            sql &= " FROM         OF_ExtakeExpen INNER JOIN"
            sql &= " OF_ExpenditureProject_deatail ON OF_ExtakeExpen.TakeExpen_ID = OF_ExpenditureProject_deatail.TakeExpen_ID AND "
            sql &= " OF_ExtakeExpen.Project_Id = OF_ExpenditureProject_deatail.Project_ID LEFT OUTER JOIN"
            sql &= " OF_Ex_Currency ON OF_ExtakeExpen.Currency_ID = OF_Ex_Currency.Currency_ID"
            sql &= " where OF_ExtakeExpen.TakeExpen_ID=" & strproid & " "
            Dim datare As String
            Dim ds As New DataSet
            Dim SqlAp As New MysqlAdapter
            SqlAp.SetAdapterDataset(sql, ds, "prodetail")
            If ds.Tables("prodetail").Rows.Count <> 0 Then
                datare = ch_null(ds.Tables("prodetail").Rows(0).Item("Currency_Detail"))
                If datare = "-" Then datare = ""
                strxoil = ds.Tables("prodetail").Rows(0).Item("Xoil")
            Else
                datare = "-"
                strxoil = 0
            End If
            SqlAp = Nothing
            ds.Clear()
            Return datare
        End Function
        Function SetAdapterDataset(ByVal strsql As String, ByRef ds As DataSet, ByVal nametab As String)
            Dim conn As New SqlConnection
            Dim mycon As New MyConnectionStr
            mycon.Opendata(SrtCon, conn)
            Dim adter As New SqlDataAdapter(strsql, conn)
            adter.Fill(ds, nametab)
            adter.Dispose()
            conn.Close()
            Return True
        End Function
    End Class

    Public Class MyThaiConvertDate
        Function ShowDateEng(ByVal MyDate As Date, ByVal TimeShow As Boolean) As String
            'Return "::"
            Dim SrtMonth() As String = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
            If TimeShow Then
                ShowDateEng = Right("00" & CStr(MyDate.Day), 2) & "-" & SrtMonth(MyDate.Month - 1) & "-" & MyDate.Year & " at" & Right("00" & CStr(MyDate.Hour), 2) & ":" & Right("00" & CStr(MyDate.Minute), 2)
            Else
                ShowDateEng = Right("00" & CStr(MyDate.Day), 2) & "-" & SrtMonth(MyDate.Month - 1) & "-" & MyDate.Year
            End If
        End Function

        Function ShowDateThi(ByVal MyDate As Date, ByVal TimeShow As Boolean) As String
            Dim SrtMonth() As String = {"ม.ค.", "ก.พ.", "มี.ค.", "เม.ย.", "พ.ค.", "มิ.ย.", "ก.ค.", "ส.ค.", "ก.ย.", "ต.ค.", "พ.ย.", "ธค."}
            If TimeShow Then
                ShowDateThi = Right("00" & CStr(MyDate.Day), 2) & "-" & SrtMonth(MyDate.Month - 1) & "-" & MyDate.Year & " :" & Right("00" & CStr(MyDate.Hour), 2) & ":" & Right("00" & CStr(MyDate.Minute), 2)
            Else
                ShowDateThi = Right("00" & CStr(MyDate.Day), 2) & "-" & SrtMonth(MyDate.Month - 1) & "-" & MyDate.Year
            End If
        End Function
        Function ToDate(ByVal SrtDate As String) As String
            Dim srtYear As String
            Dim srtMonth As String
            Dim srtDay As String
            Dim fullDate As Date
            fullDate = CDate(SrtDate)
            srtYear = CStr(Year(fullDate))
            If Year(fullDate) > 2500 Then srtYear = CStr(Year(fullDate) - 543)
            srtMonth = CStr(Month(fullDate))
            srtDay = CStr(Day(fullDate))
            ToDate = srtMonth & "-" & srtDay & "-" & srtYear
        End Function

        Function ToDateSrt(ByVal SrtDate As String) As String
            Dim srtYear As String
            Dim srtMonth As String
            Dim srtDay As String
            Dim Mydate As DateTime
            Mydate = SrtDate
            srtDay = Mydate.Day()
            srtMonth = Mydate.Month()
            srtYear = Mydate.Year()
            If CInt(srtYear) > 2500 Then srtYear = CStr(CInt(srtYear) - 543)
            ToDateSrt = srtMonth & "-" & srtDay & "-" & srtYear
        End Function
        Function ReDateSrt(ByVal SrtDate As Date) As String
            Dim srtYear As String
            Dim srtMonth As String
            Dim srtDay As String
            srtDay = Right("0" & SrtDate.Day, 2)
            srtMonth = Right("0" & SrtDate.Month, 2)
            srtYear = SrtDate.Year
            If srtYear > 2500 Then srtYear = CStr(CInt(srtYear) - 543)
            ReDateSrt = srtDay & "/" & srtMonth & "/" & srtYear
        End Function

        Function ToDateTime(ByVal SrtDate As String) As String
            Dim srtYear As String
            Dim srtMonth As String
            Dim srtDay As String
            Dim srtTime As String
            Dim fullDate As Date
            srtTime = Right(SrtDate, 8)
            fullDate = CDate(SrtDate)
            srtYear = CStr(Year(fullDate))
            If Year(fullDate) > 2500 Then srtYear = CStr(Year(fullDate) - 543)
            srtMonth = CStr(Month(fullDate))
            srtDay = CStr(Day(fullDate))
            ToDateTime = srtMonth & "-" & srtDay & "-" & srtYear & " " & fullDate.Hour & ":" & fullDate.Minute 'srtTime
        End Function

        Function ChgTextToHtml(ByVal BufText As String) As String
            BufText = Replace(BufText, vbNewLine, "<br>")
            BufText = Replace(BufText, " ", "&nbsp;")
            'BufText = Replace(BufText, "'", "&#39;")
            ChgTextToHtml = BufText
        End Function

        '  Function ChgHtmlToText(ByVal BufText As String) As String
        '     BufText = Replace(BufText, "<br>", vbNewLine)
        '    BufText = Replace(BufText, "&nbsp;", " ")
        '   BufText = Replace(BufText, "<", "&lt;")
        '  BufText = Replace(BufText, "&#39;", "'")
        ' ChgHtmlToText = BufText
        ' End Function

    End Class
    Public Class ClassValidator
        Function ch_null(ByVal data As DBNull) As String
            Return "-"
        End Function
        Function ch_null(ByVal data As String) As String
            Return Trim(data)
        End Function
        Function ch_null(ByVal data As Integer) As String
            Return data
        End Function
        Function ch_null(ByVal data As Double) As String
            Return data
        End Function
        Function ch_null(ByVal data As Date) As String
            Dim a As String = data.Day
            Dim b As String = data.Month
            Dim c As String
            If data.Year > 2500 Then
                c = data.Year - 543
            Else
                c = data.Year
            End If
            c = a & "/" & b & "/" & c
            Return c
        End Function

        Function format_money(ByVal MyMoney As Integer) As String
            MyMoney = Format(MyMoney, "#,###.0#")
            Return MyMoney
        End Function
    End Class
    Public Class MysqlAdapter
        Inherits MyConnectionStr
        Function SetAdapterDataset(ByVal Ls_SrtSql As String, ByRef MyDs As DataSet, ByVal ls_inname As String)
            Dim Con As New SqlConnection(SrtCon)
            If Con.State <> ConnectionState.Open Then
                Con.Open()
            End If

            Dim MySQLAdapter As New SqlDataAdapter(Ls_SrtSql, Con)
            MySQLAdapter.Fill(MyDs, ls_inname)
            Con.Close()
            Return True

        End Function
    End Class

End Namespace


