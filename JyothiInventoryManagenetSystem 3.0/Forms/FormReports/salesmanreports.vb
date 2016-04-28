Imports System.Data.SqlClient

Public Class salesmanreports
    Dim SqlStr As String = ""
    Dim SqlstrTotal As String = ""

    Sub LoadDef()
        'LoadDataIntoComboBox("select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "')", TxtFilterByLedger, "ledgername")
        LoadDataIntoComboBox("select salespersonname from salespersons", TxtSalesPerson, "salespersonname", "*All")
        TxtStartDate.Value = New Date(Today.Date.Year, Today.Date.Month, 1)
        TxtEndDate.Value = New Date(Today.Date.Year, Today.Date.Month, Date.DaysInMonth(Today.Date.Year, Today.Date.Month))

      
    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadSummeryData()
        Me.Cursor = Cursors.WaitCursor

        Dim TempBS As New BindingSource
        TxtSalesPerson.Text = "*All"

        SqlStr = "SELECT salesperson as [Salesman Name],SUM((CASE WHEN VOUCHERNAME IN ('SI','POS') THEN  NETTOTAL ELSE 0 END)) AS [Sales Amount], SUM((CASE WHEN VOUCHERNAME='SR' THEN  NETTOTAL ELSE 0 END)) AS [Returns Amount], SUM((CASE WHEN VOUCHERNAME IN ('SI','POS') THEN  NETTOTAL ELSE -1*NETTOTAL END)) AS [Net Sales], 0 AS [Commision Amount] from StockInvoiceDetails where (VoucherName IN ('SI','POS','SR')) and isdelete=0 "
        SqlstrTotal = ""
        If IsDateWiseOn.Checked = True Then
            If TxtSalesPerson.Text = "*All" Or TxtSalesPerson.Text.Length = 0 Then
                SqlStr = SqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
                SqlstrTotal = SqlstrTotal & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
            Else
                SqlStr = SqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
                SqlstrTotal = SqlstrTotal & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
            End If

        Else
            If TxtSalesPerson.Text = "*All" Or TxtSalesPerson.Text.Length = 0 Then

            Else
                SqlStr = SqlStr & "  and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
                SqlstrTotal = SqlstrTotal & "  and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
            End If
        End If

        SqlStr = SqlStr & " GROUP BY SALESPERSON "
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        For i As Integer = 0 To TxtList.RowCount - 1
            TxtList.Item("Commision Amount", i).Value = TxtList.Item("Net Sales", i).Value * SQLGetNumericFieldValue("select per from salespersons where salespersonname=N'" & TxtList.Item("Salesman Name", i).Value & "'", "per") / 100
        Next

        Me.Cursor = Cursors.Default
        Try
            If TxtList.RowCount = 0 Then Exit Sub
            Me.TxtList.Columns("Salesman Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns("Salesman Name").Width = 150
          
            Me.TxtList.Columns("Sales Amount").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Sales Amount").Width = 130
            Me.TxtList.Columns("Sales Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("Returns Amount").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Returns Amount").Width = 130
            Me.TxtList.Columns("Returns Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("Net Sales").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Net Sales").Width = 130
            Me.TxtList.Columns("Net Sales").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("Commision Amount").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Commision Amount").Width = 130
            Me.TxtList.Columns("Commision Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception

        End Try

        TxtTotal1.Text = FormatNumber(SQLGetNumericFieldValue("SELECT SUM(nettotal) AS Tot from StockInvoiceDetails where (VoucherName='SI' or voucherName='POS')  and isdelete=0 " & SqlstrTotal, "Tot"), ErpDecimalPlaces, , , TriState.False)
        TxtTotal2.Text = FormatNumber(SQLGetNumericFieldValue("SELECT SUM(nettotal) AS Tot from StockInvoiceDetails where VoucherName='SR'  and isdelete=0  " & SqlstrTotal, "Tot"), ErpDecimalPlaces, , , TriState.False)

        TxtNetTotal.Text = FormatNumber(CDbl(TxtTotal1.Text) - CDbl(TxtTotal2.Text), ErpDecimalPlaces)

        If TxtSalesPerson.Text = "*All" Or TxtSalesPerson.Text.Length = 0 Then
        Else
            TxtCommPer.Text = SQLGetNumericFieldValue("select per from salespersons where salespersonname=N'" & TxtSalesPerson.Text & "'", "per")
            TxtCmAmount.Text = FormatNumber(CDbl(TxtNetTotal.Text) * CDbl(TxtCommPer.Text) / 100, ErpDecimalPlaces)
        End If

        Me.Cursor = Cursors.Default

    End Sub
    Sub LoadData()
        Me.Cursor = Cursors.WaitCursor

        Dim TempBS As New BindingSource
        If TxtSalesPerson.Text.Length = 0 Then
            TxtSalesPerson.Text = "*All"
        End If
        SqlStr = "select transdate as Date, ledgername as [Customer Name],qutono as [Invoice No], (CASE WHEN VOUCHERNAME IN ('SI','POS') THEN  NETTOTAL ELSE 0 END) AS [Sale Total] ,(CASE WHEN VOUCHERNAME='SR' THEN  NETTOTAL ELSE 0 END) AS [Return Total] ,transcode as [TransCode] from StockInvoiceDetails where (VoucherName IN ('SI','POS','SR')) and isdelete=0  "
        SqlstrTotal = ""
        If IsDateWiseOn.Checked = True Then
            If TxtSalesPerson.Text = "*All" Or TxtSalesPerson.Text.Length = 0 Then
                SqlStr = SqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
                SqlstrTotal = SqlstrTotal & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
            Else
                SqlStr = SqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
                SqlstrTotal = SqlstrTotal & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
            End If

        Else
            If TxtSalesPerson.Text = "*All" Or TxtSalesPerson.Text.Length = 0 Then

            Else
                SqlStr = SqlStr & "  and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
                SqlstrTotal = SqlstrTotal & "  and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
            End If
        End If


        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Me.Cursor = Cursors.Default

        Try
            If TxtList.RowCount = 0 Then Exit Sub
            Me.TxtList.Columns("TransCode").Visible = False
            Me.TxtList.Columns("Invoice No").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Invoice No").Width = 55

        

            Me.TxtList.Columns("Date").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Date").Width = 80
            Me.TxtList.Columns("Date").DefaultCellStyle.Format = "d"

            Me.TxtList.Columns("Customer Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns("Customer Name").Width = 150

        
            Me.TxtList.Columns("Sale Total").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Sale Total").Width = 130
            Me.TxtList.Columns("Sale Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("Return Total").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Return Total").Width = 130
            Me.TxtList.Columns("Return Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        Catch ex As Exception

        End Try
       
        TxtTotal1.Text = FormatNumber(SQLGetNumericFieldValue("SELECT SUM(nettotal) AS Tot from StockInvoiceDetails where (VoucherName='SI' or voucherName='POS')  and isdelete=0 " & SqlstrTotal, "Tot"), ErpDecimalPlaces, , , TriState.False)
        TxtTotal2.Text = FormatNumber(SQLGetNumericFieldValue("SELECT SUM(nettotal) AS Tot from StockInvoiceDetails where VoucherName='SR'  and isdelete=0  " & SqlstrTotal, "Tot"), ErpDecimalPlaces, , , TriState.False)

        TxtNetTotal.Text = FormatNumber(CDbl(TxtTotal1.Text) - CDbl(TxtTotal2.Text), ErpDecimalPlaces)

        If TxtSalesPerson.Text = "*All" Or TxtSalesPerson.Text.Length = 0 Then
        Else
            TxtCommPer.Text = SQLGetNumericFieldValue("select per from salespersons where salespersonname=N'" & TxtSalesPerson.Text & "'", "per")
            TxtCmAmount.Text = FormatNumber(CDbl(TxtNetTotal.Text) * CDbl(TxtCommPer.Text) / 100, ErpDecimalPlaces)
        End If

        Me.Cursor = Cursors.Default


    End Sub

    Private Sub salesmanreports_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub IncomingStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDef()
        LoadData()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub TxtFilterByLedger_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSalesPerson.SelectedIndexChanged
        If TxtSalesPerson.Text = "*All" Or TxtSalesPerson.Text.Length = 0 Then
            calpanel.Visible = False
        Else
            calpanel.Visible = True
        End If
        LoadData()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        LoadData()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If IsSummery.Checked = False Then
            Me.Cursor = Cursors.WaitCursor
            Dim ds As New SalesmanReportDetDataSet
            ds.Clear()
            ds.Tables(0).Rows.Clear()

            For i As Integer = 0 To TxtList.RowCount - 1
                Dim row As DataRow
                row = ds.Tables("Datatable1").NewRow
                For k As Integer = 0 To TxtList.ColumnCount - 1
                    Try
                        row(TxtList.Columns(k).Name) = TxtList.Item(k, i).Value
                    Catch ex As Exception
                        row(TxtList.Columns(k).Name) = 0
                    End Try
                Next
                ds.Tables("Datatable1").Rows.Add(row)
            Next
            Dim reporttitle As String = ""
            If TxtSalesPerson.Text = "*All" Or TxtSalesPerson.Text.Length = 0 Then
                If IsDateWiseOn.Checked = True Then
                    reporttitle = "SALES PERSONS REPORT " & Chr(13) & " FOR PERIOD FROM " & FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " TO " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)
                Else
                    reporttitle = "SALES PERSONS REPORT"
                End If

            Else
                If IsDateWiseOn.Checked = True Then
                    reporttitle = "SALES PERSONS REPORT FOR " & UCase(TxtSalesPerson.Text) & Chr(13) & " FOR PERIOD FROM " & FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " TO " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)
                Else
                    reporttitle = "SALES PERSONS REPORT " & UCase(TxtSalesPerson.Text)
                End If
            End If
            Dim objRpt As New SalesPersonDetailedCRReport
            SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
            If PrintOptionsforCR.IsPrintHeader = False Then
                CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
                CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
                CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = reporttitle
            Else
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = reporttitle
            End If
            objRpt.SetDataSource(ds)
            Dim FRM As New ReportCommonForm(objRpt)
            FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            Me.Cursor = Cursors.Default
            FRM.ShowDialog()
            FRM.Dispose()
            objRpt.Dispose()
            ds.Dispose()
        Else
            Me.Cursor = Cursors.WaitCursor
            Dim ds As New SalesmanSummeryDataSet
            ds.Clear()
            ds.Tables(0).Rows.Clear()

            For i As Integer = 0 To TxtList.RowCount - 1
                Dim row As DataRow
                row = ds.Tables("Datatable1").NewRow
                For k As Integer = 0 To TxtList.ColumnCount - 1
                    Try
                        row(TxtList.Columns(k).Name) = TxtList.Item(k, i).Value
                    Catch ex As Exception
                        row(TxtList.Columns(k).Name) = 0
                    End Try
                Next
                ds.Tables("Datatable1").Rows.Add(row)
            Next
            Dim reporttitle As String = ""
            If IsDateWiseOn.Checked = True Then
                reporttitle = "SALES SUMMARY REPORT " & Chr(13) & " FOR PERIOD FROM " & FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " TO " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)
            Else
                reporttitle = "SALES SUMMARY REPORT"
            End If
            Dim objRpt As New SalesPersonSummeryCRReport
            SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
            If PrintOptionsforCR.IsPrintHeader = False Then
                CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
                CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
                CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = reporttitle
            Else
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = reporttitle
            End If
            objRpt.SetDataSource(ds)
            Dim FRM As New ReportCommonForm(objRpt)
            FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            Me.Cursor = Cursors.Default
            FRM.ShowDialog()
            FRM.Dispose()
            objRpt.Dispose()
            ds.Dispose()
        End If
       
    End Sub

    Private Sub IsSummery_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsSummery.CheckedChanged
        If IsSummery.Checked = True Then
            TxtSalesPerson.Enabled = False
            LoadSummeryData()
        Else
            TxtSalesPerson.Enabled = True
            LoadData()
        End If
    End Sub
End Class