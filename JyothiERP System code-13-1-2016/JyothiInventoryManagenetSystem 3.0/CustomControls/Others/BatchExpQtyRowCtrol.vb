Public Class BatchExpQtyRowCtrol
    Public OldBarcode As String = ""
    Public OldLocation As String = ""
    Public OldBatchNo As String = ""
    Public oldqty1 As Double

    Public oldqty2 As Double
    Public Event MyCtrlLostFocus(ByVal e As Object)
    Public Event MyCtrlTextChange(ByVal e As Object)
    Public Sub SetUnitName(ByVal unitname As String)
        TxtQty.SetUnitName(unitname)
    End Sub
    Private Sub TxtBatchNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBatchNo.LostFocus
        RaiseEvent MyCtrlLostFocus(Me)
    End Sub

    Private Sub TxtExpiry_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtExpiry.LostFocus
        RaiseEvent MyCtrlLostFocus(Me)
    End Sub

    Private Sub TxtQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtQty.LostFocus

        RaiseEvent MyCtrlLostFocus(Me)
        Try

            RaiseEvent MyCtrlTextChange(Me)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TxtQty_ThisLostFocus(ByVal e As Object) Handles TxtQty.ThisLostFocus
        Try
            TxtTotalValue.Text = CDbl(TxtStockRate.Text) * TxtQty.GetTotalQty / TxtQty.GetConverionUnit
        Catch ex As Exception

        End Try
        RaiseEvent MyCtrlLostFocus(Me)
    End Sub

    Private Sub TxtStockRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtStockRate.LostFocus, TxtTotalValue.LostFocus
        RaiseEvent MyCtrlLostFocus(Me)
    End Sub

    Private Sub TxtStockRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockRate.TextChanged
        Try
            TxtTotalValue.Text = CDbl(TxtStockRate.Text) * TxtQty.GetTotalQty / TxtQty.GetConverionUnit
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BatchExpQtyRowCtrol_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
