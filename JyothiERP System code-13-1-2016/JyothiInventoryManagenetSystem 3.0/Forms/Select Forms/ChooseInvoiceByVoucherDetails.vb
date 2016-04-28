Imports System.Windows.Forms

Public Class ChooseInvoiceByVoucherDetails
    Dim Isloaded As Boolean = False
    Dim LoadType As New ClsSelectInvDB
    Dim DbName As String = ""
    Dim DbNameForQuery As String = ""
    Dim InvNoFiled As String = ""
    Dim VhName As String = ""
    Dim Isreturn As Boolean = False
    Sub New(ByRef k As ClsSelectInvDB)

        ' This call is required by the designer.
        InitializeComponent()



        ' Add any initialization after the InitializeComponent() call.
        LoadType = k
        DbName = "StockInvoiceDetails"
        LoadType.SelectedDbDetailsName = DbName
        'LoadType.SelectedVoucherType=k.SelectedVoucherType 
        LoadType.SelectedDbRowItemsName = "StockInvoiceRowItems"
        If LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchasegoodsreceived Then
            InvNoFiled = "GoodRef"
            VhName = "PG"
            TxtVouchertypes.Items.Clear()
            TxtVouchertypes.Items.Add("From Purchase Enquiry")
            TxtVouchertypes.Items.Add("From Purchase Order")
            TxtVouchertypes.Items.Add("From Purchase Invoice")
            TxtVouchertypes.Text = "From Purchase Order"
            DbNameForQuery = "PurchOrderDetails"

        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchaseinvoice Then
            VhName = "PI"
            InvNoFiled = "InvoiceRef"
            TxtVouchertypes.Items.Clear()
            TxtVouchertypes.Items.Add("From Purchase Enquiry")
            TxtVouchertypes.Items.Add("From Purchase Goods Received Note")
            TxtVouchertypes.Items.Add("From Purchase Order")
            TxtVouchertypes.Text = "From Purchase Order"
            LoadType.OpenedInvType = ClsSelectInvDB.InvtypeStruct.purchaseinvoice
            DbNameForQuery = "PurchOrderDetails"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.DirectPurchase Then
            VhName = "DP"
            InvNoFiled = "InvoiceRef"
            TxtVouchertypes.Items.Clear()
            TxtVouchertypes.Items.Add("From Purchase Enquiry")
            TxtVouchertypes.Items.Add("From Purchase Order")
            TxtVouchertypes.Text = "From Purchase Order"
            LoadType.OpenedInvType = ClsSelectInvDB.InvtypeStruct.purchaseinvoice
            DbNameForQuery = "PurchOrderDetails"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchaseorder Then
            VhName = "PO"
            InvNoFiled = "OrderRef"
            TxtVouchertypes.Items.Clear()
            TxtVouchertypes.Items.Add("From Purchase Enquiry")
            LoadType.OpenedInvType = ClsSelectInvDB.InvtypeStruct.purchaseorder
            TxtVouchertypes.Text = "From Purchase Enquiry"
            DbNameForQuery = "PurchQutoDetails"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchasequto Then
            VhName = "PQ"
            InvNoFiled = "QutoRef"

            TxtVouchertypes.Items.Clear()
            TxtVouchertypes.Items.Add("From Purchase Enquiry")
            TxtVouchertypes.Text = "From Purchase Enquiry"
            TxtVouchertypes.Enabled = False
            LoadType.OpenedInvType = ClsSelectInvDB.InvtypeStruct.purchasequto
            DbNameForQuery = "PurchQutoDetails"

        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.PurchaseReturns Then
            VhName = "PQ"
            InvNoFiled = "QutoRef"
            Isreturn = True
            TxtVouchertypes.Items.Clear()
            TxtVouchertypes.Items.Add("From Purchase Invoice")
            TxtVouchertypes.Text = "From Purchase Invoice"
            TxtVouchertypes.Enabled = False
            LoadType.OpenedInvType = ClsSelectInvDB.InvtypeStruct.PurchaseReturns
            DbNameForQuery = "PurchInvoiceDetails"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesdelaverynote Then
            VhName = "SD"
            InvNoFiled = "GoodRef"
            TxtVouchertypes.Items.Clear()
            '    TxtVouchertypes.Items.Add("From Sales Quotation")
            TxtVouchertypes.Items.Add("From Sales Order")
            TxtVouchertypes.Items.Add("From Sales Invoice")
            TxtVouchertypes.Text = "From Sales Order"
            LoadType.OpenedInvType = ClsSelectInvDB.InvtypeStruct.salesdelaverynote

            DbNameForQuery = "SalesOrderDetails"


        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesinvoice Then
            VhName = "SI"
            InvNoFiled = "InvoiceRef"
            TxtVouchertypes.Items.Clear()
            ' TxtVouchertypes.Items.Add("From Sales Quotation")
            TxtVouchertypes.Items.Add("From Sales Delivery Note")
            TxtVouchertypes.Items.Add("From Sales Order")
            TxtVouchertypes.Text = "From Sales Delivery Note"
            LoadType.OpenedInvType = ClsSelectInvDB.InvtypeStruct.salesinvoice

            DbNameForQuery = "SalesOrderDetails"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesPOS Then
            VhName = "POS"
            InvNoFiled = "InvoiceRef"
            TxtVouchertypes.Items.Clear()
            TxtVouchertypes.Items.Add("From Sales Quotation")
            TxtVouchertypes.Items.Add("From Sales Order")
            TxtVouchertypes.Text = "From Sales Order"
            LoadType.OpenedInvType = ClsSelectInvDB.InvtypeStruct.salesPOS

            DbNameForQuery = "SalesOrderDetails"

        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesorder Then
            VhName = "SO"
            InvNoFiled = "OrderRef"
            TxtVouchertypes.Items.Clear()
            TxtVouchertypes.Items.Add("From Sales Quotation")
            LoadType.OpenedInvType = ClsSelectInvDB.InvtypeStruct.salesorder
            TxtVouchertypes.Text = "From Sales Quotation"
            DbNameForQuery = "SalesQutoDetails"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesquto Then
            VhName = "SQ"
            InvNoFiled = "QutoRef"

            LoadType.OpenedInvType = ClsSelectInvDB.InvtypeStruct.salesquto
            TxtVouchertypes.Enabled = False

            TxtVouchertypes.Items.Clear()
            TxtVouchertypes.Items.Add("From Sales Quotation")
            TxtVouchertypes.Text = "From Sales Quotation"
            DbNameForQuery = "SalesQutoDetails"

        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesReturns Then
            VhName = "SI"
            InvNoFiled = "QutoRef"
            Isreturn = True
            LoadType.OpenedInvType = ClsSelectInvDB.InvtypeStruct.salesReturns
            TxtVouchertypes.Enabled = False

            TxtVouchertypes.Items.Clear()
            TxtVouchertypes.Items.Add("From Sales Invoice")
            TxtVouchertypes.Text = "From Sales Invoice"

            DbNameForQuery = "SalesInvoiceDetails"
        End If
        If MyAppSettings.IsShowAllReferencesonBilling = True Then
            TxtLedgerName.Enabled = True
        Else
            TxtLedgerName.Enabled = False
        End If
        If TxtVouchertypes.Items.Count > 0 Then
            TxtVouchertypes.SelectedIndex = 0
        End If
    End Sub

    Private Sub TxtVouchertypes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtVouchertypes.SelectedIndexChanged
        SelectedIndexData()

        LoadData()
    End Sub
    Sub SelectedIndexData()
        If TxtVouchertypes.Text.Length = 0 Then Exit Sub
        If TxtVouchertypes.Text = "From Sales Quotation" Then
            LoadType.OpenedInvType = ClsSelectInvDB.InvtypeStruct.salesquto
            InvNoFiled = "QutoRef"
            VhName = "SQ"
            DbNameForQuery = "SalesQutoDetails"
        ElseIf TxtVouchertypes.Text = "From Sales Delivery Note" Then
            InvNoFiled = "GoodRef"
            VhName = "SD"
            DbNameForQuery = "SalesDeliveryDetails"
            LoadType.OpenedInvType = ClsSelectInvDB.InvtypeStruct.salesdelaverynote
        ElseIf TxtVouchertypes.Text = "From Sales Order" Then
            InvNoFiled = "OrderRef"
            VhName = "SO"
            DbNameForQuery = "SalesOrderDetails"
            LoadType.OpenedInvType = ClsSelectInvDB.InvtypeStruct.salesdelaverynote
        ElseIf TxtVouchertypes.Text = "From Purchase Enquiry" Then
            InvNoFiled = "QutoRef"
            VhName = "PQ"
            DbNameForQuery = "PurchQutoDetails"
            LoadType.OpenedInvType = ClsSelectInvDB.InvtypeStruct.purchasequto
        ElseIf TxtVouchertypes.Text = "From Purchase Goods Received Note" Then
            InvNoFiled = "GoodRef"
            VhName = "PG"
            DbNameForQuery = "PurchDeliveryDetails"
            LoadType.OpenedInvType = ClsSelectInvDB.InvtypeStruct.purchasequto
        ElseIf TxtVouchertypes.Text = "From Purchase Order" Then
            InvNoFiled = "OrderRef"
            VhName = "PO"
            DbNameForQuery = "PurchOrderDetails"
            LoadType.OpenedInvType = ClsSelectInvDB.InvtypeStruct.purchasegoodsreceived
        ElseIf TxtVouchertypes.Text = "From Sales Invoice" Then
            InvNoFiled = "OrderRef"
            VhName = "SI"
            DbNameForQuery = "SalesInvoiceDetails"
            LoadType.OpenedInvType = ClsSelectInvDB.InvtypeStruct.salesinvoice

        ElseIf TxtVouchertypes.Text = "From Purchase Invoice" Then
            InvNoFiled = "OrderRef"
            VhName = "PI"
            DbNameForQuery = "PurchInvoiceDetails"
            LoadType.OpenedInvType = ClsSelectInvDB.InvtypeStruct.purchaseorder
        End If

    End Sub
    Sub SetVouhcerType()
        If LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchasegoodsreceived Then
            InvNoFiled = "GoodRef"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchaseinvoice Then
            InvNoFiled = "InvoiceRef"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.DirectPurchase Then
            InvNoFiled = "InvoiceRef"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchaseorder Then
            InvNoFiled = "OrderRef"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchasequto Then
            InvNoFiled = "QutoRef"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesdelaverynote Then
            InvNoFiled = "GoodRef"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesinvoice Then
            InvNoFiled = "InvoiceRef"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesorder Then
            InvNoFiled = "OrderRef"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesquto Then
            InvNoFiled = "QutoRef"
        End If
    End Sub
    Sub LoadData(Optional ByVal SqlStrp As String = "")
        If Isloaded = False Then Exit Sub
        Dim SqlStr As String = ""
        If Isreturn = True Then
            If VhName = "SI" Then
                SqlStr = "select transdate as [Date],TransCode as [Trans Code],qutono as [Invoice No],qutoref as [" & InvNoFiled & "] ,ledgername as [Account Name],nettotal as [Value] from " & DbName & " Where  ledgername=N'" & TxtLedgerName.Text & "'  and  vouchername in ('POS','SI')  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ") and ((SELECT SUM(TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS Expr1 FROM StockInvoiceRowItems WHERE  (StockInvoiceRowItems.TransCode = StockInvoiceDetails.TransCode)) > 0) "
                SqlStr = SqlStr & SqlStrp
            Else
                SqlStr = "select transdate as [Date],TransCode as [Trans Code],qutono as [Invoice No],qutoref as [" & InvNoFiled & "] ,ledgername as [Account Name],nettotal as [Value] from " & DbName & " Where  ledgername=N'" & TxtLedgerName.Text & "'  and  vouchername in ('PI','DP')  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ") and ((SELECT SUM(TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS Expr1 FROM StockInvoiceRowItems WHERE  (StockInvoiceRowItems.TransCode = StockInvoiceDetails.TransCode)) > 0) "
                SqlStr = SqlStr & SqlStrp
            End If

        Else
            If VhName = "SQ" Or VhName = "PQ" Then
                If MyAppSettings.IsShowAllReferencesonBilling = False Then
                    If SqlStrp.Length = 0 Then
                        SqlStr = "select transdate as [Date],TransCode as [Trans Code],qutono as [Invoice No],qutoref as [" & InvNoFiled & "] ,ledgername as [Account Name],nettotal as [Value] from " & DbName & " Where LEDGERNAME=N'" & TxtLedgerName.Text & "' AND IsPending=1 and vouchername=N'" & VhName & "'  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ") "
                    Else
                        SqlStr = SqlStr & SqlStrp
                    End If
                Else
                    If SqlStrp.Length = 0 Then
                        SqlStr = "select transdate as [Date],TransCode as [Trans Code],qutono as [Invoice No],qutoref as [" & InvNoFiled & "] ,ledgername as [Account Name],nettotal as [Value] from " & DbName & " Where IsPending=1 and ledgername=N'" & TxtLedgerName.Text & "'  and  vouchername=N'" & VhName & "'  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ") "
                    Else
                        SqlStr = SqlStr & SqlStrp
                    End If
                End If
                If VhName = "PQ" Then
                    If MyAppSettings.IsAllowOnlyPurchaseEnquires = True Then
                        SqlStr = SqlStr & " AND IsApproved=1 "
                    End If
                End If
                If VhName = "SQ" Then
                    If MyAppSettings.IsAllowOnlySalesorders = True Then
                        SqlStr = SqlStr & " AND IsApproved=1 "
                    End If
                End If
            Else
                SqlStr = "select transdate as [Date],TransCode as [Trans Code],qutono as [Invoice No],qutoref as [" & InvNoFiled & "] ,ledgername as [Account Name],nettotal as [Value] from " & DbName & " Where  ledgername=N'" & TxtLedgerName.Text & "'  and  vouchername=N'" & VhName & "'  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ") and ((SELECT SUM(TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS Expr1 FROM StockInvoiceRowItems WHERE  (StockInvoiceRowItems.TransCode = StockInvoiceDetails.TransCode)) > 0) "
                SqlStr = SqlStr & SqlStrp
            End If
        End If

        SqlStr = SqlStr & " and vouchertype=N'" & LoadType.SelectedVoucherType & "' "
        Dim TempBS As New BindingSource



        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("date").DefaultCellStyle.Format = "d"
            TxtList.Columns("Date").Width = 70
            TxtList.Columns("Trans Code").Width = 60
            TxtList.Columns("Invoice No").Width = 80
            TxtList.Columns(InvNoFiled).Width = 80
            TxtList.Columns("Account Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("Account Name").Width = 120
            TxtList.Columns("Value").Width = 60
            TxtList.Columns("Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

        Catch ex As Exception

        End Try

    End Sub

    Sub LoadComboBoxItems()
        LoadDataIntoComboBox("select distinct ledgername from " & DbName, TxtLedgerName, "ledgername", "*All")

    End Sub

    Private Sub ChooseInvoiceByVoucherDetails_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub ChooseInvoiceNumber_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = Today
        LoadComboBoxItems()

        TxtLedgerName.Text = LoadType.SelectedLedgerName
        Isloaded = True
        If Isreturn = True Then
            LoadData()
        Else
            LoadData()
            LoadData("select transdate as [Date],TransCode as [Trans Code],qutono as [Invoice No],qutoref as [" & InvNoFiled & "] ,ledgername as [Account Name],nettotal as [Value] from " & DbName & " Where IsPending=1 and vouchername=N'" & VhName & "'  and ledgername=N'" & TxtLedgerName.Text & "'  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")")
        End If

    End Sub


    Private Sub TxtLedgerName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtStartDate.KeyDown, TxtEndDate.KeyDown, TxtInvoice.KeyDown, TxtList.KeyDown, TxtLedgerName.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return Then
            OkPressed()
        End If
    End Sub

    Private Sub TxtLedgerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.SelectedIndexChanged

        LoadData()
    End Sub



    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        LoadData()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        If MyAppSettings.IsShowAllReferencesonBilling = False Then
            If TxtInvoice.Text.Length = 0 Then
                LoadData("")
            Else
                LoadData("  and qutono LIKE N'%" & TxtInvoice.Text & "%' ")
            End If
        Else
            If TxtInvoice.Text.Length = 0 Then
                LoadData("")
            Else
                LoadData("  and qutono LIKE N'%" & TxtInvoice.Text & "%' ")
            End If
        End If


    End Sub


    Sub OkPressed()

        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Invoice Row....     ", MsgBoxStyle.Information)
            Exit Sub
        Else
            LoadType.ListofTrascodeadded.Rows.Clear()
            For Each x As DataGridViewRow In TxtList.SelectedRows
                Dim k As Integer
                k = LoadType.ListofTrascodeadded.Rows.Add
                LoadType.ListofTrascodeadded.Item("Transcode", k).Value = TxtList.Item("Trans Code", x.Index).Value
                LoadType.ListofTrascodeadded.Item("Dbname", k).Value = DbNameForQuery
                LoadType.SelectedTransCode = TxtList.Item("Trans Code", x.Index).Value
            Next
            Me.Close()
        End If
    End Sub


    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        OkPressed()
    End Sub

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Private Sub ImsGrid1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentDoubleClick
        OkPressed()
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        Me.Close()
    End Sub

    Private Sub TxtList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub
End Class
