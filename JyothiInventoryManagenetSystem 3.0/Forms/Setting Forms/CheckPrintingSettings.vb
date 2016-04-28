Imports System.Windows.Forms
Imports System.Drawing.Printing

Public Class CheckPrintingSettings
    Dim NewFontStyle As New FontStyle
    Dim LeftSidelogoselected As Boolean = False
    Dim Rightsidelogoselected As Boolean = False
    Dim IsNewLine As Boolean = False
    Dim PrtValues As New ChequePrintValuesStruct
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

    Private Sub CheckPrintingSettings_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

   

    Private Sub SalesInvoicePrintingOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If My.Computer.Screen.WorkingArea.Width <= 1024 Then
            Me.Font = New Font(Me.Font.Name, 8, FontStyle.Regular)
        End If
        PrtValues.PrintDate = "12/05/2012"
        PrtValues.PayeeName = "JYOTHI SURESH"
        PrtValues.Amount = 455874.58
        PrtValues.AmountinWords = "Four lakhs and fifty thousand and eight hundred seventy four only"
        TxtPrinterName.Items.Clear()
        For Each s In Printing.PrinterSettings.InstalledPrinters
            TxtPrinterName.Items.Add(s)
        Next

        LoadSchemesIntoBoxes()
        LoadDefauls()
        If txtSchemName.Items.Count > 0 Then
            txtSchemName.SelectedIndex = 0
        End If

        PrintPreviewControl1.Zoom = 1
        PrintPreviewControl1.Refresh()
        TxtZoom.Text = "Auto"
    End Sub
    Sub LoadSchemesIntoBoxes()
        LoadDataIntoComboBox("select  schemename from chequePrintingSettings", txtSchemName, "schemename")
        LoadDataIntoComboBox("select  schemename from chequePrintingSettings", TxtDefaultBankSechems, "schemename")
        LoadDataIntoComboBox("select ledgername from ledgers where  (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.BankOD & "'))", TxtBankNames, "Ledgername")

    End Sub
    Sub LoadDefauls()
        LeftSidelogoselected = False
        Rightsidelogoselected = False
        'chequePrintingSettings

        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SQLFcmd2 As New SqlClient.SqlCommand
            SQLFcmd2.Connection = SqlConn1
            SQLFcmd2.CommandText = "select * from chequePrintingSettings where schemename=N'" & txtSchemName.Text & "'"
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
            SQLFcmd2.Connection = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
        End Try

        LoadDataIntoComboBox("select Fieldname from chequePrintFieldLabels where schemename=N'" & txtSchemName.Text & "'", TxtFieldLables, "Fieldname")
        LoadDataIntoComboBox("select Fieldname from chequePrintLines where schemename=N'" & txtSchemName.Text & "'", txtLineNames, "Fieldname")
        LoadDataIntoComboBox("select Fieldname from chequePrintLables where schemename=N'" & txtSchemName.Text & "'", TxtLabelLists, "Fieldname")


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
        ChequePrinting(sender, e, 0, txtSchemName.Text, PrtValues)
        Dim Watermarkpath As String = ""
        Watermarkpath = SQLGetStringFieldValue("select watermark from chequePrintingSettings where schemename=N'" & txtSchemName.Text & "'", "watermark")

        If Watermarkpath.Length > 0 Then
            Dim ImageValue As System.Drawing.Image
            ImageValue = Image.FromFile(Watermarkpath)
            e.Graphics.DrawImage(ImageValue, 0, 0, PrtDoc.DefaultPageSettings.PaperSize.Width, PrtDoc.DefaultPageSettings.PaperSize.Height)

        End If
    End Sub

    Private Sub BtnPagesetupSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPagesetupSave.Click
        Dim SqlStr As String = ""
        If MsgBox("Do You want to save?           ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            SqlStr = "UPDATE chequePrintingSettings SET "
            SqlStr = SqlStr & "printername='" & TxtPrinterName.Text & "',"
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
            SqlStr = SqlStr & "watermark='" & TxtWaterMark.ImageLocation & "',"

            If IsShownPageNos.Checked = True Then
                SqlStr = SqlStr & "showpageno='true',"
            Else
                SqlStr = SqlStr & "showpageno='false',"
            End If

            SqlStr = SqlStr & "pagenoleft=" & TxtPageNoLeft.Value & ","
            SqlStr = SqlStr & "pagenotop=" & TxtPageNoTop.Value & ","
            SqlStr = SqlStr & "pageformat=" & TxtPageNoFormat.SelectedIndex & "  where schemename=N'" & txtSchemName.Text & "'"
            'Dbf.Fields("watermark").Value = TxtWaterMark.ImageLocation
            'MsgBox SqlStr 
            ExecuteSQLQuery(SqlStr)
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

    Private Sub GroupBox13_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintGroup.Enter

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
        'chequePrintFieldLabels
        Dim SqlStr As String = ""
        If MsgBox("Do you want to Save?      ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then

            SqlStr = "UPDATE chequePrintFieldLabels SET "

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
            SqlStr = SqlStr & "align='" & TxtFLFAlign.Text & "'  where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtFieldLables.Text & "'"

            ExecuteSQLQuery(SqlStr)
        End If
        If TxtFLApplyToAll.Checked = True Then
            TxtFLApplyToAll.Checked = False
            SqlStr = "UPDATE chequePrintFieldLabels SET "

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
            SqlStr = "UPDATE chequePrintFieldLabels SET "

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
            SqlStr = SqlStr & "fontcolor='" & TxtFLFontColor.Text & "'  where schemename=N'" & txtSchemName.Text & "'"
            ExecuteSQLQuery(SqlStr)
        End If
        LoadReport()
    End Sub

    Private Sub TxtFieldLables_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFieldLables.SelectedIndexChanged
        'chequePrintFieldLabels

        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SQLFcmd2 As New SqlClient.SqlCommand
            SQLFcmd2.Connection = SqlConn1
            SQLFcmd2.CommandText = "select * from chequePrintFieldLabels where schemename=N'" & txtSchemName.Text & "' and Fieldname=N'" & TxtFieldLables.Text & "'"
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

                TxtFLFAlign.Text = Sreader("align").ToString.Trim
            End While
            Sreader.Close()
            SQLFcmd2.Connection = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
        End Try
    End Sub

    Private Sub btnNewLabelSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewLabelSave.Click
        If TxtLabelLists.Text.Length = 0 Then
            MsgBox("Please Select the  Labels from the list")
            TxtLabelLists.Focus()
            Exit Sub
        End If
        'chequePrintLables

        If MsgBox("Do you want to Save?      ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            If SQLIsFieldExists("SELECT TOP 1 1 from   chequePrintLables where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtLabelLists.Text & "'") = True Then
                'update
                Dim SQlstr As String = ""
                SQlstr = "UPDATE chequePrintLables  SET "
                SQlstr = SQlstr & " schemename=N'" & txtSchemName.Text & "',"
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
                sqlsTR = " INSERT INTO [chequePrintLables] ([schemename],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor], " _
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
            SQLStr = " UPDATE chequePrintLables SET "
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
        'chequePrintLables
        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SQLFcmd2 As New SqlClient.SqlCommand
            SQLFcmd2.Connection = SqlConn1
            SQLFcmd2.CommandText = "select * from chequePrintLables where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & TxtLabelLists.Text & "'"
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
            SQLFcmd2.Connection = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
        End Try


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
        'chequePrintLines
        If MsgBox("Do you want to save the line ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
            Exit Sub
        End If
        If txtLineNames.Text.Length > 0 Then
            Dim SQLStr As String = ""
            If SQLIsFieldExists("SELECT TOP 1 1 from   chequePrintLines where schemename=N'" & txtSchemName.Text & "' and fieldname=N'" & txtLineNames.Text & "'") = True Then
                SQLStr = "UPDATE printlines SET "
                SQLStr = SQLStr & " schemename='" & txtSchemName.Text & "',"
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
                SQLStr = "INSERT INTO [chequePrintLines] ([schemename],[ftop],[fleft],[width],[height],[fieldname],[FieldType],[LineColor],[BoarderStyle],[BoarderWidth],[IsVisible])     VALUES " _
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
            SQLFcmd2.Connection = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
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
                        sqlStr = "INSERT INTO [chequePrintingSettings]([PrinterName],[schemename],[Width],[Height],[IsLandScape],[fleft],[fright],[ftop],[fbuttom],[multi],[showsubtotals],[IsActive],[PaperName],[LeftLogoIsOn],[RightLogoIson],[Leftlogoleft],[Leftlogotop],[Leftlogowidth],[Leftlogoheight],[Rightlogoleft],[Rightlogotop],[Rightlogowidth],[Rightlogoheight],[leftlogopath],[rightlogopath],[MaxRowsPerPage],[RowHeight],[showpageno],[pagenotop],[pagenoleft],[pageformat]) " _
                            & " (SELECT  [PrinterName],N'" & schemevalue & "' AS [schemename],[Width],[Height],[IsLandScape],[fleft],[fright],[ftop],[fbuttom],[multi],[showsubtotals],[IsActive],[PaperName],[LeftLogoIsOn],[RightLogoIson],[Leftlogoleft],[Leftlogotop],[Leftlogowidth],[Leftlogoheight],[Rightlogoleft],[Rightlogotop],[Rightlogowidth],[Rightlogoheight],[leftlogopath],[rightlogopath],[MaxRowsPerPage],[RowHeight],[showpageno],[pagenotop],[pagenoleft],[pageformat] FROM chequePrintingSettings where schemename=N'" & txtSchemName.Text & "')"
                        ExecuteSQLQuery(sqlStr)

                        sqlStr = "INSERT INTO [chequePrintFieldLabels] ([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[databasevalue]) " _
                            & "(SELECT N'" & schemevalue & "' AS [SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[databasevalue] FROM chequePrintFieldLabels where schemename=N'" & txtSchemName.Text & "')"
                        ExecuteSQLQuery(sqlStr)

                        sqlStr = "INSERT INTO [chequePrintLables] ([schemename],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[fieldname],[labletext],[isvisible],[align]) " _
                            & "(SELECT N'" & schemevalue & "' AS [schemename],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[fieldname],[labletext],[isvisible],[align] from chequePrintLables where schemename=N'" & txtSchemName.Text & "')"
                        ExecuteSQLQuery(sqlStr)

                        sqlStr = "INSERT INTO [chequePrintLines] ([schemename],[ftop],[fleft],[width],[height],[fieldname],[FieldType],[LineColor],[BoarderStyle],[BoarderWidth],[IsVisible]) " _
                            & "(SELECT N'" & schemevalue & "' AS [schemename],[ftop],[fleft],[width],[height],[fieldname],[FieldType],[LineColor],[BoarderStyle],[BoarderWidth],[IsVisible] from chequePrintLines where schemename=N'" & txtSchemName.Text & "')"
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

    Private Sub BtnCLose1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCLose1.Click
        Me.Close()
    End Sub

    Private Sub BtnFieldClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFieldClose.Click
        Me.Close()
    End Sub

    Private Sub BtnNewlabelClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewlabelClose.Click
        Me.Close()
    End Sub

   

    Private Sub UserButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton1.Click
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

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        OpenPicture.Title = "Select The Image for Water Mark"
        If OpenPicture.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TxtWaterMark.ImageLocation = OpenPicture.FileName
        End If
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        If TxtBankNames.Text.Length <= 2 Then
            MsgBox("Please select the Bank Name......", MsgBoxStyle.Information)
            TxtBankNames.Focus()
            Exit Sub
        End If
        If TxtDefaultBankSechems.Text.Length < 2 Then
            MsgBox("Please Select the Scheme Name for the Selected Bank....", MsgBoxStyle.Information)
            TxtDefaultBankSechems.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to save ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ExecuteSQLQuery("update ledgers set f1=N'" & TxtDefaultBankSechems.Text & "' where ledgername=N'" & TxtBankNames.Text & "'")
        End If
    End Sub

    Private Sub TxtBankNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBankNames.SelectedIndexChanged
        TxtDefaultBankSechems.Text = SQLGetStringFieldValue("select f1 from ledgers where ledgername=N'" & TxtBankNames.Text & "'", "f1")
    End Sub
End Class
