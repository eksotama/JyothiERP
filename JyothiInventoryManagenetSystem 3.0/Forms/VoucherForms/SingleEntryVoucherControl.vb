Public Class SingleEntryVoucherControl
    Public vhtype As Byte
    Public Event AmountEnteredEvent(ByVal e As Object)
    Public Event ItemAdded(ByVal e As Object)
    Public SetAsAlterMode As Boolean = False
    Public Sub LoadDefaults(ByVal VoucherNumber As Byte)
        vhtype = VoucherNumber
        If Vhtype = VoucherType.PurchaseVoucher Then
         
            Dim k2 As New SingleEntryVoucherRow(vhtype)
            k2.LedgerSQLStr = "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')"
            k2.LoadLedgersList("Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')")
            k2.TxtLedgerName.Text = DefLedgers.PurchaseAccount 'DefPurchaseAccount


            AddHandler k2.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k2.ItemAddedEvent, AddressOf LoadItemEvent

            Tb.Controls.Add(k2)
        ElseIf Vhtype = VoucherType.PurchaseRetVoucher Then

            Dim k2 As New SingleEntryVoucherRow(vhtype)
            k2.LoadLedgersList("Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')")
            k2.TxtLedgerName.Text = DefLedgers.PurchaseRetAccount 'DefPurchaseReturnAccount

            Tb.Controls.Add(k2)

            k2.LedgerSQLStr = "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')"
            AddHandler k2.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k2.ItemAddedEvent, AddressOf LoadItemEvent

        ElseIf Vhtype = VoucherType.SalesVoucher Then

            Dim k2 As New SingleEntryVoucherRow(Vhtype)
            k2.LoadLedgersList("Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')")
            k2.TxtLedgerName.Text = DefLedgers.SalesAccount  ' DefSalesAccount

            k2.LedgerSQLStr = "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')"
            Tb.Controls.Add(k2)

            AddHandler k2.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k2.ItemAddedEvent, AddressOf LoadItemEvent
        ElseIf Vhtype = VoucherType.SalesReturnVoucher Then


            Dim k2 As New SingleEntryVoucherRow(Vhtype)
            k2.LoadLedgersList("Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')")
            k2.TxtLedgerName.Text = DefLedgers.SalesRetAccount ' DefSalesReturnAccount

            k2.LedgerSQLStr = "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')"
            Tb.Controls.Add(k2)


            AddHandler k2.ItemAddedEvent, AddressOf LoadItemEvent
            AddHandler k2.AmountLostFocus, AddressOf AmountLostFocus_k
        ElseIf Vhtype = VoucherType.Payment Then

            Dim k2 As New SingleEntryVoucherRow(vhtype)
            k2.LoadLedgersList("Accountgroup not in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')")
            k2.LedgerSQLStr = "Accountgroup not in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')"
            Tb.Controls.Add(k2)
            AddHandler k2.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k2.ItemAddedEvent, AddressOf LoadItemEvent


        ElseIf Vhtype = VoucherType.Receipt Then
            Dim k2 As New SingleEntryVoucherRow(vhtype)
            k2.LoadLedgersList("Accountgroup not in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')")
            k2.LedgerSQLStr = "Accountgroup not in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')"
            Tb.Controls.Add(k2)


            AddHandler k2.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k2.ItemAddedEvent, AddressOf LoadItemEvent

        ElseIf Vhtype = VoucherType.Contra Then

            Dim k2 As New SingleEntryVoucherRow(vhtype)
            k2.LoadLedgersList("Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')")
            k2.LedgerSQLStr = "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')"
            Tb.Controls.Add(k2)
            AddHandler k2.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k2.ItemAddedEvent, AddressOf LoadItemEvent

        ElseIf Vhtype = VoucherType.journal Then

            Dim k2 As New SingleEntryVoucherRow(vhtype)
            If MyAppSettings.IsAllowCashBankinJournal = True Then
                k2.LoadLedgersList("")
            Else

                k2.LoadLedgersList("Accountgroup not in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')")
            End If

            Tb.Controls.Add(k2)
            k2.LedgerSQLStr = ""

            AddHandler k2.AmountLostFocus, AddressOf AmountLostFocus_k

            AddHandler k2.ItemAddedEvent, AddressOf LoadItemEvent
        End If
    End Sub

    Private Sub VoucherEntryControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim k As New SingleEntryVoucherRow(VoucherType, 0)
    End Sub

    Sub AmountLostFocus_k(ByVal Amount As Double, ByRef mainobj As Object, ByRef amtobj As Object)
        'On Error Resume Next
        If CType(Tb.Controls.Item(Tb.Controls.IndexOf(mainobj)), SingleEntryVoucherRow).TxtLedgerName.Text = "*End Of List" Then
            DeleteControlsFrom(Tb.Controls.IndexOf(mainobj))
            Me.TopLevelControl.SelectNextControl(Me, True, True, True, True)
            If Tb.Controls.Count = 0 Then
                AddRow()
                Me.TopLevelControl.SelectNextControl(Me, True, True, True, True)

            End If
        ElseIf CDbl(CType(Tb.Controls.Item(Tb.Controls.IndexOf(mainobj)), SingleEntryVoucherRow).TxtAmount.Text) = 0 Or CType(Tb.Controls.Item(Tb.Controls.IndexOf(mainobj)), SingleEntryVoucherRow).TxtLedgerName.Text = "*End Of List" Then
             DeleteControlsFrom(Tb.Controls.IndexOf(mainobj))
            Me.TopLevelControl.SelectNextControl(Me, True, True, True, True)
            If Tb.Controls.Count = 0 Then
                AddRow()
                Me.TopLevelControl.SelectNextControl(Me, True, True, True, True)

            End If

          
        Else
            For i As Integer = 0 To Tb.Controls.Count - 1
                If CType(Tb.Controls.Item(i), SingleEntryVoucherRow).TxtLedgerName.Text.Length = 0 Then
                    Me.TopLevelControl.SelectNextControl(Me, True, True, True, True)
                    Exit Sub
                End If
            Next
            If Tb.Controls.Count - 1 = Tb.Controls.IndexOf(mainobj) Then
                AddRow()
                Me.TopLevelControl.SelectNextControl(Me, True, True, True, True)
            Else
                CType(Tb.Controls.Item(Tb.Controls.IndexOf(mainobj) + 1), SingleEntryVoucherRow).TxtLedgerName.Focus()
            End If




        End If
        RaiseEvent AmountEnteredEvent(Me)
    End Sub
    Sub FindTotals()
        Me.ParentForm.Controls("txtDebitTotal").Text = GetDebitTotal()
        Me.ParentForm.Controls("txtcreditTotal").Text = GetCreditTotal()
    End Sub
    Public Function GetDebitTotal() As Double
        Dim dramt As Double = 0
        For i As Integer = 0 To Tb.Controls.Count - 1
            If CType(Tb.Controls.Item(i), SingleEntryVoucherRow).TxtLedgerName.Text.Length > 1 Then
                dramt = dramt + CDbl(CType(Tb.Controls.Item(i), SingleEntryVoucherRow).TxtAmount.Text)
            End If
        Next
        Return dramt
    End Function

    Public Function GetCreditTotal() As Double
        Dim dramt As Double = 0
        For i As Integer = 0 To Tb.Controls.Count - 1
            If CType(Tb.Controls.Item(i), SingleEntryVoucherRow).TxtLedgerName.Text.Length > 1 Then
                dramt = dramt + CDbl(CType(Tb.Controls.Item(i), SingleEntryVoucherRow).TxtAmount.Text)
            End If
        Next
        Return dramt
    End Function
    Sub DeleteControlsFrom(ByVal Fromno As Integer)
        For i As Integer = Fromno To Tb.Controls.Count - 1
            Try
                Tb.Controls.RemoveAt(Fromno)
            Catch ex As Exception

            End Try

        Next

    End Sub

    Function CheckIfEmpty() As Boolean
        Dim k As Boolean = False
        For i As Integer = 0 To Tb.Controls.Count - 1
            If CDbl(CType(Tb.Controls.Item(i), SingleEntryVoucherRow).TxtAmount.Text) = 0 Then
                k = True
                Exit For
            End If
        Next
        Return k
    End Function

    Public Property SetItem(ByVal col As Integer, ByVal row As Integer) As String
        Get
            Return ""
        End Get
        Set(ByVal value As String)
            Try
                Select Case (col)
                    Case 0
                        CType(Tb.Controls.Item(row), SingleEntryVoucherRow).TxtDrCr.Text = value
                    Case 1
                        CType(Tb.Controls.Item(row), SingleEntryVoucherRow).TxtLedgerName.Text = value
                    Case 2
                        CType(Tb.Controls.Item(row), SingleEntryVoucherRow).TxtAmount.Text = value
                    Case 3
                        CType(Tb.Controls.Item(row), SingleEntryVoucherRow).TxtCurRate.Text = value
                End Select
            Catch ex As Exception

            End Try
        End Set
    End Property
    Public Function GetItems(ByVal col As Integer, ByVal row As Integer) As String
        Try
            Select Case (col)
                Case 0
                    Return CType(Tb.Controls.Item(row), SingleEntryVoucherRow).TxtDrCr.Text
                Case 1
                    Return CType(Tb.Controls.Item(row), SingleEntryVoucherRow).TxtLedgerName.Text
                Case 2
                    Return CType(Tb.Controls.Item(row), SingleEntryVoucherRow).TxtAmount.Text
                Case 3
                    If CDbl(CType(Tb.Controls.Item(row), SingleEntryVoucherRow).TxtCurRate.Text) = 0 Then
                        Return 1
                    Else
                        Return CType(Tb.Controls.Item(row), SingleEntryVoucherRow).TxtCurRate.Text
                    End If
                Case Else
                    Return ""

            End Select
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Function Rowcount() As Integer
        Return Tb.Controls.Count
    End Function
    Public Sub ClearFrom(ByVal LoadVoucherType As Byte)
        DeleteControlsFrom(0)
        LoadDefaults(LoadVoucherType)
    End Sub
    Public Function AddRow() As Integer
        Dim k1 As New SingleEntryVoucherRow(vhtype)
        If SetAsAlterMode = True Then
            k1.IsAltertoOpen = True
        Else
            k1.IsAltertoOpen = False
        End If
        k1.LoadLedgersList("", True)
        k1.LedgerSQLStr = ""

        Tb.Controls.Add(k1)
        AddHandler k1.AmountLostFocus, AddressOf AmountLostFocus_k
        AddHandler k1.ItemAddedEvent, AddressOf LoadItemEvent
        CType(Tb.Controls.Item(Tb.Controls.Count - 1), SingleEntryVoucherRow).TxtLedgerName.Focus()
        Return Tb.Controls.Count - 1
    End Function
    Public Sub DeleteRowAt(ByVal ctrlindex As Integer)
        Try
            Tb.Controls.RemoveAt(ctrlindex)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub LoadItemEvent(ByVal e As Object)
        If Tb.Controls.IndexOf(e) > 0 Then
            CType(Tb.Controls(Tb.Controls.IndexOf(e)), SingleEntryVoucherRow).LoadLedgersList(CType(Tb.Controls(Tb.Controls.IndexOf(e)), SingleEntryVoucherRow).LedgerSQLStr, True)
        Else
            CType(Tb.Controls(Tb.Controls.IndexOf(e)), SingleEntryVoucherRow).LoadLedgersList(CType(Tb.Controls(Tb.Controls.IndexOf(e)), SingleEntryVoucherRow).LedgerSQLStr)
        End If

    End Sub
End Class
