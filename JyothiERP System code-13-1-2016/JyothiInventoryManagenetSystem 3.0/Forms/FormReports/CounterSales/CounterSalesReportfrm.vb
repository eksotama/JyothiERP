Public Class CounterSalesReportfrm
    Dim SqlStr As String = ""

    Sub loaddata()
        MainForm.Cursor = Cursors.WaitCursor
        Dim CounterID As Integer = 0
        If TxtUserWise.Text.Length = 0 Or TxtUserWise.Text = "*All" Then
            CounterID = 0
        Else
            CounterID = SQLGetNumericFieldValue("select counterID from Counters where countername=N'" & TxtUserWise.Text & "'", "counterID")
        End If
        Dim wherestr As String = ""
        SqlStr = "SELECT TRANSCODE,transdate as [Date],acledger as [Details], invoiceno as [Voucher No],invoicename as [Voucher Name],dr as [DR], cr as [CR] from ledgerbook where isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "'"
        wherestr = " where isdeleted=0 and ledgername=N'" & TxtLedgerName.Text & "'"
        If IsDateWiseOn.Checked = True Then
            SqlStr = SqlStr & " and (transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
            wherestr = wherestr & " and (transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "

        End If
        If TxtUserWise.Text.Length = 0 Or TxtUserWise.Text = "*All" Then

        Else
            SqlStr = SqlStr & " and CounterID=" & CounterID & "  "
            wherestr = wherestr & " and CounterID=" & CounterID & "  "
        End If
        If TxtLocationWise.Text.Length = 0 Or TxtLocationWise.Text = "*All" Then
        Else
            If TxtLocationWise.Text.ToUpper = "MainLocation".ToUpper Or TxtLocationWise.Text.ToUpper = "MainStore".ToUpper Then
                SqlStr = SqlStr & " and storename in ('MainLocation','MainStore') "
                wherestr = wherestr & " and storename in ('MainLocation','MainStore') "
            Else
                SqlStr = SqlStr & " and storename=N'" & TxtLocationWise.Text & "' "
                wherestr = wherestr & " and storename=N'" & TxtLocationWise.Text & "' "
            End If
        End If
        SqlStr = SqlStr & " order by TransDate, transcode"
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            Me.TxtList.Columns("TRANSCODE").Visible = False
            Me.TxtList.Columns("Date").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Date").Width = 100
            Me.TxtList.Columns("Date").DefaultCellStyle.Format = "d"
            Me.TxtList.Columns("Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.TxtList.Columns("Details").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns("Details").Width = 100

            Me.TxtList.Columns("Voucher No").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Voucher No").Width = 85

            Me.TxtList.Columns("Voucher Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Voucher Name").Width = 125



            Me.TxtList.Columns("DR").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("DR").Width = 150
            Me.TxtList.Columns("DR").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("DR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("Cr").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Cr").Width = 150
            Me.TxtList.Columns("Cr").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("Cr").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        Catch ex As Exception

        End Try
        Dim bal As Double = 0
        bal = SQLGetNumericFieldValue("select sum(dr-cr) as tot from ledgerbook " & wherestr, "tot")
        If bal > 0 Then
            TxtNetCrTotal.Visible = False
            TxtNetDrTotal.Visible = True
            TxtNetDrTotal.Text = FormatNumber(bal, 2)
        Else
            TxtNetCrTotal.Visible = True
            TxtNetDrTotal.Visible = False
            TxtNetCrTotal.Text = FormatNumber(bal * -1, 2)
        End If
        MainForm.Cursor = Cursors.Default
    End Sub
    Private Sub CounterSalesReportfrm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtStartDate.Value = Today
        TxtEndDate.Value = Today
        If IsUserAdmin = False Then
            LoadDataIntoComboBox("select distinct storename  from ledgerbook ", TxtLocationWise, "storename", "*All")
            TxtUserWise.Items.Add(CurrentCounterID)
            TxtUserWise.Text = CurrentCounterID
        Else
            LoadDataIntoComboBox("select distinct storename  from ledgerbook ", TxtLocationWise, "storename", "*All")
            LoadDataIntoComboBox("select Distinct countername from Counters", TxtUserWise, "countername", "*All")
        End If
        
        LoadDataIntoComboBox("SELECT LEDGERNAME FROM LEDGERS where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "'))", TxtLedgerName, "ledgername")
        TxtLocationWise.Text = "*All"
        If TxtUserWise.Items.Count > 0 Then
            TxtUserWise.SelectedIndex = 0
        End If
        If TxtLedgerName.Items.Count > 0 Then
            TxtLedgerName.Text = POSSettings.CashLedger
        End If
        loaddata()
    End Sub

    Private Sub CounterSalesReportfrm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click, RefreshToolStripMenuItem.Click
        loaddata()
    End Sub

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub IsDateWiseOn_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles IsDateWiseOn.CheckedChanged
        loaddata()
    End Sub
End Class