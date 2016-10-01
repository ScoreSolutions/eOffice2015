Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Web.UI

Public Class EtimeSheetClass03
    Dim Conf As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/")
    Dim StrConn As String = Conf.ConnectionStrings.ConnectionStrings("MyConn").ToString
    Dim Conn As New SqlConnection(StrConn)


    Public Function updateConn(Optional ByVal forceExit As Boolean = True) As Boolean
        Try
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
            Conn.ConnectionString = StrConn
            Conn.Open()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function getDataset(ByVal argSQL As String, Optional ByVal forceExit As Boolean = True) As DataSet
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        If updateConn() Then
            Try
                da = New SqlDataAdapter(argSQL, Conn)
                da.Fill(ds)
                Return ds
            Catch ex As Exception
                Return ds
            End Try
        End If
        Return New DataSet
    End Function

    

    Public Sub executeSQL(ByVal sql As String)
        If updateConn() Then
            If sql.Trim <> "" Then
                Dim cmd As New SqlCommand(sql)
                cmd.Connection = Conn
                cmd.ExecuteNonQuery()
            End If
        End If
    End Sub

    Public Function FixDB(ByVal paramTXT As String) As String
        If IsDBNull(paramTXT) = True Then
            Return ""
        ElseIf paramTXT = Nothing Then
            Return ""
        Else
            Return paramTXT.ToString.Replace("'", "''")
        End If
    End Function

    Public Function GetMax(ByVal Table As String, ByVal Field As String) As Int32
        Dim ds As New DataSet
        Dim Max As Int32 = 0
        Dim sql As String = ""
        sql = "select isnull(max(" & Field & "),0) as num from " & Table & ""
        ds = getDataset(sql)
        If ds.Tables(0).Rows.Count > 0 Then
            Max = CInt(ds.Tables(0).Rows(0)("num"))
            Return Max
        End If
        Return 0
    End Function

    Function FixDate(ByVal txt As String)
        Dim dd As String() = Split(txt, "-")
        Dim mm As String = ""
        Dim new_date As String = ""
        Select Case dd(1)
            Case "ม.ค."
                mm = "Jan"
            Case "ก.พ."
                mm = "Feb"
            Case "มี.ค."
                mm = "Mar"
            Case "ม.ย."
                mm = "Apr"
            Case "พ.ค."
                mm = "May"
            Case "มิ.ย."
                mm = "Jue"
            Case "ก.ค."
                mm = "Jul"
            Case "ส.ค."
                mm = "Aug"
            Case "ก.ย."
                mm = "Sep"
            Case "ต.ค."
                mm = "Oct"
            Case "พ.ย."
                mm = "Nov"
            Case "ธ.ค."
                mm = "Dec"
        End Select
        If mm = "" Then
            Return new_date
        End If
        new_date = dd(0) & "-" & mm & "-" & dd(2)
        Return new_date
    End Function

End Class
