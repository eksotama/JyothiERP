Public Class PayrollLedgers
    Dim Sqlstr As String = ""
    Dim IslOaded As Boolean = False

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
#Region "Functions"
    Sub LoadSuppliersList(Optional ByVal sqlText As String = "")

        My.Application.DoEvents()
        Me.Cursor = Cursors.WaitCursor
        Sqlstr = "SELECT LedgerCode as [Code], LedgerName as [Pay Head Name],AccountGroup as [Account Type],f1 as [Balance] from ledgers where n1=2 "
        If sqlText.Length > 0 Then
            Sqlstr = Sqlstr & sqlText
        End If
        Try
            Me.TxtList.Rows.Clear()
        Catch ex As Exception

        End Try
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(0).Width = 60
            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns(1).Width = 250
            Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(2).Width = 300
            Me.TxtList.Columns("balance").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            For i As Integer = 0 To TxtList.RowCount - 1
                TxtList.Item("Balance", i).Value = GetCurrentBalanceText(TxtList.Item("Pay Head Name", i).Value)
            Next
        Catch ex As Exception

        End Try

        Me.Cursor = Cursors.Default
    End Sub
#End Region

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        Dim k As New CreatePayrollLedgers()
        k.ShowDialog()
        LoadSuppliersList()
    End Sub

    Private Sub PayrollLedgers_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub StockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        LoadDataIntoComboBox("select subgroup from AccountGroupsList ", TxtAccountGroup, "subgroup")
        TxtAccountGroup.Items.Add("*All")
        LoadSuppliersList()

        IslOaded = True
    End Sub

    Private Sub TxtList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles TxtList.CellFormatting
        For i As Integer = 0 To TxtList.RowCount - 1
            If TxtList.Item("balance", i).Value.ToString.Contains("Dr") = True Then
                TxtList.Rows(i).DefaultCellStyle.BackColor = Color.Bisque
            Else
                TxtList.Rows(i).DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub TxtList_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.RowEnter
        On Error Resume Next
        Dim v_isactive As Integer

        v_isactive = SQLGetNumericFieldValue("SELECT ISACTIVE FROM LEDGERS WHERE LEDGERNAME=N'" & TxtList.Item("Pay Head Name", e.RowIndex).Value & "'", "ISACTIVE")
        If v_isactive = 0 Then
            btnActivate.Text = "Activate"
        Else
            btnActivate.Text = "DeActivate"
        End If

    End Sub

    Private Sub btnActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivate.Click, DEACTIVATEToolStripMenuItem.Click
        If IslOaded = False Then Exit Sub
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If btnActivate.Text = "Activate" Then
            If MsgBox("Do you want to Activate the selected Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE LEDGERS SET ISACTIVE=1 WHERE LEDGERNAME=N'" & TxtList.Item("Pay Head Name", TxtList.CurrentRow.Index).Value & "'")
                btnActivate.Text = "DeActivate"
                TxtList.Focus()
            End If
        Else
            If MsgBox("Do you want to De-Activate the selected Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE LEDGERS SET ISACTIVE=0 WHERE LEDGERNAME=N'" & TxtList.Item("Pay Head Name", TxtList.CurrentRow.Index).Value & "'")
                btnActivate.Text = "Activate"
                TxtList.Focus()
            End If
        End If
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, EditToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        dELETEfUCTION()


    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If APPUserRights.IsEditable = False Then
            MsgBox("The Edit Restricted by the Admin, Not possible to Edit......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If TxtList.SelectedRows.Count = 0 Then
            Exit Sub
        End If

        Dim v_isactive As Integer
        v_isactive = SQLGetNumericFieldValue("SELECT ISACTIVE FROM LEDGERS WHERE LEDGERNAME=N'" & TxtList.Item("Pay Head Name", TxtList.CurrentRow.Index).Value & "'", "ISACTIVE")
        Dim k As New CreatePayrollLedgers(TxtList.Item("Pay Head Name", TxtList.CurrentRow.Index).Value)
        If v_isactive = 0 Then
            k.TxtLedgerName.Enabled = False
        End If
        k.ShowDialog()
        LoadSuppliersList()
    End Sub

    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        LoadSuppliersList()
    End Sub
    Private Sub TxtAccountGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAccountGroup.SelectedIndexChanged
        If TxtAccountGroup.Text = "*All" Or TxtAccountGroup.Text.Length = 0 Then
            LoadSuppliersList()
        Else
            LoadSuppliersList(" and AccountGroup=N'" & TxtAccountGroup.Text & "'")
        End If
    End Sub

    Private Sub TxtLedgerName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.TextChanged
        If TxtLedgerName.Text.Length = 0 Then
            LoadSuppliersList()
        Else
            LoadSuppliersList(" and  LedgerName LIKE N'%" & TxtLedgerName.Text & "%'")
        End If
    End Sub

    Private Sub TxtLedgerCity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerCity.TextChanged
        If TxtLedgerCity.Text.Length = 0 Then
            LoadSuppliersList()
        Else
            LoadSuppliersList(" and  address LIKE N'%" & TxtLedgerCity.Text & "%'")
        End If
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        Dim kfrm As New LedgersPrintOptions("Payroll", TxtList.Item("Pay Head Name", TxtList.CurrentRow.Index).Value)
        kfrm.ShowDialog()
        kfrm.Dispose()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Dim k As New CreatePayrollLedgers()
        k.ShowDialog()
        LoadSuppliersList()
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        If TxtList.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        Dim v_isactive As Integer
        v_isactive = SQLGetNumericFieldValue("SELECT ISACTIVE FROM LEDGERS WHERE LEDGERNAME=N'" & TxtList.Item("Pay Head Name", TxtList.CurrentRow.Index).Value & "'", "ISACTIVE")
        If v_isactive = 0 Then
            MsgBox("This Account is In-Active...., Edit is not possible....")
            Exit Sub
        End If
        Dim k As New CreatePayrollLedgers(TxtList.Item("Pay Head Name", TxtList.CurrentRow.Index).Value)
        k.ShowDialog()
        LoadSuppliersList()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        dELETEfUCTION()
    End Sub
    Sub dELETEfUCTION()
        If APPUserRights.IsDeleteble = False Then
            MsgBox("The Delete Restricted by the Admin, No possible to Delete......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Pay Head Name to delete...", MsgBoxStyle.Information)
            Exit Sub
        End If
        If SQLIsFieldExists("SELECT TOP 1 1 from   ledgerbook where ledgername=N'" & TxtList.Item("Pay Head Name", TxtList.CurrentRow.Index).Value & "' and transcode>0") = True Then
            MsgBox("The Pay Head  is already used in accounts, It is not possible to delete the ledger..")
            Exit Sub
        Else
            If MsgBox("Do You want to Delete The Pay Head  Account ?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("Delete from ledgers where ledgername=N'" & TxtList.Item("Pay Head Name", TxtList.CurrentRow.Index).Value & "'")
                ExecuteSQLQuery("UPDATE DEFLEDGERS SET ledgername=N'' WHERE ledgername=N'" & TxtList.Item("Pay Head Name", TxtList.CurrentRow.Index).Value & "'")
                LoadDefLedgerValues()
                LoadSuppliersList()
            End If

        End If
    End Sub

End Class