Imports System.Data.SqlClient

Public Class EmployeeMonthlyPresentAttendens
    Dim Sqlstr As String = ""
    Private Sub TxtDepartmentName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDepartmentName.SelectedIndexChanged, TxtEmployeeName.SelectedIndexChanged
        lOADdATA()
    End Sub
    Sub lOADdATA()
        Dim wherestr As String = ""
        MainForm.Cursor = Cursors.WaitCursor
        Sqlstr = "SELECT  UPPER(LEFT(DATENAME(MONTH, TransDate), 3)) + '-' + CONVERT(varchar(30), YEAR(TransDate)) AS Period,(select empid from employees where employees.empname=EmpAttend.empname) as [EMP ID], EmpName as [Employee Name], " _
            & " (select Designation from employees where employees.empname=EmpAttend.empname) as [Designation],(select depname from employees where employees.empname=EmpAttend.empname) as [Department],COUNT(Status) AS [Total Presents]" _
            & " FROM      EmpAttend where (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "

        If TxtEmployeeName.Text.Length = 0 Or TxtEmployeeName.Text = "*All" Then

        Else
            Sqlstr = Sqlstr & " and empname=N'" & TxtEmployeeName.Text & "' "
        End If

        If TxtDepartmentName.Text.Length = 0 Or TxtDepartmentName.Text = "*All" Then

        Else
            Sqlstr = Sqlstr & " and empname in (select empname from employees where  depname=N'" & TxtDepartmentName.Text & "') "
        End If

        Sqlstr = Sqlstr & "  GROUP BY EmpName, YEAR(TransDate), MONTH(TransDate), DATENAME(MONTH, TransDate) "


        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("Period").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Period").Width = 100

            TxtList.Columns("Emp ID").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Emp ID").Width = 120

            TxtList.Columns("Employee Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("Employee Name").Width = 125

            TxtList.Columns("Designation").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Designation").Width = 180

            TxtList.Columns("Department").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Department").Width = 180

            TxtList.Columns("Total Presents").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Total Presents").Width = 100

        Catch ex As Exception

        End Try

        MainForm.Cursor = Cursors.Default
    End Sub

    Private Sub EmployeeMonthlyPresentAttendens_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub EmployeeDailyAbsentForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("SELECT  DepName FROM DepartmentGroups", TxtDepartmentName, "DepName", "*All")
        LoadDataIntoComboBox("SELECT  empname FROM employees", TxtEmployeeName, "empname", "*All")
        TxtStartDate.Value = Today

    End Sub

    Private Sub TxtpresentDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStartDate.ValueChanged
        lOADdATA()
    End Sub

    Private Sub TxtList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Me.Close()
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        Me.Cursor = Cursors.WaitCursor
        If Sqlstr.Length = 0 Then Exit Sub
        Dim ds As New DataSet

        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(Sqlstr, cnn)
        dscmd.Fill(ds, "DataTable1")
        cnn.Close()




        Dim objRpt As New EmpMonthlyAttendenceCRReport

        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ImsHeadingLabel1.Text & Chr(13) & " For " & TxtStartDate.Value.Date.ToString("dd/MMM/yyyy") & " TO " & TxtEndDate.Value.Date.ToString("dd/MMM/yyyy")

        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ImsHeadingLabel1.Text & Chr(13) & " For " & TxtStartDate.Value.Date.ToString("dd/MMM/yyyy") & " TO " & TxtEndDate.Value.Date.ToString("dd/MMM/yyyy")

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

    Private Sub BtnPrintempwise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintempwise.Click
        Me.Cursor = Cursors.WaitCursor
        If Sqlstr.Length = 0 Then Exit Sub
        Dim ds As New DataSet

        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(Sqlstr, cnn)
        dscmd.Fill(ds, "DataTable1")
        cnn.Close()




        Dim objRpt As New EmpMonthlyAttendenceAbsentsCRReport___Empwise

        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ImsHeadingLabel1.Text & Chr(13) & " For " & TxtStartDate.Value.Date.ToString("dd/MMM/yyyy") & " TO " & TxtEndDate.Value.Date.ToString("dd/MMM/yyyy")

        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ImsHeadingLabel1.Text & Chr(13) & " For " & TxtStartDate.Value.Date.ToString("dd/MMM/yyyy") & " TO " & TxtEndDate.Value.Date.ToString("dd/MMM/yyyy")

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