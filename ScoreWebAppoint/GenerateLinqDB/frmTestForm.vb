Public Class frmTestForm

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim lnq As New LinqDB.TABLE.MsMemberTypeLinqDB
        'Dim trans As New LinqDB.ConnectDB.TransactionDB
        'lnq.MEMBER_TYPE_CODE = "0002"
        'lnq.MEMBER_TYPE_NAME = "Member Type Name2"
        'lnq.ACTIVE_STATUS = "N"

        'Dim ret As Boolean = lnq.InsertData("KKK", trans.Trans)
        'If ret = False Then
        '    trans.RollbackTransaction()
        'Else
        '    trans.CommitTransaction()
        'End If


        'Dim lnq As New LinqDB.TABLE.MsMemberTypeLinqDB
        'Dim trans As New LinqDB.ConnectDB.TransactionDB
        'lnq.GetDataByPK(2, trans.Trans)
        'lnq.MEMBER_TYPE_CODE = "0003"
        'lnq.MEMBER_TYPE_NAME = "Member Type Name3"
        'lnq.ACTIVE_STATUS = "Y"

        'Dim ret As Boolean = lnq.UpdateByPK("AAAA", trans.Trans)
        'If ret = False Then
        '    trans.RollbackTransaction()
        'Else
        '    trans.CommitTransaction()
        'End If


        'Dim lnq As New LinqDB.TABLE.MsMemberTypeLinqDB
        'Dim dt As New DataTable
        'dt = lnq.GetDataList("member_type_code='0003'", "", Nothing)

        'txtCode.Text = dt.Rows(0)("member_type_code")
        'txtName.Text = dt.Rows(0)("member_type_name")
        'chkActiveStatus.Checked = (dt.Rows(0)("active_status").ToString = "Y")


        'Dim lnq As New LinqDB.TABLE.MsMemberTypeLinqDB
        'Dim trans As New LinqDB.ConnectDB.TransactionDB
        'If lnq.DeleteByPK(1, trans.Trans) = True Then
        '    trans.CommitTransaction()
        'Else
        '    trans.RollbackTransaction()
        'End If
    End Sub
End Class