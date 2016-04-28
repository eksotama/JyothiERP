Public Class SalesOrderList

    Dim SqlStr As String = ""
    Dim SqlGroupStr As String = ""
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Private Sub Txtgrid_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtGrid.DataError

    End Sub
    Sub LoadListofOrders(Optional ByVal AddSqlText As String = "")
        If IsShowPendingsOnly.Checked = True Then
            SqlStr = "SELECT ROW_NUMBER() OVER (ORDER BY QutoNo) AS [S.NO],TransCode as [TransCode],TransDate as [Date],QutoNo as [Order No],QutoRef as [Ref no],DelivaryDate as [Delivary Date],LedgerName as [Customer Name],nettotal as [Invoice Amount],(case IsPending when 0 then 'Completed' ELSE  'Pending' END)  as [Status] from stockinvoicedetails where Isdelete=0 and IsPending=1 and vouchername='SO' and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
        Else
            SqlStr = "SELECT ROW_NUMBER() OVER (ORDER BY QutoNo) AS [S.NO],TransCode as [TransCode],TransDate as [Date],QutoNo as [Order No],QutoRef as [Ref no],DelivaryDate as [Delivary Date],LedgerName as [Customer Name],nettotal as [Invoice Amount],(case IsPending when 0 then 'Completed' ELSE  'Pending' END)  as [Status] from stockinvoicedetails where Isdelete=0 and vouchername='SO' and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
        End If

        SqlStr = SqlStr & AddSqlText

        Dim TempBS As New BindingSource

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(0).Width = 35
            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(1).Width = 120
            Me.TxtList.Columns(1).Visible = False
            Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(2).Width = 120
            Me.TxtList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(3).Width = 120
            Me.TxtList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(4).Width = 120
            Me.TxtList.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(5).Width = 120

        Catch ex As Exception

        End Try

    End Sub
    Sub LoadItemWiseReport()
        Me.Cursor = Cursors.WaitCursor
        BtnEdit.Visible = True
        Dim TempBS As New BindingSource
        If TxtSalesPerson.Text.Length = 0 Then
            TxtSalesPerson.Text = "*All"
        End If
        If TxtLedgerName.Text.Length = 0 Then
            TxtLedgerName.Text = "*All"
        End If
        Dim sqlStrGroup As String
        sqlStrGroup = " GROUP BY StockCode,StockName, StockSize, BaseUnit, UnitCon, MainUnit,SubUnit"

        If IsShowPendingsOnly.Checked = True Then
            SqlGroupStr = "SELECT StockCode as [Stock Code],StockName as [Stock Name],StockSize as [Stock Size],SUM(TotalQty) AS [Base Qty], (CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainunit ELSE (CASE CAST(SUM(TotalQty) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST(SUM(TotalQty) AS INT) % CAST(UnitCon AS INT))+ ' ' + subUnit) END) END) AS [Total Qty], sum(stockamount) as [Stock Value] FROM StockInvoiceRowItems where VoucherName='SO'  and isdelete=0 and (transcode IN (select transcode from StockInvoiceDetails where ispending=1)) "
        Else
            SqlGroupStr = "SELECT StockCode as [Stock Code],StockName as [Stock Name],StockSize as [Stock Size],SUM(TotalQty) AS [Base Qty], (CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainunit ELSE (CASE CAST(SUM(TotalQty) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor(SUM(TotalQty) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST(SUM(TotalQty) AS INT) % CAST(UnitCon AS INT))+ ' ' + subUnit) END) END) AS [Total Qty], sum(stockamount) as [Stock Value] FROM StockInvoiceRowItems where VoucherName='SO' and isdelete=0 "
        End If

        'If CheckBox2.Checked = True Then
        '    sqlStrGroup = " GROUP BY ledgername, StockCode,StockName, StockSize, BaseUnit, UnitCon, MainUnit,SubUnit"
        'End If

        If TxtSalesPerson.Text = "*All" And TxtLedgerName.Text = "*All" Then
            SqlGroupStr = SqlGroupStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"

        ElseIf TxtSalesPerson.Text = "*All" Then
            SqlGroupStr = SqlGroupStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and ledgername=N'" & TxtLedgerName.Text & "'"

        ElseIf TxtLedgerName.Text = "*All" Then
            SqlGroupStr = SqlGroupStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and salesperson=N'" & TxtSalesPerson.Text & "'"

        Else
            SqlGroupStr = SqlGroupStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and ledgername=N'" & TxtLedgerName.Text & "' and salesperson=N'" & TxtSalesPerson.Text & "'"

        End If

        SqlGroupStr = SqlGroupStr & sqlStrGroup
        With Me.TxtGrid
            TempBS.DataSource = SQLLoadGridData(SqlGroupStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try

            Me.TxtGrid.Columns("Stock Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtGrid.Columns("Stock Code").Width = 180
            'Stock Name
            Me.TxtGrid.Columns("Stock Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtGrid.Columns("Stock Name").Width = 180


            Me.TxtGrid.Columns("Stock Size").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtGrid.Columns("Stock Size").Width = 150

            Me.TxtGrid.Columns("Base Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtGrid.Columns("Base Qty").Width = 180
            Me.TxtGrid.Columns("Base Qty").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtGrid.Columns("Base Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtGrid.Columns("Total Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtGrid.Columns("Total Qty").Width = 180

            Me.TxtGrid.Columns("Stock Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtGrid.Columns("Stock Value").Width = 120
            Me.TxtGrid.Columns("Stock Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            Me.TxtGrid.Columns("Stock Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Catch ex As Exception

        End Try

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub SalesOrderList_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub SalesOrderList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        If APPUserRights.IsDeleteble = False Then
            BtnDelete.Enabled = False
        End If
        If APPUserRights.IsEditable = False Then
            BtnEdit.Enabled = False
        End If

        LoadDataIntoComboBox("select distinct ledgername from  stockinvoicedetails where vouchername='SO'", TxtLedgerName, "ledgername", "*All")
        LoadDataIntoComboBox("select distinct salesperson from  stockinvoicedetails where vouchername='SO'", TxtSalesPerson, "salesperson", "*All")
        LoadDataIntoComboBox("select distinct area from  stockinvoicedetails where vouchername='SO'", TxtSalesArea, "area", "*All")
        If IsShowItemWise.Checked = True Then
            TxtList.Visible = False
            TxtGrid.Visible = True
            TxtGrid.Dock = DockStyle.Fill
            BtnEdit.Visible = False
            CheckBox2.Visible = True
            BtnDelete.Visible = False
        Else
            TxtList.Visible = True
            CheckBox2.Visible = False
            TxtGrid.Visible = False
            TxtList.Dock = DockStyle.Fill
            BtnEdit.Visible = True
            BtnDelete.Visible = True
        End If
        If IsShowItemWise.Checked = True Then
            LoadItemWiseReport()
        Else
            LoadListofOrders()
        End If


    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        If IsShowItemWise.Checked = True Then
            LoadItemWiseReport()
        Else
            LoadListofOrders()
        End If
    End Sub

    Private Sub IsShowPendingsOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsShowPendingsOnly.CheckedChanged
        If IsShowItemWise.Checked = True Then
            LoadItemWiseReport()
        Else
            LoadListofOrders()
        End If
    End Sub

    Private Sub TxtLedgerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.SelectedIndexChanged

        If IsShowItemWise.Checked = True Then
            LoadItemWiseReport()
        Else
            If TxtLedgerName.Text.Length = 0 Or TxtLedgerName.Text = "*All" Then
                LoadListofOrders()
            Else
                LoadListofOrders(" and ledgername=N'" & TxtLedgerName.Text & "'")
            End If
        End If

    End Sub

    Private Sub TxtSalesPerson_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSalesPerson.SelectedIndexChanged
        If TxtSalesPerson.Text.Length = 0 Or TxtSalesPerson.Text = "*All" Then
            LoadListofOrders()
        Else
            LoadListofOrders(" and salesperson=N'" & TxtSalesPerson.Text & "'")
        End If
    End Sub

    Private Sub TxtSalesArea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSalesArea.SelectedIndexChanged
        If TxtSalesArea.Text.Length = 0 Or TxtSalesArea.Text = "*All" Then
            LoadListofOrders()
        Else
            LoadListofOrders(" and area=N'" & TxtSalesArea.Text & "'")
        End If
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If IsShowItemWise.Checked = True Then
            MsgBox("Edit is not possible on Itemwise Report.....", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Order Row   ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtList.Item("transcode", TxtList.CurrentRow.Index).Value.ToString.Length > 0 Then
            Dim frm As New InvoiceAlterForm
            frm.TxtTitle.Text = "ALTER SALES ORDER"
            Dim K As New SalesControlAll("SO", TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
            K.BtnNew.Enabled = False
            K.BtnOpen.Enabled = False
            If TxtList.Item("Status", TxtList.CurrentRow.Index).Value = "Pending" Then
                K.BtnSave.Enabled = False
            End If
            frm.TxtList.Controls.Add(K)
            frm.TxtList.Controls(0).Dock = DockStyle.Fill
            frm.WindowState = FormWindowState.Maximized
            frm.ShowDialog()


            frm.Dispose()
            K.Dispose()
            LoadListofOrders()
        End If

    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem.Click
        If IsShowItemWise.Checked = True Then
            MsgBox("Delete is not possible on Itemwise Report.....", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Order Row   ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If MsgBox("Are u sure, Do you want to delete the selected Entry?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            Dim testlock As String = IsTransactionLocked(TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
            If testlock.Length = 0 Then
                Dim K As New SalesControlAll("SO", TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
                K.IsOpenedOutsideforDelete = True
                K.BtnNew.Enabled = False
                K.BtnOpen.Enabled = False
                K.OpenByTransCodeID(TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
                K.DeleteOpenedInvoice()
                K.Dispose()
                LoadListofOrders()
            Else
                MsgBox(testlock)
            End If

        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsShowItemWise.CheckedChanged, CheckBox2.CheckedChanged
        If IsShowItemWise.Checked = True Then
            TxtList.Visible = False
            TxtGrid.Visible = True
            TxtGrid.Dock = DockStyle.Fill
            BtnEdit.Visible = False
            CheckBox2.Visible = True
            BtnDelete.Visible = False
        Else
            TxtList.Visible = True
            CheckBox2.Visible = False
            TxtGrid.Visible = False
            TxtList.Dock = DockStyle.Fill
            BtnEdit.Visible = True
            BtnDelete.Visible = True
        End If
    End Sub
End Class