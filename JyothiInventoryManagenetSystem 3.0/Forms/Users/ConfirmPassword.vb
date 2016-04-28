Imports System.Windows.Forms

Public Class ConfirmPassword

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim SqlStr As String
        SqlStr = "SELECT * FROM COMPANY WHERE [adminname]=N'" & CurrentUserName & "' AND [adminpassword]=N'" & EncrypPassword(PasswordTextBox.Text) & "'"
        If SQLIsFieldExists(sqlstr) = False Then
            SqlStr = "SELECT * FROM users WHERE [userid]=N'" & CurrentUserName & "' AND [userpassword]=N'" & EncrypPassword(PasswordTextBox.Text) & "'"
            If SQLIsFieldExists(sqlstr) = False Then
                MsgBox("Invalid  Password ", MsgBoxStyle.Information, MySoftwareName)
                Me.Cursor = Cursors.Default
                Exit Sub
            Else
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
