Imports System.Data.SqlClient

Public Class frmEmployeeSiteschedule
    Dim Sqlstr As String = ""
    Sub loadClients()


        Sqlstr = " SELECT [ID] ,ClientName,Empname as [Employee Name],[WorkType],[Rate],RateType,[Food],[Accommodation],[Transport],[StartDate],[EndDate],TotalHours  FROM [Siteschedule] inner join employees on employees.EmpID =Siteschedule.empid inner join clients on clients.ClientID=Siteschedule.clientid where StartDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate

        Dim TempBS As New BindingSource

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("ID").Width = 30


            TxtList.Columns("ClientName").Width = 30
            TxtList.Columns("ClientName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            TxtList.Columns("Employee Name").Width = 30
            TxtList.Columns("Employee Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Catch ex As Exception

        End Try

    End Sub

    Private Sub SiteMaster_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtStartDate.Value = Today.AddMonths(-3)
        TxtEndDate.Value = Today
        loadClients()
    End Sub

    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        Dim FRM As New frmNewSiteShedule
        FRM.ShowDialog()
        loadClients()
    End Sub

    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If TxtList.Rows.Count = 0 Then Exit Sub
        Dim FRM As New frmNewSiteShedule(TxtList.Item("ID", TxtList.CurrentRow.Index).Value)
        FRM.ShowDialog()
        loadClients()
    End Sub

    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        loadClients()
    End Sub

    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click
        If TxtList.Rows.Count = 0 Then Exit Sub
        If MsgBox("Do you want to delete the seleted entry? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ExecuteSQLQueryForDELETE("Delete from Siteschedule where id=" & TxtList.Item("ID", TxtList.CurrentRow.Index).Value)
            loadClients()
        End If
    End Sub

    Private Sub ImsButton4_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton4.Click
        If Sqlstr.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor

        Dim ds As New DataSet
        Dim cnn As SqlConnection

        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()

        Dim dscmd As New SqlDataAdapter(Sqlstr, cnn)

        dscmd.Fill(ds, "Siteschedule")
        cnn.Close()
        Dim objRpt As New SiteSheduleEMPCrReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EMPLOYEE SITE SCHEDULE " + Chr(13) + " Period " & TxtStartDate.Value.ToString("dd/MM/yyyy") & " - " & TxtEndDate.Value.ToString("dd/MM/yyyy")
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EMPLOYEE SITE SCHEDULE " + Chr(13) + " Period " & TxtStartDate.Value.ToString("dd/MM/yyyy") & " - " & TxtEndDate.Value.ToString("dd/MM/yyyy")
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