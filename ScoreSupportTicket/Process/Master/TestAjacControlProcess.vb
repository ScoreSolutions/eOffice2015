Imports XCS.DAL.Common.Utilities
Imports XCS.DAL.Table
Imports XCS.Data.Table

Namespace Master
    Public Class TestAjacControlProcess
        Public Function GetDataBySql(ByVal sql As String, ByVal trans As TransactionDB) As SqlClient.SqlDataReader
            Return SqlDB.ExecuteReader(sql, trans.Trans)
        End Function
    End Class
End Namespace
