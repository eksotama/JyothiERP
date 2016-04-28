Imports System.Drawing.Printing

Public Class MultiSalesInvoices
    Dim TotalPages As Long = 0
    Dim ListTranscode As New ComboBox
    Dim PrintingScheme As String = ""
    Dim pvalues As New PrintParameters
    Private Sub IsDateWise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsDateWise.CheckedChanged
        If IsDateWise.Checked = True Then
            TxtStDate.Enabled = True
            TxtEdDate.Enabled = True
        Else
            TxtStDate.Enabled = False
            TxtEdDate.Enabled = False
        End If
    End Sub

    Private Sub IsInvoiceNoWise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsInvoiceNoWise.CheckedChanged
        If IsInvoiceNoWise.Checked = True Then
            TxtStInvoiceNo.Enabled = True
            TxtEdInvoiceNo.Enabled = True
        Else
            TxtStInvoiceNo.Enabled = False
            TxtEdInvoiceNo.Enabled = False
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try
            PrintPreviewControl1.StartPage = PrintPreviewControl1.StartPage + 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            PrintPreviewControl1.StartPage = PrintPreviewControl1.StartPage - 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click

        PrintDialog1.Document = PrtDoc 'PrintDialog associate with PrintDocument.
        PrintDialog1.AllowSelection = False
        PrintDialog1.AllowPrintToFile = False
        If PrintDialog1.ShowDialog() = DialogResult.OK Then
            PrtDoc.PrinterSettings.PrinterName = PrintDialog1.PrinterSettings.PrinterName
            PrtDoc.Print()
        End If


    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Loadreport()
    End Sub
    Sub Loadreport()
        Dim sqlStr As String = ""
        ' Dim crep As New SalesInvoiceRep
        Me.Cursor = Cursors.WaitCursor

        If TxtStDate.Value > TxtEdDate.Value Then
            Dim TDate As New Date(TxtStDate.Value.Year, TxtStDate.Value.Month, TxtStDate.Value.Day)
            TxtStDate.Value = TxtEdDate.Value
            TxtEdDate.Value = TDate.Date
        End If
        Dim Vhstr As String = ""
        If TxtVoucherType.Text = "All Sales" Then
            Vhstr = " ('SD','POS') "
            pvalues.VouhcerName = PrintVoucherNames.salespos
        ElseIf TxtVoucherType.Text = "Delivery Note" Then
            Vhstr = " ('SD') "
            pvalues.VouhcerName = PrintVoucherNames.salesdelivery
        ElseIf TxtVoucherType.Text = "POS" Then
            Vhstr = " ('POS') "
            pvalues.VouhcerName = PrintVoucherNames.salespos
        ElseIf TxtVoucherType.Text = "Sales Invoice" Then
            Vhstr = " ('SD') "
            pvalues.VouhcerName = PrintVoucherNames.salesdelivery
        ElseIf TxtVoucherType.Text = "Sales Orders" Then
            Vhstr = " ('SO') "
            pvalues.VouhcerName = PrintVoucherNames.salesorder
        ElseIf TxtVoucherType.Text = "Credit Notes" Then
            Vhstr = " ('SR') "
            pvalues.VouhcerName = PrintVoucherNames.salesreturns
        Else
            Vhstr = " ('SD','POS') "
            pvalues.VouhcerName = PrintVoucherNames.salespos
        End If

        Dim Datestr As String = ""
        If TxtLedgerName.Text = "*All" Then
            If IsDateWise.Checked = True Then
                Datestr = "SELECT TRANSCODE FROM StockInvoiceDetails WHERE ( VOUCHERNAME IN " & Vhstr & " ) and  (TransDateValue between " & TxtStDate.Value.Date.ToOADate & " and " & TxtEdDate.Value.Date.ToOADate & ")  "
            Else
                Datestr = "SELECT TRANSCODE FROM StockInvoiceDetails WHERE ( VOUCHERNAME IN " & Vhstr & " )   "
            End If
            If IsInvoiceNoWise.Checked = True Then
                Datestr = Datestr & " and  (qutono between N'" & TxtStInvoiceNo.Text & "' and N'" & TxtEdInvoiceNo.Text & "' ) "
            End If
        Else
            If IsDateWise.Checked = True Then
                Datestr = "SELECT TRANSCODE FROM StockInvoiceDetails WHERE ( VOUCHERNAME IN " & Vhstr & " ) and  (TransDateValue between " & TxtStDate.Value.Date.ToOADate & " and " & TxtEdDate.Value.Date.ToOADate & ") and ledgername=N'" & TxtLedgerName.Text & "'  "
            Else
                Datestr = "SELECT TRANSCODE FROM StockInvoiceDetails WHERE ( VOUCHERNAME IN " & Vhstr & " ) and ledgername=N'" & TxtLedgerName.Text & "'  "
            End If
            If IsInvoiceNoWise.Checked = True Then
                Datestr = Datestr & " and  (qutono between N'" & TxtStInvoiceNo.Text & "' and N'" & TxtEdInvoiceNo.Text & "' ) "
            End If
        End If

        ListTranscode.Items.Clear()

        LoadDataIntoComboBox(Datestr, ListTranscode, "Transcode")
        ListTranscode.Sorted = True
        Try
            Me.PrintGroup.Controls.RemoveAt(0)

        Catch ex As Exception

        End Try

        If ListTranscode.Items.Count <= 0 Then
            MsgBox(" No Records Found..............                           ")

        Else
           
            Me.PrintPreviewControl1 = New System.Windows.Forms.PrintPreviewControl
            Me.PrintPreviewControl1.AutoZoom = True
            If UCase(TxtZoom.Text) = "AUTO" Then
                Me.PrintPreviewControl1.AutoZoom = True
            Else
                Me.PrintPreviewControl1.AutoZoom = False
                If TxtZoom.Text = "25%" Then
                    Me.PrintPreviewControl1.Zoom = 0.25
                ElseIf TxtZoom.Text = "50%" Then
                    Me.PrintPreviewControl1.Zoom = 0.5
                ElseIf TxtZoom.Text = "75%" Then
                    Me.PrintPreviewControl1.Zoom = 0.75
                ElseIf TxtZoom.Text = "100%" Then
                    Me.PrintPreviewControl1.Zoom = 1

                Else
                    Me.PrintPreviewControl1.Zoom = 2

                End If
            End If

            Me.PrintPreviewControl1.Hide()
            Me.PrintPreviewControl1.SuspendLayout()
            Me.PrintPreviewControl1.Dock = DockStyle.Fill
            PrintPreviewControl1.Refresh()
            PrintPreviewControl1.Document = PrtDoc
            Me.PrintPreviewControl1.ResumeLayout()
            Me.PrintGroup.Controls.Add(Me.PrintPreviewControl1)
            Me.PrintPreviewControl1.Show()
            Me.Cursor = Cursors.Default

            Me.Cursor = Cursors.Default

        End If

       

    End Sub

    Private Sub PrtDoc_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrtDoc.BeginPrint
        Dim defscheme As String = SQLGetStringFieldValue("select schemename from printingschemes where vouchername=N'" & pvalues.VouhcerName & "' and isactive =1", "schemename")
        PrintingScheme = defscheme
        LoadPageSetupValues(PrintingScheme)
        PrtDoc.DefaultPageSettings.PaperSize = New PaperSize("Custom", PagesetupValues.Paperwidth, PagesetupValues.Paperheight)
        If PagesetupValues.IslandScape = True Then
            PrtDoc.DefaultPageSettings.Landscape = True
        Else
            PrtDoc.DefaultPageSettings.Landscape = False
        End If
        PrtDoc.DefaultPageSettings.Margins.Left = PagesetupValues.leftmarging
        PrtDoc.DefaultPageSettings.Margins.Right = PagesetupValues.rightmarging
        PrtDoc.DefaultPageSettings.Margins.Top = PagesetupValues.topmarging
        PrtDoc.DefaultPageSettings.Margins.Bottom = PagesetupValues.buttommarging
        PrtDoc.PrinterSettings.PrinterName = PagesetupValues.PrinterName
        PrtDoc.DefaultPageSettings.PrinterSettings.PrinterName = PagesetupValues.PrinterName
        PrtDoc.DefaultPageSettings.PrinterSettings.Copies = 1

    End Sub

    Private Sub PrtDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrtDoc.PrintPage
        PrintingWithMultipleInvoices(sender, e, 0, PrintingScheme, "StockInvoiceRowItems", "StockInvoiceDetails", ListTranscode)
    End Sub

    Private Sub MultiSalesInvoices_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub MultiSalesInvoices_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDataIntoComboBox("Select LedgerName  from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "' or groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.SuppliersAccounts & "'))", TxtLedgerName, "ledgername", "*All")
        TxtZoom.Text = "AUTO"
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub TxtZoom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtZoom.SelectedIndexChanged
        If UCase(TxtZoom.Text) = "AUTO" Then
            Me.PrintPreviewControl1.AutoZoom = True
        Else
            Me.PrintPreviewControl1.AutoZoom = False
            If TxtZoom.Text = "25%" Then
                Me.PrintPreviewControl1.Zoom = 0.25
            ElseIf TxtZoom.Text = "50%" Then
                Me.PrintPreviewControl1.Zoom = 0.5
            ElseIf TxtZoom.Text = "75%" Then
                Me.PrintPreviewControl1.Zoom = 0.75
            ElseIf TxtZoom.Text = "100%" Then
                Me.PrintPreviewControl1.Zoom = 1

            Else
                Me.PrintPreviewControl1.Zoom = 2

            End If
        End If
        PrintPreviewControl1.Refresh()
    End Sub
End Class