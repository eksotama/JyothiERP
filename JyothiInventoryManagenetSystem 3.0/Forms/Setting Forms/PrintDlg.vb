Imports System.Windows.Forms

Public Class PrintDlg
    Dim PrinterValues As New PrintParameters
    Sub New(ByRef Printvalues As PrintParameters)

        ' This call is required by the designer.
        InitializeComponent()
        PrinterValues = Printvalues
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If TxtPrinterName.Text.Length = 0 Then
            MsgBox("Please select the Printer Name ....     ", MsgBoxStyle.Information)
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
        PrinterValues.schemename = TxtSelectedSchemeName.Text
        PrinterValues.PrinterName = TxtPrinterName.Text
        If CInt(TxtNoOfCopies.Text) > 1 Then
            PrinterValues.IsPrintDuplicateInvoice = TxtDuplicateInvoice.Checked
        Else
            PrinterValues.IsPrintDuplicateInvoice = False
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        My.Settings.DefPrinterName = TxtPrinterName.Text
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub PrintDlg_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub PrintDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If My.Computer.Screen.WorkingArea.Width <= 1024 Then
            Me.Font = New Font(Me.Font.Name, 8, FontStyle.Regular)
        End If
        TxtPrinterName.Items.Clear()
        For Each s In Printing.PrinterSettings.InstalledPrinters
            TxtPrinterName.Items.Add(s)
        Next
        If TxtPrinterName.Items.Count > 0 Then
            TxtPrinterName.Text = My.Settings.DefPrinterName
        End If
        Dim defscheme As String = SQLGetStringFieldValue("select schemename from printingschemes where vouchername=N'" & PrinterValues.VouhcerName & "' and isactive =1", "schemename")

        LoadDataIntoComboBox("select schemename from printingschemes where vouchername=N'" & PrinterValues.VouhcerName & "' order by isactive", TxtSelectedSchemeName, "schemename")

        If TxtSelectedSchemeName.Items.Count = 0 Then
            MsgBox("Error: Printing Scheme is not found, Please set Printing Scheme To Print the Invoice ...")
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
            Exit Sub
        Else
            TxtSelectedSchemeName.Text = defscheme
        End If
        TxtNoOfCopies.Text = SQLGetNumericFieldValue("select NoofCopies from printingschemes where schemename='" & TxtSelectedSchemeName.Text & "' and vouchername=N'" & PrinterValues.VouhcerName & "'", "NoofCopies")
    End Sub

    Private Sub TxtNoOfCopies_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNoOfCopies.TextChanged
        If TxtNoOfCopies.Text.Length = 0 Then Exit Sub
        If CDbl(TxtNoOfCopies.Text) > 1 Then
            TxtDuplicateInvoice.Visible = True
            TxtDuplicateInvoice.Checked = False
        Else
            TxtDuplicateInvoice.Visible = False
            TxtDuplicateInvoice.Checked = False
        End If
    End Sub

    Private Sub TxtSelectedSchemeName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtSelectedSchemeName.SelectedIndexChanged
        TxtNoOfCopies.Text = SQLGetNumericFieldValue("select NoofCopies from printingschemes where schemename='" & TxtSelectedSchemeName.Text & "' and vouchername=N'" & PrinterValues.VouhcerName & "'", "NoofCopies")
    End Sub
End Class
