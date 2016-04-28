Imports System.Data.SqlClient
Imports System.IO

Public Class ledgerdaywisebalancereport
    Dim SqlStr As String = ""
    Dim IsOpened As Boolean = False
    Dim OpenLedgerName As String = ""

    Dim ReportSqlStr As String = ""
    Public IsCashBookReport As Boolean = False
    Public IsBankBookReport As Boolean = False

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadReport()
        txtDrTotal.Text = "0"
        TxtCrTotal.Text = "0"
        If TxtLedgerName.Text.Length = 0 Then
            MsgBox("Please Select the Ledger name ...             ")
            Exit Sub
        End If
        If TxtStartDate.Value > TxtEndDate.Value Then
            Dim k As New DateTimePicker
            k = TxtStartDate
            TxtStartDate = TxtEndDate
            TxtEndDate = k
        End If
        Dim OpenRowStr As String = ""
        Dim OpenBalance As Double = 0
        Dim OpenCrBalance As Double = 0
        ReportSqlStr = ""
        MainForm.Cursor = Cursors.WaitCursor
        If TxtIsCurrency.Checked = True Then
            If IsDateWiseOn.Checked = True Then
                OpenBalance = SQLGetNumericFieldValue("select sum(dr*conrate) as tot from ledgerbook where  isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "' and transdatevalue<" & (CDbl(TxtStartDate.Value.Date.ToOADate)), "tot")
                OpenCrBalance = SQLGetNumericFieldValue("select sum(cr*conrate) as tot from ledgerbook where  isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "' and transdatevalue<" & (CDbl(TxtStartDate.Value.Date.ToOADate)), "tot")
                OpenBalance = OpenBalance - OpenCrBalance
                If OpenBalance > 0 Then
                    OpenRowStr = "SELECT TOP 1 CONVERT(datetime,'" & TxtStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101) as [Date],'Opening Balance' as [Details], '' as [Voucher No],'' as [Voucher Name]," & OpenBalance & " as [DR], 0 as [CR] ,'' as [Balance] from ledgerbook where isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "'"
                ElseIf OpenBalance = 0 Then
                    OpenRowStr = ""
                Else

                    OpenRowStr = "SELECT TOP 1 CONVERT(datetime,'" & TxtStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101) as [Date],'Opening Balance' as [Details], '' as [Voucher No],'' as [Voucher Name],0 as [DR], " & OpenBalance * -1 & " as [CR] ,'' as [Balance] from ledgerbook where isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "'"
                End If

            End If
            SqlStr = "SELECT TOP (100) PERCENT  transdate as [Date],acledger as [Details], invoiceno as [Voucher No],invoicename as [Voucher Name],dr*conrate as [DR], cr*conrate as [CR] ,'' as [Balance] from ledgerbook where isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "'"
            TxtCurrencyName.Text = "Grand Totals Figures in " & SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TxtLedgerName.Text & "'", "currency")


        Else
            If IsDateWiseOn.Checked = True Then
                OpenBalance = SQLGetNumericFieldValue("select sum(dr-cr) as tot from ledgerbook where  isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "' and transdatevalue<" & (CDbl(TxtStartDate.Value.Date.ToOADate)), "tot")
                If OpenBalance > 0 Then
                    OpenRowStr = "SELECT TOP 1 CONVERT(datetime,'" & TxtStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101) as [Date],'Opening Balance' as [Details], '' as [Voucher No],'' as [Voucher Name]," & OpenBalance & " as [DR], 0 as [CR] ,'' as [Balance] from ledgerbook where isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "'"
                ElseIf OpenBalance = 0 Then
                    OpenRowStr = ""
                Else
                    OpenRowStr = "SELECT TOP 1 CONVERT(datetime,'" & TxtStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101) as [Date],'Opening Balance' as [Details], '' as [Voucher No],'' as [Voucher Name],0 as [DR], " & OpenBalance * -1 & " as [CR] ,'' as [Balance] from ledgerbook where isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "'"
                End If

            End If
            SqlStr = "SELECT TOP (100) PERCENT  transdate as [Date],acledger as [Details], invoiceno as [Voucher No],invoicename as [Voucher Name],dr as [DR], cr as [CR],'' as [Balance] from ledgerbook where isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "'"

            TxtCurrencyName.Text = "Grand Totals Figures in " & CompDetails.Currency
        End If
        If IsDateWiseOn.Checked = True Then
            SqlStr = SqlStr & " and (transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") order by TransDate, transcode"
        Else
            SqlStr = SqlStr & "  order by TransDate, transcode"
        End If
        If OpenRowStr.Length > 0 Then
            SqlStr = "SELECT * FROM (" & OpenRowStr & ") AS TB1 UNION ALL SELECT * FROM (" & SqlStr & " ) AS TB1"
        End If
        ReportSqlStr = SqlStr
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            Me.TxtList.Columns("Date").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Date").Width = 85
            Me.TxtList.Columns("Date").DefaultCellStyle.Format = "d"
            Me.TxtList.Columns("Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.TxtList.Columns("Details").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Details").Width = 250

            Me.TxtList.Columns("Voucher No").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Voucher No").Width = 85

            Me.TxtList.Columns("Voucher Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Voucher Name").Width = 125

            Me.TxtList.Columns("DR").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("DR").Width = 108
            Me.TxtList.Columns("DR").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("DR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("Cr").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Cr").Width = 108
            Me.TxtList.Columns("Cr").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("Cr").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("Balance").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Balance").Width = 108
            Me.TxtList.Columns("Balance").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("Balance").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Catch ex As Exception

        End Try
        TxtList.Refresh()
        Dim drtotal As Double = 0
        Dim crtotal As Double = 0
        Dim baltotal As Double = 0
        For i As Integer = 0 To TxtList.RowCount - 1
            drtotal = drtotal + CDbl(TxtList.Item("DR", i).Value)
            crtotal = crtotal + CDbl(TxtList.Item("cr", i).Value)
            TxtList.Item("Balance", i).Value = IIf(drtotal - crtotal > 0, FormatNumber(drtotal - crtotal, ErpDecimalPlaces, , , TriState.False).ToString & " Dr", FormatNumber(crtotal - drtotal, ErpDecimalPlaces, , , TriState.False).ToString & " Cr")
            If CDbl(TxtList.Item("DR", i).Value) = 0 Then
                TxtList.Item("DR", i).Value = DBNull.Value
            End If
            If CDbl(TxtList.Item("cr", i).Value) = 0 Then
                TxtList.Item("cr", i).Value = DBNull.Value
            End If
          
        Next

        txtDrTotal.Text = FormatNumber(drtotal, ErpDecimalPlaces, , , TriState.False)
        TxtCrTotal.Text = FormatNumber(crtotal, ErpDecimalPlaces, , , TriState.False)
        TxtNetTotal.Text = IIf(drtotal - crtotal > 0, FormatNumber(drtotal - crtotal, ErpDecimalPlaces, , , TriState.False).ToString & " Dr", FormatNumber(crtotal - drtotal, ErpDecimalPlaces, , , TriState.False).ToString & " Cr")
        For i As Integer = 0 To TxtList.Columns.Count - 1
            TxtList.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        txttotalrows.Text = TxtList.RowCount & " Rows Found"
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
        TxtHeading.Text = UCase(TxtLedgerName.Text) & "  LEDGER DAY WISE BALANCE SHEET"
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

    Private Sub TxtShowNarration_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadReport()
    End Sub

    Private Sub ledgerdaywisebalancereport_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub LedgerTransactionsReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
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


    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, PrintToolStripMenuItem.Click
        If ReportSqlStr.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New LedgerDaywiseBalanceDataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(ReportSqlStr, cnn)
        dscmd.Fill(ds, "ledgerbook")
        cnn.Close()
        Dim objRpt As New LedgerDaywiseBalanceCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = " Period From " & TxtStartDate.Value.Date & " To " & TxtEndDate.Value.Date
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text & Chr(13) & " Period From " & TxtStartDate.Value.Date & " To " & TxtEndDate.Value.Date
        End If



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
                If ReportSqlStr.Length = 0 Then Exit Sub
                Me.Cursor = Cursors.WaitCursor
                Dim ds As New LedgerDaywiseBalanceDataSet
                Dim cnn As SqlConnection
                cnn = New SqlConnection(ConnectionStrinG)
                cnn.Open()
                Dim dscmd As New SqlDataAdapter(ReportSqlStr, cnn)
                dscmd.Fill(ds, "ledgerbook")
                cnn.Close()
                Dim objRpt As New LedgerDaywiseBalanceCRReport
                SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
                If PrintOptionsforCR.IsPrintHeader = False Then
                    CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
                    CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
                    CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
                    CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = " Period From " & TxtStartDate.Value.Date & " To " & TxtEndDate.Value.Date
                Else
                    CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text & Chr(13) & " Period From " & TxtStartDate.Value.Date & " To " & TxtEndDate.Value.Date
                End If



                objRpt.SetDataSource(ds)
                Dim printfilename As String = ""
                printfilename = Path.GetTempPath() & TxtLedgerName.Text & "-BalanceSheet-" & Now.ToString("yyyy-MM-dd HH mm ss") & ".pdf"

                objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, printfilename)
                objRpt.Dispose()

                SendCustomEmailTo(SQLGetStringFieldValue("SELECT emailid FROM LEDGERS WHERE LEDGERNAME=N'" & TxtLedgerName.Text & "'", "emailid"), TxtHeading.Text, "Dear Sir, Please Find the attachement for Balance sheet", printfilename)
            End If
        End If
    End Sub
End Class