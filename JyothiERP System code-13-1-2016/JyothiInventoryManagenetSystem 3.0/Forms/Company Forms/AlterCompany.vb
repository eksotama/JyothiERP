Imports System.IO

Public Class AlterCompany
    Dim CompanyLogoPath As String = ""
    Dim UserSecurityQ1 As String = ""
    Dim UserSecurityQ2 As String = ""
    Dim UserSecurityA1 As String = ""
    Dim UserSecurityA2 As String = ""
    Dim Sdate As New DateTimePicker
    Dim edate As New DateTimePicker
    Dim IsSizeWise As Boolean = False
    Dim imageData1 As Byte()
    Dim IsImagechanged As Boolean = False
    Private Sub AlterCompany_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub AlterCompany_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CompanyLogoPath = ""
        TxtCompanyID.Text = CompDetails.CompanyID
        TxtCmpName.Text = CompDetails.CompanyName
        TxtLicenseno.Text = CompDetails.CompanyLicenceno
        txtRegNo.Text = CompDetails.Companytaxregno
        txtpoboxno.Text = CompDetails.Companystate
        txtstreet.Text = CompDetails.Companystreet
        TxtState.Text = CompDetails.Companystate
        TxtCountry.Text = CompDetails.Companycountry
        txttelephone.Text = CompDetails.Companytel
        txtfaxno.Text = CompDetails.CompanyFax
        txtemailid.Text = CompDetails.Companyemail
        txtwebsite.Text = CompDetails.Companywebsite
        TxtCompanyType.Text = CompDetails.CompanyType
        txtadminname.Text = CompDetails.Companyusername
        TxtAdminEmailID.Text = CompDetails.CompanyAdminEmailId
        txtnoofdecimals.Text = CompDetails.NoofDecimals
        TxtCSTNo.Text = CompDetails.CSTNo
        TxtDateFormat.Text = CompDetails.DateFormattext

        TxtCurrencyName.Text = TrailEndForAmountInWordsInteger
        TxtDecimalSymbol.Text = TrailEndForamountinWordsDecimals

        Try
            PictureBox1.WaitOnLoad = True
            PictureBox1.Image = GetImageFromDatabase("IMAGEDATA", "SELECT TOP 1  IMAGEDATA FROM IMAGES WHERE BCODE=N'@CMP0000L0GO'")
        Catch ex As Exception

        End Try
        PictureBox1.Image = My.Resources.NOPIC
        Try
            Dim dt As New DataTable
            dt = SQLLoadGridData("SELECT TOP 1  IMAGEDATA FROM IMAGES WHERE BCODE=N'@CMP0000L0GO'")
            imageData1 = DirectCast(dt.Rows(0).Item("IMAGEDATA"), Byte())
            If Not imageData1 Is Nothing Then
                Using ms As New MemoryStream(imageData1, 0, imageData1.Length)
                    ms.Write(imageData1, 0, imageData1.Length)
                    PictureBox1.Image = Image.FromStream(ms, True)
                End Using
            End If
        Catch ex As Exception
        End Try
        Try

            If SQLGetStringFieldValue("select IsSizeBasedItem from company", "IsSizeBasedItem") = "True" Then
                IsSizeWise = True
            Else
                IsSizeWise = False
            End If
        Catch ex As Exception

        End Try
        CompanyLogoPath = CompDetails.CompanyLogopath
        txtAccDateStart.Value = CompDetails.AccDateFrom
        txtaccdateend.Value = CompDetails.AccDateTo
        txtbookstartdate.Value = CompDetails.BookDateFrom
        txtbookenddate.Value = CompDetails.BookDateTo
        TxtCurrency.Text = CompDetails.Currency
        txtpassword1.Text = DecrypPassword(CompDetails.Companypasword)
        txtpassword2.Text = txtpassword1.Text
        TxtCurrency.Enabled = False
        TxtSharedFolder.Text = SQLGetStringFieldValue("select SharedFolderName from settings", "SharedFolderName")

        UserSecurityQ1 = SQLGetStringFieldValue("select UserSecurityQ1 from company", "UserSecurityQ1")
        UserSecurityQ1 = SQLGetStringFieldValue("select UserSecurityQ1 from company", "UserSecurityQ1")
        UserSecurityA1 = SQLGetStringFieldValue("select UserSecurityA1 from company", "UserSecurityA1")
        UserSecurityA2 = SQLGetStringFieldValue("select UserSecurityA2 from company", "UserSecurityA2")
        Sdate.Value = SQLGetStringFieldValue("select YearStartDate from company", "YearStartDate")
        edate.Value = SQLGetStringFieldValue("select YearEndDate from company", "YearEndDate")
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Dim sd As OpenFileDialog = New OpenFileDialog
        sd.Title = "Select Image "
        sd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
        ' sd.Filter = "Bitmap |*.bmp| JPG | *.jpg | GIF | *.gif | All Files|*.*"
        sd.FilterIndex = 1
        sd.Multiselect = False
        If sd.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim temp As Image = PictureBox1.Image
            PictureBox1.Image = Nothing
            temp.Dispose()
            IsImagechanged = True
            Dim fs As System.IO.FileStream
            fs = New System.IO.FileStream(sd.FileName, IO.FileMode.Open, IO.FileAccess.Read)

            PictureBox1.WaitOnLoad = True
            PictureBox1.LoadAsync(sd.FileName)



        End If
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        PictureBox1.Image = My.Resources.NOPIC
        CompanyLogoPath = ""
        IsImagechanged = True
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click
        Me.Close()
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click

        If TxtCompanyID.Text.Length < 2 Then
            MsgBox("Please Enter the Company Name ", MsgBoxStyle.Information, MySoftwareName)
            TxtCompanyID.Focus()
            Exit Sub
        End If

        If TxtCmpName.Text.Length < 2 Then
            MsgBox("Please Enter the Company Mailing Name ", MsgBoxStyle.Information, MySoftwareName)
            TxtCmpName.Focus()
            Exit Sub
        End If

        If MainForm.IsCompanyNameisExists(TxtCompanyID.Text, CompDetails.CompanyID) Then
            MsgBox("The Entered Company Name is already Exists, Please Try again...... ", MsgBoxStyle.Critical)
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
        If txtnoofdecimals.Text.Length = 0 Then
            MsgBox("Please select the Decimal places.. ", MsgBoxStyle.Information)
            txtnoofdecimals.Focus()
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
        If MsgBox("Do you want to Alter ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        savevalues()
    End Sub
    Sub savevalues()
        Dim SQLSTR As String = ""
        '   ExecuteSQLQuery("DELETE FROM COMPANY")
        MainForm.TxtMainLogo.BackgroundImage = My.Resources.NOPIC
        If CompanyLogoPath.Length > 0 Then

            Try
                My.Computer.FileSystem.DeleteFile(PhotoPathForLedgers & "\CompanyImages\CompanyLogo.jpg")
            Catch ex As Exception

            End Try
            Try
                PictureBox1.Image.Save(PhotoPathForLedgers & "\CompanyImages\CompanyLogo.jpg")
                CompanyLogoPath = PhotoPathForLedgers & "\CompanyImages\CompanyLogo.jpg"
                CompDetails.CompanyLogopath = CompanyLogoPath
                Try
                    MainForm.TxtMainLogo.BackgroundImage = GetImageFromDatabase("IMAGEDATA", "SELECT TOP 1  IMAGEDATA FROM IMAGES WHERE BCODE=N'@CMP0000L0GO'")
                Catch ex As Exception
                    ' MsgBox(ex.Message)
                End Try
            Catch ex As Exception
                '  MsgBox(ex.Message)
            End Try
        Else
            Try
                My.Computer.FileSystem.DeleteFile(PhotoPathForLedgers & "\CompanyImages\CompanyLogo.jpg")
            Catch ex As Exception

            End Try
        End If
        Dim CURCHANGED As Boolean = False
        SQLSTR = "UPDATE [company] SET [companyname]=@companyname,[licenseno]=@licenseno,[taxregno]=@taxregno,[address]=@address,[location]=@location,[state]=@state,[country]=@country,[Tel]=@Tel,[fax]=@fax,[emailid]=@emailid,[website]=@website,[accounttype]=@accounttype,[adminname]=@adminname," _
           & "[adminpassword]=@adminpassword,[adminemailid]=@adminemailid,[Isactive]=@Isactive,[logoimage]=@logoimage,[accyearstart]=@accyearstart,[accyearend]=@accyearend,[booksyearstart]=@booksyearstart,[booksyearend]=@booksyearend,[Backupath]=@Backupath,[photopath]=@photopath," _
           & "[BarcodePath]=@BarcodePath,[Currency]=@Currency,[UserSecurityQ1]=@UserSecurityQ1,[UserSecurityQ2]=@UserSecurityQ2,[UserSecurityA1]=@UserSecurityA1,[UserSecurityA2]=@UserSecurityA2,[IsSizeBasedItem]=@IsSizeBasedItem,[YearStartDate]=@YearStartDate,[YearEndDate]=@YearEndDate,[PeriodFrom]=@PeriodFrom," _
           & " [PeriodTo]=@PeriodTo,[Versionno]=@Versionno,[Companyid]=@Companyid ,[noofdecimals]=@noofdecimals,CstNo=@CstNo,dateformattext=@dateformattext ,CurrencyName=@CurrencyName,DecimalSymbol=@DecimalSymbol "

        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(SQLSTR, MAINCON)
        With DBF.Parameters
            .AddWithValue("Companyid", TxtCompanyID.Text)
            .AddWithValue("companyname", TxtCmpName.Text)
            .AddWithValue("licenseno", TxtLicenseno.Text)
            .AddWithValue("noofdecimals", CInt(txtnoofdecimals.Text))
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
            .AddWithValue("accyearend", txtaccdateend.Value.Date)
            .AddWithValue("booksyearstart", txtbookstartdate.Value.Date)
            .AddWithValue("booksyearend", txtbookenddate.Value.Date)
            .AddWithValue("PeriodFrom", txtaccdateend.Value.Date)
            .AddWithValue("PeriodTo", txtaccdateend.Value.Date.AddMonths(1))
            .AddWithValue("Backupath", PhotoBackupPath)
            .AddWithValue("Photopath", PhotoPathForLedgers)
            .AddWithValue("BarcodePath", PhotoPathForBarcode)
            .AddWithValue("Currency", TxtCurrency.Text)
            .AddWithValue("UserSecurityQ1", UserSecurityQ1)
            .AddWithValue("UserSecurityQ2", UserSecurityQ2)
            .AddWithValue("UserSecurityA1", UserSecurityA1)
            .AddWithValue("UserSecurityA2", UserSecurityA2)
            If IsSizeWise = True Then
                .AddWithValue("IsSizeBasedItem", "True")
            Else
                .AddWithValue("IsSizeBasedItem", "False")
            End If
            .AddWithValue("YearStartDate", Sdate.Value.Date)
            .AddWithValue("YearEndDate", edate.Value.Date)

            If CompDetails.CompanyVersionNumber = Nothing Then
                .AddWithValue("Versionno", 0)
            Else
                .AddWithValue("Versionno", PresentVersionNumber)
            End If
            .AddWithValue("CstNo", TxtCSTNo.Text)
            .AddWithValue("dateformattext", TxtDateFormat.Text)
            .AddWithValue("DecimalSymbol", TxtDecimalSymbol.Text)
            .AddWithValue("CurrencyName", TxtCurrencyName.Text)
        End With
        DBF.ExecuteNonQuery()
        MAINCON.Close()
        If IsNothing(PictureBox1.Image) = True Then
            PictureBox1.Image = My.Resources.NOPIC
        End If
       
        If TxtCurrencyName.Text.ToUpper <> TrailEndForAmountInWordsInteger Or TxtDecimalSymbol.Text.ToUpper <> TrailEndForamountinWordsDecimals Then
            Me.Cursor = Cursors.WaitCursor
            ExecuteSQLQuery("update StockInvoiceDetails set amountinwords=dbo.[fnNumberToWord](nettotal)")
            Me.Cursor = Cursors.Default
        End If
        Dim ms1 As New MemoryStream()
        Dim objData As Byte()
        Try
            If IsImagechanged = True Then
                PictureBox1.Image.Save(ms1, PictureBox1.Image.RawFormat)
                objData = ms1.GetBuffer()
            Else
                objData = imageData1
            End If
          
        Catch ex As Exception
            objData = imageData1
        End Try
        Dim strsqlimg As String = ""
        If SQLIsFieldExists("SELECT TOP 1 1 from  IMAGES WHERE BCODE=N'@CMP0000L0GO'") = False Then
            'INSERT INTO IMAGES (IMAGEDATA,BCODE) VALUES(@IMAGEDATA,@BCODE)
            strsqlimg = "INSERT INTO IMAGES (IMAGEDATA,BCODE) VALUES (@IMAGEDATA,@BCODE)"
            '  InsertImageIntoDatabase(PictureBox1.Image, "IMAGEDATA", "BCODE", , "@CMP0000L0GO", "")
        Else
            'UpdateImageIntoDatabase(PictureBox1.Image, "IMAGEDATA", , "")
            strsqlimg = "UPDATE IMAGES SET IMAGEDATA=@IMAGEDATA ,BCODE=@BCODE WHERE BCODE=N'@CMP0000L0GO'"
        End If
        Dim MAINCON2 As New SqlClient.SqlConnection
        MAINCON2.ConnectionString = ConnectionStrinG
        MAINCON2.Open()
        Dim DBF3 As New SqlClient.SqlCommand(strsqlimg, MAINCON2)
        With DBF3.Parameters
            .AddWithValue("IMAGEDATA", objData)
            .AddWithValue("BCODE", "@CMP0000L0GO")
        End With
        DBF3.ExecuteNonQuery()
        DBF3 = Nothing
        MAINCON2.Close()

        LoadCompanyData()
        MainForm.TxtCompanyName.Text = CompDetails.CompanyID
        MainForm.TxtCompanyAddress.Text = CompDetails.Companystreet
        MainForm.TxtCompanyAccPeriod.Text = FormatDateTime(CompDetails.AccDateFrom.Date, DateFormat.ShortDate) & " - " & FormatDateTime(CompDetails.AccDateTo.Date.ToString, DateFormat.ShortDate)
        Try
            MainForm.TxtMainLogo.BackgroundImage = GetImageFromDatabase("IMAGEDATA", "SELECT TOP 1  IMAGEDATA FROM IMAGES WHERE BCODE=N'@CMP0000L0GO'")
        Catch ex As Exception

        End Try

        Me.Close()
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
End Class