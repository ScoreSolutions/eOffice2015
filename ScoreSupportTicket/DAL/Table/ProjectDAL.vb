Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DB = XCS.DAL.Common.Utilities.SqlDB
Imports XCS.Data.Common.Utilities
Imports XCS.Data.Table

Namespace Table
    'Represents a transaction for PROJECT table DAL.
    '[Create by  on March, 11 2011]
    Public Class ProjectDAL
        Public Sub ProjectDAL()

        End Sub
        ' PROJECT
        Const _tableName As String = "TRACKINGLOG_PROJECT"
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
        Dim _PROJECT_CODE As String = ""
        Dim _PROJECT_NAME As String = ""
        Dim _CUSTOMER_NAME As String = ""
        Dim _START_YEAR As String = ""
        Dim _CONTRACT_NO As String = ""
        Dim _PROJECT_DESC As String = ""

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
        Public Property PROJECT_CODE() As String
            Get
                Return _PROJECT_CODE
            End Get
            Set(ByVal value As String)
                _PROJECT_CODE = value
            End Set
        End Property
        Public Property PROJECT_NAME() As String
            Get
                Return _PROJECT_NAME
            End Get
            Set(ByVal value As String)
                _PROJECT_NAME = value
            End Set
        End Property
        Public Property CUSTOMER_NAME() As String
            Get
                Return _CUSTOMER_NAME
            End Get
            Set(ByVal value As String)
                _CUSTOMER_NAME = value
            End Set
        End Property
        Public Property START_YEAR() As String
            Get
                Return _START_YEAR
            End Get
            Set(ByVal value As String)
                _START_YEAR = value
            End Set
        End Property
        Public Property CONTRACT_NO() As String
            Get
                Return _CONTRACT_NO
            End Get
            Set(ByVal value As String)
                _CONTRACT_NO = value
            End Set
        End Property
        Public Property PROJECT_DESC() As String
            Get
                Return _PROJECT_DESC
            End Get
            Set(ByVal value As String)
                _PROJECT_DESC = value
            End Set
        End Property


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_ON = New DateTime(1, 1, 1)
            _UPDATE_BY = ""
            _UPDATE_ON = New DateTime(1, 1, 1)
            _PROJECT_CODE = ""
            _PROJECT_NAME = ""
            _CUSTOMER_NAME = ""
            _START_YEAR = ""
            _CONTRACT_NO = ""
            _PROJECT_DESC = ""
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


        '/// Returns an indication whether the current data is inserted into PROJECT table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _id = DB.GetNextID("id", tableName, trans)
            _CREATE_BY = UserID
            _CREATE_ON = DateTime.Now
            Return doInsert(trans)
        End Function


        '/// Returns an indication whether the current data is updated to PROJECT table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _UPDATE_BY = UserID
            _UPDATE_ON = DateTime.Now
            Return doUpdate("id = " & DB.SetDouble(_id) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is deleted from PROJECT table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPK(ByVal trans As SQLTransaction) As Boolean
            Return doDelete("id = " & DB.SetDouble(_id) & " ", trans)
        End Function


        '/// Returns an indication whether the record of PROJECT by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(ByVal cid As Long, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of PROJECT by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(ByVal cid As Long, ByVal trans As SQLTransaction) As ProjectData
            Return doGetMappingData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is updated to PROJECT table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPROJECT_CODE(ByVal cPROJECT_CODE As String, ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _UPDATE_BY = UserID
            _UPDATE_ON = DateTime.Now
            Return doUpdate("PROJECT_CODE = " & DB.SetString(cPROJECT_CODE) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is deleted from PROJECT table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPROJECT_CODE(ByVal cPROJECT_CODE As String, ByVal trans As SQLTransaction) As Boolean
            Return doDelete("PROJECT_CODE = " & DB.SetString(cPROJECT_CODE) & " ", trans)
        End Function


        '/// Returns an indication whether the record of PROJECT by specified PROJECT_CODE key is retrieved successfully.
        '/// <param name=cPROJECT_CODE>The PROJECT_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPROJECT_CODE(ByVal cPROJECT_CODE As String, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("PROJECT_CODE = " & DB.SetString(cPROJECT_CODE) & " ", trans)
        End Function

        '/// Returns an indication whether the Data Class of PROJECT by specified PROJECT_CODE key is retrieved successfully.
        '/// <param name=cPROJECT_CODE>The PROJECT_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPROJECT_CODE(ByVal cPROJECT_CODE As String, ByVal trans As SQLTransaction) As ProjectData
            Return doGetMappingData("PROJECT_CODE = " & DB.SetString(cPROJECT_CODE) & " ", trans)
        End Function

        '/// Returns an indication whether the current data is updated to PROJECT table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPROJECT_NAME(ByVal cPROJECT_NAME As String, ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _UPDATE_BY = UserID
            _UPDATE_ON = DateTime.Now
            Return doUpdate("PROJECT_NAME = " & DB.SetString(cPROJECT_NAME) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is deleted from PROJECT table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPROJECT_NAME(ByVal cPROJECT_NAME As String, ByVal trans As SQLTransaction) As Boolean
            Return doDelete("PROJECT_NAME = " & DB.SetString(cPROJECT_NAME) & " ", trans)
        End Function


        '/// Returns an indication whether the record of PROJECT by specified PROJECT_NAME key is retrieved successfully.
        '/// <param name=cPROJECT_NAME>The PROJECT_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPROJECT_NAME(ByVal cPROJECT_NAME As String, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("PROJECT_NAME = " & DB.SetString(cPROJECT_NAME) & " ", trans)
        End Function

        '/// Returns an indication whether the Data Class of PROJECT by specified PROJECT_NAME key is retrieved successfully.
        '/// <param name=cPROJECT_NAME>The PROJECT_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPROJECT_NAME(ByVal cPROJECT_NAME As String, ByVal trans As SQLTransaction) As ProjectData
            Return doGetMappingData("PROJECT_NAME = " & DB.SetString(cPROJECT_NAME) & " ", trans)
        End Function

        '/// Returns an indication whether the record of PROJECT by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(ByVal whText As String, ByVal trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into PROJECT table successfully.
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


        '/// Returns an indication whether the current data is updated to PROJECT table successfully.
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


        '/// Returns an indication whether the current data is deleted from PROJECT table successfully.
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


        '/// Returns an indication whether the record of PROJECT by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("project_code")) = False Then _project_code = Rdr("project_code").ToString()
                        If Convert.IsDBNull(Rdr("project_name")) = False Then _project_name = Rdr("project_name").ToString()
                        If Convert.IsDBNull(Rdr("customer_name")) = False Then _customer_name = Rdr("customer_name").ToString()
                        If Convert.IsDBNull(Rdr("start_year")) = False Then _start_year = Rdr("start_year").ToString()
                        If Convert.IsDBNull(Rdr("contract_no")) = False Then _contract_no = Rdr("contract_no").ToString()
                        If Convert.IsDBNull(Rdr("project_desc")) = False Then _project_desc = Rdr("project_desc").ToString()
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
        '/// Returns an indication whether the Class Data of PROJECT by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingData(ByVal ret As ProjectData, ByVal RDr As DataRow) As ProjectData
            If Convert.IsDBNull(Rdr("id")) = False Then ret.ID = Convert.ToInt64(Rdr("id"))
            If Convert.IsDBNull(Rdr("create_by")) = False Then ret.CREATE_BY = Rdr("create_by").ToString()
            If Convert.IsDBNull(Rdr("create_on")) = False Then ret.CREATE_ON = Convert.ToDateTime(Rdr("create_on"))
            If Convert.IsDBNull(Rdr("update_by")) = False Then ret.UPDATE_BY = Rdr("update_by").ToString()
            If Convert.IsDBNull(Rdr("update_on")) = False Then ret.UPDATE_ON = Convert.ToDateTime(Rdr("update_on"))
            If Convert.IsDBNull(Rdr("project_code")) = False Then ret.PROJECT_CODE = Rdr("project_code").ToString()
            If Convert.IsDBNull(Rdr("project_name")) = False Then ret.PROJECT_NAME = Rdr("project_name").ToString()
            If Convert.IsDBNull(Rdr("customer_name")) = False Then ret.CUSTOMER_NAME = Rdr("customer_name").ToString()
            If Convert.IsDBNull(Rdr("start_year")) = False Then ret.START_YEAR = Rdr("start_year").ToString()
            If Convert.IsDBNull(Rdr("contract_no")) = False Then ret.CONTRACT_NO = Rdr("contract_no").ToString()
            If Convert.IsDBNull(Rdr("project_desc")) = False Then ret.PROJECT_DESC = Rdr("project_desc").ToString()
            Return ret
        End Function


        '/// Returns an indication whether the record of PROJECT by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetMappingData(ByVal whText As String, ByVal trans As SQLTransaction) As ProjectData
            ClearData()
            _haveData = False
            Dim ret As New ProjectData
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


        'Get Insert Statement for table PROJECT
        Private ReadOnly Property SqlInsert() As String
            Get
                Dim Sql As String = ""
                Sql += "INSERT INTO " & tableName & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, PROJECT_CODE, PROJECT_NAME, CUSTOMER_NAME, START_YEAR, CONTRACT_NO, PROJECT_DESC)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetString(_PROJECT_CODE) & ", "
                sql += DB.SetString(_PROJECT_NAME) & ", "
                sql += DB.SetString(_CUSTOMER_NAME) & ", "
                sql += DB.SetString(_START_YEAR) & ", "
                sql += DB.SetString(_CONTRACT_NO) & ", "
                sql += DB.SetString(_PROJECT_DESC)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table PROJECT
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_ON = " & DB.SetDateTime(_CREATE_ON) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_ON = " & DB.SetDateTime(_UPDATE_ON) & ", "
                Sql += "PROJECT_CODE = " & DB.SetString(_PROJECT_CODE) & ", "
                Sql += "PROJECT_NAME = " & DB.SetString(_PROJECT_NAME) & ", "
                Sql += "CUSTOMER_NAME = " & DB.SetString(_CUSTOMER_NAME) & ", "
                Sql += "START_YEAR = " & DB.SetString(_START_YEAR) & ", "
                Sql += "CONTRACT_NO = " & DB.SetString(_CONTRACT_NO) & ", "
                Sql += "PROJECT_DESC = " & DB.SetString(_PROJECT_DESC) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table PROJECT
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table PROJECT
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace