Imports System.Windows.Forms

Public Class ChangeRecoveryOptions

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If TxtQ1.Text.Length < 3 Or TxtQ2.Text.Length < 3 Or TxtA1.Text.Length < 3 Or TxtA2.Text.Length < 3 Then
            MsgBox("Please Entere the Required fileds...", MsgBoxStyle.Information)
            TxtQ1.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to Save Changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        If SQLIsFieldExists("SELECT TOP 1 1 from   users where userid=N'" & CurrentUserName & "'") = True Then
            ExecuteSQLQuery("update users set UserSecurityQ1=N'" & TxtQ1.Text & "',UserSecurityQ2=N'" & TxtQ2.Text & "',UserSecurityA1=N'" & TxtA1.Text & "',UserSecurityA2=N'" & TxtA2.Text & "' where userid=N'" & CurrentUserName & "'")
        ElseIf SQLIsFieldExists("SELECT TOP 1 1 from   Company where adminname=N'" & CurrentUserName & "'") = True Then
            ExecuteSQLQuery("update Company set UserSecurityQ1=N'" & TxtQ1.Text & "',UserSecurityQ2=N'" & TxtQ2.Text & "',UserSecurityA1=N'" & TxtA1.Text & "',UserSecurityA2=N'" & TxtA2.Text & "' where adminname=N'" & CurrentUserName & "'")
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Sub LoadData()
        If IsUserAdmin = True Then
            TxtA1.Text = SQLGetStringFieldValue("select UserSecurityA1 from Company where adminname=N'" & CurrentUserName & "'", "UserSecurityA1")
            TxtA2.Text = SQLGetStringFieldValue("select UserSecurityA2 from Company where adminname=N'" & CurrentUserName & "'", "UserSecurityA2")
            TxtQ1.Text = SQLGetStringFieldValue("select UserSecurityQ1 from Company where adminname=N'" & CurrentUserName & "'", "UserSecurityQ1")
            TxtQ2.Text = SQLGetStringFieldValue("select UserSecurityQ2 from Company where adminname=N'" & CurrentUserName & "'", "UserSecurityQ2")
        Else
            TxtA1.Text = SQLGetStringFieldValue("select UserSecurityA1 from users where userid=N'" & CurrentUserName & "'", "UserSecurityA1")
            TxtA2.Text = SQLGetStringFieldValue("select UserSecurityA2 from users where userid=N'" & CurrentUserName & "'", "UserSecurityA2")
            TxtQ1.Text = SQLGetStringFieldValue("select UserSecurityQ1 from users where userid=N'" & CurrentUserName & "'", "UserSecurityQ1")
            TxtQ2.Text = SQLGetStringFieldValue("select UserSecurityQ2 from users where userid=N'" & CurrentUserName & "'", "UserSecurityQ2")
        End If
       
    End Sub
    Private Sub BtnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancle.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ChangeRecoveryOptions_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub ChangeRecoveryOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadData()
    End Sub
End Class
