Public Class InventorySideBarMenu
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
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
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

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
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

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
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

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked

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

   

    Private Sub LinkLabel6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
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

    Private Sub LinkLabel7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
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

    

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        arrangecontrols(0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        arrangecontrols(1)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        arrangecontrols(2)
    End Sub

 

    Private Sub LinkLabel11_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked
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

    Private Sub LinkLabel12_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel12.LinkClicked
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

    Private Sub LinkLabel13_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel13.LinkClicked
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

    Private Sub LinkLabel15_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel15.LinkClicked
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

    

   

    

    Private Sub LinkLabel28_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel28.LinkClicked
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

    Private Sub LinkLabel36_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel36.LinkClicked
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

    Private Sub LinkLabel32_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel32.LinkClicked
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

    Private Sub LinkLabel29_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel29.LinkClicked
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

    

    Private Sub LinkLabel33_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel33.LinkClicked
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

    Private Sub LinkLabel23_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel23.LinkClicked
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
End Class
