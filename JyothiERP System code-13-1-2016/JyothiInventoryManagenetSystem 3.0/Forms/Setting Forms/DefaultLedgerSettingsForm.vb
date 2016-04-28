Imports System.Windows.Forms

Public Class DefaultLedgerSettingsForm
    Sub LoadData()
        LoadDataIntoComboBox("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "')", TxtCashAccount, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')", TxtSales, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')", TxtSalesRet, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')", TxtPurchase, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')", TxtpurchaseRet, "ledgername")

        LoadDataIntoComboBox("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "')", TxtSalesDiscountLedger, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "')", TxtPurchaseDiscountLedger, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "')", TxtRoundOffLedger, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "')", TxtCommisionLedger, "ledgername")

    End Sub

    Sub LoadDefValues()
        If IsUserAdmin = True Then
            TxtCashAccount.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='cash'", "ledgername")
            TxtSales.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='sales'", "ledgername")
            TxtSalesRet.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='salesret'", "ledgername")
            TxtPurchase.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='purch'", "ledgername")
            TxtpurchaseRet.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='purchret'", "ledgername")
            TxtPOSPayment.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='pos'", "ledgername")
            TxtSalesDiscountLedger.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='cddr'", "ledgername")
            TxtPurchaseDiscountLedger.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='cdcr'", "ledgername")
            TxtRoundOffLedger.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='round'", "ledgername")
            TxtCommisionLedger.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='comm'", "ledgername")
        Else
            TxtCashAccount.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='cash' and username=N'" & CurrentUserName & "'", "ledgername")
            TxtSales.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='sales' and username=N'" & CurrentUserName & "'", "ledgername")
            TxtSalesRet.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='salesret' and username=N'" & CurrentUserName & "'", "ledgername")
            TxtPurchase.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='purch' and username=N'" & CurrentUserName & "'", "ledgername")
            TxtpurchaseRet.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='purchret' and username=N'" & CurrentUserName & "'", "ledgername")
            TxtPOSPayment.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='pos' and username=N'" & CurrentUserName & "'", "ledgername")
            TxtSalesDiscountLedger.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='cddr' and username=N'" & CurrentUserName & "'", "ledgername")
            TxtPurchaseDiscountLedger.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='cdcr' and username=N'" & CurrentUserName & "'", "ledgername")
            TxtRoundOffLedger.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='round' and username=N'" & CurrentUserName & "'", "ledgername")
            TxtCommisionLedger.Text = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='comm' and username=N'" & CurrentUserName & "'", "ledgername")
        End If
      
       
    End Sub

    Private Sub DefaultLedgerSettingsForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub DefaultSettingsForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadData()
        TxtPOSPayment.Items.Clear()
        TxtPOSPayment.Items.Add("Cash")
        TxtPOSPayment.Items.Add("Bank")
        TxtPOSPayment.Items.Add("Cheque")
        LoadDefValues()
    End Sub

    Private Sub TxtCashAccount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCashAccount.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim k As New CreateLedgerAccounts
            k.ShowDialog()
            k = Nothing
            LoadDataIntoComboBox("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "')", TxtCashAccount, "ledgername")

        End If
    End Sub



    Private Sub TxtPurchase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPurchase.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim k As New CreateLedgerAccounts
            k.ShowDialog()
            k = Nothing

            LoadDataIntoComboBox("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')", TxtPurchase, "ledgername")

        End If
    End Sub



    Private Sub TxtpurchaseRet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtpurchaseRet.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim k As New CreateLedgerAccounts
            k.ShowDialog()
            k = Nothing

            LoadDataIntoComboBox("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')", TxtpurchaseRet, "ledgername")
        End If
    End Sub



    Private Sub TxtSales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSales.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim k As New CreateLedgerAccounts
            k.ShowDialog()
            k = Nothing

            LoadDataIntoComboBox("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')", TxtSales, "ledgername")

        End If
    End Sub



    Private Sub TxtSalesRet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSalesRet.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim k As New CreateLedgerAccounts
            k.ShowDialog()
            k = Nothing
            LoadDataIntoComboBox("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')", TxtSalesRet, "ledgername")

        End If
    End Sub



    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If MsgBox("Do You want to Save Changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If IsUserAdmin = True Then
                If TxtCashAccount.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtCashAccount.Text & "' where ledgertype='cash' and username=''")
                    DefLedgers.CashAccount = TxtCashAccount.Text
                End If
                If TxtPurchase.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtPurchase.Text & "' where ledgertype='purch'")
                    DefLedgers.PurchaseAccount = TxtPurchase.Text
                End If
                If TxtpurchaseRet.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtpurchaseRet.Text & "' where ledgertype='purchret'")
                    DefLedgers.PurchaseRetAccount = TxtpurchaseRet.Text
                End If

                If TxtSales.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtSales.Text & "' where ledgertype='sales'")
                    DefLedgers.SalesAccount = TxtSales.Text
                End If
                If TxtSalesRet.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtSalesRet.Text & "' where ledgertype='salesret'")
                    DefLedgers.SalesRetAccount = TxtSalesRet.Text
                End If
                If TxtPOSPayment.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtPOSPayment.Text & "' where ledgertype='pos'")
                    DefLedgers.POSDefaultOption = TxtPOSPayment.Text
                End If

                If TxtPurchaseDiscountLedger.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtPurchaseDiscountLedger.Text & "' where ledgertype='cdcr'")
                    DefLedgers.PurchaseDiscountLedger = TxtPurchaseDiscountLedger.Text
                End If

                If TxtSalesDiscountLedger.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtSalesDiscountLedger.Text & "' where ledgertype='cddr'")
                    DefLedgers.SalesDiscountLedger = TxtSalesDiscountLedger.Text
                End If

                If TxtRoundOffLedger.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtRoundOffLedger.Text & "' where ledgertype='round'")
                    DefLedgers.RoundOffLeder = TxtRoundOffLedger.Text
                End If

                If TxtCommisionLedger.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtCommisionLedger.Text & "' where ledgertype='round'")
                    DefLedgers.CommisionLedger = TxtCommisionLedger.Text
                End If
            Else

                If TxtCashAccount.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtCashAccount.Text & "' where ledgertype='cash' and username=N'" & CurrentUserName & "'")
                    DefLedgers.CashAccount = TxtCashAccount.Text
                End If
                If TxtPurchase.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtPurchase.Text & "' where ledgertype='purch' and username=N'" & CurrentUserName & "'")
                    DefLedgers.PurchaseAccount = TxtPurchase.Text
                End If
                If TxtpurchaseRet.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtpurchaseRet.Text & "' where ledgertype='purchret' and username=N'" & CurrentUserName & "'")
                    DefLedgers.PurchaseRetAccount = TxtpurchaseRet.Text
                End If

                If TxtSales.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtSales.Text & "' where ledgertype='sales' and username=N'" & CurrentUserName & "'")
                    DefLedgers.SalesAccount = TxtSales.Text
                End If
                If TxtSalesRet.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtSalesRet.Text & "' where ledgertype='salesret' and username=N'" & CurrentUserName & "'")
                    DefLedgers.SalesRetAccount = TxtSalesRet.Text
                End If
                If TxtPOSPayment.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtPOSPayment.Text & "' where ledgertype='pos' and username=N'" & CurrentUserName & "'")
                    DefLedgers.POSDefaultOption = TxtPOSPayment.Text
                End If


                If TxtPurchaseDiscountLedger.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtPurchaseDiscountLedger.Text & "' where ledgertype='cdcr' and username=N'" & CurrentUserName & "'")
                    DefLedgers.PurchaseDiscountLedger = TxtPurchaseDiscountLedger.Text
                End If

                If TxtSalesDiscountLedger.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtSalesDiscountLedger.Text & "' where ledgertype='cddr' and username=N'" & CurrentUserName & "'")
                    DefLedgers.SalesDiscountLedger = TxtSalesDiscountLedger.Text
                End If

                If TxtRoundOffLedger.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtRoundOffLedger.Text & "' where ledgertype='round' and username=N'" & CurrentUserName & "'")
                    DefLedgers.RoundOffLeder = TxtRoundOffLedger.Text
                End If

                If TxtCommisionLedger.Text.Length > 0 Then
                    ExecuteSQLQuery("Update DefLedgers set ledgername=N'" & TxtCommisionLedger.Text & "' where ledgertype='round' and username=N'" & CurrentUserName & "'")
                    DefLedgers.CommisionLedger = TxtCommisionLedger.Text
                End If

            End If
            Me.Close()
        End If
        LoadDefLedgerValues()

    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        If MsgBox("Do you want to exit ?        ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub TxtPurchaseDiscountLedger_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPurchaseDiscountLedger.KeyDown, TxtSalesDiscountLedger.KeyDown, TxtRoundOffLedger.KeyDown, TxtCommisionLedger.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim n1 As String = TxtPurchaseDiscountLedger.Text
            Dim n2 As String = TxtSalesDiscountLedger.Text
            Dim n3 As String = TxtRoundOffLedger.Text
            Dim n4 As String = TxtCommisionLedger.Text
            Dim k As New CreateLedgerAccounts
            k.ShowDialog()
            k = Nothing

            LoadDataIntoComboBox("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "')", TxtPurchaseDiscountLedger, "ledgername")
            LoadDataIntoComboBox("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "')", TxtSalesDiscountLedger, "ledgername")
            LoadDataIntoComboBox("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "')", TxtRoundOffLedger, "ledgername")
            LoadDataIntoComboBox("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "')", TxtCommisionLedger, "ledgername")
            TxtPurchaseDiscountLedger.Text = n1
            TxtSalesDiscountLedger.Text = n2
            TxtRoundOffLedger.Text = n3
            TxtCommisionLedger.Text = n4
        End If
    End Sub

    
   
End Class
