Imports System.Data.SqlClient

Public Class Dutyallotment
    Dim SqlStr As String = ""
    Dim TempStr As String = ""
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub loadData()

        If MyAppSettings.IsMrngEvngShiftDuty = True Then
            SqlStr = "SELECT [sno] as [Ref No],[EmpName] as [Employee Name],[DutyType] as [Shift Name],[TimeIn] as [Mrng TimeIn],[TimeOut] as [Mrng TimeOut],[etimein] as [Evng TimeIn], [etimeout] as [Evng TimeOut],[datefrom] as [Date From],[dateto] as [Date To]  FROM [Duties] "
        Else
            SqlStr = "SELECT [sno] as [Ref No],[EmpName] as [Employee Name],[DutyType] as [Shift Name],[TimeIn],[TimeOut],[datefrom] as [Date From],[dateto] as [Date To]  FROM [Duties] "
        End If

        If TxtIsPeriod.Checked = True Then
            TempStr = " where (datefromvalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
        Else
            TempStr = ""
        End If
        If TxtEmployeeName.Text.Length = 0 Or TxtEmployeeName.Text = "*All" Then
        Else
            If TempStr.Length = 0 Then
                TempStr = TempStr & " where empname=N'" & TxtEmployeeName.Text & "'"
            Else
                TempStr = TempStr & " and empname=N'" & TxtEmployeeName.Text & "'"
            End If
        End If

        If TxtShift.Text.Length = 0 Or TxtShift.Text = "*All" Then

        Else
            If TempStr.Length = 0 Then
                TempStr = TempStr & " where DutyType=N'" & TxtShift.Text & "'"
            Else
                TempStr = TempStr & " and DutyType=N'" & TxtShift.Text & "'"
            End If
        End If
        SqlStr = SqlStr & TempStr
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(0).Width = 35

            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns(1).Width = 100

            Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(2).Width = 120

            Me.TxtList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(3).Width = 80
            Me.TxtList.Columns(3).DefaultCellStyle.Format = "t"

            Me.TxtList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(4).Width = 80
            Me.TxtList.Columns(4).DefaultCellStyle.Format = "t"
            If MyAppSettings.IsMrngEvngShiftDuty = True Then
               

                Me.TxtList.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtList.Columns(5).Width = 80
                Me.TxtList.Columns(5).DefaultCellStyle.Format = "t"

                Me.TxtList.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtList.Columns(6).Width = 80
                Me.TxtList.Columns(6).DefaultCellStyle.Format = "t"

                Me.TxtList.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtList.Columns(7).Width = 100
                Me.TxtList.Columns(7).DefaultCellStyle.Format = "d"

                Me.TxtList.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtList.Columns(8).Width = 100
                Me.TxtList.Columns(8).DefaultCellStyle.Format = "d"
            Else
                Me.TxtList.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtList.Columns(5).Width = 100
                Me.TxtList.Columns(5).DefaultCellStyle.Format = "d"
                Me.TxtList.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtList.Columns(6).Width = 100
                Me.TxtList.Columns(6).DefaultCellStyle.Format = "d"
            End If
          

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem1.Click
        Dim kfrm As New NewAllotDuty
        kfrm.ShowDialog()
        kfrm.Dispose()
        loadData()
    End Sub

    Private Sub Dutyallotment_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub Dutyallotment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = Today
        LoadDataIntoComboBox("select EmpName from Employees where isactive=1 and isdelete=0 ", TxtEmployeeName, "EmpName", "*All")
        LoadDataIntoComboBox("select shiftname from dutysettings", TxtShift, "shiftname")
        If MyAppSettings.IsMrngEvngShiftDuty = True Then
            TxtShift.Items.Add("Custom")
        End If
        loadData()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem1.Click
        If TxtList.RowCount = 0 Then Exit Sub
        'Ref No
        'Employee Name
        If SQLGetNumericFieldValue("select max(sno) as s from duties where empname=N'" & TxtList.Item("Employee Name", TxtList.CurrentRow.Index).Value & "'", "s") = TxtList.Item("Ref No", TxtList.CurrentRow.Index).Value Then
            If MsgBox("Do you want to Delete the selected Entry ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("delete from duties where empname=N'" & TxtList.Item("Employee Name", TxtList.CurrentRow.Index).Value & "' and sno=" & TxtList.Item("Ref No", TxtList.CurrentRow.Index).Value)
                loadData()
            End If
        Else
            MsgBox("The Selected Entry is not Delete, Last Entry can be Delete", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem1.Click
        If TxtList.RowCount = 0 Then Exit Sub
        'Ref No
        'Employee Name
        'SqlStr = "SELECT [sno] as [Ref No],[EmpName] as [Employee Name],[DutyType] as [Shift Name],[TimeIn],[TimeOut],[datefrom] as [Date From],[dateto] as [Date To]  FROM [Duties]"
        If SQLGetNumericFieldValue("select max(sno) as s from duties where empname=N'" & TxtList.Item("Employee Name", TxtList.CurrentRow.Index).Value & "'", "s") = TxtList.Item("Ref No", TxtList.CurrentRow.Index).Value Then
            If MsgBox("Do you want to Edit the selected Entry ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim kfrm As New NewAllotDuty(TxtList.Item("Ref No", TxtList.CurrentRow.Index).Value, TxtList.Item("Employee Name", TxtList.CurrentRow.Index).Value)
                kfrm.TxtEmployeeName.Text = TxtList.Item("Employee Name", TxtList.CurrentRow.Index).Value
                kfrm.TxtShiftName.Text = TxtList.Item("Shift Name", TxtList.CurrentRow.Index).Value
                kfrm.TxtEmployeeName.Enabled = False
                kfrm.ShowDialog()
                kfrm.Dispose()
                loadData()
            End If
        Else
            MsgBox("The Selected Entry is not editable, Last Entry can be editable ", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        If MyAppSettings.IsMrngEvngShiftDuty = True Then
            If TxtList.RowCount = 0 Then Exit Sub
            If SqlStr.Length = 0 Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            Dim ds As New DataSet
            Dim cnn As SqlConnection
            cnn = New SqlConnection(ConnectionStrinG)
            cnn.Open()
            Dim dscmd As New SqlDataAdapter("select * from duties " & TempStr, cnn)
            dscmd.Fill(ds, "Duties")
            cnn.Close()
            Dim objRpt As New DutiesMrngEvngCRReport
            SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
            If PrintOptionsforCR.IsPrintHeader = False Then
                CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
                CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
                CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EMPLOYEE DETAILS"
            Else
                CType(objRpt.Section2.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EMPLOYEE DETAILS"

            End If
            objRpt.SetDataSource(ds)
            Dim FRM As New ReportCommonForm(objRpt)
            FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            Me.Cursor = Cursors.Default
            FRM.ShowDialog()
            FRM.Dispose()
            objRpt.Dispose()
            ds.Dispose()
        Else
            If TxtList.RowCount = 0 Then Exit Sub
            If SqlStr.Length = 0 Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            Dim ds As New DataSet
            Dim cnn As SqlConnection
            cnn = New SqlConnection(ConnectionStrinG)
            cnn.Open()
            Dim dscmd As New SqlDataAdapter(SqlStr, cnn)
            dscmd.Fill(ds, "Duties")
            cnn.Close()
            Dim objRpt As New DutiesCRReport
            SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
            If PrintOptionsforCR.IsPrintHeader = False Then
                CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
                CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
                CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EMPLOYEE DETAILS"
            Else
                CType(objRpt.Section2.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EMPLOYEE DETAILS"

            End If
            objRpt.SetDataSource(ds)
            Dim FRM As New ReportCommonForm(objRpt)
            FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            Me.Cursor = Cursors.Default
            FRM.ShowDialog()
            FRM.Dispose()
            objRpt.Dispose()
            ds.Dispose()
        End If
    End Sub

    Private Sub TxtIsPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIsPeriod.CheckedChanged
        loadData()
    End Sub

    Private Sub UserButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton2.Click
        loadData()
    End Sub

    Private Sub TxtEmployeeName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEmployeeName.SelectedIndexChanged
        loadData()
    End Sub

    Private Sub TxtShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShift.SelectedIndexChanged
        loadData()
    End Sub

    Private Sub BtnForGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnForGroup.Click
        Dim kfrm As New MultiAllotDuties
        kfrm.ShowDialog()
        kfrm.Dispose()
        loadData()
    End Sub
End Class