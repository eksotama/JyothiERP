Public Class StockImportErrorLogFile

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim sdlg As New SaveFileDialog
        sdlg.Filter = "Text Files (*.txt)|*.txt"
        If sdlg.ShowDialog() = vbOK Then
            RichTextBox1.SaveFile(sdlg.FileName)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class