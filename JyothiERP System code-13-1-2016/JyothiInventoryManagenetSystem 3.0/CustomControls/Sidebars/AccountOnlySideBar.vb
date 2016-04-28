Public Class AccountOnlySideBar

    Public Sub arrangecontrols(ByVal RowNumber As Integer)
        If TxtMainTable.RowCount = 1 Then Exit Sub
        For i As Integer = 0 To TxtMainTable.RowCount - 1
            If i = RowNumber Then
                TxtMainTable.RowStyles(i).SizeType = 2
                TxtMainTable.RowStyles(i).Height = 100

                CType(TxtMainTable.Controls(i), Panel).AutoScroll = True
            Else
                TxtMainTable.RowStyles(i).SizeType = 1
                TxtMainTable.RowStyles(i).Height = 30
                CType(TxtMainTable.Controls(i), Panel).AutoScroll = False
            End If
        Next
    End Sub






    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        arrangecontrols(0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        arrangecontrols(1)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        arrangecontrols(2)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        arrangecontrols(3)
    End Sub


    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        ConfirmPassword.PasswordTextBox.Text = ""
        If ConfirmPassword.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim k As New ChangePassword(CurrentUserName, True)
            k.ShowDialog()
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked

        ConfirmPassword.PasswordTextBox.Text = ""
        If ConfirmPassword.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ChangeRecoveryOptions.ShowDialog()
        End If
    End Sub
End Class
