Imports System.Drawing.Printing
Imports System.Data.SqlClient
Imports System.IO
Public Class PurchaseControlAll

    Dim TxtSalesPerson As New IMSComboBox
    Dim TxtStockTax2 As Double = 0
    Dim Tax2TotalValue As Double = 0

    Dim TxtArea As New IMSComboBox
    Dim isopeningprocess As Boolean = False
    Public NetBillingAmount As Double = 0
    Public IsOpenedOutsideforDelete As Boolean = False
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
    Dim AcountAmountDr As Double
    Dim AcountAmountCr As Double
    Dim SelectedTransList As New ClsSelectInvDB
    Dim OpenedTransList As New ClsSelectInvDB
    Dim CurrentTransList As New ClsSelectInvDB
    Dim OpenedCurrencyRate As Double
    Dim IsOpenedFromOutside As Boolean = False
    Dim InvoiceCtrlType As String = ""
    Dim OpenedPDCValues As New PDCSettingsClass
    Dim Bill2Billdetails As New Bill2BillClass
    Dim IsCopyInvoice As Boolean = False
    Dim IsValueTextChanged As Boolean = False
    Dim IsValuecalculate As Boolean = False
    Dim IsNetRateCalculate As Boolean = False
    Dim IsNetValueTextChanged As Boolean = False
    Dim IsPrintDuplicateInvoice As Boolean = False
    Dim PrintInvoicecopyno As Integer = 1
    Dim OpenedLedgerName As String = ""
    Dim IsBarcodeEntered As Boolean = False
    Dim SalesTrancsationType As String = ""
    Dim IsAddedByBarcode As Boolean = True
    Sub New(ByVal InvoiceType As String, Optional ByVal OpTranscode As Single = 0, Optional ByVal SalesTransType As String = "")
        ' This call is required by the designer.
        InitializeComponent()
        SalesTrancsationType = SalesTransType
        If SalesTrancsationType.Length > 0 Then
            lblInvoiceTitle.Text = SalesTrancsationType
        End If
        InvoiceCtrlType = InvoiceType
        If OpTranscode <> 0 Then
            OpenedTranscode = OpTranscode
            IsOpenedFromOutside = True
        End If
        Select Case InvoiceCtrlType
            Case "PI", "PR", "DP"
            Case Else
                TabControl1.TabPages.RemoveAt(1)
        End Select


        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub TxtList_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles TxtList.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right And e.ColumnIndex > -1 And e.RowIndex > -1 Then
            Dim cell As DataGridViewCell = TxtList.Rows(e.RowIndex).Cells(e.ColumnIndex)
            TxtList.CurrentCell = cell
            EditSerialNumbersToolStripMenuItem.Enabled = False
            EditSerialNumbersToolStripMenuItem.Visible = False
            If InvoiceCtrlType = "PI" Or InvoiceCtrlType = "DP" Or InvoiceCtrlType = "PR" Then
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
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
#Region "FUNCTIONS"
    Sub LoadDisplaySettings()
       
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
            Me.TableForItemRow.ColumnStyles.Item(8).Width = 65
            TxtList.Columns("strateper").Visible = True
            TxtRatePer.Visible = True
        End If
        ' Me.TableForItemRow.ColumnStyles.Item(9).Width = 91
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
            TxtList.Columns("Sttax").Visible = True
            TxtList.Columns("Sttax2").Visible = True
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
        If (InvoiceDisplaySettings.ShowNetRate = False And InvoiceDisplaySettings.ShowTax = False) Or InvoiceDisplaySettings.ShowItemName = False Then
            Me.TableForItemRow.ColumnStyles.Item(7).Width = 180
        End If

        Me.TableForItemRow.ColumnStyles.Item(15).Width = 0
        Me.TableForItemRow.ColumnStyles.Item(16).Width = 65

        If MyAppSettings.IsAllowMultiTaxRatesOnPurchase = False Then
            ' TxtList.Columns("sttax2").Visible = False
            TxtList.Columns("sttaxamount2").Visible = False
        Else
            ' TxtList.Columns("sttax2").Visible = True
            TxtList.Columns("sttaxamount2").Visible = False
        End If
        If InvoiceDisplaySettings.ShowNarration = False Then
            lblNarration.Visible = False
            TxtNarration.Visible = False
        Else
            lblNarration.Visible = True
            TxtNarration.Visible = True
        End If

       

        If InvoiceDisplaySettings.ShowPriceList = False Then
            LblPriceList.Visible = False
            TxtPriceLevel.Visible = False
        Else
            LblPriceList.Visible = True
            TxtPriceLevel.Visible = True
        End If

        'PaymentOptionPanel.Visible = False
        lblDeliverNoteDate.Visible = False
        TxtDelivaryDate.Visible = False
        LblSalesLedger.Visible = False
        TxtPurchaseLedger.Visible = False
        BtnPullData.Visible = True
        TxtBarCode.Visible = True
        btnadditems.Visible = False
        TxtList.Columns("stdnoteno").Visible = False
        Select Case InvoiceCtrlType
            Case "PQ"
                lblDeliverNoteDate.Visible = False
                TxtDelivaryDate.Visible = False
                BtnPullData.Visible = False
                lblInvoiceTitle.Text = "PURCHASE ENQUIRY"
                lblInvoiceNo.Text = "Quote No"
                LblReferenceNo.Text = "Quote Ref"
                Me.TableForItemRow.ColumnStyles.Item(0).Width = 0
                TxtBarCode.Visible = False
                GrpAdvancePayment.Enabled = False
                GrpAdvancePayment.Visible = False
            Case "PO"
                lblDeliverNoteDate.Visible = True
                TxtDelivaryDate.Visible = True
                lblInvoiceTitle.Text = "PURCHASE ORDER"
                lblInvoiceNo.Text = "Order No"
                LblReferenceNo.Text = "Order Ref"
                TxtBarCode.Visible = False
                Me.TableForItemRow.ColumnStyles.Item(0).Width = 0
                GrpAdvancePayment.Enabled = False
                GrpAdvancePayment.Visible = False
            Case "PG"
                LblSalesLedger.Visible = True
                TxtPurchaseLedger.Visible = True
                lblInvoiceTitle.Text = "PURCHASE GOODS RECEIPT"
                lblInvoiceNo.Text = "Receipt No"
                LblReferenceNo.Text = "Receipt Ref"

                'If MyAppSettings.IsShowAdditionalFieldsinSalesDeliveryNote = False Then
                '    'btnadditems.Visible = True
                '    'TxtStockRate.Visible = False
                '    'TxtRatePer.Visible = False
                '    'TxtStockDisc.Visible = False
                '    'TxtStockTax.Visible = False
                '    'TxtStockNetRate.Visible = False
                '    'TxtStockValue.Visible = False

                '    ''Me.TableForItemRow.ColumnStyles.Item(9).Width = 0
                '    ''Me.TableForItemRow.ColumnStyles.Item(10).Width = 0
                '    ''Me.TableForItemRow.ColumnStyles.Item(8).Width = 0
                '    'Me.TableForItemRow.ColumnStyles.Item(9).Width = 0
                '    'Me.TableForItemRow.ColumnStyles.Item(10).Width = 0
                '    'Me.TableForItemRow.ColumnStyles.Item(11).Width = 0
                '    'Me.TableForItemRow.ColumnStyles.Item(12).Width = 80
                '    'Me.TableForItemRow.ColumnStyles.Item(13).Width = 80

                '    btnadditems.Width = 60
                '    TxtList.Columns("StStockTaxValue").Visible = False
                '    TxtList.Columns("stnetrate").Visible = False
                '    TxtList.Columns("sttax").Visible = False
                '    TxtList.Columns("stdiscount").Visible = False
                '    TxtList.Columns("strateper").Visible = False
                '    TxtList.Columns("strate").Visible = False


                'End If

            Case "PI"
                LblSalesLedger.Visible = True
                TxtPurchaseLedger.Visible = True
                lblInvoiceTitle.Text = "PURCHASE INVOICE"
                lblInvoiceNo.Text = "Invoice No"
                LblReferenceNo.Text = "Ref No"
                TxtList.Columns("stdnoteno").Visible = True
            Case "PR"
                LblSalesLedger.Visible = True
                TxtPurchaseLedger.Visible = True
                lblInvoiceTitle.Text = "PURCHASE RETURNS - DEBIT NOTE"
                lblInvoiceNo.Text = "Invoice No"
                LblReferenceNo.Text = "Ref No"
            Case "DP"
                LblSalesLedger.Visible = True
                TxtPurchaseLedger.Visible = True
                lblInvoiceTitle.Text = "PURCHASE INVOICE"
                lblInvoiceNo.Text = "Invoice No"
                LblReferenceNo.Text = "Ref No"
                If SalesTrancsationType.Length > 0 Then
                    lblInvoiceTitle.Text = UCase(SalesTrancsationType)
                Else
                    lblInvoiceTitle.Text = "PURCHASE INVOICE"
                End If
        End Select
        TxtVoucherType.Text = "Tax Invoice"
    End Sub
    Sub LoadDefaults()
        TxtVoucherType.Enabled = True
        TableLayoutPanel1.RowStyles(1).Height = 103
        TableLayoutPanel1.RowStyles(4).Height = 116
        UnLockTransaction(OpenedTranscode)
        CostList.Rows.Clear()
        LblSalesLedger.Visible = False
        NewAddItem.StockItemCode = ""
        TxtPurchaseLedger.Visible = False
        CurrencyLabel.Text = CompDetails.Currency
        TxtBillingCurrency.Text = CompDetails.Currency
        TxtCurrency.Text = CompDetails.Currency
        TxtRateofExchange.Text = "1"
        IsValuesInBillingCurrency.Checked = False
        TxtDate.Value = Now
        TxtSupplierInvoiceNo.Text = ""
        TxtSupplierDate.Value = Now
        TxtAdvancePayment.Text = "0"
        TxtBalanceAmount.Text = "0"
        Try
            TabControl1.SelectedIndex = 1
        Catch ex As Exception

        End Try
        Select Case InvoiceCtrlType
            Case "PO"
                TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.purchaseorder)
                If InvoiceBillingSettings.PurchaseOrderSettings.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
            Case "PI"
                TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.purchaseinvoice)
                If InvoiceBillingSettings.PurchaseInvoicesetting.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
                LblSalesLedger.Visible = True
                TxtPurchaseLedger.Visible = True
            Case "DP"
              
                If InvoiceBillingSettings.PurchaseInvoicesetting.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
                LblSalesLedger.Visible = True
                TxtPurchaseLedger.Visible = True


                If SalesTrancsationType.Length > 0 Then
                    If SalesTrancsationType = "Cash Purchase" Then
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.CASHPURCHASE)
                        If InvoiceBillingSettings.CashPurchaseInvoicesetting.InvoiceMethod = 0 Then
                            TxtQutoNo.Enabled = False
                        Else
                            TxtQutoNo.Enabled = True
                        End If
                    ElseIf SalesTrancsationType = "Credit Purchase" Then
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.CREDITPURCHASE)
                        If InvoiceBillingSettings.CreditPurchaseInvoicesetting.InvoiceMethod = 0 Then
                            TxtQutoNo.Enabled = False
                        Else
                            TxtQutoNo.Enabled = True
                        End If
                    Else
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.purchaseinvoice)
                    End If
                Else
                    TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.purchaseinvoice)
                End If
            Case "PQ"
                TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.purchasequoto)
                If InvoiceBillingSettings.PurchaseQutoSettings.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
            Case "PR"
                TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.PurchaseRetInvoice)
                If InvoiceBillingSettings.PurchaseReturnInvoiceSettings.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
                LblSalesLedger.Visible = True
                TxtPurchaseLedger.Visible = True
            Case "PG"
                TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.purchasereceived)
                If InvoiceBillingSettings.PurchaseGoodReceivedSettings.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
                LblSalesLedger.Visible = True
                TxtPurchaseLedger.Visible = True

        End Select
        TxtRefNo.Text = TxtQutoNo.Text
        If MyAppSettings.IsAllowBatchNoExipry = True Then
            TxtList.Columns("Stbatchno").Visible = True
            TxtList.Columns("stExpiry").Visible = True
        Else
            TxtList.Columns("Stbatchno").Visible = False
            TxtList.Columns("stExpiry").Visible = False
        End If
        Bill2Billdetails.BillList.Rows.Clear()
        LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where (groupname=N'" & AccountGroupNames.SuppliersAccounts & "'  or groupname=N'" & AccountGroupNames.CashAccounts & "'))", txtLedgerName, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')", TxtPurchaseLedger, "ledgername")
        LoadDataIntoComboBox("SELECT Ledgername from ledgers where isactive=1 and (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.DirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "' or groupname=N'" & AccountGroupNames.DirectIncomes & "'))", TxtLedgerName1, "ledgername")
        LoadDataIntoComboBox("SELECT Ledgername from ledgers where isactive=1 and (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.DirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "' or groupname=N'" & AccountGroupNames.DirectIncomes & "'))", TxtLedgerName2, "ledgername")
        LoadDataIntoComboBox("SELECT Ledgername from ledgers where  isactive=1 and (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.DirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "' or groupname=N'" & AccountGroupNames.DirectIncomes & "'))", TxtLedgerName3, "ledgername")
        LoadDataIntoComboBox("select salespersonname from salespersons where isactive=1", TxtSalesPerson, "salespersonname")
        LoadDataIntoComboBox("SELECT ProjectName   FROM projecttable", TxtProject, "ProjectName")
        LoadDataIntoComboBox("SELECT vattax   FROM Vatclauses where vattype='VAT' or vattype='CST'", TxtStockTax, "vattax")
        TxtVoucherType.Text = "Tax Invoice"
        If SQLIsFieldExists("select Vattax from vatclauses where vattype='CST'") = True Then
            TxtVoucherType.Enabled = True
        Else
            TxtVoucherType.Enabled = False
        End If
        If TxtProject.Items.Count > 0 Then
            TxtProject.SelectedIndex = 0
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
        Tax2TotalValue = 0
        TxtDiscount.Text = "0"
        If InvoiceCtrlType = "PR" Then
            TxtPurchaseLedger.Text = DefLedgers.PurchaseRetAccount
        Else
            TxtPurchaseLedger.Text = DefLedgers.PurchaseAccount
        End If

        IsInvoiceOpen = False
        IsInvoiceSaved = True
        TxtNarration.Text = ""
        TxtAmtInwords.Text = ""
        TxtList.Rows.Clear()
        TxtList.SerialNumberColName = "stSno"
        TxtList.HasSerialNumber = True

        TxtList.Columns("stbarcode").Visible = False
        TxtList.Columns("stcustbarcode").Visible = True
        IsOpendByWindows = False
        IsPullFromQuto = False
        TxtDrCr1.Text = "Dr"
        TxtDrCr2.Text = "Dr"
        TxtDrCr3.Text = "Dr"
        TxtLedgerName1.Text = ""
        TxtLedgerName2.Text = ""
        TxtLedgerName3.Text = ""
        TxtLedgerAmount1.Text = "0"
        TxtLedgerAmount2.Text = "0"
        TxtLedgerAmount3.Text = "0"
        OpenedTransList.ListofTrascodeadded.Rows.Clear()
        SelectedTransList.ListofTrascodeadded.Rows.Clear()
        CurrentTransList.ListofTrascodeadded.Rows.Clear()
        MoreDet.Clear()

        IsInvoiceOpen = False
        IsInvoiceSaved = True
    End Sub
#End Region

    Private Sub txtLedgerName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLedgerName.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            NewCreatedLedgerName = ""
            Dim k As New CreateSuppliers
            k.ShowDialog()
            k.Dispose()
            LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "')", txtLedgerName, "ledgername")
            txtLedgerName.Text = NewCreatedLedgerName
            txtLedgerName.Focus()
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

    Private Sub txtLedgerName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLedgerName.LostFocus
        ' If txtLedgerName.IsValidated = False Then Exit Sub
        If SQLIsFieldExists("select ledgername from ledgers where ledgername=N'" & txtLedgerName.Text & "' and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "')") = True Then
            TxtPaymentMethod.Text = "Cash"
            TxtPaymentMethod.Enabled = False
            TxtStockCode.Focus()
        Else
            If TxtPaymentMethod.Text.Length = 0 Then
                TxtPaymentMethod.Text = MyAppSettings.DefaultPaymentMethodOnPurchase
            ElseIf IsInvoiceOpen = False Then
                TxtPaymentMethod.Text = MyAppSettings.DefaultPaymentMethodOnPurchase
            End If

            TxtPaymentMethod.Enabled = True
            TxtStockCode.Focus()
        End If
    End Sub
    Private Sub txtLedgerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLedgerName.SelectedIndexChanged
        ' If txtLedgerName.IsValidated = False Then Exit Sub
        If txtLedgerName.Text.Length = 0 Then
            TxtAddress.Text = ""
            Exit Sub
        End If

        '   TxtAddress.Text = SQLGetStringFieldValue("select address from ledgers where ledgername=N'" & txtLedgerName.Text & "'", "address")
        TxtAddress.Text = SQLGetStringFieldValue("select address+','+state AS ST from ledgers where ledgername=N'" & txtLedgerName.Text & "'", "ST")

        Dim Plevel As String
        Plevel = SQLGetStringFieldValue("select PriceLevel from ledgers where ledgername=N'" & txtLedgerName.Text & "'", "PriceLevel", "")
        If Plevel.Length = 0 Then
            TxtPriceLevel.Text = "Custom"
        Else
            TxtPriceLevel.Text = Plevel
        End If

        IsInvoiceSaved = False
    End Sub


    Private Sub TxtStockCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtStockCode.KeyPress, TxtStockName.KeyPress
        If TxtStockCode.Text.Length = 0 Then
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
                CheckBeforeSave()
                Exit Sub
            End If
        Else
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
                'If sender.Equals(TxtStockCode) = True Then
                '    GetStockDets(0, TxtStockCode.Text)
                'Else
                '    GetStockDets(1, TxtStockName.Text)

                'End If
            End If

        End If

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
        k.ShowDialog()
        k.Dispose()
        If bvalue.StockItemBarCode.Length <> 0 Then
            LoadStockItemsIntoClass(bvalue.StockItemBarCode, bvalue.StockLocation, NewAddItem)
            TxtStockDisc.Text = "0"
            TxtStockValue.Text = "0"
            TxtStockCode.Text = NewAddItem.StockItemCode
            TxtStockName.Text = NewAddItem.StockItemName
            TxtStockSize.Text = NewAddItem.StockITemSize
            TxtMRP.Text = NewAddItem.MRP
            If MyAppSettings.IsZEROTAXONPURCHASE = True Then
                NewAddItem.Tax = 0
                NewAddItem.Tax2 = 0
            End If
            If TxtVoucherType.Text = "Tax Invoice" Then
                If IsSalesPriceAsMRPWithOutVAT = True Then
                    TxtStockTax.Text = 0
                Else
                    TxtStockTax.Text = NewAddItem.Tax
                End If
                TxtStockTax2 = NewAddItem.Tax2
            Else
                TxtStockTax.Text = NewAddItem.CSTtax

                TxtStockTax2 = 0
                NewAddItem.Tax2 = 0
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
            TxtStockRate.Text = FormatNumber(NewAddItem.StockRate / CDbl(TxtRateofExchange.Text), 3, , , TriState.False)
            TxtBatchNo.Text = ""
            TxtBatchNo.Items.Clear()
            If NewAddItem.IsBatchNo = 1 Then
                LoadDataIntoComboBox("select batchno from stockbatch where stockcode=N'" & NewAddItem.StockItemCode & "' and stocksize=N'" & NewAddItem.StockITemSize & "' and location=N'" & NewAddItem.StockLocation & "'", TxtBatchNo, "batchno", "")
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
        bvalue = Nothing
        k.Dispose()
    End Sub

    Private Sub TxtStockNetRate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtStockNetRate.GotFocus
        IsNetRateCalculate = True
        IsNetValueTextChanged = False
    End Sub


    Private Sub TxtStockRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockRate.TextChanged, TxtRatePer.SelectedIndexChanged, TxtStockDisc.TextChanged, TxtStockNetRate.TextChanged, TxtStockTax.TextChanged, TxtStockTax.TextChanged, TxtStockDiscount2.TextChanged, TxtMRP.TextChanged
        FindStockAmount()
    End Sub
    Sub FindStockAmount()
        Dim NetRate As Double = 0
        Try
            'CALCULATE NET RATE FOR  DISCOUNT
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

    Sub FindTotalAmounts()
        Dim Tot As Double = 0
        Dim nettot As Double = 0
        Dim TaxTotal As Double = 0
        Tax2TotalValue = 0
        Try
            For i As Integer = 0 To TxtList.RowCount - 1
                Tot = Tot + CDbl(TxtList.Item("stStockvalueWithOutTax", i).Value)
                TaxTotal = TaxTotal + CDbl(TxtList.Item("sttaxamount", i).Value)
                Try
                    Tax2TotalValue = Tax2TotalValue + CDbl(TxtList.Item("sttaxamount2", i).Value)
                Catch ex As Exception

                End Try
                If Len(TxtList.Item("TUTRANSCODE", i).Value) > 0 Then
                    TxtList.Item("stdnoteno", i).Value = SQLGetStringFieldValue("select qutono from StockInvoiceDetails where vouchername='PG' and transcode=" & TxtList.Item("TUTRANSCODE", i).Value, "qutono")
                Else
                    TxtList.Item("stdnoteno", i).Value = ""
                End If
            Next
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

            TxtNetTotal.Text = FormatNumber(Tot + CDbl(TxtDiscAmt.Text) + TaxTotal + Tax2TotalValue + CDbl(TxtServiceAccountAmount.Text) + CDbl(TxtDeductions.Text), ErpDecimalPlaces, , , TriState.False)


            NetBillingAmount = CDbl(TxtNetTotal.Text)
        Catch ex As Exception

        End Try
        If TxtList.RowCount > 0 Then
            TxtVoucherType.Enabled = False
        Else
            TxtVoucherType.Enabled = True
        End If
    End Sub
    Private Sub TxtStockQty_QtyChanageEvent(ByVal e As Object) Handles TxtStockQty.QtyChanageEvent, TxtStockFreeQty.QtyChanageEvent
        FindStockAmount()
    End Sub

    Private Sub TxtStockQty_QtyLostFocus(ByVal e As Object) Handles TxtStockQty.QtyLostFocus, TxtStockFreeQty.QtyLostFocus
        FindStockAmount()
    End Sub

 



    Private Sub SalesQuotoControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDataIntoComboBox("select currencycode from currencylist", TxtCurrency, "Currencycode")
        LoadDataIntoComboBox("select CurrencyCode from currencylist ", TxtBillingCurrency, "CurrencyCode")

        If InvoiceCtrlType = "DP" Or InvoiceCtrlType = "PI" Or InvoiceCtrlType = "PR" Then
            LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')", TxtPaymentBy, "ledgername")
            TxtPaymentMethod.Items.Clear()
            TxtPaymentMethod.Items.Add("Cash")
            TxtPaymentMethod.Items.Add("Card")
            TxtPaymentMethod.Items.Add("Gift Voucher")
            TxtPaymentMethod.Items.Add("Voucher")
            TxtPaymentMethod.Items.Add("Credit")
        Else
            LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "')", txtLedgerName, "ledgername")
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
        ToolTip1.SetToolTip(grpDetails, "Double click to hide/unhide the details  to Increase/Decrease the Item List")
        ToolTip2.SetToolTip(grpOptions, "Double click to hide/unhide the details  to Increase/Decrease the Item List")
        ToolTip3.SetToolTip(lblLedgerGroup, "Double click to hide/unhide the details  to Increase/Decrease the Item List")
    End Sub
    Sub LoadStockEntryDefaults()
        TxtStockCode.Text = ""
        TxtStockSize.Text = ""
        TxtBarCode.Text = ""
        TxtStockName.Text = ""
        TxtStockTax.Text = "0"
        TxtStockTax2 = 0
        TxtStockNetRate.Text = "0"
        TxtRatePer.Text = ""
        TxtStockQty.ClearQty()
        TxtStockQty.TxtQty1.Text = "1"
        TxtStockFreeQty.ClearQty()
        TxtStockFreeQty.TxtQty1.Text = "0"
        TxtMRP.Text = "0"
        TxtStockDisc.Text = "0"
        TxtStockRate.Text = "0"
        TxtBatchNo.Text = ""
        TxtStockValue.Text = "0"
        IsEditItem = False
        BtnEditCancel.Visible = False
        TxtStockDiscount2.Text = "0"
        TxtList.Enabled = True
    End Sub

    Private Sub TxtStockValue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtStockValue.GotFocus
        IsValuecalculate = True
        IsValueTextChanged = False
    End Sub

    Private Sub TxtStockValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtStockValue.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            Additems()
        End If
    End Sub
    Sub Additems()
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
                    If MyAppSettings.IsAllowMultiTaxRatesOnPurchase = False Then
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
                    If MyAppSettings.IsAllowMultiTaxRatesOnPurchase = False Then
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
                If MyAppSettings.IsAllowMultiTaxRatesOnPurchase = False Then
                    TxtList.Item("sttax2", nR).Value = 0
                Else
                    TxtList.Item("sttax2", nR).Value = NewAddItem.Tax2
                End If
                TxtList.Item("stmrp", nR).Value = CDbl(TxtMRP.Text)
                TxtList.Item("stpacking", nR).Value = NewAddItem.Packing
                TxtList.Item("stconrate", nR).Value = CDbl(TxtRateofExchange.Text)
                'stconrate
                'CALCULATE   TAX AMOUNT
                If TxtBatchNo.Text.Length > 0 Then
                    NewAddItem.StockExpirydate = CDate(SQLGetStringFieldValue("SELECT Expiry FROM STOCKBATCH WHERE STOCKCODE=N'" & NewAddItem.StockItemCode & "' AND STOCKSIZE=N'" & NewAddItem.StockITemSize & "' AND LOCATION=N'" & NewAddItem.StockLocation & "' AND BATCHNO=N'" & TxtBatchNo.Text & "'", "Expiry"))
                    TxtList.Item("stExpiry", nR).Value = NewAddItem.StockExpirydate
                Else
                    TxtList.Item("stExpiry", nR).Value = ""
                End If

                If TxtList.RowCount > 3 Then
                    TxtList.FirstDisplayedCell = TxtList.Item(0, TxtList.RowCount - (TxtList.DisplayedRowCount(False)) + 1)
                End If
                LoadStockEntryDefaults()
                FindTotalAmounts()
                TxtStockCode.Focus()
                IsInvoiceSaved = False
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
                    If MyAppSettings.IsAllowMultiTaxRatesOnPurchase = False Then
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
                    If MyAppSettings.IsAllowMultiTaxRatesOnPurchase = False Then
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
                If MyAppSettings.IsAllowMultiTaxRatesOnPurchase = False Then
                    TxtList.Item("sttax2", nR).Value = 0
                Else
                    TxtList.Item("sttax2", nR).Value = NewAddItem.Tax2
                End If
                TxtList.Item("tutranscode", nR).Value = 0
                TxtList.Item("stpacking", nR).Value = NewAddItem.Packing
                TxtList.Item("stmrp", nR).Value = TxtMRP.Text
                TxtList.Item("stconrate", nR).Value = CDbl(TxtRateofExchange.Text)
                If TxtBatchNo.Text.Length > 0 Then
                    NewAddItem.StockExpirydate = CDate(SQLGetStringFieldValue("SELECT Expiry FROM STOCKBATCH WHERE STOCKCODE=N'" & NewAddItem.StockItemCode & "' AND STOCKSIZE=N'" & NewAddItem.StockITemSize & "' AND LOCATION=N'" & NewAddItem.StockLocation & "' AND BATCHNO=N'" & TxtBatchNo.Text & "'", "Expiry"))
                    TxtList.Item("stExpiry", nR).Value = NewAddItem.StockExpirydate
                Else
                    TxtList.Item("stExpiry", nR).Value = ""
                End If
                If TxtList.RowCount > 3 Then
                    TxtList.FirstDisplayedCell = TxtList.Item(0, TxtList.RowCount - (TxtList.DisplayedRowCount(False)) + 1)
                End If
                TxtList.Item("stslnos", nR).Value = ""
                LoadStockEntryDefaults()
                FindTotalAmounts()
                TxtStockCode.Focus()
                IsInvoiceSaved = False
            End If
        End If
        If IsBarcodeEntered = True Then
            TxtBarCode.Focus()
        End If
    End Sub
    Sub UpdateOrderedItemsQtys()
        If InvoiceCtrlType = "PG" Or InvoiceCtrlType = "DP" Or InvoiceCtrlType = "PI" Then
            For i As Integer = 0 To TxtList.RowCount - 1
                If Len(TxtList.Item("TUTRANSCODE", i).Value) = 0 Then Exit Sub
                If Len(TxtList.Item("stqty", i).Value) = 0 Then
                    TxtList.Item("stqty", i).Value = "0"
                End If
                If SQLIsFieldExists("select barcode from StockInvoiceRowItems WHERE  TRANSCODE=" & TxtList.Item("TUTRANSCODE", i).Value & " and barcode=N'" & TxtList.Item("StBarCode", i).Value & "' and (usedqty is null) and batchno=N'" & TxtList.Item("Stbatchno", i).Value & "'") = True Then
                    ExecuteSQLQuery("UPDATE StockInvoiceRowItems SET USEDQTY=0 WHERE TRANSCODE=" & TxtList.Item("TUTRANSCODE", i).Value & " and barcode=N'" & TxtList.Item("StBarCode", i).Value & "' and batchno=N'" & TxtList.Item("Stbatchno", i).Value & "'")
                End If
                ExecuteSQLQuery("UPDATE StockInvoiceRowItems SET USEDQTY=USEDQTY+" & CDbl(TxtList.Item("stqty", i).Value) & " WHERE TRANSCODE=" & TxtList.Item("TUTRANSCODE", i).Value & " and barcode=N'" & TxtList.Item("StBarCode", i).Value & "' and batchno=N'" & TxtList.Item("Stbatchno", i).Value & "'")
            Next
        End If
    End Sub



    Private Sub TxtDiscount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDiscAmt.TextChanged, TxtDiscAmt.TextChanged
        'FindTotalAmounts()
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
        If DefLedgers.PurchaseDiscountLedger.Length = 0 Then
            MsgBox("Please set the default ledger for the Purchase Discount...      ", MsgBoxStyle.Information)
            Exit Sub
        End If
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
                End If
            End If

        End If
        If TxtRefNo.Text.Length = 0 Then
            MsgBox("Please Enter the Reference Number....")
            TxtRefNo.Focus()
            Exit Sub
        End If

        If txtLedgerName.Text.Length = 0 Then
            MsgBox("Please Select the Account Name      ", MsgBoxStyle.Information)
            txtLedgerName.Focus()
            Exit Sub
        End If
        TableLayoutPanel1.RowStyles(1).Height = 103
        TableLayoutPanel1.RowStyles(4).Height = 116
        If TxtList.RowCount = 0 Then
            MsgBox("Please Select the Items, Press any key to add items at item code or item name fileds...")
            TxtStockCode.Focus()
            Exit Sub
        End If
        If CDbl(TxtGrossTotal.Text) < 0 Then
            MsgBox("Please Select the Items, Press any key to add items at item code or item name fileds...")
            TxtStockCode.Focus()
            Exit Sub
        End If
        If TxtCurrency.Text.Length = 0 Then
            MsgBox("Please select the Currency Code...  ", MsgBoxStyle.Information)
            TxtCurrency.Focus()
            Exit Sub
        End If
        If CDbl(TxtNetTotal.Text) < 0 Then
            MsgBox("Please Select the Items, Press any key to add items at item code or item name fileds...")
            TxtStockCode.Focus()
            Exit Sub
        End If
        If CDbl(TxtAdvancePayment.Text) > CDbl(TxtNetTotal.Text) Then
            MsgBox("The Advance Paid Amount is greater than the Bill Total, Please Check again...", MsgBoxStyle.Information)
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

        Select Case InvoiceCtrlType
            Case "PG", "PR", "PI", "DP"
                If TxtPurchaseLedger.Text.Length = 0 Then
                    MsgBox("Please Select the Purchase Account Ledger      ", MsgBoxStyle.Information)
                    TxtPurchaseLedger.Focus()
                    Exit Sub
                End If
        End Select

        If InvoiceCtrlType = "DP" Or InvoiceCtrlType = "PI" Or InvoiceCtrlType = "PR" Then
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
            If InvoiceCtrlType = "PR" Or InvoiceCtrlType = "PG" Or InvoiceCtrlType = "DP" Then
                If SQLGetStringFieldValue("select IsAllowCostCentre from ledgers where ledgername=N'" & txtLedgerName.Text & "'", "IsAllowCostCentre", False) = True Then
                    Dim lfrm As New Costcenterallocation(CostList, TxtNetTotal.Text, txtLedgerName.Text)
                    lfrm.ShowDialog()
                    lfrm = Nothing
                Else
                    CostList.Rows.Clear()
                End If
            End If
        End If
        If InvoiceCtrlType = "PR" And TxtPaymentMethod.Text <> "Cash" Then
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
    Sub SaveTrasactions(ByVal Trancode As Single)

        Dim SqlStr As String = ""
        Dim sno As Integer = 1
        SqlStr = "INSERT INTO [LedgerBook] ([LedgerName],[TransCode],[InvoiceNo],[InvoiceName],[sno],[Dr],[Cr],[TransDate], " _
          & "[TransDateValue],[LedgerGroup],[AcLedger],[IsAdvance],[IsDeleted],[UserName],[StoreName],[Narration],[InvoiceType],[RefNo],[CurrencyCode],[ConRate],CounterID) " _
          & " VALUES (@LedgerName,@TransCode,@InvoiceNo,@InvoiceName,@sno,@Dr,@Cr,@TransDate,@TransDateValue,@LedgerGroup, " _
          & "@AcLedger,@IsAdvance,@IsDeleted,@UserName,@StoreName,@Narration,@InvoiceType,@RefNo,@CurrencyCode,@ConRate,@CounterID) "

        If InvoiceCtrlType = "PI" Or InvoiceCtrlType = "DP" Or InvoiceCtrlType = "PR" Then
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
                        Case "PO"
                            .AddWithValue("InvoiceName", "PurchaseOrder")
                            .AddWithValue("InvoiceType", "PurchaseOrder")
                        Case "PI", "DP"
                            .AddWithValue("InvoiceName", "PurchaseInvoice")
                            .AddWithValue("InvoiceType", "PurchaseInvoice")
                        Case "PQ"
                            .AddWithValue("InvoiceName", "PurchaseQuote")
                            .AddWithValue("InvoiceType", "PurchaseQuote")
                        Case "PR"
                            .AddWithValue("InvoiceName", "DebitNote")
                            .AddWithValue("InvoiceType", "DebitNote")
                        Case "PG"
                            .AddWithValue("InvoiceName", "PurchaseGoods")
                            .AddWithValue("InvoiceType", "PurchaseGoods")

                    End Select

                    .AddWithValue("sno", sno)
                    sno = sno + 1
                    Select Case InvoiceCtrlType

                        Case "PI", "PG", "DP"
                            .AddWithValue("Dr", CDbl(TxtNetTotal.Text))
                            .AddWithValue("Cr", 0)
                        Case "PR"
                            .AddWithValue("Dr", 0)
                            .AddWithValue("Cr", CDbl(TxtNetTotal.Text))
                    End Select

                    .AddWithValue("TransDate", TxtDate.Value)
                    .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                    .AddWithValue("LedgerGroup", "")
                    .AddWithValue("CurrencyCode", TxtCurrency.Text)
                    .AddWithValue("ConRate", OpenedCurrencyRate)
                    .AddWithValue("AcLedger", TxtPurchaseLedger.Text)
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
                        Case "PO"
                            .AddWithValue("InvoiceName", "PurchaseOrder")
                            .AddWithValue("InvoiceType", "PurchaseOrder")
                        Case "PI", "DP"
                            .AddWithValue("InvoiceName", "PurchaseInvoice")
                            .AddWithValue("InvoiceType", "PurchaseInvoice")
                        Case "PQ"
                            .AddWithValue("InvoiceName", "PurchaseQuote")
                            .AddWithValue("InvoiceType", "PurchaseQuote")
                        Case "PR"
                            .AddWithValue("InvoiceName", "DebitNote")
                            .AddWithValue("InvoiceType", "DebitNote")
                        Case "PG"
                            .AddWithValue("InvoiceName", "PurchaseGoods")
                            .AddWithValue("InvoiceType", "PurchaseGoods")

                    End Select
                    .AddWithValue("sno", sno)
                    sno = sno + 1
                    Select Case InvoiceCtrlType

                        Case "PI", "PG", "DP"
                            .AddWithValue("Dr", 0)
                            .AddWithValue("Cr", CDbl(TxtNetTotal.Text))
                        Case "PR"
                            .AddWithValue("Dr", CDbl(TxtNetTotal.Text))
                            .AddWithValue("Cr", 0)
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
                Case "PO"
                    .AddWithValue("InvoiceName", "PurchaseOrder")
                    .AddWithValue("InvoiceType", "PurchaseOrder")
                Case "PI", "DP"
                    .AddWithValue("InvoiceName", "PurchaseInvoice")
                    .AddWithValue("InvoiceType", "PurchaseInvoice")
                Case "PQ"
                    .AddWithValue("InvoiceName", "PurchaseQuote")
                    .AddWithValue("InvoiceType", "PurchaseQuote")
                Case "PR"
                    .AddWithValue("InvoiceName", "DebitNote")
                    .AddWithValue("InvoiceType", "DebitNote")
                Case "PG"
                    .AddWithValue("InvoiceName", "PurchaseGoods")
                    .AddWithValue("InvoiceType", "PurchaseGoods")

            End Select
            .AddWithValue("sno", sno)
            sno = sno + 1
            Select Case InvoiceCtrlType

                Case "PI", "PG", "DP"
                    .AddWithValue("Dr", 0)
                    .AddWithValue("Cr", CDbl(TxtNetTotal.Text))
                Case "PR"
                    .AddWithValue("Dr", CDbl(TxtNetTotal.Text))
                    .AddWithValue("Cr", 0)
            End Select

            .AddWithValue("TransDate", TxtDate.Value)
            .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
            .AddWithValue("LedgerGroup", "")
            .AddWithValue("CurrencyCode", TxtCurrency.Text)
            .AddWithValue("ConRate", OpenedCurrencyRate)
            .AddWithValue("AcLedger", TxtPurchaseLedger.Text)
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
                SaveCSTTaxes(Trancode, sno)
            End If
        ElseIf SQLGetNumericFieldValue("select count(*) as tot from Vatclauses where vattype='VAT'", "tot") > 0 Then
            SaveVatTaxes(Trancode, sno)
            SaveVatTaxes2(Trancode, sno)
        Else

            DBFR = New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBFR.Parameters
                .AddWithValue("LedgerName", TxtPurchaseLedger.Text)
                .AddWithValue("TransCode", Trancode)
                .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                .AddWithValue("sno", sno)
                sno = sno + 1
                Select Case InvoiceCtrlType
                    Case "PI", "PG", "DP"
                        .AddWithValue("Dr", CDbl(TxtGrossTotal.Text))
                        .AddWithValue("Cr", 0)
                    Case "PR"
                        .AddWithValue("Dr", 0)
                        .AddWithValue("Cr", CDbl(TxtGrossTotal.Text))
                End Select
                .AddWithValue("CurrencyCode", TxtCurrency.Text)
                .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TxtPurchaseLedger.Text & "'", "currency").ToString))
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
                    Case "PO"
                        .AddWithValue("InvoiceName", "PurchaseOrder")
                        .AddWithValue("InvoiceType", "PurchaseOrder")
                    Case "PI", "DP"
                        .AddWithValue("InvoiceName", "PurchaseInvoice")
                        .AddWithValue("InvoiceType", "PurchaseInvoice")
                    Case "PQ"
                        .AddWithValue("InvoiceName", "PurchaseQuote")
                        .AddWithValue("InvoiceType", "PurchaseQuote")
                    Case "PR"
                        .AddWithValue("InvoiceName", "DebitNote")
                        .AddWithValue("InvoiceType", "DebitNote")
                    Case "PG"
                        .AddWithValue("InvoiceName", "PurchaseGoods")
                        .AddWithValue("InvoiceType", "PurchaseGoods")

                End Select
                .AddWithValue("RefNo", TxtRefNo.Text)
                .AddWithValue("CounterID", CurrentCounterID)
            End With
            DBFR.ExecuteNonQuery()
            DBFR = Nothing
            '

        End If

        If CDbl(TxtDiscAmt.Text) <> 0 Then
         

            Dim DBFR5 As SqlClient.SqlCommand
            DBFR5 = New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBFR5.Parameters
                .AddWithValue("LedgerName", DefLedgers.PurchaseDiscountLedger)
                .AddWithValue("TransCode", Trancode)
                .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                .AddWithValue("InvoiceName", "PurchaseInvoice")
                .AddWithValue("InvoiceType", "PurchaseInvoice")
                .AddWithValue("sno", sno)
                sno = sno + 1
                If CDbl(TxtDiscAmt.Text) > 0 Then
                    .AddWithValue("Dr", CDbl(TxtDiscAmt.Text))
                    .AddWithValue("Cr", 0)
                Else
                    .AddWithValue("Dr", 0)
                    .AddWithValue("Cr", CDbl(TxtDiscAmt.Text) * -1)
                End If


                .AddWithValue("TransDate", TxtDate.Value)
                .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                .AddWithValue("LedgerGroup", "")
                .AddWithValue("CurrencyCode", CompDetails.Currency)
                .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & DefLedgers.PurchaseDiscountLedger & "'", "currency").ToString))
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
                    Case "PO"
                        .AddWithValue("InvoiceName", "PurchaseOrder")
                        .AddWithValue("InvoiceType", "PurchaseOrder")
                    Case "PI", "DP"
                        .AddWithValue("InvoiceName", "PurchaseInvoice")
                        .AddWithValue("InvoiceType", "PurchaseInvoice")
                    Case "PQ"
                        .AddWithValue("InvoiceName", "PurchaseQuote")
                        .AddWithValue("InvoiceType", "PurchaseQuote")
                    Case "PR"
                        .AddWithValue("InvoiceName", "DebitNote")
                        .AddWithValue("InvoiceType", "DebitNote")
                    Case "PG"
                        .AddWithValue("InvoiceName", "PurchaseGoods")
                        .AddWithValue("InvoiceType", "PurchaseGoods")
                End Select
                .AddWithValue("sno", sno)
                sno = sno + 1
                Select Case InvoiceCtrlType
                    Case "PI", "PG", "DP"
                        .AddWithValue("Dr", CDbl(TxtAdvancePayment.Text))
                        .AddWithValue("Cr", 0)
                    Case "PR"
                        .AddWithValue("Dr", 0)
                        .AddWithValue("Cr", CDbl(TxtAdvancePayment.Text))
                End Select

                .AddWithValue("TransDate", TxtDate.Value)
                .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                .AddWithValue("LedgerGroup", "")
                .AddWithValue("CurrencyCode", CompDetails.Currency)
                .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & txtLedgerName.Text & "'", "currency").ToString))
                .AddWithValue("AcLedger", TxtPurchaseLedger.Text)
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
                    Case "PO"
                        .AddWithValue("InvoiceName", "PurchaseOrder")
                        .AddWithValue("InvoiceType", "PurchaseOrder")
                    Case "PI", "DP"
                        .AddWithValue("InvoiceName", "PurchaseInvoice")
                        .AddWithValue("InvoiceType", "PurchaseInvoice")
                    Case "PQ"
                        .AddWithValue("InvoiceName", "PurchaseQuote")
                        .AddWithValue("InvoiceType", "PurchaseQuote")
                    Case "PR"
                        .AddWithValue("InvoiceName", "DebitNote")
                        .AddWithValue("InvoiceType", "DebitNote")
                    Case "PG"
                        .AddWithValue("InvoiceName", "PurchaseGoods")
                        .AddWithValue("InvoiceType", "PurchaseGoods")
                End Select
                .AddWithValue("sno", sno)
                sno = sno + 1
                Select Case InvoiceCtrlType
                    Case "PI", "PG", "DP"
                        .AddWithValue("Dr", 0)
                        .AddWithValue("Cr", CDbl(TxtAdvancePayment.Text))
                    Case "PR"
                        .AddWithValue("Dr", CDbl(TxtAdvancePayment.Text))
                        .AddWithValue("Cr", 0)
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

        'If CDbl(TxtRoundoff.Text) <> 0 Then
        '    SqlStr = "INSERT INTO [LedgerBook] ([LedgerName],[TransCode],[InvoiceNo],[InvoiceName],[sno],[Dr],[Cr],[TransDate], " _
        '   & "[TransDateValue],[LedgerGroup],[AcLedger],[IsAdvance],[IsDeleted],[UserName],[StoreName],[Narration],[InvoiceType],[RefNo],[CurrencyCode],[ConRate]) " _
        '   & " VALUES (@LedgerName,@TransCode,@InvoiceNo,@InvoiceName,@sno,@Dr,@Cr,@TransDate,@TransDateValue,@LedgerGroup, " _
        '   & "@AcLedger,@IsAdvance,@IsDeleted,@UserName,@StoreName,@Narration,@InvoiceType,@RefNo,@CurrencyCode,@ConRate) "

        '    Dim DBFR5 As SqlClient.SqlCommand
        '    DBFR5 = New SqlClient.SqlCommand(SqlStr, MAINCON)
        '    With DBFR5.Parameters
        '        .AddWithValue("LedgerName", DefLedgers.Roundoffledger)
        '        .AddWithValue("TransCode", Trancode)
        '        .AddWithValue("InvoiceNo", TxtBillNo.Text)
        '        .AddWithValue("InvoiceName", "PurchaseInvoice")
        '        .AddWithValue("InvoiceType", "PurchaseInvoice")
        '        .AddWithValue("sno", sno)
        '        sno = sno + 1
        '        If CDbl(TxtRoundoff.Text) > 0 Then
        '            .AddWithValue("Dr", CDbl(TxtRoundoff.Text))
        '            .AddWithValue("Cr", 0)
        '        Else
        '            .AddWithValue("Dr", 0)
        '            .AddWithValue("Cr", CDbl(TxtRoundoff.Text) * -1)
        '        End If

        '        .AddWithValue("TransDate", TxtDate.Value.Date)
        '        .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
        '        .AddWithValue("LedgerGroup", "")
        '        .AddWithValue("CurrencyCode", CompDetails.Currency)
        '        .AddWithValue("ConRate", 1)
        '        .AddWithValue("AcLedger", txtledgername.Text)
        '        .AddWithValue("IsAdvance", 1)
        '        .AddWithValue("IsDeleted", 0)
        '        .AddWithValue("UserName", CurrentUserName)
        '        .AddWithValue("StoreName", DefStoreName)
        '        .AddWithValue("Narration", TxtNarration.Text)
        '        .AddWithValue("RefNo", TxtBillNo.Text)
        '    End With
        '    DBFR5.ExecuteNonQuery()
        '    DBFR5 = Nothing
        'End If

        If TxtLedgerAmount1.Text.Length = 0 Then
            TxtLedgerAmount1.Text = "0"
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
                .AddWithValue("AcLedger", TxtPurchaseLedger.Text)
                .AddWithValue("IsAdvance", 1)
                .AddWithValue("IsDeleted", 0)
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Narration", TxtNarration.Text)
                Select Case InvoiceCtrlType
                    Case "PO"
                        .AddWithValue("InvoiceName", "PurchaseOrder")
                        .AddWithValue("InvoiceType", "PurchaseOrder")
                    Case "PI", "DP"
                        .AddWithValue("InvoiceName", "PurchaseInvoice")
                        .AddWithValue("InvoiceType", "PurchaseInvoice")
                    Case "PQ"
                        .AddWithValue("InvoiceName", "PurchaseQuote")
                        .AddWithValue("InvoiceType", "PurchaseQuote")
                    Case "PR"
                        .AddWithValue("InvoiceName", "DebitNote")
                        .AddWithValue("InvoiceType", "DebitNote")
                    Case "PG"
                        .AddWithValue("InvoiceName", "PurchaseGoods")
                        .AddWithValue("InvoiceType", "PurchaseGoods")

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
                .AddWithValue("AcLedger", TxtPurchaseLedger.Text)
                .AddWithValue("IsAdvance", 1)
                .AddWithValue("IsDeleted", 0)
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Narration", TxtNarration.Text)
                Select Case InvoiceCtrlType
                    Case "PO"
                        .AddWithValue("InvoiceName", "PurchaseOrder")
                        .AddWithValue("InvoiceType", "PurchaseOrder")
                    Case "PI", "DP"
                        .AddWithValue("InvoiceName", "PurchaseInvoice")
                        .AddWithValue("InvoiceType", "PurchaseInvoice")
                    Case "PQ"
                        .AddWithValue("InvoiceName", "PurchaseQuote")
                        .AddWithValue("InvoiceType", "PurchaseQuote")
                    Case "PR"
                        .AddWithValue("InvoiceName", "DebitNote")
                        .AddWithValue("InvoiceType", "DebitNote")
                    Case "PG"
                        .AddWithValue("InvoiceName", "PurchaseGoods")
                        .AddWithValue("InvoiceType", "PurchaseGoods")

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
                .AddWithValue("AcLedger", TxtPurchaseLedger.Text)
                .AddWithValue("IsAdvance", 1)
                .AddWithValue("IsDeleted", 0)
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Narration", TxtNarration.Text)
                Select Case InvoiceCtrlType
                    Case "PO"
                        .AddWithValue("InvoiceName", "PurchaseOrder")
                        .AddWithValue("InvoiceType", "PurchaseOrder")
                    Case "PI", "DP"
                        .AddWithValue("InvoiceName", "PurchaseInvoice")
                        .AddWithValue("InvoiceType", "PurchaseInvoice")
                    Case "PQ"
                        .AddWithValue("InvoiceName", "PurchaseQuote")
                        .AddWithValue("InvoiceType", "PurchaseQuote")
                    Case "PR"
                        .AddWithValue("InvoiceName", "DebitNote")
                        .AddWithValue("InvoiceType", "DebitNote")
                    Case "PG"
                        .AddWithValue("InvoiceName", "PurchaseGoods")
                        .AddWithValue("InvoiceType", "PurchaseGoods")

                End Select
                .AddWithValue("RefNo", TxtRefNo.Text)
                .AddWithValue("CounterID", CurrentCounterID)
            End With
            DBFR.ExecuteNonQuery()
            DBFR = Nothing
        End If

        MAINCON.Close()




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
                        TempLedgerName = SQLGetStringFieldValue("select PurchaseLedger from vatclauses where vattype='VAT' and vattax=0", "PurchaseLedger")
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
                        TempLedgerName = SQLGetStringFieldValue("select DebitNoteLedger from vatclauses where  vattype='VAT' and  vattax=0", "DebitNoteLedger")
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
                        TempLedgerName = SQLGetStringFieldValue("select SalesLedger from vatclauses where  vattype='VAT' and  vattax=0", "SalesLedger")
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
                        TempLedgerName = SQLGetStringFieldValue("select CreditLedger from vatclauses where  vattype='VAT' and  vattax=0", "CreditLedger")
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
                        TempLedgerName = SQLGetStringFieldValue("select PurchaseLedger from vatclauses where  vattype='VAT' and  vattax=" & Sreader("tax"), "PurchaseLedger")
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
                        TempLedgerName = SQLGetStringFieldValue("select SalesLedger from vatclauses where  vattype='VAT' and  vattax=" & Sreader("tax"), "SalesLedger")
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
                        TempLedgerName = SQLGetStringFieldValue("select outputvatledger from vatclauses where  vattype='VAT' and vattax=" & Sreader("tax"), "outputvatledger")
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
                        TempLedgerName = SQLGetStringFieldValue("select outputvatledger from vatclauses where vattype='VAT' and  vattax=" & Sreader("tax"), "outputvatledger")
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
    Sub SaveCSTTaxes(ByVal Tcode As Double, ByRef sno As Integer)
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
                        TempLedgerName = SQLGetStringFieldValue("select PurchaseLedger from vatclauses where vattype='CST' and vattax=0", "PurchaseLedger")
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
                        TempLedgerName = SQLGetStringFieldValue("select DebitNoteLedger from vatclauses where  vattype='CST' and  vattax=0", "DebitNoteLedger")
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
                        TempLedgerName = SQLGetStringFieldValue("select SalesLedger from vatclauses where  vattype='CST' and  vattax=0", "SalesLedger")
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
                        TempLedgerName = SQLGetStringFieldValue("select CreditLedger from vatclauses where  vattype='CST' and  vattax=0", "CreditLedger")
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
                        TempLedgerName = SQLGetStringFieldValue("select PurchaseLedger from vatclauses where  vattype='CST' and  vattax=" & Sreader("tax"), "PurchaseLedger")
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
                        TempLedgerName = SQLGetStringFieldValue("select SalesLedger from vatclauses where  vattype='CST' and  vattax=" & Sreader("tax"), "SalesLedger")
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
                        TempLedgerName = SQLGetStringFieldValue("select outputvatledger from vatclauses where  vattype='CST' and vattax=" & Sreader("tax"), "outputvatledger")
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
                        TempLedgerName = SQLGetStringFieldValue("select outputvatledger from vatclauses where vattype='CST' and  vattax=" & Sreader("tax"), "outputvatledger")
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

                    ' you need to update for input and output as well as purchase/sales ledgers for each tax2
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
                        TempLedgerName = SQLGetStringFieldValue("select outputvatledger from vatclauses where  vattype='VAT' and vattax=" & Sreader("tax2"), "outputvatledger")
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
                        TempLedgerName = SQLGetStringFieldValue("select outputvatledger from vatclauses where vattype='VAT' and  vattax=" & Sreader("tax2"), "outputvatledger")
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
            SqlFcmd.CommandText = "select stockcode,stocksize,batchno,location,barcode,TotalQty ,stockrate from StockInvoiceRowItems where transcode=" & OpenedTranscode & " order by sno"
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



    End Sub
    Sub SaveCostCentersData(ByVal trancode As Double)
        ExecuteSQLQuery("delete from costcenterbook where  TransCode=" & trancode)
        Dim Sno As Integer = 0

        If CostList.RowCount > 0 Then
            For rc As Integer = 0 To CostList.RowCount - 1
                If Len(CostList.Item("tcostname", rc).Value) > 0 Then
                    Dim SqlStr As String = ""
                    SqlStr = "INSERT INTO [CostCenterBook] ([sno],[LedgerName],[CostCenterName],[Dr],[Cr],[UserName],[TransCode],[TransDate],[Transdatevalue],[VoucherName],[InvoiceNo],[CostNo],[Costcat],[IsAdditional])    " _
                        & " VALUES (@sno,@LedgerName,@CostCenterName,@Dr,@Cr,@UserName,@TransCode,@TransDate,@Transdatevalue,@VoucherName,@InvoiceNo,@CostNo,@Costcat,@IsAdditional) "
                    Sno = Sno + 1
                    MAINCON.ConnectionString = ConnectionStrinG
                    MAINCON.Open()
                    Dim DBFR = New SqlClient.SqlCommand(SqlStr, MAINCON)
                    With DBFR.Parameters
                        .AddWithValue("sno", Sno)
                        .AddWithValue("LedgerName", txtLedgerName.Text)
                        .AddWithValue("CostCenterName", CostList.Item("tcostname", rc).Value)
                        If InvoiceCtrlType = "PR" Then
                            .AddWithValue("Dr", CostList.Item("tamount", rc).Value)
                            .AddWithValue("Cr", 0)
                        Else
                            .AddWithValue("Dr", 0)
                            .AddWithValue("Cr", CostList.Item("tamount", rc).Value)
                        End If
                        .AddWithValue("UserName", CurrentUserName)
                        .AddWithValue("costcat", CostList.Item("tcostcat", rc).Value)
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
        Dim subSqlStr As String = ""
        'IsAdditional='False' and 
        subSqlStr = "INSERT INTO [CostCenterBook] ([sno],[LedgerName],[CostCenterName],[Dr],[Cr],[UserName],[TransCode],[TransDate],[Transdatevalue],[VoucherName],[InvoiceNo],[CostNo],[CostCat],[IsAdditional])    " _
            & " VALUES (@sno,@LedgerName,@CostCenterName,@Dr,@Cr,@UserName,@TransCode,@TransDate,@Transdatevalue,@VoucherName,@InvoiceNo,@CostNo,@CostCat,@IsAdditional) "
        Sno = Sno + 1

        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBFR3 = New SqlClient.SqlCommand(subSqlStr, MAINCON)
        With DBFR3.Parameters
            .AddWithValue("sno", Sno)
            .AddWithValue("LedgerName", txtLedgerName.Text)
            .AddWithValue("CostCenterName", TxtProject.Text)
            If InvoiceCtrlType = "PR" Then
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
                        ExecuteSQLQuery("UPDATE StockInvoiceRowItems SET USEDQTY=USEDQTY-" & Sreader("totalqty") & " WHERE TRANSCODE=" & Sreader("utranscode") & " and barcode=N'" & Sreader("barcode").ToString.Trim & "'  and batchno=N'" & Sreader("batchno").ToString & "'")
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
    Sub RollBackAccounts()
        OpenedPDCValues = GetPDCValues(OpenedTranscode)
        ExecuteSQLQuery("delete from LEDGERBOOK where transcode=" & OpenedTranscode)
        ExecuteSQLQuery("delete from bill2bill where transcode=" & OpenedTranscode)
    End Sub

    Sub SaveData()
        If IMSBEGINTRANSACTION() = False Then
            IMSENDTRANSACTION()
            '  MsgBox("The server is too busy or ERP Server may be shutdown, Please Run the ERP Server ....Please Try again")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        If IsInvoiceOpen = True Then
            If IsOpendByWindows = True Then
                Select Case InvoiceCtrlType
                    Case "PO"
                        UpdateLogFile(DefStoreName, OpenedTranscode, "PurchaseOrder", TxtQutoNo.Text, CurrentUserName, "Modified", System.Environment.MachineName, "Modified   PurchaseOrder  by OpenMethod")
                    Case "PI", "DP"
                        UpdateLogFile(DefStoreName, OpenedTranscode, "Purchaseinvoice", TxtQutoNo.Text, CurrentUserName, "Modified", System.Environment.MachineName, "Modified   Purchaseinvoice  by OpenMethod")
                    Case "PQ"
                        UpdateLogFile(DefStoreName, OpenedTranscode, "PurchaseQuotation", TxtQutoNo.Text, CurrentUserName, "Modified", System.Environment.MachineName, "Modified   PurchaseQuotation  by OpenMethod")
                    Case "PR"
                        UpdateLogFile(DefStoreName, OpenedTranscode, "DebitNote", TxtQutoNo.Text, CurrentUserName, "Modified", System.Environment.MachineName, "Modified   DebitNote  by OpenMethod")
                    Case "PG"
                        UpdateLogFile(DefStoreName, OpenedTranscode, "PurchaseGoodsNote", TxtQutoNo.Text, CurrentUserName, "Modified", System.Environment.MachineName, "Modified   PurchaseGoodsNote  by OpenMethod")

                End Select

            End If


            Select Case InvoiceCtrlType
                Case "PI", "PR", "DP"
                    RollBackAccounts()
            End Select
            Select Case InvoiceCtrlType
                Case "PG", "DP"
                    RollBackUpdatedOrdereditemsQtys()
            End Select

            ExecuteSQLQuery("update  StockInvoiceRowItems set Isdelete=1  where transcode=" & OpenedTranscode)
            Select Case InvoiceCtrlType
                Case "PG", "PR", "DP"
                    RollBackStockQuantities()
            End Select
            'RELEASE PENDINGS ORDERS....
            For I As Integer = 0 To OpenedTransList.ListofTrascodeadded.Rows.Count - 1
                ExecuteSQLQuery("UPDATE StockInvoiceDetails SET ISPENDING=1 WHERE TRANSCODE=" & OpenedTransList.ListofTrascodeadded.Item("TRANSCODE", I).Value)
            Next
            'DELETE ENTRIES
            ExecuteSQLQuery("delete from StockInvoiceDetails where transcode=" & OpenedTranscode)
            ExecuteSQLQuery("delete from StockInvoiceRowItems where transcode=" & OpenedTranscode)
            ExecuteSQLQuery("delete from UsedTranscodeList where transcode=" & OpenedTranscode)
            ExecuteSQLQuery("delete from VoucherAccounts where transcode=" & OpenedTranscode)
            ExecuteSQLQuery("delete from InvoiceMoreDet where transcode=" & OpenedTranscode)


            If OpenedLedgerName <> txtLedgerName.Text Then
                OpenedCurrencyRate = GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & txtLedgerName.Text & "'", "currency").ToString)
            End If

        Else
            OpenedTranscode = GetAndSetIDCode(EnumIDType.TransCode)
            OpenedCurrencyRate = GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & txtLedgerName.Text & "'", "currency").ToString)
            Select Case InvoiceCtrlType
                Case "PO"
                    If InvoiceBillingSettings.PurchaseOrderSettings.InvoiceMethod = 0 Then
                        TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.purchaseorder)
                    Else
                        GetAndSetInvoiceNumber(InvoiceNoStrct.purchaseorder)
                    End If

                    UpdateLogFile(DefStoreName, OpenedTranscode, "PurchaseOrder", TxtQutoNo.Text, CurrentUserName, "Created", System.Environment.MachineName, "Created New PurchaseOrder")


                Case "PI", "DP"

                    If InvoiceCtrlType = "DP" Then
                        If SalesTrancsationType.Length > 0 Then
                            If SalesTrancsationType = "Cash Purchase" Then
                                If InvoiceBillingSettings.CashPurchaseInvoicesetting.InvoiceMethod = 0 Then
                                    TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.CASHPURCHASE)
                                Else
                                    GetAndSetInvoiceNumber(InvoiceNoStrct.CASHPURCHASE)
                                End If

                            ElseIf SalesTrancsationType = "Credit Purchase" Then
                                If InvoiceBillingSettings.CreditPurchaseInvoicesetting.InvoiceMethod = 0 Then
                                    TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.CREDITPURCHASE)
                                Else
                                    GetAndSetInvoiceNumber(InvoiceNoStrct.CREDITPURCHASE)
                                End If

                            Else
                                If InvoiceBillingSettings.PurchaseInvoicesetting.InvoiceMethod = 0 Then
                                    TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.purchaseinvoice)
                                Else
                                    GetAndSetInvoiceNumber(InvoiceNoStrct.purchaseinvoice)
                                End If
                            End If

                        Else
                            If InvoiceBillingSettings.PurchaseInvoicesetting.InvoiceMethod = 0 Then
                                TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.purchaseinvoice)
                            Else
                                GetAndSetInvoiceNumber(InvoiceNoStrct.purchaseinvoice)
                            End If
                        End If
                    Else
                        If InvoiceBillingSettings.PurchaseInvoicesetting.InvoiceMethod = 0 Then
                            TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.purchaseinvoice)
                        Else
                            GetAndSetInvoiceNumber(InvoiceNoStrct.purchaseinvoice)
                        End If

                    End If

                    'If InvoiceBillingSettings.PurchaseInvoicesetting.InvoiceMethod = 0 Then

                    '    If InvoiceCtrlType = "DP" Then
                    '        If SalesTrancsationType.Length > 0 Then
                    '            If SalesTrancsationType = "Cash Purchase" Then
                    '                TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.CASHPURCHASE)
                    '            ElseIf SalesTrancsationType = "Credit Purchase" Then
                    '                TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.CREDITPURCHASE)
                    '            Else
                    '                TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.purchaseinvoice)
                    '            End If

                    '        Else
                    '            TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.purchaseinvoice)
                    '        End If
                    '    Else
                    '        TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.purchaseinvoice)
                    '    End If
                    'Else
                    '    GetAndSetInvoiceNumber(InvoiceNoStrct.purchaseinvoice)
                    'End If


                    UpdateLogFile(DefStoreName, OpenedTranscode, "PurchaseInvoice", TxtQutoNo.Text, CurrentUserName, "Created", System.Environment.MachineName, "Created New PurchaseInvoice")


                Case "PQ"
                    If InvoiceBillingSettings.PurchaseQutoSettings.InvoiceMethod = 0 Then
                        TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.purchasequoto)
                    Else
                        GetAndSetInvoiceNumber(InvoiceNoStrct.purchasequoto)
                    End If

                    UpdateLogFile(DefStoreName, OpenedTranscode, "PurchaseQuotation", TxtQutoNo.Text, CurrentUserName, "Created", System.Environment.MachineName, "Created New PurchaseQuotation")


                Case "PR"
                    If InvoiceBillingSettings.PurchaseReturnInvoiceSettings.InvoiceMethod = 0 Then
                        TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.PurchaseRetInvoice)
                    Else
                        GetAndSetInvoiceNumber(InvoiceNoStrct.PurchaseRetInvoice)
                    End If

                    UpdateLogFile(DefStoreName, OpenedTranscode, "Debit Note", TxtQutoNo.Text, CurrentUserName, "Created", System.Environment.MachineName, "Created New Debit Note")


                Case "PG"
                    If InvoiceBillingSettings.PurchaseGoodReceivedSettings.InvoiceMethod = 0 Then
                        TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.purchasereceived)
                    Else
                        GetAndSetInvoiceNumber(InvoiceNoStrct.purchasereceived)
                    End If

                    UpdateLogFile(DefStoreName, OpenedTranscode, "PurchaseGoods", TxtQutoNo.Text, CurrentUserName, "Created", System.Environment.MachineName, "Created New PurchaseGoods")

            End Select
            OpenedPDCValues.ischequePrint = False
            If TxtDate.Value > Today.Date Then
                OpenedPDCValues.IsPDC = True
            Else
                OpenedPDCValues.IsPDC = False
            End If
            OpenedPDCValues.TodayDate.Value = Now
            OpenedPDCValues.IsPDCClear = False

        End If

        If TxtServiceAccountAmount.Text.Length = 0 Then
            TxtServiceAccountAmount.Text = "0"
        End If
        Dim SqlStr As String = ""
        Try
            SqlStr = "INSERT INTO [StockInvoiceDetails] ([TransCode],[TransDate],[TransDateValue],[QutoNo],[QutoRef],[OrderNo],[OrderRef],[DNoteno]," _
                & "[DnoteRef],[StoreName],[Currency],[PriceList],[SalesPerson],[ProjectName],[Area],[LedgerName],[LedgerAddress],[IsCommit]," _
                & "[IsDelete],[IsPending],[subtotal],[grosstotal],[discountper],[nettotal],[taxtotal],[InvoiceTotal],[AccountTotal]," _
                & "[amountinwords],[narration],[InvoiceNo],[InvoiceRef],[GoodNo],[GoodRef],[CurrencyCon1],[VoucherName],[DelivaryDate],[DelivaryDateValue],[Additions],[Deductions],[PaymentMethod],[PaymentLedger],[PaymentDetails],[AccountLedgerName],[servicetaxtotal],[roundoff],[surcharge],[DiscPer],[CurrencyCon2],[BillCurrency],[sinvoiceno],[sinvoicedate],[taxtotal2],[transtype],[cstamount],[VoucherType],[AdvancePayment],[CounterId]) " _
                & "VALUES (@TransCode,@TransDate,@TransDateValue,@QutoNo,@QutoRef,@OrderNo,@OrderRef,@DNoteno,@DnoteRef,@StoreName,@Currency," _
                & "@PriceList,@SalesPerson,@ProjectName,@Area,@LedgerName,@LedgerAddress,@IsCommit,@IsDelete,@IsPending,@subtotal,@grosstotal," _
                & "@discountper,@nettotal,@taxtotal,@InvoiceTotal,@AccountTotal,@amountinwords,@narration,@InvoiceNo,@InvoiceRef,@GoodNo,@GoodRef,@CurrencyCon1,@VoucherName," _
                & "@DelivaryDate,@DelivaryDateValue,@Additions,@Deductions,@PaymentMethod,@PaymentLedger,@PaymentDetails,@AccountLedgerName,@servicetaxtotal,@roundoff,@surcharge,@DiscPer,@CurrencyCon2,@BillCurrency,@sinvoiceno,@sinvoicedate,@taxtotal2,@transtype,@cstamount,@VoucherType,@AdvancePayment,@CounterId) "
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()

            Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBF.Parameters
                .AddWithValue("TransCode", OpenedTranscode)
                .AddWithValue("transtype", SalesTrancsationType)
                .AddWithValue("TransDate", TxtDate.Value)
                '@sinvoiceno,@sinvoicedate
                .AddWithValue("sinvoiceno", TxtSupplierInvoiceNo.Text)
                .AddWithValue("sinvoicedate", TxtSupplierDate.Value)
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
                .AddWithValue("LedgerAddress", TxtAddress.Text)
                .AddWithValue("IsCommit", 0)
                .AddWithValue("IsDelete", 0)
                .AddWithValue("IsPending", 1)
                .AddWithValue("subtotal", CDbl(TxtGrossTotal.Text))
                .AddWithValue("grosstotal", CDbl(TxtGrossTotal.Text))
                .AddWithValue("discountper", CDbl(TxtDiscAmt.Text))
                .AddWithValue("nettotal", CDbl(TxtNetTotal.Text))

                .AddWithValue("InvoiceTotal", 0)
                .AddWithValue("AccountTotal", CDbl(TxtServiceAccountAmount.Text))
                .AddWithValue("amountinwords", TxtAmtInwords.Text)
                .AddWithValue("narration", TxtNarration.Text)
                .AddWithValue("InvoiceNo", "")
                .AddWithValue("InvoiceRef", "")
                .AddWithValue("GoodNo", "")
                .AddWithValue("GoodRef", "")
                Select Case InvoiceCtrlType
                    Case "PO"
                        .AddWithValue("VoucherName", "PO")
                        .AddWithValue("PaymentMethod", TxtPaymentMethod.Text)
                        .AddWithValue("PaymentLedger", "")
                        .AddWithValue("PaymentDetails", "")

                    Case "PI"
                        .AddWithValue("VoucherName", "PI")
                        .AddWithValue("PaymentMethod", TxtPaymentMethod.Text)
                        .AddWithValue("PaymentLedger", TxtPaymentBy.Text)
                        .AddWithValue("PaymentDetails", TxtPaymentDetails.Text)

                    Case "PQ"
                        .AddWithValue("VoucherName", "PQ")
                        .AddWithValue("PaymentMethod", TxtPaymentMethod.Text)
                        .AddWithValue("PaymentLedger", "")
                        .AddWithValue("PaymentDetails", "")

                    Case "PR"
                        .AddWithValue("VoucherName", "PR")
                        .AddWithValue("PaymentMethod", TxtPaymentMethod.Text)
                        .AddWithValue("PaymentLedger", TxtPaymentBy.Text)
                        .AddWithValue("PaymentDetails", TxtPaymentDetails.Text)

                    Case "PG"
                        .AddWithValue("VoucherName", "PG")
                        .AddWithValue("PaymentMethod", TxtPaymentMethod.Text)
                        .AddWithValue("PaymentLedger", "")
                        .AddWithValue("PaymentDetails", "")

                    Case "DP"
                        .AddWithValue("VoucherName", "DP")
                        .AddWithValue("PaymentMethod", TxtPaymentMethod.Text)
                        .AddWithValue("PaymentLedger", TxtPaymentBy.Text)
                        .AddWithValue("PaymentDetails", TxtPaymentDetails.Text)
                End Select
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

                .AddWithValue("CurrencyCon1", OpenedCurrencyRate)
                .AddWithValue("DelivaryDate", TxtDelivaryDate.Value.Date)
                .AddWithValue("DelivaryDateValue", TxtDelivaryDate.Value.Date.ToOADate)
                .AddWithValue("Additions", TxtServiceAccountAmount.Text)
                .AddWithValue("Deductions", TxtDeductions.Text)
                .AddWithValue("AccountLedgerName", TxtPurchaseLedger.Text)
                .AddWithValue("servicetaxtotal", 0)
                .AddWithValue("roundoff", 0)
                .AddWithValue("surcharge", 0)
                .AddWithValue("DiscPer", CDbl(TxtDiscount.Text))
                .AddWithValue("CurrencyCon2", CDbl(TxtRateofExchange.Text))
                .AddWithValue("BillCurrency", TxtCurrency.Text)
                .AddWithValue("AdvancePayment", CDbl(TxtAdvancePayment.Text))
                .AddWithValue("CounterId", CurrentCounterID)
                'BillCurrency
                'CurrencyCon2
                'DiscPer
            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        SqlStr = "INSERT INTO [StockInvoiceRowItems]([TransCode],[TransDate],[TransDateValue],[QutoNo],[QutoRef],[OrderNo],[OrderRef]," _
            & "[DNoteno],[DnoteRef],[StoreName],[Currency],[StockName],[StockCode],[stockgroup],[Barcode],[StockSize],[Location]," _
            & "[description],[BaseUnit],[MainUnit],[SubUnit],[IsSimpleUnit],[MainQty],[TotalQty],[SubUnitQty],[QtyText],[StockRate],[Expiry]," _
            & "[BatchNo],[StockType],[StockDisc],[RatePer],[UnitCon],[CustBarcode],[sno],[StockAmount],[QtyValues],[VoucherName]," _
            & "[CurrencyCon1],[Tax],[NetRate],[origin],[HScode],[isdelete],[Utranscode],[TaxAmount],[disc2],[Servicetax],[netStockAmount],[MRP],[packing],[slnos],[Tax2],[TaxAmount2],[transtype],[FreeQty],[FreeQtyText],[FreeMQty],[FreeMQtyText],[UsedQty],[DiscountAmount1],[DiscountAmount2]) " _
            & " VALUES (@TransCode,@TransDate,@TransDateValue,@QutoNo,@QutoRef,@OrderNo,@OrderRef,@DNoteno,@DnoteRef," _
            & "@StoreName,@Currency,@StockName,@StockCode,@stockgroup,@Barcode,@StockSize,@Location,@description,@BaseUnit," _
            & "@MainUnit,@SubUnit,@IsSimpleUnit,@MainQty,@TotalQty,@SubUnitQty,@QtyText,@StockRate,@Expiry,@BatchNo,@StockType," _
            & "@StockDisc,@RatePer,@UnitCon,@CustBarcode,@sno,@StockAmount,@QtyValues,@VoucherName,@CurrencyCon1,@Tax,@NetRate,@origin,@HScode,@isdelete,@Utranscode,@TaxAmount,@disc2,@Servicetax,@netStockAmount,@MRP,@packing,@slnos,@Tax2,@TaxAmount2,@transtype,@FreeQty,@FreeQtyText,@FreeMQty,@FreeMQtyText,@UsedQty,@DiscountAmount1,@DiscountAmount2)"

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
                    .AddWithValue("transtype", SalesTrancsationType)
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
                    .AddWithValue("MRP", CDbl(TxtList.Item("stmrp", i).Value))
                    .AddWithValue("disc2", CDbl(TxtList.Item("tdisc2", i).Value))
                    .AddWithValue("StockType", st.StockType)
                    .AddWithValue("UnitCon", st.TxtQtyBOX.GetUnitConversion())
                    .AddWithValue("StockAmount", CDbl(TxtList.Item("stStockvalueWithOutTax", i).Value))
                    Select Case InvoiceCtrlType
                        Case "PO"
                            .AddWithValue("VoucherName", "PO")
                            .AddWithValue("slnos", "")
                        Case "PI"
                            .AddWithValue("VoucherName", "PI")
                            .AddWithValue("slnos", "")
                        Case "PQ"
                            .AddWithValue("VoucherName", "PQ")
                            .AddWithValue("slnos", "")
                        Case "PR"
                            .AddWithValue("VoucherName", "PR")
                            .AddWithValue("slnos", IIf(TxtList.Item("stslnos", i).Value = Nothing, "", TxtList.Item("stslnos", i).Value))
                        Case "PG"
                            .AddWithValue("VoucherName", "PG")
                            .AddWithValue("slnos", IIf(TxtList.Item("stslnos", i).Value = Nothing, "", TxtList.Item("stslnos", i).Value))
                        Case "DP"
                            .AddWithValue("VoucherName", "DP")
                            .AddWithValue("slnos", IIf(TxtList.Item("stslnos", i).Value = Nothing, "", TxtList.Item("stslnos", i).Value))
                    End Select
                    'StockAmount
                    If Len(TxtList.Item("stcustbarcode", i).Value) = 0 Then
                        .AddWithValue("CustBarcode", "")
                    Else
                        .AddWithValue("CustBarcode", TxtList.Item("stcustbarcode", i).Value.ToString)
                    End If
                    .AddWithValue("CurrencyCon1", OpenedCurrencyRate)
                    .AddWithValue("Tax", CDbl(TxtList.Item("Sttax", i).Value))
                    .AddWithValue("Tax2", CDbl(TxtList.Item("Sttax2", i).Value))

                    .AddWithValue("NetRate", CDbl(TxtList.Item("stnetrate", i).Value))
                    .AddWithValue("origin", TxtList.Item("stmadeby", i).Value)
                    .AddWithValue("HScode", TxtList.Item("sthscode", i).Value)
                    If TxtList.Item("tUTranscode", i).Value = Nothing Then
                        .AddWithValue("Utranscode", 0)
                    Else
                        .AddWithValue("Utranscode", TxtList.Item("tUTranscode", i).Value)
                    End If
                    .AddWithValue("TaxAmount", CDbl(TxtList.Item("sttaxamount", i).Value))
                    .AddWithValue("TaxAmount2", CDbl(TxtList.Item("sttaxamount2", i).Value))

                    .AddWithValue("isdelete", 0)
                    .AddWithValue("Servicetax", 0)
                    .AddWithValue("netStockAmount", CDbl(TxtList.Item("StStockTaxValue", i).Value))
                    .AddWithValue("DiscountAmount1", CDbl(TxtList.Item("stdiscamt1", i).Value))
                    .AddWithValue("DiscountAmount2", CDbl(TxtList.Item("stdiscamt2", i).Value))
                    Try
                        If Len(TxtList.Item("stdnoteno", i).Value) > 0 Then
                            .AddWithValue("UsedQty", st.TxtQtyBOX.GetTotalQty())
                        Else
                            .AddWithValue("UsedQty", 0)
                        End If
                    Catch ex As Exception
                        .AddWithValue("UsedQty", 0)
                    End Try
                End With
                DBF1.ExecuteNonQuery()
                DBF1 = Nothing
                MAINCON.Close()
            End If

        Next
        'UPDATE STOCK ITEMS FOR SALES INVOICE AND POINT OF SALES
        For I As Integer = 0 To CurrentTransList.ListofTrascodeadded.Rows.Count - 1
            ExecuteSQLQuery("UPDATE StockInvoiceDetails SET ISPENDING=0 WHERE TRANSCODE=" & CurrentTransList.ListofTrascodeadded.Item("TRANSCODE", I).Value)
            ExecuteSQLQuery("INSERT INTO [UsedTranscodeList]([Transcode],[UsedTranscode],[UsedDbName]) VALUES(" & OpenedTranscode & "," & CurrentTransList.ListofTrascodeadded.Item("TRANSCODE", I).Value & ",'StockInvoiceDetails')")
        Next

        SaveSerialNumbers()
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
            Case "PG", "PR", "DP"
                UpdateStockForSI_SR_POS()

        End Select

        Select Case InvoiceCtrlType
            Case "PI", "PR", "DP"
                SaveTrasactions(OpenedTranscode)
                SaveChequeInfo(OpenedTranscode)
                UpdatePDCValues(OpenedTranscode, OpenedPDCValues)
                UpdateBill2Bill()
        End Select

        Select Case InvoiceCtrlType
            Case "PO", "PQ"
                ExecuteSQLQuery("update  StockInvoiceRowItems set UsedQty=0 where transcode=" & OpenedTranscode)
        End Select
        Select Case InvoiceCtrlType
            Case "PG", "PR", "DP"
                SaveCostCentersData(OpenedTranscode)
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
        If MyAppSettings.IsNewBillAfterSaveInvoice = True Then
            LoadDefaults()

            LoadStockEntryDefaults()
            TxtDate.Focus()
            IsInvoiceSaved = True
            IsInvoiceOpen = False
        End If
    End Sub
    Sub PrintInvoice()
        SelectedVoucherType = InvoiceType
        Dim pvalues As New PrintParameters
        Select Case InvoiceCtrlType
            Case "PO"
                pvalues.VouhcerName = PrintVoucherNames.purchaseorder
            Case "PI", "DP"
                pvalues.VouhcerName = PrintVoucherNames.purchaseinvoice
                If SalesTrancsationType.Length > 0 Then
                    If SalesTrancsationType = "Cash Purchase" Then
                        pvalues.VouhcerName = PrintVoucherNames.cashpurchase
                    ElseIf SalesTrancsationType = "Credit Purchase" Then
                        pvalues.VouhcerName = PrintVoucherNames.creditpurchase
                    Else
                        pvalues.VouhcerName = PrintVoucherNames.purchaseinvoice
                    End If
                Else
                    pvalues.VouhcerName = PrintVoucherNames.purchaseinvoice
                End If
            Case "PQ"
                pvalues.VouhcerName = PrintVoucherNames.purchasequote
            Case "PR"
                pvalues.VouhcerName = PrintVoucherNames.purchasereturns
            Case "PG"
                pvalues.VouhcerName = PrintVoucherNames.purchasegoods
        End Select

        Dim printk As New PrintDlg(pvalues)
        If printk.ShowDialog = DialogResult.OK Then
            PrintingScheme = pvalues.schemename
            Dim ppd As New PrintPreviewDialog()


            PrtDoc.PrinterSettings.PrinterName = pvalues.PrinterName
            PrtDoc.DefaultPageSettings.PrinterSettings.PrinterName = pvalues.PrinterName
            ppd.Document = PrtDoc
            If pvalues.IsPrintToPrinter = True Then
                If pvalues.IsPrintDuplicateInvoice = True Then
                    If pvalues.NoofCopies = 1 Then
                        PrtDoc.PrinterSettings.PrinterName = pvalues.PrinterName
                        PrtDoc.DefaultPageSettings.PrinterSettings.PrinterName = pvalues.PrinterName
                        PrtDoc.DefaultPageSettings.PrinterSettings.Copies = 1
                        PrtDoc.Print()
                    Else
                        PrtDoc.PrinterSettings.PrinterName = pvalues.PrinterName
                        PrtDoc.DefaultPageSettings.PrinterSettings.PrinterName = pvalues.PrinterName
                        For i As Integer = 1 To pvalues.NoofCopies
                            PrtDoc.DefaultPageSettings.PrinterSettings.Copies = 1
                            IsPrintDuplicateInvoice = True
                            PrintInvoicecopyno = i
                            ppd.Document = PrtDoc
                            PrtDoc.Print()
                        Next
                    End If
                Else
                    If pvalues.NoofCopies <= 0 Then
                        pvalues.NoofCopies = 1
                    End If
                    PrtDoc.PrinterSettings.PrinterName = pvalues.PrinterName
                    PrtDoc.DefaultPageSettings.PrinterSettings.PrinterName = pvalues.PrinterName
                    For i As Integer = 1 To pvalues.NoofCopies
                        PrtDoc.Print()
                    Next

                End If

            ElseIf pvalues.IsPrintToPrinter = False Then
                PrtDoc.DefaultPageSettings.PrinterSettings.Copies = pvalues.NoofCopies
                Try
                    ppd.ShowDialog()
                Catch ex As Exception

                End Try

            End If
        End If
    End Sub
    Sub UpdateBill2Bill()
        If InvoiceCtrlType = "PI" Or InvoiceCtrlType = "DP" Then
            ExecuteSQLQuery("delete from bill2bill where billtype='New' and transcode=" & OpenedTranscode)
            If TxtPaymentMethod.Text <> "Credit" Then Exit Sub

            Dim SqlStr As String = ""
            SqlStr = "INSERT INTO [Bill2Bill]([BillType],[LedgerName],[TransCode],[BillTransCode],[Dr],[Cr],[RefNo],[InvoiceNo],[IsOpening],[TransDate],[StoreName],[PayDays],[VoucherName]) " _
                                   & " VALUES(@BillType,@LedgerName,@TransCode,@BillTransCode,@Dr,@Cr,@RefNo,@InvoiceNo,@IsOpening,@TransDate,@StoreName,@PayDays,@VoucherName) "

            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF1 As New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBF1.Parameters
                If InvoiceCtrlType = "PI" Or InvoiceCtrlType = "DP" Then
                    .AddWithValue("BillType", "New")
                    .AddWithValue("VoucherName", "PurchaseInvoice")
                Else
                    .AddWithValue("BillType", "Against")
                    .AddWithValue("VoucherName", "PurchaseReturns")
                End If

                .AddWithValue("LedgerName", txtLedgerName.Text)
                .AddWithValue("TransCode", OpenedTranscode)
                .AddWithValue("BillTransCode", 0)
                If InvoiceCtrlType = "PG" Then
                    .AddWithValue("Dr", 0)
                    .AddWithValue("cr", CDbl(TxtNetTotal.Text))
                Else
                    .AddWithValue("Dr", CDbl(TxtNetTotal.Text))
                    .AddWithValue("cr", 0)
                End If
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
                        .AddWithValue("VoucherName", "PurchaseReturns")
                        .AddWithValue("Dr", Bill2Billdetails.BillList.Item("tamt", i).Value)
                        .AddWithValue("Cr", 0)
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

    Private Sub TxtSalesPerson_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim k As New CreateSalesPersons()
            k.ShowDialog()
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



    Private Sub TxtDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDate.ValueChanged, TxtRefNo.TextChanged, TxtNetTotal.TextChanged, txtLedgerName.SelectedIndexChanged, TxtPriceLevel.SelectedIndexChanged, TxtProject.SelectedIndexChanged, TxtQutoNo.TextChanged, TxtDelivaryDate.ValueChanged
        IsInvoiceSaved = False
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click, EditToolStripMenuItem.Click
        If APPUserRights.IsEditable = False Then
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
            Case "PO"
                st.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchaseorder
            Case "PI"
                st.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchaseinvoice
            Case "DP"
                st.Invoicetype = ClsSelectInvDB.InvtypeStruct.DirectPurchase
            Case "PQ"
                st.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchasequto
            Case "PR"
                st.Invoicetype = ClsSelectInvDB.InvtypeStruct.PurchaseReturns
            Case "PG"
                st.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchasegoodsreceived

        End Select
        Dim editfrm As New ChooseInvoiceNumber(st, SalesTrancsationType)
        editfrm.ShowDialog()
        If st.SelectedTransCode = 0 Then
            Exit Sub
        Else

            LoadDefaults()
            TxtVoucherType.Enabled = False
            LoadStockEntryDefaults()
            LockTransaction(st.SelectedTransCode)
            OpenByTransCodeID(st.SelectedTransCode)
            OpenedLedgerName = txtLedgerName.Text
        End If

    End Sub
    Public Sub OpenByTransCodeID(ByVal tcode As Single)
        OpenedTranscode = tcode
        IsOpendByWindows = True
        If IsOpendByWindows = True Then
            Select Case InvoiceCtrlType
                Case "PO"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "PurchaseOrder", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  PurchaseOrder  for TransCode: " & OpenedTranscode.ToString)
                Case "PI", "DP"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "Purchaseinvoice", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  Purchaseinvoice  for TransCode: " & OpenedTranscode.ToString)
                Case "PQ"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "PurchaseQuotation", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  PurchaseQuotation  for TransCode: " & OpenedTranscode.ToString)
                Case "PR"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "DebitNote", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  DebitNote  for TransCode: " & OpenedTranscode.ToString)
                Case "PG"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "PurchaseGoods", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  PurchaseGoods  for TransCode: " & OpenedTranscode.ToString)

            End Select


        End If
        isopeningprocess = True
        Dim SqlConn As New SqlClient.SqlConnection
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

                TxtArea.Text = Sreader("AREA").ToString.Trim
                TxtSalesPerson.Text = Sreader("SalesPerson").ToString.Trim
                TxtSupplierInvoiceNo.Text = Sreader("sinvoiceno").ToString.Trim
                Try
                    TxtSupplierDate.Value = Sreader("sinvoicedate")
                Catch ex As Exception

                End Try

                ''@sinvoiceno,@sinvoicedate
                TxtProject.Text = Sreader("ProjectName").ToString.Trim

                TxtGrossTotal.Text = Sreader("grosstotal").ToString.Trim
                TxtNetTotal.Text = Sreader("nettotal").ToString.Trim
                TxtDiscAmt.Text = Sreader("discountper").ToString.Trim
                TxtAmtInwords.Text = Sreader("amountinwords").ToString.Trim
                TxtNarration.Text = Sreader("narration").ToString.Trim
                TxtPriceLevel.Text = Sreader("PriceList").ToString.Trim


                OpenedCurrencyRate = CDbl(Sreader("CurrencyCon1").ToString.Trim)
                TxtServiceAccountAmount.Text = Sreader("Additions")
                TxtDeductions.Text = Sreader("Deductions")

                TxtPaymentMethod.Text = Sreader("PaymentMethod")
                TxtPaymentBy.Text = Sreader("PaymentLedger")
                TxtPaymentDetails.Text = Sreader("PaymentDetails")
                TxtPurchaseLedger.Text = Sreader("AccountLedgerName").ToString.Trim
                TxtRateofExchange.Text = Sreader("CurrencyCon2").ToString.Trim
                If IsNumeric(TxtRateofExchange.Text) = False Then
                    TxtRateofExchange.Text = "1"
                End If
                TxtCurrency.Text = Sreader("BillCurrency").ToString
                TxtBillingCurrency.Text = TxtCurrency.Text
                Try
                    Tax2TotalValue = Sreader("taxtotal2")
                Catch ex As Exception
                    Tax2TotalValue = 0
                End Try
                Try
                    TxtVoucherType.Text = Sreader("VoucherType")
                Catch ex As Exception
                    TxtVoucherType.Text = "Tax Invoice"
                End Try
                If TxtVoucherType.Text.Length = 0 Then
                    TxtVoucherType.Text = "Tax Invoice"
                End If
                TxtAdvancePayment.Text = Sreader("AdvancePayment")
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
                TxtList.Item("stbarcode", i).Value = Sreader("Barcode")
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
                TxtList.Item("stStockvalueWithOutTax", i).Value = Sreader("StockAmount")
                TxtList.Item("stmrp", i).Value = Sreader("mrp")
                TxtList.Item("stpacking", i).Value = Sreader("packing").ToString.Trim
                TxtList.Item("stconrate", i).Value = CDbl(TxtRateofExchange.Text)
                TxtList.Item("stslnos", i).Value = Sreader("slnos").ToString
                TxtList.Item("Sttaxamount", i).Value = Sreader("Taxamount")
                TxtList.Item("Sttaxamount2", i).Value = Sreader("Taxamount2")
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

        'LOAD INVOICE DETAILS 


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
            SQLFcmd.CommandText = "select * from CostCenterBook where IsAdditional='False' and  transcode=" & OpenedTranscode & " and ledgername=N'" & txtLedgerName.Text & "' order by sno"
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

        If InvoiceCtrlType = "PR" Then
            LoadBillWiseData(tcode)
        End If

        SqlConn.Dispose()

        FindTotalAmounts()
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

        If IsOpendByWindows = True Then

            Select Case InvoiceCtrlType

                Case "PO"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "PurchaseOrder", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  PurchaseOrder  for TransCode: " & OpenedTranscode.ToString)
                Case "PI", "DP"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "Purchaseinvoice", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  Purchaseinvoice  for TransCode: " & OpenedTranscode.ToString)
                Case "PQ"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "PurchaseQuotation", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  PurchaseQuotation  for TransCode: " & OpenedTranscode.ToString)
                Case "PR"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "DebitNote", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  DebitNote  for TransCode: " & OpenedTranscode.ToString)
                Case "PG"
                    UpdateLogFile(DefStoreName, OpenedTranscode, "PurchaseGoods", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  PurchaseGoods  for TransCode: " & OpenedTranscode.ToString)

            End Select

        End If
        isopeningprocess = True
        Dim SqlConn As New SqlClient.SqlConnection
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
                TxtSupplierInvoiceNo.Text = Sreader("sinvoiceno").ToString.Trim
                Try
                    TxtSupplierDate.Value = Sreader("sinvoicedate")
                Catch ex As Exception

                End Try
                TxtProject.Text = Sreader("ProjectName").ToString.Trim
                TxtGrossTotal.Text = Sreader("grosstotal")
                TxtNetTotal.Text = Sreader("nettotal")
                TxtDiscAmt.Text = Sreader("discountper")
                TxtAmtInwords.Text = Sreader("amountinwords").ToString.Trim
                TxtNarration.Text = Sreader("narration").ToString.Trim
                TxtPriceLevel.Text = Sreader("PriceList").ToString.Trim


                TxtPaymentMethod.Text = Sreader("PaymentMethod").ToString.Trim
                TxtPaymentBy.Text = Sreader("PaymentLedger").ToString.Trim
                TxtPaymentDetails.Text = Sreader("PaymentDetails").ToString.Trim
                Try
                    Tax2TotalValue = Sreader("taxtotal2")
                Catch ex As Exception
                    Tax2TotalValue = 0
                End Try
                Try
                    TxtVoucherType.Text = Sreader("VoucherType")
                Catch ex As Exception
                    TxtVoucherType.Text = "Tax Invoice"
                End Try
                If TxtVoucherType.Text.Length = 0 Then
                    TxtVoucherType.Text = "Tax Invoice"
                End If
                If TxtList.RowCount = 0 Then
                    TxtRateofExchange.Text = Sreader("CurrencyCon2").ToString.Trim
                    TxtCurrency.Text = Sreader("BillCurrency").ToString
                    TxtBillingCurrency.Text = TxtCurrency.Text
                End If
                TxtAdvancePayment.Text = Sreader("AdvancePayment")
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
                i = TxtList.Rows.Add()
                TxtList.Item("stsno", i).Value = i + 1
                TxtList.Item("stlocation", i).Value = Sreader("location").ToString.Trim
                TxtList.Item("stitemcode", i).Value = Sreader("StockCode").ToString.Trim
                TxtList.Item("stitemname", i).Value = Sreader("StockName").ToString.Trim
                TxtList.Item("stbarcode", i).Value = Sreader("Barcode")
                TxtList.Item("stcustbarcode", i).Value = Sreader("CustBarcode").ToString.Trim
                TxtList.Item("stsize", i).Value = Sreader("StockSize").ToString.Trim
                TxtList.Item("stbatchno", i).Value = Sreader("BatchNo").ToString.Trim
                TxtList.Item("stexpiry", i).Value = Sreader("Expiry")


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
                TxtList.Item("tdisc2", i).Value = Sreader("disc2")
                TxtList.Item("stdiscamt1", i).Value = Sreader("DiscountAmount1")
                TxtList.Item("stdiscamt2", i).Value = Sreader("DiscountAmount2")
                TxtList.Item("stStockvalueWithOutTax", i).Value = Sreader("StockAmount")
                TxtList.Item("stmrp", i).Value = Sreader("mrp")
                TxtList.Item("tUTranscode", i).Value = tcode
                TxtList.Item("stpacking", i).Value = Sreader("packing").ToString.Trim
                TxtList.Item("stconrate", i).Value = CDbl(TxtRateofExchange.Text)
                TxtList.Item("stslnos", i).Value = Sreader("slnos").ToString
                TxtList.Item("Sttaxamount", i).Value = Sreader("Taxamount")
                TxtList.Item("Sttaxamount2", i).Value = Sreader("Taxamount2")
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

        'LOAD INVOICE DETAILS 

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
        If InvoiceCtrlType = "PR" Then
            LoadBillWiseData(tcode)
        End If
        FindTotalAmounts()
        '  CalculateTaxAmount()
        IsInvoiceSaved = False
        TxtVoucherType.Enabled = False
        SqlConn.Dispose()
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
        If IsInvoiceOpen = True Then
            If IsAuditConfirm(OpenedTranscode, "Inventory") = True Then
                MsgBox("The Selected Entry can't be Editable....", MsgBoxStyle.Information)
                Exit Sub
            End If
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
        MainForm.Cursor = Cursors.WaitCursor
        Select Case InvoiceCtrlType

            Case "PO"
                UpdateLogFile(DefStoreName, OpenedTranscode, "PurchaseOrder", TxtQutoNo.Text, CurrentUserName, "Deleted", System.Environment.MachineName, "Deleted  PurchaseOrder  for TransCode: " & OpenedTranscode.ToString)
            Case "PI", "DP"
                UpdateLogFile(DefStoreName, OpenedTranscode, "Purchaseinvoice", TxtQutoNo.Text, CurrentUserName, "Deleted", System.Environment.MachineName, "Deleted  Purchaseinvoice  for TransCode: " & OpenedTranscode.ToString)
            Case "PQ"
                UpdateLogFile(DefStoreName, OpenedTranscode, "PurchaseQuotation", TxtQutoNo.Text, CurrentUserName, "Deleted", System.Environment.MachineName, "Deleted  PurchaseQuotation  for TransCode: " & OpenedTranscode.ToString)
            Case "PR"
                UpdateLogFile(DefStoreName, OpenedTranscode, "DebitNote", TxtQutoNo.Text, CurrentUserName, "Deleted", System.Environment.MachineName, "Deleted  DebitNote  for TransCode: " & OpenedTranscode.ToString)
            Case "PG"
                UpdateLogFile(DefStoreName, OpenedTranscode, "PurchaseGoods", TxtQutoNo.Text, CurrentUserName, "Deleted", System.Environment.MachineName, "Deleted  PurchaseGoods  for TransCode: " & OpenedTranscode.ToString)

        End Select
        ExecuteSQLQuery("update StockInvoiceDetails set isdelete=1 where transcode=" & OpenedTranscode)
        ExecuteSQLQuery("update StockInvoiceRowItems set isdelete=1 where transcode=" & OpenedTranscode)
        Select Case InvoiceCtrlType
            Case "PG", "PR", "DP"
                RollBackStockQuantities()


        End Select

        Select Case InvoiceCtrlType
            Case "PI", "PR", "DP"
                RollBackAccounts()
        End Select
        Select Case InvoiceCtrlType
            Case "PG", "DP"
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


        LoadDefaults()
        LoadStockEntryDefaults()
        TxtDate.Focus()
        IsInvoiceSaved = True
        IsInvoiceOpen = False
        MainForm.Cursor = Cursors.Default
    End Sub
    Private Sub ImsButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMore.Click
        Dim Moredetfrm As New AddMoreDet(MoreDet)
        Moredetfrm.ShowDialog()
        Me.SelectNextControl(Me, True, True, True, True)
        '    MsgBox(MoreDet.buyersname)
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPullData.Click
        If txtLedgerName.Text.Length = 0 Then
            MsgBox("Please Select Suppliers  Name.....", MsgBoxStyle.Information)
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
            Case "PO"
                SelectedTransList.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchaseorder
            Case "PI"
                SelectedTransList.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchaseinvoice
            Case "DP"
                SelectedTransList.Invoicetype = ClsSelectInvDB.InvtypeStruct.DirectPurchase
            Case "PQ"
                SelectedTransList.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchasequto
            Case "PR"
                SelectedTransList.Invoicetype = ClsSelectInvDB.InvtypeStruct.PurchaseReturns
            Case "PG"
                SelectedTransList.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchasegoodsreceived

        End Select


        Dim editfrm As New ChooseInvoiceByVoucherDetails(SelectedTransList)

        If txtLedgerName.Text.Length > 0 Then
            editfrm.TxtLedgerName.Text = txtLedgerName.Text
        End If
        editfrm.ShowDialog()

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
        Me.Dispose()
    End Sub

    Private Sub TxtDrCr1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDrCr1.SelectedIndexChanged, TxtDrCr2.SelectedIndexChanged, TxtDrCr3.SelectedIndexChanged, TxtLedgerAmount1.TextChanged, TxtLedgerAmount2.TextChanged, TxtLedgerAmount3.TextChanged, TxtLedgerName1.SelectedIndexChanged, TxtLedgerName2.SelectedIndexChanged, TxtLedgerName3.SelectedIndexChanged
        On Error Resume Next

        'If sender.IsValidated = False Then Exit Sub
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
        TxtServiceAccountAmount.Text = FormatNumber(AcountAmountDr, ErpDecimalPlaces, , , TriState.False)
        TxtDeductions.Text = FormatNumber(AcountAmountCr * -1, ErpDecimalPlaces, , , TriState.False)
        FindTotalAmounts()
    End Sub





    Sub LoadStockDataByBarCode(ByVal barcode As String, ByVal StockLocation As String)
        If TxtVoucherType.Text.Length = 0 Then
            MsgBox("Please select the Tax Type .. ", MsgBoxStyle.Information)
            TxtVoucherType.Focus()
            Exit Sub
        End If
        Dim SqlStrng As String = ""

        If SQLIsFieldExists("select stockcode from stockdbf where custbarcode=N'" & barcode & "' and location=N'" & StockLocation & "'") = False Then
            TxtBarCode.Focus()
            Exit Sub
        End If

        If LoadStockItemsIntoClassByCustBarCode(barcode, StockLocation, NewAddItem) = False Then Exit Sub
        Dim CRate As Double = 1
        If IsValuesInBillingCurrency.Checked = True Then
            CRate = CDbl(TxtRateofExchange.Text)
        Else
            CRate = 1
        End If
        TxtStockDisc.Text = "0"
        TxtStockDiscount2.Text = "0"
        TxtStockValue.Text = "0"
        TxtStockCode.Text = NewAddItem.StockItemCode
        TxtStockName.Text = NewAddItem.StockItemName
        If MyAppSettings.IsZEROTAXONPURCHASE = True Then
            NewAddItem.Tax = 0
            NewAddItem.Tax2 = 0
        End If
        If TxtVoucherType.Text = "Tax Invoice" Then
            TxtStockTax2 = NewAddItem.Tax2
            TxtStockTax.Text = NewAddItem.Tax
        Else
            TxtStockTax2 = 0
            NewAddItem.Tax2 = 0
            TxtStockTax.Text = NewAddItem.CSTtax
        End If
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
        'If CDbl(TxtStockRate.Text) = 0 Then
        '    TxtStockRate.Text = NewAddItem.StockRRPRate / CDbl(TxtRateofExchange.Text)
        'End If
        TxtStockRate.Text = FormatNumber(NewAddItem.StockRate / CDbl(TxtRateofExchange.Text), 3, , , TriState.False)
        IsBarcodeEntered = True
        TxtBatchNo.Enabled = False
        If NewAddItem.IsBatchNo = 1 Then
            LoadDataIntoComboBox("select batchno from stockbatch where stockcode=N'" & NewAddItem.StockItemCode & "' and stocksize=N'" & NewAddItem.StockITemSize & "' and location=N'" & NewAddItem.StockLocation & "'", TxtBatchNo, "batchno")
            TxtBatchNo.Enabled = True
            TxtStockDisc.Text = "0"
            TxtStockValue.Text = "0"
            TxtStockCode.Text = NewAddItem.StockItemCode
            TxtStockName.Text = NewAddItem.StockItemName
            TxtStockSize.Text = NewAddItem.StockITemSize

            TxtMRP.Text = NewAddItem.MRP
            If MyAppSettings.IsZEROTAXONPURCHASE = True Then
                NewAddItem.Tax = 0
                NewAddItem.Tax2 = 0
            End If
            If TxtVoucherType.Text = "Tax Invoice" Then
                TxtStockTax2 = NewAddItem.Tax2
                TxtStockTax.Text = NewAddItem.Tax
            Else
                NewAddItem.Tax = NewAddItem.CSTtax
                TxtStockTax.Text = NewAddItem.CSTtax
                NewAddItem.Tax2 = 0
                TxtStockTax2 = 0
            End If
            TxtStockQty.SetUnitName(NewAddItem.StockUnitName)
            TxtStockQty.ClearQty()
            TxtStockQty.TxtQty1.Text = "1"
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
            'If CDbl(TxtStockRate.Text) = 0 Then
            '    TxtStockRate.Text = NewAddItem.StockRRPRate / CDbl(TxtRateofExchange.Text)
            'End If
            TxtStockRate.Text = FormatNumber(NewAddItem.StockRate / CDbl(TxtRateofExchange.Text), 3, , , TriState.False)
            TxtBatchNo.Text = ""
            TxtBatchNo.Items.Clear()
            If NewAddItem.IsBatchNo = 1 Then
                LoadDataIntoComboBox("select batchno from stockbatch where stockcode=N'" & NewAddItem.StockItemCode & "' and stocksize=N'" & NewAddItem.StockITemSize & "' and location=N'" & NewAddItem.StockLocation & "'", TxtBatchNo, "batchno")
                TxtBatchNo.Enabled = True
                IsAddedByBarcode = False
                Me.TableForItemRow.ColumnStyles.Item(4).Width = 80
                TxtBatchNo.Focus()
            Else
                TxtBatchNo.Enabled = False
                Me.TableForItemRow.ColumnStyles.Item(4).Width = 0
                IsAddedByBarcode = False
                TxtStockQty.Focus()
            End If
            'Me.TableForItemRow.ColumnStyles.Item(4).Width = 12.5
            ' TxtBatchNo.Focus()
            ' Me.TableForItemRow.ColumnStyles.Item(4).Width = 12.5
            'TxtBatchNo.Focus()
        Else
            TxtStockQty.Focus()
            Exit Sub
            'If MyAppSettings.IsZEROTAXONPURCHASE = True Then
            '    NewAddItem.Tax = 0
            '    NewAddItem.Tax2 = 0
            'End If
            'If TxtVoucherType.Text = "Tax Invoice" Then
            '    TxtStockTax2 = NewAddItem.Tax2
            '    TxtStockTax.Text = NewAddItem.Tax
            'Else
            '    NewAddItem.Tax = NewAddItem.CSTtax
            '    TxtStockTax.Text = NewAddItem.CSTtax
            '    NewAddItem.Tax2 = 0
            '    TxtStockTax2 = 0

            'End If

            'Dim nR As Integer
            'nR = TxtList.Rows.Add()
            'TxtList.Item("stsno", nR).Value = nR + 1
            'TxtList.Item("stlocation", nR).Value = NewAddItem.StockLocationNames
            'TxtList.Item("StItemcode", nR).Value = NewAddItem.StockItemCode
            'TxtList.Item("Stitemname", nR).Value = NewAddItem.StockItemName
            'TxtList.Item("Stbarcode", nR).Value = NewAddItem.StockItemBarCode
            'TxtList.Item("Stsize", nR).Value = NewAddItem.StockITemSize
            'TxtList.Item("Stbatchno", nR).Value = NewAddItem.StockBatchNo
            'TxtList.Item("stcustbarcode", nR).Value = NewAddItem.CustBarCode
            'TxtList.Item("stExpiry", nR).Value = NewAddItem.StockExpirydate

            'TxtList.Item("stfreeqty", nR).Value = TxtStockFreeQty.GetTotalQty
            'TxtList.Item("stfreeqtytext", nR).Value = TxtStockFreeQty.GetTotalQtyText

            'TxtList.Item("stMqty", nR).Value = TxtStockQty.GetTotalQty
            'TxtList.Item("stMqtytext", nR).Value = TxtStockQty.GetTotalQtyText

            'TxtStockFreeQty.TxtQty1.Text = CDbl(TxtStockQty.TxtQty1.Text) + CDbl(TxtStockFreeQty.TxtQty1.Text)
            'TxtStockFreeQty.TxtQty2.Text = CDbl(TxtStockQty.TxtQty2.Text) + CDbl(TxtStockFreeQty.TxtQty2.Text)
            'TxtStockFreeQty.CalculateValues()

            'TxtList.Item("stqty", nR).Value = TxtStockFreeQty.GetTotalQty
            'TxtList.Item("stqtytext", nR).Value = TxtStockFreeQty.GetTotalQtyText

            'If TxtRatePer.Text = TxtStockQty.GetSubUnit() Then
            '    Dim trate As Double
            '    trate = CDbl(TxtStockRate.Text) * CDbl(TxtRateofExchange.Text) / CRate * TxtStockQty.GetUnitConversion
            '    TxtList.Item("strate", nR).Value = trate
            '    TxtList.Item("strateper", nR).Value = TxtStockQty.GetMainUnit
            '    trate = trate - trate * CDbl(TxtStockDisc.Text) / 100
            '    trate = trate - CDbl(TxtStockDiscount2.Text)
            '    TxtList.Item("stStockvalueWithOutTax", nR).Value = trate * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
            '    TxtList.Item("sttaxamount", nR).Value = trate * CDbl(TxtStockTax.Text) / 100 * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
            '    If MyAppSettings.IsAllowMultiTaxRatesOnPurchase = False Then
            '        TxtList.Item("sttaxamount2", nR).Value = 0
            '    Else
            '        TxtList.Item("sttaxamount2", nR).Value = trate * NewAddItem.Tax2 / 100 * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
            '    End If
            '    trate = trate + trate * CDbl(TxtStockTax.Text) / 100
            '    TxtList.Item("stnetrate", nR).Value = trate
            '    TxtStockValue.Text = trate
            'Else
            '    Dim trate As Double
            '    trate = CDbl(TxtStockRate.Text) * CDbl(TxtRateofExchange.Text) / CRate
            '    TxtList.Item("strate", nR).Value = trate
            '    TxtList.Item("strateper", nR).Value = TxtStockQty.GetMainUnit
            '    trate = trate - trate * CDbl(TxtStockDisc.Text) / 100
            '    trate = trate - CDbl(TxtStockDiscount2.Text)

            '    TxtList.Item("stStockvalueWithOutTax", nR).Value = trate * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)

            '    TxtList.Item("sttaxamount", nR).Value = trate * CDbl(TxtStockTax.Text) / 100 * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
            '    If MyAppSettings.IsAllowMultiTaxRatesOnPurchase = False Then
            '        TxtList.Item("sttaxamount2", nR).Value = 0
            '    Else
            '        TxtList.Item("sttaxamount2", nR).Value = trate * NewAddItem.Tax2 / 100 * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
            '    End If
            '    trate = trate + trate * CDbl(TxtStockTax.Text) / 100
            '    TxtList.Item("stnetrate", nR).Value = trate
            '    TxtStockValue.Text = trate
            'End If

            'TxtList.Item("stdiscount", nR).Value = TxtStockDisc.Text
            'TxtList.Item("tdisc2", nR).Value = TxtStockDiscount2.Text

            'TxtList.Item("stdiscamt1", nR).Value = CDbl(TxtStockDisc.Text) * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)
            'TxtList.Item("stdiscamt2", nR).Value = CDbl(TxtStockDiscount2.Text) * (TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion)


            'TxtList.Item("StStockTaxValue", nR).Value = CDbl(TxtStockValue.Text) * CDbl(TxtRateofExchange.Text) / CRate
            'TxtList.Item("stmainunit", nR).Value = TxtStockQty.GetMainUnit
            'TxtList.Item("stsubunit", nR).Value = TxtStockQty.GetSubUnit
            'TxtList.Item("sthscode", nR).Value = NewAddItem.HScode
            'TxtList.Item("stmadeby", nR).Value = NewAddItem.Madeby
            'TxtList.Item("sttax", nR).Value = TxtStockTax.Text
            'If MyAppSettings.IsAllowMultiTaxRatesOnPurchase = False Then
            '    TxtList.Item("sttax2", nR).Value = 0
            'Else
            '    TxtList.Item("sttax2", nR).Value = NewAddItem.Tax2
            'End If
            'TxtList.Item("sttax", nR).Value = TxtStockTax.Text
            'TxtList.Item("tutranscode", nR).Value = 0
            'TxtList.Item("stmrp", nR).Value = NewAddItem.MRP
            'TxtList.Item("stconrate", nR).Value = CDbl(TxtRateofExchange.Text) / CRate
            'TxtList.Item("stslnos", nR).Value = ""
            'TxtBatchNo.Enabled = False
            'Me.TableForItemRow.ColumnStyles.Item(4).Width = 0
            'LoadStockEntryDefaults()
            'FindTotalAmounts()
            'TxtBarCode.Focus()
            'IsInvoiceSaved = False
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
        PrintInvoice()
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
            PrtDoc.PrinterSettings.PrinterName = PagesetupValues.PrinterName
            PrtDoc.DefaultPageSettings.PrinterSettings.PrinterName = PagesetupValues.PrinterName
            PrtDoc.DefaultPageSettings.Margins.Left = PagesetupValues.leftmarging
            PrtDoc.DefaultPageSettings.Margins.Right = PagesetupValues.rightmarging
            PrtDoc.DefaultPageSettings.Margins.Top = PagesetupValues.topmarging
            PrtDoc.DefaultPageSettings.Margins.Bottom = PagesetupValues.buttommarging
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
            Dim k As New CreateSuppliers
            k.ShowDialog()
            LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')", TxtPaymentBy, "ledgername")
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
        Select Case InvoiceCtrlType
            Case "PO"
                TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.purchaseorder)
                If InvoiceBillingSettings.PurchaseOrderSettings.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
            Case "PI", "DP"

                If SalesTrancsationType.Length > 0 Then
                    If SalesTrancsationType = "Cash Purchase" Then
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.CASHPURCHASE)
                    ElseIf SalesTrancsationType = "Credit Purchase" Then
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.CREDITPURCHASE)
                    Else
                        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.purchaseinvoice)
                    End If
                Else
                    TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.purchaseinvoice)
                End If
                If InvoiceBillingSettings.PurchaseInvoicesetting.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
                LblSalesLedger.Visible = True
                TxtPurchaseLedger.Visible = True
            Case "PQ"
                TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.purchasequoto)
                If InvoiceBillingSettings.PurchaseQutoSettings.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
            Case "SR"
                TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.PurchaseRetInvoice)
                If InvoiceBillingSettings.PurchaseReturnInvoiceSettings.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If
                LblSalesLedger.Visible = True
                TxtPurchaseLedger.Visible = True
            Case "PG"
                TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.purchasereceived)
                If InvoiceBillingSettings.PurchaseGoodReceivedSettings.InvoiceMethod = 0 Then
                    TxtQutoNo.Enabled = False
                Else
                    TxtQutoNo.Enabled = True
                End If

        End Select

        LoadStockEntryDefaults()
        TxtDate.Focus()
        IsInvoiceSaved = True
        IsInvoiceOpen = False
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
        value2 = TxtPurchaseLedger.Text
        value3 = TxtLedgerName1.Text
        value4 = TxtLedgerName2.Text
        value5 = TxtLedgerName3.Text
        value6 = TxtSalesPerson.Text

        LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "')", txtLedgerName, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')", TxtPurchaseLedger, "ledgername")
        LoadDataIntoComboBox("SELECT Ledgername from ledgers where isactive=1 and (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.DirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "' or groupname=N'" & AccountGroupNames.DirectIncomes & "'))", TxtLedgerName1, "ledgername")
        LoadDataIntoComboBox("SELECT Ledgername from ledgers where isactive=1 and (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.DirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "' or groupname=N'" & AccountGroupNames.DirectIncomes & "'))", TxtLedgerName2, "ledgername")
        LoadDataIntoComboBox("SELECT Ledgername from ledgers where  isactive=1 and (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.DirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "' or groupname=N'" & AccountGroupNames.DirectIncomes & "'))", TxtLedgerName3, "ledgername")
        LoadDataIntoComboBox("select salespersonname from salespersons where isactive=1", TxtSalesPerson, "salespersonname")

        txtLedgerName.Text = value1
        TxtPurchaseLedger.Text = value2
        TxtLedgerName1.Text = value3
        TxtLedgerName2.Text = value4
        TxtLedgerName3.Text = value5
        TxtSalesPerson.Text = value6
    End Sub

    Private Sub btnadditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadditems.Click
        Additems()
    End Sub

    Private Sub TxtRatePer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRatePer.GotFocus
        If TxtStockCode.Text.Length = 0 Then
            TxtStockCode.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub TxtBatchNo_GotFocus(sender As Object, e As System.EventArgs) Handles TxtBatchNo.GotFocus
        If TxtStockCode.Text.Length = 0 Then TxtStockCode.Focus()
    End Sub
    Private Sub TxtBatchNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBatchNo.KeyDown
        If TxtStockCode.Text.Length = 0 Then Exit Sub
        If e.Alt = True And e.KeyCode = Keys.C Then
            CreateNewBatchDetails()

        End If
    End Sub
    Function CreateNewBatchDetails() As Boolean
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
            Return True
        Else
            Return False
        End If
    End Function

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

    Private Sub TxtBatchNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBatchNo.KeyPress


    End Sub

    Private Sub TxtBatchNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBatchNo.LostFocus
        If TxtBatchNo.Text.Length > 0 Then
            NewAddItem.MRP = SQLGetNumericFieldValue("SELECT mrp FROM STOCKBATCH WHERE STOCKCODE=N'" & NewAddItem.StockItemCode & "' AND STOCKSIZE=N'" & NewAddItem.StockITemSize & "' AND LOCATION=N'" & NewAddItem.StockLocation & "' AND BATCHNO=N'" & TxtBatchNo.Text & "'", "mrp")
            TxtMRP.Text = NewAddItem.MRP
        End If

    End Sub

    Private Sub TxtBatchNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBatchNo.SelectedIndexChanged
        TxtStatusText.Text = "Cur Qty:" & SQLGetStringFieldValue("SELECT QTYTEXT FROM STOCKBATCH WHERE STOCKCODE=N'" & NewAddItem.StockItemCode & "' AND STOCKSIZE=N'" & NewAddItem.StockITemSize & "' AND LOCATION=N'" & NewAddItem.StockLocation & "' AND BATCHNO=N'" & TxtBatchNo.Text & "'", "QTYTEXT")
    End Sub

    Private Sub TxtBatchNo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBatchNo.Validating
        If TxtBatchNo.Text.Length > 0 And TxtBatchNo.Items.Contains(TxtBatchNo.Text) = False Then
            If CreateNewBatchDetails() = False Then
                TxtBatchNo.Text = ""
            End If

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
        BtnEditCancel.Visible = True
        TxtList.Enabled = False
        EditItemRow = TxtList.CurrentRow.Index
        Dim bvalue As New ChooseItemClass
        bvalue.StockItemBarCode = TxtList.Item("stbarcode", EditItemRow).Value
        bvalue.StockLocation = TxtList.Item("stlocation", EditItemRow).Value
        LoadStockItemsIntoClass(bvalue.StockItemBarCode, bvalue.StockLocation, NewAddItem)
        TxtStockDisc.Text = "0"
        TxtStockValue.Text = "0"
        TxtStockTax2 = NewAddItem.Tax2
        TxtStockCode.Text = NewAddItem.StockItemCode
        TxtStockName.Text = NewAddItem.StockItemName
        TxtStockSize.Text = NewAddItem.StockITemSize
        TxtStockQty.SetUnitName(NewAddItem.StockUnitName)
        TxtStockQty.ClearQty()
        TxtStockFreeQty.SetUnitName(NewAddItem.StockUnitName)
        TxtStockFreeQty.ClearQty()
        If MyAppSettings.IsZEROTAXONPURCHASE = True Then
            NewAddItem.Tax = 0
            NewAddItem.Tax2 = 0
        End If
        If TxtVoucherType.Text = "Tax Invoice" Then
            TxtStockTax2 = NewAddItem.Tax2
            TxtStockTax.Text = NewAddItem.Tax
        Else
            NewAddItem.Tax = NewAddItem.CSTtax
            TxtStockTax.Text = NewAddItem.CSTtax
            NewAddItem.Tax2 = 0
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
    End Sub

    Private Sub DeleteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem1.Click
        TxtList.Rows.RemoveAt(TxtList.CurrentRow.Index)
        'FindTotalAmounts()

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
        TxtStockCode.Text = NewAddItem.StockItemCode
        TxtStockName.Text = NewAddItem.StockItemName
        TxtStockSize.Text = NewAddItem.StockITemSize
        TxtStockQty.SetUnitName(NewAddItem.StockUnitName)
        TxtStockQty.ClearQty()
        TxtStockFreeQty.SetUnitName(NewAddItem.StockUnitName)
        TxtStockFreeQty.ClearQty()
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

    Private Sub TxtList_SortCompare(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles TxtList.SortCompare

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





    'Private Sub TxtBillingCurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBillingCurrency.SelectedIndexChanged
    '    If isopeningprocess = True Then Exit Sub
    '    If TxtBillingCurrency.Text = CompDetails.Currency Then
    '        TxtRateofExchange.Enabled = False
    '        TxtCurrency.Text = TxtBillingCurrency.Text
    '    Else
    '        TxtRateofExchange.Enabled = True
    '        TxtCurrency.Text = TxtBillingCurrency.Text
    '    End If

    '    If TxtCurrency.Text = CompDetails.Currency Then
    '        TxtRateofExchange.Text = "1"
    '        TxtBillingCurrency.Text = TxtCurrency.Text
    '    Else
    '        ErpReadExchangeRate = SQLGetNumericFieldValue("SELECT ConRate FROM CurrencyList WHERE CurrencyCode=N'" & TxtCurrency.Text & "'", "ConRate")
    '        Dim FRM As New ReadCurrencyExchangeRate(ErpReadExchangeRate, TxtCurrency.Text)
    '        FRM.ShowDialog()
    '        TxtRateofExchange.Text = ErpReadExchangeRate
    '        TxtBillingCurrency.Text = TxtCurrency.Text
    '    End If
    '    ConvertValuesByCurrency()
    'End Sub





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
            BtnEditCancel.Visible = True
            TxtList.Enabled = False
            EditItemRow = TxtList.CurrentRow.Index
            Dim bvalue As New ChooseItemClass
            bvalue.StockItemBarCode = TxtList.Item("stbarcode", EditItemRow).Value
            bvalue.StockLocation = TxtList.Item("stlocation", EditItemRow).Value
            LoadStockItemsIntoClass(bvalue.StockItemBarCode, bvalue.StockLocation, NewAddItem)
            TxtStockDisc.Text = "0"
            TxtStockValue.Text = "0"
            TxtStockTax2 = NewAddItem.Tax2
            TxtStockCode.Text = NewAddItem.StockItemCode
            TxtStockName.Text = NewAddItem.StockItemName
            TxtStockSize.Text = NewAddItem.StockITemSize
            TxtStockQty.SetUnitName(NewAddItem.StockUnitName)
            TxtStockQty.ClearQty()
            TxtStockFreeQty.SetUnitName(NewAddItem.StockUnitName)
            TxtStockFreeQty.ClearQty()
            If MyAppSettings.IsZEROTAXONPURCHASE = True Then
                NewAddItem.Tax = 0
                NewAddItem.Tax2 = 0
            End If
            If TxtVoucherType.Text = "Tax Invoice" Then
                TxtStockTax2 = NewAddItem.Tax2
                TxtStockTax.Text = NewAddItem.Tax
            Else
                NewAddItem.Tax = NewAddItem.CSTtax
                TxtStockTax.Text = NewAddItem.CSTtax
                NewAddItem.Tax2 = 0
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
            CurrencyLabel.Text = TxtCurrency.Text
        Else
            For i As Integer = 0 To TxtList.RowCount - 1
                TxtList.Item("strate", i).Value = CDbl(TxtList.Item("strate", i).Value) * CDbl(TxtList.Item("stconrate", i).Value)
                TxtList.Item("stStockvalueWithOutTax", i).Value = CDbl(TxtList.Item("stStockvalueWithOutTax", i).Value) * CDbl(TxtList.Item("stconrate", i).Value)
                TxtList.Item("sttaxamount", i).Value = CDbl(TxtList.Item("sttaxamount", i).Value) * CDbl(TxtList.Item("stconrate", i).Value)
                TxtList.Item("sttaxamount2", i).Value = CDbl(TxtList.Item("sttaxamount2", i).Value) * CDbl(TxtList.Item("stconrate", i).Value)
                TxtList.Item("stnetrate", i).Value = CDbl(TxtList.Item("stnetrate", i).Value) * CDbl(TxtList.Item("stconrate", i).Value)
                TxtList.Item("ststocktaxvalue", i).Value = CDbl(TxtList.Item("ststocktaxvalue", i).Value) * CDbl(TxtList.Item("stconrate", i).Value)
            Next
            CurrencyLabel.Text = CompDetails.Currency
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

            CurrencyLabel.Text = TxtCurrency.Text

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

    Private Sub TxtRateofExchange_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRateofExchange.TextChanged

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
    Sub SaveChequeInfo(ByVal transcode As Single)
        Dim isprinted As Boolean = False
        isprinted = SQLGetBooleanFieldValue("select Isprinted from chequeinfo where transcode=" & transcode, "Isprinted")
        ExecuteSQLQuery("delete from chequeinfo where transcode=" & transcode)
        If SQLIsFieldExists("SELECT TOP 1 1 from   ledgers where ledgername=N'" & TxtPaymentBy.Text & "' and   (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.BankOD & "'))") = True Then
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
                    Case "PI", "DP"
                        .AddWithValue("vouchername", "Purchase")
                    Case "PR"
                        .AddWithValue("vouchername", "DebitNote")
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

    Private Sub SearchStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchStockToolStripMenuItem.Click
        GetStockDets(0, TxtStockCode.Text)
    End Sub

    Private Sub TxtList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

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
        MainForm.Cursor = Cursors.Default
    End Sub
    Sub SaveSerialNumbers()
        ExecuteSQLQuery("DELETE FROM stockserialnos WHERE TRANSCODE=" & OpenedTranscode)
        Select Case InvoiceCtrlType
            Case "DP", "PG", "PR", "PI"
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
            Case "DP", "PG"
                insstr = "INSERT INTO [stockserialnos]([StockCode],[StockSize],[SerialNumber],[transcode],[vouchername])     VALUES (N'" & scode & "',N'" & ssize & "',N'" & slno & "'," & OpenedTranscode & ",'PI')"
                ExecuteSQLQuery(insstr)
            Case "PR"
                insstr = "INSERT INTO [stockserialnos]([StockCode],[StockSize],[SerialNumber],[transcode],[vouchername])     VALUES (N'" & scode & "',N'" & ssize & "',N'" & slno & "'," & OpenedTranscode & ",'PR')"
                ExecuteSQLQuery(insstr)
            Case "PI"
                insstr = "INSERT INTO [stockserialnos]([StockCode],[StockSize],[SerialNumber],[transcode],[vouchername])     VALUES (N'" & scode & "',N'" & ssize & "',N'" & slno & "'," & OpenedTranscode & ",'PO')"
                ExecuteSQLQuery(insstr)
        End Select



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
    Private Sub grpDetails_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles grpDetails.MouseDoubleClick, grpOptions.MouseDoubleClick, lblLedgerGroup.MouseDoubleClick
        HideorunHidepannel()
    End Sub
    Public Sub HideorunHidepannel()
        If Me.TableLayoutPanel1.RowStyles(1).Height < 24 Then
            Me.TableLayoutPanel1.RowStyles(1).Height = 103
            Me.TableLayoutPanel1.RowStyles(4).Height = 116
        Else
            Me.TableLayoutPanel1.RowStyles(1).Height = 15
            Me.TableLayoutPanel1.RowStyles(4).Height = 5
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
            MsgBox("The Advance Paid Amount is greater than the Bill Total, Please Check again...", MsgBoxStyle.Information)
            e.Cancel = True
        End If
    End Sub

    Private Sub lblLedgerGroup_Enter(sender As System.Object, e As System.EventArgs) Handles lblLedgerGroup.Enter

    End Sub

    Private Sub HideorUnhidePanelTooltip_Click(sender As Object, e As System.EventArgs) Handles HideorUnhidePanelTooltip.Click
        HideorunHidepannel()
    End Sub

    Sub CheckBarcodeAndLoadData()
        If TxtBarCode.Text.Length = 0 Then Exit Sub
        TxtBarCode.Text = GetAlternativeBarcode(TxtBarCode.Text)
        LoadStockDataByBarCode(TxtBarCode.Text, GetLocation)

    End Sub

    Private Sub TxtBarCode_LostFocus(sender As Object, e As System.EventArgs) Handles TxtBarCode.LostFocus
        CheckBarcodeAndLoadData()
    End Sub
    Private Sub TxtBarCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBarCode.TextChanged

    End Sub

    Private Sub TxtStockCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtStockCode.TextChanged

    End Sub
End Class
