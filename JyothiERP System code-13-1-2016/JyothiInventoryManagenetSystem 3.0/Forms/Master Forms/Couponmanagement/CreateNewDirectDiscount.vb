Imports System.Windows.Forms

Public Class CreateNewDirectDiscount
    Dim DiscountOpenID As Integer = -1
    Dim OpenDisocuntName As String = ""
    Sub New(Optional ID As Integer = -1)

        ' This call is required by the designer.
        InitializeComponent()
        DiscountOpenID = ID
        ' Add any initialization after the InitializeComponent() call.

    End Sub
   
    Private Sub CreateNewDirectDiscount_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadDataIntoComboBox("select stockgroupname from stockgroups", TxtStockGroup, "stockgroupname", "*All")
        LoadDataIntoComboBox("select StockCategoryName from Categoriesgroups", TxtStockCat, "StockCategoryName", "*All")
        LoadDataIntoComboBox("select locationname  from StockLocations", TxtLocation, "locationname")
        TxtDateFrom.Value = Today
        TxtDateTo.Value = Today
        If DiscountOpenID > -1 Then
            LoadData()
        End If
    End Sub
    Sub LoadData()
        Dim dt As New DataTable
        dt = SQLLoadGridData("select * from Discounts where ID=" & DiscountOpenID)
        If dt.Rows.Count > 0 Then
            TxtDisName.Text = dt.Rows(0).Item("DiscountName").ToString
            OpenDisocuntName = TxtDisName.Text
            If dt.Rows(0).Item("IsDiscPer") = True Then
                TxtValueType.Text = "PERCENTAGE"
            Else
                TxtValueType.Text = "VALUE"
            End If

            TxtPer.Text = dt.Rows(0).Item("DiscountPer")
            TxtDateFrom.Value = dt.Rows(0).Item("DateFrom")
            TxtDateTo.Value = dt.Rows(0).Item("dateto")
        End If
        dt.Dispose()
        loaditemlist()
    End Sub
    Sub loaditemlist()
        Dim sqlstr As String = "select itemid,stockcode,stocksize,location,IsDiscPer,DiscountPer  from Discountdetails inner join stockdbf on barcode=itemid where DiscountID=" & DiscountOpenID
        Dim dt As New DataTable
        dt = SQLLoadGridData(sqlstr)
        Dim RNO As Integer = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                RNO = TxtList.Rows.Add
                TxtList.Item("STSNO", RNO).Value = RNO + 1
                TxtList.Item("stitemID", RNO).Value = dt.Rows(i).Item("itemid").ToString
                TxtList.Item("StItemCode", RNO).Value = dt.Rows(i).Item("STOCKCODE").ToString
                TxtList.Item("stItemSize", RNO).Value = dt.Rows(i).Item("STOCKSIZE").ToString
                TxtList.Item("StLocation", RNO).Value = dt.Rows(i).Item("location").ToString
                If dt.Rows(i).Item("IsDiscPer") = True Then
                    TxtList.Item("stDis", RNO).Value = dt.Rows(i).Item("DiscountPer").ToString & "%"
                Else
                    TxtList.Item("stDis", RNO).Value = -1 * dt.Rows(i).Item("DiscountPer").ToString
                End If
            Next
        End If
        dt.Dispose()
    End Sub
    Private Sub btnAddCat_Click(sender As System.Object, e As System.EventArgs) Handles btnAddCat.Click
        If TxtLocation.Text.Length = 0 Then
            MsgBox("Please Select the Location Name...     ", MsgBoxStyle.Information)
            TxtLocation.Focus()
            Exit Sub
        End If
        If TxtStockCat.Text.Length = 0 Then
            MsgBox("Please Select the Stock Category name...", MsgBoxStyle.Information)
            TxtStockCat.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to Add ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim stlist As New DataTable
            If TxtStockCat.Text = "*All" Then
                stlist = SQLLoadGridData("select barcode,stockcode,stocksize,location from stockdbf where location=N'" & GetDefLocationName() & "' ")
            Else
                stlist = SQLLoadGridData("select barcode,stockcode,stocksize,location  from stockdbf where location=N'" & GetDefLocationName() & "' and category=N'" & TxtStockCat.Text & "'")
            End If
            If stlist.Rows.Count = 0 Then Exit Sub
            For i As Integer = 0 To stlist.Rows.Count - 1
                Dim ITEMBARCODE As String = SQLGetStringFieldValue("select barcode from stockdbf where location=N'" & TxtLocation.Text & "' and stockcode=N'" & stlist.Rows(i).Item("STOCKCODE").ToString & "' and stockSIZE=N'" & stlist.Rows(i).Item("STOCKSIZE").ToString & "'", "barcode")
                If ITEMBARCODE.Length = 0 Then
                    Dim NewAddItem As New ChooseItemClass
                    LoadStockItemsIntoClassWithStockDetails(stlist.Rows(i).Item("STOCKCODE").ToString, stlist.Rows(i).Item("STOCKSIZE").ToString, "", NewAddItem)
                    ITEMBARCODE = AddStockItem(stlist.Rows(i).Item("STOCKCODE").ToString, stlist.Rows(i).Item("STOCKSIZE").ToString, "", TxtLocation.Text, NewAddItem)
                End If
                Dim RNO As Integer = 0
                If TxtList.Find("stitemID", ITEMBARCODE) = False Then
                    RNO = TxtList.Rows.Add
                    TxtList.Item("STSNO", RNO).Value = RNO + 1
                    TxtList.Item("stitemID", RNO).Value = ITEMBARCODE
                    TxtList.Item("StItemCode", RNO).Value = stlist.Rows(i).Item("STOCKCODE").ToString
                    TxtList.Item("stItemSize", RNO).Value = stlist.Rows(i).Item("STOCKSIZE").ToString
                    TxtList.Item("StLocation", RNO).Value = TxtLocation.Text
                    If TxtValueType.Text = "PERCENTAGE" Then
                        TxtList.Item("stDis", RNO).Value = TxtPer.Text & "%"
                    Else
                        TxtList.Item("stDis", RNO).Value = -1 * TxtPer.Text
                    End If

                End If


            Next

        End If
    End Sub

    Private Sub BtnAddGroup_Click(sender As System.Object, e As System.EventArgs) Handles BtnAddGroup.Click
        If TxtLocation.Text.Length = 0 Then
            MsgBox("Please Select the Location Name...     ", MsgBoxStyle.Information)
            TxtLocation.Focus()
            Exit Sub
        End If
        If TxtStockCat.Text.Length = 0 Then
            MsgBox("Please Select the Stock Category name...", MsgBoxStyle.Information)
            TxtStockCat.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to Add ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim stlist As New DataTable
            If TxtStockGroup.Text = "*All" Then
                stlist = SQLLoadGridData("select barcode,stockcode,stocksize,location from stockdbf where location=N'" & GetDefLocationName() & "' ")
            Else
                stlist = SQLLoadGridData("select barcode,stockcode,stocksize,location  from stockdbf where location=N'" & GetDefLocationName() & "' and stockgroup=N'" & TxtStockGroup.Text & "'")
            End If
            If stlist.Rows.Count = 0 Then Exit Sub
            For i As Integer = 0 To stlist.Rows.Count - 1
                Dim ITEMBARCODE As String = SQLGetStringFieldValue("select barcode from stockdbf where location=N'" & TxtLocation.Text & "' and stockcode=N'" & stlist.Rows(i).Item("STOCKCODE").ToString & "' and stockSIZE=N'" & stlist.Rows(i).Item("STOCKSIZE").ToString & "'", "barcode")
                If ITEMBARCODE.Length = 0 Then
                    Dim NewAddItem As New ChooseItemClass
                    LoadStockItemsIntoClassWithStockDetails(stlist.Rows(i).Item("STOCKCODE").ToString, stlist.Rows(i).Item("STOCKSIZE").ToString, "", NewAddItem)
                    ITEMBARCODE = AddStockItem(stlist.Rows(i).Item("STOCKCODE").ToString, stlist.Rows(i).Item("STOCKSIZE").ToString, "", TxtLocation.Text, NewAddItem)
                End If
                Dim RNO As Integer = 0
                If TxtList.Find("stitemID", ITEMBARCODE) = False Then
                    RNO = TxtList.Rows.Add
                    TxtList.Item("STSNO", RNO).Value = RNO + 1
                    TxtList.Item("stitemID", RNO).Value = ITEMBARCODE
                    TxtList.Item("StItemCode", RNO).Value = stlist.Rows(i).Item("STOCKCODE").ToString
                    TxtList.Item("stItemSize", RNO).Value = stlist.Rows(i).Item("STOCKSIZE").ToString
                    TxtList.Item("StLocation", RNO).Value = TxtLocation.Text
                    If TxtValueType.Text = "PERCENTAGE" Then
                        TxtList.Item("stDis", RNO).Value = TxtPer.Text & "%"
                    Else
                        TxtList.Item("stDis", RNO).Value = -1 * TxtPer.Text
                    End If
                End If


            Next

        End If
    End Sub

    Private Sub TxtBarcode_LostFocus(sender As Object, e As System.EventArgs)
        If TxtLocation.Text.Length = 0 Then
            MsgBox("Please Select the Location Name...     ", MsgBoxStyle.Information)
            TxtLocation.Focus()
            Exit Sub
        End If
    End Sub

  
    
    Private Sub btnsearchbyitem_Click(sender As System.Object, e As System.EventArgs) Handles btnsearchbyitem.Click
        Dim bvalue As New ChooseItemClass
        bvalue.StockItemBarCode = 0
        Dim k As New ChooseItems(bvalue)
        If POSSettings.AllowNewItem = False Then
            k.BtnCreate.Enabled = False
        End If

        If k.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If bvalue.StockItemBarCode.Length <> 0 Then
                Dim NewAddItem As New ChooseItemClass
                LoadStockItemsIntoClass(bvalue.StockItemBarCode, bvalue.StockLocation, NewAddItem)
                Dim RNO As Integer = 0
                If TxtList.Find("stitemID", NewAddItem.StockItemBarCode) = False Then
                    RNO = TxtList.Rows.Add
                    TxtList.Item("STSNO", RNO).Value = RNO + 1
                    TxtList.Item("stitemID", RNO).Value = NewAddItem.StockItemBarCode
                    TxtList.Item("StItemCode", RNO).Value = NewAddItem.StockItemCode
                    TxtList.Item("stItemSize", RNO).Value = NewAddItem.StockITemSize
                    TxtList.Item("StLocation", RNO).Value = NewAddItem.StockLocation
                    If TxtValueType.Text = "PERCENTAGE" Then
                        TxtList.Item("stDis", RNO).Value = TxtPer.Text & "%"
                    Else
                        TxtList.Item("stDis", RNO).Value = -1 * TxtPer.Text
                    End If
                End If
            End If
        End If

        bvalue = Nothing
        k.Dispose()
    End Sub

    Private Sub BtnCreate_Click(sender As System.Object, e As System.EventArgs) Handles BtnCreate.Click
        If TxtList.Rows.Count = 0 Then
            MsgBox("Please Select Items      ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtDisName.Text.Length = 0 Then
            MsgBox("Please Enter the Discount Name...", MsgBoxStyle.Information)
            TxtDisName.Focus()
            Exit Sub
        End If
        If TxtPer.Text.Length = 0 Then
            MsgBox("Please Enter the Discount Value...", MsgBoxStyle.Information)
            TxtPer.Focus()
            Exit Sub
        End If
        If CDbl(TxtPer.Text) <= 0 Then
            MsgBox("Please Enter the Discount Value...", MsgBoxStyle.Information)
            TxtPer.Focus()
            Exit Sub
        End If
        If TxtValueType.Text.Length = 0 Then
            MsgBox("Please Select the Discount Type... ", MsgBoxStyle.Information)
            TxtValueType.Focus()
            Exit Sub
        End If
        If DiscountOpenID > -1 Then
            If TxtDisName.Text.ToUpper <> OpenDisocuntName.ToUpper Then
                If SQLIsFieldExists("select DiscountName from Discounts where DiscountName=N'" & TxtDisName.Text & "'") = True Then
                    MsgBox("The Entered Disocunt Name is Already Exists, Please try again....")
                    TxtDisName.Focus()
                    Exit Sub
                End If
            End If
            If MsgBox("Do You want to Save Changes ?                 ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("delete from discountDetails where DiscountID=" & DiscountOpenID)
                SaveChangesData()
                Me.Close()
            End If
        Else
            If SQLIsFieldExists("select DiscountName from Discounts where DiscountName=N'" & TxtDisName.Text & "'") = True Then
                MsgBox("The Entered Disocunt Name is Already Exists, Please try again....")
                TxtDisName.Focus()
                Exit Sub
            End If
            If MsgBox("Do You want to Save ?                 ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SaveData()
                Me.Close()
            End If
        End If

    End Sub
    Sub SaveChangesData()
        Dim sqlstr As String = ""

        sqlstr = "update [Discounts] set [DiscountName]=@DiscountName,[IsDiscPer]=@IsDiscPer,[DiscountPer]=@DiscountPer,[DateFrom]=@DateFrom,[DateFromValue]=@DateFromValue, " _
             & " [DateTo]=@DateTo,[DateToValue]=@DateToValue,[DiscountType]=@DiscountType where id=" & DiscountOpenID

        Try
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
            With DBF.Parameters
                .AddWithValue("DiscountName", TxtDisName.Text)
                .AddWithValue("IsDiscPer", IIf(TxtValueType.Text = "PERCENTAGE", 1, 0))
                .AddWithValue("DiscountPer", CDbl(TxtPer.Text))
                .AddWithValue("DateFrom", TxtDateFrom.Value)
                .AddWithValue("DateFromValue", TxtDateFrom.Value.Date.ToOADate)
                .AddWithValue("DateTo", TxtDateTo.Value)
                .AddWithValue("DateToValue", TxtDateTo.Value.Date.ToOADate)
                .AddWithValue("DiscountType", "ItemWise")

            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
        sqlstr = "INSERT INTO [discountDetails] ([DiscountID],[ItemID],IsDiscPer,DiscountPer)     VALUES (@DiscountID,@ItemID,@IsDiscPer,@DiscountPer)"
        Try
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            For i As Integer = 0 To TxtList.Rows.Count - 1
                Dim DiscountAmount As String = ""
                Dim IsPer As Boolean = False
                DiscountAmount = TxtList.Item("stdis", i).Value
                If DiscountAmount.Contains("%") = True Then
                    DiscountAmount = DiscountAmount.Replace("%", "")
                    IsPer = True
                    If IsNumeric(DiscountAmount) = False Then
                        GoTo xx
                    End If
                Else
                    IsPer = False
                    If IsNumeric(DiscountAmount) = False Then
                        GoTo xx
                    End If
                End If
                Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
                With DBF.Parameters
                    .AddWithValue("DiscountID", DiscountOpenID)
                    .AddWithValue("ItemID", TxtList.Item("stitemID", i).Value)
                   
                    If IsPer = True Then
                        .AddWithValue("IsDiscPer", True)
                        .AddWithValue("DiscountPer", CDbl(DiscountAmount))
                    Else
                        .AddWithValue("IsDiscPer", False)
                        .AddWithValue("DiscountPer", IIf(CDbl(DiscountAmount) > 0, CDbl(DiscountAmount), -1 * CDbl(DiscountAmount)))
                    End If
                End With
                DBF.ExecuteNonQuery()
                DBF = Nothing
xx:
            Next
            MAINCON.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

    End Sub
    Sub SaveData()
        Dim sqlstr As String = ""

        sqlstr = "INSERT INTO [Discounts]([DiscountName],[StockGroup],[IsDiscPer],[DiscountPer],[DateFrom],[DateFromValue],[DateTo],[DateToValue],[DiscountType],[isActive])  " _
            & " VALUES (@DiscountName,@StockGroup,@IsDiscPer,@DiscountPer,@DateFrom,@DateFromValue,@DateTo,@DateToValue,@DiscountType,@isActive)  "
        Try
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
            With DBF.Parameters
                .AddWithValue("DiscountName", TxtDisName.Text)
                .AddWithValue("StockGroup", "")
                .AddWithValue("IsDiscPer", IIf(TxtValueType.Text = "PERCENTAGE", 1, 0))
                .AddWithValue("DiscountPer", CDbl(TxtPer.Text))
                .AddWithValue("DateFrom", TxtDateFrom.Value)
                .AddWithValue("DateFromValue", TxtDateFrom.Value.Date.ToOADate)
                .AddWithValue("DateTo", TxtDateTo.Value)
                .AddWithValue("DateToValue", TxtDateTo.Value.Date.ToOADate)
                .AddWithValue("DiscountType", "ItemWise")
                .AddWithValue("isActive", 1)
            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
        Dim dID As Long = 0
        dID = SQLGetNumericFieldValue("select id from Discounts where DiscountName=N'" & TxtDisName.Text & "'", "id")
        'saving items
        sqlstr = "INSERT INTO [discountDetails] ([DiscountID],[ItemID],IsDiscPer,DiscountPer)     VALUES (@DiscountID,@ItemID,@IsDiscPer,@DiscountPer)"
        Try
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            For i As Integer = 0 To TxtList.Rows.Count - 1
                Dim DiscountAmount As String = ""
                Dim IsPer As Boolean = False
                DiscountAmount = TxtList.Item("stdis", i).Value
                If DiscountAmount.Contains("%") = True Then
                    DiscountAmount = DiscountAmount.Replace("%", "")
                    IsPer = True
                    If IsNumeric(DiscountAmount) = False Then
                        GoTo xx
                    End If
                Else
                    IsPer = False
                    If IsNumeric(DiscountAmount) = False Then
                        GoTo xx
                    End If
                End If
                Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
                With DBF.Parameters
                    .AddWithValue("DiscountID", dID)
                    .AddWithValue("ItemID", TxtList.Item("stitemID", i).Value)

                    If IsPer = True Then
                        .AddWithValue("IsDiscPer", True)
                        .AddWithValue("DiscountPer", CDbl(DiscountAmount))
                    Else
                        .AddWithValue("IsDiscPer", False)
                        .AddWithValue("DiscountPer", IIf(CDbl(DiscountAmount) > 0, CDbl(DiscountAmount), -1 * CDbl(DiscountAmount)))
                    End If
                End With
                DBF.ExecuteNonQuery()
                DBF = Nothing
xx:
            Next
            MAINCON.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

    End Sub
End Class
