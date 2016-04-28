Imports System.Data.SqlClient
Imports System.IO

Module PrintingModule
    Dim PrtDbf As New ADODB.Recordset
    Public TotalPagesPrint As Long
    Public IsCashBill As Boolean = False
    Dim Conn As New ADODB.Connection
    Dim PrtData As New DataSet
    Public PagesetupValues As New PrintingPageVaulesStruct
    Public ChequePrintingValues As New ChequePrintValuesStruct
    Public ChequePagesetupValues As New PrintingPageVaulesStruct
    Public PrintOptionsforCR As New CrystalPriningOptionStrct
    ' Dim PrtRows As SqlClient.SqlDataReader
    Structure ChequePrintValuesStruct
        Dim Amount As Double
        Dim PayeeName As String
        Dim PrintDate As String
        Dim AmountinWords As String

    End Structure
    Structure PrintingPageVaulesStruct
        Dim Paperwidth As Integer
        Dim Paperheight As Integer
        Dim leftmarging As Integer
        Dim rightmarging As Integer
        Dim topmarging As Integer
        Dim buttommarging As Integer
        Dim IslandScape As Boolean
        Dim PrinterName As String
        Dim IsRollPaper As Boolean
    End Structure
    Structure CrystalPriningOptionStrct
        Dim IsPrintHeader As Boolean
        Dim IsPrintFooter As Boolean
        Dim IsPrintLeftLogo As Boolean
        Dim IsprintRightLogo As Boolean
        Dim LeftLogoPath As String
        Dim RightLogoPath As String
        Dim HeaderLogoPath As String
        Dim FooterLogoPath As String
        Dim ispirntPageNumber As Boolean
        Dim IsPrintCmpName As Boolean
        Dim IsprintCmpAddress As Boolean
        Dim IsPrintTitle As Boolean

    End Structure
    Public Sub LoadPageSetupValues(ByVal PrintingScheme As String)
        Dim Sqlstr1 As String = ""
        Sqlstr1 = "select * from printingsettings where schemename=N'" & PrintingScheme & "'"
        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            SQLFcmd.Connection = SqlConn1
            SQLFcmd.CommandText = Sqlstr1
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                PagesetupValues.Paperwidth = Sreader("width")
                PagesetupValues.Paperheight = Sreader("height")
                PagesetupValues.PrinterName = My.Settings.DefPrinterName
                PagesetupValues.IslandScape = Sreader("islandscape")
                PagesetupValues.leftmarging = Sreader("fleft")
                PagesetupValues.rightmarging = Sreader("fright")
                PagesetupValues.topmarging = Sreader("ftop")
                PagesetupValues.buttommarging = Sreader("fbuttom")
                PagesetupValues.IsRollPaper = Sreader("IsrollPaper")
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
            SqlConn1.Dispose()
            SQLFcmd.Connection = Nothing
        End Try
    End Sub
    Public Sub LoadChequePageSetupValues(ByVal PrintingScheme As String)
        Dim Sqlstr1 As String = ""
        Sqlstr1 = "select * from chequeprintingsettings where schemename=N'" & PrintingScheme & "'"
        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            SQLFcmd.Connection = SqlConn1
            SQLFcmd.CommandText = Sqlstr1
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                ChequePagesetupValues.Paperwidth = Sreader("width")
                ChequePagesetupValues.Paperheight = Sreader("height")
                ChequePagesetupValues.PrinterName = Sreader("PrinterName").ToString.Trim
                ChequePagesetupValues.IslandScape = Sreader("islandscape")
                ChequePagesetupValues.leftmarging = Sreader("fleft")
                ChequePagesetupValues.rightmarging = Sreader("fright")
                ChequePagesetupValues.topmarging = Sreader("ftop")
                ChequePagesetupValues.buttommarging = Sreader("fbuttom")

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
            SqlConn1.Dispose()
            SQLFcmd.Connection = Nothing
        End Try
    End Sub
    Sub Printingset(ByRef sender As System.Object, ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal Transcode As Single, ByVal PrintingScheme As String, ByVal Dbitemsname As String, ByVal dbname As String, Optional ByVal nocopies As Integer = 1, Optional ByVal IsDuplicateInvoice As Boolean = False, Optional ByVal InvoiceList As ComboBox = Nothing)

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
        Static RowNo As Integer = 0
        Dim PageTotal As Double = 0
        Static IsshowSubtotal As Boolean = False
        Dim Dbf As New ADODB.Recordset
        If IsFirstOpen = True Then
            IsFirstOpen = False

            e.PageSettings.PrinterSettings.PrinterName = SQLGetStringFieldValue("select PrinterName from PrintingSettings where schemename=N'" & PrintingScheme & "'", "PrinterName")
            IsshowSubtotal = SQLGetBooleanFieldValue("select Isheaderfooterrepeat from PrintingSettings where schemename=N'" & PrintingScheme & "'", "Isheaderfooterrepeat")
            pagerecords = SQLGetNumericFieldValue("select maxrowsperpage from PrintingSettings where schemename=N'" & PrintingScheme & "'", "maxrowsperpage")
            RowHeight = SQLGetNumericFieldValue("select rowheight from PrintingSettings where schemename=N'" & PrintingScheme & "'", "rowheight")
            PresentRecords = 1
            If pagerecords = 0 Then
                pagerecords = 20
            End If
            e.PageSettings.PrinterSettings.PrinterName = PagesetupValues.PrinterName

            PageTop = SQLGetNumericFieldValue("select ftop from printrecords where schemename=N'" & PrintingScheme & "'", "ftop")
            PageSpace = SQLGetNumericFieldValue("select space from printrecords where schemename=N'" & PrintingScheme & "'", "space")
            FooterTop = PageTop + SQLGetNumericFieldValue("select height from printrecords where schemename=N'" & PrintingScheme & "'", "height")

            If SQLGetStringFieldValue("select ledgername from  " & dbname & " where transcode=" & Transcode, "ledgername") = UCase(DefCashAccount) Then
                IsCashBill = True
            Else
                IsCashBill = False
            End If

            PageTopConst = PageTop
            RowNo = 0
           

            FillDataset(PrtData, "select * from  " & Dbitemsname & " where transcode=" & Transcode & " order by sno")

            If PrtData.Tables(0).Rows.Count < pagerecords Then
                pagerecords = PrtData.Tables(0).Rows.Count
            End If

            PageNos = Math.Ceiling(PrtData.Tables(0).Rows.Count / pagerecords)
            PageNo = 1
        End If
        If IsDuplicateInvoice = True Then
            Dim drawFormat21 As New StringFormat
            Dim drawFont21 As Font = New Font("arial", 11)
            Dim drawBrush21 As New SolidBrush(Color.Gray)
            Dim rect21 As New Rectangle(10, 10, e.PageSettings.PaperSize.Width, e.PageSettings.PaperSize.Height)
            drawFormat21.Alignment = StringAlignment.Center
            If nocopies = 1 Then
                e.Graphics.DrawString("ORIGINAL", drawFont21, drawBrush21, rect21, drawFormat21)
            Else
                e.Graphics.DrawString("COPY", drawFont21, drawBrush21, rect21, drawFormat21)
            End If
            drawFormat21.Dispose()
            drawFont21.Dispose()
            drawBrush21.Dispose()

        End If

        



        Dim SqlConn2 As New SqlClient.SqlConnection
        Try
            SqlConn2.ConnectionString = ConnectionStrinG
            SqlConn2.Open()
            SQLFcmd.Connection = SqlConn2
            SQLFcmd.CommandText = "select * from printingsettings where schemename=N'" & PrintingScheme & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                Try
                    If Sreader("LeftLogoIsOn") = True Then
                        Dim ImageValue As System.Drawing.Image
                        ImageValue = Image.FromFile(Sreader("leftlogopath").ToString.Trim)
                        e.Graphics.DrawImage(ImageValue, CSng(Sreader("Leftlogoleft")), CSng(Sreader("leftlogotop")), CSng(Sreader("Leftlogowidth")), CSng(Sreader("Leftlogoheight")))
                        ImageValue.Dispose()
                    End If
                Catch ex As Exception
                End Try

                Try
                    If Sreader("rightLogoIsOn") = True Then
                        Dim ImageValue As System.Drawing.Image
                        ImageValue = Image.FromFile(Sreader("rightlogopath").ToString.Trim)
                        e.Graphics.DrawImage(ImageValue, CSng(Sreader("rightlogoleft")), CSng(Sreader("rightlogotop")), CSng(Sreader("rightlogowidth")), CSng(Sreader("rightlogoheight")))
                        ImageValue.Dispose()
                    End If
                Catch ex As Exception

                End Try
            End While
            Sreader.Close()
            Sreader = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn2.Close()
            SqlConn2.Dispose()
            SQLFcmd.Connection = Nothing
        End Try


        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from PrintLables where schemename=N'" & PrintingScheme & "' and IsVisible='True'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
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


                If CSng(Sreader("width")) > 50 Then
                    Dim rect1 As New Rectangle(CSng(Sreader("fleft")), CSng(Sreader("ftop")), CSng(Sreader("width")), CSng(Sreader("height")))
                    e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, rect1, drawFormat)
                Else
                    e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                End If

                drawFormat.Dispose()
                drawFont.Dispose()
                drawBrush.Dispose()

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


        Dim SqlConn0 As New SqlClient.SqlConnection
        Try
            SqlConn0.ConnectionString = ConnectionStrinG
            SqlConn0.Open()
            SQLFcmd.Connection = SqlConn0
            SQLFcmd.CommandText = "select * from printheadings where schemename=N'" & PrintingScheme & "' and IsVisible='True'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
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
                e.Graphics.DrawString(Sreader("HeadText").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                drawFormat.Dispose()
                drawFont.Dispose()
                drawBrush.Dispose()
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn0.Close()
            SqlConn0.Dispose()
            SQLFcmd.Connection = Nothing
        End Try






        Dim SqlConn3 As New SqlClient.SqlConnection
        Try
            SqlConn3.ConnectionString = ConnectionStrinG
            SqlConn3.Open()
            SQLFcmd.Connection = SqlConn3
            SQLFcmd.CommandText = "select * from printlines where schemename=N'" & PrintingScheme & "' and IsVisible='True'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
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
                If Sreader("FieldType") = 0 Then
                    e.Graphics.DrawLine(penstyle, CSng(Sreader("fleft")), CSng(Sreader("ftop")), CSng(Sreader("width")), CSng(Sreader("height")))
                Else
                    e.Graphics.DrawRectangle(penstyle, CSng(Sreader("fleft")), CSng(Sreader("ftop")), CSng(Sreader("width")), CSng(Sreader("height")))
                End If
                penstyle.Dispose()
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


       


        Dim SqlConn5 As New SqlClient.SqlConnection
        Try
            SqlConn5.ConnectionString = ConnectionStrinG
            SqlConn5.Open()
            SQLFcmd.Connection = SqlConn5
            SQLFcmd.CommandText = "select * from Printrecords where schemename=N'" & PrintingScheme & "' and IsVisible='True'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                Dim drawFormat As New StringFormat
                Dim drawFont As Font = New Font("arial", 10)
                Dim drawBrush As New SolidBrush(Color.FromName(Sreader("lfontcolor").ToString.Trim))

                Select Case Sreader("lfontstyle")
                    Case 1
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold)
                    Case 2
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Italic)
                    Case 3
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Underline)
                    Case 4
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Italic)
                    Case 5
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Underline)
                    Case 6
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Italic Or FontStyle.Underline)
                    Case 7
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                    Case 8
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Regular)

                End Select


                If Sreader("lalign").ToString.Trim = "Left" Then
                    drawFormat.Alignment = StringAlignment.Near
                ElseIf Sreader("lalign").ToString.Trim = "Right" Then
                    drawFormat.Alignment = StringAlignment.Far
                Else
                    drawFormat.Alignment = StringAlignment.Center
                End If
                ' e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("lleft")), CSng(Sreader("ltop")), drawFormat)
                e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("lleft")), CSng(Sreader("ltop")), drawFormat)
                drawFormat.Dispose()
                drawFont.Dispose()
                drawBrush.Dispose()
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn5.Close()
            SqlConn5.Dispose()
            SQLFcmd.Connection = Nothing
        End Try




        'haha
        Dim INCRESEHEIGHT As Single = 0
        Dim flag2 As Boolean = False
        While PageTop + RowHeight <= FooterTop
            Try
                Dim k As String = PrtData.Tables(0).Rows(RowNo).Item("stockname").ToString

            Catch ex As Exception
                GoTo SSS
            End Try
            flag2 = False
            INCRESEHEIGHT = 0
            Dim SqlConn6 As New SqlClient.SqlConnection
            Try
                SqlConn6.ConnectionString = ConnectionStrinG
                SqlConn6.Open()
                SQLFcmd.Connection = SqlConn6
                SQLFcmd.CommandText = "select * from Printrecords where schemename=N'" & PrintingScheme & "' and IsVisible='True'"
                SQLFcmd.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd.ExecuteReader
                While Sreader.Read()
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
                    If UCase(Sreader("DBField").ToString.Trim) <> "SNO" Then
                        If Sreader("formattype") = 0 Then
                            If CSng(Sreader("width")) > 20 Then
                                Dim ht As Single = 0
                                ht = RowHeight ' RowHeight
                                Dim StringSize As New SizeF
                                StringSize = e.Graphics.MeasureString(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, drawFont)
                                Dim rect1 As New Rectangle(CSng(Sreader("fleft")), PageTop, CSng(Sreader("width")), ht)
                                If StringSize.Width > CSng(Sreader("width")) Then
                                    If StringSize.Width / CSng(Sreader("width")) > INCRESEHEIGHT Then
                                        INCRESEHEIGHT = StringSize.Width / CSng(Sreader("width"))
                                    End If

                                    ht = CSng(ht + RowHeight * INCRESEHEIGHT)
                                    rect1.Height = ht
                                    flag2 = True
                                End If

                                e.Graphics.DrawString(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, drawFont, drawBrush, rect1, drawFormat)
                            Else
                                e.Graphics.DrawString(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                            End If

                        Else
                            If Sreader("DBtype") = 3 Then
                                Dim vAL As String = ""
                                vAL = SQLGetStringFieldValue("SELECT " & Sreader("Formulastr").ToString.Trim & " AS TOT FROM " & Dbitemsname & " WHERE  TRANSCODE=" & Transcode & " AND SNO=" & PrtData.Tables(0).Rows(RowNo).Item("SNO"), "TOT", "", False)
                                If vAL.Length = 0 Then
                                    vAL = SQLGetStringFieldValue(Sreader("Formulastr").ToString.Trim & "  WHERE  TRANSCODE=" & Transcode & " AND SNO=" & PrtData.Tables(0).Rows(RowNo).Item("SNO"), "TOT", "", False)
                                End If
                                If IsNumeric(vAL) = True Then
                                    If CDbl(vAL) <> 0 Then
                                        Try
                                            e.Graphics.DrawString(FormatNumber(vAL, Sreader("decimals")).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                                        Catch ex As Exception

                                        End Try
                                    Else
                                        If Sreader("supress") = 0 Then
                                            Try
                                                e.Graphics.DrawString(FormatNumber(vAL, Sreader("decimals")).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                                            Catch ex As Exception

                                            End Try
                                        End If
                                    End If

                                Else
                                    Try
                                        e.Graphics.DrawString(vAL, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                                    Catch ex As Exception

                                    End Try
                                End If
                            Else
                                '  e.Graphics.DrawString(FormatNumber(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, Sreader("decimals")).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                                If CDbl(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField"))) <> 0 Then
                                    e.Graphics.DrawString(FormatNumber(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, Sreader("decimals")).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                                Else
                                    If Sreader("supress") = 0 Then
                                        e.Graphics.DrawString(FormatNumber(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, Sreader("decimals")).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                                    End If
                                End If
                            End If
                            
                        End If
                    Else
                        e.Graphics.DrawString(PresentRecords, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                    End If
                        drawBrush.Dispose()
                        drawFont.Dispose()
                        drawFormat.Dispose()
                End While
                Sreader.Close()
                Sreader = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SqlConn6.Close()
                SqlConn6.Dispose()
                SQLFcmd.Connection = Nothing
            End Try
            If flag2 = True Then
                PageTop = PageTop + RowHeight * INCRESEHEIGHT
                flag2 = False
            End If
            Try
                PageTotal = PageTotal + PrtData.Tables(0).Rows(RowNo).Item("StockAmount").ToString
                PageTop = PageTop + RowHeight
                RowNo = RowNo + 1
                PresentRecords = PresentRecords + 1
            Catch ex As Exception
                PresentRecords = PrtData.Tables(0).Rows.Count
                GoTo sss
            End Try
        End While
SSS:
        Dim SqlStr1 As String = ""
        Dim lEDGERnAME As String = ""
        lEDGERnAME = SQLGetStringFieldValue("select LEDGERNAME from " & dbname & " where transcode=" & Transcode, "LEDGERNAME")
        If PresentRecords >= PrtData.Tables(0).Rows.Count And RowNo >= PrtData.Tables(0).Rows.Count Then
            SqlStr1 = "select * from PrintFieldLabels where schemename=N'" & PrintingScheme & "'"
        Else

            SqlStr1 = "select * from PrintFieldLabels where schemename=N'" & PrintingScheme & "' and ltop<" & FooterTop
        End If

        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            SQLFcmd.Connection = SqlConn1
            SQLFcmd.CommandText = SqlStr1
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                If Sreader("DBField").ToString.ToUpper = "CurrentBalance".ToUpper Then
                    If SQLIsFieldExists("select ledgername from ledgers where ledgername=N'" & lEDGERnAME & "' and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "')") = False Then
                        ExecuteSQLQuery("UPDATE PrintFieldLabels SET PRINTTEXT=N'" & GetCurrentBalanceText(lEDGERnAME) & "' where schemename=N'" & PrintingScheme & "' and dbfield=N'" & Sreader("dbfield").ToString.Trim & "'")
                    End If
                Else
                    Try

                      

                        If Sreader("databasevalue") = 1 Then
                            If Sreader("DbType") <> 3 Then
                                ExecuteSQLQuery("UPDATE PrintFieldLabels SET PRINTTEXT=N'" & SQLGetStringFieldValue("select * from ledgers where ledgername=N'" & lEDGERnAME & "'", Sreader("dbfield").ToString.Trim) & "' where schemename=N'" & PrintingScheme & "' and dbfield=N'" & Sreader("dbfield").ToString.Trim & "'")
                            End If

                        ElseIf Sreader("dbfield") = "TransDate" Then

                            ExecuteSQLQuery("UPDATE PrintFieldLabels SET PRINTTEXT=N'" & SQLGetStringFieldValue("select CONVERT(VARCHAR(10),transdate," & DateFormatConversionNumber & ") as ds from " & dbname & " where transcode=" & Transcode, "ds") & "' where schemename=N'" & PrintingScheme & "' and dbfield=N'" & Sreader("dbfield").ToString.Trim & "'")
                        Else
                            If Sreader("DbType") <> 3 Then
                                ExecuteSQLQuery("UPDATE PrintFieldLabels SET PRINTTEXT=N'" & SQLGetStringFieldValue("select * from " & dbname & " where transcode=" & Transcode, Sreader("dbfield").ToString.Trim) & "' where schemename=N'" & PrintingScheme & "' and dbfield=N'" & Sreader("dbfield").ToString.Trim & "'")
                            End If

                        End If
                    Catch ex As Exception

                    End Try
                End If
               

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
            SqlConn1.Dispose()
            SQLFcmd.Connection = Nothing
        End Try


        Dim SqlStr2 As String = ""
        If PresentRecords >= PrtData.Tables(0).Rows.Count And RowNo >= PrtData.Tables(0).Rows.Count Then

            SqlStr2 = "select * from PrintFieldLabels where schemename=N'" & PrintingScheme & "' and IsVisible='True' "
        Else
            SqlStr2 = "select * from PrintFieldLabels where schemename=N'" & PrintingScheme & "' and IsVisible='True' and ltop<" & FooterTop
        End If

        Dim SqlConn4 As New SqlClient.SqlConnection
        Try
            SqlConn4.ConnectionString = ConnectionStrinG
            SqlConn4.Open()
            SQLFcmd.Connection = SqlConn4
            SQLFcmd.CommandText = SqlStr2
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
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
                If Sreader("DBtype") = 3 Then
                    Dim vAL As String = ""
                    vAL = SQLGetStringFieldValue("SELECT " & Sreader("Formulastr").ToString.Trim & " AS TOT FROM " & dbname & " WHERE  TRANSCODE=" & Transcode, "TOT", "", False)
                    If vAL.Length = 0 Then
                        vAL = SQLGetStringFieldValue(Sreader("Formulastr").ToString.Trim & " WHERE  TRANSCODE=" & Transcode, "TOT", "", False)
                    End If
                    If IsNumeric(vAL) = True Then
                        If CDbl(vAL) <> 0 Then
                            Try
                                Try
                                    e.Graphics.DrawString(FormatNumber(vAL, Sreader("decimals")).ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                                Catch ex As Exception
                                    e.Graphics.DrawString(vAL, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                                End Try

                            Catch ex As Exception

                            End Try
                        Else
                            If Sreader("supress") = 0 Then
                                Try
                                    e.Graphics.DrawString(FormatNumber(vAL, Sreader("decimals")).ToString.Trim, drawFont, drawBrush, CSng(Sreader("lleft")), CSng(Sreader("ltop")), drawFormat)
                                Catch ex As Exception

                                End Try
                            End If
                        End If

                    Else
                        Try
                            e.Graphics.DrawString(vAL, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                        Catch ex As Exception

                        End Try
                    End If
                Else
                    If CSng(Sreader("width")) > 50 Then
                        Dim rect1 As New Rectangle(CSng(Sreader("fleft")), CSng(Sreader("ftop")), CSng(Sreader("width")), CSng(Sreader("height")))
                        If Sreader("formattype") = 0 Then
                            e.Graphics.DrawString(Sreader("printtext").ToString.Trim, drawFont, drawBrush, rect1, drawFormat)
                        Else
                            Try
                                e.Graphics.DrawString(FormatNumber(Sreader("printtext"), Sreader("decimals")).ToString.Trim, drawFont, drawBrush, rect1, drawFormat)
                            Catch ex As Exception
                                e.Graphics.DrawString(Sreader("printtext").ToString.Trim, drawFont, drawBrush, rect1, drawFormat)
                            End Try

                        End If
                    Else
                        If Sreader("formattype") = 0 Then
                            e.Graphics.DrawString(Sreader("printtext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                        Else
                            Try
                                e.Graphics.DrawString(FormatNumber(Sreader("printtext"), Sreader("decimals")).ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                            Catch ex As Exception
                                e.Graphics.DrawString(Sreader("printtext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                            End Try
                        End If
                    End If
                End If
              

                Select Case Sreader("lfontstyle")
                    Case 1
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold)
                    Case 2
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Italic)
                    Case 3
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Underline)
                    Case 4
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Italic)
                    Case 5
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Underline)
                    Case 6
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Italic Or FontStyle.Underline)
                    Case 7
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                    Case 8
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Regular)

                End Select


                drawBrush.Color = Color.FromName(Sreader("lfontcolor").ToString.Trim)
                If Sreader("lalign").ToString.Trim = "Left" Then
                    drawFormat.Alignment = StringAlignment.Near
                ElseIf Sreader("lalign").ToString.Trim = "Right" Then
                    drawFormat.Alignment = StringAlignment.Far
                Else
                    drawFormat.Alignment = StringAlignment.Center
                End If
                
                    Try
                        e.Graphics.DrawString(FormatNumber(Sreader("labletext"), Sreader("decimals")).ToString.Trim, drawFont, drawBrush, CSng(Sreader("lleft")), CSng(Sreader("ltop")), drawFormat)
                    Catch ex As Exception
                        e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("lleft")), CSng(Sreader("ltop")), drawFormat)
                    End Try



                drawFormat.Dispose()
                drawFont.Dispose()
                drawBrush.Dispose()

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn4.Close()
            SqlConn4.Dispose()
            SQLFcmd.Connection = Nothing
        End Try




        Dim SqlConn8 As New SqlClient.SqlConnection
        Try
            SqlConn8.ConnectionString = ConnectionStrinG
            SqlConn8.Open()
            SQLFcmd.Connection = SqlConn8
            SQLFcmd.CommandText = "select * from PrintingSettings where schemename=N'" & PrintingScheme & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                If Sreader("showpageno") = True Then
                    If Sreader("pageformat") = 0 Then
                        e.Graphics.DrawString("Page " & PageNo.ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Sreader("pagenoleft")), CSng(Sreader("pagenotop")))
                    Else
                        e.Graphics.DrawString("Page " & PageNo.ToString & " of " & PageNos.ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Sreader("pagenoleft")), CSng(Sreader("pagenotop")))
                    End If
                End If
                If PresentRecords >= PrtData.Tables(0).Rows.Count And RowNo >= PrtData.Tables(0).Rows.Count Then

                Else
                    If IsshowSubtotal = True Then
                        e.Graphics.DrawString("Page Total= " & FormatNumber(PageTotal, ErpDecimalPlaces).ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Sreader("pagenoleft")), CSng(Sreader("pagenotop")) - 80)
                        e.Graphics.DrawString("Continue........", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Sreader("pagenoleft")), CSng(Sreader("pagenotop")) - 50)
                    End If
                  
                End If
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn8.Close()
            SqlConn8.Dispose()
            SQLFcmd.Connection = Nothing
        End Try

        If PresentRecords >= PrtData.Tables(0).Rows.Count And RowNo >= PrtData.Tables(0).Rows.Count Then
            IsFirstOpen = True
            PageTop = 0
            PageSpace = 0
            RowHeight = 0
            PresentRecords = 1
            pagerecords = 1
            PageNo = 1
            PageNos = 1
            e.HasMorePages = False
            PrtData.Tables(0).Clear()
        Else
            e.HasMorePages = True
            PageNo = PageNo + 1
            PageTop = PageTopConst
        End If


    End Sub


    Sub PrintPriviewSet(ByRef sender As System.Object, ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal PrintingScheme As String, ByVal Dbitemsname As String, ByVal dbname As String)

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
        Static RowNo As Integer = 0
        Static IsshowSubtotal As Boolean = False
        '  Static IsRepeatHeaderandfooter As Boolean = False
        Dim PageTotal As Double = 0
        Static TotalPageHeightforRows As Single = 0
        Static PageTopForRows As Single = 0
        Dim Dbf As New ADODB.Recordset
        If IsFirstOpen = True Then
            IsFirstOpen = False
            e.PageSettings.PrinterSettings.PrinterName = SQLGetStringFieldValue("select PrinterName from PrintingSettings where schemename=N'" & PrintingScheme & "'", "PrinterName")
            IsshowSubtotal = SQLGetBooleanFieldValue("select Isheaderfooterrepeat from PrintingSettings where schemename=N'" & PrintingScheme & "'", "Isheaderfooterrepeat")
            pagerecords = SQLGetNumericFieldValue("select maxrowsperpage from PrintingSettings where schemename=N'" & PrintingScheme & "'", "maxrowsperpage")
            RowHeight = SQLGetNumericFieldValue("select rowheight from PrintingSettings where schemename=N'" & PrintingScheme & "'", "rowheight")
            PresentRecords = 1
            If pagerecords = 0 Then
                pagerecords = 20
            End If
            e.PageSettings.PrinterSettings.PrinterName = PagesetupValues.PrinterName
            PageTop = SQLGetNumericFieldValue("select ftop from printrecords where schemename=N'" & PrintingScheme & "'", "ftop")
            PageSpace = SQLGetNumericFieldValue("select space from printrecords where schemename=N'" & PrintingScheme & "'", "space")
            TotalPageHeightforRows = SQLGetNumericFieldValue("select height from printrecords where schemename=N'" & PrintingScheme & "'", "height")
            PageTopForRows = PageTop
            FooterTop = PageTop + TotalPageHeightforRows

            IsCashBill = False
            PageTopConst = PageTop
            RowNo = 0
            FillDataset(PrtData, "select * from  " & Dbitemsname & " order by sno")
            If PrtData.Tables(0).Rows.Count < pagerecords Then
                pagerecords = PrtData.Tables(0).Rows.Count
            End If

            Try
                PageNos = Math.Ceiling(PrtData.Tables(0).Rows.Count / pagerecords)
            Catch ex As Exception
                PageNos = 1
            End Try
            PageNo = 1
        End If


        Dim SqlStr1 As String = ""
        Dim lEDGERnAME As String = ""
        Dim drawFormat21 As New StringFormat
        Dim drawFont21 As Font = New Font("arial", 11)
        Dim drawBrush21 As New SolidBrush(Color.Gray)
        Dim rect21 As New Rectangle(10, 10, e.PageSettings.PaperSize.Width, e.PageSettings.PaperSize.Height)
        drawFormat21.Alignment = StringAlignment.Center
        e.Graphics.DrawString("ORIGINAL", drawFont21, drawBrush21, rect21, drawFormat21)
        drawFormat21.Dispose()
        drawFont21.Dispose()
        drawBrush21.Dispose()

        Dim ImageValue As System.Drawing.Image
        Dim SqlConn2 As New SqlClient.SqlConnection
        Try
            SqlConn2.ConnectionString = ConnectionStrinG
            SqlConn2.Open()
            SQLFcmd.Connection = SqlConn2
            SQLFcmd.CommandText = "select * from printingsettings where schemename=N'" & PrintingScheme & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                Try
                    If Sreader("LeftLogoIsOn") = True Then
                        ImageValue = Image.FromFile(Sreader("leftlogopath").ToString.Trim)
                        e.Graphics.DrawImage(ImageValue, CSng(Sreader("Leftlogoleft")), CSng(Sreader("leftlogotop")), CSng(Sreader("Leftlogowidth")), CSng(Sreader("Leftlogoheight")))
                    End If
                Catch ex As Exception
                End Try

                Try
                    If Sreader("rightLogoIsOn") = True Then
                        ImageValue = Image.FromFile(Sreader("rightlogopath").ToString.Trim)
                        e.Graphics.DrawImage(ImageValue, CSng(Sreader("rightlogoleft")), CSng(Sreader("rightlogotop")), CSng(Sreader("rightlogowidth")), CSng(Sreader("rightlogoheight")))
                    End If
                Catch ex As Exception

                End Try
            End While
            Sreader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn2.Close()
            SQLFcmd.Connection = Nothing
        End Try



        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from PrintLables where schemename=N'" & PrintingScheme & "' and IsVisible='True'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
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


                If CSng(Sreader("width")) > 50 Then
                    Dim rect1 As New Rectangle(CSng(Sreader("fleft")), CSng(Sreader("ftop")), CSng(Sreader("width")), CSng(Sreader("height")))
                    e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, rect1, drawFormat)
                Else
                    e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                End If
                drawBrush.Dispose()
                drawFont.Dispose()
                drawFormat.Dispose()

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


        Dim SqlConn0 As New SqlClient.SqlConnection
        Try
            SqlConn0.ConnectionString = ConnectionStrinG
            SqlConn0.Open()
            SQLFcmd.Connection = SqlConn0
            SQLFcmd.CommandText = "select * from printheadings where schemename=N'" & PrintingScheme & "'  and IsVisible='True'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
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
                e.Graphics.DrawString(Sreader("HeadText").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                drawBrush.Dispose()
                drawFont.Dispose()
                drawFormat.Dispose()
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn0.Close()
            SqlConn0.Dispose()
            SQLFcmd.Connection = Nothing
        End Try






        Dim SqlConn3 As New SqlClient.SqlConnection
        Try
            SqlConn3.ConnectionString = ConnectionStrinG
            SqlConn3.Open()
            SQLFcmd.Connection = SqlConn3
            SQLFcmd.CommandText = "select * from printlines where schemename=N'" & PrintingScheme & "' and IsVisible='True'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
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
                If Sreader("FieldType") = 0 Then
                    e.Graphics.DrawLine(penstyle, CSng(Sreader("fleft")), CSng(Sreader("ftop")), CSng(Sreader("width")), CSng(Sreader("height")))
                Else
                    e.Graphics.DrawRectangle(penstyle, CSng(Sreader("fleft")), CSng(Sreader("ftop")), CSng(Sreader("width")), CSng(Sreader("height")))
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


       


        Dim SqlConn5 As New SqlClient.SqlConnection
        Try
            SqlConn5.ConnectionString = ConnectionStrinG
            SqlConn5.Open()
            SQLFcmd.Connection = SqlConn5
            SQLFcmd.CommandText = "select * from Printrecords where schemename=N'" & PrintingScheme & "' and IsVisible='True'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                Dim drawFormat As New StringFormat
                Dim drawFont As Font = New Font("arial", 10)
                Dim drawBrush As New SolidBrush(Color.FromName(Sreader("lfontcolor").ToString.Trim))

                Select Case Sreader("lfontstyle")
                    Case 1
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold)
                    Case 2
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Italic)
                    Case 3
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Underline)
                    Case 4
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Italic)
                    Case 5
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Underline)
                    Case 6
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Italic Or FontStyle.Underline)
                    Case 7
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                    Case 8
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Regular)

                End Select


                If Sreader("lalign").ToString.Trim = "Left" Then
                    drawFormat.Alignment = StringAlignment.Near
                ElseIf Sreader("lalign").ToString.Trim = "Right" Then
                    drawFormat.Alignment = StringAlignment.Far
                Else
                    drawFormat.Alignment = StringAlignment.Center
                End If
                Try
                    If Sreader("printtext") <> 0 Then
                        e.Graphics.DrawString(FormatNumber(Sreader("printtext"), Sreader("decimals")).ToString.Trim, drawFont, drawBrush, CSng(Sreader("lleft")), CSng(Sreader("ltop")), drawFormat)
                    Else
                        If Sreader("supress") = 0 Then
                            e.Graphics.DrawString(FormatNumber(Sreader("printtext"), Sreader("decimals")).ToString.Trim, drawFont, drawBrush, CSng(Sreader("lleft")), CSng(Sreader("ltop")), drawFormat)
                        End If
                    End If

                Catch ex As Exception
                    e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("lleft")), CSng(Sreader("ltop")), drawFormat)
                End Try
                drawBrush.Dispose()
                drawFont.Dispose()
                drawFormat.Dispose()
            End While
            Sreader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn5.Close()
            SqlConn5.Dispose()
            SQLFcmd.Connection = Nothing
        End Try
        Dim INCRESEHEIGHT As Single = 0
        Dim flag2 As Boolean = False
        While PageTop + RowHeight <= FooterTop
            Try
                Dim k As String = PrtData.Tables(0).Rows(RowNo).Item("stockname").ToString

            Catch ex As Exception
                GoTo SSS
            End Try
            flag2 = False
            INCRESEHEIGHT = 0
            Dim SqlConn6 As New SqlClient.SqlConnection
            Try
                SqlConn6.ConnectionString = ConnectionStrinG
                SqlConn6.Open()
                SQLFcmd.Connection = SqlConn6
                SQLFcmd.CommandText = "select * from Printrecords where schemename=N'" & PrintingScheme & "' and IsVisible='True' "
                SQLFcmd.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd.ExecuteReader
                While Sreader.Read()
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
                    If UCase(Sreader("DBField").ToString.Trim) <> "SNO" Then
                        If Sreader("formattype") = 0 Then
                            If CSng(Sreader("width")) > 20 Then
                                Dim ht As Single = 0
                                ht = RowHeight ' RowHeight
                                Dim StringSize As New SizeF
                                StringSize = e.Graphics.MeasureString(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, drawFont)
                                Dim rect1 As New Rectangle(CSng(Sreader("fleft")), PageTop, CSng(Sreader("width")), ht)
                                If StringSize.Width > CSng(Sreader("width")) Then
                                    If StringSize.Width / CSng(Sreader("width")) > INCRESEHEIGHT Then
                                        INCRESEHEIGHT = StringSize.Width / CSng(Sreader("width"))
                                    End If
                                    ht = CSng(ht + RowHeight * INCRESEHEIGHT)
                                    rect1.Height = ht

                                    flag2 = True
                                End If

                                e.Graphics.DrawString(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, drawFont, drawBrush, rect1, drawFormat)
                            Else
                                e.Graphics.DrawString(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                            End If

                        Else
                            '  e.Graphics.DrawString(FormatNumber(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, Sreader("decimals")).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                            If Sreader("DBtype") = 3 Then
                                Dim vAL As String = ""
                                vAL = SQLGetStringFieldValue("SELECT " & Sreader("Formulastr").ToString.Trim & " AS TOT FROM " & Dbitemsname & " WHERE  SNO=1", "TOT", "", False)
                                If vAL.Length = 0 Then
                                    vAL = SQLGetStringFieldValue(Sreader("Formulastr").ToString.Trim & " WHERE  SNO=1", "TOT", "", False)
                                End If
                                If IsNumeric(vAL) = True Then
                                    If CDbl(vAL) <> 0 Then
                                        Try
                                            e.Graphics.DrawString(FormatNumber(vAL, Sreader("decimals")).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                                        Catch ex As Exception

                                        End Try
                                    Else
                                        If Sreader("supress") = 0 Then
                                            Try
                                                e.Graphics.DrawString(FormatNumber(vAL, Sreader("decimals")).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                                            Catch ex As Exception

                                            End Try
                                        End If
                                    End If
                                   
                                Else
                                    Try
                                        e.Graphics.DrawString(vAL, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                                    Catch ex As Exception

                                    End Try
                                End If
                            Else
                                If CDbl(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField"))) <> 0 Then
                                    e.Graphics.DrawString(FormatNumber(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, Sreader("decimals")).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                                Else
                                    If Sreader("supress") = 0 Then
                                        e.Graphics.DrawString(FormatNumber(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, Sreader("decimals")).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                                    End If
                                End If
                            End If
                        End If
                    Else
                        e.Graphics.DrawString(PresentRecords, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                    End If
                    drawBrush.Dispose()
                    drawFont.Dispose()
                    drawFormat.Dispose()
                End While
                Sreader.Close()
                Sreader = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SqlConn6.Close()
                SqlConn6.Dispose()
                SQLFcmd.Connection = Nothing
            End Try
            If flag2 = True Then
                PageTop = PageTop + RowHeight * INCRESEHEIGHT
                flag2 = False
            End If
            Try
                PageTotal = PageTotal + PrtData.Tables(0).Rows(RowNo).Item("StockAmount").ToString
                PageTop = PageTop + RowHeight
                RowNo = RowNo + 1
                PresentRecords = PresentRecords + 1
            Catch ex As Exception
                PresentRecords = PrtData.Tables(0).Rows.Count
                GoTo sss
            End Try
        End While






SSS:
       

        Dim SqlStr2 As String = ""
        If PresentRecords >= PrtData.Tables(0).Rows.Count And RowNo >= PrtData.Tables(0).Rows.Count Then

            SqlStr2 = "select * from PrintFieldLabels where schemename=N'" & PrintingScheme & "' and IsVisible='True' "
        Else
            SqlStr2 = "select * from PrintFieldLabels where schemename=N'" & PrintingScheme & "' and IsVisible='True' and ltop<" & FooterTop
        End If

        Dim SqlConn4 As New SqlClient.SqlConnection
        Try
            SqlConn4.ConnectionString = ConnectionStrinG
            SqlConn4.Open()
            SQLFcmd.Connection = SqlConn4
            SQLFcmd.CommandText = SqlStr2
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
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
                If Sreader("DBtype") = 3 Then
                    Dim vAL As String = ""
                    vAL = Sreader("Formulastr").ToString.Trim
                    vAL = vAL.Replace("stockinvoicerowitems", Dbitemsname)
                    vAL = vAL.Replace("stockinvoicedetails", dbname)
                    vAL = SQLGetStringFieldValue("SELECT " & vAL & " AS TOT FROM " & dbname & " WHERE  TRANSCODE=0", "TOT", "", False)
                    If vAL.Length = 0 Then
                        vAL = SQLGetStringFieldValue(Sreader("Formulastr").ToString.Trim & " WHERE  TRANSCODE=0", "TOT", "", False)
                    End If
                    If IsNumeric(vAL) = True Then
                        If CDbl(vAL) <> 0 Then
                            Try
                                Try
                                    e.Graphics.DrawString(FormatNumber(vAL, Sreader("decimals")).ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                                Catch ex As Exception
                                    e.Graphics.DrawString(vAL, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                                End Try

                            Catch ex As Exception

                            End Try
                        Else
                            If Sreader("supress") = 0 Then
                                Try
                                    e.Graphics.DrawString(FormatNumber(vAL, Sreader("decimals")).ToString.Trim, drawFont, drawBrush, CSng(Sreader("lleft")), CSng(Sreader("ltop")), drawFormat)
                                Catch ex As Exception

                                End Try
                            End If
                        End If

                    Else
                        Try
                            e.Graphics.DrawString(vAL, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                        Catch ex As Exception

                        End Try
                    End If
                Else
                    If CSng(Sreader("width")) > 50 Then
                        Dim rect1 As New Rectangle(CSng(Sreader("fleft")), CSng(Sreader("ftop")), CSng(Sreader("width")), CSng(Sreader("height")))
                        If Sreader("formattype") = 0 Then
                            e.Graphics.DrawString(Sreader("printtext").ToString.Trim, drawFont, drawBrush, rect1, drawFormat)
                        Else
                            Try
                                e.Graphics.DrawString(FormatNumber(Sreader("printtext"), Sreader("decimals")).ToString.Trim, drawFont, drawBrush, rect1, drawFormat)
                            Catch ex As Exception
                                e.Graphics.DrawString(Sreader("printtext").ToString.Trim, drawFont, drawBrush, rect1, drawFormat)
                            End Try
                        End If
                    Else
                        If Sreader("formattype") = 0 Then
                            e.Graphics.DrawString(Sreader("printtext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                        Else

                            Try
                                e.Graphics.DrawString(FormatNumber(Sreader("printtext"), Sreader("decimals")).ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                            Catch ex As Exception
                                e.Graphics.DrawString(Sreader("printtext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                            End Try
                        End If
                    End If
                End If

              

                Select Case Sreader("lfontstyle")
                    Case 1
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold)
                    Case 2
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Italic)
                    Case 3
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Underline)
                    Case 4
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Italic)
                    Case 5
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Underline)
                    Case 6
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Italic Or FontStyle.Underline)
                    Case 7
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                    Case 8
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Regular)

                End Select


                drawBrush.Color = Color.FromName(Sreader("lfontcolor").ToString.Trim)
                If Sreader("lalign").ToString.Trim = "Left" Then
                    drawFormat.Alignment = StringAlignment.Near
                ElseIf Sreader("lalign").ToString.Trim = "Right" Then
                    drawFormat.Alignment = StringAlignment.Far
                Else
                    drawFormat.Alignment = StringAlignment.Center
                End If

                Try
                    e.Graphics.DrawString(FormatNumber(Sreader("labletext"), Sreader("decimals")).ToString.Trim, drawFont, drawBrush, CSng(Sreader("lleft")), CSng(Sreader("ltop")), drawFormat)
                Catch ex As Exception
                    e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("lleft")), CSng(Sreader("ltop")), drawFormat)
                End Try


                drawFormat.Dispose()
                drawFont.Dispose()
                drawBrush.Dispose()

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn4.Close()
            SqlConn4.Dispose()
            SQLFcmd.Connection = Nothing
        End Try




        Dim SqlConn8 As New SqlClient.SqlConnection
        Try
            SqlConn8.ConnectionString = ConnectionStrinG
            SqlConn8.Open()
            SQLFcmd.Connection = SqlConn8
            SQLFcmd.CommandText = "select * from PrintingSettings where schemename=N'" & PrintingScheme & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                If Sreader("showpageno") = True Then
                    If Sreader("pageformat") = 0 Then
                        e.Graphics.DrawString("Page " & PageNo.ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Sreader("pagenoleft")), CSng(Sreader("pagenotop")))
                    Else
                        e.Graphics.DrawString("Page " & PageNo.ToString & " of " & PageNos.ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Sreader("pagenoleft")), CSng(Sreader("pagenotop")))
                    End If
                End If
                If PresentRecords >= PrtData.Tables(0).Rows.Count And RowNo >= PrtData.Tables(0).Rows.Count Then

                Else
                    If IsshowSubtotal = True Then
                        e.Graphics.DrawString("Page Total= " & FormatNumber(PageTotal, ErpDecimalPlaces).ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Sreader("pagenoleft")), CSng(Sreader("pagenotop")) - 80)
                        e.Graphics.DrawString("Continue........", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Sreader("pagenoleft")), CSng(Sreader("pagenotop")) - 50)
                    End If
                  
                End If
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn8.Close()
            SqlConn8.Dispose()
            SQLFcmd.Connection = Nothing
        End Try

        If PresentRecords >= PrtData.Tables(0).Rows.Count And RowNo >= PrtData.Tables(0).Rows.Count Then
            IsFirstOpen = True
            PageTop = 0
            PageSpace = 0
            RowHeight = 0
            PresentRecords = 1
            pagerecords = 1
            PageNo = 1
            PageNos = 1
            e.HasMorePages = False
            PrtData.Tables(0).Clear()
        Else
            e.HasMorePages = True
            PageNo = PageNo + 1
            PageTop = PageTopConst
        End If


    End Sub



    Sub PrintingWithMultipleInvoices(ByRef sender As System.Object, ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal Transcode As Single, ByVal PrintingScheme As String, ByVal Dbitemsname As String, ByVal dbname As String, ByVal InvoiceList As ComboBox)

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
        Static RowNo As Integer = 0
        Dim PageTotal As Double = 0
        Static IsshowSubtotal As Boolean = False
        Static InvCount As Long = 0
        Static NewBill As Boolean = True

        Dim Dbf As New ADODB.Recordset
        If IsFirstOpen = True Then
            Transcode = CSng(InvoiceList.Items(InvCount))
            InvCount = InvCount + 1

            IsFirstOpen = False
            e.PageSettings.PrinterSettings.PrinterName = PagesetupValues.PrinterName
            'Dbf.Open("select * from PrintingSettings where schemename=N'" & PrintingScheme & "'", Conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            e.PageSettings.PrinterSettings.PrinterName = SQLGetStringFieldValue("select PrinterName from PrintingSettings where schemename=N'" & PrintingScheme & "'", "PrinterName")
            IsshowSubtotal = SQLGetBooleanFieldValue("select Isheaderfooterrepeat from PrintingSettings where schemename=N'" & PrintingScheme & "'", "Isheaderfooterrepeat")
            pagerecords = SQLGetNumericFieldValue("select maxrowsperpage from PrintingSettings where schemename=N'" & PrintingScheme & "'", "maxrowsperpage")
            RowHeight = SQLGetNumericFieldValue("select rowheight from PrintingSettings where schemename=N'" & PrintingScheme & "'", "rowheight")
            PresentRecords = 1
            If pagerecords = 0 Then
                pagerecords = 20
            End If
            'Isheaderfooterrepeat

            'Dbf.Open("select * from printrecords where schemename=N'" & PrintingScheme & "'", Conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            PageTop = SQLGetNumericFieldValue("select ftop from printrecords where schemename=N'" & PrintingScheme & "'", "ftop")
            PageSpace = SQLGetNumericFieldValue("select space from printrecords where schemename=N'" & PrintingScheme & "'", "space")
            FooterTop = PageTop + SQLGetNumericFieldValue("select height from printrecords where schemename=N'" & PrintingScheme & "'", "height")
            'Dbf.Open("select * from  " & dbname & " where transcode=" & Transcode, Conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If SQLGetStringFieldValue("select ledgername from  " & dbname & " where transcode=" & Transcode, "ledgername") = UCase(DefCashAccount) Then
                IsCashBill = True
            Else
                IsCashBill = False
            End If

            PageTopConst = PageTop
            RowNo = 0
            'PrtDbf.Open("select * from  " & Dbitemsname & " where transcode=" & Transcode, Conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            'PrtDbf.MoveFirst()

            FillDataset(PrtData, "select * from  " & Dbitemsname & " where transcode=" & Transcode & " order by sno")

            If PrtData.Tables(0).Rows.Count < pagerecords Then
                pagerecords = PrtData.Tables(0).Rows.Count
            End If

            PageNos = Math.Ceiling(PrtData.Tables(0).Rows.Count / pagerecords)
            PageNo = 1
        End If


       


        Dim ImageValue As System.Drawing.Image
        Dim SqlConn2 As New SqlClient.SqlConnection
        Try
            SqlConn2.ConnectionString = ConnectionStrinG
            SqlConn2.Open()
            SQLFcmd.Connection = SqlConn2
            SQLFcmd.CommandText = "select * from printingsettings where schemename=N'" & PrintingScheme & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                Try
                    If Sreader("LeftLogoIsOn") = True Then
                        ImageValue = Image.FromFile(Sreader("leftlogopath").ToString.Trim)
                        e.Graphics.DrawImage(ImageValue, CSng(Sreader("Leftlogoleft")), CSng(Sreader("leftlogotop")), CSng(Sreader("Leftlogowidth")), CSng(Sreader("Leftlogoheight")))
                    End If
                Catch ex As Exception
                End Try

                Try
                    If Sreader("rightLogoIsOn") = True Then
                        ImageValue = Image.FromFile(Sreader("rightlogopath").ToString.Trim)
                        e.Graphics.DrawImage(ImageValue, CSng(Sreader("rightlogoleft")), CSng(Sreader("rightlogotop")), CSng(Sreader("rightlogowidth")), CSng(Sreader("rightlogoheight")))
                    End If
                Catch ex As Exception

                End Try
            End While
            Sreader.Close()
            Sreader = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn2.Close()
            SqlConn2.Dispose()
            SQLFcmd.Connection = Nothing
        End Try



        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from PrintLables where schemename=N'" & PrintingScheme & "' and IsVisible='True'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
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


                If CSng(Sreader("width")) > 50 Then
                    Dim rect1 As New Rectangle(CSng(Sreader("fleft")), CSng(Sreader("ftop")), CSng(Sreader("width")), CSng(Sreader("height")))
                    e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, rect1, drawFormat)
                Else
                    e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                End If
                drawFont.Dispose()
                drawBrush.Dispose()
                drawFormat.Dispose()

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


        Dim SqlConn0 As New SqlClient.SqlConnection
        Try
            SqlConn0.ConnectionString = ConnectionStrinG
            SqlConn0.Open()
            SQLFcmd.Connection = SqlConn0
            SQLFcmd.CommandText = "select * from printheadings where schemename=N'" & PrintingScheme & "' and IsVisible='True'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
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
                e.Graphics.DrawString(Sreader("HeadText").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                drawFont.Dispose()
                drawBrush.Dispose()
                drawFormat.Dispose()
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn0.Close()
            SqlConn0.Dispose()
            SQLFcmd.Connection = Nothing
        End Try






        Dim SqlConn3 As New SqlClient.SqlConnection
        Try
            SqlConn3.ConnectionString = ConnectionStrinG
            SqlConn3.Open()
            SQLFcmd.Connection = SqlConn3
            SQLFcmd.CommandText = "select * from printlines where schemename=N'" & PrintingScheme & "' and IsVisible='True'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
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
                If Sreader("FieldType") = 0 Then
                    e.Graphics.DrawLine(penstyle, CSng(Sreader("fleft")), CSng(Sreader("ftop")), CSng(Sreader("width")), CSng(Sreader("height")))
                Else
                    e.Graphics.DrawRectangle(penstyle, CSng(Sreader("fleft")), CSng(Sreader("ftop")), CSng(Sreader("width")), CSng(Sreader("height")))
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


        


        Dim SqlConn5 As New SqlClient.SqlConnection
        Try
            SqlConn5.ConnectionString = ConnectionStrinG
            SqlConn5.Open()
            SQLFcmd.Connection = SqlConn5
            SQLFcmd.CommandText = "select * from Printrecords where schemename=N'" & PrintingScheme & "' and IsVisible='True'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                Dim drawFormat As New StringFormat
                Dim drawFont As Font = New Font("arial", 10)
                Dim drawBrush As New SolidBrush(Color.FromName(Sreader("lfontcolor").ToString.Trim))

                Select Case Sreader("lfontstyle")
                    Case 1
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold)
                    Case 2
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Italic)
                    Case 3
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Underline)
                    Case 4
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Italic)
                    Case 5
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Underline)
                    Case 6
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Italic Or FontStyle.Underline)
                    Case 7
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                    Case 8
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Regular)

                End Select


                If Sreader("lalign").ToString.Trim = "Left" Then
                    drawFormat.Alignment = StringAlignment.Near
                ElseIf Sreader("lalign").ToString.Trim = "Right" Then
                    drawFormat.Alignment = StringAlignment.Far
                Else
                    drawFormat.Alignment = StringAlignment.Center
                End If
                e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("lleft")), CSng(Sreader("ltop")), drawFormat)
                drawFont.Dispose()
                drawBrush.Dispose()
                drawFormat.Dispose()
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn5.Close()
            SqlConn5.Dispose()
            SQLFcmd.Connection = Nothing
        End Try




        'haha

        Dim flag2 As Boolean = False
        Dim INCRESEHEIGHT As Single = 0
        While PageTop + RowHeight <= FooterTop
            Try
                Dim k As String = PrtData.Tables(0).Rows(RowNo).Item("stockname").ToString

            Catch ex As Exception
                GoTo SSS
            End Try
            flag2 = False
            INCRESEHEIGHT = 0
            Dim SqlConn6 As New SqlClient.SqlConnection
            Try
                SqlConn6.ConnectionString = ConnectionStrinG
                SqlConn6.Open()
                SQLFcmd.Connection = SqlConn6
                SQLFcmd.CommandText = "select * from Printrecords where schemename=N'" & PrintingScheme & "' and IsVisible='True'"
                SQLFcmd.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd.ExecuteReader
                While Sreader.Read()
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
                    If UCase(Sreader("DBField").ToString.Trim) <> "SNO" Then
                        If Sreader("formattype") = 0 Then
                            If CSng(Sreader("width")) > 20 Then
                                Dim ht As Single = 0
                                ht = RowHeight ' RowHeight
                                Dim StringSize As New SizeF
                                StringSize = e.Graphics.MeasureString(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, drawFont)
                                Dim rect1 As New Rectangle(CSng(Sreader("fleft")), PageTop, CSng(Sreader("width")), ht)
                                If StringSize.Width > CSng(Sreader("width")) Then
                                    If StringSize.Width / CSng(Sreader("width")) > INCRESEHEIGHT Then
                                        INCRESEHEIGHT = StringSize.Width / CSng(Sreader("width"))
                                    End If
                                    ht = CSng(ht + RowHeight * INCRESEHEIGHT)
                                    rect1.Height = ht
                                    flag2 = True
                                End If

                                e.Graphics.DrawString(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, drawFont, drawBrush, rect1, drawFormat)
                            Else
                                e.Graphics.DrawString(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                            End If

                        Else
                            If Sreader("DBtype") = 3 Then
                                Dim vAL As String = ""
                                vAL = SQLGetStringFieldValue("SELECT " & Sreader("Formulastr").ToString.Trim & " AS TOT FROM " & Dbitemsname & " WHERE  TRANSCODE=" & PrtData.Tables(0).Rows(RowNo).Item("TRANSCODE") & " AND SNO=" & PrtData.Tables(0).Rows(RowNo).Item("SNO"), "TOT", "", False)
                                If vAL.Length = 0 Then
                                    vAL = SQLGetStringFieldValue(Sreader("Formulastr").ToString.Trim & " WHERE  TRANSCODE=" & PrtData.Tables(0).Rows(RowNo).Item("TRANSCODE") & " AND SNO=" & PrtData.Tables(0).Rows(RowNo).Item("SNO"), "TOT", "", False)
                                End If
                                If IsNumeric(vAL) = True Then
                                    If CDbl(vAL) <> 0 Then
                                        Try
                                            e.Graphics.DrawString(FormatNumber(vAL, Sreader("decimals")).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                                        Catch ex As Exception

                                        End Try
                                    Else
                                        If Sreader("supress") = 0 Then
                                            Try
                                                e.Graphics.DrawString(FormatNumber(vAL, Sreader("decimals")).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                                            Catch ex As Exception

                                            End Try
                                        End If
                                    End If

                                Else
                                    Try
                                        e.Graphics.DrawString(vAL, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                                    Catch ex As Exception

                                    End Try
                                End If
                            Else
                                If CDbl(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField"))) <> 0 Then
                                    e.Graphics.DrawString(FormatNumber(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, Sreader("decimals")).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                                Else
                                    If Sreader("supress") = 0 Then
                                        e.Graphics.DrawString(FormatNumber(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, Sreader("decimals")).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                                    End If
                                End If
                            End If

                            '  e.Graphics.DrawString(FormatNumber(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, Sreader("decimals")).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                           
                        End If
                    Else
                        e.Graphics.DrawString(PresentRecords, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                    End If
                        drawBrush.Dispose()
                        drawFont.Dispose()
                        drawFormat.Dispose()
                End While
                Sreader.Close()
                Sreader = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SqlConn6.Close()
                SqlConn6.Dispose()
                SQLFcmd.Connection = Nothing
            End Try
            If flag2 = True Then
                PageTop = PageTop + RowHeight * INCRESEHEIGHT
                flag2 = False
            End If
            Try
                PageTotal = PageTotal + PrtData.Tables(0).Rows(RowNo).Item("StockAmount").ToString
                PageTop = PageTop + RowHeight
                RowNo = RowNo + 1
                PresentRecords = PresentRecords + 1
            Catch ex As Exception
                PresentRecords = PrtData.Tables(0).Rows.Count
                GoTo sss
            End Try
        End While





SSS:
        Dim SqlStr1 As String = ""
        Dim lEDGERnAME As String = ""
        lEDGERnAME = SQLGetStringFieldValue("select LEDGERNAME from " & dbname & " where transcode=" & Transcode, "LEDGERNAME")
        If PresentRecords >= PrtData.Tables(0).Rows.Count And RowNo >= PrtData.Tables(0).Rows.Count Then
            SqlStr1 = "select * from PrintFieldLabels where schemename=N'" & PrintingScheme & "'"
        Else

            SqlStr1 = "select * from PrintFieldLabels where schemename=N'" & PrintingScheme & "' and ltop<" & FooterTop
        End If

        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            SQLFcmd.Connection = SqlConn1
            SQLFcmd.CommandText = SqlStr1
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                If Sreader("DBField").ToString.ToUpper = "CurrentBalance".ToUpper Then
                    If SQLIsFieldExists("select ledgername from ledgers where ledgername=N'" & lEDGERnAME & "' and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CashAccounts & "')") = False Then
                        ExecuteSQLQuery("UPDATE PrintFieldLabels SET PRINTTEXT=N'" & GetCurrentBalanceText(lEDGERnAME) & "' where schemename=N'" & PrintingScheme & "' and dbfield=N'" & Sreader("dbfield").ToString.Trim & "'")
                    End If
                Else
                    Try
                        If Sreader("databasevalue") = 1 Then
                            If Sreader("DbType") <> 3 Then
                                ExecuteSQLQuery("UPDATE PrintFieldLabels SET PRINTTEXT=N'" & SQLGetStringFieldValue("select * from ledgers where ledgername=N'" & lEDGERnAME & "'", Sreader("dbfield").ToString.Trim) & "' where schemename=N'" & PrintingScheme & "' and dbfield=N'" & Sreader("dbfield").ToString.Trim & "'")
                            End If

                            

                        ElseIf Sreader("dbfield") = "TransDate" Then
                           
                            ExecuteSQLQuery("UPDATE PrintFieldLabels SET PRINTTEXT=N'" & SQLGetStringFieldValue("select CONVERT(VARCHAR(10),transdate," & DateFormatConversionNumber & ") as ds from " & dbname & " where transcode=" & Transcode, "ds") & "' where schemename=N'" & PrintingScheme & "' and dbfield=N'" & Sreader("dbfield").ToString.Trim & "'")
                        Else
                            If Sreader("DbType") <> 3 Then
                                ExecuteSQLQuery("UPDATE PrintFieldLabels SET PRINTTEXT=N'" & SQLGetStringFieldValue("select * from " & dbname & " where transcode=" & Transcode, Sreader("dbfield").ToString.Trim) & "' where schemename=N'" & PrintingScheme & "' and dbfield=N'" & Sreader("dbfield").ToString.Trim & "'")
                            End If

                        End If
                    Catch ex As Exception

                    End Try
                End If
               

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
            SqlConn1.Dispose()
            SQLFcmd.Connection = Nothing
        End Try


        Dim SqlStr2 As String = ""
        If PresentRecords >= PrtData.Tables(0).Rows.Count And RowNo >= PrtData.Tables(0).Rows.Count Then

            SqlStr2 = "select * from PrintFieldLabels where schemename=N'" & PrintingScheme & "' and IsVisible='True' "
        Else
            SqlStr2 = "select * from PrintFieldLabels where schemename=N'" & PrintingScheme & "' and IsVisible='True' and ltop<" & FooterTop
        End If

        Dim SqlConn4 As New SqlClient.SqlConnection
        Try
            SqlConn4.ConnectionString = ConnectionStrinG
            SqlConn4.Open()
            SQLFcmd.Connection = SqlConn4
            SQLFcmd.CommandText = SqlStr2
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
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
                If Sreader("DBtype") = 3 Then
                    Dim vAL As String = ""
                    vAL = SQLGetStringFieldValue("SELECT " & Sreader("Formulastr").ToString.Trim & " AS TOT FROM " & dbname & " WHERE  TRANSCODE=" & Transcode, "TOT", "", False)
                    If vAL.Length = 0 Then
                        vAL = SQLGetStringFieldValue(Sreader("Formulastr").ToString.Trim & " WHERE  TRANSCODE=" & Transcode, "TOT", "", False)
                    End If
                    If IsNumeric(vAL) = True Then
                        If CDbl(vAL) <> 0 Then
                            Try
                                Try
                                    e.Graphics.DrawString(FormatNumber(vAL, Sreader("decimals")).ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                                Catch ex As Exception
                                    e.Graphics.DrawString(vAL, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                                End Try

                            Catch ex As Exception

                            End Try
                        Else
                            If Sreader("supress") = 0 Then
                                Try
                                    e.Graphics.DrawString(FormatNumber(vAL, Sreader("decimals")).ToString.Trim, drawFont, drawBrush, CSng(Sreader("lleft")), CSng(Sreader("ltop")), drawFormat)
                                Catch ex As Exception

                                End Try
                            End If
                        End If

                    Else
                        Try
                            e.Graphics.DrawString(vAL, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                        Catch ex As Exception

                        End Try
                    End If
                Else
                    If CSng(Sreader("width")) > 50 Then
                        Dim rect1 As New Rectangle(CSng(Sreader("fleft")), CSng(Sreader("ftop")), CSng(Sreader("width")), CSng(Sreader("height")))
                        If Sreader("formattype") = 0 Then
                            e.Graphics.DrawString(Sreader("printtext").ToString.Trim, drawFont, drawBrush, rect1, drawFormat)
                        Else
                            Try
                                e.Graphics.DrawString(FormatNumber(Sreader("printtext"), Sreader("decimals")).ToString.Trim, drawFont, drawBrush, rect1, drawFormat)
                            Catch ex As Exception
                                e.Graphics.DrawString(Sreader("printtext").ToString.Trim, drawFont, drawBrush, rect1, drawFormat)
                            End Try
                        End If
                    Else
                        If Sreader("formattype") = 0 Then
                            e.Graphics.DrawString(Sreader("printtext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                        Else
                            Try
                                e.Graphics.DrawString(FormatNumber(Sreader("printtext"), Sreader("decimals")).ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                            Catch ex As Exception
                                e.Graphics.DrawString(Sreader("printtext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                            End Try
                        End If
                    End If
                End If
               

                Select Case Sreader("lfontstyle")
                    Case 1
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold)
                    Case 2
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Italic)
                    Case 3
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Underline)
                    Case 4
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Italic)
                    Case 5
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Underline)
                    Case 6
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Italic Or FontStyle.Underline)
                    Case 7
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                    Case 8
                        drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Regular)

                End Select


                drawBrush.Color = Color.FromName(Sreader("lfontcolor").ToString.Trim)
                If Sreader("lalign").ToString.Trim = "Left" Then
                    drawFormat.Alignment = StringAlignment.Near
                ElseIf Sreader("lalign").ToString.Trim = "Right" Then
                    drawFormat.Alignment = StringAlignment.Far
                Else
                    drawFormat.Alignment = StringAlignment.Center
                End If
               
                    Try
                        e.Graphics.DrawString(FormatNumber(Sreader("labletext"), Sreader("decimals")).ToString.Trim, drawFont, drawBrush, CSng(Sreader("lleft")), CSng(Sreader("ltop")), drawFormat)
                    Catch ex As Exception
                        e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("lleft")), CSng(Sreader("ltop")), drawFormat)
                    End Try


                drawFormat.Dispose()
                drawFont.Dispose()
                drawBrush.Dispose()

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn4.Close()
            SqlConn4.Dispose()
            SQLFcmd.Connection = Nothing
        End Try




        Dim SqlConn8 As New SqlClient.SqlConnection
        Try
            SqlConn8.ConnectionString = ConnectionStrinG
            SqlConn8.Open()
            SQLFcmd.Connection = SqlConn8
            SQLFcmd.CommandText = "select * from PrintingSettings where schemename=N'" & PrintingScheme & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                If Sreader("showpageno") = True Then
                    If Sreader("pageformat") = 0 Then
                        e.Graphics.DrawString("Page " & PageNo.ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Sreader("pagenoleft")), CSng(Sreader("pagenotop")))
                    Else
                        e.Graphics.DrawString("Page " & PageNo.ToString & " of " & PageNos.ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Sreader("pagenoleft")), CSng(Sreader("pagenotop")))
                    End If
                End If
                If PresentRecords >= PrtData.Tables(0).Rows.Count And RowNo >= PrtData.Tables(0).Rows.Count Then

                Else

                    e.Graphics.DrawString("Page Total= " & FormatNumber(PageTotal, ErpDecimalPlaces).ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Sreader("pagenoleft")), CSng(Sreader("pagenotop")) - 80)
                    e.Graphics.DrawString("Continue........", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Sreader("pagenoleft")), CSng(Sreader("pagenotop")) - 50)
                End If
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn8.Close()
            SqlConn8.Dispose()
            SQLFcmd.Connection = Nothing
        End Try

        Dim SqlConn88 As New SqlClient.SqlConnection
        Try
            SqlConn88.ConnectionString = ConnectionStrinG
            SqlConn88.Open()
            SQLFcmd.Connection = SqlConn88
            SQLFcmd.CommandText = "select * from PrintingSettings where schemename=N'" & PrintingScheme & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                If Sreader("showpageno") = True Then
                    If Sreader("pageformat") = 0 Then
                        e.Graphics.DrawString("Page " & PageNo.ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Sreader("pagenoleft")), CSng(Sreader("pagenotop")))
                    Else
                        e.Graphics.DrawString("Page " & PageNo.ToString & " of " & PageNos.ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Sreader("pagenoleft")), CSng(Sreader("pagenotop")))
                    End If
                End If
                If PresentRecords >= PrtData.Tables(0).Rows.Count And RowNo >= PrtData.Tables(0).Rows.Count Then

                Else
                    If IsshowSubtotal = True Then
                        e.Graphics.DrawString("Page Total= " & FormatNumber(PageTotal, ErpDecimalPlaces).ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Sreader("pagenoleft")), CSng(Sreader("pagenotop")) - 80)
                        e.Graphics.DrawString("Continue........", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, CSng(Sreader("pagenoleft")), CSng(Sreader("pagenotop")) - 50)
                    End If
                   
                End If
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn88.Close()
            SqlConn88.Dispose()
            SQLFcmd.Connection = Nothing
        End Try

        If PresentRecords >= PrtData.Tables(0).Rows.Count And RowNo >= PrtData.Tables(0).Rows.Count Then
            IsFirstOpen = True
            PageTop = 0
            PageSpace = 0
            RowHeight = 0
            PresentRecords = 1
            pagerecords = 1
            PageNo = 1
            PageNos = 1
            If InvCount >= InvoiceList.Items.Count Then
                e.HasMorePages = False
                InvCount = 0
            Else
                TotalPagesPrint = TotalPagesPrint + 1
                e.HasMorePages = True
            End If


            PrtData.Tables(0).Clear()
        Else
            TotalPagesPrint = TotalPagesPrint + 1
            e.HasMorePages = True
            PageNo = PageNo + 1
            PageTop = PageTopConst
        End If


    End Sub

    Sub ChequePrinting(ByRef sender As System.Object, ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal Transcode As Single, ByVal PrintingScheme As String, ByVal PrtValues As ChequePrintValuesStruct)

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
        Static RowNo As Integer = 0
        Dim PageTotal As Double = 0
        Dim AmtLine1 As String = ""
        Dim Amtline2 As String = ""
        Dim NOCHARS As Integer = 50
        e.PageSettings.PrinterSettings.PrinterName = ChequePagesetupValues.PrinterName



        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from chequePrintLables where schemename=N'" & PrintingScheme & "'"
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


                    If CSng(Sreader("width")) > 50 Then
                        Dim rect1 As New Rectangle(CSng(Sreader("fleft")), CSng(Sreader("ftop")), CSng(Sreader("width")), CSng(Sreader("height")))
                        e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, rect1, drawFormat)
                    Else
                        e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                    End If

                    drawFont.Dispose()
                    drawBrush.Dispose()
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








        Dim SqlConn3 As New SqlClient.SqlConnection
        Try
            SqlConn3.ConnectionString = ConnectionStrinG
            SqlConn3.Open()
            SQLFcmd.Connection = SqlConn3
            SQLFcmd.CommandText = "select * from chequeprintlines where schemename=N'" & PrintingScheme & "'"
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
                    If Sreader("FieldType") = 0 Then
                        e.Graphics.DrawLine(penstyle, CSng(Sreader("fleft")), CSng(Sreader("ftop")), CSng(Sreader("width")), CSng(Sreader("height")))
                    Else
                        e.Graphics.DrawRectangle(penstyle, CSng(Sreader("fleft")), CSng(Sreader("ftop")), CSng(Sreader("width")), CSng(Sreader("height")))
                    End If
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

        Dim PrintTextValue As String = ""
        Dim SqlStr2 As String = ""
        SqlStr2 = "select * from chequePrintFieldLabels where schemename=N'" & PrintingScheme & "' "
        Dim SqlConn4 As New SqlClient.SqlConnection
        Try
            SqlConn4.ConnectionString = ConnectionStrinG
            SqlConn4.Open()
            SQLFcmd.Connection = SqlConn4
            SQLFcmd.CommandText = SqlStr2
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
                    ' PRINT CHEQUE VALUES FORM DATABASE OR FROM CHEQUE STRUCTURE VALUES
                    If Sreader("DBFIElD").ToString.Trim = "TransDate" Then
                        PrintTextValue = PrtValues.PrintDate
                    ElseIf Sreader("DBFIElD").ToString.Trim = "LedgerName" Then
                        PrintTextValue = PrtValues.PayeeName
                    ElseIf Sreader("DBFIElD").ToString.Trim = "Amount" Then
                        PrintTextValue = FormatNumber(PrtValues.Amount, ErpDecimalPlaces)
                    ElseIf Sreader("DBFIElD").ToString.Trim = "AmountLine1" Then
                        Dim nochar As Integer = 3
                        If drawFont.SizeInPoints < 12 Then
                            nochar = 10
                        ElseIf drawFont.SizeInPoints = 12 Then
                            nochar = 8
                        ElseIf drawFont.SizeInPoints = 14 Then
                            nochar = 7
                        ElseIf drawFont.SizeInPoints = 16 Then
                            nochar = 6
                        ElseIf drawFont.SizeInPoints = 18 Then
                            nochar = 5
                        Else
                            nochar = 3
                        End If
                        NOCHARS = nochar * CSng(Sreader("width")) / 100
                        If NOCHARS < 10 Then
                            NOCHARS = 50
                        End If
                        If PrtValues.AmountinWords.Length < NOCHARS Then
                            AmtLine1 = PrtValues.AmountinWords
                            Amtline2 = ""
                        Else
                            Dim x As Integer
                            x = PrtValues.AmountinWords.Substring(0, NOCHARS).LastIndexOf(" ")
                            Dim r As String
                            r = PrtValues.AmountinWords.Substring(0, x)
                            AmtLine1 = r
                            Amtline2 = PrtValues.AmountinWords.Substring(x, PrtValues.AmountinWords.Length - x)
                        End If
                        PrintTextValue = AmtLine1

                    Else
                        PrintTextValue = Amtline2
                    End If
                    If CSng(Sreader("width")) > 30 Then
                        Dim rect1 As New Rectangle(CSng(Sreader("fleft")), CSng(Sreader("ftop")), CSng(Sreader("width")), CSng(Sreader("height")))
                        e.Graphics.DrawString(PrintTextValue, drawFont, drawBrush, rect1, drawFormat)
                    Else
                        e.Graphics.DrawString(PrintTextValue, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                    End If

                    Select Case Sreader("lfontstyle")
                        Case 1
                            drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold)
                        Case 2
                            drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Italic)
                        Case 3
                            drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Underline)
                        Case 4
                            drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Italic)
                        Case 5
                            drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Underline)
                        Case 6
                            drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Italic Or FontStyle.Underline)
                        Case 7
                            drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                        Case 8
                            drawFont = New Font(Sreader("lFontname").ToString.Trim, CSng(Sreader("lfontsize")), FontStyle.Regular)

                    End Select


                    drawBrush.Color = Color.FromName(Sreader("lfontcolor").ToString.Trim)
                    If Sreader("lalign").ToString.Trim = "Left" Then
                        drawFormat.Alignment = StringAlignment.Near
                    ElseIf Sreader("lalign").ToString.Trim = "Right" Then
                        drawFormat.Alignment = StringAlignment.Far
                    Else
                        drawFormat.Alignment = StringAlignment.Center
                    End If
                    e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("lleft")), CSng(Sreader("ltop")), drawFormat)
                    drawFont.Dispose()
                    drawBrush.Dispose()
                    drawFormat.Dispose()
                End If
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn4.Close()
            SqlConn4.Dispose()
            SQLFcmd.Connection = Nothing
        End Try




        PageTop = 0
        PageSpace = 0
        RowHeight = 0
        PresentRecords = 1
        pagerecords = 1
        PageNo = 1
        PageNos = 1
        e.HasMorePages = False



    End Sub
    Public Sub PrintVoucher(ByVal sender As Form, ByVal tcode As Double, ByVal Vhtype As VoucherType, ByVal noofcopies As Integer, Optional ByVal PrintToPrinter As Boolean = False, Optional ByVal vhprintername As String = "", Optional ByVal IsDuplicate As Boolean = False)
        MainForm.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()

        Dim dscmd As New SqlDataAdapter("select * from ledgerbook where transcode=" & tcode, cnn)
        dscmd.Fill(ds, "Ledgerbook")
        cnn.Close()
        Dim nettotal As Double = 0
        Dim VoucherName As String = ""
        nettotal = SQLGetNumericFieldValue("select sum(dr) as tot from ledgerbook where transcode=" & tcode, "tot")
        If Vhtype = VoucherType.SalesVoucher Then
            VoucherName = "SALES VOUCHER"
        ElseIf Vhtype = VoucherType.SalesReturnVoucher Then
            VoucherName = "CREDIT NOTE"
        ElseIf Vhtype = VoucherType.PurchaseVoucher Then
            VoucherName = "PURCHASE VOUCHER"
        ElseIf Vhtype = VoucherType.PurchaseRetVoucher Then
            VoucherName = "DEBIT NOTE"
        ElseIf Vhtype = VoucherType.Payment Then
            VoucherName = "PAYMENT"
        ElseIf Vhtype = VoucherType.Receipt Then
            VoucherName = "RECEIPT"
        ElseIf Vhtype = VoucherType.journal Then
            VoucherName = "JOURNAL"
        ElseIf Vhtype = VoucherType.Contra Then
            VoucherName = "CONTRA"

        End If


        Dim objRpt As New PaymentVoucherTableCRReport
        Try
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)

            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = VoucherName
            CType(objRpt.Section5.ReportObjects.Item("txtwords"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = CompDetails.Currency & " " & GetInWords(nettotal)
            If IsDuplicate = True Then
                CType(objRpt.Section1.ReportObjects.Item("TxtVhTitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "COPY"
            Else
                CType(objRpt.Section1.ReportObjects.Item("TxtVhTitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "ORIGINAL"
            End If
        Catch ex As Exception

        End Try
        objRpt.SetDataSource(ds)
        If vhprintername.Length > 0 Then
            Try
                objRpt.PrintOptions.PrinterName = vhprintername
            Catch ex As Exception

            End Try
        End If
        Dim FRM As New ReportCommonForm(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        MainForm.Cursor = Cursors.Default

        If PrintToPrinter = True Then
            FRM.LoadReport()
            objRpt.PrintToPrinter(1, False, 1, 1)
        Else
            FRM.ShowDialog()
        End If
        FRM.Dispose()
    End Sub
    Public Sub SendVoucherToEmail(ByVal tcode As Double)
        MainForm.Cursor = Cursors.WaitCursor
        Dim CustEmailValues As New CustEmailValuesStruct
        'READING DATA FROM THE LEDGERBOOK
        Dim SqlConn As New SqlClient.SqlConnection
        Dim iNVOICEnAME As String = ""
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from ledgerbook where transcode=" & tcode & " AND SNO=1"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                CustEmailValues.EmailID = SQLGetStringFieldValue("SELECT emailid FROM LEDGERS WHERE LEDGERNAME=N'" & Sreader("LEDGERNAME") & "'", "emailid")
                CustEmailValues.CURRENTAMOUNT = Sreader("DR") + Sreader("CR")
                CustEmailValues.INVOICEDATE = Sreader("TransDate")
                CustEmailValues.INVOICENO = Sreader("INVOICENO")
                CustEmailValues.PARTYNAME = Sreader("LEDGERNAME")
                CustEmailValues.PAYMENTBY = ""
                CustEmailValues.TODAYDATE = Today
                CustEmailValues.BALANCE = GetCurrentBalanceText(Sreader("LEDGERNAME"))
                CustEmailValues.attachfilename = Path.GetTempPath() & Sreader("LEDGERNAME") & "Vouchno-" & Sreader("INVOICENO") & Sreader("TransDateValue") & ".PDF"
                iNVOICEnAME = UCase(Sreader("INVOICENAME"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try


        Dim TempStr As New TextBox
        Dim EmailSubject As String = ""
        TempStr.Multiline = True
        If iNVOICEnAME = "PAYMENT" Then
            TempStr.Text = SQLGetStringFieldValue(" select msgtext from smsmailsettings where vouchername='PAYMENT'  and IsEmail='True' ", "msgtext")
            EmailSubject = SQLGetStringFieldValue(" select mailSubject from smsmailsettings where vouchername='PAYMENT'  and IsEmail='True' ", "mailSubject")
        ElseIf iNVOICEnAME = "CONTRA" Then
            TempStr.Text = SQLGetStringFieldValue(" select msgtext from smsmailsettings where vouchername='CONTRA'  and IsEmail='True' ", "msgtext")
            EmailSubject = SQLGetStringFieldValue(" select mailSubject from smsmailsettings where vouchername='CONTRA'  and IsEmail='True' ", "mailSubject")
        ElseIf iNVOICEnAME = "JOURNAL" Then
            TempStr.Text = SQLGetStringFieldValue(" select msgtext from smsmailsettings where vouchername='JOURNAL'  and IsEmail='True' ", "msgtext")
            EmailSubject = SQLGetStringFieldValue(" select mailSubject from smsmailsettings where vouchername='JOURNAL'  and IsEmail='True' ", "mailSubject")
        ElseIf iNVOICEnAME = "RECEIPT" Then
            TempStr.Text = SQLGetStringFieldValue(" select msgtext from smsmailsettings where vouchername='RECEIPT'  and IsEmail='True' ", "msgtext")
            EmailSubject = SQLGetStringFieldValue(" select mailSubject from smsmailsettings where vouchername='RECEIPT'  and IsEmail='True' ", "mailSubject")
        End If
        TempStr.Text = TempStr.Text.Replace("@TODAYDATE@", Today)
        TempStr.Text = TempStr.Text.Replace("@INVOICENO@", CustEmailValues.INVOICENO)
        TempStr.Text = TempStr.Text.Replace("@INVOICEDATE@", CustEmailValues.INVOICEDATE)
        TempStr.Text = TempStr.Text.Replace("@PARTYNAME@", CustEmailValues.PARTYNAME)
        TempStr.Text = TempStr.Text.Replace("@CURRENTAMOUNT@", CustEmailValues.CURRENTAMOUNT)
        TempStr.Text = TempStr.Text.Replace("@INVOICEBALANCE@", CustEmailValues.CURRENTAMOUNT)
        TempStr.Text = TempStr.Text.Replace("@PAYMENTBY@", "")
        TempStr.Text = TempStr.Text.Replace("@BALANCE@", CustEmailValues.BALANCE)



        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("select * from ledgerbook where transcode=" & tcode, cnn)
        dscmd.Fill(ds, "Ledgerbook")
        cnn.Close()
        Dim nettotal As Double = 0
        Dim VoucherName As String = ""
        nettotal = SQLGetNumericFieldValue("select sum(dr) as tot from ledgerbook where transcode=" & tcode, "tot")

        Dim objRpt As New PaymentVoucherTableCRReport
        CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
        CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)

        CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = VoucherName
        CType(objRpt.Section5.ReportObjects.Item("txtwords"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = CompDetails.Currency & " " & GetInWords(nettotal)
        CType(objRpt.Section1.ReportObjects.Item("TxtVhTitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "ORIGINAL"
        objRpt.SetDataSource(ds)
        objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, CustEmailValues.attachfilename)
        Dim EmailID As String = SQLGetStringFieldValue("SELECT emailid FROM LEDGERS WHERE LEDGERNAME=N'" & CustEmailValues.PARTYNAME & "'", "emailid")

        If SQLIsFieldExists("SELECT TOP 1 1 from   smsmailsettings WHERE  isattachfile='True' ") = True Then
            SendCustomEmailTo(EmailID, EmailSubject, TempStr.Text, CustEmailValues.attachfilename)
        Else
            SendCustomEmailTo(EmailID, EmailSubject, TempStr.Text, "")
        End If

    End Sub

    Public Sub LoadCrystalReportOptions()
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Dim SQLStr As String = ""
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = "select * from CrReportSettings"
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()
                PrintOptionsforCR.IsPrintHeader = Sreader("HeaderOn")
                PrintOptionsforCR.IsPrintFooter = Sreader("FooterOn")
                PrintOptionsforCR.IsPrintLeftLogo = Sreader("LeftLogoOn")
                PrintOptionsforCR.IsprintRightLogo = Sreader("RightLogoOn")
                PrintOptionsforCR.ispirntPageNumber = Sreader("PrintPageNos")
                PrintOptionsforCR.IsprintCmpAddress = Sreader("PrintAddress")
                PrintOptionsforCR.IsPrintCmpName = Sreader("PrintCompanyName")
                PrintOptionsforCR.IsPrintTitle = Sreader("PrintTitle")
                PrintOptionsforCR.HeaderLogoPath = Sreader("HeaderPath").ToString.Trim
                PrintOptionsforCR.FooterLogoPath = Sreader("FooterPath").ToString.Trim
                PrintOptionsforCR.LeftLogoPath = Sreader("LeftLogoPath").ToString.Trim
                PrintOptionsforCR.RightLogoPath = Sreader("RightLogoPath").ToString.Trim
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

    Public Sub SetReportLogos(ByRef cr As CrystalDecisions.CrystalReports.Engine.ReportObjects, ByVal crd As CrystalDecisions.CrystalReports.Engine.DataDefinition, ByVal f1 As String, ByVal f2 As String, ByVal f3 As String)

        Try
            If PrintOptionsforCR.IsPrintHeader = True Then
                crd.FormulaFields("txtheaderlogo").Text = "formula=""" & PrintOptionsforCR.HeaderLogoPath & """"
                CType(cr.Item("Picture3"), CrystalDecisions.CrystalReports.Engine.PictureObject).ObjectFormat.EnableCanGrow = False
                CType(cr.Item("Picture3"), CrystalDecisions.CrystalReports.Engine.PictureObject).ObjectFormat.EnableSuppress = False
                CType(cr.Item(f1), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ""
                CType(cr.Item(f2), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ""
                CType(cr.Item(f3), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ""
            Else
                CType(cr.Item("Picture3"), CrystalDecisions.CrystalReports.Engine.PictureObject).ObjectFormat.EnableCanGrow = False
                CType(cr.Item("Picture3"), CrystalDecisions.CrystalReports.Engine.PictureObject).ObjectFormat.EnableSuppress = True
            End If


        Catch ex As Exception

        End Try

        Try
            If PrintOptionsforCR.IsPrintLeftLogo = True Then
                crd.FormulaFields("txtleftlogo").Text = "formula=""" & PrintOptionsforCR.LeftLogoPath & """"
                CType(cr.Item("Picture1"), CrystalDecisions.CrystalReports.Engine.PictureObject).ObjectFormat.EnableCanGrow = False
                CType(cr.Item("Picture1"), CrystalDecisions.CrystalReports.Engine.PictureObject).ObjectFormat.EnableSuppress = False
            Else
                CType(cr.Item("Picture1"), CrystalDecisions.CrystalReports.Engine.PictureObject).ObjectFormat.EnableCanGrow = False
                CType(cr.Item("Picture1"), CrystalDecisions.CrystalReports.Engine.PictureObject).ObjectFormat.EnableSuppress = True
            End If


        Catch ex As Exception

        End Try
        Try
            If PrintOptionsforCR.IsprintRightLogo = True Then
                crd.FormulaFields("txtrightlogo").Text = "formula=""" & PrintOptionsforCR.RightLogoPath & """"
                CType(cr.Item("Picture2"), CrystalDecisions.CrystalReports.Engine.PictureObject).ObjectFormat.EnableCanGrow = False
                CType(cr.Item("Picture2"), CrystalDecisions.CrystalReports.Engine.PictureObject).ObjectFormat.EnableSuppress = False
            Else
                CType(cr.Item("Picture2"), CrystalDecisions.CrystalReports.Engine.PictureObject).ObjectFormat.EnableCanGrow = False
                CType(cr.Item("Picture2"), CrystalDecisions.CrystalReports.Engine.PictureObject).ObjectFormat.EnableSuppress = True
            End If
        Catch ex As Exception

        End Try
    End Sub

End Module
