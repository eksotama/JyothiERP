Imports System.Data.SqlClient
Imports System.IO

Public Class Company
    Dim CompanyLogoPath As String = ""
    Dim IsCreateNewFromMenuVar As Boolean = False
    Dim TempConStrin As String = ""
    Sub New(Optional ByVal IsCreateNewFromMenu As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()
        IsCreateNewFromMenuVar = IsCreateNewFromMenu
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Dim sd As OpenFileDialog = New OpenFileDialog
        sd.Title = "Select Image "
        'sd.Filter = "JPEG File (*.Jpg) | *.jpg"
        sd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
        sd.FilterIndex = 1
        If sd.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtlogo.WaitOnLoad = True
            txtlogo.LoadAsync(sd.FileName)
            CompanyLogoPath = sd.FileName

        End If
    End Sub
    Sub LoadDefaults()

        TxtCountry.Text = ""
        TxtCmpName.Text = ""
        TxtState.Text = ""
        txtstreet.Text = ""
        txtRegNo.Text = ""
        TxtLicenseno.Text = ""
        txtpoboxno.Text = ""
        txtlogo.Image = My.Resources.NOPIC
        txtlogo.SizeMode = PictureBoxSizeMode.StretchImage
        TxtAdminEmailID.Text = ""
        txtadminname.Text = "Admin"
        txtemailid.Text = ""
        txttelephone.Text = ""
        txtwebsite.Text = ""
        txtfaxno.Text = ""
        txtpassword1.Text = ""
        txtpassword2.Text = ""
        If IsLeadingZeros.Text.Length = 0 Then
            IsLeadingZeros.Text = "NO"
        End If
        If IsFixedLength.Text.Length = 0 Then
            IsFixedLength.Text = "YES"
        End If
        If IsAutoFill.Text.Length = 0 Then
            IsAutoFill.Text = "NO"
        End If
    End Sub
    Private Sub IsFixedLength_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsFixedLength.SelectedIndexChanged
        If IsFixedLength.Text = "YES" Then
            IsAutoFill.Text = "YES"
            IsLeadingZeros.Text = "YES"
            IsLeadingZeros.Enabled = False
        Else
            IsLeadingZeros.Enabled = True
        End If
    End Sub
    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtCmpName.Text.Length < 2 Then
            MsgBox("Please Enter the Company Mailing Name ", MsgBoxStyle.Information, MySoftwareName)
            TxtCmpName.Focus()
            Exit Sub
        End If
        If TxtCompanyID.Text.Length < 2 Then
            MsgBox("Please Enter the Company Name ", MsgBoxStyle.Information, MySoftwareName)
            TxtCompanyID.Focus()
            Exit Sub
        End If
        If MainForm.IsCompanyNameisExists(TxtCompanyID.Text) = True Then
            MsgBox("The Entered Company Name is already exists.. Please try again...", MsgBoxStyle.Critical)
            TxtCompanyID.Focus()
            Exit Sub
        End If
        If TxtState.Text.Length < 2 Then
            MsgBox("Please Enter the State    ", MsgBoxStyle.Information, MySoftwareName)
            TxtState.Focus()
            Exit Sub
        End If
        If TxtCurrency.Text.Length = 0 Then
            MsgBox("Please Select The currency ...            ")
            TxtCurrency.Focus()
            Exit Sub
        End If
        If txtadminname.Text.Length < 4 Then
            MsgBox("Please Enter the admin Name in length 5 letter", MsgBoxStyle.Information, MySoftwareName)
            txtadminname.Focus()
            Exit Sub
        End If
        If IsNumeric(txtadminname.Text.Substring(0, 1).ToString) = True Then
            MsgBox("Admin User name is invalide, can not start with digit..", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If TxtCompanyType.Text.Length = 0 Then
            MsgBox("Select The Company Type        ", MsgBoxStyle.Information, MySoftwareName)
            TxtCompanyType.Focus()
            Exit Sub
        End If
        
        If txtpassword1.Text.Length < 6 Then
            MsgBox("Please Enter the Password in above 5 letter in length...")
            txtpassword1.Focus()
            Exit Sub
        End If
        If txtpassword1.Text <> txtpassword2.Text Then
            MsgBox("The passwords does't match  ...", MsgBoxStyle.Information, MySoftwareName)
            txtpassword1.Focus()
            Exit Sub
        End If
        If TxtSharedFolder.Text.Length <= 2 Then
            MsgBox("Please Create Shared Folder and Enter the Full Path ....")
            TxtSharedFolder.Focus()
            Exit Sub
        End If
        If System.IO.Directory.Exists(TxtSharedFolder.Text) = False Then
            MsgBox("The Entered Shared Folder is not found.....")
            TxtSharedFolder.Focus()
            Exit Sub
        End If
        If txtnoofdecimals.Text.Length = 0 Then
            txtnoofdecimals.Text = "2"
        End If
        If TxtDateFormat.Text.Length = 0 Then
            TxtDateFormat.Text = "DD/MM/YYYY"
        End If
        If MsgBox("Do you want to Create ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        If CreateNewCompany() = False Then
            If IsCreateNewFromMenuVar = True Then
                ConnectionStrinG = TempConStrin
                Me.Cursor = Cursors.Default
            End If
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        Dim ConStr As String = ""
        Dim SQLstr As String = ""
        Dim Backuppath As String = ""
        Dim Photopath As String = ""
        Dim Barcodepath As String = ""
        Try
            System.IO.Directory.CreateDirectory(TxtSharedFolder.Text & "\" & NewCompanyDBName)
            System.IO.Directory.CreateDirectory(TxtSharedFolder.Text & "\" & NewCompanyDBName & "\Images")
            System.IO.Directory.CreateDirectory(TxtSharedFolder.Text & "\" & NewCompanyDBName & "\Images\StockPhotos")
            System.IO.Directory.CreateDirectory(TxtSharedFolder.Text & "\" & NewCompanyDBName & "\Images\Others")
            System.IO.Directory.CreateDirectory(TxtSharedFolder.Text & "\" & NewCompanyDBName & "\Images\CompanyImages")
            System.IO.Directory.CreateDirectory(TxtSharedFolder.Text & "\" & NewCompanyDBName & "\Backup")
            System.IO.Directory.CreateDirectory(TxtSharedFolder.Text & "\" & NewCompanyDBName & "\BarCodeImages")
        Catch ex As Exception

        End Try






        ConStr = ConnectionStringFromFile & " Initial Catalog=" & NewCompanyDBName & ";"
        '"Server=" & TxtSoftwareSQlServer & ";Integrated Security=True;Initial Catalog=" & NewCompanyDBName & "; User ID=" & txtSoftwareSQlUserID & ";"

        Backuppath = TxtSharedFolder.Text & "\" & NewCompanyDBName & "\Backup"
        Photopath = TxtSharedFolder.Text & "\" & NewCompanyDBName & "\Images"
        Barcodepath = TxtSharedFolder.Text & "\" & NewCompanyDBName & "\BarCodeImages"

        If CompanyLogoPath.Length > 0 Then

            Try
                My.Computer.FileSystem.DeleteFile(Photopath & "\CompanyImages\CompanyLogo.jpg")
            Catch ex As Exception

            End Try
            Try

                txtlogo.Image.Save(Photopath & "\CompanyImages\CompanyLogo.jpg")
                CompanyLogoPath = Photopath & "\CompanyImages\CompanyLogo.jpg"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Try
                My.Computer.FileSystem.DeleteFile(Photopath & "\CompanyImages\CompanyLogo.jpg")
            Catch ex As Exception

            End Try
        End If



        MAINCON.ConnectionString = ConStr
        MAINCON.Open()
        If IsNothing(txtlogo.Image) = True Then
            txtlogo.Image = My.Resources.NOPIC
        End If
        Dim ms As New MemoryStream()
        txtlogo.Image.Save(ms, txtlogo.Image.RawFormat)
        Dim objData As Byte() = ms.GetBuffer()

        SQLstr = "INSERT INTO [company] ([companyname],[licenseno],[taxregno],[address],[location],[state],[country],[Tel],[fax],[emailid],[website],[accounttype],[adminname]," _
           & "[adminpassword],[adminemailid],[Isactive],[logoimage],[accyearstart],[accyearend],[booksyearstart],[booksyearend],[Backupath],[photopath],[BarcodePath],[Currency],[UserSecurityQ1],[UserSecurityQ2],[UserSecurityA1],[UserSecurityA2],[IsSizeBasedItem],[YearStartDate],[YearEndDate],[CurrencyName],[PeriodFrom],[PeriodTo],[Versionno],[CompanyID],[CurrentDate],[noofdecimals],[CstNo],[dateformattext],[DecimalSymbol])  " _
         & " VALUES (@companyname,@licenseno,@taxregno,@address,@location,@state,@country,@tel,@fax,@emailid,@website,@accounttype,@adminname," _
         & "@adminpassword,@adminemailid,@isactive,@logoimage,@accyearstart,@acceyearend,@bookyearstart,@bookyearend,@backpath,@Photopath,@barcodepath,@Currency,@UserSecurityQ1,@UserSecurityQ2,@UserSecurityA1,@UserSecurityA2,@IsSizeBasedItem,@YearStartDate,@YearEndDate,@CurrencyName,@PeriodFrom,@PeriodTo,@Versionno,@CompanyID,@CurrentDate,@noofdecimals,@CstNo,@dateformattext,@DecimalSymbol) "
        Dim k As New DateTimePicker
        Dim sdate As New DateTime(2013, 1, 1)
        Dim edate As New DateTime(2013, 12, 31)
        Dim DBF As New SqlClient.SqlCommand(SQLstr, MAINCON)
        With DBF.Parameters
            .AddWithValue("CompanyID", TxtCompanyID.Text)
            .AddWithValue("companyname", TxtCmpName.Text)
            .AddWithValue("CurrentDate", Today)
            .AddWithValue("noofdecimals", CInt(txtnoofdecimals.Text))
            .AddWithValue("licenseno", TxtLicenseno.Text)
            .AddWithValue("taxregno", txtRegNo.Text)
            .AddWithValue("address", txtpoboxno.Text)
            .AddWithValue("location", txtstreet.Text)
            .AddWithValue("state", TxtState.Text)
            .AddWithValue("country", TxtCountry.Text)
            .AddWithValue("tel", txttelephone.Text)
            .AddWithValue("fax", txtfaxno.Text)
            .AddWithValue("emailid", txtemailid.Text)
            .AddWithValue("website", txtwebsite.Text)
            .AddWithValue("accounttype", TxtCompanyType.Text)
            .AddWithValue("adminname", txtadminname.Text)
            .AddWithValue("adminpassword", EncrypPassword(txtpassword1.Text))
            .AddWithValue("adminemailid", TxtAdminEmailID.Text)
            .AddWithValue("isactive", 1)
            .AddWithValue("logoimage", CompanyLogoPath)
            .AddWithValue("accyearstart", txtAccDateStart.Value.Date)
            .AddWithValue("acceyearend", txtaccdateend.Value.Date)
            .AddWithValue("PeriodFrom", txtAccDateStart.Value.Date)
            .AddWithValue("PeriodTo", txtAccDateStart.Value.Date.AddMonths(1))

            .AddWithValue("bookyearstart", txtbookstartdate.Value.Date)
            .AddWithValue("bookyearend", txtbookenddate.Value.Date)
            .AddWithValue("backpath", Backuppath)
            'Versionno
            .AddWithValue("Versionno", PresentVersionNumber)
            .AddWithValue("Photopath", Photopath)
            .AddWithValue("BarcodePath", Barcodepath)
            .AddWithValue("Currency", UCase(TxtCurrency.Text))
            .AddWithValue("UserSecurityQ1", "Your Software Provider?")
            .AddWithValue("UserSecurityQ2", "Your Software Develope Name?")
            .AddWithValue("UserSecurityA1", "jyothierp")
            .AddWithValue("UserSecurityA2", "jyothi")
            'IsSizeBasedItem
            If TxtIsSizeWise.Checked = True Then
                .AddWithValue("IsSizeBasedItem", "True")
            Else
                .AddWithValue("IsSizeBasedItem", "False")
            End If
            k.Value = sdate
            .AddWithValue("YearStartDate", k.Value.Date)
            k.Value = edate
            .AddWithValue("YearEndDate", k.Value.Date)
            .AddWithValue("CurrencyName", TxtCurrencyName.Text)
            .AddWithValue("CstNo", TxtCSTNo.Text)
            .AddWithValue("dateformattext", TxtDateFormat.Text)
            .AddWithValue("DecimalSymbol", TxtDecimalSymbol.Text)
            'CurrencyName
        End With

        DBF.ExecuteNonQuery()
        MAINCON.Close()




        Try
            SQLstr = "INSERT INTO [CurrencyList] ([CurrencyName],[CurrencyCode],[CurrencySymbol],[IsActive],[ConRate],[Demicals]) " _
     & "VALUES(N'" & TxtCurrencyName.Text & "',N'" & TxtCurrency.Text & "',N'" & TxtCurrency.Text & "',1,1,2)"
            ExecuteSQLQueryWithConString(SQLstr, ConStr)
        Catch ex As Exception

        End Try


        Try
            Dim ms2 As New MemoryStream()
            txtlogo.Image.Save(ms, txtlogo.Image.RawFormat)
            Dim objData2 As Byte() = ms2.GetBuffer()
            Try
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim DBF22 As New SqlClient.SqlCommand("INSERT INTO IMAGES (IMAGEDATA,BCODE) VALUES(@IMAGEDATA,@BCODE)", MAINCON)
                With DBF22.Parameters
                    .AddWithValue("IMAGEDATA", objData)
                    .AddWithValue("bCODE", "@CMP0000L0GO")
                End With
                DBF22.ExecuteNonQuery()
                DBF22 = Nothing
                MAINCON.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex3 As Exception
            MsgBox(ex3.Message)
        End Try

        Try
            SQLstr = "Update settings set SharedFolderName='" & TxtSharedFolder.Text & "'"
            ExecuteSQLQueryWithConString(SQLstr, ConStr)
        Catch ex As Exception

        End Try

      

        Try
            CreateDefaultLedgerAccounts(ConStr)
        Catch ex As Exception

        End Try
        'UPDATE FOR HEADING IN PRINTING SCHEMES SETTINGS
        ExecuteSQLQueryWithConString(" UPDATE printheadings SET  headtext=N'" & TxtCmpName.Text & "'   where  fieldname='CompanyName'", ConStr)
        ExecuteSQLQueryWithConString(" UPDATE printheadings SET  headtext=N'" & txtstreet.Text & "'   where  fieldname='CompanyCity'", ConStr)
        ExecuteSQLQueryWithConString(" UPDATE printheadings SET  headtext=N'" & txtpoboxno.Text & "'   where  fieldname='CompanyAddress'", ConStr)
        ExecuteSQLQueryWithConString(" UPDATE printheadings SET  headtext=N'" & txtRegNo.Text & "'   where  fieldname='CompanyTin'", ConStr)
        ExecuteSQLQueryWithConString(" UPDATE printheadings SET  headtext=N'" & txttelephone.Text & "'   where  fieldname='CompanyContact'", ConStr)
        ExecuteSQLQueryWithConString(" UPDATE printheadings SET  headtext=N'" & TxtCSTNo.Text & "'   where  fieldname='CompanySalesTax'", ConStr)
        ExecuteSQLQueryWithConString(" UPDATE printheadings SET  headtext=N'" & txtpoboxno.Text & "," & txtstreet.Text & "," & TxtState.Text & "'   where  fieldname='CompanyAddressAndCityPinCode'", ConStr)

        If SQLIsFieldExists("SELECT TOP 1 1 from  barcodesettings") = False Then
            ExecuteSQLQuery("INSERT INTO [barcodesettings]([barcodelength],[Isreplacezeros],[Isautofill],[FixedLength],[BarcodeType])     VALUES (" & TxtBarcodeLength.Value & ",'" & IIf(IsLeadingZeros.Text = "YES", "True", "False") & "','" & IIf(IsAutoFill.Text = "YES", "True", "False") & "','" & IIf(IsFixedLength.Text = "YES", "True", "False") & "','CODE128')")
        Else
            ExecuteSQLQuery("UPDATE [barcodesettings]   SET [barcodelength] =" & TxtBarcodeLength.Value & " ,[Isreplacezeros] ='" & IIf(IsLeadingZeros.Text = "YES", "True", "False") & "' ,[Isautofill] ='" & IIf(IsAutoFill.Text = "YES", "True", "False") & "',[FixedLength] ='" & IIf(IsFixedLength.Text = "YES", "True", "False") & "',[BarcodeType] ='CODE128'")
        End If
    
        If IsCreateNewFromMenuVar = True Then
            ConnectionStrinG = TempConStrin
        End If

        Me.Cursor = Cursors.Default
        MsgBox("Create Successfully .........., Please restart the application... ", MsgBoxStyle.Information)

        Me.Close()
    End Sub

    Sub CreateDefaultLedgerAccounts(ByVal constr As String)
        'CREATE CASH LEDGER
        Dim SqlStr As String = ""
        Dim LedgerCode As String = ""
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
            LedgerCode = GetAndSetIDCode(EnumIDType.Accounts)
            .AddWithValue("LedgerName", "Cash")
            .AddWithValue("LedgerCode", LedgerCode)
            .AddWithValue("TaxRegno", "")
            .AddWithValue("AccountGroup", AccountGroupNames.CashAccounts)
            .AddWithValue("BankAccNo", "")
            .AddWithValue("address", "")
            .AddWithValue("location", "")
            .AddWithValue("state", "")
            .AddWithValue("country", "")
            .AddWithValue("Tel", "")
            .AddWithValue("fax", "")
            .AddWithValue("emailid", "")
            .AddWithValue("website", "")
            .AddWithValue("accounttype", AccountGroupNames.CashAccounts)
            .AddWithValue("createdby", "Admin")
            .AddWithValue("alterby", "")
            .AddWithValue("verifiedby", "")
            .AddWithValue("Isactive", 1)
            .AddWithValue("creditlimit", 10000)
            .AddWithValue("discount", 0)
            .AddWithValue("Contactperson", "")
            .AddWithValue("pdesignation", "")
            .AddWithValue("ptel", "")
            .AddWithValue("pphoneno", "")
            .AddWithValue("pemail", "")
            .AddWithValue("Dr", 0)
            .AddWithValue("Cr", 0)
            .AddWithValue("OpDr", 0)
            .AddWithValue("OpCr", 0)
            .AddWithValue("IsBillWise", 0)
            .AddWithValue("photopath", PhotoPathForLedgers & "\" & LedgerCode & ".jpg")
            .AddWithValue("currentbalance", 0)
            .AddWithValue("partyaddresscity", "")
            .AddWithValue("StoreName", "MainStore")
            .AddWithValue("CreditPeriod", 30)
            .AddWithValue("EnableChequePrinting", "False")
            .AddWithValue("pincode", "")
            .AddWithValue("Currency", UCase(TxtCurrency.Text))
            .AddWithValue("LedgerNameTemp", "Cash")
            .AddWithValue("IsAllowCostCentre", "False")
            .AddWithValue("n1", 0)
        End With
        DBF.ExecuteNonQuery()
        DBF = Nothing

        'creating Purchase account ledger
        Dim DBF2 As New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBF2.Parameters
            LedgerCode = GetAndSetIDCode(EnumIDType.Accounts)
            .AddWithValue("LedgerName", "Purchase A/c")
            .AddWithValue("LedgerCode", LedgerCode)
            .AddWithValue("TaxRegno", "")
            .AddWithValue("AccountGroup", AccountGroupNames.PurchaseAccounts)
            .AddWithValue("BankAccNo", "")
            .AddWithValue("address", "")
            .AddWithValue("location", "")
            .AddWithValue("state", "")
            .AddWithValue("country", "")
            .AddWithValue("Tel", "")
            .AddWithValue("fax", "")
            .AddWithValue("emailid", "")
            .AddWithValue("website", "")
            .AddWithValue("accounttype", AccountGroupNames.PurchaseAccounts)
            .AddWithValue("createdby", "Admin")
            .AddWithValue("alterby", "")
            .AddWithValue("verifiedby", "")
            .AddWithValue("Isactive", 1)
            .AddWithValue("creditlimit", 10000)
            .AddWithValue("discount", 0)
            .AddWithValue("Contactperson", "")
            .AddWithValue("pdesignation", "")
            .AddWithValue("ptel", "")
            .AddWithValue("pphoneno", "")
            .AddWithValue("pemail", "")
            .AddWithValue("Dr", 0)
            .AddWithValue("Cr", 0)
            .AddWithValue("OpDr", 0)
            .AddWithValue("OpCr", 0)
            .AddWithValue("IsBillWise", 0)
            .AddWithValue("photopath", PhotoPathForLedgers & "\" & LedgerCode & ".jpg")
            .AddWithValue("currentbalance", 0)
            .AddWithValue("partyaddresscity", "")
            .AddWithValue("StoreName", "MainStore")
            .AddWithValue("CreditPeriod", 30)
            .AddWithValue("EnableChequePrinting", "False")
            .AddWithValue("pincode", "")
            .AddWithValue("Currency", UCase(TxtCurrency.Text))
            .AddWithValue("LedgerNameTemp", "PurchaseA/c")
            .AddWithValue("IsAllowCostCentre", "False")
            .AddWithValue("n1", 0)
        End With
        DBF2.ExecuteNonQuery()
        DBF2 = Nothing

        'creating Sales account ledger
        Dim DBF3 As New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBF3.Parameters
            LedgerCode = GetAndSetIDCode(EnumIDType.Accounts)
            .AddWithValue("LedgerName", "Sales A/c")
            .AddWithValue("LedgerCode", LedgerCode)
            .AddWithValue("TaxRegno", "")
            .AddWithValue("AccountGroup", AccountGroupNames.SalesAccounts)
            .AddWithValue("BankAccNo", "")
            .AddWithValue("address", "")
            .AddWithValue("location", "")
            .AddWithValue("state", "")
            .AddWithValue("country", "")
            .AddWithValue("Tel", "")
            .AddWithValue("fax", "")
            .AddWithValue("emailid", "")
            .AddWithValue("website", "")
            .AddWithValue("accounttype", AccountGroupNames.SalesAccounts)
            .AddWithValue("createdby", "Admin")
            .AddWithValue("alterby", "")
            .AddWithValue("verifiedby", "")
            .AddWithValue("Isactive", 1)
            .AddWithValue("creditlimit", 10000)
            .AddWithValue("discount", 0)
            .AddWithValue("Contactperson", "")
            .AddWithValue("pdesignation", "")
            .AddWithValue("ptel", "")
            .AddWithValue("pphoneno", "")
            .AddWithValue("pemail", "")
            .AddWithValue("Dr", 0)
            .AddWithValue("Cr", 0)
            .AddWithValue("OpDr", 0)
            .AddWithValue("OpCr", 0)
            .AddWithValue("IsBillWise", 0)
            .AddWithValue("photopath", PhotoPathForLedgers & "\" & LedgerCode & ".jpg")
            .AddWithValue("currentbalance", 0)
            .AddWithValue("partyaddresscity", "")
            .AddWithValue("StoreName", "MainStore")
            .AddWithValue("CreditPeriod", 30)
            .AddWithValue("EnableChequePrinting", "False")
            .AddWithValue("pincode", "")
            .AddWithValue("Currency", UCase(TxtCurrency.Text))
            .AddWithValue("LedgerNameTemp", "SalesA/c")
            .AddWithValue("IsAllowCostCentre", "False")
            .AddWithValue("n1", 0)
        End With
        DBF3.ExecuteNonQuery()
        DBF3 = Nothing


        Dim DBF4 As New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBF4.Parameters
            LedgerCode = GetAndSetIDCode(EnumIDType.Accounts)
            .AddWithValue("LedgerName", "Cd Cr")
            .AddWithValue("LedgerCode", LedgerCode)
            .AddWithValue("TaxRegno", "")
            .AddWithValue("AccountGroup", AccountGroupNames.IndirectIncomes)
            .AddWithValue("BankAccNo", "")
            .AddWithValue("address", "")
            .AddWithValue("location", "")
            .AddWithValue("state", "")
            .AddWithValue("country", "")
            .AddWithValue("Tel", "")
            .AddWithValue("fax", "")
            .AddWithValue("emailid", "")
            .AddWithValue("website", "")
            .AddWithValue("accounttype", AccountGroupNames.IndirectIncomes)
            .AddWithValue("createdby", "Admin")
            .AddWithValue("alterby", "")
            .AddWithValue("verifiedby", "")
            .AddWithValue("Isactive", 1)
            .AddWithValue("creditlimit", 10000)
            .AddWithValue("discount", 0)
            .AddWithValue("Contactperson", "")
            .AddWithValue("pdesignation", "")
            .AddWithValue("ptel", "")
            .AddWithValue("pphoneno", "")
            .AddWithValue("pemail", "")
            .AddWithValue("Dr", 0)
            .AddWithValue("Cr", 0)
            .AddWithValue("OpDr", 0)
            .AddWithValue("OpCr", 0)
            .AddWithValue("IsBillWise", 0)
            .AddWithValue("photopath", PhotoPathForLedgers & "\" & LedgerCode & ".jpg")
            .AddWithValue("currentbalance", 0)
            .AddWithValue("partyaddresscity", "")
            .AddWithValue("StoreName", "MainStore")
            .AddWithValue("CreditPeriod", 30)
            .AddWithValue("EnableChequePrinting", "False")
            .AddWithValue("pincode", "")
            .AddWithValue("Currency", UCase(TxtCurrency.Text))
            .AddWithValue("LedgerNameTemp", "cdcr")
            .AddWithValue("IsAllowCostCentre", "False")
            .AddWithValue("n1", 0)
        End With
        DBF4.ExecuteNonQuery()
        DBF4 = Nothing

        Dim DBF5 As New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBF5.Parameters
            LedgerCode = GetAndSetIDCode(EnumIDType.Accounts)
            .AddWithValue("LedgerName", "Cd Dr")
            .AddWithValue("LedgerCode", LedgerCode)
            .AddWithValue("TaxRegno", "")
            .AddWithValue("AccountGroup", AccountGroupNames.IndirectExpenses)
            .AddWithValue("BankAccNo", "")
            .AddWithValue("address", "")
            .AddWithValue("location", "")
            .AddWithValue("state", "")
            .AddWithValue("country", "")
            .AddWithValue("Tel", "")
            .AddWithValue("fax", "")
            .AddWithValue("emailid", "")
            .AddWithValue("website", "")
            .AddWithValue("accounttype", AccountGroupNames.IndirectExpenses)
            .AddWithValue("createdby", "Admin")
            .AddWithValue("alterby", "")
            .AddWithValue("verifiedby", "")
            .AddWithValue("Isactive", 1)
            .AddWithValue("creditlimit", 10000)
            .AddWithValue("discount", 0)
            .AddWithValue("Contactperson", "")
            .AddWithValue("pdesignation", "")
            .AddWithValue("ptel", "")
            .AddWithValue("pphoneno", "")
            .AddWithValue("pemail", "")
            .AddWithValue("Dr", 0)
            .AddWithValue("Cr", 0)
            .AddWithValue("OpDr", 0)
            .AddWithValue("OpCr", 0)
            .AddWithValue("IsBillWise", 0)
            .AddWithValue("photopath", PhotoPathForLedgers & "\" & LedgerCode & ".jpg")
            .AddWithValue("currentbalance", 0)
            .AddWithValue("partyaddresscity", "")
            .AddWithValue("StoreName", "MainStore")
            .AddWithValue("CreditPeriod", 30)
            .AddWithValue("EnableChequePrinting", "False")
            .AddWithValue("pincode", "")
            .AddWithValue("Currency", UCase(TxtCurrency.Text))
            .AddWithValue("LedgerNameTemp", "cddr")
            .AddWithValue("IsAllowCostCentre", "False")
            .AddWithValue("n1", 0)
        End With
        DBF5.ExecuteNonQuery()
        DBF5 = Nothing

        Dim DBF6 As New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBF6.Parameters
            LedgerCode = GetAndSetIDCode(EnumIDType.Accounts)
            .AddWithValue("LedgerName", "Commission A/c")
            .AddWithValue("LedgerCode", LedgerCode)
            .AddWithValue("TaxRegno", "")
            .AddWithValue("AccountGroup", AccountGroupNames.IndirectExpenses)
            .AddWithValue("BankAccNo", "")
            .AddWithValue("address", "")
            .AddWithValue("location", "")
            .AddWithValue("state", "")
            .AddWithValue("country", "")
            .AddWithValue("Tel", "")
            .AddWithValue("fax", "")
            .AddWithValue("emailid", "")
            .AddWithValue("website", "")
            .AddWithValue("accounttype", AccountGroupNames.IndirectExpenses)
            .AddWithValue("createdby", "Admin")
            .AddWithValue("alterby", "")
            .AddWithValue("verifiedby", "")
            .AddWithValue("Isactive", 1)
            .AddWithValue("creditlimit", 10000)
            .AddWithValue("discount", 0)
            .AddWithValue("Contactperson", "")
            .AddWithValue("pdesignation", "")
            .AddWithValue("ptel", "")
            .AddWithValue("pphoneno", "")
            .AddWithValue("pemail", "")
            .AddWithValue("Dr", 0)
            .AddWithValue("Cr", 0)
            .AddWithValue("OpDr", 0)
            .AddWithValue("OpCr", 0)
            .AddWithValue("IsBillWise", 0)
            .AddWithValue("photopath", PhotoPathForLedgers & "\" & LedgerCode & ".jpg")
            .AddWithValue("currentbalance", 0)
            .AddWithValue("partyaddresscity", "")
            .AddWithValue("StoreName", "MainStore")
            .AddWithValue("CreditPeriod", 30)
            .AddWithValue("EnableChequePrinting", "False")
            .AddWithValue("pincode", "")
            .AddWithValue("Currency", UCase(TxtCurrency.Text))
            .AddWithValue("LedgerNameTemp", "CommissionA/c")
            .AddWithValue("IsAllowCostCentre", "False")
            .AddWithValue("n1", 0)
        End With
        DBF6.ExecuteNonQuery()
        DBF6 = Nothing

        Dim DBF7 As New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBF7.Parameters
            LedgerCode = GetAndSetIDCode(EnumIDType.Accounts)
            .AddWithValue("LedgerName", "Round Off")
            .AddWithValue("LedgerCode", LedgerCode)
            .AddWithValue("TaxRegno", "")
            .AddWithValue("AccountGroup", AccountGroupNames.IndirectExpenses)
            .AddWithValue("BankAccNo", "")
            .AddWithValue("address", "")
            .AddWithValue("location", "")
            .AddWithValue("state", "")
            .AddWithValue("country", "")
            .AddWithValue("Tel", "")
            .AddWithValue("fax", "")
            .AddWithValue("emailid", "")
            .AddWithValue("website", "")
            .AddWithValue("accounttype", AccountGroupNames.IndirectExpenses)
            .AddWithValue("createdby", "Admin")
            .AddWithValue("alterby", "")
            .AddWithValue("verifiedby", "")
            .AddWithValue("Isactive", 1)
            .AddWithValue("creditlimit", 10000)
            .AddWithValue("discount", 0)
            .AddWithValue("Contactperson", "")
            .AddWithValue("pdesignation", "")
            .AddWithValue("ptel", "")
            .AddWithValue("pphoneno", "")
            .AddWithValue("pemail", "")
            .AddWithValue("Dr", 0)
            .AddWithValue("Cr", 0)
            .AddWithValue("OpDr", 0)
            .AddWithValue("OpCr", 0)
            .AddWithValue("IsBillWise", 0)
            .AddWithValue("photopath", PhotoPathForLedgers & "\" & LedgerCode & ".jpg")
            .AddWithValue("currentbalance", 0)
            .AddWithValue("partyaddresscity", "")
            .AddWithValue("StoreName", "MainStore")
            .AddWithValue("CreditPeriod", 30)
            .AddWithValue("EnableChequePrinting", "False")
            .AddWithValue("pincode", "")
            .AddWithValue("Currency", UCase(TxtCurrency.Text))
            .AddWithValue("LedgerNameTemp", "RoundOff")
            .AddWithValue("IsAllowCostCentre", "False")
            .AddWithValue("n1", 0)
        End With
        DBF7.ExecuteNonQuery()
        DBF7 = Nothing

        Dim DBF8 As New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBF8.Parameters
            LedgerCode = GetAndSetIDCode(EnumIDType.Accounts)
            .AddWithValue("LedgerName", "Profit And Loss A/C")
            .AddWithValue("LedgerCode", LedgerCode)
            .AddWithValue("TaxRegno", "")
            .AddWithValue("AccountGroup", AccountGroupNames.ProfitLossAccounts)
            .AddWithValue("BankAccNo", "")
            .AddWithValue("address", "")
            .AddWithValue("location", "")
            .AddWithValue("state", "")
            .AddWithValue("country", "")
            .AddWithValue("Tel", "")
            .AddWithValue("fax", "")
            .AddWithValue("emailid", "")
            .AddWithValue("website", "")
            .AddWithValue("accounttype", AccountGroupNames.ProfitLossAccounts)
            .AddWithValue("createdby", "Admin")
            .AddWithValue("alterby", "")
            .AddWithValue("verifiedby", "")
            .AddWithValue("Isactive", 1)
            .AddWithValue("creditlimit", 10000)
            .AddWithValue("discount", 0)
            .AddWithValue("Contactperson", "")
            .AddWithValue("pdesignation", "")
            .AddWithValue("ptel", "")
            .AddWithValue("pphoneno", "")
            .AddWithValue("pemail", "")
            .AddWithValue("Dr", 0)
            .AddWithValue("Cr", 0)
            .AddWithValue("OpDr", 0)
            .AddWithValue("OpCr", 0)
            .AddWithValue("IsBillWise", 0)
            .AddWithValue("photopath", PhotoPathForLedgers & "\" & LedgerCode & ".jpg")
            .AddWithValue("currentbalance", 0)
            .AddWithValue("partyaddresscity", "")
            .AddWithValue("StoreName", "MainStore")
            .AddWithValue("CreditPeriod", 30)
            .AddWithValue("EnableChequePrinting", "False")
            .AddWithValue("pincode", "")
            .AddWithValue("Currency", UCase(TxtCurrency.Text))
            .AddWithValue("LedgerNameTemp", "ProfitAndLossA/C")
            .AddWithValue("IsAllowCostCentre", "False")
            .AddWithValue("n1", 0)
        End With
        DBF8.ExecuteNonQuery()
        DBF8 = Nothing
        'create default service tax ledger
        Dim DBF18 As New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBF18.Parameters
            LedgerCode = GetAndSetIDCode(EnumIDType.Accounts)
            .AddWithValue("LedgerName", "Service Tax @0")
            .AddWithValue("LedgerCode", LedgerCode)
            .AddWithValue("TaxRegno", "")
            .AddWithValue("AccountGroup", AccountGroupNames.DutiesTaxes)
            .AddWithValue("BankAccNo", "")
            .AddWithValue("address", "")
            .AddWithValue("location", "")
            .AddWithValue("state", "")
            .AddWithValue("country", "")
            .AddWithValue("Tel", "")
            .AddWithValue("fax", "")
            .AddWithValue("emailid", "")
            .AddWithValue("website", "")
            .AddWithValue("accounttype", AccountGroupNames.DutiesTaxes)
            .AddWithValue("createdby", "Admin")
            .AddWithValue("alterby", "")
            .AddWithValue("verifiedby", "")
            .AddWithValue("Isactive", 1)
            .AddWithValue("creditlimit", 10000)
            .AddWithValue("discount", 0)
            .AddWithValue("Contactperson", "")
            .AddWithValue("pdesignation", "")
            .AddWithValue("ptel", "")
            .AddWithValue("pphoneno", "")
            .AddWithValue("pemail", "")
            .AddWithValue("Dr", 0)
            .AddWithValue("Cr", 0)
            .AddWithValue("OpDr", 0)
            .AddWithValue("OpCr", 0)
            .AddWithValue("IsBillWise", 0)
            .AddWithValue("photopath", PhotoPathForLedgers & "\" & LedgerCode & ".jpg")
            .AddWithValue("currentbalance", 0)
            .AddWithValue("partyaddresscity", "")
            .AddWithValue("StoreName", "MainStore")
            .AddWithValue("CreditPeriod", 30)
            .AddWithValue("EnableChequePrinting", "False")
            .AddWithValue("pincode", "")
            .AddWithValue("Currency", UCase(TxtCurrency.Text))
            .AddWithValue("LedgerNameTemp", "ServiceTax@0")
            .AddWithValue("IsAllowCostCentre", "False")
            .AddWithValue("n1", 0)
        End With
        DBF18.ExecuteNonQuery()
        DBF18 = Nothing

        SqlStr = "INSERT INTO [Vatclauses] ([VatName],[vattax],[inputvatledger],[outputvatledger],[PurchaseLedger],[DebitNoteLedger],[SalesLedger],[CreditLedger],[isactive],[vattype])     VALUES " _
            & " (@VatName,@vattax,@inputvatledger,@outputvatledger,@PurchaseLedger,@DebitNoteLedger,@SalesLedger,@CreditLedger,@isactive,@vattype) "


        Dim DBF1 As New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBF1.Parameters
            .AddWithValue("VatName", "VAT @0%")
            .AddWithValue("vattax", 0)
            .AddWithValue("inputvatledger", "")
            .AddWithValue("outputvatledger", "")
            .AddWithValue("PurchaseLedger", "Purchase A/c")
            .AddWithValue("DebitNoteLedger", "Purchase A/c")
            .AddWithValue("SalesLedger", "Sales A/c")
            .AddWithValue("CreditLedger", "Sales A/c")
            .AddWithValue("isactive", "True")
            .AddWithValue("vattype", "VAT")
        End With
        DBF1.ExecuteNonQuery()
        DBF1 = Nothing


        SqlStr = "INSERT INTO [Vatclauses] ([VatName],[vattax],[inputvatledger],[outputvatledger],[PurchaseLedger],[DebitNoteLedger],[SalesLedger],[CreditLedger],[isactive],[vattype])     VALUES " _
           & " (@VatName,@vattax,@inputvatledger,@outputvatledger,@PurchaseLedger,@DebitNoteLedger,@SalesLedger,@CreditLedger,@isactive,@vattype) "


        Dim DBF12 As New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBF12.Parameters
            .AddWithValue("VatName", "Service Tax @0")
            .AddWithValue("vattax", 0)
            .AddWithValue("inputvatledger", "Service Tax @0")
            .AddWithValue("outputvatledger", "")
            .AddWithValue("PurchaseLedger", "Purchase A/c")
            .AddWithValue("DebitNoteLedger", "Purchase A/c")
            .AddWithValue("SalesLedger", "Sales A/c")
            .AddWithValue("CreditLedger", "Sales A/c")
            .AddWithValue("isactive", "True")
            .AddWithValue("vattype", "Service Tax")
        End With
        DBF12.ExecuteNonQuery()
        DBF12 = Nothing

        MAINCON.Close()
        'Assigned default ledger accounts for transactions

        ExecuteSQLQuery("Update DefLedgers set ledgername=N'Cash' where ledgertype='cash' ")
        ExecuteSQLQuery("Update DefLedgers set ledgername=N'Purchase A/c' where ledgertype='purch'")
        ExecuteSQLQuery("Update DefLedgers set ledgername=N'Purchase A/c' where ledgertype='purchret'")
        ExecuteSQLQuery("Update DefLedgers set ledgername=N'Sales A/c' where ledgertype='sales'")
        ExecuteSQLQuery("Update DefLedgers set ledgername=N'Sales A/c' where ledgertype='salesret'")
        ExecuteSQLQuery("Update DefLedgers set ledgername=N'Cd Cr' where ledgertype='cdcr'")
        ExecuteSQLQuery("Update DefLedgers set ledgername=N'Cd Dr' where ledgertype='cddr'")
        ExecuteSQLQuery("Update DefLedgers set ledgername=N'Round Off' where ledgertype='round'")
        ExecuteSQLQuery("Update DefLedgers set ledgername=N'Commission A/c' where ledgertype='comm'")
        ExecuteSQLQuery("Update DefLedgers set ledgername=N'Profit And Loss A/C' where ledgertype='profit'")
        '
        'Isprimary
        'Profit And Loss A/C
        ExecuteSQLQuery("Update ledgers set Isprimary=1 where ledgername=N'Cash'")
        ExecuteSQLQuery("Update ledgers set Isprimary=1 where ledgername=N'Profit And Loss A/C'")

        'to turn of deliverynote and goodsreceipt note

        ExecuteSQLQuery("update settings set IsAllowDeliveryNote='False'")
        ExecuteSQLQuery("update settings set IsAllowGReceiptNote='False'")



    End Sub

    Private Sub txtpassword1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpassword1.TextChanged, txtpassword2.TextChanged, TxtAdminEmailID.TextChanged
        On Error Resume Next
        If txtpassword1.Text = txtpassword2.Text Then
            TxtIspassword.Text = "Passwords are Match"
            TxtIspassword.ForeColor = Color.Green
        Else
            TxtIspassword.Text = "Passwords are not Match"
            TxtIspassword.ForeColor = Color.Red
        End If

    End Sub

    Private Sub Company_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtSharedFolder.Text = Application.StartupPath & "\Images"
        TxtCompanyID.Focus()
    End Sub

    Private Sub Company_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        txtAccDateStart.Value = Today
        txtaccdateend.Value = Today.Date.AddMonths(12)
        txtbookstartdate.Value = Today
        txtbookenddate.Value = Today.Date.AddMonths(12)
        Dim clist As Object = {"AFN", "ALL", "ANG", "ARS", "AUD", "AWG", "AZN", "BAM", "BBD", "BGN", "BMD", "BND", "BOB", "BRL", "BSD", "BWP", "BYR", "BZD", "CAD", "CHF", "CLP", "CNY", "COP", "CRC", "CUP", "CZK", "DKK", "DOP", "EEK", "EGP", "EUR", "FJD", "FKP", "GBP", "GGP", "GHC", "GIP", "GTQ", "GYD", "HKD", "HNL", "HRK", "HUF", "IDR", "ILS", "IMP", "INR", "IRR", "ISK", "JEP", "JMD", "JPY", "KGS", "KHR", "KPW", "KRW", "KYD", "KZT", "LAK", "LBP", "LKR", "LRD", "LTL", "LVL", "MKD", "MNT", "MUR", "MXN", "MYR", "MZN", "NAD", "NGN", "NIO", "NOK", "NPR", "NZD", "OMR", "PAB", "PEN", "PHP", "PKR", "PLN", "PYG", "QAR", "RON", "RSD", "RUB", "SAR", "SBD", "SCR", "SEK", "SGD", "SHP", "SOS", "SRD", "SVC", "SYP", "THB", "TRL", "TRY", "TTD", "TVD", "TWD", "UAH", "USD", "UYU", "UZS", "VEF", "VND", "XCD", "YER", "ZAR", "ZWD"}
        TxtCurrency.Items.AddRange(clist)
       
        If IsCreateNewFromMenuVar = True Then
            TempConStrin = ConnectionStrinG
        End If
        TxtCompanyType.Text = "ALL"
        TxtDateFormat.Text = "DD/MM/YYYY"
        IsFixedLength.Text = "NO"
        IsAutoFill.Text = "YES"
        IsLeadingZeros.Text = "NO"

    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        txtlogo.Image = My.Resources.NOPIC
        CompanyLogoPath = ""
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click
        Me.Close()
    End Sub


    Private Sub BtnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowse.Click
        Dim dfrm As New FolderBrowserDialog
        If dfrm.ShowDialog() = vbOK Then
            TxtSharedFolder.Text = dfrm.SelectedPath
        End If
    End Sub

    Private Sub TxtCompanyID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCompanyID.LostFocus
        If TxtCmpName.Text.Length = 0 Then
            TxtCmpName.Text = TxtCompanyID.Text
        End If
    End Sub


    Private Sub btndemo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndemo.Click
        If TxtCmpName.Text.Length < 2 Then
            MsgBox("Please Enter the Company Mailing Name ", MsgBoxStyle.Information, MySoftwareName)
            TxtCmpName.Focus()
            Exit Sub
        End If
        If TxtCompanyID.Text.Length < 2 Then
            MsgBox("Please Enter the Company Name ", MsgBoxStyle.Information, MySoftwareName)
            TxtCompanyID.Focus()
            Exit Sub
        End If
        If MainForm.IsCompanyNameisExists(TxtCompanyID.Text) = True Then
            MsgBox("The Entered Company Name is already exists.. Please try again...", MsgBoxStyle.Critical)
            TxtCompanyID.Focus()
            Exit Sub
        End If
        If System.IO.Directory.Exists(TxtSharedFolder.Text) = False Then
            MsgBox("The Entered Shared Folder is not found.....")
            TxtSharedFolder.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to Create ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        If CreateNewCompany(True) = False Then
            If IsCreateNewFromMenuVar = True Then
                ConnectionStrinG = TempConStrin
                Me.Cursor = Cursors.Default
            End If
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        Dim ConStr As String = ""
        Dim SQLstr As String = ""
        Dim Backuppath As String = ""
        Dim Photopath As String = ""
        Dim Barcodepath As String = ""
        Try
            System.IO.Directory.CreateDirectory(TxtSharedFolder.Text & "\" & NewCompanyDBName)
            System.IO.Directory.CreateDirectory(TxtSharedFolder.Text & "\" & NewCompanyDBName & "\Images")
            System.IO.Directory.CreateDirectory(TxtSharedFolder.Text & "\" & NewCompanyDBName & "\Images\StockPhotos")
            System.IO.Directory.CreateDirectory(TxtSharedFolder.Text & "\" & NewCompanyDBName & "\Images\Others")
            System.IO.Directory.CreateDirectory(TxtSharedFolder.Text & "\" & NewCompanyDBName & "\Images\CompanyImages")
            System.IO.Directory.CreateDirectory(TxtSharedFolder.Text & "\" & NewCompanyDBName & "\Backup")
            System.IO.Directory.CreateDirectory(TxtSharedFolder.Text & "\" & NewCompanyDBName & "\BarCodeImages")
        Catch ex As Exception

        End Try



        ConStr = ConnectionStringFromFile & " Initial Catalog=" & NewCompanyDBName & ";"
        '"Server=" & TxtSoftwareSQlServer & ";Integrated Security=True;Initial Catalog=" & NewCompanyDBName & "; User ID=" & txtSoftwareSQlUserID & ";"

        Backuppath = TxtSharedFolder.Text & "\" & NewCompanyDBName & "\Backup"
        Photopath = TxtSharedFolder.Text & "\" & NewCompanyDBName & "\Images"
        Barcodepath = TxtSharedFolder.Text & "\" & NewCompanyDBName & "\BarCodeImages"

        If CompanyLogoPath.Length > 0 Then

            Try
                My.Computer.FileSystem.DeleteFile(Photopath & "\CompanyImages\CompanyLogo.jpg")
            Catch ex As Exception

            End Try
            Try

                txtlogo.Image.Save(Photopath & "\CompanyImages\CompanyLogo.jpg")
                CompanyLogoPath = Photopath & "\CompanyImages\CompanyLogo.jpg"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Try
                My.Computer.FileSystem.DeleteFile(Photopath & "\CompanyImages\CompanyLogo.jpg")
            Catch ex As Exception

            End Try
        End If
        'IMPORT DEMO DATA HERE


        Dim TBLSTR As String = "SELECT * FROM INFORMATION_SCHEMA.tables"
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConStr)
        cnn.Open()
        Dim da As SqlDataAdapter = New SqlDataAdapter(TBLSTR, cnn)
        Dim ds As New DataSet()
        da.Fill(ds)

        For Each row As DataRow In ds.Tables(0).Rows

            Try
                Dim ids As New DataSet

                Dim dscmd As New SqlDataAdapter("select * from " & row.Item("TABLE_NAME"), cnn)
                dscmd.Fill(ids, row.Item("TABLE_NAME"))
                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(dscmd)
                ids.ReadXml(Application.StartupPath & "\DEMODATA\" & row.Item("TABLE_NAME") & ".xml")
                dscmd.Update(ids, row.Item("TABLE_NAME"))
            Catch ex As Exception

            End Try

        Next row



        MAINCON.ConnectionString = ConStr
        MAINCON.Open()

        SQLstr = "UPDATE  company  SET CompanyID=@CompanyID,companyname=@companyname, logoimage=@logoimage,Backupath=@Backupath,Photopath=@Photopath,BarcodePath=@BarcodePath  "
        Dim k As New DateTimePicker
        Dim sdate As New DateTime(2013, 1, 1)
        Dim edate As New DateTime(2013, 12, 31)
        Dim DBF As New SqlClient.SqlCommand(SQLstr, MAINCON)
        With DBF.Parameters
            .AddWithValue("CompanyID", TxtCompanyID.Text)
            .AddWithValue("companyname", TxtCmpName.Text)
            .AddWithValue("logoimage", CompanyLogoPath)
            .AddWithValue("Backupath", Backuppath)
            .AddWithValue("Photopath", Photopath)
            .AddWithValue("BarcodePath", Barcodepath)

        End With

        DBF.ExecuteNonQuery()
        MAINCON.Close()




        If IsCreateNewFromMenuVar = True Then
            ConnectionStrinG = TempConStrin
        End If
        Me.Cursor = Cursors.Default
        MsgBox("Create Successfully ..........." & Chr(13) & "User Name: Admin and Password: 123456 ")
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub BtnAttachDb_Click(sender As System.Object, e As System.EventArgs) Handles BtnAttachDb.Click
        Dim dg As New OpenFileDialog
        If dg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If dg.FileName.Length > 0 Then
                Dim conn As New SqlConnection(ConnectionStringFromFile)
                Dim cmd As New SqlCommand("", conn)
                cmd.CommandText = "CREATE DATABASE MESWERPDBDD210 ON " & _
                    "PRIMARY ( FILENAME =  '" & dg.FileName & "' ) " & _
                    "FOR ATTACH"

                conn.Open()
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                conn.Dispose()
            End If
        End If
    End Sub
    Private Sub TxtDateFormat_LostFocus(sender As Object, e As System.EventArgs) Handles TxtDateFormat.LostFocus
        txtAccDateStart.Format = DateTimePickerFormat.Custom
        txtaccdateend.Format = DateTimePickerFormat.Custom
        txtbookstartdate.Format = DateTimePickerFormat.Custom
        txtbookenddate.Format = DateTimePickerFormat.Custom
        txtAccDateStart.CustomFormat = TxtDateFormat.Text
        txtaccdateend.CustomFormat = TxtDateFormat.Text
        txtbookstartdate.CustomFormat = TxtDateFormat.Text
        txtbookenddate.CustomFormat = TxtDateFormat.Text
    End Sub

    Private Sub TxtDateFormat_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtDateFormat.SelectedIndexChanged
        txtAccDateStart.Format = DateTimePickerFormat.Custom
        txtaccdateend.Format = DateTimePickerFormat.Custom
        txtbookstartdate.Format = DateTimePickerFormat.Custom
        txtbookenddate.Format = DateTimePickerFormat.Custom
        txtAccDateStart.CustomFormat = TxtDateFormat.Text
        txtaccdateend.CustomFormat = TxtDateFormat.Text
        txtbookstartdate.CustomFormat = TxtDateFormat.Text
        txtbookenddate.CustomFormat = TxtDateFormat.Text
    End Sub

    Private Sub Panel2_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class