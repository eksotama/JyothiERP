Public Class LedgerOpeningBalanceControl
    Public Event AmountChanged(ByVal e As Object)
    Public Sub ClearAll()
        Try
            For i As Integer = 0 To Panel1.Controls.Count - 1
                Panel1.Controls.RemoveAt(i)
            Next
        Catch ex As Exception

        End Try

        AddNew()
    End Sub
    Public Function GetRows() As Integer
        Return Panel1.Controls.Count
    End Function
    Public Function GetDrTotalAmount() As Double
        Dim amt As Double
        amt = 0
        For i As Integer = 0 To Me.GetRows - 1
            If Me.GetItem(1, i).Length > 0 And CDbl(Me.GetItem(3, i)) > 0 Then
                amt = amt + CDbl(GetItem(3, i))
            End If
        Next
        Return amt
    End Function
    Public Function GetCrTotalAmount() As Double
        Dim amt As Double
        amt = 0
        For i As Integer = 0 To Me.GetRows - 1
            If Me.GetItem(1, i).Length > 0 And CDbl(Me.GetItem(4, i)) > 0 Then
                amt = amt + CDbl(GetItem(4, i))
            End If
        Next
        Return amt
    End Function
    Public Sub CtrlLostFocus()
        Dim IsAddCtrl As Boolean = True

        For i As Integer = 0 To Me.GetRows - 1
            If GetItem(1, i).Length = 0 Then
                IsAddCtrl = False
                Exit For
            End If
            If CDbl(GetItem(3, i)) = 0 And CDbl(GetItem(4, i)) = 0 Then
                IsAddCtrl = False

            End If
        Next
        ' MsgBox(IsAddCtrl)
        If IsAddCtrl = True Then
            AddNew()
        End If

    End Sub
    Public Function GetBill2BillTransCode(ByVal rowno As Integer) As Single
        Return CType(Panel1.Controls(rowno), LedgerOpeningBalanceRow).Bill2BillTranscode
    End Function
    Public Sub SetBill2BillTransCode(ByVal rowno As Integer, ByVal TCode As Single)
        CType(Panel1.Controls(rowno), LedgerOpeningBalanceRow).Bill2BillTranscode = TCode
    End Sub
    Public Sub AmountChangesSub()
        Try
            RaiseEvent AmountChanged(Me)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub AddNew()
        Dim ka As New LedgerOpeningBalanceRow
        ka.Anchor = AnchorStyles.Left
        ka.Anchor = AnchorStyles.Top
        ka.Anchor = AnchorStyles.Right
        ka.TxtDr.Text = "0"
        ka.TxtCr.Text = "0"
        ka.TxtDate.Focus()
        AddHandler ka.MyCtrlTextChange, AddressOf AmountChangesSub
        AddHandler ka.MyCtrlLostFocus, AddressOf CtrlLostFocus
        Panel1.Controls.Add(ka)
        Try
            Panel1.Controls(Panel1.Controls.Count - 1).Focus()
        Catch ex As Exception

        End Try
        ' ka.TxtDr.Focus()
    End Sub
    Public Function GetItem(ByVal colno As Integer, ByVal rowno As Integer) As String
        If colno = 0 Then
            Return CType(Panel1.Controls(rowno), LedgerOpeningBalanceRow).TxtDate.Value.Date
        ElseIf colno = 1 Then
            Return CType(Panel1.Controls(rowno), LedgerOpeningBalanceRow).TxtRefNo.Text
        ElseIf colno = 2 Then
            Return CType(Panel1.Controls(rowno), LedgerOpeningBalanceRow).TxtVoucher.Text
        ElseIf colno = 3 Then
            Return CType(Panel1.Controls(rowno), LedgerOpeningBalanceRow).TxtDr.Text
        ElseIf colno = 4 Then
            Return CType(Panel1.Controls(rowno), LedgerOpeningBalanceRow).TxtCr.Text
        Else
            Return ""
        End If
    End Function


    Public Sub SetItem(ByVal colno As Integer, ByVal rowno As Integer, ByVal value As String)
        If colno = 0 Then
            CType(Panel1.Controls(rowno), LedgerOpeningBalanceRow).TxtDate.Value = value
        ElseIf colno = 1 Then
            CType(Panel1.Controls(rowno), LedgerOpeningBalanceRow).TxtRefNo.Text = value
        ElseIf colno = 2 Then
            CType(Panel1.Controls(rowno), LedgerOpeningBalanceRow).TxtVoucher.Text = value
        ElseIf colno = 3 Then
            CType(Panel1.Controls(rowno), LedgerOpeningBalanceRow).TxtDr.Text = value
        ElseIf colno = 4 Then
            CType(Panel1.Controls(rowno), LedgerOpeningBalanceRow).TxtCr.Text = value
        End If
    End Sub
    
End Class
