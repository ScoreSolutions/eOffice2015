Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 
Imports DB = LinqDB.ConnectDB.SQLDB
Imports LinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for TS_APPOINTMENT_JOB table LinqDB.
    '[Create by  on September, 26 2014]
    Public Class TsAppointmentJobLinqDB
        Public sub TsAppointmentJobLinqDB()

        End Sub 
        ' TS_APPOINTMENT_JOB
        Const _tableName As String = "TS_APPOINTMENT_JOB"
        Dim _deletedRow As Int16 = 0

        'Set Common Property
        Dim _error As String = ""
        Dim _information As String = ""
        Dim _haveData As Boolean = False

        Public ReadOnly Property TableName As String
            Get
                Return _tableName
            End Get
        End Property
        Public ReadOnly Property ErrorMessage As String
            Get
                Return _error
            End Get
        End Property
        Public ReadOnly Property InfoMessage As String
            Get
                Return _information
            End Get
        End Property
        Public ReadOnly Property HaveData As Boolean
            Get
                Return _haveData
            End Get
        End Property


        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATED_BY As String = ""
        Dim _CREATED_DATE As DateTime = New DateTime(1,1,1)
        Dim _UPDATED_BY As  String  = ""
        Dim _UPDATED_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _MS_BRANCH_ID As Long = 0
        Dim _MS_CUSTOMER_ID As Long = 0
        Dim _TRANS_DATE As DateTime = New DateTime(1,1,1)
        Dim _APPOINTMENT_DATE As DateTime = New DateTime(1,1,1)
        Dim _APPOINTMENT_CHANNEL As Char = "2"
        Dim _APPOINTMENT_STATUS_ID As Long = 0
        Dim _CUSTOMER_EMAIL As String = ""

        'Generate Field Property 
        <Column(Storage:="_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
               _ID = value
            End Set
        End Property 
        <Column(Storage:="_CREATED_BY", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATED_BY() As String
            Get
                Return _CREATED_BY
            End Get
            Set(ByVal value As String)
               _CREATED_BY = value
            End Set
        End Property 
        <Column(Storage:="_CREATED_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATED_DATE() As DateTime
            Get
                Return _CREATED_DATE
            End Get
            Set(ByVal value As DateTime)
               _CREATED_DATE = value
            End Set
        End Property 
        <Column(Storage:="_UPDATED_BY", DbType:="VarChar(100)")>  _
        Public Property UPDATED_BY() As  String 
            Get
                Return _UPDATED_BY
            End Get
            Set(ByVal value As  String )
               _UPDATED_BY = value
            End Set
        End Property 
        <Column(Storage:="_UPDATED_DATE", DbType:="DateTime")>  _
        Public Property UPDATED_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _UPDATED_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _UPDATED_DATE = value
            End Set
        End Property 
        <Column(Storage:="_MS_BRANCH_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_BRANCH_ID() As Long
            Get
                Return _MS_BRANCH_ID
            End Get
            Set(ByVal value As Long)
               _MS_BRANCH_ID = value
            End Set
        End Property 
        <Column(Storage:="_MS_CUSTOMER_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_CUSTOMER_ID() As Long
            Get
                Return _MS_CUSTOMER_ID
            End Get
            Set(ByVal value As Long)
               _MS_CUSTOMER_ID = value
            End Set
        End Property 
        <Column(Storage:="_TRANS_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property TRANS_DATE() As DateTime
            Get
                Return _TRANS_DATE
            End Get
            Set(ByVal value As DateTime)
               _TRANS_DATE = value
            End Set
        End Property 
        <Column(Storage:="_APPOINTMENT_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property APPOINTMENT_DATE() As DateTime
            Get
                Return _APPOINTMENT_DATE
            End Get
            Set(ByVal value As DateTime)
               _APPOINTMENT_DATE = value
            End Set
        End Property 
        <Column(Storage:="_APPOINTMENT_CHANNEL", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property APPOINTMENT_CHANNEL() As Char
            Get
                Return _APPOINTMENT_CHANNEL
            End Get
            Set(ByVal value As Char)
               _APPOINTMENT_CHANNEL = value
            End Set
        End Property 
        <Column(Storage:="_APPOINTMENT_STATUS_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property APPOINTMENT_STATUS_ID() As Long
            Get
                Return _APPOINTMENT_STATUS_ID
            End Get
            Set(ByVal value As Long)
               _APPOINTMENT_STATUS_ID = value
            End Set
        End Property 
        <Column(Storage:="_CUSTOMER_EMAIL", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property CUSTOMER_EMAIL() As String
            Get
                Return _CUSTOMER_EMAIL
            End Get
            Set(ByVal value As String)
               _CUSTOMER_EMAIL = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _MS_BRANCH_ID = 0
            _MS_CUSTOMER_ID = 0
            _TRANS_DATE = New DateTime(1,1,1)
            _APPOINTMENT_DATE = New DateTime(1,1,1)
            _APPOINTMENT_CHANNEL = ""
            _APPOINTMENT_STATUS_ID = 0
            _CUSTOMER_EMAIL = ""
        End Sub

       'Define Public Method 
        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=orderBy>The fields for sort data.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetDataList(whClause As String, orderBy As String, trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(SqlSelect & IIf(whClause = "", "", " WHERE " & whClause) & IIF(orderBy = "", "", " ORDER BY  " & orderBy), trans)
        End Function


        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetListBySql(Sql As String, trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(Sql, trans)
        End Function


        '/// Returns an indication whether the current data is inserted into TS_APPOINTMENT_JOB table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _ID = DB.GetNextID("ID",tableName, trans)
                _Created_By = LoginName
                _Created_Date = DateTime.Now
                Return doInsert(trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to TS_APPOINTMENT_JOB table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _Updated_By = LoginName
                _Updated_Date = DateTime.Now
                Return doUpdate("ID = " & DB.SetDouble(_ID), trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to TS_APPOINTMENT_JOB table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TS_APPOINTMENT_JOB table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPK(cID As Long, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return doDelete("ID = " & DB.SetDouble(cID), trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the record of TS_APPOINTMENT_JOB by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TS_APPOINTMENT_JOB by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TsAppointmentJobLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TS_APPOINTMENT_JOB by specified MS_BRANCH_ID key is retrieved successfully.
        '/// <param name=cMS_BRANCH_ID>The MS_BRANCH_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMS_BRANCH_ID(cMS_BRANCH_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MS_BRANCH_ID = " & DB.SetDouble(cMS_BRANCH_ID) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TS_APPOINTMENT_JOB by specified MS_BRANCH_ID key is retrieved successfully.
        '/// <param name=cMS_BRANCH_ID>The MS_BRANCH_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMS_BRANCH_ID(cMS_BRANCH_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MS_BRANCH_ID = " & DB.SetDouble(cMS_BRANCH_ID) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TS_APPOINTMENT_JOB by specified MS_CUSTOMER_ID key is retrieved successfully.
        '/// <param name=cMS_CUSTOMER_ID>The MS_CUSTOMER_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMS_CUSTOMER_ID(cMS_CUSTOMER_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MS_CUSTOMER_ID = " & DB.SetDouble(cMS_CUSTOMER_ID) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TS_APPOINTMENT_JOB by specified MS_CUSTOMER_ID key is retrieved successfully.
        '/// <param name=cMS_CUSTOMER_ID>The MS_CUSTOMER_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMS_CUSTOMER_ID(cMS_CUSTOMER_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MS_CUSTOMER_ID = " & DB.SetDouble(cMS_CUSTOMER_ID) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TS_APPOINTMENT_JOB by specified APPOINTMENT_DATE_MS_BRANCH_ID key is retrieved successfully.
        '/// <param name=cAPPOINTMENT_DATE_MS_BRANCH_ID>The APPOINTMENT_DATE_MS_BRANCH_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByAPPOINTMENT_DATE_MS_BRANCH_ID(cAPPOINTMENT_DATE As DateTime, cMS_BRANCH_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("APPOINTMENT_DATE = " & DB.SetDateTime(cAPPOINTMENT_DATE) & " AND MS_BRANCH_ID = " & DB.SetDouble(cMS_BRANCH_ID), trans)
        End Function

        '/// Returns an duplicate data record of TS_APPOINTMENT_JOB by specified APPOINTMENT_DATE_MS_BRANCH_ID key is retrieved successfully.
        '/// <param name=cAPPOINTMENT_DATE_MS_BRANCH_ID>The APPOINTMENT_DATE_MS_BRANCH_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByAPPOINTMENT_DATE_MS_BRANCH_ID(cAPPOINTMENT_DATE As DateTime, cMS_BRANCH_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("APPOINTMENT_DATE = " & DB.SetDateTime(cAPPOINTMENT_DATE) & " AND MS_BRANCH_ID = " & DB.SetDouble(cMS_BRANCH_ID) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TS_APPOINTMENT_JOB by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TS_APPOINTMENT_JOB table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Private Function doInsert(trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = False Then
                Try
                    ret = (DB.ExecuteNonQuery(SqlInsert, trans, SetParameterData()) > -1)
                    If ret = False Then
                        _error = DB.ErrorMessage
                    Else
                        _haveData = True
                    End If
                    _information = MessageResources.MSGIN001
                Catch ex As ApplicationException
                    ret = false
                    _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlInsert
                Catch ex As Exception
                    ret = False
                    _error = MessageResources.MSGEC101 & " Exception :" & ex.ToString() & "### SQL: " & SqlInsert
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEN002 & "### SQL: " & SqlInsert
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is updated to TS_APPOINTMENT_JOB table successfully.
        '/// <param name=whText>The condition specify the updating record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Private Function doUpdate(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If _haveData = True Then
                If whText.Trim() <> ""
                    Try
                        ret = (DB.ExecuteNonQuery(SqlUpdate & tmpWhere, trans, SetParameterData()) > -1)
                        If ret = False Then
                            _error = DB.ErrorMessage
                        End If
                        _information = MessageResources.MSGIU001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlUpdate & tmpWhere
                    Catch ex As Exception
                        ret = False
                        _error = MessageResources.MSGEC102 & " Exception :" & ex.ToString() & "### SQL: " & SqlUpdate & tmpWhere
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGEU003 & "### SQL: " & SqlUpdate & tmpWhere
                End If
            Else
                ret = True
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is deleted from TS_APPOINTMENT_JOB table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If doChkData(whText, trans) = True Then
                If whText.Trim() <> ""
                    Try
                        ret = (DB.ExecuteNonQuery(SqlDelete & tmpWhere, trans) > -1)
                        If ret = False Then
                            _error = MessageResources.MSGED001
                        End If
                        _information = MessageResources.MSGID001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlDelete & tmpWhere
                    Catch ex As Exception
                        ret = False
                        _error = MessageResources.MSGEC103 & " Exception :" & ex.ToString() & "### SQL: " & SqlDelete & tmpWhere
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGED003 & "### SQL: " & SqlDelete & tmpWhere
                End If
            Else
                ret = True
            End If

            Return ret
        End Function

        Private Function SetParameterData() As SqlParameter()
            Dim cmbParam(11) As SqlParameter
            cmbParam(0) = New SqlParameter("@_ID", SqlDbType.BigInt)
            cmbParam(0).Value = _ID

            cmbParam(1) = New SqlParameter("@_CREATED_BY", SqlDbType.VarChar)
            cmbParam(1).Value = _CREATED_BY

            cmbParam(2) = New SqlParameter("@_CREATED_DATE", SqlDbType.DateTime)
            If _CREATED_DATE.Year > 1 Then 
                cmbParam(2).Value = _CREATED_DATE
            Else
                cmbParam(2).Value = DBNull.value
            End If

            cmbParam(3) = New SqlParameter("@_UPDATED_BY", SqlDbType.VarChar)
            cmbParam(3).Value = _UPDATED_BY

            cmbParam(4) = New SqlParameter("@_UPDATED_DATE", SqlDbType.DateTime)
            If _UPDATED_DATE.Value.Year > 1 Then 
                cmbParam(4).Value = _UPDATED_DATE.Value
            Else
                cmbParam(4).Value = DBNull.value
            End If

            cmbParam(5) = New SqlParameter("@_MS_BRANCH_ID", SqlDbType.BigInt)
            cmbParam(5).Value = _MS_BRANCH_ID

            cmbParam(6) = New SqlParameter("@_MS_CUSTOMER_ID", SqlDbType.BigInt)
            cmbParam(6).Value = _MS_CUSTOMER_ID

            cmbParam(7) = New SqlParameter("@_TRANS_DATE", SqlDbType.DateTime)
            If _TRANS_DATE.Year > 1 Then 
                cmbParam(7).Value = _TRANS_DATE
            Else
                cmbParam(7).Value = DBNull.value
            End If

            cmbParam(8) = New SqlParameter("@_APPOINTMENT_DATE", SqlDbType.DateTime)
            If _APPOINTMENT_DATE.Year > 1 Then 
                cmbParam(8).Value = _APPOINTMENT_DATE
            Else
                cmbParam(8).Value = DBNull.value
            End If

            cmbParam(9) = New SqlParameter("@_APPOINTMENT_CHANNEL", SqlDbType.Char)
            cmbParam(9).Value = _APPOINTMENT_CHANNEL

            cmbParam(10) = New SqlParameter("@_APPOINTMENT_STATUS_ID", SqlDbType.BigInt)
            cmbParam(10).Value = _APPOINTMENT_STATUS_ID

            cmbParam(11) = New SqlParameter("@_CUSTOMER_EMAIL", SqlDbType.VarChar)
            cmbParam(11).Value = _CUSTOMER_EMAIL

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TS_APPOINTMENT_JOB by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doChkData(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " WHERE " & whText
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("created_by")) = False Then _created_by = Rdr("created_by").ToString()
                        If Convert.IsDBNull(Rdr("created_date")) = False Then _created_date = Convert.ToDateTime(Rdr("created_date"))
                        If Convert.IsDBNull(Rdr("updated_by")) = False Then _updated_by = Rdr("updated_by").ToString()
                        If Convert.IsDBNull(Rdr("updated_date")) = False Then _updated_date = Convert.ToDateTime(Rdr("updated_date"))
                        If Convert.IsDBNull(Rdr("ms_branch_id")) = False Then _ms_branch_id = Convert.ToInt64(Rdr("ms_branch_id"))
                        If Convert.IsDBNull(Rdr("ms_customer_id")) = False Then _ms_customer_id = Convert.ToInt64(Rdr("ms_customer_id"))
                        If Convert.IsDBNull(Rdr("trans_date")) = False Then _trans_date = Convert.ToDateTime(Rdr("trans_date"))
                        If Convert.IsDBNull(Rdr("appointment_date")) = False Then _appointment_date = Convert.ToDateTime(Rdr("appointment_date"))
                        If Convert.IsDBNull(Rdr("appointment_channel")) = False Then _appointment_channel = Rdr("appointment_channel").ToString()
                        If Convert.IsDBNull(Rdr("appointment_status_id")) = False Then _appointment_status_id = Convert.ToInt64(Rdr("appointment_status_id"))
                        If Convert.IsDBNull(Rdr("customer_email")) = False Then _customer_email = Rdr("customer_email").ToString()
                    Else
                        ret = False
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC104 & " #### " & ex.ToString()
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEV001
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of TS_APPOINTMENT_JOB by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TsAppointmentJobLinqDB
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("created_by")) = False Then _created_by = Rdr("created_by").ToString()
                        If Convert.IsDBNull(Rdr("created_date")) = False Then _created_date = Convert.ToDateTime(Rdr("created_date"))
                        If Convert.IsDBNull(Rdr("updated_by")) = False Then _updated_by = Rdr("updated_by").ToString()
                        If Convert.IsDBNull(Rdr("updated_date")) = False Then _updated_date = Convert.ToDateTime(Rdr("updated_date"))
                        If Convert.IsDBNull(Rdr("ms_branch_id")) = False Then _ms_branch_id = Convert.ToInt64(Rdr("ms_branch_id"))
                        If Convert.IsDBNull(Rdr("ms_customer_id")) = False Then _ms_customer_id = Convert.ToInt64(Rdr("ms_customer_id"))
                        If Convert.IsDBNull(Rdr("trans_date")) = False Then _trans_date = Convert.ToDateTime(Rdr("trans_date"))
                        If Convert.IsDBNull(Rdr("appointment_date")) = False Then _appointment_date = Convert.ToDateTime(Rdr("appointment_date"))
                        If Convert.IsDBNull(Rdr("appointment_channel")) = False Then _appointment_channel = Rdr("appointment_channel").ToString()
                        If Convert.IsDBNull(Rdr("appointment_status_id")) = False Then _appointment_status_id = Convert.ToInt64(Rdr("appointment_status_id"))
                        If Convert.IsDBNull(Rdr("customer_email")) = False Then _customer_email = Rdr("customer_email").ToString()
                    Else
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    _error = MessageResources.MSGEC104 & " #### " & ex.ToString()
                End Try
            Else
                _error = MessageResources.MSGEV001
            End If
            Return Me
        End Function



        ' SQL Statements


        'Get Insert Statement for table TS_APPOINTMENT_JOB
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_BRANCH_ID, MS_CUSTOMER_ID, TRANS_DATE, APPOINTMENT_DATE, APPOINTMENT_CHANNEL, APPOINTMENT_STATUS_ID, CUSTOMER_EMAIL)"
                Sql += " VALUES("
                sql += "@_ID" & ", "
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_UPDATED_BY" & ", "
                sql += "@_UPDATED_DATE" & ", "
                sql += "@_MS_BRANCH_ID" & ", "
                sql += "@_MS_CUSTOMER_ID" & ", "
                sql += "@_TRANS_DATE" & ", "
                sql += "@_APPOINTMENT_DATE" & ", "
                sql += "@_APPOINTMENT_CHANNEL" & ", "
                sql += "@_APPOINTMENT_STATUS_ID" & ", "
                sql += "@_CUSTOMER_EMAIL"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TS_APPOINTMENT_JOB
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATED_BY = " & "@_CREATED_BY" & ", "
                Sql += "CREATED_DATE = " & "@_CREATED_DATE" & ", "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "MS_BRANCH_ID = " & "@_MS_BRANCH_ID" & ", "
                Sql += "MS_CUSTOMER_ID = " & "@_MS_CUSTOMER_ID" & ", "
                Sql += "TRANS_DATE = " & "@_TRANS_DATE" & ", "
                Sql += "APPOINTMENT_DATE = " & "@_APPOINTMENT_DATE" & ", "
                Sql += "APPOINTMENT_CHANNEL = " & "@_APPOINTMENT_CHANNEL" & ", "
                Sql += "APPOINTMENT_STATUS_ID = " & "@_APPOINTMENT_STATUS_ID" & ", "
                Sql += "CUSTOMER_EMAIL = " & "@_CUSTOMER_EMAIL" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TS_APPOINTMENT_JOB
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TS_APPOINTMENT_JOB
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_BRANCH_ID, MS_CUSTOMER_ID, TRANS_DATE, APPOINTMENT_DATE, APPOINTMENT_CHANNEL, APPOINTMENT_STATUS_ID, CUSTOMER_EMAIL FROM " & tableName
                Return Sql
            End Get
        End Property


            'Define Child Table 

       Dim _TS_APPOINTMENT_JOB_SERVICE_ts_appointment_job_id As DataTable

       Public Property CHILD_TS_APPOINTMENT_JOB_SERVICE_ts_appointment_job_id() As DataTable
           Get
               'Child Table Name : TS_APPOINTMENT_JOB_SERVICE Column :ts_appointment_job_id
               Dim trans As New LinqDB.ConnectDB.TransactionDB
               Dim TsAppointmentJobServiceItem As New TsAppointmentJobServiceLinqDB
               _TS_APPOINTMENT_JOB_SERVICE_ts_appointment_job_id = TsAppointmentJobServiceItem.GetDataList("ts_appointment_job_id = " & _ID, "", trans.Trans)
               trans.CommitTransaction()
               TsAppointmentJobServiceItem = Nothing
               Return _TS_APPOINTMENT_JOB_SERVICE_ts_appointment_job_id
           End Get
           Set(ByVal value As DataTable)
               _TS_APPOINTMENT_JOB_SERVICE_ts_appointment_job_id = value
           End Set
       End Property
    End Class
End Namespace
