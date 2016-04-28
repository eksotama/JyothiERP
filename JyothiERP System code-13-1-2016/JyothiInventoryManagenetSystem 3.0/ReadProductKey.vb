Imports System.Windows.Forms

Public Class ReadProductKey

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If txtpcode.Text = ProductKeyCode Then
            My.Settings.keycode = GetHDDSErialNumber(Application.StartupPath, "2323")
            My.Settings.Save()
        Else
            MsgBox("The Invalid Product Key...      ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
