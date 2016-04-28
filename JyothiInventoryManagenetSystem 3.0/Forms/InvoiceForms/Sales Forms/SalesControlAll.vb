Imports System.Drawing.Printing
Imports System.Data.SqlClient
Imports System.IO

Public Class SalesControlAll
    Dim IsTaxInclude As Boolean = False
    Dim ChangedStockRate As Double = 0
    Dim Tax2TotalValue As Double = 0
    Dim TxtStockTax2 As Double = 0
    Dim Bill2Billdetails As New Bill2BillClass
    Dim OpenedCouponDiscountAmount As Double = 0
    Dim isopeningprocess As Boolean = False
    Public IsOpenedOutsideforDelete As Boolean = False
    Dim NOofpagestoprint As Integer = 1
    Dim IsReadyOnly As Boolean = False
    Dim IsInvoiceOpen As Boolean = False
    Dim IsPullFromQuto As Boolean = False
    Dim IsInvoiceSaved As Boolean = True
    Dim OpenedTranscode As Single = 0
    Dim IsOpendByWindows As Boolean = False
    Dim IsEditItem As Boolean = False
    Dim EditItemRow As Integer = 0
    Dim PrintingScheme As String = ""
    Dim NewAddItem As New ChooseItemClass
    Dim IsModified As Boolean = False
    Dim MoreDet As New LedgerDetailsClass
    Dim AcountAmountDr As Double = 0
    Dim AcountAmountCr As Double = 0
    Dim SelectedTransList As New ClsSelectInvDB
    Dim OpenedTransList As New ClsSelectInvDB
    Dim CurrentTransList As New ClsSelectInvDB
    Dim OpenedCurrencyRate As Double = 0
    Dim IsOpenedFromOutside As Boolean = False
    Dim InvoiceCtrlType As String = ""
    Dim OpenedPDCValues As New PDCSettingsClass
    Dim IsCopyInvoice As Boolean = False
    Dim IsValueTextChanged As Boolean = False
    Dim IsValuecalculate As Boolean = False
    Dim IsNetRateCalculate As Boolean = False
    Dim IsNetValueTextChanged As Boolean = False
    Dim IsPrintDuplicateInvoice As Boolean = False
    Dim PrintInvoicecopyno As Integer = 1
    Public IsDirectSales As Boolean = False
    Dim OpenedLedgerName As String = ""
    Dim SalesTrancsationType As String = ""
    Dim TxtRoundoff As Double = 0
    Dim IsBarcodeEntered As Boolean = False
    Dim OpenedInvoiceTotal As Double = 0
    Dim IsEditing As Boolean = False
    Dim IsAddedByBarcode As Boolean = True
    Dim Is_CreditSales As Boolean = False
    Dim IsZeroTax As Boolean = False
    Sub New(ByVal InvoiceType As String, Optional ByVal OpTranscode As Single = 0, Optional ByVal SalesTransType As String = "", Optional IsCreditSales As Boolean = False, Optional Invoicewithouttax As Boolean = False)
        ' This call is required by the designer.
        InitializeComponent()
        SalesTrancsationType = SalesTransType
        If SalesTrancsationType.Length > 0 Then
            lblInvoiceTitle.Text = SalesTrancsationType
        End If
        Is_CreditSales = IsCreditSales
        IsZeroTax = Invoicewithouttax
        InvoiceCtrlType = InvoiceType
        If OpTranscode <> 0 Then
            OpenedTranscode = OpTranscode
            IsOpenedFromOutside = True
        End If
        If InvoiceType = "POS" Or InvoiceType = "SR" Or InvoiceType = "SI" Then
        Else
            TabControl1.TabPages.RemoveAt(1)
            ReceiptPanel.Visible = False
        End If
        If IsZeroTax = True Then
            lblInvoiceTitle.Text = "ZERO TAX POS "
        End If
        ' Add any initialization after the InitializeComponent() call.
    End Sub


    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
#Region "FUNCTIONS"
    Sub LoadDisplaySettings()

        On Error Resume Next
        If InvoiceDisplaySettings.ShowItemName = False Then
            Me.TableForItemRow.ColumnStyles.Item(2).Width = 0
            TxtStockName.Visible = False
        Else
            Me.TableForItemRow.ColumnStyles.Item(2).Width = 200
            TxtStockName.Visible = True
        End If
        If InvoiceDisplaySettings.ShowItemMoreInfo = False Then
            Me.TableForItemRow.ColumnStyles.Item(3).Width = 0
            TxtList.Columns("stsize").Visible = False
            TxtStockSize.Visible = False
        Else
            Me.TableForItemRow.ColumnStyles.Item(3).Width = 80
            TxtList.Columns("stsize").Visible = True
            TxtStockSize.Visible = True
        End If
        Me.TableForItemRow.ColumnStyles.Item(4).Width = 80
        If AppIsItemwithSize = False Then
            Me.TableForItemRow.ColumnStyles.Item(3).Width = 0
            TxtList.Columns("stsize").Visible = False
            TxtStockSize.Visible = False
        End If


        If InvoiceDisplaySettings.ShowRatePer = False Then
            Me.TableForItemRow.ColumnStyles.Item(8).Width = 0
            TxtList.Columns("strateper").Visible = False
            TxtRatePer.Visible = False
        Else
            Me.TableForItemRow.ColumnStyles.Item(8).Width = 80
            TxtList.Columns("strateper").Visible = True
            TxtRatePer.Visible = True
        End If

        If InvoiceDisplaySettings.ShowDiscount = False Then
            TxtList.Columns("StDiscount").Visible = False
            Me.TableForItemRow.ColumnStyles.Item(10).Width = 0
            TxtStockDisc.Visible = False
        Else
            Me.TableForItemRow.ColumnStyles.Item(10).Width = 51
            TxtList.Columns("StDiscount").Visible = True
            TxtStockDisc.Visible = True
        End If

        If InvoiceDisplaySettings.ShowDiscount2 = False Then
            TxtList.Columns("tdisc2").Visible = False
            Me.TableForItemRow.ColumnStyles.Item(11).Width = 0
            TxtStockDiscount2.Visible = False
        Else
            Me.TableForItemRow.ColumnStyles.Item(11).Width = 51
            TxtList.Columns("tdisc2").Visible = True
            TxtStockDiscount2.Visible = True

        End If
        If InvoiceDisplaySettings.ShowTax = False Then
            TxtList.Columns("Sttax").Visible = False
            TxtList.Columns("Sttax2").Visible = False
            Me.TableForItemRow.ColumnStyles.Item(12).Width = 0
            TxtStockTax.Visible = False

        Else
            Me.TableForItemRow.ColumnStyles.Item(12).Width = 60
            TxtList.Columns("Sttax").Visible = True
            TxtList.Columns("Sttax2").Visible = True
            TxtStockTax.Visible = True
            If MyAppSettings.IsAllowCustomTaxRates = True Then
                TxtStockTax.Enabled = True
            Else
                TxtStockTax.Enabled = False
            End If

        End If
        
        If InvoiceDisplaySettings.ShowNetRate = False Then
            Me.TableForItemRow.ColumnStyles.Item(13).Width = 0
            TxtList.Columns("Stnetrate").Visible = False
            TxtStockNetRate.Visible = False
        Else
            Me.TableForItemRow.ColumnStyles.Item(13).Width = 82
            TxtList.Columns("Stnetrate").Visible = True
            TxtStockNetRate.Visible = True
        End If

        If InvoiceDisplaySettings.ShowNarration = False Then
            lblNarration.Visible = False
            TxtNarration.Visible = False
        Else
            lblNarration.Visible = True
            TxtNarration.Visible = True
        End If

        '  Me.TableForItemRow.ColumnStyles.Item(15).Width = 85
        Me.TableForItemRow.ColumnStyles.Item(15).Width = 2
        Me.TableForItemRow.ColumnStyles.Item(16).Width = 45
        If InvoiceDisplaySettings.ShowPriceList = False Then
            LblPriceList.Visible = False
            TxtPriceLevel.Visible = False
        Else
            LblPriceList.Visible = True
            TxtPriceLevel.Visible = True
        End If
        If MyAppSettings.IsAllowMultiTaxRatesOnSales = False Then
            'TxtList.Columns("sttax2").Visible = False
            TxtList.Columns("sttaxamount2").Visible = False

        Else
            '  TxtList.Columns("sttax2").Visible = True
            TxtList.Columns("sttaxamount2").Visible = True
        End If
        If (InvoiceDisplaySettings.ShowNetRate = False And InvoiceDisplaySettings.ShowTax = False) Or InvoiceDisplaySettings.ShowItemName = False Then
            Me.TableForItemRow.ColumnStyles.Item(7).Width = 180
        End If
        'PaymentOptionPanel.Visible = False
        lblDeliverNoteDate.Visible = False
        TxtDelivaryDate.Visible = False
        TxtDelivaryDate.Enabled = False
        LblSalesLedger.Visible = False
        TxtSalesLedger.Visible = False
        BtnPullData.Visible = True
        TxtBarCode.Visible = True
        btnAddItems.Visible = False
        TxtList.Columns("stdnoteno").Visible = False
        Select Case InvoiceCtrlType
            Case "SQ"
                lblDeliverNoteDate.Visible = False
                TxtDelivaryDate.Visible = False
                TxtDelivaryDate.Enabled = False
                BtnPullData.Visible = False
                lblInvoiceTitle.Text = "SALES QUOTATION"
                lblInvoiceNo.Text = "Quote No"
                LblReferenceNo.Text = "Quote Ref"
                Me.TableForItemRow.ColumnStyles.Item(0).Width = 0
                TxtBarCode.Visible = False
                GrpAdvancePayment.Enabled = False
                GrpAdvancePayment.Visible = False
            Case "SO"
                lblDeliverNoteDate.Visible = True
                TxtDelivaryDate.Enabled = True
                TxtDelivaryDate.Visible = True
                lblInvoiceTitle.Text = "SALES ORDER"
                lblInvoiceNo.Text = "Order No"
                LblReferenceNo.Text = "Order Ref"
                Me.TableForItemRow.ColumnStyles.Item(0).Width = 0
                TxtBarCode.Visible = False
                GrpAdvancePayment.Enabled = False
                GrpAdvancePayment.Visible = False
            Case "SD"
                LblSalesLedger.Visible = True
                TxtSalesLedger.Visible = True
                lblInvoiceTitle.Text = "SALES DELIVERY NOTE"
                lblInvoiceNo.Text = "Delivery No"
                LblReferenceNo.Text = "Delivery Ref"

                'If MyAppSettings.IsShowAdditionalFieldsinSalesDeliveryNote = False Then
                '    btnAddItems.Visible = True
                '    TxtStockRate.Visible = False
                '    TxtRatePer.Visible = False
                '    TxtStockDisc.Visible = False
                '    TxtStockTax.Visible = False
                '    TxtStockNetRate.Visible = False
                '    TxtStockValue.Visible = False

                '    'Me.TableForItemRow.ColumnStyles.Item(6).Width = 0
                '    'Me.TableForItemRow.ColumnStyles.Item(7).Width = 0
                '    'Me.TableForItemRow.ColumnStyles.Item(8).Width = 0
                '    'Me.TableForItemRow.ColumnStyles.Item(9).Width = 0
                '    'Me.TableForItemRow.ColumnStyles.Item(10).Width = 0
                '    'Me.TableForItemRow.ColumnStyles.Item(11).Width = 0
                '    'Me.TableForItemRow.ColumnStyles.Item(12).Width = 80
                '    'Me.TableForItemRow.ColumnStyles.Item(13).Width = 80
                '    'Me.TableForItemRow.ColumnStyles.Item(14).Width = 80
                '    btnAddItems.Width = 60
                '    TxtList.Columns("StStockTaxValue").Visible = False
                '    TxtList.Columns("stnetrate").Visible = False
                '    TxtList.Columns("sttax").Visible = False
                '    TxtList.Columns("stdiscount").Visible = False
                '    TxtList.Columns("strateper").Visible = False
                '    TxtList.Columns("strate").Visible = False


                'End If


            Case "SI"
                LblSalesLedger.Visible = True
                TxtSalesLedger.Visible = True
                lblInvoiceTitle.Text = "SALES INVOICE"
                lblInvoiceNo.Text = "Invoice No"
                LblReferenceNo.Text = "Ref No"
                TxtList.Columns("stdnoteno").Visible = True
            Case "SR"
                LblSalesLedger.Visible = True
                TxtSalesLedger.Visible = True
                If SalesTrancsationType.Length > 0 Then
                    lblInvoiceTitle.Text = UCase(SalesTrancsationType)
                Else
                    lblInvoiceTitle.Text = "SALES RETURNS - CREDIT NOTE"
                End If

                lblInvoiceNo.Text = "Invoice No"
                LblReferenceNo.Text = "Ref No"

            Case "POS"
                LblSalesLedger.Visible = True
                TxtSalesLedger.Visible = True
                'PaymentOptionPanel.Visible = True
                If SalesTrancsationType.Length > 0 Then
                    lblInvoiceTitle.Text = UCase(SalesTrancsationType)
                Else
                    lblInvoiceTitle.Text = "POINT OF SALES - POS"
                End If

                lblInvoiceNo.Text = "Invoice No"
                LblReferenceNo.Text = "Ref No"

        End Select
        If MyAppSettings.POSPriceListName = "*All" Then
            TxtPriceLevel.Enabled = True
        Else
            TxtPriceLevel.Text = MyAppSettings.POSPriceListName
            TxtPriceLevel.Enabled = False
        End If
        TxtVoucherType.Text = "Tax Invoice"
    End Sub

    Sub LoadDefaults()
        TableLayoutPanel1.RowStyles(1).Height = 127
        TableLayoutPanel1.RowStyles(4).Height = 129
        TxtVoucherType.Enabled = True
        UnLockTransaction(OpenedTranscode)
        CostList.Rows.Clear()
        PostDatedBox.Checked = False

        PostDatedBox.Visible = False
        LblSalesLedger.Visible = False
        TxtSalesLedger.Visible = False
        NewAddItem.StockItemCode = ""
        TxtMobileNo.Text = ""
        Try
            TabControl1.SelectedIndex = 1
        Catch ex As Exception

        End Try
        OpenedInvoiceTotal = 0
        TxtAdvancePayment.Text = "0"
        TxtBalanceAmount.Text = "0"
        TxtStockTax2 = 0
        TxtCurrencyLabel.Text = CompDetails.Currency
        TxtBillingCurrency.Text = CompDetails.Currency
        TxtCurrency.Text = CompDetails.Currency
        TxtRateofExchange.Text = "1"
        IsValuesInBillingCurrency.Checked = False
        TxtDate.Value = Now
        If TxtSalesPerson.Items.Contains(CurrentUserName) = True Then
            TxtSalesPerson.Text = CurrentUserName
        End If
        Select Case InvoiceCtrlType
            Case "SO"
                TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.salesorder)
                If InvoiceBillingSettings.SalesOrderSettings.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
            Case "SI"
                TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.salesinvoice)
                If InvoiceBillingSettings.SalesInvoiceSettings.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
                LblSalesLedger.Visible = True
                TxtSalesLedger.Visible = True
            Case "SQ"
                TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.salesquoto)
                If InvoiceBillingSettings.SalesQutoSetting.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
            Case "SR"
                If InvoiceBillingSettings.SalesReturnInvoiceSettings.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
                If Is_CreditSales = True Then
                    TxtPaymentMethod.Text = "Credit"
                Else
                    TxtPaymentMethod.Text = "Cash"
                End If
                If SalesTrancsationType.Length > 0 Then
                    If SalesTrancsationType = "Return Form-8B" Then
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.SRFORM8B)
                        If InvoiceBillingSettings.Form8BSalesRETInvoicesetting.InvoiceMethod = 0 Then
                            TxtQutoNo.Enabled = False
                        Else
                            TxtQutoNo.Enabled = True
                        End If
                    ElseIf SalesTrancsationType = "Return Form-8" Then
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.SRFORM8)
                        If InvoiceBillingSettings.Form8SalesRETInvoicesetting.InvoiceMethod = 0 Then
                            TxtQutoNo.Enabled = False
                        Else
                            TxtQutoNo.Enabled = True
                        End If
                    Else
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.SRFORM8D)
                        If InvoiceBillingSettings.Form8DSalesRETInvoicesetting.InvoiceMethod = 0 Then
                            TxtQutoNo.Enabled = False
                        Else
                            TxtQutoNo.Enabled = True
                        End If
                    End If
                Else
                    TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.SalesRetInvoice)
                End If
                
                LblSalesLedger.Visible = True
                TxtSalesLedger.Visible = True
            Case "SD"
                TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.salesdelavery)
                If InvoiceBillingSettings.SalesDelavarySettings.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
                LblSalesLedger.Visible = True
                TxtSalesLedger.Visible = True
            Case "POS"
                If InvoiceBillingSettings.POS.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
                If SalesTrancsationType.Length > 0 Then
                    If SalesTrancsationType = "Cash Sales" Then
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.CASHSALES)
                        If InvoiceBillingSettings.CashSalesInvoicesetting.InvoiceMethod = 0 Then
                            TxtQutoNo.Enabled = False
                        Else
                            TxtQutoNo.Enabled = True
                        End If
                    ElseIf SalesTrancsationType = "Credit Sales" Then
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.CREDITSALES)
                        If InvoiceBillingSettings.CreditSalesInvoicesetting.InvoiceMethod = 0 Then
                            TxtQutoNo.Enabled = False
                        Else
                            TxtQutoNo.Enabled = True
                        End If
                    ElseIf SalesTrancsationType = "Form-8D" Then
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.FORM8D)
                        If InvoiceBillingSettings.Form8DSalesInvoicesetting.InvoiceMethod = 0 Then
                            TxtQutoNo.Enabled = False
                        Else
                            TxtQutoNo.Enabled = True
                        End If
                    ElseIf SalesTrancsationType = "Form-8B" Then
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.FORM8B)
                        If InvoiceBillingSettings.Form8BSalesInvoicesetting.InvoiceMethod = 0 Then
                            TxtQutoNo.Enabled = False
                        Else
                            TxtQutoNo.Enabled = True
                        End If
                    ElseIf SalesTrancsationType = "Form-8" Then
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.FORM8)
                        If InvoiceBillingSettings.Form8SalesInvoicesetting.InvoiceMethod = 0 Then
                            TxtQutoNo.Enabled = False
                        Else
                            TxtQutoNo.Enabled = True
                        End If
                    Else
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.POS)
                    End If
                Else
                    TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.POS)
                End If


                LblSalesLedger.Visible = True
                TxtSalesLedger.Visible = True
                If txtLedgerName.Items.Contains(DefCashAccount) = True Then
                    txtLedgerName.Text = DefLedgers.CashAccount
                End If
                If TxtSalesPerson.Items.Contains(CurrentUserName) = True Then
                    TxtSalesPerson.Text = CurrentUserName
                End If
                PostDatedBox.Visible = True
        End Select
        TxtRefNo.Text = TxtQutoNo.Text
        If MyAppSettings.IsAllowBatchNoExipry = True Then
            TxtList.Columns("Stbatchno").Visible = True
            TxtList.Columns("stExpiry").Visible = True
        Else
            TxtList.Columns("Stbatchno").Visible = False
            TxtList.Columns("stExpiry").Visible = False
        End If

        LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where (groupname=N'" & AccountGroupNames.CustomersAccounts & "'  or groupname=N'" & AccountGroupNames.CashAccounts & "'))", txtLedgerName, "ledgername")
        LoadDataIntoComboBox("select salespersonname from salespersons where isactive=1", TxtSalesPerson, "salespersonname")

        LoadDataIntoComboBox("SELECT ProjectName   FROM projecttable", TxtProject, "ProjectName")
        LoadDataIntoComboBox("SELECT vattax   FROM Vatclauses where vattype='VAT' or vattype='CST'", TxtStockTax, "vattax")
        LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')", TxtSalesLedger, "ledgername")
        LoadDataIntoComboBox("SELECT Ledgername from ledgers where isactive=1 and (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.DirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "' or groupname=N'" & AccountGroupNames.DirectIncomes & "'))", TxtLedgerName1, "ledgername")
        LoadDataIntoComboBox("SELECT Ledgername from ledgers where isactive=1 and (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.DirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "' or groupname=N'" & AccountGroupNames.DirectIncomes & "'))", TxtLedgerName2, "ledgername")
        LoadDataIntoComboBox("SELECT Ledgername from ledgers where  isactive=1 and (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.DirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "' or groupname=N'" & AccountGroupNames.DirectIncomes & "'))", TxtLedgerName3, "ledgername")

        TxtVoucherType.Text = "Tax Invoice"
        If SQLIsFieldExists("select Vattax from vatclauses where vattype='CST'") = True Then
            TxtVoucherType.Enabled = True
        Else
            TxtVoucherType.Enabled = False
        End If
        If TxtProject.Items.Count > 0 Then
            TxtProject.SelectedIndex = 0
        End If
        If InvoiceCtrlType = "SR" Then
            TxtSalesLedger.Text = DefLedgers.SalesRetAccount
        Else
            TxtSalesLedger.Text = DefLedgers.SalesAccount
        End If
        If SQLIsFieldExists("select ledgername from ledgers where ledgername=N'" & txtLedgerName.Text & "' and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "')") = True Then
            TxtPaymentMethod.Text = "Cash"
            TxtPaymentMethod.Enabled = False
        Else
            TxtPaymentMethod.Enabled = True
        End If
        TxtPriceLevel.Items.Clear()
        LoadDataIntoComboBox("select  pricelistname from pricelist", TxtPriceLevel, "pricelistname")
        TxtPriceLevel.Items.Add("Wholesale")
        TxtPriceLevel.Items.Add("Retail")
        TxtPriceLevel.Items.Add("Custom")
        TxtDiscount.Text = "0"
        TxtDiscAmt.Text = "0"
        TxtGrossTotal.Text = "0"
        TxtNetTotal.Text = "0"
        TxtStockTax.Text = "0"
        TxtStockNetRate.Text = "0"
        TxtTaxTotal.Text = "0"
        IsInvoiceOpen = False
        IsInvoiceSaved = True
        TxtNarration.Text = ""
        TxtAmtInwords.Text = ""
        TxtBatchNo.Text = ""
        TxtList.Rows.Clear()
        TxtList.SerialNumberColName = "stSno"
        TxtList.HasSerialNumber = True

        TxtList.Columns("stbarcode").Visible = False
        TxtList.Columns("stcustbarcode").Visible = True
        IsOpendByWindows = False
        IsPullFromQuto = False
        TxtDrCr1.Text = "Cr"
        TxtDrCr2.Text = "Cr"
        TxtDrCr3.Text = "Cr"
        TxtLedgerName1.Text = ""
        TxtLedgerName2.Text = ""
        TxtLedgerName3.Text = ""
        TxtLedgerAmount1.Text = "0"
        TxtLedgerAmount2.Text = "0"
        TxtLedgerAmount3.Text = "0"
        TxtCouponDiscAmount.Text = "0"
        TxtCouponPer.Text = "0"
        TxtCouponName.Text = ""
        OpenedTransList.ListofTrascodeadded.Rows.Clear()
        SelectedTransList.ListofTrascodeadded.Rows.Clear()
        CurrentTransList.ListofTrascodeadded.Rows.Clear()
        MoreDet.Clear()
        IsTaxInclude = False
        IsInvoiceOpen = False
        IsInvoiceSaved = True
        If InvoiceCtrlType = "POS" Then
            TxtBarCode.Focus()
        End If
        LoadBill2BillReceipts()
        If InvoiceCtrlType = "POS" Then
            txtLedgerName.Text = DefLedgers.CashAccount
            TxtPaymentMethod.Text = "Cash"
            TxtPriceLevel.Text = "Retail"
            TxtBarCode.Focus()
        End If
    End Sub
#End Region

    Private Sub txtLedgerName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLedgerName.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim k As New CreateCustomers
            k.ShowDialog()
            k.Dispose()
            NewCreatedLedgerName = ""
            If InvoiceCtrlType = "POS" Then
                LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "' or groupname=N'" & AccountGroupNames.CashAccounts & "')", txtLedgerName, "ledgername")
            Else
                LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "')", txtLedgerName, "ledgername")
            End If
            txtLedgerName.Text = NewCreatedLedgerName
            txtLedgerName.Focus()
        End If
    End Sub

   

    Private Sub txtLedgerName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLedgerName.LostFocus
        If SQLIsFieldExists("select ledgername from ledgers where ledgername=N'" & txtLedgerName.Text & "' and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "')") = True Then
            TxtPaymentMethod.Text = "Cash"
            TxtPaymentMethod.Enabled = False
            TxtToPrintName.Focus()
        Else
            If TxtPaymentMethod.Text.Length = 0 Then
                TxtPaymentMethod.Text = MyAppSettings.DefaultPaymentMethodOnSales
            ElseIf IsInvoiceOpen = False Then
                TxtPaymentMethod.Text = MyAppSettings.DefaultPaymentMethodOnSales
            End If
            If InvoiceCtrlType = "SR" Then
                If Is_CreditSales = True Then
                    TxtPaymentMethod.Text = "Credit"
                Else
                    TxtPaymentMethod.Text = "Cash"
                End If
            End If
            TxtPaymentMethod.Enabled = True
            TxtToPrintName.Focus()
        End If
    End Sub



    Private Sub txtLedgerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLedgerName.SelectedIndexChanged
      

        If txtLedgerName.Text.Length = 0 Then
            TxtToPrintName.Text = ""

            Exit Sub
        End If


        TxtToPrintName.Text = txtLedgerName.Text

        If MyAppSettings.POSPriceListName = "*All" Then
            Dim Plevel As String
            Plevel = SQLGetStringFieldValue("select PriceLevel from ledgers where ledgername=N'" & txtLedgerName.Text & "'", "PriceLevel", "")
            If Plevel.Length = 0 Then
                TxtPriceLevel.Text = "Retail"
            Else
                TxtPriceLevel.Text = Plevel
            End If
        End If

        TxtCurBalance.Text = "Balance: " & GetCurrentBalanceText(txtLedgerName.Text)
       
        IsInvoiceSaved = False
    End Sub




    Sub GetStockDets(ByVal Ctrlno As Byte, ByVal curchar As String)
        If TxtVoucherType.Text.Length = 0 Then
            MsgBox("Please select the Tax Type .. ", MsgBoxStyle.Information)
            TxtVoucherType.Focus()
            Exit Sub
        End If
        Dim bvalue As New ChooseItemClass
        bvalue.StockItemBarCode = 0
        bvalue.CurrentField = Ctrlno
        bvalue.CurrentChar = curchar
        Dim k As New ChooseItems(bvalue)
        If k.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If bvalue.StockItemBarCode.Length <> 0 Then
                LoadStockItemsIntoClass(bvalue.StockItemBarCode, bvalue.StockLocation, NewAddItem)
                TxtStockDisc.Text = "0"
                TxtStockValue.Text = "0"
                TxtStockTax2 = NewAddItem.Tax2
                TxtStockCode.Text = NewAddItem.StockItemCode
                TxtStockName.Text = NewAddItem.StockItemName
                TxtStockSize.Text = NewAddItem.StockITemSize
                IsTaxInclude = NewAddItem.IsTaxInclude
                TxtMRP.Text = NewAddItem.MRP
                If IsSalesPriceAsMRPWithOutVAT = True Then
                    TxtStockTax.Text = 0
                Else
                    TxtStockTax.Text = NewAddItem.Tax
                End If
                If IsZeroTax = True Then
                    NewAddItem.Tax = 0
                    NewAddItem.Tax2 = 0
                    TxtStockTax.Text = "0"
                    TxtStockTax2 = 0
                End If
                If TxtVoucherType.Text = "Tax Invoice" Then
                    TxtStockTax2 = NewAddItem.Tax2
                    TxtStockTax.Text = NewAddItem.Tax
                Else
                    NewAddItem.Tax = NewAddItem.CSTtax
                    TxtStockTax.Text = NewAddItem.Tax
                    NewAddItem.Tax2 = 0
                    TxtStockTax2 = 0
                End If
                TxtStockQty.SetUnitName(NewAddItem.StockUnitName)
                TxtStockQty.ClearQty()
                TxtStockQty.TxtQty1.Text = "1"

                TxtStockFreeQty.SetUnitName(NewAddItem.StockUnitName)
                TxtStockFreeQty.ClearQty()
                TxtStockFreeQty.TxtQty1.Text = "0"

                TxtRatePer.Items.Clear()

                If NewAddItem.IsSimpleUnit = 1 Then
                    TxtRatePer.Items.Add(NewAddItem.StockUnitName)
                    TxtRatePer.Text = NewAddItem.StockUnitName
                Else
                    TxtRatePer.Items.Add(NewAddItem.StockMainUnitName)
                    TxtRatePer.Items.Add(NewAddItem.StockSubUnitName)
                    TxtRatePer.Text = NewAddItem.StockMainUnitName
                End If
                If IsTaxInclude = True Then

                    Dim NetRate As Double = 0
                    NetRate = FormatNumber(GetStockRateByPriceListName(TxtPriceLevel.Text, NewAddItem.StockItemBarCode, NewAddItem.StockLocation) / CDbl(TxtRateofExchange.Text), 3, , , TriState.False)
                    TxtStockRate.Text = FormatNumber(NetRate * 100 / (100 + CDbl(TxtStockTax.Text)), 3, , , TriState.False)
                    TxtStockNetRate.Text = FormatNumber(NetRate, 3, , , TriState.False)

                Else
                    If TxtPriceLevel.Text = "Custom" Then
                        TxtStockRate.Text = FormatNumber(SQLGetNumericFieldValue("select top 1 stockrate from StockInvoiceRowItems where transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & txtLedgerName.Text & "') and stockcode=N'" & NewAddItem.StockItemCode & "' and stocksize=N'" & NewAddItem.StockITemSize & "' order by transdate desc ", "stockrate") / CDbl(TxtRateofExchange.Text), 3, , , TriState.False)
                    Else
                        TxtStockRate.Text = FormatNumber(GetStockRateByPriceListName(TxtPriceLevel.Text, NewAddItem.StockItemBarCode, NewAddItem.StockLocation) / CDbl(TxtRateofExchange.Text), 3, , , TriState.False)
                    End If


                End If

                If CDbl(TxtStockRate.Text) = 0 Then
                    TxtStockRate.Text = FormatNumber(NewAddItem.StockWRPRate / CDbl(TxtRateofExchange.Text), 3, , , TriState.False)
                End If

                TxtBatchNo.Text = ""
                TxtBatchNo.Items.Clear()
                If NewAddItem.IsBatchNo = 1 Then
                    If MyAppSettings.IsAllowEmptyBatchnoOnSales = True Then
                        LoadDataIntoComboBox("select batchno from stockbatch where stockcode=N'" & NewAddItem.StockItemCode & "' and stocksize=N'" & NewAddItem.StockITemSize & "' and location=N'" & NewAddItem.StockLocation & "' ", TxtBatchNo, "batchno", "")
                    Else
                        LoadDataIntoComboBox("select batchno from stockbatch where stockcode=N'" & NewAddItem.StockItemCode & "' and stocksize=N'" & NewAddItem.StockITemSize & "' and location=N'" & NewAddItem.StockLocation & "' and totalqty>0", TxtBatchNo, "batchno", "")

                    End If

                    TxtBatchNo.Enabled = True

                    Me.TableForItemRow.ColumnStyles.Item(4).Width = 80
                    TxtBatchNo.Focus()
                Else
                    TxtBatchNo.Enabled = False
                    Me.TableForItemRow.ColumnStyles.Item(4).Width = 0
                    TxtStockQty.Focus()
                End If
                TxtStatusText.Text = "Cur Qty:" & SQLGetStringFieldValue("SELECT QTYTEXT FROM STOCKDBF WHERE STOCKCODE=N'" & NewAddItem.StockItemCode & "' AND STOCKSIZE=N'" & NewAddItem.StockITemSize & "' AND LOCATION=N'" & NewAddItem.StockLocation & "'", "QTYTEXT")

            Else
                TxtStockCode.Text = ""
            End If
        Else
            TxtStockCode.Text = ""
        End If
        
        bvalue = Nothing
        k.Dispose()
    End Sub

    Private Sub TxtStockNetRate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtStockNetRate.GotFocus
        IsNetRateCalculate = True
        IsNetValueTextChanged = False
    End Sub

    Private Sub TxtStockNetRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtStockNetRate.LostFocus
        If IsNetRateCalculate = True And IsNetValueTextChanged = True Then
            FindRateOnNetRateChange()
        End If
        IsNetRateCalculate = False
    End Sub

    Private Sub TxtStockDisc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtStockDisc.LostFocus
        FindStockAmount()
    End Sub


    Sub FindStockAmount()
        Dim NetRate As Double = 0
        Try
            'CALCULATE NET RATE FOR  DISCOUNT
            '  TxtStockDiscount2.Text =
            NetRate = (CDbl(TxtStockRate.Text) - CDbl(TxtStockRate.Text) * CDbl(TxtStockDisc.Text) / 100)

            NetRate = (NetRate - CDbl(TxtStockDiscount2.Text))

            'CALCULATE NET RATE FOR  TAX
            Dim temp As Double = 0
            temp = NetRate
            NetRate = NetRate + NetRate * CDbl(TxtStockTax.Text) / 100
            NetRate = NetRate + temp * TxtStockTax2 / 100
            TxtStockNetRate.Text = NetRate

            If TxtRatePer.Text = TxtStockQty.GetSubUnit() Then
                TxtStockValue.Text = NetRate * TxtStockQty.GetTotalQty()
            Else

                TxtStockValue.Text = NetRate * TxtStockQty.GetTotalQty() / TxtStockQty.GetUnitConversion()
            End If
        Catch ex As Exception
            TxtStockValue.Text = "0"
        End Try

    End Sub

    Sub FindRateOnNetRateChange()
        'Dim Rate As Double = 0
        'Try
        '    Rate = CDbl(TxtStockNetRate.Text) * 100 * 100 / ((100 + CDbl(TxtStockTax.Text)) * (100 - CDbl(TxtDiscount.Text)))
        '    TxtStockRate.Text = Rate
        'Catch ex As Exception

        'End Try
    End Sub

    Sub FindTotalAmounts()
        Dim Tot As Double = 0
        Dim nettot As Double = 0
        Dim TaxTotal As Double = 0
        Tax2TotalValue = 0
        Dim Servicetaxtotal As Double = 0
        Try
            For i As Integer = 0 To TxtList.RowCount - 1
                Tot = Tot + CDbl(TxtList.Item("stStockvalueWithOutTax", i).Value)
                TaxTotal = TaxTotal + CDbl(TxtList.Item("sttaxamount", i).Value)
                Try
                    Tax2TotalValue = Tax2TotalValue + CDbl(TxtList.Item("sttaxamount2", i).Value)
                Catch ex As Exception

                End Try
                Servicetaxtotal = Servicetaxtotal + CDbl(TxtList.Item("stStockvalueWithOutTax", i).Value) * CDbl(TxtList.Item("stservicetax", i).Value) / 100
                'TxtList.Columns("stdnoteno").Visible = True
                If Len(TxtList.Item("TUTRANSCODE", i).Value) > 0 Then
                    TxtList.Item("stdnoteno", i).Value = SQLGetStringFieldValue("select qutono from StockInvoiceDetails where vouchername='SD' and transcode=" & TxtList.Item("TUTRANSCODE", i).Value, "qutono")
                Else
                    TxtList.Item("stdnoteno", i).Value = ""
                End If
                '

            Next
            TxtServiceTaxTotal.Text = FormatNumber(Servicetaxtotal, ErpDecimalPlaces, , , TriState.False).ToString
            TxtGrossTotal.Text = FormatNumber(Tot, ErpDecimalPlaces, , , TriState.False).ToString
            TxtTaxTotal.Text = FormatNumber(TaxTotal + Tax2TotalValue, ErpDecimalPlaces, , , TriState.False).ToString
            If TxtDiscount.Text.Length = 0 Then
                TxtDiscAmt.Text = "0.00"
            Else
                If CDbl(TxtGrossTotal.Text) > 0 Then
                    TxtDiscAmt.Text = FormatNumber(-1 * CDbl(TxtGrossTotal.Text) * CDbl(TxtDiscount.Text) / 100, ErpDecimalPlaces, , , TriState.False)
                Else
                    TxtDiscAmt.Text = "0.00"
                End If

            End If
            Dim tempcoupamt As Double = 0

            tempcoupamt = CDbl(TxtGrossTotal.Text) * CDbl(TxtCouponPer.Text) / 100
            If tempcoupamt > TxtCouponDiscAmount.Max Then
                TxtCouponDiscAmount.Text = FormatNumber(TxtCouponDiscAmount.Max, ErpDecimalPlaces, , , TriState.False)
            Else
                TxtCouponDiscAmount.Text = FormatNumber(tempcoupamt, ErpDecimalPlaces, , , TriState.False)
            End If

            TxtNetTotal.Text = FormatNumber(Tot + CDbl(TxtDiscAmt.Text) + TaxTotal + Tax2TotalValue + CDbl(TxtServiceTaxTotal.Text) + CDbl(TxtServiceAccountAmount.Text) + CDbl(TxtDeductions.Text) - CDbl(TxtCouponDiscAmount.Text), ErpDecimalPlaces, , , TriState.False)
            Dim Amt As Double = 0
            TxtRoundoff = "0"
            Select Case InvoiceCtrlType
                Case "SO"

                Case "SI"
                    If RoundoffInvoiceSettings.AllowinSalesInvoice = True Then
                        Amt = CDbl(TxtNetTotal.Text)
                        TxtNetTotal.Text = FormatNumber(Math.Round(Amt), ErpDecimalPlaces)
                        TxtRoundoff = FormatNumber(Math.Round(Amt) - Amt, 2)
                    End If
                Case "SQ"
                    TxtRoundoff = "0"
                Case "SR"
                    If RoundoffInvoiceSettings.AllowinSalesRet = True Then
                        Amt = CDbl(TxtNetTotal.Text)
                        TxtNetTotal.Text = FormatNumber(Math.Round(Amt), ErpDecimalPlaces)
                        TxtRoundoff = FormatNumber(Math.Round(Amt) - Amt, 2)
                    End If
                Case "SD"
                    If RoundoffInvoiceSettings.AllowinDNote = True Then
                        Amt = CDbl(TxtNetTotal.Text)
                        TxtNetTotal.Text = FormatNumber(Math.Round(Amt), ErpDecimalPlaces)
                        TxtRoundoff = FormatNumber(Math.Round(Amt) - Amt, 2)
                    End If
                Case "POS"
                    If RoundoffInvoiceSettings.AllowinPOS = True Then
                        Amt = CDbl(TxtNetTotal.Text)
                        TxtNetTotal.Text = FormatNumber(Math.Round(Amt), ErpDecimalPlaces)
                        TxtRoundoff = FormatNumber(Math.Round(Amt) - Amt, 2)
                    End If
            End Select


        Catch ex As Exception

        End Try



        TxtVoucherType.Enabled = False

    End Sub

    Private Sub TxtStockQty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtStockQty.GotFocus

    End Sub




    Private Sub TxtStockQty_QtyChanageEvent(ByVal e As Object) Handles TxtStockQty.QtyChanageEvent
        FindStockAmount()
    End Sub

    Private Sub TxtStockQty_QtyLostFocus(ByVal e As Object) Handles TxtStockQty.QtyLostFocus
        FindStockAmount()
    End Sub





    Private Sub SalesQuotoControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDataIntoComboBox("select currencycode from currencylist", TxtCurrency, "Currencycode")
        LoadDataIntoComboBox("select CurrencyCode from currencylist ", TxtBillingCurrency, "CurrencyCode")
        If InvoiceCtrlType = "POS" Or InvoiceCtrlType = "SR" Or InvoiceCtrlType = "SI" Then
            LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "' or groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')", TxtPaymentBy, "ledgername")
            LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "' or groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')", txtLedgerName, "ledgername")
            TxtPaymentMethod.Items.Clear()
            TxtPaymentMethod.Items.Add("Cash")
            TxtPaymentMethod.Items.Add("Card")
            TxtPaymentMethod.Items.Add("Gift Voucher")
            TxtPaymentMethod.Items.Add("Voucher")
            TxtPaymentMethod.Items.Add("Credit")
        Else
            LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "')", txtLedgerName, "ledgername")
            TxtPaymentBy.Items.Add("")
            TxtPaymentBy.Items.Add("")
        End If

        If IsOpenedOutsideforDelete = False Then
            ERPInitializeObjects(sender)
            LoadDisplaySettings()

            If IsOpenedFromOutside = True Then
                LoadDefaults()
                TxtVoucherType.Enabled = False
                LoadStockEntryDefaults()
                LockTransaction(OpenedTranscode)
                OpenByTransCodeID(OpenedTranscode)
            Else

                LoadDefaults()

                If SQLIsFieldExists("select Vattax from vatclauses where vattype='CST'") = True Then
                    TxtVoucherType.Enabled = True
                Else
                    TxtVoucherType.Enabled = False
                End If

            End If

        End If
        TxtExchangeText.Text = "Rate of Exchange equal to " & CompDetails.Currency
        txtLedgerName.SetLedgerFilterType = SelectedLedgerNameClass.LedgerTypeEnum.Customersandsupplierswithcashandbanks
        ToolTip1.SetToolTip(grpDetails, "Double click to hide/unhide the details to Increase/Decrease the Item List")
        ToolTip2.SetToolTip(grpOptions, "Double click to hide/unhide the details  to Increase/Decrease the Item List")
        ToolTip3.SetToolTip(lblLedgerGroup, "Double click to hide/unhide the details  to Increase/Decrease the Item List")
    End Sub

    Sub LoadStockEntryDefaults()
        TxtStockCode.Text = ""
        TxtStockSize.Text = ""
        TxtBarCode.Text = ""
        TxtStockName.Text = ""
        TxtStockTax.Text = "0"
        TxtStockNetRate.Text = "0"
        TxtStockTax2 = 0
        TxtRatePer.Text = "0"
        TxtStockQty.ClearQty()
        TxtStockQty.TxtQty1.Text = "1"
        TxtStockFreeQty.ClearQty()
        TxtStockFreeQty.TxtQty1.Text = "0"
        TxtStockDisc.Text = "0"
        TxtStockRate.Text = "0"
        TxtMRP.Text = "0"
        TxtBatchNo.Text = ""
        TxtStockValue.Text = "0"
        TxtStockDiscount2.Text = "0"
        IsEditItem = False
        IsEditing = False
        BtnEditCancel.Visible = False
        TxtList.Enabled = True
    End Sub

    Private Sub TxtStockValue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtStockValue.GotFocus
        IsValuecalculate = True
        IsValueTextChanged = False
    End Sub

    Private Sub TxtStockValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtStockValue.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            AddItems()

        End If
    End Sub
    Sub AddItems()
        If (MyAppSettings.IsAllowNegativeStock = False And InvoiceCtrlType = "SD") Or (MyAppSettings.IsAllowNegativeStock = False And InvoiceCtrlType = "POS") Then
            If TxtStockQty.GetTotalQty() > SQLGetNumericFieldValue("select totalqty from stockdbf where barcode=N'" & NewAddItem.StockItemBarCode & "'", "totalqty") Then
                MsgBox("The Stock Quantity is greater than the available stock....", MsgBoxStyle.Information)
                TxtStockQty.Focus()
                Exit Sub
            End If
        End If
        If TxtStockCode.Text.Length = 0 Then
            TxtStockCode.Focus()
            Exit Sub
        End If
        If TxtBatchNo.Enabled = True Then
            If TxtBatchNo.Text.Length = 0 Then
                TxtBatchNo.Focus()
                Exit Sub
            End If
        End If
        Dim CRate As Double = 1
        If IsValuesInBillingCurrency.Checked = True Then
            CRate = CDbl(TxtRateofExchange.Text)
        Else
            CRate = 1
        End If
        If IsEditItem = True Then
            If MsgBox("Do you want to Edit ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                Dim nR As Integer
                nR = EditItemRow
                TxtList.Item("stsno", nR).Value = nR + 1
                TxtList.Item("stlocation", nR).Value = NewAddItem.StockLocationNames
                TxtList.Item("StItemcode", nR).Value = NewAddItem.StockItemCode
                TxtList.Item("Stitemname", nR).Value = NewAddItem.StockItemName
                TxtList.Item("Stbarcode", nR).Value = NewAddItem.StockItemBarCode
                TxtList.Item("stcustbarcode", nR).Value = NewAddItem.CustBarCode
                TxtList.Item("Stsize", nR).Value = NewAddItem.StockITemSize
                TxtList.Item("Stbatchno", nR).Value = TxtBatchNo.Text

                TxtList.Item("stfreeqty", nR).Value = TxtStockFreeQty.GetTotalQty
                TxtList.Item("stfreeqtytext", nR).Value = TxtStockFreeQty.GetTotalQtyText

                TxtList.Item("stMqty", nR).Value = TxtStockQty.GetTotalQty
                TxtList.Item("stMqtytext", nR).Value = TxtStockQty.GetTotalQtyText

                TxtStockFreeQty.TxtQty1.Text = CDbl(TxtStockQty.TxtQty1.Text) + CDbl(TxtStockFreeQty.TxtQty1.Text)
                TxtStockFreeQty.TxtQty2.Text = CDbl(TxtStockQty.TxtQty2.Text) + CDbl(TxtStockFreeQty.TxtQty2.Text)
                TxtStockFreeQty.CalculateValues()

                TxtList.Item("stqty", nR).Value = TxtStockFreeQty.GetTotalQty
                TxtList.Item("stqtytext", nR).Value = TxtStockFreeQty.GetTotalQtyText

                If TxtRatePer.Text = TxtStockQty.GetSubUnit() Then
                    Dim trate As Double
                    trate = CDbl(TxtStockRate.Text) * CDbl(TxtRateofExchange.Text) / CRate * TxtStockQty.GetUnitConversion
                    TxtList.Item("strate", nR).Value = trate
                    TxtList.Item("strateper", nR).Value = TxtStockQty.GetMainUnit
                    trate = trate - trate * CDbl(TxtStockDisc.Text) / 100
                    trate = trate - CDbl(TxtStockDiscount2.Text)
                    TxtList.Item("stStockvalueWithOutTax", nR).Value = trate * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                    TxtList.Item("sttaxamount", nR).Value = trate * CDbl(TxtStockTax.Text) / 100 * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                    If MyAppSettings.IsAllowMultiTaxRatesOnSales = False Then
                        TxtList.Item("sttaxamount2", nR).Value = 0
                    Else
                        TxtList.Item("sttaxamount2", nR).Value = trate * NewAddItem.Tax2 / 100 * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                    End If
                    trate = trate + (trate * CDbl(TxtStockTax.Text) / 100) + (trate * TxtStockTax2 / 100)
                    TxtList.Item("stnetrate", nR).Value = trate
                Else
                    Dim trate As Double
                    trate = CDbl(TxtStockRate.Text) * CDbl(TxtRateofExchange.Text) / CRate
                    TxtList.Item("strate", nR).Value = trate
                    TxtList.Item("strateper", nR).Value = TxtStockQty.GetMainUnit
                    trate = trate - trate * CDbl(TxtStockDisc.Text) / 100
                    trate = trate - CDbl(TxtStockDiscount2.Text)

                    TxtList.Item("stStockvalueWithOutTax", nR).Value = trate * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                    TxtList.Item("sttaxamount", nR).Value = trate * CDbl(TxtStockTax.Text) / 100 * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                    If MyAppSettings.IsAllowMultiTaxRatesOnSales = False Then
                        TxtList.Item("sttaxamount2", nR).Value = 0
                    Else
                        TxtList.Item("sttaxamount2", nR).Value = trate * NewAddItem.Tax2 / 100 * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                    End If
                    trate = trate + (trate * CDbl(TxtStockTax.Text) / 100) + (trate * TxtStockTax2 / 100)
                    TxtList.Item("stnetrate", nR).Value = trate
                End If
                TxtList.Item("stdiscount", nR).Value = TxtStockDisc.Text
                TxtList.Item("tdisc2", nR).Value = TxtStockDiscount2.Text
                TxtList.Item("stdiscamt1", nR).Value = CDbl(TxtStockDisc.Text) * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                TxtList.Item("stdiscamt2", nR).Value = CDbl(TxtStockDiscount2.Text) * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                TxtList.Item("StStockTaxValue", nR).Value = CDbl(TxtStockValue.Text) * CDbl(TxtRateofExchange.Text) / CRate
                TxtList.Item("stmainunit", nR).Value = TxtStockQty.GetMainUnit
                TxtList.Item("stsubunit", nR).Value = TxtStockQty.GetSubUnit
                TxtList.Item("sthscode", nR).Value = NewAddItem.HScode
                TxtList.Item("stmadeby", nR).Value = NewAddItem.Madeby
                TxtList.Item("sttax", nR).Value = TxtStockTax.Text
                If MyAppSettings.IsAllowMultiTaxRatesOnSales = False Then
                    TxtList.Item("sttax2", nR).Value = 0
                Else
                    TxtList.Item("sttax2", nR).Value = NewAddItem.Tax2
                End If
                TxtList.Item("stservicetax", nR).Value = NewAddItem.ServiceTax
                TxtList.Item("stmrp", nR).Value = TxtMRP.Text
                If TxtBatchNo.Text.Length > 0 Then
                    NewAddItem.StockExpirydate = CDate(SQLGetStringFieldValue("SELECT Expiry FROM STOCKBATCH WHERE STOCKCODE=N'" & NewAddItem.StockItemCode & "' AND STOCKSIZE=N'" & NewAddItem.StockITemSize & "' AND LOCATION=N'" & NewAddItem.StockLocation & "' AND BATCHNO=N'" & TxtBatchNo.Text & "'", "Expiry"))
                    'SQLGetStringFieldValue("SELECT Expiry FROM STOCKBATCH WHERE STOCKCODE=N'" & NewAddItem.StockItemCode & "' AND STOCKSIZE=N'" & NewAddItem.StockITemSize & "' AND LOCATION=N'" & NewAddItem.StockLocation & "' AND BATCHNO=N'" & TxtBatchNo.Text & "'", "Expiry"))
                    TxtList.Item("stprate", nR).Value = SQLGetNumericFieldValue("SELECT stockrate FROM STOCKBATCH WHERE STOCKCODE=N'" & NewAddItem.StockItemCode & "' AND STOCKSIZE=N'" & NewAddItem.StockITemSize & "' AND LOCATION=N'" & NewAddItem.StockLocation & "' AND BATCHNO=N'" & TxtBatchNo.Text & "'", "stockrate")
                    TxtList.Item("stExpiry", nR).Value = NewAddItem.StockExpirydate
                Else
                    TxtList.Item("stExpiry", nR).Value = ""
                    If Len(TxtList.Item("stprate", nR).Value) = 0 Then
                        TxtList.Item("stprate", nR).Value = GetPresetCostofStockItem(NewAddItem.StockItemBarCode)
                    ElseIf CDbl(TxtList.Item("stprate", nR).Value) = 0 Then
                        TxtList.Item("stprate", nR).Value = GetPresetCostofStockItem(NewAddItem.StockItemBarCode)
                    End If
                End If
                If IsValuesInBillingCurrency.Checked = False Then
                    TxtList.Item("stprofit", nR).Value = (CDbl(TxtList.Item("stnetrate", nR).Value) - CDbl(TxtList.Item("stprate", nR).Value)) * TxtStockQty.GetTotalQty() / TxtStockQty.GetUnitConversion()
                Else
                    TxtList.Item("stprofit", nR).Value = ((CDbl(TxtList.Item("stnetrate", nR).Value) * CDbl(TxtRateofExchange.Text)) - CDbl(TxtList.Item("stprate", nR).Value)) * TxtStockQty.GetTotalQty() / TxtStockQty.GetUnitConversion()
                End If

                'NetRate * TxtStockQty.GetTotalQty() / TxtStockQty.GetUnitConversion()
                TxtList.Item("stpacking", nR).Value = NewAddItem.Packing
                If TxtList.RowCount > 3 Then
                    TxtList.FirstDisplayedCell = TxtList.Item(0, TxtList.RowCount - (TxtList.DisplayedRowCount(False)) + 1)
                End If
                TxtList.Item("stconrate", nR).Value = CDbl(TxtRateofExchange.Text)
                LoadStockEntryDefaults()
                FindTotalAmounts()
                TxtStockCode.Focus()
                IsInvoiceSaved = False
                IsEditing = False
                IsEditItem = False
            End If
        Else

            If MsgBox("Do you want to Add ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                Dim nR As Integer
                nR = TxtList.Rows.Add()
                TxtList.Item("stsno", nR).Value = nR + 1
                TxtList.Item("stlocation", nR).Value = NewAddItem.StockLocationNames
                TxtList.Item("StItemcode", nR).Value = NewAddItem.StockItemCode
                TxtList.Item("Stitemname", nR).Value = NewAddItem.StockItemName
                TxtList.Item("Stbarcode", nR).Value = NewAddItem.StockItemBarCode
                TxtList.Item("Stsize", nR).Value = NewAddItem.StockITemSize
                TxtList.Item("Stbatchno", nR).Value = TxtBatchNo.Text
                TxtList.Item("stcustbarcode", nR).Value = NewAddItem.CustBarCode

                TxtList.Item("stfreeqty", nR).Value = TxtStockFreeQty.GetTotalQty
                TxtList.Item("stfreeqtytext", nR).Value = TxtStockFreeQty.GetTotalQtyText

                TxtList.Item("stMqty", nR).Value = TxtStockQty.GetTotalQty
                TxtList.Item("stMqtytext", nR).Value = TxtStockQty.GetTotalQtyText

                TxtStockFreeQty.TxtQty1.Text = CDbl(TxtStockQty.TxtQty1.Text) + CDbl(TxtStockFreeQty.TxtQty1.Text)
                TxtStockFreeQty.TxtQty2.Text = CDbl(TxtStockQty.TxtQty2.Text) + CDbl(TxtStockFreeQty.TxtQty2.Text)
                TxtStockFreeQty.CalculateValues()
                TxtList.Item("stqty", nR).Value = TxtStockFreeQty.GetTotalQty
                TxtList.Item("stqtytext", nR).Value = TxtStockFreeQty.GetTotalQtyText

                If TxtRatePer.Text = TxtStockQty.GetSubUnit() Then
                    Dim trate As Double
                    trate = CDbl(TxtStockRate.Text) * CDbl(TxtRateofExchange.Text) / CRate * TxtStockQty.GetUnitConversion
                    TxtList.Item("strate", nR).Value = trate
                    TxtList.Item("strateper", nR).Value = TxtStockQty.GetMainUnit
                    trate = trate - trate * CDbl(TxtStockDisc.Text) / 100
                    trate = trate - CDbl(TxtStockDiscount2.Text)
                    TxtList.Item("stStockvalueWithOutTax", nR).Value = trate * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                    TxtList.Item("sttaxamount", nR).Value = trate * CDbl(TxtStockTax.Text) / 100 * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                    If MyAppSettings.IsAllowMultiTaxRatesOnSales = False Then
                        TxtList.Item("sttaxamount2", nR).Value = 0
                    Else
                        TxtList.Item("sttaxamount2", nR).Value = trate * NewAddItem.Tax2 / 100 * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                    End If
                    trate = trate + (trate * CDbl(TxtStockTax.Text) / 100) + (trate * TxtStockTax2 / 100)
                    TxtList.Item("stnetrate", nR).Value = trate
                Else
                    Dim trate As Double
                    trate = CDbl(TxtStockRate.Text) * CDbl(TxtRateofExchange.Text) / CRate
                    TxtList.Item("strate", nR).Value = trate
                    TxtList.Item("strateper", nR).Value = TxtStockQty.GetMainUnit
                    trate = trate - trate * CDbl(TxtStockDisc.Text) / 100
                    trate = trate - CDbl(TxtStockDiscount2.Text)

                    TxtList.Item("stStockvalueWithOutTax", nR).Value = trate * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                    TxtList.Item("sttaxamount", nR).Value = trate * CDbl(TxtStockTax.Text) / 100 * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                    If MyAppSettings.IsAllowMultiTaxRatesOnSales = False Then
                        TxtList.Item("sttaxamount2", nR).Value = 0
                    Else
                        TxtList.Item("sttaxamount2", nR).Value = trate * NewAddItem.Tax2 / 100 * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                    End If
                    trate = trate + (trate * CDbl(TxtStockTax.Text) / 100) + (trate * TxtStockTax2 / 100)
                    TxtList.Item("stnetrate", nR).Value = trate
                End If

                TxtList.Item("stdiscount", nR).Value = TxtStockDisc.Text
                TxtList.Item("tdisc2", nR).Value = TxtStockDiscount2.Text
                TxtList.Item("stdiscamt1", nR).Value = CDbl(TxtStockDisc.Text) * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                TxtList.Item("stdiscamt2", nR).Value = CDbl(TxtStockDiscount2.Text) * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                TxtList.Item("StStockTaxValue", nR).Value = CDbl(TxtStockValue.Text) * CDbl(TxtRateofExchange.Text) / CRate
                TxtList.Item("stmainunit", nR).Value = TxtStockQty.GetMainUnit
                TxtList.Item("stsubunit", nR).Value = TxtStockQty.GetSubUnit
                TxtList.Item("sthscode", nR).Value = NewAddItem.HScode
                TxtList.Item("stmadeby", nR).Value = NewAddItem.Madeby
                TxtList.Item("sttax", nR).Value = TxtStockTax.Text
                If MyAppSettings.IsAllowMultiTaxRatesOnSales = False Then
                    TxtList.Item("sttax2", nR).Value = 0
                Else
                    TxtList.Item("sttax2", nR).Value = NewAddItem.Tax2
                End If
                TxtList.Item("tutranscode", nR).Value = 0
                TxtList.Item("stservicetax", nR).Value = NewAddItem.ServiceTax
                TxtList.Item("stprate", nR).Value = GetPresetCostofStockItem(NewAddItem.StockItemBarCode)
                TxtList.Item("stmrp", nR).Value = TxtMRP.Text
                If TxtBatchNo.Text.Length > 0 Then
                    NewAddItem.StockExpirydate = CDate(SQLGetStringFieldValue("SELECT Expiry FROM STOCKBATCH WHERE STOCKCODE=N'" & NewAddItem.StockItemCode & "' AND STOCKSIZE=N'" & NewAddItem.StockITemSize & "' AND LOCATION=N'" & NewAddItem.StockLocation & "' AND BATCHNO=N'" & TxtBatchNo.Text & "'", "Expiry"))
                    'SQLGetStringFieldValue("SELECT Expiry FROM STOCKBATCH WHERE STOCKCODE=N'" & NewAddItem.StockItemCode & "' AND STOCKSIZE=N'" & NewAddItem.StockITemSize & "' AND LOCATION=N'" & NewAddItem.StockLocation & "' AND BATCHNO=N'" & TxtBatchNo.Text & "'", "Expiry"))
                    TxtList.Item("stprate", nR).Value = SQLGetNumericFieldValue("SELECT stockrate FROM STOCKBATCH WHERE STOCKCODE=N'" & NewAddItem.StockItemCode & "' AND STOCKSIZE=N'" & NewAddItem.StockITemSize & "' AND LOCATION=N'" & NewAddItem.StockLocation & "' AND BATCHNO=N'" & TxtBatchNo.Text & "'", "stockrate")
                    TxtList.Item("stExpiry", nR).Value = NewAddItem.StockExpirydate
                Else
                    TxtList.Item("stExpiry", nR).Value = ""
                    If Len(TxtList.Item("stprate", nR).Value) = 0 Then
                        TxtList.Item("stprate", nR).Value = GetPresetCostofStockItem(NewAddItem.StockItemBarCode)
                    ElseIf CDbl(TxtList.Item("stprate", nR).Value) = 0 Then
                        TxtList.Item("stprate", nR).Value = GetPresetCostofStockItem(NewAddItem.StockItemBarCode)
                    End If
                End If

                If IsValuesInBillingCurrency.Checked = False Then
                    TxtList.Item("stprofit", nR).Value = (CDbl(TxtList.Item("stnetrate", nR).Value) - CDbl(TxtList.Item("stprate", nR).Value)) * TxtStockQty.GetTotalQty() / TxtStockQty.GetUnitConversion()
                Else
                    TxtList.Item("stprofit", nR).Value = ((CDbl(TxtList.Item("stnetrate", nR).Value) * CDbl(TxtRateofExchange.Text)) - CDbl(TxtList.Item("stprate", nR).Value)) * TxtStockQty.GetTotalQty() / TxtStockQty.GetUnitConversion()
                End If
                TxtList.Item("stconrate", nR).Value = CDbl(TxtRateofExchange.Text)
                TxtList.Item("stpacking", nR).Value = NewAddItem.Packing
                TxtList.Item("stslnos", nR).Value = ""
                If TxtList.RowCount > 3 Then
                    TxtList.FirstDisplayedCell = TxtList.Item(0, TxtList.RowCount - (TxtList.DisplayedRowCount(False)) + 1)
                End If
                LoadStockEntryDefaults()

                FindTotalAmounts()

                TxtStockCode.Focus()

                IsInvoiceSaved = False
                IsEditing = False
            End If
        End If
        If IsBarcodeEntered = True Then
            TxtBarCode.Focus()
        End If
    End Sub

    Private Sub TxtDiscount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTaxTotal.TextChanged, TxtServiceTaxTotal.TextChanged
        FindTotalAmounts()
    End Sub



    Private Sub TxtList_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles TxtList.RowsRemoved
        FindTotalAmounts()
    End Sub

    Private Sub BtnEditCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditCancel.Click
        LoadStockEntryDefaults()
    End Sub



    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, SaveToolStripMenuItem1.Click
        CheckBeforeSave()
    End Sub

    Sub CheckBeforeSave()
        If IsInvoiceOpen = True And User_IsAllowtoEdit = False Then
            MsgBox("Error: Edit is not allowed ,Contact Admin Department ... ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If DefLedgers.SalesDiscountLedger.Length = 0 Then
            MsgBox("Please set the default ledger for the Sales Discount...      ", MsgBoxStyle.Information)
            Exit Sub
        End If
        TableLayoutPanel1.RowStyles(1).Height = 127
        TableLayoutPanel1.RowStyles(4).Height = 129
        If IsInvoiceOpen = True Then
            If IsAuditConfirm(OpenedTranscode, "Inventory") = True Then
                MsgBox("The Selected Entry can't be Editable....", MsgBoxStyle.Information)
                Exit Sub
            End If
        Else
            If MyAppSettings.IsAllowDuplicatInvoice = False Then
                If SQLIsFieldExists("SELECT TOP 1 1 from   bill2bill where RefNo=N'" & TxtRefNo.Text & "' and ledgername=N'" & txtLedgerName.Text & "'") = True Then
                    MsgBox("The Reference Number is already exists for the Selected Account, Please Try again....", MsgBoxStyle.Information)
                    TxtRefNo.Focus()
                    Exit Sub
                ElseIf SQLIsFieldExists("select TransCode from StockInvoiceDetails where QutoRef=N'" & TxtRefNo.Text & "' and vouchername=N'" & InvoiceCtrlType & "'") = True Then
                    MsgBox("The Reference Number is already exists for the Selected Account, Please Try again....", MsgBoxStyle.Information)
                    TxtRefNo.Focus()
                    Exit Sub
                End If
            End If

        End If

        If TxtRefNo.Text.Length = 0 Then
            MsgBox("Please Enter the Reference Number....")
            TxtRefNo.Focus()
            Exit Sub
        End If
        If TxtCurrency.Text.Length = 0 Then
            MsgBox("Please select the Currency Code...  ", MsgBoxStyle.Information)
            TxtCurrency.Focus()
            Exit Sub
        End If
        If txtLedgerName.Text.Length = 0 Then
            MsgBox("Please Select the Account Name      ", MsgBoxStyle.Information)
            txtLedgerName.Focus()
            Exit Sub
        End If
        If CDbl(TxtGrossTotal.Text) < 0 Then
            MsgBox("Please Select the Items, Press any key to add items at item code or item name fileds...")
            TxtStockCode.Focus()
            Exit Sub
        End If
        If TxtList.RowCount = 0 Then
            MsgBox("Please Select the Items, Press any key to add items at item code or item name fileds...")
            TxtStockCode.Focus()
            Exit Sub
        End If
        If CDbl(TxtNetTotal.Text) < 0 Then
            MsgBox("Please Select the Items, Press any key to add items at item code or item name fileds...")
            TxtStockCode.Focus()
            Exit Sub
        End If
        Select Case InvoiceCtrlType
            Case "SD", "SR", "POS", "SI"
                If TxtSalesLedger.Text.Length = 0 Then
                    MsgBox("Please Select the Sales Account Ledger      ", MsgBoxStyle.Information)
                    TxtSalesLedger.Focus()
                    Exit Sub
                End If
        End Select
        If TxtPaymentMethod.Text.Length = 0 Then
            TxtPaymentMethod.Text = "Credit"
        End If

        If InvoiceCtrlType = "POS" Then
            If SQLIsFieldExists("select ledgername from ledgers where ledgername=N'" & txtLedgerName.Text & "' and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "')") = False Then
                'CHECKING FOR CREDIT
                Dim CreditAmount As Double = SQLGetNumericFieldValue("select creditlimit from ledgers where ledgername=N'" & txtLedgerName.Text & "'", "creditlimit")
                If CreditAmount > 0 Then
                    If IsInvoiceOpen = True Then
                        If TxtPaymentMethod.Text.ToUpper = "CREDIT" Then
                            Dim currentbalance = GetCurrentBalanceValue(txtLedgerName.Text, True) - SQLGetNumericFieldValue("select sum(dr-cr) as tot from ledgerbook where isdeleted=0 and ledgername=N'" & txtLedgerName.Text & "' and transcode=" & OpenedTranscode, "tot")
                            If currentbalance + CDbl(TxtNetTotal.Text) > CreditAmount Then
                                Dim frm As New AdminLoginForAcceptChages
                                frm.TxtTitle.Text = "The Credit Limit is exceeded , It is not allowed to Made this invoice "
                                If frm.ShowDialog() <> DialogResult.OK Then
                                    Exit Sub
                                End If
                            End If
                        End If

                    Else
                        If TxtPaymentMethod.Text.ToUpper = "CREDIT" Then
                            Dim currentbalance = GetCurrentBalanceValue(txtLedgerName.Text, True)
                            If currentbalance + CDbl(TxtNetTotal.Text) > CreditAmount Then
                                Dim frm As New AdminLoginForAcceptChages
                                frm.TxtTitle.Text = "The Credit Limit is exceeded , It is not allowed to Made this invoice "
                                If frm.ShowDialog() <> DialogResult.OK Then
                                    Exit Sub
                                End If

                            End If
                        End If

                    End If
                End If

                If IsDirectSales = True Then
                    If TxtPaymentMethod.Text.Length = 0 Then
                        TxtPaymentMethod.Text = "Credit"
                    End If
                Else
                    If TxtPaymentMethod.Text = "Credit" Then
                    Else
                        If TxtPaymentBy.Text.Length = 0 Or TxtPaymentMethod.Text.Length = 0 Then
                            MsgBox("Please Select the Payment Details ...", MsgBoxStyle.Information)
                            TabControl1.SelectedIndex = 1
                            TxtPaymentBy.Focus()
                            Exit Sub
                        End If
                    End If
                End If
            End If
        End If
        If CDbl(TxtAdvancePayment.Text) > CDbl(TxtNetTotal.Text) Then
            MsgBox("The Advance Received amount is greater than the Bill Total, Please Check again...", MsgBoxStyle.Information)
            TxtAdvancePayment.Focus()
            Exit Sub
        End If
        If TxtPaymentMethod.Text <> "Credit" Then
            TxtAdvancePayment.Text = "0"
        End If
        If SQLIsFieldExists("SELECT TOP 1 1 from   ledgers where ledgername=N'" & txtLedgerName.Text & "'") = False Then
            MsgBox("The Ledger Name : " & txtLedgerName.Text & "  is not exists, It may be modified or deleted, Please make sure and try again....", MsgBoxStyle.Critical)
            txtLedgerName.Focus()
            Exit Sub
        End If
        If TxtLedgerName1.Text.Length > 0 Then
            If SQLIsFieldExists("SELECT TOP 1 1 from   ledgers where ledgername=N'" & TxtLedgerName1.Text & "'") = False Then
                MsgBox("The Ledger Name : " & TxtLedgerName1.Text & "  is not exists, It may be modified or deleted, Please make sure and try again....", MsgBoxStyle.Critical)
                TxtLedgerName1.Focus()
                Exit Sub
            End If
        End If


        If TxtLedgerName2.Text.Length > 0 Then
            If SQLIsFieldExists("SELECT TOP 1 1 from   ledgers where ledgername=N'" & TxtLedgerName2.Text & "'") = False Then
                MsgBox("The Ledger Name : " & TxtLedgerName2.Text & "  is not exists, It may be modified or deleted, Please make sure and try again....", MsgBoxStyle.Critical)
                TxtLedgerName2.Focus()
                Exit Sub
            End If
        End If

        If TxtLedgerName3.Text.Length > 0 Then
            If SQLIsFieldExists("SELECT TOP 1 1 from   ledgers where ledgername=N'" & TxtLedgerName3.Text & "'") = False Then
                MsgBox("The Ledger Name : " & TxtLedgerName3.Text & "  is not exists, It may be modified or deleted, Please make sure and try again....", MsgBoxStyle.Critical)
                TxtLedgerName3.Focus()
                Exit Sub
            End If
        End If
        If MyAppSettings.AllowCostingforInvoicesAlso = True Then
            If InvoiceCtrlType = "SR" Or InvoiceCtrlType = "SD" Or InvoiceCtrlType = "POS" Then
                If SQLGetStringFieldValue("select IsAllowCostCentre from ledgers where ledgername=N'" & txtLedgerName.Text & "'", "IsAllowCostCentre", False) = True Then
                    Dim lfrm As New Costcenterallocation(CostList, TxtNetTotal.Text, txtLedgerName.Text)
                    lfrm.ShowDialog()
                    lfrm.Dispose()
                Else
                    CostList.Rows.Clear()
                End If
            End If
        End If
        If InvoiceCtrlType = "SR" And TxtPaymentMethod.Text <> "Cash" Then
            If SQLGetNumericFieldValue("select isbillwise from ledgers where ledgername=N'" & txtLedgerName.Text & "'", "isbillwise") = 1 Then
                Bill2Billdetails.LedgerAmount = CDbl(TxtNetTotal.Text)
                Dim bfrom As New BillwiseDetailsEntryForm(txtLedgerName.Text, Bill2Billdetails, 0)
                bfrom.TxtHeading.Text = "Bill Wise Allocation for " & txtLedgerName.Text
                bfrom.ShowDialog()
                If Bill2Billdetails.LedgerAmount <> Bill2Billdetails.AllocationAmount Then
                    Bill2Billdetails.BillList.Rows.Clear()
                End If
            End If
        End If

        If MsgBox("Do you want to save ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            IsValuesInBillingCurrency.Checked = False
            SaveData()
        End If
    End Sub
    Sub UpdateOrderedItemsQtys()
        If InvoiceCtrlType = "POS" Or InvoiceCtrlType = "SD" Or InvoiceCtrlType = "SI" Then
            For i As Integer = 0 To TxtList.RowCount - 1
                If Len(TxtList.Item("TUTRANSCODE", i).Value) = 0 Then Exit Sub
                If Len(TxtList.Item("stqty", i).Value) = 0 Then
                    TxtList.Item("stqty", i).Value = "0"
                End If
                If SQLIsFieldExists("select barcode from StockInvoiceRowItems WHERE  TRANSCODE=" & TxtList.Item("TUTRANSCODE", i).Value & " and barcode=N'" & TxtList.Item("StBarCode", i).Value & "' and (usedqty is null)  and batchno=N'" & TxtList.Item("Stbatchno", i).Value & "'") = True Then
                    ExecuteSQLQuery("UPDATE StockInvoiceRowItems SET USEDQTY=0 WHERE TRANSCODE=" & TxtList.Item("TUTRANSCODE", i).Value & " and barcode=N'" & TxtList.Item("StBarCode", i).Value & "'  and batchno=N'" & TxtList.Item("Stbatchno", i).Value & "'")
                End If
                ExecuteSQLQuery("UPDATE StockInvoiceRowItems SET USEDQTY=USEDQTY+" & CDbl(TxtList.Item("stqty", i).Value) & " WHERE TRANSCODE=" & TxtList.Item("TUTRANSCODE", i).Value & " and barcode=N'" & TxtList.Item("StBarCode", i).Value & "'  and batchno=N'" & TxtList.Item("Stbatchno", i).Value & "'")
            Next
        End If
    End Sub
    Sub RollBackUpdatedOrdereditemsQtys()
        'JVS

        Dim Sqlstr1 As String = ""
        Sqlstr1 = "select totalqty,utranscode,barcode,batchno from StockInvoiceRowItems  where transcode=" & OpenedTranscode
        Dim SqlConn1 As New SqlClient.SqlConnection
        Dim SQLFcmd12 As New SqlClient.SqlCommand
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            SQLFcmd12.Connection = SqlConn1
            SQLFcmd12.CommandText = Sqlstr1
            SQLFcmd12.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd12.ExecuteReader
            While Sreader.Read()
                If IsDBNull(Sreader("utranscode")) = False Then
                    If Len(Sreader("utranscode")) > 0 Then
                        ExecuteSQLQuery("UPDATE StockInvoiceRowItems SET USEDQTY=USEDQTY-" & Sreader("totalqty") & " WHERE TRANSCODE=" & Sreader("utranscode") & " and barcode=N'" & Sreader("barcode").ToString.Trim & "'  and batchno=N'" & Sreader("batchno").ToString.Trim & "'")
                    End If

                End If
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
            SqlConn1.Dispose()
            SQLFcmd12.Connection = Nothing
        End Try
    End Sub
    Sub SaveTrasactions(ByVal Trancode As Single)

        Dim SqlStr As String = ""
        SqlStr = "INSERT INTO [LedgerBook] ([LedgerName],[TransCode],[InvoiceNo],[InvoiceName],[sno],[Dr],[Cr],[TransDate], " _
          & "[TransDateValue],[LedgerGroup],[AcLedger],[IsAdvance],[IsDeleted],[UserName],[StoreName],[Narration],[InvoiceType],[RefNo],[CurrencyCode],[ConRate],[CounterID]) " _
          & " VALUES (@LedgerName,@TransCode,@InvoiceNo,@InvoiceName,@sno,@Dr,@Cr,@TransDate,@TransDateValue,@LedgerGroup, " _
          & "@AcLedger,@IsAdvance,@IsDeleted,@UserName,@StoreName,@Narration,@InvoiceType,@RefNo,@CurrencyCode,@ConRate,@CounterID) "
        Dim sno As Integer = 1

        'If InvoiceCtrlType = "POS" Or InvoiceCtrlType = "SI" Or InvoiceCtrlType = "SR" Then
        If InvoiceCtrlType = "POS" Or InvoiceCtrlType = "SR" Or InvoiceCtrlType = "SI" Then
            'IF THE LEDGER ACCOUNT IS NOT CASH THEN WE NEED TO ENTRY FOR TRANSACTION ( FOR lEDGER ACCOUNT (CR) AND PAYMENT LEDGER (DR)
            If SQLIsFieldExists("select ledgername from ledgers where ledgername=N'" & txtLedgerName.Text & "' and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "')") = False And TxtPaymentMethod.Text <> "Credit" Then

                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()

                Dim DBFR2 As SqlClient.SqlCommand
                DBFR2 = New SqlClient.SqlCommand(SqlStr, MAINCON)
                With DBFR2.Parameters
                    .AddWithValue("LedgerName", txtLedgerName.Text)
                    .AddWithValue("TransCode", Trancode)
                    .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                    Select Case InvoiceCtrlType
                        Case "SO"
                            .AddWithValue("InvoiceName", "SalesOrder")
                            .AddWithValue("InvoiceType", "SalesOrder")
                        Case "SI"
                            .AddWithValue("InvoiceName", "SalesInvoice")
                            .AddWithValue("InvoiceType", "SalesInvoice")
                        Case "SQ"
                            .AddWithValue("InvoiceName", "SalesQuote")
                            .AddWithValue("InvoiceType", "SalesQuote")
                        Case "SR"
                            .AddWithValue("InvoiceName", "CreditNote")
                            .AddWithValue("InvoiceType", "CreditNote")
                        Case "SD"
                            .AddWithValue("InvoiceName", "SalesDelivery")
                            .AddWithValue("InvoiceType", "SalesDelivery")
                        Case "POS"
                            .AddWithValue("InvoiceName", "POS")
                            .AddWithValue("InvoiceType", "POS")
                    End Select

                    .AddWithValue("sno", sno)
                    sno = sno + 1
                    Select Case InvoiceCtrlType

                        Case "SI", "POS", "SD"
                            .AddWithValue("Dr", 0)
                            .AddWithValue("Cr", CDbl(TxtNetTotal.Text))
                        Case "SR"
                            .AddWithValue("Dr", CDbl(TxtNetTotal.Text))
                            .AddWithValue("Cr", 0)
                    End Select

                    .AddWithValue("TransDate", TxtDate.Value)
                    .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                    .AddWithValue("LedgerGroup", "")
                    .AddWithValue("CurrencyCode", TxtCurrency.Text)
                    .AddWithValue("ConRate", OpenedCurrencyRate)
                    .AddWithValue("AcLedger", TxtPaymentBy.Text)
                    .AddWithValue("IsAdvance", 1)
                    .AddWithValue("IsDeleted", 0)
                    .AddWithValue("UserName", CurrentUserName)
                    .AddWithValue("StoreName", DefStoreName)
                    .AddWithValue("Narration", TxtNarration.Text)
                    .AddWithValue("CounterID", CurrentCounterID)
                    .AddWithValue("RefNo", TxtRefNo.Text)
                End With
                DBFR2.ExecuteNonQuery()
                DBFR2 = Nothing



                DBFR2 = New SqlClient.SqlCommand(SqlStr, MAINCON)
                With DBFR2.Parameters
                    .AddWithValue("LedgerName", TxtPaymentBy.Text)
                    .AddWithValue("TransCode", Trancode)
                    .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                    Select Case InvoiceCtrlType
                        Case "SO"
                            .AddWithValue("InvoiceName", "SalesOrder")
                            .AddWithValue("InvoiceType", "SalesOrder")
                        Case "SI"
                            .AddWithValue("InvoiceName", "SalesInvoice")
                            .AddWithValue("InvoiceType", "SalesInvoice")
                        Case "SQ"
                            .AddWithValue("InvoiceName", "SalesQuote")
                            .AddWithValue("InvoiceType", "SalesQuote")
                        Case "SR"
                            .AddWithValue("InvoiceName", "CreditNote")
                            .AddWithValue("InvoiceType", "CreditNote")
                        Case "SD"
                            .AddWithValue("InvoiceName", "SalesDelivery")
                            .AddWithValue("InvoiceType", "SalesDelivery")
                        Case "POS"
                            .AddWithValue("InvoiceName", "POS")
                            .AddWithValue("InvoiceType", "POS")
                    End Select
                    .AddWithValue("sno", sno)
                    sno = sno + 1
                    Select Case InvoiceCtrlType

                        Case "SI", "POS", "SD"
                            .AddWithValue("Dr", CDbl(TxtNetTotal.Text))
                            .AddWithValue("Cr", 0)
                        Case "SR"
                            .AddWithValue("Dr", 0)
                            .AddWithValue("Cr", CDbl(TxtNetTotal.Text))
                    End Select
                    .AddWithValue("CurrencyCode", TxtCurrency.Text)
                    .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TxtPaymentBy.Text & "'", "currency").ToString))
                    .AddWithValue("TransDate", TxtDate.Value)
                    .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                    .AddWithValue("LedgerGroup", "")
                    .AddWithValue("AcLedger", txtLedgerName.Text)
                    .AddWithValue("IsAdvance", 1)
                    .AddWithValue("IsDeleted", 0)
                    .AddWithValue("UserName", CurrentUserName)
                    .AddWithValue("StoreName", DefStoreName)
                    .AddWithValue("Narration", TxtNarration.Text)
                    .AddWithValue("RefNo", TxtRefNo.Text)
                    .AddWithValue("CounterID", CurrentCounterID)
                End With
                DBFR2.ExecuteNonQuery()
                DBFR2 = Nothing
                MAINCON.Close()
            End If

        End If


      
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()

        Dim DBFR As SqlClient.SqlCommand
        DBFR = New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBFR.Parameters
            .AddWithValue("LedgerName", txtLedgerName.Text)
            .AddWithValue("TransCode", Trancode)
            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
            Select Case InvoiceCtrlType
                Case "SO"
                    .AddWithValue("InvoiceName", "SalesOrder")
                    .AddWithValue("InvoiceType", "SalesOrder")
                Case "SI"
                    .AddWithValue("InvoiceName", "SalesInvoice")
                    .AddWithValue("InvoiceType", "SalesInvoice")
                Case "SQ"
                    .AddWithValue("InvoiceName", "SalesQuote")
                    .AddWithValue("InvoiceType", "SalesQuote")
                Case "SR"
                    .AddWithValue("InvoiceName", "CreditNote")
                    .AddWithValue("InvoiceType", "CreditNote")
                Case "SD"
                    .AddWithValue("InvoiceName", "SalesDelivery")
                    .AddWithValue("InvoiceType", "SalesDelivery")
                Case "POS"
                    .AddWithValue("InvoiceName", "POS")
                    .AddWithValue("InvoiceType", "POS")
            End Select
            .AddWithValue("sno", sno)
            sno = sno + 1
            Select Case InvoiceCtrlType

                Case "SI", "POS", "SD"
                    .AddWithValue("Dr", CDbl(TxtNetTotal.Text))
                    .AddWithValue("Cr", 0)
                Case "SR"
                    .AddWithValue("Dr", 0)
                    .AddWithValue("Cr", CDbl(TxtNetTotal.Text))
            End Select

            .AddWithValue("TransDate", TxtDate.Value)
            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
            .AddWithValue("LedgerGroup", "")
            .AddWithValue("CurrencyCode", TxtCurrency.Text)
            .AddWithValue("ConRate", OpenedCurrencyRate)
            .AddWithValue("AcLedger", TxtSalesLedger.Text)
            .AddWithValue("IsAdvance", 1)
            .AddWithValue("IsDeleted", 0)
            .AddWithValue("UserName", CurrentUserName)
            .AddWithValue("StoreName", DefStoreName)
            .AddWithValue("Narration", TxtNarration.Text)
            .AddWithValue("CounterID", CurrentCounterID)
            .AddWithValue("RefNo", TxtRefNo.Text)
        End With
        DBFR.ExecuteNonQuery()
        DBFR = Nothing



        If TxtVoucherType.Text <> "Tax Invoice" Then
            If SQLGetNumericFieldValue("select count(*) as tot from Vatclauses where vattype='cst'", "tot") > 0 Then
                SaveCSTVatTaxes(Trancode, sno)
            End If
        ElseIf SQLGetNumericFieldValue("select count(*) as tot from Vatclauses where vattype='VAT'", "tot") > 0 Then
            SaveVatTaxes(Trancode, sno)
            SaveVatTaxes2(Trancode, sno)

        Else

            DBFR = New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBFR.Parameters
                .AddWithValue("LedgerName", TxtSalesLedger.Text)

                .AddWithValue("TransCode", Trancode)
                .AddWithValue("InvoiceNo", TxtQutoNo.Text)

                .AddWithValue("sno", sno)
                sno = sno + 1

                Select Case InvoiceCtrlType

                    Case "SI", "POS", "SD"
                        .AddWithValue("Dr", 0)
                        .AddWithValue("Cr", CDbl(TxtGrossTotal.Text))

                    Case "SR"
                        .AddWithValue("Cr", 0)
                        .AddWithValue("Dr", CDbl(TxtGrossTotal.Text))
                End Select


                .AddWithValue("CurrencyCode", TxtCurrency.Text)

                .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TxtSalesLedger.Text & "'", "currency").ToString))

                .AddWithValue("TransDate", TxtDate.Value)
                .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                .AddWithValue("LedgerGroup", "")
                .AddWithValue("AcLedger", txtLedgerName.Text)
                .AddWithValue("IsAdvance", 1)
                .AddWithValue("IsDeleted", 0)
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Narration", TxtNarration.Text)
                Select Case InvoiceCtrlType
                    Case "SO"
                        .AddWithValue("InvoiceName", "SalesOrder")
                        .AddWithValue("InvoiceType", "SalesOrder")
                    Case "SI"
                        .AddWithValue("InvoiceName", "SalesInvoice")
                        .AddWithValue("InvoiceType", "SalesInvoice")
                    Case "SQ"
                        .AddWithValue("InvoiceName", "SalesQuote")
                        .AddWithValue("InvoiceType", "SalesQuote")
                    Case "SR"
                        .AddWithValue("InvoiceName", "CreditNote")
                        .AddWithValue("InvoiceType", "CreditNote")
                    Case "SD"
                        .AddWithValue("InvoiceName", "SalesDelivery")
                        .AddWithValue("InvoiceType", "SalesDelivery")
                    Case "POS"
                        .AddWithValue("InvoiceName", "POS")
                        .AddWithValue("InvoiceType", "POS")
                End Select
                .AddWithValue("RefNo", TxtRefNo.Text)
                .AddWithValue("CounterID", CurrentCounterID)
            End With
            DBFR.ExecuteNonQuery()
            DBFR = Nothing
            '
        End If

        If CDbl(TxtServiceTaxTotal.Text) > 0 Then
            SaveServiceTaxes(Trancode, sno)
        End If

        If CDbl(TxtDiscAmt.Text) <> 0 Then
           


            Dim DBFR5 As SqlClient.SqlCommand
            DBFR5 = New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBFR5.Parameters
                .AddWithValue("LedgerName", DefLedgers.SalesDiscountLedger)
                .AddWithValue("TransCode", Trancode)
                .AddWithValue("InvoiceNo", TxtQutoNo.Text)

                Select Case InvoiceCtrlType
                    Case "SO"
                        .AddWithValue("InvoiceName", "SalesOrder")
                        .AddWithValue("InvoiceType", "SalesOrder")
                    Case "SI"
                        .AddWithValue("InvoiceName", "SalesInvoice")
                        .AddWithValue("InvoiceType", "SalesInvoice")
                    Case "SQ"
                        .AddWithValue("InvoiceName", "SalesQuote")
                        .AddWithValue("InvoiceType", "SalesQuote")
                    Case "SR"
                        .AddWithValue("InvoiceName", "CreditNote")
                        .AddWithValue("InvoiceType", "CreditNote")
                    Case "SD"
                        .AddWithValue("InvoiceName", "SalesDelivery")
                        .AddWithValue("InvoiceType", "SalesDelivery")
                    Case "POS"
                        .AddWithValue("InvoiceName", "POS")
                        .AddWithValue("InvoiceType", "POS")
                End Select
                .AddWithValue("sno", sno)
                sno = sno + 1
                If CDbl(TxtDiscAmt.Text) > 0 Then
                    .AddWithValue("Dr", 0)
                    .AddWithValue("Cr", CDbl(TxtDiscAmt.Text))
                Else
                    .AddWithValue("Dr", CDbl(TxtDiscAmt.Text) * -1)
                    .AddWithValue("Cr", 0)
                End If


                .AddWithValue("TransDate", TxtDate.Value)
                .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                .AddWithValue("LedgerGroup", "")
                .AddWithValue("CurrencyCode", CompDetails.Currency)
                .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & DefLedgers.SalesDiscountLedger & "'", "currency").ToString))
                .AddWithValue("AcLedger", txtLedgerName.Text)
                .AddWithValue("IsAdvance", 1)
                .AddWithValue("IsDeleted", 0)
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Narration", TxtNarration.Text)
                .AddWithValue("RefNo", TxtQutoNo.Text)
                .AddWithValue("CounterID", CurrentCounterID)
            End With
            DBFR5.ExecuteNonQuery()
            DBFR5 = Nothing
        End If
        'FOR ADVANCE PAYMENT LEDGER ALLOCATION
        If CDbl(TxtAdvancePayment.Text) > 0 Then
          

            'CUSTOMER LEDGER ALLOCATION
            Dim DBFR56 As SqlClient.SqlCommand
            DBFR56 = New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBFR56.Parameters
                .AddWithValue("LedgerName", txtLedgerName.Text)
                .AddWithValue("TransCode", Trancode)
                .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                Select Case InvoiceCtrlType
                    Case "SO"
                        .AddWithValue("InvoiceName", "SalesOrder")
                        .AddWithValue("InvoiceType", "SalesOrder")
                    Case "SI"
                        .AddWithValue("InvoiceName", "SalesInvoice")
                        .AddWithValue("InvoiceType", "SalesInvoice")
                    Case "SQ"
                        .AddWithValue("InvoiceName", "SalesQuote")
                        .AddWithValue("InvoiceType", "SalesQuote")
                    Case "SR"
                        .AddWithValue("InvoiceName", "CreditNote")
                        .AddWithValue("InvoiceType", "CreditNote")
                    Case "SD"
                        .AddWithValue("InvoiceName", "SalesDelivery")
                        .AddWithValue("InvoiceType", "SalesDelivery")
                    Case "POS"
                        .AddWithValue("InvoiceName", "POS")
                        .AddWithValue("InvoiceType", "POS")
                End Select
                .AddWithValue("sno", sno)
                sno = sno + 1
                Select Case InvoiceCtrlType

                    Case "SI", "POS", "SD"
                        .AddWithValue("Dr", 0)
                        .AddWithValue("Cr", CDbl(TxtAdvancePayment.Text))
                    Case "SR"
                        .AddWithValue("Dr", CDbl(TxtAdvancePayment.Text))
                        .AddWithValue("Cr", 0)
                End Select

                .AddWithValue("TransDate", TxtDate.Value)
                .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                .AddWithValue("LedgerGroup", "")
                .AddWithValue("CurrencyCode", CompDetails.Currency)
                .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & txtLedgerName.Text & "'", "currency").ToString))
                .AddWithValue("AcLedger", TxtSalesLedger.Text)
                .AddWithValue("IsAdvance", 1)
                .AddWithValue("IsDeleted", 0)
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Narration", "Advance Payment Received From Customer")
                .AddWithValue("RefNo", TxtQutoNo.Text)
                .AddWithValue("CounterID", CurrentCounterID)
            End With
            DBFR56.ExecuteNonQuery()
            DBFR56 = Nothing

            'LEDGER BOOK FOR CASH ALLOCATION
            Dim DBFR57 As SqlClient.SqlCommand
            DBFR57 = New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBFR57.Parameters
                .AddWithValue("LedgerName", DefLedgers.CashAccount)
                .AddWithValue("TransCode", Trancode)
                .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                Select Case InvoiceCtrlType
                    Case "SO"
                        .AddWithValue("InvoiceName", "SalesOrder")
                        .AddWithValue("InvoiceType", "SalesOrder")
                    Case "SI"
                        .AddWithValue("InvoiceName", "SalesInvoice")
                        .AddWithValue("InvoiceType", "SalesInvoice")
                    Case "SQ"
                        .AddWithValue("InvoiceName", "SalesQuote")
                        .AddWithValue("InvoiceType", "SalesQuote")
                    Case "SR"
                        .AddWithValue("InvoiceName", "CreditNote")
                        .AddWithValue("InvoiceType", "CreditNote")
                    Case "SD"
                        .AddWithValue("InvoiceName", "SalesDelivery")
                        .AddWithValue("InvoiceType", "SalesDelivery")
                    Case "POS"
                        .AddWithValue("InvoiceName", "POS")
                        .AddWithValue("InvoiceType", "POS")
                End Select
                .AddWithValue("sno", sno)
                sno = sno + 1
                Select Case InvoiceCtrlType

                    Case "SI", "POS", "SD"
                        .AddWithValue("Dr", CDbl(TxtAdvancePayment.Text))
                        .AddWithValue("Cr", 0)
                    Case "SR"
                        .AddWithValue("Dr", 0)
                        .AddWithValue("Cr", CDbl(TxtAdvancePayment.Text))
                End Select

                .AddWithValue("TransDate", TxtDate.Value)
                .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                .AddWithValue("LedgerGroup", "")
                .AddWithValue("CurrencyCode", CompDetails.Currency)
                .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & DefLedgers.CashAccount & "'", "currency").ToString))
                .AddWithValue("AcLedger", txtLedgerName.Text)
                .AddWithValue("IsAdvance", 1)
                .AddWithValue("IsDeleted", 0)
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Narration", "Advance Payment Received From Customer")
                .AddWithValue("RefNo", TxtQutoNo.Text)
                .AddWithValue("CounterID", CurrentCounterID)
            End With
            DBFR57.ExecuteNonQuery()
            DBFR57 = Nothing
        End If

        If TxtLedgerAmount1.Text.Length = 0 Then
            TxtLedgerAmount1.Text = "0"
        End If



        If TxtRoundoff <> 0 And DefLedgers.RoundOffLeder.Length > 0 Then
          

            Dim DBFR5 As SqlClient.SqlCommand
            DBFR5 = New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBFR5.Parameters
                .AddWithValue("LedgerName", DefLedgers.RoundOffLeder)
                .AddWithValue("TransCode", Trancode)
                .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                .AddWithValue("InvoiceName", "SalesInvoice")
                .AddWithValue("InvoiceType", "SalesInvoice")
                .AddWithValue("sno", sno)
                sno = sno + 1
                If TxtRoundoff > 0 Then
                    .AddWithValue("Dr", 0)
                    .AddWithValue("Cr", TxtRoundoff)
                Else
                    .AddWithValue("Dr", TxtRoundoff * -1)
                    .AddWithValue("Cr", 0)
                End If

                .AddWithValue("TransDate", TxtDate.Value.Date)
                .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                .AddWithValue("LedgerGroup", "")
                .AddWithValue("CurrencyCode", CompDetails.Currency)
                .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & DefLedgers.RoundOffLeder & "'", "currency").ToString))
                .AddWithValue("AcLedger", TxtSalesLedger.Text)
                .AddWithValue("IsAdvance", 1)
                .AddWithValue("IsDeleted", 0)
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Narration", TxtNarration.Text)
                .AddWithValue("RefNo", TxtQutoNo.Text)
                .AddWithValue("CounterID", CurrentCounterID)
            End With
            DBFR5.ExecuteNonQuery()
            DBFR5 = Nothing
        End If

        If TxtDrCr1.Text.Length > 0 And TxtLedgerName1.Text.Length > 0 And CDbl(TxtLedgerAmount1.Text) > 0 Then
            DBFR = New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBFR.Parameters
                .AddWithValue("LedgerName", TxtLedgerName1.Text)
                .AddWithValue("TransCode", Trancode)
                .AddWithValue("InvoiceNo", TxtQutoNo.Text)

                .AddWithValue("sno", sno)
                sno = sno + 1
                If TxtDrCr1.Text = "Dr" Then
                    .AddWithValue("Dr", CDbl(TxtLedgerAmount1.Text))
                    .AddWithValue("Cr", 0)
                Else
                    .AddWithValue("Dr", 0)
                    .AddWithValue("Cr", CDbl(TxtLedgerAmount1.Text))
                End If
                .AddWithValue("CurrencyCode", TxtCurrency.Text)
                .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TxtLedgerName1.Text & "'", "currency").ToString))
                .AddWithValue("TransDate", TxtDate.Value)
                .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                .AddWithValue("LedgerGroup", "")
                .AddWithValue("AcLedger", TxtSalesLedger.Text)
                .AddWithValue("IsAdvance", 1)
                .AddWithValue("IsDeleted", 0)
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Narration", TxtNarration.Text)
                Select Case InvoiceCtrlType
                    Case "SO"
                        .AddWithValue("InvoiceName", "SalesOrder")
                        .AddWithValue("InvoiceType", "SalesOrder")
                    Case "SI"
                        .AddWithValue("InvoiceName", "SalesInvoice")
                        .AddWithValue("InvoiceType", "SalesInvoice")
                    Case "SQ"
                        .AddWithValue("InvoiceName", "SalesQuote")
                        .AddWithValue("InvoiceType", "SalesQuote")
                    Case "SR"
                        .AddWithValue("InvoiceName", "CreditNote")
                        .AddWithValue("InvoiceType", "CreditNote")
                    Case "SD"
                        .AddWithValue("InvoiceName", "SalesDelivery")
                        .AddWithValue("InvoiceType", "SalesDelivery")
                    Case "POS"
                        .AddWithValue("InvoiceName", "POS")
                        .AddWithValue("InvoiceType", "POS")
                End Select
                .AddWithValue("RefNo", TxtRefNo.Text)
                .AddWithValue("CounterID", CurrentCounterID)
            End With
            DBFR.ExecuteNonQuery()
            DBFR = Nothing

        End If
        If TxtLedgerAmount2.Text.Length = 0 Then
            TxtLedgerAmount2.Text = "0"
        End If
        If TxtDrCr2.Text.Length > 0 And TxtLedgerName2.Text.Length > 0 And CDbl(TxtLedgerAmount2.Text) > 0 Then
            DBFR = New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBFR.Parameters
                .AddWithValue("LedgerName", TxtLedgerName2.Text)
                .AddWithValue("TransCode", Trancode)
                .AddWithValue("InvoiceNo", TxtQutoNo.Text)

                .AddWithValue("sno", sno)
                sno = sno + 1
                If TxtDrCr2.Text = "Dr" Then
                    .AddWithValue("Dr", CDbl(TxtLedgerAmount2.Text))
                    .AddWithValue("Cr", 0)
                Else
                    .AddWithValue("Dr", 0)
                    .AddWithValue("Cr", CDbl(TxtLedgerAmount2.Text))
                End If
                .AddWithValue("CurrencyCode", TxtCurrency.Text)
                .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TxtLedgerName2.Text & "'", "currency").ToString))
                .AddWithValue("TransDate", TxtDate.Value)
                .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                .AddWithValue("LedgerGroup", "")
                .AddWithValue("AcLedger", TxtSalesLedger.Text)
                .AddWithValue("IsAdvance", 1)
                .AddWithValue("IsDeleted", 0)
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Narration", TxtNarration.Text)
                Select Case InvoiceCtrlType
                    Case "SO"
                        .AddWithValue("InvoiceName", "SalesOrder")
                        .AddWithValue("InvoiceType", "SalesOrder")
                    Case "SI"
                        .AddWithValue("InvoiceName", "SalesInvoice")
                        .AddWithValue("InvoiceType", "SalesInvoice")
                    Case "SQ"
                        .AddWithValue("InvoiceName", "SalesQuote")
                        .AddWithValue("InvoiceType", "SalesQuote")
                    Case "SR"
                        .AddWithValue("InvoiceName", "CreditNote")
                        .AddWithValue("InvoiceType", "CreditNote")
                    Case "SD"
                        .AddWithValue("InvoiceName", "SalesDelivery")
                        .AddWithValue("InvoiceType", "SalesDelivery")
                    Case "POS"
                        .AddWithValue("InvoiceName", "POS")
                        .AddWithValue("InvoiceType", "POS")
                End Select
                .AddWithValue("RefNo", TxtRefNo.Text)
                .AddWithValue("CounterID", CurrentCounterID)
            End With
            DBFR.ExecuteNonQuery()
            DBFR = Nothing
        End If

        If TxtLedgerAmount3.Text.Length = 0 Then
            TxtLedgerAmount3.Text = "0"
        End If
        If TxtDrCr3.Text.Length > 0 And TxtLedgerName3.Text.Length > 0 And CDbl(TxtLedgerAmount3.Text) > 0 Then
            DBFR = New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBFR.Parameters
                .AddWithValue("LedgerName", TxtLedgerName3.Text)
                .AddWithValue("TransCode", Trancode)
                .AddWithValue("InvoiceNo", TxtQutoNo.Text)

                .AddWithValue("sno", sno)
                sno = sno + 1
                If TxtDrCr3.Text = "Dr" Then
                    .AddWithValue("Dr", CDbl(TxtLedgerAmount3.Text))
                    .AddWithValue("Cr", 0)
                Else
                    .AddWithValue("Dr", 0)
                    .AddWithValue("Cr", CDbl(TxtLedgerAmount3.Text))
                End If
                .AddWithValue("CurrencyCode", TxtCurrency.Text)
                .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TxtLedgerName3.Text & "'", "currency").ToString))
                .AddWithValue("TransDate", TxtDate.Value)
                .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                .AddWithValue("LedgerGroup", "")
                .AddWithValue("AcLedger", TxtSalesLedger.Text)
                .AddWithValue("IsAdvance", 1)
                .AddWithValue("IsDeleted", 0)
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Narration", TxtNarration.Text)
                Select Case InvoiceCtrlType
                    Case "SO"
                        .AddWithValue("InvoiceName", "SalesOrder")
                        .AddWithValue("InvoiceType", "SalesOrder")
                    Case "SI"
                        .AddWithValue("InvoiceName", "SalesInvoice")
                        .AddWithValue("InvoiceType", "SalesInvoice")
                    Case "SQ"
                        .AddWithValue("InvoiceName", "SalesQuote")
                        .AddWithValue("InvoiceType", "SalesQuote")
                    Case "SR"
                        .AddWithValue("InvoiceName", "CreditNote")
                        .AddWithValue("InvoiceType", "CreditNote")
                    Case "SD"
                        .AddWithValue("InvoiceName", "SalesDelivery")
                        .AddWithValue("InvoiceType", "SalesDelivery")
                    Case "POS"
                        .AddWithValue("InvoiceName", "POS")
                        .AddWithValue("InvoiceType", "POS")
                End Select
                .AddWithValue("RefNo", TxtRefNo.Text)
                .AddWithValue("CounterID", CurrentCounterID)
            End With
            DBFR.ExecuteNonQuery()
            DBFR = Nothing
        End If
        'FOR ADVANCE PAYMENT 


        MAINCON.Close()
        ' ExecuteSQLQuery("UPDATE LEDGERS SET currentbalance=currentbalance+" & CDbl(TxtNetTotal.Text) & "  where LedgerName=N'" & txtLedgerName.Text & "'")

    End Sub
    Sub SaveServiceTaxes(ByVal Tcode As Double, ByRef sno As Integer)
        Dim Sqlstr As String = ""
        Sqlstr = "INSERT INTO [LedgerBook] ([LedgerName],[TransCode],[InvoiceNo],[InvoiceName],[sno],[Dr],[Cr],[TransDate], " _
         & "[TransDateValue],[LedgerGroup],[AcLedger],[IsAdvance],[IsDeleted],[UserName],[StoreName],[Narration],[InvoiceType],[RefNo],[CurrencyCode],[ConRate],CounterID) " _
         & " VALUES (@LedgerName,@TransCode,@InvoiceNo,@InvoiceName,@sno,@Dr,@Cr,@TransDate,@TransDateValue,@LedgerGroup, " _
         & "@AcLedger,@IsAdvance,@IsDeleted,@UserName,@StoreName,@Narration,@InvoiceType,@RefNo,@CurrencyCode,@ConRate,@CounterID) "

        Dim SqlConn2 As New SqlClient.SqlConnection
        Dim Sqlcmmd2 As New SqlClient.SqlCommand
        Dim TempLedgerName As String = ""
        Try
            SqlConn2.ConnectionString = ConnectionStrinG
            SqlConn2.Open()
            Sqlcmmd2.Connection = SqlConn2
            Sqlcmmd2.CommandText = "SELECT Servicetax,sum(stockamount) as samt, SUM(TAXAMOUNT) AS TAMT FROM StockInvoiceRowItems WHERE TRANSCODE=" & Tcode & " GROUP BY Servicetax "
            Sqlcmmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd2.ExecuteReader
            While Sreader.Read()
                ' for zero tax , no need to update for input and output vat ledgers
                TempLedgerName = SQLGetStringFieldValue("select inputvatledger from vatclauses where vattype='Service Tax' and vattax=" & Sreader("Servicetax"), "inputvatledger")
                Dim DBFR As SqlClient.SqlCommand
                DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                With DBFR.Parameters
                    .AddWithValue("LedgerName", TempLedgerName)
                    .AddWithValue("TransCode", Tcode)
                    .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                    .AddWithValue("sno", sno)
                    sno = sno + 1
                    .AddWithValue("Dr", 0)
                    .AddWithValue("Cr", Sreader("samt") * Sreader("servicetax") / 100)
                    .AddWithValue("CurrencyCode", CompDetails.Currency)
                    .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                    .AddWithValue("TransDate", TxtDate.Value)
                    .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                    .AddWithValue("LedgerGroup", "")
                    .AddWithValue("AcLedger", txtLedgerName.Text)
                    .AddWithValue("IsAdvance", 1)
                    .AddWithValue("IsDeleted", 0)
                    .AddWithValue("UserName", CurrentUserName)
                    .AddWithValue("StoreName", DefStoreName)
                    .AddWithValue("Narration", TxtNarration.Text)
                    .AddWithValue("InvoiceName", "SalesInvoice")
                    .AddWithValue("InvoiceType", "SalesInvoice")
                    .AddWithValue("RefNo", TxtQutoNo.Text)
                    .AddWithValue("CounterID", CurrentCounterID)
                End With
                DBFR.ExecuteNonQuery()
                DBFR = Nothing

            End While

            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn2.Close()
            SqlConn2.Dispose()
            Sqlcmmd2.Connection = Nothing
        End Try
    End Sub
    Sub SaveVatTaxes(ByVal Tcode As Double, ByRef sno As Integer)
        Dim Sqlstr As String = ""
        Sqlstr = "INSERT INTO [LedgerBook] ([LedgerName],[TransCode],[InvoiceNo],[InvoiceName],[sno],[Dr],[Cr],[TransDate], " _
         & "[TransDateValue],[LedgerGroup],[AcLedger],[IsAdvance],[IsDeleted],[UserName],[StoreName],[Narration],[InvoiceType],[RefNo],[CurrencyCode],[ConRate],CounterID) " _
         & " VALUES (@LedgerName,@TransCode,@InvoiceNo,@InvoiceName,@sno,@Dr,@Cr,@TransDate,@TransDateValue,@LedgerGroup, " _
         & "@AcLedger,@IsAdvance,@IsDeleted,@UserName,@StoreName,@Narration,@InvoiceType,@RefNo,@CurrencyCode,@ConRate,@CounterID) "

        Dim SqlConn2 As New SqlClient.SqlConnection
        Dim Sqlcmmd2 As New SqlClient.SqlCommand
        Dim TempLedgerName As String = ""
        Try
            SqlConn2.ConnectionString = ConnectionStrinG
            SqlConn2.Open()
            Sqlcmmd2.Connection = SqlConn2
            Sqlcmmd2.CommandText = "SELECT TAX,sum(stockamount) as samt, SUM(TAXAMOUNT) AS TAMT FROM StockInvoiceRowItems WHERE TRANSCODE=" & Tcode & " GROUP BY TAX "
            Sqlcmmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd2.ExecuteReader
            While Sreader.Read()
                ' for zero tax , no need to update for input and output vat ledgers
                If Sreader("tax") = 0 Then
                    If InvoiceCtrlType = "PI" Or InvoiceCtrlType = "DP" Then
                        ' for purchase ledgers
                        TempLedgerName = SQLGetStringFieldValue("select PurchaseLedger from vatclauses where vattax=0 and vattype='VAT'", "PurchaseLedger")
                        Dim DBFR As SqlClient.SqlCommand
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing
                    ElseIf InvoiceCtrlType = "PR" Then
                        TempLedgerName = SQLGetStringFieldValue("select DebitNoteLedger from vatclauses where vattax=0 and vattype='VAT'", "DebitNoteLedger")
                        Dim DBFR As SqlClient.SqlCommand
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing
                    ElseIf InvoiceCtrlType = "SI" Or InvoiceCtrlType = "POS" Then
                        TempLedgerName = SQLGetStringFieldValue("select SalesLedger from vatclauses where vattax=0 and vattype='VAT'", "SalesLedger")
                        Dim DBFR As SqlClient.SqlCommand
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing
                    ElseIf InvoiceCtrlType = "SR" Then
                        TempLedgerName = SQLGetStringFieldValue("select CreditLedger from vatclauses where vattax=0 and vattype='VAT'", "CreditLedger")
                        Dim DBFR As SqlClient.SqlCommand
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing
                    End If


                Else
                    ' you need to update for input and output as well as purchase/sales ledgers for each tax
                    If InvoiceCtrlType = "PI" Or InvoiceCtrlType = "DP" Then
                        ' for purchase ledgers
                        TempLedgerName = SQLGetStringFieldValue("select PurchaseLedger from vatclauses where   vattype='VAT' and vattax=" & Sreader("tax"), "PurchaseLedger")
                        Dim DBFR As SqlClient.SqlCommand
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing

                        ' for input vat or output vat ledges positing
                        TempLedgerName = SQLGetStringFieldValue("select inputvatledger from vatclauses where  vattype='VAT' and vattax=" & Sreader("tax"), "inputvatledger")
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing

                    ElseIf InvoiceCtrlType = "PR" Then
                        TempLedgerName = SQLGetStringFieldValue("select DebitNoteLedger from vatclauses where  vattype='VAT' and vattax=" & Sreader("tax"), "DebitNoteLedger")
                        Dim DBFR As SqlClient.SqlCommand
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing


                        ' for input vat or output vat ledges positing
                        TempLedgerName = SQLGetStringFieldValue("select inputvatledger from vatclauses where  vattype='VAT' and vattax=" & Sreader("tax"), "inputvatledger")
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing

                    ElseIf InvoiceCtrlType = "SI" Or InvoiceCtrlType = "POS" Then
                        TempLedgerName = SQLGetStringFieldValue("select SalesLedger from vatclauses where  vattype='VAT' and vattax=" & Sreader("tax"), "SalesLedger")
                        Dim DBFR As SqlClient.SqlCommand
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing



                        ' for input vat or output vat ledges positing
                        TempLedgerName = SQLGetStringFieldValue("select outputvatledger from vatclauses where  vattype='VAT' and  vattax=" & Sreader("tax"), "outputvatledger")
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing

                    ElseIf InvoiceCtrlType = "SR" Then
                        TempLedgerName = SQLGetStringFieldValue("select CreditLedger from vatclauses where  vattype='VAT' and  vattax=" & Sreader("tax"), "CreditLedger")
                        Dim DBFR As SqlClient.SqlCommand
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing



                        ' for input vat or output vat ledges positing
                        TempLedgerName = SQLGetStringFieldValue("select outputvatledger from vatclauses where  vattype='VAT' and  vattax=" & Sreader("tax"), "outputvatledger")
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing

                    End If

                End If

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn2.Close()
            SqlConn2.Dispose()
            Sqlcmmd2.Connection = Nothing
        End Try

    End Sub
    Sub SaveCSTVatTaxes(ByVal Tcode As Double, ByRef sno As Integer)
        Dim Sqlstr As String = ""
        Sqlstr = "INSERT INTO [LedgerBook] ([LedgerName],[TransCode],[InvoiceNo],[InvoiceName],[sno],[Dr],[Cr],[TransDate], " _
         & "[TransDateValue],[LedgerGroup],[AcLedger],[IsAdvance],[IsDeleted],[UserName],[StoreName],[Narration],[InvoiceType],[RefNo],[CurrencyCode],[ConRate],CounterID) " _
         & " VALUES (@LedgerName,@TransCode,@InvoiceNo,@InvoiceName,@sno,@Dr,@Cr,@TransDate,@TransDateValue,@LedgerGroup, " _
         & "@AcLedger,@IsAdvance,@IsDeleted,@UserName,@StoreName,@Narration,@InvoiceType,@RefNo,@CurrencyCode,@ConRate,@CounterID) "

        Dim SqlConn2 As New SqlClient.SqlConnection
        Dim Sqlcmmd2 As New SqlClient.SqlCommand
        Dim TempLedgerName As String = ""
        Try
            SqlConn2.ConnectionString = ConnectionStrinG
            SqlConn2.Open()
            Sqlcmmd2.Connection = SqlConn2
            Sqlcmmd2.CommandText = "SELECT TAX,sum(stockamount) as samt, SUM(TAXAMOUNT) AS TAMT FROM StockInvoiceRowItems WHERE TRANSCODE=" & Tcode & " GROUP BY TAX "
            Sqlcmmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd2.ExecuteReader
            While Sreader.Read()
                ' for zero tax , no need to update for input and output vat ledgers
                If Sreader("tax") = 0 Then
                    If InvoiceCtrlType = "PI" Or InvoiceCtrlType = "DP" Then
                        ' for purchase ledgers
                        TempLedgerName = SQLGetStringFieldValue("select PurchaseLedger from vatclauses where vattax=0 and vattype='CST'", "PurchaseLedger")
                        Dim DBFR As SqlClient.SqlCommand
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing
                    ElseIf InvoiceCtrlType = "PR" Then
                        TempLedgerName = SQLGetStringFieldValue("select DebitNoteLedger from vatclauses where vattax=0 and vattype='CST'", "DebitNoteLedger")
                        Dim DBFR As SqlClient.SqlCommand
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing
                    ElseIf InvoiceCtrlType = "SI" Or InvoiceCtrlType = "POS" Then
                        TempLedgerName = SQLGetStringFieldValue("select SalesLedger from vatclauses where vattax=0 and vattype='CST'", "SalesLedger")
                        Dim DBFR As SqlClient.SqlCommand
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing
                    ElseIf InvoiceCtrlType = "SR" Then
                        TempLedgerName = SQLGetStringFieldValue("select CreditLedger from vatclauses where vattax=0 and vattype='CST'", "CreditLedger")
                        Dim DBFR As SqlClient.SqlCommand
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing
                    End If


                Else
                    ' you need to update for input and output as well as purchase/sales ledgers for each tax
                    If InvoiceCtrlType = "PI" Or InvoiceCtrlType = "DP" Then
                        ' for purchase ledgers
                        TempLedgerName = SQLGetStringFieldValue("select PurchaseLedger from vatclauses where   vattype='CST' and vattax=" & Sreader("tax"), "PurchaseLedger")
                        Dim DBFR As SqlClient.SqlCommand
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing

                        ' for input vat or output vat ledges positing
                        TempLedgerName = SQLGetStringFieldValue("select inputvatledger from vatclauses where  vattype='CST' and vattax=" & Sreader("tax"), "inputvatledger")
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing

                    ElseIf InvoiceCtrlType = "PR" Then
                        TempLedgerName = SQLGetStringFieldValue("select DebitNoteLedger from vatclauses where  vattype='CST' and vattax=" & Sreader("tax"), "DebitNoteLedger")
                        Dim DBFR As SqlClient.SqlCommand
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing


                        ' for input vat or output vat ledges positing
                        TempLedgerName = SQLGetStringFieldValue("select inputvatledger from vatclauses where  vattype='CST' and vattax=" & Sreader("tax"), "inputvatledger")
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing

                    ElseIf InvoiceCtrlType = "SI" Or InvoiceCtrlType = "POS" Then
                        TempLedgerName = SQLGetStringFieldValue("select SalesLedger from vatclauses where  vattype='CST' and vattax=" & Sreader("tax"), "SalesLedger")
                        Dim DBFR As SqlClient.SqlCommand
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing



                        ' for input vat or output vat ledges positing
                        TempLedgerName = SQLGetStringFieldValue("select outputvatledger from vatclauses where  vattype='CST' and  vattax=" & Sreader("tax"), "outputvatledger")
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing

                    ElseIf InvoiceCtrlType = "SR" Then
                        TempLedgerName = SQLGetStringFieldValue("select CreditLedger from vatclauses where  vattype='CST' and  vattax=" & Sreader("tax"), "CreditLedger")
                        Dim DBFR As SqlClient.SqlCommand
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("samt"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("samt"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing



                        ' for input vat or output vat ledges positing
                        TempLedgerName = SQLGetStringFieldValue("select outputvatledger from vatclauses where  vattype='CST' and  vattax=" & Sreader("tax"), "outputvatledger")
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing

                    End If

                End If

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn2.Close()
            SqlConn2.Dispose()
            Sqlcmmd2.Connection = Nothing
        End Try

    End Sub
    Sub SaveVatTaxes2(ByVal Tcode As Double, ByRef sno As Integer)
        Dim Sqlstr As String = ""
        Sqlstr = "INSERT INTO [LedgerBook] ([LedgerName],[TransCode],[InvoiceNo],[InvoiceName],[sno],[Dr],[Cr],[TransDate], " _
         & "[TransDateValue],[LedgerGroup],[AcLedger],[IsAdvance],[IsDeleted],[UserName],[StoreName],[Narration],[InvoiceType],[RefNo],[CurrencyCode],[ConRate],[CounterID]) " _
         & " VALUES (@LedgerName,@TransCode,@InvoiceNo,@InvoiceName,@sno,@Dr,@Cr,@TransDate,@TransDateValue,@LedgerGroup, " _
         & "@AcLedger,@IsAdvance,@IsDeleted,@UserName,@StoreName,@Narration,@InvoiceType,@RefNo,@CurrencyCode,@ConRate,@CounterID) "

        Dim SqlConn2 As New SqlClient.SqlConnection
        Dim Sqlcmmd2 As New SqlClient.SqlCommand
        Dim TempLedgerName As String = ""
        Try
            SqlConn2.ConnectionString = ConnectionStrinG
            SqlConn2.Open()
            Sqlcmmd2.Connection = SqlConn2
            Sqlcmmd2.CommandText = "SELECT TAX2, SUM(TAXAMOUNT2) AS TAMT FROM StockInvoiceRowItems WHERE TRANSCODE=" & Tcode & " GROUP BY tax2 "
            Sqlcmmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd2.ExecuteReader
            While Sreader.Read()
                ' for zero tax2 , no need to update for input and output vat ledgers
                If Sreader("tax2") > 0 Then



                    ' you need to update for input and output  for each tax2
                    If InvoiceCtrlType = "PI" Or InvoiceCtrlType = "DP" Then


                        Dim DBFR As SqlClient.SqlCommand


                        ' for input vat or output vat ledges positing
                        TempLedgerName = SQLGetStringFieldValue("select inputvatledger from vatclauses where  vattype='VAT' and vattax=" & Sreader("tax2"), "inputvatledger")
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing

                    ElseIf InvoiceCtrlType = "PR" Then

                        Dim DBFR As SqlClient.SqlCommand

                        ' for input vat or output vat ledges positing
                        TempLedgerName = SQLGetStringFieldValue("select inputvatledger from vatclauses where  vattype='VAT' and vattax=" & Sreader("tax2"), "inputvatledger")
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing

                    ElseIf InvoiceCtrlType = "SI" Or InvoiceCtrlType = "POS" Then

                        Dim DBFR As SqlClient.SqlCommand

                        ' for input vat or output vat ledges positing
                        TempLedgerName = SQLGetStringFieldValue("select outputvatledger from vatclauses where  vattype='VAT' and  vattax=" & Sreader("tax2"), "outputvatledger")
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing

                    ElseIf InvoiceCtrlType = "SR" Then

                        Dim DBFR As SqlClient.SqlCommand



                        ' for input vat or output vat ledges positing
                        TempLedgerName = SQLGetStringFieldValue("select outputvatledger from vatclauses where  vattype='VAT' and  vattax=" & Sreader("tax2"), "outputvatledger")
                        DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                        With DBFR.Parameters
                            .AddWithValue("LedgerName", TempLedgerName)
                            .AddWithValue("TransCode", Tcode)
                            .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                            .AddWithValue("sno", sno)
                            sno = sno + 1
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                                Case "PR"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SI", "POS"
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", Sreader("TAMT"))
                                Case "SR"
                                    .AddWithValue("Dr", Sreader("TAMT"))
                                    .AddWithValue("Cr", 0)
                            End Select
                            .AddWithValue("CurrencyCode", TxtCurrency.Text)
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TempLedgerName & "'", "currency").ToString))
                            .AddWithValue("TransDate", TxtDate.Value)
                            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", txtLedgerName.Text)
                            .AddWithValue("IsAdvance", 1)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", TxtNarration.Text)
                            Select Case InvoiceCtrlType
                                Case "PI", "DP"
                                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                                Case "PR"
                                    .AddWithValue("InvoiceName", "DebitNote")
                                    .AddWithValue("InvoiceType", "DebitNote")
                                Case "SI", "POS"
                                    .AddWithValue("InvoiceName", "SalesInvoice")
                                    .AddWithValue("InvoiceType", "SalesInvoice")
                                Case "SR"
                                    .AddWithValue("InvoiceName", "CreditNote")
                                    .AddWithValue("InvoiceType", "CreditNote")
                            End Select
                            .AddWithValue("RefNo", TxtRefNo.Text)
                            .AddWithValue("CounterID", CurrentCounterID)
                        End With
                        DBFR.ExecuteNonQuery()
                        DBFR = Nothing

                    End If

                End If

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn2.Close()
            SqlConn2.Dispose()
            Sqlcmmd2.Connection = Nothing
        End Try

    End Sub
    Sub RollBackStockQuantities()

        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SqlFcmd As New SqlClient.SqlCommand
            SqlFcmd.Connection = SqlConn1
            SqlFcmd.CommandText = "select stockcode,stocksize,batchno,location,barcode,TotalQty from StockInvoiceRowItems where transcode=" & OpenedTranscode & " order by sno"
            SqlFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SqlFcmd.ExecuteReader
            While Sreader.Read()
                ExecuteSQLQuery("exec UpdateStockQty N'" & Sreader("location").ToString.Trim & "',N'" & Sreader("stockcode").ToString.Trim & "',N'" & Sreader("stocksize").ToString.Trim & "',N'" & Sreader("batchno").ToString.Trim & "'")
                ExecuteSQLQuery("EXEC proInventoryCosting N'" & Sreader("location").ToString.Trim & "',N'" & Sreader("stockcode").ToString.Trim & "',N'" & Sreader("stocksize").ToString.Trim & "'," & UpdateQuantityForNon_StockAlso)
                ExecuteSQLQuery("exec UpdateBatchStockQty N'" & Sreader("location").ToString.Trim & "',N'" & Sreader("stockcode").ToString.Trim & "',N'" & Sreader("stocksize").ToString.Trim & "',N'" & Sreader("batchno").ToString.Trim & "'")

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
            SqlConn1.Dispose()
            SQLFcmd.Connection = Nothing
        End Try

        'nettotal,StockInvoiceDetails

    End Sub
    Sub RollBackAccounts()
        OpenedPDCValues = GetPDCValues(OpenedTranscode)
        ExecuteSQLQuery("delete from LEDGERBOOK where transcode=" & OpenedTranscode)
        ExecuteSQLQuery("delete from bill2bill where billtype='New' and transcode=" & OpenedTranscode)
    End Sub
    Sub SaveMasterData()
        Dim SqlStr As String = ""
        Try
         
            SqlStr = "INSERT INTO [StockInvoiceDetails] ([TransCode],[TransDate],[TransDateValue],[QutoNo],[QutoRef],[OrderNo],[OrderRef],[DNoteno]," _
                & "[DnoteRef],[StoreName],[Currency],[PriceList],[SalesPerson],[ProjectName],[Area],[LedgerName],[LedgerAddress],[IsCommit]," _
                & "[IsDelete],[IsPending],[subtotal],[grosstotal],[discountper],[nettotal],[taxtotal],[InvoiceTotal],[AccountTotal]," _
                & "[amountinwords],[narration],[InvoiceNo],[InvoiceRef],[GoodNo],[GoodRef],[CurrencyCon1],[VoucherName],[DelivaryDate],[DelivaryDateValue],[Additions],[Deductions],[PaymentMethod],[PaymentLedger], " _
                & " [PaymentDetails],[AccountLedgerName],[servicetaxtotal],[roundoff],[surcharge],[DiscPer],[CurrencyCon2],[BillCurrency],[CouponName],[CDiscount],[CDisCountPer],[transtype],[taxtotal2],[cstamount],[VoucherType],[AdvancePayment],[customername],[CounterId],IsMultiPayment,BillType,CashReceived,CashtoPay) " _
                & "VALUES (@TransCode,@TransDate,@TransDateValue,@QutoNo,@QutoRef,@OrderNo,@OrderRef,@DNoteno,@DnoteRef,@StoreName,@Currency," _
                & "@PriceList,@SalesPerson,@ProjectName,@Area,@LedgerName,@LedgerAddress,@IsCommit,@IsDelete,@IsPending,@subtotal,@grosstotal," _
                & "@discountper,@nettotal,@taxtotal,@InvoiceTotal,@AccountTotal,@amountinwords,@narration,@InvoiceNo,@InvoiceRef,@GoodNo,@GoodRef,@CurrencyCon1,@VoucherName," _
                & "@DelivaryDate,@DelivaryDateValue,@Additions,@Deductions,@PaymentMethod,@PaymentLedger,@PaymentDetails,@AccountLedgerName, " _
                & " @servicetaxtotal,@roundoff,@surcharge,@DiscPer,@CurrencyCon2,@BillCurrency,@CouponName,@CDiscount,@CDisCountPer,@transtype,@taxtotal2,@cstamount,@VoucherType,@AdvancePayment,@customername,@CounterId,@IsMultiPayment,@BillType,@CashReceived,@CashtoPay)"


            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBF.Parameters
                .AddWithValue("TransCode", OpenedTranscode)
                .AddWithValue("TransDate", TxtDate.Value)
                .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                .AddWithValue("QutoNo", TxtQutoNo.Text)
                .AddWithValue("QutoRef", TxtRefNo.Text)
                .AddWithValue("OrderNo", "")
                .AddWithValue("OrderRef", "")
                .AddWithValue("DNoteno", "")
                .AddWithValue("DnoteRef", "")
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Currency", TxtCurrency.Text)
                .AddWithValue("PriceList", TxtPriceLevel.Text)
                .AddWithValue("SalesPerson", TxtSalesPerson.Text)
                .AddWithValue("ProjectName", TxtProject.Text)
                .AddWithValue("Area", TxtArea.Text)
                .AddWithValue("LedgerName", txtLedgerName.Text)
                .AddWithValue("LedgerAddress", TxtToPrintName.Text)
                .AddWithValue("customername", TxtToPrintName.Text)
                .AddWithValue("IsCommit", 0)
                .AddWithValue("IsDelete", 0)
                .AddWithValue("IsPending", 1)
                .AddWithValue("subtotal", CDbl(TxtGrossTotal.Text))
                .AddWithValue("grosstotal", CDbl(TxtGrossTotal.Text))
                .AddWithValue("discountper", CDbl(TxtDiscAmt.Text))
                .AddWithValue("nettotal", CDbl(TxtNetTotal.Text))

                'VoucherType
                .AddWithValue("VoucherType", TxtVoucherType.Text)
                If TxtVoucherType.Text = "Tax Invoice" Then
                    .AddWithValue("cstamount", 0)
                    .AddWithValue("taxtotal", CDbl(TxtTaxTotal.Text))
                    .AddWithValue("taxtotal2", Tax2TotalValue)
                Else
                    .AddWithValue("cstamount", CDbl(TxtTaxTotal.Text))
                    .AddWithValue("taxtotal", CDbl(TxtTaxTotal.Text))
                    .AddWithValue("taxtotal2", 0)
                End If


                .AddWithValue("InvoiceTotal", 0)
                .AddWithValue("AccountTotal", CDbl(TxtServiceAccountAmount.Text))
                .AddWithValue("amountinwords", TxtAmtInwords.Text)
                .AddWithValue("narration", TxtNarration.Text)
                .AddWithValue("InvoiceNo", "")
                .AddWithValue("InvoiceRef", "")
                .AddWithValue("GoodNo", "")
                .AddWithValue("GoodRef", "")
                Select Case InvoiceCtrlType
                    Case "SO"
                        .AddWithValue("VoucherName", "SO")
                        .AddWithValue("PaymentMethod", TxtPaymentMethod.Text)
                        .AddWithValue("PaymentLedger", "")
                        .AddWithValue("PaymentDetails", "")
                    Case "SI"
                        .AddWithValue("VoucherName", "SI")
                        .AddWithValue("PaymentMethod", TxtPaymentMethod.Text)
                        .AddWithValue("PaymentLedger", TxtPaymentBy.Text)
                        .AddWithValue("PaymentDetails", TxtPaymentDetails.Text)
                    Case "SQ"
                        .AddWithValue("VoucherName", "SQ")
                        .AddWithValue("PaymentMethod", TxtPaymentMethod.Text)
                        .AddWithValue("PaymentLedger", "")
                        .AddWithValue("PaymentDetails", "")
                    Case "SR"
                        .AddWithValue("VoucherName", "SR")
                        .AddWithValue("PaymentMethod", TxtPaymentMethod.Text)
                        .AddWithValue("PaymentLedger", TxtPaymentBy.Text)
                        .AddWithValue("PaymentDetails", TxtPaymentDetails.Text)
                    Case "SD"
                        .AddWithValue("VoucherName", "SD")
                        .AddWithValue("PaymentMethod", TxtPaymentMethod.Text)
                        .AddWithValue("PaymentLedger", "")
                        .AddWithValue("PaymentDetails", "")
                    Case "POS"
                        .AddWithValue("VoucherName", "POS")
                        .AddWithValue("PaymentMethod", TxtPaymentMethod.Text)
                        .AddWithValue("PaymentLedger", TxtPaymentBy.Text)
                        .AddWithValue("PaymentDetails", TxtPaymentDetails.Text)
                End Select
                .AddWithValue("CurrencyCon1", OpenedCurrencyRate)
                .AddWithValue("DelivaryDate", TxtDelivaryDate.Value.Date)
                .AddWithValue("DelivaryDateValue", TxtDelivaryDate.Value.Date.ToOADate)
                .AddWithValue("Additions", TxtServiceAccountAmount.Text)
                .AddWithValue("Deductions", TxtDeductions.Text)
                .AddWithValue("AccountLedgerName", TxtSalesLedger.Text)
                .AddWithValue("servicetaxtotal", CDbl(TxtServiceTaxTotal.Text))
                .AddWithValue("roundoff", TxtRoundoff)
                .AddWithValue("surcharge", 0)
                .AddWithValue("DiscPer", CDbl(TxtDiscount.Text))
                .AddWithValue("CurrencyCon2", CDbl(TxtRateofExchange.Text))
                .AddWithValue("BillCurrency", TxtCurrency.Text)
                'CDisCountPer  CDiscount CouponName
                .AddWithValue("CDisCountPer", CDbl(TxtCouponPer.Text))
                .AddWithValue("CDiscount", CDbl(TxtCouponDiscAmount.Text))
                .AddWithValue("CouponName", TxtCouponName.Text)
                OpenedCouponDiscountAmount = CDbl(TxtCouponDiscAmount.Text)
                .AddWithValue("transtype", SalesTrancsationType)
                .AddWithValue("AdvancePayment", CDbl(TxtAdvancePayment.Text))
                .AddWithValue("CounterId", CurrentCounterID)
                .AddWithValue("IsMultiPayment", 0)

                .AddWithValue("BillType", "")
                .AddWithValue("CashReceived", 0)
                .AddWithValue("CashtoPay", 0)

            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub SaveRowDetailsData()
        Dim SqlStr As String = ""



        SqlStr = "INSERT INTO [StockInvoiceRowItems]([TransCode],[TransDate],[TransDateValue],[QutoNo],[QutoRef],[OrderNo],[OrderRef]," _
            & "[DNoteno],[DnoteRef],[StoreName],[Currency],[StockName],[StockCode],[stockgroup],[Barcode],[StockSize],[Location]," _
            & "[description],[BaseUnit],[MainUnit],[SubUnit],[IsSimpleUnit],[MainQty],[TotalQty],[SubUnitQty],[QtyText],[StockRate],[Expiry]," _
            & "[BatchNo],[StockType],[StockDisc],[RatePer],[UnitCon],[CustBarcode],[sno],[StockAmount],[QtyValues],[VoucherName]," _
            & "[CurrencyCon1],[Tax],[NetRate],[origin],[HScode],[isdelete],[Utranscode],[PresetRate],[TaxAmount],[disc2],[Servicetax],[netStockAmount],[MRP],[packing],[n1],[transtype],[slnos],[Tax2],[TaxAmount2],[FreeQty],[FreeQtyText],[FreeMQty],[FreeMQtyText],[UsedQty],[DiscountAmount1],[DiscountAmount2]) " _
            & " VALUES (@TransCode,@TransDate,@TransDateValue,@QutoNo,@QutoRef,@OrderNo,@OrderRef,@DNoteno,@DnoteRef," _
            & "@StoreName,@Currency,@StockName,@StockCode,@stockgroup,@Barcode,@StockSize,@Location,@description,@BaseUnit," _
            & "@MainUnit,@SubUnit,@IsSimpleUnit,@MainQty,@TotalQty,@SubUnitQty,@QtyText,@StockRate,@Expiry,@BatchNo,@StockType," _
            & "@StockDisc,@RatePer,@UnitCon,@CustBarcode,@sno,@StockAmount,@QtyValues,@VoucherName,@CurrencyCon1,@Tax,@NetRate,@origin,@HScode,@isdelete,@Utranscode,@PresetRate,@TaxAmount,@disc2,@Servicetax,@netStockAmount,@MRP,@packing,@n1,@transtype,@slnos,@Tax2,@TaxAmount2,@FreeQty,@FreeQtyText,@FreeMQty,@FreeMQtyText,@UsedQty,@DiscountAmount1,@DiscountAmount2)"
        '[Utranscode] [bigint] NULL
        For i As Integer = 0 To TxtList.RowCount - 1
            If TxtList.Item("StBarCode", i).Value.ToString.Length > 0 Then
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim st As New ChooseItemClass
                st.ClearData()
                LoadStockItemsIntoClass(TxtList.Item("StBarCode", i).Value, TxtList.Item("Stlocation", i).Value, st)
                st.TxtQtyBOX.SetUnitName(st.StockUnitName)
                st.TxtQtyFreeBOX.SetUnitName(st.StockUnitName)
                st.TxtMQtyBOX.SetUnitName(st.StockUnitName)

                If st.TxtQtyBOX.IsSimpleUnit = True Then
                    st.TxtQtyBOX.TxtQty1.Text = TxtList.Item("Stqty", i).Value
                    st.TxtQtyFreeBOX.TxtQty1.Text = TxtList.Item("stfreeqty", i).Value
                    st.TxtMQtyBOX.TxtQty1.Text = TxtList.Item("stmqty", i).Value
                Else
                    st.TxtQtyBOX.TxtQty2.Text = TxtList.Item("Stqty", i).Value
                    st.TxtQtyFreeBOX.TxtQty2.Text = TxtList.Item("stfreeqty", i).Value
                    st.TxtMQtyBOX.TxtQty2.Text = TxtList.Item("stmqty", i).Value
                End If

                st.TxtQtyBOX.CalculateValues()
                st.TxtQtyFreeBOX.CalculateValues()
                st.TxtMQtyBOX.CalculateValues()

                Dim DBF1 As New SqlClient.SqlCommand(SqlStr, MAINCON)
                With DBF1.Parameters
                    .AddWithValue("sno", i + 1)
                    .AddWithValue("TransCode", OpenedTranscode)
                    .AddWithValue("TransDate", TxtDate.Value)
                    .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                    .AddWithValue("QutoNo", TxtQutoNo.Text)
                    .AddWithValue("QutoRef", TxtRefNo.Text)
                    .AddWithValue("OrderNo", "0")
                    .AddWithValue("OrderRef", "0")
                    .AddWithValue("DNoteno", "0")
                    .AddWithValue("DnoteRef", "0")
                    .AddWithValue("StoreName", DefStoreName)
                    .AddWithValue("Currency", "")
                    .AddWithValue("StockName", st.StockItemName)
                    .AddWithValue("StockCode", st.StockItemCode)
                    .AddWithValue("stockgroup", st.StockGroup)
                    .AddWithValue("Barcode", st.StockItemBarCode)
                    .AddWithValue("StockSize", st.StockITemSize)
                    .AddWithValue("Location", st.StockLocationNames)
                    .AddWithValue("description", st.StockITemDescription)
                    .AddWithValue("BaseUnit", st.TxtQtyBOX.GetUnitName)
                    .AddWithValue("MainUnit", st.TxtQtyBOX.GetMainUnit)
                    .AddWithValue("SubUnit", st.TxtQtyBOX.GetSubUnit)
                    .AddWithValue("IsSimpleUnit", IIf(st.TxtQtyBOX.IsSimpleUnit() = True, 1, 0))

                    .AddWithValue("MainQty", st.TxtQtyBOX.GetUnitQtys(0))
                    .AddWithValue("TotalQty", st.TxtQtyBOX.GetTotalQty())

                    .AddWithValue("FreeQty", st.TxtQtyFreeBOX.GetTotalQty)
                    .AddWithValue("FreeQtytext", st.TxtQtyFreeBOX.GetTotalQtyText)

                    .AddWithValue("FreeMQty", st.TxtMQtyBOX.GetTotalQty)
                    .AddWithValue("FreeMQtyText", st.TxtMQtyBOX.GetTotalQtyText)

                    .AddWithValue("packing", st.Packing)
                    If st.TxtQtyBOX.IsSimpleUnit = True Then
                        .AddWithValue("QtyValues", st.TxtQtyBOX.TxtQty1.Text & " " & st.TxtQtyBOX.GetMainUnit)
                    Else
                        .AddWithValue("QtyValues", st.TxtQtyBOX.TxtQty1.Text & "-" & st.TxtQtyBOX.TxtQty2.Text & " " & st.TxtQtyBOX.GetMainUnit)
                    End If
                    .AddWithValue("SubUnitQty", st.TxtQtyBOX.GetUnitQtys(1))
                    .AddWithValue("QtyText", st.TxtQtyBOX.GetTotalQtyText)
                    .AddWithValue("StockRate", CDbl(TxtList.Item("Strate", i).Value))
                    .AddWithValue("StockDisc", CDbl(TxtList.Item("StDiscount", i).Value))
                    .AddWithValue("RatePer", TxtList.Item("Strateper", i).Value)
                    If Len(TxtList.Item("Stbatchno", i).Value) > 0 Then
                        .AddWithValue("Expiry", CDate(TxtList.Item("stExpiry", i).Value))
                    Else
                        .AddWithValue("Expiry", DBNull.Value)
                    End If
                    .AddWithValue("BatchNo", TxtList.Item("Stbatchno", i).Value)
                    .AddWithValue("StockType", st.StockType)
                    .AddWithValue("MRP", CDbl(TxtList.Item("stmrp", i).Value))
                    .AddWithValue("UnitCon", st.TxtQtyBOX.GetUnitConversion())
                    .AddWithValue("StockAmount", CDbl(TxtList.Item("stStockvalueWithOutTax", i).Value))
                    .AddWithValue("disc2", CDbl(TxtList.Item("tdisc2", i).Value))
                    .AddWithValue("PresetRate", CDbl(TxtList.Item("stprate", i).Value))
                    Select Case InvoiceCtrlType
                        Case "SO"
                            .AddWithValue("VoucherName", "SO")
                            .AddWithValue("slnos", "")
                        Case "SI"
                            .AddWithValue("VoucherName", "SI")
                            .AddWithValue("slnos", IIf(TxtList.Item("stslnos", i).Value = Nothing, "", TxtList.Item("stslnos", i).Value))
                        Case "SQ"
                            .AddWithValue("VoucherName", "SQ")
                            .AddWithValue("slnos", "")
                        Case "SR"
                            .AddWithValue("VoucherName", "SR")
                            .AddWithValue("slnos", IIf(TxtList.Item("stslnos", i).Value = Nothing, "", TxtList.Item("stslnos", i).Value))
                        Case "SD"
                            .AddWithValue("VoucherName", "SD")
                            .AddWithValue("slnos", IIf(TxtList.Item("stslnos", i).Value = Nothing, "", TxtList.Item("stslnos", i).Value))
                        Case "POS"
                            .AddWithValue("VoucherName", "POS")
                            .AddWithValue("slnos", IIf(TxtList.Item("stslnos", i).Value = Nothing, "", TxtList.Item("stslnos", i).Value))
                    End Select
                    'StockAmount
                    If Len(TxtList.Item("stcustbarcode", i).Value) = 0 Then
                        .AddWithValue("CustBarcode", "")
                    Else
                        .AddWithValue("CustBarcode", TxtList.Item("stcustbarcode", i).Value.ToString)
                    End If
                    .AddWithValue("CurrencyCon1", OpenedCurrencyRate)
                    If TxtVoucherType.Text = "Tax Invoice" Then
                        .AddWithValue("Tax", CDbl(TxtList.Item("Sttax", i).Value))
                        .AddWithValue("Tax2", CDbl(TxtList.Item("Sttax2", i).Value))
                        .AddWithValue("TaxAmount", CDbl(TxtList.Item("sttaxamount", i).Value))
                        .AddWithValue("TaxAmount2", CDbl(TxtList.Item("sttaxamount2", i).Value))
                    Else
                        .AddWithValue("Tax", CDbl(TxtList.Item("Sttax", i).Value))
                        .AddWithValue("Tax2", 0)
                        .AddWithValue("TaxAmount", CDbl(TxtList.Item("sttaxamount", i).Value))
                        .AddWithValue("TaxAmount2", 0)
                    End If

                    .AddWithValue("NetRate", CDbl(TxtList.Item("stnetrate", i).Value))
                    .AddWithValue("origin", TxtList.Item("stmadeby", i).Value)
                    .AddWithValue("HScode", TxtList.Item("sthscode", i).Value)
                    If TxtList.Item("tUTranscode", i).Value = Nothing Then
                        .AddWithValue("Utranscode", 0)
                    Else
                        .AddWithValue("Utranscode", TxtList.Item("tUTranscode", i).Value)
                    End If

                    .AddWithValue("isdelete", 0)
                    .AddWithValue("Servicetax", CDbl(TxtList.Item("stservicetax", i).Value))
                    .AddWithValue("netStockAmount", CDbl(TxtList.Item("StStockTaxValue", i).Value))
                    .AddWithValue("DiscountAmount1", CDbl(TxtList.Item("stdiscamt1", i).Value))
                    .AddWithValue("DiscountAmount2", CDbl(TxtList.Item("stdiscamt2", i).Value))

                    Try
                        .AddWithValue("n1", CDbl(TxtList.Item("stprofit", i).Value))
                    Catch ex As Exception
                        .AddWithValue("n1", 0)
                    End Try
                    .AddWithValue("transtype", SalesTrancsationType)
                    Try
                        If Len(TxtList.Item("stdnoteno", i).Value) > 0 Then
                            .AddWithValue("UsedQty", st.TxtQtyBOX.GetTotalQty())
                        Else
                            .AddWithValue("UsedQty", 0)
                        End If
                    Catch ex As Exception
                        .AddWithValue("UsedQty", 0)
                    End Try

                    st = Nothing
                End With
                DBF1.ExecuteNonQuery()
                DBF1 = Nothing
                MAINCON.Close()
            End If

        Next
        SaveSerialNumbers()
    End Sub
    Sub SaveData()
        If IMSBEGINTRANSACTION() = False Then
            IMSENDTRANSACTION()

            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        If IsInvoiceOpen = True Then
            If IsOpendByWindows = True Then
                Select Case InvoiceCtrlType
                    Case "SO"
                        UpdateLogFile(DefStoreName, OpenedTranscode, "SalesOrder", TxtQutoNo.Text, CurrentUserName, "Modified", System.Environment.MachineName, "Modified   SalesOrder  by OpenMethod")
                    Case "SI"
                        UpdateLogFile(DefStoreName, OpenedTranscode, "Salesinvoice", TxtQutoNo.Text, CurrentUserName, "Modified", System.Environment.MachineName, "Modified   Salesinvoice  by OpenMethod")
                    Case "SQ"
                        UpdateLogFile(DefStoreName, OpenedTranscode, "SalesQuotation", TxtQutoNo.Text, CurrentUserName, "Modified", System.Environment.MachineName, "Modified   SalesQuotation  by OpenMethod")
                    Case "SR"
                        UpdateLogFile(DefStoreName, OpenedTranscode, "CreditNote", TxtQutoNo.Text, CurrentUserName, "Modified", System.Environment.MachineName, "Modified   CreditNote  by OpenMethod")
                    Case "SD"
                        UpdateLogFile(DefStoreName, OpenedTranscode, "SalesDeliveryNote", TxtQutoNo.Text, CurrentUserName, "Modified", System.Environment.MachineName, "Modified   SalesDeliveryNote  by OpenMethod")
                    Case "POS"
                        UpdateLogFile(DefStoreName, OpenedTranscode, "POS", TxtQutoNo.Text, CurrentUserName, "Modified", System.Environment.MachineName, "Modified   POS  by OpenMethod")
                End Select

            End If

            Select Case InvoiceCtrlType
                Case "SI", "SR", "POS"
                    RollBackAccounts()
            End Select

            Select Case InvoiceCtrlType
                Case "SD", "POS"
                    RollBackUpdatedOrdereditemsQtys()

            End Select


            'RELEASE PENDINGS ORDERS....
            For I As Integer = 0 To OpenedTransList.ListofTrascodeadded.Rows.Count - 1
                ExecuteSQLQuery("UPDATE StockInvoiceDetails SET ISPENDING=1 WHERE TRANSCODE=" & OpenedTransList.ListofTrascodeadded.Item("TRANSCODE", I).Value)
            Next
            ExecuteSQLQuery("update  StockInvoiceRowItems set Isdelete=1  where transcode=" & OpenedTranscode)
            Select Case InvoiceCtrlType
                Case "SD", "SR", "POS"
                    RollBackStockQuantities()
            End Select

            ExecuteSQLQuery("delete from UsedTranscodeList where transcode=" & OpenedTranscode)
            'DELETE ENTRIES
            ExecuteSQLQuery("delete from StockInvoiceDetails where transcode=" & OpenedTranscode)
            ExecuteSQLQuery("delete from StockInvoiceRowItems where transcode=" & OpenedTranscode)
            ExecuteSQLQuery("delete from VoucherAccounts where transcode=" & OpenedTranscode)
            ExecuteSQLQuery("delete from InvoiceMoreDet where transcode=" & OpenedTranscode)

            'OpenedCouponDiscountAmount
            'updatecoupondiscountamount
            If PostDatedBox.Checked = True Then
                OpenedPDCValues.IsPDC = True
            Else
                OpenedPDCValues.IsPDC = False
                OpenedPDCValues.IsPDCClear = True
            End If
            If OpenedLedgerName <> txtLedgerName.Text Then
                OpenedCurrencyRate = GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & txtLedgerName.Text & "'", "currency").ToString)
            End If

        Else



            OpenedTranscode = GetAndSetIDCode(EnumIDType.TransCode)
            OpenedCurrencyRate = GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & txtLedgerName.Text & "'", "currency").ToString)
            Select Case InvoiceCtrlType
                Case "SO"
                    If InvoiceBillingSettings.SalesOrderSettings.InvoiceMethod = 0 Then
                        TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.salesorder)
                    Else
                        GetAndSetInvoiceNumber(InvoiceNoStrct.salesorder)
                    End If

                    UpdateLogFile(DefStoreName, OpenedTranscode, "SalesOrder", TxtQutoNo.Text, CurrentUserName, "Created", System.Environment.MachineName, "Created New Sales Order")


                Case "SI"
                    If InvoiceBillingSettings.SalesInvoiceSettings.InvoiceMethod = 0 Then
                        TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.salesinvoice)
                    Else
                        GetAndSetInvoiceNumber(InvoiceNoStrct.salesinvoice)
                    End If

                    UpdateLogFile(DefStoreName, OpenedTranscode, "Salesinvoice", TxtQutoNo.Text, CurrentUserName, "Created", System.Environment.MachineName, "Created New Sales invoice")


                Case "SQ"
                    If InvoiceBillingSettings.SalesQutoSetting.InvoiceMethod = 0 Then
                        TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.salesquoto)
                    Else
                        GetAndSetInvoiceNumber(InvoiceNoStrct.salesquoto)
                    End If

                    UpdateLogFile(DefStoreName, OpenedTranscode, "SalesQuotation", TxtQutoNo.Text, CurrentUserName, "Created", System.Environment.MachineName, "Created New SalesQuotation")


                Case "SR"
                    If SalesTrancsationType.Length > 0 Then
                        If SalesTrancsationType = "Returns Form-8B" Then
                            If InvoiceBillingSettings.Form8BSalesRETInvoicesetting.InvoiceMethod = 0 Then
                                TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.SRFORM8B)
                            Else
                                GetAndSetInvoiceNumber(InvoiceNoStrct.SRFORM8B)
                            End If

                        ElseIf SalesTrancsationType = "Returns Form-8" Then

                            If InvoiceBillingSettings.Form8SalesRETInvoicesetting.InvoiceMethod = 0 Then
                                TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.SRFORM8)
                            Else
                                GetAndSetInvoiceNumber(InvoiceNoStrct.SRFORM8)
                            End If
                        Else

                            If InvoiceBillingSettings.Form8DSalesRETInvoicesetting.InvoiceMethod = 0 Then
                                TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.SRFORM8D)
                            Else
                                GetAndSetInvoiceNumber(InvoiceNoStrct.SRFORM8D)
                            End If
                        End If
                    Else

                        If InvoiceBillingSettings.SalesReturnInvoiceSettings.InvoiceMethod = 0 Then
                            TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.SalesRetInvoice)
                        Else
                            GetAndSetInvoiceNumber(InvoiceNoStrct.SalesRetInvoice)
                        End If
                    End If

                   



                    UpdateLogFile(DefStoreName, OpenedTranscode, "Credit Note", TxtQutoNo.Text, CurrentUserName, "Created", System.Environment.MachineName, "Created New Credit Note")


                Case "SD"
                    If InvoiceBillingSettings.SalesDelavarySettings.InvoiceMethod = 0 Then
                        TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.salesdelavery)
                    Else
                        GetAndSetInvoiceNumber(InvoiceNoStrct.salesdelavery)
                    End If

                    UpdateLogFile(DefStoreName, OpenedTranscode, "SalesDeliveryNote", TxtQutoNo.Text, CurrentUserName, "Created", System.Environment.MachineName, "Created New SalesDeliveryNote")


                Case "POS"
                    If SalesTrancsationType.Length > 0 Then
                        If SalesTrancsationType = "Cash Sales" Then

                            If InvoiceBillingSettings.CashSalesInvoicesetting.InvoiceMethod = 0 Then
                                TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.CASHSALES)
                            Else
                                GetAndSetInvoiceNumber(InvoiceNoStrct.CASHSALES)
                            End If
                        ElseIf SalesTrancsationType = "Credit Sales" Then

                            If InvoiceBillingSettings.CreditSalesInvoicesetting.InvoiceMethod = 0 Then
                                TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.CREDITSALES)
                            Else
                                GetAndSetInvoiceNumber(InvoiceNoStrct.CREDITSALES)
                            End If
                        ElseIf SalesTrancsationType = "Form-8" Then

                            If InvoiceBillingSettings.Form8SalesInvoicesetting.InvoiceMethod = 0 Then
                                TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.FORM8)
                            Else
                                GetAndSetInvoiceNumber(InvoiceNoStrct.FORM8)
                            End If
                        ElseIf SalesTrancsationType = "Form-8B" Then
                            TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.FORM8B)
                            If InvoiceBillingSettings.POS.InvoiceMethod = 0 Then
                            Else

                            End If
                        ElseIf SalesTrancsationType = "Form-8D" Then

                            If InvoiceBillingSettings.Form8DSalesInvoicesetting.InvoiceMethod = 0 Then
                                TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.FORM8D)
                            Else
                                GetAndSetInvoiceNumber(InvoiceNoStrct.FORM8D)
                            End If
                        Else

                            If InvoiceBillingSettings.POS.InvoiceMethod = 0 Then
                                TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.POS)
                            Else
                                GetAndSetInvoiceNumber(InvoiceNoStrct.POS)
                            End If
                        End If

                    Else

                        If InvoiceBillingSettings.POS.InvoiceMethod = 0 Then
                            TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.POS)
                        Else
                            GetAndSetInvoiceNumber(InvoiceNoStrct.POS)
                        End If
                    End If

                   

                    UpdateLogFile(DefStoreName, OpenedTranscode, "POS", TxtQutoNo.Text, CurrentUserName, "Created", System.Environment.MachineName, "Created New POS Invoice")


            End Select
            If PostDatedBox.Checked = True Then
                OpenedPDCValues.IsPDC = True
                OpenedPDCValues.IsPDCClear = False
            Else
                OpenedPDCValues.IsPDC = False
                OpenedPDCValues.IsPDCClear = True
            End If
            OpenedPDCValues.ischequePrint = False
            OpenedPDCValues.TodayDate.Value = Now

        End If

        If TxtServiceAccountAmount.Text.Length = 0 Then
            TxtServiceAccountAmount.Text = "0"
        End If
        SaveMasterData()
        SaveRowDetailsData()

        'UPDATE STOCK ITEMS FOR SALES INVOICE AND POINT OF SALES

        For I As Integer = 0 To CurrentTransList.ListofTrascodeadded.Rows.Count - 1
            ExecuteSQLQuery("UPDATE StockInvoiceDetails SET ISPENDING=0 WHERE TRANSCODE=" & CurrentTransList.ListofTrascodeadded.Item("TRANSCODE", I).Value)
            ExecuteSQLQuery("INSERT INTO [UsedTranscodeList]([Transcode],[UsedTranscode],[UsedDbName]) VALUES(" & OpenedTranscode & "," & CurrentTransList.ListofTrascodeadded.Item("TRANSCODE", I).Value & ",'StockInvoiceDetails')")

        Next


        'READING LIST OF USED INVOICE TRANSCODES
        Dim SqlConn As New SqlClient.SqlConnection
        OpenedTransList.ListofTrascodeadded.Rows.Clear()
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from UsedTranscodeList where transcode=" & OpenedTranscode
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                Dim K As Integer
                K = OpenedTransList.ListofTrascodeadded.Rows.Add
                OpenedTransList.ListofTrascodeadded.Item("transcode", K).Value = Sreader("UsedTranscode").ToString.Trim
                OpenedTransList.ListofTrascodeadded.Item("dbname", K).Value = Sreader("UsedDbName").ToString.Trim
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            SQLFcmd.Connection = Nothing
        End Try

        UpdateOrderedItemsQtys()

        LockTransaction(OpenedTranscode)
        SaveAccountServices(OpenedTranscode)
        SaveMoreDetails(OpenedTranscode, TxtRefNo.Text)

        Select Case InvoiceCtrlType
            Case "SD", "POS", "SR"
                UpdateStockForSI_SR_POS()
        End Select
        Select Case InvoiceCtrlType
            Case "SI", "POS", "SR"
                SaveTrasactions(OpenedTranscode)
                SaveChequeInfo(OpenedTranscode)
                UpdatePDCValues(OpenedTranscode, OpenedPDCValues)
                UpdateBill2Bill()

        End Select
        Select Case InvoiceCtrlType
            Case "SD", "POS", "SR"
                SaveCostCentersData(OpenedTranscode)
        End Select
        Select Case InvoiceCtrlType
            Case "SO", "SQ"
                ExecuteSQLQuery("update  StockInvoiceRowItems set UsedQty=0 where transcode=" & OpenedTranscode)
        End Select
        Me.Cursor = Cursors.Default
        IsInvoiceOpen = True
        IsInvoiceSaved = True
        IMSENDTRANSACTION()
        If IsCopyInvoice = True Then
            IsCopyInvoice = False
            Exit Sub
        End If
        If MyAppSettings.ISAllowAutoInvoicePrining = True Then
            PrintInvoice()
        End If
        If SQLGetBooleanFieldValue("select IsSendSMS from ledgers where ledgername=N'" & txtLedgerName.Text & "'", "IsSendSMS") = True Then
            Dim TempStr As String = ""
            Dim vhname As String = ""
            Select Case InvoiceCtrlType
                Case "SI"
                    vhname = "SALES"
                Case "SR"
                    vhname = "SALES RETURNS"
                Case "POS"
                    vhname = "SALES"
            End Select
            If vhname.Length > 0 Then
                If MsgBox("Do you want to Send SMS to Customer Mobile ?       ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim mbno As String = ""
                    If TxtMobileNo.Text.Length >= 10 Then
                        mbno = TxtMobileNo.Text
                    Else
                        mbno = SQLGetStringFieldValue("select tel from ledgers where ledgername=N'" & txtLedgerName.Text & "'", "tel")
                    End If


                    If mbno.Length > 6 Then
                        TempStr = SQLGetStringFieldValue("SELECT MSGTEXT FROM smsmailsettings where vouchername=N'" & vhname & "'", "MSGTEXT")
                        TempStr = TempStr.Replace("@TODAYDATE@", Today.ToString())
                        TempStr = TempStr.Replace("@INVOICENO@", TxtQutoNo.Text)
                        TempStr = TempStr.Replace("@INVOICEDATE@", TxtDate.Value.Date.ToString())
                        TempStr = TempStr.Replace("@PARTYNAME@", txtLedgerName.Text)
                        TempStr = TempStr.Replace("@CURRENTAMOUNT@", TxtNetTotal.Text)
                        TempStr = TempStr.Replace("@INVOICEBALANCE@", "NAV")
                        TempStr = TempStr.Replace("@PAYMENTBY@", "NAV")
                        TempStr = TempStr.Replace("@BALANCE@", GetCurrentBalanceText(txtLedgerName.Text))
                        TempStr = TempStr.Replace("@CURRENTBALANCE@", GetCurrentBalanceValue(txtLedgerName.Text) - (TxtNetTotal.Text))
                        SendSMSToMobile(mbno, TempStr)
                    End If
                End If

            End If
        ElseIf TxtMobileNo.Text.Length > 5 Then
            Dim TempStr As String = ""
            Dim vhname As String = ""
            Select Case InvoiceCtrlType
                Case "SI"
                    vhname = "SALES"
                Case "SR"
                    vhname = "SALES RETURNS"
                Case "POS"
                    vhname = "SALES"
            End Select
            If vhname.Length > 0 Then
                If MsgBox("Do you want to Send SMS to Customer Mobile ?       ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim mbno As String = ""
                    mbno = TxtMobileNo.Text

                    If mbno.Length > 6 Then
                        TempStr = SQLGetStringFieldValue("SELECT MSGTEXT FROM smsmailsettings where vouchername=N'" & vhname & "'", "MSGTEXT")
                        TempStr = TempStr.Replace("@TODAYDATE@", Today.ToString())
                        TempStr = TempStr.Replace("@INVOICENO@", TxtQutoNo.Text)
                        TempStr = TempStr.Replace("@INVOICEDATE@", TxtDate.Value.Date.ToString())
                        TempStr = TempStr.Replace("@PARTYNAME@", txtLedgerName.Text)
                        TempStr = TempStr.Replace("@CURRENTAMOUNT@", TxtNetTotal.Text)
                        TempStr = TempStr.Replace("@INVOICEBALANCE@", "NAV")
                        TempStr = TempStr.Replace("@PAYMENTBY@", "NAV")
                        TempStr = TempStr.Replace("@BALANCE@", GetCurrentBalanceText(txtLedgerName.Text))
                        TempStr = TempStr.Replace("@CURRENTBALANCE@", GetCurrentBalanceValue(txtLedgerName.Text) - (TxtNetTotal.Text))
                        SendSMSToMobile(mbno, TempStr)
                    End If
                End If

            End If
        End If

        If MyAppSettings.IsNewBillAfterSaveInvoice = True Then
           
            LoadDefaults()
            LoadStockEntryDefaults()
            TxtDate.Focus()
            IsInvoiceSaved = True
            IsInvoiceOpen = False
        End If

    End Sub
    Sub SaveCostCentersData(ByVal trancode As Double)
        ExecuteSQLQuery("delete from costcenterbook where TransCode=" & trancode)
        Dim Sno As Integer = 0

        If CostList.RowCount > 0 Then
            For rc As Integer = 0 To CostList.RowCount - 1
                If Len(CostList.Item("tcostname", rc).Value) > 0 Then
                    Dim SqlStr As String = ""
                    'IsAdditional='False' and 
                    SqlStr = "INSERT INTO [CostCenterBook] ([sno],[LedgerName],[CostCenterName],[Dr],[Cr],[UserName],[TransCode],[TransDate],[Transdatevalue],[VoucherName],[InvoiceNo],[CostNo],[CostCat],[IsAdditional])    " _
                        & " VALUES (@sno,@LedgerName,@CostCenterName,@Dr,@Cr,@UserName,@TransCode,@TransDate,@Transdatevalue,@VoucherName,@InvoiceNo,@CostNo,@CostCat,@IsAdditional) "
                    Sno = Sno + 1
                    MAINCON.ConnectionString = ConnectionStrinG
                    MAINCON.Open()
                    Dim DBFR = New SqlClient.SqlCommand(SqlStr, MAINCON)
                    With DBFR.Parameters
                        .AddWithValue("sno", Sno)
                        .AddWithValue("LedgerName", txtLedgerName.Text)
                        .AddWithValue("CostCenterName", CostList.Item("tcostname", rc).Value)
                        If InvoiceCtrlType = "SR" Then
                            .AddWithValue("Dr", 0)
                            .AddWithValue("Cr", CostList.Item("tamount", rc).Value)
                        Else
                            .AddWithValue("Dr", CostList.Item("tamount", rc).Value)
                            .AddWithValue("Cr", 0)
                        End If
                        .AddWithValue("costcat", CostList.Item("tcostcat", rc).Value)
                        .AddWithValue("UserName", CurrentUserName)
                        .AddWithValue("TransCode", trancode)
                        .AddWithValue("TransDate", TxtDate.Value)
                        .AddWithValue("Transdatevalue", TxtDate.Value.Date.ToOADate)
                        .AddWithValue("VoucherName", InvoiceCtrlType)
                        .AddWithValue("InvoiceNo", TxtRefNo.Text)
                        .AddWithValue("CostNo", CostList.Item("tcostno", rc).Value)
                        .AddWithValue("IsAdditional", "False")
                    End With
                    DBFR.ExecuteNonQuery()
                    DBFR = Nothing
                    MAINCON.Close()
                End If
            Next
        End If
        'FOR ADDITIONAL COST CENTERS
        'FOR SALES PERSONS
        Dim subSqlStr As String = ""
        'IsAdditional='False' and 
        subSqlStr = "INSERT INTO [CostCenterBook] ([sno],[LedgerName],[CostCenterName],[Dr],[Cr],[UserName],[TransCode],[TransDate],[Transdatevalue],[VoucherName],[InvoiceNo],[CostNo],[CostCat],[IsAdditional])    " _
            & " VALUES (@sno,@LedgerName,@CostCenterName,@Dr,@Cr,@UserName,@TransCode,@TransDate,@Transdatevalue,@VoucherName,@InvoiceNo,@CostNo,@CostCat,@IsAdditional) "
        Sno = Sno + 1
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBFR2 = New SqlClient.SqlCommand(subSqlStr, MAINCON)
        With DBFR2.Parameters
            .AddWithValue("sno", Sno)
            .AddWithValue("LedgerName", txtLedgerName.Text)
            .AddWithValue("CostCenterName", TxtSalesPerson.Text)
            If InvoiceCtrlType = "SR" Then
                .AddWithValue("Dr", 0)
                .AddWithValue("Cr", CDbl(TxtNetTotal.Text))
            Else
                .AddWithValue("Dr", CDbl(TxtNetTotal.Text))
                .AddWithValue("Cr", 0)
            End If
            .AddWithValue("costcat", "*Primary")
            .AddWithValue("UserName", CurrentUserName)
            .AddWithValue("TransCode", trancode)
            .AddWithValue("TransDate", TxtDate.Value)
            .AddWithValue("Transdatevalue", TxtDate.Value.Date.ToOADate)
            .AddWithValue("VoucherName", InvoiceCtrlType)
            .AddWithValue("InvoiceNo", TxtRefNo.Text)
            .AddWithValue("CostNo", 0)
            .AddWithValue("IsAdditional", "True")
        End With
        DBFR2.ExecuteNonQuery()
        DBFR2 = Nothing
        MAINCON.Close()
        'FOR PROJECT
        Sno = Sno + 1
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBFR3 = New SqlClient.SqlCommand(subSqlStr, MAINCON)
        With DBFR3.Parameters
            .AddWithValue("sno", Sno)
            .AddWithValue("LedgerName", txtLedgerName.Text)
            .AddWithValue("CostCenterName", TxtProject.Text)
            If InvoiceCtrlType = "SR" Then
                .AddWithValue("Dr", 0)
                .AddWithValue("Cr", CDbl(TxtNetTotal.Text))
            Else
                .AddWithValue("Dr", CDbl(TxtNetTotal.Text))
                .AddWithValue("Cr", 0)
            End If
            .AddWithValue("costcat", "*Primary")
            .AddWithValue("UserName", CurrentUserName)
            .AddWithValue("TransCode", trancode)
            .AddWithValue("TransDate", TxtDate.Value)
            .AddWithValue("Transdatevalue", TxtDate.Value.Date.ToOADate)
            .AddWithValue("VoucherName", InvoiceCtrlType)
            .AddWithValue("InvoiceNo", TxtRefNo.Text)
            .AddWithValue("CostNo", 0)
            .AddWithValue("IsAdditional", "True")
        End With
        DBFR3.ExecuteNonQuery()
        DBFR3 = Nothing
        MAINCON.Close()
    End Sub
    Sub UpdateBill2Bill()
        If InvoiceCtrlType = "SI" Or InvoiceCtrlType = "POS" Then
            ExecuteSQLQuery("delete from bill2bill where billtype='New' and transcode=" & OpenedTranscode)
            If TxtPaymentMethod.Text <> "Credit" Then Exit Sub

            Dim SqlStr As String = ""
            SqlStr = "INSERT INTO [Bill2Bill]([BillType],[LedgerName],[TransCode],[BillTransCode],[Dr],[Cr],[RefNo],[InvoiceNo],[IsOpening],[TransDate],[StoreName],[PayDays],[VoucherName]) " _
                                   & " VALUES(@BillType,@LedgerName,@TransCode,@BillTransCode,@Dr,@Cr,@RefNo,@InvoiceNo,@IsOpening,@TransDate,@StoreName,@PayDays,@VoucherName) "

            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF1 As New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBF1.Parameters
                If InvoiceCtrlType = "SI" Then
                    .AddWithValue("BillType", "New")
                    .AddWithValue("VoucherName", "SalesInvoice")
                ElseIf InvoiceCtrlType = "POS" Then

                    .AddWithValue("BillType", "New")
                    .AddWithValue("VoucherName", "POS")
                Else
                    .AddWithValue("BillType", "Against")
                    .AddWithValue("VoucherName", "SalesReturns")
                End If
                .AddWithValue("LedgerName", txtLedgerName.Text)
                .AddWithValue("TransCode", OpenedTranscode)
                .AddWithValue("BillTransCode", 0)
                If InvoiceCtrlType = "SD" Then
                    .AddWithValue("Dr", CDbl(TxtNetTotal.Text))
                    .AddWithValue("cr", 0)
                Else
                    .AddWithValue("Dr", 0)
                    .AddWithValue("cr", CDbl(TxtNetTotal.Text))
                End If
                'VoucherName

                .AddWithValue("RefNo", TxtRefNo.Text)
                .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                .AddWithValue("IsOpening", 0)
                .AddWithValue("TransDate", TxtDate.Value)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("PayDays", SQLGetNumericFieldValue("select CreditPeriod from ledgers where ledgername=N'" & txtLedgerName.Text & "'", "CreditPeriod"))
            End With
            DBF1.ExecuteNonQuery()
            DBF1 = Nothing
            MAINCON.Close()
        Else
            ExecuteSQLQuery("delete from bill2bill where  transcode=" & OpenedTranscode)
            If Bill2Billdetails.IsNotApplicable = True Then Exit Sub
            If TxtPaymentMethod.Text <> "Credit" Then
                For i As Integer = 0 To Bill2Billdetails.BillList.RowCount - 1
                    Dim SqlStr As String = ""
                    SqlStr = "INSERT INTO [Bill2Bill]([BillType],[LedgerName],[TransCode],[BillTransCode],[Dr],[Cr],[RefNo],[InvoiceNo],[IsOpening],[TransDate],[StoreName],[PayDays],[VoucherName],[PaymentMethod]) " _
                                           & " VALUES(@BillType,@LedgerName,@TransCode,@BillTransCode,@Dr,@Cr,@RefNo,@InvoiceNo,@IsOpening,@TransDate,@StoreName,@PayDays,@VoucherName,@PaymentMethod) "

                    MAINCON.ConnectionString = ConnectionStrinG
                    MAINCON.Open()
                    Dim DBF1 As New SqlClient.SqlCommand(SqlStr, MAINCON)
                    With DBF1.Parameters
                        .AddWithValue("BillType", Bill2Billdetails.BillList.Item("ttype", i).Value)
                        .AddWithValue("LedgerName", txtLedgerName.Text)
                        .AddWithValue("TransCode", OpenedTranscode)
                        .AddWithValue("BillTransCode", OpenedTranscode)
                        .AddWithValue("RefNo", Bill2Billdetails.BillList.Item("tref", i).Value)
                        .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                        .AddWithValue("IsOpening", 0)
                        .AddWithValue("TransDate", TxtDate.Value)
                        .AddWithValue("StoreName", DefStoreName)
                        .AddWithValue("PaymentMethod", TxtPaymentMethod.Text)

                        If Bill2Billdetails.BillList.Item("ttype", i).Value = "New" Then
                            .AddWithValue("PayDays", SQLGetNumericFieldValue("select CreditPeriod from ledgers where ledgername=N'" & txtLedgerName.Text & "'", "CreditPeriod"))
                        Else
                            .AddWithValue("PayDays", 0)
                        End If
                        .AddWithValue("VoucherName", "SalesReturns")
                        .AddWithValue("Dr", 0)
                        .AddWithValue("Cr", Bill2Billdetails.BillList.Item("tamt", i).Value)
                    End With
                    DBF1.ExecuteNonQuery()
                    DBF1 = Nothing
                    MAINCON.Close()
                Next
            End If

        End If



    End Sub
    Sub UpdateStockForSI_SR_POS()
        For I As Integer = 0 To TxtList.RowCount - 1
            ExecuteSQLQuery("exec UpdateStockQty N'" & TxtList.Item("stlocation", I).Value & "',N'" & TxtList.Item("STItemCode", I).Value & "',N'" & TxtList.Item("stsize", I).Value & "',N'" & TxtList.Item("stbatchno", I).Value & "'")
            ExecuteSQLQuery("EXEC proInventoryCosting N'" & TxtList.Item("stlocation", I).Value & "',N'" & TxtList.Item("STItemCode", I).Value & "',N'" & TxtList.Item("stsize", I).Value & "'," & UpdateQuantityForNon_StockAlso)
            ExecuteSQLQuery("exec UpdateBatchStockQty N'" & TxtList.Item("stlocation", I).Value & "',N'" & TxtList.Item("STItemCode", I).Value & "',N'" & TxtList.Item("stsize", I).Value & "',N'" & TxtList.Item("stbatchno", I).Value & "'")



        Next

    End Sub
    Sub SaveAccountServices(ByVal tcode As Single)
        Dim SqlStr As String = ""
        If TxtDrCr1.Text.Length > 0 And TxtLedgerName1.Text.Length > 0 And CDbl(TxtLedgerAmount1.Text) Then
            SqlStr = "INSERT INTO [VoucherAccounts] ([AccountName],[Amount],[IsDrCr],[Transcode],[VoucherNo],[sno]) " _
            & " VALUES(N'" & TxtLedgerName1.Text & "'," & CDbl(TxtLedgerAmount1.Text) & "," & IIf(TxtDrCr1.Text = "Dr", 0, 1) & "," & tcode & ",N'" & TxtRefNo.Text & "',1)"
            ExecuteSQLQuery(SqlStr)
        End If
        If TxtDrCr2.Text.Length > 0 And TxtLedgerName2.Text.Length > 0 And CDbl(TxtLedgerAmount2.Text) Then
            SqlStr = "INSERT INTO [VoucherAccounts] ([AccountName],[Amount],[IsDrCr],[Transcode],[VoucherNo],[sno]) " _
            & " VALUES(N'" & TxtLedgerName2.Text & "'," & CDbl(TxtLedgerAmount2.Text) & "," & IIf(TxtDrCr2.Text = "Dr", 0, 1) & "," & tcode & ",N'" & TxtRefNo.Text & "',2)"
            ExecuteSQLQuery(SqlStr)
        End If
        If TxtDrCr3.Text.Length > 0 And TxtLedgerName3.Text.Length > 0 And CDbl(TxtLedgerAmount3.Text) Then
            SqlStr = "INSERT INTO [VoucherAccounts] ([AccountName],[Amount],[IsDrCr],[Transcode],[VoucherNo],[sno]) " _
            & " VALUES(N'" & TxtLedgerName3.Text & "'," & CDbl(TxtLedgerAmount3.Text) & "," & IIf(TxtDrCr3.Text = "Dr", 0, 1) & "," & tcode & ",N'" & TxtRefNo.Text & "',3)"
            ExecuteSQLQuery(SqlStr)
        End If

    End Sub
    Sub SaveMoreDetails(ByVal Tcode As Single, ByVal OrderNo As String)

        Dim SQLSTR As String = ""
        SQLSTR = "INSERT INTO [InvoiceMoreDet] ([Despatchto],[Despatchaddress],[despatchtax],[despatchthrough],[DespatchDestination]," _
            & "[buyername],[buyeraddress],[buyertax],[paymenterm],[otherref],[remarks],[consgneename],[consgneeaddress],[delevaryto],[delevarynoteno],[orderno],[delevaryterm],[Transcode]) " _
            & " VALUES(@Despatchto,@Despatchaddress,@despatchtax,@despatchthrough,@DespatchDestination,@buyername,@buyeraddress,@buyertax,@paymenterm,@otherref,@remarks,@consgneename,@consgneeaddress,@delevaryto,@delevarynoteno,@orderno,@delevaryterm,@Transcode)"

        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(SQLSTR, MAINCON)
        With DBF.Parameters
            .AddWithValue("Despatchto", MoreDet.Despatchto)
            .AddWithValue("Despatchaddress", MoreDet.despatchaddress)
            .AddWithValue("despatchtax", MoreDet.despatchtaxdetails)
            .AddWithValue("despatchthrough", MoreDet.DespatchThrough)
            .AddWithValue("DespatchDestination", MoreDet.DespatchDestination)
            .AddWithValue("buyername", MoreDet.buyersname)
            .AddWithValue("buyeraddress", MoreDet.buyeraddress)
            .AddWithValue("buyertax", MoreDet.buyertaxdetails)
            .AddWithValue("paymenterm", MoreDet.paymentterm)
            .AddWithValue("otherref", MoreDet.otherreference)
            .AddWithValue("remarks", MoreDet.remarks)
            .AddWithValue("consgneename", MoreDet.consgneename)
            .AddWithValue("consgneeaddress", MoreDet.consgneeaddress)
            .AddWithValue("delevaryto", MoreDet.DelevaryTo)
            .AddWithValue("delevarynoteno", MoreDet.Delevarynoteno)
            .AddWithValue("orderno", OrderNo)
            .AddWithValue("delevaryterm", MoreDet.delevarterms)
            .AddWithValue("Transcode", Tcode)
        End With
        DBF.ExecuteNonQuery()
        DBF = Nothing
        MAINCON.Close()

    End Sub
    Private Sub TxtNetTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNetTotal.TextChanged, TxtServiceAccountAmount.TextChanged, TxtDeductions.TextChanged
        Try
            TxtAmtInwords.Text = GetInWords(CDbl(TxtNetTotal.Text), DefTailCurrencyName)
        Catch ex As Exception

        End Try
        Try
            TxtAdvancePayment.Max = CLng(TxtNetTotal.Text)
        Catch ex As Exception

        End Try
        IsInvoiceSaved = False
    End Sub

    Private Sub TxtSalesPerson_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSalesPerson.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim k As New CreateSalesPersons()
            k.ShowDialog()
            k.Dispose()
            LoadDataIntoComboBox("select salespersonname from salespersons where isactive=1", TxtSalesPerson, "salespersonname")
        End If
    End Sub


    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        If IsInvoiceSaved = False Then
            Dim k As DialogResult
            k = MsgBox("The Current Invoice is not saved, Do you want to save ?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.DefaultButton1)
            If k = MsgBoxResult.Yes Then
                CheckBeforeSave()
                If IsInvoiceSaved = False Then
                    Exit Sub
                End If
            ElseIf k = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If
        LoadDefaults()
        LoadStockEntryDefaults()
        TxtDate.Focus()
        IsInvoiceSaved = True
        IsInvoiceOpen = False

    End Sub

    Private Sub TxtArea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtArea.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim k As New CreateSalesPersons
            k.ShowDialog()
            k.Dispose()
            LoadDataIntoComboBox("select salespersonname from salespersons where isactive=1", TxtSalesPerson, "salespersonname")
            TxtSalesPerson.Focus()
        End If
    End Sub

    Private Sub TxtProject_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtProject.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            Dim PNAME As String = ""
            PNAME = InputBox("Enter the Project Name  :", "Project Name", "")
            If PNAME.Length > 0 Then
                If SQLIsFieldExists("select costname from CostCenterNames where costname=N'" & PNAME & "'") = False Then
                    If SQLIsFieldExists("select costname from CostCenterNames where costname=N'" & Replace(PNAME, " ", "") & "'") = False Then
                        Dim Sqlstr As String = ""
                        Sqlstr = "INSERT INTO [projecttable]([ProjectName] ,[CatName] ,[f1])  VALUES (N'" & PNAME & "','*Primary','')"
                        ExecuteSQLQuery(Sqlstr)

                        Sqlstr = "INSERT INTO [CostCenterNames]([CostName],[costgroup],[n1],[f1])     " _
                          & "VALUES(N'" & PNAME & "','*Primary',0,'Projects')"
                        ExecuteSQLQuery(Sqlstr)
                    End If
                End If
                LoadDataIntoComboBox("SELECT ProjectName   FROM projecttable", TxtProject, "ProjectName")
            End If
        End If
    End Sub

    Private Sub TxtDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDate.ValueChanged, TxtRefNo.TextChanged, TxtNetTotal.TextChanged, txtLedgerName.SelectedIndexChanged, TxtPriceLevel.SelectedIndexChanged, TxtArea.SelectedIndexChanged, TxtSalesPerson.SelectedIndexChanged, TxtProject.SelectedIndexChanged, TxtQutoNo.TextChanged, TxtDelivaryDate.ValueChanged
        IsInvoiceSaved = False
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click, EditToolStripMenuItem.Click
        If APPUserRights.IsAccessable = False Then
            MsgBox("The Edit  Restricted by the Admin, No possible to Edit ......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If IsInvoiceSaved = False Then
            Dim k As DialogResult
            k = MsgBox("The Current Invoice is not saved, Do you want to save ?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.DefaultButton1)
            If k = MsgBoxResult.Yes Then
                CheckBeforeSave()
                If IsInvoiceSaved = False Then
                    Exit Sub
                End If
            ElseIf k = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If

        Dim st As New ClsSelectInvDB
        st.SelectedTransCode = 0
        Select Case InvoiceCtrlType
            Case "SO"
                st.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesorder
            Case "SI"
                st.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesinvoice
            Case "SQ"
                st.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesquto
            Case "SR"
                st.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesReturns
            Case "SD"
                st.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesdelaverynote
            Case "POS"
                st.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesPOS
        End Select


        Dim editfrm As New ChooseInvoiceNumber(st, SalesTrancsationType, True)
        editfrm.ShowDialog()
        editfrm.Dispose()
        If st.SelectedTransCode = 0 Then
            st = Nothing
            Exit Sub
        Else

            LoadDefaults()
            TxtVoucherType.Enabled = False
            LoadStockEntryDefaults()
            LockTransaction(st.SelectedTransCode)
            OpenByTransCodeID(st.SelectedTransCode)
            OpenedLedgerName = txtLedgerName.Text
            LoadBill2BillReceipts()
            st = Nothing
        End If

    End Sub
    Public Sub OpenByTransCodeID(ByVal tcode As Single)
        OpenedTranscode = tcode
        IsOpendByWindows = True
        If IsOpendByWindows = True Then
            Select Case InvoiceCtrlType
                Case "SO"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "SalesOrder", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  SalesOrder  for TransCode: " & OpenedTranscode.ToString)
                Case "SI"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "Salesinvoice", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  Salesinvoice  for TransCode: " & OpenedTranscode.ToString)
                Case "SQ"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "SalesQuotation", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  SalesQuotation  for TransCode: " & OpenedTranscode.ToString)
                Case "SR"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "CreditNote", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  CreditNote  for TransCode: " & OpenedTranscode.ToString)
                Case "SD"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "SalesDeliveryNote", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  SalesDeliveryNote  for TransCode: " & OpenedTranscode.ToString)
                Case "POS"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "POS", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  POS  for TransCode: " & OpenedTranscode.ToString)
            End Select


        End If
        isopeningprocess = True
        Dim SqlConn As New SqlClient.SqlConnection
        'LOAD INVOICE DETAILS 
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from StockInvoiceDetails where transcode=" & OpenedTranscode
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                TxtDate.Value = CDate(Sreader("TRANSDATE"))
                TxtDelivaryDate.Value = CDate(Sreader("DelivaryDate"))
                TxtDiscount.Text = Sreader("DiscPer").ToString
                TxtTaxTotal.Text = Sreader("taxtotal").ToString.Trim
                TxtRefNo.Text = Sreader("QutoRef").ToString.Trim
                TxtQutoNo.Text = Sreader("QutoNo").ToString.Trim
                txtLedgerName.Text = Sreader("LEDGERNAME").ToString.Trim

                TxtGrossTotal.Text = Sreader("grosstotal").ToString.Trim
                TxtNetTotal.Text = Sreader("nettotal").ToString.Trim
                TxtDiscAmt.Text = Sreader("discountper").ToString.Trim
                TxtAmtInwords.Text = Sreader("amountinwords").ToString.Trim
                TxtNarration.Text = Sreader("narration").ToString.Trim
                TxtPriceLevel.Text = Sreader("PriceList").ToString.Trim
                TxtServiceTaxTotal.Text = Sreader("servicetaxtotal").ToString.Trim
                OpenedCurrencyRate = CDbl(Sreader("CurrencyCon1").ToString.Trim)
                TxtServiceAccountAmount.Text = Sreader("Additions")
                TxtDeductions.Text = Sreader("Deductions")
                TxtSalesLedger.Text = Sreader("AccountLedgerName").ToString.Trim
                TxtPaymentMethod.Text = Sreader("PaymentMethod")
                TxtPaymentBy.Text = Sreader("PaymentLedger")
                TxtPaymentDetails.Text = Sreader("PaymentDetails")
                TxtArea.Text = Sreader("AREA").ToString.Trim
                TxtSalesPerson.Text = Sreader("SalesPerson").ToString.Trim
                TxtProject.Text = Sreader("ProjectName").ToString.Trim
                TxtRoundoff = Sreader("RoundOff")
                TxtRateofExchange.Text = Sreader("CurrencyCon2").ToString.Trim
                TxtCurrency.Text = Sreader("BillCurrency").ToString
                TxtBillingCurrency.Text = TxtCurrency.Text
                TxtCouponName.Text = Sreader("CouponName").ToString
                TxtCouponDiscAmount.Max = Sreader("CDiscount")
                TxtCouponDiscAmount.Text = Sreader("CDiscount")
                TxtCouponPer.Text = Sreader("CDisCountPer")
                OpenedCouponDiscountAmount = Sreader("cdiscount")
                TxtAdvancePayment.Text = Sreader("AdvancePayment")
                Try
                    TxtVoucherType.Text = Sreader("VoucherType")
                Catch ex As Exception
                    TxtVoucherType.Text = "Tax Invoice"
                End Try
                If TxtVoucherType.Text.Length = 0 Then
                    TxtVoucherType.Text = "Tax Invoice"
                End If
                Try
                    Tax2TotalValue = Sreader("taxtotal2")
                Catch ex As Exception
                    Tax2TotalValue = 0
                End Try
                TxtToPrintName.Text = Sreader("customername").ToString
            End While

            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try


        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from StockInvoiceRowItems where transcode=" & OpenedTranscode & " order by sno"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            Dim i As Integer = 0
            While Sreader.Read()
                i = TxtList.Rows.Add()
                TxtList.Item("stsno", i).Value = i + 1
                TxtList.Item("stlocation", i).Value = Sreader("location").ToString.Trim
                TxtList.Item("stitemcode", i).Value = Sreader("StockCode").ToString.Trim
                TxtList.Item("stitemname", i).Value = Sreader("StockName").ToString.Trim
                TxtList.Item("stbarcode", i).Value = Sreader("Barcode").ToString.Trim
                TxtList.Item("stcustbarcode", i).Value = Sreader("CustBarcode").ToString.Trim
                TxtList.Item("stsize", i).Value = Sreader("StockSize").ToString.Trim
                TxtList.Item("stbatchno", i).Value = Sreader("BatchNo").ToString.Trim
                TxtList.Item("stexpiry", i).Value = Sreader("Expiry").ToString.Trim





                TxtList.Item("stqty", i).Value = Sreader("TotalQty")
                TxtList.Item("stqtytext", i).Value = Sreader("QtyText").ToString.Trim

                TxtList.Item("stfreeqty", i).Value = Sreader("FreeQty")
                TxtList.Item("stFreeQtyText", i).Value = Sreader("FreeQtyText").ToString.Trim


                TxtList.Item("STMQty", i).Value = Sreader("FreeMQty")
                TxtList.Item("StMQtyText", i).Value = Sreader("FreeMQtyText").ToString.Trim


                TxtList.Item("strate", i).Value = Sreader("StockRate")
                TxtList.Item("strateper", i).Value = Sreader("RatePer").ToString.Trim
                TxtList.Item("stdiscount", i).Value = Sreader("StockDisc")
                TxtList.Item("StStockTaxValue", i).Value = Sreader("netStockAmount")
                TxtList.Item("stmainunit", i).Value = Sreader("MainUnit").ToString.Trim
                TxtList.Item("stsubunit", i).Value = Sreader("SubUnit").ToString.Trim
                TxtList.Item("Sttax", i).Value = Sreader("Tax")
                TxtList.Item("Sttax2", i).Value = Sreader("Tax2")

                TxtList.Item("stnetrate", i).Value = Sreader("NetRate")
                TxtList.Item("stmadeby", i).Value = Sreader("origin").ToString.Trim
                TxtList.Item("sthscode", i).Value = Sreader("HScode").ToString.Trim
                TxtList.Item("TUTRANSCODE", i).Value = Sreader("Utranscode")
                TxtList.Item("tdisc2", i).Value = Sreader("disc2")
                TxtList.Item("stdiscamt1", i).Value = Sreader("DiscountAmount1")
                TxtList.Item("stdiscamt2", i).Value = Sreader("DiscountAmount2")
                TxtList.Item("stservicetax", i).Value = Sreader("Servicetax")
                TxtList.Item("stStockvalueWithOutTax", i).Value = Sreader("StockAmount")
                TxtList.Item("stmrp", i).Value = Sreader("mrp")
                TxtList.Item("stpacking", i).Value = Sreader("packing").ToString.Trim
                TxtList.Item("Sttaxamount", i).Value = Sreader("Taxamount")
                TxtList.Item("Sttaxamount2", i).Value = Sreader("Taxamount2")
                Try
                    TxtList.Item("stprate", i).Value = Sreader("PresetRate")
                Catch ex As Exception
                    TxtList.Item("stprate", i).Value = GetPresetCostofStockItem(Sreader("Barcode").ToString.Trim)
                End Try
                Try
                    TxtList.Item("stprofit", i).Value = Sreader("n1")
                Catch ex As Exception
                    TxtList.Item("stprofit", i).Value = 0
                End Try
                TxtList.Item("stconrate", i).Value = CDbl(TxtRateofExchange.Text)
                TxtList.Item("stslnos", i).Value = Sreader("slnos").ToString

                i = i + 1
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try
        OpenedInvoiceTotal = CDbl(TxtNetTotal.Text)


        'MORE ACCOUNT DETAILS
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from InvoiceMoreDet where transcode=" & OpenedTranscode
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                MoreDet.Despatchto = Sreader("Despatchto").ToString.Trim
                MoreDet.despatchaddress = Sreader("Despatchaddress").ToString.Trim
                MoreDet.despatchtaxdetails = Sreader("despatchtax").ToString.Trim
                MoreDet.DespatchThrough = Sreader("despatchthrough").ToString.Trim
                MoreDet.DespatchDestination = Sreader("DespatchDestination").ToString.Trim
                MoreDet.buyersname = Sreader("buyername").ToString.Trim
                MoreDet.buyeraddress = Sreader("buyeraddress").ToString.Trim
                MoreDet.buyertaxdetails = Sreader("buyertax").ToString.Trim
                MoreDet.paymentterm = Sreader("paymenterm").ToString.Trim
                MoreDet.otherreference = Sreader("otherref").ToString.Trim
                MoreDet.remarks = Sreader("remarks").ToString.Trim
                MoreDet.consgneename = Sreader("consgneename").ToString.Trim
                MoreDet.consgneeaddress = Sreader("consgneeaddress").ToString.Trim
                MoreDet.DelevaryTo = Sreader("delevaryto").ToString.Trim
                MoreDet.Delevarynoteno = Sreader("delevarynoteno").ToString.Trim
                MoreDet.orderno = Sreader("orderno").ToString.Trim
                MoreDet.delevarterms = Sreader("delevaryterm").ToString.Trim
                MoreDet.delevarytranscode = CDbl(Sreader("Transcode").ToString.Trim)
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try
        'If TxtDrCr1.Text.Length > 0 And TxtLedgerName1.Text.Length > 0 And CDbl(TxtLedgerAmount1.Text) Then
        '    SqlStr = "INSERT INTO [VoucherAccounts] ([AccountName],[Amount],[IsDrCr],[Transcode],[VoucherNo],[sno]) " _
        '    & " VALUES(N'" & TxtLedgerName1.Text & "'," & CDbl(TxtLedgerAmount1.Text) & "," & IIf(TxtDrCr1.Text = "Dr", 0, 1) & "," & tcode & ",N'" & TxtRefNo.Text & "',1)"
        '    ExecuteSQLQuery(SqlStr)

        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from VoucherAccounts where transcode=" & OpenedTranscode & " ORDER BY sno"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            Dim count As Integer = 1
            While Sreader.Read()
                If count = 1 Then
                    TxtLedgerName1.Text = Sreader("AccountName").ToString.Trim
                    TxtLedgerAmount1.Text = CDbl(Sreader("Amount").ToString.Trim)
                    TxtDrCr1.Text = IIf(CDbl(Sreader("IsDrCr").ToString.Trim) = 0, "Dr", "Cr")
                ElseIf count = 2 Then
                    TxtLedgerName2.Text = Sreader("AccountName").ToString.Trim
                    TxtLedgerAmount2.Text = CDbl(Sreader("Amount").ToString.Trim)
                    TxtDrCr2.Text = IIf(CDbl(Sreader("IsDrCr").ToString.Trim) = 0, "Dr", "Cr")
                Else
                    TxtLedgerName3.Text = Sreader("AccountName").ToString.Trim
                    TxtLedgerAmount3.Text = CDbl(Sreader("Amount").ToString.Trim)
                    TxtDrCr3.Text = IIf(CDbl(Sreader("IsDrCr").ToString.Trim) = 0, "Dr", "Cr")
                End If
                count = count + 1
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try

        OpenedTransList.ListofTrascodeadded.Rows.Clear()
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from UsedTranscodeList where transcode=" & OpenedTranscode
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                Dim K As Integer
                K = OpenedTransList.ListofTrascodeadded.Rows.Add
                OpenedTransList.ListofTrascodeadded.Item("transcode", K).Value = Sreader("UsedTranscode").ToString.Trim
                OpenedTransList.ListofTrascodeadded.Item("dbname", K).Value = Sreader("UsedDbName").ToString.Trim
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try

        Dim rno As Integer = 0
        CostList.Rows.Clear()
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from CostCenterBook where IsAdditional='False' and transcode=" & OpenedTranscode & " and ledgername=N'" & txtLedgerName.Text & "' order by sno"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                rno = CostList.Rows.Add()
                CostList.Item("tcostname", rno).Value = Sreader("CostCenterName").ToString.Trim
                CostList.Item("tcostcat", rno).Value = Sreader("costcat").ToString.Trim
                CostList.Item("tcostno", rno).Value = Sreader("costno").ToString.Trim
                CostList.Item("tamount", rno).Value = Sreader("dr") + Sreader("cr")
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try

        SqlConn.Dispose()


        OpenedPDCValues.IsPDC = False
        Try
            OpenedPDCValues.IsPDC = SQLGetStringFieldValue("select IsPostDated from ledgerbook where transcode=" & tcode, "IsPostDated")
            OpenedPDCValues.IsPDCClear = SQLGetStringFieldValue("select ClearPDC from ledgerbook where transcode=" & tcode, "ClearPDC")
            OpenedPDCValues.TodayDate.Value = SQLGetStringFieldValue("select Todaydate from ledgerbook where transcode=" & tcode, "Todaydate")
        Catch ex As Exception

        End Try

        If OpenedPDCValues.IsPDC = True Then
            PostDatedBox.Checked = True
        Else
            PostDatedBox.Checked = False
        End If
        FindTotalAmounts()
        LoadBill2BillReceipts()
        If InvoiceCtrlType = "SR" Then
            LoadBillWiseData(tcode)
        End If
        IsInvoiceSaved = True
        IsInvoiceOpen = True
        If SQLIsFieldExists("SELECT TOP 1 1 from   bill2bill where ledgername=N'" & txtLedgerName.Text & "' and refno=N'" & TxtRefNo.Text & "' and Billtype<>'New'") = True Then
            txtLedgerName.Enabled = False
            TxtRefNo.Enabled = False
        Else
            txtLedgerName.Enabled = True
            TxtRefNo.Enabled = True
        End If
        isopeningprocess = False
        TxtVoucherType.Enabled = False
    End Sub
    Sub LoadFromSalesQuto(ByVal tcode As Single)
        TxtVoucherType.Enabled = False
        If IsOpendByWindows = True Then

            Select Case InvoiceCtrlType

                Case "SO"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "SalesOrder", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  SalesOrder  for TransCode: " & OpenedTranscode.ToString)
                Case "SI"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "Salesinvoice", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  Salesinvoice  for TransCode: " & OpenedTranscode.ToString)
                Case "SQ"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "SalesQuotation", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  SalesQuotation  for TransCode: " & OpenedTranscode.ToString)
                Case "SR"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "CreditNote", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  CreditNote  for TransCode: " & OpenedTranscode.ToString)
                Case "SD"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "SalesDeliveryNote", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  SalesDeliveryNote  for TransCode: " & OpenedTranscode.ToString)
                Case "POS"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "POS", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  POS  for TransCode: " & OpenedTranscode.ToString)
            End Select
        End If
        isopeningprocess = True
        Dim Iszerovalue As Boolean = False
        Dim SqlConn As New SqlClient.SqlConnection
        'LOAD INVOICE DETAILS 
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from StockInvoiceDetails where transcode=" & tcode
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                TxtDiscount.Text = Sreader("DiscPer").ToString
                txtLedgerName.Text = Sreader("LEDGERNAME").ToString.Trim
                TxtArea.Text = Sreader("AREA").ToString.Trim
                TxtSalesPerson.Text = Sreader("SalesPerson").ToString.Trim
                TxtProject.Text = Sreader("ProjectName").ToString.Trim
                TxtGrossTotal.Text = Sreader("grosstotal")
                TxtNetTotal.Text = Sreader("nettotal")
                TxtDiscAmt.Text = Sreader("discountper")
                TxtAmtInwords.Text = Sreader("amountinwords").ToString.Trim
                TxtNarration.Text = Sreader("narration").ToString.Trim
                TxtPriceLevel.Text = Sreader("PriceList").ToString.Trim
                TxtCurrency.Text = Sreader("Currency").ToString.Trim
                TxtPaymentMethod.Text = Sreader("PaymentMethod").ToString.Trim
                TxtPaymentBy.Text = Sreader("PaymentLedger").ToString.Trim
                TxtPaymentDetails.Text = Sreader("PaymentDetails").ToString.Trim
                TxtSalesLedger.Text = Sreader("AccountLedgerName").ToString.Trim
                Try
                    Tax2TotalValue = Sreader("taxtotal2")
                Catch ex As Exception
                    Tax2TotalValue = 0
                End Try
                TxtVoucherType.Text = Sreader("VoucherType")
                If TxtVoucherType.Text.Length = 0 Then
                    TxtVoucherType.Text = "Tax Invoice"
                End If
                If TxtList.RowCount = 0 Then
                    TxtRateofExchange.Text = Sreader("CurrencyCon2").ToString.Trim
                    TxtCurrency.Text = Sreader("BillCurrency").ToString
                    TxtBillingCurrency.Text = TxtCurrency.Text
                End If
                TxtAdvancePayment.Text = Sreader("AdvancePayment")
                TxtToPrintName.Text = Sreader("customername").ToString
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from StockInvoiceRowItems where transcode=" & tcode & " order by sno"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            Dim i As Integer = 0
            While Sreader.Read()
                Dim k As Double = 0
                If IsDBNull(Sreader("usedqty")) = True Then
                    k = 0
                Else
                    k = Sreader("usedqty")

                End If
                If InvoiceCtrlType = "SD" Or InvoiceCtrlType = "POS" Then
                    If Sreader("TotalQty") >= k Then
                        i = TxtList.Rows.Add()

                        TxtList.Item("stsno", i).Value = i + 1
                        TxtList.Item("stlocation", i).Value = Sreader("location").ToString.Trim
                        TxtList.Item("stitemcode", i).Value = Sreader("StockCode").ToString.Trim
                        TxtList.Item("stitemname", i).Value = Sreader("StockName").ToString.Trim
                        TxtList.Item("stbarcode", i).Value = Sreader("Barcode").ToString.Trim
                        TxtList.Item("stcustbarcode", i).Value = Sreader("CustBarcode").ToString.Trim
                        TxtList.Item("stsize", i).Value = Sreader("StockSize").ToString.Trim
                        TxtList.Item("stbatchno", i).Value = Sreader("BatchNo").ToString.Trim
                        TxtList.Item("stexpiry", i).Value = Sreader("Expiry")

                        If MyAppSettings.IsAllowNegativeStock = True Then

                            TxtList.Item("stqty", i).Value = Sreader("TotalQty")
                            TxtList.Item("stqtytext", i).Value = Sreader("QtyText").ToString.Trim
                            TxtList.Item("stfreeqty", i).Value = Sreader("FreeQty")
                            TxtList.Item("stFreeQtyText", i).Value = Sreader("FreeQtyText").ToString.Trim
                            TxtList.Item("STMQty", i).Value = Sreader("FreeMQty")
                            TxtList.Item("StMQtyText", i).Value = Sreader("FreeMQtyText").ToString.Trim

                            TxtList.Item("StStockTaxValue", i).Value = Sreader("netStockAmount")
                            TxtList.Item("stStockvalueWithOutTax", i).Value = Sreader("StockAmount")
                        Else
                            If InvoiceCtrlType = "SD" Or InvoiceCtrlType = "SI" Or InvoiceCtrlType = "POS" Then
                                Dim presentstock As Double

                                presentstock = GetAvailableStockQty(Sreader("barcode").ToString.Trim, Sreader("location").ToString.Trim)
                                If presentstock < Sreader("totalqty") Then

                                    Dim qt As New IMSQtyBox
                                    qt.SetUnitName(Sreader("baseunit").ToString)
                                    If qt.IsSimpleUnit = True Then
                                        qt.TxtQty1.Text = presentstock
                                        qt.TxtQty2.Text = "0"
                                    Else
                                        qt.TxtQty1.Text = "0"
                                        qt.TxtQty2.Text = presentstock
                                    End If
                                    qt.CalculateValues()
                                    TxtList.Item("stqty", i).Value = qt.GetTotalQty
                                    TxtList.Item("stqtytext", i).Value = qt.GetTotalQtyText

                                    TxtList.Item("stfreeqty", i).Value = Sreader("FreeQty")
                                    TxtList.Item("stFreeQtyText", i).Value = Sreader("FreeQtyText").ToString.Trim
                                    TxtList.Item("STMQty", i).Value = Sreader("FreeMQty")
                                    TxtList.Item("StMQtyText", i).Value = Sreader("FreeMQtyText").ToString.Trim
                                    Dim TAMT As Double = 0
                                    TAMT = Sreader("StockRate")
                                    TAMT = TAMT - TAMT * Sreader("StockDisc") / 100
                                    TAMT = TAMT - TAMT * Sreader("disc2") / 100
                                    TAMT = TAMT * qt.GetTotalQty / qt.GetUnitConversion
                                    TxtList.Item("stStockvalueWithOutTax", i).Value = TAMT
                                    TxtList.Item("StStockTaxValue", i).Value = TAMT + TAMT * Sreader("Tax") / 100
                                    If qt.GetTotalQty() <= 0 Then
                                        Iszerovalue = True
                                    End If
                                Else
                                    TxtList.Item("stqty", i).Value = Sreader("TotalQty")
                                    TxtList.Item("stqtytext", i).Value = Sreader("QtyText").ToString.Trim
                                    TxtList.Item("stfreeqty", i).Value = Sreader("FreeQty")
                                    TxtList.Item("stFreeQtyText", i).Value = Sreader("FreeQtyText").ToString.Trim
                                    TxtList.Item("STMQty", i).Value = Sreader("FreeMQty")
                                    TxtList.Item("StMQtyText", i).Value = Sreader("FreeMQtyText").ToString.Trim

                                    TxtList.Item("StStockTaxValue", i).Value = Sreader("netStockAmount")
                                    TxtList.Item("stStockvalueWithOutTax", i).Value = Sreader("StockAmount")
                                End If
                            Else
                                TxtList.Item("stqty", i).Value = Sreader("TotalQty")
                                TxtList.Item("stqtytext", i).Value = Sreader("QtyText").ToString.Trim
                                TxtList.Item("stfreeqty", i).Value = Sreader("FreeQty")
                                TxtList.Item("stFreeQtyText", i).Value = Sreader("FreeQtyText").ToString.Trim
                                TxtList.Item("STMQty", i).Value = Sreader("FreeMQty")
                                TxtList.Item("StMQtyText", i).Value = Sreader("FreeMQtyText").ToString.Trim

                                TxtList.Item("StStockTaxValue", i).Value = Sreader("netStockAmount")
                                TxtList.Item("stStockvalueWithOutTax", i).Value = Sreader("StockAmount")
                            End If

                        End If

                        TxtList.Item("strate", i).Value = Sreader("StockRate")
                        TxtList.Item("strateper", i).Value = Sreader("RatePer").ToString.Trim
                        TxtList.Item("stdiscount", i).Value = Sreader("StockDisc")
                        TxtList.Item("tdisc2", i).Value = Sreader("disc2")
                        TxtList.Item("stdiscamt1", i).Value = Sreader("DiscountAmount1")
                        TxtList.Item("stdiscamt2", i).Value = Sreader("DiscountAmount2")
                        TxtList.Item("stmainunit", i).Value = Sreader("MainUnit").ToString.Trim
                        TxtList.Item("stsubunit", i).Value = Sreader("SubUnit").ToString.Trim
                        TxtList.Item("Sttax", i).Value = Sreader("Tax")
                        TxtList.Item("Sttaxamount", i).Value = Sreader("Taxamount")
                        TxtList.Item("Sttax2", i).Value = Sreader("Tax2")
                        TxtList.Item("Sttaxamount2", i).Value = Sreader("Taxamount2")
                        TxtList.Item("stnetrate", i).Value = Sreader("NetRate")
                        TxtList.Item("stmadeby", i).Value = Sreader("origin").ToString.Trim
                        TxtList.Item("sthscode", i).Value = Sreader("HScode").ToString.Trim
                        TxtList.Item("stmrp", i).Value = Sreader("mrp")
                        TxtList.Item("stpacking", i).Value = Sreader("packing").ToString.Trim
                        TxtList.Item("tUTranscode", i).Value = tcode
                        TxtList.Item("stconrate", i).Value = CDbl(TxtRateofExchange.Text)
                        TxtList.Item("stslnos", i).Value = Sreader("slnos").ToString
                        Try
                            TxtList.Item("stprate", i).Value = Sreader("PresetRate")
                        Catch ex As Exception
                            TxtList.Item("stprate", i).Value = GetPresetCostofStockItem(Sreader("Barcode").ToString.Trim)
                        End Try
                        If Iszerovalue = True Then
                            Iszerovalue = False
                            TxtList.Rows.RemoveAt(i)
                        Else
                            i = i + 1
                        End If
                    End If

                Else
                    i = TxtList.Rows.Add()

                    TxtList.Item("stsno", i).Value = i + 1
                    TxtList.Item("stlocation", i).Value = Sreader("location").ToString.Trim
                    TxtList.Item("stitemcode", i).Value = Sreader("StockCode").ToString.Trim
                    TxtList.Item("stitemname", i).Value = Sreader("StockName").ToString.Trim
                    TxtList.Item("stbarcode", i).Value = Sreader("Barcode").ToString.Trim
                    TxtList.Item("stcustbarcode", i).Value = Sreader("CustBarcode").ToString.Trim
                    TxtList.Item("stsize", i).Value = Sreader("StockSize").ToString.Trim
                    TxtList.Item("stbatchno", i).Value = Sreader("BatchNo").ToString.Trim
                    TxtList.Item("stexpiry", i).Value = Sreader("Expiry")

                    If MyAppSettings.IsAllowNegativeStock = True Then
                        TxtList.Item("stqty", i).Value = Sreader("TotalQty")
                        TxtList.Item("stqtytext", i).Value = Sreader("QtyText").ToString.Trim
                        TxtList.Item("stfreeqty", i).Value = Sreader("FreeQty")
                        TxtList.Item("stFreeQtyText", i).Value = Sreader("FreeQtyText").ToString.Trim
                        TxtList.Item("STMQty", i).Value = Sreader("FreeMQty")
                        TxtList.Item("StMQtyText", i).Value = Sreader("FreeMQtyText").ToString.Trim
                        TxtList.Item("StStockTaxValue", i).Value = Sreader("netStockAmount")
                        TxtList.Item("stStockvalueWithOutTax", i).Value = Sreader("StockAmount")
                    Else
                        If InvoiceCtrlType = "SD" Or InvoiceCtrlType = "SI" Or InvoiceCtrlType = "POS" Then
                            Dim presentstock As Double

                            presentstock = GetAvailableStockQty(Sreader("barcode").ToString.Trim, Sreader("location").ToString.Trim)
                            If presentstock < Sreader("totalqty") And SQLGetStringFieldValue("SELECT VOUCHERNAME FROM StockInvoiceDetails WHERE TRANSCODE=" & tcode, "VOUCHERNAME") <> "SD" Then

                                Dim qt As New IMSQtyBox
                                qt.SetUnitName(Sreader("baseunit").ToString)
                                If qt.IsSimpleUnit = True Then
                                    qt.TxtQty1.Text = presentstock
                                    qt.TxtQty2.Text = "0"
                                Else
                                    qt.TxtQty1.Text = "0"
                                    qt.TxtQty2.Text = presentstock
                                End If
                                qt.CalculateValues()
                                TxtList.Item("stqty", i).Value = qt.GetTotalQty
                                TxtList.Item("stqtytext", i).Value = qt.GetTotalQtyText

                                TxtList.Item("stfreeqty", i).Value = Sreader("FreeQty")
                                TxtList.Item("stFreeQtyText", i).Value = Sreader("FreeQtyText").ToString.Trim
                                TxtList.Item("STMQty", i).Value = Sreader("FreeMQty")
                                TxtList.Item("StMQtyText", i).Value = Sreader("FreeMQtyText").ToString.Trim

                                Dim TAMT As Double = 0
                                TAMT = Sreader("StockRate")
                                TAMT = TAMT - TAMT * Sreader("StockDisc") / 100
                                TAMT = TAMT - TAMT * Sreader("disc2") / 100
                                TAMT = TAMT * qt.GetTotalQty / qt.GetUnitConversion
                                TxtList.Item("stStockvalueWithOutTax", i).Value = TAMT
                                TxtList.Item("StStockTaxValue", i).Value = TAMT + TAMT * Sreader("Tax") / 100
                                If qt.GetTotalQty() <= 0 Then
                                    Iszerovalue = True
                                End If
                            Else
                                TxtList.Item("stqty", i).Value = Sreader("TotalQty")
                                TxtList.Item("stqtytext", i).Value = Sreader("QtyText").ToString.Trim
                                TxtList.Item("stfreeqty", i).Value = Sreader("FreeQty")
                                TxtList.Item("stFreeQtyText", i).Value = Sreader("FreeQtyText").ToString.Trim
                                TxtList.Item("STMQty", i).Value = Sreader("FreeMQty")
                                TxtList.Item("StMQtyText", i).Value = Sreader("FreeMQtyText").ToString.Trim
                                TxtList.Item("StStockTaxValue", i).Value = Sreader("netStockAmount")
                                TxtList.Item("stStockvalueWithOutTax", i).Value = Sreader("StockAmount")
                            End If
                        Else
                            TxtList.Item("stqty", i).Value = Sreader("TotalQty")
                            TxtList.Item("stqtytext", i).Value = Sreader("QtyText").ToString.Trim
                            TxtList.Item("stfreeqty", i).Value = Sreader("FreeQty")
                            TxtList.Item("stFreeQtyText", i).Value = Sreader("FreeQtyText").ToString.Trim
                            TxtList.Item("STMQty", i).Value = Sreader("FreeMQty")
                            TxtList.Item("StMQtyText", i).Value = Sreader("FreeMQtyText").ToString.Trim
                            TxtList.Item("StStockTaxValue", i).Value = Sreader("netStockAmount")
                            TxtList.Item("stStockvalueWithOutTax", i).Value = Sreader("StockAmount")
                        End If

                    End If

                    TxtList.Item("strate", i).Value = Sreader("StockRate")
                    TxtList.Item("strateper", i).Value = Sreader("RatePer").ToString.Trim
                    TxtList.Item("stdiscount", i).Value = Sreader("StockDisc")
                    TxtList.Item("tdisc2", i).Value = Sreader("disc2")
                    TxtList.Item("stdiscamt1", i).Value = Sreader("DiscountAmount1")
                    TxtList.Item("stdiscamt2", i).Value = Sreader("DiscountAmount2")
                    TxtList.Item("stmainunit", i).Value = Sreader("MainUnit").ToString.Trim
                    TxtList.Item("stsubunit", i).Value = Sreader("SubUnit").ToString.Trim
                    TxtList.Item("Sttax", i).Value = Sreader("Tax")
                    TxtList.Item("Sttaxamount", i).Value = Sreader("Taxamount")
                    TxtList.Item("Sttax2", i).Value = Sreader("Tax2")
                    TxtList.Item("Sttaxamount2", i).Value = Sreader("Taxamount2")
                    TxtList.Item("stnetrate", i).Value = Sreader("NetRate")
                    TxtList.Item("stmadeby", i).Value = Sreader("origin").ToString.Trim
                    TxtList.Item("sthscode", i).Value = Sreader("HScode").ToString.Trim
                    TxtList.Item("tUTranscode", i).Value = tcode
                    TxtList.Item("stmrp", i).Value = Sreader("mrp")
                    TxtList.Item("stpacking", i).Value = Sreader("packing").ToString.Trim
                    TxtList.Item("stconrate", i).Value = CDbl(TxtRateofExchange.Text)
                    TxtList.Item("stslnos", i).Value = Sreader("slnos").ToString
                    Try
                        TxtList.Item("stprate", i).Value = Sreader("PresetRate")
                    Catch ex As Exception
                        TxtList.Item("stprate", i).Value = GetPresetCostofStockItem(Sreader("Barcode").ToString.Trim)
                    End Try
                    If Iszerovalue = True Then
                        Iszerovalue = False
                        TxtList.Rows.RemoveAt(i)
                    Else
                        i = i + 1
                    End If
                End If

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try


        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from VoucherAccounts where transcode=" & tcode & " ORDER BY sno"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            Dim count As Integer = 1
            While Sreader.Read()
                If count = 1 Then
                    If CDbl(TxtLedgerAmount1.Text) = 0 Then
                        TxtLedgerName1.Text = Sreader("AccountName").ToString.Trim
                        TxtLedgerAmount1.Text = CDbl(Sreader("Amount").ToString.Trim)
                        TxtDrCr1.Text = IIf(CDbl(Sreader("IsDrCr").ToString.Trim) = 0, "Dr", "Cr")
                    ElseIf CDbl(TxtLedgerAmount2.Text) = 0 Then
                        TxtLedgerName2.Text = Sreader("AccountName").ToString.Trim
                        TxtLedgerAmount2.Text = CDbl(Sreader("Amount").ToString.Trim)
                        TxtDrCr2.Text = IIf(CDbl(Sreader("IsDrCr").ToString.Trim) = 0, "Dr", "Cr")
                    Else
                        TxtLedgerName3.Text = Sreader("AccountName").ToString.Trim
                        TxtLedgerAmount3.Text = CDbl(Sreader("Amount").ToString.Trim)
                        TxtDrCr3.Text = IIf(CDbl(Sreader("IsDrCr").ToString.Trim) = 0, "Dr", "Cr")
                    End If
                ElseIf count = 2 Then
                    If CDbl(TxtLedgerAmount1.Text) = 0 Then
                        TxtLedgerName1.Text = Sreader("AccountName").ToString.Trim
                        TxtLedgerAmount1.Text = CDbl(Sreader("Amount").ToString.Trim)
                        TxtDrCr1.Text = IIf(CDbl(Sreader("IsDrCr").ToString.Trim) = 0, "Dr", "Cr")
                    ElseIf CDbl(TxtLedgerAmount2.Text) = 0 Then
                        TxtLedgerName2.Text = Sreader("AccountName").ToString.Trim
                        TxtLedgerAmount2.Text = CDbl(Sreader("Amount").ToString.Trim)
                        TxtDrCr2.Text = IIf(CDbl(Sreader("IsDrCr").ToString.Trim) = 0, "Dr", "Cr")
                    Else
                        TxtLedgerName3.Text = Sreader("AccountName").ToString.Trim
                        TxtLedgerAmount3.Text = CDbl(Sreader("Amount").ToString.Trim)
                        TxtDrCr3.Text = IIf(CDbl(Sreader("IsDrCr").ToString.Trim) = 0, "Dr", "Cr")
                    End If
                Else
                    If CDbl(TxtLedgerAmount1.Text) = 0 Then
                        TxtLedgerName1.Text = Sreader("AccountName").ToString.Trim
                        TxtLedgerAmount1.Text = CDbl(Sreader("Amount").ToString.Trim)
                        TxtDrCr1.Text = IIf(CDbl(Sreader("IsDrCr").ToString.Trim) = 0, "Dr", "Cr")
                    ElseIf CDbl(TxtLedgerAmount2.Text) = 0 Then
                        TxtLedgerName2.Text = Sreader("AccountName").ToString.Trim
                        TxtLedgerAmount2.Text = CDbl(Sreader("Amount").ToString.Trim)
                        TxtDrCr2.Text = IIf(CDbl(Sreader("IsDrCr").ToString.Trim) = 0, "Dr", "Cr")
                    Else
                        TxtLedgerName3.Text = Sreader("AccountName").ToString.Trim
                        TxtLedgerAmount3.Text = CDbl(Sreader("Amount").ToString.Trim)
                        TxtDrCr3.Text = IIf(CDbl(Sreader("IsDrCr").ToString.Trim) = 0, "Dr", "Cr")
                    End If
                End If
                count = count + 1
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try
        SqlConn.Dispose()
        If InvoiceCtrlType = "SR" Then
            LoadBillWiseData(tcode)
        End If
        FindTotalAmounts()
        IsInvoiceSaved = False
        If TxtList.RowCount = 0 Then
            MsgBox("There is no available stock Items to Pull....", MsgBoxStyle.Information)
        End If
        isopeningprocess = False
    End Sub
    Sub CalculateTaxAmount()
        For i As Integer = 0 To TxtList.RowCount - 1
            TxtList.Item("sttaxamount", i).Value = CDbl(TxtList.Item("StStockTaxValue", i).Value) - (CDbl(TxtList.Item("StStockTaxValue", i).Value) * 100 / (CDbl(TxtList.Item("sttax", i).Value) + 100))
            TxtList.Item("sttaxamount2", i).Value = CDbl(TxtList.Item("StStockTaxValue", i).Value) - (CDbl(TxtList.Item("StStockTaxValue", i).Value) * 100 / (CDbl(TxtList.Item("sttax2", i).Value) + 100))
        Next
    End Sub
    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem.Click
        If APPUserRights.IsDeleteble = False Then
            MsgBox("The Delete Restricted by the Admin, No possible to Delete......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If IsTrailApplication = True Then
            MsgBox("Edit and Delete is not allowed in trail version....", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If SQLIsFieldExists("SELECT TOP 1 1 from   bill2bill where ledgername=N'" & txtLedgerName.Text & "' and refno=N'" & TxtRefNo.Text & "' and Billtype<>'New'") = True Then
            MsgBox("This Invoice is already used for Bill to Bill, Now it is not allowed to Delete", MsgBoxStyle.Information)
            Exit Sub
        End If
        If IsInvoiceOpen = True Then
            If MsgBox("Do you want to delete current Invoice ......?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                DeleteOpenedInvoice()
            End If
        End If
    End Sub
    Public Sub DeleteOpenedInvoice()
        If IsAuditConfirm(OpenedTranscode, "Inventory") = True Then
            MsgBox("The Selected Entry is already audited, not possible to delete....", MsgBoxStyle.Information)
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor

        Select Case InvoiceCtrlType

            Case "SO"

                UpdateLogFile(DefStoreName, OpenedTranscode, "SalesOrder", TxtQutoNo.Text, CurrentUserName, "Deleted", System.Environment.MachineName, "Deleted  SalesOrder  for TransCode: " & OpenedTranscode.ToString)
            Case "SI"
                UpdateLogFile(DefStoreName, OpenedTranscode, "Salesinvoice", TxtQutoNo.Text, CurrentUserName, "Deleted", System.Environment.MachineName, "Deleted  Salesinvoice  for TransCode: " & OpenedTranscode.ToString)
            Case "SQ"
                UpdateLogFile(DefStoreName, OpenedTranscode, "SalesQuotation", TxtQutoNo.Text, CurrentUserName, "Deleted", System.Environment.MachineName, "Deleted  SalesQuotation  for TransCode: " & OpenedTranscode.ToString)
            Case "SR"
                UpdateLogFile(DefStoreName, OpenedTranscode, "CreditNote", TxtQutoNo.Text, CurrentUserName, "Deleted", System.Environment.MachineName, "Deleted  CreditNote  for TransCode: " & OpenedTranscode.ToString)
            Case "SD"
                UpdateLogFile(DefStoreName, OpenedTranscode, "SalesDeliveryNote", TxtQutoNo.Text, CurrentUserName, "Deleted", System.Environment.MachineName, "Deleted  SalesDeliveryNote  for TransCode: " & OpenedTranscode.ToString)
            Case "POS"
                UpdateLogFile(DefStoreName, OpenedTranscode, "POS", TxtQutoNo.Text, CurrentUserName, "Deleted", System.Environment.MachineName, "Deleted  POS  for TransCode: " & OpenedTranscode.ToString)
        End Select
        ExecuteSQLQuery("update StockInvoiceDetails set isdelete=1 where transcode=" & OpenedTranscode)
        ExecuteSQLQuery("update StockInvoiceRowItems set isdelete=1 where transcode=" & OpenedTranscode)
        Select Case InvoiceCtrlType
            Case "SD", "SR", "POS"
                RollBackStockQuantities()

        End Select
        Select Case InvoiceCtrlType
            Case "SI", "SR", "POS"
                RollBackAccounts()
        End Select
        Select Case InvoiceCtrlType
            Case "SD", "POS"
                RollBackUpdatedOrdereditemsQtys()

        End Select
        'RELEASE PENDINGS ORDERS....
        For I As Integer = 0 To OpenedTransList.ListofTrascodeadded.Rows.Count - 1
            ExecuteSQLQuery("UPDATE StockInvoiceDetails SET ISPENDING=1 WHERE TRANSCODE=" & OpenedTransList.ListofTrascodeadded.Item("TRANSCODE", I).Value)
        Next
        ExecuteSQLQuery("delete from UsedTranscodeList where transcode=" & OpenedTranscode)

        ExecuteSQLQuery("delete from VoucherAccounts where transcode=" & OpenedTranscode)
        ExecuteSQLQuery("delete from InvoiceMoreDet where transcode=" & OpenedTranscode)
        ExecuteSQLQuery("DELETE FROM stockserialnos WHERE TRANSCODE=" & OpenedTranscode)

        ExecuteSQLQuery("delete from costcenterbook where TransCode=" & OpenedTranscode)
        ExecuteSQLQuery("delete from bill2bill where  transcode=" & OpenedTranscode)



        Try
            If IsReArrangeInvoiceNumberOnDelete = True Then
                Dim Invno As Long = 0
                Dim currentInvoiceNo As Long = 0
                Select Case InvoiceCtrlType
                    Case "SO"
                        currentInvoiceNo = CLng(GetInvVhNumber(InvoiceNoStrct.salesorder))

                    Case "SI"
                        currentInvoiceNo = CLng(GetInvVhNumber(InvoiceNoStrct.salesinvoice))

                    Case "SQ"
                        currentInvoiceNo = CLng(GetInvVhNumber(InvoiceNoStrct.salesquoto))

                    Case "SR"

                        If SalesTrancsationType.Length > 0 Then
                            If SalesTrancsationType = "Returns Form-8B" Then
                                currentInvoiceNo = CLng(GetInvVhNumber(InvoiceNoStrct.SRFORM8B))
                            ElseIf SalesTrancsationType = "Returns Form-8" Then
                                currentInvoiceNo = CLng(GetInvVhNumber(InvoiceNoStrct.SRFORM8))
                            Else
                                currentInvoiceNo = CLng(GetInvVhNumber(InvoiceNoStrct.SRFORM8D))
                            End If
                        Else
                            currentInvoiceNo = CLng(GetInvVhNumber(InvoiceNoStrct.SalesRetInvoice))
                        End If
                    Case "SD"
                        currentInvoiceNo = CLng(GetInvVhNumber(InvoiceNoStrct.salesdelavery))

                    Case "POS"
                        If SalesTrancsationType.Length > 0 Then
                            If SalesTrancsationType = "Cash Sales" Then
                                currentInvoiceNo = GetInvVhNumber(InvoiceNoStrct.CASHSALES)
                            ElseIf SalesTrancsationType = "Credit Sales" Then
                                currentInvoiceNo = GetInvVhNumber(InvoiceNoStrct.CREDITSALES)
                            ElseIf SalesTrancsationType = "Form-8" Then
                                currentInvoiceNo = GetInvVhNumber(InvoiceNoStrct.FORM8)
                            ElseIf SalesTrancsationType = "Form-8B" Then
                                currentInvoiceNo = GetInvVhNumber(InvoiceNoStrct.FORM8B)
                            ElseIf SalesTrancsationType = "Form-8D" Then
                                currentInvoiceNo = GetInvVhNumber(InvoiceNoStrct.FORM8D)
                            Else
                                currentInvoiceNo = GetInvVhNumber(InvoiceNoStrct.POS)
                            End If

                        Else
                            currentInvoiceNo = GetInvVhNumber(InvoiceNoStrct.POS)
                        End If


                End Select

                Try
                    Invno = CLng(TxtQutoNo.Text)
                    For i As Long = Invno To currentInvoiceNo
                        ExecuteSQLQuery("UPDATE StockInvoiceDetails SET QutoNo=N'" & i.ToString & "' WHERE QUTONO=N'" & (i + 1).ToString & "' AND VoucherName=N'" & InvoiceCtrlType & "' AND transtype=N'" & SalesTrancsationType & "'")
                    Next
                    currentInvoiceNo = currentInvoiceNo - 1
                    Select Case InvoiceCtrlType
                        Case "SO"
                            SetInvoiceNumber(InvoiceNoStrct.salesorder, currentInvoiceNo)
                        Case "SI"
                            SetInvoiceNumber(InvoiceNoStrct.salesinvoice, currentInvoiceNo)
                        Case "SQ"
                            SetInvoiceNumber(InvoiceNoStrct.salesquoto, currentInvoiceNo)
                        Case "SR"
                            If SalesTrancsationType.Length > 0 Then
                                If SalesTrancsationType = "Returns Form-8B" Then
                                    SetInvoiceNumber(InvoiceNoStrct.SRFORM8B, currentInvoiceNo)
                                ElseIf SalesTrancsationType = "Returns Form-8" Then
                                    SetInvoiceNumber(InvoiceNoStrct.SRFORM8, currentInvoiceNo)
                                Else
                                    SetInvoiceNumber(InvoiceNoStrct.SRFORM8D, currentInvoiceNo)
                                End If
                            Else
                                SetInvoiceNumber(InvoiceNoStrct.SalesRetInvoice, currentInvoiceNo)
                            End If

                        Case "SD"
                            SetInvoiceNumber(InvoiceNoStrct.salesdelavery, currentInvoiceNo)
                        Case "POS"
                            If SalesTrancsationType.Length > 0 Then
                                If SalesTrancsationType = "Cash Sales" Then
                                    SetInvoiceNumber(InvoiceNoStrct.CASHSALES, currentInvoiceNo)
                                ElseIf SalesTrancsationType = "Credit Sales" Then
                                    SetInvoiceNumber(InvoiceNoStrct.CREDITSALES, currentInvoiceNo)
                                ElseIf SalesTrancsationType = "Form-8" Then
                                    SetInvoiceNumber(InvoiceNoStrct.FORM8, currentInvoiceNo)
                                ElseIf SalesTrancsationType = "Form-8B" Then
                                    SetInvoiceNumber(InvoiceNoStrct.FORM8B, currentInvoiceNo)
                                ElseIf SalesTrancsationType = "Form-8D" Then
                                    SetInvoiceNumber(InvoiceNoStrct.FORM8D, currentInvoiceNo)
                                Else
                                    SetInvoiceNumber(InvoiceNoStrct.POS, currentInvoiceNo)
                                End If
                            Else
                                SetInvoiceNumber(InvoiceNoStrct.POS, currentInvoiceNo)
                            End If

                          

                    End Select
                Catch ex As Exception

                End Try
            End If
        Catch ex3 As Exception

        End Try


        LoadDefaults()
        LoadStockEntryDefaults()
        TxtDate.Focus()
        IsInvoiceSaved = True
        IsInvoiceOpen = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ImsButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMore.Click
        Dim Moredetfrm As New AddMoreDet(MoreDet)
        Moredetfrm.ShowDialog()
        Moredetfrm.Dispose()
        Me.SelectNextControl(Me, True, True, True, True)
        '    MsgBox(MoreDet.buyersname)
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPullData.Click
        If txtLedgerName.Text.Length = 0 Then
            MsgBox("Please Select Customer Name.....", MsgBoxStyle.Information)
            txtLedgerName.Focus()
            Exit Sub
        End If
        If TxtVoucherType.Text.Length = 0 Then
            MsgBox("Please Select the Tax Type       ", MsgBoxStyle.Information)
            TxtVoucherType.Focus()
            Exit Sub
        End If
        SelectedTransList.SelectedLedgerName = txtLedgerName.Text
        SelectedTransList.SelectedTransCode = 0
        SelectedTransList.ListofTrascodeadded.Rows.Clear()
        SelectedTransList.SelectedVoucherType = TxtVoucherType.Text
        Select Case InvoiceCtrlType
            Case "SO"
                SelectedTransList.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesorder
            Case "SI"
                SelectedTransList.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesinvoice
            Case "SQ"
                SelectedTransList.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesquto
            Case "SR"
                SelectedTransList.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesReturns
            Case "SD"
                SelectedTransList.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesdelaverynote
            Case "POS"
                SelectedTransList.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesPOS
        End Select


        Dim editfrm As New ChooseInvoiceByVoucherDetails(SelectedTransList)

        If txtLedgerName.Text.Length > 0 Then
            editfrm.TxtLedgerName.Text = txtLedgerName.Text
        End If
        editfrm.ShowDialog()
        editfrm.Dispose()
        If SelectedTransList.ListofTrascodeadded.Rows.Count = 0 Then
            Exit Sub
        Else
            IsValuesInBillingCurrency.Checked = False
            Dim isopentemp As Boolean
            isopentemp = IsInvoiceOpen
            If TxtList.RowCount = 0 Then
            ElseIf MsgBox("Do You want to merge the list with existing stock list ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
                TxtList.Rows.Clear()
            End If
            For i As Integer = 0 To SelectedTransList.ListofTrascodeadded.Rows.Count - 1
                If IsAllowDuplicateIvoiceItems = True Then
                    LoadFromSalesQuto(SelectedTransList.ListofTrascodeadded.Item("transcode", i).Value)
                Else
                    Dim found As Boolean = False
                    For k As Integer = 0 To CurrentTransList.ListofTrascodeadded.Rows.Count - 1
                        If CurrentTransList.ListofTrascodeadded.Item("transcode", k).Value = SelectedTransList.ListofTrascodeadded.Item("transcode", i).Value Then
                            found = True
                            Exit For
                        End If
                    Next
                    If found = False Then
                        LoadFromSalesQuto(SelectedTransList.ListofTrascodeadded.Item("transcode", i).Value)
                        Dim k As Integer
                        k = CurrentTransList.ListofTrascodeadded.Rows.Add
                        CurrentTransList.ListofTrascodeadded.Item("transcode", k).Value = SelectedTransList.ListofTrascodeadded.Item("transcode", i).Value
                        CurrentTransList.ListofTrascodeadded.Item("dbname", k).Value = SelectedTransList.ListofTrascodeadded.Item("dbname", i).Value
                    End If


                End If
            Next
            FindTotalAmounts()
            IsInvoiceOpen = isopentemp
        End If
        Me.SelectNextControl(Me, True, True, True, True)
    End Sub


    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        If IsInvoiceSaved = False Then
            Dim k As DialogResult
            k = MsgBox("The current Bill is not saved , Do you want to exit?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1)
            If k = DialogResult.No Then
                Exit Sub
            End If
        End If
        UnLockTransaction(OpenedTranscode)
        Try
            Me.Parent.Dispose()
        Catch ex As Exception

        End Try
        Me.Dispose(True)
    End Sub

    Private Sub TxtDrCr1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDrCr1.SelectedIndexChanged, TxtDrCr2.SelectedIndexChanged, TxtDrCr3.SelectedIndexChanged, TxtLedgerAmount1.TextChanged, TxtLedgerAmount2.TextChanged, TxtLedgerAmount3.TextChanged, TxtLedgerName1.SelectedIndexChanged, TxtLedgerName2.SelectedIndexChanged, TxtLedgerName3.SelectedIndexChanged
        On Error Resume Next

        AcountAmountCr = 0
        AcountAmountDr = 0
        If TxtDrCr1.Text.Length > 0 And TxtLedgerName1.Text.Length > 0 And CDbl(TxtLedgerAmount1.Text) Then
            If TxtDrCr1.Text = "Dr" Then
                AcountAmountDr = AcountAmountDr + CDbl(TxtLedgerAmount1.Text)
            Else
                AcountAmountCr = AcountAmountCr + CDbl(TxtLedgerAmount1.Text)
            End If
        End If
        If TxtDrCr2.Text.Length > 0 And TxtLedgerName2.Text.Length > 0 And CDbl(TxtLedgerAmount2.Text) Then
            If TxtDrCr2.Text = "Dr" Then
                AcountAmountDr = AcountAmountDr + CDbl(TxtLedgerAmount2.Text)
            Else
                AcountAmountCr = AcountAmountCr + CDbl(TxtLedgerAmount2.Text)
            End If
        End If
        If TxtDrCr3.Text.Length > 0 And TxtLedgerName3.Text.Length > 0 And CDbl(TxtLedgerAmount3.Text) Then
            If TxtDrCr3.Text = "Dr" Then
                AcountAmountDr = AcountAmountDr + CDbl(TxtLedgerAmount3.Text)
            Else
                AcountAmountCr = AcountAmountCr + CDbl(TxtLedgerAmount3.Text)
            End If
        End If
        TxtServiceAccountAmount.Text = FormatNumber(AcountAmountCr, ErpDecimalPlaces, , , TriState.False)
        TxtDeductions.Text = FormatNumber(AcountAmountDr * -1, ErpDecimalPlaces, , , TriState.False)
        FindTotalAmounts()
    End Sub




    Sub CheckBarcodeAndLoadData()
        If TxtBarCode.Text.Length = 0 Then Exit Sub
        TxtBarCode.Text = GetAlternativeBarcode(TxtBarCode.Text)
        LoadStockDataByBarCode(TxtBarCode.Text, GetLocation)
        If IsAddedByBarcode = True Then
            TxtBarCode.Focus()
        End If

    End Sub

    Private Sub TxtBarCode_LostFocus(sender As Object, e As System.EventArgs) Handles TxtBarCode.LostFocus
        CheckBarcodeAndLoadData()
    End Sub


    Sub LoadStockDataByBarCode(ByVal barcode As String, ByVal STOCKLOCATION As String)
        If TxtVoucherType.Text.Length = 0 Then
            MsgBox("Please select the Tax Type .. ", MsgBoxStyle.Information)
            TxtVoucherType.Focus()
            Exit Sub
        End If
        Dim SqlStrng As String = ""

        If SQLIsFieldExists("select stockcode from stockdbf where custbarcode=N'" & barcode & "' and location=N'" & STOCKLOCATION & "'") = False Then
            TxtBarCode.Text = ""

            TxtBarCode.Focus()
            Exit Sub
        End If

        If LoadStockItemsIntoClassByCustBarCode(barcode, STOCKLOCATION, NewAddItem) = False Then Exit Sub
        Dim CRate As Double = 1
        IsAddedByBarcode = True
        If IsValuesInBillingCurrency.Checked = True Then
            CRate = CDbl(TxtRateofExchange.Text)
        Else
            CRate = 1
        End If
        TxtStockDisc.Text = "0"
        TxtStockValue.Text = "0"
        TxtStockDiscount2.Text = "0"
        If TxtVoucherType.Text = "Tax Invoice" Then
            TxtStockTax2 = NewAddItem.Tax2
            TxtStockTax.Text = NewAddItem.Tax
        Else
            TxtStockTax2 = 0
            NewAddItem.Tax2 = 0
            TxtStockTax.Text = NewAddItem.CSTtax
        End If
        If IsZeroTax = True Then
            NewAddItem.Tax = 0
            NewAddItem.Tax2 = 0
            TxtStockTax.Text = "0"
            TxtStockTax2 = 0
        End If
        IsTaxInclude = NewAddItem.IsTaxInclude
        TxtStockCode.Text = NewAddItem.StockItemCode
        TxtStockName.Text = NewAddItem.StockItemName
        TxtMRP.Text = NewAddItem.MRP
        TxtStockSize.Text = NewAddItem.StockITemSize
        TxtStockQty.SetUnitName(NewAddItem.StockUnitName)
        TxtStockQty.ClearQty()
        TxtStockQty.TxtQty1.Text = "1"
        TxtStockFreeQty.SetUnitName(NewAddItem.StockUnitName)
        TxtStockFreeQty.ClearQty()
        TxtStockFreeQty.TxtQty1.Text = "0"
        TxtRatePer.Items.Clear()
        If NewAddItem.IsSimpleUnit = 1 Then
            TxtRatePer.Items.Add(NewAddItem.StockUnitName)
            TxtRatePer.Text = NewAddItem.StockUnitName
        Else
            TxtRatePer.Items.Add(NewAddItem.StockMainUnitName)
            TxtRatePer.Items.Add(NewAddItem.StockSubUnitName)
            TxtRatePer.Text = NewAddItem.StockMainUnitName
        End If
        'TxtStockRate.Text = GetStockRateByPriceListName(TxtPriceLevel.Text, NewAddItem.StockItemBarCode, NewAddItem.StockLocation) / CDbl(TxtRateofExchange.Text)
        If IsTaxInclude = True Then
            Dim NetRate As Double = 0
            NetRate = FormatNumber(GetStockRateByPriceListName(TxtPriceLevel.Text, NewAddItem.StockItemBarCode, NewAddItem.StockLocation) / CDbl(TxtRateofExchange.Text), 3, , , TriState.False)
            TxtStockRate.Text = FormatNumber(NetRate * 100 / (100 + CDbl(TxtStockTax.Text)), 3, , , TriState.False)
            TxtStockNetRate.Text = FormatNumber(NetRate, 3, , , TriState.False)
        Else
            If TxtPriceLevel.Text = "Custom" Then
                TxtStockRate.Text = FormatNumber(SQLGetNumericFieldValue("select top 1 stockrate from StockInvoiceRowItems where transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & txtLedgerName.Text & "') and stockcode=N'" & NewAddItem.StockItemCode & "' and stocksize=N'" & NewAddItem.StockITemSize & "' order by transdate desc ", "stockrate") / CDbl(TxtRateofExchange.Text), 3, , , TriState.False)
            Else
                TxtStockRate.Text = FormatNumber(GetStockRateByPriceListName(TxtPriceLevel.Text, NewAddItem.StockItemBarCode, NewAddItem.StockLocation) / CDbl(TxtRateofExchange.Text), 3, , , TriState.False)
            End If

        End If

        If CDbl(TxtStockRate.Text) = 0 Then
            TxtStockRate.Text = NewAddItem.StockWRPRate / CDbl(TxtRateofExchange.Text)
        End If

        IsBarcodeEntered = True
        TxtBatchNo.Enabled = False
        If NewAddItem.IsBatchNo = 1 Then
            If MyAppSettings.IsAllowEmptyBatchnoOnSales = True Then
                ' and totalqty>0
                LoadDataIntoComboBox("select batchno from stockbatch where stockcode=N'" & NewAddItem.StockItemCode & "' and stocksize=N'" & NewAddItem.StockITemSize & "' and location=N'" & NewAddItem.StockLocation & "'", TxtBatchNo, "batchno")
            Else

                LoadDataIntoComboBox("select batchno from stockbatch where stockcode=N'" & NewAddItem.StockItemCode & "' and stocksize=N'" & NewAddItem.StockITemSize & "' and location=N'" & NewAddItem.StockLocation & "' and totalqty>0", TxtBatchNo, "batchno")
            End If

            TxtBatchNo.Enabled = True
            TxtStockDisc.Text = "0"
            TxtStockValue.Text = "0"
            TxtStockCode.Text = NewAddItem.StockItemCode
            TxtStockName.Text = NewAddItem.StockItemName
            TxtStockSize.Text = NewAddItem.StockITemSize
            TxtStockTax.Text = NewAddItem.Tax
            IsTaxInclude = NewAddItem.IsTaxInclude
            TxtMRP.Text = NewAddItem.MRP
            If TxtVoucherType.Text = "Tax Invoice" Then
                TxtStockTax2 = NewAddItem.Tax2
                TxtStockTax.Text = NewAddItem.Tax
            Else
                NewAddItem.Tax = NewAddItem.CSTtax
                TxtStockTax.Text = NewAddItem.Tax
                NewAddItem.Tax2 = 0
                TxtStockTax2 = 0
            End If
            If IsZeroTax = True Then
                NewAddItem.Tax = 0
                NewAddItem.Tax2 = 0
                TxtStockTax.Text = "0"
                TxtStockTax2 = 0
            End If
            TxtStockQty.SetUnitName(NewAddItem.StockUnitName)
            TxtStockQty.ClearQty()
            TxtStockQty.TxtQty1.Text = "1"
            TxtStockFreeQty.SetUnitName(NewAddItem.StockUnitName)
            TxtStockFreeQty.ClearQty()
            TxtStockFreeQty.TxtQty1.Text = "0"
            TxtRatePer.Items.Clear()
            If NewAddItem.IsSimpleUnit = 1 Then
                TxtRatePer.Items.Add(NewAddItem.StockUnitName)
                TxtRatePer.Text = NewAddItem.StockUnitName
            Else
                TxtRatePer.Items.Add(NewAddItem.StockMainUnitName)
                TxtRatePer.Items.Add(NewAddItem.StockSubUnitName)
                TxtRatePer.Text = NewAddItem.StockMainUnitName
            End If
            ''
            ''
            ' TxtStockRate.Text = GetStockRateByPriceListName(TxtPriceLevel.Text, NewAddItem.StockItemBarCode, NewAddItem.StockLocation) / CDbl(TxtRateofExchange.Text)
            If IsTaxInclude = True Then
                Dim NetRate As Double = 0
                NetRate = FormatNumber(GetStockRateByPriceListName(TxtPriceLevel.Text, NewAddItem.StockItemBarCode, NewAddItem.StockLocation) / CDbl(TxtRateofExchange.Text), 3, , , TriState.False)
                TxtStockRate.Text = FormatNumber(NetRate * 100 / (100 + CDbl(TxtStockTax.Text)), 3, , , TriState.False)
                TxtStockNetRate.Text = FormatNumber(NetRate, 3, , , TriState.False)
            Else
                TxtStockRate.Text = FormatNumber(GetStockRateByPriceListName(TxtPriceLevel.Text, NewAddItem.StockItemBarCode, NewAddItem.StockLocation) / CDbl(TxtRateofExchange.Text), 3, , , TriState.False)
            End If

            If CDbl(TxtStockRate.Text) = 0 Then
                TxtStockRate.Text = NewAddItem.StockRRPRate / CDbl(TxtRateofExchange.Text)
            End If

            TxtBatchNo.Text = ""
            TxtBatchNo.Items.Clear()
            If NewAddItem.IsBatchNo = 1 Then
                If MyAppSettings.IsAllowEmptyBatchnoOnSales = True Then
                    ' and totalqty>0
                    LoadDataIntoComboBox("select batchno from stockbatch where stockcode=N'" & NewAddItem.StockItemCode & "' and stocksize=N'" & NewAddItem.StockITemSize & "' and location=N'" & NewAddItem.StockLocation & "'", TxtBatchNo, "batchno")
                Else
                    LoadDataIntoComboBox("select batchno from stockbatch where stockcode=N'" & NewAddItem.StockItemCode & "' and stocksize=N'" & NewAddItem.StockITemSize & "' and location=N'" & NewAddItem.StockLocation & "'  and totalqty>0", TxtBatchNo, "batchno")
                End If

                TxtBatchNo.Enabled = True
                Me.TableForItemRow.ColumnStyles.Item(4).Width = 80
                IsAddedByBarcode = False
                TxtBatchNo.Focus()
            Else
                TxtBatchNo.Enabled = False
                Me.TableForItemRow.ColumnStyles.Item(4).Width = 0
                IsAddedByBarcode = False
                TxtStockQty.Focus()
            End If
            'Me.TableForItemRow.ColumnStyles.Item(4).Width = 12.5
            'TxtBatchNo.Focus()
            'Me.TableForItemRow.ColumnStyles.Item(4).Width = 12.5
            'TxtBatchNo.Focus()
        Else
            If BarcodeSettingsVals.IsAutoFill = False Then
                TxtStockQty.Focus()
                Exit Sub
            End If
            If TxtVoucherType.Text = "Tax Invoice" Then
                TxtStockTax2 = NewAddItem.Tax2
                TxtStockTax.Text = NewAddItem.Tax
            Else
                NewAddItem.Tax = NewAddItem.CSTtax
                TxtStockTax.Text = NewAddItem.Tax
                NewAddItem.Tax2 = 0
                TxtStockTax2 = 0
            End If
            Dim nR As Integer
            TxtBatchNo.Text = ""
            nR = TxtList.Rows.Add()
            TxtList.Item("stsno", nR).Value = nR + 1
            TxtList.Item("stlocation", nR).Value = NewAddItem.StockLocationNames
            TxtList.Item("StItemcode", nR).Value = NewAddItem.StockItemCode
            TxtList.Item("Stitemname", nR).Value = NewAddItem.StockItemName
            TxtList.Item("Stbarcode", nR).Value = NewAddItem.StockItemBarCode
            TxtList.Item("Stsize", nR).Value = NewAddItem.StockITemSize
            TxtList.Item("Stbatchno", nR).Value = NewAddItem.StockBatchNo
            TxtList.Item("stcustbarcode", nR).Value = NewAddItem.CustBarCode
            TxtList.Item("stExpiry", nR).Value = NewAddItem.StockExpirydate




            TxtList.Item("stfreeqty", nR).Value = TxtStockFreeQty.GetTotalQty
            TxtList.Item("stfreeqtytext", nR).Value = TxtStockFreeQty.GetTotalQtyText

            TxtList.Item("stMqty", nR).Value = TxtStockQty.GetTotalQty
            TxtList.Item("stMqtytext", nR).Value = TxtStockQty.GetTotalQtyText

            TxtStockFreeQty.TxtQty1.Text = CDbl(TxtStockQty.TxtQty1.Text) + CDbl(TxtStockFreeQty.TxtQty1.Text)
            TxtStockFreeQty.TxtQty2.Text = CDbl(TxtStockQty.TxtQty2.Text) + CDbl(TxtStockFreeQty.TxtQty2.Text)
            TxtStockFreeQty.CalculateValues()

            TxtList.Item("stqty", nR).Value = TxtStockFreeQty.GetTotalQty
            TxtList.Item("stqtytext", nR).Value = TxtStockFreeQty.GetTotalQtyText

            If TxtRatePer.Text = TxtStockQty.GetSubUnit() Then
                Dim trate As Double
                trate = CDbl(TxtStockRate.Text) * CDbl(TxtRateofExchange.Text) / CRate * TxtStockQty.GetUnitConversion
                TxtList.Item("strate", nR).Value = trate
                TxtList.Item("strateper", nR).Value = TxtStockQty.GetMainUnit
                trate = trate - trate * CDbl(TxtStockDisc.Text) / 100
                trate = trate - CDbl(TxtStockDiscount2.Text)
                TxtList.Item("stStockvalueWithOutTax", nR).Value = trate * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                TxtList.Item("sttaxamount", nR).Value = trate * CDbl(TxtStockTax.Text) / 100 * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                If MyAppSettings.IsAllowMultiTaxRatesOnSales = False Then
                    TxtList.Item("sttaxamount2", nR).Value = 0
                Else
                    TxtList.Item("sttaxamount2", nR).Value = trate * NewAddItem.Tax2 / 100 * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                End If
                trate = trate + trate * CDbl(TxtStockTax.Text) / 100
                TxtList.Item("stnetrate", nR).Value = trate
                TxtStockValue.Text = trate
            Else
                Dim trate As Double
                trate = CDbl(TxtStockRate.Text) * CDbl(TxtRateofExchange.Text) / CRate
                TxtList.Item("strate", nR).Value = trate
                TxtList.Item("strateper", nR).Value = TxtStockQty.GetMainUnit
                trate = trate - trate * CDbl(TxtStockDisc.Text) / 100
                trate = trate - CDbl(TxtStockDiscount2.Text)

                TxtList.Item("stStockvalueWithOutTax", nR).Value = trate * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                TxtList.Item("sttaxamount", nR).Value = trate * CDbl(TxtStockTax.Text) / 100 * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                If MyAppSettings.IsAllowMultiTaxRatesOnSales = False Then
                    TxtList.Item("sttaxamount2", nR).Value = 0
                Else
                    TxtList.Item("sttaxamount2", nR).Value = trate * NewAddItem.Tax2 / 100 * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
                End If
                trate = trate + trate * CDbl(TxtStockTax.Text) / 100
                TxtList.Item("stnetrate", nR).Value = trate
                TxtStockValue.Text = trate
            End If

            TxtList.Item("stdiscount", nR).Value = TxtStockDisc.Text
            TxtList.Item("tdisc2", nR).Value = TxtStockDiscount2.Text
            TxtList.Item("stdiscamt1", nR).Value = CDbl(TxtStockDisc.Text) * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
            TxtList.Item("stdiscamt2", nR).Value = CDbl(TxtStockDiscount2.Text) * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)

            TxtList.Item("StStockTaxValue", nR).Value = CDbl(TxtStockValue.Text) * CDbl(TxtRateofExchange.Text) / CRate
            TxtList.Item("stmainunit", nR).Value = TxtStockQty.GetMainUnit
            TxtList.Item("stsubunit", nR).Value = TxtStockQty.GetSubUnit
            TxtList.Item("sthscode", nR).Value = NewAddItem.HScode
            TxtList.Item("stmadeby", nR).Value = NewAddItem.Madeby
            TxtList.Item("sttax", nR).Value = TxtStockTax.Text
            If MyAppSettings.IsAllowMultiTaxRatesOnSales = False Then
                TxtList.Item("sttax2", nR).Value = 0

            Else
                TxtList.Item("sttax2", nR).Value = NewAddItem.Tax2
            End If
            TxtList.Item("tutranscode", nR).Value = 0
            TxtList.Item("stservicetax", nR).Value = NewAddItem.ServiceTax
            TxtList.Item("stprate", nR).Value = GetPresetCostofStockItem(NewAddItem.StockItemBarCode)
            TxtList.Item("stmrp", nR).Value = NewAddItem.MRP
            TxtList.Item("stconrate", nR).Value = CDbl(TxtRateofExchange.Text) / CRate
            TxtList.Item("stslnos", nR).Value = ""
            TxtBatchNo.Enabled = False
            Me.TableForItemRow.ColumnStyles.Item(4).Width = 0
            TxtBarCode.Focus()
            LoadStockEntryDefaults()
            FindTotalAmounts()
            TxtBarCode.Focus()
            IsInvoiceSaved = False
        End If








    End Sub



    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, PrintToolStripMenuItem.Click
        If CDbl(TxtGrossTotal.Text) <= 0 Then Exit Sub
        If IsInvoiceSaved = False Then
            If MsgBox("The Current Invoice is Not Save, Do You want to save ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                CheckBeforeSave()
                If IsInvoiceSaved = False Then
                    Exit Sub
                End If
            End If
        End If
        If IsInvoiceOpen = True Then
            PrintInvoice()
        Else
            MsgBox("Please Make an invoice or open the existing one....")
        End If
       
    End Sub
    Sub PrintInvoice()
        If InvoiceCtrlType = "SI" Or InvoiceCtrlType = "POS" Or InvoiceCtrlType = "SR" Then
            If SQLIsFieldExists("SELECT LEDGERNAME FROM LEDGERS WHERE LEDGERNAME=N'" & txtLedgerName.Text & "' AND ISSENDEMAIL='True'") = True Then
                If MsgBox("Do you want to Send Email to the Customer?    ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    Dim TempStr As New TextBox
                    TempStr.Multiline = True
                    If InvoiceCtrlType = "SI" Or InvoiceCtrlType = "POS" Then
                        TempStr.Text = SQLGetStringFieldValue(" select msgtext from smsmailsettings where vouchername='SALES'  and IsEmail='True' ", "msgtext")
                    ElseIf InvoiceCtrlType = "SR" Then
                        TempStr.Text = SQLGetStringFieldValue(" select msgtext from smsmailsettings where vouchername='SALES RETURNS'  and IsEmail='True' ", "msgtext")
                    End If
                    TempStr.Text = TempStr.Text.Replace("@TODAYDATE@", Today)
                    TempStr.Text = TempStr.Text.Replace("@INVOICENO@", TxtQutoNo.Text)
                    TempStr.Text = TempStr.Text.Replace("@INVOICEDATE@", TxtDate.Value)
                    TempStr.Text = TempStr.Text.Replace("@PARTYNAME@", txtLedgerName.Text)
                    TempStr.Text = TempStr.Text.Replace("@CURRENTAMOUNT@", TxtNetTotal.Text)
                    TempStr.Text = TempStr.Text.Replace("@INVOICEBALANCE@", TxtNetTotal.Text)
                    TempStr.Text = TempStr.Text.Replace("@PAYMENTBY@", TxtPaymentBy.Text)
                    TempStr.Text = TempStr.Text.Replace("@BALANCE@", GetCurrentBalanceText(txtLedgerName.Text))

                    If SQLIsFieldExists("SELECT TOP 1 1 from   smsmailsettings WHERE  isattachfile='True' ") = True Then
                        PrintingInvoice(True, TempStr.Text, True, Path.GetTempPath() & txtLedgerName.Text & "-InvNo " & TxtQutoNo.Text & "." & My.Settings.filetypetoexport)
                    Else
                        PrintingInvoice(True, TempStr.Text, False, Path.GetTempPath() & txtLedgerName.Text & "-InvNo" & TxtQutoNo.Text & "." & My.Settings.filetypetoexport)
                    End If

                Else
                    PrintingInvoice()
                End If
            Else
                PrintingInvoice()
            End If
        Else
            PrintingInvoice()
        End If



    End Sub
    Sub PrintingInvoice(Optional ByVal IsSendEmail As Boolean = False, Optional ByVal sentmessage As String = "", Optional ByVal issendtofile As Boolean = False, Optional ByVal printfilename As String = "")

        SelectedVoucherType = InvoiceType
        Dim pvalues As New PrintParameters
        Select Case InvoiceCtrlType
            Case "SO"
                pvalues.VouhcerName = PrintVoucherNames.salesorder
            Case "SI"
                pvalues.VouhcerName = PrintVoucherNames.salesinvoice
            Case "SQ"
                pvalues.VouhcerName = PrintVoucherNames.salesquote
            Case "SR"
                If SalesTrancsationType.Length > 0 Then
                    If SalesTrancsationType = "Returns Form-8" Then
                        pvalues.VouhcerName = PrintVoucherNames.SRForm8
                    ElseIf SalesTrancsationType = "Returns Form-8B" Then
                        pvalues.VouhcerName = PrintVoucherNames.SRForm8b
                    ElseIf SalesTrancsationType = "Returns Cash Sales" Then
                        pvalues.VouhcerName = PrintVoucherNames.SRform8D

                    End If
                Else
                    pvalues.VouhcerName = PrintVoucherNames.salesreturns
                End If

            Case "SD"
                pvalues.VouhcerName = PrintVoucherNames.salesdelivery
            Case "POS"
                If SalesTrancsationType.Length > 0 Then
                    If SalesTrancsationType = "Cash Sales" Then
                        pvalues.VouhcerName = PrintVoucherNames.cashsales
                    ElseIf SalesTrancsationType = "Credit Sales" Then
                        pvalues.VouhcerName = PrintVoucherNames.creditsales
                    ElseIf SalesTrancsationType = "Cash Sales" Then
                        pvalues.VouhcerName = PrintVoucherNames.salespos
                    ElseIf SalesTrancsationType = "Form-8" Then
                        pvalues.VouhcerName = PrintVoucherNames.Form8
                    ElseIf SalesTrancsationType = "Form-8B" Then
                        pvalues.VouhcerName = PrintVoucherNames.Form8b
                    ElseIf SalesTrancsationType = "Form-8D" Then
                        pvalues.VouhcerName = PrintVoucherNames.form8D
                    End If
                Else
                    pvalues.VouhcerName = PrintVoucherNames.salespos
                End If

        End Select

        If MyAppSettings.IsCustomCrReportForInvoices = True Then
            Dim printk As New PrintDlg(pvalues)
            printk.UserLabel3.Visible = False
            printk.TxtSelectedSchemeName.Visible = False
            If printk.ShowDialog = DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                Dim ds As New InvoiceReportDataSet
                Dim cnn As SqlConnection
                cnn = New SqlConnection(ConnectionStrinG)
                cnn.Open()
                Dim dscmd As New SqlDataAdapter("select * from StockInvoiceDetails where transcode=" & OpenedTranscode, cnn)
                dscmd.Fill(ds, "StockInvoiceDetails")
                Dim dscmd2 As New SqlDataAdapter("select * from StockInvoiceRowItems where transcode=" & OpenedTranscode & " order by sno", cnn)
                dscmd2.Fill(ds, "StockInvoiceRowItems")

                Dim dscmd3 As New SqlDataAdapter("select * from ledgers where ledgername=N'" & SQLGetStringFieldValue("select ledgername from StockInvoiceDetails where transcode=" & OpenedTranscode, "ledgername") & "'", cnn)
                dscmd3.Fill(ds, "ledgers")
                'ledgers

                cnn.Close()
                If InvoiceCtrlType = "SI" Or InvoiceCtrlType = "POS" Then
                    If TxtVoucherType.Text = "Tax Invoice" Then
                        Dim objRpt As New Invoice_1
                        CType(objRpt.Section2.ReportObjects.Item("TxtTinNo"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = CompDetails.Companytaxregno
                        CType(objRpt.Section2.ReportObjects.Item("TxtCSTNo"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = CompDetails.CSTNo
                        CType(objRpt.Section2.ReportObjects.Item("TxtCreditCash"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtPaymentMethod.Text

                        CType(objRpt.Section5.ReportObjects.Item("TxtCompanyName"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "For, " & CompDetails.CompanyName

                        objRpt.SetDataSource(ds)

                        If pvalues.IsPrintToPrinter = True Then
                            objRpt.PrintToPrinter(1, False, 1, 20)
                        Else
                            Dim FRM As New ReportCommonForm(objRpt)
                            FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                            Me.Cursor = Cursors.Default
                            FRM.ShowDialog()
                            FRM.Dispose()
                            objRpt.Dispose()
                            ds.Dispose()
                        End If
                        If IsSendEmail = True Then
                            If issendtofile = True Then
                                objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, printfilename)
                                SendCustomEmailTo(SQLGetStringFieldValue("SELECT emailid FROM LEDGERS WHERE LEDGERNAME=N'" & txtLedgerName.Text & "'", "emailid"), SQLGetStringFieldValue(" select mailSubject from smsmailsettings where vouchername='SALES'  and IsEmail='True' ", "mailSubject"), sentmessage, printfilename)
                            Else
                                SendCustomEmailTo(SQLGetStringFieldValue("SELECT emailid FROM LEDGERS WHERE LEDGERNAME=N'" & txtLedgerName.Text & "'", "emailid"), SQLGetStringFieldValue(" select mailSubject from smsmailsettings where vouchername='SALES'  and IsEmail='True' ", "mailSubject"), sentmessage, "")
                            End If
                        End If
                    Else
                        Dim objRpt As New CSTInvoiceCRReport
                        CType(objRpt.Section2.ReportObjects.Item("TxtTinNo"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = CompDetails.Companytaxregno
                        CType(objRpt.Section2.ReportObjects.Item("TxtCSTNo"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = CompDetails.CSTNo
                        CType(objRpt.Section2.ReportObjects.Item("TxtCreditCash"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtPaymentMethod.Text

                        CType(objRpt.Section5.ReportObjects.Item("TxtCompanyName"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "For, " & CompDetails.CompanyName

                        objRpt.SetDataSource(ds)

                        If pvalues.IsPrintToPrinter = True Then
                            objRpt.PrintToPrinter(1, False, 1, 20)
                        Else
                            Dim FRM As New ReportCommonForm(objRpt)
                            FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                            Me.Cursor = Cursors.Default
                            FRM.ShowDialog()
                            FRM.Dispose()
                            objRpt.Dispose()
                            ds.Dispose()
                        End If
                        If IsSendEmail = True Then
                            If issendtofile = True Then
                                objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, printfilename)
                                SendCustomEmailTo(SQLGetStringFieldValue("SELECT emailid FROM LEDGERS WHERE LEDGERNAME=N'" & txtLedgerName.Text & "'", "emailid"), SQLGetStringFieldValue(" select mailSubject from smsmailsettings where vouchername='SALES'  and IsEmail='True' ", "mailSubject"), sentmessage, printfilename)
                            Else
                                SendCustomEmailTo(SQLGetStringFieldValue("SELECT emailid FROM LEDGERS WHERE LEDGERNAME=N'" & txtLedgerName.Text & "'", "emailid"), SQLGetStringFieldValue(" select mailSubject from smsmailsettings where vouchername='SALES'  and IsEmail='True' ", "mailSubject"), sentmessage, "")
                            End If
                        End If
                    End If
                ElseIf InvoiceCtrlType = "SD" Then
                    Dim objRpt As New DeliveryNoteInvoiceCRReprot
                    CType(objRpt.Section2.ReportObjects.Item("TxtTinNo"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = CompDetails.Companytaxregno
                    CType(objRpt.Section2.ReportObjects.Item("TxtCSTNo"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = CompDetails.CSTNo
                    '  CType(objRpt.Section2.ReportObjects.Item("TxtCreditCash"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtPaymentMethod.Text

                    CType(objRpt.Section5.ReportObjects.Item("TxtCompanyName"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "For, " & CompDetails.CompanyName

                    objRpt.SetDataSource(ds)

                    If pvalues.IsPrintToPrinter = True Then
                        objRpt.PrintToPrinter(1, False, 1, 20)
                    Else
                        Dim FRM As New ReportCommonForm(objRpt)
                        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        Me.Cursor = Cursors.Default
                        FRM.ShowDialog()
                        FRM.Dispose()
                        objRpt.Dispose()
                        ds.Dispose()
                    End If
                    If IsSendEmail = True Then
                        If issendtofile = True Then
                            objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, printfilename)
                            SendCustomEmailTo(SQLGetStringFieldValue("SELECT emailid FROM LEDGERS WHERE LEDGERNAME=N'" & txtLedgerName.Text & "'", "emailid"), SQLGetStringFieldValue(" select mailSubject from smsmailsettings where vouchername='SALES'  and IsEmail='True' ", "mailSubject"), sentmessage, printfilename)
                        Else
                            SendCustomEmailTo(SQLGetStringFieldValue("SELECT emailid FROM LEDGERS WHERE LEDGERNAME=N'" & txtLedgerName.Text & "'", "emailid"), SQLGetStringFieldValue(" select mailSubject from smsmailsettings where vouchername='SALES'  and IsEmail='True' ", "mailSubject"), sentmessage, "")
                        End If
                    End If
                ElseIf InvoiceCtrlType = "SQ" Then
                    If TxtVoucherType.Text = "Tax Invoice" Then
                        Dim objRpt As New InoviceForQutoVAT
                        CType(objRpt.Section2.ReportObjects.Item("TxtTinNo"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = CompDetails.Companytaxregno
                        CType(objRpt.Section2.ReportObjects.Item("TxtCSTNo"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = CompDetails.CSTNo
                        '  CType(objRpt.Section2.ReportObjects.Item("TxtCreditCash"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtPaymentMethod.Text

                        CType(objRpt.Section5.ReportObjects.Item("TxtCompanyName"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "For, " & CompDetails.CompanyName

                        objRpt.SetDataSource(ds)

                        If pvalues.IsPrintToPrinter = True Then
                            objRpt.PrintToPrinter(1, False, 1, 20)
                        Else
                            Dim FRM As New ReportCommonForm(objRpt)
                            FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                            Me.Cursor = Cursors.Default
                            FRM.ShowDialog()
                            FRM.Dispose()
                            objRpt.Dispose()
                            ds.Dispose()
                        End If
                        If IsSendEmail = True Then
                            If issendtofile = True Then
                                objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, printfilename)
                                SendCustomEmailTo(SQLGetStringFieldValue("SELECT emailid FROM LEDGERS WHERE LEDGERNAME=N'" & txtLedgerName.Text & "'", "emailid"), SQLGetStringFieldValue(" select mailSubject from smsmailsettings where vouchername='SALES'  and IsEmail='True' ", "mailSubject"), sentmessage, printfilename)
                            Else
                                SendCustomEmailTo(SQLGetStringFieldValue("SELECT emailid FROM LEDGERS WHERE LEDGERNAME=N'" & txtLedgerName.Text & "'", "emailid"), SQLGetStringFieldValue(" select mailSubject from smsmailsettings where vouchername='SALES'  and IsEmail='True' ", "mailSubject"), sentmessage, "")
                            End If
                        End If
                    Else
                        Dim objRpt As New CSTInvoiceCRReportForQuto
                        CType(objRpt.Section2.ReportObjects.Item("TxtTinNo"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = CompDetails.Companytaxregno
                        CType(objRpt.Section2.ReportObjects.Item("TxtCSTNo"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = CompDetails.CSTNo
                        '  CType(objRpt.Section2.ReportObjects.Item("TxtCreditCash"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtPaymentMethod.Text

                        CType(objRpt.Section5.ReportObjects.Item("TxtCompanyName"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "For, " & CompDetails.CompanyName

                        objRpt.SetDataSource(ds)

                        If pvalues.IsPrintToPrinter = True Then
                            objRpt.PrintToPrinter(1, False, 1, 20)
                        Else
                            Dim FRM As New ReportCommonForm(objRpt)
                            FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                            Me.Cursor = Cursors.Default
                            FRM.ShowDialog()
                            FRM.Dispose()
                            objRpt.Dispose()
                            ds.Dispose()
                        End If
                        If IsSendEmail = True Then
                            If issendtofile = True Then
                                objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, printfilename)
                                SendCustomEmailTo(SQLGetStringFieldValue("SELECT emailid FROM LEDGERS WHERE LEDGERNAME=N'" & txtLedgerName.Text & "'", "emailid"), SQLGetStringFieldValue(" select mailSubject from smsmailsettings where vouchername='SALES'  and IsEmail='True' ", "mailSubject"), sentmessage, printfilename)
                            Else
                                SendCustomEmailTo(SQLGetStringFieldValue("SELECT emailid FROM LEDGERS WHERE LEDGERNAME=N'" & txtLedgerName.Text & "'", "emailid"), SQLGetStringFieldValue(" select mailSubject from smsmailsettings where vouchername='SALES'  and IsEmail='True' ", "mailSubject"), sentmessage, "")
                            End If
                        End If
                    End If

                End If

                Me.Cursor = Cursors.Default

            End If
        Else
            Dim printk As New PrintDlg(pvalues)
            printk.TxtDuplicateInvoice.Checked = True
            If printk.ShowDialog = DialogResult.OK Then
                PrintingScheme = pvalues.schemename
                Dim ppd As New PrintPreviewDialog()

                PrtDoc.PrinterSettings.PrinterName = pvalues.PrinterName

                ppd.Document = PrtDoc

                If pvalues.IsPrintToPrinter = True Then
                    If pvalues.IsPrintDuplicateInvoice = True Then
                        If pvalues.NoofCopies = 1 Then
                            PrtDoc.PrinterSettings.Copies = 1
                            PrtDoc.PrinterSettings.PrinterName = pvalues.PrinterName
                            PrtDoc.Print()

                        Else
                            PrtDoc.PrinterSettings.PrinterName = pvalues.PrinterName
                            IsPrintDuplicateInvoice = True
                            PrintInvoicecopyno = pvalues.NoofCopies
                            ppd.Document = PrtDoc
                          
                            For i As Integer = 1 To pvalues.NoofCopies
                                PrtDoc.Print()
                            Next

                        End If
                    Else
                        If pvalues.NoofCopies <= 0 Then
                            pvalues.NoofCopies = 1
                        End If
                        PrtDoc.PrinterSettings.PrinterName = pvalues.PrinterName
                       
                        For i As Integer = 1 To pvalues.NoofCopies
                            PrtDoc.Print()
                        Next
                    End If
                    If issendtofile = True Then
                        PrtDoc.PrinterSettings.PrintFileName = printfilename
                        PrtDoc.PrinterSettings.PrintToFile = True
                        PrtDoc.PrinterSettings.PrinterName = My.Settings.printernametoexport
                        PrtDoc.Print()
                    End If
                ElseIf pvalues.IsPrintToPrinter = False Then
                    PrtDoc.PrinterSettings.PrinterName = pvalues.PrinterName
                    PrtDoc.PrinterSettings.Copies = pvalues.NoofCopies
                    PrtDoc.PrinterSettings.PrinterName = pvalues.PrinterName
                    Try

                        ppd.ShowDialog()
                    Catch ex As Exception
                        PrtDoc.PrinterSettings.PrinterName = pvalues.PrinterName
                        ppd.ShowDialog()
                    End Try
                    If issendtofile = True Then
                        PrtDoc.PrinterSettings.PrintFileName = printfilename
                        PrtDoc.PrinterSettings.PrinterName = My.Settings.printernametoexport
                        PrtDoc.PrinterSettings.PrintToFile = True
                        PrtDoc.Print()
                    End If
                End If

            End If
            If IsSendEmail = True Then
                If issendtofile = True Then
                    SendCustomEmailTo(SQLGetStringFieldValue("SELECT emailid FROM LEDGERS WHERE LEDGERNAME=N'" & txtLedgerName.Text & "'", "emailid"), SQLGetStringFieldValue(" select mailSubject from smsmailsettings where vouchername='SALES'  and IsEmail='True' ", "mailSubject"), sentmessage, printfilename)
                Else
                    SendCustomEmailTo(SQLGetStringFieldValue("SELECT emailid FROM LEDGERS WHERE LEDGERNAME=N'" & txtLedgerName.Text & "'", "emailid"), SQLGetStringFieldValue(" select mailSubject from smsmailsettings where vouchername='SALES'  and IsEmail='True' ", "mailSubject"), sentmessage, "")
                End If
            End If
            printk.Dispose()
            pvalues = Nothing
        End If

    End Sub

    Private Sub PrtDoc_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrtDoc.BeginPrint
        LoadPageSetupValues(PrintingScheme)
        If PagesetupValues.IsRollPaper = False Then
            PrtDoc.DefaultPageSettings.PaperSize = New PaperSize("Custom", PagesetupValues.Paperwidth, PagesetupValues.Paperheight)
            If PagesetupValues.IslandScape = True Then
                PrtDoc.DefaultPageSettings.Landscape = True
            Else
                PrtDoc.DefaultPageSettings.Landscape = False
            End If
            PrtDoc.DefaultPageSettings.Margins.Left = PagesetupValues.leftmarging
            PrtDoc.DefaultPageSettings.Margins.Right = PagesetupValues.rightmarging
            PrtDoc.DefaultPageSettings.Margins.Top = PagesetupValues.topmarging
            PrtDoc.DefaultPageSettings.Margins.Bottom = PagesetupValues.buttommarging
            PrtDoc.PrinterSettings.PrinterName = PagesetupValues.PrinterName
            PrtDoc.DefaultPageSettings.PrinterSettings.PrinterName = PagesetupValues.PrinterName
            PrtDoc.DefaultPageSettings.PrinterSettings.Copies = NOofpagestoprint
        Else
            RollPaperBeginPrint(sender, OpenedTranscode, "StockInvoiceRowItems", "StockInvoiceDetails", PrintingScheme, 0)
            PrtDoc.DefaultPageSettings.PaperSize = New PaperSize("Custom", RollPaperPrintSettings.PageWidht, RollPaperPrintSettings.PageHeight)
            PrtDoc.DefaultPageSettings.Landscape = False
            PrtDoc.DefaultPageSettings.Margins.Left = RollPaperPrintSettings.LeftMargin
            PrtDoc.DefaultPageSettings.Margins.Right = RollPaperPrintSettings.RightMargin
            PrtDoc.DefaultPageSettings.Margins.Top = RollPaperPrintSettings.TopMargin
            PrtDoc.DefaultPageSettings.Margins.Bottom = RollPaperPrintSettings.ButtomMargin
        End If


    End Sub

    Private Sub PrtDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrtDoc.PrintPage
        If PagesetupValues.IsRollPaper = False Then
            Printingset(sender, e, OpenedTranscode, PrintingScheme, "StockInvoiceRowItems", "StockInvoiceDetails", PrintInvoicecopyno, IsPrintDuplicateInvoice)
        Else
            RollPaperPrinting(sender, e, PrtDoc, True)
        End If


    End Sub
    Private Sub TxtDiscount_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDiscount.TextChanged
        FindTotalAmounts()

    End Sub

    Private Sub TxtPaymentBy_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPaymentBy.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim Oldname As String
            Oldname = TxtPaymentBy.Text
            Dim k As New CreateCustomers
            k.ShowDialog()
            k.Dispose()
            LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "' or groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')", TxtPaymentBy, "ledgername")
            TxtPaymentBy.Text = Oldname
        End If
    End Sub

    Private Sub BtnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCopy.Click, CopyStripMenuItem1.Click
        If CDbl(TxtNetTotal.Text) <= 0 Then Exit Sub
        IsCopyInvoice = True
        If IsInvoiceSaved = False Then
            Dim k As DialogResult
            k = MsgBox("The Current Invoice is not saved, Do you want to save ?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.DefaultButton1)
            If k = MsgBoxResult.Yes Then
                CheckBeforeSave()
                IsCopyInvoice = False
                If IsInvoiceSaved = False Then
                    Exit Sub

                End If
            ElseIf k = MsgBoxResult.Cancel Then
                IsCopyInvoice = False
                Exit Sub
            End If
            IsCopyInvoice = False
        End If
        If MsgBox("Do You want to copy/Duplicate for New Invoice with list of items from this invoice ?    ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Select Case InvoiceCtrlType
            Case "SO"
                TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.salesorder)
                If InvoiceBillingSettings.SalesOrderSettings.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
            Case "SI"
                TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.salesinvoice)
                If InvoiceBillingSettings.SalesInvoiceSettings.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
                LblSalesLedger.Visible = True
                TxtSalesLedger.Visible = True
            Case "SQ"
                TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.salesquoto)
                If InvoiceBillingSettings.SalesQutoSetting.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
            Case "SR"
                If SalesTrancsationType.Length > 0 Then
                    If SalesTrancsationType = "Returns Form-8B" Then
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.SRFORM8B)
                    ElseIf SalesTrancsationType = "Returns Form-8" Then
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.SRFORM8)
                    Else
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.SRFORM8D)
                    End If
                Else
                    TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.SalesRetInvoice)
                End If

                If InvoiceBillingSettings.SalesReturnInvoiceSettings.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
                LblSalesLedger.Visible = True
                TxtSalesLedger.Visible = True
            Case "SD"
                TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.salesdelavery)
                If InvoiceBillingSettings.SalesDelavarySettings.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
            Case "POS"
                If SalesTrancsationType.Length > 0 Then
                    If SalesTrancsationType = "Cash Sales" Then
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.CASHSALES)
                    ElseIf SalesTrancsationType = "Credit Sales" Then
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.CREDITSALES)
                    Else
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.POS)
                    End If
                Else
                    TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.POS)
                End If
                If InvoiceBillingSettings.SalesInvoiceSettings.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
                LblSalesLedger.Visible = True
                TxtSalesLedger.Visible = True
        End Select
        LoadStockEntryDefaults()
        TxtDate.Focus()
        IsInvoiceSaved = True
        IsInvoiceOpen = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TxtStockValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtStockValue.TextChanged
        IsValueTextChanged = True
    End Sub
    '    IsValueTextChanged = True

    Private Sub TxtStockNetRate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtStockNetRate.TextChanged
        IsNetValueTextChanged = True
    End Sub


    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        Dim value1 As String = ""
        Dim value2 As String = ""
        Dim value3 As String = ""
        Dim value4 As String = ""
        Dim value5 As String = ""
        Dim value6 As String = ""
        value1 = txtLedgerName.Text
        value2 = TxtSalesLedger.Text
        value3 = TxtLedgerName1.Text
        value4 = TxtLedgerName2.Text
        value5 = TxtLedgerName3.Text
        value6 = TxtSalesPerson.Text
        LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "')", txtLedgerName, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')", TxtSalesLedger, "ledgername")
        LoadDataIntoComboBox("SELECT Ledgername from ledgers where isactive=1 and (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.DirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "' or groupname=N'" & AccountGroupNames.DirectIncomes & "'))", TxtLedgerName1, "ledgername")
        LoadDataIntoComboBox("SELECT Ledgername from ledgers where isactive=1 and (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.DirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "' or groupname=N'" & AccountGroupNames.DirectIncomes & "'))", TxtLedgerName2, "ledgername")
        LoadDataIntoComboBox("SELECT Ledgername from ledgers where  isactive=1 and (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.DirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "' or groupname=N'" & AccountGroupNames.DirectIncomes & "'))", TxtLedgerName3, "ledgername")
        LoadDataIntoComboBox("select salespersonname from salespersons where isactive=1", TxtSalesPerson, "salespersonname")

        txtLedgerName.Text = value1
        TxtSalesLedger.Text = value2
        TxtLedgerName1.Text = value3
        TxtLedgerName2.Text = value4
        TxtLedgerName3.Text = value5
        TxtSalesPerson.Text = value6
    End Sub

    Private Sub TxtRatePer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRatePer.GotFocus
        If TxtStockCode.Text.Length = 0 Then
            TxtStockCode.Focus()
            Exit Sub
        End If
    End Sub


    Private Sub TxtRatePer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRatePer.SelectedIndexChanged
        FindStockAmount()
    End Sub

    Private Sub btnAddItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddItems.Click
        AddItems()
    End Sub

    Private Sub TxtPaymentMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPaymentMethod.SelectedIndexChanged
        TxtPaymentBy.Items.Clear()
        If TxtPaymentMethod.Text = "Cash" Then
            LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where  groupname=N'" & AccountGroupNames.CashAccounts & "')", TxtPaymentBy, "ledgername")
        ElseIf TxtPaymentMethod.Text = "Card" Then
            LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where  groupname=N'" & AccountGroupNames.BankAccounts & "')", TxtPaymentBy, "ledgername")

        ElseIf TxtPaymentMethod.Text.Length > 0 Then
            LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "' OR groupname=N'" & AccountGroupNames.IndirectIncomes & "')", TxtPaymentBy, "ledgername")

        Else
            LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where  groupname=N'" & AccountGroupNames.CashAccounts & "')", TxtPaymentBy, "ledgername")

        End If
        If TxtPaymentMethod.Text = "Credit" Then
            GrpAdvancePayment.Enabled = True
        Else
            GrpAdvancePayment.Enabled = False
        End If
        Try
            TxtPaymentBy.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtBatchNo_GotFocus(sender As Object, e As System.EventArgs) Handles TxtBatchNo.GotFocus
        If TxtStockCode.Text.Length = 0 Then TxtStockCode.Focus()
    End Sub

    Private Sub TxtBatchNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBatchNo.KeyDown
        If TxtStockCode.Text.Length = 0 Then Exit Sub
        If e.Alt = True And e.KeyCode = Keys.C Then
            Dim bvalues As New newbatchexpiryClass
            bvalues.Batchno = ""
            bvalues.stockcode = NewAddItem.StockItemCode
            bvalues.Stocksize = NewAddItem.StockITemSize
            bvalues.StockLocation = NewAddItem.StockLocation
            bvalues.Expirydate.Value = Today.AddDays(1)
            Dim frm As New ReadBatchExpiryInInvoice(bvalues)
            frm.ShowDialog()
            If bvalues.Batchno.Length > 0 Then
                TxtBatchNo.Items.Add(bvalues.Batchno)
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim batchsqlstr As String = ""
                batchsqlstr = " INSERT INTO [StockBatch] ([StockCode] ,[Barcode] ,[StockSize] ,[Location],[BaseUnit],[MainUnit],[SubUnit],[IsSimpleUnit] ,[BaseQty] ,[TotalQty] ,[SubUnitQty] ,[QtyText] ,[OpBaseQty] , " _
                    & " [OpTotalQty] ,[OpSubUnitQty] ,[StockRate] ,[Expiry] ,[BatchNo] ,[OpstockRate] ,[mrp] ,[expiryDateValue])     VALUES " _
                    & "(@StockCode ,@Barcode ,@StockSize ,@Location,@BaseUnit,@MainUnit,@SubUnit,@IsSimpleUnit ,@BaseQty ,@TotalQty ,@SubUnitQty ,@QtyText , " _
                    & " @OpBaseQty ,@OpTotalQty ,@OpSubUnitQty ,@StockRate ,@Expiry ,@BatchNo ,@OpstockRate ,@mrp ,@expiryDateValue)   "
                Dim DBF1 As New SqlClient.SqlCommand(batchsqlstr, MAINCON)
                With DBF1.Parameters
                    .AddWithValue("StockCode", NewAddItem.StockItemCode)
                    .AddWithValue("Barcode", NewAddItem.StockItemBarCode)
                    .AddWithValue("StockSize", NewAddItem.StockITemSize)
                    .AddWithValue("Location", NewAddItem.StockLocation)
                    .AddWithValue("BaseUnit", NewAddItem.StockUnitName)
                    .AddWithValue("MainUnit", NewAddItem.StockMainUnitName)
                    .AddWithValue("SubUnit", NewAddItem.StockSubUnitName)
                    .AddWithValue("IsSimpleUnit", 1)
                    .AddWithValue("BaseQty", 0)
                    .AddWithValue("TotalQty", 0)
                    .AddWithValue("SubUnitQty", 0)
                    .AddWithValue("QtyText", 0)
                    .AddWithValue("OpBaseQty", 0)
                    .AddWithValue("OpTotalQty", 0)
                    .AddWithValue("OpSubUnitQty", 0)
                    .AddWithValue("OpstockRate", 0)
                    .AddWithValue("StockRate", NewAddItem.StockRate)
                    .AddWithValue("mrp", NewAddItem.MRP)
                    .AddWithValue("expiry", bvalues.Expirydate.Value)
                    .AddWithValue("BatchNo", bvalues.Batchno)
                    .AddWithValue("expiryDateValue", bvalues.Expirydate.Value.Date.ToOADate)
                End With
                DBF1.ExecuteNonQuery()
                DBF1 = Nothing
                MAINCON.Close()
                TxtBatchNo.Text = bvalues.Batchno
            End If
        End If
    End Sub

    Private Sub TxtBatchNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBatchNo.LostFocus
        If IsSalesPriceAsMRPWithOutVAT = True Then
            '  TxtStockRate.Text = SQLGetNumericFieldValue("select mrp from stockbatch where stockcode=N'" & NewAddItem.StockItemCode & "' and stocksize=N'" & NewAddItem.StockITemSize & "' and location=N'" & NewAddItem.StockLocation & "' and batchno=N'" & TxtBatchNo.Text & "'", "mrp")
            NewAddItem.MRP = SQLGetNumericFieldValue("select mrp from stockbatch where stockcode=N'" & NewAddItem.StockItemCode & "' and stocksize=N'" & NewAddItem.StockITemSize & "' and location=N'" & NewAddItem.StockLocation & "' and batchno=N'" & TxtBatchNo.Text & "'", "mrp")
            TxtStockRate.Text = NewAddItem.MRP
            TxtMRP.Text = NewAddItem.MRP
        Else
            If TxtBatchNo.Text.Length > 0 Then
                NewAddItem.MRP = SQLGetNumericFieldValue("SELECT mrp FROM STOCKBATCH WHERE STOCKCODE=N'" & NewAddItem.StockItemCode & "' AND STOCKSIZE=N'" & NewAddItem.StockITemSize & "' AND LOCATION=N'" & NewAddItem.StockLocation & "' AND BATCHNO=N'" & TxtBatchNo.Text & "'", "mrp")
            End If
            TxtMRP.Text = NewAddItem.MRP
        End If
    End Sub




    Private Sub TxtBatchNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBatchNo.SelectedIndexChanged
        TxtStatusText.Text = "Cur Qty:" & SQLGetStringFieldValue("SELECT QTYTEXT FROM stockbatch WHERE STOCKCODE=N'" & NewAddItem.StockItemCode & "' AND STOCKSIZE=N'" & NewAddItem.StockITemSize & "' AND LOCATION=N'" & NewAddItem.StockLocation & "'  AND BATCHNO=N'" & TxtBatchNo.Text & "'", "QTYTEXT")
    End Sub

    Private Sub TxtBatchNo_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBatchNo.SizeChanged

    End Sub

    Private Sub TxtBatchNo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBatchNo.Validating
        If TxtBatchNo.Text.Length > 0 And TxtBatchNo.Items.Contains(TxtBatchNo.Text) = False Then

            Dim bvalues As New newbatchexpiryClass
            bvalues.Batchno = TxtBatchNo.Text
            bvalues.stockcode = NewAddItem.StockItemCode
            bvalues.Stocksize = NewAddItem.StockITemSize
            bvalues.StockLocation = NewAddItem.StockLocation
            bvalues.Expirydate.Value = Today.AddDays(1)

            Dim frm As New ReadBatchExpiryInInvoice(bvalues)
            frm.ShowDialog()
            If bvalues.Batchno.Length > 0 Then
                TxtBatchNo.Items.Add(bvalues.Batchno)
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim batchsqlstr As String = ""
                batchsqlstr = " INSERT INTO [StockBatch] ([StockCode] ,[Barcode] ,[StockSize] ,[Location],[BaseUnit],[MainUnit],[SubUnit],[IsSimpleUnit] ,[BaseQty] ,[TotalQty] ,[SubUnitQty] ,[QtyText] ,[OpBaseQty] , " _
                    & " [OpTotalQty] ,[OpSubUnitQty] ,[StockRate] ,[Expiry] ,[BatchNo] ,[OpstockRate] ,[mrp] ,[expiryDateValue])     VALUES " _
                    & "(@StockCode ,@Barcode ,@StockSize ,@Location,@BaseUnit,@MainUnit,@SubUnit,@IsSimpleUnit ,@BaseQty ,@TotalQty ,@SubUnitQty ,@QtyText , " _
                    & " @OpBaseQty ,@OpTotalQty ,@OpSubUnitQty ,@StockRate ,@Expiry ,@BatchNo ,@OpstockRate ,@mrp ,@expiryDateValue)   "
                Dim DBF1 As New SqlClient.SqlCommand(batchsqlstr, MAINCON)
                With DBF1.Parameters
                    .AddWithValue("StockCode", NewAddItem.StockItemCode)
                    .AddWithValue("Barcode", NewAddItem.StockItemBarCode)
                    .AddWithValue("StockSize", NewAddItem.StockITemSize)
                    .AddWithValue("Location", NewAddItem.StockLocation)
                    .AddWithValue("BaseUnit", NewAddItem.StockUnitName)
                    .AddWithValue("MainUnit", NewAddItem.StockMainUnitName)
                    .AddWithValue("SubUnit", NewAddItem.StockSubUnitName)
                    .AddWithValue("IsSimpleUnit", 1)
                    .AddWithValue("BaseQty", 0)
                    .AddWithValue("TotalQty", 0)
                    .AddWithValue("SubUnitQty", 0)
                    .AddWithValue("QtyText", 0)
                    .AddWithValue("OpBaseQty", 0)
                    .AddWithValue("OpTotalQty", 0)
                    .AddWithValue("OpSubUnitQty", 0)
                    .AddWithValue("OpstockRate", 0)
                    .AddWithValue("StockRate", NewAddItem.StockRate)
                    .AddWithValue("mrp", bvalues.Mrp)
                    .AddWithValue("expiry", bvalues.Expirydate.Value)
                    .AddWithValue("BatchNo", bvalues.Batchno)
                    .AddWithValue("expiryDateValue", bvalues.Expirydate.Value.Date.ToOADate)
                End With
                DBF1.ExecuteNonQuery()
                DBF1 = Nothing
                MAINCON.Close()
                TxtBatchNo.Text = bvalues.Batchno
                TxtStockQty.Focus()
                e.Cancel = False
            Else
                TxtBatchNo.Text = ""
            End If
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem1.Click
        TxtList.Rows.RemoveAt(TxtList.CurrentRow.Index)
        If SQLIsFieldExists("select Vattax from vatclauses where vattype='CST'") = True Then
            If TxtList.RowCount > 0 Then
                TxtVoucherType.Enabled = False
            Else
                TxtVoucherType.Enabled = True
            End If
        Else
            TxtVoucherType.Enabled = False
        End If

    End Sub



    Private Sub EditToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem1.Click
        LoadStockEntryDefaults()
        Dim CRate As Double = 1
        If IsValuesInBillingCurrency.Checked = True Then
            CRate = CDbl(TxtRateofExchange.Text)
        Else
            CRate = 1
        End If

        IsEditItem = True
        IsEditing = True
        BtnEditCancel.Visible = True
        TxtList.Enabled = False
        EditItemRow = TxtList.CurrentRow.Index
        Dim bvalue As New ChooseItemClass
        bvalue.StockItemBarCode = TxtList.Item("stbarcode", EditItemRow).Value
        bvalue.StockLocation = TxtList.Item("stlocation", EditItemRow).Value
        LoadStockItemsIntoClass(bvalue.StockItemBarCode, bvalue.StockLocation, NewAddItem)
        TxtStockDisc.Text = "0"
        IsTaxInclude = NewAddItem.IsTaxInclude
        TxtStockValue.Text = "0"
        TxtStockTax2 = NewAddItem.Tax2
        TxtStockCode.Text = NewAddItem.StockItemCode
        TxtStockName.Text = NewAddItem.StockItemName
        TxtStockSize.Text = NewAddItem.StockITemSize
        TxtStockQty.SetUnitName(NewAddItem.StockUnitName)
        TxtStockQty.ClearQty()
        TxtStockFreeQty.SetUnitName(NewAddItem.StockUnitName)
        TxtStockFreeQty.ClearQty()
        If TxtVoucherType.Text = "Tax Invoice" Then
            TxtStockTax2 = NewAddItem.Tax2
            TxtStockTax.Text = NewAddItem.Tax
        Else
            NewAddItem.Tax = NewAddItem.CSTtax
            TxtStockTax.Text = NewAddItem.Tax
            NewAddItem.Tax2 = 0
            TxtStockTax2 = 0
        End If
        If IsZeroTax = True Then
            NewAddItem.Tax = 0
            NewAddItem.Tax2 = 0
            TxtStockTax.Text = "0"
            TxtStockTax2 = 0
        End If
        TxtStockRate.Text = CDbl(TxtList.Item("strate", EditItemRow).Value) * CRate / CDbl(TxtRateofExchange.Text)
        TxtRatePer.Items.Clear()
        If NewAddItem.IsSimpleUnit = 1 Then
            TxtStockQty.TxtQty2.Text = "0"
            TxtStockQty.TxtQty1.Text = CDbl(TxtList.Item("stMqty", EditItemRow).Value)
            TxtStockFreeQty.TxtQty2.Text = "0"
            TxtStockFreeQty.TxtQty1.Text = CDbl(TxtList.Item("stfreeqty", EditItemRow).Value)
            TxtRatePer.Items.Add(NewAddItem.StockUnitName)
            TxtRatePer.Text = NewAddItem.StockUnitName
        Else
            TxtStockQty.TxtQty1.Text = "0"
            TxtStockQty.TxtQty2.Text = CDbl(TxtList.Item("stMqty", EditItemRow).Value)
            TxtStockFreeQty.TxtQty1.Text = "0"
            TxtStockFreeQty.TxtQty2.Text = CDbl(TxtList.Item("stfreeqty", EditItemRow).Value)
            TxtRatePer.Items.Add(NewAddItem.StockMainUnitName)
            TxtRatePer.Items.Add(NewAddItem.StockSubUnitName)
            TxtRatePer.Text = NewAddItem.StockMainUnitName
        End If

        TxtStockQty.CalculateValues()
        TxtStockFreeQty.CalculateValues()
        TxtRatePer.Text = TxtList.Item("strateper", EditItemRow).Value
        TxtStockDisc.Text = TxtList.Item("stdiscount", EditItemRow).Value
        TxtStockDiscount2.Text = TxtList.Item("tdisc2", EditItemRow).Value
        TxtStockRate.Text = TxtList.Item("strate", EditItemRow).Value * CRate / CDbl(TxtRateofExchange.Text)
        TxtStockValue.Text = TxtList.Item("StStockTaxValue", EditItemRow).Value * CRate / CDbl(TxtRateofExchange.Text)
        TxtStockNetRate.Text = TxtList.Item("stnetrate", EditItemRow).Value * CRate / CDbl(TxtRateofExchange.Text)
        TxtStockTax.Text = TxtList.Item("sttax", EditItemRow).Value

        TxtMRP.Text = TxtList.Item("stmrp", EditItemRow).Value
        If Len(TxtList.Item("stbatchno", EditItemRow).Value) > 0 Then
            LoadDataIntoComboBox("select batchno from stockbatch where stockcode=N'" & TxtStockCode.Text & "' and stocksize=N'" & TxtStockSize.Text & "' and location=N'" & TxtList.Item("stlocation", EditItemRow).Value & "'", TxtBatchNo, "batchno")

            TxtBatchNo.Text = TxtList.Item("stbatchno", EditItemRow).Value
            TxtBatchNo.Enabled = True
            Me.TableForItemRow.ColumnStyles.Item(4).Width = 80
        Else
            TxtBatchNo.Enabled = False
            TxtBatchNo.Text = ""
            Me.TableForItemRow.ColumnStyles.Item(4).Width = 0
        End If
        TxtStockQty.Focus()
        IsEditing = False
        IsEditItem = True
        bvalue = Nothing

    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        LoadStockEntryDefaults()

        Dim CRate As Double = 1
        If IsValuesInBillingCurrency.Checked = True Then
            CRate = CDbl(TxtRateofExchange.Text)
        Else
            CRate = 1
        End If

        EditItemRow = TxtList.CurrentRow.Index
        Dim bvalue As New ChooseItemClass
        bvalue.StockItemBarCode = TxtList.Item("stbarcode", EditItemRow).Value
        bvalue.StockLocation = TxtList.Item("stlocation", EditItemRow).Value
        LoadStockItemsIntoClass(bvalue.StockItemBarCode, bvalue.StockLocation, NewAddItem)
        TxtStockDisc.Text = "0"
        TxtStockValue.Text = "0"
        TxtStockTax2 = NewAddItem.Tax2
        IsTaxInclude = NewAddItem.IsTaxInclude
        TxtStockCode.Text = NewAddItem.StockItemCode
        TxtStockName.Text = NewAddItem.StockItemName
        TxtStockSize.Text = NewAddItem.StockITemSize
        TxtStockQty.SetUnitName(NewAddItem.StockUnitName)
        TxtStockQty.ClearQty()
        TxtStockFreeQty.SetUnitName(NewAddItem.StockUnitName)
        TxtStockFreeQty.ClearQty()
        If IsZeroTax = True Then
            NewAddItem.Tax = 0
            NewAddItem.Tax2 = 0
            TxtStockTax.Text = "0"
            TxtStockTax2 = 0
        End If
        TxtStockRate.Text = CDbl(TxtList.Item("strate", EditItemRow).Value) * CRate / CDbl(TxtRateofExchange.Text)
        TxtRatePer.Items.Clear()
        If NewAddItem.IsSimpleUnit = 1 Then
            TxtStockQty.TxtQty2.Text = "0"
            TxtStockQty.TxtQty1.Text = CDbl(TxtList.Item("stMqty", EditItemRow).Value)
            TxtStockFreeQty.TxtQty2.Text = "0"
            TxtStockFreeQty.TxtQty1.Text = CDbl(TxtList.Item("stfreeqty", EditItemRow).Value)
            TxtRatePer.Items.Add(NewAddItem.StockUnitName)
            TxtRatePer.Text = NewAddItem.StockUnitName
        Else
            TxtStockQty.TxtQty1.Text = "0"
            TxtStockQty.TxtQty2.Text = CDbl(TxtList.Item("stMqty", EditItemRow).Value)
            TxtStockFreeQty.TxtQty1.Text = "0"
            TxtStockFreeQty.TxtQty2.Text = CDbl(TxtList.Item("stfreeqty", EditItemRow).Value)
            TxtRatePer.Items.Add(NewAddItem.StockMainUnitName)
            TxtRatePer.Items.Add(NewAddItem.StockSubUnitName)
            TxtRatePer.Text = NewAddItem.StockMainUnitName
        End If

        TxtStockQty.CalculateValues()
        TxtStockFreeQty.CalculateValues()
        TxtRatePer.Text = TxtList.Item("strateper", EditItemRow).Value
        TxtStockDisc.Text = TxtList.Item("stdiscount", EditItemRow).Value
        TxtStockDiscount2.Text = TxtList.Item("tdisc2", EditItemRow).Value
        TxtStockRate.Text = TxtList.Item("strate", EditItemRow).Value * CRate / CDbl(TxtRateofExchange.Text)
        TxtStockValue.Text = TxtList.Item("StStockTaxValue", EditItemRow).Value * CRate / CDbl(TxtRateofExchange.Text)
        TxtStockNetRate.Text = TxtList.Item("stnetrate", EditItemRow).Value * CRate / CDbl(TxtRateofExchange.Text)
        TxtStockTax.Text = TxtList.Item("sttax", EditItemRow).Value

        TxtMRP.Text = TxtList.Item("stmrp", EditItemRow).Value
        If Len(TxtList.Item("stbatchno", EditItemRow).Value) > 0 Then
            LoadDataIntoComboBox("select batchno from stockbatch where stockcode=N'" & TxtStockCode.Text & "' and stocksize=N'" & TxtStockSize.Text & "' and location=N'" & TxtList.Item("stlocation", EditItemRow).Value & "'", TxtBatchNo, "batchno")

            TxtBatchNo.Text = TxtList.Item("stbatchno", EditItemRow).Value
            TxtBatchNo.Enabled = True
            Me.TableForItemRow.ColumnStyles.Item(4).Width = 80
        Else
            TxtBatchNo.Enabled = False
            TxtBatchNo.Text = ""
            Me.TableForItemRow.ColumnStyles.Item(4).Width = 0
        End If
        TxtStockCode.Focus()
        bvalue = Nothing
    End Sub
    Private Sub ViewInwordsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewInwordsToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If StockINOUTReport Is Nothing OrElse StockINOUTReport.IsDisposed Then
            StockINOUTReport = New ViewInwards(True, TxtList.Item("STItemCode", TxtList.CurrentRow.Index).Value)
            StockINOUTReport.BringToFront()
            StockINOUTReport.StartPosition = FormStartPosition.CenterParent
            StockINOUTReport.Show()
        Else
            StockINOUTReport.Dispose()
            StockINOUTReport = New ViewInwards(True, TxtList.Item("STItemCode", TxtList.CurrentRow.Index).Value)
            StockINOUTReport.BringToFront()
            StockINOUTReport.StartPosition = FormStartPosition.CenterParent
            StockINOUTReport.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
    Public Shared StockINOUTReport As ViewInwards

    Private Sub ViewOutWardsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewOutWardsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If StockINOUTReport Is Nothing OrElse StockINOUTReport.IsDisposed Then
            StockINOUTReport = New ViewInwards(False, TxtList.Item("STItemCode", TxtList.CurrentRow.Index).Value)
            StockINOUTReport.BringToFront()
            StockINOUTReport.StartPosition = FormStartPosition.CenterParent
            StockINOUTReport.Show()
        Else
            StockINOUTReport.Dispose()
            StockINOUTReport = New ViewInwards(True, TxtList.Item("STItemCode", TxtList.CurrentRow.Index).Value)
            StockINOUTReport.BringToFront()
            StockINOUTReport.StartPosition = FormStartPosition.CenterParent
            StockINOUTReport.Show()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TxtStockTax_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockTax.SelectedIndexChanged
        FindStockAmount()
    End Sub

    Private Sub TxtDiscAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDiscAmt.LostFocus
        If TxtDiscAmt.Text.Length = 0 Then
            TxtDiscount.Text = "0"
        Else
            If CDbl(TxtGrossTotal.Text) > 0 Then
                TxtDiscount.Text = CDbl(TxtDiscAmt.Text) * -1 * 100 / CDbl(TxtGrossTotal.Text)
            Else
                TxtDiscount.Text = "0"
            End If

        End If

    End Sub

    Private Sub IsValuesInBillingCurrency_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsValuesInBillingCurrency.CheckedChanged
        If TxtBillingCurrency.Text = CompDetails.Currency Then Exit Sub
        If IsValuesInBillingCurrency.Checked = True Then
            For i As Integer = 0 To TxtList.RowCount - 1
                TxtList.Item("strate", i).Value = CDbl(TxtList.Item("strate", i).Value) / CDbl(TxtList.Item("stconrate", i).Value)
                TxtList.Item("stStockvalueWithOutTax", i).Value = CDbl(TxtList.Item("stStockvalueWithOutTax", i).Value) / CDbl(TxtList.Item("stconrate", i).Value)
                TxtList.Item("sttaxamount", i).Value = CDbl(TxtList.Item("sttaxamount", i).Value) / CDbl(TxtList.Item("stconrate", i).Value)
                TxtList.Item("sttaxamount2", i).Value = CDbl(TxtList.Item("sttaxamount2", i).Value) / CDbl(TxtList.Item("stconrate", i).Value)
                TxtList.Item("stnetrate", i).Value = CDbl(TxtList.Item("stnetrate", i).Value) / CDbl(TxtList.Item("stconrate", i).Value)
                TxtList.Item("ststocktaxvalue", i).Value = CDbl(TxtList.Item("ststocktaxvalue", i).Value) / CDbl(TxtList.Item("stconrate", i).Value)
            Next
            TxtCurrencyLabel.Text = TxtCurrency.Text
        Else
            For i As Integer = 0 To TxtList.RowCount - 1
                TxtList.Item("strate", i).Value = CDbl(TxtList.Item("strate", i).Value) * CDbl(TxtList.Item("stconrate", i).Value)
                TxtList.Item("stStockvalueWithOutTax", i).Value = CDbl(TxtList.Item("stStockvalueWithOutTax", i).Value) * CDbl(TxtList.Item("stconrate", i).Value)
                TxtList.Item("sttaxamount", i).Value = CDbl(TxtList.Item("sttaxamount", i).Value) * CDbl(TxtList.Item("stconrate", i).Value)
                TxtList.Item("sttaxamount2", i).Value = CDbl(TxtList.Item("sttaxamount2", i).Value) * CDbl(TxtList.Item("stconrate", i).Value)
                TxtList.Item("stnetrate", i).Value = CDbl(TxtList.Item("stnetrate", i).Value) * CDbl(TxtList.Item("stconrate", i).Value)
                TxtList.Item("ststocktaxvalue", i).Value = CDbl(TxtList.Item("ststocktaxvalue", i).Value) * CDbl(TxtList.Item("stconrate", i).Value)
            Next
            TxtCurrencyLabel.Text = CompDetails.Currency
        End If

        FindTotalAmounts()
    End Sub
    Sub ConvertValuesByCurrency()
        If TxtList.RowCount = 0 Then Exit Sub
        Dim Tempcbc As Boolean = False
        If TxtBillingCurrency.Text = CompDetails.Currency Then
            If IsValuesInBillingCurrency.Checked = False Then
                For i As Integer = 0 To TxtList.RowCount - 1
                    TxtList.Item("strate", i).Value = CDbl(TxtList.Item("strate", i).Value) / CDbl(TxtList.Item("stconrate", i).Value)
                    TxtList.Item("stStockvalueWithOutTax", i).Value = CDbl(TxtList.Item("stStockvalueWithOutTax", i).Value) / CDbl(TxtList.Item("stconrate", i).Value)
                    TxtList.Item("sttaxamount", i).Value = CDbl(TxtList.Item("sttaxamount", i).Value) / CDbl(TxtList.Item("stconrate", i).Value)
                    TxtList.Item("sttaxamount2", i).Value = CDbl(TxtList.Item("sttaxamount2", i).Value) / CDbl(TxtList.Item("stconrate", i).Value)
                    TxtList.Item("stnetrate", i).Value = CDbl(TxtList.Item("stnetrate", i).Value) / CDbl(TxtList.Item("stconrate", i).Value)
                    TxtList.Item("ststocktaxvalue", i).Value = CDbl(TxtList.Item("ststocktaxvalue", i).Value) / CDbl(TxtList.Item("stconrate", i).Value)
                Next
            End If

            TxtCurrencyLabel.Text = TxtCurrency.Text

            For i As Integer = 0 To TxtList.RowCount - 1
                TxtList.Item("stconrate", i).Value = CDbl(TxtRateofExchange.Text)
            Next

        Else
            If IsValuesInBillingCurrency.Checked = True Then
                Tempcbc = True
            Else
                Tempcbc = False
                IsValuesInBillingCurrency.Checked = True
            End If

            For i As Integer = 0 To TxtList.RowCount - 1
                TxtList.Item("stconrate", i).Value = CDbl(TxtRateofExchange.Text)
            Next
            IsValuesInBillingCurrency.Checked = Tempcbc
        End If



    End Sub

    Private Sub TxtRateofExchange_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRateofExchange.LostFocus
        ConvertValuesByCurrency()
    End Sub


    Private Sub TxtBillingCurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBillingCurrency.SelectedIndexChanged

    End Sub

    Private Sub TxtCurrency_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCurrency.LostFocus

    End Sub

    Private Sub TxtCurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCurrency.SelectedIndexChanged
        If isopeningprocess = True Then Exit Sub
        If TxtCurrency.Text.ToUpper = CompDetails.Currency.ToUpper Then
            TxtRateofExchange.Text = "1"
            TxtRateofExchange.Enabled = False
            TxtBillingCurrency.Text = TxtCurrency.Text
        Else
            ErpReadExchangeRate = SQLGetNumericFieldValue("SELECT ConRate FROM CurrencyList WHERE CurrencyCode=N'" & TxtCurrency.Text & "'", "ConRate")
            Dim FRM As New ReadCurrencyExchangeRate(ErpReadExchangeRate, TxtCurrency.Text)
            FRM.ShowDialog()
            TxtRateofExchange.Text = ErpReadExchangeRate
            TxtBillingCurrency.Text = TxtCurrency.Text
            TxtRateofExchange.Enabled = True
        End If
        ConvertValuesByCurrency()
    End Sub

    Private Sub TxtList_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles TxtList.CellMouseDoubleClick
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        Dim CRate As Double = 1
        If IsValuesInBillingCurrency.Checked = True Then
            CRate = CDbl(TxtRateofExchange.Text)
        Else
            CRate = 1
        End If
        If MsgBox("Do you want to Edit?          ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            LoadStockEntryDefaults()
            IsEditItem = True
            IsEditing = True
            BtnEditCancel.Visible = True
            TxtList.Enabled = False
            EditItemRow = TxtList.CurrentRow.Index
            Dim bvalue As New ChooseItemClass
            bvalue.StockItemBarCode = TxtList.Item("stbarcode", EditItemRow).Value
            bvalue.StockLocation = TxtList.Item("stlocation", EditItemRow).Value
            LoadStockItemsIntoClass(bvalue.StockItemBarCode, bvalue.StockLocation, NewAddItem)
            TxtStockDisc.Text = "0"
            TxtStockValue.Text = "0"
            IsTaxInclude = NewAddItem.IsTaxInclude
            TxtStockCode.Text = NewAddItem.StockItemCode
            TxtStockName.Text = NewAddItem.StockItemName
            TxtStockSize.Text = NewAddItem.StockITemSize
            TxtStockQty.SetUnitName(NewAddItem.StockUnitName)
            TxtStockQty.ClearQty()
            TxtStockFreeQty.SetUnitName(NewAddItem.StockUnitName)
            TxtStockFreeQty.ClearQty()
            If TxtVoucherType.Text = "Tax Invoice" Then
                TxtStockTax2 = NewAddItem.Tax2
                TxtStockTax.Text = NewAddItem.Tax
            Else
                NewAddItem.Tax = NewAddItem.CSTtax
                TxtStockTax.Text = NewAddItem.Tax
                NewAddItem.Tax2 = 0
                TxtStockTax2 = 0
            End If
            If IsZeroTax = True Then
                NewAddItem.Tax = 0
                NewAddItem.Tax2 = 0
                TxtStockTax.Text = "0"
                TxtStockTax2 = 0
            End If
            TxtStockRate.Text = CDbl(TxtList.Item("strate", EditItemRow).Value) * CRate / CDbl(TxtRateofExchange.Text)
            TxtRatePer.Items.Clear()
            If NewAddItem.IsSimpleUnit = 1 Then
                TxtStockQty.TxtQty2.Text = "0"
                TxtStockQty.TxtQty1.Text = CDbl(TxtList.Item("stMqty", EditItemRow).Value)
                TxtStockFreeQty.TxtQty2.Text = "0"
                TxtStockFreeQty.TxtQty1.Text = CDbl(TxtList.Item("stfreeqty", EditItemRow).Value)
                TxtRatePer.Items.Add(NewAddItem.StockUnitName)
                TxtRatePer.Text = NewAddItem.StockUnitName
            Else
                TxtStockQty.TxtQty1.Text = "0"
                TxtStockQty.TxtQty2.Text = CDbl(TxtList.Item("stMqty", EditItemRow).Value)
                TxtStockFreeQty.TxtQty1.Text = "0"
                TxtStockFreeQty.TxtQty2.Text = CDbl(TxtList.Item("stFreeqty", EditItemRow).Value)

                TxtRatePer.Items.Add(NewAddItem.StockMainUnitName)
                TxtRatePer.Items.Add(NewAddItem.StockSubUnitName)
                TxtRatePer.Text = NewAddItem.StockMainUnitName
            End If

            TxtStockQty.CalculateValues()
            TxtStockFreeQty.CalculateValues()



            TxtRatePer.Text = TxtList.Item("strateper", EditItemRow).Value
            TxtStockDisc.Text = TxtList.Item("stdiscount", EditItemRow).Value
            TxtStockDiscount2.Text = TxtList.Item("tdisc2", EditItemRow).Value
            TxtStockRate.Text = CDbl(TxtList.Item("strate", EditItemRow).Value) * CRate / CDbl(TxtRateofExchange.Text)
            TxtStockValue.Text = CDbl(TxtList.Item("StStockTaxValue", EditItemRow).Value) * CRate / CDbl(TxtRateofExchange.Text)
            TxtStockNetRate.Text = CDbl(TxtList.Item("stnetrate", EditItemRow).Value) * CRate / CDbl(TxtRateofExchange.Text)
            TxtStockTax.Text = TxtList.Item("sttax", EditItemRow).Value

            TxtMRP.Text = TxtList.Item("stmrp", EditItemRow).Value
            If Len(TxtList.Item("stbatchno", EditItemRow).Value) > 0 Then
                LoadDataIntoComboBox("select batchno from stockbatch where stockcode=N'" & TxtStockCode.Text & "' and stocksize=N'" & TxtStockSize.Text & "' and location=N'" & TxtList.Item("stlocation", EditItemRow).Value & "'", TxtBatchNo, "batchno")
                TxtBatchNo.Text = TxtList.Item("stbatchno", EditItemRow).Value
                TxtBatchNo.Enabled = True
                Me.TableForItemRow.ColumnStyles.Item(4).Width = 80
            Else
                TxtBatchNo.Enabled = False
                TxtBatchNo.Text = ""
                Me.TableForItemRow.ColumnStyles.Item(4).Width = 0
            End If
            TxtStockQty.Focus()
            IsEditItem = True
            IsEditing = False
            bvalue = Nothing
        End If
    End Sub

    Private Sub TxtStockRate_GotFocus(sender As Object, e As System.EventArgs) Handles TxtStockRate.GotFocus
        ChangedStockRate = FormatNumber(CDbl(TxtStockRate.Text), 2, , , TriState.False)
    End Sub

    Private Sub TxtStockRate_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtStockRate.TextChanged

    End Sub
    Private Sub TxtStockRate_LostFocus(sender As Object, e As System.EventArgs) Handles TxtStockRate.LostFocus
        If ChangedStockRate <> FormatNumber(CDbl(TxtStockRate.Text), 2, , , TriState.False) Then
            If IsTaxInclude = True Then
                Dim NetRate As Double = 0
                NetRate = TxtStockRate.Text
                TxtStockRate.Text = FormatNumber(NetRate * 100 / (100 + CDbl(TxtStockTax.Text)), 3, , , TriState.False)
                TxtStockNetRate.Text = FormatNumber(NetRate, 3, , , TriState.False)
            End If
        End If

        FindStockAmount()

    End Sub

    'Private Sub TxtStockRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockRate.TextChanged
    '    FindStockAmount()
    'End Sub

    Private Sub TxtRateofExchange_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRateofExchange.TextChanged

    End Sub
    Sub SaveChequeInfo(ByVal transcode As Single)
        Dim isprinted As Boolean = False
        isprinted = SQLGetBooleanFieldValue("select Isprinted from chequeinfo where transcode=" & transcode, "Isprinted")
        ExecuteSQLQuery("delete from chequeinfo where transcode=" & transcode)

        If SQLIsFieldExists("SELECT TOP 1 1 from   ledgers where ledgername=N'" & TxtPaymentBy.Text & "' and   (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'Bank O D'))") = True Then
            Dim SqlStr As String = ""
            SqlStr = " INSERT INTO [chequeinfo]([transcode],[Ledgername],[chequeno],[chequedate],[issuedate],[details],[vouchername],[voucherno],[amount],[Isprinted],[chequedatevalue])     VALUES " _
                & "(@transcode,@Ledgername,@chequeno,@chequedate,@issuedate,@details,@vouchername,@voucherno,@amount,@Isprinted,@chequedatevalue) "
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBFR = New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBFR.Parameters
                .AddWithValue("transcode", transcode)
                .AddWithValue("Ledgername", TxtPaymentBy.Text)
                .AddWithValue("chequeno", TxtPaymentDetails.Text)
                .AddWithValue("chequedate", TxtDate.Value)
                .AddWithValue("issuedate", TxtDate.Value)
                .AddWithValue("details", txtLedgerName.Text)
                Select Case InvoiceCtrlType
                    Case "SI", "POS"
                        .AddWithValue("vouchername", "Sales")
                    Case "SR"
                        .AddWithValue("vouchername", "CreditNote")
                End Select

                .AddWithValue("voucherno", TxtQutoNo.Text)
                .AddWithValue("amount", CDbl(TxtNetTotal.Text))
                .AddWithValue("Isprinted", isprinted)
                .AddWithValue("chequedatevalue", TxtDate.Value.Date.ToOADate)
            End With
            DBFR.ExecuteNonQuery()
            DBFR = Nothing
            MAINCON.Close()
        End If

    End Sub
    Sub LoadBill2BillReceipts()
        TxtReceipts.DataSource = Nothing
        If IsInvoiceOpen = False Then Exit Sub
        If InvoiceCtrlType = "POS" Or InvoiceCtrlType = "SR" Or InvoiceCtrlType = "SI" Then
            TxtReceipts.DataSource = Nothing
            TxtRBillAmount.Text = "0.00"
            TxtRPaidAmount.Text = "0.00"
            TxtRBalanceAmount.Text = "0.00"
            If InvoiceCtrlType = "SI" Or InvoiceCtrlType = "POS" Or InvoiceCtrlType = "SR" Then
                Try
                    Dim SqlStrList As String = ""
                    SqlStrList = "SELECT TRANSCODE AS [Transcode],BILLTRANSCODE AS [BILLTRANSCODE],TRANSDATE AS [Date ],REFNO AS [Ref No],invoiceno as [Invoice No],paymentmethod as [Pay Method],DR+CR AS [Amount] FROM BILL2BILL WHERE LEDGERNAME=N'" & txtLedgerName.Text & "' AND REFNO=N'" & TxtRefNo.Text & "' AND BILLTYPE='Against' "
                    Dim TempBS As New BindingSource
                    With Me.TxtReceipts
                        TempBS.DataSource = SQLLoadGridData(SqlStrList)
                        .AutoGenerateColumns = True
                        .DataSource = TempBS
                    End With
                    Try
                        TxtReceipts.Columns("transcode").Visible = False
                        TxtReceipts.Columns("BILLTRANSCODE").Visible = False
                    Catch ex As Exception

                    End Try
                    TxtRBillAmount.Text = FormatNumber(SQLGetNumericFieldValue("select (dr+cr) as tot  FROM BILL2BILL WHERE LEDGERNAME=N'" & txtLedgerName.Text & "' AND REFNO=N'" & TxtRefNo.Text & "' AND BILLTYPE='New' ", "tot"), 2)
                    TxtRPaidAmount.Text = FormatNumber(SQLGetNumericFieldValue("select (dr+cr) as tot  FROM BILL2BILL WHERE LEDGERNAME=N'" & txtLedgerName.Text & "' AND REFNO=N'" & TxtRefNo.Text & "' AND BILLTYPE='Against' ", "tot"), 2)
                    TxtRBalanceAmount.Text = FormatNumber(CDbl(TxtRBillAmount.Text) - CDbl(TxtRPaidAmount.Text), 2)
                Catch ex As Exception

                End Try
            End If
        End If


    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            If CDbl(TxtRBalanceAmount.Text) > 0 Then
                Dim frm As New ReceiptVoucherByBill2Bill(TxtRefNo.Text, CDbl(TxtRBalanceAmount.Text), txtLedgerName.Text, 0)
                frm.ShowDialog()
                LoadBill2BillReceipts()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try
            If TxtReceipts.RowCount = 0 Then Exit Sub
            If CDbl(TxtRBalanceAmount.Text) > 0 Then
                Dim frm As New ReceiptVoucherByBill2Bill(TxtRefNo.Text, CDbl(TxtRBalanceAmount.Text) + CDbl(TxtReceipts.Item("amount", TxtReceipts.CurrentRow.Index).Value), txtLedgerName.Text, CDbl(TxtReceipts.Item("transcode", TxtReceipts.CurrentRow.Index).Value))
                frm.ShowDialog()
                LoadBill2BillReceipts()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If TxtReceipts.RowCount = 0 Then Exit Sub
        If MsgBox("Do you want to Delete            ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ExecuteSQLQuery("update ledgerbook set IsDeleted=1 where transcode=" & TxtReceipts.Item("transcode", TxtReceipts.CurrentRow.Index).Value)
            ExecuteSQLQuery("delete from bill2bill where  transcode=" & TxtReceipts.Item("transcode", TxtReceipts.CurrentRow.Index).Value)
            ExecuteSQLQuery("delete from chequeinfo where TransCode=" & TxtReceipts.Item("transcode", TxtReceipts.CurrentRow.Index).Value)
            ExecuteSQLQuery("delete from costcenterbook where TransCode=" & TxtReceipts.Item("transcode", TxtReceipts.CurrentRow.Index).Value)
            LoadBill2BillReceipts()
        End If



    End Sub

    Private Sub SearchStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchStockToolStripMenuItem.Click
        GetStockDets(0, TxtStockCode.Text)
    End Sub

    Private Sub TxtStockCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        If TxtCouponName.Text.Length = 0 Then
            TxtCouponPer.Text = "0"
            TxtCouponPer.Max = 0
            TxtCouponDiscAmount.Text = "0"

        Else
            If IsInvoiceOpen = True Then
                If SQLIsFieldExists("select CouponName from StockInvoiceDetails where CouponName=N'" & TxtCouponName.Text & "' and transcode<>" & OpenedTranscode) = True Then
                    MsgBox("The Coupon Code is not valid or it may be expired, Please try with another one", MsgBoxStyle.Critical)
                Else
                    If IsCouponValid(TxtCouponName.Text, TxtDate) = False Then
                        MsgBox("The Coupon Code is not valid or it may be expired, Please try with another one", MsgBoxStyle.Critical)
                        TxtCouponName.Text = ""
                        TxtCouponPer.Text = "0"
                        TxtCouponPer.Max = 0
                        TxtCouponDiscAmount.Text = "0"

                    Else
                        TxtCouponPer.Text = GetCouponPercentage(TxtCouponName.Text)
                        TxtCouponPer.Max = CInt(TxtCouponPer.Text)
                        TxtCouponDiscAmount.Max = GetCouponMaxValue(TxtCouponName.Text, 0)

                    End If
                End If
            Else
                If IsCouponValid(TxtCouponName.Text, TxtDate) = False Then
                    MsgBox("The Coupon Code is not valid or it may be expired, Please try with another one", MsgBoxStyle.Critical)
                    TxtCouponName.Text = ""
                    TxtCouponPer.Text = "0"
                    TxtCouponPer.Max = 0
                    TxtCouponDiscAmount.Text = "0"

                Else
                    TxtCouponPer.Text = GetCouponPercentage(TxtCouponName.Text)
                    TxtCouponPer.Max = CInt(TxtCouponPer.Text)
                    TxtCouponDiscAmount.Max = GetCouponMaxValue(TxtCouponName.Text, 0)

                End If
            End If

        End If
        FindTotalAmounts()
    End Sub

  

    Private Sub TxtStockCode_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockCode.TextChanged

    End Sub
    Private Sub TxtList_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles TxtList.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right And e.ColumnIndex > -1 And e.RowIndex > -1 Then
            Dim cell As DataGridViewCell = TxtList.Rows(e.RowIndex).Cells(e.ColumnIndex)
            TxtList.CurrentCell = cell
            EditSerialNumbersToolStripMenuItem.Enabled = False
            EditSerialNumbersToolStripMenuItem.Visible = False
            If InvoiceCtrlType = "SI" Or InvoiceCtrlType = "POS" Or InvoiceCtrlType = "SR" Then
                If SQLGetBooleanFieldValue("select allowserialnumbers from stockdbf where stockcode=N'" & TxtList.Item("STItemCode", e.RowIndex).Value & "' and stocksize=N'" & TxtList.Item("stsize", e.RowIndex).Value & "'", "allowserialnumbers") = True Then
                    EditSerialNumbersToolStripMenuItem.Enabled = True
                    EditSerialNumbersToolStripMenuItem.Visible = True
                Else
                    EditSerialNumbersToolStripMenuItem.Enabled = False
                    EditSerialNumbersToolStripMenuItem.Visible = False
                End If
            End If
            Me.TxtListGridMenu.Show(Cursor.Position)
        End If
    End Sub

    Private Sub EditSerialNumbersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditSerialNumbersToolStripMenuItem.Click
        If CDbl(TxtList.Item("StQty", TxtList.CurrentRow.Index).Value) > 300 Then
            MsgBox("The serial Numbers are too long..", MsgBoxStyle.Critical)
            Exit Sub
        Else
            Dim tempcode As Single = 0
            If IsInvoiceOpen = True Then
                tempcode = OpenedTranscode
            Else
                tempcode = 0
            End If
            Dim frm As New ReadSerialNumbers(TxtList.Item("stitemcode", TxtList.CurrentRow.Index).Value, TxtList.Item("StSize", TxtList.CurrentRow.Index).Value, TxtList.Item("StQty", TxtList.CurrentRow.Index).Value, TxtList.Item("stslnos", TxtList.CurrentRow.Index).Value, InvoiceCtrlType, tempcode)
            frm.ShowDialog()
            If frm.HoldList.Length > 0 Then
                TxtList.Item("stslnos", TxtList.CurrentRow.Index).Value = frm.HoldList
            End If
            frm.Dispose()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TxtList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub
    Sub SaveSerialNumbers()
        ExecuteSQLQuery("DELETE FROM stockserialnos WHERE TRANSCODE=" & OpenedTranscode)
        Select Case InvoiceCtrlType
            Case "SD", "POS", "SR", "SI"
                For i As Integer = 0 To TxtList.RowCount - 1
                    Dim HoldList As String = ""
                    HoldList = IIf(TxtList.Item("stslnos", i).Value = Nothing, "", TxtList.Item("stslnos", i).Value)
                    Dim arr As String() = HoldList.Split(",")
                    For k As Integer = 0 To arr.Count - 1
                        If arr(k).Length > 0 Then
                            SaveStockSerialNumberRows(TxtList.Item("STItemCode", i).Value, TxtList.Item("stsize", i).Value, arr(k))
                        End If
                    Next
                Next
        End Select
    End Sub
    Sub SaveStockSerialNumberRows(ByVal scode, ByVal ssize, ByVal slno)
        Dim insstr As String = ""
        Select Case InvoiceCtrlType
            Case "SD", "POS"
                insstr = "INSERT INTO [stockserialnos]([StockCode],[StockSize],[SerialNumber],[transcode],[vouchername])     VALUES (N'" & scode & "',N'" & ssize & "',N'" & slno & "'," & OpenedTranscode & ",'SI')"
                ExecuteSQLQuery(insstr)
            Case "SI"
                insstr = "INSERT INTO [stockserialnos]([StockCode],[StockSize],[SerialNumber],[transcode],[vouchername])     VALUES (N'" & scode & "',N'" & ssize & "',N'" & slno & "'," & OpenedTranscode & ",'SO')"
                ExecuteSQLQuery(insstr)
            Case "SR"
                insstr = "INSERT INTO [stockserialnos]([StockCode],[StockSize],[SerialNumber],[transcode],[vouchername])     VALUES (N'" & scode & "',N'" & ssize & "',N'" & slno & "'," & OpenedTranscode & ",'SR')"
                ExecuteSQLQuery(insstr)
        End Select



    End Sub

    Private Sub TxtVoucherType_Click(sender As Object, e As System.EventArgs) Handles TxtVoucherType.Click
        If SQLIsFieldExists("select Vattax from vatclauses where vattype='CST'") = True Then
            If TxtList.RowCount > 0 Then
                TxtVoucherType.Enabled = False
            Else
                TxtVoucherType.Enabled = True
            End If
        Else
            TxtVoucherType.Enabled = False
        End If
    End Sub

   
    Private Sub SerialNosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub TableForItemRow_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles TableForItemRow.Paint

    End Sub

    Private Sub TxtDiscAmt_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtDiscAmt.TextChanged

    End Sub

    Private Sub TxtStockDiscount2_LostFocus(sender As Object, e As System.EventArgs) Handles TxtStockDiscount2.LostFocus
        FindStockAmount()
    End Sub

    Private Sub TxtStockDiscount2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtStockDiscount2.TextChanged

    End Sub

    Private Sub TxtStockDisc_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtStockDisc.TextChanged

    End Sub

   
    Private Sub TxtStockCode_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtStockCode.KeyPress, TxtStockName.KeyPress
        If TxtStockCode.Text.Length = 0 Then
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
                CheckBeforeSave()
                Exit Sub
            End If

        End If
    End Sub
    Sub LoadBillWiseData(ByVal tcode)
        Dim SqlConn As New SqlClient.SqlConnection
        Bill2Billdetails.Clear()
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from bill2bill where transcode=" & tcode
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            Dim rno As Integer = 0
            While Sreader.Read()
                rno = Bill2Billdetails.BillList.Rows.Add
                Bill2Billdetails.BillList.Item("ttype", rno).Value = Sreader("Billtype").ToString.Trim
                Bill2Billdetails.BillList.Item("tref", rno).Value = Sreader("refno").ToString.Trim
                Bill2Billdetails.BillList.Item("TCode", rno).Value = Sreader("Transcode").ToString.Trim
                Bill2Billdetails.BillList.Item("tamt", rno).Value = Sreader("dr") + Sreader("cr")
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try
        Bill2Billdetails.TransCode = tcode
    End Sub

   
    Private Sub TxtStockCode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtStockCode.Validating
        If TxtStockCode.Text.Length = 0 Then Exit Sub
        If IsEditing = True Then Exit Sub
        GetStockDets(0, TxtStockCode.Text)
        If TxtStockCode.Text.ToUpper <> NewAddItem.StockItemCode.ToUpper Then
            e.Cancel = True
        End If
    End Sub

    

    Private Sub TxtStockQty_QtyGotFocus(e As Object) Handles TxtStockQty.QtyGotFocus
        If TxtStockCode.Text.Length = 0 Then TxtStockCode.Focus()
    End Sub

    Private Sub TxtStockFreeQty_QtyGotFocus(e As Object) Handles TxtStockFreeQty.QtyGotFocus
        If TxtStockCode.Text.Length = 0 Then TxtStockCode.Focus()
    End Sub

   
    Private Sub lblLedgerGroup_Enter(sender As System.Object, e As System.EventArgs) Handles lblLedgerGroup.Enter

    End Sub

    

    Private Sub grpDetails_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles grpDetails.MouseDoubleClick, grpOptions.MouseDoubleClick, lblLedgerGroup.MouseDoubleClick
        HideorunHidepannel()
    End Sub
    Public Sub HideorunHidepannel()
        If TableLayoutPanel1.RowStyles(1).Height < 24 Then
            TableLayoutPanel1.RowStyles(1).Height = 127
            TableLayoutPanel1.RowStyles(4).Height = 129
        Else
            TableLayoutPanel1.RowStyles(1).Height = 15
            TableLayoutPanel1.RowStyles(4).Height = 2
        End If
    End Sub
    Private Sub TxtAdvancePayment_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtAdvancePayment.TextChanged
        Try
            TxtBalanceAmount.Text = FormatNumber(CDbl(TxtNetTotal.Text) - CDbl(TxtAdvancePayment.Text), ErpDecimalPlaces)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtAdvancePayment_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtAdvancePayment.Validating
        If CDbl(TxtAdvancePayment.Text) > CDbl(TxtNetTotal.Text) Then
            MsgBox("The Advance Received Amount is greater than the Bill Total, Please Check again...", MsgBoxStyle.Information)
            e.Cancel = True
        End If
    End Sub

    Private Sub HideorUnhidePanelTooltip_Click(sender As Object, e As System.EventArgs) Handles HideorUnhidePanelTooltip.Click
        HideorunHidepannel()
    End Sub

  
    Private Sub TxtBarCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBarCode.TextChanged

    End Sub

    Private Sub TxtMobileNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMobileNo.LostFocus
        TxtBarCode.Focus()
    End Sub

   
    Private Sub TxtMobileNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMobileNo.TextChanged

    End Sub

    Private Sub TxtStockCode_VisibleChanged(sender As Object, e As System.EventArgs) Handles TxtStockCode.VisibleChanged

    End Sub
End Class
