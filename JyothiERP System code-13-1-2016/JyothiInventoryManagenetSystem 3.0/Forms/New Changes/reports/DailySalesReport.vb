Public Class DailySalesReport

    Sub loadreport()
        Dim SqlSubstr As String = ""
        Dim rno As Integer = 0
        TxtList.Rows.Clear()
        ' SALES PART
        If TxtLocationWise.Text.Length = 0 Or TxtLocationWise.Text = "*All" Then
            SqlSubstr = ""
        Else
            SqlSubstr = "  and Storename=N'" & TxtLocationWise.Text & "'"
        End If
        rno = TxtList.Rows.Add
        TxtList.Item("tdes", rno).Value = "Sales "
        TxtList.Item("tcash", rno).Value = SQLGetNumericFieldValue("select sum(nettotal) as [Value] from StockInvoiceDetails where (VoucherName='SI' or voucherName='POS') and paymentmethod<>'Credit' and isdelete=0 and Transdatevalue=" & (CDbl(TxtStartDate.Value.Date.ToOADate)) & SqlSubstr, "Value")
        TxtList.Item("tcredit", rno).Value = SQLGetNumericFieldValue("select sum(nettotal) as [Value] from StockInvoiceDetails where (VoucherName='SI' or voucherName='POS') and paymentmethod='Credit' and isdelete=0 and Transdatevalue=" & (CDbl(TxtStartDate.Value.Date.ToOADate)) & SqlSubstr, "Value")
        TxtList.Item("ttotal", rno).Value = SQLGetNumericFieldValue("select sum(nettotal) as [Value] from StockInvoiceDetails where (VoucherName='SI' or voucherName='POS') and isdelete=0 and Transdatevalue=" & (CDbl(TxtStartDate.Value.Date.ToOADate)) & SqlSubstr, "Value")
       

        'SALES RETURNS
        rno = TxtList.Rows.Add
        TxtList.Item("tdes", rno).Value = "Sales Returns-Credit Note"
        TxtList.Item("tcash", rno).Value = SQLGetNumericFieldValue("select sum(nettotal) as [Value] from StockInvoiceDetails where VoucherName='SR' and paymentmethod<>'Credit' and isdelete=0 and Transdatevalue=" & (CDbl(TxtStartDate.Value.Date.ToOADate)) & SqlSubstr, "Value")
        TxtList.Item("tcredit", rno).Value = SQLGetNumericFieldValue("select sum(nettotal) as [Value] from StockInvoiceDetails where VoucherName='SR'  and paymentmethod='Credit' and isdelete=0 and Transdatevalue=" & (CDbl(TxtStartDate.Value.Date.ToOADate)) & SqlSubstr, "Value")
        TxtList.Item("ttotal", rno).Value = SQLGetNumericFieldValue("select sum(nettotal) as [Value] from StockInvoiceDetails where VoucherName='SR'  and isdelete=0 and Transdatevalue=" & (CDbl(TxtStartDate.Value.Date.ToOADate)) & SqlSubstr, "Value")

       
        'payments
        rno = TxtList.Rows.Add
        TxtList.Item("tdes", rno).Value = "Payments"
        TxtList.Item("tcash", rno).Value = -1 * SQLGetNumericFieldValue("Select sum(dr+cr) as [Value]  from ledgerbook where sno=1 and isdeleted=0 and InvoiceName in ('Payment','Payroll') and TransDateValue=" & (CDbl(TxtStartDate.Value.Date.ToOADate)) & SqlSubstr, "Value")
        TxtList.Item("tcredit", rno).Value = 0
        TxtList.Item("ttotal", rno).Value = -1 * SQLGetNumericFieldValue("Select sum(dr+cr) as [Value]  from ledgerbook where sno=1 and isdeleted=0 and InvoiceName in ('Payment','Payroll') and TransDateValue=" & (CDbl(TxtStartDate.Value.Date.ToOADate)) & SqlSubstr, "Value")

        'RECEIPTS
        rno = TxtList.Rows.Add
        TxtList.Item("tdes", rno).Value = "Receipts"
        TxtList.Item("tcash", rno).Value = SQLGetNumericFieldValue("Select sum(dr+cr) as [Value]  from ledgerbook where sno=1 and isdeleted=0 and InvoiceName='Receipt' and TransDateValue=" & (CDbl(TxtStartDate.Value.Date.ToOADate)) & SqlSubstr, "Value")
        TxtList.Item("tcredit", rno).Value = 0
        TxtList.Item("ttotal", rno).Value = SQLGetNumericFieldValue("Select sum(dr+cr) as [Value]  from ledgerbook where sno=1 and isdeleted=0 and InvoiceName='Receipt' and TransDateValue=" & (CDbl(TxtStartDate.Value.Date.ToOADate)) & SqlSubstr, "Value")

        'RECEIPTS
        rno = TxtList.Rows.Add
        TxtList.Item("tdes", rno).Value = "Cash Balance"
        TxtList.Item("tcash", rno).Value = SQLGetNumericFieldValue("select sum(dr-cr) as [value] from ledgerbook where isdeleted=0 and ( ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "'))) ) and TransDateValue=" & (CDbl(TxtStartDate.Value.Date.ToOADate)) & SqlSubstr, "Value")
        TxtList.Item("tcredit", rno).Value = 0
        TxtList.Item("ttotal", rno).Value = SQLGetNumericFieldValue("select sum(dr-cr) as [value] from ledgerbook where isdeleted=0 and ( ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "'))) ) and TransDateValue=" & (CDbl(TxtStartDate.Value.Date.ToOADate)) & SqlSubstr, "Value")

    End Sub
    Private Sub DailySalesReport_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadDataIntoComboBox("select locationname from StockLocations", TxtLocationWise, "locationname", "*All")
        TxtStartDate.Value = Today
        loadreport()
    End Sub

    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click
        loadreport()
    End Sub

    Private Sub TxtList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub

    Private Sub TxtList_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

   
End Class