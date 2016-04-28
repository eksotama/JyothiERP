Public Class Countersfrm

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
    Sub loadCategories(Optional ByVal SearchSqlstr As String = "")
        Dim Sqlstr As String
        Sqlstr = "SELECT CounterID, CounterName, LocationName  FROM Counters"
        Sqlstr = Sqlstr & SearchSqlstr
        Dim TempBS As New BindingSource
        '   Me.TxtList.Rows.Clear()
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtList.Columns(0).Width = 120
        Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtList.Columns(1).Width = 350
        Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtList.Columns(2).Width = 350
    End Sub
#End Region
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        Dim CATFRM As New CreateNewCounterfrm
        CATFRM.ShowDialog()
        loadCategories()
    End Sub

    Private Sub Departments_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub StockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadCategories()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        Dim CATGRM As New CreateNewCounterfrm(TxtList.Item("CounterID", TxtList.CurrentRow.Index).Value)
        CATGRM.ShowDialog()
        loadCategories()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem.Click
        If TxtList.SelectedRows.Count = 0 Then Exit Sub

    End Sub

    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        loadCategories()
    End Sub

    Private Sub TxtSearchBy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearchBy.TextChanged
        If TxtSearchBy.Text.Length = 0 Then
            loadCategories()
        Else
            loadCategories(" where countername LIKE N'%" & TxtSearchBy.Text & "%'")
        End If
    End Sub



    'Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, PrintToolStripMenuItem.Click
    '    If TxtList.RowCount = 0 Then Exit Sub

    '    Me.Cursor = Cursors.WaitCursor
    '    Dim ds As New DataSet
    '    Dim cnn As SqlConnection
    '    cnn = New SqlConnection(ConnectionStrinG)
    '    cnn.Open()
    '    Dim dscmd As New SqlDataAdapter("SELECT * FROM DepartmentGroups ", cnn)
    '    dscmd.Fill(ds, "DepartmentGroups")
    '    cnn.Close()
    '    Dim objRpt As New DepartmentCrReport
    '    SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
    '    If PrintOptionsforCR.IsPrintHeader = False Then
    '        CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
    '        CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
    '        CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF EMPLOYEE DEPARTMENTS"
    '    Else
    '        CType(objRpt.Section2.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF EMPLOYEE DEPARTMENTS"

    '    End If
    '    objRpt.SetDataSource(ds)
    '    Dim FRM As New ReportCommonForm(objRpt)
    '    FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    '    Me.Cursor = Cursors.Default
    '    FRM.ShowDialog()
    '    FRM.Dispose()
    '    objRpt.Dispose()
    '    ds.Dispose()
    'End Sub
End Class