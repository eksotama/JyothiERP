Imports System.Data.SqlClient

Public Class SalesRegisterInvoiceWise

    Private Sub UserButton2_Click(sender As System.Object, e As System.EventArgs) Handles UserButton2.Click
        loadreport()
    End Sub
    Sub loadreport()
        Dim sqlstr As String = ""
        'sqlstr = ",qtytext,stockrate,stockamount,TaxAmount as tax,netrate,netstockamount,ledgername from StockInvoiceRowItems inner join StockInvoiceDetails on StockInvoiceDetails.TransCode=StockInvoiceRowItems.TransCode "
        sqlstr = "SELECT transcode,transdate,qutono,stockcode,stocksize,qtytext,stockrate,stockamount,taxamount as tax, netrate,netstockamount,(select ledgername from StockInvoiceDetails where StockInvoiceDetails.TransCode=StockInvoiceRowItems.TransCode) as ledgername from  StockInvoiceRowItems"
        sqlstr = sqlstr & " where  StockInvoiceRowItems.VoucherName in ('SI','POS') and StockInvoiceRowItems.isdelete=0  and  (StockInvoiceRowItems.Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
        If TxtLedgerName.Text.Length = 0 Or TxtLedgerName.Text = "*All" Then
        Else
            sqlstr = sqlstr & " and transcode in (select transcode from stockinvoicedetails where LedgerName=N'" & TxtLedgerName.Text & "') "

        End If

        If sqlstr.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(sqlstr, cnn)
        dscmd.Fill(ds, "DataTable1")
        cnn.Close()
        Dim objRpt As New SalesInvoiceDetailedReport
        CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
        CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
        CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "SALES REGISTER"

        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "SALES REGISTER"
            CType(objRpt.Section1.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " To " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)
        Else
            CType(objRpt.Section1.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True
            CType(objRpt.Section1.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "SALES REGISTER" & Chr(13) & "  Period From " & FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " To " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)

        End If

        objRpt.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = objRpt
        Me.Cursor = Cursors.Default
        
    End Sub

    Private Sub SalesRegisterInvoiceWise_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtStartDate.Value = Today.AddDays(-7)
        TxtEndDate.Value = Today
        LoadDataIntoComboBox("SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "'  or groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "')) ", TxtLedgerName, "ledgername", "*All")
        loadreport()
    End Sub

    Private Sub TxtLedgerName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtLedgerName.SelectedIndexChanged
        loadreport()
    End Sub
End Class