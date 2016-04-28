Public Class BatchExpQtyControl
    Public ThiUnitName As String
    Public IsExpiryBatch As Boolean = True
    Public AllocateTotalQtyValue As Double = 0
    Public Event AmountChanged(ByVal e As Object)
    Public Sub AmountChangesSub()
        Try
            RaiseEvent AmountChanged(Me)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SetUnitNames(ByVal unitname)
        ThiUnitName = unitname
        ChangeUnits()
    End Sub
  
    Public Sub ChangeUnits()
        Try
            For i As Integer = 0 To Panel1.Controls.Count
                CType(Panel1.Controls(i), BatchExpQtyRowCtrol).TxtQty.SetUnitName(ThiUnitName)
                If CType(Panel1.Controls(0), BatchExpQtyRowCtrol).TxtQty.IscompoundUnit = False Then
                    CType(Panel1.Controls(i), BatchExpQtyRowCtrol).TxtQty.TxtQty2.Text = "0"
                End If

            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AddNew(Optional ByVal DefLoc As String = "")
        Dim ka As New BatchExpQtyRowCtrol
        ka.Anchor = AnchorStyles.Left
        ka.Anchor = AnchorStyles.Top
        ka.Anchor = AnchorStyles.Right
        ka.TxtQty.SetUnitName(ThiUnitName)
        ka.TxtQty.TxtQty1.Text = "0"
        ka.TxtQty.TxtQty2.Text = "0"
        ka.TxtBatchNo.Focus()
        AddHandler ka.MyCtrlLostFocus, AddressOf CtrlLostFocus
        AddHandler ka.MyCtrlTextChange, AddressOf AmountChangesSub
        Panel1.Controls.Add(ka)
        Try
            Panel1.Controls(Panel1.Controls.Count - 1).Focus()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub ValidateStockQty(ByVal rowno As Integer)
        Try
            CType(Panel1.Controls(rowno), BatchExpQtyRowCtrol).TxtQty.ValidateQtys()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub ClearAll()
        Try
            For i As Integer = 0 To Panel1.Controls.Count - 1
                Panel1.Controls.RemoveAt(i)
            Next
        Catch ex As Exception

        End Try
        Try
            Panel1.Controls.RemoveAt(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IMSBatchNoExpiryControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddNew()
    End Sub
    Public Function GetRows() As Integer
        Return Panel1.Controls.Count
    End Function
    Public Function GetItem(ByVal colno As Integer, ByVal rowno As Integer) As String
        If colno = 0 Then
            Return ""

        ElseIf colno = 1 Then
            Return CType(Panel1.Controls(rowno), BatchExpQtyRowCtrol).TxtBatchNo.Text

        ElseIf colno = 2 Then
            Return CType(Panel1.Controls(rowno), BatchExpQtyRowCtrol).TxtExpiry.Value.Date.ToString
        ElseIf colno = 3 Then
            Return CType(Panel1.Controls(rowno), BatchExpQtyRowCtrol).TxtQty.TxtQty1.Text

        ElseIf colno = 4 Then
            Return CType(Panel1.Controls(rowno), BatchExpQtyRowCtrol).TxtQty.TxtQty2.Text
        ElseIf colno = 5 Then
            Return CType(Panel1.Controls(rowno), BatchExpQtyRowCtrol).TxtStockRate.Text
        ElseIf colno = 6 Then
            Return CType(Panel1.Controls(rowno), BatchExpQtyRowCtrol).TxtTotalValue.Text
        Else
            Return ""
        End If


    End Function
    Public Sub SetItems(ByVal colno As Integer, ByVal rowno As Integer, ByVal Value As String)
        If colno = 0 Then


        ElseIf colno = 1 Then
            CType(Panel1.Controls(rowno), BatchExpQtyRowCtrol).TxtBatchNo.Text = Value
        ElseIf colno = 2 Then
            Try
                CType(Panel1.Controls(rowno), BatchExpQtyRowCtrol).TxtExpiry.Value = CDate(Value)
            Catch ex As Exception

            End Try
        ElseIf colno = 3 Then
            CType(Panel1.Controls(rowno), BatchExpQtyRowCtrol).TxtQty.TxtQty1.Text = Value
        ElseIf colno = 4 Then
            CType(Panel1.Controls(rowno), BatchExpQtyRowCtrol).TxtQty.TxtQty2.Text = Value
            CType(Panel1.Controls(rowno), BatchExpQtyRowCtrol).TxtQty.CalculateQtys()
        ElseIf colno = 5 Then
            CType(Panel1.Controls(rowno), BatchExpQtyRowCtrol).TxtStockRate.Text = Value

        End If
    End Sub
    Public Function GetQtyIsExists(ByVal row As Integer) As Double
        Return CDbl(CType(Panel1.Controls(row), BatchExpQtyRowCtrol).TxtQty.TxtQty1.Text) + CDbl(CType(Panel1.Controls(row), BatchExpQtyRowCtrol).TxtQty.TxtQty2.Text)
    End Function
    Public Sub CtrlLostFocus()
        Dim IsAddCtrl As Boolean = True
        On Error Resume Next
        For i As Integer = 0 To Me.GetRows - 1
            If CDbl(Me.GetItem(3, i)) = 0 And CDbl(Me.GetItem(4, i)) = 0 Then
                IsAddCtrl = False
                Exit For
            End If
        Next
        If IsAddCtrl = False Then
            Dim pqty As Double = 0
            pqty = GetMainTotalQty()
            If AllocateTotalQtyValue = pqty Then
                IsAddCtrl = False
            ElseIf AllocateTotalQtyValue > pqty Then
                IsAddCtrl = True
            Else
                IsAddCtrl = False
                MsgBox("The Total Quatity is not match, Please check...")
            End If
        End If
        
        If IsAddCtrl = True Then
            AddNew()
        End If
        AmountChangesSub()
    End Sub
    Public Function GetTotalQtyOnRow(ByVal row As Integer) As Double
        If GetUnitConverionNo() <= 0 Then
            Return CDbl(Me.GetItem(3, row))
        Else
            Return CDbl(Me.GetItem(3, row)) * GetUnitConverionNo() + CDbl(Me.GetItem(4, row))
        End If

    End Function
    Public Function GetTotalQtyTextOnRow(ByVal row As Integer) As String
        Return CType(Panel1.Controls(row), BatchExpQtyRowCtrol).TxtQty.GetTotalQtyText
    End Function
    Public Function GetMainTotalQty() As Double
        Dim Mt As Double
        Dim St As Double
        St = 0
        Mt = 0
        For i As Integer = 0 To Me.GetRows - 1
            If IsExpiryBatch = True Then
                If Me.GetItem(0, i).Length > 0 And Me.GetItem(1, i).Length > 0 Then
                    Mt = Mt + CDbl(Me.GetItem(3, i))
                    St = St + CDbl(Me.GetItem(4, i))
                End If
            ElseIf Me.GetItem(0, i).Length > 0 Then
                Mt = Mt + CDbl(Me.GetItem(3, i))
                St = St + CDbl(Me.GetItem(4, i))
            End If

        Next
        Return Mt + St \ GetUnitConverionNo()
    End Function

    Public Function GetSubTotalQty() As Double
        Dim St As Double
        St = 0
        If CType(Panel1.Controls(0), BatchExpQtyRowCtrol).TxtQty.IscompoundUnit = False Then
            St = 0
            Return St
        Else
            For i As Integer = 0 To Me.GetRows - 1
                If IsExpiryBatch = True Then
                    If Me.GetItem(0, i).Length > 0 And Me.GetItem(1, i).Length > 0 Then
                        St = St + CDbl(Me.GetItem(4, i))
                    End If
                ElseIf Me.GetItem(0, i).Length > 0 Then
                    St = St + CDbl(Me.GetItem(4, i))
                End If
            Next
        End If

        Return St Mod GetUnitConverionNo()
    End Function
    Public Function GetUnitConverionNo() As Integer

        Return CType(Panel1.Controls(0), BatchExpQtyRowCtrol).TxtQty.GetConverionUnit
    End Function
    Public Function GetMainUnitName() As String
        Return CType(Panel1.Controls(0), BatchExpQtyRowCtrol).TxtQty.GetMainUnitName
    End Function
    Public Function GetSubUnitName() As String
        Return CType(Panel1.Controls(0), BatchExpQtyRowCtrol).TxtQty.GetSubUnitName
    End Function
    Public Function IsSimpleUnit() As Boolean
        Return CType(Panel1.Controls(0), BatchExpQtyRowCtrol).TxtQty.IsSimpleUnit
    End Function
End Class
