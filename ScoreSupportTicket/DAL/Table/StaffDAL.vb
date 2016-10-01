﻿Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DB = XCS.DAL.Common.Utilities.SqlDB
Imports XCS.Data.Common.Utilities
Imports XCS.Data.Table

Namespace Table
    'Represents a transaction for STAFF table DAL.
    '[Create by  on March, 8 2011]
    Public Class StaffDAL
        Public Sub StaffDAL()

        End Sub
        ' STAFF
        Const _tableName As String = "TRACKINGLOG_STAFF"
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
        Dim _USERNAME As String = ""
        Dim _PWD As String = ""
        Dim _STAFFNAME As String = ""
        Dim _POSITION_NAME As String = ""
        Dim _DIVISION_NAME As String = ""
        Dim _CAN_RAISE As String = ""
        Dim _CAN_ACCEPT_ASSIGNMENT As String = ""
        Dim _CAN_CLOSE As String = ""
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
        Public Property USERNAME() As String
            Get
                Return _USERNAME
            End Get
            Set(ByVal value As String)
                _USERNAME = value
            End Set
        End Property
        Public Property PWD() As String
            Get
                Return _PWD
            End Get
            Set(ByVal value As String)
                _PWD = value
            End Set
        End Property
        Public Property STAFFNAME() As String
            Get
                Return _STAFFNAME
            End Get
            Set(ByVal value As String)
                _STAFFNAME = value
            End Set
        End Property
        Public Property POSITION_NAME() As String
            Get
                Return _POSITION_NAME
            End Get
            Set(ByVal value As String)
                _POSITION_NAME = value
            End Set
        End Property
        Public Property DIVISION_NAME() As String
            Get
                Return _DIVISION_NAME
            End Get
            Set(ByVal value As String)
                _DIVISION_NAME = value
            End Set
        End Property
        Public Property CAN_RAISE() As String
            Get
                Return _CAN_RAISE
            End Get
            Set(ByVal value As String)
                _CAN_RAISE = value
            End Set
        End Property
        Public Property CAN_ACCEPT_ASSIGNMENT() As String
            Get
                Return _CAN_ACCEPT_ASSIGNMENT
            End Get
            Set(ByVal value As String)
                _CAN_ACCEPT_ASSIGNMENT = value
            End Set
        End Property
        Public Property CAN_CLOSE() As String
            Get
                Return _CAN_CLOSE
            End Get
            Set(ByVal value As String)
                _CAN_CLOSE = value
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
            _USERNAME = ""
            _PWD = ""
            _STAFFNAME = ""
            _POSITION_NAME = ""
            _DIVISION_NAME = ""
            _CAN_RAISE = ""
            _CAN_ACCEPT_ASSIGNMENT = ""
            _CAN_CLOSE = ""
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


        '/// Returns an indication whether the current data is inserted into STAFF table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _id = DB.GetNextID("id", tableName, trans)
            _CREATE_BY = UserID
            _CREATE_ON = DateTime.Now
            Return doInsert(trans)
        End Function


        '/// Returns an indication whether the current data is updated to STAFF table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _UPDATE_BY = UserID
            _UPDATE_ON = DateTime.Now
            Return doUpdate("id = " & DB.SetDouble(_id) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is deleted from STAFF table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPK(ByVal trans As SQLTransaction) As Boolean
            Return doDelete("id = " & DB.SetDouble(_id) & " ", trans)
        End Function


        '/// Returns an indication whether the record of STAFF by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(ByVal cid As Long, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of STAFF by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(ByVal cid As Long, ByVal trans As SQLTransaction) As StaffData
            Return doGetMappingData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is updated to STAFF table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByUSERNAME(ByVal cUSERNAME As String, ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _UPDATE_BY = UserID
            _UPDATE_ON = DateTime.Now
            Return doUpdate("USERNAME = " & DB.SetString(cUSERNAME) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is deleted from STAFF table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByUSERNAME(ByVal cUSERNAME As String, ByVal trans As SQLTransaction) As Boolean
            Return doDelete("USERNAME = " & DB.SetString(cUSERNAME) & " ", trans)
        End Function


        '/// Returns an indication whether the record of STAFF by specified USERNAME key is retrieved successfully.
        '/// <param name=cUSERNAME>The USERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByUSERNAME(ByVal cUSERNAME As String, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("USERNAME = " & DB.SetString(cUSERNAME) & " ", trans)
        End Function

        '/// Returns an indication whether the Data Class of STAFF by specified USERNAME key is retrieved successfully.
        '/// <param name=cUSERNAME>The USERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByUSERNAME(ByVal cUSERNAME As String, ByVal trans As SQLTransaction) As StaffData
            Return doGetMappingData("USERNAME = " & DB.SetString(cUSERNAME) & " ", trans)
        End Function

        '/// Returns an indication whether the current data is updated to STAFF table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySTAFFNAME(ByVal cSTAFFNAME As String, ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _UPDATE_BY = UserID
            _UPDATE_ON = DateTime.Now
            Return doUpdate("STAFFNAME = " & DB.SetString(cSTAFFNAME) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is deleted from STAFF table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteBySTAFFNAME(ByVal cSTAFFNAME As String, ByVal trans As SQLTransaction) As Boolean
            Return doDelete("STAFFNAME = " & DB.SetString(cSTAFFNAME) & " ", trans)
        End Function


        '/// Returns an indication whether the record of STAFF by specified STAFFNAME key is retrieved successfully.
        '/// <param name=cSTAFFNAME>The STAFFNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySTAFFNAME(ByVal cSTAFFNAME As String, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("STAFFNAME = " & DB.SetString(cSTAFFNAME) & " ", trans)
        End Function

        '/// Returns an indication whether the Data Class of STAFF by specified STAFFNAME key is retrieved successfully.
        '/// <param name=cSTAFFNAME>The STAFFNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataBySTAFFNAME(ByVal cSTAFFNAME As String, ByVal trans As SQLTransaction) As StaffData
            Return doGetMappingData("STAFFNAME = " & DB.SetString(cSTAFFNAME) & " ", trans)
        End Function

        '/// Returns an indication whether the record of STAFF by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(ByVal whText As String, ByVal trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into STAFF table successfully.
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


        '/// Returns an indication whether the current data is updated to STAFF table successfully.
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


        '/// Returns an indication whether the current data is deleted from STAFF table successfully.
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


        '/// Returns an indication whether the record of STAFF by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("username")) = False Then _username = Rdr("username").ToString()
                        If Convert.IsDBNull(Rdr("pwd")) = False Then _pwd = Rdr("pwd").ToString()
                        If Convert.IsDBNull(Rdr("staffname")) = False Then _staffname = Rdr("staffname").ToString()
                        If Convert.IsDBNull(Rdr("position_name")) = False Then _position_name = Rdr("position_name").ToString()
                        If Convert.IsDBNull(Rdr("division_name")) = False Then _division_name = Rdr("division_name").ToString()
                        If Convert.IsDBNull(Rdr("can_raise")) = False Then _can_raise = Rdr("can_raise").ToString()
                        If Convert.IsDBNull(Rdr("can_accept_assignment")) = False Then _can_accept_assignment = Rdr("can_accept_assignment").ToString()
                        If Convert.IsDBNull(Rdr("can_close")) = False Then _can_close = Rdr("can_close").ToString()
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
        '/// Returns an indication whether the Class Data of STAFF by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingData(ByVal ret As StaffData, ByVal RDr As DataRow) As StaffData
            If Convert.IsDBNull(Rdr("id")) = False Then ret.ID = Convert.ToInt64(Rdr("id"))
            If Convert.IsDBNull(Rdr("create_by")) = False Then ret.CREATE_BY = Rdr("create_by").ToString()
            If Convert.IsDBNull(Rdr("create_on")) = False Then ret.CREATE_ON = Convert.ToDateTime(Rdr("create_on"))
            If Convert.IsDBNull(Rdr("update_by")) = False Then ret.UPDATE_BY = Rdr("update_by").ToString()
            If Convert.IsDBNull(Rdr("update_on")) = False Then ret.UPDATE_ON = Convert.ToDateTime(Rdr("update_on"))
            If Convert.IsDBNull(Rdr("username")) = False Then ret.USERNAME = Rdr("username").ToString()
            If Convert.IsDBNull(Rdr("pwd")) = False Then ret.PWD = Rdr("pwd").ToString()
            If Convert.IsDBNull(Rdr("staffname")) = False Then ret.STAFFNAME = Rdr("staffname").ToString()
            If Convert.IsDBNull(Rdr("position_name")) = False Then ret.POSITION_NAME = Rdr("position_name").ToString()
            If Convert.IsDBNull(Rdr("division_name")) = False Then ret.DIVISION_NAME = Rdr("division_name").ToString()
            If Convert.IsDBNull(Rdr("can_raise")) = False Then ret.CAN_RAISE = Rdr("can_raise").ToString()
            If Convert.IsDBNull(Rdr("can_accept_assignment")) = False Then ret.CAN_ACCEPT_ASSIGNMENT = Rdr("can_accept_assignment").ToString()
            If Convert.IsDBNull(Rdr("can_close")) = False Then ret.CAN_CLOSE = Rdr("can_close").ToString()
            If Convert.IsDBNull(Rdr("active")) = False Then ret.ACTIVE = Rdr("active").ToString()
            Return ret
        End Function


        '/// Returns an indication whether the record of STAFF by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetMappingData(ByVal whText As String, ByVal trans As SQLTransaction) As StaffData
            ClearData()
            _haveData = False
            Dim ret As New StaffData
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


        'Get Insert Statement for table STAFF
        Private ReadOnly Property SqlInsert() As String
            Get
                Dim Sql As String = ""
                Sql += "INSERT INTO " & tableName & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, USERNAME, PWD, STAFFNAME, POSITION_NAME, DIVISION_NAME, CAN_RAISE, CAN_ACCEPT_ASSIGNMENT, CAN_CLOSE, ACTIVE)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetString(_USERNAME) & ", "
                sql += DB.SetString(_PWD) & ", "
                sql += DB.SetString(_STAFFNAME) & ", "
                sql += DB.SetString(_POSITION_NAME) & ", "
                sql += DB.SetString(_DIVISION_NAME) & ", "
                sql += DB.SetString(_CAN_RAISE) & ", "
                sql += DB.SetString(_CAN_ACCEPT_ASSIGNMENT) & ", "
                sql += DB.SetString(_CAN_CLOSE) & ", "
                sql += DB.SetString(_ACTIVE)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table STAFF
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_ON = " & DB.SetDateTime(_CREATE_ON) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_ON = " & DB.SetDateTime(_UPDATE_ON) & ", "
                Sql += "USERNAME = " & DB.SetString(_USERNAME) & ", "
                Sql += "PWD = " & DB.SetString(_PWD) & ", "
                Sql += "STAFFNAME = " & DB.SetString(_STAFFNAME) & ", "
                Sql += "POSITION_NAME = " & DB.SetString(_POSITION_NAME) & ", "
                Sql += "DIVISION_NAME = " & DB.SetString(_DIVISION_NAME) & ", "
                Sql += "CAN_RAISE = " & DB.SetString(_CAN_RAISE) & ", "
                Sql += "CAN_ACCEPT_ASSIGNMENT = " & DB.SetString(_CAN_ACCEPT_ASSIGNMENT) & ", "
                Sql += "CAN_CLOSE = " & DB.SetString(_CAN_CLOSE) & ", "
                Sql += "ACTIVE = " & DB.SetString(_ACTIVE) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table STAFF
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table STAFF
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace