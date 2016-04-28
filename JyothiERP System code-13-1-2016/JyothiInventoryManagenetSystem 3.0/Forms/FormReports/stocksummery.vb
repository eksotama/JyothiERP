Imports System.Data.SqlClient

Public Class stocksummery
    'PLEASE DONT CHANGE THE GRIDVIEW  COLUMN NAME, IT WILL BE EFFECT IN DATASET FOR THE REPORTTS
    ' HERE IS THE CODE , DON'T CHANGE THE NAMES 
    ' SQLSTR="SELECT STOCKCODE AS [STOCK CODE] ....." DONT CHANGE THE [STOCK CODE]
    'SO, INSTEAD OF THE COLUMN NAME, PLEASE CHANGE THE HEADERTEXT PROPERTY OF THE GRID.
    ' YOU CAN CHANGE THE HEADERTEXT
    'FOR EXAMPLE
    ' TxtList.Columns("Item Code").HeaderText = "STOCK NAME(ANY TEXT)"

    Dim sQLSTR As String = ""
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadData()
        MainForm.Cursor = Cursors.WaitCursor
        Dim TotalWhereSQL As String = ""
        Dim TotalDbfWhereSQL As String = ""
        Dim DateSQLStr As String = ""
        If TxtIsPeriod.Checked = True Then
            DateSQLStr = " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Isdelete=0"
            TotalWhereSQL = " (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Isdelete=0"
            If TxtLocation.Text.Length = 0 Or TxtLocation.Text = "*All" Then
            Else
                DateSQLStr = DateSQLStr & " and location=N'" & TxtLocation.Text & "' "
                TotalDbfWhereSQL = TotalDbfWhereSQL & " and location=N'" & TxtLocation.Text & "' "
                TotalWhereSQL = TotalWhereSQL & " and location=N'" & TxtLocation.Text & "' "
            End If
        Else
            DateSQLStr = " and Isdelete=0"
            TotalWhereSQL = " Isdelete=0 "
            If TxtLocation.Text.Length = 0 Or TxtLocation.Text = "*All" Then
            Else
                DateSQLStr = DateSQLStr & " and location=N'" & TxtLocation.Text & "' "
                TotalDbfWhereSQL = TotalDbfWhereSQL & " and location=N'" & TxtLocation.Text & "' "
                TotalWhereSQL = TotalWhereSQL & " and location=N'" & TxtLocation.Text & "' "
            End If

        End If
        If txtByItemName.Text.Length > 0 Then
            TotalDbfWhereSQL = TotalDbfWhereSQL & " and stockcode LIKE N'%" & txtByItemName.Text & "%' "
            TotalWhereSQL = TotalWhereSQL & " and stockcode LIKE N'%" & txtByItemName.Text & "%' "
            DateSQLStr = DateSQLStr & " and stockcode LIKE N'%" & txtByItemName.Text & "%' "
        End If
        If IsShowinSubUnits.Checked = True Then
            sQLSTR = " SELECT     StockCode AS [Item Code], StockSize AS [Item More Info], (CASE ISSIMPLEUNIT WHEN 1 THEN CONVERT(varchar(30), SUM(OpTotalQty))   + ' ' + BASEUNIT ELSE CONVERT(varchar(30), SUM(OpTotalQty)) + ' ' + SUBUNIT END) AS [Opening Qty], SUM(OpTotalQty * OpstockRate / UnitCon) AS [Opening Value], " _
                  & " (SELECT     (CASE StockDbf.ISSIMPLEUNIT WHEN 1 THEN CONVERT(varchar(30), SUM(CASE WHEN vouchername IN ('PG', 'DP')  THEN TIV.TotalQty ELSE 0 - TIV.totalqty END)) + ' ' + StockDbf.BASEUNIT ELSE CONVERT(varchar(30), SUM(CASE WHEN vouchername IN ('PG', 'DP') THEN TIV.TotalQty ELSE 0 - TIV.totalqty END)) + ' ' + StockDbf.SUBUNIT END) AS TOT  FROM          dbo.StockInvoiceRowItems AS TIV  WHERE      (StockCode = dbo.StockDbf.StockCode) AND (StockSize = dbo.StockDbf.StockSize) AND (VoucherName IN ('PG', 'DP','PR')) " & DateSQLStr & " )  AS [Inwards Qty], " _
                  & "  (SELECT     SUM((CASE WHEN vouchername IN ('PG', 'DP') THEN TIV1.TotalQty ELSE 0 - TIV1.totalqty END) * StockRate / UnitCon) AS TOT FROM          dbo.StockInvoiceRowItems AS TIV1   WHERE      (StockCode = dbo.StockDbf.StockCode) AND (StockSize = dbo.StockDbf.StockSize) AND (VoucherName IN ('PG', 'DP','PR')) " & DateSQLStr & " )    AS [Inwards Value]," _
                  & "  (SELECT     (CASE StockDbf.ISSIMPLEUNIT WHEN 1 THEN CONVERT(varchar(30), SUM(CASE WHEN vouchername IN ('SD', 'POS') THEN  TSin.TotalQty ELSE 0 - TSin.totalqty END)) + ' ' + StockDbf.BASEUNIT ELSE CONVERT(varchar(30), SUM(CASE WHEN vouchername IN ('SD', 'POS')  THEN TSin.TotalQty ELSE 0 - TSin.totalqty END)) + ' ' + StockDbf.SUBUNIT END) AS TOT  FROM          dbo.StockInvoiceRowItems AS TSin WHERE      (StockCode = dbo.StockDbf.StockCode) AND (StockSize = dbo.StockDbf.StockSize) AND (VoucherName IN ('SD', 'POS','SR')) " & DateSQLStr & " )    AS [Outwards Qty]," _
                  & "  (SELECT     SUM((CASE WHEN vouchername IN ('SD', 'POS') THEN TSo2.TotalQty ELSE 0 - TSo2.totalqty END) * StockRate / UnitCon) AS TOT  FROM          dbo.StockInvoiceRowItems AS TSo2  WHERE      (StockCode = dbo.StockDbf.StockCode) AND (StockSize = dbo.StockDbf.StockSize) AND (VoucherName IN ('SD', 'POS','SR'))" & DateSQLStr & ") AS [Outwards Value], " _
                  & "  SUM(TotalQty)  AS [Closing Qty], " _
                  & "  SUM(TotalQty * StockRate / UnitCon) AS [Closing Value] " _
                  & "  FROM StockDbf     WHERE (StockType = 0)  "
            If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
            Else
                sQLSTR = sQLSTR & " and stockgroup=N'" & TxtStockGroup.Text & "' "
                TotalWhereSQL = TotalWhereSQL & " and Stockcode in ( select stockcode from stockdbf  where stockgroup=N'" & TxtStockGroup.Text & "') "
                TotalDbfWhereSQL = TotalDbfWhereSQL & " and stockgroup=N'" & TxtStockGroup.Text & "' "
            End If

            If TxtCat.Text.Length = 0 Or TxtCat.Text = "*All" Then
            Else
                sQLSTR = sQLSTR & " and category=N'" & TxtCat.Text & "' "
                TotalWhereSQL = TotalWhereSQL & " and Stockcode in ( select stockcode from stockdbf  where category=N'" & TxtCat.Text & "')"
                TotalDbfWhereSQL = TotalDbfWhereSQL & " and category=N'" & TxtCat.Text & "' "
            End If
            If TxtLocation.Text.Length = 0 Or TxtLocation.Text = "*All" Then
            Else
                sQLSTR = sQLSTR & " and location=N'" & TxtLocation.Text & "' "
                TotalWhereSQL = TotalWhereSQL & " and location=N'" & TxtLocation.Text & "' "
                TotalDbfWhereSQL = TotalDbfWhereSQL & " and location=N'" & TxtLocation.Text & "' "
            End If

            If txtByItemName.Text.Length > 0 Then
                sQLSTR = sQLSTR & " and stockcode LIKE N'%" & txtByItemName.Text & "%' "
            End If

            sQLSTR = sQLSTR & "  GROUP BY StockCode, StockSize, SubUnit, BaseUnit, IsSimpleUnit "

        Else

            sQLSTR = " SELECT     StockCode AS [Item Code], StockSize AS [Item More Info], (CASE ISSIMPLEUNIT WHEN 1 THEN CONVERT(varchar(30), SUM(OpTotalQty))   + ' ' + BASEUNIT ELSE CONVERT(varchar(30), SUM(OpTotalQty)) + ' ' + SUBUNIT END) AS [Opening Qty], SUM(OpTotalQty * OpstockRate / UnitCon) AS [Opening Value], " _
                 & " (SELECT     SUM(CASE WHEN vouchername IN ('PG', 'DP')  THEN TIV.TotalQty ELSE 0 - TIV.totalqty END)  AS TOT  FROM          dbo.StockInvoiceRowItems AS TIV  WHERE      (StockCode = dbo.StockDbf.StockCode) AND (StockSize = dbo.StockDbf.StockSize) AND (VoucherName IN ('PG', 'DP','PR')) " & DateSQLStr & " )  AS [Inwards Qty], " _
                 & "  (SELECT     SUM((CASE WHEN vouchername IN ('PG', 'DP') THEN TIV1.TotalQty ELSE 0 - TIV1.totalqty END) * StockRate / UnitCon) AS TOT FROM          dbo.StockInvoiceRowItems AS TIV1   WHERE      (StockCode = dbo.StockDbf.StockCode) AND (StockSize = dbo.StockDbf.StockSize) AND (VoucherName IN ('PG', 'DP','PR')) " & DateSQLStr & " )    AS [Inwards Value]," _
                 & "  (SELECT     SUM(CASE WHEN vouchername IN ('SD', 'POS') THEN  TSin.TotalQty ELSE 0 - TSin.totalqty END) AS TOT  FROM          dbo.StockInvoiceRowItems AS TSin WHERE      (StockCode = dbo.StockDbf.StockCode) AND (StockSize = dbo.StockDbf.StockSize) AND (VoucherName IN ('SD', 'POS','SR')) " & DateSQLStr & " )    AS [Outwards Qty]," _
                 & "  (SELECT     SUM((CASE WHEN vouchername IN ('SD', 'POS') THEN TSo2.TotalQty ELSE 0 - TSo2.totalqty END) * StockRate / UnitCon) AS TOT  FROM          dbo.StockInvoiceRowItems AS TSo2  WHERE      (StockCode = dbo.StockDbf.StockCode) AND (StockSize = dbo.StockDbf.StockSize) AND (VoucherName IN ('SD', 'POS','SR'))" & DateSQLStr & ") AS [Outwards Value], " _
                 & "  SUM(TotalQty)  AS [Closing Qty], " _
                 & "  SUM(TotalQty * StockRate / UnitCon) AS [Closing Value] " _
                 & "  FROM StockDbf     WHERE (StockType = 0)  "

            If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
            Else
                sQLSTR = sQLSTR & " and stockgroup=N'" & TxtStockGroup.Text & "' "
                TotalWhereSQL = TotalWhereSQL & " and Stockcode in ( select stockcode from stockdbf  where stockgroup=N'" & TxtStockGroup.Text & "')"
                TotalDbfWhereSQL = TotalDbfWhereSQL & " and stockgroup=N'" & TxtStockGroup.Text & "' "
                'TotalDbfWhereSQL
            End If

            If TxtCat.Text.Length = 0 Or TxtCat.Text = "*All" Then
            Else
                sQLSTR = sQLSTR & " and category=N'" & TxtCat.Text & "' "
                TotalWhereSQL = TotalWhereSQL & " and Stockcode in ( select stockcode from stockdbf  where category=N'" & TxtCat.Text & "')"
                TotalDbfWhereSQL = TotalDbfWhereSQL & " and category=N'" & TxtCat.Text & "' "
            End If
            If TxtLocation.Text.Length = 0 Or TxtLocation.Text = "*All" Then
            Else
                sQLSTR = sQLSTR & " and location=N'" & TxtLocation.Text & "' "
                TotalWhereSQL = TotalWhereSQL & " and location=N'" & TxtLocation.Text & "' "
                TotalDbfWhereSQL = TotalDbfWhereSQL & " and location=N'" & TxtLocation.Text & "' "
            End If
            If txtByItemName.Text.Length > 0 Then
                sQLSTR = sQLSTR & " and stockcode LIKE N'%" & txtByItemName.Text & "%' "
            End If
            sQLSTR = sQLSTR & "  GROUP BY StockCode, StockSize, SubUnit, BaseUnit, IsSimpleUnit "

        End If

        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(sQLSTR)
            If IsHideZerovalue.Checked = True Then
                TempBS.Filter = " [Closing Value]<>0 "
            Else
                TempBS.Filter = ""
            End If
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Dim totopvalue As Double = 0
        Dim totoutvalue As Double = 0
        Dim totinvalue As Double = 0
        Dim totclvalue As Double = 0

        totopvalue = SQLGetNumericFieldValue("SELECT SUM(OpTotalQty * OpstockRate / UnitCon) AS TOT FROM STOCKDBF  WHERE (StockType = 0)   " & TotalDbfWhereSQL, "TOT")
        totinvalue = SQLGetNumericFieldValue("SELECT     SUM((CASE WHEN vouchername IN ('PG', 'DP') THEN TotalQty ELSE 0 - totalqty END) * StockRate / UnitCon) AS TOT FROM          dbo.StockInvoiceRowItems  where " & TotalWhereSQL & " AND (VoucherName IN ('PG', 'DP')) ", "TOT")
        totoutvalue = SQLGetNumericFieldValue("SELECT SUM((CASE WHEN vouchername IN ('SD', 'POS') THEN TotalQty ELSE 0 - totalqty END) * StockRate / UnitCon) AS TOT  FROM          dbo.StockInvoiceRowItems where  " & TotalWhereSQL & " AND (VoucherName IN ('SD', 'POS'))   ", "TOT")

        totclvalue = SQLGetNumericFieldValue("SELECT  SUM(TotalQty * StockRate / UnitCon) AS TOT FROM STOCKDBF  WHERE (StockType = 0)   " & TotalDbfWhereSQL, "TOT")



        Try
            TxtList.Columns("Opening Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Opening Qty").Width = 100
            TxtList.Columns("Opening Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TxtList.Columns("Opening Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Opening Value").Width = 100
            TxtList.Columns("Opening Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Opening Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Opening Value").DefaultCellStyle.DataSourceNullValue = "0"

            TxtList.Columns("Closing Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Closing Qty").Width = 100
            TxtList.Columns("Closing Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TxtList.Columns("Closing Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Closing Value").Width = 100
            TxtList.Columns("Closing Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Closing Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Closing Value").DefaultCellStyle.DataSourceNullValue = "0"

            TxtList.Columns("Outwards Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Outwards Value").Width = 100
            TxtList.Columns("Outwards Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Outwards Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Outwards Value").DefaultCellStyle.DataSourceNullValue = "0"

            TxtList.Columns("Outwards Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Outwards Qty").Width = 100
            TxtList.Columns("Outwards Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TxtList.Columns("Inwards Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Inwards Value").Width = 100
            TxtList.Columns("Inwards Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Inwards Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Inwards Value").DefaultCellStyle.DataSourceNullValue = "0"

            TxtList.Columns("Inwards Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Inwards Qty").Width = 100
            TxtList.Columns("Inwards Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Catch ex As Exception

        End Try

        'sumObject = table.Compute("Sum(Total)", "EmpID = 5")

        'For i As Integer = 0 To TxtList.RowCount - 1
        '    Try
        '        totopvalue = totopvalue + CDbl(TxtList.Item("Opening Value", i).Value)
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        totoutvalue = totoutvalue + CDbl(TxtList.Item("Outwards Value", i).Value)
        '    Catch ex As Exception

        '    End Try
        '    'Closing Value
        '    Try
        '        totinvalue = totinvalue + CDbl(TxtList.Item("Inwards Value", i).Value)
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        totclvalue = totclvalue + CDbl(TxtList.Item("Closing Value", i).Value)
        '    Catch ex As Exception

        '    End Try
        'Next
        TxttotalOp.Text = FormatNumber(totopvalue, ErpDecimalPlaces)
        TxtTotal2.Text = FormatNumber(totinvalue, ErpDecimalPlaces)
        TxtTotal3.Text = FormatNumber(totoutvalue, ErpDecimalPlaces)
        TxtTotal4.Text = FormatNumber(totclvalue, ErpDecimalPlaces)
        Try
            If AppIsItemwithSize = False Then
                TxtList.Columns("Item More Info").Visible = False
            End If
        Catch ex As Exception

        End Try
        MainForm.Cursor = Cursors.Default
    End Sub
    Sub Detailedview()
        TxtList.DataSource = Nothing
        Dim DateSQLStr As String = ""
        If TxtIsPeriod.Checked = True Then
            DateSQLStr = " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Isdelete=0"
            If TxtLocation.Text.Length = 0 Or TxtLocation.Text = "*All" Then
            Else
                DateSQLStr = DateSQLStr & " and location=N'" & TxtLocation.Text & "' "
            End If
        Else
            DateSQLStr = " and Isdelete=0"
            If TxtLocation.Text.Length = 0 Or TxtLocation.Text = "*All" Then
            Else
                DateSQLStr = DateSQLStr & " and location=N'" & TxtLocation.Text & "' "
            End If
        End If

        If IsShowinSubUnits.Checked = True Then
            sQLSTR = " SELECT     StockCode AS [Item Code], StockSize AS [Item More Info], (CASE ISSIMPLEUNIT WHEN 1 THEN CONVERT(varchar(30), SUM(OpTotalQty))   + ' ' + BASEUNIT ELSE CONVERT(varchar(30), SUM(OpTotalQty)) + ' ' + SUBUNIT END) AS [Opening Qty], SUM(OpTotalQty * OpstockRate / UnitCon) AS [Opening Value], " _
                  & " (SELECT     (CASE StockDbf.ISSIMPLEUNIT WHEN 1 THEN CONVERT(varchar(30), SUM(CASE WHEN vouchername IN ('PG', 'DP')  THEN TIV.TotalQty ELSE 0 - TIV.totalqty END)) + ' ' + StockDbf.BASEUNIT ELSE CONVERT(varchar(30), SUM(CASE WHEN vouchername IN ('PG', 'DP') THEN TIV.TotalQty ELSE 0 - TIV.totalqty END)) + ' ' + StockDbf.SUBUNIT END) AS TOT  FROM          dbo.StockInvoiceRowItems AS TIV  WHERE      (StockCode = dbo.StockDbf.StockCode) AND (StockSize = dbo.StockDbf.StockSize) AND (VoucherName IN ('PG', 'DP')) " & DateSQLStr & " )  AS [Inward Qty], " _
                  & "  (SELECT     SUM((CASE WHEN vouchername IN ('PG', 'DP') THEN TIV1.TotalQty ELSE 0 - TIV1.totalqty END) * StockRate / UnitCon) AS TOT FROM          dbo.StockInvoiceRowItems AS TIV1   WHERE      (StockCode = dbo.StockDbf.StockCode) AND (StockSize = dbo.StockDbf.StockSize) AND (VoucherName IN ('PG', 'DP')) " & DateSQLStr & " )    AS [Inward Value]," _
                  & "  (SELECT     (CASE StockDbf.ISSIMPLEUNIT WHEN 1 THEN CONVERT(varchar(30), SUM(CASE WHEN vouchername IN ('SD', 'POS') THEN  TSin.TotalQty ELSE 0 - TSin.totalqty END)) + ' ' + StockDbf.BASEUNIT ELSE CONVERT(varchar(30), SUM(CASE WHEN vouchername IN ('SD', 'POS')  THEN TSin.TotalQty ELSE 0 - TSin.totalqty END)) + ' ' + StockDbf.SUBUNIT END) AS TOT  FROM          dbo.StockInvoiceRowItems AS TSin WHERE      (StockCode = dbo.StockDbf.StockCode) AND (StockSize = dbo.StockDbf.StockSize) AND (VoucherName IN ('SD', 'POS')) " & DateSQLStr & " )    AS [Outward Qty]," _
                  & "  (SELECT     SUM((CASE WHEN vouchername IN ('SD', 'POS') THEN TSo2.TotalQty ELSE 0 - TSo2.totalqty END) * StockRate / UnitCon) AS TOT  FROM          dbo.StockInvoiceRowItems AS TSo2  WHERE      (StockCode = dbo.StockDbf.StockCode) AND (StockSize = dbo.StockDbf.StockSize) AND (VoucherName IN ('SD', 'POS'))" & DateSQLStr & ") AS [Outward Value], " _
                  & "  SUM(TotalQty)  AS [Closing Qty], " _
                  & "  SUM(TotalQty * StockRate / UnitCon) AS [Closing Value] " _
                  & "  FROM StockDbf     WHERE (StockType = 0)  "
            If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
            Else
                sQLSTR = sQLSTR & " and stockgroup=N'" & TxtStockGroup.Text & "' "
            End If

            If TxtCat.Text.Length = 0 Or TxtCat.Text = "*All" Then
            Else
                sQLSTR = sQLSTR & " and category=N'" & TxtCat.Text & "' "
            End If
            If TxtLocation.Text.Length = 0 Or TxtLocation.Text = "*All" Then
            Else
                sQLSTR = sQLSTR & " and location=N'" & TxtLocation.Text & "' "
            End If

            sQLSTR = sQLSTR & "  GROUP BY StockCode, StockSize, SubUnit, BaseUnit, IsSimpleUnit "

        Else

            sQLSTR = " SELECT     StockCode AS [Item Code], StockSize AS [Item More Info], (CASE ISSIMPLEUNIT WHEN 1 THEN CONVERT(varchar(30), SUM(OpTotalQty))   + ' ' + BASEUNIT ELSE CONVERT(varchar(30), SUM(OpTotalQty)) + ' ' + SUBUNIT END) AS [Opening Qty], SUM(OpTotalQty * OpstockRate / UnitCon) AS [Opening Value], " _
                 & " (SELECT     SUM(CASE WHEN vouchername IN ('PG', 'DP')  THEN TIV.TotalQty ELSE 0 - TIV.totalqty END))  AS TOT  FROM          dbo.StockInvoiceRowItems AS TIV  WHERE      (StockCode = dbo.StockDbf.StockCode) AND (StockSize = dbo.StockDbf.StockSize) AND (VoucherName IN ('PG', 'DP')) " & DateSQLStr & " )  AS [Inward Qty], " _
                 & "  (SELECT     SUM((CASE WHEN vouchername IN ('PG', 'DP') THEN TIV1.TotalQty ELSE 0 - TIV1.totalqty END) * StockRate / UnitCon) AS TOT FROM          dbo.StockInvoiceRowItems AS TIV1   WHERE      (StockCode = dbo.StockDbf.StockCode) AND (StockSize = dbo.StockDbf.StockSize) AND (VoucherName IN ('PG', 'DP')) " & DateSQLStr & " )    AS [Inward Value]," _
                 & "  (SELECT     SUM(CASE WHEN vouchername IN ('SD', 'POS') THEN  TSin.TotalQty ELSE 0 - TSin.totalqty END) AS TOT  FROM          dbo.StockInvoiceRowItems AS TSin WHERE      (StockCode = dbo.StockDbf.StockCode) AND (StockSize = dbo.StockDbf.StockSize) AND (VoucherName IN ('SD', 'POS')) " & DateSQLStr & " )    AS [Outward Qty]," _
                 & "  (SELECT     SUM((CASE WHEN vouchername IN ('SD', 'POS') THEN TSo2.TotalQty ELSE 0 - TSo2.totalqty END) * StockRate / UnitCon) AS TOT  FROM          dbo.StockInvoiceRowItems AS TSo2  WHERE      (StockCode = dbo.StockDbf.StockCode) AND (StockSize = dbo.StockDbf.StockSize) AND (VoucherName IN ('SD', 'POS'))" & DateSQLStr & ") AS [Outward Value], " _
                 & "  SUM(TotalQty)  AS [Closing Qty], " _
                 & "  SUM(TotalQty * StockRate / UnitCon) AS [Closing Value] " _
                 & "  FROM StockDbf     WHERE (StockType = 0)  "
            If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
            Else
                sQLSTR = sQLSTR & " and stockgroup=N'" & TxtStockGroup.Text & "' "
            End If

            If TxtCat.Text.Length = 0 Or TxtCat.Text = "*All" Then
            Else
                sQLSTR = sQLSTR & " and category=N'" & TxtCat.Text & "' "
            End If
            If TxtLocation.Text.Length = 0 Or TxtLocation.Text = "*All" Then
            Else
                sQLSTR = sQLSTR & " and location=N'" & TxtLocation.Text & "' "
            End If

            sQLSTR = sQLSTR & "  GROUP BY StockCode, StockSize, SubUnit, BaseUnit, IsSimpleUnit "

        End If




        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(sQLSTR)
            If IsHideZerovalue.Checked = True Then
                TempBS.Filter = " [Closing Value]<>0 "
            Else
                TempBS.Filter = ""
            End If
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With





        Try
            TxtList.Columns("Opening Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Opening Qty").Width = 100
            TxtList.Columns("Opening Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TxtList.Columns("Opening Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Opening Value").Width = 100
            TxtList.Columns("Opening Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Opening Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Opening Value").DefaultCellStyle.DataSourceNullValue = "0"

            TxtList.Columns("Closing Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Closing Qty").Width = 100
            TxtList.Columns("Closing Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TxtList.Columns("Closing Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Closing Value").Width = 100
            TxtList.Columns("Closing Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Closing Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Closing Value").DefaultCellStyle.DataSourceNullValue = "0"

            TxtList.Columns("Outwards Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Outwards Value").Width = 100
            TxtList.Columns("Outwards Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Outwards Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Outwards Value").DefaultCellStyle.DataSourceNullValue = "0"

            TxtList.Columns("Outwards Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Outwards Qty").Width = 100
            TxtList.Columns("Outwards Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TxtList.Columns("Inwards Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Inwards Value").Width = 100
            TxtList.Columns("Inwards Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Inwards Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Inwards Value").DefaultCellStyle.DataSourceNullValue = "0"

            TxtList.Columns("Inwards Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Inwards Qty").Width = 100
            TxtList.Columns("Inwards Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Catch ex As Exception

        End Try
        Dim totopvalue As Double = 0
        Dim totoutvalue As Double = 0
        Dim totinvalue As Double = 0
        Dim totclvalue As Double = 0

        For i As Integer = 0 To TxtList.RowCount - 1
            Try
                totopvalue = totopvalue + CDbl(TxtList.Item("Opening Value", i).Value)
            Catch ex As Exception

            End Try
            Try
                totoutvalue = totoutvalue + CDbl(TxtList.Item("Outwards Value", i).Value)
            Catch ex As Exception

            End Try
            'Closing Value
            Try
                totinvalue = totinvalue + CDbl(TxtList.Item("Inwards Value", i).Value)
            Catch ex As Exception

            End Try
            Try
                totclvalue = totclvalue + CDbl(TxtList.Item("Closing Value", i).Value)
            Catch ex As Exception

            End Try
        Next
        TxttotalOp.Text = FormatNumber(totopvalue, ErpDecimalPlaces)
        TxtTotal2.Text = FormatNumber(totinvalue, ErpDecimalPlaces)
        TxtTotal3.Text = FormatNumber(totoutvalue, ErpDecimalPlaces)
        TxtTotal4.Text = FormatNumber(totclvalue, ErpDecimalPlaces)
        Try
            If AppIsItemwithSize = False Then
                TxtList.Columns("Item More Info").Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub stocksummery_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub stocksummery_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        LoadDataIntoComboBox("select stockgroupname from stockgroups", TxtStockGroup, "stockgroupname", "*All")
        LoadDataIntoComboBox("select StockCategoryName from Categoriesgroups", TxtCat, "StockCategoryName", "*All")
        LoadDataIntoComboBox("select locationname  from StockLocations", TxtLocation, "locationname", "*All")
        LoadData()
    End Sub

    Private Sub IsShowinSubUnits_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadData()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadData()
    End Sub

    Private Sub IsShowinSubUnits_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadData()
    End Sub

    Private Sub TxtShowinCompound_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadData()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click

        Me.Cursor = Cursors.WaitCursor
        Dim ds As New StockSummeryDataSet

        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(sQLSTR, cnn)
        dscmd.Fill(ds, "StockDbf")
        If IsHideZerovalue.Checked = True Then
            Dim rows() As System.Data.DataRow
            rows = ds.Tables("stockdbf").Select("[Closing Value]=0 ")
            If rows.Length > 0 Then
                For Each row As System.Data.DataRow In rows
                    ds.Tables(0).Rows.Remove(row)
                Next
            End If
          

        End If
        cnn.Close()
       
        'sQLSTR
        'ds.Clear()
        'For i As Integer = 0 To TxtList.RowCount - 1
        '    Dim row As DataRow
        '    row = ds.Tables(0).NewRow
        '    For k As Integer = 0 To TxtList.ColumnCount - 1
        '        Try
        '            row(TxtList.Columns(k).Name) = TxtList.Item(k, i).Value
        '        Catch ex As Exception

        '        End Try

        '    Next
        '    ds.Tables(0).Rows.Add(row)
        'Next
        Dim subtitle As String = ""
        If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
        Else
            subtitle = " For " & TxtStockGroup.Text
        End If

        Dim objRpt As New StockSummeryCRReport
     
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "STOCK SUMMARY REPORT" & subtitle
            If TxtIsPeriod.Checked = True Then
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Period :" & TxtStartDate.Value.Date & " To " & TxtEndDate.Value.Date
            End If
        Else
            If TxtIsPeriod.Checked = True Then
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "STOCK SUMMARY REPORT" & subtitle & Chr(13) & "Period :" & TxtStartDate.Value.Date & " To " & TxtEndDate.Value.Date
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True
            Else
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "STOCK SUMMARY REPORT" & subtitle

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



    Private Sub TxtList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellDoubleClick
        If TxtList.SelectedRows.Count > 0 Then
            Dim k As New StockItemwiseReport(TxtList.Item("Item Code", TxtList.CurrentRow.Index).Value)
            Me.Cursor = Cursors.WaitCursor
            k.SuspendLayout()
            k.MdiParent = MainForm
            k.Dock = DockStyle.Fill
            k.Show()
            k.WindowState = FormWindowState.Maximized
            k.BringToFront()
            k.ResumeLayout()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub TxtStockGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockGroup.SelectedIndexChanged, TxtCat.SelectedIndexChanged, TxtLocation.SelectedIndexChanged
        txtByItemName.Text = ""
        LoadData()

    End Sub

    Private Sub UserButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton2.Click
        txtByItemName.Text = ""
        LoadData()
    End Sub

    Private Sub IsShowinSubUnits_CheckedChanged_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsShowinSubUnits.CheckedChanged, TxtDetailedView.CheckedChanged, IsHideZerovalue.CheckedChanged
        txtByItemName.Text = ""
        LoadData()
    End Sub

    Private Sub BtItemNameSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtItemNameSearch.Click

        LoadData()
        txtByItemName.Text = ""
    End Sub
End Class