Imports System.Windows.Forms

Public Class ChooseItems
    Public FileterLocationName As String = ""
    Dim isloading As Boolean = True
    Dim TempBS As New BindingSource

    Sub loadstockitems(Optional ByVal SqlStrOp As String = "")
        If isloading = True Then Exit Sub
        Dim Sqlstr As String = ""
        '        Sqlstr = " SELECT StockLocations.locationname as [Location], MT.StockCode AS [Stock Code], (SELECT TOP 1 StockName FROM StockDbf AS mt1 WHERE (StockCode = MT.StockCode) AND (StockSize = MT.StockSize)) AS [Stock Name], MT.StockSize as [Stock Size]," _
        ' & " (SELECT TOP 1  Barcode FROM StockDbf AS mt1 WHERE (StockCode = MT.StockCode) AND (StockSize = MT.StockSize) AND (Location = dbo.StockLocations.locationname)) AS barcode, MT.BaseUnit,  MT.CustBarcode as [Bar Code],  (SELECT avg(stockrate) FROM StockDbf AS mt1 WHERE (StockCode = MT.StockCode) AND (StockSize = MT.StockSize) AND (Location = dbo.StockLocations.locationname)) AS Price," _
        '& " (SELECT TOP 1  QtyText FROM          dbo.StockDbf AS StockDbf_2 WHERE  (StockCode = MT.StockCode) AND (StockSize = MT.StockSize) AND (Location = dbo.StockLocations.locationname)) AS [Total Qty] " _
        '& " FROM   StockDbf AS MT CROSS JOIN   StockLocations where isactive=1"


        '        Sqlstr = Sqlstr & SqlStrOp

        '        Sqlstr = Sqlstr & " GROUP BY MT.StockCode, MT.StockSize, MT.BaseUnit, MT.CustBarcode, dbo.StockLocations.locationname "
        Sqlstr = " SELECT STOCKLOCATIONS.locationname AS Location,STOCKCODE AS [Stock Code],STOCKNAME AS [Stock Name],STOCKSIZE AS [Stock Size] ,CUSTbarcode AS [BARCODE],BaseUnit,avg(StockRate) as Price ,isnull((SELECT TOP 1  QTYTEXT FROM          dbo.StockDbf AS t WHERE  (t.StockCode = StockDbf.StockCode) AND (t.StockSize = StockDbf.StockSize) AND (t.Location = dbo.StockLocations.locationname)),'0 ' ) AS [Total Qty] FROM STOCKDBF   CROSS JOIN StockLocations WHERE isactive=1  "

        If TxtLocation.Text = "*All" Or TxtLocation.Text.Length = 0 Then

        Else
            SqlStrOp = SqlStrOp & " AND  STOCKLOCATIONS.locationname=N'" & TxtLocation.Text & "'"
        End If
        Sqlstr = Sqlstr & SqlStrOp
        Sqlstr = Sqlstr & "  GROUP BY STOCKCODE,STOCKSIZE,STOCKNAME,STOCKLOCATIONS.locationname ,CUSTbarcode,BaseUnit   "
        TempBS.DataSource = SQLLoadGridData(Sqlstr)
        With Me.TxtList
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            If AppIsItemwithSize = False Then
                TxtList.Columns("Stock Size").Visible = False
            End If
            TxtList.Columns("Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Price").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("BARCODE").Visible = False
            TxtList.Columns("BAR CODE").Visible = False




        Catch ex As Exception

        End Try
        Try
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(0).Width = 100
            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(1).Width = 250
            Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(2).Width = 150
        Catch ex As Exception

        End Try

      
    End Sub

    Private Sub ChooseItems_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        If Bcode.CurrentField = 0 Then
            TxtStockCode.Focus()
            TxtStockCode.Text = Bcode.CurrentChar
            Try
                TxtStockCode.SelectionStart = TxtStockCode.Text.Length
            Catch ex As Exception

            End Try
        Else
            TxtStockName.Focus()
            TxtStockName.Text = Bcode.CurrentChar
            Try
                TxtStockName.SelectionStart = TxtStockName.Text.Length
            Catch ex As Exception

            End Try

        End If
        If TxtList.RowCount = 0 Then
            loadstockitems()
        End If
    End Sub

    Private Sub ChooseItems_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        TxtList.Dispose()
    End Sub
    Private Sub ChooseItems_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Bcode.StockItemBarCode = 0


        LoadDataIntoComboBox("select locationname from StockLocations where isdelete=0 ", TxtLocation, "locationname", "*All")
        If LocationName.Length > 0 Then
            TxtLocation.Text = LocationName
        Else
            If TxtLocation.Enabled = True Then
                TxtLocation.Text = GetLocation()
            End If
            If TxtLocation.Text.Length = 0 Then
                TxtLocation.Text = GetLocation()
            End If
        End If
        isloading = False
        ' loadstockitems()

    End Sub
    Sub AcceptValues()
        Bcode.StockItemBarCode = 0
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Item from the list.............. ", MsgBoxStyle.Information)
            TxtList.Focus()
            Exit Sub
        Else
            Dim ITEMBARCODE As String = SQLGetStringFieldValue("select barcode from stockdbf where location=N'" & TxtList.Item("Location", TxtList.CurrentRow.Index).Value & "' and custbarcode=N'" & TxtList.Item("BARCODE", TxtList.CurrentRow.Index).Value & "'", "barcode")

            If ITEMBARCODE.Length = 0 Then
                'create stock items with location
                Dim NewAddItem As New ChooseItemClass
                LoadStockItemsIntoClassWithStockDetails(TxtList.Item("stock code", TxtList.CurrentRow.Index).Value, TxtList.Item("stock size", TxtList.CurrentRow.Index).Value, "", NewAddItem)
                Bcode.StockItemBarCode = AddStockItem(TxtList.Item("stock code", TxtList.CurrentRow.Index).Value, TxtList.Item("stock size", TxtList.CurrentRow.Index).Value, "", TxtList.Item("location", TxtList.CurrentRow.Index).Value, NewAddItem)
                Bcode.StockLocation = TxtList.Item("Location", TxtList.CurrentRow.Index).Value
            Else
                Bcode.StockItemBarCode = ITEMBARCODE
                Bcode.StockLocation = TxtList.Item("Location", TxtList.CurrentRow.Index).Value
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub
    Private Sub TxtStockCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtStockCode.KeyDown, TxtLocation.KeyDown, TxtStockDes.KeyDown, TxtStockName.KeyDown, TxtOnlyServices.KeyDown
        If e.KeyCode = Keys.Enter Then
            AcceptValues()
        ElseIf e.KeyCode = Keys.Down Then
            Try
                TxtList.Item(0, TxtList.CurrentRow.Index + 1).Selected = True
            Catch ex As Exception

            End Try
        ElseIf e.KeyCode = Keys.Up Then
            Try
                TxtList.Item(0, TxtList.CurrentRow.Index - 1).Selected = True
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub TxtListe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtList.KeyDown
        If e.KeyCode = Keys.Enter Then
            AcceptValues()
        End If
    End Sub

    Private Sub TxtStockCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockCode.TextChanged
        If isloading = True Then Exit Sub
        Dim str As String = ""
        If TxtStockCode.Text.Length = 0 Then
            If TxtOnlyServices.Text = "Non-Stock" Then
                str = " and stocktype<>0 "
            ElseIf TxtOnlyServices.Text = "Stock" Then
                str = "  and stocktype=0 "
            Else
                str = ""
            End If

        Else
            If TxtOnlyServices.Text = "Non-Stock" Then
                str = " and stockcode LIKE N'%" & TxtStockCode.Text & "%' and stocktype<>0 "
            ElseIf TxtOnlyServices.Text = "Stock" Then
                str = " and stockcode LIKE N'%" & TxtStockCode.Text & "%' and stocktype=0 "
            Else
                str = " and stockcode LIKE N'%" & TxtStockCode.Text & "%' "
            End If
        End If

        loadstockitems(str)
    End Sub



    Private Sub TxtStockName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockName.TextChanged
        If isloading = True Then Exit Sub
        Dim str As String = ""

        If TxtStockName.Text.Length = 0 Then
            If TxtOnlyServices.Text = "Non-Stock" Then
                str = " and stocktype<>0 "
            ElseIf TxtOnlyServices.Text = "Stock" Then
                str = "  and stocktype=0 "
            Else
                str = ""
            End If

        Else
            If TxtOnlyServices.Text = "Non-Stock" Then
                str = " and stockname LIKE N'" & TxtStockName.Text & "%' and stocktype<>0 "
            ElseIf TxtOnlyServices.Text = "Stock" Then
                str = " and stockname LIKE N'" & TxtStockName.Text & "%' and stocktype=0 "
            Else
                str = " and stockname LIKE N'" & TxtStockName.Text & "%' "
            End If
        End If
       
        loadstockitems(str)
    End Sub

    Private Sub TxtStockDes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockDes.TextChanged
        If isloading = True Then Exit Sub
        Dim str As String = ""
        If TxtStockDes.Text.Length = 0 Then
            If TxtOnlyServices.Text = "Non-Stock" Then
                str = " and stocktype<>0 "
            ElseIf TxtOnlyServices.Text = "Stock" Then
                str = "  and stocktype=0 "
            Else
                str = ""
            End If

        Else
            If TxtOnlyServices.Text = "Non-Stock" Then
                str = " and description LIKE N'%" & TxtStockDes.Text & "%'  and stocktype<>0 "
            ElseIf TxtOnlyServices.Text = "Stock" Then
                str = " and description LIKE N'%" & TxtStockDes.Text & "%'  and stocktype=0 "
            Else
                str = " and description LIKE N'%" & TxtStockDes.Text & "%'  "
            End If
        End If

       


        loadstockitems(str)
    End Sub

    Private Sub TxtList_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentDoubleClick
        AcceptValues()
    End Sub

    Private Sub TxtList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellDoubleClick
        AcceptValues()
    End Sub

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub

   


    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        AcceptValues()
    End Sub

    Private Sub TxtLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLocation.SelectedIndexChanged
        If isloading = True Then Exit Sub
        Dim str As String = ""
        If TxtStockCode.Text.Length = 0 Then
            If TxtOnlyServices.Text = "Non-Stock" Then
                str = " and stocktype<>0 "
            ElseIf TxtOnlyServices.Text = "Stock" Then
                str = "  and stocktype=0 "
            Else
                str = ""
            End If

        Else
            If TxtOnlyServices.Text = "Non-Stock" Then
                str = "   and stocktype<>0 "
            ElseIf TxtOnlyServices.Text = "Stock" Then
                str = "   and stocktype=0 "
            Else
                str = "  "
            End If
        End If
        loadstockitems(str)
    End Sub

    Private Sub TxtOnlyServices_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOnlyServices.SelectedIndexChanged
        If isloading = True Then Exit Sub
        TxtStockCode.Focus()
        Dim Str As String = ""
        If TxtOnlyServices.Text = "Non-Stock" Then
            Str = " and StockType<>0"
        ElseIf TxtOnlyServices.Text = "Stock" Then
            Str = " and StockType=0"
        Else
            Str = " "
        End If
        loadstockitems(Str)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        Dim NewStFrm As New CreateNewStockItem
        NewStFrm.ShowDialog()
        NewStFrm.Dispose()
        loadstockitems()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    'CREATE STOCKITEM WITH LOCATION
    
    Private Sub NameToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NameToolStripMenuItem.Click
        TxtStockCode.Focus()
    End Sub

    Private Sub CodeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CodeToolStripMenuItem.Click
        TxtStockName.Focus()
    End Sub
End Class
