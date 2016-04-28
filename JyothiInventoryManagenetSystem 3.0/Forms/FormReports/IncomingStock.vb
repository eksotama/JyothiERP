Imports System.Data.SqlClient

Public Class IncomingStock
    Dim SqlStr As String = ""
    Sub LoadDef()
        LoadDataIntoComboBox("select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "')", TxtFilterByLedger, "ledgername")
        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadData()
        Dim TotSqlStr As String = " FROM StockInvoiceRowItems WHERE (VoucherName = 'PG' or vouchername='SR' or vouchername='DP') and isdelete=0"
        SqlStr = "SELECT StockCode as [Stock Item], StockSize as [Stock Size], SUM(TotalQty) AS [Base Qty], (CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainunit ELSE (CASE CAST(SUM(TotalQty) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST(SUM(TotalQty) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END) AS [Total Qty], SUM(StockAmount) AS [Stock Value] FROM StockInvoiceRowItems WHERE (VoucherName = 'PG'  or vouchername='SR' or vouchername='DP') and isdelete=0"
        If TxtFilterByLedger.Text.Length = 0 Or TxtFilterByLedger.Text = "*All" Then
        Else
            SqlStr = SqlStr & " and transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtFilterByLedger.Text & "') "
            TotSqlStr = TotSqlStr & " and transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtFilterByLedger.Text & "') "
        End If
        If IsDateWiseOn.Checked = True Then
            SqlStr = SqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"

            TotSqlStr = TotSqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
        End If

        SqlStr = SqlStr & " GROUP BY StockCode, StockSize, BaseUnit, UnitCon, MainUnit, SubUnit"

        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            'Total Qty

            If AppIsItemwithSize = False Then
                TxtList.Columns("Stock Size").Visible = False
            End If

            TxtList.Columns("Total Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Total Qty").Width = 160

            TxtList.Columns("Stock Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Stock Value").Width = 160
            TxtTotal1.Text = SQLGetNumericFieldValue("select sum(totalqty) as tot " & TotSqlStr, "tot")
            TxtTotal2.Text = SQLGetNumericFieldValue("select sum(StockAmount) as tot " & TotSqlStr, "tot")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub IncomingStock_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub IncomingStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        LoadDef()
        LoadData()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub TxtFilterByLedger_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFilterByLedger.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        LoadData()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If SqlStr.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(SqlStr, cnn)
        dscmd.Fill(ds, "stockinvoicerowitems")
        cnn.Close()
        Dim objRpt As New OutgoingStockCrReport

        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
            If IsDateWiseOn.Checked = True Then
                CType(objRpt.Section1.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " To " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)
            End If
        Else

            If IsDateWiseOn.Checked = True Then
                CType(objRpt.Section1.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text & "  Period From " & FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " To " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)
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
End Class