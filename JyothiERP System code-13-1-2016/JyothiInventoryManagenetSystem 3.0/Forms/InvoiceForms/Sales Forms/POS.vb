Imports System.Drawing.Printing

Public Class POS
    Dim NewAddItem As New ChooseItemClass
    Dim TxtStockQty As New JyothiPharmaERPSystem3.IMSQtyBox
    Dim IsInvoiceSaved As Boolean = False
    Dim OpenedTranscode As Single = 0
    Dim IsInvoiceOpened As Boolean = False
    Dim isloading As Boolean = True
    Dim taxeslist As New ComboBox
    Dim PrintingScheme As String = ""
    Private Sub POS_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtBarcode.Focus()
        If POSSettings.AllowPaymentMethod = True Then
            If POSSettings.CashLedger.Length = 0 Or POSSettings.CreditCardLedger.Length = 0 Or POSSettings.ChequeLedger.Length = 0 Or POSSettings.GiftCardLedger.Length = 0 Then
                MsgBox("Please set the default Ledger allocation for Payment methods...", MsgBoxStyle.Information)
                Dim frm As New PosSettingfrm
                frm.ShowDialog()
                If POSSettings.CashLedger.Length = 0 Or POSSettings.CreditCardLedger.Length = 0 Or POSSettings.ChequeLedger.Length = 0 Or POSSettings.GiftCardLedger.Length = 0 Then
                    Me.Close()
                End If
            End If
        End If
       
    End Sub
    Sub LoadDefults()
        TxtDate.Value = Now
        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.POS)
        If InvoiceBillingSettings.POS.InvoiceMethod = 0 Then
            TxtQutoNo.Enabled = False
        Else
            TxtQutoNo.Enabled = True
        End If
        TxtBillType.Text = "Cash Bill"
        TxtTotalQty.Text = "Total Qty : 0"
        TxtNarration.Text = ""
        TxtCashtoPay.Text = ""
        TxtReceivedCash.Text = ""
        TxtAmountinWords.Text = ""
        LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.CustomersAccounts & "' or groupname=N'" & AccountGroupNames.SuppliersAccounts & "')", txtLedgerName, "ledgername")
        TxtPaymentList.Rows.Clear()
        TxtPriceLevel.Items.Clear()
        LoadDataIntoComboBox("select  pricelistname from pricelist", TxtPriceLevel, "pricelistname")
        TxtPriceLevel.Items.Add("Wholesale")
        TxtPriceLevel.Items.Add("Retail")
        txtList.Rows.Clear()
        TxtPriceLevel.Items.Add("Custom")
        TxtPriceLevel.Text = "Wholesale"
        txtLedgerName.Text = DefLedgers.CashAccount
        TxtCurrency.Text = CompDetails.Currency
        TxtPriceLevel.Text = "Retail"
        TxtSubTotal.Text = "0"
        TxtTaxTotal.Text = "0"

        IsInvoiceOpened = False
        IsInvoiceSaved = True
        TxtNetTotal.Text = "0"

        TxtDiscountTotal.Text = "0"
        TxtDiscPer.Text = "0"
        TxtBarcode.Focus()
    End Sub
    Private Sub POS_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        isloading = True
        If User_IsAllowtoDelete = True Then

        Else

        End If
       
        LoadDefults()
        isloading = False
        If Dummydata = True Then
            BtnRough.Visible = True
            BtnRough.Enabled = True
        Else
            BtnRough.Visible = False
            BtnRough.Enabled = False
        End If
        If POSSettings.AllowPriceAlter = False Then
            txtList.Columns("strate").ReadOnly = True
        End If
        If POSSettings.AllowDiscountAlter = False Then
            txtList.Columns("stDisc").ReadOnly = True
        End If
        If POSSettings.IsAllowTochangeDate = False Then
            TxtDate.Enabled = False
        End If
        If POSSettings.IsAllowMultiCurrency = False Then
            LblMultiCurrencyLabel.Visible = False
            TxtCurrency.Enabled = False
            TxtCurrency.Visible = False

        End If
        If POSSettings.AllowPaymentMethod = True Then
            lblcahsreceived.Visible = False
            lblchangetopay.Visible = False
            TxtCashtoPay.Visible = False
            TxtReceivedCash.Visible = False
        End If
        If POSSettings.IsAllowCreditSales = True Then
            TxtBillType.Text = "Cash Bill"
            TxtBillType.Enabled = True
            TxtBillType.Visible = True
            ImSlabel13.Visible = True
        Else
            TxtBillType.Text = "Cash Bill"
            TxtBillType.Enabled = False
            TxtBillType.Visible = False
            ImSlabel13.Visible = False
        End If
        TxtPriceLevel.Text = POSSettings.DefaultPriceList
        LoadDataIntoComboBox("select currencycode from currencylist", TxtCurrency, "Currencycode")
        TxtCurrency.Text = CompDetails.Currency
        If POSSettings.ShowKeyboard = True Then
            Try
                Dim p As New Process()
                p.StartInfo = New ProcessStartInfo(Application.StartupPath & "\osk.exe")
                p.Start()
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub txtList_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles txtList.CellClick
        txtList.Focus()
    End Sub

    Private Sub txtList_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles txtList.CellEndEdit
        CalculateRowValues(e.RowIndex)
        TxtBarcode.Focus()
    End Sub
    Sub CalculateRowValues(rno As Integer)
        Dim netrate As Double = 0

        txtList.Item("stnetrate", rno).Value = txtList.Item("strate", rno).Value - txtList.Item("strate", rno).Value * txtList.Item("stdisc", rno).Value / 100
        txtList.Item("stnetrate", rno).Value = txtList.Item("stnetrate", rno).Value + txtList.Item("stnetrate", rno).Value * txtList.Item("sttax", rno).Value / 100
        If txtList.Item("stissimpleunit", txtList.CurrentRow.Index).Value = 0 Then
            TxtStockQty.SetUnitName(txtList.Item("STUNITNAME", txtList.CurrentRow.Index).Value)
            TxtStockQty.ClearQty()
            Dim Strqty As String = ""
            Strqty = txtList.Item("stqty", rno).Value
            If Strqty.Contains("-") = True Then
                Dim q1 As String = ""
                Dim q2 As String = ""
                q1 = Strqty.Substring(0, Strqty.IndexOf("-"))
                q2 = Strqty.Substring(Strqty.IndexOf("-") + 1)
                If q2.Length > 0 Then
                    TxtStockQty.TxtQty1.Text = CDbl(q1)
                    TxtStockQty.TxtQty2.Text = CDbl(q2)
                    TxtStockQty.CalculateValues()
                    Strqty = TxtStockQty.TxtQty1.Text & "-" & TxtStockQty.TxtQty2.Text
                Else
                    TxtStockQty.TxtQty1.Text = CDbl(q1)
                    TxtStockQty.TxtQty2.Text = 0
                    TxtStockQty.CalculateValues()
                    Strqty = TxtStockQty.TxtQty1.Text
                End If
                netrate = TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion() * txtList.Item("strate", rno).Value
                txtList.Item("stqty", rno).Value = Strqty
            Else
                netrate = txtList.Item("stqty", rno).Value * txtList.Item("strate", rno).Value
            End If




        Else
            netrate = txtList.Item("stqty", rno).Value * txtList.Item("strate", rno).Value
        End If


        netrate = netrate - netrate * txtList.Item("stdisc", rno).Value / 100
        txtList.Item("ststockvalue", rno).Value = netrate
        txtList.Item("sttaxvalue", rno).Value = netrate * txtList.Item("sttax", rno).Value / 100
        txtList.Item("stTotal", rno).Value = netrate + CDbl(txtList.Item("sttaxvalue", rno).Value)

        findInvoiceTotals()
    End Sub
    Sub findInvoiceTotals()
        If isloading = True Then Exit Sub
        Dim nettotal As Double = 0
        Dim TAXTOTAL As Double = 0
        Dim TotalQty As Integer = 0
        For I As Integer = 0 To txtList.RowCount - 1
            TAXTOTAL = TAXTOTAL + CDbl(txtList.Item("sttaxvalue", I).Value)
            nettotal = nettotal + CDbl(txtList.Item("stTotal", I).Value)
            Dim Strqty As String = ""
            Strqty = txtList.Item("stqty", I).Value
            If Strqty.Contains("-") = True Then
                Dim q1 As String = ""
                Dim q2 As String = ""
                q1 = Strqty.Substring(0, Strqty.IndexOf("-"))
                TotalQty = TotalQty + CInt(q1)
            Else
                TotalQty = TotalQty + CInt(Strqty)
            End If
        Next
        TxtTotalQty.Text = "Total Qty : " & TotalQty.ToString
        TxtSubTotal.Text = FormatNumber(nettotal - TAXTOTAL, 2)
        TxtTaxTotal.Text = FormatNumber(TAXTOTAL, 2)
        TxtNetTotal.Text = FormatNumber(nettotal + CDbl(TxtDiscountTotal.Text), 2)
        If TxtDiscPer.Text.Length = 0 Then
            TxtDiscPer.Text = "0.00"
        Else
            If CDbl(TxtSubTotal.Text) > 0 Then
                Try
                    TxtDiscountTotal.Text = FormatNumber(-1 * CDbl(TxtSubTotal.Text) * CDbl(TxtDiscPer.Text) / 100, ErpDecimalPlaces, , , TriState.False)
                Catch ex As Exception

                End Try

            Else
                TxtDiscountTotal.Text = "0.00"
            End If

        End If
      
    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles txtList.EditingControlShowing
        If txtList.Columns("sttax").Index = txtList.CurrentCell.ColumnIndex Then Exit Sub
        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress1

    End Sub

    Private Sub TextBox_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)

        If Char.IsDigit(CChar(CStr(e.KeyChar))) = False Then e.Handled = True

    End Sub

    Private Sub TextBox_keyPress1(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then

        End If
        e.Handled = Not (IsNumeric(e.KeyChar) Or (e.KeyChar = "." And Not CBool(InStr(sender.Text, "."))))
        If txtList.CurrentCell.ColumnIndex = txtList.Columns("stqty").Index Then
            If txtList.Item("stissimpleunit", txtList.CurrentRow.Index).Value = 0 Then
                If e.KeyChar = "-" Then
                    If CBool(InStr(sender.Text, "-")) = True Then
                        e.Handled = True
                    Else
                        e.Handled = False
                    End If
                End If
            End If
        End If

        If e.KeyChar = Chr(&H8) Then e.Handled = False


    End Sub
    

    Private Sub TxtBarcode_LostFocus(sender As Object, e As System.EventArgs) Handles TxtBarcode.LostFocus
        CheckBarcodeAndLoadData()
    End Sub
    Sub CheckBarcodeAndLoadData()
        If TxtBarcode.Text.Length = 0 Then Exit Sub
        TxtBarcode.Text = GetAlternativeBarcode(TxtBarcode.Text)
        LoadStockDataByBarCode(TxtBarcode.Text, GetLocation)
        TxtBarcode.Text = ""
        TxtBarcode.Focus()
    End Sub
    Sub LoadStockDataByBarCode(ByVal barcode As String, ByVal STOCKLOCATION As String)
        If TxtBarcode.Text.Length = 0 Then Exit Sub

        If SQLIsFieldExists("select stockcode from stockdbf where custbarcode=N'" & barcode & "' and location=N'" & STOCKLOCATION & "'") = False Then
            If SQLIsFieldExists("select stockcode from stockdbf where stockcode=N'" & barcode & "' and stocksize='' and location=N'" & STOCKLOCATION & "'") = True Then
                LoadStockItemsIntoClassWithStockDetails(barcode, "", "", NewAddItem, STOCKLOCATION)
                AddItems()
                TxtBarcode.Text = ""
                TxtBarcode.Focus()
                Exit Sub
            Else
                Dim bvalue As New ChooseItemClass
                bvalue.StockItemBarCode = 0
                Dim k As New ChooseItems(bvalue)
                If POSSettings.AllowNewItem = False Then
                    k.BtnCreate.Enabled = False
                End If
                bvalue.CurrentField = 0
                bvalue.CurrentChar = TxtBarcode.Text
                TxtBarcode.Text = ""
                If k.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    If bvalue.StockItemBarCode.Length <> 0 Then
                        LoadStockItemsIntoClass(bvalue.StockItemBarCode, bvalue.StockLocation, NewAddItem)
                        AddItems()
                    End If
                End If
                bvalue = Nothing
                k.Dispose()
                TxtBarcode.Text = ""
                TxtBarcode.Focus()
                Exit Sub
            End If
        End If

        If LoadStockItemsIntoClassByCustBarCode(barcode, STOCKLOCATION, NewAddItem) = False Then Exit Sub

        AddItems()

    End Sub
    Sub AddItems()
        Dim nR As Integer
        If NewAddItem.IsBatchNo = 1 Then
            Dim frm As New PosSelectBatchNumberExpiryFrm(NewAddItem)
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                NewAddItem.StockBatchNo = frm.SelectedBatchNo
                NewAddItem.ExpDatePicker.Value = frm.selectedExpiryDate.Value
                NewAddItem.MRP = frm.selectedMRP

            Else
                TxtBarcode.Text = ""
                TxtBarcode.Focus()
                Exit Sub
            End If
        End If
        If POSSettings.ZeroTax = True Then
            NewAddItem.Tax = 0
            NewAddItem.Tax2 = 0
        End If

        nR = txtList.Rows.Add()
        txtList.Item("stsno", nR).Value = nR + 1
        txtList.Item("stlocation", nR).Value = NewAddItem.StockLocationNames
        txtList.Item("stitemname", nR).Value = NewAddItem.StockItemName
        txtList.Item("stcustbarcode", nR).Value = NewAddItem.CustBarCode
        txtList.Item("stbarcode", nR).Value = NewAddItem.StockItemBarCode
        txtList.Item("STItemCode", nR).Value = NewAddItem.StockItemCode
        txtList.Item("stsize", nR).Value = NewAddItem.StockITemSize
        txtList.Item("stbatchno", nR).Value = NewAddItem.StockBatchNo
        txtList.Item("stexpiry", nR).Value = NewAddItem.ExpDatePicker.Value
        txtList.Item("stissimpleunit", nR).Value = NewAddItem.IsSimpleUnit
        txtList.Item("STUNITNAME", nR).Value = NewAddItem.StockUnitName

        TxtStockQty.SetUnitName(NewAddItem.StockUnitName)
        TxtStockQty.ClearQty()
        TxtStockQty.TxtQty1.Text = "1"
        txtList.Item("stqty", nR).Value = "1"
        Dim StockRate As Double = 0
        If TxtPriceLevel.Text = "Custom" Then
            StockRate = FormatNumber(SQLGetNumericFieldValue("select top 1 stockrate from StockInvoiceRowItems where transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & txtLedgerName.Text & "') and stockcode=N'" & NewAddItem.StockItemCode & "' and stocksize=N'" & NewAddItem.StockITemSize & "' order by transdate desc ", "stockrate"), 3, , , TriState.False)
        Else
            StockRate = FormatNumber(GetStockRateByPriceListName(TxtPriceLevel.Text, NewAddItem.StockItemBarCode, NewAddItem.StockLocation), 3, , , TriState.False)
        End If

        If StockRate = 0 Then
            StockRate = NewAddItem.StockRate
        End If
        StockRate = GetFinalRateByDiscounts(NewAddItem.StockItemBarCode, StockRate, TxtDate)
        'CHANGES 
        If NewAddItem.IsTaxInclude = True Then
            Dim NetRate As Double = 0
            NetRate = StockRate
            NetRate = NetRate * 100 / (100 + CDbl(NewAddItem.Tax))
            StockRate = NetRate
        End If
        'END
        txtList.Item("strate", nR).Value = StockRate
        txtList.Item("stdisc", nR).Value = 0
        txtList.Item("sttax", nR).Value = NewAddItem.Tax
        txtList.Item("stmrp", nR).Value = NewAddItem.MRP
        txtList.Item("sttaxvalue", nR).Value = NewAddItem.Tax * StockRate
        txtList.Item("stTotal", nR).Value = StockRate + NewAddItem.Tax * StockRate
        CalculateRowValues(nR)
        IsInvoiceSaved = False
        findInvoiceTotals()
        TxtBarcode.Text = ""
        TxtBarcode.Focus()

    End Sub
    
    Private Sub btnPlus_Click(sender As System.Object, e As System.EventArgs) Handles btnPlus.Click

        Try
            If txtList.CurrentCell.ColumnIndex = txtList.Columns("stqty").Index Or txtList.CurrentCell.ColumnIndex = txtList.Columns("sttax").Index Or txtList.CurrentCell.ColumnIndex = txtList.Columns("stdisc").Index Or txtList.CurrentCell.ColumnIndex = txtList.Columns("strate").Index Then
                If CDbl(txtList.CurrentCell.Value) + 1 >= 0 Then
                    txtList.CurrentCell.Value = CDbl(txtList.CurrentCell.Value) + 1
                End If

                CalculateRowValues(txtList.CurrentRow.Index)
            End If
        Catch ex As Exception

        End Try
        TxtBarcode.Focus()
    End Sub

    Private Sub btnMinus_Click(sender As System.Object, e As System.EventArgs) Handles btnMinus.Click

        Try
            If txtList.CurrentCell.ColumnIndex = txtList.Columns("stqty").Index Or txtList.CurrentCell.ColumnIndex = txtList.Columns("sttax").Index Or txtList.CurrentCell.ColumnIndex = txtList.Columns("stdisc").Index Or txtList.CurrentCell.ColumnIndex = txtList.Columns("strate").Index Then
                If CDbl(txtList.CurrentCell.Value) - 1 >= 0 Then
                    txtList.CurrentCell.Value = CDbl(txtList.CurrentCell.Value) - 1
                End If

                CalculateRowValues(txtList.CurrentRow.Index)
            End If
        Catch ex As Exception

        End Try
        TxtBarcode.Focus()
    End Sub

    Private Sub BtnAdd5_Click(sender As System.Object, e As System.EventArgs) Handles BtnAdd5.Click
        Try
            If txtList.CurrentCell.ColumnIndex = txtList.Columns("stqty").Index Or txtList.CurrentCell.ColumnIndex = txtList.Columns("sttax").Index Or txtList.CurrentCell.ColumnIndex = txtList.Columns("stdisc").Index Or txtList.CurrentCell.ColumnIndex = txtList.Columns("strate").Index Then
                If CDbl(txtList.CurrentCell.Value) + 5 >= 0 Then
                    txtList.CurrentCell.Value = CDbl(txtList.CurrentCell.Value) + 5
                End If

                CalculateRowValues(txtList.CurrentRow.Index)
            End If
        Catch ex As Exception

        End Try
        TxtBarcode.Focus()
    End Sub

    Private Sub BtnMinus5_Click(sender As System.Object, e As System.EventArgs) Handles BtnMinus5.Click
        Try
            If txtList.CurrentCell.ColumnIndex = txtList.Columns("stqty").Index Or txtList.CurrentCell.ColumnIndex = txtList.Columns("sttax").Index Or txtList.CurrentCell.ColumnIndex = txtList.Columns("stdisc").Index Or txtList.CurrentCell.ColumnIndex = txtList.Columns("strate").Index Then
                If CDbl(txtList.CurrentCell.Value) - 5 >= 0 Then
                    txtList.CurrentCell.Value = CDbl(txtList.CurrentCell.Value) - 5
                End If

                CalculateRowValues(txtList.CurrentRow.Index)
            End If
        Catch ex As Exception

        End Try
        TxtBarcode.Focus()
    End Sub



    Private Sub Label1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown, Label9.MouseDown, Label8.MouseDown, Label7.MouseDown, Label6.MouseDown, Label5.MouseDown, Label4.MouseDown, Label3.MouseDown, Label2.MouseDown, Label16.MouseDown, Label15.MouseDown, Label14.MouseDown, Label12.MouseDown, Label11.MouseDown, Label10.MouseDown, Label19.MouseDown, Label18.MouseDown, Label17.MouseDown, Label13.MouseDown, Label20.MouseDown
        sender.BorderStyle = BorderStyle.Fixed3D

    End Sub

    Private Sub Label1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp, Label9.MouseUp, Label8.MouseUp, Label7.MouseUp, Label6.MouseUp, Label5.MouseUp, Label4.MouseUp, Label3.MouseUp, Label2.MouseUp, Label16.MouseUp, Label15.MouseUp, Label14.MouseUp, Label12.MouseUp, Label11.MouseUp, Label10.MouseUp, Label19.MouseUp, Label18.MouseUp, Label17.MouseUp, Label13.MouseUp, Label20.MouseUp
        sender.BorderStyle = BorderStyle.FixedSingle

        If sender.TEXT.ToUPPER = "B" Then
            SendKeys.Send("{BACKSPACE}")
        ElseIf sender.TEXT.ToUPPER = "ENTER" Then
            SendKeys.Send("{ENTER}")
        ElseIf sender.TEXT.ToUPPER = "TAB" Then
            SendKeys.Send("{TAB}")
        ElseIf sender.TEXT.ToUPPER = "DEL" Then
            SendKeys.Send("{DELETE}")
        ElseIf sender.TEXT.ToUPPER = "L" Then
            SendKeys.Send("{LEFT}")
        ElseIf sender.TEXT.ToUPPER = "R" Then
            SendKeys.Send("{RIGHT}")
        ElseIf sender.TEXT.ToUPPER = "D" Then
            SendKeys.Send("{DOWN}")
        ElseIf sender.TEXT.ToUPPER = "U" Then
            SendKeys.Send("{UP}")
        ElseIf sender.TEXT.ToUPPER = "-" Then
            SendKeys.Send("-")

        Else
            SendKeys.Send(sender.text)
        End If
    End Sub


    Private Sub txtList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles txtList.CellContentClick

    End Sub

    Private Sub txtList_CellValidating(sender As Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles txtList.CellValidating
        If e.ColumnIndex = txtList.Columns("stqty").Index Or e.ColumnIndex = txtList.Columns("strate").Index Or e.ColumnIndex = txtList.Columns("stmrp").Index Then
            If e.FormattedValue.ToString.Length = 0 Then
                e.Cancel = True
                Me.txtList.Rows(e.RowIndex).ErrorText = "the value must be a non-negative integer"
                If MsgBox("The Values is Empty, Please try again                   ", MsgBoxStyle.RetryCancel + MsgBoxStyle.Critical) = MsgBoxResult.Cancel Then
                    SendKeys.Send("{ESC}")
                End If
            Else
                If e.FormattedValue.ToString.Contains("-") = True Then
                    If e.FormattedValue.ToString.Length > 9 Then
                        e.Cancel = True
                        Me.txtList.Rows(e.RowIndex).ErrorText = "the value must be a non-negative integer"
                        If MsgBox("The Values is too Big, Please try again                ", MsgBoxStyle.RetryCancel + MsgBoxStyle.Critical) = MsgBoxResult.Cancel Then
                            SendKeys.Send("{ESC}")
                        End If
                    End If
                Else
                    If CDbl(e.FormattedValue.ToString) > 99999999 Then
                        e.Cancel = True
                        Me.txtList.Rows(e.RowIndex).ErrorText = "the value must be a non-negative integer"
                        If MsgBox("The Values is too Big, Please try again                ", MsgBoxStyle.RetryCancel + MsgBoxStyle.Critical) = MsgBoxResult.Cancel Then
                            SendKeys.Send("{ESC}")
                        End If
                    End If
                End If

            End If

        ElseIf e.ColumnIndex = txtList.Columns("stdisc").Index Then
            If txtList.CurrentCell.Value.ToString.Length = 0 Then
                e.Cancel = True
                Me.txtList.Rows(e.RowIndex).ErrorText = "the value must be a non-negative integer"
                If MsgBox("The Values is Empty, Please try again           ", MsgBoxStyle.RetryCancel + MsgBoxStyle.Critical) = MsgBoxResult.Cancel Then
                    SendKeys.Send("{ESC}")
                End If
            Else
                If CDbl(e.FormattedValue.ToString) > 100 Then
                    e.Cancel = True
                    Me.txtList.Rows(e.RowIndex).ErrorText = "the value must be a non-negative integer"
                    If MsgBox("The Values is too Big, Please try again          ", MsgBoxStyle.RetryCancel + MsgBoxStyle.Critical) = MsgBoxResult.Cancel Then
                        SendKeys.Send("{ESC}")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub TxtDiscountTotal_Click(sender As Object, e As System.EventArgs) Handles TxtDiscountTotal.Click
        TxtDiscountTotal.SelectAll()
    End Sub

    Private Sub TxtDiscountTotal_LostFocus(sender As Object, e As System.EventArgs) Handles TxtDiscountTotal.LostFocus
        If TxtDiscountTotal.Text.Length = 0 Then
            TxtDiscPer.Text = "0"
        Else
            If CDbl(TxtSubTotal.Text) > 0 Then
                TxtDiscPer.Text = CDbl(TxtDiscountTotal.Text) * -1 * 100 / CDbl(TxtSubTotal.Text)
            Else
                TxtDiscPer.Text = "0"
            End If

        End If
    End Sub




    Private Sub TxtDiscPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtDiscPer.TextChanged
        findInvoiceTotals()
    End Sub

    Private Sub TxtDiscountTotal_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ImsButton3_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton3.Click
        If txtList.RowCount > 0 Then
            If MsgBox("Do you want to Remove the Selected Item Row?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                txtList.Rows.RemoveAt(txtList.CurrentRow.Index)
                findInvoiceTotals()
            End If
        End If
        TxtBarcode.Focus()
    End Sub

    Private Sub txtList_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles txtList.DataError

    End Sub

    Private Sub TxtNetTotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtNetTotal.TextChanged
        On Error Resume Next
        TxtCashtoPay.Text = CDbl(TxtReceivedCash.Text) - CDbl(TxtNetTotal.Text)
        TxtAmountinWords.Text = GetInWords(CDbl(TxtNetTotal.Text), DefTailCurrencyName)
        IsInvoiceSaved = False
    End Sub

    Private Sub TxtReceivedCash_Click(sender As Object, e As System.EventArgs) Handles TxtReceivedCash.Click
        TxtReceivedCash.SelectAll()
    End Sub

    Private Sub TxtReceivedCash_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtReceivedCash.TextChanged
        On Error Resume Next
        TxtCashtoPay.Text = FormatNumber(CDbl(TxtReceivedCash.Text) - CDbl(TxtNetTotal.Text), 2, , , TriState.False)
    End Sub


    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click, SearchStockToolStripMenuItem.Click
        Dim bvalue As New ChooseItemClass
        bvalue.StockItemBarCode = 0
        Dim k As New ChooseItems(bvalue)
        If POSSettings.AllowNewItem = False Then
            k.BtnCreate.Enabled = False
        End If

        If k.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If bvalue.StockItemBarCode.Length <> 0 Then
                LoadStockItemsIntoClass(bvalue.StockItemBarCode, bvalue.StockLocation, NewAddItem)
                AddItems()
            End If
        End If

        bvalue = Nothing
        k.Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click, SaveToolStripMenuItem1.Click, SAVE2ToolStripMenuItem.Click
       
        If IsInvoiceOpened = True And APPUserRights.IsEditable = False Then
            MsgBox("Error: Edit is not allowed ,Contact Admin Department ... ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If POSSettings.AllowPaymentMethod = True Then
            If POSSettings.CashLedger.Length = 0 Or POSSettings.CreditCardLedger.Length = 0 Or POSSettings.ChequeLedger.Length = 0 Or POSSettings.GiftCardLedger.Length = 0 Then
                MsgBox("Please set the default Ledger allocation for Payment methods...", MsgBoxStyle.Information)
                Dim frm As New PosSettingfrm
                frm.ShowDialog()
                If POSSettings.CashLedger.Length = 0 Or POSSettings.CreditCardLedger.Length = 0 Or POSSettings.ChequeLedger.Length = 0 Or POSSettings.GiftCardLedger.Length = 0 Then
                    Me.Close()
                End If
            End If
        End If
        CheckBeforesave()
    End Sub
    Sub SendSMS()
        If SQLGetBooleanFieldValue("select IsSendSMS from ledgers where ledgername=N'" & txtLedgerName.Text & "'", "IsSendSMS") = True Then
            Dim TempStr As String = ""
            Dim vhname As String = "SALES"
            If vhname.Length > 0 Then
                If MsgBox("Do you want to Send SMS to Customer Mobile ?        ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
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
            Dim vhname As String = "POS"

            If vhname.Length > 0 Then
                If MsgBox("Do you want to Send SMS to Customer Mobile ?       ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim mbno As String = ""
                    mbno = TxtMobileNo.Text
                    If mbno.Length > 6 Then
                        TempStr = SQLGetStringFieldValue("SELECT MSGTEXT FROM smsmailsettings where vouchername=N'" & vhname & "'", "MSGTEXT")
                        TempStr = TempStr.Replace("@TODAYDATE@", Today.ToString())
                        TempStr = TempStr.Replace("@INVOICENO@", TxtQutoNo.Text)
                        TempStr = TempStr.Replace("@INVOICEDATE@", TxtDate.Value.Date.ToString())
                        TempStr = TempStr.Replace("@PARTYNAME@", TxtCustomerName.Text)
                        TempStr = TempStr.Replace("@CURRENTAMOUNT@", TxtNetTotal.Text)
                        TempStr = TempStr.Replace("@INVOICEBALANCE@", "NAV")
                        TempStr = TempStr.Replace("@PAYMENTBY@", "NAV")
                        TempStr = TempStr.Replace("@BALANCE@", "")
                        TempStr = TempStr.Replace("@CURRENTBALANCE@", "")
                        SendSMSToMobile(mbno, TempStr)
                    End If
                End If

            End If
        End If
    End Sub
    Sub CheckBeforesave()
      
        If DefLedgers.SalesDiscountLedger.Length = 0 Then
            MsgBox("Please set the default ledger for the Sales Discount...      ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If CDbl(TxtSubTotal.Text) < 0 Then
            MsgBox("Please Select the Items, Press any key to add items at item code or item name fileds...")
            TxtBarcode.Focus()
            Exit Sub
        End If
        If txtList.RowCount = 0 Then
            MsgBox("Please Select the Items, Press any key to add items at item code or item name fileds...")
            TxtBarcode.Focus()
            Exit Sub
        End If
        If TxtBillType.Text = "Cash Bill" Then
            txtLedgerName.Text = DefLedgers.CashAccount
        End If
        If SQLIsFieldExists("SELECT TOP 1 1 from   ledgers where ledgername=N'" & txtLedgerName.Text & "'") = False Then
            MsgBox("The Ledger Name : " & txtLedgerName.Text & "  is not exists, It may be modified or deleted, Please make sure and try again....", MsgBoxStyle.Critical)
            txtLedgerName.Focus()
            Exit Sub
        End If
        If POSSettings.AllowPaymentMethod = True Then
            If POSSettings.CashLedger.Length = 0 Or POSSettings.ChequeLedger.Length = 0 Or POSSettings.CreditCardLedger.Length = 0 Or POSSettings.GiftCardLedger.Length = 0 Then
                MsgBox("There are no Default Ledger allocation for Payment Methods, Please Select the ledgers, then try again", MsgBoxStyle.Information)
                Dim posfrm As New PosSettingfrm
                posfrm.ShowDialog()
                Exit Sub
            End If
            Dim frm As New AcceptsPaymentfrm(CDbl(TxtNetTotal.Text))
            If SQLIsFieldExists("select ledgername from ledgers where ledgername=N'" & txtLedgerName.Text & "' and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "')") = True Then
                frm.btnOnaccount.Visible = False
            Else
                frm.btnOnaccount.Visible = True
            End If
            For i As Integer = 0 To TxtPaymentList.Rows.Count - 1
                frm.TxtList.Rows.Add()
                frm.TxtList.Item("stsno", i).Value = i + 1
                frm.TxtList.Item("sttype", i).Value = TxtPaymentList.Item("sttype", i).Value
                frm.TxtList.Item("stamount", i).Value = TxtPaymentList.Item("stamount", i).Value
            Next
            frm.findtotal()
            frm.TxtReceivedCash.Text = TxtReceivedCash.Text
            frm.TxtCashtoPay.Text = TxtCashtoPay.Text
            If Dummydata = True Then
                frm.AddPaymentstoList("Cash")
                frm.TxtReceivedCash.Focus()
            End If
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                TxtPaymentList.Rows.Clear()
                For i As Integer = 0 To frm.TxtList.Rows.Count - 1
                    TxtPaymentList.Rows.Add()
                    TxtPaymentList.Item("spsno", i).Value = i + 1
                    TxtPaymentList.Item("sttype", i).Value = frm.TxtList.Item("sttype", i).Value
                    TxtPaymentList.Item("stamount", i).Value = frm.TxtList.Item("stamount", i).Value
                Next
                TxtReceivedCash.Text = frm.TxtReceivedCash.Text
                TxtCashtoPay.Text = frm.TxtCashtoPay.Text
            Else
                Exit Sub
            End If
            frm.Dispose()
            Me.Cursor = Cursors.WaitCursor
            savedata()
            Me.Cursor = Cursors.Default
            PrintInvoice()
            SendSMS()
            If Dummydata = True Then
                'UpdateLogFile(DefStoreName, OpenedTranscode, "POS", TxtQutoNo.Text, CurrentUserName, "Modified", System.Environment.MachineName, "Modified   POS  by OpenMethod")
                ExecuteSQLQuery("update  StockInvoiceRowItems set Isdelete=1  where transcode=" & OpenedTranscode)
                RollBackStockQuantities()
                RollBackAccounts()
                RollBackUpdatedOrdereditemsQtys()
                ExecuteSQLQuery("delete from VoucherAccounts where transcode=" & OpenedTranscode)
                ExecuteSQLQuery("delete from InvoiceMoreDet where transcode=" & OpenedTranscode)
                ExecuteSQLQuery("delete from StockInvoiceDetails where transcode=" & OpenedTranscode)
                ExecuteSQLQuery("delete from StockInvoiceRowItems where transcode=" & OpenedTranscode)
                ExecuteSQLQuery("delete from UsedTranscodeList where transcode=" & OpenedTranscode)
                ExecuteSQLQuery("delete from PaymentMethodDetails where transcode=" & OpenedTranscode)
                IsInvoiceOpened = False
                LoadDefults()
            Else

                If POSSettings.NewInvoiceAfterSave = True Then
                    LoadDefults()
                    IsInvoiceOpened = False
                Else
                    IsInvoiceOpened = True
                End If

            End If
        Else
            If MsgBox("Do you want to save ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                savedata()
                Me.Cursor = Cursors.Default
                PrintInvoice()
                SendSMS()
                If Dummydata = True Then
                    UpdateLogFile(DefStoreName, OpenedTranscode, "POS", TxtQutoNo.Text, CurrentUserName, "Modified", System.Environment.MachineName, "Modified   POS  by OpenMethod")
                    ExecuteSQLQuery("update  StockInvoiceRowItems set Isdelete=1  where transcode=" & OpenedTranscode)
                    RollBackStockQuantities()
                    RollBackAccounts()
                    RollBackUpdatedOrdereditemsQtys()
                    ExecuteSQLQuery("delete from VoucherAccounts where transcode=" & OpenedTranscode)
                    ExecuteSQLQuery("delete from InvoiceMoreDet where transcode=" & OpenedTranscode)
                    ExecuteSQLQuery("delete from StockInvoiceDetails where transcode=" & OpenedTranscode)
                    ExecuteSQLQuery("delete from StockInvoiceRowItems where transcode=" & OpenedTranscode)
                    ExecuteSQLQuery("delete from UsedTranscodeList where transcode=" & OpenedTranscode)
                    ExecuteSQLQuery("delete from PaymentMethodDetails where transcode=" & OpenedTranscode)
                    IsInvoiceOpened = False
                    LoadDefults()
                Else
                    If POSSettings.NewInvoiceAfterSave = True Then
                        LoadDefults()
                        IsInvoiceOpened = False
                    Else
                        IsInvoiceOpened = True
                    End If
                End If
            End If


        End If
        IsInvoiceSaved = True
        TxtBarcode.Focus()
    End Sub
    Sub PrintInvoice()
        If POSSettings.PrintInvoiceAfterSave = True Then
            PrintNow()
        End If
    End Sub
    Sub PrintNow()
        If POSSettings.DirectPrint = True And POSSettings.defPrinterName.Length > 0 Then
            PrintingScheme = SQLGetStringFieldValue("select schemename from printingschemes where vouchername=N'" & PrintVoucherNames.salespos & "' and isactive =1", "schemename")
            Try
                PrtDoc.PrinterSettings.Copies = POSSettings.NoofCopies
                PrtDoc.PrinterSettings.PrinterName = POSSettings.defPrinterName
                PrtDoc.Print()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Else
            Dim pvalues As New PrintParameters
            pvalues.VouhcerName = PrintVoucherNames.salespos
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
                End If
            End If
        End If
    End Sub
    Sub savedata()
        Me.Cursor = Cursors.WaitCursor
        Dim OpenedCurrencyRate As Double = 1
        If IsInvoiceOpened = True Then
            If Dummydata = False Then
                UpdateLogFile(DefStoreName, OpenedTranscode, "POS", TxtQutoNo.Text, CurrentUserName, "Modified", System.Environment.MachineName, "Modified   POS  by OpenMethod")
                ExecuteSQLQuery("update  StockInvoiceRowItems set Isdelete=1  where transcode=" & OpenedTranscode)
                RollBackStockQuantities()
                RollBackAccounts()
                RollBackUpdatedOrdereditemsQtys()
            End If
            ExecuteSQLQuery("delete from VoucherAccounts where transcode=" & OpenedTranscode)
            ExecuteSQLQuery("delete from InvoiceMoreDet where transcode=" & OpenedTranscode)
            ExecuteSQLQuery("delete from StockInvoiceDetails where transcode=" & OpenedTranscode)
            ExecuteSQLQuery("delete from StockInvoiceRowItems where transcode=" & OpenedTranscode)
            ExecuteSQLQuery("delete from UsedTranscodeList where transcode=" & OpenedTranscode)
            ExecuteSQLQuery("delete from PaymentMethodDetails where transcode=" & OpenedTranscode)

            'DELETE ENTRIES
        Else
            OpenedTranscode = GetAndSetIDCode(EnumIDType.TransCode)
            OpenedCurrencyRate = 1



            If InvoiceBillingSettings.POS.InvoiceMethod = 0 Then
                TxtQutoNo.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.POS)
            Else
                'GetAndSetInvoiceNumber(InvoiceNoStrct.POS)
            End If

            UpdateLogFile(DefStoreName, OpenedTranscode, "POS", TxtQutoNo.Text, CurrentUserName, "Created", System.Environment.MachineName, "Created New POS Invoice")

        End If
        SaveMasterData()
        SaveRowDetailsData()

        If Dummydata = False Then
            UpdateStockForSI_SR_POS()
            SaveTrasactions(OpenedTranscode)
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Sub SaveMasterData()
        If TxtReceivedCash.Text.Length = 0 Or TxtReceivedCash.Text = "" Then
            TxtReceivedCash.Text = "0"
        End If
        If TxtCashtoPay.Text.Length = 0 Then
            TxtCashtoPay.Text = "0"
        End If
        If CDbl(TxtCashtoPay.Text) < 0 Then
            TxtCashtoPay.Text = "0"
        End If
        Dim SqlStr As String = ""
        Try
            SqlStr = "INSERT INTO [StockInvoiceDetails] ([TransCode],[TransDate],[TransDateValue],[QutoNo],[QutoRef],[OrderNo],[OrderRef],[DNoteno]," _
                & "[DnoteRef],[StoreName],[Currency],[PriceList],[SalesPerson],[ProjectName],[Area],[LedgerName],[LedgerAddress],[IsCommit]," _
                & "[IsDelete],[IsPending],[subtotal],[grosstotal],[discountper],[nettotal],[taxtotal],[InvoiceTotal],[AccountTotal]," _
                & "[amountinwords],[narration],[InvoiceNo],[InvoiceRef],[GoodNo],[GoodRef],[CurrencyCon1],[VoucherName],[DelivaryDate],[DelivaryDateValue],[Additions],[Deductions],[PaymentMethod],[PaymentLedger], " _
                & " [PaymentDetails],[AccountLedgerName],[servicetaxtotal],[roundoff],[surcharge],[DiscPer],[CurrencyCon2],[BillCurrency],[CouponName],[CDiscount],[CDisCountPer],[transtype],[taxtotal2],[cstamount],[VoucherType],[AdvancePayment],[customername],IsMultiPayment,BillType ,CashReceived,CashtoPay,CounterId) " _
                & "VALUES (@TransCode,@TransDate,@TransDateValue,@QutoNo,@QutoRef,@OrderNo,@OrderRef,@DNoteno,@DnoteRef,@StoreName,@Currency," _
                & "@PriceList,@SalesPerson,@ProjectName,@Area,@LedgerName,@LedgerAddress,@IsCommit,@IsDelete,@IsPending,@subtotal,@grosstotal," _
                & "@discountper,@nettotal,@taxtotal,@InvoiceTotal,@AccountTotal,@amountinwords,@narration,@InvoiceNo,@InvoiceRef,@GoodNo,@GoodRef,@CurrencyCon1,@VoucherName," _
                & "@DelivaryDate,@DelivaryDateValue,@Additions,@Deductions,@PaymentMethod,@PaymentLedger,@PaymentDetails,@AccountLedgerName, " _
                & " @servicetaxtotal,@roundoff,@surcharge,@DiscPer,@CurrencyCon2,@BillCurrency,@CouponName,@CDiscount,@CDisCountPer,@transtype,@taxtotal2,@cstamount,@VoucherType,@AdvancePayment,@customername,@IsMultiPayment,@BillType,@CashReceived,@CashtoPay,@CounterId)"

            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBF.Parameters
                .AddWithValue("TransCode", OpenedTranscode)
                .AddWithValue("TransDate", TxtDate.Value)
                .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                .AddWithValue("QutoNo", TxtQutoNo.Text)
                .AddWithValue("QutoRef", TxtQutoNo.Text)
                .AddWithValue("OrderNo", "")
                .AddWithValue("OrderRef", "")
                .AddWithValue("DNoteno", "")
                .AddWithValue("DnoteRef", "")
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Currency", CompDetails.Currency)
                .AddWithValue("PriceList", TxtPriceLevel.Text)
                .AddWithValue("SalesPerson", "")
                .AddWithValue("ProjectName", "")
                .AddWithValue("Area", "")
                .AddWithValue("LedgerName", txtLedgerName.Text)
                .AddWithValue("LedgerAddress", TxtMobileNo.Text)
                .AddWithValue("customername", TxtCustomerName.Text)
                .AddWithValue("IsCommit", 0)
                .AddWithValue("IsDelete", 0)
                .AddWithValue("IsPending", 1)
                .AddWithValue("subtotal", CDbl(TxtSubTotal.Text))
                .AddWithValue("grosstotal", CDbl(TxtSubTotal.Text))
                .AddWithValue("discountper", CDbl(TxtDiscPer.Text))
                .AddWithValue("nettotal", CDbl(TxtNetTotal.Text))

                .AddWithValue("VoucherType", "Tax Invoice")
                .AddWithValue("cstamount", 0)
                .AddWithValue("taxtotal", CDbl(TxtTaxTotal.Text))
                .AddWithValue("taxtotal2", 0)


                .AddWithValue("InvoiceTotal", 0)
                .AddWithValue("AccountTotal", 0)
                .AddWithValue("amountinwords", TxtAmountinWords.Text)
                .AddWithValue("narration", "")
                .AddWithValue("InvoiceNo", "")
                .AddWithValue("InvoiceRef", "")
                .AddWithValue("GoodNo", "")
                .AddWithValue("GoodRef", "")
                .AddWithValue("VoucherName", "POS")
                .AddWithValue("PaymentMethod", "Cash")
                .AddWithValue("PaymentLedger", DefCashAccount)
                .AddWithValue("PaymentDetails", "")

                .AddWithValue("CurrencyCon1", 1)
                .AddWithValue("DelivaryDate", Today.Date)
                .AddWithValue("DelivaryDateValue", Today.Date.ToOADate)
                .AddWithValue("Additions", "")
                .AddWithValue("Deductions", "")
                .AddWithValue("AccountLedgerName", DefLedgers.SalesAccount)
                .AddWithValue("servicetaxtotal", 0)
                .AddWithValue("roundoff", 0)
                .AddWithValue("surcharge", 0)
                .AddWithValue("DiscPer", CDbl(TxtDiscountTotal.Text))
                .AddWithValue("CurrencyCon2", 1)
                .AddWithValue("BillCurrency", CompDetails.Currency)

                .AddWithValue("CDisCountPer", 0)
                .AddWithValue("CDiscount", 0)
                .AddWithValue("CouponName", "")
                .AddWithValue("transtype", "")
                .AddWithValue("AdvancePayment", 0)
                If POSSettings.AllowPaymentMethod = True Then
                    .AddWithValue("IsMultiPayment", 1)
                Else
                    .AddWithValue("IsMultiPayment", 0)
                End If
                .AddWithValue("BillType", TxtBillType.Text)

                .AddWithValue("CashReceived", CDbl(TxtReceivedCash.Text))
                .AddWithValue("CashtoPay", CDbl(TxtCashtoPay.Text))
                .AddWithValue("CounterId", CurrentCounterID)
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
        For i As Integer = 0 To txtList.RowCount - 1
            If txtList.Item("stbarcode", i).Value.ToString.Length > 0 Then
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim st As New ChooseItemClass
                st.ClearData()
                LoadStockItemsIntoClass(txtList.Item("stbarcode", i).Value, txtList.Item("Stlocation", i).Value, st)
                st.TxtQtyBOX.SetUnitName(st.StockUnitName)
                st.TxtQtyFreeBOX.SetUnitName(st.StockUnitName)
                st.TxtMQtyBOX.SetUnitName(st.StockUnitName)

                If st.TxtQtyBOX.IsSimpleUnit = True Then
                    st.TxtQtyBOX.TxtQty1.Text = txtList.Item("Stqty", i).Value
                    st.TxtQtyFreeBOX.TxtQty1.Text = "0"
                    st.TxtMQtyBOX.TxtQty1.Text = "0"
                Else
                    Dim Strqty As String = ""
                    Strqty = txtList.Item("stqty", i).Value
                    If Strqty.Contains("-") = True Then
                        Dim q1 As String = ""
                        Dim q2 As String = ""
                        q1 = Strqty.Substring(0, Strqty.IndexOf("-"))
                        q2 = Strqty.Substring(Strqty.IndexOf("-") + 1)
                        If q2.Length > 0 Then
                            st.TxtQtyBOX.TxtQty1.Text = CDbl(q1)
                            st.TxtQtyBOX.TxtQty2.Text = CDbl(q2)

                        Else
                            st.TxtQtyBOX.TxtQty1.Text = CDbl(q1)
                            st.TxtQtyBOX.TxtQty2.Text = 0
                        End If
                    Else
                        st.TxtQtyBOX.TxtQty1.Text = txtList.Item("Stqty", i).Value
                    End If

                    st.TxtQtyFreeBOX.TxtQty2.Text = "0"
                    st.TxtMQtyBOX.TxtQty2.Text = "0"
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
                    .AddWithValue("QutoRef", TxtQutoNo.Text)
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
                    .AddWithValue("FreeMQty", st.TxtQtyBOX.GetTotalQty)
                    .AddWithValue("FreeMQtyText", st.TxtQtyBOX.GetTotalQtyText)
                    .AddWithValue("packing", st.Packing)
                    If st.TxtQtyBOX.IsSimpleUnit = True Then
                        .AddWithValue("QtyValues", st.TxtQtyBOX.TxtQty1.Text & " " & st.TxtQtyBOX.GetMainUnit)
                    Else
                        .AddWithValue("QtyValues", st.TxtQtyBOX.TxtQty1.Text & "-" & st.TxtQtyBOX.TxtQty2.Text & " " & st.TxtQtyBOX.GetMainUnit)
                    End If
                    .AddWithValue("SubUnitQty", st.TxtQtyBOX.GetUnitQtys(1))
                    .AddWithValue("QtyText", st.TxtQtyBOX.GetTotalQtyText)
                    .AddWithValue("StockRate", CDbl(txtList.Item("Strate", i).Value))
                    .AddWithValue("StockDisc", CDbl(txtList.Item("stdisc", i).Value))
                    .AddWithValue("RatePer", st.TxtQtyBOX.GetMainUnit)
                    Dim dt As New DateTimePicker
                    Try
                        dt.Value = CDate(txtList.Item("stexpiry", i).Value)
                        .AddWithValue("Expiry", dt.Value)
                    Catch ex As Exception

                        .AddWithValue("Expiry", DBNull.Value)
                    End Try

                    .AddWithValue("BatchNo", txtList.Item("stbatchno", i).Value)
                    .AddWithValue("StockType", st.StockType)
                    .AddWithValue("MRP", CDbl(txtList.Item("stmrp", i).Value))
                    .AddWithValue("UnitCon", st.TxtQtyBOX.GetUnitConversion())
                    .AddWithValue("StockAmount", CDbl(txtList.Item("ststockvalue", i).Value))
                    .AddWithValue("disc2", 0)
                    .AddWithValue("PresetRate", st.StockRate)
                    .AddWithValue("VoucherName", "POS")
                    .AddWithValue("slnos", "")
                    If Len(txtList.Item("stbarcode", i).Value) = 0 Then
                        .AddWithValue("CustBarcode", "")
                    Else
                        .AddWithValue("CustBarcode", txtList.Item("stcustbarcode", i).Value.ToString)
                    End If
                    .AddWithValue("CurrencyCon1", 1)
                    .AddWithValue("Tax", CDbl(txtList.Item("Sttax", i).Value))
                    .AddWithValue("Tax2", 0)
                    .AddWithValue("TaxAmount", CDbl(txtList.Item("sttaxvalue", i).Value))
                    .AddWithValue("TaxAmount2", 0)
                    .AddWithValue("NetRate", CDbl(txtList.Item("stnetrate", i).Value))
                    .AddWithValue("origin", "")
                    .AddWithValue("HScode", "")
                    .AddWithValue("Utranscode", 0)
                    .AddWithValue("isdelete", 0)
                    .AddWithValue("Servicetax", 0)
                    .AddWithValue("netStockAmount", CDbl(txtList.Item("stTotal", i).Value))
                    .AddWithValue("DiscountAmount1", 0)
                    .AddWithValue("DiscountAmount2", 0)
                    .AddWithValue("n1", 0)
                    .AddWithValue("transtype", "")
                    .AddWithValue("UsedQty", 0)

                  
                    st = Nothing
                End With
                DBF1.ExecuteNonQuery()
                DBF1 = Nothing
                MAINCON.Close()
            End If

        Next

    End Sub
    Private Sub ImsButton6_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton6.Click, CloseToolStripMenuItem.Click
        If MsgBox("Do you want to Close ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click, NewToolStripMenuItem.Click
        If MsgBox("Do you to Create New ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            LoadDefults()
            IsInvoiceSaved = True
        End If

        TxtBarcode.Focus()
    End Sub

    Private Sub PrtDoc_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PrtDoc.BeginPrint
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
            PrtDoc.DefaultPageSettings.PrinterSettings.Copies = 1
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

    Private Sub PrtDoc_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrtDoc.PrintPage
        If PagesetupValues.IsRollPaper = False Then
            Printingset(sender, e, OpenedTranscode, PrintingScheme, "StockInvoiceRowItems", "StockInvoiceDetails", 1, False)
        Else
            RollPaperPrinting(sender, e, PrtDoc, True)
        End If
    End Sub

    Private Sub btnoPEN_Click(sender As System.Object, e As System.EventArgs) Handles btnOpen.Click, OPEN2ToolStripMenuItem.Click
        If APPUserRights.IsAccessable = False Then
            MsgBox("The Edit  Restricted by the Admin, No possible to Edit ......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If IsInvoiceSaved = False Then
            Dim k As DialogResult
            k = MsgBox("The Current Invoice is not saved, Do you want to save ?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.DefaultButton1)
            If k = MsgBoxResult.Yes Then
                CheckBeforesave()
                If IsInvoiceSaved = False Then
                    Exit Sub
                End If
            ElseIf k = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If

        Dim st As New ClsSelectInvDB
        st.SelectedTransCode = 0
        st.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesPOS

        Dim editfrm As New ChooseInvoiceNumber(st)
        editfrm.ShowDialog()
        editfrm.Dispose()
        If st.SelectedTransCode = 0 Then
            st = Nothing
            Exit Sub
        Else

            LoadDefults()

            OpenByTransCodeID(st.SelectedTransCode)
            findInvoiceTotals()
            IsInvoiceOpened = True
            st = Nothing
        End If

    End Sub
    Public Sub OpenByTransCodeID(ByVal tcode As Single)
        OpenedTranscode = tcode

        UpdateLogFile(DefStoreName, OpenedTranscode, "POS", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  POS  for TransCode: " & OpenedTranscode.ToString)

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
                TxtDate.Value = Sreader("TRANSDATE")
                TxtTaxTotal.Text = Sreader("taxtotal").ToString.Trim
                TxtQutoNo.Text = Sreader("QutoNo").ToString.Trim
                txtLedgerName.Text = Sreader("LEDGERNAME").ToString.Trim
                TxtSubTotal.Text = Sreader("subtotal").ToString.Trim
                TxtNetTotal.Text = Sreader("nettotal").ToString.Trim
                TxtDiscPer.Text = Sreader("discountper").ToString.Trim
                TxtAmountinWords.Text = Sreader("amountinwords").ToString.Trim
                TxtNarration.Text = Sreader("narration").ToString.Trim
                TxtPriceLevel.Text = Sreader("PriceList").ToString.Trim
                TxtCurrency.Text = Sreader("BillCurrency").ToString
                TxtCustomerName.Text = Sreader("customername").ToString
                TxtDiscountTotal.Text = Sreader("DiscPer").ToString
                TxtMobileNo.Text = Sreader("LedgerAddress").ToString
                TxtBillType.Text = Sreader("BillType").ToString
                Try
                    TxtReceivedCash.Text = Sreader("CashReceived").ToString
                    TxtCashtoPay.Text = Sreader("CashtoPay").ToString
                Catch ex As Exception

                End Try
              
                TxtDiscountTotal.Text = Sreader("DiscPer").ToString.Trim
               

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

                txtList.Item("strate", i).Value = Sreader("StockRate")
                txtList.Item("stdisc", i).Value = Sreader("StockDisc")
                txtList.Item("sttotal", i).Value = Sreader("netStockAmount")
                txtList.Item("ststockvalue", i).Value = Sreader("StockAmount")
                txtList.Item("Sttax", i).Value = Sreader("Tax")
                txtList.Item("stnetrate", i).Value = Sreader("NetRate")
                txtList.Item("stmrp", i).Value = Sreader("mrp")
                txtList.Item("sttaxvalue", i).Value = Sreader("Taxamount")
                txtList.Item("stIsSimpleUnit", i).Value = Sreader("IsSimpleUnit")
                txtList.Item("stunitname", i).Value = Sreader("BaseUnit").ToString

                Dim TxttempQty As New JyothiPharmaERPSystem3.IMSQtyBox
                TxttempQty.SetUnitName(Sreader("BaseUnit").ToString)

                If TxttempQty.IsSimpleUnit = True Then
                    txtList.Item("stqty", i).Value = Sreader("TotalQty")
                Else
                    TxttempQty.TxtQty1.Text = "0"
                    TxttempQty.TxtQty2.Text = Sreader("TotalQty")
                    TxttempQty.CalculateValues()
                    txtList.Item("stqty", i).Value = TxttempQty.TxtQty1.Text & "-" & TxttempQty.TxtQty2.Text
                End If


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
        'loading payment methods
        Dim dt As New DataTable
        dt = SQLLoadGridData("SELECT * FROM PaymentMethodDetails WHERE TRANSCODE=" & tcode)
        TxtPaymentList.Rows.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                TxtPaymentList.Rows.Add()
                TxtPaymentList.Item("spsno", i).Value = i + 1
                TxtPaymentList.Item("sttype", i).Value = dt.Rows(i).Item("TTYPE").ToString
                TxtPaymentList.Item("stamount", i).Value = dt.Rows(i).Item("Amount").ToString
            Next
        End If
        dt.Dispose()
        OpenedTranscode = tcode
        IsInvoiceSaved = True
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
        '  OpenedPDCValues = GetPDCValues(OpenedTranscode)
        ExecuteSQLQuery("delete from LEDGERBOOK where transcode=" & OpenedTranscode)
        ExecuteSQLQuery("delete from bill2bill where billtype='New' and transcode=" & OpenedTranscode)
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
        Dim sno As Integer = 1
        SqlStr = "INSERT INTO [LedgerBook] ([LedgerName],[TransCode],[InvoiceNo],[InvoiceName],[sno],[Dr],[Cr],[TransDate], " _
     & "[TransDateValue],[LedgerGroup],[AcLedger],[IsAdvance],[IsDeleted],[UserName],[StoreName],[Narration],[InvoiceType],[RefNo],[CurrencyCode],[ConRate],CounterID) " _
     & " VALUES (@LedgerName,@TransCode,@InvoiceNo,@InvoiceName,@sno,@Dr,@Cr,@TransDate,@TransDateValue,@LedgerGroup, " _
     & "@AcLedger,@IsAdvance,@IsDeleted,@UserName,@StoreName,@Narration,@InvoiceType,@RefNo,@CurrencyCode,@ConRate,@CounterID) "
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()

        'FOR ADVANCE PAYMENT LEDGER ALLOCATION
        Dim TotalPaidAmount As Double = 0
        If TxtPaymentList.Rows.Count > 0 Then
            For I As Integer = 0 To TxtPaymentList.Rows.Count - 1
                If TxtPaymentList.Item("STTYPE", I).Value <> "On Account" Then
               


                    Dim DBFR5 As SqlClient.SqlCommand
                    DBFR5 = New SqlClient.SqlCommand(SqlStr, MAINCON)
                    With DBFR5.Parameters
                        If TxtPaymentList.Item("STTYPE", I).Value = "Cash" Then
                            .AddWithValue("LedgerName", POSSettings.CashLedger)
                        ElseIf TxtPaymentList.Item("STTYPE", I).Value = "Credit Card" Then
                            .AddWithValue("LedgerName", POSSettings.CreditCardLedger)
                        ElseIf TxtPaymentList.Item("STTYPE", I).Value = "Cheque" Then
                            .AddWithValue("LedgerName", POSSettings.ChequeLedger)
                        ElseIf TxtPaymentList.Item("STTYPE", I).Value = "Gift Card" Then
                            .AddWithValue("LedgerName", POSSettings.GiftCardLedger)
                        End If

                        .AddWithValue("TransCode", Trancode)
                        .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                        .AddWithValue("InvoiceName", "POS")
                        .AddWithValue("InvoiceType", "POS")
                        .AddWithValue("sno", sno)
                        sno = sno + 1
                        .AddWithValue("Dr", CDbl(TxtPaymentList.Item("stamount", I).Value))
                        TotalPaidAmount = TotalPaidAmount + CDbl(TxtPaymentList.Item("stamount", I).Value)
                        .AddWithValue("Cr", 0)
                        .AddWithValue("TransDate", TxtDate.Value)
                        .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                        .AddWithValue("LedgerGroup", "")
                        .AddWithValue("CurrencyCode", CompDetails.Currency)
                        .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & DefLedgers.SalesDiscountLedger & "'", "currency").ToString))
                        .AddWithValue("AcLedger", DefLedgers.SalesAccount)
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
            Next

        Else
          


            Dim DBFR5 As SqlClient.SqlCommand
            DBFR5 = New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBFR5.Parameters
                .AddWithValue("LedgerName", IIf(POSSettings.CashLedger.Length = 0, DefLedgers.CashAccount, POSSettings.CashLedger))
                .AddWithValue("TransCode", Trancode)
                .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                .AddWithValue("InvoiceName", "POS")
                .AddWithValue("InvoiceType", "POS")
                .AddWithValue("sno", sno)
                sno = sno + 1
                .AddWithValue("Dr", CDbl(TxtNetTotal.Text))
                .AddWithValue("Cr", 0)
                .AddWithValue("TransDate", TxtDate.Value)
                .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                .AddWithValue("LedgerGroup", "")
                .AddWithValue("CurrencyCode", CompDetails.Currency)
                .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & DefLedgers.SalesDiscountLedger & "'", "currency").ToString))
                .AddWithValue("AcLedger", DefLedgers.SalesAccount)
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
        'END OF  ADVANCE PAYMENT 

        If SQLIsFieldExists("select ledgername from ledgers where ledgername=N'" & txtLedgerName.Text & "' and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "')") = False Then

            Dim DBFR32 As SqlClient.SqlCommand
            DBFR32 = New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBFR32.Parameters
                .AddWithValue("LedgerName", txtLedgerName.Text)
                .AddWithValue("TransCode", Trancode)
                .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                .AddWithValue("InvoiceName", "POS")
                .AddWithValue("InvoiceType", "POS")

                .AddWithValue("sno", sno)
                sno = sno + 1
                .AddWithValue("Dr", CDbl(TxtNetTotal.Text))
                .AddWithValue("Cr", 0)

                .AddWithValue("TransDate", TxtDate.Value)
                .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                .AddWithValue("LedgerGroup", "")
                .AddWithValue("CurrencyCode", CompDetails.Currency)
                .AddWithValue("ConRate", 1)
                .AddWithValue("AcLedger", DefLedgers.SalesAccount)
                .AddWithValue("IsAdvance", 1)
                .AddWithValue("IsDeleted", 0)
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Narration", TxtNarration.Text)

                .AddWithValue("RefNo", TxtQutoNo.Text)
                .AddWithValue("CounterID", CurrentCounterID)
            End With
            DBFR32.ExecuteNonQuery()
            DBFR32 = Nothing

            If TotalPaidAmount > 0 Then
                Dim DBFR42 As SqlClient.SqlCommand
                DBFR42 = New SqlClient.SqlCommand(SqlStr, MAINCON)
                With DBFR42.Parameters
                    .AddWithValue("LedgerName", txtLedgerName.Text)
                    .AddWithValue("TransCode", Trancode)
                    .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                    .AddWithValue("InvoiceName", "POS")
                    .AddWithValue("InvoiceType", "POS")

                    .AddWithValue("sno", sno)
                    sno = sno + 1
                    .AddWithValue("Dr", 0)
                    .AddWithValue("Cr", TotalPaidAmount)

                    .AddWithValue("TransDate", TxtDate.Value)
                    .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                    .AddWithValue("LedgerGroup", "")
                    .AddWithValue("CurrencyCode", CompDetails.Currency)
                    .AddWithValue("ConRate", 1)
                    .AddWithValue("AcLedger", DefLedgers.SalesAccount)
                    .AddWithValue("IsAdvance", 1)
                    .AddWithValue("IsDeleted", 0)
                    .AddWithValue("UserName", CurrentUserName)
                    .AddWithValue("StoreName", DefStoreName)
                    .AddWithValue("Narration", TxtNarration.Text)

                    .AddWithValue("RefNo", TxtQutoNo.Text)
                    .AddWithValue("CounterID", CurrentCounterID)
                End With
                DBFR42.ExecuteNonQuery()
                DBFR42 = Nothing
            End If


        End If

        Dim DBFR2 As SqlClient.SqlCommand
        If SQLGetNumericFieldValue("select count(*) as tot from Vatclauses where vattype='VAT'", "tot") > 0 Then
            SaveVatTaxes(Trancode, sno)
        Else
            DBFR2 = New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBFR2.Parameters
                .AddWithValue("LedgerName", DefLedgers.SalesAccount)
                .AddWithValue("TransCode", Trancode)
                .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                .AddWithValue("InvoiceName", "POS")
                .AddWithValue("InvoiceType", "POS")
                .AddWithValue("sno", sno)
                sno = sno + 1
                .AddWithValue("Dr", 0)
                .AddWithValue("Cr", CDbl(TxtSubTotal.Text))
                .AddWithValue("CurrencyCode", CompDetails.Currency)
                .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & DefLedgers.SalesAccount & "'", "currency").ToString))
                .AddWithValue("TransDate", TxtDate.Value)
                .AddWithValue("TransDateValue", TxtDate.Value.Date.ToOADate)
                .AddWithValue("LedgerGroup", "")
                .AddWithValue("AcLedger", txtLedgerName.Text)
                .AddWithValue("IsAdvance", 1)
                .AddWithValue("IsDeleted", 0)
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Narration", TxtNarration.Text)
                .AddWithValue("RefNo", TxtQutoNo.Text)
                .AddWithValue("CounterID", CurrentCounterID)
            End With
            DBFR2.ExecuteNonQuery()
            DBFR2 = Nothing
            MAINCON.Close()

        End If


        If CDbl(TxtDiscountTotal.Text) <> 0 Then


            Dim DBFR5 As SqlClient.SqlCommand
            DBFR5 = New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBFR5.Parameters
                .AddWithValue("LedgerName", DefLedgers.SalesDiscountLedger)
                .AddWithValue("TransCode", Trancode)
                .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                .AddWithValue("InvoiceName", "POS")
                .AddWithValue("InvoiceType", "POS")
                .AddWithValue("sno", sno)
                sno = sno + 1
                If CDbl(TxtDiscountTotal.Text) > 0 Then
                    .AddWithValue("Dr", 0)
                    .AddWithValue("Cr", CDbl(TxtDiscountTotal.Text))
                Else
                    .AddWithValue("Dr", CDbl(TxtDiscountTotal.Text) * -1)
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

        'END CREDIT TRANSCATIONS 
        'SAVE PAYMENT METHODS
        For I As Integer = 0 To TxtPaymentList.Rows.Count - 1
            SqlStr = "INSERT INTO [PaymentMethodDetails] ([Transcode] ,[Ttype] ,[Amount])     VALUES (@Transcode ,@Ttype ,@Amount)  "

            Dim DBFR5 As SqlClient.SqlCommand
            DBFR5 = New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBFR5.Parameters
                .AddWithValue("Ttype", TxtPaymentList.Item("STTYPE", I).Value)
                .AddWithValue("TransCode", Trancode)
                .AddWithValue("Amount", CDbl(TxtPaymentList.Item("stamount", I).Value))
            End With
            DBFR5.ExecuteNonQuery()
            DBFR5 = Nothing
        Next

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
                   
                    TempLedgerName = SQLGetStringFieldValue("select SalesLedger from vatclauses where vattax=0 and vattype='VAT'", "SalesLedger")
                    Dim DBFR As SqlClient.SqlCommand
                    DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                    With DBFR.Parameters
                        .AddWithValue("LedgerName", TempLedgerName)
                        .AddWithValue("TransCode", Tcode)
                        .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                        .AddWithValue("sno", sno)
                        sno = sno + 1
                        .AddWithValue("Dr", 0)
                        .AddWithValue("Cr", Sreader("samt"))
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


                Else
                    ' you need to update for input and output as well as purchase/sales ledgers for each tax
                    TempLedgerName = SQLGetStringFieldValue("select SalesLedger from vatclauses where  vattype='VAT' and vattax=" & Sreader("tax"), "SalesLedger")
                    Dim DBFR As SqlClient.SqlCommand
                    DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                    With DBFR.Parameters
                        .AddWithValue("LedgerName", TempLedgerName)
                        .AddWithValue("TransCode", Tcode)
                        .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                        .AddWithValue("sno", sno)
                        sno = sno + 1
                        .AddWithValue("Dr", 0)
                        .AddWithValue("Cr", Sreader("samt"))
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



                    ' for input vat or output vat ledges positing
                    TempLedgerName = SQLGetStringFieldValue("select outputvatledger from vatclauses where  vattype='VAT' and  vattax=" & Sreader("tax"), "outputvatledger")
                    DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
                    With DBFR.Parameters
                        .AddWithValue("LedgerName", TempLedgerName)
                        .AddWithValue("TransCode", Tcode)
                        .AddWithValue("InvoiceNo", TxtQutoNo.Text)
                        .AddWithValue("sno", sno)
                        sno = sno + 1
                      .AddWithValue("Dr", 0)
                        .AddWithValue("Cr", Sreader("TAMT"))
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
    Sub UpdateStockForSI_SR_POS()
        For I As Integer = 0 To txtList.RowCount - 1
            ExecuteSQLQuery("exec UpdateStockQty N'" & txtList.Item("stlocation", I).Value & "',N'" & txtList.Item("STItemCode", I).Value & "',N'" & txtList.Item("stsize", I).Value & "',N'" & txtList.Item("stbatchno", I).Value & "'")
            ExecuteSQLQuery("EXEC proInventoryCosting N'" & txtList.Item("stlocation", I).Value & "',N'" & txtList.Item("STItemCode", I).Value & "',N'" & txtList.Item("stsize", I).Value & "'," & UpdateQuantityForNon_StockAlso)
            ExecuteSQLQuery("exec UpdateBatchStockQty N'" & txtList.Item("stlocation", I).Value & "',N'" & txtList.Item("STItemCode", I).Value & "',N'" & txtList.Item("stsize", I).Value & "',N'" & txtList.Item("stbatchno", I).Value & "'")
        Next

    End Sub

    Private Sub Label15_Click(sender As System.Object, e As System.EventArgs) Handles Label15.Click
        TxtBarcode.Focus()
    End Sub

    Private Sub txtList_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtList.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            TxtBarcode.Focus()
        End If
    End Sub

    Private Sub Label20_Click(sender As System.Object, e As System.EventArgs) Handles Label20.Click

    End Sub

    Private Sub Label6_Click(sender As System.Object, e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub BtnRough_Click(sender As System.Object, e As System.EventArgs) Handles BtnRough.Click
        Dim frm As New RoughtNotesFrm
        frm.Show()

    End Sub

    Private Sub TxtBarcode_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBarcode.TextChanged

    End Sub

    Private Sub PlaceFocusOnQtyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PlaceFocusOnQtyToolStripMenuItem.Click
        Try
            txtList.CurrentCell = txtList.Item("Strate", txtList.RowCount - 1)
            txtList.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PlaceFocusOnQtyToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles PlaceFocusOnQtyToolStripMenuItem1.Click
        Try
            txtList.CurrentCell = txtList.Item("Stqty", txtList.RowCount - 1)
            txtList.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarcodefocusToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BarcodefocusToolStripMenuItem.Click
        TxtBarcode.Focus()
    End Sub

    Private Sub CashReceivedfocusToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CashReceivedfocusToolStripMenuItem.Click
        TxtReceivedCash.Focus()
    End Sub

    Private Sub TxtBillType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtBillType.SelectedIndexChanged
        If TxtBillType.Text = "Cash Bill" Then
            lblcustomername.Visible = True
            TxtCustomerName.Visible = True
            lblledgername.Visible = False
            txtLedgerName.Visible = False
            txtLedgerName.Text = DefLedgers.CashAccount
        Else
            lblledgername.Visible = True
            txtLedgerName.Visible = True
            lblcustomername.Visible = False
            TxtCustomerName.Visible = False
            TxtCustomerName.Enabled = True
            txtLedgerName.Enabled = True
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As System.Object, e As System.EventArgs) Handles BtnPrint.Click, PrintToolStripMenuItem.Click
        If IsInvoiceOpened = True Then
            If MsgBox("Do you want to Print ?  ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                PrintNow()
            End If

        End If
    End Sub

    Private Sub BtnSendSMS_Click(sender As System.Object, e As System.EventArgs) Handles BtnSendSMS.Click, SendSMSToolStripMenuItem.Click
        If IsInvoiceOpened = True And TxtMobileNo.Text.Length > 6 Then

            If MsgBox("Do you want to Send SMS ?  ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SendSMS()
            End If

        End If

    End Sub



    Private Sub txtList_CellMouseMove(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles txtList.CellMouseMove
        Try
            Dim dt As New DateTimePicker
            dt.Value = CDate(txtList.Item("stexpiry", e.RowIndex).Value)
            txtList.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Location:" & txtList.Item("stlocation", e.RowIndex).Value & ", Item:" & txtList.Item("stitemname", e.RowIndex).Value & ", Batch No:" & txtList.Item("stbatchno", e.RowIndex).Value & ", Expiry:" & dt.Value.Date.ToString("dd/MM/yyyy") & ", Qty:" & txtList.Item("stqty", e.RowIndex).Value & ", Tax :" & txtList.Item("sttax", e.RowIndex).Value
        Catch ex As Exception
            Try
                txtList.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = ""
            Catch ex4 As Exception

            End Try
        End Try
    End Sub

    Private Sub TxtDiscountTotal_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles TxtDiscountTotal.TextChanged
        'findInvoiceTotals()
    End Sub

    Private Sub txtList_CellValidated(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles txtList.CellValidated
        TxtBarcode.Focus()
    End Sub

   
    Private Sub TxtSubTotal_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub TxtDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtDate.ValueChanged
        Dim discountval As String = GetInvoiceDiscountValue(TxtDate)
        If discountval.Length > 0 Then

            If discountval.IndexOf("%") = -1 Then
                TxtDiscountTotal.Text = discountval
            Else
                TxtDiscPer.Text = discountval.Replace("%", "")
            End If
        Else
            TxtDiscPer.Text = "0"
        End If
    End Sub
End Class