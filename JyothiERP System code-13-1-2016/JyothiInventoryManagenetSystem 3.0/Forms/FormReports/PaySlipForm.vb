Public Class PaySlipForm
    Dim SqlStr As String = ""

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadData()
        Dim TotalSqlStr As String = ""
        TotalSqlStr = "Select sum(amount) as tot FROM payrollvoucherRowDetails WHERE    (PayName = 'NETSALARY') "
        SqlStr = "SELECT     transcode, (select TOP (1) transdate from payrollVoucherMasterData where transcode=payrollvoucherRowDetails.transcode) as [Date],(select TOP (1) voucherno from payrollVoucherMasterData where transcode=payrollvoucherRowDetails.transcode) AS [Voucher No], EmpName as [Employee Name] , amount  as [Net Salary]  FROM payrollvoucherRowDetails WHERE    (PayName = 'NETSALARY') "
        If IsDateWiseOn.Checked = True Then
            SqlStr = SqlStr & " AND (TRANSCODE IN ( SELECT TRANSCODE FROM payrollVoucherMasterData WHERE (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & "))) "
            TotalSqlStr = TotalSqlStr & " AND (TRANSCODE IN ( SELECT TRANSCODE FROM payrollVoucherMasterData WHERE (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & "))) "
        Else

        End If
        If TxtEmployeeName.Text = "*All" Or TxtEmployeeName.Text.Length = 0 Then

        Else
            SqlStr = SqlStr & " and empname=N'" & TxtEmployeeName.Text & "'"
            TotalSqlStr = TotalSqlStr & " and empname=N'" & TxtEmployeeName.Text & "'"
        End If
      
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            If TxtVoucherNo.Text.Length > 0 Then
                TempBS.Filter = " [voucher no]='" & TxtVoucherNo.Text & "'"
            End If
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            
            TxtList.Columns("transcode").Visible = False
            TxtList.Columns("Date").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Date").DefaultCellStyle.Format = "d"
            TxtList.Columns("Date").Width = 80

            TxtList.Columns("Voucher No").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Voucher No").Width = 100

           

            TxtList.Columns("Employee Name").Visible = True
            TxtList.Columns("Employee Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("Employee Name").Width = 200
           

            TxtList.Columns("Net Salary").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Net Salary").Width = 100
            TxtList.Columns("Net Salary").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Net Salary").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Net Salary").DefaultCellStyle.Font = New Font("Arial", 11, FontStyle.Bold)
            TxtList.Columns("Net Salary").DefaultCellStyle.ForeColor = Color.Green
        Catch ex As Exception

        End Try

        If TxtVoucherNo.Text.Length > 0 Then
            Dim tot As Double = 0
            For i As Integer = 0 To TxtList.RowCount - 1
                tot = tot + CDbl(TxtList.Item("Net Salary", i).Value)
            Next
            TxtCrTotal.Text = FormatNumber(tot, ErpDecimalPlaces)
        Else
            TxtCrTotal.Text = FormatNumber(SQLGetNumericFieldValue(TotalSqlStr, "tot"), ErpDecimalPlaces)
        End If

        TxtVoucherNo.Text = ""
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, RefreshToolStripMenuItem.Click, ImsButton2.Click
        LoadData()
    End Sub

    Private Sub TxtShowDetailed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadData()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, PrintToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New PaySlipReportDataSet
        ds.Clear()
        ds.Tables(0).Rows.Clear()
        For Each x As DataGridViewRow In TxtList.SelectedRows
          
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
                    Sqlcmmd.CommandText = "select * from employees where empname=N'" & TxtList.Item("Employee Name", x.Index).Value & "'"
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
                    Sqlcmmd1.CommandText = "select * from payrollvoucherRowDetails where empname=N'" & TxtList.Item("Employee Name", x.Index).Value & "' and transcode=" & TxtList.Item("Transcode", x.Index).Value & " and type=1 "
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
                        drow("PaySlipNo") = x.Index
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
                        drow("ForMonth") = SQLGetStringFieldValue("select PayDate from payrollVoucherMasterData where  transcode=" & TxtList.Item("Transcode", x.Index).Value, "PayDate")
                        drow("Voucherno") = SQLGetStringFieldValue("select VoucherNo from payrollVoucherMasterData where   transcode=" & TxtList.Item("Transcode", x.Index).Value, "VoucherNo")
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
                    Sqlcmmd1.CommandText = "select * from payrollvoucherRowDetails where empname=N'" & TxtList.Item("Employee Name", x.Index).Value & "' and transcode=" & TxtList.Item("Transcode", x.Index).Value & " and type=2 "
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
                            drow("PaySlipNo") = x.Index
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
                            drow("ForMonth") = SQLGetStringFieldValue("select PayDate from payrollVoucherMasterData where  transcode=" & TxtList.Item("Transcode", x.Index).Value, "PayDate")
                            drow("Voucherno") = SQLGetStringFieldValue("select VoucherNo from payrollVoucherMasterData where   transcode=" & TxtList.Item("Transcode", x.Index).Value, "VoucherNo")
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

    End Sub

    Private Sub PaySlipForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub PayrollListFormReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        LoadDataIntoComboBox("select distinct empname from payrollvoucherRowDetails", TxtEmployeeName, "Empname", "*All")
        TxtEmployeeName.Text = "*All"

    End Sub

    Private Sub TxtEmployeeName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEmployeeName.SelectedIndexChanged
        LoadData()
    End Sub
End Class