Public Class IMSDate
    Private FontSizeGotFocus As Single = FontForGotFocus
    Private FontSizeLoseFocus As Single = FontForLostFocus
    Private IsShitPressed As Boolean = False
    Private Sub IMSDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Shift = True And e.KeyCode = Keys.Return Then
            IsShitPressed = True
            Me.TopLevelControl.SelectNextControl(sender, False, True, True, True)
            Exit Sub
        Else
            IsShitPressed = False
        End If
    End Sub

    Private Sub IMSDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(Keys.Escape) And IsExitOnEscKey = True Then
            Me.FindForm.Dispose()
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            If IsShitPressed = True Then Exit Sub
            Me.TopLevelControl.SelectNextControl(sender, True, True, True, True)
        End If
    End Sub
End Class
