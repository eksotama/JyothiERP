Public Class CostCenterMultiControl
    Dim CtrlCount As Integer = 0
    Dim TotalValue As Double = 0
    Public Property TotalCostValue() As Double
        Get
            Return TotalValue
        End Get
        Set(ByVal value As Double)
            TotalValue = value
            Invalidate()
        End Set
    End Property

    Sub AddNew()
        Dim ka As New CostCenterControl
        ka.Anchor = AnchorStyles.Left
        ka.Anchor = AnchorStyles.Top
        ka.Anchor = AnchorStyles.Right
        AddHandler ka.AmountIsTally, AddressOf MeLostFocus
        mtb.Controls.Add(ka)
        Try
            mtb.Controls(mtb.Controls.Count - 1).Focus()
            CType(mtb.Controls(mtb.Controls.Count - 1), CostCenterRow).TxtCostName.Focus()
        Catch ex As Exception

        End Try
        CtrlCount = mtb.Controls.Count
    End Sub
    Sub MeLostFocus()
        ' AddNew()
    End Sub
End Class
