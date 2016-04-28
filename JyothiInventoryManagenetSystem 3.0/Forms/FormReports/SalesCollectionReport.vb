Public Class SalesCollectionReport

    Dim SqlStr As String = ""


    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub

    Sub LoadListofOrders(Optional ByVal AddSqlText As String = "")
        SqlStr = "SELECT ROW_NUMBER() OVER (ORDER BY QutoNo) AS [S.NO],TransCode as [TransCode],TransDate as [Date],QutoNo as [Invoice No],QutoRef as [Ref no],vouchername as [Voucher Name],LedgerName as [Customer Name],nettotal as [Invoice Amount],0 AS [Pending],0 AS [Cheque Paid],0 AS [Card Paid],0 AS [Cash Paid] from stockinvoicedetails where Isdelete=0 and (vouchername in ('SI','POS')) and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "

        If TxtSalesArea.Text.Length = 0 Or TxtSalesArea.Text = "*All" Then
        Else
            SqlStr = SqlStr & " and area=N'" & TxtSalesArea.Text & "' "
        End If

        If TxtSalesPerson.Text.Length = 0 Or TxtSalesPerson.Text = "*All" Then
        Else
            SqlStr = SqlStr & " and salesperson=N'" & TxtSalesPerson.Text & "' "
        End If

        If TxtLedgerName.Text.Length = 0 Or TxtLedgerName.Text = "*All" Then
        Else
            SqlStr = SqlStr & " and ledgername=N'" & TxtLedgerName.Text & "' "
        End If



        Dim TempBS As New BindingSource

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            Me.TxtList.Columns("S.No").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("S.No").Width = 35

            Me.TxtList.Columns("TransCode").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("TransCode").Visible = False


            Me.TxtList.Columns("Date").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Date").Width = 60
            Me.TxtList.Columns("Date").DefaultCellStyle.Format = "d"

            Me.TxtList.Columns("Invoice No").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Invoice No").Width = 50


            Me.TxtList.Columns("Ref no").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Ref no").Width = 50

            'Voucher Name
            Me.TxtList.Columns("Voucher Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Voucher Name").Width = 50

            Me.TxtList.Columns("Customer Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns("Customer Name").Width = 30


            Me.TxtList.Columns("Invoice Amount").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Invoice Amount").Width = 100
            Me.TxtList.Columns("Invoice Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.TxtList.Columns("Invoice Amount").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

            Me.TxtList.Columns("Cash Paid").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Cash Paid").Width = 100
            Me.TxtList.Columns("Cash Paid").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.TxtList.Columns("Cash Paid").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

            Me.TxtList.Columns("Card Paid").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Card Paid").Width = 100
            Me.TxtList.Columns("Card Paid").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.TxtList.Columns("Card Paid").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

            Me.TxtList.Columns("Cheque Paid").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Cheque Paid").Width = 100
            Me.TxtList.Columns("Cheque Paid").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.TxtList.Columns("Cheque Paid").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

            Me.TxtList.Columns("Pending").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Pending").Width = 100
            Me.TxtList.Columns("Pending").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.TxtList.Columns("Pending").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            'Pending

        Catch ex As Exception

        End Try
        For i As Integer = 0 To TxtList.RowCount - 1

            If TxtList.Item("Voucher Name", i).Value = "SI" Then
                Dim CashVal As Double = 0
                Dim ChequeVal As Double = 0
                'Customer Name
                If SQLGetNumericFieldValue("select isbillwise from ledgers where ledgername=N'" & TxtList.Item("Customer Name", i).Value & "'", "isbillwise") = 1 Then
                    CashVal = SQLGetNumericFieldValue("SELECT SUM(DR+CR) AS TOT FROM BILL2BILL WHERE BILLTYPE='Against' AND LEDGERNAME=N'" & TxtList.Item("Customer Name", i).Value & "' AND REFNO=N'" & TxtList.Item("Ref no", i).Value & "'  and PaymentMethod='Cash'", "TOT")
                    TxtList.Item("Cash Paid", i).Value = IIf(CashVal = 0, "", CashVal)
                    TxtList.Item("Voucher Name", i).Value = "SalesInvoice"
                    ChequeVal = SQLGetNumericFieldValue("SELECT SUM(DR+CR) AS TOT FROM BILL2BILL WHERE BILLTYPE='Against' AND LEDGERNAME=N'" & TxtList.Item("Customer Name", i).Value & "' AND REFNO=N'" & TxtList.Item("Ref no", i).Value & "'  and PaymentMethod<>'Cash'", "TOT")
                    TxtList.Item("Cash Paid", i).Value = IIf(ChequeVal = 0, "", ChequeVal)
                    'Pending
                    CashVal = CDbl(TxtList.Item("Invoice Amount", i).Value) - (CashVal + ChequeVal)
                    TxtList.Item("Pending", i).Value = IIf(CashVal = 0, "", CashVal)
                    TxtList.Rows(i).Visible = True
                Else
                    TxtList.Item("Pending", i).Value = TxtList.Item("Invoice Amount", i).Value
                    If IsShowPendingsOnly.Checked = True Then
                        TxtList.Rows(i).Visible = True
                    Else
                        TxtList.Rows(i).Visible = False
                    End If

                End If
                

            Else
                'PaymentMethod
                Dim paymethod As String = ""
                paymethod = SQLGetStringFieldValue("select PaymentMethod from StockInvoiceDetails where transcode=" & TxtList.Item("TransCode", i).Value, "PaymentMethod")
                If paymethod = "Cash" Then
                    TxtList.Item("Cash Paid", i).Value = TxtList.Item("Invoice Amount", i).Value
                    TxtList.Item("Pending", i).Value = ""
                ElseIf paymethod = "Card" Then
                    If SQLGetStringFieldValue("select ispostdated from ledgerbook where  transcode=" & TxtList.Item("TransCode", i).Value, "ispostdated") = True Then
                        If SQLGetStringFieldValue("select clearpdc from ledgerbook where ispostdated='True' and transcode=" & TxtList.Item("TransCode", i).Value, "clearpdc") = True Then
                            TxtList.Item("Card Paid", i).Value = TxtList.Item("Invoice Amount", i).Value
                        Else
                            TxtList.Item("Card Paid", i).Value = ""
                        End If
                    Else
                        TxtList.Item("Card Paid", i).Value = TxtList.Item("Invoice Amount", i).Value

                    End If
                    TxtList.Item("Pending", i).Value = ""
                Else
                    TxtList.Item("Pending", i).Value = ""
                End If

            End If
        Next


    End Sub

    Private Sub SalesCollectionReport_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub SalesOrderList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        LoadDataIntoComboBox("select distinct ledgername from  stockinvoicedetails where (vouchername in ('SI','POS'))", TxtLedgerName, "ledgername", "*All")
        LoadDataIntoComboBox("select distinct salesperson from  stockinvoicedetails where (vouchername in ('SI','POS'))", TxtSalesPerson, "salesperson", "*All")
        LoadDataIntoComboBox("select distinct area from  stockinvoicedetails where (vouchername in ('SI','POS'))", TxtSalesArea, "area", "*All")
        LoadListofOrders()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        LoadListofOrders()
    End Sub

    Private Sub IsShowPendingsOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsShowPendingsOnly.CheckedChanged
        LoadListofOrders()
    End Sub

    Private Sub TxtLedgerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.SelectedIndexChanged

        LoadListofOrders()


    End Sub

    Private Sub TxtSalesPerson_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSalesPerson.SelectedIndexChanged

        LoadListofOrders()

    End Sub

    Private Sub TxtSalesArea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSalesArea.SelectedIndexChanged

        LoadListofOrders()
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub




    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click

    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then
            MsgBox("There is no data ..            ", MsgBoxStyle.Information)
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New SalesCollectionDataSet2
        ds.Clear()
        For i As Integer = 0 To TxtList.RowCount - 1
            Dim row As DataRow
            row = ds.Tables(0).NewRow
            For k As Integer = 0 To TxtList.ColumnCount - 1
                Try
                    row(TxtList.Columns(k).Name) = TxtList.Item(k, i).Value
                Catch ex As Exception
                    row(TxtList.Columns(k).Name) = 0
                End Try
            Next
            ds.Tables(0).Rows.Add(row)
        Next
        Dim objRpt As New SalesCollectionsCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtTitle.Text
            CType(objRpt.Section1.ReportObjects.Item("txtPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "For Period : " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date
        Else
            CType(objRpt.Section1.ReportObjects.Item("txtPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True
            CType(objRpt.Section1.ReportObjects.Item("txtPERIOD"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtTitle.Text & Chr(13) & "For Period : " & TxtStartDate.Value.Date & " - " & TxtEndDate.Value.Date
        End If
        objRpt.SetDataSource(ds)
        Dim FRM As New ReportCommonForm(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cursor = Cursors.Default
        FRM.ShowDialog()
        FRM.Dispose()
        objRpt.Dispose()
        ds.Dispose()
    End Sub
End Class