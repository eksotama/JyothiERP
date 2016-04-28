Imports System.Data.SqlClient
Imports System.IO

Public Class Barcodeprintingnewfrm
    Dim SqlSTR As String = ""
    Dim isImagechanged As Boolean = False

    Sub LoadStock(Optional ByVal WhereStr As String = "")
        Dim AdditionSqlText = ""

        SqlSTR = "SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [SNO], StockCode , stockName ,[custBarcode] as [BARCODE],MRP, StockDRP as [DRP],StockWRP as [WRP],0 as [No Of Copies]  FROM [StockDbf]  where location=N'" & GetDefLocationName() & "'"

        Dim TempBS As New BindingSource

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlSTR)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            TxtList.Columns("SNO").Width = 80
            TxtList.Columns("MRP").Width = 80
            TxtList.Columns("dRP").Width = 80
            TxtList.Columns("wRP").Width = 80
            TxtList.Columns("No Of Copies").Width = 80
            TxtList.Columns("Stockcode").Width = 150
            TxtList.Columns("stockName").Width = 150
            TxtList.Columns("BARCODE").Width = 120
            TxtList.Columns("SNo").ReadOnly = True
        Catch ex As Exception

        End Try



    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        TxtList.ClearSelection()
        For i As Integer = TxtList.Rows.Count - 1 To 0 Step -1
            Dim s As String = TxtList.Item("stockcode", i).Value.ToString.ToUpper
            If s.Contains(TxtStockCode.Text.ToUpper) = True Then
                TxtList.FirstDisplayedCell = TxtList.Item(0, i)
                TxtList.Item(0, i).Selected = True

            End If
        Next

    End Sub

    Private Sub Barcodeprintingnewfrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub Printbarcode48Lfrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDataIntoComboBox("select Schemename from barcodeprintsettings ", TxtSchemeName, "Schemename", "*New")
        Try
            TxtSchemeName.SelectedIndex = 1
        Catch ex As Exception
            Try
                TxtSchemeName.SelectedIndex = 0
            Catch ex2 As Exception

            End Try
        End Try
        TxtCurrency.Text = CompDetails.Currency
        TxtCmpName.Text = CompDetails.CompanyName

        LoadStock()
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        TxtList.ClearSelection()
        For i As Integer = TxtList.Rows.Count - 1 To 0 Step -1
            Dim s As String = TxtList.Item("stockname", i).Value.ToString.ToUpper
            If s.Contains(TxtStockName.Text.ToUpper) = True Then
                TxtList.FirstDisplayedCell = TxtList.Item(0, i)
                TxtList.Item(0, i).Selected = True

            End If
        Next
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        TxtList.ClearSelection()
        For i As Integer = TxtList.Rows.Count - 1 To 0 Step -1
            Dim s As String = TxtList.Item("BARCODE", i).Value.ToString.ToUpper
            If s.Contains(TxtBarcode.Text.ToUpper) = True Then
                TxtList.FirstDisplayedCell = TxtList.Item(0, i)

                TxtList.Item(0, i).Selected = True

            End If
        Next
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click
        If cbEncodeType.Text.Length = 0 Then
            cbEncodeType.Text = "Code 128"
        End If
        PrintReport()
    End Sub
    Sub PrintReport(Optional IsDirectToPrinter As Boolean = False)
        If MsgBox("Do You want to Print ? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        lOADbCODEDATA()
        Dim facter As Double = 56.692913386

        Me.Cursor = Cursors.WaitCursor
        Dim ds As New BarcodeListDataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("Select * from printbarcodeList", cnn)
        dscmd.Fill(ds, "printbarcodeList")
        cnn.Close()
        Dim objRpt As New Barcode39CRReport

        'setting fileds for crreports
        If TxtPaperSize.Text = "A4" Then
            objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4
            objRpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
        Else
            objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLegal
        End If
        objRpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
        objRpt.Section2.Height = 0
        objRpt.Section1.Height = 0
        objRpt.Section4.Height = 0
        objRpt.Section5.Height = 0
        Dim margin As New CrystalDecisions.Shared.PageMargins()
        margin = objRpt.PrintOptions.PageMargins
        margin.leftMargin = CInt(TxtLeft.Value * facter)
        margin.rightMargin = 0
        margin.topMargin = CInt(TxtTop.Value * facter)
        margin.bottomMargin = 0
        objRpt.PrintOptions.ApplyPageMargins(margin)


        Dim dt As New DataTable
        dt = SQLLoadGridData("select * from BarcodeFieldSettings where Schemename=N'" & TxtSchemeName.Text & "'")
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i).Item("FiledName").ToString.ToUpper = "Barcode".ToUpper Then
                    If dt.Rows(i).Item("IsVisible") = True Then
                        If cbEncodeType.Text = "Use Code39BarcodeFont" Or cbEncodeType.Text.Length = 0 Then

                            CType(objRpt.Section3.ReportObjects.Item("barcode11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                            'Fontname
                            Dim drawFont As Font = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")))
                            Select Case dt.Rows(i).Item("fontstyle")
                                Case 1
                                    drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold)
                                Case 2
                                    drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Italic)
                                Case 3
                                    drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Underline)
                                Case 4
                                    drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold Or FontStyle.Italic)
                                Case 5
                                    drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold Or FontStyle.Underline)
                                Case 6
                                    drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Italic Or FontStyle.Underline)
                                Case 7
                                    drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                                Case 8
                                    drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Regular)

                            End Select

                            If dt.Rows(i).Item("align").ToString.Trim = "Left" Then
                                CType(objRpt.Section3.ReportObjects.Item("barcode11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                                CType(objRpt.Section3.ReportObjects.Item("barcode21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                                CType(objRpt.Section3.ReportObjects.Item("barcode31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                                CType(objRpt.Section3.ReportObjects.Item("barcode41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                                CType(objRpt.Section3.ReportObjects.Item("barcode51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                                CType(objRpt.Section3.ReportObjects.Item("barcode61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            ElseIf dt.Rows(i).Item("align").ToString.Trim = "Right" Then
                                CType(objRpt.Section3.ReportObjects.Item("barcode11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                                CType(objRpt.Section3.ReportObjects.Item("barcode21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                                CType(objRpt.Section3.ReportObjects.Item("barcode31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                                CType(objRpt.Section3.ReportObjects.Item("barcode41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                                CType(objRpt.Section3.ReportObjects.Item("barcode51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                                CType(objRpt.Section3.ReportObjects.Item("barcode61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            Else
                                CType(objRpt.Section3.ReportObjects.Item("barcode11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                                CType(objRpt.Section3.ReportObjects.Item("barcode21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                                CType(objRpt.Section3.ReportObjects.Item("barcode31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                                CType(objRpt.Section3.ReportObjects.Item("barcode41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                                CType(objRpt.Section3.ReportObjects.Item("barcode51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                                CType(objRpt.Section3.ReportObjects.Item("barcode61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            End If


                            CType(objRpt.Section3.ReportObjects.Item("barcode11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                            CType(objRpt.Section3.ReportObjects.Item("barcode21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                            CType(objRpt.Section3.ReportObjects.Item("barcode31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                            CType(objRpt.Section3.ReportObjects.Item("barcode41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                            CType(objRpt.Section3.ReportObjects.Item("barcode51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                            CType(objRpt.Section3.ReportObjects.Item("barcode61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)


                            CType(objRpt.Section3.ReportObjects.Item("barcode11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("barcode21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("barcode31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("barcode41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("barcode51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("barcode61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))

                            If dt.Rows(i).Item("backcolor").ToString.ToUpper = "NULL" Or dt.Rows(i).Item("backcolor").ToString.ToUpper = "WHITE" Then

                            Else
                                CType(objRpt.Section3.ReportObjects.Item("barcode11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                                CType(objRpt.Section3.ReportObjects.Item("barcode21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                                CType(objRpt.Section3.ReportObjects.Item("barcode31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                                CType(objRpt.Section3.ReportObjects.Item("barcode41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                                CType(objRpt.Section3.ReportObjects.Item("barcode51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                                CType(objRpt.Section3.ReportObjects.Item("barcode61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))

                            End If


                            CType(objRpt.Section3.ReportObjects.Item("barcode11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter + TxtWidth.Value * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 2 + TxtWidth.Value * 2 * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 3 + TxtWidth.Value * 3 * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 4 + TxtWidth.Value * 4 * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 5 + TxtWidth.Value * 5 * facter)

                            CType(objRpt.Section3.ReportObjects.Item("barcode11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)

                            CType(objRpt.Section3.ReportObjects.Item("barcode11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("barcode61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)

                            'HIDE BARCODE IMAGE FILEDS
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True

                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Top = 0
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Top = 0
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Top = 0
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Top = 0
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Top = 0
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Top = 0

                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Width = 0
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Width = 0
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Width = 0
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Width = 0
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Width = 0
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Width = 0

                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Height = 0
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Height = 0
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Height = 0
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Height = 0
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Height = 0
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Height = 0
                        Else
                            'HIDE ALL FONT BARCODE FILEDS
                            CType(objRpt.Section3.ReportObjects.Item("barcode11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                            CType(objRpt.Section3.ReportObjects.Item("barcode21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                            CType(objRpt.Section3.ReportObjects.Item("barcode31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                            CType(objRpt.Section3.ReportObjects.Item("barcode41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                            CType(objRpt.Section3.ReportObjects.Item("barcode51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                            CType(objRpt.Section3.ReportObjects.Item("barcode61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True

                            CType(objRpt.Section3.ReportObjects.Item("barcode11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                            CType(objRpt.Section3.ReportObjects.Item("barcode21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                            CType(objRpt.Section3.ReportObjects.Item("barcode31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                            CType(objRpt.Section3.ReportObjects.Item("barcode41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                            CType(objRpt.Section3.ReportObjects.Item("barcode51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                            CType(objRpt.Section3.ReportObjects.Item("barcode61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0

                            CType(objRpt.Section3.ReportObjects.Item("barcode11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                            CType(objRpt.Section3.ReportObjects.Item("barcode21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                            CType(objRpt.Section3.ReportObjects.Item("barcode31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                            CType(objRpt.Section3.ReportObjects.Item("barcode41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                            CType(objRpt.Section3.ReportObjects.Item("barcode51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                            CType(objRpt.Section3.ReportObjects.Item("barcode61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0

                            CType(objRpt.Section3.ReportObjects.Item("barcode11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                            CType(objRpt.Section3.ReportObjects.Item("barcode21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                            CType(objRpt.Section3.ReportObjects.Item("barcode31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                            CType(objRpt.Section3.ReportObjects.Item("barcode41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                            CType(objRpt.Section3.ReportObjects.Item("barcode51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                            CType(objRpt.Section3.ReportObjects.Item("barcode61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0

                            'FOR DIRCET IAMGES

                              'Fontname

                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True

                         
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)



                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter + TxtWidth.Value * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 2 + TxtWidth.Value * 2 * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 3 + TxtWidth.Value * 3 * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 4 + TxtWidth.Value * 4 * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 5 + TxtWidth.Value * 5 * facter)

                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)

                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeImage66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                            If TxtNoCols.Value = 1 Then
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = 0
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = 0
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = 0
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = 0
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = 0
                            ElseIf TxtNoCols.Value = 2 Then
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = 0
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = 0
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = 0
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = 0
                            ElseIf TxtNoCols.Value = 3 Then
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = 0
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = 0
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = 0
                            ElseIf TxtNoCols.Value = 4 Then
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = 0
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = 0
                            ElseIf TxtNoCols.Value = 5 Then
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = 0
                            ElseIf TxtNoCols.Value = 6 Then
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                                CType(objRpt.Section3.ReportObjects.Item("BarcodeImage66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
                            End If
                        End If
                        
                    Else
                        CType(objRpt.Section3.ReportObjects.Item("barcode11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("barcode21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("barcode31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("barcode41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("barcode51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("barcode61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True

                        CType(objRpt.Section3.ReportObjects.Item("barcode11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("barcode21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("barcode31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("barcode41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("barcode51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("barcode61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0

                        CType(objRpt.Section3.ReportObjects.Item("barcode11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("barcode21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("barcode31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("barcode41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("barcode51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("barcode61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0

                        CType(objRpt.Section3.ReportObjects.Item("barcode11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("barcode21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("barcode31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("barcode41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("barcode51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("barcode61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                    End If
                ElseIf dt.Rows(i).Item("FiledName").ToString.ToUpper = "BarcodeText".ToUpper Then
                    If dt.Rows(i).Item("IsVisible") = True Then
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        'Fontname
                        Dim drawFont As Font = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")))
                        Select Case dt.Rows(i).Item("fontstyle")
                            Case 1
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold)
                            Case 2
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Italic)
                            Case 3
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Underline)
                            Case 4
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold Or FontStyle.Italic)
                            Case 5
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold Or FontStyle.Underline)
                            Case 6
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Italic Or FontStyle.Underline)
                            Case 7
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                            Case 8
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Regular)

                        End Select

                        If dt.Rows(i).Item("align").ToString.Trim = "Left" Then
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                        ElseIf dt.Rows(i).Item("align").ToString.Trim = "Right" Then
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                        Else
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                        End If


                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)


                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))

                        If dt.Rows(i).Item("backcolor").ToString.ToUpper = "NULL" Or dt.Rows(i).Item("backcolor").ToString.ToUpper = "WHITE" Then

                        Else
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))

                        End If


                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter + TxtWidth.Value * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 2 + TxtWidth.Value * 2 * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 3 + TxtWidth.Value * 3 * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 4 + TxtWidth.Value * 4 * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 5 + TxtWidth.Value * 5 * facter)

                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)

                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        If TxtNoCols.Value < 5 Then
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        ElseIf TxtNoCols.Value = 5 Then
                            CType(objRpt.Section3.ReportObjects.Item("BarcodeText61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        End If
                    Else
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True

                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0

                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0

                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("BarcodeText61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                    End If
                ElseIf dt.Rows(i).Item("FiledName").ToString.ToUpper = "CompanyName".ToUpper Then
                    If dt.Rows(i).Item("IsVisible") = True Then
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        'Fontname
                        Dim drawFont As Font = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")))
                        Select Case dt.Rows(i).Item("fontstyle")
                            Case 1
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold)
                            Case 2
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Italic)
                            Case 3
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Underline)
                            Case 4
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold Or FontStyle.Italic)
                            Case 5
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold Or FontStyle.Underline)
                            Case 6
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Italic Or FontStyle.Underline)
                            Case 7
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                            Case 8
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Regular)

                        End Select

                        If dt.Rows(i).Item("align").ToString.Trim = "Left" Then
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                        ElseIf dt.Rows(i).Item("align").ToString.Trim = "Right" Then
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                        Else
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                        End If


                        CType(objRpt.Section3.ReportObjects.Item("Cmpname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)


                        CType(objRpt.Section3.ReportObjects.Item("Cmpname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))

                        If dt.Rows(i).Item("backcolor").ToString.ToUpper = "NULL" Or dt.Rows(i).Item("backcolor").ToString.ToUpper = "WHITE" Then

                        Else
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))

                        End If


                        CType(objRpt.Section3.ReportObjects.Item("Cmpname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter + TxtWidth.Value * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 2 + TxtWidth.Value * 2 * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 3 + TxtWidth.Value * 3 * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 4 + TxtWidth.Value * 4 * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 5 + TxtWidth.Value * 5 * facter)

                        CType(objRpt.Section3.ReportObjects.Item("Cmpname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)

                        CType(objRpt.Section3.ReportObjects.Item("Cmpname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        If TxtNoCols.Value < 5 Then
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        ElseIf TxtNoCols.Value = 5 Then
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        End If
                    Else
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True

                        CType(objRpt.Section3.ReportObjects.Item("Cmpname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0

                        CType(objRpt.Section3.ReportObjects.Item("Cmpname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0

                        CType(objRpt.Section3.ReportObjects.Item("Cmpname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("Cmpname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                    End If
                ElseIf dt.Rows(i).Item("FiledName").ToString.ToUpper = "ItemName".ToUpper Then
                    If dt.Rows(i).Item("IsVisible") = True Then
                        CType(objRpt.Section3.ReportObjects.Item("itemname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        'Fontname
                        Dim drawFont As Font = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")))
                        Select Case dt.Rows(i).Item("fontstyle")
                            Case 1
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold)
                            Case 2
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Italic)
                            Case 3
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Underline)
                            Case 4
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold Or FontStyle.Italic)
                            Case 5
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold Or FontStyle.Underline)
                            Case 6
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Italic Or FontStyle.Underline)
                            Case 7
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                            Case 8
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Regular)

                        End Select

                        If dt.Rows(i).Item("align").ToString.Trim = "Left" Then
                            CType(objRpt.Section3.ReportObjects.Item("itemname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("itemname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("itemname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("itemname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("itemname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("itemname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                        ElseIf dt.Rows(i).Item("align").ToString.Trim = "Right" Then
                            CType(objRpt.Section3.ReportObjects.Item("itemname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("itemname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("itemname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("itemname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("itemname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("itemname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                        Else
                            CType(objRpt.Section3.ReportObjects.Item("itemname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("itemname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("itemname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("itemname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("itemname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("itemname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                        End If


                        CType(objRpt.Section3.ReportObjects.Item("itemname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("itemname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("itemname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("itemname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("itemname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("itemname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)


                        CType(objRpt.Section3.ReportObjects.Item("itemname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("itemname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("itemname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("itemname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("itemname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("itemname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))

                        If dt.Rows(i).Item("backcolor").ToString.ToUpper = "NULL" Or dt.Rows(i).Item("backcolor").ToString.ToUpper = "WHITE" Then

                        Else
                            CType(objRpt.Section3.ReportObjects.Item("itemname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("itemname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("itemname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("itemname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("itemname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("itemname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))

                        End If


                        CType(objRpt.Section3.ReportObjects.Item("itemname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter + TxtWidth.Value * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 2 + TxtWidth.Value * 2 * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 3 + TxtWidth.Value * 3 * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 4 + TxtWidth.Value * 4 * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 4 + TxtWidth.Value * 5 * facter)

                        CType(objRpt.Section3.ReportObjects.Item("itemname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)

                        CType(objRpt.Section3.ReportObjects.Item("itemname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("itemname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        If TxtNoCols.Value < 5 Then
                            CType(objRpt.Section3.ReportObjects.Item("itemname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        ElseIf TxtNoCols.Value = 5 Then
                            CType(objRpt.Section3.ReportObjects.Item("Cmpname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        End If
                    Else
                        CType(objRpt.Section3.ReportObjects.Item("itemname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("itemname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("itemname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("itemname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("itemname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("itemname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True

                        CType(objRpt.Section3.ReportObjects.Item("itemname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("itemname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("itemname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("itemname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("itemname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("itemname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0

                        CType(objRpt.Section3.ReportObjects.Item("itemname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("itemname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("itemname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("itemname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("itemname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("itemname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0

                        CType(objRpt.Section3.ReportObjects.Item("itemname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("itemname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("itemname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("itemname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("itemname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("itemname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                    End If
                ElseIf dt.Rows(i).Item("FiledName").ToString.ToUpper = "MRP".ToUpper Then
                    If dt.Rows(i).Item("IsVisible") = True Then
                        CType(objRpt.Section3.ReportObjects.Item("mrp11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        'Fontname
                        Dim drawFont As Font = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")))
                        Select Case dt.Rows(i).Item("fontstyle")
                            Case 1
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold)
                            Case 2
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Italic)
                            Case 3
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Underline)
                            Case 4
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold Or FontStyle.Italic)
                            Case 5
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold Or FontStyle.Underline)
                            Case 6
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Italic Or FontStyle.Underline)
                            Case 7
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                            Case 8
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Regular)

                        End Select

                        If dt.Rows(i).Item("align").ToString.Trim = "Left" Then
                            CType(objRpt.Section3.ReportObjects.Item("mrp11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("mrp21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("mrp31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("mrp41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("mrp51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("mrp61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                        ElseIf dt.Rows(i).Item("align").ToString.Trim = "Right" Then
                            CType(objRpt.Section3.ReportObjects.Item("mrp11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("mrp21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("mrp31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("mrp41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("mrp51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("mrp61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                        Else
                            CType(objRpt.Section3.ReportObjects.Item("mrp11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("mrp21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("mrp31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("mrp41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("mrp51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("mrp61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                        End If


                        CType(objRpt.Section3.ReportObjects.Item("mrp11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("mrp21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("mrp31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("mrp41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("mrp51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("mrp61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)


                        CType(objRpt.Section3.ReportObjects.Item("mrp11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("mrp21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("mrp31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("mrp41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("mrp51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("mrp61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))

                        If dt.Rows(i).Item("backcolor").ToString.ToUpper = "NULL" Or dt.Rows(i).Item("backcolor").ToString.ToUpper = "WHITE" Then

                        Else
                            CType(objRpt.Section3.ReportObjects.Item("mrp11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("mrp21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("mrp31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("mrp41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("mrp51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("mrp61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))

                        End If


                        CType(objRpt.Section3.ReportObjects.Item("mrp11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter + TxtWidth.Value * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 2 + TxtWidth.Value * 2 * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 3 + TxtWidth.Value * 3 * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 4 + TxtWidth.Value * 4 * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 5 + TxtWidth.Value * 5 * facter)

                        CType(objRpt.Section3.ReportObjects.Item("mrp11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)

                        CType(objRpt.Section3.ReportObjects.Item("mrp11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("mrp61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        If TxtNoCols.Value < 5 Then
                            CType(objRpt.Section3.ReportObjects.Item("mrp51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                            CType(objRpt.Section3.ReportObjects.Item("mrp61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        ElseIf TxtNoCols.Value = 5 Then
                            CType(objRpt.Section3.ReportObjects.Item("mrp61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        End If
                    Else
                        CType(objRpt.Section3.ReportObjects.Item("mrp11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("mrp21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("mrp31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("mrp41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("mrp51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("mrp61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True

                        CType(objRpt.Section3.ReportObjects.Item("mrp11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("mrp21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("mrp31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("mrp41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("mrp51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("mrp61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0

                        CType(objRpt.Section3.ReportObjects.Item("mrp11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("mrp21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("mrp31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("mrp41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("mrp51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("mrp61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0

                        CType(objRpt.Section3.ReportObjects.Item("mrp11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("mrp21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("mrp31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("mrp41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("mrp51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("mrp61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                    End If
                ElseIf dt.Rows(i).Item("FiledName").ToString.ToUpper = "Price".ToUpper Then
                    If dt.Rows(i).Item("IsVisible") = True Then
                        CType(objRpt.Section3.ReportObjects.Item("price11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = CInt(dt.Rows(i).Item("LTop") * facter)
                        'Fontname
                        Dim drawFont As Font = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")))
                        Select Case dt.Rows(i).Item("fontstyle")
                            Case 1
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold)
                            Case 2
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Italic)
                            Case 3
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Underline)
                            Case 4
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold Or FontStyle.Italic)
                            Case 5
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold Or FontStyle.Underline)
                            Case 6
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Italic Or FontStyle.Underline)
                            Case 7
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                            Case 8
                                drawFont = New Font(dt.Rows(i).Item("Fontname").ToString, CSng(dt.Rows(i).Item("fontsize")), FontStyle.Regular)

                        End Select

                        If dt.Rows(i).Item("align").ToString.Trim = "Left" Then
                            CType(objRpt.Section3.ReportObjects.Item("price11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("price21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("price31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("price41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("price51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                            CType(objRpt.Section3.ReportObjects.Item("price61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign
                        ElseIf dt.Rows(i).Item("align").ToString.Trim = "Right" Then
                            CType(objRpt.Section3.ReportObjects.Item("price11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("price21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("price31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("price41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("price51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                            CType(objRpt.Section3.ReportObjects.Item("price61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign
                        Else
                            CType(objRpt.Section3.ReportObjects.Item("price11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("price21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("price31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("price41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("price51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                            CType(objRpt.Section3.ReportObjects.Item("price61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                        End If


                        CType(objRpt.Section3.ReportObjects.Item("price11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("price21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("price31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("price41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("price51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)
                        CType(objRpt.Section3.ReportObjects.Item("price61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ApplyFont(drawFont)


                        CType(objRpt.Section3.ReportObjects.Item("price11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("price21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("price31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("price41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("price51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))
                        CType(objRpt.Section3.ReportObjects.Item("price61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Color = Color.FromName(dt.Rows(i).Item("fontcolor"))

                        If dt.Rows(i).Item("backcolor").ToString.ToUpper = "NULL" Or dt.Rows(i).Item("backcolor").ToString.ToUpper = "WHITE" Then

                        Else
                            CType(objRpt.Section3.ReportObjects.Item("price11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("price21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("price31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("price41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("price51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))
                            CType(objRpt.Section3.ReportObjects.Item("price61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Border.BackgroundColor = Color.FromName(dt.Rows(i).Item("backcolor"))

                        End If


                        CType(objRpt.Section3.ReportObjects.Item("price11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter + TxtWidth.Value * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 2 + TxtWidth.Value * 2 * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 3 + TxtWidth.Value * 3 * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 4 + TxtWidth.Value * 4 * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Left = CInt(dt.Rows(i).Item("Lleft") * facter + TxtVgap.Value * facter * 5 + TxtWidth.Value * 5 * facter)

                        CType(objRpt.Section3.ReportObjects.Item("price11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = CInt(dt.Rows(i).Item("Lwidth") * facter)

                        CType(objRpt.Section3.ReportObjects.Item("price11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)
                        CType(objRpt.Section3.ReportObjects.Item("price61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = CInt(dt.Rows(i).Item("LHeight") * facter)

                        If TxtNoCols.Value < 5 Then
                            CType(objRpt.Section3.ReportObjects.Item("price51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                            CType(objRpt.Section3.ReportObjects.Item("price61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        ElseIf TxtNoCols.Value = 5 Then
                            CType(objRpt.Section3.ReportObjects.Item("price61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        End If
                    Else
                        CType(objRpt.Section3.ReportObjects.Item("price11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("price21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("price31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("price41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("price51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
                        CType(objRpt.Section3.ReportObjects.Item("price61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True

                        CType(objRpt.Section3.ReportObjects.Item("price11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("price21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("price31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("price41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("price51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0
                        CType(objRpt.Section3.ReportObjects.Item("price61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Top = 0

                        CType(objRpt.Section3.ReportObjects.Item("price11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("price21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("price31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("price41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("price51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0
                        CType(objRpt.Section3.ReportObjects.Item("price61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Width = 0

                        CType(objRpt.Section3.ReportObjects.Item("price11"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("price21"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("price31"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("price41"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("price51"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                        CType(objRpt.Section3.ReportObjects.Item("price61"), CrystalDecisions.CrystalReports.Engine.FieldObject).Height = 0
                    End If
                End If

            Next

        End If

        If IsPrintComp.Checked = False Then
            CType(objRpt.Section3.ReportObjects.Item("Cmpname11"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True

            CType(objRpt.Section3.ReportObjects.Item("Cmpname21"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section3.ReportObjects.Item("Cmpname31"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section3.ReportObjects.Item("Cmpname41"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section3.ReportObjects.Item("Cmpname51"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section3.ReportObjects.Item("Cmpname61"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True

        End If
        'image settings 
        If IsLogoPrint.Checked = True Then
            If TxtPic.Image.Equals(Nothing) = False Then
                CType(objRpt.Section3.ReportObjects.Item("image11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Width = CInt(TxtLogoWidth.Value * facter)
                CType(objRpt.Section3.ReportObjects.Item("image22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Width = CInt(TxtLogoWidth.Value * facter)
                CType(objRpt.Section3.ReportObjects.Item("image33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Width = CInt(TxtLogoWidth.Value * facter)
                CType(objRpt.Section3.ReportObjects.Item("image44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Width = CInt(TxtLogoWidth.Value * facter)
                CType(objRpt.Section3.ReportObjects.Item("image55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Width = CInt(TxtLogoWidth.Value * facter)
                CType(objRpt.Section3.ReportObjects.Item("image66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Width = CInt(TxtLogoWidth.Value * facter)

                CType(objRpt.Section3.ReportObjects.Item("image11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Height = CInt(TxtLogoHeight.Value * facter)
                CType(objRpt.Section3.ReportObjects.Item("image22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Height = CInt(TxtLogoHeight.Value * facter)
                CType(objRpt.Section3.ReportObjects.Item("image33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Height = CInt(TxtLogoHeight.Value * facter)
                CType(objRpt.Section3.ReportObjects.Item("image44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Height = CInt(TxtLogoHeight.Value * facter)
                CType(objRpt.Section3.ReportObjects.Item("image55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Height = CInt(TxtLogoHeight.Value * facter)
                CType(objRpt.Section3.ReportObjects.Item("image66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Height = CInt(TxtLogoHeight.Value * facter)

                CType(objRpt.Section3.ReportObjects.Item("image11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Top = CInt(TxtLogoTop.Value * facter)
                CType(objRpt.Section3.ReportObjects.Item("image22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Top = CInt(TxtLogoTop.Value * facter)
                CType(objRpt.Section3.ReportObjects.Item("image33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Top = CInt(TxtLogoTop.Value * facter)
                CType(objRpt.Section3.ReportObjects.Item("image44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Top = CInt(TxtLogoTop.Value * facter)
                CType(objRpt.Section3.ReportObjects.Item("image55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Top = CInt(TxtLogoTop.Value * facter)
                CType(objRpt.Section3.ReportObjects.Item("image66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Top = CInt(TxtLogoTop.Value * facter)

                CType(objRpt.Section3.ReportObjects.Item("image11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = CInt(TxtLogoLeft.Value * facter)
                CType(objRpt.Section3.ReportObjects.Item("image22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = CInt(TxtLogoLeft.Value * facter + TxtVgap.Value * facter + TxtWidth.Value * facter)
                CType(objRpt.Section3.ReportObjects.Item("image33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = CInt(TxtLogoLeft.Value * facter + TxtVgap.Value * facter * 2 + TxtWidth.Value * facter * 2)
                CType(objRpt.Section3.ReportObjects.Item("image44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = CInt(TxtLogoLeft.Value * facter + TxtVgap.Value * facter * 3 + TxtWidth.Value * facter * 3)
                CType(objRpt.Section3.ReportObjects.Item("image55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = CInt(TxtLogoLeft.Value * facter + TxtVgap.Value * facter * 4 + TxtWidth.Value * facter * 4)
                CType(objRpt.Section3.ReportObjects.Item("image66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).Left = CInt(TxtLogoLeft.Value * facter + TxtVgap.Value * facter * 5 + TxtWidth.Value * facter * 5)


            Else
                CType(objRpt.Section3.ReportObjects.Item("image11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
                CType(objRpt.Section3.ReportObjects.Item("image22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
                CType(objRpt.Section3.ReportObjects.Item("image33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
                CType(objRpt.Section3.ReportObjects.Item("image44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
                CType(objRpt.Section3.ReportObjects.Item("image55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
                CType(objRpt.Section3.ReportObjects.Item("image66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True

            End If
        Else
            CType(objRpt.Section3.ReportObjects.Item("image11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section3.ReportObjects.Item("image22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section3.ReportObjects.Item("image33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section3.ReportObjects.Item("image44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section3.ReportObjects.Item("image55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section3.ReportObjects.Item("image66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True

        End If

        If TxtNoCols.Value = 1 Then
            CType(objRpt.Section3.ReportObjects.Item("image11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section3.ReportObjects.Item("image33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section3.ReportObjects.Item("image44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section3.ReportObjects.Item("image55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section3.ReportObjects.Item("image66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True

          
        ElseIf TxtNoCols.Value = 2 Then
            CType(objRpt.Section3.ReportObjects.Item("image11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section3.ReportObjects.Item("image44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section3.ReportObjects.Item("image55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section3.ReportObjects.Item("image66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
        ElseIf TxtNoCols.Value = 3 Then
            CType(objRpt.Section3.ReportObjects.Item("image11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section3.ReportObjects.Item("image55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section3.ReportObjects.Item("image66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
        ElseIf TxtNoCols.Value = 4 Then
            CType(objRpt.Section3.ReportObjects.Item("image11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section3.ReportObjects.Item("image66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
        ElseIf TxtNoCols.Value = 5 Then
            CType(objRpt.Section3.ReportObjects.Item("image11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = True
        ElseIf TxtNoCols.Value = 6 Then

            CType(objRpt.Section3.ReportObjects.Item("image11"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image22"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image33"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image44"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image55"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
            CType(objRpt.Section3.ReportObjects.Item("image66"), CrystalDecisions.CrystalReports.Engine.BlobFieldObject).ObjectFormat.EnableSuppress = False
        End If


        Try
            objRpt.Section3.Height = TxtHeight.Value * facter + TxtHgap.Value * facter
        Catch ex As Exception

        End Try

        objRpt.SetDataSource(ds)
        If IsDirectToPrinter = True Then
            objRpt.PrintToPrinter(1, False, 1, 100)
        Else
            Dim FRM As New ReportCommonForm(objRpt)
            FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

            Me.Cursor = Cursors.Default
            Me.Cursor = Cursors.Default
            FRM.ShowDialog()
            FRM.Dispose()
        End If
      
        objRpt.Dispose()
        ds.Dispose()
        LoadStock()
    End Sub
    Sub lOADbCODEDATA()
        ExecuteSQLQuery("DELETE FROM printbarcodeList")
        Dim mrpstr As String = ""
        Dim pricestr As String = ""
        Dim BarcodeTextstr As String = ""
        Dim lcase As String = ""
        Dim tempstr As String = ""
        Dim BROTATE As String = ""
        Dim BCODEWIDHT As Integer = 0
        Dim BCODEHEIGHT As Integer = 0
        Dim BCODEalign As String = "CENTER"
        Dim isComma As Boolean = False
        'BCODEWIDHT=
        '3.779527559055
        'Sqlstr = "UPDATE [BarcodeFieldSettings]  LText  WHERE schemename=N'" & SchemeName & "' and FiledName=N'" & TxtFieldNames.Text & "'"

        mrpstr = SQLGetStringFieldValue("SELECT LTEXT AS TOT FROM BarcodeFieldSettings WHERE schemename=N'" & TxtSchemeName.Text & "' AND FiledName='MRP'", "TOT", , , True)
        pricestr = SQLGetStringFieldValue("SELECT LTEXT AS TOT FROM BarcodeFieldSettings WHERE schemename=N'" & TxtSchemeName.Text & "' AND FiledName='PRICE'", "TOT", , , True)
        isComma = SQLGetBooleanFieldValue("SELECT IsComaSep  FROM BarcodeFieldSettings WHERE schemename=N'" & TxtSchemeName.Text & "' AND FiledName='PRICE'", "IsComaSep")
        lcase = SQLGetStringFieldValue("SELECT lcase AS TOT FROM BarcodeFieldSettings WHERE schemename=N'" & TxtSchemeName.Text & "' AND FiledName='ItemName'", "TOT", , , True)
        BROTATE = SQLGetStringFieldValue("SELECT Rotate AS TOT FROM BarcodeFieldSettings WHERE schemename=N'" & TxtSchemeName.Text & "' AND FiledName='barcode'", "TOT", , , True)
        BCODEalign = SQLGetStringFieldValue("SELECT Align AS TOT FROM BarcodeFieldSettings WHERE schemename=N'" & TxtSchemeName.Text & "' AND FiledName='barcode'", "TOT", , , True)
        BCODEWIDHT = CInt(3.779527559055 * SQLGetNumericFieldValue("SELECT Lwidth AS TOT FROM BarcodeFieldSettings WHERE schemename=N'" & TxtSchemeName.Text & "' AND FiledName='barcode'", "TOT"))
        BCODEHEIGHT = CInt(3.779527559055 * SQLGetNumericFieldValue("SELECT LHeight AS TOT FROM BarcodeFieldSettings WHERE schemename=N'" & TxtSchemeName.Text & "' AND FiledName='barcode'", "TOT"))


        Dim btype As BarcodeLib.TYPE
        Dim Barcodeimg As New BarcodeLib.Barcode
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

        Select Case cbEncodeType.SelectedItem.ToString().Trim()
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



        Dim ID As Long = 1
        Dim ColNo As Integer = 1
        For I As Integer = 0 To TxtList.Rows.Count - 1
            If IsNumeric(TxtList.Item("No Of Copies", I).Value.ToString) = True Then
                If TxtList.Item("No Of Copies", I).Value > 0 Then
                    For k As Integer = 0 To CInt(TxtList.Item("No Of Copies", I).Value) - 1
                        If ColNo = 1 Then
                            Dim sqlstr As String = "INSERT INTO printbarcodeList(ID,Cmpname1,itemname1,MRP1,Price1,barcode1,BarcodeImage1) values (@ID,@Cmpname1,@itemname1,@MRP1,@Price1,@barcode1,@BarcodeImage1)"
                            MAINCON.ConnectionString = ConnectionStrinG
                            MAINCON.Open()
                            Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
                            With DBF.Parameters
                                .AddWithValue("ID", ID)
                                .AddWithValue("Cmpname1", TxtCmpName.Text)
                                If TxtIsprintItemCode.Checked = True Then
                                    tempstr = TxtList.Item("stockcode", I).Value.ToString
                                    If lcase.ToUpper = "UPPERCASE" Then
                                        tempstr = StrConv(tempstr, VbStrConv.Uppercase)
                                    ElseIf lcase.ToUpper = "lowercase".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.Lowercase)
                                    ElseIf lcase.ToUpper = "Title Case".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.ProperCase)
                                    End If

                                    .AddWithValue("itemname1", tempstr)
                                Else
                                    tempstr = TxtList.Item("stockname", I).Value.ToString
                                    If lcase.ToUpper = "UPPERCASE" Then
                                        tempstr = StrConv(tempstr, VbStrConv.Uppercase)
                                    ElseIf lcase.ToUpper = "lowercase".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.Lowercase)
                                    ElseIf lcase.ToUpper = "Title Case".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.ProperCase)
                                    End If

                                    .AddWithValue("itemname1", tempstr)
                                   
                                End If
                                If btype = BarcodeLib.TYPE.UNSPECIFIED Then
                                    .Add("BarcodeImage1", SqlDbType.Image).Value = DBNull.Value
                                Else

                                    Try
                                        Dim ms As New MemoryStream()
                                        Barcodeimg.Encode(btype, TxtList.Item("barcode", I).Value.ToString, BCODEWIDHT, BCODEHEIGHT)
                                        Barcodeimg.SaveImage(ms, BarcodeLib.SaveTypes.BMP)
                                        Dim data As Byte() = ms.GetBuffer()
                                        .AddWithValue("BarcodeImage1", data)
                                    Catch ex As Exception
                                        .Add("BarcodeImage1", SqlDbType.Image).Value = DBNull.Value
                                    End Try
                                End If
                                If IsPrintWRP.Checked = True Then
                                    If TxtCurrency.Text.Length > 0 Then

                                        .AddWithValue("Price1", pricestr & TxtCurrency.Text & IIf(isComma = True, FormatNumber(TxtList.Item("WRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("WRP", I).Value.ToString.Replace(",", "")))
                                    Else
                                        .AddWithValue("Price1", pricestr & IIf(isComma = True, FormatNumber(TxtList.Item("WRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("WRP", I).Value.ToString.Replace(",", "")))
                                    End If

                                Else
                                    If TxtCurrency.Text.Length > 0 Then
                                        .AddWithValue("Price1", pricestr & TxtCurrency.Text & IIf(isComma = True, FormatNumber(TxtList.Item("DRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("DRP", I).Value.ToString.Replace(",", "")))
                                    Else
                                        .AddWithValue("Price1", pricestr & IIf(isComma = True, FormatNumber(TxtList.Item("DRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("DRP", I).Value.ToString.Replace(",", "")))
                                    End If

                                End If
                                .AddWithValue("barcode1", "*" & TxtList.Item("barcode", I).Value.ToString & "*")
                                If TxtCurrency.Text.Length > 0 Then
                                    .AddWithValue("MRP1", mrpstr & TxtCurrency.Text & IIf(isComma = True, FormatNumber(TxtList.Item("MRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("MRP", I).Value.ToString.Replace(",", "")))
                                Else
                                    .AddWithValue("MRP1", mrpstr & IIf(isComma = True, FormatNumber(TxtList.Item("MRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("MRP", I).Value.ToString.Replace(",", "")))
                                End If

                            End With
                            DBF.ExecuteNonQuery()
                            DBF = Nothing
                            MAINCON.Close()
                            ID = ID + 1
                        End If
                        If ColNo = 2 Then

                            Dim sqlstr As String = "UPDATE printbarcodeList SET Cmpname2=@Cmpname2,itemname2=@itemname2,Price2=@Price2,barcode2=@barcode2,MRP2=@MRP2,BarcodeImage2=@BarcodeImage2 WHERE ID=" & ID - 1

                            MAINCON.ConnectionString = ConnectionStrinG
                            MAINCON.Open()
                            Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
                            With DBF.Parameters
                                .AddWithValue("Cmpname2", TxtCmpName.Text)
                                If TxtIsprintItemCode.Checked = True Then
                                    tempstr = TxtList.Item("stockcode", I).Value.ToString
                                    If lcase.ToUpper = "UPPERCASE" Then
                                        tempstr = StrConv(tempstr, VbStrConv.Uppercase)
                                    ElseIf lcase.ToUpper = "lowercase".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.Lowercase)
                                    ElseIf lcase.ToUpper = "Title Case".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.ProperCase)
                                    End If
                                    .AddWithValue("itemname2", tempstr)
                                Else
                                    tempstr = TxtList.Item("stockname", I).Value.ToString
                                    If lcase.ToUpper = "UPPERCASE" Then
                                        tempstr = StrConv(tempstr, VbStrConv.Uppercase)
                                    ElseIf lcase.ToUpper = "lowercase".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.Lowercase)
                                    ElseIf lcase.ToUpper = "Title Case".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.ProperCase)
                                    End If
                                    .AddWithValue("itemname2", tempstr)
                                End If
                                If IsPrintWRP.Checked = True Then
                                    If TxtCurrency.Text.Length > 0 Then

                                        .AddWithValue("Price2", pricestr & TxtCurrency.Text & IIf(isComma = True, FormatNumber(TxtList.Item("WRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("WRP", I).Value.ToString.Replace(",", "")))
                                    Else
                                        .AddWithValue("Price2", pricestr & IIf(isComma = True, FormatNumber(TxtList.Item("WRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("WRP", I).Value.ToString.Replace(",", "")))
                                    End If

                                Else
                                    If TxtCurrency.Text.Length > 0 Then
                                        .AddWithValue("Price2", pricestr & TxtCurrency.Text & IIf(isComma = True, FormatNumber(TxtList.Item("DRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("DRP", I).Value.ToString.Replace(",", "")))
                                    Else
                                        .AddWithValue("Price2", pricestr & IIf(isComma = True, FormatNumber(TxtList.Item("DRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("DRP", I).Value.ToString.Replace(",", "")))
                                    End If

                                End If
                                If btype = BarcodeLib.TYPE.UNSPECIFIED Then
                                    .Add("BarcodeImage2", SqlDbType.Image).Value = DBNull.Value
                                Else


                                    Try
                                        Dim ms As New MemoryStream()
                                        Barcodeimg.Encode(btype, TxtList.Item("barcode", I).Value.ToString, BCODEWIDHT, BCODEHEIGHT)
                                        Barcodeimg.SaveImage(ms, BarcodeLib.SaveTypes.BMP)
                                        Dim data As Byte() = ms.GetBuffer()
                                        .AddWithValue("BarcodeImage2", data)
                                    Catch ex As Exception
                                        .Add("BarcodeImage2", SqlDbType.Image).Value = DBNull.Value
                                    End Try
                                End If
                                .AddWithValue("barcode2", "*" & TxtList.Item("barcode", I).Value.ToString & "*")
                                If TxtCurrency.Text.Length > 0 Then
                                    .AddWithValue("MRP2", mrpstr & TxtCurrency.Text & IIf(isComma = True, FormatNumber(TxtList.Item("MRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("MRP", I).Value.ToString.Replace(",", "")))
                                Else
                                    .AddWithValue("MRP2", mrpstr & IIf(isComma = True, FormatNumber(TxtList.Item("MRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("MRP", I).Value.ToString.Replace(",", "")))
                                End If
                            End With
                            DBF.ExecuteNonQuery()
                            DBF = Nothing
                            MAINCON.Close()

                        End If
                        If ColNo = 3 Then
                            Dim sqlstr As String = "UPDATE printbarcodeList SET Cmpname3=@Cmpname3,itemname3=@itemname3,Price3=@Price3,barcode3=@barcode3,MRP3=@MRP3,BarcodeImage3=@BarcodeImage3 WHERE ID=" & ID - 1

                            MAINCON.ConnectionString = ConnectionStrinG
                            MAINCON.Open()
                            Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
                            With DBF.Parameters
                                .AddWithValue("Cmpname3", TxtCmpName.Text)
                                If TxtIsprintItemCode.Checked = True Then
                                    tempstr = TxtList.Item("stockcode", I).Value.ToString
                                    If lcase.ToUpper = "UPPERCASE" Then
                                        tempstr = StrConv(tempstr, VbStrConv.Uppercase)
                                    ElseIf lcase.ToUpper = "lowercase".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.Lowercase)
                                    ElseIf lcase.ToUpper = "Title Case".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.ProperCase)
                                    End If
                                    .AddWithValue("itemname3", tempstr)
                                Else
                                    tempstr = TxtList.Item("stockname", I).Value.ToString
                                    If lcase.ToUpper = "UPPERCASE" Then
                                        tempstr = StrConv(tempstr, VbStrConv.Uppercase)
                                    ElseIf lcase.ToUpper = "lowercase".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.Lowercase)
                                    ElseIf lcase.ToUpper = "Title Case".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.ProperCase)
                                    End If
                                    .AddWithValue("itemname3", tempstr)
                                End If
                                If IsPrintWRP.Checked = True Then
                                    If TxtCurrency.Text.Length > 0 Then

                                        .AddWithValue("Price3", pricestr & TxtCurrency.Text & IIf(isComma = True, FormatNumber(TxtList.Item("WRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("WRP", I).Value.ToString.Replace(",", "")))
                                    Else
                                        .AddWithValue("Price3", pricestr & IIf(isComma = True, FormatNumber(TxtList.Item("WRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("WRP", I).Value.ToString.Replace(",", "")))
                                    End If

                                Else
                                    If TxtCurrency.Text.Length > 0 Then
                                        .AddWithValue("Price3", pricestr & TxtCurrency.Text & IIf(isComma = True, FormatNumber(TxtList.Item("DRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("DRP", I).Value.ToString.Replace(",", "")))
                                    Else
                                        .AddWithValue("Price3", pricestr & IIf(isComma = True, FormatNumber(TxtList.Item("DRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("DRP", I).Value.ToString.Replace(",", "")))
                                    End If

                                End If
                                If btype = BarcodeLib.TYPE.UNSPECIFIED Then
                                    .Add("BarcodeImage3", SqlDbType.Image).Value = DBNull.Value
                                Else


                                    Try
                                        Dim ms As New MemoryStream()
                                        Barcodeimg.Encode(btype, TxtList.Item("barcode", I).Value.ToString, BCODEWIDHT, BCODEHEIGHT)
                                        Barcodeimg.SaveImage(ms, BarcodeLib.SaveTypes.BMP)
                                        Dim data As Byte() = ms.GetBuffer()
                                        .AddWithValue("BarcodeImage3", data)
                                    Catch ex As Exception
                                        .Add("BarcodeImage3", SqlDbType.Image).Value = DBNull.Value
                                    End Try
                                End If
                                .AddWithValue("barcode3", "*" & TxtList.Item("barcode", I).Value.ToString & "*")
                                If TxtCurrency.Text.Length > 0 Then
                                    .AddWithValue("MRP3", mrpstr & TxtCurrency.Text & IIf(isComma = True, FormatNumber(TxtList.Item("MRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("MRP", I).Value.ToString.Replace(",", "")))
                                Else
                                    .AddWithValue("MRP3", mrpstr & IIf(isComma = True, FormatNumber(TxtList.Item("MRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("MRP", I).Value.ToString.Replace(",", "")))
                                End If
                            End With
                            DBF.ExecuteNonQuery()
                            DBF = Nothing
                            MAINCON.Close()


                        End If
                        If ColNo = 4 Then
                            Dim sqlstr As String = "UPDATE printbarcodeList SET Cmpname4=@Cmpname4,itemname4=@itemname4,Price4=@Price4,barcode4=@barcode4,MRP4=@MRP4,BarcodeImage4=@BarcodeImage4 WHERE ID=" & ID - 1

                            MAINCON.ConnectionString = ConnectionStrinG
                            MAINCON.Open()
                            Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
                            With DBF.Parameters
                                .AddWithValue("Cmpname4", TxtCmpName.Text)
                                If TxtIsprintItemCode.Checked = True Then
                                    tempstr = TxtList.Item("stockcode", I).Value.ToString
                                    If lcase.ToUpper = "UPPERCASE" Then
                                        tempstr = StrConv(tempstr, VbStrConv.Uppercase)
                                    ElseIf lcase.ToUpper = "lowercase".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.Lowercase)
                                    ElseIf lcase.ToUpper = "Title Case".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.ProperCase)
                                    End If
                                    .AddWithValue("itemname4", tempstr)
                                Else
                                    tempstr = TxtList.Item("stockname", I).Value.ToString
                                    If lcase.ToUpper = "UPPERCASE" Then
                                        tempstr = StrConv(tempstr, VbStrConv.Uppercase)
                                    ElseIf lcase.ToUpper = "lowercase".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.Lowercase)
                                    ElseIf lcase.ToUpper = "Title Case".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.ProperCase)
                                    End If
                                    .AddWithValue("itemname4", tempstr)
                                End If
                                If IsPrintWRP.Checked = True Then
                                    If TxtCurrency.Text.Length > 0 Then

                                        .AddWithValue("Price4", pricestr & TxtCurrency.Text & IIf(isComma = True, FormatNumber(TxtList.Item("WRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("WRP", I).Value.ToString.Replace(",", "")))
                                    Else
                                        .AddWithValue("Price4", pricestr & IIf(isComma = True, FormatNumber(TxtList.Item("WRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("WRP", I).Value.ToString.Replace(",", "")))
                                    End If

                                Else
                                    If TxtCurrency.Text.Length > 0 Then
                                        .AddWithValue("Price4", pricestr & TxtCurrency.Text & IIf(isComma = True, FormatNumber(TxtList.Item("DRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("DRP", I).Value.ToString.Replace(",", "")))
                                    Else
                                        .AddWithValue("Price4", pricestr & IIf(isComma = True, FormatNumber(TxtList.Item("DRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("DRP", I).Value.ToString.Replace(",", "")))
                                    End If

                                End If
                                If btype = BarcodeLib.TYPE.UNSPECIFIED Then
                                    .Add("BarcodeImage4", SqlDbType.Image).Value = DBNull.Value
                                Else


                                    Try
                                        Dim ms As New MemoryStream()
                                        Barcodeimg.Encode(btype, TxtList.Item("barcode", I).Value.ToString, BCODEWIDHT, BCODEHEIGHT)
                                        Barcodeimg.SaveImage(ms, BarcodeLib.SaveTypes.BMP)
                                        Dim data As Byte() = ms.GetBuffer()
                                        .AddWithValue("BarcodeImage4", data)
                                    Catch ex As Exception
                                        .Add("BarcodeImage4", SqlDbType.Image).Value = DBNull.Value
                                    End Try
                                End If
                                .AddWithValue("barcode4", "*" & TxtList.Item("barcode", I).Value.ToString & "*")
                                If TxtCurrency.Text.Length > 0 Then
                                    .AddWithValue("MRP4", mrpstr & TxtCurrency.Text & IIf(isComma = True, FormatNumber(TxtList.Item("MRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("MRP", I).Value.ToString.Replace(",", "")))
                                Else
                                    .AddWithValue("MRP4", mrpstr & IIf(isComma = True, FormatNumber(TxtList.Item("MRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("MRP", I).Value.ToString.Replace(",", "")))
                                End If
                            End With
                            DBF.ExecuteNonQuery()
                            DBF = Nothing
                            MAINCON.Close()



                        End If
                        If ColNo = 5 Then
                            Dim sqlstr As String = "UPDATE printbarcodeList SET Cmpname5=@Cmpname5,itemname5=@itemname5,Price5=@Price5,barcode5=@barcode5,MRP5=@MRP5,BarcodeImage5=@BarcodeImage5 WHERE ID=" & ID - 1

                            MAINCON.ConnectionString = ConnectionStrinG
                            MAINCON.Open()
                            Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
                            With DBF.Parameters
                                .AddWithValue("Cmpname5", TxtCmpName.Text)
                                If TxtIsprintItemCode.Checked = True Then
                                    tempstr = TxtList.Item("stockcode", I).Value.ToString
                                    If lcase.ToUpper = "UPPERCASE" Then
                                        tempstr = StrConv(tempstr, VbStrConv.Uppercase)
                                    ElseIf lcase.ToUpper = "lowercase".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.Lowercase)
                                    ElseIf lcase.ToUpper = "Title Case".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.ProperCase)
                                    End If
                                    .AddWithValue("itemname5", tempstr)
                                Else
                                    tempstr = TxtList.Item("stockname", I).Value.ToString
                                    If lcase.ToUpper = "UPPERCASE" Then
                                        tempstr = StrConv(tempstr, VbStrConv.Uppercase)
                                    ElseIf lcase.ToUpper = "lowercase".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.Lowercase)
                                    ElseIf lcase.ToUpper = "Title Case".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.ProperCase)
                                    End If
                                    .AddWithValue("itemname5", tempstr)
                                End If
                                If IsPrintWRP.Checked = True Then
                                    If TxtCurrency.Text.Length > 0 Then

                                        .AddWithValue("Price5", pricestr & TxtCurrency.Text & IIf(isComma = True, FormatNumber(TxtList.Item("WRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("WRP", I).Value.ToString.Replace(",", "")))
                                    Else
                                        .AddWithValue("Price5", pricestr & IIf(isComma = True, FormatNumber(TxtList.Item("WRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("WRP", I).Value.ToString.Replace(",", "")))
                                    End If

                                Else
                                    If TxtCurrency.Text.Length > 0 Then
                                        .AddWithValue("Price5", pricestr & TxtCurrency.Text & IIf(isComma = True, FormatNumber(TxtList.Item("DRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("DRP", I).Value.ToString.Replace(",", "")))
                                    Else
                                        .AddWithValue("Price5", pricestr & IIf(isComma = True, FormatNumber(TxtList.Item("DRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("DRP", I).Value.ToString.Replace(",", "")))
                                    End If

                                End If
                                If btype = BarcodeLib.TYPE.UNSPECIFIED Then
                                    .Add("BarcodeImage5", SqlDbType.Image).Value = DBNull.Value
                                Else


                                    Try
                                        Dim ms As New MemoryStream()
                                        Barcodeimg.Encode(btype, TxtList.Item("barcode", I).Value.ToString, BCODEWIDHT, BCODEHEIGHT)
                                        Barcodeimg.SaveImage(ms, BarcodeLib.SaveTypes.BMP)
                                        Dim data As Byte() = ms.GetBuffer()
                                        .AddWithValue("BarcodeImage5", data)
                                    Catch ex As Exception
                                        .Add("BarcodeImage5", SqlDbType.Image).Value = DBNull.Value
                                    End Try
                                End If
                                .AddWithValue("barcode5", "*" & TxtList.Item("barcode", I).Value.ToString & "*")
                                If TxtCurrency.Text.Length > 0 Then
                                    .AddWithValue("MRP5", mrpstr & TxtCurrency.Text & IIf(isComma = True, FormatNumber(TxtList.Item("MRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("MRP", I).Value.ToString.Replace(",", "")))
                                Else
                                    .AddWithValue("MRP5", mrpstr & IIf(isComma = True, FormatNumber(TxtList.Item("MRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("MRP", I).Value.ToString.Replace(",", "")))
                                End If
                            End With
                            DBF.ExecuteNonQuery()
                            DBF = Nothing
                            MAINCON.Close()


                        End If
                        If ColNo = 6 Then

                            Dim sqlstr As String = "UPDATE printbarcodeList SET Cmpname6=@Cmpname6,itemname6=@itemname6,Price6=@Price6,barcode6=@barcode6,MRP6=@MRP6,BarcodeImage6=@BarcodeImage6 WHERE ID=" & ID - 1

                            MAINCON.ConnectionString = ConnectionStrinG
                            MAINCON.Open()
                            Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
                            With DBF.Parameters
                                .AddWithValue("Cmpname6", TxtCmpName.Text)
                                If TxtIsprintItemCode.Checked = True Then
                                    tempstr = TxtList.Item("stockcode", I).Value.ToString
                                    If lcase.ToUpper = "UPPERCASE" Then
                                        tempstr = StrConv(tempstr, VbStrConv.Uppercase)
                                    ElseIf lcase.ToUpper = "lowercase".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.Lowercase)
                                    ElseIf lcase.ToUpper = "Title Case".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.ProperCase)
                                    End If
                                    .AddWithValue("itemname6", tempstr)
                                Else
                                    tempstr = TxtList.Item("stockname", I).Value.ToString
                                    If lcase.ToUpper = "UPPERCASE" Then
                                        tempstr = StrConv(tempstr, VbStrConv.Uppercase)
                                    ElseIf lcase.ToUpper = "lowercase".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.Lowercase)
                                    ElseIf lcase.ToUpper = "Title Case".ToUpper Then
                                        tempstr = StrConv(tempstr, VbStrConv.ProperCase)
                                    End If
                                    .AddWithValue("itemname6", tempstr)
                                End If
                                If IsPrintWRP.Checked = True Then
                                    If TxtCurrency.Text.Length > 0 Then

                                        .AddWithValue("Price6", pricestr & TxtCurrency.Text & IIf(isComma = True, FormatNumber(TxtList.Item("WRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("WRP", I).Value.ToString.Replace(",", "")))
                                    Else
                                        .AddWithValue("Price6", pricestr & IIf(isComma = True, FormatNumber(TxtList.Item("WRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("WRP", I).Value.ToString.Replace(",", "")))
                                    End If

                                Else
                                    If TxtCurrency.Text.Length > 0 Then
                                        .AddWithValue("Price6", pricestr & TxtCurrency.Text & IIf(isComma = True, FormatNumber(TxtList.Item("DRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("DRP", I).Value.ToString.Replace(",", "")))
                                    Else
                                        .AddWithValue("Price6", pricestr & IIf(isComma = True, FormatNumber(TxtList.Item("DRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("DRP", I).Value.ToString.Replace(",", "")))
                                    End If

                                End If
                                .AddWithValue("barcode6", "*" & TxtList.Item("barcode", I).Value.ToString & "*")
                                If TxtCurrency.Text.Length > 0 Then
                                    .AddWithValue("MRP6", mrpstr & TxtCurrency.Text & IIf(isComma = True, FormatNumber(TxtList.Item("MRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("MRP", I).Value.ToString.Replace(",", "")))
                                Else
                                    .AddWithValue("MRP6", mrpstr & IIf(isComma = True, FormatNumber(TxtList.Item("MRP", I).Value, TxtDecimals.Value, , , TriState.True).ToString, TxtList.Item("MRP", I).Value.ToString.Replace(",", "")))
                                End If
                                If btype = BarcodeLib.TYPE.UNSPECIFIED Then
                                    .Add("BarcodeImage6", SqlDbType.Image).Value = DBNull.Value
                                Else


                                    Try
                                        Dim ms As New MemoryStream()
                                        Barcodeimg.Encode(btype, TxtList.Item("barcode", I).Value.ToString, BCODEWIDHT, BCODEHEIGHT)
                                        Barcodeimg.SaveImage(ms, BarcodeLib.SaveTypes.BMP)
                                        Dim data As Byte() = ms.GetBuffer()
                                        .AddWithValue("BarcodeImage6", data)
                                    Catch ex As Exception
                                        .Add("BarcodeImage6", SqlDbType.Image).Value = DBNull.Value
                                    End Try
                                End If
                            End With
                            DBF.ExecuteNonQuery()
                            DBF = Nothing
                            MAINCON.Close()

                        End If
                        If ColNo = TxtNoCols.Value Then
                            ColNo = 1
                        Else
                            ColNo = ColNo + 1
                        End If
                    Next


                End If
            End If

        Next
        If IsLogoPrint.Checked = True Then
            If TxtPic.Image.Equals(Nothing) = False Then
                Dim dt As New DataTable
                dt = SQLLoadGridData("select * from barcodeprintsettings where Schemename=N'" & TxtSchemeName.Text & "'")
                Dim imageData As Byte()
                Try
                    imageData = DirectCast(dt.Rows(0).Item("logo"), Byte())
                    Try
                        If Not imageData Is Nothing Then
                            Using ms As New MemoryStream(imageData, 0, imageData.Length)
                                ms.Write(imageData, 0, imageData.Length)
                                SqlSTR = "UPDATE [printbarcodeList] SET  [image1]=@image1,Image2=@Image2,Image3=@Image3,Image4=@Image4,Image5=@Image5,Image6=@Image6 "
                                MAINCON.ConnectionString = ConnectionStrinG
                                MAINCON.Open()
                                Dim DBF2 As New SqlClient.SqlCommand(SqlSTR, MAINCON)
                                With DBF2.Parameters
                                    .AddWithValue("image1", imageData)
                                    .AddWithValue("image2", imageData)
                                    .AddWithValue("image3", imageData)
                                    .AddWithValue("image4", imageData)
                                    .AddWithValue("image5", imageData)
                                    .AddWithValue("image6", imageData)
                                End With
                                DBF2.ExecuteNonQuery()
                                DBF2 = Nothing
                                MAINCON.Close()

                            End Using
                        End If
                    Catch ex As Exception

                    End Try
                Catch ex As Exception

                End Try

            End If
        End If


    End Sub
    Private Sub TxtList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub

    Private Sub ImsButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton5.Click
        Me.Close()
    End Sub

    

    Private Sub TxtSchemeName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtSchemeName.SelectedIndexChanged
        Dim dt As New DataTable
        isImagechanged = False
        dt = SQLLoadGridData("select * from barcodeprintsettings where Schemename=N'" & TxtSchemeName.Text & "'")
        If dt.Rows.Count > 0 Then

            TxtPaperSize.Text = dt.Rows(0).Item("PaperSize").ToString
            TxtWidth.Value = dt.Rows(0).Item("lwidht")
            TxtHeight.Value = dt.Rows(0).Item("lheight")
            TxtTop.Value = dt.Rows(0).Item("TopMargin")
            TxtLeft.Value = dt.Rows(0).Item("LeftMargin")
            TxtHgap.Value = dt.Rows(0).Item("HGap")
            TxtVgap.Value = dt.Rows(0).Item("Vgap")
            TxtIsprintItemCode.Checked = dt.Rows(0).Item("IsPrintItemCode")
            IsPrintWRP.Checked = dt.Rows(0).Item("IsPrintWRP")
            TxtNoCols.Value = dt.Rows(0).Item("Noofcolumns")
            IsPrintComp.Checked = dt.Rows(0).Item("IsPrintComp")
            TxtCurrency.Text = dt.Rows(0).Item("Currency")
            TxtDecimals.Value = dt.Rows(0).Item("IsWithDecimal")
            TxtLogoHeight.Value = dt.Rows(0).Item("logoheight")
            TxtLogoWidth.Value = dt.Rows(0).Item("logowidth")
            TxtLogoLeft.Value = dt.Rows(0).Item("logoleft")
            TxtLogoTop.Value = dt.Rows(0).Item("logotop")
            IsLogoPrint.Checked = dt.Rows(0).Item("IslogoEnable")
            cbEncodeType.Text = dt.Rows(0).Item("BarcodeType").ToString
            Dim retimage As Image = My.Resources.NOPIC
            Try
                Dim imageData As Byte() = DirectCast(dt.Rows(0).Item("logo"), Byte())
                If Not imageData Is Nothing Then
                    Using ms As New MemoryStream(imageData, 0, imageData.Length)
                        ms.Write(imageData, 0, imageData.Length)
                        retimage = Image.FromStream(ms, True)
                    End Using
                End If
            Catch ex As Exception

            End Try
            TxtPic.Image = retimage
        Else
            TxtPic.Image = My.Resources.NOPIC
            IsLogoPrint.Checked = False
        End If
    End Sub

    Private Sub ImsButton6_Click_1(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        If TxtSchemeName.Text = "*New" Then
            Dim Schname As String = ""
MM:         Schname = InputBox("Enter the Scheme Name ", "Enter Schmen Name ")
            If Schname.Length = 0 Then Exit Sub
            If Schname.Length > 100 Then
                If MsgBox("Please Enter the Scheme Name is too long.., Try agin ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    GoTo MM
                Else
                    Exit Sub
                End If
            Else
                If SQLIsFieldExists("select Schemename from barcodeprintsettings where Schemename=N'" & Schname & "'") = True Then
                    If MsgBox("Please Enter the Scheme Name is already exists, Try agin ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        GoTo MM
                    Else
                        Exit Sub
                    End If
                End If
            End If
            If Schname.ToUpper = "*New".ToUpper Then
                MsgBox("Invalid Scheme Name , Please try again...")
                GoTo MM
            End If
            Dim sqlstr As String = ""
            sqlstr = "INSERT INTO [barcodeprintsettings] ([Schemename],[PaperSize],[lwidht],[lheight],[TopMargin],[LeftMargin],[HGap],[Vgap],[IsPrintItemCode],[IsPrintMRP],[IsPrintWRP],[Noofcolumns],[IsPrintComp],[Currency],[IsWithDecimal],logowidth,logoheight,logoleft,logotop,IslogoEnable,LOGO,BarcodeType)     VALUES " _
                & " (@Schemename,@PaperSize,@lwidht,@lheight,@TopMargin,@LeftMargin,@HGap,@Vgap,@IsPrintItemCode, " _
                & " @IsPrintMRP,@IsPrintWRP,@Noofcolumns,@IsPrintComp,@Currency,@IsWithDecimal,@logowidth,@logoheight,@logoleft,@logotop,@IslogoEnable,@LOGO,@BarcodeType) "
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
            With DBF.Parameters

                .AddWithValue("Schemename", Schname)
                .AddWithValue("PaperSize", TxtPaperSize.Text)
                .AddWithValue("lwidht", TxtWidth.Value)
                .AddWithValue("lheight", TxtHeight.Value)
                .AddWithValue("TopMargin", TxtTop.Value)
                .AddWithValue("LeftMargin", TxtLeft.Value)
                .AddWithValue("HGap", TxtHgap.Value)
                .AddWithValue("Vgap", TxtVgap.Value)
                .AddWithValue("IsPrintItemCode", TxtIsprintItemCode.Checked)
                .AddWithValue("IsPrintMRP", 0)
                .AddWithValue("IsPrintWRP", IsPrintWRP.Checked)
                .AddWithValue("Noofcolumns", TxtNoCols.Value)
                .AddWithValue("IsPrintComp", IsPrintComp.Checked)
                .AddWithValue("Currency", TxtCurrency.Text)
                .AddWithValue("logowidth", TxtLogoWidth.Value)
                .AddWithValue("logoheight", TxtLogoHeight.Value)
                .AddWithValue("logoleft", TxtLogoLeft.Value)
                .AddWithValue("logotop", TxtLogoTop.Value)
                .AddWithValue("IslogoEnable", IsLogoPrint.Checked)
                Dim ms As New MemoryStream()
                TxtPic.Image.Save(ms, TxtPic.Image.RawFormat)
                Dim objData As Byte() = ms.GetBuffer()
                .AddWithValue("LOGO", objData)
                .AddWithValue("IsWithDecimal", TxtDecimals.Value)
                .AddWithValue("BarcodeType", cbEncodeType.Text)
            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
           
            ExecuteSQLQuery("INSERT INTO [BarcodeFieldSettings] ([Schemename],[FiledName],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor])     VALUES (N'" & Schname & "','Barcode',40,20,0,0,'Barcode','','ARIAL',10,0,'Black','Left',1,'NULL')")
            ExecuteSQLQuery("INSERT INTO [BarcodeFieldSettings] ([Schemename],[FiledName],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor])     VALUES (N'" & Schname & "','BarcodeText',40,20,0,0,'BarcodeText','','ARIAL',10,0,'Black','Left',0,'NULL')")
            ExecuteSQLQuery("INSERT INTO [BarcodeFieldSettings] ([Schemename],[FiledName],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor])     VALUES (N'" & Schname & "','CompanyName',40,20,0,0,'CompanyName','','ARIAL',10,0,'Black','Left',0,'NULL')")
            ExecuteSQLQuery("INSERT INTO [BarcodeFieldSettings] ([Schemename],[FiledName],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor])     VALUES (N'" & Schname & "','ItemName',40,20,0,0,'ItemName','','ARIAL',10,0,'Black','Left',0,'NULL')")
            ExecuteSQLQuery("INSERT INTO [BarcodeFieldSettings] ([Schemename],[FiledName],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor])     VALUES (N'" & Schname & "','MRP',40,20,0,0,'MRP','','ARIAL',10,0,'Black','Left',0,'NULL')")
            ExecuteSQLQuery("INSERT INTO [BarcodeFieldSettings] ([Schemename],[FiledName],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor])     VALUES (N'" & Schname & "','Price',40,20,0,0,'Price','','ARIAL',10,0,'Black','Left',0,'NULL')")

            LoadDataIntoComboBox("select Schemename from barcodeprintsettings ", TxtSchemeName, "Schemename", "*New")
            TxtSchemeName.Text = Schname
            isImagechanged = False
        Else
            If MsgBox("Do you want to save changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim sqlstr As String = ""
            sqlstr = "UPDATE [barcodeprintsettings] SET [PaperSize]=@PaperSize,[lwidht]=@lwidht,[lheight]=@lheight, " _
                & " [TopMargin]=@TopMargin,[LeftMargin]=@LeftMargin,[HGap]=@HGap,[Vgap]=@Vgap,[IsPrintItemCode]=@IsPrintItemCode,[IsPrintMRP]=@IsPrintMRP, " _
                & " [IsPrintWRP]=@IsPrintWRP,[Noofcolumns]=@Noofcolumns,[IsPrintComp]=@IsPrintComp,[Currency]=@Currency, " _
                & " logowidth=@logowidth,logoheight=@logoheight,logoleft=@logoleft,logotop=@logotop,IslogoEnable=@IslogoEnable, [IsWithDecimal]=@IsWithDecimal ,BarcodeType=@BarcodeType where Schemename=N'" & TxtSchemeName.Text & "'"

            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
            With DBF.Parameters
                .AddWithValue("PaperSize", TxtPaperSize.Text)
                .AddWithValue("lwidht", TxtWidth.Value)
                .AddWithValue("lheight", TxtHeight.Value)
                .AddWithValue("TopMargin", TxtTop.Value)
                .AddWithValue("LeftMargin", TxtLeft.Value)
                .AddWithValue("HGap", TxtHgap.Value)
                .AddWithValue("Vgap", TxtVgap.Value)
                .AddWithValue("IsPrintItemCode", TxtIsprintItemCode.Checked)
                .AddWithValue("IsPrintMRP", 0)
                .AddWithValue("IsPrintWRP", IsPrintWRP.Checked)
                .AddWithValue("Noofcolumns", TxtNoCols.Value)
                .AddWithValue("IsPrintComp", IsPrintComp.Checked)
                .AddWithValue("Currency", TxtCurrency.Text)
                .AddWithValue("IsWithDecimal", TxtDecimals.Value)
                .AddWithValue("logowidth", TxtLogoWidth.Value)
                .AddWithValue("logoheight", TxtLogoHeight.Value)
                .AddWithValue("logoleft", TxtLogoLeft.Value)
                .AddWithValue("logotop", TxtLogoTop.Value)
                .AddWithValue("IslogoEnable", IsLogoPrint.Checked)
                .AddWithValue("BarcodeType", cbEncodeType.Text)
            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
            If isImagechanged = True Then
                sqlstr = "UPDATE [barcodeprintsettings] SET  [logo]=@logo where Schemename=N'" & TxtSchemeName.Text & "'"
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim DBF2 As New SqlClient.SqlCommand(sqlstr, MAINCON)
                With DBF2.Parameters
                    If TxtPic.Image.Equals(Nothing) Then
                        .AddWithValue("LOGO", DBNull.Value)
                    Else
                        Dim ms As New MemoryStream()
                        TxtPic.Image.Save(ms, TxtPic.Image.RawFormat)
                        Dim objData As Byte() = ms.GetBuffer()
                        .AddWithValue("LOGO", objData)
                        ms.Dispose()
                    End If

                End With
                DBF2.ExecuteNonQuery()
                DBF2 = Nothing
                MAINCON.Close()

            End If
            isImagechanged = False
        End If
    End Sub

    Private Sub btnMore_Click(sender As System.Object, e As System.EventArgs) Handles btnMore.Click
        If TxtSchemeName.Text = "*New" Then
            MsgBox("Please save the scheme and then try again...")
        Else
            Dim FRM As New BarcodeFieldSettings(TxtSchemeName.Text)
            FRM.ShowDialog()
        End If

    End Sub

    Private Sub GroupBox4_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        Dim sd As OpenFileDialog = New OpenFileDialog
        sd.Title = "Select Image "
        sd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
        sd.FilterIndex = 1
        sd.Multiselect = False
        If sd.ShowDialog = Windows.Forms.DialogResult.OK Then
            TxtPic.Image = Image.FromFile(sd.FileName)
            isImagechanged = True
        End If
    End Sub

    Private Sub GroupBox3_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        
        PrintReport(True)
        'objRpt.SetDataSource(ds)
        'Dim prs As New System.Drawing.Printing.PrinterSettings
        'Dim pages As New System.Drawing.Printing.PageSettings
        'prs.Copies = 1
        'prs.DefaultPageSettings.Margins.Left = 0
        'prs.DefaultPageSettings.Margins.Right = 0
        'prs.DefaultPageSettings.Margins.Top = 0
        'prs.DefaultPageSettings.Margins.Bottom = 0
        'MsgBox(prs.DefaultPageSettings.PaperSize.Height)
        'pages.Margins.Left = 0
        'pages.Margins.Right = 0
        'pages.Margins.Top = 0
        'pages.Margins.Bottom = 0
        'objRpt.PrintToPrinter(prs, pages, False)
        '' objRpt.PrintToPrinter(prs)
        'objRpt.Dispose()
        'ds.Dispose()
    End Sub
End Class