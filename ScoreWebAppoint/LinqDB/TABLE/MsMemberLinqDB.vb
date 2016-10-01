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
    'Represents a transaction for MS_MEMBER table LinqDB.
    '[Create by  on September, 26 2014]
    Public Class MsMemberLinqDB
        Public sub MsMemberLinqDB()

        End Sub 
        ' MS_MEMBER
        Const _tableName As String = "MS_MEMBER"
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
        Dim _MEMBER_CODE As String = ""
        Dim _MEMBER_NAME_EN As String = ""
        Dim _MEMBER_NAME_TH As String = ""
        Dim _MS_MEMBER_TYPE_ID As Long = 0
        Dim _REGISTER_DATE As DateTime = New DateTime(1,1,1)
        Dim _MEMBER_LOGO() As Byte
        Dim _LOGO2() As Byte

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
        <Column(Storage:="_MEMBER_CODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property MEMBER_CODE() As String
            Get
                Return _MEMBER_CODE
            End Get
            Set(ByVal value As String)
               _MEMBER_CODE = value
            End Set
        End Property 
        <Column(Storage:="_MEMBER_NAME_EN", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property MEMBER_NAME_EN() As String
            Get
                Return _MEMBER_NAME_EN
            End Get
            Set(ByVal value As String)
               _MEMBER_NAME_EN = value
            End Set
        End Property 
        <Column(Storage:="_MEMBER_NAME_TH", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property MEMBER_NAME_TH() As String
            Get
                Return _MEMBER_NAME_TH
            End Get
            Set(ByVal value As String)
               _MEMBER_NAME_TH = value
            End Set
        End Property 
        <Column(Storage:="_MS_MEMBER_TYPE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_MEMBER_TYPE_ID() As Long
            Get
                Return _MS_MEMBER_TYPE_ID
            End Get
            Set(ByVal value As Long)
               _MS_MEMBER_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_REGISTER_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property REGISTER_DATE() As DateTime
            Get
                Return _REGISTER_DATE
            End Get
            Set(ByVal value As DateTime)
               _REGISTER_DATE = value
            End Set
        End Property 
        <Column(Storage:="_MEMBER_LOGO", DbType:="IMAGE")>  _
        Public Property MEMBER_LOGO() As  Byte() 
            Get
                Return _MEMBER_LOGO
            End Get
            Set(ByVal value() As Byte)
               _MEMBER_LOGO = value
            End Set
        End Property 
        <Column(Storage:="_LOGO2", DbType:="IMAGE")>  _
        Public Property LOGO2() As  Byte() 
            Get
                Return _LOGO2
            End Get
            Set(ByVal value() As Byte)
               _LOGO2 = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _MEMBER_CODE = ""
            _MEMBER_NAME_EN = ""
            _MEMBER_NAME_TH = ""
            _MS_MEMBER_TYPE_ID = 0
            _REGISTER_DATE = New DateTime(1,1,1)
             _MEMBER_LOGO = Nothing
             _LOGO2 = Nothing
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


        '/// Returns an indication whether the current data is inserted into MS_MEMBER table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_MEMBER table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_MEMBER table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from MS_MEMBER table successfully.
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


        '/// Returns an indication whether the record of MS_MEMBER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of MS_MEMBER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As MsMemberLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of MS_MEMBER by specified MEMBER_CODE key is retrieved successfully.
        '/// <param name=cMEMBER_CODE>The MEMBER_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMEMBER_CODE(cMEMBER_CODE As String, trans As SQLTransaction) As Boolean
            Return doChkData("MEMBER_CODE = " & DB.SetString(cMEMBER_CODE) & " ", trans)
        End Function

        '/// Returns an duplicate data record of MS_MEMBER by specified MEMBER_CODE key is retrieved successfully.
        '/// <param name=cMEMBER_CODE>The MEMBER_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMEMBER_CODE(cMEMBER_CODE As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MEMBER_CODE = " & DB.SetString(cMEMBER_CODE) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MS_MEMBER by specified MEMBER_NAME_EN key is retrieved successfully.
        '/// <param name=cMEMBER_NAME_EN>The MEMBER_NAME_EN key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMEMBER_NAME_EN(cMEMBER_NAME_EN As String, trans As SQLTransaction) As Boolean
            Return doChkData("MEMBER_NAME_EN = " & DB.SetString(cMEMBER_NAME_EN) & " ", trans)
        End Function

        '/// Returns an duplicate data record of MS_MEMBER by specified MEMBER_NAME_EN key is retrieved successfully.
        '/// <param name=cMEMBER_NAME_EN>The MEMBER_NAME_EN key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMEMBER_NAME_EN(cMEMBER_NAME_EN As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MEMBER_NAME_EN = " & DB.SetString(cMEMBER_NAME_EN) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MS_MEMBER by specified MEMBER_NAME_TH key is retrieved successfully.
        '/// <param name=cMEMBER_NAME_TH>The MEMBER_NAME_TH key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMEMBER_NAME_TH(cMEMBER_NAME_TH As String, trans As SQLTransaction) As Boolean
            Return doChkData("MEMBER_NAME_TH = " & DB.SetString(cMEMBER_NAME_TH) & " ", trans)
        End Function

        '/// Returns an duplicate data record of MS_MEMBER by specified MEMBER_NAME_TH key is retrieved successfully.
        '/// <param name=cMEMBER_NAME_TH>The MEMBER_NAME_TH key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMEMBER_NAME_TH(cMEMBER_NAME_TH As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MEMBER_NAME_TH = " & DB.SetString(cMEMBER_NAME_TH) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MS_MEMBER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into MS_MEMBER table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_MEMBER table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_MEMBER table successfully.
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

            cmbParam(5) = New SqlParameter("@_MEMBER_CODE", SqlDbType.VarChar)
            cmbParam(5).Value = _MEMBER_CODE

            cmbParam(6) = New SqlParameter("@_MEMBER_NAME_EN", SqlDbType.VarChar)
            cmbParam(6).Value = _MEMBER_NAME_EN

            cmbParam(7) = New SqlParameter("@_MEMBER_NAME_TH", SqlDbType.VarChar)
            cmbParam(7).Value = _MEMBER_NAME_TH

            cmbParam(8) = New SqlParameter("@_MS_MEMBER_TYPE_ID", SqlDbType.BigInt)
            cmbParam(8).Value = _MS_MEMBER_TYPE_ID

            cmbParam(9) = New SqlParameter("@_REGISTER_DATE", SqlDbType.DateTime)
            If _REGISTER_DATE.Year > 1 Then 
                cmbParam(9).Value = _REGISTER_DATE
            Else
                cmbParam(9).Value = DBNull.value
            End If

            If _MEMBER_LOGO IsNot Nothing Then 
                cmbParam(10) = New SqlParameter("@_MEMBER_LOGO",SqlDbType.Image, _MEMBER_LOGO.Length)
                cmbParam(10).Value = _MEMBER_LOGO
            Else
                cmbParam(10) = New SqlParameter("@_MEMBER_LOGO", SqlDbType.Image)
                cmbParam(10).Value = DBNull.value
            End If

            If _LOGO2 IsNot Nothing Then 
                cmbParam(11) = New SqlParameter("@_LOGO2",SqlDbType.Image, _LOGO2.Length)
                cmbParam(11).Value = _LOGO2
            Else
                cmbParam(11) = New SqlParameter("@_LOGO2", SqlDbType.Image)
                cmbParam(11).Value = DBNull.value
            End If

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of MS_MEMBER by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("member_code")) = False Then _member_code = Rdr("member_code").ToString()
                        If Convert.IsDBNull(Rdr("member_name_en")) = False Then _member_name_en = Rdr("member_name_en").ToString()
                        If Convert.IsDBNull(Rdr("member_name_th")) = False Then _member_name_th = Rdr("member_name_th").ToString()
                        If Convert.IsDBNull(Rdr("ms_member_type_id")) = False Then _ms_member_type_id = Convert.ToInt64(Rdr("ms_member_type_id"))
                        If Convert.IsDBNull(Rdr("register_date")) = False Then _register_date = Convert.ToDateTime(Rdr("register_date"))
                        If Convert.IsDBNull(Rdr("member_logo")) = False Then _member_logo = CType(Rdr("member_logo"), Byte())
                        If Convert.IsDBNull(Rdr("logo2")) = False Then _logo2 = CType(Rdr("logo2"), Byte())
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


        '/// Returns an indication whether the record of MS_MEMBER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As MsMemberLinqDB
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
                        If Convert.IsDBNull(Rdr("member_code")) = False Then _member_code = Rdr("member_code").ToString()
                        If Convert.IsDBNull(Rdr("member_name_en")) = False Then _member_name_en = Rdr("member_name_en").ToString()
                        If Convert.IsDBNull(Rdr("member_name_th")) = False Then _member_name_th = Rdr("member_name_th").ToString()
                        If Convert.IsDBNull(Rdr("ms_member_type_id")) = False Then _ms_member_type_id = Convert.ToInt64(Rdr("ms_member_type_id"))
                        If Convert.IsDBNull(Rdr("register_date")) = False Then _register_date = Convert.ToDateTime(Rdr("register_date"))
                        If Convert.IsDBNull(Rdr("member_logo")) = False Then _member_logo = CType(Rdr("member_logo"), Byte())
                        If Convert.IsDBNull(Rdr("logo2")) = False Then _logo2 = CType(Rdr("logo2"), Byte())
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


        'Get Insert Statement for table MS_MEMBER
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MEMBER_CODE, MEMBER_NAME_EN, MEMBER_NAME_TH, MS_MEMBER_TYPE_ID, REGISTER_DATE, MEMBER_LOGO, LOGO2)"
                Sql += " VALUES("
                sql += "@_ID" & ", "
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_UPDATED_BY" & ", "
                sql += "@_UPDATED_DATE" & ", "
                sql += "@_MEMBER_CODE" & ", "
                sql += "@_MEMBER_NAME_EN" & ", "
                sql += "@_MEMBER_NAME_TH" & ", "
                sql += "@_MS_MEMBER_TYPE_ID" & ", "
                sql += "@_REGISTER_DATE" & ", "
                sql += "@_MEMBER_LOGO" & ", "
                sql += "@_LOGO2"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table MS_MEMBER
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATED_BY = " & "@_CREATED_BY" & ", "
                Sql += "CREATED_DATE = " & "@_CREATED_DATE" & ", "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "MEMBER_CODE = " & "@_MEMBER_CODE" & ", "
                Sql += "MEMBER_NAME_EN = " & "@_MEMBER_NAME_EN" & ", "
                Sql += "MEMBER_NAME_TH = " & "@_MEMBER_NAME_TH" & ", "
                Sql += "MS_MEMBER_TYPE_ID = " & "@_MS_MEMBER_TYPE_ID" & ", "
                Sql += "REGISTER_DATE = " & "@_REGISTER_DATE" & ", "
                Sql += "MEMBER_LOGO = " & "@_MEMBER_LOGO" & ", "
                Sql += "LOGO2 = " & "@_LOGO2" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table MS_MEMBER
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table MS_MEMBER
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MEMBER_CODE, MEMBER_NAME_EN, MEMBER_NAME_TH, MS_MEMBER_TYPE_ID, REGISTER_DATE, MEMBER_LOGO, LOGO2 FROM " & tableName
                Return Sql
            End Get
        End Property


            'Define Child Table 

       Dim _MS_BRANCH_ms_member_id As DataTable
       Dim _MS_MEMBER_CUSTOMER_TYPE_ms_member_id As DataTable
       Dim _MS_MEMBER_SERVICE_ms_member_id As DataTable
       Dim _MS_MEMBER_SYSCONFIG_ms_member_id As DataTable

       Public Property CHILD_MS_BRANCH_ms_member_id() As DataTable
           Get
               'Child Table Name : MS_BRANCH Column :ms_member_id
               Dim trans As New LinqDB.ConnectDB.TransactionDB
               Dim MsBranchItem As New MsBranchLinqDB
               _MS_BRANCH_ms_member_id = MsBranchItem.GetDataList("ms_member_id = " & _ID, "", trans.Trans)
               trans.CommitTransaction()
               MsBranchItem = Nothing
               Return _MS_BRANCH_ms_member_id
           End Get
           Set(ByVal value As DataTable)
               _MS_BRANCH_ms_member_id = value
           End Set
       End Property
       Public Property CHILD_MS_MEMBER_CUSTOMER_TYPE_ms_member_id() As DataTable
           Get
               'Child Table Name : MS_MEMBER_CUSTOMER_TYPE Column :ms_member_id
               Dim trans As New LinqDB.ConnectDB.TransactionDB
               Dim MsMemberCustomerTypeItem As New MsMemberCustomerTypeLinqDB
               _MS_MEMBER_CUSTOMER_TYPE_ms_member_id = MsMemberCustomerTypeItem.GetDataList("ms_member_id = " & _ID, "", trans.Trans)
               trans.CommitTransaction()
               MsMemberCustomerTypeItem = Nothing
               Return _MS_MEMBER_CUSTOMER_TYPE_ms_member_id
           End Get
           Set(ByVal value As DataTable)
               _MS_MEMBER_CUSTOMER_TYPE_ms_member_id = value
           End Set
       End Property
       Public Property CHILD_MS_MEMBER_SERVICE_ms_member_id() As DataTable
           Get
               'Child Table Name : MS_MEMBER_SERVICE Column :ms_member_id
               Dim trans As New LinqDB.ConnectDB.TransactionDB
               Dim MsMemberServiceItem As New MsMemberServiceLinqDB
               _MS_MEMBER_SERVICE_ms_member_id = MsMemberServiceItem.GetDataList("ms_member_id = " & _ID, "", trans.Trans)
               trans.CommitTransaction()
               MsMemberServiceItem = Nothing
               Return _MS_MEMBER_SERVICE_ms_member_id
           End Get
           Set(ByVal value As DataTable)
               _MS_MEMBER_SERVICE_ms_member_id = value
           End Set
       End Property
       Public Property CHILD_MS_MEMBER_SYSCONFIG_ms_member_id() As DataTable
           Get
               'Child Table Name : MS_MEMBER_SYSCONFIG Column :ms_member_id
               Dim trans As New LinqDB.ConnectDB.TransactionDB
               Dim MsMemberSysconfigItem As New MsMemberSysconfigLinqDB
               _MS_MEMBER_SYSCONFIG_ms_member_id = MsMemberSysconfigItem.GetDataList("ms_member_id = " & _ID, "", trans.Trans)
               trans.CommitTransaction()
               MsMemberSysconfigItem = Nothing
               Return _MS_MEMBER_SYSCONFIG_ms_member_id
           End Get
           Set(ByVal value As DataTable)
               _MS_MEMBER_SYSCONFIG_ms_member_id = value
           End Set
       End Property
    End Class
End Namespace
