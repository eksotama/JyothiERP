Public Class OpeningStockQtyRow
    Public Event MyCtrlLostFocus(ByVal e As Object)
    Public Sub SetUnitName(ByVal unitname As String)
        TxtQty.SetUnitName(unitname)
    End Sub

    Private Sub TxtQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtQty.LostFocus
        RaiseEvent MyCtrlLostFocus(Me)
    End Sub

    Private Sub TxtQty_ThisLostFocus(ByVal e As Object) Handles TxtQty.ThisLostFocus
        RaiseEvent MyCtrlLostFocus(Me)
    End Sub

    Private Sub OpeningStockQtyRow_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        RaiseEvent MyCtrlLostFocus(Me)
    End Sub
End Class
