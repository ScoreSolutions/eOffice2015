Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports System.Data
Imports System.IO

Partial Class login
    Inherits System.Web.UI.Page
    Dim func As New EtimesheetSystem

    Protected Sub txtusername_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtusername.PreRender
        txtusername.Focus()
        txtusername.Attributes.Add("onKeyPress", "if((event.keyCode==13)) {document." & Master.FindControl("frm").ClientID & "." & txtpassword.ClientID & ".focus();return false;} else {return true;}")
        txtusername.Attributes.Add("onKeyDown", "if((event.keyCode==9)) {document." & Master.FindControl("frm").ClientID & "." & txtpassword.ClientID & ".focus();return false;} else {return true;}")
    End Sub

    Protected Sub btnlogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlogin.Click
        Dim func As New EtimesheetSystem
        Dim st_StrSQL As String

        st_StrSQL = " select  a.id as member_id,a.employee_id,a.department_Id,b.prename_desc + a.name +' '+a.surname as member_fullname,"
        st_StrSQL &= " a.name,a.username,chg_pwd_first_login,group_menu from eOFFICE_USER a "
        st_StrSQL &= " inner join eOFFICE_USER_GROUP UG ON a.group_id=UG.id "
        st_StrSQL &= " inner join eOFFICE_PRENAME b  on   a.prename_id = b.id where a.[username] ='" & func.FixData(txtusername.Text) & "'"
        st_StrSQL &= " and a.[password] = '" & func.FixData(func.EnCripPwd(txtpassword.Text)) & "'"

        Dim dt As New DataTable
        dt = func.GetDatatable(st_StrSQL)
        Session.RemoveAll()
        If dt.Rows.Count <> 0 Then
            Session("login_state") = "LoginPass"
            Session("Employee_Id") = dt.Rows(0)("Employee_Id")
            Session("Member_Id") = dt.Rows(0)("Member_Id")
            Session("user_id") = dt.Rows(0)("Member_Id")
            Session("department_Id") = dt.Rows(0)("department_Id")
            Session("Member_FullName") = dt.Rows(0)("Member_FullName")
            Session("menu") = dt.Rows(0)("group_menu")
            Session("username") = dt.Rows(0)("username")
            Session("gname") = func.CmdSQL("Select max(Group_name_en) from eOFFICE_USER_GROUP Where Id=(Select Group_Id From eOFFICE_USER Where Id='" & Session("Member_Id") & "')")
            func.CmdSQL("Update eOFFICE_USER Set last_login_date = getdate() Where Id=" & Session("Member_Id"))


            'Try
            '    Dim TimeSheetID As String = Request.QueryString("TimeSheetID")
            '    Dim ISSender As String = Request.QueryString("ISSender")
            '    Dim Type As String = Request.QueryString("Type")

            '    If ISSender = "Y" Then
            '        Response.Redirect("ET_TimeSheetDetail.aspx?id=" & TimeSheetID & "")
            '        Exit Sub
            '    End If

            '    If ISSender = "N" Then
            '        Response.Redirect("ET_ViewTimeSheetDetail.aspx?id=" & TimeSheetID & "&type=" & Type & "")
            '        Exit Sub
            '    End If
            'Catch ex As Exception
            'End Try

            If dt.Rows(0)("chg_pwd_first_login") = "Y" Then
                Session("menu") = "9"
                Response.Redirect("MN_Change_Password.aspx")
            Else
                Response.Redirect("Default.aspx")
            End If
        Else
            lblInvalid.Text = "Invalid username or password"
        End If
        dt.Dispose()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("ChangePassword") = "Y" Then
            lblInvalid.Text = "Please login again with your new password."
        Else
            lblInvalid.Text = ""
        End If
    End Sub
End Class
