Imports System.Data.SqlClient

Public Class CostCenterReportForm
    Dim SqlStr As String = ""
    Dim TotalSqlStrwhere As String = ""
    Dim ReportTitlestr As String = ""
    Sub LoadDef()
        LoadDataIntoComboBox("select ledgername from ledgers", TxtLedgername, "ledgername", "*All")
        LoadDataIntoComboBox("select StockGroupName from CostCenters where grouplevel=2", TxtPrimaryGroups, "StockGroupName", "*All")
        LoadDataIntoComboBox("select costname from CostCenterNames ", TxtCostGroups, "costname", "*All")
        LoadDataIntoComboBox("select groupname from AccountGroups", TxtAccountGroups, "groupname", "*All")

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
    End Sub
    
    Sub LoadDatewithDetails(Optional ByVal ParmSqlStr As String = "")

        SqlStr = "SELECT transdate as [Date],ledgername as [Particulars],vouchername as [Voucher Name],invoiceno as [Inv No], dr as [Debit], cr as [Credit] from costcenterbook  "

        '   SqlStr = SqlStr & ParmSqlStr
        Dim substr As String = ""
        If IsDateWiseOn.Checked = True Then
            substr = " where   (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
        End If
        If TxtPrimaryGroups.Text = "*All" Or TxtPrimaryGroups.Text.Length = 0 Then
        Else
            If substr.Length = 0 Then
                substr = substr & " where  costcat in (select subgroup from CostCenterList where groupname=N'" & TxtPrimaryGroups.Text & "') "
            Else
                substr = substr & " and  costcat in (select subgroup from CostCenterList where groupname=N'" & TxtPrimaryGroups.Text & "') "
            End If
        End If
        ' costcentername=N'" & TxtCostGroups.Text & "' 
        If TxtCostGroups.Text = "*All" Or TxtCostGroups.Text.Length = 0 Then

        Else
            If substr.Length = 0 Then
                substr = substr & " where  costcentername=N'" & TxtCostGroups.Text & "' "
            Else
                substr = substr & " and  costcentername=N'" & TxtCostGroups.Text & "' "
            End If
        End If

        If TxtAccountGroups.Text = "*All" Or TxtAccountGroups.Text.Length = 0 Then

        Else
            If substr.Length = 0 Then
                substr = substr & " where  ledgername in (select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroups.Text & "')) "
            Else
                substr = substr & " and  ledgername in (select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroups.Text & "')) "
            End If
        End If

        If TxtLedgername.Text = "*All" Or TxtLedgername.Text.Length = 0 Then

        Else
            If substr.Length = 0 Then
                substr = substr & " where  ledgername=N'" & TxtLedgername.Text & "' "
            Else
                substr = substr & " and  ledgername=N'" & TxtLedgername.Text & "' "
            End If
        End If
        SqlStr = SqlStr & substr

        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
       
        Try

            TxtList.Columns("Date").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Date").Width = 100
            TxtList.Columns("Date").DefaultCellStyle.Format = "d"
            TxtList.Columns("Date").DisplayIndex = 0

            TxtList.Columns("Particulars").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("Particulars").Width = 160
            TxtList.Columns("Particulars").DisplayIndex = 1

            TxtList.Columns("Voucher Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Voucher Name").Width = 120
            TxtList.Columns("Voucher Name").DisplayIndex = 2

            TxtList.Columns("Inv No").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Inv No").Width = 80
            TxtList.Columns("Inv No").DisplayIndex = 3

            TxtList.Columns("Debit").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Debit").Width = 160
            TxtList.Columns("Debit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Debit").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Debit").DisplayIndex = 4

            TxtList.Columns("Credit").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Credit").Width = 160
            TxtList.Columns("Credit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Credit").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Credit").DisplayIndex = 5

        Catch ex As Exception

        End Try
        Try
            TxtTotal1.Visible = False
            TxtTotal2.Text = FormatNumber(SQLGetNumericFieldValue("select sum(dr) as tot from costcenterbook " & substr, "tot"), ErpDecimalPlaces)
            TxtBalance.Text = FormatNumber(SQLGetNumericFieldValue("select sum(cr) as tot from costcenterbook " & substr, "tot"), ErpDecimalPlaces)

        Catch ex As Exception

        End Try
        TxtSubTitle.Text = ReportTitlestr
    End Sub

    Sub LoadData(Optional ByVal ParmSqlStr As String = "")
        SqlStr = "SELECT transdate as [Date],costcentername as [Particulars], sum(dr) as [Debit], sum(cr) as [Credit], CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1)  as [Closing Balance] from costcenterbook "
        'If ParmSqlStr.Length = 0 Then
        '    If IsDateWiseOn.Checked = True Then
        '        'CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1) 
        '        SqlStr = "SELECT transdate as [Date],costcentername as [Particulars], sum(dr) as [Debit], sum(cr) as [Credit], CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1)  as [Closing Balance] from costcenterbook where (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") group by costcentername,transdate "
        '    Else
        '        SqlStr = "SELECT transdate as [Date],costcentername as [Particulars], sum(dr) as [Debit], sum(cr) as [Credit], CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1)  as [Closing Balance] from costcenterbook group by costcentername,transdate "
        '    End If

        'End If

        Dim substr As String = ""
        If IsDateWiseOn.Checked = True Then
            substr = " where   (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
        End If
        If TxtPrimaryGroups.Text = "*All" Or TxtPrimaryGroups.Text.Length = 0 Then
        Else
            If substr.Length = 0 Then
                substr = substr & " where  costcat in (select subgroup from CostCenterList where groupname=N'" & TxtPrimaryGroups.Text & "') "
            Else
                substr = substr & " and  costcat in (select subgroup from CostCenterList where groupname=N'" & TxtPrimaryGroups.Text & "') "
            End If
        End If
        ' costcentername=N'" & TxtCostGroups.Text & "' 
        If TxtCostGroups.Text = "*All" Or TxtCostGroups.Text.Length = 0 Then

        Else
            If substr.Length = 0 Then
                substr = substr & " where  costcentername=N'" & TxtCostGroups.Text & "' "
            Else
                substr = substr & " and  costcentername=N'" & TxtCostGroups.Text & "' "
            End If
        End If

        If TxtAccountGroups.Text = "*All" Or TxtAccountGroups.Text.Length = 0 Then

        Else
            If substr.Length = 0 Then
                substr = substr & " where  ledgername in (select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroups.Text & "')) "
            Else
                substr = substr & " and  ledgername in (select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroups.Text & "')) "
            End If
        End If

        If TxtLedgername.Text = "*All" Or TxtLedgername.Text.Length = 0 Then

        Else
            If substr.Length = 0 Then
                substr = substr & " where  ledgername=N'" & TxtLedgername.Text & "' "
            Else
                substr = substr & " and  ledgername=N'" & TxtLedgername.Text & "' "
            End If
        End If
        SqlStr = SqlStr & substr

        SqlStr = SqlStr & "  group by costcentername,transdate  "

        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try

            TxtList.Columns("Particulars").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("Particulars").Width = 160
            TxtList.Columns("Particulars").DisplayIndex = 0

            TxtList.Columns("Debit").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Debit").Width = 160
            TxtList.Columns("Debit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Debit").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Debit").DisplayIndex = 2


            TxtList.Columns("Credit").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Credit").Width = 160
            TxtList.Columns("Credit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Credit").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Credit").DisplayIndex = 3


            TxtList.Columns("Closing Balance").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Closing Balance").Width = 160
            TxtList.Columns("Closing Balance").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Closing Balance").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Closing Balance").DisplayIndex = 4
        Catch ex As Exception

        End Try
        TxtTotal1.Visible = True
        Try
            TxtTotal1.Text = FormatNumber(SQLGetNumericFieldValue("select sum(dr) as tot from costcenterbook " & substr, "tot"), ErpDecimalPlaces)
            TxtTotal2.Text = FormatNumber(SQLGetNumericFieldValue("select sum(cr) as tot from costcenterbook " & substr, "tot"), ErpDecimalPlaces)
            If CDbl(TxtTotal1.Text) > CDbl(TxtTotal2.Text) Then
                TxtBalance.Text = FormatNumber((TxtTotal1.Text) - CDbl(TxtTotal2.Text), ErpDecimalPlaces).ToString & " Dr"
            Else
                TxtBalance.Text = FormatNumber(CDbl(TxtTotal2.Text) - (TxtTotal1.Text), ErpDecimalPlaces).ToString & " Cr"
            End If
        Catch ex As Exception

        End Try
        TxtSubTitle.Text = ReportTitlestr
    End Sub

   



    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click

        If TxtIsDetailed.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            Dim ds As New CostCenterDetDataSet
            ds.Clear()
            ds.Tables(0).Rows.Clear()
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

            Dim objRpt As New CostCenterDetCRReport
            SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
            If PrintOptionsforCR.IsPrintHeader = False Then
                CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
                CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
                CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ReportTitlestr
            Else
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ReportTitlestr
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
            Dim ds As New CostCenterSummeryDataSet
            ds.Clear()
            ds.Tables(0).Rows.Clear()
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

            Dim objRpt As New CostCenterSummeryCRReport
            SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
            If PrintOptionsforCR.IsPrintHeader = False Then
                CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
                CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
                CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ReportTitlestr
            Else
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ReportTitlestr
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


    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        If IsDateWiseOn.Checked = True Then
            ReportTitlestr = "COST CATEGORY REPORT " & Chr(13) & "FROM PERIOD " & FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " TO " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)
        Else
            ReportTitlestr = "COST CATEGORY REPORT "
        End If

        LoadData()
    End Sub

    Private Sub TxtPrimaryGroups_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrimaryGroups.SelectedIndexChanged
        If TxtPrimaryGroups.Text.Length = 0 Or TxtPrimaryGroups.Text = "*All" Then
            If IsDateWiseOn.Checked = True Then
                SqlStr = "SELECT transdate as [Date],costcentername as [Particulars], sum(dr) as [Debit], sum(cr) as [Credit], CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1)  as [Closing Balance] from costcenterbook where (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") group by costcentername,transdate "

                TotalSqlStrwhere = " where (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
                ReportTitlestr = "PRIMARY COST CENTER REPORT " & Chr(13) & "FROM PERIOD " & FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " TO " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)
            Else
                SqlStr = "SELECT transdate as [Date],costcentername as [Particulars], sum(dr) as [Debit], sum(cr) as [Credit], CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1)  as [Closing Balance] from costcenterbook group by costcentername,transdate "
                TotalSqlStrwhere = ""
                ReportTitlestr = "PRIMARY COST CENTER REPORT "
            End If

        Else
            'costcentername in (select subgroup from CostCenterList where groupname=N'" & txtprimarygroups.text & "')"
            If IsDateWiseOn.Checked = True Then
                SqlStr = "SELECT transdate as [Date],costcentername as [Particulars], sum(dr) as [Debit], sum(cr) as [Credit], CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1)  as [Closing Balance] from costcenterbook where  costcat in (select subgroup from CostCenterList where groupname=N'" & TxtPrimaryGroups.Text & "') and  (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") group by costcentername,transdate "
                TotalSqlStrwhere = " where  costcat in (select subgroup from CostCenterList where groupname=N'" & TxtPrimaryGroups.Text & "') and  (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
                ReportTitlestr = "PRIMARY COST CENTER REPORT FOR  " & UCase(TxtPrimaryGroups.Text) & " " & Chr(13) & "FROM PERIOD " & FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " TO " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)

            Else
                SqlStr = "SELECT transdate as [Date],costcentername as [Particulars], sum(dr) as [Debit], sum(cr) as [Credit], CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1)  as [Closing Balance] from costcenterbook where costcat in (select subgroup from CostCenterList where groupname=N'" & TxtPrimaryGroups.Text & "')  group by costcentername,transdate "
                TotalSqlStrwhere = " where costcat in (select subgroup from CostCenterList where groupname=N'" & TxtPrimaryGroups.Text & "') "
                ReportTitlestr = "PRIMARY COST CENTER REPORT FOR  " & UCase(TxtPrimaryGroups.Text) & " "
            End If
        End If
        If TxtIsDetailed.Checked = True Then
            LoadDatewithDetails(TotalSqlStrwhere)
        Else
            LoadData(SqlStr)
        End If
    End Sub

    Private Sub TxtCostGroups_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCostGroups.SelectedIndexChanged
        If TxtCostGroups.Text.Length = 0 Or TxtCostGroups.Text = "*All" Then
            If IsDateWiseOn.Checked = True Then
                SqlStr = "SELECT transdate as [Date],costcentername as [Particulars], sum(dr) as [Debit], sum(cr) as [Credit], CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1)  as [Closing Balance] from costcenterbook where (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") group by costcentername,transdate "
                TotalSqlStrwhere = " where (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"

                ReportTitlestr = "COST CENTER REPORT " & "FROM PERIOD " & FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " TO " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)
            Else
                SqlStr = "SELECT transdate as [Date],costcentername as [Particulars], sum(dr) as [Debit], sum(cr) as [Credit], CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1)  as [Closing Balance] from costcenterbook group by costcentername,transdate "
                TotalSqlStrwhere = ""
                ReportTitlestr = "COST CENTER REPORT "
            End If

        Else
            If IsDateWiseOn.Checked = True Then
                SqlStr = "SELECT transdate as [Date],costcentername as [Particulars], sum(dr) as [Debit], sum(cr) as [Credit], CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1)  as [Closing Balance] from costcenterbook where costcentername=N'" & TxtCostGroups.Text & "' and  (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") group by costcentername,transdate "
                TotalSqlStrwhere = "  where costcentername=N'" & TxtCostGroups.Text & "' and  (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
                ReportTitlestr = "COST CENTER REPORT FOR  " & UCase(TxtCostGroups.Text) & " " & Chr(13) & "FROM PERIOD " & FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " TO " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)

            Else
                SqlStr = "SELECT transdate as [Date],costcentername as [Particulars], sum(dr) as [Debit], sum(cr) as [Credit], CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1)  as [Closing Balance] from costcenterbook where costcentername=N'" & TxtCostGroups.Text & "'  group by costcentername,transdate "
                TotalSqlStrwhere = "  where costcentername=N'" & TxtCostGroups.Text & "'"
                ReportTitlestr = "COST CENTER REPORT FOR  " & UCase(TxtCostGroups.Text) & " "
            End If
        End If
        If TxtIsDetailed.Checked = True Then
            LoadDatewithDetails(TotalSqlStrwhere)
        Else
            LoadData(SqlStr)
        End If
    End Sub

    Private Sub TxtAccountGroups_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAccountGroups.SelectedIndexChanged
        If TxtAccountGroups.Text.Length = 0 Or TxtAccountGroups.Text = "*All" Then
            If IsDateWiseOn.Checked = True Then
                SqlStr = "SELECT transdate as [Date],costcentername as [Particulars], sum(dr) as [Debit], sum(cr) as [Credit], CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1)  as [Closing Balance] from costcenterbook where (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") group by costcentername,transdate "
                TotalSqlStrwhere = " where (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
                ReportTitlestr = "COST CENTER REPORT BY ACCOUNT GROUP " & Chr(13) & "FROM PERIOD " & FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " TO " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)

            Else
                SqlStr = "SELECT transdate as [Date],costcentername as [Particulars], sum(dr) as [Debit], sum(cr) as [Credit], CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1)  as [Closing Balance] from costcenterbook group by costcentername,transdate "
                ReportTitlestr = "COST CENTER REPORT BY ACCOUNT GROUP " & Chr(13) & "FROM PERIOD " & FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " TO " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)
                TotalSqlStrwhere = ""
            End If

        Else

            If IsDateWiseOn.Checked = True Then

                SqlStr = "SELECT transdate as [Date],costcentername as [Particulars], sum(dr) as [Debit], sum(cr) as [Credit], CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1)  as [Closing Balance] from costcenterbook where  ledgername in (select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroups.Text & "'))  and  (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") group by costcentername,transdate "
                TotalSqlStrwhere = " where  ledgername in (select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroups.Text & "'))  and  (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"

                ReportTitlestr = "COST CENTER REPORT FOR ACCOUNT GROUP " & UCase(TxtAccountGroups.Text) & " " & Chr(13) & "FROM PERIOD " & FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " TO " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)

            Else
                SqlStr = "SELECT transdate as [Date],costcentername as [Particulars], sum(dr) as [Debit], sum(cr) as [Credit], CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1)  as [Closing Balance] from costcenterbook where ledgername in (select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroups.Text & "'))  group by costcentername,transdate "
                TotalSqlStrwhere = "  where ledgername in (select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroups.Text & "'))"
                ReportTitlestr = "COST CENTER REPORT FOR ACCOUNT GROUP " & UCase(TxtAccountGroups.Text)
            End If
        End If
        If TxtIsDetailed.Checked = True Then
            LoadDatewithDetails(TotalSqlStrwhere)
        Else
            LoadData(SqlStr)
        End If
    End Sub

    Private Sub TxtLedgername_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgername.SelectedIndexChanged
        If TxtLedgername.Text.Length = 0 Or TxtLedgername.Text = "*All" Then
            If IsDateWiseOn.Checked = True Then
                SqlStr = "SELECT transdate as [Date],costcentername as [Particulars], sum(dr) as [Debit], sum(cr) as [Credit], CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1)  as [Closing Balance] from costcenterbook where (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") group by costcentername,transdate "
                TotalSqlStrwhere = " where (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
                ReportTitlestr = "COST CENTER REPORT BY LEDGER WISE " & Chr(13) & "FROM PERIOD " & FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " TO " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)

            Else
                SqlStr = "SELECT transdate as [Date],costcentername as [Particulars], sum(dr) as [Debit], sum(cr) as [Credit], CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1)  as [Closing Balance] from costcenterbook group by costcentername,transdate "
                ReportTitlestr = "COST CENTER REPORT FOR LEDGER WISE "
                TotalSqlStrwhere = ""
            End If

        Else
            'costcentername in (select subgroup from CostCenterList where groupname=N'" & txtprimarygroups.text & "')"
            '(select ledgername from ledgers where  accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroups.text & "'))
            If IsDateWiseOn.Checked = True Then
                SqlStr = "SELECT transdate as [Date],costcentername as [Particulars], sum(dr) as [Debit], sum(cr) as [Credit], CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1)  as [Closing Balance] from costcenterbook where  ledgername=N'" & TxtLedgername.Text & "'  and  (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") group by costcentername,transdate "
                TotalSqlStrwhere = " where  ledgername=N'" & TxtLedgername.Text & "'  and  (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
                ReportTitlestr = "COST CENTER REPORT FOR THE LEDGER " & UCase(TxtLedgername.Text) & " " & Chr(13) & "FROM PERIOD " & FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " TO " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)

            Else
                SqlStr = "SELECT transdate as [Date],costcentername as [Particulars], sum(dr) as [Debit], sum(cr) as [Credit], CONVERT(varchar(30), CAST(sum(dr-cr) AS DECIMAL(15,3)),1)  as [Closing Balance] from costcenterbook where ledgername=N'" & TxtLedgername.Text & "'  group by costcentername,transdate "
                TotalSqlStrwhere = "  where ledgername=N'" & TxtLedgername.Text & "' "
                ReportTitlestr = "COST CENTER REPORT FOR THE LEDGER " & UCase(TxtLedgername.Text) & " "
            End If
        End If
        If TxtIsDetailed.Checked = True Then
            LoadDatewithDetails(TotalSqlStrwhere)
        Else
            LoadData(SqlStr)
        End If
    End Sub

    Private Sub CostCenterReportForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub CostCenterReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        If IsDateWiseOn.Checked = True Then
            ReportTitlestr = "COST CATEGORY REPORT " & Chr(13) & "FROM PERIOD " & FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate) & " TO " & FormatDateTime(TxtEndDate.Value.Date, DateFormat.ShortDate)
        Else
            ReportTitlestr = "COST CATEGORY REPORT "
        End If
        LoadDef()
    End Sub

    Private Sub BtnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub TxtIsDetailed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIsDetailed.CheckedChanged
        If TxtIsDetailed.Checked = True Then
            LoadDatewithDetails("")
        Else
            LoadData("")
        End If
    End Sub

    Private Sub TxtList_DataError1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
End Class