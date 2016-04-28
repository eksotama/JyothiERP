Imports Microsoft.Office.Interop

Public Class IMSList
    Private Sub ERPList_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Me.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right And e.ColumnIndex > -1 And e.RowIndex > -1 Then
            ContextMenuStrip1.Show(Cursor.Position)
        End If
    End Sub


    Private Sub ToolStripMenuCopyCell_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuCopyCell.Click
        Try
            Clipboard.SetText(Me.CurrentCell.Value.ToString)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuCopyRow_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuCopyRow.Click
        Try
            Dim tabstring As String = ""
            For i As Integer = 0 To Me.ColumnCount - 1
                tabstring = tabstring & Me.Item(i, Me.CurrentRow.Index).Value & Chr(9)
            Next
            Clipboard.SetText(tabstring)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuCopyColumn_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuCopyColumn.Click
        Try
            Dim tabstring As String = ""
            For i As Integer = 0 To Me.RowCount - 1
                tabstring = tabstring & Me.Item(Me.CurrentCell.ColumnIndex, i).Value & Chr(13)
            Next
            Clipboard.SetText(tabstring)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuCopyAll_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuCopyAll.Click
        Dim selmode As Integer = 0
        Dim multiselect As Boolean = False
        selmode = Me.SelectionMode
        multiselect = Me.MultiSelect
        Me.SelectionMode = DataGridViewSelectionMode.CellSelect
        Me.MultiSelect = True
        Me.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.SelectAll()
        Clipboard.SetDataObject(Me.GetClipboardContent())
        Me.SelectionMode = selmode
        Me.MultiSelect = multiselect
    End Sub

    Private Sub ToolStripMenuExporttoExcel_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuExporttoExcel.Click
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
        For i = 0 To Me.ColumnCount - 1
            xlWorkSheet.Cells(1, i + 1) = Me.Columns(i).Name.ToString
        Next

        For i = 1 To Me.RowCount
            For j = 1 To Me.ColumnCount
                xlWorkSheet.Cells(i + 1, j) = Me(j - 1, i - 1).Value.ToString()
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
    Private Sub ERPList_ColumnHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Me.ColumnHeaderMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(Cursor.Position)
        End If

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

    'Private Sub ToolStripAutoSize_Click(sender As Object, e As System.EventArgs) Handles ToolStripAutoSize.Click
    '    If ToolStripAutoSize.Checked = True Then
    '        Me.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    '        Me.AllowUserToResizeColumns = False
    '        Me.AllowUserToResizeColumns = True
    '    Else
    '        Me.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
    '        Me.AllowUserToResizeColumns = True
    '    End If
    '    Invalidate()
    'End Sub
    Public Function Find(ColName1 As String, findvalue1 As String, Optional ColName2 As String = "", Optional findvalue2 As String = "", Optional ColName3 As String = "", Optional findvalue3 As String = "", Optional ColName4 As String = "", Optional findvalue4 As String = "") As Boolean
        Dim retval As Boolean = False
        If ColName1.Length > 0 And ColName2.Length > 0 And ColName3.Length > 0 And ColName4.Length > 0 Then
            For i As Integer = 0 To Me.Rows.Count - 1
                If Me.Item(ColName1, i).Value = findvalue1 And Me.Item(ColName2, i).Value = findvalue2 And Me.Item(ColName3, i).Value = findvalue3 And Me.Item(ColName4, i).Value = findvalue4 Then
                    retval = True
                    Exit For
                End If
            Next
        ElseIf ColName1.Length > 0 And ColName2.Length > 0 And ColName3.Length > 0 Then
            For i As Integer = 0 To Me.Rows.Count - 1
                If Me.Item(ColName1, i).Value = findvalue1 And Me.Item(ColName2, i).Value = findvalue2 And Me.Item(ColName3, i).Value = findvalue3 Then
                    retval = True
                    Exit For
                End If
            Next
        ElseIf ColName1.Length > 0 And ColName2.Length > 0 Then
            For i As Integer = 0 To Me.Rows.Count - 1
                If Me.Item(ColName1, i).Value = findvalue1 And Me.Item(ColName2, i).Value = findvalue2 Then
                    retval = True
                    Exit For
                End If
            Next
        Else

            For i As Integer = 0 To Me.Rows.Count - 1
                If Me.Item(ColName1, i).Value = findvalue1 Then
                    retval = True
                    Exit For
                End If
            Next
        End If

        Return retval
    End Function

    Private Sub TollStripMenuAutoSize_Click(sender As Object, e As System.EventArgs) Handles TollStripMenuAutoSize.Click
        On Error Resume Next
        For i As Integer = 0 To Me.Columns.Count - 1
            Me.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next
    End Sub
End Class
