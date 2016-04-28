Imports System.Data.SqlClient

Public Class SalesStatusReportFrm

    Dim SqlStr As String = ""

  
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
   
    Sub LoadListofOrders(Optional ByVal AddSqlText As String = "")

        If IsShowPendingsOnly.Checked = True Then
            SqlStr = "SELECT ROW_NUMBER() OVER (ORDER BY QutoNo) AS [S.NO],TransCode as [TransCode],TransDate as [Date],QutoNo as [Invoice No],QutoRef as [Ref no],LedgerName as [Customer Name],nettotal as [Invoice Amount],vouchername as [Voucher Name],paymentmethod as [Payment Mode],0 AS [Paid Amount],SalesPerson as [Salesman], '' as [Status] from stockinvoicedetails where Isdelete=0 and (vouchername in ('SI','POS'))  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
        Else
            SqlStr = "SELECT ROW_NUMBER() OVER (ORDER BY QutoNo) AS [S.NO],TransCode as [TransCode],TransDate as [Date],QutoNo as [Invoice No],QutoRef as [Ref no],LedgerName as [Customer Name],nettotal as [Invoice Amount],vouchername as [Voucher Name],paymentmethod as [Payment Mode],0 AS [Paid Amount],SalesPerson as [Salesman], '' as [Status] from stockinvoicedetails where Isdelete=0 and (vouchername in ('SI','POS')) and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
        End If
        
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
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(0).Width = 35
            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(1).Width = 120
            Me.TxtList.Columns(1).Visible = False
            Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(2).Width = 120
            Me.TxtList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(3).Width = 120
            Me.TxtList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(4).Width = 120
            Me.TxtList.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(5).Width = 120
            Me.TxtList.Columns("Invoice Amount").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Invoice Amount").Width = 120
            Me.TxtList.Columns("Invoice Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.TxtList.Columns("Invoice Amount").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
        Catch ex As Exception

        End Try
        For i As Integer = 0 To TxtList.RowCount - 1
            If Len(TxtList.Item("Payment Mode", i).Value) = 0 Then
                TxtList.Item("Payment Mode", i).Value = "Credit"
            End If
            If TxtList.Item("Voucher Name", i).Value = "SI" Then
                Dim val As Double = 0
                'Customer Name
                If SQLGetNumericFieldValue("select isbillwise from ledgers where ledgername=N'" & TxtList.Item("Customer Name", i).Value & "'", "isbillwise") = 1 Then
                    val = SQLGetNumericFieldValue("SELECT SUM(DR+CR) AS TOT FROM BILL2BILL WHERE BILLTYPE='Against' AND LEDGERNAME=N'" & TxtList.Item("Customer Name", i).Value & "' AND REFNO=N'" & TxtList.Item("Ref no", i).Value & "'", "TOT")
                    TxtList.Item("Paid Amount", i).Value = val
                    'Status
                    If CDbl(TxtList.Item("Invoice Amount", i).Value) <= val Then
                        TxtList.Item("Status", i).Value = "Paid"
                    Else
                        TxtList.Item("Status", i).Value = "Pending"
                    End If
                    TxtList.Item("Voucher Name", i).Value = "SalesInvoice"
                Else
                    TxtList.Item("Paid Amount", i).Value = 0
                    TxtList.Item("Status", i).Value = "Not Available"
                    TxtList.Item("Voucher Name", i).Value = "SalesInvoice"

                End If
                
            Else
                If TxtList.Item("Payment Mode", i).Value = "Cash" Then
                    TxtList.Item("Status", i).Value = "Paid"
                    TxtList.Item("Paid Amount", i).Value = TxtList.Item("Invoice Amount", i).Value
                ElseIf TxtList.Item("Payment Mode", i).Value = "Card" Then
                    If SQLGetStringFieldValue("select ispostdated from ledgerbook where  transcode=" & TxtList.Item("TransCode", i).Value, "ispostdated") = True Then
                        If SQLGetStringFieldValue("select clearpdc from ledgerbook where ispostdated='True' and transcode=" & TxtList.Item("TransCode", i).Value, "clearpdc") = True Then
                            TxtList.Item("Status", i).Value = "Paid"
                            TxtList.Item("Paid Amount", i).Value = TxtList.Item("Invoice Amount", i).Value
                        Else
                            TxtList.Item("Status", i).Value = "Pending"
                            TxtList.Item("Paid Amount", i).Value = 0
                        End If
                    Else
                        TxtList.Item("Status", i).Value = "Paid"
                        TxtList.Item("Paid Amount", i).Value = TxtList.Item("Invoice Amount", i).Value
                    End If
                   
                Else
                    TxtList.Item("Status", i).Value = "Paid"
                End If

            End If
        Next


    End Sub

    Private Sub SalesStatusReportFrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
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
        If TxtShowDetailed.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            Dim ds As New SalesStatusDataSet
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
            Dim objRpt As New SalesStatusCRReportBySalesMan
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
        Else
            Me.Cursor = Cursors.WaitCursor
            Dim ds As New SalesStatusDataSet
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
            Dim objRpt As New SalesStatusCRReport
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
        End If
    End Sub
End Class