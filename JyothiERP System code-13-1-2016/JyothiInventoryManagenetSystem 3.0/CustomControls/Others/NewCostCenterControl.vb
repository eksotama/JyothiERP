Public Class NewCostCenterControl
    Public Event AmountChanged(ByVal e As Object)
    Public Event AmountIsTally(ByVal e As Object)
    Public TotalValue As Double = 0
    Public CatOldName As String = ""
    Public CtrlNo As Integer = 0
    Public Sub CostNameLostFocus()

    End Sub
    Public Sub SetHeading(ByVal value As String)

    End Sub
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub AmountChangesSub(ByVal e As Object)
        Dim val As Double = 0
        Dim isnewrows As Boolean = False
        For i As Integer = 0 To Panel1.Controls.Count - 1
            If (CType(Panel1.Controls(i), CostCenterRow).TxtCostName.Text.Length > 0) Then
                val = val + CDbl(CType(Panel1.Controls(i), CostCenterRow).TxtValue.Text)
                If val = TotalValue Then
                    DeleteControlsFrom(i + 1)
                    Exit For
                ElseIf val > TotalValue Then
                    TxtTotal.Text = val
                    isnewrows = False
                    CType(Panel1.Controls(i), CostCenterRow).TxtValue.Focus()
                    Exit Sub
                Else

                    If i = Panel1.Controls.Count - 1 Then
                        isnewrows = True
                    End If
                End If
            End If

        Next

        If isnewrows = True Then
            AddNew(TotalValue - val)
        Else
            '  MsgBox(Panel1.Controls.IndexOf(e))

        End If

        TxtTotal.Text = val
        Try
            RaiseEvent AmountChanged(Me)
        Catch ex As Exception

        End Try
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
        Dim ka As New CostCenterRow
        ka.Anchor = AnchorStyles.Left
        ka.Anchor = AnchorStyles.Top
        ka.Anchor = AnchorStyles.Right
        ka.TxtCostName.Focus()
        ka.TxtValue.Text = Value
        ka.TxtCostName.Focus()
        AddHandler ka.AmountLostFocus, AddressOf AmountChangesSub
        AddHandler ka.CostLostFocus, AddressOf CostNameLostFocus
        AddHandler ka.ItemListAddedEvent, AddressOf ItemsAddedEvnt
        LoadDataIntoComboBox("SELECT CostName as Nv FROM CostCenterNames where costgroup=N'" & TxtCostCatName.Text & "'", ka.TxtCostName, "NV")

        If ka.TxtCostName.Items.Count > 0 Then
            ka.TxtCostName.SelectedIndex = 0
        End If
        Panel1.Controls.Add(ka)
        Try
            Panel1.Controls(Panel1.Controls.Count - 1).Focus()
            CType(Panel1.Controls(Panel1.Controls.Count - 1), CostCenterRow).TxtCostName.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub ItemsAddedEvnt(ByVal e As Object)
        LoadDataIntoComboBox("SELECT CostName as Nv FROM CostCenterNames where costgroup=N'" & TxtCostCatName.Text & "'", CType(e, CostCenterRow).TxtCostName, "NV")
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
            Return CType(Panel1.Controls(rowno), CostCenterRow).TxtCostName.Text

        ElseIf colno = 1 Then
            Return CType(Panel1.Controls(rowno), CostCenterRow).TxtValue.Text
        Else

            Return ""
        End If


    End Function
    Public Sub SetItems(ByVal colno As Integer, ByVal rowno As Integer, ByVal Value As String)
        If colno = 0 Then
            CType(Panel1.Controls(rowno), CostCenterRow).TxtCostName.Text = Value

        ElseIf colno = 1 Then
            CType(Panel1.Controls(rowno), CostCenterRow).TxtValue.Text = Value
        End If
    End Sub
    Public Function GetTotals() As Double
        Dim val As Double = 0
        For i As Integer = 0 To Panel1.Controls.Count - 1
            val = val + CDbl(CType(Panel1.Controls(i), CostCenterRow).TxtValue.Text)
        Next
        Return val
    End Function

    Private Sub CostCenterControl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Try
            TxtCostCatName.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CostCenterControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ERPInitializeObjects(Me)
        Try
            If CtrlNo = 0 Then
                LoadDataIntoComboBox("SELECT StockGroupName as Nv FROM CostCenters ", TxtCostCatName, "NV")
            Else
                LoadDataIntoComboBox("SELECT StockGroupName as Nv FROM CostCenters ", TxtCostCatName, "NV", "*End Of List")
            End If
        Catch ex As Exception

        End Try

        Try
            TxtCostCatName.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCostCatName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCostCatName.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            Dim k As New CreateNewCostCentre
            k.ShowDialog()
            k.Dispose()
            LoadDataIntoComboBox("SELECT StockGroupName as Nv FROM CostCenters ", TxtCostCatName, "NV")
        End If
    End Sub



    Private Sub TxtCostCatName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCostCatName.LostFocus

        If CatOldName.Length = 0 And TxtCostCatName.Text.Length = 0 Then Exit Sub
        If TxtCostCatName.Text = "*End Of List" Then
            RaiseEvent AmountIsTally(Me)
        End If
        'If CType(Me.ParentForm, Costcenterallocation).ValidaeCostCategories(Me) = True Then
        '    TxtCostCatName.Focus()
        '    Exit Sub
        'End If

        If TxtCostCatName.Text <> CatOldName Or CatOldName.Length = 0 Then
            ClearAll()
            AddNew(TotalValue)
        End If
        CatOldName = TxtCostCatName.Text

    End Sub

End Class
