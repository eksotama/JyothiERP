Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class VoucherEntryForm
    Dim VhSchemeName As String = ""
    Dim PaymentMethod As String = ""
    Dim OpenRStatus As Boolean = False
    Dim OpenRStatus2 As Boolean = False
    Dim OpenedRTransCode As Single
    Dim OpenedRTransCode2 As Single
    Dim IsOpenMode As Boolean = False
    Dim CurRow As Integer = 0
    Dim CurCol As Integer = 0
    Dim DebitName As String = ""
    Dim CreditName As String = ""
    Dim VoucherName As String = "Purchase Voucher"
    Dim PrinterName As String = ""
    Dim vhtype As VoucherType
    Dim OpenedCurrencyRate As Double = 0
    Dim OpenedPDCValues As New PDCSettingsClass
    Public Bill2Billdetails As New Bill2BillClass
    Dim Prtchequevalues As New ChequePrintValuesStruct
    Dim IsEditFromOutside As Boolean = False
    Dim OpenedTransactionCode As Single
    Sub New(ByVal VoucherNameValue As String, Optional openedTranscode As Double = 0)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        VoucherName = VoucherNameValue
        OpenedTransactionCode = openedTranscode
        If openedTranscode > 0 Then
            IsEditFromOutside = True
        Else
            IsEditFromOutside = False
        End If
        PostedBox.Visible = False
        BtnPosted.Visible = False
        If VoucherNameValue = "Sales Voucher" Then
            vhtype = VoucherType.SalesVoucher
            VhTitle1.Text = "SALES VOUCHER ENTRY"
            VhTitle3.Text = "SALES VOUCHER ENTRY"
            Me.Text = "SALES VOUCHER ENTRY"
        ElseIf VoucherNameValue = "Credit Note Voucher" Then
            VhTitle1.Text = "CREDIT NOTE ENTRY"
            VhTitle3.Text = "CREDIT NOTE ENTRY"
            Me.Text = "SALES RETURNS VOUCHER/CREDIT NOTE"
            vhtype = VoucherType.SalesReturnVoucher
        ElseIf VoucherNameValue = "Purchase Voucher" Then
            VhTitle1.Text = "PURCHASE VOUCHER ENTRY"
            VhTitle3.Text = "PURCHASE VOUCHER ENTRY"
            Me.Text = "PURCHASE VOUCHER ENTRY"
            vhtype = VoucherType.PurchaseVoucher
        ElseIf VoucherNameValue = "Debit Note Voucher" Then
            VhTitle1.Text = "PURCHASE RETURNS ENTRY/DEBIT NOTE"

            VhTitle3.Text = "PURCHASE RETURNS ENTRY/DEBIT NOTE"
            Me.Text = "PURCHASE RETURNS ENTRY/DEBIT NOTE"
            vhtype = VoucherType.PurchaseRetVoucher
        ElseIf VoucherNameValue = "Payment" Then
            VhTitle1.Text = "PAYMENT VOUCHER ENTRY"
            VhTitle3.Text = "PAYMENT VOUCHER ENTRY"
            Me.Text = "PAYMENT VOUCHER ENTRY"
            vhtype = VoucherType.Payment
            PostedBox.Visible = True
            BtnPosted.Visible = True
        ElseIf VoucherNameValue = "Receipt" Then
            VhTitle1.Text = "RECEIPT VOUCHER ENTRY"
            VhTitle3.Text = "RECEIPT VOUCHER ENTRY"
            Me.Text = "RECEIPT VOUCHER ENTRY"
            vhtype = VoucherType.Receipt
            PostedBox.Visible = True
            BtnPosted.Visible = True
        ElseIf VoucherNameValue = "Journal" Then
            VhTitle1.Text = "JOURNAL VOUCHER ENTRY"
            VhTitle3.Text = "JOURNAL VOUCHER ENTRY"
            Me.Text = "JOURNAL VOUCHER ENTRY"
            vhtype = VoucherType.journal
        ElseIf VoucherNameValue = "Contra" Then
            VhTitle1.Text = "CONTRA VOUCHER ENTRY"
            VhTitle3.Text = "CONTRA VOUCHER ENTRY"
            Me.Text = "CONTRA VOUCHER ENTRY"
            vhtype = VoucherType.Contra
            PostedBox.Visible = True
            BtnPosted.Visible = True
        Else
            MsgBox("Not Found")
        End If
        If MyAppSettings.AllowNarrationsinVouchers = False Then
            TxtNarration2.Text = ""
            TxtNarration2.Visible = False
        End If
    End Sub



    Private Sub payments_Activated(ByVal sender As Object, ByVal e As System.EventArgs)
        TxtDate2.Focus()
    End Sub

    Private Sub VoucherEntryForm_GiveFeedback(ByVal sender As Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles Me.GiveFeedback

    End Sub

    Private Sub payments_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        PayList.ClearFrom(vhtype)
        LoadDef()
        LoadDataIntoComboBox("select ledgername from Ledgers where Isactive=1", txtFilterLedger, "ledgername")
        txtFilterLedger.Items.Add("*All")
        txtFilterLedger.Text = "*All"
        If IsEditFromOutside = True Then
            OpenedRTransCode = OpenedTransactionCode
            OpenVoucherByID(OpenedRTransCode)
        End If
    End Sub
    Sub LoadDef()
        'ChangeHere
        IsOpenMode = False
        PostedBox.Checked = False
        PayList.ClearFrom(vhtype)
        TxtDate2.Value = Now
        TxtNarration2.Text = ""
        PayStartDate.Value = EntryCurrentPeriodStart.Value
        PayEndDate.Value = EntryCurrentPeriodEnd.Value
        Bill2Billdetails.Clear()
        IsOpenMode = False
        OpenRStatus = False
        OpenRStatus2 = False
        txtCreditTotal.Text = "0"
        txtDebitTotal.Text = "0"
        BtnClose2.Text = "Close"
        BtnSave2.Text = "Save"
        '  SetStatus("Ready")
        LoadTransactionList()
        If vhtype = VoucherType.PurchaseVoucher Then
            TxtVoucherNo2.Text = GetInvVhNumber(InvoiceNoStrct.purchasevoucher)
        ElseIf vhtype = VoucherType.PurchaseRetVoucher Then
            TxtVoucherNo2.Text = GetInvVhNumber(InvoiceNoStrct.purchasereturnvoucher)
        ElseIf vhtype = VoucherType.SalesVoucher Then
            TxtVoucherNo2.Text = GetInvVhNumber(InvoiceNoStrct.salesvoucher)
        ElseIf vhtype = VoucherType.SalesReturnVoucher Then
            TxtVoucherNo2.Text = GetInvVhNumber(InvoiceNoStrct.salesreturnvoucher)
        ElseIf vhtype = VoucherType.Payment Then
            TxtVoucherNo2.Text = GetInvVhNumber(InvoiceNoStrct.paymnetvoucher)
        ElseIf vhtype = VoucherType.Receipt Then
            TxtVoucherNo2.Text = GetInvVhNumber(InvoiceNoStrct.receiptvoucher)
        ElseIf vhtype = VoucherType.Contra Then
            TxtVoucherNo2.Text = GetInvVhNumber(InvoiceNoStrct.contravoucher)
        ElseIf vhtype = VoucherType.journal Then
            TxtVoucherNo2.Text = GetInvVhNumber(InvoiceNoStrct.journalvoucher)
        End If
        TxtRefNo.Text = TxtVoucherNo2.Text
        BtnChequeDetails.Visible = False
        TxtChequeNo.Text = ""
        TxtChequeDate.Value = Now
        TxtPrintName.Text = ""
        TxtDate2.Focus()
    End Sub


    Public Sub ASaveBeforeCheck()

        txtCreditTotal.Text = FormatNumber(PayList.GetCreditTotal, ErpDecimalPlaces)
        txtDebitTotal.Text = FormatNumber(PayList.GetDebitTotal, ErpDecimalPlaces)
        If CDbl(txtCreditTotal.Text) = 0 Or CDbl(txtDebitTotal.Text) = 0 Then
            MsgBox("The Debit and Credit Amount must match               ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If CDbl(txtCreditTotal.Text) <> CDbl(txtDebitTotal.Text) Then
            MsgBox("The Debit and Credit Amount must match                ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If MsgBox("Save ?                                           ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            For i As Integer = 0 To PayList.Rowcount - 1
                If Len(PayList.GetItems(1, i)) > 2 Then
                    If SQLIsFieldExists("select ledgername from ledgers where ledgername=N'" & PayList.GetItems(1, i).ToString & "'") = False Then
                        MsgBox("The Ledger Name : " & PayList.GetItems(1, i).ToString & "  is not exists, It may be modified or deleted, Please make sure and try again....", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End If
            Next


            If IMSBEGINTRANSACTION() = False Then
                IMSENDTRANSACTION()
                ' MsgBox("Please Try again, The server is busy or ERP Server may be shutdown, Please Run the ERP Server ")
                Exit Sub
            Else
                SaveVoucher2()
                LoadDef()
            End If
        End If
    End Sub

    Sub SaveVoucher2()

        Dim Trancode As Decimal
        If OpenRStatus2 = True Then
            OpenedPDCValues = GetPDCValues(OpenedRTransCode2)
            ExecuteSQLQuery("delete  from ledgerbook where TransCode=" & OpenedRTransCode2)
            ' dbf.Open("delete  from ledgerbook where transcode=" & OpenedRTransCode2, Conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            ExecuteSQLQuery("delete from bill2bill where  transcode=" & OpenedRTransCode2)
            Trancode = OpenedRTransCode2
            '
        Else
            Trancode = GetAndSetIDCode(EnumIDType.TransCode)
            If vhtype = VoucherType.PurchaseVoucher Then
                TxtVoucherNo2.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.purchasevoucher)
            ElseIf vhtype = VoucherType.PurchaseRetVoucher Then
                TxtVoucherNo2.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.purchasereturnvoucher)
            ElseIf vhtype = VoucherType.SalesVoucher Then
                TxtVoucherNo2.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.salesvoucher)
            ElseIf vhtype = VoucherType.SalesReturnVoucher Then
                TxtVoucherNo2.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.salesreturnvoucher)
            ElseIf vhtype = VoucherType.Payment Then
                TxtVoucherNo2.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.paymnetvoucher)
            ElseIf vhtype = VoucherType.Receipt Then
                TxtVoucherNo2.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.receiptvoucher)
            ElseIf vhtype = VoucherType.Contra Then
                TxtVoucherNo2.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.contravoucher)
            ElseIf vhtype = VoucherType.journal Then
                TxtVoucherNo2.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.journalvoucher)
            End If
            OpenedPDCValues.ischequePrint = False
            If TxtDate2.Value > Today.Date Then
                OpenedPDCValues.IsPDC = True
            Else
                OpenedPDCValues.IsPDC = False
            End If
            OpenedPDCValues.TodayDate.Value = Now
            OpenedPDCValues.IsPDCClear = False

            '   OpenedCurrencyRate = GetCurrencyRate(TxtCurrency.Text)


        End If
        Dim sno As Integer = 1
        For i As Integer = 0 To PayList.Rowcount - 1
            If Len(PayList.GetItems(1, i)) > 2 Then
                If Len(PayList.GetItems(2, i)) > 0 Then
                    If PayList.GetItems(0, i) = "Dr" Then
                        DebitName = PayList.GetItems(1, i)
                        Exit For
                    End If
                End If
            End If
        Next
        For i As Integer = 0 To PayList.Rowcount - 1

            If Len(PayList.GetItems(1, i)) > 2 Then
                If Len(PayList.GetItems(2, i)) > 0 Then
                    If PayList.GetItems(0, i) = "Cr" Then
                        CreditName = PayList.GetItems(1, i)
                        Exit For
                    End If
                End If
            End If
        Next



        Dim SqlStr As String = ""
        SqlStr = "INSERT INTO [LedgerBook] ([LedgerName],[TransCode],[InvoiceNo],[InvoiceName],[sno],[Dr],[Cr],[TransDate], " _
            & "[TransDateValue],[LedgerGroup],[AcLedger],[IsAdvance],[IsDeleted],[UserName],[StoreName],[Narration],[InvoiceType],[RefNo],[ConRate],[CounterID]) " _
            & " VALUES (@LedgerName,@TransCode,@InvoiceNo,@InvoiceName,@sno,@Dr,@Cr,@TransDate,@TransDateValue,@LedgerGroup, " _
            & "@AcLedger,@IsAdvance,@IsDeleted,@UserName,@StoreName,@Narration,@InvoiceType,@RefNo,@ConRate,@CounterID) "

        For i As Integer = 0 To PayList.Rowcount - 1

            If Len(PayList.GetItems(1, i)) > 2 Then
              
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim DBFR = New SqlClient.SqlCommand(SqlStr, MAINCON)
                With DBFR.Parameters
                    .AddWithValue("LedgerName", PayList.GetItems(1, i).ToString)
                    .AddWithValue("TransCode", Trancode)
                    .AddWithValue("InvoiceNo", TxtVoucherNo2.Text)
                    .AddWithValue("InvoiceName", VoucherName)
                    .AddWithValue("sno", sno)
                    sno = sno + 1
                    .AddWithValue("Dr", CDbl(IIf(PayList.GetItems(0, i) = "Dr", PayList.GetItems(2, i), 0)))
                    .AddWithValue("Cr", CDbl(IIf(PayList.GetItems(0, i) = "Cr", PayList.GetItems(2, i), 0)))
                    .AddWithValue("TransDate", TxtDate2.Value)
                    .AddWithValue("TransDateValue", TxtDate2.Value.Date.ToOADate)
                    .AddWithValue("LedgerGroup", "")
                    If PayList.GetItems(0, i) = "Cr" Then
                        .AddWithValue("AcLedger", DebitName)
                    Else
                        .AddWithValue("AcLedger", CreditName)
                    End If

                    .AddWithValue("IsAdvance", 1)
                    .AddWithValue("IsDeleted", 0)
                    .AddWithValue("UserName", CurrentUserName)
                    .AddWithValue("StoreName", DefStoreName)
                    .AddWithValue("Narration", TxtNarration2.Text)
                    .AddWithValue("InvoiceType", VoucherName)
                    .AddWithValue("RefNo", "")
                    .AddWithValue("ConRate", PayList.GetItems(3, i))
                    .AddWithValue("CounterID", CurrentCounterID)
                End With
                DBFR.ExecuteNonQuery()
                DBFR = Nothing
                MAINCON.Close()

            End If
        Next


        If SQLIsFieldExists("SELECT TOP 1 1 from   ledgers where ledgername=N'" & DebitName & "' and   (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.BankOD & "'))") = True Then
            PaymentMethod = "Cheque"
        Else
            PaymentMethod = "Cash"
        End If



        UpdateBill2Bill(Trancode)
        OpenedPDCValues.IsPDC = PostedBox.Checked
        UpdatePDCValues(Trancode, OpenedPDCValues)



        '  SetStatus("Saved Successfully the Voucher No: " & TxtVoucherNo2.Text.ToString)

        If MyAppSettings.ISAllowAutoInvoicePrining = True Then

            Dim pvalues As New PrintParameters
            pvalues.IsWithSchemes = False
            Dim printk As New VhDlgfrm(pvalues)
            If printk.ShowDialog = DialogResult.OK Then
                ' pvalues.schemename
                If pvalues.IsPrintToPrinter = True Then
                    If pvalues.IsPrintDuplicateInvoice = True Then
                        For i As Integer = 1 To pvalues.NoofCopies
                            If i = 1 Then
                                PrintVoucher(Me, Trancode, vhtype, 1, True, pvalues.VouhcerName, False)
                            Else
                                PrintVoucher(Me, Trancode, vhtype, 1, True, pvalues.VouhcerName, True)
                            End If
                        Next
                    Else
                        PrintVoucher(Me, Trancode, vhtype, 1, True, pvalues.VouhcerName)
                    End If

                ElseIf pvalues.IsPrintToPrinter = False Then
                    If pvalues.IsPrintDuplicateInvoice = True Then
                        For i As Integer = 1 To pvalues.NoofCopies
                            If i = 1 Then
                                PrintVoucher(Me, Trancode, vhtype, 1, False, pvalues.VouhcerName, )
                            Else
                                PrintVoucher(Me, Trancode, vhtype, 1, False, pvalues.VouhcerName, True)
                            End If
                        Next
                    Else
                        PrintVoucher(Me, Trancode, vhtype, 1, False, pvalues.VouhcerName, )
                    End If

                End If
            End If
            If SQLIsFieldExists("SELECT LEDGERNAME FROM LEDGERS WHERE LEDGERNAME=N'" & DebitName & "' AND ISSENDEMAIL='True'") = True Then
                If MsgBox("Do you want to Send Email to the Customer?    ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    SendVoucherToEmail(Trancode)
                End If
            End If

        End If
        If SQLGetBooleanFieldValue("select IsSendSMS from ledgers where ledgername=N'" & PayList.GetItems(1, 0) & "'", "IsSendSMS") = True Then
            Try
                Dim TempStr As String = ""
                Dim vhname As String = ""
                If vhtype = VoucherType.SalesVoucher Then
                    vhname = "SALES"
                ElseIf vhtype = VoucherType.Payment Then
                    vhname = "PAYMENT"
                ElseIf vhtype = VoucherType.Receipt Then
                    vhname = "RECEIPT"
                ElseIf vhtype = VoucherType.Contra Then
                    vhname = "CONTRA"
                ElseIf vhtype = VoucherType.journal Then
                    vhname = "JOURNAL"
                End If


                If vhname.Length > 0 Then
                    If MsgBox("Do you want to Send SMS to Customer Mobile ?       ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Dim mbno As String = ""

                        mbno = SQLGetStringFieldValue("select tel from ledgers where ledgername=N'" & PayList.GetItems(1, 0) & "'", "tel")
                        If mbno.Length > 6 Then
                            TempStr = SQLGetStringFieldValue("SELECT MSGTEXT FROM smsmailsettings where vouchername=N'" & vhname & "'", "MSGTEXT")
                            TempStr = TempStr.Replace("@TODAYDATE@", Today.ToString())
                            TempStr = TempStr.Replace("@INVOICENO@", TxtVoucherNo2.Text)
                            TempStr = TempStr.Replace("@INVOICEDATE@", TxtDate2.Value.Date.ToString())
                            TempStr = TempStr.Replace("@PARTYNAME@", PayList.GetItems(1, 0))
                            TempStr = TempStr.Replace("@CURRENTAMOUNT@", PayList.GetItems(2, 0))
                            TempStr = TempStr.Replace("@INVOICEBALANCE@", "NAV")
                            TempStr = TempStr.Replace("@PAYMENTBY@", PayList.GetItems(1, 1))
                            TempStr = TempStr.Replace("@BALANCE@", GetCurrentBalanceText(PayList.GetItems(1, 0)))
                            TempStr = TempStr.Replace("@CURRENTBALANCE@", GetCurrentBalanceValue(PayList.GetItems(1, 0)) - (PayList.GetItems(2, 0)))
                            SendSMSToMobile(mbno, TempStr)
                        End If
                    End If

                End If
            Catch ex As Exception

            End Try

        End If
        'SAVEING COST CENTER  DATA
        SaveCostCentersData(Trancode)
        SaveChequeInfo(Trancode, PayList.GetItems(1, 1))

        IMSENDTRANSACTION()

    End Sub
    Sub SaveCostCentersData(ByVal trancode As Double)
        ExecuteSQLQuery("delete from costcenterbook where TransCode=" & trancode)
        Dim Sno As Integer = 0
        For i As Integer = 0 To PayList.Rowcount - 1
            If Len(PayList.GetItems(1, i)) > 2 Then
                If CType(PayList.Tb.Controls(i), VoucherRow).CostList.RowCount > 0 Then
                    For rc As Integer = 0 To CType(PayList.Tb.Controls(i), VoucherRow).CostList.RowCount - 1
                        If Len(CType(PayList.Tb.Controls(i), VoucherRow).CostList.Item("tcostname", rc).Value) > 0 Then
                            Dim SqlStr As String = ""
                            SqlStr = "INSERT INTO [CostCenterBook] ([sno],[LedgerName],[CostCenterName],[Dr],[Cr],[UserName],[TransCode],[TransDate],[Transdatevalue],[VoucherName],[InvoiceNo],[CostNo],[CostCat],[IsAdditional])    " _
                                & " VALUES (@sno,@LedgerName,@CostCenterName,@Dr,@Cr,@UserName,@TransCode,@TransDate,@Transdatevalue,@VoucherName,@InvoiceNo,@CostNo,@CostCat,@IsAdditional) "
                            Sno = Sno + 1
                            MAINCON.ConnectionString = ConnectionStrinG
                            MAINCON.Open()
                            Dim DBFR = New SqlClient.SqlCommand(SqlStr, MAINCON)
                            With DBFR.Parameters
                                .AddWithValue("sno", Sno)
                                .AddWithValue("LedgerName", PayList.GetItems(1, i).ToString)
                                .AddWithValue("CostCenterName", CType(PayList.Tb.Controls(i), VoucherRow).CostList.Item("tcostname", rc).Value)
                                If PayList.GetItems(0, i) = "Cr" Then
                                    .AddWithValue("Dr", 0)
                                    .AddWithValue("Cr", CType(PayList.Tb.Controls(i), VoucherRow).CostList.Item("tamount", rc).Value)
                                Else
                                    .AddWithValue("Dr", CType(PayList.Tb.Controls(i), VoucherRow).CostList.Item("tamount", rc).Value)
                                    .AddWithValue("Cr", 0)
                                End If
                                .AddWithValue("UserName", CurrentUserName)
                                .AddWithValue("TransCode", trancode)
                                .AddWithValue("TransDate", TxtDate2.Value)
                                .AddWithValue("Transdatevalue", TxtDate2.Value.Date.ToOADate)
                                .AddWithValue("VoucherName", VoucherName)
                                .AddWithValue("InvoiceNo", TxtVoucherNo2.Text)
                                .AddWithValue("CostCat", CType(PayList.Tb.Controls(i), VoucherRow).CostList.Item("tcostcat", rc).Value)
                                .AddWithValue("CostNo", CType(PayList.Tb.Controls(i), VoucherRow).CostList.Item("tcostno", rc).Value)
                                .AddWithValue("IsAdditional", "False")
                                'tCostCat
                            End With
                            DBFR.ExecuteNonQuery()
                            DBFR = Nothing
                            MAINCON.Close()
                        End If
                    Next
                End If

            End If
        Next
    End Sub
    Sub UpdateBill2Bill(ByVal tcode As Double)
        ExecuteSQLQuery("delete from bill2bill where  transcode=" & tcode)
        If Bill2Billdetails.IsNotApplicable = True Then Exit Sub
        For i As Integer = 0 To Bill2Billdetails.BillList.RowCount - 1
            Dim SqlStr As String = ""
            SqlStr = "INSERT INTO [Bill2Bill]([BillType],[LedgerName],[TransCode],[BillTransCode],[Dr],[Cr],[RefNo],[InvoiceNo],[IsOpening],[TransDate],[StoreName],[PayDays],[VoucherName],[PaymentMethod]) " _
                                   & " VALUES(@BillType,@LedgerName,@TransCode,@BillTransCode,@Dr,@Cr,@RefNo,@InvoiceNo,@IsOpening,@TransDate,@StoreName,@PayDays,@VoucherName,@PaymentMethod) "

            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF1 As New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBF1.Parameters
                .AddWithValue("BillType", Bill2Billdetails.BillList.Item("ttype", i).Value)
                .AddWithValue("LedgerName", PayList.GetItems(1, 0).ToString)
                .AddWithValue("TransCode", tcode)
                .AddWithValue("BillTransCode", tcode)
                .AddWithValue("RefNo", Bill2Billdetails.BillList.Item("tref", i).Value)
                .AddWithValue("InvoiceNo", TxtVoucherNo2.Text)
                .AddWithValue("IsOpening", 0)
                .AddWithValue("TransDate", TxtDate2.Value)
                .AddWithValue("StoreName", DefStoreName)
                If PostedBox.Checked = True Then
                    .AddWithValue("PaymentMethod", "Cheque")
                Else
                    .AddWithValue("PaymentMethod", PaymentMethod)
                End If

                If Bill2Billdetails.BillList.Item("ttype", i).Value = "New" Then
                    .AddWithValue("PayDays", SQLGetNumericFieldValue("select CreditPeriod from ledgers where ledgername=N'" & PayList.GetItems(1, 0).ToString & "'", "CreditPeriod"))
                Else
                    .AddWithValue("PayDays", 0)
                End If
                If vhtype = VoucherType.PurchaseVoucher Then
                    .AddWithValue("VoucherName", "PurchaseVoucher")
                    .AddWithValue("Dr", 0)
                    .AddWithValue("cr", Bill2Billdetails.BillList.Item("tamt", i).Value)
                ElseIf vhtype = VoucherType.PurchaseRetVoucher Then
                    .AddWithValue("VoucherName", "DebitNote")
                    .AddWithValue("Dr", Bill2Billdetails.BillList.Item("tamt", i).Value)
                    .AddWithValue("cr", 0)
                ElseIf vhtype = VoucherType.SalesVoucher Then
                    .AddWithValue("VoucherName", "SalesVoucher")
                    .AddWithValue("Dr", Bill2Billdetails.BillList.Item("tamt", i).Value)
                    .AddWithValue("cr", 0)
                ElseIf vhtype = VoucherType.SalesReturnVoucher Then
                    .AddWithValue("VoucherName", "CreditNote")
                    .AddWithValue("Dr", 0)
                    .AddWithValue("cr", Bill2Billdetails.BillList.Item("tamt", i).Value)
                ElseIf vhtype = VoucherType.Payment Then
                    .AddWithValue("VoucherName", "Payment")
                    .AddWithValue("Dr", Bill2Billdetails.BillList.Item("tamt", i).Value)
                    .AddWithValue("cr", 0)
                ElseIf vhtype = VoucherType.Receipt Then
                    .AddWithValue("VoucherName", "Receipt")
                    .AddWithValue("Dr", 0)
                    .AddWithValue("cr", Bill2Billdetails.BillList.Item("tamt", i).Value)
                ElseIf vhtype = VoucherType.Contra Then
                    .AddWithValue("VoucherName", "Contra")
                    .AddWithValue("Dr", 0)
                    .AddWithValue("cr", Bill2Billdetails.BillList.Item("tamt", i).Value)
                ElseIf vhtype = VoucherType.journal Then
                    .AddWithValue("VoucherName", "Journal")
                    .AddWithValue("Dr", Bill2Billdetails.BillList.Item("tamt", i).Value)
                    .AddWithValue("cr", 0)
                End If
            End With
            DBF1.ExecuteNonQuery()
            DBF1 = Nothing
            MAINCON.Close()
        Next
    End Sub
    Sub LoadBillWiseData(ByVal tcode)
        Dim SqlConn As New SqlClient.SqlConnection
        Bill2Billdetails.Clear()
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from bill2bill where transcode=" & tcode
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            Dim rno As Integer = 0
            While Sreader.Read()
                rno = Bill2Billdetails.BillList.Rows.Add
                Bill2Billdetails.BillList.Item("ttype", rno).Value = Sreader("Billtype").ToString.Trim
                Bill2Billdetails.BillList.Item("tref", rno).Value = Sreader("refno").ToString.Trim
                Bill2Billdetails.BillList.Item("TCode", rno).Value = Sreader("Transcode").ToString.Trim
                Bill2Billdetails.BillList.Item("tamt", rno).Value = Sreader("dr") + Sreader("cr")
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try
        Bill2Billdetails.TransCode = tcode
    End Sub

    Public Sub OpenVoucherByID(ByVal openedID As Single, Optional ByVal Mode As Integer = 0)
        LoadDef()
        IsOpenMode = True
        Dim SqlConn As New SqlClient.SqlConnection
        Try
            If SQLGetNumericFieldValue("select isAdvance from ledgerbook where transcode=" & OpenedRTransCode & " order by sno", "isAdvance") = 0 And Mode = 0 Then
                IsOpenMode = False
            Else
                OpenRStatus2 = True
                OpenedRTransCode2 = OpenedRTransCode
                PayList.ClearFrom(vhtype)
                PayList.SetAsAlterMode = True
                Dim i As Integer
                i = 0
                SqlConn.ConnectionString = ConnectionStrinG
                SqlConn.Open()
                SQLFcmd.Connection = SqlConn
                SQLFcmd.CommandText = "select * from ledgerbook where transcode=" & OpenedRTransCode & " order by sno"
                SQLFcmd.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd.ExecuteReader
                While Sreader.Read()
                    If i = 0 Then
                        TxtVoucherNo2.Text = Sreader("InvoiceNo").ToString.Trim
                        TxtDate2.Value = Sreader("TransDate")
                        TxtNarration2.Text = Sreader("Narration").ToString.Trim
                    End If
                    If i > 0 Then
                        PayList.AddRow()
                    End If
                    PayList.SetItem(1, i) = Sreader("LedgerName").ToString.Trim
                    If CDbl(Sreader("cr")) <> 0 Then
                        PayList.SetItem(0, i) = "Cr"
                        PayList.SetItem(2, i) = Sreader("cr")
                    Else
                        PayList.SetItem(0, i) = "Dr"
                        PayList.SetItem(2, i) = Sreader("Dr")
                    End If
                    PayList.SetItem(3, i) = Sreader("conrate")
                    i = i + 1
                End While

                BtnClose2.Text = "Cancel"
                BtnSave2.Text = "Alter"
                txtCreditTotal.Text = FormatNumber(PayList.GetCreditTotal, ErpDecimalPlaces)
                txtDebitTotal.Text = FormatNumber(PayList.GetDebitTotal, ErpDecimalPlaces)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try



        For i As Integer = 0 To PayList.Rowcount - 1

            Dim rno As Integer = 0
            CType(PayList.Tb.Controls(i), VoucherRow).CostList.Rows.Clear()
            Try
                SqlConn.ConnectionString = ConnectionStrinG
                SqlConn.Open()
                SQLFcmd.Connection = SqlConn
                SQLFcmd.CommandText = "select * from CostCenterBook where IsAdditional='False' and transcode=" & OpenedRTransCode & " and ledgername=N'" & PayList.GetItems(1, i) & "' order by sno"
                SQLFcmd.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd.ExecuteReader
                While Sreader.Read()
                    rno = CType(PayList.Tb.Controls(i), VoucherRow).CostList.Rows.Add
                    CType(PayList.Tb.Controls(i), VoucherRow).CostList.Item("tcostname", rno).Value = Sreader("CostCenterName").ToString.Trim
                    CType(PayList.Tb.Controls(i), VoucherRow).CostList.Item("tamount", rno).Value = Sreader("dr") + Sreader("cr")
                    CType(PayList.Tb.Controls(i), VoucherRow).CostList.Item("tcostcat", rno).Value = Sreader("costcat").ToString.Trim
                    CType(PayList.Tb.Controls(i), VoucherRow).CostList.Item("tcostno", rno).Value = Sreader("costno").ToString.Trim

                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SqlConn.Close()
                SQLFcmd.Connection = Nothing
            End Try

        Next
        IsOpenMode = False
        PayList.SetAsAlterMode = False
        LoadBillWiseData(OpenedRTransCode)
        LoadChequeInfoData()
    End Sub



    Private Sub UserButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton1.Click, ClearListToolStripMenuItem.Click
        If MsgBox("Do you want to Clear the List ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            PayList.ClearFrom(vhtype)
        End If

    End Sub




    Private Sub BtnClose2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose2.Click, CloseToolStripMenuItem.Click
        If BtnClose2.Text = "Close" Then
            Me.Dispose()

        Else
            BtnClose2.Text = "Close"
            LoadDef()
        End If
    End Sub
    Private Sub payList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        On Error Resume Next
    End Sub

    Private Sub txtFilterLedger_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilterLedger.SelectedIndexChanged
        LoadTransactionList()
        TransList.Focus()
    End Sub



    Private Sub btnadvancemode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OpenVoucherByID(OpenedRTransCode, 1)
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        LoadTransactionList()
    End Sub

    Private Sub TransList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TransList.DataError

    End Sub



    Private Sub TransList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TransList.CellDoubleClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If
        If IsAuditConfirm(TransList.Item(0, TransList.CurrentRow.Index).Value) = True Then
            MsgBox("The Selected Entry can not be Editable....", MsgBoxStyle.Information)
            Exit Sub
        End If
        If MsgBox("Do You want to Modify ?                 ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            OpenedRTransCode = TransList.Item(0, e.RowIndex).Value
            OpenVoucherByID(OpenedRTransCode)

        End If
    End Sub
    Sub LoadTransactionList()
        If PayStartDate.Value > PayEndDate.Value Then
            Dim dt As New DateTimePicker
            dt.Value = PayStartDate.Value
            PayStartDate.Value = PayEndDate.Value
            PayEndDate.Value = dt.Value

        End If
        TransList.Rows.Clear()

        Dim sqlstr As String = ""
        If txtFilterLedger.Text = "*All" Then
            sqlstr = "Select * from ledgerbook where sno=1 and isdeleted=0 and InvoiceName=N'" & VoucherName & "' and (TransDateValue between " & (CDbl(PayStartDate.Value.Date.ToOADate)) & " and " & (CDbl(PayEndDate.Value.Date.ToOADate)) & ") order by InvoiceNo"
        Else
            sqlstr = "Select * from ledgerbook where   InvoiceName=N'" & VoucherName & "' and isdeleted=0 and ledgername=N'" & txtFilterLedger.Text & "' and (TransDateValue between " & (CDbl(PayStartDate.Value.Date.ToOADate)) & " and " & (CDbl(PayEndDate.Value.Date.ToOADate)) & ") order by InvoiceNo"
        End If

        Dim SqlConn As New SqlClient.SqlConnection
        Dim Rno As Integer = 0
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = sqlstr
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                Rno = TransList.Rows.Add()
                TransList.Item("ttranscode", Rno).Value = Sreader("TransCode")
                TransList.Item("tdate", Rno).Value = Sreader("TransDate")
                If IsShowNarration.Checked = True Then
                    TransList.Item("tdetails", Rno).Value = Sreader("ledgername").ToString.Trim & " <-> " & Sreader("AcLedger").ToString.Trim & vbCrLf & vbCrLf & Sreader("narration").ToString.Trim
                Else
                    TransList.Item("tdetails", Rno).Value = Sreader("ledgername").ToString.Trim & " <-> " & Sreader("AcLedger").ToString.Trim
                End If
                TransList.Item("tvhno", Rno).Value = Sreader("InvoiceNo").ToString.Trim
                TransList.Item("tpdebit", Rno).Value = CDbl(Sreader("Dr")) + CDbl(Sreader("Cr"))
            End While

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try





    End Sub

    Private Sub TxtDate2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDate2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            sender.TopLevelControl.SelectNextControl(sender, True, True, True, True)
        End If
    End Sub

    Private Sub TxtDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            sender.TopLevelControl.SelectNextControl(sender, True, True, True, True)
        End If
    End Sub

    Private Sub IsShowNarration_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsShowNarration.CheckedChanged
        LoadTransactionList()
    End Sub

    Private Sub VoucherEntryControl1_AmountEnteredEvent(ByVal e As Object) Handles PayList.AmountEnteredEvent
        txtCreditTotal.Text = FormatNumber(PayList.GetCreditTotal, ErpDecimalPlaces)
        txtDebitTotal.Text = FormatNumber(PayList.GetDebitTotal, ErpDecimalPlaces)
    End Sub

    Private Sub VoucherEntryForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        MainForm.AppCompanyTitleBar.Visible = False
        MainForm.AppMainBarContainer.Height = 1
        TxtDate2.Focus()

    End Sub


    Private Sub BtnSave2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave2.Click, SaveToolStripMenuItem.Click
        ASaveBeforeCheck()
    End Sub

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint

        PrintDocument1.DefaultPageSettings.PaperSize = New PaperSize("Custom", ChequePagesetupValues.Paperwidth, ChequePagesetupValues.Paperheight)
        If ChequePagesetupValues.IslandScape = True Then
            PrintDocument1.DefaultPageSettings.Landscape = True
            'PagesetupValues
        Else
            PrintDocument1.DefaultPageSettings.Landscape = False
        End If
        PrintDocument1.DefaultPageSettings.Margins.Left = ChequePagesetupValues.leftmarging
        PrintDocument1.DefaultPageSettings.Margins.Right = ChequePagesetupValues.rightmarging
        PrintDocument1.DefaultPageSettings.Margins.Top = ChequePagesetupValues.topmarging
        PrintDocument1.DefaultPageSettings.Margins.Bottom = ChequePagesetupValues.buttommarging

    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ChequePrinting(sender, e, OpenedRTransCode2, VhSchemeName, Prtchequevalues)
    End Sub


    Private Sub BtnPosted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPosted.Click, PostDatedToolStripMenuItem.Click
        If PostedBox.Checked = True Then
            PostedBox.Checked = False
        Else
            PostedBox.Checked = True
        End If
    End Sub

    Private Sub TransList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TransList.CellContentClick

    End Sub

    Private Sub TxtNarration2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNarration2.LostFocus

        If SQLIsFieldExists("SELECT TOP 1 1 from   ledgers where ledgername=N'" & PayList.GetItems(1, 1) & "' and   (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.BankOD & "'))") = True Then
            BtnChequeDetails.Visible = True
            TxtPrintName.Text = PayList.GetItems(1, 0)
            TxtChequeNo.Focus()
        Else
            BtnChequeDetails.Visible = False
        End If
    End Sub

    Private Sub TxtNarration2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNarration2.TextChanged



    End Sub

    Private Sub BtnSave2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave2.GotFocus
        If BtnChequeDetails.Visible = False Then
            If SQLIsFieldExists("SELECT TOP 1 1 from   ledgers where ledgername=N'" & PayList.GetItems(1, 1) & "' and   (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.BankOD & "'))") = True Then
                BtnChequeDetails.Visible = True
                TxtPrintName.Text = PayList.GetItems(1, 0)
                TxtChequeNo.Focus()
                Exit Sub
            Else
                BtnChequeDetails.Visible = False
            End If
        End If
    End Sub
    Sub SaveChequeInfo(ByVal transcode As Single, ByVal bankname As String)
        Dim isprinted As Boolean = False
        isprinted = SQLGetBooleanFieldValue("select Isprinted from chequeinfo where transcode=" & transcode, "Isprinted")
        ExecuteSQLQuery("delete from chequeinfo where transcode=" & transcode)
        If BtnChequeDetails.Visible = False Then Exit Sub
        Dim SqlStr As String = ""
        SqlStr = " INSERT INTO [chequeinfo]([transcode],[Ledgername],[chequeno],[chequedate],[issuedate],[details],[vouchername],[voucherno],[amount],[Isprinted],[chequedatevalue])     VALUES " _
            & "(@transcode,@Ledgername,@chequeno,@chequedate,@issuedate,@details,@vouchername,@voucherno,@amount,@Isprinted,@chequedatevalue) "
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBFR = New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBFR.Parameters
            .AddWithValue("transcode", transcode)
            .AddWithValue("Ledgername", bankname)
            .AddWithValue("chequeno", TxtChequeNo.Text)
            .AddWithValue("chequedate", TxtChequeDate.Value)
            .AddWithValue("issuedate", TxtDate2.Value)
            .AddWithValue("details", TxtPrintName.Text)
            .AddWithValue("vouchername", VoucherName)
            .AddWithValue("voucherno", TxtVoucherNo2.Text)
            .AddWithValue("amount", CDbl(txtCreditTotal.Text))
            .AddWithValue("Isprinted", isprinted)
            .AddWithValue("chequedatevalue", TxtDate2.Value.Date.ToOADate)
        End With
        DBFR.ExecuteNonQuery()
        DBFR = Nothing
        MAINCON.Close()
    End Sub
    Sub LoadChequeInfoData()
        BtnChequeDetails.Visible = False
        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from chequeinfo where  transcode=" & OpenedRTransCode
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                TxtChequeNo.Text = Sreader("chequeno").ToString
                TxtChequeDate.Value = Sreader("chequedate")
                TxtPrintName.Text = Sreader("details").ToString
                BtnChequeDetails.Visible = True
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles BtnPrint.Click, PrintToolStripMenuItem.Click
        If TransList.SelectedRows.Count <= 0 Then Exit Sub
        Dim pvalues As New PrintParameters
        pvalues.IsWithSchemes = False
        Dim printk As New VhDlgfrm(pvalues)
        If printk.ShowDialog = DialogResult.OK Then
            ' pvalues.schemename
            If pvalues.IsPrintToPrinter = True Then
                If pvalues.IsPrintDuplicateInvoice = True Then
                    For i As Integer = 1 To pvalues.NoofCopies
                        If i = 1 Then
                            PrintVoucher(Me, TransList.Item(0, TransList.CurrentRow.Index).Value, vhtype, 1, True, pvalues.PrinterName, False)
                        Else
                            PrintVoucher(Me, TransList.Item(0, TransList.CurrentRow.Index).Value, vhtype, 1, True, pvalues.PrinterName, True)
                        End If
                    Next

                Else
                    PrintVoucher(Me, TransList.Item(0, TransList.CurrentRow.Index).Value, vhtype, 1, True, pvalues.PrinterName)
                End If

            ElseIf pvalues.IsPrintToPrinter = False Then
                If pvalues.IsPrintDuplicateInvoice = True Then
                    For i As Integer = 1 To pvalues.NoofCopies
                        If i = 1 Then
                            PrintVoucher(Me, TransList.Item(0, TransList.CurrentRow.Index).Value, vhtype, 1, False, pvalues.PrinterName, False)
                        Else
                            PrintVoucher(Me, TransList.Item(0, TransList.CurrentRow.Index).Value, vhtype, 1, False, pvalues.PrinterName, True)
                        End If
                    Next

                Else
                    PrintVoucher(Me, TransList.Item(0, TransList.CurrentRow.Index).Value, vhtype, 1, False, pvalues.PrinterName, False)
                End If

            End If
        End If

    End Sub

    Private Sub ImsButton3_Click(sender As System.Object, e As System.EventArgs) Handles BtnChequePrint.Click, ChequePrintToolStripMenuItem.Click
        If TransList.SelectedRows.Count <= 0 Then Exit Sub
        If vhtype = VoucherType.Payment Then
            Dim pvalues As New PrintParameters
            Dim QDebitName As String = ""
            Dim QcreditName As String = ""
            Dim SQLstr As String = ""
            Dim QAmt As Double = 0
            Dim Tcode As Double = 0
            QDebitName = SQLGetStringFieldValue("select ledgername from ledgerbook where transcode=" & TransList.Item(0, TransList.CurrentRow.Index).Value, "Ledgername")
            Dim SqlConn As New SqlClient.SqlConnection

            SQLstr = "select ledgername, cr,TransDate,transcode from ledgerbook where transcode=" & TransList.Item(0, TransList.CurrentRow.Index).Value & " and sno>1 and cr>0 "
            Dim Sqlcmmd As New SqlClient.SqlCommand
            Try
                SqlConn.ConnectionString = ConnectionStrinG
                SqlConn.Open()
                Sqlcmmd.Connection = SqlConn
                Sqlcmmd.CommandText = SQLstr
                Sqlcmmd.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = Sqlcmmd.ExecuteReader
                While Sreader.Read()
                    QcreditName = Sreader("ledgername").ToString.Trim
                    If IsBankLedger(QcreditName) = True Then
                        Tcode = Sreader("transcode")
                        Prtchequevalues.PayeeName = SQLGetStringFieldValue("SELECT details FROM chequeinfo WHERE TRANSCODE=" & Tcode, "details")
                        Prtchequevalues.Amount = Sreader("cr")
                        Prtchequevalues.PrintDate = Sreader("TransDate")
                        Prtchequevalues.AmountinWords = GetInWords(Prtchequevalues.Amount)
                        Exit While
                    End If
                End While
                Sreader.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SqlConn.Close()
                SqlConn = Nothing
                Sqlcmmd.Connection = Nothing
            End Try

            If QcreditName.Length > 1 Then
                Dim printk As New VoucherPrintDlg(pvalues)
                printk.Text = "Cheque Printing"
                printk.TxtHeading.Text = "CHEQUE PRINTING"
                VhSchemeName = SQLGetStringFieldValue("select  f1 from ledgers where ledgername=N'" & QcreditName & "'", "f1")
                If printk.ShowDialog = DialogResult.OK Then
                    LoadChequePageSetupValues(VhSchemeName)
                    Dim ppd As New PrintPreviewDialog()
                    ppd.Document = PrintDocument1
                    If pvalues.NoofCopies > 0 Then
                        PrintDocument1.DefaultPageSettings.PrinterSettings.Copies = pvalues.NoofCopies
                    End If
                    If pvalues.IsPrintToPrinter = True Then
                        PrintDocument1.Print()
                    ElseIf pvalues.IsPrintToPrinter = False Then
                        ppd.ShowDialog()
                    End If
                    ExecuteSQLQuery("UPDATE LEDGERBOOK SET IsChequePrint='True' where transcode=" & Tcode)
                    ExecuteSQLQuery("UPDATE chequeinfo SET Isprinted='True' where transcode=" & Tcode)
                End If
            End If
        End If


    End Sub

    Private Sub ImsButton4_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If TransList.SelectedRows.Count <= 0 Then Exit Sub
        If IsAuditConfirm(TransList.Item(0, TransList.CurrentRow.Index).Value) = True Then
            MsgBox("The Selected Entry can not be Editable....", MsgBoxStyle.Information)
            Exit Sub
        End If
        'If TransList.RowCount = 0 Then Exit Sub
        If TransList.CurrentRow.Index < 0 Then
            Exit Sub
        End If
        If MsgBox("Do You want to Modify ?                 ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            OpenedRTransCode = TransList.Item(0, TransList.CurrentRow.Index).Value
            OpenVoucherByID(OpenedRTransCode)
        End If

    End Sub

    Private Sub Delete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem.Click
        If TransList.SelectedRows.Count <= 0 Then Exit Sub
        If TransList.CurrentRow.Index < 0 Then
            Exit Sub
        End If
        If IsAuditConfirm(TransList.Item(0, TransList.CurrentRow.Index).Value) = True Then
            MsgBox("The Selected Entry can not be Editable....", MsgBoxStyle.Information)
            Exit Sub
        End If
        If MsgBox("Do You want to Delete the Voucher Details =" & TransList.Item(2, TransList.CurrentRow.Index).Value & " and Voucher No =" & TransList.Item(3, TransList.CurrentRow.Index).Value & " ?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.DefaultButton2, "Delete The Voucher ?") = MsgBoxResult.Yes Then
            ExecuteSQLQuery("update ledgerbook set IsDeleted=1 where transcode=" & TransList.Item(0, TransList.CurrentRow.Index).Value)
            ExecuteSQLQuery("delete from bill2bill where  transcode=" & TransList.Item(0, TransList.CurrentRow.Index).Value)
            ExecuteSQLQuery("delete from chequeinfo where TransCode=" & TransList.Item(0, TransList.CurrentRow.Index).Value)
            ExecuteSQLQuery("delete from costcenterbook where TransCode=" & TransList.Item(0, TransList.CurrentRow.Index).Value)
            LoadDef()

        End If
    End Sub
End Class