Public Class CustomBarcodeEntry
    Dim SQlStr As String = ""
    Dim ListIsOnloading As Boolean = True

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadStock(Optional ByVal AdditionSqlText As String = "")
        If MyAppSettings.IsAllowBatchNoExipry = True Then
            SQlStr = "SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [S.NO],  [StockCode] as [Stock Code],stockname as [Stock Name],[StockSize] as [Stock Size],[stockgroup] as [Stock Group],[custBarcode] as [BARCODE],batchno as [Batch No],expiry as [Expiry],[custBarcode] as [BAR CODE]  FROM [StockDbf] "
        Else
            SQlStr = "SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [S.NO],  [StockCode] as [Stock Code],stockname as [Stock Name],[StockSize] as [Stock Size],[stockgroup] as [Stock Group],[custBarcode] as [BARCODE],batchno as [Batch No],expiry as [Expiry],[custBarcode] as [BAR CODE]  FROM [StockDbf] "
        End If
        ListIsOnloading = True
        Dim TempBS As New BindingSource
        SQlStr = SQlStr & AdditionSqlText
        If AdditionSqlText.Length > 0 Then
            SQlStr = SQlStr & " and location=N'" & GetDefLocationName() & "'"
        Else
            SQlStr = SQlStr & " where location=N'" & GetDefLocationName() & "'"
        End If
        Try
            Me.TxtList.Rows.Clear()
        Catch ex As Exception

        End Try

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SQlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(0).Width = 35
            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(1).Width = 200
            Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(2).Width = 150
            Me.TxtList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(3).Width = 150
            Me.TxtList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(4).Width = 150
            Me.TxtList.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(5).Width = 150
            For i As Integer = 0 To TxtList.ColumnCount - 1
                Me.TxtList.Columns(i).ReadOnly = True
            Next
        Catch ex As Exception

        End Try
       
        Try

            Me.TxtList.Columns("BARCODE").Visible = False
            Me.TxtList.Columns("BAR CODE").ReadOnly = False
            If AppIsItemwithSize = False Then
                TxtList.Columns("Stock Size").Visible = False
            End If
        Catch ex As Exception

        End Try
        ListIsOnloading = False
    End Sub

    Private Sub CustomBarcodeEntry_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub CustomBarcodeEntry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select stockgroupname from stockgroups", TxtGroup, "stockgroupname", "*All")
        LoadDataIntoComboBox("select StockCategoryName from Categoriesgroups", TxtCat, "StockCategoryName", "*All")
        LoadDataIntoComboBox("select locationname  from StockLocations", TxtLocation, "locationname", "*All")
        LoadStock()

    End Sub

    Private Sub TxtLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLocation.SelectedIndexChanged
        If TxtLocation.Text.Length = 0 Or TxtLocation.Text = "*All" Then
            LoadStock()
        Else
            LoadStock(" Where location=N'" & TxtLocation.Text & "'")
        End If
    End Sub

    Private Sub TxtGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtGroup.SelectedIndexChanged
        If TxtGroup.Text.Length = 0 Or TxtGroup.Text = "*All" Then
            LoadStock()
        Else
            LoadStock(" Where stockgroup=N'" & TxtGroup.Text & "'")
        End If
    End Sub

    Private Sub TxtCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCat.SelectedIndexChanged
        If TxtCat.Text.Length = 0 Or TxtCat.Text = "*All" Then
            LoadStock()
        Else
            LoadStock(" Where category=N'" & TxtCat.Text & "'")
        End If
    End Sub

    Private Sub TxtStockName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockName.TextChanged
        If TxtStockName.Text.Length = 0 Then
            LoadStock()
        Else
            LoadStock(" Where StockName LIKE N'%" & TxtStockName.Text & "%'")
        End If
    End Sub

    Private Sub ImsTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockCode.TextChanged
        If TxtStockCode.Text.Length = 0 Then
            LoadStock()
        Else
            LoadStock(" Where Stockcode LIKE N'%" & TxtStockCode.Text & "%'")
        End If
    End Sub


    Private Sub TxtList_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellValueChanged
       
        If ListIsOnloading = True Then Exit Sub
        Dim TempBarcode As String = ""

        If TxtList.Item("BAR CODE", TxtList.CurrentRow.Index).Value.ToString.Length = 0 Then Exit Sub

        TempBarcode = ReplaceZerosToBarcode(TxtList.Item("BAR CODE", TxtList.CurrentRow.Index).Value)
        If TempBarcode = "0" Or TempBarcode = "0000000000000" Then
            LoadStock()
        Else

            If SQLIsFieldExists("select custbarcode from stockdbf where custbarcode=N'" & TempBarcode & "'") = True Then
                MsgBox("The Barcode is already exists....", MsgBoxStyle.Critical)
                LoadStock()
                Exit Sub
            End If
        End If

        ' TxtList.Item("BAR CODE", TxtList.CurrentRow.Index).Value = TempBarcode
        ExecuteSQLQuery("update stockdbf set custbarcode=N'" & TempBarcode & "' where custbarcode=N'" & TxtList.Item("BARCODE", TxtList.CurrentRow.Index).Value & "'")
        ExecuteSQLQuery("update barcodelist set Pbarcode=N'" & TempBarcode & "' where Pbarcode=N'" & TxtList.Item("BARCODE", TxtList.CurrentRow.Index).Value & "'")
        'Pbarcode
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Me.Close()
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click
        Me.Cursor = Cursors.WaitCursor
        Barcodeprintingnewfrm.SuspendLayout()
        Barcodeprintingnewfrm.MdiParent = MainForm
        Barcodeprintingnewfrm.Dock = DockStyle.Fill
        Barcodeprintingnewfrm.Show()
        Barcodeprintingnewfrm.WindowState = FormWindowState.Maximized
        Barcodeprintingnewfrm.BringToFront()
        Barcodeprintingnewfrm.ResumeLayout()
        Me.Cursor = Cursors.Default

    End Sub
End Class