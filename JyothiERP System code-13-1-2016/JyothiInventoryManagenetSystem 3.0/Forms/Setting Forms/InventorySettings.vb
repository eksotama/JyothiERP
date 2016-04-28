Public Class InventorySettings
    Sub LoadPriceListNames()
        IsAllowCustomPriceInSales.Items.Clear()
        LoadDataIntoComboBox("select  pricelistname from pricelist", IsAllowCustomPriceInSales, "pricelistname")
        IsAllowCustomPriceInSales.Items.Add("Wholesale")
        IsAllowCustomPriceInSales.Items.Add("Retail")
        IsAllowCustomPriceInSales.Items.Add("*All")
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click


        If IsAllowCustomPriceInSales.Text.Length <= 0 Then
            ExecuteSQLQuery("update settings set PosPriceList='*All'")
        Else
            ExecuteSQLQuery("update settings set PosPriceList=N'" & IsAllowCustomPriceInSales.Text & "'")
        End If
        'ZerotaxonPurchase
        If TxtPurchaseZeroTax.Checked = True Then
            ExecuteSQLQuery("update settings set ZerotaxonPurchase='True'")
        Else
            ExecuteSQLQuery("update settings set ZerotaxonPurchase='False'")
        End If
        If IsBillWise.Text = "NO" Or IsBillWise.Text = "" Then
            ExecuteSQLQuery("update settings set IsBillWise='False'")
        Else
            ExecuteSQLQuery("update settings set IsBillWise='True'")
        End If
        If IsNewInvoiceAfterSave.Text = "NO" Or IsNewInvoiceAfterSave.Text = "" Then
            ExecuteSQLQuery("update settings set IsNewInvoiceOnSave='False'")
        Else
            ExecuteSQLQuery("update settings set IsNewInvoiceOnSave='True'")
        End If
        If IsPrintOnSave.Text = "NO" Or IsPrintOnSave.Text = "" Then
            ExecuteSQLQuery("update settings set IsAutoPrinting='False'")
        Else
            ExecuteSQLQuery("update settings set IsAutoPrinting='True'")
        End If
        If IsBatchWise.Text = "NO" Or IsBatchWise.Text = "" Then
            ExecuteSQLQuery("update settings set IsBatchExpiry='False'")
        Else
            ExecuteSQLQuery("update settings set IsBatchExpiry='True'")
        End If
        If IsAllowCashOnJournal.Text = "NO" Or IsAllowCashOnJournal.Text = "" Then
            ExecuteSQLQuery("update settings set IsAllowCashBankinJournal='False'")
        Else
            ExecuteSQLQuery("update settings set IsAllowCashBankinJournal='True'")
        End If
        If IsAllowDuplicateRef.Text = "NO" Or IsAllowDuplicateRef.Text = "" Then
            ExecuteSQLQuery("update settings set IsAllowDuplicateRef='False'")
        Else
            ExecuteSQLQuery("update settings set IsAllowDuplicateRef='True'")
        End If
        If IsAllowZeroStock.Text = "NO" Or IsAllowZeroStock.Text = "" Then
            ExecuteSQLQuery("update settings set IsAllowZeroValueStock='False'")
        Else
            ExecuteSQLQuery("update settings set IsAllowZeroValueStock='True'")
        End If
        If IsAllowNagativeStock.Text = "NO" Or IsAllowNagativeStock.Text = "" Then
            ExecuteSQLQuery("update settings set IsAllowNagetiveStock='False'")
        Else
            ExecuteSQLQuery("update settings set IsAllowNagetiveStock='True'")
        End If
        If IsAllowCustomBarcode.Text = "NO" Or IsAllowCustomBarcode.Text = "" Then
            ExecuteSQLQuery("update settings set IsCustomBarcode='False'")
        Else
            ExecuteSQLQuery("update settings set IsCustomBarcode='True'")
        End If
        If IsAllowShowAllRef.Text = "NO" Or IsAllowShowAllRef.Text = "" Then
            ExecuteSQLQuery("update settings set IsAllowAllRef='False'")
        Else
            ExecuteSQLQuery("update settings set IsAllowAllRef='True'")
        End If
        If IsAlloExtraFiledInDNote.Text = "NO" Or IsAlloExtraFiledInDNote.Text = "" Then
            ExecuteSQLQuery("update settings set IsAllowPriceField='False'")
        Else
            ExecuteSQLQuery("update settings set IsAllowPriceField='True'")
        End If

        If IsAllowDebitNote.Text = "NO" Or IsAllowDebitNote.Text = "" Then
            ExecuteSQLQuery("update settings set IsAllowDebitNote='False'")
        Else
            ExecuteSQLQuery("update settings set IsAllowDebitNote='True'")
        End If

        If IsAllowCreditNote.Text = "NO" Or IsAllowCreditNote.Text = "" Then
            ExecuteSQLQuery("update settings set IsAllowCreditNote='False'")
        Else
            ExecuteSQLQuery("update settings set IsAllowCreditNote='True'")
        End If


        If IsAllowSalesOrder.Text = "NO" Or IsAllowSalesOrder.Text = "" Then
            ExecuteSQLQuery("update settings set IsAllowSalesOrders='False'")
        Else
            ExecuteSQLQuery("update settings set IsAllowSalesOrders='True'")
        End If


        If IsAllowPurchOrder.Text = "NO" Or IsAllowPurchOrder.Text = "" Then
            ExecuteSQLQuery("update settings set IsAllowPurchaseOrders='False'")
        Else
            ExecuteSQLQuery("update settings set IsAllowPurchaseOrders='True'")
        End If

        If IsAllowDeliveryNote.Text = "NO" Or IsAllowDeliveryNote.Text = "" Then
            ExecuteSQLQuery("update settings set IsAllowDeliveryNote='False'")
        Else
            ExecuteSQLQuery("update settings set IsAllowDeliveryNote='True'")
        End If


        If IsAllowGReciptNote.Text = "NO" Or IsAllowGReciptNote.Text = "" Then
            ExecuteSQLQuery("update settings set IsAllowGReceiptNote='False'")
        Else
            ExecuteSQLQuery("update settings set IsAllowGReceiptNote='True'")
        End If
        If ISMuliPriceList.Text = "NO" Or ISMuliPriceList.Text = "" Then
            ExecuteSQLQuery("update settings set isAllowMultiPriceLevels='False'")
        Else
            ExecuteSQLQuery("update settings set isAllowMultiPriceLevels='True'")
        End If


        If IsPrintChequeOnSave.Text = "NO" Or IsPrintChequeOnSave.Text = "" Then
            ExecuteSQLQuery("update settings set IsAllowChequePrinting='False'")
        Else
            ExecuteSQLQuery("update settings set IsAllowChequePrinting='True'")
        End If

        If DefCostMethod.Text = "" Then
            ExecuteSQLQuery("update settings set CostingMethod='AVERAGE'")
        Else
            ExecuteSQLQuery("update settings set CostingMethod=N'" & DefCostMethod.Text & "'")
        End If

        If IsAllowMrngEvngDuties.Text = "YES" Then
            ExecuteSQLQuery("update settings set IsAllowMrngEvngShifts='True'")
        Else
            ExecuteSQLQuery("update settings set IsAllowMrngEvngShifts='False'")
        End If


        If IsSingleEntryMode.Text = "YES" Then
            ExecuteSQLQuery("update settings set IsSingleEntryMode='True'")
        Else
            ExecuteSQLQuery("update settings set IsSingleEntryMode='False'")
        End If

        If IsAllowNarrations.Text = "YES" Then
            ExecuteSQLQuery("update settings set AllowNarrationinvouchers='True'")
        Else
            ExecuteSQLQuery("update settings set AllowNarrationinvouchers='False'")
        End If
        If IsAllowCostCenterOnInvoice.Text = "YES" Then
            ExecuteSQLQuery("update settings set IsallowCostingforInvoice='True'")
        Else
            ExecuteSQLQuery("update settings set IsallowCostingforInvoice='False'")
        End If

        If IsCustomTaxRate.Text = "YES" Then
            ExecuteSQLQuery("update settings set IsMultiTaxRates='True'")
        Else
            ExecuteSQLQuery("update settings set IsMultiTaxRates='False'")
        End If

        If TxtSalesVat.Text = "YES" Then
            ExecuteSQLQuery("update settings set SalesPricewithTax='True'")
        Else
            ExecuteSQLQuery("update settings set SalesPricewithTax='False'")
        End If


        If TxtItemVAT.Text = "YES" Then
            ExecuteSQLQuery("update settings set StockPricewithTax='True'")
        Else
            ExecuteSQLQuery("update settings set StockPricewithTax='False'")
        End If

        If IsEmptyBatchNo.Text = "YES" Then
            ExecuteSQLQuery("update settings set IsAllowEmptyBatchNo='True'")
        Else
            ExecuteSQLQuery("update settings set IsAllowEmptyBatchNo='False'")
        End If
        If IsmultiPurchTax.Text = "YES" Then
            ExecuteSQLQuery("update settings set IsAllowMultiPurchaseTax='True'")
        Else
            ExecuteSQLQuery("update settings set IsAllowMultiPurchaseTax='False'")
        End If
        If IsmulittaxonSales.Text = "YES" Then
            ExecuteSQLQuery("update settings set IsAllowMultiSalesTax='True'")
        Else
            ExecuteSQLQuery("update settings set IsAllowMultiSalesTax='False'")
        End If
        If TxtcustomPrint.Text = "YES" Then
            ExecuteSQLQuery("update settings set customPrint='True'")
        Else
            ExecuteSQLQuery("update settings set customPrint='False'")
        End If

        If IsAllowPurchaseApproved.Text = "YES" Then
            ExecuteSQLQuery("update settings set IsAllowOnlyApprovedPurchaseenquiry='True'")
        Else
            ExecuteSQLQuery("update settings set IsAllowOnlyApprovedPurchaseenquiry='False'")
        End If
        If IsAllowSalesApproved.Text = "YES" Then
            ExecuteSQLQuery("update settings set IsAllowOnlyApprovedSalesenquiry='True'")
        Else
            ExecuteSQLQuery("update settings set IsAllowOnlyApprovedSalesenquiry='False'")
        End If
        ExecuteSQLQuery("update settings set DefPaymentMethodinPurchase=N'" & TxtDefPaymentOnPurchase.Text & "'")
        ExecuteSQLQuery("update settings set DefPaymentMethodInSales=N'" & TxtDefPaymentOnSales.Text & "'")
        'IsAllowMultiTax
        'customPrint
        LoadSettings()

        If MyAppSettings.IsCustomBarcode = True Then
            MainForm.CustomBarcodeSettingsToolStripMenuItem.Visible = True
            IsCustomBarCode = True
        Else
            MainForm.CustomBarcodeSettingsToolStripMenuItem.Visible = False
            IsCustomBarCode = False
        End If

        MainForm.SetAdditionalMenuSettings()

        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub InventorySettings_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub AppSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand

        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = "select * from settings"
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()
                IsBillWise.Text = IIf(Sreader("IsBillWise") = "True", "YES", "NO")
                IsNewInvoiceAfterSave.Text = IIf(Sreader("IsNewInvoiceOnSave") = "True", "YES", "NO")
                IsPrintOnSave.Text = IIf(Sreader("IsAutoPrinting") = "True", "YES", "NO")
                IsBatchWise.Text = IIf(Sreader("IsBatchExpiry") = "True", "YES", "NO")
                IsAllowCashOnJournal.Text = IIf(Sreader("IsAllowCashBankinJournal") = "True", "YES", "NO")
                IsAllowDuplicateRef.Text = IIf(Sreader("IsAllowDuplicateRef") = "True", "YES", "NO")
                IsAllowZeroStock.Text = IIf(Sreader("IsAllowZeroValueStock") = "True", "YES", "NO")
                IsAllowNagativeStock.Text = IIf(Sreader("IsAllowNagetiveStock") = "True", "YES", "NO")
                IsAllowCustomBarcode.Text = IIf(Sreader("IsCustomBarcode") = "True", "YES", "NO")
                IsAllowShowAllRef.Text = IIf(Sreader("IsAllowAllRef") = "True", "YES", "NO")
                IsAlloExtraFiledInDNote.Text = IIf(Sreader("IsAllowPriceField") = "True", "YES", "NO")

                IsAllowDebitNote.Text = IIf(Sreader("IsAllowDebitNote") = "True", "YES", "NO")
                IsAllowCreditNote.Text = IIf(Sreader("IsAllowCreditNote") = "True", "YES", "NO")
                IsAllowSalesOrder.Text = IIf(Sreader("IsAllowSalesOrders") = "True", "YES", "NO")
                IsAllowPurchOrder.Text = IIf(Sreader("IsAllowPurchaseOrders") = "True", "YES", "NO")
                IsAllowDeliveryNote.Text = IIf(Sreader("IsAllowDeliveryNote") = "True", "YES", "NO")
                IsAllowGReciptNote.Text = IIf(Sreader("IsAllowGReceiptNote") = "True", "YES", "NO")
                ISMuliPriceList.Text = IIf(Sreader("isAllowMultiPriceLevels") = "True", "YES", "NO")
                IsPrintChequeOnSave.Text = IIf(Sreader("IsAllowChequePrinting") = "True", "YES", "NO")

                DefCostMethod.Text = Sreader("CostingMethod").ToString.Trim
                IsAllowMrngEvngDuties.Text = IIf(Sreader("IsAllowMrngEvngShifts") = "True", "YES", "NO")
                IsSingleEntryMode.Text = IIf(Sreader("IsSingleEntryMode") = "True", "YES", "NO")
                IsAllowNarrations.Text = IIf(Sreader("AllowNarrationinvouchers") = "True", "YES", "NO")
                IsAllowCostCenterOnInvoice.Text = IIf(Sreader("IsallowCostingforInvoice") = "True", "YES", "NO")
                IsCustomTaxRate.Text = IIf(Sreader("IsMultiTaxRates") = "True", "YES", "NO")
                TxtItemVAT.Text = IIf(Sreader("StockPricewithTax") = "True", "YES", "NO")
                TxtSalesVat.Text = IIf(Sreader("SalesPricewithTax") = "True", "YES", "NO")
                IsEmptyBatchNo.Text = IIf(Sreader("IsAllowEmptyBatchNo") = "True", "YES", "NO")
                IsmultiPurchTax.Text = IIf(Sreader("IsAllowMultiPurchaseTax") = "True", "YES", "NO")
                IsmulittaxonSales.Text = IIf(Sreader("IsAllowMultiSalesTax") = "True", "YES", "NO")
                TxtcustomPrint.Text = IIf(Sreader("customPrint") = "True", "YES", "NO")
                IsAllowCustomPriceInSales.Text = Sreader("PosPriceList").ToString.Trim
                TxtPurchaseZeroTax.Checked = Sreader("ZerotaxonPurchase")
                TxtDefPaymentOnPurchase.Text = Sreader("DefPaymentMethodinPurchase").ToString
                TxtDefPaymentOnSales.Text = Sreader("DefPaymentMethodInSales").ToString
                Try
                    IsAllowPurchaseApproved.Text = IIf(Sreader("IsAllowOnlyApprovedPurchaseenquiry").ToString = "True", "YES", "NO")
                    IsAllowSalesApproved.Text = IIf(Sreader("IsAllowOnlyApprovedSalesenquiry").ToString = "True", "YES", "NO")
                Catch ex As Exception

                End Try

          
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn = Nothing
            Sqlcmmd.Connection = Nothing
        End Try
        LoadPriceListNames()
        IsAllowCustomPriceInSales.Text = MyAppSettings.POSPriceListName
        ImSlabel9.Text = "Is Custom Barcode? (" & DefaultBarcodeLength & " Digits)"
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles IsBillWise.KeyPress, MyBase.KeyPress, IsAllowCustomBarcode.KeyPress, IsAllowNagativeStock.KeyPress, IsAllowZeroStock.KeyPress, IsAllowDuplicateRef.KeyPress, IsAllowCashOnJournal.KeyPress, IsBatchWise.KeyPress, IsPrintOnSave.KeyPress, IsSingleEntryMode.KeyPress, IsAllowMrngEvngDuties.KeyPress, DefCostMethod.KeyPress, IsNewInvoiceAfterSave.KeyPress, IsPrintChequeOnSave.KeyPress, ISMuliPriceList.KeyPress, IsAllowGReciptNote.KeyPress, IsAllowDeliveryNote.KeyPress, IsAllowPurchOrder.KeyPress, IsAllowSalesOrder.KeyPress, IsAllowCreditNote.KeyPress, IsAllowDebitNote.KeyPress, IsAlloExtraFiledInDNote.KeyPress, IsAllowShowAllRef.KeyPress, IsAllowNarrations.KeyPress, IsAllowCostCenterOnInvoice.KeyPress, IsAllowCustomPriceInSales.KeyPress, IsCustomTaxRate.KeyPress, TxtItemVAT.KeyPress, TxtSalesVat.KeyPress, IsEmptyBatchNo.KeyPress, IsmultiPurchTax.KeyPress, IsmulittaxonSales.KeyPress, TxtcustomPrint.KeyPress, IsAllowSalesApproved.KeyPress, IsAllowPurchaseApproved.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Me.TopLevelControl.SelectNextControl(sender, True, True, True, True)
        End If
    End Sub


    Private Sub ComboBox16_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsAllowDeliveryNote.SelectedIndexChanged
        IsAllowGReciptNote.Text = IsAllowDeliveryNote.Text
    End Sub

    Private Sub ComboBox17_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsAllowGReciptNote.SelectedIndexChanged
        IsAllowDeliveryNote.Text = IsAllowGReciptNote.Text
    End Sub
End Class