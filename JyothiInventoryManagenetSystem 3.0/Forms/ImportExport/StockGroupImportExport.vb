Imports Microsoft.Office.Interop

Public Class StockGroupImportExport
    Dim ExSqlstr As String = ""
    Sub LoadExportList()

        ExSqlstr = "SELECT STOCKGROUPNAME AS [Group Name],grouproot as [Under Group] from stockgroups"

        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(ExSqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("Group Name").Width = 220
            TxtList.Columns("Under Name").Width = 220
        Catch ex As Exception

        End Try
    End Sub

    Private Sub StockGroupImportExport_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub EmployeeImportAndExport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadExportList()
        For i As Integer = 0 To TxtList.ColumnCount - 1
            TxtIList.Columns.Add(TxtList.Columns(i).HeaderText, TxtList.Columns(i).HeaderText)
            TxtIList.Columns(TxtList.Columns(i).HeaderText).Width = 220

        Next
        
    End Sub

    Private Sub TxtDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadExportList()
    End Sub
    Sub ExportToExecl()
        Dim sdlg As New SaveFileDialog
        Dim xlFileName As String = ""
        sdlg.Filter = "(*.xlsx, *.xls)|*.xlsx;*.xls "
        If sdlg.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If
        xlFileName = sdlg.FileName
        If xlFileName.Length = 0 Then Exit Sub

        Dim i, j As Integer
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")


        If IsWithHeadings.Checked = True Then
            For c As Integer = 0 To TxtList.ColumnCount - 1
                xlWorkSheet.Cells(1, c + 1) = TxtList.Columns(c).HeaderText
            Next

            For i = 1 To TxtList.Rows.Count
                For j = 0 To TxtList.Columns.Count - 1
                    xlWorkSheet.Cells(i + 1, j + 1) = TxtList.Item(j, i - 1).Value
                Next
            Next
        Else

            For i = 0 To TxtList.Rows.Count - 1
                For j = 0 To TxtList.Columns.Count - 1
                    xlWorkSheet.Cells(i + 1, j + 1) = TxtList.Item(j, i).Value
                Next
            Next
        End If


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

    Private Sub BtnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        ExportToExecl()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Dim sdlg As New SaveFileDialog
        Dim xlFileName As String = ""
        sdlg.Filter = "(*.xlsx, *.xls)|*.xlsx;*.xls "
        If sdlg.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If
        xlFileName = sdlg.FileName
        If xlFileName.Length = 0 Then Exit Sub


        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")


        For c As Integer = 0 To TxtList.ColumnCount - 1
            xlWorkSheet.Cells(1, c + 1) = TxtList.Columns(c).HeaderText
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

    Private Sub BtnImportBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImportBrowse.Click
        Dim opfile As New OpenFileDialog
        '(*.bmp, *.jpg)|*.bmp;*.jpg
        opfile.Filter = "(*.xlsx, *.xls)|*.xlsx;*.xls "
        If opfile.ShowDialog() = DialogResult.OK Then
            ReadData(opfile.FileName)
        End If
        If TxtIList.Rows.Count = 0 Then
            MsgBox("There are no items to Import....", MsgBoxStyle.Information)

        End If
    End Sub
    Sub ReadData(ByVal filename As String)
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim range As Excel.Range
        Dim rowno As Integer
        My.Application.DoEvents()
        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(filename)
        xlWorkSheet = xlWorkBook.Worksheets("sheet1")
        TxtIList.Rows.Clear()
        Dim listrowno As Integer = 0
        range = xlWorkSheet.UsedRange
        TxtIList.Rows.Clear()
        Dim rn As Integer = 0
        For rowno = 1 To range.Rows.Count
            If Len(CType(range.Cells(rowno, 2), Excel.Range).Value) = 0 Then GoTo NextRow
            Try


                If CType(range.Cells(rowno, 1), Excel.Range).Value <> Nothing Then
                    rn = TxtIList.Rows.Add()
                    TxtIList.Item("Group Name", rn).Value = StrConv(Trim(CType(range.Cells(rowno, 1), Excel.Range).Value.ToString), VbStrConv.ProperCase)
                    If CType(range.Cells(rowno, 2), Excel.Range).Value = Nothing Then
                        TxtIList.Item("Under Group", rn).Value = "*Primary"
                    Else
                        TxtIList.Item("Under Group", rn).Value = StrConv(Trim(CType(range.Cells(rowno, 2), Excel.Range).Value.ToString), VbStrConv.ProperCase)
                    End If

                End If

            Catch ex As Exception
                MsgBox(ex.Message & " Invalid Columns of Data..... ")
                If MsgBox("Do you want to continue...              ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    GoTo EndPoint
                End If

            End Try


NextRow:
        Next
EndPoint:
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

    End Sub
    Sub SaveData()
        
        Dim TxtStockGroupName As String = ""
        Dim TxtunderGroup As String = ""
        Dim txtempID As String = ""
        Dim EmpName As String = ""
        For i As Integer = 0 To TxtIList.Rows.Count - 1
            Dim IsCreated As Boolean = False
            TxtStockGroupName = TxtIList.Item("Group Name", i).Value
            TxtunderGroup = TxtIList.Item("Under Group", i).Value
            If UCase(TxtStockGroupName) = "*PRIMARY" Then
                GoTo NextRowLbl
            End If
            If TxtunderGroup.Length = 0 Then
                GoTo NextRowLbl
            End If
            If SQLIsFieldExists("select StockgroupNameTemp from stockgroups where StockgroupNameTemp=N'" & Replace(TxtStockGroupName, " ", "").ToString & "'") = True Then
                GoTo NextRowLbl
            End If

            If SQLIsFieldExists("select StockgroupNameTemp from stockgroups where StockgroupNameTemp=N'" & TxtunderGroup & "'") = False Then
                If SQLIsFieldExists("select StockgroupNameTemp from stockgroups where StockgroupNameTemp=N'" & Replace(TxtunderGroup, " ", "").ToString & "'") = False Then
                    GoTo NextRowLbl
                Else
                    TxtunderGroup = Replace(TxtunderGroup, " ", "").ToString()
                End If
            End If

            Dim SqlStr As String = ""
            Dim glevel As Integer = 0
            glevel = SQLGetNumericFieldValue("select grouplevel from stockgroups where StockgroupNameTemp=N'" & Replace(TxtunderGroup, " ", "").ToString & "'", "grouplevel")

            SqlStr = "INSERT INTO [stockgroups] ([StockgroupName],[StockgroupNameTemp],[groupRoot],[grouplevel]) " _
                & "VALUES(N'" & TxtStockGroupName & "',N'" & Replace(TxtStockGroupName, " ", "").ToString & "',N'" & TxtunderGroup & "'," & glevel + 1 & ")"
            ExecuteSQLQuery(SqlStr)

            IsCreated = True
NextRowLbl:
            If IsCreated = False Then
                TxtIList.Rows(i).DefaultCellStyle.BackColor = Color.IndianRed
            Else
                TxtIList.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            End If
        Next

        ReArrangeStockGroups()


    End Sub
   

    Private Sub BtnImportUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImportUpdate.Click
        If MsgBox("Do you want to update ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            SaveData()
        End If
    End Sub
End Class