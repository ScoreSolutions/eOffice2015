﻿Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DB = XCS.DAL.Common.Utilities.SqlDB
Imports XCS.Data.Common.Utilities
Imports XCS.Data.Table

Namespace Table
    'Represents a transaction for SCREEN table DAL.
    '[Create by  on March, 8 2011]
    Public Class ScreenDAL
        Public Sub ScreenDAL()

        End Sub
        ' SCREEN
        Const _tableName As String = "TRACKINGLOG_SCREEN"
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
        Dim _SCREEN_CODE As String = ""
        Dim _SCREEN_NAME As String = ""
        Dim _SCREEN_DESC As String = ""
        Dim _MODULE_ID As Long = 0
        Dim _SCREEN_ORDER As Long = 0

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
        Public Property SCREEN_CODE() As String
            Get
                Return _SCREEN_CODE
            End Get
            Set(ByVal value As String)
                _SCREEN_CODE = value
            End Set
        End Property
        Public Property SCREEN_NAME() As String
            Get
                Return _SCREEN_NAME
            End Get
            Set(ByVal value As String)
                _SCREEN_NAME = value
            End Set
        End Property
        Public Property SCREEN_DESC() As String
            Get
                Return _SCREEN_DESC
            End Get
            Set(ByVal value As String)
                _SCREEN_DESC = value
            End Set
        End Property
        Public Property MODULE_ID() As Long
            Get
                Return _MODULE_ID
            End Get
            Set(ByVal value As Long)
                _MODULE_ID = value
            End Set
        End Property
        Public Property SCREEN_ORDER() As Long
            Get
                Return _SCREEN_ORDER
            End Get
            Set(ByVal value As Long)
                _SCREEN_ORDER = value
            End Set
        End Property


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_ON = New DateTime(1, 1, 1)
            _UPDATE_BY = ""
            _UPDATE_ON = New DateTime(1, 1, 1)
            _SCREEN_CODE = ""
            _SCREEN_NAME = ""
            _SCREEN_DESC = ""
            _MODULE_ID = 0
            _SCREEN_ORDER = 0
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


        '/// Returns an indication whether the current data is inserted into SCREEN table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _id = DB.GetNextID("id", tableName, trans)
            _CREATE_BY = UserID
            _CREATE_ON = DateTime.Now
            Return doInsert(trans)
        End Function


        '/// Returns an indication whether the current data is updated to SCREEN table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _UPDATE_BY = UserID
            _UPDATE_ON = DateTime.Now
            Return doUpdate("id = " & DB.SetDouble(_id) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is deleted from SCREEN table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPK(ByVal trans As SQLTransaction) As Boolean
            Return doDelete("id = " & DB.SetDouble(_id) & " ", trans)
        End Function


        '/// Returns an indication whether the record of SCREEN by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(ByVal cid As Long, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of SCREEN by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(ByVal cid As Long, ByVal trans As SQLTransaction) As ScreenData
            Return doGetMappingData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is updated to SCREEN table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySCREEN_CODE(ByVal cSCREEN_CODE As String, ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _UPDATE_BY = UserID
            _UPDATE_ON = DateTime.Now
            Return doUpdate("SCREEN_CODE = " & DB.SetString(cSCREEN_CODE) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is deleted from SCREEN table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteBySCREEN_CODE(ByVal cSCREEN_CODE As String, ByVal trans As SQLTransaction) As Boolean
            Return doDelete("SCREEN_CODE = " & DB.SetString(cSCREEN_CODE) & " ", trans)
        End Function


        '/// Returns an indication whether the record of SCREEN by specified SCREEN_CODE key is retrieved successfully.
        '/// <param name=cSCREEN_CODE>The SCREEN_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySCREEN_CODE(ByVal cSCREEN_CODE As String, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("SCREEN_CODE = " & DB.SetString(cSCREEN_CODE) & " ", trans)
        End Function

        '/// Returns an indication whether the Data Class of SCREEN by specified SCREEN_CODE key is retrieved successfully.
        '/// <param name=cSCREEN_CODE>The SCREEN_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataBySCREEN_CODE(ByVal cSCREEN_CODE As String, ByVal trans As SQLTransaction) As ScreenData
            Return doGetMappingData("SCREEN_CODE = " & DB.SetString(cSCREEN_CODE) & " ", trans)
        End Function

        '/// Returns an indication whether the current data is updated to SCREEN table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByMODULE_ID_SCREEN_ORDER(ByVal cMODULE_ID As Long, ByVal cSCREEN_ORDER As Long, ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _UPDATE_BY = UserID
            _UPDATE_ON = DateTime.Now
            Return doUpdate("MODULE_ID = " & DB.SetDouble(cMODULE_ID) & " AND SCREEN_ORDER = " & DB.SetDouble(cSCREEN_ORDER), trans)
        End Function


        '/// Returns an indication whether the current data is deleted from SCREEN table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByMODULE_ID_SCREEN_ORDER(ByVal cMODULE_ID As Long, ByVal cSCREEN_ORDER As Long, ByVal trans As SQLTransaction) As Boolean
            Return doDelete("MODULE_ID = " & DB.SetDouble(cMODULE_ID) & " AND SCREEN_ORDER = " & DB.SetDouble(cSCREEN_ORDER), trans)
        End Function


        '/// Returns an indication whether the record of SCREEN by specified MODULE_ID_SCREEN_ORDER key is retrieved successfully.
        '/// <param name=cMODULE_ID_SCREEN_ORDER>The MODULE_ID_SCREEN_ORDER key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMODULE_ID_SCREEN_ORDER(ByVal cMODULE_ID As Long, ByVal cSCREEN_ORDER As Long, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("MODULE_ID = " & DB.SetDouble(cMODULE_ID) & " AND SCREEN_ORDER = " & DB.SetDouble(cSCREEN_ORDER), trans)
        End Function

        '/// Returns an indication whether the Data Class of SCREEN by specified MODULE_ID_SCREEN_ORDER key is retrieved successfully.
        '/// <param name=cMODULE_ID_SCREEN_ORDER>The MODULE_ID_SCREEN_ORDER key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByMODULE_ID_SCREEN_ORDER(ByVal cMODULE_ID As Long, ByVal cSCREEN_ORDER As Long, ByVal trans As SQLTransaction) As ScreenData
            Return doGetMappingData("MODULE_ID = " & DB.SetDouble(cMODULE_ID) & " AND SCREEN_ORDER = " & DB.SetDouble(cSCREEN_ORDER), trans)
        End Function

        '/// Returns an indication whether the current data is updated to SCREEN table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySCREEN_NAME(ByVal cSCREEN_NAME As String, ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _UPDATE_BY = UserID
            _UPDATE_ON = DateTime.Now
            Return doUpdate("SCREEN_NAME = " & DB.SetString(cSCREEN_NAME) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is deleted from SCREEN table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteBySCREEN_NAME(ByVal cSCREEN_NAME As String, ByVal trans As SQLTransaction) As Boolean
            Return doDelete("SCREEN_NAME = " & DB.SetString(cSCREEN_NAME) & " ", trans)
        End Function


        '/// Returns an indication whether the record of SCREEN by specified SCREEN_NAME key is retrieved successfully.
        '/// <param name=cSCREEN_NAME>The SCREEN_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySCREEN_NAME(ByVal cSCREEN_NAME As String, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("SCREEN_NAME = " & DB.SetString(cSCREEN_NAME) & " ", trans)
        End Function

        '/// Returns an indication whether the Data Class of SCREEN by specified SCREEN_NAME key is retrieved successfully.
        '/// <param name=cSCREEN_NAME>The SCREEN_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataBySCREEN_NAME(ByVal cSCREEN_NAME As String, ByVal trans As SQLTransaction) As ScreenData
            Return doGetMappingData("SCREEN_NAME = " & DB.SetString(cSCREEN_NAME) & " ", trans)
        End Function

        '/// Returns an indication whether the record of SCREEN by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(ByVal whText As String, ByVal trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into SCREEN table successfully.
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


        '/// Returns an indication whether the current data is updated to SCREEN table successfully.
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


        '/// Returns an indication whether the current data is deleted from SCREEN table successfully.
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


        '/// Returns an indication whether the record of SCREEN by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("screen_code")) = False Then _screen_code = Rdr("screen_code").ToString()
                        If Convert.IsDBNull(Rdr("screen_name")) = False Then _screen_name = Rdr("screen_name").ToString()
                        If Convert.IsDBNull(Rdr("screen_desc")) = False Then _screen_desc = Rdr("screen_desc").ToString()
                        If Convert.IsDBNull(Rdr("module_id")) = False Then _module_id = Convert.ToInt64(Rdr("module_id"))
                        If Convert.IsDBNull(Rdr("screen_order")) = False Then _screen_order = Convert.ToInt64(Rdr("screen_order"))
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
        '/// Returns an indication whether the Class Data of SCREEN by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingData(ByVal ret As ScreenData, ByVal RDr As DataRow) As ScreenData
            If Convert.IsDBNull(Rdr("id")) = False Then ret.ID = Convert.ToInt64(Rdr("id"))
            If Convert.IsDBNull(Rdr("create_by")) = False Then ret.CREATE_BY = Rdr("create_by").ToString()
            If Convert.IsDBNull(Rdr("create_on")) = False Then ret.CREATE_ON = Convert.ToDateTime(Rdr("create_on"))
            If Convert.IsDBNull(Rdr("update_by")) = False Then ret.UPDATE_BY = Rdr("update_by").ToString()
            If Convert.IsDBNull(Rdr("update_on")) = False Then ret.UPDATE_ON = Convert.ToDateTime(Rdr("update_on"))
            If Convert.IsDBNull(Rdr("screen_code")) = False Then ret.SCREEN_CODE = Rdr("screen_code").ToString()
            If Convert.IsDBNull(Rdr("screen_name")) = False Then ret.SCREEN_NAME = Rdr("screen_name").ToString()
            If Convert.IsDBNull(Rdr("screen_desc")) = False Then ret.SCREEN_DESC = Rdr("screen_desc").ToString()
            If Convert.IsDBNull(Rdr("module_id")) = False Then ret.MODULE_ID = Convert.ToInt64(Rdr("module_id"))
            If Convert.IsDBNull(Rdr("screen_order")) = False Then ret.SCREEN_ORDER = Convert.ToInt64(Rdr("screen_order"))
            Return ret
        End Function


        '/// Returns an indication whether the record of SCREEN by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetMappingData(ByVal whText As String, ByVal trans As SQLTransaction) As ScreenData
            ClearData()
            _haveData = False
            Dim ret As New ScreenData
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


        'Get Insert Statement for table SCREEN
        Private ReadOnly Property SqlInsert() As String
            Get
                Dim Sql As String = ""
                Sql += "INSERT INTO " & tableName & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, SCREEN_CODE, SCREEN_NAME, SCREEN_DESC, MODULE_ID, SCREEN_ORDER)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetString(_SCREEN_CODE) & ", "
                sql += DB.SetString(_SCREEN_NAME) & ", "
                sql += DB.SetString(_SCREEN_DESC) & ", "
                sql += DB.SetDouble(_MODULE_ID) & ", "
                sql += DB.SetDouble(_SCREEN_ORDER)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table SCREEN
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_ON = " & DB.SetDateTime(_CREATE_ON) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_ON = " & DB.SetDateTime(_UPDATE_ON) & ", "
                Sql += "SCREEN_CODE = " & DB.SetString(_SCREEN_CODE) & ", "
                Sql += "SCREEN_NAME = " & DB.SetString(_SCREEN_NAME) & ", "
                Sql += "SCREEN_DESC = " & DB.SetString(_SCREEN_DESC) & ", "
                Sql += "MODULE_ID = " & DB.SetDouble(_MODULE_ID) & ", "
                Sql += "SCREEN_ORDER = " & DB.SetDouble(_SCREEN_ORDER) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table SCREEN
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table SCREEN
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace