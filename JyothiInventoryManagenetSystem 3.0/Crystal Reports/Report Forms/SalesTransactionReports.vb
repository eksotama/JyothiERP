Public Class SalesTransactionReports
    Dim DBFieldName As String = ""
    Dim VhName As String = ""
    Dim SqlStr As String = ""

    Private Sub TxtList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellDoubleClick
        EditTransactions()
    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub New(ByVal vname As String)

        ' This call is required by the designer.
        InitializeComponent()
        VhName = vname
        If VhName = "SO" Then
            TxtTitle.Text = "SALES ORDER REPORTS"
            DBFieldName = "Order No"
        ElseIf VhName = "SQ" Then
            TxtTitle.Text = "SALES QUOTE REPORTS "
            DBFieldName = "Quote No"
        ElseIf VhName = "SI" Then
            DBFieldName = "Invoice No"
            TxtTitle.Text = "SALES INVOICE  REPORTS"
        ElseIf VhName = "SD" Then
            DBFieldName = "Delivery No"
            TxtTitle.Text = "SALES DELIVERY NOTE REPORTS "
        ElseIf VhName = "SR" Then
            DBFieldName = "Return No"
            TxtTitle.Text = "SALES RETURNS (DEBIT NOTE) REPORTS"
        ElseIf VhName = "POS" Then
            DBFieldName = "Invoice No"
            TxtTitle.Text = "SALES POS  REPORTS"
        End If
        ' Add any initialization after the InitializeComponent() call.
        
    End Sub
    Sub LoadListofOrders(Optional ByVal AddSqlText As String = "")
        If DBFieldName.Length = 0 Then Exit Sub
        If IsShowPendingsOnly.Checked = True Then
            SqlStr = "SELECT ROW_NUMBER() OVER (ORDER BY QutoNo) AS [S.NO],TransCode as [TransCode],TransDate as [Date],QutoNo as [" & DBFieldName & "],QutoRef as [Ref no],DelivaryDate as [Delivary Date],LedgerName as [Customer Name],nettotal as [Invoice Amount],(case IsPending when 0 then 'Completed' ELSE  'Pending' END)  as [Status],transtype as [ttype] from stockinvoicedetails where Isdelete=0 and IsPending=1 and vouchername=N'" & VhName & "' and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
        Else
            SqlStr = "SELECT ROW_NUMBER() OVER (ORDER BY QutoNo) AS [S.NO],TransCode as [TransCode],TransDate as [Date],QutoNo as [" & DBFieldName & "],QutoRef as [Ref no],DelivaryDate as [Delivary Date],LedgerName as [Customer Name],nettotal as [Invoice Amount],(case IsPending when 0 then 'Completed' ELSE  'Pending' END)  as [Status],transtype as [ttype] from stockinvoicedetails where Isdelete=0 and vouchername=N'" & VhName & "' and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
        End If

      
        SqlStr = SqlStr & AddSqlText

        Dim TempBS As New BindingSource

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            Me.TxtList.Columns("ttype").Visible = False
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
            Me.TxtList.Columns("Invoice Amount").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Invoice Amount").Width = 120
            Me.TxtList.Columns("Invoice Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.TxtList.Columns("Invoice Amount").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
        Catch ex As Exception

        End Try
        Select Case VhName
            Case "SO", "SQ"
                TxtList.Columns("Status").Visible = True
            Case "SI", "SD", "SR", "POS"
                TxtList.Columns("Status").Visible = False
        End Select
    End Sub

    Private Sub SalesTransactionReports_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
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


        LoadDataIntoComboBox("select distinct ledgername from  stockinvoicedetails ", TxtLedgerName, "ledgername", "*All")
        LoadDataIntoComboBox("select distinct salesperson from  stockinvoicedetails ", TxtSalesPerson, "salesperson", "*All")
        LoadDataIntoComboBox("select distinct area from  stockinvoicedetails ", TxtSalesArea, "area", "*All")
        TxtLedgerName.SetLedgerFilterType = SelectedLedgerNameClass.LedgerTypeEnum.Customers
        LoadListofOrders()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        LoadListofOrders()
    End Sub

    Private Sub IsShowPendingsOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsShowPendingsOnly.CheckedChanged
        LoadListofOrders()
    End Sub

    Private Sub TxtLedgerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.SelectedIndexChanged
        If TxtLedgerName.Text.Length = 0 Or TxtLedgerName.Text = "*All" Then
            LoadListofOrders()
        Else
            LoadListofOrders(" and ledgername=N'" & TxtLedgerName.Text & "'")
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
        EditTransactions()
    End Sub
    Sub EditTransactions()
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Row   ", MsgBoxStyle.Information)
            Exit Sub
        End If


        If TxtList.Item("transcode", TxtList.CurrentRow.Index).Value.ToString.Length > 0 Then
            If IsAuditConfirm(TxtList.Item("transcode", TxtList.CurrentRow.Index).Value, "Inventory") = True Then
                MsgBox("The Selected Entry can't be Editable....", MsgBoxStyle.Information)
                Exit Sub
            End If


            If VhName = "SO" Then
                Dim frm As New InvoiceAlterForm
                frm.TxtTitle.Text = "ALTER SALES ORDER"
                Dim K As New SalesControlAll("SO", TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
                K.BtnNew.Enabled = False
                K.BtnOpen.Enabled = False
                If TxtList.Item("Status", TxtList.CurrentRow.Index).Value <> "Pending" Then
                    K.BtnSave.Enabled = False
                End If
                frm.TxtList.Controls.Add(K)
                frm.TxtList.Controls(0).Dock = DockStyle.Fill
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()
                frm.Dispose()
                K.Dispose()
            ElseIf VhName = "SQ" Then
                Dim frm As New InvoiceAlterForm
                frm.TxtTitle.Text = "ALTER SALES QUOTE "
                Dim K As New SalesControlAll("SQ", TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
                K.BtnNew.Enabled = False
                K.BtnOpen.Enabled = False
                If TxtList.Item("Status", TxtList.CurrentRow.Index).Value <> "Pending" Then
                    K.BtnSave.Enabled = False
                End If
                frm.TxtList.Controls.Add(K)
                frm.TxtList.Controls(0).Dock = DockStyle.Fill
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()


                frm.Dispose()
                K.Dispose()
            ElseIf VhName = "SI" Then
                Dim frm As New InvoiceAlterForm
                frm.TxtTitle.Text = "ALTER SALES INVOICE "
                Dim K As New SalesControlAll("SI", TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
                K.BtnNew.Enabled = False
                K.BtnOpen.Enabled = False
                If TxtList.Item("Status", TxtList.CurrentRow.Index).Value <> "Pending" Then
                    K.BtnSave.Enabled = False
                End If
                frm.TxtList.Controls.Add(K)
                frm.TxtList.Controls(0).Dock = DockStyle.Fill
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()


                frm.Dispose()
                K.Dispose()
            ElseIf VhName = "SD" Then
                Dim frm As New InvoiceAlterForm
                frm.TxtTitle.Text = "ALTER SALES DELIVERY NOTE "
                Dim K As New SalesControlAll("SD", TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
                K.BtnNew.Enabled = False
                K.BtnOpen.Enabled = False
                If TxtList.Item("Status", TxtList.CurrentRow.Index).Value <> "Pending" Then
                    K.BtnSave.Enabled = False
                End If
                frm.TxtList.Controls.Add(K)
                frm.TxtList.Controls(0).Dock = DockStyle.Fill
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()


                frm.Dispose()
                K.Dispose()
            ElseIf VhName = "SR" Then
                Dim frm As New InvoiceAlterForm
                frm.TxtTitle.Text = "ALTER SALES RETURNS (DEBIT NOTE) "
                Dim K As New SalesControlAll("SR", TxtList.Item("transcode", TxtList.CurrentRow.Index).Value, TxtList.Item("ttype", TxtList.CurrentRow.Index).Value)
                K.BtnNew.Enabled = False
                K.BtnOpen.Enabled = False
                If TxtList.Item("Status", TxtList.CurrentRow.Index).Value <> "Pending" Then
                    K.BtnSave.Enabled = False
                End If
                frm.TxtList.Controls.Add(K)
                frm.TxtList.Controls(0).Dock = DockStyle.Fill
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()


                frm.Dispose()
                K.Dispose()
            ElseIf VhName = "POS" Then
                Dim frm As New InvoiceAlterForm
                frm.TxtTitle.Text = "ALTER SALES POS"
                Dim K As New SalesControlAll("POS", TxtList.Item("transcode", TxtList.CurrentRow.Index).Value, TxtList.Item("ttype", TxtList.CurrentRow.Index).Value)
                K.BtnNew.Enabled = False
                K.BtnOpen.Enabled = False
                If TxtList.Item("Status", TxtList.CurrentRow.Index).Value <> "Pending" Then
                    K.BtnSave.Enabled = False
                End If
                frm.TxtList.Controls.Add(K)
                frm.TxtList.Controls(0).Dock = DockStyle.Fill
                frm.WindowState = FormWindowState.Maximized
                frm.ShowDialog()


                frm.Dispose()
                K.Dispose()
            End If

            LoadListofOrders()
        End If

    End Sub
    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem.Click
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Row   ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If IsAuditConfirm(TxtList.Item("transcode", TxtList.CurrentRow.Index).Value, "Inventory") = True Then
            MsgBox("The Selected Entry can't be Editable....", MsgBoxStyle.Information)
            Exit Sub
        End If
        If MsgBox("Are u sure, Do you want to delete the selected Entry?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            Dim testlock As String = IsTransactionLocked(TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
            If testlock.Length = 0 Then
                If VhName = "SO" Then
                    Dim K As New SalesControlAll("SO", TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
                   K.IsOpenedOutsideforDelete = True
                    K.BtnNew.Enabled = False
                    K.BtnOpen.Enabled = False
                    K.OpenByTransCodeID(TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
                    K.DeleteOpenedInvoice()
                    K.Dispose()
                ElseIf VhName = "SQ" Then
                    Dim K As New SalesControlAll("SQ", TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
                    K.IsOpenedOutsideforDelete = True
                    K.BtnNew.Enabled = False
                    K.BtnOpen.Enabled = False
                    K.OpenByTransCodeID(TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
                    K.DeleteOpenedInvoice()
                    K.Dispose()
                ElseIf VhName = "SI" Then
                    Dim K As New SalesControlAll("SI", TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
                     K.IsOpenedOutsideforDelete = True
                    K.BtnNew.Enabled = False
                    K.BtnOpen.Enabled = False
                    K.OpenByTransCodeID(TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
                    K.DeleteOpenedInvoice()
                    K.Dispose()
                ElseIf VhName = "SD" Then
                    Dim K As New SalesControlAll("SD", TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
                    K.IsOpenedOutsideforDelete = True
                    K.BtnNew.Enabled = False
                    K.BtnOpen.Enabled = False
                    K.OpenByTransCodeID(TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
                    K.DeleteOpenedInvoice()
                    K.Dispose()
                ElseIf VhName = "SR" Then
                    Dim K As New SalesControlAll("SR", TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
                     K.IsOpenedOutsideforDelete = True
                    K.BtnNew.Enabled = False
                    K.BtnOpen.Enabled = False
                    K.OpenByTransCodeID(TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
                    K.DeleteOpenedInvoice()
                    K.Dispose()
                ElseIf VhName = "POS" Then
                    
                    Dim K As New SalesControlAll("POS", TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
                    K.IsOpenedOutsideforDelete = True
                    K.BtnNew.Enabled = False
                    K.BtnOpen.Enabled = False
                    K.OpenByTransCodeID(TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
                    K.DeleteOpenedInvoice()
                    K.Dispose()
                End If

                LoadListofOrders()
            Else
                MsgBox(testlock)
            End If

        End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, PrintToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then
            MsgBox("There is no data ..            ", MsgBoxStyle.Information)
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New InventoryTransactoionDataSet
        ds.Clear()
        For i As Integer = 0 To TxtList.RowCount - 1
            Dim row As DataRow
            row = ds.Tables(0).NewRow
            For k As Integer = 0 To TxtList.ColumnCount - 1
                If TxtList.Columns(k).Name = DBFieldName Then
                    row("orderno") = TxtList.Item(k, i).Value
                Else
                    Try
                        row(TxtList.Columns(k).Name) = TxtList.Item(k, i).Value
                    Catch ex As Exception
                        Try
                            row(TxtList.Columns(k).Name) = 0
                        Catch ex3 As Exception

                        End Try
                    End Try
                End If

            Next
            ds.Tables(0).Rows.Add(row)
        Next
        Dim objRpt As New InventoryTransactionCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtTitle.Text
            CType(objRpt.Section1.ReportObjects.Item("txtPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "For Period : " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date

        Else
            CType(objRpt.Section1.ReportObjects.Item("txtPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True
            CType(objRpt.Section1.ReportObjects.Item("txtPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtTitle.Text & Chr(13) & "For Period : " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date

        End If
        CType(objRpt.Section2.ReportObjects.Item("text3"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = DBFieldName
        objRpt.SetDataSource(ds)
        Dim FRM As New ReportCommonForm(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cursor = Cursors.Default
        FRM.ShowDialog()
        FRM.Dispose()
        objRpt.Dispose()
        ds.Dispose()
    End Sub
End Class