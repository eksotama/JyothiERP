Public Class empbarcodeSettings

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub empbarcodeSettings_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub empbarcodeSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("SELECT  DepName FROM DepartmentGroups", TxtDepartmentName, "DepName", "*All")
        loaddata()
    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub loaddata()
        Dim SqlStr As String = ""
        If TxtDepartmentName.Text.Length = 0 Or TxtDepartmentName.Text = "*All" Then
            SqlStr = "Select empname as [Employee Name],DepName as [Department], barcode as [Barcode] from employees where IsDelete=0"

        Else
            SqlStr = "Select empname as [Employee Name],DepName as [Department], barcode as [Barcode] from employees where IsDelete=0 and depname=N'" & TxtDepartmentName.Text & "'"
        End If
        Dim TempBS As New BindingSource
        '   Me.TxtList.Rows.Clear()
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("Employee Name").Width = 200
            TxtList.Columns("Barcode").Width = 120
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click, EditToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.CurrentRow.Index < 0 Then Exit Sub
        Dim k As New EditEmpBarcode
        k.TxtEmployeeName.Text = TxtList.Item("Employee Name", TxtList.CurrentRow.Index).Value
        k.ShowDialog()
        k.Dispose()
        loaddata()
    End Sub

    Private Sub TxtDepartmentName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDepartmentName.SelectedIndexChanged
        loaddata()
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click, PrintToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New EmpBarcodeDataset
        ds.Clear()
        For i As Integer = 0 To TxtList.RowCount - 1
            Dim row As DataRow
            row = ds.Tables(0).NewRow
            For k As Integer = 0 To TxtList.ColumnCount - 1
                row(TxtList.Columns(k).Name) = TxtList.Item(k, i).Value
            Next
            ds.Tables(0).Rows.Add(row)
        Next
        Dim objRpt As New EmpBarcodereport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "TRIAL BALANCE SHEET"
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "TRIAL BALANCE SHEET"
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