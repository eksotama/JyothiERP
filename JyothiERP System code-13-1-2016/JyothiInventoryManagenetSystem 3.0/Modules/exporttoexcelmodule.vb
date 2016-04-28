Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient
Module exporttoexcelmodule
    Public Sub ExportDataGridToExcel(ByVal txtIlist As DataGridView, ByVal txttitle As String)
        Dim sdlg As New SaveFileDialog
        Dim xlFileName As String = ""
        sdlg.Filter = "(*.xlsx, *.xls)|*.xlsx;*.xls "
        If sdlg.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If
        xlFileName = sdlg.FileName
        If xlFileName.Length = 0 Then Exit Sub
        Dim i As Integer
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")
        Dim Rowno As Integer = 0
        Dim ColNo As Integer = 0

        For i = 1 To txtIlist.ColumnCount
            If txtIlist.Columns(i - 1).Visible = True Then
                ColNo = ColNo + 1
                xlWorkSheet.Cells(4, ColNo) = txtIlist.Columns(i - 1).HeaderText
                xlWorkSheet.Cells(4, ColNo).EntireColumn.ColumnWidth = 20
                xlWorkSheet.Cells(4, ColNo).Font.Name = txtIlist.ColumnHeadersDefaultCellStyle.Font.Name
                xlWorkSheet.Cells(4, ColNo).Font.Bold = True
                xlWorkSheet.Cells(4, ColNo).Font.Size = txtIlist.ColumnHeadersDefaultCellStyle.Font.Size
                xlWorkSheet.Cells(4, ColNo).BorderAround(Excel.XlLineStyle.xlContinuous)
                xlWorkSheet.Cells(4, ColNo).Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Aqua)
                xlWorkSheet.Columns(ColNo).ColumnWidth = txtIlist.Columns(i - 1).Width / 7
                xlWorkSheet.Cells(4, ColNo).WrapText = True
                xlWorkSheet.Rows(4).RowHeight = 26
            End If

        Next
        'PRINT COMPANY NAME
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, ColNo)).Merge()
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, ColNo)).Font.Size = 13
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, ColNo)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        xlWorkSheet.Rows(1).RowHeight = 26
        xlWorkSheet.Cells(1, 1).Font.Bold = True
        xlWorkSheet.Cells(1, 1) = CompDetails.CompanyName

        'PRINT ADDRESS LINT
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, ColNo)).Merge()
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, ColNo)).Font.Size = 13
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, ColNo)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        xlWorkSheet.Rows(2).RowHeight = 26
        xlWorkSheet.Cells(2, 1).Font.Bold = True
        xlWorkSheet.Cells(2, 1) = CompDetails.Companyaddresspoboxno

        'PRINTING TITLE
        xlWorkSheet.Range(xlWorkSheet.Cells(3, 1), xlWorkSheet.Cells(3, ColNo)).Merge()
        xlWorkSheet.Range(xlWorkSheet.Cells(3, 1), xlWorkSheet.Cells(3, ColNo)).Font.Size = 13
        xlWorkSheet.Range(xlWorkSheet.Cells(3, 1), xlWorkSheet.Cells(3, ColNo)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        xlWorkSheet.Rows(3).RowHeight = 26
        xlWorkSheet.Cells(3, 1).Font.Bold = True
        xlWorkSheet.Cells(3, 1) = txttitle

        Rowno = 4
        ColNo = 0
        For i = 0 To txtIlist.Rows.Count - 1
            If txtIlist.Rows(i).Visible = True Then
                Rowno = Rowno + 1
                ColNo = 0
                For j = 0 To txtIlist.Columns.Count - 1
                    If txtIlist.Columns(j).Visible = True Then
                        ColNo = ColNo + 1
                        xlWorkSheet.Cells(Rowno, ColNo) = txtIlist.Item(j, i).FormattedValue   ' ds.Tables(0).Rows(i - 1).Item(j)

                        xlWorkSheet.Cells(Rowno, ColNo).BorderAround(Excel.XlLineStyle.xlContinuous)

                    End If
                Next

            End If

        Next

        xlWorkSheet.SaveAs(xlFileName)
        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

        Try
            Process.Start(xlFileName)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
End Module
