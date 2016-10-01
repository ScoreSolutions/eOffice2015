Option Strict Off
Option Explicit On
Imports system.data
Imports system.data.sqlclient
Imports System.Web.Configuration

Partial Class TM_TimeStamp_solution
    Inherits System.Web.UI.Page

    Dim MyConn As New SqlConnection(WebConfigurationManager.ConnectionStrings("MyConn").ToString)
    Dim func As New EtimesheetSystem

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim ETClass As New EtimesheetSystem
            SetMonth(ETClass)
            SetYear(ETClass)
            ShowAccount()
            ddlAccount_SelectedIndexChanged(sender, e)
            ddlProject_SelectedIndexChanged(sender, e)
            'ShowManHour()

            ShowSearchUser()
            ShowSearchProject()
            ddlSearchProject_SelectedIndexChanged(sender, e)

            If ETClass.ChedkUserResponsibility(Session("username"), 1) = True Then
                ddlSearchUser.Enabled = True
            End If

            ETClass = Nothing
        End If
    End Sub

    Sub ShowSearchUser()
        Dim Sql As String = "Select id,name + ' ' + surname staff_name from eOFFICE_USER order by name,surname "
        func.BindControl(Me.ddlSearchUser, 1, Sql)

        ddlSearchUser.SelectedValue = Session("user_id")
    End Sub

    Sub ShowSearchProject()
        Dim Sql As String = "Select id,project_code from eOFFICE_PROJECT order by project_code "
        func.BindControl(Me.ddlSearchProject, 1, Sql)
    End Sub

    Sub ShowAccount()
        Dim Sql As String = "Select Id,Account_name from eOFFICE_ACCOUNT order by Account_name "
        func.BindControl(Me.ddlAccount, 1, Sql)
    End Sub

    Sub ShowProject()
        Dim Sql As String = "Select Id,Project_name from eOFFICE_PROJECT where account_id='" & ddlAccount.SelectedValue & "' and active_status='Y' order by Project_name "
        func.BindControl(Me.ddlProject, 1, Sql)
    End Sub

    Sub ShowBillingName(ByVal ddlP As DropDownList, ByVal ddlB As DropDownList)
        Dim Sql As String = "Select Id,Billing_Name from eOFFICE_PROJECT_BILLING where project_id ='" & ddlP.SelectedValue & "'  order by Billing_Name "
        func.BindControl(ddlB, 1, Sql)
    End Sub

    Sub SetMonth(ByVal ETClass As EtimesheetSystem)
        Dim dt As New DataTable
        'Dim ETClass As New EtimesheetSystem
        dt = ETClass.GetMonthNameListThai()
        ddlMonth.DataSource = dt
        ddlMonth.DataBind()
        ddlMonth.Items.Insert(0, New ListItem("-Select-", 0))
    End Sub

    Sub SetYear(ByVal ETClass As EtimesheetSystem)
        Dim dt As New DataTable
        'Dim ETClass As New EtimesheetSystem
        dt = ETClass.GetYearList(10, True)
        ddlYear.DataSource = dt
        ddlYear.DataBind()
        ddlYear.Items.Insert(0, New ListItem("-Select-", 0))
    End Sub

    Sub ShowManHour(ByVal ETClass As EtimesheetSystem)
        Dim filter As String = ""

        If ETClass.ChedkUserResponsibility(Session("username"), 1) = False Then
            filter += " and  MH.eoffice_user_id='" & Session("user_id") & "'"
        End If

        If ddlSearchUser.SelectedValue > 0 Then
            filter += " and MH.eoffice_user_id='" & ddlSearchUser.SelectedValue & "'"
        End If
        If ddlSearchProject.SelectedValue > 0 Then
            filter += " and B.project_id = '" & ddlSearchProject.SelectedValue & "'"
        End If
        If ddlSearchBilling.SelectedValue > 0 Then
            filter += " and MH.project_billing_id = '" & ddlSearchBilling.SelectedValue & "'"
        End If
        If ddlMonth.SelectedIndex > 0 Then
            filter += " and  DATEPART(MM,start_time) ='" & ddlMonth.SelectedValue & "'"
        End If
        If ddlYear.SelectedIndex > 0 Then
            filter += " and DATEPART(yyyy,start_time)  ='" & ddlYear.SelectedItem.Text & "'"
        End If

        Dim sql As String = ""
        sql = " select MH.*,convert(varchar(10),MH.start_time,103) + ' ' + convert(varchar(10),start_time,108) as start_date_time,"
        sql &= " convert(varchar(10),MH.end_time,103) + ' ' + convert(varchar(10),end_time,108) as end_date_time,"
        sql &= " convert(varchar(10),MH.start_time,103) as mhdate,A.account_name,P.project_name,B.billing_name, mh.project_phase, "
        sql &= " u.name + ' ' + u.surname staff_name"
        sql &= " from eOFFICE_PROJECT_BILLING B "
        sql &= " Inner Join eOFFICE_PROJECT P ON B.project_id=P.id"
        sql &= " Inner Join eOFFICE_ACCOUNT A ON P.account_id =A.id "
        sql &= " Inner Join eOFFICE_PROJECT_MANHOUR MH ON B.id=MH.project_billing_id"
        sql &= " inner join eOFFICE_USER u on u.id=mh.eoffice_user_id"
        sql &= " where 1=1 " & filter & " "
        sql += " Order By A.account_name,P.project_name,billing_name, start_time"
        func.checkConn(MyConn)
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet
        da.Fill(ds)
        rptShowManhour.DataSource = ds
        rptShowManhour.DataBind()
    End Sub

    Protected Sub ddlAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAccount.SelectedIndexChanged
        ShowProject()
    End Sub

    Protected Sub ddlProject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProject.SelectedIndexChanged
        ShowBillingName(ddlProject, ddlBillingName)
    End Sub

    Protected Sub ButView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButView.Click
        Dim ETClass As New EtimesheetSystem
        ShowManHour(ETClass)
        ETClass = Nothing
    End Sub

    Sub ClearForm()
        ddlAccount.SelectedIndex = 0
        ddlProject.SelectedIndex = 0
        ddlBillingName.SelectedIndex = 0
        txtDate.TxtBox.Text = ""
        txtStartTime.TxtBox.Text = ""
        txtEndTime.TxtBox.Text = ""
        txtDescription.Text = ""
        lblID.Text = "0"
        rdiPhaseSale.Checked = False
        rdiPhaseDevelop.Checked = False
        rdiPhaseDeploy.Checked = False
        rdiPhaseSupport.Checked = False
    End Sub

    Protected Sub btnCancle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancle.Click
        ClearForm()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblError.Visible = True
        lblError.Text = ""
        lblError.CssClass = "errorBox"
        Try

            If ddlAccount.SelectedIndex = 0 Then
                lblError.Text = "Please Enter Account"
                lblError.Visible = True
                Exit Sub
            ElseIf ddlProject.SelectedIndex = 0 Then
                lblError.Text = "Please Enter Project"
                lblError.Visible = True
                Exit Sub
            ElseIf ddlBillingName.SelectedIndex = 0 Then
                lblError.Text = "Please Enter Billing Name"
                lblError.Visible = True
                Exit Sub
            ElseIf txtDate.TxtBox.Text = "" Then
                lblError.Text = "Please Enter Date"
                lblError.Visible = True
                Exit Sub
            ElseIf rdiPhaseSale.Checked = False And rdiPhaseDevelop.Checked = False And rdiPhaseDeploy.Checked = False And rdiPhaseSupport.Checked = False Then
                lblError.Text = "Please Select Phase"
                lblError.Visible = True
                Exit Sub
            ElseIf txtStartTime.TxtBox.Text = "" Then
                lblError.Text = "Please Enter Start Time"
                lblError.Visible = True
                Exit Sub
            ElseIf txtEndTime.TxtBox.Text = "" Then
                lblError.Text = "Please Enter End Time"
                lblError.Visible = True
                Exit Sub
            ElseIf txtDescription.Text.Trim.Length < 50 Then
                lblError.Text = "Please Enter Description More Than 50 Characters"
                lblError.Visible = True
                Exit Sub
            End If

            Dim mhDate As String = txtDate.DateValue.Year & "-" & txtDate.DateValue.Month & "-" & txtDate.DateValue.Day
            Dim startTime As String = mhDate & " " & txtStartTime.TxtBox.Text & ":00"
            Dim endTime As String = mhDate & " " & txtEndTime.TxtBox.Text & ":00"
            Dim ProjectPhase As String = ""
            If rdiPhaseSale.Checked = True Then
                ProjectPhase = "1"
            ElseIf rdiPhaseDevelop.Checked = True Then
                ProjectPhase = "2"
            ElseIf rdiPhaseDeploy.Checked = True Then
                ProjectPhase = "3"
            ElseIf rdiPhaseSupport.Checked = True Then
                ProjectPhase = "4"
            End If

            Dim sql As String = ""
            func.checkConn(MyConn)
            If lblID.Text = "0" Then
                sql = "insert into eOFFICE_PROJECT_MANHOUR(created_by,created_date,project_billing_id,start_time,end_time,manhour_desc,project_phase, eoffice_user_id)"
                sql &= " values('" & Session("username") & "',GETDATE(),'" & ddlBillingName.SelectedValue & "','" & startTime & "','" & endTime & "','" & txtDescription.Text.Trim() & "','" & ProjectPhase & "','" & Session("user_id") & "')"
            Else
                sql = "Update eOFFICE_PROJECT_MANHOUR Set "
                sql &= " project_billing_id ='" & ddlBillingName.SelectedValue & "'"
                sql &= ",start_time ='" & startTime & "'"
                sql &= ",end_time ='" & endTime & "'"
                sql &= ",manhour_desc = '" & txtDescription.Text & "'"
                sql += ",project_phase = '" & ProjectPhase & "'"
                sql &= ",updated_by='" & Session("username") & "',updated_date=GETDATE()"
                sql &= " where id ='" & lblID.Text & "'"
            End If
            Dim cmd As New SqlCommand(sql, MyConn)
            cmd.ExecuteNonQuery()

            ClearForm()

            Dim ETClass As New EtimesheetSystem
            ShowManHour(ETClass)
            ETClass = Nothing

            lblError.CssClass = "successBox"
            lblError.Text = "Manhour has been add successfully."

        Catch ex As Exception
            lblError.Text = ex.ToString()
        End Try
    End Sub

    Sub EditDelete(ByVal o As Object, ByVal e As RepeaterCommandEventArgs) Handles rptShowManhour.ItemCommand
        Dim id As String = CType(e.CommandSource, Button).CommandArgument
        If e.CommandName.ToUpper = "EDIT" Then
            lblError.Visible = False
            Dim Sql As String = "select MH.id,MH.project_billing_id,convert(varchar(5),start_time,108) as start_time,"
            Sql &= " convert(varchar(5),end_time,108) as end_time,"
            Sql &= " MH.start_time as mhdate,P.account_id,B.project_id,MH.manhour_desc,mh.project_phase,MH.eoffice_user_id "
            Sql &= " from eOFFICE_PROJECT_BILLING B "
            Sql &= " Inner Join eOFFICE_PROJECT P ON B.project_id=P.id"
            Sql &= " Inner Join eOFFICE_ACCOUNT A ON P.account_id =A.id "
            Sql &= " Inner Join eOFFICE_PROJECT_MANHOUR MH ON B.id=MH.project_billing_id where MH.id= '" & id & "' "
            Dim da As New SqlDataAdapter(Sql, MyConn)
            Dim dt As New DataTable
            da.Fill(dt)
            lblID.Text = dt.Rows(0)("Id")

            Try
                ddlAccount.SelectedValue = dt.Rows(0)("account_id").ToString
                ddlAccount_SelectedIndexChanged(o, e)
            Catch ex As Exception
                ddlAccount.SelectedIndex = 0
            End Try

            Try
                ddlProject.SelectedValue = dt.Rows(0)("project_id").ToString
                ddlProject_SelectedIndexChanged(o, e)
            Catch ex As Exception
                ddlProject.SelectedIndex = 0
            End Try

            Try
                ddlBillingName.SelectedValue = dt.Rows(0)("project_billing_id").ToString
            Catch ex As Exception
                ddlBillingName.SelectedIndex = 0
            End Try

            Try
                txtDate.DateValue = dt.Rows(0)("mhdate")
            Catch ex As Exception
                txtDate.TxtBox.Text = ""
            End Try

            rdiPhaseSale.Checked = False
            rdiPhaseDevelop.Checked = False
            rdiPhaseDeploy.Checked = False
            rdiPhaseSupport.Checked = False

            Select Case dt.Rows(0)("project_phase")
                Case "1"
                    rdiPhaseSale.Checked = True
                Case "2"
                    rdiPhaseDevelop.Checked = True
                Case "3"
                    rdiPhaseDeploy.Checked = True
                Case "4"
                    rdiPhaseSupport.Checked = True
            End Select

            Try
                txtStartTime.TxtBox.Text = dt.Rows(0)("start_time")
            Catch ex As Exception
                txtStartTime.TxtBox.Text = ""
            End Try

            Try
                txtEndTime.TxtBox.Text = dt.Rows(0)("end_time")
            Catch ex As Exception
                txtEndTime.TxtBox.Text = ""
            End Try

            txtDescription.Text = dt.Rows(0)("manhour_desc").ToString

        ElseIf e.CommandName.ToUpper = "DELETE" Then
            func.checkConn(MyConn)
            Dim Sql As String = "delete from eOFFICE_PROJECT_MANHOUR where id = '" & id & "' "
            Dim cmd As New SqlCommand(Sql, MyConn)
            cmd.ExecuteNonQuery()
            lblError.CssClass = "successBox"
            lblError.Text = "Manhour has been delete successfully."
            lblError.Visible = True
            ClearForm()
        End If

        'ShowManHour()
    End Sub

    Protected Sub ddlSearchProject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSearchProject.SelectedIndexChanged
        ShowBillingName(ddlSearchProject, ddlSearchBilling)
    End Sub
End Class
