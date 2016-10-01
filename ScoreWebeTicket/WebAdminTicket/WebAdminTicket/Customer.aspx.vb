Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class Customer
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Support-TicketConnectionString").ConnectionString)
    Dim Cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("state") = Nothing Then
            Response.Write("<script>alert('Will have to login before')</script>")
            Response.Write("<script>window.location.href='Login.aspx';</script>")
        End If
        If Not IsPostBack Then
            RadGrid4.DataSource = Data() ' bind account in gridview4
            RadGrid4.DataBind()
        End If
    End Sub
    Private Function Data() As DataSet 'ฟังก์ชั่น ดึงข้อมูลจาก Account มาโชวที่ gridview
        Dim text As String = "SELECT ROW_NUMBER() OVER(ORDER BY account_id DESC) AS Row,account_id,account_code,account_name FROM TICKET_ACCOUNT "
        Dim cmd As New SqlCommand(text, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        con.Close()
        Return ds
    End Function
    Public Function DataSearchgrid7(ByVal s1 As String) As DataSet 'ฟังก์ชั่นดึงข้อมูล Branch ที่เกี่ยวข้องกับ account ที่กด Edit จาก gridview 
        Dim sq As String
        sq = "Select branch_id,branch_code,branch_name,account_id from TICKET_BRANCH where "
        sq += "account_id Like '%" & Session("aid") & "%'"
        Dim cmd As New SqlCommand(sq, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        con.Close()
        Return ds
    End Function
    Public Function DataSearchgrid8(ByVal s1 As String) As DataSet 'ฟังก์ชั่นดึงข้อมูล Conntact ที่เกี่ยวข้องกับ account ที่กด Edit จาก gridview
        Dim sq As String
        sq = "Select contact_id,contact_code,contact_name,contact_tell,contact_email,account_id from TICKET_CONTACT_PERSON where "
        sq += "account_id Like '%" & Session("aid") & "%'"
        Dim cmd As New SqlCommand(sq, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        con.Close()
        Return ds
    End Function
    Public Function DataSearchgrid9(ByVal s1 As String) As DataSet 'ฟังก์ชั่นดึงข้อมูล project ที่เกี่ยวข้องกับ account ที่กด Edit จาก gridview
        Dim sq As String
        sq = "Select id,project_code,project_name,project_desc,account_id from TICKET_PROJECT where "
        sq += "account_id Like '%" & Session("aid") & "%'"
        Dim cmd As New SqlCommand(sq, con)
        con.Open()
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        con.Close()
        Return ds
    End Function
    Protected Sub RadGrid4_PageIndexChanged(source As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGrid4.PageIndexChanged
        RadGrid4.CurrentPageIndex = e.NewPageIndex
        RadGrid4.DataSource = Data()
        RadGrid4.DataBind()
    End Sub
    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click 'เซฟ account ที่สร้าง
        con.Open()
        ' check account code repeat yes or no 
        Dim chn As String
        chn = "Select account_code,account_name from TICKET_ACCOUNT where account_code = '" & txtcode.Text & "'or account_name = '" & txtname.Text & "'"
        Dim cmd As New SqlCommand(chn, con)
        Dim chk As SqlDataReader = cmd.ExecuteReader
        If chk.Read = True Then ' yes
            chk.Close()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('This Accountcode or Accountname is repeat.');", True)
            txtcode.Text = ""
            txtname.Text = ""
        Else ' no
            chk.Close()
            Dim chg1 As Integer = RadGrid1.Items.Count 'get branch from grid
            Dim chg5 As Integer = RadGrid5.Items.Count 'get contact from grid
            Dim chg6 As Integer = RadGrid6.Items.Count 'get project from grid
            If txtcode.Text = "" Or txtname.Text = "" Or chg1 = 0 Or chg5 = 0 Or chg6 = 0 Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "AlertBox", "alert('Information is not complete.');", True)
            Else 'insert account 
                Dim sql As String = "Insert Into TICKET_ACCOUNT(create_by,create_on,account_code,account_name) " & _
                        "  Values('" & Session("state") & "',Getdate(),'" & txtcode.Text & "','" & txtname.Text & "')"
                With cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Connection = con
                    .ExecuteNonQuery()
                End With

                For i As Integer = 0 To RadGrid1.Items.Count - 1 'insert branch in grid
                    Try
                        Dim strvalue As String = RadGrid1.Items(i).Item("column").Text
                        Dim strvalue1 As String = RadGrid1.Items(i).Item("column1").Text
                        Dim strvalue2 As String = RadGrid1.Items(i).Item("column2").Text

                        Dim sql1 As String = "insert into TICKET_BRANCH(create_by,create_on,branch_code,branch_name,branch_sla,account_id) " & _
                                      "Values('" & Session("state") & "',Getdate(),'" & strvalue & "','" & strvalue1 & "','" & Convert.ToInt32(strvalue2) & "',(select account_id from TICKET_ACCOUNT where account_code = '" & txtcode.Text & "'))"

                        With cmd
                            .CommandType = CommandType.Text
                            .CommandText = sql1
                            .Connection = con
                            .ExecuteNonQuery()
                        End With
                    Catch ex As Exception
                        ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "AlertBox", "alert('Error! Please try again.');", True)
                    End Try
                Next

                For i1 As Integer = 0 To RadGrid5.Items.Count - 1 'insert contact in grid
                    Try
                        Dim strvalue As String = RadGrid5.Items(i1).Item("column").Text
                        Dim strvalue1 As String = RadGrid5.Items(i1).Item("column1").Text
                        Dim strvalue2 As String = RadGrid5.Items(i1).Item("column2").Text
                        Dim strvalue3 As String = RadGrid5.Items(i1).Item("column3").Text

                        Dim sql2 As String = "insert into TICKET_CONTACT_PERSON(create_by,create_on,contact_code,contact_name,contact_tell,contact_email,account_id) " & _
                                      "Values('" & Session("state") & "',Getdate(),'" & strvalue & "','" & strvalue1 & "','" & strvalue2 & "','" & strvalue3 & "',(select account_id from TICKET_ACCOUNT where account_code = '" & txtcode.Text & "'))"

                        With cmd
                            .CommandType = CommandType.Text
                            .CommandText = sql2
                            .Connection = con
                            .ExecuteNonQuery()
                        End With
                    Catch ex As Exception
                        ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "AlertBox", "alert('Error! Please try again.');", True)
                    End Try
                Next

                For i2 As Integer = 0 To RadGrid6.Items.Count - 1 'insert project in grid
                    Try
                        Dim strvalue As String = RadGrid6.Items(i2).Item("column").Text
                        Dim strvalue1 As String = RadGrid6.Items(i2).Item("column1").Text
                        Dim strvalue2 As String = RadGrid6.Items(i2).Item("column2").Text
                        Dim strvalue3 As String = RadGrid6.Items(i2).Item("column3").Text

                        Dim sql3 As String = "insert into TICKET_PROJECT(create_by,create_on,project_code,project_name,project_desc,account_id,staff_id) " & _
                                      "Values('" & Session("state") & "',Getdate(),'" & strvalue & "','" & strvalue1 & "','" & strvalue2 & "',(select account_id from TICKET_ACCOUNT where account_code = '" & txtcode.Text & "'),(select id from TICKET_STAFF where staffname = '" & strvalue3 & "'))"

                        With cmd
                            .CommandType = CommandType.Text
                            .CommandText = sql3
                            .Connection = con
                            .ExecuteNonQuery()
                        End With
                    Catch ex As Exception
                        ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "AlertBox", "alert('Error! Please try again.');", True)
                    End Try
                Next
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Insert Complete.'); window.location='" + Request.ApplicationPath + "/Customer.aspx';", True)
            End If
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'add branch to gridview1
        If txtbcode.Text = "" Or txtbname.Text = "" Or txtbsla.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Information is not complete.');", True)
        Else
            RadGrid1.Visible = True
            RadGrid7.Visible = False

            Dim dt As New DataTable
            dt.Columns.Add("column")
            dt.Columns.Add("column1")
            dt.Columns.Add("column2")
            Dim dr As DataRow

            For i As Integer = 0 To RadGrid1.Items.Count - 1
                dr = dt.NewRow
                dr.Item("column") = RadGrid1.Items(i).Item("column").Text
                dr.Item("column1") = RadGrid1.Items(i).Item("column1").Text
                dr.Item("column2") = RadGrid1.Items(i).Item("column2").Text
                dt.Rows.Add(dr)
            Next

            dr = dt.NewRow
            dr.Item("column") = txtbcode.Text
            dr.Item("column1") = txtbname.Text
            dr.Item("column2") = txtbsla.Text
            dt.Rows.Add(dr)
            RadGrid1.DataSource = dt
            RadGrid1.DataBind()
            Session("dtc1") = dt

            txtbcode.Text = ""
            txtbname.Text = ""
            txtbsla.Text = ""
        End If
    End Sub
    Protected Sub RadGrid1_PageIndexChanged(source As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGrid1.PageIndexChanged
        RadGrid1.CurrentPageIndex = e.NewPageIndex
        RadGrid1.DataSource = Session("dt")
        RadGrid1.DataBind()
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'add contact to gridview5
        If txtconC.Text = "" Or txtconE.Text = "" Or txtconN.Text = "" Or txtconT.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Information is not complete.');", True)
        Else
            RadGrid5.Visible = True
            RadGrid8.Visible = False

            Dim dt1 As New DataTable
            dt1.Columns.Add("column")
            dt1.Columns.Add("column1")
            dt1.Columns.Add("column2")
            dt1.Columns.Add("column3")
            Dim dr As DataRow

            For i As Integer = 0 To RadGrid5.Items.Count - 1
                dr = dt1.NewRow
                dr.Item("column") = RadGrid5.Items(i).Item("column").Text
                dr.Item("column1") = RadGrid5.Items(i).Item("column1").Text
                dr.Item("column2") = RadGrid5.Items(i).Item("column2").Text
                dr.Item("column3") = RadGrid5.Items(i).Item("column3").Text
                dt1.Rows.Add(dr)
            Next

            dr = dt1.NewRow
            dr.Item("column") = txtconC.Text
            dr.Item("column1") = txtconN.Text
            dr.Item("column2") = txtconT.Text
            dr.Item("column3") = txtconE.Text
            dt1.Rows.Add(dr)
            RadGrid5.DataSource = dt1
            RadGrid5.DataBind()
            Session("dtc2") = dt1

            txtconC.Text = ""
            txtconE.Text = ""
            txtconT.Text = ""
            txtconN.Text = ""
        End If
    End Sub
    Protected Sub RadGrid5_PageIndexChanged(source As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGrid5.PageIndexChanged
        RadGrid1.CurrentPageIndex = e.NewPageIndex
        RadGrid1.DataSource = Session("dt1")
        RadGrid1.DataBind()
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click 'add project to gridview6
        If txtpoC.Text = "" Or txtpoD.Text = "" Or txtpoN.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Information is not complete.');", True)
        Else
            RadGrid6.Visible = True
            RadGrid9.Visible = False

            Dim dt2 As New DataTable
            dt2.Columns.Add("column")
            dt2.Columns.Add("column1")
            dt2.Columns.Add("column2")
            dt2.Columns.Add("column3")
            Dim dr As DataRow

            For i As Integer = 0 To RadGrid6.Items.Count - 1
                dr = dt2.NewRow
                dr.Item("column") = RadGrid6.Items(i).Item("column").Text
                dr.Item("column1") = RadGrid6.Items(i).Item("column1").Text
                dr.Item("column2") = RadGrid6.Items(i).Item("column2").Text
                dr.Item("column3") = RadGrid6.Items(i).Item("column3").Text
                dt2.Rows.Add(dr)
            Next
            dr = dt2.NewRow
            dr.Item("column") = txtpoC.Text
            dr.Item("column1") = txtpoN.Text
            dr.Item("column2") = txtpoD.Text
            dr.Item("column3") = DropDownList1.Text
            dt2.Rows.Add(dr)
            RadGrid6.DataSource = dt2
            RadGrid6.DataBind()
            Session("dtc3") = dt2

            txtpoC.Text = ""
            txtpoD.Text = ""
            txtpoN.Text = ""
        End If
    End Sub
    Protected Sub RadGrid6_PageIndexChanged(source As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGrid6.PageIndexChanged
        RadGrid1.CurrentPageIndex = e.NewPageIndex
        RadGrid1.DataSource = Session("dt2")
        RadGrid1.DataBind()
    End Sub
    Protected Sub RadGrid1_DeleteCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid1.DeleteCommand 'delete branch from gridview1
        Dim item As GridDataItem = e.Item
        Dim ID As String = item("column").Text
        Dim table As DataTable = CType(Session("dtc1"), DataTable)
        If table IsNot Nothing Then
            table.Rows(item.ItemIndex).Delete()
            table.AcceptChanges()
            RadGrid1.DataSource = table
            RadGrid1.DataBind()
        End If
    End Sub
    Protected Sub RadGrid5_DeleteCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid5.DeleteCommand 'delete contact from gridview5
        Dim item As GridDataItem = e.Item
        Dim ID As String = item("column").Text
        Dim table As DataTable = CType(Session("dtc2"), DataTable)
        If table IsNot Nothing Then
            table.Rows(item.ItemIndex).Delete()
            table.AcceptChanges()
            RadGrid5.DataSource = table
            RadGrid5.DataBind()
        End If
    End Sub
    Protected Sub RadGrid6_DeleteCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid6.DeleteCommand ' delete project from gridview6
        Dim item As GridDataItem = e.Item
        Dim ID As String = item("column").Text
        Dim table As DataTable = CType(Session("dtc3"), DataTable)
        If table IsNot Nothing Then
            table.Rows(item.ItemIndex).Delete()
            table.AcceptChanges()
            RadGrid6.DataSource = table
            RadGrid6.DataBind()
        End If
    End Sub
    Protected Sub RadGrid4_EditCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid4.EditCommand
        'show branch,contact,project of account edit click
        Dim aidt As Label = e.Item.FindControl("Label3")
        Session("aid") = aidt.Text
        RadGrid7.Visible = True
        RadGrid8.Visible = True
        RadGrid9.Visible = True
        RadGrid7.DataSource = DataSearchgrid7(aidt.Text)
        RadGrid7.DataBind()
        RadGrid8.DataSource = DataSearchgrid8(aidt.Text)
        RadGrid8.DataBind()
        RadGrid9.DataSource = DataSearchgrid9(aidt.Text)
        RadGrid9.DataBind()
        RadGrid4.DataSource = Data()
        RadGrid4.DataBind()
    End Sub
    Protected Sub RadGrid4_DeleteCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid4.DeleteCommand
        con.Open()
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
            If e.CommandName = "Delete" Then
                'find id account 
                Dim aidt As Label = e.Item.FindControl("Label3")
                Dim sqt As String = "Select TICKET_ACCOUNT.account_id from TICKET_ACCOUNT join TICKET_TICKET on TICKET_ACCOUNT.account_id = TICKET_TICKET.account_id"
                Dim cmdt As New SqlCommand(sqt, con)
                Dim dat As New SqlDataAdapter(cmdt)
                Dim dst As New DataSet()
                dat.Fill(dst)
                Dim idselt As String
                For i As Integer = 0 To dst.Tables(0).Rows.Count - 1
                    idselt = (dst.Tables(0).Rows(i).Item("account_id").ToString) 'if this account have user using cannot delete
                    If aidt.Text = idselt Then
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Cannot delete! This Account is using.'); window.location='" + Request.ApplicationPath + "/Customer.aspx';", True)
                        Return
                    End If
                Next
                'find account id from project for delete
                Dim aid As Label = e.Item.FindControl("Label3")
                Dim sq As String = "Select TICKET_ACCOUNT.account_id from TICKET_ACCOUNT join TICKET_PROJECT on TICKET_ACCOUNT.account_id = TICKET_PROJECT.account_id"
                Dim cmd1 As New SqlCommand(sq, con)
                Dim da As New SqlDataAdapter(cmd1)
                Dim ds As New DataSet()
                da.Fill(ds)
                Dim idsel As String
                For i1 As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    idsel = (ds.Tables(0).Rows(i1).Item("account_id").ToString)
                    If aid.Text = idsel Then 'delete project of this account selected
                        Dim psq As String = "DELETE FROM TICKET_PROJECT Where account_id = '" + aid.Text + "'"
                        With Cmd
                            .CommandType = CommandType.Text
                            .CommandText = psq
                            .Connection = con
                            .ExecuteNonQuery()
                        End With
                    End If
                Next
                'find account from branch
                Dim sq1 As String = "Select TICKET_ACCOUNT.account_id from TICKET_ACCOUNT join TICKET_BRANCH on TICKET_ACCOUNT.account_id = TICKET_BRANCH.account_id"
                Dim cmd2 As New SqlCommand(sq1, con)
                Dim da1 As New SqlDataAdapter(cmd2)
                Dim ds1 As New DataSet()
                da1.Fill(ds1)
                Dim idsel1 As String
                For i2 As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                    idsel1 = (ds1.Tables(0).Rows(i2).Item("account_id").ToString)
                    If aid.Text = idsel1 Then 'delete branch of this account selected
                        Dim bsq As String = "DELETE FROM TICKET_BRANCH Where account_id = '" + aid.Text + "'"
                        With Cmd
                            .CommandType = CommandType.Text
                            .CommandText = bsq
                            .Connection = con
                            .ExecuteNonQuery()
                        End With
                    End If
                Next
                'find account from contact
                Dim sq2 As String = "Select TICKET_ACCOUNT.account_id from TICKET_ACCOUNT join TICKET_CONTACT_PERSON on TICKET_ACCOUNT.account_id = TICKET_CONTACT_PERSON.account_id"
                Dim cmd3 As New SqlCommand(sq2, con)
                Dim da2 As New SqlDataAdapter(cmd3)
                Dim ds2 As New DataSet()
                da2.Fill(ds2)
                Dim idsel2 As String
                For i3 As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                    idsel2 = (ds2.Tables(0).Rows(i3).Item("account_id").ToString)
                    If aid.Text = idsel2 Then 'delete contact of this account selected
                        Dim csq As String = "DELETE FROM TICKET_CONTACT_PERSON Where account_id = '" + aid.Text + "'"
                        With Cmd
                            .CommandType = CommandType.Text
                            .CommandText = csq
                            .Connection = con
                            .ExecuteNonQuery()
                        End With
                    End If
                Next
                'and delete account ......
                Dim sql As String = "DELETE FROM TICKET_ACCOUNT Where account_id = '" + aid.Text + "'"
                With Cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Connection = con
                    .ExecuteNonQuery()
                End With
                con.Close()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Delete Complete.'); window.location='" + Request.ApplicationPath + "/Customer.aspx';", True)
            End If
        End If
    End Sub
    Protected Sub RadGrid4_CancelCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid4.CancelCommand
        RadGrid4.DataSource = Data()
        RadGrid4.DataBind()
        RadGrid7.Visible = False
        RadGrid8.Visible = False
        RadGrid9.Visible = False
    End Sub
    Protected Sub RadGrid4_UpdateCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid4.UpdateCommand
        con.Open() 'update account 
        Dim la As TextBox = e.Item.FindControl("Textbox4")
        Dim f As TextBox = e.Item.FindControl("Textbox5")
        Dim acid As TextBox = e.Item.FindControl("Textbox6")
        Dim sql As String = "UPDATE TICKET_ACCOUNT SET account_code = '" + la.Text + "',account_name = '" + f.Text + "' where account_id = " + acid.Text + ""
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = sql
            .Connection = con
            .ExecuteNonQuery()
        End With
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Update Complete.'); window.location='" + Request.ApplicationPath + "/Customer.aspx';", True)
    End Sub
    Protected Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        Response.Redirect("Customer.aspx")
    End Sub
    Public Sub ClearTextBox(ByVal root As Control)
        For Each ctrl As Control In root.Controls
            ClearTextBox(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            End If
        Next ctrl
    End Sub
    Protected Sub RadGrid7_EditCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid7.EditCommand
        RadGrid7.DataSource = DataSearchgrid7(Session("aid")) 'bind gridview branch
        RadGrid7.DataBind()
    End Sub
    Protected Sub RadGrid8_EditCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid8.EditCommand
        RadGrid8.DataSource = DataSearchgrid8(Session("aid")) 'bind gridview contact
        RadGrid8.DataBind()
    End Sub
    Protected Sub RadGrid9_EditCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid9.EditCommand
        RadGrid9.DataSource = DataSearchgrid9(Session("aid")) 'bind gridview project
        RadGrid9.DataBind()
    End Sub
    Protected Sub RadGrid7_CancelCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid7.CancelCommand
        RadGrid7.DataSource = DataSearchgrid7(Session("aid"))
        RadGrid7.DataBind()
    End Sub
    Protected Sub RadGrid8_CancelCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid8.CancelCommand
        RadGrid8.DataSource = DataSearchgrid8(Session("aid"))
        RadGrid8.DataBind()
    End Sub
    Protected Sub RadGrid9_CancelCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid9.CancelCommand
        RadGrid9.DataSource = DataSearchgrid9(Session("aid"))
        RadGrid9.DataBind()
    End Sub
    Protected Sub RadGrid7_DeleteCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid7.DeleteCommand
        con.Open() 'delete branch 
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
            If e.CommandName = "Delete" Then
                Dim aidt As Label = e.Item.FindControl("Label4")
                Dim psq As String = "DELETE FROM TICKET_BRANCH Where branch_id = '" + aidt.Text + "'"
                With Cmd
                    .CommandType = CommandType.Text
                    .CommandText = psq
                    .Connection = con
                    .ExecuteNonQuery()
                End With
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Delete complete');", True)
                RadGrid7.DataSource = DataSearchgrid7(aidt.Text)
                RadGrid7.DataBind()
            End If
        End If
    End Sub
    Protected Sub RadGrid8_DeleteCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid8.DeleteCommand
        con.Open() 'delete contact
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
            If e.CommandName = "Delete" Then
                Dim aidt As Label = e.Item.FindControl("Label8")
                Dim psq As String = "DELETE FROM TICKET_CONTACT_PERSON Where contact_id = '" + aidt.Text + "'"
                With Cmd
                    .CommandType = CommandType.Text
                    .CommandText = psq
                    .Connection = con
                    .ExecuteNonQuery()
                End With
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Delete complete');", True)
                RadGrid8.DataSource = DataSearchgrid8(aidt.Text)
                RadGrid8.DataBind()
            End If
        End If
    End Sub
    Protected Sub RadGrid9_DeleteCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid9.DeleteCommand
        con.Open() 'delete project
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
            If e.CommandName = "Delete" Then
                Dim aidt As Label = e.Item.FindControl("Label16")
                Dim psq As String = "DELETE FROM TICKET_PROJECT Where id = '" + aidt.Text + "'"
                With Cmd
                    .CommandType = CommandType.Text
                    .CommandText = psq
                    .Connection = con
                    .ExecuteNonQuery()
                End With
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Delete complete');", True)
                RadGrid9.DataSource = DataSearchgrid9(aidt.Text)
                RadGrid9.DataBind()
            End If
        End If
    End Sub
    Protected Sub RadGrid7_UpdateCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid7.UpdateCommand
        'update branch
        Dim aidt As TextBox = e.Item.FindControl("Textbox7")
        Dim bco As TextBox = e.Item.FindControl("Textbox8")
        Dim bna As TextBox = e.Item.FindControl("Textbox9")
        Dim sql As String = "UPDATE TICKET_BRANCH SET branch_code = '" + bco.Text + "',branch_name = '" + bna.Text + "' where branch_id = " + aidt.Text + ""
        con.Open()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = sql
            .Connection = con
            .ExecuteNonQuery()
        End With
        ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "AlertBox", "alert('Update Complete.');", True)
        RadGrid7.DataSource = DataSearchgrid7(aidt.Text)
        RadGrid7.DataBind()
        con.Close()
    End Sub
    Protected Sub RadGrid8_UpdateCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid8.UpdateCommand
        'update contact
        Dim aidt As TextBox = e.Item.FindControl("Textbox1") '
        Dim cco As TextBox = e.Item.FindControl("Textbox12")
        Dim cna As TextBox = e.Item.FindControl("Textbox13")
        Dim cma As TextBox = e.Item.FindControl("Textbox20")
        Dim cte As TextBox = e.Item.FindControl("Textbox21")
        Dim sql As String = "UPDATE TICKET_CONTACT_PERSON SET contact_code = '" + cco.Text + "',contact_name = '" + cna.Text + "',contact_tell = '" + cma.Text + "',contact_email = '" + cte.Text + "' where contact_id = " + aidt.Text + ""
        con.Open()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = sql
            .Connection = con
            .ExecuteNonQuery()
        End With
        ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "AlertBox", "alert('Update Complete.');", True)
        RadGrid8.DataSource = DataSearchgrid8(aidt.Text)
        RadGrid8.DataBind()
        con.Close()
    End Sub
    Protected Sub RadGrid9_UpdateCommand(source As Object, e As GridCommandEventArgs) Handles RadGrid9.UpdateCommand
        'update project
        Dim aidt As TextBox = e.Item.FindControl("Textbox19")
        Dim pco As TextBox = e.Item.FindControl("Textbox15")
        Dim pna As TextBox = e.Item.FindControl("Textbox16")
        Dim pde As TextBox = e.Item.FindControl("Textbox17")
        Dim sql As String = "UPDATE TICKET_PROJECT SET project_code = '" + pco.Text + "',project_name = '" + pna.Text + "',project_desc = '" + pde.Text + "' where id = " + aidt.Text + ""
        con.Open()
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = sql
            .Connection = con
            .ExecuteNonQuery()
        End With
        ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "AlertBox", "alert('Update Complete.');", True)
        RadGrid9.DataSource = DataSearchgrid9(aidt.Text)
        RadGrid9.DataBind()
        con.Close()
    End Sub
End Class