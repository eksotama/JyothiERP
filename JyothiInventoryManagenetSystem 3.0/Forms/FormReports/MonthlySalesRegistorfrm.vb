Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting

Public Class MonthlySalesRegistorfrm
    'PLEASE DONT CHANGE THE GRIDVIEW  COLUMN NAME, IT WILL BE EFFECT IN DATASET FOR THE REPORTTS
    ' HERE IS THE CODE , DON'T CHANGE THE NAMES 
    ' SQLSTR="SELECT STOCKCODE AS [STOCK CODE] ....." DONT CHANGE THE [STOCK CODE]
    'SO, INSTEAD OF THE COLUMN NAME, PLEASE CHANGE THE HEADERTEXT PROPERTY OF THE GRID.
    ' YOU CAN CHANGE THE HEADERTEXT
    'FOR EXAMPLE
    ' TxtList.Columns("Item Code").HeaderText = "STOCK NAME(ANY TEXT)"

    Dim SqlStr As String = ""
    Dim SqlStrTotal As String = ""
    Dim SqlGroupStr As String = ""
    Dim GraphSqlStr As String = ""
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadReport()

        Me.Cursor = Cursors.WaitCursor
        TxtTotals.Text = "0.000"
        Dim TempBS As New BindingSource
        If TxtSalesPerson.Text.Length = 0 Then
            TxtSalesPerson.Text = "*All"
        End If
        If TxtLedgerName.Text.Length = 0 Then
            TxtLedgerName.Text = "*All"
        End If
        If TxtStockGroup.Text.Length = 0 Then
            TxtStockGroup.Text = "*All"
        End If
        SqlStrTotal = "SELECT SUM(nettotal) AS Tot from StockInvoiceDetails where (VoucherName='SI' or voucherName='POS')  and isdelete=0 "
        SqlStr = "SELECT (UPPER(left(DATENAME(MONTH,StockInvoiceDetails.TransDate),3)) + '-' + CONVERT(varchar(30),year(StockInvoiceDetails.TransDate))) AS [Period], SUM(nettotal) AS [Net Total] from StockInvoiceDetails where (VoucherName='SI' or voucherName='POS')  and isdelete=0 "
        GraphSqlStr = "(VoucherName='SI' or voucherName='POS') and isdelete=0  "
        If TxtIsPeriod.Checked = True Then
            If TxtSalesPerson.Text = "*All" And TxtLedgerName.Text = "*All" Then
                SqlStr = SqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
                SqlStrTotal = SqlStrTotal & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
                GraphSqlStr = GraphSqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
            ElseIf TxtSalesPerson.Text = "*All" Then
                SqlStr = SqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "')"
                SqlStrTotal = SqlStrTotal & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "')"
                GraphSqlStr = GraphSqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "')"
            ElseIf TxtLedgerName.Text = "*All" Then
                SqlStr = SqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
                SqlStrTotal = SqlStrTotal & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
                GraphSqlStr = GraphSqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
            Else
                SqlStr = SqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "' and ledgername=N'" & TxtLedgerName.Text & "')"
                SqlStrTotal = SqlStrTotal & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "' and ledgername=N'" & TxtLedgerName.Text & "')"
                GraphSqlStr = GraphSqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "' and ledgername=N'" & TxtLedgerName.Text & "')"
            End If

        Else
            If TxtSalesPerson.Text = "*All" And TxtLedgerName.Text = "*All" Then

            ElseIf TxtSalesPerson.Text = "*All" Then
                SqlStr = SqlStr & "  and Transcode in (select transcode from StockInvoiceDetails where  ledgername=N'" & TxtLedgerName.Text & "')"
                SqlStrTotal = SqlStrTotal & "  and Transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "')"
                GraphSqlStr = GraphSqlStr & "  and Transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "')"
            ElseIf TxtLedgerName.Text = "*All" Then
                SqlStr = SqlStr & "  and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
                SqlStrTotal = SqlStrTotal & "  and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
                GraphSqlStr = GraphSqlStr & "  and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
            Else
                SqlStr = SqlStr & "  and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "' and ledgername=N'" & TxtLedgerName.Text & "')"
                SqlStrTotal = SqlStrTotal & "  and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "' and ledgername=N'" & TxtLedgerName.Text & "')"
                GraphSqlStr = GraphSqlStr & "  and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "' and ledgername=N'" & TxtLedgerName.Text & "')"
            End If
        End If

        If TxtSalesAc.Text.Length = 0 Or TxtSalesAc.Text = "*All" Then
        Else
            SqlStr = SqlStr & " and AccountLedgerName=N'" & TxtSalesAc.Text & "'"
            SqlStrTotal = SqlStrTotal & " and AccountLedgerName=N'" & TxtSalesAc.Text & "'"
            GraphSqlStr = GraphSqlStr & " and AccountLedgerName=N'" & TxtSalesAc.Text & "'"
        End If

        SqlStr = SqlStr & " GROUP BY year(StockInvoiceDetails.TransDate),month(StockInvoiceDetails.TransDate) ,DATENAME(MONTH,TransDate) "
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Me.Cursor = Cursors.Default

        Try
            If TxtList.RowCount = 0 Then Exit Sub
            Me.TxtList.Columns("Period").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns("Period").Width = 120
            Me.TxtList.Columns("Period").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.TxtList.Columns("Net Total").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Net Total").Width = 150
            Me.TxtList.Columns("Net Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.TxtList.Columns("Net Total").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

        Catch ex As Exception

        End Try
        Dim Tot As Double
        Tot = FormatNumber(SQLGetNumericFieldValue(SqlStrTotal, "Tot"), ErpDecimalPlaces)
        TxtTotals.Text = CompDetails.Currency & " " & Tot.ToString
        Me.Cursor = Cursors.Default

        LoadGraphs()
    End Sub

    Private Sub MonthlySalesRegistorfrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub


    Private Sub SalesRegister_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        LoadDataIntoComboBox("select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "')", TxtLedgerName, "ledgername", "*All")
        LoadDataIntoComboBox("select salespersonname from salespersons", TxtSalesPerson, "salespersonname", "*All")
        LoadDataIntoComboBox("select stockgroupname from stockgroups", TxtStockGroup, "stockgroupname", "*All")
        LoadDataIntoComboBox("select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')", TxtSalesAc, "ledgername", "*All")
        TxtList.Visible = True
        TxtList.Dock = DockStyle.Fill
        LoadReport()
        TxtCharType.Text = "Column"
    End Sub



    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub TxtCharType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCharType.SelectedIndexChanged
        If TxtCharType.SelectedIndex >= 0 Then
            Chart1.Series(0).ChartType = TxtCharType.SelectedIndex
        Else
            Chart1.Series(0).ChartType = 0
        End If
    End Sub
    Sub LoadGraphs()
        Try
            If GraphSqlStr.Length = 0 Then Exit Sub
            Chart1.DataSource = SQLLoadGridData(SqlStr)

            Chart1.Series("Series1").XValueMember = "period"
            Chart1.Series("Series1").YValueMembers = "Net Total"
            If TxtCharType.SelectedIndex >= 0 Then
                Chart1.Series(0).ChartType = TxtCharType.SelectedIndex
            Else
                Chart1.Series(0).ChartType = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            Chart1.Titles.Clear()
            Chart1.Titles.Add("Sales")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtIsPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIsPeriod.CheckedChanged
        LoadReport()
    End Sub

    Private Sub UserButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton2.Click
        LoadReport()
    End Sub

    Private Sub TxtLedgerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.SelectedIndexChanged, TxtStockGroup.SelectedIndexChanged, TxtSalesPerson.SelectedIndexChanged, TxtSalesAc.SelectedIndexChanged
        LoadReport()
    End Sub



    Private Sub TxtList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellDoubleClick
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        Dim stdt As New DateTimePicker
        Dim eddt As New DateTimePicker
       
        Try
            stdt.Value = ("1-" & TxtList.Item("Period", TxtList.CurrentRow.Index).Value).ToString
        Catch ex As Exception
            stdt.Value = "1-1" & TxtList.Item("Period", TxtList.CurrentRow.Index).Value
        End Try
        Try
            eddt.Value = ("20-" & TxtList.Item("Period", TxtList.CurrentRow.Index).Value).ToString
            eddt.Value = (Date.DaysInMonth(eddt.Value.Year, eddt.Value.Month) & "-" & TxtList.Item("Period", TxtList.CurrentRow.Index).Value).ToString
        Catch ex As Exception
            eddt.Value = "31-12" & TxtList.Item("Period", TxtList.CurrentRow.Index).Value
        End Try

        MainForm.Cursor = Cursors.WaitCursor
        SalesRegister.SuspendLayout()
        SalesRegister.MdiParent = MainForm
        SalesRegister.Dock = DockStyle.Fill
        SalesRegister.TxtStartDate.Value = stdt.Value
        SalesRegister.TxtEndDate.Value = eddt.Value
        SalesRegister.Show()
        SalesRegister.WindowState = FormWindowState.Maximized
        SalesRegister.BringToFront()
        SalesRegister.ResumeLayout()
        MainForm.Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If TxtList.RowCount = 0 Then Exit Sub


        Me.Cursor = Cursors.WaitCursor
        Dim ds As New MonthlyRegisterDataSet
        ds.Clear()
        For i As Integer = 0 To TxtList.RowCount - 1
            Dim row As DataRow
            row = ds.Tables(0).NewRow
            For k As Integer = 0 To TxtList.ColumnCount - 1
                Try
                    row(TxtList.Columns(k).Name) = TxtList.Item(k, i).Value
                Catch ex As Exception
                    row(TxtList.Columns(k).Name) = 0
                End Try

            Next
            ds.Tables(0).Rows.Add(row)
        Next
        Dim objRpt As New MonthlyRegistersCRReport

        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "SALES REGISTER"
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "SALES REGISTER"

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