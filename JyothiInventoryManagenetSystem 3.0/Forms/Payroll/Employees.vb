Imports System.Data.SqlClient

Public Class Employees

   Dim Sqlstr As String = ""
    Dim IslOaded As Boolean = False
    Dim RepSqlStr As String = ""
#Region "Functions"
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadEmployeeList(Optional ByVal sqlText As String = "")
        Dim TempBS As New BindingSource
        My.Application.DoEvents()
        Me.Cursor = Cursors.WaitCursor
        RepSqlStr = ""
        Sqlstr = "SELECT EmpID as [ID],Empname as [Employee Name],Gender as [Gender],dateofbirth as [Date of Birth],Designation as [Designation],address as [Address],contactno as [Contact],emailid as [Email ID] from employees  "
        If sqlText.Length > 0 Then
            Sqlstr = Sqlstr & " where IsDelete=0  and " & sqlText
            RepSqlStr = " where  IsDelete=0 and " & sqlText
        Else
            RepSqlStr = " where IsDelete=0 "
        End If

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(0).Width = 55
            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(1).Width = 150
            Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(2).Width = 250

        Catch ex As Exception

        End Try
        Me.Cursor = Cursors.Default
    End Sub

#End Region
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        Dim k As New CreateEmployee
        k.ShowDialog()
        k.Dispose()
        LoadEmployeeList()

    End Sub

    Private Sub Employees_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub StockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select DepName from DepartmentGroups ", TxtDepartment, "DepName")
        TxtDepartment.Items.Add("*All")
        LoadEmployeeList()
        IslOaded = True
    End Sub


    Private Sub TxtList_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.RowEnter
        On Error Resume Next
        If IslOaded = False Then Exit Sub
        Dim v_isactive As Integer

        v_isactive = SQLGetNumericFieldValue("SELECT ISACTIVE FROM employees WHERE empname=N'" & TxtList.Item("Employee Name", e.RowIndex).Value & "'", "ISACTIVE")
        If v_isactive = 0 Then
            BtnActivate.Text = "Activate"
        Else
            BtnActivate.Text = "DeActivate"
        End If

    End Sub

    Private Sub btnActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActivate.Click
        If IslOaded = False Then Exit Sub
        If BtnActivate.Text = "Activate" Then
            If MsgBox("Do you want to Activate the selected Employee Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE employees SET ISACTIVE=1 WHERE empname=N'" & TxtList.Item("Employee Name", TxtList.CurrentRow.Index).Value & "'")
                BtnActivate.Text = "DeActivate"
                TxtList.Focus()
            End If
        Else
            If MsgBox("Do you want to De-Activate the selected Employee Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE employees SET ISACTIVE=0 WHERE empname=N'" & TxtList.Item("Employee Name", TxtList.CurrentRow.Index).Value & "'")
                BtnActivate.Text = "Activate"
                TxtList.Focus()
            End If
        End If
    End Sub
    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If TxtList.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        Dim v_isactive As Integer
        v_isactive = SQLGetNumericFieldValue("SELECT ISACTIVE FROM employees WHERE EmpName=N'" & TxtList.Item("Employee Name", TxtList.CurrentRow.Index).Value & "'", "ISACTIVE")
        If v_isactive = 0 Then
            MsgBox("This Employee Account is In-Active...., Edit is not possible....")
            Exit Sub
        End If
        Dim k As New CreateEmployee(TxtList.Item("Employee Name", TxtList.CurrentRow.Index).Value)
        k.ShowDialog()
        k.Dispose()
        LoadEmployeeList()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem.Click
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Employee Name to delete...", MsgBoxStyle.Information)
            Exit Sub
        End If
        If SQLIsFieldExists("SELECT TOP 1 1 from   payrollvoucherRowDetails where empname=N'" & TxtList.Item("Employee Name", TxtList.CurrentRow.Index).Value & "'") = True Then
            MsgBox("The Employee is already used in accounts, It is not possible to delete...")
            Exit Sub
        Else
            If MsgBox("Do You want to Mark as Delete The Employee Account ?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("update  employees set isdelete=1 where empname=N'" & TxtList.Item("Employee Name", TxtList.CurrentRow.Index).Value & "'")
                LoadEmployeeList()
            End If

        End If

    End Sub
    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        LoadEmployeeList()
    End Sub
    Private Sub TxtAccountGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDepartment.SelectedIndexChanged
        If TxtDepartment.Text = "*All" Or TxtDepartment.Text.Length = 0 Then
            LoadEmployeeList()
        Else
            LoadEmployeeList("  DepName=N'" & TxtDepartment.Text & "'")
        End If
    End Sub

    Private Sub TxtLedgerName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.TextChanged
        If TxtLedgerName.Text.Length = 0 Then
            LoadEmployeeList()
        Else
            LoadEmployeeList("   empname LIKE N'%" & TxtLedgerName.Text & "%'")
        End If
    End Sub

    Private Sub TxtLedgerCity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerCity.TextChanged
        If TxtLedgerCity.Text.Length = 0 Then
            LoadEmployeeList()
        Else
            LoadEmployeeList("   address LIKE N'%" & TxtLedgerCity.Text & "%'")
        End If
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("SELECT * FROM EMPLOYEES " & RepSqlStr, cnn)
        dscmd.Fill(ds, "EMPLOYEES")
        cnn.Close()
        Dim objRpt As New EmployeeBasicDetailsCRReport
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
    End Sub

    Private Sub BtnGtySettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGtySettings.Click, SettingsToolStripMenuItem.Click
        Dim k As New EmpGratuityCalculationMethods
        k.ShowDialog()
        k.Dispose()
    End Sub

    Private Sub BtnSalaryHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalaryHistory.Click, HistoryToolStripMenuItem.Click
        Dim k As New EmpSalaryHistory(TxtList.Item("Employee Name", TxtList.CurrentRow.Index).Value)
        k.ShowDialog()
        k.Dispose()
    End Sub

    Private Sub BtnGratuity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGratuity.Click, GratutyToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        EmpGratuityReport.SuspendLayout()
        EmpGratuityReport.MdiParent = MainForm
        EmpGratuityReport.Dock = DockStyle.Fill
        EmpGratuityReport.Show()
        EmpGratuityReport.WindowState = FormWindowState.Maximized
        EmpGratuityReport.BringToFront()
        EmpGratuityReport.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnLeaves_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLeaves.Click, LeavesToolStripMenuItem.Click
        Dim k As New GrantLeave
        k.ShowDialog()
        k.Dispose()
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        If TxtList.RowCount = 0 Then Exit Sub
        Dim k As New ViewFullEmployeeDetails()
        k.ShowDialog()
        k.Dispose()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim k As New EmployeeImportAndExport
        k.ShowDialog()
        k.Dispose()
        LoadEmployeeList()
    End Sub
End Class