Imports System.Data.SqlClient
Public Class ItemwiseQuantityPurchaseFrm
    Dim SQlstr As String = ""
    Dim LoadType As Integer = 1
    Dim ReportTitle As String = ""

    Private Sub ItemwiseQuantityPurchaseFrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
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
        LoadData()
    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Private Sub TxtStockLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockLocation.SelectedIndexChanged

    End Sub
    Sub LoadData()
        MainForm.Cursor = Cursors.WaitCursor

        Dim WHERESQL As String = ""
        Sqlstr = "select stockname+'  '+stocksize as [paritculars], case when issimpleunit=1 then convert(nvarchar(20),sum(totalqty))+' '+ mainunit  else  convert(nvarchar(20),cast(sum(totalqty) as int)/unitcon) +'-'+ convert(nvarchar(20),cast(sum(totalqty) as decimal(10,3)) % unitcon) +' '+ mainunit end as [Sales Total Qty], max(stockrate) as [Max Price],min(stockrate) as [Min Price],avg(stockrate) as [Avg Price] from StockInvoiceRowItems "
        If IsDateWiseOn.Checked = True Then
            If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
                If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
                    ReportTitle = "Period " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date
                    WHERESQL = " WHERE (VoucherName IN ('DP', 'PG'))  and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
                Else
                    ReportTitle = "For Location:" & TxtStockLocation.Text & "  Period " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date
                    WHERESQL = " WHERE LOCATION=N'" & TxtStockLocation.Text & "' AND (VoucherName IN ('DP', 'PG'))  and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
                End If

            Else
                If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
                    ReportTitle = "Period " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date & " For Stock Group : " & TxtStockGroup.Text
                    WHERESQL = " WHERE (VoucherName IN ('DP', 'PG'))  and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
                Else
                    ReportTitle = "For Location:" & TxtStockLocation.Text & " Period " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date & " For Stock Group : " & TxtStockGroup.Text

                    WHERESQL = " WHERE (STOCKNAME IN (SELECT STOCKNAME FROM STOCKDBF WHERE STOCKGROUP=N'" & TxtStockGroup.Text & "')) AND LOCATION=N'" & TxtStockLocation.Text & "' AND (VoucherName IN ('DP', 'PG'))  and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "

                End If

            End If
        Else
            If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
                If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
                    ReportTitle = "For All Stock Groups"
                    WHERESQL = " WHERE (VoucherName IN ('DP', 'PG'))  and isdelete=0   "
                Else
                    ReportTitle = "For Location:" & TxtStockLocation.Text & "  For All Stock Groups"
                    WHERESQL = " WHERE LOCATION=N'" & TxtStockLocation.Text & "' AND  (VoucherName IN ('DP', 'PG'))  and isdelete=0 "
                End If

            Else
                If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
                    ReportTitle = "For Stock Group : " & TxtStockGroup.Text
                    WHERESQL = " WHERE (STOCKNAME IN (SELECT STOCKNAME FROM STOCKDBF WHERE STOCKGROUP=N'" & TxtStockGroup.Text & "')) AND (VoucherName IN ('DP', 'PG'))  and isdelete=0   "
                Else
                    ReportTitle = "For Location:" & TxtStockLocation.Text & "  For Stock Group : " & TxtStockGroup.Text
                    WHERESQL = " WHERE (STOCKNAME IN (SELECT STOCKNAME FROM STOCKDBF WHERE STOCKGROUP=N'" & TxtStockGroup.Text & "')) AND LOCATION=N'" & TxtStockLocation.Text & "' AND  (VoucherName IN ('DP', 'PG'))  and isdelete=0   "
                End If

            End If
        End If

        If Txtledger.Text.Length = 0 Or Txtledger.Text = "*All" Then
            Sqlstr = Sqlstr & WHERESQL & "   group by stockname,stocksize,issimpleunit,mainunit,subunit,UnitCon,baseunit "
        Else
            SQlstr = SQlstr & WHERESQL & "  AND (transcode in ( select transcode from StockInvoiceDetails where LEDGERNAME=N'" & Txtledger.Text & "'))  group by stockname,stocksize,issimpleunit,mainunit,subunit,UnitCon,baseunit "
            ReportTitle = ReportTitle & Chr(13) & " For Ledger: " & Txtledger.Text
        End If

        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try

            TxtList.Columns("Sales Total Qty").Width = 120
            TxtList.Columns("Sales Total Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("paritculars").Width = 120
            TxtList.Columns("paritculars").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            TxtList.Columns("Max Price").Width = 120
            TxtList.Columns("Max Price").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Max Price").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Max Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TxtList.Columns("Min Price").Width = 120
            TxtList.Columns("Min Price").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Min Price").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Min Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TxtList.Columns("Avg Price").Width = 120
            TxtList.Columns("Avg Price").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Avg Price").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Avg Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Catch ex As Exception

        End Try
        MainForm.Cursor = Cursors.Default
    End Sub

    Private Sub TxtStockGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockGroup.SelectedIndexChanged, TxtStockLocation.SelectedIndexChanged
        LoadData()

    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Txtledger_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtledger.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub TxtAccountGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAccountGroup.SelectedIndexChanged

        LoadData()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        LoadData()
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
        Dim objRpt As New ItemwiseQuantityReport
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