Imports System.Windows.Forms

Public Class SelectLedgerNameForm
    'LedgerCode,LedgerName,address
    Dim TypeSQlstr As String = " (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "'))"
    Sub loadstockitems(Optional ByVal SqlStrOp As String = "")
        Dim Sqlstr As String = ""
        If SqlStrOp.Length = 0 Then
            Sqlstr = "SELECT [LedgerCode] as [Code],  [LedgerName] as [Account Name], [address] as [Address] FROM [ledgers] where " & TypeSQlstr & " and  Isactive=1"
        Else
            Sqlstr = SqlStrOp
        End If

        Dim TempBS As New BindingSource

        Try
            Me.TxtList.Rows.Clear()
        Catch ex As Exception

        End Try

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtList.Columns(0).Width = 105
        Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.TxtList.Columns(1).Width = 150
        Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtList.Columns(2).Width = 180
    End Sub

    Private Sub ChooseItems_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtLedgerName.Focus()
        TxtLedgerName.Text = SelectedAcName.CurrentChar
        Try
            TxtLedgerName.SelectionStart = 1
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ChooseItems_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If SelectedAcName.LedgerType = SelectedLedgerNameClass.LedgerTypeEnum.Customers Then
            TypeSQlstr = " (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "'  or groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "'))"
        ElseIf SelectedAcName.LedgerType = SelectedLedgerNameClass.LedgerTypeEnum.Customersandsupplierswithcashandbanks Then
            TypeSQlstr = " (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CustomersAccounts & "'  or groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "'))"
        ElseIf SelectedAcName.LedgerType = SelectedLedgerNameClass.LedgerTypeEnum.suppliers Then
            TypeSQlstr = " (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "'))"
        ElseIf SelectedAcName.LedgerType = SelectedLedgerNameClass.LedgerTypeEnum.Expenses Then
            TypeSQlstr = " (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.DirectExpenses & "'))"
        ElseIf SelectedAcName.LedgerType = SelectedLedgerNameClass.LedgerTypeEnum.incomes Then
            TypeSQlstr = " (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectIncomes & "' or groupname=N'" & AccountGroupNames.DirectIncomes & "'))"
        ElseIf SelectedAcName.LedgerType = SelectedLedgerNameClass.LedgerTypeEnum.assets Then
            TypeSQlstr = " (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CurrentAssets & "' or groupname=N'" & AccountGroupNames.FixedAssets & "'))"
        ElseIf SelectedAcName.LedgerType = SelectedLedgerNameClass.LedgerTypeEnum.laibilities Then
            TypeSQlstr = " (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CurrentLiabilities & "' or groupname=N'" & AccountGroupNames.DutiesTaxes & "'))"
        ElseIf SelectedAcName.LedgerType = SelectedLedgerNameClass.LedgerTypeEnum.BothExpIncomes Then
            TypeSQlstr = " (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.DirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "' or groupname=N'" & AccountGroupNames.DirectIncomes & "'))"
        ElseIf SelectedAcName.LedgerType = SelectedLedgerNameClass.LedgerTypeEnum.BothExpIncomes Then
            TypeSQlstr = " Accountgroup<>''"
        End If
        loadstockitems()
    End Sub
    Sub AcceptValues()
        SelectedAcName.SelectedLedgerName = ""
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Item from the list.............. ", MsgBoxStyle.Information)
            TxtList.Focus()
            Exit Sub
        Else
            SelectedAcName.SelectedLedgerName = TxtList.Item("Account Name", TxtList.CurrentRow.Index).Value
        End If

        Me.Close()
    End Sub
    Private Sub TxtStockCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLedgerName.KeyDown, TxtLedgerCity.KeyDown, TxtLedgerCode.KeyDown, TxtList.KeyDown
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

    Private Sub TxtLedgerName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.TextChanged

        Dim str As String = ""
        If TxtLedgerName.Text.Length = 0 Then
            str = "SELECT [LedgerCode] as [Code],  [LedgerName] as [Account Name], [address] as [Address] FROM [ledgers] where " & TypeSQlstr & " and  Isactive=1"
        Else
            str = "SELECT [LedgerCode] as [Code],  [LedgerName] as [Account Name], [address] as [Address] FROM [ledgers] where " & TypeSQlstr & " and  Isactive=1  and LedgerName LIKE N'%" & TxtLedgerName.Text & "%'"
        End If

        loadstockitems(str)
    End Sub



    Private Sub TxtLedgerCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerCode.TextChanged
        Dim str As String = ""
        If TxtLedgerCode.Text.Length = 0 Then
            str = "SELECT [LedgerCode] as [Code],  [LedgerName] as [Account Name], [address] as [Address] FROM [ledgers] where " & TypeSQlstr & " and  Isactive=1"
        Else
            str = "SELECT [LedgerCode] as [Code],  [LedgerName] as [Account Name], [address] as [Address] FROM [ledgers] where " & TypeSQlstr & " and  Isactive=1  and LedgerCode LIKE N'%" & TxtLedgerCode.Text & "%'"
        End If
        loadstockitems(str)
    End Sub

    Private Sub TxtLedgerCity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerCity.TextChanged
        Dim str As String = ""
        If TxtLedgerCity.Text.Length = 0 Then
            str = "SELECT [LedgerCode] as [Code],  [LedgerName] as [Account Name], [address] as [Address] FROM [ledgers] where " & TypeSQlstr & " and  Isactive=1"
        Else
            str = "SELECT [LedgerCode] as [Code],  [LedgerName] as [Account Name], [address] as [Address] FROM [ledgers] where " & TypeSQlstr & " and  Isactive=1  and LedgerCode LIKE N'%" & TxtLedgerCity.Text & "%'"
        End If
        loadstockitems(str)

    End Sub

    Private Sub TxtList_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentDoubleClick
        AcceptValues()
    End Sub

    Private Sub TxtList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellDoubleClick
        AcceptValues()
    End Sub

   
    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        AcceptValues()
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click

       
        If SelectedAcName.LedgerType = SelectedLedgerNameClass.LedgerTypeEnum.Customers Then
            Dim k As New CreateCustomers
            k.ShowDialog()
        ElseIf SelectedAcName.LedgerType = SelectedLedgerNameClass.LedgerTypeEnum.suppliers Then
            Dim k As New CreateSuppliers
            k.ShowDialog()
        Else
            Dim k As New CreateLedgerAccounts
            k.ShowDialog()
        End If

        loadstockitems()
    End Sub

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
End Class
