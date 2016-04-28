Imports System.Windows.Forms
Imports System.IO

Public Class SqlServersForm

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If TxtServerName.Text.Length <= 2 Then
            MsgBox("Please Enter the Sever Name ", MsgBoxStyle.Information)
            TxtServerName.Focus()
            Exit Sub
        End If
        If TxtUserName.Text.Length = 0 Then
            MsgBox("please enter the User Name ", MsgBoxStyle.Information)
            TxtUserName.Focus()
            Exit Sub
        End If
        If MsgBox("It will take 1 to 5 mins to configure the sql server, Do you want to save ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
            Exit Sub
        End If
        Using sw As StreamWriter = New StreamWriter(Application.StartupPath & "\SQLSettings.dat")
            sw.WriteLine(EncrypPassword(TxtServerName.Text))
            sw.WriteLine(EncrypPassword(TxtUserName.Text))
            sw.WriteLine(EncrypPassword(TxtPassword.Text))
            sw.WriteLine(EncrypPassword("1"))
            sw.Close()
        End Using
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        If MsgBox("Do you want to close the application....", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            End
        End If

    End Sub

    Private Sub SqlServersForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub SqlServersForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        MainForm.Cursor = Cursors.WaitCursor
        TxtServerName.Items.Clear()
        GetServerList(TxtServerName)
        If TxtServerName.Items.Count > 0 Then
            TxtServerName.SelectedIndex = 0
        Else
            MsgBox("No SQL Server found ....              ", MsgBoxStyle.Critical)
        End If
        MainForm.Cursor = Cursors.Default
    End Sub
End Class
