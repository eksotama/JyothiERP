Imports System.Data.SqlClient

Public Class PurchaseRegister
    Dim SqlStr As String = ""
    Dim SqlStrTotal As String = ""
    Dim SqlGroupStr As String = ""
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Private Sub Txtgrid_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtGrid.DataError

    End Sub
    Sub LoadReport()
      
        Me.Cursor = Cursors.WaitCursor
        Dim TempBS As New BindingSource
        TxtTotals.Text = "0.000"
        If TxtLedgerName.Text.Length = 0 Then
            TxtLedgerName.Text = "*All"
        End If
        SqlStrTotal = "SELECT SUM(nettotal) AS Tot from StockInvoiceDetails where VoucherName IN ('PI','DP') "
        If IsLedgerCurrency.Checked = True Then
            SqlStr = "select  QutoNo as [Invoice No],QutoRef as [Ref No],TransDate as [Date], LedgerName as [Supplier Name],SalesPerson as [Sales Person] , grosstotal*CurrencyCon1 as [Gross],Additions*CurrencyCon1 as [Additions],Deductions*CurrencyCon1 as [Deductions], (Currency + ' ' + CONVERT(varchar(30), CAST (nettotal*CurrencyCon1 AS DECIMAL(15,3)),1))  as [Net Total],TransCode as [Trans Code] from StockInvoiceDetails where (VoucherName IN ('PI','DP')) and isdelete=0 "
        Else
            SqlStr = "select  QutoNo as [Invoice No],QutoRef as [Ref No],TransDate as [Date], LedgerName as [Supplier Name],SalesPerson as [Sales Person] , grosstotal as [Gross],Additions as [Additions],Deductions as [Deductions], CONVERT(varchar(30), CAST (nettotal AS DECIMAL(15,3)),1)  as [Net Total],TransCode as [Trans Code] from StockInvoiceDetails where (VoucherName IN ('PI','DP')) and isdelete=0  "
        End If

        If TxtIsPeriod.Checked = True Then
            If TxtLedgerName.Text = "*All" Or TxtLedgerName.Text.Length = 0 Then
                SqlStr = SqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
                SqlStrTotal = SqlStrTotal & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
            Else
                SqlStr = SqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "')"
                SqlStrTotal = SqlStrTotal & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "')"
            End If
        Else
            If TxtLedgerName.Text = "*All" Then


            Else
                SqlStr = SqlStr & "  and Transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "')"
                SqlStrTotal = SqlStrTotal & "  and Transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "')"
            End If
        End If

        If TxtSalesAc.Text.Length = 0 Or TxtSalesAc.Text = "*All" Then
        Else
            SqlStr = SqlStr & " and AccountLedgerName=N'" & TxtSalesAc.Text & "'"
            SqlStrTotal = SqlStrTotal & " and AccountLedgerName=N'" & TxtSalesAc.Text & "'"
        End If


        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            Me.TxtList.Columns("Trans Code").Visible = False
            Me.TxtList.Columns("Invoice No").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Invoice No").Width = 55
            Me.TxtList.Columns("Ref No").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Ref No").Width = 55

            Me.TxtList.Columns("Date").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Date").Width = 80
            Me.TxtList.Columns("Date").DefaultCellStyle.Format = "d"

            Me.TxtList.Columns("Supplier Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns("Supplier Name").Width = 150

            Me.TxtList.Columns("Sales Person").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Sales Person").Width = 150
            Me.TxtList.Columns("Sales Person").Visible = False
            Me.TxtList.Columns("Gross").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Gross").Width = 130
            Me.TxtList.Columns("Gross").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            Me.TxtList.Columns("Additions").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Additions").Width = 130
            Me.TxtList.Columns("Additions").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            Me.TxtList.Columns("Deductions").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Deductions").Width = 130
            Me.TxtList.Columns("Deductions").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("Net Total").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Net Total").Width = 130
            Me.TxtList.Columns("Net Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight



        Catch ex As Exception

        End Try
        Dim Tot As Double
        Tot = FormatNumber(SQLGetNumericFieldValue(SqlStrTotal, "Tot"), ErpDecimalPlaces, , , TriState.False)
        TxtTotals.Text = CompDetails.Currency & " " & Tot.ToString
        Me.Cursor = Cursors.Default

    End Sub
    Sub LoadItemWiseReport()
        Me.Cursor = Cursors.WaitCursor

        Dim TempBS As New BindingSource
        TxtTotals.Text = "0.000"
        If TxtLedgerName.Text.Length = 0 Then
            TxtLedgerName.Text = "*All"
        End If
        Dim sqlStrGroup As String
        sqlStrGroup = " GROUP BY StockCode,StockName, StockSize, BaseUnit, UnitCon, MainUnit,SubUnit"
        SqlGroupStr = "SELECT StockCode as [Stock Code],StockName as [Stock Name],StockSize as [Stock Size],SUM(TotalQty) AS [Base Qty], (CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainunit ELSE (CASE CAST(SUM(TotalQty) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST(SUM(TotalQty) AS INT) % CAST(UnitCon AS INT))+ ' ' + subUnit) END) END) AS [Total Qty], sum(stockamount) as [Stock Value] FROM StockInvoiceRowItems where (vouchername in ('PI','DP')) and isdelete=0 "

        If TxtIsPeriod.Checked = True Then
            If TxtLedgerName.Text = "*All" Or TxtLedgerName.Text.Length = 0 Then
                SqlGroupStr = SqlGroupStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"

            Else
                SqlGroupStr = SqlGroupStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "')"

            End If
        Else
            If TxtLedgerName.Text = "*All" Or TxtLedgerName.Text.Length = 0 Then

            Else
                SqlGroupStr = SqlGroupStr & " and Transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "')"

            End If
        End If
        If TxtStockGroup.Text = "*All" Or TxtStockGroup.Text.Length = 0 Then
        Else
            SqlGroupStr = SqlGroupStr & " and stockcode in (select stockcode from stockdbf where stockgroup=N'" & TxtStockGroup.Text & "')"
        End If

        SqlGroupStr = SqlGroupStr & sqlStrGroup
        With Me.TxtGrid
            TempBS.DataSource = SQLLoadGridData(SqlGroupStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try

            Me.TxtGrid.Columns("Stock Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtGrid.Columns("Stock Code").Width = 180
            'Stock Name
            Me.TxtGrid.Columns("Stock Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtGrid.Columns("Stock Name").Width = 180


            Me.TxtGrid.Columns("Stock Size").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtGrid.Columns("Stock Size").Width = 150

            Me.TxtGrid.Columns("Base Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtGrid.Columns("Base Qty").Width = 180
            Me.TxtGrid.Columns("Base Qty").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtGrid.Columns("Base Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtGrid.Columns("Total Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtGrid.Columns("Total Qty").Width = 180

            Me.TxtGrid.Columns("Stock Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtGrid.Columns("Stock Value").Width = 120
            Me.TxtGrid.Columns("Stock Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtGrid.Columns("Stock Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Catch ex As Exception

        End Try
        Dim ttotal As Double = 0
        For i As Integer = 0 To TxtGrid.RowCount - 1
            ttotal = ttotal + CDbl(TxtGrid.Item("Stock Value", i).Value)
        Next
        TxtTotals.Text = FormatNumber(ttotal, ErpDecimalPlaces, , , TriState.False)
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub UserButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton2.Click
        If TxtShowItemDetails.Checked = True Then
            LoadItemWiseReport()
        Else
            LoadReport()
        End If
    End Sub

    Private Sub TxtLedgerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.SelectedIndexChanged
        If TxtShowItemDetails.Checked = True Then
            LoadItemWiseReport()
        Else
            LoadReport()
        End If
    End Sub

    Private Sub TxtSalesPerson_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TxtShowItemDetails.Checked = True Then
            LoadItemWiseReport()
        Else
            LoadReport()
        End If
    End Sub

    Private Sub IsLedgerCurrency_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsLedgerCurrency.CheckedChanged
        If TxtShowItemDetails.Checked = True Then
            LoadItemWiseReport()
        Else
            LoadReport()
        End If
    End Sub

    Private Sub PurchaseRegister_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub SalesRegister_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        LoadDataIntoComboBox("select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "')", TxtLedgerName, "ledgername", "*All")
        LoadDataIntoComboBox("select stockgroupname from stockgroups", TxtStockGroup, "stockgroupname", "*All")
        LoadDataIntoComboBox("select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')", TxtSalesAc, "ledgername", "*All")
        TxtList.Visible = True
        TxtList.Dock = DockStyle.Fill
        TxtGrid.Visible = False
        LoadReport()
    End Sub


    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If APPUserRights.IsEditable = False Then
            MsgBox("The Edit Restricted by the Admin, Not possible to Edit......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Selec the Row to Edit.....", MsgBoxStyle.Information)
            Exit Sub
        End If
        If MsgBox("Do you want to Edit ?         ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            'Trans Code

            Dim frm As New InvoiceAlterForm
            frm.TxtTitle.Text = "ALTER PURCHASE "
            Dim K As New PurchaseControlAll(SQLGetStringFieldValue("SELECT VOUCHERNAME FROM StockInvoiceDetails WHERE TRANSCODE=" & TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value, "VOUCHERNAME"), TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value, SQLGetStringFieldValue("SELECT transtype FROM StockInvoiceDetails WHERE TRANSCODE=" & TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value, "transtype"))
            K.BtnNew.Enabled = False
            K.BtnOpen.Enabled = False
            frm.TxtList.Controls.Add(K)
            frm.TxtList.Controls(0).Dock = DockStyle.Fill
            frm.WindowState = FormWindowState.Maximized
            frm.ShowDialog()
            frm.Dispose()
            K.Dispose()
            LoadReport()
        End If

    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, PrintToolStripMenuItem.Click

        If TxtShowItemDetails.Checked = True Then
            If SqlStr.Length = 0 Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            Dim ds As New DataSet
            Dim cnn As SqlConnection
            cnn = New SqlConnection(ConnectionStrinG)
            cnn.Open()
            Dim dscmd As New SqlDataAdapter(SqlGroupStr, cnn)
            dscmd.Fill(ds, "StockInvoiceRowItems")
            cnn.Close()
            Dim objRpt As New RegiterSumCrReport
            

            SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
            If PrintOptionsforCR.IsPrintHeader = False Then
                CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
                CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
                CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "PURCHASE REGISTER"
                If TxtIsPeriod.Checked = True Then
                    CType(objRpt.Section1.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True
                    CType(objRpt.Section1.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " To " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)
                End If

            Else

                If TxtIsPeriod.Checked = True Then
                    CType(objRpt.Section1.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True
                    CType(objRpt.Section1.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "PURCHASE REGISTER" & Chr(13) & "  Period From " & FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " To " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)
                Else
                    CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "PURCHASE REGISTER"
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

        Else

            If SqlStr.Length = 0 Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            Dim ds As New DataSet
            Dim cnn As SqlConnection
            cnn = New SqlConnection(ConnectionStrinG)
            cnn.Open()
            Dim dscmd As New SqlDataAdapter(SqlStr, cnn)
            dscmd.Fill(ds, "StockInvoiceDetails")
            cnn.Close()
            Dim objRpt As New RegisterCRReport


            SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
            If PrintOptionsforCR.IsPrintHeader = False Then
                CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
                CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
                CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "PURCHASE REGISTER"
                If TxtIsPeriod.Checked = True Then
                    CType(objRpt.Section1.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " To " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)
                End If

            Else

                If TxtIsPeriod.Checked = True Then
                    CType(objRpt.Section1.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "PURCHASE REGISTER" & Chr(13) & "  Period From " & FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " To " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)
                Else
                    CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "PURCHASE REGISTER"
                End If

            End If

            CType(objRpt.Section4.ReportObjects.Item("txtnettotal"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtTotals.Text
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

    Private Sub TxtShowItemDetails_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShowItemDetails.CheckedChanged
        If TxtShowItemDetails.Checked = True Then
            TxtGrid.Visible = True
            TxtList.Visible = False
            BtnEdit.Visible = False
            ImSlabel4.Visible = True
            TxtStockGroup.Visible = True
            TxtGrid.Dock = DockStyle.Fill
            LoadItemWiseReport()
        Else
            TxtGrid.Visible = False
            ImSlabel4.Visible = False
            TxtStockGroup.Visible = False
            TxtList.Visible = True
            BtnEdit.Visible = True
            TxtGrid.Dock = DockStyle.Fill
            LoadReport()
        End If
    End Sub

    Private Sub TxtStockGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockGroup.SelectedIndexChanged
        If TxtShowItemDetails.Checked = True Then
            LoadItemWiseReport()
        Else
            TxtShowItemDetails.Checked = True
        End If
    End Sub

    Private Sub TxtSalesAc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSalesAc.SelectedIndexChanged
        If TxtShowItemDetails.Checked = False Then
            LoadReport()
        Else
            TxtShowItemDetails.Checked = False
        End If
    End Sub
End Class