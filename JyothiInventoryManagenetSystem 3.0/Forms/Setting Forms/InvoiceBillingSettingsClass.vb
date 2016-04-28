Public Class InvoiceBillingSettingsClass
    Public PaymentSettings As New IBS
    Public ReceiptSettings As New IBS
    Public ContraSettings As New IBS
    Public JournalSettings As New IBS
    Public PurchaseVoucher As New IBS
    Public PurchaseReturnVoucher As New IBS
    Public SalesVoucher As New IBS
    Public SalesReturnVoucher As New IBS
    Public PurchaseQutoSettings As New IBS
    Public PurchaseGoodReceivedSettings As New IBS
    Public PurchaseOrderSettings As New IBS
    Public PurchaseInvoicesetting As New IBS
    Public SalesQutoSetting As New IBS
    Public SalesDelavarySettings As New IBS
    Public SalesOrderSettings As New IBS
    Public SalesInvoiceSettings As New IBS
    Public SalesReturnInvoiceSettings As New IBS
    Public PurchaseReturnInvoiceSettings As New IBS
    Public StockJournal As New IBS
    Public POS As New IBS
    Public CashPurchaseInvoicesetting As New IBS
    Public CreditPurchaseInvoicesetting As New IBS
    Public CashSalesInvoicesetting As New IBS
    Public CreditSalesInvoicesetting As New IBS
    Public Form8BSalesInvoicesetting As New IBS
    Public Form8SalesInvoicesetting As New IBS
    Public Form8DSalesInvoicesetting As New IBS
    Public Form8BSalesRETInvoicesetting As New IBS
    Public Form8SalesRETInvoicesetting As New IBS
    Public Form8DSalesRETInvoicesetting As New IBS
    Structure IBS
        Dim InvoiceMethod As Byte
        Dim IsAllowDuplicates As Byte
        Dim PrintonSave As Byte
        Dim eachnarration As Byte
        Dim PrintingScheme1 As String
        Dim PrintingScheme2 As String
        Dim PrintingScheme3 As String
    End Structure
End Class
