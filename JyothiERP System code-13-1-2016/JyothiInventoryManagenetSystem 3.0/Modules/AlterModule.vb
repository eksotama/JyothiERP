Module AlterModule
    Public Sub AlterLedgerName(ByVal NewLedgername As String, ByVal oldLedgername As String)
        ExecuteSQLQuery("EXEC  UPDATELEDGERNAMES N'" & NewLedgername & "',N'" & oldLedgername & "'")

        LoadDefLedgerValues()

    End Sub
    Sub ks()


    End Sub
End Module
