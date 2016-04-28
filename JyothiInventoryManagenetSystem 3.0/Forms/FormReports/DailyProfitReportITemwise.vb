Imports System.Data.SqlClient

Public Class DailyProfitReportITemwise
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
    Sub LoadReport()
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

        Else
            Wherestr = Wherestr & " and transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "') "
        End If

        Dim grpstr As String = ""
        If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
            grpstr = ""
        Else
            grpstr = " and (STOCKCODE IN (SELECT STOCKCODE FROM STOCKDBF WHERE STOCKGROUP=N'" & TxtStockGroup.Text & "'))  "
            Wherestr = Wherestr & grpstr
        End If

        If TxtOnCurrentPrice.Checked = True Then
            SqlStr = "SELECT STOCKCODE AS [STOCK CODE], ISNULL( (SELECT SUM(TOTALQTY) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND STOCKCODE=T.STOCKCODE ),0) AS [SOLD QTY],ISNULL( (SELECT avg(netrate) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND STOCKCODE=T.STOCKCODE ),0) AS [RATE], ISNULL( (SELECT SUM(netStockAmount) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND STOCKCODE=T.STOCKCODE ),0) AS [TOTAL SALES], ISNULL( (SELECT SUM(netStockAmount) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND STOCKCODE=T.STOCKCODE ),0)-(ISNULL( (SELECT SUM(TOTALQTY/unitcon) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND STOCKCODE=T.STOCKCODE ),0)* (SELECT MAX(STOCKRATE) FROM STOCKDBF WHERE  STOCKCODE=T.STOCKCODE AND  STOCKSIZE=T.STOCKSIZE ))  AS [SOLD PROFIT]," _
         & "  ISNULL((SELECT SUM(TOTALQTY) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SR') AND STOCKCODE=T.STOCKCODE ),0) AS [RET QTY],  ISNULL((SELECT SUM(N1) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SR') AND STOCKCODE=T.STOCKCODE ),0) AS [RET PROFIT], ( ISNULL( (SELECT SUM(netStockAmount) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND STOCKCODE=T.STOCKCODE ),0)-(ISNULL( (SELECT SUM(TOTALQTY/unitcon) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND STOCKCODE=T.STOCKCODE ),0)* (SELECT MAX(STOCKRATE) FROM STOCKDBF WHERE  STOCKCODE=T.STOCKCODE AND  STOCKSIZE=T.STOCKSIZE )) -  ISNULL((SELECT SUM(N1) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SR') AND STOCKCODE=T.STOCKCODE ),0)) AS [NET PRFIT] " _
         & " FROM StockInvoiceRowItems AS T WHERE VOUCHERNAME IN ('POS','SD','SR')  " & grpstr

        Else
            SqlStr = "SELECT STOCKCODE AS [STOCK CODE], ISNULL( (SELECT SUM(TOTALQTY) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND STOCKCODE=T.STOCKCODE ),0) AS [SOLD QTY],ISNULL( (SELECT avg(netrate*100/(100+tax)) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND STOCKCODE=T.STOCKCODE ),0) AS [RATE], ISNULL( (SELECT SUM(StockAmount) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND STOCKCODE=T.STOCKCODE ),0) AS [TOTAL SALES],  ISNULL((SELECT SUM(COALESCE(N1,2)) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND STOCKCODE=T.STOCKCODE ),0) AS [SOLD PROFIT]," _
         & "  ISNULL((SELECT SUM(TOTALQTY) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SR') AND STOCKCODE=T.STOCKCODE ),0) AS [RET QTY],  ISNULL((SELECT SUM(N1) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SR') AND STOCKCODE=T.STOCKCODE ),0) AS [RET PROFIT], ( ISNULL((SELECT SUM(N1) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') AND STOCKCODE=T.STOCKCODE ),2) -  ISNULL((SELECT SUM(N1) FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SR') AND STOCKCODE=T.STOCKCODE ),0)) AS [NET PRFIT] " _
         & " FROM StockInvoiceRowItems AS T WHERE VOUCHERNAME IN ('POS','SD','SR')  " & grpstr

        End If
        If IsDateWiseOn.Checked = True Then
            SqlStr = SqlStr & "  and (transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
        End If

        SqlStr = SqlStr & " GROUP BY STOCKCODE,STOCKSIZE,UNITCON order by stockcode"
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        'Wherestr
        txtSoldProfit.Text = "0"
        TxtNetSalesAmount.Text = "0"
        TxtReturnProfit.Text = "0"
        TxtNetProfit.Text = "0"
        For i As Integer = 0 To TxtList.RowCount - 1
            txtSoldProfit.Text = CDbl(txtSoldProfit.Text) + CDbl(TxtList.Item("SOLD PROFIT", i).Value)
            TxtNetSalesAmount.Text = CDbl(TxtNetSalesAmount.Text) + CDbl(TxtList.Item("TOTAL SALES", i).Value)
            TxtReturnProfit.Text = CDbl(TxtReturnProfit.Text) + CDbl(TxtList.Item("RET PROFIT", i).Value)
            TxtNetProfit.Text = CDbl(TxtNetProfit.Text) + CDbl(TxtList.Item("NET PRFIT", i).Value)
        Next

        txtSoldProfit.Text = FormatNumber(CDbl(txtSoldProfit.Text), ErpDecimalPlaces)
        TxtNetSalesAmount.Text = FormatNumber(CDbl(TxtNetSalesAmount.Text), ErpDecimalPlaces)
        TxtReturnProfit.Text = FormatNumber(CDbl(TxtReturnProfit.Text), ErpDecimalPlaces)
        TxtNetProfit.Text = FormatNumber(CDbl(txtSoldProfit.Text) - CDbl(TxtReturnProfit.Text), ErpDecimalPlaces)

        'txtSoldProfit.Text = FormatNumber(SQLGetNumericFieldValue("SELECT SUM(N1) AS TOT FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') ", "TOT"), ErpDecimalPlaces)
        'TxtNetSalesAmount.Text = FormatNumber(SQLGetNumericFieldValue("SELECT SUM(StockAmount) AS TOT FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME IN ('SD','POS') ", "TOT"), ErpDecimalPlaces)
        'TxtReturnProfit.Text = FormatNumber(SQLGetNumericFieldValue("SELECT SUM(N1) AS TOT FROM StockInvoiceRowItems " & Wherestr & " AND VOUCHERNAME='SR' ", "TOT"), ErpDecimalPlaces)
        'TxtNetProfit.Text = FormatNumber(CDbl(txtSoldProfit.Text) - CDbl(TxtReturnProfit.Text), ErpDecimalPlaces)



        Try

            Me.TxtList.Columns("Stock Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns("Stock Code").Width = 250

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


    End Sub

    Private Sub TxtIsCurrency_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadReport()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, RefreshToolStripMenuItem.Click
        LoadReport()
    End Sub

    Private Sub TxtLedgerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.SelectedIndexChanged
        If TxtLedgerName.Text.Length = 0 Then Exit Sub
        TxtHeading.Text = UCase(TxtLedgerName.Text) & "  PROFIT  SUMMARY"
        LoadReport()
    End Sub

    Private Sub TxtShowNarration_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadReport()
    End Sub

    Private Sub DailyProfitReportITemwise_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub LedgerTransactionsReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = Today
        TxtEndDate.Value = Today
        LoadDataIntoComboBox("select stockgroupname from stockgroups", TxtStockGroup, "stockgroupname", "*All")
        LoadDataIntoComboBox("select distinct ledgername from StockInvoiceDetails where vouchername in ('POS','SD','SR')", TxtLedgerName, "LEDGERNAME", "*All")
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
        Dim objRpt As New DailyProfitReportItemwiseCR
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


    Private Sub TxtStockGroup_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtStockGroup.SelectedIndexChanged
        If TxtStockGroup.Text.Length = 0 Then Exit Sub
        TxtHeading.Text = UCase(TxtStockGroup.Text) & "  PROFIT  SUMMARY"
        LoadReport()
    End Sub

    Private Sub TxtOnCurrentPrice_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles TxtOnCurrentPrice.CheckedChanged
        LoadReport()
    End Sub
End Class