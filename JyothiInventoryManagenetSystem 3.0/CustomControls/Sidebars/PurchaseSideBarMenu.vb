Public Class PurchaseSideBarMenu

    Public Shared purchaseVoucherEntry As VoucherEntryForm
    Public Shared PurchaseReturnVoucherEntry As VoucherEntryForm
    Public Shared SalesVoucherEntry As VoucherEntryForm
    Public Shared SalesReturnVoucherEntry As VoucherEntryForm
    Public Shared PaymentVoucherEntry As VoucherEntryForm
    Public Shared ReceiptVoucherEntry As VoucherEntryForm
    Public Shared JournalVoucherEntry As VoucherEntryForm
    Public Shared ContraVoucherEntry As VoucherEntryForm
    Public Shared LedgersBalaceReportFrom As LedgerBalanceSheetForm
    Public Shared SalesSOReportForm As SalesTransactionReports
    Public Shared SalesSRReportForm As SalesTransactionReports
    Public Shared SalesSIReportForm As SalesTransactionReports
    Public Shared SalesSDReportForm As SalesTransactionReports
    Public Shared SalesSQReportForm As SalesTransactionReports
    Public Shared SalesPOSReportForm As SalesTransactionReports
    Public Shared CustomerBalaceReportFrom As LedgerBalanceSheetForm
    Public Shared SupplierBalaceReportFrom As LedgerBalanceSheetForm
    Public Shared LedgerAccountReportFormForCashBook As LedgerAccountReportForm
    Public Shared LedgerAccountReportFormForLedgers As LedgerAccountReportForm

    Public Shared PurchasePQReportForm As PurchaseTransactionReports
    Public Shared PurchasePGReportForm As PurchaseTransactionReports
    Public Shared PurchasePIReportForm As PurchaseTransactionReports
    Public Shared PurchasePOReportForm As PurchaseTransactionReports
    Public Shared PurchasePRReportForm As PurchaseTransactionReports

    Public Shared SalesInvoiceFormSQ As SalesInvoiceAllFormControl
    Public Shared SalesInvoiceFormSI As SalesInvoiceAllFormControl
    Public Shared SalesInvoiceFormSD As SalesInvoiceAllFormControl
    Public Shared SalesInvoiceFormSR As SalesInvoiceAllFormControl
    Public Shared SalesInvoiceFormPOS As SalesInvoiceAllFormControl
    Public Shared SalesInvoiceFormSO As SalesInvoiceAllFormControl


    Public Shared PurchaseInvoiceFormPQ As PurchaseInvoiceAllFromControl
    Public Shared PurchaseInvoiceFormPI As PurchaseInvoiceAllFromControl
    Public Shared PurchaseInvoiceFormPG As PurchaseInvoiceAllFromControl
    Public Shared PurchaseInvoiceFormPR As PurchaseInvoiceAllFromControl
    Public Shared PurchaseInvoiceFormPO As PurchaseInvoiceAllFromControl

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
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Customers.SuspendLayout()
        Customers.MdiParent = MainForm
        Customers.Dock = DockStyle.Fill
        Customers.Show()
        Customers.WindowState = FormWindowState.Maximized
        Customers.BringToFront()
        Customers.ResumeLayout()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel342_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Suppliers.SuspendLayout()
        Suppliers.MdiParent = MainForm
        Suppliers.Dock = DockStyle.Fill
        Suppliers.Show()
        Suppliers.WindowState = FormWindowState.Maximized
        Suppliers.BringToFront()
        Suppliers.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel34_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Employees.SuspendLayout()
        Employees.MdiParent = MainForm
        Employees.Dock = DockStyle.Fill
        Employees.Show()
        Employees.WindowState = FormWindowState.Maximized
        Employees.BringToFront()
        Employees.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        Me.Cursor = Cursors.WaitCursor
        StockItems.SuspendLayout()
        StockItems.MdiParent = MainForm
        StockItems.Dock = DockStyle.Fill
        StockItems.Show()
        StockItems.WindowState = FormWindowState.Maximized
        StockItems.BringToFront()
        StockItems.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Users.SuspendLayout()
        Users.MdiParent = MainForm
        Users.Dock = DockStyle.Fill
        Users.Show()
        Users.WindowState = FormWindowState.Maximized
        Users.BringToFront()
        Users.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        StockCategories.SuspendLayout()
        StockCategories.MdiParent = MainForm
        StockCategories.Dock = DockStyle.Fill
        StockCategories.Show()
        StockCategories.WindowState = FormWindowState.Maximized
        StockCategories.BringToFront()
        StockCategories.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        StockGroups.SuspendLayout()
        StockGroups.MdiParent = MainForm
        StockGroups.Dock = DockStyle.Fill
        StockGroups.Show()
        StockGroups.WindowState = FormWindowState.Maximized
        StockGroups.BringToFront()
        StockGroups.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
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

    Private Sub LinkLabel9_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        EmployeeAttendenceSheet.SuspendLayout()
        EmployeeAttendenceSheet.MdiParent = MainForm
        EmployeeAttendenceSheet.Dock = DockStyle.Fill
        EmployeeAttendenceSheet.Show()
        EmployeeAttendenceSheet.WindowState = FormWindowState.Maximized
        EmployeeAttendenceSheet.BringToFront()
        EmployeeAttendenceSheet.ResumeLayout()
        Me.Cursor = Cursors.Default
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

    Private Sub LinkLabel11_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesInvoiceFormSO Is Nothing OrElse SalesInvoiceFormSO.IsDisposed Then
            SalesInvoiceFormSO = New SalesInvoiceAllFormControl("SO")
            SalesInvoiceFormSO.MdiParent = MainForm
            SalesInvoiceFormSO.BringToFront()
            SalesInvoiceFormSO.Dock = DockStyle.Fill
            SalesInvoiceFormSO.Show()
            SalesInvoiceFormSO.WindowState = FormWindowState.Maximized
        Else
            SalesInvoiceFormSO.MdiParent = MainForm
            SalesInvoiceFormSO.Dock = DockStyle.Fill
            SalesInvoiceFormSO.Show()
            SalesInvoiceFormSO.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel12_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesInvoiceFormSD Is Nothing OrElse SalesInvoiceFormSD.IsDisposed Then
            SalesInvoiceFormSD = New SalesInvoiceAllFormControl("SD")
            SalesInvoiceFormSD.MdiParent = MainForm
            SalesInvoiceFormSD.BringToFront()
            SalesInvoiceFormSD.Dock = DockStyle.Fill
            SalesInvoiceFormSD.Show()
            SalesInvoiceFormSD.WindowState = FormWindowState.Maximized
        Else
            SalesInvoiceFormSD.MdiParent = MainForm
            SalesInvoiceFormSD.Dock = DockStyle.Fill
            SalesInvoiceFormSD.Show()
            SalesInvoiceFormSD.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel13_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesInvoiceFormSI Is Nothing OrElse SalesInvoiceFormSI.IsDisposed Then
            SalesInvoiceFormSI = New SalesInvoiceAllFormControl("SI")
            SalesInvoiceFormSI.MdiParent = MainForm
            SalesInvoiceFormSI.BringToFront()
            SalesInvoiceFormSI.Dock = DockStyle.Fill
            SalesInvoiceFormSI.Show()
            SalesInvoiceFormSI.WindowState = FormWindowState.Maximized
        Else
            SalesInvoiceFormSI.MdiParent = MainForm
            SalesInvoiceFormSI.Dock = DockStyle.Fill
            SalesInvoiceFormSI.Show()
            SalesInvoiceFormSI.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel14_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel14.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchaseInvoiceFormPO Is Nothing OrElse PurchaseInvoiceFormPO.IsDisposed Then
            PurchaseInvoiceFormPO = New PurchaseInvoiceAllFromControl("PO")
            PurchaseInvoiceFormPO.MdiParent = MainForm
            PurchaseInvoiceFormPO.BringToFront()
            PurchaseInvoiceFormPO.Dock = DockStyle.Fill
            PurchaseInvoiceFormPO.Show()
            PurchaseInvoiceFormPO.WindowState = FormWindowState.Maximized
        Else
            PurchaseInvoiceFormPO.MdiParent = MainForm
            PurchaseInvoiceFormPO.Dock = DockStyle.Fill
            PurchaseInvoiceFormPO.Show()
            PurchaseInvoiceFormPO.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel15_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchaseInvoiceFormPG Is Nothing OrElse PurchaseInvoiceFormPG.IsDisposed Then
            PurchaseInvoiceFormPG = New PurchaseInvoiceAllFromControl("PG")
            PurchaseInvoiceFormPG.MdiParent = MainForm
            PurchaseInvoiceFormPG.BringToFront()
            PurchaseInvoiceFormPG.Dock = DockStyle.Fill
            PurchaseInvoiceFormPG.Show()
            PurchaseInvoiceFormPG.WindowState = FormWindowState.Maximized
        Else
            PurchaseInvoiceFormPG.MdiParent = MainForm
            PurchaseInvoiceFormPG.Dock = DockStyle.Fill
            PurchaseInvoiceFormPG.Show()
            PurchaseInvoiceFormPG.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel16_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        If DefLedgers.CashAccount.Length < 2 Then
            MsgBox("The Cash Account Ledger not Exists. without Cash Account Ledger , voucher can't be created...")
            Exit Sub
        End If
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
    End Sub

    Private Sub LinkLabel17_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        If DefLedgers.CashAccount.Length < 2 Then
            MsgBox("The Cash Account Ledger not Exists. without Cash Account Ledger , voucher can't be created...")
            Exit Sub
        End If
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
    End Sub

    Private Sub LinkLabel18_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

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

    Private Sub LinkLabel19_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        If DefLedgers.CashAccount.Length < 2 Then
            MsgBox("The Cash Account Ledger not Exists. without Cash Account Ledger , voucher can't be created...")
            Exit Sub
        End If

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
    End Sub

    Private Sub LinkLabel24_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        If DefLedgers.SalesRetAccount.Length < 2 Then
            MsgBox("The Sales Returns Ledger not Exists. without Sales Return Ledger , voucher can't be created...")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesReturnVoucherEntry Is Nothing OrElse SalesReturnVoucherEntry.IsDisposed Then
            SalesReturnVoucherEntry = New VoucherEntryForm("Credit Note")
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

    Private Sub LinkLabel25_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        If DefLedgers.PurchaseRetAccount.Length < 2 Then
            MsgBox("The Purchase Returns Ledger not Exists. without Purchase Return Ledger , voucher can't be created...")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchaseReturnVoucherEntry Is Nothing OrElse PurchaseReturnVoucherEntry.IsDisposed Then
            PurchaseReturnVoucherEntry = New VoucherEntryForm("Debit Note")
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

    Private Sub LinkLabel37_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Users.SuspendLayout()
        Users.MdiParent = MainForm
        Users.Dock = DockStyle.Fill
        Users.Show()
        Users.WindowState = FormWindowState.Maximized
        Users.BringToFront()
        Users.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel26_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        ActiveLoginUsersInfo.SuspendLayout()
        ActiveLoginUsersInfo.MdiParent = MainForm
        ActiveLoginUsersInfo.Dock = DockStyle.Fill
        ActiveLoginUsersInfo.Show()
        ActiveLoginUsersInfo.WindowState = FormWindowState.Maximized
        ActiveLoginUsersInfo.BringToFront()
        ActiveLoginUsersInfo.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel27_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        UserLogInfo.SuspendLayout()
        UserLogInfo.MdiParent = MainForm
        UserLogInfo.Dock = DockStyle.Fill
        UserLogInfo.Show()
        UserLogInfo.WindowState = FormWindowState.Maximized
        UserLogInfo.BringToFront()
        UserLogInfo.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub LinkLabel21_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If LedgerAccountReportFormForCashBook Is Nothing OrElse LedgerAccountReportFormForCashBook.IsDisposed Then
            LedgerAccountReportFormForCashBook = New LedgerAccountReportForm("", AccountGroupNames.CashAccounts)
            LedgerAccountReportFormForCashBook.MdiParent = MainForm
            LedgerAccountReportFormForCashBook.BringToFront()
            LedgerAccountReportFormForCashBook.Dock = DockStyle.Fill
            LedgerAccountReportFormForCashBook.Show()
            LedgerAccountReportFormForCashBook.WindowState = FormWindowState.Maximized
        Else
            LedgerAccountReportFormForCashBook.MdiParent = MainForm
            LedgerAccountReportFormForCashBook.Dock = DockStyle.Fill
            LedgerAccountReportFormForCashBook.Show()
            LedgerAccountReportFormForCashBook.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel20_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Daybook.SuspendLayout()
        Daybook.MdiParent = MainForm
        Daybook.TxtEndDate.Value = Today
        Daybook.TxtStartDate.Value = Today
        Daybook.Dock = DockStyle.Fill
        Daybook.Show()
        Daybook.WindowState = FormWindowState.Maximized
        Daybook.BringToFront()
        Daybook.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel22_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If LedgerAccountReportFormForCashBook Is Nothing OrElse LedgerAccountReportFormForCashBook.IsDisposed Then
            LedgerAccountReportFormForCashBook = New LedgerAccountReportForm("", AccountGroupNames.CustomersAccounts)
            LedgerAccountReportFormForCashBook.MdiParent = MainForm
            LedgerAccountReportFormForCashBook.BringToFront()

            LedgerAccountReportFormForCashBook.Dock = DockStyle.Fill
            LedgerAccountReportFormForCashBook.Show()
            LedgerAccountReportFormForCashBook.WindowState = FormWindowState.Maximized
        Else
            LedgerAccountReportFormForCashBook.MdiParent = MainForm
            LedgerAccountReportFormForCashBook.Dock = DockStyle.Fill
            LedgerAccountReportFormForCashBook.Show()
            LedgerAccountReportFormForCashBook.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel28_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If CustomerBalaceReportFrom Is Nothing OrElse CustomerBalaceReportFrom.IsDisposed Then
            CustomerBalaceReportFrom = New LedgerBalanceSheetForm
            CustomerBalaceReportFrom.MdiParent = MainForm
            CustomerBalaceReportFrom.BringToFront()
            CustomerBalaceReportFrom.lblGroupWise.Visible = False
            CustomerBalaceReportFrom.TxtGroupName.Visible = False
            CustomerBalaceReportFrom.TxtGroupName.Text = AccountGroupNames.CustomersAccounts
            CustomerBalaceReportFrom.Dock = DockStyle.Fill
            CustomerBalaceReportFrom.Show()
            CustomerBalaceReportFrom.WindowState = FormWindowState.Maximized
        Else
            CustomerBalaceReportFrom.MdiParent = MainForm
            CustomerBalaceReportFrom.Dock = DockStyle.Fill
            CustomerBalaceReportFrom.Show()
            CustomerBalaceReportFrom.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel36_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        SalesRegister.SuspendLayout()
        SalesRegister.MdiParent = MainForm
        SalesRegister.Dock = DockStyle.Fill
        SalesRegister.Show()
        SalesRegister.WindowState = FormWindowState.Maximized
        SalesRegister.BringToFront()
        SalesRegister.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel32_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        PurchaseRegister.SuspendLayout()
        PurchaseRegister.MdiParent = MainForm
        PurchaseRegister.Dock = DockStyle.Fill
        PurchaseRegister.Show()
        PurchaseRegister.WindowState = FormWindowState.Maximized
        PurchaseRegister.BringToFront()
        PurchaseRegister.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel29_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SupplierBalaceReportFrom Is Nothing OrElse SupplierBalaceReportFrom.IsDisposed Then
            SupplierBalaceReportFrom = New LedgerBalanceSheetForm()
            SupplierBalaceReportFrom.MdiParent = MainForm
            SupplierBalaceReportFrom.BringToFront()
            SupplierBalaceReportFrom.lblGroupWise.Visible = False
            SupplierBalaceReportFrom.TxtGroupName.Visible = False
            SupplierBalaceReportFrom.TxtGroupName.Text = AccountGroupNames.SuppliersAccounts
            SupplierBalaceReportFrom.Dock = DockStyle.Fill
            SupplierBalaceReportFrom.Show()
            SupplierBalaceReportFrom.WindowState = FormWindowState.Maximized
        Else
            SupplierBalaceReportFrom.MdiParent = MainForm
            SupplierBalaceReportFrom.Dock = DockStyle.Fill
            SupplierBalaceReportFrom.Show()
            SupplierBalaceReportFrom.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel35_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If LedgersBalaceReportFrom Is Nothing OrElse LedgersBalaceReportFrom.IsDisposed Then
            LedgersBalaceReportFrom = New LedgerBalanceSheetForm()
            LedgersBalaceReportFrom.MdiParent = MainForm
            LedgersBalaceReportFrom.BringToFront()
            LedgersBalaceReportFrom.TxtGroupName.Text = AccountGroupNames.CashAccounts
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

    Private Sub LinkLabel33_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        SalesOrderList.SuspendLayout()
        SalesOrderList.MdiParent = MainForm
        SalesOrderList.Dock = DockStyle.Fill
        SalesOrderList.Show()
        SalesOrderList.WindowState = FormWindowState.Maximized
        SalesOrderList.BringToFront()
        SalesOrderList.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel23_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesSDReportForm Is Nothing OrElse SalesSDReportForm.IsDisposed Then
            SalesSDReportForm = New SalesTransactionReports("SD")
            SalesSDReportForm.MdiParent = MainForm
            SalesSDReportForm.BringToFront()
            SalesSDReportForm.Dock = DockStyle.Fill
            SalesSDReportForm.Show()
            SalesSDReportForm.WindowState = FormWindowState.Maximized
        Else
            SalesSDReportForm.MdiParent = MainForm
            SalesSDReportForm.Dock = DockStyle.Fill
            SalesSDReportForm.Show()
            SalesSDReportForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel10_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchasePIReportForm Is Nothing OrElse PurchasePIReportForm.IsDisposed Then
            PurchasePIReportForm = New PurchaseTransactionReports("PI")
            PurchasePIReportForm.MdiParent = MainForm
            PurchasePIReportForm.BringToFront()
            PurchasePIReportForm.Dock = DockStyle.Fill
            PurchasePIReportForm.Show()
            PurchasePIReportForm.WindowState = FormWindowState.Maximized
        Else
            PurchasePIReportForm.MdiParent = MainForm
            PurchasePIReportForm.Dock = DockStyle.Fill
            PurchasePIReportForm.Show()
            PurchasePIReportForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
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

    Private Sub LinkLabel5_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchaseInvoiceFormPQ Is Nothing OrElse PurchaseInvoiceFormPQ.IsDisposed Then
            PurchaseInvoiceFormPQ = New PurchaseInvoiceAllFromControl("PQ")
            PurchaseInvoiceFormPQ.MdiParent = MainForm
            PurchaseInvoiceFormPQ.BringToFront()
            PurchaseInvoiceFormPQ.Dock = DockStyle.Fill
            PurchaseInvoiceFormPQ.Show()
            PurchaseInvoiceFormPQ.WindowState = FormWindowState.Maximized
        Else
            PurchaseInvoiceFormPQ.MdiParent = MainForm
            PurchaseInvoiceFormPQ.Dock = DockStyle.Fill
            PurchaseInvoiceFormPQ.Show()
            PurchaseInvoiceFormPQ.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel6_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchaseInvoiceFormPR Is Nothing OrElse PurchaseInvoiceFormPR.IsDisposed Then
            PurchaseInvoiceFormPR = New PurchaseInvoiceAllFromControl("PR")
            PurchaseInvoiceFormPR.MdiParent = MainForm
            PurchaseInvoiceFormPR.BringToFront()
            PurchaseInvoiceFormPR.Dock = DockStyle.Fill
            PurchaseInvoiceFormPR.Show()
            PurchaseInvoiceFormPR.WindowState = FormWindowState.Maximized
        Else
            PurchaseInvoiceFormPR.MdiParent = MainForm
            PurchaseInvoiceFormPR.Dock = DockStyle.Fill
            PurchaseInvoiceFormPR.Show()
            PurchaseInvoiceFormPR.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel4_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        PurchaseOrdersList.SuspendLayout()
        PurchaseOrdersList.MdiParent = MainForm
        PurchaseOrdersList.Dock = DockStyle.Fill
        PurchaseOrdersList.Show()
        PurchaseOrdersList.WindowState = FormWindowState.Maximized
        PurchaseOrdersList.BringToFront()
        PurchaseOrdersList.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel7_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        PendingPuchaseOrderForm.SuspendLayout()
        PendingPuchaseOrderForm.MdiParent = MainForm
        '  PurchaseOrdersList.IsShowItemWise.Checked = True
        PendingPuchaseOrderForm.Dock = DockStyle.Fill
        PendingPuchaseOrderForm.Show()
        PendingPuchaseOrderForm.WindowState = FormWindowState.Maximized
        PendingPuchaseOrderForm.BringToFront()
        PendingPuchaseOrderForm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel8_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchasePQReportForm Is Nothing OrElse PurchasePQReportForm.IsDisposed Then
            PurchasePQReportForm = New PurchaseTransactionReports("PQ")
            PurchasePQReportForm.MdiParent = MainForm
            PurchasePQReportForm.BringToFront()
            PurchasePQReportForm.Dock = DockStyle.Fill
            PurchasePQReportForm.Show()
            PurchasePQReportForm.WindowState = FormWindowState.Maximized
        Else
            PurchasePQReportForm.MdiParent = MainForm
            PurchasePQReportForm.Dock = DockStyle.Fill
            PurchasePQReportForm.Show()
            PurchasePQReportForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel9_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchasePOReportForm Is Nothing OrElse PurchasePOReportForm.IsDisposed Then
            PurchasePOReportForm = New PurchaseTransactionReports("PO")
            PurchasePOReportForm.MdiParent = MainForm
            PurchasePOReportForm.BringToFront()
            PurchasePOReportForm.Dock = DockStyle.Fill
            PurchasePOReportForm.Show()
            PurchasePOReportForm.WindowState = FormWindowState.Maximized
        Else
            PurchasePOReportForm.MdiParent = MainForm
            PurchasePOReportForm.Dock = DockStyle.Fill
            PurchasePOReportForm.Show()
            PurchasePOReportForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
