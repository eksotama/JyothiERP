Public Class AccountFinanceSideBarMenu

    Public Shared purchaseVoucherEntry As VoucherEntryForm
    Public Shared PurchaseReturnVoucherEntry As VoucherEntryForm
    Public Shared SalesVoucherEntry As VoucherEntryForm
    Public Shared SalesReturnVoucherEntry As VoucherEntryForm
    Public Shared PaymentVoucherEntry As VoucherEntryForm
    Public Shared ReceiptVoucherEntry As VoucherEntryForm
    Public Shared JournalVoucherEntry As VoucherEntryForm
    Public Shared ContraVoucherEntry As VoucherEntryForm

    Public Shared SinglePaymentVoucherEntry As SingleEntryVoucherForm
    Public Shared SingleReceiptVoucherEntry As SingleEntryVoucherForm
    Public Shared SingleContraVoucherEntry As SingleEntryVoucherForm

    Public Shared CustomerBalaceReportFrom As LedgerBalanceSheetForm
    Public Shared SupplierBalaceReportFrom As LedgerBalanceSheetForm
    Public Shared LedgersBalaceReportFrom As LedgerBalanceSheetForm
    Public Shared LedgerAccountReportFormForCashBook As LedgerAccountReportForm
    Public Shared LedgerAccountReportFormForLedgers As LedgerAccountReportForm


    Public Sub arrangecontrols(ByVal RowNumber As Integer)
        If TxtMainTable.RowCount = 1 Then Exit Sub
        For i As Integer = 0 To TxtMainTable.RowCount - 1
            If i = RowNumber Then
                TxtMainTable.RowStyles(i).SizeType = 2
                TxtMainTable.RowStyles(i).Height = 100

                CType(TxtMainTable.Controls(i), Panel).AutoScroll = True
            Else
                TxtMainTable.RowStyles(i).SizeType = 1
                TxtMainTable.RowStyles(i).Height = 30
                CType(TxtMainTable.Controls(i), Panel).AutoScroll = False
            End If
        Next
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        arrangecontrols(0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        arrangecontrols(1)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        arrangecontrols(2)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        arrangecontrols(3)
    End Sub


    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        ConfirmPassword.PasswordTextBox.Text = ""
        If ConfirmPassword.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim k As New ChangePassword(CurrentUserName, True)
            k.ShowDialog()
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked

        ConfirmPassword.PasswordTextBox.Text = ""
        If ConfirmPassword.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ChangeRecoveryOptions.ShowDialog()
        End If
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Ledgers.SuspendLayout()
        Ledgers.MdiParent = MainForm
        Ledgers.Dock = DockStyle.Fill
        Ledgers.Show()
        Ledgers.WindowState = FormWindowState.Maximized
        Ledgers.BringToFront()
        Ledgers.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        AccountGroups.SuspendLayout()
        AccountGroups.MdiParent = MainForm
        AccountGroups.Dock = DockStyle.Fill
        AccountGroups.Show()
        AccountGroups.WindowState = FormWindowState.Maximized
        AccountGroups.BringToFront()
        AccountGroups.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        CostCentersNames.SuspendLayout()
        CostCentersNames.MdiParent = MainForm
        CostCentersNames.Dock = DockStyle.Fill
        CostCentersNames.Show()
        CostCentersNames.WindowState = FormWindowState.Maximized
        CostCentersNames.BringToFront()
        CostCentersNames.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        CurrencyExchageRates.SuspendLayout()
        CurrencyExchageRates.MdiParent = MainForm
        CurrencyExchageRates.Dock = DockStyle.Fill
        CurrencyExchageRates.Show()
        CurrencyExchageRates.WindowState = FormWindowState.Maximized
        CurrencyExchageRates.BringToFront()
        CurrencyExchageRates.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel16_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel16.LinkClicked
        If DefLedgers.CashAccount.Length < 2 Then
            MsgBox("The Cash Account Ledger not Exists. without Cash Account Ledger , voucher can't be created...")
            DefaultLedgerSettingsForm.ShowDialog()
            If DefLedgers.CashAccount.Length < 2 Then
                Exit Sub
            End If

        End If
        If MyAppSettings.AllowSingleEntryMode = True Then
            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            If SinglePaymentVoucherEntry Is Nothing OrElse SinglePaymentVoucherEntry.IsDisposed Then
                SinglePaymentVoucherEntry = New SingleEntryVoucherForm("Payment")
                SinglePaymentVoucherEntry.MdiParent = MainForm
                SinglePaymentVoucherEntry.BringToFront()
                SinglePaymentVoucherEntry.Dock = DockStyle.Fill
                SinglePaymentVoucherEntry.Show()
                SinglePaymentVoucherEntry.WindowState = FormWindowState.Maximized
            Else
                SinglePaymentVoucherEntry.MdiParent = MainForm
                SinglePaymentVoucherEntry.Dock = DockStyle.Fill
                SinglePaymentVoucherEntry.Show()
                SinglePaymentVoucherEntry.BringToFront()
            End If
            Me.Cursor = Cursors.Arrow
        Else
            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            If PaymentVoucherEntry Is Nothing OrElse PaymentVoucherEntry.IsDisposed Then
                PaymentVoucherEntry = New VoucherEntryForm("Payment")
                PaymentVoucherEntry.MdiParent = MainForm
                PaymentVoucherEntry.BringToFront()
                PaymentVoucherEntry.Dock = DockStyle.Fill
                PaymentVoucherEntry.Show()
                PaymentVoucherEntry.WindowState = FormWindowState.Maximized
            Else
                PaymentVoucherEntry.MdiParent = MainForm
                PaymentVoucherEntry.Dock = DockStyle.Fill
                PaymentVoucherEntry.Show()
                PaymentVoucherEntry.BringToFront()
            End If
            Me.Cursor = Cursors.Arrow
        End If

    End Sub

    Private Sub LinkLabel17_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel17.LinkClicked
        If DefLedgers.CashAccount.Length < 2 Then
            MsgBox("The Cash Account Ledger not Exists. without Cash Account Ledger , voucher can't be created...")
            DefaultLedgerSettingsForm.ShowDialog()
            If DefLedgers.CashAccount.Length < 2 Then
                Exit Sub
            End If
        End If
        If MyAppSettings.AllowSingleEntryMode = True Then
            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            If SingleReceiptVoucherEntry Is Nothing OrElse SingleReceiptVoucherEntry.IsDisposed Then
                SingleReceiptVoucherEntry = New SingleEntryVoucherForm("Receipt")
                SingleReceiptVoucherEntry.MdiParent = MainForm
                SingleReceiptVoucherEntry.BringToFront()
                SingleReceiptVoucherEntry.Dock = DockStyle.Fill
                SingleReceiptVoucherEntry.Show()
                SingleReceiptVoucherEntry.WindowState = FormWindowState.Maximized
            Else
                SingleReceiptVoucherEntry.MdiParent = MainForm
                SingleReceiptVoucherEntry.Dock = DockStyle.Fill
                SingleReceiptVoucherEntry.Show()
                SingleReceiptVoucherEntry.BringToFront()
            End If
            Me.Cursor = Cursors.Arrow
        Else
            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            If ReceiptVoucherEntry Is Nothing OrElse ReceiptVoucherEntry.IsDisposed Then
                ReceiptVoucherEntry = New VoucherEntryForm("Receipt")
                ReceiptVoucherEntry.MdiParent = MainForm
                ReceiptVoucherEntry.BringToFront()
                ReceiptVoucherEntry.Dock = DockStyle.Fill
                ReceiptVoucherEntry.Show()
                ReceiptVoucherEntry.WindowState = FormWindowState.Maximized
            Else
                ReceiptVoucherEntry.MdiParent = MainForm
                ReceiptVoucherEntry.Dock = DockStyle.Fill
                ReceiptVoucherEntry.Show()
                ReceiptVoucherEntry.BringToFront()
            End If
            Me.Cursor = Cursors.Arrow
        End If

    End Sub

    Private Sub LinkLabel19_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel19.LinkClicked
        If DefLedgers.CashAccount.Length < 2 Then
            MsgBox("The Cash Account Ledger not Exists. without Cash Account Ledger , voucher can't be created...")
            DefaultLedgerSettingsForm.ShowDialog()
            If DefLedgers.CashAccount.Length < 2 Then
                Exit Sub
            End If

        End If
        If MyAppSettings.AllowSingleEntryMode = True Then
            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            If SingleContraVoucherEntry Is Nothing OrElse SingleContraVoucherEntry.IsDisposed Then
                SingleContraVoucherEntry = New SingleEntryVoucherForm("Contra")
                SingleContraVoucherEntry.MdiParent = MainForm
                SingleContraVoucherEntry.BringToFront()
                SingleContraVoucherEntry.Dock = DockStyle.Fill
                SingleContraVoucherEntry.Show()
                SingleContraVoucherEntry.WindowState = FormWindowState.Maximized
            Else
                SingleContraVoucherEntry.MdiParent = MainForm
                SingleContraVoucherEntry.Dock = DockStyle.Fill
                SingleContraVoucherEntry.Show()
                SingleContraVoucherEntry.BringToFront()
            End If
            Me.Cursor = Cursors.Arrow
        Else
            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            If ContraVoucherEntry Is Nothing OrElse ContraVoucherEntry.IsDisposed Then
                ContraVoucherEntry = New VoucherEntryForm("Contra")
                ContraVoucherEntry.MdiParent = MainForm
                ContraVoucherEntry.BringToFront()
                ContraVoucherEntry.Dock = DockStyle.Fill
                ContraVoucherEntry.Show()
                ContraVoucherEntry.WindowState = FormWindowState.Maximized
            Else
                ContraVoucherEntry.MdiParent = MainForm
                ContraVoucherEntry.Dock = DockStyle.Fill
                ContraVoucherEntry.Show()
                ContraVoucherEntry.BringToFront()
            End If
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub LinkLabel18_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel18.LinkClicked

        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If JournalVoucherEntry Is Nothing OrElse JournalVoucherEntry.IsDisposed Then
            JournalVoucherEntry = New VoucherEntryForm("Journal")
            JournalVoucherEntry.MdiParent = MainForm
            JournalVoucherEntry.BringToFront()
            JournalVoucherEntry.Dock = DockStyle.Fill
            JournalVoucherEntry.Show()
            JournalVoucherEntry.WindowState = FormWindowState.Maximized
        Else
            JournalVoucherEntry.MdiParent = MainForm
            JournalVoucherEntry.Dock = DockStyle.Fill
            JournalVoucherEntry.Show()
            JournalVoucherEntry.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel25_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel25.LinkClicked
        If DefLedgers.PurchaseRetAccount.Length < 2 Then
            MsgBox("The Purchase Returns Ledger not Exists. without Purchase Return Ledger , voucher can't be created...")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchaseReturnVoucherEntry Is Nothing OrElse PurchaseReturnVoucherEntry.IsDisposed Then
            PurchaseReturnVoucherEntry = New VoucherEntryForm("Debit Note Voucher")
            PurchaseReturnVoucherEntry.MdiParent = MainForm
            PurchaseReturnVoucherEntry.BringToFront()
            PurchaseReturnVoucherEntry.Dock = DockStyle.Fill
            PurchaseReturnVoucherEntry.Show()
            PurchaseReturnVoucherEntry.WindowState = FormWindowState.Maximized
        Else
            PurchaseReturnVoucherEntry.MdiParent = MainForm
            PurchaseReturnVoucherEntry.Dock = DockStyle.Fill
            PurchaseReturnVoucherEntry.Show()
            PurchaseReturnVoucherEntry.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel24_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel24.LinkClicked
        If DefLedgers.SalesRetAccount.Length < 2 Then
            MsgBox("The Sales Returns Ledger not Exists. without Sales Return Ledger , voucher can't be created...")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesReturnVoucherEntry Is Nothing OrElse SalesReturnVoucherEntry.IsDisposed Then
            SalesReturnVoucherEntry = New VoucherEntryForm("Credit Note Voucher")
            SalesReturnVoucherEntry.MdiParent = MainForm
            SalesReturnVoucherEntry.BringToFront()
            SalesReturnVoucherEntry.Dock = DockStyle.Fill
            SalesReturnVoucherEntry.WindowState = FormWindowState.Maximized
            SalesReturnVoucherEntry.Show()
        Else
            SalesReturnVoucherEntry.MdiParent = MainForm
            SalesReturnVoucherEntry.Dock = DockStyle.Fill
            SalesReturnVoucherEntry.Show()
            SalesReturnVoucherEntry.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    
    Private Sub LinkLabel9_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        AuditForm.SuspendLayout()
        AuditForm.MdiParent = MainForm
        AuditForm.Dock = DockStyle.Fill
        AuditForm.Show()
        AuditForm.WindowState = FormWindowState.Maximized
        AuditForm.BringToFront()
        AuditForm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Me.Cursor = Cursors.WaitCursor

        TrailBalanceSheet.SuspendLayout()
        TrailBalanceSheet.MdiParent = MainForm
        TrailBalanceSheet.Dock = DockStyle.Fill
        TrailBalanceSheet.Show()
        TrailBalanceSheet.WindowState = FormWindowState.Maximized
        TrailBalanceSheet.BringToFront()
        TrailBalanceSheet.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel11_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        ProfitandLossForm.SuspendLayout()
        ProfitandLossForm.MdiParent = MainForm
        ProfitandLossForm.Dock = DockStyle.Fill
        ProfitandLossForm.Show()
        ProfitandLossForm.WindowState = FormWindowState.Maximized
        ProfitandLossForm.BringToFront()
        ProfitandLossForm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        BalanceSheet.SuspendLayout()
        BalanceSheet.MdiParent = MainForm
        BalanceSheet.Dock = DockStyle.Fill
        BalanceSheet.Show()
        BalanceSheet.WindowState = FormWindowState.Maximized
        BalanceSheet.BringToFront()
        BalanceSheet.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel10_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        CostCenterReportForm.SuspendLayout()
        CostCenterReportForm.MdiParent = MainForm
        CostCenterReportForm.Dock = DockStyle.Fill
        CostCenterReportForm.Show()
        CostCenterReportForm.WindowState = FormWindowState.Maximized
        CostCenterReportForm.BringToFront()
        CostCenterReportForm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel13_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel13.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        AccountAnalysis.SuspendLayout()
        AccountAnalysis.MdiParent = MainForm
        AccountAnalysis.Dock = DockStyle.Fill
        AccountAnalysis.Show()
        AccountAnalysis.WindowState = FormWindowState.Maximized
        AccountAnalysis.BringToFront()
        AccountAnalysis.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel15_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel15.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If LedgersBalaceReportFrom Is Nothing OrElse LedgersBalaceReportFrom.IsDisposed Then
            LedgersBalaceReportFrom = New LedgerBalanceSheetForm()
            LedgersBalaceReportFrom.MdiParent = MainForm
            LedgersBalaceReportFrom.BringToFront()
            LedgersBalaceReportFrom.TxtGroupName.Text = AccountGroupNames.CashAccounts
            LedgersBalaceReportFrom.TxtHeading.Text = "CASH ACCOUNTS REPORT "
            LedgersBalaceReportFrom.Dock = DockStyle.Fill
            LedgersBalaceReportFrom.Show()
            LedgersBalaceReportFrom.WindowState = FormWindowState.Maximized
        Else
            LedgersBalaceReportFrom.MdiParent = MainForm
            LedgersBalaceReportFrom.Dock = DockStyle.Fill
            LedgersBalaceReportFrom.Show()
            LedgersBalaceReportFrom.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel12_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel12.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        CashFlowFrm.SuspendLayout()
        CashFlowFrm.MdiParent = MainForm
        CashFlowFrm.Dock = DockStyle.Fill
        CashFlowFrm.Show()
        CashFlowFrm.WindowState = FormWindowState.Maximized
        CashFlowFrm.BringToFront()
        CashFlowFrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel14_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel14.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        FundFlowFrm.SuspendLayout()
        FundFlowFrm.MdiParent = MainForm
        FundFlowFrm.Dock = DockStyle.Fill
        FundFlowFrm.Show()
        FundFlowFrm.WindowState = FormWindowState.Maximized
        FundFlowFrm.BringToFront()
        FundFlowFrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub
End Class
