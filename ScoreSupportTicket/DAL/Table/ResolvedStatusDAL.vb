Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DB = XCS.DAL.Common.Utilities.SqlDB
Imports XCS.Data.Common.Utilities
Imports XCS.Data.Table

Namespace Table
    'Represents a transaction for RESOLVED_STATUS table DAL.
    '[Create by  on March, 27 2011]
    Public Class ResolvedStatusDAL
        Public Sub ResolvedStatusDAL()

        End Sub
        ' RESOLVED_STATUS
        Const _tableName As String = "TRACKINGLOG_RESOLVED_STATUS"
        Dim _deletedRow As Int16 = 0

        'Set Common Property
        Dim _error As String = ""
        Dim _information As String = ""
        Dim _haveData As Boolean = False

        Public ReadOnly Property TableName() As String
            Get
                Return _tableName
            End Get
        End Property
        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _error
            End Get
        End Property
        Public ReadOnly Property InfoMessage() As String
            Get
                Return _information
            End Get
        End Property
        Public ReadOnly Property HaveData() As Boolean
            Get
                Return _haveData
            End Get
        End Property


        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1, 1, 1)
        Dim _UPDATE_BY As String = ""
        Dim _UPDATE_ON As DateTime = New DateTime(1, 1, 1)
        Dim _STATUS_NAME As String = ""
        Dim _STATUS_DESC As String = ""
        Dim _STATUS_ORDER As Long = 0
        Dim _ACTIVE As String = ""

        'Generate Field Property 
        Public ReadOnly Property ID() As Long
            Get
                Return _ID
            End Get
        End Property
        Public ReadOnly Property CREATE_BY() As String
            Get
                Return _CREATE_BY
            End Get
        End Property
        Public ReadOnly Property CREATE_ON() As DateTime
            Get
                Return _CREATE_ON
            End Get
        End Property
        Public ReadOnly Property UPDATE_BY() As String
            Get
                Return _UPDATE_BY
            End Get
        End Property
        Public ReadOnly Property UPDATE_ON() As DateTime
            Get
                Return _UPDATE_ON
            End Get
        End Property
        Public Property STATUS_NAME() As String
            Get
                Return _STATUS_NAME
            End Get
            Set(ByVal value As String)
                _STATUS_NAME = value
            End Set
        End Property
        Public Property STATUS_DESC() As String
            Get
                Return _STATUS_DESC
            End Get
            Set(ByVal value As String)
                _STATUS_DESC = value
            End Set
        End Property
        Public Property STATUS_ORDER() As Long
            Get
                Return _STATUS_ORDER
            End Get
            Set(ByVal value As Long)
                _STATUS_ORDER = value
            End Set
        End Property
        Public Property ACTIVE() As String
            Get
                Return _ACTIVE
            End Get
            Set(ByVal value As String)
                _ACTIVE = value
            End Set
        End Property


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_ON = New DateTime(1, 1, 1)
            _UPDATE_BY = ""
            _UPDATE_ON = New DateTime(1, 1, 1)
            _STATUS_NAME = ""
            _STATUS_DESC = ""
            _STATUS_ORDER = 0
            _ACTIVE = ""
        End Sub

        'Define Public Method 
        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=orderBy>The fields for sort data.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetDataList(ByVal whClause As String, ByVal orderBy As String, ByVal trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(SqlSelect & IIf(whClause = "", "", " WHERE " & whClause) & IIF(orderBy = "", "", " ORDER BY  " & orderBy), trans)
        End Function


        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=orderBy>The fields for sort data.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetListBySql(ByVal Sql As String, ByVal orderBy As String, ByVal trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(Sql & IIF(orderBy = "", "", " ORDER BY  " & orderBy), trans)
        End Function


        '/// Returns an indication whether the current data is inserted into RESOLVED_STATUS table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _id = DB.GetNextID("id", tableName, trans)
            _CREATE_BY = UserID
            _CREATE_ON = DateTime.Now
            Return doInsert(trans)
        End Function


        '/// Returns an indication whether the current data is updated to RESOLVED_STATUS table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _UPDATE_BY = UserID
            _UPDATE_ON = DateTime.Now
            Return doUpdate("id = " & DB.SetDouble(_id) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is deleted from RESOLVED_STATUS table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPK(ByVal trans As SQLTransaction) As Boolean
            Return doDelete("id = " & DB.SetDouble(_id) & " ", trans)
        End Function


        '/// Returns an indication whether the record of RESOLVED_STATUS by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(ByVal cid As Long, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of RESOLVED_STATUS by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(ByVal cid As Long, ByVal trans As SQLTransaction) As ResolvedStatusData
            Return doGetMappingData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is updated to RESOLVED_STATUS table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySTATUS_NAME(ByVal cSTATUS_NAME As String, ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _UPDATE_BY = UserID
            _UPDATE_ON = DateTime.Now
            Return doUpdate("STATUS_NAME = " & DB.SetString(cSTATUS_NAME) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is deleted from RESOLVED_STATUS table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteBySTATUS_NAME(ByVal cSTATUS_NAME As String, ByVal trans As SQLTransaction) As Boolean
            Return doDelete("STATUS_NAME = " & DB.SetString(cSTATUS_NAME) & " ", trans)
        End Function


        '/// Returns an indication whether the record of RESOLVED_STATUS by specified STATUS_NAME key is retrieved successfully.
        '/// <param name=cSTATUS_NAME>The STATUS_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySTATUS_NAME(ByVal cSTATUS_NAME As String, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("STATUS_NAME = " & DB.SetString(cSTATUS_NAME) & " ", trans)
        End Function

        '/// Returns an indication whether the Data Class of RESOLVED_STATUS by specified STATUS_NAME key is retrieved successfully.
        '/// <param name=cSTATUS_NAME>The STATUS_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataBySTATUS_NAME(ByVal cSTATUS_NAME As String, ByVal trans As SQLTransaction) As ResolvedStatusData
            Return doGetMappingData("STATUS_NAME = " & DB.SetString(cSTATUS_NAME) & " ", trans)
        End Function

        '/// Returns an indication whether the current data is updated to RESOLVED_STATUS table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySTATUS_ORDER(ByVal cSTATUS_ORDER As Long, ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _UPDATE_BY = UserID
            _UPDATE_ON = DateTime.Now
            Return doUpdate("STATUS_ORDER = " & DB.SetDouble(cSTATUS_ORDER) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is deleted from RESOLVED_STATUS table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteBySTATUS_ORDER(ByVal cSTATUS_ORDER As Long, ByVal trans As SQLTransaction) As Boolean
            Return doDelete("STATUS_ORDER = " & DB.SetDouble(cSTATUS_ORDER) & " ", trans)
        End Function


        '/// Returns an indication whether the record of RESOLVED_STATUS by specified STATUS_ORDER key is retrieved successfully.
        '/// <param name=cSTATUS_ORDER>The STATUS_ORDER key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySTATUS_ORDER(ByVal cSTATUS_ORDER As Long, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("STATUS_ORDER = " & DB.SetDouble(cSTATUS_ORDER) & " ", trans)
        End Function

        '/// Returns an indication whether the Data Class of RESOLVED_STATUS by specified STATUS_ORDER key is retrieved successfully.
        '/// <param name=cSTATUS_ORDER>The STATUS_ORDER key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataBySTATUS_ORDER(ByVal cSTATUS_ORDER As Long, ByVal trans As SQLTransaction) As ResolvedStatusData
            Return doGetMappingData("STATUS_ORDER = " & DB.SetDouble(cSTATUS_ORDER) & " ", trans)
        End Function

        '/// Returns an indication whether the record of RESOLVED_STATUS by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(ByVal whText As String, ByVal trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into RESOLVED_STATUS table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Private Function doInsert(ByVal trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = False Then
                Try
                    ret = (DB.ExecuteNonQuery(SqlInsert, trans) > 0)
                    If ret = False Then
                        _error = MessageResources.MSGEN001
                    Else
                        _haveData = True
                    End If
                    _information = MessageResources.MSGIN001
                Catch ex As ApplicationException
                    ret = False
                    _error = ex.Message
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC101
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEN002
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is updated to RESOLVED_STATUS table successfully.
        '/// <param name=whText>The condition specify the updating record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Private Function doUpdate(ByVal whText As String, ByVal trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = True Then
                If whText.Trim() <> "" Then
                    Dim tmpWhere As String = " Where " & whText
                    Try
                        ret = (DB.ExecuteNonQuery(SqlUpdate & tmpWhere, trans) > 0)
                        If ret = False Then
                            _error = MessageResources.MSGEU001
                        End If
                        _information = MessageResources.MSGIU001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message
                    Catch ex As Exception
                        ex.ToString()
                        ret = False
                        _error = MessageResources.MSGEC102
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGEU003
                End If
            Else
                ret = False
                _error = MessageResources.MSGEU002
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is deleted from RESOLVED_STATUS table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(ByVal whText As String, ByVal trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If doChkData(whText, trans) = True Then
                If whText.Trim() <> "" Then
                    Dim tmpWhere As String = " Where " & whText
                    Try
                        ret = (DB.ExecuteNonQuery(SqlDelete & tmpWhere, trans) > 0)
                        If ret = False Then
                            _error = MessageResources.MSGED001
                        End If
                        _information = MessageResources.MSGID001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message
                    Catch ex As Exception
                        ex.ToString()
                        ret = False
                        _error = MessageResources.MSGEC103
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGED003
                End If
            Else
                ret = False
                _error = MessageResources.MSGEU002
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of RESOLVED_STATUS by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doChkData(ByVal whText As String, ByVal trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            ClearData()
            _haveData = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("create_by")) = False Then _create_by = Rdr("create_by").ToString()
                        If Convert.IsDBNull(Rdr("create_on")) = False Then _create_on = Convert.ToDateTime(Rdr("create_on"))
                        If Convert.IsDBNull(Rdr("update_by")) = False Then _update_by = Rdr("update_by").ToString()
                        If Convert.IsDBNull(Rdr("update_on")) = False Then _update_on = Convert.ToDateTime(Rdr("update_on"))
                        If Convert.IsDBNull(Rdr("status_name")) = False Then _status_name = Rdr("status_name").ToString()
                        If Convert.IsDBNull(Rdr("status_desc")) = False Then _status_desc = Rdr("status_desc").ToString()
                        If Convert.IsDBNull(Rdr("status_order")) = False Then _status_order = Convert.ToInt64(Rdr("status_order"))
                        If Convert.IsDBNull(Rdr("active")) = False Then _active = Rdr("active").ToString()
                    Else
                        ret = False
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC104
                    If Rdr IsNot Nothing And Rdr.IsClosed = False Then
                        Rdr.Close()
                    End If
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEV001
            End If

            Return ret
        End Function
        '/// Returns an indication whether the Class Data of RESOLVED_STATUS by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingData(ByVal ret As ResolvedStatusData, ByVal RDr As DataRow) As ResolvedStatusData
            If Convert.IsDBNull(Rdr("id")) = False Then ret.ID = Convert.ToInt64(Rdr("id"))
            If Convert.IsDBNull(Rdr("create_by")) = False Then ret.CREATE_BY = Rdr("create_by").ToString()
            If Convert.IsDBNull(Rdr("create_on")) = False Then ret.CREATE_ON = Convert.ToDateTime(Rdr("create_on"))
            If Convert.IsDBNull(Rdr("update_by")) = False Then ret.UPDATE_BY = Rdr("update_by").ToString()
            If Convert.IsDBNull(Rdr("update_on")) = False Then ret.UPDATE_ON = Convert.ToDateTime(Rdr("update_on"))
            If Convert.IsDBNull(Rdr("status_name")) = False Then ret.STATUS_NAME = Rdr("status_name").ToString()
            If Convert.IsDBNull(Rdr("status_desc")) = False Then ret.STATUS_DESC = Rdr("status_desc").ToString()
            If Convert.IsDBNull(Rdr("status_order")) = False Then ret.STATUS_ORDER = Convert.ToInt64(Rdr("status_order"))
            If Convert.IsDBNull(Rdr("active")) = False Then ret.ACTIVE = Rdr("active").ToString()
            Return ret
        End Function


        '/// Returns an indication whether the record of RESOLVED_STATUS by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetMappingData(ByVal whText As String, ByVal trans As SQLTransaction) As ResolvedStatusData
            ClearData()
            _haveData = False
            Dim ret As New ResolvedStatusData
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdt As DataTable
                Try
                    Rdt = DB.ExecuteTable(SqlSelect() & tmpWhere, trans)
                    If Rdt.Rows.Count = 1 Then
                        _haveData = True
                        Dim RDr As DataRow
                        RDr = Rdt.Rows(0)
                        doChkData(whText, trans)
                        ret = doMappingData(ret, RDr)
                    Else
                        _haveData = False
                        _error = MessageResources.MSGEV002
                    End If

                    Rdt = Nothing
                Catch ex As Exception
                    ex.ToString()
                    _haveData = False
                    _error = MessageResources.MSGEC104
                    If Rdt IsNot Nothing Then
                        Rdt = Nothing
                    End If
                End Try
            Else
                _haveData = False
                _error = MessageResources.MSGEV001
            End If

            Return ret
        End Function



        ' SQL Statements


        'Get Insert Statement for table RESOLVED_STATUS
        Private ReadOnly Property SqlInsert() As String
            Get
                Dim Sql As String = ""
                Sql += "INSERT INTO " & tableName & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, STATUS_NAME, STATUS_DESC, STATUS_ORDER, ACTIVE)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetString(_STATUS_NAME) & ", "
                sql += DB.SetString(_STATUS_DESC) & ", "
                sql += DB.SetDouble(_STATUS_ORDER) & ", "
                sql += DB.SetString(_ACTIVE)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table RESOLVED_STATUS
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_ON = " & DB.SetDateTime(_CREATE_ON) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_ON = " & DB.SetDateTime(_UPDATE_ON) & ", "
                Sql += "STATUS_NAME = " & DB.SetString(_STATUS_NAME) & ", "
                Sql += "STATUS_DESC = " & DB.SetString(_STATUS_DESC) & ", "
                Sql += "STATUS_ORDER = " & DB.SetDouble(_STATUS_ORDER) & ", "
                Sql += "ACTIVE = " & DB.SetString(_ACTIVE) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table RESOLVED_STATUS
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table RESOLVED_STATUS
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace