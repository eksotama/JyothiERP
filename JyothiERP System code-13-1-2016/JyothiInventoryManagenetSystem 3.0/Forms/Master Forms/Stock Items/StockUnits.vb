Imports System.Data.SqlClient

Public Class StockUnits

#Region "Functions"
    Dim Sqlstr As String
    Sub LoadStockUnits()
        Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY UNITNAME) AS [S NO],rtrim(UNITNAME) AS [UNIT NAME],(case UNITTYPE when 0 then 'Simple' ELSE  'Compound' END) AS [UNIT TYPE], rtrim(FORMALNAME) AS [FORMAL NAME] FROM STOCKUNITS"
        Dim TempBS As New BindingSource
        Try
            Me.TxtList.Rows.Clear()
        Catch ex As Exception

        End Try
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtList.Columns(0).Width = 40
        Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtList.Columns(1).Width = 350
        Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtList.Columns(2).Width = 150
    End Sub
#End Region

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        Dim k As New CreateUnits
        k.ShowDialog()
        LoadStockUnits()
    End Sub

    Private Sub TxtList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellClick
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.Item("UNIT TYPE", TxtList.CurrentRow.Index).Value = "Simple" Then
            btnRename.Enabled = True
            btnchangedecimal.Enabled = True
        Else
            btnRename.Enabled = False
            btnchangedecimal.Enabled = False
        End If
    End Sub

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub

    Private Sub StockUnits_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub StockUnits_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadStockUnits()
    End Sub

    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        LoadStockUnits()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem.Click
        If APPUserRights.IsDeleteble = False Then
            MsgBox("The Delete Restricted by the Admin, Not possible to Delete......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If TxtList.RowCount = 0 Then Exit Sub

        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Unit Name to Edit...", MsgBoxStyle.Information)
            Exit Sub
        End If
        If SQLIsFieldExists("select BaseUnit from stockdbf where BaseUnit=N'" & TxtList.Item("UNIT NAME", TxtList.CurrentRow.Index).Value & "'") = True Then
            MsgBox("The Selected Stock Unit Name is already used for Stock Item  , Can't be deleted....", MsgBoxStyle.Information)
            Exit Sub
        Else
            If MsgBox("Do you want to Delete the Selected Unit Name ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("DELETE FROM STOCKUNITS WHERE UNITNAME=N'" & TxtList.Item("UNIT NAME", TxtList.CurrentRow.Index).Value & "'")
                LoadStockUnits()
            End If
        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If APPUserRights.IsEditable = False Then
            MsgBox("The Edit Restricted by the Admin, Not possible to Edit......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Unit Name to Edit...", MsgBoxStyle.Information)
            Exit Sub
        End If
        If SQLIsFieldExists("select BaseUnit from stockdbf where BaseUnit=N'" & TxtList.Item("UNIT NAME", TxtList.CurrentRow.Index).Value & "'") = True Then
            MsgBox("The Selected Stock Unit Name is already used for Stock Item  , Can't be Editable....", MsgBoxStyle.Information)
            Exit Sub
        Else
            Dim k As New CreateUnits(TxtList.Item("UNIT NAME", TxtList.CurrentRow.Index).Value)
            k.ShowDialog()
            LoadStockUnits()
        End If
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("SELECT RTRIM(UnitName) AS UNITNAME, (CASE UNITTYPE WHEN 0 THEN 'Simple' ELSE 'Compound' END) AS UNITTYPE, RTRIM(formalname) AS FORMALNAME FROM Stockunits", cnn)
        dscmd.Fill(ds, "Stockunits")
        cnn.Close()
        Dim objRpt As New StockUnitMasterReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "STOCK UNITS REPORTS"
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True

        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "STOCK UNITS REPORTS"

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

    Private Sub BtnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImport.Click
        Dim efrm As New StockUnitImportExport
        Me.Cursor = Cursors.WaitCursor
        efrm.SuspendLayout()
        efrm.MdiParent = MainForm
        efrm.Dock = DockStyle.Fill
        efrm.Show()
        efrm.WindowState = FormWindowState.Maximized
        efrm.BringToFront()
        efrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TxtList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub

    Private Sub btnchangedecimal_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnchangedecimal.LinkClicked
        Dim frm As New changeunitdecimals(TxtList.Item("UNIT NAME", TxtList.CurrentRow.Index).Value)
        frm.ShowDialog()
        LoadStockUnits()
    End Sub
End Class