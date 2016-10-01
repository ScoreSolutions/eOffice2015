Imports XCS.Process.Master

Partial Class TestAjaxControl
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim lookupName As String = ""
        Dim filterName As String = ""
        Dim filterValue As String = ""

        If Request.Params("id") IsNot Nothing And Request.Params("id") <> "" Then
            lookupName = Request.Params("id")
            If Request.Params("filter") IsNot Nothing And Request.Params("filter") <> "" Then
                Dim filter As String = Request.Params("filter")
                Dim filters() As String = filter.Split(",")
                If (filters.Length = 2) Then
                    filterName = filters(0)
                    filterValue = filters(1)
                End If
            End If

            Dim query As String
            Select Case lookupName
                Case "Project"
                    query = "select id, project_name text from ticket_project order by project_name"
                Case "Module"
                    query = "select id, module_name text from ticket_module "
                    If filterName = "Project" Then
                        query += String.Format(" where project_id = '{0}'", filterValue)
                    End If
                Case "Screen"
                    query = "select id, screen_name text from ticket_screen"
                    If filterName = "Module" Then
                        query += String.Format(" where module_id = '{0}'", filterValue)
                    End If
            End Select

            Dim sb As New StringBuilder
            Dim proc As New TestAjacControlProcess
            Dim trans As New XCS.Process.Common.DbTransProcess
            trans.CreateTransaction()
            Dim reader As System.Data.SqlClient.SqlDataReader = proc.GetDataBySql(query, trans)
            While reader.Read()
                sb.AppendFormat("{{""value"":""{0}"",""name"":""{1}""}},", reader("id"), reader("text"))
            End While

            Dim output As String = sb.ToString
            If output <> "" Then
                If output.Substring(output.Length - 1, 1) = "," Then
                    output = output.Substring(0, output.Length - 1)
                End If
            End If
            trans.CommitTransaction()
            output = String.Format("[{0}]", output)
            Response.Write(output)

        End If


    End Sub
End Class
