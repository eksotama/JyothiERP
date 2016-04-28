Public Class PriceList
    Dim DbFiledName As String = ""
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadData(Optional ByVal subSqlstr As String = "")


        If TxtPriceListName.Text = "Wholesale" Then
            DbFiledName = "StockWRP"
        ElseIf TxtPriceListName.Text = "Retail" Then
            DbFiledName = "StockDRP"
        Else
            DbFiledName = TxtPriceListName.Text
        End If
        If TxtPriceListName.Text.Length = 0 Then Exit Sub

        Dim SqlStr As String = ""
        '  SqlStr = "Select DISTINCT(stockcode) as [StockCode],barcode as [barcode],stockname as [Stock Name],Stocksize as [Stock Size]," & DbFiledName & " as [Price] from stockdbf "
        If IsStockGroupWise.Checked = True And IsStockCatWise.Checked = True Then
            If (TxtStockCat.Text.Length = 0 Or TxtStockCat.Text = "*All") And (TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All") Then
                SqlStr = "Select DISTINCT(stockcode) as [StockCode],barcode as [barcode],stockname as [Stock Name],Stocksize as [Stock Size]," & DbFiledName & " as [Price] from stockdbf "
            ElseIf TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
                SqlStr = "Select DISTINCT  stockcode as [StockCode] ,barcode as [barcode],stockname as [Stock Name],Stocksize as [Stock Size]," & DbFiledName & " as [Price] from stockdbf where category=N'" & TxtStockCat.Text & "' "
            ElseIf TxtStockCat.Text.Length = 0 Or TxtStockCat.Text = "*All" Then
                SqlStr = "Select DISTINCT  stockcode as [StockCode] ,barcode as [barcode],stockname as [Stock Name],Stocksize as [Stock Size]," & DbFiledName & " as [Price] from stockdbf where  stockgroup=N'" & TxtStockGroup.Text & "' "
            Else
                SqlStr = "Select DISTINCT  stockcode as [StockCode] ,barcode as [barcode],stockname as [Stock Name],Stocksize as [Stock Size]," & DbFiledName & " as [Price] from stockdbf where category=N'" & TxtStockCat.Text & "' and stockgroup=N'" & TxtStockGroup.Text & "' "
            End If

        ElseIf IsStockGroupWise.Checked = True Then
            If TxtStockGroup.Text.Length = 0 Or TxtStockGroup.Text = "*All" Then
                SqlStr = "Select DISTINCT  stockcode as [StockCode] ,barcode as [barcode],stockname as [Stock Name],Stocksize as [Stock Size]," & DbFiledName & " as [Price] from stockdbf  "
            Else
                SqlStr = "Select DISTINCT  stockcode as [StockCode] ,barcode as [barcode],stockname as [Stock Name],Stocksize as [Stock Size]," & DbFiledName & " as [Price] from stockdbf where  stockgroup=N'" & TxtStockGroup.Text & "' "
            End If
        ElseIf IsStockCatWise.Checked = True Then
            If TxtStockCat.Text.Length = 0 Or TxtStockCat.Text = "*All" Then
                SqlStr = "Select DISTINCT  stockcode as [StockCode] ,barcode as [barcode],stockname as [Stock Name],Stocksize as [Stock Size]," & DbFiledName & " as [Price] from stockdbf  "
            Else
                SqlStr = "Select DISTINCT  stockcode as [StockCode] ,barcode as [barcode],stockname as [Stock Name],Stocksize as [Stock Size]," & DbFiledName & " as [Price] from stockdbf where category=N'" & TxtStockCat.Text & "' "
            End If
        Else
            SqlStr = "Select DISTINCT  stockcode  as [StockCode],barcode as [barcode],stockname as [Stock Name],Stocksize as [Stock Size]," & DbFiledName & " as [Price] from stockdbf "
        End If


        Dim TempBS As New BindingSource

        Try
            Me.TxtList.Rows.Clear()
        Catch ex As Exception

        End Try

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

      
        Try
            TxtList.Columns(0).Width = 250
            TxtList.Columns(2).Width = 350
            TxtList.Columns(3).Width = 250
            TxtList.Columns("StockCode").ReadOnly = True
            TxtList.Columns("barcode").Visible = False
            TxtList.Columns("Stock Name").ReadOnly = True
            TxtList.Columns("Stock Size").ReadOnly = True
            TxtList.Columns("Price").ReadOnly = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PriceList_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub PriceList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select stockgroupname from stockgroups", TxtStockGroup, "stockgroupname", "*All")
        LoadDataIntoComboBox("select StockCategoryName from Categoriesgroups", TxtStockCat, "StockCategoryName", "*All")
        LoadPriceListNames()
    End Sub
    Sub LoadPriceListNames()
        TxtPriceListName.Items.Clear()
        LoadDataIntoComboBox("select  pricelistname from pricelist", TxtPriceListName, "pricelistname")
        TxtPriceListName.Items.Add("Wholesale")
        TxtPriceListName.Items.Add("Retail")
    End Sub
    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Dim k As New CreateNewPriceList
        k.ShowDialog()
        LoadPriceListNames()
        TxtPriceListName.Text = "Wholesale"
        LoadData()
    End Sub

    Private Sub TxtPriceListName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPriceListName.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub TxtStockGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockGroup.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub TxtStockCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockCat.SelectedIndexChanged
        LoadData()
    End Sub



    Private Sub TxtList_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellValueChanged
        If DbFiledName.Length = 0 Then Exit Sub
        If TxtList.Item("Price", TxtList.CurrentRow.Index).Value.ToString.Length = 0 Then Exit Sub
        If TxtList.Item("Price", TxtList.CurrentRow.Index).Value.ToString.Length > 14 Then Exit Sub
        If IsNumeric(TxtList.Item("Price", TxtList.CurrentRow.Index).Value) = False Then Exit Sub
       
        ExecuteSQLQuery("update stockdbf set " & DbFiledName & "=" & CDbl(TxtList.Item("Price", TxtList.CurrentRow.Index).Value) & " where stockcode=N'" & TxtList.Item("StockCode", TxtList.CurrentRow.Index).Value & "' and stocksize=N'" & TxtList.Item("Stock Size", TxtList.CurrentRow.Index).Value & "'")

    End Sub

    Private Sub TxtList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        Dim efrm As New ImportPriceList
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
End Class