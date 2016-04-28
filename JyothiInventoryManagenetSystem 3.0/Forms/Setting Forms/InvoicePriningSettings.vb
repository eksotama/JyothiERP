Imports System.Drawing.Printing
Imports System.IO

Public Class InvoicePriningSettings
    Dim NewFontStyle As New FontStyle
    Dim LeftSidelogoselected As Boolean = False
    Dim Rightsidelogoselected As Boolean = False
    Dim IsNewLine As Boolean = False
    Dim PrtData As New DataSet

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

    Private Sub InvoicePriningSettings_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub



    Private Sub SalesInvoicePrintingOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

       

        cmbAutoPreview.Checked = True
        If My.Computer.Screen.WorkingArea.Width <= 1024 Then
            Me.Font = New Font(Me.Font.Name, 8, FontStyle.Regular)
        End If
        TxtPrinterName.Items.Clear()
        For Each s In Printing.PrinterSettings.InstalledPrinters
            TxtPrinterName.Items.Add(s)
        Next
        FillDataset(PrtData, "select top 5 * from  PrintingDataRowsItems")
        LoadSchemesIntoBoxes()
        LoadDataIntoComboBox("select  distinct VoucherName from PrintingSchemes where SchemeType=1", TxtDefInvoiceList, "VoucherName")
        LoadDefauls()
        txtSchemName.SelectedIndex = 0
        PrintPreviewControl22.Zoom = 1
        PrintPreviewControl22.Refresh()
        TxtZoom.Text = "Auto"

    End Sub
    Sub LoadSchemesIntoBoxes()
        LoadDataIntoComboBox("select distinct schemename from printingsettings where IsrollPaper='False' or IsrollPaper is null", txtSchemName, "schemename")
        LoadDataIntoComboBox("select  distinct schemename from printingsettings ", TxtInvoiceSchameList, "schemename")

    End Sub
    Sub LoadDefauls()
        LeftSidelogoselected = False
        Rightsidelogoselected = False

        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SQLFcmd2 As New SqlClient.SqlCommand
            SQLFcmd2.Connection = SqlConn1
            SQLFcmd2.CommandText = "select * from printingsettings where schemename=N'" & txtSchemName.Text & "'"
            SQLFcmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd2.ExecuteReader
            While Sreader.Read()
                TxtPrinterName.Text = Sreader("printername").ToString.Trim
                TxtPaperWidth.Text = Sreader("width")
                TxtPaperHeight.Text = Sreader("height")
                If Sreader("islandscape") = True Then
                    prtOrientationLand.Checked = True
                Else
                    prtOrientationPort.Checked = True
                End If
                pageleftmargin.Value = Sreader("fleft")
                pagerighttmargin.Value = Sreader("fright")
                pagetopmargin.Value = Sreader("ftop")
                pagebuttommargin.Value = Sreader("fbuttom")
                If Sreader("LeftLogoIsOn") = True Then
                    TxtIsLeftLogoOn.Checked = True
                Else
                    TxtIsLeftLogoOn.Checked = False
                End If
                txtleftEdge.Text = Sreader("Leftlogoleft")
                txtlefttop.Text = Sreader("leftlogotop")
                txtleftwidth.Text = Sreader("Leftlogowidth")
                txtleftheight.Text = Sreader("Leftlogoheight")
                Try
                    txtleftlogobox.ImageLocation = Sreader("leftlogopath").ToString.Trim
                Catch ex As Exception

                End Try

                If Sreader("rightLogoIsOn") = True Then
                    TxtIsRightLogoOn.Checked = True
                Else
                    TxtIsRightLogoOn.Checked = False
                End If
                txtrightedge.Text = Sreader("rightlogoleft")
                txtrighttop.Text = Sreader("rightlogotop")
                txtrightwidth.Text = Sreader("rightlogowidth")
                txtrightheight.Text = Sreader("rightlogoheight")
                Try
                    txtRightLogobox.ImageLocation = Sreader("rightlogopath")
                Catch ex As Exception

                End Try
                If Sreader("showpageno") = True Then
                    IsShownPageNos.Checked = True
                Else
                    IsShownPageNos.Checked = False
                End If
                TxtPageNoLeft.Value = Sreader("pagenoleft")
                TxtPageNoTop.Value = Sreader("pagenotop")
                TxtPageNoFormat.SelectedIndex = Sreader("pageformat")
                Exit While
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

        LoadDataIntoComboBox("select Fieldname from printFieldLabels where schemename=N'" & txtSchemName.Text & "'", TxtFieldLables, "Fieldname")
        LoadDataIntoComboBox("select Fieldname from printrecords where schemename=N'" & txtSchemName.Text & "'", TxtrecordItems, "Fieldname")
        LoadDataIntoComboBox("select Fieldname from printheadings where schemename=N'" & txtSchemName.Text & "'", txtheadingitems, "Fieldname")
        LoadDataIntoComboBox("select Fieldname from printlines where schemename=N'" & txtSchemName.Text & "'", txtLineNames, "Fieldname")
        LoadDataIntoComboBox("select Fieldname from printlables where schemename=N'" & txtSchemName.Text & "'", TxtLabelLists, "Fieldname")

        Dim SqlConn2 As New SqlClient.SqlConnection
        Try
            SqlConn2.ConnectionString = ConnectionStrinG
            SqlConn2.Open()
            Dim SQLFcmd2 As New SqlClient.SqlCommand
            SQLFcmd2.Connection = SqlConn2
            SQLFcmd2.CommandText = "select * from printrecords where schemename=N'" & txtSchemName.Text & "'"
            SQLFcmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd2.ExecuteReader
            While Sreader.Read()
                TxtRtop.Value = Sreader("ftop")
                TxtRlTop.Value = Sreader("ltop")
                TxtLineSpecing.Value = Sreader("space")
                TxtRFHeight.Value = Sreader("height")
                Exit While
            End While
            Sreader.Close()
            Sreader = Nothing
            SQLFcmd2.Connection = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn2.Close()
            SqlConn2.Dispose()
        End Try



        'DummyPanel.Width = CInt(TxtPaperWidth.Text) + 20
        'DummyPanel.Height = CInt(TxtPaperHeight.Text)
        'DummyPanel.BringToFront()
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
        PrintPriviewSet(sender, e, txtSchemName.Text, "PrintingDataRowsItems", "PrintDataDetails")

    End Sub

    Private Sub BtnPagesetupSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPagesetupSave.Click
        Dim SqlStr As String = ""
        If MsgBox("Do You want to save?           ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            SqlStr = "UPDATE printingsettings SET "
            SqlStr = SqlStr & "printername=N'" & TxtPrinterName.Text & "',"
            SqlStr = SqlStr & "width=" & TxtPaperWidth.Text & ","
            SqlStr = SqlStr & "height=" & TxtPaperHeight.Text & ","
            If prtOrientationLand.Checked = True Then
                SqlStr = SqlStr & "islandscape='true',"
            Else
                SqlStr = SqlStr & "islandscape='false',"
            End If

            If TxtIsLeftLogoOn.Checked = True Then
                SqlStr = SqlStr & "LeftLogoIsOn='true',"
            Else
                SqlStr = SqlStr & "LeftLogoIsOn='false',"
            End If
            If TxtIsRightLogoOn.Checked = True Then
                SqlStr = SqlStr & "rightLogoIsOn='true',"
            Else
                SqlStr = SqlStr & "rightLogoIsOn='false',"
            End If

            SqlStr = SqlStr & "fleft=" & pageleftmargin.Text & ","
            SqlStr = SqlStr & "fright=" & pagerighttmargin.Text & ","
            SqlStr = SqlStr & "ftop=" & pagetopmargin.Text & ","
            SqlStr = SqlStr & "fbuttom=" & pagetopmargin.Text & ","

            SqlStr = SqlStr & "Leftlogoleft=" & txtleftEdge.Text & ","
            SqlStr = SqlStr & "leftlogotop=" & txtlefttop.Text & ","
            SqlStr = SqlStr & "Leftlogowidth=" & txtleftwidth.Text & ","
            SqlStr = SqlStr & "Leftlogoheight=" & txtleftheight.Text & ","

            SqlStr = SqlStr & "rightlogoleft=" & txtrightedge.Text & ","
            SqlStr = SqlStr & "rightlogotop=" & txtrighttop.Text & ","
            SqlStr = SqlStr & "rightlogowidth=" & txtrightwidth.Text & ","
            SqlStr = SqlStr & "rightlogoheight=" & txtrightheight.Text & ","

            SqlStr = SqlStr & "leftlogopath='" & txtleftlogobox.ImageLocation & "',"
            SqlStr = SqlStr & "rightlogopath='" & txtRightLogobox.ImageLocation & "',"

            If IsShownPageNos.Checked = True Then
                SqlStr = SqlStr & "showpageno='true',"
            Else
                SqlStr = SqlStr & "showpageno='false',"
            End If
            If TxtIsShowSubtotal.Checked = True Then
                SqlStr = SqlStr & "Isheaderfooterrepeat=1,"
            Else
                SqlStr = SqlStr & "Isheaderfooterrepeat=0,"
            End If
            SqlStr = SqlStr & "pagenoleft=" & TxtPageNoLeft.Value & ","
            SqlStr = SqlStr & "pagenotop=" & TxtPageNoTop.Value & ","
            'Isheaderfooterrepeat
            SqlStr = SqlStr & "pageformat=" & TxtPageNoFormat.SelectedIndex & "   where schemename=N'" & txtSchemName.Text & "'"

            'MsgBox SqlStr 
            ExecuteSQLQuery(SqlStr)
        End If
        LoadReport()

    End Sub
    Sub LoadReport()
        If cmbAutoPreview.Checked = False Then
            Exit Sub
        End If
        Try
            Me.PrintGroup.Controls.RemoveAt(0)

        Catch ex As Exception

        End Try
        Me.PrintPreviewControl22 = New System.Windows.Forms.PrintPreviewControl

        If UCase(TxtZoom.Text) = "AUTO" Then
            Me.PrintPreviewControl22.AutoZoom = True
        Else
            Me.PrintPreviewControl22.AutoZoom = False
            If TxtZoom.Text = "25%" Then
                Me.PrintPreviewControl22.Zoom = 0.25
            ElseIf TxtZoom.Text = "50%" Then
                Me.PrintPreviewControl22.Zoom = 0.5
            ElseIf TxtZoom.Text = "75%" Then
                Me.PrintPreviewControl22.Zoom = 0.75
            ElseIf TxtZoom.Text = "100%" Then
                Me.PrintPreviewControl22.Zoom = 1

            Else
                Me.PrintPreviewControl22.Zoom = 2

            End If
        End If

        Me.PrintPreviewControl22.Hide()
        Me.PrintPreviewControl22.SuspendLayout()
        Me.PrintPreviewControl22.Dock = DockStyle.Fill
        PrintPreviewControl22.Refresh()
        PrintPreviewControl22.Document = PrtDoc
        Me.PrintPreviewControl22.ResumeLayout()
        Me.PrintGroup.Controls.Add(Me.PrintPreviewControl22)
        Me.PrintPreviewControl22.Show()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub TxtZoom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtZoom.SelectedIndexChanged
        On Error Resume Next
        If UCase(TxtZoom.Text) = "AUTO" Then
            Me.PrintPreviewControl22.AutoZoom = True
        Else
            Me.PrintPreviewControl22.AutoZoom = False
            If TxtZoom.Text = "25%" Then
                Me.PrintPreviewControl22.Zoom = 0.25
            ElseIf TxtZoom.Text = "50%" Then
                Me.PrintPreviewControl22.Zoom = 0.5
            ElseIf TxtZoom.Text = "75%" Then
                Me.PrintPreviewControl22.Zoom = 0.75
            ElseIf TxtZoom.Text = "100%" Then
                Me.PrintPreviewControl22.Zoom = 1

            Else
                Me.PrintPreviewControl22.Zoom = 2

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
        Dim SqlStr As String = ""
        If MsgBox("Do you want to Save?      ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then

            SqlStr = "UPDATE PrintFieldLabels SET "

            SqlStr = SqlStr & "schemename=N'" & txtSchemName.Text & "',"
            SqlStr = SqlStr & "fieldname='" & TxtFieldLables.Text & "',"
            SqlStr = SqlStr & "labletext=N'" & txtFLtext.Text & "',"
            If TxtFLShow.Checked = True Then
                SqlStr = SqlStr & "isvisible='True',"
            Else
                SqlStr = SqlStr & "isvisible='False',"
            End If

            SqlStr = SqlStr & "ltop=" & TxtFLtop.Value & ","
            SqlStr = SqlStr & "lleft=" & TxtFLLeft.Value & ","
            SqlStr = SqlStr & "lwidth=" & TxtFLWidth.Value & ","
            SqlStr = SqlStr & "lheight=" & TxtFLHeight.Value & ","
            SqlStr = SqlStr & "lfontname='" & TxtFLFont.Text & "',"
            SqlStr = SqlStr & "lfontsize=" & TxtFLFontSize.Value & ","

            If TxtFLStyleU.Checked = True Then
                If TxtFLStyleB.Checked = True And TxtFLSytleI.Checked = True Then
                    SqlStr = SqlStr & "lfontstyle=7,"
                ElseIf TxtFLStyleB.Checked = True Then
                    SqlStr = SqlStr & "lfontstyle=5,"
                ElseIf TxtFLSytleI.Checked = True Then
                    SqlStr = SqlStr & "lfontstyle=6,"
                Else
                    SqlStr = SqlStr & "lfontstyle=3,"

                End If
            Else
                If TxtFLStyleB.Checked = True And TxtFLSytleI.Checked = True Then
                    SqlStr = SqlStr & "lfontstyle=4,"
                ElseIf TxtFLStyleB.Checked = True Then
                    SqlStr = SqlStr & "lfontstyle=1,"
                ElseIf TxtFLSytleI.Checked = True Then
                    SqlStr = SqlStr & "lfontstyle=2,"
                Else
                    SqlStr = SqlStr & "lfontstyle=8,"
                End If
            End If

            SqlStr = SqlStr & "lalign='" & TxtFLAlign.Text & "',"
            SqlStr = SqlStr & "ftop=" & TxtFLFTop.Value & ","
            SqlStr = SqlStr & "fleft=" & TxtFLFLeft.Value & ","
            SqlStr = SqlStr & "width=" & TxtFLFwidth.Value & ","
            SqlStr = SqlStr & "height=" & TxtFLFHeight.Value & ","
            SqlStr = SqlStr & "fontsize=" & TxtFLFFontSize.Value & ","


            SqlStr = SqlStr & "fontname='" & TxtFLFFont.Text & "',"
            SqlStr = SqlStr & "fontcolor='" & TxtFLFColor.Text & "',"
            SqlStr = SqlStr & "lfontcolor='" & TxtFLFontColor.Text & "',"

            If TxtFLFStyleU.Checked = True Then
                If TxtFLFStyleB.Checked = True And TxtFLFStyleI.Checked = True Then
                    SqlStr = SqlStr & "fontstyle=7,"

                ElseIf TxtFLFStyleB.Checked = True Then
                    SqlStr = SqlStr & "fontstyle=5,"

                ElseIf TxtFLFStyleI.Checked = True Then
                    SqlStr = SqlStr & "fontstyle=6,"
                Else

                    SqlStr = SqlStr & "fontstyle=3,"
                End If
            Else
                If TxtFLFStyleB.Checked = True And TxtFLFStyleI.Checked = True Then
                    SqlStr = SqlStr & "fontstyle=4,"
                ElseIf TxtFLFStyleB.Checked = True Then
                    SqlStr = SqlStr & "fontstyle=1,"
                ElseIf TxtFLFStyleI.Checked = True Then
                    SqlStr = SqlStr & "fontstyle=2,"
                Else
                    SqlStr = SqlStr & "fontstyle=8,"
                End If
            End If
            If TxtFSuppres.Text.Length = 0 Or TxtFSuppres.Text = "NO" Then
                SqlStr = SqlStr & "align='" & TxtFLFAlign.Text & "',decimals=" & TxtFDecimals.Value & ",supress=0  where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtFieldLables.Text & "'"
            Else
                SqlStr = SqlStr & "align='" & TxtFLFAlign.Text & "',decimals=" & TxtFDecimals.Value & ",supress=1  where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtFieldLables.Text & "'"
            End If


            ExecuteSQLQuery(SqlStr)
        End If
        If TxtFLApplyToAll.Checked = True Then
            TxtFLApplyToAll.Checked = False
            SqlStr = "UPDATE PrintFieldLabels SET "

            SqlStr = SqlStr & "lfontname='" & TxtFLFont.Text & "',"
            SqlStr = SqlStr & "lfontsize=" & TxtFLFontSize.Value & ","

            If TxtFLStyleU.Checked = True Then
                If TxtFLStyleB.Checked = True And TxtFLSytleI.Checked = True Then
                    SqlStr = SqlStr & "lfontstyle=7,"
                ElseIf TxtFLStyleB.Checked = True Then
                    SqlStr = SqlStr & "lfontstyle=5,"
                ElseIf TxtFLSytleI.Checked = True Then
                    SqlStr = SqlStr & "lfontstyle=6,"
                Else
                    SqlStr = SqlStr & "lfontstyle=3,"

                End If
            Else
                If TxtFLStyleB.Checked = True And TxtFLSytleI.Checked = True Then
                    SqlStr = SqlStr & "lfontstyle=4,"
                ElseIf TxtFLStyleB.Checked = True Then
                    SqlStr = SqlStr & "lfontstyle=1,"
                ElseIf TxtFLSytleI.Checked = True Then
                    SqlStr = SqlStr & "lfontstyle=2,"
                Else
                    SqlStr = SqlStr & "lfontstyle=8,"
                End If
            End If
            SqlStr = SqlStr & "lfontcolor='" & TxtFLFColor.Text & "'  where schemename=N'" & txtSchemName.Text & "'"
            ExecuteSQLQuery(SqlStr)
        End If


        If TxtFLFapplytoall.Checked = True Then
            TxtFLFapplytoall.Checked = False
            SqlStr = "UPDATE PrintFieldLabels SET "

            SqlStr = SqlStr & "fontname='" & TxtFLFFont.Text & "',"
            SqlStr = SqlStr & "fontsize=" & TxtFLFFontSize.Value & ","

            If TxtFLFStyleU.Checked = True Then
                If TxtFLFStyleB.Checked = True And TxtFLFStyleI.Checked = True Then
                    SqlStr = SqlStr & "fontstyle=7,"
                ElseIf TxtFLFStyleB.Checked = True Then
                    SqlStr = SqlStr & "fontstyle=5,"
                ElseIf TxtFLFStyleI.Checked = True Then
                    SqlStr = SqlStr & "fontstyle=6,"
                Else
                    SqlStr = SqlStr & "fontstyle=3,"

                End If
            Else
                If TxtFLFStyleB.Checked = True And TxtFLFStyleI.Checked = True Then
                    SqlStr = SqlStr & "fontstyle=4,"
                ElseIf TxtFLFStyleB.Checked = True Then
                    SqlStr = SqlStr & "fontstyle=1,"
                ElseIf TxtFLFStyleI.Checked = True Then
                    SqlStr = SqlStr & "fontstyle=2,"
                Else
                    SqlStr = SqlStr & "fontstyle=8,"
                End If
            End If
            SqlStr = SqlStr & "fontcolor='" & TxtFLFontColor.Text & "',decimals=" & TxtFDecimals.Value & "  where schemename=N'" & txtSchemName.Text & "'"
            ExecuteSQLQuery(SqlStr)
        End If
        LoadReport()
    End Sub

    Private Sub TxtFieldLables_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFieldLables.SelectedIndexChanged

        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SQLFcmd2 As New SqlClient.SqlCommand
            SQLFcmd2.Connection = SqlConn1
            SQLFcmd2.CommandText = "select * from PrintFieldLabels where schemename=N'" & txtSchemName.Text & "' and Fieldname=N'" & TxtFieldLables.Text & "'"
            SQLFcmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd2.ExecuteReader
            While Sreader.Read()
                txtFLtext.Text = Sreader("labletext").ToString
                If Sreader("isvisible") = True Then
                    TxtFLShow.Checked = True
                Else
                    TxtFLShow.Checked = False
                End If
                TxtFLtop.Value = Sreader("ltop")
                TxtFLLeft.Value = Sreader("lleft")
                TxtFLWidth.Value = Sreader("lwidth")
                TxtFLHeight.Value = Sreader("lheight")
                TxtFLFont.Text = Sreader("lfontname").ToString.Trim
                TxtFLFontSize.Value = Sreader("lfontsize")
                If Sreader("supress") = 1 Then
                    TxtFSuppres.Text = "YES"
                Else
                    TxtFSuppres.Text = "NO"

                End If
                If Sreader("lfontstyle") = 1 Then
                    TxtFLStyleB.Checked = True
                    TxtFLStyleU.Checked = False
                    TxtFLSytleI.Checked = False
                ElseIf Sreader("lfontstyle") = 2 Then
                    TxtFLStyleB.Checked = False
                    TxtFLSytleI.Checked = True
                    TxtFLStyleU.Checked = False
                ElseIf Sreader("lfontstyle") = 3 Then
                    TxtFLStyleB.Checked = False
                    TxtFLSytleI.Checked = False
                    TxtFLStyleU.Checked = True
                ElseIf Sreader("lfontstyle") = 4 Then
                    TxtFLStyleB.Checked = True
                    TxtFLSytleI.Checked = True
                    TxtFLStyleU.Checked = False
                ElseIf Sreader("lfontstyle") = 5 Then
                    TxtFLStyleB.Checked = True
                    TxtFLSytleI.Checked = False
                    TxtFLStyleU.Checked = True
                ElseIf Sreader("lfontstyle") = 6 Then
                    TxtFLStyleB.Checked = False
                    TxtFLSytleI.Checked = True
                    TxtFLStyleU.Checked = True
                ElseIf Sreader("lfontstyle") = 7 Then
                    TxtFLStyleB.Checked = True
                    TxtFLSytleI.Checked = True
                    TxtFLStyleU.Checked = True
                Else
                    TxtFLStyleB.Checked = False
                    TxtFLSytleI.Checked = False
                    TxtFLStyleU.Checked = False
                End If


                TxtFLAlign.Text = Sreader("lalign")
                TxtFLFontColor.Text = Sreader("fontcolor").ToString.Trim
                TxtFLFColor.Text = Sreader("lfontcolor").ToString.Trim
                TxtFLFTop.Value = Sreader("ftop")
                TxtFLFLeft.Value = Sreader("fleft")
                TxtFLFwidth.Value = Sreader("width")
                TxtFLFHeight.Value = Sreader("height")
                TxtFLFFont.Text = Sreader("fontname").ToString.Trim
                TxtFLFFontSize.Value = Sreader("fontsize")

                If Sreader("fontstyle") = 1 Then
                    TxtFLFStyleB.Checked = True
                    TxtFLFStyleI.Checked = False
                    TxtFLFStyleU.Checked = False
                ElseIf Sreader("fontstyle") = 2 Then
                    TxtFLFStyleB.Checked = False
                    TxtFLFStyleI.Checked = False
                    TxtFLFStyleU.Checked = True
                ElseIf Sreader("fontstyle") = 3 Then
                    TxtFLFStyleB.Checked = False
                    TxtFLFStyleI.Checked = False
                    TxtFLFStyleU.Checked = True
                ElseIf Sreader("fontstyle") = 4 Then
                    TxtFLFStyleB.Checked = True
                    TxtFLFStyleI.Checked = True
                    TxtFLFStyleU.Checked = False
                ElseIf Sreader("fontstyle") = 5 Then
                    TxtFLFStyleB.Checked = True
                    TxtFLFStyleI.Checked = False
                    TxtFLFStyleU.Checked = True
                ElseIf Sreader("fontstyle") = 6 Then
                    TxtFLFStyleB.Checked = False
                    TxtFLFStyleU.Checked = True
                    TxtFLFStyleI.Checked = True
                ElseIf Sreader("fontstyle") = 7 Then
                    TxtFLFStyleB.Checked = True
                    TxtFLFStyleI.Checked = True
                    TxtFLFStyleU.Checked = True
                Else
                    TxtFLFStyleB.Checked = False
                    TxtFLFStyleI.Checked = False
                    TxtFLFStyleU.Checked = False
                End If
                TxtFDecimals.Value = Sreader("decimals")
                TxtFLFAlign.Text = Sreader("align").ToString.Trim
                txtFormulaNameF.Text = Sreader("Formulastr").ToString
                If Sreader("DBType") = 3 Then
                    txtFormulaNameF.Visible = True
                    lblformalf.Visible = True
                    BtnDefineF.Visible = True
                Else
                    txtFormulaNameF.Visible = False
                    BtnDefineF.Visible = False
                    lblformalf.Visible = False
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

    Private Sub btnNewLabelSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewLabelSave.Click
        If TxtLabelLists.Text.Length = 0 Then
            MsgBox("Please Select the  Labels from the list")
            TxtLabelLists.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to Save?      ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            If SQLIsFieldExists("SELECT TOP 1 1 from   PrintLables where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtLabelLists.Text & "'") = True Then
                'update
                Dim SQlstr As String = ""
                SQlstr = "UPDATE PrintLables  SET "
                SQlstr = SQlstr & " schemename='" & txtSchemName.Text & "',"
                SQlstr = SQlstr & " fieldname='" & TxtLabelLists.Text & "',"
                SQlstr = SQlstr & " labletext=N'" & txtLtext.Text & "',"
                SQlstr = SQlstr & " fontcolor='" & TxtLFontColor.Text & "',"
                SQlstr = SQlstr & " ftop=" & TxtLtop.Value & ","
                SQlstr = SQlstr & " fleft=" & TxtLleft.Value & ","
                SQlstr = SQlstr & " width=" & TxtLwidth.Value & ","
                SQlstr = SQlstr & " height=" & TxtLHeight.Value & ","
                SQlstr = SQlstr & " fontsize=" & TxtLFontSize.Value & ","
                SQlstr = SQlstr & " fontname='" & TxtLFontName.Text & "',"
                If TxtLShow.Checked = True Then
                    SQlstr = SQlstr & " isvisible='True',"
                Else
                    SQlstr = SQlstr & " isvisible='False',"
                End If

                If TxtLStyleU.Checked = True Then
                    If TxtLStyleB.Checked = True And TxtLStyleI.Checked = True Then
                        SQlstr = SQlstr & " fontstyle=7,"
                    ElseIf TxtLStyleB.Checked = True Then
                        SQlstr = SQlstr & " fontstyle=5,"
                    ElseIf TxtLStyleI.Checked = True Then
                        SQlstr = SQlstr & " fontstyle=6,"
                    Else

                        SQlstr = SQlstr & " fontstyle=3,"
                    End If
                Else
                    If TxtLStyleB.Checked = True And TxtLStyleI.Checked = True Then
                        SQlstr = SQlstr & " fontstyle=4,"
                    ElseIf TxtLStyleB.Checked = True Then
                        SQlstr = SQlstr & " fontstyle=1,"
                    ElseIf TxtLStyleI.Checked = True Then
                        SQlstr = SQlstr & " fontstyle=2,"
                    Else
                        SQlstr = SQlstr & " fontstyle=8,"
                    End If
                End If

                SQlstr = SQlstr & " align='" & TxtLFontAlign.Text & "' where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtLabelLists.Text & "'"
                ExecuteSQLQuery(SQlstr)


                'SQlstr = SQlstr & " schemename=N'" & txtSchemName.Text & "',"

            Else
                Dim sqlsTR As String = ""
                sqlsTR = " INSERT INTO [PrintLables] ([schemename],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor], " _
                    & " [fieldname],[labletext],[isvisible],[align])     VALUES " _
                    & "(@schemename,@ftop,@fleft,@width,@height,@Fontname,@fontsize,@fontstyle,@fontcolor,@fieldname,@labletext,@isvisible,@align) "

                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim DBF As New SqlClient.SqlCommand(sqlsTR, MAINCON)
                With DBF.Parameters
                    .AddWithValue("schemename", txtSchemName.Text)
                    .AddWithValue("fieldname", TxtLabelLists.Text)
                    .AddWithValue("labletext", txtLtext.Text)
                    If TxtLShow.Checked = True Then
                        .AddWithValue("isvisible", "True")
                    Else
                        .AddWithValue("isvisible", "False")
                    End If

                    .AddWithValue("fontcolor", TxtLFontColor.Text)

                    .AddWithValue("ftop", TxtLtop.Value)
                    .AddWithValue("fleft", TxtLleft.Value)
                    .AddWithValue("width", TxtLwidth.Value)
                    .AddWithValue("height", TxtLHeight.Value)
                    .AddWithValue("fontname", TxtLFontName.Text)
                    .AddWithValue("fontsize", TxtLFontSize.Value)

                    If TxtLStyleU.Checked = True Then
                        If TxtLStyleB.Checked = True And TxtLStyleI.Checked = True Then
                            .AddWithValue("fontstyle", 7)
                        ElseIf TxtLStyleB.Checked = True Then
                            .AddWithValue("fontstyle", 5)
                        ElseIf TxtLStyleI.Checked = True Then
                            .AddWithValue("fontstyle", 6)
                        Else

                            .AddWithValue("fontstyle", 3)
                        End If
                    Else
                        If TxtLStyleB.Checked = True And TxtLStyleI.Checked = True Then
                            .AddWithValue("fontstyle", 4)
                        ElseIf TxtLStyleB.Checked = True Then
                            .AddWithValue("fontstyle", 1)
                        ElseIf TxtLStyleI.Checked = True Then
                            .AddWithValue("fontstyle", 2)
                        Else
                            .AddWithValue("fontstyle", 8)
                        End If
                    End If


                    .AddWithValue("align", TxtLFontAlign.Text)
                End With
                DBF.ExecuteNonQuery()
                DBF = Nothing
                MAINCON.Close()
            End If
        End If
        If TxtLableApplytoall.Checked = True Then
            Dim SQLStr As String = ""
            SQLStr = " UPDATE PrintLables SET "
            SQLStr = SQLStr & " fontcolor='" & TxtLFontColor.Text & "',"
            SQLStr = SQLStr & " fontname='" & TxtLFontName.Text & "',"

            If TxtLStyleU.Checked = True Then
                If TxtLStyleB.Checked = True And TxtLStyleI.Checked = True Then
                    SQLStr = SQLStr & " fontsize=7,"

                ElseIf TxtLStyleB.Checked = True Then
                    SQLStr = SQLStr & " fontsize=5,"
                ElseIf TxtLStyleI.Checked = True Then
                    SQLStr = SQLStr & " fontsize=6,"
                Else
                    SQLStr = SQLStr & " fontsize=3,"
                End If
            Else
                If TxtLStyleB.Checked = True And TxtLStyleI.Checked = True Then
                    SQLStr = SQLStr & " fontsize=4,"
                ElseIf TxtLStyleB.Checked = True Then
                    SQLStr = SQLStr & " fontsize=1,"
                ElseIf TxtLStyleI.Checked = True Then
                    SQLStr = SQLStr & " fontsize=2,"
                Else
                    SQLStr = SQLStr & " fontsize=8,"
                End If
            End If
            SQLStr = SQLStr & " fontsize=" & TxtLFontSize.Value & "  where schemename=N'" & txtSchemName.Text & "'"
            ExecuteSQLQuery(SQLStr)
            TxtLableApplytoall.Checked = False
        End If
        LoadReport()
    End Sub

    Private Sub TxtLabelLists_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLabelLists.SelectedIndexChanged
        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SQLFcmd2 As New SqlClient.SqlCommand
            SQLFcmd2.Connection = SqlConn1
            SQLFcmd2.CommandText = "select * from PrintLables where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtLabelLists.Text & "'"
            SQLFcmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd2.ExecuteReader
            While Sreader.Read()
                TxtLabelLists.Text = Sreader("fieldname").ToString.Trim
                txtLtext.Text = Sreader("labletext").ToString.Trim
                If Sreader("isvisible") = True Then
                    TxtLShow.Checked = True
                Else
                    TxtLShow.Checked = False
                End If

                TxtLFontColor.Text = Sreader("fontcolor").ToString.Trim

                TxtLtop.Value = Sreader("ftop")
                TxtLleft.Value = Sreader("fleft")
                TxtLwidth.Value = Sreader("width")
                TxtLHeight.Value = Sreader("height")
                TxtLFontName.Text = Sreader("fontname").ToString.Trim
                TxtLFontSize.Value = Sreader("fontsize")


                If Sreader("fontstyle") = 1 Then
                    TxtLStyleB.Checked = True
                    TxtLStyleI.Checked = False
                    TxtLStyleU.Checked = False
                ElseIf Sreader("fontstyle") = 2 Then
                    TxtLStyleB.Checked = False
                    TxtLStyleI.Checked = False
                    TxtLStyleU.Checked = True
                ElseIf Sreader("fontstyle") = 3 Then
                    TxtLStyleB.Checked = False
                    TxtLStyleI.Checked = False
                    TxtLStyleU.Checked = True
                ElseIf Sreader("fontstyle") = 4 Then
                    TxtLStyleB.Checked = True
                    TxtLStyleI.Checked = True
                    TxtLStyleU.Checked = False
                ElseIf Sreader("fontstyle") = 5 Then
                    TxtLStyleB.Checked = True
                    TxtLStyleI.Checked = False
                    TxtLStyleU.Checked = True
                ElseIf Sreader("fontstyle") = 6 Then
                    TxtLStyleB.Checked = False
                    TxtLStyleU.Checked = True
                    TxtLStyleI.Checked = True
                ElseIf Sreader("fontstyle") = 7 Then
                    TxtLStyleB.Checked = True
                    TxtLStyleI.Checked = True
                    TxtLStyleU.Checked = True
                Else
                    TxtLStyleB.Checked = False
                    TxtLStyleI.Checked = False
                    TxtLStyleU.Checked = False
                End If
                TxtLFontAlign.Text = Sreader("align").ToString
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
        If TxtLabelLists.Text.Length > 0 Then
            ReDrawCtrl()
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
        gr.Dispose()
        rh = m + TxtLineSpecing.Value
        m = TxtRFHeight.Value / (m + TxtLineSpecing.Value)
        ExecuteSQLQuery("UPDATE PrintingSettings SET maxrowsperpage=" & m & ", rowheight=" & rh & "  where schemename=N'" & txtSchemName.Text & "'")
        ExecuteSQLQuery("UPDATE printrecords SET [fTop]=" & TxtRtop.Value & ",height=" & TxtRFHeight.Value & ",ltop=" & TxtRlTop.Value & ",space=" & TxtLineSpecing.Value & "  where schemename=N'" & txtSchemName.Text & "'")

        Dim SqlStr As String = ""
        SqlStr = "UPDATE printrecords SET "
        SqlStr = SqlStr & " labletext=N'" & TxtRlText.Text & "',"
        SqlStr = SqlStr & " lfontname='" & TxtRlfontname.Text & "',"
        SqlStr = SqlStr & " lfontcolor='" & TxtRlfontcolor.Text & "',"
        SqlStr = SqlStr & " fontcolor='" & TxtRfontColor.Text & "',"
        SqlStr = SqlStr & " fontname='" & TxtRFontname.Text & "',"
        SqlStr = SqlStr & " Rcase='" & TxtRCase.Text & "',"
        SqlStr = SqlStr & " align='" & TxtRAlign.Text & "',"
        SqlStr = SqlStr & " Lcase='" & TxtRlCase.Text & "',"
        SqlStr = SqlStr & " lalign='" & TxtRlalign.Text & "',"


        If TxtRShow.Checked = True Then
            SqlStr = SqlStr & " isvisible='True',"
        Else
            SqlStr = SqlStr & " isvisible='False',"
        End If
        SqlStr = SqlStr & " lleft=" & TxtRlLeft.Value & ","
        SqlStr = SqlStr & " lwidth=" & TxtRlwidth.Value & ","
        SqlStr = SqlStr & " lfontsize=" & TxtRlfontsize.Value & ","
        SqlStr = SqlStr & " fleft=" & TxtRFleft.Value & ","
        SqlStr = SqlStr & " width=" & TxtRwidht.Value & ","

        If TxtRlStyleU.Checked = True Then
            If TxtRlstyelB.Checked = True And TxtRlStyleI.Checked = True Then
                SqlStr = SqlStr & " Lfontstyle=7,"

            ElseIf TxtRlstyelB.Checked = True Then
                SqlStr = SqlStr & " Lfontstyle=5,"
            ElseIf TxtRlStyleI.Checked = True Then
                SqlStr = SqlStr & " Lfontstyle=6,"
            Else

                SqlStr = SqlStr & " Lfontstyle=3,"
            End If
        Else
            If TxtRlstyelB.Checked = True And TxtRlStyleI.Checked = True Then
                SqlStr = SqlStr & " Lfontstyle=4,"
            ElseIf TxtRlstyelB.Checked = True Then
                SqlStr = SqlStr & " Lfontstyle=1,"
            ElseIf TxtRlStyleI.Checked = True Then
                SqlStr = SqlStr & " Lfontstyle=2,"
            Else
                SqlStr = SqlStr & " Lfontstyle=8,"
            End If
        End If

        If TxtRStyleU.Checked = True Then
            If txtRStyleB.Checked = True And TxtRStyleI.Checked = True Then
                SqlStr = SqlStr & " fontstyle=7,"

            ElseIf txtRStyleB.Checked = True Then
                SqlStr = SqlStr & " fontstyle=5,"
            ElseIf TxtRStyleI.Checked = True Then
                SqlStr = SqlStr & " fontstyle=6,"
            Else

                SqlStr = SqlStr & " fontstyle=3,"
            End If
        Else
            If txtRStyleB.Checked = True And TxtRStyleI.Checked = True Then
                SqlStr = SqlStr & " fontstyle=4,"
            ElseIf txtRStyleB.Checked = True Then
                SqlStr = SqlStr & " fontstyle=1,"
            ElseIf TxtRStyleI.Checked = True Then
                SqlStr = SqlStr & " fontstyle=2,"
            Else
                SqlStr = SqlStr & " fontstyle=8,"
            End If
        End If
        If TxtRecSuppress.Text.Length = 0 Or TxtRecSuppress.Text = "NO" Then
            SqlStr = SqlStr & " fontsize=" & TxtRFontSize.Value & ",decimals=" & TxtRecDecimals.Value & ",supress=0  where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtrecordItems.Text & "'"
        Else
            'SqlStr = SqlStr & "align=N'" & TxtFLFAlign.Text & "',decimals=" & TxtFDecimals.Value & ",supress=1  where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtFieldLables.Text & "'"
            SqlStr = SqlStr & " fontsize=" & TxtRFontSize.Value & ",decimals=" & TxtRecDecimals.Value & ",supress=1  where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtrecordItems.Text & "'"
        End If
        '   SqlStr = SqlStr & " fontsize=" & TxtRFontSize.Value & ",decimals=" & TxtRecDecimals.Value & "  where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtrecordItems.Text & "'"
        ExecuteSQLQuery(SqlStr)

        If txtRLapplytoall.Checked = True Then
            txtRLapplytoall.Checked = False
            SqlStr = "UPDATE printrecords SET "
            SqlStr = SqlStr & " lfontname='" & TxtRlfontname.Text & "',"
            SqlStr = SqlStr & " lfontcolor='" & TxtRlfontcolor.Text & "',"
            SqlStr = SqlStr & " lfontsize=" & TxtRlfontsize.Value & ","
            If TxtRlStyleU.Checked = True Then
                If TxtRlstyelB.Checked = True And TxtRlStyleI.Checked = True Then
                    SqlStr = SqlStr & " lfontstyle=7,"
                ElseIf TxtRlstyelB.Checked = True Then
                    SqlStr = SqlStr & " lfontstyle=5,"
                ElseIf TxtRlStyleI.Checked = True Then
                    SqlStr = SqlStr & " lfontstyle=6,"
                Else
                    SqlStr = SqlStr & " lfontstyle=3,"
                End If
            Else
                If TxtRlstyelB.Checked = True And TxtRlStyleI.Checked = True Then
                    SqlStr = SqlStr & " lfontstyle=4,"
                ElseIf TxtRlstyelB.Checked = True Then
                    SqlStr = SqlStr & " lfontstyle=1,"
                ElseIf TxtRlStyleI.Checked = True Then
                    SqlStr = SqlStr & " lfontstyle=2,"
                Else
                    SqlStr = SqlStr & " lfontstyle=8,"
                End If
            End If
            SqlStr = SqlStr & " Lcase='" & TxtRlCase.Text & "' where schemename=N'" & txtSchemName.Text & "'"
            ExecuteSQLQuery(SqlStr)
        End If

        If TxtRapplytoall.Checked = True Then
            TxtRapplytoall.Checked = False
            SqlStr = "UPDATE printrecords SET "
            SqlStr = SqlStr & " fontname='" & TxtRFontname.Text & "',"
            SqlStr = SqlStr & " fontcolor='" & TxtRfontColor.Text & "',"
            SqlStr = SqlStr & " fontsize=" & TxtRFontSize.Value & ","

            If TxtRStyleU.Checked = True Then
                If txtRStyleB.Checked = True And TxtRStyleI.Checked = True Then
                    SqlStr = SqlStr & " fontstyle=7,"

                ElseIf txtRStyleB.Checked = True Then
                    SqlStr = SqlStr & " fontstyle=5,"
                ElseIf TxtRStyleI.Checked = True Then
                    SqlStr = SqlStr & " fontstyle=6,"
                Else

                    SqlStr = SqlStr & " fontstyle=3,"
                End If
            Else
                If txtRStyleB.Checked = True And TxtRStyleI.Checked = True Then
                    SqlStr = SqlStr & " fontstyle=4,"
                ElseIf txtRStyleB.Checked = True Then
                    SqlStr = SqlStr & " fontstyle=1,"
                ElseIf TxtRStyleI.Checked = True Then
                    SqlStr = SqlStr & " fontstyle=2,"
                Else
                    SqlStr = SqlStr & " fontstyle=8,"
                End If
            End If
            SqlStr = SqlStr & " Rcase='" & TxtRCase.Text & "',decimals=" & TxtRecDecimals.Value & " where schemename=N'" & txtSchemName.Text & "'"
            ExecuteSQLQuery(SqlStr)
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
            Dim SqlConn1 As New SqlClient.SqlConnection
            Try
                SqlConn1.ConnectionString = ConnectionStrinG
                SqlConn1.Open()
                Dim SQLFcmd2 As New SqlClient.SqlCommand
                SQLFcmd2.Connection = SqlConn1
                SQLFcmd2.CommandText = "select * from printrecords where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtrecordItems.Text & "'"
                SQLFcmd2.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd2.ExecuteReader
                While Sreader.Read()
                    TxtRlText.Text = Sreader("labletext").ToString.Trim
                    If Sreader("isvisible") = True Then
                        TxtRShow.Checked = True
                    Else
                        TxtRShow.Checked = False
                    End If
                    TxtRlLeft.Value = Sreader("lleft")
                    TxtRlwidth.Value = Sreader("lwidth")
                    TxtRlfontname.Text = Sreader("lfontname").ToString.Trim
                    TxtRlfontsize.Value = Sreader("lfontsize")
                    TxtRlfontcolor.Text = Sreader("lfontcolor").ToString.Trim

                    If Sreader("lfontstyle") = 1 Then
                        TxtRlstyelB.Checked = True
                        TxtRlStyleI.Checked = False
                        TxtRlStyleU.Checked = False
                    ElseIf Sreader("lfontstyle") = 2 Then
                        TxtRlstyelB.Checked = False
                        TxtRlStyleI.Checked = False
                        TxtRlStyleU.Checked = True
                    ElseIf Sreader("lfontstyle") = 3 Then
                        TxtRlstyelB.Checked = False
                        TxtRlStyleI.Checked = False
                        TxtRlStyleU.Checked = True
                    ElseIf Sreader("lfontstyle") = 4 Then
                        TxtRlstyelB.Checked = True
                        TxtRlStyleI.Checked = True
                        TxtRlStyleU.Checked = False
                    ElseIf Sreader("lfontstyle") = 5 Then
                        TxtRlstyelB.Checked = True
                        TxtRlStyleI.Checked = False
                        TxtRlStyleU.Checked = True
                    ElseIf Sreader("lfontstyle") = 6 Then
                        TxtRlstyelB.Checked = False
                        TxtRlStyleU.Checked = True
                        TxtRlStyleI.Checked = True
                    ElseIf Sreader("lfontstyle") = 7 Then
                        TxtRlstyelB.Checked = True
                        TxtRlStyleI.Checked = True
                        TxtRlStyleU.Checked = True
                    Else
                        TxtRlstyelB.Checked = False
                        TxtRlStyleI.Checked = False
                        TxtRlStyleU.Checked = False
                    End If
                    If Sreader("supress") = 1 Then
                        TxtRecSuppress.Text = "YES"
                    Else
                        TxtRecSuppress.Text = "NO"

                    End If

                    TxtRecDecimals.Value = Sreader("decimals")
                    TxtRlCase.Text = Sreader("Lcase").ToString.Trim
                    TxtRlalign.Text = Sreader("lalign").ToString.Trim

                    TxtRFleft.Value = Sreader("fleft")
                    TxtRwidht.Value = Sreader("width")
                    TxtRFontname.Text = Sreader("fontname").ToString.Trim
                    TxtRFontSize.Value = Sreader("fontsize")
                    TxtRfontColor.Text = Sreader("fontcolor").ToString.Trim


                    If Sreader("fontstyle") = 1 Then
                        txtRStyleB.Checked = True
                        TxtRStyleI.Checked = False
                        TxtRStyleU.Checked = False
                    ElseIf Sreader("fontstyle") = 2 Then
                        txtRStyleB.Checked = False
                        TxtRStyleI.Checked = False
                        TxtRStyleU.Checked = True
                    ElseIf Sreader("fontstyle") = 3 Then
                        txtRStyleB.Checked = False
                        TxtRStyleI.Checked = False
                        TxtRStyleU.Checked = True
                    ElseIf Sreader("fontstyle") = 4 Then
                        txtRStyleB.Checked = True
                        TxtRStyleI.Checked = True
                        TxtRStyleU.Checked = False
                    ElseIf Sreader("fontstyle") = 5 Then
                        txtRStyleB.Checked = True
                        TxtRStyleI.Checked = False
                        TxtRStyleU.Checked = True
                    ElseIf Sreader("fontstyle") = 6 Then
                        txtRStyleB.Checked = False
                        TxtRStyleU.Checked = True
                        TxtRStyleI.Checked = True
                    ElseIf Sreader("fontstyle") = 7 Then
                        txtRStyleB.Checked = True
                        TxtRStyleI.Checked = True
                        TxtRStyleU.Checked = True
                    Else
                        txtRStyleB.Checked = False
                        TxtRStyleI.Checked = False
                        TxtRStyleU.Checked = False
                    End If

                    TxtRCase.Text = Sreader("Rcase").ToString.Trim
                    TxtRAlign.Text = Sreader("align").ToString.Trim
                    TxtFormulaName.Text = Sreader("Formulastr").ToString
                    If Sreader("DBType") = 3 Then
                        lblformulaRec.Visible = True
                        TxtFormulaName.Visible = True
                        btnDefinformula.Visible = True
                    Else
                        lblformulaRec.Visible = False
                        TxtFormulaName.Visible = False
                        btnDefinformula.Visible = False
                    End If
                    Exit While
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




        End If
        If TxtrecordItems.Text.Length > 0 Then
            ReDrawCtrl()
        End If
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Dim inputval As String = ""
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
            Dim SQLStr As String = ""
            If SQLIsFieldExists("SELECT TOP 1 1 from   printlines where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & txtLineNames.Text & "'") = True Then
                SQLStr = "UPDATE printlines SET "
                SQLStr = SQLStr & " schemename=N'" & txtSchemName.Text & "',"
                SQLStr = SQLStr & " Fieldname='" & txtLineNames.Text & "',"
                SQLStr = SQLStr & " linecolor='" & txtLineColor.Text & "',"
                SQLStr = SQLStr & " boarderstyle='" & txtLineStyle.Text & "',"
                If TxtLineShow.Checked = True Then
                    SQLStr = SQLStr & " isvisible='True',"
                Else
                    SQLStr = SQLStr & " isvisible='False',"
                End If
                SQLStr = SQLStr & " ftop=" & TxtLineY1.Value & ","
                SQLStr = SQLStr & " fleft=" & TxtLineX1.Value & ","
                SQLStr = SQLStr & " width=" & TxtLinex2.Value & ","
                SQLStr = SQLStr & " height=" & TxtLineY2.Value & ","
                SQLStr = SQLStr & " boarderwidth=" & txtLineWidth.Value & "  where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & txtLineNames.Text & "'"
                ExecuteSQLQuery(SQLStr)
            Else
                SQLStr = "INSERT INTO [PrintLines] ([schemename],[ftop],[fleft],[width],[height],[fieldname],[FieldType],[LineColor],[BoarderStyle],[BoarderWidth],[IsVisible])     VALUES " _
                    & "(@schemename,@ftop,@fleft,@width,@height,@fieldname,@FieldType,@LineColor,@BoarderStyle,@BoarderWidth,@IsVisible)     "
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
                    .AddWithValue("schemename", txtSchemName.Text)
                    .AddWithValue("ftop", TxtLineY1.Value)
                    .AddWithValue("fleft", TxtLineX1.Value)
                    .AddWithValue("width", TxtLinex2.Value)
                    .AddWithValue("height", TxtLineY2.Value)
                    .AddWithValue("Fieldname", txtLineNames.Text)
                    .AddWithValue("linecolor", txtLineColor.Text)
                    .AddWithValue("boarderstyle", txtLineStyle.Text)
                    .AddWithValue("boarderwidth", txtLineWidth.Value)
                End With
                DBF.ExecuteNonQuery()
                DBF = Nothing
                MAINCON.Close()
            End If
            IsNewLine = False
        End If
        LoadReport()

    End Sub

    Private Sub txtLineNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLineNames.SelectedIndexChanged
        If txtLineNames.Text.Length = 0 Then
            Exit Sub
        End If

        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SQLFcmd2 As New SqlClient.SqlCommand
            SQLFcmd2.Connection = SqlConn1
            SQLFcmd2.CommandText = "select * from printlines where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & txtLineNames.Text & "'"
            SQLFcmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd2.ExecuteReader
            While Sreader.Read()
                If Sreader("isvisible") = True Then
                    TxtLineShow.Checked = True
                Else
                    TxtLineShow.Checked = False
                End If
                TxtLineY1.Value = Sreader("ftop")
                TxtLineX1.Value = Sreader("fleft")
                TxtLinex2.Value = Sreader("width")
                TxtLineY2.Value = Sreader("height")

                txtLineColor.Text = Sreader("linecolor").ToString.Trim
                txtLineStyle.Text = Sreader("boarderstyle").ToString.Trim
                txtLineWidth.Value = Sreader("boarderwidth")
                Exit While
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

        If txtLineNames.Text.Length > 0 Then
            ReDrawCtrl()
        End If
    End Sub

    Private Sub BtnHeadingSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHeadingSave.Click
        If txtheadingitems.Text.Length = 0 Then
            MsgBox("Please Select The Headings form the list ")
            txtheadingitems.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to Save?      ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            Dim SQlStr As String = ""
            If SQLIsFieldExists("SELECT TOP 1 1 from   printheadings where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & txtheadingitems.Text & "'") = True Then
                SQlStr = " UPDATE printheadings SET "
                SQlStr = SQlStr & " schemename=N'" & txtSchemName.Text & "',"
                SQlStr = SQlStr & " fieldname='" & txtheadingitems.Text & "',"
                SQlStr = SQlStr & " headtext=N'" & TxtHeadDisplyText.Text & "',"
                SQlStr = SQlStr & " fontcolor='" & TxtHeadFontColor.Text & "',"
                SQlStr = SQlStr & " fontname='" & TxtHeadFontName.Text & "',"
                If TxtHeadShow.Checked = True Then
                    SQlStr = SQlStr & " isvisible='True',"
                Else
                    SQlStr = SQlStr & " isvisible='False',"
                End If

                SQlStr = SQlStr & " ftop=" & TxtHeadTop.Value & ","

                SQlStr = SQlStr & " fleft=" & TxtHeadLeft.Value & ","
                SQlStr = SQlStr & " width=" & TxtHeadWidth.Value & ","
                SQlStr = SQlStr & " height=" & TxtHeadHeight.Value & ","
                SQlStr = SQlStr & " fontsize=" & TxtHeadFontSize.Value & ","

                If TxtHeadStyleU.Checked = True Then
                    If TxtHeadStyleB.Checked = True And TxtHeadStyleI.Checked = True Then
                        SQlStr = SQlStr & " fontstyle=7,"

                    ElseIf TxtHeadStyleB.Checked = True Then
                        SQlStr = SQlStr & " fontstyle=5,"
                    ElseIf TxtHeadStyleI.Checked = True Then
                        SQlStr = SQlStr & " fontstyle=6,"
                    Else

                        SQlStr = SQlStr & " fontstyle=3,"
                    End If
                Else
                    If TxtHeadStyleB.Checked = True And TxtHeadStyleI.Checked = True Then
                        SQlStr = SQlStr & " fontstyle=4,"
                    ElseIf TxtHeadStyleB.Checked = True Then
                        SQlStr = SQlStr & " fontstyle=1,"
                    ElseIf TxtHeadStyleI.Checked = True Then
                        SQlStr = SQlStr & " fontstyle=2,"
                    Else
                        SQlStr = SQlStr & " fontstyle=8,"
                    End If
                End If
                SQlStr = SQlStr & " align='" & TxtHeadAlign.Text & "' where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & txtheadingitems.Text & "'"
                ExecuteSQLQuery(SQlStr)
            Else
                SQlStr = " INSERT INTO [PrintHeadings]([schemename],[fTop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[fieldname],[Align],[IsVisible],[HeadText])     VALUES " _
                    & " (@schemename,@fTop,@fleft,@width,@height,@Fontname,@fontsize,@fontstyle,@fontcolor,@fieldname,@Align,@IsVisible,@HeadText) "
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim DBF As New SqlClient.SqlCommand(SQlStr, MAINCON)
                With DBF.Parameters

                    .AddWithValue("schemename", txtSchemName.Text)
                    .AddWithValue("fieldname", txtheadingitems.Text)
                    .AddWithValue("headtext", TxtHeadDisplyText.Text)
                    If TxtHeadShow.Checked = True Then
                        .AddWithValue("isvisible", "True")
                    Else
                        .AddWithValue("isvisible", "False")
                    End If

                    .AddWithValue("fontcolor", TxtHeadFontColor.Text)
                    .AddWithValue("ftop", TxtHeadTop.Value)
                    .AddWithValue("fleft", TxtHeadLeft.Value)
                    .AddWithValue("width", TxtHeadWidth.Value)
                    .AddWithValue("height", TxtHeadHeight.Value)
                    .AddWithValue("fontname", TxtHeadFontName.Text)
                    .AddWithValue("fontsize", TxtHeadFontSize.Value)

                    If TxtHeadStyleU.Checked = True Then
                        If TxtHeadStyleB.Checked = True And TxtHeadStyleI.Checked = True Then
                            .AddWithValue("fontstyle", 7)
                        ElseIf TxtHeadStyleB.Checked = True Then
                            .AddWithValue("fontstyle", 5)
                        ElseIf TxtHeadStyleI.Checked = True Then
                            .AddWithValue("fontstyle", 6)
                        Else

                            .AddWithValue("fontstyle", 3)
                        End If
                    Else
                        If TxtHeadStyleB.Checked = True And TxtHeadStyleI.Checked = True Then
                            .AddWithValue("fontstyle", 4)
                        ElseIf TxtHeadStyleB.Checked = True Then
                            .AddWithValue("fontstyle", 1)
                        ElseIf TxtHeadStyleI.Checked = True Then
                            .AddWithValue("fontstyle", 2)
                        Else
                            .AddWithValue("fontstyle", 8)
                        End If
                    End If
                    .AddWithValue("align", TxtHeadAlign.Text)
                End With
                DBF.ExecuteNonQuery()
                DBF = Nothing
                MAINCON.Close()
            End If



            If TxtHeadApplytoall.Checked = True Then
                TxtHeadApplytoall.Checked = False
                SQlStr = " UPDATE printheadings SET "
                SQlStr = SQlStr & " fontcolor='" & TxtHeadFontColor.Text & "',"
                SQlStr = SQlStr & " fontname='" & TxtHeadFontName.Text & "',"
                SQlStr = SQlStr & " fontsize=" & TxtHeadFontSize.Value & ","

                If TxtHeadStyleU.Checked = True Then
                    If TxtHeadStyleB.Checked = True And TxtHeadStyleI.Checked = True Then
                        SQlStr = SQlStr & " fontstyle=7,"

                    ElseIf TxtHeadStyleB.Checked = True Then
                        SQlStr = SQlStr & " fontstyle=5,"
                    ElseIf TxtHeadStyleI.Checked = True Then
                        SQlStr = SQlStr & " fontstyle=6,"
                    Else

                        SQlStr = SQlStr & " fontstyle=3,"
                    End If
                Else
                    If TxtHeadStyleB.Checked = True And TxtHeadStyleI.Checked = True Then
                        SQlStr = SQlStr & " fontstyle=4,"
                    ElseIf TxtHeadStyleB.Checked = True Then
                        SQlStr = SQlStr & " fontstyle=1,"
                    ElseIf TxtHeadStyleI.Checked = True Then
                        SQlStr = SQlStr & " fontstyle=2,"
                    Else
                        SQlStr = SQlStr & " fontstyle=8,"
                    End If
                End If
                SQlStr = SQlStr & " align='" & TxtHeadAlign.Text & "' where schemename=N'" & txtSchemName.Text & "'"
                ExecuteSQLQuery(SQlStr)
            End If
            LoadReport()
        End If


    End Sub

    Private Sub txtheadingitems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtheadingitems.SelectedIndexChanged


        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SQLFcmd2 As New SqlClient.SqlCommand
            SQLFcmd2.Connection = SqlConn1
            SQLFcmd2.CommandText = "select * from printheadings where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & txtheadingitems.Text & "'"
            SQLFcmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd2.ExecuteReader
            While Sreader.Read()
                If Sreader("isvisible") = True Then
                    TxtHeadShow.Checked = True
                Else
                    TxtHeadShow.Checked = False
                End If
                TxtHeadDisplyText.Text = Sreader("headtext").ToString.Trim
                TxtHeadFontColor.Text = Sreader("fontcolor").ToString.Trim
                TxtHeadTop.Value = Sreader("ftop")
                TxtHeadLeft.Value = Sreader("fleft")
                TxtHeadWidth.Value = Sreader("width")
                TxtHeadHeight.Value = Sreader("height")
                TxtHeadFontName.Text = Sreader("fontname").ToString.Trim
                TxtHeadFontSize.Value = Sreader("fontsize")

                If Sreader("fontstyle") = 1 Then
                    TxtHeadStyleB.Checked = True
                    TxtHeadStyleI.Checked = False
                    TxtHeadStyleU.Checked = False
                ElseIf Sreader("fontstyle") = 2 Then
                    TxtHeadStyleB.Checked = False
                    TxtHeadStyleI.Checked = False
                    TxtHeadStyleU.Checked = True
                ElseIf Sreader("fontstyle") = 3 Then
                    TxtHeadStyleB.Checked = False
                    TxtHeadStyleI.Checked = False
                    TxtHeadStyleU.Checked = True
                ElseIf Sreader("fontstyle") = 4 Then
                    TxtHeadStyleB.Checked = True
                    TxtHeadStyleI.Checked = True
                    TxtHeadStyleU.Checked = False
                ElseIf Sreader("fontstyle") = 5 Then
                    TxtHeadStyleB.Checked = True
                    TxtHeadStyleI.Checked = False
                    TxtHeadStyleU.Checked = True
                ElseIf Sreader("fontstyle") = 6 Then
                    TxtHeadStyleB.Checked = False
                    TxtHeadStyleI.Checked = True
                    TxtHeadStyleU.Checked = True
                ElseIf Sreader("fontstyle") = 7 Then
                    TxtHeadStyleB.Checked = True
                    TxtHeadStyleI.Checked = True
                    TxtHeadStyleU.Checked = True
                Else
                    TxtHeadStyleB.Checked = False
                    TxtHeadStyleI.Checked = False
                    TxtHeadStyleU.Checked = False
                End If
                TxtHeadAlign.Text = Sreader("align").ToString.Trim
                Exit While
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim schemevalue As String
        schemevalue = InputBox("Plese Enter the Scheme Name ", "New Scheme ", "")
        If schemevalue.Length > 0 Then
            If txtSchemName.Items.Contains(schemevalue) = False Then
                If MsgBox("Do you want to create a new scheme ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    Try
                        Dim sqlStr As String = ""
                        sqlStr = "INSERT INTO [PrintingSettings]([PrinterName],[schemename],[Width],[Height],[IsLandScape],[fleft],[fright],[ftop],[fbuttom],[multi],[showsubtotals],[IsActive],[PaperName],[LeftLogoIsOn],[RightLogoIson],[Leftlogoleft],[Leftlogotop],[Leftlogowidth],[Leftlogoheight],[Rightlogoleft],[Rightlogotop],[Rightlogowidth],[Rightlogoheight],[leftlogopath],[rightlogopath],[MaxRowsPerPage],[RowHeight],[showpageno],[pagenotop],[pagenoleft],[pageformat],[IsrollPaper]) " _
                            & " (SELECT  [PrinterName],N'" & schemevalue & "' AS [schemename],[Width],[Height],[IsLandScape],[fleft],[fright],[ftop],[fbuttom],[multi],[showsubtotals],[IsActive],[PaperName],[LeftLogoIsOn],[RightLogoIson],[Leftlogoleft],[Leftlogotop],[Leftlogowidth],[Leftlogoheight],[Rightlogoleft],[Rightlogotop],[Rightlogowidth],[Rightlogoheight],[leftlogopath],[rightlogopath],[MaxRowsPerPage],[RowHeight],[showpageno],[pagenotop],[pagenoleft],[pageformat],[IsrollPaper] FROM printingsettings where schemename=N'" & txtSchemName.Text & "')"
                        ExecuteSQLQuery(sqlStr)

                        sqlStr = "INSERT INTO [PrintFieldLabels] ([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[databasevalue],[IsLedgerValue] ,[decimals] ,[supress],[Formulastr]) " _
                            & "(SELECT N'" & schemevalue & "' AS [SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[databasevalue],[IsLedgerValue] ,[decimals] ,[supress],Formulastr FROM printfieldlabels where schemename=N'" & txtSchemName.Text & "')"
                        ExecuteSQLQuery(sqlStr)

                        sqlStr = "INSERT INTO [PrintHeadings] ([schemename],[fTop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[fieldname],[Align],[fcase],[IsVisible],[HeadText]) " _
                            & "(SELECT N'" & schemevalue & "' AS [schemename],[fTop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[fieldname],[Align],[fcase],[IsVisible],[HeadText] from printheadings where schemename=N'" & txtSchemName.Text & "')"
                        ExecuteSQLQuery(sqlStr)

                        sqlStr = "INSERT INTO [PrintLables] ([schemename],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[fieldname],[labletext],[isvisible],[align]) " _
                            & "(SELECT N'" & schemevalue & "' AS [schemename],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[fieldname],[labletext],[isvisible],[align] from printlables where schemename=N'" & txtSchemName.Text & "')"
                        ExecuteSQLQuery(sqlStr)

                        sqlStr = "INSERT INTO [PrintLines] ([schemename],[ftop],[fleft],[width],[height],[fieldname],[FieldType],[LineColor],[BoarderStyle],[BoarderWidth],[IsVisible]) " _
                            & "(SELECT N'" & schemevalue & "' AS [schemename],[ftop],[fleft],[width],[height],[fieldname],[FieldType],[LineColor],[BoarderStyle],[BoarderWidth],[IsVisible] from printlines where schemename=N'" & txtSchemName.Text & "')"
                        ExecuteSQLQuery(sqlStr)

                        sqlStr = "INSERT INTO [PrintRecords] ([SchemeName],[Fieldname],[labletext],[ObjectType],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[Lcase],[Rcase],[lalign],[space],[DBType],[DBField],[FormatType],[decimals] ,	[supress],[Formulastr]) " _
                            & " (SELECT N'" & schemevalue & "' AS [SchemeName],[Fieldname],[labletext],[ObjectType],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[Lcase],[Rcase],[lalign],[space],[DBType],[DBField],[FormatType],[decimals] ,	[supress],Formulastr from printrecords where schemename=N'" & txtSchemName.Text & "')"

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
            PrintPreviewControl22.StartPage = PrintPreviewControl22.StartPage + 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UserButton5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevi.Click
        Try
            PrintPreviewControl22.StartPage = PrintPreviewControl22.StartPage - 1
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


            SqlStr = "INSERT INTO [PrintFieldLabels] ([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[databasevalue],[IsLedgerValue] ,[decimals] ,[supress]) " _
                & "(SELECT   [SchemeName],([Fieldname]+ '2') AS [Fieldname],[labletext],[DBField],'FALSE' AS [IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[databasevalue] ,[IsLedgerValue] ,[decimals] ,[supress] FROM printfieldlabels where schemename=N'" & txtSchemName.Text & "')"
            ExecuteSQLQuery(SqlStr)

            SqlStr = "INSERT INTO [PrintHeadings] ([schemename],[fTop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[fieldname],[Align],[fcase],[IsVisible],[HeadText]) " _
                & "(SELECT  [schemename],[fTop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],([Fieldname]+ '2') AS [fieldname],[Align],[fcase],'FALSE' AS [IsVisible],[HeadText] from printheadings where schemename=N'" & txtSchemName.Text & "')"
            ExecuteSQLQuery(SqlStr)

            SqlStr = "INSERT INTO [PrintLables] ([schemename],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[fieldname],[labletext],[isvisible],[align]) " _
                & "(SELECT  [schemename],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],([Fieldname]+ '2') AS [fieldname],[labletext],'FALSE' AS [IsVisible],[align] from printlables where schemename=N'" & txtSchemName.Text & "')"
            ExecuteSQLQuery(SqlStr)

            SqlStr = "INSERT INTO [PrintLines] ([schemename],[ftop],[fleft],[width],[height],[fieldname],[FieldType],[LineColor],[BoarderStyle],[BoarderWidth],[IsVisible]) " _
                & "(SELECT  [schemename],[ftop],[fleft],[width],[height],([Fieldname]+ '2') AS [fieldname],[FieldType],[LineColor],[BoarderStyle],[BoarderWidth],'FALSE' AS [IsVisible] from printlines where schemename=N'" & txtSchemName.Text & "')"
            ExecuteSQLQuery(SqlStr)

            SqlStr = "INSERT INTO [PrintRecords] ([SchemeName],[Fieldname],[labletext],[ObjectType],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[Lcase],[Rcase],[lalign],[space],[DBType],[DBField],[FormatType],[decimals] ,	[supress]) " _
                & " (SELECT   [SchemeName],([Fieldname]+ '2') AS [Fieldname],[labletext],[ObjectType],'FALSE' AS [IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[Lcase],[Rcase],[lalign],[space],[DBType],[DBField],[FormatType],[decimals] ,	[supress] from printrecords where schemename=N'" & txtSchemName.Text & "')"

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
        Dim r As Integer = 0
        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SQLFcmd2 As New SqlClient.SqlCommand
            SQLFcmd2.Connection = SqlConn1
            SQLFcmd2.CommandText = "select * from PrintingSchemes where vouchername=N'" & TxtDefInvoiceList.Text & "'"
            SQLFcmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd2.ExecuteReader
            While Sreader.Read()
                r = TxtGridList.Rows.Add()
                If Sreader("isactive") = 1 Then
                    TxtGridList.Item(0, r).Value = Sreader("id")
                    TxtGridList.Item(1, r).Value = Sreader("schemename").ToString.Trim
                    TxtGridList.Item(2, r).Value = "YES"
                    TxtGridList.Item(3, r).Value = Sreader("NoofCopies").ToString.Trim
                    'NoofCopies
                Else
                    TxtGridList.Item(0, r).Value = Sreader("id")
                    TxtGridList.Item(1, r).Value = Sreader("schemename").ToString.Trim
                    TxtGridList.Item(2, r).Value = "NO"
                    TxtGridList.Item(3, r).Value = Sreader("NoofCopies").ToString.Trim
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
    Private Sub UserButton42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton42.Click
        If TxtDefInvoiceList.Text.Length = 0 Then
            MsgBox("Please Select the Invoice Type..")
            TxtDefInvoiceList.Focus()
        End If
        If TxtInvoiceSchameList.Text.Length = 0 Then Exit Sub

        If SQLIsFieldExists("SELECT TOP 1 1 from   PrintingSchemes where schemename=N'" & TxtInvoiceSchameList.Text & "' and vouchername=N'" & TxtDefInvoiceList.Text & "'") = True Then
            MsgBox("The Scheme Name is already exist....             ", MsgBoxStyle.Information)
            Exit Sub
        Else
            Dim idvalue As Integer
            idvalue = SQLGetNumericFieldValue("select max(ID) as val from PrintingSchemes", "val") + 1
            Dim Sqlstr As String = ""
            Sqlstr = "INSERT INTO [PrintingSchemes] ([SchemeName],[VoucherName],[IsActive],[ID],[SchemeType],NoofCopies) VALUES "
            Sqlstr = Sqlstr & "(N'" & TxtInvoiceSchameList.Text & "',N'" & TxtDefInvoiceList.Text & "',0," & idvalue & ",1,1) "
            ExecuteSQLQuery(Sqlstr)
            LoadInvoiceTypeSchemes()
        End If


    End Sub


    Private Sub UserButton40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton40.Click
        If TxtDefInvoiceList.Text.Length = 0 Then
            MsgBox("Please Select the Invoice Type..              ")
            TxtDefInvoiceList.Focus()
        End If
        If TxtGridList.SelectedRows.Count > 0 Then
            If MsgBox("Do you want to  selected scheme Name as Default Secheme (Y/N)?  ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("update PrintingSchemes set isactive=0 where vouchername=N'" & TxtDefInvoiceList.Text & "'")
                ExecuteSQLQuery("update PrintingSchemes set isactive=1 where schemename=N'" & TxtGridList.Item(1, TxtGridList.CurrentRow.Index).Value & "' and vouchername=N'" & TxtDefInvoiceList.Text & "'")
                'NoofCopies
            End If

            LoadInvoiceTypeSchemes()
        Else
            MsgBox("Please Select the Scheme Name from the list....   ")
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
                ExecuteSQLQuery("delete  from PrintingSchemes where schemename=N'" & TxtGridList.Item(1, TxtGridList.CurrentRow.Index).Value & "' and vouchername=N'" & TxtDefInvoiceList.Text & "'")
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


    Private Sub Label99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label99.Click

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblExport.LinkClicked
        If txtSchemName.Text.Length = 0 Then
            MsgBox("Please Select the Scheme Name...        ")
            Exit Sub
        End If
        Dim frm As New SaveFileDialog

        If frm.ShowDialog() = vbOK Then
            Dim Filename As String = ""
            Dim FileName3 As String = ""
            Filename = frm.FileName & ".dat"
            Try
                Dim fs As FileStream = File.Create(Filename)
                fs.Close()
                fs = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            Dim TextLine As String = ""
            Dim Line As String = ""
            Dim SqlConn2 As New SqlClient.SqlConnection
            Try
                SqlConn2.ConnectionString = ConnectionStrinG
                SqlConn2.Open()
                Dim SQLFcmd2 As New SqlClient.SqlCommand
                SQLFcmd2.Connection = SqlConn2
                SQLFcmd2.CommandText = "select * from PrintFieldLabels where schemename=N'" & txtSchemName.Text & "'"
                SQLFcmd2.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd2.ExecuteReader
                Line = ""
                While Sreader.Read()

                    Line = ""
                    Line = Line & "'&SSSName&','"
                    Line = Line & Sreader("Fieldname").ToString.Trim & "','"
                    Line = Line & Sreader("labletext").ToString.Trim & "','"
                    Line = Line & Sreader("DBField").ToString.Trim & "','"
                    Line = Line & Sreader("IsVisible").ToString.Trim & "',"
                    Line = Line & Sreader("ftop") & ","
                    Line = Line & Sreader("fleft") & ","
                    Line = Line & Sreader("width") & ","
                    Line = Line & Sreader("height") & ",'"
                    Line = Line & Sreader("Fontname").ToString.Trim & "',"
                    Line = Line & Sreader("fontsize") & ","
                    Line = Line & Sreader("fontstyle") & ",'"
                    Line = Line & Sreader("fontcolor").ToString.Trim & "','"
                    Line = Line & Sreader("Align").ToString.Trim & "',"
                    Line = Line & Sreader("lTop") & ","
                    Line = Line & Sreader("lleft") & ","
                    Line = Line & Sreader("lwidth") & ","
                    Line = Line & Sreader("lheight") & ",'"
                    Line = Line & Sreader("lFontname").ToString.Trim & "',"
                    Line = Line & Sreader("lfontsize") & ","
                    Line = Line & Sreader("lfontstyle") & ",'"
                    Line = Line & Sreader("lfontcolor") & "','"
                    Line = Line & Sreader("lalign").ToString.Trim & "','"
                    Line = Line & Sreader("sample").ToString.Trim & "',"
                    Line = Line & Sreader("DBType") & ","
                    Line = Line & Sreader("FieldType") & ",'"
                    Line = Line & Sreader("PrintText") & "',"
                    Line = Line & Sreader("FormatType") & ","
                    Line = Line & Sreader("DatabaseValue") & ","
                    If IsDBNull(Sreader("IsLedgerValue")) = True Then
                        Line = Line & "0" & ","
                    Else
                        Line = Line & Sreader("IsLedgerValue") & ","
                    End If

                    Line = Line & Sreader("decimals") & ","
                    Line = Line & Sreader("supress")
                    Line = Line & ",N'" & Sreader("Formulastr") & "'"

                    TextLine = TextLine & "INSERT INTO [PrintFieldLabels]([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height]," _
                        & " [Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle]," _
                        & "[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[DatabaseValue],[IsLedgerValue],[decimals] ,[supress],[Formulastr]) VALUES (" & Line & ")" & vbCrLf
                    FileName3 = FileName3 & Line & vbCrLf
                End While
                Sreader.Close()
                Sreader = Nothing
                SQLFcmd2.Connection = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SqlConn2.Close()

            End Try



            Try
                SqlConn2.ConnectionString = ConnectionStrinG
                SqlConn2.Open()
                Dim SQLFcmd2 As New SqlClient.SqlCommand
                SQLFcmd2.Connection = SqlConn2
                SQLFcmd2.CommandText = "select * from PrintHeadings where schemename=N'" & txtSchemName.Text & "'"
                SQLFcmd2.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd2.ExecuteReader
                Line = ""
                While Sreader.Read()

                    Line = ""
                    Line = Line & "'&SSSName&',"
                    Line = Line & Sreader("ftop") & ","
                    Line = Line & Sreader("fleft") & ","
                    Line = Line & Sreader("width") & ","
                    Line = Line & Sreader("height") & ",'"
                    Line = Line & Sreader("Fontname").ToString.Trim & "',"
                    Line = Line & Sreader("fontsize") & ","
                    Line = Line & Sreader("fontstyle") & ",'"
                    Line = Line & Sreader("fontcolor").ToString.Trim & "','"
                    Line = Line & Sreader("fieldname").ToString.Trim & "','"
                    Line = Line & Sreader("Align").ToString.Trim & "','"
                    Line = Line & Sreader("fcase").ToString.Trim & "','"
                    Line = Line & Sreader("IsVisible").ToString.Trim & "','"
                    Line = Line & Sreader("HeadText").ToString.Trim & "'"

                    TextLine = TextLine & "INSERT INTO [PrintHeadings] ([schemename],[fTop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[fieldname],[Align],[fcase]," _
                        & " [IsVisible],[HeadText]) VALUES (" & Line & ")" & vbCrLf
                    FileName3 = FileName3 & Line & vbCrLf
                End While
                Sreader.Close()
                Sreader = Nothing
                SQLFcmd2.Connection = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SqlConn2.Close()
            End Try




            Try
                SqlConn2.ConnectionString = ConnectionStrinG
                SqlConn2.Open()
                Dim SQLFcmd2 As New SqlClient.SqlCommand
                SQLFcmd2.Connection = SqlConn2
                SQLFcmd2.CommandText = "select * from PrintRecords where schemename=N'" & txtSchemName.Text & "'"
                SQLFcmd2.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd2.ExecuteReader
                Line = ""
                While Sreader.Read()

                    Line = ""
                    Line = Line & "'&SSSName&','"
                    Line = Line & Sreader("Fieldname").ToString.Trim & "','"
                    Line = Line & Sreader("labletext").ToString.Trim & "','"
                    Line = Line & Sreader("ObjectType").ToString.Trim & "','"
                    Line = Line & Sreader("IsVisible").ToString.Trim & "',"
                    Line = Line & Sreader("ftop") & ","
                    Line = Line & Sreader("fleft") & ","
                    Line = Line & Sreader("width") & ","
                    Line = Line & Sreader("height") & ",'"
                    Line = Line & Sreader("Fontname").ToString.Trim & "',"
                    Line = Line & Sreader("fontsize") & ","
                    Line = Line & Sreader("fontstyle") & ",'"
                    Line = Line & Sreader("fontcolor").ToString.Trim & "','"
                    Line = Line & Sreader("Align").ToString.Trim & "',"
                    Line = Line & Sreader("lTop") & ","
                    Line = Line & Sreader("lleft") & ","
                    Line = Line & Sreader("lwidth") & ","
                    Line = Line & Sreader("lheight") & ",'"
                    Line = Line & Sreader("lFontname").ToString.Trim & "',"
                    Line = Line & Sreader("lfontsize") & ","
                    Line = Line & Sreader("lfontstyle") & ",'"
                    Line = Line & Sreader("lfontcolor") & "','"
                    Line = Line & Sreader("Lcase") & "','"
                    Line = Line & Sreader("Rcase") & "','"
                    Line = Line & Sreader("lalign").ToString.Trim & "',"
                    Line = Line & Sreader("space").ToString.Trim & ","
                    Line = Line & Sreader("DBType").ToString.Trim & ",'"
                    Line = Line & Sreader("DBField").ToString.Trim & "',"
                    Line = Line & Sreader("FormatType").ToString.Trim & ","
                    Line = Line & Sreader("decimals").ToString.Trim & ","
                    Line = Line & Sreader("supress").ToString.Trim
                    Line = Line & ",N'" & Sreader("Formulastr") & "'"
                    TextLine = TextLine & "INSERT INTO [PrintRecords] ([SchemeName],[Fieldname],[labletext],[ObjectType],[IsVisible],[ftop],[fleft],[width],[height]," _
                        & "[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor]," _
                        & "[Lcase],[Rcase],[lalign],[space],[DBType],[DBField],[FormatType],[decimals] ,	[supress],[Formulastr]) VALUES (" & Line & ")" & vbCrLf
                    FileName3 = FileName3 & Line & vbCrLf
                End While
                Sreader.Close()
                Sreader = Nothing
                SQLFcmd2.Connection = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SqlConn2.Close()

            End Try





            Try
                SqlConn2.ConnectionString = ConnectionStrinG
                SqlConn2.Open()
                Dim SQLFcmd2 As New SqlClient.SqlCommand
                SQLFcmd2.Connection = SqlConn2
                SQLFcmd2.CommandText = "select * from PrintingSettings where schemename=N'" & txtSchemName.Text & "'"
                SQLFcmd2.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd2.ExecuteReader
                Line = ""
                While Sreader.Read()

                    Line = ""
                    Line = Line & "N'" & Sreader("PrinterName").ToString & "',"
                    Line = Line & "'&SSSName&',"
                    Line = Line & Sreader("Width") & ","
                    Line = Line & Sreader("Height") & ",'"
                    Line = Line & Sreader("IsLandScape") & "',"
                    Line = Line & Sreader("fleft") & ","
                    Line = Line & Sreader("fright") & ","
                    Line = Line & Sreader("ftop") & ","
                    Line = Line & Sreader("fbuttom") & ",'"
                    Line = Line & Sreader("multi") & "','"
                    Line = Line & Sreader("showsubtotals") & "','"
                    Line = Line & Sreader("IsActive") & "','"
                    Line = Line & Sreader("PaperName").ToString.Trim & "','"
                    Line = Line & Sreader("LeftLogoIsOn") & "','"
                    Line = Line & Sreader("RightLogoIson") & "',"
                    Line = Line & Sreader("Leftlogoleft") & ","
                    Line = Line & Sreader("Leftlogotop") & ","
                    Line = Line & Sreader("Leftlogowidth") & ","
                    Line = Line & Sreader("Leftlogoheight") & ","
                    Line = Line & Sreader("Rightlogoleft") & ","
                    Line = Line & Sreader("Rightlogotop") & ","
                    Line = Line & Sreader("Rightlogowidth") & ","
                    Line = Line & Sreader("Rightlogoheight") & ",'"
                    Line = Line & Sreader("leftlogopath") & "','"
                    Line = Line & Sreader("rightlogopath") & "',"

                    Line = Line & Sreader("MaxRowsPerPage") & ","
                    Line = Line & Sreader("RowHeight") & ",'"
                    Line = Line & Sreader("showpageno") & "',"
                    Line = Line & Sreader("pagenotop") & ","
                    Line = Line & Sreader("pagenoleft") & ","
                    Line = Line & Sreader("pageformat") & ",N'" & Sreader("IsrollPaper") & "' "

                    TextLine = TextLine & "INSERT INTO [PrintingSettings] ([PrinterName],[schemename],[Width],[Height],[IsLandScape],[fleft],[fright],[ftop],[fbuttom],[multi]," _
                        & " [showsubtotals],[IsActive],[PaperName],[LeftLogoIsOn],[RightLogoIson],[Leftlogoleft],[Leftlogotop],[Leftlogowidth],[Leftlogoheight]," _
                        & "[Rightlogoleft],[Rightlogotop],[Rightlogowidth],[Rightlogoheight],[leftlogopath],[rightlogopath],[MaxRowsPerPage],[RowHeight]," _
                        & "[showpageno],[pagenotop],[pagenoleft],[pageformat],[IsrollPaper] ) VALUES (" & Line & ")" & vbCrLf
                    FileName3 = FileName3 & Line & vbCrLf

                   

                End While
                Sreader.Close()
                Sreader = Nothing
                SQLFcmd2.Connection = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SqlConn2.Close()
            End Try



            Try
                SqlConn2.ConnectionString = ConnectionStrinG
                SqlConn2.Open()
                Dim SQLFcmd2 As New SqlClient.SqlCommand
                SQLFcmd2.Connection = SqlConn2
                SQLFcmd2.CommandText = "select * from PrintLables where schemename=N'" & txtSchemName.Text & "'"
                SQLFcmd2.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd2.ExecuteReader
                Line = ""
                While Sreader.Read()

                    Line = ""
                    Line = Line & "'&SSSName&',"
                    Line = Line & Sreader("ftop") & ","
                    Line = Line & Sreader("fleft") & ","
                    Line = Line & Sreader("width") & ","
                    Line = Line & Sreader("height") & ",'"
                    Line = Line & Sreader("Fontname") & "',"
                    Line = Line & Sreader("fontsize") & ","
                    Line = Line & Sreader("fontstyle") & ",'"
                    Line = Line & Sreader("fontcolor") & "','"
                    Line = Line & Sreader("fieldname") & "','"
                    Line = Line & Sreader("labletext") & "','"
                    Line = Line & Sreader("isvisible") & "','"
                    Line = Line & Sreader("align") & "'"

                    TextLine = TextLine & "INSERT INTO [PrintLables]([schemename],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor]," _
                        & " [fieldname],[labletext],[isvisible],[align])  VALUES (" & Line & ")" & vbCrLf
                    FileName3 = FileName3 & Line & vbCrLf
                End While
                Sreader.Close()
                Sreader = Nothing
                SQLFcmd2.Connection = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SqlConn2.Close()
            End Try



            '"INSERT INTO [PrintLines]([schemename],[ftop],[fleft],[width],[height],[fieldname],[FieldType],[LineColor],[BoarderStyle],[BoarderWidth],[IsVisible]) VALUES (" & line & ")"
            Try
                SqlConn2.ConnectionString = ConnectionStrinG
                SqlConn2.Open()
                Dim SQLFcmd2 As New SqlClient.SqlCommand
                SQLFcmd2.Connection = SqlConn2
                SQLFcmd2.CommandText = "select * from PrintLines where schemename=N'" & txtSchemName.Text & "'"
                SQLFcmd2.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd2.ExecuteReader
                Line = ""
                While Sreader.Read()

                    Line = ""
                    Line = Line & "'&SSSName&',"
                    Line = Line & Sreader("ftop") & ","
                    Line = Line & Sreader("fleft") & ","
                    Line = Line & Sreader("width") & ","
                    Line = Line & Sreader("height") & ",'"
                    Line = Line & Sreader("fieldname") & "',"
                    Line = Line & Sreader("FieldType") & ",'"
                    Line = Line & Sreader("LineColor") & "','"
                    Line = Line & Sreader("BoarderStyle") & "',"
                    Line = Line & Sreader("BoarderWidth") & ",'"
                    Line = Line & Sreader("isvisible") & "'"
                    TextLine = TextLine & "INSERT INTO [PrintLines]([schemename],[ftop],[fleft],[width],[height],[fieldname],[FieldType]," _
                        & "[LineColor],[BoarderStyle],[BoarderWidth],[IsVisible]) VALUES (" & Line & ")" & vbCrLf
                    FileName3 = FileName3 & Line & vbCrLf
                End While
                Sreader.Close()
                Sreader = Nothing
                SQLFcmd2.Connection = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SqlConn2.Close()
            End Try
            SqlConn2.Dispose()
            Using sw As StreamWriter = New StreamWriter(Filename)
                sw.WriteLine(TextLine)
            End Using
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblImport.LinkClicked
        Dim frm As New OpenFileDialog
        If frm.ShowDialog() = vbOK Then
            If frm.FileName.ToString.Length = 0 Then Exit Sub
            Dim SchName As String = ""
XX:         SchName = InputBox("Please Enter the New Scheme Name ", "Scheme Name", "")
            If SchName.Length = 0 Then
                If MsgBox("Please Enter the Scheme Name , Do you want to try again ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                GoTo XX
            End If
            If txtSchemName.Items.Contains(SchName) = False Then
                If MsgBox("Do you want to create a new scheme ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then

                    If ImportNewScheme(SchName, frm.FileName.ToString) = True Then
                        MsgBox("Import is success                               ")
                    End If
                    txtSchemName.Items.Add(SchName)
                    TxtInvoiceSchameList.Items.Add(SchName)
                End If
            Else
                If MsgBox("the Scheme Name is already Exists , Do you want to try again ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                GoTo XX
            End If

        End If



    End Sub
    Function ImportNewScheme(ByVal newschemename As String, ByVal Fname As String) As Boolean
        Try

            Using sr As StreamReader = New StreamReader(Fname)
                Dim line As String
                line = sr.ReadLine()
                Do While (Not line Is Nothing)
                    If line.Length > 0 Then
                        line = line.Replace("&SSSName&", newschemename)
                        If ExecuteSQLQuery(line) = False Then
                            Return False
                            Exit Function
                        End If
                    End If
                    line = sr.ReadLine
                Loop
                sr.Close()
            End Using
            Return True
        Catch Ex As Exception
            Return False
            ' Let the user know what went wrong.
            MsgBox("The file could not be read, it may not exists, Please consult your adimn")
            MsgBox(Ex.Message)
        End Try
    End Function

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If MsgBox("Do you want to Save the Printer Name for all Schemes ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        ExecuteSQLQuery("UPDATE printingsettings SET printername=N'" & TxtPrinterName.Text & "'")
    End Sub


    Private Sub PrintPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        ' PrintPriviewSet(sender, e, txtSchemName.Text, "PrintingDataRowsItems", "PrintDataDetails")
        ' PrtDoc.DefaultPageSettings.PaperSize = New PaperSize("Custom", TxtPaperWidth.Text, TxtPaperHeight.Text)

        Dim IsFirstOpen As Boolean = True
        Dim pagerecords As Integer = 0
        Dim PresentRecords As Integer = 0
        Dim PageTop As Double = 0
        Dim PageSpace As Double = 0
        Dim RowHeight As Double = 0
        Dim PageNos As Integer = 1
        Dim PageNo As Integer = 1
        Dim Pagenoformat As Byte = 0
        Dim isPageNoyesno As Boolean = True
        Dim PageTopConst As Double = 0
        Dim FooterTop As Integer = 0
        Dim RowNo As Integer = 0
        Dim PageTotal As Double = 0
        Dim dbname As String = ""
        Dim Dbitemsname As String = ""

        dbname = "PrintDataDetails"
        Dbitemsname = "PrintingDataRowsItems"
        Dim Dbf As New ADODB.Recordset

        RowHeight = SQLGetNumericFieldValue("select rowheight from PrintingSettings where schemename=N'" & txtSchemName.Text & "'", "rowheight")
        PresentRecords = 1
        pagerecords = 5

        PageTop = SQLGetNumericFieldValue("select ftop from printrecords where schemename=N'" & txtSchemName.Text & "'", "ftop")
        PageSpace = SQLGetNumericFieldValue("select space from printrecords where schemename=N'" & txtSchemName.Text & "'", "space")
        FooterTop = PageTop + SQLGetNumericFieldValue("select height from printrecords where schemename=N'" & txtSchemName.Text & "'", "height")
        IsCashBill = False
        PageTopConst = PageTop
        RowNo = 0

        If PrtData.Tables(0).Rows.Count < pagerecords Then
            pagerecords = PrtData.Tables(0).Rows.Count
        End If
        PageNos = Math.Ceiling(PrtData.Tables(0).Rows.Count / pagerecords)
        PageNo = 1

        Dim SqlStr1 As String = ""
        Dim lEDGERnAME As String = ""
        Dim drawFormat21 As New StringFormat
        Dim drawFont21 As Font = New Font("arial", 11)
        Dim drawBrush21 As New SolidBrush(Color.Gray)
        Dim rect21 As New Rectangle(10, 10, sender.Width, sender.Height)
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
            SQLFcmd.CommandText = "select * from printingsettings where schemename=N'" & txtSchemName.Text & "'"
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
            SQLFcmd.CommandText = "select * from PrintLables where schemename=N'" & txtSchemName.Text & "'"
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
            SQLFcmd.CommandText = "select * from printheadings where schemename=N'" & txtSchemName.Text & "'"
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
            SQLFcmd.CommandText = "select * from printlines where schemename=N'" & txtSchemName.Text & "'"
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


        Dim SqlStr2 As String = ""
        If PageNo = PageNos Then
            SqlStr2 = "select * from PrintFieldLabels where schemename=N'" & txtSchemName.Text & "' "
        Else
            SqlStr2 = "select * from PrintFieldLabels where schemename=N'" & txtSchemName.Text & "' and ltop<" & FooterTop
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
            SQLFcmd.CommandText = "select * from Printrecords where schemename=N'" & txtSchemName.Text & "'"
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




        'haha
        For ri As Integer = 0 To pagerecords - 1
            Try
                Dim k As String = PrtData.Tables(0).Rows(RowNo).Item("stockname").ToString

            Catch ex As Exception
                GoTo SSS
            End Try

            Dim SqlConn6 As New SqlClient.SqlConnection
            Try
                SqlConn6.ConnectionString = ConnectionStrinG
                SqlConn6.Open()
                SQLFcmd.Connection = SqlConn6
                SQLFcmd.CommandText = "select * from Printrecords where schemename=N'" & txtSchemName.Text & "'"
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
                        If UCase(Sreader("DBField").ToString.Trim) <> "SNO" Then
                            If Sreader("formattype") = 0 Then
                                e.Graphics.DrawString(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                            Else
                                e.Graphics.DrawString(FormatNumber(PrtData.Tables(0).Rows(RowNo).Item(Sreader("DBField").ToString.Trim).ToString, ErpDecimalPlaces).ToString, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
                            End If
                        Else
                            e.Graphics.DrawString(PresentRecords, drawFont, drawBrush, CSng(Sreader("fleft")), PageTop, drawFormat)
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


            Try
                PageTotal = PageTotal + PrtData.Tables(0).Rows(RowNo).Item("StockAmount").ToString
                PageTop = PageTop + RowHeight
                RowNo = RowNo + 1
                PresentRecords = PresentRecords + 1
            Catch ex As Exception
                PresentRecords = PrtData.Tables(0).Rows.Count
                GoTo sss
            End Try

        Next



sss:




    End Sub

    Private Sub Panel5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub



    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        ReDrawCtrl()
    End Sub
    Sub ReDrawCtrl()

    End Sub

    Private Sub FindPositionCtrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Up Then
            If sender.top - 1 >= 0 Then
                sender.top = sender.top - 1
            End If

        ElseIf e.KeyCode = Keys.Down Then
            If sender.top + 1 <= sender.Parent.Height Then
                sender.top = sender.top + 1
            End If
        ElseIf e.KeyCode = Keys.Left Then
            If sender.left - 1 >= 0 Then
                sender.left = sender.left - 1
            End If
        ElseIf e.KeyCode = Keys.Right Then
            If sender.left + 1 >= 0 And sender.left + 1 <= sender.Parent.Width Then
                sender.left = sender.left + 1
            End If

        End If
    End Sub


    Sub SaveIndex1data()
        Dim Sqlstr As String = ""
        Sqlstr = "UPDATE PrintFieldLabels SET "
        Sqlstr = Sqlstr & "ltop=" & TxtFLtop.Value & ","
        Sqlstr = Sqlstr & "lleft=" & TxtFLLeft.Value & ","
        Sqlstr = Sqlstr & "lwidth=" & TxtFLWidth.Value & ","
        Sqlstr = Sqlstr & "lheight=" & TxtFLHeight.Value & ","
        Sqlstr = Sqlstr & "lfontname='" & TxtFLFont.Text & "',"
        Sqlstr = Sqlstr & "lfontsize=" & TxtFLFontSize.Value & ","
        Sqlstr = Sqlstr & "ftop=" & TxtFLFTop.Value & ","
        Sqlstr = Sqlstr & "fleft=" & TxtFLFLeft.Value & ","
        Sqlstr = Sqlstr & "width=" & TxtFLFwidth.Value & ","
        Sqlstr = Sqlstr & "height=" & TxtFLFHeight.Value
        Sqlstr = Sqlstr & "  where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtFieldLables.Text & "'"
        ExecuteSQLQuery(Sqlstr)

    End Sub

    Private Sub TxtPaperHeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPaperHeight.TextChanged

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub


    Sub SaveLables()
        If SQLIsFieldExists("SELECT TOP 1 1 from   PrintLables where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtLabelLists.Text & "'") = True Then
            'update
            Dim SQlstr As String = ""
            SQlstr = "UPDATE PrintLables  SET "
            SQlstr = SQlstr & " schemename='" & txtSchemName.Text & "',"
            SQlstr = SQlstr & " fieldname='" & TxtLabelLists.Text & "',"
            SQlstr = SQlstr & " labletext=N'" & txtLtext.Text & "',"
            SQlstr = SQlstr & " fontcolor='" & TxtLFontColor.Text & "',"
            SQlstr = SQlstr & " ftop=" & TxtLtop.Value & ","
            SQlstr = SQlstr & " fleft=" & TxtLleft.Value & ","
            SQlstr = SQlstr & " width=" & TxtLwidth.Value & ","
            SQlstr = SQlstr & " height=" & TxtLHeight.Value & ","
            SQlstr = SQlstr & " fontsize=" & TxtLFontSize.Value & ","
            SQlstr = SQlstr & " fontname='" & TxtLFontName.Text & "',"
            If TxtLShow.Checked = True Then
                SQlstr = SQlstr & " isvisible='True',"
            Else
                SQlstr = SQlstr & " isvisible='False',"
            End If

            If TxtLStyleU.Checked = True Then
                If TxtLStyleB.Checked = True And TxtLStyleI.Checked = True Then
                    SQlstr = SQlstr & " fontstyle=7,"
                ElseIf TxtLStyleB.Checked = True Then
                    SQlstr = SQlstr & " fontstyle=5,"
                ElseIf TxtLStyleI.Checked = True Then
                    SQlstr = SQlstr & " fontstyle=6,"
                Else

                    SQlstr = SQlstr & " fontstyle=3,"
                End If
            Else
                If TxtLStyleB.Checked = True And TxtLStyleI.Checked = True Then
                    SQlstr = SQlstr & " fontstyle=4,"
                ElseIf TxtLStyleB.Checked = True Then
                    SQlstr = SQlstr & " fontstyle=1,"
                ElseIf TxtLStyleI.Checked = True Then
                    SQlstr = SQlstr & " fontstyle=2,"
                Else
                    SQlstr = SQlstr & " fontstyle=8,"
                End If
            End If

            SQlstr = SQlstr & " align='" & TxtLFontAlign.Text & "' where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtLabelLists.Text & "'"
            ExecuteSQLQuery(SQlstr)


            'SQlstr = SQlstr & " schemename=N'" & txtSchemName.Text & "',"

        Else
            Dim sqlsTR As String = ""
            sqlsTR = " INSERT INTO [PrintLables] ([schemename],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor], " _
                & " [fieldname],[labletext],[isvisible],[align])     VALUES " _
                & "(@schemename,@ftop,@fleft,@width,@height,@Fontname,@fontsize,@fontstyle,@fontcolor,@fieldname,@labletext,@isvisible,@align) "

            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand(sqlsTR, MAINCON)
            With DBF.Parameters
                .AddWithValue("schemename", txtSchemName.Text)
                .AddWithValue("fieldname", TxtLabelLists.Text)
                .AddWithValue("labletext", txtLtext.Text)
                If TxtLShow.Checked = True Then
                    .AddWithValue("isvisible", "True")
                Else
                    .AddWithValue("isvisible", "False")
                End If

                .AddWithValue("fontcolor", TxtLFontColor.Text)

                .AddWithValue("ftop", TxtLtop.Value)
                .AddWithValue("fleft", TxtLleft.Value)
                .AddWithValue("width", TxtLwidth.Value)
                .AddWithValue("height", TxtLHeight.Value)
                .AddWithValue("fontname", TxtLFontName.Text)
                .AddWithValue("fontsize", TxtLFontSize.Value)

                If TxtLStyleU.Checked = True Then
                    If TxtLStyleB.Checked = True And TxtLStyleI.Checked = True Then
                        .AddWithValue("fontstyle", 7)
                    ElseIf TxtLStyleB.Checked = True Then
                        .AddWithValue("fontstyle", 5)
                    ElseIf TxtLStyleI.Checked = True Then
                        .AddWithValue("fontstyle", 6)
                    Else

                        .AddWithValue("fontstyle", 3)
                    End If
                Else
                    If TxtLStyleB.Checked = True And TxtLStyleI.Checked = True Then
                        .AddWithValue("fontstyle", 4)
                    ElseIf TxtLStyleB.Checked = True Then
                        .AddWithValue("fontstyle", 1)
                    ElseIf TxtLStyleI.Checked = True Then
                        .AddWithValue("fontstyle", 2)
                    Else
                        .AddWithValue("fontstyle", 8)
                    End If
                End If


                .AddWithValue("align", TxtLFontAlign.Text)
            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
        End If
    End Sub
    Sub SaveRecordFileds()
        Dim gr As New Font(TxtRFontname.Text, CSng(TxtRFontSize.Value), FontStyle.Bold)
        Dim m As Integer
        Dim rh As Integer
        m = gr.GetHeight()
        gr.Dispose()
        rh = m + TxtLineSpecing.Value
        m = TxtRFHeight.Value / (m + TxtLineSpecing.Value)
        ExecuteSQLQuery("UPDATE PrintingSettings SET maxrowsperpage=" & m & ", rowheight=" & rh & "  where schemename=N'" & txtSchemName.Text & "'")
        ExecuteSQLQuery("UPDATE printrecords SET [fTop]=" & TxtRtop.Value & ",height=" & TxtRFHeight.Value & ",ltop=" & TxtRlTop.Value & ",space=" & TxtLineSpecing.Value & "  where schemename=N'" & txtSchemName.Text & "'")

        Dim SqlStr As String = ""
        SqlStr = "UPDATE printrecords SET "
        SqlStr = SqlStr & " labletext=N'" & TxtRlText.Text & "',"
        SqlStr = SqlStr & " lfontname='" & TxtRlfontname.Text & "',"
        SqlStr = SqlStr & " lfontcolor='" & TxtRlfontcolor.Text & "',"
        SqlStr = SqlStr & " fontcolor='" & TxtRfontColor.Text & "',"
        SqlStr = SqlStr & " fontname='" & TxtRFontname.Text & "',"
        SqlStr = SqlStr & " Rcase='" & TxtRCase.Text & "',"
        SqlStr = SqlStr & " align='" & TxtRAlign.Text & "',"
        SqlStr = SqlStr & " Lcase='" & TxtRlCase.Text & "',"
        SqlStr = SqlStr & " lalign='" & TxtRlalign.Text & "',"


        If TxtRShow.Checked = True Then
            SqlStr = SqlStr & " isvisible='True',"
        Else
            SqlStr = SqlStr & " isvisible='False',"
        End If
        SqlStr = SqlStr & " lleft=" & TxtRlLeft.Value & ","
        SqlStr = SqlStr & " lwidth=" & TxtRlwidth.Value & ","
        SqlStr = SqlStr & " lfontsize=" & TxtRlfontsize.Value & ","
        SqlStr = SqlStr & " fleft=" & TxtRFleft.Value & ","
        SqlStr = SqlStr & " width=" & TxtRwidht.Value & ","

        If TxtRlStyleU.Checked = True Then
            If TxtRlstyelB.Checked = True And TxtRlStyleI.Checked = True Then
                SqlStr = SqlStr & " Lfontstyle=7,"

            ElseIf TxtRlstyelB.Checked = True Then
                SqlStr = SqlStr & " Lfontstyle=5,"
            ElseIf TxtRlStyleI.Checked = True Then
                SqlStr = SqlStr & " Lfontstyle=6,"
            Else

                SqlStr = SqlStr & " Lfontstyle=3,"
            End If
        Else
            If TxtRlstyelB.Checked = True And TxtRlStyleI.Checked = True Then
                SqlStr = SqlStr & " Lfontstyle=4,"
            ElseIf TxtRlstyelB.Checked = True Then
                SqlStr = SqlStr & " Lfontstyle=1,"
            ElseIf TxtRlStyleI.Checked = True Then
                SqlStr = SqlStr & " Lfontstyle=2,"
            Else
                SqlStr = SqlStr & " Lfontstyle=8,"
            End If
        End If

        If TxtRStyleU.Checked = True Then
            If txtRStyleB.Checked = True And TxtRStyleI.Checked = True Then
                SqlStr = SqlStr & " fontstyle=7,"

            ElseIf txtRStyleB.Checked = True Then
                SqlStr = SqlStr & " fontstyle=5,"
            ElseIf TxtRStyleI.Checked = True Then
                SqlStr = SqlStr & " fontstyle=6,"
            Else

                SqlStr = SqlStr & " fontstyle=3,"
            End If
        Else
            If txtRStyleB.Checked = True And TxtRStyleI.Checked = True Then
                SqlStr = SqlStr & " fontstyle=4,"
            ElseIf txtRStyleB.Checked = True Then
                SqlStr = SqlStr & " fontstyle=1,"
            ElseIf TxtRStyleI.Checked = True Then
                SqlStr = SqlStr & " fontstyle=2,"
            Else
                SqlStr = SqlStr & " fontstyle=8,"
            End If
        End If
        SqlStr = SqlStr & " fontsize=" & TxtRFontSize.Value & "  where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtrecordItems.Text & "'"
        ExecuteSQLQuery(SqlStr)
    End Sub
    Sub SaveLines()
        If txtLineNames.Text.Length > 0 Then
            Dim SQLStr As String = ""
            If SQLIsFieldExists("SELECT TOP 1 1 from   printlines where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & txtLineNames.Text & "'") = True Then
                SQLStr = "UPDATE printlines SET "
                SQLStr = SQLStr & " schemename=N'" & txtSchemName.Text & "',"
                SQLStr = SQLStr & " Fieldname='" & txtLineNames.Text & "',"
                SQLStr = SQLStr & " linecolor='" & txtLineColor.Text & "',"
                SQLStr = SQLStr & " boarderstyle='" & txtLineStyle.Text & "',"
                If TxtLineShow.Checked = True Then
                    SQLStr = SQLStr & " isvisible='True',"
                Else
                    SQLStr = SQLStr & " isvisible='False',"
                End If
                SQLStr = SQLStr & " ftop=" & TxtLineY1.Value & ","
                SQLStr = SQLStr & " fleft=" & TxtLineX1.Value & ","
                SQLStr = SQLStr & " width=" & TxtLinex2.Value & ","
                SQLStr = SQLStr & " height=" & TxtLineY2.Value & ","
                SQLStr = SQLStr & " boarderwidth=" & txtLineWidth.Value & "  where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & txtLineNames.Text & "'"
                ExecuteSQLQuery(SQLStr)
            Else
                SQLStr = "INSERT INTO [PrintLines] ([schemename],[ftop],[fleft],[width],[height],[fieldname],[FieldType],[LineColor],[BoarderStyle],[BoarderWidth],[IsVisible])     VALUES " _
                    & "(@schemename,@ftop,@fleft,@width,@height,@fieldname,@FieldType,@LineColor,@BoarderStyle,@BoarderWidth,@IsVisible)     "
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
                    .AddWithValue("schemename", txtSchemName.Text)
                    .AddWithValue("ftop", TxtLineY1.Value)
                    .AddWithValue("fleft", TxtLineX1.Value)
                    .AddWithValue("width", TxtLinex2.Value)
                    .AddWithValue("height", TxtLineY2.Value)
                    .AddWithValue("Fieldname", txtLineNames.Text)
                    .AddWithValue("linecolor", txtLineColor.Text)
                    .AddWithValue("boarderstyle", txtLineStyle.Text)
                    .AddWithValue("boarderwidth", txtLineWidth.Value)
                End With
                DBF.ExecuteNonQuery()
                DBF = Nothing
                MAINCON.Close()
            End If
            IsNewLine = False
        End If
    End Sub
    Private Sub FindPositionCtrl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked_2(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim InsertStr As String = ""



        Me.Cursor = Cursors.WaitCursor
        Dim TempBS As New BindingSource
        TempBS.DataSource = SQLLoadGridData("select TOP 1 *  FROM StockInvoiceDetails")
        txtlist.AutoGenerateColumns = True
        txtlist.DataSource = TempBS
        Dim tempschlist As New ComboBox
        LoadDataIntoComboBox("SELECT SchemeName FROM PrintingSettings ", tempschlist, "SchemeName")

        For i As Integer = 0 To txtlist.ColumnCount - 1
            If SQLIsFieldExists("SELECT TOP 1 1 from   PrintFieldLabels where dbfield=N'" & txtlist.Columns(i).Name & "'") = False Then
                For k As Integer = 0 To tempschlist.Items.Count - 1
                    InsertStr = " INSERT INTO [PrintFieldLabels]([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[DatabaseValue],[IsLedgerValue],[decimals] ,[supress])     VALUES " _
                        & "(@SchemeName,@Fieldname,@labletext,@DBField,@IsVisible,@ftop,@fleft,@width,@height,@Fontname,@fontsize,@fontstyle,@fontcolor,@Align,@lTop,@lleft, " _
                        & " @lwidth,@lheight,@lFontname,@lfontsize,@lfontstyle,@lfontcolor,@lalign,@sample,@DBType,@FieldType,@PrintText,@FormatType,@DatabaseValue,@IsLedgerValue,@decimals,@supress)  "
                    MAINCON.ConnectionString = ConnectionStrinG
                    MAINCON.Open()
                    Dim DBF As New SqlClient.SqlCommand(InsertStr, MAINCON)
                    With DBF.Parameters
                        .AddWithValue("SchemeName", tempschlist.Items(k).ToString)
                        .AddWithValue("Fieldname", txtlist.Columns(i).Name.ToString)
                        .AddWithValue("labletext", txtlist.Columns(i).Name.ToString)
                        .AddWithValue("DBField", txtlist.Columns(i).Name.ToString)
                        .AddWithValue("IsVisible", False)
                        .AddWithValue("ftop", 10)
                        .AddWithValue("fleft", 10)
                        .AddWithValue("width", 20)
                        .AddWithValue("height", 20)
                        .AddWithValue("Fontname", "Arial")
                        .AddWithValue("fontsize", 12)
                        .AddWithValue("fontstyle", 1)
                        .AddWithValue("fontcolor", "Black")
                        .AddWithValue("Align", "Left")
                        .AddWithValue("lTop", 120)
                        .AddWithValue("lleft", 120)
                        .AddWithValue("lwidth", 120)
                        .AddWithValue("lheight", 120)
                        .AddWithValue("lFontname", "Arial")
                        .AddWithValue("lfontsize", 12)
                        .AddWithValue("lfontstyle", 1)
                        .AddWithValue("lfontcolor", "Black")
                        .AddWithValue("lalign", "Left")
                        .AddWithValue("sample", "")
                        .AddWithValue("DBType", 0)
                        .AddWithValue("FieldType", 1)
                        If txtlist.Columns(i).ValueType = GetType(Integer) Or txtlist.Columns(i).ValueType = GetType(Double) Or txtlist.Columns(i).ValueType = GetType(Int32) Or txtlist.Columns(i).ValueType = GetType(Int16) Or txtlist.Columns(i).ValueType = GetType(Long) Then
                            .AddWithValue("FormatType", 2)
                        Else
                            .AddWithValue("FormatType", 1)
                        End If
                        .AddWithValue("PrintText", "")
                        .AddWithValue("DatabaseValue", 0)
                        .AddWithValue("IsLedgerValue", 0)
                        .AddWithValue("decimals", 2)
                        .AddWithValue("supress", 0)


                    End With
                    DBF.ExecuteNonQuery()
                    DBF = Nothing
                    MAINCON.Close()
                Next
            End If

        Next
        'INSERT COLUMSN IN PRINTFILED DATA
        'PrintingDataRowsItems
        'PrintDataDetails
        For i As Integer = 0 To txtlist.ColumnCount - 1
            If SQLIsFieldExists("SELECT * FROM sys.columns      WHERE Name = N'" & txtlist.Columns(i).Name & "' AND Object_ID = Object_ID(N'PrintDataDetails')") = False Then
                If txtlist.Columns(i).ValueType = GetType(Integer) Or txtlist.Columns(i).ValueType = GetType(Double) Or txtlist.Columns(i).ValueType = GetType(Int32) Or txtlist.Columns(i).ValueType = GetType(Int16) Or txtlist.Columns(i).ValueType = GetType(Long) Then
                    ExecuteSQLQuery("ALTER TABLE PrintDataDetails ADD [" & txtlist.Columns(i).Name & "] [float] NULL ")
                    ExecuteSQLQuery("update PrintDataDetails set " & txtlist.Columns(i).Name & "=0")
                Else
                    ExecuteSQLQuery("ALTER TABLE PrintDataDetails ADD [" & txtlist.Columns(i).Name & "] [nvarchar](100) NULL  ")
                    ExecuteSQLQuery("update PrintDataDetails set " & txtlist.Columns(i).Name & "=''")
                End If
            End If
        Next
        LoadDataIntoComboBox("select Fieldname from printFieldLabels where schemename=N'" & txtSchemName.Text & "'", TxtFieldLables, "Fieldname")
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New newRecordFiledForPrintingScheme
        frm.ShowDialog()
        LoadDefauls()
        LoadReport()

    End Sub

    Private Sub LinkLabel2_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim InsertStr As String = ""

        Me.Cursor = Cursors.WaitCursor
        Dim TempBS As New BindingSource
        TempBS.DataSource = SQLLoadGridData("select TOP 1 *  FROM StockInvoiceRowItems")
        txtlist.AutoGenerateColumns = True
        txtlist.DataSource = TempBS
        Dim tempschlist As New ComboBox
        LoadDataIntoComboBox("SELECT SchemeName FROM PrintingSettings ", tempschlist, "SchemeName")

        For i As Integer = 0 To txtlist.ColumnCount - 1

            For k As Integer = 0 To tempschlist.Items.Count - 1
                If SQLIsFieldExists("SELECT TOP 1 1 from   PrintRecords where dbfield=N'" & txtlist.Columns(i).Name & "' and schemename=N'" & tempschlist.Items(k).ToString & "'") = False Then
                    InsertStr = " INSERT INTO [PrintRecords]([SchemeName],[Fieldname],[labletext],[ObjectType],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[Lcase],[Rcase],[lalign],[space],[DBType],[DBField],[FormatType],[decimals],[supress])     VALUES " _
                   & " (@SchemeName,@Fieldname,@labletext,@ObjectType,@IsVisible,@ftop,@fleft,@width,@height,@Fontname,@fontsize,@fontstyle,@fontcolor,@Align," _
                   & " @lTop,@lleft,@lwidth,@lheight,@lFontname,@lfontsize,@lfontstyle,@lfontcolor, " _
                   & " @Lcase,@Rcase,@lalign,@space,@DBType,@DBField,@FormatType,@decimals,@supress)     "

                    MAINCON.ConnectionString = ConnectionStrinG
                    MAINCON.Open()
                    Dim DBF As New SqlClient.SqlCommand(InsertStr, MAINCON)
                    With DBF.Parameters
                        .AddWithValue("SchemeName", tempschlist.Items(k).ToString)
                        .AddWithValue("Fieldname", txtlist.Columns(i).Name.ToString)
                        .AddWithValue("labletext", txtlist.Columns(i).Name.ToString)
                        .AddWithValue("ObjectType", txtlist.Columns(i).Name.ToString)
                        .AddWithValue("IsVisible", False)
                        .AddWithValue("ftop", 10)
                        .AddWithValue("fleft", 10)
                        .AddWithValue("width", 20)
                        .AddWithValue("height", 20)
                        .AddWithValue("Fontname", "Arial")
                        .AddWithValue("fontsize", 12)
                        .AddWithValue("fontstyle", 1)
                        .AddWithValue("fontcolor", "Black")
                        .AddWithValue("Align", "Left")
                        .AddWithValue("lTop", 120)
                        .AddWithValue("lleft", 120)
                        .AddWithValue("lwidth", 120)
                        .AddWithValue("lheight", 120)
                        .AddWithValue("lFontname", "Arial")
                        .AddWithValue("lfontsize", 12)
                        .AddWithValue("lfontstyle", 1)
                        .AddWithValue("lfontcolor", "Black")
                        .AddWithValue("Lcase", "lower case")
                        .AddWithValue("Rcase", "lower case")
                        .AddWithValue("lalign", "left")
                        .AddWithValue("space", 5)
                        .AddWithValue("DBField", txtlist.Columns(i).Name.ToString)
                        .AddWithValue("DBType", 0)
                        .AddWithValue("FieldType", 1)
                        If txtlist.Columns(i).ValueType = GetType(Integer) Or txtlist.Columns(i).ValueType = GetType(Double) Or txtlist.Columns(i).ValueType = GetType(Int32) Or txtlist.Columns(i).ValueType = GetType(Int16) Or txtlist.Columns(i).ValueType = GetType(Long) Then
                            .AddWithValue("FormatType", 2)
                        Else
                            .AddWithValue("FormatType", 1)
                        End If
                        .AddWithValue("decimals", 2)
                        .AddWithValue("supress", 0)


                    End With
                    DBF.ExecuteNonQuery()
                    DBF = Nothing
                    MAINCON.Close()
                End If

            Next


        Next
        'adding new columns in temp details row items
        For i As Integer = 0 To txtlist.ColumnCount - 1
            If SQLIsFieldExists("SELECT * FROM sys.columns      WHERE Name = N'" & txtlist.Columns(i).Name & "' AND Object_ID = Object_ID(N'PrintingDataRowsItems')") = False Then
                If txtlist.Columns(i).ValueType = GetType(Integer) Or txtlist.Columns(i).ValueType = GetType(Double) Or txtlist.Columns(i).ValueType = GetType(Int32) Or txtlist.Columns(i).ValueType = GetType(Int16) Or txtlist.Columns(i).ValueType = GetType(Long) Then
                    ExecuteSQLQuery("ALTER TABLE PrintingDataRowsItems ADD [" & txtlist.Columns(i).Name & "] [float] NULL ")
                    ExecuteSQLQuery("update PrintingDataRowsItems set " & txtlist.Columns(i).Name & "=0")
                Else
                    ExecuteSQLQuery("ALTER TABLE PrintingDataRowsItems ADD [" & txtlist.Columns(i).Name & "] [nvarchar](100) NULL  ")
                    ExecuteSQLQuery("update PrintingDataRowsItems set " & txtlist.Columns(i).Name & "=''")
                End If
            End If
        Next
        LoadDataIntoComboBox("select Fieldname from PrintRecords where schemename=N'" & txtSchemName.Text & "'", TxtrecordItems, "Fieldname")
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ImsButton1_Click_1(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click
        If MsgBox("Do You want to Apply the Text to All Schemes ? ", MsgBoxStyle.YesNo) + MsgBoxResult.Yes Then
            Dim SQLSTR As String = ""
            SQLSTR = " UPDATE printheadings SET  headtext=N'" & TxtHeadDisplyText.Text & "'   where  fieldname=N'" & txtheadingitems.Text & "'"
            ExecuteSQLQuery(SQlStr)
        End If
    End Sub

  

  

    Private Sub btnDefinformula_Click(sender As System.Object, e As System.EventArgs) Handles btnDefinformula.Click
        If TxtrecordItems.Text.Length = 0 Then Exit Sub
        Dim FRM As New DefineFormulafrm(1, txtSchemName.Text, TxtrecordItems.Text, TxtFormulaName.Text)
        FRM.ShowDialog()
        If FRM.FORMULANAME.Length > 0 Then
            TxtFormulaName.Text = FRM.FORMULANAME
        End If
        FRM.Dispose()
    End Sub

    Private Sub BtnDefineF_Click(sender As System.Object, e As System.EventArgs) Handles BtnDefineF.Click
        If TxtFieldLables.Text.Length = 0 Then Exit Sub
        Dim FRM As New DefineFormulafrm(0, txtSchemName.Text, TxtFieldLables.Text, txtFormulaNameF.Text)
        FRM.ShowDialog()
        If FRM.FORMULANAME.Length > 0 Then
            txtFormulaNameF.Text = FRM.FORMULANAME
        End If
        FRM.Dispose()
    End Sub

    Private Sub ImsButton3_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton3.Click
        Dim FRM As New DefineFormulafrm(0, txtSchemName.Text)
        FRM.ShowDialog()
        LoadDataIntoComboBox("select Fieldname from printFieldLabels where schemename=N'" & txtSchemName.Text & "'", TxtFieldLables, "Fieldname")
        FRM.Dispose()
    End Sub

    Private Sub ImsButton2_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton2.Click
        Dim FRM As New DefineFormulafrm(1, txtSchemName.Text)
        FRM.ShowDialog()
        LoadDataIntoComboBox("select Fieldname from PrintRecords where schemename=N'" & txtSchemName.Text & "'", TxtrecordItems, "Fieldname")
        FRM.Dispose()
    End Sub

    Private Sub TxtGridList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtGridList.CellContentClick

    End Sub

    Private Sub TxtGridList_CellValidating(sender As Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles TxtGridList.CellValidating
        If e.ColumnIndex = TxtGridList.Columns("tcopies").Index Then
            If IsNumeric(e.FormattedValue) = True Then
                If CLng(e.FormattedValue) > 5 Then
                    e.Cancel = True
                Else
                    ExecuteSQLQuery("update PrintingSchemes set NoofCopies=" & CLng(e.FormattedValue) & " where schemename=N'" & TxtGridList.Item(1, TxtGridList.CurrentRow.Index).Value & "' and vouchername=N'" & TxtDefInvoiceList.Text & "'")
                    '
                    e.Cancel = False
                End If
            Else
                e.Cancel = True
            End If
        End If
    End Sub
End Class