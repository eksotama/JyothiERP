Imports System.Windows.Forms

Public Class SelectAttendenceEntry
    Dim k As New AttendEntryClass
    Sub New(ByRef v As AttendEntryClass)

        ' This call is required by the designer.
        InitializeComponent()
        k = v

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        k.val.Value = TxtDate.Value

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SelectAttendenceEntry_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub SelectAttendenceEntry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtDate.Value = k.val.Value
        TxtDate.MinDate = k.val.Value.Date
        TxtDate.MaxDate = k.val.Value.AddDays(1)
    End Sub
End Class
