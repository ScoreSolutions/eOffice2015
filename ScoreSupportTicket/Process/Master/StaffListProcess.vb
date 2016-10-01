Imports XCS.DAL.Common.Utilities
Imports XCS.DAL.Table
Imports XCS.Data.Table

Namespace Master
    Public Class StaffListProcess
        Public Function SearchData(ByVal whText As String, ByVal trans As TransactionDB) As DataTable
            'Dim sql As String = ""
            'sql += "select s.id, s.username, s.staffname, s.position_name, s.division_name,"
            'sql += " s.can_raise, s.can_accept_assignment, s.can_close, s.active"
            Dim sDAL As New StaffDAL
            Dim dt As DataTable = sDAL.GetDataList(whText, "username", trans.Trans)
            dt.Columns.Add("no")
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = (i + 1)
            Next

            Return dt
        End Function
    End Class
End Namespace
