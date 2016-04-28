Imports System.Windows.Forms
Imports System.IO

Public Class CreateNewStockItem
    'NOTE: I USED FOR BARCODING FILED NAME AS "CUSTBARCODE" FOR BOTH CUSTOME AND SYSTEM GENERATE BARCODE
    'THE FILED "BARCODE" IS USED FOR STOCK UNIQU CODE TO TRACK THE STOCK ITEM 
    'SO PLEASE DON'T CONFUSE WITH BARCODE AND CUSTBARCODE
    Public OpenfromOutside As Boolean = False
    Dim Photoname As String = ""
    Dim IsOpenForEdit As Boolean = False
    Dim IsAllowChangeUnits As Boolean = True
    Dim LocationsAV As New ComboBox
    Dim StockBarcodeNo As String = ""
    Dim OpenedStockCode As String = ""
    Dim OpenedStockName As String = ""
    Dim OpenedstockSize As String = ""
    Dim OpenedCustomBarcode As String = ""
    Dim OpenedImage As String = ""
    Dim IsPrimaryValueschanged As Boolean = False
    Dim IsImageChanged As Boolean = False
    Dim isdataloading As Boolean = True
    Dim EditMoreItems As Boolean = False
    Dim ItemRowIndexNumber As Long = 0
    Dim MaxItemRows As Long = 0
#Region "Functions"
    Sub New(Optional ByVal stcode As String = "", Optional ByVal stsize As String = "", Optional EditMore As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        If stcode.Length > 0 Then
            OpenedStockCode = stcode
            OpenedstockSize = stsize
            IsOpenForEdit = True
            EditMoreItems = EditMore
            TxtCustomBarcode.Enabled = False
            MaxItemRows = SQLGetNumericFieldValue("select count(*) as tot from stockdbf", "tot")
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub LoadDefaults()
        'NOTE: I USED FOR BARCODING FILED NAME AS "CUSTBARCODE" FOR BOTH CUSTOME AND SYSTEM GENERATE BARCODE
        'THE FILED "BARCODE" IS USED FOR STOCK UNIQU CODE TO TRACK THE STOCK ITEM 
        'SO PLEASE DON'T CONFUSE WITH BARCODE AND CUSTBARCODE
        TxtIdicates.BackColor = Color.Transparent
           'packing
        If MyAppSettings.CostingMethod.Length = 0 Then
            TxtCostingMethod.Text = MyAppSettings.CostingMethod
        Else
            TxtCostingMethod.Text = "AVERAGE"
        End If
        If txtservicetax.Items.Count = 0 Then
            txtservicetax.Items.Add("0")
        End If
        txtservicetax.Text = "0"
        TxtIsDiscountAllowed.Checked = True
        TxtBarCode.Text = GetBarCodeForNewStockItem()
        TxtCustomBarcode.Text = GetCustBarCodeForNewStockItem()
        If TxtStockCode.Text.Length = 0 Then
            TxtStockCode.Text = ""
        End If

        TxtStockName.Text = ""
        TxtStockSize.Text = ""
        TxtBrand.Text = ""
        TxtDrp.Text = "0"
        IsImageChanged = False
        TxtWRp.Text = "0"
        TxtMrp.Text = "0"
        TxtRate.Text = "0"
        TxtDescription.Text = ""
        TxtHSCode.Text = ""
        txtMadeBy.Text = ""
        TxtCSTTax.Text = ""
        TxtMinStockQty.Text = "5"
        TxtStockSize.Text = ""
        TxtStockType.Text = "Stock Item"
        Photoname = ""
        TxtPic.SizeMode = PictureBoxSizeMode.StretchImage
        TxtPic.Image = My.Resources.NOPIC
        TxtTax.Text = "0"
        TxtTax2.Text = "0"
        TxtTotalStock.Text = ""
        IsBatchExpiry.Checked = False
        TxtBatchD.ClearAll()
       
        IsBatchExpiry.Enabled = True
        TabControl1.SelectedTab = TabControl1.TabPages(0)

        'FIND THE LOCATION AND ADDING ROWS FOR EACH LOCATION FOR QTY OR BATCHWISE ALLOCATION
        For i As Integer = 0 To LocationsAV.Items.Count - 1
            TxtBatchD.AddNew(LocationsAV.Items(i).ToString)
        Next
        If IsAllowChangeUnits = True Then
            TxtUnit.Enabled = True
        Else
            TxtUnit.Enabled = False
        End If
        lblQty.Left = 230
      

        IsBatchExpiry.Checked = False
        TxtBatchD.IsExipryBatchValue(False)

        If IsCustomBarCode = True Then
            TxtCustomBarcode.Visible = True
        Else
            TxtCustomBarcode.Visible = False
        End If
        TxtCustomBarcode.MaxLength = BarcodeSettingsVals.BarcodeLength
        TxtCustomBarcode.Focus()
    End Sub


#End Region

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    '
    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        'NOTE: I USED FOR BARCODING FILED NAME AS "CUSTBARCODE" FOR BOTH CUSTOME AND SYSTEM GENERATE BARCODE
        'THE FILED "BARCODE" IS USED FOR STOCK UNIQUE CODE TO TRACK THE STOCK ITEM 
        'SO PLEASE DON'T CONFUSE WITH BARCODE AND CUSTBARCODE
        TxtCustomBarcode.Text = ReplaceZerosToBarcode(TxtCustomBarcode.Text)
        If TxtStockCode.Text.Length < 1 Then
            MsgBox("Please Enter The Stock Code  ", MsgBoxStyle.Information, MySoftwareName)
            TabControl1.SelectedTab = TabControl1.TabPages(0)
            TxtStockCode.Focus()
            Exit Sub
        End If
        If TxtStockName.Text.Length < 1 Then
            MsgBox("Please Enter The Stock Name  ", MsgBoxStyle.Information, MySoftwareName)
            TabControl1.SelectedTab = TabControl1.TabPages(0)
            TxtStockCode.Focus()

            Exit Sub
        End If
        If TxtStockType.Text.Length = 0 Then
            MsgBox("Please Select Stock Type          ", MsgBoxStyle.Information, MySoftwareName)
            TabControl1.SelectedTab = TabControl1.TabPages(0)
            TxtStockType.Focus()
            Exit Sub
        End If
        If TxtUnit.Text.Length = 0 Then
            MsgBox("Please Select the Unit of Stock Item ...", MsgBoxStyle.Information, MySoftwareName)
            TabControl1.SelectedTab = TabControl1.TabPages(0)
            TxtUnit.Focus()
            Exit Sub
        End If
        If TxtCostingMethod.Text.Length = 0 Then
            MsgBox("Please select the Costing Method                    ", MsgBoxStyle.Information)
            TxtCostingMethod.Focus()
            Exit Sub
        End If
        If IsCustomBarCode = True Then
            If IsOpenForEdit = True Then
                If UCase(TxtCustomBarcode.Text) <> UCase(OpenedCustomBarcode) Then
                    If SQLIsFieldExists("select custbarcode from stockdbf where custbarcode=N'" & TxtCustomBarcode.Text & "'") = True Then
                        MsgBox("The Custom Barcode is already exists., Please try with another barcode...... ", MsgBoxStyle.Information)
                        TxtCustomBarcode.Focus()
                        Exit Sub
                    End If
                End If
            Else
                If SQLIsFieldExists("select custbarcode from stockdbf where custbarcode=N'" & TxtCustomBarcode.Text & "'") = True Then
                    MsgBox("The Custom Barcode is already exists., Please try with another barcode...... ", MsgBoxStyle.Information)
                    TxtCustomBarcode.Focus()
                    Exit Sub
                End If
            End If
        End If
      
        SaveAndUpateStockITems()
        TxtCustomBarcode.Focus()
    End Sub
    Public Sub SaveAndUpateStockITems()

        For i As Integer = 0 To TxtBatchD.GetRows - 1
            If TxtBatchD.GetTotalQtyOnRow(i) > 0 Then
                If CDbl(TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.stockrate, i)) = 0 Then
                    MsgBox("Please Enter the Rate of the Item.....", MsgBoxStyle.Information)
                    TabControl1.SelectedTab = TabControl1.TabPages(1)
                    Exit Sub
                End If
            End If
        Next
        If IsBatchExpiry.Checked = True Then
            For i As Integer = 0 To TxtBatchD.GetRows - 1
                If TxtBatchD.IsbatchnoQtyMatch(i) = False Then
                    MsgBox("The Batch Number and Expiry is not matches .....")
                    Exit Sub
                End If
            Next

        End If

        If AppIsItemwithSize = False Then
            TxtStockSize.Text = ""
        End If
        IsPrimaryValueschanged = False
        If IsOpenForEdit = True Then
            If MsgBox("Do you want to save changes  ?                ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            If UCase(TxtStockCode.Text) = UCase(OpenedStockCode) And UCase(TxtStockSize.Text) = UCase(OpenedstockSize) Then
                IsPrimaryValueschanged = False
            Else
                If SQLIsFieldExists("select stockname from stockdbf where stockcode=N'" & TxtStockCode.Text & "' and stocksize=N'" & TxtStockSize.Text & "'") = True Then
                    MsgBox("The Entered Stock Code with size/More information is  already Exists...", MsgBoxStyle.Critical)
                    TabControl1.SelectedTab = TabControl1.TabPages(0)
                    TxtStockCode.Focus()
                End If
                If IsthereanyUsersLogin() > 0 Then
                    MsgBox("Currently some users are logged In, Rename is not recommended..... ", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If Application.OpenForms.Count > 3 Then
                    MsgBox("Please Close all Forms to prevent data.. and try again...", MsgBoxStyle.Information)
                    Exit Sub
                End If
                IsPrimaryValueschanged = True
            End If
            UpdateStockITems()
            TxtStatus.Text = "Changes are Updated ...."
            TxtBarCode.Focus()
            Timer1.Enabled = True
        Else
            If SQLIsFieldExists("SELECT TOP 1 1 from Stockdbf where stockcode=N'" & TxtStockCode.Text & "' and stocksize=N'" & TxtStockSize.Text & "'") = True Then
                MsgBox("The Entered Stock Code with size/More information is  already Exists...", MsgBoxStyle.Critical)
                TabControl1.SelectedTab = TabControl1.TabPages(0)
                TxtStockCode.Focus()
                Exit Sub
            End If

            If TxtTax.Text.Length = 0 Then
                TxtTax.Text = "0"
            End If
            If TxtTax2.Text.Length = 0 Then
                TxtTax2.Text = "0"
            End If

            If MsgBox("Do you want to create a Stock Item ?                   ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            SaveNewStockItems()
            LoadDefaults()
            TabControl1.SelectedIndex = 0
            TxtBarCode.Focus()
        End If
    End Sub

    Public Sub UpdateStockITems()
        If IMSBEGINTRANSACTION() = False Then
            IMSENDTRANSACTION()
            Exit Sub
        End If
        Dim UnitConversionNumber As Double = 1
        UnitConversionNumber = SQLGetNumericFieldValue("select UnitConversion from Stockunits where unitname=N'" & TxtUnit.Text & "'", "UnitConversion")
        Dim SqlStr As String = ""
        SqlStr = "UPDATE [StockDbf]   SET [StockName]=@StockName,[stockgroup] = @stockgroup,[Brand] =@brand ,[Company] = @Company,[description] = @description,[origin] = @origin," _
            & "[HScode] = @HScode,[category] =@category,[ISBatch] = @ISBatch,[BaseUnit] = @BaseUnit,[MainUnit] = @MainUnit,[SubUnit] = @SubUnit,[IsSimpleUnit] = @IsSimpleUnit," _
            & "[StockWRP] = @StockWRP,[StockDRP] = @StockDRP,[IsAdvance] = @IsAdvance,[StockType] = @StockType,[Tax] = @Tax,[UnitCon] = @UnitCon," _
            & "[MinQty] = @MinQty,[costmethod] = @costmethod, Servicetax=@Servicetax,AllowDiscount=@AllowDiscount, mrp=@mrp,packing=@packing,allowserialnumbers=@allowserialnumbers,Tax2=@Tax2, " _
            & " cst=@cst,IsTaxInclude=@IsTaxInclude WHERE stockcode=N'" & OpenedStockCode & "' and stocksize=N'" & OpenedstockSize & "'"
      
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBF.Parameters
            .AddWithValue("StockName", TxtStockName.Text)
            .AddWithValue("stockgroup", TxtStockGroup.Text)
            .AddWithValue("Brand", TxtBrand.Text)
            .AddWithValue("Company", txtMadeBy.Text)
            .AddWithValue("IsTaxInclude", TxtIsInvlusiveTax.Checked)
            .AddWithValue("description", TxtDescription.Text)
            .AddWithValue("origin", txtMadeBy.Text)
            .AddWithValue("HScode", TxtHSCode.Text)
            .AddWithValue("category", TxtCat.Text)
            If IsBatchExpiry.Checked = True Then
                .AddWithValue("ISBatch", 1)
            Else
                .AddWithValue("ISBatch", 0)
            End If

            .AddWithValue("BaseUnit", TxtUnit.Text)
            .AddWithValue("MainUnit", TxtBatchD.GetMainUnitName)
            .AddWithValue("SubUnit", TxtBatchD.GetSubUnitName())
            If TxtBatchD.IsSimpleUnit() = True Then
                .AddWithValue("IsSimpleUnit", 1)
            Else
                .AddWithValue("IsSimpleUnit", 0)
            End If
            .AddWithValue("StockWRP", TxtWRp.Text)
            .AddWithValue("StockDRP", TxtDrp.Text)
            .AddWithValue("IsAdvance", 0)
            .AddWithValue("Tax", TxtTax.Text)
            .AddWithValue("Tax2", TxtTax2.Text)
            If TxtStockType.Text = "Non-Stock" Then
                .AddWithValue("stocktype", 1)
            ElseIf TxtStockType.Text = "Service" Then
                .AddWithValue("stocktype", 2)
            Else
                .AddWithValue("stocktype", 0)
            End If
            .AddWithValue("unitcon", UnitConversionNumber)
            .AddWithValue("MinQty", TxtMinStockQty.Text)
            .AddWithValue("costmethod", TxtCostingMethod.Text)
            .AddWithValue("Servicetax", CDbl(txtservicetax.Text))
            If TxtIsDiscountAllowed.Checked = True Then
                .AddWithValue("AllowDiscount", "True")
            Else
                .AddWithValue("AllowDiscount", "False")
            End If
            .AddWithValue("packing", TxtPacking.Text)
            .AddWithValue("mrp", CDbl(TxtMrp.Text))
            'allowserialnumbers
            If IsAllowSerialNumbers.Checked = True Then
                .AddWithValue("allowserialnumbers", "True")
            Else
                .AddWithValue("allowserialnumbers", "False")
            End If
            If TxtCSTTax.Items.Count > 0 And TxtCSTTax.Text.Length > 0 Then
                .AddWithValue("cst", CDbl(TxtCSTTax.Text))
            Else
                .AddWithValue("cst", 0)
            End If
            'AllowDiscount
            'Servicetax
        End With
        DBF.ExecuteNonQuery()
        DBF = Nothing
        MAINCON.Close()

        CreateStockItemWithLocation(TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.location, 0).ToString)

        If UCase(TxtCustomBarcode.Text) <> UCase(OpenedCustomBarcode) Then
            ExecuteSQLQuery("UPDATE STOCKDBF SET CUSTBARCODE=N'" & TxtCustomBarcode.Text & "' WHERE stockcode=N'" & OpenedStockCode & "' and stocksize=N'" & OpenedstockSize & "'")
            ExecuteSQLQuery("DELETE FROM IMAGES WHERE BCODE=N'" & OpenedCustomBarcode & "'")
            IsImageChanged = True
        End If

        If IsImageChanged = True Then
            If SQLIsFieldExists("SELECT TOP 1 1 from images where BCODE=N'" & TxtCustomBarcode.Text & "'") = False Then
                If Photoname.Length > 0 Then
                    InsertImageIntoDatabase(Photoname, "imagedata", "bcode", "INSERT INTO [images] ([ImageData] ,[Bcode])  VALUES (@IMAGEDATA,@BCODE) ", TxtCustomBarcode.Text, "")
                Else
                    InsertImageIntoDatabase(TxtPic.Image, "imagedata", "bcode", "INSERT INTO [images] ([ImageData] ,[Bcode])  VALUES (@IMAGEDATA,@BCODE) ", TxtCustomBarcode.Text, "")
                End If
            Else
                If Photoname.Length > 0 Then
                    UpdateImageIntoDatabase(Photoname, "imagedata", "UPDATE IMAGES SET IMAGEDATA=@IMAGEDATA WHERE BCODE=N'" & TxtCustomBarcode.Text & "'", "")
                Else
                    UpdateImageIntoDatabase(TxtPic.Image, "imagedata", "UPDATE IMAGES SET IMAGEDATA=@IMAGEDATA WHERE BCODE=N'" & TxtCustomBarcode.Text & "'", "")
                End If
            End If

        End If


        ' 
        For i As Integer = 0 To TxtBatchD.GetRows - 1

            ExecuteSQLQuery("exec UpdateStockQty N'" & TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.location, i) & "',N'" & OpenedStockCode & "',N'" & OpenedstockSize & "',N''")
            ExecuteSQLQuery("EXEC proInventoryCosting N'" & TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.location, i) & "',N'" & OpenedStockCode & "',N'" & OpenedstockSize & "'," & UpdateQuantityForNon_StockAlso)

            If IsBatchExpiry.Checked = True Then
                For bi As Integer = 0 To TxtBatchD.GetBatchNoExpiryRows(i) - 1
                    UpdateBatchOpeningStock(OpenedStockCode, OpenedstockSize, TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.location, i).ToString, TxtBatchD.GetBatchNoExpiryItem(i, "TBATCHNO", bi), TxtBatchD.GetBatchNoExpiryItem(i, "ttotalqty", bi), TxtBatchD.GetBatchNoExpiryItem(i, "tmainunitqty", bi), TxtBatchD.GetBatchNoExpiryItem(i, "tsubunitqty", bi), TxtBatchD.GetBatchNoExpiryItem(i, "TRATE", bi), TxtBatchD.GetBatchNoExpiryItem(i, "TMRP", bi), TxtBatchD.GetBatchNoExpiryItem(i, "TEXPIRY", bi), TxtBatchD.GetBatchNoExpiryItem(i, "TQTYTEXT", bi))
                    ExecuteSQLQuery("EXEC UpdateBatchStockQty N'" & TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.location, i).ToString & "',N'" & OpenedStockCode & "',N'" & OpenedstockSize & "',N'" & TxtBatchD.GetBatchNoExpiryItem(i, "TBATCHNO", bi) & "'")
                Next
            Else
                ExecuteSQLQuery("delete from stockbatch  where stockcode=N'" & OpenedStockCode & "' and stocksize=N'" & OpenedstockSize & "' and location=N'" & TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.location, i) & "'")
            End If
            'FIND THE UNUSED BATCHNOS AND THEN DELETE
            DELETEUNUSEDBatchNos(OpenedStockCode, OpenedstockSize, TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.location, i).ToString)

            'END OF BATCH WISE 

        Next

      

        If IsPrimaryValueschanged = True Then
            ExecuteSQLQuery("EXEC UPDATESTOCKITEMSNAMES N'" & TxtStockCode.Text & "',N'" & TxtStockSize.Text & "',N'" & OpenedStockCode & "',N'" & OpenedstockSize & "',N'" & TxtStockName.Text & "'")
           
        End If
        ExecuteSQLQuery("UPDATE StockInvoiceRowItems SET description=N'" & TxtDescription.Text & "',origin=N'" & txtMadeBy.Text & "',hscode=N'" & TxtHSCode.Text & "',packing=N'" & TxtPacking.Text & "'  where  stockcode=N'" & OpenedStockCode & "' and stocksize=N'" & OpenedstockSize & "'")
    




        IMSENDTRANSACTION()

    End Sub
    Sub DELETEUNUSEDBatchNos(ByVal scode As String, ByVal ssize As String, ByVal sloc As String)
        '
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand

        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = "SELECT * FROM STOCKBATCH where STOCKCODE=N'" & scode & "' AND STOCKSIZE=N'" & ssize & "' AND LOCATION=N'" & sloc & "' and totalqty=0"
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()
                If SQLIsFieldExists("SELECT TOP 1 1 from StockInvoiceRowItems where STOCKCODE=N'" & scode & "' AND STOCKSIZE=N'" & ssize & "' AND LOCATION=N'" & sloc & "' and batchno=N'" & Sreader("batchno").ToString.Trim & "'") = False Then
                    ExecuteSQLQuery("DELETE FROM STOCKBATCH where STOCKCODE=N'" & scode & "' AND STOCKSIZE=N'" & ssize & "' AND LOCATION=N'" & sloc & "' and batchno=N'" & Sreader("batchno").ToString.Trim & "'")
                End If
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
    Sub UpdateBatchOpeningStock(ByVal scode As String, ByVal ssize As String, ByVal sloc As String, ByVal BATCHNO As String, ByVal updatetotalqty As Double, ByVal opbaseqty As Double, ByVal opsubqty As Double, ByVal OPRATE As Double, ByVal OPMRP As Double, ByVal OPEXPIRY As String, ByVal OPQTYTEXT As String)
        If SQLIsFieldExists("SELECT TOP 1 1 from STOCKBATCH where STOCKCODE=N'" & scode & "' AND STOCKSIZE=N'" & ssize & "' AND LOCATION=N'" & sloc & "' AND BATCHNO=N'" & BATCHNO & "'") = True Then
            ExecuteSQLQuery("update STOCKBATCH set opTotalQty=" & updatetotalqty & " ,opBaseQty=" & opbaseqty & ",opstockrate=" & OPRATE & ",OpSubUnitQty=" & opsubqty & "   where STOCKCODE=N'" & scode & "' AND STOCKSIZE=N'" & ssize & "' AND LOCATION=N'" & sloc & "' and batchno=N'" & BATCHNO & "'")
        Else
            Dim batchsqlstr As String = ""
            batchsqlstr = " INSERT INTO [StockBatch] ([StockCode] ,[Barcode] ,[StockSize] ,[Location],[BaseUnit],[MainUnit],[SubUnit],[IsSimpleUnit] ,[BaseQty] ,[TotalQty] ,[SubUnitQty] ,[QtyText] ,[OpBaseQty] , " _
                & " [OpTotalQty] ,[OpSubUnitQty] ,[StockRate] ,[Expiry] ,[BatchNo] ,[OpstockRate] ,[mrp] ,[expiryDateValue])     VALUES " _
                & "(@StockCode ,@Barcode ,@StockSize ,@Location,@BaseUnit,@MainUnit,@SubUnit,@IsSimpleUnit ,@BaseQty ,@TotalQty ,@SubUnitQty ,@QtyText , " _
                & " @OpBaseQty ,@OpTotalQty ,@OpSubUnitQty ,@StockRate ,@Expiry ,@BatchNo ,@OpstockRate ,@mrp ,@expiryDateValue)   "
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF1 As New SqlClient.SqlCommand(batchsqlstr, MAINCON)
            With DBF1.Parameters
                .AddWithValue("StockCode", OpenedStockCode)
                .AddWithValue("Barcode", TxtBarCode.Text)
                .AddWithValue("StockSize", OpenedstockSize)
                .AddWithValue("Location", sloc)
                .AddWithValue("BaseUnit", TxtUnit.Text)
                .AddWithValue("MainUnit", TxtBatchD.GetMainUnitName)
                .AddWithValue("SubUnit", TxtBatchD.GetSubUnitName())
                If TxtBatchD.IsSimpleUnit() = True Then
                    .AddWithValue("IsSimpleUnit", 1)
                Else
                    .AddWithValue("IsSimpleUnit", 0)
                End If
                .AddWithValue("BaseQty", opbaseqty)
                .AddWithValue("TotalQty", updatetotalqty)
                .AddWithValue("SubUnitQty", opsubqty)
                .AddWithValue("QtyText", OPQTYTEXT)
                .AddWithValue("OpBaseQty", opbaseqty)
                .AddWithValue("OpTotalQty", updatetotalqty)
                .AddWithValue("OpSubUnitQty", opsubqty)
                If MyAppSettings.ItemPriceasIncludingVAT = True Then
                    .AddWithValue("StockRate", OPRATE * 100 / (100 + CDbl(TxtTax.Text)))
                    .AddWithValue("OpstockRate", OPRATE)
                Else
                    .AddWithValue("OpstockRate", OPRATE)
                    .AddWithValue("StockRate", OPRATE)
                End If
                .AddWithValue("mrp", OPMRP)
                Dim dt As New DateTimePicker
                dt.Value = CDate(OPEXPIRY)
                .AddWithValue("expiry", dt.Value)
                .AddWithValue("BatchNo", BATCHNO)
                .AddWithValue("expiryDateValue", dt.Value.Date.ToOADate)
            End With
            DBF1.ExecuteNonQuery()
            DBF1 = Nothing
            MAINCON.Close()
        End If


    End Sub
    
    Sub CreateStockItemWithLocation(ByVal locationname As String)

        Dim UnitConversionNumber As Double = 1
        UnitConversionNumber = SQLGetNumericFieldValue("select UnitConversion from Stockunits where unitname=N'" & TxtUnit.Text & "'", "UnitConversion")

        'CREATE A NON-STOCK ITEM
        Dim SqlStr As String = ""
        If IsCustomBarCode = False Then
           
            StockBarcodeNo = GetAndSetCustBarCodeForNewStockItem()
        Else
            StockBarcodeNo = TxtBarCode.Text
        End If

        SqlStr = "INSERT INTO [StockDbf] ([StockName],[StockCodeTemp],[StockCode],[stockgroup],[Barcode],[StockSize],[Brand],[Company],[Location],[description], " _
                    & "[origin],[HScode],[category],[ISBatch],[StoreName],[BaseUnit],[MainUnit],[SubUnit],[IsSimpleUnit],[BaseQty],[TotalQty],[SubUnitQty],[QtyText], " _
                    & "[OpBaseQty],[OpTotalQty],[OpSubUnitQty],[StockRate],[StockWRP],[StockDRP],[IsAdvance],[F1],[F2],[N1],[N2],[StockSizeTemp],[Expiry],[BatchNo],[StockImagePath],[StockType],[Isactive],[Tax],[unitcon],[MinQty],[OpstockRate],[costmethod],[CustBarcode],[AllowDiscount],[Servicetax],[mrp],[packing],[allowserialnumbers],[Tax2],[cst],[IsTaxInclude]) VALUES " _
                    & "(@StockName,@StockCodeTemp,@StockCode,@stockgroup,@Barcode,@StockSize,@Brand,@Company,@Location,@description,@origin,@HScode,@category," _
                    & "@ISBatch,@StoreName,@BaseUnit,@MainUnit,@SubUnit,@IsSimpleUnit,@BaseQty,@TotalQty,@SubUnitQty,@QtyText,@OpBaseQty,@OpTotalQty,@OpSubUnitQty,@StockRate," _
                    & "@StockWRP,@StockDRP,@IsAdvance,@F1,@F2,@N1,@N2,@StockSizeTemp,@Expiry,@BatchNo,@StockImagePath,@StockType,@Isactive,@Tax,@unitcon,@MinQty,@OpstockRate,@costmethod,@CustBarcode,@AllowDiscount,@Servicetax,@mrp,@packing,@allowserialnumbers,@Tax2,@cst,@IsTaxInclude) "


        If TxtStockType.Text <> "Stock Item" Then
            Try
                If SQLIsFieldExists("SELECT TOP 1 1 from Stockdbf where stockcode=N'" & OpenedStockCode & "' and stocksize=N'" & OpenedstockSize & "' and location=N'" & locationname & "'") = False Then

                    TxtBarCode.Text = GetAndSetBarCodeForNewStockItem()
                    MAINCON.ConnectionString = ConnectionStrinG
                    MAINCON.Open()
                    Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
                    With DBF.Parameters
                        .AddWithValue("StockName", TxtStockName.Text)
                        .AddWithValue("StockCodeTemp", Replace(OpenedStockCode, " ", ""))
                        .AddWithValue("StockCode", OpenedStockCode)
                        .AddWithValue("stockgroup", TxtStockGroup.Text)
                        .AddWithValue("Barcode", TxtBarCode.Text)
                        .AddWithValue("StockSize", OpenedstockSize)
                        .AddWithValue("Brand", TxtBrand.Text)
                        .AddWithValue("Company", txtMadeBy.Text)
                        .AddWithValue("Location", locationname)
                        .AddWithValue("description", TxtDescription.Text)
                        .AddWithValue("origin", txtMadeBy.Text)
                        .AddWithValue("HScode", TxtHSCode.Text)
                        .AddWithValue("category", TxtCat.Text)
                        .AddWithValue("ISBatch", 0)
                        .AddWithValue("BaseUnit", TxtUnit.Text)
                        .AddWithValue("MainUnit", TxtBatchD.GetMainUnitName)
                        .AddWithValue("SubUnit", TxtBatchD.GetSubUnitName())
                        If TxtBatchD.IsSimpleUnit() = True Then
                            .AddWithValue("IsSimpleUnit", 1)
                        Else
                            .AddWithValue("IsSimpleUnit", 0)
                        End If
                        .AddWithValue("BaseQty", 0)
                        .AddWithValue("TotalQty", 0)
                        .AddWithValue("SubUnitQty", 0)
                        .AddWithValue("QtyText", "0 " & TxtBatchD.GetMainUnitName)
                        .AddWithValue("OpBaseQty", 0)
                        .AddWithValue("OpTotalQty", 0)
                        .AddWithValue("OpSubUnitQty", 0)
                        .AddWithValue("StoreName", DefStoreName)
                        .AddWithValue("IsTaxInclude", TxtIsInvlusiveTax.Checked)

                        If MyAppSettings.ItemPriceasIncludingVAT = True Then
                            .AddWithValue("StockRate", CDbl(TxtRate.Text) * 100 / (100 + CDbl(TxtTax.Text)))
                            .AddWithValue("OpstockRate", CDbl(TxtRate.Text) * 100 / (100 + CDbl(TxtTax.Text)))
                        Else
                            .AddWithValue("StockRate", TxtRate.Text)
                            .AddWithValue("OpstockRate", TxtRate.Text)
                        End If
                        .AddWithValue("StockWRP", TxtWRp.Text)
                        .AddWithValue("StockDRP", TxtDrp.Text)
                        .AddWithValue("IsAdvance", 0)
                        .AddWithValue("F1", "")
                        .AddWithValue("F2", "")
                        .AddWithValue("N1", 0)
                        .AddWithValue("N2", 0)
                        .AddWithValue("Tax", TxtTax.Text)
                        .AddWithValue("Tax2", TxtTax2.Text)
                        If TxtStockType.Text = "Non-Stock" Then
                            .AddWithValue("stocktype", 1)
                        Else
                            .AddWithValue("stocktype", 2)
                        End If

                        .AddWithValue("Isactive", 1)
                        .AddWithValue("batchno", "")
                        .AddWithValue("expiry", Today.Date)
                        If OpenedstockSize.Length = 0 Then
                            .AddWithValue("StockSizeTemp", OpenedstockSize)
                        Else
                            .AddWithValue("StockSizeTemp", Replace(OpenedstockSize, " ", ""))
                        End If
                        .AddWithValue("StockImagePath", OpenedImage)
                        .AddWithValue("CustBarcode", StockBarcodeNo)
                        .AddWithValue("unitcon", UnitConversionNumber)
                        .AddWithValue("MinQty", TxtMinStockQty.Text)
                        .AddWithValue("costmethod", TxtCostingMethod.Text)
                        .AddWithValue("Servicetax", CDbl(txtservicetax.Text))
                        If TxtIsDiscountAllowed.Checked = True Then
                            .AddWithValue("AllowDiscount", "True")
                        Else
                            .AddWithValue("AllowDiscount", "False")
                        End If
                        'allowserialnumbers
                        If IsAllowSerialNumbers.Checked = True Then
                            .AddWithValue("allowserialnumbers", "True")
                        Else
                            .AddWithValue("allowserialnumbers", "False")
                        End If
                        .AddWithValue("packing", TxtPacking.Text)
                        .AddWithValue("mrp", CDbl(TxtMrp.Text))
                        If TxtCSTTax.Items.Count > 0 And TxtCSTTax.Text.Length > 0 Then
                            .AddWithValue("cst", CDbl(TxtCSTTax.Text))
                        Else
                            .AddWithValue("cst", 0)
                        End If
                    End With
                    DBF.ExecuteNonQuery()
                    DBF = Nothing
                    MAINCON.Close()
                
                End If



            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Else
            For i As Integer = 0 To TxtBatchD.GetRows - 1
                Try
                    If SQLIsFieldExists("SELECT TOP 1 1 from Stockdbf where stockcode=N'" & OpenedStockCode & "' and stocksize=N'" & OpenedstockSize & "' and location=N'" & TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.location, i) & "'") = False Then
                        TxtBarCode.Text = GetAndSetBarCodeForNewStockItem()
                        MAINCON.ConnectionString = ConnectionStrinG
                        MAINCON.Open()
                        Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
                        With DBF.Parameters
                            .AddWithValue("StockName", TxtStockName.Text)
                            .AddWithValue("StockCodeTemp", Replace(OpenedStockCode, " ", ""))
                            .AddWithValue("StockCode", OpenedStockCode)
                            .AddWithValue("stockgroup", TxtStockGroup.Text)
                            'THE FILED BARCODE IS USED FOR ONLY INTERNAL PURPOSE, TO IDENTIFY THE STOCK ITEM ONLY.
                            .AddWithValue("Barcode", TxtBarCode.Text)
                            .AddWithValue("StockSize", OpenedstockSize)
                            .AddWithValue("Brand", TxtBrand.Text)
                            .AddWithValue("Company", txtMadeBy.Text)
                            .AddWithValue("Location", TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.location, i))
                            .AddWithValue("description", TxtDescription.Text)
                            .AddWithValue("origin", txtMadeBy.Text)
                            .AddWithValue("HScode", TxtHSCode.Text)
                            .AddWithValue("category", TxtCat.Text)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("ISBatch", 0)
                            .AddWithValue("BaseUnit", TxtUnit.Text)
                            .AddWithValue("MainUnit", TxtBatchD.GetMainUnitName)
                            .AddWithValue("SubUnit", TxtBatchD.GetSubUnitName())
                            If TxtBatchD.IsSimpleUnit() = True Then
                                .AddWithValue("IsSimpleUnit", 1)
                            Else
                                .AddWithValue("IsSimpleUnit", 0)
                            End If
                            .AddWithValue("BaseQty", TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.qty1, i))
                            .AddWithValue("TotalQty", TxtBatchD.GetTotalQtyOnRow(i))
                            .AddWithValue("SubUnitQty", TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.qty2, i))
                            .AddWithValue("QtyText", TxtBatchD.GetTotalQtyTextOnRow(i))
                            .AddWithValue("OpBaseQty", TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.qty1, i))
                            .AddWithValue("OpTotalQty", TxtBatchD.GetTotalQtyOnRow(i))
                            .AddWithValue("OpSubUnitQty", TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.qty2, i))

                            If MyAppSettings.ItemPriceasIncludingVAT = True Then
                                .AddWithValue("StockRate", CDbl(TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.stockrate, i)) * 100 / (100 + CDbl(TxtTax.Text)))
                                .AddWithValue("OpstockRate", CDbl(TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.stockrate, i)) * 100 / (100 + CDbl(TxtTax.Text)))
                            Else
                                .AddWithValue("StockRate", TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.stockrate, i))
                                .AddWithValue("OpstockRate", TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.stockrate, i))
                            End If


                            .AddWithValue("StockWRP", TxtWRp.Text)
                            .AddWithValue("IsTaxInclude", TxtIsInvlusiveTax.Checked)
                            .AddWithValue("StockDRP", TxtDrp.Text)
                            .AddWithValue("IsAdvance", 0)
                            .AddWithValue("stocktype", 0)
                            .AddWithValue("Isactive", 1)
                            .AddWithValue("F1", "")
                            .AddWithValue("F2", "")
                            .AddWithValue("N1", 0)
                            .AddWithValue("Tax", TxtTax.Text)
                            .AddWithValue("Tax2", TxtTax2.Text)
                            .AddWithValue("expiry", Today.Date)
                            .AddWithValue("N2", 0)

                            If OpenedstockSize.Length = 0 Then
                                .AddWithValue("StockSizeTemp", OpenedstockSize)
                            Else
                                .AddWithValue("StockSizeTemp", Replace(OpenedstockSize, " ", ""))
                            End If
                            .AddWithValue("StockImagePath", OpenedImage)
                            .AddWithValue("BatchNo", "")
                            .AddWithValue("unitcon", UnitConversionNumber)
                            .AddWithValue("CustBarcode", StockBarcodeNo)
                            .AddWithValue("costmethod", TxtCostingMethod.Text)
                            .AddWithValue("MinQty", TxtMinStockQty.Text)
                            .AddWithValue("Servicetax", CDbl(txtservicetax.Text))
                            If TxtIsDiscountAllowed.Checked = True Then
                                .AddWithValue("AllowDiscount", "True")
                            Else
                                .AddWithValue("AllowDiscount", "False")
                            End If
                            If IsAllowSerialNumbers.Checked = True Then
                                .AddWithValue("allowserialnumbers", "True")
                            Else
                                .AddWithValue("allowserialnumbers", "False")
                            End If
                            .AddWithValue("mrp", CDbl(TxtMrp.Text))
                            .AddWithValue("packing", TxtPacking.Text)
                            If TxtCSTTax.Items.Count > 0 And TxtCSTTax.Text.Length > 0 Then
                                .AddWithValue("cst", CDbl(TxtCSTTax.Text))
                            Else
                                .AddWithValue("cst", 0)
                            End If
                        End With
                        DBF.ExecuteNonQuery()
                        DBF = Nothing
                        MAINCON.Close()
                    Else
                        MAINCON.ConnectionString = ConnectionStrinG
                        MAINCON.Open()
                        Dim DBF As New SqlClient.SqlCommand("update stockdbf set OpBaseQty=@OpBaseQty,OpTotalQty=@OpTotalQty,OpSubUnitQty=@OpSubUnitQty,OpstockRate=@OpstockRate where stockcode=N'" & OpenedStockCode & "' and stocksize=N'" & OpenedstockSize & "' and location=N'" & TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.location, i) & "'", MAINCON)
                        With DBF.Parameters

                            .AddWithValue("OpBaseQty", TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.qty1, i))
                            .AddWithValue("OpTotalQty", TxtBatchD.GetTotalQtyOnRow(i))
                            .AddWithValue("OpSubUnitQty", TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.qty2, i))
                            If MyAppSettings.ItemPriceasIncludingVAT = True Then
                                .AddWithValue("OpstockRate", CDbl(TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.stockrate, i)) * 100 / (100 + CDbl(TxtTax.Text)))
                            Else
                                .AddWithValue("OpstockRate", TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.stockrate, i))
                            End If

                        End With
                        DBF.ExecuteNonQuery()
                        DBF = Nothing
                        MAINCON.Close()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next
        End If

    End Sub
    Sub SaveNewStockItems()
       
        Dim UnitConversionNumber As Double = 1
        UnitConversionNumber = SQLGetNumericFieldValue("select UnitConversion from Stockunits where unitname=N'" & TxtUnit.Text & "'", "UnitConversion")
       
        GetAndSetIDCode(EnumIDType.StockCode)
        'CREATE A NON-STOCK ITEM
        Dim SqlStr As String = ""
        Dim StrStockImagePath As String = ""
        StrStockImagePath = StockPhotoPath & "\" & TxtBarCode.Text & ".jpg"
        StockBarcodeNo = GetAndSetCustBarCodeForNewStockItem()
        If IsCustomBarCode = True Then
            StockBarcodeNo = TxtCustomBarcode.Text
        End If
       
        SqlStr = "INSERT INTO [StockDbf] ([StockName],[StockCodeTemp],[StockCode],[stockgroup],[Barcode],[StockSize],[Brand],[Company],[Location],[description], " _
                     & "[origin],[HScode],[category],[ISBatch],[StoreName],[BaseUnit],[MainUnit],[SubUnit],[IsSimpleUnit],[BaseQty],[TotalQty],[SubUnitQty],[QtyText], " _
                     & "[OpBaseQty],[OpTotalQty],[OpSubUnitQty],[StockRate],[StockWRP],[StockDRP],[IsAdvance],[F1],[F2],[N1],[N2],[StockSizeTemp],[Expiry],[BatchNo],[StockImagePath],[StockType],[Isactive],[Tax],[unitcon],[MinQty],[OpstockRate],[costmethod],[CustBarcode],[AllowDiscount],[Servicetax],[mrp],[packing],[allowserialnumbers],[Tax2],[cst],[IsTaxInclude]) VALUES " _
                     & "(@StockName,@StockCodeTemp,@StockCode,@stockgroup,@Barcode,@StockSize,@Brand,@Company,@Location,@description,@origin,@HScode,@category," _
                     & "@ISBatch,@StoreName,@BaseUnit,@MainUnit,@SubUnit,@IsSimpleUnit,@BaseQty,@TotalQty,@SubUnitQty,@QtyText,@OpBaseQty,@OpTotalQty,@OpSubUnitQty,@StockRate," _
                     & "@StockWRP,@StockDRP,@IsAdvance,@F1,@F2,@N1,@N2,@StockSizeTemp,@Expiry,@BatchNo,@StockImagePath,@StockType,@Isactive,@Tax,@unitcon,@MinQty,@OpstockRate,@costmethod,@CustBarcode,@AllowDiscount,@Servicetax,@mrp,@packing,@allowserialnumbers,@Tax2,@cst,@IsTaxInclude) "


        If TxtStockType.Text <> "Stock Item" Then
            Try
               
                TxtBarCode.Text = GetAndSetBarCodeForNewStockItem()
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
                With DBF.Parameters
                    .AddWithValue("StockName", TxtStockName.Text)
                    .AddWithValue("StockCodeTemp", Replace(TxtStockCode.Text, " ", ""))
                    .AddWithValue("StockCode", TxtStockCode.Text)
                    .AddWithValue("stockgroup", TxtStockGroup.Text)
                    .AddWithValue("Barcode", TxtBarCode.Text)
                    .AddWithValue("StockSize", TxtStockSize.Text)
                    .AddWithValue("Brand", TxtBrand.Text)
                    .AddWithValue("Company", txtMadeBy.Text)
                    .AddWithValue("Location", GetDefLocationName)
                    .AddWithValue("description", TxtDescription.Text)
                    .AddWithValue("origin", txtMadeBy.Text)
                    .AddWithValue("HScode", TxtHSCode.Text)
                    .AddWithValue("category", TxtCat.Text)
                    .AddWithValue("ISBatch", 0)
                    .AddWithValue("BaseUnit", TxtUnit.Text)
                    .AddWithValue("MainUnit", TxtBatchD.GetMainUnitName)
                    .AddWithValue("SubUnit", TxtBatchD.GetSubUnitName())
                    If TxtBatchD.IsSimpleUnit() = True Then
                        .AddWithValue("IsSimpleUnit", 1)
                    Else
                        .AddWithValue("IsSimpleUnit", 0)
                    End If
                    .AddWithValue("BaseQty", 0)
                    .AddWithValue("TotalQty", 0)
                    .AddWithValue("SubUnitQty", 0)
                    .AddWithValue("QtyText", "0 " & TxtBatchD.GetMainUnitName)
                    .AddWithValue("OpBaseQty", 0)
                    .AddWithValue("OpTotalQty", 0)
                    .AddWithValue("OpSubUnitQty", 0)
                    .AddWithValue("StoreName", DefStoreName)
                    .AddWithValue("OpstockRate", TxtRate.Text)
                    If MyAppSettings.ItemPriceasIncludingVAT = True Then
                        .AddWithValue("StockRate", CDbl(TxtRate.Text) * 100 / (100 + CDbl(TxtTax.Text)))
                    Else
                        .AddWithValue("StockRate", TxtRate.Text)
                    End If
                    .AddWithValue("IsTaxInclude", TxtIsInvlusiveTax.Checked)
                    .AddWithValue("StockWRP", TxtWRp.Text)
                    .AddWithValue("StockDRP", TxtDrp.Text)
                    .AddWithValue("IsAdvance", 0)
                    .AddWithValue("F1", "")
                    .AddWithValue("F2", "")
                    .AddWithValue("N1", 0)
                    .AddWithValue("N2", 0)
                    .AddWithValue("Tax", TxtTax.Text)
                    .AddWithValue("Tax2", TxtTax2.Text)
                    If TxtStockType.Text = "Non-Stock" Then
                        .AddWithValue("stocktype", 1)
                    Else
                        .AddWithValue("stocktype", 2)
                    End If
                    If IsAllowSerialNumbers.Checked = True Then
                        .AddWithValue("allowserialnumbers", "True")
                    Else
                        .AddWithValue("allowserialnumbers", "False")
                    End If
                    .AddWithValue("Isactive", 1)
                    .AddWithValue("batchno", "")
                    .AddWithValue("expiry", Today.Date)
                    If TxtStockSize.Text.Length = 0 Then
                        .AddWithValue("StockSizeTemp", TxtStockSize.Text)
                    Else
                        .AddWithValue("StockSizeTemp", Replace(TxtStockSize.Text, " ", ""))
                    End If
                    .AddWithValue("StockImagePath", StrStockImagePath)
                    .AddWithValue("CustBarcode", StockBarcodeNo)
                    .AddWithValue("unitcon", UnitConversionNumber)
                    .AddWithValue("MinQty", TxtMinStockQty.Text)
                    .AddWithValue("costmethod", TxtCostingMethod.Text)
                    .AddWithValue("Servicetax", CDbl(txtservicetax.Text))

                    If TxtIsDiscountAllowed.Checked = True Then
                        .AddWithValue("AllowDiscount", "True")
                    Else
                        .AddWithValue("AllowDiscount", "False")
                    End If
                    .AddWithValue("mrp", CDbl(TxtMrp.Text))
                    .AddWithValue("packing", TxtPacking.Text)
                    If TxtCSTTax.Items.Count > 0 And TxtCSTTax.Text.Length > 0 Then
                        .AddWithValue("cst", CDbl(TxtCSTTax.Text))
                    Else
                        .AddWithValue("cst", 0)
                    End If
                End With
                DBF.ExecuteNonQuery()
                DBF = Nothing
                MAINCON.Close()


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'If Photoname.Length > 0 Then
            '    Try
            '        My.Computer.FileSystem.DeleteFile(StrStockImagePath)
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        TxtPic.BackgroundImage.Save(StrStockImagePath)
            '    Catch ex As Exception
            '    End Try
            'End If
        Else

         
            For i As Integer = 0 To TxtBatchD.GetRows - 1
                Try

                    If SQLIsFieldExists("SELECT TOP 1 1 from Stockdbf where stockcode=N'" & TxtStockName.Text & "' and stocksize=N'" & TxtStockSize.Text & "' and location=N'" & TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.location, i) & "'") = False Then

                        TxtBarCode.Text = GetAndSetBarCodeForNewStockItem()
                        MAINCON.ConnectionString = ConnectionStrinG
                        MAINCON.Open()
                        Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
                        With DBF.Parameters
                            .AddWithValue("StockName", TxtStockName.Text)
                            .AddWithValue("StockCodeTemp", Replace(TxtStockCode.Text, " ", ""))
                            .AddWithValue("StockCode", TxtStockCode.Text)
                            .AddWithValue("stockgroup", TxtStockGroup.Text)
                            'THE FILED BARCODE IS USED FOR ONLY INTERNAL PURPOSE, TO IDENTIFY THE STOCK ITEM ONLY.
                            .AddWithValue("Barcode", TxtBarCode.Text)
                            .AddWithValue("StockSize", TxtStockSize.Text)
                            .AddWithValue("Brand", TxtBrand.Text)
                            .AddWithValue("Company", txtMadeBy.Text)
                            .AddWithValue("Location", TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.location, i))
                            .AddWithValue("description", TxtDescription.Text)
                            .AddWithValue("origin", txtMadeBy.Text)
                            .AddWithValue("HScode", TxtHSCode.Text)
                            .AddWithValue("category", TxtCat.Text)
                            .AddWithValue("StoreName", DefStoreName)
                            If IsBatchExpiry.Checked = True Then
                                .AddWithValue("ISBatch", 1)
                            Else
                                .AddWithValue("ISBatch", 0)
                            End If

                            .AddWithValue("BaseUnit", TxtUnit.Text)
                            .AddWithValue("MainUnit", TxtBatchD.GetMainUnitName)
                            .AddWithValue("SubUnit", TxtBatchD.GetSubUnitName())
                            If TxtBatchD.IsSimpleUnit() = True Then
                                .AddWithValue("IsSimpleUnit", 1)
                            Else
                                .AddWithValue("IsSimpleUnit", 0)
                            End If
                            .AddWithValue("BaseQty", TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.qty1, i))
                            .AddWithValue("TotalQty", TxtBatchD.GetTotalQtyOnRow(i))
                            .AddWithValue("SubUnitQty", TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.qty2, i))
                            .AddWithValue("QtyText", TxtBatchD.GetTotalQtyTextOnRow(i))
                            .AddWithValue("OpBaseQty", TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.qty1, i))
                            .AddWithValue("OpTotalQty", TxtBatchD.GetTotalQtyOnRow(i))
                            .AddWithValue("OpSubUnitQty", TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.qty2, i))


                            If MyAppSettings.ItemPriceasIncludingVAT = True Then
                                .AddWithValue("StockRate", CDbl(TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.stockrate, i)) * 100 / (100 + CDbl(TxtTax.Text)))
                                .AddWithValue("OpstockRate", CDbl(TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.stockrate, i)) * 100 / (100 + CDbl(TxtTax.Text)))
                            Else
                                .AddWithValue("StockRate", TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.stockrate, i))
                                .AddWithValue("OpstockRate", TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.stockrate, i))
                            End If

                            .AddWithValue("StockWRP", TxtWRp.Text)

                            .AddWithValue("StockDRP", TxtDrp.Text)
                            .AddWithValue("IsAdvance", 0)
                            .AddWithValue("stocktype", 0)
                            .AddWithValue("Isactive", 1)
                            .AddWithValue("F1", "")
                            .AddWithValue("F2", "")
                            .AddWithValue("N1", 0)
                            .AddWithValue("Tax", TxtTax.Text)
                            .AddWithValue("Tax2", TxtTax2.Text)
                            .AddWithValue("expiry", Today.Date)
                            .AddWithValue("N2", 0)
                            .AddWithValue("IsTaxInclude", TxtIsInvlusiveTax.Checked)
                            If TxtStockSize.Text.Length = 0 Then
                                .AddWithValue("StockSizeTemp", TxtStockSize.Text)
                            Else
                                .AddWithValue("StockSizeTemp", Replace(TxtStockSize.Text, " ", ""))
                            End If
                            If IsAllowSerialNumbers.Checked = True Then
                                .AddWithValue("allowserialnumbers", "True")
                            Else
                                .AddWithValue("allowserialnumbers", "False")
                            End If
                            .AddWithValue("StockImagePath", StrStockImagePath)
                            .AddWithValue("BatchNo", "")
                            .AddWithValue("unitcon", UnitConversionNumber)
                            .AddWithValue("CustBarcode", StockBarcodeNo)
                            .AddWithValue("costmethod", TxtCostingMethod.Text)
                            .AddWithValue("MinQty", TxtMinStockQty.Text)
                            .AddWithValue("Servicetax", CDbl(txtservicetax.Text))
                            If TxtIsDiscountAllowed.Checked = True Then
                                .AddWithValue("AllowDiscount", "True")
                            Else
                                .AddWithValue("AllowDiscount", "False")
                            End If
                            .AddWithValue("mrp", CDbl(TxtMrp.Text))
                            .AddWithValue("packing", TxtPacking.Text)
                            If TxtCSTTax.Items.Count > 0 And TxtCSTTax.Text.Length > 0 Then
                                .AddWithValue("cst", CDbl(TxtCSTTax.Text))
                            Else
                                .AddWithValue("cst", 0)
                            End If
                        End With
                        DBF.ExecuteNonQuery()
                        DBF = Nothing

                        'SAVE BATCHNUMBER  LOCATION WISE, FOR NEW STOCK ITEMS
                        If TxtBatchD.GetTotalQtyOnRow(i) > 0 Then
                            Dim batchsqlstr As String = ""
                            batchsqlstr = " INSERT INTO [StockBatch] ([StockCode] ,[Barcode] ,[StockSize] ,[Location],[BaseUnit],[MainUnit],[SubUnit],[IsSimpleUnit] ,[BaseQty] ,[TotalQty] ,[SubUnitQty] ,[QtyText] ,[OpBaseQty] , " _
                                & " [OpTotalQty] ,[OpSubUnitQty] ,[StockRate] ,[Expiry] ,[BatchNo] ,[OpstockRate] ,[mrp] ,[expiryDateValue])     VALUES " _
                                & "(@StockCode ,@Barcode ,@StockSize ,@Location,@BaseUnit,@MainUnit,@SubUnit,@IsSimpleUnit ,@BaseQty ,@TotalQty ,@SubUnitQty ,@QtyText , " _
                                & " @OpBaseQty ,@OpTotalQty ,@OpSubUnitQty ,@StockRate ,@Expiry ,@BatchNo ,@OpstockRate ,@mrp ,@expiryDateValue)   "

                            For k As Integer = 0 To TxtBatchD.GetBatchNoExpiryRows(i) - 1
                                Dim DBF1 As New SqlClient.SqlCommand(batchsqlstr, MAINCON)
                                With DBF1.Parameters
                                    .AddWithValue("StockCode", TxtStockCode.Text)
                                    .AddWithValue("Barcode", TxtBarCode.Text)
                                    .AddWithValue("StockSize", TxtStockSize.Text)
                                    .AddWithValue("Location", TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.location, i))
                                    .AddWithValue("BaseUnit", TxtUnit.Text)
                                    .AddWithValue("MainUnit", TxtBatchD.GetMainUnitName)
                                    .AddWithValue("SubUnit", TxtBatchD.GetSubUnitName())
                                    If TxtBatchD.IsSimpleUnit() = True Then
                                        .AddWithValue("IsSimpleUnit", 1)
                                    Else
                                        .AddWithValue("IsSimpleUnit", 0)
                                    End If
                                    .AddWithValue("BaseQty", CDbl(TxtBatchD.GetBatchNoExpiryItem(i, "tmainunitqty", k)))
                                    .AddWithValue("TotalQty", CDbl(TxtBatchD.GetBatchNoExpiryItem(i, "ttotalqty", k)))
                                    .AddWithValue("SubUnitQty", CDbl(TxtBatchD.GetBatchNoExpiryItem(i, "tsubunitqty", k)))
                                    ' remove cdbl here
                                    .AddWithValue("QtyText", TxtBatchD.GetBatchNoExpiryItem(i, "tqtytext", k))
                                    .AddWithValue("OpBaseQty", CDbl(TxtBatchD.GetBatchNoExpiryItem(i, "tmainunitqty", k)))
                                    .AddWithValue("OpTotalQty", CDbl(TxtBatchD.GetBatchNoExpiryItem(i, "ttotalqty", k)))
                                    .AddWithValue("OpSubUnitQty", CDbl(TxtBatchD.GetBatchNoExpiryItem(i, "tsubunitqty", k)))
                                    If MyAppSettings.ItemPriceasIncludingVAT = True Then
                                        .AddWithValue("StockRate", CDbl(TxtBatchD.GetBatchNoExpiryItem(i, "trate", k)) * 100 / (100 + CDbl(TxtTax.Text)))
                                        .AddWithValue("OpstockRate", CDbl(TxtBatchD.GetBatchNoExpiryItem(i, "trate", k)) * 100 / (100 + CDbl(TxtTax.Text)))
                                    Else
                                        .AddWithValue("StockRate", CDbl(TxtBatchD.GetBatchNoExpiryItem(i, "trate", k)))
                                        .AddWithValue("OpstockRate", CDbl(TxtBatchD.GetBatchNoExpiryItem(i, "trate", k)))
                                    End If

                                    .AddWithValue("mrp", CDbl(TxtBatchD.GetBatchNoExpiryItem(i, "tmrp", k)))
                                    Dim dt As New DateTimePicker
                                    dt.Value = CDate(TxtBatchD.GetBatchNoExpiryItem(i, "texpiry", k))
                                    .AddWithValue("expiry", dt.Value)
                                    .AddWithValue("BatchNo", TxtBatchD.GetBatchNoExpiryItem(i, "tbatchno", k))
                                    .AddWithValue("expiryDateValue", dt.Value.Date.ToOADate)

                                End With
                                DBF1.ExecuteNonQuery()
                                DBF1 = Nothing
                            Next

                        End If

                        MAINCON.Close()

                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next
        End If
        If Photoname.Length > 0 Then
            InsertImageIntoDatabase(Photoname, "imagedata", "bcode", "INSERT INTO [images] ([ImageData] ,[Bcode])  VALUES (@IMAGEDATA,@BCODE) ", StockBarcodeNo, "DELETE FROM IMAGES WHERE BCODE=N'" & StockBarcodeNo & "'")
        Else
            InsertImageIntoDatabase(TxtPic.Image, "imagedata", "bcode", "INSERT INTO [images] ([ImageData] ,[Bcode])  VALUES (@IMAGEDATA,@BCODE) ", StockBarcodeNo, "DELETE FROM IMAGES WHERE BCODE=N'" & StockBarcodeNo & "'")
        End If
    End Sub
    Private Sub CreateNewStockItem_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        If TxtCustomBarcode.Enabled = False Then
            TxtStockCode.Focus()
        Else
            TxtCustomBarcode.Focus()
        End If


    End Sub

    Private Sub CreateNewStockItem_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        IsExitOnEscKey = False
    End Sub

    Private Sub CreateNewStockItem_Leave(sender As Object, e As System.EventArgs) Handles Me.Leave

    End Sub

    Private Sub CreateNewStockItem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        IsExitOnEscKey = True
        If OpenfromOutside = False Then
            LoadDataIntoComboBox("select stockgroupname from stockgroups", TxtStockGroup, "stockgroupname")
            LoadDataIntoComboBox("select StockCategoryName from Categoriesgroups", TxtCat, "StockCategoryName")
            LoadDataIntoComboBox("select UnitName from stockunits", TxtUnit, "UnitName")
            'LoadDataIntoComboBoxByBinding("select distinct stocksize from stockdbf", TxtStockSize, "stocksize")
            'LoadDataIntoComboBoxByBinding("select distinct Brand from stockdbf", TxtBrand, "Brand")
            'LoadDataIntoComboBoxByBinding("select distinct packing from stockdbf", TxtPacking, "packing", "")
            'LoadDataIntoComboBoxByBinding("select distinct Company from stockdbf", txtMadeBy, "Company")
            LoadDataIntoComboBox("select locationname  from StockLocations", LocationsAV, "locationname")
            LoadDataIntoComboBox("select distinct vattax  from vatclauses WHERE vattype='VAT'", TxtTax, "vattax")
            LoadDataIntoComboBox("select distinct vattax  from vatclauses WHERE vattype='VAT'", TxtTax2, "vattax")
            LoadDataIntoComboBox("select distinct vattax  from vatclauses WHERE vattype='CST'", TxtCSTTax, "vattax", "0")
            LoadDataIntoComboBox("select distinct vattax  from vatclauses WHERE vattype='Service Tax'", txtservicetax, "vattax")

            LoadDefaults()
            If IsOpenForEdit = True Then
                LoadStockDetails()
            End If
            If AppIsItemwithSize = False Then
                Label6.Visible = False
                TxtStockSize.Visible = False
            End If
            ' If MyAppSettings.IsAllowBatchNoExipry = False Then
            'IsBatchExpiry.Visible = False
            'End If
        Else
            If MyAppSettings.SalesPriceasIncludingVAT = True Then
                TxtIsInvlusiveTax.Checked = True
            Else
                TxtIsInvlusiveTax.Checked = False

            End If
        End If
        If IsOpenForEdit = True Then
            isdataloading = True
            If EditMoreItems = True Then
                editpannel.Enabled = True
                LoadDataIntoComboBoxByBinding("SELECT DISTINCT STOCKCODE FROM STOCKDBF", TxtStockNameList, "STOCKCODE")
            End If

            isdataloading = False
            TxtStockNameList.Text = OpenedStockCode
            TxtStockSizeList.Text = OpenedstockSize
        Else
            editpannel.Enabled = False
        End If
    End Sub
    Public Sub LoadDataFromOutSide()
        LoadDataIntoComboBox("select stockgroupname from stockgroups", TxtStockGroup, "stockgroupname")
        LoadDataIntoComboBox("select StockCategoryName from Categoriesgroups", TxtCat, "StockCategoryName")
        LoadDataIntoComboBox("select UnitName from stockunits", TxtUnit, "UnitName")
        
        LoadDataIntoComboBox("select locationname  from StockLocations", LocationsAV, "locationname")
        LoadDataIntoComboBox("select distinct vattax  from vatclauses WHERE vattype='VAT'", TxtTax, "vattax")
        LoadDataIntoComboBox("select distinct vattax  from vatclauses WHERE vattype='VAT'", TxtTax2, "vattax")
        LoadDataIntoComboBox("select distinct vattax  from vatclauses WHERE vattype='CST'", TxtCSTTax, "vattax", "0")
        LoadDataIntoComboBox("select distinct vattax  from vatclauses WHERE vattype='Service Tax'", txtservicetax, "vattax")

        LoadDefaults()
        If IsOpenForEdit = True Then
            LoadStockDetails()
        End If
        If AppIsItemwithSize = False Then
            Label6.Visible = False
            TxtStockSize.Visible = False
        End If
        If MyAppSettings.IsAllowBatchNoExipry = False Then
            IsBatchExpiry.Visible = False
        End If
    End Sub
    Private Sub TxtUnit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUnit.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim newsg As New CreateUnits
            newsg.ShowDialog()
            LoadDataIntoComboBox("select UnitName from stockunits", TxtUnit, "UnitName")
        End If
    End Sub

    Private Sub TxtUnit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtUnit.SelectedIndexChanged
        If SQLGetNumericFieldValue("select unittype from stockunits where unitname=N'" & TxtUnit.Text & "'", "unittype") = 1 Then
            Dim mainunit As String
            Dim subunit As String
            mainunit = SQLGetStringFieldValue("select mainunitname from stockunits where unitname=N'" & TxtUnit.Text & "'", "mainunitname")
            subunit = SQLGetStringFieldValue("select subunitname from stockunits where unitname=N'" & TxtUnit.Text & "'", "subunitname")
            TxtRatePer.Items.Clear()
            TxtWrpPer.Items.Clear()
            TxtDrpPer.Items.Clear()
            TxtRatePer.Items.Add(mainunit)
            TxtWrpPer.Items.Add(mainunit)
            TxtDrpPer.Items.Add(mainunit)
            BatchRateLbl.Text = mainunit & " Price"
            lblMinQty.Text = subunit
        Else
            TxtRatePer.Items.Clear()
            TxtWrpPer.Items.Clear()
            TxtDrpPer.Items.Clear()
            TxtRatePer.Items.Add(TxtUnit.Text)
            TxtWrpPer.Items.Add(TxtUnit.Text)
            TxtDrpPer.Items.Add(TxtUnit.Text)
            lblMinQty.Text = TxtUnit.Text
            BatchRateLbl.Text = TxtUnit.Text & " Price"
        End If

        TxtBatchD.SetUnitNames(TxtUnit.Text)
        If TxtRatePer.Items.Count > 0 Then
            TxtRatePer.SelectedIndex = 0
        End If
        If TxtWrpPer.Items.Count > 0 Then
            TxtWrpPer.SelectedIndex = 0
        End If
        If TxtDrpPer.Items.Count > 0 Then
            TxtDrpPer.SelectedIndex = 0
        End If

    End Sub

    Private Sub TxtStockGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtStockGroup.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim newsg As New CreateStockGroups
            newsg.ShowDialog()
            LoadDataIntoComboBox("select stockgroupname from stockgroups", TxtStockGroup, "stockgroupname")
        End If
    End Sub

    Private Sub TxtStockGroup_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtStockGroup.KeyPress

    End Sub

    Private Sub TxtCat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCat.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim newsg As New CreateStockCategories
            newsg.ShowDialog()
            LoadDataIntoComboBox("select StockCategoryName from Categoriesgroups", TxtCat, "StockCategoryName")
        End If
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

   

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Dim sd As OpenFileDialog = New OpenFileDialog
        sd.Title = "Select Image "
        sd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
        ' sd.Filter = "Bitmap |*.bmp| JPG | *.jpg | GIF | *.gif | All Files|*.*"
        sd.FilterIndex = 1
        sd.Multiselect = False
        If sd.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim temp As Image = TxtPic.Image
            TxtPic.Image = Nothing
            temp.Dispose()
            Dim fs As System.IO.FileStream
            ' Specify a valid picture file path on your computer.
            fs = New System.IO.FileStream(sd.FileName, IO.FileMode.Open, IO.FileAccess.Read)
            TxtPic.Image = System.Drawing.Image.FromStream(fs)
            fs.Close()
            fs.Dispose()
            ' TxtPic.BackgroundImage = Image.FromFile(sd.FileName)
            Photoname = sd.FileName
            IsImageChanged = True
        End If
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        TxtPic.Image = My.Resources.NOPIC
        IsImageChanged = True
        Photoname = ""
    End Sub

    Private Sub TxtBatchD_AmountChanged(ByVal e As Object) Handles TxtBatchD.AmountChanged
        '  MsgBox(TxtBatchD.GetMainTotalQty())
        TxtTotalStock.Text = TxtBatchD.GetMainTotalQty().ToString & "-" & TxtBatchD.GetSubTotalQty.ToString
        If TxtBatchD.GetMainTotalQty() = 0 And TxtBatchD.GetSubTotalQty() = 0 Then
            TxtTotalStock.Text = ""
        Else
            TxtTotalStock.Text = TxtBatchD.GetMainTotalQty().ToString & "-" & TxtBatchD.GetSubTotalQty.ToString
        End If

    End Sub

    Private Sub TxtStockType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockType.SelectedIndexChanged
        If TxtStockType.Text <> "Stock Item" Then
            BatchGroupBox.Visible = False
            ratelble.Visible = True
            TxtRate.Visible = True
            TxtRatePer.Visible = True
            TxtMinStockQty.Enabled = False
        Else
            BatchGroupBox.Visible = True
            ratelble.Visible = False
            TxtRate.Visible = False
            TxtRatePer.Visible = False
            TxtMinStockQty.Enabled = True
        End If
    End Sub

    Private Sub TxtCustomBarcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCustomBarcode.LostFocus
        TxtCustomBarcode.Text = ReplaceZerosToBarcode(TxtCustomBarcode.Text)
        If TxtCustomBarcode.Text.Length = 0 Then Exit Sub
        If SQLIsFieldExists("select custbarcode from Stockdbf where custbarcode=N'" & TxtCustomBarcode.Text & "' ") = True Then
            TxtStockCode.Text = SQLGetStringFieldValue("select stockcode from Stockdbf where custbarcode=N'" & TxtCustomBarcode.Text & "' ", "stockcode")
            barcodeIndicator.BackColor = Color.Red
        Else
            barcodeIndicator.BackColor = Color.Green
        End If
        '
    End Sub

   

   

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        Dim k As New WebcamImage
        k.ShowDialog()
        If TempFileNames2.Length > 0 Then

            TxtPic.Image = Image.FromFile(TempFileNames2)
            Photoname = TempFileNames2
            IsImageChanged = True
        End If
    End Sub


    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab.Name = TabControl1.TabPages(1).Name Then
            If TxtUnit.Text.Length = 0 Then
                TabControl1.SelectedIndex = 0
                MsgBox("Please Select the Unit Name ......             ", MsgBoxStyle.Information)
                TxtUnit.Focus()
            End If
        End If

    End Sub
    Sub LoadStockDetails(Optional ItemRowIndex As Long = -1)
        TxtStockType.Enabled = False
        Dim SQLstr As String = ""
        If ItemRowIndex = -1 Then
            SQLstr = "select * from Stockdbf where stockcode=N'" & OpenedStockCode & "' and stocksize=N'" & OpenedstockSize & "'"
        Else
            SQLstr = "select * from (select *, ROW_NUMBER() OVER (ORDER BY Stockcode) as sn from stockdbf )  tb where sn=" & ItemRowIndex
        End If

        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Dim IsFirstTime As Boolean = True
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = SQLstr
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader

            While Sreader.Read()
                If IsFirstTime = True Then
                    TxtBarCode.Text = Sreader("barcode").ToString.Trim
                    TxtStockName.Text = Sreader("StockName").ToString.Trim
                    TxtStockCode.Text = Sreader("StockCode").ToString.Trim
                    TxtStockGroup.Text = Sreader("stockgroup").ToString.Trim
                    TxtStockSize.Text = Sreader("StockSize").ToString.Trim
                    TxtBrand.Text = Sreader("Brand").ToString.Trim
                    txtMadeBy.Text = Sreader("Company").ToString.Trim
                    TxtDescription.Text = Sreader("description").ToString.Trim
                    TxtHSCode.Text = Sreader("HScode").ToString.Trim
                    TxtCat.Text = Sreader("category").ToString
                    TxtMrp.Text = Sreader("mrp")
                    If MyAppSettings.ItemPriceasIncludingVAT = True Then
                        TxtRate.Text = Sreader("StockRate") + Sreader("StockRate") * Sreader("TAX") / 100
                    Else
                        TxtRate.Text = Sreader("StockRate")
                    End If

                    TxtIsInvlusiveTax.Checked = Sreader("IsTaxInclude")
                    TxtWRp.Text = Sreader("StockWRP")
                    TxtPacking.Text = Sreader("packing").ToString.Trim
                    TxtDrp.Text = Sreader("StockDRP")
                    If Sreader("isbatch") = 1 Then
                        IsBatchExpiry.Checked = True
                    Else
                        IsBatchExpiry.Checked = False
                    End If
                    IsImageChanged = False
                    TxtCustomBarcode.Text = Sreader("custbarcode").ToString.Trim
                    OpenedCustomBarcode = TxtCustomBarcode.Text
                    TxtCostingMethod.Text = IIf(IsDBNull(Sreader("costmethod")) = True, "FIFO", Sreader("costmethod").ToString.Trim)
                    Try
                        TxtTax.Text = Sreader("Tax")
                    Catch ex As Exception
                        TxtTax.Text = "0"
                    End Try
                    Try
                        TxtTax2.Text = Sreader("Tax2")
                    Catch ex As Exception
                        TxtTax2.Text = "0"
                    End Try
                    If Sreader("stocktype") = 0 Then
                        TxtStockType.Text = "Stock Item"
                    ElseIf Sreader("stocktype") = 1 Then
                        TxtStockType.Text = "Non-Stock"
                    Else
                        TxtStockType.Text = "Service"
                    End If
                    TxtStockType.Enabled = False
                    Try
                        TxtMinStockQty.Text = Sreader("minqty")
                    Catch ex As Exception

                    End Try
                    Try
                        'TxtPic.BackgroundImage = Image.FromFile(Sreader("StockImagePath").ToString.Trim)
                        OpenedImage = Sreader("StockImagePath").ToString.Trim
                    Catch ex As Exception

                    End Try
                    IsAllowSerialNumbers.Checked = False
                    Try
                        IsAllowSerialNumbers.Checked = Sreader("allowserialnumbers")
                    Catch ex As Exception

                    End Try
                    TxtUnit.Text = Sreader("BaseUnit").ToString.Trim
                    Try
                        TxtCSTTax.Text = Sreader("cst").ToString
                    Catch ex As Exception

                    End Try
                    TxtIsDiscountAllowed.Checked = Sreader("AllowDiscount")
                    txtservicetax.Text = Sreader("Servicetax")
                End If
                For ct As Integer = 0 To TxtBatchD.GetRows - 1
                    If UCase(Sreader("location")) = UCase(TxtBatchD.GetItem(IMSBatchNoExpiryControl.ControlValues.location, ct).ToString) Then
                        TxtBatchD.SetItems(IMSBatchNoExpiryControl.ControlValues.qty2, ct, Sreader("optotalqty"))
                        TxtBatchD.ValidateStockQty(ct)
                        TxtBatchD.SetItems(IMSBatchNoExpiryControl.ControlValues.stockrate, ct, IIf(IsDBNull(Sreader("opstockrate")) = True, "0", Sreader("opstockrate").ToString.Trim))

                        If IsBatchExpiry.Checked = True Then
                            Dim SqlConn1 As New SqlClient.SqlConnection
                            Dim Sqlcmmd1 As New SqlClient.SqlCommand

                            Try
                                SqlConn1.ConnectionString = ConnectionStrinG
                                SqlConn1.Open()
                                Sqlcmmd1.Connection = SqlConn1
                                Sqlcmmd1.CommandText = "SELECT * FROM STOCKBATCH WHERE STOCKCODE=N'" & TxtStockCode.Text & "' AND STOCKSIZE=N'" & TxtStockSize.Text & "' AND LOCATION=N'" & Sreader("location") & "' AND OPTOTALQTY>0"
                                Sqlcmmd1.CommandType = CommandType.Text
                                Dim SreaderBatch As SqlClient.SqlDataReader
                                SreaderBatch = Sqlcmmd1.ExecuteReader
                                Dim ROWNUMBER As Integer = 0
                                While SreaderBatch.Read()
                                    Dim RNO As Integer = 0
                                    Dim qtytext As New IMSQtyBox
                                    qtytext.SetUnitName(TxtUnit.Text)
                                    If qtytext.IsSimpleUnit = True Then
                                        qtytext.TxtQty1.Text = SreaderBatch("OPTOTALQTY")
                                        qtytext.TxtQty2.Text = "0"
                                    Else
                                        qtytext.TxtQty1.Text = "0"
                                        qtytext.TxtQty2.Text = SreaderBatch("OPTOTALQTY")
                                    End If

                                    TxtBatchD.NewBatchNoExpiryRow(ct)
                                    TxtBatchD.InsertBatchNoExpiryItem(ct, "tlocation", ROWNUMBER, SreaderBatch("LOCATION").ToString.Trim)
                                    TxtBatchD.InsertBatchNoExpiryItem(ct, "tbatchno", ROWNUMBER, SreaderBatch("BATCHNO").ToString.Trim)
                                    TxtBatchD.InsertBatchNoExpiryItem(ct, "texpiry", ROWNUMBER, SreaderBatch("EXPIRY"))
                                    TxtBatchD.InsertBatchNoExpiryItem(ct, "tqtytext", ROWNUMBER, qtytext.GetTotalQtyText)
                                    TxtBatchD.InsertBatchNoExpiryItem(ct, "tmrp", ROWNUMBER, SreaderBatch("MRP"))
                                    If MyAppSettings.ItemPriceasIncludingVAT = True Then
                                        TxtBatchD.InsertBatchNoExpiryItem(ct, "trate", ROWNUMBER, SreaderBatch("opstockrate") + SreaderBatch("opstockrate") * CDbl(TxtTax.Text) / 100)

                                    Else
                                        TxtBatchD.InsertBatchNoExpiryItem(ct, "trate", ROWNUMBER, SreaderBatch("opstockrate"))
                                    End If

                                    TxtBatchD.InsertBatchNoExpiryItem(ct, "trate", ROWNUMBER, SreaderBatch("opstockrate"))
                                    TxtBatchD.InsertBatchNoExpiryItem(ct, "tvalue", ROWNUMBER, SreaderBatch("OPTOTALQTY") * SreaderBatch("opstockrate") / TxtBatchD.GetUnitConverionNo)
                                    TxtBatchD.InsertBatchNoExpiryItem(ct, "ttotalqty", ROWNUMBER, SreaderBatch("OPTOTALQTY"))
                                    TxtBatchD.InsertBatchNoExpiryItem(ct, "tmainunitqty", ROWNUMBER, SreaderBatch("opbaseqty"))
                                    TxtBatchD.InsertBatchNoExpiryItem(ct, "tsubunitqty", ROWNUMBER, SreaderBatch("opsubunitqty"))

                                    ROWNUMBER = ROWNUMBER + 1
                                End While
                                SreaderBatch.Close()
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                SqlConn1.Close()
                                SqlConn1 = Nothing
                                Sqlcmmd1.Connection = Nothing
                            End Try

                        End If

                    End If
                Next

            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn = Nothing
            Sqlcmmd.Connection = Nothing
        End Try




        TxtPic.Image = GetImageFromDatabase("ImageData", "SELECT TOP 1  IMAGEDATA FROM IMAGES where bcode=N'" & TxtCustomBarcode.Text & "'")

        If SQLIsFieldExists("Select stockname from StockInvoiceRowItems where stockcode=N'" & OpenedStockCode & "' and stocksize=N'" & OpenedstockSize & "'") = True Then
            TxtUnit.Enabled = False
            IsBatchExpiry.Enabled = False
        Else
            TxtUnit.Enabled = True
            IsBatchExpiry.Enabled = True
        End If
    End Sub

    Private Sub TxtTax_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTax.LostFocus
        If TxtTax.Text.Length = 0 Then
            TxtTax.Text = "0"
        Else
            If IsNumeric(TxtTax.Text) = False Then
                TxtTax.Text = "0"
            End If
        End If
    End Sub
    Private Sub TxtTax2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTax2.LostFocus
        If TxtTax2.Text.Length = 0 Then
            TxtTax2.Text = "0"
        Else
            If IsNumeric(TxtTax2.Text) = False Then
                TxtTax2.Text = "0"
            End If
        End If
    End Sub
    Private Sub TxtTax_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTax.SelectedIndexChanged, TxtTax2.SelectedIndexChanged

    End Sub

    Private Sub TxtStockCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtStockCode.LostFocus
        If TxtStockName.Text.Length = 0 Then
            TxtStockName.Text = TxtStockCode.Text
        End If
        If SQLIsFieldExists("SELECT TOP 1 1 from Stockdbf where stockcode=N'" & TxtStockCode.Text & "' and stocksize=N'" & TxtStockSize.Text & "'") = True Then
            TxtIdicates.BackColor = Color.Red
        Else
            TxtIdicates.BackColor = Color.Green
        End If
        'barcodeIndicator

        TxtMrp.Focus()

    End Sub

    Private Sub TxtStockCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockCode.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub IsBatchExpiry_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsBatchExpiry.CheckedChanged
        If IsBatchExpiry.Checked = True Then
            TxtBatchD.IsExipryBatchValue(True)

        Else
            TxtBatchD.IsExipryBatchValue(False)
        End If
    End Sub

    Private Sub TxtStockNameList_DropDown(sender As Object, e As System.EventArgs) Handles TxtStockNameList.DropDown
        Dim frm As New SearchStockDbffrm("stockcode", False)
        frm.ShowDialog()
        If frm.SelectedName.Length > 0 Then
            TxtStockNameList.DroppedDown = False
            ItemRowIndexNumber = frm.SelectedRowIndex
            TxtStockNameList.Items.Clear()
            TxtStockNameList.Items.Add(frm.SelectedName)
            TxtStockNameList.Text = frm.SelectedName
            TxtStockNameList.DroppedDown = False
            TxtStockNameList.Focus()
            TxtStockNameList.SelectedIndex = 0
            TxtStockCode.Focus()

            Try
                LoadDataIntoComboBox("SELECT DISTINCT STOCKSIZE FROM STOCKDBF WHERE STOCKCODE=N'" & TxtStockNameList.Text & "'", TxtStockSizeList, "STOCKSIZE")
                TxtStockSizeList.SelectedIndex = 0
                OpenedStockCode = TxtStockNameList.Text
                OpenedstockSize = TxtStockSizeList.Text
                LblItemCodeNumber.Text = "Item Code   (" & ItemRowIndexNumber & ")"
            Catch ex As Exception

            End Try
        End If
        frm.Dispose()
    End Sub

   

   

    Private Sub ImsButton7_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton7.Click
        
        TxtStockNameList.Items.Clear()
        TxtStockNameList.Items.Add(SQLGetStringFieldValue("select stockcode from (select Stockcode, ROW_NUMBER() OVER (ORDER BY Stockcode) as sn from stockdbf )  tb where sn=1", "stockcode"))
        If TxtStockNameList.Items.Count > 0 Then
            TxtStockNameList.SelectedIndex = 0
        End If
    End Sub

    Private Sub ImsButton5_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton5.Click
    
        If ItemRowIndexNumber > 1 Then
            TxtStockNameList.Items.Clear()
            ItemRowIndexNumber = ItemRowIndexNumber - 1
            TxtStockNameList.Items.Add(SQLGetStringFieldValue("select stockcode from (select Stockcode, ROW_NUMBER() OVER (ORDER BY Stockcode) as sn from stockdbf )  tb where sn=" & ItemRowIndexNumber, "stockcode"))
            If TxtStockNameList.Items.Count > 0 Then
                TxtStockNameList.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub ImsButton6_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton6.Click
        
        If ItemRowIndexNumber < MaxItemRows Then
            TxtStockNameList.Items.Clear()
            ItemRowIndexNumber = ItemRowIndexNumber + 1
            TxtStockNameList.Items.Add(SQLGetStringFieldValue("select stockcode from (select Stockcode, ROW_NUMBER() OVER (ORDER BY Stockcode) as sn from stockdbf )  tb where sn=" & ItemRowIndexNumber, "stockcode"))
            If TxtStockNameList.Items.Count > 0 Then
                TxtStockNameList.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub ImsButton4_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton4.Click
        TxtStockNameList.Items.Clear()
        ItemRowIndexNumber = MaxItemRows
        TxtStockNameList.Items.Add(SQLGetStringFieldValue("select stockcode from (select Stockcode, ROW_NUMBER() OVER (ORDER BY Stockcode) as sn from stockdbf )  tb where sn=" & ItemRowIndexNumber, "stockcode"))
        If TxtStockNameList.Items.Count > 0 Then
            TxtStockNameList.SelectedIndex = 0
        End If
    End Sub

    Private Sub TxtStockSizeList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtStockSizeList.SelectedIndexChanged
        OpenedStockCode = TxtStockNameList.Text
        OpenedstockSize = TxtStockSizeList.Text
        IsOpenForEdit = True
        LoadDefaults()
        If IsOpenForEdit = True Then
            LoadStockDetails()
        End If
       
    End Sub

    Private Sub TxtPacking_DropDown(sender As Object, e As System.EventArgs) Handles TxtPacking.DropDown
        Dim frm As New SearchStockDbffrm("packing", False)
        frm.ShowDialog()
        If frm.SelectedName.Length > 0 Then
            TxtPacking.Items.Add(frm.SelectedName)
            TxtPacking.Text = frm.SelectedName
            TxtPacking.DroppedDown = False
        End If
        frm.Dispose()
    End Sub

   
    Private Sub TxtPacking_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtPacking.SelectedIndexChanged

    End Sub

    Private Sub TxtBrand_DropDown(sender As Object, e As System.EventArgs) Handles TxtBrand.DropDown
        Dim frm As New SearchStockDbffrm("Brand", False)
        frm.ShowDialog()
        If frm.SelectedName.Length > 0 Then

            TxtBrand.Items.Add(frm.SelectedName)
            TxtBrand.Text = frm.SelectedName
            TxtBrand.DroppedDown = False
        End If
        frm.Dispose()
    End Sub

    Private Sub TxtBrand_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtBrand.SelectedIndexChanged

    End Sub

    Private Sub txtMadeBy_DropDown(sender As Object, e As System.EventArgs) Handles txtMadeBy.DropDown
        Dim frm As New SearchStockDbffrm("Company", False)
        frm.ShowDialog()
        If frm.SelectedName.Length > 0 Then

            txtMadeBy.Items.Add(frm.SelectedName)
            txtMadeBy.Text = frm.SelectedName
            txtMadeBy.DroppedDown = False
        End If
        frm.Dispose()
    End Sub

    Private Sub txtMadeBy_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles txtMadeBy.SelectedIndexChanged

    End Sub

    Private Sub TxtStockSize_DropDown(sender As Object, e As System.EventArgs) Handles TxtStockSize.DropDown
        Dim frm As New SearchStockDbffrm("stocksize", False)
        frm.ShowDialog()
        If frm.SelectedName.Length > 0 Then

            TxtStockSize.Items.Add(frm.SelectedName)
            TxtStockSize.Text = frm.SelectedName
            TxtStockSize.DroppedDown = False
        End If
        frm.Dispose()
    End Sub

    Private Sub TxtStockSize_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtStockSize.SelectedIndexChanged

    End Sub

   

    Private Sub TxtStockNameList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtStockNameList.SelectedIndexChanged
        If isdataloading = True Then Exit Sub
        Try
            LoadDataIntoComboBox("SELECT DISTINCT STOCKSIZE FROM STOCKDBF WHERE STOCKCODE=N'" & TxtStockNameList.Text & "'", TxtStockSizeList, "STOCKSIZE")
            TxtStockSizeList.SelectedIndex = 0

            LblItemCodeNumber.Text = "Item Code   (" & ItemRowIndexNumber & ")"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Static k As Boolean = True
        Static c As Byte = 0
        If k = True Then
            TxtStatus.ForeColor = Color.Green
            k = False
        Else
            TxtStatus.ForeColor = Color.Blue
            k = True
        End If
        If c = 5 Then
            Timer1.Enabled = False
            c = 0
            TxtStatus.ForeColor = Color.Green
            TxtStatus.Text = "Status: Ready"
        Else
            c = c + 1
        End If
    End Sub

    Private Sub TxtWRp_LostFocus(sender As Object, e As System.EventArgs) Handles TxtWRp.LostFocus
        If CDbl(TxtDrp.Text) = 0 Then
            TxtDrp.Text = TxtWRp.Text
        End If
    End Sub

  
    Private Sub TxtCustomBarcode_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCustomBarcode.TextChanged

    End Sub
End Class
