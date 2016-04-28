Imports System.Windows.Forms

Public Class ReadOpBatchNoExpiry
    Public TotalQTY As Double = 0
    Public CUrrentTotalQty As Double = 0
    Public UStockBcode As String = ""
    Dim itemunitname As String = ""
    Dim Plist As New DataGridView
    Function FindTotalQty() As Double
        Dim kt As Double = 0
        For i As Integer = 0 To TxtList.RowCount - 1
            kt = kt + CDbl(TxtList.Item("ttotalqty", i).Value)
        Next
        Return kt
    End Function

    Sub New(ByRef blist As DataGridView, ByVal locname As String, ByVal totqty As Double, ByVal unitname As String)

        ' This call is required by the designer.
        InitializeComponent()
        TxtLocation.Text = locname
        TotalQTY = totqty
        itemunitname = unitname
        Plist = blist
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub


    Private Sub TxtList_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles TxtList.RowsRemoved

        CUrrentTotalQty = FindTotalQty()
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        savedata()
    End Sub
    Sub savedata()
        If MsgBox("Do you want to accept ?     ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        If FindTotalQty() = TotalQTY Then
            Plist.Rows.Clear()
            For i As Integer = 0 To TxtList.RowCount - 1
                Dim rno As Integer = 0
                rno = Plist.Rows.Add
                Plist.Item("tlocation", rno).Value = TxtList.Item("tlocation", i).Value
                Plist.Item("tbatchno", rno).Value = TxtList.Item("tbatchno", i).Value
                Plist.Item("texpiry", rno).Value = TxtList.Item("texpiry", i).Value
                Plist.Item("tqtytext", rno).Value = TxtList.Item("tqtytext", i).Value
                Plist.Item("tmrp", rno).Value = TxtList.Item("tmrp", i).Value
                Plist.Item("trate", rno).Value = TxtList.Item("trate", i).Value
                Plist.Item("tvalue", rno).Value = TxtList.Item("tvalue", i).Value
                Plist.Item("ttotalqty", rno).Value = TxtList.Item("ttotalqty", i).Value
                Plist.Item("tmainunitqty", rno).Value = TxtList.Item("tmainunitqty", i).Value
                Plist.Item("tsubunitqty", rno).Value = TxtList.Item("tsubunitqty", i).Value
            Next
            Me.Close()
        Else
            MsgBox("The Total Quantity does't match... ")
            Exit Sub
        End If
    End Sub
    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        If TxtBatchNo.Text.Length = 0 Then
            MsgBox("Enter the Batch Number....", MsgBoxStyle.Information)
            TxtBatchNo.Focus()
            Exit Sub
        End If
        If TxtExpiry.Value <= Today Then
            MsgBox("Please Chane Expiry Date, It is below the Current Date ... ", MsgBoxStyle.Information)
            TxtExpiry.Focus()
            Exit Sub
        End If
        If CDbl(TxtRate.Text) = 0 Then
            MsgBox("Enter the Rate of the Item.... ", MsgBoxStyle.Information)
            TxtRate.Focus()
            Exit Sub
        End If
        If FindTotalQty() + TxtQty.GetTotalQty > TotalQTY Then
            MsgBox("Invalid Quatity, Quantity Does't  match.... ")
            Exit Sub
        Else
            If IsBatchIsAlreadyExists(TxtBatchNo.Text) = True Then
                MsgBox("The batch number is already exists...")
                TxtBatchNo.Focus()
                Exit Sub
            Else
                Dim rno As Integer = 0
                rno = TxtList.Rows.Add
                TxtList.Item("tlocation", rno).Value = TxtLocation.Text
                TxtList.Item("tbatchno", rno).Value = TxtBatchNo.Text
                TxtList.Item("texpiry", rno).Value = TxtExpiry.Value
                TxtList.Item("tqtytext", rno).Value = TxtQty.GetTotalQtyText
                TxtList.Item("tmrp", rno).Value = TxtMRP.Text
                TxtList.Item("trate", rno).Value = TxtRate.Text
                TxtList.Item("tvalue", rno).Value = CDbl(TxtRate.Text) * TxtQty.GetTotalQty / TxtQty.GetConverionUnit
                TxtList.Item("ttotalqty", rno).Value = TxtQty.GetTotalQty
                TxtList.Item("tmainunitqty", rno).Value = TxtQty.GetUnitQtys(0)
                TxtList.Item("tsubunitqty", rno).Value = TxtQty.GetUnitQtys(1)
                If FindTotalQty() = TotalQTY Then
                    savedata()
                Else
                    TxtBatchNo.Focus()
                End If
                TxtBatchNo.Text = ""
                TxtQty.TxtQty1.Text = "0"
                TxtQty.TxtQty2.Text = "0"
                TxtMRP.Text = "0"
                TxtRate.Text = "0"



            End If


        End If
    End Sub
    Function IsBatchIsAlreadyExists(ByVal btno As String)
        Dim retval As Boolean = False
        For i As Integer = 0 To TxtList.RowCount - 1
            If UCase(btno) = UCase(TxtList.Item("tbatchno", i).Value) Then
                retval = True
                Exit For
            End If
        Next
        Return retval
    End Function

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub ReadOpBatchNoExpiry_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtBatchNo.Focus()
    End Sub

    Private Sub ReadOpBatchNoExpiry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtExpiry.Value = Today.AddDays(1)
        TxtQty.SetUnitName(itemunitname)
        TxtBatchNo.Focus()
    End Sub

  
    Private Sub TxtList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub

    Private Sub TxtList_UserDeletingRow(sender As Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles TxtList.UserDeletingRow
        If MsgBox("Do you want to Delete Current Row? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            e.Cancel = True

        End If
    End Sub
End Class
