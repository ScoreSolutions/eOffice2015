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
    'Represents a transaction for MS_BRANCH table LinqDB.
    '[Create by  on September, 26 2014]
    Public Class MsBranchLinqDB
        Public sub MsBranchLinqDB()

        End Sub 
        ' MS_BRANCH
        Const _tableName As String = "MS_BRANCH"
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
        Dim _BRANCH_CODE As String = ""
        Dim _BRANCH_NAME_EN As String = ""
        Dim _BRANCH_NAME_TH As String = ""
        Dim _ADDR_NAME As  String  = ""
        Dim _ADDR_NO As  String  = ""
        Dim _ADDR_MOO As  String  = ""
        Dim _ADDR_SOI As  String  = ""
        Dim _ADDR_ROAD As  String  = ""
        Dim _MS_SUBDISTRICT_ID As Long = 0
        Dim _POST_CODE As  String  = ""
        Dim _TEL_NO As  String  = ""
        Dim _FAX_NO As  String  = ""
        Dim _MOBILE_NO As  String  = ""
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
        <Column(Storage:="_BRANCH_CODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property BRANCH_CODE() As String
            Get
                Return _BRANCH_CODE
            End Get
            Set(ByVal value As String)
               _BRANCH_CODE = value
            End Set
        End Property 
        <Column(Storage:="_BRANCH_NAME_EN", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property BRANCH_NAME_EN() As String
            Get
                Return _BRANCH_NAME_EN
            End Get
            Set(ByVal value As String)
               _BRANCH_NAME_EN = value
            End Set
        End Property 
        <Column(Storage:="_BRANCH_NAME_TH", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property BRANCH_NAME_TH() As String
            Get
                Return _BRANCH_NAME_TH
            End Get
            Set(ByVal value As String)
               _BRANCH_NAME_TH = value
            End Set
        End Property 
        <Column(Storage:="_ADDR_NAME", DbType:="VarChar(255)")>  _
        Public Property ADDR_NAME() As  String 
            Get
                Return _ADDR_NAME
            End Get
            Set(ByVal value As  String )
               _ADDR_NAME = value
            End Set
        End Property 
        <Column(Storage:="_ADDR_NO", DbType:="VarChar(50)")>  _
        Public Property ADDR_NO() As  String 
            Get
                Return _ADDR_NO
            End Get
            Set(ByVal value As  String )
               _ADDR_NO = value
            End Set
        End Property 
        <Column(Storage:="_ADDR_MOO", DbType:="VarChar(50)")>  _
        Public Property ADDR_MOO() As  String 
            Get
                Return _ADDR_MOO
            End Get
            Set(ByVal value As  String )
               _ADDR_MOO = value
            End Set
        End Property 
        <Column(Storage:="_ADDR_SOI", DbType:="VarChar(100)")>  _
        Public Property ADDR_SOI() As  String 
            Get
                Return _ADDR_SOI
            End Get
            Set(ByVal value As  String )
               _ADDR_SOI = value
            End Set
        End Property 
        <Column(Storage:="_ADDR_ROAD", DbType:="VarChar(100)")>  _
        Public Property ADDR_ROAD() As  String 
            Get
                Return _ADDR_ROAD
            End Get
            Set(ByVal value As  String )
               _ADDR_ROAD = value
            End Set
        End Property 
        <Column(Storage:="_MS_SUBDISTRICT_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_SUBDISTRICT_ID() As Long
            Get
                Return _MS_SUBDISTRICT_ID
            End Get
            Set(ByVal value As Long)
               _MS_SUBDISTRICT_ID = value
            End Set
        End Property 
        <Column(Storage:="_POST_CODE", DbType:="VarChar(5)")>  _
        Public Property POST_CODE() As  String 
            Get
                Return _POST_CODE
            End Get
            Set(ByVal value As  String )
               _POST_CODE = value
            End Set
        End Property 
        <Column(Storage:="_TEL_NO", DbType:="VarChar(100)")>  _
        Public Property TEL_NO() As  String 
            Get
                Return _TEL_NO
            End Get
            Set(ByVal value As  String )
               _TEL_NO = value
            End Set
        End Property 
        <Column(Storage:="_FAX_NO", DbType:="VarChar(100)")>  _
        Public Property FAX_NO() As  String 
            Get
                Return _FAX_NO
            End Get
            Set(ByVal value As  String )
               _FAX_NO = value
            End Set
        End Property 
        <Column(Storage:="_MOBILE_NO", DbType:="VarChar(100)")>  _
        Public Property MOBILE_NO() As  String 
            Get
                Return _MOBILE_NO
            End Get
            Set(ByVal value As  String )
               _MOBILE_NO = value
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
            _BRANCH_CODE = ""
            _BRANCH_NAME_EN = ""
            _BRANCH_NAME_TH = ""
            _ADDR_NAME = ""
            _ADDR_NO = ""
            _ADDR_MOO = ""
            _ADDR_SOI = ""
            _ADDR_ROAD = ""
            _MS_SUBDISTRICT_ID = 0
            _POST_CODE = ""
            _TEL_NO = ""
            _FAX_NO = ""
            _MOBILE_NO = ""
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


        '/// Returns an indication whether the current data is inserted into MS_BRANCH table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_BRANCH table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_BRANCH table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from MS_BRANCH table successfully.
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


        '/// Returns an indication whether the record of MS_BRANCH by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of MS_BRANCH by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As MsBranchLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of MS_BRANCH by specified BRANCH_CODE_MS_MEMBER_ID key is retrieved successfully.
        '/// <param name=cBRANCH_CODE_MS_MEMBER_ID>The BRANCH_CODE_MS_MEMBER_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByBRANCH_CODE_MS_MEMBER_ID(cBRANCH_CODE As String, cMS_MEMBER_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("BRANCH_CODE = " & DB.SetString(cBRANCH_CODE) & " AND MS_MEMBER_ID = " & DB.SetDouble(cMS_MEMBER_ID), trans)
        End Function

        '/// Returns an duplicate data record of MS_BRANCH by specified BRANCH_CODE_MS_MEMBER_ID key is retrieved successfully.
        '/// <param name=cBRANCH_CODE_MS_MEMBER_ID>The BRANCH_CODE_MS_MEMBER_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByBRANCH_CODE_MS_MEMBER_ID(cBRANCH_CODE As String, cMS_MEMBER_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("BRANCH_CODE = " & DB.SetString(cBRANCH_CODE) & " AND MS_MEMBER_ID = " & DB.SetDouble(cMS_MEMBER_ID) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MS_BRANCH by specified BRANCH_NAME_EN_MS_MEMBER_ID key is retrieved successfully.
        '/// <param name=cBRANCH_NAME_EN_MS_MEMBER_ID>The BRANCH_NAME_EN_MS_MEMBER_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByBRANCH_NAME_EN_MS_MEMBER_ID(cBRANCH_NAME_EN As String, cMS_MEMBER_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("BRANCH_NAME_EN = " & DB.SetString(cBRANCH_NAME_EN) & " AND MS_MEMBER_ID = " & DB.SetDouble(cMS_MEMBER_ID), trans)
        End Function

        '/// Returns an duplicate data record of MS_BRANCH by specified BRANCH_NAME_EN_MS_MEMBER_ID key is retrieved successfully.
        '/// <param name=cBRANCH_NAME_EN_MS_MEMBER_ID>The BRANCH_NAME_EN_MS_MEMBER_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByBRANCH_NAME_EN_MS_MEMBER_ID(cBRANCH_NAME_EN As String, cMS_MEMBER_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("BRANCH_NAME_EN = " & DB.SetString(cBRANCH_NAME_EN) & " AND MS_MEMBER_ID = " & DB.SetDouble(cMS_MEMBER_ID) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MS_BRANCH by specified BRANCH_NAME_TH_MS_MEMBER_ID key is retrieved successfully.
        '/// <param name=cBRANCH_NAME_TH_MS_MEMBER_ID>The BRANCH_NAME_TH_MS_MEMBER_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByBRANCH_NAME_TH_MS_MEMBER_ID(cBRANCH_NAME_TH As String, cMS_MEMBER_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("BRANCH_NAME_TH = " & DB.SetString(cBRANCH_NAME_TH) & " AND MS_MEMBER_ID = " & DB.SetDouble(cMS_MEMBER_ID), trans)
        End Function

        '/// Returns an duplicate data record of MS_BRANCH by specified BRANCH_NAME_TH_MS_MEMBER_ID key is retrieved successfully.
        '/// <param name=cBRANCH_NAME_TH_MS_MEMBER_ID>The BRANCH_NAME_TH_MS_MEMBER_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByBRANCH_NAME_TH_MS_MEMBER_ID(cBRANCH_NAME_TH As String, cMS_MEMBER_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("BRANCH_NAME_TH = " & DB.SetString(cBRANCH_NAME_TH) & " AND MS_MEMBER_ID = " & DB.SetDouble(cMS_MEMBER_ID) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MS_BRANCH by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into MS_BRANCH table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_BRANCH table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_BRANCH table successfully.
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
            Dim cmbParam(19) As SqlParameter
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

            cmbParam(6) = New SqlParameter("@_BRANCH_CODE", SqlDbType.VarChar)
            cmbParam(6).Value = _BRANCH_CODE

            cmbParam(7) = New SqlParameter("@_BRANCH_NAME_EN", SqlDbType.VarChar)
            cmbParam(7).Value = _BRANCH_NAME_EN

            cmbParam(8) = New SqlParameter("@_BRANCH_NAME_TH", SqlDbType.VarChar)
            cmbParam(8).Value = _BRANCH_NAME_TH

            cmbParam(9) = New SqlParameter("@_ADDR_NAME", SqlDbType.VarChar)
            cmbParam(9).Value = _ADDR_NAME

            cmbParam(10) = New SqlParameter("@_ADDR_NO", SqlDbType.VarChar)
            cmbParam(10).Value = _ADDR_NO

            cmbParam(11) = New SqlParameter("@_ADDR_MOO", SqlDbType.VarChar)
            cmbParam(11).Value = _ADDR_MOO

            cmbParam(12) = New SqlParameter("@_ADDR_SOI", SqlDbType.VarChar)
            cmbParam(12).Value = _ADDR_SOI

            cmbParam(13) = New SqlParameter("@_ADDR_ROAD", SqlDbType.VarChar)
            cmbParam(13).Value = _ADDR_ROAD

            cmbParam(14) = New SqlParameter("@_MS_SUBDISTRICT_ID", SqlDbType.BigInt)
            cmbParam(14).Value = _MS_SUBDISTRICT_ID

            cmbParam(15) = New SqlParameter("@_POST_CODE", SqlDbType.VarChar)
            cmbParam(15).Value = _POST_CODE

            cmbParam(16) = New SqlParameter("@_TEL_NO", SqlDbType.VarChar)
            cmbParam(16).Value = _TEL_NO

            cmbParam(17) = New SqlParameter("@_FAX_NO", SqlDbType.VarChar)
            cmbParam(17).Value = _FAX_NO

            cmbParam(18) = New SqlParameter("@_MOBILE_NO", SqlDbType.VarChar)
            cmbParam(18).Value = _MOBILE_NO

            cmbParam(19) = New SqlParameter("@_ACTIVE_STATUS", SqlDbType.Char)
            cmbParam(19).Value = _ACTIVE_STATUS

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of MS_BRANCH by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("branch_code")) = False Then _branch_code = Rdr("branch_code").ToString()
                        If Convert.IsDBNull(Rdr("branch_name_en")) = False Then _branch_name_en = Rdr("branch_name_en").ToString()
                        If Convert.IsDBNull(Rdr("branch_name_th")) = False Then _branch_name_th = Rdr("branch_name_th").ToString()
                        If Convert.IsDBNull(Rdr("addr_name")) = False Then _addr_name = Rdr("addr_name").ToString()
                        If Convert.IsDBNull(Rdr("addr_no")) = False Then _addr_no = Rdr("addr_no").ToString()
                        If Convert.IsDBNull(Rdr("addr_moo")) = False Then _addr_moo = Rdr("addr_moo").ToString()
                        If Convert.IsDBNull(Rdr("addr_soi")) = False Then _addr_soi = Rdr("addr_soi").ToString()
                        If Convert.IsDBNull(Rdr("addr_road")) = False Then _addr_road = Rdr("addr_road").ToString()
                        If Convert.IsDBNull(Rdr("ms_subdistrict_id")) = False Then _ms_subdistrict_id = Convert.ToInt64(Rdr("ms_subdistrict_id"))
                        If Convert.IsDBNull(Rdr("post_code")) = False Then _post_code = Rdr("post_code").ToString()
                        If Convert.IsDBNull(Rdr("tel_no")) = False Then _tel_no = Rdr("tel_no").ToString()
                        If Convert.IsDBNull(Rdr("fax_no")) = False Then _fax_no = Rdr("fax_no").ToString()
                        If Convert.IsDBNull(Rdr("mobile_no")) = False Then _mobile_no = Rdr("mobile_no").ToString()
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


        '/// Returns an indication whether the record of MS_BRANCH by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As MsBranchLinqDB
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
                        If Convert.IsDBNull(Rdr("branch_code")) = False Then _branch_code = Rdr("branch_code").ToString()
                        If Convert.IsDBNull(Rdr("branch_name_en")) = False Then _branch_name_en = Rdr("branch_name_en").ToString()
                        If Convert.IsDBNull(Rdr("branch_name_th")) = False Then _branch_name_th = Rdr("branch_name_th").ToString()
                        If Convert.IsDBNull(Rdr("addr_name")) = False Then _addr_name = Rdr("addr_name").ToString()
                        If Convert.IsDBNull(Rdr("addr_no")) = False Then _addr_no = Rdr("addr_no").ToString()
                        If Convert.IsDBNull(Rdr("addr_moo")) = False Then _addr_moo = Rdr("addr_moo").ToString()
                        If Convert.IsDBNull(Rdr("addr_soi")) = False Then _addr_soi = Rdr("addr_soi").ToString()
                        If Convert.IsDBNull(Rdr("addr_road")) = False Then _addr_road = Rdr("addr_road").ToString()
                        If Convert.IsDBNull(Rdr("ms_subdistrict_id")) = False Then _ms_subdistrict_id = Convert.ToInt64(Rdr("ms_subdistrict_id"))
                        If Convert.IsDBNull(Rdr("post_code")) = False Then _post_code = Rdr("post_code").ToString()
                        If Convert.IsDBNull(Rdr("tel_no")) = False Then _tel_no = Rdr("tel_no").ToString()
                        If Convert.IsDBNull(Rdr("fax_no")) = False Then _fax_no = Rdr("fax_no").ToString()
                        If Convert.IsDBNull(Rdr("mobile_no")) = False Then _mobile_no = Rdr("mobile_no").ToString()
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


        'Get Insert Statement for table MS_BRANCH
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_MEMBER_ID, BRANCH_CODE, BRANCH_NAME_EN, BRANCH_NAME_TH, ADDR_NAME, ADDR_NO, ADDR_MOO, ADDR_SOI, ADDR_ROAD, MS_SUBDISTRICT_ID, POST_CODE, TEL_NO, FAX_NO, MOBILE_NO, ACTIVE_STATUS)"
                Sql += " VALUES("
                sql += "@_ID" & ", "
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_UPDATED_BY" & ", "
                sql += "@_UPDATED_DATE" & ", "
                sql += "@_MS_MEMBER_ID" & ", "
                sql += "@_BRANCH_CODE" & ", "
                sql += "@_BRANCH_NAME_EN" & ", "
                sql += "@_BRANCH_NAME_TH" & ", "
                sql += "@_ADDR_NAME" & ", "
                sql += "@_ADDR_NO" & ", "
                sql += "@_ADDR_MOO" & ", "
                sql += "@_ADDR_SOI" & ", "
                sql += "@_ADDR_ROAD" & ", "
                sql += "@_MS_SUBDISTRICT_ID" & ", "
                sql += "@_POST_CODE" & ", "
                sql += "@_TEL_NO" & ", "
                sql += "@_FAX_NO" & ", "
                sql += "@_MOBILE_NO" & ", "
                sql += "@_ACTIVE_STATUS"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table MS_BRANCH
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATED_BY = " & "@_CREATED_BY" & ", "
                Sql += "CREATED_DATE = " & "@_CREATED_DATE" & ", "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "MS_MEMBER_ID = " & "@_MS_MEMBER_ID" & ", "
                Sql += "BRANCH_CODE = " & "@_BRANCH_CODE" & ", "
                Sql += "BRANCH_NAME_EN = " & "@_BRANCH_NAME_EN" & ", "
                Sql += "BRANCH_NAME_TH = " & "@_BRANCH_NAME_TH" & ", "
                Sql += "ADDR_NAME = " & "@_ADDR_NAME" & ", "
                Sql += "ADDR_NO = " & "@_ADDR_NO" & ", "
                Sql += "ADDR_MOO = " & "@_ADDR_MOO" & ", "
                Sql += "ADDR_SOI = " & "@_ADDR_SOI" & ", "
                Sql += "ADDR_ROAD = " & "@_ADDR_ROAD" & ", "
                Sql += "MS_SUBDISTRICT_ID = " & "@_MS_SUBDISTRICT_ID" & ", "
                Sql += "POST_CODE = " & "@_POST_CODE" & ", "
                Sql += "TEL_NO = " & "@_TEL_NO" & ", "
                Sql += "FAX_NO = " & "@_FAX_NO" & ", "
                Sql += "MOBILE_NO = " & "@_MOBILE_NO" & ", "
                Sql += "ACTIVE_STATUS = " & "@_ACTIVE_STATUS" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table MS_BRANCH
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table MS_BRANCH
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_MEMBER_ID, BRANCH_CODE, BRANCH_NAME_EN, BRANCH_NAME_TH, ADDR_NAME, ADDR_NO, ADDR_MOO, ADDR_SOI, ADDR_ROAD, MS_SUBDISTRICT_ID, POST_CODE, TEL_NO, FAX_NO, MOBILE_NO, ACTIVE_STATUS FROM " & tableName
                Return Sql
            End Get
        End Property


            'Define Child Table 

       Dim _MS_APPOINTMENT_SCHEDULE_ms_branch_id As DataTable
       Dim _MS_BRANCH_CONFIG_ms_branch_id As DataTable
       Dim _MS_BRANCH_DB_CONFIG_ms_branch_id As DataTable

       Public Property CHILD_MS_APPOINTMENT_SCHEDULE_ms_branch_id() As DataTable
           Get
               'Child Table Name : MS_APPOINTMENT_SCHEDULE Column :ms_branch_id
               Dim trans As New LinqDB.ConnectDB.TransactionDB
               Dim MsAppointmentScheduleItem As New MsAppointmentScheduleLinqDB
               _MS_APPOINTMENT_SCHEDULE_ms_branch_id = MsAppointmentScheduleItem.GetDataList("ms_branch_id = " & _ID, "", trans.Trans)
               trans.CommitTransaction()
               MsAppointmentScheduleItem = Nothing
               Return _MS_APPOINTMENT_SCHEDULE_ms_branch_id
           End Get
           Set(ByVal value As DataTable)
               _MS_APPOINTMENT_SCHEDULE_ms_branch_id = value
           End Set
       End Property
       Public Property CHILD_MS_BRANCH_CONFIG_ms_branch_id() As DataTable
           Get
               'Child Table Name : MS_BRANCH_CONFIG Column :ms_branch_id
               Dim trans As New LinqDB.ConnectDB.TransactionDB
               Dim MsBranchConfigItem As New MsBranchConfigLinqDB
               _MS_BRANCH_CONFIG_ms_branch_id = MsBranchConfigItem.GetDataList("ms_branch_id = " & _ID, "", trans.Trans)
               trans.CommitTransaction()
               MsBranchConfigItem = Nothing
               Return _MS_BRANCH_CONFIG_ms_branch_id
           End Get
           Set(ByVal value As DataTable)
               _MS_BRANCH_CONFIG_ms_branch_id = value
           End Set
       End Property
       Public Property CHILD_MS_BRANCH_DB_CONFIG_ms_branch_id() As DataTable
           Get
               'Child Table Name : MS_BRANCH_DB_CONFIG Column :ms_branch_id
               Dim trans As New LinqDB.ConnectDB.TransactionDB
               Dim MsBranchDbConfigItem As New MsBranchDbConfigLinqDB
               _MS_BRANCH_DB_CONFIG_ms_branch_id = MsBranchDbConfigItem.GetDataList("ms_branch_id = " & _ID, "", trans.Trans)
               trans.CommitTransaction()
               MsBranchDbConfigItem = Nothing
               Return _MS_BRANCH_DB_CONFIG_ms_branch_id
           End Get
           Set(ByVal value As DataTable)
               _MS_BRANCH_DB_CONFIG_ms_branch_id = value
           End Set
       End Property
    End Class
End Namespace
