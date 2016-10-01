Imports Microsoft.VisualBasic

Public Class Constants
    Partial Public Class Expenditure
        Partial Public Class ExpenditureStatus
            Public Const Entered As String = "0"
            Public Const WaitForApproval As String = "1"
            Public Const ApproveByPM As String = "2"
            Public Const RejectByPM As String = "3"
            Public Const WaitForClearBill As String = "4"
            Public Const RejectByCostcontroller As String = "5"
            Public Const Finished As String = "6"
        End Class
    End Class

    Partial Public Class ETimeSheet
        Partial Public Class TimeSheetStatus
            Public Const Entered As String = "0"
            Public Const WaitForApproval As String = "1"
            Public Const ApproveByPM As String = "2"
            Public Const RejectByPM As String = "3"
            Public Const Finished As String = "4"
            Public Const RejectByCostcontroller As String = "5"
        End Class
    End Class

    Partial Public Class Responsibility
        Public Const ViewProjectManhour As Long = 1
        Public Const Accounting As Long = 2
    End Class
End Class
