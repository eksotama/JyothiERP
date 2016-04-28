Public Class BatchExpiryRow
    Public OldBarcode As String = ""
    Public OldLocation As String = ""
    Public OldBatchNo As String = ""
    Public oldqty1 As Double
    Public oldqty2 As Double
    Public Event MyCtrlLostFocus(ByVal e As Object)
    Public Event MyCtrlTextChange(ByVal e As Object)
    Public IsBatchWise As Boolean = False
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
        If TxtQty.GetTotalQty() > 0 Then
            Button1.Visible = True
        Else
            Button1.Visible = False
        End If
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

    Private Sub TxtLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLocation.SelectedIndexChanged
        RaiseEvent MyCtrlLostFocus(Me)
    End Sub
    Public Sub SetForExpryBatch(ByVal value As Boolean)
        If value = True Then
            TxtStockRate.Enabled = False
            TxtTotalValue.Enabled = False
            Button1.Enabled = True
            Button1.Visible = True
            IsBatchWise = True
        Else
            TxtStockRate.Enabled = True
            TxtTotalValue.Enabled = True
            Button1.Enabled = False
            Button1.Visible = False
            IsBatchWise = False
        End If
    End Sub

    Private Sub TxtStockRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtStockRate.LostFocus, TxtTotalValue.LostFocus
        RaiseEvent MyCtrlLostFocus(Me)
    End Sub

   
    Private Sub TxtQty_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtQty.Load

    End Sub

    Private Sub TxtStockRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockRate.TextChanged
        Try
            TxtTotalValue.Text = CDbl(TxtStockRate.Text) * TxtQty.GetTotalQty / TxtQty.GetConverionUnit
        Catch ex As Exception

        End Try
    End Sub
    Public Function GetBatchWiseTotalQty() As Double
        Dim kt As Double = 0
        For i As Integer = 0 To TxtBatchList.RowCount - 1
            kt = kt + CDbl(TxtBatchList.Item("ttotalqty", i).Value)
        Next
        Return kt
    End Function
    Public Function GetBatchWiseTotalValue() As Double
        Dim kt As Double = 0
        For i As Integer = 0 To TxtBatchList.RowCount - 1
            kt = kt + CDbl(TxtBatchList.Item("tvalue", i).Value)
        Next
        Return kt
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TxtQty.GetTotalQty() = 0 Then
            TxtStockRate.Text = "0"
            TxtTotalValue.Text = "0"
            TxtBatchList.Rows.Clear()
            Exit Sub
        End If
        Dim frm As New ReadOpBatchNoExpiry(TxtBatchList, TxtLocation.Text, TxtQty.GetTotalQty, TxtQty.GetUnitName)
        frm.TxtQty.SetUnitName(TxtQty.GetUnitName)
        frm.TxtList.Rows.Clear()
        For i As Integer = 0 To TxtBatchList.RowCount - 1
            Dim rno As Integer = 0
            rno = frm.TxtList.Rows.Add
            frm.TxtList.Item("tlocation", rno).Value = TxtBatchList.Item("tlocation", i).Value
            frm.TxtList.Item("tbatchno", rno).Value = TxtBatchList.Item("tbatchno", i).Value
            frm.TxtList.Item("texpiry", rno).Value = TxtBatchList.Item("texpiry", i).Value
            frm.TxtList.Item("tqtytext", rno).Value = TxtBatchList.Item("tqtytext", i).Value
            frm.TxtList.Item("tmrp", rno).Value = TxtBatchList.Item("tmrp", i).Value
            frm.TxtList.Item("trate", rno).Value = TxtBatchList.Item("trate", i).Value
            frm.TxtList.Item("tvalue", rno).Value = TxtBatchList.Item("tvalue", i).Value
            frm.TxtList.Item("ttotalqty", rno).Value = TxtBatchList.Item("ttotalqty", i).Value
            frm.TxtList.Item("tmainunitqty", rno).Value = TxtBatchList.Item("tmainunitqty", i).Value
            frm.TxtList.Item("tsubunitqty", rno).Value = TxtBatchList.Item("tsubunitqty", i).Value


        Next

        frm.ShowDialog()
        If TxtQty.GetTotalQty <> GetBatchWiseTotalQty() Then
            TxtQty.Focus()
        Else
            TxtStockRate.Text = FormatNumber(GetBatchWiseTotalValue() / (TxtQty.GetTotalQty / TxtQty.GetConverionUnit), ErpDecimalPlaces, , , TriState.False)
            TxtTotalValue.Text = GetBatchWiseTotalValue()
            Me.Parent.TopLevelControl.SelectNextControl(sender, True, True, True, True)
        End If
       
    End Sub
    Public Function IsBatchNoQtyMatches() As Boolean
        Dim val As Boolean = False
        If TxtQty.GetTotalQty <> GetBatchWiseTotalQty() Then
            val = False
        Else
            val = True
        End If
        Return val
    End Function
   
End Class
