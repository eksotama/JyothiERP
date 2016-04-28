Imports System.Data.SqlClient

Public Class StockMovementAnalysis

    Dim SqlStrcust As String = ""
    Dim SqlstrSup As String = ""
    Dim reportTitle As String = ""
    Dim sQLSTRSUBGROUP1 As String = ""
    Dim sQLSTRSUBGROUP2 As String = ""
    Dim ISLOADING As Boolean = True
    Private Sub StockMovementAnalysis_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub StockMovementAnalysis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        '  LoadDataIntoComboBoxBindMethod("select distinct stockcode from stockdbf", TxtStockCode, "stockcode")
        LoadDataIntoComboBox("select locationname  from StockLocations", TxtStockLocation, "locationname", "*All")
        LoadDataIntoComboBox("select stockgroupname from stockgroups", TxtStockGroup, "stockgroupname", "*All")
        ISLOADING = False
        If TxtStockGroup.Items.Count > 0 Then
            TxtStockGroup.SelectedIndex = 0
        End If
    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Private Sub TxtList1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList1.DataError

    End Sub
    Public Sub LOADDATA()
        If ISLOADING = True Then Exit Sub
        MainForm.Cursor = Cursors.WaitCursor
        Dim stgroupstr As String = ""
        If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
        Else
            stgroupstr = "and (stockcode in (select stockcode from stockdbf where stockgroup=N'" & TxtStockGroup.Text & "'))  "
        End If
        If IsDateWiseOn.Checked = True Then
            stgroupstr = stgroupstr & " and (StockInvoiceDetails.TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & " ) "
        End If
        Dim substrig As String = ""
        If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
            SqlStrcust = "select StockInvoiceDetails.LedgerName as [Account Name], (CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainunit ELSE (CASE CAST(SUM(TotalQty) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST(SUM(TotalQty) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END) AS [Total Qty],AVG(STOCKRATE) AS [RATE],SUM(STOCKAMOUNT) AS [VALUE] " _
           & " FROM StockInvoiceRowItems INNER JOIN StockInvoiceDetails ON StockInvoiceDetails.TransCode = StockInvoiceRowItems.TransCode " _
           & " WHERE STOCKCODE=N'" & TxtStockCode.Text & "' and StockInvoiceRowItems.vouchername in ('SD','POS') and StockInvoiceRowItems.isdelete=0 " & stgroupstr _
           & " GROUP BY StockInvoiceDetails.LedgerName,StockInvoiceRowItems.Stocksize, StockInvoiceRowItems.BaseUnit, StockInvoiceRowItems.MainUnit, StockInvoiceRowItems.SubUnit,StockInvoiceRowItems.UnitCon "
            substrig = " FROM StockInvoiceRowItems INNER JOIN StockInvoiceDetails ON StockInvoiceDetails.TransCode = StockInvoiceRowItems.TransCode " _
                    & " WHERE STOCKCODE=N'" & TxtStockCode.Text & "' and StockInvoiceRowItems.vouchername in ('SD','POS') and StockInvoiceRowItems.isdelete=0 " & stgroupstr _
                    & " GROUP BY StockInvoiceDetails.LedgerName,StockInvoiceRowItems.Stocksize, StockInvoiceRowItems.BaseUnit, StockInvoiceRowItems.MainUnit, StockInvoiceRowItems.SubUnit,StockInvoiceRowItems.UnitCon "

        Else
            SqlStrcust = "select StockInvoiceDetails.LedgerName as [Account Name], (CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainunit ELSE (CASE CAST(SUM(TotalQty) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST(SUM(TotalQty) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END) AS [Total Qty],AVG(STOCKRATE) AS [RATE],SUM(STOCKAMOUNT) AS [VALUE] " _
                       & " FROM StockInvoiceRowItems INNER JOIN StockInvoiceDetails ON StockInvoiceDetails.TransCode = StockInvoiceRowItems.TransCode " _
                       & " WHERE STOCKCODE=N'" & TxtStockCode.Text & "' and StockInvoiceRowItems.vouchername in ('SD','POS') and location=N'" & TxtStockLocation.Text & "' and StockInvoiceRowItems.isdelete=0 " & stgroupstr _
                       & " GROUP BY StockInvoiceDetails.LedgerName,StockInvoiceRowItems.Stocksize, StockInvoiceRowItems.BaseUnit, StockInvoiceRowItems.MainUnit, StockInvoiceRowItems.SubUnit,StockInvoiceRowItems.UnitCon "
            substrig = " FROM StockInvoiceRowItems INNER JOIN StockInvoiceDetails ON StockInvoiceDetails.TransCode = StockInvoiceRowItems.TransCode " _
                    & " WHERE STOCKCODE=N'" & TxtStockCode.Text & "' and StockInvoiceRowItems.vouchername in ('SD','POS') and location=N'" & TxtStockLocation.Text & "' and StockInvoiceRowItems.isdelete=0 " & stgroupstr _
                    & " GROUP BY StockInvoiceDetails.LedgerName,StockInvoiceRowItems.Stocksize, StockInvoiceRowItems.BaseUnit, StockInvoiceRowItems.MainUnit, StockInvoiceRowItems.SubUnit,StockInvoiceRowItems.UnitCon "

        End If
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStrcust)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        'Dim TOTQTY As Double
        'Dim qtystr As String = ""
        'TOTQTY = SQLGetNumericFieldValue("select sum(TOTALQTY) as tot " & substrig, "tot")
        'qtystr = "select (CASE unittype  WHEN 0 THEN CONVERT(varchar(30), floor(" & TOTQTY & " / Unitconversion)) + ' ' + Unitname ELSE (CASE CAST(" & TOTQTY & " AS INT) % CAST(Unitconversion AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor(" & TOTQTY & " / Unitconversion)) + ' ' + mainunitname) ELSE (CONVERT(varchar(30), floor(" & TOTQTY & " / Unitconversion)) + ' ' + mainunitname + ' ' + CONVERT(varchar(30), CAST(" & TOTQTY & " AS INT) % CAST(Unitconversion AS INT)) + ' ' + subunitname) END) END) as tot from stockunits where (UNITNAME=(SELECT DISTINCT BASEUNIT FROM STOCKDBF WHERE STOCKCODE=N'" & TxtStockCode.Text & "'))"
        'TxtTotal1.Text = FormatNumber(SQLGetStringFieldValue(qtystr, "TOT"), 2)
        TxtTotal2.Text = FormatNumber(SQLGetNumericFieldValue("select avg(stockrate) as tot " & substrig, "tot"), ErpDecimalPlaces)
        TxtTotal3.Text = FormatNumber(SQLGetNumericFieldValue("select sum(stockamount) as tot " & substrig, "tot"), ErpDecimalPlaces)

        Try
            TxtList.Columns("Account Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("Account Name").Width = 300


            TxtList.Columns("Total Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Total Qty").Width = 90
            TxtList.Columns("Total Qty").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

            TxtList.Columns("RATE").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("RATE").Width = 90
            TxtList.Columns("RATE").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("RATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

            TxtList.Columns("VALUE").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("VALUE").Width = 90
            TxtList.Columns("VALUE").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("VALUE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

        Catch ex As Exception

        End Try
        'and location=N'" & TxtStockLocation.Text & "' "
        If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
            SqlstrSup = "select StockInvoiceDetails.LedgerName as [Account Name], (CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainunit ELSE (CASE CAST(SUM(TotalQty) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST(SUM(TotalQty) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END) AS [Total Qty],AVG(STOCKRATE) AS [RATE],SUM(STOCKAMOUNT) AS [VALUE] " _
         & " FROM StockInvoiceRowItems INNER JOIN StockInvoiceDetails ON StockInvoiceDetails.TransCode = StockInvoiceRowItems.TransCode " _
         & " WHERE STOCKCODE=N'" & TxtStockCode.Text & "' and (StockInvoiceRowItems.vouchername in ('PG','DP')) and StockInvoiceRowItems.isdelete=0 " & stgroupstr _
         & " GROUP BY StockInvoiceDetails.LedgerName,StockInvoiceRowItems.Stocksize, StockInvoiceRowItems.BaseUnit, StockInvoiceRowItems.MainUnit, StockInvoiceRowItems.SubUnit,StockInvoiceRowItems.UnitCon "

            substrig = " FROM StockInvoiceRowItems INNER JOIN StockInvoiceDetails ON StockInvoiceDetails.TransCode = StockInvoiceRowItems.TransCode " _
                  & " WHERE STOCKCODE=N'" & TxtStockCode.Text & "' and (StockInvoiceRowItems.vouchername in ('PG','DP')) and StockInvoiceRowItems.isdelete=0 " & stgroupstr _
                      & " GROUP BY StockInvoiceDetails.LedgerName,StockInvoiceRowItems.Stocksize, StockInvoiceRowItems.BaseUnit, StockInvoiceRowItems.MainUnit, StockInvoiceRowItems.SubUnit,StockInvoiceRowItems.UnitCon "

        Else
            SqlstrSup = "select StockInvoiceDetails.LedgerName as [Account Name], (CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainunit ELSE (CASE CAST(SUM(TotalQty) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST(SUM(TotalQty) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END) AS [Total Qty],AVG(STOCKRATE) AS [RATE],SUM(STOCKAMOUNT) AS [VALUE] " _
         & " FROM StockInvoiceRowItems INNER JOIN StockInvoiceDetails ON StockInvoiceDetails.TransCode = StockInvoiceRowItems.TransCode " _
         & " WHERE STOCKCODE=N'" & TxtStockCode.Text & "' and (StockInvoiceRowItems.vouchername in ('PG','DP')) and location=N'" & TxtStockLocation.Text & "' and StockInvoiceRowItems.isdelete=0 " & stgroupstr _
         & " GROUP BY StockInvoiceDetails.LedgerName,StockInvoiceRowItems.Stocksize, StockInvoiceRowItems.BaseUnit, StockInvoiceRowItems.MainUnit, StockInvoiceRowItems.SubUnit,StockInvoiceRowItems.UnitCon "

            substrig = " FROM StockInvoiceRowItems INNER JOIN StockInvoiceDetails ON StockInvoiceDetails.TransCode = StockInvoiceRowItems.TransCode " _
                  & " WHERE STOCKCODE=N'" & TxtStockCode.Text & "' and (StockInvoiceRowItems.vouchername in ('PG','DP')) and location=N'" & TxtStockLocation.Text & "' and StockInvoiceRowItems.isdelete=0 " & stgroupstr _
                      & " GROUP BY StockInvoiceDetails.LedgerName,StockInvoiceRowItems.Stocksize, StockInvoiceRowItems.BaseUnit, StockInvoiceRowItems.MainUnit, StockInvoiceRowItems.SubUnit,StockInvoiceRowItems.UnitCon "

        End If

        Dim TempBS1 As New BindingSource
        With Me.TxtList1
            TempBS1.DataSource = SQLLoadGridData(SqlstrSup)
            .AutoGenerateColumns = True
            .DataSource = TempBS1
        End With

        TxtTotal5.Text = FormatNumber(SQLGetNumericFieldValue("select avg(stockrate) as tot " & substrig, "tot"), ErpDecimalPlaces)
        TxtTotal6.Text = FormatNumber(SQLGetNumericFieldValue("select sum(stockamount) as tot " & substrig, "tot"), ErpDecimalPlaces)
        Try
            TxtList1.Columns("Account Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList1.Columns("Account Name").Width = 300


            TxtList1.Columns("Total Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList1.Columns("Total Qty").Width = 90
            TxtList1.Columns("Total Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            TxtList1.Columns("Total Qty").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

            TxtList1.Columns("RATE").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList1.Columns("RATE").Width = 90
            TxtList1.Columns("RATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            TxtList1.Columns("RATE").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

            TxtList1.Columns("VALUE").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList1.Columns("VALUE").Width = 90
            TxtList1.Columns("VALUE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            TxtList1.Columns("VALUE").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

        Catch ex As Exception

        End Try
        lOADDETAILEDVIEW()
        MainForm.Cursor = Cursors.Default
    End Sub

    Private Sub TxtStockCode_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TxtStockCode.MouseClick
        Dim frm As New SelectItemCodeorName
        frm.ShowDialog()
        If SearchStockItemName.Length > 0 Then
            TxtStockCode.Items.Clear()
            TxtStockCode.Items.Add(SearchStockItemName)
            TxtStockCode.Text = SearchStockItemName
            LOADDATA()
        End If
    End Sub

    Private Sub TxtStockCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockCode.SelectedIndexChanged
        LOADDATA()
    End Sub

    Private Sub TxtStockLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockLocation.SelectedIndexChanged
        LOADDATA()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If SqlStrcust.Length = 0 Then Exit Sub
        If TxtList.RowCount = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If BtnBoth.Checked = True Then
            Dim ds As New MovementByStockCodeDataSet
            Dim cnn As SqlConnection
            cnn = New SqlConnection(ConnectionStrinG)
            cnn.Open()
            Dim dscmd As New SqlDataAdapter(SqlStrcust, cnn)
            dscmd.Fill(ds, "datatable1")

            Dim dscmd2 As New SqlDataAdapter(SqlstrSup, cnn)
            dscmd2.Fill(ds, "datatable2")

            cnn.Close()
            Dim objRpt As New MovementbyItemCodeCUSSUPCRReport
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
            If IsDateWiseOn.Checked = True Then
                CType(objRpt.Section1.ReportObjects.Item("txtPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "For Stock Code ; " & TxtStockCode.Text & " On Period : " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date
            Else
                CType(objRpt.Section1.ReportObjects.Item("txtPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "For Stock Code ; " & TxtStockCode.Text
            End If

            objRpt.SetDataSource(ds)
            Dim FRM As New ReportCommonForm(objRpt)
            FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

            FRM.ShowDialog()
            FRM.Dispose()
            objRpt.Dispose()
            ds.Dispose()
        ElseIf btnCustomersOnly.Checked = True Then
            Dim ds As New MovementByStockCodeDataSet
            Dim cnn As SqlConnection
            cnn = New SqlConnection(ConnectionStrinG)
            cnn.Open()
            Dim dscmd As New SqlDataAdapter(SqlStrcust, cnn)
            dscmd.Fill(ds, "datatable1")
            cnn.Close()
            Dim objRpt As New MovementSUPorCUSTCRReportByStockCode
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "CUSTOMERS WISE " & TxtHeading.Text
            If IsDateWiseOn.Checked = True Then
                CType(objRpt.Section1.ReportObjects.Item("txtPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "For Stock Code ; " & TxtStockCode.Text & " On Period : " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date
            Else
                CType(objRpt.Section1.ReportObjects.Item("txtPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "For Stock Code ; " & TxtStockCode.Text
            End If

            objRpt.SetDataSource(ds)
            Dim FRM As New ReportCommonForm(objRpt)
            FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

            FRM.ShowDialog()
            FRM.Dispose()
            objRpt.Dispose()
            ds.Dispose()
        Else
            Dim ds As New MovementByStockCodeDataSet
            Dim cnn As SqlConnection
            cnn = New SqlConnection(ConnectionStrinG)
            cnn.Open()
            Dim dscmd As New SqlDataAdapter(SqlstrSup, cnn)
            dscmd.Fill(ds, "datatable1")
            cnn.Close()
            Dim objRpt As New MovementSUPorCUSTCRReportByStockCode
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "SUPPLIER WISE " & TxtHeading.Text
            If IsDateWiseOn.Checked = True Then
                CType(objRpt.Section1.ReportObjects.Item("txtPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "For Stock Code ; " & TxtStockCode.Text & " On Period : " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date
            Else
                CType(objRpt.Section1.ReportObjects.Item("txtPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "For Stock Code ; " & TxtStockCode.Text
            End If

            objRpt.SetDataSource(ds)
            Dim FRM As New ReportCommonForm(objRpt)
            FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

            FRM.ShowDialog()
            FRM.Dispose()
            objRpt.Dispose()
            ds.Dispose()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnBoth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBoth.CheckedChanged, btnCustomersOnly.CheckedChanged, BtnSuppliersOnly.CheckedChanged
        On Error Resume Next
        If BtnBoth.Checked = True Then
            TableLayoutPanel3.ColumnStyles(0).SizeType = SizeType.Percent
            TableLayoutPanel3.ColumnStyles(0).Width = 50
            TableLayoutPanel3.ColumnStyles(1).SizeType = SizeType.Percent
            TableLayoutPanel3.ColumnStyles(1).Width = 50
        ElseIf btnCustomersOnly.Checked = True Then
            TableLayoutPanel3.ColumnStyles(0).SizeType = SizeType.Percent
            TableLayoutPanel3.ColumnStyles(0).Width = 100
            TableLayoutPanel3.ColumnStyles(1).SizeType = SizeType.Percent
            TableLayoutPanel3.ColumnStyles(1).Width = 0
        Else
            TableLayoutPanel3.ColumnStyles(0).SizeType = SizeType.Percent
            TableLayoutPanel3.ColumnStyles(0).Width = 0
            TableLayoutPanel3.ColumnStyles(1).SizeType = SizeType.Percent
            TableLayoutPanel3.ColumnStyles(1).Width = 100
        End If
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, PrintToolStripMenuItem.Click
        LOADDATA()

    End Sub

   

    Private Sub TxtList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellDoubleClick
        If TxtList.RowCount = 0 Then
            MsgBox("There is no data            ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtList.CurrentRow.Index >= 0 Then
            'Account Name
            Me.Cursor = Cursors.WaitCursor
            OutgoiningStock.SuspendLayout()
            OutgoiningStock.MdiParent = MainForm
            OutgoiningStock.Dock = DockStyle.Fill
            OutgoiningStock.TxtFilterByLedger.Text = TxtList.Item("Account Name", TxtList.CurrentRow.Index).Value
            OutgoiningStock.Show()
            OutgoiningStock.WindowState = FormWindowState.Maximized
            OutgoiningStock.BringToFront()
            OutgoiningStock.ResumeLayout()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub TxtStockGroup_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtStockGroup.SelectedIndexChanged
        LOADDATA()
    End Sub
    Sub lOADDETAILEDVIEW()

        Dim stgroupstr As String = ""
        If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
        Else
            stgroupstr = "and (stockcode in (select stockcode from stockdbf where stockgroup=N'" & TxtStockGroup.Text & "'))  "
        End If
        If IsDateWiseOn.Checked = True Then
            stgroupstr = stgroupstr & " and (StockInvoiceRowItems.TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & " ) "
        End If
        Dim substrig As String = "SELECT StockInvoiceDetails.LEDGERNAME,StockInvoiceRowItems.STOCKCODE,StockInvoiceRowItems.STOCKSIZE,StockInvoiceRowItems.TotalQty,StockInvoiceRowItems.STOCKRATE,StockInvoiceRowItems.STOCKAMOUNT  FROM StockInvoiceRowItems INNER JOIN  StockInvoiceDetails  ON StockInvoiceRowItems.TransCode =StockInvoiceDetails.TransCode  "
        If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
            sQLSTRSUBGROUP1 = substrig & "  WHERE  StockInvoiceRowItems.vouchername in ('SD','POS') and StockInvoiceRowItems.isdelete=0 " & stgroupstr
        Else
            sQLSTRSUBGROUP1 = substrig & "   WHERE StockInvoiceRowItems.vouchername in ('SD','POS') and location=N'" & TxtStockLocation.Text & "' and StockInvoiceRowItems.isdelete=0 " & stgroupstr
        End If

        If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
            sQLSTRSUBGROUP2 = substrig & "  WHERE  StockInvoiceRowItems.vouchername in ('PG','DP') and StockInvoiceRowItems.isdelete=0 " & stgroupstr
        Else
            sQLSTRSUBGROUP2 = substrig & "   WHERE StockInvoiceRowItems.vouchername in ('PG','DP') and location=N'" & TxtStockLocation.Text & "' and StockInvoiceRowItems.isdelete=0 " & stgroupstr
        End If

        Dim ds As New STOCKMOVEDETAIELDDATASET
        Dim ds2 As New STOCKMOVEDETAIELDDATASET
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(sQLSTRSUBGROUP1, cnn)
        dscmd.Fill(ds, "datatable1")
        Dim dscmd2 As New SqlDataAdapter(sQLSTRSUBGROUP2, cnn)
        dscmd2.Fill(ds2, "datatable1")
        cnn.Close()
        Dim objRpt As New StockMovenentDetailedCRReport
        CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
        CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
        CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "OUTWARDS  " & TxtHeading.Text
        If IsDateWiseOn.Checked = True Then
            CType(objRpt.Section1.ReportObjects.Item("txtPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "BY GROUPWISE [" & TxtStockGroup.Text & "]" & Chr(13) & " Period : " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date
        Else
            CType(objRpt.Section1.ReportObjects.Item("txtPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "BY GROUPWISE [" & TxtStockGroup.Text & "]" & Chr(13) & "FOR ALL DATES"
        End If
        objRpt.SetDataSource(ds)
        CrystalReportViewer2.ReportSource = objRpt


        Dim objRpt2 As New StockMovenentDetailedCRReport_Out
        CType(objRpt2.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
        CType(objRpt2.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
        CType(objRpt2.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "INWARDS  " & TxtHeading.Text
        If IsDateWiseOn.Checked = True Then
            CType(objRpt2.Section1.ReportObjects.Item("txtPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "BY GROUPWISE [" & TxtStockGroup.Text & "]" & Chr(13) & " Period : " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date
        Else
            CType(objRpt2.Section1.ReportObjects.Item("txtPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "BY GROUPWISE [" & TxtStockGroup.Text & "]" & Chr(13) & "FOR ALL DATES"
        End If
        objRpt2.SetDataSource(ds2)
        CrystalReportViewer1.ReportSource = objRpt2
        CrystalReportViewer1.Refresh()
        CrystalReportViewer2.Refresh()
    End Sub
End Class