Imports System.Data.SqlClient
Public Class ItemMovementByLedgerWisePurchase
    Dim SQlstr As String = ""
    Dim LoadType As Integer = 1
    Dim ReportTitle As String = ""

    Private Sub ItemMovementByLedgerWisePurchase_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub MovementAnanlysisbyStockGroupWise_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select stockgroupname from stockgroups", TxtStockGroup, "stockgroupname", "*All")
        LoadDataIntoComboBox("select ledgername from ledgers where accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CustomersAccounts & "')", Txtledger, "ledgername", "*All")
        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        LoadData()
    End Sub


    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub

    Sub LoadData()
        MainForm.Cursor = Cursors.WaitCursor

        Dim WHERESQL As String = ""
        SQlstr = "select transcode, stockname + '  '+stocksize as [Particulars],transdate as [Date],qutono as [Inv No],qtytext as [Sold Qty],stockrate as [Price],stockamount as [Value] from StockInvoiceRowItems "
        If IsDateWiseOn.Checked = True Then
            If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
                ReportTitle = "Period " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date
                WHERESQL = " WHERE (VoucherName IN ('DP', 'PG'))  and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
            Else
                ReportTitle = "Period " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date & " For Stock Group : " & TxtStockGroup.Text
                WHERESQL = " WHERE  (STOCKNAME IN (SELECT STOCKNAME FROM STOCKDBF WHERE STOCKGROUP=N'" & TxtStockGroup.Text & "')) AND  (VoucherName IN ('DP', 'PG'))  and isdelete=0    and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "

            End If
        Else
            If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
                ReportTitle = "For All Stock Groups"
                WHERESQL = " WHERE (VoucherName IN ('DP', 'PG'))  and isdelete=0   "
            Else
                ReportTitle = "For Stock Group : " & TxtStockGroup.Text
                WHERESQL = " WHERE (STOCKNAME IN (SELECT STOCKNAME FROM STOCKDBF WHERE STOCKGROUP=N'" & TxtStockGroup.Text & "')) AND (VoucherName IN ('DP', 'PG'))  and isdelete=0   "
            End If
        End If

        If Txtledger.Text.Length = 0 Or Txtledger.Text = "*All" Then
            SQlstr = SQlstr & WHERESQL & " order by transdate "
        Else
            SQlstr = SQlstr & WHERESQL & "  AND (transcode in ( select transcode from StockInvoiceDetails where LEDGERNAME=N'" & Txtledger.Text & "')) order by transdate "
        End If

        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SQlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try


            TxtList.Columns("transcode").Visible = False
            TxtList.Columns("paritculars").Width = 120
            TxtList.Columns("paritculars").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'Date
            TxtList.Columns("Date").Width = 120
            TxtList.Columns("Date").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Date").DefaultCellStyle.Format = "D"
            TxtList.Columns("Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            TxtList.Columns("Inv No").Width = 120
            TxtList.Columns("Inv No").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Inv No").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            TxtList.Columns("Sold Qty").Width = 120
            TxtList.Columns("Sold Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Sold Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            TxtList.Columns("Price").Width = 120
            TxtList.Columns("Price").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Price").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TxtList.Columns("Value").Width = 120
            TxtList.Columns("Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight



        Catch ex As Exception

        End Try
        MainForm.Cursor = Cursors.Default
    End Sub

    Private Sub TxtStockGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockGroup.SelectedIndexChanged
        LoadData()

    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Txtledger_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtledger.SelectedIndexChanged
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
        Dim objRpt As New ItemwiseMovementByLedgerWiseCRReport
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

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        editinvoice()
    End Sub


    Private Sub TxtList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellDoubleClick

        editinvoice()
    End Sub
    Sub editinvoice()
        If TxtList.SelectedRows.Count = 1 Then
            Dim frm As New InvoiceAlterForm
            frm.TxtTitle.Text = "ALTER SALES"
            MainForm.Cursor = Cursors.WaitCursor
            Dim K As New PurchaseControlAll(SQLGetStringFieldValue("SELECT VOUCHERNAME FROM StockInvoiceDetails WHERE TRANSCODE=" & TxtList.Item("TransCode", TxtList.CurrentRow.Index).Value, "VOUCHERNAME"), TxtList.Item("TransCode", TxtList.CurrentRow.Index).Value)
            K.BtnNew.Enabled = False
            K.BtnOpen.Enabled = False
            frm.TxtList.Controls.Add(K)
            frm.TxtList.Controls(0).Dock = DockStyle.Fill
            frm.WindowState = FormWindowState.Maximized
            MainForm.Cursor = Cursors.Default
            frm.ShowDialog()
            frm.Dispose()
            K.Dispose()
        End If
    End Sub
End Class