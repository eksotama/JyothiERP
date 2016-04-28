Public Class AccountAnalysis
    'PLEASE DONT CHANGE THE GRIDVIEW  COLUMN NAME, IT WILL BE EFFECT IN DATASET FOR THE REPORTTS
    ' HERE IS THE CODE , DON'T CHANGE THE NAMES 
    ' SQLSTR="SELECT STOCKCODE AS [STOCK CODE] ....." DONT CHANGE THE [STOCK CODE]
    'SO, INSTEAD OF THE COLUMN NAME, PLEASE CHANGE THE HEADERTEXT PROPERTY OF THE GRID.
    ' YOU CAN CHANGE THE HEADERTEXT
    'FOR EXAMPLE
    ' TxtList.Columns("Item Code").HeaderText = "STOCK NAME(ANY TEXT)"

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Private Sub TxtList1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList1.DataError

    End Sub
    Sub loaddata()
        TxtList.SuspendLayout()
        TxtList1.SuspendLayout()
        TxtList.RowTemplate.Height = 25
        TxtList1.RowTemplate.Height = 25
        Dim SqlStr As String = ""
        Dim Rowno As Integer = 0
        Dim TotalDrValue As Double = 0
        Dim TotalCrValue As Double = 0
        Dim val As Double = 0
        Dim Val2 As Double = 0
        Dim Salesacval As Double = 0
        Dim Workingval As Double = 0
        Dim StockInHandVal As Double = 0
        Dim CurrentAssetsval As Double = 0
        Dim CurrentLaibilitiesval As Double = 0
        Dim NettProfitval As Double = 0
        Dim CapitalAccountVal As Double = 0
        Dim GrossProfitValue As Double = 0
        TxtList.Rows.Clear()
        Dim sTOCKvALUE As Double = 0
        sTOCKvALUE = SQLGetNumericFieldValue("select sum(stockrate*totalqty/unitcon) as tot from stockdbf WHERE STOCKTYPE=0", "tot")
        StockInHandVal = sTOCKvALUE

        'Working Capital (Current Asset - Liabilities)
        SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CurrentAssets & "')))"
        If IsDateWiseOn.Checked = True Then
            val = SQLGetNumericFieldValue("select sum(dr-CR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
        Else
            val = SQLGetNumericFieldValue("select sum(dr-CR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
        End If
        val = val + StockInHandVal
        CurrentAssetsval = val

        SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CurrentLiabilities & "')))"
        If IsDateWiseOn.Checked = True Then
            Val2 = SQLGetNumericFieldValue("select sum(cr-dR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
        Else
            Val2 = SQLGetNumericFieldValue("select sum(cr-dR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
        End If
        CurrentLaibilitiesval = Val2
        val = val - Val2
        Workingval = val
        Rowno = TxtList.Rows.Add()
        TxtList.Item("ts1", Rowno).Value = 1
        TxtList.Item("tadetails", Rowno).Value = "Working Capital" & Chr(13) & "(Current Asset - Liabilities)"
        TxtList.Item("tavalues", Rowno).Value = IIf(val >= 0, FormatNumber(val, ErpDecimalPlaces) & " Dr", FormatNumber(val * -1, ErpDecimalPlaces) & " Cr")
        TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
        TotalDrValue = val

        'END OF WORKING CAPITAL

        'CASH IN HAND
        SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "')))"
        If IsDateWiseOn.Checked = True Then
            Val2 = SQLGetNumericFieldValue("select sum(dr-cR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
        Else
            Val2 = SQLGetNumericFieldValue("select sum(dr-cR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
        End If


        Rowno = TxtList.Rows.Add()
        TxtList.Item("ts1", Rowno).Value = 1
        TxtList.Item("tadetails", Rowno).Value = "Cahs-in-Hand"
        TxtList.Item("tavalues", Rowno).Value = IIf(Val2 >= 0, FormatNumber(Val2, ErpDecimalPlaces) & " Dr", FormatNumber(Val2 * -1, ErpDecimalPlaces) & " Cr")
        TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
        'END OF CHSH IN HAND


        '" & AccountGroupNames.BankAccounts & "
        SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "')))"
        If IsDateWiseOn.Checked = True Then
            Val2 = SQLGetNumericFieldValue("select sum(dr-cR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
        Else
            Val2 = SQLGetNumericFieldValue("select sum(dr-cR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
        End If


        Rowno = TxtList.Rows.Add()
        TxtList.Item("ts1", Rowno).Value = 1
        TxtList.Item("tadetails", Rowno).Value = AccountGroupNames.BankAccounts
        TxtList.Item("tavalues", Rowno).Value = IIf(Val2 >= 0, FormatNumber(Val2, ErpDecimalPlaces) & " Dr", FormatNumber(Val2 * -1, ErpDecimalPlaces) & " Cr")
        TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
        'END OF BANK ACCOUNT"



        'bankod  accounts
        SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankOD & "')))"
        If IsDateWiseOn.Checked = True Then
            Val2 = SQLGetNumericFieldValue("select sum(dr-cR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
        Else
            Val2 = SQLGetNumericFieldValue("select sum(dr-cR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
        End If


        Rowno = TxtList.Rows.Add()
        TxtList.Item("ts1", Rowno).Value = 1
        TxtList.Item("tadetails", Rowno).Value = "Bank OD Accounts"
        TxtList.Item("tavalues", Rowno).Value = IIf(Val2 >= 0, FormatNumber(Val2, ErpDecimalPlaces) & " Dr", FormatNumber(Val2 * -1, ErpDecimalPlaces) & " Cr")
        TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
        'END OF OD BANK ACCOUNT"


        'SUNDRRY DEBTORS
        SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "')))"
        If IsDateWiseOn.Checked = True Then
            Val2 = SQLGetNumericFieldValue("select sum(dr-cR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
        Else
            Val2 = SQLGetNumericFieldValue("select sum(dr-cR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
        End If


        Rowno = TxtList.Rows.Add()
        TxtList.Item("ts1", Rowno).Value = 1
        TxtList.Item("tadetails", Rowno).Value = "Sundry Debtors"
        TxtList.Item("tavalues", Rowno).Value = IIf(Val2 >= 0, FormatNumber(Val2, ErpDecimalPlaces) & " Dr", FormatNumber(Val2 * -1, ErpDecimalPlaces) & " Cr")
        TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
        'END OF SUNDRRY DEBTORS

        ' SUNDRY CREDITORS
        SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "')))"
        If IsDateWiseOn.Checked = True Then
            Val2 = SQLGetNumericFieldValue("select sum(dR-cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
        Else
            Val2 = SQLGetNumericFieldValue("select sum(dr-cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
        End If


        Rowno = TxtList.Rows.Add()
        TxtList.Item("ts1", Rowno).Value = 1
        TxtList.Item("tadetails", Rowno).Value = "Sundry Creditors"
        TxtList.Item("tavalues", Rowno).Value = IIf(Val2 >= 0, FormatNumber(Val2, ErpDecimalPlaces) & " Dr", FormatNumber(Val2 * -1, ErpDecimalPlaces) & " Cr")
        TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
        'END OF SUNDRY CREDITORS


        ' SALES ACCOUNT
        SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')))"
        If IsDateWiseOn.Checked = True Then
            Val2 = SQLGetNumericFieldValue("select sum(cr-dR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
        Else
            Val2 = SQLGetNumericFieldValue("select sum(cr-dR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
        End If

        Salesacval = Val2
        Rowno = TxtList.Rows.Add()
        TxtList.Item("ts1", Rowno).Value = 1
        TxtList.Item("tadetails", Rowno).Value = AccountGroupNames.SalesAccounts
        TxtList.Item("tavalues", Rowno).Value = IIf(Val2 >= 0, FormatNumber(Val2, ErpDecimalPlaces) & " Dr", FormatNumber(Val2 * -1, ErpDecimalPlaces) & " Cr")
        TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
        'END OF SALES ACCOUNT


        ' PURCHASE  ACCOUNT
        SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')))"
        If IsDateWiseOn.Checked = True Then
            Val2 = SQLGetNumericFieldValue("select sum(dr-cR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
        Else
            Val2 = SQLGetNumericFieldValue("select sum(dr-cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
        End If


        Rowno = TxtList.Rows.Add()
        TxtList.Item("ts1", Rowno).Value = 1
        TxtList.Item("tadetails", Rowno).Value = AccountGroupNames.PurchaseAccounts
        TxtList.Item("tavalues", Rowno).Value = IIf(Val2 >= 0, FormatNumber(Val2, ErpDecimalPlaces) & " Dr", FormatNumber(Val2 * -1, ErpDecimalPlaces) & " Cr")
        TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
        'END OF purchase ACCOUNT


        'STOCK IN HAND

       
        Rowno = TxtList.Rows.Add()
        TxtList.Item("ts1", Rowno).Value = 1
        TxtList.Item("tadetails", Rowno).Value = "Stock-in-Hand"
        TxtList.Item("tavalues", Rowno).Value = IIf(sTOCKvALUE >= 0, FormatNumber(sTOCKvALUE, ErpDecimalPlaces) & " Dr", FormatNumber(sTOCKvALUE * -1, ErpDecimalPlaces) & " Cr")
        TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
        'STOCK IN HAND


        'PROFIT AND LOSS A/C

        If IsDateWiseOn.Checked = True Then
            Dim k2 As New CheckBox
            k2.Checked = True
            sTOCKvALUE = GetProfitLossAcValues(k2, TxtStartDate, TxtEndDate, GrossProfitValue)
            NettProfitval = sTOCKvALUE
        Else
            Dim k2 As New CheckBox
            k2.Checked = False
            Dim d As New DateTimePicker
            sTOCKvALUE = GetProfitLossAcValues(k2, d, d, GrossProfitValue)
            NettProfitval = sTOCKvALUE
        End If

        If sTOCKvALUE > 0 Then
            Rowno = TxtList.Rows.Add()
            TxtList.Item("ts1", Rowno).Value = 1
            TxtList.Item("tadetails", Rowno).Value = "Nett Profit"
            TxtList.Item("tavalues", Rowno).Value = FormatNumber(sTOCKvALUE, ErpDecimalPlaces) & " Cr"
            TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)

        Else
            Rowno = TxtList.Rows.Add()
            TxtList.Item("ts1", Rowno).Value = 1
            TxtList.Item("tadetails", Rowno).Value = "Nett Loss"
            TxtList.Item("tavalues", Rowno).Value = FormatNumber(sTOCKvALUE * -1, ErpDecimalPlaces) & " Dr"
            TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)

        End If

        'END OF PROFI AND LOSS A/C



        'Working Capital Turnover

        Rowno = TxtList.Rows.Add()
        TxtList.Item("ts1", Rowno).Value = 1
        TxtList.Item("tadetails", Rowno).Value = "Working Capital Turnover"
        TxtList.Item("tavalues", Rowno).Value = FormatNumber(Salesacval / Workingval, ErpDecimalPlaces)
        TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)


        'end of Working Capital turnover
        'Inventory Turnover
        Rowno = TxtList.Rows.Add()
        TxtList.Item("ts1", Rowno).Value = 1
        TxtList.Item("tadetails", Rowno).Value = "Inventory Turnover"
        If StockInHandVal = 0 Then
            TxtList.Item("tavalues", Rowno).Value = "0.000"
        Else
            TxtList.Item("tavalues", Rowno).Value = FormatNumber(Salesacval / StockInHandVal, ErpDecimalPlaces)
        End If

        TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)

        ' end of Inventory Turnover







        'RATIO PART
        TxtList1.Rows.Clear()

        'Current Ratio (Current Asset : Current Liabilities)

        Rowno = TxtList1.Rows.Add()
        TxtList1.Item("ts2", Rowno).Value = 1
        TxtList1.Item("tldetails", Rowno).Value = "Current Ratio "
        If CurrentLaibilitiesval = 0 Then
            TxtList1.Item("tlvalues", Rowno).Value = "0.000:1"
        Else
            Dim R As Double = 0
            Dim rstr As String = ""
            If CurrentAssetsval > CurrentLaibilitiesval Then
                R = CurrentLaibilitiesval / CurrentAssetsval
                R = 1 / R
                rstr = FormatNumber(R, ErpDecimalPlaces) & ":1"

            Else
                R = CurrentAssetsval / CurrentLaibilitiesval
                R = 1 / R
                rstr = "1:" & FormatNumber(R, ErpDecimalPlaces)
            End If
            TxtList1.Item("tlvalues", Rowno).Value = rstr

            'TxtList1.Item("tlvalues", Rowno).Value = FormatNumber(CurrentAssetsval / CurrentLaibilitiesval, 2).ToString & ":1"
        End If

        TxtList1.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)




        'Quick Ratio
        Rowno = TxtList1.Rows.Add()
        TxtList1.Item("ts2", Rowno).Value = 1
        TxtList1.Item("tldetails", Rowno).Value = "Quick Ratio"
        If CurrentLaibilitiesval = 0 Then
            TxtList1.Item("tlvalues", Rowno).Value = "0.000:1"
        Else
            Dim R As Double = 0
            Dim rstr As String = ""
            If (CurrentAssetsval - StockInHandVal) > CurrentLaibilitiesval Then
                R = CurrentLaibilitiesval / (CurrentAssetsval - StockInHandVal)
                R = 1 / R
                rstr = FormatNumber(R, ErpDecimalPlaces) & ":1"

            Else
                R = (CurrentAssetsval - StockInHandVal) / CurrentLaibilitiesval
                R = 1 / R
                rstr = "1:" & FormatNumber(R, ErpDecimalPlaces)
            End If
            TxtList1.Item("tlvalues", Rowno).Value = rstr
            'TxtList1.Item("tlvalues", Rowno).Value = FormatNumber((CurrentAssetsval - StockInHandVal) / CurrentLaibilitiesval, 2) & ":1"
        End If
        TxtList1.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)

        Dim LoanLiaVal As Double = 0
        SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.LoansAccountsLaibilities & "')))"
        If IsDateWiseOn.Checked = True Then
            LoanLiaVal = SQLGetNumericFieldValue("select sum(cr-dR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
        Else
            LoanLiaVal = SQLGetNumericFieldValue("select sum(cr-dr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
        End If

        SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'Capital Accounts')))"
        If IsDateWiseOn.Checked = True Then
            CapitalAccountVal = SQLGetNumericFieldValue("select sum(cr-dR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
        Else
            CapitalAccountVal = SQLGetNumericFieldValue("select sum(cr-dr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
        End If

        'Debt Ratio (Loans : Capital Account + Net Profit)
        Rowno = TxtList1.Rows.Add()
        TxtList1.Item("ts2", Rowno).Value = 1
        TxtList1.Item("tldetails", Rowno).Value = "Debt/Equity Ratio"
        If LoanLiaVal = 0 Then
            TxtList1.Item("tlvalues", Rowno).Value = "0.000:1"
        ElseIf CapitalAccountVal + NettProfitval = 0 Then
            TxtList1.Item("tlvalues", Rowno).Value = "0.000:1"
        Else

            Dim R As Double = 0
            Dim rstr As String = ""
            If LoanLiaVal > (CapitalAccountVal + NettProfitval) Then
                R = (CapitalAccountVal + NettProfitval) / LoanLiaVal
                R = 1 / R
                rstr = FormatNumber(R, ErpDecimalPlaces) & ":1"

            Else
                R = LoanLiaVal / (CapitalAccountVal + NettProfitval)
                R = 1 / R
                rstr = "1:" & FormatNumber(R, ErpDecimalPlaces)
            End If
            TxtList1.Item("tlvalues", Rowno).Value = rstr

            ' TxtList1.Item("tlvalues", Rowno).Value = FormatNumber(LoanLiaVal / (CapitalAccountVal + NettProfitval), 2) & ":1"
        End If
        TxtList1.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)



        Dim DirectIncomesVal As Double = 0
        Dim InDirectIncomesVal As Double = 0
        Dim TotalExpenesval As Double = 0

        SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where  groupname=N'" & AccountGroupNames.DirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectExpenses & "')))"
        If IsDateWiseOn.Checked = True Then
            TotalExpenesval = SQLGetNumericFieldValue("select sum(dr-cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
        Else
            TotalExpenesval = SQLGetNumericFieldValue("select sum(dr-cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
        End If

        SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where  groupname=N'" & AccountGroupNames.DirectIncomes & "')))"
        If IsDateWiseOn.Checked = True Then
            DirectIncomesVal = SQLGetNumericFieldValue("select sum(cr-dR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
        Else
            DirectIncomesVal = SQLGetNumericFieldValue("select sum(cr-dR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
        End If


        SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectIncomes & "')))"
        If IsDateWiseOn.Checked = True Then
            InDirectIncomesVal = SQLGetNumericFieldValue("select sum(cr-dR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr & "  and (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")", "tot")
        Else
            InDirectIncomesVal = SQLGetNumericFieldValue("select sum(cr-dR) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
        End If
        Rowno = TxtList1.Rows.Add()
        TxtList1.Item("ts2", Rowno).Value = 1
        TxtList1.Item("tldetails", Rowno).Value = "Gross Profit %"
        TxtList1.Item("tlvalues", Rowno).Value = FormatNumber(GrossProfitValue / (Salesacval + DirectIncomesVal) * 100, ErpDecimalPlaces) & " %"
        TxtList1.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)

        Rowno = TxtList1.Rows.Add()
        TxtList1.Item("ts2", Rowno).Value = 1
        TxtList1.Item("tldetails", Rowno).Value = "Nett Profit %"
        TxtList1.Item("tlvalues", Rowno).Value = FormatNumber(NettProfitval / (Salesacval + DirectIncomesVal + InDirectIncomesVal) * 100, ErpDecimalPlaces) & " %"
        TxtList1.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)


        'Operation Cost %
        Rowno = TxtList1.Rows.Add()
        TxtList1.Item("ts2", Rowno).Value = 1
        TxtList1.Item("tldetails", Rowno).Value = "Operation Cost %"
        If Salesacval = 0 Then
            TxtList1.Item("tlvalues", Rowno).Value = "0.00 %"
        Else
            TxtList1.Item("tlvalues", Rowno).Value = FormatNumber(TotalExpenesval / Salesacval * 100, ErpDecimalPlaces) & " %"
        End If
        TxtList1.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
        'Customer Payment Ratio (average received date of all invoices)

        'end of Customer Payment Ratio (average received date of all invoices)


        'Return on Investment (Net Profit / Capital A/c + Net profit)
        Rowno = TxtList1.Rows.Add()
        TxtList1.Item("ts2", Rowno).Value = 1
        TxtList1.Item("tldetails", Rowno).Value = "Return on Investment %"
        If CapitalAccountVal + NettProfitval = 0 Then
            TxtList1.Item("tlvalues", Rowno).Value = "0.00 %"
        Else
            TxtList1.Item("tlvalues", Rowno).Value = FormatNumber(NettProfitval / (CapitalAccountVal + NettProfitval) * 100, ErpDecimalPlaces) & " %"
        End If
        TxtList1.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)

        'end of Return on Investment (Net Profit / Capital A/c + Net profit)


        'Return on Working Capital (Net profit / working capital) x 100

        Rowno = TxtList1.Rows.Add()
        TxtList1.Item("ts2", Rowno).Value = 1
        TxtList1.Item("tldetails", Rowno).Value = "Return on Working Capital  %"
        If Workingval = 0 Then
            TxtList1.Item("tlvalues", Rowno).Value = "0.00 %"
        Else
            TxtList1.Item("tlvalues", Rowno).Value = FormatNumber(NettProfitval / Workingval * 100, ErpDecimalPlaces) & " %"
        End If
        TxtList1.Rows(Rowno).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
        Suprese0s()
        TxtList.ResumeLayout()
        TxtList1.ResumeLayout()
    End Sub
    Sub Suprese0s()
        If IsSupresszeros.Checked = False Then Exit Sub
        For i As Integer = 0 To TxtList.RowCount - 1
            If TxtList.Item("tavalues", i).Value = "0.00 %" Or TxtList.Item("tavalues", i).Value = "0.00%" Or TxtList.Item("tavalues", i).Value = "0.000" Or TxtList.Item("tavalues", i).Value = "0.000 Dr" Or TxtList.Item("tavalues", i).Value = "0.000 Cr" Then
                TxtList.Item("tavalues", i).Value = ""
            End If
        Next

        For i As Integer = 0 To TxtList1.RowCount - 1
            If TxtList1.Item("tlvalues", i).Value = "0.00 %" Or TxtList1.Item("tlvalues", i).Value = "0.00%" Or TxtList1.Item("tlvalues", i).Value = "0.000" Or TxtList1.Item("tlvalues", i).Value = "0.000 Dr" Or TxtList1.Item("tlvalues", i).Value = "0.000 Cr" Then
                TxtList1.Item("tlvalues", i).Value = ""
            End If
        Next
    End Sub

    Private Sub AccountAnalysis_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub BalanceSheet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load, RefreshToolStripMenuItem.Click

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
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

    Private Sub IsDetailedView_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsDetailedView.CheckedChanged, RefreshToolStripMenuItem.Click
        loaddata()
    End Sub


    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub IsSupresszeros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsSupresszeros.CheckedChanged
        Suprese0s()
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

        Dim objRpt As New RatioAnalysisCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
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