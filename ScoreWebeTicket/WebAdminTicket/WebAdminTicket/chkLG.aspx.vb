Imports System.Data
Imports System.Data.SqlClient
Imports Newtonsoft.Json

Partial Public Class CheLG
    Inherits System.Web.UI.Page
    Dim objConn As New SqlConnection(ConfigurationManager.ConnectionStrings("Conn").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If (Request.QueryString("_id") IsNot Nothing And Trim(Request.QueryString("_id")) <> "") Then
                Dim _id As String = Request.QueryString("_id")
                Dim strSql As String = ""

                Try
                    If objConn.State = ConnectionState.Closed Then objConn.Open()

                    '***SELECT TABLE HERE
                    strSql = "Select * From ListStock Where _id='" & _id & "'"

                    Dim objAdapter As New SqlDataAdapter(strSql, objConn)
                    Dim Ds As New DataSet
                    objAdapter.Fill(Ds, "Test")

                    Dim strResult As String = String.Empty
                    'For Each Dr As DataRow In Ds.Tables("ListStock").Rows
                    '***EDIT ROW 
                    'Response.Write(Dr.Item("_id") & "| " & Dr.Item("code_id") & "    " & Dr.Item("item_name"))
                    'Next

                    Response.Write(JsonConvert.SerializeObject(Ds.Tables("Test").Rows, Formatting.Indented))

                Catch ex As Exception
                    Response.Write("False")
                End Try

            Else
                Response.Write("False")
            End If

        Catch ex As Exception
            Response.Write("False")
        End Try

    End Sub

    Sub CallUnitDisplay(ByVal Queue As String, ByVal UnitdisplayID As String)

        If UnitdisplayID = "" Then Exit Sub
        Dim sql As String = ""
        Dim ID As Int32
        ID = FindID("Q_UNITDISPLAY")
        sql = "insert into Q_UNITDISPLAY(id,counter_no,queue_no,txt,action,status_cls) values(" & ID & ",'" & UnitdisplayID & "','" & Queue & "','',0,1)"
        If objConn.State = ConnectionState.Closed Then objConn.Open()
        Dim objCmd As New SqlCommand(sql, objConn)
        objCmd.ExecuteNonQuery()
    End Sub

    Sub ServeUnitDisplay(ByVal Queue As String, ByVal UnitdisplayID As String)
        If UnitdisplayID = "" Then Exit Sub
        Dim sql As String = ""
        Dim ID As Int32
        ID = FindID("Q_UNITDISPLAY")
        sql = "insert into Q_UNITDISPLAY(id,counter_no,queue_no,txt,action,status_cls) values(" & ID & ",'" & UnitdisplayID & "','" & Queue & "','',1,1)"
        If objConn.State = ConnectionState.Closed Then objConn.Open()
        Dim objCmd As New SqlCommand(sql, objConn)
        objCmd.ExecuteNonQuery()
    End Sub

    Sub ShowUserUnitDisplay(ByVal txt As String, ByVal UnitdisplayID As String)

        If UnitdisplayID = "" Then Exit Sub
        Dim sql As String = ""
        Dim ID As Int32
        ID = FindID("Q_UNITDISPLAY")
        Try
            sql = "insert into Q_UNITDISPLAY(id,counter_no,queue_no,txt,action,status_cls) values(" & ID & ",'" & UnitdisplayID & "','','" & txt & "',5,1)"
            If objConn.State = ConnectionState.Closed Then objConn.Open()
            Dim objCmd As New SqlCommand(sql, objConn)
            objCmd.ExecuteNonQuery()

        Catch ex As Exception

        End Try
    End Sub

    Public Function FindID(ByVal TableName As String) As String
        Dim id As String = ""
        Try
            Dim sql As String = ""
            Dim ds As New DataSet
            sql = "select isnull(MAX(id + 1),1) as id from " & FixDB(TableName)
            If objConn.State = ConnectionState.Closed Then objConn.Open()
            Dim objAdapter As New SqlDataAdapter(sql, objConn)
            objAdapter.Fill(ds, "ID")

            If ds.Tables("ID").Rows.Count > 0 Then
                id = ds.Tables("ID").Rows(0).Item("id")
            End If
            Return id
        Catch ex As Exception

        End Try
        Return id
    End Function

    Public Function FixDB(ByVal paramTXT As String) As String
        If IsDBNull(paramTXT) = True Then
            Return ""
        ElseIf paramTXT = Nothing Then
            Return ""
        Else
            Return paramTXT.ToString.Replace("'", "''")
        End If
    End Function

End Class