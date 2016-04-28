Imports System.Windows.Forms

Public Class BillwiseDetailsEntryForm
    Dim OpenedLedgerName As String = ""
    Dim OpenedTranscode As Double
    Dim SqlStrList As String
    Dim SqlStrPaid As String
    Dim RefList As New Bill2BillClass
    Sub New(ByVal LName As String, ByRef bLIST As Bill2BillClass, Optional ByVal Transcode As Double = 0)

        ' This call is required by the designer.
        InitializeComponent()
        OpenedLedgerName = LName
        RefList = bLIST
        OpenedTranscode = bLIST.TransCode

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Private Sub Txtpaidlist_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtPaidList.DataError

    End Sub
    Sub loadData()
        SqlStrList = "select Transcode as [Trans Code],Refno as [Ref No],Invoiceno as [Invoice No],Transdate as [Date],(dr+cr) as [Amount], DATEDIFF(day, TransDate, { fn CURDATE() }) as [No Days],(cr+dr) as [Balance] from bill2bill where billtype='New' and ledgername=N'" & OpenedLedgerName & "' and transcode<>" & OpenedTranscode
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStrList)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        If TxtList.RowCount > 0 Then
            For i As Integer = 0 To TxtList.RowCount - 1
                TxtList.Item("balance", i).Value = TxtList.Item("Amount", i).Value - SQLGetNumericFieldValue("select sum(dr+cr) as tot from bill2bill where ledgername=N'" & OpenedLedgerName & "' and billtype='Against' and refno=N'" & TxtList.Item("ref no", i).Value & "' and transcode<>" & OpenedTranscode, "tot")
            Next
        End If
        TxtPaidList.Rows.Clear()
        For i As Integer = 0 To RefList.BillList.RowCount - 1
            Dim K As Integer
            K = TxtPaidList.Rows.Add()
            TxtPaidList.Item("TTYPE", K).Value = RefList.BillList.Item("TTYPE", i).Value
            TxtPaidList.Item("TCODE", K).Value = RefList.BillList.Item("TCODE", i).Value
            TxtPaidList.Item("TREF", K).Value = RefList.BillList.Item("TREF", i).Value
            TxtPaidList.Item("TAMT", K).Value = RefList.BillList.Item("TAMT", i).Value
        Next
        FindAmount()


    End Sub

    Private Sub BillwiseDetailsEntryForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub


    Private Sub BillwiseDetailsEntryForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loadData()
        RefList.IsNotApplicable = False
    End Sub

    Private Sub TxtList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellClick
        If TxtList.SelectedRows.Count > 0 Then
            TxtRefType.Text = "Against"
            TxtRefNo.Text = TxtList.Item("Ref No", TxtList.CurrentRow.Index).Value
            If RefList.LedgerAmount - CDbl(TxtTotal.Text) > TxtList.Item("Amount", TxtList.CurrentRow.Index).Value Then
                TxtAmount.Text = TxtList.Item("Amount", TxtList.CurrentRow.Index).Value
            Else
                TxtAmount.Text = RefList.LedgerAmount - CDbl(TxtTotal.Text)
            End If
        End If
    End Sub


    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        If TxtRefType.Text.Length = 0 Then
            MsgBox("Please Select the Reference type.... ", MsgBoxStyle.Information)
            TxtRefType.Focus()
            Exit Sub
        End If
        If TxtRefNo.Text.Length = 0 Then
            MsgBox("Please Enter the Reference Number...", MsgBoxStyle.Information)
            TxtRefNo.Focus()
            Exit Sub
        End If
        If CDbl(TxtAmount.Text) <= 0 Then
            MsgBox("Please Enter the Amount..", MsgBoxStyle.Information)
            TxtAmount.Focus()
            Exit Sub
        End If
        Dim found As Boolean = False
        For i As Integer = 0 To TxtPaidList.RowCount - 1
            If UCase(TxtPaidList.Item("tref", i).Value) = UCase(TxtRefNo.Text) Then
                found = True
                Exit For
            End If
        Next
        If found = True Then
            MsgBox("The Reference Number is already exists,.....", MsgBoxStyle.Information)
            TxtRefNo.Focus()
            Exit Sub
        End If
        Dim rno As Integer
        rno = TxtPaidList.Rows.Add
        TxtPaidList.Item("ttype", rno).Value = TxtRefType.Text
        TxtPaidList.Item("tcode", rno).Value = 0
        TxtPaidList.Item("tref", rno).Value = TxtRefNo.Text
        TxtPaidList.Item("tamt", rno).Value = TxtAmount.Text
        FindAmount()

    End Sub

    Sub FindAmount()
        Dim amt As Double = 0
        For i As Integer = 0 To TxtPaidList.RowCount - 1
            amt = amt + CDbl(TxtPaidList.Item("tamt", i).Value)
        Next
        TxtTotal.Text = amt
    End Sub
    
    Private Sub ImsButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Me.Close()
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        If RefList.LedgerAmount = CDbl(TxtTotal.Text) Then
            RefList.BillList.Rows.Clear()
            For i As Integer = 0 To TxtPaidList.RowCount - 1
                Dim K As Integer
                K = RefList.BillList.Rows.Add()
                RefList.BillList.Item("TTYPE", K).Value = TxtPaidList.Item("TTYPE", i).Value
                RefList.BillList.Item("TCODE", K).Value = TxtPaidList.Item("TCODE", i).Value
                RefList.BillList.Item("TREF", K).Value = TxtPaidList.Item("TREF", i).Value
                RefList.BillList.Item("TAMT", K).Value = TxtPaidList.Item("TAMT", i).Value
            Next
            RefList.AllocationAmount = TxtTotal.Text
            Me.Close()
        Else
            MsgBox("The Amount is not tally .....", MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub

    Private Sub TxtRefType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRefType.SelectedIndexChanged
        If TxtRefType.Text = "New" Then
            TxtAmount.Text = RefList.LedgerAmount - CDbl(TxtTotal.Text)
        End If
    End Sub

    Private Sub TxtPaidList_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles TxtPaidList.RowsRemoved
        FindAmount()
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        RefList.AllocationAmount = RefList.LedgerAmount
        RefList.IsNotApplicable = True
        Me.Close()
    End Sub

    Private Sub TxtPaidList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtPaidList.CellContentClick

    End Sub
End Class
