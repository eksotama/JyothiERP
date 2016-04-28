Public Class OpeningStockQty
    Public ThiUnitName As String
    Public Sub SetUnitNames(ByVal unitname)
        ThiUnitName = unitname
        ChangeUnits()
    End Sub
    Public Sub ChangeUnits()
        Try
            For i As Integer = 0 To Panel1.Controls.Count
                CType(Panel1.Controls(i), OpeningStockQtyRow).TxtQty.SetUnitName(ThiUnitName)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AddNew()
        Dim ka As New OpeningStockQtyRow
        ka.Anchor = AnchorStyles.Left
        ka.Anchor = AnchorStyles.Top
        ka.Anchor = AnchorStyles.Right
        ka.TxtQty.SetUnitName(ThiUnitName)
        ka.TxtQty.TxtQty1.Text = "0"
        ka.TxtQty.TxtQty2.Text = "0"
        ka.Visible = True
        LoadDataIntoComboBox("select locationname  from StockLocations", ka.TxtLocation, "locationname")
        AddHandler ka.MyCtrlLostFocus, AddressOf CtrlLostFocus
        Panel1.Controls.Add(ka)
    End Sub
    Public Sub ClearAll()
        Try
            For i As Integer = 0 To Panel1.Controls.Count - 1
                Panel1.Controls.RemoveAt(i)
            Next
        Catch ex As Exception

        End Try

        AddNew()
    End Sub

    Private Sub IMSBatchNoExpiryControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ERPInitializeObjects(Me)
    End Sub
    Public Function GetRows() As Integer
        Return Panel1.Controls.Count
    End Function
    Public Function GetItem(ByVal colno As Integer, ByVal rowno As Integer) As String
        If colno = 0 Then
            Return CType(Panel1.Controls(rowno), OpeningStockQtyRow).TxtLocation.Text
        ElseIf colno = 1 Then
            Return CType(Panel1.Controls(rowno), OpeningStockQtyRow).TxtQty.TxtQty1.Text
        ElseIf colno = 2 Then
            Return CType(Panel1.Controls(rowno), OpeningStockQtyRow).TxtQty.TxtQty2.Text
        Else
            Return ""
        End If


    End Function
    Public Sub CtrlLostFocus()

        Dim IsAddCtrl As Boolean = True
        For i As Integer = 0 To Me.GetRows - 1
            If CDbl(Me.GetItem(1, i)) = 0 And CDbl(Me.GetItem(2, i)) = 0 Then
                IsAddCtrl = False
                Exit For
            End If
        Next
        If IsAddCtrl = True Then
            AddNew()
        End If

    End Sub

    Public Function GetMainTotalQty() As Double
        Dim Mt As Double
        Dim St As Double
        St = 0
        Mt = 0
        For i As Integer = 0 To Me.GetRows - 1
            If Me.GetItem(0, i).Length > 0 Then
                Mt = Mt + CDbl(Me.GetItem(1, i))
                St = St + CDbl(Me.GetItem(2, i))
            End If
        Next
        Return Mt + St \ GetUnitConverionNo()
    End Function

    Public Function GetSubTotalQty() As Double

        Dim St As Double
        St = 0
        For i As Integer = 0 To Me.GetRows - 1
            If Me.GetItem(0, i).Length > 0 Then
                St = St + CDbl(Me.GetItem(2, i))
            End If
        Next
        Return St Mod GetUnitConverionNo()
    End Function
    Public Function GetUnitConverionNo() As Integer
        Try
            Return CType(Panel1.Controls(0), OpeningStockQtyRow).TxtQty.GetConverionUnit
        Catch ex As Exception
            Return 0
        End Try

    End Function
End Class
