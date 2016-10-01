Imports XCS.DAL.Table
Imports XCS.DAL.Common.Utilities
Namespace Master
    Public Class FunctionProcess
        Public Shared Function GetConfigValue(ByVal configName As String, ByVal trans As TransactionDB) As String
            Dim dal As New SysConfigDAL
            dal.GetDataByCONFIG_NAME(configName, trans.Trans)
            Return dal.CONFIG_VALUE
        End Function
    End Class
End Namespace
