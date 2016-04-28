Imports System.Windows.Forms

Public Class SelectPayRollVoucher
    Sub LoadData(Optional ByVal SqlStrp As String = "")
        Dim SqlStr As String = ""

        If SqlStrp.Length = 0 Then
            SqlStr = "select  Transcode as [Trans Code],voucherno as [Voucher No],transdate as [Vh Date],NetTotal AS [Total Amount] from payrollVoucherMasterData where (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")  "
            SqlStr = SqlStr & SqlStrp
        Else
            SqlStr = "select  Transcode as [Trans Code],voucherno as [Voucher No],transdate as [Vh Date],NetTotal AS [Total Amount] from payrollVoucherMasterData where (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")  "
        End If

        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("Vh Date").DefaultCellStyle.Format = "d"
            TxtList.Columns("Vh Date").Width = 60
            'TxtList.Columns("Trans Codee").Visible = False
        Catch ex As Exception

        End Try

    End Sub
   
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        LoadData()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        LoadData(" and voucherno like N'%" & TxtInvoice.Text & "%'")
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        OkPressed()
    End Sub
    Sub OkPressed()
        OpendedPayRollTransCode = 0
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Invoice Row....     ", MsgBoxStyle.Information)
            Exit Sub
        Else
            Dim tc As Single
            tc = TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value

            If CDbl(tc) <> 0 Then
                Dim testlock As String = IsTransactionLocked(tc)
                If testlock.Length = 0 Then
                    OpendedPayRollTransCode = tc
                    Me.Close()
                Else
                    MsgBox(testlock)
                End If

            Else
                Exit Sub
            End If
        End If
    End Sub
    Private Sub TxtLedgerName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtStartDate.KeyDown, TxtEndDate.KeyDown, TxtInvoice.KeyDown, TxtList.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return Then
            OkPressed()
        End If
    End Sub

    Private Sub SelectPayRollVoucher_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub SelectPayRollVoucher_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        LoadData()
    End Sub
End Class
