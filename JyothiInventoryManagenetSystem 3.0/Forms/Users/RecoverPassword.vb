Imports System.Windows.Forms

Public Class RecoverPassword
    Dim IsSendRecover As Boolean = False
    Dim cd As Long = 0

    Private Sub RecoverPassword_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub RecoverPassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadEmailSettings()

        BtnEmailID.Checked = True
        If IsEmailIsConfigured = True Then
            BtnEmailID.Enabled = True
            P1.Visible = True
            P2.Visible = False
        Else
            BtnEmailID.Checked = False
            BtnEmailID.Enabled = False
            P1.Visible = False
            P2.Visible = True
        End If

    End Sub

    Private Sub BtnQ_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQ.CheckedChanged, BtnEmailID.CheckedChanged

        If BtnEmailID.Checked = True Then
            P1.Visible = True
            P2.Visible = False
        Else
            P1.Visible = False
            P2.Visible = True
        End If

    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If BtnEmailID.Checked = True Then
            If IsSendRecover = True Then
                If TxtCode.Text = cd.ToString Then
                    Dim k As New ChangePassword(TxtEmailId.Text)
                    If k.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Me.Close()
                    End If
                Else
                    MsgBox("The Recovery Code is invalid, Try again....", MsgBoxStyle.Information)
                    Exit Sub
                End If

            Else

                If ValidateEmailID(TxtEmailId.Text) = False Then
                    MsgBox("Invalid Email Id , Please Enter The Email ID..", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If SQLIsFieldExists("SELECT TOP 1 1 from   users where useremailid=N'" & TxtEmailId.Text & "'") = True Then
                    Dim ks As New Random
                    cd = ks.Next(254584, 985878)
                    SendCustomEmailTo(TxtEmailId.Text, "Password Recovery Code", "The Recovery code for the user: " & TxtUserID.Text & " :<b>" & cd.ToString & "</b>")
                    IsSendRecover = True
                    BtnQ.Enabled = False
                    TxtEmailId.Enabled = False
                    P2.Visible = False
                    p3.Visible = True
                    PanelCode.Visible = True
                ElseIf SQLIsFieldExists("SELECT TOP 1 1 from   Company where adminemailid=N'" & TxtEmailId.Text & "'") = True Then
                    Dim ks As New Random
                    cd = ks.Next(254584, 985878)
                    SendCustomEmailTo(TxtEmailId.Text, "Password Recovery Code", "The Recovery code for the user: " & TxtUserID.Text & " <b>" & cd.ToString & "</b>")
                    IsSendRecover = True
                    BtnQ.Enabled = False
                    TxtEmailId.Enabled = False
                    P2.Visible = False
                    p3.Visible = True
                    PanelCode.Visible = True
                Else
                    MsgBox("The Email ID is not found in database....", MsgBoxStyle.Information)
                    TxtEmailId.Focus()
                    Exit Sub
                End If
            End If
        Else
            If TxtUserID.Text.Length < 3 Then
                MsgBox("Please Enter the User Name       ", MsgBoxStyle.Information)
                TxtUserID.Focus()
                Exit Sub
            End If
            If SQLIsFieldExists("SELECT TOP 1 1 from   users where userid=N'" & TxtUserID.Text & "'") = True Then
                If TxtA1.Text = SQLGetStringFieldValue("select UserSecurityA1 from users where userid=N'" & TxtUserID.Text & "'", "UserSecurityA1") And TxtA2.Text = SQLGetStringFieldValue("select UserSecurityA2 from users where userid=N'" & TxtUserID.Text & "'", "UserSecurityA2") Then
                    Dim k As New ChangePassword(TxtUserID.Text, True)
                    If k.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Me.Close()
                    End If
                End If

            ElseIf SQLIsFieldExists("SELECT TOP 1 1 from   Company where adminname=N'" & TxtUserID.Text & "'") = True Then
                If TxtA1.Text = SQLGetStringFieldValue("select UserSecurityA1 from Company where adminname=N'" & TxtUserID.Text & "'", "UserSecurityA1") And TxtA2.Text = SQLGetStringFieldValue("select UserSecurityA2 from Company where adminname=N'" & TxtUserID.Text & "'", "UserSecurityA2") Then
                    Dim k As New ChangePassword(TxtUserID.Text, True)
                    If k.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Me.Close()
                    End If
                End If
            Else
                MsgBox("Found Nothing...")
            End If
        End If
    End Sub

    Private Sub BtnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancle.Click
        Me.Close()
    End Sub

    Private Sub TxtUserID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtUserID.LostFocus
        TxtQ1.Text = ""
        TxtQ2.Text = ""
        TxtA1.Text = ""
        TxtA2.Text = ""
        If SQLIsFieldExists("SELECT TOP 1 1 from   users where userid=N'" & TxtUserID.Text & "'") = True Then
            TxtQ1.Text = SQLGetStringFieldValue("select UserSecurityQ1 from users where userid=N'" & TxtUserID.Text & "'", "UserSecurityQ1")
            TxtQ2.Text = SQLGetStringFieldValue("select UserSecurityQ2 from users where userid=N'" & TxtUserID.Text & "'", "UserSecurityQ2")
        ElseIf SQLIsFieldExists("SELECT TOP 1 1 from   Company where adminname=N'" & TxtUserID.Text & "'") = True Then
            TxtQ1.Text = SQLGetStringFieldValue("select UserSecurityQ1 from Company where adminname=N'" & TxtUserID.Text & "'", "UserSecurityQ1")
            TxtQ2.Text = SQLGetStringFieldValue("select UserSecurityQ2 from Company where adminname=N'" & TxtUserID.Text & "'", "UserSecurityQ2")
        End If
    End Sub

   
   
End Class
