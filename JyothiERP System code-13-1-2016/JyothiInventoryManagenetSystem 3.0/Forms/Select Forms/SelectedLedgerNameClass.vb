Public Class SelectedLedgerNameClass
    Public SelectedLedgerName As String = ""
    Public CurrentChar As String = ""
    Public LedgerType As New LedgerTypeEnum
    Enum LedgerTypeEnum
        Customers = 0
        suppliers = 1
        Expenses = 2
        incomes = 3
        BothExpIncomes = 4
        assets = 5
        laibilities = 6
        all = 20
        Customersandsupplierswithcashandbanks = 7
    End Enum

End Class
