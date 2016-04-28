Imports System.Windows.Forms

Public Class ChooseInvoiceNumber
    Dim LoadType As New ClsSelectInvDB
    Dim DbName As String = ""
    Dim VhName As String = ""
    Dim InvNoFiled As String = ""
    Dim SalesTransactionType As String = ""
    Dim PosStr As String = ""
    Sub New(ByRef k As ClsSelectInvDB, Optional ByVal SalesTranstype As String = "", Optional ispos As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()
        SalesTransactionType = SalesTranstype
        PosStr = " "
        ' Add any initialization after the InitializeComponent() call.
        LoadType = k
        DbName = "StockInvoiceDetails"
        If LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchasegoodsreceived Then
            VhName = "PG"
            InvNoFiled = "GoodRef"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchaseinvoice Then

            InvNoFiled = "InvoiceRef"
            VhName = "PI"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchaseorder Then
            VhName = "PO"

            InvNoFiled = "OrderRef"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.purchasequto Then

            VhName = "PQ"
            InvNoFiled = "QutoRef"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesdelaverynote Then

            InvNoFiled = "GoodRef"
            VhName = "SD"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesinvoice Then

            InvNoFiled = "InvoiceRef"
            VhName = "SI"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesorder Then

            InvNoFiled = "OrderRef"
            VhName = "SO"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesquto Then

            InvNoFiled = "QutoRef"
            VhName = "SQ"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesReturns Then

            InvNoFiled = "QutoRef"
            VhName = "SR"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.PurchaseReturns Then

            InvNoFiled = "QutoRef"
            VhName = "PR"
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.salesPOS Then

            InvNoFiled = "QutoRef"
            VhName = "POS"
            If ispos = True Then
                PosStr = "  and (ismultipayment=0 or ismultipayment is null)   "
            Else
                PosStr = " "
            End If
        ElseIf LoadType.Invoicetype = ClsSelectInvDB.InvtypeStruct.DirectPurchase Then

            InvNoFiled = "QutoRef"
            VhName = "DP"
        End If
       
    End Sub
    
    Sub LoadData(Optional ByVal SqlStrp As String = "")
        Dim SqlStr As String = ""

        If SqlStrp.Length = 0 Then
            SqlStr = "select transdate as [Date],TransCode as [Trans Code],QutoNo as [Invoice No]," & InvNoFiled & " as [" & InvNoFiled & "] ,ledgername as [Account Name],nettotal as [Value] from " & DbName & " Where  isdelete=0 and vouchername=N'" & VhName & "'  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ") "
            If SalesTransactionType.Length > 0 Then
                SqlStr = SqlStr & " and transtype=N'" & SalesTransactionType & "'"
            End If
        Else
            If SalesTransactionType.Length > 0 Then
                SqlStr = SqlStrp & " and transtype=N'" & SalesTransactionType & "'"
            Else
                SqlStr = SqlStrp
            End If

        End If

        SqlStr = SqlStr & PosStr & " order by transcode "

        Dim TempBS As New BindingSource

       

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("date").DefaultCellStyle.Format = "d"
            TxtList.Columns("date").Width = 80
            TxtList.Columns("date").AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            TxtList.Columns("Trans Code").Width = 55
            TxtList.Columns("Trans Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Invoice No").Width = 80
            TxtList.Columns("Invoice No").AutoSizeMode = DataGridViewAutoSizeColumnMode.None


            TxtList.Columns(InvNoFiled).Width = 80
            TxtList.Columns(InvNoFiled).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            'InvNoFiled

            TxtList.Columns("Account Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("Account Name").Width = 120
            TxtList.Columns("Value").Width = 100
            TxtList.Columns("Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception

        End Try

    End Sub

    Sub LoadComboBoxItems()
        LoadDataIntoComboBox("select distinct ledgername from " & DbName, TxtLedgerName, "ledgername", "*All")
        LoadDataIntoComboBox("select distinct SalesPerson from " & DbName, TxtSalesPersons, "SalesPerson", "*All")
        LoadDataIntoComboBox("select distinct Area from " & DbName, TxtAreas, "Area", "*All")
        LoadDataIntoComboBox("select distinct ProjectName from " & DbName, TxtProjects, "ProjectName", "*All")
    End Sub

    Private Sub ChooseInvoiceNumber_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub ChooseInvoiceNumber_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = Today
        LoadComboBoxItems()
        LoadData()

    End Sub

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub

    Private Sub TxtLedgerName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLedgerName.KeyDown, TxtAreas.KeyDown, TxtProjects.KeyDown, TxtSalesPersons.KeyDown, TxtStartDate.KeyDown, TxtEndDate.KeyDown, TxtInvoice.KeyDown, TxtList.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return Then
            OkPressed()
        End If
    End Sub

    Private Sub TxtLedgerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.SelectedIndexChanged
        If TxtLedgerName.Text.Length = 0 Or TxtLedgerName.Text = "*All" Then
            LoadData("select transdate as [Date],TransCode as [Trans Code],QutoNo as [Invoice No]," & InvNoFiled & " as [" & InvNoFiled & "] ,ledgername as [Account Name],nettotal as [Value] from " & DbName & " Where  isdelete=0 and vouchername=N'" & VhName & "'  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")")
        Else

            LoadData("select transdate as [Date],TransCode as [Trans Code],QutoNo as [Invoice No]," & InvNoFiled & " as [" & InvNoFiled & "] ,ledgername as [Account Name],nettotal as [Value] from " & DbName & " Where  isdelete=0 and vouchername=N'" & VhName & "'  and ledgername=N'" & TxtLedgerName.Text & "'  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")")
        End If
    End Sub

    Private Sub TxtSalesPersons_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSalesPersons.SelectedIndexChanged
        If TxtSalesPersons.Text.Length = 0 Or TxtLedgerName.Text = "*All" Then
            LoadData("select transdate as [Date],TransCode as [Trans Code],QutoNo as [Invoice No]," & InvNoFiled & " as [" & InvNoFiled & "] ,ledgername as [Account Name],nettotal as [Value] from " & DbName & " Where  isdelete=0 and vouchername=N'" & VhName & "'  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")")
        Else

            LoadData("select transdate as [Date],TransCode as [Trans Code],QutoNo as [Invoice No]," & InvNoFiled & " as [" & InvNoFiled & "] ,ledgername as [Account Name],nettotal as [Value] from " & DbName & " Where  isdelete=0 and vouchername=N'" & VhName & "'  and SalesPerson=N'" & TxtSalesPersons.Text & "'  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")")
        End If
    End Sub

    Private Sub TxtAreas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAreas.SelectedIndexChanged
        If TxtAreas.Text.Length = 0 Or TxtLedgerName.Text = "*All" Then
            LoadData("select transdate as [Date],TransCode as [Trans Code],QutoNo as [Invoice No]," & InvNoFiled & " as [" & InvNoFiled & "] ,ledgername as [Account Name],nettotal as [Value] from " & DbName & " Where  isdelete=0 and vouchername=N'" & VhName & "'  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")")
        Else
            LoadData("select transdate as [Date],TransCode as [Trans Code],QutoNo as [Invoice No]," & InvNoFiled & " as [" & InvNoFiled & "] ,ledgername as [Account Name],nettotal as [Value] from " & DbName & " Where  isdelete=0 and vouchername=N'" & VhName & "'  and Area=N'" & TxtAreas.Text & "'  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")")
        End If
    End Sub

    Private Sub TxtProjects_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtProjects.SelectedIndexChanged
        If TxtProjects.Text.Length = 0 Or TxtLedgerName.Text = "*All" Then
            LoadData("select transdate as [Date],TransCode as [Trans Code],QutoNo as [Invoice No]," & InvNoFiled & " as [" & InvNoFiled & "] ,ledgername as [Account Name],nettotal as [Value] from " & DbName & " Where  isdelete=0 and vouchername=N'" & VhName & "'  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")")
        Else
            LoadData("select transdate as [Date],TransCode as [Trans Code],QutoNo as [Invoice No]," & InvNoFiled & " as [" & InvNoFiled & "] ,ledgername as [Account Name],nettotal as [Value] from " & DbName & " Where  isdelete=0 and vouchername=N'" & VhName & "'  and ProjectName=N'" & TxtProjects.Text & "'  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")")
        End If
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        LoadData()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        searchbyref()
    End Sub

    Sub searchbyref()
        If TxtInvoice.Text.Length = 0 Then
            LoadData("select transdate as [Date],TransCode as [Trans Code],QutoNo as [Invoice No]," & InvNoFiled & " as [" & InvNoFiled & "] ,ledgername as [Account Name],nettotal as [Value] from " & DbName & " Where  isdelete=0 and vouchername=N'" & VhName & "'  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")")

        Else
            If IsSearchByRef.Checked = True Then
                LoadData("select transdate as [Date],TransCode as [Trans Code],QutoNo as [Invoice No]," & InvNoFiled & " as [" & InvNoFiled & "] ,ledgername as [Account Name],nettotal as [Value] from " & DbName & " Where  isdelete=0 and vouchername=N'" & VhName & "'  and " & InvNoFiled & " LIKE N'%" & TxtInvoice.Text & "%' and   (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")")
            Else
                LoadData("select transdate as [Date],TransCode as [Trans Code],QutoNo as [Invoice No]," & InvNoFiled & " as [" & InvNoFiled & "] ,ledgername as [Account Name],nettotal as [Value] from " & DbName & " Where  isdelete=0 and vouchername=N'" & VhName & "'  and qutono LIKE N'%" & TxtInvoice.Text & "%' and   (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")")
            End If

        End If
    End Sub

    Private Sub ImsGrid1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentDoubleClick
        OkPressed()
    End Sub
    Sub OkPressed()
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Invoice Row....     ", MsgBoxStyle.Information)
            Exit Sub
        Else
            Dim tc As Single
            tc = TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value

            If CDbl(tc) <> 0 Then
                Dim testlock As String = IsTransactionLocked(tc)
                If testlock.Length = 0 Then
                    LoadType.SelectedTransCode = tc
                    Me.Close()
                Else
                    MsgBox(testlock)
                End If

            Else
                Exit Sub
            End If
        End If
    End Sub

    
    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        OkPressed()
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        Me.Close()
    End Sub

    Private Sub TxtInvoice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtInvoice.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            searchbyref()
        End If
    End Sub

    Private Sub TxtInvoice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtInvoice.TextChanged

    End Sub
End Class
