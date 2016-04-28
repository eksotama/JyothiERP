Public Class VATLedgers
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Dim IslOaded As Boolean = False
    Dim Sqlstr As String = ""
    Dim RepSqlStr As String = ""
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub

#Region "Functions"

    Sub LoadLedgerAccounts(Optional ByVal sqlText As String = "")
        Dim TempBS As New BindingSource
        My.Application.DoEvents()
        Me.Cursor = Cursors.WaitCursor
        RepSqlStr = " "
        'Sqlstr = "SELECT LedgerCode as [Code], LedgerName as [vatname],AccountGroup as [Account Type],address as [Location],state as [State],Tel as [Contact Number],fax as [Fax Number],emailid as [Email  ID],f1 as [Balance] from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.DutiesTaxes & "'))"
        Sqlstr = "SELECT vatname as [Vat Name], vattax as [VAT Tax],inputvatledger as [Input VAT Ledger],outputvatledger as [Output VAT Ledger],PurchaseLedger as [Purchase Ledger],DebitNoteLedger as [Debit Note Ledger],SalesLedger as [Sales Ledger],CreditLedger as [Credit Note Ledger], Vattype as [Type] from vatclauses"
        If sqlText.Length > 0 Then
            Sqlstr = Sqlstr & sqlText
            RepSqlStr = sqlText
        End If
        Try
            Me.TxtList.Rows.Clear()
        Catch ex As Exception

        End Try

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns(0).Width = 150
            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(1).Width = 80
            Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(2).Width = 120
            Me.TxtList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(3).Width = 120

            Me.TxtList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(4).Width = 120

            Me.TxtList.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(5).Width = 120

            Me.TxtList.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(6).Width = 120

        Catch ex As Exception

        End Try

        Me.Cursor = Cursors.Default
    End Sub

#End Region
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        Dim k As New CreateVatLedgers
        k.ShowDialog()
        LoadLedgerAccounts()
    End Sub

    Private Sub VATLedgers_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub StockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadLedgerAccounts()


        IslOaded = True
    End Sub
    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        LoadLedgerAccounts()
    End Sub

    Private Sub TxtLedgerName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.TextChanged
        If TxtLedgerName.Text.Length = 0 Then
            LoadLedgerAccounts()
        Else
            LoadLedgerAccounts(" where  vatname LIKE N'%" & TxtLedgerName.Text & "%'")
        End If
    End Sub



    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        Dim kfrm As New LedgersPrintOptions("Ledgers", TxtList.Item("Vat Name", TxtList.CurrentRow.Index).Value)
        kfrm.ShowDialog()
        kfrm.Dispose()
       
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub TxtList_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.RowEnter
        On Error Resume Next
        If IslOaded = False Then Exit Sub
        Dim v_isactive As Boolean

        v_isactive = SQLGetStringFieldValue("SELECT ISACTIVE FROM vatclauses WHERE vatname=N'" & TxtList.Item("Vat Name", e.RowIndex).Value & "'", "ISACTIVE")
        If v_isactive = False Then
            BtnActivate.Text = "Activate"
        Else
            BtnActivate.Text = "DeActivate"
        End If

    End Sub

    Private Sub btnActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActivate.Click, AcitvateToolStripMenuItem.Click
        If IslOaded = False Then Exit Sub
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If BtnActivate.Text = "Activate" Then
            If MsgBox("Do you want to Activate the selected Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE vatclauses SET ISACTIVE='True' WHERE vatname=N'" & TxtList.Item("Vat Name", TxtList.CurrentRow.Index).Value & "'")
                BtnActivate.Text = "DeActivate"
                TxtList.Focus()
            End If
        Else
            If MsgBox("Do you want to De-Activate the selected Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE vatclauses SET ISACTIVE='False' WHERE vatname=N'" & TxtList.Item("Vat Name", TxtList.CurrentRow.Index).Value & "'")
                BtnActivate.Text = "Activate"
                TxtList.Focus()
            End If
        End If
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If APPUserRights.IsDeleteble = False Then
            MsgBox("The Delete Restricted by the Admin, No possible to Delete......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the vatname to delete...", MsgBoxStyle.Information)
            Exit Sub
        End If
        If SQLIsFieldExists("select stockcode from stockdbf where tax=" & CDbl(TxtList.Item("VAT Tax", TxtList.CurrentRow.Index).Value)) = True Then
            MsgBox("The Selected VAT Clause is already in used by stock items......", MsgBoxStyle.Critical)
            Exit Sub
        Else
            If MsgBox("Do you want to delete the Selected VAT Clause ?           ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("delete from vatclauses where vattax=" & CDbl(TxtList.Item("VAT Tax", TxtList.CurrentRow.Index).Value))
                LoadLedgerAccounts()
            End If
        End If

    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        MsgBox("The VAT rate is not recommend to modify, instead of this, you can create new VAT Class", MsgBoxStyle.Information)
        'Dim v_isactive As Boolean
        'v_isactive = SQLGetStringFieldValue("SELECT ISACTIVE FROM vatclauses WHERE vatname=N'" & TxtList.Item("Vat Name", TxtList.CurrentRow.Index).Value & "'", "ISACTIVE")
        Dim k As New CreateVatLedgers(TxtList.Item("Vat Name", TxtList.CurrentRow.Index).Value)
        k.ShowDialog()
        LoadLedgerAccounts()
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click, ReportsToolStripMenuItem.Click
        If TxtList.SelectedRows.Count > 0 Then
       
        End If
    End Sub
End Class