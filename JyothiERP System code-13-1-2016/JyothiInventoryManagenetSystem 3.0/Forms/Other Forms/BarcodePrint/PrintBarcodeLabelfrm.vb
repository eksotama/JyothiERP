
Imports System.Drawing.Printing
Imports System.IO

Public Class PrintBarcodeLabelfrm
    Dim SqlSTR As String = ""
    Dim PaperWidth As Integer = 0
    Dim PaperHeight As Integer = 0
    Dim IsNewLine As Boolean = False
    Dim Printtext1 As String = ""
    Dim StringtoPrint As String = ""
    Dim factor As Double = 0
    Dim StockBcodeList As New ComboBox
    Public TotalBarcodeToBePrint As Integer = 0
    Dim btype As BarcodeLib.TYPE
    Dim Barcodeimg As New BarcodeLib.Barcode
    Sub LoadStock(Optional ByVal WhereStr As String = "")
        Dim AdditionSqlText = ""

        SqlSTR = "SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [SNO],0 as [No Of Copies],barcode as [ID], StockCode , stockName ,[custBarcode] as [BARCODE],MRP, StockDRP as [DRP],StockWRP as [WRP]  FROM [StockDbf]  "
        If TxtGroup.Text.Length = 0 Or TxtGroup.Text = "*All" Then

        Else
            AdditionSqlText = " Where stockgroup=N'" & TxtGroup.Text & "' "
        End If

        If TxtCat.Text.Length = 0 Or TxtCat.Text = "*All" Then

        Else
            If AdditionSqlText.Length = 0 Then
                AdditionSqlText = " where  category=N'" & TxtCat.Text & "' "
            Else
                AdditionSqlText = AdditionSqlText & " and  category=N'" & TxtCat.Text & "' "
            End If
        End If
        If AdditionSqlText.Length = 0 Then
            AdditionSqlText = " where location=N'" & GetDefLocationName() & "' "
        Else
            AdditionSqlText = AdditionSqlText & " and location=N'" & GetDefLocationName() & "' "
        End If

        If WhereStr.Length > 0 Then
            If AdditionSqlText.Length = 0 Then
                AdditionSqlText = " where  " & WhereStr
            Else
                AdditionSqlText = AdditionSqlText & " and " & WhereStr
            End If
        End If
        If AdditionSqlText.Length > 5 Then
            AdditionSqlText = AdditionSqlText & "  and location=N'" & GetDefLocationName() & "'"
        Else
            AdditionSqlText = "  where location=N'" & GetDefLocationName() & "'"
        End If
        SqlSTR = SqlSTR & AdditionSqlText
        Dim TempBS As New BindingSource
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
            TxtList.Columns("ID").Visible = False
            TxtList.Columns("SNO").Visible = False

            TxtList.Columns("SNO").Width = 80
            TxtList.Columns("MRP").Width = 70
            TxtList.Columns("dRP").Width = 70
            TxtList.Columns("wRP").Width = 70
            TxtList.Columns("No Of Copies").Width = 80
            TxtList.Columns("Stockcode").Width = 120
            TxtList.Columns("stockName").Width = 130
            TxtList.Columns("BARCODE").Width = 80
            For i As Integer = 0 To TxtList.Columns.Count - 1
                TxtList.Columns(i).ReadOnly = True
            Next
            TxtList.Columns("No Of Copies").ReadOnly = False
            TxtList.Columns("MRP").ReadOnly = False
            TxtList.Columns("dRP").ReadOnly = False
            TxtList.Columns("wRP").ReadOnly = False
        Catch ex As Exception

        End Try

    End Sub
    Sub LoadReport()
     
       
        Try
            Me.PrintGroup2.Controls.RemoveAt(0)
        Catch ex As Exception

        End Try


        Me.PrintPreviewControl2 = New System.Windows.Forms.PrintPreviewControl
        Me.PrintPreviewControl2.Zoom = 1
        Me.PrintPreviewControl2.Hide()
        Me.PrintPreviewControl2.SuspendLayout()
        Me.PrintPreviewControl2.Dock = DockStyle.Fill
        PrintPreviewControl2.Refresh()
        PrintPreviewControl2.Document = PrtDoc
        Me.PrintPreviewControl2.ResumeLayout()
        Me.PrintGroup2.Controls.Add(Me.PrintPreviewControl2)
        Me.PrintPreviewControl2.Show()
        PrintPreviewControl2.Refresh()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PrintBarcodeLabelfrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub CustomBarcodeEntry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        factor = 3.779527559
        TxtBarcodeType.Text = "ENA13"
        LoadDataIntoComboBox("select stockgroupname from stockgroups", TxtGroup, "stockgroupname", "*All")
        PaperWidth = 827
        PaperHeight = 1169
        LoadDataIntoComboBox("select StockCategoryName from Categoriesgroups", TxtCat, "StockCategoryName", "*All")
        LoadStock()
        LoadDataIntoComboBox("select SchemeName from BarcodePrintSchemes ", TxtSchemeName, "SchemeName")
        TxtBarcodeRotate.DataSource = System.[Enum].GetNames(GetType(RotateFlipType))
        If TxtSchemeName.Items.Count > 0 Then
            TxtSchemeName.SelectedIndex = 0
        End If
        StockBcodeList.Sorted = False

    End Sub
    Function GetTotalRecords() As Integer
        Dim tot As Integer = 0
        For I As Integer = 0 To TxtList.Rows.Count - 1
            If IsNumeric(TxtList.Item("No Of Copies", I).Value.ToString) = True Then
                tot = tot + CInt(TxtList.Item("No Of Copies", I).Value)
            End If
        Next
        Return tot
    End Function
    Sub lOADbCODEDATA()
        StockBcodeList.Items.Clear()

        For I As Integer = 0 To TxtList.Rows.Count - 1
            If IsNumeric(TxtList.Item("No Of Copies", I).Value.ToString) = True Then
                If TxtList.Item("No Of Copies", I).Value > 0 Then
                    For k As Integer = 0 To CInt(TxtList.Item("No Of Copies", I).Value) - 1
                        StockBcodeList.Items.Add(TxtList.Item("ID", I).Value)
                    Next
                End If
            End If

        Next

    End Sub
    Private Sub PrtDoc_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrtDoc.BeginPrint
        PrtDoc.DefaultPageSettings.PaperSize = New PaperSize("Custom", PaperWidth, PaperHeight)
        PrtDoc.DefaultPageSettings.Landscape = False
        PrtDoc.DefaultPageSettings.Margins.Left = TxtLeftGap.Value * factor
        PrtDoc.DefaultPageSettings.Margins.Right = 0
        PrtDoc.DefaultPageSettings.Margins.Top = TxtTopGap.Value * factor
        PrtDoc.DefaultPageSettings.Margins.Bottom = 0
        lOADbCODEDATA()
    End Sub
   
    Private Sub PrtDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrtDoc.PrintPage
        Static totalPrintImages As Integer = 0
        If StockBcodeList.Items.Count = 0 Then
            totalPrintImages = 0
            Exit Sub
        End If
        Dim top As Integer = 0
        Dim left As Integer = 0
        Dim Imagesforwidth As Integer = 0
        Dim ImagesforHeight As Integer = 0
        If TxtPaperSize.Text.ToUpper = "RollPaper".ToUpper Then
            Imagesforwidth = PaperWidth \ (CInt(CInt(TxtWidth.Text) * factor))
            ImagesforHeight = PaperHeight \ (CInt(CInt(txtheight.Text) * factor))
            top = CInt(TxtTopGap.Value * factor)
            For i As Integer = 1 To ImagesforHeight
                left = CInt(TxtLeftGap.Value * factor)
                For k As Integer = 1 To TxtNoOfColumns.Value
                    PrintBarcodeLabels(sender, e, totalPrintImages, top, left)
                    PrintBarcodelINES(sender, e, totalPrintImages, top, left)
                    PrintBarcodeImages(sender, e, totalPrintImages, top, left)
                    left = left + CInt(CInt(TxtWidth.Text) * factor) + CInt(TxtVGap.Value * factor)
                    totalPrintImages = totalPrintImages + 1
                    If totalPrintImages >= StockBcodeList.Items.Count Then
                        GoTo mm
                    End If
                Next
                top = top + CInt(CInt(txtheight.Text) * factor) + CInt(TxtHGap.Value * factor)
            Next

        Else
            Imagesforwidth = PaperWidth \ (CInt(CInt(TxtWidth.Text) * factor))
            ImagesforHeight = PaperHeight \ (CInt(CInt(txtheight.Text) * factor))

            top = CInt(TxtTopGap.Value * factor)

            For i As Integer = 1 To ImagesforHeight
                left = CInt(TxtLeftGap.Value * factor)
                For k As Integer = 1 To Imagesforwidth
                    PrintBarcodeLabels(sender, e, totalPrintImages, top, left)
                    PrintBarcodelINES(sender, e, totalPrintImages, top, left)
                    PrintBarcodeImages(sender, e, totalPrintImages, top, left)
                    left = left + CInt(CInt(TxtWidth.Text) * factor) + CInt(TxtVGap.Value * factor)
                    totalPrintImages = totalPrintImages + 1
                    If totalPrintImages >= StockBcodeList.Items.Count Then
                        GoTo mm
                    End If
                Next

                top = top + CInt(CInt(txtheight.Text) * factor) + CInt(TxtHGap.Value * factor)
                If top + CInt(CInt(txtheight.Text) * factor) > PaperHeight Then
                    GoTo mm
                End If
            Next
        End If
       
mm:
        
        If totalPrintImages >= StockBcodeList.Items.Count Then
            e.HasMorePages = False
            totalPrintImages = 0
        Else
            e.HasMorePages = True
        End If
        'If e.HasMorePages = True Then

        'Else
        '    totalPrintImages = 0
        'End If

    End Sub
    Sub PrintBarcodeImages(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal index As Integer, Optional ByVal TOPValue As Integer = 0, Optional ByVal LeftValue As Integer = 0)

        Dim SqlConn2 As New SqlClient.SqlConnection
        Try
            SqlConn2.ConnectionString = ConnectionStrinG
            SqlConn2.Open()
            SQLFcmd.Connection = SqlConn2
            SQLFcmd.CommandText = "select * from barcodeprintimages where schemename=N'" & TxtSchemeName.Text & "' order by Orderno"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                If Sreader("IsVisible") = True Then
                    Try
                        Dim ImageValue As System.Drawing.Image
                        ImageValue = Image.FromFile(Sreader("imagepath").ToString.Trim)
                        Dim rect1 As New Rectangle(CSng(Sreader("Lleft") * factor + LeftValue), CSng(Sreader("LTop") * factor + TOPValue), CSng(Sreader("imagewidth") * factor), CSng(Sreader("imageHeight") * factor))
                        e.Graphics.DrawImage(ImageValue, rect1)
                        ImageValue = Nothing

                    Catch ex As Exception

                    End Try
                End If

            End While
            Sreader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn2.Close()
            SQLFcmd.Connection = Nothing
        End Try
    End Sub
    Sub PrintBarcodeLabels(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal index As Integer, ByVal TOPValue As Integer, ByVal LeftValue As Integer)
        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from barcodeprintlabels where schemename=N'" & TxtSchemeName.Text & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                If Sreader("IsVisible") = True Then
                    Dim drawFormat As New StringFormat
                    Dim drawFont As Font = New Font("arial", 10)
                    Dim drawBrush As New SolidBrush(Color.FromName(Sreader("fontcolor").ToString.Trim))
                    Select Case Sreader("fontstyle")
                        Case 1
                            drawFont = New Font(Sreader("Fontname").ToString.Trim, CSng(Sreader("fontsize")), FontStyle.Bold)
                        Case 2
                            drawFont = New Font(Sreader("Fontname").ToString.Trim, CSng(Sreader("fontsize")), FontStyle.Italic)
                        Case 3
                            drawFont = New Font(Sreader("Fontname").ToString.Trim, CSng(Sreader("fontsize")), FontStyle.Underline)
                        Case 4
                            drawFont = New Font(Sreader("Fontname").ToString.Trim, CSng(Sreader("fontsize")), FontStyle.Bold Or FontStyle.Italic)
                        Case 5
                            drawFont = New Font(Sreader("Fontname").ToString.Trim, CSng(Sreader("fontsize")), FontStyle.Bold Or FontStyle.Underline)
                        Case 6
                            drawFont = New Font(Sreader("Fontname").ToString.Trim, CSng(Sreader("fontsize")), FontStyle.Italic Or FontStyle.Underline)
                        Case 7
                            drawFont = New Font(Sreader("Fontname").ToString.Trim, CSng(Sreader("fontsize")), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                        Case 8
                            drawFont = New Font(Sreader("Fontname").ToString.Trim, CSng(Sreader("fontsize")), FontStyle.Regular)

                    End Select

                    If Sreader("align").ToString.Trim = "Left" Then
                        drawFormat.Alignment = StringAlignment.Near
                    ElseIf Sreader("align").ToString.Trim = "Right" Then
                        drawFormat.Alignment = StringAlignment.Far
                    Else
                        drawFormat.Alignment = StringAlignment.Center
                    End If

                    e.Graphics.RotateTransform(Sreader("Rotate"))
                    Dim rect1 As New Rectangle(CSng(Sreader("lleft") * factor) + LeftValue, CSng(Sreader("ltop") * factor) + TOPValue, CSng(Sreader("lwidth") * factor), CSng(Sreader("lheight") * factor))
                    If Sreader("backcolor") = "null" Or Sreader("backcolor") = "white" Then
                    Else
                        Try
                            Dim fbrush As New SolidBrush(Color.FromName(Sreader("backcolor").ToString.Trim))
                            e.Graphics.FillRectangle(fbrush, rect1)
                        Catch ex As Exception

                        End Try

                    End If
                    '  

                    If Sreader("IsDbFiled") = 1 Then
                        If UCase(Sreader("DbName").ToString) = "BARCODEIMAGE" Then
                            Dim val As String = ""
                            val = SQLGetStringFieldValue("SELECT custbarcode AS TOT FROM STOCKDBF WHERE BARCODE=N'" & StockBcodeList.Items(index).ToString & "'", "TOT")
                            If TxtBarcodeType.Text = "Use Code39BarcodeFont" Then
                                e.Graphics.DrawString("*" & val & "*", drawFont, drawBrush, rect1, drawFormat)
                            Else
                                Try
                                    e.Graphics.DrawImage(Barcodeimg.Encode(btype, val, CInt(Sreader("lwidth") * factor), CInt(Sreader("lheight") * factor)), rect1)
                                Catch ex As Exception

                                End Try
                            End If

                        ElseIf UCase(Sreader("DbName").ToString) = "BARCODE" Then
                            Dim val As String = ""
                            val = SQLGetStringFieldValue("SELECT custbarcode AS TOT FROM STOCKDBF WHERE BARCODE=N'" & StockBcodeList.Items(index).ToString & "'", "TOT")
                            Try
                                e.Graphics.DrawString(Sreader("LText").ToString & val, drawFont, drawBrush, rect1, drawFormat)
                            Catch ex As Exception
                                e.Graphics.DrawString(Sreader("LText").ToString & val, drawFont, drawBrush, rect1, drawFormat)
                            End Try
                        ElseIf UCase(Sreader("DbName").ToString) = "stockcode".ToUpper Then
                            Dim val As String = ""
                            val = SQLGetStringFieldValue("SELECT stockcode AS TOT FROM STOCKDBF WHERE BARCODE=N'" & StockBcodeList.Items(index).ToString & "'", "TOT")
                            Try
                                e.Graphics.DrawString(Sreader("LText").ToString & val, drawFont, drawBrush, rect1, drawFormat)
                            Catch ex As Exception
                                e.Graphics.DrawString(Sreader("LText").ToString & val, drawFont, drawBrush, rect1, drawFormat)
                            End Try
                        ElseIf UCase(Sreader("DbName").ToString) = "stockname".ToUpper Then
                            Dim val As String = ""
                            val = SQLGetStringFieldValue("SELECT stockname AS TOT FROM STOCKDBF WHERE BARCODE=N'" & StockBcodeList.Items(index).ToString & "'", "TOT")
                            Try
                                e.Graphics.DrawString(Sreader("LText").ToString & val, drawFont, drawBrush, rect1, drawFormat)
                            Catch ex As Exception
                                e.Graphics.DrawString(Sreader("LText").ToString & val, drawFont, drawBrush, rect1, drawFormat)
                            End Try
                        ElseIf UCase(Sreader("DbName").ToString) = "stocksize".ToUpper Then
                            Dim val As String = ""
                            val = SQLGetStringFieldValue("SELECT stocksize AS TOT FROM STOCKDBF WHERE BARCODE=N'" & StockBcodeList.Items(index).ToString & "'", "TOT")
                            Try
                                e.Graphics.DrawString(Sreader("LText").ToString & val, drawFont, drawBrush, rect1, drawFormat)
                            Catch ex As Exception
                                e.Graphics.DrawString(Sreader("LText").ToString & val, drawFont, drawBrush, rect1, drawFormat)
                            End Try
                        Else

                            Dim val As String = ""
                            val = SQLGetStringFieldValue("SELECT " & Sreader("DbName").ToString & " AS TOT FROM STOCKDBF WHERE BARCODE=N'" & StockBcodeList.Items(index).ToString & "'", "TOT")
                            Try
                                e.Graphics.DrawString(Sreader("LText").ToString & FormatNumber(CDbl(val), 2, , , Sreader("IsComaSep")), drawFont, drawBrush, rect1, drawFormat)
                            Catch ex As Exception
                                e.Graphics.DrawString(Sreader("LText").ToString & val, drawFont, drawBrush, rect1, drawFormat)
                            End Try

                        End If

                    Else
                        If UCase(Sreader("DbName").ToString) = "BARCODEIMAGE" Then
                            Dim val As String = ""
                            val = SQLGetStringFieldValue("SELECT custbarcode AS TOT FROM STOCKDBF WHERE BARCODE=N'" & StockBcodeList.Items(index).ToString & "'", "TOT")
                            If TxtBarcodeType.Text = "Use Code39BarcodeFont" Then
                                e.Graphics.DrawString("*" & val & "*", drawFont, drawBrush, rect1, drawFormat)
                            Else
                                Try
                                    e.Graphics.DrawImage(Barcodeimg.Encode(btype, val, CInt(Sreader("lwidth") * factor), CInt(Sreader("lheight") * factor)), rect1)
                                Catch ex As Exception

                                End Try
                            End If
                        ElseIf UCase(Sreader("DbName").ToString) = "BARCODE" Then
                            Dim val As String = ""
                            val = SQLGetStringFieldValue("SELECT custbarcode AS TOT FROM STOCKDBF WHERE BARCODE=N'" & StockBcodeList.Items(index).ToString & "'", "TOT")
                            Try
                                e.Graphics.DrawString(Sreader("LText").ToString & val, drawFont, drawBrush, rect1, drawFormat)
                            Catch ex As Exception
                                e.Graphics.DrawString(Sreader("LText").ToString & val, drawFont, drawBrush, rect1, drawFormat)
                            End Try
                        Else
                            e.Graphics.DrawString(Sreader("LText").ToString, drawFont, drawBrush, rect1, drawFormat)
                        End If

                    End If
                    e.Graphics.RotateTransform(Sreader("Rotate") * -1)
                    e.Graphics.ResetTransform()
                    drawBrush.Dispose()
                    drawFont.Dispose()
                    drawFormat.Dispose()

                End If

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            SQLFcmd.Connection = Nothing
        End Try
    End Sub
    Sub PrintBarcodelINES(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal index As Integer, Optional ByVal TOPValue As Integer = 0, Optional ByVal LeftValue As Integer = 0)
        Dim SqlConn3 As New SqlClient.SqlConnection
        Try
            SqlConn3.ConnectionString = ConnectionStrinG
            SqlConn3.Open()
            SQLFcmd.Connection = SqlConn3
            SQLFcmd.CommandText = "select * from barcodePrintLines where schemename=N'" & TxtSchemeName.Text & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                If Sreader("IsVisible") = True Then
                    Dim penstyle As New Pen(Color.FromName(Sreader("LineColor").ToString.Trim), CSng(Sreader("BoarderWidth")))

                    If Sreader("BoarderStyle").ToString.Trim = "Solid" Then
                        penstyle.DashStyle = Drawing2D.DashStyle.Solid
                    ElseIf Sreader("BoarderStyle").ToString.Trim = "Dash" Then
                        penstyle.DashStyle = Drawing2D.DashStyle.Dash
                    ElseIf Sreader("BoarderStyle").ToString.Trim = "Dot" Then
                        penstyle.DashStyle = Drawing2D.DashStyle.Dot
                    ElseIf Sreader("BoarderStyle").ToString.Trim = "DashDot" Then
                        penstyle.DashStyle = Drawing2D.DashStyle.DashDot
                    Else
                        penstyle.DashStyle = Drawing2D.DashStyle.DashDotDot
                    End If
                    e.Graphics.RotateTransform(Sreader("Rotate"))
                    If Sreader("FieldType") = 0 Then
                        e.Graphics.DrawLine(penstyle, CSng(Sreader("Lleft") * factor) + LeftValue, CSng(Sreader("Ltop") * factor) + TOPValue, CSng(Sreader("Lwidth") * factor) + LeftValue, CSng(Sreader("Lheight") * factor + TOPValue))
                    Else
                        e.Graphics.DrawRectangle(penstyle, CSng(Sreader("Lleft") * factor) + LeftValue, CSng(Sreader("Ltop") * factor) + TOPValue, CSng(Sreader("Lwidth") * factor), CSng(Sreader("Lheight") * factor))
                    End If
                    e.Graphics.RotateTransform(Sreader("Rotate") * -1)
                    e.Graphics.ResetTransform()
                End If
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn3.Close()
            SqlConn3.Dispose()
            SQLFcmd.Connection = Nothing
        End Try
    End Sub
    Function GetImageName(ByVal imageno As Integer) As String
        Return ""
    End Function
    Private Sub BtnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPreview.Click
        PreviewReport()
    End Sub
    Sub PreviewReport()
        If TxtBarcodeType.Text.Length = 0 Then
            TxtBarcodeType.Text = "Code 128"
        End If

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

            PaperWidth = TxtNoOfColumns.Value * (CInt(CInt(TxtWidth.Text) * factor) + CInt(TxtVGap.Value * factor)) + TxtLeftGap.Value * 2 * 3.78
            TotalRows = Math.Ceiling(GetTotalRecords() / TxtNoOfColumns.Value)

            TotalRows = CInt(txtheight.Text) * factor * TotalRows + TxtTopGap.Value * factor + (TotalRows * TxtHGap.Value * factor)
            PaperHeight = CInt(TotalRows)

        End If
        Dim BROTATE As String = ""
        Dim BCODEalign As String = "CENTER"
        BROTATE = SQLGetStringFieldValue("SELECT BarcodeRotate AS TOT FROM barcodeprintlabels WHERE schemename=N'" & TxtSchemeName.Text & "' AND DbName='BarcodeImage'", "TOT", , , True)
        BCODEalign = SQLGetStringFieldValue("SELECT Align AS TOT FROM barcodeprintlabels WHERE schemename=N'" & TxtSchemeName.Text & "' AND DbName='BarcodeImage'", "TOT", , , True)

        Barcodeimg.IncludeLabel = False
        If BCODEalign.ToUpper = "CENTRE" Then
            Barcodeimg.Alignment = BarcodeLib.AlignmentPositions.CENTER
        ElseIf BCODEalign.ToUpper = "LEFT" Then
            Barcodeimg.Alignment = BarcodeLib.AlignmentPositions.LEFT
        Else
            Barcodeimg.Alignment = BarcodeLib.AlignmentPositions.RIGHT
        End If

        If BROTATE.Length = 0 Then
            BROTATE = "RotateNoneFlipNone"
        End If
        Barcodeimg.RotateFlipType = DirectCast([Enum].Parse(GetType(RotateFlipType), BROTATE, True), RotateFlipType)
        btype = BarcodeLib.TYPE.UNSPECIFIED

        Select Case TxtBarcodeType.SelectedItem.ToString().Trim()
            Case "UPC-A"
                btype = BarcodeLib.TYPE.UPCA
            Case "UPC-E"
                btype = BarcodeLib.TYPE.UPCE
            Case "UPC 2 Digit Ext."
                btype = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_2DIGIT
            Case "UPC 5 Digit Ext."
                btype = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_5DIGIT
            Case "EAN-13"
                btype = BarcodeLib.TYPE.EAN13
            Case "JAN-13"
                btype = BarcodeLib.TYPE.JAN13
            Case "EAN-8"
                btype = BarcodeLib.TYPE.EAN8
            Case "ITF-14"
                btype = BarcodeLib.TYPE.ITF14
            Case "Codabar"
                btype = BarcodeLib.TYPE.Codabar
            Case "PostNet"
                btype = BarcodeLib.TYPE.PostNet
            Case "Bookland/ISBN"
                btype = BarcodeLib.TYPE.BOOKLAND
            Case "Code 11"
                btype = BarcodeLib.TYPE.CODE11
            Case "Code 39"
                btype = BarcodeLib.TYPE.CODE39
            Case "Code 39 Extended"
                btype = BarcodeLib.TYPE.CODE39Extended
            Case "Code 39 Mod 43"
                btype = BarcodeLib.TYPE.CODE39_Mod43
            Case "Code 93"
                btype = BarcodeLib.TYPE.CODE93
            Case "LOGMARS"
                btype = BarcodeLib.TYPE.LOGMARS
            Case "MSI"
                btype = BarcodeLib.TYPE.MSI_Mod10
            Case "Interleaved 2 of 5"
                btype = BarcodeLib.TYPE.Interleaved2of5
            Case "Standard 2 of 5"
                btype = BarcodeLib.TYPE.Standard2of5
            Case "Code 128"
                btype = BarcodeLib.TYPE.CODE128
            Case "Code 128-A"
                btype = BarcodeLib.TYPE.CODE128A
            Case "Code 128-B"
                btype = BarcodeLib.TYPE.CODE128B
            Case "Code 128-C"
                btype = BarcodeLib.TYPE.CODE128C
            Case "Telepen"
                btype = BarcodeLib.TYPE.TELEPEN
            Case "FIM"
                btype = BarcodeLib.TYPE.FIM
            Case "Pharmacode"
                btype = BarcodeLib.TYPE.PHARMACODE
        End Select

        LoadReport()
        On Error Resume Next
        If UCase(TxtZoom.Text) = "AUTO" Then
            Me.PrintPreviewControl2.AutoZoom = True
        Else
            Me.PrintPreviewControl2.AutoZoom = False
            If TxtZoom.Text = "25%" Then
                Me.PrintPreviewControl2.Zoom = 0.25
            ElseIf TxtZoom.Text = "50%" Then
                Me.PrintPreviewControl2.Zoom = 0.5
            ElseIf TxtZoom.Text = "75%" Then
                Me.PrintPreviewControl2.Zoom = 0.75
            ElseIf TxtZoom.Text = "100%" Then
                Me.PrintPreviewControl2.Zoom = 1
            Else
                Me.PrintPreviewControl2.Zoom = 2
            End If
        End If
    End Sub
    Private Sub TxtGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadStock()
    End Sub

    Private Sub TxtCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadStock()
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





    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TxtList.ClearSelection()
    End Sub





    Private Sub ImsButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        Me.Close()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        If MsgBox("Do you want to save changes ?        ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim Sqlstr As String = ""
            Sqlstr = "UPDATE barcodeprintschemes SET Schemename =N'" & TxtSchemeName.Text & "' ,Lwidth =" & CDbl(TxtWidth.Text) & " ,LHeight =" & CDbl(txtheight.Text) & " ,LTop =" & CDbl(TxtTopGap.Value) & " ,Lleft =" & CDbl(TxtLeftGap.Value) & " ,LVgap =" & CDbl(TxtVGap.Value) & " ,LHgap =" & CDbl(TxtHGap.Value) & " ,nocolumns =" & CInt(TxtNoOfColumns.Value) & "  ,barcodetype =N'" & TxtBarcodeType.Text & "',papertype=N'" & TxtPaperSize.Text & "' where  schemename=N'" & TxtSchemeName.Text & "'"
            ExecuteSQLQuery(Sqlstr)
            PreviewReport()
        End If
    End Sub

    Private Sub TxtSchemeName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSchemeName.SelectedIndexChanged
        If TxtSchemeName.Text.Length > 0 Then
            If SQLIsFieldExists("SELECT TOP 1 1 from   barcodeprintschemes where schemename=N'" & TxtSchemeName.Text & "'") = False Then
                SqlSTR = "INSERT INTO [BarcodePrintSchemes]([Schemename],[Barcodewidth],[BarcodeHeight],[Lwidth],[LHeight],[LTop],[Lleft],[LVgap],[LHgap],[nocolumns],[barcodetype],[papertype],[barcodeleft],[barcodetop],[barcodeColor],[Rotate])     VALUES " _
                    & "(N'" & TxtSchemeName.Text & "',125,65,200,100,10,10,10,10,1,'Code 128','RollPaper',0,0,'Black',0)"
                ExecuteSQLQuery(SqlSTR)
            End If
            LoadPageSetupvalues()
        End If
    End Sub
    Sub LoadPageSetupvalues()
        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SQLFcmd2 As New SqlClient.SqlCommand
            SQLFcmd2.Connection = SqlConn1
            SQLFcmd2.CommandText = "select * from BarcodePrintSchemes where Schemename=N'" & TxtSchemeName.Text & "'"
            SQLFcmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd2.ExecuteReader
            While Sreader.Read()
                TxtWidth.Text = Sreader("Lwidth")
                txtheight.Text = Sreader("LHeight")
                TxtTopGap.Value = Sreader("LTop")
                TxtLeftGap.Value = Sreader("Lleft")
                TxtVGap.Value = Sreader("LVgap")
                TxtHGap.Value = Sreader("LHgap")
                TxtNoOfColumns.Value = Sreader("nocolumns")
                TxtBarcodeType.Text = IIf(Sreader("barcodetype").ToString = "code128", "Code 128", Sreader("Barcodetype").ToString)
                TxtPaperSize.Text = Sreader("papertype").ToString
                TxtBarcodeRotate.Text = Sreader("Rotate")
            End While
            Sreader.Close()
            Sreader = Nothing
            SQLFcmd2.Connection = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
            SqlConn1.Dispose()
        End Try
        'loading fields
        LoadDataIntoComboBox("select DbName from barcodeprintlabels where Schemename=N'" & TxtSchemeName.Text & "'", TxtFieldNames, "DbName")
        'loading lines txtLineNames
        LoadDataIntoComboBox("select fieldname from barcodePrintLines where Schemename=N'" & TxtSchemeName.Text & "'", txtLineNames, "fieldname")
        'loading images Imagename
        LoadDataIntoComboBox("select Imagename from barcodeprintimages where Schemename=N'" & TxtSchemeName.Text & "'", TxtImagesList, "Imagename")
        Dim sqlistr As String = ""
        If TxtFieldNames.Items.Count > 0 Then
            If SQLIsFieldExists("select Schemename from barcodeprintlabels where Schemename=N'" & TxtSchemeName.Text & "' and DbName='BarcodeImage'") = False Then
                sqlistr = "INSERT INTO [barcodeprintlabels]([Schemename],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor],[Rotate],[IsDbFiled])     VALUES " _
             & "(N'" & TxtSchemeName.Text & "',0,0,0,0,'BarcodeImage','','Arial',9,0,'Black','Left',0,'null',0 ,1)"
                ExecuteSQLQuery(sqlistr)
                LoadDataIntoComboBox("select DbName from barcodeprintlabels where Schemename=N'" & TxtSchemeName.Text & "'", TxtFieldNames, "DbName")
            End If
            TxtFieldNames.SelectedIndex = 0
        Else

            sqlistr = "INSERT INTO [barcodeprintlabels]([Schemename],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor],[Rotate],[IsDbFiled])     VALUES " _
                & "(N'" & TxtSchemeName.Text & "',0,0,0,0,'StockCode','','Arial',9,0,'Black','Left',0,'null',0,1 )"
            ExecuteSQLQuery(sqlistr)

            sqlistr = "INSERT INTO [barcodeprintlabels]([Schemename],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor],[Rotate],[IsDbFiled])     VALUES " _
               & "(N'" & TxtSchemeName.Text & "',0,0,0,0,'StockName','','Arial',9,0,'Black','Left',0,'null',0 ,1)"
            ExecuteSQLQuery(sqlistr)
            sqlistr = "INSERT INTO [barcodeprintlabels]([Schemename],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor],[Rotate],[IsDbFiled])     VALUES " _
               & "(N'" & TxtSchemeName.Text & "',0,0,0,0,'StockSize','','Arial',9,0,'Black','Left',0,'null',0,1 )"
            ExecuteSQLQuery(sqlistr)
            sqlistr = "INSERT INTO [barcodeprintlabels]([Schemename],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor],[Rotate],[IsDbFiled])     VALUES " _
               & "(N'" & TxtSchemeName.Text & "',0,0,0,0,'Barcode','','Arial',9,0,'Black','Left',0,'null',0 ,1)"
            ExecuteSQLQuery(sqlistr)
            sqlistr = "INSERT INTO [barcodeprintlabels]([Schemename],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor],[Rotate],[IsDbFiled])     VALUES " _
              & "(N'" & TxtSchemeName.Text & "',0,0,0,0,'BarcodeImage','','Arial',9,0,'Black','Left',0,'null',0 ,1)"
            ExecuteSQLQuery(sqlistr)
            sqlistr = "INSERT INTO [barcodeprintlabels]([Schemename],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor],[Rotate],[IsDbFiled])     VALUES " _
               & "(N'" & TxtSchemeName.Text & "',0,0,0,0,'mrp','','Arial',9,0,'Black','Left',0,'null',0,1 )"
            ExecuteSQLQuery(sqlistr)
            'additional fields

            sqlistr = "INSERT INTO [barcodeprintlabels]([Schemename],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor],[Rotate],[IsDbFiled])     VALUES " _
               & "(N'" & TxtSchemeName.Text & "',0,0,0,0,'Brand','','Arial',9,0,'Black','Left',0,'null',0,1 )"
            ExecuteSQLQuery(sqlistr)

            sqlistr = "INSERT INTO [barcodeprintlabels]([Schemename],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor],[Rotate],[IsDbFiled])     VALUES " _
               & "(N'" & TxtSchemeName.Text & "',0,0,0,0,'Company','','Arial',9,0,'Black','Left',0,'null',0,1 )"
            ExecuteSQLQuery(sqlistr)

            sqlistr = "INSERT INTO [barcodeprintlabels]([Schemename],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor],[Rotate],[IsDbFiled])     VALUES " _
               & "(N'" & TxtSchemeName.Text & "',0,0,0,0,'origin','','Arial',9,0,'Black','Left',0,'null',0,1 )"
            ExecuteSQLQuery(sqlistr)

            sqlistr = "INSERT INTO [barcodeprintlabels]([Schemename],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor],[Rotate],[IsDbFiled])     VALUES " _
               & "(N'" & TxtSchemeName.Text & "',0,0,0,0,'HScode','','Arial',9,0,'Black','Left',0,'null',0,1 )"
            ExecuteSQLQuery(sqlistr)

            sqlistr = "INSERT INTO [barcodeprintlabels]([Schemename],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor],[Rotate],[IsDbFiled])     VALUES " _
               & "(N'" & TxtSchemeName.Text & "',0,0,0,0,'StockRate','','Arial',9,0,'Black','Left',0,'null',0,1 )"
            ExecuteSQLQuery(sqlistr)

            sqlistr = "INSERT INTO [barcodeprintlabels]([Schemename],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor],[Rotate],[IsDbFiled])     VALUES " _
               & "(N'" & TxtSchemeName.Text & "',0,0,0,0,'StockWRP','','Arial',9,0,'Black','Left',0,'null',0,1 )"
            ExecuteSQLQuery(sqlistr)

            sqlistr = "INSERT INTO [barcodeprintlabels]([Schemename],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor],[Rotate],[IsDbFiled])     VALUES " _
               & "(N'" & TxtSchemeName.Text & "',0,0,0,0,'StockDRP','','Arial',9,0,'Black','Left',0,'null',0,1 )"
            ExecuteSQLQuery(sqlistr)

            sqlistr = "INSERT INTO [barcodeprintlabels]([Schemename],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor],[Rotate],[IsDbFiled])     VALUES " _
               & "(N'" & TxtSchemeName.Text & "',0,0,0,0,'description','','Arial',9,0,'Black','Left',0,'null',0,1 )"
            ExecuteSQLQuery(sqlistr)
            'packing
            sqlistr = "INSERT INTO [barcodeprintlabels]([Schemename],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor],[Rotate],[IsDbFiled])     VALUES " _
               & "(N'" & TxtSchemeName.Text & "',0,0,0,0,'packing','','Arial',9,0,'Black','Left',0,'null',0,1 )"
            ExecuteSQLQuery(sqlistr)

            LoadDataIntoComboBox("select DbName from barcodeprintlabels where Schemename=N'" & TxtSchemeName.Text & "'", TxtFieldNames, "DbName")
        End If
        If txtLineNames.Items.Count > 0 Then
            txtLineNames.SelectedIndex = 0
        End If
        If TxtImagesList.Items.Count > 0 Then
            TxtImagesList.SelectedIndex = 0
        End If
    End Sub

    Private Sub BtnNewField_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewField.Click
        Dim frm As New BarcodeNewFieldfrm(TxtSchemeName.Text)
        frm.Show()
        LoadDataIntoComboBox("select DbName from barcodeprintlabels where Schemename=N'" & TxtSchemeName.Text & "'", TxtFieldNames, "DbName")
        If TxtFieldNames.Items.Count > 0 Then
            TxtFieldNames.SelectedIndex = 0
        End If
        LoadDataIntoComboBox("select DbName from barcodeprintlabels where Schemename=N'" & TxtSchemeName.Text & "'", TxtFieldNames, "DbName")
    End Sub

    Private Sub ImsButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton6.Click
        If TxtFieldNames.Text.Length = 0 Then
            MsgBox("Please select the filed name ..              ")
            TxtFieldNames.Focus()
            Exit Sub
        End If

        Dim fontstyle As Integer = 0
        If TxtFLStyleU.Checked = True Then
            If TxtFLStyleB.Checked = True And TxtFLSytleI.Checked = True Then
                fontstyle = 7
            ElseIf TxtFLStyleB.Checked = True Then
                fontstyle = 5
            ElseIf TxtFLSytleI.Checked = True Then
                fontstyle = 6
            Else
                fontstyle = 3
            End If
        Else
            If TxtFLStyleB.Checked = True And TxtFLSytleI.Checked = True Then
                fontstyle = 4
            ElseIf TxtFLStyleB.Checked = True Then
                fontstyle = 1
            ElseIf TxtFLSytleI.Checked = True Then
                fontstyle = 2
            Else
                fontstyle = 8
            End If
        End If
        If MsgBox("Do you want to Save changes                 ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim Sqlstr As String = ""
            If IsShowFiled.Checked = True Then
                Sqlstr = "UPDATE [barcodeprintlabels]   SET [Lwidth] =" & CDbl(TxtFLWidth.Value) & " ,[LHeight] =" & CDbl(TxtFLHeight.Value) & ",[LTop] =" & CDbl(TxtFLtop.Value) & " ,[Lleft] =" & CDbl(TxtFLLeft.Value) & ",[LText] =N'" & txtFLtext.Text & "' ,[Fontname] =N'" & TxtFLFont.Text & "',[fontsize] =" & CInt(TxtFLFontSize.Text) & " ,[fontstyle] =" & fontstyle & " ,[fontcolor] =N'" & TxtFLFontColor.Text & "' ,[Align] =N'" & TxtFLAlign.Text & "' ,[IsVisible] =1 ,[backcolor] =N'" & TxtFLBackColor.Text & "' ,[Rotate] =" & CInt(txtFRotate.Text) & ",BarcodeRotate=N'" & TxtBarcodeRotate.Text & "',IsComaSep=" & IIf(IsCommaSep.Checked = True, 1, 0) & "  WHERE schemename=N'" & TxtSchemeName.Text & "' and DbName=N'" & TxtFieldNames.Text & "'"
            Else
                Sqlstr = "UPDATE [barcodeprintlabels]   SET [Lwidth] =" & CDbl(TxtFLWidth.Value) & " ,[LHeight] =" & CDbl(TxtFLHeight.Value) & ",[LTop] =" & CDbl(TxtFLtop.Value) & " ,[Lleft] =" & CDbl(TxtFLLeft.Value) & ",[LText] =N'" & txtFLtext.Text & "' ,[Fontname] =N'" & TxtFLFont.Text & "',[fontsize] =" & CInt(TxtFLFontSize.Text) & " ,[fontstyle] =" & fontstyle & " ,[fontcolor] =N'" & TxtFLFontColor.Text & "' ,[Align] =N'" & TxtFLAlign.Text & "' ,[IsVisible] =0 ,[backcolor] =N'" & TxtFLBackColor.Text & "' ,[Rotate] =" & CInt(txtFRotate.Text) & ",BarcodeRotate=N'" & TxtBarcodeRotate.Text & "',IsComaSep=" & IIf(IsCommaSep.Checked = True, 1, 0) & "  WHERE schemename=N'" & TxtSchemeName.Text & "' and DbName=N'" & TxtFieldNames.Text & "'"
            End If
            ExecuteSQLQuery(Sqlstr)
            PreviewReport()
        End If
    End Sub

    Private Sub TxtFieldNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFieldNames.SelectedIndexChanged
        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SQLFcmd2 As New SqlClient.SqlCommand
            SQLFcmd2.Connection = SqlConn1
            SQLFcmd2.CommandText = "select * from barcodeprintlabels where Schemename=N'" & TxtSchemeName.Text & "' and dbname=N'" & TxtFieldNames.Text & "'"
            SQLFcmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd2.ExecuteReader
            While Sreader.Read()
                If Sreader("IsVisible") = True Then
                    IsShowFiled.Checked = True
                Else
                    IsShowFiled.Checked = False
                End If
                txtFLtext.Text = Sreader("LText")
                TxtFLtop.Value = Sreader("LTop")
                TxtFLLeft.Value = Sreader("Lleft")
                TxtFLWidth.Value = Sreader("Lwidth")
                TxtFLHeight.Value = Sreader("LHeight")
                txtFRotate.Text = Sreader("Rotate")
                TxtFLFont.Text = Sreader("fontname")
                TxtFLFontSize.Text = Sreader("fontsize")
                TxtFLFontColor.Text = Sreader("fontcolor")
                TxtFLAlign.Text = Sreader("Align")
                TxtFLBackColor.Text = Sreader("backcolor")
                Try
                    TxtFLBackColor.BackColor = Color.FromName(Sreader("backcolor"))
                Catch ex As Exception

                End Try
                If Sreader("fontstyle") = 1 Then
                    TxtFLStyleB.Checked = True
                    TxtFLStyleU.Checked = False
                    TxtFLSytleI.Checked = False
                ElseIf Sreader("fontstyle") = 2 Then
                    TxtFLStyleB.Checked = False
                    TxtFLSytleI.Checked = True
                    TxtFLStyleU.Checked = False
                ElseIf Sreader("fontstyle") = 3 Then
                    TxtFLStyleB.Checked = False
                    TxtFLSytleI.Checked = False
                    TxtFLStyleU.Checked = True
                ElseIf Sreader("fontstyle") = 4 Then
                    TxtFLStyleB.Checked = True
                    TxtFLSytleI.Checked = True
                    TxtFLStyleU.Checked = False
                ElseIf Sreader("fontstyle") = 5 Then
                    TxtFLStyleB.Checked = True
                    TxtFLSytleI.Checked = False
                    TxtFLStyleU.Checked = True
                ElseIf Sreader("fontstyle") = 6 Then
                    TxtFLStyleB.Checked = False
                    TxtFLSytleI.Checked = True
                    TxtFLStyleU.Checked = True
                ElseIf Sreader("fontstyle") = 7 Then
                    TxtFLStyleB.Checked = True
                    TxtFLSytleI.Checked = True
                    TxtFLStyleU.Checked = True
                Else
                    TxtFLStyleB.Checked = False
                    TxtFLSytleI.Checked = False
                    TxtFLStyleU.Checked = False
                End If
                TxtBarcodeRotate.Text = Sreader("BarcodeRotate").ToString
                Try
                    IsCommaSep.Checked = Sreader("IsComaSep")
                Catch ex As Exception
                    IsCommaSep.Checked = False
                End Try
            End While
            Sreader.Close()
            Sreader = Nothing
            SQLFcmd2.Connection = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
            SqlConn1.Dispose()
        End Try
        txtFLtext.Font = TxtFLSample.Font
        If TxtFieldNames.Text.ToUpper = "BarcodeImage".ToUpper Then
            TxtBarcodeRotate.Visible = True
            ImSlabel1.Visible = True
        Else
            TxtBarcodeRotate.Visible = False
            ImSlabel1.Visible = False
        End If
    End Sub

    Private Sub ImsButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton7.Click

    End Sub

    Private Sub ImsButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton5.Click
        Me.Close()
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Dim inputval As String
        inputval = InputBox("Enter The Line Name ?", "Line Name", "")
        If inputval.Length > 0 Then
            If txtLineNames.Items.Contains(inputval) = False Then
                txtLineNames.Items.Add(inputval)
                IsNewLine = True
            Else
                MsgBox("The Name is already exists, Please Try Again")
            End If
        End If
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Dim inputval As String = ""
        inputval = InputBox("Enter The Rectangle  Name ?", "Rectangle Name", "")
        If inputval.Length > 0 Then
            If txtLineNames.Items.Contains(inputval) = False Then

                txtLineNames.Items.Add(inputval)
                IsNewLine = False
            Else
                MsgBox("The Name is already exists, Please Try Again")
            End If
        End If
    End Sub

    Private Sub UserButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton3.Click
        ColorDialog1.SolidColorOnly = True
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                txtLineColor.Text = ColorDialog1.Color.Name
                txtLineColor.BackColor = Color.FromName(ColorDialog1.Color.Name)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ImsButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton8.Click
        If txtLineNames.Text.Length = 0 Then
            MsgBox("Please Select the Line Name       ")
            txtLineNames.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to save the line ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
            Exit Sub
        End If

        If txtLineNames.Text.Length > 0 Then
            Dim SQLStr As String = ""
            If SQLIsFieldExists("SELECT TOP 1 1 from   barcodePrintLines where schemename=N'" & TxtSchemeName.Text & "' and fieldname=N'" & txtLineNames.Text & "'") = True Then
                SQLStr = "UPDATE barcodePrintLines SET "
                SQLStr = SQLStr & " schemename=N'" & TxtSchemeName.Text & "',"
                SQLStr = SQLStr & " Fieldname=N'" & txtLineNames.Text & "',"
                SQLStr = SQLStr & " linecolor=N'" & txtLineColor.Text & "',"
                SQLStr = SQLStr & " fillcolor='null',"
                SQLStr = SQLStr & " boarderstyle=N'" & txtLineStyle.Text & "',"
                If TxtLineShow.Checked = True Then
                    SQLStr = SQLStr & " isvisible='True',"
                Else
                    SQLStr = SQLStr & " isvisible='False',"
                End If
                SQLStr = SQLStr & " ltop=" & TxtLineY1.Value & ","
                SQLStr = SQLStr & " lleft=" & TxtLineX1.Value & ","
                SQLStr = SQLStr & " lwidth=" & TxtLinex2.Value & ","
                SQLStr = SQLStr & " lheight=" & TxtLineY2.Value & ","
                If TxtLineType.Text = "Line" Then
                    SQLStr = SQLStr & " FieldType=0,Rotate=" & CInt(TxtLineRotate.Text)
                Else
                    SQLStr = SQLStr & " FieldType=1,Rotate=" & CInt(TxtLineRotate.Text)
                End If

                SQLStr = SQLStr & ", boarderwidth=" & txtLineWidth.Value & "  where schemename=N'" & TxtSchemeName.Text & "' and fieldname=N'" & txtLineNames.Text & "'"
                ExecuteSQLQuery(SQLStr)
            Else
                SQLStr = "INSERT INTO [barcodePrintLines] ([schemename],[ltop],[lleft],[lwidth],[lheight],[fieldname],[FieldType],[LineColor],[BoarderStyle],[BoarderWidth],[IsVisible],[fillcolor],[Rotate])     VALUES " _
                    & "(@schemename,@ltop,@lleft,@lwidth,@lheight,@fieldname,@FieldType,@LineColor,@BoarderStyle,@BoarderWidth,@IsVisible,@fillcolor,@Rotate)     "
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim DBF As New SqlClient.SqlCommand(SQLStr, MAINCON)
                With DBF.Parameters

                    If IsNewLine = True Then
                        .AddWithValue("fieldtype", 0)
                    Else
                        .AddWithValue("fieldtype", 1)
                    End If
                    If TxtLineShow.Checked = True Then
                        .AddWithValue("isvisible", "True")
                    Else
                        .AddWithValue("isvisible", "False")
                    End If
                    .AddWithValue("schemename", TxtSchemeName.Text)
                    .AddWithValue("ltop", TxtLineY1.Value)
                    .AddWithValue("lleft", TxtLineX1.Value)
                    .AddWithValue("lwidth", TxtLinex2.Value)
                    .AddWithValue("lheight", TxtLineY2.Value)
                    .AddWithValue("Fieldname", txtLineNames.Text)
                    .AddWithValue("linecolor", txtLineColor.Text)
                    .AddWithValue("boarderstyle", txtLineStyle.Text)
                    .AddWithValue("boarderwidth", txtLineWidth.Value)
                    .AddWithValue("fillcolor", "null")
                    .AddWithValue("Rotate", CInt(TxtLineRotate.Text))
                End With
                DBF.ExecuteNonQuery()
                DBF = Nothing
                MAINCON.Close()
            End If
            IsNewLine = False
        End If
        PreviewReport()
    End Sub

    Private Sub txtLineNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLineNames.SelectedIndexChanged
        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SQLFcmd2 As New SqlClient.SqlCommand
            SQLFcmd2.Connection = SqlConn1
            SQLFcmd2.CommandText = "select * from barcodePrintLines where Schemename=N'" & TxtSchemeName.Text & "' and fieldname=N'" & txtLineNames.Text & "'"
            SQLFcmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd2.ExecuteReader
            While Sreader.Read()
                If Sreader("isvisible") = True Then
                    TxtLineShow.Checked = True
                Else
                    TxtLineShow.Checked = False
                End If
                TxtLineY1.Value = Sreader("ltop")
                TxtLineX1.Value = Sreader("lleft")
                TxtLinex2.Value = Sreader("lwidth")
                TxtLineY2.Value = Sreader("lheight")
                txtLineColor.Text = Sreader("linecolor")
                txtLineStyle.Text = Sreader("boarderstyle")
                txtLineWidth.Value = Sreader("boarderwidth")
                TxtLineRotate.Text = Sreader("Rotate")
                If Sreader("FieldType") = 0 Then
                    TxtLineType.Text = "Rectangle"
                Else
                    TxtLineType.Text = "Line"
                End If
            End While
            Sreader.Close()
            Sreader = Nothing
            SQLFcmd2.Connection = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
            SqlConn1.Dispose()
        End Try
    End Sub

    Private Sub btnNewImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewImage.Click
        Dim inputval As String
        inputval = InputBox("Enter The Image Name ?", "Image Name", "")
        If inputval.Length > 0 Then
            If inputval.Length > 40 Then
                MsgBox("The image name too long.... ")
                Exit Sub
            End If
            If TxtImagesList.Items.Contains(inputval) = False Then
                TxtImagesList.Items.Add(inputval)
            Else
                MsgBox("The Name is already exists, Please Try Again")
            End If
        End If
    End Sub

    Private Sub TxtImagesList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtImagesList.SelectedIndexChanged
        Dim SqlConn1 As New SqlClient.SqlConnection
        TxtImageTop.Text = "0"
        TxtImageLeft.Text = "0"
        TxtImageWidth.Text = "0"
        TxtImageHeight.Text = "0"
        TxtImagePath.Text = ""
        TxtImageOrderNo.Text = "0"
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SQLFcmd2 As New SqlClient.SqlCommand
            SQLFcmd2.Connection = SqlConn1
            SQLFcmd2.CommandText = "select * from barcodeprintimages where Schemename=N'" & TxtSchemeName.Text & "' and Imagename=N'" & TxtImagesList.Text & "'"
            SQLFcmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd2.ExecuteReader
            While Sreader.Read()
                If Sreader("isvisible") = True Then
                    Isshowimage.Checked = True
                Else
                    Isshowimage.Checked = False
                End If
                TxtImageTop.Text = Sreader("ltop")
                TxtImageLeft.Text = Sreader("lleft")
                TxtImageWidth.Text = Sreader("imagewidth")
                TxtImageHeight.Text = Sreader("imageheight")
                TxtImagePath.Text = Sreader("imagepath").ToString
                TxtImageOrderNo.Text = Sreader("orderno")

                Try
                    txtleftlogobox.Image = Image.FromFile(TxtImagePath.Text)
                Catch ex As Exception

                End Try
            End While
            Sreader.Close()
            Sreader = Nothing
            SQLFcmd2.Connection = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
            SqlConn1.Dispose()
        End Try
    End Sub

    Private Sub BtnSaveImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveImage.Click
        If TxtImagesList.Text.Length = 0 Then
            MsgBox("Please select the Image Name               ", MsgBoxStyle.Information)
            TxtImagesList.Focus()
            Exit Sub
        End If
        If TxtImagePath.Text.Length > 245 Then
            MsgBox("The image path/address is too long , please select the image less than 245 letters in length.... ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox("Do you want to save changes ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If SQLIsFieldExists("SELECT TOP 1 1 from   barcodeprintimages where Schemename=N'" & TxtSchemeName.Text & "' and Imagename=N'" & TxtImagesList.Text & "'") = True Then
                Dim sqlstr As String = ""
                If Isshowimage.Checked = True Then
                    sqlstr = "UPDATE [barcodeprintimages]   SET [imagewidth] =" & CDbl(TxtImageWidth.Text) & " ,[imageHeight] =" & CDbl(TxtImageHeight.Text) & " ,[LTop] =" & CDbl(TxtImageTop.Text) & " ,[Lleft] =" & CDbl(TxtImageLeft.Text) & " ,[imagepath] =N'" & TxtImagePath.Text & "' ,[Orderno] =" & CInt(TxtImageOrderNo.Text) & " ,[IsVisible] ='True',Rotate=0  where Schemename=N'" & TxtSchemeName.Text & "' and Imagename=N'" & TxtImagesList.Text & "'"
                Else
                    sqlstr = "UPDATE [barcodeprintimages]   SET [imagewidth] =" & CDbl(TxtImageWidth.Text) & " ,[imageHeight] =" & CDbl(TxtImageHeight.Text) & " ,[LTop] =" & CDbl(TxtImageTop.Text) & " ,[Lleft] =" & CDbl(TxtImageLeft.Text) & " ,[imagepath] =N'" & TxtImagePath.Text & "' ,[Orderno] =" & CInt(TxtImageOrderNo.Text) & " ,[IsVisible] ='False',Rotate=0  where Schemename=N'" & TxtSchemeName.Text & "' and Imagename=N'" & TxtImagesList.Text & "'"
                End If
                ExecuteSQLQuery(sqlstr)
            Else
                Dim sqlstr As String = ""
                If Isshowimage.Checked = True Then
                    sqlstr = " INSERT INTO [barcodeprintimages] ([Schemename],[imagewidth],[imageHeight],[LTop],[Lleft],[imagepath],[Orderno],[IsVisible],[Imagename],[Rotate])     VALUES " _
                        & "(N'" & TxtSchemeName.Text & "'," & CDbl(TxtImageWidth.Text) & "," & CDbl(TxtImageHeight.Text) & "," & CDbl(TxtImageTop.Text) & "," & CDbl(TxtImageLeft.Text) & ",N'" & TxtImagePath.Text & "'," & CInt(TxtImageOrderNo.Text) & ",'True',N'" & TxtImagesList.Text & "',0)"
                Else
                    sqlstr = " INSERT INTO [barcodeprintimages] ([Schemename],[imagewidth],[imageHeight],[LTop],[Lleft],[imagepath],[Orderno],[IsVisible],[Imagename],[Rotate])     VALUES " _
                        & "(N'" & TxtSchemeName.Text & "'," & CDbl(TxtImageWidth.Text) & "," & CDbl(TxtImageHeight.Text) & "," & CDbl(TxtImageTop.Text) & "," & CDbl(TxtImageLeft.Text) & ",N'" & TxtImagePath.Text & "'," & CInt(TxtImageOrderNo.Text) & ",'False',N'" & TxtImagesList.Text & "',0)"
                End If
                ExecuteSQLQuery(sqlstr)
            End If
            PreviewReport()
        End If
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        If TxtImagesList.Text.Length = 0 Then
            MsgBox("Please select the Image Name               ", MsgBoxStyle.Information)
            TxtImagesList.Focus()
            Exit Sub
        End If
        OpenFileDialog1.Title = "Select The Image "
        OpenFileDialog1.Filter = "(Image Files)|*.jpg;*.png;*.bmp;*.gif |Jpg, | *.jpg | Png, | *.png|Bmp, | *.bmp|Gif, | *.gif"

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TxtImagePath.Text = OpenFileDialog1.FileName
            Try
                txtleftlogobox.Image = Image.FromFile(TxtImagePath.Text)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TxtZoom_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtZoom.SelectedIndexChanged
        On Error Resume Next
        If UCase(TxtZoom.Text) = "AUTO" Then
            Me.PrintPreviewControl2.AutoZoom = True
        Else
            Me.PrintPreviewControl2.AutoZoom = False
            If TxtZoom.Text = "25%" Then
                Me.PrintPreviewControl2.Zoom = 0.25
            ElseIf TxtZoom.Text = "50%" Then
                Me.PrintPreviewControl2.Zoom = 0.5
            ElseIf TxtZoom.Text = "75%" Then
                Me.PrintPreviewControl2.Zoom = 0.75
            ElseIf TxtZoom.Text = "100%" Then
                Me.PrintPreviewControl2.Zoom = 1
            Else
                Me.PrintPreviewControl2.Zoom = 2
            End If
        End If
    End Sub

    Private Sub UserButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton5.Click
        Try
            PrintPreviewControl2.StartPage = PrintPreviewControl2.StartPage - 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UserButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton6.Click
        Try
            PrintPreviewControl2.StartPage = PrintPreviewControl2.StartPage + 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnNewScheme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewScheme.Click
        If MsgBox("Do you want to Create New Template ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim inputval As String
            inputval = InputBox("Enter The Template Name ?", "Template Name", "")
            If inputval.Length > 0 Then
                If inputval.Length > 40 Then
                    MsgBox("The Template name too long.... ")
                    Exit Sub
                End If
                If TxtSchemeName.Items.Contains(inputval) = False Then
                    TxtSchemeName.Items.Add(inputval)
                Else
                    MsgBox("The Template Name is already exists, Please Try Again")
                End If
            End If
        End If
    End Sub



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
            TxtFLFontSize.Text = txtFont.Font.Size
            TxtFLFontColor.Text = txtFont.Color.Name.ToString

            txtFLtext.Font = txtFont.Font

        End If
    End Sub


  

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ColorDialog1.SolidColorOnly = True

        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                TxtFLBackColor.Text = ColorDialog1.Color.Name
                TxtFLBackColor.BackColor = Color.FromName(ColorDialog1.Color.Name)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ImsButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton10.Click
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        PrintOnthermalPaperUsingFile()

    End Sub
    Sub PrintOnthermalPaperUsingFile()
        Dim docName As String = "1.txt"
        Dim docPath As String = Microsoft.VisualBasic.CurDir & "\"
        PrintDocument1.DocumentName = docName
        Dim stream As New FileStream(docPath + docName, FileMode.Open)
        Try
            Dim reader As New StreamReader(stream)
            Try
                Printtext1 = reader.ReadToEnd()
            Finally
                reader.Dispose()
            End Try
        Finally
            stream.Dispose()
        End Try

        Dim tempstr As String = Printtext1
        If TxtList.SelectedRows.Count > 1 Then
            If MsgBox("Do you want to print all selected stock list one by one  ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                For Each x As DataGridViewRow In TxtList.SelectedRows
                    tempstr = Printtext1
                    tempstr = tempstr.Replace("@barcode", TxtList.Item("barcode", x.Index).Value)
                    tempstr = tempstr.Replace("@itemcode", TxtList.Item("stockcode", x.Index).Value)
                    tempstr = tempstr.Replace("@itemname", TxtList.Item("stockname", x.Index).Value)
                    tempstr = tempstr.Replace("@mrp", TxtList.Item("mrp", x.Index).Value)
                    tempstr = tempstr.Replace("PRINT 1,1", "PRINT 1," & TxtThermalNoOfCopies.Value)
                    StringtoPrint = StringtoPrint & tempstr
                Next
            End If

        Else
            If MsgBox("Do you want to Print ? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            For Each x As DataGridViewRow In TxtList.SelectedRows
                tempstr = Printtext1
                tempstr = tempstr.Replace("@barcode", TxtList.Item("barcode", x.Index).Value)
                tempstr = tempstr.Replace("@itemcode", TxtList.Item("stockcode", x.Index).Value)
                tempstr = tempstr.Replace("@itemname", TxtList.Item("stockname", x.Index).Value)
                tempstr = tempstr.Replace("@mrp", TxtList.Item("mrp", x.Index).Value)
                tempstr = tempstr.Replace("PRINT 1,1", "PRINT 1," & TxtThermalNoOfCopies.Value)
                StringtoPrint = StringtoPrint & tempstr
            Next
        End If

      
        PrintDocument1.Print()
    End Sub
    Sub PrintOnthermalPaperUsingFile2Cols()
        Dim docName As String = "2.txt"
        Dim docPath As String = Microsoft.VisualBasic.CurDir & "\"
        PrintDocument1.DocumentName = docName
        Dim stream As New FileStream(docPath + docName, FileMode.Open)
        Try
            Dim reader As New StreamReader(stream)
            Try
                Printtext1 = reader.ReadToEnd()
            Finally
                reader.Dispose()
            End Try
        Finally
            stream.Dispose()
        End Try

        Dim tempstr As String = Printtext1
        If TxtList.SelectedRows.Count > 1 Then
            If MsgBox("Do you want to print all selected stock list one by one  ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                For Each x As DataGridViewRow In TxtList.SelectedRows
                    tempstr = Printtext1
                    tempstr = tempstr.Replace("@barcode", TxtList.Item("barcode", x.Index).Value)
                    tempstr = tempstr.Replace("@itemcode", TxtList.Item("stockcode", x.Index).Value)
                    tempstr = tempstr.Replace("@itemname", TxtList.Item("stockname", x.Index).Value)
                    tempstr = tempstr.Replace("@mrp", TxtList.Item("mrp", x.Index).Value)
                    tempstr = tempstr.Replace("PRINT 1,1", "PRINT 1," & TxtThermalNoOfCopies.Value)
                    StringtoPrint = StringtoPrint & tempstr
                Next
            End If

        Else
            If MsgBox("Do you want to Print ? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            For Each x As DataGridViewRow In TxtList.SelectedRows
                tempstr = Printtext1
                tempstr = tempstr.Replace("@barcode", TxtList.Item("barcode", x.Index).Value)
                tempstr = tempstr.Replace("@itemcode", TxtList.Item("stockcode", x.Index).Value)
                tempstr = tempstr.Replace("@itemname", TxtList.Item("stockname", x.Index).Value)
                tempstr = tempstr.Replace("@mrp", TxtList.Item("mrp", x.Index).Value)
                tempstr = tempstr.Replace("PRINT 1,1", "PRINT 1," & TxtThermalNoOfCopies.Value)
                StringtoPrint = StringtoPrint & tempstr
            Next
        End If



        PrintDocument1.Print()
    End Sub
    Private Sub PrintDocument1_BeginPrint1(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint

    End Sub

    Private Sub PrintDocument1_PrintPage_1(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim charactersOnPage As Integer = 0
        Dim linesPerPage As Integer = 0

        ' Sets the value of charactersOnPage to the number of characters  
        ' of stringToPrint that will fit within the bounds of the page.
        e.Graphics.MeasureString(StringtoPrint, Me.Font, e.MarginBounds.Size, _
            StringFormat.GenericTypographic, charactersOnPage, linesPerPage)

        ' Draws the string within the bounds of the page
        e.Graphics.DrawString(StringtoPrint, Me.Font, Brushes.Black, _
            e.MarginBounds, StringFormat.GenericTypographic)

        ' Remove the portion of the string that has been printed.
        StringtoPrint = StringtoPrint.Substring(charactersOnPage)

        ' Check to see if more pages are to be printed.
        e.HasMorePages = StringtoPrint.Length > 0
    End Sub

    Private Sub TxtStockCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockCode.TextChanged
        Dim str As String = ""
        If TxtStockCode.Text.Length = 0 Then
            str = "  stockcode LIKE N'%" & TxtStockCode.Text & "%' and stocktype=0 "
        Else
            str = "  stockcode LIKE N'%" & TxtStockCode.Text & "%' and stocktype=0 "
        End If
        LoadStock(str)
    End Sub

    Private Sub TxtStockName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockName.TextChanged
        Dim str As String = ""
        If TxtStockName.Text.Length = 0 Then
            str = "  stockname LIKE N'%" & TxtStockName.Text & "%' and stocktype=0 "
        Else
            str = "  stockname LIKE N'%" & TxtStockName.Text & "%' and stocktype=0 "
        End If
        LoadStock(str)
    End Sub

    Private Sub TxtGroup_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtGroup.SelectedIndexChanged
        LoadStock()
    End Sub

    Private Sub TxtCat_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCat.SelectedIndexChanged
        LoadStock()
    End Sub

    Private Sub ImsButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton11.Click
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        PrintOnthermalPaperUsingFile2Cols()
    End Sub

    Private Sub BtnSaveAs_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub TxtBarcodeType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtBarcodeType.SelectedIndexChanged

    End Sub
End Class