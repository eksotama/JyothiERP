Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient
Public Class StockItemsImportExport
    Dim SqlStrExprot As String = ""
    Dim stvalues As New ChooseItemClass
    Dim TempStvalues As New ChooseItemClass
    Dim ErrorLineNumber As Long = 1
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
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Private Sub TxtIList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtIList.DataError

    End Sub
    Sub loadstockitems(Optional ByVal WhereSqlStr As String = "")

        'If MyAppSettings.IsCustomBarcode = True Then
        '    If IsShowCurrentQty.Checked = True Then
        '        SqlStrExprot = "SELECT location,barcode,stockgroup,stockname,stockcode,stocksize,batchno,expiry,totalqty as [current qty],brand,company as [madeby],description,hscode,baseunit ,mainunit,subunit,unitcon as [unit conversion],optotalqty as [opening qty],stockrate,stockwrp,stockdrp, tax as [Tax],minqty,stockimagepath as [image location] FROM [StockDbf] "
        '    Else
        '        SqlStrExprot = "SELECT location,barcode,stockgroup,stockname,stockcode,stocksize,batchno,expiry,brand,company as [madeby],description,hscode,baseunit,mainunit,subunit,unitcon as [unit conversion],optotalqty as [opening qty],stockrate,stockwrp,stockdrp, tax as [Tax],minqty,stockimagepath as [image location] FROM [StockDbf] "
        '    End If

        'Else
        '    If IsShowCurrentQty.Checked = True Then
        '        SqlStrExprot = "SELECT location,barcode,stockgroup,stockname,stockcode,stocksize,batchno,expiry,totalqty as [current qty],brand,company as [madeby],description,hscode,baseunit,mainunit,subunit,unitcon as [unit conversion],optotalqty as [opening qty],stockrate,stockwrp,stockdrp, tax as [Tax],minqty,stockimagepath as [image location] FROM [StockDbf] "
        '    Else
        '        SqlStrExprot = "SELECT location,barcode,stockgroup,stockname,stockcode,stocksize,batchno,expiry,brand,company as [madeby],description,hscode,baseunit,mainunit,subunit,unitcon as [unit conversion],optotalqty as [opening qty],stockrate,stockwrp,stockdrp, tax as [Tax],minqty,stockimagepath as [image location] FROM [StockDbf] "
        '    End If

        'End If
        If IsShowCurrentQty.Checked = True Then
            SqlStrExprot = "SELECT location,custbarcode as [barcode],stockgroup,stockname,stockcode,stocksize,batchno,expiry,totalqty as [current qty],brand,company as [madeby],description,hscode,baseunit ,mainunit,subunit,unitcon as [unit conversion],optotalqty as [opening qty],stockrate,stockwrp,stockdrp, tax as [Tax],minqty,stockimagepath as [image location] FROM [StockDbf] "
        Else
            SqlStrExprot = "SELECT location,custbarcode as [barcode],stockgroup,stockname,stockcode,stocksize,batchno,expiry,brand,company as [madeby],description,hscode,baseunit,mainunit,subunit,unitcon as [unit conversion],optotalqty as [opening qty],stockrate,stockwrp,stockdrp, tax as [Tax],minqty,stockimagepath as [image location] FROM [StockDbf] "
        End If
        SqlStrExprot = SqlStrExprot & WhereSqlStr
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStrExprot)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
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

    Private Sub BtnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        ExportToExecl()
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
    Private Sub IsShowCurrentQty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsShowCurrentQty.CheckedChanged
        loadstockitems()
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
            For c As Integer = 0 To TxtList.ColumnCount - 1
                xlWorkSheet.Cells(1, c + 1) = TxtList.Columns(c).HeaderText
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
        Try
            Process.Start(xlFileName)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImportUpdate.Click

        If MsgBox("Please Confirm the Stock List is correct format or not in the List shown, Do You want to Procced  ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        If MsgBox("Do you want to Import into the Stock Items?   ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            TxtErrorBox.Text = ""
            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            txtStatus.Text = " 0 of " & TxtIList.RowCount & " Items are UPDATED..."
            SaveStockItems()
            ReArrangeStockGroups()
            Me.Cursor = Cursors.Default
            BtnError.Visible = True
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
        stvalues.ClearData()
        Dim listrowno As Integer = 0
        range = xlWorkSheet.UsedRange
        Dim imgPath As String = ""

        For rowno = 2 To range.Rows.Count
            If Len(CType(range.Cells(rowno, 1), Excel.Range).Value) = 0 Then GoTo EndPoint
            Try
                stvalues.StockLocation = CType(range.Cells(rowno, 1), Excel.Range).Value
                stvalues.StockItemBarCode = CType(range.Cells(rowno, 2), Excel.Range).Value
                stvalues.CustBarCode = CType(range.Cells(rowno, 2), Excel.Range).Value
                stvalues.StockGroup = CType(range.Cells(rowno, 3), Excel.Range).Value
                stvalues.StockItemName = CType(range.Cells(rowno, 4), Excel.Range).Value
                stvalues.StockItemCode = CType(range.Cells(rowno, 5), Excel.Range).Value
                stvalues.StockITemSize = CType(range.Cells(rowno, 6), Excel.Range).Value
                stvalues.StockBatchNo = CType(range.Cells(rowno, 7), Excel.Range).Value
                If UCase(stvalues.StockBatchNo) = "YES" Then
                Else
                    stvalues.StockBatchNo = "No"
                End If
                stvalues.Tax = IIf(IsNumeric(CType(range.Cells(rowno, 17), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 17), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 17), Excel.Range).Value), 0), 0)
                stvalues.Brand = CType(range.Cells(rowno, 8), Excel.Range).Value
                stvalues.Madeby = CType(range.Cells(rowno, 9), Excel.Range).Value
                stvalues.StockITemDescription = CType(range.Cells(rowno, 10), Excel.Range).Value
                stvalues.HScode = CType(range.Cells(rowno, 11), Excel.Range).Value
                stvalues.StockUnitName = CType(range.Cells(rowno, 12), Excel.Range).Value
                stvalues.OpStockQty = IIf(IsNumeric(CType(range.Cells(rowno, 13), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 13), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 13), Excel.Range).Value), 0), 0)
                If IsIncludingTax.Text = "Including Tax" Then
                    stvalues.StockRate = IIf(IsNumeric(CType(range.Cells(rowno, 14), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 14), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 14), Excel.Range).Value), 0), 0)
                    stvalues.StockRate = stvalues.StockRate * 100 / (stvalues.Tax + 100)
                Else
                    stvalues.StockRate = IIf(IsNumeric(CType(range.Cells(rowno, 14), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 14), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 14), Excel.Range).Value), 0), 0)
                End If

                '
                If IsSalesIncludingTax.Text = "Including Tax" Then
                    stvalues.StockWRPRate = IIf(IsNumeric(CType(range.Cells(rowno, 15), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 15), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 15), Excel.Range).Value), 0), 0)
                    stvalues.StockRRPRate = IIf(IsNumeric(CType(range.Cells(rowno, 16), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 16), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 16), Excel.Range).Value), 0), 0)
                    stvalues.StockWRPRate = stvalues.StockWRPRate * 100 / (stvalues.Tax + 100)
                    stvalues.StockRRPRate = stvalues.StockRRPRate * 100 / (stvalues.Tax + 100)
                Else
                    stvalues.StockWRPRate = IIf(IsNumeric(CType(range.Cells(rowno, 15), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 15), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 15), Excel.Range).Value), 0), 0)
                    stvalues.StockRRPRate = IIf(IsNumeric(CType(range.Cells(rowno, 16), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 16), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 16), Excel.Range).Value), 0), 0)

                End If
             
                stvalues.MinQty = IIf(IsNumeric(CType(range.Cells(rowno, 18), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 18), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 18), Excel.Range).Value), 0), 0)
                imgPath = CType(range.Cells(rowno, 19), Excel.Range).Value
                stvalues.MRP = IIf(IsNumeric(CType(range.Cells(rowno, 20), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 20), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 20), Excel.Range).Value), 0), 0)
                If stvalues.StockItemCode.Length = 0 Then GoTo NextRow
                If stvalues.StockItemName.Length = 0 Then GoTo NextRow
                If stvalues.StockUnitName.Length = 0 Then GoTo NextRow
                stvalues.TxtQtyBOX.ClearQty()
                stvalues.TxtOpQtyBOX.ClearQty()

                If SQLIsFieldExists("select unitname from stockunits where unitname=N'" & stvalues.StockUnitName & "'") = True Then

                    If SQLIsFieldExists("select stockname from  StockDbf where location=N'" & stvalues.StockLocation & "' and stockcode=N'" & stvalues.StockItemCode & "' and stocksize=N'" & stvalues.StockITemSize & "' and batchno=N'" & stvalues.StockBatchNo & "'") = False Then
                        stvalues.IsSimpleUnit = SQLGetNumericFieldValue("select unittype from stockunits where unitname=N'" & stvalues.StockUnitName & "'", "unittype")
                        If stvalues.IsSimpleUnit = 1 Then
                            stvalues.StockMainUnitName = SQLGetStringFieldValue("select mainunitname from stockunits where unitname=N'" & stvalues.StockUnitName & "'", "mainunitname")
                            stvalues.StockSubUnitName = SQLGetStringFieldValue("select subunitname from stockunits where unitname=N'" & stvalues.StockUnitName & "'", "subunitname")
                        Else
                            stvalues.StockMainUnitName = stvalues.StockUnitName
                            stvalues.StockSubUnitName = ""
                        End If
                        stvalues.TxtOpQtyBOX.SetUnitName(stvalues.StockUnitName)
                        stvalues.TxtOpQtyBOX.SetTotalQty(stvalues.OpStockQty)
                        If SQLIsFieldExists("select stockgroupname from stockgroups where stockgroupname=N'" & stvalues.StockGroup & "'") = False Then
                            If IsCreateStockGroups.Checked = False Then
                                stvalues.StockGroup = "*Primary"
                            End If

                        End If
                        LoadDataIntoList()
                        txtStatus.Text = TxtIList.RowCount & " Items are loaded..."
                        TxtIList.FirstDisplayedCell = TxtIList.Item(0, TxtIList.RowCount - 1)
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
    Sub LoadDataIntoList()
        Dim TxtBarcode As String = ""
        Dim SqlStr As String = ""
        Dim rno As Integer = 0
        rno = TxtIList.Rows.Add
        TxtIList.Item("tlocation", rno).Value = stvalues.StockLocation
        TxtIList.Item("tbarcode", rno).Value = stvalues.CustBarCode
        TxtIList.Item("tstockgroup", rno).Value = stvalues.StockGroup
        TxtIList.Item("tstockname", rno).Value = stvalues.StockItemName
        TxtIList.Item("tstockcode", rno).Value = stvalues.StockItemCode
        TxtIList.Item("tstocksize", rno).Value = stvalues.StockITemSize
        TxtIList.Item("tbatchno", rno).Value = stvalues.StockBatchNo
        TxtIList.Item("tbrand", rno).Value = stvalues.Brand
        TxtIList.Item("tmadeby", rno).Value = stvalues.Madeby
        TxtIList.Item("tdes", rno).Value = stvalues.StockITemDescription
        TxtIList.Item("thscode", rno).Value = stvalues.HScode
        TxtIList.Item("tunitname", rno).Value = stvalues.StockUnitName
        TxtIList.Item("topqty", rno).Value = stvalues.OpStockQty
        TxtIList.Item("tstockrate", rno).Value = stvalues.StockRate
        TxtIList.Item("twrp", rno).Value = stvalues.StockWRPRate
        TxtIList.Item("tdrp", rno).Value = stvalues.StockRRPRate
        TxtIList.Item("ttax", rno).Value = stvalues.Tax
        TxtIList.Item("tminqty", rno).Value = stvalues.MinQty
        TxtIList.Item("timagepath", rno).Value = stvalues.ImagePath
        TxtIList.Item("tmrp", rno).Value = stvalues.MRP
    End Sub

    Sub SaveData(ByVal filename As String)
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim range As Excel.Range
        Dim rowno As Integer
        My.Application.DoEvents()
        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(filename)
        xlWorkSheet = xlWorkBook.Worksheets("sheet1")
        Dim listrowno As Integer = 0
        range = xlWorkSheet.UsedRange
        Dim imgPath As String = ""
        stvalues.ClearData()
        For rowno = 1 To range.Rows.Count
            stvalues.StockLocation = CType(range.Cells(rowno, 1), Excel.Range).Value
            stvalues.StockItemBarCode = CType(range.Cells(rowno, 2), Excel.Range).Value
            stvalues.CustBarCode = CType(range.Cells(rowno, 2), Excel.Range).Value
            stvalues.StockGroup = CType(range.Cells(rowno, 3), Excel.Range).Value
            stvalues.StockItemName = CType(range.Cells(rowno, 4), Excel.Range).Value
            stvalues.StockItemCode = CType(range.Cells(rowno, 5), Excel.Range).Value
            stvalues.StockITemSize = CType(range.Cells(rowno, 6), Excel.Range).Value
            stvalues.StockBatchNo = CType(range.Cells(rowno, 7), Excel.Range).Value


            stvalues.Brand = CType(range.Cells(rowno, 8), Excel.Range).Value
            stvalues.Madeby = CType(range.Cells(rowno, 9), Excel.Range).Value
            stvalues.StockITemDescription = CType(range.Cells(rowno, 10), Excel.Range).Value
            stvalues.HScode = CType(range.Cells(rowno, 11), Excel.Range).Value
            stvalues.StockUnitName = CType(range.Cells(rowno, 12), Excel.Range).Value
            stvalues.OpStockQty = IIf(IsNumeric(CType(range.Cells(rowno, 13), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 13), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 13), Excel.Range).Value), 0), 0)
            stvalues.StockRate = IIf(IsNumeric(CType(range.Cells(rowno, 14), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 14), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 14), Excel.Range).Value), 0), 0)
            stvalues.StockWRPRate = IIf(IsNumeric(CType(range.Cells(rowno, 15), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 15), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 15), Excel.Range).Value), 0), 0)
            stvalues.StockRRPRate = IIf(IsNumeric(CType(range.Cells(rowno, 16), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 16), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 16), Excel.Range).Value), 0), 0)
            stvalues.Tax = IIf(IsNumeric(CType(range.Cells(rowno, 17), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 17), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 17), Excel.Range).Value), 0), 0)
            stvalues.MinQty = IIf(IsNumeric(CType(range.Cells(rowno, 18), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 18), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 18), Excel.Range).Value), 0), 0)
            imgPath = CType(range.Cells(rowno, 19), Excel.Range).Value
            If stvalues.StockItemCode.Length = 0 Then GoTo NextRow
            If stvalues.StockItemName.Length = 0 Then GoTo NextRow
            If stvalues.StockUnitName.Length = 0 Then GoTo NextRow

            stvalues.TxtOpQtyBOX.ClearQty()
            If SQLIsFieldExists("select unitname from stockunits where unitname=N'" & stvalues.StockUnitName & "'") = True Then
                If stvalues.CustBarCode.Length > 0 Then
                    If SQLIsFieldExists("select stockname from stockdbf where custbarcode=N'" & stvalues.CustBarCode & "'") = True Then
                        GoTo NextRow
                    End If
                End If
                If SQLIsFieldExists("select stockname from  StockDbf where location=N'" & stvalues.StockLocation & "' and stockcode=N'" & stvalues.StockItemCode & "' and stocksize=N'" & stvalues.StockITemSize & "'") = False Then
                    stvalues.IsSimpleUnit = SQLGetNumericFieldValue("select unittype from stockunits where unitname=N'" & stvalues.StockUnitName & "'", "unittype")
                    stvalues.TxtOpQtyBOX.SetUnitName(stvalues.StockUnitName)
                    stvalues.TxtOpQtyBOX.SetTotalQty(stvalues.OpStockQty)
                    If stvalues.IsSimpleUnit = 1 Then
                        stvalues.StockMainUnitName = SQLGetStringFieldValue("select mainunitname from stockunits where unitname=N'" & stvalues.StockUnitName & "'", "mainunitname")
                        stvalues.StockSubUnitName = SQLGetStringFieldValue("select subunitname from stockunits where unitname=N'" & stvalues.StockUnitName & "'", "subunitname")
                    Else
                        stvalues.StockMainUnitName = stvalues.StockUnitName
                        stvalues.StockSubUnitName = ""
                    End If

                    If SQLIsFieldExists("select stockgroupname from stockgroups where stockgroupname=N'" & stvalues.StockGroup & "'") = False Then
                        stvalues.StockGroup = "*Primary"
                    End If
                    CreateStockValues(rowno)
                End If
            End If

NextRow:
        Next

        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub
    Sub CreateStockLocations(ByVal TxtStockLocation As String)
        Dim SqlStr As String = ""
        TxtStockLocation = Replace(TxtStockLocation, " ", "")
        SqlStr = "INSERT INTO [StockLocations] ([locationname],[locationtemp],[Isvisible],[IsDefault],[IsDelete]) VALUES (N'" & TxtStockLocation & "',N'" & TxtStockLocation & "',1,0,0)"
        ExecuteSQLQuery(SqlStr)

    End Sub
    Sub SaveStockItems()
        My.Application.DoEvents()
        For rowno = 0 To TxtIList.RowCount - 1
            ErrorLineNumber = rowno + 1
            Dim isCreated As Boolean = False
            stvalues.ClearData()
            stvalues.StockLocation = TxtIList.Item(0, rowno).Value
            stvalues.StockItemBarCode = TxtIList.Item(1, rowno).Value
            stvalues.CustBarCode = TxtIList.Item(1, rowno).Value
            stvalues.StockGroup = TxtIList.Item(2, rowno).Value
            stvalues.StockItemName = TxtIList.Item(3, rowno).Value
            stvalues.StockItemCode = TxtIList.Item(4, rowno).Value
            stvalues.StockITemSize = TxtIList.Item(5, rowno).Value
            stvalues.StockBatchNo = TxtIList.Item(6, rowno).Value


            stvalues.Brand = TxtIList.Item(7, rowno).Value
            stvalues.Madeby = TxtIList.Item(8, rowno).Value
            stvalues.StockITemDescription = TxtIList.Item(9, rowno).Value
            stvalues.HScode = TxtIList.Item(10, rowno).Value
            stvalues.StockUnitName = TxtIList.Item(11, rowno).Value
            stvalues.OpStockQty = IIf(IsNumeric(TxtIList.Item(12, rowno).Value) = True, IIf(CDbl(TxtIList.Item(12, rowno).Value) >= 0, CDbl(TxtIList.Item(12, rowno).Value), 0), 0)
            stvalues.StockRate = IIf(IsNumeric(TxtIList.Item(13, rowno).Value) = True, IIf(CDbl(TxtIList.Item(13, rowno).Value) >= 0, CDbl(TxtIList.Item(13, rowno).Value), 0), 0)
            stvalues.StockWRPRate = IIf(IsNumeric(TxtIList.Item(14, rowno).Value) = True, IIf(CDbl(TxtIList.Item(14, rowno).Value) >= 0, CDbl(TxtIList.Item(14, rowno).Value), 0), 0)
            stvalues.StockRRPRate = IIf(IsNumeric(TxtIList.Item(15, rowno).Value) = True, IIf(CDbl(TxtIList.Item(15, rowno).Value) >= 0, CDbl(TxtIList.Item(15, rowno).Value), 0), 0)
            stvalues.MRP = IIf(IsNumeric(TxtIList.Item(19, rowno).Value) = True, IIf(CDbl(TxtIList.Item(19, rowno).Value) >= 0, CDbl(TxtIList.Item(19, rowno).Value), 0), 0)

            stvalues.Tax = IIf(IsNumeric(TxtIList.Item(16, rowno).Value) = True, IIf(CDbl(TxtIList.Item(16, rowno).Value) >= 0, CDbl(TxtIList.Item(16, rowno).Value), 0), 0)
            stvalues.MinQty = IIf(IsNumeric(TxtIList.Item(17, rowno).Value) = True, IIf(CDbl(TxtIList.Item(17, rowno).Value) >= 0, CDbl(TxtIList.Item(17, rowno).Value), 0), 0)
            stvalues.ImagePath = TxtIList.Item(18, rowno).Value
            If stvalues.StockItemCode.Length = 0 Then GoTo NextRow
            If stvalues.StockItemName.Length = 0 Then GoTo NextRow
            If stvalues.StockUnitName.Length = 0 Then GoTo NextRow
            If stvalues.StockITemSize = Nothing Then stvalues.StockITemSize = ""
            If stvalues.StockItemCode.IndexOf("""") >= 0 Or stvalues.StockItemCode.IndexOf("[") >= 0 Or stvalues.StockItemCode.IndexOf("]") >= 0 Or stvalues.StockItemCode.IndexOf("'") >= 0 Then
                TxtErrorBox.Text = TxtErrorBox.Text & Chr(13) & ErrorLineNumber.ToString & "  " & ": Invalid Stock Code, special characters are not allowed"
                GoTo NextRow
            End If
            If stvalues.StockItemName.IndexOf("""") >= 0 Or stvalues.StockItemName.IndexOf("[") >= 0 Or stvalues.StockItemName.IndexOf("]") >= 0 Or stvalues.StockItemName.IndexOf("'") >= 0 Then
                TxtErrorBox.Text = TxtErrorBox.Text & Chr(13) & ErrorLineNumber.ToString & "  " & ":  Invalid Stock Name, special characters are not allowed"
                GoTo NextRow
            End If
            If stvalues.StockITemSize.IndexOf("""") >= 0 Or stvalues.StockITemSize.IndexOf("[") >= 0 Or stvalues.StockITemSize.IndexOf("]") >= 0 Or stvalues.StockITemSize.IndexOf("'") >= 0 Then
                TxtErrorBox.Text = TxtErrorBox.Text & Chr(13) & ErrorLineNumber.ToString & "  " & ":  Invalid Stock Size/ More Info, special characters are not allowed"
                GoTo NextRow
            End If



            If stvalues.CustBarCode = Nothing Then stvalues.CustBarCode = ""
            If stvalues.StockLocation = Nothing Then stvalues.StockLocation = "MyLocation"
            stvalues.TxtQtyBOX.ClearQty()
            stvalues.TxtOpQtyBOX.ClearQty()
            stvalues.StockLocation = Replace(stvalues.StockLocation, " ", "")
            If SQLIsFieldExists("SELECT TOP 1 1 from   stocklocations where locationtemp=N'" & Replace(stvalues.StockLocation, " ", "").ToString & "'") = False Then
                If TxtAutoCreateLocations.Checked = True Then
                    CreateStockLocations(stvalues.StockLocation)
                    TxtErrorBox.Text = TxtErrorBox.Text & Chr(13) & ErrorLineNumber.ToString & "  " & ":Stock Location not found, SOLVED:The Location is Created Automatically : Value=" & stvalues.StockLocation
                Else
                    TxtErrorBox.Text = TxtErrorBox.Text & Chr(13) & ErrorLineNumber.ToString & "  " & ":Stock Location not found : Value=" & stvalues.StockLocation
                    GoTo NextRow
                End If
            End If
            If SQLIsFieldExists("select custbarcode from stockdbf where custbarcode=N'" & stvalues.CustBarCode & "' and location=N'" & stvalues.StockLocation & "'") = True Then
                TxtErrorBox.Text = TxtErrorBox.Text & Chr(13) & ErrorLineNumber.ToString & "  " & ": Barcode is already Exists  Values For location=N'" & stvalues.StockLocation & "' and stockcode=N'" & stvalues.StockItemCode & "' and stocksize=N'" & stvalues.StockITemSize & "' and batchno=N'" & stvalues.StockBatchNo & "'"
                GoTo NextRow
            End If
            If SQLIsFieldExists("select unitname from stockunits where unitname=N'" & stvalues.StockUnitName & "'") = True Then

                If SQLIsFieldExists("select stockname from  StockDbf where location=N'" & stvalues.StockLocation & "' and stockcode=N'" & stvalues.StockItemCode & "' and stocksize=N'" & stvalues.StockITemSize & "' ") = False Then
                    If SQLIsFieldExists("select stockname from  StockDbf where location=N'" & stvalues.StockLocation & "' and stockcode=N'" & Replace(stvalues.StockItemCode, " ", "") & "' and stocksize=N'" & stvalues.StockITemSize & "'") = True Then
                        GoTo NextRow
                    End If
                    stvalues.IsSimpleUnit = SQLGetNumericFieldValue("select unittype from stockunits where unitname=N'" & stvalues.StockUnitName & "'", "unittype")

                    stvalues.TxtOpQtyBOX.SetUnitName(stvalues.StockUnitName)
                    stvalues.TxtOpQtyBOX.SetTotalQty(stvalues.OpStockQty)
                    If stvalues.IsSimpleUnit = 1 Then
                        stvalues.StockMainUnitName = SQLGetStringFieldValue("select mainunitname from stockunits where unitname=N'" & stvalues.StockUnitName & "'", "mainunitname")
                        stvalues.StockSubUnitName = SQLGetStringFieldValue("select subunitname from stockunits where unitname=N'" & stvalues.StockUnitName & "'", "subunitname")
                    Else
                        stvalues.StockMainUnitName = stvalues.StockUnitName
                        stvalues.StockSubUnitName = ""
                    End If
                    If SQLIsFieldExists("select stockname from  StockDbf where custbarcode=N'" & stvalues.CustBarCode & "' and ( location<>N'" & stvalues.StockLocation & "' and stockcode<>N'" & stvalues.StockItemCode & "' and stocksize<>N'" & stvalues.StockITemSize & "' )") = True Then
                        TxtErrorBox.Text = TxtErrorBox.Text & Chr(13) & ErrorLineNumber.ToString & "  " & ": Barcode is already Exists  Values For location=N'" & stvalues.StockLocation & "' and stockcode=N'" & stvalues.StockItemCode & "' and stocksize=N'" & stvalues.StockITemSize & "' and batchno=N'" & stvalues.StockBatchNo & "'"
                        GoTo NextRow
                    End If

                    If stvalues.StockGroup = Nothing Then
                        stvalues.StockGroup = "*Primary"
                    ElseIf stvalues.StockGroup.Length = 0 Then

                        stvalues.StockGroup = "*Primary"

                    End If
                    If SQLIsFieldExists("select stockgroupname from stockgroups where stockgroupname=N'" & stvalues.StockGroup & "'") = False Then
                        If IsCreateStockGroups.Checked = True Then

                            ExecuteSQLQuery("INSERT INTO [stockgroups] ([StockgroupName],[StockgroupNameTemp],[groupRoot],[grouplevel]) VALUES(N'" & stvalues.StockGroup & "',N'" & Replace(stvalues.StockGroup, " ", "").ToString & "','*Primary'," & 0 & ")")
                        Else
                            stvalues.StockGroup = "*Primary"
                        End If

                    End If

                    isCreated = CreateStockValues(rowno)

                Else
                    TxtErrorBox.Text = TxtErrorBox.Text & Chr(13) & ErrorLineNumber.ToString & "  " & ": Stock Name and Code is already Exists : Values For location=N'" & stvalues.StockLocation & "' and stockcode=N'" & stvalues.StockItemCode & "' and stocksize=N'" & stvalues.StockITemSize & "' and batchno=N'" & stvalues.StockBatchNo & "'"
                End If
            Else
                TxtErrorBox.Text = TxtErrorBox.Text & Chr(13) & ErrorLineNumber.ToString & "  " & ": Stock Unit Name is not found : Value=" & stvalues.StockUnitName
            End If

NextRow:
            If isCreated = True Then
                TxtIList.Rows(rowno).DefaultCellStyle.BackColor = Color.LightGreen
            Else
                TxtIList.Rows(rowno).DefaultCellStyle.BackColor = Color.OrangeRed
            End If
        Next
    End Sub
    Function CreateStockValues(currentindex As Integer) As Boolean
        Dim TxtBarcode As String = ""
        Dim SqlStr As String = ""

       
        TxtBarcode = GetAndSetBarCodeForNewStockItem()

        SqlStr = "INSERT INTO [StockDbf] ([StockName],[StockCodeTemp],[StockCode],[stockgroup],[Barcode],[StockSize],[Brand],[Company],[Location],[description], " _
         & "[origin],[HScode],[category],[ISBatch],[StoreName],[BaseUnit],[MainUnit],[SubUnit],[IsSimpleUnit],[BaseQty],[TotalQty],[SubUnitQty],[QtyText], " _
         & "[OpBaseQty],[OpTotalQty],[OpSubUnitQty],[StockRate],[StockWRP],[StockDRP],[IsAdvance],[F1],[F2],[N1],[N2],[StockSizeTemp],[Expiry],[BatchNo],[StockImagePath],[StockType],[Isactive],[Tax],[unitcon],[MinQty],[CustBarcode],[OpstockRate],[costmethod],[AllowDiscount],[Servicetax],[mrp],[packing],[allowserialnumbers],[tax2],cst,IsTaxInclude) VALUES " _
         & "(@StockName,@StockCodeTemp,@StockCode,@stockgroup,@Barcode,@StockSize,@Brand,@Company,@Location,@description,@origin,@HScode,@category," _
         & "@ISBatch,@StoreName,@BaseUnit,@MainUnit,@SubUnit,@IsSimpleUnit,@BaseQty,@TotalQty,@SubUnitQty,@QtyText,@OpBaseQty,@OpTotalQty,@OpSubUnitQty,@StockRate," _
         & "@StockWRP,@StockDRP,@IsAdvance,@F1,@F2,@N1,@N2,@StockSizeTemp,@Expiry,@BatchNo,@StockImagePath,@StockType,@Isactive,@Tax,@unitcon,@MinQty,@CustBarcode,@OpstockRate,@costmethod,@AllowDiscount,@Servicetax,@mrp,@packing,@allowserialnumbers,@tax2,@cst,@IsTaxInclude) "

        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
        Try

            With DBF.Parameters
                .AddWithValue("StockName", stvalues.StockItemName)
                .AddWithValue("StockCodeTemp", Replace(stvalues.StockItemCode, " ", ""))
                .AddWithValue("StockCode", stvalues.StockItemCode)
                .AddWithValue("stockgroup", stvalues.StockGroup)
                .AddWithValue("Barcode", TxtBarcode)

                If stvalues.StockITemSize = Nothing Then
                    stvalues.StockITemSize = ""
                End If
                .AddWithValue("CustBarcode", IIf(stvalues.CustBarCode.Length > 0, stvalues.CustBarCode, GetBarcodeForStockItems(stvalues.StockItemCode, stvalues.StockITemSize, TxtBarcode)))

                .AddWithValue("StockSize", stvalues.StockITemSize)
                .AddWithValue("Brand", IIf(stvalues.Brand = Nothing, "", stvalues.Brand))
                .AddWithValue("Company", IIf(stvalues.Madeby = Nothing, " ", stvalues.Madeby))
                .AddWithValue("Location", IIf(stvalues.StockLocation = Nothing, "", stvalues.StockLocation))
                .AddWithValue("description", IIf(stvalues.StockITemDescription = Nothing, "", stvalues.StockITemDescription))
                .AddWithValue("origin", IIf(stvalues.Madeby = Nothing, " ", stvalues.Madeby))
                .AddWithValue("HScode", IIf(stvalues.HScode = Nothing, " ", stvalues.HScode))
                .AddWithValue("category", "")
                If stvalues.StockBatchNo = Nothing Then stvalues.StockBatchNo = "No"
                If UCase(stvalues.StockBatchNo) = "NO" Then
                    stvalues.IsBatchNo = 0
                Else
                    stvalues.IsBatchNo = 1
                End If
                .AddWithValue("ISBatch", stvalues.IsBatchNo)
                .AddWithValue("BaseUnit", stvalues.StockUnitName)
                .AddWithValue("IsTaxInclude", stvalues.IsTaxInclude)
                .AddWithValue("MainUnit", stvalues.StockMainUnitName)
                .AddWithValue("SubUnit", stvalues.StockSubUnitName)
                If stvalues.TxtOpQtyBOX.GetTotalQty() > 0 Then


                    If stvalues.TxtOpQtyBOX.IsSimpleUnit = True Then
                        .AddWithValue("IsSimpleUnit", 1)
                    Else
                        .AddWithValue("IsSimpleUnit", 0)
                    End If
                    .AddWithValue("BaseQty", stvalues.TxtOpQtyBOX.GetUnitQtys(0))
                    .AddWithValue("TotalQty", stvalues.TxtOpQtyBOX.GetTotalQty)
                    .AddWithValue("SubUnitQty", stvalues.TxtOpQtyBOX.GetUnitQtys(1))
                    .AddWithValue("QtyText", stvalues.TxtOpQtyBOX.GetTotalQtyText)
                    .AddWithValue("OpBaseQty", stvalues.TxtOpQtyBOX.GetUnitQtys(0))
                    .AddWithValue("OpTotalQty", stvalues.TxtOpQtyBOX.GetTotalQty)
                    .AddWithValue("OpSubUnitQty", stvalues.TxtOpQtyBOX.GetUnitQtys(1))
                    .AddWithValue("unitcon", stvalues.TxtOpQtyBOX.GetUnitConversion)

                Else
                    If stvalues.TxtOpQtyBOX.IsSimpleUnit = True Then
                        .AddWithValue("IsSimpleUnit", 1)
                    Else
                        .AddWithValue("IsSimpleUnit", 0)
                    End If

                    .AddWithValue("BaseQty", 0)
                    .AddWithValue("TotalQty", 0)
                    .AddWithValue("SubUnitQty", 0)
                    .AddWithValue("QtyText", stvalues.TxtOpQtyBOX.GetTotalQtyText)
                    .AddWithValue("OpBaseQty", 0)
                    .AddWithValue("OpTotalQty", 0)
                    .AddWithValue("OpSubUnitQty", 0)
                    .AddWithValue("unitcon", stvalues.TxtOpQtyBOX.GetUnitConversion)
                End If



                .AddWithValue("batchno", "") ' FOR BATCH NUMBER, WE HAD A SAPERATE TABLE CALLED STOCKBATCH
                .AddWithValue("expiry", Today)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("StockRate", stvalues.StockRate)
                .AddWithValue("OpstockRate", stvalues.StockRate)
                .AddWithValue("StockWRP", stvalues.StockWRPRate)
                .AddWithValue("StockDRP", stvalues.StockRRPRate)
                .AddWithValue("mrp", stvalues.MRP)
                .AddWithValue("packing", "")
                .AddWithValue("allowserialnumbers", "False")


                .AddWithValue("IsAdvance", 0)
                .AddWithValue("F1", "")
                .AddWithValue("F2", "")
                .AddWithValue("N1", 0)
                .AddWithValue("N2", 0)
                .AddWithValue("Tax", stvalues.Tax)
                .AddWithValue("Tax2", stvalues.Tax2)
                .AddWithValue("cst", stvalues.CSTtax)
                .AddWithValue("stocktype", 0)
                .AddWithValue("Isactive", 1)
                If stvalues.StockITemSize = Nothing Then stvalues.StockITemSize = ""
                If stvalues.StockITemSize.Length = 0 Then
                    .AddWithValue("StockSizeTemp", stvalues.StockITemSize)
                Else
                    .AddWithValue("StockSizeTemp", Replace(stvalues.StockITemSize, " ", ""))
                End If
                .AddWithValue("StockImagePath", IIf(stvalues.ImagePath = Nothing, "", stvalues.ImagePath))
                'costmethod
                .AddWithValue("costmethod", "FIFO")
                .AddWithValue("MinQty", stvalues.MinQty)
                .AddWithValue("AllowDiscount", "True")
                .AddWithValue("Servicetax", 0)
            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
            TxtErrorBox.Text = TxtErrorBox.Text & Chr(13) & ErrorLineNumber.ToString & "  " & ": Update successfull for Location,barcode,stockcode,size: " & stvalues.StockLocation & ", " & stvalues.CustBarCode & "," & stvalues.StockItemCode & "," & stvalues.StockITemSize
            My.Application.DoEvents()
            txtStatus.Text = currentindex + 1 & " of " & TxtIList.RowCount & " Items are UPDATED..."
            TxtIList.FirstDisplayedCell = TxtIList.Item(0, currentindex)
            Return True
        Catch ex As Exception
            TxtErrorBox.Text = TxtErrorBox.Text & Chr(13) & ErrorLineNumber.ToString & "  " & ": Internal Error, Error Message: " & ex.Message.ToString
            Try
                DBF = Nothing
                MAINCON.Close()
                Return False
            Catch ex1 As Exception

            End Try
            Return False

        End Try

    End Function
    Function GetBarcodeForStockItems(ByVal vstockcode As String, ByVal vstocksize As String, ByVal vDefBarcode As String) As String
        If SQLIsFieldExists("select CustBarcode from stockdbf where stockcode=N'" & vstockcode & "' and stocksize=N'" & vstocksize & "'") = True Then
            Return SQLGetStringFieldValue("select distinct CustBarcode from stockdbf where stockcode=N'" & vstockcode & "' and stocksize=N'" & vstocksize & "'", "CustBarcode")
        Else
            Return vDefBarcode
        End If

    End Function
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnImportBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImportBrowse.Click
        Dim opfile As New OpenFileDialog
        '(*.bmp, *.jpg)|*.bmp;*.jpg
        opfile.Filter = "(*.xlsx, *.xls)|*.xlsx;*.xls "
        If opfile.ShowDialog() = DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            ReadData(opfile.FileName)
            Me.Cursor = Cursors.Default
        End If
        If TxtIList.Rows.Count = 0 Then
            MsgBox("There are no items to Import.... Please make sure, Unit of stock are exists, if not, Please create Units .", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub BtnError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnError.Click
        Dim k As New StockImportErrorLogFile
        k.RichTextBox1.Text = TxtErrorBox.Text
        k.ShowDialog()
    End Sub

    Private Sub ImsButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click

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


        For i = 1 To TxtIList.ColumnCount
            xlWorkSheet.Cells(1, i) = TxtIList.Columns(i - 1).HeaderText
            xlWorkSheet.Cells(1, i).EntireColumn.ColumnWidth = 20
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


    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click
        Dim opfile As New OpenFileDialog
        '(*.bmp, *.jpg)|*.bmp;*.jpg
        opfile.Filter = "(*.xlsx, *.xls)|*.xlsx;*.xls "
        If opfile.ShowDialog() = DialogResult.OK Then
            ReadBatchData(opfile.FileName)
        End If
        If TxtBatchList.Rows.Count = 0 Then
            MsgBox("There are no Batch details to Import....", MsgBoxStyle.Information)

        End If
    End Sub
    Sub ReadBatchData(ByVal filename As String)
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim range As Excel.Range
        Dim rowno As Integer
        My.Application.DoEvents()
        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(filename)
        xlWorkSheet = xlWorkBook.Worksheets("sheet1")
        TxtBatchList.Rows.Clear()
        stvalues.ClearData()
        Dim listrowno As Integer = 0
        range = xlWorkSheet.UsedRange
        For rowno = 2 To range.Rows.Count
            If Len(CType(range.Cells(rowno, 1), Excel.Range).Value) = 0 Then GoTo NextRow
            Try
                stvalues.StockLocation = CType(range.Cells(rowno, 1), Excel.Range).Value
                stvalues.StockItemCode = CType(range.Cells(rowno, 2), Excel.Range).Value
                stvalues.StockITemSize = CType(range.Cells(rowno, 3), Excel.Range).Value
                stvalues.Tax = SQLGetNumericFieldValue("select tax from  StockDbf where location=N'" & stvalues.StockLocation & "' and stockcode=N'" & stvalues.StockItemCode & "' and stocksize=N'" & stvalues.StockITemSize & "'", "tax")


                stvalues.StockBatchNo = CType(range.Cells(rowno, 4), Excel.Range).Value
                stvalues.ExpDatePicker.Value = CDate(CType(range.Cells(rowno, 5), Excel.Range).Value)
                stvalues.MRP = CType(range.Cells(rowno, 6), Excel.Range).Value
                stvalues.OpStockQty = IIf(IsNumeric(CType(range.Cells(rowno, 7), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 7), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 7), Excel.Range).Value), 0), 0)
                If IsBatchItemIncludeTax.Text = "Including Tax" Then
                    stvalues.StockRate = IIf(IsNumeric(CType(range.Cells(rowno, 8), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 8), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 8), Excel.Range).Value), 0), 0)
                    stvalues.StockRate = stvalues.StockRate * 100 / (100 + stvalues.Tax)
                Else
                    stvalues.StockRate = IIf(IsNumeric(CType(range.Cells(rowno, 8), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 8), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 8), Excel.Range).Value), 0), 0)
                End If
                If IsBatchSalesIncludeTax.Text = "Including Tax" Then
                    stvalues.StockWRPRate = IIf(IsNumeric(CType(range.Cells(rowno, 9), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 9), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 9), Excel.Range).Value), 0), 0)
                    stvalues.StockWRPRate = stvalues.StockWRPRate * 100 / (100 + stvalues.Tax)
                Else
                    stvalues.StockWRPRate = IIf(IsNumeric(CType(range.Cells(rowno, 9), Excel.Range).Value) = True, IIf(CDbl(CType(range.Cells(rowno, 9), Excel.Range).Value) >= 0, CDbl(CType(range.Cells(rowno, 9), Excel.Range).Value), 0), 0)
                End If

                LoadDataIntoBatchList()

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
    Sub LoadDataIntoBatchList()
        Dim TxtBarcode As String = ""

        Dim rno As Integer = 0
        rno = TxtBatchList.Rows.Add
        TxtBatchList.Item("tblocation", rno).Value = stvalues.StockLocation

        TxtBatchList.Item("tbstockcode", rno).Value = stvalues.StockItemCode
        TxtBatchList.Item("tbstocksize", rno).Value = stvalues.StockITemSize

        TxtBatchList.Item("tbbatchno", rno).Value = stvalues.StockBatchNo
        TxtBatchList.Item("tbexpiry", rno).Value = stvalues.ExpDatePicker.Value
        TxtBatchList.Item("tbopqty", rno).Value = stvalues.OpStockQty
        TxtBatchList.Item("tbstockrate", rno).Value = stvalues.StockRate
        TxtBatchList.Item("tbdrp", rno).Value = stvalues.StockWRPRate
        TxtBatchList.Item("tbmrp", rno).Value = stvalues.MRP


    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
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


        For i = 1 To TxtBatchList.ColumnCount
            xlWorkSheet.Cells(1, i) = TxtBatchList.Columns(i - 1).HeaderText
            xlWorkSheet.Cells(1, i).EntireColumn.ColumnWidth = 20
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

    Private Sub ImsButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton5.Click
        If TxtBatchList.RowCount = 0 Then
            MsgBox("Please select the Excel file with pre-defined format then try again....", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If IsUpdateQtywithBatchNo.Checked = True Then
            If MsgBox("Update Stock Qty is checked. The Total Qty of the Batch Number wise will be added to the current Stock Qty" & Chr(13) & "Do you want to Continue....", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        Else
            If MsgBox("Do you want to Update ?               ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        SaveBatchDetails()
    End Sub
    Sub SaveBatchDetails()
        For rowno = 0 To TxtBatchList.RowCount - 1
            ErrorLineNumber = rowno + 1
            Dim isCreated As Boolean = False
            'TempStvalues
            stvalues.ClearData()
            stvalues.StockLocation = TxtBatchList.Item(0, rowno).Value
            stvalues.StockItemCode = TxtBatchList.Item(1, rowno).Value
            stvalues.StockITemSize = TxtBatchList.Item(2, rowno).Value
            If stvalues.StockITemSize = Nothing Then
                stvalues.StockITemSize = ""
            End If
            If SQLIsFieldExists("select stockname from  StockDbf where location=N'" & stvalues.StockLocation & "' and stockcode=N'" & stvalues.StockItemCode & "' and stocksize=N'" & stvalues.StockITemSize & "' ") = False Then
                TxtErrorBox.Text = TxtErrorBox.Text & Chr(13) & ErrorLineNumber.ToString & "  " & ": Stock Name and Code is not found : Values For location=N'" & stvalues.StockLocation & "' and stockcode=N'" & stvalues.StockItemCode & "' and stocksize=N'" & stvalues.StockITemSize & "' and batchno=N'" & stvalues.StockBatchNo & "'"
                GoTo NextRow
            End If
            GetDefLocationStockDetails(stvalues.StockLocation, stvalues.StockItemCode, stvalues.StockITemSize, stvalues)
            stvalues.StockLocation = TxtBatchList.Item(0, rowno).Value
            stvalues.StockBatchNo = TxtBatchList.Item(3, rowno).Value
            stvalues.ExpDatePicker.Value = CDate(TxtBatchList.Item(4, rowno).Value)
            stvalues.MRP = IIf(IsNumeric(TxtBatchList.Item(5, rowno).Value) = True, IIf(CDbl(TxtBatchList.Item(5, rowno).Value) >= 0, CDbl(TxtBatchList.Item(5, rowno).Value), 0), 0)
            stvalues.OpStockQty = IIf(IsNumeric(TxtBatchList.Item(6, rowno).Value) = True, IIf(CDbl(TxtBatchList.Item(6, rowno).Value) >= 0, CDbl(TxtBatchList.Item(6, rowno).Value), 0), 0)
            stvalues.StockRate = IIf(IsNumeric(TxtBatchList.Item(7, rowno).Value) = True, IIf(CDbl(TxtBatchList.Item(7, rowno).Value) >= 0, CDbl(TxtBatchList.Item(7, rowno).Value), 0), 0)
            stvalues.StockWRPRate = IIf(IsNumeric(TxtBatchList.Item(8, rowno).Value) = True, IIf(CDbl(TxtBatchList.Item(8, rowno).Value) >= 0, CDbl(TxtBatchList.Item(8, rowno).Value), 0), 0)
            'READING ADDITIONAL STOCK DETAILS


            If stvalues.StockItemCode.Length = 0 Then GoTo NextRow
            If stvalues.StockUnitName.Length = 0 Then GoTo NextRow
            If stvalues.CustBarCode = Nothing Then stvalues.CustBarCode = ""
            If stvalues.StockLocation = Nothing Then stvalues.StockLocation = "MyLocation"
            stvalues.TxtOpQtyBOX.ClearQty()
            stvalues.StockLocation = Replace(stvalues.StockLocation, " ", "")
            If SQLIsFieldExists("SELECT TOP 1 1 from   stocklocations where locationtemp=N'" & Replace(stvalues.StockLocation, " ", "").ToString & "'") = False Then
                TxtErrorBox.Text = TxtErrorBox.Text & Chr(13) & ErrorLineNumber.ToString & "  " & ":Stock Location not found : Value=" & stvalues.StockLocation
                GoTo NextRow
            End If
            If SQLIsFieldExists("select stockname from  StockDbf where location=N'" & stvalues.StockLocation & "' and stockcode=N'" & stvalues.StockItemCode & "' and stocksize=N'" & stvalues.StockITemSize & "' ") = True Then

                stvalues.IsSimpleUnit = SQLGetNumericFieldValue("select unittype from stockunits where unitname=N'" & stvalues.StockUnitName & "'", "unittype")

                stvalues.TxtOpQtyBOX.SetUnitName(stvalues.StockUnitName)
                stvalues.TxtOpQtyBOX.SetTotalQty(stvalues.OpStockQty)
                If stvalues.IsSimpleUnit = 1 Then
                    stvalues.StockMainUnitName = SQLGetStringFieldValue("select mainunitname from stockunits where unitname=N'" & stvalues.StockUnitName & "'", "mainunitname")
                    stvalues.StockSubUnitName = SQLGetStringFieldValue("select subunitname from stockunits where unitname=N'" & stvalues.StockUnitName & "'", "subunitname")
                Else
                    stvalues.StockMainUnitName = stvalues.StockUnitName
                    stvalues.StockSubUnitName = ""
                End If
                If SQLIsFieldExists("Select stockcode from StockBatch where stockcode=N'" & stvalues.StockItemCode & "' and stocksize=N'" & stvalues.StockITemSize & "' and location=N'" & stvalues.StockLocation & "' and batchno=N'" & stvalues.StockBatchNo & "'") = False Then
                    isCreated = CreatebatchNosExpiryData(stvalues)
                Else
                    TxtErrorBox.Text = TxtErrorBox.Text & Chr(13) & ErrorLineNumber.ToString & "  " & ": Batch Number is Already Exists : Values For location=N'" & stvalues.StockLocation & "' and stockcode=N'" & stvalues.StockItemCode & "' and stocksize=N'" & stvalues.StockITemSize & "' and batchno=N'" & stvalues.StockBatchNo & "'"
                End If

            Else
                TxtErrorBox.Text = TxtErrorBox.Text & Chr(13) & ErrorLineNumber.ToString & "  " & ": Stock Name and Code is not found : Values For location=N'" & stvalues.StockLocation & "' and stockcode=N'" & stvalues.StockItemCode & "' and stocksize=N'" & stvalues.StockITemSize & "' "
            End If

NextRow:
            If isCreated = True Then
                TxtBatchList.Rows(rowno).DefaultCellStyle.BackColor = Color.LightGreen
            Else
                TxtBatchList.Rows(rowno).DefaultCellStyle.BackColor = Color.OrangeRed
            End If
        Next
    End Sub

    Function CreatebatchNosExpiryData(ByVal stockvalues As ChooseItemClass) As Boolean
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim batchsqlstr As String = ""
        batchsqlstr = " INSERT INTO [StockBatch] ([StockCode] ,[Barcode] ,[StockSize] ,[Location],[BaseUnit],[MainUnit],[SubUnit],[IsSimpleUnit] ,[BaseQty] ,[TotalQty] ,[SubUnitQty] ,[QtyText] ,[OpBaseQty] , " _
            & " [OpTotalQty] ,[OpSubUnitQty] ,[StockRate] ,[Expiry] ,[BatchNo] ,[OpstockRate] ,[mrp] ,[expiryDateValue])     VALUES " _
            & "(@StockCode ,@Barcode ,@StockSize ,@Location,@BaseUnit,@MainUnit,@SubUnit,@IsSimpleUnit ,@BaseQty ,@TotalQty ,@SubUnitQty ,@QtyText , " _
            & " @OpBaseQty ,@OpTotalQty ,@OpSubUnitQty ,@StockRate ,@Expiry ,@BatchNo ,@OpstockRate ,@mrp ,@expiryDateValue)   "

       
        Dim DBF1 As New SqlClient.SqlCommand(batchsqlstr, MAINCON)
        With DBF1.Parameters
            .AddWithValue("StockCode", stockvalues.StockItemCode)
            .AddWithValue("Barcode", stockvalues.StockItemBarCode)
            .AddWithValue("StockSize", stockvalues.StockITemSize)
            .AddWithValue("Location", stockvalues.StockLocation)
            .AddWithValue("BaseUnit", stockvalues.StockUnitName)
            .AddWithValue("MainUnit", stockvalues.StockMainUnitName)
            .AddWithValue("SubUnit", stockvalues.StockSubUnitName)
            .AddWithValue("IsSimpleUnit", stockvalues.IsSimpleUnit)

            .AddWithValue("BaseQty", stockvalues.TxtOpQtyBOX.GetUnitQtys(0))
            .AddWithValue("TotalQty", stockvalues.TxtOpQtyBOX.GetTotalQty)
            .AddWithValue("SubUnitQty", stockvalues.TxtOpQtyBOX.GetUnitQtys(1))
            .AddWithValue("QtyText", stockvalues.TxtOpQtyBOX.GetTotalQtyText)
            .AddWithValue("OpBaseQty", stockvalues.TxtOpQtyBOX.GetUnitQtys(0))
            .AddWithValue("OpTotalQty", stockvalues.TxtOpQtyBOX.GetTotalQty)
            .AddWithValue("OpSubUnitQty", stockvalues.TxtOpQtyBOX.GetUnitQtys(1))

            .AddWithValue("OpstockRate", stockvalues.StockRate)
            .AddWithValue("StockRate", stockvalues.StockRate)
            .AddWithValue("mrp", stockvalues.MRP)

            .AddWithValue("expiry", stockvalues.ExpDatePicker.Value)
            .AddWithValue("BatchNo", stockvalues.StockBatchNo)
            .AddWithValue("expiryDateValue", stockvalues.ExpDatePicker.Value.Date.ToOADate)

        End With
        DBF1.ExecuteNonQuery()
        DBF1 = Nothing
        MAINCON.Close()
        If IsUpdateQtywithBatchNo.Checked = True Then
            UpdateStockQtys(stockvalues.StockLocation, stockvalues.StockItemCode, stockvalues.StockITemSize, stockvalues.TxtOpQtyBOX.GetTotalQty)
        End If

        Return True
    End Function

    Sub UpdateStockQtys(ByVal vstocklocation As String, ByVal vstockcode As String, ByVal vstocksize As String, ByVal uQty As Double)
        Dim DbQty As Double = 0
        Dim OpDbQty As Double = 0
        Dim UpQty As New IMSQtyBox
        Dim OpUpQty As New IMSQtyBox
        Dim DbUnit As String = ""
        UpQty.TxtQty2.Min = -9999999
        UpQty.TxtQty2.AllowNegative = True
        UpQty.TxtQty1.AllowNegative = True
        OpUpQty.TxtQty2.Min = -9999999
        OpUpQty.TxtQty2.AllowNegative = True
        OpUpQty.TxtQty1.AllowNegative = True

        DbQty = SQLGetNumericFieldValue("select TotalQty from stockdbf where location=N'" & vstocklocation & "' and stockcode=N'" & vstockcode & "' and stocksize=N'" & vstocksize & "'", "TotalQty")
        OpDbQty = SQLGetNumericFieldValue("select opTotalQty from stockdbf where location=N'" & vstocklocation & "' and stockcode=N'" & vstockcode & "' and stocksize=N'" & vstocksize & "'", "opTotalQty")
        DbUnit = SQLGetStringFieldValue("select baseunit from stockdbf where location=N'" & vstocklocation & "' and stockcode=N'" & vstockcode & "' and stocksize=N'" & vstocksize & "'", "baseunit")
        UpQty.SetUnitName(DbUnit)
        UpQty.TxtQty2.Text = "0"
        UpQty.TxtQty1.Text = "0"

        OpUpQty.TxtQty2.Text = "0"
        OpUpQty.TxtQty1.Text = "0"

        DbQty = DbQty + uQty
        OpDbQty = OpDbQty + uQty
        If UpQty.IsSimpleUnit = True Then
            UpQty.TxtQty1.Text = DbQty
            OpUpQty.TxtQty1.Text = OpDbQty
            ExecuteSQLQuery("update stockdbf set TotalQty=" & DbQty & ",BaseQty=" & DbQty & ",QtyText=N'" & UpQty.GetTotalQtyText() & "',opTotalQty=" & OpDbQty & ",opBaseQty=" & OpDbQty & " where location=N'" & vstocklocation & "' and stockcode=N'" & vstockcode & "' and stocksize=N'" & vstocksize & "'")

        Else
            UpQty.TxtQty2.Text = DbQty
            UpQty.CalculateValuesWithNumeric()
            OpUpQty.TxtQty2.Text = OpDbQty
            OpUpQty.CalculateValuesWithNumeric()
            ExecuteSQLQuery("update stockdbf set TotalQty=" & DbQty & ",BaseQty=" & UpQty.GetUnitQtys(0) & ",SubUnitQty=" & UpQty.GetUnitQtys(1) & ",QtyText=N'" & UpQty.GetTotalQtyText() & "',opTotalQty=" & OpDbQty & ",opBaseQty=" & OpUpQty.GetUnitQtys(0) & ",opSubUnitQty=" & OpUpQty.GetUnitQtys(1) & " where location=N'" & vstocklocation & "' and stockcode=N'" & vstockcode & "' and stocksize=N'" & vstocksize & "'")

        End If


    End Sub

    Private Sub StockItemsImportExport_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub StockItemsImportExport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If MyAppSettings.ItemPriceasIncludingVAT = True Then
            IsIncludingTax.Text = "Including Tax"
            IsBatchItemIncludeTax.Text = "Including Tax"
        Else
            IsIncludingTax.Text = "Excluding Tax"
            IsBatchItemIncludeTax.Text = "Excluding Tax"
        End If
        If MyAppSettings.SalesPriceasIncludingVAT = True Then
            IsSalesIncludingTax.Text = "Including Tax"
            IsBatchSalesIncludeTax.Text = "Including Tax"
        Else
            IsSalesIncludingTax.Text = "Excluding Tax"
            IsBatchSalesIncludeTax.Text = "Excluding Tax"
        End If
      
    End Sub
End Class