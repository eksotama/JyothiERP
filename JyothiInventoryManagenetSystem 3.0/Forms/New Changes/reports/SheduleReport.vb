Imports System.Data.SqlClient

Public Class SheduleReport
    Dim SqlStr As String = ""
    Dim HeadText As String = ""
    Sub LoadDef()
        LoadDataIntoComboBox("select empname from employees", TxtEmployee, "empname", "*All")
        LoadDataIntoComboBox("select sitename from Sites", TxtSite, "sitename", "*All")
        LoadDataIntoComboBox("select ClientName from Clients", TxtClient, "ClientName", "*All")

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
    End Sub
    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click
        Loaddata()
    End Sub
    Sub Loaddata()
        Dim substring As String = ""
        HeadText = " MANPOWER FOR " & TxtStartDate.Value.Date.ToString("dd/MM/yyyy") & " to " & TxtEndDate.Value.Date.ToString("dd/MM/yyyy") & Chr(13)
        If TxtEmployee.Text.Length = 0 Or TxtEmployee.Text = "*All" Then
        Else
            substring = substring & " and Siteschedule.empid=(select empid from employees where empname=N'" & TxtEmployee.Text & "')"

        End If
        If TxtClient.Text.Length = 0 Or TxtClient.Text = "*All" Then
        Else
            substring = substring & " and Siteschedule.clientid=(select clientID from clients where ClientName=N'" & TxtClient.Text & "')"
        End If
        If TxtSite.Text.Length = 0 Or TxtSite.Text = "*All" Then
        Else
            substring = substring & " and Siteschedule.siteid=(select siteid from Sites where sitename=N'" & TxtSite.Text & "')"
        End If
        HeadText = HeadText & " For Employee: " & TxtEmployee.Text & ", For Client: " & TxtClient.Text & ", For Site: " & TxtSite.Text
        SqlStr = "select  ROW_NUMBER() OVER (ORDER BY id) AS [Sno],Employees.EmpID,Employees.contactno,Empname as [Employee Name],WorkType,ClientName,SiteName,Siteschedule.TotalHours AS [Total Working Hours] from Siteschedule inner join clients on clients.clientid=Siteschedule.clientid inner join sites on sites.SiteID=Siteschedule.SiteID  inner join Employees on Employees.EmpID=Siteschedule.empid  where (StartDateValue between " & TxtStartDate.Value.Date.ToOADate & "  and  " & TxtEndDate.Value.Date.ToOADate & ") " & substring

        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
    End Sub

    Private Sub SheduleReport_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadDef()
        Loaddata()
    End Sub

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnPrint_Click(sender As System.Object, e As System.EventArgs) Handles BtnPrint.Click
        If SqlStr.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection

        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()

        Dim dscmd As New SqlDataAdapter(SqlStr, cnn)
        dscmd.Fill(ds, "DataTable1")
        cnn.Close()
        Dim objRpt As New ScheduleManPowerCR
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = HeadText
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = HeadText
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