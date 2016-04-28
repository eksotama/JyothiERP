Imports System.Windows.Forms

Public Class AdminLoginForAcceptChages

    Private Sub OK_Click(sender As System.Object, e As System.EventArgs) Handles OK.Click
        Dim sqlstr As String = ""
        
        If UsernameTextBox.Text.Length < 2 Then
            MsgBox("Please Enter the User Name ", MsgBoxStyle.Information)
            UsernameTextBox.Focus()
            Exit Sub
        End If
        If PasswordTextBox.Text.Length < 2 Then
            MsgBox("Please Enter the Password ", MsgBoxStyle.Information)
            PasswordTextBox.Focus()
            Exit Sub
        End If

        sqlstr = "SELECT * FROM COMPANY WHERE [adminname]=N'" & UsernameTextBox.Text & "' AND [adminpassword]=N'" & EncrypPassword(PasswordTextBox.Text) & "'"
        If SQLIsFieldExists(sqlstr) = True Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            MsgBox("Invalid Username or Password...", MsgBoxStyle.Critical)
        End If
       
    End Sub

    Private Sub Cancel_Click(sender As System.Object, e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class
