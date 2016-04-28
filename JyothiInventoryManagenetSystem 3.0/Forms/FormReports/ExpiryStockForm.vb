Imports System.Data.SqlClient

Public Class ExpiryStockForm
    Dim IslOaded As Boolean = False
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Dim Sqlstr As String = ""
    Dim SqlStrSoon As String = ""
    Dim varLoadsubstr As String = ""
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
    Sub loadstockitems(Optional ByVal WhereSqlStr As String = "")

        Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [S.NO],[location] as [Location],  [StockCode] as [Stock Code],[StockSize] as [Stock Size],batchno as [Batch Number],expiry as [Expiry],[QtyText] as [Qty],barcode as [BAR CODE],(" & Today.Date.ToOADate & "-expirydatevalue) as [Expiry Days]  FROM [stockbatch] where expiryDateValue<=" & Today.Date.ToOADate

        Sqlstr = Sqlstr & WhereSqlStr
        Dim TempBS As New BindingSource
        Try
            TxtList.Columns.Remove("SImage")
        Catch ex As Exception

        End Try
        If TxtShowImages.Checked = True Then
            Dim kc As New DataGridViewImageColumn()
            kc.DisplayIndex = 1
            kc.Name = "SImage"
            kc.Width = 120
            kc.ImageLayout = DataGridViewImageCellLayout.Stretch
            kc.HeaderText = "Image"
            TxtList.Columns.Add(kc)
            TxtList.RowTemplate.Height = 80
        Else
            TxtList.RowTemplate.Height = 30
        End If
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            Me.TxtList.Columns("BAR CODE").Visible = False
            Me.TxtList.Columns("S.NO").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("S.NO").Width = 40
            If TxtShowImages.Checked = True Then
                Me.TxtList.Columns("Location").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtList.Columns("Location").Width = 120

                Me.TxtList.Columns("Stock Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtList.Columns("Stock Code").Width = 150

                Me.TxtList.Columns("Batch Number").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtList.Columns("Batch Number").Width = 120
            Else
                Me.TxtList.Columns("Location").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtList.Columns("Location").Width = 120

                Me.TxtList.Columns("Stock Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtList.Columns("Stock Code").Width = 250

                Me.TxtList.Columns("Batch Number").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtList.Columns("Batch Number").Width = 120
            End If



        Catch ex As Exception

        End Try
        Try
            If AppIsItemwithSize = False Then
                TxtList.Columns("Stock Size").Visible = False
            End If
        Catch ex As Exception

        End Try

        If TxtShowImages.Checked = True Then

            For i As Integer = 0 To TxtList.RowCount - 1
                Dim imgname As String = SQLGetStringFieldValue("select stockimagepath from stockdbf where barcode=N'" & TxtList.Item("BAR CODE", i).Value & "'", "stockimagepath")
                If imgname.Length > 0 Then
                    Try
                        CType(TxtList.Item("SImage", i), DataGridViewImageCell).Value = Image.FromFile(imgname)
                    Catch ex As Exception

                    End Try

                End If
            Next
        End If
        Dim dt As New DateTimePicker
        dt.Value = Today.Date.AddDays(10)
        'soon
        SqlStrSoon = "SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [S.NO],[location] as [Location],  [StockCode] as [Stock Code],[StockSize] as [Stock Size],batchno as [Batch Number],expiry as [Expiry],[QtyText] as [Qty],barcode as [BAR CODE],(" & Today.Date.ToOADate & "-expirydatevalue) as [Expiry Days]  FROM [stockbatch] where expiryDateValue>" & Today.Date.ToOADate & " AND EXPIRYDATEVALUE<=" & dt.Value.Date.ToOADate


        SqlStrSoon = SqlStrSoon & WhereSqlStr
        Dim TempBS1 As New BindingSource
        Try
            TxtListSoon.Columns.Remove("SImage")
        Catch ex As Exception

        End Try
        If TxtShowImages.Checked = True Then
            Dim kc As New DataGridViewImageColumn()
            kc.DisplayIndex = 1
            kc.Name = "SImage"
            kc.Width = 120
            kc.ImageLayout = DataGridViewImageCellLayout.Stretch
            kc.HeaderText = "Image"
            TxtListSoon.Columns.Add(kc)
            TxtListSoon.RowTemplate.Height = 80
        Else
            TxtListSoon.RowTemplate.Height = 30
        End If
        With Me.TxtListSoon
            TempBS1.DataSource = SQLLoadGridData(SqlStrSoon)
            .AutoGenerateColumns = True
            .DataSource = TempBS1
        End With

        Try
            Me.TxtListSoon.Columns("BAR CODE").Visible = False
            Me.TxtListSoon.Columns("S.NO").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtListSoon.Columns("S.NO").Width = 40
            If TxtShowImages.Checked = True Then
                Me.TxtListSoon.Columns("Location").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtListSoon.Columns("Location").Width = 120

                Me.TxtListSoon.Columns("Stock Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtListSoon.Columns("Stock Code").Width = 150

                Me.TxtListSoon.Columns("Batch Number").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtListSoon.Columns("Batch Number").Width = 120
            Else
                Me.TxtListSoon.Columns("Location").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtListSoon.Columns("Location").Width = 120

                Me.TxtListSoon.Columns("Stock Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtListSoon.Columns("Stock Code").Width = 250

                Me.TxtListSoon.Columns("Batch Number").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.TxtListSoon.Columns("Batch Number").Width = 120
            End If



        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub ExpiryStockForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub


    Private Sub StockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtFilters.Text = "Filter By Location"
        loadstockitems()
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
                loadstockitems(" and location=N'" & TxtFilterBy.Text & "'")
            End If

        End If
    End Sub

    Private Sub TxtSearchByStockItem_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearchByStockItem.TextChanged
        If TxtSearchByStockItem.Text.Length = 0 Then
            loadstockitems()
        Else
            loadstockitems(" and stockcode like N'%" & TxtSearchByStockItem.Text & "%'")
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
        Dim ds As New ExpiryStockDataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim TEMPSTR As String = ""
        If TabControl1.SelectedIndex = 0 Then
            TEMPSTR = Sqlstr
        Else
            TEMPSTR = SqlStrSoon
        End If
        Dim dscmd As New SqlDataAdapter(TEMPSTR, cnn)
        dscmd.Fill(ds, "stockbatch")
        cnn.Close()

        Dim objRpt As New ExpiryStockCRReport
        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)

            If TabControl1.SelectedIndex = 0 Then
                CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EXPIRY STOCK REPORT"
            Else
                CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "NEAREST EXPIRY STOCK REPORT "
            End If
        Else

            If TabControl1.SelectedIndex = 0 Then
                CType(objRpt.Section2.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EXPIRY STOCK REPORT"
            Else
                CType(objRpt.Section2.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "NEAREST EXPIRY STOCK REPORT"
            End If
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