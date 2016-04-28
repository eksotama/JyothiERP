Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.IO.Ports
Imports System.Net.Mail
Imports System.Net

Module MainModule
    Public TrailEndForAmountInWordsInteger As String = " Ruppes " ' loadded by the company data
    Public TrailEndForamountinWordsDecimals As String = " Paisa"
    Public TrailEndForAmountInWords As String = " Only"
    Public IsShowCurrencyAfterAmountInwords As Boolean = False
    Public isAllowToPulldatainSalesfromDelivery As Boolean = False
    Public FontNameforCtrls As String = "Microsoft Sans Serif"
    Public FontForLostFocus As Single = 8.25
    Public FontForGotFocus As Single = 10
    Public CurrentCounterID As Integer = 0
    Public Dummydata As Boolean = False
    Public IsReArrangeInvoiceNumberOnDelete As Boolean = False
    Public IsLateinCountAsABSENTSInPayroll As Boolean = True
    Public erpCurrencyConversionEffectOnValues As Boolean = True
    Public ErpReadExchangeRate As Double = 1
    Public SearchStockItemName As String = ""
    Public ErpDecimalPlaces As Integer = 3
    Public EntryCurrentDate As New DateTimePicker
    Public EntryCurrentPeriodStart As New DateTimePicker
    Public EntryCurrentPeriodEnd As New DateTimePicker
    Public IsSalesPriceAsMRPWithOutVAT As Boolean = False
    Public NewCreatedLedgerName As String = ""
    'SET THIS TRUE FOR THE CLIENT AND SERVER SYSTEM
    'FOR DORA MEDORAERPDBS
    Public IsClientAndServerSystem As Boolean = False

    Public ProductKeyCode As String = ""
    Public IsExitOnEscKey As Boolean = False
    Public CurrentAPPDate As New DateTimePicker

    Public MySoftwareName As String = "JyothiERP"
    Public CompDetails As New CompanyStructure
    Public CurrentUserName As String = "Admin" ' don't change
    Public User_IsAllowtoDelete As Boolean = True
    Public User_IsAllowtoEdit As Boolean = True
    Public User_IsCreateMasters As Boolean = True
    Public EmpincrementTranscode As Double = 0
    'Don't Change this Database Name
    'If you  change, you need to change in 'Module1.vb' of  the 'ERP Request Server' Project also 
    'Public NewCompanyDBName As String = "MESWERPDBDD"
    Public NewCompanyDBName As String = "MESWERPDBDD"
    'JyothipharmaerpDB1005
    Public UpdateQuantityForNon_StockAlso As Boolean = False
    Public PhotoPathForLedgers As String = ""
    Public PhotoPathForBarcode As String = ""
    Public PhotoBackupPath As String = ""
    Public StockPhotoPath As String = ""
    Public DefDutyHours As Integer = 8
    Public InvoiceType As InvoiceNoStrct
    Public MaxInvoicePages As Byte = 8
    Public DefLedgers As New DefLedgerstrut
    Public LastAccessDate As New DateTimePicker
    Public PresentVersionNumber As Integer = 48
    Public DefTailCurrencyName As String = " Only"
    Public IsCustomBarCode As Boolean = False
    Public InvoiceBillingSettings As New InvoiceBillingSettingsClass
    Public FormNameCode As New FormNameStruct
    Public var_RequestCode As Single = 0
    Public Var_FormFiledCode As Single = 0
    Public DefaultLocation As String = "MainLocation"
    Public CustomBarcodelength As Integer = 40  ' maximum 40
    Public DefaultBarcodeLength As Integer = 16 ' maximum 40
    Public MYLOGOUTTIME As Integer = 10000
    Public SelectedVoucherType As Byte = 0
    Public DefCashAccount As String = "Cash"
    Public OpendedPayRollTransCode As Single = 0
    Public IsAllowDuplicateIvoiceItems As Boolean = False
    Public PrintVoucherNames As New PrintVoucherNamesClass
    Public MyAppSettings As New SoftwareSettingClass
    Public APPUserRights As New UserRightsStruct
    Public UserLogInlogoutID As Single = 0
    Public ConnectionStringFromFile As String = ""
    Public DateFormatConversionNumber As Integer = 103
    Public SelectedEmpCodeforWPS As String
    Public Trailmsg As String = "The Trail Period is Expired....."
    Public IsTrailApplication As Boolean = True

    Public IsRunServerWithApplication As Boolean = True
    Public ServerRequestTimeOut As Integer = 100 ' set 100 for below 10 clients , set 200 for above 10 clients
    Public SMSSettings As New SMSSettingStruct
    Public BarcodeSettingsVals As New BarcodeSettingsStruct
    Public POSSettings As New POSSettingStruct
    Public Structure POSSettingStruct

        Dim AllowPriceAlter As Boolean
        Dim AllowDiscountAlter As Boolean
        Dim AllowNewItem As Boolean
        Dim defPrinterName As String
        Dim NoofCopies As Integer
        Dim ZeroTax As Boolean
        Dim DirectPrint As Boolean
        Dim NewInvoiceAfterSave As Boolean
        Dim PrintInvoiceAfterSave As Boolean
        Dim AllowPaymentMethod As Boolean
        Dim ShowKeyboard As Boolean
        Dim DefaultPriceList As String
        Dim IsAllowTochangeDate As Boolean
        Dim IsAllowCreditSales As Boolean
        Dim IsAllowMultiCurrency As Boolean
        Dim IsItemsAsGridList As Boolean
        Dim CashLedger As String
        Dim CreditCardLedger As String
        Dim ChequeLedger As String
        Dim GiftCardLedger As String
    End Structure
    Public Structure BarcodeSettingsStruct
        Dim BarcodeLength As Integer
        Dim IsFixedLegth As Boolean
        Dim IsAutoFill As Boolean
        Dim IsLeadingZeros As Boolean
    End Structure
    Public Structure UserRightsStruct
        Dim IsDeleteble As Boolean
        Dim IsEditable As Boolean
        Dim IsAccessable As Boolean
        Dim IsHasFullRights As Boolean
        Dim IsReadOnly As Boolean
        Dim IsAccessMasters As Boolean
        Dim IsAdvanceUser As Boolean
    End Structure
    Public Structure SMSSettingStruct
        Dim UserName As String
        Dim Password As String
        Dim SMSType As String
        Dim PortName As String
        Dim BaudRate As Integer
        Dim ServiceNo As String
        Dim PortNo As String
        Dim UrlPathforAPI As String
    End Structure
    Public Enum ExportOptions
        Word = 1
        PDF = 2
        HTML = 3
        Other = 4
    End Enum
    Public Structure EditValuesStruct
        Dim IsActive As Integer
        Dim OpBalance As Double
        Dim OpBalanceCrDr As String
        Dim PhotoPath As String
        Dim isBillWise As Integer
        Dim CurCon As Double
    End Structure
    Public Function ValidateEmailID(ByVal emailAddress As String) As Boolean
        If Regex.IsMatch(emailAddress, "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$") Then
            ValidateEmailID = True
        Else

            ValidateEmailID = False
        End If
    End Function
    Public Function IsAuditConfirm(ByVal tCode As Double, Optional ByVal ttype As String = "Vouchers") As Boolean
        Dim isconfm As Boolean = False
        Dim val As Integer
        If UCase(ttype) = UCase("Vouchers") Then
            val = SQLGetNumericFieldValue("select n1 from ledgerbook where transcode=" & tCode, "n1")
        ElseIf UCase(ttype) = UCase("Inventory") Then
            val = SQLGetNumericFieldValue("select n1 from StockInvoiceDetails where transcode=" & tCode, "n1")
        End If
        If val = 1 Then
            isconfm = True
        End If


        Return isconfm
    End Function

    Public Function GetAvailableStockQty(ByVal barcode As String, ByVal stocklocation As String) As Double
        Dim ks As Double = 0
        ks = SQLGetNumericFieldValue("select totalqty from stockdbf where barcode=N'" & barcode & "' and location=N'" & stocklocation & "'", "totalqty")
        Return ks
    End Function

    Public Function ReplaceZerosToBarcode(ByVal bcode As String) As String
        If BarcodeSettingsVals.IsLeadingZeros = False Then
            Return bcode
        Else
            If bcode.Length = CustomBarcodelength Then
                Return bcode
            Else
                If bcode.Length > CustomBarcodelength Then
                    MsgBox("The Barcode Legth is excceds the limit...            ", MsgBoxStyle.Critical)
                    bcode = bcode.Substring(0, CustomBarcodelength - 1)
                End If
                For i As Byte = 1 To CustomBarcodelength - bcode.Length
                    bcode = "0" & bcode
                Next
                Return bcode
            End If
        End If

    End Function

    Public Function IsAllowToDeleteAccountGroup(ByVal gpname As String) As Boolean
        If SQLGetNumericFieldValue("select isprimary from AccountGroups where groupname=N'" & gpname & "'", "Isprimary") = 1 Then
            Return False
        Else
            If SQLIsFieldExists("SELECT TOP 1 1 from   ledgers where AccountGroup=N'" & gpname & "'") = True Then
                Return False
            Else
                Return True
            End If
        End If
    End Function

    Public Function PresentUserLoginCount() As Integer
        Return 1
    End Function

    Public Sub IMSWait(ByVal interval As Integer)
        Dim sp As New Stopwatch
        sp.Start()
        Do While sp.ElapsedMilliseconds < interval

        Loop
        sp.Stop()
    End Sub

    Public Enum VoucherType
        Payment = 1
        Receipt = 2
        Purchase = 3
        PurchaseReturns = 4
        PurchaseVoucher = 5
        PurchaseRetVoucher = 6
        Sales = 7
        SalesReturns = 8
        SalesVoucher = 9
        SalesReturnVoucher = 10
        journal = 11
        Contra = 12
    End Enum
    Public Structure DefLedgerstrut
        Dim SalesAccount As String
        Dim SalesRetAccount As String
        Dim PurchaseAccount As String
        Dim PurchaseRetAccount As String
        Dim CashAccount As String
        Dim BankAccount As String
        Dim CashDiscountDRAccount As String
        Dim CashDiscountCRAccount As String
        Dim POSDefaultOption As String
        Dim RoundOffLeder As String
        Dim SalesDiscountLedger As String
        Dim PurchaseDiscountLedger As String
        Dim CommisionLedger As String
    End Structure
    Public Enum InvoiceNoStrct
        salesquoto = 1
        salesorder = 2
        salesdelavery = 3
        salesinvoice = 4
        purchasequoto = 5
        purchaseorder = 6
        purchasereceived = 7
        purchaseinvoice = 8
        salesvoucher = 9
        salesreturnvoucher = 10
        purchasevoucher = 11
        purchasereturnvoucher = 12
        paymnetvoucher = 13
        receiptvoucher = 14
        contravoucher = 15
        journalvoucher = 16
        SalesRetInvoice = 17
        PurchaseRetInvoice = 18
        POS = 19
        Payroll = 20
        STOCKJOURNAL = 21
        FORM8 = 22
        FORM8B = 23
        FORM8D = 24
        SRFORM8 = 25
        SRFORM8B = 26
        SRFORM8D = 27
        CASHSALES = 28
        CREDITSALES = 29
        CASHPURCHASE = 30
        CREDITPURCHASE = 31
    End Enum
    Public Enum EnumIDType
        EmployeeID = 1
        SupplierID = 2
        CustomerID = 3
        EmployeePErID = 4
        SalesPersonID = 5
        TransCode = 6
        Barcode128 = 7
        BarcodeENA = 8
        AreaCode = 9
        StockCode = 10
        Accounts = 11
        LogFileID = 12
        Bill2BillCode = 13
        lOCKTRANSCODE = 20
        UserTransID = 21
        AssetID = 22
        BudgetID = 23
    End Enum
    Public Structure CompanyStructure
        Dim CompanyID As String
        Dim CompanyName As String
        Dim CompanyLicenceno As String
        Dim Companytaxregno As String
        Dim Companyaddresspoboxno As String
        Dim Companystreet As String
        Dim Companystate As String
        Dim Companycountry As String
        Dim Companytel As String
        Dim CompanyFax As String
        Dim Companyemail As String
        Dim Companywebsite As String
        Dim Companyusername As String
        Dim Companypasword As String
        Dim CompanyLogopath As String
        Dim AccDateFrom As Date
        Dim AccDateTo As Date
        Dim BookDateFrom As Date
        Dim BookDateTo As Date
        Dim CompanyAdminEmailId As String
        Dim CompanyType As String
        Dim Currency As String
        Dim CompanyVersionNumber As Integer
        Dim NoofDecimals As Integer
        Dim CSTNo As String
        Dim DateFormattext As String
    End Structure
    Public Function GetGratuityValue(ByVal Years As Double, ByVal methodname As String) As Double
        Dim SqlConn2 As New SqlClient.SqlConnection
        Dim SQLFcmd12 As New SqlClient.SqlCommand
        Dim Value As Double = 1
        Try
            SqlConn2.ConnectionString = ConnectionStrinG
            SqlConn2.Open()
            SQLFcmd12.Connection = SqlConn2
            SQLFcmd12.CommandText = "select * from EmpGratuityMethods where method=N'" & methodname & "' order by years "
            SQLFcmd12.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd12.ExecuteReader
            While Sreader.Read()
                If Years < Sreader("years") Then
                    Value = Sreader("price") / 30
                    Exit While
                End If

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception

        Finally
            SqlConn2.Close()
            SQLFcmd12.Connection = Nothing
            SqlConn2.Dispose()
        End Try
        Return Value
    End Function

    Public Function GetEmpAttendence(ByVal empname As String, ByVal txtpresentdate As DateTimePicker) As Double

        If MyAppSettings.IsMrngEvngShiftDuty = True Then
            Dim Datefromvalue As Long = 0
            Dim DateTovalue As Long = 0
            Dim tempdate As New DateTimePicker
            tempdate.Value = txtpresentdate.Value.Date.AddDays(-txtpresentdate.Value.Date.Day + 1)
            Datefromvalue = tempdate.Value.Date.ToOADate
            DateTovalue = tempdate.Value.Date.AddDays(Date.DaysInMonth(tempdate.Value.Year, tempdate.Value.Month) - 1).Date.ToOADate
            Dim ccount As Double = 0
            Dim SqlConn2 As New SqlClient.SqlConnection
            Dim SQLFcmd12 As New SqlClient.SqlCommand

            Try
                SqlConn2.ConnectionString = ConnectionStrinG
                SqlConn2.Open()
                SQLFcmd12.Connection = SqlConn2
                SQLFcmd12.CommandText = "select * from empattend where empname=N'" & empname & "' and  (EmpDateValue between " & Datefromvalue & " and " & DateTovalue & ") order by EmpDateValue"
                SQLFcmd12.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd12.ExecuteReader
                While Sreader.Read()
                    If Sreader("Status").ToString.Trim = "P" And Sreader("period").ToString.Trim = "M" Then
                        ccount = ccount + 1 / 2
                    End If
                    If Sreader("Status").ToString.Trim = "P" And Sreader("period").ToString.Trim = "E" Then
                        ccount = ccount + 1 / 2
                    End If
                End While
                Sreader.Close()
                Sreader = Nothing
            Catch ex As Exception

            Finally
                SqlConn2.Close()
                SqlConn2.Dispose()

                SQLFcmd.Connection = Nothing

            End Try
            Return ccount
        Else
            Dim Datefromvalue As Long = 0
            Dim DateTovalue As Long = 0
            Dim tempdate As New DateTimePicker
            tempdate.Value = txtpresentdate.Value.Date.AddDays(-txtpresentdate.Value.Date.Day + 1)
            Datefromvalue = tempdate.Value.Date.ToOADate
            DateTovalue = tempdate.Value.Date.AddDays(Date.DaysInMonth(tempdate.Value.Year, tempdate.Value.Month) - 1).Date.ToOADate
            Dim ccount As Integer = 0
            Dim SqlConn2 As New SqlClient.SqlConnection
            Dim SQLFcmd12 As New SqlClient.SqlCommand

            Try
                SqlConn2.ConnectionString = ConnectionStrinG
                SqlConn2.Open()
                SQLFcmd12.Connection = SqlConn2
                SQLFcmd12.CommandText = "select * from empattend where period='M' and  empname=N'" & empname & "' and  (EmpDateValue between " & Datefromvalue & " and " & DateTovalue & ") order by EmpDateValue"
                SQLFcmd12.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd12.ExecuteReader
                While Sreader.Read()

                    If Sreader("Status") = "P" Then
                        ccount = ccount + 1
                    End If
                End While
                Sreader.Close()

            Catch ex As Exception

            Finally
                SqlConn2.Close()
                SQLFcmd.Connection = Nothing
                SqlConn2.Dispose()
            End Try
            Return ccount
        End If



    End Function
    Public Function IsBankLedger(ByVal ledgname As String) As Boolean
        If SQLIsFieldExists("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "') and ledgername=N'" & ledgname & "'") = True Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function IsCashLedger(ByVal ledgname As String) As Boolean
        If SQLIsFieldExists("select ledgername from ledgers where Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "') and ledgername=N'" & ledgname & "'") = True Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function IMSBEGINTRANSACTION() As Boolean
        Dim Retvalue As Boolean = True
        If IsClientAndServerSystem = False Then
            Return Retvalue
        Else
            Dim K As Integer = 1
            MainForm.Cursor = Cursors.WaitCursor

RetryAgain: var_RequestCode = var_RequestCode + 1
            If var_RequestCode = 99999999 Then
                var_RequestCode = 1
            End If
            ExecuteSQLQuery("INSERT INTO [Request] ([ReqNo],[ReqSystemName],[Status],[UserName],[SystemName]) VALUES(" & var_RequestCode & ",N'" & My.Computer.Name.ToString & "','A',N'" & CurrentUserName & "',N'" & My.Computer.Name.ToString & "')")

            'My.Application.DoEvents()
            While (SQLGetStringFieldValue("SELECT STATUS FROM REQUEST WHERE ReqSystemName=N'" & My.Computer.Name & "' and REQNO=" & var_RequestCode, "STATUS") <> "R")
                IMSWait(ServerRequestTimeOut)
                If K > 100 Then
                    Retvalue = False
                    Exit While
                End If
                K = K + 1
            End While
            If Retvalue = False Then
                If MsgBox("The server is too busy or ERP Server may be shutdown, Please Run the ERP Server .....Please Try again", MsgBoxStyle.RetryCancel + MsgBoxStyle.Critical) = MsgBoxResult.Retry Then
                    IMSENDTRANSACTION()
                    K = 1
                    Retvalue = True
                    GoTo RetryAgain
                Else
                    If MsgBox("The Present Transaction may be incompleted, Do you want to cancel ?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                        IMSENDTRANSACTION()
                        K = 1
                        Retvalue = True
                        GoTo RetryAgain
                    End If
                End If
            End If
            Return Retvalue
        End If


    End Function
    Public Function IMSENDTRANSACTION() As Boolean
        ExecuteSQLQuery("UPDATE REQUEST SET Status='C' WHERE ReqSystemName=N'" & My.Computer.Name & "' and REQNO=" & var_RequestCode)
        MainForm.Cursor = Cursors.Default
        Return True
    End Function

    Public Sub LoadDefLedgerValues()
        DefLedgers.CashAccount = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='cash'", "ledgername")
        DefLedgers.SalesAccount = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='sales'", "ledgername")
        DefLedgers.SalesRetAccount = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='salesret'", "ledgername")
        DefLedgers.PurchaseAccount = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='purch'", "ledgername")
        DefLedgers.PurchaseRetAccount = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='purchret'", "ledgername")
        DefLedgers.POSDefaultOption = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='pos'", "ledgername")
        DefLedgers.PurchaseDiscountLedger = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='cdcr'", "ledgername")
        DefLedgers.SalesDiscountLedger = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='cddr'", "ledgername")
        DefLedgers.RoundOffLeder = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='round'", "ledgername")


    End Sub
    Public Sub LoadCompanyData()
        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from company "
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                ' cob.Items.Add(Sreader(FieldName).ToString.Trim)
                CompDetails.CompanyID = Sreader("companyID").ToString.Trim
                CompDetails.CompanyName = Sreader("companyname").ToString.Trim
                CompDetails.CompanyLicenceno = Sreader("licenseno").ToString.Trim
                CompDetails.Companytaxregno = Sreader("taxregno").ToString.Trim
                CompDetails.Companyaddresspoboxno = Sreader("address").ToString.Trim
                CompDetails.Companystreet = Sreader("location").ToString.Trim
                CompDetails.Companystate = Sreader("state").ToString.Trim
                CompDetails.Companycountry = Sreader("country").ToString.Trim
                CompDetails.Companytel = Sreader("tel").ToString.Trim
                CompDetails.CompanyFax = Sreader("fax").ToString.Trim
                CompDetails.Companyemail = Sreader("emailid").ToString.Trim
                CompDetails.Companywebsite = Sreader("website").ToString.Trim
                CompDetails.Companyusername = Sreader("adminname").ToString.Trim
                CompDetails.Companypasword = Sreader("adminpassword").ToString.Trim
                CompDetails.CompanyLogopath = Sreader("logoimage").ToString.Trim
                CompDetails.AccDateFrom = CDate(Sreader("accyearstart").ToString.Trim)
                CompDetails.AccDateTo = CDate(Sreader("accyearend").ToString.Trim)
                CompDetails.BookDateFrom = CDate(Sreader("booksyearstart").ToString.Trim)
                CompDetails.BookDateTo = CDate(Sreader("booksyearend").ToString.Trim)
                CompDetails.CompanyAdminEmailId = Sreader("adminemailid").ToString.Trim
                CompDetails.CompanyType = Sreader("accounttype").ToString.Trim
                CompDetails.Currency = Sreader("Currency").ToString.Trim
                Try
                    CompDetails.DateFormattext = Sreader("DateFormattext").ToString
                Catch ex As Exception
                    CompDetails.DateFormattext = "dd/mmm/yyyy"
                End Try

                If IsDBNull(Sreader("Versionno")) = True Then
                    CompDetails.CompanyVersionNumber = 0
                Else
                    CompDetails.CompanyVersionNumber = Sreader("Versionno")
                End If

                'Versionno
                PhotoPathForLedgers = Sreader("photopath").ToString.Trim
                StockPhotoPath = Sreader("photopath").ToString.Trim & "\StockPhotos"
                PhotoBackupPath = Sreader("Backupath").ToString.Trim
                PhotoPathForBarcode = Sreader("BarcodePath").ToString.Trim
                AppIsItemwithSize = Sreader("IsSizeBasedItem")
                'Public TrailEndForAmountInWordsInteger As String = " RO "
                'Public TrailEndForamountinWordsDecimals As String = " baiza"

                TrailEndForAmountInWordsInteger = Sreader("CurrencyName").ToString
                TrailEndForamountinWordsDecimals = Sreader("DecimalSymbol").ToString
                Try
                    LastAccessDate.Value = CDate(Sreader("LastAccessDate"))
                    If LastAccessDate.Value > Now.AddDays(1) Then
                        MsgBox("Please Check The System Date, The System Date is below the Transaction Date ", MsgBoxStyle.Information)
                    End If
                Catch ex As Exception
                    LastAccessDate.Value = Now
                End Try
                Try

                    EntryCurrentPeriodStart.Value = Sreader("periodfrom")
                Catch ex As Exception
                    EntryCurrentPeriodStart.Value = Today.AddDays(-30)
                End Try
                Try

                    EntryCurrentPeriodEnd.Value = Sreader("PeriodTo")
                Catch ex As Exception
                    EntryCurrentPeriodEnd.Value = Today
                End Try
                Try
                    EntryCurrentDate.Value = IIf(IsDBNull(Sreader("CurrentDate")) = True, Today, Sreader("CurrentDate"))
                Catch ex As Exception
                    EntryCurrentDate.Value = Today
                    Try
                        ExecuteSQLQuery("ALTER TABLE COMPANY ADD [CurrentDate] [DATETIME] NULL")
                        ExecuteSQLQuery("update company set CurrentDate=CONVERT(datetime,'" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "',101)  ")
                    Catch ex3 As Exception

                    End Try
                End Try
                Try
                    CompDetails.NoofDecimals = Sreader("noofdecimals")
                    ErpDecimalPlaces = CompDetails.NoofDecimals
                Catch ex As Exception
                    ExecuteSQLQuery("ALTER TABLE company ADD [noofdecimals] [int] NULL")
                    ExecuteSQLQuery("update company set noofdecimals=2")
                    CompDetails.NoofDecimals = ErpDecimalPlaces
                End Try
                Try
                    CompDetails.CSTNo = Sreader("CstNo").ToString
                Catch ex As Exception
                    CompDetails.CSTNo = ""
                End Try
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
            SqlConn.Dispose()
        End Try
        DefaultLocation = GetDefLocationName()
        ExecuteSQLQuery("update company set lastaccessdate=CONVERT(datetime,'" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "',101)")
    End Sub
    Public Function GetCurrentBalanceValue(ByVal LedgerName As String, Optional withNagitive As Boolean = False) As Double
        Dim Dramt As Double
        Dramt = SQLGetNumericFieldValue("Select sum(dr-cr) as Dramt from ledgerbook where isdeleted=0 and ledgername=N'" & LedgerName & "'", "dramt")

        If Dramt > 0 Then
            Return Dramt
        Else
            If withNagitive = True Then
                Return Dramt
            Else
                Return Dramt * -1
            End If

        End If

    End Function
    Public Function GetCurrentBalanceText(ByVal LedgerName As String) As String
        Dim Dramt As Double

        Dramt = SQLGetNumericFieldValue("Select sum(dr-cr) as Dramt from ledgerbook where IsDeleted=0 and  ledgername=N'" & LedgerName & "'", "dramt")


        If Dramt > 0 Then
            Return (FormatNumber(Dramt, ErpDecimalPlaces).ToString & " Dr")
        Else
            Return (FormatNumber(Dramt * -1, ErpDecimalPlaces).ToString & " Cr")
        End If

    End Function
    Public Function EncrypPassword(ByVal str As String) As String
        If str.Length = 0 Then
            Return ""
        Else
            Return Crypto.Encrypt(str, "")
        End If

    End Function
    Public Function DecrypPassword(ByVal str As String) As String
        If str.Length = 0 Then
            Return ""
        Else
            Return Crypto.Decrypt(str, "")
        End If
    End Function
    Public Sub GetConnectionStringFromFile()

        Try
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\ConnectionString.dat") = False Then
                MsgBox("The file  ConnectionString.dat could not be read, it may not exists, Please consult your adimn")
                End
            End If
        Catch ex As Exception

        End Try
        If TxtSoftwareSQlServer.Length < 2 Then
            If SqlServersForm.ShowDialog = Windows.Forms.DialogResult.OK Then
                MainForm.Cursor = Cursors.WaitCursor
                ReadSqlSettings()
            Else

                Application.Exit()
            End If
        End If
StartAgain:
        MainForm.Cursor = Cursors.WaitCursor
        ConnectionStringFromFile = ""
        Try
            Using sr As StreamReader = New StreamReader(Application.StartupPath & "\ConnectionString.dat")
                ConnectionStringFromFile = sr.ReadLine()
                If ConnectionStringFromFile = Nothing Then
                    ConnectionStringFromFile = ""
                End If
                sr.Close()
            End Using
        Catch Ex As Exception

        Finally
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&servername&", TxtSoftwareSQlServer)
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&username&", txtSoftwareSQlUserID)
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&password&", TxtSoftwareSQLPassword)
        End Try
        ConnectionStrinG = ConnectionStringFromFile
        If TestSQLConnection() = False Then
            If TxtSoftwareSQlServer.Length < 2 Then
                MainForm.Cursor = Cursors.Default
                If SqlServersForm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    MainForm.Cursor = Cursors.WaitCursor
                    ReadSqlSettings()
                    GoTo StartAgain
                Else
                    End
                End If
            End If
            MainForm.Cursor = Cursors.WaitCursor
            Dim Tempcon As String = ""
            ConnectionStringFromFile = Connectionstrin1
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&servername&", TxtSoftwareSQlServer)
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&username&", txtSoftwareSQlUserID)
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&password&", TxtSoftwareSQLPassword)
            ConnectionStrinG = ConnectionStringFromFile
            If TestSQLConnection() = True Then
                Tempcon = Connectionstrin1
                GoTo Exitlbl
            End If

            ConnectionStringFromFile = Connectionstrin2
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&servername&", TxtSoftwareSQlServer)
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&username&", txtSoftwareSQlUserID)
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&password&", TxtSoftwareSQLPassword)
            ConnectionStrinG = ConnectionStringFromFile
            If TestSQLConnection() = True Then
                Tempcon = Connectionstrin2
                GoTo Exitlbl
            End If

            ConnectionStringFromFile = Connectionstrin3
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&servername&", TxtSoftwareSQlServer)
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&username&", txtSoftwareSQlUserID)
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&password&", TxtSoftwareSQLPassword)
            ConnectionStrinG = ConnectionStringFromFile
            If TestSQLConnection() = True Then
                Tempcon = Connectionstrin3
                GoTo Exitlbl
            End If

            ConnectionStringFromFile = Connectionstrin4
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&servername&", TxtSoftwareSQlServer)
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&username&", txtSoftwareSQlUserID)
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&password&", TxtSoftwareSQLPassword)
            ConnectionStrinG = ConnectionStringFromFile
            If TestSQLConnection() = True Then
                Tempcon = Connectionstrin4
                GoTo Exitlbl
            End If

            ConnectionStringFromFile = Connectionstrin5
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&servername&", TxtSoftwareSQlServer)
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&username&", txtSoftwareSQlUserID)
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&password&", TxtSoftwareSQLPassword)
            ConnectionStrinG = ConnectionStringFromFile
            If TestSQLConnection() = True Then
                Tempcon = Connectionstrin5
                GoTo Exitlbl
            End If

            ConnectionStringFromFile = Connectionstrin6
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&servername&", TxtSoftwareSQlServer)
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&username&", txtSoftwareSQlUserID)
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&password&", TxtSoftwareSQLPassword)
            ConnectionStrinG = ConnectionStringFromFile
            If TestSQLConnection() = True Then
                Tempcon = Connectionstrin6
                GoTo Exitlbl
            End If
            ConnectionStringFromFile = Connectionstrin7
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&servername&", TxtSoftwareSQlServer)
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&username&", txtSoftwareSQlUserID)
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&password&", TxtSoftwareSQLPassword)
            ConnectionStrinG = ConnectionStringFromFile
            If TestSQLConnection() = True Then
                Tempcon = Connectionstrin6
                GoTo Exitlbl
            End If

Exitlbl:
            If Tempcon.Length > 0 Then
                Using sw As StreamWriter = New StreamWriter(Application.StartupPath & "\ConnectionString.dat")
                    sw.WriteLine(Tempcon)
                    sw.Close()
                End Using
            Else
                MainForm.Cursor = Cursors.Default
                If MsgBox("SQL Server Error: User Id or Password invalid or SQL Server is not accessed. ...." & Chr(13) & " Do you want to try again  ?            ", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If SqlServersForm.ShowDialog = Windows.Forms.DialogResult.OK Then
                        MainForm.Cursor = Cursors.WaitCursor
                        ReadSqlSettings()
                        GoTo StartAgain
                    Else
                        Application.Exit()
                    End If
                Else
                    Application.Exit()
                End If


            End If

        End If
        MainForm.Cursor = Cursors.Default

    End Sub
    Public Sub ReadSqlSettings()
        TxtSoftwareSQlServer = ""
        TxtSoftwareSQLIPaddress = ""
        TxtSoftwareSQLPassword = ""
        txtSoftwareSQlUserID = ""
        Try
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\SQLSettings.dat") = False Then
                MsgBox("The file  SQLSettings.dat could not be read, it may not exists, Please consult your adimn")
                End
            End If
        Catch ex As Exception

        End Try

        Try
            Using sr As StreamReader = New StreamReader(Application.StartupPath & "\SQLSettings.dat")
                Dim line As String
                line = sr.ReadLine()
                TxtSoftwareSQlServer = DecrypPassword(line)
                line = sr.ReadLine()
                txtSoftwareSQlUserID = DecrypPassword(line)
                line = sr.ReadLine()
                TxtSoftwareSQLPassword = DecrypPassword(line)
                line = sr.ReadLine()
                TxtSoftwareSQLDatabaseName = DecrypPassword(line)
                sr.Close()
            End Using
        Catch Ex As Exception

        Finally

        End Try
    End Sub
    Public Sub GetSQLSettingFromFile()
        MainForm.Cursor = Cursors.WaitCursor
        TxtSoftwareSQlServer = ""
        TxtSoftwareSQLIPaddress = ""
        TxtSoftwareSQLPassword = ""
        txtSoftwareSQlUserID = ""

        Try
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\SQLSettings.dat") = False Then
                Dim fs As FileStream = File.Create(Application.StartupPath & "\SQLSettings.dat")
                fs.Close()
                fs = Nothing
                Dim fs2 As FileStream = File.Create(Application.StartupPath & "\ConnectionString.dat")
                fs2.Close()
                fs2 = Nothing
                'MsgBox("The file  SQLSettings.dat could not be read, it may not exists, Please consult your adimn")
                'End
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("Please Install The application in other than OS Drive (Exampel D: Drive) ")
        End Try

        Try
            Using sr As StreamReader = New StreamReader(Application.StartupPath & "\SQLSettings.dat")
                Dim line As String
                line = sr.ReadLine()
                If line = Nothing Then
                    TxtSoftwareSQlServer = ""
                Else
                    TxtSoftwareSQlServer = DecrypPassword(line)
                End If

                line = sr.ReadLine()
                If line = Nothing Then
                    txtSoftwareSQlUserID = ""
                Else
                    txtSoftwareSQlUserID = DecrypPassword(line)
                End If

                line = sr.ReadLine()
                If line = Nothing Then
                    TxtSoftwareSQLPassword = ""
                Else
                    TxtSoftwareSQLPassword = DecrypPassword(line)
                End If

                line = sr.ReadLine()
                If line = Nothing Then
                    TxtSoftwareSQLDatabaseName = ""
                Else
                    TxtSoftwareSQLDatabaseName = DecrypPassword(line)
                End If

                sr.Close()
            End Using
        Catch Ex As Exception

        Finally
            GetConnectionStringFromFile()
        End Try
        MainForm.Cursor = Cursors.Default
    End Sub
    Public Function GetIDCode(ByVal Idno As EnumIDType) As String
        Dim Sqlstr As String = ""
        If Idno = EnumIDType.CustomerID Then
            Sqlstr = "CUST" & SQLGetNumericFieldValue("Select custid from IDsettings", "custid").ToString

        ElseIf Idno = EnumIDType.EmployeeID Then
            Sqlstr = "EMP" & SQLGetNumericFieldValue("Select EmployeeID from IDsettings", "EmployeeID").ToString
        ElseIf Idno = EnumIDType.Accounts Then

            Sqlstr = "ACC" & SQLGetNumericFieldValue("Select AccountCode from IDsettings", "AccountCode").ToString
        ElseIf Idno = EnumIDType.SupplierID Then
            Sqlstr = "SUP" & SQLGetNumericFieldValue("Select supid from IDsettings", "supid").ToString

        ElseIf Idno = EnumIDType.EmployeePErID Then
            Sqlstr = "EMPP" & SQLGetNumericFieldValue("Select EmployeePerID from IDsettings", "EmployeePerID").ToString

        ElseIf Idno = EnumIDType.SalesPersonID Then
            Sqlstr = "SAP" & SQLGetNumericFieldValue("Select salespersonsID from IDsettings", "salespersonsID").ToString

        ElseIf Idno = EnumIDType.TransCode Then
            Sqlstr = SQLGetNumericFieldValue("Select TransCode from IDsettings", "TransCode").ToString



        ElseIf Idno = EnumIDType.Barcode128 Then
            Sqlstr = SQLGetNumericFieldValue("Select Barcode128 from IDsettings", "Barcode128").ToString

        ElseIf Idno = EnumIDType.BarcodeENA Then
            Sqlstr = SQLGetNumericFieldValue("Select BarCodeEna8 from IDsettings", "BarCodeEna8").ToString

        ElseIf Idno = EnumIDType.AreaCode Then
            Sqlstr = "AR" & SQLGetNumericFieldValue("Select AreaID from IDsettings", "AreaID").ToString
        ElseIf Idno = EnumIDType.StockCode Then
            Sqlstr = "ITEM" & SQLGetNumericFieldValue("Select Stockcode from IDsettings", "Stockcode").ToString
        ElseIf Idno = EnumIDType.LogFileID Then
            Sqlstr = "ITEM" & SQLGetNumericFieldValue("Select logfileid from IDsettings", "logfileid").ToString
        ElseIf Idno = EnumIDType.lOCKTRANSCODE Then
            Sqlstr = SQLGetNumericFieldValue("Select LockTransCode from IDsettings", "LockTransCode").ToString
        ElseIf Idno = EnumIDType.Bill2BillCode Then
            Sqlstr = SQLGetNumericFieldValue("Select BillTranscode from IDsettings", "BillTranscode").ToString
        ElseIf Idno = EnumIDType.UserTransID Then
            Sqlstr = SQLGetNumericFieldValue("Select UserTransCode from IDsettings", "UserTransCode").ToString
        ElseIf Idno = EnumIDType.AssetID Then
            Sqlstr = "AS" & SQLGetNumericFieldValue("Select AssetID from IDsettings", "AssetID").ToString
        ElseIf Idno = EnumIDType.BudgetID Then
            Sqlstr = "BD" & SQLGetNumericFieldValue("Select BudgetID from IDsettings", "BudgetID").ToString
            'LockTransCode
        End If

        Return Sqlstr
    End Function
    Public Function GetAndSetIDCode(ByVal Idno As EnumIDType) As String
        Dim Sqlstr As String = ""
        Dim s As String = ""
        s = CurrentUserName.Replace(" ", "")


        If Idno = EnumIDType.CustomerID Then
            Sqlstr = "CUST" & SQLGetNumericFieldValue(" BEGIN TRANSACTION " & s & "t1; Select * from IDsettings; update Idsettings set custid=custid+1 where id=1 ; COMMIT  TRANSACTION " & s & "t1;", "custid").ToString


        ElseIf Idno = EnumIDType.EmployeeID Then
            Sqlstr = "EMP" & SQLGetNumericFieldValue(" BEGIN TRANSACTION " & s & "t1; Select * from IDsettings; update Idsettings set EmployeeID=EmployeeID+1 where id=1 ; COMMIT  TRANSACTION " & s & "t1;", "EmployeeID").ToString

        ElseIf Idno = EnumIDType.Accounts Then
            Sqlstr = "ACC" & SQLGetNumericFieldValue(" BEGIN TRANSACTION " & s & "t1; Select * from IDsettings; update Idsettings set AccountCode=AccountCode+1 where id=1 ; COMMIT  TRANSACTION " & s & "t1;", "AccountCode").ToString


        ElseIf Idno = EnumIDType.SupplierID Then
            Sqlstr = "SUP" & SQLGetNumericFieldValue(" BEGIN TRANSACTION " & s & "t1; Select * from IDsettings; update Idsettings set supid=supid+1 where id=1 ; COMMIT  TRANSACTION " & s & "t1;", "supid").ToString


        ElseIf Idno = EnumIDType.EmployeePErID Then
            Sqlstr = "EMPP" & SQLGetNumericFieldValue(" BEGIN TRANSACTION " & s & "t1; Select * from IDsettings; update Idsettings set EmployeePerID=EmployeePerID+1 where id=1 ; COMMIT  TRANSACTION " & s & "t1;", "EmployeePerID").ToString


        ElseIf Idno = EnumIDType.SalesPersonID Then
            Sqlstr = "SAP" & SQLGetNumericFieldValue(" BEGIN TRANSACTION " & s & "t1; Select * from IDsettings; update Idsettings set salespersonsID=salespersonsID+1 where id=1 ; COMMIT  TRANSACTION " & s & "t1;", "salespersonsID").ToString


        ElseIf Idno = EnumIDType.TransCode Then
            Sqlstr = SQLGetNumericFieldValue(" BEGIN TRANSACTION " & s & "t1; Select * from IDsettings; update Idsettings set TransCode=TransCode+1 where id=1 ; COMMIT  TRANSACTION " & s & "t1;", "TransCode").ToString
            'NEED TO COMMENT

            'Try
            '    If CDbl(Sqlstr) > 2000 Then
            '        End
            '    End If
            'Catch ex As Exception

            'End Try

            'END OF COMMENT
        ElseIf Idno = EnumIDType.Barcode128 Then
            Sqlstr = SQLGetNumericFieldValue(" BEGIN TRANSACTION " & s & "t1; Select * from IDsettings; update Idsettings set Barcode128=Barcode128+1 where id=1 ; COMMIT  TRANSACTION " & s & "t1;", "Barcode128").ToString


        ElseIf Idno = EnumIDType.BarcodeENA Then
            Sqlstr = SQLGetNumericFieldValue(" BEGIN TRANSACTION " & s & "t1; Select * from IDsettings; update Idsettings set BarCodeEna8=BarCodeEna8+1 where id=1 ; COMMIT  TRANSACTION " & s & "t1;", "BarCodeEna8").ToString


        ElseIf Idno = EnumIDType.AreaCode Then
            Sqlstr = "AR" & SQLGetNumericFieldValue(" BEGIN TRANSACTION " & s & "t1; Select * from IDsettings; update Idsettings set AreaID=AreaID+1 where id=1 ; COMMIT  TRANSACTION " & s & "t1;", "AreaID").ToString

        ElseIf Idno = EnumIDType.StockCode Then
            Sqlstr = "ITEM" & SQLGetNumericFieldValue(" BEGIN TRANSACTION " & s & "t1; Select * from IDsettings; update Idsettings set StockCode=StockCode+1 where id=1 ; COMMIT  TRANSACTION " & s & "t1;", "StockCode").ToString

        ElseIf Idno = EnumIDType.LogFileID Then
            Sqlstr = SQLGetNumericFieldValue(" BEGIN TRANSACTION " & s & "t1; Select * from IDsettings; update Idsettings set logfileid=logfileid+1 where id=1 ; COMMIT  TRANSACTION " & s & "t1;", "logfileid").ToString


        ElseIf Idno = EnumIDType.lOCKTRANSCODE Then
            Sqlstr = SQLGetNumericFieldValue(" BEGIN TRANSACTION " & s & "t1; Select * from IDsettings; update Idsettings set LockTransCode=LockTransCode+1 where id=1 ; COMMIT  TRANSACTION " & s & "t1;", "LockTransCode").ToString

        ElseIf Idno = EnumIDType.Bill2BillCode Then
            Sqlstr = SQLGetNumericFieldValue(" BEGIN TRANSACTION " & s & "t1; Select * from IDsettings; update Idsettings set BillTranscode=BillTranscode+1 where id=1 ; COMMIT  TRANSACTION " & s & "t1;", "BillTranscode").ToString

        ElseIf Idno = EnumIDType.UserTransID Then
            Sqlstr = SQLGetNumericFieldValue(" BEGIN TRANSACTION " & s & "t1; Select * from IDsettings; update Idsettings set UserTransCode=UserTransCode+1 where id=1 ; COMMIT  TRANSACTION " & s & "t1;", "UserTransCode").ToString

        ElseIf Idno = EnumIDType.AssetID Then
            Sqlstr = "AS" & SQLGetNumericFieldValue(" BEGIN TRANSACTION " & s & "t1; Select * from IDsettings; update Idsettings set AssetID=AssetID+1 where id=1 ; COMMIT  TRANSACTION " & s & "t1;", "AssetID").ToString

        ElseIf Idno = EnumIDType.BudgetID Then
            Sqlstr = "BD" & SQLGetNumericFieldValue(" BEGIN TRANSACTION " & s & "t1; Select * from IDsettings; update Idsettings set BudgetID=BudgetID+1 where id=1 ; COMMIT  TRANSACTION " & s & "t1;", "BudgetID").ToString
        End If
        Return Sqlstr
    End Function

    Public Function GetInvVhNumber(ByVal invtype As InvoiceNoStrct) As String
        Dim iNVNO As String = ""
        Dim BranchName As String = GetLocation()

        If invtype = InvoiceNoStrct.contravoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='CON' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.journalvoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='JOUR' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.paymnetvoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PAY' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.purchaseinvoice Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PI' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.purchaseorder Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PO' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.purchasequoto Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PQ' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.purchasereceived Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PG' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.purchasereturnvoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PRV' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.purchasevoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PV' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.receiptvoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='REC' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.salesdelavery Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SD' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.salesinvoice Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SI' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.salesorder Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SO' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.salesquoto Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SQ' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.salesreturnvoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SRV' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.salesvoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SV' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.SalesRetInvoice Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SR' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.PurchaseRetInvoice Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PR' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.POS Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='POS' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.Payroll Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PAY' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.STOCKJOURNAL Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SJ' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.FORM8 Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='F8' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.FORM8B Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='F8B' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.FORM8D Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='F8D' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.SRFORM8 Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SRF8' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.SRFORM8B Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SRF8B' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.SRFORM8D Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SRF8D' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.CASHSALES Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='cashsales' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.CREDITSALES Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='creditsales' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.CASHPURCHASE Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='cashpurchase' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.CREDITPURCHASE Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='creditpurchase' and location=N'" & BranchName & "'")

        End If
        Return iNVNO
    End Function

    Public Function GetAndSetInvoiceNumber(ByVal invtype As InvoiceNoStrct) As String
        Dim iNVNO As String = ""
        Dim BranchName As String = GetLocation()
        If invtype = InvoiceNoStrct.contravoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='CON' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='CON' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.journalvoucher Then

            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='JOUR' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='JOUR' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.paymnetvoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PAY' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='PAY' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.purchaseinvoice Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PI' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='PI' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.purchaseorder Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PO' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='PO' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.purchasequoto Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PQ' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='PQ' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.purchasereceived Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PG' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='PG' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.purchasereturnvoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PRV' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='PRV' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.purchasevoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PV' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='PV' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.receiptvoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='REC' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='REC' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.salesdelavery Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SD' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='SD' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.salesinvoice Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SI' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='SI' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.salesorder Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SO' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='SO' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.salesquoto Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SQ' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='SQ' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.salesreturnvoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SRV' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='SRV' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.salesvoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SV' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='SV' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.SalesRetInvoice Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SR' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='SR' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.PurchaseRetInvoice Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PR' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='PR' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.POS Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='POS' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='POS' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.Payroll Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PAY' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='PAY' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.STOCKJOURNAL Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SJ' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='SJ' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.FORM8 Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='F8' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='F8' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.FORM8B Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='F8B' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='F8B' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.FORM8D Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='F8D' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='F8D' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.SRFORM8 Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SRF8' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='SRF8' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.SRFORM8B Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SRF8B' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='SRF8B' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.SRFORM8D Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SRF8D' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='SRF8D' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.CASHSALES Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='cashsales' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='cashsales' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.CREDITSALES Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='creditsales' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='creditsales' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.CASHPURCHASE Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='cashpurchase' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='cashpurchase' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.CREDITPURCHASE Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='creditpurchase' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=InvoiceNumber+1  WHERE VOUCHERNAME='creditpurchase' and location=N'" & BranchName & "'")

        End If
        Return iNVNO

    End Function

    Public Function SetInvoiceNumber(ByVal invtype As InvoiceNoStrct, ByVal invoiceno As Long) As String
        Dim iNVNO As String = ""
        Dim BranchName As String = GetLocation()
        If invtype = InvoiceNoStrct.contravoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='CON' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "   WHERE VOUCHERNAME='CON' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.journalvoucher Then

            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='JOUR' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='JOUR' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.paymnetvoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PAY' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='PAY' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.purchaseinvoice Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PI' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='PI' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.purchaseorder Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PO' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='PO' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.purchasequoto Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PQ' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='PQ' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.purchasereceived Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PG' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='PG' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.purchasereturnvoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PRV' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='PRV' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.purchasevoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PV' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='PV' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.receiptvoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='REC' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='REC' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.salesdelavery Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SD' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='SD' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.salesinvoice Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SI' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='SI' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.salesorder Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SO' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='SO' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.salesquoto Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SQ' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='SQ' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.salesreturnvoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SRV' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='SRV' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.salesvoucher Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SV' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='SV' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.SalesRetInvoice Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SR' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='SR' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.PurchaseRetInvoice Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PR' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='PR' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.POS Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='POS' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='POS' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.Payroll Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='PAY' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='PAY' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.STOCKJOURNAL Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SJ' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='SJ' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.FORM8 Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='F8' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='F8' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.FORM8B Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='F8B' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='F8B' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.FORM8D Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='F8D' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='F8D' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.SRFORM8 Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SRF8' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='SRF8' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.SRFORM8B Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SRF8B' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='SRF8B' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.SRFORM8D Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='SRF8D' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='SRF8D' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.CASHSALES Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='cashsales' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='cashsales' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.CREDITSALES Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='creditsales' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='creditsales' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.CASHPURCHASE Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='cashpurchase' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='cashpurchase' and location=N'" & BranchName & "'")
        ElseIf invtype = InvoiceNoStrct.CREDITPURCHASE Then
            iNVNO = SQLExecuteQueryForInvoiceNumber("SELECT  *  from invoicesettings WHERE VOUCHERNAME='creditpurchase' and location=N'" & BranchName & "'")
            ExecuteSQLQuery("update invoicesettings set InvoiceNumber=" & invoiceno.ToString & "  WHERE VOUCHERNAME='creditpurchase' and location=N'" & BranchName & "'")

        End If
        Return iNVNO

    End Function
    Public Sub LoadInvoiceBillingSettings()
        Dim SqlConn As New SqlClient.SqlConnection

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='CON' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()

                InvoiceBillingSettings.ContraSettings.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.ContraSettings.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.ContraSettings.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.ContraSettings.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.ContraSettings.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.ContraSettings.PrintonSave = CInt(Sreader("PrintonSave"))

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try


        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='JOUR' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                InvoiceBillingSettings.JournalSettings.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.JournalSettings.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.JournalSettings.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.JournalSettings.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.JournalSettings.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.JournalSettings.PrintonSave = CInt(Sreader("PrintonSave"))

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='PAY' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                InvoiceBillingSettings.PaymentSettings.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.PaymentSettings.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.PaymentSettings.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.PaymentSettings.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.PaymentSettings.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.PaymentSettings.PrintonSave = CInt(Sreader("PrintonSave"))
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='PI' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                InvoiceBillingSettings.PurchaseInvoicesetting.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.PurchaseInvoicesetting.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.PurchaseInvoicesetting.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.PurchaseInvoicesetting.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.PurchaseInvoicesetting.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.PurchaseInvoicesetting.PrintonSave = CInt(Sreader("PrintonSave"))
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='PO' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                InvoiceBillingSettings.PurchaseOrderSettings.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.PurchaseOrderSettings.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.PurchaseOrderSettings.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.PurchaseOrderSettings.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.PurchaseOrderSettings.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.PurchaseOrderSettings.PrintonSave = CInt(Sreader("PrintonSave"))
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='PR' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                InvoiceBillingSettings.PurchaseReturnInvoiceSettings.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.PurchaseReturnInvoiceSettings.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.PurchaseReturnInvoiceSettings.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.PurchaseReturnInvoiceSettings.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.PurchaseReturnInvoiceSettings.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.PurchaseReturnInvoiceSettings.PrintonSave = CInt(Sreader("PrintonSave"))
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='REC' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                InvoiceBillingSettings.ReceiptSettings.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.ReceiptSettings.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.ReceiptSettings.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.ReceiptSettings.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.ReceiptSettings.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.ReceiptSettings.PrintonSave = CInt(Sreader("PrintonSave"))
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='SI' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                InvoiceBillingSettings.SalesInvoiceSettings.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.SalesInvoiceSettings.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.SalesInvoiceSettings.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.SalesInvoiceSettings.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.SalesInvoiceSettings.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.SalesInvoiceSettings.PrintonSave = CInt(Sreader("PrintonSave"))
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='SO' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                InvoiceBillingSettings.SalesOrderSettings.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.SalesOrderSettings.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.SalesOrderSettings.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.SalesOrderSettings.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.SalesOrderSettings.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.SalesOrderSettings.PrintonSave = CInt(Sreader("PrintonSave"))
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='SR' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                InvoiceBillingSettings.SalesReturnInvoiceSettings.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.SalesReturnInvoiceSettings.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.SalesReturnInvoiceSettings.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.SalesReturnInvoiceSettings.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.SalesReturnInvoiceSettings.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.SalesReturnInvoiceSettings.PrintonSave = CInt(Sreader("PrintonSave"))
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try


        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='SQ' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                InvoiceBillingSettings.SalesQutoSetting.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.SalesQutoSetting.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.SalesQutoSetting.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.SalesQutoSetting.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.SalesQutoSetting.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.SalesQutoSetting.PrintonSave = CInt(Sreader("PrintonSave"))
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='SD' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                InvoiceBillingSettings.SalesDelavarySettings.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.SalesDelavarySettings.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.SalesDelavarySettings.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.SalesDelavarySettings.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.SalesDelavarySettings.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.SalesDelavarySettings.PrintonSave = CInt(Sreader("PrintonSave"))
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='PQ' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                InvoiceBillingSettings.PurchaseQutoSettings.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.PurchaseQutoSettings.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.PurchaseQutoSettings.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.PurchaseQutoSettings.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.PurchaseQutoSettings.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.PurchaseQutoSettings.PrintonSave = CInt(Sreader("PrintonSave"))
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='PG' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                InvoiceBillingSettings.PurchaseGoodReceivedSettings.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.PurchaseGoodReceivedSettings.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.PurchaseGoodReceivedSettings.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.PurchaseGoodReceivedSettings.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.PurchaseGoodReceivedSettings.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.PurchaseGoodReceivedSettings.PrintonSave = CInt(Sreader("PrintonSave"))
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='SV' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                InvoiceBillingSettings.SalesVoucher.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.SalesVoucher.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.SalesVoucher.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.SalesVoucher.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.SalesVoucher.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.SalesVoucher.PrintonSave = CInt(Sreader("PrintonSave"))
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='SRV' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                InvoiceBillingSettings.SalesReturnVoucher.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.SalesReturnVoucher.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.SalesReturnVoucher.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.SalesReturnVoucher.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.SalesReturnVoucher.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.SalesReturnVoucher.PrintonSave = CInt(Sreader("PrintonSave"))
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='POS' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                InvoiceBillingSettings.POS.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.POS.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.POS.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.POS.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.POS.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.POS.PrintonSave = CInt(Sreader("PrintonSave"))
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try




        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='PV' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                InvoiceBillingSettings.PurchaseVoucher.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.PurchaseVoucher.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.PurchaseVoucher.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.PurchaseVoucher.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.PurchaseVoucher.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.PurchaseVoucher.PrintonSave = CInt(Sreader("PrintonSave"))
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='PRV' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                InvoiceBillingSettings.PurchaseReturnVoucher.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.PurchaseReturnVoucher.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.PurchaseReturnVoucher.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.PurchaseReturnVoucher.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.PurchaseReturnVoucher.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.PurchaseReturnVoucher.PrintonSave = CInt(Sreader("PrintonSave"))
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='SJ' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()

                InvoiceBillingSettings.JournalSettings.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.JournalSettings.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.JournalSettings.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.JournalSettings.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.JournalSettings.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.JournalSettings.PrintonSave = CInt(Sreader("PrintonSave"))

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try


        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='CashSales' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()

                InvoiceBillingSettings.CashSalesInvoicesetting.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.CashSalesInvoicesetting.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.CashSalesInvoicesetting.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.CashSalesInvoicesetting.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.CashSalesInvoicesetting.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.CashSalesInvoicesetting.PrintonSave = CInt(Sreader("PrintonSave"))

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='CreditSales' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()

                InvoiceBillingSettings.CreditSalesInvoicesetting.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.CreditSalesInvoicesetting.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.CreditSalesInvoicesetting.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.CreditSalesInvoicesetting.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.CreditSalesInvoicesetting.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.CreditSalesInvoicesetting.PrintonSave = CInt(Sreader("PrintonSave"))

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='CashPurchase' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()

                InvoiceBillingSettings.CashPurchaseInvoicesetting.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.CashPurchaseInvoicesetting.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.CashPurchaseInvoicesetting.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.CashPurchaseInvoicesetting.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.CashPurchaseInvoicesetting.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.CashPurchaseInvoicesetting.PrintonSave = CInt(Sreader("PrintonSave"))

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='CreditPurchase' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()

                InvoiceBillingSettings.CreditPurchaseInvoicesetting.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.CreditPurchaseInvoicesetting.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.CreditPurchaseInvoicesetting.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.CreditPurchaseInvoicesetting.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.CreditPurchaseInvoicesetting.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.CreditPurchaseInvoicesetting.PrintonSave = CInt(Sreader("PrintonSave"))

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='F8' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()

                InvoiceBillingSettings.Form8SalesInvoicesetting.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.Form8SalesInvoicesetting.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.Form8SalesInvoicesetting.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.Form8SalesInvoicesetting.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.Form8SalesInvoicesetting.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.Form8SalesInvoicesetting.PrintonSave = CInt(Sreader("PrintonSave"))

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='F8B' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()

                InvoiceBillingSettings.Form8BSalesInvoicesetting.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.Form8BSalesInvoicesetting.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.Form8BSalesInvoicesetting.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.Form8BSalesInvoicesetting.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.Form8BSalesInvoicesetting.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.Form8BSalesInvoicesetting.PrintonSave = CInt(Sreader("PrintonSave"))

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='F8D' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()

                InvoiceBillingSettings.Form8DSalesInvoicesetting.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.Form8DSalesInvoicesetting.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.Form8DSalesInvoicesetting.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.Form8DSalesInvoicesetting.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.Form8DSalesInvoicesetting.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.Form8DSalesInvoicesetting.PrintonSave = CInt(Sreader("PrintonSave"))

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='SRF8' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()

                InvoiceBillingSettings.Form8SalesRETInvoicesetting.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.Form8SalesRETInvoicesetting.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.Form8SalesRETInvoicesetting.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.Form8SalesRETInvoicesetting.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.Form8SalesRETInvoicesetting.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.Form8SalesRETInvoicesetting.PrintonSave = CInt(Sreader("PrintonSave"))

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try
        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='SRF8B' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()

                InvoiceBillingSettings.Form8BSalesRETInvoicesetting.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.Form8BSalesRETInvoicesetting.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.Form8BSalesRETInvoicesetting.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.Form8BSalesRETInvoicesetting.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.Form8BSalesRETInvoicesetting.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.Form8BSalesRETInvoicesetting.PrintonSave = CInt(Sreader("PrintonSave"))

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from INVOICESETTINGS WHERE VOUCHERNAME='SRF8D' and location=N'" & GetLocation() & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()

                InvoiceBillingSettings.Form8DSalesRETInvoicesetting.InvoiceMethod = CInt(Sreader("InvoiceMethod"))
                InvoiceBillingSettings.Form8DSalesRETInvoicesetting.IsAllowDuplicates = CInt(Sreader("AllowDuplicate"))
                InvoiceBillingSettings.Form8DSalesRETInvoicesetting.PrintingScheme1 = Sreader("PrintingScheme1").ToString.Trim()
                InvoiceBillingSettings.Form8DSalesRETInvoicesetting.PrintingScheme2 = Sreader("PrintingScheme2").ToString.Trim()
                InvoiceBillingSettings.Form8DSalesRETInvoicesetting.PrintingScheme3 = Sreader("PrintingScheme3").ToString.Trim()
                InvoiceBillingSettings.Form8DSalesRETInvoicesetting.PrintonSave = CInt(Sreader("PrintonSave"))

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try
        SqlConn.Dispose()
    End Sub
    Public Function GetProfitLossAcValues(ByVal isdatewiseon As CheckBox, ByVal txtstartdate As DateTimePicker, ByVal txtenddate As DateTimePicker, Optional ByRef GrossProfitVal As Double = 0) As Double
        Dim VALUE As Double = 0

        Dim opvalue As Double = 0
        Dim purvalue As Double = 0
        Dim clvalue As Double = 0
        Dim salvalue As Double = 0
        Dim DExpenses As Double = 0
        Dim DIncomes As Double = 0
        Dim Expense As Double = 0
        Dim Incomes As Double = 0

        opvalue = SQLGetNumericFieldValue("select SUM(OpTotalQty * opStockRate / UnitCon) AS tot from stockdbf where stocktype=0", "tot")
        If isdatewiseon.Checked = True Then
            purvalue = SQLGetNumericFieldValue("select SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "')))  and (Transdatevalue between " & (CDbl(txtstartdate.Value.Date.ToOADate)) & " and " & (CDbl(txtenddate.Value.Date.ToOADate)) & ") ", "tot")
        Else
            purvalue = SQLGetNumericFieldValue("select SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "'))) ", "tot")
        End If

        'CALCULATE PURCHASE ACCOUNTS
        If isdatewiseon.Checked = True Then
            salvalue = SQLGetNumericFieldValue("select SUM(CR-Dr) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "')))  and (Transdatevalue between " & (CDbl(txtstartdate.Value.Date.ToOADate)) & " and " & (CDbl(txtenddate.Value.Date.ToOADate)) & ")", "tot")
        Else
            salvalue = SQLGetNumericFieldValue("select SUM(CR-Dr) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "'))) ", "tot")
        End If
        clvalue = SQLGetNumericFieldValue("select sum(stockrate*(totalqty)/unitcon) as tot from stockdbf where stocktype=0", "tot")

        Dim ISlOSS As Boolean = False
        Dim grossprofitlosstotal As Double = 0
        If isdatewiseon.Checked = True Then
            DExpenses = SQLGetNumericFieldValue("select SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.DirectExpenses & "')))  and (Transdatevalue between " & (CDbl(txtstartdate.Value.Date.ToOADate)) & " and " & (CDbl(txtenddate.Value.Date.ToOADate)) & ")", "tot")
            DIncomes = SQLGetNumericFieldValue("select SUM(CR-DR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.DirectIncomes & "')))  and (Transdatevalue between " & (CDbl(txtstartdate.Value.Date.ToOADate)) & " and " & (CDbl(txtenddate.Value.Date.ToOADate)) & ")", "tot")
            Expense = SQLGetNumericFieldValue("select SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "')))   and (Transdatevalue between " & (CDbl(txtstartdate.Value.Date.ToOADate)) & " and " & (CDbl(txtenddate.Value.Date.ToOADate)) & ")", "tot")
            Incomes = SQLGetNumericFieldValue("select SUM(CR-dr) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectIncomes & "')))   and (Transdatevalue between " & (CDbl(txtstartdate.Value.Date.ToOADate)) & " and " & (CDbl(txtenddate.Value.Date.ToOADate)) & ")", "tot")

        Else
            DExpenses = SQLGetNumericFieldValue("select SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.DirectExpenses & "'))) ", "tot")
            DIncomes = SQLGetNumericFieldValue("select SUM(CR-DR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.DirectIncomes & "'))) ", "tot")
            Expense = SQLGetNumericFieldValue("select SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "'))) ", "tot")
            Incomes = SQLGetNumericFieldValue("select SUM(CR-dr) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectIncomes & "'))) ", "tot")

        End If
        Dim Opgrossprofitlosstotal As Double = 0

        Dim st As String = ""
        If isdatewiseon.Checked = True Then
            st = "select  SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.ProfitLossAccounts & "')))  and (Transdatevalue between " & (CDbl(txtstartdate.Value.Date.ToOADate)) & " and " & (CDbl(txtenddate.Value.Date.ToOADate)) & ") "
            Opgrossprofitlosstotal = SQLGetNumericFieldValue(st, "tot")
        Else
            st = "select  SUM(DR-CR) AS TOT FROM LEDGERBOOK WHERE isdeleted=0 and ledgername in (SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.ProfitLossAccounts & "')))"
            Opgrossprofitlosstotal = SQLGetNumericFieldValue(st, "tot")
        End If
        If Opgrossprofitlosstotal >= 0 Then
            If salvalue + DIncomes + clvalue + Opgrossprofitlosstotal >= opvalue + purvalue + DExpenses Then
                grossprofitlosstotal = (salvalue + DIncomes + clvalue + Opgrossprofitlosstotal) - (opvalue + purvalue + DExpenses)
                ISlOSS = False
            Else
                grossprofitlosstotal = (opvalue + purvalue + DExpenses) - (salvalue + DIncomes + clvalue + Opgrossprofitlosstotal)
                ISlOSS = True
            End If
        Else
            If salvalue + DIncomes + clvalue >= opvalue + purvalue + DExpenses + Opgrossprofitlosstotal Then
                grossprofitlosstotal = (salvalue + DIncomes + clvalue) - (opvalue + purvalue + DExpenses + Opgrossprofitlosstotal)
                ISlOSS = False
            Else
                grossprofitlosstotal = (opvalue + purvalue + DExpenses + Opgrossprofitlosstotal) - (salvalue + DIncomes + clvalue)
                ISlOSS = True
            End If
        End If




        'FOR INDIRECT EXPENSES AND INCOMES ROWS

        GrossProfitVal = grossprofitlosstotal
        If ISlOSS = False Then
            'FOR PROFIT
            Return (grossprofitlosstotal + Incomes - Expense)
        Else
            'FOR LOSS
            Return (grossprofitlosstotal + Expense - Incomes) * -1
        End If
    End Function
    Public Sub ERPInitializeObjects(ByRef sender As Object, Optional ByVal F1 As String = "", Optional ByVal F2 As String = "", Optional ByVal N1 As Double = 0)
        'YOU CAN CHANGE THE LAYOUT COLORS OR LABEL FONTS AND MORE 
        Try
            ' sender.font = New Font("ARIAL", 6.25, FontStyle.Bold)
            'For i As Integer = 0 To sender.controls.count - 1
            '    If TypeOf (sender.controls(i)) Is IMSlabel Then
            '        sender.controls(i).forecolor = Color.Red
            '    End If



            'Next


        Catch ex As Exception

        End Try
        Try
            ' sender.BackColor = Color.MintCream
        Catch ex As Exception

        End Try

    End Sub

    Public Function GetFormColorName() As Color
        'Return MainForm.BackColor
        Return Color.Bisque
    End Function



    Public Function GetCustBarCodeForNewStockItem() As String
        Dim Bcode As String = ""
        While True
            Bcode = ReplaceZerosToBarcode(SQLGetStringFieldValue("select BarCodeEna8 from IDsettings", "BarCodeEna8"))
            If SQLIsFieldExists("select custbarcode from stockdbf where custbarcode=N'" & Bcode & "'") = False Then
                Exit While
            Else
                ExecuteSQLQuery("UPDATE IDsettings SET BarCodeEna8=BarCodeEna8+1 where id=1")
            End If
        End While
        Return Bcode
    End Function

    Public Function GetAndSetCustBarCodeForNewStockItem() As String
        Dim Bcode As String = ""
        While True
            Bcode = ReplaceZerosToBarcode(SQLGetStringFieldValue("select BarCodeEna8 from IDsettings", "BarCodeEna8"))
            If SQLIsFieldExists("select custbarcode from stockdbf where custbarcode=N'" & Bcode & "'") = False Then
                ExecuteSQLQuery("UPDATE IDsettings SET BarCodeEna8=BarCodeEna8+1 where id=1")
                Exit While
            Else
                ExecuteSQLQuery("UPDATE IDsettings SET BarCodeEna8=BarCodeEna8+1 where id=1")
            End If
        End While
        Return Bcode
    End Function
    Public Function GetBarCodeForNewStockItem() As String
        Dim Bcode As String = ""
        While True
            Bcode = ReplaceZerosToBarcode(SQLGetStringFieldValue("select Barcode128 from IDsettings", "Barcode128"))
            If SQLIsFieldExists("select custbarcode from stockdbf where custbarcode=N'" & Bcode & "'") = False Then
                Exit While
            Else
                ExecuteSQLQuery("UPDATE IDsettings SET Barcode128=Barcode128+1 where id=1")
            End If
        End While
        Return Bcode
    End Function

    Public Function GetAndSetBarCodeForNewStockItem() As String
        Dim Bcode As String = ""
        While True
            Bcode = ReplaceZerosToBarcode(SQLGetStringFieldValue("select Barcode128 from IDsettings", "Barcode128"))
            If SQLIsFieldExists("select custbarcode from stockdbf where custbarcode=N'" & Bcode & "'") = False Then
                ExecuteSQLQuery("UPDATE IDsettings SET Barcode128=Barcode128+1 where id=1")
                Exit While
            Else
                ExecuteSQLQuery("UPDATE IDsettings SET Barcode128=Barcode128+1 where id=1")

            End If
        End While
        Return Bcode
    End Function

    Private Function DisplayImages(ByVal row As DataRow, ByVal Img As String, ByVal path As String) As Byte()
        Dim stream As New FileStream(path, FileMode.Open, FileAccess.Read)
        Dim ImgData As Byte() = New Byte(stream.Length - 1) {}
        stream.Read(ImgData, 0, Convert.ToInt32(stream.Length))
        stream.Close()
        stream.Dispose()
        Return ImgData
    End Function

    Public Function GetImageToDataTableColum(ByVal filepath As String) As Byte()
        Try
            Dim fs As New FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Dim ImgData As Byte() = New Byte(fs.Length - 1) {}
            fs.Read(ImgData, 0, Convert.ToInt32(fs.Length))
            fs.Close()
            fs.Dispose()
            Return ImgData
        Catch ex As Exception

            Return Nothing
        End Try
    End Function
    Function GetHDDSErialNumber(ByVal drvpath As String, ByVal defvalue As String) As String
        Try
            Dim fso, d
            fso = CreateObject("Scripting.FileSystemObject")
            d = fso.GetDrive(fso.GetDriveName(fso.GetAbsolutePathName(drvpath)))

            Return d.SerialNumber.ToString
        Catch ex As Exception
            Return defvalue
        End Try
    End Function
    Sub SaveAttachment(ByVal filename As String, ByVal fieldname As String, ByVal filesize As Double, ByVal tablename As String, ByVal idcode As String)

        Try
            Dim objFileStream As New FileStream(filename, FileMode.Open, FileAccess.Read)
            Dim intLength As Integer = Convert.ToInt32(objFileStream.Length)
            Dim objData As Byte()
            objData = New Byte(intLength - 1) {}
            Dim strPath As String() = filename.Split(Convert.ToChar("\"))
            objFileStream.Read(objData, 0, intLength)
            objFileStream.Close()

            Dim SqlStr As String = "update asset set ud4=@FiledFileName, filename=@filename  where assetname=N'" & idcode & "'"

            Try
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
                With DBF.Parameters
                    .AddWithValue("FiledFileName", objData)
                    .AddWithValue("filename", strPath(strPath.Length - 1))
                End With
                DBF.ExecuteNonQuery()
                DBF = Nothing
                MAINCON.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex3 As Exception
            MsgBox(ex3.Message)
        End Try

    End Sub
    Public Function GetTotalEmpLeaves(ByVal empname As String, ByVal stdate As DateTimePicker, ByVal eddate As DateTimePicker) As Double
        Dim TxtpresentDate As New DateTimePicker
        Dim tot As Double = 0
        TxtpresentDate.Value = stdate.Value
        For i As Integer = 0 To DateDiff(DateInterval.Day, stdate.Value.Date, eddate.Value.Date)
            If SQLIsFieldExists("select empname from empleaves where empname=N'" & empname & "' and (fromdatevalue<=" & TxtpresentDate.Value.Date.ToOADate & " and " & TxtpresentDate.Value.Date.ToOADate & "<=todatevalue)") = True Then
                tot = tot + 1
            End If
            TxtpresentDate.Value = TxtpresentDate.Value.AddDays(1)
        Next
        Return tot
    End Function
    Public Function GetTotalEmpUnpaidLeaves(ByVal empname As String, ByVal stdate As DateTimePicker, ByVal eddate As DateTimePicker) As Double
        Dim TxtpresentDate As New DateTimePicker
        Dim tot As Double = 0
        TxtpresentDate.Value = stdate.Value
        For i As Integer = 0 To DateDiff(DateInterval.Day, stdate.Value.Date, eddate.Value.Date)
            If SQLIsFieldExists("select empname from empleaves where empname=N'" & empname & "' and (fromdatevalue<=" & TxtpresentDate.Value.Date.ToOADate & " and " & TxtpresentDate.Value.Date.ToOADate & "<=todatevalue) and leavecode in (select leavecode from leaves where leavetype='UNPAID LEAVE')") = True Then
                tot = tot + 1
            End If
            TxtpresentDate.Value = TxtpresentDate.Value.AddDays(1)
        Next
        Return tot
    End Function
    Public Function GetTotalEmpearnedLeaves(ByVal empname As String, ByVal stdate As DateTimePicker, ByVal eddate As DateTimePicker) As Double
        Dim TxtpresentDate As New DateTimePicker
        Dim tot As Double = 0
        TxtpresentDate.Value = stdate.Value
        For i As Integer = 0 To DateDiff(DateInterval.Day, stdate.Value.Date, eddate.Value.Date)
            If SQLIsFieldExists("select empname from empleaves where empname=N'" & empname & "' and (fromdatevalue<=" & TxtpresentDate.Value.Date.ToOADate & " and " & TxtpresentDate.Value.Date.ToOADate & "<=todatevalue) and leavecode in (select leavecode from leaves where leavetype='EARNED LEAVE')") = True Then
                tot = tot + 1
            End If
            TxtpresentDate.Value = TxtpresentDate.Value.AddDays(1)
        Next
        Return tot
    End Function
    Public Function GetTotalemppaidLeaves(ByVal empname As String, ByVal stdate As DateTimePicker, ByVal eddate As DateTimePicker) As Double
        Dim TxtpresentDate As New DateTimePicker
        Dim tot As Double = 0
        TxtpresentDate.Value = stdate.Value
        For i As Integer = 0 To DateDiff(DateInterval.Day, stdate.Value.Date, eddate.Value.Date)
            If SQLIsFieldExists("select empname from empleaves where empname=N'" & empname & "' and (fromdatevalue<=" & TxtpresentDate.Value.Date.ToOADate & " and " & TxtpresentDate.Value.Date.ToOADate & "<=todatevalue) and leavecode in (select leavecode from leaves where leavetype='PAID LEAVE')") = True Then
                tot = tot + 1
            End If
            TxtpresentDate.Value = TxtpresentDate.Value.AddDays(1)
        Next
        Return tot
    End Function
    Public Function GetTotalempALLPaideaves(ByVal empname As String, ByVal stdate As DateTimePicker, ByVal eddate As DateTimePicker) As Double
        Dim TxtpresentDate As New DateTimePicker
        Dim tot As Double = 0
        TxtpresentDate.Value = stdate.Value
        For i As Integer = 0 To DateDiff(DateInterval.Day, stdate.Value.Date, eddate.Value.Date)
            If SQLIsFieldExists("select empname from empleaves where empname=N'" & empname & "' and (fromdatevalue<=" & TxtpresentDate.Value.Date.ToOADate & " and " & TxtpresentDate.Value.Date.ToOADate & "<=todatevalue) and leavecode in (select leavecode from leaves where leavetype<>'UNPAID LEAVE')") = True Then
                tot = tot + 1
            End If
            TxtpresentDate.Value = TxtpresentDate.Value.AddDays(1)
        Next
        Return tot
    End Function
    Public Function GetTotalempALLeaves(ByVal empname As String, ByVal stdate As DateTimePicker, ByVal eddate As DateTimePicker) As Double
        Dim TxtpresentDate As New DateTimePicker
        Dim tot As Double = 0
        TxtpresentDate.Value = stdate.Value
        For i As Integer = 0 To DateDiff(DateInterval.Day, stdate.Value.Date, eddate.Value.Date)
            If SQLIsFieldExists("select empname from empleaves where empname=N'" & empname & "' and (fromdatevalue<=" & TxtpresentDate.Value.Date.ToOADate & " and " & TxtpresentDate.Value.Date.ToOADate & "<=todatevalue) ") = True Then
                tot = tot + 1
            End If
            TxtpresentDate.Value = TxtpresentDate.Value.AddDays(1)
        Next
        Return tot
    End Function
    Public Function GetTotalCompanyLeaves(ByVal stdate As DateTimePicker, ByVal eddate As DateTimePicker) As Double
        Dim TxtpresentDate As New DateTimePicker
        Dim tot As Double = 0
        TxtpresentDate.Value = stdate.Value
        For i As Integer = 0 To DateDiff(DateInterval.Day, stdate.Value.Date, eddate.Value.Date)
            If SQLIsFieldExists("select fromdatevalue from CompanyLeaves where  (fromdatevalue<=" & TxtpresentDate.Value.Date.ToOADate & " and " & TxtpresentDate.Value.Date.ToOADate & "<=todatevalue) ") = True Then
                tot = tot + 1
            End If
            TxtpresentDate.Value = TxtpresentDate.Value.AddDays(1)
        Next
        Return tot
    End Function

    Public Function GetTotalempOT(ByVal empname As String, ByVal stdate As DateTimePicker, ByVal eddate As DateTimePicker) As Double
        Dim tot As Double = 0
        tot = SQLGetNumericFieldValue("select sum(ot) as tot from empattend where status='P' and  empname=N'" & empname & "' and  (Transdatevalue between " & stdate.Value.Date.ToOADate & " and " & eddate.Value.Date.ToOADate & ") ", "tot")
        Return tot
    End Function
    Public Function GetTotalempLateInWorkingDays(ByVal empname As String, ByVal stdate As DateTimePicker, ByVal eddate As DateTimePicker) As Double
        Dim tot As Double = 0
        tot = SQLGetNumericFieldValue("select sum(LT/TotalworkingMin) as tot from empattend where status='P' and LT>0 and  empname=N'" & empname & "' and  (Transdatevalue between " & stdate.Value.Date.ToOADate & " and " & eddate.Value.Date.ToOADate & ") ", "tot")
        Return tot
    End Function
    Public Function GetTotalempPresents(ByVal empname As String, ByVal stdate As DateTimePicker, ByVal eddate As DateTimePicker) As Double
        Dim tot As Double = 0
        tot = SQLGetNumericFieldValue("select SUM(TickCount) as tot from empattend where status='P' and  empname=N'" & empname & "' and  (Transdatevalue between " & stdate.Value.Date.ToOADate & " and " & eddate.Value.Date.ToOADate & ") ", "tot")
        Return tot
    End Function
    Function AddStockItem(ByVal stockcode As String, ByVal stocksize As String, ByVal stockbatchno As String, ByVal TxtStockLocation As String, ByVal st As ChooseItemClass) As String
        stockbatchno = ""
        If SQLIsFieldExists("SELECT TOP 1 1 from   stockdbf where stockcode=N'" & stockcode & "' and stocksize=N'" & stocksize & "' and batchno=N'" & stockbatchno & "' and location=N'" & TxtStockLocation & "'") = True Then
            Return ""
            Exit Function
        End If

        Dim txtbarcode As String = ""

        txtbarcode = GetAndSetBarCodeForNewStockItem()
        Dim Sqlstr As String = ""
        Sqlstr = "INSERT INTO [StockDbf] ([StockName],[StockCodeTemp],[StockCode],[stockgroup],[Barcode],[StockSize],[Brand],[Company],[Location],[description], " _
                    & "[origin],[HScode],[category],[ISBatch],[StoreName],[BaseUnit],[MainUnit],[SubUnit],[IsSimpleUnit],[BaseQty],[TotalQty],[SubUnitQty],[QtyText], " _
                    & "[OpBaseQty],[OpTotalQty],[OpSubUnitQty],[StockRate],[StockWRP],[StockDRP],[IsAdvance],[F1],[F2],[N1],[N2],[StockSizeTemp],[Expiry],[BatchNo],[StockImagePath],[StockType],[Isactive],[Tax],[unitcon],[MinQty],[OpstockRate],[costmethod],[CustBarcode],[Servicetax],[AllowDiscount],[mrp],[packing],[allowserialnumbers],[tax2],cst,IsTaxInclude) VALUES " _
                    & "(@StockName,@StockCodeTemp,@StockCode,@stockgroup,@Barcode,@StockSize,@Brand,@Company,@Location,@description,@origin,@HScode,@category," _
                    & "@ISBatch,@StoreName,@BaseUnit,@MainUnit,@SubUnit,@IsSimpleUnit,@BaseQty,@TotalQty,@SubUnitQty,@QtyText,@OpBaseQty,@OpTotalQty,@OpSubUnitQty,@StockRate," _
                    & "@StockWRP,@StockDRP,@IsAdvance,@F1,@F2,@N1,@N2,@StockSizeTemp,@Expiry,@BatchNo,@StockImagePath,@StockType,@Isactive,@Tax,@unitcon,@MinQty,@OpstockRate,@costmethod,@CustBarcode,@Servicetax,@AllowDiscount,@mrp,@packing,@allowserialnumbers,@tax2,@cst,@IsTaxInclude) "

        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(Sqlstr, MAINCON)
        With DBF.Parameters
            .AddWithValue("StockName", st.StockItemName)
            .AddWithValue("StockCodeTemp", Replace(st.StockItemName, " ", ""))
            .AddWithValue("StockCode", st.StockItemCode)
            .AddWithValue("stockgroup", st.StockGroup)
            'THE FILED BARCODE IS USED FOR ONLY INTERNAL PURPOSE, TO IDENTIFY THE STOCK ITEM ONLY.
            .AddWithValue("Barcode", txtbarcode)
            .AddWithValue("StockSize", st.StockITemSize)
            .AddWithValue("Brand", st.Brand)
            .AddWithValue("Company", st.Madeby)
            .AddWithValue("Location", TxtStockLocation)
            .AddWithValue("description", st.StockITemDescription)
            .AddWithValue("origin", st.Madeby)
            .AddWithValue("HScode", st.HScode)
            .AddWithValue("category", st.StockCat)
            .AddWithValue("StoreName", st.StoreName)
            .AddWithValue("ISBatch", st.IsBatchNo)
            .AddWithValue("BaseUnit", st.StockUnitName)
            .AddWithValue("MainUnit", st.StockMainUnitName)
            .AddWithValue("SubUnit", st.StockSubUnitName)
            .AddWithValue("IsSimpleUnit", st.IsSimpleUnit)
            .AddWithValue("BaseQty", 0)
            .AddWithValue("TotalQty", 0)
            .AddWithValue("SubUnitQty", 0)
            .AddWithValue("QtyText", "0 " & st.StockMainUnitName)
            .AddWithValue("OpBaseQty", 0)
            .AddWithValue("OpTotalQty", 0)
            .AddWithValue("OpSubUnitQty", 0)
            .AddWithValue("IsTaxInclude", st.IsTaxInclude)
            .AddWithValue("OpstockRate", st.OpRate)
            .AddWithValue("StockRate", st.StockRate)
            .AddWithValue("StockWRP", st.StockWRPRate)
            .AddWithValue("cst", st.CSTtax)
            .AddWithValue("StockDRP", st.StockRRPRate)
            .AddWithValue("IsAdvance", 0)
            .AddWithValue("stocktype", 0)
            .AddWithValue("Isactive", 1)
            .AddWithValue("F1", "")
            .AddWithValue("F2", "")
            .AddWithValue("N1", 0)
            .AddWithValue("Tax", st.Tax)
            .AddWithValue("Tax2", st.Tax2)
            .AddWithValue("expiry", Today.Date)
            .AddWithValue("N2", 0)
            .AddWithValue("allowserialnumbers", st.IsAllowSerialNumbers)

            If st.StockITemSize.Length = 0 Then
                .AddWithValue("StockSizeTemp", st.StockITemSize)
            Else
                .AddWithValue("StockSizeTemp", Replace(st.StockITemSize, " ", ""))
            End If
            .AddWithValue("StockImagePath", st.ImagePath)
            .AddWithValue("BatchNo", "")
            .AddWithValue("unitcon", st.Unitconversion)
            .AddWithValue("CustBarcode", st.CustBarCode)
            .AddWithValue("costmethod", st.CostMethod)
            .AddWithValue("MinQty", st.MinQty)
            .AddWithValue("Servicetax", st.ServiceTax)
            .AddWithValue("AllowDiscount", st.IsAllowDiscount)
            .AddWithValue("packing", st.Packing)
            .AddWithValue("mrp", st.MRP)
        End With
        DBF.ExecuteNonQuery()
        DBF = Nothing
        MAINCON.Close()
        Return txtbarcode
    End Function
    Function ErpZeroValue() As String
        If ErpDecimalPlaces = 0 Then
            Return "0"
        ElseIf ErpDecimalPlaces = 1 Then
            Return "0.0"
        ElseIf ErpDecimalPlaces = 2 Then
            Return "0.00"
        ElseIf ErpDecimalPlaces = 3 Then
            Return "0.000"
        Else
            Return "0.0000"
        End If

    End Function
    Sub LoadSMSSettings()
        SMSSettings.BaudRate = 0
        SMSSettings.Password = ""
        SMSSettings.PortName = ""
        SMSSettings.PortNo = "2"
        SMSSettings.ServiceNo = ""
        SMSSettings.SMSType = ""
        SMSSettings.UserName = ""


        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand

        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = "SELECT * FROM SMSSettings WHERE IsDefault='True'"
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()
                SMSSettings.BaudRate = Sreader("BaudRate")
                SMSSettings.Password = Sreader("password")
                SMSSettings.PortName = Sreader("PortName")
                SMSSettings.PortNo = Sreader("PortName")
                SMSSettings.ServiceNo = Sreader("serviceno")
                SMSSettings.SMSType = Sreader("SMSType")
                SMSSettings.UserName = Sreader("username")

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

    End Sub
    Public Function SendSMSToMobile(ByVal Mobileno As String, ByVal msg As String) As Boolean
        If SMSSettings.SMSType.Length = 0 Then
            MsgBox("There is no setting made for SMS , Please Enter the Settings then try again...")
            Return False
        Else

            If SMSSettings.SMSType = "GSM Mobile" Then
                Try
                    Dim SMSPort As New SerialPort
                    With SMSPort
                        .PortName = SMSSettings.PortNo
                        .BaudRate = SMSSettings.BaudRate ' default 19200
                        .Parity = Parity.None
                        .DataBits = 8
                        .StopBits = StopBits.One
                        .Handshake = Handshake.RequestToSend
                        .DtrEnable = True
                        .RtsEnable = True
                        .NewLine = vbCrLf
                    End With
                    If SMSPort.IsOpen = False Then
                        SMSPort.Open()
                    End If
                    SMSPort.WriteLine("AT")
                    SMSPort.WriteLine("AT+CMGF=1" & vbCrLf)
                    If SMSSettings.ServiceNo.Length > 0 Then
                        SMSPort.WriteLine("AT+CSCA=" & SMSSettings.ServiceNo & vbCrLf)
                    End If
                    SMSPort.WriteLine("AT+CMGS=" & Char.ConvertFromUtf32(34) & Mobileno & Char.ConvertFromUtf32(34) & vbCrLf)
                    SMSPort.WriteLine(msg & vbCrLf & Chr(26))
                    SMSPort.Close()
                    Return True
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False
                End Try


            Else

                Dim SmsStatusMsg As String = String.Empty
                Try

                    Dim client As WebClient = New WebClient()
                    Dim URL As String = SMSSettings.UserName
                    URL = URL.Replace("@MOBILENO@", Mobileno)
                    URL = URL.Replace("@MSG@", msg)
                    SmsStatusMsg = client.DownloadString(URL)
                    If SmsStatusMsg.Contains("<br>") Then
                        SmsStatusMsg = SmsStatusMsg.Replace("<br>", ", ")
                    End If

                    Return True
                Catch e1 As WebException
                    SmsStatusMsg = e1.Message
                    Return False
                Catch e2 As Exception
                    SmsStatusMsg = e2.Message
                    Return False
                End Try

            End If
        End If



    End Function
    Public Sub LoadDataIntoComboBoxBindMethod(ByVal SQLStr As String, ByVal cob As IMSComboBox, ByVal FieldName As String, Optional ByVal AnyExtraItem As String = "")
        Dim ds As New DataSet()
        FillDataset(ds, SQLStr)
        If AnyExtraItem.Length > 0 Then
            ds.Tables(0).Rows.Add(AnyExtraItem)
        End If
        cob.BeginUpdate()
        Dim items = ds.Tables(0).AsEnumerable().Select(Function(d) DirectCast(d(0).ToString(), Object)).ToArray()
        cob.Items.AddRange(items)
        cob.EndUpdate()

    End Sub
    Public Function IsCouponValid(ByVal couponname As String, ByVal datevalue As DateTimePicker) As Boolean
        Return SQLIsFieldExists("SELECT * FROM couponmaster WHERE Cname=N'" & couponname & "' AND (Datefromvalue<=" & datevalue.Value.Date.ToOADate & " AND " & datevalue.Value.Date.ToOADate & "<=DatetoValue) and (CASE WHEN maxvalues=0 THEN 100000000.0 ELSE MAXVALUES END) >usedvalue and isActive='True'")
    End Function
    Public Function GetCouponMaxValue(ByVal couponname As String, ByVal OpenedCouponDiscountAmount As Double) As Double
        Dim MaxValue As Double = 0
        MaxValue = SQLGetNumericFieldValue("SELECT MaxValues FROM couponmaster WHERE Cname=N'" & couponname & "' ", "MaxValues")
        If MaxValue = 0 Then
            MaxValue = 100000
        End If
        Return MaxValue - (OpenedCouponDiscountAmount * -1)
    End Function
    Public Function GetCouponPercentage(ByVal couponname As String) As Double
        Dim MaxPer As Double = 0
        MaxPer = SQLGetNumericFieldValue("SELECT cper FROM couponmaster WHERE Cname=N'" & couponname & "' ", "cper")
        If MaxPer = 0 Then
            MaxPer = 60
        End If
        Return MaxPer
    End Function
    Public Sub UpdateCouponValues(ByVal couponname As String, ByVal UsedValue As Double)
        ExecuteSQLQuery("UPDATE couponmaster SET UsedValue=UsedValue+" & UsedValue & " WHERE Cname=N'" & couponname & "' ")
    End Sub
    Public Sub LoadBarcodeSettings()
        ' CREATE TABLE [barcodesettings]([barcodelength] [int] NULL,[Isreplacezeros] [bit] NULL,[Isautofill] [bit] NULL,[FixedLength] [bit] NULL,[BarcodeType] [nvarchar](50) NULL) ON [PRIMARY] 

        If SQLIsFieldExists("SELECT TOP 1 1 from   barcodesettings") = False Then
            Dim frm As New BarcodeSettingsFrm
            frm.ShowDialog()
        Else
            BarcodeSettingsVals.BarcodeLength = SQLGetNumericFieldValue("select barcodelength from barcodesettings", "barcodelength")
            BarcodeSettingsVals.IsLeadingZeros = SQLGetBooleanFieldValue("select Isreplacezeros from barcodesettings", "Isreplacezeros")
            BarcodeSettingsVals.IsFixedLegth = SQLGetBooleanFieldValue("select FixedLength from barcodesettings", "FixedLength")
            BarcodeSettingsVals.IsAutoFill = SQLGetBooleanFieldValue("select Isautofill from barcodesettings", "Isautofill")
        End If
        CustomBarcodelength = BarcodeSettingsVals.BarcodeLength
        DefaultBarcodeLength = BarcodeSettingsVals.BarcodeLength

    End Sub
    Public Sub sendMailDataFromDataGridView(ByVal dg As DataGridView, ByVal heading As String, ByVal msg As String, ByVal title As String, ByVal toemailaddress As String, ByVal ccmail As String)

        Dim strb As New StringBuilder
        strb.AppendLine("<html><body>")
        strb.AppendLine("<h1>" & heading & "</h1> ")
        strb.AppendLine("<h1>" & msg & "</h1> ")
        strb.AppendLine("<center><table border='1' cellpadding='0' cellspacing='0'><tr>")
        ''create table header

        For i As Integer = 0 To dg.Columns.Count - 1
            strb.AppendLine("<td align='center' valign='middle'>" & dg.Columns(i).HeaderText + "</td>")
        Next
        ''create table body
        strb.AppendLine("<tr>")

        For i As Integer = 0 To dg.Rows.Count - 1
            strb.AppendLine("<tr>")
            For Each dcol As DataGridViewCell In dg.Rows(0).Cells
                strb.AppendLine("<td align='center' valign='middle'>" & dcol.Value.ToString() + "</td>")
            Next
            strb.AppendLine("</tr>")
        Next
        strb.AppendLine("</table></center></body></html>")

        SendCustomEmailTo(toemailaddress, title, strb.ToString, , ccmail)

    End Sub
    Function GetImageFromDatabase(ByVal fieldname As String, SelectQuery As String) As Image
        Dim retimage As Image = My.Resources.NOPIC
        Try
            Dim imageData As Byte() = DirectCast(SQLLoadGridData(SelectQuery).Rows(0).Item(0), Byte())
            If Not imageData Is Nothing Then
                Using ms As New MemoryStream(imageData, 0, imageData.Length)
                    ms.Write(imageData, 0, imageData.Length)

                    retimage = Image.FromStream(ms, True)
                End Using
            End If
        Catch ex As Exception

        End Try
        Return retimage
    End Function
    Sub UpdateImageIntoDatabase(ByVal filename As String, ByVal fieldname As String, UpdateQueary As String, DELETEEXISTINGQUERY As String)

        Try
            Dim objFileStream As New FileStream(filename, FileMode.Open, FileAccess.Read)
            Dim intLength As Integer = Convert.ToInt32(objFileStream.Length)
            Dim objData As Byte()
            objData = New Byte(intLength - 1) {}
            objFileStream.Read(objData, 0, intLength)
            objFileStream.Close()
            Try
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim DBF As New SqlClient.SqlCommand(UpdateQueary, MAINCON)
                With DBF.Parameters
                    .AddWithValue(fieldname, objData)
                End With
                DBF.ExecuteNonQuery()
                DBF = Nothing
                MAINCON.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex3 As Exception
            MsgBox(ex3.Message)
        End Try

    End Sub
    Sub UpdateImageIntoDatabase(imagevalue As Image, ByVal fieldname As String, UpdateQueary As String, DELETEEXISTINGQUERY As String)

        Try
            Dim ms As New MemoryStream()
            imagevalue.Save(ms, imagevalue.RawFormat)
            Dim objData As Byte() = ms.GetBuffer()
            Try
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim DBF As New SqlClient.SqlCommand(UpdateQueary, MAINCON)
                With DBF.Parameters
                    .AddWithValue(fieldname, objData)

                End With
                DBF.ExecuteNonQuery()
                DBF = Nothing
                MAINCON.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex3 As Exception
            MsgBox(ex3.Message)
        End Try

    End Sub
    Sub InsertImageIntoDatabase(imagevalue As Image, ByVal fieldname As String, ByVal fieldname2 As String, UpdateQueary As String, fieldnamedata2 As String, DELETEEXISTINGQUERY As String)

        Try
            Dim ms As New MemoryStream()
            imagevalue.Save(ms, imagevalue.RawFormat)
            Dim objData As Byte() = ms.GetBuffer()
            Try
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim DBF As New SqlClient.SqlCommand(UpdateQueary, MAINCON)
                With DBF.Parameters
                    .AddWithValue(fieldname, objData)
                    .AddWithValue(fieldname2, fieldnamedata2)
                End With
                DBF.ExecuteNonQuery()
                DBF = Nothing
                MAINCON.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex3 As Exception
            MsgBox(ex3.Message)
        End Try

    End Sub
    Sub InsertImageIntoDatabase(ByVal filename As String, ByVal fieldname As String, ByVal fieldname2 As String, UpdateQueary As String, fieldnamedata2 As String, DELETEEXISTINGQUERY As String)

        Try
            Dim objFileStream As New FileStream(filename, FileMode.Open, FileAccess.Read)
            Dim intLength As Integer = Convert.ToInt32(objFileStream.Length)
            Dim objData As Byte()
            objData = New Byte(intLength - 1) {}
            objFileStream.Read(objData, 0, intLength)
            objFileStream.Close()
            Try
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim DBF As New SqlClient.SqlCommand(UpdateQueary, MAINCON)
                With DBF.Parameters
                    .AddWithValue(fieldname, objData)
                    .AddWithValue(fieldname2, fieldnamedata2)
                End With
                DBF.ExecuteNonQuery()
                DBF = Nothing
                MAINCON.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex3 As Exception
            MsgBox(ex3.Message)
        End Try

    End Sub
    Public Sub LoadDataIntoComboBoxByBinding(ByVal SQLStr As String, ByVal cob As IMSComboBox, ByVal FieldName As String, Optional ByVal AnyExtraItem As String = "")
        Dim TBD As New DataSet
        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConn)
            Adapter.Fill(TBD)
            cob.DataSource = TBD.Tables(0)
            cob.ValueMember = FieldName
            cob.DisplayMember = FieldName
            Adapter.Dispose()
        Catch ex As Exception

        Finally
            SqlConn.Close()
            SqlConn.Dispose()

        End Try
    End Sub
    Public Sub LoadPOSSettings()
        Dim dt As New DataTable

        dt = SQLLoadGridData("select * from POSSettings")
        If dt.Rows.Count > 0 Then

            POSSettings.AllowPaymentMethod = dt.Rows(0).Item("AllowPaymentMethod")
            POSSettings.NewInvoiceAfterSave = dt.Rows(0).Item("NewInvoiceAfterSave")
            POSSettings.PrintInvoiceAfterSave = dt.Rows(0).Item("PrintInvoiceAfterSave")
            POSSettings.defPrinterName = dt.Rows(0).Item("defPrinterName")
            POSSettings.DirectPrint = dt.Rows(0).Item("DirectPrint")
            POSSettings.NoofCopies = dt.Rows(0).Item("NoofCopies")
            POSSettings.AllowPriceAlter = dt.Rows(0).Item("AllowPriceAlter")
            POSSettings.AllowDiscountAlter = dt.Rows(0).Item("AllowDiscountAlter")
            POSSettings.AllowNewItem = dt.Rows(0).Item("AllowNewItem")
            POSSettings.ZeroTax = dt.Rows(0).Item("ZeroTax")
            POSSettings.ShowKeyboard = dt.Rows(0).Item("osk")
            POSSettings.DefaultPriceList = dt.Rows(0).Item("DefaultPriceList")
            POSSettings.IsAllowTochangeDate = dt.Rows(0).Item("IsAllowTochangeDate")
            POSSettings.IsAllowCreditSales = dt.Rows(0).Item("IsAllowCreditSales")
            POSSettings.IsAllowMultiCurrency = dt.Rows(0).Item("IsAllowMultiCurrency")
            POSSettings.IsItemsAsGridList = dt.Rows(0).Item("IsItemsAsGridList")

            POSSettings.CashLedger = dt.Rows(0).Item("CashLedger").ToString
            POSSettings.CreditCardLedger = dt.Rows(0).Item("CreditCardLedger").ToString
            POSSettings.ChequeLedger = dt.Rows(0).Item("ChequeLedger").ToString
            POSSettings.GiftCardLedger = dt.Rows(0).Item("GiftCardLedger").ToString




        End If
    End Sub
    Public Function GetFinalRateByDiscounts(StockITemID As String, Srate As Double, txtdate As DateTimePicker) As Double


        Dim dt As New DataTable
        dt = SQLLoadGridData("select * from discounts where isactive=1 and (" & txtdate.Value.Date.ToOADate & ">=DateFromValue and " & txtdate.Value.Date.ToOADate & "<=DateToValue) ")
        If dt.Rows.Count > 0 Then
            If SQLIsFieldExists("select * from discountDetails where DiscountID=" & CLng(dt.Rows(0).Item("ID")) & " and ItemID=N'" & StockITemID & "'") = True Then
                Dim dt2 As New DataTable
                dt2 = SQLLoadGridData("select * from discountDetails where DiscountID=" & CLng(dt.Rows(0).Item("ID")) & " and ItemID=N'" & StockITemID & "'")
                If dt2.Rows(0).Item("IsDiscPer") = True Then
                    Return Srate - Srate * dt2.Rows(0).Item("DiscountPer") / 100
                Else
                    Return Srate - dt2.Rows(0).Item("DiscountPer")
                End If
            Else
                Return Srate
            End If

        Else
            Return Srate
        End If
    End Function
  
    Public Function GetInvoiceDiscountValue(txtdate As DateTimePicker) As String
        Dim dt As New DataTable
        dt = SQLLoadGridData("select * from discounts where isactive=1 and Discounttype='Invoice' and (" & txtdate.Value.Date.ToOADate & ">=DateFromValue and " & txtdate.Value.Date.ToOADate & "<=DateToValue) ")
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("IsDiscPer") = True Then
                Return dt.Rows(0).Item("DiscountPer").ToString & "%"
            Else
                Return dt.Rows(0).Item("DiscountPer")
            End If
        Else
            Return "0"
        End If
    End Function
    Public Function GetPresetCostofStockItem(ByVal barcode As String) As Double
        If barcode.Length = 0 Then
            Return 0
        Else
            Return (SQLGetNumericFieldValue("select stockrate from stockdbf where barcode=N'" & barcode & "'", "stockrate"))
        End If

    End Function
    Public Function GetAlternativeBarcode(bcode As String) As String
        Dim retcode As String = ""
        retcode = SQLGetStringFieldValue("select Pbarcode from barcodelist where Abarcode=N'" & bcode & "'", "Pbarcode")
        If retcode.Length = 0 Then
            Return bcode
        Else
            Return retcode
        End If
    End Function
    Public Function IsAlternativeBarcodeExists(bcode As String) As Boolean
        Dim retcode As String = ""
        retcode = SQLGetStringFieldValue("select Pbarcode from barcodelist where Abarcode=N'" & bcode & "'", "Pbarcode")
        If retcode.Length = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function IsBarcodeExists(bcode As String) As Boolean
        Dim retcode As String = ""
        retcode = SQLGetStringFieldValue("select Pbarcode from barcodelist where Abarcode=N'" & bcode & "'", "Pbarcode")
        If retcode.Length = 0 Then
            retcode = SQLGetStringFieldValue("select custbarcode from stockdbf where custbarcode=N'" & bcode & "'", "custbarcode")
            If retcode.Length = 0 Then
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function
End Module
