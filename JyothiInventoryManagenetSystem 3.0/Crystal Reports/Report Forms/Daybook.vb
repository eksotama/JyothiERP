Imports System.Data.SqlClient

Public Class Daybook

    Dim CustSqlStr As String = ""
    Dim CrepGbal As New DayBookCRReport
    'Dim Para1 As String
    'Sub New(ByVal LedgerName As String)

    '    ' This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.
    '    Para1 = LedgerName
    'End Sub


    Sub LoadLedgerReport()
        Me.Cursor = Cursors.WaitCursor
        If TxtByLedger.Text.Length = 0 Then
            TxtByLedger.Text = "*All"
        End If
        If TxtStartDate.Value > TxtEndDate.Value Then
            Dim ka As DateTimePicker
            ka = TxtStartDate
            TxtStartDate = TxtEndDate
            TxtEndDate = ka
        End If
        Dim SubStr As String = ""
        Dim SubReportstr As String = ""
        Dim dbf As New ADODB.Recordset
        Dim crep As New DayBookCRReport
        Dim myDataSet As New DataSet
        Dim mysubdataset As New DataSet
        mysubdataset.Clear()
        myDataSet.Clear()
        If TxtOtherReports.Text = "Day Book" Then
            SubStr = "where sno=1 "
            SubReportstr = "select * from Ledgerbook where sno<>1 and isdeleted=0"
        Else
            SubStr = "where ledgername=N'" & TxtOtherReports.Text & "' and isdeleted=0 "
            SubReportstr = "select * from Ledgerbook where  AcLedger<>N'" & TxtOtherReports.Text & "' and isdeleted=0 and ledgername<>N'" & TxtOtherReports.Text & "'"
        End If
        If TxtDetailedView.Checked = True Or TxtNarrationAslo.Checked = True Then
            Dim cnn1 As SqlConnection
            cnn1 = New SqlConnection(ConnectionStrinG)
            cnn1.Open()
            Dim dscmd1 As New SqlDataAdapter(SubReportstr, cnn1)
            dscmd1.Fill(mysubdataset, "ledgerbook")
            cnn1.Close()
            cnn1.Dispose()
            crep.Subreports.Item(0).SetDataSource(mysubdataset)
        End If
        If TxtDetailedView.Checked = True And TxtNarrationAslo.Checked = True Then
            crep.Subreports.Item(0).ReportDefinition.Sections(2).SectionFormat.EnableSuppress = False
            crep.Subreports.Item(0).ReportDefinition.Sections(3).SectionFormat.EnableSuppress = False


        ElseIf TxtDetailedView.Checked = True And TxtNarrationAslo.Checked = False Then
            crep.Subreports.Item(0).ReportDefinition.Sections(2).SectionFormat.EnableSuppress = False
            crep.Subreports.Item(0).ReportDefinition.Sections(3).SectionFormat.EnableSuppress = True

        ElseIf TxtDetailedView.Checked = False And TxtNarrationAslo.Checked = True Then
            crep.Subreports.Item(0).ReportDefinition.Sections(2).SectionFormat.EnableSuppress = True
            crep.Subreports.Item(0).ReportDefinition.Sections(3).SectionFormat.EnableSuppress = False
        Else
            crep.Subreports.Item(0).ReportDefinition.Sections(2).SectionFormat.EnableSuppress = True
            crep.Subreports.Item(0).ReportDefinition.Sections(3).SectionFormat.EnableSuppress = True

        End If
        crep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter

        If TxtIsVouchers.Checked = True Then
            SubStr = SubStr & " and  invoicename=N'" & txtvoucher.Text & "' "
        End If
        If TxtIsPeriod.Checked = True Then
            SubStr = SubStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
        End If
        If TxtByLedger.Text = "*All" Then

        Else
            SubStr = SubStr & " and  ledgername=N'" & TxtByLedger.Text & "' "
        End If
        Dim orderStr As String = ""
        Select Case TxtReportOptions.SelectedIndex
            Case 0
                If TxtOtherReports.Text = "Day Book" Then
                    orderStr = " order by ledgername DESC "
                Else
                    orderStr = " order by acledger DESC "
                End If
            Case 1
                If TxtOtherReports.Text = "Day Book" Then
                    orderStr = " order by ledgername asc"
                Else
                    orderStr = " order by acledger asc"
                End If
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



        CustSqlStr = "Select * from ledgerbook " & SubStr & orderStr


        If TxtOtherReports.Text = "Day Book" Then
            crep.Section3.ReportObjects.Item("ledgername1").ObjectFormat.EnableSuppress = False
            crep.Section3.ReportObjects.Item("acledger1").ObjectFormat.EnableSuppress = True

        Else
            crep.Section3.ReportObjects.Item("ledgername1").ObjectFormat.EnableSuppress = True
            crep.Section3.ReportObjects.Item("acledger1").ObjectFormat.EnableSuppress = False
        End If
      
        

        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(CustSqlStr, cnn)
        dscmd.Fill(myDataSet, "ledgerbook")
        cnn.Close()
        cnn.Dispose()
        crep.SetDataSource(myDataSet)



        SetReportLogos(crep.Section1.ReportObjects, crep.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(crep.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(crep.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(crep.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtOtherReports.Text.ToString
        Else
            CType(crep.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtOtherReports.Text.ToString
        End If

        If TxtIsPeriod.Checked = True Then
            CType(crep.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Period :" & TxtStartDate.Value.Date & " To " & TxtEndDate.Value.Date
        Else
            CType(crep.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ""
        End If

        Me.CrystalReportViewer1.ReportSource = crep
        Me.CrystalReportViewer1.RefreshReport()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub UserButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton1.Click
        LoadLedgerReport()
    End Sub

    Private Sub Daybook_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub daybook_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If My.Computer.Screen.WorkingArea.Width <= 1024 Then
            Me.Font = New Font(Me.Font.Name, 8, FontStyle.Regular)
        End If
        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        Me.SuspendLayout()
        My.Application.DoEvents()
        TxtReportOptions.Text = "Default"
        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        LoadDataIntoComboBox("select distinct InvoiceName from ledgerbook", txtvoucher, "InvoiceName")
        LoadDataIntoComboBox("SELECT ledgername FROM ledgers  ", TxtByLedger, "ledgername", "*All")
        TxtOtherReports.Items.Add("Day Book")
        TxtOtherReports.Text = "Day Book"
        LoadLedgerReport()
        Me.ResumeLayout()
    End Sub

    Private Sub TxtIsVouchers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIsVouchers.CheckedChanged
        If TxtIsVouchers.Checked = True Then
            txtvoucher.Enabled = True
            UserButton3.Enabled = True
        Else
            UserButton3.Enabled = False
            txtvoucher.Enabled = False
        End If
    End Sub

    Private Sub TxtIsPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIsPeriod.CheckedChanged
        If TxtIsPeriod.Checked = True Then
            TxtStartDate.Enabled = True
            TxtEndDate.Enabled = True
        Else
            TxtStartDate.Enabled = False
            TxtEndDate.Enabled = False
        End If
    End Sub

    Private Sub TxtDetailedView_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDetailedView.CheckedChanged
        LoadLedgerReport()
    End Sub

    
    Private Sub TxtNarrationAslo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNarrationAslo.CheckedChanged
        LoadLedgerReport()
    End Sub

    Private Sub UserButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton2.Click
        LoadLedgerReport()
    End Sub

    Private Sub UserButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton3.Click
        LoadLedgerReport()
    End Sub

    Private Sub UserButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton4.Click
        LoadLedgerReport()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        LoadLedgerReport()
    End Sub

    Private Sub TxtByLedger_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtByLedger.SelectedIndexChanged
        LoadLedgerReport()
    End Sub
End Class