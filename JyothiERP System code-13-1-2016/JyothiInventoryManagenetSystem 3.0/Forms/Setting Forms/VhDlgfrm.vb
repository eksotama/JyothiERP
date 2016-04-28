Imports System.Windows.Forms

Public Class VhDlgfrm
    Dim PrinterValues As New PrintParameters
    Sub New(ByRef Printvalues As PrintParameters)

        ' This call is required by the designer.
        InitializeComponent()
        PrinterValues = Printvalues
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If TxtPrinterName.Text.Length = 0 Then
            MsgBox("Please Select the Printer Name .... ")
            TxtPrinterName.Focus()
            Exit Sub
        End If
        If TxtNoOfCopies.Text.Length = 0 Then
            TxtNoOfCopies.Text = "1"
        End If
        If IsPrintPreview.Checked = True Then
            PrinterValues.IsPrintToPrinter = False
        Else
            PrinterValues.IsPrintToPrinter = True
        End If
        PrinterValues.NoofCopies = CInt(TxtNoOfCopies.Text)
        PrinterValues.schemename = TxtPrinterName.Text
        PrinterValues.PrinterName = TxtPrinterName.Text
        If CInt(TxtNoOfCopies.Text) > 1 Then
            PrinterValues.IsPrintDuplicateInvoice = TxtDuplicateInvoice.Checked
        Else
            PrinterValues.IsPrintDuplicateInvoice = False
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub VhDlgfrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub PrintDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtPrinterName.Items.Clear()
        For Each s In Printing.PrinterSettings.InstalledPrinters
            TxtPrinterName.Items.Add(s)
        Next
        If TxtPrinterName.Items.Count > 0 Then
            Dim oPS As New System.Drawing.Printing.PrinterSettings
            Try
                TxtPrinterName.Text = oPS.PrinterName
            Catch ex As Exception
                TxtPrinterName.SelectedIndex = 0
            End Try

        Else
            MsgBox("There are no printers...")
            Me.Close()
        End If
    End Sub

    Private Sub TxtNoOfCopies_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNoOfCopies.TextChanged
        If TxtNoOfCopies.Text.Length = 0 Then Exit Sub
        If CDbl(TxtNoOfCopies.Text) > 1 Then
            TxtDuplicateInvoice.Visible = True
        Else
            TxtDuplicateInvoice.Visible = False
        End If
    End Sub
End Class
