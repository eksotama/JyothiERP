Public Class PayRollNewRowControl
    Public Event AmountLostFocus(ByVal e As Object)
    Public Event ItemListAddedEvent(ByVal e As Object)
    Public Event AmountValidatting()
    Public Event CostLostFocus()

    Private Sub TxtValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDrCr.LostFocus

        RaiseEvent AmountLostFocus(Me)
    End Sub

    Private Sub TxtValue_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtValue.Validating
        On Error Resume Next
        If TxtPayRollLedgerName.Text <> "*End Of List" Then
            If CDbl(TxtValue.Text) <= 0 Then
                e.Cancel = True
                Exit Sub
            End If
        Else
            RaiseEvent AmountLostFocus(Me)
        End If
        RaiseEvent AmountValidatting()
    End Sub

    Private Sub TxtCostName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPayRollLedgerName.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            Dim k As New CreatePayrollLedgers
            k.ShowDialog()
            k.Dispose()
            RaiseEvent ItemListAddedEvent(Me)
        End If
    End Sub

    Private Sub TxtCostName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPayRollLedgerName.LostFocus
        'TxtValue.Focus()
        RaiseEvent CostLostFocus()
    End Sub

    Private Sub CostCenterRow_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        TxtPayRollLedgerName.Focus()
    End Sub

    Private Sub CostCenterRow_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ERPInitializeObjects(Me)
        TxtPayRollLedgerName.Focus()
    End Sub


    Private Sub TxtCostName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPayRollLedgerName.SelectedIndexChanged
        If TxtDrCr.Text.Length = 0 Then
            TxtDrCr.Text = "Dr"
        End If
        If TxtPayRollLedgerName.Text <> "*End Of List" Then
            TxtBalanceVal.Text = GetCurrentBalanceText(TxtPayRollLedgerName.Text)
        End If
    End Sub

    
End Class
