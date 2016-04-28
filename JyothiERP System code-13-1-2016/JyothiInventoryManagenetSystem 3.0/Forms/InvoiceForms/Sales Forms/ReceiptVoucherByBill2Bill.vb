Imports System.Windows.Forms

Public Class ReceiptVoucherByBill2Bill

    Dim RefNo As String = ""
    Dim MaxValue As Double = 0
    Dim OpenedTranscode As Double = 0
    Dim OpenedPDCValues As New PDCSettingsClass
    Public Bill2Billdetails As New Bill2BillClass
    Dim Prtchequevalues As New ChequePrintValuesStruct
    Dim DebitName As String = ""
    Dim CreditName As String = ""
    Dim PaymentMethod As String = ""
    Dim VoucherName As String = "Receipt"
    Sub New(ByVal refnumber As String, ByVal maxamount As Double, ByVal ledgername As String, ByVal tcode As Double)

        ' This call is required by the designer.
        InitializeComponent()
        RefNo = refnumber
        MaxValue = maxamount
        TxtLedgerName.Text = ledgername
        OpenedTranscode = tcode
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    

    Private Sub BtnSave2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave2.Click
        If CDbl(TxtPaidAmount.Text) > MaxValue Then
            MsgBox("The Amount is exceeds the pending balance amount.... ", MsgBoxStyle.Critical)
            TxtPaidAmount.Focus()
            Exit Sub
        End If
        If TxtPayLedgerName.Text.Length = 0 Then
            MsgBox("Please Select the Pay Ledger Account...  ", MsgBoxStyle.Information)
            TxtPayLedgerName.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to save ?               ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If IMSBEGINTRANSACTION() = False Then
                IMSENDTRANSACTION()

                Exit Sub
            Else
                SaveVoucher2()
                Me.Close()
            End If
        End If
        
    End Sub
    Sub SaveVoucher2()

        Dim Trancode As Decimal
        If OpenedTranscode > 0 Then
            OpenedPDCValues = GetPDCValues(OpenedTranscode)
            ExecuteSQLQuery("delete  from ledgerbook where TransCode=" & OpenedTranscode)
            ExecuteSQLQuery("delete from bill2bill where  transcode=" & OpenedTranscode)
            Trancode = OpenedTranscode
            '
        Else
            Trancode = GetAndSetIDCode(EnumIDType.TransCode)
              TxtVoucherNo2.Text = GetAndSetInvoiceNumber(InvoiceNoStrct.receiptvoucher)
            OpenedPDCValues.ischequePrint = False
            If TxtDate2.Value > Today.Date Then
                OpenedPDCValues.IsPDC = True
            Else
                OpenedPDCValues.IsPDC = False
            End If
            OpenedPDCValues.TodayDate.Value = Today.Date
            OpenedPDCValues.IsPDCClear = False

            '   OpenedCurrencyRate = GetCurrencyRate(TxtCurrency.Text)


        End If
        Dim sno As Integer = 1

        DebitName = TxtPayLedgerName.Text
        CreditName = TxtLedgerName.Text
        Dim SqlStr As String = ""
        SqlStr = "INSERT INTO [LedgerBook] ([LedgerName],[TransCode],[InvoiceNo],[InvoiceName],[sno],[Dr],[Cr],[TransDate], " _
               & "[TransDateValue],[LedgerGroup],[AcLedger],[IsAdvance],[IsDeleted],[UserName],[StoreName],[Narration],[InvoiceType],[RefNo],[ConRate],[CounterID]) " _
               & " VALUES (@LedgerName,@TransCode,@InvoiceNo,@InvoiceName,@sno,@Dr,@Cr,@TransDate,@TransDateValue,@LedgerGroup, " _
               & "@AcLedger,@IsAdvance,@IsDeleted,@UserName,@StoreName,@Narration,@InvoiceType,@RefNo,@ConRate,@CounterID) "
        Try

           
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBFR = New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBFR.Parameters
                .AddWithValue("LedgerName", TxtPayLedgerName.Text)
                .AddWithValue("TransCode", Trancode)
                .AddWithValue("InvoiceNo", TxtVoucherNo2.Text)
                .AddWithValue("InvoiceName", "Receipt")
                .AddWithValue("sno", 2)
                .AddWithValue("Dr", CDbl(TxtPaidAmount.Text))
                .AddWithValue("Cr", 0)
                .AddWithValue("AcLedger", CreditName)
                .AddWithValue("TransDate", TxtDate2.Value)
                .AddWithValue("TransDateValue", TxtDate2.Value.Date.ToOADate)
                .AddWithValue("LedgerGroup", "")
                .AddWithValue("IsAdvance", 1)
                .AddWithValue("IsDeleted", 0)
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Narration", TxtNarration2.Text)
                .AddWithValue("InvoiceType", "Receipt")
                .AddWithValue("RefNo", "")
                .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TxtPayLedgerName.Text & "'", "currency").ToString))
                .AddWithValue("CounterID", CurrentCounterID)
            End With
            DBFR.ExecuteNonQuery()
            DBFR = Nothing
            MAINCON.Close()
        Catch ex As Exception

        End Try


      
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBFR2 = New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBFR2.Parameters
            .AddWithValue("LedgerName", TxtLedgerName.Text)
            .AddWithValue("TransCode", Trancode)
            .AddWithValue("InvoiceNo", TxtVoucherNo2.Text)
            .AddWithValue("InvoiceName", "Receipt")
            .AddWithValue("sno", 1)
            .AddWithValue("Dr", 0)
            .AddWithValue("Cr", CDbl(TxtPaidAmount.Text))
            .AddWithValue("AcLedger", DebitName)
            .AddWithValue("TransDate", TxtDate2.Value)
            .AddWithValue("TransDateValue", TxtDate2.Value.Date.ToOADate)
            .AddWithValue("LedgerGroup", "")
            .AddWithValue("IsAdvance", 1)
            .AddWithValue("IsDeleted", 0)
            .AddWithValue("UserName", CurrentUserName)
            .AddWithValue("StoreName", DefStoreName)
            .AddWithValue("Narration", TxtNarration2.Text)
            .AddWithValue("InvoiceType", "Receipt")
            .AddWithValue("RefNo", "")
            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TxtLedgerName.Text & "'", "currency").ToString))
            .AddWithValue("CounterID", CurrentCounterID)
        End With
        DBFR2.ExecuteNonQuery()
        DBFR2 = Nothing
        MAINCON.Close()


       


        If SQLIsFieldExists("SELECT TOP 1 1 from   ledgers where ledgername=N'" & TxtPayLedgerName.Text & "' and   (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.BankOD & "'))") = True Then
            PaymentMethod = "Cheque"
        Else
            PaymentMethod = "Cash"
        End If



        UpdateBill2Bill(Trancode)
        OpenedPDCValues.IsPDC = False
        UpdatePDCValues(Trancode, OpenedPDCValues)

        SaveChequeInfo(Trancode, TxtPayLedgerName.Text)
        IMSENDTRANSACTION()

    End Sub
    Sub UpdateBill2Bill(ByVal tcode As Double)
        ExecuteSQLQuery("delete from bill2bill where  transcode=" & tcode)
        Dim SqlStr As String = ""
        SqlStr = "INSERT INTO [Bill2Bill]([BillType],[LedgerName],[TransCode],[BillTransCode],[Dr],[Cr],[RefNo],[InvoiceNo],[IsOpening],[TransDate],[StoreName],[PayDays],[VoucherName],[PaymentMethod]) " _
                               & " VALUES(@BillType,@LedgerName,@TransCode,@BillTransCode,@Dr,@Cr,@RefNo,@InvoiceNo,@IsOpening,@TransDate,@StoreName,@PayDays,@VoucherName,@PaymentMethod) "

        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF1 As New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBF1.Parameters
            .AddWithValue("BillType", "Against")
            .AddWithValue("LedgerName", TxtLedgerName.Text)
            .AddWithValue("TransCode", tcode)
            .AddWithValue("BillTransCode", tcode)
            .AddWithValue("RefNo", RefNo)
            .AddWithValue("InvoiceNo", TxtVoucherNo2.Text)
            .AddWithValue("IsOpening", 0)
            .AddWithValue("TransDate", TxtDate2.Value)
            .AddWithValue("StoreName", DefStoreName)
            .AddWithValue("PaymentMethod", PaymentMethod)
            .AddWithValue("PayDays", 0)
            .AddWithValue("VoucherName", "Receipt")
            .AddWithValue("Dr", 0)
            .AddWithValue("cr", CDbl(TxtPaidAmount.Text))
        End With
        DBF1.ExecuteNonQuery()
        DBF1 = Nothing
        MAINCON.Close()
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
            .AddWithValue("amount", CDbl(TxtPaidAmount.Text))
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
            SQLFcmd.CommandText = "select * from chequeinfo where  transcode=" & OpenedTranscode
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

    Private Sub TxtPayLedgerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPayLedgerName.SelectedIndexChanged
        If SQLIsFieldExists("SELECT TOP 1 1 from   ledgers where ledgername=N'" & TxtPayLedgerName.Text & "' and   (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.BankOD & "'))") = True Then
            BtnChequeDetails.Visible = True
            TxtPrintName.Text = TxtLedgerName.Text
            TxtChequeNo.Focus()
        Else
            BtnChequeDetails.Visible = False
        End If
    End Sub

    Private Sub BtnClose2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose2.Click
        Me.Close()
    End Sub

    Private Sub ReceiptVoucherByBill2Bill_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub ReceiptVoucherByBill2Bill_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDataIntoComboBox("SELECT LEDGERNAME FROM LEDGERS WHERE Isactive=1 and Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.BankOD & "' ) ", TxtPayLedgerName, "LEDGERNAME")
        If OpenedTranscode > 0 Then
            OpenVoucherByID(OpenedTranscode)
        Else
            TxtVoucherNo2.Text = GetInvVhNumber(InvoiceNoStrct.receiptvoucher)
            TxtRefNo.Text = TxtVoucherNo2.Text
            TxtChequeNo.Text = ""
            TxtChequeDate.Value = Now
            TxtPrintName.Text = ""
            TxtDate2.Value = Now
            TxtDate2.Focus()
        End If
    End Sub
    Sub OpenVoucherByID(ByVal openedID As Single)

        Dim SqlConn As New SqlClient.SqlConnection
        Try
            Dim i As Integer
            i = 1
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from ledgerbook where transcode=" & openedID & " order by sno"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                If i = 2 Then
                    TxtPayLedgerName.Text = Sreader("LedgerName").ToString.Trim
                Else
                    If i = 1 Then
                        TxtVoucherNo2.Text = Sreader("InvoiceNo").ToString.Trim
                        TxtDate2.Value = Sreader("TransDate")
                        TxtNarration2.Text = Sreader("Narration").ToString.Trim
                        TxtPaidAmount.Text = Sreader("cr")
                    End If

                    i = i + 1
                End If
            End While

            BtnClose2.Text = "Cancel"
            BtnSave2.Text = "Alter"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try


        LoadChequeInfoData()


    End Sub
End Class
