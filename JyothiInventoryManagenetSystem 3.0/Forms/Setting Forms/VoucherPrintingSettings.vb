﻿Imports System.Drawing.Printing

Public Class VoucherPrintingSettings
   
    Dim NewFontStyle As New FontStyle
    Dim LeftSidelogoselected As Boolean = False
    Dim Rightsidelogoselected As Boolean = False
    Dim IsNewLine As Boolean = False
    Dim PrtDbf As New ADODB.Recordset
    Dim conn As New ADODB.Connection

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If txtFont.ShowDialog() Then
            TxtFLSample.Font = txtFont.Font
            TxtFLSample.ForeColor = txtFont.Color
            TxtFLFont.Text = txtFont.Font.Name
            If txtFont.Font.Underline = True Then
                TxtFLStyleU.Checked = True
            Else
                TxtFLStyleU.Checked = False
            End If
            If txtFont.Font.Bold = True Then
                TxtFLStyleB.Checked = True
            Else
                TxtFLStyleB.Checked = False
            End If
            If txtFont.Font.Italic = True Then
                TxtFLSytleI.Checked = True
            Else
                TxtFLSytleI.Checked = False
            End If
            TxtFLFontSize.Value = txtFont.Font.Size
            TxtFLFontColor.Text = txtFont.Color.Name.ToString

        End If

    End Sub

    Private Sub ObjAlign_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFLAlign.SelectedIndexChanged, TxtFLFAlign.SelectedIndexChanged
        If TxtFLAlign.Text = "Left" Then
            TxtFLSample.TextAlign = ContentAlignment.TopLeft
        ElseIf TxtFLAlign.Text = "Right" Then
            TxtFLSample.TextAlign = ContentAlignment.TopRight
        Else
            TxtFLSample.TextAlign = ContentAlignment.TopCenter
        End If
    End Sub


    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        'e.Graphics.DrawLine(Pens.Black, LeftMr + 10, txttop, 800, txttop)
        Dim inputval As String
        inputval = InputBox("Enter The Line Name ?", "Line Name", "")
        If inputval.Length > 0 Then
            If txtLineNames.Items.Contains(inputval) = False Then
                IsNewLine = True
                txtLineNames.Items.Add(inputval)
            Else
                MsgBox("The Name is already exists, Please Try Again")
            End If
        End If
    End Sub

    Private Sub VoucherPrintingSettings_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub InvoicePriningSettings_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        conn.Close()
    End Sub

    Private Sub SalesInvoicePrintingOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If My.Computer.Screen.WorkingArea.Width <= 1024 Then
            Me.Font = New Font(Me.Font.Name, 8, FontStyle.Regular)
        End If
        TxtPrinterName.Items.Clear()
        For Each s In Printing.PrinterSettings.InstalledPrinters
            TxtPrinterName.Items.Add(s)
        Next
        Try
            conn.ConnectionString = "Provider=SQLOLEDB;Data Source=" & TxtSoftwareSQlServer & ";Integrated Security=SSPI;Initial Catalog=" & TxtSoftwareSQLDatabaseName
            conn.Open()
        Catch ex As Exception
            MsgBox("Sql Connection error....")
            Me.Close()
        End Try
        LoadSchemesIntoBoxes()
        LoadDataIntoComboBox("select  distinct VoucherName from PrintingSchemes where SchemeType=2", TxtDefInvoiceList, "VoucherName")


        LoadDefauls()
        txtSchemName.SelectedIndex = 0
        PrintPreviewControl1.Zoom = 1
        PrintPreviewControl1.Refresh()
        TxtZoom.Text = "Auto"

    End Sub
    Sub LoadSchemesIntoBoxes()
        LoadDataIntoComboBox("select  schemename from VoucherPrintingSettings", txtSchemName, "schemename")
        LoadDataIntoComboBox("select  schemename from VoucherPrintingSettings ", TxtInvoiceSchameList, "schemename")

    End Sub
    Sub LoadDefauls()
        LeftSidelogoselected = False
        Rightsidelogoselected = False
        Dim Dbf As New ADODB.Recordset

        Dbf.Open("select * from VoucherPrintingSettings where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If Dbf.RecordCount > 0 Then
            TxtPrinterName.Text = Dbf.Fields("printername").Value.ToString
            TxtPaperWidth.Text = Dbf.Fields("width").Value
            TxtPaperHeight.Text = Dbf.Fields("height").Value
            If Dbf.Fields("islandscape").Value = True Then
                prtOrientationLand.Checked = True
            Else
                prtOrientationPort.Checked = True
            End If
            pageleftmargin.Value = Dbf.Fields("fleft").Value
            pagerighttmargin.Value = Dbf.Fields("fright").Value
            pagetopmargin.Value = Dbf.Fields("ftop").Value
            pagebuttommargin.Value = Dbf.Fields("fbuttom").Value
            If Dbf.Fields("LeftLogoIsOn").Value = True Then
                TxtIsLeftLogoOn.Checked = True
            Else
                TxtIsLeftLogoOn.Checked = False
            End If
            '  MsgBox(Dbf.Fields("LeftLogoIsOn").Value)
            txtleftEdge.Text = Dbf.Fields("Leftlogoleft").Value
            txtlefttop.Text = Dbf.Fields("leftlogotop").Value
            txtleftwidth.Text = Dbf.Fields("Leftlogowidth").Value
            txtleftheight.Text = Dbf.Fields("Leftlogoheight").Value
            Try
                txtleftlogobox.ImageLocation = Dbf.Fields("leftlogopath").Value
            Catch ex As Exception

            End Try

            If Dbf.Fields("rightLogoIsOn").Value = True Then
                TxtIsRightLogoOn.Checked = True
            Else
                TxtIsRightLogoOn.Checked = False
            End If
            txtrightedge.Text = Dbf.Fields("rightlogoleft").Value
            txtrighttop.Text = Dbf.Fields("rightlogotop").Value
            txtrightwidth.Text = Dbf.Fields("rightlogowidth").Value
            txtrightheight.Text = Dbf.Fields("rightlogoheight").Value
            Try
                txtRightLogobox.ImageLocation = Dbf.Fields("rightlogopath").Value
            Catch ex As Exception

            End Try
            If Dbf.Fields("showpageno").Value = True Then
                IsShownPageNos.Checked = True
            Else
                IsShownPageNos.Checked = False
            End If
            TxtPageNoLeft.Value = Dbf.Fields("pagenoleft").Value
            TxtPageNoTop.Value = Dbf.Fields("pagenotop").Value
            TxtPageNoFormat.SelectedIndex = Dbf.Fields("pageformat").Value

        End If
        Dbf.Close()

        '  Dim Dbf As New ADODB.Recordset
        TxtFieldLables.Items.Clear()
        Dbf.Open("select * from VoucherPrintFieldLabels where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If Dbf.RecordCount > 0 Then
            Dbf.MoveFirst()

            For i As Integer = 0 To Dbf.RecordCount - 1
                TxtFieldLables.Items.Add(Dbf.Fields("fieldname").Value)
                Dbf.MoveNext()
            Next
        End If
        Dbf.Close()

        TxtrecordItems.Items.Clear()
        Dbf.Open("select * from VoucherPrintRecords where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If Dbf.RecordCount > 0 Then
            Dbf.MoveFirst()
            For i As Integer = 0 To Dbf.RecordCount - 1
                TxtrecordItems.Items.Add(Dbf.Fields("fieldname").Value)
                Dbf.MoveNext()
            Next
        End If
        Dbf.Close()

        txtheadingitems.Items.Clear()
        Dbf.Open("select * from VoucherPrintHeadings where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If Dbf.RecordCount > 0 Then
            Dbf.MoveFirst()
            For i As Integer = 0 To Dbf.RecordCount - 1
                txtheadingitems.Items.Add(Dbf.Fields("fieldname").Value)
                Dbf.MoveNext()
            Next
        End If
        Dbf.Close()

        'txtLineNames


        txtLineNames.Items.Clear()
        Dbf.Open("select * from VoucherPrintingLines where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If Dbf.RecordCount > 0 Then
            Dbf.MoveFirst()
            For i As Integer = 0 To Dbf.RecordCount - 1
                txtLineNames.Items.Add(Dbf.Fields("fieldname").Value)
                Dbf.MoveNext()
            Next
        End If
        Dbf.Close()


        TxtLabelLists.Items.Clear()
        Dbf.Open("select * from VoucherPrintingLables where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If Dbf.RecordCount > 0 Then
            Dbf.MoveFirst()
            For i As Integer = 0 To Dbf.RecordCount - 1
                TxtLabelLists.Items.Add(Dbf.Fields("fieldname").Value)
                Dbf.MoveNext()
            Next
        End If
        Dbf.Close()


        Dbf.Open("select * from VoucherPrintRecords where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If Dbf.RecordCount > 0 Then
            Dbf.MoveFirst()
            TxtRtop.Value = Dbf.Fields("ftop").Value
            TxtRlTop.Value = Dbf.Fields("ltop").Value
            TxtLineSpecing.Value = Dbf.Fields("space").Value
            TxtRFHeight.Value = Dbf.Fields("height").Value
        End If
        Dbf.Close()


    End Sub


    Private Sub TxtIsLeftLogoOn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIsLeftLogoOn.CheckedChanged
        If TxtIsLeftLogoOn.Checked = True Then
            Panel3.Enabled = True
        Else
            Panel3.Enabled = False
        End If
    End Sub

    Private Sub TxtIsRightLogoOn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIsRightLogoOn.CheckedChanged
        If TxtIsRightLogoOn.Checked = True Then
            Panel4.Enabled = True
        Else
            Panel4.Enabled = False
        End If
    End Sub


    Private Sub txtrightedge_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtrightedge.Validating, txtrightwidth.Validating, txtrighttop.Validating, txtrightheight.Validating, TxtPaperWidth.Validating, TxtPaperHeight.Validating, txtleftwidth.Validating, txtlefttop.Validating, txtleftheight.Validating, txtleftEdge.Validating
        If IsNumeric(sender.text) = False Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub


    Private Sub btnselectleftlogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnselectleftlogo.Click
        OpenPicture.Title = "Select The Image for Left Side Logo"
        If OpenPicture.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtleftlogobox.ImageLocation = OpenPicture.FileName
            LeftSidelogoselected = True
        End If
    End Sub

    Private Sub btnselectrightlogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnselectrightlogo.Click
        OpenPicture.Title = "Select The Image for Left Side Logo"
        If OpenPicture.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtRightLogobox.ImageLocation = OpenPicture.FileName
            Rightsidelogoselected = True
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If txtFont.ShowDialog() Then


            TxtHeadFontName.Text = txtFont.Font.Name
            If txtFont.Font.Underline = True Then
                TxtHeadStyleU.Checked = True
            Else
                TxtHeadStyleU.Checked = False
            End If
            If txtFont.Font.Bold = True Then
                TxtHeadStyleB.Checked = True
            Else
                TxtHeadStyleB.Checked = False
            End If
            If txtFont.Font.Italic = True Then
                TxtHeadStyleI.Checked = True
            Else
                TxtHeadStyleI.Checked = False
            End If
            TxtHeadFontSize.Value = txtFont.Font.Size
            TxtHeadFontColor.Text = txtFont.Color.Name.ToString

        End If
    End Sub

    Private Sub PrtDoc_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrtDoc.BeginPrint
        PrtDoc.DefaultPageSettings.PaperSize = New PaperSize("Custom", TxtPaperWidth.Text, TxtPaperHeight.Text)
        If prtOrientationLand.Checked = True Then
            PrtDoc.DefaultPageSettings.Landscape = True
        Else
            PrtDoc.DefaultPageSettings.Landscape = False
        End If
        PrtDoc.DefaultPageSettings.Margins.Left = pageleftmargin.Value
        PrtDoc.DefaultPageSettings.Margins.Right = pagerighttmargin.Value
        PrtDoc.DefaultPageSettings.Margins.Top = pagetopmargin.Value
        PrtDoc.DefaultPageSettings.Margins.Bottom = pagebuttommargin.Value


    End Sub

    Private Sub PrtDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrtDoc.PrintPage
        If txtSchemName.Text.Length = 0 Then
            Exit Sub
        End If
        Static IsFirstOpen As Boolean = True
        Static pagerecords As Integer = 0
        Static PresentRecords As Integer = 0
        Static PageTop As Double = 0
        Static PageSpace As Double = 0
        Static RowHeight As Double = 0
        Static PageNos As Integer = 1
        Static PageNo As Integer = 1
        Static Pagenoformat As Byte = 0
        Static isPageNoyesno As Boolean = True
        Static PageTopConst As Double = 0
        Static FooterTop As Integer = 0
        Dim PageTotal As Double = 0
        Dim Dbf As New ADODB.Recordset
        Dim Dbfr As New ADODB.Recordset




        If IsFirstOpen = True Then
            IsFirstOpen = False
            PrtDoc.DefaultPageSettings.PaperSize = New PaperSize("Custom", TxtPaperWidth.Text, TxtPaperHeight.Text)
            If prtOrientationLand.Checked = True Then
                PrtDoc.DefaultPageSettings.Landscape = True
            Else
                PrtDoc.DefaultPageSettings.Landscape = False
            End If
            PrtDoc.DefaultPageSettings.Margins.Left = pageleftmargin.Value
            PrtDoc.DefaultPageSettings.Margins.Right = pagerighttmargin.Value
            PrtDoc.DefaultPageSettings.Margins.Top = pagetopmargin.Value
            PrtDoc.DefaultPageSettings.Margins.Bottom = pagebuttommargin.Value
            Dbf.Open("select * from VoucherPrintingSettings where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If Dbf.RecordCount > 0 Then
                pagerecords = Dbf.Fields("maxrowsperpage").Value
                RowHeight = Dbf.Fields("rowheight").Value
                FooterTop = Dbf.Fields("ftop").Value + Dbf.Fields("height").Value
            End If
            PresentRecords = 1
            Dbf.Close()



            Dbf.Open("select * from VoucherPrintRecords where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If Dbf.RecordCount > 0 Then
                PageTop = Dbf.Fields("ftop").Value
                PageSpace = Dbf.Fields("space").Value
                'mod
                FooterTop = Dbf.Fields("ftop").Value + Dbf.Fields("height").Value
            End If
            Dbf.Close()
            PageTopConst = PageTop
            PrtDbf.Open("select * from PrintingDataRowsItems ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            PrtDbf.MoveFirst()
            If PrtDbf.RecordCount < pagerecords Then
                pagerecords = PrtDbf.RecordCount
            End If
            PageNos = Math.Ceiling(PrtDbf.RecordCount / pagerecords)
            PageNo = 1
        End If



        Dim ImageValue As System.Drawing.Image

        'OUTLINES
        Dim Outlinepen1 As New Pen(Brushes.DarkCyan, 1)
        Dim Outlinepen2 As New Pen(Brushes.Red, 1)
        Outlinepen1.DashStyle = Drawing2D.DashStyle.Dot
        Outlinepen2.DashStyle = Drawing2D.DashStyle.Dot
        If prtOrientationLand.Checked = True Then
            e.Graphics.DrawRectangle(Outlinepen1, CSng(pageleftmargin.Value), CSng(pagetopmargin.Value), CSng(TxtPaperHeight.Text) - CSng(pagetopmargin.Value) - CSng(pagebuttommargin.Value), CSng(TxtPaperWidth.Text) - CSng(pageleftmargin.Value) - CSng(pagerighttmargin.Value))
            e.Graphics.DrawRectangle(Outlinepen2, CSng(pageleftmargin.Value), CSng(TxtRtop.Value), CSng(TxtPaperHeight.Text) - CSng(pagetopmargin.Value) - CSng(pagebuttommargin.Value), CSng(TxtRFHeight.Text) - CSng(pageleftmargin.Value) - CSng(pagerighttmargin.Value))
        Else
            e.Graphics.DrawRectangle(Outlinepen1, CSng(pageleftmargin.Value), CSng(pagetopmargin.Value), CSng(TxtPaperWidth.Text) - CSng(pageleftmargin.Value) - CSng(pagerighttmargin.Value), CSng(TxtPaperHeight.Text) - CSng(pagetopmargin.Value) - CSng(pagebuttommargin.Value))
            e.Graphics.DrawRectangle(Outlinepen2, CSng(pageleftmargin.Value), CSng(TxtRtop.Value), CSng(TxtPaperWidth.Text) - CSng(pagetopmargin.Value) - CSng(pagerighttmargin.Value), CSng(TxtRFHeight.Text))
        End If


        Try
            If TxtIsLeftLogoOn.Checked = True Then
                ImageValue = Image.FromFile(txtleftlogobox.ImageLocation)
                e.Graphics.DrawImage(ImageValue, CSng(txtleftEdge.Text), CSng(txtlefttop.Text), CSng(txtleftwidth.Text), CSng(txtleftheight.Text))
            End If
        Catch ex As Exception
        End Try

        Try
            If TxtIsRightLogoOn.Checked = True Then
                ImageValue = Image.FromFile(txtRightLogobox.ImageLocation)
                e.Graphics.DrawImage(ImageValue, CSng(txtrightedge.Text), CSng(txtrighttop.Text), CSng(txtrightwidth.Text), CSng(txtrightheight.Text))
            End If
        Catch ex As Exception

        End Try

        If PageNo = PageNos Then
            Dbf.Open("select * from VoucherPrintFieldLabels where schemename=N'" & txtSchemName.Text & "' ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        Else
            Dbf.Open("select * from VoucherPrintFieldLabels where schemename=N'" & txtSchemName.Text & "' and ltop<" & FooterTop, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        End If


        If Dbf.RecordCount > 0 Then
            Dbf.MoveFirst()
            For i As Integer = 0 To Dbf.RecordCount - 1
                If Dbf.Fields("IsVisible").Value = True Then
                    Dim drawFormat As New StringFormat
                    Dim drawFont As Font = New Font("arial", 10)
                    Dim drawBrush As New SolidBrush(Color.FromName(Dbf.Fields("fontcolor").Value.ToString))

                    Select Case Dbf.Fields("fontstyle").Value
                        Case 1
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Bold)
                        Case 2
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Italic)
                        Case 3
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Underline)
                        Case 4
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Bold Or FontStyle.Italic)
                        Case 5
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Bold Or FontStyle.Underline)
                        Case 6
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Italic Or FontStyle.Underline)
                        Case 7
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                        Case 8
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Regular)

                    End Select



                    If Dbf.Fields("align").Value = "Left" Then
                        drawFormat.Alignment = StringAlignment.Near
                    ElseIf Dbf.Fields("align").Value = "Right" Then
                        drawFormat.Alignment = StringAlignment.Far
                    Else
                        drawFormat.Alignment = StringAlignment.Center
                    End If



                    '   e.Graphics.DrawString("Sl", font1, Brushes.Black, rect1, StringFormat)

                    If CSng(Dbf.Fields("width").Value) > 50 Then
                        Dim rect1 As New Rectangle(CSng(Dbf.Fields("fleft").Value), CSng(Dbf.Fields("ftop").Value), CSng(Dbf.Fields("width").Value), CSng(Dbf.Fields("height").Value))
                        If Dbf.Fields("formattype").Value = 0 Then
                            e.Graphics.DrawString(Dbf.Fields("sample").Value.ToString, drawFont, drawBrush, rect1, drawFormat)
                        Else
                            e.Graphics.DrawString(FormatNumber(Dbf.Fields("sample").Value, ErpDecimalPlaces).ToString, drawFont, drawBrush, rect1, drawFormat)
                        End If


                    Else
                        If Dbf.Fields("formattype").Value = 0 Then
                            e.Graphics.DrawString(Dbf.Fields("sample").Value.ToString, drawFont, drawBrush, CSng(Dbf.Fields("fleft").Value), CSng(Dbf.Fields("ftop").Value), drawFormat)
                        Else
                            e.Graphics.DrawString(FormatNumber(Dbf.Fields("sample").Value, ErpDecimalPlaces).ToString, drawFont, drawBrush, CSng(Dbf.Fields("fleft").Value), CSng(Dbf.Fields("ftop").Value), drawFormat)
                        End If
                    End If



                    Select Case Dbf.Fields("lfontstyle").Value
                        Case 1
                            drawFont = New Font(Dbf.Fields("lFontname").Value.ToString, CSng(Dbf.Fields("lfontsize").Value), FontStyle.Bold)
                        Case 2
                            drawFont = New Font(Dbf.Fields("lFontname").Value.ToString, CSng(Dbf.Fields("lfontsize").Value), FontStyle.Italic)
                        Case 3
                            drawFont = New Font(Dbf.Fields("lFontname").Value.ToString, CSng(Dbf.Fields("lfontsize").Value), FontStyle.Underline)
                        Case 4
                            drawFont = New Font(Dbf.Fields("lFontname").Value.ToString, CSng(Dbf.Fields("lfontsize").Value), FontStyle.Bold Or FontStyle.Italic)
                        Case 5
                            drawFont = New Font(Dbf.Fields("lFontname").Value.ToString, CSng(Dbf.Fields("lfontsize").Value), FontStyle.Bold Or FontStyle.Underline)
                        Case 6
                            drawFont = New Font(Dbf.Fields("lFontname").Value.ToString, CSng(Dbf.Fields("lfontsize").Value), FontStyle.Italic Or FontStyle.Underline)
                        Case 7
                            drawFont = New Font(Dbf.Fields("lFontname").Value.ToString, CSng(Dbf.Fields("lfontsize").Value), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                        Case 8
                            drawFont = New Font(Dbf.Fields("lFontname").Value.ToString, CSng(Dbf.Fields("lfontsize").Value), FontStyle.Regular)

                    End Select



                    drawBrush.Color = Color.FromName(Dbf.Fields("lfontcolor").Value.ToString)
                    If Dbf.Fields("lalign").Value = "Left" Then
                        drawFormat.Alignment = StringAlignment.Near
                    ElseIf Dbf.Fields("lalign").Value = "Right" Then
                        drawFormat.Alignment = StringAlignment.Far
                    Else
                        drawFormat.Alignment = StringAlignment.Center
                    End If

                    e.Graphics.DrawString(Dbf.Fields("labletext").Value.ToString, drawFont, drawBrush, CSng(Dbf.Fields("lleft").Value), CSng(Dbf.Fields("ltop").Value), drawFormat)

                End If
                Dbf.MoveNext()
            Next
        End If
        Dbf.Close()




        Dbf.Open("select * from VoucherPrintingLables where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If Dbf.RecordCount > 0 Then
            Dbf.MoveFirst()
            For i As Integer = 0 To Dbf.RecordCount - 1
                If Dbf.Fields("IsVisible").Value = True Then
                    Dim drawFormat As New StringFormat
                    Dim drawFont As Font = New Font("arial", 10)
                    Dim drawBrush As New SolidBrush(Color.FromName(Dbf.Fields("fontcolor").Value.ToString))
                    Select Case Dbf.Fields("fontstyle").Value
                        Case 1
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Bold)
                        Case 2
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Italic)
                        Case 3
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Underline)
                        Case 4
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Bold Or FontStyle.Italic)
                        Case 5
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Bold Or FontStyle.Underline)
                        Case 6
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Italic Or FontStyle.Underline)
                        Case 7
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                        Case 8
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Regular)

                    End Select



                    If Dbf.Fields("align").Value = "Left" Then
                        drawFormat.Alignment = StringAlignment.Near
                    ElseIf Dbf.Fields("align").Value = "Right" Then
                        drawFormat.Alignment = StringAlignment.Far
                    Else
                        drawFormat.Alignment = StringAlignment.Center
                    End If
                    'Modified Start
                    If CSng(Dbf.Fields("width").Value) > 50 Then
                        Dim rect1 As New Rectangle(CSng(Dbf.Fields("fleft").Value), CSng(Dbf.Fields("ftop").Value), CSng(Dbf.Fields("width").Value), CSng(Dbf.Fields("height").Value))
                        e.Graphics.DrawString(Dbf.Fields("labletext").Value.ToString, drawFont, drawBrush, rect1, drawFormat)
                    Else
                        e.Graphics.DrawString(Dbf.Fields("labletext").Value.ToString, drawFont, drawBrush, CSng(Dbf.Fields("fleft").Value), CSng(Dbf.Fields("ftop").Value), drawFormat)
                    End If
                    'Modified End
                    'e.Graphics.DrawString(Dbf.Fields("labletext").Value.ToString, drawFont, drawBrush, CSng(Dbf.Fields("fleft").Value), CSng(Dbf.Fields("ftop").Value), drawFormat)
                End If
                Dbf.MoveNext()
            Next
        End If
        Dbf.Close()

        Dbf.Open("select * from VoucherPrintHeadings where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If Dbf.RecordCount > 0 Then
            Dbf.MoveFirst()
            For i As Integer = 0 To Dbf.RecordCount - 1
                If Dbf.Fields("IsVisible").Value = True Then
                    Dim drawFormat As New StringFormat
                    Dim drawFont As Font = New Font("arial", 10)
                    Dim drawBrush As New SolidBrush(Color.FromName(Dbf.Fields("fontcolor").Value.ToString))

                    Select Case Dbf.Fields("fontstyle").Value
                        Case 1
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Bold)
                        Case 2
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Italic)
                        Case 3
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Underline)
                        Case 4
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Bold Or FontStyle.Italic)
                        Case 5
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Bold Or FontStyle.Underline)
                        Case 6
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Italic Or FontStyle.Underline)
                        Case 7
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                        Case 8
                            drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Regular)

                    End Select


                    If Dbf.Fields("align").Value = "Left" Then
                        drawFormat.Alignment = StringAlignment.Near
                    ElseIf Dbf.Fields("align").Value = "Right" Then
                        drawFormat.Alignment = StringAlignment.Far
                    Else
                        drawFormat.Alignment = StringAlignment.Center
                    End If
                    e.Graphics.DrawString(Dbf.Fields("HeadText").Value.ToString, drawFont, drawBrush, CSng(Dbf.Fields("fleft").Value), CSng(Dbf.Fields("ftop").Value), drawFormat)
                End If
                Dbf.MoveNext()
            Next
        End If
        Dbf.Close()



       

        Dbf.Open("select * from VoucherPrintingLines where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If Dbf.RecordCount > 0 Then
            Dbf.MoveFirst()
            For i As Integer = 0 To Dbf.RecordCount - 1
                If Dbf.Fields("IsVisible").Value = True Then
                    Dim penstyle As New Pen(Color.FromName(Dbf.Fields("LineColor").Value), CSng(Dbf.Fields("BoarderWidth").Value))

                    If Dbf.Fields("BoarderStyle").Value = "Solid" Then
                        penstyle.DashStyle = Drawing2D.DashStyle.Solid
                    ElseIf Dbf.Fields("BoarderStyle").Value = "Dash" Then
                        penstyle.DashStyle = Drawing2D.DashStyle.Dash
                    ElseIf Dbf.Fields("BoarderStyle").Value = "Dot" Then
                        penstyle.DashStyle = Drawing2D.DashStyle.Dot
                    ElseIf Dbf.Fields("BoarderStyle").Value = "DashDot" Then
                        penstyle.DashStyle = Drawing2D.DashStyle.DashDot
                    Else
                        penstyle.DashStyle = Drawing2D.DashStyle.DashDotDot
                    End If
                    If Dbf.Fields("FieldType").Value = 0 Then
                        e.Graphics.DrawLine(penstyle, CSng(Dbf.Fields("fleft").Value), CSng(Dbf.Fields("ftop").Value), CSng(Dbf.Fields("width").Value), CSng(Dbf.Fields("height").Value))
                    Else
                        e.Graphics.DrawRectangle(penstyle, CSng(Dbf.Fields("fleft").Value), CSng(Dbf.Fields("ftop").Value), CSng(Dbf.Fields("width").Value), CSng(Dbf.Fields("height").Value))
                    End If
                End If
                Dbf.MoveNext()
            Next
        End If
        Dbf.Close()


        Dbf.Open("select * from VoucherPrintRecords where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If Dbf.RecordCount > 0 Then
            Dbf.MoveFirst()
            For i As Integer = 0 To Dbf.RecordCount - 1
                If Dbf.Fields("IsVisible").Value = True Then
                    Dim drawFormat As New StringFormat
                    Dim drawFont As Font = New Font("arial", 10)
                    Dim drawBrush As New SolidBrush(Color.FromName(Dbf.Fields("lfontcolor").Value.ToString))

                    Select Case Dbf.Fields("lfontstyle").Value
                        Case 1
                            drawFont = New Font(Dbf.Fields("lFontname").Value.ToString, CSng(Dbf.Fields("lfontsize").Value), FontStyle.Bold)
                        Case 2
                            drawFont = New Font(Dbf.Fields("lFontname").Value.ToString, CSng(Dbf.Fields("lfontsize").Value), FontStyle.Italic)
                        Case 3
                            drawFont = New Font(Dbf.Fields("lFontname").Value.ToString, CSng(Dbf.Fields("lfontsize").Value), FontStyle.Underline)
                        Case 4
                            drawFont = New Font(Dbf.Fields("lFontname").Value.ToString, CSng(Dbf.Fields("lfontsize").Value), FontStyle.Bold Or FontStyle.Italic)
                        Case 5
                            drawFont = New Font(Dbf.Fields("lFontname").Value.ToString, CSng(Dbf.Fields("lfontsize").Value), FontStyle.Bold Or FontStyle.Underline)
                        Case 6
                            drawFont = New Font(Dbf.Fields("lFontname").Value.ToString, CSng(Dbf.Fields("lfontsize").Value), FontStyle.Italic Or FontStyle.Underline)
                        Case 7
                            drawFont = New Font(Dbf.Fields("lFontname").Value.ToString, CSng(Dbf.Fields("lfontsize").Value), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                        Case 8
                            drawFont = New Font(Dbf.Fields("lFontname").Value.ToString, CSng(Dbf.Fields("lfontsize").Value), FontStyle.Regular)

                    End Select


                    If Dbf.Fields("lalign").Value = "Left" Then
                        drawFormat.Alignment = StringAlignment.Near
                    ElseIf Dbf.Fields("lalign").Value = "Right" Then
                        drawFormat.Alignment = StringAlignment.Far
                    Else
                        drawFormat.Alignment = StringAlignment.Center
                    End If

                    If UCase(Dbf.Fields("Fieldname").Value.ToString) = "cashbankaccount" Then
                        Dbfr.Open("select * from VoucherPrintingData where transcode=0", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
                        Dim rn As Integer = 0
                        If Dbfr.RecordCount > 0 Then
                            Dbfr.MoveFirst()
                            For m As Integer = 1 To Dbfr.RecordCount
                                If IsBankLedger(Dbfr.Fields("ledgername").Value) = True Then
                                    e.Graphics.DrawString(Dbfr.Fields("ledgername").Value.ToString, drawFont, drawBrush, CSng(Dbf.Fields("lleft").Value), CSng(Dbf.Fields("ltop").Value) + rn * RowHeight, drawFormat)
                                    rn = rn + 1
                                    e.Graphics.DrawString((Dbfr.Fields("dr").Value + Dbfr.Fields("Cr").Value).ToString, drawFont, drawBrush, CSng(Dbf.Fields("lleft").Value) + 120, CSng(Dbf.Fields("ltop").Value) + rn * RowHeight, drawFormat)

                                End If
                                Dbfr.MoveNext()
                            Next
                        End If
                        Dbfr.Close()
                    ElseIf UCase(Dbf.Fields("Fieldname").Value.ToString) = "netamount" Then
                        Dbfr.Open("select sum(dr) as tot from VoucherPrintingData where transcode=0", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
                        If Dbfr.RecordCount > 0 Then
                            Dbfr.MoveFirst()
                            e.Graphics.DrawString(Dbfr.Fields("tot").Value.ToString, drawFont, drawBrush, CSng(Dbf.Fields("lleft").Value), CSng(Dbf.Fields("ltop").Value), drawFormat)
                        End If
                        Dbfr.Close()
                    ElseIf UCase(Dbf.Fields("Fieldname").Value.ToString) = "DrCrAmount" Then


                    ElseIf UCase(Dbf.Fields("Fieldname").Value.ToString) = "LedgerAcounts" Then

                        Dbfr.Open("select * from VoucherPrintingData where transcode=0", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
                        Dim rn As Integer = 0
                        If Dbfr.RecordCount > 0 Then
                            Dbfr.MoveFirst()
                            For m As Integer = 1 To Dbfr.RecordCount
                                If IsBankLedger(Dbfr.Fields("ledgername").Value) = False Then
                                    e.Graphics.DrawString(Dbfr.Fields("ledgername").Value.ToString, drawFont, drawBrush, CSng(Dbf.Fields("lleft").Value), CSng(Dbf.Fields("ltop").Value) + rn * RowHeight, drawFormat)
                                    rn = rn + 1
                                End If
                                Dbfr.MoveNext()
                            Next
                        End If
                        Dbfr.Close()

                    End If




                End If
                Dbf.MoveNext()
            Next
        End If
        Dbf.Close()



        For ri As Integer = 1 To pagerecords
            Dbf.Open("select * from VoucherPrintRecords where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If Dbf.RecordCount > 0 Then
                Dbf.MoveFirst()
                For i As Integer = 0 To Dbf.RecordCount - 1
                    If Dbf.Fields("IsVisible").Value = True Then
                        Dim drawFormat As New StringFormat
                        Dim drawFont As Font = New Font("arial", 10)
                        Dim drawBrush As New SolidBrush(Color.FromName(Dbf.Fields("fontcolor").Value.ToString))
                        Select Case Dbf.Fields("fontstyle").Value
                            Case 1
                                drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Bold)
                            Case 2
                                drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Italic)
                            Case 3
                                drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Underline)
                            Case 4
                                drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Bold Or FontStyle.Italic)
                            Case 5
                                drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Bold Or FontStyle.Underline)
                            Case 6
                                drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Italic Or FontStyle.Underline)
                            Case 7
                                drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                            Case 8
                                drawFont = New Font(Dbf.Fields("Fontname").Value.ToString, CSng(Dbf.Fields("fontsize").Value), FontStyle.Regular)

                        End Select


                        If Dbf.Fields("align").Value = "Left" Then
                            drawFormat.Alignment = StringAlignment.Near
                        ElseIf Dbf.Fields("align").Value = "Right" Then
                            drawFormat.Alignment = StringAlignment.Far
                        Else
                            drawFormat.Alignment = StringAlignment.Center
                        End If


                        If UCase(Dbf.Fields("Fieldname").Value.ToString) = "cashbankaccount" Then
                            Dbfr.Open("select * from VoucherPrintingData ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
                            If Dbfr.RecordCount > 0 Then
                                Dbfr.MoveFirst()
                                For m As Integer = 1 To Dbfr.RecordCount
                                    If IsBankLedger(Dbfr.Fields("ledgername").Value) = True Then
                                        e.Graphics.DrawString(Dbfr.Fields("ledgername").Value, drawFont, drawBrush, CSng(Dbf.Fields("fleft").Value), PageTop, drawFormat)
                                        PageTop = PageTop + RowHeight
                                    End If
                                Next
                            End If

                            If Dbf.Fields("formattype").Value = 0 Then
                                e.Graphics.DrawString(PrtDbf.Fields(Dbf.Fields("DBField").Value.ToString).Value.ToString, drawFont, drawBrush, CSng(Dbf.Fields("fleft").Value), PageTop, drawFormat)
                            Else
                                e.Graphics.DrawString(FormatNumber(PrtDbf.Fields(Dbf.Fields("DBField").Value.ToString).Value, ErpDecimalPlaces).ToString, drawFont, drawBrush, CSng(Dbf.Fields("fleft").Value), PageTop, drawFormat)
                            End If

                        ElseIf UCase(Dbf.Fields("Fieldname").Value.ToString) = "netamount" Then

                        ElseIf UCase(Dbf.Fields("Fieldname").Value.ToString) = "DrCrAmount" Then

                        ElseIf UCase(Dbf.Fields("Fieldname").Value.ToString) = "LedgerAcounts" Then

                            e.Graphics.DrawString(PresentRecords, drawFont, drawBrush, CSng(Dbf.Fields("fleft").Value), PageTop, drawFormat)
                        End If

                    End If

                    Dbf.MoveNext()
                Next

            End If
            Dbf.Close()

            Try
                PageTop = PageTop + RowHeight
                PresentRecords = PresentRecords + 1
                PrtDbf.MoveNext()

            Catch ex As Exception
                PresentRecords = PrtDbf.RecordCount
                GoTo sss
            End Try
            

        Next





SSS:
        Dbf.Open("select * from VoucherPrintingSettings where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If Dbf.RecordCount > 0 Then
            If Dbf.Fields("showpageno").Value = True Then
                If Dbf.Fields("pageformat").Value = 0 Then
                    e.Graphics.DrawString("Page " & PageNo.ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Dbf.Fields("pagenoleft").Value), CSng(Dbf.Fields("pagenotop").Value))
                Else
                    e.Graphics.DrawString("Page " & PageNo.ToString & " of " & PageNos.ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Dbf.Fields("pagenoleft").Value), CSng(Dbf.Fields("pagenotop").Value))
                End If
            End If
            If PageNo < PageNos Then
                e.Graphics.DrawString("Page Total=   " & FormatNumber(PageTotal, ErpDecimalPlaces).ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Dbf.Fields("pagenoleft").Value), CSng(Dbf.Fields("pagenotop").Value) - 80)
                e.Graphics.DrawString("Continue........", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Dbf.Fields("pagenoleft").Value), CSng(Dbf.Fields("pagenotop").Value) - 50)
            End If

        End If


        Dbf.Close()
        PrtDbf.Close()
        IsFirstOpen = True
        PresentRecords = 1
        pagerecords = 1
        e.HasMorePages = False



    End Sub

    Private Sub BtnPagesetupSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPagesetupSave.Click

        If MsgBox("Do You want to save?           ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            Dim Dbf As New ADODB.Recordset
            Dbf.Open("select * from VoucherPrintingSettings where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            Dbf.Fields("printername").Value = TxtPrinterName.Text
            Dbf.Fields("width").Value = TxtPaperWidth.Text
            Dbf.Fields("height").Value = TxtPaperHeight.Text
            If prtOrientationLand.Checked = True Then
                Dbf.Fields("islandscape").Value = 1
            Else
                Dbf.Fields("islandscape").Value = 0
            End If

            Dbf.Fields("fleft").Value = pageleftmargin.Value
            Dbf.Fields("fright").Value = pagerighttmargin.Value
            Dbf.Fields("ftop").Value = pagetopmargin.Value
            Dbf.Fields("fbuttom").Value = pagebuttommargin.Value
            If TxtIsLeftLogoOn.Checked = True Then
                Dbf.Fields("LeftLogoIsOn").Value = True
            Else
                Dbf.Fields("LeftLogoIsOn").Value = False
            End If

            Dbf.Fields("Leftlogoleft").Value = txtleftEdge.Text
            Dbf.Fields("leftlogotop").Value = txtlefttop.Text
            Dbf.Fields("Leftlogowidth").Value = txtleftwidth.Text
            Dbf.Fields("Leftlogoheight").Value = txtleftheight.Text
            Try
                Dbf.Fields("leftlogopath").Value = txtleftlogobox.ImageLocation
            Catch ex As Exception

            End Try

            If TxtIsRightLogoOn.Checked = True Then
                Dbf.Fields("rightLogoIsOn").Value = True
            Else
                Dbf.Fields("rightLogoIsOn").Value = False
            End If
            Dbf.Fields("rightlogoleft").Value = txtrightedge.Text
            Dbf.Fields("rightlogotop").Value = txtrighttop.Text
            Dbf.Fields("rightlogowidth").Value = txtrightwidth.Text
            Dbf.Fields("rightlogoheight").Value = txtrightheight.Text
            Try
                Dbf.Fields("rightlogopath").Value = txtRightLogobox.ImageLocation
            Catch ex As Exception

            End Try
            If IsShownPageNos.Checked = True Then
                Dbf.Fields("showpageno").Value = True

            Else
                Dbf.Fields("showpageno").Value = False

            End If
            Dbf.Fields("pagenoleft").Value = TxtPageNoLeft.Value
            Dbf.Fields("pagenotop").Value = TxtPageNoTop.Value
            Dbf.Fields("pageformat").Value = TxtPageNoFormat.SelectedIndex
            Dbf.Update()
            Dbf.Close()
        End If
        LoadReport()

    End Sub
    Sub LoadReport()

        Try
            Me.PrintGroup.Controls.RemoveAt(0)

        Catch ex As Exception

        End Try
        Me.PrintPreviewControl1 = New System.Windows.Forms.PrintPreviewControl

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtFont.ShowDialog() Then
            TxtFLFSample.Font = txtFont.Font
            TxtFLFSample.ForeColor = txtFont.Color
            TxtFLFFont.Text = txtFont.Font.Name
            If txtFont.Font.Underline = True Then
                TxtFLFStyleU.Checked = True
            Else
                TxtFLFStyleU.Checked = False
            End If
            If txtFont.Font.Bold = True Then
                TxtFLFStyleB.Checked = True
            Else
                TxtFLFStyleB.Checked = False
            End If
            If txtFont.Font.Italic = True Then
                TxtFLFStyleI.Checked = True
            Else
                TxtFLFStyleI.Checked = False

            End If
            TxtFLFFontSize.Value = txtFont.Font.Size
            TxtFLFColor.Text = txtFont.Color.Name.ToString

        End If
    End Sub

    Private Sub BtnFieldSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFieldSave.Click
        If TxtFieldLables.Text.Length = 0 Then
            MsgBox("Please Select the Field Labels from the list")
            TxtFieldLables.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to Save?      ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            Dim Dbf As New ADODB.Recordset
            Dbf.Open("select * from VoucherPrintFieldLabels where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtFieldLables.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            Dbf.Fields("schemename").Value = txtSchemName.Text
            Dbf.Fields("fieldname").Value = TxtFieldLables.Text
            Dbf.Fields("labletext").Value = txtFLtext.Text
            If TxtFLShow.Checked = True Then
                Dbf.Fields("isvisible").Value = True
            Else
                Dbf.Fields("isvisible").Value = False
            End If
            Dbf.Fields("ltop").Value = TxtFLtop.Value
            Dbf.Fields("lleft").Value = TxtFLLeft.Value
            Dbf.Fields("lwidth").Value = TxtFLWidth.Value
            Dbf.Fields("lheight").Value = TxtFLHeight.Value
            Dbf.Fields("lfontname").Value = TxtFLFont.Text
            Dbf.Fields("lfontsize").Value = TxtFLFontSize.Value

            If TxtFLStyleU.Checked = True Then
                If TxtFLStyleB.Checked = True And TxtFLSytleI.Checked = True Then
                    Dbf.Fields("lfontstyle").Value = 7
                ElseIf TxtFLStyleB.Checked = True Then
                    Dbf.Fields("lfontstyle").Value = 5
                ElseIf TxtFLSytleI.Checked = True Then
                    Dbf.Fields("lfontstyle").Value = 1
                Else

                    Dbf.Fields("lfontstyle").Value = 3
                End If
            Else
                If TxtFLStyleB.Checked = True And TxtFLSytleI.Checked = True Then
                    Dbf.Fields("lfontstyle").Value = 4
                ElseIf TxtFLStyleB.Checked = True Then
                    Dbf.Fields("lfontstyle").Value = 1
                ElseIf TxtFLSytleI.Checked = True Then
                    Dbf.Fields("lfontstyle").Value = 2
                Else
                    Dbf.Fields("lfontstyle").Value = 8
                End If
            End If



            Dbf.Fields("lalign").Value = TxtFLAlign.Text
            Dbf.Fields("fontcolor").Value = TxtFLFColor.Text
            Dbf.Fields("lfontcolor").Value = TxtFLFontColor.Text
            Dbf.Fields("ftop").Value = TxtFLFTop.Value
            Dbf.Fields("fleft").Value = TxtFLFLeft.Value
            Dbf.Fields("width").Value = TxtFLFwidth.Value
            Dbf.Fields("height").Value = TxtFLFHeight.Value
            Dbf.Fields("fontname").Value = TxtFLFFont.Text
            Dbf.Fields("fontsize").Value = TxtFLFFontSize.Value

            If TxtFLFStyleU.Checked = True Then
                If TxtFLFStyleB.Checked = True And TxtFLFStyleI.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 7
                ElseIf TxtFLFStyleB.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 5
                ElseIf TxtFLFStyleI.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 1
                Else

                    Dbf.Fields("fontstyle").Value = 3
                End If
            Else
                If TxtFLFStyleB.Checked = True And TxtFLFStyleI.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 4
                ElseIf TxtFLFStyleB.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 1
                ElseIf TxtFLFStyleI.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 2
                Else
                    Dbf.Fields("fontstyle").Value = 8
                End If
            End If

            Dbf.Fields("align").Value = TxtFLFAlign.Text
            Dbf.Update()
            Dbf.Close()


        End If
        If TxtFLApplyToAll.Checked = True Then
            TxtFLApplyToAll.Checked = False
            Dim Dbf As New ADODB.Recordset
            Dbf.Open("select * from VoucherPrintFieldLabels where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If Dbf.RecordCount > 0 Then
                Dbf.MoveFirst()
                For i As Integer = 0 To Dbf.RecordCount - 1
                    Dbf.Fields("lfontname").Value = TxtFLFont.Text
                    Dbf.Fields("lfontsize").Value = TxtFLFontSize.Value
                    If TxtFLStyleU.Checked = True Then
                        If TxtFLStyleB.Checked = True And TxtFLSytleI.Checked = True Then
                            Dbf.Fields("lfontstyle").Value = 7
                        ElseIf TxtFLStyleB.Checked = True Then
                            Dbf.Fields("lfontstyle").Value = 5
                        ElseIf TxtFLSytleI.Checked = True Then
                            Dbf.Fields("lfontstyle").Value = 1
                        Else

                            Dbf.Fields("lfontstyle").Value = 3
                        End If
                    Else
                        If TxtFLStyleB.Checked = True And TxtFLSytleI.Checked = True Then
                            Dbf.Fields("lfontstyle").Value = 4
                        ElseIf TxtFLStyleB.Checked = True Then
                            Dbf.Fields("lfontstyle").Value = 1
                        ElseIf TxtFLSytleI.Checked = True Then
                            Dbf.Fields("lfontstyle").Value = 2
                        Else
                            Dbf.Fields("lfontstyle").Value = 8
                        End If
                    End If
                    ' Dbf.Fields("lalign").Value = TxtFLAlign.Text
                    Dbf.Fields("lfontcolor").Value = TxtFLFColor.Text
                    Dbf.Update()
                    Dbf.MoveNext()
                Next
            End If
            Dbf.Close()
        End If

        If TxtFLFapplytoall.Checked = True Then
            TxtFLFapplytoall.Checked = False

            Dim Dbf As New ADODB.Recordset
            Dbf.Open("select * from VoucherPrintFieldLabels where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If Dbf.RecordCount > 0 Then
                Dbf.MoveFirst()
                For i As Integer = 0 To Dbf.RecordCount - 1
                    Dbf.Fields("fontcolor").Value = TxtFLFontColor.Text
                    Dbf.Fields("fontname").Value = TxtFLFFont.Text
                    Dbf.Fields("fontsize").Value = TxtFLFFontSize.Value
                    If TxtFLFStyleU.Checked = True Then
                        If TxtFLFStyleB.Checked = True And TxtFLFStyleI.Checked = True Then
                            Dbf.Fields("fontstyle").Value = 7
                        ElseIf TxtFLFStyleB.Checked = True Then
                            Dbf.Fields("fontstyle").Value = 5
                        ElseIf TxtFLFStyleI.Checked = True Then
                            Dbf.Fields("fontstyle").Value = 1
                        Else

                            Dbf.Fields("fontstyle").Value = 3
                        End If
                    Else
                        If TxtFLFStyleB.Checked = True And TxtFLFStyleI.Checked = True Then
                            Dbf.Fields("fontstyle").Value = 4
                        ElseIf TxtFLFStyleB.Checked = True Then
                            Dbf.Fields("fontstyle").Value = 1
                        ElseIf TxtFLFStyleI.Checked = True Then
                            Dbf.Fields("fontstyle").Value = 2
                        Else
                            Dbf.Fields("fontstyle").Value = 8
                        End If
                    End If
                    ' Dbf.Fields("align").Value = TxtFLFAlign.Text
                    Dbf.Update()
                    Dbf.MoveNext()
                Next
            End If



            Dbf.Close()
        End If
        LoadReport()
    End Sub

    Private Sub TxtFieldLables_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFieldLables.SelectedIndexChanged
        Dim Dbf As New ADODB.Recordset
        Dbf.Open("select * from VoucherPrintFieldLabels where schemename=N'" & txtSchemName.Text & "' and Fieldname=N'" & TxtFieldLables.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

        txtFLtext.Text = Dbf.Fields("labletext").Value.ToString
        If Dbf.Fields("isvisible").Value = True Then
            TxtFLShow.Checked = True
        Else
            TxtFLShow.Checked = False
        End If
        TxtFLtop.Value = Dbf.Fields("ltop").Value
        TxtFLLeft.Value = Dbf.Fields("lleft").Value
        TxtFLWidth.Value = Dbf.Fields("lwidth").Value
        TxtFLHeight.Value = Dbf.Fields("lheight").Value
        TxtFLFont.Text = Dbf.Fields("lfontname").Value
        TxtFLFontSize.Value = Dbf.Fields("lfontsize").Value

        If Dbf.Fields("lfontstyle").Value = 1 Then
            TxtFLStyleB.Checked = True
            TxtFLStyleU.Checked = False
            TxtFLSytleI.Checked = False
        ElseIf Dbf.Fields("lfontstyle").Value = 2 Then
            TxtFLStyleB.Checked = False
            TxtFLSytleI.Checked = True
            TxtFLStyleU.Checked = False
        ElseIf Dbf.Fields("lfontstyle").Value = 3 Then
            TxtFLStyleB.Checked = False
            TxtFLSytleI.Checked = False
            TxtFLStyleU.Checked = True
        ElseIf Dbf.Fields("lfontstyle").Value = 4 Then
            TxtFLStyleB.Checked = True
            TxtFLSytleI.Checked = True
            TxtFLStyleU.Checked = False
        ElseIf Dbf.Fields("lfontstyle").Value = 5 Then
            TxtFLStyleB.Checked = True
            TxtFLSytleI.Checked = False
            TxtFLStyleU.Checked = True
        ElseIf Dbf.Fields("lfontstyle").Value = 6 Then
            TxtFLStyleB.Checked = False
            TxtFLSytleI.Checked = True
            TxtFLStyleU.Checked = True
        ElseIf Dbf.Fields("lfontstyle").Value = 7 Then
            TxtFLStyleB.Checked = True
            TxtFLSytleI.Checked = True
            TxtFLStyleU.Checked = True
        Else
            TxtFLStyleB.Checked = False
            TxtFLSytleI.Checked = False
            TxtFLStyleU.Checked = False
        End If


        TxtFLAlign.Text = Dbf.Fields("lalign").Value
        TxtFLFontColor.Text = Dbf.Fields("fontcolor").Value
        TxtFLFColor.Text = Dbf.Fields("lfontcolor").Value
        TxtFLFTop.Value = Dbf.Fields("ftop").Value
        TxtFLFLeft.Value = Dbf.Fields("fleft").Value
        TxtFLFwidth.Value = Dbf.Fields("width").Value
        TxtFLFHeight.Value = Dbf.Fields("height").Value
        TxtFLFFont.Text = Dbf.Fields("fontname").Value
        TxtFLFFontSize.Value = Dbf.Fields("fontsize").Value

        If Dbf.Fields("fontstyle").Value = 1 Then
            TxtFLFStyleB.Checked = True
            TxtFLFStyleI.Checked = False
            TxtFLFStyleU.Checked = False
        ElseIf Dbf.Fields("fontstyle").Value = 2 Then
            TxtFLFStyleB.Checked = False
            TxtFLFStyleI.Checked = False
            TxtFLFStyleU.Checked = True
        ElseIf Dbf.Fields("fontstyle").Value = 3 Then
            TxtFLFStyleB.Checked = False
            TxtFLFStyleI.Checked = False
            TxtFLFStyleU.Checked = True
        ElseIf Dbf.Fields("fontstyle").Value = 4 Then
            TxtFLFStyleB.Checked = True
            TxtFLFStyleI.Checked = True
            TxtFLFStyleU.Checked = False
        ElseIf Dbf.Fields("fontstyle").Value = 5 Then
            TxtFLFStyleB.Checked = True
            TxtFLFStyleI.Checked = False
            TxtFLFStyleU.Checked = True
        ElseIf Dbf.Fields("fontstyle").Value = 6 Then
            TxtFLFStyleB.Checked = False
            TxtFLFStyleU.Checked = True
            TxtFLFStyleI.Checked = True
        ElseIf Dbf.Fields("fontstyle").Value = 7 Then
            TxtFLFStyleB.Checked = True
            TxtFLFStyleI.Checked = True
            TxtFLFStyleU.Checked = True
        Else
            TxtFLFStyleB.Checked = False
            TxtFLFStyleI.Checked = False
            TxtFLFStyleU.Checked = False
        End If

        TxtFLFAlign.Text = Dbf.Fields("align").Value
        Dbf.Close()
    End Sub

    Private Sub btnNewLabelSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewLabelSave.Click
        If TxtLabelLists.Text.Length = 0 Then
            MsgBox("Please Select the  Labels from the list")
            TxtLabelLists.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to Save?      ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            Dim Dbf As New ADODB.Recordset
            Dbf.Open("select * from VoucherPrintingLables where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtLabelLists.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If Dbf.RecordCount > 0 Then

            Else
                Dbf.AddNew()
            End If
            Dbf.Fields("schemename").Value = txtSchemName.Text
            Dbf.Fields("fieldname").Value = TxtLabelLists.Text
            Dbf.Fields("labletext").Value = txtLtext.Text
            If TxtLShow.Checked = True Then
                Dbf.Fields("isvisible").Value = True
            Else
                Dbf.Fields("isvisible").Value = False
            End If

            Dbf.Fields("fontcolor").Value = TxtLFontColor.Text

            Dbf.Fields("ftop").Value = TxtLtop.Value
            Dbf.Fields("fleft").Value = TxtLleft.Value
            Dbf.Fields("width").Value = TxtLwidth.Value
            Dbf.Fields("height").Value = TxtLHeight.Value
            Dbf.Fields("fontname").Value = TxtLFontName.Text
            Dbf.Fields("fontsize").Value = TxtLFontSize.Value

            If TxtLStyleU.Checked = True Then
                If TxtLStyleB.Checked = True And TxtLStyleI.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 7
                ElseIf TxtLStyleB.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 5
                ElseIf TxtLStyleI.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 1
                Else

                    Dbf.Fields("fontstyle").Value = 3
                End If
            Else
                If TxtLStyleB.Checked = True And TxtLStyleI.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 4
                ElseIf TxtLStyleB.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 1
                ElseIf TxtLStyleI.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 2
                Else
                    Dbf.Fields("fontstyle").Value = 8
                End If
            End If


            Dbf.Fields("align").Value = TxtLFontAlign.Text
            Dbf.Update()
            Dbf.Close()


        End If
        If TxtLableApplytoall.Checked = True Then
            Dim Dbf As New ADODB.Recordset
            Dbf.Open("select * from VoucherPrintingLables where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If Dbf.RecordCount > 0 Then
                Dbf.MoveFirst()
                For i As Integer = 0 To Dbf.RecordCount - 1
                    Dbf.Fields("fontcolor").Value = TxtLFontColor.Text
                    Dbf.Fields("fontname").Value = TxtLFontName.Text
                    Dbf.Fields("fontsize").Value = TxtLFontSize.Value
                    If TxtLStyleU.Checked = True Then
                        If TxtLStyleB.Checked = True And TxtLStyleI.Checked = True Then
                            Dbf.Fields("lfontstyle").Value = 7
                        ElseIf TxtLStyleB.Checked = True Then
                            Dbf.Fields("lfontstyle").Value = 5
                        ElseIf TxtLStyleI.Checked = True Then
                            Dbf.Fields("lfontstyle").Value = 1
                        Else
                            Dbf.Fields("lfontstyle").Value = 3
                        End If
                    Else
                        If TxtLStyleB.Checked = True And TxtLStyleI.Checked = True Then
                            Dbf.Fields("lfontstyle").Value = 4
                        ElseIf TxtLStyleB.Checked = True Then
                            Dbf.Fields("lfontstyle").Value = 1
                        ElseIf TxtLStyleI.Checked = True Then
                            Dbf.Fields("lfontstyle").Value = 2
                        Else
                            Dbf.Fields("lfontstyle").Value = 8
                        End If
                    End If
                    '  Dbf.Fields("align").Value = TxtLFontAlign.Text
                    Dbf.Update()
                    Dbf.MoveNext()
                Next

            End If
            Dbf.Close()
            TxtLableApplytoall.Checked = False
        End If

        LoadReport()
    End Sub

    Private Sub TxtLabelLists_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLabelLists.SelectedIndexChanged
        Dim Dbf As New ADODB.Recordset
        Dbf.Open("select * from VoucherPrintingLables where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtLabelLists.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If Dbf.RecordCount > 0 Then

            TxtLabelLists.Text = Dbf.Fields("fieldname").Value
            txtLtext.Text = Dbf.Fields("labletext").Value
            If Dbf.Fields("isvisible").Value = True Then
                TxtLShow.Checked = True
            Else
                TxtLShow.Checked = False
            End If

            TxtLFontColor.Text = Dbf.Fields("fontcolor").Value

            TxtLtop.Value = Dbf.Fields("ftop").Value
            TxtLleft.Value = Dbf.Fields("fleft").Value
            TxtLwidth.Value = Dbf.Fields("width").Value
            TxtLHeight.Value = Dbf.Fields("height").Value
            TxtLFontName.Text = Dbf.Fields("fontname").Value
            TxtLFontSize.Value = Dbf.Fields("fontsize").Value


            If Dbf.Fields("fontstyle").Value = 1 Then
                TxtLStyleB.Checked = True
                TxtLStyleI.Checked = False
                TxtLStyleU.Checked = False
            ElseIf Dbf.Fields("fontstyle").Value = 2 Then
                TxtLStyleB.Checked = False
                TxtLStyleI.Checked = False
                TxtLStyleU.Checked = True
            ElseIf Dbf.Fields("fontstyle").Value = 3 Then
                TxtLStyleB.Checked = False
                TxtLStyleI.Checked = False
                TxtLStyleU.Checked = True
            ElseIf Dbf.Fields("fontstyle").Value = 4 Then
                TxtLStyleB.Checked = True
                TxtLStyleI.Checked = True
                TxtLStyleU.Checked = False
            ElseIf Dbf.Fields("fontstyle").Value = 5 Then
                TxtLStyleB.Checked = True
                TxtLStyleI.Checked = False
                TxtLStyleU.Checked = True
            ElseIf Dbf.Fields("fontstyle").Value = 6 Then
                TxtLStyleB.Checked = False
                TxtLStyleU.Checked = True
                TxtLStyleI.Checked = True
            ElseIf Dbf.Fields("fontstyle").Value = 7 Then
                TxtLStyleB.Checked = True
                TxtLStyleI.Checked = True
                TxtLStyleU.Checked = True
            Else
                TxtLStyleB.Checked = False
                TxtLStyleI.Checked = False
                TxtLStyleU.Checked = False
            End If

            TxtLFontAlign.Text = Dbf.Fields("align").Value

            Dbf.Close()

        End If

    End Sub

    Private Sub btnnewlable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnewlable.Click
        Dim txtnlbl As String = ""
        txtnlbl = InputBox("Enter The Lable Name ", "Create New Label", "")
        If txtnlbl.Length > 0 Then
            If TxtLabelLists.Items.Contains(txtnlbl) = True Then
                MsgBox("The lable name is already exists, Please Try Again")
            Else
                TxtLabelLists.Items.Add(txtnlbl)
                TxtLabelLists.Text = txtnlbl
            End If
        End If
    End Sub

    Private Sub TxtLSelFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLSelFont.Click
        If txtFont.ShowDialog() Then
            TxtLsample.Font = txtFont.Font
            TxtLsample.ForeColor = txtFont.Color
            TxtLFontName.Text = txtFont.Font.Name
            If txtFont.Font.Underline = True Then
                TxtLStyleU.Checked = True
            Else
                TxtLStyleU.Checked = False
            End If
            If txtFont.Font.Bold = True Then
                TxtLStyleB.Checked = True
            Else
                TxtLStyleB.Checked = False
            End If
            If txtFont.Font.Italic = True Then
                TxtLStyleI.Checked = True
            Else
                TxtLStyleI.Checked = False
            End If
            TxtLFontSize.Value = txtFont.Font.Size
            TxtLFontColor.Text = txtFont.Color.Name.ToString

        End If
    End Sub

    Private Sub btnRecordSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecordSave.Click
        If TxtrecordItems.Text.Length = 0 Then
            MsgBox("Please Select Record Field Item from the list")
            TxtrecordItems.Focus()
            Exit Sub
        End If
        If MsgBox("Do You want to save  ?       ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim gr As New Font(TxtRFontname.Text, CSng(TxtRFontSize.Value), FontStyle.Bold)
        Dim m As Integer
        Dim rh As Integer
        m = gr.GetHeight()
        rh = m + TxtLineSpecing.Value
        m = TxtRFHeight.Value / (m + TxtLineSpecing.Value)

        Dim Dbf As New ADODB.Recordset
        Dbf.Open("UPDATE VoucherPrintingSettings SET maxrowsperpage=" & m & "  where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        Dbf.Open("UPDATE VoucherPrintingSettings SET rowheight=" & rh & "  where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

        Dbf.Open("UPDATE VoucherPrintRecords SET [fTop]=" & TxtRtop.Value & "  where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        Dbf.Open("UPDATE VoucherPrintRecords SET height=" & TxtRFHeight.Value & "  where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

        Dbf.Open("UPDATE VoucherPrintRecords SET ltop=" & TxtRlTop.Value & "  where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        Dbf.Open("UPDATE VoucherPrintRecords SET space=" & TxtLineSpecing.Value & "  where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

        Dbf.Open("select * from VoucherPrintRecords where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtrecordItems.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If Dbf.RecordCount > 0 Then
            Dbf.Fields("labletext").Value = TxtRlText.Text
            If TxtRShow.Checked = True Then
                Dbf.Fields("isvisible").Value = True
            Else
                Dbf.Fields("isvisible").Value = False
            End If
            Dbf.Fields("lleft").Value = TxtRlLeft.Value
            Dbf.Fields("lwidth").Value = TxtRlwidth.Value
            Dbf.Fields("lfontname").Value = TxtRlfontname.Text
            Dbf.Fields("lfontsize").Value = TxtRlfontsize.Value
            Dbf.Fields("lfontcolor").Value = TxtRlfontcolor.Text
            If TxtRlStyleU.Checked = True Then
                If TxtRlstyelB.Checked = True And TxtRlStyleI.Checked = True Then
                    Dbf.Fields("lfontstyle").Value = 7
                ElseIf TxtRlstyelB.Checked = True Then
                    Dbf.Fields("lfontstyle").Value = 5
                ElseIf TxtRlStyleI.Checked = True Then
                    Dbf.Fields("lfontstyle").Value = 1
                Else

                    Dbf.Fields("lfontstyle").Value = 3
                End If
            Else
                If TxtRlstyelB.Checked = True And TxtRlStyleI.Checked = True Then
                    Dbf.Fields("lfontstyle").Value = 4
                ElseIf TxtRlstyelB.Checked = True Then
                    Dbf.Fields("lfontstyle").Value = 1
                ElseIf TxtRlStyleI.Checked = True Then
                    Dbf.Fields("lfontstyle").Value = 2
                Else
                    Dbf.Fields("lfontstyle").Value = 8
                End If
            End If
            Dbf.Fields("Lcase").Value = TxtRlCase.Text
            Dbf.Fields("lalign").Value = TxtRlalign.Text

            Dbf.Fields("fleft").Value = TxtRFleft.Value
            Dbf.Fields("width").Value = TxtRwidht.Value
            Dbf.Fields("fontname").Value = TxtRFontname.Text
            Dbf.Fields("fontsize").Value = TxtRFontSize.Value
            Dbf.Fields("fontcolor").Value = TxtRfontColor.Text

            If TxtRStyleU.Checked = True Then
                If txtRStyleB.Checked = True And TxtRStyleI.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 7
                ElseIf txtRStyleB.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 5
                ElseIf TxtRStyleI.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 1
                Else

                    Dbf.Fields("fontstyle").Value = 3
                End If
            Else
                If txtRStyleB.Checked = True And TxtRStyleI.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 4
                ElseIf txtRStyleB.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 1
                ElseIf TxtRStyleI.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 2
                Else
                    Dbf.Fields("fontstyle").Value = 8
                End If
            End If


            Dbf.Fields("Rcase").Value = TxtRCase.Text
            Dbf.Fields("align").Value = TxtRAlign.Text
            Dbf.Update()


        End If
        Dbf.Close()
        If txtRLapplytoall.Checked = True Then
            txtRLapplytoall.Checked = False
            Dbf.Open("select * from VoucherPrintRecords where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            Dbf.MoveFirst()
            If Dbf.RecordCount > 0 Then
                For i As Integer = 1 To Dbf.RecordCount

                    Dbf.Fields("lfontname").Value = TxtRlfontname.Text
                    Dbf.Fields("lfontsize").Value = TxtRlfontsize.Value
                    Dbf.Fields("lfontcolor").Value = TxtRlfontcolor.Text

                    If TxtRlStyleU.Checked = True Then
                        If TxtRlstyelB.Checked = True And TxtRlStyleI.Checked = True Then
                            Dbf.Fields("lfontstyle").Value = 7
                        ElseIf TxtRlstyelB.Checked = True Then
                            Dbf.Fields("lfontstyle").Value = 5
                        ElseIf TxtRlStyleI.Checked = True Then
                            Dbf.Fields("lfontstyle").Value = 1
                        Else

                            Dbf.Fields("lfontstyle").Value = 3
                        End If
                    Else
                        If TxtRlstyelB.Checked = True And TxtRlStyleI.Checked = True Then
                            Dbf.Fields("lfontstyle").Value = 4
                        ElseIf TxtRlstyelB.Checked = True Then
                            Dbf.Fields("lfontstyle").Value = 1
                        ElseIf TxtRlStyleI.Checked = True Then
                            Dbf.Fields("lfontstyle").Value = 2
                        Else
                            Dbf.Fields("lfontstyle").Value = 8
                        End If
                    End If


                    Dbf.Fields("Lcase").Value = TxtRlCase.Text
                    ' Dbf.Fields("lalign").Value = TxtRlalign.Text


                    Dbf.Update()

                    Dbf.MoveNext()
                Next
            End If
            Dbf.Close()
        End If

        If TxtRapplytoall.Checked = True Then
            TxtRapplytoall.Checked = False
            Dbf.Open("select * from VoucherPrintRecords where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            Dbf.MoveFirst()
            If Dbf.RecordCount > 0 Then

                For i As Integer = 1 To Dbf.RecordCount
                    Dbf.Fields("fontname").Value = TxtRFontname.Text
                    Dbf.Fields("fontsize").Value = TxtRFontSize.Value
                    Dbf.Fields("fontcolor").Value = TxtRfontColor.Text

                    If TxtRStyleU.Checked = True Then
                        If txtRStyleB.Checked = True And TxtRStyleI.Checked = True Then
                            Dbf.Fields("fontstyle").Value = 7
                        ElseIf txtRStyleB.Checked = True Then
                            Dbf.Fields("fontstyle").Value = 5
                        ElseIf TxtRStyleI.Checked = True Then
                            Dbf.Fields("fontstyle").Value = 1
                        Else

                            Dbf.Fields("fontstyle").Value = 3
                        End If
                    Else
                        If txtRStyleB.Checked = True And TxtRStyleI.Checked = True Then
                            Dbf.Fields("fontstyle").Value = 4
                        ElseIf txtRStyleB.Checked = True Then
                            Dbf.Fields("fontstyle").Value = 1
                        ElseIf TxtRStyleI.Checked = True Then
                            Dbf.Fields("fontstyle").Value = 2
                        Else
                            Dbf.Fields("fontstyle").Value = 8
                        End If
                    End If


                    Dbf.Fields("Rcase").Value = TxtRCase.Text
                    '   Dbf.Fields("align").Value = TxtRAlign.Text
                    Dbf.Update()
                    Dbf.MoveNext()
                Next

            End If
            Dbf.Close()
        End If
        LoadReport()

    End Sub

    Private Sub txtselfontrr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtselfontrr.Click
        If txtFont.ShowDialog() Then


            TxtRlfontname.Text = txtFont.Font.Name
            If txtFont.Font.Underline = True Then
                TxtRlStyleU.Checked = True
            Else
                TxtRlStyleU.Checked = False
            End If
            If txtFont.Font.Bold = True Then
                TxtRlstyelB.Checked = True
            Else
                TxtRlstyelB.Checked = False
            End If
            If txtFont.Font.Italic = True Then
                TxtRlStyleI.Checked = True
            Else
                TxtRlStyleI.Checked = False
            End If
            TxtRlfontsize.Value = txtFont.Font.Size
            TxtRlfontcolor.Text = txtFont.Color.Name.ToString

        End If
    End Sub

    Private Sub TxtRselecfotnr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRselecfotnr.Click
        If txtFont.ShowDialog() Then

            TxtRFontname.Text = txtFont.Font.Name
            If txtFont.Font.Underline = True Then
                TxtRStyleU.Checked = True
            Else
                TxtRStyleU.Checked = False
            End If
            If txtFont.Font.Bold = True Then
                txtRStyleB.Checked = True
            Else
                txtRStyleB.Checked = False
            End If
            If txtFont.Font.Italic = True Then
                TxtRStyleI.Checked = True
            Else
                TxtRStyleI.Checked = False
            End If
            TxtRFontSize.Value = txtFont.Font.Size
            TxtRfontColor.Text = txtFont.Color.Name.ToString

        End If
    End Sub

    Private Sub TxtrecordItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtrecordItems.SelectedIndexChanged
        If TxtrecordItems.Text.Length > 0 Then
            Dim dbf As New ADODB.Recordset
            dbf.Open("select * from VoucherPrintRecords where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtrecordItems.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If dbf.RecordCount > 0 Then
                TxtRlText.Text = dbf.Fields("labletext").Value
                If dbf.Fields("isvisible").Value = True Then
                    TxtRShow.Checked = True
                Else
                    TxtRShow.Checked = False
                End If
                TxtRlLeft.Value = dbf.Fields("lleft").Value
                TxtRlwidth.Value = dbf.Fields("lwidth").Value
                TxtRlfontname.Text = dbf.Fields("lfontname").Value
                TxtRlfontsize.Value = dbf.Fields("lfontsize").Value
                TxtRlfontcolor.Text = dbf.Fields("lfontcolor").Value

                If dbf.Fields("lfontstyle").Value = 1 Then
                    TxtRlstyelB.Checked = True
                    TxtRlStyleI.Checked = False
                    TxtRlStyleU.Checked = False
                ElseIf dbf.Fields("lfontstyle").Value = 2 Then
                    TxtRlstyelB.Checked = False
                    TxtRlStyleI.Checked = False
                    TxtRlStyleU.Checked = True
                ElseIf dbf.Fields("lfontstyle").Value = 3 Then
                    TxtRlstyelB.Checked = False
                    TxtRlStyleI.Checked = False
                    TxtRlStyleU.Checked = True
                ElseIf dbf.Fields("lfontstyle").Value = 4 Then
                    TxtRlstyelB.Checked = True
                    TxtRlStyleI.Checked = True
                    TxtRlStyleU.Checked = False
                ElseIf dbf.Fields("lfontstyle").Value = 5 Then
                    TxtRlstyelB.Checked = True
                    TxtRlStyleI.Checked = False
                    TxtRlStyleU.Checked = True
                ElseIf dbf.Fields("lfontstyle").Value = 6 Then
                    TxtRlstyelB.Checked = False
                    TxtRlStyleU.Checked = True
                    TxtRlStyleI.Checked = True
                ElseIf dbf.Fields("lfontstyle").Value = 7 Then
                    TxtRlstyelB.Checked = True
                    TxtRlStyleI.Checked = True
                    TxtRlStyleU.Checked = True
                Else
                    TxtRlstyelB.Checked = False
                    TxtRlStyleI.Checked = False
                    TxtRlStyleU.Checked = False
                End If



                TxtRlCase.Text = dbf.Fields("Lcase").Value
                TxtRlalign.Text = dbf.Fields("lalign").Value

                TxtRFleft.Value = dbf.Fields("fleft").Value
                TxtRwidht.Value = dbf.Fields("width").Value
                TxtRFontname.Text = dbf.Fields("fontname").Value
                TxtRFontSize.Value = dbf.Fields("fontsize").Value
                TxtRfontColor.Text = dbf.Fields("fontcolor").Value


                If dbf.Fields("fontstyle").Value = 1 Then
                    txtRStyleB.Checked = True
                    TxtRStyleI.Checked = False
                    TxtRStyleU.Checked = False
                ElseIf dbf.Fields("fontstyle").Value = 2 Then
                    txtRStyleB.Checked = False
                    TxtRStyleI.Checked = False
                    TxtRStyleU.Checked = True
                ElseIf dbf.Fields("fontstyle").Value = 3 Then
                    txtRStyleB.Checked = False
                    TxtRStyleI.Checked = False
                    TxtRStyleU.Checked = True
                ElseIf dbf.Fields("fontstyle").Value = 4 Then
                    txtRStyleB.Checked = True
                    TxtRStyleI.Checked = True
                    TxtRStyleU.Checked = False
                ElseIf dbf.Fields("fontstyle").Value = 5 Then
                    txtRStyleB.Checked = True
                    TxtRStyleI.Checked = False
                    TxtRStyleU.Checked = True
                ElseIf dbf.Fields("fontstyle").Value = 6 Then
                    txtRStyleB.Checked = False
                    TxtRStyleU.Checked = True
                    TxtRStyleI.Checked = True
                ElseIf dbf.Fields("fontstyle").Value = 7 Then
                    txtRStyleB.Checked = True
                    TxtRStyleI.Checked = True
                    TxtRStyleU.Checked = True
                Else
                    txtRStyleB.Checked = False
                    TxtRStyleI.Checked = False
                    TxtRStyleU.Checked = False
                End If

                TxtRCase.Text = dbf.Fields("Rcase").Value
                TxtRAlign.Text = dbf.Fields("align").Value

            End If
            dbf.Close()
        End If
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Dim inputval As String
        inputval = InputBox("Enter The Line Name ?", "Line Name", "")
        If inputval.Length > 0 Then
            If txtLineNames.Items.Contains(inputval) = False Then
                IsNewLine = False
                txtLineNames.Items.Add(inputval)
            Else
                MsgBox("The Name is already exists, Please Try Again")
            End If
        End If
    End Sub

    Private Sub UserButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton3.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtLineColor.Text = ColorDialog1.Color.Name
        End If
    End Sub


    Private Sub UserButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton2.Click
        If txtLineNames.Text.Length = 0 Then
            MsgBox("Please Select the Line Name       ")
            txtLineNames.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to save the line ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
            Exit Sub
        End If

        If txtLineNames.Text.Length > 0 Then
            Dim dbf As New ADODB.Recordset
            dbf.Open("select * from VoucherPrintingLines where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & txtLineNames.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If dbf.RecordCount > 0 Then

            Else
                dbf.AddNew()
                If IsNewLine = True Then
                    dbf.Fields("fieldtype").Value = 0
                Else
                    dbf.Fields("fieldtype").Value = 1
                End If
            End If
            If TxtLineShow.Checked = True Then
                dbf.Fields("isvisible").Value = True
            Else
                dbf.Fields("isvisible").Value = False

            End If
            dbf.Fields("schemename").Value = txtSchemName.Text
            dbf.Fields("ftop").Value = TxtLineY1.Value
            dbf.Fields("fleft").Value = TxtLineX1.Value
            dbf.Fields("width").Value = TxtLinex2.Value
            dbf.Fields("height").Value = TxtLineY2.Value
            dbf.Fields("Fieldname").Value = txtLineNames.Text
            dbf.Fields("linecolor").Value = txtLineColor.Text
            dbf.Fields("boarderstyle").Value = txtLineStyle.Text
            dbf.Fields("boarderwidth").Value = txtLineWidth.Value
            dbf.Update()
            dbf.Close()
            IsNewLine = False
        End If

        LoadReport()

    End Sub

    Private Sub txtLineNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLineNames.SelectedIndexChanged
        If txtLineNames.Text.Length = 0 Then
            Exit Sub
        End If
        On Error Resume Next
        Dim dbf As New ADODB.Recordset
        dbf.Open("select * from VoucherPrintingLines where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & txtLineNames.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If dbf.Fields("isvisible").Value = True Then
            TxtLineShow.Checked = True
        Else
            TxtLineShow.Checked = False
        End If
        TxtLineY1.Value = dbf.Fields("ftop").Value
        TxtLineX1.Value = dbf.Fields("fleft").Value
        TxtLinex2.Value = dbf.Fields("width").Value
        TxtLineY2.Value = dbf.Fields("height").Value

        txtLineColor.Text = dbf.Fields("linecolor").Value
        txtLineStyle.Text = dbf.Fields("boarderstyle").Value
        txtLineWidth.Value = dbf.Fields("boarderwidth").Value
        dbf.Close()

    End Sub

    Private Sub BtnHeadingSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHeadingSave.Click
        If txtheadingitems.Text.Length = 0 Then
            MsgBox("Please Select The Headings form the list ")
            txtheadingitems.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to Save?      ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            Dim Dbf As New ADODB.Recordset
            Dbf.Open("select * from VoucherPrintHeadings where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & txtheadingitems.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If Dbf.RecordCount > 0 Then

            Else
                Dbf.AddNew()
            End If
            Dbf.Fields("schemename").Value = txtSchemName.Text
            Dbf.Fields("fieldname").Value = txtheadingitems.Text
            Dbf.Fields("headtext").Value = TxtHeadDisplyText.Text
            If TxtHeadShow.Checked = True Then
                Dbf.Fields("isvisible").Value = True
            Else
                Dbf.Fields("isvisible").Value = False
            End If

            Dbf.Fields("fontcolor").Value = TxtHeadFontColor.Text
            Dbf.Fields("ftop").Value = TxtHeadTop.Value
            Dbf.Fields("fleft").Value = TxtHeadLeft.Value
            Dbf.Fields("width").Value = TxtHeadWidth.Value
            Dbf.Fields("height").Value = TxtHeadHeight.Value
            Dbf.Fields("fontname").Value = TxtHeadFontName.Text
            Dbf.Fields("fontsize").Value = TxtHeadFontSize.Value

            If TxtHeadStyleU.Checked = True Then
                If TxtHeadStyleB.Checked = True And TxtHeadStyleI.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 7
                ElseIf TxtHeadStyleB.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 5
                ElseIf TxtHeadStyleI.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 1
                Else

                    Dbf.Fields("fontstyle").Value = 3
                End If
            Else
                If TxtHeadStyleB.Checked = True And TxtHeadStyleI.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 4
                ElseIf TxtHeadStyleB.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 1
                ElseIf TxtHeadStyleI.Checked = True Then
                    Dbf.Fields("fontstyle").Value = 2
                Else
                    Dbf.Fields("fontstyle").Value = 8
                End If
            End If
            Dbf.Fields("align").Value = TxtHeadAlign.Text
            Dbf.Update()
            Dbf.Close()
        End If
        If TxtHeadApplytoall.Checked = True Then
            TxtHeadApplytoall.Checked = False
            Dim Dbf As New ADODB.Recordset
            Dbf.Open("select * from VoucherPrintHeadings where schemename=N'" & txtSchemName.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If Dbf.RecordCount > 0 Then
                Dbf.MoveFirst()
                For i As Integer = 1 To Dbf.RecordCount


                    Dbf.Fields("fontcolor").Value = TxtHeadFontColor.Text
                    Dbf.Fields("fontname").Value = TxtHeadFontName.Text
                    Dbf.Fields("fontsize").Value = TxtHeadFontSize.Value

                    If TxtHeadStyleU.Checked = True Then
                        If TxtHeadStyleB.Checked = True And TxtHeadStyleI.Checked = True Then
                            Dbf.Fields("fontstyle").Value = 7
                        ElseIf TxtHeadStyleB.Checked = True Then
                            Dbf.Fields("fontstyle").Value = 5
                        ElseIf TxtHeadStyleI.Checked = True Then
                            Dbf.Fields("fontstyle").Value = 1
                        Else

                            Dbf.Fields("fontstyle").Value = 3
                        End If
                    Else
                        If TxtHeadStyleB.Checked = True And TxtHeadStyleI.Checked = True Then
                            Dbf.Fields("fontstyle").Value = 4
                        ElseIf TxtHeadStyleB.Checked = True Then
                            Dbf.Fields("fontstyle").Value = 1
                        ElseIf TxtHeadStyleI.Checked = True Then
                            Dbf.Fields("fontstyle").Value = 2
                        Else
                            Dbf.Fields("fontstyle").Value = 8
                        End If
                    End If
                    Dbf.Fields("align").Value = TxtHeadAlign.Text
                    Dbf.Update()
                    Dbf.MoveNext()
                Next
                Dbf.Close()
            End If

        End If
        LoadReport()
    End Sub

    Private Sub txtheadingitems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtheadingitems.SelectedIndexChanged

        Dim Dbf As New ADODB.Recordset
        Dbf.Open("select * from VoucherPrintHeadings where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & txtheadingitems.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If Dbf.RecordCount > 0 Then


            If Dbf.Fields("isvisible").Value = True Then
                TxtHeadShow.Checked = True
            Else
                TxtHeadShow.Checked = False
            End If
            TxtHeadDisplyText.Text = Dbf.Fields("headtext").Value.ToString
            TxtHeadFontColor.Text = Dbf.Fields("fontcolor").Value
            TxtHeadTop.Value = Dbf.Fields("ftop").Value
            TxtHeadLeft.Value = Dbf.Fields("fleft").Value
            TxtHeadWidth.Value = Dbf.Fields("width").Value
            TxtHeadHeight.Value = Dbf.Fields("height").Value
            TxtHeadFontName.Text = Dbf.Fields("fontname").Value
            TxtHeadFontSize.Value = Dbf.Fields("fontsize").Value

            If Dbf.Fields("fontstyle").Value = 1 Then
                TxtHeadStyleB.Checked = True
                TxtHeadStyleI.Checked = False
                TxtHeadStyleU.Checked = False
            ElseIf Dbf.Fields("fontstyle").Value = 2 Then
                TxtHeadStyleB.Checked = False
                TxtHeadStyleI.Checked = False
                TxtHeadStyleU.Checked = True
            ElseIf Dbf.Fields("fontstyle").Value = 3 Then
                TxtHeadStyleB.Checked = False
                TxtHeadStyleI.Checked = False
                TxtHeadStyleU.Checked = True
            ElseIf Dbf.Fields("fontstyle").Value = 4 Then
                TxtHeadStyleB.Checked = True
                TxtHeadStyleI.Checked = True
                TxtHeadStyleU.Checked = False
            ElseIf Dbf.Fields("fontstyle").Value = 5 Then
                TxtHeadStyleB.Checked = True
                TxtHeadStyleI.Checked = False
                TxtHeadStyleU.Checked = True
            ElseIf Dbf.Fields("fontstyle").Value = 6 Then
                TxtHeadStyleB.Checked = False
                TxtHeadStyleI.Checked = True
                TxtHeadStyleU.Checked = True
            ElseIf Dbf.Fields("fontstyle").Value = 7 Then
                TxtHeadStyleB.Checked = True
                TxtHeadStyleI.Checked = True
                TxtHeadStyleU.Checked = True
            Else
                TxtHeadStyleB.Checked = False
                TxtHeadStyleI.Checked = False
                TxtHeadStyleU.Checked = False
            End If

            TxtHeadAlign.Text = Dbf.Fields("align").Value

            Dbf.Close()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim schemevalue As String
        schemevalue = InputBox("Plese Enter the Scheme Name ", "New Scheme ", "")
        If schemevalue.Length > 0 Then
            If txtSchemName.Items.Contains(schemevalue) = False Then
                If MsgBox("Do you want to create a new scheme ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    Try
                        Dim sqlStr As String = ""
                        sqlStr = "INSERT INTO [VoucherPrintingSettings]([PrinterName],[schemename],[Width],[Height],[IsLandScape],[fleft],[fright],[ftop],[fbuttom],[multi],[showsubtotals],[IsActive],[PaperName],[LeftLogoIsOn],[RightLogoIson],[Leftlogoleft],[Leftlogotop],[Leftlogowidth],[Leftlogoheight],[Rightlogoleft],[Rightlogotop],[Rightlogowidth],[Rightlogoheight],[leftlogopath],[rightlogopath],[MaxRowsPerPage],[RowHeight],[showpageno],[pagenotop],[pagenoleft],[pageformat]) " _
                            & " (SELECT  [PrinterName],N'" & schemevalue & "' AS [schemename],[Width],[Height],[IsLandScape],[fleft],[fright],[ftop],[fbuttom],[multi],[showsubtotals],[IsActive],[PaperName],[LeftLogoIsOn],[RightLogoIson],[Leftlogoleft],[Leftlogotop],[Leftlogowidth],[Leftlogoheight],[Rightlogoleft],[Rightlogotop],[Rightlogowidth],[Rightlogoheight],[leftlogopath],[rightlogopath],[MaxRowsPerPage],[RowHeight],[showpageno],[pagenotop],[pagenoleft],[pageformat] FROM VoucherPrintingSettings where schemename=N'" & txtSchemName.Text & "')"
                        ExecuteSQLQuery(sqlStr)

                        sqlStr = "INSERT INTO [VoucherPrintFieldLabels] ([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[databasevalue]) " _
                            & "(SELECT N'" & schemevalue & "' AS [SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[databasevalue] FROM VoucherPrintFieldLabels where schemename=N'" & txtSchemName.Text & "')"
                        ExecuteSQLQuery(sqlStr)

                        sqlStr = "INSERT INTO [VoucherPrintHeadings] ([schemename],[fTop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[fieldname],[Align],[fcase],[IsVisible],[HeadText]) " _
                            & "(SELECT N'" & schemevalue & "' AS [schemename],[fTop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[fieldname],[Align],[fcase],[IsVisible],[HeadText] from VoucherPrintHeadings where schemename=N'" & txtSchemName.Text & "')"
                        ExecuteSQLQuery(sqlStr)

                        sqlStr = "INSERT INTO [VoucherPrintingLables] ([schemename],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[fieldname],[labletext],[isvisible],[align]) " _
                            & "(SELECT N'" & schemevalue & "' AS [schemename],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[fieldname],[labletext],[isvisible],[align] from VoucherPrintingLables where schemename=N'" & txtSchemName.Text & "')"
                        ExecuteSQLQuery(sqlStr)

                        sqlStr = "INSERT INTO [VoucherPrintingLines] ([schemename],[ftop],[fleft],[width],[height],[fieldname],[FieldType],[LineColor],[BoarderStyle],[BoarderWidth],[IsVisible]) " _
                            & "(SELECT N'" & schemevalue & "' AS [schemename],[ftop],[fleft],[width],[height],[fieldname],[FieldType],[LineColor],[BoarderStyle],[BoarderWidth],[IsVisible] from VoucherPrintingLines where schemename=N'" & txtSchemName.Text & "')"
                        ExecuteSQLQuery(sqlStr)

                        sqlStr = "INSERT INTO [VoucherPrintRecords] ([SchemeName],[Fieldname],[labletext],[ObjectType],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[Lcase],[Rcase],[lalign],[space],[DBType],[DBField],[FormatType]) " _
                            & " (SELECT N'" & schemevalue & "' AS [SchemeName],[Fieldname],[labletext],[ObjectType],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[Lcase],[Rcase],[lalign],[space],[DBType],[DBField],[FormatType] from VoucherPrintRecords where schemename=N'" & txtSchemName.Text & "')"

                        ExecuteSQLQuery(sqlStr)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    LoadSchemesIntoBoxes()
                End If
            End If
        End If
    End Sub

    Private Sub txtSchemName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSchemName.SelectedIndexChanged
        LoadDefauls()
        LoadReport()
    End Sub




    Private Sub UserButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton6.Click
        Try
            PrintPreviewControl1.StartPage = PrintPreviewControl1.StartPage + 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UserButton5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton5.Click
        Try
            PrintPreviewControl1.StartPage = PrintPreviewControl1.StartPage - 1
        Catch ex As Exception

        End Try
    End Sub





    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If txtSchemName.Text.Length = 0 Then
            MsgBox("Please Select the Scheme Name        ")
            txtSchemName.Focus()
            Exit Sub
        End If
        If MsgBox("Make Sure, Do not Duplicate More than 2  Do you want to Duplicate All Fileds for the Scheme : " & txtSchemName.Text, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If


        Dim SqlStr As String

        Try

           
            SqlStr = "INSERT INTO [VoucherPrintFieldLabels] ([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[databasevalue]) " _
                & "(SELECT   [SchemeName],CONCAT([Fieldname], '2') AS [Fieldname],[labletext],[DBField],'FALSE' AS [IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[databasevalue] FROM VoucherPrintFieldLabels where schemename=N'" & txtSchemName.Text & "')"
            ExecuteSQLQuery(SqlStr)

            SqlStr = "INSERT INTO [VoucherPrintHeadings] ([schemename],[fTop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[fieldname],[Align],[fcase],[IsVisible],[HeadText]) " _
                & "(SELECT  [schemename],[fTop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],CONCAT([Fieldname], '2') AS [fieldname],[Align],[fcase],'FALSE' AS [IsVisible],[HeadText] from VoucherPrintHeadings where schemename=N'" & txtSchemName.Text & "')"
            ExecuteSQLQuery(SqlStr)

            SqlStr = "INSERT INTO [VoucherPrintingLables] ([schemename],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[fieldname],[labletext],[isvisible],[align]) " _
                & "(SELECT  [schemename],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],CONCAT([Fieldname], '2') AS [fieldname],[labletext],'FALSE' AS [IsVisible],[align] from VoucherPrintingLables where schemename=N'" & txtSchemName.Text & "')"
            ExecuteSQLQuery(SqlStr)

            SqlStr = "INSERT INTO [VoucherPrintingLines] ([schemename],[ftop],[fleft],[width],[height],[fieldname],[FieldType],[LineColor],[BoarderStyle],[BoarderWidth],[IsVisible]) " _
                & "(SELECT  [schemename],[ftop],[fleft],[width],[height],CONCAT([Fieldname], '2') AS [fieldname],[FieldType],[LineColor],[BoarderStyle],[BoarderWidth],'FALSE' AS [IsVisible] from VoucherPrintingLines where schemename=N'" & txtSchemName.Text & "')"
            ExecuteSQLQuery(SqlStr)

            SqlStr = "INSERT INTO [VoucherPrintRecords] ([SchemeName],[Fieldname],[labletext],[ObjectType],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[Lcase],[Rcase],[lalign],[space],[DBType],[DBField],[FormatType]) " _
                & " (SELECT   [SchemeName],CONCAT([Fieldname], '2') AS [Fieldname],[labletext],[ObjectType],'FALSE' AS [IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[Lcase],[Rcase],[lalign],[space],[DBType],[DBField],[FormatType] from VoucherPrintRecords where schemename=N'" & txtSchemName.Text & "')"

            ExecuteSQLQuery(SqlStr)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDefInvoiceList.SelectedIndexChanged
        LoadInvoiceTypeSchemes()
    End Sub
    Sub LoadInvoiceTypeSchemes()
        TxtGridList.Rows.Clear()
        If TxtDefInvoiceList.Text.Length = 0 Then Exit Sub
        Dim r As Integer
        Dim Dbf As New ADODB.Recordset
        Dbf.Open("select * from PrintingSchemes where vouchername=N'" & TxtDefInvoiceList.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If Dbf.RecordCount > 0 Then
            Dbf.MoveFirst()
            For i As Integer = 0 To Dbf.RecordCount - 1
                r = TxtGridList.Rows.Add()
                If Dbf.Fields("isactive").Value = 1 Then
                    TxtGridList.Item(0, r).Value = Dbf.Fields("id").Value
                    TxtGridList.Item(1, r).Value = Dbf.Fields("schemename").Value
                    TxtGridList.Item(2, r).Value = "YES"
                Else
                    TxtGridList.Item(0, r).Value = Dbf.Fields("id").Value
                    TxtGridList.Item(1, r).Value = Dbf.Fields("schemename").Value
                    TxtGridList.Item(2, r).Value = "NO"
                End If
                Dbf.MoveNext()
            Next
        End If
        Dbf.Close()
    End Sub
    Private Sub UserButton42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton42.Click
        If TxtDefInvoiceList.Text.Length = 0 Then
            MsgBox("Please Select the Invoice Type..")
            TxtDefInvoiceList.Focus()
        End If
        If TxtInvoiceSchameList.Text.Length = 0 Then Exit Sub
        Dim Dbf As New ADODB.Recordset
        Dbf.Open("select * from PrintingSchemes where schemename=N'" & TxtInvoiceSchameList.Text & "' and vouchername=N'" & TxtDefInvoiceList.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If Dbf.RecordCount > 0 Then
            Dbf.Close()
            MsgBox("The Scheme Name is already exist....")
        Else
            If MsgBox("Do you want to add (Y/N) ?                ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dbf.AddNew()
                Dbf.Fields("ID").Value = SQLGetNumericFieldValue("select max(ID) as val from PrintingSchemes", "val") + 1
                Dbf.Fields("schemename").Value = TxtInvoiceSchameList.Text
                Dbf.Fields("vouchername").Value = TxtDefInvoiceList.Text
                Dbf.Fields("SchemeType").Value = 2
                Dbf.Fields("isactive").Value = 0
                Dbf.Update()
            End If
            Dbf.Close()
            LoadInvoiceTypeSchemes()
        End If
    End Sub


    Private Sub UserButton40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton40.Click
        If TxtDefInvoiceList.Text.Length = 0 Then
            MsgBox("Please Select the Invoice Type..")
            TxtDefInvoiceList.Focus()
        End If
        If TxtGridList.SelectedRows.Count > 0 Then
            If MsgBox("Do you want to  selected scheme Name as Default Secheme (Y/N)?  ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim Dbf As New ADODB.Recordset
                Dbf.Open("update PrintingSchemes set isactive=0 where vouchername=N'" & TxtDefInvoiceList.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
                Dbf.Open("update PrintingSchemes set isactive=1 where schemename=N'" & TxtGridList.Item(1, TxtGridList.CurrentRow.Index).Value & "' and vouchername=N'" & TxtDefInvoiceList.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            End If
            LoadInvoiceTypeSchemes()
        Else
            MsgBox("Please Select the Scheme from the list.... ")
        End If
    End Sub

    Private Sub UserButton41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton41.Click
        If TxtDefInvoiceList.Text.Length = 0 Then
            MsgBox("Please Select the Invoice Type..")
            TxtDefInvoiceList.Focus()
        End If
        If TxtGridList.RowCount = 1 Then Exit Sub
        If TxtGridList.SelectedRows.Count > 0 Then
            If MsgBox("Do you want to Delete selected scheme Name (Y/N)?  ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim Dbf As New ADODB.Recordset
                Dbf.Open("delete  from PrintingSchemes where schemename=N'" & TxtGridList.Item(1, TxtGridList.CurrentRow.Index).Value & "' and vouchername=N'" & TxtDefInvoiceList.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            End If
            LoadInvoiceTypeSchemes()
        Else
            MsgBox("Please Select the Scheme from the list.... ")
        End If
    End Sub

    Private Sub BtnCLose1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCLose1.Click
        Me.Close()
    End Sub

    Private Sub BtnFieldClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFieldClose.Click
        Me.Close()
    End Sub

    Private Sub BtnNewlabelClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewlabelClose.Click
        Me.Close()
    End Sub

    Private Sub BtnRecordclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRecordclose.Click
        Me.Close()
    End Sub

    Private Sub UserButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton1.Click
        Me.Close()
    End Sub

    Private Sub UserButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton4.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text.Length = 0 Then Exit Sub
        Select Case ComboBox1.Text
            Case "A4"
                If prtOrientationPort.Checked = True Then
                    TxtPaperWidth.Text = "827"
                    TxtPaperHeight.Text = "1169"
                Else
                    TxtPaperHeight.Text = "827"
                    TxtPaperWidth.Text = "1169"
                End If

            Case "A5"
                If prtOrientationPort.Checked = True Then
                    TxtPaperWidth.Text = "583"
                    TxtPaperHeight.Text = "827"
                Else
                    TxtPaperHeight.Text = "583"
                    TxtPaperWidth.Text = "827"
                End If

            Case "Letter"
                If prtOrientationPort.Checked = True Then
                    TxtPaperWidth.Text = "850"
                    TxtPaperHeight.Text = "1100"
                Else
                    TxtPaperHeight.Text = "850"
                    TxtPaperWidth.Text = "1100"
                End If
            Case "Tabloid"
                If prtOrientationPort.Checked = True Then
                    TxtPaperWidth.Text = "1100"
                    TxtPaperHeight.Text = "1700"
                Else
                    TxtPaperHeight.Text = "1100"
                    TxtPaperWidth.Text = "1700"
                End If
            Case "A3"
                If prtOrientationPort.Checked = True Then
                    TxtPaperWidth.Text = "1169"
                    TxtPaperHeight.Text = "1650"
                Else
                    TxtPaperHeight.Text = "1169"
                    TxtPaperWidth.Text = "1650"
                End If
            Case "Legal"
                If prtOrientationPort.Checked = True Then
                    TxtPaperWidth.Text = "850"
                    TxtPaperHeight.Text = "1400"
                Else
                    TxtPaperHeight.Text = "850"
                    TxtPaperWidth.Text = "1400"
                End If
        End Select

    End Sub
End Class