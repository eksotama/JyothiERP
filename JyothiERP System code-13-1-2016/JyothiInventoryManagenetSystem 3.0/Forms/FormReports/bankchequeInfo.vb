Imports System.Drawing.Printing

Public Class bankchequeInfo
    Dim SqlStr As String = ""
    Dim Prtchequevalues As New ChequePrintValuesStruct
    Dim VhSchemeName As String = ""
    Dim OpenedTranscode As Double = 0
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)

    End Sub
    Sub LoadData()
        Dim TotalSqlStr As String = ""
        Dim Vouchernamestr As String = ""
        Vouchernamestr = " vouchername in ('payment','purchase','creditnote','Contra','journal') "
        TotalSqlStr = " SELECT SUM(AMOUNT) AS TOT FROM  chequeinfo where  " & Vouchernamestr
        SqlStr = "SELECT ROW_NUMBER() OVER (ORDER BY transcode) AS [SNO], details as [Particulars],ledgername as [Bank Name],chequeno as [Cheque No],chequedate as [Trans Date],voucherno as [Voucher No], Amount as [Amount], (case when  isprinted='true' then 'YES' else 'NO' end) as [IsPrinted],transcode as [Trans Code] from chequeinfo where    " & Vouchernamestr
        If IsDateWiseOn.Checked = True Then
            SqlStr = SqlStr & " AND (chequedatevalue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")"
            TotalSqlStr = TotalSqlStr & " AND (chequedatevalue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")"
        Else

        End If
        If TxtBankName.Text = "*All" Or TxtBankName.Text.Length = 0 Then

        Else
            SqlStr = SqlStr & " and ledgername=N'" & TxtBankName.Text & "'"
            TotalSqlStr = TotalSqlStr & " and ledgername=N'" & TxtBankName.Text & "'"
        End If

        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try

            TxtList.Columns("trans code").Visible = False
            TxtList.Columns("Sno").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Sno").Width = 80

            TxtList.Columns("Bank Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Bank Name").Width = 180


            TxtList.Columns("Particulars").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("Particulars").Width = 220

            'Cheque No
            TxtList.Columns("Cheque No").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Cheque No").Width = 100


            TxtList.Columns("Voucher No").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Voucher No").Width = 90

            TxtList.Columns("Trans Date").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Trans Date").DefaultCellStyle.Format = "d"
            TxtList.Columns("Trans Date").Width = 80

            TxtList.Columns("IsPrinted").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("IsPrinted").Width = 55






            TxtList.Columns("Amount").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Amount").Width = 100
            TxtList.Columns("Amount").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Amount").DefaultCellStyle.Font = New Font("Arial", 11, FontStyle.Bold)
            TxtList.Columns("Amount").DefaultCellStyle.ForeColor = Color.Green

        Catch ex As Exception

        End Try

        TxtCrTotal.Text = FormatNumber(SQLGetNumericFieldValue(TotalSqlStr, "tot"), ErpDecimalPlaces)
    End Sub




    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, PrintToolStripMenuItem.Click

        Dim pvalues As New PrintParameters

        Dim QcreditName As String = ""
        Dim SQLstr As String = ""
        Dim QAmt As Double = 0
        Dim Tcode As Double = 0


        Dim printk As New VoucherPrintDlg(pvalues)
        printk.Text = "Cheque Printing"
        printk.TxtHeading.Text = "CHEQUE PRINTING"

        If printk.ShowDialog = DialogResult.OK Then
            For Each x As DataGridViewRow In TxtList.SelectedRows
                QcreditName = TxtList.Item("Bank Name", x.Index).Value
                VhSchemeName = SQLGetStringFieldValue("select  f1 from ledgers where ledgername=N'" & QcreditName & "'", "f1")
                OpenedTranscode = CDbl(TxtList.Item("Trans code", x.Index).Value)
                Prtchequevalues.PayeeName = TxtList.Item("Particulars", x.Index).Value
                Prtchequevalues.Amount = TxtList.Item("Amount", x.Index).Value
                Prtchequevalues.PrintDate = TxtList.Item("Trans Date", x.Index).Value
                Prtchequevalues.AmountinWords = GetInWords(Prtchequevalues.Amount)
                LoadChequePageSetupValues(VhSchemeName)
                Dim ppd As New PrintPreviewDialog()
                ppd.Document = PrintDocument1
                If pvalues.NoofCopies > 0 Then
                    PrintDocument1.DefaultPageSettings.PrinterSettings.Copies = pvalues.NoofCopies
                End If
                If pvalues.IsPrintToPrinter = True Then
                    PrintDocument1.Print()
                ElseIf pvalues.IsPrintToPrinter = False Then
                    ppd.ShowDialog()
                End If
                ExecuteSQLQuery("UPDATE LEDGERBOOK SET IsChequePrint='True' where transcode=" & Tcode)
                ExecuteSQLQuery("UPDATE chequeinfo SET Isprinted='True' where transcode=" & Tcode)
            Next
            
            LoadData()
        End If


        'Me.Cursor = Cursors.WaitCursor
        'Dim ds As New PaySlipReportDataSet
        'ds.Clear()
        'ds.Tables(0).Rows.Clear()
        'For Each x As DataGridViewRow In TxtList.SelectedRows

        'Next



        'Dim objRpt As New PaySlipCRA5ReportForEmp
        'SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        'If PrintOptionsforCR.IsPrintHeader = False Then
        '    CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
        '    CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
        '    CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "PAY SLIP"
        'Else
        '    CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "PAY SLIP"
        'End If

        'objRpt.SetDataSource(ds)
        'Dim FRM As New ReportCommonForm(objRpt)
        'FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        'Me.Cursor = Cursors.Default
        'FRM.ShowDialog()
        'FRM.Dispose()
        'objRpt.Dispose()
        'ds.Dispose()

    End Sub

    Private Sub bankchequeInfo_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub PayrollListFormReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        LoadDataIntoComboBox("select LEDGERNAME from Ledgers where Isactive=1 and Accountgroup not in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankOD & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')", TxtBankName, "LEDGERNAME", "*All")
        TxtBankName.Text = "*All"

    End Sub

    Private Sub TxtEmployeeName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBankName.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub ImsButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        LoadData()
    End Sub

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint

        PrintDocument1.DefaultPageSettings.PaperSize = New PaperSize("Custom", ChequePagesetupValues.Paperwidth, ChequePagesetupValues.Paperheight)
        If ChequePagesetupValues.IslandScape = True Then
            PrintDocument1.DefaultPageSettings.Landscape = True
            'PagesetupValues
        Else
            PrintDocument1.DefaultPageSettings.Landscape = False
        End If
        PrintDocument1.DefaultPageSettings.Margins.Left = ChequePagesetupValues.leftmarging
        PrintDocument1.DefaultPageSettings.Margins.Right = ChequePagesetupValues.rightmarging
        PrintDocument1.DefaultPageSettings.Margins.Top = ChequePagesetupValues.topmarging
        PrintDocument1.DefaultPageSettings.Margins.Bottom = ChequePagesetupValues.buttommarging

    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ChequePrinting(sender, e, CDbl(TxtList.Item("trans code", TxtList.CurrentRow.Index).Value), VhSchemeName, Prtchequevalues)
    End Sub
End Class