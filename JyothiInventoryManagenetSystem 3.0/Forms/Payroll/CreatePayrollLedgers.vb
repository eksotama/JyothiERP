Imports System.Windows.Forms
Imports System.IO
Public Class CreatePayrollLedgers

    Dim Photoname As String = ""
    Dim IsOpenForAlter As Boolean = False
    Dim OpenedTransCode As Single = 0
    Dim OpendeCode As String = ""
    Dim EditValues As New EditValuesStruct
    Dim LedgerNameforEdit As String = ""
    Dim OpenedCurrencyRate As Double = 1
    Dim isImagechanged As Boolean = False
    Sub loadDefaults()
        TabControl1.SelectedTab = TabControl1.TabPages(0)
        TxtCode.Text = GetIDCode(EnumIDType.Accounts)
        TxtLedgerName.Text = ""
        TxtCurrency.Text = CompDetails.Currency
        TxtPic.Image = My.Resources.NOPIC
        TxtPic.SizeMode = PictureBoxSizeMode.StretchImage
        isImagechanged = False

        LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "' or groupname=N'" & AccountGroupNames.DutiesTaxes & "' or groupname=N'" & AccountGroupNames.LoansAdvancesAssets & "' or groupname=N'" & AccountGroupNames.DirectExpenses & "' or groupname=N'" & AccountGroupNames.DirectIncomes & "' ", TxtUnderGroup, "subgroup")
        LoadDataIntoComboBox("select distinct country from ledgers", TxtCountry, "country")
        LoadDataIntoComboBox("select distinct state from ledgers", TxtState, "state")
        TxtCreditDays.Text = "30"
        TxtCreditLimit.Text = "0"
        TxtDesignation.Text = ""
        TxtDiscount.Text = "0"
        TxtAccountNo.Text = ""
        TxtEmailID.Text = ""
        TxtFax.Text = ""
        TxtOpBalanceAmt.Text = "0"
        TxtNOpenBalanceAmt.Text = "0"
        TxtPEmailid.Text = ""
        TxtPMobile.Text = ""
        TxtPono.Text = ""
        TxtPostalCode.Text = ""
        OpenedCurrencyRate = 1
        Photoname = ""
        OpendeCode = ""
        OpenedTransCode = 0
        TxtNOpenBalanceAmt.Text = "0"
        TxtNDrcr.Text = "Cr"
        TxtOpDate.Value = Now
        TxtOpBillDate.Value = Now
        IsOpenForAlter = False
        TxtPPerson.Text = ""
        TxtPtel.Text = ""
        TxtRegNo.Text = ""
        Txtstreet.Text = ""
        TxtWebsite.Text = ""
        IsBill2Bill.Checked = False
        TxtBill2BillList.ClearAll()
    End Sub
    Sub New(Optional ByVal EditLedgerName As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If EditLedgerName.Length > 0 Then
            LedgerNameforEdit = EditLedgerName
            IsOpenForAlter = True
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub LoadonOpen()
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Dim SQLStr As String = ""
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = "select * from ledgers where ledgername=N'" & LedgerNameforEdit & "'"
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()
                TxtLedgerName.Text = Sreader("LedgerName").ToString.Trim
                TxtCode.Text = Sreader("LedgerCode").ToString.Trim
                '  TxtAcitvity.Text = Sreader("Activity").ToString.Trim
                TxtRegNo.Text = Sreader("TaxRegno").ToString.Trim
                TxtUnderGroup.Text = Sreader("AccountGroup").ToString.Trim
                Txtstreet.Text = Sreader("address").ToString.Trim
                Txtstreet.Text = Sreader("location").ToString.Trim
                TxtState.Text = Sreader("state").ToString.Trim
                TxtCountry.Text = Sreader("country").ToString.Trim
                TxtTel.Text = Sreader("Tel").ToString.Trim
                TxtFax.Text = Sreader("fax").ToString.Trim
                TxtEmailID.Text = Sreader("emailid").ToString.Trim
                TxtWebsite.Text = Sreader("website").ToString.Trim
                TxtUnderGroup.Text = Sreader("accounttype").ToString.Trim
                EditValues.IsActive = Sreader("Isactive")
                TxtCreditLimit.Text = Sreader("creditlimit")
                TxtDiscount.Text = Sreader("discount")
                TxtPPerson.Text = Sreader("Contactperson").ToString.Trim
                TxtDesignation.Text = Sreader("pdesignation").ToString.Trim
                TxtPtel.Text = Sreader("ptel").ToString.Trim
                TxtPMobile.Text = Sreader("pphoneno").ToString.Trim
                TxtPEmailid.Text = Sreader("pemail").ToString.Trim

                EditValues.isBillWise = Sreader("IsBillWise")
                Dim k As Double = 0
                If EditValues.isBillWise = 1 Then
                    k = Sreader("OpDr")
                    If k > 0 Then
                        TxtDrCr.Text = "Dr"
                        TxtOpBalanceAmt.Text = Sreader("OpDr")
                    Else
                        TxtDrCr.Text = "Cr"
                        TxtOpBalanceAmt.Text = Sreader("OpCr")
                    End If

                Else
                    k = Sreader("OpDr")
                    If k > 0 Then
                        TxtNDrcr.Text = "Dr"
                        TxtNOpenBalanceAmt.Text = Sreader("OpDr")
                    Else
                        TxtDrCr.Text = "Cr"
                        TxtNOpenBalanceAmt.Text = Sreader("OpCr")
                    End If
                End If
                EditValues.PhotoPath = Sreader("photopath").ToString.Trim
                Try
                    TxtPic.Image = GetImageFromDatabase("ImageData", "SELECT TOP 1  IMAGEDATA FROM IMAGES where BCODE=N'EMP" & TxtCode.Text & "'")
                Catch ex As Exception

                End Try
                isImagechanged = False
                TxtCreditDays.Text = Sreader("CreditPeriod")
                TxtCurrency.Text = Sreader("Currency").ToString.Trim
                Try
                    If Sreader("IsAllowCostCentre") = "True" Then
                        TxtIsAllowCostCentre.Text = "Yes"
                    Else
                        TxtIsAllowCostCentre.Text = "No"
                    End If

                Catch ex As Exception
                    TxtIsAllowCostCentre.Text = "No"
                End Try
            End While
            Sreader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn = Nothing
            Sqlcmmd.Connection = Nothing

        End Try
        IsBill2Bill.Checked = False
        If EditValues.isBillWise = 1 Then
            IsBill2Bill.Checked = True
            '& "' and isopening=1"
            Dim SqlConn1 As New SqlClient.SqlConnection
            Dim Sqlcmmd1 As New SqlClient.SqlCommand
            Try
                SqlConn1.ConnectionString = ConnectionStrinG
                SqlConn1.Open()
                Sqlcmmd1.Connection = SqlConn1
                Sqlcmmd1.CommandText = "select * from Bill2bill where ledgername=N'" & LedgerNameforEdit & "' and isopening=1"
                Sqlcmmd1.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = Sqlcmmd1.ExecuteReader
                TxtBill2BillList.ClearAll()
                Dim Brow As Integer = 0
                While Sreader.Read()
                    TxtBill2BillList.AddNew()
                    TxtBill2BillList.SetItem(0, Brow, Sreader("transdate"))
                    TxtBill2BillList.SetItem(1, Brow, Sreader("RefNo"))
                    TxtBill2BillList.SetItem(2, Brow, Sreader("InvoiceNo"))
                    TxtBill2BillList.SetItem(3, Brow, Sreader("Dr"))
                    TxtBill2BillList.SetItem(4, Brow, Sreader("Cr"))
                    TxtBill2BillList.SetBill2BillTransCode(Brow, Sreader("transcode"))
                    Brow = Brow + 1
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SqlConn1.Close()
                SqlConn1 = Nothing
                Sqlcmmd1.Connection = Nothing
            End Try

        End If
        Try
            TxtOpDate.Value = SQLGetStringFieldValue("select transdate from ledgerbook where ledgername=N'" & LedgerNameforEdit & "'", "transdate")
        Catch ex As Exception

        End Try
        If SQLIsFieldExists("SELECT TOP 1 1 from   ledgerbook where ledgername=N'" & LedgerNameforEdit & "'") = True Then
            TxtCurrency.Enabled = False
        Else
            TxtCurrency.Enabled = True
        End If
    End Sub
    Private Sub IsBill2Bill_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsBill2Bill.CheckedChanged
        If IsBill2Bill.Checked = True Then
            TxtBill2BillListPanel.Visible = True
            TxtSimpleOpeningBalance.Visible = False
        Else
            TxtBill2BillListPanel.Visible = False
            TxtSimpleOpeningBalance.Visible = True
        End If
    End Sub

    Private Sub CreateLedgerAccounts_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtLedgerName.Focus()
    End Sub

    Private Sub CreateSuppliers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select CurrencyCode from currencylist ", TxtCurrency, "CurrencyCode")
        If IsOpenForAlter = True Then
            BtnSave.Text = "&Alter"
            loadDefaults()
            IsOpenForAlter = True
            LoadonOpen()
        Else
            loadDefaults()
        End If
    End Sub

    Private Sub TxtBill2BillList_AmountChanged(ByVal e As Object) Handles TxtBill2BillList.AmountChanged
        Dim cramt As Double
        Dim dramt As Double
        dramt = TxtBill2BillList.GetDrTotalAmount()
        cramt = TxtBill2BillList.GetCrTotalAmount()
        If cramt - dramt > 0 Then
            TxtOpBalanceAmt.Text = cramt - dramt
            TxtDrCr.Text = "Cr"
        Else
            TxtOpBalanceAmt.Text = dramt - cramt
            TxtDrCr.Text = "Dr"
        End If
    End Sub


    Private Sub ImSlabel28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        TxtPic.Image = My.Resources.NOPIC
        Photoname = ""
        isImagechanged = True
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Dim sd As OpenFileDialog = New OpenFileDialog
        sd.Title = "Select Image "
        sd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
        ' sd.Filter = "Bitmap |*.bmp| JPG | *.jpg | GIF | *.gif | All Files|*.*"
        sd.FilterIndex = 1
        sd.Multiselect = False
        If sd.ShowDialog = Windows.Forms.DialogResult.OK Then
            TxtPic.Image = Image.FromFile(sd.FileName)
            Photoname = sd.FileName
            isImagechanged = True
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If TxtLedgerName.Text.Length < 2 Then
            MsgBox("Please Enter the Supplier Name ", MsgBoxStyle.Information)
            TxtLedgerName.Focus()
            Exit Sub
        End If
        If TxtUnderGroup.Text.Length = 0 Then
            MsgBox("Please Select the Account Type  ", MsgBoxStyle.Information)
            TxtUnderGroup.Focus()
            Exit Sub
        End If
        If TxtCurrency.Text.Length = 0 Then
            MsgBox("Please Select the Currency ..     ", MsgBoxStyle.Information)
            TxtCurrency.Focus()
            Exit Sub

        End If
        If IsOpenForAlter = True Then
            If UCase(TxtLedgerName.Text) <> UCase(LedgerNameforEdit) Then
                If UCase(Replace(TxtLedgerName.Text, " ", "")) <> UCase(Replace(LedgerNameforEdit, " ", "")) Then
                    If SQLIsFieldExists("SELECT TOP 1 1 from   ledgers where LedgerNameTemp=N'" & Replace(TxtLedgerName.Text, " ", "") & "'") = True Then
                        MsgBox("The Ledger Account with the same name is exists, Please Try again...")
                        TxtLedgerName.Focus()
                        Exit Sub
                    End If
                End If

                If IsthereanyUsersLogin() > 0 Then
                    MsgBox("Currently some users are logged In, Rename is not recommended..... ", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If Application.OpenForms.Count > 3 Then
                    MsgBox("Please Close all Forms  and try again.....", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If
        Else
            If SQLIsFieldExists("SELECT TOP 1 1 from   ledgers where LedgerNameTemp=N'" & Replace(TxtLedgerName.Text, " ", "") & "'") = True Then
                MsgBox("The Ledger Account with the same name is exists, Please Try again...")
                TxtLedgerName.Focus()
                Exit Sub
            End If
        End If

        If MsgBox("Do you want to create ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, MySoftwareName) = MsgBoxResult.No Then
            Exit Sub
        End If
        If IsOpenForAlter = True Then
            OpenedCurrencyRate = SQLGetNumericFieldValue("select ConRate from ledgerbook WHERE LEDGERNAME=N'" & LedgerNameforEdit & "' AND TRANSCODE=0", "ConRate")
            If OpenedCurrencyRate = 0 Then OpenedCurrencyRate = 1
            ExecuteSQLQuery("DELETE FROM LEDGERS WHERE LEDGERNAME=N'" & LedgerNameforEdit & "'")
            ExecuteSQLQuery("DELETE FROM Bill2bill WHERE LEDGERNAME=N'" & LedgerNameforEdit & "' and isopening=1")
            ExecuteSQLQuery("DELETE FROM LEDGERBOOK WHERE LEDGERNAME=N'" & LedgerNameforEdit & "' AND TRANSCODE=0")
        Else
            TxtCode.Text = GetAndSetIDCode(EnumIDType.Accounts)
            OpenedCurrencyRate = GetCurrencyRate(TxtCurrency.Text)
        End If

        Dim SqlStr As String = ""
        SqlStr = "INSERT INTO [ledgers] ([LedgerName],[LedgerCode],[TaxRegno],[AccountGroup],[address],[location],[state],[country],[Tel],[fax],[emailid],[website]," _
            & "[accounttype],[createdby],[alterby],[verifiedby],[Isactive],[creditlimit],[discount],[Contactperson],[pdesignation],[ptel],[pphoneno]," _
            & "[pemail],[Dr],[Cr],[OpDr],[OpCr],[IsBillWise],[photopath],[currentbalance],[partyaddresscity],[StoreName],[CreditPeriod],[Currency],[LedgerNameTemp],[BankAccNo],[EnableChequePrinting],[pincode],[IsAllowCostCentre],[n1]) " _
            & "VALUES (@LedgerName,@LedgerCode,@TaxRegno,@AccountGroup,@address,@location,@state,@country,@Tel,@fax,@emailid,@website,@accounttype,@createdby,@alterby," _
            & "@verifiedby,@Isactive,@creditlimit,@discount,@Contactperson,@pdesignation,@ptel,@pphoneno,@pemail,@Dr,@Cr,@OpDr,@OpCr,@IsBillWise, " _
            & "@photopath,@currentbalance,@partyaddresscity,@StoreName,@CreditPeriod,@Currency,@LedgerNameTemp,@BankAccNo,@EnableChequePrinting,@pincode,@IsAllowCostCentre,@n1)"
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBF.Parameters
            .AddWithValue("LedgerName", TxtLedgerName.Text)
            .AddWithValue("LedgerCode", TxtCode.Text)
            .AddWithValue("TaxRegno", TxtRegNo.Text)
            .AddWithValue("AccountGroup", TxtUnderGroup.Text)
            'BankAccNo
            .AddWithValue("BankAccNo", TxtAccountNo.Text)
            .AddWithValue("address", Txtstreet.Text)
            .AddWithValue("location", Txtstreet.Text)
            .AddWithValue("state", TxtState.Text)
            .AddWithValue("country", TxtCountry.Text)
            .AddWithValue("Tel", TxtTel.Text)
            .AddWithValue("fax", TxtFax.Text)
            .AddWithValue("emailid", TxtEmailID.Text)
            .AddWithValue("website", TxtWebsite.Text)
            .AddWithValue("accounttype", TxtUnderGroup.Text)
            .AddWithValue("createdby", CurrentUserName)
            .AddWithValue("alterby", "")
            .AddWithValue("verifiedby", "")
            .AddWithValue("Isactive", 1)
            .AddWithValue("creditlimit", TxtCreditLimit.Text)
            .AddWithValue("discount", TxtDiscount.Text)
            .AddWithValue("Contactperson", TxtPPerson.Text)
            .AddWithValue("pdesignation", TxtDesignation.Text)
            .AddWithValue("ptel", TxtPtel.Text)
            .AddWithValue("pphoneno", TxtPMobile.Text)
            .AddWithValue("pemail", TxtPEmailid.Text)
            If IsBill2Bill.Checked = True Then
                If TxtDrCr.Text = "Dr" Then
                    .AddWithValue("Dr", TxtOpBalanceAmt.Text)
                    .AddWithValue("Cr", 0)
                    .AddWithValue("OpDr", TxtOpBalanceAmt.Text)
                    .AddWithValue("OpCr", 0)
                Else
                    .AddWithValue("Dr", 0)
                    .AddWithValue("Cr", TxtOpBalanceAmt.Text)
                    .AddWithValue("OpDr", 0)
                    .AddWithValue("OpCr", TxtOpBalanceAmt.Text)
                End If
                .AddWithValue("IsBillWise", 1)

            Else

                If TxtNDrcr.Text = "Dr" Then
                    .AddWithValue("Dr", TxtNOpenBalanceAmt.Text)
                    .AddWithValue("Cr", 0)
                    .AddWithValue("OpDr", TxtNOpenBalanceAmt.Text)
                    .AddWithValue("OpCr", 0)
                Else
                    .AddWithValue("Dr", 0)
                    .AddWithValue("Cr", TxtNOpenBalanceAmt.Text)
                    .AddWithValue("OpDr", 0)
                    .AddWithValue("OpCr", TxtNOpenBalanceAmt.Text)
                End If
                .AddWithValue("IsBillWise", 0)
            End If
            .AddWithValue("photopath", PhotoPathForLedgers & "\" & TxtCode.Text & ".jpg")
            .AddWithValue("currentbalance", 0)
            .AddWithValue("partyaddresscity", Txtstreet.Text & TxtState.Text)
            .AddWithValue("StoreName", DefStoreName)
            .AddWithValue("CreditPeriod", TxtCreditDays.Text)
            If IsChequePrinting.Checked = True Then
                .AddWithValue("EnableChequePrinting", "True")
            Else
                .AddWithValue("EnableChequePrinting", "False")
            End If
            .AddWithValue("pincode", TxtPostalCode.Text)
            .AddWithValue("n1", 2)
            .AddWithValue("Currency", TxtCurrency.Text)
            .AddWithValue("LedgerNameTemp", Replace(TxtLedgerName.Text, " ", ""))
            If TxtIsAllowCostCentre.Text = "No" Or TxtIsAllowCostCentre.Text.Length = 0 Then
                .AddWithValue("IsAllowCostCentre", "False")
            Else
                .AddWithValue("IsAllowCostCentre", "True")
            End If
        End With
        DBF.ExecuteNonQuery()
        DBF = Nothing
        MAINCON.Close()

        If IsBill2Bill.Checked = True And CDbl(TxtOpBalanceAmt.Text) > 0 Then
            For i As Integer = 0 To TxtBill2BillList.GetRows - 1
                If TxtBill2BillList.GetItem(1, i).Length > 0 Then
                    Dim dramt As Double
                    Dim cramt As Double
                    dramt = CDbl(TxtBill2BillList.GetItem(3, i))
                    cramt = CDbl(TxtBill2BillList.GetItem(4, i))
                    If dramt > 0 Or cramt > 0 Then
                        SqlStr = "INSERT INTO [Bill2Bill]([BillType],[LedgerName],[TransCode],[BillTransCode],[Dr],[Cr],[RefNo],[InvoiceNo],[IsOpening],[TransDate],[StoreName],[PayDays]) " _
                                & " VALUES(@BillType,@LedgerName,@TransCode,@BillTransCode,@Dr,@Cr,@RefNo,@InvoiceNo,@IsOpening,@TransDate,@StoreName,@PayDays) "

                        MAINCON.ConnectionString = ConnectionStrinG
                        MAINCON.Open()
                        Dim DBF1 As New SqlClient.SqlCommand(SqlStr, MAINCON)
                        With DBF1.Parameters
                            .AddWithValue("BillType", "New")
                            .AddWithValue("LedgerName", TxtLedgerName.Text)
                            If TxtBill2BillList.GetBill2BillTransCode(i) = 0 Then
                                .AddWithValue("TransCode", GetAndSetIDCode(EnumIDType.Bill2BillCode))
                            Else
                                .AddWithValue("TransCode", TxtBill2BillList.GetBill2BillTransCode(i))
                            End If
                            .AddWithValue("BillTransCode", 0)
                            If dramt > 0 Then
                                .AddWithValue("Dr", dramt)
                                .AddWithValue("cr", 0)
                            Else
                                .AddWithValue("Dr", 0)
                                .AddWithValue("cr", cramt)
                            End If
                            .AddWithValue("RefNo", TxtBill2BillList.GetItem(1, i))
                            .AddWithValue("InvoiceNo", TxtBill2BillList.GetItem(2, i))
                            .AddWithValue("IsOpening", 1)
                            Dim tdate As New DateTimePicker
                            tdate.Value = CDate(TxtBill2BillList.GetItem(0, i))
                            .AddWithValue("TransDate", tdate.Value)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("PayDays", TxtCreditDays.Text)

                        End With
                        DBF1.ExecuteNonQuery()
                        DBF1 = Nothing
                        MAINCON.Close()
                    End If

                End If
            Next
        End If


        If IsBill2Bill.Checked = True Then
            If CDbl(TxtOpBalanceAmt.Text) > 0 Then
                SqlStr = "INSERT INTO [LedgerBook] ([LedgerName],[TransCode],[InvoiceNo],[InvoiceType],[InvoiceName],[sno],[Dr],[Cr],[TransDate]," _
                   & " [TransDateValue],[LedgerGroup],[AcLedger],[IsAdvance],[IsDeleted],[UserName],[StoreName],[Narration],[ConRate],[currencycode]) " _
                   & " VALUES(@LedgerName,@TransCode,@InvoiceNo,@InvoiceType,@InvoiceName,@sno,@Dr,@Cr,@TransDate,@TransDateValue,@LedgerGroup," _
                   & " @AcLedger,@IsAdvance,@IsDeleted,@UserName,@StoreName,@Narration,@ConRate,@currencycode)"

                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim DBF1 As New SqlClient.SqlCommand(SqlStr, MAINCON)
                With DBF1.Parameters
                    .AddWithValue("LedgerName", TxtLedgerName.Text)
                    .AddWithValue("TransCode", 0)
                    .AddWithValue("InvoiceNo", 0)
                    .AddWithValue("InvoiceType", "Opening Balance")
                    .AddWithValue("InvoiceName", "Opening Balance")
                    .AddWithValue("sno", 1)
                    If TxtDrCr.Text = "Dr" Then
                        .AddWithValue("Dr", TxtOpBalanceAmt.Text)
                        .AddWithValue("Cr", 0)
                    Else
                        .AddWithValue("Dr", 0)
                        .AddWithValue("Cr", TxtOpBalanceAmt.Text)
                    End If

                    .AddWithValue("TransDate", TxtOpBillDate.Value)
                    .AddWithValue("TransDateValue", TxtOpBillDate.Value.Date.ToOADate)
                    .AddWithValue("LedgerGroup", TxtUnderGroup.Text)
                    .AddWithValue("AcLedger", "Opening")
                    .AddWithValue("IsAdvance", 0)
                    .AddWithValue("IsDeleted", 0)
                    .AddWithValue("UserName", CurrentUserName)
                    .AddWithValue("StoreName", DefStoreName)
                    .AddWithValue("Narration", "Opening Balances")
                    .AddWithValue("currencycode", UCase(TxtCurrency.Text))
                    .AddWithValue("ConRate", OpenedCurrencyRate)
                End With
                DBF1.ExecuteNonQuery()
                DBF1 = Nothing
                MAINCON.Close()
            End If
        Else
            If CDbl(TxtNOpenBalanceAmt.Text) > 0 Then
                SqlStr = "INSERT INTO [LedgerBook] ([LedgerName],[TransCode],[InvoiceNo],[InvoiceType],[InvoiceName],[sno],[Dr],[Cr],[TransDate]," _
                    & " [TransDateValue],[LedgerGroup],[AcLedger],[IsAdvance],[IsDeleted],[UserName],[StoreName],[Narration],[ConRate]) " _
                    & " VALUES(@LedgerName,@TransCode,@InvoiceNo,@InvoiceType,@InvoiceName,@sno,@Dr,@Cr,@TransDate,@TransDateValue,@LedgerGroup," _
                    & " @AcLedger,@IsAdvance,@IsDeleted,@UserName,@StoreName,@Narration,@ConRate)"

                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim DBF1 As New SqlClient.SqlCommand(SqlStr, MAINCON)
                With DBF1.Parameters
                    .AddWithValue("LedgerName", TxtLedgerName.Text)
                    .AddWithValue("TransCode", 0)
                    .AddWithValue("InvoiceNo", 0)
                    .AddWithValue("InvoiceType", "Opening Balance")
                    .AddWithValue("InvoiceName", "Opening Balance")
                    .AddWithValue("sno", 1)
                    If TxtNDrcr.Text = "Dr" Then
                        .AddWithValue("Dr", TxtNOpenBalanceAmt.Text)
                        .AddWithValue("Cr", 0)
                    Else
                        .AddWithValue("Dr", 0)
                        .AddWithValue("Cr", TxtNOpenBalanceAmt.Text)
                    End If

                    .AddWithValue("TransDate", TxtOpDate.Value)
                    .AddWithValue("TransDateValue", TxtOpDate.Value.Date.ToOADate)
                    .AddWithValue("LedgerGroup", TxtUnderGroup.Text)
                    .AddWithValue("AcLedger", "Opening")
                    .AddWithValue("IsAdvance", 0)
                    .AddWithValue("IsDeleted", 0)
                    .AddWithValue("UserName", CurrentUserName)
                    .AddWithValue("StoreName", DefStoreName)
                    .AddWithValue("Narration", "Opening Balances")
                    .AddWithValue("ConRate", OpenedCurrencyRate)
                End With
                DBF1.ExecuteNonQuery()
                DBF1 = Nothing
                MAINCON.Close()
            End If
        End If
        If isImagechanged = True Then
            If SQLIsFieldExists("SELECT TOP 1 1 from   images where BCODE=N'LEDGER" & TxtCode.Text & "'") = False Then
                If Photoname.Length > 0 Then
                    InsertImageIntoDatabase(Photoname, "imagedata", "bcode", "INSERT INTO [images] ([ImageData] ,[Bcode])  VALUES (@IMAGEDATA,@BCODE) ", "LEDGER" & TxtCode.Text, "")
                Else
                    InsertImageIntoDatabase(TxtPic.Image, "imagedata", "bcode", "INSERT INTO [images] ([ImageData] ,[Bcode])  VALUES (@IMAGEDATA,@BCODE) ", "LEDGER" & TxtCode.Text, "")
                End If
            Else
                If Photoname.Length > 0 Then
                    UpdateImageIntoDatabase(Photoname, "imagedata", "UPDATE IMAGES SET IMAGEDATA=@IMAGEDATA WHERE BCODE=N'LEDGER" & TxtCode.Text & "'", "")
                Else
                    UpdateImageIntoDatabase(TxtPic.Image, "imagedata", "UPDATE IMAGES SET IMAGEDATA=@IMAGEDATA WHERE BCODE=N'LEDGER" & TxtCode.Text & "'", "")
                End If
            End If
        ElseIf IsOpenForAlter = False Then
            If Photoname.Length > 0 Then
                UpdateImageIntoDatabase(Photoname, "imagedata", "UPDATE IMAGES SET IMAGEDATA=@IMAGEDATA WHERE BCODE=N'LEDGER" & TxtCode.Text & "'", "")
            Else
                UpdateImageIntoDatabase(TxtPic.Image, "imagedata", "UPDATE IMAGES SET IMAGEDATA=@IMAGEDATA WHERE BCODE=N'LEDGER" & TxtCode.Text & "'", "")
            End If
        End If

        If SQLIsFieldExists("SELECT TOP 1 1 from   CURRENCYLIST WHERE CurrencyCode=N'" & TxtCurrency.Text & "'") = False Then
            Dim CurName As String = ""
            CurName = SQLGetStringFieldValue("select CurrencyName from currencies where CurrencyCode=N'" & TxtCurrency.Text & "'", "CurrencyName")
            ExecuteSQLQuery("INSERT INTO [CurrencyList] ([CurrencyName],[CurrencyCode],[CurrencySymbol],[ConRate],[Demicals]) VALUES(N'" & CurName & "',N'" & TxtCurrency.Text & "','',1,2)")
        End If
        If IsOpenForAlter = True Then
            UpdateLogFile(DefStoreName, 0, "Alter Customer", 0, CurrentUserName, "Alterd", System.Environment.MachineName, "Customer was edited")
            AlterLedgerName(TxtLedgerName.Text, LedgerNameforEdit)
            ExecuteSQLQuery("UPDATE LEDGERBOOK SET CurrencyCode=N'" & UCase(TxtCurrency.Text) & "' WHERE LEDGERNAME=N'" & TxtLedgerName.Text & "'")
            Me.Close()

        Else
            UpdateLogFile(DefStoreName, 0, "New Customer", 0, CurrentUserName, "Created", System.Environment.MachineName, "New Customer is created")
            loadDefaults()
            TxtLedgerName.Focus()
        End If

    End Sub

    Private Sub TxtDrCr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDrCr.Click

    End Sub

    Private Sub TxtPEmailid_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPEmailid.LostFocus
        TabControl1.SelectedTab = TabControl1.TabPages(1)
    End Sub


    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub TxtUnderGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUnderGroup.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim k As New CreateAccountGroups
            k.ShowDialog()
            LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.IndirectIncomes & "' or groupname=N'" & AccountGroupNames.DutiesTaxes & "' or groupname=N'" & AccountGroupNames.LoansAdvancesAssets & "' or groupname=N'" & AccountGroupNames.DirectExpenses & "' or groupname=N'" & AccountGroupNames.DirectIncomes & "' ", TxtUnderGroup, "subgroup")
        End If
    End Sub



    Private Sub TxtUnderGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtUnderGroup.SelectedIndexChanged
        IsChequePrinting.Visible = False
        If SQLIsFieldExists("SELECT TOP 1 1 from   accountgroupslist where groupname=N'" & AccountGroupNames.SuppliersAccounts & "' and subgroup=N'" & TxtUnderGroup.Text & "' ") = True Then
            Panel2.Visible = True
            Panel3.Visible = True
        ElseIf SQLIsFieldExists("SELECT TOP 1 1 from   accountgroupslist where groupname=N'" & AccountGroupNames.CustomersAccounts & "' and subgroup=N'" & TxtUnderGroup.Text & "' ") = True Then
            Panel2.Visible = True
            Panel3.Visible = True
        ElseIf SQLIsFieldExists("SELECT TOP 1 1 from   accountgroupslist where groupname=N'" & AccountGroupNames.BankAccounts & "' and subgroup=N'" & TxtUnderGroup.Text & "' ") = True Then

            TxtAcnoLbl.Visible = True
            TxtAccountNo.Visible = True
            IsChequePrinting.Visible = True
            Panel2.Visible = False
            Panel3.Visible = False
        ElseIf SQLIsFieldExists("SELECT TOP 1 1 from   accountgroupslist where groupname=N'" & AccountGroupNames.BankOD & "' and subgroup=N'" & TxtUnderGroup.Text & "' ") = True Then
            TxtAcnoLbl.Visible = True
            TxtAccountNo.Visible = True
            IsChequePrinting.Visible = True
            Panel2.Visible = False
            Panel3.Visible = False
        Else
            TxtAcnoLbl.Visible = False
            TxtAccountNo.Visible = False
            Panel2.Visible = False
            Panel3.Visible = False
        End If
    End Sub
    Private Sub TxtCurrency_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCurrency.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim k As New CreateNewCurrency
            k.Show()
            LoadDataIntoComboBox("select CurrencyCode from currencylist ", TxtCurrency, "CurrencyCode")
        End If
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        Dim k As New WebcamImage
        k.ShowDialog()
        If TempFileNames2.Length > 0 Then
            TxtPic.Image = Image.FromFile(TempFileNames2)
            Photoname = TempFileNames2
            isImagechanged = True
        End If
    End Sub


End Class
