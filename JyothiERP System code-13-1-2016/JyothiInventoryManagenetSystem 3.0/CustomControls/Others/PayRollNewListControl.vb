Public Class PayRollNewListControl
    Public Event AmountChanged(ByVal e As Object)
    Public Event AmountIsTally(ByVal e As Object)
    Public Event CreateMainControlEvent(ByVal e As Object)
    Public TotalValue As Double = 0
    Public CatOldName As String = ""
    Public CtrlNo As Integer = 0
    Public PrimaryCostCenterName As String = ""
    Dim lostcount As Integer = 0
    Public Sub CostNameLostFocus()

    End Sub
    Public Sub SetHeading(ByVal value As String)

    End Sub
    Public Sub FindAmountValues()
        Dim val As Double = 0
        Dim crval As Double = 0
        Dim drval As Double = 0
        Dim isnewrows As Boolean = False
        For i As Integer = 0 To Panel1.Controls.Count - 1
            If (CType(Panel1.Controls(i), PayRollNewRowControl).TxtPayRollLedgerName.Text.Length > 0) Then
                If CType(Panel1.Controls(i), PayRollNewRowControl).TxtPayRollLedgerName.Text = "*End Of List" Then
                    Exit For
                Else
                    If CType(Panel1.Controls(i), PayRollNewRowControl).TxtDrCr.Text = "Dr" Then
                        drval = drval + CType(Panel1.Controls(i), PayRollNewRowControl).TxtValue.Text
                    Else
                        crval = crval + CType(Panel1.Controls(i), PayRollNewRowControl).TxtValue.Text
                    End If
                    isnewrows = True
                End If
            End If
        Next
        TxtTotal.Text = drval - crval
       
    End Sub
    Public Sub AmountChangesSub(ByVal e As Object)
        Dim val As Double = 0
        Dim crval As Double = 0
        Dim drval As Double = 0
        Dim isnewrows As Boolean = False
        For i As Integer = 0 To Panel1.Controls.Count - 1
            If (CType(Panel1.Controls(i), PayRollNewRowControl).TxtPayRollLedgerName.Text.Length > 0) Then
                If CType(Panel1.Controls(i), PayRollNewRowControl).TxtPayRollLedgerName.Text = "*End Of List" Then
                    isnewrows = False
                    DeleteControlsFrom(i)
                    Exit For
                Else
                    If CType(Panel1.Controls(i), PayRollNewRowControl).TxtDrCr.Text = "Dr" Then
                        drval = drval + CType(Panel1.Controls(i), PayRollNewRowControl).TxtValue.Text
                    Else
                        crval = crval + CType(Panel1.Controls(i), PayRollNewRowControl).TxtValue.Text
                    End If
                    isnewrows = True
                End If
            End If
        Next
        TxtTotal.Text = drval - crval
        If isnewrows = True Then
            AddNew(TotalValue)
        Else
            Try
                RaiseEvent AmountChanged(Me)
            Catch ex As Exception

            End Try
        End If

        
    End Sub
    Sub DeleteControlsFrom(ByVal Fromno As Integer)
        For i As Integer = Fromno To Panel1.Controls.Count - 1
            Try
                Panel1.Controls.RemoveAt(Fromno)
            Catch ex As Exception

            End Try

        Next

    End Sub
    Public Sub AddNew(Optional ByVal Value As Double = 0)
        Dim ka As New PayRollNewRowControl
        ka.TxtDrCr.Items.Add("Dr")
        ka.TxtDrCr.Items.Add("Cr")
        ka.Anchor = AnchorStyles.Left
        ka.Anchor = AnchorStyles.Top
        ka.Anchor = AnchorStyles.Right
        ka.TxtPayRollLedgerName.Focus()
        ka.TxtValue.Text = Value
        ka.TxtPayRollLedgerName.Focus()
        AddHandler ka.AmountLostFocus, AddressOf AmountChangesSub
        AddHandler ka.CostLostFocus, AddressOf CostNameLostFocus
        AddHandler ka.ItemListAddedEvent, AddressOf ItemsAddedEvnt
        If Panel1.Controls.Count > 0 Then
            LoadDataIntoComboBox("SELECT ledgername as Nv FROM ledgers where n1=2 and Isactive=1 ", ka.TxtPayRollLedgerName, "NV", "*End Of List")
        Else
            LoadDataIntoComboBox("SELECT ledgername as Nv FROM ledgers where n1=2 and Isactive=1 ", ka.TxtPayRollLedgerName, "NV")
        End If


        'If ka.TxtPayRollLedgerName.Items.Count > 0 Then
        '    ka.TxtPayRollLedgerName.SelectedIndex = 0
        'End If
        Panel1.Controls.Add(ka)
        Try
            Panel1.Controls(Panel1.Controls.Count - 1).Focus()
            CType(Panel1.Controls(Panel1.Controls.Count - 1), PayRollNewRowControl).TxtPayRollLedgerName.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub ItemsAddedEvnt(ByVal e As Object)

        If Panel1.Controls.IndexOf(e) > 0 Then
            LoadDataIntoComboBox("SELECT ledgername as Nv FROM ledgers where n1=2 and Isactive=1 ", CType(e, PayRollNewRowControl).TxtPayRollLedgerName, "NV", "*End Of List")
        Else
            LoadDataIntoComboBox("SELECT ledgername as Nv FROM ledgers where n1=2 and Isactive=1 ", CType(e, PayRollNewRowControl).TxtPayRollLedgerName, "NV")
        End If

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
    Public Function GetRows() As Integer
        Return Panel1.Controls.Count
    End Function
    Public Function GetItem(ByVal colno As Integer, ByVal rowno As Integer) As String
        If colno = 0 Then
            Return CType(Panel1.Controls(rowno), PayRollNewRowControl).TxtPayRollLedgerName.Text

        ElseIf colno = 1 Then
            Return CType(Panel1.Controls(rowno), PayRollNewRowControl).TxtValue.Text
        ElseIf colno = 2 Then
            Return CType(Panel1.Controls(rowno), PayRollNewRowControl).TxtDrCr.Text
        Else

            Return ""
        End If


    End Function
    Public Sub SetItems(ByVal colno As Integer, ByVal rowno As Integer, ByVal Value As String)
        If colno = 0 Then
            CType(Panel1.Controls(rowno), PayRollNewRowControl).TxtPayRollLedgerName.Text = Value

        ElseIf colno = 1 Then
            CType(Panel1.Controls(rowno), PayRollNewRowControl).TxtValue.Text = Value
        ElseIf colno = 2 Then
            CType(Panel1.Controls(rowno), PayRollNewRowControl).TxtDrCr.Text = Value
        End If
    End Sub
    Public Function GetTotals() As Double
        Dim val As Double = 0
        For i As Integer = 0 To Panel1.Controls.Count - 1
            val = val + CDbl(CType(Panel1.Controls(i), PayRollNewRowControl).TxtValue.Text)
        Next
        Return val
    End Function

    Private Sub CostCenterControl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Try
            TxtEmployeeNames.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CostCenterControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ERPInitializeObjects(Me)
        'If CtrlNo = 0 Then
        '    LoadDataIntoCostCenterComboBox("SELECT empname as Nv FROM employees where  isdelete=0 ", TxtEmployeeNames, "NV")
        'Else
        '    LoadDataIntoCostCenterComboBox("SELECT empname as Nv FROM employees where  isdelete=0 ", TxtEmployeeNames, "NV", "*End Of List")
        'End If
        CtrlNo = 1
        Try
            TxtEmployeeNames.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCostCatName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEmployeeNames.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            Dim k As New CreateNewCostCentre
            k.ShowDialog()
            k.Dispose()
            If CtrlNo = 0 Then
                LoadDataIntoCostCenterComboBox("SELECT stockgroupname as Nv FROM CostCenters ", TxtEmployeeNames, "NV")
            Else
                LoadDataIntoCostCenterComboBox("SELECT stockgroupname as Nv FROM CostCenters ", TxtEmployeeNames, "NV", "*End Of List")
            End If
        End If
    End Sub



    Private Sub TxtCostCatName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEmployeeNames.LostFocus

        If CatOldName.Length = 0 And TxtEmployeeNames.Text.Length = 0 Then Exit Sub
        If TxtEmployeeNames.Text = "*End Of List" Then
            RaiseEvent AmountIsTally(Me)
            RaiseEvent CreateMainControlEvent(Me)
            Exit Sub
        End If

        If TxtEmployeeNames.Text <> CatOldName And CatOldName.Length = 0 Then
            ClearAll()
            AddNew(TotalValue)
        End If
        CatOldName = TxtEmployeeNames.Text

    End Sub

  
End Class
