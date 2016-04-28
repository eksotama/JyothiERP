Imports System.Data.SqlClient

Public Class OrderSummeryForm
    Dim SqlStr As String = ""
    Sub LoadDef()
        LoadDataIntoComboBox("select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "')", TxtFilterByLedger, "ledgername")
        LoadDataIntoComboBox("select distinct stockname from StockInvoiceRowItems", TxtFilterByItemName, "stockname")
        LoadDataIntoComboBox("select distinct qutoref from StockInvoiceRowItems", TxtFilterbyRef, "qutoref")
    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadData()
        MainForm.Cursor = Cursors.WaitCursor
        If IsDateWiseOn.Checked = True Then
            SqlStr = SqlStr & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
        End If
        Dim SubString As String = ""
        'SubString = " and ((SELECT SUM(TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS Expr1 FROM StockInvoiceRowItems as tb1 WHERE  (tb1.StockInvoiceRowItems.TransCode = StockInvoiceRowItems.TransCode)) > 0)"
        SubString = " and (TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END) > 0)"
        If IsCustomBarCode = True Then
            SqlStr = Replace(SqlStr, ",barcode", ",CustBarCode")
        End If
        SqlStr = SqlStr & SubString
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            If AppIsItemwithSize = False Then
                TxtList.Columns("More Info").Visible = False
            End If
        Catch ex As Exception

        End Try
        MainForm.Cursor = Cursors.Default
    End Sub

    Private Sub TxtFilterByLedger_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFilterByLedger.SelectedIndexChanged
        If TxtFilterByLedger.Text.Length = 0 Or TxtFilterByLedger.Text = "*All" Then

            SqlStr = "select stockcode as [Item Code],stockname as [Item Name],stocksize as[More Info],barcode as [Barcode],(CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainunit ELSE (CASE CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END) AS [Total Qty],Transdate as [Date], qutoref as [Ref No],(select ledgername from StockInvoiceDetails where transcode=StockInvoiceRowItems.transcode) as [Customer Name] from StockInvoiceRowItems where isdelete<>1 and vouchername='SO'  "
            LoadData()
        Else
            SqlStr = "select stockcode as [Item Code],stockname as [Item Name],stocksize as[More Info],barcode as [Barcode],(CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainunit ELSE (CASE CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END) AS [Total Qty],Transdate as [Date], qutoref as [Ref No],(select ledgername from StockInvoiceDetails where transcode=StockInvoiceRowItems.transcode ) as [Customer Name] from StockInvoiceRowItems where isdelete<>1 and vouchername='SO' and transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtFilterByLedger.Text & "')   "
            LoadData()
        End If
    End Sub

    Private Sub OrderSummeryForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub OrderSummeryForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        LoadDef()
        SqlStr = "select stockcode as [Item Code],stockname as [Item Name],stocksize as[More Info],barcode as [Barcode],(CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainunit ELSE (CASE CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END) AS [Total Qty],Transdate as [Date], qutoref as [Ref No],(select ledgername from StockInvoiceDetails where transcode=StockInvoiceRowItems.transcode) as [Customer Name] from StockInvoiceRowItems where isdelete<>1 and vouchername='SO' "
        LoadData()
    End Sub

    Private Sub TxtFilterByItemName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFilterByItemName.SelectedIndexChanged
        If TxtFilterByItemName.Text.Length = 0 Or TxtFilterByItemName.Text = "*All" Then
            SqlStr = "select stockcode as [Item Code],stockname as [Item Name],stocksize as[More Info],barcode as [Barcode],(CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainunit ELSE (CASE CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END) AS [Total Qty],Transdate as [Date], qutoref as [Ref No],(select ledgername from StockInvoiceDetails where transcode=StockInvoiceRowItems.transcode) as [Customer Name] from StockInvoiceRowItems where isdelete<>1 and vouchername='SO' "
            LoadData()
        Else
            SqlStr = "select stockcode as [Item Code],stockname as [Item Name],stocksize as[More Info],barcode as [Barcode],(CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainunit ELSE (CASE CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END) AS [Total Qty],Transdate as [Date], qutoref as [Ref No],(select ledgername from StockInvoiceDetails where transcode=StockInvoiceRowItems.transcode and ledgername=N'" & TxtFilterByLedger.Text & "') as [Customer Name] from StockInvoiceRowItems where isdelete<>1 and vouchername='SO' and stockname=N'" & TxtFilterByItemName.Text & "' "
            LoadData()
        End If
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        SqlStr = "select stockcode as [Item Code],stockname as [Item Name],stocksize as[More Info],barcode as [Barcode],(CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainunit ELSE (CASE CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END) AS [Total Qty],Transdate as [Date], qutoref as [Ref No],(select ledgername from StockInvoiceDetails where transcode=StockInvoiceRowItems.transcode) as [Customer Name] from StockInvoiceRowItems where isdelete<>1 and vouchername='SO' "
        LoadData()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub TxtFilterbyRef_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFilterbyRef.SelectedIndexChanged
        If TxtFilterbyRef.Text.Length = 0 Or TxtFilterbyRef.Text = "*All" Then
            SqlStr = "select stockcode as [Item Code],stockname as [Item Name],stocksize as[More Info],barcode as [Barcode],(CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainunit ELSE (CASE CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END) AS [Total Qty],Transdate as [Date], qutoref as [Ref No],(select ledgername from StockInvoiceDetails where transcode=StockInvoiceRowItems.transcode) as [Customer Name] from StockInvoiceRowItems where isdelete<>1 and vouchername='SO' "
            LoadData()
        Else
            SqlStr = "select stockcode as [Item Code],stockname as [Item Name],stocksize as[More Info],barcode as [Barcode],(CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainunit ELSE (CASE CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END) AS [Total Qty],Transdate as [Date], qutoref as [Ref No],(select ledgername from StockInvoiceDetails where transcode=StockInvoiceRowItems.transcode and ledgername=N'" & TxtFilterByLedger.Text & "') as [Customer Name] from StockInvoiceRowItems where isdelete<>1 and vouchername='SO' and qutoref=N'" & TxtFilterbyRef.Text & "' "
            LoadData()
        End If
    End Sub

    Private Sub TxtSearchByLedger_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearchByLedger.TextChanged
        If TxtSearchByLedger.Text.Length = 0 Then
            SqlStr = "select stockcode as [Item Code],stockname as [Item Name],stocksize as[More Info],barcode as [Barcode],(CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainunit ELSE (CASE CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END) AS [Total Qty],Transdate as [Date], qutoref as [Ref No],(select ledgername from StockInvoiceDetails where transcode=StockInvoiceRowItems.transcode) as [Customer Name] from StockInvoiceRowItems where isdelete<>1 and vouchername='SO' "
            LoadData()
        Else
            SqlStr = "select stockcode as [Item Code],stockname as [Item Name],stocksize as[More Info],barcode as [Barcode],(CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainunit ELSE (CASE CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END) AS [Total Qty],Transdate as [Date], qutoref as [Ref No],(select ledgername from StockInvoiceDetails where transcode=StockInvoiceRowItems.transcode) as [Customer Name] from StockInvoiceRowItems where isdelete<>1 and vouchername='SO' and transcode in (select transcode from StockInvoiceDetails where ledgername LIKE N'%" & TxtSearchByLedger.Text & "%')  "
            LoadData()
        End If
    End Sub

    Private Sub TxtSearchbyPerson_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearchbyPerson.TextChanged
        If TxtSearchbyPerson.Text.Length = 0 Then
            SqlStr = "select stockcode as [Item Code],stockname as [Item Name],stocksize as[More Info],barcode as [Barcode],(CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainunit ELSE (CASE CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END) AS [Total Qty],Transdate as [Date], qutoref as [Ref No],(select ledgername from StockInvoiceDetails where transcode=StockInvoiceRowItems.transcode) as [Customer Name] from StockInvoiceRowItems where isdelete<>1 and vouchername='SO' "
            LoadData()
        Else
            SqlStr = "select stockcode as [Item Code],stockname as [Item Name],stocksize as[More Info],barcode as [Barcode],(CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainunit ELSE (CASE CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END) AS [Total Qty],Transdate as [Date], qutoref as [Ref No],(select ledgername from StockInvoiceDetails where transcode=StockInvoiceRowItems.transcode) as [Customer Name] from StockInvoiceRowItems where isdelete<>1 and vouchername='SO' and transcode in (select transcode from StockInvoiceDetails where salesperson LIKE N'%" & TxtSearchbyPerson.Text & "%') "
            LoadData()
        End If
    End Sub

    Private Sub TxtSearchByItemName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearchByItemName.TextChanged
        If TxtSearchByItemName.Text.Length = 0 Then
            SqlStr = "select stockcode as [Item Code],stockname as [Item Name],stocksize as[More Info],barcode as [Barcode],(CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainunit ELSE (CASE CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END) AS [Total Qty],Transdate as [Date], qutoref as [Ref No],(select ledgername from StockInvoiceDetails where transcode=StockInvoiceRowItems.transcode) as [Customer Name] from StockInvoiceRowItems where isdelete<>1 and vouchername='SO'"
            LoadData()
        Else
            SqlStr = "select stockcode as [Item Code],stockname as [Item Name],stocksize as[More Info],barcode as [Barcode],(CASE (SELECT unittype FROM stockunits WHERE stockunits.unitname = StockInvoiceRowItems.baseunit) WHEN 0 THEN CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainunit ELSE (CASE CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT) WHEN 0 THEN (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit) ELSE (CONVERT(varchar(30), floor((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) / unitcon)) + ' ' + mainUnit + ' ' + CONVERT(varchar(30), CAST((TotalQty - (CASE WHEN UsedQty > 0 THEN usedqty ELSE 0 END)) AS INT) % CAST(UnitCon AS INT)) + ' ' + subUnit) END) END) AS [Total Qty],Transdate as [Date], qutoref as [Ref No],(select ledgername from StockInvoiceDetails where transcode=StockInvoiceRowItems.transcode) as [Customer Name] from StockInvoiceRowItems where isdelete<>1 and vouchername='SO' and stockname LIKE N'%" & TxtSearchByItemName.Text & "%' "
            LoadData()
        End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If SqlStr.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(SqlStr, cnn)
        dscmd.Fill(ds, "StockInvoiceRowItems")
        cnn.Close()
        Dim objRpt As New OrderSummeryCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
            If IsDateWiseOn.Checked = True Then
                CType(objRpt.Section1.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " To " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)
            End If

        Else

            If IsDateWiseOn.Checked = True Then
                CType(objRpt.Section1.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text & "  Period From " & FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " To " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)
            Else
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
            End If

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