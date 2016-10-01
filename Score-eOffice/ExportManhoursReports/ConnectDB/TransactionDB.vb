Imports System
Imports System.Data.SqlClient

Namespace ConnectDB
    Public Class TransactionDB
        Private _error As String = ""
        Private _conn As SqlConnection
        Private _trans As SqlTransaction

        Private errorCommitTransaction = MessageResources.MSGEC008
        Private errorRollbackTransaction = MessageResources.MSGEC008
        Private errorCreateTransaction = MessageResources.MSGEC008

        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _error
            End Get
        End Property

        Public ReadOnly Property conn() As SqlConnection
            Get
                Return _conn
            End Get
        End Property

        Public ReadOnly Property Trans() As SqlTransaction
            Get
                Return _trans
            End Get
        End Property

        ' <summary>
        ' Commit the SQL database transaction and close the connection to the database.
        ' </summary>
        ' <returns>Return true when process operation successfully, otherwise false.</returns>
        Public Function CommitTransaction() As Boolean
            Dim ret As Boolean = True
            Try
                If _trans IsNot Nothing Then _trans.Commit()
                If _conn IsNot Nothing Then _conn.Close()

            Catch ex As SqlException
                ret = False
                _error = SqlDB.GetExceptionMessage(ex)
            Catch
                ret = False
                _error = errorCommitTransaction
            End Try

            Return ret
        End Function


        ' <summary>
        ' Rolls back a transaction from a pending state and close the connection to the database.
        ' </summary>
        ' <returns>Return true when process operation successfully, otherwise false.</returns>
        Public Function RollbackTransaction() As Boolean
            Dim ret As Boolean = True
            Try
                If _trans IsNot Nothing Then _trans.Rollback()
                If _conn IsNot Nothing Then _conn.Close()
            Catch ex As SqlException
                ret = False
                _error = SqlDB.GetExceptionMessage(ex)
            Catch
                ret = False
                _error = errorRollbackTransaction
            End Try

            Return ret
        End Function

        ' <summary>
        ' Initializes a new opened instance of the System.Data.OracleClient.OracleConnection class and begins a transaction at a database with System.Data.IsolationLevel.ReadCommitted.
        ' </summary>
        ' <returns>Return yes when transaction is begined, otherwise no.</returns>
        Public Function CreateTransaction() As Boolean
            Dim ret As Boolean = True
            Try
                If _conn Is Nothing Then _conn = SqlDB.GetConnection
                _trans = _conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted)
            Catch ex As Exception
                ret = False
                _error = SqlDB.GetExceptionMessage(ex)
            Catch
                ret = False
                _error = errorCreateTransaction
            End Try
        End Function

        Public Function CreateTransaction(ByVal connectionString As String) As Boolean
            Dim ret As Boolean = True
            Try
                If _conn Is Nothing Then _conn = SqlDB.GetConnection(connectionString)
                _trans = _conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted)
            Catch ex As Exception
                ret = False
                _error = SqlDB.GetExceptionMessage(ex)
            Catch
                ret = False
                _error = errorCreateTransaction
            End Try
        End Function

        Public Sub New()
            CreateTransaction()
        End Sub
    End Class
End Namespace
