Public Class Payrollsubcontrol
    Public vhtype As Byte
    Public Event AmountEnteredEvent(ByVal e As Object)
    Public Event ItemAdded(ByVal e As Object)
    Public SetAsAlterMode As Boolean = False
    Public Event RowsCompletedEvent(ByVal e As Object)
    Public Sub LoadDefaults(ByVal VoucherNumber As Byte)
        vhtype = VoucherNumber
        Dim k1 As New payrollsubRow(vhtype)
        'k1.LedgerSQLStr = "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CustomersAccounts & "')"
        'k1.LoadLedgersList("Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CustomersAccounts & "')")
        k1.TxtDrCr.Text = "Dr"
        k1.TxtDrCr.Enabled = True
        k1.IsBillwiseDetails = False
        Tb.Controls.Add(k1)
        Dim k2 As New payrollsubRow(vhtype)
        'k2.LedgerSQLStr = "Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')"
        k2.LoadLedgersList("", "*End Of List")
        ' k2.TxtLedgerName.Text = DefLedgers.PurchaseAccount 'DefPurchaseAccount
        k2.TxtDrCr.Text = "Dr"
        k2.TxtDrCr.Enabled = True
        AddHandler k1.AmountLostFocus, AddressOf AmountLostFocus_k
        AddHandler k1.LedgerNameSelectedIndexChangedEvent, AddressOf LedgerNameChangedEvent
        AddHandler k2.AmountLostFocus, AddressOf AmountLostFocus_k
        AddHandler k2.ItemAddedEvent, AddressOf LoadItemEvent
        AddHandler k2.LedgerNameSelectedIndexChangedEvent, AddressOf LedgerNameChangedEvent
        AddHandler k1.ItemAddedEvent, AddressOf LoadItemEvent
        Tb.Controls.Add(k2)

    End Sub

    Private Sub VoucherEntryControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ERPInitializeObjects(sender)
        'Dim k As New payrollsubRow(VoucherType, 0)
    End Sub
    Sub AmountLostFocus_k(ByVal Amount As Double, ByRef mainobj As Object, ByRef amtobj As Object)
        On Error Resume Next

        If Tb.Controls.IndexOf(mainobj) = Tb.Controls.Count Then
            AddRow()
        Else
            'Me.TopLevelControl.SelectNextControl(Me, True, True, True, True)
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
            If CType(Tb.Controls.Item(i), payrollsubRow).TxtDrCr.Text = "Dr" And CType(Tb.Controls.Item(i), payrollsubRow).TxtLedgerName.Text.Length > 1 Then
                dramt = dramt + CDbl(CType(Tb.Controls.Item(i), payrollsubRow).TxtAmount.Text)
            End If
        Next
        Return dramt
    End Function

    Public Function GetCreditTotal() As Double
        Dim dramt As Double = 0
        For i As Integer = 0 To Tb.Controls.Count - 1
            If CType(Tb.Controls.Item(i), payrollsubRow).TxtDrCr.Text = "Cr" And CType(Tb.Controls.Item(i), payrollsubRow).TxtLedgerName.Text.Length > 1 Then
                dramt = dramt + CDbl(CType(Tb.Controls.Item(i), payrollsubRow).TxtAmount.Text)
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
            If CDbl(CType(Tb.Controls.Item(i), payrollsubRow).TxtAmount.Text) = 0 Then
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
                        CType(Tb.Controls.Item(row), payrollsubRow).TxtDrCr.Text = value
                    Case 1
                        CType(Tb.Controls.Item(row), payrollsubRow).TxtLedgerName.Text = value
                    Case 2
                        CType(Tb.Controls.Item(row), payrollsubRow).TxtAmount.Text = value
                    Case 3
                        CType(Tb.Controls.Item(row), payrollsubRow).TxtCurRate.Text = value
                End Select
            Catch ex As Exception

            End Try
        End Set
    End Property
    Public Function GetItems(ByVal col As Integer, ByVal row As Integer) As String
        Try
            Select Case (col)
                Case 0
                    Return CType(Tb.Controls.Item(row), payrollsubRow).TxtDrCr.Text
                Case 1
                    Return CType(Tb.Controls.Item(row), payrollsubRow).TxtLedgerName.Text
                Case 2
                    Return CType(Tb.Controls.Item(row), payrollsubRow).TxtAmount.Text
                Case 3
                    If CDbl(CType(Tb.Controls.Item(row), payrollsubRow).TxtCurRate.Text) = 0 Then
                        Return 1
                    Else
                        Return CType(Tb.Controls.Item(row), payrollsubRow).TxtCurRate.Text
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
        Dim k1 As New payrollsubRow(vhtype)
        k1.LoadLedgersList("", "*End Of List")
        k1.TxtDrCr.Text = "Dr"
        k1.TxtDrCr.Enabled = True
        k1.LedgerSQLStr = ""
        Tb.Controls.Add(k1)
        AddHandler k1.AmountLostFocus, AddressOf AmountLostFocus_k
        AddHandler k1.ItemAddedEvent, AddressOf LoadItemEvent
        AddHandler k1.LedgerNameSelectedIndexChangedEvent, AddressOf LedgerNameChangedEvent
        Return Tb.Controls.Count - 1
    End Function
    Public Sub DeleteRowAt(ByVal ctrlindex As Integer)
        Try
            Tb.Controls.RemoveAt(ctrlindex)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub LoadItemEvent(ByVal e As Object)
        CType(Tb.Controls(Tb.Controls.IndexOf(e)), payrollsubRow).LoadLedgersList(CType(Tb.Controls(Tb.Controls.IndexOf(e)), payrollsubRow).LedgerSQLStr)
    End Sub
    Public Sub LedgerNameChangedEvent(ByVal Amount As Double, ByRef mainobj As Object, ByRef amtobj As Object)
        If CType(Tb.Controls.Item(Tb.Controls.IndexOf(mainobj)), VoucherRow).TxtLedgerName.Text = "*End Of List" Then
            Me.TopLevelControl.SelectNextControl(Me, True, True, True, True)
            DeleteControlsFrom(Tb.Controls.IndexOf(mainobj) + 1)
            RaiseEvent RowsCompletedEvent(Me)
        End If

    End Sub
End Class
