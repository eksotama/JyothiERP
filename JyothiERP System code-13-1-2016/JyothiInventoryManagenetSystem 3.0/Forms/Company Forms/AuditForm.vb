Public Class AuditForm
    Dim IsLoading As Boolean = True
    Private Sub TxtFilterBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFilterBy.SelectedIndexChanged
        If TxtFilterBy.Text.Length = 0 Then Exit Sub
        LoadData()
    End Sub

    Private Sub TxtList_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellEnter
        If IsLoading = True Then Exit Sub
        If TxtList.Item("Status", TxtList.CurrentRow.Index).Value = "Pending" Then
            BtnUnConfirm.Enabled = False
            BtnConfirm.Enabled = True
        Else
            BtnUnConfirm.Enabled = True
            BtnConfirm.Enabled = False
        End If
    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadData()
        '*All
        'Inventory
        'Payroll
        'Vouchers
        If IsLoading = True Then Exit Sub
        If TxtFilterBy.Text.Length = 0 Then Exit Sub
        Dim SqlStr As String = ""
        If TxtFilterBy.Text = "Vouchers" Then
            SqlStr = "SELECT TransDate AS date, TransCode AS [TransCode], InvoiceNo AS [Voucher No], LedgerName AS [Account name], Dr, Cr,  (CASE n1 WHEN 1 THEN 'Confirmed' ELSE 'Pending' END) AS Status FROM LedgerBook WHERE  (IsDeleted = 0) AND (TransCode <> 0) AND (sno = 1) AND (InvoiceName IN ('Payment','Receipt','Contra','Journal','Credit Note Voucher','Debit Note Voucher','Purchase Voucher','Sales Voucher'))"
            If TxtIsPeriod.Checked = True Then
                SqlStr = SqlStr & " and isdeleted=0 and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"

            End If
            If TxtShowPendings.Checked = True Then
                SqlStr = SqlStr & " and ( n1=0 or n1 is null)"
            End If
        ElseIf TxtFilterBy.Text = "Inventory" Then
            SqlStr = "SELECT     TransDate AS Date, TransCode AS [TransCode], QutoNo AS [Invoice No], VoucherName, LedgerName AS [Account Name], (CASE WHEN (vouchername IN  ('SR' ,'PI' ,'PG','DP')) THEN nettotal ELSE 0 END) AS Dr, (CASE WHEN (vouchername IN ('SD' , 'POS', 'SI','PR')) THEN nettotal ELSE 0 END) AS Cr, (CASE n1 WHEN 1 THEN 'Confirmed' ELSE 'Pending' END) AS Status " _
                & " FROM  StockInvoiceDetails WHERE  (VoucherName IN ('PI','PG','SI','SD', 'SR','PR','POS','DP')) "

            If TxtIsPeriod.Checked = True Then
                SqlStr = SqlStr & " and isdelete=0 and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
            End If
            If TxtShowPendings.Checked = True Then
                SqlStr = SqlStr & " and (n1=0 or n1 is null)"
            End If
        ElseIf TxtFilterBy.Text = "Payroll" Then
            SqlStr = "SELECT TransDate AS date, TransCode AS [TransCode], InvoiceNo AS [Voucher No], LedgerName AS [Account name], Dr, Cr,  (CASE n1 WHEN 1 THEN 'Confirmed' ELSE 'Pending' END) AS Status FROM LedgerBook WHERE  (IsDeleted = 0) AND (TransCode <> 0) AND (sno = 1) AND (InvoiceName='PayRoll')  "
            If TxtIsPeriod.Checked = True Then
                SqlStr = SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"

            End If
            If TxtShowPendings.Checked = True Then
                SqlStr = SqlStr & " and (n1=0 or n1 is null)"
            End If

        End If
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            If TxtFilterBy.Text = "Inventory" Then
                TempBS.Filter = "VoucherName <>'SQ' AND VoucherName<>'SO' "
            End If
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("cr").Width = 110
            TxtList.Columns("cr").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("cr").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            TxtList.Columns("dr").Width = 110
            TxtList.Columns("dr").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("dr").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCLose.Click
        Me.Close()
    End Sub

    Private Sub UserButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton2.Click
        If TxtFilterBy.Text.Length = 0 Then Exit Sub
        LoadData()
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuto.Click
        Dim k As New AuditAutoConfirmDg
        If k.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If TxtFilterBy.Text = "Vouchers" Then
                ExecuteSQLQuery("Update LedgerBook set n1=1 where   isdeleted=0 and (Transdatevalue between " & (CDbl(k.TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(k.TxtEndDate.Value.Date.ToOADate)) & ")")
            ElseIf TxtFilterBy.Text = "Inventory" Then
                ExecuteSQLQuery("Update StockInvoiceDetails set n1=1 where   isdelete=0 and (Transdatevalue between " & (CDbl(k.TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(k.TxtEndDate.Value.Date.ToOADate)) & ")")
            ElseIf TxtFilterBy.Text = "Payroll" Then
                ExecuteSQLQuery("Update LedgerBook set n1=1 where   isdeleted=0 and (Transdatevalue between " & (CDbl(k.TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(k.TxtEndDate.Value.Date.ToOADate)) & ")")
            End If
            LoadData()
        End If
        k.Dispose()
    End Sub

    Private Sub AuditForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub AuditForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        TxtFilterBy.Text = "Inventory"
        IsLoading = False
        LoadData()
    End Sub

    Private Sub TxtList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub

    Private Sub TxtList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtList.Click
      
    End Sub

    Private Sub BtnUnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnConfirm.Click
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If MsgBox("Do you want to UnConfirm The selected Rows...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            For Each x As DataGridViewRow In TxtList.SelectedRows
                If TxtFilterBy.Text = "Vouchers" Or TxtFilterBy.Text = "Payroll" Then
                    ExecuteSQLQuery("Update LedgerBook set n1=0 where transcode=" & TxtList.Item("Transcode", x.Index).Value)
                ElseIf TxtFilterBy.Text = "Inventory" Then
                    ExecuteSQLQuery("Update StockInvoiceDetails set n1=0 where  transcode=" & TxtList.Item("Transcode", x.Index).Value)

                End If
            Next
            LoadData()
        End If
    End Sub

    Private Sub TxtShowPendings_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShowPendings.CheckedChanged
        If TxtShowPendings.Checked = True Then
            BtnUnConfirm.Enabled = False
        Else
            BtnUnConfirm.Enabled = True
        End If
        LoadData()
    End Sub

    Private Sub BtnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConfirm.Click
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If MsgBox("Do you want to Confirm The selected Rows...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            For Each x As DataGridViewRow In TxtList.SelectedRows
                If TxtFilterBy.Text = "Vouchers" Then
                    ExecuteSQLQuery("Update LedgerBook set n1=1 where transcode=" & TxtList.Item("Transcode", x.Index).Value)
                ElseIf TxtFilterBy.Text = "Inventory" Then
                    ExecuteSQLQuery("Update StockInvoiceDetails set n1=1 where  transcode=" & TxtList.Item("Transcode", x.Index).Value)
                ElseIf TxtFilterBy.Text = "Payroll" Then

                    ' MsgBox("PEnding...")
                    ExecuteSQLQuery("Update LedgerBook set n1=1 where transcode=" & TxtList.Item("Transcode", x.Index).Value)
                End If
            Next
            LoadData()
        End If
    End Sub

    
End Class