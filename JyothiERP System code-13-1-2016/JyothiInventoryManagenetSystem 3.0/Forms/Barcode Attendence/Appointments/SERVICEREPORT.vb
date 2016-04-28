Imports System.Data.SqlClient
Imports System.IO
Public Class SERVICEREPORT
    Dim SqlStr As String = ""
    Dim ReportSqlStr As String = ""
   

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadReport()
        
        SqlStr = " SELECT EMPNAME,appid,datestart,dateend,note,ledgername, (select sum(rate) form FROM AppointmentRows   WHERE AppointmentRows.appID = Appointmentdb.appID ) as Price, (SELECT ServiceName + ',' FROM AppointmentRows   WHERE AppointmentRows.appID = Appointmentdb.appID     ORDER BY ServiceName FOR XML PATH('') ) AS SERVICELIST FROM Appointmentdb  "
        If IsDateWiseOn.Checked = True Then
            If TxtLedgerName.Text.Length = 0 Or TxtLedgerName.Text = "*All" Then
                SqlStr = SqlStr & " where (dateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & " )"
            Else
                SqlStr = SqlStr & " where (dateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & " ) and empname=N'" & TxtLedgerName.Text & "'"
            End If

        Else
            If TxtLedgerName.Text.Length = 0 Or TxtLedgerName.Text = "*All" Then
            Else
                SqlStr = SqlStr & " where empname=N'" & TxtLedgerName.Text & "'"
            End If
        End If
        Dim TempBS As New BindingSource
        ReportSqlStr = SqlStr
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        If IsDateWiseOn.Checked = True Then
            If TxtLedgerName.Text.Length = 0 Or TxtLedgerName.Text = "*All" Then
                SqlStr = "select sum(rate) AS TOT from AppointmentRows where appid in " & "(SELECT APPID FROM Appointmentdb where (dateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & " ))"
            Else
                SqlStr = "select sum(rate) AS TOT from AppointmentRows where appid in " & "(SELECT APPID FROM Appointmentdb where (dateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & " ) and empname=N'" & TxtLedgerName.Text & "')"
            End If

        Else
            If TxtLedgerName.Text.Length = 0 Or TxtLedgerName.Text = "*All" Then
                SqlStr = "select sum(rate) AS TOT from AppointmentRows "
            Else
                SqlStr = "select sum(rate) AS TOT from AppointmentRows where appid in " & "(SELECT APPID FROM Appointmentdb where empname=N'" & TxtLedgerName.Text & "')"
            End If
        End If

        TxtNetTotal.Text = SQLGetNumericFieldValue(SqlStr, "TOT")

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TxtIsCurrency_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadReport()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, RefreshToolStripMenuItem.Click
        LoadReport()
    End Sub

    Private Sub TxtLedgerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.SelectedIndexChanged
      

        LoadReport()
    End Sub

    Private Sub TxtShowNarration_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadReport()
    End Sub

    Private Sub SERVICEREPORT_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub LedgerTransactionsReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select EmpName from Employees ", TxtLedgerName, "EmpName", "*All")
        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value


    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, PrintToolStripMenuItem.Click
        If ReportSqlStr.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DailyAppServiceDataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(ReportSqlStr, cnn)
        dscmd.Fill(ds, "DataTable1")
        cnn.Close()
        Dim objRpt As New ServiceReports
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
            If IsDateWiseOn.Checked = True Then
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text & Chr(13) & " Period From " & TxtStartDate.Value.Date & " To " & TxtEndDate.Value.Date
            Else
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
            End If

        Else
            If IsDateWiseOn.Checked = True Then
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text & Chr(13) & " Period From " & TxtStartDate.Value.Date & " To " & TxtEndDate.Value.Date
            Else
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
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



   
End Class