Public Class DaybookReportFrm
    Dim SubStr As String = ""
    Dim SubReportstr As String = ""
    Dim CustSqlStr As String = ""
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadData()
        If TxtByLedger.Text.Length = 0 Then
            TxtByLedger.Text = "*All"
        End If
        If TxtShowDetailed.Checked = True Then
            Dim detsqlstr As String = ""
            detsqlstr = "(CASE WHEN dr-cr>0 THEN dr ELSE cr END)"
            If TxtShowNarration.Checked = True Then
                SubReportstr = "select (CASE WHEN SNO=1 THEN TransDate ELSE NULL END)  as [Date], Right(replicate(' ' ,75)+(CASE WHEN SNO=1 THEN (ledgername) ELSE CAST(ledgername as char(75)) END),75) + (CASE WHEN DR>0 THEN CAST(DR AS CHAR(15)) ELSE CAST(CR AS CHAR(15)) END ) as [Details], (CASE WHEN SNO=1 THEN invoicename ELSE NULL END)  as [Vh Name], (CASE WHEN SNO=1 THEN invoiceno ELSE NULL END)  as [Vh No], (CASE WHEN SNO=1 THEN Dr ELSE NULL END)  as [Dr Amount],(CASE WHEN SNO=1 THEN Cr ELSE NULL END)   as [Cr Amount] from Ledgerbook "
                TxtList.RowTemplate.Height = 35
            Else
                SubReportstr = "select (CASE WHEN SNO=1 THEN TransDate ELSE NULL END)  as [Date],  (ledgername ) as [Details], (CASE WHEN SNO=1 THEN invoicename ELSE NULL END)  as [Vh Name], (CASE WHEN SNO=1 THEN invoiceno ELSE NULL END)  as [Vh No], (CASE WHEN SNO=1 THEN Dr ELSE NULL END)  as [Dr Amount],(CASE WHEN SNO=1 THEN Cr ELSE NULL END)   as [Cr Amount] from Ledgerbook "
                TxtList.RowTemplate.Height = 23
            End If
            '(CASE WHEN SNO=1 THEN  ELSE END)
            SubStr = " where  isdeleted=0  "
            If IsDateWiseOn.Checked = True Then
                SubStr = SubStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
            End If
            If TxtByVouchers.Text.Length = 0 Or TxtByVouchers.Text = "*All" Then
            Else
                SubStr = SubStr & " and invoicename=N'" & TxtByVouchers.Text & "'"
            End If
            If TxtByLedger.Text = "*All" Then
            Else
                SubStr = SubStr & " and ledgername=N'" & TxtByLedger.Text & "'"
            End If
        Else
            If TxtShowNarration.Checked = True Then
                SubReportstr = "select TransDate as [Date], (ledgername + char(13) + narration) as [Details],invoicename as [Vh Name], invoiceno as [Vh No], Dr as [Dr Amount],cr  as [Cr Amount] from Ledgerbook "
                TxtList.RowTemplate.Height = 35
            Else
                SubReportstr = "select TransDate as [Date], ledgername as [Details],invoicename as [Vh Name], invoiceno as [Vh No], dr as [Dr Amount],cr  as [Cr Amount] from Ledgerbook  "
                TxtList.RowTemplate.Height = 23
            End If
            SubStr = " where sno=1 and isdeleted=0  "
            If IsDateWiseOn.Checked = True Then
                SubStr = SubStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
            End If
            If TxtByVouchers.Text.Length = 0 Or TxtByVouchers.Text = "*All" Then
            Else
                SubStr = SubStr & " and invoicename=N'" & TxtByVouchers.Text & "'"
            End If
            If TxtByLedger.Text = "*All" Then
            Else
                SubStr = SubStr & " and ledgername=N'" & TxtByLedger.Text & "'"
            End If
        End If


        Dim orderStr As String = ""
        Select Case TxtReportOptions.SelectedIndex
            Case 0
                orderStr = " order by ledgername DESC "
            Case 1
                orderStr = " order by ledgername asc"
            Case 2
                orderStr = " order by (cr+dr) DESC "
            Case 3
                orderStr = " order by (cr+dr) ASC "
            Case 4
                orderStr = " order by transdate DESC "
            Case 5
                orderStr = " order by transdate ASC "
            Case 6
                orderStr = " order by transcode DESC "
            Case 7
                orderStr = " order by invoiceno DESC "
            Case 8
                orderStr = " order by invoiceno ASC "
            Case 9
                orderStr = " order by invoicename DESC , transdate "
            Case 10
                orderStr = " order by invoicename ASC, transdate "
            Case Else
                orderStr = " order by transdate ASC "

        End Select
        CustSqlStr = SubReportstr & SubStr & orderStr

        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(CustSqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            TxtList.Columns("Date").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Date").Width = 80

            TxtList.Columns("Details").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("Details").Width = 120
            TxtList.Columns("Details").DefaultCellStyle.WrapMode = DataGridViewTriState.True

            TxtList.Columns("Vh Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Vh Name").Width = 100

            TxtList.Columns("Vh No").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Vh No").Width = 75

            TxtList.Columns("Dr Amount").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Dr Amount").Width = 100
            TxtList.Columns("Dr Amount").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Dr Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TxtList.Columns("Cr Amount").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Cr Amount").Width = 100
            TxtList.Columns("Cr Amount").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Cr Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception

        End Try
        txtDrTotal.Text = FormatNumber(SQLGetNumericFieldValue("select sum(dr) as tot from ledgerbook " & SubStr, "tot"), ErpDecimalPlaces)
        TxtCrTotal.Text = FormatNumber(SQLGetNumericFieldValue("select sum(cr) as tot from ledgerbook " & SubStr, "tot"), ErpDecimalPlaces)
    End Sub

    Private Sub DaybookReportFrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub DaybookReportFrm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        TxtList.Dispose()
    End Sub

    Private Sub DaybookReportFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        'invoicename
        LoadDataIntoComboBox("SELECT DISTINCT invoicename FROM LEDGERBOOK ", TxtByVouchers, "INVOICENAME", "*All")
        LoadDataIntoComboBox("SELECT ledgername FROM ledgers  ", TxtByLedger, "ledgername", "*All")
        LoadData()
    End Sub

    Private Sub TxtReportOptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtReportOptions.SelectedIndexChanged, TxtByVouchers.SelectedIndexChanged, TxtByLedger.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub UserButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton4.Click, RefreshToolStripMenuItem.Click
        LoadData()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, RefreshToolStripMenuItem.Click
        LoadData()
    End Sub

    Private Sub TxtShowNarration_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShowNarration.CheckedChanged, TxtShowDetailed.CheckedChanged
        LoadData()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Me.Cursor = Cursors.WaitCursor
        Daybook.SuspendLayout()
        Daybook.MdiParent = MainForm
        Daybook.Dock = DockStyle.Fill
        Daybook.Show()
        Daybook.WindowState = FormWindowState.Maximized
        Daybook.BringToFront()
        Daybook.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub
End Class