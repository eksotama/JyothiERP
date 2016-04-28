Public Class LedgerDetailsClass
    Public Despatchto As String
    Public despatchaddress As String
    Public despatchtaxdetails As String
    Public DespatchThrough As String
    Public DespatchDestination As String
    Public buyersname As String
    Public buyeraddress As String
    Public buyertaxdetails As String
    Public paymentterm As String
    Public otherreference As String
    Public remarks As String
    Public consgneename As String
    Public consgneeaddress As String
    Public DelevaryTo As String
    Public delevarterms As String
    Public Delevarynoteno As String
    Public delevarytranscode As Single
    Public orderno As String
    Public ordertranscode As Single
    Public Sub Clear()
        DespatchThrough = ""
        DespatchDestination = ""
        despatchaddress = ""
        despatchtaxdetails = ""
        Despatchto = ""
        buyeraddress = ""
        buyersname = ""
        buyertaxdetails = ""
        paymentterm = ""
        otherreference = ""
        remarks = ""
        consgneeaddress = ""
        consgneename = ""
        delevarterms = ""
        Delevarynoteno = ""
        DelevaryTo = ""
        delevarytranscode = 0
        orderno = ""
        ordertranscode = 0
    End Sub
End Class
