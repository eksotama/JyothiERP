Public Class payrollsubRow
    Public VoucherType As Byte
    Public LedgersType As Integer
    Dim IsShowBalance As Boolean = True
    Public LedgerSQLStr As String
    Dim ConRate As Double = 1
    Public IsAltertoOpen As Boolean = False
    Public Event AmountLostFocus(ByVal Amount As Double, ByRef mainobj As Object, ByRef amtobj As Object)
    Public Event ItemAddedEvent(ByVal e As Object)
    Public Event LedgerNameSelectedIndexChangedEvent(ByVal Amount As Double, ByRef mainobj As Object, ByRef amtobj As Object)
    Public IsBillwiseDetails As Boolean = False

    Property ShowCurrentBalance() As Boolean
        Get
            Return IsShowBalance
        End Get
        Set(ByVal value As Boolean)
            IsShowBalance = value
            If value = True Then
                TxtCurrentbalance.Visible = True
                Me.Height = 45
            Else
                TxtCurrentbalance.Visible = False
                Me.Height = 26
            End If
        End Set
    End Property
    Sub New(Optional ByVal voucherstype As Byte = 1, Optional ByVal ledgertype As Integer = 0)
        LedgersType = ledgertype
        VoucherType = voucherstype
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        CostList.Rows.Clear()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Property SetVoucherType() As Byte
        Get
            Return VoucherType
        End Get
        Set(ByVal value As Byte)
            VoucherType = value
        End Set
    End Property

    Public Sub LoadLedgersList(ByVal SqlString As String, Optional ByVal AdditionalItem As String = "")
        If SqlString.Length = 0 Then
            LoadDataIntoComboBox("select ledgername from Ledgers where Isactive=1 and n1=2", TxtLedgerName, "ledgername", AdditionalItem)
            ' LoadLedgers(TxtLedgerName, 50)
        Else
            LoadDataIntoComboBox("select ledgername from Ledgers where Isactive=1 and n1=2 and " & SqlString, TxtLedgerName, "ledgername", AdditionalItem)
            '   LoadVouchersLedgers(TxtLedgerName, SqlString)
        End If

    End Sub

    Private Sub TxtLedgerName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLedgerName.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim k As New CreateLedgerAccounts
            k.ShowDialog()
            k.Dispose()
            RaiseEvent ItemAddedEvent(Me)

        End If

    End Sub

    Private Sub TxtLedgerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.SelectedIndexChanged
        If TxtLedgerName.Text = "*End Of List" Then
        Else
            ConRate = GetCurrencyRate(SQLGetStringFieldValue("SELECT CURRENCY FROM LEDGERS WHERE LEDGERNAME=N'" & TxtLedgerName.Text & "'", "CURRENCY"))
            TxtCurrentbalance.Text = "Current " & GetCurrentBalanceText(TxtLedgerName.Text)
        End If
        RaiseEvent LedgerNameSelectedIndexChangedEvent(CDbl(TxtAmount.Text), Me, TxtLedgerName)
    End Sub

    Private Sub TxtDrCr_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDrCr.SelectedIndexChanged
        If TxtDrCr.Text = "Dr" Then
            TxtAmount.Anchor = AnchorStyles.Left
        Else
            TxtAmount.Anchor = AnchorStyles.Right
        End If
        RaiseEvent AmountLostFocus(CDbl(TxtAmount.Text), Me, TxtAmount)
    End Sub

    Private Sub TxtAmount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAmount.LostFocus
        RaiseEvent AmountLostFocus(CDbl(TxtAmount.Text), Me, TxtAmount)
    End Sub


    Private Sub TxtAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAmount.TextChanged

        If TxtAmount.Text.Length = 0 Then Exit Sub
        If IsAltertoOpen = True Then Exit Sub
        TxtCurRate.Text = ConRate

    End Sub

    Private Sub TxtAmount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtAmount.Validating
        If TxtLedgerName.Text.Length = 0 Then TxtLedgerName.Focus()
        'If SQLGetStringFieldValue("select IsAllowCostCentre from ledgers where ledgername=N'" & TxtLedgerName.Text & "'", "IsAllowCostCentre", False) = True Then
        '    Dim lfrm As New Costcenterallocation(CostList, TxtAmount.Text, TxtLedgerName.Text)
        '    lfrm.ShowDialog()
        '    e.Cancel = False
        'End If

        'If SQLGetNumericFieldValue("select isbillwise from ledgers where ledgername=N'" & TxtLedgerName.Text & "'", "isbillwise") = 1 Then
        '    CType(Me.ParentForm, VoucherEntryForm).Bill2Billdetails.LedgerAmount = TxtAmount.Text
        '    Dim bfrom As New BillwiseDetailsEntryForm(TxtLedgerName.Text, CType(Me.ParentForm, VoucherEntryForm).Bill2Billdetails, 0)
        '    bfrom.TxtHeading.Text = "Bill Wise Allocation for " & TxtLedgerName.Text
        '    bfrom.ShowDialog()
        '    If CType(Me.ParentForm, VoucherEntryForm).Bill2Billdetails.LedgerAmount <> CType(Me.ParentForm, VoucherEntryForm).Bill2Billdetails.AllocationAmount Then
        '        e.Cancel = True
        '    End If
        'End If

    End Sub
End Class
