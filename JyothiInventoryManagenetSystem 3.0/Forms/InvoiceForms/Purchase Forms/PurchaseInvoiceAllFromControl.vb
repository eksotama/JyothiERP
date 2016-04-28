Public Class PurchaseInvoiceAllFromControl
    Dim CurBill = 0
    Dim InvoiceCtrlType As String = ""
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Dim SalesTransactionType As String = ""
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Sub New(ByVal InvoiceName As String, Optional ByVal SalesTransType As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        InvoiceCtrlType = InvoiceName
        SalesTransactionType = SalesTransType
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub TabControl1_ControlRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles TabControl1.ControlRemoved
        If TabControl1.TabCount = 1 Then
            Me.Dispose()
        End If

    End Sub
    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        Dim g As Graphics = e.Graphics
        Dim tp As TabPage = TabControl1.TabPages(e.Index)
        Dim br As Brush
        Dim sf As New StringFormat
        Dim r As New Rectangle(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2)
        sf.Alignment = StringAlignment.Center
        Dim strTtile As String = tp.Text
        If TabControl1.SelectedIndex = e.Index Then
            br = New SolidBrush(Color.Gold)
            g.FillRectangle(br, e.Bounds)
            br = New SolidBrush(Color.White)
            g.DrawString(strTtile, TabControl1.Font, br, r, sf)
            TxtCurrentBill.Text = tp.Text
        Else
            br = New SolidBrush(Color.Yellow)
            g.FillRectangle(br, e.Bounds)
            br = New SolidBrush(Color.Black)

            g.DrawString(strTtile, TabControl1.Font, br, r, sf)
        End If

        br.Dispose()
        sf.Dispose()
        g.Dispose()
    End Sub
    Sub CreateNewControls()
        If TabControl1.TabPages.Count >= MaxInvoicePages Then
            MsgBox("The Maximum pages are excceds, can't create new billl")
            Exit Sub
        End If
        If CurBill > 10 Then
            MsgBox("Max Forms reached, No forms are added... ", MsgBoxStyle.Information)
            Exit Sub
        End If
        CurBill = CurBill + 1
        Dim tabpage As New TabPage
        TabControl1.TabPages.Add(tabpage)

        Dim BillVh As New PurchaseControlAll(InvoiceCtrlType, , SalesTransactionType)

        tabpage.Controls.Add(BillVh)

        Select Case InvoiceCtrlType
            Case "PO"
                Me.Text = "PURCHASE ORDER FORM"
                Me.BtnNewInvoice.Text = "CREATE NEW INVOICE (Allows Multiple Purchase Order Entries)"
                tabpage.Name = "Tabpage" & CurBill.ToString
                tabpage.Text = "Purchase Order:" & CurBill.ToString
            Case "PI", "DP"
                Me.Text = "PURCHASE INVOICE FORM"
                Me.BtnNewInvoice.Text = "CREATE NEW INVOICE (Allows Multiple Purchase Invoices  Entries)"
                tabpage.Name = "Tabpage" & CurBill.ToString
                tabpage.Text = "Purchase Invoice:" & CurBill.ToString
                If InvoiceCtrlType = "DP" Then
                    If SalesTransactionType.Length > 0 Then
                        tabpage.Text = SalesTransactionType & ":" & CurBill.ToString
                   
                    End If
                End If
            Case "PQ"
                Me.Text = "PURCHASE ENQUIRY FORM"
                Me.BtnNewInvoice.Text = "CREATE NEW INVOICE (Allows Multiple Purchase Quotations  Entries)"
                tabpage.Name = "Tabpage" & CurBill.ToString
                tabpage.Text = "Purchase Quote:" & CurBill.ToString
            Case "PR"
                Me.Text = "DEBIT NOTE FORM"
                Me.BtnNewInvoice.Text = "CREATE NEW INVOICE (Allows Multiple Debit Notes  Entries)"
                tabpage.Name = "Tabpage" & CurBill.ToString
                tabpage.Text = "Debit Note:" & CurBill.ToString
            Case "PG"
                Me.Text = "GOODS RECEIPT FORM"
                Me.BtnNewInvoice.Text = "CREATE NEW INVOICE (Allows Multiple  Goods Receipts  Entries)"
                tabpage.Name = "Tabpage" & CurBill.ToString
                tabpage.Text = "Goods Receipt:" & CurBill.ToString
        End Select

        BillVh.Dock = DockStyle.Fill
        If CurBill Mod 2 = 1 Then
            tabpage.BorderStyle = BorderStyle.Fixed3D
        Else
            tabpage.BorderStyle = BorderStyle.FixedSingle
        End If
        BillVh.txtLedgerName.Focus()

    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            CType(TabControl1.TabPages(TabControl1.SelectedIndex).Controls(0), PurchaseControlAll).TxtDate.Focus()
            '  TabControl1.TabPages(TabControl1.SelectedIndex).Controls(0).Controls(0).Controls(0).Controls(0).Controls("txtledgername").Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SalesDeliveryNoteForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(sender)
        Try
            CType(TabControl1.TabPages(TabControl1.SelectedIndex).Controls(0), PurchaseControlAll).TxtDate.Focus()
            '  TabControl1.TabPages(TabControl1.SelectedIndex).Controls(0).Controls(0).Controls(0).Controls(0).Controls("txtledgername").Focus()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub SalesQutoForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CreateNewControls()
    End Sub

    Private Sub BtnNewInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewInvoice.Click, NewFormToolStripMenuItem.Click
        CreateNewControls()
    End Sub
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Try
            TabControl1.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Try
            TabControl1.SelectedIndex = 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Try
            TabControl1.SelectedIndex = 2
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Try
            TabControl1.SelectedIndex = 3
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        Try
            TabControl1.SelectedIndex = 4
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        Try
            TabControl1.SelectedIndex = 5
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        Try
            TabControl1.SelectedIndex = 6
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        Try
            TabControl1.SelectedIndex = 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        Try
            TabControl1.SelectedIndex = 8
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        Try
            TabControl1.SelectedIndex = 9
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HideunhideToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HideunhideToolStripMenuItem.Click
        Try
            CType(TabControl1.TabPages(TabControl1.SelectedIndex).Controls(0), PurchaseControlAll).HideorunHidepannel()
        Catch ex As Exception

        End Try
    End Sub
End Class