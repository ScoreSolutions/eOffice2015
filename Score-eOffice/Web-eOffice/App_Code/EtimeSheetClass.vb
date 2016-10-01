Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Image
Imports System.Web.UI

Public Class EtimesheetSystem
    Dim Conf As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/")
    Dim MyConn As New SqlConnection(Conf.ConnectionStrings.ConnectionStrings("MyConn").ToString)

    Sub checkConn(ByRef argConn As SqlConnection, Optional ByVal argMode As String = "Open")
        Select Case UCase(argMode)
            Case "O", "OPEN"
                If argConn.State <> 1 Then argConn.Open()
            Case "C", "CLOSE"
                If argConn.State = 1 Then argConn.Close()
                argConn.Dispose()
                argConn = Nothing
        End Select
    End Sub

    Function Getdataset(ByVal sql As String)
        checkConn(MyConn, "o")
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da = New SqlDataAdapter(sql, MyConn)
        da.Fill(ds)
        Return ds
    End Function

    Public Function GetDatatable(ByVal sql As String) As DataTable
        Dim dt As New DataTable
        checkConn(MyConn, "o")
        Try
            Dim da As New SqlDataAdapter()
            Dim cmd As New SqlCommand
            cmd.Connection = MyConn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql



            da.SelectCommand = cmd
            da.Fill(dt)
        Catch ex As Exception
            dt = New DataTable
        End Try
        Return dt
    End Function

    Function ExecuteSQL(ByVal sql As String) As Boolean
        Dim ret As Boolean = False
        Try
            checkConn(MyConn, "o")
            Dim cmd As New SqlCommand(sql)
            cmd.Connection = MyConn
            cmd.ExecuteNonQuery()
            ret = True
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

    Function ExecuteSQL(ByVal sql As String, ByVal Pam As SqlParameter) As Boolean
        Dim ret As Boolean = False
        Try
            checkConn(MyConn, "o")
            Dim cmd As New SqlCommand(sql)
            cmd.Connection = MyConn
            cmd.Parameters.Add(Pam)

            cmd.ExecuteNonQuery()
            ret = True
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

    Function ExecuteScalar(ByVal sql As String) As String
        Dim ret As String = ""
        Try
            checkConn(MyConn, "o")
            Dim cmd As New SqlCommand(sql)
            cmd.Connection = MyConn
            ret = cmd.ExecuteScalar().ToString
        Catch ex As Exception
            ret = ""
        End Try
        Return ret
    End Function


    Function CmdSQL(ByVal Ls_SrtSql As String) As Object
        Dim li_cmdType As Integer
        CmdSQL = 0
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
            If MyConn.State <> 1 Then
                checkConn(MyConn, "O")
            End If
            Dim MySQLcommand As New SqlCommand(Ls_SrtSql, MyConn)
            Select Case li_cmdType
                Case 1 : MySQLcommand.ExecuteNonQuery()
                Case 2 : CmdSQL = MySQLcommand.ExecuteScalar()
            End Select
            MyConn.Close()
        End If
    End Function

    Function CheckLogin(ByVal argLogin As String) As Boolean
        If argLogin = "LoginPass" Then
            Return True
        Else
            Return False
        End If
    End Function
    Function CheckTimeAttendance() As Boolean
        Return False
    End Function
    Sub showMenu(ByRef argPlaceHoler As PlaceHolder, ByVal argSessionMenu As String)
        checkConn(MyConn, "O")
        'argSessionMenu = "*"
        Dim whereClause As String = ""
        If argSessionMenu <> "*" Then
            whereClause = " and (id in (" & argSessionMenu & ") or "
            whereClause &= " id in (select parent_id from eOFFICE_MENU where id in(" & argSessionMenu & "))"
            whereClause &= " or id in(0,999) and parent_id>-2)"
        End If

        Dim sql As String = "select * from eOFFICE_MENU where 1=1 " & whereClause & " and active_status='Y'  order by menu_order asc"
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter(sql, MyConn)
        da.Fill(ds)
        Dim tmp As String = "<script type=""text/javascript"">d = new dTree('d');"
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            With ds.Tables(0).Rows(i)
                If tmp = "" Then
                    tmp = "d.add(" & .Item("id") & "," & .Item("parent_id") & ",'" & .Item("menu_text") & "','" & .Item("menu_link") & "');"
                Else
                    tmp &= vbCrLf & "d.add(" & .Item("id") & "," & .Item("parent_id") & ",'" & .Item("menu_text") & "','" & .Item("menu_link") & "');"
                End If
            End With
        Next
        tmp &= "document.write(d);</script>"
        If MyConn.State = 1 Then MyConn.Close()
        checkConn(MyConn, "C")
        argPlaceHoler.Controls.Add(New LiteralControl(tmp))

    End Sub
    Function checkPerm(ByVal argFileName As String, ByVal argUserMenu As String, ByRef arglblHader As Label) As Boolean
        'Dim argFileID As String
        'Dim tmp As String = "," & argUserMenu & ","

        'argFileID = CmdSQL("Select max(id) from eOFFICE_MENU Where menu_link='" & argFileName & "'")
        'arglblHader.Text = CmdSQL("Select max(header_desc) from eOFFICE_MENU Where id = " & argFileID & "")
        'If InStr(tmp, "," & argFileID & ",") = 0 And argUserMenu <> "*" Then
        '    Return False
        'End If
        Return True
    End Function

    Sub BindControl(ByRef argControlObj As Object, ByVal ShowDefault As Byte, ByVal strSQL As String)
        If MyConn.State <> 1 Then
            checkConn(MyConn, "O")
        End If

        Dim Da As New SqlDataAdapter(strSQL, MyConn)
        Dim Ds As New DataSet
        Da.Fill(Ds)
        argControlObj.DataSource = Ds
        argControlObj.DataBind()

        ' ShowDefault = 1 คือ Show Default -Select-
        Dim a As New ListItem("-Select-", 0)
        If ShowDefault = 1 Then argControlObj.Items.Insert(0, a)
    End Sub


    Sub BindDropDownlist(ByRef ddl As DropDownList, ByVal DefaultValue As String, ByVal DefaultText As String, ByVal ValueField As String, ByVal TextField As String, ByVal strSQL As String)
        If MyConn.State <> 1 Then
            checkConn(MyConn, "O")
        End If

        Dim Da As New SqlDataAdapter(strSQL, MyConn)
        Dim Dt As New DataTable
        Da.Fill(Dt)

        ddl.DataValueField = ValueField
        ddl.DataTextField = TextField
        ddl.DataSource = Dt
        ddl.DataBind()

        Dim a As New ListItem(DefaultText, DefaultValue)
        ddl.Items.Insert(0, a)
    End Sub

    Function FixData(ByVal argTxt As String) As String
        Return Trim(Replace(argTxt, "'", "''"))
    End Function
    Function FixDate(ByVal DateIn As Date) As String
        Return DateIn.ToString("yyyy-MM-dd hh:mm:ss.fff", New Globalization.CultureInfo("en-US"))
    End Function
    Function FixDate(ByVal DateIn As String) As String
        'แปลงวันที่จาก Format dd/MM/yyyy ให้เป็น yyyy-MM-dd hh:mm:ss.fff

        Dim ret As String = ""
        If DateIn.Length = 10 Then
            Dim tmp As String() = Split(DateIn, "/")
            If tmp.Length = 3 Then
                Dim tmpDate As New Date(tmp(2), tmp(1), tmp(0))
                ret = tmpDate.ToString("yyyy-MM-dd hh:mm:ss.fff", New Globalization.CultureInfo("en-US"))
            End If
        End If

        Return ret
    End Function

    Function fixNull(ByVal argObj As Object, Optional ByVal argRetString As String = "") As String
        If IsDBNull(argObj) Then
            Return argRetString
        Else
            Return argObj
        End If
    End Function

    Function dataExists(ByVal argTable As String, ByVal argField As String, ByVal argFieldValue As String) As Boolean
        Dim sql As String = "select " & argField & " from " & argTable & " where " & argField & "='" & argFieldValue & "'"
        checkConn(MyConn)
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
        da.Dispose()
        ds.Dispose()
        da = Nothing
        ds = Nothing
        checkConn(MyConn, "c")
    End Function

    Public Function StringFromLeft(ByVal strTmp As String, ByVal strLength As Integer) As String
        If (strLength > 0 And strTmp.Length >= strLength) Then
            Return strTmp.Substring(0, strLength)
        Else
            Return strTmp
        End If
    End Function

    Public Function StringFromRight(ByVal strTmp As String, ByVal strLength As Integer) As String
        If (strLength > 0 And strTmp.Length >= strLength) Then
            Return strTmp.Substring(strTmp.Length - strLength, strLength)
        Else
            Return strTmp
        End If
    End Function

    Public Function GetMonthNameListThai() As DataTable


        Dim dt As New DataTable()
        dt.Columns.Add("No", GetType(String))
        dt.Columns.Add("Month", GetType(String))

        Dim dr As DataRow
        For i As Integer = 1 To 12
            dr = dt.NewRow()
            dr("No") = i

            Dim MonthName As String = ""
            Select Case i
                Case 1
                    MonthName = "มกราคม"
                    Exit Select
                Case 2
                    MonthName = "กุมภาพันธ์"
                    Exit Select
                Case 3
                    MonthName = "มีนาคม"
                    Exit Select
                Case 4
                    MonthName = "เมษายน"
                    Exit Select
                Case 5
                    MonthName = "พฤษภาคม"
                    Exit Select
                Case 6
                    MonthName = "มิถุนายน"
                    Exit Select
                Case 7
                    MonthName = "กรกฏาคม"
                    Exit Select
                Case 8
                    MonthName = "สิงหาคม"
                    Exit Select
                Case 9
                    MonthName = "กันยายน"
                    Exit Select
                Case 10
                    MonthName = "ตุลาคม"
                    Exit Select
                Case 11
                    MonthName = "พฤศจิกายน"
                    Exit Select
                Case 12
                    MonthName = "ธันวาคม"
                    Exit Select
                Case Else
                    MonthName = ""
                    Exit Select

            End Select

            dr("Month") = MonthName
            dt.Rows.Add(dr)
        Next


        Return dt
    End Function

    Public Function GetYearList(ByVal NumberOfYear As Integer, ByVal IsBack As Boolean) As DataTable

        Dim dt As New DataTable()
        dt.Columns.Add("No", GetType(String))
        dt.Columns.Add("Year", GetType(String))

        Dim dr As DataRow
        For i As Integer = 0 To NumberOfYear - 1
            dr = dt.NewRow()
            dr("No") = i + 1
            If IsBack Then
                dr("Year") = DateTime.Today.Year - i
            Else
                dr("Year") = DateTime.Today.Year + i
            End If

            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Public Function GetUserResponsibilityList(ByVal UserName As String) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = ""
            sql += " select r.id, r.responsibility_name "
            sql += " from eOFFICE_RESPONSIBILITY r"
            sql += " inner join eOFFICE_GROUP_RESPONSIBILITY gr on gr.eoffice_responsibility_id=r.id"
            sql += " inner join eOFFICE_USER u on u.group_id=gr.eoffice_user_group_id"
            sql += " where u.username='" & UserName & "' and r.active_status='Y'"
            sql += " order by r.responsibility_name"
            ret = GetDatatable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Public Function GetUserListByResponsibility(ByVal ResponsibilityID As Long) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = ""
            sql += " select u.id, u.name + ' ' + u.surname staff_name,u.email "
            sql += " from eOFFICE_USER u"
            sql += " inner join eOFFICE_GROUP_RESPONSIBILITY gr on gr.eoffice_user_group_id=u.group_id"
            sql += " inner join eOFFICE_RESPONSIBILITY r on r.id=gr.eoffice_user_group_id"
            sql += " where r.id='" & ResponsibilityID & "' and r.active_status='Y'"
            sql += " order by u.name,u.surname"
            ret = GetDatatable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Public Function ChedkUserResponsibility(ByVal UserName As String, ByVal ResponsibilityID As Long) As Boolean
        Dim ret As Boolean = False
        Try
            Dim sql As String = ""
            sql += " select top 1 r.id "
            sql += " from eOFFICE_RESPONSIBILITY r"
            sql += " inner join eOFFICE_GROUP_RESPONSIBILITY gr on gr.eoffice_responsibility_id=r.id"
            sql += " inner join eOFFICE_USER u on u.group_id=gr.eoffice_user_group_id"
            sql += " where u.username='" & UserName & "' and r.id='" & ResponsibilityID & "' and r.active_status='Y'"
            sql += " order by r.responsibility_name"
            Dim dt As New DataTable
            dt = GetDatatable(sql)
            If dt.Rows.Count > 0 Then
                ret = True
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

#Region " Encrypt/Decrypt "
    Private EncryptionKey As String = "scoresolutions14"
    Public Function EnCripPwd(ByVal passString As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(EncryptionKey))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(passString)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))

        Catch ex As Exception
        End Try

        Return encrypted
    End Function

    Public Function DeCripPwd(ByVal passString As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(EncryptionKey))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(passString)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
        Catch ex As Exception
        End Try

        Return decrypted
    End Function
#End Region

End Class

Public Class MyThaiConvertDate
    Function ChgTextToHtml(ByVal BufText As String) As String
        BufText = Replace(BufText, vbNewLine, "<br>")
        BufText = Replace(BufText, " ", "&nbsp;")
        'BufText = Replace(BufText, "'", "&#39;")
        ChgTextToHtml = BufText
    End Function

End Class