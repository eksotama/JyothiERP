Imports System.Windows.Forms

Public Class loginagain

   

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        If MsgBox("The Changes made are not saved!!, Do you want to close the application ?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then
            MainForm.AppLogout()
        End If
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If PasswordTextBox.Text = pwdtextvalues Then
            MainForm.Visible = True
            Me.Close()
        Else
            MsgBox("Invalid Password....")
        End If
    End Sub

    Private Sub loginagain_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub loginagain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        UsernameTextBox.Text = CurrentUserName
        UsernameTextBox.Enabled = False
    End Sub
End Class
