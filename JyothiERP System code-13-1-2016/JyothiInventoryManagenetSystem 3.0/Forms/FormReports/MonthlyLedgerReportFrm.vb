Imports System.Data.SqlClient
Imports System.IO

Public Class MonthlyLedgerReportFrm
    'LEDGER MONTHLY REPORT
    Dim sqlstr As String = ""
    Sub loadreport()
        TxtHeading.Text = TxtLedgerName.Text & " LEDGER MONTHLY REPORT "
        If TxtLedgerName.Text.Length = 0 Then Exit Sub

        If TxtStartDate.Value > TxtEndDate.Value Then
            Dim k As New DateTimePicker
            k = TxtStartDate
            TxtStartDate = TxtEndDate
            TxtEndDate = k
        End If
        TxtStartDate.Value = New Date(TxtStartDate.Value.Year, TxtStartDate.Value.Month, 1)
        TxtEndDate.Value = New Date(TxtEndDate.Value.Year, TxtEndDate.Value.Month, Date.DaysInMonth(TxtEndDate.Value.Year, TxtEndDate.Value.Month))
        If DateDiff(DateInterval.Year, TxtStartDate.Value.Date, TxtEndDate.Value.Date) > 35 Then
            If MsgBox("Too long date range , Please select the 35 years only..." + Chr(13) + "Do you want to Continue. ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        MainForm.Cursor = Cursors.WaitCursor
        sqlstr = "exec Pro_DayBrkMonthReport N'" & TxtLedgerName.Text & "','" & TxtStartDate.Value.Year & "-" & TxtStartDate.Value.Month & "-" & TxtStartDate.Value.Day & "','" & TxtEndDate.Value.Year & "-" & TxtEndDate.Value.Month & "-" & TxtEndDate.Value.Day & "'"
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        MainForm.Cursor = Cursors.Default
        Try
            TxtList.Columns("sno").Visible = False
            TxtList.Columns("Period").Width = 150
            TxtList.Columns("DrAmount").Width = 120
            TxtList.Columns("DrAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("DrAmount").DefaultCellStyle.Format = "N2"
            TxtList.Columns("CrAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("CrAmount").DefaultCellStyle.Format = "N2"
            TxtList.Columns("CrAmount").Width = 120
            TxtList.Columns("ClosingBalance").Width = 150
            TxtList.Columns("ClosingBalance").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception

        End Try

    End Sub


    Private Sub LedgerDayBreakReport_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadDataIntoComboBox("SELECT LEDGERNAME FROM LEDGERS ", TxtLedgerName, "ledgername")
        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        loadreport()
    End Sub

    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click
        loadreport()
    End Sub

    Private Sub BtnPrint_Click(sender As System.Object, e As System.EventArgs) Handles BtnPrint.Click
        If sqlstr.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New MonthlyLedgerReportDataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(sqlstr, cnn)
        dscmd.Fill(ds, "DataTable1")
        cnn.Close()
        Dim objRpt As New MonthlyLedgerCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text & Chr(13) & " For Period: " & TxtStartDate.Value.Date.ToString("dd/MM/yyyy") & " To " & TxtEndDate.Value.Date.ToString("dd/MM/yyyy")
        Else
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text & Chr(13) & " For Period: " & TxtStartDate.Value.Date.ToString("dd/MM/yyyy") & " To " & TxtEndDate.Value.Date.ToString("dd/MM/yyyy")
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

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub TxtLedgerName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtLedgerName.SelectedIndexChanged
        btnsendemail.Enabled = False
        If TxtLedgerName.Text.Length = 0 Then Exit Sub
        TxtHeading.Text = UCase(TxtLedgerName.Text) & "  TRANSACTIONS SUMMARY"
        If TxtLedgerName.Text.Length = 0 Or TxtLedgerName.Text = "*All" Then
        Else
            If SQLIsFieldExists("SELECT LEDGERNAME FROM LEDGERS WHERE LEDGERNAME=N'" & TxtLedgerName.Text & "' AND ISSENDEMAIL='True'") = True Then
                btnsendemail.Enabled = True
            Else
                btnsendemail.Enabled = False
            End If
        End If
        loadreport()
    End Sub

    Private Sub btnsendemail_Click(sender As System.Object, e As System.EventArgs) Handles btnsendemail.Click
        If SQLIsFieldExists("SELECT LEDGERNAME FROM LEDGERS WHERE LEDGERNAME=N'" & TxtLedgerName.Text & "' AND ISSENDEMAIL='True'") = True Then
            If MsgBox("Do you want to send E-Mail to " & TxtLedgerName.Text & " ?          ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If sqlstr.Length = 0 Then Exit Sub
                Me.Cursor = Cursors.WaitCursor
                Dim ds As New MonthlyLedgerReportDataSet
                Dim cnn As SqlConnection
                cnn = New SqlConnection(ConnectionStrinG)
                cnn.Open()
                Dim dscmd As New SqlDataAdapter(sqlstr, cnn)
                dscmd.Fill(ds, "DataTable1")
                cnn.Close()
                Dim objRpt As New MonthlyLedgerCRReport
                SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
                If PrintOptionsforCR.IsPrintHeader = False Then
                    CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
                    CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
                    CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text & Chr(13) & " For Period: " & TxtStartDate.Value.Date.ToString("dd/MM/yyyy") & " To " & TxtEndDate.Value.Date.ToString("dd/MM/yyyy")
                Else
                    CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text & Chr(13) & " For Period: " & TxtStartDate.Value.Date.ToString("dd/MM/yyyy") & " To " & TxtEndDate.Value.Date.ToString("dd/MM/yyyy")
                End If

                objRpt.SetDataSource(ds)
                Dim printfilename As String = ""
                printfilename = Path.GetTempPath() & TxtLedgerName.Text & "-LedBalanceSheet-" & Now.ToString("yyyy-MM-dd HH mm ss") & ".pdf"
                objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, printfilename)
                objRpt.Dispose()

                SendCustomEmailTo(SQLGetStringFieldValue("SELECT emailid FROM LEDGERS WHERE LEDGERNAME=N'" & TxtLedgerName.Text & "'", "emailid"), TxtHeading.Text, "Dear Sir, Please Find the attachement for Monthly Balance sheet", printfilename)
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub
End Class