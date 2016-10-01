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
    'Represents a transaction for MS_MEMBER_SERVICE table LinqDB.
    '[Create by  on September, 26 2014]
    Public Class MsMemberServiceLinqDB
        Public sub MsMemberServiceLinqDB()

        End Sub 
        ' MS_MEMBER_SERVICE
        Const _tableName As String = "MS_MEMBER_SERVICE"
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
        Dim _MS_MEMBER_ID As Long = 0
        Dim _SERVICE_CODE As String = ""
        Dim _SERVICE_NAME_EN As String = ""
        Dim _SERVICE_NAME_TH As String = ""
        Dim _ORDER_SEQ As Long = 0
        Dim _TXT_QUEUE As  String  = ""
        Dim _ACTIVE_STATUS As Char = "Y"

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
        <Column(Storage:="_MS_MEMBER_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_MEMBER_ID() As Long
            Get
                Return _MS_MEMBER_ID
            End Get
            Set(ByVal value As Long)
               _MS_MEMBER_ID = value
            End Set
        End Property 
        <Column(Storage:="_SERVICE_CODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property SERVICE_CODE() As String
            Get
                Return _SERVICE_CODE
            End Get
            Set(ByVal value As String)
               _SERVICE_CODE = value
            End Set
        End Property 
        <Column(Storage:="_SERVICE_NAME_EN", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property SERVICE_NAME_EN() As String
            Get
                Return _SERVICE_NAME_EN
            End Get
            Set(ByVal value As String)
               _SERVICE_NAME_EN = value
            End Set
        End Property 
        <Column(Storage:="_SERVICE_NAME_TH", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property SERVICE_NAME_TH() As String
            Get
                Return _SERVICE_NAME_TH
            End Get
            Set(ByVal value As String)
               _SERVICE_NAME_TH = value
            End Set
        End Property 
        <Column(Storage:="_ORDER_SEQ", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property ORDER_SEQ() As Long
            Get
                Return _ORDER_SEQ
            End Get
            Set(ByVal value As Long)
               _ORDER_SEQ = value
            End Set
        End Property 
        <Column(Storage:="_TXT_QUEUE", DbType:="VarChar(1)")>  _
        Public Property TXT_QUEUE() As  String 
            Get
                Return _TXT_QUEUE
            End Get
            Set(ByVal value As  String )
               _TXT_QUEUE = value
            End Set
        End Property 
        <Column(Storage:="_ACTIVE_STATUS", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ACTIVE_STATUS() As Char
            Get
                Return _ACTIVE_STATUS
            End Get
            Set(ByVal value As Char)
               _ACTIVE_STATUS = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _MS_MEMBER_ID = 0
            _SERVICE_CODE = ""
            _SERVICE_NAME_EN = ""
            _SERVICE_NAME_TH = ""
            _ORDER_SEQ = 0
            _TXT_QUEUE = ""
            _ACTIVE_STATUS = ""
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


        '/// Returns an indication whether the current data is inserted into MS_MEMBER_SERVICE table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_MEMBER_SERVICE table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_MEMBER_SERVICE table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from MS_MEMBER_SERVICE table successfully.
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


        '/// Returns an indication whether the record of MS_MEMBER_SERVICE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of MS_MEMBER_SERVICE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As MsMemberServiceLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of MS_MEMBER_SERVICE by specified MS_MEMBER_ID_SERVICE_CODE key is retrieved successfully.
        '/// <param name=cMS_MEMBER_ID_SERVICE_CODE>The MS_MEMBER_ID_SERVICE_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMS_MEMBER_ID_SERVICE_CODE(cMS_MEMBER_ID As Long, cSERVICE_CODE As String, trans As SQLTransaction) As Boolean
            Return doChkData("MS_MEMBER_ID = " & DB.SetDouble(cMS_MEMBER_ID) & " AND SERVICE_CODE = " & DB.SetString(cSERVICE_CODE), trans)
        End Function

        '/// Returns an duplicate data record of MS_MEMBER_SERVICE by specified MS_MEMBER_ID_SERVICE_CODE key is retrieved successfully.
        '/// <param name=cMS_MEMBER_ID_SERVICE_CODE>The MS_MEMBER_ID_SERVICE_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMS_MEMBER_ID_SERVICE_CODE(cMS_MEMBER_ID As Long, cSERVICE_CODE As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MS_MEMBER_ID = " & DB.SetDouble(cMS_MEMBER_ID) & " AND SERVICE_CODE = " & DB.SetString(cSERVICE_CODE) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MS_MEMBER_SERVICE by specified MS_MEMBER_ID_SERVICE_NAME_EN key is retrieved successfully.
        '/// <param name=cMS_MEMBER_ID_SERVICE_NAME_EN>The MS_MEMBER_ID_SERVICE_NAME_EN key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMS_MEMBER_ID_SERVICE_NAME_EN(cMS_MEMBER_ID As Long, cSERVICE_NAME_EN As String, trans As SQLTransaction) As Boolean
            Return doChkData("MS_MEMBER_ID = " & DB.SetDouble(cMS_MEMBER_ID) & " AND SERVICE_NAME_EN = " & DB.SetString(cSERVICE_NAME_EN), trans)
        End Function

        '/// Returns an duplicate data record of MS_MEMBER_SERVICE by specified MS_MEMBER_ID_SERVICE_NAME_EN key is retrieved successfully.
        '/// <param name=cMS_MEMBER_ID_SERVICE_NAME_EN>The MS_MEMBER_ID_SERVICE_NAME_EN key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMS_MEMBER_ID_SERVICE_NAME_EN(cMS_MEMBER_ID As Long, cSERVICE_NAME_EN As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MS_MEMBER_ID = " & DB.SetDouble(cMS_MEMBER_ID) & " AND SERVICE_NAME_EN = " & DB.SetString(cSERVICE_NAME_EN) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MS_MEMBER_SERVICE by specified MS_MEMBER_ID_SERVICE_NAME_TH key is retrieved successfully.
        '/// <param name=cMS_MEMBER_ID_SERVICE_NAME_TH>The MS_MEMBER_ID_SERVICE_NAME_TH key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMS_MEMBER_ID_SERVICE_NAME_TH(cMS_MEMBER_ID As Long, cSERVICE_NAME_TH As String, trans As SQLTransaction) As Boolean
            Return doChkData("MS_MEMBER_ID = " & DB.SetDouble(cMS_MEMBER_ID) & " AND SERVICE_NAME_TH = " & DB.SetString(cSERVICE_NAME_TH), trans)
        End Function

        '/// Returns an duplicate data record of MS_MEMBER_SERVICE by specified MS_MEMBER_ID_SERVICE_NAME_TH key is retrieved successfully.
        '/// <param name=cMS_MEMBER_ID_SERVICE_NAME_TH>The MS_MEMBER_ID_SERVICE_NAME_TH key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMS_MEMBER_ID_SERVICE_NAME_TH(cMS_MEMBER_ID As Long, cSERVICE_NAME_TH As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MS_MEMBER_ID = " & DB.SetDouble(cMS_MEMBER_ID) & " AND SERVICE_NAME_TH = " & DB.SetString(cSERVICE_NAME_TH) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MS_MEMBER_SERVICE by specified MS_MEMBER_ID_ORDER_SEQ key is retrieved successfully.
        '/// <param name=cMS_MEMBER_ID_ORDER_SEQ>The MS_MEMBER_ID_ORDER_SEQ key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMS_MEMBER_ID_ORDER_SEQ(cMS_MEMBER_ID As Long, cORDER_SEQ As Integer, trans As SQLTransaction) As Boolean
            Return doChkData("MS_MEMBER_ID = " & DB.SetDouble(cMS_MEMBER_ID) & " AND ORDER_SEQ = " & DB.SetDouble(cORDER_SEQ), trans)
        End Function

        '/// Returns an duplicate data record of MS_MEMBER_SERVICE by specified MS_MEMBER_ID_ORDER_SEQ key is retrieved successfully.
        '/// <param name=cMS_MEMBER_ID_ORDER_SEQ>The MS_MEMBER_ID_ORDER_SEQ key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMS_MEMBER_ID_ORDER_SEQ(cMS_MEMBER_ID As Long, cORDER_SEQ As Integer, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MS_MEMBER_ID = " & DB.SetDouble(cMS_MEMBER_ID) & " AND ORDER_SEQ = " & DB.SetDouble(cORDER_SEQ) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MS_MEMBER_SERVICE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into MS_MEMBER_SERVICE table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_MEMBER_SERVICE table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_MEMBER_SERVICE table successfully.
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

            cmbParam(5) = New SqlParameter("@_MS_MEMBER_ID", SqlDbType.BigInt)
            cmbParam(5).Value = _MS_MEMBER_ID

            cmbParam(6) = New SqlParameter("@_SERVICE_CODE", SqlDbType.VarChar)
            cmbParam(6).Value = _SERVICE_CODE

            cmbParam(7) = New SqlParameter("@_SERVICE_NAME_EN", SqlDbType.VarChar)
            cmbParam(7).Value = _SERVICE_NAME_EN

            cmbParam(8) = New SqlParameter("@_SERVICE_NAME_TH", SqlDbType.VarChar)
            cmbParam(8).Value = _SERVICE_NAME_TH

            cmbParam(9) = New SqlParameter("@_ORDER_SEQ", SqlDbType.Int)
            cmbParam(9).Value = _ORDER_SEQ

            cmbParam(10) = New SqlParameter("@_TXT_QUEUE", SqlDbType.VarChar)
            cmbParam(10).Value = _TXT_QUEUE

            cmbParam(11) = New SqlParameter("@_ACTIVE_STATUS", SqlDbType.Char)
            cmbParam(11).Value = _ACTIVE_STATUS

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of MS_MEMBER_SERVICE by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("ms_member_id")) = False Then _ms_member_id = Convert.ToInt64(Rdr("ms_member_id"))
                        If Convert.IsDBNull(Rdr("service_code")) = False Then _service_code = Rdr("service_code").ToString()
                        If Convert.IsDBNull(Rdr("service_name_en")) = False Then _service_name_en = Rdr("service_name_en").ToString()
                        If Convert.IsDBNull(Rdr("service_name_th")) = False Then _service_name_th = Rdr("service_name_th").ToString()
                        If Convert.IsDBNull(Rdr("order_seq")) = False Then _order_seq = Convert.ToInt32(Rdr("order_seq"))
                        If Convert.IsDBNull(Rdr("txt_queue")) = False Then _txt_queue = Rdr("txt_queue").ToString()
                        If Convert.IsDBNull(Rdr("active_status")) = False Then _active_status = Rdr("active_status").ToString()
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


        '/// Returns an indication whether the record of MS_MEMBER_SERVICE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As MsMemberServiceLinqDB
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
                        If Convert.IsDBNull(Rdr("ms_member_id")) = False Then _ms_member_id = Convert.ToInt64(Rdr("ms_member_id"))
                        If Convert.IsDBNull(Rdr("service_code")) = False Then _service_code = Rdr("service_code").ToString()
                        If Convert.IsDBNull(Rdr("service_name_en")) = False Then _service_name_en = Rdr("service_name_en").ToString()
                        If Convert.IsDBNull(Rdr("service_name_th")) = False Then _service_name_th = Rdr("service_name_th").ToString()
                        If Convert.IsDBNull(Rdr("order_seq")) = False Then _order_seq = Convert.ToInt32(Rdr("order_seq"))
                        If Convert.IsDBNull(Rdr("txt_queue")) = False Then _txt_queue = Rdr("txt_queue").ToString()
                        If Convert.IsDBNull(Rdr("active_status")) = False Then _active_status = Rdr("active_status").ToString()
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


        'Get Insert Statement for table MS_MEMBER_SERVICE
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_MEMBER_ID, SERVICE_CODE, SERVICE_NAME_EN, SERVICE_NAME_TH, ORDER_SEQ, TXT_QUEUE, ACTIVE_STATUS)"
                Sql += " VALUES("
                sql += "@_ID" & ", "
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_UPDATED_BY" & ", "
                sql += "@_UPDATED_DATE" & ", "
                sql += "@_MS_MEMBER_ID" & ", "
                sql += "@_SERVICE_CODE" & ", "
                sql += "@_SERVICE_NAME_EN" & ", "
                sql += "@_SERVICE_NAME_TH" & ", "
                sql += "@_ORDER_SEQ" & ", "
                sql += "@_TXT_QUEUE" & ", "
                sql += "@_ACTIVE_STATUS"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table MS_MEMBER_SERVICE
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATED_BY = " & "@_CREATED_BY" & ", "
                Sql += "CREATED_DATE = " & "@_CREATED_DATE" & ", "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "MS_MEMBER_ID = " & "@_MS_MEMBER_ID" & ", "
                Sql += "SERVICE_CODE = " & "@_SERVICE_CODE" & ", "
                Sql += "SERVICE_NAME_EN = " & "@_SERVICE_NAME_EN" & ", "
                Sql += "SERVICE_NAME_TH = " & "@_SERVICE_NAME_TH" & ", "
                Sql += "ORDER_SEQ = " & "@_ORDER_SEQ" & ", "
                Sql += "TXT_QUEUE = " & "@_TXT_QUEUE" & ", "
                Sql += "ACTIVE_STATUS = " & "@_ACTIVE_STATUS" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table MS_MEMBER_SERVICE
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table MS_MEMBER_SERVICE
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_MEMBER_ID, SERVICE_CODE, SERVICE_NAME_EN, SERVICE_NAME_TH, ORDER_SEQ, TXT_QUEUE, ACTIVE_STATUS FROM " & tableName
                Return Sql
            End Get
        End Property


            'Define Child Table 

       Dim _MS_APPOINTMENT_SERVICE_ms_member_service_id As DataTable
       Dim _TS_APPOINTMENT_JOB_SERVICE_ms_member_service_id As DataTable

       Public Property CHILD_MS_APPOINTMENT_SERVICE_ms_member_service_id() As DataTable
           Get
               'Child Table Name : MS_APPOINTMENT_SERVICE Column :ms_member_service_id
               Dim trans As New LinqDB.ConnectDB.TransactionDB
               Dim MsAppointmentServiceItem As New MsAppointmentServiceLinqDB
               _MS_APPOINTMENT_SERVICE_ms_member_service_id = MsAppointmentServiceItem.GetDataList("ms_member_service_id = " & _ID, "", trans.Trans)
               trans.CommitTransaction()
               MsAppointmentServiceItem = Nothing
               Return _MS_APPOINTMENT_SERVICE_ms_member_service_id
           End Get
           Set(ByVal value As DataTable)
               _MS_APPOINTMENT_SERVICE_ms_member_service_id = value
           End Set
       End Property
       Public Property CHILD_TS_APPOINTMENT_JOB_SERVICE_ms_member_service_id() As DataTable
           Get
               'Child Table Name : TS_APPOINTMENT_JOB_SERVICE Column :ms_member_service_id
               Dim trans As New LinqDB.ConnectDB.TransactionDB
               Dim TsAppointmentJobServiceItem As New TsAppointmentJobServiceLinqDB
               _TS_APPOINTMENT_JOB_SERVICE_ms_member_service_id = TsAppointmentJobServiceItem.GetDataList("ms_member_service_id = " & _ID, "", trans.Trans)
               trans.CommitTransaction()
               TsAppointmentJobServiceItem = Nothing
               Return _TS_APPOINTMENT_JOB_SERVICE_ms_member_service_id
           End Get
           Set(ByVal value As DataTable)
               _TS_APPOINTMENT_JOB_SERVICE_ms_member_service_id = value
           End Set
       End Property
    End Class
End Namespace
