Public Class ChooseItemClass
    Public StockItemCode As String
    Public StockLocation As String
    Public StockItemBarCode As String
    Public StockGroup As String
    Public StockCat As String
    Public Brand As String
    Public StockPhotoPath As String
    Public StockItemName As String
    Public StockITemDescription As String
    Public StockITemSize As String
    Public StockUnitName As String
    Public StockRate As Double
    Public StockWRPRate As Double
    Public StockRRPRate As Double
    Public CurrentStockQty As Double
    Public StockLocationNames As String
    Public StockMainUnitName As String
    Public StockSubUnitName As String
    Public TotalQtytext As String
    Public TotalQty As Double
    Public StoreName As String
    Public StockType As Byte
    Public StockBatchNo As String
    Public StockExpirydate As Date
    Public IsBatchNo As Byte
    Public IsSimpleUnit As Byte
    Public CurrentField As Byte
    Public TxtQtyBOX As New IMSQtyBox
    Public TxtMQtyBOX As New IMSQtyBox
    Public TxtQtyFreeBOX As New IMSQtyBox
    Public TxtOpQtyBOX As New IMSQtyBox
    Public CurrentChar As String
    Public HScode As String = ""
    Public CustBarCode As String = ""
    Public Madeby As String = ""
    Public Tax As Double = 0
    Public Tax2 As Double = 0
    Public OpStockQty As Double = 0
    Public MinQty As Double = 0
    Public ExpDatePicker As New DateTimePicker
    Public ImagePath As String = ""
    Public CostMethod As String = ""
    Public OpRate As Double = 0
    Public Unitconversion As Double = 1
    Public ServiceTax As Double = 0
    Public IsAllowDiscount As Boolean = True
    Public MRP As Double = 0
    Public Packing As String = ""
    Public IsAllowSerialNumbers As Boolean = False
    Public CSTtax As Double = 0
    Public IsTaxInclude As Boolean = False
    Public ServiceDuration As Double = 0
    Public Sub ClearData()
        IsAllowDiscount = True
        IsAllowSerialNumbers = False
        Tax = "0"
        CSTtax = 0
        MRP = 0
        Packing = ""
        ServiceDuration = 0
        ServiceTax = 0
        MinQty = 0
        OpRate = 0
        CostMethod = "FIFO"
        ImagePath = ""
        Unitconversion = 1
        ExpDatePicker.Value = Today.Date
        StockItemCode = ""
        StockLocationNames = ""
        StockItemBarCode = 0
        StockItemName = ""
        StockITemDescription = ""
        StockGroup = ""
        StockLocation = ""
        CurrentField = 0
        StockITemSize = ""
        StockUnitName = ""
        CurrentChar = ""
        StockPhotoPath = ""
        StockRate = 0
        StockWRPRate = 0
        StockRRPRate = 0
        CurrentStockQty = 0
        StockLocationNames = ""
        StockMainUnitName = ""
        StockSubUnitName = ""
        TotalQtytext = ""
        TotalQty = 0
        StoreName = ""
        StockType = 0
        StockBatchNo = ""
        IsBatchNo = 0
        IsAllowSerialNumbers = False
        StockCat = ""
        Brand = ""
        HScode = ""
        Madeby = ""
        CustBarCode = ""
        IsSimpleUnit = 0
        TxtQtyBOX.ClearQty()
        TxtMQtyBOX.ClearQty()
        TxtOpQtyBOX.ClearQty()
        TxtQtyFreeBOX.ClearQty()
        OpStockQty = 0
        StockExpirydate = CDate("01/12/1900")
    End Sub
End Class
