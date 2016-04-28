Imports System.Data.SqlClient

Public Class EmployeeDailyPresentform
    Dim Sqlstr As String = ""
    Private Sub TxtDepartmentName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDepartmentName.SelectedIndexChanged
        lOADdATA()
    End Sub
    Sub lOADdATA()
        MainForm.Cursor = Cursors.WaitCursor
        Dim DATESTR As String = ""
        DATESTR = TxtpresentDate.Value.Year & "-" & TxtpresentDate.Value.Month & "-" & TxtpresentDate.Value.Day

        Sqlstr = "SELECT  EmpID as [Emp ID],   EmpName as [Employee Name],  Designation,DepName as [Department], Status FROM  " _
            & " (SELECT    EmpName, EmpID, DepName, Designation, (CASE WHEN     (SELECT     Status    FROM      EmpAttend AS T " _
            & " WHERE      (T .TransDate = '" & DATESTR & "') AND (T .EmpName = Employees.EMPNAME)) IS NOT NULL THEN 'P' ELSE 'A' END) AS Status   " _
            & " FROM      dbo.Employees) AS derivedtbl_1 WHERE     (Status = 'P')"

        If TxtDepartmentName.Text.Length = 0 Or TxtDepartmentName.Text = "*All" Then

        Else
            Sqlstr = Sqlstr & " and depname=N'" & TxtDepartmentName.Text & "' "
        End If
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("Emp ID").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Emp ID").Width = 120

            TxtList.Columns("Employee Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("Employee Name").Width = 125

            TxtList.Columns("Designation").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Designation").Width = 180
            TxtList.Columns("Department").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Department").Width = 180
            TxtList.Columns("Status").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Status").Width = 100

        Catch ex As Exception

        End Try

        MainForm.Cursor = Cursors.Default
    End Sub

    Private Sub EmployeeDailyPresentform_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub EmployeeDailyAbsentForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("SELECT  DepName FROM DepartmentGroups", TxtDepartmentName, "DepName", "*All")
        TxtpresentDate.Value = Today

    End Sub

    Private Sub TxtpresentDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtpresentDate.ValueChanged
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




        Dim objRpt As New EmpAttendenceDailyCRReport

        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ImsHeadingLabel1.Text & Chr(13) & " For " & TxtpresentDate.Value.Date.ToString("dd/MMM/yyyy")

        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ImsHeadingLabel1.Text & Chr(13) & " For " & TxtpresentDate.Value.Date.ToString("dd/MMM/yyyy")

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