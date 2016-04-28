Public Class BalanceSheet

    Public Shared LedgersBalaceReportFrom As LedgerBalanceSheetForm
    Public ShowCaptialAccountsalso As Boolean = True
    Dim Isloaded As Boolean = False
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Private Sub TxtList1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList1.DataError

    End Sub
    Sub loaddata()
        If Isloaded = False Then Exit Sub
        MainForm.Cursor = Cursors.WaitCursor
        Dim SqlStr As String = ""
        Dim Rowno As Integer = 0
        Dim TotalDrValue As Double = 0
        Dim TotalCrValue As Double = 0
        Dim val As Double = 0
        Dim StockInHandVal As Double = 0
        Dim OpeningStockValue As Double = 0
        ' 
        OpeningStockValue = SQLGetNumericFieldValue("select sum(opstockrate*optotalqty/unitcon) as tot from stockdbf WHERE STOCKTYPE=0", "tot")
        If IsDateWiseOn.Checked = True Then
            StockInHandVal = SQLGetNumericFieldValue("select sum(totalqty*stockrate/UnitCon) as tot from StockInvoiceRowItems where Isdelete=0 and VoucherName in ('DP','PG','SR') and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") ", "tot")
            StockInHandVal = OpeningStockValue + OpeningStockValue - SQLGetNumericFieldValue("select sum(e.ss/unitcon*e.ss) as tot from stockdbf as i INNER JOIN (select stockcode as sc, stocksize as sz , sum(totalqty) as ss from StockInvoiceRowItems where Isdelete=0 and VoucherName in ('POS','sd','PR') and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") group by stockcode,stocksize) as e on i.stockcode=e.sc and i.stocksize=e.sz", "tot")
        Else
            StockInHandVal = SQLGetNumericFieldValue("select sum(stockrate*totalqty/unitcon) as tot from stockdbf WHERE STOCKTYPE=0", "tot")
        End If



        ''CALCULATE THE " & AccountGroupNames.CurrentAssets & " and assets Values
        ' and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
        TxtList.Rows.Clear()
        SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CurrentAssets & "')))"
        If IsDateWiseOn.Checked = True Then
            val = SQLGetNumericFieldValue("select sum(dr-CR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
        Else
            val = SQLGetNumericFieldValue("select sum(dr-CR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
        End If
        val = val + StockInHandVal
        If TxtShowWithOpeningStock.Checked = True Then
            val = val + OpeningStockValue
        End If
        Rowno = TxtList.Rows.Add()
        TxtList.Item("ts1", Rowno).Value = 1
        TxtList.Item("tadetails", Rowno).Value = AccountGroupNames.CurrentAssets
        TxtList.Item("tavalues", Rowno).Value = FormatNumber(val, ErpDecimalPlaces)
        TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
        TotalDrValue = val

        If IsDetailedView.Checked = True Then
            Dim cmbGroups As New ComboBox
            If IsDetailedView.Checked = True Then
                LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CurrentAssets & "' and subgroup<>'" & AccountGroupNames.CurrentAssets & "'", cmbGroups, "subgroup")
            Else
                LoadDataIntoComboBox("select groupname from AccountGroups where grouproot=N'" & AccountGroupNames.CurrentAssets & "'", cmbGroups, "groupname")
            End If
            '  LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CurrentAssets & "' and subgroup<>'" & AccountGroupNames.CurrentAssets & "'", cmbGroups, "subgroup")
            Rowno = TxtList.Rows.Add()
            TxtList.Item("tadetails", Rowno).Value = "     Stock-in-Hand"
            TxtList.Item("tasubvalues", Rowno).Value = FormatNumber(StockInHandVal, ErpDecimalPlaces)
            If IsSubDetails.Checked = True Then
                Dim SqlConn As New SqlClient.SqlConnection
                Dim Sqlcmmd As New SqlClient.SqlCommand
                Try
                    SqlConn.ConnectionString = ConnectionStrinG
                    SqlConn.Open()
                    Sqlcmmd.Connection = SqlConn
                    If IsDateWiseOn.Checked = True Then
                        Sqlcmmd.CommandText = "select e.sc as [stockcode],e.sz as [stocksize], (e.ss/unitcon*e.ss) as tot from stockdbf as i INNER JOIN (select stockcode as sc, stocksize as sz , sum(totalqty) as ss from StockInvoiceRowItems where Isdelete=0 and VoucherName in ('POS','sd','PR') and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") group by stockcode,stocksize) as e on i.stockcode=e.sc and i.stocksize=e.sz "
                    Else
                        Sqlcmmd.CommandText = "select STOCKCODE,STOCKSIZE, sum(stockrate*(totalqty)/unitcon) AS tot from stockdbf   where stocktype=0 GROUP BY STOCKCODE,STOCKSIZE,BATCHNO"
                    End If
                    Sqlcmmd.CommandType = CommandType.Text
                    Dim Sreader As SqlClient.SqlDataReader
                    Sreader = Sqlcmmd.ExecuteReader
                    While Sreader.Read()
                        If Sreader("tot") <> 0 Then
                            Rowno = TxtList.Rows.Add
                            TxtList.Item("tadetails", Rowno).Value = "         " & Sreader("STOCKCODE").ToString.Trim & " " & Sreader("STOCKSIZE").ToString.Trim
                            TxtList.Item("tasubvalues", Rowno).Value = Sreader("tot")
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
            End If

            For i As Integer = 0 To cmbGroups.Items.Count - 1

                SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & cmbGroups.Items(i).ToString & "')))"
                If IsDateWiseOn.Checked = True Then
                    val = SQLGetNumericFieldValue("select sum(dr-cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
                Else
                    val = SQLGetNumericFieldValue("select sum(dr-cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
                End If
                If val <> 0 Then
                    Rowno = TxtList.Rows.Add()
                    TxtList.Item("tadetails", Rowno).Value = "     " & cmbGroups.Items(i).ToString
                    TxtList.Item("tasubvalues", Rowno).Value = FormatNumber(val, ErpDecimalPlaces)
                End If
                If IsSubDetails.Checked = True Then
                    Dim SqlConn As New SqlClient.SqlConnection
                    Dim Sqlcmmd As New SqlClient.SqlCommand
                    Try
                        SqlConn.ConnectionString = ConnectionStrinG
                        SqlConn.Open()
                        Sqlcmmd.Connection = SqlConn
                        If IsDateWiseOn.Checked = True Then
                            Sqlcmmd.CommandText = "select LEDGERNAME, sum(dr-cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") GROUP BY LEDGERNAME"
                        Else
                            Sqlcmmd.CommandText = "select LEDGERNAME, sum(dr-cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & " GROUP BY LEDGERNAME"
                        End If

                        Sqlcmmd.CommandType = CommandType.Text
                        Dim Sreader As SqlClient.SqlDataReader
                        Sreader = Sqlcmmd.ExecuteReader
                        While Sreader.Read()
                            Rowno = TxtList.Rows.Add
                            TxtList.Item("tadetails", Rowno).Value = "         " & Sreader("LEDGERNAME")
                            TxtList.Item("tasubvalues", Rowno).Value = IIf(Sreader("TOT") >= 0, FormatNumber(Sreader("TOT"), ErpDecimalPlaces) & " Dr", FormatNumber(Sreader("TOT") * -1, ErpDecimalPlaces) & " Cr")
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
                End If

            Next
        End If

        'Fixed Assets
        ' and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
        SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.FixedAssets & "')))"
        If IsDateWiseOn.Checked = True Then
            val = SQLGetNumericFieldValue("select sum(dr-CR) as tot from ledgerbook where isdeleted=0 and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
        Else
            val = SQLGetNumericFieldValue("select sum(dr-CR) as tot from ledgerbook where isdeleted=0 and ledgername in " & SqlStr, "tot")
        End If

        Rowno = TxtList.Rows.Add()
        TxtList.Item("ts1", Rowno).Value = 1
        TxtList.Item("tadetails", Rowno).Value = AccountGroupNames.FixedAssets
        TxtList.Item("tavalues", Rowno).Value = FormatNumber(val, ErpDecimalPlaces)
        TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
        TotalDrValue = TotalDrValue + val
        If IsDetailedView.Checked = True Then
            Dim cmbGroups As New ComboBox
            If IsDetailedView.Checked = True Then
                LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.FixedAssets & "' and subgroup<>'" & AccountGroupNames.FixedAssets & "'", cmbGroups, "subgroup")
            Else
                LoadDataIntoComboBox("select groupname from AccountGroups where grouproot=N'" & AccountGroupNames.FixedAssets & "'", cmbGroups, "groupname")
            End If
            '  LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CurrentAssets & "' and subgroup<>'" & AccountGroupNames.CurrentAssets & "'", cmbGroups, "subgroup")
            For i As Integer = 0 To cmbGroups.Items.Count - 1
                SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & cmbGroups.Items(i).ToString & "')))"
                If IsDateWiseOn.Checked = True Then
                    val = SQLGetNumericFieldValue("select sum(dr-cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
                Else
                    val = SQLGetNumericFieldValue("select sum(dr-cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
                End If
                If val <> 0 Then
                    Rowno = TxtList.Rows.Add()
                    TxtList.Item("tadetails", Rowno).Value = "     " & cmbGroups.Items(i).ToString
                    TxtList.Item("tasubvalues", Rowno).Value = FormatNumber(val, ErpDecimalPlaces)
                End If

                If IsSubDetails.Checked = True Then
                    Dim SqlConn As New SqlClient.SqlConnection
                    Dim Sqlcmmd As New SqlClient.SqlCommand
                    Try
                        SqlConn.ConnectionString = ConnectionStrinG
                        SqlConn.Open()
                        Sqlcmmd.Connection = SqlConn
                        If IsDateWiseOn.Checked = True Then
                            Sqlcmmd.CommandText = "select LEDGERNAME, sum(dr-cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") GROUP BY LEDGERNAME"
                        Else
                            Sqlcmmd.CommandText = "select LEDGERNAME, sum(dr-cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & " GROUP BY LEDGERNAME"
                        End If

                        Sqlcmmd.CommandType = CommandType.Text
                        Dim Sreader As SqlClient.SqlDataReader
                        Sreader = Sqlcmmd.ExecuteReader
                        While Sreader.Read()
                            Rowno = TxtList.Rows.Add
                            TxtList.Item("tadetails", Rowno).Value = "         " & Sreader("LEDGERNAME")
                            TxtList.Item("tasubvalues", Rowno).Value = IIf(Sreader("TOT") >= 0, FormatNumber(Sreader("TOT"), ErpDecimalPlaces) & " Dr", FormatNumber(Sreader("TOT") * -1, ErpDecimalPlaces) & " Cr")
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
                End If
            Next
        End If

        Dim ProfitlossAmount As Double
        ProfitlossAmount = GetProfitLossAcValues(IsDateWiseOn, TxtStartDate, TxtEndDate)
        If ProfitlossAmount < 0 Then
            Rowno = TxtList.Rows.Add()
            TxtList.Item("ts1", Rowno).Value = 1
            TxtList.Item("tadetails", Rowno).Value = "Profit & Loss A/c"
            TxtList.Item("tavalues", Rowno).Value = FormatNumber(ProfitlossAmount * -1, ErpDecimalPlaces)
            TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
            TotalDrValue = TotalDrValue + ProfitlossAmount * -1
        End If




        '***********************

        'liabalities


        ''CALCULATE THE Current LIABILITIES  Values
        ' and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
        TxtList1.Rows.Clear()
        If ShowCaptialAccountsalso = True Then
            SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CapitalAccounts & "')))"
            If IsDateWiseOn.Checked = True Then
                val = SQLGetNumericFieldValue("select sum(Cr-DR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
            Else
                val = SQLGetNumericFieldValue("select sum(Cr-DR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
            End If

            Rowno = TxtList1.Rows.Add()
            TxtList1.Item("ts2", Rowno).Value = 1
            TxtList1.Item("tldetails", Rowno).Value = AccountGroupNames.CapitalAccounts
            TxtList1.Item("tlvalues", Rowno).Value = FormatNumber(val, ErpDecimalPlaces)
            TxtList1.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
            TotalCrValue = val
            If IsDetailedView.Checked = True Then
                Dim cmbGroups As New ComboBox
                If IsDetailedView.Checked = True Then
                    LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CapitalAccounts & "' and subgroup<>'" & AccountGroupNames.CapitalAccounts & "'", cmbGroups, "subgroup")
                Else
                    LoadDataIntoComboBox("select groupname from AccountGroups where grouproot=N'" & AccountGroupNames.CapitalAccounts & "'", cmbGroups, "groupname")
                End If
                '  LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CurrentAssets & "' and subgroup<>'" & AccountGroupNames.CurrentAssets & "'", cmbGroups, "subgroup")
                For i As Integer = 0 To cmbGroups.Items.Count - 1

                    SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & cmbGroups.Items(i).ToString & "')))"
                    If IsDateWiseOn.Checked = True Then
                        val = SQLGetNumericFieldValue("select sum(Cr-DR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
                    Else
                        val = SQLGetNumericFieldValue("select sum(Cr-DR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
                    End If
                    If val <> 0 Then
                        Rowno = TxtList1.Rows.Add()
                        TxtList1.Item("tldetails", Rowno).Value = "     " & cmbGroups.Items(i).ToString
                        TxtList1.Item("tlsubvalues", Rowno).Value = FormatNumber(val, ErpDecimalPlaces)
                    End If

                    If IsSubDetails.Checked = True Then
                        Dim SqlConn As New SqlClient.SqlConnection
                        Dim Sqlcmmd As New SqlClient.SqlCommand
                        Try
                            SqlConn.ConnectionString = ConnectionStrinG
                            SqlConn.Open()
                            Sqlcmmd.Connection = SqlConn
                            If IsDateWiseOn.Checked = True Then
                                Sqlcmmd.CommandText = "select LEDGERNAME, sum(cr-dr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") GROUP BY LEDGERNAME"
                            Else
                                Sqlcmmd.CommandText = "select LEDGERNAME, sum(cr-dr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & " GROUP BY LEDGERNAME"
                            End If

                            Sqlcmmd.CommandType = CommandType.Text
                            Dim Sreader As SqlClient.SqlDataReader
                            Sreader = Sqlcmmd.ExecuteReader
                            While Sreader.Read()
                                Rowno = TxtList1.Rows.Add
                                TxtList1.Item("tldetails", Rowno).Value = "         " & Sreader("LEDGERNAME")
                                TxtList1.Item("tlsubvalues", Rowno).Value = IIf(Sreader("TOT") >= 0, FormatNumber(Sreader("TOT"), ErpDecimalPlaces) & " Dr", FormatNumber(Sreader("TOT") * -1, ErpDecimalPlaces) & " Cr")
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
                    End If
                Next
            End If

        End If



        'LIABILITIES

        SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CurrentLiabilities & "')))"
        If IsDateWiseOn.Checked = True Then
            val = SQLGetNumericFieldValue("select sum(Cr-DR) as tot from ledgerbook where isdeleted=0 and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
        Else
            val = SQLGetNumericFieldValue("select sum(Cr-DR) as tot from ledgerbook where isdeleted=0 and ledgername in " & SqlStr, "tot")
        End If

        Rowno = TxtList1.Rows.Add()
        TxtList1.Item("ts2", Rowno).Value = 1
        TxtList1.Item("tldetails", Rowno).Value = AccountGroupNames.CurrentLiabilities
        TxtList1.Item("tlvalues", Rowno).Value = FormatNumber(val, ErpDecimalPlaces)
        TxtList1.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
        TotalCrValue = TotalCrValue + val
        If IsDetailedView.Checked = True Then
            Dim cmbGroups As New ComboBox
            If IsDetailedView.Checked = True Then
                LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CurrentLiabilities & "' and subgroup<>'" & AccountGroupNames.CurrentLiabilities & "'", cmbGroups, "subgroup")
            Else
                LoadDataIntoComboBox("select groupname from AccountGroups where grouproot=N'" & AccountGroupNames.CurrentLiabilities & "'", cmbGroups, "groupname")
            End If
            '  LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CurrentAssets & "' and subgroup<>'" & AccountGroupNames.CurrentAssets & "'", cmbGroups, "subgroup")
            For i As Integer = 0 To cmbGroups.Items.Count - 1
                SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & cmbGroups.Items(i).ToString & "')))"
                If IsDateWiseOn.Checked = True Then
                    val = SQLGetNumericFieldValue("select sum(cr-dR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
                Else
                    val = SQLGetNumericFieldValue("select sum(cr-dR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
                End If
                If val <> 0 Then
                    Rowno = TxtList1.Rows.Add()
                    TxtList1.Item("tldetails", Rowno).Value = "     " & cmbGroups.Items(i).ToString
                    TxtList1.Item("tlsubvalues", Rowno).Value = FormatNumber(val, ErpDecimalPlaces)
                End If
                If IsSubDetails.Checked = True Then
                    Dim SqlConn As New SqlClient.SqlConnection
                    Dim Sqlcmmd As New SqlClient.SqlCommand
                    Try
                        SqlConn.ConnectionString = ConnectionStrinG
                        SqlConn.Open()
                        Sqlcmmd.Connection = SqlConn
                        If IsDateWiseOn.Checked = True Then
                            Sqlcmmd.CommandText = "select LEDGERNAME, sum(dr-cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") GROUP BY LEDGERNAME"
                        Else
                            Sqlcmmd.CommandText = "select LEDGERNAME, sum(dr-cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & " GROUP BY LEDGERNAME"
                        End If

                        Sqlcmmd.CommandType = CommandType.Text
                        Dim Sreader As SqlClient.SqlDataReader
                        Sreader = Sqlcmmd.ExecuteReader
                        While Sreader.Read()
                            Rowno = TxtList1.Rows.Add
                            TxtList1.Item("tldetails", Rowno).Value = "         " & Sreader("LEDGERNAME")
                            TxtList1.Item("tlsubvalues", Rowno).Value = IIf(Sreader("TOT") >= 0, FormatNumber(Sreader("TOT"), ErpDecimalPlaces) & " Dr", FormatNumber(Sreader("TOT") * -1, ErpDecimalPlaces) & " Cr")
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
                End If
            Next
        End If


        If ProfitlossAmount > 0 Then
            Rowno = TxtList1.Rows.Add()
            TxtList1.Item("ts2", Rowno).Value = 1
            TxtList1.Item("tldetails", Rowno).Value = "Profit & Loss A/c"
            TxtList1.Item("tlvalues", Rowno).Value = FormatNumber(ProfitlossAmount, ErpDecimalPlaces)
            TxtList1.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
            TotalCrValue = TotalCrValue + ProfitlossAmount
        End If

        If TotalCrValue > TotalDrValue Then
            Rowno = TxtList.Rows.Add()
            TxtList.Item("tadetails", Rowno).Value = "Differences in Opening Balances"
            TxtList.Item("tavalues", Rowno).Value = FormatNumber(TotalCrValue - TotalDrValue, ErpDecimalPlaces)
            TxtList.Item("tavalues", Rowno).Style.Font = New Font("Arial", 9, FontStyle.Bold)
            TxtDrTotal.Text = FormatNumber(TotalCrValue, ErpDecimalPlaces)
            TxtCrTotals.Text = FormatNumber(TotalCrValue, ErpDecimalPlaces)
        ElseIf TotalCrValue < TotalDrValue Then
            Rowno = TxtList1.Rows.Add()
            TxtList1.Item("tldetails", Rowno).Value = "Differences in Opening Balances"
            TxtList1.Item("tlvalues", Rowno).Value = FormatNumber(TotalDrValue - TotalCrValue, ErpDecimalPlaces)
            TxtList1.Item("tlvalues", Rowno).Style.Font = New Font("Arial", 9, FontStyle.Bold)
            TxtDrTotal.Text = FormatNumber(TotalDrValue, ErpDecimalPlaces)
            TxtCrTotals.Text = FormatNumber(TotalDrValue, ErpDecimalPlaces)
        Else
            TxtDrTotal.Text = FormatNumber(TotalDrValue, ErpDecimalPlaces)
            TxtCrTotals.Text = FormatNumber(TotalDrValue, ErpDecimalPlaces)
        End If
        MainForm.Cursor = Cursors.Default
    End Sub

    Private Sub BalanceSheet_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub BalanceSheet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load, RefreshToolStripMenuItem.Click

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        Isloaded = True
        loaddata()
    End Sub

    Private Sub IsDateWiseOn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsDateWiseOn.CheckedChanged
        If IsDateWiseOn.Checked = True Then
            TxtStartDate.Enabled = True
            TxtEndDate.Enabled = True
            Button1.Enabled = True
        Else
            TxtStartDate.Enabled = False
            TxtEndDate.Enabled = False
            Button1.Enabled = False
        End If
        loaddata()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        loaddata()
    End Sub

    Private Sub IsDetailedView_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsDetailedView.CheckedChanged, IsSubDetails.CheckedChanged
        loaddata()
    End Sub

   

    Private Sub TxtList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellDoubleClick
        LoadFormForAssets()
    End Sub
    Sub LoadFormForAssets()
        If TxtList.SelectedRows.Count > 0 Then
            If TxtList.Item("tadetails", TxtList.CurrentRow.Index).Value = "Profit & Loss A/c" Then
                Me.Cursor = Cursors.WaitCursor
                ProfitandLossForm.SuspendLayout()
                ProfitandLossForm.MdiParent = MainForm
                ProfitandLossForm.Dock = DockStyle.Fill
                ProfitandLossForm.Show()
                ProfitandLossForm.WindowState = FormWindowState.Maximized
                ProfitandLossForm.BringToFront()
                ProfitandLossForm.ResumeLayout()
                Me.Cursor = Cursors.Default
            ElseIf SQLIsFieldExists("SELECT TOP 1 1 from   accountgroups where groupname=N'" & Trim(TxtList.Item("tadetails", TxtList.CurrentRow.Index).Value) & "'") = True Then

                Me.Cursor = Cursors.WaitCursor
                My.Application.DoEvents()
                If LedgersBalaceReportFrom Is Nothing OrElse LedgersBalaceReportFrom.IsDisposed Then
                    LedgersBalaceReportFrom = New LedgerBalanceSheetForm()
                    LedgersBalaceReportFrom.MdiParent = MainForm
                    LedgersBalaceReportFrom.BringToFront()
                    LedgerBalanceSheetForm.TxtHeading.Text = UCase(Trim(TxtList.Item("tadetails", TxtList1.CurrentRow.Index).Value)) & " REPORT"
                    LedgersBalaceReportFrom.TxtGroupName.Text = Trim(TxtList.Item("tadetails", TxtList.CurrentRow.Index).Value)
                    LedgersBalaceReportFrom.Dock = DockStyle.Fill
                    LedgersBalaceReportFrom.Show()
                    LedgerBalanceSheetForm.TxtHeading.Text = UCase(Trim(TxtList.Item("tadetails", TxtList1.CurrentRow.Index).Value)) & " REPORT"
                    LedgersBalaceReportFrom.WindowState = FormWindowState.Maximized
                Else
                    LedgersBalaceReportFrom.MdiParent = Me
                    LedgersBalaceReportFrom.Dock = DockStyle.Fill
                    LedgersBalaceReportFrom.Show()
                    LedgersBalaceReportFrom.BringToFront()
                End If
                Me.Cursor = Cursors.Arrow
            End If
        End If
    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub TxtList1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList1.CellDoubleClick
        LoadFormForLiabilities()
    End Sub
    Sub LoadFormForLiabilities()
        If TxtList1.SelectedRows.Count > 0 Then
            If TxtList1.Item("tldetails", TxtList1.CurrentRow.Index).Value = "Profit & Loss A/c" Then
                Me.Cursor = Cursors.WaitCursor
                ProfitandLossForm.SuspendLayout()
                ProfitandLossForm.MdiParent = MainForm
                ProfitandLossForm.Dock = DockStyle.Fill
                ProfitandLossForm.Show()
                ProfitandLossForm.WindowState = FormWindowState.Maximized
                ProfitandLossForm.BringToFront()
                ProfitandLossForm.ResumeLayout()
                Me.Cursor = Cursors.Default
            ElseIf SQLIsFieldExists("SELECT TOP 1 1 from   accountgroups where groupname=N'" & Trim(TxtList1.Item("tldetails", TxtList1.CurrentRow.Index).Value) & "'") = True Then

                Me.Cursor = Cursors.WaitCursor
                My.Application.DoEvents()
                If LedgersBalaceReportFrom Is Nothing OrElse LedgersBalaceReportFrom.IsDisposed Then
                    LedgersBalaceReportFrom = New LedgerBalanceSheetForm()
                    LedgersBalaceReportFrom.MdiParent = MainForm
                    LedgersBalaceReportFrom.BringToFront()
                    LedgersBalaceReportFrom.TxtGroupName.Text = Trim(TxtList1.Item("tldetails", TxtList1.CurrentRow.Index).Value)
                    LedgersBalaceReportFrom.Dock = DockStyle.Fill
                    LedgersBalaceReportFrom.Show()
                    LedgerBalanceSheetForm.TxtHeading.Text = UCase(Trim(TxtList1.Item("tldetails", TxtList1.CurrentRow.Index).Value)) & " REPORT"
                    LedgersBalaceReportFrom.WindowState = FormWindowState.Maximized

                Else
                    LedgersBalaceReportFrom.MdiParent = Me
                    LedgersBalaceReportFrom.Dock = DockStyle.Fill
                    LedgersBalaceReportFrom.Show()
                    LedgersBalaceReportFrom.BringToFront()
                End If
                Me.Cursor = Cursors.Arrow
            End If
        End If
    End Sub

    Private Sub TxtList1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtList1.KeyDown
        If e.KeyCode = Keys.Return Then
            LoadFormForLiabilities()
        End If
    End Sub

   
    Private Sub TxtList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtList.KeyDown
        If e.KeyCode = Keys.Return Then
            LoadFormForAssets()
        End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, PrintToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New BalanceSheetDataSet
        ds.Clear()

        ds.Tables(0).Rows.Clear()

        If TxtList.RowCount > TxtList1.RowCount Then
            For i As Integer = 0 To TxtList.RowCount - 1
                Dim row As DataRow
                row = ds.Tables("Datatable1").NewRow
                For k As Integer = 0 To TxtList.ColumnCount - 1
                    row(TxtList.Columns(k).Name) = TxtList.Item(k, i).Value
                    Try
                        row(TxtList1.Columns(k).Name) = TxtList1.Item(k, i).Value
                    Catch ex As Exception

                    End Try
                Next
                ds.Tables("Datatable1").Rows.Add(row)
            Next
        Else
            For i As Integer = 0 To TxtList1.RowCount - 1
                Dim row As DataRow
                row = ds.Tables("Datatable1").NewRow
                For k As Integer = 0 To TxtList1.ColumnCount - 1
                    row(TxtList1.Columns(k).Name) = TxtList1.Item(k, i).Value
                    Try
                        row(TxtList.Columns(k).Name) = TxtList.Item(k, i).Value
                    Catch ex As Exception

                    End Try
                Next
                ds.Tables("Datatable1").Rows.Add(row)
            Next
        End If

        Dim objRpt As New BalanceSheetCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
        End If

        CType(objRpt.Section4.ReportObjects.Item("TXTLTOTAL"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtDrTotal.Text
        CType(objRpt.Section4.ReportObjects.Item("TXTRTOTAL"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtCrTotals.Text

        objRpt.SetDataSource(ds)
        Dim FRM As New ReportCommonForm(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cursor = Cursors.Default
        FRM.ShowDialog()
        FRM.Dispose()
        objRpt.Dispose()
        ds.Dispose()
    End Sub

    Private Sub txtwithcapitcalac_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtwithcapitcalac.CheckedChanged
        If txtwithcapitcalac.Checked = True Then
            ShowCaptialAccountsalso = True
        Else
            ShowCaptialAccountsalso = False
        End If
        loaddata()

    End Sub

    Private Sub TxtShowWithOpeningStock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShowWithOpeningStock.CheckedChanged
        loaddata()
    End Sub
End Class