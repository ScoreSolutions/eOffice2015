Option Strict Off
Option Explicit On
Imports system.data
Imports system.data.sqlclient

Partial Class _ET_CreateProject
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim ds As New DataSet
    Dim Conf As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/")
    Dim MyConn As New SqlConnection(Conf.ConnectionStrings.ConnectionStrings("MyConn").ToString)
    Dim last_parent As String = ""
    Dim func As New EtimesheetSystem

    Sub LoadCHBSelected(ByRef CrtCheckBoxList As CheckBoxList, ByVal ls_PK_ID As String, ByVal ls_TableName As String, ByVal ParmId As String)
        Dim li_i As Int16 = 0
        Dim li_j As Int16 = 0
        sql = "Select " & ls_PK_ID & " as PK_ID From " & ls_TableName & " Where  Project_Id = " & ParmId
        'Response.Write(sql)
        'Response.End()
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet
        Dim temp_dsVal As String
        da.Fill(ds)
        For li_i = 0 To ds.Tables(0).Rows.Count - 1
            temp_dsVal = Trim(func.fixNull(ds.Tables(0).Rows(li_i).Item("PK_ID"), "0"))
            'Response.Write(temp_dsVal & ",<br>")
            If temp_dsVal <> "0" Then
                Try
                    CrtCheckBoxList.Items.FindByValue(temp_dsVal).Selected = True
                Catch ex As Exception

                End Try

            End If
        Next
        CrtCheckBoxList.Visible = True
    End Sub

    Sub LoadDetail(ByVal prm_Id As Int16)
        sql = "Select * From Of_Project  Where Project_Id = " & prm_Id
        Dim da As New SqlDataAdapter(sql, MyConn)
        Dim ds As New DataSet
        da.Fill(ds)
        Me.txtProjectCode.Text = ds.Tables(0).Rows(0)("Project_Code")
        Me.txtProjectName.Text = ds.Tables(0).Rows(0)("Project_Name")
        Try
            Me.drpClientOwner.SelectedValue = ds.Tables(0).Rows(0)("ClientOwner_Id")
        Catch ex As Exception:End Try
        func.BindControl(Me.chbOperateBranch, 0, "Select * From Of_Client Where Parent_Id = " & Me.drpClientOwner.SelectedValue & " or Client_Id=" & Me.drpClientOwner.SelectedValue)
        func.BindControl(Me.drpBillTo, 1, "Select * From Of_Client Where Parent_Id = " & Me.drpClientOwner.SelectedValue & " or Client_Id=" & Me.drpClientOwner.SelectedValue)
        func.BindControl(Me.chbContractPerson, 0, "SELECT a.Customer_Id, b.prename_dec + '.' + a.Name + '  ' + a.SurName AS CustomerFullName FROM OF_Customer a INNER JOIN OF_Prename b ON a.Prename_Id = b.Prename_Id WHERE a.Client_Id = " & Me.drpClientOwner.SelectedValue & "order by a.name,a.surname")
        func.BindControl(Me.chbCusManager, 0, "SELECT a.Customer_Id, b.prename_dec + '.' + a.Name + '  ' + a.SurName AS CustomerFullName FROM OF_Customer a INNER JOIN OF_Prename b ON a.Prename_Id = b.Prename_Id WHERE a.Client_Id = " & Me.drpClientOwner.SelectedValue & "order by a.name,a.surname")
        func.BindControl(Me.chbCusLeader, 0, "SELECT a.Customer_Id, b.prename_dec + '.' + a.Name + '  ' + a.SurName AS CustomerFullName FROM OF_Customer a INNER JOIN OF_Prename b ON a.Prename_Id = b.Prename_Id WHERE a.Client_Id = " & Me.drpClientOwner.SelectedValue & "order by a.name,a.surname")
        func.BindControl(Me.chbProjectManager, 0, "select a.member_id,b.prename_dec+'.'+a.name+' '+a.surname as MemberFullName From Of_member a,of_Prename b Where a.Prename_Id = b.Prename_Id  and Member_type='Human'order by a.name,a.surname")
        func.BindControl(Me.chbProjectLeader, 0, "select a.member_id,b.prename_dec+'.'+a.name+' '+a.surname as MemberFullName From Of_member a,of_Prename b Where a.Prename_Id = b.Prename_Id  and Member_type='Human'order by a.name,a.surname")
        func.BindControl(Me.chbProjectTeam, 0, "select a.member_id,b.prename_dec+'.'+a.name+' '+a.surname as MemberFullName From Of_member a,of_Prename b Where a.Prename_Id = b.Prename_Id  and Member_type='Human'order by a.name,a.surname")

        Me.txtDate.Text = CDate(ds.Tables(0).Rows(0)("Start_Date")).ToString("dd-MMM-yyyy")
        'Me.txtDate.Text = Me.txtDate.Text.ToString("dd-MMM-yyyy")
        Me.txtDulation.Text = func.fixnull(ds.Tables(0).Rows(0)("Dulation"), "")
        If Me.drpBillTo.SelectedIndex > 0 Then Me.drpBillTo.SelectedValue = func.fixNull(ds.Tables(0).Rows(0)("billing_To"), "")
        Me.TxtBillAddress.Text = func.fixNull(ds.Tables(0).Rows(0)("BillingAddress"), "")
        Try
            Me.drpMethodology.SelectedValue = func.fixNull(ds.Tables(0).Rows(0)("Methodology"), "")
        Catch ex As Exception
            Me.drpMethodology.SelectedIndex = 0
        End Try
        Try
            drpBillTo.SelectedValue = func.fixNull(ds.Tables(0).Rows(0)("Billing_To"), "")
        Catch ex As Exception
            drpBillTo.SelectedIndex = 0
        End Try

        LoadCHBSelected(Me.chbOperateBranch, "Client_Id", "OF_ProjectBranch", prm_Id)
        LoadCHBSelected(Me.chbCusManager, "Customer_Id", "OF_ProjectCusManager", prm_Id)
        LoadCHBSelected(Me.chbCusLeader, "Customer_Id", "OF_ProjectCusLeader", prm_Id)
        LoadCHBSelected(Me.chbContractPerson, "Customer_Id", "OF_ProjectCusContract", prm_Id)
        LoadCHBSelected(Me.chbProjectManager, "member_Id", "OF_ProjectManager", prm_Id)
        LoadCHBSelected(Me.chbProjectLeader, "member_Id", "OF_ProjectLeader", prm_Id)
        LoadCHBSelected(Me.chbProjectTeam, "member_Id", "OF_ProjectTeam", prm_Id)
    End Sub

    Sub rptSelect(ByVal o As Object, ByVal e As RepeaterCommandEventArgs) Handles rptShowProject.ItemCommand

        Dim id As String = CType(e.CommandSource, Button).CommandArgument
        Dim comn As String = CType(e.CommandSource, Button).CommandName
        Dim li_RecCount As Int16
        li_RecCount = func.CmdSQL("Select Count(Project_Id) from Of_Project Where Project_Id=" & id)
        If li_RecCount > 0 Then
            Me.lblProject_Id.Text = id
            sql = ""
            func.checkConn(MyConn, "o")
            If comn.ToUpper = "SELECT" Then
                LoadDetail(id)
                SetVisibleBut("SELECT")
                sql = " and a.Project_Id <>" & id
            End If
            lblError.Visible = False
        Else
            ClearLoader()
            lblError.CssClass = "errorBox"
            lblError.Text = "Record not Found."
            SetVisibleBut("CANCEL")
            lblError.Visible = True
        End If
        func.BindControl(rptShowProject, 0, lblTempSQL.Text & sql)
    End Sub


    Protected Sub PlHSelectDate_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles PlHSelectDate.Init
        PlHSelectDate.Controls.Add(New LiteralControl("<SCRIPT language=""javascript"">if (!document.layers){document.write(""<image src='__js/calendar.jpg' width=20 height=20 border=0 align=absmiddle onclick='popUpCalendar(this, " & Me.txtDate.ClientID & ", \""dd-mmm-yyyy\"")' value=' Date ' style='font-size:11px'>"")}</SCRIPT>"))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtProjectCode.Focus()
            'func.BindControl(Me.drpClientOwner, 1, "Select * From Of_Client Where parent_id <> 0")
            func.BindControl(Me.drpClientOwner, 1, "Select Client_id,Client_name From Of_Client Where parent_id = 33")
            Me.drpBillTo.Items.Insert(0, "-Select-")
            func.BindControl(Me.drpMethodology, 1, "Select * From OF_MasMethodology Where  parentid = 1")

        End If
    End Sub

    Protected Sub butExpBranch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butExpBranch.Click

        If Not chbOperateBranch.Visible Then
            butExpBranch.Text = "Hide"
            chbOperateBranch.Visible = True
        Else
            butExpBranch.Text = "Expand"
            chbOperateBranch.Visible = False
        End If
    End Sub


    Protected Sub txtDulation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDulation.Init
        txtDulation.Attributes.Add("onkeypress", "if (event.keyCode < 45 || event.keyCode > 57 && (event.keyCode!=35)) event.returnValue = false;")
    End Sub


    Protected Sub txtDate_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDate.Init
        txtDate.Attributes.Add("onkeypress", "if (event.keyCode < 0 || event.keyCode > 0 && (event.keyCode!=0)) event.returnValue = false;")
    End Sub

    Protected Sub drpClientHQ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpClientOwner.SelectedIndexChanged
        Dim li_TempVal As Int16
        li_TempVal = Me.drpClientOwner.SelectedValue
        'func.BindControl(Me.drpClientOwner, 0, "Select * From Of_Client Where parent_id <> 0")
        func.BindControl(Me.drpClientOwner, 0, "Select Client_id,Client_name From Of_Client Where parent_id = 33")
        Me.drpClientOwner.SelectedValue = li_TempVal
        func.BindControl(Me.chbOperateBranch, 0, "Select * From Of_Client Where Parent_Id = " & Me.drpClientOwner.SelectedValue & " or Client_Id=" & Me.drpClientOwner.SelectedValue)
        Dim parent As String = func.CmdSQL("select max(Parent_Id) from Of_Client where Client_id=" & li_TempVal)
        func.BindControl(Me.drpBillTo, 1, "Select * From Of_Client Where Parent_Id = " & parent & " or Client_Id=" & parent)
        'func.BindControl(Me.drpBillTo, 1, "Select * From Of_Client Where Parent_Id = " & Me.drpClientOwner.SelectedValue & " or Client_Id=" & Me.drpClientOwner.SelectedValue)
        func.BindControl(Me.chbContractPerson, 0, "SELECT a.Customer_Id, b.prename_dec + '.' + a.Name + '  ' + a.SurName AS CustomerFullName FROM OF_Customer a INNER JOIN OF_Prename b ON a.Prename_Id = b.Prename_Id WHERE a.Client_Id = " & Me.drpClientOwner.SelectedValue & " order by a.name")
        func.BindControl(Me.chbCusManager, 0, "SELECT a.Customer_Id, b.prename_dec + '.' + a.Name + '  ' + a.SurName AS CustomerFullName FROM OF_Customer a INNER JOIN OF_Prename b ON a.Prename_Id = b.Prename_Id WHERE a.Client_Id = " & Me.drpClientOwner.SelectedValue & " order by a.name")
        func.BindControl(Me.chbCusLeader, 0, "SELECT a.Customer_Id, b.prename_dec + '.' + a.Name + '  ' + a.SurName AS CustomerFullName FROM OF_Customer a INNER JOIN OF_Prename b ON a.Prename_Id = b.Prename_Id WHERE a.Client_Id = " & Me.drpClientOwner.SelectedValue & " order by a.name")
        func.BindControl(Me.chbProjectManager, 0, "select a.member_id,b.prename_dec+'.'+a.name+' '+a.surname as MemberFullName From Of_member a,of_Prename b Where a.Prename_Id = b.Prename_Id  and Member_type='Human'order by a.name")
        func.BindControl(Me.chbProjectLeader, 0, "select a.member_id,b.prename_dec+'.'+a.name+' '+a.surname as MemberFullName From Of_member a,of_Prename b Where a.Prename_Id = b.Prename_Id  and Member_type='Human'order by a.name")
        func.BindControl(Me.chbProjectTeam, 0, "select a.member_id,b.prename_dec+'.'+a.name+' '+a.surname as MemberFullName From Of_member a,of_Prename b Where a.Prename_Id = b.Prename_Id  and Member_type='Human'order by a.name")
        chbOperateBranch.Visible = True
        Panel1.Visible = True
        drpBillTo.Visible = True
        chbContractPerson.Visible = True
        chbCusManager.Visible = True
        chbCusLeader.Visible = True
        chbProjectManager.Visible = True
        chbProjectLeader.Visible = True
        chbProjectTeam.Visible = True
        ButExpandProjectTeam.Text = "Hide"
        butExpandProLeader.Text = "Hide"
        butProjectManager.Text = "Hide"
        butExpenContractPerson.Text = "Hide"
        butExpanCusManager.Text = "Hide"
        butExpanCusLeader.Text = "Hide"

    End Sub



    Protected Sub butExpandProLeader_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butExpandProLeader.Click
        If Not chbProjectLeader.Visible Then
            butExpandProLeader.Text = "Hide"
            chbProjectLeader.Visible = True
            func.BindControl(Me.chbProjectLeader, 0, "select a.member_id,b.prename_dec+'.'+a.name+' '+a.surname as MemberFullName From Of_member a,of_Prename b Where a.Prename_Id = b.Prename_Id  and Member_type='Human'")
        Else
            butExpandProLeader.Text = "Expand"
            chbProjectLeader.Visible = False
        End If
    End Sub

    Protected Sub ButExpandProjectTeam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButExpandProjectTeam.Click
        If Not chbProjectTeam.Visible Then
            ButExpandProjectTeam.Text = "Hide"
            chbProjectTeam.Visible = True
            func.BindControl(Me.chbProjectTeam, 0, "select a.member_id,b.prename_dec+'.'+a.name+' '+a.surname as MemberFullName From Of_member a,of_Prename b Where a.Prename_Id = b.Prename_Id  and Member_type='Human'")
        Else
            ButExpandProjectTeam.Text = "Expand"
            chbProjectTeam.Visible = False
        End If
    End Sub

    Protected Sub butProjectManager_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butProjectManager.Click
        If Not chbProjectManager.Visible Then
            butProjectManager.Text = "Hide"
            chbProjectManager.Visible = True
            func.BindControl(Me.chbProjectManager, 0, "select a.member_id,b.prename_dec+'.'+a.name+' '+a.surname as MemberFullName From Of_member a,of_Prename b Where a.Prename_Id = b.Prename_Id  and Member_type='Human'")

        Else
            butProjectManager.Text = "Expand"
            chbProjectManager.Visible = False
        End If
    End Sub

    Protected Sub butExpenContractPerson_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butExpenContractPerson.Click
        If Not chbContractPerson.Visible Then
            func.BindControl(Me.chbContractPerson, 0, "SELECT a.Customer_Id, b.prename_dec + '.' + a.Name + '  ' + a.SurName AS CustomerFullName FROM OF_Customer a INNER JOIN OF_Prename b ON a.Prename_Id = b.Prename_Id WHERE a.Client_Id = " & Me.drpClientOwner.SelectedValue)
            butExpenContractPerson.Text = "Hide"
            chbContractPerson.Visible = True
        Else
            butExpenContractPerson.Text = "Expand"
            chbContractPerson.Visible = False
        End If
    End Sub

    Protected Sub butExpanCusManager_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butExpanCusManager.Click
        If Not chbCusManager.Visible Then
            func.BindControl(Me.chbCusManager, 0, "SELECT a.Customer_Id, b.prename_dec + '.' + a.Name + '  ' + a.SurName AS CustomerFullName FROM OF_Customer a INNER JOIN OF_Prename b ON a.Prename_Id = b.Prename_Id WHERE a.Client_Id = " & Me.drpClientOwner.SelectedValue & "order by a.name,a.surname")
            butExpanCusManager.Text = "Hide"
            chbCusManager.Visible = True
        Else
            butExpanCusManager.Text = "Expand"
            chbCusManager.Visible = False
        End If
    End Sub

    Protected Sub butExpanCusLeader_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butExpanCusLeader.Click
        If Not chbCusLeader.Visible Then
            func.BindControl(Me.chbCusLeader, 0, "SELECT a.Customer_Id, b.prename_dec + '.' + a.Name + '  ' + a.SurName AS CustomerFullName FROM OF_Customer a INNER JOIN OF_Prename b ON a.Prename_Id = b.Prename_Id WHERE a.Client_Id = " & Me.drpClientOwner.SelectedValue & "order by a.name,a.surname")
            butExpanCusLeader.Text = "Hide"
            chbCusLeader.Visible = True
        Else
            butExpanCusLeader.Text = "Expand"
            chbCusLeader.Visible = False
        End If

    End Sub

    Protected Sub butShowAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butShowAll.Click
        ClearLoader()
        sql = "Select a.Project_Id,a.Project_Code,a.Project_Name,b.Client_Name as Client_Name From OF_Project a,OF_Client b Where a.ClientOwner_id=b.Client_Id and a.Project_Status <>'Close'"
        func.BindControl(Me.rptShowProject, 0, sql & " order by project_code")
        SetVisibleBut("SHOWALL")
        lblTempSQL.Text = sql
        rptShowProject.Visible = True

    End Sub

    Sub SetVisibleBut(ByVal Mode As String)
        Select Case UCase(Mode)
            Case "QUERY", "CANCEL", "DELETE", "SHOWALL"
                'Me.butQuery.Visible = True
                Me.butSave.Visible = True
                Me.butUpdate.Visible = False
                Me.butDelete.Visible = False
                Me.butCancel.Visible = False
            Case "SAVE", "SELECT", "UPDATE"
                ' Me.butQuery.Visible = False
                Me.butSave.Visible = False
                Me.butUpdate.Visible = True
                Me.butDelete.Visible = True
                Me.butCancel.Visible = True
        End Select
    End Sub

    Sub InsertSelectCHB(ByRef CrtCheckBoxList As CheckBoxList, ByVal ls_InsertSRT As String, ByVal ls_TableName As String, ByVal ParmId As String)

        Dim li_i As Int16
        Dim srt_Row As String = " Member_Id "
        Dim bufSQL As String = ""

        sql = "Delete From " & ls_TableName & " Where Project_Id = " & ParmId
        func.CmdSQL(sql)
        sql = ""

        For li_i = 0 To CrtCheckBoxList.Items.Count - 1
            If CrtCheckBoxList.Items(li_i).Selected Then
                bufSQL = ls_InsertSRT & " Values(" & ParmId & "," & CrtCheckBoxList.Items(li_i).Value & ");"
                sql = sql + bufSQL
            End If
        Next

        func.CmdSQL(sql)
    End Sub

    Function CountSelected(ByVal CrtCheckBoxList As CheckBoxList) As Int16
        Dim li_i As Int16 = 0
        Dim li_count As Int16 = 0
        For li_i = 0 To CrtCheckBoxList.Items.Count - 1
            If CrtCheckBoxList.Items(li_i).Selected Then
                li_count = li_count + 1
            End If
        Next
        CountSelected = li_count
    End Function
    Protected Sub butSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butSave.Click
        Dim Error_Msg As String = ""
        If Me.chbOperateBranch.Items.Count = 0 Then Error_Msg = "Plese Create Client Branch <br>" & Error_Msg
        If Me.chbCusManager.Items.Count = 0 Then Error_Msg = "Plese Create Client Manager <br>" & Error_Msg
        If Me.chbCusLeader.Items.Count = 0 Then Error_Msg = "Plese Create Client Leader <br>" & Error_Msg
        If Me.chbContractPerson.Items.Count = 0 Then Error_Msg = "Plese Create Contractperson <br>" & Error_Msg
        If Me.chbProjectManager.Items.Count = 0 Then Error_Msg = "Plese Create Manager <br>" & Error_Msg
        If Me.chbProjectLeader.Items.Count = 0 Then Error_Msg = "Plese Create Leader <br>" & Error_Msg
        If Me.chbProjectTeam.Items.Count = 0 Then Error_Msg = "Plese Create Members <br>" & Error_Msg
        '-----------------------
        If CountSelected(chbOperateBranch) = 0 Then Error_Msg = "Plese Select Client Branch <br>" & Error_Msg
        If CountSelected(chbCusManager) = 0 Then Error_Msg = "Plese Select Client Manager <br>" & Error_Msg
        If CountSelected(chbCusLeader) = 0 Then Error_Msg = "Plese Select Client Leader <br>" & Error_Msg
        If CountSelected(chbContractPerson) = 0 Then Error_Msg = "Plese Select Contractperson <br>" & Error_Msg
        If CountSelected(chbProjectManager) = 0 Then Error_Msg = "Plese Select Manager <br>" & Error_Msg
        If CountSelected(chbProjectLeader) = 0 Then Error_Msg = "Plese Select Leader <br>" & Error_Msg
        If CountSelected(chbProjectTeam) = 0 Then Error_Msg = "Plese Select Members <br>" & Error_Msg
        '-----------------------

        If Error_Msg = "" Then
            Dim li_id As Int16
            sql = "Insert Into OF_Project (Project_Code,Project_Name,ClientOwner_Id,Start_Date,Dulation,Billing_to,BillingAddress,Methodology,Project_Status,billing_no)values('" & func.FixData(Me.txtProjectCode.Text) & "','" & func.FixData(Me.txtProjectName.Text) & "'," & Me.drpClientOwner.SelectedValue & ",'" & func.FixData(Me.txtDate.Text) & "'," & func.FixData(Me.txtDulation.Text) & "," & Me.drpBillTo.SelectedValue & ",'" & func.FixData(Me.TxtBillAddress.Text) & "'," & Me.drpMethodology.SelectedValue & ",'Start','" & func.FixData(txtBilling.Text) & "');SELECT max(@@IDENTITY)"
            func.CmdSQL(sql)
            ds = func.Getdataset("select project_id from OF_Project where project_code ='" & txtProjectCode.Text.Replace("'", "''") & "' and project_name ='" & txtProjectName.Text.Replace("'", "''") & "'")
            If ds.Tables(0).Rows.Count > 0 Then
                li_id = Val(ds.Tables(0).Rows(0)("project_id").ToString)
            End If
            'lblProject_Id.Text = func.CmdSQL(sql)
            'li_id = Val(lblProject_Id.Text)
            InsertSelectCHB(Me.chbOperateBranch, "Insert Into OF_ProjectBranch (Project_Id,Client_Id)", "OF_ProjectBranch", li_id)
            InsertSelectCHB(Me.chbCusManager, "Insert Into OF_ProjectCusManager(Project_Id,Customer_Id)", "OF_ProjectCusManager", li_id)
            InsertSelectCHB(Me.chbCusLeader, "Insert Into OF_ProjectCusLeader(Project_Id,Customer_Id)", "OF_ProjectCusLeader", li_id)
            InsertSelectCHB(Me.chbContractPerson, "Insert Into OF_ProjectCusContract(Project_Id,Customer_Id)", "OF_ProjectCusContract", li_id)
            InsertSelectCHB(Me.chbProjectManager, "Insert Into OF_ProjectManager(Project_Id,Member_Id)", "OF_ProjectManager", li_id)
            InsertSelectCHB(Me.chbProjectLeader, "Insert Into OF_ProjectLeader(Project_Id,Member_Id)", "OF_ProjectLeader", li_id)
            InsertSelectCHB(Me.chbProjectTeam, "Insert Into OF_ProjectTeam(Project_Id,Member_Id)", "OF_ProjectTeam", li_id)
            lblError.CssClass = "successBox"
            lblError.Text = "Record has been add successfully."
            lblError.Visible = True
            func.BindControl(Me.rptShowProject, 0, "Select a.Project_Id,a.Project_Code,a.Project_Name,b.Client_Name as Client_Name From OF_Project a,OF_Client b Where a.ClientOwner_id=b.Client_Id and a.Project_Status <>'Close' and Project_Id <>" & li_id)
            'func.CmdSQL("Update of_member set Allow_menu = replace(Allow_menu,',44','')  where allow_menu <> '*' and member_id not in (select member_id from OF_ProjectManager)and Allow_menu like '%,44%';Update of_member set Allow_menu = Allow_menu+',44'  where allow_menu <> '*' and member_id in (select member_id from OF_ProjectManager)and Allow_menu not like '%,44%';")
            func.CmdSQL("Update of_member set Allow_menu = replace(Allow_menu,',44','')  where allow_menu <> '*' and member_id not in (select member_id from OF_ProjectLeader)and Allow_menu like '%,44%';Update of_member set Allow_menu = Allow_menu+',44'  where allow_menu <> '*' and member_id in (select member_id from OF_ProjectLeader)and Allow_menu not like '%,44%';")
            SetVisibleBut("Save")
        Else
            'ClearLoader()
            lblError.CssClass = "errorBox"
            lblError.Text = Error_Msg
            SetVisibleBut("CANCEL")
            lblError.Visible = True
        End If
    End Sub
    Sub ClearLoader()
        lblProject_Id.Text = ""
        Me.txtProjectCode.Text = ""
        txtProjectName.Text = ""
        txtDate.Text = ""
        txtDulation.Text = ""
        drpClientOwner.SelectedIndex = 0
        butExpBranch.Text = "Expand"
        chbOperateBranch.Visible = False
        drpBillTo.SelectedIndex = 0
        TxtBillAddress.Text = ""
        butExpanCusManager.Text = "Expand"
        chbCusManager.Visible = False
        butExpanCusLeader.Text = "Expand"
        chbCusLeader.Visible = False
        butExpenContractPerson.Text = "Expand"
        chbContractPerson.Visible = False
        butProjectManager.Text = "Expand"
        chbProjectManager.Visible = False
        butExpandProLeader.Text = "Expand"
        chbProjectLeader.Visible = False
        ButExpandProjectTeam.Text = "Expand"
        chbProjectTeam.Visible = False
        drpMethodology.SelectedIndex = 0
        lblError.Text = ""
        lblError.Visible = False
    End Sub
    Protected Sub butDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butDelete.Click
        'sql = "Delete from OF_Project Where Project_Id = " & Me.lblProject_Id.Text
        'ยังขาดการไร delet ลูก
        ' func.CmdSQL(sql)
        lblError.CssClass = "successBox"
        lblError.Text = "Record has been Delete Successfully."
        SetVisibleBut("DELETE")
        lblError.Visible = True
        ClearLoader()
    End Sub

    Protected Sub butCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butCancel.Click
        SetVisibleBut("CANCEL")
        ClearLoader()
        rptShowProject.Visible = False
        lblTempSQL.Text = ""
    End Sub


    Protected Sub butDelete_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles butDelete.Init
        butDelete.Attributes("onclick") = "return confirm('Are you sure you want to delete?');"
    End Sub

    Protected Sub butUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butUpdate.Click
        Dim Error_Msg As String = ""
        Dim id As String = ""
        For i As Int32 = 0 To chbOperateBranch.Items.Count - 1
            If chbOperateBranch.Items(i).Selected = False Then
                ds = func.Getdataset("select id from OF_ProjectBranch where project_id ='" & func.FixData(lblProject_Id.Text) & "' and Client_Id ='" & chbOperateBranch.Items(i).Value & "'")
                If ds.Tables(0).Rows.Count > 0 Then
                    id = ds.Tables(0).Rows(0)("id").ToString
                End If
                ds = func.Getdataset("select ProjectBranch_id from OF_TimeAttendance where ProjectBranch_id ='" & id & "'")
                If ds.Tables(0).Rows.Count > 0 Then
                    lblError.Text = "ข้อมูล Site Branch มีการเชื่อมโยงกับข้อมูลอื่น" & vbCrLf & "ไม่สามารถทำการแก้ไขได้"
                    lblError.Visible = True
                    Exit Sub
                End If
            End If
        Next

        'Dim _str As String = "select id from OF_ProjectBranch where project_id=" & Val(lblProject_Id.Text) & " and Client_Id="

        If Me.chbOperateBranch.Items.Count = 0 Then Error_Msg = "Plese Create Client Branch <br>" & Error_Msg
        If Me.chbCusManager.Items.Count = 0 Then Error_Msg = "Plese Create Client Manager <br>" & Error_Msg
        If Me.chbCusLeader.Items.Count = 0 Then Error_Msg = "Plese Create Client Leader <br>" & Error_Msg
        If Me.chbContractPerson.Items.Count = 0 Then Error_Msg = "Plese Create Contractperson <br>" & Error_Msg
        If Me.chbProjectManager.Items.Count = 0 Then Error_Msg = "Plese Create Manager <br>" & Error_Msg
        If Me.chbProjectLeader.Items.Count = 0 Then Error_Msg = "Plese Create Leader <br>" & Error_Msg
        If Me.chbProjectTeam.Items.Count = 0 Then Error_Msg = "Plese Create Members <br>" & Error_Msg
        '-----------------------
        If CountSelected(chbOperateBranch) = 0 Then Error_Msg = "Plese Select Client Branch <br>" & Error_Msg
        If CountSelected(chbCusManager) = 0 Then Error_Msg = "Plese Select Client Manager <br>" & Error_Msg
        If CountSelected(chbCusLeader) = 0 Then Error_Msg = "Plese Select Client Leader <br>" & Error_Msg
        If CountSelected(chbContractPerson) = 0 Then Error_Msg = "Plese Select Contractperson <br>" & Error_Msg
        If CountSelected(chbProjectManager) = 0 Then Error_Msg = "Plese Select Manager <br>" & Error_Msg
        If CountSelected(chbProjectLeader) = 0 Then Error_Msg = "Plese Select Leader <br>" & Error_Msg
        If CountSelected(chbProjectTeam) = 0 Then Error_Msg = "Plese Select Members <br>" & Error_Msg
        '-----------------------
        
        If Error_Msg = "" Then
            Dim li_id As Int16
            sql = "Update OF_Project Set Project_Code='" & func.FixData(Me.txtProjectCode.Text) & "',Project_Name='" & func.FixData(Me.txtProjectName.Text) & "',ClientOwner_Id=" & Me.drpClientOwner.SelectedValue & ",Start_Date='" & func.FixData(Me.txtDate.Text) & "',Dulation=" & func.FixData(Me.txtDulation.Text) & ",Billing_to=" & Me.drpBillTo.SelectedValue & ",BillingAddress='" & func.FixData(Me.TxtBillAddress.Text) & "',Methodology=" & Me.drpMethodology.SelectedValue & ",billing_no='" & func.FixData(txtBilling.Text) & "' Where Project_Id = " & func.FixData(Me.lblProject_Id.Text)
            func.CmdSQL(sql)
            li_id = lblProject_Id.Text

            'InsertSelectCHB(Me.chbOperateBranch, "Insert Into OF_ProjectBranch (Project_Id,Client_Id)", "OF_ProjectBranch", li_id)
            For i As Int32 = 0 To chbOperateBranch.Items.Count - 1
                If chbOperateBranch.Items(i).Selected = False Then
                    func.CmdSQL("delete from OF_ProjectBranch where Project_Id ='" & li_id & "' and Client_Id ='" & chbOperateBranch.Items(i).Value & "'")
                Else
                    ds = func.Getdataset("select id from OF_ProjectBranch where Project_Id ='" & li_id & "' and Client_Id ='" & chbOperateBranch.Items(i).Value & "'")
                    If ds.Tables(0).Rows.Count = 0 Then
                        func.CmdSQL("insert into OF_ProjectBranch(Project_Id,Client_Id) values('" & li_id & "','" & chbOperateBranch.Items(i).Value & "')")
                    End If
                End If
            Next
            InsertSelectCHB(Me.chbCusManager, "Insert Into OF_ProjectCusManager(Project_Id,Customer_Id)", "OF_ProjectCusManager", li_id)
            InsertSelectCHB(Me.chbCusLeader, "Insert Into OF_ProjectCusLeader(Project_Id,Customer_Id)", "OF_ProjectCusLeader", li_id)
            InsertSelectCHB(Me.chbContractPerson, "Insert Into OF_ProjectCusContract(Project_Id,Customer_Id)", "OF_ProjectCusContract", li_id)
            InsertSelectCHB(Me.chbProjectManager, "Insert Into OF_ProjectManager(Project_Id,Member_Id)", "OF_ProjectManager", li_id)
            InsertSelectCHB(Me.chbProjectLeader, "Insert Into OF_ProjectLeader(Project_Id,Member_Id)", "OF_ProjectLeader", li_id)
            InsertSelectCHB(Me.chbProjectTeam, "Insert Into OF_ProjectTeam(Project_Id,Member_Id)", "OF_ProjectTeam", li_id)
            lblError.CssClass = "successBox"
            lblError.Text = "Record has been Update successfully."
            lblError.Visible = True
            func.BindControl(Me.rptShowProject, 0, "Select a.Project_Id,a.Project_Code,a.Project_Name,b.Client_Name as Client_Name From OF_Project a,OF_Client b Where a.ClientOwner_id=b.Client_Id and a.Project_Status <>'Close' and Project_Id <>" & func.FixData(Me.lblProject_Id.Text) & " order by project_code")
            func.CmdSQL("Update of_member set Allow_menu = replace(Allow_menu,',44','')  where allow_menu <> '*' and member_id not in (select member_id from OF_ProjectLeader)and Allow_menu like '%,44%';Update of_member set Allow_menu = Allow_menu+',44'  where allow_menu <> '*' and member_id in (select member_id from OF_ProjectLeader)and Allow_menu not like '%,44%';")

            SetVisibleBut("UPDATE")
        Else
            ClearLoader()
            lblError.CssClass = "errorBox"
            lblError.Text = Error_Msg
            SetVisibleBut("CANCEL")
            lblError.Visible = True
        End If
    End Sub

End Class
