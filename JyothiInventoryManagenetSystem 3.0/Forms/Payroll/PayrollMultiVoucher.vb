Public Class PayrollMultiVoucher

    Dim IsAlterMode As Boolean = False
    Dim TransCode As Double = 0
    Dim IsSaved As Boolean = True
    Dim GrossTotalColName As String = "GROSSTOTAL"
    Dim NetSalaryColName As String = "NETSALARY"
    Dim PaySlipGenerateMethod As String = ""
    Private Sub BtnCal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCal.Click
        If TxtPayMethod.Text.Length = 0 Then
            MsgBox("Please select the pay method...", MsgBoxStyle.Information)
            TxtPayMethod.Focus()
            Exit Sub

        End If
        If SQLIsFieldExists("SELECT TOP 1 1 from   paytypes where PayName='Basic Salary' and PayTypeGroup=N'" & TxtPayMethod.Text & "'") = False Then
            MsgBox("The Additions and Deduction are not assigned to the selected pay method, Please try again...", MsgBoxStyle.Critical)
            Exit Sub

        End If
        If TxtList.RowCount > 0 Then
            If MsgBox("Do you want to Re Calculate ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        MainForm.Cursor = Cursors.WaitCursor
        PaySlipGenerateMethod = TxtPayMethod.Text
        CreateColumns()
        createemployeesrows()
        createpaymentledgers()
        FindPayHeadTotals()
        MainForm.Cursor = Cursors.Default
    End Sub
    Sub FindPayHeadTotals()
        Dim rno As Integer = 0
        rno = TxtList.Rows.Add
        TxtList.Item("empname", rno).Value = "TOTALS"
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
    Sub createpaymentledgers()
        TxtAccList.Rows.Clear()
        Dim rno As Integer = 0
        rno = TxtAccList.Rows.Add()
        TxtAccList.Item(0, rno).Value = SQLGetStringFieldValue("Select ledgername from paysliptypes where settingname=N'" & TxtPayMethod.Text & "'", "ledgername")
        TxtAccList.Item(1, rno).Value = CDbl(TxtNetPaybleTotal.Text)
        FindPaymentTotals()
    End Sub
    Sub createemployeesrows()
        Dim BasicSalary As Double = 0
        Dim SubTotal As Double = 0
        Dim NetTotal As Double = 0
        Dim Deducttotaol As Double = 0
        Dim GrandTotal As Double = 0
        Dim tempval As Double = 0
        Dim rno As Integer = 0
        Dim SqlConn3 As New SqlClient.SqlConnection
        Dim Sqlcmmd3 As New SqlClient.SqlCommand
        Try
            SqlConn3.ConnectionString = ConnectionStrinG
            SqlConn3.Open()
            Sqlcmmd3.Connection = SqlConn3
            Sqlcmmd3.CommandText = "SELECT empid, empname,basicsalary FROM Employees WHERE payslipmethod=N'" & TxtPayMethod.Text & "'"
            Sqlcmmd3.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd3.ExecuteReader
            While Sreader.Read()
                SubTotal = 0
                Deducttotaol = 0
                GrandTotal = 0
                BasicSalary = Sreader("basicsalary")
                SubTotal = BasicSalary
                rno = TxtList.Rows.Add
                TxtList.Item("empid", rno).Value = Sreader("empid").ToString
                TxtList.Item("empname", rno).Value = Sreader("empname").ToString
                TxtList.Item("Basic Salary", rno).Value = Sreader("basicsalary").ToString

                Dim SqlConn As New SqlClient.SqlConnection
                Dim Sqlcmmd As New SqlClient.SqlCommand
                Try
                    SqlConn.ConnectionString = ConnectionStrinG
                    SqlConn.Open()
                    Sqlcmmd.Connection = SqlConn
                    Sqlcmmd.CommandText = "SELECT * FROM PAYTYPES WHERE PayTypeGroup=N'" & TxtPayMethod.Text & "' AND PAYTYPE='Allowances' and payname<>'Basic Salary' ORDER BY orderno "
                    Sqlcmmd.CommandType = CommandType.Text
                    Dim Sreader2 As SqlClient.SqlDataReader
                    Sreader2 = Sqlcmmd.ExecuteReader
                    While Sreader2.Read()
                        If UCase(Sreader2("payname").ToString.Trim) = "OVER TIME" Then
                            Dim DATEFROMVALUE As New DateTimePicker
                            Dim DATETOVALUE As New DateTimePicker
                            Dim Ot As Double = 0
                            DATEFROMVALUE.Value = New Date(TxtSalaryMonth.Value.Year, TxtSalaryMonth.Value.Month, 1)
                            DATETOVALUE.Value = New Date(TxtSalaryMonth.Value.Year, TxtSalaryMonth.Value.Month, Date.DaysInMonth(TxtSalaryMonth.Value.Year, TxtSalaryMonth.Value.Month))
                            Ot = GetTotalempOT(Sreader("empname").ToString, DATEFROMVALUE, DATETOVALUE)
                            tempval = Ot * SQLGetNumericFieldValue("select rateperhour from employees where empname=N'" & Sreader("empname").ToString & "'", "rateperhour")
                            SubTotal = SubTotal + tempval
                        Else
                            If Sreader2("method").ToString = "On Basic" Or Sreader2("method").ToString = "On Gross" Then
                                tempval = BasicSalary * CDbl(Sreader2("per")) / 100
                                SubTotal = SubTotal + tempval
                            ElseIf Sreader2("method").ToString = "Fixed" Then
                                tempval = Sreader2("per")
                                SubTotal = SubTotal + tempval
                            ElseIf Sreader2("method").ToString = "On Total" Then
                                tempval = SubTotal * CDbl(Sreader2("per")) / 100
                                SubTotal = SubTotal + tempval
                            End If
                        End If
                       
                        TxtList.Item(Sreader2("payname").ToString.Trim, rno).Value = tempval
                    End While
                    Sreader2.Close()
                    Sreader2 = Nothing
                Catch ex As Exception

                Finally
                    Try
                        SqlConn.Close()
                        SqlConn.Dispose()
                        Sqlcmmd.Connection = Nothing
                    Catch ex3 As Exception

                    End Try
                End Try
                'end of allowances calculations
                GrandTotal = SubTotal
                TxtList.Item(GrossTotalColName, rno).Value = GrandTotal
                'for deductions 
                'for DEDUCTIONS
                Deducttotaol = 0
                Dim SqlConn1 As New SqlClient.SqlConnection
                Dim Sqlcmmd1 As New SqlClient.SqlCommand
                Try
                    SqlConn1.ConnectionString = ConnectionStrinG
                    SqlConn1.Open()
                    Sqlcmmd1.Connection = SqlConn1
                    Sqlcmmd1.CommandText = "SELECT * FROM PAYTYPES WHERE PayTypeGroup=N'" & TxtPayMethod.Text & "' AND PAYTYPE<>'Allowances' ORDER BY orderno "
                    Sqlcmmd1.CommandType = CommandType.Text
                    Dim Sreader3 As SqlClient.SqlDataReader
                    Sreader3 = Sqlcmmd1.ExecuteReader
                    While Sreader3.Read()
                        If UCase(Sreader3("payname").ToString.Trim) = "ABSENTS" Then
                            Dim DATEFROMVALUE As New DateTimePicker
                            Dim DATETOVALUE As New DateTimePicker
                            Dim totabs As Double = 0
                            DATEFROMVALUE.Value = New Date(TxtSalaryMonth.Value.Year, TxtSalaryMonth.Value.Month, 1)
                            DATETOVALUE.Value = New Date(TxtSalaryMonth.Value.Year, TxtSalaryMonth.Value.Month, Date.DaysInMonth(TxtSalaryMonth.Value.Year, TxtSalaryMonth.Value.Month))
                            totabs = Date.DaysInMonth(TxtSalaryMonth.Value.Year, TxtSalaryMonth.Value.Month) - (GetTotalemppaidLeaves(Sreader("empname").ToString, DATEFROMVALUE, DATETOVALUE) + GetTotalCompanyLeaves(DATEFROMVALUE, DATETOVALUE) + GetTotalempPresents(Sreader("empname").ToString, DATEFROMVALUE, DATETOVALUE) + GetTotalEmpearnedLeaves(Sreader("empname").ToString, DATEFROMVALUE, DATETOVALUE))
                            If IsLateinCountAsABSENTSInPayroll = True Then
                                totabs = totabs + GetTotalempLateInWorkingDays(Sreader("empname").ToString, DATEFROMVALUE, DATETOVALUE)
                            End If
                            If Sreader3("method").ToString = "On Gross" Then
                                tempval = totabs * GrandTotal / Date.DaysInMonth(TxtSalaryMonth.Value.Year, TxtSalaryMonth.Value.Month)
                            Else
                                If totabs > 0 Then
                                    tempval = totabs * SQLGetNumericFieldValue("select basicsalary from employees where empname=N'" & Sreader("empname").ToString & "'", "basicsalary") / Date.DaysInMonth(TxtSalaryMonth.Value.Year, TxtSalaryMonth.Value.Month)
                                Else
                                    tempval = 0
                                End If

                            End If
                           

                            SubTotal = SubTotal + tempval
                            Deducttotaol = Deducttotaol + tempval
                        Else
                            If Sreader3("method").ToString = "On Basic" Or Sreader3("method").ToString = "On Gross" Then
                                tempval = GrandTotal * CDbl(Sreader3("per")) / 100
                                SubTotal = SubTotal + tempval
                                Deducttotaol = Deducttotaol + tempval
                            ElseIf Sreader3("method").ToString = "Fixed" Then
                                tempval = Sreader3("per")
                                SubTotal = SubTotal + tempval
                                Deducttotaol = Deducttotaol + tempval
                            ElseIf Sreader3("method").ToString = "On Total" Then
                                tempval = SubTotal * CDbl(Sreader3("per")) / 100
                                SubTotal = SubTotal + tempval
                                Deducttotaol = Deducttotaol + tempval
                            End If
                        End If
                       
                        TxtList.Item(Sreader3("payname").ToString.Trim, rno).Value = tempval
                    End While
                    Sreader3.Close()
                    Sreader3 = Nothing
                Catch ex As Exception

                Finally
                    Try
                        SqlConn1.Close()
                        SqlConn1.Dispose()
                        Sqlcmmd1.Connection = Nothing
                    Catch ex3 As Exception

                    End Try
                End Try
                TxtList.Item(NetSalaryColName, rno).Value = GrandTotal - Deducttotaol
                NetTotal = NetTotal + (GrandTotal - Deducttotaol)

                'endof deduction calucaltions
                TxtNetPaybleTotal.Text = FormatNumber(NetTotal, ErpDecimalPlaces)
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception

        Finally
            Try
                SqlConn3.Close()
                SqlConn3.Dispose()
                Sqlcmmd3.Connection = Nothing
            Catch ex3 As Exception

            End Try
        End Try
    End Sub
    Sub CreateColumns()

        TxtList.Rows.Clear()
        TxtList.Columns.Clear()
        TxtList.Columns.Add("empid", "EMP ID")
        TxtList.Columns("empid").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        TxtList.Columns("empid").Width = 80

        TxtList.Columns.Add("empname", "Employee Name")

        TxtList.Columns("empname").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        TxtList.Columns("empname").Width = 85
        ' TxtList.Columns.Add("basicsalary", "Basic Salary")
        'PayTypes
        ' FOR ADDITIONS
        TxtpayHeadLedgerList.Rows.Clear()
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = "SELECT * FROM PAYTYPES WHERE PayTypeGroup=N'" & TxtPayMethod.Text & "' AND PAYTYPE='Allowances' ORDER BY orderno "
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()
                TxtList.Columns.Add(Sreader("PAYNAME").ToString.Trim, Sreader("PAYNAME").ToString.Trim)
                TxtList.Columns(Sreader("PAYNAME").ToString.Trim).DefaultCellStyle.Format = "N" & ErpDecimalPlaces
                TxtList.Columns(Sreader("PAYNAME").ToString.Trim).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                TxtList.Columns(Sreader("PAYNAME").ToString.Trim).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                TxtList.Columns(Sreader("PAYNAME").ToString.Trim).Width = 85
                Dim rno As Integer = 0
                rno = TxtpayHeadLedgerList.Rows.Add
                TxtpayHeadLedgerList.Item("tpayname", rno).Value = Sreader("payname").ToString.Trim
                TxtpayHeadLedgerList.Item("tledgername", rno).Value = Sreader("ledgername").ToString.Trim

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception

        Finally
            Try
                SqlConn.Close()
                SqlConn.Dispose()
                Sqlcmmd.Connection = Nothing
            Catch ex3 As Exception

            End Try
        End Try
        TxtList.Columns.Add(GrossTotalColName, "GROSS TOTAL")
        TxtList.Columns(GrossTotalColName).DefaultCellStyle.Format = "N" & ErpDecimalPlaces
        TxtList.Columns(GrossTotalColName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        TxtList.Columns(GrossTotalColName).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        TxtList.Columns(GrossTotalColName).Width = 120
        TxtList.Columns(GrossTotalColName).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
        TxtList.Columns(GrossTotalColName).DefaultCellStyle.ForeColor = Color.Green

        'for DEDUCTIONS
        Dim SqlConn1 As New SqlClient.SqlConnection
        Dim Sqlcmmd1 As New SqlClient.SqlCommand
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Sqlcmmd1.Connection = SqlConn1
            Sqlcmmd1.CommandText = "SELECT * FROM PAYTYPES WHERE PayTypeGroup=N'" & TxtPayMethod.Text & "' AND PAYTYPE<>'Allowances' ORDER BY orderno "
            Sqlcmmd1.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd1.ExecuteReader
            While Sreader.Read()
                TxtList.Columns.Add(Sreader("PAYNAME").ToString.Trim, Sreader("PAYNAME").ToString.Trim)
                TxtList.Columns(Sreader("PAYNAME").ToString.Trim).DefaultCellStyle.Format = "N" & ErpDecimalPlaces
                TxtList.Columns(Sreader("PAYNAME").ToString.Trim).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                TxtList.Columns(Sreader("PAYNAME").ToString.Trim).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                TxtList.Columns(Sreader("PAYNAME").ToString.Trim).Width = 85
                Dim rno As Integer = 0
                rno = TxtpayHeadLedgerList.Rows.Add
                TxtpayHeadLedgerList.Item("tpayname", rno).Value = Sreader("payname").ToString.Trim
                TxtpayHeadLedgerList.Item("tledgername", rno).Value = Sreader("ledgername").ToString.Trim
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception

        Finally
            Try
                SqlConn1.Close()
                SqlConn1.Dispose()
                Sqlcmmd1.Connection = Nothing
            Catch ex3 As Exception

            End Try
        End Try
        TxtList.Columns.Add(NetSalaryColName, "NET SALARY")
        TxtList.Columns(NetSalaryColName).DefaultCellStyle.Format = "N" & ErpDecimalPlaces
        TxtList.Columns(NetSalaryColName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        TxtList.Columns(NetSalaryColName).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        TxtList.Columns(NetSalaryColName).Width = 100
        TxtList.Columns(NetSalaryColName).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
        TxtList.Columns(NetSalaryColName).DefaultCellStyle.ForeColor = Color.Green



        If TxtList.Columns.Count > 13 Then
            TxtList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        Else
            TxtList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If

    End Sub

    Private Sub PayrollMultiVoucher_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub PayrollMultiVoucher_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("Select settingname from paysliptypes", TxtPayMethod, "settingname")
        LoadDataIntoComboBox("select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankOD & "')) ", TxtLedger, "ledgername")

    End Sub
    Sub loaddefs()
        TxtAccList.Rows.Clear()

        TxtList.Rows.Clear()
        TxtpayHeadLedgerList.Rows.Clear()
        TxtList.Columns.Clear()
        txtvoucherno.Text = GetInvVhNumber(InvoiceNoStrct.Payroll)
        TxtVoucherDate.Value = Today
        TxtSalaryMonth.Value = Today
        TxtNetPaybleTotal.Text = "0"
        TxtpayAmount.Text = "0"
        TxtPayMethod.Text = ""
        IsSaved = True
        TxtNetPaybleTotal.Text = "0"
        IsAlterMode = False
    End Sub
    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If IsSaved = False Then
            If MsgBox("Current Voucher is not saved, Do you want to Close ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        Me.Close()
    End Sub

    Private Sub btnAddPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPay.Click
        If TxtLedger.Text.Length = 0 Then
            MsgBox("Select the Payment Ledger Account Name ", MsgBoxStyle.Information)
            TxtLedger.Focus()
            Exit Sub
        End If
        If CDbl(TxtpayAmount.TabIndex) <= 0 Then
            MsgBox("Please Enter the Allocate Amount ...", MsgBoxStyle.Information)
            TxtpayAmount.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to Add ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim rno As Integer = 0
            rno = TxtAccList.Rows.Add
            TxtAccList.Item(0, rno).Value = TxtLedger.Text
            TxtAccList.Item(1, rno).Value = TxtpayAmount.Text
            FindPaymentTotals()
        End If

    End Sub

    Private Sub TxtAccList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtAccList.CellContentClick

    End Sub
    Sub FindPaymentTotals()
        Dim tot As Double = 0
        For i As Integer = 0 To TxtAccList.Rows.Count - 1
            tot = tot + CDbl(TxtAccList.Item(1, i).Value)
        Next
        TxtTotalAllocationAmount.Text = FormatNumber(tot, ErpDecimalPlaces)
    End Sub

    Private Sub TxtAccList_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtAccList.CellEndEdit
        FindPaymentTotals()
    End Sub

    Private Sub TxtAccList_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles TxtAccList.CellValidating
        If e.ColumnIndex = 1 Then
            If IsNumeric(e.FormattedValue) = False Then
                e.Cancel = True
            Else
                e.Cancel = False
            End If

        End If
    End Sub

    Private Sub TxtAccList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtAccList.DataError

    End Sub

    Private Sub TxtAccList_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles TxtAccList.RowsAdded
        FindPaymentTotals()
    End Sub

    Private Sub TxtAccList_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles TxtAccList.RowsRemoved
        FindPaymentTotals()
    End Sub

    Private Sub TxtList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub


    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        CHECKBEFORESAVE()
    End Sub
    Sub CHECKBEFORESAVE()

        If CDbl(TxtTotalAllocationAmount.Text) = 0 Then
            MsgBox("Please Generate the employee pay slip details....")
            TxtPayMethod.Focus()
            TabControl1.SelectedIndex = 0
            Exit Sub
        End If
        If CDbl(TxtTotalAllocationAmount.Text) = 0 Then
            MsgBox("Please Select the Payment Account Ledger Name....", MsgBoxStyle.Information)
            TabControl1.SelectedIndex = 1
            Exit Sub
        End If
        If CDbl(TxtNetPaybleTotal.Text) <> CDbl(TxtTotalAllocationAmount.Text) Then
            MsgBox("The Allocate Amount is not match to generated Amount...")
            Exit Sub
        End If

        If MsgBox("Do you want to Save ?            ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            SaveData()
            loaddefs()
        End If

    End Sub
    Sub SaveData()
        If IMSBEGINTRANSACTION() = False Then
            IMSENDTRANSACTION()
            Exit Sub
        End If
        Dim SQLstr As String = ""
        If IsAlterMode = True Then
            ExecuteSQLQuery("DELETE FROM payrollVoucherMasterData WHERE TRANSCODE=" & TransCode)
            ExecuteSQLQuery("DELETE FROM payrollvoucherRowDetails WHERE TRANSCODE=" & TransCode)
            ExecuteSQLQuery("DELETE FROM PayRollVoucherPayMaster WHERE TRANSCODE=" & TransCode)
            ExecuteSQLQuery("DELETE FROM payrollvoucherLedgers WHERE TRANSCODE=" & TransCode)
            ExecuteSQLQuery("DELETE FROM LedgerBook WHERE TRANSCODE=" & TransCode)

        Else
            txtvoucherno.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.Payroll)
            TransCode = GetAndSetIDCode(EnumIDType.TransCode)
        End If
        Dim SqlQueryString As String = ""
        For i As Integer = 2 To TxtList.Columns.Count - 1
            If SqlQueryString.Length = 0 Then
                SqlQueryString = "[" & TxtList.Columns(i).Name & "]"
            Else
                SqlQueryString = SqlQueryString & "," & "[" & TxtList.Columns(i).Name & "]"
            End If
        Next

        'STORE MASTER DETAILS
        SQLstr = "INSERT INTO [payrollVoucherMasterData] ([transcode],[Transdate],[Transdatevalue],[VoucherNo],[VoucherRef],[PayDate],[PayDateValue],[NetTotal],[CashTotal],[BankTotal],[paymethod],[narration],[sqlstr])     VALUES " _
            & " (@transcode,@Transdate,@Transdatevalue,@VoucherNo,@VoucherRef,@PayDate,@PayDateValue,@NetTotal,@CashTotal,@BankTotal,@paymethod,@narration,@sqlstr) "


        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBFR = New SqlClient.SqlCommand(SQLstr, MAINCON)
        With DBFR.Parameters
            .AddWithValue("transcode", TransCode)
            .AddWithValue("Transdate", TxtVoucherDate.Value)
            .AddWithValue("Transdatevalue", TxtVoucherDate.Value.Date.ToOADate)
            .AddWithValue("VoucherNo", txtvoucherno.Text)
            .AddWithValue("VoucherRef", txtvoucherno.Text)
            .AddWithValue("PayDate", TxtSalaryMonth.Value)
            .AddWithValue("PayDateValue", TxtSalaryMonth.Value.ToOADate)
            .AddWithValue("NetTotal", CDbl(TxtTotalAllocationAmount.Text))
            .AddWithValue("CashTotal", 0)
            .AddWithValue("BankTotal", 0)
            .AddWithValue("paymethod", TxtPayMethod.Text)
            .AddWithValue("narration", txtnarration.text)
            .AddWithValue("sqlstr", SqlQueryString)
        End With
        DBFR.ExecuteNonQuery()
        DBFR = Nothing
        MAINCON.Close()


        'SAVE EMPLOYEE DETAILS
        Dim isdeductions As Boolean = False
        For i As Integer = 0 To TxtList.RowCount - 2
            isdeductions = False
            For cl As Integer = 2 To TxtList.Columns.Count - 1
                SQLstr = "INSERT INTO [payrollvoucherRowDetails] ([transcode],[EmpName],[PayName],[OrderNo],[amount],[EmpID],[type],[AttendenceDetails])     VALUES  " _
      & " (@transcode,@EmpName,@PayName,@OrderNo,@amount,@EmpID,@type,@AttendenceDetails) "

                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim DBFR3 = New SqlClient.SqlCommand(SQLstr, MAINCON)
                With DBFR3.Parameters
                    .AddWithValue("transcode", TransCode)
                    .AddWithValue("EmpName", TxtList.Item("empname", i).Value)
                    .AddWithValue("PayName", TxtList.Columns(cl).Name)
                    .AddWithValue("OrderNo", cl)
                    .AddWithValue("amount", CDbl(TxtList.Item(cl, i).Value))
                    .AddWithValue("EmpID", TxtList.Item("empid", i).Value)
                    .AddWithValue("AttendenceDetails", "")
                    'AttendenceDetails
                    'TO IDENTIY THE ADDITIONS AND DEDUCTIONS
                    If TxtList.Columns(cl).Name = GrossTotalColName Then
                        .AddWithValue("type", 12)
                        isdeductions = True
                    ElseIf TxtList.Columns(cl).Name = NetSalaryColName Then
                        .AddWithValue("type", 21)
                    Else
                        If isdeductions = True Then
                            .AddWithValue("type", 2)
                        Else
                            .AddWithValue("type", 1)
                        End If

                    End If

                End With
                DBFR3.ExecuteNonQuery()
                DBFR3 = Nothing
                MAINCON.Close()
            Next


        Next

        'TO SAVE PAYMENT DETAILS
        For i As Integer = 0 To TxtAccList.RowCount - 1
            SQLstr = "INSERT INTO [PayRollVoucherPayMaster]([transcode],[LedgerName],[Amount])     VALUES " _
    & " (@transcode,@LedgerName,@Amount) "
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBFR4 = New SqlClient.SqlCommand(SQLstr, MAINCON)
            With DBFR4.Parameters
                .AddWithValue("transcode", TransCode)
                .AddWithValue("LedgerName", TxtAccList.Item(0, i).Value)
                .AddWithValue("Amount", CDbl(TxtAccList.Item(1, i).Value))
            End With
            DBFR4.ExecuteNonQuery()
            DBFR4 = Nothing
            MAINCON.Close()
        Next


        'TO SAVE PAYHEAD LEDGERS DETAILS
        For i As Integer = 0 To TxtpayHeadLedgerList.RowCount - 1
            SQLstr = " INSERT INTO [payrollvoucherLedgers] ([PAYNAME],[ledgername],[Transcode])     VALUES " _
    & " (@PAYNAME,@ledgername,@Transcode) "
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBFR4 = New SqlClient.SqlCommand(SQLstr, MAINCON)
            With DBFR4.Parameters
                .AddWithValue("transcode", TransCode)
                .AddWithValue("PAYNAME", TxtpayHeadLedgerList.Item(0, i).Value)
                .AddWithValue("LedgerName", TxtpayHeadLedgerList.Item(1, i).Value)
            End With
            DBFR4.ExecuteNonQuery()
            DBFR4 = Nothing
            MAINCON.Close()
        Next
        'payrollvoucherLedgers

        'SAVE LEDGERS DATA FOR ALL INFORMATIONS
        'SAVE DR AMOOUNT TO LEDGERS ACCOUNTS UNTILT GrossTotalColName
        Dim cOLCOUNT As Integer = 2
        Dim sno As Integer = 1
        For I As Integer = 2 To TxtList.Columns.Count - 2
            cOLCOUNT = I
            If TxtList.Columns(I).Name = GrossTotalColName Then
                cOLCOUNT = cOLCOUNT + 1
                Exit For
            End If
            SQLstr = "INSERT INTO [LedgerBook] ([LedgerName],[TransCode],[InvoiceNo],[InvoiceName],[sno],[Dr],[Cr],[TransDate], " _
           & "[TransDateValue],[LedgerGroup],[AcLedger],[IsAdvance],[IsDeleted],[UserName],[StoreName],[Narration],[InvoiceType],[RefNo],[CurrencyCode],[ConRate]) " _
           & " VALUES (@LedgerName,@TransCode,@InvoiceNo,@InvoiceName,@sno,@Dr,@Cr,@TransDate,@TransDateValue,@LedgerGroup, " _
           & "@AcLedger,@IsAdvance,@IsDeleted,@UserName,@StoreName,@Narration,@InvoiceType,@RefNo,@CurrencyCode,@ConRate) "

            'GetPayHeadLedgerName
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBFR5 As SqlClient.SqlCommand
            DBFR5 = New SqlClient.SqlCommand(SQLstr, MAINCON)
            With DBFR5.Parameters
                .AddWithValue("LedgerName", GetPayHeadLedgerName(TxtList.Columns(I).Name))
                .AddWithValue("TransCode", TransCode)
                .AddWithValue("InvoiceNo", txtvoucherno.Text)
                .AddWithValue("InvoiceName", "Payroll")
                .AddWithValue("InvoiceType", "Payroll")
                .AddWithValue("sno", sno)
                sno = sno + 1
                ' MsgBox(CDbl(TxtList.Item(TxtList.Columns(I).Name, TxtList.Rows.Count - 1).Value))
                .AddWithValue("Dr", CDbl(TxtList.Item(TxtList.Columns(I).Name, TxtList.Rows.Count - 1).Value))

                .AddWithValue("Cr", 0)

                .AddWithValue("TransDate", TxtVoucherDate.Value)
                .AddWithValue("TransDateValue", TxtVoucherDate.Value.Date.ToOADate)
                .AddWithValue("LedgerGroup", "")
                .AddWithValue("CurrencyCode", CompDetails.Currency)

                .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & GetPayHeadLedgerName(TxtList.Columns(I).Name) & "'", "currency").ToString))
                .AddWithValue("AcLedger", TxtAccList.Item(0, 0).Value)
                .AddWithValue("IsAdvance", 1)
                .AddWithValue("IsDeleted", 0)
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Narration", txtnarration.Text)
                .AddWithValue("RefNo", txtvoucherno.Text)
            End With
            DBFR5.ExecuteNonQuery()
            DBFR5 = Nothing
            MAINCON.Close()
        Next


        'SAVE DR AMOOUNT TO LEDGERS ACCOUNTS UNTILT NetSalaryColName

        For I As Integer = cOLCOUNT To TxtList.Columns.Count - 2

            If TxtList.Columns(I).Name = NetSalaryColName Then
                Exit For
            End If
            SQLstr = "INSERT INTO [LedgerBook] ([LedgerName],[TransCode],[InvoiceNo],[InvoiceName],[sno],[Dr],[Cr],[TransDate], " _
           & "[TransDateValue],[LedgerGroup],[AcLedger],[IsAdvance],[IsDeleted],[UserName],[StoreName],[Narration],[InvoiceType],[RefNo],[CurrencyCode],[ConRate]) " _
           & " VALUES (@LedgerName,@TransCode,@InvoiceNo,@InvoiceName,@sno,@Dr,@Cr,@TransDate,@TransDateValue,@LedgerGroup, " _
           & "@AcLedger,@IsAdvance,@IsDeleted,@UserName,@StoreName,@Narration,@InvoiceType,@RefNo,@CurrencyCode,@ConRate) "
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            'GetPayHeadLedgerName

            Dim DBFR5 As SqlClient.SqlCommand
            DBFR5 = New SqlClient.SqlCommand(SQLstr, MAINCON)
            With DBFR5.Parameters
                .AddWithValue("LedgerName", GetPayHeadLedgerName(TxtList.Columns(I).Name))
                .AddWithValue("TransCode", TransCode)
                .AddWithValue("InvoiceNo", txtvoucherno.Text)
                .AddWithValue("InvoiceName", "Payroll")
                .AddWithValue("InvoiceType", "Payroll")
                .AddWithValue("sno", sno)
                sno = sno + 1
                ' MsgBox(CDbl(TxtList.Item(TxtList.Columns(I).Name, TxtList.Rows.Count - 1).Value))
                .AddWithValue("Dr", 0)

                .AddWithValue("Cr", CDbl(TxtList.Item(TxtList.Columns(I).Name, TxtList.Rows.Count - 1).Value))

                .AddWithValue("TransDate", TxtVoucherDate.Value)
                .AddWithValue("TransDateValue", TxtVoucherDate.Value.Date.ToOADate)
                .AddWithValue("LedgerGroup", "")
                .AddWithValue("CurrencyCode", CompDetails.Currency)
                .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & GetPayHeadLedgerName(TxtList.Columns(I).Name) & "'", "currency").ToString))
                .AddWithValue("AcLedger", TxtAccList.Item(0, 0).Value)
                .AddWithValue("IsAdvance", 1)
                .AddWithValue("IsDeleted", 0)
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Narration", txtnarration.Text)
                .AddWithValue("RefNo", txtvoucherno.Text)
            End With
            DBFR5.ExecuteNonQuery()
            DBFR5 = Nothing
            MAINCON.Close()
        Next

        ' PAYMENT LEDGER ACCOUNTS (CAHS OR BANKS)

        For I As Integer = 0 To TxtAccList.RowCount - 1


            SQLstr = "INSERT INTO [LedgerBook] ([LedgerName],[TransCode],[InvoiceNo],[InvoiceName],[sno],[Dr],[Cr],[TransDate], " _
           & "[TransDateValue],[LedgerGroup],[AcLedger],[IsAdvance],[IsDeleted],[UserName],[StoreName],[Narration],[InvoiceType],[RefNo],[CurrencyCode],[ConRate]) " _
           & " VALUES (@LedgerName,@TransCode,@InvoiceNo,@InvoiceName,@sno,@Dr,@Cr,@TransDate,@TransDateValue,@LedgerGroup, " _
           & "@AcLedger,@IsAdvance,@IsDeleted,@UserName,@StoreName,@Narration,@InvoiceType,@RefNo,@CurrencyCode,@ConRate) "

            'GetPayHeadLedgerName
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBFR5 As SqlClient.SqlCommand
            DBFR5 = New SqlClient.SqlCommand(SQLstr, MAINCON)
            With DBFR5.Parameters
                .AddWithValue("LedgerName", TxtAccList.Item("TLNAME", I).Value)
                .AddWithValue("TransCode", TransCode)
                .AddWithValue("InvoiceNo", txtvoucherno.Text)
                .AddWithValue("InvoiceName", "Payroll")
                .AddWithValue("InvoiceType", "Payroll")
                .AddWithValue("sno", sno)
                sno = sno + 1
                .AddWithValue("Dr", 0)
                .AddWithValue("Cr", CDbl(TxtAccList.Item("TAMT", I).Value))
                '  MsgBox(CDbl(TxtAccList.Item("TAMT", I).Value))
                .AddWithValue("TransDate", TxtVoucherDate.Value)
                .AddWithValue("TransDateValue", TxtVoucherDate.Value.Date.ToOADate)
                .AddWithValue("LedgerGroup", "")
                .AddWithValue("CurrencyCode", CompDetails.Currency)
                .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TxtAccList.Item("TLNAME", I).Value & "'", "currency").ToString))
                .AddWithValue("AcLedger", TxtpayHeadLedgerList.Item(1, 0).Value)
                .AddWithValue("IsAdvance", 1)
                .AddWithValue("IsDeleted", 0)
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Narration", txtnarration.Text)
                .AddWithValue("RefNo", txtvoucherno.Text)
            End With
            DBFR5.ExecuteNonQuery()
            DBFR5 = Nothing
            MAINCON.Close()
        Next

        IMSENDTRANSACTION()
    End Sub
    Function GetPayHeadLedgerName(ByVal payname As String) As String
        Dim str As String = ""
        For i As Integer = 0 To TxtpayHeadLedgerList.Rows.Count - 1
            If TxtpayHeadLedgerList.Item(0, i).Value = payname Then
                str = TxtpayHeadLedgerList.Item(1, i).Value
                Exit For
            End If
        Next
        Return str
    End Function
    Function GetPayHeadTotalAmount(ByVal payname As String) As Double
        Dim str As Double = 0
        str = CDbl(TxtList.Item(payname, TxtList.Rows.Count - 1).Value)

        Return str
    End Function
    Private Sub TxtList_SortCompare(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles TxtList.SortCompare
        If e.RowIndex1 = TxtList.RowCount - 1 Then e.Handled = True
        If e.RowIndex2 = TxtList.RowCount - 1 Then e.Handled = True
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnoPEN.Click
        If IsSaved = False Then
            If MsgBox("Current Voucher is not saved, Do you want to Open ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        OpendedPayRollTransCode = 0
        Dim kfrm As New SelectPayRollVoucher
        kfrm.ShowDialog()
        kfrm.Dispose()
        If OpendedPayRollTransCode > 0 Then
            OpenbyTransCode(OpendedPayRollTransCode)
        End If
    End Sub
    Sub OpenbyTransCode(ByVal tcode As Double)
        loaddefs()
        TransCode = tcode
        'load master data
        Dim SqlStr As String = ""





        '

        TxtAccList.Rows.Clear()
        Dim SqlConn2 As New SqlClient.SqlConnection
        Try
            SqlConn2.ConnectionString = ConnectionStrinG
            SqlConn2.Open()
            SQLFcmd.Connection = SqlConn2
            SQLFcmd.CommandText = "SELECT * FROM PayRollVoucherPayMaster WHERE TRANSCODE=" & TransCode
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            Dim rno As Integer = 0
            While Sreader.Read()
                rno = TxtAccList.Rows.Add
                TxtAccList.Item(0, rno).Value = Sreader("LedgerName")
                TxtAccList.Item(1, rno).Value = Sreader("Amount")
            End While
        Catch ex As Exception
        Finally
            SqlConn2.Close()
            SQLFcmd.Connection = Nothing
        End Try



        TxtpayHeadLedgerList.Rows.Clear()
        Dim SqlConn3 As New SqlClient.SqlConnection
        Try
            SqlConn3.ConnectionString = ConnectionStrinG
            SqlConn3.Open()
            SQLFcmd.Connection = SqlConn3
            SQLFcmd.CommandText = "SELECT * FROM payrollvoucherLedgers WHERE TRANSCODE=" & TransCode
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            Dim rno As Integer = 0
            While Sreader.Read()
                rno = TxtpayHeadLedgerList.Rows.Add
                TxtpayHeadLedgerList.Item(0, rno).Value = Sreader("PAYNAME")
                TxtpayHeadLedgerList.Item(1, rno).Value = Sreader("ledgername")
            End While
        Catch ex As Exception
        Finally
            SqlConn3.Close()
            SQLFcmd.Connection = Nothing
        End Try
        Dim Insubstring As String = ""
        Insubstring = SQLGetStringFieldValue("select sqlstr from payrollVoucherMasterData where transcode=" & TransCode, "sqlstr")
        SqlStr = "SELECT  * FROM  (SELECT   empid as [EMP ID],  empname as [Employee Name], amount, payname FROM payrollvoucherRowDetails  WHERE  transcode =" & TransCode & ") AS s PIVOT (SUM(amount) FOR [PayName] IN (" & Insubstring & " )) AS sf "

        Dim TempBS As New BindingSource
        With Me.TxtTempList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        TxtList.Columns.Clear()
        TxtList.Rows.Clear()
        For i As Integer = 0 To TxtTempList.ColumnCount - 1
            TxtList.Columns.Add(TxtTempList.Columns(i).Name, TxtTempList.Columns(i).HeaderText)
        Next

        For i As Integer = 0 To TxtTempList.Rows.Count - 1
            TxtList.Rows.Add()
            For j As Integer = 0 To TxtTempList.Columns.Count - 1
                TxtList.Item(j, i).Value = TxtTempList.Item(j, i).Value
            Next
        Next


        Try
            If TxtList.Columns.Count > 13 Then
                TxtList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            Else
                TxtList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            End If
            TxtList.Columns(NetSalaryColName).DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns(NetSalaryColName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns(NetSalaryColName).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns(NetSalaryColName).Width = 100
            TxtList.Columns(NetSalaryColName).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
            TxtList.Columns(NetSalaryColName).DefaultCellStyle.ForeColor = Color.Green
            TxtList.Columns(GrossTotalColName).DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns(GrossTotalColName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns(GrossTotalColName).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns(GrossTotalColName).Width = 120
            TxtList.Columns(GrossTotalColName).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
            TxtList.Columns(GrossTotalColName).DefaultCellStyle.ForeColor = Color.Green

        Catch ex As Exception

        End Try
        Try
            For i As Integer = 2 To TxtList.Columns.Count - 1
                TxtList.Columns(i).DefaultCellStyle.Format = "N" & ErpDecimalPlaces
                TxtList.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                TxtList.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                TxtList.Columns(i).Width = 85
            Next
            TxtList.Columns(0).Name = "empid"
            TxtList.Columns(1).Name = "empname"
            TxtList.Columns("empid").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("empid").Width = 80
            TxtList.Columns("empname").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("empname").Width = 85
        Catch ex As Exception

        End Try
        FindPayHeadTotals()
        SqlStr = "Select * from payrollVoucherMasterData where transcode=" & TransCode
        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = SqlStr
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            Dim rno As Integer = 0
            While Sreader.Read()
                TxtVoucherDate.Value = Sreader("Transdate")
                txtvoucherno.Text = Sreader("VoucherNo")
                TxtSalaryMonth.Value = Sreader("PayDate")
                TxtTotalAllocationAmount.Text = FormatNumber(Sreader("NetTotal"), ErpDecimalPlaces)
                TxtNetPaybleTotal.Text = FormatNumber(Sreader("NetTotal"), ErpDecimalPlaces)
                txtnarration.Text = Sreader("narration")
                TxtPayMethod.Text = Sreader("paymethod")
            End While
        Catch ex As Exception
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try
        IsSaved = True
        IsAlterMode = True
        '  TxtList.DataSource = Nothing
    End Sub

    Private Sub TxtpayHeadLedgerList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtpayHeadLedgerList.CellContentClick

    End Sub

    Private Sub TxtpayHeadLedgerList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtpayHeadLedgerList.DataError

    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If IsAlterMode = True Then
            If MsgBox("Do you want to Delete the current Voucher  ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("DELETE FROM payrollVoucherMasterData WHERE TRANSCODE=" & TransCode)
                ExecuteSQLQuery("DELETE FROM payrollvoucherRowDetails WHERE TRANSCODE=" & TransCode)
                ExecuteSQLQuery("DELETE FROM PayRollVoucherPayMaster WHERE TRANSCODE=" & TransCode)
                ExecuteSQLQuery("DELETE FROM payrollvoucherLedgers WHERE TRANSCODE=" & TransCode)
                ExecuteSQLQuery("DELETE FROM LedgerBook WHERE TRANSCODE=" & TransCode)

                loaddefs()
            End If
        End If
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        If IsSaved = False Then
            If MsgBox("Current Voucher is not saved, Do you want to Create New Voucher ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        loaddefs()
    End Sub

    Private Sub btnprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprint.Click
        If IsAlterMode = True Then
            Me.Cursor = Cursors.WaitCursor
            Dim ds As New PaySlipReportDataSet
            ds.Clear()
            ds.Tables(0).Rows.Clear()
            For emprowsi As Integer = 0 To TxtList.Rows.Count - 1

                Dim empid As String = ""
                Dim EmpNo As String = ""
                Dim EmpBankName As String = ""
                Dim EmpBankNo As String = ""
                Dim EmpBankIFSCNo As String = ""
                Dim EmpDesignation As String = ""
                Dim EmpDepartment As String = ""
                Dim ContractType As String = ""
                Dim Gender As String = ""
                Dim EmpDOJ As New DateTimePicker
                Dim ContractExpiry As New DateTimePicker
                Try
                    Dim SqlConn As New SqlClient.SqlConnection
                    Dim Sqlcmmd As New SqlClient.SqlCommand
                    Dim SQLStr As String = ""
                    Try
                        SqlConn.ConnectionString = ConnectionStrinG
                        SqlConn.Open()
                        Sqlcmmd.Connection = SqlConn
                        Sqlcmmd.CommandText = "select * from employees where empname=N'" & TxtList.Item("empname", emprowsi).Value & "'"
                        Sqlcmmd.CommandType = CommandType.Text
                        Dim Sreader As SqlClient.SqlDataReader
                        Sreader = Sqlcmmd.ExecuteReader
                        While Sreader.Read()
                            empid = Sreader("EmpID").ToString.Trim
                            EmpNo = Sreader("EmpPersonalID").ToString.Trim
                            EmpBankName = Sreader("empbankname").ToString.Trim
                            EmpBankNo = Sreader("empbankacno").ToString.Trim
                            EmpBankIFSCNo = Sreader("bankifsccode").ToString.Trim
                            EmpDOJ.Value = Sreader("DateofJoining")
                            EmpDesignation = Sreader("Designation").ToString.Trim
                            EmpDepartment = Sreader("DepName").ToString.Trim
                            ContractExpiry.Value = Sreader("contractexpirydate")
                            ContractType = Sreader("Contracttype").ToString.Trim
                            Gender = Sreader("Gender").ToString.Trim
                        End While
                        Sreader.Close()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        SqlConn.Close()
                        SqlConn = Nothing
                        Sqlcmmd.Connection = Nothing
                    End Try
                Catch ex As Exception

                End Try

                'Dim row As DataRow
                'row = ds.Tables("DataTable2").NewRow
                'row("EmpName") = TxtList.Item("Employee Name", x.Index).Value
                'row("EmpID") = empid
                'row("EmpNo") = EmpNo


                'row("DataColumn8") = TxtList.Item("transcode", x.Index).Value
                'ds.Tables("DataTable2").Rows.Add(row)

                Dim Prow As Integer = -1
                Try
                    Dim SqlConn1 As New SqlClient.SqlConnection
                    Dim Sqlcmmd1 As New SqlClient.SqlCommand
                    Dim SQLStr As String = ""

                    Try
                        SqlConn1.ConnectionString = ConnectionStrinG
                        SqlConn1.Open()
                        Sqlcmmd1.Connection = SqlConn1
                        Sqlcmmd1.CommandText = "select * from payrollvoucherRowDetails where empname=N'" & TxtList.Item("empname", emprowsi).Value & "' and transcode=" & TransCode & " and type=1 "
                        Sqlcmmd1.CommandType = CommandType.Text
                        Dim Sreader As SqlClient.SqlDataReader
                        Sreader = Sqlcmmd1.ExecuteReader
                        While Sreader.Read()
                            Dim drow As DataRow
                            If Prow = -1 Then
                                Prow = ds.Tables("Datatable1").Rows.Count
                            End If
                            drow = ds.Tables("Datatable1").NewRow
                            drow("EmpName") = Sreader("empname").ToString
                            drow("EmpID") = empid
                            drow("amount") = Sreader("amount").ToString
                            drow("payname") = Sreader("payname").ToString.Trim
                            drow("orderno") = Sreader("orderno")
                            drow("type") = Sreader("type")
                            drow("damount") = 0
                            drow("PaySlipNo") = emprowsi
                            drow("dpayname") = ""
                            drow("transcode") = Sreader("transcode")
                            'drow("InvoiceNo") = TxtList.Item("Voucher No", x.Index).Value
                            'drow("InvoiceRef") = TxtList.Item("Voucher No", x.Index).Value
                            drow("EmpBankName") = EmpBankName
                            drow("EmpBankNo") = EmpBankNo
                            drow("EmpBankIFSCNo") = EmpBankIFSCNo
                            drow("EmpDOJ") = EmpDOJ.Value.Date
                            drow("EmpDesignation") = EmpDesignation
                            drow("EmpDepartment") = EmpDepartment
                            drow("ContractExpiry") = FormatDateTime(ContractExpiry.Value.Date, DateFormat.ShortDate)
                            drow("ContractType") = ContractType
                            drow("Gender") = Gender
                            ' drow("CrAmount") = 0
                            drow("ForMonth") = SQLGetStringFieldValue("select PayDate from payrollVoucherMasterData where  transcode=" & TransCode, "PayDate")
                            drow("Voucherno") = SQLGetStringFieldValue("select VoucherNo from payrollVoucherMasterData where   transcode=" & TransCode, "VoucherNo")
                            ds.Tables("Datatable1").Rows.Add(drow)

                        End While
                        Sreader.Close()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        SqlConn1.Close()
                        SqlConn1 = Nothing
                        Sqlcmmd1.Connection = Nothing
                    End Try
                Catch ex As Exception

                End Try


                'for duductions
                Try
                    Dim SqlConn1 As New SqlClient.SqlConnection
                    Dim Sqlcmmd1 As New SqlClient.SqlCommand
                    Dim SQLStr As String = ""

                    Try
                        SqlConn1.ConnectionString = ConnectionStrinG
                        SqlConn1.Open()
                        Sqlcmmd1.Connection = SqlConn1
                        Sqlcmmd1.CommandText = "select * from payrollvoucherRowDetails where empname=N'" & TxtList.Item("empname", emprowsi).Value & "' and transcode=" & TransCode & " and type=2 "
                        Sqlcmmd1.CommandType = CommandType.Text
                        Dim Sreader As SqlClient.SqlDataReader
                        Sreader = Sqlcmmd1.ExecuteReader
                        While Sreader.Read()
                            Try
                                ds.Tables("Datatable1").Rows(Prow).Item("damount") = Sreader("Amount")
                                ds.Tables("Datatable1").Rows(Prow).Item("dpayname") = Sreader("payname").ToString.Trim
                            Catch ex2 As Exception
                                Dim drow As DataRow
                                drow = ds.Tables("Datatable1").NewRow
                                drow("EmpName") = Sreader("empname").ToString
                                drow("EmpID") = empid
                                drow("amount") = 0
                                drow("PaySlipNo") = emprowsi
                                drow("payname") = 0
                                drow("orderno") = Sreader("orderno")
                                drow("type") = Sreader("type")
                                drow("damount") = Sreader("Amount")
                                drow("dpayname") = Sreader("payname").ToString.Trim
                                drow("transcode") = Sreader("transcode")
                                drow("EmpBankName") = EmpBankName
                                drow("EmpBankNo") = EmpBankNo
                                drow("EmpBankIFSCNo") = EmpBankIFSCNo
                                drow("EmpDOJ") = EmpDOJ.Value.Date
                                drow("EmpDesignation") = EmpDesignation
                                drow("EmpDepartment") = EmpDepartment
                                drow("ContractExpiry") = FormatDateTime(ContractExpiry.Value.Date, DateFormat.ShortDate)
                                drow("ContractType") = ContractType
                                drow("Gender") = Gender
                                drow("ForMonth") = SQLGetStringFieldValue("select PayDate from payrollVoucherMasterData where  transcode=" & TransCode, "PayDate")
                                drow("Voucherno") = SQLGetStringFieldValue("select VoucherNo from payrollVoucherMasterData where   transcode=" & TransCode, "VoucherNo")
                                ds.Tables("Datatable1").Rows.Add(drow)
                            End Try

                            Prow = Prow + 1
                        End While
                        Sreader.Close()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        SqlConn1.Close()
                        SqlConn1 = Nothing
                        Sqlcmmd1.Connection = Nothing
                    End Try
                Catch ex As Exception

                End Try
            Next





            Dim objRpt As New PaySlipCRA5ReportForEmp
            SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
            If PrintOptionsforCR.IsPrintHeader = False Then
                CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
                CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
                CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "PAY SLIP"
            Else
                CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "PAY SLIP"
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
            MsgBox("Please open the existing voucher or save the current voucher...", MsgBoxStyle.Critical)
            Exit Sub
        End If
    End Sub

    Private Sub TxtTempList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtTempList.CellContentClick

    End Sub

    Private Sub TxtTempList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtTempList.DataError

    End Sub
End Class