<%@ WebHandler Language="VB" Class="DemoData" %>

Imports System
Imports System.Web
Imports System.Data

Public Class DemoData : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Try
            
            Dim dtData As New DataTable
            dtData.Columns.Add("RowID")
            dtData.Columns.Add("Name")
            dtData.Columns.Add("Description")
           
            dtData.Rows.Add(1, "1xxxxxx", "1yyyyyyyy")
            dtData.Rows.Add(2, "2xxxxxx", "2yyyyyyyy")
            dtData.Rows.Add(3, "3xxxxxx", "3yyyyyyyy")
            dtData.Rows.Add(4, "4xxxxxx", "4yyyyyyyy")
            dtData.Rows.Add(5, "5xxxxxx", "5yyyyyyyy")
            dtData.Rows.Add(6, "6xxxxxx", "6yyyyyyyy")
            dtData.Rows.Add(7, "1xxxxxx", "1yyyyyyyy")
            dtData.Rows.Add(8, "2xxxxxx", "2yyyyyyyy")
            dtData.Rows.Add(9, "3xxxxxx", "3yyyyyyyy")
            dtData.Rows.Add(10, "4xxxxxx", "4yyyyyyyy")
            dtData.Rows.Add(11, "5xxxxxx", "5yyyyyyyy")
            dtData.Rows.Add(12, "6xxxxxx", "6yyyyyyyy")
            'dtData.Rows.Add(1, "1xxxxxx", "1yyyyyyyy")
            'dtData.Rows.Add(2, "2xxxxxx", "2yyyyyyyy")
            'dtData.Rows.Add(3, "3xxxxxx", "3yyyyyyyy")
            'dtData.Rows.Add(4, "4xxxxxx", "4yyyyyyyy")
            'dtData.Rows.Add(5, "5xxxxxx", "5yyyyyyyy")
            'dtData.Rows.Add(6, "6xxxxxx", "6yyyyyyyy")
            'dtData.Rows.Add(1, "1xxxxxx", "1yyyyyyyy")
            'dtData.Rows.Add(2, "2xxxxxx", "2yyyyyyyy")
            'dtData.Rows.Add(3, "3xxxxxx", "3yyyyyyyy")
            'dtData.Rows.Add(4, "4xxxxxx", "4yyyyyyyy")
            'dtData.Rows.Add(5, "5xxxxxx", "5yyyyyyyy")
            'dtData.Rows.Add(6, "6xxxxxx", "6yyyyyyyy")
            
            
            Dim strdata As String = clsdtHelper.ConvertDataTableToJson(dtData)
            With context
                .Response.ContentType = "application/json"
                .Response.ContentEncoding = Encoding.UTF8
                .Response.Write(strdata)
                .Response.Flush()
            End With
        Catch ex As Exception
            context.Response.ContentType = "application/json"
            context.Response.ContentEncoding = Encoding.UTF8
            context.Response.Write("[]")
        End Try
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class