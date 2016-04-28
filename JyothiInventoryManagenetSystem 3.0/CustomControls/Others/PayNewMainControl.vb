Public Class PayNewMainControl
    Public IsCompletedOneCost As Boolean = False
    Dim IsLoadedData As Boolean = False
    Public PCostName As String = ""
    Dim TotalAmount As Double = 0
    Dim Isnewrow As Boolean = True
    Dim CostCatName As String = ""
    Dim CostList As New DataGridView
    Dim isFirstTime As Boolean = True
    Sub New(ByRef CList As DataGridView, ByVal totalvalue As Double, ByVal Primarycostname As String)

        ' This call is required by the designer.
        InitializeComponent()
        CostList.AllowUserToAddRows = False
        CostList.AllowUserToDeleteRows = False
        CostList.EditMode = DataGridViewEditMode.EditProgrammatically
        CostList.Rows.Clear()
        TotalAmount = totalvalue
        PCostName = Primarycostname
        CostList = CList
        LoadData()
        IsLoadedData = True
    End Sub
    Public Sub AddNew()
        Dim ka As New PayrollNewPrimaryCostControl
        ka.Anchor = AnchorStyles.Left
        ka.Anchor = AnchorStyles.Top
        ka.Anchor = AnchorStyles.Right
        ka.CtrlNo = Ftb.Controls.Count
        AddHandler ka.AmountIsTally, AddressOf AmountisTalled
        AddHandler ka.EndofEmployeeContrls, AddressOf EndoFEmployees
        ka.TotalValue = TotalAmount
        ka.Focus()
        Ftb.Controls.Add(ka)
    End Sub
    Sub EndoFEmployees()
        AddNew()
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


    Private Sub Costcenterallocation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ERPInitializeObjects(Me)
        'LoadData()

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
                    Dim subcount As Integer = 0
                    Dim prowcount As Integer = 0
                    For i As Integer = 0 To CostList.RowCount - 1
                        If CostList.Item("tempno", i).Value = ctcount.ToString Then
                            If ctcount = 0 Then
                                CType(Ftb.Controls(ci), PayrollNewPrimaryCostControl).CatOldName = CostList.Item("tpcostname", i).Value
                                CType(Ftb.Controls(ci), PayrollNewPrimaryCostControl).TxtPrimaryCostCentreName.Text = CostList.Item("tpcostname", i).Value

                            End If
                            CType(Ftb.Controls(ci), PayrollNewPrimaryCostControl).AddNew()
                            subcount = 0
                            For subno As Integer = 0 To CostList.RowCount - 1
                                If CostList.Item("tcostno", subno).Value = ci.ToString And CostList.Item("tempno", subno).Value = ctcount.ToString Then
                                    If subcount = 0 Then
                                        CType(CType(Ftb.Controls(ci), PayrollNewPrimaryCostControl).Panel1.Controls(ctcount), PayRollNewListControl).CatOldName = CostList.Item("tempname", i).Value
                                        CType(CType(Ftb.Controls(ci), PayrollNewPrimaryCostControl).Panel1.Controls(ctcount), PayRollNewListControl).TxtEmployeeNames.Text = CostList.Item("tempname", i).Value
                                        ' CType(Ftb.Controls(ci), PayrollNewPrimaryCostControl).AddNew()
                                    End If
                                    CType(CType(Ftb.Controls(ci), PayrollNewPrimaryCostControl).Panel1.Controls(ctcount), PayRollNewListControl).AddNew()
                                    CType(CType(CType(Ftb.Controls(ci), PayrollNewPrimaryCostControl).Panel1.Controls(ctcount), PayRollNewListControl).Panel1.Controls(subcount), PayRollNewRowControl).TxtPayRollLedgerName.Text = CostList.Item("tpayledger", subno).Value
                                    CType(CType(CType(Ftb.Controls(ci), PayrollNewPrimaryCostControl).Panel1.Controls(ctcount), PayRollNewListControl).Panel1.Controls(subcount), PayRollNewRowControl).TxtValue.Text = CostList.Item("tvalue", subno).Value
                                    CType(CType(CType(Ftb.Controls(ci), PayrollNewPrimaryCostControl).Panel1.Controls(ctcount), PayRollNewListControl).Panel1.Controls(subcount), PayRollNewRowControl).TxtDrCr.Text = CostList.Item("tdrcr", subno).Value

                                    subcount = subcount + 1
                                End If

                            Next
                            CType(CType(Ftb.Controls(ci), PayrollNewPrimaryCostControl).Panel1.Controls(ctcount), PayRollNewListControl).FindAmountValues()
                            ctcount = ctcount + 1
                        End If
                        CType(Ftb.Controls(ci), PayrollNewPrimaryCostControl).FindAmountValues()
                    Next
                Next
                Try
                    CType(Ftb.Controls(0), PayrollNewPrimaryCostControl).Focus()
                Catch ex3 As Exception

                End Try

            End If
        Catch ex As Exception

        End Try
    End Sub
    Function GetCtrlItems(ByVal ctrlno As Integer, ByVal colno As Integer, ByVal rno As Integer) As String
        If colno = 0 Then
            Return CType(Ftb.Controls(ctrlno), PayrollNewPrimaryCostControl).GetItem(0, rno)
        ElseIf colno = 1 Then
            Return CType(Ftb.Controls(ctrlno), PayrollNewPrimaryCostControl).GetItem(1, rno)
        ElseIf colno = 2 Then
            Return CType(Ftb.Controls(ctrlno), PayrollNewPrimaryCostControl).GetItem(2, rno)
        ElseIf colno = 3 Then
            Return CType(Ftb.Controls(ctrlno), PayrollNewPrimaryCostControl).GetItem(3, rno)
        ElseIf colno = 4 Then
            Return CType(Ftb.Controls(ctrlno), PayrollNewPrimaryCostControl).GetItem(4, rno)
        Else
            Return ""
        End If
    End Function
    Sub SetCtrlItems(ByVal ctrlno As Integer, ByVal colno As Integer, ByVal rno As Integer, ByVal Value As String)
        If colno = 0 Then
            CType(Ftb.Controls(ctrlno), PayrollNewPrimaryCostControl).SetItems(0, rno, Value)
        ElseIf colno = 1 Then
            CType(Ftb.Controls(ctrlno), PayrollNewPrimaryCostControl).SetItems(1, rno, Value)
        ElseIf colno = 2 Then
            CType(Ftb.Controls(ctrlno), PayrollNewPrimaryCostControl).SetItems(2, rno, Value)
        ElseIf colno = 3 Then
            CType(Ftb.Controls(ctrlno), PayrollNewPrimaryCostControl).SetItems(3, rno, Value)
        Else

        End If
    End Sub


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
                If Cb.Items.Contains(CostList.Item("tCostno", i).Value) = False Then
                    Cb.Items.Add(CostList.Item("tCostno", i).Value)
                End If

            Next

        End If
        Return Cb.Items.Count
    End Function
    Function GetEmpCount()
        Dim Ct As Integer = 0
        Dim Cb As New ComboBox
        Cb.Items.Clear()
        If CostList.RowCount = 0 Then
            Return 0
        Else
            For i As Integer = 0 To CostList.RowCount - 1
                If Cb.Items.Contains(CostList.Item("tEmpNo", i).Value) = False Then
                    Cb.Items.Add(CostList.Item("tEmpNo", i).Value)
                End If

            Next

        End If
        Return Cb.Items.Count
    End Function
    Public Sub SaveData()
        CostList.Rows.Clear()
        Dim rno As Integer = 0
        For c1 As Integer = 0 To Ftb.Controls.Count - 1
            For c2 As Integer = 0 To CType(Ftb.Controls(c1), PayrollNewPrimaryCostControl).Panel1.Controls.Count - 1
                For c3 As Integer = 0 To CType(CType(Ftb.Controls(c1), PayrollNewPrimaryCostControl).Panel1.Controls(c2), PayRollNewListControl).Panel1.Controls.Count - 1
                    rno = CostList.Rows.Add
                    CostList.Item("ttranscode", rno).Value = "0"
                    CostList.Item("tcostno", rno).Value = c1.ToString
                    CostList.Item("tempno", rno).Value = c2.ToString
                    CostList.Item("tpcostname", rno).Value = CType(Ftb.Controls(c1), PayrollNewPrimaryCostControl).TxtPrimaryCostCentreName.Text
                    CostList.Item("tempname", rno).Value = CType(CType(Ftb.Controls(c1), PayrollNewPrimaryCostControl).Panel1.Controls(c2), PayRollNewListControl).TxtEmployeeNames.Text
                    CostList.Item("tpayledger", rno).Value = CType(CType(Ftb.Controls(c1), PayrollNewPrimaryCostControl).Panel1.Controls(c2), PayRollNewListControl).GetItem(0, c3)
                    CostList.Item("tvalue", rno).Value = CType(CType(Ftb.Controls(c1), PayrollNewPrimaryCostControl).Panel1.Controls(c2), PayRollNewListControl).GetItem(1, c3)
                    CostList.Item("tdrcr", rno).Value = CType(CType(Ftb.Controls(c1), PayrollNewPrimaryCostControl).Panel1.Controls(c2), PayRollNewListControl).GetItem(2, c3)
                Next
            Next
        Next
    End Sub

    Private Sub ImsButton1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
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
            Dim cb1 As New ComboBox
            cb1.Items.Clear()
            For i1 As Integer = 0 To Ftb.Controls.Count - 1
                If cb1.Items.Contains(CType(Ftb.Controls(i1), PayrollNewPrimaryCostControl).TxtPrimaryCostCentreName.Text) = False Then
                    cb1.Items.Add(CType(Ftb.Controls(i1), PayrollNewPrimaryCostControl).TxtPrimaryCostCentreName.Text)
                    Dim cb2 As New ComboBox
                    cb2.Items.Clear()
                    For k As Integer = 0 To CType(Ftb.Controls(i1), PayrollNewPrimaryCostControl).Panel1.Controls.Count - 1
                        If cb2.Items.Contains(CType(CType(Ftb.Controls(i1), PayrollNewPrimaryCostControl).Panel1.Controls(k), PayRollNewListControl).TxtEmployeeNames.Text) = False Then
                            cb2.Items.Add(CType(CType(Ftb.Controls(i1), PayrollNewPrimaryCostControl).Panel1.Controls(k), PayRollNewListControl).TxtEmployeeNames.Text)
                            Dim cb3 As New ComboBox
                            cb3.Items.Clear()
                            For k2 As Integer = 0 To CType(CType(Ftb.Controls(i1), PayrollNewPrimaryCostControl).Panel1.Controls(k), PayRollNewListControl).Panel1.Controls.Count - 1
                                If cb3.Items.Contains(CType(CType(CType(Ftb.Controls(i1), PayrollNewPrimaryCostControl).Panel1.Controls(k), PayRollNewListControl).Panel1.Controls(k2), PayRollNewRowControl).TxtPayRollLedgerName.Text) = False Then
                                    cb3.Items.Add(CType(CType(CType(Ftb.Controls(i1), PayrollNewPrimaryCostControl).Panel1.Controls(k), PayRollNewListControl).Panel1.Controls(k2), PayRollNewRowControl).TxtPayRollLedgerName.Text)
                                Else
                                    MsgBox("Duplicate Entry, Please Try again......")
                                    CType(CType(CType(Ftb.Controls(i1), PayrollNewPrimaryCostControl).Panel1.Controls(k), PayRollNewListControl).Panel1.Controls(k2), PayRollNewRowControl).TxtPayRollLedgerName.Focus()
                                    val = False
                                    Return val
                                End If
                            Next
                        Else
                            MsgBox("Duplicate Entry, Please Try again......")
                            CType(CType(Ftb.Controls(i1), PayrollNewPrimaryCostControl).Panel1.Controls(k), PayRollNewListControl).TxtEmployeeNames.Focus()
                            val = False
                            Return val
                        End If
                    Next


                Else
                    MsgBox("Duplicate Entry, Please Try Again.....")
                    CType(Ftb.Controls(i1), CostCenterControl).TxtCostCatName.Focus()
                    val = False
                    Return val
                End If


            Next
        End If
        Return val
    End Function

    Private Sub BtnOk_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        IsCompletedOneCost = False
    End Sub
End Class
