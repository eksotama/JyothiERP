Public Class DashBoard
    Dim TXTSTARTDATE As New DateTimePicker
    Dim TXTENDDATE As New DateTimePicker
    Dim TSqlstr As String = ""
    Sub LOADRECEIPTS()


        Dim sqlstr As String = ""
        'sqlstr = "Select ledgername + ' <-> ' + AcLedger AS [Details],dr+cr as [Value]  from ledgerbook where sno=1 and isdeleted=0 and InvoiceName='Receipt' and (TransDateValue between " & (CDbl(TXTSTARTDATE.Value.Date.ToOADate)) & " and " & (CDbl(TXTENDDATE.Value.Date.ToOADate)) & ") order by InvoiceNo"
        sqlstr = "Select transcode,invoicename as [Voucher Name], ledgername + ' <-> ' + AcLedger AS [Details],dr+cr as [Value]  from ledgerbook where sno=1 and isdeleted=0 and InvoiceName='Receipt' and TransDateValue=" & (CDbl(Today.Date.ToOADate)) & " order by InvoiceNo"
        TSqlstr = "Select sum(dr+cr) as [Value]  from ledgerbook where sno=1 and isdeleted=0 and InvoiceName='Receipt' and TransDateValue=" & (CDbl(Today.Date.ToOADate))
        Dim TempBS As New BindingSource
        With Me.TXTRECEIPTS
            TempBS.DataSource = SQLLoadGridData(sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            TXTRECEIPTS.Columns("transcode").Visible = False
            TXTRECEIPTS.Columns("Voucher Name").Visible = False
            TXTRECEIPTS.Columns("Details").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TXTRECEIPTS.Columns("Details").Width = 90

            TXTRECEIPTS.Columns("Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TXTRECEIPTS.Columns("Value").Width = 90
            TXTRECEIPTS.Columns("Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TXTRECEIPTS.Columns("Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception

        End Try

        txttodayrectotal.Text = FormatNumber(SQLGetNumericFieldValue(TSqlstr, "value"), ErpDecimalPlaces)
    End Sub
    Sub LOADPAYMENTS()


        Dim sqlstr As String = ""
        'sqlstr = "Select ledgername + ' <-> ' + AcLedger AS [Details],dr+cr as [Value]  from ledgerbook where sno=1 and isdeleted=0 and InvoiceName='Receipt' and (TransDateValue between " & (CDbl(TXTSTARTDATE.Value.Date.ToOADate)) & " and " & (CDbl(TXTENDDATE.Value.Date.ToOADate)) & ") order by InvoiceNo"
        sqlstr = "Select transcode,invoicename as [Voucher Name], ledgername + ' <-> ' + AcLedger AS [Details],dr+cr as [Value]  from ledgerbook where sno=1 and isdeleted=0 and InvoiceName in ('Payment','Payroll') and TransDateValue=" & (CDbl(Today.Date.ToOADate)) & " order by InvoiceNo"
        TSqlstr = "Select sum(dr+cr) as [Value]  from ledgerbook where sno=1 and isdeleted=0 and InvoiceName in ('Payment','Payroll') and TransDateValue=" & (CDbl(Today.Date.ToOADate))
        Dim TempBS As New BindingSource
        With Me.TXTPAYMENT
            TempBS.DataSource = SQLLoadGridData(sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            TXTPAYMENT.Columns("transcode").Visible = False
            TXTPAYMENT.Columns("Voucher Name").Visible = False
            TXTPAYMENT.Columns("Details").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TXTPAYMENT.Columns("Details").Width = 90

            TXTPAYMENT.Columns("Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TXTPAYMENT.Columns("Value").Width = 90
            TXTPAYMENT.Columns("Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TXTPAYMENT.Columns("Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception

        End Try

        txttodaypaytotal.Text = FormatNumber(SQLGetNumericFieldValue(TSqlstr, "value"), ErpDecimalPlaces)
    End Sub
    Sub lOADTODAYSALES()


        Dim sqlstr As String = ""

        sqlstr = "select transcode,vouchername as [Voucher Name], LedgerName as [Details],nettotal as  [Value] from StockInvoiceDetails where (VoucherName='SI' or voucherName='POS') and isdelete=0 and TransDateValue=" & (CDbl(Today.Date.ToOADate))
        TSqlstr = "Select sum(nettotal) as [Value]  from StockInvoiceDetails where (VoucherName='SI' or voucherName='POS') and isdelete=0 and TransDateValue=" & (CDbl(Today.Date.ToOADate))

        Dim TempBS As New BindingSource
        With Me.TXTSALES
            TempBS.DataSource = SQLLoadGridData(sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            TXTSALES.Columns("transcode").Visible = False
            TXTSALES.Columns("Voucher Name").Visible = False
            TXTSALES.Columns("Details").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TXTSALES.Columns("Details").Width = 90

            TXTSALES.Columns("Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TXTSALES.Columns("Value").Width = 90
            TXTSALES.Columns("Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TXTSALES.Columns("Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception

        End Try
        txttodaysalestotal.Text = FormatNumber(SQLGetNumericFieldValue(TSqlstr, "value"), ErpDecimalPlaces)
    End Sub
    Sub lOADMSALES()



        Dim sqlstr As String = ""

        sqlstr = "select  transcode,vouchername as [Voucher Name] ,TransDate AS [Date], LedgerName as [Details],nettotal as [Value] from StockInvoiceDetails where (VoucherName='SI' or voucherName='POS') and isdelete=0 and (Transdatevalue between " & (CDbl(TXTSTARTDATE.Value.Date.ToOADate)) & " and " & (CDbl(TXTENDDATE.Value.Date.ToOADate)) & ") "
        TSqlstr = "select sum(nettotal) as [Value] from StockInvoiceDetails where (VoucherName='SI' or voucherName='POS') and isdelete=0 and (Transdatevalue between " & (CDbl(TXTSTARTDATE.Value.Date.ToOADate)) & " and " & (CDbl(TXTENDDATE.Value.Date.ToOADate)) & ") "
        Dim TempBS As New BindingSource
        With Me.TXTMSALES
            TempBS.DataSource = SQLLoadGridData(sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            TXTMSALES.Columns("transcode").Visible = False
            TXTMSALES.Columns("Voucher Name").Visible = False

            TXTMSALES.Columns("Details").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TXTMSALES.Columns("Details").Width = 90

            TXTMSALES.Columns("Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TXTMSALES.Columns("Value").Width = 90
            TXTMSALES.Columns("Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TXTMSALES.Columns("Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TXTMSALES.Columns("Date").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TXTMSALES.Columns("Date").Width = 55
            TXTMSALES.Columns("Date").DefaultCellStyle.Format = "d"

        Catch ex As Exception

        End Try
        txtsalestotal.Text = FormatNumber(SQLGetNumericFieldValue(TSqlstr, "value"), ErpDecimalPlaces)
    End Sub
    Sub lOADMpurchase()



        Dim sqlstr As String = ""

        sqlstr = "select  transcode,vouchername as [Voucher Name],TransDate AS [Date], LedgerName as [Details],nettotal as [Value] from StockInvoiceDetails where VoucherName IN ('PI','DP') and isdelete=0 and (Transdatevalue between " & (CDbl(TXTSTARTDATE.Value.Date.ToOADate)) & " and " & (CDbl(TXTENDDATE.Value.Date.ToOADate)) & ") "
        TSqlstr = "select sum(nettotal) as  [Value] from StockInvoiceDetails where VoucherName IN ('PI','DP') and isdelete=0 and (Transdatevalue between " & (CDbl(TXTSTARTDATE.Value.Date.ToOADate)) & " and " & (CDbl(TXTENDDATE.Value.Date.ToOADate)) & ") "
        Dim TempBS As New BindingSource
        With Me.TXTPURCHASE
            TempBS.DataSource = SQLLoadGridData(sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            TXTPURCHASE.Columns("transcode").Visible = False
            TXTPURCHASE.Columns("Voucher Name").Visible = False

            TXTPURCHASE.Columns("Details").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TXTPURCHASE.Columns("Details").Width = 90

            TXTPURCHASE.Columns("Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TXTPURCHASE.Columns("Value").Width = 90
            TXTPURCHASE.Columns("Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TXTPURCHASE.Columns("Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TXTPURCHASE.Columns("Date").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TXTPURCHASE.Columns("Date").Width = 55
            TXTPURCHASE.Columns("Date").DefaultCellStyle.Format = "d"
        Catch ex As Exception

        End Try
        txtpurtotal.Text = FormatNumber(SQLGetNumericFieldValue(TSqlstr, "value"), ErpDecimalPlaces)
    End Sub
    'SqlStr = "SELECT transdate as [Date],acledger as [Details], invoiceno as [Voucher No],invoicename as [Voucher Name],dr as [DR], cr as [CR] from ledgerbook where isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "'"
    Sub loadCashAccount()

        '  TXTCASHFLOW.Rows.Clear()

        Dim sqlstr As String = ""

        sqlstr = "select transcode,invoicename as [Voucher Name],TransDate AS [Date], acledger as [Details],dr as [DR], cr as [CR] from ledgerbook where isdeleted=0 and ( ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "'))) )  and (Transdatevalue between " & (CDbl(TXTSTARTDATE.Value.Date.ToOADate)) & " and " & (CDbl(TXTENDDATE.Value.Date.ToOADate)) & ") "
        TSqlstr = "select sum(dr-cr) as [value] from ledgerbook where isdeleted=0 and ( ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "'))) )  and (Transdatevalue between " & (CDbl(TXTSTARTDATE.Value.Date.ToOADate)) & " and " & (CDbl(TXTENDDATE.Value.Date.ToOADate)) & ") "
        Dim TempBS As New BindingSource
        With Me.TXTCASHFLOW
            TempBS.DataSource = SQLLoadGridData(sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            TXTCASHFLOW.Columns("transcode").Visible = False
            TXTCASHFLOW.Columns("Voucher Name").Visible = False

            TXTCASHFLOW.Columns("Details").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TXTCASHFLOW.Columns("Details").Width = 90

            TXTCASHFLOW.Columns("dr").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TXTCASHFLOW.Columns("dr").Width = 90
            TXTCASHFLOW.Columns("dr").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TXTCASHFLOW.Columns("dr").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TXTCASHFLOW.Columns("cr").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TXTCASHFLOW.Columns("cr").Width = 90
            TXTCASHFLOW.Columns("cr").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TXTCASHFLOW.Columns("cr").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TXTCASHFLOW.Columns("Date").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TXTCASHFLOW.Columns("Date").Width = 55
            TXTCASHFLOW.Columns("Date").DefaultCellStyle.Format = "d"
        Catch ex As Exception

        End Try
        Dim tot As Double = 0
        tot = SQLGetNumericFieldValue(TSqlstr, "value")
        txtcashflowtotal.Text = IIf(tot >= 0, "Dr " & FormatNumber(tot, ErpDecimalPlaces), "Cr " & FormatNumber(tot * -1, ErpDecimalPlaces))
    End Sub

    Private Sub DashBoard_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub DashBoard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TXTSTARTDATE.Value = Today.AddDays(-7)
        TXTENDDATE.Value = Today
        SalesTitle.Text = "LAST WEEK SALES"
        purchasetitle.Text = "LAST WEEK PURCHASE"
        CashTitle.Text = "LAST WEEK CASH FLOW"
        LoadAllData()
       

    End Sub
    Sub LoadAllData()
        loadCashAccount()
        LOADRECEIPTS()
        LOADPAYMENTS()
        lOADTODAYSALES()
        lOADMpurchase()
        lOADMSALES()
    End Sub
    Private Sub ShowWeeklyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowWeeklyToolStripMenuItem.Click
        TXTSTARTDATE.Value = Today.AddDays(-7)
        TXTENDDATE.Value = Today
        SalesTitle.Text = "LAST WEEK SALES"
        purchasetitle.Text = "LAST WEEK PURCHASE"
        CashTitle.Text = "LAST WEEK CASH FLOW"
        LoadAllData()
    End Sub

    Private Sub ShowMonthlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowMonthlyToolStripMenuItem.Click
        SalesTitle.Text = "THIS MONTH SALES"
        purchasetitle.Text = "THIS MONTH PURCHASE"
        CashTitle.Text = "THIS MONTH CASH FLOW"
        TXTSTARTDATE.Value = New Date(Today.Year, Today.Month, 1)
        TXTENDDATE.Value = New Date(Today.Year, Today.Month, Date.DaysInMonth(Today.Year, Today.Month))
        LoadAllData()
    End Sub

    Private Sub ShowForniteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowForniteToolStripMenuItem.Click
        TXTSTARTDATE.Value = Today.AddDays(-15)
        TXTENDDATE.Value = Today
        SalesTitle.Text = "LAST 15 DAYS SALES"
        purchasetitle.Text = "LAST 15 DAYS PURCHASE"
        CashTitle.Text = "LAST 15 DAYS CASH FLOW"
        LoadAllData()
    End Sub

    Private Sub ShowLast30DaysToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowLast30DaysToolStripMenuItem.Click
        TXTSTARTDATE.Value = Today.AddDays(-30)
        TXTENDDATE.Value = Today
        SalesTitle.Text = "LAST 30 DAYS SALES"
        purchasetitle.Text = "LAST 30 DAYS PURCHASE"
        CashTitle.Text = "LAST 30 DAYS CASH FLOW"
        LoadAllData()
    End Sub

    Private Sub ShowLastMonthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowLastMonthToolStripMenuItem.Click
        Dim td As New DateTimePicker
        td.Value = Today.AddMonths(-1)
        TXTSTARTDATE.Value = New Date(td.Value.Year, td.Value.Month, 1)
        TXTENDDATE.Value = New Date(td.Value.Year, td.Value.Month, Date.DaysInMonth(td.Value.Year, td.Value.Month))
        SalesTitle.Text = "LAST MONTH SALES"
        purchasetitle.Text = "LAST MONTH PURCHASE"
        CashTitle.Text = "LAST MONTH CASH FLOW"
        LoadAllData()
    End Sub

    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        LoadAllData()

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub TXTRECEIPTS_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TXTRECEIPTS.CellContentClick

    End Sub

    Private Sub TXTRECEIPTS_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TXTRECEIPTS.CellDoubleClick
        Dim VoucherNameValue As String = TXTRECEIPTS.Item("Voucher Name", TXTRECEIPTS.CurrentRow.Index).Value
        Dim Transcodevalue As Double = TXTRECEIPTS.Item("transcode", TXTRECEIPTS.CurrentRow.Index).Value
        If Transcodevalue <= 0 Then
            MsgBox("Voucher Not Found,It may be Opening Account Balance ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If VoucherNameValue = "Receipt" Then
            If MyAppSettings.AllowSingleEntryMode = True Then
                Dim frm As New SingleEntryVoucherForm("Receipt", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()
            Else
                Dim frm As New VoucherEntryForm("Receipt", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()

            End If
            LoadAllData()
        End If
    End Sub

    Private Sub TXTPAYMENT_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TXTPAYMENT.CellContentClick

    End Sub

    Private Sub TXTPAYMENT_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TXTPAYMENT.CellDoubleClick
        Dim VoucherNameValue As String = TXTPAYMENT.Item("Voucher Name", TXTPAYMENT.CurrentRow.Index).Value
        Dim Transcodevalue As Double = TXTPAYMENT.Item("transcode", TXTPAYMENT.CurrentRow.Index).Value
        If Transcodevalue <= 0 Then
            MsgBox("Voucher Not Found,It may be Opening Account Balance ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If VoucherNameValue = "Payment" Then
            If MyAppSettings.AllowSingleEntryMode = True Then
                Dim frm As New SingleEntryVoucherForm("Payment", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()
            Else
                Dim frm As New VoucherEntryForm("Payment", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()

            End If
            LoadAllData()
            
        End If
    End Sub

    Private Sub TXTSALES_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TXTSALES.CellContentClick

    End Sub

    Private Sub TXTSALES_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TXTSALES.CellDoubleClick
        Dim VoucherNameValue As String = TXTSALES.Item("Voucher Name", TXTSALES.CurrentRow.Index).Value
        Dim Transcodevalue As Double = TXTSALES.Item("transcode", TXTSALES.CurrentRow.Index).Value
        If Transcodevalue <= 0 Then
            MsgBox("Voucher Not Found,It may be Opening Account Balance ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If VoucherNameValue = "SalesInvoice" Then
            Dim frm As New InvoiceAlterForm
            frm.TxtTitle.Text = "ALTER SALES INVOICE"
            Dim K As New SalesControlAll("SI", Transcodevalue, SQLGetStringFieldValue("SELECT transtype FROM StockInvoiceDetails WHERE TRANSCODE=" & Transcodevalue, "transtype"))
            K.BtnNew.Enabled = False
            K.BtnOpen.Enabled = False
            frm.TxtList.Controls.Add(K)
            frm.TxtList.Controls(0).Dock = DockStyle.Fill
            frm.WindowState = FormWindowState.Maximized
            frm.ShowDialog()
            frm.Dispose()
            K.Dispose()
           
            LoadAllData()
            
        ElseIf VoucherNameValue = "POS" Then
            Dim frm As New InvoiceAlterForm
            frm.TxtTitle.Text = "ALTER POS INVOICE"
            Dim K As New SalesControlAll("POS", Transcodevalue, SQLGetStringFieldValue("SELECT transtype FROM StockInvoiceDetails WHERE TRANSCODE=" & Transcodevalue, "transtype"))
            K.BtnNew.Enabled = False
            K.BtnOpen.Enabled = False
            frm.TxtList.Controls.Add(K)
            frm.TxtList.Controls(0).Dock = DockStyle.Fill
            frm.WindowState = FormWindowState.Maximized
            frm.ShowDialog()
            frm.Dispose()
            K.Dispose()
            LoadAllData()
           
        End If
    End Sub

    Private Sub TXTMSALES_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TXTMSALES.CellContentClick

    End Sub

    Private Sub TXTMSALES_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TXTMSALES.CellDoubleClick
        Dim VoucherNameValue As String = TXTMSALES.Item("Voucher Name", TXTMSALES.CurrentRow.Index).Value
        Dim Transcodevalue As Double = TXTMSALES.Item("transcode", TXTMSALES.CurrentRow.Index).Value
        If Transcodevalue <= 0 Then
            MsgBox("Voucher Not Found,It may be Opening Account Balance ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If VoucherNameValue = "SalesInvoice" Then
            Dim frm As New InvoiceAlterForm
            frm.TxtTitle.Text = "ALTER SALES INVOICE"
            Dim K As New SalesControlAll("SI", Transcodevalue, SQLGetStringFieldValue("SELECT transtype FROM StockInvoiceDetails WHERE TRANSCODE=" & Transcodevalue, "transtype"))
            K.BtnNew.Enabled = False
            K.BtnOpen.Enabled = False
            frm.TxtList.Controls.Add(K)
            frm.TxtList.Controls(0).Dock = DockStyle.Fill
            frm.WindowState = FormWindowState.Maximized
            frm.ShowDialog()
            frm.Dispose()
            K.Dispose()
            
            LoadAllData()
        ElseIf VoucherNameValue = "POS" Then
            Dim frm As New InvoiceAlterForm
            frm.TxtTitle.Text = "ALTER POS INVOICE"
            Dim K As New SalesControlAll("POS", Transcodevalue, SQLGetStringFieldValue("SELECT transtype FROM StockInvoiceDetails WHERE TRANSCODE=" & Transcodevalue, "transtype"))
            K.BtnNew.Enabled = False
            K.BtnOpen.Enabled = False
            frm.TxtList.Controls.Add(K)
            frm.TxtList.Controls(0).Dock = DockStyle.Fill
            frm.WindowState = FormWindowState.Maximized
            frm.ShowDialog()
            frm.Dispose()
            K.Dispose()
           
            LoadAllData()
        End If
    End Sub

    Private Sub TXTPURCHASE_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TXTPURCHASE.CellContentClick
       
    End Sub

    Private Sub TXTCASHFLOW_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TXTCASHFLOW.CellContentClick
       
      
    End Sub

    Private Sub TXTPURCHASE_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TXTPURCHASE.CellDoubleClick
        Dim VoucherNameValue As String = TXTPURCHASE.Item("Voucher Name", TXTPURCHASE.CurrentRow.Index).Value
        Dim Transcodevalue As Double = TXTPURCHASE.Item("transcode", TXTPURCHASE.CurrentRow.Index).Value
        If Transcodevalue <= 0 Then
            MsgBox("Voucher Not Found,It may be Opening Account Balance ", MsgBoxStyle.Information)
            Exit Sub
        End If

        If VoucherNameValue = "PurchaseInvoice" Then
            Dim frm As New InvoiceAlterForm
            frm.TxtTitle.Text = "ALTER PURCHASE INVOICE "
            Dim K As New PurchaseControlAll("PI", Transcodevalue, SQLGetStringFieldValue("SELECT transtype FROM StockInvoiceDetails WHERE TRANSCODE=" & Transcodevalue, "transtype"))
            K.BtnNew.Enabled = False
            K.BtnOpen.Enabled = False
            frm.TxtList.Controls.Add(K)
            frm.TxtList.Controls(0).Dock = DockStyle.Fill
            frm.WindowState = FormWindowState.Maximized
            frm.ShowDialog()
            frm.Dispose()
            K.Dispose()

            LoadAllData()

        End If
    End Sub

    Private Sub TXTCASHFLOW_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TXTCASHFLOW.CellDoubleClick
        Dim VoucherNameValue As String = TXTCASHFLOW.Item("Voucher Name", TXTCASHFLOW.CurrentRow.Index).Value
        Dim Transcodevalue As Double = TXTCASHFLOW.Item("transcode", TXTCASHFLOW.CurrentRow.Index).Value
        If Transcodevalue <= 0 Then
            MsgBox("Voucher Not Found,It may be Opening Account Balance ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If VoucherNameValue = "Sales Voucher" Then
            If MyAppSettings.AllowSingleEntryMode = True Then
                Dim frm As New SingleEntryVoucherForm("Sales Voucher", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()
            Else
                Dim frm As New VoucherEntryForm("Sales Voucher", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()

            End If
            LoadAllData()
        ElseIf VoucherNameValue = "Credit Note Voucher" Then
            If MyAppSettings.AllowSingleEntryMode = True Then
                Dim frm As New SingleEntryVoucherForm("Credit Note Voucher", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()
            Else
                Dim frm As New VoucherEntryForm("Credit Note Voucher", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()

            End If
            LoadAllData()
        ElseIf VoucherNameValue = "Purchase Voucher" Then
            If MyAppSettings.AllowSingleEntryMode = True Then
                Dim frm As New SingleEntryVoucherForm("Purchase Voucher", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()
            Else
                Dim frm As New VoucherEntryForm("Purchase Voucher", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()

            End If
            LoadAllData()
        ElseIf VoucherNameValue = "Debit Note Voucher" Then
            If MyAppSettings.AllowSingleEntryMode = True Then
                Dim frm As New SingleEntryVoucherForm("Debit Note Voucher", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()
            Else
                Dim frm As New VoucherEntryForm("Debit Note Voucher", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()

            End If
            LoadAllData()
        ElseIf VoucherNameValue = "Payment" Then
            If MyAppSettings.AllowSingleEntryMode = True Then
                Dim frm As New SingleEntryVoucherForm("Payment", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()
            Else
                Dim frm As New VoucherEntryForm("Payment", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()

            End If
            LoadAllData()
        ElseIf VoucherNameValue = "Receipt" Then
            If MyAppSettings.AllowSingleEntryMode = True Then
                Dim frm As New SingleEntryVoucherForm("Receipt", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()
            Else
                Dim frm As New VoucherEntryForm("Receipt", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()

            End If
            LoadAllData()
        ElseIf VoucherNameValue = "Journal" Then
            If MyAppSettings.AllowSingleEntryMode = True Then
                Dim frm As New SingleEntryVoucherForm("Journal", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()
            Else
                Dim frm As New VoucherEntryForm("Journal", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()

            End If
            LoadAllData()
        ElseIf VoucherNameValue = "Contra" Then
            If MyAppSettings.AllowSingleEntryMode = True Then
                Dim frm As New SingleEntryVoucherForm("Contra", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()
            Else
                Dim frm As New VoucherEntryForm("Contra", Transcodevalue)
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()

            End If
            LoadAllData()
        ElseIf VoucherNameValue = "SalesInvoice" Then
            Dim frm As New InvoiceAlterForm
            frm.TxtTitle.Text = "ALTER SALES INVOICE"
            Dim K As New SalesControlAll("SI", Transcodevalue, SQLGetStringFieldValue("SELECT transtype FROM StockInvoiceDetails WHERE TRANSCODE=" & Transcodevalue, "transtype"))
            K.BtnNew.Enabled = False
            K.BtnOpen.Enabled = False
            frm.TxtList.Controls.Add(K)
            frm.TxtList.Controls(0).Dock = DockStyle.Fill
            frm.WindowState = FormWindowState.Maximized
            frm.ShowDialog()
            frm.Dispose()
            K.Dispose()
            LoadAllData()
        ElseIf VoucherNameValue = "POS" Then
            Dim frm As New InvoiceAlterForm
            frm.TxtTitle.Text = "ALTER POS INVOICE"
            Dim K As New SalesControlAll("POS", Transcodevalue, SQLGetStringFieldValue("SELECT transtype FROM StockInvoiceDetails WHERE TRANSCODE=" & Transcodevalue, "transtype"))
            K.BtnNew.Enabled = False
            K.BtnOpen.Enabled = False
            frm.TxtList.Controls.Add(K)
            frm.TxtList.Controls(0).Dock = DockStyle.Fill
            frm.WindowState = FormWindowState.Maximized
            frm.ShowDialog()
            frm.Dispose()
            K.Dispose()
            LoadAllData()
        ElseIf VoucherNameValue = "PurchaseInvoice" Then
            Dim frm As New InvoiceAlterForm
            frm.TxtTitle.Text = "ALTER PURCHASE INVOICE "
            Dim K As New PurchaseControlAll("PI", Transcodevalue, SQLGetStringFieldValue("SELECT transtype FROM StockInvoiceDetails WHERE TRANSCODE=" & Transcodevalue, "transtype"))
            K.BtnNew.Enabled = False
            K.BtnOpen.Enabled = False
            frm.TxtList.Controls.Add(K)
            frm.TxtList.Controls(0).Dock = DockStyle.Fill
            frm.WindowState = FormWindowState.Maximized
            frm.ShowDialog()
            frm.Dispose()
            K.Dispose()
            LoadAllData()
        Else

            MsgBox("Voucher Not Found ", MsgBoxStyle.Information)
        End If

    End Sub
End Class