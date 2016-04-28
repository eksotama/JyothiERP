Imports System.Windows.Forms

Public Class CreateNewFixedAsset

   
    Sub LoadDefs()
        TxtAssetID.Text = GetIDCode(EnumIDType.AssetID)
        'If IsEditMode = True Then
        '    AssetNameTemp = AssetName
        'Else
        '    AssetNameTemp = CurrentUserName & TxtAssetID.Text
        'End If
        TxtAssetBarcode.Text = ReplaceZerosToBarcode("A" & "1000" & TxtAssetID.Text)
        TxtAssetName.Text = ""
        TxtDescr.Text = ""
        LoadDataIntoComboBox("Select Distinct store from assets ", TxtStoreName, "Store")
        LoadDataIntoComboBox("Select locationname from StockLocations ", TxtLocation, "locationname")
        LoadDataIntoComboBox("Select Distinct Manufacturer from assets ", TxtManufact, "Manufacturer")
        LoadDataIntoComboBox("Select Distinct brand from assets ", TxtBrand, "brand")
        LoadDataIntoComboBox("Select Distinct Model from assets ", TxtModel, "Model")
        LoadDataIntoComboBox("Select Distinct status from assets ", TxtAssetStatus, "status")
        LoadDataIntoComboBox("Select AssetGroupName  from assetgroups ", TxtAssetType, "AssetGroupName")
        If TxtAssetStatus.Items.Count = 0 Then
            TxtAssetStatus.Items.Add("In Use")
            TxtAssetStatus.Text = "In Use"
        End If
        LoadDataIntoComboBox("Select Distinct condition from assets ", txtCondition, "condition")
        If txtCondition.Items.Count = 0 Then
            txtCondition.Items.Add("Good")
            txtCondition.Text = "Good"
        End If
        TxtExpiry.Value = Today.AddYears(10)
        TxtNote.Text = ""
        TxtImage.BackgroundImage = Nothing
        LoadDataIntoComboBox("SELECT  LedgerName  from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "'))", TxtVendorName, "LedgerName")
        TxtPurRate.Text = "0"
        TxtScrapValue.Text = "0"
        TxtYears.Text = "1"
        TxtpurchaseDate.Value = Today
        TxtServiceStartDate.Value = Today
        TxtWarrantyDate.Value = Today.AddYears(10)
        TxtDepRate.Text = "0"
        TxtDepreMethod.Text = "Custom"
        TxtDepList.Rows.Clear()

    End Sub
    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click

    End Sub
    Sub SaveAsset()
        Dim Sqlstr As String = ""
        Sqlstr = "INSERT INTO [assets]([AssetID],[AssetName],[AssetBarcode],[createddate],[purchasedate],[duedate],[LastServiceDate],[LastCheckoutDate],[LastCheckInDate]," _
            & " [assettype],[vender],[status],[transcode],[qty],[rate],[totalvalue],[condition],[orderno],[locationid],[employeename],[department],[notes],[notesId], " _
            & " [expirydate],[deprate],[username],[location],[depreciationmethod],[assetimage],[IsReadOnly],[ISACTIVE],[checkstatus],[n1],[Moreinfo],[Store],[Manufacturer],[Model])  VALUES " _
            & " (@AssetID,@AssetName,@AssetBarcode,@createddate,@purchasedate,@duedate,@LastServiceDate,@LastCheckoutDate,@LastCheckInDate,@assettype,@vender,@status,@transcode,@qty,@rate, " _
            & " @totalvalue,@condition,@orderno,@locationid,@employeename,@department,@notes,@notesId,@expirydate,@deprate,@username,@location,@depreciationmethod, " _
            & " @assetimage,@IsReadOnly,@ISACTIVE,@checkstatus,@n1,@Moreinfo,@Store,@Manufacturer,@Model) "


    End Sub

    Private Sub TxtDepreMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDepreMethod.SelectedIndexChanged
        CalculateDepr()
    End Sub
    Sub CalculateDepr()
        TxtDepRate.Enabled = False
        If TxtDepreMethod.Text = "Sum Of Years" Then
            CalForSumofYears()

        ElseIf TxtDepreMethod.Text = "Not Applicable" Then
            TxtDepList.Rows.Clear()
        
        ElseIf TxtDepreMethod.Text = "Straight Line" Then
            CalForFixedDoubleDecline()
        ElseIf TxtDepreMethod.Text = "Fixed Declining Balance" Then
            CalForFixedDoubleDecline()
        ElseIf TxtDepreMethod.Text = "Double Declining Balance" Then
            TxtDepRate.Enabled = True
            CalForDoubleDecline()
        End If
    End Sub
    Sub CalForFixedDoubleDecline()
        TxtDepList.Rows.Clear()
        If CDbl(TxtYears.Text) <= 0 Then Exit Sub
        If CDbl(TxtPurRate.Text) <= 0 Then Exit Sub
        Dim Years As Integer = CDbl(TxtYears.Text)
        Dim Tdate As New DateTimePicker
        Dim yearFactor As Integer = 0
        Dim MonthFactor As Integer = 1
        Dim AssetValue As Double = 0
        Dim AccValue As Double = 0
        Dim Depvalue As Double = 0
        Dim AssetYears As Double = 0
        AssetYears = CDbl(TxtYears.Text)
        AssetValue = CDbl(TxtPurRate.Text)
        Dim scalefator As Double = 2


        
        MonthFactor = 13 - TxtServiceStartDate.Value.Date.Month
        Tdate.Value = TxtServiceStartDate.Value
        Dim DepPer As Double = 0
        Dim rno As Integer = 0
        For count As Integer = 0 To IIf(TxtServiceStartDate.Value.Date.Month > 1, Years, Years - 1)
            If TxtServiceStartDate.Value.Date.Month > 1 Then
                If count = 0 Then
                    If AssetValue - AccValue = 0 Then
                        DepPer = 0
                    Else
                        DepPer = AssetValue * (1 - Math.Pow((CDbl(TxtScrapValue.Text) / AssetValue), 1 / Years)) * MonthFactor / 12
                        DepPer = DepPer / (AssetValue - AccValue)
                    End If
                   
                ElseIf count = Years Then
                    If AssetValue - AccValue = 0 Then
                        DepPer = 0
                    Else
                        DepPer = Depvalue * (1 - Math.Pow((CDbl(TxtScrapValue.Text) / AssetValue), 1 / Years)) * (12 - MonthFactor) / 12
                        DepPer = DepPer / (AssetValue - AccValue)
                    End If
                    
                Else
                    If AssetValue - AccValue = 0 Then
                        DepPer = 0
                    Else
                        DepPer = 1 - Math.Pow((CDbl(TxtScrapValue.Text) / AssetValue), 1 / Years)
                    End If


                End If
            Else
                If AssetValue - AccValue = 0 Then
                    DepPer = 0
                Else
                     DepPer = 1 - Math.Pow((CDbl(TxtScrapValue.Text) / AssetValue), 1 / Years)
                End If


            End If


            Depvalue = (AssetValue - AccValue) * DepPer
            rno = TxtDepList.Rows.Add


            TxtDepList.Item("tyear", rno).Value = Tdate.Value.Date
            TxtDepList.Item("tbookvalue", rno).Value = AssetValue - AccValue
            TxtDepList.Item("tdepper", rno).Value = IIf(AssetValue - AccValue = 0, 0, DepPer * 100)
            TxtDepList.Item("tdepval", rno).Value = Depvalue
            AccValue = AccValue + Depvalue
            TxtDepList.Item("tacvalue", rno).Value = IIf(AssetValue - AccValue = 0, 0, AccValue)
            TxtDepList.Item("tendbookvalue", rno).Value = AssetValue - AccValue
            Dim temp As New DateTimePicker
            temp.Value = New Date(Tdate.Value.Year, 12, 31).Date
            TxtDepList.Item("tenddate", rno).Value = New Date(Tdate.Value.Year, 12, 31).Date
            Tdate.Value = New Date(Tdate.Value.Year + 1, 1, 1)
            If Years = 1 Then
                Exit For
            End If
        Next
        '  MsgBox(CDbl(AssetValue) - AccValue)
        TxtDepList.Item("tdepval", rno).Value = CDbl(TxtDepList.Item("tbookvalue", rno).Value) - CDbl(TxtScrapValue.Text)
        TxtDepList.Item("tdepper", rno).Value = (CDbl(TxtDepList.Item("tbookvalue", rno).Value) - CDbl(TxtScrapValue.Text)) * 100 / CDbl(TxtDepList.Item("tbookvalue", rno).Value)

        TxtDepList.Item("tendbookvalue", rno).Value = CDbl(TxtScrapValue.Text)
    End Sub
    Sub CalForDoubleDecline()
        TxtDepList.Rows.Clear()
        If CDbl(TxtYears.Text) <= 0 Then Exit Sub
        If CDbl(TxtPurRate.Text) <= 0 Then Exit Sub
        Dim Years As Integer = CDbl(TxtYears.Text)
        Dim Tdate As New DateTimePicker
        Dim yearFactor As Integer = 0
        Dim MonthFactor As Integer = 1
        Dim AssetValue As Double = 0
        Dim AccValue As Double = 0
        Dim Depvalue As Double = 0
        Dim AssetYears As Double = 0
        AssetYears = CDbl(TxtYears.Text)
        AssetValue = CDbl(TxtPurRate.Text)
        Dim scalefator As Double = 2
        If CDbl(TxtDepRate.Text) > 0 Then
            scalefator = CDbl(TxtDepRate.Text)
        End If
        yearFactor = Years * (Years + 1) / 2
        If TxtServiceStartDate.Value.Date.Month > 1 Then
            '     Years = Years + 1
        End If
        MonthFactor = 13 - TxtServiceStartDate.Value.Date.Month
        Tdate.Value = TxtServiceStartDate.Value
        Dim DepPer As Double = 0
        Dim rno As Integer = 0
        For count As Integer = 0 To IIf(TxtServiceStartDate.Value.Date.Month > 1, Years, Years - 1)
            If TxtServiceStartDate.Value.Date.Month > 1 Then
                If count = 0 Then
                    DepPer = (MonthFactor / 12) * (100 / Years)
                ElseIf count = Years Then

                    DepPer = ((12 - MonthFactor) / 12) * (100 / Years)
                Else

                    DepPer = (100 / Years)
                End If
            Else
                DepPer = (100 / Years)
            End If


            Depvalue = (AssetValue - AccValue) * DepPer * scalefator / 100
            rno = TxtDepList.Rows.Add


            TxtDepList.Item("tyear", rno).Value = Tdate.Value.Date
            TxtDepList.Item("tbookvalue", rno).Value = AssetValue - AccValue
            TxtDepList.Item("tdepper", rno).Value = DepPer * scalefator
            TxtDepList.Item("tdepval", rno).Value = Depvalue
            AccValue = AccValue + Depvalue
            TxtDepList.Item("tacvalue", rno).Value = AccValue
            TxtDepList.Item("tendbookvalue", rno).Value = AssetValue - AccValue
            Dim temp As New DateTimePicker
            temp.Value = New Date(Tdate.Value.Year, 12, 31).Date
            TxtDepList.Item("tenddate", rno).Value = New Date(Tdate.Value.Year, 12, 31).Date
            Tdate.Value = New Date(Tdate.Value.Year + 1, 1, 1)
            If Years = 1 Then
                Exit For
            End If
        Next
        '  MsgBox(CDbl(AssetValue) - AccValue)
        TxtDepList.Item("tdepval", rno).Value = CDbl(TxtDepList.Item("tbookvalue", rno).Value) - CDbl(TxtScrapValue.Text)
        TxtDepList.Item("tdepper", rno).Value = (CDbl(TxtDepList.Item("tbookvalue", rno).Value) - CDbl(TxtScrapValue.Text)) * 100 / CDbl(TxtDepList.Item("tbookvalue", rno).Value)

        TxtDepList.Item("tendbookvalue", rno).value = CDbl(TxtScrapValue.Text)
    End Sub
    Sub CalForSumofYears()
        TxtDepList.Rows.Clear()
        If CDbl(TxtYears.Text) <= 0 Then Exit Sub
        If CDbl(TxtPurRate.Text) <= 0 Then Exit Sub
        Dim Years As Integer = CDbl(TxtYears.Text)
        Dim Tdate As New DateTimePicker
        Dim yearFactor As Integer = 0
        Dim MonthFactor As Integer = 1
        Dim AssetValue As Double = 0
        Dim AccValue As Double = 0
        Dim Depvalue As Double = 0
        Dim AssetYears As Double = 0
        AssetYears = CDbl(TxtYears.Text)
        AssetValue = CDbl(TxtPurRate.Text) - CDbl(TxtScrapValue.Text)
        yearFactor = Years * (Years + 1) / 2
        If TxtServiceStartDate.Value.Date.Month > 1 Then
            Years = Years + 1
        End If
        MonthFactor = 13 - TxtServiceStartDate.Value.Date.Month
        Tdate.Value = TxtServiceStartDate.Value
        Dim DepPer As Double = 0
        Dim rno As Integer = 0
        
        For count As Integer = 0 To Years - 1
            If count = 0 Then
                DepPer = (MonthFactor / 12) * (AssetYears / yearFactor)
            Else
                DepPer = (((12 - MonthFactor) / 12) * (AssetYears + 1 - count) / yearFactor) + ((MonthFactor / 12) * ((AssetYears - count) / yearFactor))
            End If
            Depvalue = AssetValue * DepPer
            rno = TxtDepList.Rows.Add
            TxtDepList.Item("tyear", rno).Value = Tdate.Value.Date
            TxtDepList.Item("tbookvalue", rno).Value = AssetValue - AccValue
            TxtDepList.Item("tdepper", rno).Value = DepPer * 100
            TxtDepList.Item("tdepval", rno).Value = Depvalue
            AccValue = AccValue + Depvalue
            TxtDepList.Item("tacvalue", rno).Value = AccValue
            TxtDepList.Item("tendbookvalue", rno).Value = AssetValue - AccValue
            Dim temp As New DateTimePicker
            temp.Value = New Date(Tdate.Value.Year, 12, 31).Date
            TxtDepList.Item("tenddate", rno).Value = New Date(Tdate.Value.Year, 12, 31).Date
            Tdate.Value = New Date(Tdate.Value.Year + 1, 1, 1)
            If Years = 1 Then
                Exit For
            End If
        Next
        TxtDepList.Item("tendbookvalue", rno).value = CDbl(TxtScrapValue.Text)
    End Sub

    Private Sub TxtPurRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPurRate.LostFocus, TxtScrapValue.LostFocus, TxtYears.LostFocus, TxtpurchaseDate.LostFocus, TxtServiceStartDate.LostFocus
        CalculateDepr()
    End Sub

   
End Class
