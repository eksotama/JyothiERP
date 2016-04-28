Public Class IMSBatchNoExpiryControl
    Public ThiUnitName As String
    Public IsExpiryBatch As Boolean = True
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
   
    Public Sub IsExipryBatchValue(ByVal value As Boolean)
        IsExpiryBatch = value
        Me.SuspendLayout()
        Try
            For i As Integer = 0 To Panel1.Controls.Count
                CType(Panel1.Controls(i), BatchExpiryRow).SetForExpryBatch(value)
                If value = True Then
                    CType(Panel1.Controls(i), BatchExpiryRow).Width = 600
                    Me.Width = 640
                Else
                    CType(Panel1.Controls(i), BatchExpiryRow).Width = 600
                    Me.Width = 640
                End If
            Next
        Catch ex As Exception

        End Try
        Me.ResumeLayout()
    End Sub
    Public Sub ChangeUnits()

        Try
            For i As Integer = 0 To Panel1.Controls.Count
                CType(Panel1.Controls(i), BatchExpiryRow).TxtQty.SetUnitName(ThiUnitName)
                If CType(Panel1.Controls(0), BatchExpiryRow).TxtQty.IscompoundUnit = False Then
                    CType(Panel1.Controls(i), BatchExpiryRow).TxtQty.TxtQty2.Text = "0"
                End If

            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AddNew(Optional ByVal DefLoc As String = "")
        Dim ka As New BatchExpiryRow
        ka.Anchor = AnchorStyles.Left
        ka.Anchor = AnchorStyles.Top
        ka.Anchor = AnchorStyles.Right
        ka.TxtQty.SetUnitName(ThiUnitName)
        ka.TxtQty.TxtQty1.Text = "0"
        ka.TxtQty.TxtQty2.Text = "0"
        ka.SetForExpryBatch(IsExpiryBatch)
        ka.TxtLocation.Focus()
        LoadDataIntoComboBox("select locationname  from StockLocations", ka.TxtLocation, "locationname")
        ka.TxtLocation.Text = DefLoc
        AddHandler ka.MyCtrlLostFocus, AddressOf CtrlLostFocus
        AddHandler ka.MyCtrlTextChange, AddressOf AmountChangesSub
        Panel1.Controls.Add(ka)
        IsExipryBatchValue(IsExpiryBatch)
        Try
            Panel1.Controls(Panel1.Controls.Count - 1).Focus()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub ValidateStockQty(ByVal rowno As Integer)
        Try
            CType(Panel1.Controls(rowno), BatchExpiryRow).TxtQty.ValidateQtys()
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
        ERPInitializeObjects(Me)
    End Sub
    Public Function GetRows() As Integer
        Return Panel1.Controls.Count
    End Function
    Public Function GetItem(ByVal colno As ControlValues, ByVal rowno As Integer) As String
        If colno = 0 Then
            Return CType(Panel1.Controls(rowno), BatchExpiryRow).TxtLocation.Text

        ElseIf colno = 1 Then
            Return CType(Panel1.Controls(rowno), BatchExpiryRow).TxtBatchNo.Text

        ElseIf colno = 2 Then
            Return CType(Panel1.Controls(rowno), BatchExpiryRow).TxtExpiry.Value.Date.ToString
        ElseIf colno = 3 Then
            Return CType(Panel1.Controls(rowno), BatchExpiryRow).TxtQty.TxtQty1.Text

        ElseIf colno = 4 Then
            Return CType(Panel1.Controls(rowno), BatchExpiryRow).TxtQty.TxtQty2.Text
        ElseIf colno = 5 Then
            Return CType(Panel1.Controls(rowno), BatchExpiryRow).TxtStockRate.Text
        Else
            Return ""
        End If


    End Function
    Enum ControlValues
        location = 0
        batchno = 1
        expiry = 2
        qty1 = 3
        qty2 = 4
        stockrate = 5

    End Enum
    Public Sub SetItems(ByVal colno As ControlValues, ByVal rowno As Integer, ByVal Value As String)
        If colno = 0 Then
            CType(Panel1.Controls(rowno), BatchExpiryRow).TxtLocation.Text = Value

        ElseIf colno = 1 Then
            CType(Panel1.Controls(rowno), BatchExpiryRow).TxtBatchNo.Text = Value

        ElseIf colno = 2 Then
            Try
                CType(Panel1.Controls(rowno), BatchExpiryRow).TxtExpiry.Value = Value
            Catch ex As Exception

            End Try

        ElseIf colno = 3 Then
            CType(Panel1.Controls(rowno), BatchExpiryRow).TxtQty.TxtQty1.Text = Value
        ElseIf colno = 4 Then
            CType(Panel1.Controls(rowno), BatchExpiryRow).TxtQty.TxtQty2.Text = Value
            CType(Panel1.Controls(rowno), BatchExpiryRow).TxtQty.CalculateQtys()
        ElseIf colno = 5 Then
            CType(Panel1.Controls(rowno), BatchExpiryRow).TxtStockRate.Text = Value
        
        End If
    End Sub
    Public Function GetQtyIsExists(ByVal row As Integer) As Double
        Return CDbl(CType(Panel1.Controls(row), BatchExpiryRow).TxtQty.TxtQty1.Text) + CDbl(CType(Panel1.Controls(row), BatchExpiryRow).TxtQty.TxtQty2.Text)
    End Function
    Public Sub CtrlLostFocus()
        Dim IsAddCtrl As Boolean = True
        On Error Resume Next
        For i As Integer = 0 To Me.GetRows - 1
            If CDbl(Me.GetItem(ControlValues.qty1, i)) = 0 And CDbl(Me.GetItem(ControlValues.qty2, i)) = 0 Then
                IsAddCtrl = False
                Exit For
            End If
        Next

        If IsAddCtrl = True Then
            '  AddNew()
        End If
        AmountChangesSub()
    End Sub
    Public Function GetTotalQtyOnRow(ByVal row As Integer) As Double
        If GetUnitConverionNo() <= 0 Then
            Return CDbl(Me.GetItem(ControlValues.qty1, row))
        Else
            Return CDbl(Me.GetItem(ControlValues.qty1, row)) * GetUnitConverionNo() + CDbl(Me.GetItem(ControlValues.qty2, row))
        End If

    End Function
    Public Function GetTotalQtyTextOnRow(ByVal row As Integer) As String
        Return CType(Panel1.Controls(row), BatchExpiryRow).TxtQty.GetTotalQtyText
    End Function
    Public Function GetMainTotalQty() As Double
        Dim Mt As Double
        Dim St As Double
        St = 0
        Mt = 0
        For i As Integer = 0 To Me.GetRows - 1
            If IsExpiryBatch = True Then
                If Me.GetItem(ControlValues.location, i).Length > 0 And Me.GetItem(ControlValues.batchno, i).Length > 0 Then
                    Mt = Mt + CDbl(Me.GetItem(ControlValues.qty1, i))
                    St = St + CDbl(Me.GetItem(ControlValues.qty2, i))
                End If
            ElseIf Me.GetItem(ControlValues.location, i).Length > 0 Then
                Mt = Mt + CDbl(Me.GetItem(ControlValues.qty1, i))
                St = St + CDbl(Me.GetItem(ControlValues.qty2, i))
            End If
           
        Next
        Return Mt + St \ GetUnitConverionNo()
    End Function

    Public Function GetSubTotalQty() As Double
        Dim St As Double
        St = 0
        If CType(Panel1.Controls(0), BatchExpiryRow).TxtQty.IscompoundUnit = False Then
            St = 0
            Return St
        Else
            For i As Integer = 0 To Me.GetRows - 1
                If IsExpiryBatch = True Then
                    If Me.GetItem(ControlValues.location, i).Length > 0 And Me.GetItem(ControlValues.batchno, i).Length > 0 Then
                        St = St + CDbl(Me.GetItem(ControlValues.qty2, i))
                    End If
                ElseIf Me.GetItem(0, i).Length > 0 Then
                    St = St + CDbl(Me.GetItem(ControlValues.qty2, i))
                End If
            Next
        End If

       
        Return St Mod GetUnitConverionNo()
    End Function
    Public Function GetUnitConverionNo() As Integer
       
        Return CType(Panel1.Controls(0), BatchExpiryRow).TxtQty.GetConverionUnit
    End Function
    Public Function GetMainUnitName() As String
        Return CType(Panel1.Controls(0), BatchExpiryRow).TxtQty.GetMainUnitName
    End Function
    Public Function GetSubUnitName() As String
        Return CType(Panel1.Controls(0), BatchExpiryRow).TxtQty.GetSubUnitName
    End Function
    Public Function IsSimpleUnit() As Boolean
        Return CType(Panel1.Controls(0), BatchExpiryRow).TxtQty.IsSimpleUnit
    End Function
    Public Function IsbatchnoQtyMatch(ByVal crl As Integer) As Boolean
        Return CType(Panel1.Controls(crl), BatchExpiryRow).IsBatchNoQtyMatches
    End Function
    Public Function GetBatchNoExpiryRows(ByVal crl As Integer) As Integer
        Return CType(Panel1.Controls(crl), BatchExpiryRow).TxtBatchList.RowCount
    End Function
    Public Function GetBatchNoExpiryItem(ByVal crl As Integer, ByVal colname As String, ByVal row As Integer) As String
        Return CType(Panel1.Controls(crl), BatchExpiryRow).TxtBatchList.Item(colname, row).Value
    End Function
    Public Function NewBatchNoExpiryRow(ByVal crl As Integer) As Integer
        Dim rno As Integer
        rno = CType(Panel1.Controls(crl), BatchExpiryRow).TxtBatchList.Rows.Add
        Return rno
    End Function
    Public Sub InsertBatchNoExpiryItem(ByVal crl As Integer, ByVal colname As String, ByVal row As Integer, ByVal valuestr As String)
        CType(Panel1.Controls(crl), BatchExpiryRow).TxtBatchList.Item(colname, row).Value = valuestr
    End Sub
End Class
