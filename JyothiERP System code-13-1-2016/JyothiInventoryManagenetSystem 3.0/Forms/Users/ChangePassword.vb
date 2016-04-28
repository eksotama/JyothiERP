Imports System.Windows.Forms

Public Class ChangePassword
    Dim var_emailid As String
    Dim var_IsUserID As Boolean = False
    Sub New(ByVal emailid As String, Optional ByVal UserID As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()
        var_emailid = emailid
        TxtTitle.Text = "Change Password for Email Id: " & var_emailid
        var_IsUserID = UserID
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If TxtPassword1.Text.Length < 6 Then
            MsgBox("The Password length is minimum 6 letters  ....", MsgBoxStyle.Information)
            TxtPassword1.Focus()
            Exit Sub
        End If
        If TxtPassword2.Text.Length < 6 Then
            MsgBox("The Password length is minimum 6 letters  ....", MsgBoxStyle.Information)
            TxtPassword2.Focus()
            Exit Sub
        End If
        If TxtPassword1.Text = TxtPassword2.Text Then
            If var_IsUserID = True Then
                If SQLIsFieldExists("SELECT TOP 1 1 from   users where UserID=N'" & var_emailid & "'") = True Then
                    ExecuteSQLQuery("update users set userpassword=N'" & EncrypPassword(TxtPassword1.Text) & "' where UserID=N'" & var_emailid & "'")
                ElseIf SQLIsFieldExists("SELECT TOP 1 1 from   Company where adminname=N'" & var_emailid & "'") = True Then
                    ExecuteSQLQuery("update company set adminpassword=N'" & EncrypPassword(TxtPassword1.Text) & "' where adminname=N'" & var_emailid & "'")
                End If
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                If SQLIsFieldExists("SELECT TOP 1 1 from   users where useremailid=N'" & var_emailid & "'") = True Then
                    ExecuteSQLQuery("update users set userpassword=N'" & EncrypPassword(TxtPassword1.Text) & "' where useremailid=N'" & var_emailid & "'")
                ElseIf SQLIsFieldExists("SELECT TOP 1 1 from   Company where adminemailid=N'" & var_emailid & "'") = True Then
                    ExecuteSQLQuery("update company set adminpassword=N'" & EncrypPassword(TxtPassword1.Text) & "' where adminemailid=N'" & var_emailid & "'")
                End If
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
           
        Else
            MsgBox("The passwords did not match, Please try again.....", MsgBoxStyle.Information)
            TxtPassword1.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub BtnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancle.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class
