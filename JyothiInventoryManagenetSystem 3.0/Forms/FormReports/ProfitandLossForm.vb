Public Class ProfitandLossForm
    Public Shared LedgersBalaceReportFrom As LedgerBalanceSheetForm
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Private Sub TxtList1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList1.DataError

    End Sub
    Sub loaddata()
        'FINDING STOCK OPENING BALANCES
        Dim VALUE As Double = 0
        Dim RNO As Integer = 0
        Dim opvalue As Double = 0
        Dim purvalue As Double = 0
        Dim clvalue As Double = 0
        Dim salvalue As Double = 0
        Dim DExpenses As Double = 0
        Dim DIncomes As Double = 0
        Dim Expense As Double = 0
        Dim Incomes As Double = 0
        TxtList.Rows.Clear()
        TxtList1.Rows.Clear()
        If IsDateWiseOn.Checked = True Then
            Dim OPSQLSTR As String = ""
            OPSQLSTR = " Select stockcode,stocksize, (ISNULL(optotalqty/unitcon,0)+ISNULL((select sum(totalqty/unitcon) from StockInvoiceRowItems where Isdelete=0 and StockInvoiceRowItems.StockCode=stockdbf.stockcode and StockInvoiceRowItems.stocksize=stockdbf.stocksize and StockInvoiceRowItems.location=stockdbf.Location and vouchername in ('DP','PG','SJIN')  and Transdatevalue<" & TxtStartDate.Value.Date.ToOADate & " ),0)+ISNULL((select sum(totalqty/unitcon) from StockInvoiceRowItems where Isdelete=0 and StockInvoiceRowItems.StockCode=stockdbf.stockcode and StockInvoiceRowItems.stocksize=stockdbf.stocksize and StockInvoiceRowItems.location=stockdbf.Location and vouchername='SR'  and Transdatevalue<" & TxtStartDate.Value.Date.ToOADate & "),0) - ISNULL((select sum(totalqty/unitcon) from StockInvoiceRowItems where Isdelete=0 and StockInvoiceRowItems.StockCode=stockdbf.stockcode and StockInvoiceRowItems.stocksize=stockdbf.stocksize and StockInvoiceRowItems.location=stockdbf.Location and vouchername='PR'  and Transdatevalue<" & TxtStartDate.Value.Date.ToOADate & "),0)-ISNULL((select sum(totalqty/unitcon) from StockInvoiceRowItems where Isdelete=0 and StockInvoiceRowItems.StockCode=stockdbf.stockcode and StockInvoiceRowItems.stocksize=stockdbf.stocksize and StockInvoiceRowItems.location=stockdbf.Location and vouchername in ('SD','POS','SJOUT')  and Transdatevalue<" & TxtStartDate.Value.Date.ToOADate & "),0))* STOCKRATE as tval from stockdbf "
            opvalue = SQLGetNumericFieldValue("SELECT SUM(tval) AS TOT FROM (" & OPSQLSTR & ")  as MTTABLE ", "tot")

            If opvalue <> 0 Then
                RNO = TxtList.Rows.Add
                TxtList.Item("TLDetails", RNO).Value = "Opening Stock Value "
                TxtList.Item("TLAmount", RNO).Value = FormatNumber(opvalue, ErpDecimalPlaces)
                If ISDetailedView.Checked = True Then
                    Dim SqlConn As New SqlClient.SqlConnection
                    Dim Sqlcmmd As New SqlClient.SqlCommand
                    Try
                        SqlConn.ConnectionString = ConnectionStrinG
                        SqlConn.Open()
                        Sqlcmmd.Connection = SqlConn
                        Sqlcmmd.CommandText = OPSQLSTR
                        Sqlcmmd.CommandType = CommandType.Text
                        Dim Sreader As SqlClient.SqlDataReader
                        Sreader = Sqlcmmd.ExecuteReader
                        While Sreader.Read()
                            If Sreader("tval") <> 0 Then
                                RNO = TxtList.Rows.Add
                                TxtList.Item("TLDetails", RNO).Value = "  " & Sreader("STOCKCODE").ToString.Trim & " " & Sreader("STOCKSIZE").ToString.Trim
                                TxtList.Item("TLSubAmount", RNO).Value = FormatNumber(Sreader("tval"), ErpDecimalPlaces)
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
            End If
        Else
            opvalue = SQLGetNumericFieldValue("select SUM(OpTotalQty * opStockRate / UnitCon) AS tot from stockdbf   where stocktype=0 ", "tot")



            If opvalue <> 0 Then
                RNO = TxtList.Rows.Add
                TxtList.Item("TLDetails", RNO).Value = "Opening Stock Value "
                TxtList.Item("TLAmount", RNO).Value = FormatNumber(opvalue, ErpDecimalPlaces)
                If ISDetailedView.Checked = True Then
                    Dim SqlConn As New SqlClient.SqlConnection
                    Dim Sqlcmmd As New SqlClient.SqlCommand
                    Try
                        SqlConn.ConnectionString = ConnectionStrinG
                        SqlConn.Open()
                        Sqlcmmd.Connection = SqlConn
                        Sqlcmmd.CommandText = "select STOCKCODE,STOCKSIZE, SUM(OpTotalQty * opStockRate / UnitCon) AS tot from stockdbf   where stocktype=0 GROUP BY STOCKCODE,STOCKSIZE,BATCHNO"
                        Sqlcmmd.CommandType = CommandType.Text
                        Dim Sreader As SqlClient.SqlDataReader
                        Sreader = Sqlcmmd.ExecuteReader
                        While Sreader.Read()
                            If Sreader("tot") <> 0 Then
                                RNO = TxtList.Rows.Add
                                TxtList.Item("TLDetails", RNO).Value = "  " & Sreader("STOCKCODE").ToString.Trim & " " & Sreader("STOCKSIZE").ToString.Trim
                                TxtList.Item("TLSubAmount", RNO).Value = FormatNumber(Sreader("tot"), ErpDecimalPlaces)
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
            End If
        End If
        

        'CALCULATE PURCHASE ACCOUNTS
        '(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'Purchase Accounts')))

        If IsDateWiseOn.Checked = True Then
            purvalue = SQLGetNumericFieldValue("select SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')))  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") ", "tot")
            If purvalue <> 0 Then
                RNO = TxtList.Rows.Add
                TxtList.Item("TLDetails", RNO).Value = AccountGroupNames.PurchaseAccounts
                TxtList.Item("TLAmount", RNO).Value = FormatNumber(purvalue, ErpDecimalPlaces)
            End If
            If ISDetailedView.Checked = True Then
                Dim SqlConn As New SqlClient.SqlConnection
                Dim Sqlcmmd As New SqlClient.SqlCommand
                Try
                    SqlConn.ConnectionString = ConnectionStrinG
                    SqlConn.Open()
                    Sqlcmmd.Connection = SqlConn
                    Sqlcmmd.CommandText = "select LEDGERNAME, SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')))  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") GROUP BY LEDGERNAME"
                    Sqlcmmd.CommandType = CommandType.Text
                    Dim Sreader As SqlClient.SqlDataReader
                    Sreader = Sqlcmmd.ExecuteReader
                    While Sreader.Read()
                        RNO = TxtList.Rows.Add
                        TxtList.Item("TLDetails", RNO).Value = "  " & Sreader("LEDGERNAME").ToString.Trim
                        TxtList.Item("TLSubAmount", RNO).Value = FormatNumber(Sreader("tot"), ErpDecimalPlaces)
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

        Else
            purvalue = SQLGetNumericFieldValue("select SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "'))) ", "tot")
            If purvalue <> 0 Then
                RNO = TxtList.Rows.Add
                TxtList.Item("TLDetails", RNO).Value = AccountGroupNames.PurchaseAccounts
                TxtList.Item("TLAmount", RNO).Value = FormatNumber(purvalue, ErpDecimalPlaces)
            End If

            If ISDetailedView.Checked = True Then
                Dim SqlConn As New SqlClient.SqlConnection
                Dim Sqlcmmd As New SqlClient.SqlCommand
                Try
                    SqlConn.ConnectionString = ConnectionStrinG
                    SqlConn.Open()
                    Sqlcmmd.Connection = SqlConn
                    Sqlcmmd.CommandText = "select LEDGERNAME, SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')))  GROUP BY LEDGERNAME"
                    Sqlcmmd.CommandType = CommandType.Text
                    Dim Sreader As SqlClient.SqlDataReader
                    Sreader = Sqlcmmd.ExecuteReader
                    While Sreader.Read()
                        RNO = TxtList.Rows.Add
                        TxtList.Item("TLDetails", RNO).Value = "  " & Sreader("ledgername").ToString.Trim
                        TxtList.Item("TLSubAmount", RNO).Value = FormatNumber(Sreader("tot"), ErpDecimalPlaces)
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
        End If


        'CALCULATE SALES ACCOUNTS
        
        If IsDateWiseOn.Checked = True Then
            salvalue = SQLGetNumericFieldValue("select SUM(CR-Dr) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')))  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
            If salvalue <> 0 Then
                RNO = TxtList1.Rows.Add
                TxtList1.Item("TRDetails", RNO).Value = AccountGroupNames.SalesAccounts

                TxtList1.Item("TRAmount", RNO).Value = FormatNumber(salvalue, ErpDecimalPlaces)
            End If
            If ISDetailedView.Checked = True Then
                Dim SqlConn As New SqlClient.SqlConnection
                Dim Sqlcmmd As New SqlClient.SqlCommand
                Try
                    SqlConn.ConnectionString = ConnectionStrinG
                    SqlConn.Open()
                    Sqlcmmd.Connection = SqlConn
                    Sqlcmmd.CommandText = "select LEDGERNAME, SUM(CR-Dr) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')))  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") GROUP BY LEDGERNAME "
                    Sqlcmmd.CommandType = CommandType.Text
                    Dim Sreader As SqlClient.SqlDataReader
                    Sreader = Sqlcmmd.ExecuteReader
                    While Sreader.Read()
                        RNO = TxtList1.Rows.Add
                        TxtList1.Item("TrDetails", RNO).Value = "  " & Sreader("LEDGERNAME").ToString.Trim
                        TxtList1.Item("TRSubAmount", RNO).Value = FormatNumber(Sreader("tot"), ErpDecimalPlaces)
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

        Else
            salvalue = SQLGetNumericFieldValue("select SUM(CR-Dr) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "'))) ", "tot")
            If salvalue <> 0 Then
                RNO = TxtList1.Rows.Add
                TxtList1.Item("TRDetails", RNO).Value = AccountGroupNames.SalesAccounts

                TxtList1.Item("TRAmount", RNO).Value = FormatNumber(salvalue, ErpDecimalPlaces)
            End If

            If ISDetailedView.Checked = True Then
                Dim SqlConn As New SqlClient.SqlConnection
                Dim Sqlcmmd As New SqlClient.SqlCommand
                Try
                    SqlConn.ConnectionString = ConnectionStrinG
                    SqlConn.Open()
                    Sqlcmmd.Connection = SqlConn
                    Sqlcmmd.CommandText = "select LEDGERNAME, SUM(CR-DR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')))  GROUP BY LEDGERNAME"
                    Sqlcmmd.CommandType = CommandType.Text
                    Dim Sreader As SqlClient.SqlDataReader
                    Sreader = Sqlcmmd.ExecuteReader
                    While Sreader.Read()
                        RNO = TxtList1.Rows.Add
                        TxtList1.Item("TRDetails", RNO).Value = "  " & Sreader("ledgername").ToString.Trim
                        TxtList1.Item("TRSubAmount", RNO).Value = FormatNumber(Sreader("tot"), ErpDecimalPlaces)
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
        End If


        Dim ISlOSS As Boolean = False
        Dim grossprofitlosstotal As Double = 0
        If IsDateWiseOn.Checked = True Then
            DExpenses = SQLGetNumericFieldValue("select SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.DirectExpenses & "')))  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
            DIncomes = SQLGetNumericFieldValue("select SUM(CR-DR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.DirectIncomes & "')))  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
            Expense = SQLGetNumericFieldValue("select SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "')))   and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
            Incomes = SQLGetNumericFieldValue("select SUM(CR-dr) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectIncomes & "')))   and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")

        Else
            DExpenses = SQLGetNumericFieldValue("select SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.DirectExpenses & "'))) ", "tot")
            DIncomes = SQLGetNumericFieldValue("select SUM(CR-DR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.DirectIncomes & "'))) ", "tot")
            Expense = SQLGetNumericFieldValue("select SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "'))) ", "tot")
            Incomes = SQLGetNumericFieldValue("select SUM(CR-dr) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectIncomes & "'))) ", "tot")

        End If

        If DExpenses <> 0 Then
            RNO = TxtList.Rows.Add
            TxtList.Item("TLDetails", RNO).Value = AccountGroupNames.DirectExpenses
            TxtList.Item("TLAmount", RNO).Value = FormatNumber(DExpenses, ErpDecimalPlaces)

            If ISDetailedView.Checked = True Then
                Dim SqlConn As New SqlClient.SqlConnection
                Dim Sqlcmmd As New SqlClient.SqlCommand
                Try
                    SqlConn.ConnectionString = ConnectionStrinG
                    SqlConn.Open()
                    Sqlcmmd.Connection = SqlConn
                    If IsDateWiseOn.Checked = True Then
                        Sqlcmmd.CommandText = "select ledgername, SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.DirectExpenses & "')))  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  GROUP BY LEDGERNAME"
                    Else
                        Sqlcmmd.CommandText = "select ledgername, SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.DirectExpenses & "')))    GROUP BY LEDGERNAME"
                    End If

                    Sqlcmmd.CommandType = CommandType.Text
                    Dim Sreader As SqlClient.SqlDataReader
                    Sreader = Sqlcmmd.ExecuteReader
                    While Sreader.Read()
                        RNO = TxtList.Rows.Add
                        TxtList.Item("TLDetails", RNO).Value = "  " & Sreader("ledgername").ToString.Trim
                        TxtList.Item("TLSubAmount", RNO).Value = FormatNumber(Math.Abs(Sreader("tot")), ErpDecimalPlaces)
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

        End If
        '''''NEEED
        If DIncomes <> 0 Then
            RNO = TxtList1.Rows.Add
            TxtList1.Item("TRDetails", RNO).Value = AccountGroupNames.DirectIncomes
            TxtList1.Item("TRAmount", RNO).Value = FormatNumber(DIncomes, ErpDecimalPlaces)
            If ISDetailedView.Checked = True Then
                Dim SqlConn As New SqlClient.SqlConnection
                Dim Sqlcmmd As New SqlClient.SqlCommand
                Try
                    SqlConn.ConnectionString = ConnectionStrinG
                    SqlConn.Open()
                    Sqlcmmd.Connection = SqlConn
                    If IsDateWiseOn.Checked = True Then
                        Sqlcmmd.CommandText = "select ledgername, SUM(CR-DR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.DirectExpenses & "')))  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  GROUP BY LEDGERNAME"
                    Else
                        Sqlcmmd.CommandText = "select ledgername, SUM(CR-DR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.DirectExpenses & "')))    GROUP BY LEDGERNAME"
                    End If

                    Sqlcmmd.CommandType = CommandType.Text
                    Dim Sreader As SqlClient.SqlDataReader
                    Sreader = Sqlcmmd.ExecuteReader
                    While Sreader.Read()
                        RNO = TxtList1.Rows.Add
                        TxtList1.Item("TRDetails", RNO).Value = "  " & Sreader("ledgername").ToString.Trim
                        TxtList1.Item("TRSubAmount", RNO).Value = FormatNumber(Math.Abs(Sreader("tot")), ErpDecimalPlaces)
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
        End If
        If IsDateWiseOn.Checked = True Then
            'clvalue = SQLGetNumericFieldValue("select sum(totalqty*stockrate/UnitCon) as tot from StockInvoiceRowItems where Isdelete=0 and VoucherName in ('DP','PG','SR') and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") ", "tot")
            'clvalue = clvalue + opvalue - SQLGetNumericFieldValue("select sum(e.ss/unitcon*e.ss) as tot from stockdbf as i INNER JOIN (select stockcode as sc, stocksize as sz , sum(totalqty) as ss from StockInvoiceRowItems where Isdelete=0 and VoucherName in ('POS','sd','PR') and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") group by stockcode,stocksize) as e on i.stockcode=e.sc and i.stocksize=e.sz", "tot")
            Dim OPSQLSTR As String = ""
            OPSQLSTR = " Select stockcode,stocksize, (ISNULL(optotalqty/unitcon,0)+ISNULL((select sum(totalqty/unitcon) from StockInvoiceRowItems where Isdelete=0 and StockInvoiceRowItems.StockCode=stockdbf.stockcode and StockInvoiceRowItems.stocksize=stockdbf.stocksize and StockInvoiceRowItems.location=stockdbf.Location and vouchername in ('DP','PG','SJIN')  and Transdatevalue<=" & TxtEndDate.Value.Date.ToOADate & " ),0)+ISNULL((select sum(totalqty/unitcon) from StockInvoiceRowItems where Isdelete=0 and StockInvoiceRowItems.StockCode=stockdbf.stockcode and StockInvoiceRowItems.stocksize=stockdbf.stocksize and StockInvoiceRowItems.location=stockdbf.Location and vouchername='SR'  and Transdatevalue<=" & TxtEndDate.Value.Date.ToOADate & "),0) - ISNULL((select sum(totalqty/unitcon) from StockInvoiceRowItems where Isdelete=0 and StockInvoiceRowItems.StockCode=stockdbf.stockcode and StockInvoiceRowItems.stocksize=stockdbf.stocksize and StockInvoiceRowItems.location=stockdbf.Location and vouchername='PR'  and Transdatevalue<=" & TxtEndDate.Value.Date.ToOADate & "),0)-ISNULL((select sum(totalqty/unitcon) from StockInvoiceRowItems where Isdelete=0 and StockInvoiceRowItems.StockCode=stockdbf.stockcode and StockInvoiceRowItems.stocksize=stockdbf.stocksize and StockInvoiceRowItems.location=stockdbf.Location and vouchername in ('SD','POS','SJOUT')  and Transdatevalue<=" & TxtEndDate.Value.Date.ToOADate & "),0))* STOCKRATE as tval from stockdbf "
            clvalue = SQLGetNumericFieldValue("SELECT SUM(tval) AS TOT FROM (" & OPSQLSTR & ")  as MTTABLE ", "tot")

            If clvalue <> 0 Then
                RNO = TxtList1.Rows.Add
                TxtList1.Item("TRDetails", RNO).Value = "Closing Stock Value"
                TxtList1.Item("TRAmount", RNO).Value = FormatNumber(clvalue, ErpDecimalPlaces)

                If ISDetailedView.Checked = True Then
                    Dim SqlConn As New SqlClient.SqlConnection
                    Dim Sqlcmmd As New SqlClient.SqlCommand
                    Try
                        SqlConn.ConnectionString = ConnectionStrinG
                        SqlConn.Open()
                        Sqlcmmd.Connection = SqlConn
                        'If IsDateWiseOn.Checked = True Then
                        '    Sqlcmmd.CommandText = "select e.sc as [stockcode],e.sz as [stocksize], (e.ss/unitcon*e.ss) as tot from stockdbf as i INNER JOIN (select stockcode as sc, stocksize as sz , sum(totalqty) as ss from StockInvoiceRowItems where Isdelete=0 and VoucherName in ('POS','sd','PR') and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") group by stockcode,stocksize) as e on i.stockcode=e.sc and i.stocksize=e.sz "
                        'Else
                        '    Sqlcmmd.CommandText = "select STOCKCODE,STOCKSIZE, sum(stockrate*(totalqty)/unitcon) AS tot from stockdbf   where stocktype=0 GROUP BY STOCKCODE,STOCKSIZE,BATCHNO"
                        'End If
                        Sqlcmmd.CommandText = OPSQLSTR
                        Sqlcmmd.CommandType = CommandType.Text
                        Dim Sreader As SqlClient.SqlDataReader
                        Sreader = Sqlcmmd.ExecuteReader
                        While Sreader.Read()
                            If Sreader("tval") <> 0 Then
                                RNO = TxtList1.Rows.Add
                                TxtList1.Item("TRDetails", RNO).Value = "  " & Sreader("STOCKCODE").ToString.Trim & " " & Sreader("STOCKSIZE").ToString.Trim
                                TxtList1.Item("TRSubAmount", RNO).Value = FormatNumber(Math.Abs(Sreader("tval")), ErpDecimalPlaces)
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

            End If

        Else
            clvalue = SQLGetNumericFieldValue("select sum(stockrate*(totalqty)/unitcon) as tot from stockdbf where stocktype=0", "tot")
            If clvalue <> 0 Then
                RNO = TxtList1.Rows.Add
                TxtList1.Item("TRDetails", RNO).Value = "Closing Stock Value"
                TxtList1.Item("TRAmount", RNO).Value = FormatNumber(clvalue, ErpDecimalPlaces)

                If ISDetailedView.Checked = True Then
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
                                RNO = TxtList1.Rows.Add
                                TxtList1.Item("TRDetails", RNO).Value = "  " & Sreader("STOCKCODE").ToString.Trim & " " & Sreader("STOCKSIZE").ToString.Trim
                                TxtList1.Item("TRSubAmount", RNO).Value = FormatNumber(Math.Abs(Sreader("tot")), ErpDecimalPlaces)
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

            End If
        End If

        

        Dim Opgrossprofitlosstotal As Double = 0
        Dim st As String = ""
      
        If IsDateWiseOn.Checked = True Then
            st = "select  SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.ProfitLossAccounts & "')))  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
            Opgrossprofitlosstotal = SQLGetNumericFieldValue(st, "tot")
        Else
            st = "select  SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.ProfitLossAccounts & "')))"
            Opgrossprofitlosstotal = SQLGetNumericFieldValue(st, "tot")
        End If

        Dim GrossTotal As Double = 0
        If Opgrossprofitlosstotal >= 0 Then

            If (salvalue + DIncomes + clvalue + Opgrossprofitlosstotal) - (opvalue + purvalue + DExpenses) > 0 Then
                'If salvalue + DIncomes + clvalue + Opgrossprofitlosstotal >= opvalue + purvalue + DExpenses Then
                grossprofitlosstotal = (salvalue + DIncomes + clvalue + Opgrossprofitlosstotal) - (opvalue + purvalue + DExpenses)
                RNO = TxtList.Rows.Add
                TxtList.Item("TLDetails", RNO).Value = "Gross Profit C/O"
                TxtList.Item("TLAmount", RNO).Value = FormatNumber(grossprofitlosstotal, ErpDecimalPlaces)
                ' GrossTotal = opvalue + purvalue + DIncomes - (opvalue + purvalue + DIncomes)
                GrossTotal = grossprofitlosstotal
                ISlOSS = False
            Else
                RNO = TxtList1.Rows.Add
                grossprofitlosstotal = (opvalue + purvalue + DExpenses) - (salvalue + DIncomes + clvalue + Opgrossprofitlosstotal)
                TxtList1.Item("TRDetails", RNO).Value = "Gross Loss C/O"
                TxtList1.Item("TRAmount", RNO).Value = FormatNumber(grossprofitlosstotal, ErpDecimalPlaces)
                '  GrossTotal = opvalue + purvalue + DIncomes - (salvalue + clvalue + DExpenses)
                GrossTotal = grossprofitlosstotal
                ISlOSS = True
            End If
        Else
            If (salvalue + DIncomes + clvalue) - (opvalue + purvalue + DExpenses + Opgrossprofitlosstotal) > 0 Then
                'If salvalue + DIncomes + clvalue >= opvalue + purvalue + DExpenses + Opgrossprofitlosstotal Then
                grossprofitlosstotal = (salvalue + DIncomes + clvalue) - (opvalue + purvalue + DExpenses + Opgrossprofitlosstotal)
                RNO = TxtList.Rows.Add
                TxtList.Item("TLDetails", RNO).Value = "Gross Profit C/O"
                TxtList.Item("TLAmount", RNO).Value = FormatNumber(grossprofitlosstotal, ErpDecimalPlaces)
                'GrossTotal = opvalue + purvalue + DIncomes - (opvalue + purvalue + DIncomes)
                GrossTotal = grossprofitlosstotal
                ISlOSS = False
            Else
                RNO = TxtList1.Rows.Add
                grossprofitlosstotal = (opvalue + purvalue + DExpenses + Opgrossprofitlosstotal) - (salvalue + DIncomes + clvalue)
                TxtList1.Item("TRDetails", RNO).Value = "Gross Loss C/O"
                TxtList1.Item("TRAmount", RNO).Value = FormatNumber(grossprofitlosstotal, ErpDecimalPlaces)
                ' GrossTotal = opvalue + purvalue + DIncomes - (salvalue + clvalue + DExpenses)
                GrossTotal = grossprofitlosstotal
                ISlOSS = True
            End If

        End If
       


        If TxtList.RowCount > TxtList1.RowCount Then
            For k As Integer = TxtList1.RowCount To TxtList.RowCount - 1
                RNO = TxtList1.Rows.Add
            Next
        ElseIf TxtList.RowCount < TxtList1.RowCount Then
            For k As Integer = TxtList.RowCount To TxtList1.RowCount - 1
                RNO = TxtList.Rows.Add
            Next

        End If
        RNO = TxtList1.Rows.Add
        RNO = TxtList.Rows.Add
        RNO = TxtList.Rows.Add
        Dim GTotal1 As Double = 0

        For i As Integer = 0 To TxtList.RowCount - 1
            Try
                GTotal1 = GTotal1 + CDbl(TxtList.Item("TLAmount", i).Value)
            Catch ex As Exception
            End Try
        Next

        TxtList.Item("TLDetails", RNO).Value = "               Gross Total :"
        TxtList.Item("TLAmount", RNO).Value = FormatNumber(GTotal1, ErpDecimalPlaces)
        TxtList.Item("ts1", RNO).Value = 1
        TxtList.Rows(RNO).DefaultCellStyle.BackColor = Color.WhiteSmoke
        TxtList.Rows(RNO).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
        RNO = TxtList1.Rows.Add
        TxtList1.Item("TRDetails", RNO).Value = "             Gross Total :"
        TxtList1.Item("TRAmount", RNO).Value = FormatNumber(GTotal1, ErpDecimalPlaces)
        TxtList1.Item("ts2", RNO).Value = 1
        TxtList1.Rows(RNO).DefaultCellStyle.BackColor = Color.WhiteSmoke
        TxtList1.Rows(RNO).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)

        'FOR INDIRECT EXPENSES AND INCOMES ROWS
        Dim IsNetLossrowno As Integer
        IsNetLossrowno = RNO
       
        Dim GrandTotal As Double = 0

        If ISlOSS = False Then
            'FOR PROFIT
            RNO = TxtList.Rows.Add 'INDEIRECT EXPENSES
            TxtList.Item("TLDetails", RNO).Value = AccountGroupNames.IndirectExpenses
            TxtList.Item("TLAmount", RNO).Value = FormatNumber(Expense, ErpDecimalPlaces)

            'DETAILED VIEW
            If ISDetailedView.Checked = True Then
                Dim SqlConn As New SqlClient.SqlConnection
                Dim Sqlcmmd As New SqlClient.SqlCommand
                Try
                    SqlConn.ConnectionString = ConnectionStrinG
                    SqlConn.Open()
                    Sqlcmmd.Connection = SqlConn
                    If IsDateWiseOn.Checked = True Then
                        Sqlcmmd.CommandText = "select ledgername, SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "')))  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  GROUP BY LEDGERNAME"
                    Else
                        Sqlcmmd.CommandText = "select ledgername, SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "')))    GROUP BY LEDGERNAME"
                    End If

                    Sqlcmmd.CommandType = CommandType.Text
                    Dim Sreader As SqlClient.SqlDataReader
                    Sreader = Sqlcmmd.ExecuteReader
                    While Sreader.Read()
                        RNO = TxtList.Rows.Add
                        TxtList.Item("TlDetails", RNO).Value = "  " & Sreader("ledgername").ToString.Trim
                        TxtList.Item("TLSubAmount", RNO).Value = FormatNumber(Sreader("tot"), ErpDecimalPlaces)
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

            RNO = TxtList1.Rows.Add 'GROSS PROFIT
            TxtList1.Item("TRDetails", RNO).Value = "Gross Profit b/f"
            TxtList1.Item("TRAmount", RNO).Value = FormatNumber(grossprofitlosstotal, ErpDecimalPlaces)


            RNO = TxtList1.Rows.Add 'INDIRECT INCOMES
            TxtList1.Item("TRDetails", RNO).Value = AccountGroupNames.IndirectIncomes
            TxtList1.Item("TRAmount", RNO).Value = FormatNumber(Incomes, ErpDecimalPlaces)

            'DETAILED VIEW
            If ISDetailedView.Checked = True Then
                Dim SqlConn As New SqlClient.SqlConnection
                Dim Sqlcmmd As New SqlClient.SqlCommand
                Try
                    SqlConn.ConnectionString = ConnectionStrinG
                    SqlConn.Open()
                    Sqlcmmd.Connection = SqlConn
                    If IsDateWiseOn.Checked = True Then
                        Sqlcmmd.CommandText = "select ledgername, SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectIncomes & "')))  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  GROUP BY LEDGERNAME"
                    Else
                        Sqlcmmd.CommandText = "select ledgername, SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectIncomes & "')))    GROUP BY LEDGERNAME"
                    End If

                    Sqlcmmd.CommandType = CommandType.Text
                    Dim Sreader As SqlClient.SqlDataReader
                    Sreader = Sqlcmmd.ExecuteReader
                    While Sreader.Read()
                        RNO = TxtList1.Rows.Add
                        TxtList1.Item("TRDetails", RNO).Value = "  " & Sreader("ledgername").ToString.Trim
                        TxtList1.Item("TRSubAmount", RNO).Value = FormatNumber(Sreader("tot"), ErpDecimalPlaces)
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
            If TxtList.RowCount > TxtList1.RowCount Then
                For k As Integer = TxtList1.RowCount To TxtList.RowCount - 1
                    RNO = TxtList1.Rows.Add
                Next
            ElseIf TxtList.RowCount < TxtList1.RowCount Then
                For k As Integer = TxtList.RowCount To TxtList1.RowCount - 1
                    RNO = TxtList.Rows.Add
                Next

            End If

            If grossprofitlosstotal + Incomes - Expense > 0 Then
                RNO = TxtList.Rows.Add 'INDIRECT INCOMES
                TxtList.Item("TLDetails", RNO).Value = "Nett Profit "
                TxtList.Item("TLAmount", RNO).Value = FormatNumber(grossprofitlosstotal + Incomes - Expense, ErpDecimalPlaces)


            Else
                RNO = TxtList1.Rows.Add 'INDIRECT INCOMES
                TxtList1.Item("TrDetails", RNO).Value = "Nett Loss "
                TxtList1.Item("TrAmount", RNO).Value = FormatNumber(Expense - (grossprofitlosstotal + Incomes), ErpDecimalPlaces)


            End If
           
            If TxtList.RowCount > TxtList1.RowCount Then
                For k As Integer = TxtList1.RowCount To TxtList.RowCount - 1
                    RNO = TxtList1.Rows.Add
                Next
            ElseIf TxtList.RowCount < TxtList1.RowCount Then
                For k As Integer = TxtList.RowCount To TxtList1.RowCount - 1
                    RNO = TxtList.Rows.Add
                Next

            End If
            'EMPTY ROWS
            RNO = TxtList.Rows.Add
            RNO = TxtList.Rows.Add
            RNO = TxtList.Rows.Add
            RNO = TxtList.Rows.Add
            RNO = TxtList1.Rows.Add
            RNO = TxtList1.Rows.Add
            RNO = TxtList1.Rows.Add
            RNO = TxtList1.Rows.Add
            GrandTotal = 0
            For rs As Integer = IsNetLossrowno + 1 To TxtList1.RowCount - 1
                Try
                    GrandTotal = GrandTotal + CDbl(TxtList1.Item("TrAmount", rs).Value)
                Catch ex As Exception

                End Try
            Next

            RNO = TxtList1.Rows.Add 'INDIRECT INCOMES
            TxtList1.Item("TRDetails", RNO).Value = "              Grand Total :"
            TxtList1.Item("TRAmount", RNO).Value = FormatNumber(GrandTotal, ErpDecimalPlaces)
            'TxtList1.Item("TRAmount", RNO).Value = grossprofitlosstotal + Incomes - Expense
            TxtList1.Item("ts2", RNO).Value = 1
            TxtList1.Rows(RNO).DefaultCellStyle.BackColor = Color.WhiteSmoke
            TxtList1.Rows(RNO).DefaultCellStyle.Font = New Font("Arial", 11, FontStyle.Bold)

            RNO = TxtList.Rows.Add 'INDIRECT INCOMES
            TxtList.Item("TLDetails", RNO).Value = "              Grand Total :"
            TxtList.Item("TLAmount", RNO).Value = FormatNumber(GrandTotal, ErpDecimalPlaces)
            'TxtList.Item("TLAmount", RNO).Value = grossprofitlosstotal + Incomes - Expense
            TxtList.Item("ts1", RNO).Value = 1
            TxtList.Rows(RNO).DefaultCellStyle.BackColor = Color.WhiteSmoke
            TxtList.Rows(RNO).DefaultCellStyle.Font = New Font("Arial", 11, FontStyle.Bold)

        Else

            'FOR LOSS

            RNO = TxtList.Rows.Add 'GROSS PROFIT
            TxtList.Item("TLDetails", RNO).Value = "Gross Loss b/f"
            TxtList.Item("TLAmount", RNO).Value = FormatNumber(grossprofitlosstotal, ErpDecimalPlaces)

            RNO = TxtList1.Rows.Add 'INDIRECT INCOMES
            TxtList1.Item("TRDetails", RNO).Value = AccountGroupNames.IndirectIncomes
            TxtList1.Item("TRAmount", RNO).Value = FormatNumber(Incomes, ErpDecimalPlaces)

            If ISDetailedView.Checked = True Then
                Dim SqlConn As New SqlClient.SqlConnection
                Dim Sqlcmmd As New SqlClient.SqlCommand
                Try
                    SqlConn.ConnectionString = ConnectionStrinG
                    SqlConn.Open()
                    Sqlcmmd.Connection = SqlConn
                    If IsDateWiseOn.Checked = True Then
                        Sqlcmmd.CommandText = "select ledgername, SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectIncomes & "')))  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  GROUP BY LEDGERNAME"
                    Else
                        Sqlcmmd.CommandText = "select ledgername, SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectIncomes & "')))    GROUP BY LEDGERNAME"
                    End If

                    Sqlcmmd.CommandType = CommandType.Text
                    Dim Sreader As SqlClient.SqlDataReader
                    Sreader = Sqlcmmd.ExecuteReader
                    While Sreader.Read()
                        RNO = TxtList1.Rows.Add
                        TxtList1.Item("TRDetails", RNO).Value = "  " & Sreader("ledgername").ToString.Trim
                        TxtList1.Item("TRSubAmount", RNO).Value = FormatNumber(Sreader("tot"), ErpDecimalPlaces)
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

            RNO = TxtList.Rows.Add 'INDEIRECT EXPENSES
            TxtList.Item("TLDetails", RNO).Value = AccountGroupNames.IndirectExpenses
            TxtList.Item("TLAmount", RNO).Value = FormatNumber(Expense, ErpDecimalPlaces)

            If ISDetailedView.Checked = True Then
                Dim SqlConn As New SqlClient.SqlConnection
                Dim Sqlcmmd As New SqlClient.SqlCommand
                Try
                    SqlConn.ConnectionString = ConnectionStrinG
                    SqlConn.Open()
                    Sqlcmmd.Connection = SqlConn
                    If IsDateWiseOn.Checked = True Then
                        Sqlcmmd.CommandText = "select ledgername, SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "')))  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  GROUP BY LEDGERNAME"
                    Else
                        Sqlcmmd.CommandText = "select ledgername, SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "')))    GROUP BY LEDGERNAME"
                    End If

                    Sqlcmmd.CommandType = CommandType.Text
                    Dim Sreader As SqlClient.SqlDataReader
                    Sreader = Sqlcmmd.ExecuteReader
                    While Sreader.Read()
                        RNO = TxtList.Rows.Add
                        TxtList.Item("TlDetails", RNO).Value = "  " & Sreader("ledgername").ToString.Trim
                        TxtList.Item("TLSubAmount", RNO).Value = FormatNumber(Sreader("tot"), ErpDecimalPlaces)
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

            If TxtList.RowCount > TxtList1.RowCount Then
                For k As Integer = TxtList1.RowCount To TxtList.RowCount - 1
                    RNO = TxtList1.Rows.Add
                Next
            ElseIf TxtList.RowCount < TxtList1.RowCount Then
                For k As Integer = TxtList.RowCount To TxtList1.RowCount - 1
                    RNO = TxtList.Rows.Add
                Next

            End If
            If grossprofitlosstotal + Expense - Incomes > 0 Then
                RNO = TxtList1.Rows.Add 'INDIRECT INCOMES
                TxtList1.Item("TRDetails", RNO).Value = "Nett Loss "
                TxtList1.Item("TRAmount", RNO).Value = FormatNumber(grossprofitlosstotal + Expense - Incomes, ErpDecimalPlaces)

            Else
                RNO = TxtList.Rows.Add 'INDIRECT INCOMES
                TxtList.Item("TlDetails", RNO).Value = "Nett Profit "
                TxtList.Item("TlAmount", RNO).Value = FormatNumber(Incomes - (grossprofitlosstotal + Expense), ErpDecimalPlaces)

            End If
          

            If TxtList.RowCount > TxtList1.RowCount Then
                For k As Integer = TxtList1.RowCount To TxtList.RowCount - 1
                    RNO = TxtList1.Rows.Add
                Next
            ElseIf TxtList.RowCount < TxtList1.RowCount Then
                For k As Integer = TxtList.RowCount To TxtList1.RowCount - 1
                    RNO = TxtList.Rows.Add
                Next

            End If
            'EMPTY ROWS
            RNO = TxtList.Rows.Add
            RNO = TxtList.Rows.Add
            RNO = TxtList.Rows.Add
            RNO = TxtList.Rows.Add
            RNO = TxtList1.Rows.Add
            RNO = TxtList1.Rows.Add
            RNO = TxtList1.Rows.Add
            RNO = TxtList1.Rows.Add
            GrandTotal = 0
            For rs As Integer = IsNetLossrowno + 1 To TxtList1.RowCount - 1
                Try
                    GrandTotal = GrandTotal + CDbl(TxtList1.Item("TrAmount", rs).Value)
                Catch ex As Exception

                End Try
            Next

            RNO = TxtList1.Rows.Add 'INDIRECT INCOMES
            TxtList1.Item("TRDetails", RNO).Value = "              Grand Total :"
            TxtList1.Item("TRAmount", RNO).Value = FormatNumber(GrandTotal, ErpDecimalPlaces)
           

            'TxtList1.Item("TRAmount", RNO).Value = grossprofitlosstotal + Expense - Incomes
            TxtList1.Item("ts2", RNO).Value = 1
            TxtList1.Rows(RNO).DefaultCellStyle.BackColor = Color.WhiteSmoke
            TxtList1.Rows(RNO).DefaultCellStyle.Font = New Font("Arial", 11, FontStyle.Bold)


            RNO = TxtList.Rows.Add 'INDIRECT INCOMES
            TxtList.Item("TLDetails", RNO).Value = "              Grand Total :"
            TxtList.Item("TLAmount", RNO).Value = FormatNumber(GrandTotal, ErpDecimalPlaces)
            'TxtList.Item("TLAmount", RNO).Value = grossprofitlosstotal + Expense - Incomes
            TxtList.Item("ts1", RNO).Value = 1
            TxtList.Rows(RNO).DefaultCellStyle.BackColor = Color.WhiteSmoke
            TxtList.Rows(RNO).DefaultCellStyle.Font = New Font("Arial", 11, FontStyle.Bold)

        End If

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

    Private Sub ProfitandLossForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub ProfitandLossForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        loaddata()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        loaddata()
    End Sub


    Sub loadFormforLiabilites()
        If TxtList1.SelectedRows.Count > 0 Then
            If SQLIsFieldExists("SELECT TOP 1 1 from   accountgroups where groupname=N'" & Trim(TxtList1.Item("TRDetails", TxtList.CurrentRow.Index).Value) & "'") = True Then

                Me.Cursor = Cursors.WaitCursor
                My.Application.DoEvents()
                If LedgersBalaceReportFrom Is Nothing OrElse LedgersBalaceReportFrom.IsDisposed Then
                    LedgersBalaceReportFrom = New LedgerBalanceSheetForm()
                    LedgersBalaceReportFrom.MdiParent = MainForm
                    LedgersBalaceReportFrom.BringToFront()
                    LedgerBalanceSheetForm.TxtHeading.Text = UCase(Trim(TxtList1.Item("TRDetails", TxtList1.CurrentRow.Index).Value)) & " REPORT"
                    LedgersBalaceReportFrom.TxtGroupName.Text = Trim(TxtList1.Item("TRDetails", TxtList.CurrentRow.Index).Value)
                    LedgersBalaceReportFrom.Dock = DockStyle.Fill
                    LedgersBalaceReportFrom.Show()
                    LedgerBalanceSheetForm.TxtHeading.Text = UCase(Trim(TxtList1.Item("TRDetails", TxtList1.CurrentRow.Index).Value)) & " REPORT"
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
    Sub LoadFormForAssets()
        If TxtList.SelectedRows.Count > 0 Then
            If SQLIsFieldExists("SELECT TOP 1 1 from   accountgroups where groupname=N'" & Trim(TxtList.Item("TLDetails", TxtList.CurrentRow.Index).Value) & "'") = True Then

                Me.Cursor = Cursors.WaitCursor
                My.Application.DoEvents()
                If LedgersBalaceReportFrom Is Nothing OrElse LedgersBalaceReportFrom.IsDisposed Then
                    LedgersBalaceReportFrom = New LedgerBalanceSheetForm()
                    LedgersBalaceReportFrom.MdiParent = MainForm
                    LedgersBalaceReportFrom.BringToFront()
                    LedgerBalanceSheetForm.TxtHeading.Text = UCase(Trim(TxtList.Item("TLDetails", TxtList1.CurrentRow.Index).Value)) & " REPORT"
                    LedgersBalaceReportFrom.TxtGroupName.Text = Trim(TxtList.Item("TLDetails", TxtList.CurrentRow.Index).Value)
                    LedgersBalaceReportFrom.Dock = DockStyle.Fill
                    LedgersBalaceReportFrom.Show()
                    LedgerBalanceSheetForm.TxtHeading.Text = UCase(Trim(TxtList.Item("TLDetails", TxtList1.CurrentRow.Index).Value)) & " REPORT"
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

    Private Sub TxtList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellDoubleClick
        LoadFormForAssets()
    End Sub

    Private Sub TxtList1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList1.CellDoubleClick
        loadFormforLiabilites()
    End Sub

    Private Sub TxtList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtList.KeyDown
        If e.KeyCode = Keys.Return Then
            LoadFormForAssets()
        End If
    End Sub

    Private Sub TxtList1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtList1.KeyDown
        If e.KeyCode = Keys.Return Then
            loadFormforLiabilites()
        End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New ProfitandLossDataset
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

        If ISDetailedView.Checked = True Then
            Dim objRpt As New ProfitandLossCrReport__Detailed
            SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
            If PrintOptionsforCR.IsPrintHeader = False Then
                CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
                CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
                CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text.Replace("&&", "&")
            Else
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text.Replace("&&", "&")

            End If
            'CType(objRpt.Section4.ReportObjects.Item("TXTTOTAL"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtNetTotal.Text

            objRpt.SetDataSource(ds)
            Dim FRM As New ReportCommonForm(objRpt)
            FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            Me.Cursor = Cursors.Default
            FRM.ShowDialog()
            FRM.Dispose()
            objRpt.Dispose()
            ds.Dispose()
        Else
            Dim objRpt As New ProfitandLossCrReport
            SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
            If PrintOptionsforCR.IsPrintHeader = False Then
                CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
                CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
                CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text.Replace("&&", "&")
            Else
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text.Replace("&&", "&")

            End If
            'CType(objRpt.Section4.ReportObjects.Item("TXTTOTAL"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtNetTotal.Text

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

    Private Sub ISDetailedView_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ISDetailedView.CheckedChanged
        loaddata()
    End Sub
End Class