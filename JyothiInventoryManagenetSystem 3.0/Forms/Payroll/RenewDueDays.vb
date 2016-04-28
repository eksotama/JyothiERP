Imports System.Windows.Forms

Public Class RenewDueDays
    Dim EmployeeName As String = ""
    Dim IsLeave As Boolean = False
    Sub New(Empname As String, IsLeaveDue As Boolean)

        ' This call is required by the designer.
        InitializeComponent()
        EmployeeName = Empname
        IsLeave = IsLeaveDue
        ' Add any initialization after the InitializeComponent() call.
        If IsLeave = True Then
            Me.Text = "Renew Leave Salary Due"
            Label1.Text = "RENEW LEAVE SALARY DUE"
        Else
            Me.Text = "Renew Air Ticket Due"
            Label1.Text = "RENEW AIR TICKET DUE"
        End If
    End Sub

    Private Sub RenewDueDays_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtEmployeeName.Text = EmployeeName
        TxtDueDays.Text = "0"
        TxtExpiry.Value = Today
    End Sub

    Private Sub BtnCreate_Click(sender As System.Object, e As System.EventArgs) Handles BtnCreate.Click
        If TxtEmployeeName.Text.Length = 0 Then Exit Sub
        If CInt(TxtDueDays.Text) < 0 Then
            MsgBox("Please Enter the Due days... ", MsgBoxStyle.Information)
            TxtDueDays.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to Renew ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If IsLeave = True Then
                ExecuteSQLQuery(" UPDATE EMPLOYEES SET leavesalaryfrom=" & TxtExpiry.Value.Date.ToOADate & ",leavesalaryduedays=" & CInt(TxtDueDays.Text) & " WHERE EMPNAME=N'" & TxtEmployeeName.Text & "'")
            Else
                ExecuteSQLQuery(" UPDATE EMPLOYEES SET airticketfrom=" & TxtExpiry.Value.Date.ToOADate & ",airticketduedays=" & CInt(TxtDueDays.Text) & " WHERE EMPNAME=N'" & TxtEmployeeName.Text & "'")
            End If
            Me.Close()
        End If
    End Sub
End Class
