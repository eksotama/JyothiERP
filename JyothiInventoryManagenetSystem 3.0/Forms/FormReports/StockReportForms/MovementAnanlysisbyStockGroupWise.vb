Imports System.Data.SqlClient

Public Class MovementAnanlysisbyStockGroupWise
    Dim SQlstr As String = ""
    Dim LoadType As Integer = 1
    Dim ReportTitle As String = ""

    Private Sub MovementAnanlysisbyStockGroupWise_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub MovementAnanlysisbyStockGroupWise_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select stockgroupname from stockgroups", TxtStockGroup, "stockgroupname", "*All")
        LoadDataIntoComboBox("select ledgername from ledgers where accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CustomersAccounts & "')", Txtledger, "ledgername", "*All")
        LoadDataIntoComboBox("select locationname  from StockLocations", TxtStockLocation, "locationname", "*All")
        LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CustomersAccounts & "' or groupname=N'" & AccountGroupNames.BankOD & "' or groupname=N'" & AccountGroupNames.BankAccounts & "'", TxtAccountGroup, "subgroup", "*All")
        TxtStockLocation.Text = GetDefLocationName()
        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Private Sub TxtStockLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockLocation.SelectedIndexChanged
        If LoadType = 1 Then
            LoadByStockGroup()
        ElseIf LoadType = 2 Then
            LoadByLedgerName()
        Else
            LoadByAccountGroup()
        End If
    End Sub
    Sub LoadData(ByVal SqlStr As String, ByVal totSqlStr As String)
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        'Outward Value
        'Inward Value
        Dim tot1 As Double = 0
        Dim tot2 As Double = 0
        For i As Integer = 0 To TxtList.RowCount - 1
            Try
                tot1 = tot1 + CDbl(TxtList.Item("Inward Value", i).Value)
            Catch ex As Exception

            End Try
            Try
                tot2 = tot2 + CDbl(TxtList.Item("Outward Value", i).Value)
            Catch ex As Exception

            End Try
        Next
        TxtTotal2.Text = FormatNumber(tot1, ErpDecimalPlaces)
        TxtTotal4.Text = FormatNumber(tot2, ErpDecimalPlaces)
        Try
            If AppIsItemwithSize = False Then
                TxtList.Columns("MORE INFO").Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtStockGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockGroup.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        LoadType = 1
        LoadByStockGroup()

        Me.Cursor = Cursors.Default

    End Sub
    Sub LoadByStockGroup()
        'isdeleted=0
        '  and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")
        Dim AvgInsqlstr As String = ""
        Dim Avgoutsqlstr As String = ""
        'FOR REPORT TITLE
        If IsDateWiseOn.Checked = True Then
            If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
                ReportTitle = "Period " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date

            Else
                ReportTitle = "Period " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date & " For Stock Group : " & TxtStockGroup.Text

            End If
        Else
            If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
                ReportTitle = "For All Stock Groups"

            Else
                ReportTitle = "For Stock Group : " & TxtStockGroup.Text

            End If
        End If

        If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
            If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
                If IsDateWiseOn.Checked = True Then
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP'))  and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS'))   and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  GROUP BY Stockcode,stocksize) AS [Outward Rate] "

                Else
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP'))  and isdelete=0    GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS'))  and isdelete=0    GROUP BY Stockcode,stocksize) AS [Outward Rate] "

                End If
            Else
                '  and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")
                If IsDateWiseOn.Checked = True Then
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP')) and (stockcode in (select stockcode from stockdbf where stockgroup=N'" & TxtStockGroup.Text & "'))   and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS')) and (stockcode in (select stockcode from stockdbf where stockgroup=N'" & TxtStockGroup.Text & "'))  and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  GROUP BY Stockcode,stocksize) AS [Outward Rate] "
                Else
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP')) and (stockcode in (select stockcode from stockdbf where stockgroup=N'" & TxtStockGroup.Text & "'))  and isdelete=0   GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS')) and (stockcode in (select stockcode from stockdbf where stockgroup=N'" & TxtStockGroup.Text & "'))   and isdelete=0    GROUP BY Stockcode,stocksize) AS [Outward Rate] "
                End If

            End If
        Else
            If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
                If IsDateWiseOn.Checked = True Then
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE (location=N'" & TxtStockLocation.Text & "') and (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP'))   and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE (location=N'" & TxtStockLocation.Text & "') and  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS') )   and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") GROUP BY Stockcode,stocksize) AS [Outward Rate] "
                Else
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE (location=N'" & TxtStockLocation.Text & "') and (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP'))   and isdelete=0     GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE (location=N'" & TxtStockLocation.Text & "') and  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS') )   and isdelete=0    GROUP BY Stockcode,stocksize) AS [Outward Rate] "
                End If
                '  and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")
            Else
                If IsDateWiseOn.Checked = True Then
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (location=N'" & TxtStockLocation.Text & "') and (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP')) and (stockcode in (select stockcode from stockdbf where stockgroup=N'" & TxtStockGroup.Text & "'))   and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE (location=N'" & TxtStockLocation.Text & "') and (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS')) and (stockcode in (select stockcode from stockdbf where stockgroup=N'" & TxtStockGroup.Text & "'))   and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  GROUP BY Stockcode,stocksize) AS [Outward Rate] "
                Else
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (location=N'" & TxtStockLocation.Text & "') and (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP')) and (stockcode in (select stockcode from stockdbf where stockgroup=N'" & TxtStockGroup.Text & "'))  and isdelete=0   GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE (location=N'" & TxtStockLocation.Text & "') and (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS')) and (stockcode in (select stockcode from stockdbf where stockgroup=N'" & TxtStockGroup.Text & "'))  and isdelete=0    GROUP BY Stockcode,stocksize) AS [Outward Rate] "
                End If

            End If
        End If

        If TxtShowTailUnit.Checked = True Then
            SQlstr = "SELECT Stockcode AS [ITEM NAME], STOCKSIZE AS [MORE INFO], (CONVERT(varchar(30),SUM(CASE WHEN (VOUCHERNAME IN ('PG', 'SR','DP')) THEN TotalQty ELSE 0 END)) + ' ' + (SELECT (CASE WHEN UNITTYPE=0 THEN UNITNAME ELSE SUBUNITNAME END) AS K FROM STOCKUNITS WHERE STOCKUNITS.UNITNAME=MT.BASEUNIT)) AS [Inward Qty]," & AvgInsqlstr & "," _
              & " SUM(CASE WHEN VOUCHERNAME IN ('PG', 'SR','DP') THEN STOCKAMOUNT ELSE 0 END) AS [Inward Value], " _
              & " (CONVERT(varchar(30),SUM(CASE WHEN (VOUCHERNAME IN ('SD', 'PR','POS')) THEN TotalQty ELSE 0 END)) + ' ' + (SELECT (CASE WHEN UNITTYPE=0 THEN UNITNAME ELSE SUBUNITNAME END) AS K FROM STOCKUNITS WHERE STOCKUNITS.UNITNAME=MT.BASEUNIT)) AS [Outward Qty] ," & Avgoutsqlstr & "," _
              & " SUM(CASE WHEN VOUCHERNAME IN ('SD', 'PR','POS') THEN STOCKAMOUNT ELSE 0 END) AS [Outward Value] from StockInvoiceRowItems as MT "
            If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
                If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
                    SQlstr = SQlstr & " where  isdelete=0 "
                Else
                    SQlstr = SQlstr & " where stockcode in ( select stockcode from stockdbf where stockgroup=N'" & TxtStockGroup.Text & "') and isdelete=0"
                End If
            Else
                If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
                    SQlstr = SQlstr & " where location=N'" & TxtStockLocation.Text & "'  and isdelete=0 "
                Else
                    SQlstr = SQlstr & " where stockcode in ( select stockcode from stockdbf where stockgroup=N'" & TxtStockGroup.Text & "') and location=N'" & TxtStockLocation.Text & "'  and isdelete=0"
                End If
            End If
        Else

            SQlstr = "SELECT Stockcode AS [ITEM NAME], STOCKSIZE AS [MORE INFO], ((CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = MT.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor(SUM(CASE WHEN (VOUCHERNAME IN ('PG', 'SR','DP')) THEN TotalQty ELSE 0 END) / unitcon)) + ' ' + mainunit ELSE (CASE CAST(SUM(CASE WHEN (VOUCHERNAME IN ('PG', 'SR','DP')) THEN TotalQty ELSE 0 END) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor(SUM(CASE WHEN (VOUCHERNAME IN ('PG', 'SR','DP')) THEN TotalQty ELSE 0 END) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor(SUM(CASE WHEN (VOUCHERNAME IN ('PG', 'SR','DP')) THEN TotalQty ELSE 0 END) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST(SUM(CASE WHEN (VOUCHERNAME IN ('PG', 'SR','DP')) THEN TotalQty ELSE 0 END) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END)) AS [Inward Qty]," & AvgInsqlstr & "," _
                         & " SUM(CASE WHEN VOUCHERNAME IN ('PG', 'SR','DP') THEN STOCKAMOUNT ELSE 0 END) AS [Inward Value], " _
                         & " ((CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = MT.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor(SUM(CASE WHEN (VOUCHERNAME IN ('SD', 'PR','POS')) THEN TotalQty ELSE 0 END) / unitcon)) + ' ' + mainunit ELSE (CASE CAST(SUM(CASE WHEN (VOUCHERNAME IN ('SD', 'PR','POS')) THEN TotalQty ELSE 0 END) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor(SUM(CASE WHEN (VOUCHERNAME IN ('SD', 'PR','POS')) THEN TotalQty ELSE 0 END) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor(SUM(CASE WHEN (VOUCHERNAME IN ('SD', 'PR','POS')) THEN TotalQty ELSE 0 END) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST(SUM(CASE WHEN (VOUCHERNAME IN ('SD', 'PR','POS')) THEN TotalQty ELSE 0 END) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END)) AS [Outward Qty] ," & Avgoutsqlstr & "," _
                         & " SUM(CASE WHEN VOUCHERNAME IN ('SD', 'PR','POS') THEN STOCKAMOUNT ELSE 0 END) AS [Outward Value] from StockInvoiceRowItems as MT "
            If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
                If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
                    SQlstr = SQlstr & " where  isdelete=0 "
                Else
                    SQlstr = SQlstr & " where stockcode in ( select stockcode from stockdbf where stockgroup=N'" & TxtStockGroup.Text & "')  and isdelete=0"
                End If
            Else
                If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
                    SQlstr = SQlstr & " where location=N'" & TxtStockLocation.Text & "'  and isdelete=0"
                Else
                    SQlstr = SQlstr & " where stockcode in ( select stockcode from stockdbf where stockgroup=N'" & TxtStockGroup.Text & "') and location=N'" & TxtStockLocation.Text & "'  and isdelete=0"
                End If
            End If


        End If
        If IsDateWiseOn.Checked = True Then
            SQlstr = SQlstr & " and (vouchername in ('SD', 'PR','POS','PG', 'SR','DP'))      and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
        Else
            SQlstr = SQlstr & " and (vouchername in ('SD', 'PR','POS','PG', 'SR','DP'))    "
        End If

        If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
            SQlstr = SQlstr & " GROUP BY STOCKCODE,STOCKSIZE,subunit,BASEUNIT,mainunit,unitcon"
        Else
            SQlstr = SQlstr & " GROUP BY STOCKCODE,STOCKSIZE,subunit,BASEUNIT,mainunit,unitcon,LOCATION "
        End If

        LoadData(SQlstr, " ")
        Try
            TxtList.Columns("ITEM NAME").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("ITEM NAME").Width = 350

            TxtList.Columns("MORE INFO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("MORE INFO").Width = 200

            TxtList.Columns("Inward Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Inward Qty").Width = 120

            TxtList.Columns("Outward Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Outward Qty").Width = 120

            TxtList.Columns("Inward Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Inward Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            TxtList.Columns("Inward Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Inward Value").Width = 80


            TxtList.Columns("Outward Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Outward Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            TxtList.Columns("Outward Value").Width = 80
            TxtList.Columns("Outward Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

            TxtList.Columns("Inward Rate").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Inward Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            TxtList.Columns("Inward Rate").Width = 80
            TxtList.Columns("Inward Rate").DefaultCellStyle.Format = "N" & ErpDecimalPlaces & ErpDecimalPlaces

            TxtList.Columns("Outward Rate").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Outward Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            TxtList.Columns("Outward Rate").Width = 80
            TxtList.Columns("Outward Rate").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Txtledger_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtledger.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        LoadType = 2

        LoadByLedgerName()
        Me.Cursor = Cursors.Default
    End Sub
    Sub LoadByLedgerName()
        Dim AvgInsqlstr As String = ""
        Dim Avgoutsqlstr As String = ""
        '   and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")
        If IsDateWiseOn.Checked = True Then
            If Txtledger.Text.Length = 0 Or Txtledger.Text = "*All" Then
                ReportTitle = "Period " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date

            Else
                ReportTitle = "Period " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date & " For Ledger Account : " & Txtledger.Text

            End If
        Else
            If Txtledger.Text.Length = 0 Or Txtledger.Text = "*All" Then
                ReportTitle = "For All Ledger Accounts"

            Else
                ReportTitle = "For Ledger Account : " & Txtledger.Text

            End If
        End If

        If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
            If Txtledger.Text.Length = 0 Or Txtledger.Text = "*All" Then
                If IsDateWiseOn.Checked = True Then
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP'))   and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS'))   and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  GROUP BY Stockcode,stocksize) AS [Outward Rate] "

                Else
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP'))   and isdelete=0   GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS'))   and isdelete=0   GROUP BY Stockcode,stocksize) AS [Outward Rate] "

                End If
            Else
                If IsDateWiseOn.Checked = True Then
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP')) and (transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & Txtledger.Text & "'))   and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS')) and (transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & Txtledger.Text & "'))    and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  GROUP BY Stockcode,stocksize) AS [Outward Rate] "

                Else
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP')) and (transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & Txtledger.Text & "'))  and isdelete=0   GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS')) and (transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & Txtledger.Text & "'))   and isdelete=0   GROUP BY Stockcode,stocksize) AS [Outward Rate] "

                End If

            End If

        Else
            If Txtledger.Text.Length = 0 Or Txtledger.Text = "*All" Then
                If IsDateWiseOn.Checked = True Then
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE (location=N'" & TxtStockLocation.Text & "') and (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP'))    and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE (location=N'" & TxtStockLocation.Text & "') and  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS') )   and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") GROUP BY Stockcode,stocksize) AS [Outward Rate] "
                Else
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE (location=N'" & TxtStockLocation.Text & "') and (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP'))  and isdelete=0    GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE (location=N'" & TxtStockLocation.Text & "') and  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS') )  and isdelete=0   GROUP BY Stockcode,stocksize) AS [Outward Rate] "
                End If

            Else
                If IsDateWiseOn.Checked = True Then
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (location=N'" & TxtStockLocation.Text & "') and (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP')) and (transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & Txtledger.Text & "'))   and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE (location=N'" & TxtStockLocation.Text & "') and (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS')) and (transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & Txtledger.Text & "'))    and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") GROUP BY Stockcode,stocksize) AS [Outward Rate] "
                Else
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (location=N'" & TxtStockLocation.Text & "') and (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP')) and (transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & Txtledger.Text & "'))  and isdelete=0   GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE (location=N'" & TxtStockLocation.Text & "') and (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS')) and (transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & Txtledger.Text & "'))  and isdelete=0    GROUP BY Stockcode,stocksize) AS [Outward Rate] "
                End If

            End If
        End If

        If TxtShowTailUnit.Checked = True Then
            SQlstr = "SELECT Stockcode AS [ITEM NAME], STOCKSIZE AS [MORE INFO], (CONVERT(varchar(30),SUM(CASE WHEN (VOUCHERNAME IN ('PG', 'SR','DP')) THEN TotalQty ELSE 0 END)) + ' ' + (SELECT (CASE WHEN UNITTYPE=0 THEN UNITNAME ELSE SUBUNITNAME END) AS K FROM STOCKUNITS WHERE STOCKUNITS.UNITNAME=MT.BASEUNIT)) AS [Inward Qty]," & AvgInsqlstr & "," _
              & " SUM(CASE WHEN VOUCHERNAME IN ('PG', 'SR','DP') THEN STOCKAMOUNT ELSE 0 END) AS [Inward Value], " _
              & " (CONVERT(varchar(30),SUM(CASE WHEN (VOUCHERNAME IN ('SD', 'PR','POS')) THEN TotalQty ELSE 0 END)) + ' ' + (SELECT (CASE WHEN UNITTYPE=0 THEN UNITNAME ELSE SUBUNITNAME END) AS K FROM STOCKUNITS WHERE STOCKUNITS.UNITNAME=MT.BASEUNIT)) AS [Outward Qty] ," & Avgoutsqlstr & "," _
              & " SUM(CASE WHEN VOUCHERNAME IN ('SD', 'PR','POS') THEN STOCKAMOUNT ELSE 0 END) AS [Outward Value] from StockInvoiceRowItems as MT "
            If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
                If Txtledger.Text.Length = 0 Or Txtledger.Text = "*All" Then
                    SQlstr = SQlstr & " where  isdelete=0 "
                Else
                    SQlstr = SQlstr & " where (transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & Txtledger.Text & "')) and isdelete=0 "
                End If
            Else
                If Txtledger.Text.Length = 0 Or Txtledger.Text = "*All" Then
                    SQlstr = SQlstr & " where location=N'" & TxtStockLocation.Text & "' and isdelete=0"
                Else
                    SQlstr = SQlstr & " where (transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & Txtledger.Text & "')) and location=N'" & TxtStockLocation.Text & "' and isdelete=0"
                End If
            End If
        Else

            SQlstr = "SELECT Stockcode AS [ITEM NAME], STOCKSIZE AS [MORE INFO], ((CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = MT.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor(SUM(CASE WHEN (VOUCHERNAME IN ('PG', 'SR','DP')) THEN TotalQty ELSE 0 END) / unitcon)) + ' ' + mainunit ELSE (CASE CAST(SUM(CASE WHEN (VOUCHERNAME IN ('PG', 'SR','DP')) THEN TotalQty ELSE 0 END) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor(SUM(CASE WHEN (VOUCHERNAME IN ('PG', 'SR','DP')) THEN TotalQty ELSE 0 END) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor(SUM(CASE WHEN (VOUCHERNAME IN ('PG', 'SR','DP')) THEN TotalQty ELSE 0 END) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST(SUM(CASE WHEN (VOUCHERNAME IN ('PG', 'SR','DP')) THEN TotalQty ELSE 0 END) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END)) AS [Inward Qty]," & AvgInsqlstr & "," _
                         & " SUM(CASE WHEN VOUCHERNAME IN ('PG', 'SR','DP') THEN STOCKAMOUNT ELSE 0 END) AS [Inward Value], " _
                         & " ((CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = MT.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor(SUM(CASE WHEN (VOUCHERNAME IN ('SD', 'PR','POS')) THEN TotalQty ELSE 0 END) / unitcon)) + ' ' + mainunit ELSE (CASE CAST(SUM(CASE WHEN (VOUCHERNAME IN ('SD', 'PR','POS')) THEN TotalQty ELSE 0 END) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor(SUM(CASE WHEN (VOUCHERNAME IN ('SD', 'PR','POS')) THEN TotalQty ELSE 0 END) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor(SUM(CASE WHEN (VOUCHERNAME IN ('SD', 'PR','POS')) THEN TotalQty ELSE 0 END) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST(SUM(CASE WHEN (VOUCHERNAME IN ('SD', 'PR','POS')) THEN TotalQty ELSE 0 END) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END)) AS [Outward Qty] ," & Avgoutsqlstr & "," _
                         & " SUM(CASE WHEN VOUCHERNAME IN ('SD', 'PR','POS') THEN STOCKAMOUNT ELSE 0 END) AS [Outward Value] from StockInvoiceRowItems as MT "
            If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
                If Txtledger.Text.Length = 0 Or Txtledger.Text = "*All" Then
                    SQlstr = SQlstr & " where  isdelete=0 "
                Else
                    SQlstr = SQlstr & " where (transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & Txtledger.Text & "'))  and isdelete=0"
                End If
            Else
                If Txtledger.Text.Length = 0 Or Txtledger.Text = "*All" Then
                    SQlstr = SQlstr & " where location=N'" & TxtStockLocation.Text & "'  and isdelete=0"
                Else
                    SQlstr = SQlstr & " where (transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & Txtledger.Text & "')) and location=N'" & TxtStockLocation.Text & "'  and isdelete=0"
                End If
            End If


        End If
        If IsDateWiseOn.Checked = True Then
            SQlstr = SQlstr & " and (vouchername in ('SD', 'PR','POS','PG', 'SR','DP'))   and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
        Else
            SQlstr = SQlstr & " and (vouchername in ('SD', 'PR','POS','PG', 'SR','DP'))    "
        End If

        If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
            SQlstr = SQlstr & " GROUP BY STOCKCODE,STOCKSIZE,subunit,BASEUNIT,mainunit,unitcon"
        Else
            SQlstr = SQlstr & " GROUP BY STOCKCODE,STOCKSIZE,subunit,BASEUNIT,mainunit,unitcon,LOCATION "
        End If

        LoadData(SQlstr, " ")
        Try
            TxtList.Columns("ITEM NAME").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("ITEM NAME").Width = 350

            TxtList.Columns("MORE INFO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("MORE INFO").Width = 200

            TxtList.Columns("Inward Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Inward Qty").Width = 120

            TxtList.Columns("Outward Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Outward Qty").Width = 120

            TxtList.Columns("Inward Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Inward Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            TxtList.Columns("Inward Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Inward Value").Width = 80


            TxtList.Columns("Outward Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Outward Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            TxtList.Columns("Outward Value").Width = 80
            TxtList.Columns("Outward Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

            TxtList.Columns("Inward Rate").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Inward Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            TxtList.Columns("Inward Rate").Width = 80
            TxtList.Columns("Inward Rate").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

            TxtList.Columns("Outward Rate").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Outward Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            TxtList.Columns("Outward Rate").Width = 80
            TxtList.Columns("Outward Rate").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

        Catch ex As Exception

        End Try
    End Sub
    Private Sub TxtAccountGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAccountGroup.SelectedIndexChanged

        Me.Cursor = Cursors.WaitCursor
        LoadType = 3
        LoadByAccountGroup()
        Me.Cursor = Cursors.Default
    End Sub
    Sub LoadByAccountGroup()
        Dim AvgInsqlstr As String = ""
        Dim Avgoutsqlstr As String = ""
        '   and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")

        If IsDateWiseOn.Checked = True Then
            If TxtAccountGroup.Text.Length = 0 Or TxtAccountGroup.Text = "*All" Then
                ReportTitle = "Period " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date
            Else
                ReportTitle = "Period " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date & " For Account Group : " & TxtAccountGroup.Text
            End If
        Else
            If TxtAccountGroup.Text.Length = 0 Or TxtAccountGroup.Text = "*All" Then
                ReportTitle = "For All Account Groups"
            Else
                ReportTitle = "For Account Group : " & TxtAccountGroup.Text
            End If
        End If


        If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
            If TxtAccountGroup.Text.Length = 0 Or TxtAccountGroup.Text = "*All" Then
                If IsDateWiseOn.Checked = True Then
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP'))    and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS'))    and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  GROUP BY Stockcode,stocksize) AS [Outward Rate] "
                Else
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP'))    and isdelete=0    GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS'))    and isdelete=0    GROUP BY Stockcode,stocksize) AS [Outward Rate] "
                End If

            Else
                If IsDateWiseOn.Checked = True Then
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP')) and (transcode in (select transcode from StockInvoiceDetails where ledgername In (select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroup.Text & "')))))    and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS')) and (transcode in (select transcode from StockInvoiceDetails where ledgername In (select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroup.Text & "')))))    and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  GROUP BY Stockcode,stocksize) AS [Outward Rate] "
                Else
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP')) and (transcode in (select transcode from StockInvoiceDetails where ledgername In (select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroup.Text & "')))))   and isdelete=0     GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS')) and (transcode in (select transcode from StockInvoiceDetails where ledgername In (select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroup.Text & "')))))   and isdelete=0     GROUP BY Stockcode,stocksize) AS [Outward Rate] "
                End If

            End If
        Else
            If TxtAccountGroup.Text.Length = 0 Or TxtAccountGroup.Text = "*All" Then
                If IsDateWiseOn.Checked = True Then
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE (location=N'" & TxtStockLocation.Text & "') and (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP'))    and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE (location=N'" & TxtStockLocation.Text & "') and  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS') )    and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  GROUP BY Stockcode,stocksize) AS [Outward Rate] "
                Else
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE (location=N'" & TxtStockLocation.Text & "') and (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP'))   and isdelete=0      GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE (location=N'" & TxtStockLocation.Text & "') and  (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS') )    and isdelete=0    GROUP BY Stockcode,stocksize) AS [Outward Rate] "
                End If

            Else
                If IsDateWiseOn.Checked = True Then
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (location=N'" & TxtStockLocation.Text & "') and (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP')) and (transcode in (select transcode from StockInvoiceDetails where ledgername In (select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroup.Text & "')))))    and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE (location=N'" & TxtStockLocation.Text & "') and (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS')) and (transcode in (select transcode from StockInvoiceDetails where ledgername In (select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroup.Text & "')))))     and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") GROUP BY Stockcode,stocksize) AS [Outward Rate] "
                Else
                    AvgInsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE  (location=N'" & TxtStockLocation.Text & "') and (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('PG', 'SR','DP')) and (transcode in (select transcode from StockInvoiceDetails where ledgername In (select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroup.Text & "')))))   and isdelete=0    GROUP BY Stockcode,stocksize) AS [Inward Rate] "
                    Avgoutsqlstr = "(SELECT     AVG(StockRate) AS tot  FROM StockInvoiceRowItems  WHERE (location=N'" & TxtStockLocation.Text & "') and (Stockcode = MT.Stockcode) AND (StockSIZE = MT.StockSIZE) AND (VoucherName IN ('SD', 'PR','POS')) and (transcode in (select transcode from StockInvoiceDetails where ledgername In (select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroup.Text & "')))))   and isdelete=0     GROUP BY Stockcode,stocksize) AS [Outward Rate] "
                End If

            End If
        End If

        If TxtShowTailUnit.Checked = True Then
            SQlstr = "SELECT Stockcode AS [ITEM NAME], STOCKSIZE AS [MORE INFO], (CONVERT(varchar(30),SUM(CASE WHEN (VOUCHERNAME IN ('PG', 'SR','DP')) THEN TotalQty ELSE 0 END)) + ' ' + (SELECT (CASE WHEN UNITTYPE=0 THEN UNITNAME ELSE SUBUNITNAME END) AS K FROM STOCKUNITS WHERE STOCKUNITS.UNITNAME=MT.BASEUNIT)) AS [Inward Qty]," & AvgInsqlstr & "," _
              & " SUM(CASE WHEN VOUCHERNAME IN ('PG', 'SR','DP') THEN STOCKAMOUNT ELSE 0 END) AS [Inward Value], " _
              & " (CONVERT(varchar(30),SUM(CASE WHEN (VOUCHERNAME IN ('SD', 'PR','POS')) THEN TotalQty ELSE 0 END)) + ' ' + (SELECT (CASE WHEN UNITTYPE=0 THEN UNITNAME ELSE SUBUNITNAME END) AS K FROM STOCKUNITS WHERE STOCKUNITS.UNITNAME=MT.BASEUNIT)) AS [Outward Qty] ," & Avgoutsqlstr & "," _
              & " SUM(CASE WHEN VOUCHERNAME IN ('SD', 'PR','POS') THEN STOCKAMOUNT ELSE 0 END) AS [Outward Value] from StockInvoiceRowItems as MT "
            If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
                If TxtAccountGroup.Text.Length = 0 Or TxtAccountGroup.Text = "*All" Then
                    SQlstr = SQlstr & " where (vouchername in ('SD', 'PR','POS','PG', 'SR','DP')) "
                Else
                    SQlstr = SQlstr & " where (transcode in (select transcode from StockInvoiceDetails where ledgername In (select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroup.Text & "'))))) and (vouchername in ('SD', 'PR','POS','PG', 'SR','DP'))"
                End If
            Else
                If TxtAccountGroup.Text.Length = 0 Or TxtAccountGroup.Text = "*All" Then
                    SQlstr = SQlstr & " where location=N'" & TxtStockLocation.Text & "' and (vouchername in ('SD', 'PR','POS','PG', 'SR','DP'))"
                Else
                    SQlstr = SQlstr & " where (transcode in (select transcode from StockInvoiceDetails where ledgername In (select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroup.Text & "'))))) and location=N'" & TxtStockLocation.Text & "' and (vouchername in ('SD', 'PR','POS','PG', 'SR','DP'))"
                End If
            End If
        Else

            SQlstr = "SELECT Stockcode AS [ITEM NAME], STOCKSIZE AS [MORE INFO], ((CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = MT.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor(SUM(CASE WHEN (VOUCHERNAME IN ('PG', 'SR','DP')) THEN TotalQty ELSE 0 END) / unitcon)) + ' ' + mainunit ELSE (CASE CAST(SUM(CASE WHEN (VOUCHERNAME IN ('PG', 'SR','DP')) THEN TotalQty ELSE 0 END) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor(SUM(CASE WHEN (VOUCHERNAME IN ('PG', 'SR','DP')) THEN TotalQty ELSE 0 END) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor(SUM(CASE WHEN (VOUCHERNAME IN ('PG', 'SR','DP')) THEN TotalQty ELSE 0 END) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST(SUM(CASE WHEN (VOUCHERNAME IN ('PG', 'SR','DP')) THEN TotalQty ELSE 0 END) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END)) AS [Inward Qty]," & AvgInsqlstr & "," _
                         & " SUM(CASE WHEN VOUCHERNAME IN ('PG', 'SR','DP') THEN STOCKAMOUNT ELSE 0 END) AS [Inward Value], " _
                         & " ((CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = MT.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor(SUM(CASE WHEN (VOUCHERNAME IN ('SD', 'PR','POS')) THEN TotalQty ELSE 0 END) / unitcon)) + ' ' + mainunit ELSE (CASE CAST(SUM(CASE WHEN (VOUCHERNAME IN ('SD', 'PR','POS')) THEN TotalQty ELSE 0 END) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor(SUM(CASE WHEN (VOUCHERNAME IN ('SD', 'PR','POS')) THEN TotalQty ELSE 0 END) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor(SUM(CASE WHEN (VOUCHERNAME IN ('SD', 'PR','POS')) THEN TotalQty ELSE 0 END) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST(SUM(CASE WHEN (VOUCHERNAME IN ('SD', 'PR','POS')) THEN TotalQty ELSE 0 END) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END)) AS [Outward Qty] ," & Avgoutsqlstr & "," _
                         & " SUM(CASE WHEN VOUCHERNAME IN ('SD', 'PR','POS') THEN STOCKAMOUNT ELSE 0 END) AS [Outward Value] from StockInvoiceRowItems as MT "
            If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
                If TxtAccountGroup.Text.Length = 0 Or TxtAccountGroup.Text = "*All" Then
                    SQlstr = SQlstr & " where (vouchername in ('SD', 'PR','POS','PG', 'SR','DP')) "
                Else
                    SQlstr = SQlstr & " where (transcode in (select transcode from StockInvoiceDetails where ledgername In (select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroup.Text & "'))))) and (vouchername in ('SD', 'PR','POS','PG', 'SR','DP'))"
                End If
            Else
                If TxtAccountGroup.Text.Length = 0 Or TxtAccountGroup.Text = "*All" Then
                    SQlstr = SQlstr & " where location=N'" & TxtStockLocation.Text & "' and (vouchername in ('SD', 'PR','POS','PG', 'SR','DP'))"
                Else
                    SQlstr = SQlstr & " where (transcode in (select transcode from StockInvoiceDetails where ledgername In (select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroup.Text & "'))))) and location=N'" & TxtStockLocation.Text & "' and (vouchername in ('SD', 'PR','POS','PG', 'SR','DP'))"
                End If
            End If


        End If
        If IsDateWiseOn.Checked = True Then
            '  and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")
            SQlstr = SQlstr & "  and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
        Else
            SQlstr = SQlstr & "  and isdelete=0   "
        End If

        If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
            SQlstr = SQlstr & " GROUP BY STOCKCODE,STOCKSIZE,subunit,BASEUNIT,mainunit,unitcon"
        Else
            SQlstr = SQlstr & " GROUP BY STOCKCODE,STOCKSIZE,subunit,BASEUNIT,mainunit,unitcon,LOCATION "
        End If

        LoadData(SQlstr, " ")

        Try
            TxtList.Columns("ITEM NAME").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("ITEM NAME").Width = 350

            TxtList.Columns("MORE INFO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("MORE INFO").Width = 200

            TxtList.Columns("Inward Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Inward Qty").Width = 120

            TxtList.Columns("Outward Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Outward Qty").Width = 120

            TxtList.Columns("Inward Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Inward Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            TxtList.Columns("Inward Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Inward Value").Width = 80

            TxtList.Columns("Outward Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Outward Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            TxtList.Columns("Outward Value").Width = 80
            TxtList.Columns("Outward Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

            TxtList.Columns("Inward Rate").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Inward Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            TxtList.Columns("Inward Rate").Width = 80
            TxtList.Columns("Inward Rate").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

            TxtList.Columns("Outward Rate").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Outward Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            TxtList.Columns("Outward Rate").Width = 80
            TxtList.Columns("Outward Rate").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If LoadType = 1 Then
            LoadByStockGroup()
        ElseIf LoadType = 2 Then
            LoadByLedgerName()
        Else
            LoadByAccountGroup()
        End If
    End Sub

    Private Sub TxtShowTailUnit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShowTailUnit.CheckedChanged
        If LoadType = 1 Then
            LoadByStockGroup()
        ElseIf LoadType = 2 Then
            LoadByLedgerName()
        Else
            LoadByAccountGroup()
        End If
    End Sub


    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, PrintToolStripMenuItem.Click
        If SQlstr.Length = 0 Then Exit Sub
        If TxtList.RowCount = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(SQlstr, cnn)
        dscmd.Fill(ds, "datatable1")
        cnn.Close()
        Dim objRpt As New StockMovemenybyStockGroup
        CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
        CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
        CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
        CType(objRpt.Section1.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ReportTitle

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