Imports System.Data.SqlClient
Imports System.Data
Partial Class MasterPage_Basic
    Inherits System.Web.UI.MasterPage
    Dim func As New EtimesheetSystem

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Request("token") IsNot Nothing Then
            CreateTokenLogonData(Request("token"))
        End If

        If Not func.CheckLogin(Session("login_state")) Then Response.Redirect("login.aspx")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ls_FileName As String = Replace(Request.FilePath, Request.ApplicationPath & "/", "", , , 1)
        If Not func.checkPerm(Replace(ls_FileName, "/", ""), Session("menu"), lblheaderMenulink) Then
            If Not ls_FileName.ToLower = "default.aspx" Then
                Response.Redirect("default.aspx")
            End If
        Else
            Session("SubFileName") = ls_FileName
        End If
        func.showMenu(mnHolder, Session("menu"))

    End Sub


    Private Sub CreateTokenLogonData(ByVal TokenData As String)
        Dim st_StrSQL = " select  a.id as member_id,a.employee_id,a.department_Id,b.prename_desc + a.name +' '+a.surname as member_fullname,"
        st_StrSQL &= " a.name,a.username,chg_pwd_first_login,group_menu "
        st_StrSQL += " from eOFFICE_EMAIL_TOKEN et "
        st_StrSQL += " inner join eOFFICE_USER a on a.id=et.eoffice_user_id"
        st_StrSQL &= " inner join eOFFICE_USER_GROUP UG ON a.group_id=UG.id "
        st_StrSQL &= " inner join eOFFICE_PRENAME b  on   a.prename_id = b.id "
        st_StrSQL += " where et.token_data ='" & TokenData & "'"


        Dim dt As New DataTable
        dt = func.GetDatatable(st_StrSQL)
        If dt.Rows.Count > 0 Then
            Session("login_state") = "LoginPass"
            Session("Employee_Id") = dt.Rows(0)("Employee_Id")
            Session("Member_Id") = dt.Rows(0)("Member_Id")
            Session("user_id") = dt.Rows(0)("Member_Id")
            Session("department_Id") = dt.Rows(0)("department_Id")
            Session("Member_FullName") = dt.Rows(0)("Member_FullName")
            Session("menu") = dt.Rows(0)("group_menu")
            Session("username") = dt.Rows(0)("username")
            Session("gname") = func.CmdSQL("Select max(Group_name_en) from eOFFICE_USER_GROUP Where Id=(Select Group_Id From eOFFICE_USER Where Id='" & Session("Member_Id") & "')")
            Session("token_data") = TokenData
        End If
        dt.Dispose()
    End Sub
End Class