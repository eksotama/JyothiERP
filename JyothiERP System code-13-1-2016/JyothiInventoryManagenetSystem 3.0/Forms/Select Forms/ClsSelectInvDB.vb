Public Class ClsSelectInvDB
    Public Invoicetype As New InvtypeStruct
    Public SelectedTransCode As Single
    Public OpenedInvType As New InvtypeStruct
    Public SelectedDbDetailsName As String = ""
    Public SelectedDbRowItemsName As String = ""
    Public ListofTrascodeadded As New DataGridView
    Public SelectedLedgerName As String = ""
    Public SelectedInvoiceName As String = ""
    Public SelectedVoucherType As String = ""
    Sub New()
        ListofTrascodeadded.AllowUserToAddRows = False
        ListofTrascodeadded.AllowUserToDeleteRows = False
        ListofTrascodeadded.EditMode = DataGridViewEditMode.EditProgrammatically
        ListofTrascodeadded.Columns.Add("Transcode", "Trancode")
        ListofTrascodeadded.Columns.Add("Dbname", "Dbname")
        ListofTrascodeadded.Columns.Add("VoucherName", "VoucherName")
    End Sub
    Enum InvtypeStruct
        salesquto = 1
        salesorder = 2
        salesdelaverynote = 3
        salesinvoice = 4
        salesvoucher = 5
        purchasequto = 6
        purchaseorder = 7
        purchasegoodsreceived = 8
        purchaseinvoice = 9
        purchasevoucher = 10
        PurchaseReturns = 11
        salesReturns = 12
        salesPOS = 13
        stockjournal = 14
        stockphysical = 15
        DirectPurchase = 16
    End Enum

End Class
