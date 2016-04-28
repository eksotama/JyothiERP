Public Class StockAgingReportFrm

    Dim Sqlstr As String = ""
    Sub loadstockitems(Optional ByVal SearchString As String = "")
        Dim FirstStValue As Integer = Today.Date.ToOADate - CInt(TxtFirstS.Text)
        Dim FirstEdValue As Integer = Today.Date.ToOADate

        Dim SecondStValue As Integer = Today.Date.ToOADate - CInt(Txt2Svalue.Text)
        Dim SecondEdValue As Integer = Today.Date.ToOADate - CInt(Txt2Fvalue.Text)

        Dim ThirdStValue As Integer = Today.Date.ToOADate - CInt(Txt3SValue.Text)
        Dim ThirdEdValue As Integer = Today.Date.ToOADate - CInt(Txt3Fvalue.Text)

        Dim FourthStValue As Integer = Today.Date.ToOADate - CInt(Txt4value.Text)
        Dim FourthEdValue As Integer = Today.Date.ToOADate - 90


        Sqlstr = "SELECT STOCKCODE AS [Stock Code], stockname as [Stock Name],stocksize as [Stock Size], 0 as [<" & CInt(TxtFirstS.Text).ToString & " Days], 0 as [" & CInt(Txt2Fvalue.Text).ToString & " to " & CInt(Txt2Fvalue.Text).ToString & " Days], 0 as [" & CInt(Txt3Fvalue.Text).ToString & " to " & CInt(Txt3SValue.Text) & " Days], 0 as [Above " & CInt(Txt4value.Text) & " Days] from stockdbf "

        If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
        Else
            Sqlstr = Sqlstr & " where stockgroup=N'" & TxtStockGroup.Text & "' "
        End If
        Sqlstr = Sqlstr & SearchString
        If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
            Sqlstr = Sqlstr & " GROUP BY STOCKCODE,STOCKSIZE,stockname "
        Else
            Sqlstr = Sqlstr & " GROUP BY STOCKCODE,STOCKSIZE,stockname, LOCATION "
        End If

        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            If AppIsItemwithSize = False Then
                TxtList.Columns("Stock Size").Visible = False
            End If
            Me.TxtList.Columns("Stock Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Stock Code").Width = 180

            Me.TxtList.Columns("Stock Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Stock Name").Width = 180

            Me.TxtList.Columns("Stock Size").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Stock Size").Width = 100


            Me.TxtList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.TxtList.Columns(3).Width = 100

            Me.TxtList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.TxtList.Columns(4).Width = 100


            Me.TxtList.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.TxtList.Columns(5).Width = 100

            Me.TxtList.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.TxtList.Columns(6).Width = 100
        Catch ex As Exception
        End Try

        For I As Integer = 0 To TxtList.RowCount - 1
            If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
                Dim viewQstr As String = ""
                Dim SoldstockQty As Double = 0
                Dim Unitconverion As Double = 0
                Dim stockcode As String = ""
                Dim stocksize As String = ""
                Dim stockbatch As String = ""
                stockcode = TxtList.Item("stock code", I).Value
                stocksize = TxtList.Item("stock Size", I).Value

                Unitconverion = SQLGetNumericFieldValue("select unitcon from stockdbf  where STOCKCODE=N'" & stockcode & "' AND STOCKSIZE=N'" & stocksize & "' AND BATCHNO=N'" & stockbatch & "' ", "unitcon")
                SoldstockQty = SQLGetNumericFieldValue("SELECT (CASE WHEN SUM(TotalQty) IS NULL THEN 0 ELSE SUM(TOTALQTY) END) AS TOT FROM  StockInvoiceRowItems AS T2 WHERE (VoucherName IN ('SD', 'POS','SJout')) AND (Isdelete = 0) AND (StockCode =N'" & stockcode & "') AND (StockSize =N'" & stocksize & "') AND (BatchNo = N'" & stockbatch & "') ", "TOT")
                SoldstockQty = SoldstockQty - SQLGetNumericFieldValue("SELECT (CASE WHEN SUM(TotalQty) IS NULL THEN 0 ELSE SUM(TOTALQTY) END) AS TOT FROM  StockInvoiceRowItems AS T2 WHERE (VoucherName='SR') AND (Isdelete = 0) AND (StockCode =N'" & stockcode & "') AND (StockSize =N'" & stocksize & "') AND (BatchNo = N'" & stockbatch & "') ", "TOT")
                Dim currenttotalqty As Double = 0
                currenttotalqty = SQLGetNumericFieldValue("select totalqty from stockdbf where STOCKCODE=N'" & stockcode & "' AND STOCKSIZE=N'" & stocksize & "' AND BATCHNO=N'" & stockbatch & "' ", "totalqty")

                If currenttotalqty = 0 Then
                    currenttotalqty = 1
                Else
                    currenttotalqty = currenttotalqty / Unitconverion
                End If


                If SQLGetNumericFieldValue("SELECT OPTOTALQTY FROM STOCKDBF where STOCKCODE=N'" & stockcode & "' AND STOCKSIZE=N'" & stocksize & "' AND BATCHNO=N'" & stockbatch & "' ", "OPTOTALQTY") > 0 Then
                    viewQstr = "SELECT  0 AS SNo, 0 as TDateValue, OpTotalQty AS PQTY, OpstockRate AS RATE, " & SoldstockQty & " AS TSOLD FROM STOCKDBF where STOCKCODE=N'" & stockcode & "' AND STOCKSIZE=N'" & stocksize & "' AND BATCHNO=N'" & stockbatch & "'  UNION ALL "
                Else
                    viewQstr = ""
                End If


                viewQstr = viewQstr & "SELECT  ROW_NUMBER() OVER (ORDER BY TransDateValue,transcode) AS [SNo], TRANSDATEVALUE as TDateValue, (CASE WHEN VOUCHERNAME IN ('PG','SJIn','DP') THEN TotalQty ELSE 0 - TotalQty END) AS PQTY, " _
                & "StockRate AS RATE," & SoldstockQty & "  AS TSOLD " _
                & " FROM StockInvoiceRowItems AS T1  WHERE  (Isdelete = 0) AND (VoucherName IN ('PG', 'PR','SJin','DP')) AND  " _
                & " STOCKCODE=N'" & stockcode & "' AND STOCKSIZE=N'" & stocksize & "' AND BATCHNO=N'" & stockbatch & "' "

                PriceSQLQuery("DROP VIEW AFIFOVIEW")
                PriceSQLQuery("CREATE VIEW AFIFOVIEW AS " & viewQstr)



                Dim Qtystr As String = "SELECT TDATEVALUE, CASE WHEN EXPR1 - PQTY < 0 THEN EXPR1 ELSE PQTY END AS QTYHAND FROM (SELECT     SNo, PQTY, RATE, TSOLD,TRANSDATEVALUE," _
                                       & " (SELECT     SUM(PQTY) AS Expr1  FROM  dbo.AFIFOVIEW  WHERE      (SNo <= TB1.SNo)) - TSOLD AS Expr1    FROM  dbo.AFIFOVIEW AS TB1 " _
                                       & "  WHERE      ((SELECT     SUM(PQTY) AS Expr2  FROM  dbo.AFIFOVIEW AS AFIFOVIEW_1  WHERE     (SNo <= TB1.SNo)) - TSOLD > 0)) AS derivedtbl_1 "

                Qtystr = "SELECT SUM(CASE WHEN EXPR1 - PQTY < 0 THEN EXPR1 ELSE PQTY END) AS QTYHAND FROM (SELECT   TDateValue,   PQTY, " _
                          & " (SELECT     SUM(PQTY) AS Expr1  FROM  dbo.AFIFOVIEW  WHERE      (SNo <= TB1.SNo)) - TSOLD AS Expr1    FROM  dbo.AFIFOVIEW AS TB1 " _
                          & "  WHERE      ((SELECT     SUM(PQTY) AS Expr2  FROM  dbo.AFIFOVIEW AS AFIFOVIEW_1  WHERE     (SNo <= TB1.SNo)) - TSOLD > 0)) AS derivedtbl_1 "

                'PriceSQLQuery("DROP VIEW AQFIFOVIEW")
                'PriceSQLQuery("CREATE VIEW AQFIFOVIEW AS " & Qtystr)


                TxtList.Item(3, I).Value = SQLGetNumericFieldValue(Qtystr & " WHERE ( TDATEVALUE>" & FirstStValue & " AND TDATEVALUE<=" & FirstEdValue & ")", "QTYHAND")
                TxtList.Item(4, I).Value = SQLGetNumericFieldValue(Qtystr & " WHERE ( TDATEVALUE>" & SecondStValue & " AND TDATEVALUE<=" & SecondEdValue & ")", "QTYHAND")
                TxtList.Item(5, I).Value = SQLGetNumericFieldValue(Qtystr & " WHERE ( TDATEVALUE>" & ThirdStValue & " AND TDATEVALUE<=" & ThirdEdValue & ")", "QTYHAND")
                TxtList.Item(6, I).Value = SQLGetNumericFieldValue(Qtystr & " WHERE  (TDATEVALUE<" & FourthEdValue & ")", "QTYHAND")

            Else
                Dim viewQstr As String = ""
                Dim SoldstockQty As Double = 0
                Dim Unitconverion As Double = 0
                Dim stockcode As String = ""
                Dim stocksize As String = ""
                Dim stockbatch As String = ""
                Dim location As String = ""
                stockcode = TxtList.Item("stock code", I).Value
                stocksize = TxtList.Item("stock Size", I).Value
                location = TxtStockLocation.Text
                Unitconverion = SQLGetNumericFieldValue("select unitcon from stockdbf  where STOCKCODE=N'" & stockcode & "' AND STOCKSIZE=N'" & stocksize & "' AND BATCHNO=N'" & stockbatch & "' AND LOCATION=N'" & location & "'", "unitcon")
                SoldstockQty = SQLGetNumericFieldValue("SELECT (CASE WHEN SUM(TotalQty) IS NULL THEN 0 ELSE SUM(TOTALQTY) END) AS TOT FROM  StockInvoiceRowItems AS T2 WHERE (VoucherName IN ('SD', 'POS','SJout')) AND (Isdelete = 0) AND (StockCode =N'" & stockcode & "') AND (StockSize =N'" & stocksize & "') AND (BatchNo = N'" & stockbatch & "') AND (LOCATION=N'" & location & "')", "TOT")
                SoldstockQty = SoldstockQty - SQLGetNumericFieldValue("SELECT (CASE WHEN SUM(TotalQty) IS NULL THEN 0 ELSE SUM(TOTALQTY) END) AS TOT FROM  StockInvoiceRowItems AS T2 WHERE (VoucherName='SR') AND (Isdelete = 0) AND (StockCode =N'" & stockcode & "') AND (StockSize =N'" & stocksize & "') AND (BatchNo = N'" & stockbatch & "') AND (LOCATION=N'" & location & "')", "TOT")
                Dim currenttotalqty As Double = 0
                currenttotalqty = SQLGetNumericFieldValue("select totalqty from stockdbf where STOCKCODE=N'" & stockcode & "' AND STOCKSIZE=N'" & stocksize & "' AND BATCHNO=N'" & stockbatch & "' AND LOCATION=N'" & location & "'", "totalqty")

                If currenttotalqty = 0 Then
                    currenttotalqty = 1
                Else
                    currenttotalqty = currenttotalqty / Unitconverion
                End If


                If SQLGetNumericFieldValue("SELECT OPTOTALQTY FROM STOCKDBF where STOCKCODE=N'" & stockcode & "' AND STOCKSIZE=N'" & stocksize & "' AND BATCHNO=N'" & stockbatch & "' AND LOCATION=N'" & location & "'", "OPTOTALQTY") > 0 Then
                    viewQstr = "SELECT  0 AS SNo, 0 as TDateValue, OpTotalQty AS PQTY, OpstockRate AS RATE, " & SoldstockQty & " AS TSOLD FROM STOCKDBF where STOCKCODE=N'" & stockcode & "' AND STOCKSIZE=N'" & stocksize & "' AND BATCHNO=N'" & stockbatch & "' AND  LOCATION=N'" & location & "' UNION ALL "
                Else
                    viewQstr = ""
                End If


                viewQstr = viewQstr & "SELECT  ROW_NUMBER() OVER (ORDER BY TransDateValue,transcode) AS [SNo], TRANSDATEVALUE as TDateValue, (CASE WHEN VOUCHERNAME IN ('PG','SJIn','DP') THEN TotalQty ELSE 0 - TotalQty END) AS PQTY, " _
                & "StockRate AS RATE," & SoldstockQty & "  AS TSOLD " _
                & " FROM StockInvoiceRowItems AS T1  WHERE  (Isdelete = 0) AND (VoucherName IN ('PG', 'PR','SJin','DP')) AND  " _
                & " STOCKCODE=N'" & stockcode & "' AND STOCKSIZE=N'" & stocksize & "' AND BATCHNO=N'" & stockbatch & "' AND LOCATION=N'" & location & "'"

                PriceSQLQuery("DROP VIEW AFIFOVIEW")
                PriceSQLQuery("CREATE VIEW AFIFOVIEW AS " & viewQstr)



                Dim Qtystr As String = "SELECT TDATEVALUE, CASE WHEN EXPR1 - PQTY < 0 THEN EXPR1 ELSE PQTY END AS QTYHAND FROM (SELECT     SNo, PQTY, RATE, TSOLD,TRANSDATEVALUE," _
                                       & " (SELECT     SUM(PQTY) AS Expr1  FROM  dbo.AFIFOVIEW  WHERE      (SNo <= TB1.SNo)) - TSOLD AS Expr1    FROM  dbo.AFIFOVIEW AS TB1 " _
                                       & "  WHERE      ((SELECT     SUM(PQTY) AS Expr2  FROM  dbo.AFIFOVIEW AS AFIFOVIEW_1  WHERE     (SNo <= TB1.SNo)) - TSOLD > 0)) AS derivedtbl_1 "

                Qtystr = "SELECT SUM(CASE WHEN EXPR1 - PQTY < 0 THEN EXPR1 ELSE PQTY) END AS QTYHAND FROM (SELECT     SNo, PQTY, RATE, TSOLD,TRANSDATEVALUE," _
                          & " (SELECT     SUM(PQTY) AS Expr1  FROM  dbo.AFIFOVIEW  WHERE      (SNo <= TB1.SNo)) - TSOLD AS Expr1    FROM  dbo.AFIFOVIEW AS TB1 " _
                          & "  WHERE      ((SELECT     SUM(PQTY) AS Expr2  FROM  dbo.AFIFOVIEW AS AFIFOVIEW_1  WHERE     (SNo <= TB1.SNo)) - TSOLD > 0)) AS derivedtbl_1 "


                TxtList.Item(3, I).Value = SQLGetNumericFieldValue(Qtystr & " WHERE ( TDATEVALUE>" & FirstStValue & " AND TDATEVALUE<=" & FirstEdValue & ")", "QTYHAND")
                TxtList.Item(4, I).Value = SQLGetNumericFieldValue(Qtystr & " WHERE ( TDATEVALUE>" & SecondStValue & " AND TDATEVALUE<=" & SecondEdValue & ")", "QTYHAND")
                TxtList.Item(5, I).Value = SQLGetNumericFieldValue(Qtystr & " WHERE ( TDATEVALUE>" & ThirdStValue & " AND TDATEVALUE<=" & ThirdEdValue & ")", "QTYHAND")
                TxtList.Item(6, I).Value = SQLGetNumericFieldValue(Qtystr & " WHERE  (TDATEVALUE<" & FourthEdValue & ")", "QTYHAND")

            End If




        Next

    End Sub

    Private Sub StockAgingReportFrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub StockAgingReportFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loadstockitems()
        LoadDataIntoComboBox("SELECT DISTINCT LOCATION FROM STOCKDBF ", TxtStockLocation, "LOCATION")
        LoadDataIntoComboBox("SELECT DISTINCT STOCKGROUP FROM STOCKDBF ", TxtStockGroup, "STOCKGROUP")
    End Sub

    Private Sub btnreloadqty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreloadqty.Click, RefreshToolStripMenuItem.Click
        loadstockitems()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, PrintToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New StockAgingDataSet
        ds.Clear()
        For i As Integer = 0 To TxtList.RowCount - 1
            Dim row As DataRow
            row = ds.Tables(0).NewRow
            row("stockcode") = TxtList.Item("stock code", i).Value
            row("stockname") = TxtList.Item("stock Name", i).Value
            row("stocksize") = TxtList.Item("stock size", i).Value
            row("fqty") = TxtList.Item(3, i).Value
            row("sqty") = TxtList.Item(4, i).Value
            row("tqty") = TxtList.Item(5, i).Value
            row("foqty") = TxtList.Item(6, i).Value

            ds.Tables(0).Rows.Add(row)
        Next

        Dim objRpt As New StockAgingCRReport


        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Or TxtStockGroup.Text = "*Primary" Then
                CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
            Else
                CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text & " FOR '" & TxtStockGroup.Text & "' GROUP"
            End If
        Else
            If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Or TxtStockGroup.Text = "*Primary" Then
                CType(objRpt.Section2.ReportObjects.Item("TXTPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
            Else
                CType(objRpt.Section2.ReportObjects.Item("TXTPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text & " FOR '" & TxtStockGroup.Text & "' GROUP"
            End If
        End If
        CType(objRpt.Section2.ReportObjects.Item("txt1"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "< " & TxtFirstS.Text
        CType(objRpt.Section2.ReportObjects.Item("txt2"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = CInt(Txt2Fvalue.Text).ToString & " to " & CInt(Txt2Fvalue.Text).ToString & " Days"
        CType(objRpt.Section2.ReportObjects.Item("txt3"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = CInt(Txt3Fvalue.Text).ToString & " to " & CInt(Txt3SValue.Text) & " Days"
        CType(objRpt.Section2.ReportObjects.Item("txt4"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Above " & CInt(Txt4value.Text) & " Days"


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