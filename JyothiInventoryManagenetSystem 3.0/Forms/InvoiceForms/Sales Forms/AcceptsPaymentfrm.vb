Imports System.Windows.Forms

Public Class AcceptsPaymentfrm
    Dim CashAmount As Double = 0
    Sub New(total As Double)

        ' This call is required by the designer.
        InitializeComponent()
        TxtTotalBillAmount.Text = FormatNumber(total, 2)
        TxtBalance.Text = TxtTotalBillAmount.Text
        TxtTradeValue.Text = TxtTotalBillAmount.Text
        TxtTotalBillAmount.SelectAll()
        TxtTotal.Text = "0"
        TxtCashtoPay.Text = "0"
        TxtReceivedCash.Text = "0"
        ' Add any initialization after the InitializeComponent() call.

    End Sub

 

    Private Sub Label11_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Label11.MouseDown, Label9.MouseDown, Label8.MouseDown, Label7.MouseDown, Label6.MouseDown, Label5.MouseDown, Label4.MouseDown, Label3.MouseDown, B6.MouseDown, B5.MouseDown, Label20.MouseDown, Label2.MouseDown, B4.MouseDown, B3.MouseDown, B2.MouseDown, Label16.MouseDown, Label15.MouseDown, Label14.MouseDown, B1.MouseDown, Label12.MouseDown, Label10.MouseDown, Label1.MouseDown, Label24.MouseDown, Label23.MouseDown, B9.MouseDown, B8.MouseDown, B7.MouseDown
        sender.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub Label11_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Label11.MouseUp, Label9.MouseUp, Label8.MouseUp, Label7.MouseUp, Label6.MouseUp, Label5.MouseUp, Label4.MouseUp, Label3.MouseUp, B6.MouseUp, B5.MouseUp, Label20.MouseUp, Label2.MouseUp, B4.MouseUp, B3.MouseUp, B2.MouseUp, Label16.MouseUp, Label15.MouseUp, Label14.MouseUp, B1.MouseUp, Label12.MouseUp, Label10.MouseUp, Label1.MouseUp, B9.MouseUp, B8.MouseUp, B7.MouseUp
        sender.BorderStyle = BorderStyle.FixedSingle

        If sender.TEXT.ToUPPER = "B" Then
            SendKeys.Send("{BACKSPACE}")
        ElseIf sender.TEXT.ToUPPER = "ENTER" Then
            SendKeys.Send("{ENTER}")
        ElseIf sender.TEXT.ToUPPER = "TAB" Then
            SendKeys.Send("{TAB}")
        ElseIf sender.TEXT.ToUPPER = "DEL" Then
            SendKeys.Send("{DELETE}")
        ElseIf sender.TEXT.ToUPPER = "L" Then
            SendKeys.Send("{LEFT}")
        ElseIf sender.TEXT.ToUPPER = "R" Then
            SendKeys.Send("{RIGHT}")
        ElseIf sender.TEXT.ToUPPER = "D" Then
            SendKeys.Send("{DOWN}")
        ElseIf sender.TEXT.ToUPPER = "U" Then
            SendKeys.Send("{UP}")
        ElseIf sender.TEXT.ToUPPER = "-" Then
            SendKeys.Send("-")

        Else
            SendKeys.Send(sender.text)
        End If
    End Sub

   

    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click
        If CDbl(TxtTradeValue.Text) > CDbl(TxtBalance.Text) Then
            MsgBox("The Amount is exceds the Balance Amount....", MsgBoxStyle.Information)
            Exit Sub
        End If
        If CDbl(TxtTradeValue.Text) <= 0 Then Exit Sub
        If TxtList.Find("sttype", "cash") = True Then
            MsgBox("The Cash is already added, Please Change the Amount from the List..")
            Exit Sub
        Else
            AddPaymentstoList("Cash")
        End If
    End Sub
    Public Sub AddPaymentstoList(ptype As String)
        Dim dr As Integer = 0
        dr = TxtList.Rows.Add
        TxtList.Item("stsno", dr).Value = dr + 1
        TxtList.Item("sttype", dr).Value = ptype
        TxtList.Item("stamount", dr).Value = CDbl(TxtTradeValue.Text)
        findtotal()
        TxtBalance.Text = FormatNumber(CDbl(TxtTotalBillAmount.Text) - CDbl(TxtTotal.Text), 2)
        TxtTradeValue.Text = TxtBalance.Text
        TxtTradeValue.SelectAll()
        TxtTradeValue.Focus()
        FindCashAmount()
        If CDbl(TxtBalance.Text) = 0 Then
            TxtReceivedCash.Focus()
        End If
    End Sub
    Sub findtotal()
        Dim tot As Double = 0
        For i As Integer = 0 To TxtList.Rows.Count - 1
            tot = tot + CDbl(TxtList.Item("stamount", i).Value)
        Next
        TxtTotal.Text = FormatNumber(tot, 2)
        TxtBalance.Text = FormatNumber(CDbl(TxtTotalBillAmount.Text) - CDbl(TxtTotal.Text), 2)
        FindCashAmount()
    End Sub
    Private Sub ImsButton2_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton2.Click
        If CDbl(TxtTradeValue.Text) > CDbl(TxtBalance.Text) Then
            MsgBox("The Amount is exceds the Balance Amount....", MsgBoxStyle.Information)
            Exit Sub
        End If
        If CDbl(TxtTradeValue.Text) <= 0 Then Exit Sub
        AddPaymentstoList("Credit Card")
    End Sub

    Private Sub BtnOk_Click(sender As System.Object, e As System.EventArgs) Handles BtnOk.Click
        If CDbl(TxtBalance.Text) <> 0 Then
            MsgBox("The Amount is not match the bill Amount, Please Try again...", MsgBoxStyle.Information)
            TxtTradeValue.Focus()
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Label8_Click(sender As System.Object, e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label24_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Label24.MouseUp
        TxtTradeValue.Text = CDbl(TxtTradeValue.Text) - 1
    End Sub

    Private Sub Label23_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Label23.MouseUp
        TxtTradeValue.Text = CDbl(TxtTradeValue.Text) + 1
    End Sub

    Private Sub ImsButton3_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton3.Click
        If CDbl(TxtTradeValue.Text) > CDbl(TxtBalance.Text) Then
            MsgBox("The Amount is exceds the Balance Amount....", MsgBoxStyle.Information)
            Exit Sub
        End If
        If CDbl(TxtTradeValue.Text) <= 0 Then Exit Sub
        AddPaymentstoList("Cheque")
    End Sub

    Private Sub ImsButton4_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton4.Click
        If CDbl(TxtTradeValue.Text) > CDbl(TxtBalance.Text) Then
            MsgBox("The Amount is exceds the Balance Amount....", MsgBoxStyle.Information)
            Exit Sub
        End If
        If CDbl(TxtTradeValue.Text) <= 0 Then Exit Sub
        AddPaymentstoList("Gift Card")
    End Sub

    Private Sub ImsButton5_Click(sender As System.Object, e As System.EventArgs) Handles btnOnaccount.Click
        If CDbl(TxtTradeValue.Text) > CDbl(TxtBalance.Text) Then
            MsgBox("The Amount is exceds the Balance Amount....", MsgBoxStyle.Information)
            Exit Sub
        End If
        If CDbl(TxtTradeValue.Text) <= 0 Then Exit Sub
        AddPaymentstoList("On Account")
    End Sub

    Private Sub AcceptsPaymentfrm_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

    End Sub

    Private Sub AcceptsPaymentfrm_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub AcceptsPaymentfrm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        TxtTradeValue.SelectAll()
        TxtTradeValue.Focus()
        TxtTradeValue.Text = TxtBalance.Text
        If CDbl(TxtBalance.Text) = 0 Then
            TxtReceivedCash.Focus()
        End If
    End Sub

    Private Sub TxtList_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellEndEdit
        findtotal()
        FindCashAmount()
    End Sub
    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles TxtList.EditingControlShowing
        If TxtList.Columns("stamount").Index = TxtList.CurrentCell.ColumnIndex Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress1
        End If


    End Sub



    Private Sub TextBox_keyPress1(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            Exit Sub
        End If
        e.Handled = Not (IsNumeric(e.KeyChar) Or (e.KeyChar = "." And Not CBool(InStr(sender.Text, "."))))

        If e.KeyChar = Chr(&H8) Then e.Handled = False


    End Sub

    Private Sub TxtReceivedCash_Click(sender As Object, e As System.EventArgs) Handles TxtReceivedCash.Click
        TxtReceivedCash.SelectionStart = 0
        TxtReceivedCash.SelectionLength = TxtReceivedCash.Text.Length
    End Sub

    Private Sub TxtReceivedCash_GotFocus(sender As Object, e As System.EventArgs) Handles TxtReceivedCash.GotFocus

        Dim dival As Integer = 0
        If CLng(CashAmount).ToString.Length < 3 Then
            dival = CLng(CashAmount) Mod 10
        Else
            dival = CLng(CashAmount) Mod 100
        End If

        B1.Text = CLng(CashAmount) - dival + 50
        B2.Text = CLng(CashAmount) - dival + 100
        B3.Text = CLng(CashAmount) - dival + 150
        B4.Text = CLng(CashAmount) - dival + 200
        B5.Text = CLng(CashAmount) - dival + 250
        B6.Text = CLng(CashAmount) - dival + 300

        If CLng(CashAmount) < 500 Then
            B7.Text = 500
            B8.Text = 300
            B9.Text = 1000
        ElseIf CLng(CashAmount) < 2000 Then
            B7.Text = 1000
            B8.Text = 1500
            B9.Text = 2000
        ElseIf CLng(CashAmount) < 3000 Then
            B7.Text = 2000
            B8.Text = 2500
            B9.Text = 3000
        ElseIf CLng(CashAmount) < 5000 Then
            B7.Text = 4000
            B8.Text = 4500
            B9.Text = 5000
        ElseIf CLng(CashAmount) < 7000 Then
            B7.Text = 6000
            B8.Text = 6500
            B9.Text = 7000
        ElseIf CLng(CashAmount) < 10000 Then
            B6.Text = 7500
            B7.Text = 8000
            B8.Text = 9000
            B9.Text = 10000
        ElseIf CLng(CashAmount) < 20000 Then
            B7.Text = 14000
            B8.Text = 15000
            B9.Text = 20000
        End If
      
    End Sub

    Private Sub TxtReceivedCash_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtReceivedCash.TextChanged
        On Error Resume Next
        TxtCashtoPay.Text = CDbl(TxtReceivedCash.Text) - CashAmount

    End Sub
    Sub FindCashAmount()
        CashAmount = 0
        For i As Integer = 0 To TxtList.Rows.Count - 1
            If TxtList.Item("sttype", i).Value = "Cash" Then
                Try
                    CashAmount = CDbl(TxtList.Item("stamount", i).Value)
                Catch ex As Exception
                    CashAmount = 0
                End Try
                Exit For
            End If
        Next
    End Sub

    Private Sub TxtTradeValue_GotFocus(sender As Object, e As System.EventArgs) Handles TxtTradeValue.GotFocus
        Dim dival As Integer = 0
        If CLng(TxtBalance.Text).ToString.Length < 3 Then
            dival = CLng(CashAmount) Mod 10
            If CLng(TxtBalance.Text) < 200 Then
                B1.Text = (TxtBalance.Text) - dival + 10
                B2.Text = CLng(TxtBalance.Text) - dival + 50
                B3.Text = CLng(TxtBalance.Text) - dival + 40
                B4.Text = CLng(TxtBalance.Text) - dival + 100
                B5.Text = CLng(TxtBalance.Text) - dival + 200
                B6.Text = CLng(TxtBalance.Text) - dival + 250
                B7.Text = CLng(TxtBalance.Text) - dival + 500
                B8.Text = CLng(TxtBalance.Text) - dival + 750
                B9.Text = CLng(TxtBalance.Text) - dival + 1000
            Else
                B1.Text = CLng(TxtBalance.Text) - dival - 100
                B2.Text = CLng(TxtBalance.Text) - dival - 150
                B3.Text = CLng(TxtBalance.Text) - dival + 50
                B4.Text = CLng(TxtBalance.Text) - dival + 100
                B5.Text = CLng(TxtBalance.Text) - dival + 150
                B6.Text = CLng(TxtBalance.Text) - dival + 200
                B7.Text = CLng(TxtBalance.Text) - dival + 250
                B8.Text = CLng(TxtBalance.Text) - dival + 350
                B9.Text = CLng(TxtBalance.Text) - dival + 500
            End If
        Else
            dival = CLng(CashAmount) Mod 100
            If CLng(TxtBalance.Text) < 200 Then
                B1.Text = (TxtBalance.Text) - dival + 50
                B2.Text = CLng(TxtBalance.Text) - dival + 100
                B3.Text = CLng(TxtBalance.Text) - dival + 150
                B4.Text = CLng(TxtBalance.Text) - dival + 250
                B5.Text = CLng(TxtBalance.Text) - dival + 300
                B6.Text = CLng(TxtBalance.Text) - dival + 350
                B7.Text = CLng(TxtBalance.Text) - dival + 500
                B8.Text = CLng(TxtBalance.Text) - dival + 750
                B9.Text = CLng(TxtBalance.Text) - dival + 1000
            Else
                B1.Text = CLng(TxtBalance.Text) - dival - 100
                B2.Text = CLng(TxtBalance.Text) - dival - 150
                B3.Text = CLng(TxtBalance.Text) - dival + 50
                B4.Text = CLng(TxtBalance.Text) - dival + 100
                B5.Text = CLng(TxtBalance.Text) - dival + 150
                B6.Text = CLng(TxtBalance.Text) - dival + 200
                B7.Text = CLng(TxtBalance.Text) - dival + 250
                B8.Text = CLng(TxtBalance.Text) - dival + 350
                B9.Text = CLng(TxtBalance.Text) - dival + 500
            End If
        End If



    End Sub

    Private Sub TxtTradeValue_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtTradeValue.TextChanged

    End Sub

    Private Sub ReceivedToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ReceivedToolStripMenuItem.Click
        TxtReceivedCash.Focus()
    End Sub

    Private Sub AmountToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AmountToolStripMenuItem.Click
        TxtTradeValue.Focus()
    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TxtList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub

    Private Sub TxtList_RowsRemoved(sender As Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles TxtList.RowsRemoved
        findtotal()
        FindCashAmount()
        TxtBalance.Text = FormatNumber(CDbl(TxtTotalBillAmount.Text) - CDbl(TxtTotal.Text), 2)
        TxtTradeValue.Text = TxtBalance.Text
        TxtTradeValue.SelectAll()
        TxtTradeValue.Focus()
        If CDbl(TxtBalance.Text) = 0 Then
            TxtReceivedCash.Focus()
        End If
    End Sub
End Class
