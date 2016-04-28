Imports System.Windows.Forms

Public Class ExportPrintSettings

    Private Sub ExportPrintSettings_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub ExportPrintSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtPrinterName.Items.Clear()
        For Each s In Printing.PrinterSettings.InstalledPrinters
            TxtPrinterName.Items.Add(s)
        Next
        TxtPrinterName.Text = My.Settings.printernametoexport
        TxtFileType.Text = My.Settings.filetypetoexport
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Settings.printernametoexport = TxtPrinterName.Text
        My.Settings.filetypetoexport = TxtFileType.Text
        My.Settings.Save()
    End Sub
End Class
