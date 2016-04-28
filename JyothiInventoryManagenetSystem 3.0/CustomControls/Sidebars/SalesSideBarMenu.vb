Public Class SalesSideBarMenu

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

    

    Private Sub LinkLabel6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        SalesPersons.SuspendLayout()
        SalesPersons.MdiParent = MainForm
        SalesPersons.Dock = DockStyle.Fill
        SalesPersons.Show()
        SalesPersons.WindowState = FormWindowState.Maximized
        SalesPersons.BringToFront()
        SalesPersons.ResumeLayout()
        Me.Cursor = Cursors.Default
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

   
    Private Sub LinkLabel12_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel12.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesInvoiceFormSR Is Nothing OrElse SalesInvoiceFormSR.IsDisposed Then
            SalesInvoiceFormSR = New SalesInvoiceAllFormControl("SR")
            SalesInvoiceFormSR.MdiParent = MainForm
            SalesInvoiceFormSR.BringToFront()
            SalesInvoiceFormSR.Dock = DockStyle.Fill
            SalesInvoiceFormSR.Show()
            SalesInvoiceFormSR.WindowState = FormWindowState.Maximized
        Else
            SalesInvoiceFormSR.MdiParent = MainForm
            SalesInvoiceFormSR.Dock = DockStyle.Fill
            SalesInvoiceFormSR.Show()
            SalesInvoiceFormSR.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesInvoiceFormPOS Is Nothing OrElse SalesInvoiceFormPOS.IsDisposed Then

            SalesInvoiceFormPOS = New SalesInvoiceAllFormControl("POS")
            SalesInvoiceFormPOS.MdiParent = MainForm
            SalesInvoiceFormPOS.BringToFront()
            SalesInvoiceFormPOS.Dock = DockStyle.Fill
            SalesInvoiceFormPOS.Show()
            SalesInvoiceFormPOS.WindowState = FormWindowState.Maximized
        Else
            SalesInvoiceFormPOS.MdiParent = MainForm
            SalesInvoiceFormPOS.Dock = DockStyle.Fill
            SalesInvoiceFormPOS.Show()
            SalesInvoiceFormPOS.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub LinkLabel7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        OrderSummeryForm.SuspendLayout()
        OrderSummeryForm.MdiParent = MainForm
        OrderSummeryForm.Dock = DockStyle.Fill
        OrderSummeryForm.Show()
        OrderSummeryForm.WindowState = FormWindowState.Maximized
        OrderSummeryForm.BringToFront()
        OrderSummeryForm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesSOReportForm Is Nothing OrElse SalesSOReportForm.IsDisposed Then
            SalesSOReportForm = New SalesTransactionReports("SO")
            SalesSOReportForm.MdiParent = MainForm
            SalesSOReportForm.BringToFront()
            SalesSOReportForm.Dock = DockStyle.Fill
            SalesSOReportForm.Show()
            SalesSOReportForm.WindowState = FormWindowState.Maximized
        Else
            SalesSOReportForm.MdiParent = MainForm
            SalesSOReportForm.Dock = DockStyle.Fill
            SalesSOReportForm.Show()
            SalesSOReportForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
