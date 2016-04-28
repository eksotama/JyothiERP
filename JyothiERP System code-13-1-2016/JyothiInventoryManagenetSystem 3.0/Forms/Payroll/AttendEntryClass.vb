Public Class AttendEntryClass
    Public val As New IMSDate
    Public IsOTTime As Boolean = False

    Sub New()
        val.Value = Today
        val.Format = DateTimePickerFormat.Custom
        val.CustomFormat = "HH:ss"
    End Sub
End Class
