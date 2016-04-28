Imports System.Data.SqlClient

Public Class dailyservicereportfrm
    Dim SqlStr As String = ""
    Dim ReportSqlStr As String = ""


    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        Me.Cursor = Cursors.WaitCursor
        LoadReport()
        Me.Cursor = Cursors.Default
    End Sub
    Sub LoadReport()

        SqlStr = " SELECT EMPNAME,appid,datestart,dateend,note,ledgername, (select sum(rate) form FROM AppointmentRows   WHERE AppointmentRows.appID = Appointmentdb.appID ) as Price, (SELECT ServiceName + ',' FROM AppointmentRows   WHERE AppointmentRows.appID = Appointmentdb.appID     ORDER BY ServiceName FOR XML PATH('') ) AS SERVICELIST FROM Appointmentdb   where (dateValue=" & TxtStartDate.Value.Date.ToOADate & ") "


        Dim ds As New DailyAppServiceDataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(SqlStr, cnn)
        dscmd.Fill(ds, "DataTable1")
        cnn.Close()
        Dim objRpt As New DailyServiceReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text & " Period For " & TxtStartDate.Value.Date
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text & " Period For " & TxtStartDate.Value.Date
        End If



        objRpt.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = objRpt
        CrystalReportViewer1.Refresh()
        objRpt.Dispose()
        ds.Dispose()

    End Sub



    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, RefreshToolStripMenuItem.Click
        LoadReport()
    End Sub

    Private Sub dailyservicereportfrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub



    Private Sub LedgerTransactionsReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = Today


    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub


End Class