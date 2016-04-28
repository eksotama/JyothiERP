Imports System.Data.SqlClient

Public Class CurrentStockItemReport
    Dim IslOaded As Boolean = False
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Dim Sqlstr As String = ""

    Dim varLoadsubstr As String = ""
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get

    End Property

    Private Sub TxtList_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles TxtList.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right And e.ColumnIndex > -1 And e.RowIndex > -1 Then
            Dim cell As DataGridViewCell = TxtList.Rows(e.RowIndex).Cells(e.ColumnIndex)
            TxtList.CurrentCell = cell
            Me.TxtListGridMenu.Show(Cursor.Position)
        End If
    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub New(Optional ByVal SqlString As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        varLoadsubstr = SqlString
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#Region "Functions"
    Sub loadstockitems(Optional ByVal WhereSqlStr As String = "")

        MainForm.Cursor = Cursors.WaitCursor
        '  Dim Sqlstr As String
        If TxtShowImages.Checked = True Then
            If MyAppSettings.IsCustomBarcode = True Then
                Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [SNo],(SELECT TOP 1 IMAGEDATA FROM IMAGES WHERE BCODE=CUSTBARCODE) AS IMAGE ,[location] as [Location],  [StockCode] as [Stock Code], stockname as [Stock Name],[StockSize] as [Stock Size],[stockgroup] as [Stock Group],[custBarcode] as [BAR CODE],[Barcode] as [BARCODE],[BaseUnit] as [Unit],[QtyText] as [Qty],[StockRate] as [Rate] FROM [StockDbf]"
            Else
                Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [SNo],(SELECT TOP 1 IMAGEDATA FROM IMAGES WHERE BCODE=CUSTBARCODE) AS IMAGE,[location] as [Location],  [StockCode] as [Stock Code], stockname as [Stock Name],[StockSize] as [Stock Size],[stockgroup] as [Stock Group],[custBarcode] as [BAR CODE],[Barcode] as [BARCODE],[BaseUnit] as [Unit],[QtyText] as [Qty],[StockRate] as [Rate] FROM [StockDbf]"
            End If
            TxtList.RowTemplate.Height = 80
        Else
            If MyAppSettings.IsCustomBarcode = True Then
                Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [SNo],[location] as [Location],  [StockCode] as [Stock Code], stockname as [Stock Name],[StockSize] as [Stock Size],[stockgroup] as [Stock Group],[custBarcode] as [BAR CODE],[Barcode] as [BARCODE],[BaseUnit] as [Unit],[QtyText] as [Qty],[StockRate] as [Rate] FROM [StockDbf]"
            Else
                '  Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [S.NO],custbarcode as [BarCode],[location] as [Location],  [StockCode] as [Stock Code],[StockSize] as [Stock Size],[stockgroup] as [Stock Group],[BaseUnit] as [Unit],[QtyText] as [Qty],[StockRate] as [Rate],barcode as [BAR CODE]  FROM [StockDbf]"
                Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [SNo],[location] as [Location],  [StockCode] as [Stock Code], stockname as [Stock Name],[StockSize] as [Stock Size],[stockgroup] as [Stock Group],[custBarcode] as [BAR CODE],[Barcode] as [BARCODE],[BaseUnit] as [Unit],[QtyText] as [Qty],[StockRate] as [Rate]  FROM [StockDbf]"
            End If
            TxtList.RowTemplate.Height = 30
        End If
        Sqlstr = Sqlstr & WhereSqlStr
        ' WhereConditionSqlStr = WhereSqlStr
        Dim TempBS As New BindingSource


        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            TxtList.Columns("BARCODE").Visible = False

            Me.TxtList.Columns("SNo").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("SNo").Width = 35
            If TxtShowImages.Checked = True Then
                Me.TxtList.Columns("Location").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtList.Columns("Location").Width = 100
                Me.TxtList.Columns("Stock Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtList.Columns("Stock Name").Width = 100

                Me.TxtList.Columns("Stock Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Me.TxtList.Columns("Stock Code").Width = 20
                Me.TxtList.Columns("Stock Code").HeaderText = "Design No"
                Me.TxtList.Columns("IMAGE").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtList.Columns("IMAGE").Width = 120
                Me.TxtList.Columns("IMAGE").DisplayIndex = 1
                CType(Me.TxtList.Columns("IMAGE"), DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Stretch
                CType(Me.TxtList.Columns("IMAGE"), DataGridViewImageColumn).DefaultCellStyle.DataSourceNullValue = My.Resources.NOPIC
                TxtList.RowTemplate.Height = 80
            Else
                TxtList.RowTemplate.Height = 30
                Me.TxtList.Columns("Location").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtList.Columns("Location").Width = 100
                Me.TxtList.Columns("Stock Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Me.TxtList.Columns("Stock Code").Width = 20
                Me.TxtList.Columns("Stock Code").HeaderText = "Design No"
                Me.TxtList.Columns("Stock Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtList.Columns("Stock Name").Width = 100
            End If
            'stockgroup
            'Unit
            Me.TxtList.Columns("Unit").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Unit").Width = 60
            Me.TxtList.Columns("qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("qty").Width = 180
            Me.TxtList.Columns("Stock Size").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Stock Size").Width = 80

            Me.TxtList.Columns("Stock Group").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Stock Group").Width = 130
            Me.TxtList.Columns("R Rate").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("R Rate").Width = 65
            Me.TxtList.Columns("R Rate").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("R Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.TxtList.Columns("W Rate").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("W Rate").Width = 65
            Me.TxtList.Columns("w Rate").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("W Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.TxtList.Columns("Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("Rate").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Rate").Width = 65
            Me.TxtList.Columns("Rate").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            Me.TxtList.Columns("BAR CODE").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("BAR CODE").Width = 100
        Catch ex As Exception

        End Try
        Try
            If AppIsItemwithSize = False Then
                TxtList.Columns("Stock Size").Visible = False
            End If
        Catch ex As Exception

        End Try



        MainForm.Cursor = Cursors.Default

      

        'Sqlstr = Sqlstr & WhereSqlStr
        'Dim TempBS As New BindingSource


        'With Me.TxtList
        '    TempBS.DataSource = SQLLoadGridData(Sqlstr)
        '    .AutoGenerateColumns = True
        '    .DataSource = TempBS
        'End With

        'Try
        '    Me.TxtList.Columns("BAR CODE").Visible = False
        '    Me.TxtList.Columns("S.NO").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        '    Me.TxtList.Columns("S.NO").Width = 40
        '    If TxtShowImages.Checked = True Then
        '        Me.TxtList.Columns("Location").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        '        Me.TxtList.Columns("Location").Width = 120
        '        Me.TxtList.Columns("Stock Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        '        Me.TxtList.Columns("Stock Code").Width = 250
        '    Else
        '        Me.TxtList.Columns("Location").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        '        Me.TxtList.Columns("Location").Width = 120
        '        Me.TxtList.Columns("Stock Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        '        Me.TxtList.Columns("Stock Code").Width = 250
        '    End If



        'Catch ex As Exception

        'End Try
        'Try
        '    If AppIsItemwithSize = False Then
        '        TxtList.Columns("Stock Size").Visible = False
        '    End If
        'Catch ex As Exception

        'End Try

        
    End Sub
#End Region

    Private Sub CurrentStockItemReport_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub


    Private Sub StockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loadstockitems()
        TxtFilters.Text = "Filter By Location"
        If varLoadsubstr.Length > 0 Then
            loadstockitems(varLoadsubstr)
        Else
            loadstockitems()
        End If
        IslOaded = True
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub TxtFilters_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFilters.SelectedIndexChanged
        If TxtFilters.Text = "Filter By Location" Then
            LoadDataIntoComboBox("select locationname from STOCKLOCATIONS", TxtFilterBy, "locationname", "*All")
        ElseIf TxtFilters.Text = "Filter By Brand" Then
            LoadDataIntoComboBox("select distinct brand from stockdbf", TxtFilterBy, "brand", "*All")
        ElseIf TxtFilters.Text = "Filter By Group" Then
            LoadDataIntoComboBox("select distinct stockgroup from stockdbf", TxtFilterBy, "stockgroup", "*All")
        ElseIf TxtFilters.Text = "Filter By Category" Then
            LoadDataIntoComboBox("select distinct category from stockdbf", TxtFilterBy, "category", "*All")
        End If
        If TxtFilterBy.Items.Count > 0 Then
            TxtFilterBy.SelectedIndex = 0
        End If
    End Sub

    Private Sub TxtFilterBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFilterBy.SelectedIndexChanged
        If TxtFilters.Text = "Filter By Location" Then
            If TxtFilterBy.Text.Length = 0 Or TxtFilterBy.Text = "*All" Then
                loadstockitems()
            Else
                loadstockitems(" where location=N'" & TxtFilterBy.Text & "'")
            End If

        ElseIf TxtFilters.Text = "Filter By Brand" Then
            If TxtFilterBy.Text.Length = 0 Or TxtFilterBy.Text = "*All" Then
                loadstockitems()
            Else
                loadstockitems(" where brand=N'" & TxtFilterBy.Text & "'")
            End If

        ElseIf TxtFilters.Text = "Filter By Group" Then
            If TxtFilterBy.Text.Length = 0 Or TxtFilterBy.Text = "*All" Then
                loadstockitems()
            Else
                loadstockitems(" where stockgroup=N'" & TxtFilterBy.Text & "'")
            End If

        ElseIf TxtFilters.Text = "Filter By Category" Then
            If TxtFilterBy.Text.Length = 0 Or TxtFilterBy.Text = "*All" Then
                loadstockitems()
            Else
                loadstockitems(" where category=N'" & TxtFilterBy.Text & "'")
            End If

        End If
    End Sub

    Private Sub TxtSearchByStockItem_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearchByStockItem.TextChanged
        If TxtSearchByStockItem.Text.Length = 0 Then
            loadstockitems()
        Else
            loadstockitems(" where stockcode like N'%" & TxtSearchByStockItem.Text & "%'")
        End If
    End Sub



    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        loadstockitems()
    End Sub


    Private Sub TxtShowImages_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShowImages.CheckedChanged
        loadstockitems()
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If Sqlstr.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(Sqlstr, cnn)
        dscmd.Fill(ds, "StockDbf")
        cnn.Close()
        Dim objRpt As New CurrentStockCrReport
        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "CURRENT STOCK REPORT"
        Else
            CType(objRpt.Section2.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "CURRENT STOCK REPORT"

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

    Private Sub TxtSearchbyStockName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearchbyStockName.TextChanged
        If TxtSearchbyStockName.Text.Length = 0 Then
            loadstockitems()
        Else
            loadstockitems(" where stockname like N'%" & TxtSearchbyStockName.Text & "%'")
        End If
    End Sub

    Private Sub TxtList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub

    Private Sub ShowInwardDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowInwardDetailsToolStripMenuItem.Click

        MainForm.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If StockINOUTReport Is Nothing OrElse StockINOUTReport.IsDisposed Then
            StockINOUTReport = New ViewInwards(True, TxtList.Item("Stock Code", TxtList.CurrentRow.Index).Value)
            StockINOUTReport.BringToFront()
            StockINOUTReport.StartPosition = FormStartPosition.CenterParent
            StockINOUTReport.Show()
        Else
            StockINOUTReport.Dispose()
            StockINOUTReport = New ViewInwards(True, TxtList.Item("Stock Code", TxtList.CurrentRow.Index).Value)
            StockINOUTReport.BringToFront()
            StockINOUTReport.StartPosition = FormStartPosition.CenterParent
            StockINOUTReport.Show()
        End If
        MainForm.Cursor = Cursors.Arrow
    End Sub
    Public Shared StockINOUTReport As ViewInwards
    Public Shared Stockmovementfrm As StockMovementAnalysis

    Private Sub ShowOutWardDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowOutWardDetailsToolStripMenuItem.Click
        MainForm.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If StockINOUTReport Is Nothing OrElse StockINOUTReport.IsDisposed Then
            StockINOUTReport = New ViewInwards(False, TxtList.Item("Stock Code", TxtList.CurrentRow.Index).Value)
            StockINOUTReport.BringToFront()
            StockINOUTReport.StartPosition = FormStartPosition.CenterParent
            StockINOUTReport.Show()
        Else
            StockINOUTReport.Dispose()
            StockINOUTReport = New ViewInwards(True, TxtList.Item("Stock Code", TxtList.CurrentRow.Index).Value)
            StockINOUTReport.BringToFront()
            StockINOUTReport.StartPosition = FormStartPosition.CenterParent
            StockINOUTReport.Show()
        End If
        MainForm.Cursor = Cursors.Arrow
    End Sub

    Private Sub ShowInwardAndOutwardDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowInwardAndOutwardDetailsToolStripMenuItem.Click
        MainForm.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        'TxtList.Item("Stock Code", TxtList.CurrentRow.Index).Value
        If Stockmovementfrm Is Nothing OrElse Stockmovementfrm.IsDisposed Then
            Stockmovementfrm = New StockMovementAnalysis()
            Stockmovementfrm.TxtStockCode.Text = TxtList.Item("Stock Code", TxtList.CurrentRow.Index).Value
            Stockmovementfrm.LOADDATA()
            Stockmovementfrm.BringToFront()
            Stockmovementfrm.StartPosition = FormStartPosition.CenterParent
            Stockmovementfrm.Show()
        Else
            Stockmovementfrm.Dispose()
            Stockmovementfrm = New StockMovementAnalysis()
            Stockmovementfrm.TxtStockCode.Text = TxtList.Item("Stock Code", TxtList.CurrentRow.Index).Value
            Stockmovementfrm.LOADDATA()
            Stockmovementfrm.BringToFront()
            Stockmovementfrm.StartPosition = FormStartPosition.CenterParent
            Stockmovementfrm.Show()
        End If
        MainForm.Cursor = Cursors.Arrow
    End Sub

    Private Sub ShowProfitOnThisItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowProfitOnThisItemToolStripMenuItem.Click
        MainForm.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        'TxtList.Item("Stock Code", TxtList.CurrentRow.Index).Value
        If StockPROFTsUMMARYfrm Is Nothing OrElse StockPROFTsUMMARYfrm.IsDisposed Then
            StockPROFTsUMMARYfrm = New profitreportsummary()
            StockPROFTsUMMARYfrm.TxtStockCode.Text = TxtList.Item("Stock Code", TxtList.CurrentRow.Index).Value
            StockPROFTsUMMARYfrm.LoadReport()
            StockPROFTsUMMARYfrm.BringToFront()
            StockPROFTsUMMARYfrm.StartPosition = FormStartPosition.CenterParent
            StockPROFTsUMMARYfrm.Show()
        Else
            StockPROFTsUMMARYfrm.Dispose()
            StockPROFTsUMMARYfrm = New profitreportsummary()
            StockPROFTsUMMARYfrm.TxtStockCode.Text = TxtList.Item("Stock Code", TxtList.CurrentRow.Index).Value
            StockPROFTsUMMARYfrm.LoadReport()
            StockPROFTsUMMARYfrm.BringToFront()
            StockPROFTsUMMARYfrm.StartPosition = FormStartPosition.CenterParent
            StockPROFTsUMMARYfrm.Show()
        End If
        MainForm.Cursor = Cursors.Arrow
    End Sub
    Public Shared StockPROFTsUMMARYfrm As profitreportsummary
End Class