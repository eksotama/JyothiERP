Imports System.IO
Imports System.Data.SqlClient

Module CreateDatabaseDM



    Public Function CreateNewCompany(Optional ByVal IsEmptyDatabase As Boolean = False, Optional ByVal IsHostingSqlServer As Boolean = False) As Boolean
        Dim iscreateD As Boolean = False
        Dim ext As Integer = 0
        Dim extnewcmp As String = ""



        Try
            If IsHostingSqlServer = False Then
                extnewcmp = NewCompanyDBName
                Dim I As Integer
                For I = 100 To 4000
                    NewCompanyDBName = extnewcmp & I.ToString
                    If TestSQLDatabaseIsEXIST(NewCompanyDBName) = False Then
                        ext = I
                        Exit For
                    End If
                Next
                If I >= 4000 Then
                    MsgBox("The Maximum No of Companies reaches ,Please consult Developer ")
                    End
                End If
            End If


            MainSqlConn.ConnectionString = ConnectionStringFromFile
            MainSqlConn.Open()
            Try
                If IsHostingSqlServer = False Then
                    Dim SqlInsert As String = ""
letdoagain:
                    Try

                        SQLFcmd.Connection = MainSqlConn
                        SQLFcmd.CommandText = "CREATE DATABASE " & NewCompanyDBName
                        SQLFcmd.CommandType = CommandType.Text
                        SQLFcmd.ExecuteNonQuery()


                        'SQLFcmd.CommandText = "ALTER DATABASE " & NewCompanyDBName & " SET COMPATIBILITY_LEVEL = 100"
                        'SQLFcmd.CommandType = CommandType.Text
                        'SQLFcmd.ExecuteNonQuery()



                    Catch ex As Exception

                        NewCompanyDBName = extnewcmp & (ext + 1).ToString
                        ext = ext + 1
                        GoTo letdoagain
                    End Try
                End If
                'CREATE A DATABASE AS NAME new company database


                SQLFcmd.CommandText = "USE  " & NewCompanyDBName
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                'CREATE A TABLE IN JVSKCOMPANY DATABASE
                SQLFcmd.CommandText = "CREATE TABLE [AccountGroups](	[GroupName] [nvarchar](75) NULL,	[GroupNameTemp] [nvarchar](75) NULL,	[GroupRoot] [nvarchar](75) NULL,	[GroupLevel] [int] NULL,	[UserName] [nvarchar](70) NULL,	[Isprimary] [smallint] NULL,	[AcType] [smallint] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                
                SQLFcmd.CommandText = "CREATE TABLE [roundingsettings] ([AllowinPOS] [bit] NULL, [AllowinSalesInvoice] [bit] NULL,[AllowinPurchase] [bit] NULL,[AllowinPurchaseRet] [bit] NULL,[AllowinSalesRet] [bit] NULL,[AllowinDNote] [bit] NULL,[AllowinGnote] [bit] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "INSERT INTO [roundingsettings]([AllowinPOS],[AllowinSalesInvoice],[AllowinPurchase],[AllowinPurchaseRet],[AllowinSalesRet],[AllowinDNote],[AllowinGnote])     VALUES(0,0,0,0,0,0,0)"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [images] (	[ImageData] [image] NULL,	[Bcode] [nvarchar](80) NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [Currencies]([CurrencyName] [nvarchar](250) NULL,[CurrencyCode] [nvarchar](8) NULL,[CurrencySymbol] [nvarchar](8) NULL,[IsActive] [int] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [stockserialnos]([StockCode] [nvarchar](75) NULL,[StockSize] [nvarchar](25) NULL,[SerialNumber] [nvarchar](50) NULL,[MFD] [datetime] NULL,[Narration] [nvarchar](150) NULL,[Status] [nvarchar](10) NULL,[transcode] [bigint] NULL,[vouchername] [nvarchar](5) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [serialnumbermaster]([STOCKCODE] [nvarchar](75) NULL,[STOCKSIZE] [nvarchar](75) NULL,[SERIALNUMBER] [nvarchar](50) NULL,[Note1] [nvarchar](150) NULL,[Note2] [nvarchar](150) NULL,[Status] [int] NULL,[MFD] [datetime] NULL,[purchasedate] [datetime] NULL,[expirydate] [datetime] NULL,[warrantydate] [datetime] NULL,[Guaranteedate] [datetime] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                '
                SQLFcmd.CommandText = "CREATE TABLE [chequePrintFieldLabels]([SchemeName] [nvarchar](50) NULL,[Fieldname] [nvarchar](50) NULL,[labletext] [nvarchar](50) NULL,[DBField] [nvarchar](50) NULL,[IsVisible] [bit] NULL,[ftop] [int] NULL,[fleft] [int] NULL,[width] [int] NULL,[height] [int] NULL,[Fontname] [nvarchar](50) NULL,[fontsize] [smallint] NULL,[fontstyle] [smallint] NULL,[fontcolor] [nvarchar](50) NULL,[Align] [nvarchar](50) NULL,[lTop] [int] NULL,[lleft] [int] NULL,[lwidth] [int] NULL,[lheight] [int] NULL,[lFontname] [nvarchar](50) NULL,[lfontsize] [smallint] NULL,[lfontstyle] [smallint] NULL,[lfontcolor] [nvarchar](50) NULL,[lalign] [nvarchar](150) NULL,[sample] [nvarchar](150) NULL,[DBType] [smallint] NULL,[FieldType] [smallint] NULL,[PrintText] [nvarchar](150) NULL,[FormatType] [int] NULL,[DatabaseValue] [int] NULL,[IsLedgerValue] [int] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [SMSSettings] ([username] [nvarchar](700) NULL,[password] [nvarchar](100) NULL,[PortName] [nvarchar](50) NULL,[BaudRate] [int] NULL,[SMSType] [nvarchar](50) NULL,[serviceno] [nvarchar](50) NULL,[IsDefault] [bit] NULL,[portno] [nvarchar](10) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [barcodesettings]([barcodelength] [int] NULL,[Isreplacezeros] [bit] NULL,[Isautofill] [bit] NULL,[FixedLength] [bit] NULL,[BarcodeType] [nvarchar](50) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [notes]( [noteno] [bigint] NULL,[notes] [nvarchar](max) NULL,[notedate] [datetime] NULL,[UserID] [nvarchar](50) NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [printbarcode] (itemname [nvarchar](120) null, barcode [nvarchar](50), rate float null,copies int null,f1  [nvarchar](75) null ,n1 float null )  ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [chequePrintingSchemes]([SchemeName] [nvarchar](50) NULL,[VoucherName] [nvarchar](50) NULL,[IsActive] [float] NULL,[ID] [int] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [chequePrintingSettings] ([PrinterName] [nvarchar](150) NULL,[schemename] [nvarchar](50) NULL,[Width] [int] NULL,[Height] [int] NULL,[IsLandScape] [bit] NULL,[fleft] [int] NULL,[fright] [int] NULL,[ftop] [int] NULL,[fbuttom] [int] NULL,[multi] [bit] NULL,[showsubtotals] [bit] NULL,[IsActive] [bit] NULL,[PaperName] [nvarchar](50) NULL,[LeftLogoIsOn] [bit] NULL,[RightLogoIson] [bit] NULL,[Leftlogoleft] [int] NULL,[Leftlogotop] [int] NULL,[Leftlogowidth] [int] NULL,[Leftlogoheight] [int] NULL,[Rightlogoleft] [int] NULL,[Rightlogotop] [int] NULL,[Rightlogowidth] [int] NULL,[Rightlogoheight] [int] NULL,[leftlogopath] [nvarchar](255) NULL,[rightlogopath] [nvarchar](255) NULL,[MaxRowsPerPage] [int] NULL,[RowHeight] [int] NULL,[showpageno] [bit] NULL,[pagenotop] [int] NULL,[pagenoleft] [int] NULL,[pageformat] [smallint] NULL,[Watermark] [nvarchar](250) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [chequePrintLables]([schemename] [nvarchar](50) NULL,[ftop] [int] NULL,[fleft] [int] NULL,[width] [int] NULL,[height] [int] NULL,[Fontname] [nvarchar](50) NULL,[fontsize] [smallint] NULL,[fontstyle] [smallint] NULL,[fontcolor] [nvarchar](50) NULL,[fieldname] [nvarchar](75) NULL,[labletext] [nvarchar](75) NULL,[isvisible] [bit] NULL,[align] [nvarchar](50) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [chequePrintLines]( [schemename] [nvarchar](50) NULL,[ftop] [real] NULL,[fleft] [real] NULL,[width] [real] NULL,[height] [real] NULL,[fieldname] [nvarchar](75) NULL,[FieldType] [smallint] NULL,[LineColor] [nvarchar](50) NULL,[BoarderStyle] [nvarchar](50) NULL,[BoarderWidth] [real] NULL,[IsVisible] [bit] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [empsalaryincrements]([EmpName] [nvarchar](75) NULL,[oldSalary] [float] NULL,[NewSalary] [float] NULL,[Increment] [float] NULL,[Datefrom] [datetime] NULL,[datefromvalue] [bigint] NULL,[transcode] [bigint] NULL,[sno] [bigint] NULL,[Vhno] [nvarchar](50) NULL,[Transdate] [datetime] NULL,[Transdatevalue] [bigint] NULL,[EMPID] [nvarchar](50) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [CompanyLeaves]([LeaveName] [nvarchar](50) NULL,[FromDate] [datetime] NULL,[ToDate] [datetime] NULL,[FromDateValue] [bigint] NULL,[ToDateValue] [bigint] NULL,[Narration] [nvarchar](150) NULL,[F1] [nvarchar](50) NULL,[N1] [float] NULL,[Sno] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [PayTypes]([PayType] [nvarchar](20) NULL,[PayName] [nvarchar](75) NULL,[per] [float] NULL,[method] [nvarchar](15) NULL,[orderno] [int] NULL,[LedgerName] [nvarchar](75) NULL,[PaymentLedger] [nvarchar](75) NULL,[PayTypeGroup] [nvarchar](50) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [payrollvoucherLedgers]([PAYNAME] [nvarchar](75) NULL,[ledgername] [nvarchar](75) NULL,[Transcode] [bigint] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [payrollVoucherMasterData]([transcode] [bigint] NULL,[Transdate] [datetime] NULL,[Transdatevalue] [bigint] NULL,[VoucherNo] [nvarchar](50) NULL,[VoucherRef] [nvarchar](50) NULL,[PayDate] [datetime] NULL,[PayDateValue] [bigint] NULL,[NetTotal] [float] NULL,[CashTotal] [float] NULL,[BankTotal] [float] NULL,[paymethod] [nvarchar](75) NULL,[narration] [nvarchar](250) NULL,[sqlstr] [nvarchar](550) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " CREATE TABLE [PayRollVoucherPayMaster]([transcode] [bigint] NULL,[LedgerName] [nvarchar](75) NULL,[Amount] [float] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [Appointmentdb] ([ID] [bigint] IDENTITY(1,1) NOT NULL,[EmpName] [nvarchar](75) NULL,[AppID] [bigint] NULL,[DateStart] [datetime] NULL,[DateEnd] [datetime] NULL,[TextVal] [nvarchar](250) NULL,[Note] [nvarchar](250) NULL,[LedgerName] [nvarchar](75) NULL,[ColorR] [tinyint] NULL,[ColorG] [tinyint] NULL,[ColorB] [tinyint] NULL,[Imagepath] [nvarchar](250) NULL,[PatterStyle] [smallint] NULL,[PatterColorR] [tinyint] NULL,[PatterColorG] [tinyint] NULL,[PatterColorB] [tinyint] NULL,[IsConfirm] [bit] NULL,[IsOrderConfirm] [bit] NULL,[dateValue] [bigint] NULL,[IsLocked] [bit] NULL, CONSTRAINT [PK_Appointmentdb] PRIMARY KEY CLUSTERED ([ID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE[AppointmentRows]([ID] [bigint] IDENTITY(1,1) NOT NULL,[Barcode] [nvarchar](40) NULL,[AppID] [bigint] NULL,[ServiceName] [nvarchar](75) NULL,[Size] [nvarchar](50) NULL,[Rate] [float] NULL,[Mins] [int] NULL, CONSTRAINT [PK_AppointmentRows] PRIMARY KEY CLUSTERED ([ID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " CREATE TABLE [chequeinfo]([transcode] [bigint] NULL,[Ledgername] [nvarchar](75) NULL,[chequeno] [nvarchar](50) NULL,[chequedate] [datetime] NULL,[issuedate] [datetime] NULL,[details] [nvarchar](75) NULL,[vouchername] [nvarchar](50) NULL,[voucherno] [nvarchar](50) NULL,[amount] [float] NULL,[Isprinted] [bit] NULL,[chequedatevalue] [bigint] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [payrollvoucherRowDetails]([transcode] [bigint] NULL,[EmpName] [nvarchar](75) NULL,[PayName] [nvarchar](75) NULL,[OrderNo] [int] NULL,[amount] [float] NULL,[EmpID] [nvarchar](75) NULL,[Type] [int] NULL,[AttendenceDetails] [nvarchar](150) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [InvoiceDisplaySettings]([ShowTax] [bit] NULL,[ShowNetRate] [bit] NULL,[ShowItemName] [bit] NULL,[ShowItemCode] [bit] NULL,[ShowItemMoreInfo] [bit] NULL,[ShowDiscount] [bit] NULL,[ShowAccount] [bit] NULL,[ShowRatePer] [bit] NULL,[ShowNarration] [bit] NULL,[ShowCurrentBalance] [bit] NULL,[isallowdisc2] [bit] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " CREATE TABLE [PrintAccounts]([SchemeName] [nvarchar](50) NULL,[Fieldname] [nvarchar](50) NULL,[labletext] [nvarchar](50) NULL,[ObjectType] [nvarchar](50) NULL,[IsVisible] [bit] NULL,[ftop] [int] NULL,[fleft] [int] NULL,[width] [int] NULL,[height] [int] NULL,[Fontname] [nvarchar](50) NULL,[fontsize] [smallint] NULL,[fontstyle] [smallint] NULL,[fontcolor] [nvarchar](50) NULL,[Align] [nvarchar](50) NULL,[lTop] [int] NULL,[lleft] [int] NULL,[lwidth] [int] NULL,[lheight] [int] NULL,[lFontname] [nvarchar](50) NULL,[lfontsize] [smallint] NULL,[lfontstyle] [smallint] NULL,[lfontcolor] [nvarchar](50) NULL,[Lcase] [nvarchar](50) NULL,[Rcase] [nvarchar](50) NULL,[lalign] [nvarchar](50) NULL,[space] [int] NULL,[DBType] [smallint] NULL,[DBField] [nvarchar](50) NULL,[FormatType] [nvarchar](10) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE  [couponmaster]( [Cname] [nvarchar](50) NULL,[cper] [float] NULL,[datefrom] [datetime] NULL,[dateto] [datetime] NULL,[MaxValues] [float] NULL,[UsedValue] [float] NULL,[MaxNoofUses] [float] NULL,[isActive] [bit] NULL,[Datefromvalue] [bigint] NULL,[DatetoValue] [bigint] NULL,[IsAllowOneTime] [bit] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [PrintFieldLabels]([SchemeName] [nvarchar](50) NULL,[Fieldname] [nvarchar](50) NULL,[labletext] [nvarchar](50) NULL,[DBField] [nvarchar](50) NULL,[IsVisible] [bit] NULL,[ftop] [int] NULL,[fleft] [int] NULL,[width] [int] NULL,[height] [int] NULL,[Fontname] [nvarchar](50) NULL,[fontsize] [smallint] NULL,[fontstyle] [smallint] NULL,[fontcolor] [nvarchar](50) NULL,[Align] [nvarchar](50) NULL,[lTop] [int] NULL,[lleft] [int] NULL,[lwidth] [int] NULL,[lheight] [int] NULL,[lFontname] [nvarchar](50) NULL,[lfontsize] [smallint] NULL,[lfontstyle] [smallint] NULL,[lfontcolor] [nvarchar](50) NULL,[lalign] [nvarchar](150) NULL,[sample] [nvarchar](150) NULL,[DBType] [smallint] NULL,[FieldType] [smallint] NULL,[PrintText] [nvarchar](150) NULL,[FormatType] [int] NULL,[DatabaseValue] [int] NULL,[IsLedgerValue] [int] NULL,[decimals] [int] NULL,[supress] [int] NULL,[Formulastr] [nvarchar](250) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [PrintHeadings] ([schemename] [nvarchar](50) NULL,[fTop] [int] NULL,[fleft] [int] NULL,[width] [int] NULL,[height] [int] NULL,[Fontname] [nvarchar](50) NULL,[fontsize] [smallint] NULL,[fontstyle] [smallint] NULL,[fontcolor] [nvarchar](50) NULL,[fieldname] [nvarchar](75) NULL,[Align] [nvarchar](50) NULL,[fcase] [nvarchar](50) NULL,[IsVisible] [bit] NULL,[HeadText] [nvarchar](150) NULL) ON [PRIMARY]  "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                SQLFcmd.CommandText = "CREATE TABLE [PrintingSchemes]([SchemeName] [nvarchar](50) NULL,[VoucherName] [nvarchar](50) NULL,[IsActive] [float] NULL,[ID] [int] NULL,[SchemeType] [int] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [PrintingSettings] ([PrinterName] [nvarchar](150) NULL,[schemename] [nvarchar](50) NULL,[Width] [int] NULL,[Height] [int] NULL,[IsLandScape] [bit] NULL,[fleft] [int] NULL,[fright] [int] NULL,[ftop] [int] NULL,[fbuttom] [int] NULL,[multi] [bit] NULL,[showsubtotals] [bit] NULL,[IsActive] [bit] NULL,[PaperName] [nvarchar](50) NULL,[LeftLogoIsOn] [bit] NULL,[RightLogoIson] [bit] NULL,[Leftlogoleft] [int] NULL,[Leftlogotop] [int] NULL,[Leftlogowidth] [int] NULL,[Leftlogoheight] [int] NULL,[Rightlogoleft] [int] NULL,[Rightlogotop] [int] NULL,[Rightlogowidth] [int] NULL,[Rightlogoheight] [int] NULL,[leftlogopath] [nvarchar](255) NULL,[rightlogopath] [nvarchar](255) NULL,[MaxRowsPerPage] [int] NULL,[RowHeight] [int] NULL,[showpageno] [bit] NULL,[pagenotop] [int] NULL,[pagenoleft] [int] NULL,[pageformat] [smallint] NULL,[IsrollPaper] [bit] NULL,[Isheaderfooterrepeat] [bit] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [PrintLables] ([schemename] [nvarchar](50) NULL,[ftop] [int] NULL,[fleft] [int] NULL,[width] [int] NULL,[height] [int] NULL,[Fontname] [nvarchar](50) NULL,[fontsize] [smallint] NULL,[fontstyle] [smallint] NULL,[fontcolor] [nvarchar](50) NULL,[fieldname] [nvarchar](75) NULL,[labletext] [nvarchar](255) NULL,[isvisible] [bit] NULL,[align] [nvarchar](50) NULL) ON [PRIMARY]  "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [PrintLines]([schemename] [nvarchar](50) NULL,[ftop] [real] NULL,[fleft] [real] NULL,[width] [real] NULL,[height] [real] NULL,[fieldname] [nvarchar](75) NULL,[FieldType] [smallint] NULL,[LineColor] [nvarchar](50) NULL,[BoarderStyle] [nvarchar](50) NULL,[BoarderWidth] [real] NULL,[IsVisible] [bit] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [PrintRecords]([SchemeName] [nvarchar](50) NULL,[Fieldname] [nvarchar](50) NULL,[labletext] [nvarchar](50) NULL,[ObjectType] [nvarchar](50) NULL,[IsVisible] [bit] NULL,[ftop] [int] NULL,[fleft] [int] NULL,[width] [int] NULL,[height] [int] NULL,[Fontname] [nvarchar](50) NULL,[fontsize] [smallint] NULL,[fontstyle] [smallint] NULL,[fontcolor] [nvarchar](50) NULL,[Align] [nvarchar](50) NULL,[lTop] [int] NULL,[lleft] [int] NULL,[lwidth] [int] NULL,[lheight] [int] NULL,[lFontname] [nvarchar](50) NULL,[lfontsize] [smallint] NULL,[lfontstyle] [smallint] NULL,[lfontcolor] [nvarchar](50) NULL,[Lcase] [nvarchar](50) NULL,[Rcase] [nvarchar](50) NULL,[lalign] [nvarchar](50) NULL,[space] [int] NULL,[DBType] [smallint] NULL,[DBField] [nvarchar](50) NULL,[FormatType] [nvarchar](10) NULL,[decimals] [int] NULL,[supress] [int] NULL,[Formulastr] [nvarchar](250) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                'CREATE A ACCOUNTGROUPSLIST TABLE
                SQLFcmd.CommandText = "CREATE TABLE [AccountGroupsList]  ([groupname] [nvarchar](50) NOT NULL,	[subgroup] [nvarchar](50) NOT NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [PriceList]([Pricelistname] [nvarchar](50) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [UsedTranscodeList] ([Transcode] [bigint] NULL,[UsedTranscode] [bigint] NULL,[UsedDbName] [nvarchar](50) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [EmailDb] ([EmailID] [nvarchar](150) NULL,[EmailPassword] [nvarchar](50) NULL,[ServerName] [nvarchar](50) NULL,[Port] [int] NULL,[emailfooter] [nvarchar](550) NULL,[IsSSL] [nvarchar](50) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [empmsgs]([EmpMsgType] [nvarchar](50) NULL,[EmpMsgtext] [nvarchar](max) NULL,[subject] [nvarchar](200) NULL) ON [PRIMARY]  "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()
                ' 


                'STOCK DATABASE


                SQLFcmd.CommandText = "CREATE TABLE [VoucherAccounts]([AccountName] [nvarchar](75) NULL,[Amount] [float] NULL,[IsDrCr] [int] NULL,[Transcode] [bigint] NULL,[VoucherNo] [nvarchar](50) NULL,[Sno] [int] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [barcodeprintsettings]([Schemename] [nvarchar](150) NULL,[PaperSize] [nvarchar](50) NULL,[lwidht] [float] NULL,[lheight] [float] NULL,[TopMargin] [float] NULL,[LeftMargin] [float] NULL,[HGap] [float] NULL,[Vgap] [float] NULL,[IsPrintItemCode] [bit] NULL,[IsPrintMRP] [bit] NULL,[IsPrintWRP] [bit] NULL,[Noofcolumns] [int] NULL,[IsPrintComp] [bit] NULL,[Currency] [nvarchar](50) NULL,[IsWithDecimal] [int] NULL,[LOGO] [image] NULL,[logowidth] [float] NULL,[logoheight] [float] NULL,[logoleft] [float] NULL,[logotop] [float] NULL,[IslogoEnable] [bit] NULL,[IsDefault] [bit] NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]  "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [BarcodeFieldSettings]([Schemename] [nvarchar](150) NULL,[FiledName] [nvarchar](50) NULL,[Lwidth] [float] NULL,[LHeight] [float] NULL,[LTop] [float] NULL,[Lleft] [float] NULL,[DbName] [nvarchar](50) NULL,[LText] [nvarchar](50) NULL,[Fontname] [nvarchar](50) NULL,[fontsize] [smallint] NULL,[fontstyle] [smallint] NULL,[fontcolor] [nvarchar](50) NULL,[Align] [nvarchar](50) NULL,[IsVisible] [bit] NULL,[backcolor] [nvarchar](50) NULL,[Lcase] [nvarchar](50) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [printbarcodeList]([ID] [bigint] NULL,[Cmpname1] [nvarchar](75) NULL,[itemname1] [nvarchar](75) NULL,[MRP1] [nvarchar](50) NULL,[Price1] [nvarchar](50) NULL,[barcode1] [nvarchar](50) NULL,[fontname1] [nvarchar](150) NULL,[Cmpname2] [nvarchar](75) NULL,[itemname2] [nvarchar](75) NULL,[MRP2] [nvarchar](50) NULL,[Price2] [nvarchar](50) NULL,[barcode2] [nvarchar](50) NULL,[fontname2] [nvarchar](150) NULL,[Cmpname3] [nvarchar](75) NULL,[itemname3] [nvarchar](75) NULL,[MRP3] [nvarchar](50) NULL,[Price3] [nvarchar](50) NULL,[barcode3] [nvarchar](50) NULL,[fontname3] [nvarchar](150) NULL,[Cmpname4] [nvarchar](75) NULL,[itemname4] [nvarchar](75) NULL,[MRP4] [nvarchar](50) NULL,[Price4] [nvarchar](50) NULL,[barcode4] [nvarchar](50) NULL,[fontname4] [nvarchar](150) NULL,[Cmpname5] [nvarchar](75) NULL,[itemname5] [nvarchar](75) NULL,[MRP5] [nvarchar](50) NULL,[Price5] [nvarchar](50) NULL,[barcode5] [nvarchar](50) NULL,[fontname5] [nvarchar](150) NULL,[Cmpname6] [nvarchar](75) NULL,[itemname6] [nvarchar](75) NULL,[MRP6] [nvarchar](50) NULL,[Price6] [nvarchar](50) NULL,[barcode6] [nvarchar](50) NULL,[fontname6] [nvarchar](150) NULL,[Image1] [image] NULL,[Image2] [image] NULL,[Image3] [image] NULL,[Image4] [image] NULL,[Image5] [image] NULL,[Image6] [image] NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [barcodeprintimages] ([Schemename] [nvarchar](50) NULL,[imagewidth] [float] NULL,[imageHeight] [float] NULL,[LTop] [float] NULL,[Lleft] [float] NULL,[imagepath] [nvarchar](250) NULL,[Orderno] [int] NULL,[IsVisible] [bit] NULL,[Imagename] [nvarchar](50) NULL,[Rotate] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [barcodeprintlabels]([Schemename] [nvarchar](50) NULL,[Lwidth] [float] NULL,[LHeight] [float] NULL,[LTop] [float] NULL,[Lleft] [float] NULL,[DbName] [nvarchar](50) NULL,[LText] [nvarchar](50) NULL,[Fontname] [nvarchar](50) NULL,[fontsize] [smallint] NULL,[fontstyle] [smallint] NULL,[fontcolor] [nvarchar](50) NULL,[Align] [nvarchar](50) NULL,[IsVisible] [bit] NULL,[backcolor] [nvarchar](50) NULL,[Rotate] [int] NULL,[IsDbFiled] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [barcodePrintLines]([schemename] [nvarchar](50) NULL,[ltop] [float] NULL,[lleft] [float] NULL,[lwidth] [float] NULL,[lheight] [float] NULL,[fieldname] [nvarchar](75) NULL,[FieldType] [smallint] NULL,[LineColor] [nvarchar](50) NULL,[BoarderStyle] [nvarchar](50) NULL,[BoarderWidth] [int] NULL,[IsVisible] [bit] NULL,[fillcolor] [nvarchar](50) NULL,[Rotate] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [BarcodePrintSchemes]([Schemename] [nvarchar](50) NULL,[Barcodewidth] [float] NULL,[BarcodeHeight] [float] NULL,[Lwidth] [float] NULL,[LHeight] [float] NULL,[LTop] [float] NULL,[Lleft] [float] NULL,[LVgap] [float] NULL,[LHgap] [float] NULL,[nocolumns] [int] NULL,[barcodetype] [nvarchar](50) NULL,[papertype] [nvarchar](50) NULL,[BarcodeLeft] [int] NULL,[BarcodeTop] [int] NULL,[barcodeColor] [nvarchar](75) NULL,[Rotate] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [logfile] ([StoreName] [nvarchar](50) NULL,[TransDatetime] [datetime] NULL,[Transcode] [float] NULL,[vouchername] [nvarchar](50) NULL,[voucherno] [nvarchar](50) NULL,[username] [nvarchar](50) NULL,[status] [nvarchar](50) NULL,[systemno] [nvarchar](50) NULL,[details] [nvarchar](250) NULL,[ID] [float] NULL,[TransDateValue] [bigint] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [StockLocations] ([locationname] [nvarchar](50) NULL,[locationtemp] [nvarchar](50) NULL,[Isvisible] [int] NULL,[IsDefault] [int] NULL,[IsDelete] [int] NULL,[ADDRESS] [nvarchar](150) NULL,[CITY] [nvarchar](50) NULL,[contactno] [nvarchar](30) NULL,[contactperson] [nvarchar](75) NULL,[email] [nvarchar](100) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [Categoriesgroups]([StockCategoryName] [nvarchar](50) NOT NULL,[StockCategoryNameTemp] [nvarchar](50) NOT NULL,[groupRoot] [nvarchar](50) NOT NULL,[grouplevel] [int] NOT NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [DepartmentGroups]([DepName] [nvarchar](50) NOT NULL,[DepNameTemp] [nvarchar](50) NOT NULL,[groupRoot] [nvarchar](50) NOT NULL,[grouplevel] [int] NOT NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [DepartmentsLists](	[groupname] [nvarchar](50) NOT NULL,	[subgroup] [nvarchar](50) NOT NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                SQLFcmd.CommandText = "CREATE TABLE [company]([companyname] [nvarchar](125) NULL,[licenseno] [nvarchar](70) NULL,[taxregno] [nvarchar](70) NULL,[address] [nvarchar](75) NULL,[location] [nvarchar](75) NULL,[state] [nvarchar](75) NULL,[country] [nvarchar](75) NULL,[Tel] [nvarchar](20) NULL,[fax] [nvarchar](20) NULL,[emailid] [nvarchar](75) NULL,[website] [nvarchar](125) NULL,[accounttype] [nvarchar](50) NULL,[adminname] [nvarchar](50) NULL,[adminpassword] [nvarchar](50) NULL,[adminemailid] [nvarchar](120) NULL,[Isactive] [int] NULL,[logoimage] [nvarchar](255) NULL,[accyearstart] [datetime] NULL,[accyearend] [datetime] NULL,[booksyearstart] [datetime] NULL,[booksyearend]  [datetime] NULL,[Backupath] [nvarchar](255) NULL,[photopath] [nvarchar](255) NULL,[BarcodePath] [nvarchar](255) NULL,[LastAccessDate] [datetime] NULL,[Currency] [nvarchar](10) NULL,[Version] [int] NULL,[UpdateValue] [int] NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[N1] [float] NULL,[N2] [float] NULL,[UserSecurityQ1] [nvarchar](125) NULL,[UserSecurityQ2] [nvarchar](125) NULL,[UserSecurityA1] [nvarchar](50) NULL,[UserSecurityA2] [nvarchar](50) NULL,[IsSizeBasedItem] [bit] NULL,[YearStartDate] [datetime] NULL,[YearEndDate] [datetime] NULL,[CurrencyName] [nvarchar](50) NULL,[Versionno] [int] NULL,[Versiontext] [nvarchar](50) NULL,[PeriodFrom] [datetime] NULL,[PeriodTo] [datetime] NULL,[CompanyID] [nvarchar](125) NULL, [CurrentDate] [DATETIME] NULL,[noofdecimals] [int] NULL,[CstNo] [nvarchar](50) NULL,[dateformattext] [nvarchar](50) NULL,[DecimalSymbol] [nvarchar](50) NULL) ON [PRIMARY]  "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [Godwons](	[GodownName] [nvarchar](50) NULL,	[GodownNameTemp] [nvarchar](50) NULL,	[IsDeleted] [int] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                'NEWTABLES

                SQLFcmd.CommandText = "CREATE TABLE [LockEditings]([FormCode] [bigint] NULL,[AccountName] [nvarchar](75) NULL,[SystemName] [nvarchar](50) NULL,[AccountNameCode] [int] NULL,[UserName] [nvarchar](50) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                SQLFcmd.CommandText = "CREATE TABLE [Bill2Bill]([BillType] [nvarchar](10) NULL,[LedgerName] [nvarchar](75) NULL,[TransCode] [bigint] NULL,[BillTransCode] [bigint] NULL,[Dr] [float] NULL,[Cr] [float] NULL,[RefNo] [nvarchar](50) NULL,[InvoiceNo] [nvarchar](50) NULL,[IsOpening] [int] NULL,[TransDate] [datetime] NULL,[StoreName] [nvarchar](50) NULL,[PayDays] [int] NULL,[VoucherName] [nvarchar](50) NULL,[PaymentMethod] [nvarchar](50) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "  CREATE TABLE [StockBatch]([StockCode] [nvarchar](50) NULL,[Barcode] [nvarchar](40) NULL,[StockSize] [nvarchar](25) NULL,[Location] [nvarchar](50) NULL,[BaseQty] [float] NULL,[TotalQty] [float] NULL,[SubUnitQty] [float] NULL,[QtyText] [nvarchar](50) NULL,[OpBaseQty] [float] NULL,[OpTotalQty] [float] NULL,[OpSubUnitQty] [float] NULL,[StockRate] [float] NULL,[Expiry] [datetime] NULL,[BatchNo] [nvarchar](50) NULL,[OpstockRate] [float] NULL,[mrp] [float] NULL,[expiryDateValue] [bigint] NULL,[BaseUnit] [nvarchar](75) NULL,[MainUnit] [nvarchar](50) NULL,[SubUnit] [nvarchar](50) NULL,[IsSimpleUnit] [int] NULL,[mrprate] [float] NULL,[taxtype] [nvarchar](10) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [LedgerBook] ([LedgerName] [nvarchar](75) NULL,[TransCode] [bigint] NULL,[InvoiceNo] [nvarchar](50) NULL,[InvoiceName] [nvarchar](50) NULL,[sno] [int] NULL,[Dr] [float] NULL,[Cr] [float] NULL,[TransDate] [datetime] NULL,[TransDateValue] [float] NULL,[LedgerGroup] [nvarchar](75) NULL,[AcLedger] [nvarchar](75) NULL,[IsAdvance] [int] NULL,[IsDeleted] [int] NULL,[UserName] [nvarchar](50) NULL,[StoreName] [nvarchar](50) NULL,[Narration] [nvarchar](250) NULL,[InvoiceType] [nvarchar](30) NULL,[RefNo] [nvarchar](50) NULL,[CurrencyCode] [nvarchar](8) NULL,[ConRate] [float] NULL,[Ddr] [float] NULL,[Dcr] [float] NULL,[N1] [int] NULL,[IsChequePrint] [bit] NULL,[ClearPDC] [bit] NULL,[F1] [nvarchar](50) NULL,[N2] [float] NULL,[TodaydateValue] [bigint] NULL,[IsPostDated] [bit] NULL,[TodayDate] [datetime] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " CREATE TABLE [ExpiryHistory]([DocType] [nvarchar](50) NULL,[DocName] [nvarchar](50) NULL,[IDType] [nvarchar](50) NULL,[verifiedby] [nvarchar](75) NULL,[ExpiryDate] [datetime] NULL,[AlterDate] [datetime] NULL,[UserName] [nvarchar](75) NULL,[renewDate] [datetime] NULL,[RefNumber] [nvarchar](50) NULL,[RegNumber] [nvarchar](50) NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[RegDate] [datetime] NULL,[Sno] [int] IDENTITY(1,1) NOT NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [Vehicle]([VhType] [nvarchar](75) NULL,[VHRefNo] [nvarchar](50) NULL,[VHID] [nvarchar](50) NULL,[VHName] [nvarchar](75) NULL,[IssuedBy] [nvarchar](75) NULL,[ExpiryDate] [datetime] NULL,[RegNo] [nvarchar](50) NULL,[RegDate] [datetime] NULL,[VhNo] [nvarchar](50) NULL,[ContactNo1] [nvarchar](20) NULL,[ContactNo2] [nvarchar](20) NULL,[Chasisno] [nvarchar](50) NULL,[EngineNo] [nvarchar](50) NULL,[AccountGroup] [nvarchar](75) NULL,[AcountLedgerName] [nvarchar](75) NULL,[PhotoPath] [nvarchar](250) NULL,[IsDelete] [int] NULL,[IsActive] [int] NULL,[Status] [nvarchar](50) NULL,[DocAdd1] [nvarchar](250) NULL,[DocAdd2] [nvarchar](250) NULL,[DocAdd3] [nvarchar](250) NULL,[DocAdd4] [nvarchar](250) NULL,[DocAttach1] [varbinary](max) NULL,[DocAttach2] [varbinary](max) NULL,[DocAttach3] [varbinary](max) NULL,[DocAttach4] [varbinary](max) NULL,[DocAttach5] [varbinary](max) NULL,[DocAttachFileName1] [nvarchar](250) NULL,[DocAttachFileName2] [nvarchar](250) NULL,[DocAttachFileName3] [nvarchar](250) NULL,[DocAttachFileName4] [nvarchar](250) NULL,[DocAttachFileName5] [nvarchar](250) NULL,[DocAttachFileSize1] [float] NULL,[DocAttachFileSize2] [float] NULL,[DocAttachFileSize3] [float] NULL,[DocAttachFileSize4] [float] NULL,[DocAttachFileSize5] [float] NULL,[DriverName1] [nvarchar](75) NULL,[DriverName2] [nvarchar](75) NULL,[AssistantName1] [nvarchar](75) NULL,[AssistantName2] [nvarchar](75) NULL,[Color] [nvarchar](20) NULL,[Model] [nvarchar](50) NULL,[MadeBy] [nvarchar](50) NULL,[InsurenceNo1] [nvarchar](50) NULL,[InsurenceDate1] [datetime] NULL,[InsurenceExpiry1] [datetime] NULL,[InsurenceNo2] [nvarchar](50) NULL,[InsurenceDate2] [datetime] NULL,[InsurenceExpiry2] [datetime] NULL,[InsurenceNo3] [nvarchar](50) NULL,[InsurenceDate3] [datetime] NULL,[InsurenceExpiry3] [datetime] NULL,[InsurenceDetails3] [nvarchar](150) NULL,[InsurenceDetails2] [nvarchar](150) NULL,[InsurenceDetails1] [nvarchar](150) NULL,[isCheckOut] [bit] NULL ) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [documentissues]([empname] [nvarchar](75) NULL,[DocName] [nvarchar](75) NULL,[issuedate] [datetime] NULL,[expirydate] [datetime] NULL,[notes] [nvarchar](250) NULL,[IssueNo] [nvarchar](50) NULL,[Doctype] [int] NULL,[Status] [bit] NULL, [Notes2] [nvarchar](250) NULL ,[checkoutdate] [datetime] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                SQLFcmd.CommandText = " CREATE TABLE [CostCenters]([StockGroupName] [nvarchar](50) NOT NULL,[StockGroupNameTemp] [nvarchar](50) NOT NULL,[groupRoot] [nvarchar](50) NOT NULL,[grouplevel] [int] NOT NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [CostCenterList]([groupname] [nvarchar](50) NOT NULL,[subgroup] [nvarchar](50) NOT NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [CostCenterBook]([sno] [int] NULL,[LedgerName] [nvarchar](75) NULL,[CostCenterName] [nvarchar](50) NULL,[Dr] [float] NULL,[Cr] [float] NULL,[UserName] [nvarchar](75) NULL,[TransCode] [bigint] NULL,[TransDate] [datetime] NULL,[Transdatevalue] [bigint] NULL,[VoucherName] [nvarchar](50) NULL,[InvoiceNo] [nvarchar](50) NULL,[CostNo] [int] NULL,[CostCat] [nvarchar](75) NULL,[IsAdditional] [bit] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " CREATE TABLE [CostCenterNames]([CostName] [nvarchar](75) NULL,[costgroup] [nvarchar](75) NULL,[n1] [float] NULL,[f1] [nvarchar](50) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [ledgers] ([LedgerName] [nvarchar](75) NULL,[LedgerCode] [nvarchar](50) NULL,[TaxRegno] [nvarchar](50) NULL,[AccountGroup] [nvarchar](75) NULL,[address] [nvarchar](75) NULL,[location] [nvarchar](75) NULL,[state] [nvarchar](75) NULL,[country] [nvarchar](75) NULL,[Tel] [nvarchar](20) NULL,[fax] [nvarchar](20) NULL,[emailid] [nvarchar](75) NULL,[website] [nvarchar](125) NULL,[accounttype] [nvarchar](50) NULL,[createdby] [nvarchar](50) NULL,[alterby] [nvarchar](50) NULL,[verifiedby] [nvarchar](50) NULL,[Isactive] [int] NULL,[creditlimit] [float] NULL,[discount] [float] NULL,[Contactperson] [nvarchar](75) NULL,[pdesignation] [nvarchar](50) NULL,[ptel] [nvarchar](20) NULL,[pphoneno] [nvarchar](20) NULL,[pemail] [nvarchar](50) NULL,[Dr] [float] NULL,[Cr] [float] NULL,[OpDr] [float] NULL,[OpCr] [float] NULL,[IsBillWise] [int] NULL,[photopath] [nvarchar](250) NULL,[currentbalance] [float] NULL,[partyaddresscity] [nvarchar](100) NULL,[StoreName] [nvarchar](50) NULL,[CreditPeriod] [float] NULL,[Currency] [nchar](10) NULL,[LedgerNameTemp] [nvarchar](75) NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[N1] [float] NULL,[n2] [float] NULL,[PriceLevel] [nvarchar](50) NULL,[Activity] [nvarchar](50) NULL,[BankAccNo] [nvarchar](50) NULL,[EnableChequePrinting] [bit] NULL,[pincode] [nvarchar](18) NULL,[IsAllowCostCentre] [bit] NULL,[Isprimary] [int] NULL,[IsSendEmail] [bit] NULL,[IsSendSMS] [bit] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                'PrintDataLedgers
                SQLFcmd.CommandText = "CREATE TABLE [PrintDataLedgers] ([LedgerName] [nvarchar](75) NULL,[LedgerCode] [nvarchar](50) NULL,[TaxRegno] [nvarchar](50) NULL,[AccountGroup] [nvarchar](75) NULL,[address] [nvarchar](75) NULL,[location] [nvarchar](75) NULL,[state] [nvarchar](75) NULL,[country] [nvarchar](75) NULL,[Tel] [nvarchar](20) NULL,[fax] [nvarchar](20) NULL,[emailid] [nvarchar](75) NULL,[website] [nvarchar](125) NULL,[accounttype] [nvarchar](50) NULL,[createdby] [nvarchar](50) NULL,[alterby] [nvarchar](50) NULL,[verifiedby] [nvarchar](50) NULL,[Isactive] [int] NULL,[creditlimit] [float] NULL,[discount] [float] NULL,[Contactperson] [nvarchar](75) NULL,[pdesignation] [nvarchar](50) NULL,[ptel] [nvarchar](20) NULL,[pphoneno] [nvarchar](20) NULL,[pemail] [nvarchar](50) NULL,[Dr] [float] NULL,[Cr] [float] NULL,[OpDr] [float] NULL,[OpCr] [float] NULL,[IsBillWise] [int] NULL,[photopath] [nvarchar](250) NULL,[currentbalance] [float] NULL,[partyaddresscity] [nvarchar](100) NULL,[StoreName] [nvarchar](50) NULL,[CreditPeriod] [float] NULL,[Currency] [nchar](10) NULL,[LedgerNameTemp] [nvarchar](75) NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[N1] [float] NULL,[n2] [float] NULL,[PriceLevel] [nvarchar](50) NULL,[Activity] [nvarchar](50) NULL,[BankAccNo] [nvarchar](50) NULL,[EnableChequePrinting] [bit] NULL,[pincode] [nvarchar](18) NULL,[IsAllowCostCentre] [bit] NULL,[Isprimary] [int] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [CurrencyList]([CurrencyName] [nvarchar](250) NULL,[CurrencyCode] [nvarchar](8) NULL,[CurrencySymbol] [nvarchar](8) NULL,[ConRate] [float] NULL,[Demicals] [int] NULL,[IsActive] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [DefLedgers]([LedgerName] [nvarchar](75) NULL,[LedgerType] [nvarchar](50) NULL,[UserName] [nvarchar](75) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [EditValues]([ChangedName] [nvarchar](75) NULL,[OldName] [nvarchar](75) NULL,[Databasetablename] [nvarchar](50) NULL,[FileName] [nvarchar](50) NULL,[IsUpdate] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [InvoiceSettings]([InvoiceNumber] [bigint] NULL,[InvoicePreFix] [nvarchar](15) NULL,[InvoicePostFix] [nvarchar](15) NULL,[InvoiceMethod] [smallint] NULL,[PrintonSave] [smallint] NULL,[eachnarration] [smallint] NULL,[PrintingScheme1] [nvarchar](50) NULL,[PrintingScheme2] [nvarchar](50) NULL,[PrintingScheme3] [nvarchar](50) NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[N1] [int] NULL,[N2] [int] NULL,[AllowDuplicate] [int] NULL,[VoucherName] [nvarchar](50) NULL,[location] [nvarchar](75) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [UserDepartments]([UserID] [nvarchar](50) NULL,[DepName] [nvarchar](50) NULL,[Isdelete] [bit] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

               

                SQLFcmd.CommandText = " CREATE TABLE [Duties]([EmpName] [nvarchar](75) NULL,[DutyType] [nvarchar](20) NULL,[TimeIn] [datetime] NULL,[TimeOut] [datetime] NULL,[datefrom] [datetime] NULL,[dateto] [datetime] NULL,[datefromvalue] [bigint] NULL,[datetovalue] [bigint] NULL,[sno] [int] NULL,[ETimeIn] [datetime] NULL,[ETimeOut] [datetime] NULL,[MealTime] [datetime] NULL,[MealDuration] [datetime] NULL,[breaktime1] [datetime] NULL,[breakDuration1] [datetime] NULL,[BreakTime2] [datetime] NULL,[BreakDuration2] [datetime] NULL,[MealTimeText] [nvarchar](50) NULL,[Break1Text] [nvarchar](50) NULL,[Break2Text] [nvarchar](50) NULL,[MealTimeColorR] [tinyint] NULL,[MealTimeColorG] [tinyint] NULL,[MealTimeColorB] [tinyint] NULL,[Break1Colorr] [tinyint] NULL,[Break1ColorG] [tinyint] NULL,[Break1ColorB] [tinyint] NULL,[Break2ColorR] [tinyint] NULL,[Break2ColorG] [tinyint] NULL,[Break2ColorB] [tinyint] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " CREATE TABLE [Dutysettings] ([ShiftName] [nvarchar](50) NULL,[Timein] [datetime] NULL,[timeout] [datetime] NULL,[ShiftType] [nvarchar](50) NULL,[ETimeIn] [datetime] NULL,[ETimeOut] [datetime] NULL,[earlyinOT] [bit] NULL,[earlyin] [datetime] NULL,[lateoutOT] [bit] NULL,[lateout] [datetime] NULL,[breaktimefrom] [datetime] NULL,[breaktimeto] [datetime] NULL,[issingleshift] [bit] NULL,[totalmins] [float] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()







                SQLFcmd.CommandText = "CREATE TABLE [Leaves] ([LeaveName] [nvarchar](50) NULL,[LeaveType] [nvarchar](25) NULL,[Maxno] [float] NULL,[ColorCode] [nvarchar](30) NULL,[LeaveCode] [nvarchar](4) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                SQLFcmd.CommandText = "CREATE TABLE [EmpLeaves]([EmpName] [nvarchar](75) NULL,[LeaveDays] [int] NULL,[FromDate] [datetime] NULL,[FromDateValue] [bigint] NULL,[ToDate] [datetime] NULL,[ToDateValue] [bigint] NULL,[Narration] [nvarchar](200) NULL,[LeaveName] [nvarchar](50) NULL,[TransDate] [datetime] NULL,[TransDateValue] [bigint] NULL,[UserName] [nvarchar](75) NULL,[ForYear] [int] NULL,[n1] [int] NULL,[TransCode] [bigint] NULL,[LeaveCode] [nvarchar](5) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [EmpAttend]([EmpName] [nvarchar](75) NULL,[StratTime] [datetime] NULL,[EndTime] [datetime] NULL,[Status] [nvarchar](4) NULL,[Transdatevalue] [bigint] NULL,[TransDate] [datetime] NULL,[OT] [float] NULL,[Others] [float] NULL,[period] [nvarchar](15) NULL,[LT] [float] NULL,[EStratTime] [datetime] NULL,[EEndTime] [datetime] NULL,[EStatus] [nvarchar](4) NULL,[TotalworkingMin] [int] NULL,[TickCount] [float] NULL,[Narration] [nvarchar](100) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [settings] ([SharedFolderName] [nvarchar](350) NULL,[IsBatchExpiry] [bit] NULL,[IsBillWise] [bit] NULL,[IsAutoPrinting] [bit] NULL,[IsAutoBackup] [bit] NULL,[IsAllowCashBankinJournal] [bit] NULL,[IsCustomBarcode] [bit] NULL,[IsAllowZeroValueStock] [bit] NULL,[IsAllowNagetiveStock] [bit] NULL,[IsFixedDate] [bit] NULL,[IsNewInvoiceOnSave] [bit] NULL,[IsAllowDuplicateRef] [bit] NULL,[IsAllowAllRef] [bit] NULL,[IsAllowPriceField] [bit] NULL,[F1] [bit] NULL,[F2] [bit] NULL,[F3] [bit] NULL,[F4] [bit] NULL,[F5] [bit] NULL,[F6] [bit] NULL,[F7] [bit] NULL,[IsAllowSalesOrders] [bit] NULL,[IsAllowPurchaseOrders] [bit] NULL,[IsAllowMemos] [bit] NULL,[IsAllowCurrency] [bit] NULL,[IsAllowDebitNote] [bit] NULL,[IsAllowCreditNote] [bit] NULL,[IsAllowChequePrinting] [bit] NULL,[IsRestartInvoiceNo] [bit] NULL,[IsAllowDeliveryNote] [bit] NULL,[IsAllowGReceiptNote] [bit] NULL,[CostingMethod] [nvarchar](50) NULL,[IsAllowChating] [bit] NULL,[IsLoadDashBoard] [bit] NULL,[isAllowMultiPriceLevels] [bit] NULL,[IsAllowPDC] [bit] NULL,[IsAllowMrngEvngShifts] [bit] NULL,[IsSingleEntryMode] [bit] NULL,[AllowNarrationinvouchers] [bit] NULL,[IsallowCostingforInvoice] [bit] NULL, [PosPriceList] [nvarchar](75) NULL,[IsMultiTaxRates] [bit] NULL,[SalesPricewithTax] [bit] NULL,	[StockPricewithTax] [bit] NULL,[IsAllowEmptyBatchNo] [bit] NULL,[IsAllowMultiSalesTax] [bit] NULL,	[IsAllowMultiPurchaseTax] [bit] NULL,[customPrint] [bit] NULL, [ZerotaxonPurchase] [bit] NULL,[MRPisAsSalesPrice] [bit] NULL,	[IsAllowMultiTax] [bit] NULL , [DefPaymentMethodInSales] [nvarchar](50) NULL,[DefPaymentMethodinPurchase] [nvarchar](50) NULL,[IsAllowOnlyApprovedPurchaseenquiry] [bit] NULL,	[IsAllowOnlyApprovedSalesenquiry] [bit] NULL,	[IsTrailData] [bit] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [projecttable]([ProjectName] [nvarchar](50) NULL,[CatName] [nvarchar](50) NULL,[f1] [nvarchar](50) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [smsmailsettings](	[vouchername] [nvarchar](50) NULL,	[msgtext] [nvarchar](max) NULL,	[isattachfile] [bit] NULL,	[IsEmail] [bit] NULL,[mailSubject] [nvarchar](75) NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [EmpSalaries]([EmpName] [nvarchar](75) NULL,[Salary] [float] NULL,[FromDate] [datetime] NULL,[Todate] [datetime] NULL,[Days] [int] NULL,[years] [float] NULL,[Gratuity] [float] NULL,[Ispaid] [bit] NULL,[paidamount] [float] NULL,[paiddate] [datetime] NULL,[paiddetails] [nvarchar](200) NULL,[increment] [float] NULL,[sno] [int] NULL,[currentSalary] [float] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [StockDbf] ([StockName] [nvarchar](75) NULL,[StockCodeTemp] [nvarchar](75) NULL,[StockCode] [nvarchar](50) NULL,[stockgroup] [nvarchar](75) NULL,[Barcode] [nvarchar](40) NULL,[StockSize] [nvarchar](25) NULL,[Brand] [nvarchar](50) NULL,[Company] [nvarchar](50) NULL,[Location] [nvarchar](50) NULL,[description] [nvarchar](150) NULL,[origin] [nvarchar](50) NULL,[HScode] [nvarchar](50) NULL,[category] [nvarchar](75) NULL,[ISBatch] [int] NULL,[StoreName] [nvarchar](50) NULL,[BaseUnit] [nvarchar](75) NULL,[MainUnit] [nvarchar](50) NULL,[SubUnit] [nvarchar](50) NULL,[IsSimpleUnit] [int] NULL,[BaseQty] [float] NULL,[TotalQty] [float] NULL,[SubUnitQty] [float] NULL,[QtyText] [nvarchar](50) NULL,[OpBaseQty] [float] NULL,[OpTotalQty] [float] NULL,[OpSubUnitQty] [float] NULL,[StockRate] [float] NULL,[StockWRP] [float] NULL,[StockDRP] [float] NULL,[IsAdvance] [int] NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[N1] [float] NULL,[N2] [float] NULL,[StockSizeTemp] [nvarchar](50) NULL,[Expiry] [datetime] NULL,[BatchNo] [nvarchar](50) NULL,[StockImagePath] [nvarchar](250) NULL,[StockType] [int] NULL,[Isactive] [int] NULL,[CustBarcode] [nvarchar](50) NULL,[Myatpp] [float] NULL,[Tax] [float] NULL,[UnitCon] [float] NULL,[MinQty] [float] NULL,[OpstockRate] [float] NULL,[costmethod] [nvarchar](25) NULL,[Servicetax] [float] NULL,[AllowDiscount] [bit] NULL,[mrp] [float] NULL,[packing] [nvarchar](50) NULL,[allowserialnumbers] [bit] NULL,[Tax2] [float] NULL,[cst] [float] NULL,[IsTaxInclude] [bit] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [StockJournalDbf]([RefNo] [nvarchar](50) NULL,[Transcode] [bigint] NULL,[LocationFrom] [nvarchar](50) NULL,[LocationTo] [nvarchar](50) NULL,[transdate] [datetime] NULL,[StockName] [nvarchar](75) NULL,[StockCodeTemp] [nvarchar](75) NULL,[StockCode] [nvarchar](50) NULL,[stockgroup] [nvarchar](75) NULL,[Barcode] [nvarchar](40) NULL,[StockSize] [nvarchar](25) NULL,[Location] [nvarchar](50) NULL,[StoreName] [nvarchar](50) NULL,[BaseUnit] [nvarchar](75) NULL,[MainUnit] [nvarchar](50) NULL,[SubUnit] [nvarchar](50) NULL,[BaseQty] [float] NULL,[TotalQty] [float] NULL,[SubUnitQty] [float] NULL,[QtyText] [nvarchar](50) NULL,[Expiry] [datetime] NULL,[BatchNo] [nvarchar](50) NULL,[Isactive] [int] NULL,[CustBarcode] [nvarchar](50) NULL,[Isdelete] [int] NULL,[TransDateValue] [bigint] NULL,[sno] [int] NULL,[rate] [float] NULL,[presentRate] [float] NULL,[mrp] [float] NULL,	[packing] [nvarchar](50) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [UserRights]([UserName] [nvarchar](75) NULL,[IsEdit] [bit] NULL,[IsAccess] [bit] NULL,[IsReadOnly] [bit] NULL,[IsDelete] [bit] NULL,[IsFullRights] [bit] NULL,[IsMaster] [bit] NULL,[IsOptions] [bit] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [Users]([UserName] [nvarchar](50) NULL,[UserPassword] [nvarchar](50) NULL,[UserType] [int] NULL,[UserEmailID] [nvarchar](50) NULL,[UserID] [nvarchar](50) NULL,[UserSecurityQ1] [nvarchar](125) NULL,[UserSecurityQ2] [nvarchar](125) NULL,[UserSecurityA1] [nvarchar](50) NULL,[UserSecurityA2] [nvarchar](50) NULL,[UserDepartment] [nvarchar](50) NULL,[StoreName] [nvarchar](50) NULL,[LocationName] [nvarchar](50) NULL,[LoginSystemName] [nvarchar](75) NULL,[LoginTime] [datetime] NULL,[IsActive] [bit] NULL,[IsLogin] [bit] NULL,[LogoutTime] [datetime] NULL,[RCode] [nvarchar](10) NULL,[SQLUserID] [nvarchar](50) NULL,[SQLpwd] [nvarchar](50) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [CrReportSettings]([LeftLogoOn] [bit] NULL,[LeftLogoPath] [nvarchar](350) NULL,[RightLogoOn] [bit] NULL,[RightLogoPath] [nvarchar](350) NULL,[HeaderOn] [bit] NULL,[HeaderPath] [nvarchar](350) NULL,[FooterOn] [bit] NULL,[FooterPath] [nvarchar](350) NULL,[PrintPageNos] [bit] NULL,[PrintCompanyName] [bit] NULL,[PrintAddress] [bit] NULL,[PrintTitle] [bit] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                SQLFcmd.CommandText = "CREATE TABLE [UserLogFile] ([UserName] [nvarchar](50) NULL,[LoginTime] [datetime] NULL,[LogoutTime] [datetime] NULL,[LiveTime] [bigint] NULL,[SystemName] [nvarchar](75) NULL,[LoginTimeValue] [bigint] NULL,[Transcode] [bigint] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                'END OF INVOICE NUMBER SETTINGS

                SQLFcmd.CommandText = "CREATE TABLE [InvoiceMoreDet]([Despatchto] [nvarchar](100) NULL,[Despatchaddress] [nvarchar](100) NULL,[despatchtax] [nvarchar](100) NULL,[despatchthrough] [nvarchar](100) NULL,[DespatchDestination] [nvarchar](100) NULL,[buyername] [nvarchar](100) NULL,[buyeraddress] [nvarchar](100) NULL,[buyertax] [nvarchar](100) NULL,[paymenterm] [nvarchar](100) NULL,[otherref] [nvarchar](100) NULL,[remarks] [nvarchar](100) NULL,[consgneename] [nvarchar](100) NULL,[consgneeaddress] [nvarchar](100) NULL,[delevaryto] [nvarchar](100) NULL,[delevarynoteno] [nvarchar](100) NULL,[orderno] [nvarchar](100) NULL,[delevaryterm] [nvarchar](100) NULL,[Transcode] [bigint] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                SQLFcmd.CommandText = " CREATE TABLE [paysliptypes](	[settingname] [nvarchar](50) NULL,	[IsActive] [bit] NULL,	[ledgername] [nvarchar](75) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [DUMMY]([F1] [nchar](10) NULL,[F2] [int] NULL,[F3] [nchar](50) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [EmployeeAttendence] ([EmpID] [nvarchar](50) NULL,[EmpName] [nvarchar](75) NULL,[EmpDate] [datetime] NULL,[EmpDateValue] [bigint] NULL,[Status] [smallint] NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[N1] [float] NULL,[N2] [float] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [Employees] ([EmpID] [nvarchar](50) NULL,[EmpName] [nvarchar](75) NULL,[Gender] [nchar](10) NULL,[DateofBirth] [datetime] NULL,[Nationality] [nvarchar](50) NULL,[Education] [nvarchar](75) NULL,[DateofJoining] [datetime] NULL,[Designation] [nvarchar](75) NULL,[DepName] [nvarchar](50) NULL,[Contracttype] [nvarchar](50) NULL,[contractexpirydate] [datetime] NULL,[address] [nvarchar](75) NULL,[contactno] [nvarchar](50) NULL,[emailid] [nvarchar](75) NULL,[Paddress] [nvarchar](75) NULL,[pcontactno1] [nvarchar](22) NULL,[pcontactno2] [nvarchar](22) NULL,[pemailid] [nvarchar](50) NULL,[photopath] [nvarchar](225) NULL,[EmpPersonalID] [nvarchar](50) NULL,[bankcode] [nvarchar](50) NULL,[bankacno] [nvarchar](50) NULL,[fixedsalary] [money] NULL,[empbankacno] [nvarchar](50) NULL,[empbankname] [nvarchar](50) NULL,[empbankbranch] [nvarchar](50) NULL,[passportIDNo] [nvarchar](50) NULL,[passportIDissuedby] [nvarchar](50) NULL,[passportexpire] [datetime] NULL,[visaIDNo] [nvarchar](50) NULL,[visaIDissuedby] [nvarchar](50) NULL,[visaexpire] [datetime] NULL,[EmiratesDNo] [nvarchar](50) NULL,[Emiratesissuedby] [nvarchar](50) NULL,[Emiratesexpire] [datetime] NULL,[LabourcardDNo] [nvarchar](50) NULL,[Labourcardissuedby] [nvarchar](50) NULL,[Labourcardexpire] [datetime] NULL,[MedicalDNo] [nvarchar](50) NULL,[Medicalissuedby] [nvarchar](50) NULL,[Medicalexpire] [datetime] NULL,[SalaryType] [nvarchar](20) NULL,[EmpCity] [nvarchar](50) NULL,[PEmpCity] [nvarchar](50) NULL,[bankifsccode] [nvarchar](50) NULL,[bankmicrcode] [nvarchar](50) NULL,[Isactive] [int] NULL,[IsDelete] [int] NULL,[AssignedUserName] [nvarchar](75) NULL,[IsUser] [bit] NULL,[Barcode] [nvarchar](40) NULL,[DocAdd1] [nvarchar](250) NULL,[DocAdd2] [nvarchar](250) NULL,[DocAdd3] [nvarchar](250) NULL,[DocAdd4] [nvarchar](250) NULL,[DocAttach1] [varbinary](max) NULL,[DocAttach2] [varbinary](max) NULL,[DocAttach3] [varbinary](max) NULL,[DocAttach4] [varbinary](max) NULL,[DocAttach5] [varbinary](max) NULL,[DocAttachFileName1] [nvarchar](250) NULL,[DocAttachFileName2] [nvarchar](250) NULL,[DocAttachFileName3] [nvarchar](250) NULL,[DocAttachFileName4] [nvarchar](250) NULL,[DocAttachFileName5] [nvarchar](250) NULL,[DocAttachFileSize1] [float] NULL,[DocAttachFileSize2] [float] NULL,[DocAttachFileSize3] [float] NULL,[DocAttachFileSize4] [float] NULL,[DocAttachFileSize5] [float] NULL,[basicsalary] [float] NULL,[allowance] [float] NULL,[CostCat] [nvarchar](75) NULL,[payslipmethod] [nvarchar](50) NULL,[rateperhour] [float] NULL,	[TeamName] [nvarchar](75) NULL,[leavesalaryduedays] [bigint] NULL,[airticketduedays] [bigint] NULL,[leavesalaryfrom] [bigint] NULL,	[airticketfrom] [bigint] NULL,[NotifyDays] [int] NULL ,[isCheckOut] [bit] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [Documents]([DocType] [nvarchar](75) NULL,[DocRefNo] [nvarchar](50) NULL,[DocID] [nvarchar](50) NULL,[DocName] [nvarchar](75) NULL,[IssuedBy] [nvarchar](75) NULL,[ExpiryDate] [datetime] NULL,[DocAdd1] [nvarchar](250) NULL,[DocAdd2] [nvarchar](250) NULL,[DocAdd3] [nvarchar](250) NULL,[DocAdd4] [nvarchar](250) NULL,[DocAttach1] [varbinary](max) NULL,[DocAttach2] [varbinary](max) NULL,[DocAttach3] [varbinary](max) NULL,[DocAttach4] [varbinary](max) NULL,[DocAttach5] [varbinary](max) NULL,[DocAttachFileName1] [nvarchar](250) NULL,[DocAttachFileName2] [nvarchar](250) NULL,[DocAttachFileName3] [nvarchar](250) NULL,[DocAttachFileName4] [nvarchar](250) NULL,[DocAttachFileName5] [nvarchar](250) NULL,[DocAttachFileSize1] [float] NULL,[DocAttachFileSize2] [float] NULL,[DocAttachFileSize3] [float] NULL,[DocAttachFileSize4] [float] NULL,[DocAttachFileSize5] [float] NULL,[Location] [nvarchar](50) NULL,[ContactPerson] [nvarchar](50) NULL,[PersonAddress] [nvarchar](150) NULL,[IsDelete] [int] NULL,[IsActive] [int] NULL,[Status] [nvarchar](50) NULL ,[isCheckOut] [bit] NULL ) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [IDsettings]([salespersonsID] [bigint] NULL,[EmployeeID] [bigint] NULL,[EmployeePerID] [bigint] NULL,[AreaID] [bigint] NULL,[TransCode] [bigint] NULL,[BarCodeEna8] [bigint] NULL,[Barcode128] [bigint] NULL,[ID] [bigint] NULL,[supID] [bigint] NULL,[custID] [bigint] NULL,[StockCode] [bigint] NULL,[AccountCode] [bigint] NULL,[logfileid] [float] NULL,[LockTransCode] [bigint] NULL,[BillTranscode] [bigint] NULL ,[UserTransCode] [bigint] NULL ,[AssetID] [bigint] NULL,[BudgetID] [bigint] NULL) ON [PRIMARY]  "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [salespersons]([salespersonname] [nvarchar](75) NULL,[Address] [nvarchar](120) NULL,[Gender] [nchar](10) NULL,[state] [nvarchar](75) NULL,[country] [nvarchar](75) NULL,[Tel] [nvarchar](20) NULL,[emailid] [nvarchar](75) NULL,[Isactive] [int] NULL,[per] [float] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [StockCategoriesList]([groupname] [nvarchar](50) NOT NULL,[subgroup] [nvarchar](50) NOT NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [StockGroupList](	[groupname] [nvarchar](50) NOT NULL,	[subgroup] [nvarchar](50) NOT NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [assetgroupList](	[groupname] [nvarchar](50) NOT NULL,	[subgroup] [nvarchar](50) NOT NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [StockGroups]([StockGroupName] [nvarchar](50) NOT NULL,[StockGroupNameTemp] [nvarchar](50) NOT NULL,[groupRoot] [nvarchar](50) NOT NULL,[grouplevel] [int] NOT NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [assetgroups]([AssetGroupName] [nvarchar](50) NOT NULL,[AssetGroupNameTemp] [nvarchar](50) NOT NULL,[groupRoot] [nvarchar](50) NOT NULL,[grouplevel] [int] NOT NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                '
                SQLFcmd.CommandText = "CREATE TABLE [Stockunits]([UnitName] [nvarchar](75) NOT NULL,[MainUnitName] [nvarchar](25) NULL,[SubUnitName] [nvarchar](25) NULL,[UnitConversion] [numeric](18, 3) NULL,[UnitType] [int] NULL,[formalname] [nvarchar](70) NULL,[Decimals] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                '
                SQLFcmd.CommandText = "CREATE TABLE [Vatclauses]([VatName] [nvarchar](75) NULL,[vattax] [float] NULL,[inputvatledger] [nvarchar](75) NULL,[outputvatledger] [nvarchar](75) NULL,[PurchaseLedger] [nvarchar](75) NULL,[DebitNoteLedger] [nvarchar](75) NULL,[SalesLedger] [nvarchar](75) NULL,[CreditLedger] [nvarchar](75) NULL,[isactive] [bit] NULL,[Vattype] [nvarchar](15) NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [StockInvoiceDetails] ([TransCode] [bigint] NULL,[TransDate] [datetime] NULL,[TransDateValue] [bigint] NULL,[QutoNo] [nvarchar](50) NULL,[QutoRef] [nvarchar](50) NULL,[OrderNo] [nvarchar](50) NULL,[OrderRef] [nvarchar](50) NULL,[DNoteno] [nvarchar](50) NULL,[DnoteRef] [nvarchar](50) NULL,[StoreName] [nvarchar](75) NULL,[Currency] [nvarchar](10) NULL,[PriceList] [nvarchar](50) NULL,[SalesPerson] [nvarchar](75) NULL,[ProjectName] [nvarchar](75) NULL,[Area] [nvarchar](50) NULL,[LedgerName] [nvarchar](75) NULL,[LedgerAddress] [nvarchar](120) NULL,[IsCommit] [int] NULL,[IsDelete] [int] NULL,[IsPending] [int] NULL,[subtotal] [float] NULL,[grosstotal] [float] NULL,[discountper] [float] NULL,[nettotal] [float] NULL,[taxtotal] [float] NULL,[InvoiceTotal] [float] NULL,[AccountTotal] [float] NULL,[amountinwords] [nvarchar](250) NULL,[narration] [nvarchar](250) NULL,[InvoiceNo] [nvarchar](50) NULL,[InvoiceRef] [nvarchar](50) NULL,[GoodNo] [nvarchar](50) NULL,[GoodRef] [nvarchar](50) NULL,[CurrencyCon1] [float] NULL,[CurrencyCon2] [float] NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[N1] [float] NULL,[N2] [float] NULL,[VoucherName] [nvarchar](50) NULL,[DelivaryDate] [datetime] NULL,[DelivaryDateValue] [bigint] NULL,[Additions] [float] NULL,[Deductions] [float] NULL,[PaymentMethod] [nvarchar](20) NULL,[PaymentLedger] [nvarchar](75) NULL,[PaymentDetails] [nvarchar](120) NULL,[AccountLedgerName] [nvarchar](75) NULL,[InvoiceType] [int] NULL,[DeliveryNote] [bit] NULL,[allocateledger] [nvarchar](75) NULL,[IsDirect] [bit] NULL,[transtype] [nvarchar](30) NULL,[servicetaxtotal] [float] NULL,[roundoff] [float] NULL,[surcharge] [float] NULL,[BillCurrency] [nvarchar](8) NULL,[DiscPer] [float] NULL,[CDiscount] [float] NULL,[CouponName] [nvarchar](50) NULL,	[CDisCountPer] [float] NULL,[sinvoiceno] [nvarchar](50) NULL,	[sinvoicedate] [datetime] NULL,[taxtotal2] [float] NULL,[cstamount] [float] NULL,	[VoucherType] [nvarchar](20) NULL,[AdvancePayment] [float] NULL,CUSTOMERNAME NVARCHAR(100) NULL,[IsApproved] [bit] NULL,[BillType] [nvarchar](50) NULL,	[IsMultiPayment] [bit] NULL,[CashReceived] [float] NULL,	[CashtoPay] [float] NULL ) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()
                'PrintDataDetails
                SQLFcmd.CommandText = "CREATE TABLE [StockTransferDetails] ([TransCode] [bigint] NULL,[TransDate] [datetime] NULL,[TransDateValue] [bigint] NULL,[QutoNo] [nvarchar](50) NULL,[QutoRef] [nvarchar](50) NULL,[OrderNo] [nvarchar](50) NULL,[OrderRef] [nvarchar](50) NULL,[DNoteno] [nvarchar](50) NULL,[DnoteRef] [nvarchar](50) NULL,[StoreName] [nvarchar](75) NULL,[Currency] [nvarchar](10) NULL,[PriceList] [nvarchar](50) NULL,[SalesPerson] [nvarchar](75) NULL,[ProjectName] [nvarchar](75) NULL,[Area] [nvarchar](50) NULL,[LedgerName] [nvarchar](75) NULL,[LedgerAddress] [nvarchar](120) NULL,[IsCommit] [int] NULL,[IsDelete] [int] NULL,[IsPending] [int] NULL,[subtotal] [float] NULL,[grosstotal] [float] NULL,[discountper] [float] NULL,[nettotal] [float] NULL,[taxtotal] [float] NULL,[InvoiceTotal] [float] NULL,[AccountTotal] [float] NULL,[amountinwords] [nvarchar](250) NULL,[narration] [nvarchar](250) NULL,[InvoiceNo] [nvarchar](50) NULL,[InvoiceRef] [nvarchar](50) NULL,[GoodNo] [nvarchar](50) NULL,[GoodRef] [nvarchar](50) NULL,[CurrencyCon1] [float] NULL,[CurrencyCon2] [float] NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[N1] [float] NULL,[N2] [float] NULL,[VoucherName] [nvarchar](50) NULL,[DelivaryDate] [datetime] NULL,[DelivaryDateValue] [bigint] NULL,[Additions] [float] NULL,[Deductions] [float] NULL,[PaymentMethod] [nvarchar](20) NULL,[PaymentLedger] [nvarchar](75) NULL,[PaymentDetails] [nvarchar](120) NULL,[AccountLedgerName] [nvarchar](75) NULL,[InvoiceType] [int] NULL,[DeliveryNote] [bit] NULL,[allocateledger] [nvarchar](75) NULL,[IsDirect] [bit] NULL,[transtype] [nvarchar](30) NULL,[servicetaxtotal] [float] NULL,[roundoff] [float] NULL,[surcharge] [float] NULL,[BillCurrency] [nvarchar](8) NULL,[DiscPer] [float] NULL,[CDiscount] [float] NULL,[CouponName] [nvarchar](50) NULL,	[CDisCountPer] [float] NULL,[sinvoiceno] [nvarchar](50) NULL,	[sinvoicedate] [datetime] NULL,[taxtotal2] [float] NULL,[cstamount] [float] NULL,	[VoucherType] [nvarchar](20) NULL,[AdvancePayment] [float] NULL,CUSTOMERNAME NVARCHAR(100) NULL,[IsApproved] [bit] NULL ) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [PrintDataDetails] ([TransCode] [bigint] NULL,[TransDate] [datetime] NULL,[TransDateValue] [bigint] NULL,[QutoNo] [nvarchar](50) NULL,[QutoRef] [nvarchar](50) NULL,[OrderNo] [nvarchar](50) NULL,[OrderRef] [nvarchar](50) NULL,[DNoteno] [nvarchar](50) NULL,[DnoteRef] [nvarchar](50) NULL,[StoreName] [nvarchar](75) NULL,[Currency] [nvarchar](10) NULL,[PriceList] [nvarchar](50) NULL,[SalesPerson] [nvarchar](75) NULL,[ProjectName] [nvarchar](75) NULL,[Area] [nvarchar](50) NULL,[LedgerName] [nvarchar](75) NULL,[LedgerAddress] [nvarchar](120) NULL,[IsCommit] [int] NULL,[IsDelete] [int] NULL,[IsPending] [int] NULL,[subtotal] [float] NULL,[grosstotal] [float] NULL,[discountper] [float] NULL,[nettotal] [float] NULL,[taxtotal] [float] NULL,[InvoiceTotal] [float] NULL,[AccountTotal] [float] NULL,[amountinwords] [nvarchar](250) NULL,[narration] [nvarchar](250) NULL,[InvoiceNo] [nvarchar](50) NULL,[InvoiceRef] [nvarchar](50) NULL,[GoodNo] [nvarchar](50) NULL,[GoodRef] [nvarchar](50) NULL,[CurrencyCon1] [float] NULL,[CurrencyCon2] [float] NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[N1] [float] NULL,[N2] [float] NULL,[VoucherName] [nvarchar](50) NULL,[DelivaryDate] [datetime] NULL,[DelivaryDateValue] [bigint] NULL,[Additions] [float] NULL,[Deductions] [float] NULL,[PaymentMethod] [nvarchar](20) NULL,[PaymentLedger] [nvarchar](75) NULL,[PaymentDetails] [nvarchar](120) NULL,[AccountLedgerName] [nvarchar](75) NULL,[InvoiceType] [int] NULL,[DeliveryNote] [bit] NULL,[allocateledger] [nvarchar](75) NULL,[IsDirect] [bit] NULL,[transtype] [nvarchar](30) NULL,[servicetaxtotal] [float] NULL,[roundoff] [float] NULL,[surcharge] [float] NULL,[BillCurrency] [nvarchar](8) NULL,[DiscPer] [float] NULL,[CDiscount] [float] NULL,[CouponName] [nvarchar](50) NULL,	[CDisCountPer] [float] NULL,[sinvoiceno] [nvarchar](50) NULL,	[sinvoicedate] [datetime] NULL,[taxtotal2] [float] NULL,[cstamount] [float] NULL,	[VoucherType] [nvarchar](20) NULL ) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [StockInvoiceRowItems]([TransCode] [bigint] NULL,[TransDate] [datetime] NULL,[TransDateValue] [bigint] NULL,[QutoNo] [nvarchar](50) NULL,[QutoRef] [nvarchar](50) NULL,[OrderNo] [nvarchar](50) NULL,[OrderRef] [nvarchar](50) NULL,[DNoteno] [nvarchar](50) NULL,[DnoteRef] [nvarchar](50) NULL,[StoreName] [nvarchar](75) NULL,[Currency] [nvarchar](10) NULL,[StockName] [nvarchar](75) NULL,[StockCode] [nvarchar](50) NULL,[stockgroup] [nvarchar](75) NULL,[Barcode] [nvarchar](40) NULL,[StockSize] [nvarchar](25) NULL,[Location] [nvarchar](50) NULL,[description] [nvarchar](150) NULL,[BaseUnit] [nvarchar](75) NULL,[MainUnit] [nvarchar](50) NULL,[SubUnit] [nvarchar](50) NULL,[IsSimpleUnit] [int] NULL,[MainQty] [float] NULL,[TotalQty] [float] NULL,[SubUnitQty] [float] NULL,[QtyText] [nvarchar](50) NULL,[StockRate] [float] NULL,[Expiry] [datetime] NULL,[BatchNo] [nvarchar](50) NULL,[StockType] [int] NULL,[StockDisc] [float] NULL,[RatePer] [nvarchar](50) NULL,[UnitCon] [int] NULL,[CustBarcode] [nvarchar](40) NULL,[sno] [int] NULL,[StockAmount] [float] NULL,[Isdelete] [int] NULL,[QtyValues] [nvarchar](15) NULL,[VoucherName] [nvarchar](50) NULL,[CurrencyCon1] [float] NULL,[Tax] [float] NULL,[NetRate] [float] NULL,[origin] [nvarchar](50) NULL,[HScode] [nvarchar](50) NULL,[Utranscode] [bigint] NULL,[UsedQty] [float] NULL,[DeliveryNote] [bit] NULL,[allocateledger] [nvarchar](75) NULL,[PresetRate] [float] NULL,[N1] [float] NULL,[F1] [nvarchar](75) NULL,[IsDirect] [bit] NULL,[TaxAmount] [float] NULL,[disc2] [float] NULL,[transtype] [nvarchar](30) NULL,[Servicetax] [float] NULL,	[netStockAmount] [float] NULL,[mrp] [float] NULL,[packing] [nvarchar](50) NULL,[slnos] [nvarchar](max) NULL,[Tax2] [float] NULL,[TaxAmount2] [float] NULL,[FreeQty] [float] NULL,[FreeQtyText] [nvarchar](50) NULL,[FreeMQty] [float] NULL,[FreeMQtyText] [nvarchar](50) NULL,[mrprate] [float] NULL,[taxtype] [nvarchar](10) NULL,[DiscountAmount1] [float] NULL,	[DiscountAmount2] [float] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [StockTransferRowItems]([TransCode] [bigint] NULL,[TransDate] [datetime] NULL,[TransDateValue] [bigint] NULL,[QutoNo] [nvarchar](50) NULL,[QutoRef] [nvarchar](50) NULL,[OrderNo] [nvarchar](50) NULL,[OrderRef] [nvarchar](50) NULL,[DNoteno] [nvarchar](50) NULL,[DnoteRef] [nvarchar](50) NULL,[StoreName] [nvarchar](75) NULL,[Currency] [nvarchar](10) NULL,[StockName] [nvarchar](75) NULL,[StockCode] [nvarchar](50) NULL,[stockgroup] [nvarchar](75) NULL,[Barcode] [nvarchar](40) NULL,[StockSize] [nvarchar](25) NULL,[Location] [nvarchar](50) NULL,[description] [nvarchar](150) NULL,[BaseUnit] [nvarchar](75) NULL,[MainUnit] [nvarchar](50) NULL,[SubUnit] [nvarchar](50) NULL,[IsSimpleUnit] [int] NULL,[MainQty] [float] NULL,[TotalQty] [float] NULL,[SubUnitQty] [float] NULL,[QtyText] [nvarchar](50) NULL,[StockRate] [float] NULL,[Expiry] [datetime] NULL,[BatchNo] [nvarchar](50) NULL,[StockType] [int] NULL,[StockDisc] [float] NULL,[RatePer] [nvarchar](50) NULL,[UnitCon] [int] NULL,[CustBarcode] [nvarchar](40) NULL,[sno] [int] NULL,[StockAmount] [float] NULL,[Isdelete] [int] NULL,[QtyValues] [nvarchar](15) NULL,[VoucherName] [nvarchar](50) NULL,[CurrencyCon1] [float] NULL,[Tax] [float] NULL,[NetRate] [float] NULL,[origin] [nvarchar](50) NULL,[HScode] [nvarchar](50) NULL,[Utranscode] [bigint] NULL,[UsedQty] [float] NULL,[DeliveryNote] [bit] NULL,[allocateledger] [nvarchar](75) NULL,[PresetRate] [float] NULL,[N1] [float] NULL,[F1] [nvarchar](75) NULL,[IsDirect] [bit] NULL,[TaxAmount] [float] NULL,[disc2] [float] NULL,[transtype] [nvarchar](30) NULL,[Servicetax] [float] NULL,	[netStockAmount] [float] NULL,[mrp] [float] NULL,[packing] [nvarchar](50) NULL,[slnos] [nvarchar](max) NULL,[Tax2] [float] NULL,[TaxAmount2] [float] NULL,[FreeQty] [float] NULL,[FreeQtyText] [nvarchar](50) NULL,[FreeMQty] [float] NULL,[FreeMQtyText] [nvarchar](50) NULL,[mrprate] [float] NULL,[taxtype] [nvarchar](10) NULL,[DiscountAmount1] [float] NULL,	[DiscountAmount2] [float] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()
                'CREATE TABLE [PrintingDataRowsItems]([TransCode] [bigint] NULL,[TransDate] [datetime] NULL,[TransDateValue] [bigint] NULL,[QutoNo] [nvarchar](50) NULL,[QutoRef] [nvarchar](50) NULL,[OrderNo] [nvarchar](50) NULL,[OrderRef] [nvarchar](50) NULL,[DNoteno] [nvarchar](50) NULL,[DnoteRef] [nvarchar](50) NULL,[StoreName] [nvarchar](75) NULL,[Currency] [nvarchar](10) NULL,[StockName] [nvarchar](75) NULL,[StockCode] [nvarchar](50) NULL,[stockgroup] [nvarchar](75) NULL,[Barcode] [nvarchar](18) NULL,[StockSize] [nvarchar](25) NULL,[Location] [nvarchar](50) NULL,[description] [nvarchar](150) NULL,[BaseUnit] [nvarchar](75) NULL,[MainUnit] [nvarchar](50) NULL,[SubUnit] [nvarchar](50) NULL,[IsSimpleUnit] [int] NULL,[MainQty] [float] NULL,[TotalQty] [float] NULL,[SubUnitQty] [float] NULL,[QtyText] [nvarchar](50) NULL,[StockRate] [float] NULL,[Expiry] [datetime] NULL,[BatchNo] [nvarchar](50) NULL,[StockType] [int] NULL,[StockDisc] [float] NULL,[RatePer] [nvarchar](50) NULL,[UnitCon] [int] NULL,[CustBarcode] [nvarchar](18) NULL,[sno] [int] NULL,[StockAmount] [float] NULL,[Isdelete] [int] NULL,[QtyValues] [nvarchar](15) NULL,[VoucherName] [nvarchar](50) NULL,[CurrencyCon1] [float] NULL,[Tax] [float] NULL,[NetRate] [float] NULL,[origin] [nvarchar](50) NULL,[HScode] [nvarchar](50) NULL,[Utranscode] [bigint] NULL,[UsedQty] [float] NULL,[DeliveryNote] [bit] NULL,[allocateledger] [nvarchar](75) NULL,[PresetRate] [float] NULL,[N1] [float] NULL,[F1] [nvarchar](75) NULL,[IsDirect] [bit] NULL,[TaxAmount] [float] NULL,[disc2] [float] NULL,[transtype] [nvarchar](10) NULL,[Servicetax] [float] NULL,[netStockAmount] [float] NULL,[mrp] [float] NULL,[packing] [nvarchar](50) NULL,[slnos] [nvarchar](max) NULL,[Tax2] [float] NULL,[TaxAmount2] [float] NULL,[FreeQty] [float] NULL,[FreeQtyText] [nvarchar](50) NULL,[FreeMQty] [float] NULL,[FreeMQtyText] [nvarchar](50) NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
                SQLFcmd.CommandText = "CREATE TABLE [PrintingDataRowsItems]([TransCode] [bigint] NULL,[TransDate] [datetime] NULL,[TransDateValue] [bigint] NULL,[QutoNo] [nvarchar](50) NULL,[QutoRef] [nvarchar](50) NULL,[OrderNo] [nvarchar](50) NULL,[OrderRef] [nvarchar](50) NULL,[DNoteno] [nvarchar](50) NULL,[DnoteRef] [nvarchar](50) NULL,[StoreName] [nvarchar](75) NULL,[Currency] [nvarchar](10) NULL,[StockName] [nvarchar](75) NULL,[StockCode] [nvarchar](50) NULL,[stockgroup] [nvarchar](75) NULL,[Barcode] [nvarchar](40) NULL,[StockSize] [nvarchar](25) NULL,[Location] [nvarchar](50) NULL,[description] [nvarchar](150) NULL,[BaseUnit] [nvarchar](75) NULL,[MainUnit] [nvarchar](50) NULL,[SubUnit] [nvarchar](50) NULL,[IsSimpleUnit] [int] NULL,[MainQty] [float] NULL,[TotalQty] [float] NULL,[SubUnitQty] [float] NULL,[QtyText] [nvarchar](50) NULL,[StockRate] [float] NULL,[Expiry] [datetime] NULL,[BatchNo] [nvarchar](50) NULL,[StockType] [int] NULL,[StockDisc] [float] NULL,[RatePer] [nvarchar](50) NULL,[UnitCon] [int] NULL,[CustBarcode] [nvarchar](40) NULL,[sno] [int] NULL,[StockAmount] [float] NULL,[Isdelete] [int] NULL,[QtyValues] [nvarchar](15) NULL,[VoucherName] [nvarchar](50) NULL,[CurrencyCon1] [float] NULL,[Tax] [float] NULL,[NetRate] [float] NULL,[origin] [nvarchar](50) NULL,[HScode] [nvarchar](50) NULL,[Utranscode] [bigint] NULL,[UsedQty] [float] NULL,[DeliveryNote] [bit] NULL,[allocateledger] [nvarchar](75) NULL,[PresetRate] [float] NULL,[N1] [float] NULL,[F1] [nvarchar](75) NULL,[IsDirect] [bit] NULL,[TaxAmount] [float] NULL,[disc2] [float] NULL,[transtype] [nvarchar](10) NULL,[Servicetax] [float] NULL,[netStockAmount] [float] NULL,[mrp] [float] NULL,[packing] [nvarchar](50) NULL,[slnos] [nvarchar](max) NULL,[Tax2] [float] NULL,[TaxAmount2] [float] NULL,[FreeQty] [float] NULL,[FreeQtyText] [nvarchar](50) NULL,[FreeMQty] [float] NULL,[FreeMQtyText] [nvarchar](50) NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                'INSERT VALUES INTO TABLES

                'DEFAULT VALUES FOR TABLES

                SQLFcmd.CommandText = "CREATE TABLE [LockTrans]([TransCode] [bigint] NULL,[UserName] [nvarchar](50) NULL,[SystemName] [nvarchar](50) NULL,[Details] [nvarchar](250) NULL,[TransDate] [nvarchar](50) NOT NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [Request]([ReqNo] [bigint] NULL,[ReqSystemName] [nvarchar](75) NULL,[Status] [char](1) NULL,[UserName] [nvarchar](50) NULL,[SystemName] [nvarchar](75) NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [EmpGratuityMethods]([Method] [nvarchar](70) NULL,[Years] [int] NULL,[Price] [float] NULL,[MethodValue] [int] NULL) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [dbo].[PaymentMethodDetails] (	[ID] [bigint] IDENTITY(1,1) NOT NULL,	[Transcode] [bigint] NULL,	[Ttype] [nvarchar](50) NULL,	[Amount] [float] NULL, CONSTRAINT [PK_PaymentMethodDetails] PRIMARY KEY CLUSTERED (	[ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                If IsEmptyDatabase = False Then

                    Dim TBLSTR As String = "SELECT * FROM INFORMATION_SCHEMA.tables"
                    Dim cnn As SqlConnection
                    cnn = New SqlConnection(ConnectionStringFromFile & " Initial Catalog=" & NewCompanyDBName & ";")
                    cnn.Open()
                    Dim da As SqlDataAdapter = New SqlDataAdapter(TBLSTR, cnn)
                    Dim ds As New DataSet()
                    da.Fill(ds)
                    For Each row As DataRow In ds.Tables(0).Rows
                        Try
                            
                            If IO.File.Exists(Application.StartupPath & "\DbScripts\" & row.Item("TABLE_NAME") & ".xml") = True Then
                                Dim ids As New DataSet
                                Dim dscmd As New SqlDataAdapter("select * from " & row.Item("TABLE_NAME"), cnn)
                                dscmd.Fill(ids, row.Item("TABLE_NAME"))
                                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(dscmd)
                                ids.ReadXml(Application.StartupPath & "\DbScripts\" & row.Item("TABLE_NAME") & ".xml")
                                dscmd.Update(ids, row.Item("TABLE_NAME"))
                            End If

                            

                        Catch ex As Exception

                        End Try
                    Next row
                    da.Dispose()
                    ds.Dispose()
                    cnn.Close()
                    cnn.Dispose()

                    SQLFcmd.CommandText = "USE " & NewCompanyDBName
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [Categoriesgroups] ([StockCategoryName],[StockCategoryNameTemp],[groupRoot],[grouplevel])  VALUES ('*Primary','*Primary','*Primary',1) "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [DepartmentGroups]([DepName],[DepNameTemp],[groupRoot],[grouplevel])   VALUES ('*Primary','*Primary','*Primary',1) "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [settings]([SharedFolderName],[IsBatchExpiry],[IsBillWise],[IsAutoPrinting],[IsAutoBackup],[IsAllowCashBankinJournal],[IsCustomBarcode],[IsAllowZeroValueStock],[IsAllowNagetiveStock],[IsFixedDate],[IsNewInvoiceOnSave],[IsAllowDuplicateRef],[IsAllowAllRef],[IsAllowPriceField] ,[F1] ,[F2] ,[F3] ,[F4] ,[F5] ,[F6] ,[F7],[IsAllowSalesOrders],[IsAllowPurchaseOrders],[IsAllowMemos],[IsAllowCurrency],[IsAllowDebitNote],[IsAllowCreditNote],[IsAllowChequePrinting],[IsRestartInvoiceNo],[IsAllowDeliveryNote],[IsAllowGReceiptNote],[CostingMethod],[IsAllowChating],[IsLoadDashBoard],[isAllowMultiPriceLevels],[IsAllowPDC],[IsAllowMrngEvngShifts],[IsSingleEntryMode],[AllowNarrationinvouchers],[IsallowCostingforInvoice],[IsMultiTaxRates],[SalesPricewithTax],[StockPricewithTax],[IsAllowEmptyBatchNo],[IsAllowMultiSalesTax],[IsAllowMultiPurchaseTax],[customPrint],[ZerotaxonPurchase],DefPaymentMethodInSales,DefPaymentMethodinPurchase )     VALUES ('','False','True','False','False','False','True','True','True','False','False','True','True','True','False','False','False','False','False','False','False','True','True','True','True','True','True','True','True','True','True','True','True','True','True','True','True','False','True','False','False','False','False','False','False','False','False','False','Credit','Credit') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()



                    SQLFcmd.CommandText = "INSERT INTO [StockGroups] ([StockGroupName],[StockGroupNameTemp],[groupRoot],[grouplevel]) VALUES ('*Primary','*Primary','*Primary',1) "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [assetgroups] ([AssetGroupName],[AssetGroupNameTemp],[groupRoot],[grouplevel]) VALUES ('*Primary','*Primary','*Primary',1) "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [CostCenters] ([StockGroupName],[StockGroupNameTemp],[groupRoot],[grouplevel]) VALUES ('*Primary','*Primary','*Primary',1) "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [Godwons] ([GodownName],[GodownNameTemp],[IsDeleted]) VALUES ('MainLocation','MainLocation',0) "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()



                 


                    SQLFcmd.CommandText = "INSERT INTO [IDsettings] ([salespersonsID],[EmployeeID],[EmployeePerID],[AreaID],[TransCode],[BarCodeEna8],[Barcode128],[ID],[supid],[custid],[stockcode],[AccountCode],[LockTransCode],[logfileid],[BillTranscode],[UserTransCode],[AssetID] ,[BudgetID]) VALUES (1,1,1,1,1,1000,1000,1,1,1,1,1,1,1,1,1,1,1) "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [StockLocations] ([locationname],[locationtemp],[Isvisible],[IsDefault],[IsDelete],[ADDRESS],[CITY],[contactno],[contactperson],[email]) VALUES ('MainLocation','MainLocation',1,1,0,'','','','','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    'DEFAULT INVOICE VALUES

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SI','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SO','MainLocation') "

                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SQ','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SD','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SR','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SV','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SRV','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PI','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'PO','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'PQ','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'PG','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'PR','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'PV','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'PVR','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'CON','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'PAY','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'REC','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'JOUR','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'POS','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'PAY','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'SJ','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'F8','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'F8B','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'F8D','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'SRF8','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'SRF8B','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'SRF8D','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'CashSales','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'CreditSales','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'CashPurchase','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,0,0,0,0,0,'CreditPurchase','MainLocation') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [InvoiceDisplaySettings]([ShowTax],[ShowNetRate],[ShowItemName],[ShowItemCode],[ShowItemMoreInfo],[ShowDiscount],[ShowAccount],[ShowRatePer],[ShowNarration],[ShowCurrentBalance],[isallowdisc2])     VALUES ('False','False','True','True','True','True','True','True','True','True','False')"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()



                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('','cash','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()
                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('','sales','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()
                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('','salesret','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()
                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('','purch','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()
                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('','purchret','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()
                    ' sales discount ledger (indirect expenses)
                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('Cd Dr','cddr','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    'for purchase discount ledger (indirect incomes)
                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('Cd Cr','cdcr','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    'for rounding ledger account
                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('Round Off','round','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    'for commision account ledger account
                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('Commission A/c','comm','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('cash','pos','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('','profit','') "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    'cheque printing values
                    SQLFcmd.CommandText = "INSERT INTO [chequePrintingSettings] ([PrinterName],[schemename],[Width],[Height],[IsLandScape],[fleft],[fright],[ftop],[fbuttom],[multi],[showsubtotals],[IsActive],[PaperName],[LeftLogoIsOn],[RightLogoIson],[Leftlogoleft],[Leftlogotop],[Leftlogowidth],[Leftlogoheight],[Rightlogoleft],[Rightlogotop],[Rightlogowidth],[Rightlogoheight],[leftlogopath],[rightlogopath],[MaxRowsPerPage],[RowHeight],[showpageno],[pagenotop],[pagenoleft],[pageformat],[Watermark])     VALUES ('Microsoft XPS Document Writer ', 'SBI',650,350, 'FALSE',10,10,10,10, 'FALSE', 'TRUE', 'TRUE', 'TRUE', 'FALSE', 'FALSE',0,20,12,60,650,14,80,80,  '', '',31,19, 'FALSE',1100,570,1, '')"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [chequePrintingSchemes]([SchemeName],[VoucherName],[IsActive],[ID])     VALUES ('SBI','SBI',1,1)"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [chequePrintFieldLabels]([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[DatabaseValue],[IsLedgerValue])     VALUES( 'SBI', 'DateLine', '', 'TransDate', 'TRUE',10,500,10,10, 'Microsoft Sans Serif',8,8, 'Black', 'Left',10,550,10,10, 'Arial',10,2, 'Black', 'left', '12-05-2010',1,1, 'Sample Text',0,1,1)"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [DUMMY]([F1],[F2],[F3])     VALUES ('jyo',1,'thi')"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [chequePrintFieldLabels]([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[DatabaseValue],[IsLedgerValue])     VALUES ( 'SBI', 'Pay Name', '', 'LedgerName', 'TRUE',55,27,10,10, 'Microsoft Sans Serif',10,8, 'Black', 'Left',10,10,10,10, 'Arial',10,2, 'Black', 'left', 'Jyothi Suresh',1,1, 'Sample Text',0,1,1)"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [chequePrintFieldLabels]([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[DatabaseValue],[IsLedgerValue])     VALUES (  'SBI', 'Amount', '', 'Amount', 'TRUE',120,500,10,10, 'Microsoft Sans Serif',12,1, 'Black', 'Left',10,10,10,10, 'Arial',10,2, 'Black', 'left', '652554.48',1,1, 'Sample Text',0,1,1)"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [CrReportSettings]([LeftLogoOn],[LeftLogoPath],[RightLogoOn],[RightLogoPath],[HeaderOn],[HeaderPath],[FooterOn],[FooterPath],[PrintPageNos],[PrintCompanyName],[PrintAddress],[PrintTitle])     VALUES('False','','False','','False','','False','','True','True','True','True')"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()


                    SQLFcmd.CommandText = "INSERT INTO [chequePrintFieldLabels]([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[DatabaseValue],[IsLedgerValue])     VALUES ( 'SBI', 'AmountWordsLine1', '', 'AmountLine1', 'TRUE',82,35,900,20, 'Microsoft Sans Serif',11,8, 'Black', 'Left',82,30,200,10, 'Arial',10,2, 'Black', 'left', 'INR : Six Laks and Fifty Two Thousand and Fify Four ',1,1, 'Sample Text',0,1,1)"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    SQLFcmd.CommandText = "INSERT INTO [chequePrintFieldLabels]([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[DatabaseValue],[IsLedgerValue])     VALUES ( 'SBI', 'AmountWordsLine2', '', 'AmountLine2', 'TRUE',117,10,10,10, 'Microsoft Sans Serif',12,8, 'Black', 'Left',110,10,10,10, 'Arial',10,2, 'Black', 'left', 'and fourty eight Paise Only',1,1, 'Sample Text',0,1,1)"
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()

                    
                End If

                SQLFcmd.CommandText = "update PrintingSchemes set SchemeType=1 where id=21 or id=20 or id=22"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [POSSettings] ([ID] [bigint] IDENTITY(1,1) NOT NULL,[NewInvoiceAfterSave] [bit] NULL,[AllowPaymentMethod] [bit] NULL,[PrintInvoiceAfterSave] [bit] NULL,[defPrinterName] [nvarchar](250) NULL,[DirectPrint] [bit] NULL,[NoofCopies] [int] NULL,[AllowPriceAlter] [bit] NULL,[AllowDiscountAlter] [bit] NULL,[AllowNewItem] [bit] NULL,[ZeroTax] [bit] NULL,[osk] [bit] NULL,[DefaultPriceList] [nvarchar](50) NULL,[IsAllowTochangeDate] [bit] NULL,[IsAllowCreditSales] [bit] NULL,[IsAllowMultiCurrency] [bit] NULL,[IsItemsAsGridList] [bit] NULL,[CashLedger] [nvarchar](75) NULL,[CreditCardLedger] [nvarchar](75) NULL,[ChequeLedger] [nvarchar](75) NULL,[GiftCardLedger] [nvarchar](75) NULL, CONSTRAINT [PK_POSSettings] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                If IsEmptyDatabase = False Then
                    SQLFcmd.CommandText = "INSERT INTO [dbo].[POSSettings] ([NewInvoiceAfterSave],[AllowPaymentMethod],[PrintInvoiceAfterSave],[defPrinterName],[DirectPrint],[NoofCopies],[AllowPriceAlter],[AllowDiscountAlter],[AllowNewItem],[ZeroTax],[osk],[DefaultPriceList],IsAllowTochangeDate,IsAllowCreditSales,IsAllowMultiCurrency,IsItemsAsGridList)     VALUES (1,0,1,'',0,1,1,1,1,0,0,'Wholesale',1,0,0,0) "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()
                End If

                

                'DEFAULT COLUMNS VALUES
                SQLFcmd.CommandText = "ALTER TABLE [LedgerBook] ADD  CONSTRAINT [DF_LedgerBook_ClearPDC]  DEFAULT ((1)) FOR [ClearPDC]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "ALTER TABLE [StockInvoiceDetails] ADD  CONSTRAINT [DF_LedgerBook_IsDirect]  DEFAULT (('False')) FOR [IsDirect]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER TABLE [StockInvoiceRowItems] ADD  CONSTRAINT [DF_LedgerBook_IsDirect5]  DEFAULT (('False')) FOR [IsDirect]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "ALTER TABLE [LedgerBook] ADD  CONSTRAINT [DF_LedgerBook_IsPostDated]  DEFAULT ((0)) FOR [IsPostDated]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


              
                '
                

                ' CREATE INDEXES





                SQLFcmd.CommandText = "CREATE CLUSTERED INDEX [AccountGroupsindx] ON [AccountGroups] (	[GroupName] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE CLUSTERED INDEX [AccountGroupsListindx] ON [AccountGroupsList] (	[groupname] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) On [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE CLUSTERED INDEX [Bill2Billindx] ON [Bill2Bill] (	[LedgerName] ASC,	[TransCode] ASC,	[BillTransCode] ASC ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE CLUSTERED INDEX [CompanyLeavesindx] ON [CompanyLeaves] (	[LeaveName] ASC,	[FromDateValue] ASC ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE CLUSTERED INDEX [CostCenterBookindx] ON [CostCenterBook] (	[LedgerName] ASC,	[TransCode] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE CLUSTERED INDEX [couponmasterIndx] ON [couponmaster] (	[Cname] ASC,	[datefrom] ASC,	[dateto] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE NONCLUSTERED INDEX [Dutiesindx] ON [Duties] (	[EmpName] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE CLUSTERED INDEX [Dutysettingsindx] ON [Dutysettings] (	[ShiftName] ASC,	[Timein] ASC,	[ShiftType] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE CLUSTERED INDEX [EmpAttendIndx] ON [EmpAttend] (	[EmpName] ASC,	[Transdatevalue] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE CLUSTERED INDEX [EmployeesIndx] ON [Employees] (	[EmpName] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE CLUSTERED INDEX [EmpSalariesIndx] ON [EmpSalaries] (	[EmpName] ASC,	[FromDate] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE CLUSTERED INDEX [imagesIndx] ON [images] (	[Bcode] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE CLUSTERED INDEX [LeavesIndx] ON [Leaves] (	[LeaveName] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE CLUSTERED INDEX [LedgerBookIndx] ON [LedgerBook] (	[LedgerName] ASC,	[TransCode] ASC,	[TransDateValue] ASC,	[InvoiceType] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE CLUSTERED INDEX [ledgersIndx] ON [ledgers] (	[LedgerName] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE CLUSTERED INDEX [logfileIndx] ON [logfile] (	[StoreName] ASC,	[Transcode] ASC,	[vouchername] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE CLUSTERED INDEX [serialnumbermasterIndx] ON [serialnumbermaster] (	[STOCKCODE] ASC,	[STOCKSIZE] ASC,	[SERIALNUMBER] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE CLUSTERED INDEX [StockBatchIndx] ON [StockBatch] (	[StockCode] ASC,	[StockSize] ASC,	[Location] ASC,	[BatchNo] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE CLUSTERED INDEX [StockDbfIndx] ON [StockDbf] (	[StockCode] ASC,	[Barcode] ASC,	[StockSize] ASC,	[Location] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE CLUSTERED INDEX [StockInvoiceDetailsIndx] ON [StockInvoiceDetails] (	[TransCode] ASC,	[LedgerName] ASC,	[VoucherName] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE CLUSTERED INDEX [StockInvoiceRowItemsIndx] ON [StockInvoiceRowItems] (	[TransCode] ASC,	[StockCode] ASC,	[Location] ASC,	[VoucherName] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE CLUSTERED INDEX [StockJournalDbfIndx] ON [StockJournalDbf] (	[Transcode] ASC,	[LocationFrom] ASC,	[LocationTo] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE CLUSTERED INDEX [StockunitsIndx] ON [Stockunits] (	[UnitName] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE CLUSTERED INDEX [VehicleIndx] ON [Vehicle] (	[VhType] ASC,	[VHID] ASC,	[VHName] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                'REBUILD THE INDEXES
                SQLFcmd.CommandText = " ALTER INDEX [AccountGroupsindx] ON [AccountGroups] REBUILD"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " ALTER INDEX [AccountGroupsListindx] ON [AccountGroupsList] REBUILD"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER INDEX [Bill2Billindx] ON [Bill2Bill] REBUILD "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " ALTER INDEX [CompanyLeavesindx] ON [CompanyLeaves] REBUILD"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " ALTER INDEX [CostCenterBookindx] ON [CostCenterBook] REBUILD"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "ALTER INDEX [couponmasterIndx] ON [couponmaster] REBUILD "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER INDEX [Dutiesindx] ON [Duties] REBUILD "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER INDEX [Dutysettingsindx] ON [Dutysettings] REBUILD "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER INDEX [EmpAttendIndx] ON [EmpAttend] REBUILD "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " ALTER INDEX [EmployeesIndx] ON [Employees] REBUILD"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "ALTER INDEX [EmpSalariesIndx] ON [EmpSalaries] REBUILD "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "ALTER INDEX [imagesIndx] ON [images] REBUILD "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " ALTER INDEX [LeavesIndx] ON [Leaves] REBUILD"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER INDEX [LedgerBookIndx] ON [LedgerBook] REBUILD "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER INDEX [ledgersIndx] ON [ledgers] REBUILD "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " ALTER INDEX [logfileIndx] ON [logfile] REBUILD"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "ALTER INDEX [serialnumbermasterIndx] ON [serialnumbermaster] REBUILD "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "ALTER INDEX [StockBatchIndx] ON [StockBatch] REBUILD "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER INDEX [StockDbfIndx] ON [StockDbf] REBUILD "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER INDEX [StockInvoiceDetailsIndx] ON [StockInvoiceDetails] REBUILD     "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER INDEX [StockInvoiceRowItemsIndx] ON [StockInvoiceRowItems] REBUILD "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " ALTER INDEX [StockJournalDbfIndx] ON [StockJournalDbf] REBUILD"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "ALTER INDEX [StockunitsIndx] ON [Stockunits] REBUILD "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "ALTER INDEX [VehicleIndx] ON [Vehicle] REBUILD "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                'indexe reconzie
                SQLFcmd.CommandText = " ALTER INDEX [AccountGroupsindx] ON [AccountGroups] REORGANIZE"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " ALTER INDEX [AccountGroupsListindx] ON [AccountGroupsList] REORGANIZE"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER INDEX [Bill2Billindx] ON [Bill2Bill] REORGANIZE "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " ALTER INDEX [CompanyLeavesindx] ON [CompanyLeaves] REORGANIZE"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " ALTER INDEX [CostCenterBookindx] ON [CostCenterBook] REORGANIZE"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "ALTER INDEX [couponmasterIndx] ON [couponmaster] REORGANIZE "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER INDEX [Dutiesindx] ON [Duties] REORGANIZE "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER INDEX [Dutysettingsindx] ON [Dutysettings] REORGANIZE "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER INDEX [EmpAttendIndx] ON [EmpAttend] REORGANIZE "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " ALTER INDEX [EmployeesIndx] ON [Employees] REORGANIZE"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "ALTER INDEX [EmpSalariesIndx] ON [EmpSalaries] REORGANIZE "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "ALTER INDEX [imagesIndx] ON [images] REORGANIZE "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " ALTER INDEX [LeavesIndx] ON [Leaves] REORGANIZE"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER INDEX [LedgerBookIndx] ON [LedgerBook] REORGANIZE "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER INDEX [ledgersIndx] ON [ledgers] REORGANIZE "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " ALTER INDEX [logfileIndx] ON [logfile] REORGANIZE"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "ALTER INDEX [serialnumbermasterIndx] ON [serialnumbermaster] REORGANIZE "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "ALTER INDEX [StockBatchIndx] ON [StockBatch] REORGANIZE "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER INDEX [StockDbfIndx] ON [StockDbf] REORGANIZE "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER INDEX [StockInvoiceDetailsIndx] ON [StockInvoiceDetails] REORGANIZE     "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER INDEX [StockInvoiceRowItemsIndx] ON [StockInvoiceRowItems] REORGANIZE "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " ALTER INDEX [StockJournalDbfIndx] ON [StockJournalDbf] REORGANIZE"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "ALTER INDEX [StockunitsIndx] ON [Stockunits] REORGANIZE "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "ALTER INDEX [VehicleIndx] ON [Vehicle] REORGANIZE "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()
                Dim tempstr As String = ""
                tempstr = "CREATE PROCEDURE [dbo].[UpdateBatchStockQty]	@Loc nvarchar(75),@code nvarchar(100),@size nvarchar(75),@batchno nvarchar(50) AS BEGIN 		SET NOCOUNT ON;	declare @totalqty float;	DECLARE @MAINQTY FLOAT;	DECLARE @SUBQTY FLOAT;	DECLARE @TOTALQTYTEXT NVARCHAR(75);	DECLARE @CON float;	declare @mainunitname nvarchar(40);	declare @subunitname nvarchar(40);	declare @t1 bigint;	declare @t2 float;	SELECT @CON=SS.UnitConversion FROM (SELECT UnitConversion FROM STOCKUNITS WHERE UnitName=(select TOP 1 baseunit from stockdbf where StockCode=@code and Location=@loc and StockSize=@size)) AS SS;	SELECT @mainunitname=SS.MainUnitName FROM (SELECT MainUnitName FROM STOCKUNITS WHERE UnitName=(select TOP 1 baseunit from stockdbf where StockCode=@code and Location=@loc and StockSize=@size)) AS SS;	SELECT @subunitname=SS.SubUnitName FROM (SELECT SubUnitName FROM STOCKUNITS WHERE UnitName=(select TOP 1 baseunit from stockdbf where StockCode=@code and Location=@loc and StockSize=@size)) AS SS;	select @totalqty=TT.TOT from (select (select sum(optotalqty) from STOCKBATCH where StockCode=@code and Location=@loc and StockSize=@size AND BATCHNO=@batchno )+isnull(sum(case when VoucherName in ('DP','PG','SR','SJIN') THEN TOTALQTY ELSE -1*TotalQty END),0) AS TOT from stockinvoicerowitems WHERE VoucherName IN ('PG','DP','SJIN','SJOUT','PR','POS','SD','SR') and  StockCode=@code and Location=@loc and StockSize=@size AND BATCHNO=@batchno and  Isdelete=0) AS TT;	IF (@CON=1 )	" _
                    & " BEGIN	 update STOCKBATCH set TotalQty=@totalqty,BaseQty=@totalqty,QtyText=CONVERT(nvarchar(20),@totalqty)+' '+@mainunitname  where StockCode=@code and Location=@loc and StockSize=@size AND BATCHNO=@batchno;	end	else	begin		set @t1=cast(@totalqty as bigint)/cast(@con  as int);	set @t2= cast(@totalqty as bigint) % cast(@con as int);	set @t2=@totalqty -cast(@totalqty as bigint)+ @t2;	update STOCKBATCH set TotalQty=@totalqty,BaseQty=@t1,SubUnitQty=@t2,QtyText=convert(nvarchar(20),@t1)+ ' ' +@mainunitname+' ' + convert(nvarchar(20),@t2)+' ' +@subunitname  where StockCode=@code and Location=@loc and StockSize=@size AND BATCHNO=@batchno ;	end END  "
                SQLFcmd.CommandText = tempstr
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE PROCEDURE [dbo].[UPDATEEMPLOYEESNAMES]	@NEWLEDGERNAME NVARCHAR(120),@OLDLEDGERNAME NVARCHAR(120) AS BEGIN 	SET NOCOUNT ON;       update Users set USERNAME=@NEWLEDGERNAME where USERNAME=@OLDLEDGERNAME    ;    update EmpAttend set EmpName=@NEWLEDGERNAME where empname=@OLDLEDGERNAME   ;        update EmpLeaves set EmpName=@NEWLEDGERNAME where empname=@OLDLEDGERNAME     ;      update EmpSalaries set EmpName=@NEWLEDGERNAME where empname=@OLDLEDGERNAME         ;  update EmployeeAttendence set EmpName=@NEWLEDGERNAME where empname=@OLDLEDGERNAME  ;         update documentissues set EmpName=@NEWLEDGERNAME where EmpName=@OLDLEDGERNAME   ;        update duties set EmpName=@NEWLEDGERNAME where empname=@OLDLEDGERNAME   ;        UPDATE CostCenterNames SET CostName=@NEWLEDGERNAME WHERE CostName=@OLDLEDGERNAME    ;       UPDATE CostCenterBook SET CostCenterName=@NEWLEDGERNAME WHERE CostCenterName=@OLDLEDGERNAME ;          update payrollvoucherRowDetails set EmpName=@NEWLEDGERNAME where empname=@OLDLEDGERNAME    ;       update empsalaryincrements set EmpName=@NEWLEDGERNAME where empname=@OLDLEDGERNAME ; update Appointmentdb set EmpName=@NEWLEDGERNAME where empname=@OLDLEDGERNAME END   "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                tempstr = "CREATE PROCEDURE [dbo].[UPDATELEDGERNAMES] 	@NEWLEDGERNAME NVARCHAR(120),@OLDLEDGERNAME NVARCHAR(120) AS BEGIN 	SET NOCOUNT ON; UPDATE LEDGERBOOK SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME;UPDATE BILL2BILL SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME;UPDATE LEDGERBOOK SET AcLedger=@NEWLEDGERNAME WHERE AcLedger=@OLDLEDGERNAME;UPDATE DefLedgers SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME;UPDATE VoucherAccounts SET AccountName=@NEWLEDGERNAME WHERE AccountName=@OLDLEDGERNAME;UPDATE StockInvoiceDetails SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME;UPDATE StockInvoiceDetails SET PaymentLedger=@NEWLEDGERNAME WHERE PaymentLedger=@OLDLEDGERNAME;UPDATE StockInvoiceDetails SET AccountLedgerName=@NEWLEDGERNAME WHERE AccountLedgerName=@OLDLEDGERNAME;UPDATE StockInvoiceDetails SET allocateledger=@NEWLEDGERNAME WHERE allocateledger=@OLDLEDGERNAME;UPDATE Vehicle SET AcountLedgerName=@NEWLEDGERNAME WHERE AcountLedgerName=@OLDLEDGERNAME;UPDATE paytypes SET ledgername=@NEWLEDGERNAME WHERE ledgername=@OLDLEDGERNAME;UPDATE paytypes SET paymentledger=@NEWLEDGERNAME WHERE paymentledger=@OLDLEDGERNAME; " _
                    & " UPDATE paysliptypes SET ledgername=@NEWLEDGERNAME WHERE ledgername=@OLDLEDGERNAME;UPDATE CostCenterBook SET LedgerName=@NEWLEDGERNAME WHERE LedgerName=@OLDLEDGERNAME;UPDATE Vatclauses SET inputvatledger=@NEWLEDGERNAME WHERE inputvatledger=@OLDLEDGERNAME;UPDATE Vatclauses SET outputvatledger=@NEWLEDGERNAME WHERE outputvatledger=@OLDLEDGERNAME;UPDATE Vatclauses SET PurchaseLedger=@NEWLEDGERNAME WHERE PurchaseLedger=@OLDLEDGERNAME;UPDATE Vatclauses SET DebitNoteLedger=@NEWLEDGERNAME WHERE DebitNoteLedger=@OLDLEDGERNAME;UPDATE Vatclauses SET SalesLedger=@NEWLEDGERNAME WHERE SalesLedger=@OLDLEDGERNAME;UPDATE Vatclauses SET CreditLedger=@NEWLEDGERNAME WHERE CreditLedger=@OLDLEDGERNAME;  UPDATE payrollvoucherLedgers SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME;UPDATE PayRollVoucherPayMaster SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME;UPDATE paysliptypes SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME;UPDATE chequeinfo SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME;UPDATE POSSettings SET CashLedger=@NEWLEDGERNAME WHERE CashLedger=@OLDLEDGERNAME;UPDATE POSSettings SET CreditCardLedger=@NEWLEDGERNAME WHERE CreditCardLedger=@OLDLEDGERNAME;UPDATE POSSettings SET ChequeLedger=@NEWLEDGERNAME WHERE ChequeLedger=@OLDLEDGERNAME;UPDATE POSSettings SET GiftCardLedger=@NEWLEDGERNAME WHERE GiftCardLedger=@OLDLEDGERNAME;UPDATE StockTransferDetails SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME; UPDATE Appointmentdb SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME; END  "
                SQLFcmd.CommandText = tempstr
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE PROCEDURE [dbo].[UPDATESTOCKITEMSNAMES] 	@NEWSTOCKCODE NVARCHAR(120),@NEWSTOCKSIZE NVARCHAR(75),@OLDSTOCKCODE NVARCHAR(120),@OLDSTOCKSIZE NVARCHAR(75),@STOCKNAME NVARCHAR(120) AS BEGIN 		SET NOCOUNT ON;	        UPDATE STOCKDBF SET stockcode=@NEWSTOCKCODE, stocksize=@NEWSTOCKSIZE  where  stockcode=@OLDSTOCKCODE and stocksize=@OLDSTOCKSIZE  ;          UPDATE StockBatch SET stockcode=@NEWSTOCKCODE, stocksize=@NEWSTOCKSIZE  where  stockcode=@OLDSTOCKCODE and stocksize=@OLDSTOCKSIZE       ;     UPDATE StockJournalDbf SET stockcode=@NEWSTOCKCODE, stocksize=@NEWSTOCKSIZE  where  stockcode=@OLDSTOCKCODE and stocksize=@OLDSTOCKSIZE  ;          UPDATE StockInvoiceRowItems SET stockcode=@NEWSTOCKCODE, stocksize=@NEWSTOCKSIZE,STOCKNAME=@STOCKNAME  where  stockcode=@OLDSTOCKCODE and stocksize=@OLDSTOCKSIZE      ;      UPDATE serialnumbermaster SET stockcode=@NEWSTOCKCODE, stocksize=@NEWSTOCKSIZE  where  stockcode=@OLDSTOCKCODE and stocksize=@OLDSTOCKSIZE  ;          UPDATE stockserialnos SET stockcode=@NEWSTOCKCODE, stocksize=@NEWSTOCKSIZE  where  stockcode=@OLDSTOCKCODE and stocksize=@OLDSTOCKSIZE;           UPDATE StockTransferRowItems SET stockcode=@NEWSTOCKCODE, stocksize=@NEWSTOCKSIZE,STOCKNAME=@STOCKNAME  where  stockcode=@OLDSTOCKCODE and stocksize=@OLDSTOCKSIZE    END    "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                tempstr = " CREATE PROCEDURE [dbo].[UpdateStockQty] 	@Loc nvarchar(75),@code nvarchar(100),@size nvarchar(75),@batchno nvarchar(50) AS BEGIN			SET NOCOUNT ON;	declare @totalqty float;	DECLARE @MAINQTY FLOAT;	DECLARE @SUBQTY FLOAT;	DECLARE @TOTALQTYTEXT NVARCHAR(75);	DECLARE @CON float;	declare @mainunitname nvarchar(40);	" _
                    & "declare @subunitname nvarchar(40);	declare @t1 bigint;	declare @t2 float;	SELECT @CON=SS.UnitConversion FROM (SELECT UnitConversion FROM STOCKUNITS WHERE UnitName=(select TOP 1 baseunit from stockdbf where StockCode=@code and Location=@loc and StockSize=@size)) AS SS	SELECT @mainunitname=SS.MainUnitName FROM (SELECT MainUnitName FROM STOCKUNITS WHERE UnitName=(select TOP 1 baseunit from stockdbf where StockCode=@code and Location=@loc and StockSize=@size)) AS SS	SELECT @subunitname=SS.SubUnitName FROM (SELECT SubUnitName FROM STOCKUNITS WHERE UnitName=(select TOP 1 baseunit from stockdbf where StockCode=@code and Location=@loc and StockSize=@size)) AS SS	select @totalqty=TT.TOT from (select (select sum(optotalqty) from stockdbf where StockCode=@code and Location=@loc and StockSize=@size )+isnull(sum(case when VoucherName in ('DP','PG','SR','SJIN') THEN TOTALQTY ELSE -1*TotalQty END),0) AS TOT from stockinvoicerowitems WHERE VoucherName IN ('PG','DP','SJIN','SJOUT','PR','POS','SD','SR') and  StockCode=@code and Location=@loc and StockSize=@size and Isdelete=0) AS TT	IF (@CON=1 )	BEGIN	 update StockDbf set TotalQty=@totalqty,BaseQty=@totalqty,QtyText=CONVERT(nvarchar(20),@totalqty)+' '+@mainunitname  where StockCode=@code and Location=@loc and StockSize=@size 	end	else	begin		set @t1=cast(@totalqty as bigint)/cast(@con  as int);	set @t2= cast(@totalqty as bigint) % cast(@con as int);	set @t2=@totalqty -cast(@totalqty as bigint)+ @t2;	update StockDbf set TotalQty=@totalqty,BaseQty=@t1,SubUnitQty=@t2,QtyText=convert(nvarchar(20),@t1)+ ' ' +@mainunitname+' ' + convert(nvarchar(20),@t2)+' ' +@subunitname  where StockCode=@code and Location=@loc and StockSize=@size; 	end	END  "

                SQLFcmd.CommandText = tempstr
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()
                Dim str As String = ""

                str = " CREATE PROCEDURE [dbo].[proInventoryCosting] @Loc nvarchar(75),@code nvarchar(100),@size nvarchar(75),@IsUpdateAll  bit  AS  BEGIN SET NOCOUNT ON; Declare @CostingMethod nvarchar(70); declare @avgtotqty float; DECLARE @OPQTY FLOAT; declare @avgtotvalue float; DECLARE @OPvalue FLOAT; declare @NetRate float;DECLARE @CON float;	DECLARE @CurQty float;	declare @SoldstockQty float;	if (@IsUpdateAll=1) begin UPDATE stockdbf set stockrate=0,baseqty=0,totalqty=0,subunitqty=0,minqty=0 where stockcode=@code and stocksize=@size   AND LOCATION=@Loc and stocktype<>0;  	end select @CostingMethod= t1.costmethod from (select costmethod from stockdbf where stockcode=@code and stocksize=@size ) as t1; " _
                    & " if (len(@CostingMethod)=0) begin Set @CostingMethod='AVERAGE';	 end  if (@CostingMethod='AVERAGE') begin SELECT @OPQTY=T11.TOT FROM (select sum(optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11;	 select @avgtotqty=t2.tot  from  (select sum(case when vouchername='PR' THEN totalqty/unitcon*-1 ELSE totalqty/unitcon END) as tot  from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2; SET @avgtotqty=@avgtotqty+@OPQTY; SELECT @OPvalue=T11.TOT FROM (select sum(opstockrate*optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11;" _
                    & " select @avgtotvalue=t2.tot  from (select sum(case when vouchername='PR' THEN stockrate*totalqty/unitcon*-1 ELSE stockrate*totalqty/unitcon END) as tot from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and  stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2; SET @avgtotvalue=@avgtotvalue+@OPvalue; If (@avgtotqty > 0)  begin set @netrate=@avgtotvalue/@avgtotqty;	 end	 else begin  Set @netrate = 0;  end  if (@netrate is not null)  begin UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;end end if (@CostingMethod='LAST PURCHASED') BEGIN SELECT @netrate =sss1.NETRATE from (SELECT MAX(STOCKRATE) AS NETRATE FROM STOCKINVOICEROWITEMS WHERE (TRANSDATEVALUE=(SELECT MAX(TRANSDATEVALUE) FROM STOCKINVOICEROWITEMS AS TB " _
                    & " WHERE (TB.VOUCHERNAME='PG' OR TB.VOUCHERNAME='DP')  AND TB.STOCKCODE=@code AND TB.STOCKSIZE=@size  AND TB.LOCATION=@Loc))  AND STOCKCODE=@code AND STOCKSIZE=@size  AND LOCATION=@Loc) as sss1 ; if (@netrate is not null) begin	 UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;	 end	 END	 if (@CostingMethod='ZERO COST') BEGIN	 UPDATE stockdbf set stockrate=0 where stockcode=@code and stocksize=@size  AND LOCATION=@Loc;		 END   if (@CostingMethod='FIFO')  begin  SELECT @CON=SS.UnitConversion FROM (SELECT UnitConversion FROM STOCKUNITS WHERE UnitName=(select TOP 1 baseunit from stockdbf where StockCode=@code and Location=@loc and StockSize=@size)) AS SS ; " _
                    & " select @CurQty=ctb1.totalqty from(select totalqty from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as ctb1; select @SoldstockQty=TT.TOT from (select isnull(sum(case when VoucherName in ('SD', 'POS','SJout') THEN TOTALQTY ELSE -1*TotalQty END),0) AS TOT from  stockinvoicerowitems WHERE VoucherName IN ('SD', 'POS','SJout','SR') and  StockCode=@code and Location=@loc and StockSize=@size and Isdelete=0) AS TT; if (@SoldstockQty<=0) begin SELECT @OPQTY=T11.TOT FROM (select sum(optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11; select @avgtotqty=t2.tot  from  (select sum(case when vouchername='PR' THEN totalqty/unitcon*-1 ELSE totalqty/unitcon END) as tot " _
                    & " from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2; SET @avgtotqty=@avgtotqty+@OPQTY;   SELECT @OPvalue=T11.TOT FROM (select sum(opstockrate*optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11; select @avgtotvalue=t2.tot  from (select sum(case when vouchername='PR' THEN stockrate*totalqty/unitcon*-1 ELSE stockrate*totalqty/unitcon END) as tot from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR'))  and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2; SET @avgtotvalue=@avgtotvalue+@OPvalue; If (@avgtotqty > 0) begin	 set @netrate=@avgtotvalue/@avgtotqty; end else begin Set @netrate = 0;	 end   if (@netrate is not null) begin " _
                    & " UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;	  end	 end  else  begin  DECLARE @YourTempTable TABLE (SNo  int,PQTY  float,RATE  float,TSOLD  float ,runtot  float,nocol float) ; INSERT INTO @YourTempTable SELECT  0 AS SNo, OpTotalQty AS PQTY, OpstockRate AS RATE, @SoldstockQty AS TSOLD , 0 as runtot,0 nocol  FROM STOCKDBF where STOCKCODE=@code AND STOCKSIZE=@size  AND  LOCATION=@loc UNION ALL SELECT  ROW_NUMBER() OVER (ORDER BY TransDateValue,transcode) AS [SNo],  (CASE WHEN VOUCHERNAME IN ('PG','SJIn','DP') THEN TotalQty ELSE 0 - TotalQty END) AS PQTY, StockRate AS RATE,@SoldstockQty  AS TSOLD , 0 as runtot,0 nocol   FROM StockInvoiceRowItems AS T1  WHERE  (Isdelete = 0) AND (VoucherName IN ('PG', 'PR','SJin','DP')) AND  stockcode=@code and stocksize=@size   AND LOCATION=@Loc; " _
                    & " DECLARE @RunningTotal float;  SET @RunningTotal = 0.0;  UPDATE @YourTempTable SET @RunningTotal = runtot = @RunningTotal + PQTY, nocol=@RunningTotal-@SoldstockQty FROM @YourTempTable ;  select @CurQty=ctb1.totalqty from (select totalqty from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as ctb1;    if (@CurQty<=0 )   begin   set @CurQty=1;    end   else   begin   set @CurQty=@CurQty/@CON;   end  select @NetRate=fintbl1.ntrate from (select sum(case when t=1 then nocol*rate/@CON else pqty*rate/@CON end)/@CurQty as ntrate from (select  ROW_NUMBER () OVER (ORDER BY SNO) as t, * from @YourTempTable where nocol>0 ) sqery33 ) fintbl1; if (@netrate is not null) begin UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;end end   end   END  "
                SQLFcmd.CommandText = str
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                SQLFcmd.CommandText = "CREATE TABLE [Counters] ([CounterID] [bigint] IDENTITY(1,1) NOT NULL,[CounterName] [nvarchar](50) NULL,	[CounterEmpName] [nvarchar](75) NULL,	[LocationName] [nvarchar](75) NULL, CONSTRAINT [PK_Counters] PRIMARY KEY CLUSTERED (	[CounterID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                If IsEmptyDatabase = False Then
                    SQLFcmd.CommandText = "insert into counters  (countername,locationname)  select 1,locationname from stocklocations "
                    SQLFcmd.CommandType = CommandType.Text
                    SQLFcmd.ExecuteNonQuery()
                End If
               

                SQLFcmd.CommandText = "ALTER TABLE LedgerBook  ADD [CounterID] [int] NULL  "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "UPDATE LedgerBook SET CounterID=1 "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER TABLE Users  ADD [CounterID] [int] NULL "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "UPDATE Users SET CounterID=1 "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " ALTER TABLE StockInvoiceDetails  ADD [CounterID] [int] NULL"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()
                SQLFcmd.CommandText = " ALTER TABLE barcodeprintlabels  ADD [BarcodeRotate] [nvarchar](100) NULL  "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " UPDATE barcodeprintlabels set BarcodeRotate='RotateNoneFlipNone' where DbName='barcodeImage'"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

               
           


                SQLFcmd.CommandText = "ALTER TABLE PrintingSchemes ADD [NoofCopies] [int] NULL"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "UPDATE PrintingSchemes SET NoofCopies=1"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER TABLE PRINTFIELDLABELS ALTER COLUMN  Formulastr NVARCHAR(500)"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                Dim tStr As String = ""
                tStr = "ALTER TABLE StockInvoiceRowItems ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE StockInvoiceRowItems ADD PRIMARY KEY(ID); ALTER TABLE AccountGroups ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE AccountGroups ADD PRIMARY KEY(ID); ALTER TABLE AccountGroupsList ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE AccountGroupsList ADD PRIMARY KEY(ID); ALTER TABLE Bill2Bill ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE Bill2Bill ADD PRIMARY KEY(ID); ALTER TABLE LedgerBook ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE LedgerBook ADD PRIMARY KEY(ID); ALTER TABLE ledgers ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE ledgers ADD PRIMARY KEY(ID); ALTER TABLE StockDbf ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE StockDbf ADD PRIMARY KEY(ID); ALTER TABLE StockBatch ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE StockBatch ADD PRIMARY KEY(ID); ALTER TABLE StockInvoiceDetails ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE StockInvoiceDetails ADD PRIMARY KEY(ID); ALTER TABLE StockTransferRowItems ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE StockTransferRowItems ADD PRIMARY KEY(ID); ALTER TABLE CostCenterBook ADD [ID] [bigint] IDENTITY(1,1) NOT NULL;ALTER TABLE CostCenterBook ADD PRIMARY KEY(ID); ALTER TABLE couponmaster ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE couponmaster ADD PRIMARY KEY(ID); ALTER TABLE EmpAttend ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE EmpAttend ADD PRIMARY KEY(ID); ALTER TABLE images ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE images ADD PRIMARY KEY(ID); ALTER TABLE payrollVoucherMasterData ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE payrollVoucherMasterData ADD PRIMARY KEY(ID); ALTER TABLE payrollvoucherRowDetails ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE payrollvoucherRowDetails ADD PRIMARY KEY(ID); ALTER TABLE serialnumbermaster ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; " _
                    & " ALTER TABLE serialnumbermaster ADD PRIMARY KEY(ID); ALTER TABLE stockserialnos ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE stockserialnos ADD PRIMARY KEY(ID); ALTER TABLE UserLogFile ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE UserLogFile ADD PRIMARY KEY(ID);"

                SQLFcmd.CommandText = tStr
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                SQLFcmd.CommandText = "CREATE TABLE [CounterSalesCash] ([ID] [bigint] IDENTITY(1,1) NOT NULL,[CounterID] [int] NULL,[LocationName] [nvarchar](75) NULL,[TransDate] [datetime] NULL,[TransDateValue] [bigint] NULL,[EmpName] [nvarchar](75) NULL,[Dr] [float] NULL,[Cr] [float] NULL,[Narrations] [nvarchar](250) NULL, CONSTRAINT [PK_CounterSales] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [CounterSalesDNotes]([ID] [bigint] IDENTITY(1,1) NOT NULL,[TransCode] [bigint] NOT NULL,[D1] [int] NULL,[D2] [int] NULL,[D3] [int] NULL,[D4] [int] NULL,[D5] [int] NULL,[D6] [int] NULL,[D7] [int] NULL,[D8] [int] NULL,[D9] [int] NULL) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                tStr = " CREATE PROCEDURE [INSERTNEWSETTINGSLOC] 	@locname NVARCHAR(120) AS BEGIN 	SET NOCOUNT ON; INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SI',@locname);   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SO',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SQ',@locname)  ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SD',@locname)  ;    INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SR',@locname);    INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SV',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SRV',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PI',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PO',@locname) ;  " _
                  & " INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PQ',@locname);    INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PG',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PR',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PV',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PVR',@locname)  ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'CON',@locname)  ;    INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PAY',@locname) ;    INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'REC',@locname) ;    INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'JOUR',@locname) ;    INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'POS',@locname) ; " _
                  & " INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PAY',@locname)  ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SJ',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'F8',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'F8B',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'F8D',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SRF8',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SRF8B',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SRF8D',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'CashSales',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'CreditSales',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'Cashpurchase',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'creditpurchase',@locname) ;  END "

                SQLFcmd.CommandText = tStr
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                tStr = " CREATE PROCEDURE [dbo].[UPDATELOCATIONNAMES] 	@NEWlocationName NVARCHAR(120),@OLDlocationName NVARCHAR(120) AS BEGIN 			SET NOCOUNT ON; update StockDbf set Location=@NEWlocationName where location=@OLDlocationName; update StockJournalDbf set Location=@NEWlocationName where Location=@OLDlocationName; update StockJournalDbf set LocationTo=@NEWlocationName where LocationTo=@OLDlocationName;  update StockJournalDbf set LocationFrom=@NEWlocationName where LocationFrom=@OLDlocationName;  update StockBatch set Location=@NEWlocationName where location=@OLDlocationName;  update Users set LocationName=@NEWlocationName where LocationName=@OLDlocationName; update Users set StoreName=@NEWlocationName where StoreName=@OLDlocationName;  update StockInvoiceRowItems set Location=@NEWlocationName where location=@OLDlocationName;  update logfile set Storename=@NEWlocationName where Storename=@OLDlocationName;  update Bill2Bill set Storename=@NEWlocationName where Storename=@OLDlocationName;  update LedgerBook set Storename=@NEWlocationName where Storename=@OLDlocationName;  update ledgers set Storename=@NEWlocationName where Storename=@OLDlocationName;  update StockDbf set Storename=@NEWlocationName where Storename=@OLDlocationName;  update StockInvoiceDetails set Storename=@NEWlocationName where Storename=@OLDlocationName;  update StockInvoiceRowItems set Storename=@NEWlocationName where Storename=@OLDlocationName; update InvoiceSettings set location=@NEWlocationName where location=@OLDlocationName; update Counters set LocationName=@NEWlocationName where LocationName=@OLDlocationName; update StockTransferRowItems set Location=@NEWlocationName where location=@OLDlocationName;  END "
                SQLFcmd.CommandText = tStr
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                'CHANGES MADE
                SQLFcmd.CommandText = "ALTER TABLE BarcodeFieldSettings  ADD [Rotate] [nvarchar](100) NULL,	[IsComaSep] [bit] NULL "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "UPDATE BarcodeFieldSettings set Rotate='RotateNoneFlipNone' where FiledName='barcode'"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER TABLE barcodeprintsettings  ADD [BarcodeType] [nvarchar](75) NULL"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER TABLE printbarcodeList  ADD [BarcodeImage1] [image] NULL,	[BarcodeImage2] [image] NULL,	[BarcodeImage3] [image] NULL,	[BarcodeImage4] [image] NULL,	[BarcodeImage5] [image] NULL,	[BarcodeImage6] [image] NULL "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER TABLE barcodeprintlabels  ADD 	[IsComaSep] [bit] NULL"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "update barcodeprintlabels set IsComaSep=0"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                
                SQLFcmd.CommandText = "update BarcodeFieldSettings set IsComaSep=0"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

               
              

              

                Dim str2 As String = ""
                str2 = " ALTER PROCEDURE [dbo].[proInventoryCosting] @Loc nvarchar(75),@code nvarchar(100),@size nvarchar(75),@IsUpdateAll  bit  AS  BEGIN SET NOCOUNT ON; Declare @CostingMethod nvarchar(70); declare @avgtotqty float; DECLARE @OPQTY FLOAT; declare @avgtotvalue float; DECLARE @OPvalue FLOAT; declare @NetRate float;DECLARE @CON float;	DECLARE @CurQty float;	declare @SoldstockQty float;	if (@IsUpdateAll=1) begin UPDATE stockdbf set stockrate=0,baseqty=0,totalqty=0,subunitqty=0,minqty=0 where stockcode=@code and stocksize=@size   AND LOCATION=@Loc and stocktype<>0;  	end select @CostingMethod= t1.costmethod from (select costmethod from stockdbf where stockcode=@code and stocksize=@size ) as t1; " _
                    & " if (len(@CostingMethod)=0) begin Set @CostingMethod='AVERAGE';	 end  if (@CostingMethod='AVERAGE') begin SELECT @OPQTY=T11.TOT FROM (select sum(optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11;	 select @avgtotqty=t2.tot  from  (select sum(case when vouchername='PR' THEN totalqty/unitcon*-1 ELSE totalqty/unitcon END) as tot  from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2; SET @avgtotqty=@avgtotqty+@OPQTY; SELECT @OPvalue=T11.TOT FROM (select sum(opstockrate*optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11;" _
                    & " select @avgtotvalue=t2.tot  from (select sum(case when vouchername='PR' THEN stockrate*totalqty/unitcon*-1 ELSE stockrate*totalqty/unitcon END) as tot from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and  stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2; SET @avgtotvalue=@avgtotvalue+@OPvalue; If (@avgtotqty > 0)  begin set @netrate=@avgtotvalue/@avgtotqty;	 end	 else begin  SELECT @netrate=KT.OPSTOCKRATE FROM (SELECT OPSTOCKRATE FROM STOCKDBF  where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS KT;	  end  if (@netrate is not null)  begin UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;end end if (@CostingMethod='LAST PURCHASED') BEGIN SELECT @netrate =sss1.NETRATE from (SELECT MAX(STOCKRATE) AS NETRATE FROM STOCKINVOICEROWITEMS WHERE (TRANSDATEVALUE=(SELECT MAX(TRANSDATEVALUE) FROM STOCKINVOICEROWITEMS AS TB " _
                    & " WHERE (TB.VOUCHERNAME='PG' OR TB.VOUCHERNAME='DP')  AND TB.STOCKCODE=@code AND TB.STOCKSIZE=@size  AND TB.LOCATION=@Loc))  AND STOCKCODE=@code AND STOCKSIZE=@size  AND LOCATION=@Loc) as sss1 ; if (@netrate is not null) begin	 UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;	 end	 END	 if (@CostingMethod='ZERO COST') BEGIN	 UPDATE stockdbf set stockrate=0 where stockcode=@code and stocksize=@size  AND LOCATION=@Loc;		 END   if (@CostingMethod='FIFO')  begin  SELECT @CON=SS.UnitConversion FROM (SELECT UnitConversion FROM STOCKUNITS WHERE UnitName=(select TOP 1 baseunit from stockdbf where StockCode=@code and Location=@loc and StockSize=@size)) AS SS ; " _
                    & " select @CurQty=ctb1.totalqty from(select totalqty from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as ctb1; select @SoldstockQty=TT.TOT from (select isnull(sum(case when VoucherName in ('SD', 'POS','SJout') THEN TOTALQTY ELSE -1*TotalQty END),0) AS TOT from  stockinvoicerowitems WHERE VoucherName IN ('SD', 'POS','SJout','SR') and  StockCode=@code and Location=@loc and StockSize=@size and Isdelete=0) AS TT; if (@SoldstockQty<=0) begin SELECT @OPQTY=T11.TOT FROM (select sum(optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11; select @avgtotqty=t2.tot  from  (select sum(case when vouchername='PR' THEN totalqty/unitcon*-1 ELSE totalqty/unitcon END) as tot " _
                    & " from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2; SET @avgtotqty=@avgtotqty+@OPQTY;   SELECT @OPvalue=T11.TOT FROM (select sum(opstockrate*optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11; select @avgtotvalue=t2.tot  from (select sum(case when vouchername='PR' THEN stockrate*totalqty/unitcon*-1 ELSE stockrate*totalqty/unitcon END) as tot from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR'))  and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2; SET @avgtotvalue=@avgtotvalue+@OPvalue; If (@avgtotqty > 0) begin	 set @netrate=@avgtotvalue/@avgtotqty; end else begin SELECT @netrate=KT.OPSTOCKRATE FROM (SELECT OPSTOCKRATE FROM STOCKDBF  where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS KT;		 end   if (@netrate is not null) begin " _
                    & " UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;	  end	 end  else  begin  DECLARE @YourTempTable TABLE (SNo  int,PQTY  float,RATE  float,TSOLD  float ,runtot  float,nocol float) ; INSERT INTO @YourTempTable SELECT  0 AS SNo, OpTotalQty AS PQTY, OpstockRate AS RATE, @SoldstockQty AS TSOLD , 0 as runtot,0 nocol  FROM STOCKDBF where STOCKCODE=@code AND STOCKSIZE=@size  AND  LOCATION=@loc UNION ALL SELECT  ROW_NUMBER() OVER (ORDER BY TransDateValue,transcode) AS [SNo],  (CASE WHEN VOUCHERNAME IN ('PG','SJIn','DP') THEN TotalQty ELSE 0 - TotalQty END) AS PQTY, StockRate AS RATE,@SoldstockQty  AS TSOLD , 0 as runtot,0 nocol   FROM StockInvoiceRowItems AS T1  WHERE  (Isdelete = 0) AND (VoucherName IN ('PG', 'PR','SJin','DP')) AND  stockcode=@code and stocksize=@size   AND LOCATION=@Loc; " _
                    & " DECLARE @RunningTotal float;  SET @RunningTotal = 0.0;  UPDATE @YourTempTable SET @RunningTotal = runtot = @RunningTotal + PQTY, nocol=@RunningTotal-@SoldstockQty FROM @YourTempTable ;  select @CurQty=ctb1.totalqty from (select totalqty from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as ctb1;    if (@CurQty<=0 )   begin   set @CurQty=1;    end   else   begin   set @CurQty=@CurQty/@CON;   end  select @NetRate=fintbl1.ntrate from (select sum(case when t=1 then nocol*rate/@CON else pqty*rate/@CON end)/@CurQty as ntrate from (select  ROW_NUMBER () OVER (ORDER BY SNO) as t, * from @YourTempTable where nocol>0 ) sqery33 ) fintbl1; if (@netrate is not null) begin UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;end end   end   END  "

                SQLFcmd.CommandText = str2
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [dbo].[Discounts]([ID] [bigint] IDENTITY(1,1) NOT NULL,[DiscountName] [nvarchar](50) NULL,[StockGroup] [nvarchar](75) NULL,[IsDiscPer] [bit] NULL,[DiscountPer] [float] NULL,[DateFrom] [datetime] NULL,[DateFromValue] [bigint] NULL,[DateTo] [datetime] NULL,[DateToValue] [bigint] NULL,[DiscountType] [nvarchar](50) NULL,[isActive] [bit] NULL, CONSTRAINT [PK_Discounts] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "  CREATE TABLE [dbo].[discountDetails](	[ID] [bigint] IDENTITY(1,1) NOT NULL,	[DiscountID] [int] NULL,	[ItemID] [nvarchar](50) NULL,[IsDiscPer] [bit] NULL,	[DiscountPer] [float] NULL, CONSTRAINT [PK_discountDetails] PRIMARY KEY CLUSTERED (	[ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                
                SQLFcmd.CommandText = "create PROCEDURE Pro_DayBrkReport  	@ledgername nvarchar(100), @sdate DATE,@edate date AS BEGIN 		SET NOCOUNT ON;    CREATE TABLE #TEMP4 (DT DATE); ;WITH rs AS ( SELECT @sdate dt 	UNION all SELECT DATEADD(d,1,dt)    FROM rs WHERE dt<@edate ) INSERT INTO #TEMP4 SELECT * FROM RS option (maxrecursion 32767); CREATE TABLE #T (DT DATE,NR NVARCHAR(120),DD FLOAT,CC FLOAT, DDCC FLOAT); INSERT INTO #T SELECT dt,'' as nr,isnull(sum(dr),0) as dd ,isnull(sum(cr),0) as cc ,isnull(sum(dr-cr),0) as ddcc FROM #TEMP4 left join ledgerbook on cast(ledgerbook.transdate as date)=#temp4.dt where (ledgername=@ledgername or ledgername is null) and (isdeleted=0 or isdeleted is null)   group by dt order by dd; declare @opbal float; select @opbal= st.tot from (select sum(dr-cr) as tot from LedgerBook where ledgername=@ledgername and isdeleted=0 and cast(transdate as date)<@sdate ) as st; if (@opbal is null) begin set @opbal=0; end if (@opbal>=0)  begin INSERT INTO #T (DT,NR,DD,CC,DDCC) VALUES (DATEADD(d,-1,@sdate),'Opening Balance',@opbal,0,@opbal); end else begin set @opbal=@opbal*-1; INSERT INTO #T (DT,NR,DD,CC,DDCC) VALUES (DATEADD(d,-1,@sdate),'Opening Balance',0,@opbal,@opbal); end   SELECT * , (SELECT case when SUM(DDCC)>=0 then CONVERT(nvarchar,cast(sum(DDCC) as money),1) +' Dr' else CONVERT(nvarchar,cast(sum(DDCC)*-1 as money),1) +' Cr' end FROM #T T1 WHERE T1.DT<=T2.DT) AS CLOSEBAL FROM #T T2 ORDER BY DT; END "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "create PROCEDURE Pro_DayBrkMonthReport  	@ledgername nvarchar(100), @sdate DATE,@edate date AS BEGIN 		SET NOCOUNT ON;    CREATE TABLE #TEMP4 (DT DATE); ;WITH rs AS ( SELECT @sdate dt 	UNION all SELECT DATEADD(d,1,dt)    FROM rs WHERE dt<@edate ) INSERT INTO #TEMP4 SELECT * FROM RS option (maxrecursion 32767); CREATE TABLE #T (DT DATE,NR NVARCHAR(120),DD FLOAT,CC FLOAT, DDCC FLOAT); INSERT INTO #T SELECT dt,'' as nr,isnull(sum(dr),0) as dd ,isnull(sum(cr),0) as cc ,isnull(sum(dr-cr),0) as ddcc FROM #TEMP4 left join ledgerbook on cast(ledgerbook.transdate as date)=#temp4.dt where (ledgername=@ledgername or ledgername is null) and (isdeleted=0 or isdeleted is null)   group by dt order by dd; declare @opbal float; select @opbal= st.tot from (select sum(dr-cr) as tot from LedgerBook where ledgername=@ledgername and isdeleted=0 and cast(transdate as date)<@sdate ) as st; if (@opbal is null)  begin  set @opbal=0;  end    create table #temp5 (sn int,period  nvarchar(20),dd float,cc float,ddd float); insert into #temp5   SELECT ROW_NUMBER() OVER (ORDER BY year(dt)) as sn, (UPPER(left(DATENAME(MONTH,dt),3)) + '-' + CONVERT(varchar(30),year(dt))) AS [Period],SUM(dd) as dd, sum(cc) as cc,sum(dd-cc) as ddd FROM #T  GROUP BY year(dt),month(dt) ,DATENAME(MONTH,dt) ; 	if (@opbal>0)   begin  INSERT INTO #temp5 (sn,period,dd,cc,ddd ) VALUES (0,'Opening Balance',@opbal,0,@opbal);  end   else if (@opbal<0)   begin   set @opbal=@opbal*-1;  INSERT INTO #temp5 (sn,period,dd,cc,ddd ) VALUES (0,'Opening Balance',0,@opbal,@opbal);  end  	select sn as Sno,Period,dd as DrAmount,cc as CrAmount, (select case when sum(ddd)>=0 then CONVERT(nvarchar,cast(sum(ddd) as money),1)+ ' Dr' else CONVERT(nvarchar,cast(sum(ddd)*-1 as money),1)+' Cr' end  from #temp5 st2 where st2.sn<=st1.sn) as ClosingBalance from #temp5 st1 order by sn; END "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [dbo].[barcodelist]( 	[ID] [bigint] IDENTITY(1,1) NOT NULL,	[Pbarcode] [nvarchar](50) NULL,	[ABarcode] [nvarchar](50) NULL, CONSTRAINT [PK_barcodelist] PRIMARY KEY CLUSTERED (	[ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [dbo].[EmpIds]( [ID] [bigint] IDENTITY(1,1) NOT NULL,[EmpID] [nvarchar](50) NULL,[IDName] [nvarchar](50) NULL,[IDType] [nvarchar](50) NULL,[Expiry] [datetime] NULL,[Photo1] [image] NULL,[Photo2] [image] NULL,[Photo3] [image] NULL,[Description] [nvarchar](150) NULL,[IssuedBy] [nvarchar](75) NULL,[IssueDate] [datetime] NULL , CONSTRAINT [PK_EmpIds] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = " CREATE TABLE [dbo].[Clients]( [ClientID] [int] IDENTITY(1,1) NOT NULL,[ClientName] [nvarchar](150) NULL,[Address] [nvarchar](150) NULL,[ContactNo1] [nvarchar](20) NULL,[ContactNo2] [nvarchar](20) NULL,[EmailID] [nvarchar](150) NULL,[Cotracttype] [nvarchar](50) NULL,[Period] [int] NULL,[ContactPerson] [nvarchar](75) NULL,[Description] [nvarchar](250) NULL, CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED ([ClientID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "CREATE TABLE [dbo].[ClientSites]( 	[ID] [bigint] IDENTITY(1,1) NOT NULL,	[ClientID] [int] NULL,	[SiteID] [int] NULL, CONSTRAINT [PK_ClientSites] PRIMARY KEY CLUSTERED (	[ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()


                SQLFcmd.CommandText = "CREATE TABLE [dbo].[Sites]([SiteID] [int] IDENTITY(1,1) NOT NULL,[SiteName] [nvarchar](75) NULL,[SiteAddress] [nvarchar](150) NULL,[ContactNo1] [nvarchar](20) NULL,[ContactNo2] [nvarchar](20) NULL,[Description] [nvarchar](250) NULL, CONSTRAINT [PK_Sites] PRIMARY KEY CLUSTERED ([SiteID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY]"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [dbo].[Siteschedule]( [id] [bigint] IDENTITY(1,1) NOT NULL,[ClientID] [int] NULL,[EmpID] [nvarchar](50) NULL,[WorkType] [nvarchar](150) NULL,[Rate] [float] NULL,[Food] [bit] NULL,[Accommodation] [bit] NULL,[Transport] [bit] NULL,[StartDate] [datetime] NULL,[EndDate] [datetime] NULL,[StartDateValue] [bigint] NULL,[EndDateValue] [bigint] NULL,[RateType] [nvarchar](50) NULL,	[TotalHours] [float] NULL,Sponsorship [nvarchar](100) NULL, [SiteID] [int] NULL, CONSTRAINT [PK_Siteschedule] PRIMARY KEY CLUSTERED ([id] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " ALTER TABLE [dbo].[ClientSites]  WITH CHECK ADD  CONSTRAINT [FK_Clients_On_ClientSites22] FOREIGN KEY([ClientID]) REFERENCES [dbo].[Clients] ([ClientID]);ALTER TABLE [dbo].[ClientSites] CHECK CONSTRAINT [FK_Clients_On_ClientSites22];ALTER TABLE [dbo].[ClientSites]  WITH CHECK ADD  CONSTRAINT [FK_Sites_On_ClientSites22] FOREIGN KEY([SiteID]) REFERENCES [dbo].[Sites] ([SiteID]);ALTER TABLE [dbo].[ClientSites] CHECK CONSTRAINT [FK_Sites_On_ClientSites22];"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = "ALTER TABLE [dbo].[Siteschedule]  WITH CHECK ADD  CONSTRAINT [FK_Siteschedule_Clients] FOREIGN KEY([ClientID]) REFERENCES [dbo].[Clients] ([ClientID]); ALTER TABLE [dbo].[Siteschedule] CHECK CONSTRAINT [FK_Siteschedule_Clients] ;"
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

             

                SQLFcmd.CommandText = " CREATE FUNCTION [dbo].[fnFindNumbertoWord](@Money AS money)     RETURNS VARCHAR(1024) AS BEGIN     DECLARE @Number as BIGINT     SET @Number = FLOOR(@Money)     DECLARE @Below20 TABLE (ID int identity(0,1), Word varchar(32))     DECLARE @Below100 TABLE (ID int identity(2,1), Word varchar(32))     INSERT @Below20 (Word) VALUES                ( 'Zero'), ('One'),( 'Two' ), ( 'Three'),               ( 'Four' ), ( 'Five' ), ( 'Six' ), ( 'Seven' ),               ( 'Eight'), ( 'Nine'), ( 'Ten'), ( 'Eleven' ),               ( 'Twelve' ), ( 'Thirteen' ), ( 'Fourteen'),               ( 'Fifteen' ), ('Sixteen' ), ( 'Seventeen'),               ('Eighteen' ), ( 'Nineteen' )       INSERT @Below100 VALUES ('Twenty'), ('Thirty'),('Forty'), ('Fifty'),                  ('Sixty'), ('Seventy'), ('Eighty'), ('Ninety') DECLARE @English varchar(1024) = (   SELECT Case      WHEN @Number = 0 THEN  ''     WHEN @Number BETWEEN 1 AND 19      THEN (SELECT Word FROM @Below20 WHERE ID=@Number)    WHEN @Number BETWEEN 20 AND 99    THEN  (SELECT Word FROM @Below100 WHERE ID=@Number/10)+ '-' +        dbo.fnFindNumbertoWord( @Number % 10)    WHEN @Number BETWEEN 100 AND 999      THEN  (dbo.fnFindNumbertoWord( @Number / 100))+' Hundred '+     dbo.fnFindNumbertoWord( @Number % 100)    WHEN @Number BETWEEN 1000 AND 999999      THEN  (dbo.fnFindNumbertoWord( @Number / 1000))+' Thousand '+     dbo.fnFindNumbertoWord( @Number % 1000)     WHEN @Number BETWEEN 1000000 AND 999999999      THEN  (dbo.fnFindNumbertoWord( @Number / 1000000))+' Million '+     dbo.fnFindNumbertoWord( @Number % 1000000)    ELSE ' INVALID INPUT' END) SELECT @English = RTRIM(@English) SELECT @English = RTRIM(LEFT(@English,len(@English)-1))         WHERE RIGHT(@English,1)='-'IF @@NestLevel = 1 BEGIN     SELECT @English = @English+' '     SELECT @English = @English END RETURN (@English) END "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE FUNCTION [dbo].[fnNumberToWord](@Money AS money)     RETURNS VARCHAR(1024) AS BEGIN    DECLARE @Number as BIGINT;	declare @str  as nvarchar(500);	declare @frnstr as nvarchar(20);	declare @endstr as nvarchar(20);	declare @nodec as int;	select @nodec=ss.noofdecimals from (select top 1 noofdecimals from company) as ss;	select @frnstr=ss.CurrencyName from (select top 1 CurrencyName from company) as ss;	select @endstr=ss.DecimalSymbol from (select top 1 DecimalSymbol from company) as ss;    SET @Number = FLOOR(@Money)	set @str=  dbo.fnFindNumbertoWord(@number)+ ' ' +@frnstr;	if @nodec=2 	begin	set @Number=convert(int,100*(@Money - @Number));	end	else	begin	set @Number=convert(int,1000*(@Money - @Number));	end		if @Number>0 	begin	set @str=@str + ' And ' + dbo.fnFindNumbertoWord(@number) + ' ' + @endstr;	end RETURN (@str) END  "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

              


                SQLFcmd.CommandText = " CREATE TABLE [dbo].[EmpAdditionalInfo]([ID] [bigint] IDENTITY(1,1) NOT NULL,[EmpID] [nvarchar](50) NULL,[Additional_name] [nvarchar](50) NULL,[Additional_description] [nvarchar](max) NULL, CONSTRAINT [PK_EmpAdditionalInfo] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                SQLFcmd.CommandText = " CREATE TABLE [dbo].[EmpDocAttachments] ([ID] [bigint] IDENTITY(1,1) NOT NULL,[EmpID] [nvarchar](50) NULL,[DocAttach] [varbinary](max) NULL,[DocAttachFileName] [nvarchar](250) NULL,[DateofAttachment] [datetime] NULL,[DateofModified] [datetime] NULL,[DateofAccess] [datetime] NULL, CONSTRAINT [PK_EmpDocAttachments] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()



                SQLFcmd.CommandText = " CREATE TABLE [dbo].[renewHistory]([ID] [bigint] IDENTITY(1,1) NOT NULL,[RenewDate] [datetime] NULL,[Username] [nvarchar](50) NULL,[RenewID] [bigint] NULL,[DateValue] [bigint] NULL, CONSTRAINT [PK_renewHistory] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] "
                SQLFcmd.CommandType = CommandType.Text
                SQLFcmd.ExecuteNonQuery()

                ConnectionStrinG = ConnectionStringFromFile & " Initial Catalog=" & NewCompanyDBName & ";"

                If IsEmptyDatabase = False Then
                    ReArrangeAccountGroups()
                    ReArrangeStockCategories()
                    ReArrangeStockGroups()
                    ReArrangeCostCenterGroups()
                    ReArrangeAssetTypes()
                End If

                iscreateD = True

            Catch ex As Exception
                MsgBox(ex.Message)
                iscreateD = False
            End Try
            MainSqlConn.Close()

        Catch ex As Exception
            iscreateD = False
        End Try
        Return iscreateD


    End Function

End Module
