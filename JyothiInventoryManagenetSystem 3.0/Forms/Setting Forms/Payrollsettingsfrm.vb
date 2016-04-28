Imports System.Windows.Forms

Public Class Payrollsettingsfrm

   

    Private Sub OK_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If TxtPayrollVhPapersize.Text = "A5" Then
            My.Settings.PrintonA5 = "YES"
        Else
            My.Settings.PrintonA5 = "NO"
        End If
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub Payrollsettingsfrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub Payrollsettingsfrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If My.Settings.PrintonA5 = "YES" Then
            TxtPayrollVhPapersize.Text = "A5"
        Else
            TxtPayrollVhPapersize.Text = "A4"
        End If
    End Sub
End Class
