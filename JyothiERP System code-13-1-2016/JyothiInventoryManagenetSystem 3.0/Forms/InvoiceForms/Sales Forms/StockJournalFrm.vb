Imports System.Data.SqlClient

Public Class StockJournalFrm
    Dim IsInvoiceOpen As Boolean = False
    Dim IsInvoiceSaved As Boolean = True
    Dim OpenedTranscode As Single = 0
    Dim IsOpendByWindows As Boolean = False
    Dim IsEditItem As Boolean = False
    Dim EditItemRow As Integer = 0
    Dim NewAddItem As New ChooseItemClass
    Dim IsTOEditItem As Boolean = False
    Dim EditTOItemRow As Integer = 0
    Dim NewTOAddItem As New ChooseItemClass
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Sub LoadDefaults()
        UnLockTransaction(OpenedTranscode)
        TxtDate.Value = Now
        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.STOCKJOURNAL)
        TxtInvNo.Text = GetInvVhNumber(InvoiceNoStrct.STOCKJOURNAL)
        TxtDate.Value = Now
        NewTOAddItem.StockItemCode = ""
        NewAddItem.StockItemCode = ""
        TxtFromList.Rows.Clear()
        TxtToList.Rows.Clear()
        If IsCustomBarCode = True Then
            TxtFromList.Columns("sfbarcode").Visible = False
            TxtFromList.Columns("sfcustbarcode").Visible = True
            TxtToList.Columns("stbarcode").Visible = False
            TxtToList.Columns("stcustbarcode").Visible = True
        End If
        IsOpendByWindows = False
        IsInvoiceOpen = False
        IsInvoiceSaved = True
    End Sub

    Private Sub TxtStockCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtStockCode.KeyPress
      
        If TxtStockCode.Text.Length = 0 Then
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
                CheckBeforeSave()
                Exit Sub
            End If
        Else
            'If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            '     GetStockDets(0, TxtStockCode.Text)
            'End If

        End If
    End Sub

    Private Sub TxtRatePer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRatePer.GotFocus
        If TxtStockCode.Text.Length = 0 Then
            TxtStockCode.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub TxtStockRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockRate.TextChanged, TxtRatePer.SelectedIndexChanged, TxtStockDisc.TextChanged
        FindStockAmount()
    End Sub
    Private Sub TxtStockQty_QtyChanageEvent(ByVal e As Object) Handles TxtStockQty.QtyChanageEvent
        FindStockAmount()
    End Sub

    Private Sub TxtStockQty_QtyLostFocus(ByVal e As Object) Handles TxtStockQty.QtyLostFocus
        FindStockAmount()
    End Sub
    Sub FindStockAmount()
        Dim NetRate As Double = 0
        Try
            'CALCULATE NET RATE FOR  DISCOUNT
            NetRate = (CDbl(TxtStockRate.Text) - CDbl(TxtStockRate.Text) * CDbl(TxtStockDisc.Text) / 100)

            If TxtRatePer.Text = TxtStockQty.GetSubUnit() Then
                TxtStockValue.Text = NetRate * TxtStockQty.GetTotalQty()
            Else
                TxtStockValue.Text = NetRate * TxtStockQty.GetTotalQty() / TxtStockQty.GetUnitConversion()
            End If
        Catch ex As Exception
            TxtStockValue.Text = "0"
        End Try

    End Sub
    Sub GetStockDets(ByVal Ctrlno As Byte, ByVal curchar As String)
        Dim bvalue As New ChooseItemClass
        bvalue.StockItemBarCode = 0
        bvalue.CurrentField = Ctrlno
        bvalue.CurrentChar = curchar
        Dim k As New ChooseItems(bvalue)
        k.TxtOnlyServices.Text = "Stock"
        k.TxtOnlyServices.Visible = False
        k.TxtLocation.Enabled = True
        k.TxtLocation.Text = "*All"
        k.ShowDialog()
        If bvalue.StockItemBarCode.Length <> 0 Then
            LoadStockItemsIntoClass(bvalue.StockItemBarCode, bvalue.StockLocation, NewAddItem)
            TxtStockDisc.Text = "0"
            TxtStockValue.Text = "0"
            TxtStockCode.Text = NewAddItem.StockItemCode
            TxtStockSize.Text = NewAddItem.StockITemSize
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
            TxtStockRate.Text = NewAddItem.StockRate
            TxtBatchNo.Text = ""
            TxtBatchNo.Items.Clear()
            If NewAddItem.IsBatchNo = 1 Then
                LoadDataIntoComboBox("select batchno from stockbatch where stockcode=N'" & NewAddItem.StockItemCode & "' and stocksize=N'" & NewAddItem.StockITemSize & "' and location=N'" & NewAddItem.StockLocation & "'", TxtBatchNo, "batchno", "")
                TxtBatchNo.Enabled = True
                Me.TableLayoutPanel2.ColumnStyles.Item(3).Width = 20.5
                TxtBatchNo.Focus()
            Else
                TxtBatchNo.Enabled = False
                Me.TableLayoutPanel2.ColumnStyles.Item(3).Width = 0
                TxtStockQty.Focus()
            End If
        Else
            TxtStockCode.Text = ""
        End If
    End Sub

    Private Sub BtmAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmAdd.Click
        If MyAppSettings.IsAllowNegativeStock = False And IsInvoiceOpen = False Then
            If TxtStockQty.GetTotalQty() > SQLGetNumericFieldValue("select totalqty from stockdbf where barcode=N'" & NewAddItem.StockItemBarCode & "'", "totalqty") Then
                MsgBox("The Stock Quantity is greater than the available stock....", MsgBoxStyle.Information)
                TxtStockQty.Focus()
                Exit Sub
            End If
        ElseIf MyAppSettings.IsAllowNegativeStock = False And IsInvoiceOpen = True Then
            If TxtStockQty.GetTotalQty() - SQLGetNumericFieldValue("select totalqty from StockInvoiceRowItems where barcode=N'" & NewAddItem.StockItemBarCode & "'", "totalqty") > SQLGetNumericFieldValue("select totalqty from stockdbf where barcode=N'" & NewAddItem.StockItemBarCode & "'", "totalqty") Then
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
        If IsEditItem = True Then
            If MsgBox("Do you want to Add ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                Dim nR As Integer
                nR = EditItemRow
                TxtFromList.Item("sflocation", nR).Value = NewAddItem.StockLocationNames
                TxtFromList.Item("SfItemcode", nR).Value = NewAddItem.StockItemCode
                TxtFromList.Item("Sfitemname", nR).Value = NewAddItem.StockItemName
                TxtFromList.Item("Sfbarcode", nR).Value = NewAddItem.StockItemBarCode
                TxtFromList.Item("sfcustbarcode", nR).Value = NewAddItem.CustBarCode
                TxtFromList.Item("Sfsize", nR).Value = NewAddItem.StockITemSize
               
                TxtFromList.Item("Sfsize", nR).Value = NewAddItem.StockITemSize
                TxtFromList.Item("sfqty", nR).Value = TxtStockQty.GetTotalQty
                TxtFromList.Item("sfqtytext", nR).Value = TxtStockQty.GetTotalQtyText


                If TxtRatePer.Text = TxtStockQty.GetSubUnit() Then
                    Dim trate As Double
                    trate = TxtStockRate.Text * TxtStockQty.GetUnitConversion
                    TxtFromList.Item("sfprice", nR).Value = trate
                    TxtFromList.Item("sfrateper", nR).Value = TxtStockQty.GetMainUnit
                    TxtFromList.Item("sfamount", nR).Value = trate * TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion
                Else
                    TxtFromList.Item("sfprice", nR).Value = CDbl(TxtStockRate.Text)
                    TxtFromList.Item("sfrateper", nR).Value = TxtRatePer.Text
                    TxtFromList.Item("sfamount", nR).Value = CDbl(TxtStockRate.Text) * TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion
                End If

                TxtFromList.Item("Sfbatchno", nR).Value = TxtBatchNo.Text
                If TxtBatchNo.Text.Length > 0 Then
                    NewAddItem.StockExpirydate = CDate(SQLGetStringFieldValue("SELECT Expiry FROM STOCKBATCH WHERE STOCKCODE=N'" & NewAddItem.StockItemCode & "' AND STOCKSIZE=N'" & NewAddItem.StockITemSize & "' AND LOCATION=N'" & NewAddItem.StockLocation & "' AND BATCHNO=N'" & TxtBatchNo.Text & "'", "Expiry"))
                    TxtFromList.Item("sfExpiry", nR).Value = NewAddItem.StockExpirydate
                Else
                    TxtFromList.Item("sfExpiry", nR).Value = ""
                End If

                FindTotalAmount()
                LoadStockEntryDefaults()
                TxtStockCode.Focus()
                IsEditItem = False
                IsInvoiceSaved = False
            End If
        Else
            If MsgBox("Do you want to Add ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                Dim nR As Integer
                nR = TxtFromList.Rows.Add()
                TxtFromList.Item("sfsno", nR).Value = nR + 1
                TxtFromList.Item("sflocation", nR).Value = NewAddItem.StockLocationNames
                TxtFromList.Item("SfItemcode", nR).Value = NewAddItem.StockItemCode
                TxtFromList.Item("Sfitemname", nR).Value = NewAddItem.StockItemName
                TxtFromList.Item("Sfbarcode", nR).Value = NewAddItem.StockItemBarCode
                TxtFromList.Item("Sfsize", nR).Value = NewAddItem.StockITemSize

                TxtFromList.Item("sfcustbarcode", nR).Value = NewAddItem.CustBarCode

                TxtFromList.Item("Sfsize", nR).Value = NewAddItem.StockITemSize
                TxtFromList.Item("sfqty", nR).Value = TxtStockQty.GetTotalQty
                TxtFromList.Item("sfqtytext", nR).Value = TxtStockQty.GetTotalQtyText


                If TxtRatePer.Text = TxtStockQty.GetSubUnit() Then
                    Dim trate As Double
                    trate = TxtStockRate.Text * TxtStockQty.GetUnitConversion
                    TxtFromList.Item("sfprice", nR).Value = trate
                    TxtFromList.Item("sfrateper", nR).Value = TxtStockQty.GetMainUnit
                    TxtFromList.Item("sfamount", nR).Value = trate * TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion
                Else
                    TxtFromList.Item("sfprice", nR).Value = CDbl(TxtStockRate.Text)
                    TxtFromList.Item("sfrateper", nR).Value = TxtRatePer.Text
                    TxtFromList.Item("sfamount", nR).Value = CDbl(TxtStockRate.Text) * TxtStockQty.GetTotalQty / TxtStockQty.GetUnitConversion
                End If
                TxtFromList.Item("Sfbatchno", nR).Value = TxtBatchNo.Text
                If TxtBatchNo.Text.Length > 0 Then
                    NewAddItem.StockExpirydate = CDate(SQLGetStringFieldValue("SELECT Expiry FROM STOCKBATCH WHERE STOCKCODE=N'" & NewAddItem.StockItemCode & "' AND STOCKSIZE=N'" & NewAddItem.StockITemSize & "' AND LOCATION=N'" & NewAddItem.StockLocation & "' AND BATCHNO=N'" & TxtBatchNo.Text & "'", "Expiry"))
                    TxtFromList.Item("sfExpiry", nR).Value = NewAddItem.StockExpirydate
                Else
                    TxtFromList.Item("sfExpiry", nR).Value = ""
                End If
                TxtFromList.Item("sfprate", nR).Value = CDbl(TxtStockRate.Text)
                FindTotalAmount()
                LoadStockEntryDefaults()
                TxtStockCode.Focus()
                IsInvoiceSaved = False
            End If
        End If
    End Sub
    Sub LoadStockEntryDefaults()
        TxtStockCode.Text = ""
        TxtStockSize.Text = ""
        TxtRatePer.Text = "0"
        TxtStockQty.ClearQty()
        TxtStockQty.TxtQty1.Text = "1"
        TxtStockDisc.Text = "0"
        TxtBatchNo.Text = ""
        TxtStockRate.Text = "0"
        TxtStockValue.Text = "0"
        IsEditItem = False
        BtnEditCancel.Visible = False
        TxtFromList.Enabled = True
    End Sub
    Sub FindTotalAmount()
        Dim tot As Double = 0
        For i As Integer = 0 To TxtFromList.RowCount - 1
            tot = tot + CDbl(TxtFromList.Item("sfamount", i).Value)
        Next
        TxtTotalValue.Text = FormatNumber(tot, ErpDecimalPlaces, , , TriState.False)
    End Sub
    Sub FindTOTotalAmount()
        Dim tot As Double = 0
        For i As Integer = 0 To TxtToList.RowCount - 1
            tot = tot + CDbl(TxtToList.Item("stamount", i).Value)
        Next
        TxtTTotalAmount.Text = FormatNumber(tot, ErpDecimalPlaces, , , TriState.False)
    End Sub


    Private Sub TxtFromList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtFromList.CellDoubleClick
        If TxtFromList.SelectedRows.Count = 0 Then Exit Sub
        If MsgBox("Do you want to Edit?          ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            LoadStockEntryDefaults()
            IsEditItem = True
            BtnEditCancel.Visible = True
            TxtFromList.Enabled = False
            EditItemRow = TxtFromList.CurrentRow.Index
            Dim bvalue As New ChooseItemClass
            bvalue.StockItemBarCode = TxtFromList.Item("sfbarcode", EditItemRow).Value
            bvalue.StockLocation = TxtFromList.Item("sflocation", EditItemRow).Value
            LoadStockItemsIntoClass(bvalue.StockItemBarCode, bvalue.StockLocation, NewAddItem)
            TxtStockDisc.Text = "0"
            TxtStockValue.Text = "0"
            TxtStockCode.Text = NewAddItem.StockItemCode
            TxtStockSize.Text = NewAddItem.StockITemSize
            TxtStockQty.SetUnitName(NewAddItem.StockUnitName)
            TxtStockQty.ClearQty()
            TxtStockRate.Text = CDbl(TxtFromList.Item("sfprice", EditItemRow).Value)
            TxtRatePer.Items.Clear()
            If NewAddItem.IsSimpleUnit = 1 Then
                TxtStockQty.TxtQty2.Text = "0"
                TxtStockQty.TxtQty1.Text = CDbl(TxtFromList.Item("sfqty", EditItemRow).Value)
                TxtRatePer.Items.Add(NewAddItem.StockUnitName)
                TxtRatePer.Text = NewAddItem.StockUnitName
            Else
                TxtStockQty.TxtQty1.Text = "0"
                TxtStockQty.TxtQty2.Text = CDbl(TxtFromList.Item("sfqty", EditItemRow).Value)
                TxtRatePer.Items.Add(NewAddItem.StockMainUnitName)
                TxtRatePer.Items.Add(NewAddItem.StockSubUnitName)
                TxtRatePer.Text = NewAddItem.StockMainUnitName
            End If
            If Len(TxtFromList.Item("Sfbatchno", EditItemRow).Value) > 0 Then
                LoadDataIntoComboBox("select batchno from stockbatch where stockcode=N'" & TxtStockCode.Text & "' and stocksize=N'" & TxtStockSize.Text & "' and location=N'" & TxtFromList.Item("sflocation", EditItemRow).Value & "'", TxtBatchNo, "batchno")
                TxtBatchNo.Text = TxtFromList.Item("Sfbatchno", EditItemRow).Value
                TxtBatchNo.Enabled = True
                Me.TableLayoutPanel2.ColumnStyles.Item(3).Width = 22.5
            Else
                TxtBatchNo.Enabled = False
                TxtBatchNo.Text = ""
                Me.TableLayoutPanel2.ColumnStyles.Item(3).Width = 0
            End If
            TxtStockQty.CalculateValues()
            TxtStockCode.Focus()
        End If
    End Sub

    Private Sub BtnEditCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditCancel.Click
        LoadStockEntryDefaults()
    End Sub
    Private Sub TxtFromList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtFromList.DataError

    End Sub
    Private Sub TxtFromList_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles TxtFromList.RowsRemoved
        FindTotalAmount()
    End Sub











    Private Sub TxttStockCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToStockCode.KeyPress, TxtToStockSize.KeyPress
      

        If TxtToStockCode.Text.Length = 0 Then
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
                CheckBeforeSave()
                Exit Sub
            End If
        Else
            'If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            '    GetTOStockDets(0, TxtToStockCode.Text)
            'End If

        End If

    End Sub

    Private Sub TxtToRatePer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtToRatePer.GotFocus
        If TxtToStockCode.Text.Length = 0 Then
            TxtToStockCode.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub TxtTOStockRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTOstockrate.TextChanged, TxtToRatePer.SelectedIndexChanged, TxtToStockDisc.TextChanged
        FindtoStockAmount()
    End Sub
    Private Sub TxtTOStockQty_QtyChanageEvent(ByVal e As Object) Handles TxtToStockQty.QtyChanageEvent
        FindtoStockAmount()
    End Sub

    Private Sub TxtTOStockQty_QtyLostFocus(ByVal e As Object) Handles TxtToStockQty.QtyLostFocus
        FindtoStockAmount()
    End Sub
    Sub FindtoStockAmount()
        Dim NetRate As Double = 0
        Try
            'CALCULATE NET RATE FOR  DISCOUNT
            NetRate = (CDbl(TxtTOstockrate.Text) - CDbl(TxtTOstockrate.Text) * CDbl(TxtToStockDisc.Text) / 100)
            If TxtToRatePer.Text = TxtToStockQty.GetSubUnit() Then
                TxtToStockValue.Text = NetRate * TxtToStockQty.GetTotalQty()
            Else
                TxtToStockValue.Text = NetRate * TxtToStockQty.GetTotalQty() / TxtToStockQty.GetUnitConversion()
            End If
        Catch ex As Exception
            TxtToStockValue.Text = "0"
        End Try

    End Sub
    Sub GetTOStockDets(ByVal Ctrlno As Byte, ByVal curchar As String)
        Dim bvalue As New ChooseItemClass
        bvalue.StockItemBarCode = 0
        bvalue.CurrentField = Ctrlno
        bvalue.CurrentChar = curchar
        Dim k As New ChooseItems(bvalue)
        k.TxtOnlyServices.Text = "Stock"
        k.TxtOnlyServices.Visible = False
        k.TxtLocation.Enabled = True
        k.TxtLocation.Text = "*All"
        k.ShowDialog()
        If bvalue.StockItemBarCode.Length <> 0 Then
            LoadStockItemsIntoClass(bvalue.StockItemBarCode, bvalue.StockLocation, NewTOAddItem)
            TxtToStockDisc.Text = "0"
            TxtToStockValue.Text = "0"
            TxtToStockCode.Text = NewTOAddItem.StockItemCode
            TxtToStockSize.Text = NewTOAddItem.StockITemSize
            TxtToStockQty.SetUnitName(NewTOAddItem.StockUnitName)
            TxtToStockQty.ClearQty()
            TxtToStockQty.TxtQty1.Text = "1"
            TxtToRatePer.Items.Clear()
            If NewTOAddItem.IsSimpleUnit = 1 Then
                TxtToRatePer.Items.Add(NewTOAddItem.StockUnitName)
                TxtToRatePer.Text = NewTOAddItem.StockUnitName
            Else
                TxtToRatePer.Items.Add(NewTOAddItem.StockMainUnitName)
                TxtToRatePer.Items.Add(NewTOAddItem.StockSubUnitName)
                TxtToRatePer.Text = NewTOAddItem.StockMainUnitName
            End If
            TxtTOstockrate.Text = NewTOAddItem.StockRate
            TxtToBatchNo.Text = ""
            TxtToBatchNo.Items.Clear()
            If NewTOAddItem.IsBatchNo = 1 Then
                LoadDataIntoComboBox("select batchno from stockbatch where stockcode=N'" & NewTOAddItem.StockItemCode & "' and stocksize=N'" & NewTOAddItem.StockITemSize & "' and location=N'" & NewTOAddItem.StockLocation & "'", TxtToBatchNo, "batchno", "")
                TxtToBatchNo.Enabled = True
                Me.TableLayoutPanel4.ColumnStyles.Item(3).Width = 12.5
                TxtToBatchNo.Focus()
            Else
                TxtToBatchNo.Enabled = False
                Me.TableLayoutPanel4.ColumnStyles.Item(3).Width = 0
                TxtToStockQty.Focus()
            End If
        Else
            TxtToStockCode.Text = ""
        End If
    End Sub

    Private Sub BtmtoAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToAdd.Click

        If TxtToStockCode.Text.Length = 0 Then
            TxtToStockCode.Focus()
            Exit Sub
        End If
        If TxtToBatchNo.Enabled = True Then
            If TxtToBatchNo.Text.Length = 0 Then
                TxtToBatchNo.Focus()
                Exit Sub
            End If
        End If
        If IsTOEditItem = True Then
            If MsgBox("Do you want to Add ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                Dim nR As Integer
                nR = EditTOItemRow
                TxtToList.Item("stlocation", nR).Value = NewTOAddItem.StockLocationNames
                TxtToList.Item("StItemcode", nR).Value = NewTOAddItem.StockItemCode
                TxtToList.Item("Stitemname", nR).Value = NewTOAddItem.StockItemName
                TxtToList.Item("Stbarcode", nR).Value = NewTOAddItem.StockItemBarCode
                TxtToList.Item("stcustbarcode", nR).Value = NewTOAddItem.CustBarCode
                TxtToList.Item("Stsize", nR).Value = NewTOAddItem.StockITemSize
                TxtToList.Item("Stbatchno", nR).Value = TxtToBatchNo.Text

                TxtToList.Item("Stsize", nR).Value = NewTOAddItem.StockITemSize
                TxtToList.Item("stqty", nR).Value = TxtToStockQty.GetTotalQty
                TxtToList.Item("stqtytext", nR).Value = TxtToStockQty.GetTotalQtyText


                If TxtToRatePer.Text = TxtToStockQty.GetSubUnit() Then
                    Dim trate As Double
                    trate = TxtTOstockrate.Text * TxtToStockQty.GetUnitConversion
                    TxtToList.Item("stprice", nR).Value = trate
                    TxtToList.Item("strateper", nR).Value = TxtToStockQty.GetMainUnit
                    TxtToList.Item("stamount", nR).Value = trate * TxtToStockQty.GetTotalQty / TxtToStockQty.GetUnitConversion
                Else
                    TxtToList.Item("stprice", nR).Value = CDbl(TxtTOstockrate.Text)
                    TxtToList.Item("strateper", nR).Value = TxtToRatePer.Text
                    TxtToList.Item("stamount", nR).Value = CDbl(TxtTOstockrate.Text) * TxtToStockQty.GetTotalQty / TxtToStockQty.GetUnitConversion
                End If
                If TxtToBatchNo.Text.Length > 0 Then
                    NewTOAddItem.StockExpirydate = CDate(SQLGetStringFieldValue("SELECT Expiry FROM STOCKBATCH WHERE STOCKCODE=N'" & NewTOAddItem.StockItemCode & "' AND STOCKSIZE=N'" & NewTOAddItem.StockITemSize & "' AND LOCATION=N'" & NewTOAddItem.StockLocation & "' AND BATCHNO=N'" & TxtToBatchNo.Text & "'", "Expiry"))
                    TxtToList.Item("stExpiry", nR).Value = NewTOAddItem.StockExpirydate
                Else
                    TxtToList.Item("stExpiry", nR).Value = ""
                End If

                FindTOTotalAmount()
                LoadToStockEntryDefaults()
                TxtToStockCode.Focus()
                IsTOEditItem = False
                IsInvoiceSaved = False
            End If
        Else
            If MsgBox("Do you want to Add ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                Dim nR As Integer
                nR = TxtToList.Rows.Add()
                TxtToList.Item("stsno", nR).Value = nR + 1
                TxtToList.Item("stlocation", nR).Value = NewTOAddItem.StockLocationNames
                TxtToList.Item("StItemcode", nR).Value = NewTOAddItem.StockItemCode
                TxtToList.Item("Stitemname", nR).Value = NewTOAddItem.StockItemName
                TxtToList.Item("Stbarcode", nR).Value = NewTOAddItem.StockItemBarCode
                TxtToList.Item("Stsize", nR).Value = NewTOAddItem.StockITemSize
                TxtToList.Item("Stbatchno", nR).Value = TxtToBatchNo.Text
                TxtToList.Item("stcustbarcode", nR).Value = NewTOAddItem.CustBarCode

                TxtToList.Item("Stsize", nR).Value = NewTOAddItem.StockITemSize
                TxtToList.Item("stqty", nR).Value = TxtToStockQty.GetTotalQty
                TxtToList.Item("stqtytext", nR).Value = TxtToStockQty.GetTotalQtyText


                If TxtToRatePer.Text = TxtToStockQty.GetSubUnit() Then
                    Dim trate As Double
                    trate = TxtTOstockrate.Text * TxtToStockQty.GetUnitConversion
                    TxtToList.Item("stprice", nR).Value = trate
                    TxtToList.Item("strateper", nR).Value = TxtToStockQty.GetMainUnit
                    TxtToList.Item("stamount", nR).Value = trate * TxtToStockQty.GetTotalQty / TxtToStockQty.GetUnitConversion
                Else
                    TxtToList.Item("stprice", nR).Value = CDbl(TxtTOstockrate.Text)
                    TxtToList.Item("strateper", nR).Value = TxtToRatePer.Text
                    TxtToList.Item("stamount", nR).Value = CDbl(TxtTOstockrate.Text) * TxtToStockQty.GetTotalQty / TxtToStockQty.GetUnitConversion
                End If

                If TxtToBatchNo.Text.Length > 0 Then
                    NewTOAddItem.StockExpirydate = CDate(SQLGetStringFieldValue("SELECT Expiry FROM STOCKBATCH WHERE STOCKCODE=N'" & NewTOAddItem.StockItemCode & "' AND STOCKSIZE=N'" & NewTOAddItem.StockITemSize & "' AND LOCATION=N'" & NewTOAddItem.StockLocation & "' AND BATCHNO=N'" & TxtToBatchNo.Text & "'", "Expiry"))
                    TxtToList.Item("stExpiry", nR).Value = NewTOAddItem.StockExpirydate
                Else
                    TxtToList.Item("stExpiry", nR).Value = ""
                End If

                TxtToList.Item("stprate", nR).Value = CDbl(TxtTOstockrate.Text)
                FindTOTotalAmount()
                LoadToStockEntryDefaults()
                TxtToStockCode.Focus()
                IsInvoiceSaved = False
            End If
        End If
    End Sub
    Sub LoadToStockEntryDefaults()
        TxtToStockCode.Text = ""
        TxtToStockSize.Text = ""
        TxtToRatePer.Text = "0"
        TxtToStockQty.ClearQty()
        TxtToStockQty.TxtQty1.Text = "1"
        TxtToStockDisc.Text = "0"
        TxtTOstockrate.Text = "0"
        TxtToBatchNo.Text = ""
        TxtToStockValue.Text = "0"
        IsTOEditItem = False
        BtnToCancel.Visible = False
        TxtToList.Enabled = True
    End Sub



    Private Sub TxttoList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtToList.CellDoubleClick
        If TxtToList.SelectedRows.Count = 0 Then Exit Sub
        If MsgBox("Do you want to Edit?          ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            LoadToStockEntryDefaults()
            IsTOEditItem = True
            BtnToCancel.Visible = True
            TxtToList.Enabled = False
            EditTOItemRow = TxtToList.CurrentRow.Index
            Dim bvalue As New ChooseItemClass
            bvalue.StockItemBarCode = TxtToList.Item("stbarcode", EditTOItemRow).Value
            bvalue.StockLocation = TxtToList.Item("stlocation", EditTOItemRow).Value
            LoadStockItemsIntoClass(bvalue.StockItemBarCode, bvalue.StockLocation, NewTOAddItem)
            TxtToStockDisc.Text = "0"
            TxtToStockValue.Text = "0"
            TxtToStockCode.Text = NewTOAddItem.StockItemCode
            TxtToStockSize.Text = NewTOAddItem.StockITemSize
            TxtToStockQty.SetUnitName(NewTOAddItem.StockUnitName)
            TxtToStockQty.ClearQty()
            TxtTOstockrate.Text = CDbl(TxtToList.Item("stprice", EditTOItemRow).Value)
            TxtToRatePer.Items.Clear()
            If NewTOAddItem.IsSimpleUnit = 1 Then
                TxtToStockQty.TxtQty2.Text = "0"
                TxtToStockQty.TxtQty1.Text = CDbl(TxtToList.Item("stqty", EditTOItemRow).Value)
                TxtToRatePer.Items.Add(NewTOAddItem.StockUnitName)
                TxtToRatePer.Text = NewTOAddItem.StockUnitName
            Else
                TxtToStockQty.TxtQty1.Text = "0"
                TxtToStockQty.TxtQty2.Text = CDbl(TxtToList.Item("stqty", EditTOItemRow).Value)
                TxtToRatePer.Items.Add(NewTOAddItem.StockMainUnitName)
                TxtToRatePer.Items.Add(NewTOAddItem.StockSubUnitName)
                TxtToRatePer.Text = NewTOAddItem.StockMainUnitName
            End If
            TxtToStockQty.CalculateValues()
            If Len(TxtToList.Item("Stbatchno", EditItemRow).Value) > 0 Then
                LoadDataIntoComboBox("select batchno from stockbatch where stockcode=N'" & TxtToStockCode.Text & "' and stocksize=N'" & TxtToStockSize.Text & "' and location=N'" & TxtToList.Item("stlocation", EditItemRow).Value & "'", TxtToBatchNo, "batchno")
                TxtToBatchNo.Text = TxtToList.Item("Stbatchno", EditItemRow).Value
                TxtToBatchNo.Enabled = True
                Me.TableLayoutPanel4.ColumnStyles.Item(3).Width = 12.5
            Else
                TxtToBatchNo.Enabled = False
                TxtToBatchNo.Text = ""
                Me.TableLayoutPanel4.ColumnStyles.Item(3).Width = 0
            End If
            TxtToStockCode.Focus()
        End If
    End Sub

    Private Sub BtntoCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToCancel.Click
        LoadToStockEntryDefaults()
    End Sub


    Private Sub TxttoList_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles TxtToList.RowsRemoved
        FindTOTotalAmount()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        UnLockTransaction(OpenedTranscode)
        Me.Close()
    End Sub

    Private Sub TxtToList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtToList.DataError

    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        If IsInvoiceSaved = False Then
            If MsgBox("The Opened Invoice is not save, Do you want to continee.... ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        LoadDefaults()
        LoadStockEntryDefaults()
        TxtDate.Focus()
        IsInvoiceSaved = True
        IsInvoiceOpen = False
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, SaveToolStripMenuItem.Click
        CheckBeforeSave()
    End Sub
    Sub CheckBeforeSave()
        If TxtInvNo.Text.Length = 0 Then
            MsgBox("Please Enter the Invoice Number...           ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtToList.RowCount = 0 Then
            MsgBox("Please Select the Items into the list..... ", MsgBoxStyle.Information)
            TxtToStockCode.Focus()
            Exit Sub
        End If
        If TxtFromList.RowCount = 0 Then
            MsgBox("Please Select the Items into the list..... ", MsgBoxStyle.Information)
            TxtStockCode.Focus()
            Exit Sub
        End If
        If CDbl(TxtTotalValue.Text) = 0 Then
            MsgBox("Please Enter the Items in the list ...     ", MsgBoxStyle.Information)
            TxtStockCode.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to save ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            SaveData()
        End If
    End Sub
    Sub SaveData()
        If IMSBEGINTRANSACTION() = False Then
            IMSENDTRANSACTION()
            ' MsgBox("Please Try again, The server is busy or ERP Server may be shutdown, Please Run the ERP Server  ")
            Exit Sub
        End If

        If IsInvoiceOpen = True Then
            If IsOpendByWindows = True Then
                UpdateLogFile(DefStoreName, OpenedTranscode, "StockTransfer", TxtQutoNo.Text, CurrentUserName, "Modified", System.Environment.MachineName, "Modified  StockTransfer  by OpenMethod")
            End If
            ExecuteSQLQuery("UPDATE  StockInvoiceDetails SET ISDELETE=1 where transcode=" & OpenedTranscode)
            ExecuteSQLQuery("UPDATE  StockInvoiceRowItems SET ISDELETE=1  where transcode=" & OpenedTranscode)
            'ROLL BACK STOCK QTY FROM LOCATION
            Dim SqlConn As New SqlClient.SqlConnection
            Try
                SqlConn.ConnectionString = ConnectionStrinG
                SqlConn.Open()
                SQLFcmd.Connection = SqlConn
                SQLFcmd.CommandText = "select * from StockInvoiceRowItems where transcode=" & OpenedTranscode
                SQLFcmd.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd.ExecuteReader
                While Sreader.Read()
                    ExecuteSQLQuery("exec UpdateStockQty N'" & Sreader("location").ToString.Trim & "',N'" & Sreader("stockcode").ToString.Trim & "',N'" & Sreader("stocksize").ToString.Trim & "',N'" & Sreader("batchno").ToString.Trim & "'")
                    ExecuteSQLQuery("EXEC proInventoryCosting N'" & Sreader("location").ToString.Trim & "',N'" & Sreader("stockcode").ToString.Trim & "',N'" & Sreader("stocksize").ToString.Trim & "'," & UpdateQuantityForNon_StockAlso)
                    ExecuteSQLQuery("exec UpdateBatchStockQty N'" & Sreader("location").ToString.Trim & "',N'" & Sreader("stockcode").ToString.Trim & "',N'" & Sreader("stocksize").ToString.Trim & "',N'" & Sreader("batchno").ToString.Trim & "'")

                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SqlConn.Close()
                SQLFcmd.Connection = Nothing
            End Try


            ExecuteSQLQuery("delete from StockInvoiceDetails where transcode=" & OpenedTranscode)
            ExecuteSQLQuery("delete from StockInvoiceRowItems where transcode=" & OpenedTranscode)

        Else
            OpenedTranscode = GetAndSetIDCode(EnumIDType.TransCode)
            GetAndSetInvoiceNumber(InvoiceNoStrct.STOCKJOURNAL)
            UpdateLogFile(DefStoreName, OpenedTranscode, "StockTransfer", TxtQutoNo.Text, CurrentUserName, "Created", System.Environment.MachineName, "Create New StockTransfer")
        End If
        SaveStockItemsRows()
        LockTransaction(OpenedTranscode)
        IsInvoiceOpen = True
        IsInvoiceSaved = True
        IMSENDTRANSACTION()
        If MyAppSettings.ISAllowAutoInvoicePrining = True Then
            PrintSJReport()
        End If
        If MyAppSettings.IsNewBillAfterSaveInvoice = True Then
            LoadDefaults()
            LoadStockEntryDefaults()
            LoadToStockEntryDefaults()
            TxtDate.Focus()
            IsInvoiceSaved = True
            IsInvoiceOpen = False
        End If
    End Sub
    Sub SaveStockItemsRows()
        Dim SqlStr As String = ""
        Try
            SqlStr = "INSERT INTO [StockInvoiceDetails] ([TransCode],[TransDate],[TransDateValue],[QutoNo],[QutoRef],[OrderNo],[OrderRef],[DNoteno]," _
                & "[DnoteRef],[StoreName],[Currency],[PriceList],[SalesPerson],[ProjectName],[Area],[LedgerName],[LedgerAddress],[IsCommit]," _
                & "[IsDelete],[IsPending],[subtotal],[grosstotal],[discountper],[nettotal],[taxtotal],[InvoiceTotal],[AccountTotal]," _
                & "[amountinwords],[narration],[InvoiceNo],[InvoiceRef],[GoodNo],[GoodRef],[CurrencyCon1],[VoucherName],[DelivaryDate],[DelivaryDateValue],[Additions],[Deductions],[PaymentMethod],[PaymentLedger],[PaymentDetails],[AccountLedgerName],[N2]) " _
                & "VALUES (@TransCode,@TransDate,@TransDateValue,@QutoNo,@QutoRef,@OrderNo,@OrderRef,@DNoteno,@DnoteRef,@StoreName,@Currency," _
                & "@PriceList,@SalesPerson,@ProjectName,@Area,@LedgerName,@LedgerAddress,@IsCommit,@IsDelete,@IsPending,@subtotal,@grosstotal," _
                & "@discountper,@nettotal,@taxtotal,@InvoiceTotal,@AccountTotal,@amountinwords,@narration,@InvoiceNo,@InvoiceRef,@GoodNo,@GoodRef,@CurrencyCon1,@VoucherName," _
                & "@DelivaryDate,@DelivaryDateValue,@Additions,@Deductions,@PaymentMethod,@PaymentLedger,@PaymentDetails,@AccountLedgerName,@N2)"
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
                .AddWithValue("PriceList", "")
                .AddWithValue("SalesPerson", "")
                .AddWithValue("ProjectName", "")
                .AddWithValue("Area", "")
                .AddWithValue("LedgerName", "")
                .AddWithValue("LedgerAddress", "")
                .AddWithValue("IsCommit", 0)
                .AddWithValue("IsDelete", 0)
                .AddWithValue("IsPending", 1)
                .AddWithValue("subtotal", CDbl(TxtTotalValue.Text))
                .AddWithValue("grosstotal", CDbl(TxtTotalValue.Text))
                .AddWithValue("discountper", 0)
                .AddWithValue("nettotal", CDbl(TxtTotalValue.Text))
                .AddWithValue("taxtotal", 0)
                .AddWithValue("InvoiceTotal", 0)
                .AddWithValue("AccountTotal", 0)
                .AddWithValue("amountinwords", "")
                .AddWithValue("narration", "Stock Journal Entry")
                .AddWithValue("InvoiceNo", "")
                .AddWithValue("InvoiceRef", "")
                .AddWithValue("GoodNo", "")
                .AddWithValue("GoodRef", "")
                .AddWithValue("VoucherName", "SJ")
                .AddWithValue("PaymentMethod", "")
                .AddWithValue("PaymentLedger", "")
                .AddWithValue("PaymentDetails", "")
                .AddWithValue("CurrencyCon1", 1)
                .AddWithValue("DelivaryDate", TxtDate.Value.Date)
                .AddWithValue("DelivaryDateValue", TxtDate.Value.Date.ToOADate)
                .AddWithValue("Additions", 0)
                .AddWithValue("Deductions", 0)
                .AddWithValue("N2", 1)
                .AddWithValue("AccountLedgerName", "")
            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'FOR OUTGOING ITEMS

        SqlStr = "INSERT INTO [StockInvoiceRowItems]([TransCode],[TransDate],[TransDateValue],[QutoNo],[QutoRef],[OrderNo],[OrderRef]," _
            & "[DNoteno],[DnoteRef],[StoreName],[Currency],[StockName],[StockCode],[stockgroup],[Barcode],[StockSize],[Location]," _
            & "[description],[BaseUnit],[MainUnit],[SubUnit],[IsSimpleUnit],[MainQty],[TotalQty],[SubUnitQty],[QtyText],[StockRate],[Expiry]," _
            & "[BatchNo],[StockType],[StockDisc],[RatePer],[UnitCon],[CustBarcode],[sno],[StockAmount],[QtyValues],[VoucherName]," _
            & "[CurrencyCon1],[Tax],[NetRate],[origin],[HScode],[isdelete],[Utranscode],[PresetRate],[mrp]) " _
            & " VALUES (@TransCode,@TransDate,@TransDateValue,@QutoNo,@QutoRef,@OrderNo,@OrderRef,@DNoteno,@DnoteRef," _
            & "@StoreName,@Currency,@StockName,@StockCode,@stockgroup,@Barcode,@StockSize,@Location,@description,@BaseUnit," _
            & "@MainUnit,@SubUnit,@IsSimpleUnit,@MainQty,@TotalQty,@SubUnitQty,@QtyText,@StockRate,@Expiry,@BatchNo,@StockType," _
            & "@StockDisc,@RatePer,@UnitCon,@CustBarcode,@sno,@StockAmount,@QtyValues,@VoucherName,@CurrencyCon1,@Tax,@NetRate,@origin,@HScode,@isdelete,@Utranscode,@PresetRate,@mrp)"

        For i As Integer = 0 To TxtFromList.RowCount - 1
            If TxtFromList.Item("SfBarCode", i).Value.ToString.Length > 0 Then
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim st As New ChooseItemClass
                st.ClearData()
                st.StockLocation = TxtFromList.Item("Sflocation", i).Value
                LoadStockItemsIntoClass(TxtFromList.Item("SfBarCode", i).Value, TxtFromList.Item("Sflocation", i).Value, st)
                st.TxtQtyBOX.SetUnitName(st.StockUnitName)
                If st.TxtQtyBOX.IsSimpleUnit = True Then
                    st.TxtQtyBOX.TxtQty1.Text = TxtFromList.Item("Sfqty", i).Value
                Else
                    st.TxtQtyBOX.TxtQty2.Text = TxtFromList.Item("Sfqty", i).Value
                End If
                st.TxtQtyBOX.CalculateValues()

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
                    .AddWithValue("MRP", st.MRP)
                    .AddWithValue("IsSimpleUnit", IIf(st.TxtQtyBOX.IsSimpleUnit() = True, 1, 0))
                    .AddWithValue("MainQty", st.TxtQtyBOX.GetUnitQtys(0))
                    .AddWithValue("TotalQty", st.TxtQtyBOX.GetTotalQty())
                    If st.TxtQtyBOX.IsSimpleUnit = True Then
                        .AddWithValue("QtyValues", st.TxtQtyBOX.TxtQty1.Text & " " & st.TxtQtyBOX.GetMainUnit)
                    Else
                        .AddWithValue("QtyValues", st.TxtQtyBOX.TxtQty1.Text & "-" & st.TxtQtyBOX.TxtQty2.Text & " " & st.TxtQtyBOX.GetMainUnit)
                    End If
                    .AddWithValue("SubUnitQty", st.TxtQtyBOX.GetUnitQtys(1))
                    .AddWithValue("QtyText", st.TxtQtyBOX.GetTotalQtyText)
                    .AddWithValue("StockRate", CDbl(TxtFromList.Item("sfprice", i).Value))
                    .AddWithValue("StockDisc", 0)
                    .AddWithValue("RatePer", "")
                    .AddWithValue("BatchNo", TxtFromList.Item("sFbatchno", i).Value)
                    If Len(TxtFromList.Item("sFbatchno", i).Value) > 0 Then
                        .AddWithValue("Expiry", CDate(TxtFromList.Item("sFExpiry", i).Value))
                    Else
                        .AddWithValue("Expiry", DBNull.Value)
                    End If
                    .AddWithValue("StockType", st.StockType)
                    .AddWithValue("UnitCon", st.TxtQtyBOX.GetUnitConversion())
                    .AddWithValue("StockAmount", CDbl(TxtFromList.Item("sfamount", i).Value))
                    .AddWithValue("PresetRate", CDbl(TxtFromList.Item("sfprate", i).Value))
                    .AddWithValue("VoucherName", "SJout")
                    .AddWithValue("CustBarcode", "")
                    .AddWithValue("CurrencyCon1", 1)
                    .AddWithValue("Tax", 0)
                    .AddWithValue("NetRate", CDbl(TxtFromList.Item("sfprice", i).Value))
                    .AddWithValue("origin", "")
                    .AddWithValue("HScode", "")
                    .AddWithValue("Utranscode", 0)
                    .AddWithValue("isdelete", 0)
                    'isdelete
                End With
                DBF1.ExecuteNonQuery()
                DBF1 = Nothing
                MAINCON.Close()


                ExecuteSQLQuery("exec UpdateStockQty N'" & st.StockLocationNames & "',N'" & st.StockItemCode & "',N'" & st.StockITemSize & "',N'" & TxtFromList.Item("sfbatchno", i).Value & "'")
                ExecuteSQLQuery("EXEC proInventoryCosting N'" & st.StockLocationNames & "',N'" & st.StockItemCode & "',N'" & st.StockITemSize & "'," & UpdateQuantityForNon_StockAlso)
                ExecuteSQLQuery("exec UpdateBatchStockQty N'" & st.StockLocationNames & "',N'" & st.StockItemCode & "',N'" & st.StockITemSize & "',N'" & TxtFromList.Item("sfbatchno", i).Value & "'")


            End If
        Next

        'FOR INCOMING ITEMS/DESTINATION

        SqlStr = "INSERT INTO [StockInvoiceRowItems]([TransCode],[TransDate],[TransDateValue],[QutoNo],[QutoRef],[OrderNo],[OrderRef]," _
            & "[DNoteno],[DnoteRef],[StoreName],[Currency],[StockName],[StockCode],[stockgroup],[Barcode],[StockSize],[Location]," _
            & "[description],[BaseUnit],[MainUnit],[SubUnit],[IsSimpleUnit],[MainQty],[TotalQty],[SubUnitQty],[QtyText],[StockRate],[Expiry]," _
            & "[BatchNo],[StockType],[StockDisc],[RatePer],[UnitCon],[CustBarcode],[sno],[StockAmount],[QtyValues],[VoucherName]," _
            & "[CurrencyCon1],[Tax],[NetRate],[origin],[HScode],[isdelete],[Utranscode],[PresetRate],[mrp]) " _
            & " VALUES (@TransCode,@TransDate,@TransDateValue,@QutoNo,@QutoRef,@OrderNo,@OrderRef,@DNoteno,@DnoteRef," _
            & "@StoreName,@Currency,@StockName,@StockCode,@stockgroup,@Barcode,@StockSize,@Location,@description,@BaseUnit," _
            & "@MainUnit,@SubUnit,@IsSimpleUnit,@MainQty,@TotalQty,@SubUnitQty,@QtyText,@StockRate,@Expiry,@BatchNo,@StockType," _
            & "@StockDisc,@RatePer,@UnitCon,@CustBarcode,@sno,@StockAmount,@QtyValues,@VoucherName,@CurrencyCon1,@Tax,@NetRate,@origin,@HScode,@isdelete,@Utranscode,@PresetRate,@mrp)"

        For i As Integer = 0 To TxtToList.RowCount - 1
            If TxtToList.Item("STBarCode", i).Value.ToString.Length > 0 Then
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim st As New ChooseItemClass
                st.ClearData()
                st.StockLocation = TxtToList.Item("Stlocation", i).Value
                LoadStockItemsIntoClass(TxtToList.Item("STBarCode", i).Value, TxtToList.Item("Stlocation", i).Value, st)
                st.TxtQtyBOX.SetUnitName(st.StockUnitName)
                If st.TxtQtyBOX.IsSimpleUnit = True Then
                    st.TxtQtyBOX.TxtQty1.Text = TxtToList.Item("Stqty", i).Value
                Else
                    st.TxtQtyBOX.TxtQty2.Text = TxtToList.Item("Stqty", i).Value
                End If
                st.TxtQtyBOX.CalculateValues()

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
                    .AddWithValue("MRP", st.MRP)
                    .AddWithValue("IsSimpleUnit", IIf(st.TxtQtyBOX.IsSimpleUnit() = True, 1, 0))
                    .AddWithValue("MainQty", st.TxtQtyBOX.GetUnitQtys(0))
                    .AddWithValue("TotalQty", st.TxtQtyBOX.GetTotalQty())
                    If st.TxtQtyBOX.IsSimpleUnit = True Then
                        .AddWithValue("QtyValues", st.TxtQtyBOX.TxtQty1.Text & " " & st.TxtQtyBOX.GetMainUnit)
                    Else
                        .AddWithValue("QtyValues", st.TxtQtyBOX.TxtQty1.Text & "-" & st.TxtQtyBOX.TxtQty2.Text & " " & st.TxtQtyBOX.GetMainUnit)
                    End If
                    .AddWithValue("SubUnitQty", st.TxtQtyBOX.GetUnitQtys(1))
                    .AddWithValue("QtyText", st.TxtQtyBOX.GetTotalQtyText)
                    .AddWithValue("StockRate", CDbl(TxtToList.Item("stprice", i).Value))
                    .AddWithValue("StockDisc", 0)
                    .AddWithValue("RatePer", "")
                    .AddWithValue("BatchNo", TxtToList.Item("sTbatchno", i).Value)
                    If Len(TxtToList.Item("sTbatchno", i).Value) > 0 Then
                        .AddWithValue("Expiry", CDate(TxtToList.Item("stExpiry", i).Value))
                    Else
                        .AddWithValue("Expiry", DBNull.Value)
                    End If

                    .AddWithValue("StockType", st.StockType)
                    .AddWithValue("UnitCon", st.TxtQtyBOX.GetUnitConversion())
                    .AddWithValue("StockAmount", CDbl(TxtToList.Item("stamount", i).Value))
                    .AddWithValue("PresetRate", CDbl(TxtToList.Item("stprate", i).Value))
                    .AddWithValue("VoucherName", "SJin")
                    .AddWithValue("CustBarcode", "")
                    .AddWithValue("CurrencyCon1", 1)
                    .AddWithValue("Tax", 0)
                    .AddWithValue("NetRate", CDbl(TxtToList.Item("stprice", i).Value))
                    .AddWithValue("origin", "")
                    .AddWithValue("HScode", "")
                    .AddWithValue("Utranscode", 0)
                    .AddWithValue("isdelete", 0)
                    'isdelete
                End With
                DBF1.ExecuteNonQuery()
                DBF1 = Nothing
                MAINCON.Close()

                 
                ExecuteSQLQuery("exec UpdateStockQty N'" & st.StockLocationNames & "',N'" & st.StockItemCode & "',N'" & st.StockITemSize & "',N'" & TxtToList.Item("sTbatchno", i).Value & "'")
                ExecuteSQLQuery("EXEC proInventoryCosting N'" & st.StockLocationNames & "',N'" & st.StockItemCode & "',N'" & st.StockITemSize & "'," & UpdateQuantityForNon_StockAlso)
                ExecuteSQLQuery("exec UpdateBatchStockQty N'" & st.StockLocationNames & "',N'" & st.StockItemCode & "',N'" & st.StockITemSize & "',N'" & TxtToList.Item("sTbatchno", i).Value & "'")


            
            End If
        Next
    End Sub



    Sub OpenByTransCodeID(ByVal tcode As Single)
        OpenedTranscode = tcode
        IsOpendByWindows = True
        UpdateLogFile(DefStoreName, OpenedTranscode, "StockJournal", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  StockJournal  for TransCode: " & OpenedTranscode.ToString)
        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from StockInvoiceRowItems where transcode=" & OpenedTranscode & " and vouchername='SJout'  order by sno"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            Dim i As Integer = 0
            While Sreader.Read()
                i = TxtFromList.Rows.Add()
                TxtFromList.Item("sfsno", i).Value = i + 1
                TxtFromList.Item("sflocation", i).Value = Sreader("location").ToString.Trim
                TxtFromList.Item("sfitemcode", i).Value = Sreader("StockCode").ToString.Trim
                TxtFromList.Item("sfitemname", i).Value = Sreader("StockName").ToString.Trim
                TxtFromList.Item("sfbarcode", i).Value = Sreader("Barcode").ToString.Trim
                TxtFromList.Item("sfcustbarcode", i).Value = Sreader("CustBarcode").ToString.Trim
                TxtFromList.Item("sfsize", i).Value = Sreader("StockSize").ToString.Trim
                TxtFromList.Item("sfbatchno", i).Value = Sreader("BatchNo").ToString.Trim
                TxtFromList.Item("sfexpiry", i).Value = Sreader("Expiry").ToString
                TxtFromList.Item("sfqty", i).Value = Sreader("TotalQty")
                TxtFromList.Item("sfqtytext", i).Value = Sreader("QtyText").ToString.Trim
                TxtFromList.Item("sfprice", i).Value = Sreader("StockRate")
                TxtFromList.Item("sfrateper", i).Value = Sreader("RatePer").ToString.Trim

                TxtFromList.Item("sfamount", i).Value = Sreader("StockAmount")
                Try
                    TxtFromList.Item("sfprate", i).Value = Sreader("PresetRate")
                Catch ex As Exception
                    TxtFromList.Item("sfprate", i).Value = GetPresetCostofStockItem(Sreader("Barcode").ToString.Trim)
                End Try

                '.AddWithValue("PresetRate", CDbl(TxtList.Item("stprate", i).Value))
                i = i + 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try

        ' LOAD DESTINATION DATA
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from StockInvoiceRowItems where transcode=" & OpenedTranscode & " and vouchername='SJin'  order by sno"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            Dim i As Integer = 0
            While Sreader.Read()
                i = TxtToList.Rows.Add()
                TxtToList.Item("stsno", i).Value = i + 1
                TxtToList.Item("stlocation", i).Value = Sreader("location").ToString.Trim
                TxtToList.Item("stitemcode", i).Value = Sreader("StockCode").ToString.Trim
                TxtToList.Item("stitemname", i).Value = Sreader("StockName").ToString.Trim
                TxtToList.Item("stbarcode", i).Value = Sreader("Barcode").ToString.Trim
                TxtToList.Item("stcustbarcode", i).Value = Sreader("CustBarcode").ToString.Trim
                TxtToList.Item("stsize", i).Value = Sreader("StockSize").ToString.Trim
                TxtToList.Item("stbatchno", i).Value = Sreader("BatchNo").ToString.Trim
                TxtToList.Item("stexpiry", i).Value = Sreader("Expiry")
                TxtToList.Item("stqty", i).Value = Sreader("TotalQty")
                TxtToList.Item("stqtytext", i).Value = Sreader("QtyText").ToString.Trim
                TxtToList.Item("stprice", i).Value = Sreader("StockRate")
                TxtToList.Item("strateper", i).Value = Sreader("RatePer").ToString.Trim

                TxtToList.Item("stamount", i).Value = Sreader("StockAmount")
                Try
                    TxtToList.Item("stprate", i).Value = Sreader("PresetRate")
                Catch ex As Exception
                    TxtToList.Item("stprate", i).Value = GetPresetCostofStockItem(Sreader("Barcode").ToString.Trim)
                End Try

                '.AddWithValue("PresetRate", CDbl(TxtList.Item("stprate", i).Value))
                i = i + 1
            End While
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
            SQLFcmd.CommandText = "select * from StockJournalDbf where transcode=" & OpenedTranscode
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                TxtDate.Value = CDate(Sreader("transdate"))
                TxtInvNo.Text = Sreader("QutoNo").ToString.Trim
                TxtQutoNo.Text = Sreader("Qutoref").ToString.Trim
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try
        IsInvoiceSaved = True
        IsInvoiceOpen = True
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click

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
        Dim editfrm As New SelectStockJornalInvoice(st)
        editfrm.ShowDialog()

        If st.SelectedTransCode = 0 Then
            Exit Sub
        Else
            LoadDefaults()
            LoadStockEntryDefaults()
            LoadToStockEntryDefaults()
            LockTransaction(st.SelectedTransCode)
            OpenByTransCodeID(st.SelectedTransCode)
            FindTOTotalAmount()
            FindTotalAmount()
        End If
    End Sub

    Private Sub StockJournalFrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub StockJournalFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDefaults()
        LoadStockEntryDefaults()
        LoadToStockEntryDefaults()
        'If MyAppSettings.IsShowAdditionalFieldsinSalesDeliveryNote = False Then
        '    Me.TableLayoutPanel2.ColumnStyles.Item(4).Width = 0
        '    Me.TableLayoutPanel2.ColumnStyles.Item(5).Width = 0
        '    TxtStockRate.Visible = False
        '    TxtRatePer.Visible = False
        '    Me.TableLayoutPanel4.ColumnStyles.Item(4).Width = 0
        '    Me.TableLayoutPanel4.ColumnStyles.Item(5).Width = 0
        '    TxtToRatePer.Visible = False
        '    TxtTOstockrate.Visible = False
        '    TxtFromList.Columns("sfprice").Visible = False
        '    TxtFromList.Columns("sfamount").Visible = False
        '    TxtToList.Columns("stprice").Visible = False
        '    TxtToList.Columns("stamount").Visible = False
        'End If
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem.Click
        If APPUserRights.IsDeleteble = False Then
            MsgBox("The Delete Restricted by the Admin, No possible to Delete......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If IsInvoiceOpen = True Then
            If IsAuditConfirm(OpenedTranscode, "Inventory") = True Then
                MsgBox("The Selected Entry is already audited, not possible to delete....", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If
        If IsInvoiceOpen = True Then
            If MsgBox("Do you want to delete current Invoice ......?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                MainForm.Cursor = Cursors.WaitCursor
                If IMSBEGINTRANSACTION() = False Then
                    IMSENDTRANSACTION()
                    ' MsgBox("Please Try again, The server is busy or ERP Server may be shutdown, Please Run the ERP Server  ")
                    Exit Sub
                End If

                ExecuteSQLQuery("update StockInvoiceDetails set isdelete=1 where transcode=" & OpenedTranscode)
                ExecuteSQLQuery("update StockInvoiceRowItems set isdelete=1 where transcode=" & OpenedTranscode)

                If IsOpendByWindows = True Then
                    UpdateLogFile(DefStoreName, OpenedTranscode, "StockTransfer", TxtQutoNo.Text, CurrentUserName, "Modified", System.Environment.MachineName, "Modified  StockTransfer  by OpenMethod")
                End If
                Dim SqlConn As New SqlClient.SqlConnection
                Try
                    SqlConn.ConnectionString = ConnectionStrinG
                    SqlConn.Open()
                    SQLFcmd.Connection = SqlConn
                    SQLFcmd.CommandText = "select * from StockInvoiceRowItems where transcode=" & OpenedTranscode
                    SQLFcmd.CommandType = CommandType.Text
                    Dim Sreader As SqlClient.SqlDataReader
                    Sreader = SQLFcmd.ExecuteReader
                    While Sreader.Read()
                        ExecuteSQLQuery("exec UpdateStockQty N'" & Sreader("location").ToString.Trim & "',N'" & Sreader("stockcode").ToString.Trim & "',N'" & Sreader("stocksize").ToString.Trim & "',N'" & Sreader("batchno").ToString.Trim & "'")
                        ExecuteSQLQuery("EXEC proInventoryCosting N'" & Sreader("location").ToString.Trim & "',N'" & Sreader("stockcode").ToString.Trim & "',N'" & Sreader("stocksize").ToString.Trim & "'," & UpdateQuantityForNon_StockAlso)
                        ExecuteSQLQuery("exec UpdateBatchStockQty N'" & Sreader("location").ToString.Trim & "',N'" & Sreader("stockcode").ToString.Trim & "',N'" & Sreader("stocksize").ToString.Trim & "',N'" & Sreader("batchno").ToString.Trim & "'")
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    SqlConn.Close()
                    SQLFcmd.Connection = Nothing
                End Try

                


                ExecuteSQLQuery("delete from StockInvoiceDetails where transcode=" & OpenedTranscode)
                ExecuteSQLQuery("delete from StockInvoiceRowItems where transcode=" & OpenedTranscode)



               
                LoadDefaults()
                LoadStockEntryDefaults()
                LoadToStockEntryDefaults()
                TxtDate.Focus()
                IsInvoiceSaved = True
                IsInvoiceOpen = False
                MainForm.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click
        PrintSJReport()
       
    End Sub
    Sub PrintSJReport()
        If IsInvoiceOpen = False Then Exit Sub

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
        If MyAppSettings.IsShowAdditionalFieldsinSalesDeliveryNote = True Then
            Me.Cursor = Cursors.WaitCursor
            Dim ds As New DataSet
            Dim cnn As SqlConnection
            cnn = New SqlConnection(ConnectionStrinG)
            cnn.Open()
            Dim dscmd As New SqlDataAdapter("SELECT * FROM stockinvoicerowitems WHERE TRANSCODE=" & OpenedTranscode, cnn)
            dscmd.Fill(ds, "stockinvoicerowitems")

            cnn.Close()
            Dim objRpt As New JournalPrintCrReport

            SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
            If PrintOptionsforCR.IsPrintHeader = False Then
                CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
                CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
                CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "STOCK JOURNAL"

            Else
                CType(objRpt.Section2.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "STOCK JOURNAL"
            End If

            CType(objRpt.Section2.ReportObjects.Item("txtinvoiceno"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtInvNo.Text
            CType(objRpt.Section2.ReportObjects.Item("txtrefno"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtQutoNo.Text
            CType(objRpt.Section2.ReportObjects.Item("txtdate"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = FormatDateTime(TxtDate.Value.Date, DateFormat.ShortDate)

            objRpt.SetDataSource(ds)
            Dim FRM As New ReportCommonForm(objRpt)
            FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            Me.Cursor = Cursors.Default
            FRM.ShowDialog()
            FRM.Dispose()
            objRpt.Dispose()
            ds.Dispose()
        Else
            Me.Cursor = Cursors.WaitCursor
            Dim ds As New DataSet
            Dim cnn As SqlConnection
            cnn = New SqlConnection(ConnectionStrinG)
            cnn.Open()
            Dim dscmd As New SqlDataAdapter("SELECT * FROM stockinvoicerowitems WHERE TRANSCODE=" & OpenedTranscode, cnn)
            dscmd.Fill(ds, "stockinvoicerowitems")

            cnn.Close()
            Dim objRpt As New JournalPrintCrReportwithoutprice

            SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
            If PrintOptionsforCR.IsPrintHeader = False Then
                CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
                CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
                CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "STOCK JOURNAL"

            Else
                CType(objRpt.Section2.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "STOCK JOURNAL"
            End If

            CType(objRpt.Section2.ReportObjects.Item("txtinvoiceno"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtInvNo.Text
            CType(objRpt.Section2.ReportObjects.Item("txtrefno"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtQutoNo.Text
            CType(objRpt.Section2.ReportObjects.Item("txtdate"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = FormatDateTime(TxtDate.Value.Date, DateFormat.ShortDate)

            objRpt.SetDataSource(ds)
            Dim FRM As New ReportCommonForm(objRpt)
            FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            Me.Cursor = Cursors.Default
            FRM.ShowDialog()
            FRM.Dispose()
            objRpt.Dispose()
            ds.Dispose()
        End If
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

    Private Sub TxtToBatchNo_GotFocus(sender As Object, e As System.EventArgs) Handles TxtToBatchNo.GotFocus
        If TxtToStockCode.Text.Length = 0 Then TxtToStockCode.Focus()
    End Sub
    Private Sub TxttoBatchNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtToBatchNo.KeyDown
        If TxtToStockCode.Text.Length = 0 Then Exit Sub
        If e.Alt = True And e.KeyCode = Keys.C Then
            Dim bvalues As New newbatchexpiryClass
            bvalues.Batchno = ""
            bvalues.stockcode = NewTOAddItem.StockItemCode
            bvalues.Stocksize = NewTOAddItem.StockITemSize
            bvalues.StockLocation = NewTOAddItem.StockLocation
            bvalues.Expirydate.Value = Today.AddDays(1)
            Dim frm As New ReadBatchExpiryInInvoice(bvalues)
            frm.ShowDialog()
            If bvalues.Batchno.Length > 0 Then
                TxtToBatchNo.Items.Add(bvalues.Batchno)
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim batchsqlstr As String = ""
                batchsqlstr = " INSERT INTO [StockBatch] ([StockCode] ,[Barcode] ,[StockSize] ,[Location],[BaseUnit],[MainUnit],[SubUnit],[IsSimpleUnit] ,[BaseQty] ,[TotalQty] ,[SubUnitQty] ,[QtyText] ,[OpBaseQty] , " _
                    & " [OpTotalQty] ,[OpSubUnitQty] ,[StockRate] ,[Expiry] ,[BatchNo] ,[OpstockRate] ,[mrp] ,[expiryDateValue])     VALUES " _
                    & "(@StockCode ,@Barcode ,@StockSize ,@Location,@BaseUnit,@MainUnit,@SubUnit,@IsSimpleUnit ,@BaseQty ,@TotalQty ,@SubUnitQty ,@QtyText , " _
                    & " @OpBaseQty ,@OpTotalQty ,@OpSubUnitQty ,@StockRate ,@Expiry ,@BatchNo ,@OpstockRate ,@mrp ,@expiryDateValue)   "
                Dim DBF1 As New SqlClient.SqlCommand(batchsqlstr, MAINCON)
                With DBF1.Parameters
                    .AddWithValue("StockCode", NewTOAddItem.StockItemCode)
                    .AddWithValue("Barcode", NewTOAddItem.StockItemBarCode)
                    .AddWithValue("StockSize", NewTOAddItem.StockITemSize)
                    .AddWithValue("Location", NewTOAddItem.StockLocation)
                    .AddWithValue("BaseUnit", NewTOAddItem.StockUnitName)
                    .AddWithValue("MainUnit", NewTOAddItem.StockMainUnitName)
                    .AddWithValue("SubUnit", NewTOAddItem.StockSubUnitName)
                    .AddWithValue("IsSimpleUnit", 1)
                    .AddWithValue("BaseQty", 0)
                    .AddWithValue("TotalQty", 0)
                    .AddWithValue("SubUnitQty", 0)
                    .AddWithValue("QtyText", 0)
                    .AddWithValue("OpBaseQty", 0)
                    .AddWithValue("OpTotalQty", 0)
                    .AddWithValue("OpSubUnitQty", 0)
                    .AddWithValue("OpstockRate", 0)
                    .AddWithValue("StockRate", NewTOAddItem.StockRate)
                    .AddWithValue("mrp", NewTOAddItem.MRP)
                    .AddWithValue("expiry", bvalues.Expirydate.Value)
                    .AddWithValue("BatchNo", bvalues.Batchno)
                    .AddWithValue("expiryDateValue", bvalues.Expirydate.Value.Date.ToOADate)
                End With
                DBF1.ExecuteNonQuery()
                DBF1 = Nothing
                MAINCON.Close()
                TxtToBatchNo.Text = bvalues.Batchno
            End If
        End If
    End Sub

  
    Private Sub TxtStockCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockCode.TextChanged

    End Sub

    Private Sub TxtToStockCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtToStockCode.TextChanged

    End Sub

    Private Sub TxtBatchNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBatchNo.SelectedIndexChanged

    End Sub

    Private Sub SearchStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchStockToolStripMenuItem.Click
        GetStockDets(0, TxtStockCode.Text)
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        GetTOStockDets(0, TxtToStockCode.Text)
    End Sub

    Private Sub TxtStockCode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtStockCode.Validating
        If TxtStockCode.Text.Length = 0 Then Exit Sub
        GetStockDets(0, TxtStockCode.Text)
        If TxtStockCode.Text.ToUpper <> NewAddItem.StockItemCode.ToUpper Then
            e.Cancel = True
        End If
    End Sub

    Private Sub TxtToStockCode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtToStockCode.Validating
        If TxtToStockCode.Text.Length = 0 Then Exit Sub
        GetTOStockDets(0, TxtToStockCode.Text)
        If TxtToStockCode.Text.ToUpper <> NewTOAddItem.StockItemCode.ToUpper Then
            e.Cancel = True
        End If
    End Sub

    Private Sub TxtToBatchNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtToBatchNo.SelectedIndexChanged

    End Sub
    
End Class