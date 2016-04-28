Public Class PayrollVoucherControl
    Public vhtype As Byte
    Public Event AmountEnteredEvent(ByVal e As Object)
    Public Event ItemAdded(ByVal e As Object)
    Public SetAsAlterMode As Boolean = False
    Public Sub LoadDefaults(ByVal VoucherNumber As Byte)
        vhtype = VoucherNumber
        If Vhtype = VoucherType.Payment Then
            Dim k1 As New PayrollVoucherRow(Vhtype)
            k1.LoadLedgersList("Accountgroup not in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.ProvisionsAcounts & "' or groupname=N'" & AccountGroupNames.CapitalAccounts & "' or groupname=N'" & AccountGroupNames.FixedAssets & "' or groupname=N'" & AccountGroupNames.PurchaseAccounts & "' or groupname=N'" & AccountGroupNames.StockAccounts & "'  or groupname=N'" & AccountGroupNames.SalesAccounts & "' )")
            k1.TxtDrCr.Text = "Dr"
            k1.TxtDrCr.Enabled = False
            Tb.Controls.Add(k1)

            Dim k2 As New PayrollVoucherRow(Vhtype)
            k2.LoadLedgersList("Accountgroup not in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.ProvisionsAcounts & "' or groupname=N'" & AccountGroupNames.CapitalAccounts & "' or groupname=N'" & AccountGroupNames.FixedAssets & "' or groupname=N'" & AccountGroupNames.PurchaseAccounts & "' or groupname=N'" & AccountGroupNames.StockAccounts & "'  or groupname=N'" & AccountGroupNames.SalesAccounts & "' )")
            k2.TxtLedgerName.Text = DefLedgers.CashAccount  'DefCashAccount
            k2.TxtDrCr.Text = "Cr"
            k2.TxtDrCr.Enabled = True
            Tb.Controls.Add(k2)
            k1.LedgerSQLStr = "Accountgroup not in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.ProvisionsAcounts & "' or groupname=N'" & AccountGroupNames.CapitalAccounts & "' or groupname=N'" & AccountGroupNames.FixedAssets & "' or groupname=N'" & AccountGroupNames.PurchaseAccounts & "' or groupname=N'" & AccountGroupNames.StockAccounts & "'  or groupname=N'" & AccountGroupNames.SalesAccounts & "' )"
            k2.LedgerSQLStr = "Accountgroup not in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.ProvisionsAcounts & "' or groupname=N'" & AccountGroupNames.CapitalAccounts & "' or groupname=N'" & AccountGroupNames.FixedAssets & "' or groupname=N'" & AccountGroupNames.PurchaseAccounts & "' or groupname=N'" & AccountGroupNames.StockAccounts & "'  or groupname=N'" & AccountGroupNames.SalesAccounts & "' )"
            
            AddHandler k1.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k2.AmountLostFocus, AddressOf AmountLostFocus_k
            AddHandler k1.ItemAddedEvent, AddressOf LoadItemEvent
            AddHandler k2.ItemAddedEvent, AddressOf LoadItemEvent
            'AddHandler k1.ItemAddedEvent ,AddressOf 
        
        End If
    End Sub

    Private Sub VoucherEntryControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'Dim k As New PayrollVoucherRow(VoucherType, 0)
    End Sub
    Sub AmountLostFocus_k(ByVal Amount As Double, ByRef mainobj As Object, ByRef amtobj As Object)
        On Error Resume Next
        If Tb.Controls.IndexOf(mainobj) = 0 Then
            If CDbl(CType(Tb.Controls.Item(1), PayrollVoucherRow).TxtAmount.Text) = 0 Then
                CType(Tb.Controls.Item(1), PayrollVoucherRow).TxtAmount.Text = CType(Tb.Controls.Item(0), PayrollVoucherRow).TxtAmount.Text
                DeleteControlsFrom(2)
            End If
        ElseIf Tb.Controls.IndexOf(mainobj) = 1 And Tb.Controls.Count = 2 Then
            Dim cramt As Double = 0
            Dim dramt As Double = 0
            If CType(Tb.Controls.Item(1), PayrollVoucherRow).TxtDrCr.Text = "Dr" Then
                dramt = CDbl(CType(Tb.Controls.Item(1), PayrollVoucherRow).TxtAmount.Text)
            Else
                cramt = CDbl(CType(Tb.Controls.Item(1), PayrollVoucherRow).TxtAmount.Text)
            End If
            If CType(Tb.Controls.Item(0), PayrollVoucherRow).TxtDrCr.Text = "Dr" Then
                dramt = dramt + CDbl(CType(Tb.Controls.Item(0), PayrollVoucherRow).TxtAmount.Text)
            Else
                cramt = cramt + CDbl(CType(Tb.Controls.Item(0), PayrollVoucherRow).TxtAmount.Text)
            End If

            If cramt <> dramt Then
                Dim k1 As New PayRollVoucherRow(vhtype)
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

            If CDbl(CType(Tb.Controls.Item(Tb.Controls.IndexOf(mainobj)), PayrollVoucherRow).TxtAmount.Text) = 0 Then
                Exit Sub
            End If
            Dim cramt As Double = 0
            Dim dramt As Double = 0
            Dim newRow As Boolean = True
            For i As Integer = 0 To Tb.Controls.Count - 1
                If CType(Tb.Controls.Item(i), PayrollVoucherRow).TxtDrCr.Text = "Dr" Then
                    dramt = dramt + CDbl(CType(Tb.Controls.Item(i), PayrollVoucherRow).TxtAmount.Text)
                Else
                    cramt = cramt + CDbl(CType(Tb.Controls.Item(i), PayrollVoucherRow).TxtAmount.Text)
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
                    Dim k1 As New PayRollVoucherRow(vhtype)
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
            If CType(Tb.Controls.Item(i), PayrollVoucherRow).TxtDrCr.Text = "Dr" And CType(Tb.Controls.Item(i), PayrollVoucherRow).TxtLedgerName.Text.Length > 1 Then
                dramt = dramt + CDbl(CType(Tb.Controls.Item(i), PayrollVoucherRow).TxtAmount.Text)
            End If
        Next
        Return dramt
    End Function

    Public Function GetCreditTotal() As Double
        Dim dramt As Double = 0
        For i As Integer = 0 To Tb.Controls.Count - 1
            If CType(Tb.Controls.Item(i), PayrollVoucherRow).TxtDrCr.Text = "Cr" And CType(Tb.Controls.Item(i), PayrollVoucherRow).TxtLedgerName.Text.Length > 1 Then
                dramt = dramt + CDbl(CType(Tb.Controls.Item(i), PayrollVoucherRow).TxtAmount.Text)
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
            If CDbl(CType(Tb.Controls.Item(i), PayrollVoucherRow).TxtAmount.Text) = 0 Then
                k = True
                Exit For
            End If
        Next
        Return k
    End Function

    Public Property Item(ByVal col As Integer, ByVal row As Integer) As String
        Get
            Return ""
        End Get
        Set(ByVal value As String)
            Try
                Select Case (col)
                    Case 0
                        CType(Tb.Controls.Item(row), PayRollVoucherRow).TxtDrCr.Text = value
                    Case 1
                        CType(Tb.Controls.Item(row), PayRollVoucherRow).TxtLedgerName.Text = value
                    Case 2
                        CType(Tb.Controls.Item(row), PayRollVoucherRow).TxtNarration.Text = value
                    Case 3
                        CType(Tb.Controls.Item(row), PayrollVoucherRow).TxtAmount.Text = value
                    Case 4
                        CType(Tb.Controls.Item(row), PayrollVoucherRow).TxtCurRate.Text = value
                End Select
            Catch ex As Exception

            End Try
        End Set
    End Property
    Public Function Items(ByVal col As Integer, ByVal row As Integer) As String
        Try
            Select Case (col)
                Case 0
                    Return CType(Tb.Controls.Item(row), PayrollVoucherRow).TxtDrCr.Text
                Case 1
                    Return CType(Tb.Controls.Item(row), PayrollVoucherRow).TxtLedgerName.Text
                Case 2
                    Return CType(Tb.Controls.Item(row), PayRollVoucherRow).TxtNarration.Text
                Case 3
                    Return CType(Tb.Controls.Item(row), PayRollVoucherRow).TxtAmount.Text

                Case 4
                    If CDbl(CType(Tb.Controls.Item(row), PayRollVoucherRow).TxtCurRate.Text) = 0 Then
                        Return 1
                    Else
                        Return CType(Tb.Controls.Item(row), PayRollVoucherRow).TxtCurRate.Text
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
        Dim k1 As New PayRollVoucherRow(vhtype)
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
        CType(Tb.Controls(Tb.Controls.IndexOf(e)), PayrollVoucherRow).LoadLedgersList(CType(Tb.Controls(Tb.Controls.IndexOf(e)), PayrollVoucherRow).LedgerSQLStr)
        ' e.LoadLedgersList(e.ledgersqlstr)
        'LedgerSQLStr
    End Sub
End Class
