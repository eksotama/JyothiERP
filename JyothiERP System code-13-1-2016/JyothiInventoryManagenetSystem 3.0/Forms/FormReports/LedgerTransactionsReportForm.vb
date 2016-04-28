Imports System.Data.SqlClient
Imports System.IO

Public Class LedgerTransactionsReportForm
    Dim SqlStr As String = ""
    Dim IsOpened As Boolean = False
    Dim OpenLedgerName As String = ""
    Dim SqlStrTotalDr As String = ""
    Dim SqlStrTotalCr As String = ""
    Dim SqlOPDr As String = ""
    Dim SqlOpCr As String = ""
    Public IsCashBookReport As Boolean = False
    Public IsBankBookReport As Boolean = False

    Sub New(Optional ByVal Ledgername As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If Ledgername.Length > 0 Then
            OpenLedgerName = Ledgername
            IsOpened = True
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub TxtList_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellDoubleClick
        Dim VoucherNameValue As String = TxtList.Item("Voucher Name", TxtList.CurrentRow.Index).Value
        Dim Transcodevalue As Double = TxtList.Item("transcode", TxtList.CurrentRow.Index).Value
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
        Else

            MsgBox("Voucher Not Found ", MsgBoxStyle.Information)
        End If
        LoadReport()
    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadReport()
        txtDrTotal.Text = "0"
        TxtCrTotal.Text = "0"
        If TxtStartDate.Value > TxtEndDate.Value Then
            Dim k As New DateTimePicker
            k = TxtStartDate
            TxtStartDate = TxtEndDate
            TxtEndDate = k
        End If
        If IsBankBookReport = True Or IsCashBookReport = True Then
            If TxtLedgerName.Text.Length = 0 Then
                If TxtLedgerName.Items.Count > 0 Then
                    TxtLedgerName.SelectedIndex = 0
                End If
            End If

        End If
        MainForm.Cursor = Cursors.WaitCursor
        If TxtIsCurrency.Checked = True Then
            If TxtShowNarration.Checked = True Then

                SqlStr = "SELECT transdate as [Date],(acledger  +char(10)+narration) as [Details], invoiceno as [Voucher No],invoicename as [Voucher Name],dr*conrate as [DR], cr*conrate as [CR] from ledgerbook where isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "'"
            Else
                SqlStr = "SELECT transdate as [Date],acledger as [Details], invoiceno as [Voucher No],invoicename as [Voucher Name],dr*conrate as [DR], cr*conrate as [CR] from ledgerbook where isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "'"
            End If

            TxtCurrencyName.Text = "Figures in " & SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TxtLedgerName.Text & "'", "currency")
            SqlStrTotalDr = "select sum(dr*conrate) as dramt from ledgerbook where isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "'"
            SqlStrTotalCr = "select sum(Cr*conrate) as dramt from ledgerbook where isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "'"
            SqlOPDr = SqlStrTotalDr
            SqlOpCr = SqlStrTotalCr
        Else
            If TxtShowNarration.Checked = True Then
                SqlStr = "SELECT transdate as [Date],(acledger  +char(10)+narration) as [Details], invoiceno as [Voucher No],invoicename as [Voucher Name],dr as [DR], cr as [CR] from ledgerbook where isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "'"
            Else
                SqlStr = "SELECT transdate as [Date],acledger as [Details], invoiceno as [Voucher No],invoicename as [Voucher Name],dr as [DR], cr as [CR] from ledgerbook where isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "'"
            End If

            SqlStrTotalDr = "select sum(dr) as dramt from ledgerbook where isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "'"
            SqlStrTotalCr = "select sum(Cr) as dramt from ledgerbook where isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "'"
            SqlOPDr = SqlStrTotalDr
            SqlOpCr = SqlStrTotalCr

            TxtCurrencyName.Text = "Figures in " & CompDetails.Currency
        End If
        If IsDateWiseOn.Checked = True Then
            SqlStr = SqlStr & " and (transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "

            SqlStrTotalDr = SqlStrTotalDr & " and (transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
            SqlStrTotalCr = SqlStrTotalCr & " and (transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "

        End If
        If TxtUserWise.Text.Length = 0 Or TxtUserWise.Text = "*All" Then

        Else
            SqlStr = SqlStr & " and username=N'" & TxtUserWise.Text & "' "
            SqlStrTotalDr = SqlStrTotalDr & " and username=N'" & TxtUserWise.Text & "' "
            SqlStrTotalCr = SqlStrTotalCr & " and username=N'" & TxtUserWise.Text & "' "
            SqlOPDr = SqlOPDr & " and username=N'" & TxtUserWise.Text & "' "
            SqlOpCr = SqlOpCr & " and username=N'" & TxtUserWise.Text & "' "
        End If
        If TxtLocationWise.Text.Length = 0 Or TxtLocationWise.Text = "*All" Then
        Else
            If TxtLocationWise.Text.ToUpper = "MainLocation".ToUpper Or TxtLocationWise.Text.ToUpper = "MainStore".ToUpper Then
                SqlStr = SqlStr & " and storename in ('MainLocation','MainStore') "
                SqlStrTotalDr = SqlStrTotalDr & " and storename in ('MainLocation','MainStore') "
                SqlStrTotalCr = SqlStrTotalCr & " and storename in ('MainLocation','MainStore') "
                SqlOPDr = SqlOPDr & " and storename in ('MainLocation','MainStore') "
                SqlOpCr = SqlOpCr & " and storename in ('MainLocation','MainStore') "
            Else

                SqlStr = SqlStr & " and storename=N'" & TxtLocationWise.Text & "' "
                SqlStrTotalDr = SqlStrTotalDr & " and storename=N'" & TxtLocationWise.Text & "' "
                SqlStrTotalCr = SqlStrTotalCr & " and storename=N'" & TxtLocationWise.Text & "' "
                SqlOPDr = SqlOPDr & " and storename=N'" & TxtLocationWise.Text & "' "
                SqlOpCr = SqlOpCr & " and storename=N'" & TxtLocationWise.Text & "' "
            End If
         

        End If
        SqlStr = SqlStr & " order by TransDate, transcode"
        If TxtIsCurrency.Checked = True Then
            txtDrTotal.Text = SQLGetNumericFieldValue(SqlStrTotalDr, "dramt")
            TxtCrTotal.Text = SQLGetNumericFieldValue(SqlStrTotalCr, "dramt")
            Dim OpCrval As Double = 0
            Dim OpDrval As Double = 0
            If IsDateWiseOn.Checked = True Then
                OpDrval = SQLGetNumericFieldValue(SqlOPDr & " and transdatevalue<" & TxtStartDate.Value.Date.ToOADate, "dramt")
                OpCrval = SQLGetNumericFieldValue(SqlOpCr & " and transdatevalue<" & TxtStartDate.Value.Date.ToOADate, "dramt")
            End If
            Dim CurValue As String
            CurValue = SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TxtLedgerName.Text & "'", "currency").ToString
            If (CDbl(txtDrTotal.Text) + OpDrval) - (CDbl(TxtCrTotal.Text) + OpCrval) > 0 Then
                TxtNetCrTotal.Visible = False
                TxtNetDrTotal.Visible = True
                TxtNetDrTotal.Text = CurValue & " " & FormatNumber((CDbl(txtDrTotal.Text) + OpDrval) - (CDbl(TxtCrTotal.Text) + OpCrval), ErpDecimalPlaces).ToString
            Else
                TxtNetCrTotal.Visible = True
                TxtNetDrTotal.Visible = False
                TxtNetCrTotal.Text = CurValue & " " & FormatNumber((CDbl(TxtCrTotal.Text) + OpCrval) - (CDbl(txtDrTotal.Text) + OpDrval), ErpDecimalPlaces).ToString
            End If
            txtDrTotal.Text = CurValue & " " & FormatNumber(CDbl(txtDrTotal.Text), ErpDecimalPlaces)
            TxtCrTotal.Text = CurValue & " " & FormatNumber(CDbl(TxtCrTotal.Text), ErpDecimalPlaces)
            If IsDateWiseOn.Checked = True Then
                TxtOpDrTotal.Text = CurValue & " " & FormatNumber(OpDrval, ErpDecimalPlaces)
                TxtOpCrTotal.Text = CurValue & " " & FormatNumber(OpCrval, ErpDecimalPlaces)
            Else
                TxtOpDrTotal.Text = "0.000"
                TxtOpCrTotal.Text = "0.000"
            End If
        Else

            txtDrTotal.Text = SQLGetNumericFieldValue(SqlStrTotalDr, "dramt")
            TxtCrTotal.Text = SQLGetNumericFieldValue(SqlStrTotalCr, "dramt")
            Dim OpCrval As Double = 0
            Dim OpDrval As Double = 0
            If IsDateWiseOn.Checked = True Then
                OpDrval = SQLGetNumericFieldValue(SqlOPDr & " and transdatevalue<" & TxtStartDate.Value.Date.ToOADate, "dramt")
                OpCrval = SQLGetNumericFieldValue(SqlOpCr & " and transdatevalue<" & TxtStartDate.Value.Date.ToOADate, "dramt")
            End If

            Dim CurValue As String
            CurValue = CompDetails.Currency
            If (CDbl(txtDrTotal.Text) + OpDrval) - (CDbl(TxtCrTotal.Text) + OpCrval) > 0 Then
                TxtNetCrTotal.Visible = False
                TxtNetDrTotal.Visible = True
                TxtNetDrTotal.Text = CurValue & " " & FormatNumber((CDbl(txtDrTotal.Text) + OpDrval) - (CDbl(TxtCrTotal.Text) + OpCrval), ErpDecimalPlaces).ToString
            Else
                TxtNetCrTotal.Visible = True
                TxtNetDrTotal.Visible = False
                TxtNetCrTotal.Text = CurValue & " " & FormatNumber((CDbl(TxtCrTotal.Text) + OpCrval) - (CDbl(txtDrTotal.Text) + OpDrval), ErpDecimalPlaces).ToString
            End If
            txtDrTotal.Text = CurValue & " " & FormatNumber(CDbl(txtDrTotal.Text), ErpDecimalPlaces)
            TxtCrTotal.Text = CurValue & " " & FormatNumber(CDbl(TxtCrTotal.Text), ErpDecimalPlaces)
            If IsDateWiseOn.Checked = True Then
                TxtOpDrTotal.Text = CurValue & " " & FormatNumber(OpDrval, ErpDecimalPlaces)
                TxtOpCrTotal.Text = CurValue & " " & FormatNumber(OpCrval, ErpDecimalPlaces)
            Else
                TxtOpDrTotal.Text = "0.000"
                TxtOpCrTotal.Text = "0.000"
            End If
        End If


        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr.Replace("SELECT ", "SELECT TRANSCODE, "))
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            Me.TxtList.Columns("TRANSCODE").Visible = False
            Me.TxtList.Columns("Date").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Date").Width = 95
            Me.TxtList.Columns("Date").DefaultCellStyle.Format = "d"
            Me.TxtList.Columns("Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.TxtList.Columns("Details").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns("Details").Width = 250

            Me.TxtList.Columns("Voucher No").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Voucher No").Width = 85

            Me.TxtList.Columns("Voucher Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Voucher Name").Width = 125



            Me.TxtList.Columns("DR").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("DR").Width = 150
            Me.TxtList.Columns("DR").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("DR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("Cr").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Cr").Width = 150
            Me.TxtList.Columns("Cr").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("Cr").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        Catch ex As Exception

        End Try

        MainForm.Cursor = Cursors.Default
    End Sub

    Private Sub TxtIsCurrency_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIsCurrency.CheckedChanged
        LoadReport()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, RefreshToolStripMenuItem.Click
        LoadReport()
    End Sub

    Private Sub TxtLedgerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.SelectedIndexChanged
        btnsendemail.Enabled = False
        If TxtLedgerName.Text.Length = 0 Then Exit Sub
        TxtHeading.Text = UCase(TxtLedgerName.Text) & "  TRANSACTIONS SUMMARY"
        If TxtLedgerName.Text.Length = 0 Or TxtLedgerName.Text = "*All" Then
        Else
            If SQLIsFieldExists("SELECT LEDGERNAME FROM LEDGERS WHERE LEDGERNAME=N'" & TxtLedgerName.Text & "' AND ISSENDEMAIL='True'") = True Then
                btnsendemail.Enabled = True
            Else
                btnsendemail.Enabled = False
            End If
        End If
        LoadReport()
    End Sub

    Private Sub TxtShowNarration_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShowNarration.CheckedChanged
        LoadReport()
    End Sub

    Private Sub LedgerTransactionsReportForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub LedgerTransactionsReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        LoadDataIntoComboBox("select distinct storename  from ledgerbook ", TxtLocationWise, "storename", "*All")
        LoadDataIntoComboBox("select distinct username  from ledgerbook", TxtUserWise, "username", "*All")
        If DefDepartment() = "Sales" Then
            LoadDataIntoComboBox("SELECT LEDGERNAME FROM LEDGERS where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "'))", TxtLedgerName, "ledgername")
        ElseIf DefDepartment() = "Purchase" Then
            LoadDataIntoComboBox("SELECT LEDGERNAME FROM LEDGERS where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "'))", TxtLedgerName, "ledgername")
        ElseIf DefDepartment() = "Inventory" Then
            LoadDataIntoComboBox("SELECT LEDGERNAME FROM LEDGERS where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CustomersAccounts & "'))", TxtLedgerName, "ledgername")
        Else
            LoadDataIntoComboBox("SELECT LEDGERNAME FROM LEDGERS ", TxtLedgerName, "ledgername")
        End If
        If IsCashBookReport = True Then
            LoadDataIntoComboBox("SELECT LEDGERNAME FROM LEDGERS where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "'))", TxtLedgerName, "ledgername")
        End If
        If IsBankBookReport = True Then
            LoadDataIntoComboBox("SELECT LEDGERNAME FROM LEDGERS where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.BankOD & "'))", TxtLedgerName, "ledgername")
        End If
        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        If IsOpened = True Then
            TxtLedgerName.Text = OpenLedgerName
        Else

        End If
        LoadReport()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, PrintToolStripMenuItem.Click
        If SqlStr.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(SqlStr, cnn)
        dscmd.Fill(ds, "ledgerbook")
        cnn.Close()
        Dim objRpt As New LedgerTransactionCRreport1
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
        End If
        CType(objRpt.Section4.ReportObjects.Item("TxtOpDr"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtOpDrTotal.Text
        CType(objRpt.Section4.ReportObjects.Item("TxtOpCr"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtOpCrTotal.Text
        CType(objRpt.Section4.ReportObjects.Item("TxtnetDr"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtNetDrTotal.Text
        CType(objRpt.Section4.ReportObjects.Item("Txtnetcr"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtNetCrTotal.Text
      
     

        objRpt.SetDataSource(ds)
        Dim FRM As New ReportCommonForm(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cursor = Cursors.Default
        FRM.ShowDialog()
        FRM.Dispose()
        objRpt.Dispose()
        ds.Dispose()
    End Sub


    Private Sub btnsendemail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsendemail.Click
        If SQLIsFieldExists("SELECT LEDGERNAME FROM LEDGERS WHERE LEDGERNAME=N'" & TxtLedgerName.Text & "' AND ISSENDEMAIL='True'") = True Then
            If MsgBox("Do you want to send E-Mail to " & TxtLedgerName.Text & " ?          ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If SqlStr.Length = 0 Then Exit Sub
                Me.Cursor = Cursors.WaitCursor
                Dim ds As New DataSet
                Dim cnn As SqlConnection
                cnn = New SqlConnection(ConnectionStrinG)
                cnn.Open()
                Dim dscmd As New SqlDataAdapter(SqlStr, cnn)
                dscmd.Fill(ds, "ledgerbook")
                cnn.Close()
                Dim objRpt As New LedgerTransactionCRreport1
                SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
                If PrintOptionsforCR.IsPrintHeader = False Then
                    CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
                    CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
                    CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
                Else
                    CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
                End If
                CType(objRpt.Section4.ReportObjects.Item("TxtOpDr"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtOpDrTotal.Text
                CType(objRpt.Section4.ReportObjects.Item("TxtOpCr"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtOpCrTotal.Text
                CType(objRpt.Section4.ReportObjects.Item("TxtnetDr"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtNetDrTotal.Text
                CType(objRpt.Section4.ReportObjects.Item("Txtnetcr"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtNetCrTotal.Text


                objRpt.SetDataSource(ds)
                Dim printfilename As String = ""
                printfilename = Path.GetTempPath() & TxtLedgerName.Text & "-BalanceSheet-" & Now.ToString("yyyy-MM-dd HH mm ss") & ".pdf"


                objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, printfilename)
                objRpt.Dispose()

                SendCustomEmailTo(SQLGetStringFieldValue("SELECT emailid FROM LEDGERS WHERE LEDGERNAME=N'" & TxtLedgerName.Text & "'", "emailid"), TxtHeading.Text, "Dear Sir, Please Find the attachement for Balance sheet", printfilename)
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub TxtList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub

    Private Sub TxtLocationWise_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtLocationWise.SelectedIndexChanged
        LoadReport()
    End Sub

    Private Sub TxtUserWise_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtUserWise.SelectedIndexChanged
        LoadReport()
    End Sub
End Class