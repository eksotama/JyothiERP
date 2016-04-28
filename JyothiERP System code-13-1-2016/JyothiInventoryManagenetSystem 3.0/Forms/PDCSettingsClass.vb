Public Class PDCSettingsClass
    Public IsPDCClear As Boolean = False
    Public IsPDC As Boolean = False
    Public TodayDate As New DateTimePicker
    Public ischequePrint As Boolean = False
    Sub clear()
        IsPDCClear = False
        IsPDC = False
        TodayDate.Value = Today
        ischequePrint = False
    End Sub

End Class
