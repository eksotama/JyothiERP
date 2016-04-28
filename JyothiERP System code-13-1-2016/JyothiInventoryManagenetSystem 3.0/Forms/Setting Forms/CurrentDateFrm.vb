Imports System.Windows.Forms

Public Class CurrentDateFrm

    Private Sub CurrentDateFrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub


    'CurrentDate
    Private Sub CurrentDateFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtDateStart.Value = EntryCurrentDate.Value
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        ExecuteSQLQuery("update company set CurrentDate=CONVERT(datetime,'" & TxtDateStart.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101)   ")
        EntryCurrentDate.Value = TxtDateStart.Value
    End Sub

    Private Sub TxtDateStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDateStart.ValueChanged

    End Sub
End Class
