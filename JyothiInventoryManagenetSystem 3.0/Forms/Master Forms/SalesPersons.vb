Imports System.Data.SqlClient

Public Class SalesPersons
    Dim IslOaded As Boolean = False
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
#Region "Functions"
    Sub loadSalesPersons()
        Dim Sqlstr As String = ""
        ' Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY StockCategoryName) AS [S.NO],rtrim(StockCategoryName) AS [STOCK CATEGORY],rtrim(groupRoot) AS [UNDER GROUP] FROM categoriesgroups"
        Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY salespersonname) AS [S.NO],rtrim(salespersonname) AS [Sales Person Name],rtrim(Address) AS [ADDRESS],Tel AS [CONTACT NUMBER] FROM salespersons"
        '  Me.TxtList.Rows.Clear()

        Dim TempBS As New BindingSource

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtList.Columns(0).Width = 35
        Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtList.Columns(1).Width = 350
        Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtList.Columns(2).Width = 350
    End Sub
#End Region
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        Dim k As New CreateSalesPersons()
        k.ShowDialog()
        loadSalesPersons()
    End Sub

    Private Sub SalesPersons_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub StockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loadSalesPersons()
        IslOaded = True
    End Sub


    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, DeleteToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub TxtList_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.RowEnter
        On Error Resume Next
        If IslOaded = False Then Exit Sub
        Dim v_isactive As Integer

        v_isactive = SQLGetNumericFieldValue("SELECT ISACTIVE FROM salespersons WHERE salespersonname=N'" & TxtList.Item("Sales Person Name", e.RowIndex).Value & "'", "ISACTIVE")
        If v_isactive = 0 Then
            BtnActivate.Text = "Activate"
        Else
            BtnActivate.Text = "DeActivate"
        End If

    End Sub

    Private Sub btnActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActivate.Click, AcitvateToolStripMenuItem.Click
        If IslOaded = False Then Exit Sub
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If BtnActivate.Text = "Activate" Then
            If MsgBox("Do you want to Activate the selected Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE salespersons SET ISACTIVE=1 WHERE salespersonname=N'" & TxtList.Item("Sales Person Name", TxtList.CurrentRow.Index).Value & "'")
                BtnActivate.Text = "DeActivate"
                TxtList.Focus()
            End If
        Else
            If MsgBox("Do you want to De-Activate the selected Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE salespersons SET ISACTIVE=0 WHERE salespersonname=N'" & TxtList.Item("Sales Person Name", TxtList.CurrentRow.Index).Value & "'")
                BtnActivate.Text = "Activate"
                TxtList.Focus()
            End If
        End If
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If APPUserRights.IsDeleteble = False Then
            MsgBox("The Delete Restricted by the Admin, No possible to Delete......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If SQLIsFieldExists("SELECT TOP 1 1 from   StockInvoiceDetails  where salesperson=N'" & TxtList.Item("Sales Person Name", TxtList.CurrentRow.Index).Value & "'") = True Then
            MsgBox("The Sales Person already in used, you can't delete ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox("Do you want to delete ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ExecuteSQLQuery("delete from salespersons  where salespersonname=N'" & TxtList.Item("Sales Person Name", TxtList.CurrentRow.Index).Value & "'")
            loadSalesPersons()
        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If APPUserRights.IsEditable = False Then
            MsgBox("The Edit Restricted by the Admin, No possible to Edit......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If SQLGetNumericFieldValue("SELECT ISACTIVE FROM salespersons WHERE salespersonname=N'" & TxtList.Item("Sales Person Name", TxtList.CurrentRow.Index).Value & "'", "ISACTIVE") = 0 Then
            MsgBox("The Sales Person is deactivated, Edit is not possible....", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim k As New CreateSalesPersons(TxtList.Item("Sales Person Name", TxtList.CurrentRow.Index).Value)
        k.ShowDialog()
        loadSalesPersons()
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("select * from salespersons", cnn)
        dscmd.Fill(ds, "salespersons")
        cnn.Close()
        Dim objRpt As New SalesPersonsMasterReports
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "SALES PERSONS REPORTS"
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True

        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "SALES PERSONS REPORTS"

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

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click, PrintToolStripMenuItem.Click
        MainForm.Cursor = Cursors.WaitCursor
        salesmanreports.SuspendLayout()
        salesmanreports.MdiParent = MainForm
        salesmanreports.Dock = DockStyle.Fill
        salesmanreports.Show()
        salesmanreports.WindowState = FormWindowState.Maximized
        salesmanreports.BringToFront()
        salesmanreports.ResumeLayout()
        MainForm.Cursor = Cursors.Default
    End Sub
End Class