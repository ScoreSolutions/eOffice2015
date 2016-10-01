Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class eOFFICEWebServiceAPI
    Inherits System.Web.Services.WebService

    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '    Return "Hello World"
    'End Function

    <WebMethod()> _
    Public Function GetAccountAllList() As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select a.id account_id, a.account_code, a.account_name, a.account_address, a.account_province_id, p.province_name,"
            sql += " a.account_district_id, d.district_name, a.account_subdistrict_id, sd.subdistrict_name,"
            sql += " a.account_postcode, a.account_email, a.account_tel_no, a.account_fax_no, a.account_mobile_no"
            sql += " from eoffice_account a"
            sql += " left join ms_province p on p.id=a.account_province_id"
            sql += " left join MS_DISTRICT d on d.id=a.account_district_id"
            sql += " left join ms_subdistrict sd on sd.id=a.account_subdistrict_id "
            sql += " order by a.account_code, a.account_name "

            Dim eng As New EtimesheetSystem
            ret = eng.GetDatatable(sql)
            eng = Nothing
        Catch ex As Exception
            ret = New DataTable
        End Try
        ret.TableName = "GetAccountAllList"
        Return ret
    End Function

    <WebMethod()> _
    Public Function GetAccountBranch(ByVal AccountID As String) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select b.id branch_id, b.branch_code,b.branch_name, b.branch_address, b.branch_province_id, p.province_name,"
            sql += " b.branch_district_id, d.district_name, b.branch_subdistrict_id, sd.subdistrict_name,"
            sql += " b.branch_postcode, b.branch_email, b.branch_tel_no, b.branch_fax_no, b.branch_mobile_no, b.branch_contact_name"
            sql += " from eoffice_account_branch b"
            sql += " left join ms_province p on p.id=b.branch_province_id"
            sql += " left join MS_DISTRICT d on d.id=b.branch_district_id"
            sql += " left join ms_subdistrict sd on sd.id=b.branch_subdistrict_id"
            sql += " where b.account_id='" & AccountID & "'"
            sql += " order by b.branch_code, b.branch_name"

            Dim eng As New EtimesheetSystem
            ret = eng.GetDatatable(sql)
            eng = Nothing
        Catch ex As Exception
            ret = New DataTable
        End Try
        ret.TableName = "GetAccountBranch"
        Return ret
    End Function

    <WebMethod()> _
    Public Function GetAccountContact(ByVal AccountID As String) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select c.id contact_id, p.prename_desc, c.first_name, c.last_name,c.nickname,c.position_name,c.email,c.mobile"
            sql += " from eOFFICE_ACCOUNT_CONTACT c"
            sql += " left join eOFFICE_PRENAME p on p.id=c.prename_id"

            Dim eng As New EtimesheetSystem
            ret = eng.GetDatatable(sql)
            eng = Nothing
        Catch ex As Exception
            ret = New DataTable
        End Try
        ret.TableName = "GetAccountContact"
        Return ret
    End Function


    Private Function GetProjectList(ByVal wh As String) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select p.id, p.account_id, a.account_code, a.account_name, p.project_code, p.project_name,"
            sql += " p.pm_user_id, pu.name + ' ' + pu.surname project_manager,"
            sql += " p.cost_control_user_id, cu.name + ' ' + cu.surname project_cost_controller"
            sql += " from eOFFICE_PROJECT p"
            sql += " inner join eOFFICE_ACCOUNT a on a.id=p.account_id"
            sql += " inner join eOFFICE_USER pu on pu.id=p.pm_user_id"
            sql += " inner join eOFFICE_USER cu on cu.id=p.cost_control_user_id"
            sql += " where 1=1"
            If wh.Trim <> "" Then
                sql += wh
            End If
            sql += " order by a.account_code, p.project_code, p.project_name"

            Dim eng As New EtimesheetSystem
            ret = eng.GetDatatable(sql)
            eng = Nothing
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    <WebMethod()> _
    Public Function GetProjectAllList() As DataTable
        Dim ret As New DataTable
        Try
            ret = GetProjectList("")
        Catch ex As Exception
            ret = New DataTable
        End Try
        ret.TableName = "GetProjectAllList"
        Return ret
    End Function

    <WebMethod()> _
    Public Function GetProjectByAccount(ByVal AccountID As String) As DataTable
        Dim ret As New DataTable
        Try
            ret = GetProjectList(" and p.account_id='" & AccountID & "'")
        Catch ex As Exception
            ret = New DataTable
        End Try
        ret.TableName = "GetProjectByAccount"
        Return ret
    End Function

    

    Private Function GetUserList(ByVal wh As String) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select u.id,u.employee_id, u.name, u.surname, pr.prename_desc + ' ' + u.name + ' ' + u.surname staff_name,"
            sql += " u.department_id,d.department_abb,d.department_desc,u.position_id, p.position_desc,"
            sql += " u.email, u.username, u.group_id, ug.group_name_en, ug.group_name_th"
            sql += " from eOFFICE_USER u"
            sql += " inner join eOFFICE_PRENAME pr on pr.id=u.prename_id"
            sql += " left join eOFFICE_DEPARTMENT d on d.id=u.department_id"
            sql += " left join eOFFICE_POSITION p on p.id=u.position_id"
            sql += " inner join eOFFICE_USER_GROUP ug on ug.id=u.group_id"
            sql += " where 1=1 "
            If wh.Trim <> "" Then
                sql += wh
            End If
            sql += " order by u.name, u.surname"

            Dim eng As New EtimesheetSystem
            ret = eng.GetDatatable(sql)
            eng = Nothing
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    <WebMethod()> _
    Public Function GetUserAllList() As DataTable
        Dim ret As New DataTable
        Try
            ret = GetUserList("")
        Catch ex As Exception
            ret = New DataTable
        End Try
        ret.TableName = "GetUserAllList"
        Return ret
    End Function

    <WebMethod()> _
    Public Function GetActiveUserList() As DataTable
        Dim ret As New DataTable
        Try
            ret = GetUserList(" and convert(varchar(8),isnull(end_date,getdate()),112)>=convert(varchar(8),getdate(),112)")
        Catch ex As Exception
            ret = New DataTable
        End Try
        ret.TableName = "GetActiveUserList"
        Return ret
    End Function

    <WebMethod()> _
    Public Function CheckAuthorizeUser(ByVal UserName As String, ByVal pwd As String) As clsUserAuthorizedPara
        Dim ret As New clsUserAuthorizedPara
        Try
            Dim dt As New DataTable
            Dim eng As New EtimesheetSystem
            dt = GetUserList(" and u.username='" & UserName & "' and u.password='" & eng.EnCripPwd(pwd) & "' ")
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                ret.CheckUserAuthorized = True
                With ret.UserPara
                    .ID = dr("id")
                    If Convert.IsDBNull(dr("employee_id")) = False Then .EMPLOYEE_ID = dr("employee_id")
                    If Convert.IsDBNull(dr("name")) = False Then .NAME = dr("name")
                    If Convert.IsDBNull(dr("surname")) = False Then .SURNAME = dr("surname")
                    If Convert.IsDBNull(dr("staff_name")) = False Then .STAFF_NAME = dr("staff_name")
                    If Convert.IsDBNull(dr("department_id")) = False Then .DEPARTMENT_ID = Convert.ToInt64(dr("department_id"))
                    If Convert.IsDBNull(dr("department_abb")) = False Then .DEPARTMENT_ABB = dr("department_abb")
                    If Convert.IsDBNull(dr("department_desc")) = False Then .DEPARTMENT_DESC = dr("department_desc")
                    If Convert.IsDBNull(dr("position_id")) = False Then .POSITION_ID = Convert.ToInt64(dr("position_id"))
                    If Convert.IsDBNull(dr("position_desc")) = False Then .POSITION_DESC = dr("position_desc")
                    If Convert.IsDBNull(dr("email")) = False Then .EMAIL = dr("email")
                    If Convert.IsDBNull(dr("username")) = False Then .USERNAME = dr("username")
                    If Convert.IsDBNull(dr("group_id")) = False Then .GROUP_ID = Convert.ToInt64(dr("group_id"))
                    If Convert.IsDBNull(dr("group_name_en")) = False Then .GROUP_NAME_EN = dr("group_name_en")
                    If Convert.IsDBNull(dr("group_name_th")) = False Then .GROUP_NAME_TH = dr("group_name_th")
                End With
            End If
            eng = Nothing
            dt.Dispose()
        Catch ex As Exception
            ret = New clsUserAuthorizedPara
        End Try
        Return ret
    End Function


    <WebMethod()> _
    Public Function SaveUserInfo(ByVal UserID As String, ByVal UserName As String, ByVal PassWD As String, ByVal EmployeeID As String, ByVal PrenameID As String, ByVal FirstName As String, ByVal LastName As String, ByVal DepartmentID As String, ByVal PositionID As String, ByVal eMail As String, ByVal GroupID As String, ByVal MemberType As String, ByVal MobileNo As String, ByVal StartDate As String, ByVal EndDate As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim Sql As String = ""
            Dim func As New EtimesheetSystem
            If UserID = "0" Then
                If func.dataExists("eOFFICE_USER", "username", func.FixData(CStr(UserName))) Then
                    Return False
                End If

                Sql = " insert into eOFFICE_USER (PreName_Id,Employee_Id,name,surname,username,password,group_id,"
                Sql &= " Department_Id,Position_Id,created_by,created_date,Member_Type,start_date,end_date,email,mobile_no,chg_pwd_first_login) values "
                Sql &= "('" & PrenameID & "'"
                Sql &= ",'" & EmployeeID & "'"
                Sql &= ",'" & func.FixData(CStr(FirstName)) & "'"
                Sql &= ",'" & func.FixData(CStr(LastName)) & "'"
                Sql &= ",'" & func.FixData(CStr(Trim(UserName))) & "'"
                Sql &= ",'" & func.FixData(func.EnCripPwd(PassWD)) & "'"
                Sql &= ",'" & GroupID & "'"
                Sql &= ",'" & DepartmentID & "'"
                Sql &= ",'" & PositionID & "'"
                Sql &= ",'" & UserName & "'"
                Sql &= ",GETDATE(),'Human'"
                Sql &= ",'" & StartDate & "'"
                Sql &= ",'" & EndDate & "'"
                Sql &= ",'" & func.FixData(CStr(eMail)) & "'"
                Sql &= ",'" & func.FixData(CStr(MobileNo)) & "','Y')"
            Else
                Sql = "update eOFFICE_USER set PreName_ID ='" & PrenameID & "'"
                Sql &= ",Employee_Id = '" & EmployeeID & "'"
                Sql &= ",Name = '" & FirstName & "'"
                Sql &= ",SurName= '" & LastName & "'"
                Sql &= ",group_id= '" & GroupID & "'"
                Sql &= ",Department_Id= '" & DepartmentID & "'"
                Sql &= ",Position_Id= '" & PositionID & "'"
                Sql &= ",email='" & CStr(func.FixData(eMail)) & "'"
                Sql &= ",mobile_no='" & CStr(func.FixData(MobileNo)) & "'"
                Sql &= ",start_date='" & StartDate & "'"
                Sql &= ",end_date='" & EndDate & "'"
                Sql &= ",updated_by='" & UserName & "',updated_date=GETDATE()"
                Sql &= " where username= '" & UserName & "'"
            End If

            ret = func.ExecuteSQL(Sql)
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

    <WebMethod()> _
    Public Function ChangePassword(ByVal Username As String, ByVal OldPassword As String, ByVal NewPassword As String) As String
        Dim ret As String = "False"
        Try
            Dim Sql As String = ""
            Dim func As New EtimesheetSystem

            If func.dataExists("eOFFICE_USER", "username", func.FixData(CStr(Username))) = False Then
                ret = "False|Username " & Username & " not exist"
            ElseIf func.dataExists("eOFFICE_USER", "password", func.FixData(func.EnCripPwd(OldPassword))) = False Then
                ret = "False|Incorrect Old Password"
            Else
                Sql = "update eOFFICE_USER "
                Sql += " set password ='" & func.FixData(func.EnCripPwd(NewPassword)) & "'"
                Sql += " where username='" & Username & "'"

                ret = func.ExecuteSQL(Sql)
            End If
        Catch ex As Exception
            ret = "False|" & ex.Message
        End Try
        Return ret
    End Function
End Class
