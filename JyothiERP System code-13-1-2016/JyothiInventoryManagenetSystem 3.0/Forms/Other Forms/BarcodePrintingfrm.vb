
Imports System.Drawing.Printing
Imports System.IO

Public Class BarcodePrintingfrm
    Dim SqlSTR As String = ""
    Dim PaperWidth As Integer = 0
    Dim PaperHeight As Integer = 0
    Dim ImageList As New ComboBox
    Dim StockCodeList As New ComboBox
    Dim BcodeType As BarcodeLib.TYPE
    Sub LoadStock()
        Dim AdditionSqlText = ""
        
        SqlSTR = "SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [S.NO],  [StockCode] as [Stock Code],stockname as [Stock Name],[custBarcode] as [BAR CODE]  FROM [StockDbf] "
        If TxtGroup.Text.Length = 0 Or TxtGroup.Text = "*All" Then

        Else
            AdditionSqlText = " Where stockgroup='" & TxtGroup.Text & "' "
        End If

        If TxtCat.Text.Length = 0 Or TxtCat.Text = "*All" Then

        Else
            If AdditionSqlText.Length = 0 Then
                AdditionSqlText = " where  category='" & TxtCat.Text & "' "
            Else
                AdditionSqlText = AdditionSqlText & " and  category='" & TxtCat.Text & "' "
            End If
        End If
        If AdditionSqlText.Length = 0 Then
            AdditionSqlText = " where location='" & GetDefLocationName() & "' "
        Else
            AdditionSqlText = AdditionSqlText & " and location='" & GetDefLocationName() & "' "
        End If

        Dim TempBS As New BindingSource
         SqlSTR = SqlSTR & AdditionSqlText & " group by stockcode,stockname,custBarcode"

        Try
            Me.TxtList.Rows.Clear()
        Catch ex As Exception

        End Try

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlSTR)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(0).Width = 30
            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(1).Width = 120
            Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(2).Width = 120

        Catch ex As Exception

        End Try

        Try
            Me.TxtList.Columns("BAR CODE").ReadOnly = True
            If AppIsItemwithSize = False Then
                TxtList.Columns("Stock Size").Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub
    Sub LoadReport()

        Try
            Me.PrintGroup.Controls.RemoveAt(0)

        Catch ex As Exception

        End Try
        Me.PrintPreviewControl1 = New System.Windows.Forms.PrintPreviewControl

        Me.PrintPreviewControl1.Zoom = 1

        Me.PrintPreviewControl1.Hide()
        Me.PrintPreviewControl1.SuspendLayout()
        Me.PrintPreviewControl1.Dock = DockStyle.Fill
        PrintPreviewControl1.Refresh()
        PrintPreviewControl1.Document = PrtDoc
        Me.PrintPreviewControl1.ResumeLayout()
        Me.PrintGroup.Controls.Add(Me.PrintPreviewControl1)
        Me.PrintPreviewControl1.Show()
        Me.Cursor = Cursors.Default
    End Sub
    Sub LoadPriceListNames()
        TxtPriceLevel.Items.Clear()
        LoadDataIntoComboBox("select  pricelistname from pricelist", TxtPriceLevel, "pricelistname")
        TxtPriceLevel.Items.Add("Wholesale")
        TxtPriceLevel.Items.Add("Retail")
    End Sub
    Private Sub CustomBarcodeEntry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ERPInitializeObjects(Me)

        LoadPriceListNames()
        TxtBarcodeType.Text = "ENA-13"
        BcodeType = BarcodeLib.TYPE.EAN13
        LoadDataIntoComboBox("select * from stockgroups", TxtGroup, "stockgroupname", "*All")
        PaperWidth = 827
        PaperHeight = 1169
        LoadDataIntoComboBox("select * from Categoriesgroups", TxtCat, "StockCategoryName", "*All")
        LoadStock()
        ' TxtBarcodeType.Items.AddRange([Enum].GetValues(GetType(BarcodeLib.TYPE)))
     
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TxtCustomBarcode.Enabled = True
            TxtList.Enabled = False
        Else
            TxtCustomBarcode.Enabled = False
            TxtList.Enabled = True
        End If
    End Sub

    Private Sub PrtDoc_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrtDoc.BeginPrint
        PrtDoc.DefaultPageSettings.PaperSize = New PaperSize("Custom", PaperWidth, PaperHeight)
        PrtDoc.DefaultPageSettings.Landscape = False
        PrtDoc.DefaultPageSettings.Margins.Left = 10
        PrtDoc.DefaultPageSettings.Margins.Right = 10
        PrtDoc.DefaultPageSettings.Margins.Top = 10
        PrtDoc.DefaultPageSettings.Margins.Bottom = 10
    End Sub

    Private Sub PrtDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrtDoc.PrintPage
        Dim top As Integer = 0
        Dim left As Integer = 0
        Static ImageValue As System.Drawing.Image
        Dim Imagesforwidth As Integer = 0
        Dim ImagesforHeight As Integer = 0
        Static ImageNumber As Integer = 0
        Static Noprintimages As Integer = 1
        Static totalPrintImages As Integer = 0
        Imagesforwidth = PaperWidth \ (CInt(TxtWidth.Text))
        ImagesforHeight = PaperHeight \ (CInt(txtheight.Text))
        top = 10
        If TxtPaperSize.Text = "RollPaper" Then
            top = TxtTopGap.Value
        End If
        If ImageList.Items.Count = 0 Then
            e.HasMorePages = False
            Exit Sub
        End If
        For rowno As Integer = 1 To ImagesforHeight
            left = 10
            If TxtPaperSize.Text = "RollPaper" Then
                left = TxtLeftGap.Value
            End If
            For colno As Integer = 1 To Imagesforwidth
                If Noprintimages = 1 Then
                    Dim barcodename As String = ""
                    Dim PriceName As String = ""
                    barcodename = ImageList.Items(ImageNumber)
                    If IsPrintStockCodewithPrice.Checked = True Then
                        PriceName = " " & txtpriceSysmbol.Text & FormatNumber(GetStockRateByPriceListName(TxtPriceLevel.Text, barcodename, GetDefLocationName), 2)
                    Else
                        PriceName = ""
                    End If
                    Dim bcode As New BarcodeLib.Barcode()
                    bcode.Alignment = BarcodeLib.AlignmentPositions.CENTER
                    bcode.IncludeLabel = False
                    bcode.HeaderText2 = ""
                    bcode.FooterText1 = ""
                    bcode.FooterText2 = ""
                    bcode.FooterText3 = ""
                    bcode.LabelPrintText = ""
                    If TxtIsPrintLabel.Checked = True And IsPrintStockCodeAlso.Checked = True Then
                        bcode.IncludeLabel = True
                        If BarcodeOnTop.Checked = True And StockCodeOnTop.Checked = True Then
                            If IsFirstBarcode.Checked = True Then
                                bcode.LabelPrintText = barcodename
                                bcode.HeaderText2 = StockCodeList.Items(ImageNumber)
                                bcode.LabelPosition = BarcodeLib.LabelPositions.TOPCENTER
                            Else
                                bcode.LabelPrintText = StockCodeList.Items(ImageNumber)
                                bcode.HeaderText2 = barcodename
                                bcode.LabelPosition = BarcodeLib.LabelPositions.TOPCENTER
                            End If
                        ElseIf BarcodeonButtom.Checked = True And StockCodeOnTop.Checked = True Then
                            bcode.LabelPrintText = StockCodeList.Items(ImageNumber)
                            bcode.LabelPosition = BarcodeLib.LabelPositions.TOPCENTER
                            bcode.FooterText1 = barcodename
                        ElseIf BarcodeOnTop.Checked = True And StockCodeOnButtom.Checked = True Then
                            bcode.LabelPrintText = barcodename
                            bcode.LabelPosition = BarcodeLib.LabelPositions.TOPCENTER
                            bcode.FooterText1 = StockCodeList.Items(ImageNumber)
                        Else
                            If IsFirstBarcode.Checked = False Then
                                bcode.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER
                                bcode.LabelPrintText = barcodename
                                bcode.FooterText2 = StockCodeList.Items(ImageNumber)
                            Else
                                bcode.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER
                                bcode.FooterText2 = barcodename
                                bcode.LabelPrintText = StockCodeList.Items(ImageNumber)
                            End If
                            'IsFirstBarcode
                        End If

                    ElseIf IsPrintStockCodeAlso.Checked = True Then

                        bcode.IncludeLabel = True
                        If StockCodeOnButtom.Checked = True Then
                            bcode.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER
                            bcode.LabelPrintText = StockCodeList.Items(ImageNumber)

                        Else
                            bcode.LabelPosition = BarcodeLib.LabelPositions.TOPCENTER
                            bcode.LabelPrintText = StockCodeList.Items(ImageNumber)
                        End If

                    ElseIf TxtIsPrintLabel.Checked = True And IsPrintStockCodewithPrice.Checked = True Then
                        bcode.IncludeLabel = True
                        If BarcodeOnTop.Checked = True And StockCodeOnTop.Checked = True Then
                            If IsFirstBarcode.Checked = True Then
                                bcode.LabelPrintText = barcodename
                                bcode.HeaderText2 = StockCodeList.Items(ImageNumber) & PriceName
                                bcode.LabelPosition = BarcodeLib.LabelPositions.TOPCENTER
                            Else
                                bcode.LabelPrintText = StockCodeList.Items(ImageNumber) & PriceName
                                bcode.HeaderText2 = barcodename
                                bcode.LabelPosition = BarcodeLib.LabelPositions.TOPCENTER
                            End If
                        ElseIf BarcodeonButtom.Checked = True And StockCodeOnTop.Checked = True Then
                            bcode.LabelPrintText = StockCodeList.Items(ImageNumber) & PriceName
                            bcode.LabelPosition = BarcodeLib.LabelPositions.TOPCENTER
                            bcode.FooterText1 = barcodename
                        ElseIf BarcodeOnTop.Checked = True And StockCodeOnButtom.Checked = True Then
                            bcode.LabelPrintText = barcodename
                            bcode.LabelPosition = BarcodeLib.LabelPositions.TOPCENTER
                            bcode.FooterText1 = StockCodeList.Items(ImageNumber) & PriceName
                        Else
                            If IsFirstBarcode.Checked = False Then
                                bcode.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER
                                bcode.LabelPrintText = barcodename
                                bcode.FooterText2 = StockCodeList.Items(ImageNumber) & PriceName
                            Else
                                bcode.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER
                                bcode.FooterText2 = barcodename
                                bcode.LabelPrintText = StockCodeList.Items(ImageNumber) & PriceName
                            End If
                            'IsFirstBarcode
                        End If
                    ElseIf IsPrintStockCodewithPrice.Checked = True Then
                        bcode.IncludeLabel = True
                        If StockCodeOnButtom.Checked = True Then
                            bcode.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER
                            bcode.LabelPrintText = StockCodeList.Items(ImageNumber) & PriceName

                        Else
                            bcode.LabelPosition = BarcodeLib.LabelPositions.TOPCENTER
                            bcode.LabelPrintText = StockCodeList.Items(ImageNumber) & PriceName
                        End If
                    End If

                    bcode.LabelFont = New Font("Times New Roman", 12, FontStyle.Regular)
                    ' bcode.Encode(BcodeType, barcodename, 127, 40)
                    'bcode.Encode(BcodeType, barcodename, 290, 130)
                    bcode.Encode(BcodeType, barcodename, 435, 195)
                    'GetImageFromXML
                    '  Dim ms As New MemoryStream(bcode.GetImageData(BarcodeLib.SaveTypes.GIF ))
                    Dim ms As New MemoryStream(bcode.GetImageData(BarcodeLib.SaveTypes.BMP))
                    ImageValue = Image.FromStream(ms)
                End If
                e.Graphics.DrawImage(ImageValue, left, top, CInt(TxtWidth.Text), CInt(txtheight.Text) - 35)
                e.Graphics.DrawString("JYothi", New Font("Times New Roman", 12), Brushes.Black, left, top + CInt(txtheight.Text) - 25)
                totalPrintImages = totalPrintImages + 1
                Noprintimages = Noprintimages + 1
                If Noprintimages > CInt(TxtNoofCopies.Text) Then
                    Noprintimages = 1
                    ImageNumber = ImageNumber + 1
                End If
                If totalPrintImages = ImageList.Items.Count * CInt(TxtNoofCopies.Text) Then
                    Exit For
                End If
                left = left + CInt(TxtWidth.Text) + CInt(TxtHGap.Value)
            Next
            top = top + CInt(txtheight.Text) + CInt(TxtTopGap.Value)
            If totalPrintImages = ImageList.Items.Count * CInt(TxtNoofCopies.Text) Then
                Exit For
            End If
        Next
        'PhotoPathForBarcode
        If totalPrintImages = ImageList.Items.Count * CInt(TxtNoofCopies.Text) Then
            e.HasMorePages = False
            ImageNumber = 0
            Noprintimages = 1
            totalPrintImages = 0
        Else
            e.HasMorePages = True
        End If

    End Sub
    Function GetImageName(ByVal imageno As Integer) As String
        Return ""
    End Function
    Private Sub BtnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPreview.Click
        If TxtPaperSize.Text = "A4" Then
            PaperWidth = 827
            PaperHeight = 1169
        ElseIf TxtPaperSize.Text = "Letter" Then
            PaperWidth = 850
            PaperHeight = 1100
        ElseIf TxtPaperSize.Text = "Legal" Then

            PaperWidth = 850
            PaperHeight = 1400
        Else
            Dim TotalRows As Double = 1
            PaperWidth = TxtNoOfColumns.Value * CInt(TxtWidth.Text) + TxtLeftGap.Value + (TxtHGap.Value - 1) * TxtNoOfColumns.Value + 10
            TotalRows = Math.Ceiling((TxtList.SelectedRows.Count * CInt(TxtNoofCopies.Text)) / TxtNoOfColumns.Value)

            TotalRows = CInt(txtheight.Text) * TotalRows + TxtTopGap.Value + (TotalRows * TxtVGap.Value)
            'TotalRows = Math.Ceiling(PaperHeight / TxtNoOfColumns.Value)

            PaperHeight = CInt(TotalRows)

        End If
        If IsPrintStockCodewithPrice.Checked = True Then
            If TxtPriceLevel.Text.Length = 0 Then
                MsgBox("Please select the price list name... ", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If
        ImageList.Items.Clear()
        StockCodeList.Items.Clear()
        For Each x As DataGridViewRow In TxtList.SelectedRows
            ImageList.Items.Add(TxtList.Item("bar code", x.Index).Value)
            StockCodeList.Items.Add(TxtList.Item("Stock Code", x.Index).Value)
            'StockCodeList
        Next
        LoadReport()
        On Error Resume Next
        If UCase(TxtZoom.Text) = "AUTO" Then
            Me.PrintPreviewControl1.AutoZoom = True
        Else
            Me.PrintPreviewControl1.AutoZoom = False
            If TxtZoom.Text = "25%" Then
                Me.PrintPreviewControl1.Zoom = 0.25
            ElseIf TxtZoom.Text = "50%" Then
                Me.PrintPreviewControl1.Zoom = 0.5
            ElseIf TxtZoom.Text = "75%" Then
                Me.PrintPreviewControl1.Zoom = 0.75
            ElseIf TxtZoom.Text = "100%" Then
                Me.PrintPreviewControl1.Zoom = 1

            Else
                Me.PrintPreviewControl1.Zoom = 2

            End If
        End If
    End Sub

    Private Sub TxtGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtGroup.SelectedIndexChanged
        LoadStock()
    End Sub

    Private Sub TxtCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCat.SelectedIndexChanged
        LoadStock()
    End Sub

    Private Sub TxtZoom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtZoom.SelectedIndexChanged
        On Error Resume Next
        If UCase(TxtZoom.Text) = "AUTO" Then
            Me.PrintPreviewControl1.AutoZoom = True
        Else
            Me.PrintPreviewControl1.AutoZoom = False
            If TxtZoom.Text = "25%" Then
                Me.PrintPreviewControl1.Zoom = 0.25
            ElseIf TxtZoom.Text = "50%" Then
                Me.PrintPreviewControl1.Zoom = 0.5
            ElseIf TxtZoom.Text = "75%" Then
                Me.PrintPreviewControl1.Zoom = 0.75
            ElseIf TxtZoom.Text = "100%" Then
                Me.PrintPreviewControl1.Zoom = 1

            Else
                Me.PrintPreviewControl1.Zoom = 2

            End If
        End If
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        Me.Close()
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click
        Dim pvalues As New PrintParameters
        Dim printk As New BarCodePrtDlg(pvalues)

        If printk.ShowDialog = DialogResult.OK Then
            Dim ppd As New PrintPreviewDialog()
            PrtDoc.PrinterSettings.PrinterName = pvalues.PrinterName
            PrtDoc.PrinterSettings.PrinterName = pvalues.PrinterName
            ppd.Document = PrtDoc
            PrtDoc.PrinterSettings.Copies = pvalues.NoofCopies
            PrtDoc.PrinterSettings.PrinterName = pvalues.PrinterName
            PrtDoc.Print()
        End If
        printk.Dispose()
        pvalues = Nothing

    End Sub

    Private Sub UserButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton6.Click
        Try
            PrintPreviewControl1.StartPage = PrintPreviewControl1.StartPage + 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UserButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton5.Click
        Try
            PrintPreviewControl1.StartPage = PrintPreviewControl1.StartPage - 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        TxtList.SelectAll()
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        TxtList.ClearSelection()
    End Sub

    Private Sub TxtBarcodeType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBarcodeType.SelectedIndexChanged
        If TxtBarcodeType.Text = "ENA-13" Then
            BcodeType = BarcodeLib.TYPE.EAN13
        ElseIf TxtBarcodeType.Text = "CODE-39" Then
            BcodeType = BarcodeLib.TYPE.CODE39
        Else
            BcodeType = BarcodeLib.TYPE.CODE128

        End If

    End Sub

    Private Sub TxtPaperSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPaperSize.SelectedIndexChanged
        If TxtPaperSize.Text = "RollPaper" Then
            GroupBox3.Visible = True
        Else
            GroupBox3.Visible = False
        End If
    End Sub
End Class