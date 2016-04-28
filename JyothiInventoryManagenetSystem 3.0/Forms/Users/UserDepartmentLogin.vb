Imports System.Windows.Forms

Public Class UserDepartmentLogin

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtDepartment.Text.Length = 0 Then
            MsgBox("Please Select the Department to Login....", MsgBoxStyle.Information)
            TxtDepartment.Focus()
            Exit Sub
        End If
        ' DefDepartment = TxtDepartment.Text
        Me.Close()
    End Sub

    Private Sub UserDepartmentLogin_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub UserDepartmentLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select depname from UserDepartments where userid=N'" & CurrentUserName & "' and isdelete=0", TxtDepartment, "depname")
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
End Class
