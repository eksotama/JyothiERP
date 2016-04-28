Imports System.Windows.Forms

Public Class Costcenterallocation
    Public IsCompletedOneCost As Boolean = False
    Dim IsLoadedData As Boolean = False
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Dim TotalAmount As Double = 0
    Dim TxtLedgerName As String = ""
    Dim CostCatName As String = ""
    Dim CostList As New DataGridView
    Dim isFirstTime As Boolean = True
    Sub New(ByRef CList As DataGridView, ByVal totalvalue As Double, ByVal ledgername As String)

        ' This call is required by the designer.
        InitializeComponent()
        CostList.AllowUserToAddRows = False
        CostList.AllowUserToDeleteRows = False
        CostList.EditMode = DataGridViewEditMode.EditProgrammatically
        CostList.Rows.Clear()
        TotalAmount = totalvalue
        TxtLedgerName = ledgername
        CostList = CList
        TxtHeading.Text = "Cost Center Allocation For Account " & Chr(13) & TxtLedgerName & " , Value Upto : " & totalvalue.ToString

        LoadData()
        IsLoadedData = True
    End Sub
    Public Sub AddNew()
        Dim ka As New CostCenterControl
        ka.Anchor = AnchorStyles.Left
        ka.Anchor = AnchorStyles.Top
        ka.Anchor = AnchorStyles.Right
        ka.CtrlNo = Ftb.Controls.Count
        AddHandler ka.AmountIsTally, AddressOf AmountisTalled
        ka.TotalValue = TotalAmount
        ka.Focus()
        Ftb.Controls.Add(ka)
    End Sub
    Sub AmountisTalled(ByVal e As Object)
        DeleteControlsFrom(Ftb.Controls.IndexOf(e))

        IsCompletedOneCost = True
    End Sub
    Sub DeleteControlsFrom(ByVal Fromno As Integer)
        For i As Integer = Fromno To Ftb.Controls.Count - 1
            Try
                Ftb.Controls.RemoveAt(Fromno)
            Catch ex As Exception

            End Try

        Next

    End Sub
    Private Sub Costcenterallocation_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        Try
            Ftb.Controls(0).Focus()
        Catch ex As Exception

        End Try
    End Sub
   

    Private Sub Costcenterallocation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '   LoadData()

    End Sub
    Sub LoadData()


        Try

            Dim costitemcount As Integer = 0
            costitemcount = GetCostCount()
            If costitemcount = 0 Then
                AddNew()
            Else

                For ci As Integer = 0 To costitemcount - 1
                    AddNew()
                    Dim ctcount As Integer = 0
                    CType(Ftb.Controls(ci), CostCenterControl).TotalValue = TotalAmount
                    For i As Integer = 0 To CostList.RowCount - 1
                        If Len(CostList.Item("tcostname", i).Value) > 0 Then
                            If CostList.Item("tcostno", i).Value = ci.ToString Then

                                If ctcount = 0 Then
                                    CType(Ftb.Controls(ci), CostCenterControl).CatOldName = CostList.Item("tcostcat", i).Value
                                    CType(Ftb.Controls(ci), CostCenterControl).TxtCostCatName.Text = CostList.Item("tcostcat", i).Value
                                End If
                                CType(Ftb.Controls(ci), CostCenterControl).AddNew()
                                CType(Ftb.Controls(ci), CostCenterControl).SetItems(0, ctcount, CostList.Item("tcostname", i).Value)
                                CType(Ftb.Controls(ci), CostCenterControl).SetItems(1, ctcount, CostList.Item("tamount", i).Value)
                                ctcount = ctcount + 1
                            End If
                        End If
                    Next
                Next
                Try
                    CType(Ftb.Controls(0), CostCenterControl).Focus()
                Catch ex3 As Exception

                End Try

            End If
            If costitemcount > 0 Then
                BtnOk.Focus()
            End If
        Catch ex As Exception

        End Try
      
    End Sub
    Function GetCtrlItems(ByVal ctrlno As Integer, ByVal colno As Integer, ByVal rno As Integer) As String
        If colno = 0 Then
            Return CType(Ftb.Controls(ctrlno), CostCenterControl).GetItem(0, rno)
        ElseIf colno = 1 Then
            Return CType(Ftb.Controls(ctrlno), CostCenterControl).GetItem(1, rno)
        Else
            Return ""
        End If
    End Function
    Function GetCtrlCount() As Integer
        Return Ftb.Controls.Count
    End Function
    Function GetCostCount() As Integer
        Dim Ct As Integer = 0
        Dim Cb As New ComboBox
        Cb.Items.Clear()
        If CostList.RowCount = 0 Then
            Return 0
        Else
            For i As Integer = 0 To CostList.RowCount - 1
                Try
                    If Cb.Items.Contains(CostList.Item("tCostno", i).Value) = False Then
                        Cb.Items.Add(CostList.Item("tCostno", i).Value)
                    End If
                Catch ex As Exception

                End Try
            Next

        End If
        Return Cb.Items.Count
    End Function
    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
       
    End Sub
    Sub SaveData()
        If GetCtrlCount() = 0 Then
            IsCompletedOneCost = False
            Exit Sub
        End If
        If ValidateCostCategories() = False Then
            IsCompletedOneCost = False
            Exit Sub
        End If
        Dim IsAmountTotalsIsOk As Boolean = True
        For i As Integer = 0 To GetCtrlCount() - 1
            If CType(Ftb.Controls(i), CostCenterControl).GetTotals <> TotalAmount Then
                IsAmountTotalsIsOk = False
                Exit For
            End If
        Next


        If IsAmountTotalsIsOk = False Then
            MsgBox("Amounts allocations are not tally for the Account Net Value, Please Try again...", MsgBoxStyle.Information)
            CType(Ftb.Controls(0), CostCenterControl).Focus()
            IsCompletedOneCost = False
            Exit Sub
        Else
            If MsgBox("Do you want to accept changes ?        ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Try
                    CType(Ftb.Controls(0), CostCenterControl).Focus()
                Catch ex As Exception

                End Try

                Exit Sub
            End If
            CostList.Rows.Clear()
            For Ci As Integer = 0 To GetCtrlCount() - 1
                Dim rno As Integer = 0
                For i As Integer = 0 To CType(Ftb.Controls(Ci), CostCenterControl).GetRows - 1
                    rno = CostList.Rows.Add
                    CostList.Item("tCostno", rno).Value = Ci
                    CostList.Item("tcostname", rno).Value = CType(Ftb.Controls(Ci), CostCenterControl).GetItem(0, i)
                    CostList.Item("tamount", rno).Value = CType(Ftb.Controls(Ci), CostCenterControl).GetItem(1, i)
                    CostList.Item("tcostcat", rno).Value = CType(Ftb.Controls(Ci), CostCenterControl).TxtCostCatName.Text
                Next
            Next
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub ImsButton1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.GotFocus
        If isFirstTime = True Then
            isFirstTime = False
            Exit Sub
        End If
        If IsCompletedOneCost = True Then
            SaveData()
            Exit Sub
        Else
            AddNew()
        End If
    End Sub
    Public Function ValidateCostCategories() As Boolean
        Dim val As Boolean = True
        If Ftb.Controls.Count = 0 Then
            val = False
        Else
            Dim cb As New ComboBox
            cb.Items.Clear()
            Try
                For i As Integer = 0 To Ftb.Controls.Count - 1
                    If cb.Items.Contains(CType(Ftb.Controls(i), CostCenterControl).TxtCostCatName.Text) = False Then
                        cb.Items.Add(CType(Ftb.Controls(i), CostCenterControl).TxtCostCatName.Text)
                        Dim subcb As New ComboBox
                        subcb.Items.Clear()
                        For k As Integer = 0 To CType(Ftb.Controls(i), CostCenterControl).Controls.Count - 1
                            If subcb.Items.Contains(CType(CType(Ftb.Controls(i), CostCenterControl).Panel1.Controls(k), CostCenterRow).TxtCostName.Text) = False Then
                                subcb.Items.Add(CType(CType(Ftb.Controls(i), CostCenterControl).Panel1.Controls(k), CostCenterRow).TxtCostName.Text)
                            Else
                                MsgBox("Duplicate Entry, Please Try again......")
                                CType(CType(Ftb.Controls(i), CostCenterControl).Panel1.Controls(k), CostCenterRow).TxtCostName.Focus()
                                val = False
                                Return val
                            End If
                        Next
                    Else
                        MsgBox("Duplicate Entry, Please Try again......")
                        CType(Ftb.Controls(i), CostCenterControl).TxtCostCatName.Focus()
                        val = False
                        Return val
                    End If
                Next
            Catch ex As Exception
                val = True
            End Try
        End If

        Return val
    End Function

    Private Sub BtnOk_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.LostFocus
        IsCompletedOneCost = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CostList.Rows.Clear()
        Me.Close()
    End Sub
End Class
