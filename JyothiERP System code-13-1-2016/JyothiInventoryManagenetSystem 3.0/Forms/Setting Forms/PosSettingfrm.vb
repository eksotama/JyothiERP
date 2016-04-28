Imports System.Windows.Forms

Public Class PosSettingfrm

   

    Private Sub PosSettingfrm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "')", TxtDefCash, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "')", TxtDefCheque, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "')", TxtDefCreditCard, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "')", TxtDefGift, "ledgername")

        TxtPrinterName.Items.Clear()
        For Each s In Printing.PrinterSettings.InstalledPrinters
            TxtPrinterName.Items.Add(s)
        Next
        If TxtPrinterName.Items.Count > 0 Then
            TxtPrinterName.Text = My.Settings.DefPrinterName
        End If
        LoadPriceListNames()

        Dim dt As New DataTable
        dt = SQLLoadGridData("select * from POSSettings")
        If dt.Rows.Count > 0 Then
            TxPaymentMethod.Text = IIf(dt.Rows(0).Item("AllowPaymentMethod") = 0, "NO", "YES")
            TxtNewAfterSave.Text = IIf(dt.Rows(0).Item("NewInvoiceAfterSave") = 0, "NO", "YES")
            TxtPrintAfterSave.Text = IIf(dt.Rows(0).Item("PrintInvoiceAfterSave") = 0, "NO", "YES")
            TxtPrinterName.Text = dt.Rows(0).Item("defPrinterName").ToString
            TxtPrintDialog.Text = IIf(dt.Rows(0).Item("DirectPrint") = 0, "NO", "YES")
            TxtNoOfCopies.Value = dt.Rows(0).Item("NoofCopies")
            TxtAllowPrice.Text = IIf(dt.Rows(0).Item("AllowPriceAlter") = 0, "NO", "YES")
            TxtChangeDiscount.Text = IIf(dt.Rows(0).Item("AllowDiscountAlter") = 0, "NO", "YES")
            TxtNewItem.Text = IIf(dt.Rows(0).Item("AllowNewItem") = 0, "NO", "YES")
            Txtzerotax.Text = IIf(dt.Rows(0).Item("ZeroTax") = 0, "NO", "YES")
            Txtshowkeyboard.Text = IIf(dt.Rows(0).Item("osk") = 0, "NO", "YES")
            TxtPriceListName.Text = dt.Rows(0).Item("DefaultPriceList").ToString
            TxtAllowtoChangeDate.Text = IIf(dt.Rows(0).Item("IsAllowTochangeDate") = 0, "NO", "YES")
            TxtAllowCreditSales.Text = IIf(dt.Rows(0).Item("IsAllowCreditSales") = 0, "NO", "YES")
            TxtAllowCurrencies.Text = IIf(dt.Rows(0).Item("IsAllowMultiCurrency") = 0, "NO", "YES")
            TxtGridView.Text = IIf(dt.Rows(0).Item("IsItemsAsGridList") = 0, "NO", "YES")
            TxtDefCash.Text = dt.Rows(0).Item("CashLedger").ToString
            TxtDefCreditCard.Text = dt.Rows(0).Item("CreditCardLedger").ToString
            TxtDefCheque.Text = dt.Rows(0).Item("ChequeLedger").ToString
            TxtDefGift.Text = dt.Rows(0).Item("GiftCardLedger").ToString
        End If

    End Sub
    Sub LoadPriceListNames()
        TxtPriceListName.Items.Clear()
        LoadDataIntoComboBox("select  pricelistname from pricelist", TxtPriceListName, "pricelistname")
        TxtPriceListName.Items.Add("Wholesale")
        TxtPriceListName.Items.Add("Retail")
        TxtPriceListName.Items.Add("*All")
    End Sub

    Private Sub PosSettingfrm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        TxtNewAfterSave.Focus()
    End Sub

    Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click
        If TxPaymentMethod.Text = "YES" Then
            If TxtDefCash.Text.Length = 0 Or TxtDefCheque.Text.Length = 0 Or TxtDefCreditCard.Text.Length = 0 Or TxtDefGift.Text.Length = 0 Then
                MsgBox("Please Select the Default Ledger allocation ...", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If
       
        If MsgBox("Do you want the save changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If TxPaymentMethod.Text.Length = 0 Or TxPaymentMethod.Text = "NO" Then
                ExecuteSQLQuery("update POSSettings set AllowPaymentMethod=0")
            Else
                ExecuteSQLQuery("update POSSettings set AllowPaymentMethod=1")
            End If

            If TxtNewAfterSave.Text.Length = 0 Or TxtNewAfterSave.Text = "NO" Then
                ExecuteSQLQuery("update POSSettings set NewInvoiceAfterSave=0")
            Else
                ExecuteSQLQuery("update POSSettings set NewInvoiceAfterSave=1")
            End If

            If TxtPrintAfterSave.Text.Length = 0 Or TxtPrintAfterSave.Text = "NO" Then
                ExecuteSQLQuery("update POSSettings set PrintInvoiceAfterSave=0")
            Else
                ExecuteSQLQuery("update POSSettings set PrintInvoiceAfterSave=1")
            End If
            ExecuteSQLQuery("update POSSettings set defPrinterName='" & TxtPrinterName.Text & "'")
            ExecuteSQLQuery("update POSSettings set NoofCopies=" & TxtNoOfCopies.Value)

            If TxtPrintDialog.Text.Length = 0 Or TxtPrintDialog.Text = "NO" Then
                ExecuteSQLQuery("update POSSettings set DirectPrint=0")
            Else
                ExecuteSQLQuery("update POSSettings set DirectPrint=1")
            End If
            If TxtAllowPrice.Text.Length = 0 Or TxtAllowPrice.Text = "NO" Then
                ExecuteSQLQuery("update POSSettings set AllowPriceAlter=0")
            Else
                ExecuteSQLQuery("update POSSettings set AllowPriceAlter=1")
            End If
            If TxtChangeDiscount.Text.Length = 0 Or TxtChangeDiscount.Text = "NO" Then
                ExecuteSQLQuery("update POSSettings set AllowDiscountAlter=0")
            Else
                ExecuteSQLQuery("update POSSettings set AllowDiscountAlter=1")
            End If

            If TxtNewItem.Text.Length = 0 Or TxtNewItem.Text = "NO" Then
                ExecuteSQLQuery("update POSSettings set AllowNewItem=0")
            Else
                ExecuteSQLQuery("update POSSettings set AllowNewItem=1")
            End If

            If Txtzerotax.Text.Length = 0 Or Txtzerotax.Text = "NO" Then
                ExecuteSQLQuery("update POSSettings set ZeroTax=0")
            Else
                ExecuteSQLQuery("update POSSettings set ZeroTax=1")
            End If

            If Txtshowkeyboard.Text.Length = 0 Or Txtshowkeyboard.Text = "NO" Then
                ExecuteSQLQuery("update POSSettings set osk=0")
            Else
                ExecuteSQLQuery("update POSSettings set osk=1")
            End If

            If TxtAllowtoChangeDate.Text.Length = 0 Or TxtAllowtoChangeDate.Text = "NO" Then
                ExecuteSQLQuery("update POSSettings set IsAllowTochangeDate=0")
            Else
                ExecuteSQLQuery("update POSSettings set IsAllowTochangeDate=1")
            End If
            If TxtAllowCreditSales.Text.Length = 0 Or TxtAllowCreditSales.Text = "NO" Then
                ExecuteSQLQuery("update POSSettings set IsAllowCreditSales=0")
            Else
                ExecuteSQLQuery("update POSSettings set IsAllowCreditSales=1")
            End If

            If TxtAllowCurrencies.Text.Length = 0 Or TxtAllowCurrencies.Text = "NO" Then
                ExecuteSQLQuery("update POSSettings set IsAllowMultiCurrency=0")
            Else
                ExecuteSQLQuery("update POSSettings set IsAllowMultiCurrency=1")
            End If

            If TxtGridView.Text.Length = 0 Or TxtGridView.Text = "NO" Then
                ExecuteSQLQuery("update POSSettings set IsItemsAsGridList=0")
            Else
                ExecuteSQLQuery("update POSSettings set IsItemsAsGridList=1")
            End If

            ExecuteSQLQuery("update POSSettings set defPrinterName='" & TxtPrinterName.Text & "',DefaultPriceList=N'" & TxtPriceListName.Text & "', NoofCopies=" & TxtNoOfCopies.Value & ",CashLedger=N'" & TxtDefCash.Text & "',CreditCardLedger=N'" & TxtDefCreditCard.Text & "',ChequeLedger=N'" & TxtDefCheque.Text & "',GiftCardLedger=N'" & TxtDefGift.Text & "'")
            LoadPOSSettings()
            Me.Close()
        End If

    End Sub

    Private Sub BtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim frm As New CreateLedgerAccounts
        frm.ShowDialog()
        LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "')", TxtDefCash, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "')", TxtDefCheque, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "')", TxtDefCreditCard, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "')", TxtDefGift, "ledgername")

    End Sub
End Class
