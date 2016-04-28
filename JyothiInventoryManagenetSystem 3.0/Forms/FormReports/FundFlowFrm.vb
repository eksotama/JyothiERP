Imports System.Data.SqlClient

Public Class FundFlowFrm
    Dim OpenLedgerName As String = ""
    Dim IsOpened As Boolean = False
    Dim SqlStr As String = ""
    Dim SqlStrCrTotal As String = ""
    Dim SqlStrDrTotal As String = ""

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadDetailedReport()
        Dim ledstr As String = ""
        'ledstr = "(ledgername in (SELECT LEDGERNAME FROM LEDGERS where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CapitalAccounts & "' or groupname=N'" & AccountGroupNames.FixedAssets & "' or groupname=N'" & AccountGroupNames.CurrentAssets & "'  or groupname=N'" & AccountGroupNames.CurrentLiabilities & "' ))))"
        ledstr = "(ledgername in (SELECT LEDGERNAME FROM LEDGERS where (Accountgroup in (select subgroup from AccountGroupsList where  groupname=N'" & AccountGroupNames.FixedAssets & "' or groupname=N'" & AccountGroupNames.CurrentAssets & "'  or groupname=N'" & AccountGroupNames.CurrentLiabilities & "' ))))"
        If TxtShowDrCrStyle.Checked = True Then
            SqlStr = "SELECT (UPPER(left(DATENAME(MONTH,ledgerbook.TransDate),3)) + '-' + CONVERT(varchar(30),year(ledgerbook.TransDate))) AS [Period],SUM(DR) AS [Inflow],SUM(CR) as [OutFlow],(CASE  WHEN SUM(DR)-SUM(CR)>=0 THEN CONVERT(varchar(30), CAST(SUM(DR)-SUM(CR) AS DECIMAL(15,3)),1) +' Dr' ELSE CONVERT(varchar(30), CAST(SUM(CR)-SUM(DR) AS DECIMAL(15,3)),1) + ' Cr' END)  AS [Net Flow] from ledgerbook where isdeleted=0 and " & ledstr
            SqlStr = SqlStr & " GROUP BY year(ledgerbook.TransDate),month(ledgerbook.TransDate) ,DATENAME(MONTH,TransDate) "
        Else
            SqlStr = "SELECT (UPPER(left(DATENAME(MONTH,ledgerbook.TransDate),3)) + '-' + CONVERT(varchar(30),year(ledgerbook.TransDate))) AS [Period],SUM(DR) AS [Inflow],SUM(CR) as [OutFlow], (SUM(DR)-SUM(CR))  AS [Net Flow] from ledgerbook where isdeleted=0 and " & ledstr
            SqlStr = SqlStr & " GROUP BY year(ledgerbook.TransDate),month(ledgerbook.TransDate) ,DATENAME(MONTH,TransDate) "
        End If

        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns("Inflow").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Inflow").Width = 150
            Me.TxtList.Columns("Inflow").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("Inflow").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("OutFlow").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("OutFlow").Width = 150
            Me.TxtList.Columns("OutFlow").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("OutFlow").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            If TxtShowDrCrStyle.Checked = True Then
                Me.TxtList.Columns("Net Flow").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtList.Columns("Net Flow").Width = 150
                Me.TxtList.Columns("Net Flow").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.TxtList.Columns("Net Flow").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Else
                Me.TxtList.Columns("Net Flow").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtList.Columns("Net Flow").Width = 150
                Me.TxtList.Columns("Net Flow").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.TxtList.Columns("Net Flow").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            End If


        Catch ex As Exception

        End Try

        TxtCrTotal.Text = "0"
        txtDrTotal.Text = "0"
        TxtCrTotal.Text = SQLGetNumericFieldValue("select sum(cr) as cramt from ledgerbook where isdeleted=0 and " & ledstr, "cramt")
        txtDrTotal.Text = SQLGetNumericFieldValue("select sum(dr) as cramt from ledgerbook where isdeleted=0 and " & ledstr, "cramt")

        If CDbl(txtDrTotal.Text) - CDbl(TxtCrTotal.Text) > 0 Then
            If TxtShowDrCrStyle.Checked = True Then
                TxtNetTotal.Text = CompDetails.Currency & " " & FormatNumber(CDbl(txtDrTotal.Text) - CDbl(TxtCrTotal.Text), ErpDecimalPlaces).ToString & " Dr"
            Else
                TxtNetTotal.Text = CompDetails.Currency & " " & FormatNumber(CDbl(txtDrTotal.Text) - CDbl(TxtCrTotal.Text), ErpDecimalPlaces).ToString
            End If

        Else
            If TxtShowDrCrStyle.Checked = True Then
                TxtNetTotal.Text = CompDetails.Currency & " " & FormatNumber(CDbl(TxtCrTotal.Text) - CDbl(txtDrTotal.Text), ErpDecimalPlaces).ToString & " Cr"
            Else
                TxtNetTotal.Text = CompDetails.Currency & " " & FormatNumber(CDbl(TxtCrTotal.Text) - CDbl(txtDrTotal.Text), ErpDecimalPlaces).ToString
            End If

        End If


        txtDrTotal.Text = CompDetails.Currency & " " & FormatNumber(CDbl(txtDrTotal.Text), ErpDecimalPlaces)
        TxtCrTotal.Text = CompDetails.Currency & " " & FormatNumber(CDbl(TxtCrTotal.Text), ErpDecimalPlaces)

        LoadGraph()
    End Sub
    Sub LoadGraph()

        If IsCrDrChart.Checked = True Then
            Chart1.Series.Clear()

            Try
                Chart1.Series.Add("DR Value").ChartType = IIf(TxtCharType.SelectedIndex < 0, 0, TxtCharType.SelectedIndex)
                Chart1.Series.Add("CR Value").ChartType = IIf(TxtCharType.SelectedIndex < 0, 0, TxtCharType.SelectedIndex)

            Catch ex As Exception

            End Try

            For i As Integer = 1 To TxtList.RowCount
                Chart1.Series("DR Value").Points.AddXY(TxtList.Item("Period", i - 1).Value, TxtList.Item("Inflow", i - 1).Value)
                Chart1.Series("CR Value").Points.AddXY(TxtList.Item("Period", i - 1).Value, TxtList.Item("OutFlow", i - 1).Value)
            Next
        Else
            Chart1.Series.Clear()
            Chart1.Series.Add("Value")
            For i As Integer = 1 To TxtList.RowCount
                Chart1.Series("Value").Points.AddXY(TxtList.Item("Period", i - 1).Value, TxtList.Item("Inflow", i - 1).Value - TxtList.Item("OutFlow", i - 1).Value)
                Try
                    Chart1.Series(0).ChartType = IIf(TxtCharType.SelectedIndex < 0, 0, TxtCharType.SelectedIndex)
                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Private Sub FundFlowFrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub MontlyAccountBalanceSheet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDetailedReport()
        TxtCharType.Text = "Column"
        IsCrDrChart.Checked = False
    End Sub

    Private Sub TxtMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMethod.SelectedIndexChanged
        LoadDetailedReport()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCharType.SelectedIndexChanged
        LoadGraph()
    End Sub

    Private Sub IsCrDrChart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsCrDrChart.CheckedChanged
        If IsCrDrChart.Checked = True Then
            TxtCharType.Enabled = False
        Else
            TxtCharType.Enabled = True
        End If

        LoadGraph()

    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, PrintToolStripMenuItem.Click
        If SqlStr.Length = 0 Then Exit Sub
        Dim TempSql As String = ""
        Dim ledstr As String = ""
      

        ledstr = "(ledgername in (SELECT LEDGERNAME FROM LEDGERS where (Accountgroup in (select subgroup from AccountGroupsList where  groupname=N'" & AccountGroupNames.FixedAssets & "' or groupname=N'" & AccountGroupNames.CurrentAssets & "'  or groupname=N'" & AccountGroupNames.CurrentLiabilities & "' ))))"
        If TxtShowDrCrStyle.Checked = True Then
            SqlStr = "SELECT (UPPER(left(DATENAME(MONTH,ledgerbook.TransDate),3)) + '-' + CONVERT(varchar(30),year(ledgerbook.TransDate))) AS [Period],SUM(DR) AS [DrAmount],SUM(CR) as [CrAmount],(CASE  WHEN SUM(DR)-SUM(CR)>=0 THEN CONVERT(varchar(30), CAST(SUM(DR)-SUM(CR) AS DECIMAL(15,3)),1) +' Dr' ELSE CONVERT(varchar(30), CAST(SUM(CR)-SUM(DR) AS DECIMAL(15,3)),1) + ' Cr' END)  AS [Balance] from ledgerbook where isdeleted=0 and " & ledstr
            SqlStr = SqlStr & " GROUP BY year(ledgerbook.TransDate),month(ledgerbook.TransDate) ,DATENAME(MONTH,TransDate) "
        Else
            SqlStr = "SELECT (UPPER(left(DATENAME(MONTH,ledgerbook.TransDate),3)) + '-' + CONVERT(varchar(30),year(ledgerbook.TransDate))) AS [Period],SUM(DR) AS [DrAmount],SUM(CR) as [CrAmount], (SUM(DR)-SUM(CR))  AS [Balance] from ledgerbook where isdeleted=0 and " & ledstr
            SqlStr = SqlStr & " GROUP BY year(ledgerbook.TransDate),month(ledgerbook.TransDate) ,DATENAME(MONTH,TransDate) "
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(SqlStr, cnn)
        dscmd.Fill(ds, "ledgerbook")
        cnn.Close()
        Dim objRpt As New CashFlowCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
        End If
        '   CType(objRpt.Section1.ReportObjects.Item("TxtCurrency"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ""

        objRpt.SetDataSource(ds)
        Dim FRM As New ReportCommonForm(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cursor = Cursors.Default
        FRM.ShowDialog()
        FRM.Dispose()
        objRpt.Dispose()
        ds.Dispose()
    End Sub

    Private Sub TxtIsCurrency_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadDetailedReport()
    End Sub

    Private Sub TxtList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellDoubleClick
        'If TxtList.SelectedRows.Count = 0 Then Exit Sub
        'Dim stdt As New DateTimePicker
        'Dim eddt As New DateTimePicker
        'stdt.Format = DateTimePickerFormat.Custom
        'stdt.CustomFormat = "dd/MM/yyyy"
        'eddt.Format = DateTimePickerFormat.Custom
        'eddt.CustomFormat = "dd/MM/yyyy"
        'Try
        '    stdt.Value = ("1-" & TxtList.Item("Period", TxtList.CurrentRow.Index).Value).ToString
        'Catch ex As Exception
        '    stdt.Value = "1-1" & TxtList.Item("Period", TxtList.CurrentRow.Index).Value
        'End Try
        'Try
        '    eddt.Value = ("20-" & TxtList.Item("Period", TxtList.CurrentRow.Index).Value).ToString
        '    eddt.Value = (Date.DaysInMonth(eddt.Value.Year, eddt.Value.Month) & "-" & TxtList.Item("Period", TxtList.CurrentRow.Index).Value).ToString
        'Catch ex As Exception
        '    eddt.Value = "31-12" & TxtList.Item("Period", TxtList.CurrentRow.Index).Value
        'End Try
        ''MsgBox(stdt.Value)
        ''MsgBox(eddt.Value)
        'Dim K As New LedgerTransactionsReportForm(TxtLedgerName.Text)
        'Me.Cursor = Cursors.WaitCursor
        'K.SuspendLayout()
        'K.MdiParent = MainForm
        'K.TxtStartDate.Value = stdt.Value
        'K.TxtEndDate.Value = eddt.Value
        'K.Dock = DockStyle.Fill
        'K.Show()
        'K.WindowState = FormWindowState.Maximized
        'K.BringToFront()
        'K.ResumeLayout()
        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub TxtShowDrCrStyle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShowDrCrStyle.CheckedChanged
        LoadDetailedReport()
    End Sub
End Class