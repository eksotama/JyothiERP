Imports System.Data.SqlClient

Public Class profitreportsummary
    Dim SqlStr As String = ""
    Dim IsOpened As Boolean = False
    Dim OpenLedgerName As String = ""
    Dim SqlStrTotalDr As String = ""
    Dim SqlStrTotalCr As String = ""
    Dim SqlOPDr As String = ""
    Dim SqlOpCr As String = ""
    Public IsCashBookReport As Boolean = False
    Public IsBankBookReport As Boolean = False

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Public Sub LoadReport()
  
        Dim sUMQTYR As String = ""
        If TxtStartDate.Value > TxtEndDate.Value Then
            Dim k As New DateTimePicker
            k = TxtStartDate
            TxtStartDate = TxtEndDate
            TxtEndDate = k
        End If
        Dim Wherestr As String = ""
        If IsDateWiseOn.Checked = True Then
            Wherestr = " where isdelete=0  and (transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
        Else
            Wherestr = " where isdelete=0 "
        End If
        If TxtLedgerName.Text.Length = 0 Or TxtLedgerName.Text = "*All" Then
            TxtHeading.Text = "  PROFIT  SUMMARY"
        Else
            Wherestr = Wherestr & " and transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "') "
            TxtHeading.Text = UCase(TxtLedgerName.Text) & "  PROFIT  SUMMARY"
        End If
        If TxtStockCode.Text.Length = 0 Or TxtStockCode.Text = "*All" Then
        Else
            Wherestr = Wherestr & " and stockcode=N'" & TxtStockCode.Text & "' "
            TxtHeading.Text = TxtHeading.Text & " For STOCK: " & TxtStockCode.Text
        End If
       
        'DATEADD (day,TRANSDATEvalue,0) 

        'ISNULL( (SELECT AVG(MRP) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND TRANSDATE=T.TRANSDATE ),0) AS [MRP AVG]
        If TxtOnCurrentPrice.Checked = True Then
            '  SqlStr = "SELECT TRANSDATE AS [TRANS DATE], ISNULL( (SELECT SUM(TOTALQTY) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND TRANSDATE=T.TRANSDATE ),0) AS [SOLD QTY],ISNULL( (SELECT AVG(NETRATE) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND TRANSDATE=T.TRANSDATE ),0) AS [RATE], ISNULL( (SELECT SUM(StockAmount) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND TRANSDATE=T.TRANSDATE ),0) AS [TOTAL SALES], (select sum(value) from ( SELECT StockAmount-(totalqty/UnitCon * (select MAX(stockrate) from StockDbf where stockdbf.stockcode=t1.stockcode and stockdbf.stocksize=t1.stocksize)) as value,stockcode,stocksize FROM StockInvoiceRowItems t1 where VOUCHERNAME IN ('SD','POS') AND  AND TRANSDATE=T.TRANSDATE) t6)  AS [SOLD PROFIT]," _
            '& "  ISNULL((SELECT SUM(TOTALQTY) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SR') AND TRANSDATE=T.TRANSDATE ),0) AS [RET QTY],  ISNULL((SELECT SUM(N1) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SR') AND TRANSDATE=T.TRANSDATE ),0) AS [RET PROFIT], (select sum(value) from ( SELECT StockAmount-(totalqty/UnitCon * (select MAX(stockrate) from StockDbf where stockdbf.stockcode=t1.stockcode and stockdbf.stocksize=t1.stocksize)) as value,stockcode,stocksize FROM StockInvoiceRowItems t1 where VOUCHERNAME IN ('SD','POS') AND  AND TRANSDATE=T.TRANSDATE) t6)- (select sum(value) from ( SELECT StockAmount-(totalqty/UnitCon * (select MAX(stockrate) from StockDbf where stockdbf.stockcode=t1.stockcode and stockdbf.stocksize=t1.stocksize)) as value,stockcode,stocksize FROM StockInvoiceRowItems t1 where VOUCHERNAME='SR' AND   TRANSDATE=T.TRANSDATE) t6) AS [NET PRFIT] " _
            '& " FROM StockInvoiceRowItems AS T WHERE VOUCHERNAME IN ('POS','SD','SR')  "
            SqlStr = "SELECT TRANSDATE AS [TRANS DATE], ISNULL( (SELECT SUM(TOTALQTY) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND TRANSDATE=T.TRANSDATE ),0) AS [SOLD QTY],ISNULL( (SELECT AVG(netrate*100/(100+tax)) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND TRANSDATE=T.TRANSDATE ),0) AS [RATE], ISNULL( (SELECT SUM(StockAmount) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND TRANSDATE=T.TRANSDATE ),0) AS [TOTAL SALES],  (select sum(value) from ( SELECT StockAmount-(totalqty/UnitCon * (select MAX(stockrate) from StockDbf where stockdbf.stockcode=t1.stockcode and stockdbf.stocksize=t1.stocksize)) as value,stockcode,stocksize FROM StockInvoiceRowItems t1 where VOUCHERNAME IN ('SD','POS') AND  t1.TRANSDATE=T.TRANSDATE) t6)  AS [SOLD PROFIT]," _
      & "  ISNULL((SELECT SUM(TOTALQTY) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SR') AND TRANSDATE=T.TRANSDATE ),0) AS [RET QTY],  ISNULL((SELECT SUM(N1) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SR') AND TRANSDATE=T.TRANSDATE ),0) AS [RET PROFIT], (select sum(value) from ( SELECT StockAmount-(totalqty/UnitCon * (select MAX(stockrate) from StockDbf where stockdbf.stockcode=t1.stockcode and stockdbf.stocksize=t1.stocksize)) as value,stockcode,stocksize FROM StockInvoiceRowItems t1 where VOUCHERNAME IN ('SD','POS') AND  t1.TRANSDATE=T.TRANSDATE) t6)-ISNULL( (select sum(value) from ( SELECT StockAmount-(totalqty/UnitCon * (select MAX(stockrate) from StockDbf where stockdbf.stockcode=t1.stockcode and stockdbf.stocksize=t1.stocksize)) as value,stockcode,stocksize FROM StockInvoiceRowItems t1 where VOUCHERNAME='SR' AND  t1.TRANSDATE=T.TRANSDATE) t6),0) AS [NET PRFIT] " _
      & " FROM StockInvoiceRowItems AS T WHERE VOUCHERNAME IN ('POS','SD','SR')  "

        Else
            SqlStr = "SELECT TRANSDATE AS [TRANS DATE], ISNULL( (SELECT SUM(TOTALQTY) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND TRANSDATE=T.TRANSDATE ),0) AS [SOLD QTY],ISNULL( (SELECT AVG(netrate*100/(100+tax)) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND TRANSDATE=T.TRANSDATE ),0) AS [RATE], ISNULL( (SELECT SUM(StockAmount) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND TRANSDATE=T.TRANSDATE ),0) AS [TOTAL SALES], ISNULL((SELECT SUM(N1) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND TRANSDATE=T.TRANSDATE ),0) AS [SOLD PROFIT]," _
            & "  ISNULL((SELECT SUM(TOTALQTY) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SR') AND TRANSDATE=T.TRANSDATE ),0) AS [RET QTY],  ISNULL((SELECT SUM(N1) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SR') AND TRANSDATE=T.TRANSDATE ),0) AS [RET PROFIT], ( ISNULL((SELECT SUM(N1) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND TRANSDATE=T.TRANSDATE ),2) -  ISNULL((SELECT SUM(N1) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SR') AND TRANSDATE=T.TRANSDATE ),0)) AS [NET PRFIT] " _
            & " FROM StockInvoiceRowItems AS T WHERE VOUCHERNAME IN ('POS','SD','SR')  "

        End If

        
        If IsDateWiseOn.Checked = True Then
            SqlStr = SqlStr & "  and (transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
        End If

        If TxtStockCode.Text.Length = 0 Or TxtStockCode.Text = "*All" Then
        Else
            SqlStr = SqlStr & " and stockcode=N'" & TxtStockCode.Text & "' "
        End If

        SqlStr = SqlStr & " GROUP BY TRANSDATE"


        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try

            Me.TxtList.Columns("TRANS DATE").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns("TRANS DATE").Width = 250
            '  Me.TxtList.Columns("TRANS DATE").DefaultCellStyle.Format = "DD-MM-YYYY"
            Me.TxtList.Columns("RATE").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("RATE").Width = 80
            Me.TxtList.Columns("RATE").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("RATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("TOTAL SALES").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("TOTAL SALES").Width = 100
            Me.TxtList.Columns("TOTAL SALES").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("TOTAL SALES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            Me.TxtList.Columns("SOLD QTY").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("SOLD QTY").Width = 100
            Me.TxtList.Columns("SOLD QTY").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("SOLD QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("SOLD PROFIT").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("SOLD PROFIT").Width = 100
            Me.TxtList.Columns("SOLD PROFIT").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("SOLD PROFIT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("RET QTY").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("RET QTY").Width = 100
            Me.TxtList.Columns("RET QTY").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("RET QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            Me.TxtList.Columns("RET PROFIT").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("RET PROFIT").Width = 100
            Me.TxtList.Columns("RET PROFIT").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("RET PROFIT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            Me.TxtList.Columns("NET PRFIT").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("NET PRFIT").Width = 100
            Me.TxtList.Columns("NET PRFIT").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("NET PRFIT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight



        Catch ex As Exception

        End Try
        Dim solprofit As Double = 0
        Dim retproft As Double = 0
        For I As Integer = 0 To TxtList.RowCount - 1
            Try
                solprofit = solprofit + CDbl(TxtList.Item("NET PRFIT", I).Value)
            Catch ex As Exception

            End Try
        Next
        TxtOpCrTotal.Text = FormatNumber(solprofit, ErpDecimalPlaces)
        '  TxtOpCrTotal.Text = FormatNumber(SQLGetNumericFieldValue(sUMQTYR, "Profit"))
    End Sub

    Private Sub TxtIsCurrency_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadReport()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, RefreshToolStripMenuItem.Click
        LoadReport()
    End Sub

    Private Sub TxtStockCode_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TxtStockCode.MouseClick
        Dim frm As New SelectItemCodeorName
        frm.ShowDialog()
        If SearchStockItemName.Length > 0 Then
            TxtStockCode.Items.Clear()
            TxtStockCode.Items.Add(SearchStockItemName)
            TxtStockCode.Text = SearchStockItemName
            LoadReport()
        End If
       

    End Sub

    Private Sub TxtLedgerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.SelectedIndexChanged, TxtStockCode.SelectedIndexChanged
        LoadReport()
    End Sub

    Private Sub TxtShowNarration_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadReport()
    End Sub

    Private Sub profitreportsummary_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub LedgerTransactionsReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = Today
        TxtEndDate.Value = Today

        LoadDataIntoComboBox("select distinct ledgername from StockInvoiceDetails where vouchername in ('POS','SD','SR')", TxtLedgerName, "LEDGERNAME", "*All")
        ' LoadDataIntoComboBoxBindMethod("select distinct stockcode from stockdbf ", TxtStockCode, "stockcode", "*All")

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
        Dim ds As New dialyprofitdataset
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(SqlStr, cnn)
        dscmd.Fill(ds, "DataTable1")
        cnn.Close()
        Dim objRpt As New DailyProfitReportItemwiseCR_Summary
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            If IsDateWiseOn.Checked = True Then
                CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text & TxtStartDate.Value.Date.ToString("dd/MM/yyyy") & " To " & TxtEndDate.Value.Date.ToString("dd/MM/yyyy")
            Else
                CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
            End If

        Else

            If IsDateWiseOn.Checked = True Then

                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text & TxtStartDate.Value.Date.ToString("dd/MM/yyyy") & " To " & TxtEndDate.Value.Date.ToString("dd/MM/yyyy")
            Else
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
            End If
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

    Private Sub TxtStockGroup_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        LoadReport()
    End Sub

    Private Sub TxtOnCurrentPrice_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles TxtOnCurrentPrice.CheckedChanged
        LoadReport()
    End Sub
End Class