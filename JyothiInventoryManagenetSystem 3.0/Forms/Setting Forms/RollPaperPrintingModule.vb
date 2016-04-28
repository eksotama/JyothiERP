Imports System.Drawing.Printing
Imports System.Drawing.Imaging

Module RollPaperPrintingModule
    Public RollPaperPrintSettings As RollPaperPrintingStructure
    Dim PrtData As New DataSet
    Structure RollPaperPrintingStructure
        Dim PageHeight As Integer
        Dim PageWidht As Integer
        Dim HeaderHeight As Integer
        Dim FooterHeight As Integer
        Dim RowsItemsHeight As Integer
        Dim DefRecordItemHeight As Integer
        Dim PrinterName As String
        Dim SchemeName As String
        Dim RowItemsDatabaseName As String
        Dim MasterDatabaseName As String
        Dim Transcode As Single
        Dim LeftMargin As Integer
        Dim RightMargin As Integer
        Dim TopMargin As Integer
        Dim ButtomMargin As Integer
        Dim FontHeight As Integer
        Dim RecordCount As Integer
        Dim IsSampleData As Boolean
        Dim footertop As Integer
    End Structure
    Private Function MeasuresStringWidht(ByVal StringToFind As String, f As Font) As Single

        Dim b As Bitmap
        Dim g As Graphics


        ' Compute the string dimensions in the given font
        b = New Bitmap(1, 1, PixelFormat.Format32bppArgb)
        g = Graphics.FromImage(b)
        Dim stringSize As SizeF = g.MeasureString(StringToFind, f)
        g.Dispose()
        b.Dispose()
        Return stringSize.Width
    End Function
    Public Sub RollPaperBeginPrint(ByVal sender As Object, ByVal transactioncode As Double, ByVal dbitemsname As String, ByVal dbname As String, ByVal SchemeName As String, Optional ByVal DemoType As Integer = 0)
        RollPaperPrintSettings.Transcode = transactioncode
        RollPaperPrintSettings.MasterDatabaseName = dbname
        RollPaperPrintSettings.RowItemsDatabaseName = dbitemsname
        RollPaperPrintSettings.SchemeName = SchemeName
        RollPaperPrintSettings.PageWidht = SQLGetNumericFieldValue("SELECT width AS VAL FROM printingsettings WHERE schemename=N'" & RollPaperPrintSettings.SchemeName & "'", "VAL")
        RollPaperPrintSettings.HeaderHeight = SQLGetNumericFieldValue("SELECT pagenoleft AS VAL FROM printingsettings WHERE schemename=N'" & RollPaperPrintSettings.SchemeName & "'", "VAL")
        RollPaperPrintSettings.FooterHeight = SQLGetNumericFieldValue("SELECT pagenotop AS VAL FROM printingsettings WHERE schemename=N'" & RollPaperPrintSettings.SchemeName & "'", "VAL")
        RollPaperPrintSettings.DefRecordItemHeight = SQLGetNumericFieldValue("SELECT height AS VAL FROM printingsettings WHERE schemename=N'" & RollPaperPrintSettings.SchemeName & "'", "VAL")
        RollPaperPrintSettings.RowsItemsHeight = SQLGetNumericFieldValue("SELECT fTop AS VAL FROM printrecords WHERE schemename=N'" & RollPaperPrintSettings.SchemeName & "'", "VAL")
        'printrecords
        RollPaperPrintSettings.LeftMargin = SQLGetNumericFieldValue("SELECT fleft AS VAL FROM printingsettings WHERE schemename=N'" & RollPaperPrintSettings.SchemeName & "'", "VAL")
        RollPaperPrintSettings.RightMargin = SQLGetNumericFieldValue("SELECT fright AS VAL FROM printingsettings WHERE schemename=N'" & RollPaperPrintSettings.SchemeName & "'", "VAL")
        RollPaperPrintSettings.TopMargin = SQLGetNumericFieldValue("SELECT ftop AS VAL FROM printingsettings WHERE schemename=N'" & RollPaperPrintSettings.SchemeName & "'", "VAL")
        RollPaperPrintSettings.ButtomMargin = SQLGetNumericFieldValue("SELECT fbuttom AS VAL FROM printingsettings WHERE schemename=N'" & RollPaperPrintSettings.SchemeName & "'", "VAL")
        RollPaperPrintSettings.FontHeight = SQLGetNumericFieldValue("SELECT rowheight AS VAL FROM printingsettings WHERE schemename=N'" & RollPaperPrintSettings.SchemeName & "'", "VAL")
        RollPaperPrintSettings.PrinterName = SQLGetStringFieldValue("SELECT printername AS VAL FROM printingsettings WHERE schemename=N'" & RollPaperPrintSettings.SchemeName & "'", "VAL")
        If DemoType = 0 Then
            RollPaperPrintSettings.RecordCount = SQLGetNumericFieldValue("SELECT COUNT(*) AS TOT FROM " & dbitemsname & " WHERE TRANSCODE=" & transactioncode, "TOT")
            RollPaperPrintSettings.IsSampleData = False
        ElseIf DemoType = 1 Then
            RollPaperPrintSettings.RecordCount = 1
            RollPaperPrintSettings.IsSampleData = True
        End If
        ' RollPaperPrintSettings.RowsItemsHeight = RollPaperPrintSettings.PageHeight + RollPaperPrintSettings.FontHeight
        FillDataset(PrtData, "select * from  " & RollPaperPrintSettings.RowItemsDatabaseName & " where transcode=" & RollPaperPrintSettings.Transcode)
        'FINDING EXTRA PAPER HEIGHT
        Dim ExtraPageHeight As Single = 0
        Dim flag2 As Boolean = False
        '& "' and ( height<" & RollPaperPrintSettings.HeaderHeight & " or height> " & RollPaperPrintSettings.footertop & ")"
        For ri As Integer = 0 To RollPaperPrintSettings.RecordCount - 1
            Dim SqlConn6 As New SqlClient.SqlConnection

            Dim SIZETOINCRESE As Integer = 0
            Try
                SqlConn6.ConnectionString = ConnectionStrinG
                SqlConn6.Open()
                SQLFcmd.Connection = SqlConn6
                SQLFcmd.CommandText = "select * from Printrecords where schemename=N'" & RollPaperPrintSettings.SchemeName & "'"
                SQLFcmd.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd.ExecuteReader
                While Sreader.Read()
                    If Sreader("IsVisible") = True Then

                        Dim drawFont As Font = New Font("arial", 10)
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

                        If UCase(Sreader("DBField").ToString.Trim) <> "SNO" Then
                            'need to
                            If Sreader("formattype") = 0 Then
                                If CSng(Sreader("width")) > 20 Then
                                    Dim StringSize As Single = 0
                                    StringSize = MeasuresStringWidht(PrtData.Tables(0).Rows(ri).Item(Sreader("DBField").ToString.Trim).ToString, drawFont)
                                    If StringSize > CSng(Sreader("width")) Then
                                        If StringSize / CSng(Sreader("WIDTH")) > SIZETOINCRESE Then
                                            SIZETOINCRESE = StringSize / CSng(Sreader("WIDTH"))
                                        End If
                                    End If
                                End If
                            End If


                        End If

                        drawFont.Dispose()

                    End If
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
           ExtraPageHeight = ExtraPageHeight + RollPaperPrintSettings.FontHeight * SIZETOINCRESE
            SIZETOINCRESE = 0
        Next

        If DemoType = 1 Then
            RollPaperPrintSettings.PageHeight = RollPaperPrintSettings.HeaderHeight + RollPaperPrintSettings.FooterHeight + RollPaperPrintSettings.FontHeight * RollPaperPrintSettings.RecordCount + RollPaperPrintSettings.DefRecordItemHeight
            RollPaperPrintSettings.footertop = RollPaperPrintSettings.HeaderHeight + RollPaperPrintSettings.FontHeight * RollPaperPrintSettings.RecordCount '+ RollPaperPrintSettings.RowsItemsHeight
        Else
            RollPaperPrintSettings.PageHeight = RollPaperPrintSettings.HeaderHeight + RollPaperPrintSettings.FooterHeight + RollPaperPrintSettings.FontHeight * RollPaperPrintSettings.RecordCount + RollPaperPrintSettings.DefRecordItemHeight + ExtraPageHeight
            RollPaperPrintSettings.footertop = RollPaperPrintSettings.HeaderHeight + RollPaperPrintSettings.FontHeight * RollPaperPrintSettings.RecordCount '+ RollPaperPrintSettings.RowsItemsHeight
        End If

    End Sub
    Sub RollPaperPrinting(ByRef sender As System.Object, ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByRef prtdoc As Printing.PrintDocument, Optional ByVal IsFullView As Boolean = True, Optional ByVal IsPrintFormPreview As Boolean = False)
        Dim RowNo As Integer = 0
        Dim PageTop As Double = 0
        If RollPaperPrintSettings.PrinterName.Length > 0 Then
            If RollPaperPrintingSettingsForm.TxtPrinterName.Items.Contains(RollPaperPrintSettings.PrinterName) = True Then
                e.PageSettings.PrinterSettings.PrinterName = PagesetupValues.PrinterName
            End If
        End If


        'HEADER PRINTING


        Dim ImageValue As System.Drawing.Image
        Dim SqlConn2 As New SqlClient.SqlConnection
        Try
            SqlConn2.ConnectionString = ConnectionStrinG
            SqlConn2.Open()
            SQLFcmd.Connection = SqlConn2
            SQLFcmd.CommandText = "select * from printingsettings where schemename=N'" & RollPaperPrintSettings.SchemeName & "' and leftlogotop<=" & RollPaperPrintSettings.HeaderHeight
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
        If IsPrintFormPreview = False Then
            Dim SqlStr1 As String = ""
            Dim lEDGERnAME As String = ""
            lEDGERnAME = SQLGetStringFieldValue("select ledgername from " & RollPaperPrintSettings.MasterDatabaseName & " where transcode=" & RollPaperPrintSettings.Transcode, "ledgername")
            SqlStr1 = "select * from PrintFieldLabels where schemename=N'" & RollPaperPrintSettings.SchemeName & "'"
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
                            ExecuteSQLQuery("UPDATE PrintFieldLabels SET PRINTTEXT=N'" & GetCurrentBalanceText(lEDGERnAME) & "' where schemename=N'" & RollPaperPrintSettings.SchemeName & "' and dbfield=N'" & Sreader("dbfield").ToString.Trim & "'")
                        End If
                    Else
                        Try
                            If Sreader("databasevalue") = 1 Then
                                ExecuteSQLQuery("UPDATE PrintFieldLabels SET PRINTTEXT=N'" & SQLGetStringFieldValue("select * from ledgers where ledgername=N'" & lEDGERnAME & "'", Sreader("dbfield").ToString.Trim) & "' where schemename=N'" & RollPaperPrintSettings.SchemeName & "' and dbfield=N'" & Sreader("dbfield").ToString.Trim & "'")
                            ElseIf Sreader("dbfield") = "TransDate" Then
                                'CONVERT(VARCHAR(10),GETDATE(),111)
                                ExecuteSQLQuery("UPDATE PrintFieldLabels SET PRINTTEXT=N'" & SQLGetStringFieldValue("select CONVERT(VARCHAR(10),transdate," & DateFormatConversionNumber & ") as ds from " & RollPaperPrintSettings.MasterDatabaseName & " where transcode=" & RollPaperPrintSettings.Transcode, "ds") & "' where schemename=N'" & RollPaperPrintSettings.SchemeName & "' and dbfield=N'" & Sreader("dbfield").ToString.Trim & "'")
                            Else
                                If Sreader("DBtype") = 3 Then
                                    Dim vAL As String = ""
                                    vAL = SQLGetStringFieldValue("SELECT " & Sreader("Formulastr").ToString.Trim & " AS TOT FROM " & RollPaperPrintSettings.MasterDatabaseName & " WHERE  TRANSCODE=" & RollPaperPrintSettings.Transcode, "TOT", "", False)
                                    If vAL.Length = 0 Then
                                        vAL = SQLGetStringFieldValue(Sreader("Formulastr").ToString.Trim & " WHERE  TRANSCODE=" & RollPaperPrintSettings.Transcode, "TOT", "", False)
                                    End If
                                    ExecuteSQLQuery("UPDATE PrintFieldLabels SET PRINTTEXT=N'" & vAL & "' where schemename=N'" & RollPaperPrintSettings.SchemeName & "' and dbfield=N'" & Sreader("dbfield").ToString.Trim & "'")
                                Else
                                    ExecuteSQLQuery("UPDATE PrintFieldLabels SET PRINTTEXT=N'" & SQLGetStringFieldValue("select * from " & RollPaperPrintSettings.MasterDatabaseName & " where transcode=" & RollPaperPrintSettings.Transcode, Sreader("dbfield").ToString.Trim) & "' where schemename=N'" & RollPaperPrintSettings.SchemeName & "' and dbfield=N'" & Sreader("dbfield").ToString.Trim & "'")
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

        End If



        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from PrintLables where schemename=N'" & RollPaperPrintSettings.SchemeName & "' and  ftop<" & RollPaperPrintSettings.HeaderHeight
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


        Dim SqlConn0 As New SqlClient.SqlConnection
        Try
            SqlConn0.ConnectionString = ConnectionStrinG
            SqlConn0.Open()
            SQLFcmd.Connection = SqlConn0
            SQLFcmd.CommandText = "select * from printheadings where schemename=N'" & RollPaperPrintSettings.SchemeName & "' and  ftop<" & RollPaperPrintSettings.HeaderHeight
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
                    e.Graphics.DrawString(Sreader("HeadText").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
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
            SqlConn0.Close()
            SqlConn0.Dispose()
            SQLFcmd.Connection = Nothing
        End Try






        Dim SqlConn3 As New SqlClient.SqlConnection
        Try
            SqlConn3.ConnectionString = ConnectionStrinG
            SqlConn3.Open()
            SQLFcmd.Connection = SqlConn3
            SQLFcmd.CommandText = "select * from printlines where schemename=N'" & RollPaperPrintSettings.SchemeName & "' and  ftop<=" & RollPaperPrintSettings.HeaderHeight + RollPaperPrintSettings.DefRecordItemHeight
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

        PageTop = RollPaperPrintSettings.RowsItemsHeight + 10


        '& "' and ( height<" & RollPaperPrintSettings.HeaderHeight & " or height> " & RollPaperPrintSettings.footertop & ")"
        Dim SqlStr2 As String = ""

        SqlStr2 = "select * from PrintFieldLabels where schemename=N'" & RollPaperPrintSettings.SchemeName & "' and ftop<" & RollPaperPrintSettings.HeaderHeight
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

                    If CSng(Sreader("width")) > 50 Then
                        Dim rect1 As New Rectangle(CSng(Sreader("fleft")), CSng(Sreader("ftop")), CSng(Sreader("width")), CSng(Sreader("height")))
                        If Sreader("formattype") = 0 Then
                            e.Graphics.DrawString(Sreader("printtext").ToString.Trim, drawFont, drawBrush, rect1, drawFormat)
                        Else
                            e.Graphics.DrawString(FormatNumber(Sreader("printtext"), ErpDecimalPlaces).ToString.Trim, drawFont, drawBrush, rect1, drawFormat)
                        End If
                    Else
                        If Sreader("formattype") = 0 Then
                            e.Graphics.DrawString(Sreader("printtext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                        Else
                            Try
                                e.Graphics.DrawString(FormatNumber(Sreader("printtext"), ErpDecimalPlaces).ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                            Catch ex As Exception
                                e.Graphics.DrawString(Sreader("printtext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")), drawFormat)
                            End Try
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
                    e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("lleft")), CSng(Sreader("ltop")), drawFormat)
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
            SqlConn4.Close()
            SqlConn4.Dispose()
            SQLFcmd.Connection = Nothing
        End Try


        Dim SqlConn5 As New SqlClient.SqlConnection
        Try
            SqlConn5.ConnectionString = ConnectionStrinG
            SqlConn5.Open()
            SQLFcmd.Connection = SqlConn5
            SQLFcmd.CommandText = "select * from Printrecords where schemename=N'" & RollPaperPrintSettings.SchemeName & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                If Sreader("IsVisible") = True Then
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
                    drawBrush.Dispose()
                    drawFont.Dispose()
                    drawFormat.Dispose()
                End If
            End While
            Sreader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn5.Close()
            SqlConn5.Dispose()
            SQLFcmd.Connection = Nothing
        End Try
        Dim RecordItemGapHeight As Integer = 10
        PageTop = RollPaperPrintSettings.RowsItemsHeight + 10
        If IsFullView = True Then
            FillDataset(PrtData, "select * from  " & RollPaperPrintSettings.RowItemsDatabaseName & " where transcode=" & RollPaperPrintSettings.Transcode & " order by sno ")
        Else
            FillDataset(PrtData, "select TOP 1 * from  " & RollPaperPrintSettings.RowItemsDatabaseName & " where transcode=" & RollPaperPrintSettings.Transcode)
        End If
        Dim ExtraPageHeight As Single = 0
        Dim flag2 As Boolean = False
        Dim SIZETOINCRESE As Single = 0
        '& "' and ( height<" & RollPaperPrintSettings.HeaderHeight & " or height> " & RollPaperPrintSettings.footertop & ")"
        For ri As Integer = 0 To RollPaperPrintSettings.RecordCount - 1
            Dim SqlConn6 As New SqlClient.SqlConnection
            flag2 = False
            SIZETOINCRESE = 0
            Try
                SqlConn6.ConnectionString = ConnectionStrinG
                SqlConn6.Open()
                SQLFcmd.Connection = SqlConn6
                SQLFcmd.CommandText = "select * from Printrecords where schemename=N'" & RollPaperPrintSettings.SchemeName & "'"
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


                        If UCase(Sreader("DBField").ToString.Trim) = "EXPIRY" Then
                            Try
                                Dim DT As New DateTimePicker
                                DT.Value = CDate(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString)
                                e.Graphics.DrawString(DT.Value.Date.ToString("MMM/yyyy"), drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)

                            Catch ex As Exception

                            End Try

                        ElseIf UCase(Sreader("DBField").ToString.Trim) <> "SNO" Then
                            'need to
                            If Sreader("formattype") = 0 Then

                                If CSng(Sreader("width")) > 20 Then
                                    Dim ht As Single = 0
                                    ht = RollPaperPrintSettings.FontHeight ' RowHeight
                                    Dim StringSize As New SizeF
                                    StringSize = e.Graphics.MeasureString(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, drawFont)
                                    Dim rect1 As New Rectangle(CSng(Sreader("fleft")), PageTop, CSng(Sreader("width")), ht)

                                    If StringSize.Width > CSng(Sreader("width")) Then
                                        If StringSize.Width / CSng(Sreader("WIDTH")) > SIZETOINCRESE Then
                                            SIZETOINCRESE = StringSize.Width / CSng(Sreader("WIDTH"))
                                        End If

                                        ht = CSng(ht + RollPaperPrintSettings.FontHeight * SIZETOINCRESE)
                                        rect1.Height = ht
                                        flag2 = True
                                    End If

                                    e.Graphics.DrawString(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, drawFont, drawBrush, rect1, drawFormat)
                                Else
                                    e.Graphics.DrawString(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                                End If

                                '   e.Graphics.DrawString(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)

                            Else
                                If Sreader("DBtype") = 3 Then
                                    Dim vAL As String = ""
                                    vAL = SQLGetStringFieldValue("SELECT " & Sreader("Formulastr").ToString.Trim & " AS TOT FROM " & RollPaperPrintSettings.RowItemsDatabaseName & "  WHERE  TRANSCODE=" & RollPaperPrintSettings.Transcode & " AND SNO=" & PrtData.Tables(0).Rows(RowNo).Item("SNO"), "TOT", "", False)
                                    If vAL.Length = 0 Then
                                        vAL = SQLGetStringFieldValue(Sreader("Formulastr").ToString.Trim & "  WHERE  TRANSCODE=" & RollPaperPrintSettings.Transcode & " AND SNO=" & PrtData.Tables(0).Rows(RowNo).Item("SNO"), "TOT", "", False)
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

                                

                                '  e.Graphics.DrawString(FormatNumber(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, ErpDecimalPlaces).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                            End If
                            'Expiry
                        Else

                            e.Graphics.DrawString(RowNo + 1, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                        End If
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
                SqlConn6.Close()
                SqlConn6.Dispose()
                SQLFcmd.Connection = Nothing
            End Try
            If flag2 = True Then
                PageTop = PageTop + RollPaperPrintSettings.FontHeight * SIZETOINCRESE
                ExtraPageHeight = ExtraPageHeight + RollPaperPrintSettings.FontHeight * SIZETOINCRESE
                RecordItemGapHeight = RecordItemGapHeight + RollPaperPrintSettings.FontHeight * SIZETOINCRESE
                flag2 = False
            End If
            RowNo = RowNo + 1
            PageTop = PageTop + RollPaperPrintSettings.FontHeight
            RecordItemGapHeight = RecordItemGapHeight + RollPaperPrintSettings.FontHeight
        Next


        'FOOTER LABLE FILEDS
        SqlStr2 = "select * from PrintFieldLabels where schemename=N'" & RollPaperPrintSettings.SchemeName & "' and ftop>" & RollPaperPrintSettings.HeaderHeight + RollPaperPrintSettings.DefRecordItemHeight
        Dim SqlConn14 As New SqlClient.SqlConnection
        Try
            SqlConn14.ConnectionString = ConnectionStrinG
            SqlConn14.Open()
            SQLFcmd.Connection = SqlConn14
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

                    If CSng(Sreader("width")) > 50 Then
                        Dim rect1 As New Rectangle(CSng(Sreader("fleft")), CSng(Sreader("ftop")) + RecordItemGapHeight, CSng(Sreader("width")), CSng(Sreader("height")))
                        If Sreader("formattype") = 0 Then
                            e.Graphics.DrawString(Sreader("printtext").ToString.Trim, drawFont, drawBrush, rect1, drawFormat)
                        Else
                            e.Graphics.DrawString(FormatNumber(Sreader("printtext"), ErpDecimalPlaces).ToString.Trim, drawFont, drawBrush, rect1, drawFormat)
                        End If
                    Else
                        If Sreader("formattype") = 0 Then
                            e.Graphics.DrawString(Sreader("printtext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")) + RecordItemGapHeight, drawFormat)
                        Else
                            Try
                                e.Graphics.DrawString(FormatNumber(Sreader("printtext"), ErpDecimalPlaces).ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")) + RecordItemGapHeight, drawFormat)
                            Catch ex As Exception
                                e.Graphics.DrawString(Sreader("printtext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")) + RecordItemGapHeight, drawFormat)
                            End Try
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
                    e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("lleft")), CSng(Sreader("ltop")) + RecordItemGapHeight, drawFormat)
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
            SqlConn14.Close()
            SqlConn14.Dispose()
            SQLFcmd.Connection = Nothing
        End Try
        'END OF FOOTER FILEDS
        'VERTICAL LINS
        'Dim SqlConn88 As New SqlClient.SqlConnection
        'Try
        '    SqlConn88.ConnectionString = ConnectionStrinG
        '    SqlConn88.Open()
        '    SQLFcmd.Connection = SqlConn88
        '    SQLFcmd.CommandText = "select * from printlines where schemename=N'" & RollPaperPrintSettings.SchemeName & "' and  ftop>" & RollPaperPrintSettings.FooterHeight + RollPaperPrintSettings.HeaderHeight + RollPaperPrintSettings.DefRecordItemHeight
        '    SQLFcmd.CommandType = CommandType.Text
        '    Dim Sreader As SqlClient.SqlDataReader
        '    Sreader = SQLFcmd.ExecuteReader
        '    While Sreader.Read()
        '        If Sreader("IsVisible") = True Then
        '            Dim penstyle As New Pen(Color.FromName(Sreader("LineColor").ToString.Trim), CSng(Sreader("BoarderWidth")))

        '            If Sreader("BoarderStyle").ToString.Trim = "Solid" Then
        '                penstyle.DashStyle = Drawing2D.DashStyle.Solid
        '            ElseIf Sreader("BoarderStyle").ToString.Trim = "Dash" Then
        '                penstyle.DashStyle = Drawing2D.DashStyle.Dash
        '            ElseIf Sreader("BoarderStyle").ToString.Trim = "Dot" Then
        '                penstyle.DashStyle = Drawing2D.DashStyle.Dot
        '            ElseIf Sreader("BoarderStyle").ToString.Trim = "DashDot" Then
        '                penstyle.DashStyle = Drawing2D.DashStyle.DashDot
        '            Else
        '                penstyle.DashStyle = Drawing2D.DashStyle.DashDotDot
        '            End If
        '            If Sreader("FieldType") = 0 Then
        '                e.Graphics.DrawLine(penstyle, CSng(Sreader("fleft")), CSng(Sreader("ftop")) + RecordItemGapHeight, CSng(Sreader("width")), CSng(Sreader("height")) + RecordItemGapHeight)
        '            Else
        '                e.Graphics.DrawRectangle(penstyle, CSng(Sreader("fleft")), CSng(Sreader("ftop")) + RecordItemGapHeight, CSng(Sreader("width")), CSng(Sreader("height"))+ RecordItemGapHeight)
        '            End If
        '        End If
        '    End While
        '    Sreader.Close()
        '    Sreader = Nothing
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    SqlConn88.Close()
        '    SqlConn88.Dispose()
        '    SQLFcmd.Connection = Nothing
        'End Try
        'RowNo = 0
        'e.HasMorePages = False
        'PrtData.Tables(0).Clear()

        'FOOTER PART


        Dim SqlConn22 As New SqlClient.SqlConnection
        Try
            SqlConn22.ConnectionString = ConnectionStrinG
            SqlConn22.Open()
            SQLFcmd.Connection = SqlConn22
            SQLFcmd.CommandText = "select * from printingsettings where schemename=N'" & RollPaperPrintSettings.SchemeName & "' and leftlogotop >" & RollPaperPrintSettings.HeaderHeight + RollPaperPrintSettings.DefRecordItemHeight
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                Try
                    If Sreader("LeftLogoIsOn") = True Then
                        ImageValue = Image.FromFile(Sreader("leftlogopath").ToString.Trim)
                        e.Graphics.DrawImage(ImageValue, CSng(Sreader("Leftlogoleft")), CSng(Sreader("leftlogotop")) + RecordItemGapHeight, CSng(Sreader("Leftlogowidth")), CSng(Sreader("Leftlogoheight")))
                    End If
                Catch ex As Exception
                End Try

                Try
                    If Sreader("rightLogoIsOn") = True Then
                        ImageValue = Image.FromFile(Sreader("rightlogopath").ToString.Trim)
                        e.Graphics.DrawImage(ImageValue, CSng(Sreader("rightlogoleft")), CSng(Sreader("rightlogotop")) + RecordItemGapHeight, CSng(Sreader("rightlogowidth")), CSng(Sreader("rightlogoheight")))
                    End If
                Catch ex As Exception

                End Try
            End While
            Sreader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn22.Close()
            SQLFcmd.Connection = Nothing
        End Try


        '*****************
        Dim SqlConn23 As New SqlClient.SqlConnection
        Try
            SqlConn23.ConnectionString = ConnectionStrinG
            SqlConn23.Open()
            SQLFcmd.Connection = SqlConn23
            SQLFcmd.CommandText = "select * from PrintLables where schemename=N'" & RollPaperPrintSettings.SchemeName & "' and  ftop > " & RollPaperPrintSettings.HeaderHeight + RollPaperPrintSettings.DefRecordItemHeight
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
                        Dim rect1 As New Rectangle(CSng(Sreader("fleft")), CSng(Sreader("ftop")) + RecordItemGapHeight, CSng(Sreader("width")), CSng(Sreader("height")))
                        e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, rect1, drawFormat)
                    Else
                        e.Graphics.DrawString(Sreader("labletext").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")) + RecordItemGapHeight, drawFormat)
                    End If
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
            SqlConn23.Close()
            SqlConn23.Dispose()
            SQLFcmd.Connection = Nothing
        End Try

        '***********************
        Dim SqlConn20 As New SqlClient.SqlConnection
        Try
            SqlConn20.ConnectionString = ConnectionStrinG
            SqlConn20.Open()
            SQLFcmd.Connection = SqlConn20
            SQLFcmd.CommandText = "select * from printheadings where schemename=N'" & RollPaperPrintSettings.SchemeName & "' and  ftop>" & RollPaperPrintSettings.HeaderHeight + RollPaperPrintSettings.DefRecordItemHeight
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
                    e.Graphics.DrawString(Sreader("HeadText").ToString.Trim, drawFont, drawBrush, CSng(Sreader("fleft")), CSng(Sreader("ftop")) + RecordItemGapHeight, drawFormat)
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
            SqlConn20.Close()
            SqlConn20.Dispose()
            SQLFcmd.Connection = Nothing
        End Try


        '******************
        Dim SqlConn30 As New SqlClient.SqlConnection
        Try
            SqlConn30.ConnectionString = ConnectionStrinG
            SqlConn30.Open()
            SQLFcmd.Connection = SqlConn30
            SQLFcmd.CommandText = "select * from printlines where schemename=N'" & RollPaperPrintSettings.SchemeName & "' and  ftop >" & RollPaperPrintSettings.HeaderHeight + RollPaperPrintSettings.DefRecordItemHeight
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
                        If CSng(Sreader("fleft")) = CSng(Sreader("width")) Then
                            'vertical
                            e.Graphics.DrawLine(penstyle, CSng(Sreader("fleft")), CSng(Sreader("ftop")) + RecordItemGapHeight, CSng(Sreader("width")), CSng(Sreader("height")))
                        Else
                            'harizantal
                            e.Graphics.DrawLine(penstyle, CSng(Sreader("fleft")), CSng(Sreader("ftop")) + RecordItemGapHeight, CSng(Sreader("width")), CSng(Sreader("height")) + RecordItemGapHeight)
                        End If

                    Else
                        If CSng(Sreader("fleft")) = CSng(Sreader("width")) Then
                            'vertical
                            e.Graphics.DrawRectangle(penstyle, CSng(Sreader("fleft")), CSng(Sreader("ftop")) + RecordItemGapHeight, CSng(Sreader("width")), CSng(Sreader("height")))
                        Else
                            'harizantal
                            e.Graphics.DrawRectangle(penstyle, CSng(Sreader("fleft")), CSng(Sreader("ftop")) + RecordItemGapHeight, CSng(Sreader("width")), CSng(Sreader("height")) + RecordItemGapHeight)
                        End If
                        ' e.Graphics.DrawRectangle(penstyle, CSng(Sreader("fleft")), CSng(Sreader("ftop")) + RecordItemGapHeight, CSng(Sreader("width")), CSng(Sreader("height")) + RecordItemGapHeight)
                    End If
                End If
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn30.Close()
            SqlConn30.Dispose()
            SQLFcmd.Connection = Nothing
        End Try
        Try

            PrtData.Tables(0).Clear()
        Catch ex As Exception

        End Try
    End Sub

End Module
