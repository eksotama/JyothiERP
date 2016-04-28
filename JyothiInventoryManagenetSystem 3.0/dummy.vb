Public Class dummy
    
    Private Sub dummy_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CostCenterMultiControl1.TotalCostValue = 4500
        CostCenterMultiControl1.AddNew()
    End Sub
End Class