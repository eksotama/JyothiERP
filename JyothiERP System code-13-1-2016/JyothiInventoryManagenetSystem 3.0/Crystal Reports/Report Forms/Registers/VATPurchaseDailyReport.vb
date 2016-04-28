Imports System.Drawing.Printing

Public Class VATPurchaseDailyReport
    Dim SqlStr As String = ""
    Dim SqlStrTotal As String = ""
    Dim SqlGroupStr As String = ""
    Dim GraphSqlStr As String = ""
    Dim sumcolno As Integer = 2
    Dim IsLoading As Boolean = True
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Private Sub Txtgrid_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)

    End Sub
    Sub LoadReport()
        If IsLoading = True Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim VatValues As New ComboBox
        Dim TempBS As New BindingSource
        If TxtSalesPerson.Text.Length = 0 Then
            TxtSalesPerson.Text = "*All"
        End If
        If TxtLedgerName.Text.Length = 0 Then
            TxtLedgerName.Text = "*All"
        End If
        If TxtStockGroup.Text.Length = 0 Then
            TxtStockGroup.Text = "*All"
        End If
        Dim VATSqlStr As String = ""
        Dim VatsalesSqlStr As String = ""

        Dim SQLstr As String = ""
        Me.Cursor = Cursors.WaitCursor

        SQLstr = "select * from Vatclauses where VATTYPE='VAT' or vattype='CST'"
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = SQLstr
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()
                If Sreader("VATTAX") = 0 Then
                    VatsalesSqlStr = VatsalesSqlStr & ",(SELECT SUM(DR+CR) AS TOT FROM LEDGERBOOK WHERE LEDGERNAME=N'" & Sreader("PurchaseLedger") & "' AND transcode=StockInvoiceDetails.transcode) as [" & Sreader("PurchaseLedger") & "]"
                Else
                    VatsalesSqlStr = VatsalesSqlStr & ",(SELECT SUM(DR+CR) AS TOT FROM LEDGERBOOK WHERE LEDGERNAME=N'" & Sreader("PurchaseLedger") & "' AND transcode=StockInvoiceDetails.transcode) as [" & Sreader("PurchaseLedger") & "]"
                    VATSqlStr = VATSqlStr & ",(SELECT SUM(DR+CR) AS TOT FROM LEDGERBOOK WHERE LEDGERNAME=N'" & Sreader("inputvatledger") & "' AND transcode=StockInvoiceDetails.transcode) as [" & Sreader("inputvatledger") & "]"
                    VatValues.Items.Add("[" & Sreader("inputvatledger") & "]")
                End If
               
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            Sqlcmmd.Connection = Nothing

        End Try
        Dim Vhstr As String = ""
        If TxtVoucherType.Text = "*All" Then
            Vhstr = ""
        Else
            Vhstr = " and transtype=N'" & TxtVoucherType.Text & "' "
        End If

        SqlStrTotal = "SELECT SUM(nettotal) AS Tot from StockInvoiceDetails where (VoucherName='PI' or voucherName='DP')  and isdelete=0 " & Vhstr
        SQLstr = "select  QutoNo as [Invoice No],TransDate as [Date], LedgerName as [Particulars],transtype as [Voucher Type],(select taxregno from ledgers where ledgers.ledgername=StockInvoiceDetails.ledgername) as [Sales Tax No/TIN Number] , grosstotal as [Gross]" & VatsalesSqlStr & VATSqlStr & " ,TransCode as [Trans Code] from StockInvoiceDetails where (VoucherName='PI' or voucherName='DP') and isdelete=0  " & Vhstr
        sumcolno = 4
        GraphSqlStr = "(VoucherName='PI' or voucherName='DP') and isdelete=0  " & Vhstr
        If TxtIsPeriod.Checked = True Then
            If TxtSalesPerson.Text = "*All" And TxtLedgerName.Text = "*All" Then
                SQLstr = SQLstr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
                SqlStrTotal = SqlStrTotal & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
                GraphSqlStr = GraphSqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
            ElseIf TxtSalesPerson.Text = "*All" Then
                SQLstr = SQLstr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "')"
                SqlStrTotal = SqlStrTotal & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "')"
                GraphSqlStr = GraphSqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "')"
            ElseIf TxtLedgerName.Text = "*All" Then
                SQLstr = SQLstr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
                SqlStrTotal = SqlStrTotal & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
                GraphSqlStr = GraphSqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
            Else
                SQLstr = SQLstr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "' and ledgername=N'" & TxtLedgerName.Text & "')"
                SqlStrTotal = SqlStrTotal & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "' and ledgername=N'" & TxtLedgerName.Text & "')"
                GraphSqlStr = GraphSqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "' and ledgername=N'" & TxtLedgerName.Text & "')"
            End If

        Else
            If TxtSalesPerson.Text = "*All" And TxtLedgerName.Text = "*All" Then

            ElseIf TxtSalesPerson.Text = "*All" Then
                SQLstr = SQLstr & "  and Transcode in (select transcode from StockInvoiceDetails where  ledgername=N'" & TxtLedgerName.Text & "')"
                SqlStrTotal = SqlStrTotal & "  and Transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "')"
                GraphSqlStr = GraphSqlStr & "  and Transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "')"
            ElseIf TxtLedgerName.Text = "*All" Then
                SQLstr = SQLstr & "  and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
                SqlStrTotal = SqlStrTotal & "  and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
                GraphSqlStr = GraphSqlStr & "  and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "')"
            Else
                SQLstr = SQLstr & "  and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "' and ledgername=N'" & TxtLedgerName.Text & "')"
                SqlStrTotal = SqlStrTotal & "  and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "' and ledgername=N'" & TxtLedgerName.Text & "')"
                GraphSqlStr = GraphSqlStr & "  and Transcode in (select transcode from StockInvoiceDetails where salesperson=N'" & TxtSalesPerson.Text & "' and ledgername=N'" & TxtLedgerName.Text & "')"
            End If
        End If

        If TxtSalesAc.Text.Length = 0 Or TxtSalesAc.Text = "*All" Then
        Else
            SQLstr = SQLstr & " and AccountLedgerName=N'" & TxtSalesAc.Text & "'"
            SqlStrTotal = SqlStrTotal & " and AccountLedgerName=N'" & TxtSalesAc.Text & "'"
            GraphSqlStr = GraphSqlStr & " and AccountLedgerName=N'" & TxtSalesAc.Text & "'"
        End If
        Dim Subquery As String = ""
        For i As Integer = 0 To VatValues.Items.Count - 1
            If i = 0 Then
                Subquery = Subquery & " SUM (" & VatValues.Items(i).ToString & ") AS " & VatValues.Items(i).ToString
            Else
                Subquery = Subquery & ", SUM (" & VatValues.Items(i).ToString & ") AS " & VatValues.Items(i).ToString
            End If

        Next
        If Subquery.Length > 3 Then
            SQLstr = "SELECT CONVERT(date,[date]) AS [DATE],(select top 1 qutono from stockinvoicedetails where convert(date,transdate)=CONVERT(date,[date]) and (VoucherName='SI' or voucherName='POS') order by transcode,transdate) +' To ' +(select top 1 qutono from stockinvoicedetails where convert(date,transdate)=CONVERT(date,[date]) and (VoucherName='PI' or voucherName='DP') order by transcode desc,transdate desc) as [Invoice Range],count(*) as [Total Invoices],Sum(Gross) as InvoiceTotal, " & Subquery & " FROM (" & SQLstr & ") SS GROUP BY CONVERT(date,[date]) ORDER BY [DATE]"
        Else
            SQLstr = "SELECT CONVERT(date,[date]) AS [DATE],(select top 1 qutono from stockinvoicedetails where convert(date,transdate)=CONVERT(date,[date]) and (VoucherName='SI' or voucherName='POS') order by transcode,transdate) +' To ' +(select top 1 qutono from stockinvoicedetails where convert(date,transdate)=CONVERT(date,[date]) and (VoucherName='PI' or voucherName='DP') order by transcode desc,transdate desc) as [Invoice Range],count(*) as [Total Invoices],Sum(Gross) as InvoiceTotal  FROM (" & SQLstr & ") SS GROUP BY CONVERT(date,[date]) ORDER BY [DATE]"
        End If

        With Me.TxtList
            Dim kd As New DataTable
            kd = SQLLoadGridData(SQLstr)
            kd.Rows.Add()
            TempBS.DataSource = kd
            .AutoGenerateColumns = True

            .DataSource = TempBS
        End With


        Try

            For c As Integer = 3 To TxtList.Columns.Count - 1
                Try
                    TxtList.Columns(c).Width = 100
                    TxtList.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                    TxtList.Columns(c).DefaultCellStyle.Format = "N2"
                Catch ex36 As Exception

                End Try
            Next

        Catch ex As Exception

        End Try




        FindPayHeadTotals()
        For i = 0 To TxtList.Columns.Count - 1
            TxtList.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
        Next i
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub UserButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton2.Click
        LoadReport()
    End Sub

    Private Sub TxtLedgerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.SelectedIndexChanged
        LoadReport()
    End Sub

    Private Sub TxtSalesPerson_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSalesPerson.SelectedIndexChanged
        LoadReport()
    End Sub

    Private Sub IsLedgerCurrency_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadReport()
    End Sub

    Private Sub VATAllSalesVouchers_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub SalesRegister_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IsLoading = True
        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        LoadDataIntoComboBox("select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "')", TxtLedgerName, "ledgername", "*All")
        LoadDataIntoComboBox("select salespersonname from salespersons", TxtSalesPerson, "salespersonname", "*All")
        LoadDataIntoComboBox("select distinct transtype from StockInvoiceDetails", TxtVoucherType, "transtype", "*All")
        LoadDataIntoComboBox("select stockgroupname from stockgroups", TxtStockGroup, "stockgroupname", "*All")
        LoadDataIntoComboBox("select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')", TxtSalesAc, "ledgername", "*All")
        TxtList.Visible = True
        TxtList.Dock = DockStyle.Fill
        IsLoading = False

        LoadReport()
    End Sub


    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If APPUserRights.IsEditable = False Then
            MsgBox("The Edit Restricted by the Admin, Not possible to Edit......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Selec the Row to Edit.....", MsgBoxStyle.Information)
            Exit Sub
        End If
        If MsgBox("Do you want to Edit ?         ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            'Trans Code
            Dim frm As New InvoiceAlterForm
            frm.TxtTitle.Text = "ALTER SALES"
            Dim K As New SalesControlAll(SQLGetStringFieldValue("SELECT VOUCHERNAME FROM StockInvoiceDetails WHERE TRANSCODE=" & TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value, "VOUCHERNAME"), TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value)
            K.BtnNew.Enabled = False
            K.BtnOpen.Enabled = False
            frm.TxtList.Controls.Add(K)
            frm.TxtList.Controls(0).Dock = DockStyle.Fill
            frm.WindowState = FormWindowState.Maximized
            frm.ShowDialog()
            frm.Dispose()
            K.Dispose()

            LoadReport()
        End If

    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, PrintToolStripMenuItem.Click
        Dim ppd As New PrintPreviewDialog()
        ppd.Document = PrintDocument1
        ppd.ShowDialog()

    End Sub



    Private Sub ImSlabel4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImSlabel4.Click, ImSlabel5.Click, ImSlabel3.Click

    End Sub



    Private Sub TxtSalesAc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSalesAc.SelectedIndexChanged, TxtVoucherType.SelectedIndexChanged
        LoadReport()
    End Sub


    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint


        POSPrinintingValues.MainHead = CompDetails.CompanyName
        POSPrinintingValues.SubHeading = CompDetails.Companyaddresspoboxno
        POSPrinintingValues.Title = Me.tXThEAD.Text
        POSPrinintingValues.Pagewidth = 850
        PrintDocument1.DefaultPageSettings.PaperSize = New PaperSize("Custom", POSPrinintingValues.Pagewidth, 1400)
        PrintDocument1.DefaultPageSettings.Landscape = True
        PrintDocument1.DefaultPageSettings.Margins.Left = 1
        PrintDocument1.DefaultPageSettings.Margins.Right = 1
        PrintDocument1.DefaultPageSettings.Margins.Top = 1
        PrintDocument1.DefaultPageSettings.Margins.Bottom = 1
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        PRINTDATA(sender, e, POSPrinintingValues, TxtList)
    End Sub
    Public POSPrinintingValues As New HeadingStructure
    Structure HeadingStructure
        Dim MainHead As String
        Dim SubHeading As String
        Dim Title As String
        Dim InvoiceNo As String
        Dim DateLine As String
        Dim BillTo As String
        Dim BiltoAdress As String
        Dim SubTotal As String
        Dim TaxTotal As String
        Dim NetTotal As String
        Dim Pagewidth As Integer

    End Structure

    Public Sub PRINTDATA(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal PtValues As HeadingStructure, ByVal dbtable As DataGridView)
        Dim top As Integer = 0
        Dim left As Integer = 0
        Static ROWNO As Integer = 0
        Dim PAGEHEIGHT As Integer = 850
        Static pageno As Integer = 1
        Dim PAGEFOOTER As Integer = 100
        Dim LEFTMRNGIN As Integer = 30
        Dim drawFormat As New StringFormat
        Dim drawFont As Font = New Font("arial", 10)
        Dim drawBrush As New SolidBrush(Color.Black)
        drawFormat.Alignment = StringAlignment.Center
        Dim penstyle As New Pen(Brushes.Black, 1)
        Dim Rect1 As New Rectangle
        Rect1.X = LEFTMRNGIN
        Rect1.Y = 10
        Rect1.Width = 1400 - 45
        Rect1.Height = 15
        e.Graphics.DrawString(PtValues.MainHead, drawFont, drawBrush, Rect1, drawFormat)
        Rect1.Y = Rect1.Y + 15
        e.Graphics.DrawString(PtValues.SubHeading, drawFont, drawBrush, Rect1, drawFormat)
        Rect1.Y = Rect1.Y + 15
        e.Graphics.DrawString(PtValues.Title, drawFont, drawBrush, Rect1, drawFormat)
        Rect1.Y = Rect1.Y + 20
        ' Rect1.Y = Rect1.Y - (dbtable.RowTemplate.Height / 2)
        ' TOP  LINE




        e.Graphics.DrawLine(penstyle, Rect1.X, Rect1.Y, TxtList.Width - 10, Rect1.Y)


        drawFont = New Font("Arial", 8)
        For i As Integer = 0 To dbtable.ColumnCount - 1
            e.Graphics.DrawLine(penstyle, Rect1.X, Rect1.Y, Rect1.X, Rect1.Y + dbtable.ColumnHeadersHeight)
            If dbtable.Columns(i).Visible = True Then

                If dbtable.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft Then
                    drawFormat.Alignment = StringAlignment.Near
                    Dim Rect2 As New Rectangle(Rect1.X + 2, Rect1.Y, dbtable.Columns(i).Width, dbtable.ColumnHeadersHeight)
                    e.Graphics.DrawString(dbtable.Columns(i).HeaderText, drawFont, drawBrush, Rect2, drawFormat)
                    Rect1.X = Rect1.X + dbtable.Columns(i).Width
                ElseIf dbtable.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight Then
                    drawFormat.Alignment = StringAlignment.Far
                    Dim Rect2 As New Rectangle(Rect1.X - 2, Rect1.Y, dbtable.Columns(i).Width, dbtable.ColumnHeadersHeight)
                    e.Graphics.DrawString(dbtable.Columns(i).HeaderText, drawFont, drawBrush, Rect2, drawFormat)
                    Rect1.X = Rect1.X + dbtable.Columns(i).Width
                ElseIf dbtable.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter Then
                    drawFormat.Alignment = StringAlignment.Center
                    Dim Rect2 As New Rectangle(Rect1.X, Rect1.Y, dbtable.Columns(i).Width, dbtable.ColumnHeadersHeight)
                    e.Graphics.DrawString(dbtable.Columns(i).HeaderText, drawFont, drawBrush, Rect2, drawFormat)
                    Rect1.X = Rect1.X + dbtable.Columns(i).Width
                Else
                    drawFormat.Alignment = StringAlignment.Near
                    Dim Rect2 As New Rectangle(Rect1.X + 2, Rect1.Y, dbtable.Columns(i).Width, dbtable.ColumnHeadersHeight)
                    e.Graphics.DrawString(dbtable.Columns(i).HeaderText, drawFont, drawBrush, Rect2, drawFormat)
                    Rect1.X = Rect1.X + dbtable.Columns(i).Width
                End If

                e.Graphics.DrawLine(penstyle, Rect1.X, Rect1.Y, Rect1.X, Rect1.Y + dbtable.ColumnHeadersHeight)
            End If
        Next
        ' Rect1.Y = Rect1.Y + 15

        ' e.Graphics.DrawLine(Pens.Black, Rect1.X, Rect1.Y + dbtable.ColumnHeadersHeight, Rect1.Width, Rect1.Y + dbtable.ColumnHeadersHeight)

        Rect1.X = LEFTMRNGIN
        Rect1.Y = Rect1.Y + dbtable.ColumnHeadersHeight


        For j = ROWNO To dbtable.RowCount - 1
            ROWNO = j + 1
            '  Rect1.Y = Rect1.Y + dbtable.RowTemplate.Height
            Rect1.X = LEFTMRNGIN
            e.Graphics.DrawLine(penstyle, Rect1.X, Rect1.Y - 5, TxtList.Width - 10, Rect1.Y - 5)
            e.Graphics.DrawLine(penstyle, Rect1.X, Rect1.Y, Rect1.X, Rect1.Y + dbtable.RowTemplate.Height)
            For i As Integer = 0 To dbtable.ColumnCount - 1
                If i = dbtable.ColumnCount - 1 Then
                    drawFont = New Font("Arial", 9, FontStyle.Bold)
                Else
                    drawFont = New Font("Arial", 8)
                End If
                If dbtable.Columns(i).Visible = True Then
                    If dbtable.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft Then
                        drawFormat.Alignment = StringAlignment.Near
                        Dim Rect2 As New Rectangle(Rect1.X, Rect1.Y, dbtable.Columns(i).Width, 15)
                        e.Graphics.DrawString(dbtable.Item(i, j).FormattedValue.ToString, drawFont, drawBrush, Rect2, drawFormat)
                        Rect1.X = Rect1.X + dbtable.Columns(i).Width
                    ElseIf dbtable.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight Then
                        drawFormat.Alignment = StringAlignment.Far
                        Dim Rect2 As New Rectangle(Rect1.X, Rect1.Y, dbtable.Columns(i).Width, 15)
                        e.Graphics.DrawString(dbtable.Item(i, j).FormattedValue.ToString, drawFont, drawBrush, Rect2, drawFormat)
                        Rect1.X = Rect1.X + dbtable.Columns(i).Width
                    ElseIf dbtable.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter Then
                        drawFormat.Alignment = StringAlignment.Center
                        Dim Rect2 As New Rectangle(Rect1.X, Rect1.Y, dbtable.Columns(i).Width, 15)
                        e.Graphics.DrawString(dbtable.Item(i, j).FormattedValue.ToString, drawFont, drawBrush, Rect2, drawFormat)
                        Rect1.X = Rect1.X + dbtable.Columns(i).Width
                    Else

                        drawFormat.Alignment = StringAlignment.Near
                        Dim Rect2 As New Rectangle(Rect1.X, Rect1.Y, dbtable.Columns(i).Width, 15)
                        e.Graphics.DrawString(dbtable.Item(i, j).FormattedValue.ToString, drawFont, drawBrush, Rect2, drawFormat)
                        Rect1.X = Rect1.X + dbtable.Columns(i).Width
                    End If


                End If
                e.Graphics.DrawLine(penstyle, Rect1.X, Rect1.Y, Rect1.X, Rect1.Y + dbtable.RowTemplate.Height)
            Next

            Rect1.Y = Rect1.Y + dbtable.RowTemplate.Height
            If Rect1.Y > PAGEHEIGHT - PAGEFOOTER Then
                Exit For
            End If
        Next
        ' e.Graphics.DrawLine(penstyle, Rect1.X, Rect1.Y, Rect1.X, Rect1.Y + dbtable.RowTemplate.Height)
        e.Graphics.DrawLine(penstyle, LEFTMRNGIN, Rect1.Y, TxtList.Width - 10, Rect1.Y)
        Rect1.Y = Rect1.Y + 15


        If Rect1.Y > PAGEHEIGHT - PAGEFOOTER And dbtable.RowCount > ROWNO Then
            Dim Rect2 As New Rectangle(700, Rect1.Y, 100, 15)
            e.Graphics.DrawString("Page " & pageno, drawFont, drawBrush, Rect2, drawFormat)
            pageno = pageno + 1
            e.HasMorePages = True
        Else
            ROWNO = 0
            pageno = 1
        End If

    End Sub
    Private Sub TxtList_SortCompare(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles TxtList.SortCompare
        If e.RowIndex1 = TxtList.RowCount - 1 Then
            e.SortResult = False
            e.Handled = True
        End If

        If e.RowIndex2 = TxtList.RowCount - 1 Then
            e.Handled = True
            e.SortResult = False
        End If


    End Sub
    Sub FindPayHeadTotals()
        On Error Resume Next
        Dim rno As Integer = 0
        rno = TxtList.RowCount - 1
        TxtList.Item(1, rno).Value = "TOTALS"
        TxtList.Rows(rno).Height = 30
        TxtList.Rows(rno).DefaultCellStyle.BackColor = Color.Yellow
        TxtList.Rows(rno).DefaultCellStyle.ForeColor = Color.Red
        TxtList.Rows(rno).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
        Dim totamt As Double = 0

        For c As Integer = 2 To TxtList.Columns.Count - 1
            totamt = 0
            For r As Integer = 0 To TxtList.RowCount - 2
                totamt = totamt + CDbl(TxtList.Item(c, r).Value)
            Next
            TxtList.Item(c, rno).Value = totamt
        Next
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim title As String = ""
        If TxtIsPeriod.Checked = True Then
            title = tXThEAD.Text & " For Period " & TxtStartDate.Value.Date & " To " & TxtEndDate.Value.Date
        Else
            title = tXThEAD.Text
        End If
        ExportDataGridToExcel(TxtList, title)
    End Sub
End Class