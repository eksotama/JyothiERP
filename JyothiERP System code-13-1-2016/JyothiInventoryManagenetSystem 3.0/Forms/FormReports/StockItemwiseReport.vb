Imports System.Data.SqlClient

Public Class StockItemwiseReport
    Dim sQLSTR As String = ""
    Dim IsonLoading As Boolean = True
    Dim OpenedStockCode As String = ""
    Sub New(Optional ByVal StockCode As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If StockCode.Length > 0 Then
            OpenedStockCode = StockCode
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub

    Private Sub StockItemwiseReport_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub StockItemwiseReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        IsonLoading = True
        TxtStartDate.Value = Today.Date.AddMonths(-3)
        TxtEndDate.Value = Today.Date
        ' LoadDataIntoComboBoxByBinding("select distinct stockcode from stockdbf", TxtStockCode, "stockcode")
        ' LoadDataIntoComboBoxByBinding("select distinct stockname from stockdbf", TxtByStockName, "stockname", "*All")
        LoadDataIntoComboBox("select locationname  from StockLocations", TxtStockLocation, "locationname", "*All")
        LoadDataIntoComboBox("select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "')", TxtLedgerName, "ledgername", "*All")
        TxtShowSuppliers.Checked = False
        IsonLoading = False
        If OpenedStockCode.Length > 0 Then
            TxtStockCode.Text = OpenedStockCode
            LoadData(" and stockcode=N'" & TxtStockCode.Text & "'")
        Else
            If TxtStockCode.Items.Count > 0 Then
                TxtStockCode.SelectedIndex = 0
            End If
        End If
    End Sub
    Sub LoadData(Optional ByVal SubStrSql As String = "")
        Dim SqlTot As String = " from StockInvoiceRowItems where isdelete=0 "
        If IsShowinSubUnits.Checked = True Then
            sQLSTR = "SELECT STOCKCODE AS [Stock Code], Stocksize as [Stock More Info], (select ledgername  FROM  StockInvoiceDetails  where StockInvoiceDetails.transcode=StockInvoiceRowItems.transcode) as [Account Name] ,qutoref as [Invoice No],vouchername as [Voucher], transdate as [Date]," _
         & "(CASE WHEN vouchername = 'PG' OR vouchername = 'DP' THEN qtytext WHEN vouchername = 'PR' THEN '-' +QTYTEXT ELSE '' END) AS [Inwards Qty], " _
         & "(CASE WHEN vouchername = 'PG' OR vouchername = 'DP' THEN stockamount WHEN vouchername = 'PR' THEN -1*STOCKAMOUNT ELSE 0 END) AS [Inwards Value]," _
         & "(CASE WHEN vouchername = 'SD' OR vouchername = 'POS' THEN qtytext WHEN VOUCHERNAME='SR'  THEN  '-' + qtytext ELSE '' END) AS [Outwards Qty]," _
         & "(CASE WHEN vouchername = 'SD' OR vouchername = 'POS' THEN stockamount WHEN VOUCHERNAME='SR' THEN -1*STOCKAMOUNT ELSE 0 END) AS [Outwards Value] from StockInvoiceRowItems where isdelete=0  "

        Else
            sQLSTR = "SELECT STOCKCODE AS [Stock Code], Stocksize as [Stock More Info], (select ledgername  FROM  StockInvoiceDetails  where StockInvoiceDetails.transcode=StockInvoiceRowItems.transcode) as [Account Name] ,qutoref as [Invoice No],vouchername as [Voucher], transdate as [Date]," _
         & "(CASE WHEN vouchername = 'PG' OR vouchername = 'DP' THEN totalqty WHEN vouchername='PR' then -1*totalqty ELSE 0 END) AS [Inwards Qty]," _
         & "(CASE WHEN vouchername = 'PG' OR vouchername = 'DP' THEN stockamount WHEN vouchername='PR' then -1*stockamount  ELSE 0 END) AS [Inwards Value]," _
         & "(CASE WHEN vouchername = 'SD' OR  vouchername = 'POS' THEN totalqty WHEN vouchername='SR' then -1*TOTALQTY  ELSE 0 END) AS [Outwards Qty]," _
         & "(CASE WHEN vouchername = 'SD' OR  vouchername = 'POS' THEN stockamount WHEN vouchername='SR' then -1*stockamount ELSE 0 END) AS [Outwards Value] from StockInvoiceRowItems where isdelete=0  "

        End If
        If TxtIsPeriod.Checked = True Then
            sQLSTR = sQLSTR & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
            SqlTot = SqlTot & " and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
        End If
       

        If TxtLedgerName.Text.Length = 0 Or TxtLedgerName.Text = "*All" Then
            sQLSTR = sQLSTR & SubStrSql & " and (vouchername='PR' or vouchername='PG' or vouchername='SD' or vouchername='SR' OR vouchername = 'POS' OR vouchername = 'DP')"

            If TxtShowSuppliers.Checked = True Then
                sQLSTR = sQLSTR & " and (transcode in (select transcode from StockInvoiceDetails where ledgername in (select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "'))))"
            Else
                sQLSTR = sQLSTR & "  and (transcode in (select transcode from StockInvoiceDetails where ledgername in (select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "'))))"
            End If
            SqlTot = SqlTot & SubStrSql
        Else

            sQLSTR = sQLSTR & SubStrSql & " and (vouchername='PR' or vouchername='PG' or vouchername='SD' or vouchername='SR' OR vouchername = 'POS' OR vouchername = 'DP' ) and (transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "'))"
            SqlTot = SqlTot & SubStrSql
        End If

        If TxtStockLocation.Text.Length = 0 Or TxtStockLocation.Text = "*All" Then
        Else
            sQLSTR = sQLSTR & " and location=N'" & TxtStockLocation.Text & "'"
            SqlTot = SqlTot & " and location=N'" & TxtStockLocation.Text & "'"
        End If

        If TxtByStockName.Text.Length = 0 Or TxtByStockName.Text = "*All" Then
        Else
            sQLSTR = sQLSTR & " and stockname=N'" & TxtByStockName.Text & "'"
            SqlTot = SqlTot & " and stockname=N'" & TxtByStockName.Text & "'"

        End If
        
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(sQLSTR)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try

            TxtList.Columns("Outwards Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Outwards Value").Width = 160
            TxtList.Columns("Outwards Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TxtList.Columns("Outwards Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Outwards Qty").Width = 160
            TxtList.Columns("Outwards Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TxtList.Columns("Inwards Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Inwards Value").Width = 160
            TxtList.Columns("Inwards Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            TxtList.Columns("Inwards Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Inwards Qty").Width = 160
            TxtList.Columns("Inwards Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Dim kstring As String = ""
            If TxtLedgerName.Text.Length = 0 Or TxtLedgerName.Text = "*All" Then
                If TxtShowSuppliers.Checked = True Then
                    kstring = "  and (transcode in (select transcode from StockInvoiceDetails where ledgername in (select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "'))))"
                Else
                    kstring = "  and (transcode in (select transcode from StockInvoiceDetails where ledgername in (select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "'))))"
                End If
            Else
                kstring = "  and (transcode in (select transcode from StockInvoiceDetails where ledgername=N'" & TxtLedgerName.Text & "'))"
            End If
            If TxtShowSuppliers.Checked = True Then
                TxtTotal3.Text = SQLGetNumericFieldValue("select sum(case when vouchername='PG' OR vouchername = 'DP' then totalqty else 0-totalqty end) as tot " & SqlTot & " and (vouchername = 'PG' OR vouchername = 'PR' OR vouchername = 'DP')" & kstring, "tot")
                TxtTotal4.Text = SQLGetNumericFieldValue("select sum( case  when vouchername='PG' OR vouchername = 'DP' then stockamount else 0-stockamount end ) as tot " & SqlTot & " and (vouchername = 'PG' OR vouchername = 'PR' OR vouchername = 'DP')" & kstring, "tot")
                ' TxtTotal3.Text = SQLGetNumericFieldValue("select sum( case when vouchername='SD' or vouchername='POS' then totalqty else 0-totalqty end) as tot " & SqlTot & " and (vouchername = 'SD' OR vouchername = 'SR' OR vouchername = 'POS') " & kstring, "tot")
                ' TxtTotal4.Text = SQLGetNumericFieldValue("select sum( case when vouchername='SD' or vouchername='POS' then stockamount else 0-stockamount end) as tot " & SqlTot & " and (vouchername = 'SD' OR vouchername = 'SR' OR vouchername = 'POS') " & kstring, "tot")

            Else
                ' TxtTotal1.Text = SQLGetNumericFieldValue("select sum(case when vouchername='PG' then totalqty else 0-totalqty end) as tot " & SqlTot & " and (vouchername = 'PG' OR vouchername = 'PR')" & kstring, "tot")
                '  TxtTotal2.Text = SQLGetNumericFieldValue("select sum( case  when vouchername='PG' then stockamount else 0-stockamount end ) as tot " & SqlTot & " and (vouchername = 'PG' OR vouchername = 'PR')" & kstring, "tot")
                TxtTotal3.Text = SQLGetNumericFieldValue("select sum( case when vouchername='SD' or vouchername='POS' then totalqty else 0-totalqty end) as tot " & SqlTot & " and (vouchername = 'SD' OR vouchername = 'SR' OR vouchername = 'POS') " & kstring, "tot")
                TxtTotal4.Text = SQLGetNumericFieldValue("select sum( case when vouchername='SD' or vouchername='POS' then stockamount else 0-stockamount end) as tot " & SqlTot & " and (vouchername = 'SD' OR vouchername = 'SR' OR vouchername = 'POS') " & kstring, "tot")

            End If
        Catch ex As Exception

        End Try
        If TxtShowSuppliers.Checked = True Then
            TxtList.Columns("Outwards Qty").Visible = False
            TxtList.Columns("Outwards Value").Visible = False
            TxtList.Columns("Inwards Value").Visible = True
            TxtList.Columns("Inwards Qty").Visible = True
        Else
            TxtList.Columns("Inwards Value").Visible = False
            TxtList.Columns("Inwards Qty").Visible = False
            TxtList.Columns("Outwards Qty").Visible = True
            TxtList.Columns("Outwards Value").Visible = True
        End If
        Try
            If AppIsItemwithSize = False Then
                TxtList.Columns("Stock More Info").Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub UserButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton2.Click
        If IsonLoading = True Then Exit Sub
        If TxtStockCode.Text.Length = 0 Then
            MsgBox("Please Select the Stock Item Code....", MsgBoxStyle.Information)
            Exit Sub
        End If
        LoadData(" and stockcode=N'" & TxtStockCode.Text & "'")
    End Sub

    Private Sub TxtByStockName_DropDown(sender As Object, e As System.EventArgs) Handles TxtByStockName.DropDown
        Dim frm As New SelectItemCodeorName(True)
        frm.IsAllowToSelectAll = True
        frm.ShowDialog()
        If SearchStockItemName.Length > 0 Then
            TxtByStockName.Items.Clear()
            TxtByStockName.Items.Add(SearchStockItemName)
            TxtByStockName.Text = SearchStockItemName
            LoadData()
        End If
    End Sub

    Private Sub TxtByStockName_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtByStockName.KeyPress
        Dim frm As New SelectItemCodeorName(True)
        frm.IsAllowToSelectAll = True
        frm.ShowDialog()
        If SearchStockItemName.Length > 0 Then
            TxtByStockName.Items.Clear()
            TxtByStockName.Items.Add(SearchStockItemName)
            TxtByStockName.Text = SearchStockItemName
            LoadData()
        End If
    End Sub

   
    Private Sub TxtStockName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockLocation.SelectedIndexChanged
       LoadData
    End Sub

    Private Sub TxtIsPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIsPeriod.CheckedChanged
        If IsonLoading = True Then Exit Sub
        If TxtStockCode.Text.Length = 0 Then
            MsgBox("Please Select the Stock Item Code....", MsgBoxStyle.Information)
            Exit Sub
        End If
        LoadData(" and stockcode=N'" & TxtStockCode.Text & "'")
    End Sub

    Private Sub IsShowinSubUnits_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsShowinSubUnits.CheckedChanged
        If IsonLoading = True Then Exit Sub
        If TxtStockCode.Text.Length = 0 Then
            MsgBox("Please Select the Stock Item Code....", MsgBoxStyle.Information)
            Exit Sub
        End If
        LoadData(" and stockcode=N'" & TxtStockCode.Text & "'")
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If sQLSTR.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(sQLSTR, cnn)
        dscmd.Fill(ds, "StockInvoiceRowItems")
        cnn.Close()
        Dim objRpt As New StockItemwiseCrReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True
            If TxtIsPeriod.Checked = True Then
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Report For " & TxtStockCode.Text & Chr(13) & "Period :" & TxtStartDate.Value.Date & " To " & TxtEndDate.Value.Date
            Else
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Report For " & TxtStockCode.Text
            End If
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True
            If TxtIsPeriod.Checked = True Then
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text & Chr(13) & "Report For " & TxtStockCode.Text & Chr(13) & "Period :" & TxtStartDate.Value.Date & " To " & TxtEndDate.Value.Date

            Else
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text & Chr(13) & "Report For " & TxtStockCode.Text

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

    Private Sub TxtShowSuppliers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShowSuppliers.CheckedChanged
        If TxtShowSuppliers.Checked = True Then
            LoadDataIntoComboBox("select distinct ledgername from StockInvoiceDetails where  vouchername in ('DP','PI','PG','PR')", TxtLedgerName, "ledgername", "*All")
        Else
            LoadDataIntoComboBox("select distinct ledgername from StockInvoiceDetails where  vouchername in ('POS','SI','SD','SR')", TxtLedgerName, "ledgername", "*All")
        End If
        If TxtStockCode.Text.Length = 0 Or TxtStockCode.Text = "*All" Then
            LoadData()
        Else
            LoadData(" and stockcode=N'" & TxtStockCode.Text & "'")
        End If
    End Sub

    Private Sub TxtLedgerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.SelectedIndexChanged
        If TxtStockCode.Text.Length = 0 Or TxtStockCode.Text = "*All" Then
            LoadData()
        Else
            LoadData(" and stockcode=N'" & TxtStockCode.Text & "'")
        End If

    End Sub

    Private Sub TxtStockCode_DropDown(sender As Object, e As System.EventArgs) Handles TxtStockCode.DropDown
        Dim frm As New SelectItemCodeorName(True)

        frm.ShowDialog()

        If SearchStockItemName.Length > 0 Then
            TxtStockCode.Items.Clear()
            TxtStockCode.Items.Add(SearchStockItemName)
            TxtStockCode.Text = SearchStockItemName
            LoadData(" and stockcode=N'" & TxtStockCode.Text & "'")
        End If
        If TxtStockCode.Text.Length = 0 Then
            MsgBox("Please Select the Stock Item Code....", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub


    Private Sub TxtStockCode_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtStockCode.KeyPress
        Dim frm As New SelectItemCodeorName(True)

        frm.ShowDialog()

        If SearchStockItemName.Length > 0 Then
            TxtStockCode.Items.Clear()
            TxtStockCode.Items.Add(SearchStockItemName)
            TxtStockCode.Text = SearchStockItemName
            LoadData(" and stockcode=N'" & TxtStockCode.Text & "'")
        End If
        If TxtStockCode.Text.Length = 0 Then
            MsgBox("Please Select the Stock Item Code....", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub

  
    Private Sub TxtStockCode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtStockCode.SelectedIndexChanged

    End Sub
End Class