Imports System.Data.SqlClient

Public Class OverdueReceivablesForm
    ' SELECT     TransCode AS [Trans Code], RefNo AS [Ref No], InvoiceNo AS [Invoice No], TransDate AS Date,
    '                       (SELECT     (CASE WHEN SUM(DR + CR) > 0 THEN SUM(DR + CR) ELSE 0 END) AS tot
    '                        FROM          dbo.Bill2Bill
    '                       WHERE      (LedgerName = Bill2Bill_1.LedgerName) AND (BillType = 'Against') AND (RefNo = Bill2Bill_1.RefNo)) AS [Paid Amount], DATEDIFF(day, TransDate, 
    '                { fn CURDATE() }) AS [No Days], Cr + Dr AS Balance, DATEDIFF(day, TransDate, { fn CURDATE() }) AS Expr1
    'FROM         dbo.Bill2Bill AS Bill2Bill_1'
    'WHERE     (BillType = 'New') AND (Cr + Dr -
    '                         (SELECT     (CASE WHEN SUM(DR + CR) > 0 THEN SUM(DR + CR) ELSE 0 END) AS tot
    '                          FROM          dbo.Bill2Bill AS Bill2Bill_2
    '                         WHERE      (LedgerName = Bill2Bill_1.LedgerName) AND (BillType = 'Against') AND (RefNo = Bill2Bill_1.RefNo)) > 0)



    Dim SQLstr As String = ""
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadData()


        SQLstr = "select transdate as [Trans Date],refno as [Ref No],InvoiceNo AS [Invoice No], transcode as [Trans Code],ledgername as [Customer Name], dr+cr as [Bill Amount], " _
            & " (SELECT (CASE WHEN SUM(DR+CR)>0 THEN SUM(DR+CR) ELSE 0 END) as tot from bill2bill WHERE (LEDGERNAME=btable.LEDGERNAME AND BILLTYPe='Against' and refno=btable.refno )) AS [Paid Amount], " _
            & "((dr+cr)-(SELECT (CASE WHEN SUM(DR+CR)>0 THEN SUM(DR+CR) ELSE 0 END)  as tot from bill2bill WHERE (LEDGERNAME=btable.LEDGERNAME AND BILLTYPe='Against' and refno=btable.refno ))) AS [Balance] ," _
            & " DATEDIFF(day, TransDate, { fn CURDATE() } ) as [No Days] " _
            & " FROM BILL2BILL as btable WHERE BILLTYPE='New' "


        If TxtLedgerName.Text.Length = 0 Or TxtLedgerName.Text = "*All" Then
            SQLstr = SQLstr & " and (ledgername in (select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "'))) "
        Else
            SQLstr = SQLstr & " and ledgername=N'" & TxtLedgerName.Text & "'"
        End If
        Dim substring As String = " and ((dr+cr)-(SELECT (CASE WHEN SUM(DR+CR)>0 THEN SUM(DR+CR) ELSE 0 END) as tot from bill2bill AS BTABLE2 WHERE LEDGERNAME=btable.LEDGERNAME AND BILLTYPe='Against' AND refno=btable.refno ))> 0"
        If IsShowAll.Checked = False Then
            SQLstr = SQLstr & substring
        End If
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SQLstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("Trans Date").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Trans Date").Width = 80

            TxtList.Columns("Ref No").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Ref No").Width = 80

            TxtList.Columns("Trans Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Trans Code").Width = 80

            TxtList.Columns("Bill Amount").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Bill Amount").Width = 120

            TxtList.Columns("Customer Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("Customer Name").Width = 500

            TxtList.Columns("Paid Amount").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Paid Amount").Width = 120

            TxtList.Columns("Balance").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Balance").Width = 120

            TxtList.Columns("No Days").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("No Days").Width = 100
        Catch ex As Exception

        End Try
        Dim TTO As Double = 0
        For I As Integer = 0 To TxtList.RowCount - 1
            TTO = TTO + CDbl(TxtList.Item("BALANCE", I).Value)
        Next
        TxtTotal4.Text = FormatNumber(TTO, ErpDecimalPlaces)
    End Sub

    Private Sub OverdueReceivablesForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub OverdueReceivablesForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "')", TxtLedgerName, "ledgername", "*All")
        LoadData()
    End Sub

    Private Sub IsShowAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsShowAll.CheckedChanged
        LoadData()
    End Sub

    Private Sub TxtLedgerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.SelectedIndexChanged
        LoadData()
        If TxtLedgerName.Text.Length = 0 Or TxtLedgerName.Text = "*All" Then

        Else
            TxtHeading.Text = " OVERDUE RECEIVABLES FOR A/C: " & UCase(TxtLedgerName.Text)

        End If
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If SQLstr.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(SQLstr, cnn)
        dscmd.Fill(ds, "bill2bill")
        cnn.Close()
        Dim objRpt As New OverDueCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text

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
End Class