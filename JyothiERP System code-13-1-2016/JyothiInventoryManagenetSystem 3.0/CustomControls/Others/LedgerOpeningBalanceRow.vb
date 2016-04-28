Public Class LedgerOpeningBalanceRow
    Public Event MyCtrlLostFocus(ByVal e As Object)
    Public Event MyCtrlTextChange(ByVal e As Object)
    Public Bill2BillTranscode As Single = 0

    Private Sub TxtAmount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDr.LostFocus
        If CDbl(TxtDr.Text) > 0 Then
            TxtCr.Text = "0"
        End If
        Try

            RaiseEvent MyCtrlLostFocus(Me)
        Catch ex As Exception

        End Try

    End Sub

    
    Private Sub TxtRefNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRefNo.TextChanged
        Try

            RaiseEvent MyCtrlTextChange(Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCr.LostFocus
        If CDbl(TxtCr.Text) > 0 Then
            TxtDr.Text = "0"
        End If
        Try

            RaiseEvent MyCtrlLostFocus(Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCr_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCr.TextChanged
        Try

            RaiseEvent MyCtrlTextChange(Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtDr_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDr.TextChanged
        Try

            RaiseEvent MyCtrlTextChange(Me)
        Catch ex As Exception

        End Try
    End Sub
End Class
