Imports System.Data.SqlClient

Public Class Monthlyattreportdaywise
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Dim Sqlstr As String
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub loaddata()


        If TxtDepartmentName.Text.Length = 0 Or TxtDepartmentName.Text = "*All" Then
            Sqlstr = "SELECT empname as [Employee Name],TransDate as [Date],StratTime as [StartTime],EndTime,EStratTime as [EStartTime],EEndTime,OT as [Over Time],LT as [Late Min],(totalworkingmin-LT+OT) AS [Working Min],TickCount, Narration from empattend "
            If IsDateWiseOn.Checked = True Then
                Sqlstr = Sqlstr & " where transdatevalue>=" & TxtStartDate.Value.Date.ToOADate & " and transdatevalue<=" & TxtEndDate.Value.Date.ToOADate
            End If
        Else
            Sqlstr = "SELECT empname as [Employee Name],TransDate as [Date],StratTime as [StartTime],EndTime,EStratTime as [EStartTime],EEndTime,OT  as [Over Time],LT as [Late Min],(totalworkingmin-LT+OT) AS [Working Min],TickCount, Narration from empattend where empname in (select empname from employees where depname=N'" & TxtDepartmentName.Text & "') "
            If IsDateWiseOn.Checked = True Then
                Sqlstr = Sqlstr & " and (transdatevalue>=" & TxtStartDate.Value.Date.ToOADate & " and transdatevalue<=" & TxtEndDate.Value.Date.ToOADate & " )"
            End If

        End If
        Sqlstr = Sqlstr & "  order by empname "
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("StratTime").DefaultCellStyle.Format = "HH:mm:tt"
            TxtList.Columns("EndTime").DefaultCellStyle.Format = "HH:mm:tt"
            TxtList.Columns("EStratTime").DefaultCellStyle.Format = "HH:mm:tt"
            TxtList.Columns("EEndTime").DefaultCellStyle.Format = "HH:mm:tt"
        Catch ex As Exception

        End Try

    End Sub
    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click
        loaddata()
    End Sub

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub Monthlyattreportdaywise_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ERPInitializeObjects(Me)
        TxtStartDate.Value = Now.AddMonths(-1)
        TxtEndDate.Value = Now
        LoadDataIntoComboBox("SELECT  DepName FROM DepartmentGroups", TxtDepartmentName, "DepName", "*All")
        loaddata()
    End Sub

    Private Sub BtnPrint2_Click(sender As System.Object, e As System.EventArgs) Handles BtnPrint2.Click
        If Sqlstr.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(Sqlstr, cnn)
        dscmd.Fill(ds, "DATATABLE1")
        cnn.Close()
        Dim objRpt As New EmpAttendenceMonthlydaywiseCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ImSlabel2.Text & IIf(TxtDepartmentName.Text = "" Or TxtDepartmentName.Text = "*All", "", " FOR DEPARTMENT " & TxtDepartmentName.Text) & IIf(IsDateWiseOn.Checked = True, Chr(13) & "DATE BETWEEN " & TxtStartDate.Value.Date.ToString("dd/mmm/yyyy") & " AND " & TxtEndDate.Value.Date.ToString("dd/mmm/yyyy"), "")
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ImSlabel2.Text & IIf(TxtDepartmentName.Text = "" Or TxtDepartmentName.Text = "*All", "", " FOR DEPARTMENT " & TxtDepartmentName.Text) & IIf(IsDateWiseOn.Checked = True, Chr(13) & "DATE BETWEEN " & TxtStartDate.Value.Date.ToString("dd/mmm/yyyy") & " AND " & TxtEndDate.Value.Date.ToString("dd/mmm/yyyy"), "")

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