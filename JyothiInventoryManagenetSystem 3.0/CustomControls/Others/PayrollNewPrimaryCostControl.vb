Public Class PayrollNewPrimaryCostControl
    Public Event AmountChanged(ByVal e As Object)
    Public Event EndofEmployeeContrls(ByVal e As Object)
    Public Event AmountIsTally(ByVal e As Object)
    Public TotalValue As Double = 0
    Public CatOldName As String = ""
    Public CtrlNo As Integer = 0
    Public PrimaryCostCenterName As String = ""
    Public Sub CostNameLostFocus()

    End Sub
    Public Sub SetHeading(ByVal value As String)

    End Sub
   
    Public Sub AmountChangesSub(ByVal e As Object)
        Dim val As Double = 0
        Dim isnewrows As Boolean = False
        For i As Integer = 0 To Panel1.Controls.Count - 1
            If (CType(Panel1.Controls(i), PayRollNewListControl).TxtEmployeeNames.Text.Length > 0) Then
                If CType(Panel1.Controls(i), PayRollNewListControl).TxtEmployeeNames.Text = "*End Of List" Then
                    isnewrows = False

                    DeleteControlsFrom(i)
                    Exit For
                Else
                    val = val + CDbl(CType(Panel1.Controls(i), PayRollNewListControl).TxtTotal.Text)
                    isnewrows = True
                End If
            End If
        Next
        TxtTotal.Text = val
        If isnewrows = True Then
            AddNew(TotalValue)
        Else
            Try
                RaiseEvent AmountChanged(Me)
            Catch ex As Exception

            End Try
        End If

        
    End Sub
    Public Sub FindAmountValues()
        Dim val As Double = 0
        Dim isnewrows As Boolean = False
        For i As Integer = 0 To Panel1.Controls.Count - 1
            If (CType(Panel1.Controls(i), PayRollNewListControl).TxtEmployeeNames.Text.Length > 0) Then
                If CType(Panel1.Controls(i), PayRollNewListControl).TxtEmployeeNames.Text = "*End Of List" Then
                    Exit For
                Else
                    val = val + CDbl(CType(Panel1.Controls(i), PayRollNewListControl).TxtTotal.Text)
                    isnewrows = True
                End If
            End If
        Next
        TxtTotal.Text = val
       
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
        Dim ka As New PayRollNewListControl
        ka.Anchor = AnchorStyles.Left
        ka.Anchor = AnchorStyles.Top
        ka.Anchor = AnchorStyles.Right
        ka.TxtEmployeeNames.Focus()
        ka.TxtEmployeeNames.Focus()
        AddHandler ka.AmountChanged, AddressOf AmountChangesSub
        AddHandler ka.CreateMainControlEvent, AddressOf EmployeeEndEvent
        AddHandler ka.AmountIsTally, AddressOf AmountChangesSub
        ' AddHandler ka.ItemsAddedEvnt, AddressOf ItemsAddedEvnt
        If Panel1.Controls.Count > 0 Then
            LoadDataIntoComboBox("SELECT empname as Nv FROM employees where  isdelete=0 and costcat=N'" & TxtPrimaryCostCentreName.Text & "'", ka.TxtEmployeeNames, "NV", "*End Of List")
        Else
            LoadDataIntoComboBox("SELECT empname as Nv FROM employees where  isdelete=0 and costcat=N'" & TxtPrimaryCostCentreName.Text & "'", ka.TxtEmployeeNames, "NV")
        End If
        'If ka.TxtEmployeeNames.Items.Count > 0 Then
        '    ka.TxtEmployeeNames.SelectedIndex = 0
        'End If

        Panel1.Controls.Add(ka)
        Try
            Panel1.Controls(Panel1.Controls.Count - 1).Focus()
            CType(Panel1.Controls(Panel1.Controls.Count - 1), PayRollNewListControl).TxtEmployeeNames.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Sub EmployeeEndEvent(ByVal e As Object)
        RaiseEvent EndofEmployeeContrls(Me)
    End Sub
    Public Sub ItemsAddedEvnt(ByVal e As Object)

        If Panel1.Controls.IndexOf(e) > 0 Then
            LoadDataIntoComboBox("SELECT empname as Nv FROM employees where  isdelete=0 and costcat=N'" & TxtPrimaryCostCentreName.Text & "'", CType(e, PayRollNewListControl).TxtEmployeeNames, "NV", "*End Of List")
        Else
            LoadDataIntoComboBox("SELECT empname as Nv FROM employees where  isdelete=0 and costcat=N'" & TxtPrimaryCostCentreName.Text & "'", CType(e, PayRollNewListControl).TxtEmployeeNames, "NV")
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
            Return TxtPrimaryCostCentreName.Text
        ElseIf colno = 1 Then
            Return CType(Panel1.Controls(rowno), PayRollNewListControl).TxtEmployeeNames.Text
        ElseIf colno = 2 Then
            Return CType(Panel1.Controls(rowno), PayRollNewListControl).GetItem(0, rowno)
        ElseIf colno = 3 Then
            Return CType(Panel1.Controls(rowno), PayRollNewListControl).GetItem(1, rowno)
        ElseIf colno = 4 Then
            Return CType(Panel1.Controls(rowno), PayRollNewListControl).GetItem(2, rowno)
        Else
            Return ""
        End If


    End Function
    Public Sub SetItems(ByVal colno As Integer, ByVal rowno As Integer, ByVal Value As String)
        If colno = 0 Then
            CType(Panel1.Controls(rowno), PayRollNewListControl).TxtEmployeeNames.Text = Value

        ElseIf colno = 1 Then
            CType(Panel1.Controls(rowno), PayRollNewListControl).SetItems(0, rowno, Value)
        ElseIf colno = 2 Then
            CType(Panel1.Controls(rowno), PayRollNewListControl).SetItems(1, rowno, Value)
        ElseIf colno = 3 Then
            CType(Panel1.Controls(rowno), PayRollNewListControl).SetItems(2, rowno, Value)
        End If
    End Sub
    Public Function GetTotals() As Double
        Dim val As Double = 0
        For i As Integer = 0 To Panel1.Controls.Count - 1
            val = val + CDbl(CType(Panel1.Controls(i), PayRollNewListControl).TxtTotal.Text)
        Next
        Return val
    End Function

    Private Sub CostCenterControl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Try
            TxtPrimaryCostCentreName.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CostCenterControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ERPInitializeObjects(Me)
        If CtrlNo = 0 Then
            LoadDataIntoCostCenterComboBox("SELECT stockgroupname as Nv FROM costcenters", TxtPrimaryCostCentreName, "NV")
        Else
            LoadDataIntoCostCenterComboBox("SELECT stockgroupname as Nv FROM costcenters", TxtPrimaryCostCentreName, "NV", "*End Of List")
        End If
        CtrlNo = 2
        Try
            TxtPrimaryCostCentreName.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCostCatName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPrimaryCostCentreName.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            Dim k As New CreateNewCostCentre
            k.ShowDialog()
            k.Dispose()
            If CtrlNo = 0 Then
                LoadDataIntoCostCenterComboBox("SELECT stockgroupname as Nv FROM costcenters", TxtPrimaryCostCentreName, "NV")
            Else
                LoadDataIntoCostCenterComboBox("SELECT stockgroupname as Nv FROM costcenters", TxtPrimaryCostCentreName, "NV", "*End Of List")
            End If
        End If
    End Sub



    Private Sub TxtCostCatName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPrimaryCostCentreName.LostFocus

        If CatOldName.Length = 0 And TxtPrimaryCostCentreName.Text.Length = 0 Then Exit Sub
        If TxtPrimaryCostCentreName.Text = "*End Of List" Then

            RaiseEvent AmountIsTally(Me)

        End If
        If TxtPrimaryCostCentreName.Text <> CatOldName Or CatOldName.Length = 0 Then
            ClearAll()
            AddNew(TotalValue)
        End If
        CatOldName = TxtPrimaryCostCentreName.Text

    End Sub

    Private Sub TxtPrimaryCostCentreName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrimaryCostCentreName.SelectedIndexChanged

    End Sub
End Class
