Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient

Public Class ImportPriceList
    Dim DbFiledName As String = ""
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Dim opfile As New OpenFileDialog
        '(*.bmp, *.jpg)|*.bmp;*.jpg
        opfile.Filter = "(*.xlsx, *.xls)|*.xlsx;*.xls "
        If opfile.ShowDialog() = DialogResult.OK Then
            ReadData(opfile.FileName)
        End If
    End Sub
    Sub LoadPriceListNames()
        TxtPriceListName.Items.Clear()
        LoadDataIntoComboBox("select  pricelistname from pricelist", TxtPriceListName, "pricelistname")
        TxtPriceListName.Items.Add("Wholesale")
        TxtPriceListName.Items.Add("Retail")
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
        TxtList.Rows.Clear()
        Dim listrowno As Integer
        range = xlWorkSheet.UsedRange

        If IsBarcodeImport.Checked = True Then
            For rowno = 1 To range.Rows.Count

                For colno = 1 To 2
                    Obj = CType(range.Cells(rowno, colno), Excel.Range)
                    Dim TEMPSTR As String = ""
                    TEMPSTR = Trim(Obj.VALUE)
                    If TEMPSTR.Length > 0 Then
                        TEMPSTR = System.Text.RegularExpressions.Regex.Replace(TEMPSTR, "[ ]{2,}", " ")
                    End If


                    If Len(Trim(TEMPSTR)) = 0 Then
                        Exit For
                    End If
                    If colno = 1 Then
                        listrowno = TxtList.Rows.Add
                    End If

                    If colno = 1 Then
                        TxtList.Item(0, rowno - 1).Value = TEMPSTR
                    Else
                        If IsNumeric(TEMPSTR) = True Then
                            TxtList.Item("tprice", rowno - 1).Value = FormatNumber(TEMPSTR, ErpDecimalPlaces, , , TriState.False)
                        End If

                    End If
                Next
            Next
        Else

            For rowno = 1 To range.Rows.Count
                For colno = 2 To 6
                    Obj = CType(range.Cells(rowno, colno), Excel.Range)
                    Dim TEMPSTR As String = ""
                    TEMPSTR = Trim(Obj.VALUE)
                    If TEMPSTR.Length > 0 Then
                        TEMPSTR = System.Text.RegularExpressions.Regex.Replace(TEMPSTR, "[ ]{2,}", " ")
                    End If
                    If colno = 2 Then
                        listrowno = TxtList.Rows.Add
                    End If
                    If colno = 7 Then
                        If IsNumeric(TEMPSTR) = True Then
                            TxtList.Item("tprice", rowno - 1).Value = FormatNumber(TEMPSTR, ErpDecimalPlaces, , , TriState.False)
                        End If

                    Else
                        ' MsgBox(Obj.value)
                        TxtList.Item(colno - 1, rowno - 1).Value = TEMPSTR
                    End If
                Next
            Next
        End If
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
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

    Private Sub ImportPriceList_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub ImportPriceList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadPriceListNames()
        TxtList.Rows.Clear()
    End Sub

    Private Sub IsBarcodeImport_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsBarcodeImport.CheckedChanged
        If IsBarcodeImport.Checked = True Then
            TxtList.Columns("tbarcode").Visible = True
            TxtList.Columns("tstockcode").Visible = False
            TxtList.Columns("tstocksize").Visible = False
            TxtList.Columns("tbatchno").Visible = False
            TxtList.Columns("tlocation").Visible = False
        Else
            TxtList.Columns("tbarcode").Visible = False
            TxtList.Columns("tstockcode").Visible = True
            TxtList.Columns("tstocksize").Visible = True
            TxtList.Columns("tbatchno").Visible = True
            TxtList.Columns("tlocation").Visible = True

        End If
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        If TxtPriceListName.Text.Length = 0 Then
            MsgBox("Please Select the Price List Name to Update...", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtList.Rows.Count = 0 Then
            MsgBox("There are no list to update..., Please selec the excel file....", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtPriceListName.Text = "Wholesale" Then
            DbFiledName = "StockWRP"
        ElseIf TxtPriceListName.Text = "Retail" Then
            DbFiledName = "StockDRP"
        Else
            DbFiledName = TxtPriceListName.Text
        End If
        Dim count As Integer = 0
        If MsgBox(" Do you want to update the price list to """ & TxtPriceListName.Text & """?       ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            For rowno As Integer = 0 To TxtList.RowCount - 1
                If IsBarcodeImport.Checked = True Then
                    If IsCustomBarCode = True Then
                        If SQLIsFieldExists("select  stockcode from stockdbf where custbarcode=N'" & TxtList.Item("tbarcode", rowno).Value & "'") = True Then
                            ExecuteSQLQuery("update stockdbf set " & DbFiledName & "=" & CDbl(TxtList.Item("tPrice", rowno).Value) & " where  custbarcode=N'" & TxtList.Item("tbarcode", rowno).Value & "'")
                            TxtList.Rows(rowno).DefaultCellStyle.BackColor = Color.LightGreen
                            count = count + 1
                        Else
                            TxtList.Rows(rowno).DefaultCellStyle.BackColor = Color.Red
                        End If
                    Else
                        If SQLIsFieldExists("select  stockcode from stockdbf where barcode=N'" & TxtList.Item("tbarcode", rowno).Value & "'") = True Then
                            ExecuteSQLQuery("update stockdbf set " & DbFiledName & "=" & CDbl(TxtList.Item("tPrice", rowno).Value) & " where  barcode=N'" & TxtList.Item("tbarcode", rowno).Value & "'")
                            TxtList.Rows(rowno).DefaultCellStyle.BackColor = Color.LightGreen
                            count = count + 1
                        Else
                            TxtList.Rows(rowno).DefaultCellStyle.BackColor = Color.Red
                        End If

                    End If

                Else
                    If Len(TxtList.Item("tStockCode", rowno).Value) > 0 Then
                        If SQLIsFieldExists("select  stockcode from stockdbf where stockcode=N'" & TxtList.Item("tStockCode", rowno).Value & "' and stocksize=N'" & TxtList.Item("tStockSize", rowno).Value & "' and batchno=N'" & TxtList.Item("tbatchno", rowno).Value & "'") = True Then
                            ExecuteSQLQuery("update stockdbf set " & DbFiledName & "=" & CDbl(TxtList.Item("tPrice", rowno).Value) & " where stockcode=N'" & TxtList.Item("tStockCode", rowno).Value & "' and stocksize=N'" & TxtList.Item("tStockSize", rowno).Value & "' and batchno=N'" & TxtList.Item("tbatchno", rowno).Value & "'")
                            TxtList.Rows(rowno).DefaultCellStyle.BackColor = Color.LightGreen
                            count = count + 1
                        Else
                            TxtList.Rows(rowno).DefaultCellStyle.BackColor = Color.Red
                        End If
                    End If

                End If
            Next
            MsgBox(count.ToString & " Rows are Updated ..... ", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        Me.Close()
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click
        ExportToExecl()
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
        Dim cnn As SqlConnection
        Dim sql As String
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
        sql = "SELECT barcode,location, stockcode,stocksize,batchno FROM stockdbf"
        Dim dscmd As New SqlDataAdapter(sql, cnn)
        Dim ds As New DataSet
        dscmd.Fill(ds)

        For i = 0 To ds.Tables(0).Rows.Count - 1
            For j = 0 To ds.Tables(0).Columns.Count - 1
                xlWorkSheet.Cells(i + 1, j + 1) = _
                ds.Tables(0).Rows(i).Item(j)
            Next
        Next

        xlWorkSheet.SaveAs(xlFileName)
        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

        cnn.Close()
    End Sub
End Class