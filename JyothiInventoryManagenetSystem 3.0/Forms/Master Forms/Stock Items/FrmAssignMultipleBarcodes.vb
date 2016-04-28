Public Class FrmAssignMultipleBarcodes
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
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)

    End Sub
    'If IsDBNull(Dbf.Fields("photopath").Value) = False Then
    '                        CType(MembersList.Item("cphoto", i), DataGridViewImageCell).Value = Image.FromFile(Dbf.Fields("photopath").Value)
    '                    End If
#Region "Functions"
    Sub loadstockitems(Optional ByVal WhereSqlStr As String = "")
        MainForm.Cursor = Cursors.WaitCursor
        Dim Sqlstr As String
        Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [SNo],[custBarcode] as [BAR CODE],  [StockCode] as [Stock Code], stockname as [Stock Name],[StockSize] as [Stock Size] FROM [StockDbf] "
        TxtList.RowTemplate.Height = 30
        Sqlstr = Sqlstr & WhereSqlStr
        Sqlstr = Sqlstr & "  group by stockcode,stocksize,custbarcode,stockname  "
        Dim TempBS As New BindingSource

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With


        MainForm.Cursor = Cursors.Default
    End Sub
#End Region
   

    Private Sub StockItems_shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub StockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadstockitems()
        TxtFilters.Text = "Filter By Location"
        IslOaded = True
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click, ImsButton1.Click
        Me.Close()
    End Sub

   
    Private Sub TxtSearchbyStockName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearchbyStockName.TextChanged
        If TxtSearchbyStockName.Text.Length = 0 Then
            loadstockitems()
        Else
            loadstockitems(" where stockname like N'%" & TxtSearchbyStockName.Text & "%'")
        End If
    End Sub
   
    Private Sub TxtList_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles TxtList.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right And e.ColumnIndex > -1 And e.RowIndex > -1 Then
            Dim cell As DataGridViewCell = TxtList.Rows(e.RowIndex).Cells(e.ColumnIndex)
            TxtList.CurrentCell = cell
            Me.TxtListGridMenu.Show(Cursor.Position)
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

    Private Sub btnActivate_Click(sender As System.Object, e As System.EventArgs) Handles btnActivate.Click
        If TxtList.RowCount = 0 Then Exit Sub
        Dim frm As New AssignBarcodes(TxtList.Item("BAR CODE", TxtList.CurrentRow.Index).Value)
        frm.ShowDialog()

    End Sub
End Class