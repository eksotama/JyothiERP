Public Class PDCForm
    Dim SqlStr As String = ""
    Sub LoadDef()
        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        LoadDataIntoComboBox("select distinct invoicetype from ledgerbook where invoicetype<>'Opening Balance'", TxtFilterBy, "invoicetype", "*All")
        LoadDataIntoComboBox("select ledgername from ledgers where AccountGroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.BankOD & "')", TxtBankName, "ledgername", "*All")

    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadData()
        SqlStr = "SELECT TransDate AS [Trans Date], TransCode AS [TransCode], InvoiceNo AS [Voucher No], LedgerName AS [Account name], Dr, Cr,  (CASE clearpdc WHEN 1 THEN 'Clear' ELSE 'Unclear' END) AS Status FROM LedgerBook WHERE  (IsDeleted = 0) AND (TransCode <> 0) AND  ispostdated='True'  "
        If TxtBankName.Text.Length = 0 Or TxtBankName.Text = "*All" Then
            SqlStr = SqlStr & " and ledgername in (select ledgername from ledgers where AccountGroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.BankOD & "')) "
        Else
            SqlStr = SqlStr & " and ledgername=N'" & TxtBankName.Text & "' "
        End If

        If TxtIsPeriod.Checked = True Then
            SqlStr = SqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
        End If
        If TxtShowAll.Checked = False Then
            SqlStr = SqlStr & " and  clearpdc='False' "
        End If
        If TxtFilterBy.Text.Length = 0 Or TxtFilterBy.Text = "*All" Then
        Else
            SqlStr = SqlStr & " and  invoicetype=N'" & TxtFilterBy.Text & "'"
        End If

        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
    End Sub

    Private Sub PDCForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub pdcformload_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDef()
        LoadData()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        LoadData()
    End Sub

   
    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMark.Click
        If TxtList.RowCount = 0 Then
            MsgBox("There is no data            ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtList.CurrentRow.Index >= 0 Then
            If MsgBox("Do you want to Mark as PDC clears ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("Update ledgerbook set clearPDC='True'  where transcode=" & TxtList.Item("TransCode", TxtList.CurrentRow.Index).Value)
                TxtList.Item("Status", TxtList.CurrentRow.Index).Value = "Clear"
                BtnMark.Enabled = False
                BtnUnMark.Enabled = True
            End If
        End If
    End Sub

    Private Sub BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnMark.Click
        If TxtList.RowCount = 0 Then
            MsgBox("There is no data            ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtList.CurrentRow.Index >= 0 Then
            If MsgBox("Do you want to UN MARK  as PDC clears             ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("Update ledgerbook set clearPDC='False'  where transcode=" & TxtList.Item("TransCode", TxtList.CurrentRow.Index).Value)
                TxtList.Item("Status", TxtList.CurrentRow.Index).Value = "Unclear"
                BtnMark.Enabled = True
                BtnUnMark.Enabled = False
            End If
        End If
    End Sub

    Private Sub TxtList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub

    Private Sub TxtList_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellEnter
        If SQLGetBooleanFieldValue("SELECT CLEARPDC FROM LEDGERBOOK WHERE transcode=" & TxtList.Item("TransCode", TxtList.CurrentRow.Index).Value, "CLEARPDC") = True Then
            BtnMark.Enabled = False
            BtnUnMark.Enabled = True
        Else
            BtnMark.Enabled = True
            BtnUnMark.Enabled = False
        End If
    End Sub

    Private Sub TxtFilterBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFilterBy.SelectedIndexChanged, TxtBankName.SelectedIndexChanged
        LoadData()
    End Sub
End Class