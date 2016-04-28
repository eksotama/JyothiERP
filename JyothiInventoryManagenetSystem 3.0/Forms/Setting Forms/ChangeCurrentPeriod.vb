Imports System.Windows.Forms

Public Class ChangeCurrentPeriod

    Private Sub ChangeCurrentPeriod_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub ChangeCurrentPeriod_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtDateStart.Value = Today.AddMonths(-1)
        TxtDateEnd.Value = Today

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If TxtDateStart.Value.Date > TxtDateEnd.Value.Date Then
            Dim temp As New DateTimePicker
            temp.Value = TxtDateStart.Value
            TxtDateStart.Value = TxtDateEnd.Value
            TxtDateEnd.Value = temp.Value
        End If
        'ExecuteSQLQuery("update userlogfile set logouttime=CONVERT(datetime,'" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "',101)  where transcode=" & UserLogInlogoutID)
        ExecuteSQLQuery("update company set PeriodFrom=CONVERT(datetime,'" & TxtDateStart.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101) ,PeriodTo=CONVERT(datetime,'" & TxtDateEnd.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101)  ")
        EntryCurrentPeriodStart.Value = TxtDateStart.Value
        EntryCurrentPeriodEnd.Value = TxtDateEnd.Value

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub
End Class
