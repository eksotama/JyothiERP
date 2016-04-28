Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient
Public Class StockUnitImportExport
    Dim SqlStrExprot As String = ""
    Sub loadstockUnits(Optional ByVal WhereSqlStr As String = "")

        SqlStrExprot = "SELECT unitname as [Unit Name],MainUnitName as [Main Unit], subunitname as [Sub Unit], unitconversion as [Converion],formalname as [Formal Name],decimals as [No Of Decimal] from stockunits "
        SqlStrExprot = SqlStrExprot & WhereSqlStr
        Dim TempBS As New BindingSource
        With Me.TxtListE
            TempBS.DataSource = SQLLoadGridData(SqlStrExprot)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
    End Sub
    Private Sub TxtListE_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtListE.DataError

    End Sub
    Private Sub TxtListI_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtListI.DataError

    End Sub
    Sub ReadData(ByVal filename As String)
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim range As Excel.Range
        Dim rowno As Integer
        Dim colno As Integer
        Dim Obj As Object
        My.Application.DoEvents()
        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(filename)
        xlWorkSheet = xlWorkBook.Worksheets("sheet1")
        TxtListI.Rows.Clear()
        Dim listrowno As Integer
        range = xlWorkSheet.UsedRange

        For rowno = 1 To range.Rows.Count
            For colno = 1 To 5
                Obj = CType(range.Cells(rowno, colno), Excel.Range)
                Dim TEMPSTR As String = ""
                TEMPSTR = Trim(Obj.VALUE)
                If TEMPSTR.Length > 0 Then
                    TEMPSTR = System.Text.RegularExpressions.Regex.Replace(TEMPSTR, "[ ]{2,}", " ")
                End If
                '  Obj.value = System.Text.RegularExpressions.Regex.Replace(Obj.value.ToString, "[ ]{2,}", " ")
                If colno = 1 Then
                    If Len(Trim(TEMPSTR)) = 0 Then
                        Exit For
                    End If
                    listrowno = TxtListI.Rows.Add
                End If
                If colno = 3 Or colno = 4 Then
                    If IsNumeric(TEMPSTR) = True Then
                        TxtListI.Item(colno - 1, rowno - 1).Value = FormatNumber(TEMPSTR, 2)
                    End If
                Else
                    TxtListI.Item(colno - 1, rowno - 1).Value = TEMPSTR
                End If
            Next
        Next
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub
    Sub ExportToExecl()
        If SqlStrExprot.Length = 0 Then
            MsgBox("Please Filter the Stock Items....", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim sdlg As New SaveFileDialog
        Dim xlFileName As String = ""
        sdlg.Filter = "(*.xlsx, *.xls)|*.xlsx;*.xls "
        If sdlg.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If
        xlFileName = sdlg.FileName
        If xlFileName.Length = 0 Then Exit Sub
        Dim cnn As SqlConnection
        Dim i, j As Integer
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")

        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()

        Dim dscmd As New SqlDataAdapter(SqlStrExprot, cnn)
        Dim ds As New DataSet
        dscmd.Fill(ds)
        If IsWithHeadings.Checked = True Then
            For c As Integer = 0 To TxtListE.ColumnCount - 1
                xlWorkSheet.Cells(1, c + 1) = TxtListE.Columns(c).HeaderText
            Next

            For i = 1 To ds.Tables(0).Rows.Count
                For j = 0 To ds.Tables(0).Columns.Count - 1
                    xlWorkSheet.Cells(i + 1, j + 1) = ds.Tables(0).Rows(i - 1).Item(j)

                Next
            Next
        Else

            For i = 0 To ds.Tables(0).Rows.Count - 1
                For j = 0 To ds.Tables(0).Columns.Count - 1
                    xlWorkSheet.Cells(i + 1, j + 1) = _
                    ds.Tables(0).Rows(i).Item(j)
                Next
            Next
        End If


        xlWorkSheet.SaveAs(xlFileName)
        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

        cnn.Close()
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

    Private Sub StockUnitImportExport_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub StockUnitImportExport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loadstockUnits()
    End Sub

    Private Sub BtnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        ExportToExecl()
    End Sub

    Private Sub BtnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImport.Click
        Dim opfile As New OpenFileDialog
        '(*.bmp, *.jpg)|*.bmp;*.jpg
        opfile.Filter = "(*.xlsx, *.xls)|*.xlsx;*.xls "
        If opfile.ShowDialog() = DialogResult.OK Then
            ReadData(opfile.FileName)
        End If
    End Sub

    
    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        If TxtListI.RowCount = 0 Then Exit Sub
        If MsgBox("Do you want to import the list ? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim mainunitname As String = ""
        Dim subunitname As String = ""
        Dim isSimpleunit As Boolean = False
        Dim Conversion As Double = 1
        Dim FormalName As String = ""
        Dim decimals As Integer = 2
        Dim issuccess As Boolean = False
        For i As Integer = 0 To TxtListI.RowCount - 1
            issuccess = False
            mainunitname = Trim(TxtListI.Item("tmainunit", i).Value)
            subunitname = Trim(TxtListI.Item("tsubunit", i).Value)
            If IsNumeric(Trim(TxtListI.Item("tcon", i).Value)) = True Then
                Conversion = CInt(Trim(TxtListI.Item("tcon", i).Value))
            Else
                Conversion = 1
            End If

            If IsNumeric(Trim(TxtListI.Item("tdecimals", i).Value)) = True Then
                decimals = CInt(Trim(TxtListI.Item("tcon", i).Value))
            Else
                decimals = 2
            End If
            Dim SqlStr As String = ""
            FormalName = Trim(TxtListI.Item("tname", i).Value)
            If mainunitname.Length > 0 And subunitname.Length > 0 Then
                If SQLIsFieldExists("SELECT TOP 1 1 from   Stockunits where unitname=N'" & mainunitname & " Of " & Conversion.ToString & " " & subunitname & "'") = False Then
                    If Conversion > 1 Then
                        If SQLIsFieldExists("SELECT TOP 1 1 from   stockunits where unitname=N'" & mainunitname & "'") = False Then

                            SqlStr = "INSERT INTO [Stockunits]([UnitName],[MainUnitName],[SubUnitName],[UnitConversion],[UnitType],[formalname],[Decimals]) " _
                                & "VALUES(N'" & mainunitname & "', '','',1,0,N'" & FormalName & "'," & decimals & ")"
                            ExecuteSQLQuery(SqlStr)

                        End If

                        If SQLIsFieldExists("SELECT TOP 1 1 from   stockunits where unitname=N'" & subunitname & "'") = False Then

                            SqlStr = "INSERT INTO [Stockunits]([UnitName],[MainUnitName],[SubUnitName],[UnitConversion],[UnitType],[formalname],[Decimals]) " _
                                & "VALUES(N'" & subunitname & "', '','',1,0,N'" & FormalName & "'," & decimals & ")"
                            ExecuteSQLQuery(SqlStr)

                        End If
                        Dim unitstr As String
                        unitstr = mainunitname & " Of " & Conversion.ToString & " " & subunitname

                        SqlStr = "INSERT INTO [Stockunits]([UnitName],[MainUnitName],[SubUnitName],[UnitConversion],[UnitType],[formalname],[Decimals]) " _
                            & "VALUES(N'" & unitstr & "', N'" & mainunitname & "',N'" & subunitname & "'," & Conversion & ",1,'',2)"
                        ExecuteSQLQuery(SqlStr)
                        issuccess = True
                    End If
                End If

            Else
                If mainunitname.Length > 0 Then
                    If SQLIsFieldExists("SELECT TOP 1 1 from   stockunits where unitname=N'" & mainunitname & "'") = False Then
                        SqlStr = "INSERT INTO [Stockunits]([UnitName],[MainUnitName],[SubUnitName],[UnitConversion],[UnitType],[formalname],[Decimals]) " _
                        & "VALUES(N'" & mainunitname & "', '','',1,0,N'" & FormalName & "'," & decimals & ")"
                        ExecuteSQLQuery(SqlStr)
                        issuccess = True
                    End If
                End If

            End If
            If issuccess = True Then
                TxtListI.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            Else
                TxtListI.Rows(i).DefaultCellStyle.BackColor = Color.IndianRed
            End If

        Next


    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class