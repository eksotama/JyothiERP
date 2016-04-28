Imports System.Windows.Forms

Public Class BarCodePrtDlg

    Private Sub BarCodePrtDlg_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub VoucherPrintDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtPrinterName.Items.Clear()
        For Each s In Printing.PrinterSettings.InstalledPrinters
            TxtPrinterName.Items.Add(s)
        Next
        If TxtPrinterName.Items.Count > 0 Then
            TxtPrinterName.SelectedIndex = 0
        Else
            MsgBox("There are no printers...")
            Me.Close()
        End If
    End Sub
    Dim PrinterValues As New PrintParameters
    Sub New(ByRef Printvalues As PrintParameters)

        ' This call is required by the designer.
        InitializeComponent()
        PrinterValues = Printvalues
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If TxtPrinterName.Text.Length = 0 Then
            MsgBox("Please select the printer name ", MsgBoxStyle.Information)
            TxtPrinterName.Focus()
            Exit Sub
        End If
        PrinterValues.IsPrintToPrinter = True
        PrinterValues.NoofCopies = CInt(TxtNoOfCopies.Text)
        PrinterValues.PrinterName = TxtPrinterName.Text
        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
