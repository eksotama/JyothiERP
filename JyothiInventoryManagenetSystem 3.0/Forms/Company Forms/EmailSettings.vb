Imports System.Windows.Forms

Public Class EmailSettings

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If txtEmailID.Text.Length < 2 Then
            MsgBox("Please Enter the Email ID....")
            txtEmailID.Focus()
            Exit Sub
        End If
        If ValidateEmailID(txtEmailID.Text) = False Then
            MsgBox("The Email ID is not valid....")
            txtEmailID.Focus()
        End If
        If TxtPassword.Text.Length < 3 Then
            MsgBox("Please Enter the Password... ")
            TxtPassword.Focus()
            Exit Sub
        End If
        If TxtServer.Text.Length < 2 Then
            MsgBox("Please Enter the Server Name ...")
            TxtServer.Focus()
        End If
        If MsgBox("Do you want to Save ?             ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        If IsEmailIsConfigured = True Then
            ExecuteSQLQuery("UPDATE [EmailDb]  SET [EmailID] ='" & txtEmailID.Text & "',[EmailPassword] ='" & EncrypPassword(TxtPassword.Text) & "',[ServerName] ='" & TxtServer.Text & "',[Port] =" & TxtPort.Text & ",emailfooter=N'" & TxtFootermsg.Text & "',IsSSL='" & IsItSSL.Text & "'")
        Else
            ExecuteSQLQuery("INSERT INTO [EmailDb] ([EmailID],[EmailPassword],[ServerName],[Port],[emailfooter],[IsSSL])  VALUES('" & txtEmailID.Text & "','" & EncrypPassword(TxtPassword.Text) & "','" & TxtServer.Text & "'," & TxtPort.Text & ",N'" & TxtFootermsg.Text & "','" & IsItSSL.Text & "')")
        End If
        LoadEmailSettings()
        Me.Close()
    End Sub

    Private Sub EmailSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ERPInitializeObjects(Me)
        If IsEmailIsConfigured = True Then
            txtEmailID.Text = EmailValues.EmailId
            TxtPassword.Text = EmailValues.Password
            TxtServer.Text = EmailValues.Server
            TxtPort.Text = EmailValues.Port
            TxtFootermsg.Text = EmailValues.Footermsg
            IsItSSL.Text = EmailValues.ISitSSL
        Else
            txtEmailID.Text = ""
            TxtPassword.Text = ""
            TxtServer.Text = ""
            TxtPort.Text = ""
            TxtFootermsg.Text = ""
            IsItSSL.Text = "YES"
        End If
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        EmailHelp.ShowDialog()
    End Sub
End Class
