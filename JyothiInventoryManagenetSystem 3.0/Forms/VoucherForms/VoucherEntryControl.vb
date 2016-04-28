Public Class VoucherEntryControl
    Public vhtype As Byte
    Public Event AmountEnteredEvent(ByVal e As Object)
    Public Event ItemAdded(ByVal e As Object)
    Public SetAsAlterMode As Boolean = False
    Public Sub LoadDefaults(ByVal VoucherNumber As Byte)
        vhtype = VoucherNumber
        If Vhtype = VoucherType.PurchaseVoucher Then
            Dim k1 As New VoucherRow(vhtype)
            k1.LedgerSQLStr = "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CustomersAccounts & "')"
            k1.LoadLedgersList("Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CustomersAccounts & "')")
            k1.TxtDrCr.Text = "Cr"
            k1.TxtDrCr.Enabled = False
            k1.IsBillwiseDetails = True
            Tb.Controls.Add(k1)
            Dim k2 As New VoucherRow(vhtype)
            k2.LedgerSQLStr = "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')"
            k2.LoadLedgersList("Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')")
            k2.TxtLedgerName.Text = DefLedgers.PurchaseAccount 'DefPurchaseAccount
            k2.TxtDrCr.Text = "Dr"
            k2.TxtDrCr.Enabled = True

            AddHandler k1.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k2.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k2.ItemAddedEvent, AddressOf LoadItemEvent
            AddHandler k1.ItemAddedEvent, AddressOf LoadItemEvent
            Tb.Controls.Add(k2)
        ElseIf Vhtype = VoucherType.PurchaseRetVoucher Then
            Dim k1 As New VoucherRow(vhtype)

            k1.LoadLedgersList("Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CustomersAccounts & "')")
            k1.TxtDrCr.Text = "Dr"
            k1.TxtDrCr.Enabled = False
            Tb.Controls.Add(k1)
            k1.IsBillwiseDetails = True
            Dim k2 As New VoucherRow(vhtype)

            k2.LoadLedgersList("Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')")
            k2.TxtLedgerName.Text = DefLedgers.PurchaseRetAccount 'DefPurchaseReturnAccount
            k2.TxtDrCr.Text = "Cr"
            k2.TxtDrCr.Enabled = True
            Tb.Controls.Add(k2)
            k1.LedgerSQLStr = "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CustomersAccounts & "')"
            k2.LedgerSQLStr = "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')"
            AddHandler k1.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k2.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k1.ItemAddedEvent, AddressOf LoadItemEvent
            AddHandler k2.ItemAddedEvent, AddressOf LoadItemEvent
        ElseIf Vhtype = VoucherType.SalesVoucher Then
            Dim k1 As New VoucherRow(Vhtype)
            k1.LoadLedgersList("Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CustomersAccounts & "')")
            k1.TxtDrCr.Text = "Dr"
            k1.TxtDrCr.Enabled = False
            k1.IsBillwiseDetails = True
            Tb.Controls.Add(k1)
            Dim k2 As New VoucherRow(Vhtype)
            k2.LoadLedgersList("Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')")
            k2.TxtLedgerName.Text = DefLedgers.SalesAccount  ' DefSalesAccount
            k2.TxtDrCr.Text = "Cr"
            k2.TxtDrCr.Enabled = True
            Tb.Controls.Add(k2)
            k1.LedgerSQLStr = "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CustomersAccounts & "')"
            k2.LedgerSQLStr = "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')"
            AddHandler k1.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k2.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k1.ItemAddedEvent, AddressOf LoadItemEvent
            AddHandler k2.ItemAddedEvent, AddressOf LoadItemEvent
        ElseIf Vhtype = VoucherType.SalesReturnVoucher Then

            Dim k1 As New VoucherRow(Vhtype)
            k1.LoadLedgersList("Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CustomersAccounts & "')")
            k1.TxtDrCr.Text = "Cr"
            k1.TxtDrCr.Enabled = False
            Tb.Controls.Add(k1)
            k1.IsBillwiseDetails = True
            Dim k2 As New VoucherRow(Vhtype)
            k2.LoadLedgersList("Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')")
            k2.TxtLedgerName.Text = DefLedgers.SalesRetAccount ' DefSalesReturnAccount
            k2.TxtDrCr.Text = "Dr"
            k2.TxtDrCr.Enabled = True
            Tb.Controls.Add(k2)
            k1.LedgerSQLStr = "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CustomersAccounts & "')"
            k2.LedgerSQLStr = "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')"
            AddHandler k1.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k1.ItemAddedEvent, AddressOf LoadItemEvent
            AddHandler k2.ItemAddedEvent, AddressOf LoadItemEvent
            AddHandler k2.AmountLostFocus, AddressOf AmountLostFocus_k
        ElseIf Vhtype = VoucherType.Payment Then
            Dim k1 As New VoucherRow(Vhtype)
            k1.LoadLedgersList("Accountgroup not in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')")
            k1.TxtDrCr.Text = "Dr"
            k1.TxtDrCr.Enabled = False
            Tb.Controls.Add(k1)
            k1.IsBillwiseDetails = True
            Dim k2 As New VoucherRow(Vhtype)
            k2.LoadLedgersList("Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')")
            k2.TxtLedgerName.Text = DefLedgers.CashAccount  'DefCashAccount
            k2.TxtDrCr.Text = "Cr"
            k2.TxtDrCr.Enabled = False
            Tb.Controls.Add(k2)
            k1.LedgerSQLStr = "Accountgroup not in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')"
            k2.LedgerSQLStr = "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')"
            AddHandler k1.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k2.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k1.ItemAddedEvent, AddressOf LoadItemEvent
            AddHandler k2.ItemAddedEvent, AddressOf LoadItemEvent
            'AddHandler k1.ItemAddedEvent ,AddressOf 
        ElseIf Vhtype = VoucherType.Receipt Then
            Dim k1 As New VoucherRow(Vhtype)
            k1.LoadLedgersList("Accountgroup not in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')")
            k1.TxtDrCr.Text = "Cr"
            k1.TxtDrCr.Enabled = False
            k1.IsBillwiseDetails = True
            Tb.Controls.Add(k1)
            Dim k2 As New VoucherRow(Vhtype)
            k2.LoadLedgersList("Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')")
            k2.TxtDrCr.Text = "Dr"
            k2.TxtLedgerName.Text = DefLedgers.CashAccount 'DefCashAccount
            k2.TxtDrCr.Enabled = False
            Tb.Controls.Add(k2)
            k1.LedgerSQLStr = "Accountgroup not in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or  groupname=N'" & AccountGroupNames.BankAccounts & "')"
            k2.LedgerSQLStr = "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')"
            AddHandler k1.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k2.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k2.ItemAddedEvent, AddressOf LoadItemEvent
            AddHandler k1.ItemAddedEvent, AddressOf LoadItemEvent
        ElseIf Vhtype = VoucherType.Contra Then
            Dim k1 As New VoucherRow(Vhtype)
            k1.LoadLedgersList("Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')")
            k1.TxtDrCr.Text = "Cr"
            k1.TxtDrCr.Enabled = False
            k1.IsBillwiseDetails = True
            Tb.Controls.Add(k1)
            Dim k2 As New VoucherRow(Vhtype)
            k2.LoadLedgersList("Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')")
            k2.TxtDrCr.Text = "Dr"
            k2.TxtDrCr.Enabled = False
            Tb.Controls.Add(k2)
            k1.LedgerSQLStr = "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')"
            k2.LedgerSQLStr = "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')"
            AddHandler k1.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k2.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k2.ItemAddedEvent, AddressOf LoadItemEvent
            AddHandler k1.ItemAddedEvent, AddressOf LoadItemEvent
            'LoadVouchersLedgers(LedgerList3, "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')")
        ElseIf Vhtype = VoucherType.journal Then
            Dim k1 As New VoucherRow(vhtype)
            Dim k2 As New VoucherRow(vhtype)
            If MyAppSettings.IsAllowCashBankinJournal = True Then
                k1.LoadLedgersList("")
                k2.LoadLedgersList("")
            Else
                k1.LoadLedgersList("Accountgroup not in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')")
                k2.LoadLedgersList("Accountgroup not in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')")
            End If
            k1.TxtDrCr.Text = "Dr"
            k1.TxtDrCr.Enabled = False
            k1.IsBillwiseDetails = True
            Tb.Controls.Add(k1)
            k2.TxtDrCr.Text = "Cr"
            k2.TxtDrCr.Enabled = True
            Tb.Controls.Add(k2)
            k1.LedgerSQLStr = ""
            k2.LedgerSQLStr = ""
            AddHandler k1.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k2.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k1.ItemAddedEvent, AddressOf LoadItemEvent
            AddHandler k2.ItemAddedEvent, AddressOf LoadItemEvent
        End If
    End Sub

    Private Sub VoucherEntryControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim k As New VoucherRow(VoucherType, 0)
    End Sub
    Sub AmountLostFocus_k(ByVal Amount As Double, ByRef mainobj As Object, ByRef amtobj As Object)
        On Error Resume Next
        If Tb.Controls.IndexOf(mainobj) = 0 Then
            If CDbl(CType(Tb.Controls.Item(1), VoucherRow).TxtAmount.Text) = 0 Then
                CType(Tb.Controls.Item(1), VoucherRow).TxtAmount.Text = CType(Tb.Controls.Item(0), VoucherRow).TxtAmount.Text
                DeleteControlsFrom(2)
            End If
        ElseIf Tb.Controls.IndexOf(mainobj) = 1 And Tb.Controls.Count = 2 Then
            Dim cramt As Double = 0
            Dim dramt As Double = 0
            If CType(Tb.Controls.Item(1), VoucherRow).TxtDrCr.Text = "Dr" Then
                dramt = CDbl(CType(Tb.Controls.Item(1), VoucherRow).TxtAmount.Text)
            Else
                cramt = CDbl(CType(Tb.Controls.Item(1), VoucherRow).TxtAmount.Text)
            End If
            If CType(Tb.Controls.Item(0), VoucherRow).TxtDrCr.Text = "Dr" Then
                dramt = dramt + CDbl(CType(Tb.Controls.Item(0), VoucherRow).TxtAmount.Text)
            Else
                cramt = cramt + CDbl(CType(Tb.Controls.Item(0), VoucherRow).TxtAmount.Text)
            End If

            If cramt <> dramt Then
                Dim k1 As New VoucherRow(vhtype)
                k1.LoadLedgersList("")
                If dramt > cramt Then
                    k1.TxtDrCr.Text = "Cr"
                    k1.TxtAmount.Text = dramt - cramt
                Else
                    k1.TxtDrCr.Text = "Dr"
                    k1.TxtAmount.Text = cramt - dramt
                End If
                k1.TxtDrCr.Enabled = True
                k1.TxtDrCr.Focus()
                k1.LedgerSQLStr = ""

                Tb.Controls.Add(k1)
                AddHandler k1.AmountLostFocus, AddressOf AmountLostFocus_k
                AddHandler k1.ItemAddedEvent, AddressOf LoadItemEvent
                Tb.Controls(Tb.Controls.Count - 1).Focus()
            End If

        Else

            If CDbl(CType(Tb.Controls.Item(Tb.Controls.IndexOf(mainobj)), VoucherRow).TxtAmount.Text) = 0 Then
                Exit Sub
            End If
            Dim cramt As Double = 0
            Dim dramt As Double = 0
            Dim newRow As Boolean = True
            For i As Integer = 0 To Tb.Controls.Count - 1
                If CType(Tb.Controls.Item(i), VoucherRow).TxtDrCr.Text = "Dr" Then
                    dramt = dramt + CDbl(CType(Tb.Controls.Item(i), VoucherRow).TxtAmount.Text)
                Else
                    cramt = cramt + CDbl(CType(Tb.Controls.Item(i), VoucherRow).TxtAmount.Text)
                End If
                If dramt = cramt Then
                    DeleteControlsFrom(i + 1)
                    newRow = False
                    Exit For
                End If
            Next
            If newRow = True Then
                If Tb.Controls.IndexOf(mainobj) < Tb.Controls.Count - 1 Then
                    Exit Sub
                ElseIf CheckIfEmpty() = False Then
                    Dim k1 As New VoucherRow(vhtype)
                    k1.LoadLedgersList("")
                    If dramt > cramt Then
                        k1.TxtDrCr.Text = "Cr"
                        k1.TxtAmount.Text = dramt - cramt
                    Else
                        k1.TxtDrCr.Text = "Dr"
                        k1.TxtAmount.Text = cramt - dramt
                    End If
                    k1.LedgerSQLStr = ""
                    k1.TxtDrCr.Enabled = True
                    Tb.Controls.Add(k1)

                    AddHandler k1.AmountLostFocus, AddressOf AmountLostFocus_k
                    AddHandler k1.ItemAddedEvent, AddressOf LoadItemEvent
                    'Tb.Controls.Item(Tb.Controls(Tb.Controls.Count - 1)).Focus()
                    Tb.Controls(Tb.Controls.Count - 1).Focus()

                End If
            End If
            If newRow = False Then
                Me.TopLevelControl.SelectNextControl(Me, True, True, True, True)
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
            If CType(Tb.Controls.Item(i), VoucherRow).TxtDrCr.Text = "Dr" And CType(Tb.Controls.Item(i), VoucherRow).TxtLedgerName.Text.Length > 1 Then
                dramt = dramt + CDbl(CType(Tb.Controls.Item(i), VoucherRow).TxtAmount.Text)
            End If
        Next
        Return dramt
    End Function

    Public Function GetCreditTotal() As Double
        Dim dramt As Double = 0
        For i As Integer = 0 To Tb.Controls.Count - 1
            If CType(Tb.Controls.Item(i), VoucherRow).TxtDrCr.Text = "Cr" And CType(Tb.Controls.Item(i), VoucherRow).TxtLedgerName.Text.Length > 1 Then
                dramt = dramt + CDbl(CType(Tb.Controls.Item(i), VoucherRow).TxtAmount.Text)
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
            If CDbl(CType(Tb.Controls.Item(i), VoucherRow).TxtAmount.Text) = 0 Then
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
                        CType(Tb.Controls.Item(row), VoucherRow).TxtDrCr.Text = value
                    Case 1
                        CType(Tb.Controls.Item(row), VoucherRow).TxtLedgerName.Text = value
                    Case 2
                        CType(Tb.Controls.Item(row), VoucherRow).TxtAmount.Text = value
                    Case 3
                        CType(Tb.Controls.Item(row), VoucherRow).TxtCurRate.Text = value
                End Select
            Catch ex As Exception

            End Try
        End Set
    End Property
    Public Function GetItems(ByVal col As Integer, ByVal row As Integer) As String
        Try
            Select Case (col)
                Case 0
                    Return CType(Tb.Controls.Item(row), VoucherRow).TxtDrCr.Text
                Case 1
                    Return CType(Tb.Controls.Item(row), VoucherRow).TxtLedgerName.Text
                Case 2
                    Return CType(Tb.Controls.Item(row), VoucherRow).TxtAmount.Text
                Case 3
                    If CDbl(CType(Tb.Controls.Item(row), VoucherRow).TxtCurRate.Text) = 0 Then
                        Return 1
                    Else
                        Return CType(Tb.Controls.Item(row), VoucherRow).TxtCurRate.Text
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
        Dim k1 As New VoucherRow(vhtype)
        If SetAsAlterMode = True Then
            k1.IsAltertoOpen = True
        Else
            k1.IsAltertoOpen = False
        End If
        k1.LoadLedgersList("")
        k1.TxtDrCr.Text = "Cr"
        k1.TxtDrCr.Enabled = True
        k1.LedgerSQLStr = ""
        Tb.Controls.Add(k1)
        AddHandler k1.AmountLostFocus, AddressOf AmountLostFocus_k
        AddHandler k1.ItemAddedEvent, AddressOf LoadItemEvent

        Return Tb.Controls.Count - 1
    End Function
    Public Sub DeleteRowAt(ByVal ctrlindex As Integer)
        Try
            Tb.Controls.RemoveAt(ctrlindex)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub LoadItemEvent(ByVal e As Object)
        CType(Tb.Controls(Tb.Controls.IndexOf(e)), VoucherRow).LoadLedgersList(CType(Tb.Controls(Tb.Controls.IndexOf(e)), VoucherRow).LedgerSQLStr)
    End Sub
End Class
