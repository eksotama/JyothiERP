Imports System.Data.SqlClient

Public Class LedgerBalanceSheetForm
    Dim SqlStr As String = ""
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadCustomersBalances(Optional ByVal AddSqlText As String = "")

        Dim AdditionalWhereSQLStr As String = ""
        If TxtLocationWise.Text.Length = 0 Or TxtLocationWise.Text = "*All" Then
        Else
            AdditionalWhereSQLStr = " and storename=N'" & TxtLocationWise.Text & "' "
        End If
        If TxtUserWise.Text.Length = 0 Or TxtUserWise.Text = "*All" Then
        Else
            AdditionalWhereSQLStr = AdditionalWhereSQLStr & " and username=N'" & TxtUserWise.Text & "' "
        End If

        If TxtIsCurrency.Checked = True Then

            If TxtGroupName.Text.Length = 0 Or TxtGroupName.Text = "*All" Then
                SqlStr = "SELECT ledgername AS [Account Name],SUM(DR*CONRATE) AS [Dr Amount],SUM(CR*CONRATE) as [Cr Amount],  (SELECT Currency FROM  dbo.ledgers WHERE (LedgerName = dbo.LedgerBook.LedgerName)) + ' ' +(CASE  WHEN SUM(DR*CONRATE)-SUM(CR*CONRATE)>=0 THEN   CONVERT(varchar(30), CAST(SUM(DR*CONRATE)-SUM(CR*CONRATE) AS DECIMAL(15,3)),1) +' Dr' ELSE CONVERT(varchar(30), CAST(SUM(CR*CONRATE)-SUM(DR*CONRATE) AS DECIMAL(15,3)),1) + ' Cr' END)  AS [Balance] from ledgerbook where isdeleted=0  " & AdditionalWhereSQLStr
            Else
                SqlStr = "SELECT ledgername AS [Account Name],SUM(DR*CONRATE) AS [Dr Amount],SUM(CR*CONRATE) as [Cr Amount], (SELECT Currency FROM  dbo.ledgers WHERE (LedgerName = dbo.LedgerBook.LedgerName)) + ' ' +(CASE  WHEN SUM(DR*CONRATE)-SUM(CR*CONRATE)>=0 THEN  CONVERT(varchar(30), CAST(SUM(DR*CONRATE)-SUM(CR*CONRATE) AS DECIMAL(15,3)),1) +' Dr' ELSE CONVERT(varchar(30), CAST(SUM(CR*CONRATE)-SUM(DR*CONRATE) AS DECIMAL(15,3)),1) + ' Cr' END)  AS [Balance] from ledgerbook where isdeleted=0 and ledgername in (select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtGroupName.Text & "')) " & AdditionalWhereSQLStr
            End If
        Else
            If TxtGroupName.Text.Length = 0 Or TxtGroupName.Text = "*All" Then
                SqlStr = "SELECT ledgername AS [Account Name],SUM(DR) AS [Dr Amount],SUM(CR) as [Cr Amount],(CASE  WHEN SUM(DR)-SUM(CR)>=0 THEN CONVERT(varchar(30), CAST(SUM(DR)-SUM(CR) AS DECIMAL(15,3)),1) +' Dr' ELSE CONVERT(varchar(30), CAST(SUM(CR)-SUM(DR) AS DECIMAL(15,3)),1) + ' Cr' END)  AS [Balance] from ledgerbook where isdeleted=0  " & AdditionalWhereSQLStr
            Else
                SqlStr = "SELECT ledgername AS [Account Name],SUM(DR) AS [Dr Amount],SUM(CR) as [Cr Amount],(CASE  WHEN SUM(DR)-SUM(CR)>=0 THEN CONVERT(varchar(30), CAST(SUM(DR)-SUM(CR) AS DECIMAL(15,3)),1) +' Dr' ELSE CONVERT(varchar(30), CAST(SUM(CR)-SUM(DR) AS DECIMAL(15,3)),1) + ' Cr' END)  AS [Balance] from ledgerbook where isdeleted=0 and ledgername in (select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtGroupName.Text & "')) " & AdditionalWhereSQLStr
            End If
            TxtCurrencyName.Text = "Figures in " & CompDetails.Currency
        End If




        SqlStr = SqlStr & AddSqlText
        SqlStr = SqlStr & " GROUP BY ledgername "

        If TxtOrderBy.Text = "Dr Amount Ascending" Then
            SqlStr = SqlStr & " ORDER BY [Dr Amount] ASC"
        ElseIf TxtOrderBy.Text = "Dr Amount Descending" Then
            SqlStr = SqlStr & " ORDER BY [Dr Amount] DESC"
        ElseIf TxtOrderBy.Text = "Cr Amount Ascending" Then
            SqlStr = SqlStr & " ORDER BY [Cr Amount] ASC"
        ElseIf TxtOrderBy.Text = "Cr Amount Descending" Then
            SqlStr = SqlStr & " ORDER BY [Cr Amount] DESC"
        ElseIf TxtOrderBy.Text = "Balance Ascending" Then
            SqlStr = SqlStr & " ORDER BY [Balance] ASC"
        ElseIf TxtOrderBy.Text = "Balance Descending" Then
            SqlStr = SqlStr & " ORDER BY [Balance] DESC"
        ElseIf TxtOrderBy.Text = "Name Ascending" Then
            SqlStr = SqlStr & " ORDER BY ledgername ASC"
        ElseIf TxtOrderBy.Text = "Name Descending" Then
            SqlStr = SqlStr & " ORDER BY ledgername DESC"
        End If


        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)

            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            Me.TxtList.Columns("Account Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns("Account Name").Width = 150

            Me.TxtList.Columns("Dr Amount").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Dr Amount").Width = 200
            Me.TxtList.Columns("Dr Amount").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("Dr Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("Cr Amount").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Cr Amount").Width = 200
            Me.TxtList.Columns("Cr Amount").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("Cr Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            Me.TxtList.Columns("Balance").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Balance").Width = 200
            Me.TxtList.Columns("Balance").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("Balance").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Catch ex As Exception

        End Try
        TxtCrTotal.Text = "0"
        txtDrTotal.Text = "0"

        If TxtGroupName.Text.Length = 0 Or TxtGroupName.Text = "*All" Then
            txtDrTotal.Text = FormatNumber(SQLGetNumericFieldValue("select sum(dr) as Dramt  from ledgerbook where isdeleted=0 " & AdditionalWhereSQLStr, "Dramt"), ErpDecimalPlaces)
            TxtCrTotal.Text = FormatNumber(SQLGetNumericFieldValue("select sum(cr) as Dramt  from ledgerbook where isdeleted=0 " & AdditionalWhereSQLStr, "Dramt"), ErpDecimalPlaces)
        Else
            txtDrTotal.Text = FormatNumber(SQLGetNumericFieldValue("select sum(dr) as Dramt  from ledgerbook where isdeleted=0 and ledgername in (select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtGroupName.Text & "'))" & AdditionalWhereSQLStr, "Dramt"), ErpDecimalPlaces)
            TxtCrTotal.Text = FormatNumber(SQLGetNumericFieldValue("select sum(cr) as Dramt  from ledgerbook where isdeleted=0 and ledgername in (select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtGroupName.Text & "'))" & AdditionalWhereSQLStr, "Dramt"), ErpDecimalPlaces)
        End If

        If CDbl(txtDrTotal.Text) - CDbl(TxtCrTotal.Text) >= 0 Then
            TxtNetTotal.Text = CompDetails.Currency & " " & FormatNumber(CDbl(txtDrTotal.Text) - CDbl(TxtCrTotal.Text), ErpDecimalPlaces).ToString & " Dr"
        Else
            TxtNetTotal.Text = CompDetails.Currency & " " & FormatNumber(CDbl(TxtCrTotal.Text) - CDbl(txtDrTotal.Text), ErpDecimalPlaces).ToString & " Cr"
        End If


        If TxtGroupName.Text = "*All" Then
            TxtHeading.Text = "ACCOUNTS BALANCE REPORT"
        Else
            TxtHeading.Text = UCase(TxtGroupName.Text) & "  REPORT "
        End If
    End Sub

    Private Sub LedgerBalanceSheetForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub LedgerBalanceSheetForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

       
        LoadDataIntoComboBox("select locationname  from StockLocations", TxtLocationWise, "locationname", "*All")
        LoadDataIntoComboBox("select UserID  from users", TxtUserWise, "UserID", "*All")
        TxtUserWise.Items.Add(SQLGetStringFieldValue("select adminname from company", "adminname"))
        LoadDataIntoComboBox("select groupname from accountgroups", TxtGroupName, "groupname", "*All")
        TxtOrderBy.Text = "Name Ascending"
        LoadCustomersBalances()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, PrintToolStripMenuItem.Click
        If SqlStr.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(SqlStr, cnn)
        dscmd.Fill(ds, "ledgerbook")
        cnn.Close()
        Dim objRpt As New AccountBalancesCrReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
        End If

        CType(objRpt.Section4.ReportObjects.Item("TXTTOTAL"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtNetTotal.Text

        objRpt.SetDataSource(ds)
        Dim FRM As New ReportCommonForm(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cursor = Cursors.Default
        FRM.ShowDialog()
        FRM.Dispose()
        objRpt.Dispose()
        ds.Dispose()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        LoadCustomersBalances()
    End Sub

    Private Sub TxtSearchBy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearchBy.TextChanged
        If TxtSearchBy.Text.Length > 0 Then
            If TxtSearchOption.Text.Length = 0 Or TxtSearchOption.Text = "Contains" Then
                LoadCustomersBalances(" and ledgername LIKE N'%" & TxtSearchBy.Text & "%' ")
            ElseIf TxtSearchOption.Text = "Begin with" Then
                LoadCustomersBalances(" and ledgername LIKE N'" & TxtSearchBy.Text & "%' ")
            ElseIf TxtSearchOption.Text = "End With" Then
                LoadCustomersBalances(" and ledgername LIKE N'%" & TxtSearchBy.Text & "' ")
            Else
                LoadCustomersBalances(" and ledgername LIKE N'%" & TxtSearchBy.Text & "%' ")
            End If
        Else
            LoadCustomersBalances()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOrderBy.SelectedIndexChanged
        LoadCustomersBalances()
    End Sub

    

    Private Sub TxtIsCurrency_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIsCurrency.CheckedChanged
        LoadCustomersBalances()
    End Sub

  

    Private Sub TxtList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellDoubleClick
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        Dim K As New MonthlyAccountBalanceSheet(TxtList.Item("Account Name", TxtList.CurrentRow.Index).Value)
        Me.Cursor = Cursors.WaitCursor
        K.SuspendLayout()
        K.MdiParent = MainForm
        K.Dock = DockStyle.Fill
        K.TxtHeading.Text = UCase(TxtList.Item("Account Name", TxtList.CurrentRow.Index).Value) & " " & " BALANCE SHEET"
        K.Show()
        K.WindowState = FormWindowState.Maximized
        K.BringToFront()
        K.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

   
   
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TxtGroupName.Text = "*All" Or TxtGroupName.Text.Length = 0 Then
            TxtHeading.Text = "ACCOUNTS BALANCE REPORT"
        Else
            TxtHeading.Text = UCase(TxtGroupName.Text) & "  REPORT "
        End If

        LoadCustomersBalances()
    End Sub

    Private Sub TxtGroupName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtGroupName.SelectedIndexChanged

    End Sub

    Private Sub TxtList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub
End Class