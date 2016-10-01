Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DB = XCS.DAL.Common.Utilities.SqlDB
Imports XCS.Data.Common.Utilities
Imports XCS.Data.Table

Namespace Table
    'Represents a transaction for ISSUE_TRACKING_LOG table DAL.
    '[Create by  on March, 27 2011]
    Public Class IssueTrackingLogDAL
        Public Sub IssueTrackingLogDAL()

        End Sub
        ' ISSUE_TRACKING_LOG
        Const _tableName As String = "TRACKINGLOG_ISSUE_TRACKING_LOG"
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
        Dim _PROJECT_ID As Long = 0
        Dim _LOG_NO As Long = 0
        Dim _REF_REQUEST_NO As String = ""
        Dim _TYPE_ID As Long = 0
        Dim _LOG_DESC As String = ""
        Dim _STATUS_ID As Long = 0
        Dim _PRIORITY As String = ""
        Dim _STATE_ID As Long = 0
        Dim _LOG_INSTANCE As String = ""
        Dim _SCREEN_ID As Long = 0
        Dim _MODULE_ID As Long = 0
        Dim _RAISED_BY As String = ""
        Dim _RAISED_ON As DateTime = New DateTime(1, 1, 1)
        Dim _CHANGE_APPROVE As String = ""
        Dim _COMMENTS As String = ""
        Dim _ASSIGNED_TO As String = ""
        Dim _ASSIGNED_DATE As DateTime = New DateTime(1, 1, 1)
        Dim _EXPECTED_CLOSED_DATE As DateTime = New DateTime(1, 1, 1)
        Dim _CLOSED_BY As String = ""
        Dim _CLOSED_DATE As DateTime = New DateTime(1, 1, 1)
        Dim _ESTIMATE_FIXED_DATE As DateTime = New DateTime(1, 1, 1)
        Dim _RESOLVE_STATUS_ID As Long = 0
        Dim _COMPLEXITY_LEVEL As String = ""
        Dim _RESOLUTION As String = ""
        Dim _RESOLVED_DATE As DateTime = New DateTime(1, 1, 1)
        Dim _RESOLVED_COMMENT As String = ""

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
        Public Property PROJECT_ID() As Long
            Get
                Return _PROJECT_ID
            End Get
            Set(ByVal value As Long)
                _PROJECT_ID = value
            End Set
        End Property
        Public Property LOG_NO() As Long
            Get
                Return _LOG_NO
            End Get
            Set(ByVal value As Long)
                _LOG_NO = value
            End Set
        End Property
        Public Property REF_REQUEST_NO() As String
            Get
                Return _REF_REQUEST_NO
            End Get
            Set(ByVal value As String)
                _REF_REQUEST_NO = value
            End Set
        End Property
        Public Property TYPE_ID() As Long
            Get
                Return _TYPE_ID
            End Get
            Set(ByVal value As Long)
                _TYPE_ID = value
            End Set
        End Property
        Public Property LOG_DESC() As String
            Get
                Return _LOG_DESC
            End Get
            Set(ByVal value As String)
                _LOG_DESC = value
            End Set
        End Property
        Public Property STATUS_ID() As Long
            Get
                Return _STATUS_ID
            End Get
            Set(ByVal value As Long)
                _STATUS_ID = value
            End Set
        End Property
        Public Property PRIORITY() As String
            Get
                Return _PRIORITY
            End Get
            Set(ByVal value As String)
                _PRIORITY = value
            End Set
        End Property
        Public Property STATE_ID() As Long
            Get
                Return _STATE_ID
            End Get
            Set(ByVal value As Long)
                _STATE_ID = value
            End Set
        End Property
        Public Property LOG_INSTANCE() As String
            Get
                Return _LOG_INSTANCE
            End Get
            Set(ByVal value As String)
                _LOG_INSTANCE = value
            End Set
        End Property
        Public Property SCREEN_ID() As Long
            Get
                Return _SCREEN_ID
            End Get
            Set(ByVal value As Long)
                _SCREEN_ID = value
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
        Public Property RAISED_BY() As String
            Get
                Return _RAISED_BY
            End Get
            Set(ByVal value As String)
                _RAISED_BY = value
            End Set
        End Property
        Public Property RAISED_ON() As DateTime
            Get
                Return _RAISED_ON
            End Get
            Set(ByVal value As DateTime)
                _RAISED_ON = value
            End Set
        End Property
        Public Property CHANGE_APPROVE() As String
            Get
                Return _CHANGE_APPROVE
            End Get
            Set(ByVal value As String)
                _CHANGE_APPROVE = value
            End Set
        End Property
        Public Property COMMENTS() As String
            Get
                Return _COMMENTS
            End Get
            Set(ByVal value As String)
                _COMMENTS = value
            End Set
        End Property
        Public Property ASSIGNED_TO() As String
            Get
                Return _ASSIGNED_TO
            End Get
            Set(ByVal value As String)
                _ASSIGNED_TO = value
            End Set
        End Property
        Public Property ASSIGNED_DATE() As DateTime
            Get
                Return _ASSIGNED_DATE
            End Get
            Set(ByVal value As DateTime)
                _ASSIGNED_DATE = value
            End Set
        End Property
        Public Property EXPECTED_CLOSED_DATE() As DateTime
            Get
                Return _EXPECTED_CLOSED_DATE
            End Get
            Set(ByVal value As DateTime)
                _EXPECTED_CLOSED_DATE = value
            End Set
        End Property
        Public Property CLOSED_BY() As String
            Get
                Return _CLOSED_BY
            End Get
            Set(ByVal value As String)
                _CLOSED_BY = value
            End Set
        End Property
        Public Property CLOSED_DATE() As DateTime
            Get
                Return _CLOSED_DATE
            End Get
            Set(ByVal value As DateTime)
                _CLOSED_DATE = value
            End Set
        End Property
        Public Property ESTIMATE_FIXED_DATE() As DateTime
            Get
                Return _ESTIMATE_FIXED_DATE
            End Get
            Set(ByVal value As DateTime)
                _ESTIMATE_FIXED_DATE = value
            End Set
        End Property
        Public Property RESOLVE_STATUS_ID() As Long
            Get
                Return _RESOLVE_STATUS_ID
            End Get
            Set(ByVal value As Long)
                _RESOLVE_STATUS_ID = value
            End Set
        End Property
        Public Property COMPLEXITY_LEVEL() As String
            Get
                Return _COMPLEXITY_LEVEL
            End Get
            Set(ByVal value As String)
                _COMPLEXITY_LEVEL = value
            End Set
        End Property
        Public Property RESOLUTION() As String
            Get
                Return _RESOLUTION
            End Get
            Set(ByVal value As String)
                _RESOLUTION = value
            End Set
        End Property
        Public Property RESOLVED_DATE() As DateTime
            Get
                Return _RESOLVED_DATE
            End Get
            Set(ByVal value As DateTime)
                _RESOLVED_DATE = value
            End Set
        End Property
        Public Property RESOLVED_COMMENT() As String
            Get
                Return _RESOLVED_COMMENT
            End Get
            Set(ByVal value As String)
                _RESOLVED_COMMENT = value
            End Set
        End Property


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_ON = New DateTime(1, 1, 1)
            _UPDATE_BY = ""
            _UPDATE_ON = New DateTime(1, 1, 1)
            _PROJECT_ID = 0
            _LOG_NO = 0
            _REF_REQUEST_NO = ""
            _TYPE_ID = 0
            _LOG_DESC = ""
            _STATUS_ID = 0
            _PRIORITY = ""
            _STATE_ID = 0
            _LOG_INSTANCE = ""
            _SCREEN_ID = 0
            _MODULE_ID = 0
            _RAISED_BY = ""
            _RAISED_ON = New DateTime(1, 1, 1)
            _CHANGE_APPROVE = ""
            _COMMENTS = ""
            _ASSIGNED_TO = ""
            _ASSIGNED_DATE = New DateTime(1, 1, 1)
            _EXPECTED_CLOSED_DATE = New DateTime(1, 1, 1)
            _CLOSED_BY = ""
            _CLOSED_DATE = New DateTime(1, 1, 1)
            _ESTIMATE_FIXED_DATE = New DateTime(1, 1, 1)
            _RESOLVE_STATUS_ID = 0
            _COMPLEXITY_LEVEL = ""
            _RESOLUTION = ""
            _RESOLVED_DATE = New DateTime(1, 1, 1)
            _RESOLVED_COMMENT = ""
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


        '/// Returns an indication whether the current data is inserted into ISSUE_TRACKING_LOG table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _id = DB.GetNextID("id", tableName, trans)
            _CREATE_BY = UserID
            _CREATE_ON = DateTime.Now
            Return doInsert(trans)
        End Function


        '/// Returns an indication whether the current data is updated to ISSUE_TRACKING_LOG table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _UPDATE_BY = UserID
            _UPDATE_ON = DateTime.Now
            Return doUpdate("id = " & DB.SetDouble(_id) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is deleted from ISSUE_TRACKING_LOG table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPK(ByVal trans As SQLTransaction) As Boolean
            Return doDelete("id = " & DB.SetDouble(_id) & " ", trans)
        End Function


        '/// Returns an indication whether the record of ISSUE_TRACKING_LOG by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(ByVal cid As Long, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of ISSUE_TRACKING_LOG by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(ByVal cid As Long, ByVal trans As SQLTransaction) As IssueTrackingLogData
            Return doGetMappingData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is updated to ISSUE_TRACKING_LOG table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByLOG_NO_PROJECT_ID(ByVal cLOG_NO As Long, ByVal cPROJECT_ID As Long, ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _UPDATE_BY = UserID
            _UPDATE_ON = DateTime.Now
            Return doUpdate("LOG_NO = " & DB.SetDouble(cLOG_NO) & " AND PROJECT_ID = " & DB.SetDouble(cPROJECT_ID), trans)
        End Function


        '/// Returns an indication whether the current data is deleted from ISSUE_TRACKING_LOG table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByLOG_NO_PROJECT_ID(ByVal cLOG_NO As Long, ByVal cPROJECT_ID As Long, ByVal trans As SQLTransaction) As Boolean
            Return doDelete("LOG_NO = " & DB.SetDouble(cLOG_NO) & " AND PROJECT_ID = " & DB.SetDouble(cPROJECT_ID), trans)
        End Function


        '/// Returns an indication whether the record of ISSUE_TRACKING_LOG by specified LOG_NO_PROJECT_ID key is retrieved successfully.
        '/// <param name=cLOG_NO_PROJECT_ID>The LOG_NO_PROJECT_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByLOG_NO_PROJECT_ID(ByVal cLOG_NO As Long, ByVal cPROJECT_ID As Long, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("LOG_NO = " & DB.SetDouble(cLOG_NO) & " AND PROJECT_ID = " & DB.SetDouble(cPROJECT_ID), trans)
        End Function

        '/// Returns an indication whether the Data Class of ISSUE_TRACKING_LOG by specified LOG_NO_PROJECT_ID key is retrieved successfully.
        '/// <param name=cLOG_NO_PROJECT_ID>The LOG_NO_PROJECT_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByLOG_NO_PROJECT_ID(ByVal cLOG_NO As Long, ByVal cPROJECT_ID As Long, ByVal trans As SQLTransaction) As IssueTrackingLogData
            Return doGetMappingData("LOG_NO = " & DB.SetDouble(cLOG_NO) & " AND PROJECT_ID = " & DB.SetDouble(cPROJECT_ID), trans)
        End Function

        '/// Returns an indication whether the current data is updated to ISSUE_TRACKING_LOG table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByTYPE_ID(ByVal cTYPE_ID As Long, ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _UPDATE_BY = UserID
            _UPDATE_ON = DateTime.Now
            Return doUpdate("TYPE_ID = " & DB.SetDouble(cTYPE_ID) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is deleted from ISSUE_TRACKING_LOG table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByTYPE_ID(ByVal cTYPE_ID As Long, ByVal trans As SQLTransaction) As Boolean
            Return doDelete("TYPE_ID = " & DB.SetDouble(cTYPE_ID) & " ", trans)
        End Function


        '/// Returns an indication whether the record of ISSUE_TRACKING_LOG by specified TYPE_ID key is retrieved successfully.
        '/// <param name=cTYPE_ID>The TYPE_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByTYPE_ID(ByVal cTYPE_ID As Long, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("TYPE_ID = " & DB.SetDouble(cTYPE_ID) & " ", trans)
        End Function

        '/// Returns an indication whether the Data Class of ISSUE_TRACKING_LOG by specified TYPE_ID key is retrieved successfully.
        '/// <param name=cTYPE_ID>The TYPE_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByTYPE_ID(ByVal cTYPE_ID As Long, ByVal trans As SQLTransaction) As IssueTrackingLogData
            Return doGetMappingData("TYPE_ID = " & DB.SetDouble(cTYPE_ID) & " ", trans)
        End Function

        '/// Returns an indication whether the current data is updated to ISSUE_TRACKING_LOG table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySTATUS_ID(ByVal cSTATUS_ID As Long, ByVal UserID As String, ByVal trans As SQLTransaction) As Boolean
            _UPDATE_BY = UserID
            _UPDATE_ON = DateTime.Now
            Return doUpdate("STATUS_ID = " & DB.SetDouble(cSTATUS_ID) & " ", trans)
        End Function


        '/// Returns an indication whether the current data is deleted from ISSUE_TRACKING_LOG table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteBySTATUS_ID(ByVal cSTATUS_ID As Long, ByVal trans As SQLTransaction) As Boolean
            Return doDelete("STATUS_ID = " & DB.SetDouble(cSTATUS_ID) & " ", trans)
        End Function


        '/// Returns an indication whether the record of ISSUE_TRACKING_LOG by specified STATUS_ID key is retrieved successfully.
        '/// <param name=cSTATUS_ID>The STATUS_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySTATUS_ID(ByVal cSTATUS_ID As Long, ByVal trans As SQLTransaction) As Boolean
            Return doChkData("STATUS_ID = " & DB.SetDouble(cSTATUS_ID) & " ", trans)
        End Function

        '/// Returns an indication whether the Data Class of ISSUE_TRACKING_LOG by specified STATUS_ID key is retrieved successfully.
        '/// <param name=cSTATUS_ID>The STATUS_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataBySTATUS_ID(ByVal cSTATUS_ID As Long, ByVal trans As SQLTransaction) As IssueTrackingLogData
            Return doGetMappingData("STATUS_ID = " & DB.SetDouble(cSTATUS_ID) & " ", trans)
        End Function

        '/// Returns an indication whether the record of ISSUE_TRACKING_LOG by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(ByVal whText As String, ByVal trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into ISSUE_TRACKING_LOG table successfully.
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


        '/// Returns an indication whether the current data is updated to ISSUE_TRACKING_LOG table successfully.
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


        '/// Returns an indication whether the current data is deleted from ISSUE_TRACKING_LOG table successfully.
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


        '/// Returns an indication whether the record of ISSUE_TRACKING_LOG by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("project_id")) = False Then _project_id = Convert.ToInt64(Rdr("project_id"))
                        If Convert.IsDBNull(Rdr("log_no")) = False Then _LOG_NO = Convert.ToInt64(Rdr("log_no"))
                        If Convert.IsDBNull(Rdr("ref_request_no")) = False Then _REF_REQUEST_NO = Rdr("ref_request_no").ToString
                        If Convert.IsDBNull(Rdr("type_id")) = False Then _type_id = Convert.ToInt64(Rdr("type_id"))
                        If Convert.IsDBNull(Rdr("log_desc")) = False Then _log_desc = Rdr("log_desc").ToString()
                        If Convert.IsDBNull(Rdr("status_id")) = False Then _status_id = Convert.ToInt64(Rdr("status_id"))
                        If Convert.IsDBNull(Rdr("priority")) = False Then _priority = Rdr("priority").ToString()
                        If Convert.IsDBNull(Rdr("state_id")) = False Then _state_id = Convert.ToInt64(Rdr("state_id"))
                        If Convert.IsDBNull(Rdr("log_instance")) = False Then _log_instance = Rdr("log_instance").ToString()
                        If Convert.IsDBNull(Rdr("screen_id")) = False Then _screen_id = Convert.ToInt64(Rdr("screen_id"))
                        If Convert.IsDBNull(Rdr("module_id")) = False Then _module_id = Convert.ToInt64(Rdr("module_id"))
                        If Convert.IsDBNull(Rdr("raised_by")) = False Then _raised_by = Rdr("raised_by").ToString()
                        If Convert.IsDBNull(Rdr("raised_on")) = False Then _raised_on = Convert.ToDateTime(Rdr("raised_on"))
                        If Convert.IsDBNull(Rdr("change_approve")) = False Then _change_approve = Rdr("change_approve").ToString()
                        If Convert.IsDBNull(Rdr("comments")) = False Then _comments = Rdr("comments").ToString()
                        If Convert.IsDBNull(Rdr("assigned_to")) = False Then _assigned_to = Rdr("assigned_to").ToString()
                        If Convert.IsDBNull(Rdr("assigned_date")) = False Then _assigned_date = Convert.ToDateTime(Rdr("assigned_date"))
                        If Convert.IsDBNull(Rdr("expected_closed_date")) = False Then _expected_closed_date = Convert.ToDateTime(Rdr("expected_closed_date"))
                        If Convert.IsDBNull(Rdr("closed_by")) = False Then _closed_by = Rdr("closed_by").ToString()
                        If Convert.IsDBNull(Rdr("closed_date")) = False Then _closed_date = Convert.ToDateTime(Rdr("closed_date"))
                        If Convert.IsDBNull(Rdr("estimate_fixed_date")) = False Then _estimate_fixed_date = Convert.ToDateTime(Rdr("estimate_fixed_date"))
                        If Convert.IsDBNull(Rdr("resolve_status_id")) = False Then _resolve_status_id = Convert.ToInt64(Rdr("resolve_status_id"))
                        If Convert.IsDBNull(Rdr("complexity_level")) = False Then _complexity_level = Rdr("complexity_level").ToString()
                        If Convert.IsDBNull(Rdr("resolution")) = False Then _resolution = Rdr("resolution").ToString()
                        If Convert.IsDBNull(Rdr("resolved_date")) = False Then _resolved_date = Convert.ToDateTime(Rdr("resolved_date"))
                        If Convert.IsDBNull(Rdr("resolved_comment")) = False Then _resolved_comment = Rdr("resolved_comment").ToString()
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
        '/// Returns an indication whether the Class Data of ISSUE_TRACKING_LOG by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingData(ByVal ret As IssueTrackingLogData, ByVal RDr As DataRow) As IssueTrackingLogData
            If Convert.IsDBNull(Rdr("id")) = False Then ret.ID = Convert.ToInt64(Rdr("id"))
            If Convert.IsDBNull(Rdr("create_by")) = False Then ret.CREATE_BY = Rdr("create_by").ToString()
            If Convert.IsDBNull(Rdr("create_on")) = False Then ret.CREATE_ON = Convert.ToDateTime(Rdr("create_on"))
            If Convert.IsDBNull(Rdr("update_by")) = False Then ret.UPDATE_BY = Rdr("update_by").ToString()
            If Convert.IsDBNull(Rdr("update_on")) = False Then ret.UPDATE_ON = Convert.ToDateTime(Rdr("update_on"))
            If Convert.IsDBNull(Rdr("project_id")) = False Then ret.PROJECT_ID = Convert.ToInt64(Rdr("project_id"))
            If Convert.IsDBNull(RDr("log_no")) = False Then ret.LOG_NO = Convert.ToInt64(RDr("log_no"))
            If Convert.IsDBNull(RDr("ref_request_no")) = False Then ret.REF_REQUEST_NO = RDr("ref_request_no").ToString
            If Convert.IsDBNull(Rdr("type_id")) = False Then ret.TYPE_ID = Convert.ToInt64(Rdr("type_id"))
            If Convert.IsDBNull(Rdr("log_desc")) = False Then ret.LOG_DESC = Rdr("log_desc").ToString()
            If Convert.IsDBNull(Rdr("status_id")) = False Then ret.STATUS_ID = Convert.ToInt64(Rdr("status_id"))
            If Convert.IsDBNull(Rdr("priority")) = False Then ret.PRIORITY = Rdr("priority").ToString()
            If Convert.IsDBNull(Rdr("state_id")) = False Then ret.STATE_ID = Convert.ToInt64(Rdr("state_id"))
            If Convert.IsDBNull(Rdr("log_instance")) = False Then ret.LOG_INSTANCE = Rdr("log_instance").ToString()
            If Convert.IsDBNull(Rdr("screen_id")) = False Then ret.SCREEN_ID = Convert.ToInt64(Rdr("screen_id"))
            If Convert.IsDBNull(Rdr("module_id")) = False Then ret.MODULE_ID = Convert.ToInt64(Rdr("module_id"))
            If Convert.IsDBNull(Rdr("raised_by")) = False Then ret.RAISED_BY = Rdr("raised_by").ToString()
            If Convert.IsDBNull(Rdr("raised_on")) = False Then ret.RAISED_ON = Convert.ToDateTime(Rdr("raised_on"))
            If Convert.IsDBNull(Rdr("change_approve")) = False Then ret.CHANGE_APPROVE = Rdr("change_approve").ToString()
            If Convert.IsDBNull(Rdr("comments")) = False Then ret.COMMENTS = Rdr("comments").ToString()
            If Convert.IsDBNull(Rdr("assigned_to")) = False Then ret.ASSIGNED_TO = Rdr("assigned_to").ToString()
            If Convert.IsDBNull(Rdr("assigned_date")) = False Then ret.ASSIGNED_DATE = Convert.ToDateTime(Rdr("assigned_date"))
            If Convert.IsDBNull(Rdr("expected_closed_date")) = False Then ret.EXPECTED_CLOSED_DATE = Convert.ToDateTime(Rdr("expected_closed_date"))
            If Convert.IsDBNull(Rdr("closed_by")) = False Then ret.CLOSED_BY = Rdr("closed_by").ToString()
            If Convert.IsDBNull(Rdr("closed_date")) = False Then ret.CLOSED_DATE = Convert.ToDateTime(Rdr("closed_date"))
            If Convert.IsDBNull(Rdr("estimate_fixed_date")) = False Then ret.ESTIMATE_FIXED_DATE = Convert.ToDateTime(Rdr("estimate_fixed_date"))
            If Convert.IsDBNull(Rdr("resolve_status_id")) = False Then ret.RESOLVE_STATUS_ID = Convert.ToInt64(Rdr("resolve_status_id"))
            If Convert.IsDBNull(Rdr("complexity_level")) = False Then ret.COMPLEXITY_LEVEL = Rdr("complexity_level").ToString()
            If Convert.IsDBNull(Rdr("resolution")) = False Then ret.RESOLUTION = Rdr("resolution").ToString()
            If Convert.IsDBNull(Rdr("resolved_date")) = False Then ret.RESOLVED_DATE = Convert.ToDateTime(Rdr("resolved_date"))
            If Convert.IsDBNull(Rdr("resolved_comment")) = False Then ret.RESOLVED_COMMENT = Rdr("resolved_comment").ToString()
            Return ret
        End Function


        '/// Returns an indication whether the record of ISSUE_TRACKING_LOG by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetMappingData(ByVal whText As String, ByVal trans As SQLTransaction) As IssueTrackingLogData
            ClearData()
            _haveData = False
            Dim ret As New IssueTrackingLogData
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


        'Get Insert Statement for table ISSUE_TRACKING_LOG
        Private ReadOnly Property SqlInsert() As String
            Get
                Dim Sql As String = ""
                Sql += "INSERT INTO " & TableName & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, PROJECT_ID, LOG_NO, REF_REQUEST_NO, TYPE_ID, LOG_DESC, STATUS_ID, PRIORITY, STATE_ID, LOG_INSTANCE, SCREEN_ID, MODULE_ID, RAISED_BY, RAISED_ON, CHANGE_APPROVE, COMMENTS, ASSIGNED_TO, ASSIGNED_DATE, EXPECTED_CLOSED_DATE, CLOSED_BY, CLOSED_DATE, ESTIMATE_FIXED_DATE, RESOLVE_STATUS_ID, COMPLEXITY_LEVEL, RESOLUTION, RESOLVED_DATE, RESOLVED_COMMENT)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetDouble(_PROJECT_ID) & ", "
                Sql += DB.SetDouble(_LOG_NO) & ", "
                Sql += DB.SetString(_REF_REQUEST_NO) & ", "
                sql += DB.SetDouble(_TYPE_ID) & ", "
                sql += DB.SetString(_LOG_DESC) & ", "
                sql += DB.SetDouble(_STATUS_ID) & ", "
                sql += DB.SetString(_PRIORITY) & ", "
                sql += DB.SetDouble(_STATE_ID) & ", "
                sql += DB.SetString(_LOG_INSTANCE) & ", "
                sql += DB.SetDouble(_SCREEN_ID) & ", "
                sql += DB.SetDouble(_MODULE_ID) & ", "
                sql += DB.SetString(_RAISED_BY) & ", "
                sql += DB.SetDateTime(_RAISED_ON) & ", "
                sql += DB.SetString(_CHANGE_APPROVE) & ", "
                sql += DB.SetString(_COMMENTS) & ", "
                sql += DB.SetString(_ASSIGNED_TO) & ", "
                sql += DB.SetDateTime(_ASSIGNED_DATE) & ", "
                sql += DB.SetDateTime(_EXPECTED_CLOSED_DATE) & ", "
                sql += DB.SetString(_CLOSED_BY) & ", "
                sql += DB.SetDateTime(_CLOSED_DATE) & ", "
                sql += DB.SetDateTime(_ESTIMATE_FIXED_DATE) & ", "
                sql += DB.SetDouble(_RESOLVE_STATUS_ID) & ", "
                sql += DB.SetString(_COMPLEXITY_LEVEL) & ", "
                sql += DB.SetString(_RESOLUTION) & ", "
                sql += DB.SetDateTime(_RESOLVED_DATE) & ", "
                sql += DB.SetString(_RESOLVED_COMMENT)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table ISSUE_TRACKING_LOG
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_ON = " & DB.SetDateTime(_CREATE_ON) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_ON = " & DB.SetDateTime(_UPDATE_ON) & ", "
                Sql += "PROJECT_ID = " & DB.SetDouble(_PROJECT_ID) & ", "
                Sql += "LOG_NO = " & DB.SetDouble(_LOG_NO) & ", "
                Sql += "REF_REQUEST_NO = " & DB.SetString(_REF_REQUEST_NO) & ", "
                Sql += "TYPE_ID = " & DB.SetDouble(_TYPE_ID) & ", "
                Sql += "LOG_DESC = " & DB.SetString(_LOG_DESC) & ", "
                Sql += "STATUS_ID = " & DB.SetDouble(_STATUS_ID) & ", "
                Sql += "PRIORITY = " & DB.SetString(_PRIORITY) & ", "
                Sql += "STATE_ID = " & DB.SetDouble(_STATE_ID) & ", "
                Sql += "LOG_INSTANCE = " & DB.SetString(_LOG_INSTANCE) & ", "
                Sql += "SCREEN_ID = " & DB.SetDouble(_SCREEN_ID) & ", "
                Sql += "MODULE_ID = " & DB.SetDouble(_MODULE_ID) & ", "
                Sql += "RAISED_BY = " & DB.SetString(_RAISED_BY) & ", "
                Sql += "RAISED_ON = " & DB.SetDateTime(_RAISED_ON) & ", "
                Sql += "CHANGE_APPROVE = " & DB.SetString(_CHANGE_APPROVE) & ", "
                Sql += "COMMENTS = " & DB.SetString(_COMMENTS) & ", "
                Sql += "ASSIGNED_TO = " & DB.SetString(_ASSIGNED_TO) & ", "
                Sql += "ASSIGNED_DATE = " & DB.SetDateTime(_ASSIGNED_DATE) & ", "
                Sql += "EXPECTED_CLOSED_DATE = " & DB.SetDateTime(_EXPECTED_CLOSED_DATE) & ", "
                Sql += "CLOSED_BY = " & DB.SetString(_CLOSED_BY) & ", "
                Sql += "CLOSED_DATE = " & DB.SetDateTime(_CLOSED_DATE) & ", "
                Sql += "ESTIMATE_FIXED_DATE = " & DB.SetDateTime(_ESTIMATE_FIXED_DATE) & ", "
                Sql += "RESOLVE_STATUS_ID = " & DB.SetDouble(_RESOLVE_STATUS_ID) & ", "
                Sql += "COMPLEXITY_LEVEL = " & DB.SetString(_COMPLEXITY_LEVEL) & ", "
                Sql += "RESOLUTION = " & DB.SetString(_RESOLUTION) & ", "
                Sql += "RESOLVED_DATE = " & DB.SetDateTime(_RESOLVED_DATE) & ", "
                Sql += "RESOLVED_COMMENT = " & DB.SetString(_RESOLVED_COMMENT) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table ISSUE_TRACKING_LOG
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table ISSUE_TRACKING_LOG
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace