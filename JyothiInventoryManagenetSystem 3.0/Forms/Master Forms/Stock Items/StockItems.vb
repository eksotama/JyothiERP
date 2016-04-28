Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class StockItems
    Dim IslOaded As Boolean = False
    Dim WhereConditionSqlStr As String = ""
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
    'If IsDBNull(Dbf.Fields("photopath").Value) = False Then
    '                        CType(MembersList.Item("cphoto", i), DataGridViewImageCell).Value = Image.FromFile(Dbf.Fields("photopath").Value)
    '                    End If
#Region "Functions"
    Sub loadstockitems(Optional ByVal WhereSqlStr As String = "")
        MainForm.Cursor = Cursors.WaitCursor
        Dim Sqlstr As String
        If TxtShowImages.Checked = True Then
            If MyAppSettings.IsCustomBarcode = True Then
                Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [SNo],(SELECT TOP 1 IMAGEDATA FROM IMAGES WHERE BCODE=CUSTBARCODE) AS IMAGE ,[location] as [Location],  [StockCode] as [Stock Code], stockname as [Stock Name],[StockSize] as [Stock Size],[stockgroup] as [Stock Group],[custBarcode] as [BAR CODE],[Barcode] as [BARCODE],[BaseUnit] as [Unit],[QtyText] as [Qty],[StockRate] as [Rate],mrp as [MRP],[StockWRP] as [W Rate],[StockDRP] as [R Rate]  FROM [StockDbf]"
            Else
                Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [SNo],(SELECT TOP 1 IMAGEDATA FROM IMAGES WHERE BCODE=CUSTBARCODE) AS IMAGE,[location] as [Location],  [StockCode] as [Stock Code], stockname as [Stock Name],[StockSize] as [Stock Size],[stockgroup] as [Stock Group],[custBarcode] as [BAR CODE],[Barcode] as [BARCODE],[BaseUnit] as [Unit],[QtyText] as [Qty],[StockRate] as [Rate],mrp as [MRP],[StockWRP] as [W Rate],[StockDRP] as [R Rate]  FROM [StockDbf]"
            End If
            TxtList.RowTemplate.Height = 80
        Else
            If MyAppSettings.IsCustomBarcode = True Then
                Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [SNo],[location] as [Location],  [StockCode] as [Stock Code], stockname as [Stock Name],[StockSize] as [Stock Size],[stockgroup] as [Stock Group],[custBarcode] as [BAR CODE],[Barcode] as [BARCODE],[BaseUnit] as [Unit],[QtyText] as [Qty],[StockRate] as [Rate],mrp as [MRP],[StockWRP] as [W Rate],[StockDRP] as [R Rate]  FROM [StockDbf]"
            Else
                Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [SNo],[location] as [Location],  [StockCode] as [Stock Code], stockname as [Stock Name],[StockSize] as [Stock Size],[stockgroup] as [Stock Group],[custBarcode] as [BAR CODE],[Barcode] as [BARCODE],[BaseUnit] as [Unit],[QtyText] as [Qty],[StockRate] as [Rate],mrp as [MRP],[StockWRP] as [W Rate],[StockDRP] as [R Rate]  FROM [StockDbf]"
            End If
            TxtList.RowTemplate.Height = 30
        End If
        Sqlstr = Sqlstr & WhereSqlStr
        WhereConditionSqlStr = WhereSqlStr
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
                Me.TxtList.Columns("Stock Name").Width = 80

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
            Me.TxtList.Columns("Unit").Width = 85
            Me.TxtList.Columns("qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("qty").Width = 100
            Me.TxtList.Columns("Stock Size").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Stock Size").Width = 80

            Me.TxtList.Columns("Stock Group").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Stock Group").Width = 100
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

            Me.TxtList.Columns("mrp").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("mrp").Width = 65
            Me.TxtList.Columns("mrp").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtList.Columns("mrp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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
    End Sub
#End Region
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        Dim k As New CreateNewStockItem
        k.ShowDialog()
        loadstockitems()
    End Sub

    Private Sub StockItems_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub StockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        loadstockitems()
        TxtFilters.Text = "Filter By Location"
        IslOaded = True
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub TxtList_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.RowEnter
        On Error Resume Next
        If IslOaded = False Then Exit Sub
        Dim v_isactive As Integer

        v_isactive = SQLGetNumericFieldValue("SELECT ISACTIVE FROM StockDbf WHERE Barcode=N'" & TxtList.Item("Barcode", e.RowIndex).Value & "' and location=N'" & TxtList.Item("location", e.RowIndex).Value & "'", "ISACTIVE")
        If v_isactive = 0 Then
            btnActivate.Text = "Activate"
        Else
            btnActivate.Text = "DeActivate"
        End If

    End Sub

    Private Sub btnActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivate.Click
        If IslOaded = False Then Exit Sub
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If btnActivate.Text = "Activate" Then
            If MsgBox("Do you want to Activate the selected Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE StockDbf SET ISACTIVE=1 WHERE Barcode=N'" & TxtList.Item("Barcode", TxtList.CurrentRow.Index).Value & "' and  location=N'" & TxtList.Item("location", TxtList.CurrentRow.Index).Value & "'")
                btnActivate.Text = "DeActivate"
                TxtList.Focus()
            End If
        Else
            If MsgBox("Do you want to De-Activate the selected Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE StockDbf SET ISACTIVE=0 WHERE Barcode=N'" & TxtList.Item("Barcode", TxtList.CurrentRow.Index).Value & "' and  location=N'" & TxtList.Item("location", TxtList.CurrentRow.Index).Value & "'")
                btnActivate.Text = "Activate"
                TxtList.Focus()
            End If
        End If
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub

        If TxtList.RowCount = 0 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [S.NO],barcode as [BarCode],[location] as [Location],  [StockCode] as [Stock Code],[StockSize] as [Stock Size],[stockgroup] as [Stock Group],[BaseUnit] as [Unit],[QtyText] as [Qty],[StockRate] as [Rate],barcode as [BAR CODE]  FROM [StockDbf] " & WhereConditionSqlStr, cnn)
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

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If IsTrailApplication = True Then
            MsgBox("Edit and Delete is not allowed in trail version....", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If APPUserRights.IsDeleteble = False Then
            MsgBox("The Delete Restricted by the Admin, No possible to Delete......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If SQLIsFieldExists("select top 1 1 from StockInvoiceRowItems where stockcode=N'" & TxtList.Item("Stock Code", TxtList.CurrentRow.Index).Value & "' and stocksize=N'" & TxtList.Item("Stock Size", TxtList.CurrentRow.Index).Value & "'") = True Then
            MsgBox("The Selected Stock Item is already in use, can not be Delete......", MsgBoxStyle.Information)
            Exit Sub
        End If
        If Application.OpenForms.Count > 2 Then
            MsgBox("Please Close all Forms before delete the Item...", MsgBoxStyle.Information)
            Exit Sub
        End If
        If IsthereanyUsersLogin() = True Then
            MsgBox("Some Users are in login, It it not possible to delete at this time...")
            Exit Sub
        End If
        If MsgBox("Do you want to delete the current Stock Item ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If IsthereanyUsersLogin() = True Then
                MsgBox("Some Users are in login, It it not possible to delete at this time...")
                Exit Sub
            Else
                ExecuteSQLQuery("delete from stockdbf where stockcode=N'" & TxtList.Item("Stock Code", TxtList.CurrentRow.Index).Value & "' and stocksize=N'" & TxtList.Item("Stock Size", TxtList.CurrentRow.Index).Value & "'")
                ExecuteSQLQuery("delete from stockbatch where stockcode=N'" & TxtList.Item("Stock Code", TxtList.CurrentRow.Index).Value & "' and stocksize=N'" & TxtList.Item("Stock Size", TxtList.CurrentRow.Index).Value & "'")
                loadstockitems()
            End If
        End If
    End Sub

    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        loadstockitems()
    End Sub


    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub

        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If IsTrailApplication = True Then
            MsgBox("Edit and Delete is not allowed in trail version....", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If APPUserRights.IsEditable = False Then
            MsgBox("The Edit Restricted by the Admin, Not possible to Edit......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If MsgBox("Do you want to Alter the current Stock Item ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim k As New CreateNewStockItem(TxtList.Item("Stock Code", TxtList.CurrentRow.Index).Value, TxtList.Item("Stock Size", TxtList.CurrentRow.Index).Value, False)
            k.BtnCreate.Text = "&Alter"
            k.Text = "Alter Stock Items"
            k.Label1.Text = "ALTER STOCK ITEMS"
            k.BtnCreate.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.save
            k.ShowDialog()
            loadstockitems()
        End If
    End Sub

    Private Sub TxtShowBatchExpiryAlso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShowBatchExpiryAlso.CheckedChanged

    End Sub

    Private Sub TxtShowImages_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShowImages.CheckedChanged
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


    Private Sub BtnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImport.Click, IMPORTToolStripMenuItem.Click
        Dim efrm As New StockItemsImportExport
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

    Private Sub TxtSearchbyStockName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearchbyStockName.TextChanged
        If TxtSearchbyStockName.Text.Length = 0 Then
            loadstockitems()
        Else
            loadstockitems(" where stockname like N'%" & TxtSearchbyStockName.Text & "%'")
        End If
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
    Private Sub TxtList_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles TxtList.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right And e.ColumnIndex > -1 And e.RowIndex > -1 Then
            Dim cell As DataGridViewCell = TxtList.Rows(e.RowIndex).Cells(e.ColumnIndex)
            TxtList.CurrentCell = cell
            Me.TxtListGridMenu.Show(Cursor.Position)
        End If
    End Sub


    Private Sub ExportToExcelToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        Dim sdlg As New SaveFileDialog
        Dim xlFileName As String = ""
        sdlg.Filter = "(*.xlsx, *.xls)|*.xlsx;*.xls "
        If sdlg.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If
        xlFileName = sdlg.FileName

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        Dim i As Int16, j As Int16

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")
        For i = 0 To Me.TxtList.ColumnCount - 1
            xlWorkSheet.Cells(1, i + 1) = Me.TxtList.Columns(i).Name.ToString
        Next

        For i = 1 To Me.TxtList.RowCount
            For j = 1 To Me.TxtList.ColumnCount
                xlWorkSheet.Cells(i + 1, j) = Me.TxtList(j - 1, i - 1).Value.ToString()
            Next
        Next
        Try
            xlWorkBook.SaveAs(xlFileName)
        Catch ex As Exception

        End Try
        'xlWorkBook.SaveAs(xlFileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
        xlWorkBook.Close(True, misValue, misValue)
        xlApp.Quit()

        releaseObject(xlWorkSheet)
        releaseObject(xlWorkBook)
        releaseObject(xlApp)

    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
            MessageBox.Show("Exception Occured while releasing object " + ex.ToString())
        Finally
            GC.Collect()

        End Try
    End Sub
End Class