Imports System.IO
Imports System.Data
Imports System.Drawing

Partial Class UserControls_ctlBrowseFileStream
    Inherits System.Web.UI.UserControl

    Dim fnc As New EtimesheetSystem

    'Public Event Upload(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Overrides Property ID() As String
        Get
            Return MyBase.ID
        End Get
        Set(ByVal value As String)
            MyBase.ID = value
        End Set
    End Property

    'Public ReadOnly Property TmpFileUploadPara() As TmpFileUploadPara
    '    Get
    '        Dim TmpName As String = GetTempFileName()
    '        If File.Exists(TmpName) = True Then
    '            Dim FileProp As New FileInfo(TmpName)
    '            Dim fData As New TmpFileUploadPara
    '            'fData.TmpFileByte = GetTempFileByte()
    '            fData.FileExtent = FileProp.Extension
    '            fData.FileName = FileProp.Name
    '            Return fData
    '        Else
    '            Return Nothing
    '        End If
    '    End Get
    'End Property

    Public ReadOnly Property PostedFileName() As String
        Get
            Return Session("PostedFileName")
        End Get
    End Property

    Public Property Width() As Unit
        Get
            Return FileBrowse.Width
        End Get
        Set(ByVal value As Unit)
            FileBrowse.Width = value
        End Set
    End Property

    'Public ReadOnly Property HasFile() As Boolean
    '    Get
    '        Return File.Exists(GetTempFileName)
    '    End Get
    'End Property

    Public WriteOnly Property EnabledUpload() As Boolean
        Set(ByVal value As Boolean)
            FileBrowse.Visible = value
            btnUpload.Visible = value

            For Each grv As GridViewRow In gvListFile.Rows
                Dim ButtonDelete As Button = DirectCast(grv.FindControl("ButtonDelete"), Button)
                ButtonDelete.Visible = value
            Next
        End Set
    End Property

    Public Sub SetFileList(ByVal vExpenditureID As String)
        Dim sql As String = "select id, file_name, file_ext, file_byte"
        sql += " from eOFFICE_EXPENDITURE_ATTATCHMENT epa "
        sql += " where eoffice_expenditure_id='" & vExpenditureID & "'"
        Dim dt As New DataTable

        dt = fnc.GetDatatable(sql)
        If dt.Rows.Count > 0 Then
            dt.Columns.Add("no")
            dt.Columns.Add("temp_file_path")
            dt.Columns.Add("file_prop", GetType(FileInfo))

            Dim i As Integer = 1
            For Each dr As DataRow In dt.Rows
                Dim TempFilePath As String = GetTempPath & "\" & Me.Page.AppRelativeVirtualPath.Replace("~/", "").Replace(".aspx", "") & "_" & FileBrowse.ClientID & "_" & i & dr("file_ext")

                Dim fb() As Byte = dr("file_byte")
                Dim lstr As New System.IO.MemoryStream(fb)
                Dim img As Image = Image.FromStream(lstr)
                img.Save(TempFilePath)

                If File.Exists(TempFilePath) = True Then
                    Dim fInfo As New FileInfo(TempFilePath)
                    dr("file_prop") = fInfo
                    dr("temp_file_path") = TempFilePath
                End If
                dr("no") = i
                i += 1
            Next


            gvListFile.DataSource = dt
            gvListFile.DataBind()
        End If
        dt.Dispose()
    End Sub

    Public Function GetFileList() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("no")
        dt.Columns.Add("id")
        dt.Columns.Add("file_name")
        dt.Columns.Add("temp_file_path")
        dt.Columns.Add("file_prop", GetType(FileInfo))

        For i As Integer = 0 To gvListFile.Rows.Count - 1
            With gvListFile.Rows(i)
                Dim lblFileID As Label = DirectCast(.FindControl("lblFileID"), Label)
                Dim lblFileName As Label = DirectCast(.FindControl("lblFileName"), Label)
                Dim lblTempFilePath As Label = DirectCast(.FindControl("lblTempFilePath"), Label)

                Dim dr As DataRow = dt.NewRow
                dr("id") = lblFileID.Text
                dr("file_name") = lblFileName.Text
                dr("temp_file_path") = lblTempFilePath.Text

                If File.Exists(dr("temp_file_path")) = True Then
                    Dim fInfo As New FileInfo(dr("temp_file_path"))
                    dr("file_prop") = fInfo
                End If

                dt.Rows.Add(dr)
            End With
        Next
        Return dt
    End Function

    Protected Sub FileBrowse_UploadedComplete(ByVal sender As Object, ByVal e As AjaxControlToolkit.AsyncFileUploadEventArgs) Handles FileBrowse.UploadedComplete
        If e.State = AjaxControlToolkit.AsyncFileUploadState.Success Then
            Session("PostedFileName") = FileBrowse.FileName
            Dim dt As DataTable = GetFileList()
            Dim FileProp As New FileInfo(FileBrowse.FileName)
            Dim TempFilePath As String = GetTempPath & "\" & Me.Page.AppRelativeVirtualPath.Replace("~/", "").Replace(".aspx", "") & "_" & FileBrowse.ClientID & "_" & (dt.Rows.Count + 1) & FileProp.Extension

            Session("TempFilePath") = TempFilePath

            ConvertStreamToByte(FileBrowse.FileContent, TempFilePath)
        End If
    End Sub


    Private Function ConvertStreamToByte(ByVal stream As System.IO.Stream, ByVal TempFilePath As String) As Boolean
        Dim ret As Boolean = False
        If File.Exists(TempFilePath) = True Then
            File.SetAttributes(TempFilePath, FileAttributes.Normal)
            File.Delete(TempFilePath)
        End If

        Dim fileStream As FileStream = File.Create(TempFilePath, CInt(stream.Length))
        Dim buffer As Byte() = New Byte(1024 - 1) {}
        Dim len As Integer = stream.Read(buffer, 0, buffer.Length)
        While len > 0
            Try
                fileStream.Write(buffer, 0, buffer.Length)
                len = stream.Read(buffer, 0, buffer.Length)
                ret = True
            Catch ex As Exception
                ret = False
                Exit While
            End Try

        End While
        fileStream.Close()
        Return ret
    End Function

    'Private Sub SaveTempFile(ByVal FileBrowse As AjaxControlToolkit.AsyncFileUpload, ByVal FileExtent As String)
    '    Dim TmpFileUpload As String = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings("TempUpload"))
    '    If Directory.Exists(TmpFileUpload) = False Then
    '        Directory.CreateDirectory(TmpFileUpload)
    '    End If

    '    Dim ClientIP As String = Request.UserHostAddress
    '    If Directory.Exists(TmpFileUpload & "/" & ClientIP) = False Then
    '        Directory.CreateDirectory(TmpFileUpload & "/" & ClientIP)
    '    End If

    '    Dim PathFile As String = GetTempPath()
    '    Dim FileName As String = PathFile & "\" & Config.GetLoginHistoryID & "_" & Me.Page.AppRelativeVirtualPath.Replace("~/", "").Replace(".aspx", "") & "_" & FileBrowse.ClientID & FileExtent
    '    If File.Exists(FileName) = True Then
    '        File.Delete(FileName)
    '    End If
    '    FileBrowse.SaveAs(FileName)
    'End Sub
    'Private Sub SaveTempFile(ByVal fData As TmpFileUploadPara)
    '    Dim TmpFileUpload As String = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings("TempUpload"))
    '    If Directory.Exists(TmpFileUpload) = False Then
    '        Directory.CreateDirectory(TmpFileUpload)
    '    End If

    '    Dim ClientIP As String = Request.UserHostAddress
    '    If Directory.Exists(TmpFileUpload & "/" & ClientIP) = False Then
    '        Directory.CreateDirectory(TmpFileUpload & "/" & ClientIP)
    '    End If

    '    Dim fs As FileStream
    '    Dim byteData() As Byte
    '    byteData = fData.TmpFileByte

    '    Dim PathFile As String = GetTempPath()
    '    Dim FileName As String = PathFile & "\" & Config.GetLoginHistoryID & "_" & Me.Page.AppRelativeVirtualPath.Replace("~/", "").Replace(".aspx", "") & "_" & FileBrowse.ClientID & fData.FileExtent
    '    If File.Exists(FileName) = True Then
    '        File.Delete(FileName)
    '    End If

    '    fs = New FileStream(FileName, FileMode.CreateNew)
    '    fs.Write(byteData, 0, byteData.Length)
    '    fs.Close()
    'End Sub

    'Public Sub ClearFile()
    '    Dim TempFile As String = GetTempFileName()
    '    If File.Exists(TempFile) Then
    '        Try
    '            File.SetAttributes(TempFile, FileAttributes.Normal)
    '            File.Delete(TempFile)
    '        Catch ex As Exception

    '        End Try
    '    End If
    'End Sub

    Private ReadOnly Property GetTempPath() As String
        Get
            If Directory.Exists(Server.MapPath("TempExpenditureUpload")) = False Then
                Directory.CreateDirectory(Server.MapPath("TempExpenditureUpload"))
            End If

            Dim TempPath As String = Server.MapPath("TempExpenditureUpload") & "\" & Request.UserHostAddress
            If Directory.Exists(TempPath) = False Then
                Directory.CreateDirectory(TempPath)
            End If
            Return TempPath
        End Get
    End Property


    'Private Function GetTempFileName() As String
    '    Dim TempName As String = Me.Page.AppRelativeVirtualPath.Replace("~/", "").Replace(".aspx", "") & "_" & FileBrowse.ClientID

    '    Dim f As String = ""
    '    If Directory.Exists(GetTempPath) = True Then
    '        For Each fle As String In Directory.GetFiles(GetTempPath)
    '            If InStr(fle, TempName) > 0 Then
    '                f = fle
    '                Exit For
    '            End If
    '        Next
    '    End If
    '    Return f
    'End Function


    'Public Sub SaveFile(ByVal PathFile As String, ByVal fileName As String)
    '    Dim TempName As String = GetTempFileName()
    '    If TempName <> "" Then
    '        Try
    '            Dim fss As New System.Security.AccessControl.FileSecurity

    '            If Directory.Exists(PathFile) = False Then
    '                Directory.CreateDirectory(PathFile)
    '            End If
    '            File.Move(TempName, PathFile & "\" & fileName)

    '            ClearFile()
    '        Catch ex As Exception

    '        End Try
    '    End If
    'End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Dim dt As DataTable = GetFileList()
        Dim dr As DataRow = dt.NewRow
        dr("id") = "0"
        dr("file_name") = PostedFileName
        dr("temp_file_path") = Session("TempFilePath")
        dt.Rows.Add(dr)

        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i)("no") = (i + 1).ToString
        Next

        gvListFile.DataSource = dt
        gvListFile.DataBind()
        dt.Dispose()
    End Sub

    Protected Sub gvListFile_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvListFile.RowDeleting
        Dim dt As DataTable = GetFileList()
        Dim isDeleteRow As Boolean = True
        If File.Exists(dt.Rows(e.RowIndex)("temp_file_path")) = True Then
            Try
                File.SetAttributes(dt.Rows(e.RowIndex)("temp_file_path"), FileAttributes.Normal)
                File.Delete(dt.Rows(e.RowIndex)("temp_file_path"))
            Catch ex As Exception
                isDeleteRow = False
            End Try
        End If

        If isDeleteRow = True Then
            Dim FileID As String = dt.Rows(e.RowIndex)("id")
            If FileID > 0 Then
                Dim dSql As String = "delete from eOFFICE_EXPENDITURE_ATTATCHMENT where id='" & dt.Rows(e.RowIndex)("id") & "' "
                fnc.ExecuteSQL(dSql)
            End If

            dt.Rows.RemoveAt(e.RowIndex)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("no") = (i + 1).ToString
                Next
            End If

            gvListFile.DataSource = dt
            gvListFile.DataBind()
        End If
        dt.Dispose()
    End Sub
End Class
