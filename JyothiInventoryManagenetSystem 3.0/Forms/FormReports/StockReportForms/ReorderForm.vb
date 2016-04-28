Public Class ReorderForm
    Dim SqlStr As String = ""
    Dim FirstTime As Boolean = True
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub loaddata()


        If FirstTime = True Then Exit Sub
        If TxtShowTailUnit.Checked = True Then
            SqlStr = "select stockcode as [Item Code],stocksize as [More Info], " _
      & "(SELECT TOP 1 LEDGERNAME FROM StockInvoiceDetails WHERE TRANSDATEVALUE=(SELECT MAX(TRANSDATEVALUE ) FROM StockInvoiceRowItems WHERE StockInvoiceRowItems.STOCKCODE=STOCKDBF.STOCKCODE AND StockInvoiceRowItems.STOCKSIZE=STOCKDBF.STOCKSIZE) and (vouchername in ('PG','DP'))) AS [Supplier Name]  ," _
      & "(select avg(minqty) as mqty from stockdbf as k where (k.StockCode = StockDbf.StockCode) AND (k.StockSize = StockDbf.StockSize) ) as [Min Qty]," _
      & " ((SELECT CONVERT(VARCHAR(30),ISNULL(SUM(CASE WHEN VOUCHERNAME='SO' THEN TOTALQTY-USEDQTY ELSE 0 END),0)) FROM StockInvoiceRowItems WHERE StockInvoiceRowItems.STOCKCODE=STOCKDBF.STOCKCODE AND StockInvoiceRowItems.STOCKSIZE=STOCKDBF.STOCKSIZE and isdelete=0)+ ' ' + (SELECT (CASE WHEN UNITTYPE=0 THEN UNITNAME ELSE SUBUNITNAME END) AS K FROM STOCKUNITS WHERE STOCKUNITS.UNITNAME=STOCKDBF.BASEUNIT)) AS [SO Qty]," _
      & " (CONVERT(VARCHAR(30),SUM(totalqty))  + ' ' + (SELECT (CASE WHEN UNITTYPE=0 THEN UNITNAME ELSE SUBUNITNAME END) AS K FROM STOCKUNITS WHERE STOCKUNITS.UNITNAME=STOCKDBF.BASEUNIT)) as [Current Stock]," _
          & "  ((SELECT CONVERT(VARCHAR(30),ISNULL(SUM(CASE WHEN VOUCHERNAME='PO' THEN TOTALQTY-USEDQTY ELSE 0 END),0)) FROM StockInvoiceRowItems WHERE StockInvoiceRowItems.STOCKCODE=STOCKDBF.STOCKCODE AND StockInvoiceRowItems.STOCKSIZE=STOCKDBF.STOCKSIZE and isdelete=0)+ ' ' + (SELECT (CASE WHEN UNITTYPE=0 THEN UNITNAME ELSE SUBUNITNAME END) AS K FROM STOCKUNITS WHERE STOCKUNITS.UNITNAME=STOCKDBF.BASEUNIT)) AS [PO Qty]," _
  & " SUM(TotalQty)+((SELECT ISNULL(SUM(CASE WHEN VOUCHERNAME = 'PO' THEN TOTALQTY - USEDQTY ELSE 0 END),0) AS Expr12 FROM StockInvoiceRowItems AS StockInvoiceRowItems_1 WHERE (StockCode = StockDbf.StockCode) AND (StockSize = StockDbf.StockSize) and isdelete=0) +(select avg(minqty) as mqty from stockdbf as k where (k.StockCode = StockDbf.StockCode) AND (k.StockSize = StockDbf.StockSize))-(SELECT ISNULL(SUM(CASE WHEN VOUCHERNAME = 'SO' THEN TOTALQTY - USEDQTY ELSE 0 END),0) AS Expr12 FROM StockInvoiceRowItems AS StockInvoiceRowItems_1 WHERE(StockCode = StockDbf.StockCode) AND (StockSize = StockDbf.StockSize) and isdelete=0 )) AS [Reorder Qty] " _
  & " FROM STOCKDBF  where stocktype=0 "
        Else
            SqlStr = "select stockcode as [Item Code],stocksize as [More Info], " _
           & "(SELECT TOP 1 LEDGERNAME FROM StockInvoiceDetails WHERE TRANSDATEVALUE=(SELECT MAX(TRANSDATEVALUE ) FROM StockInvoiceRowItems WHERE StockInvoiceRowItems.STOCKCODE=STOCKDBF.STOCKCODE AND StockInvoiceRowItems.STOCKSIZE=STOCKDBF.STOCKSIZE) and (vouchername in ('PG','DP')) and isdelete=0) AS [Supplier Name]  ," _
           & "(select avg(minqty) as mqty from stockdbf as k where (k.StockCode = StockDbf.StockCode) AND (k.StockSize = StockDbf.StockSize) ) as [Min Qty]," _
           & " ((SELECT CONVERT(VARCHAR(30),ISNULL(SUM(CASE WHEN VOUCHERNAME='SO' THEN TOTALQTY-USEDQTY ELSE 0 END),0)) FROM StockInvoiceRowItems WHERE StockInvoiceRowItems.STOCKCODE=STOCKDBF.STOCKCODE AND StockInvoiceRowItems.STOCKSIZE=STOCKDBF.STOCKSIZE)) AS [SO Qty]," _
           & " (CONVERT(VARCHAR(30),SUM(totalqty)) ) as [Current Stock]," _
               & "  ((SELECT CONVERT(VARCHAR(30),ISNULL(SUM(CASE WHEN VOUCHERNAME='PO' THEN TOTALQTY-USEDQTY ELSE 0 END),0)) FROM StockInvoiceRowItems WHERE StockInvoiceRowItems.STOCKCODE=STOCKDBF.STOCKCODE AND StockInvoiceRowItems.STOCKSIZE=STOCKDBF.STOCKSIZE and isdelete=0)) AS [PO Qty]," _
       & "(CONVERT(VARCHAR(30),SUM(totalqty)) )+(((SELECT CONVERT(VARCHAR(30),ISNULL(SUM(CASE WHEN VOUCHERNAME='PO' THEN TOTALQTY-USEDQTY ELSE 0 END),0)) FROM StockInvoiceRowItems WHERE StockInvoiceRowItems.STOCKCODE=STOCKDBF.STOCKCODE AND StockInvoiceRowItems.STOCKSIZE=STOCKDBF.STOCKSIZE and isdelete=0))+(select avg(minqty) as mqty from stockdbf as k where (k.StockCode = StockDbf.StockCode) AND (k.StockSize = StockDbf.StockSize) )-((SELECT CONVERT(VARCHAR(30),ISNULL(SUM(CASE WHEN VOUCHERNAME='SO' THEN TOTALQTY-USEDQTY ELSE 0 END),0)) FROM StockInvoiceRowItems WHERE StockInvoiceRowItems.STOCKCODE=STOCKDBF.STOCKCODE AND StockInvoiceRowItems.STOCKSIZE=STOCKDBF.STOCKSIZE)))   AS [Reorder Qty] " _
       & " FROM STOCKDBF  where stocktype=0 "
        End If
        Try



            Dim Substr As String = ""
            If (TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All") Then

            Else
                Substr = " and stockgroup=N'" & TxtStockGroup.Text & "' "
            End If
            If (TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All") Then

            Else
                Substr = Substr & " and location=N'" & TxtStockLocation.Text & "'"
            End If


            SqlStr = SqlStr & Substr & " GROUP BY STOCKCODE,STOCKSIZE,BASEUNIT "
            Dim TempBS As New BindingSource
            With Me.TxtList
                TempBS.DataSource = SQLLoadGridData(SqlStr)
                If txtminqty.Text.Length > 0 Then
                    If TxtShowAll.Checked = True Then
                        TxtShowAll.Checked = False
                    Else
                        If TxtMaxQty.Text.Length > 0 Then
                            If CDbl(TxtMaxQty.Text) = 0 Then
                                TempBS.Filter = "[Reorder Qty] <=" & CDbl(txtminqty.Text)
                            Else
                                TempBS.Filter = "[Reorder Qty] >=" & CDbl(TxtMaxQty.Text) & " and [Reorder Qty] <=" & CDbl(txtminqty.Text)
                            End If
                        Else
                            TempBS.Filter = "[Reorder Qty] <=" & CDbl(txtminqty.Text)
                        End If
                    End If

                End If

                .AutoGenerateColumns = True
                .DataSource = TempBS
            End With
        Catch ex As Exception

        End Try
        '  TempBS.Filter = "REORDER QTY >0"

        Try
            'Current Stock
            'SO Qty
            'PO Qty
            'Reorder Qty
            'Min Qty
            TxtList.Columns("Current Stock").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Current Stock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Current Stock").Width = 120

            TxtList.Columns("SO Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("SO Qty").Width = 120
            TxtList.Columns("SO Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            TxtList.Columns("PO Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("PO Qty").Width = 120
            TxtList.Columns("PO Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TxtList.Columns("Reorder Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Reorder Qty").Width = 120
            TxtList.Columns("Reorder Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TxtList.Columns("Min Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Min Qty").Width = 120
            TxtList.Columns("Min Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TxtList.Columns("Item Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("Item Code").Width = 120

            If AppIsItemwithSize = False Then
                TxtList.Columns("More Info").Visible = False
            End If
            TxtList.Columns("SO Qty").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("PO Qty").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Reorder Qty").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Min Qty").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ReorderForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub ReorderForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select stockgroupname from stockgroups", TxtStockGroup, "stockgroupname", "*All")
        LoadDataIntoComboBox("select locationname  from StockLocations", TxtStockLocation, "locationname", "*All")
        FirstTime = False
        loaddata()
    End Sub


    Private Sub btnreloadqty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreloadqty.Click, RefreshToolStripMenuItem.Click
        loaddata()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub TxtShowAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShowAll.CheckedChanged
        loaddata()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New ReorderStatusDataset
        ds.Clear()
        For i As Integer = 0 To TxtList.RowCount - 1
            Dim row As DataRow
            row = ds.Tables(0).NewRow
            For k As Integer = 0 To TxtList.ColumnCount - 1
                row(TxtList.Columns(k).Name) = TxtList.Item(k, i).Value
            Next
            ds.Tables(0).Rows.Add(row)
        Next

        Dim objRpt As New ReorderStatusCRReport


        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Or TxtStockGroup.Text = "*Primary" Then
                CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "REORDER SUMMARY REPORT "
            Else
                CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "REORDER SUMMARY REPORT FOR '" & TxtStockGroup.Text & "' GROUP"
            End If
        Else
            If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Or TxtStockGroup.Text = "*Primary" Then
                CType(objRpt.Section1.ReportObjects.Item("TXTPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "REORDER SUMMARY REPORT "
            Else
                CType(objRpt.Section1.ReportObjects.Item("TXTPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "REORDER SUMMARY REPORT FOR '" & TxtStockGroup.Text & "' GROUP"
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

    Private Sub TxtStockGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockGroup.SelectedIndexChanged
        loaddata()
    End Sub

    Private Sub TxtStockLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockLocation.SelectedIndexChanged
        loaddata()
    End Sub

    Private Sub TxtShowTailUnit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShowTailUnit.CheckedChanged
        loaddata()
    End Sub
   
End Class