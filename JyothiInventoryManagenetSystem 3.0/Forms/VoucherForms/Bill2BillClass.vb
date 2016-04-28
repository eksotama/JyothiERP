Public Class Bill2BillClass
    Public BillList As New DataGridView
    Public Ledgername As String = ""
    Public LedgerAmount As Double = 0
    Public AllocationAmount As Double = 0
    Public IsCancel As Boolean = False
    Public IsNotApplicable As Boolean = False
    Public TransCode As Double = 0
    Sub New()
        BillList.EditMode = DataGridViewEditMode.EditProgrammatically
        BillList.AllowUserToAddRows = False
        BillList.AllowUserToDeleteRows = False
        BillList.Columns.Add("Ttype", "BillType")
        BillList.Columns.Add("TCode", "TransCode")
        BillList.Columns.Add("tref", "Ref No")
        BillList.Columns.Add("TAmt", "Amount")
    End Sub
    Public Sub Clear()
        BillList.Rows.Clear()
        ' MsgBox(BillList.RowCount)
    End Sub
End Class
