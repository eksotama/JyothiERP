Public Class CostCenterRow
    Public Event AmountLostFocus(ByVal e As Object)
    Public Event ItemListAddedEvent(ByVal e As Object)
    Public Event AmountValidatting()
    Public Event CostLostFocus()

    Private Sub TxtValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtValue.LostFocus
        RaiseEvent AmountLostFocus(Me)
    End Sub

    Private Sub TxtValue_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtValue.Validating
        On Error Resume Next
        If CDbl(TxtValue.Text) <= 0 Then
            e.Cancel = True
            Exit Sub
        End If
        RaiseEvent AmountValidatting()
    End Sub

    Private Sub TxtCostName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCostName.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            Dim k As New CreateNewCostCenterNames
            k.ShowDialog()
            k.Dispose()
            RaiseEvent ItemListAddedEvent(Me)
        End If
    End Sub

    Private Sub TxtCostName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCostName.LostFocus
        'TxtValue.Focus()
        RaiseEvent CostLostFocus()
    End Sub

    Private Sub CostCenterRow_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        TxtCostName.Focus()
    End Sub

    Private Sub CostCenterRow_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtCostName.Focus()
    End Sub

   
End Class
