Public Class RecycleBin
    Dim SQlStr As String = ""
    Private Sub ImsComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFoldertype.SelectedIndexChanged
      
        loadData()
    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub loadData()
        SQlStr = ""
        If TxtFoldertype.Text = "Vouchers" Then
            If TxtIsPeriod.Checked = True Then
                SQlStr = "Select InvoiceName as [Voucher Name], InvoiceName as [Vouchername], Transdate as [Date],TransCode as [Trans Code],InvoiceNo as [Voucher No],ledgername as [Account Name],(dr+cr) as [Value] from ledgerbook where sno=1 and isdeleted=1 and  (TransDateValue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") order by InvoiceNo"
            Else
                SQlStr = "Select InvoiceName as [Voucher Name], InvoiceName as [Vouchername], Transdate as [Date],TransCode as [Trans Code],InvoiceNo as [Voucher No],ledgername as [Account Name],(dr+cr) as [Value] from ledgerbook where sno=1 and isdeleted=1 "
            End If
        ElseIf TxtFoldertype.Text = "Inventory Invoices" Then
            If TxtIsPeriod.Checked = True Then
                SQlStr = "select vouchername as [Voucher Name],vouchername as [VoucherName], transdate as [Date],TransCode as [Trans Code],qutono as [Invoice No],qutoref as [Ref No] ,ledgername as [Account Name],nettotal as [Value] from StockInvoiceDetails where  isdelete=1 and  (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")"
            Else
                SQlStr = "select vouchername as [Voucher Name],vouchername as [VoucherName], transdate as [Date],TransCode as [Trans Code],qutono as [Invoice No],qutoref as [Ref No] ,ledgername as [Account Name],nettotal as [Value] from StockInvoiceDetails where  isdelete=1 "
            End If
            'ElseIf TxtFoldertype.Text = "Account Vouchers" Then
            '    If TxtIsPeriod.Checked = True Then
            '        SQlStr = "Select InvoiceName as [Voucher Name], InvoiceName as [Vouchername], Transdate as [Date],TransCode as [Trans Code],InvoiceNo as [Voucher No],ledgername as [Account Name],(dr+cr) as [Value] from ledgerbook where sno=1 and isdeleted=1 and  (TransDateValue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") order by InvoiceNo"
            '    Else
            '        SQlStr = "Select InvoiceName as [Voucher Name], InvoiceName as [Vouchername], Transdate as [Date],TransCode as [Trans Code],InvoiceNo as [Voucher No],ledgername as [Account Name],(dr+cr) as [Value] from ledgerbook where sno=1 and isdeleted=1 "
            '    End If
        End If
        If SQlStr.Length = 0 Then Exit Sub
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SQlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("VoucherName").Visible = False
            TxtList.Columns("value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
        Catch ex As Exception

        End Try
        For i As Integer = 0 To TxtList.RowCount - 1
            If TxtList.Item("voucher name", i).Value = "SO" Then
                TxtList.Item("voucher name", i).Value = "Sales Order"
            ElseIf TxtList.Item("voucher name", i).Value = "SQ" Then
                TxtList.Item("voucher name", i).Value = "Sales Quote"
            ElseIf TxtList.Item("voucher name", i).Value = "SI" Then
                TxtList.Item("voucher name", i).Value = "Sales Invoice"
            ElseIf TxtList.Item("voucher name", i).Value = "SR" Then
                TxtList.Item("voucher name", i).Value = "Sales Returns"
            ElseIf TxtList.Item("voucher name", i).Value = "SD" Then
                TxtList.Item("voucher name", i).Value = "Delivery Note"
            ElseIf TxtList.Item("voucher name", i).Value = "POS" Then
                TxtList.Item("voucher name", i).Value = "Sales Invoice"
            ElseIf TxtList.Item("voucher name", i).Value = "PO" Then
                TxtList.Item("voucher name", i).Value = "Purchase Order"
            ElseIf TxtList.Item("voucher name", i).Value = "PI" Or TxtList.Item("voucher name", i).Value = "DP" Then
                TxtList.Item("voucher name", i).Value = "Purchase Invoice"
            ElseIf TxtList.Item("voucher name", i).Value = "PG" Then

                TxtList.Item("voucher name", i).Value = "Goods Receipts"
            ElseIf TxtList.Item("voucher name", i).Value = "PR" Then
                TxtList.Item("voucher name", i).Value = "Purchase Returns"
            ElseIf TxtList.Item("voucher name", i).Value = "PQ" Then
                TxtList.Item("voucher name", i).Value = "Purchase Quote"
         
            End If
        Next
    End Sub

    Private Sub RecycleBin_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub RecycleBin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = Today.Date.AddMonths(-5)
        TxtEndDate.Value = Today.Date
        TxtFoldertype.Text = "Inventory Invoices"
        loadData()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Me.Close()
    End Sub

    Private Sub UserButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton2.Click
        loadData()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If MsgBox(" Are you sure do you want to delete the selected Entry ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            If TxtFoldertype.Text = "Vouchers" Then
                ExecuteSQLQuery("delete from ledgerbook where transcode=" & TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value)
            ElseIf TxtFoldertype.Text = "Inventory Invoices" Then
                ExecuteSQLQuery("delete from  StockInvoiceDetails where TransCode=" & TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value)
                ExecuteSQLQuery("delete from  StockInvoiceRowItems where TransCode=" & TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value)
                ExecuteSQLQuery("delete from VoucherAccounts where transcode=" & TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value)
                ExecuteSQLQuery("delete from InvoiceMoreDet where transcode=" & TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value)
            ElseIf TxtFoldertype.Text = "Account Vouchers" Then
                ExecuteSQLQuery("delete from ledgerbook where transcode=" & TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value)
            End If
            loadData()
        End If
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If MsgBox(" Are you sure do you want to Restore the selected Entry ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            If TxtFoldertype.Text = "Vouchers" Then
                ExecuteSQLQuery("update  ledgerbook set   isdeleted=0 where transcode=" & TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value)
            ElseIf TxtFoldertype.Text = "Inventory Invoices" Then
                ' ExecuteSQLQuery("update StockInvoiceDetails set isdelete=0 where TransCode=" & TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value)
                ' ExecuteSQLQuery("update   StockInvoiceRowItems  set isdelete=0 where TransCode=" & TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value)


                If TxtList.Item("vouchername", TxtList.CurrentRow.Index).Value = "SI" Then
                    Dim frm As New InvoiceAlterForm
                    frm.TxtTitle.Text = "ALTER SALES INVOICE "
                    Dim K As New SalesControlAll("SI", TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value)
                    K.BtnNew.Enabled = False
                    K.BtnOpen.Enabled = False
                    frm.TxtList.Controls.Add(K)
                    frm.TxtList.Controls(0).Dock = DockStyle.Fill
                    frm.WindowState = FormWindowState.Maximized
                    frm.ShowDialog()
                    frm.Dispose()

                    K.Dispose()
                ElseIf TxtList.Item("vouchername", TxtList.CurrentRow.Index).Value = "SD" Then
                    Dim frm As New InvoiceAlterForm
                    frm.TxtTitle.Text = "ALTER SALES DELIVERY NOTE "
                    Dim K As New SalesControlAll("SD", TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value)
                    K.BtnNew.Enabled = False
                    K.BtnOpen.Enabled = False
                    frm.TxtList.Controls.Add(K)
                    frm.TxtList.Controls(0).Dock = DockStyle.Fill
                    frm.WindowState = FormWindowState.Maximized
                    frm.ShowDialog()
                    frm.Dispose()

                    K.Dispose()
                ElseIf TxtList.Item("vouchername", TxtList.CurrentRow.Index).Value = "SR" Then
                    Dim frm As New InvoiceAlterForm
                    frm.TxtTitle.Text = "ALTER SALES RETURNS (DEBIT NOTE) "
                    Dim K As New SalesControlAll("SR", TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value)
                    K.BtnNew.Enabled = False
                    K.BtnOpen.Enabled = False
                    frm.TxtList.Controls.Add(K)
                    frm.TxtList.Controls(0).Dock = DockStyle.Fill
                    frm.WindowState = FormWindowState.Maximized
                    frm.ShowDialog()
                    frm.Dispose()

                    K.Dispose()
                ElseIf TxtList.Item("vouchername", TxtList.CurrentRow.Index).Value = "POS" Then
                    Dim frm As New InvoiceAlterForm
                    frm.TxtTitle.Text = "ALTER SALES POS"
                    Dim K As New SalesControlAll("POS", TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value)
                    K.BtnNew.Enabled = False
                    K.BtnOpen.Enabled = False
                    frm.TxtList.Controls.Add(K)
                    frm.TxtList.Controls(0).Dock = DockStyle.Fill
                    frm.WindowState = FormWindowState.Maximized
                    frm.ShowDialog()
                    frm.Dispose()

                    K.Dispose()
                ElseIf TxtList.Item("vouchername", TxtList.CurrentRow.Index).Value = "PI" Then
                    Dim frm As New InvoiceAlterForm
                    frm.TxtTitle.Text = "ALTER PURCHASE INVOICE "
                    Dim K As New PurchaseControlAll("PI", TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value)
                    K.BtnNew.Enabled = False
                    K.BtnOpen.Enabled = False
                    frm.TxtList.Controls.Add(K)
                    frm.TxtList.Controls(0).Dock = DockStyle.Fill
                    frm.WindowState = FormWindowState.Maximized
                    frm.ShowDialog()
                    frm.Dispose()

                    K.Dispose()
                ElseIf TxtList.Item("vouchername", TxtList.CurrentRow.Index).Value = "DP" Then
                    Dim frm As New InvoiceAlterForm
                    frm.TxtTitle.Text = "ALTER PURCHASE INVOICE "
                    Dim K As New PurchaseControlAll("DP", TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value)
                    K.BtnNew.Enabled = False
                    K.BtnOpen.Enabled = False
                    frm.TxtList.Controls.Add(K)
                    frm.TxtList.Controls(0).Dock = DockStyle.Fill
                    frm.WindowState = FormWindowState.Maximized
                    frm.ShowDialog()
                    frm.Dispose()

                    K.Dispose()
                ElseIf TxtList.Item("vouchername", TxtList.CurrentRow.Index).Value = "PG" Then
                    Dim frm As New InvoiceAlterForm
                    frm.TxtTitle.Text = "ALTER PURCHASE GOODS RECEIPTS "
                    Dim K As New PurchaseControlAll("PG", TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value)
                    K.BtnNew.Enabled = False
                    K.BtnOpen.Enabled = False

                    frm.TxtList.Controls.Add(K)
                    frm.TxtList.Controls(0).Dock = DockStyle.Fill
                    frm.WindowState = FormWindowState.Maximized
                    frm.ShowDialog()
                    frm.Dispose()

                    K.Dispose()
                ElseIf TxtList.Item("vouchername", TxtList.CurrentRow.Index).Value = "PR" Then
                    Dim frm As New InvoiceAlterForm
                    frm.TxtTitle.Text = "ALTER PURCHASE RETURNS (CREDIT NOTE) "
                    Dim K As New PurchaseControlAll("PR", TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value)
                    K.BtnNew.Enabled = False
                    K.BtnOpen.Enabled = False
                    frm.TxtList.Controls.Add(K)
                    frm.TxtList.Controls(0).Dock = DockStyle.Fill
                    frm.WindowState = FormWindowState.Maximized
                    frm.ShowDialog()
                    frm.Dispose()

                    K.Dispose()
                End If


            ElseIf TxtFoldertype.Text = "Account Vouchers" Then
                ExecuteSQLQuery("update  ledgerbook set   isdeleted=0 where transcode=" & TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value)
            End If
        loadData()
        End If
    End Sub
End Class