Public Class TrailBalanceSheet
    Dim IsDetailedView As Boolean = False
    Dim OpeningStockvalue As Double = 0
    Dim StockValue As Double = 0
    Dim FormLevel As Byte = 1
    Dim SelectedGroupname As String = ""
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadSelctedGroupData(ByVal gpname As String)
        MainForm.Cursor = Cursors.WaitCursor
        If gpname.Length = 0 Then Exit Sub
        Dim SqlStr As String = ""
        Dim opdr As Double = 0
        Dim opCr As Double = 0
        Dim tdr As Double = 0
        Dim tcr As Double = 0
        Dim cdr As Double = 0
        Dim ccr As Double = 0
        TxtList.Rows.Clear()
        Dim opdrTotal As Double = 0
        Dim opCrTotal As Double = 0
        Dim tdrTotal As Double = 0
        Dim tcrTotal As Double = 0
        Dim cdrTotal As Double = 0
        Dim ccrTotal As Double = 0
        Dim Rowno As Integer = 0
        SelectedGroupname = gpname
        If UCase(gpname) = UCase(AccountGroupNames.CurrentAssets) Then
            'CALCULATE THE OPENING STOCK VALUES
            'StockValue = SQLGetNumericFieldValue("select sum(stockrate*totalqty/unitcon) as tot from stockdbf WHERE STOCKTYPE=0", "tot")
            StockValue = 0
            OpeningStockvalue = SQLGetNumericFieldValue("select sum(opstockrate*optotalqty/unitcon) as tot from stockdbf WHERE STOCKTYPE=0", "tot")
            'END OF CALCULATE THE OPENING STOCK VALUES
            ''CALCULATE THE Current Assets  VALUES 
            TxtList.Rows.Clear()
            SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CurrentAssets & "')))"
            opdr = SQLGetNumericFieldValue("select sum(dr) as tot from ledgerbook where isdeleted=0 and transcode=0 and ledgername in " & SqlStr, "tot")
            opCr = SQLGetNumericFieldValue("select sum(cr) as tot from ledgerbook where isdeleted=0 and transcode=0 and ledgername in " & SqlStr, "tot")

            If TxtShowWithOpeningStock.Checked = True Then
                opdr = opdr + OpeningStockvalue
            End If
            tdr = SQLGetNumericFieldValue("select sum(dr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
            tcr = SQLGetNumericFieldValue("select sum(cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
            If TxtShowWithOpeningStock.Checked = True Then
                tdr = tdr + OpeningStockvalue
            End If


            opdrTotal = opdr
            opCrTotal = opCr
            tdrTotal = tdr
            tcrTotal = tcr
            Rowno = TxtList.Rows.Add()

            TxtList.Rows(Rowno).DefaultCellStyle.ForeColor = Color.Blue

            TxtList.Item("tsno", Rowno).Value = Rowno
            TxtList.Item("tprimary", Rowno).Value = 1
            TxtList.Item("TLedger", Rowno).Value = AccountGroupNames.CurrentAssets
            TxtList.Item("Topdr", Rowno).Value = FormatNumber(opdr, ErpDecimalPlaces)
            TxtList.Item("Topcr", Rowno).Value = FormatNumber(opCr, ErpDecimalPlaces)
             TxtList.Item("TDr", Rowno).Value = FormatNumber(tdr - opdr, ErpDecimalPlaces)
            TxtList.Item("TCr", Rowno).Value = FormatNumber(tcr - opCr, ErpDecimalPlaces)
           

            If tdr > tcr Then
                TxtList.Item("tclosing", Rowno).Value = FormatNumber(tdr - tcr, ErpDecimalPlaces).ToString
                TxtList.Item("tCloCr", Rowno).Value = ErpZeroValue()
            Else
                TxtList.Item("tclosing", Rowno).Value = ErpZeroValue()
                TxtList.Item("tCloCr", Rowno).Value = FormatNumber(tcr - tdr, ErpDecimalPlaces).ToString
            End If
            TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font(TxtList.Font, FontStyle.Bold)

            'END OF CALCULATE CURRENT ASSETS VALUES
            If OpeningStockvalue > 0 Then
                Rowno = TxtList.Rows.Add()
                TxtList.Item("tsno", Rowno).Value = Rowno
                TxtList.Item("TLedger", Rowno).Value = "     Opening Stock"
                TxtList.Item("Topdr", Rowno).Value = FormatNumber(OpeningStockvalue, ErpDecimalPlaces)
                TxtList.Item("Topcr", Rowno).Value = ErpZeroValue()

                TxtList.Item("TDr", Rowno).Value = ErpZeroValue()
                TxtList.Item("TCr", Rowno).Value = ErpZeroValue()
                If OpeningStockvalue > 0 Then
                    TxtList.Item("tclosing", Rowno).Value = FormatNumber(OpeningStockvalue, ErpDecimalPlaces).ToString
                    TxtList.Item("tCloCr", Rowno).Value = ErpZeroValue()
                Else
                    TxtList.Item("tclosing", Rowno).Value = ErpZeroValue()
                    TxtList.Item("tCloCr", Rowno).Value = FormatNumber(OpeningStockvalue * -1, ErpDecimalPlaces).ToString
                End If
            End If


            Dim cmbGroups As New ComboBox
            'LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'Current Assets' and subgroup<>'Current Assets'", cmbGroups, "subgroup")
            If TxtShowAllGroups.Checked = True Then
                LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CurrentAssets & "' and subgroup<>'" & AccountGroupNames.CurrentAssets & "'", cmbGroups, "subgroup")
            Else
                LoadDataIntoComboBox("select groupname from AccountGroups where grouproot=N'" & AccountGroupNames.CurrentAssets & "'", cmbGroups, "groupname")
            End If

            For i As Integer = 0 To cmbGroups.Items.Count - 1
                'For Opening Stock


                SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & cmbGroups.Items(i).ToString & "')))"
                opdr = SQLGetNumericFieldValue("select sum(dr) as tot from ledgerbook where isdeleted=0 and transcode=0 and ledgername in " & SqlStr, "tot")
                opCr = SQLGetNumericFieldValue("select sum(cr) as tot from ledgerbook where isdeleted=0 and transcode=0 and ledgername in " & SqlStr, "tot")
                tdr = SQLGetNumericFieldValue("select sum(dr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
                tcr = SQLGetNumericFieldValue("select sum(cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
                Rowno = TxtList.Rows.Add()
                TxtList.Item("tsno", Rowno).Value = Rowno
                TxtList.Item("tprimary", Rowno).Value = 0
                TxtList.Item("TLedger", Rowno).Value = "     " & cmbGroups.Items(i).ToString
                TxtList.Item("Topdr", Rowno).Value = FormatNumber(opdr, ErpDecimalPlaces)
                TxtList.Item("Topcr", Rowno).Value = FormatNumber(opCr, ErpDecimalPlaces)

                TxtList.Item("TDr", Rowno).Value = FormatNumber(tdr - opdr, ErpDecimalPlaces)
                TxtList.Item("TCr", Rowno).Value = FormatNumber(tcr - opCr, ErpDecimalPlaces)
                If tdr > tcr Then
                    TxtList.Item("tclosing", Rowno).Value = FormatNumber(tdr - tcr, ErpDecimalPlaces).ToString
                    TxtList.Item("tCloCr", Rowno).Value = ErpZeroValue()
                Else
                    TxtList.Item("tclosing", Rowno).Value = ErpZeroValue()
                    TxtList.Item("tCloCr", Rowno).Value = FormatNumber(tcr - tdr, ErpDecimalPlaces).ToString
                End If
            Next
            'END OF CALCULATE ALL ASSETS
        Else

            SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & gpname & "')))"
            opdr = SQLGetNumericFieldValue("select sum(dr) as tot from ledgerbook where isdeleted=0 and transcode=0 and ledgername in " & SqlStr, "tot")
            opCr = SQLGetNumericFieldValue("select sum(cr) as tot from ledgerbook where isdeleted=0 and transcode=0 and ledgername in " & SqlStr, "tot")
            tdr = SQLGetNumericFieldValue("select sum(dr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
            tcr = SQLGetNumericFieldValue("select sum(cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
            If tcr > 0 Or tdr > 0 Then
                opdrTotal = opdrTotal + opdr
                opCrTotal = opCrTotal + opCr
                tdrTotal = tdrTotal + tdr
                tcrTotal = tcrTotal + tcr

                Rowno = TxtList.Rows.Add()
                TxtList.Rows(Rowno).DefaultCellStyle.ForeColor = Color.Blue
                TxtList.Item("tsno", Rowno).Value = Rowno
                TxtList.Item("tprimary", Rowno).Value = 1
                TxtList.Item("TLedger", Rowno).Value = gpname
                TxtList.Item("Topdr", Rowno).Value = FormatNumber(opdr, ErpDecimalPlaces)
                TxtList.Item("Topcr", Rowno).Value = FormatNumber(opCr, ErpDecimalPlaces)

                TxtList.Item("TDr", Rowno).Value = FormatNumber(tdr - opdr, ErpDecimalPlaces)
                TxtList.Item("TCr", Rowno).Value = FormatNumber(tcr - opCr, ErpDecimalPlaces)
                If tdr > tcr Then
                    TxtList.Item("tclosing", Rowno).Value = FormatNumber(tdr - tcr, ErpDecimalPlaces).ToString
                    TxtList.Item("tCloCr", Rowno).Value = ErpZeroValue()
                Else
                    TxtList.Item("tclosing", Rowno).Value = ErpZeroValue()
                    TxtList.Item("tCloCr", Rowno).Value = FormatNumber(tcr - tdr, ErpDecimalPlaces).ToString
                End If
                TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font(TxtList.Font, FontStyle.Bold)
                Dim cmbGroups As New ComboBox
                If TxtShowAllGroups.Checked = True Then
                    LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & gpname & "' and subgroup<>N'" & gpname & "'", cmbGroups, "subgroup")
                Else
                    LoadDataIntoComboBox("select groupname from AccountGroups where grouproot=N'" & gpname & "'", cmbGroups, "groupname")
                End If
                '

                For i As Integer = 0 To cmbGroups.Items.Count - 1

                    SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & cmbGroups.Items(i).ToString & "')))"
                    opdr = SQLGetNumericFieldValue("select sum(dr) as tot from ledgerbook where isdeleted=0 and transcode=0 and ledgername in " & SqlStr, "tot")
                    opCr = SQLGetNumericFieldValue("select sum(cr) as tot from ledgerbook where isdeleted=0 and transcode=0 and ledgername in " & SqlStr, "tot")
                    tdr = SQLGetNumericFieldValue("select sum(dr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
                    tcr = SQLGetNumericFieldValue("select sum(cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
                    Rowno = TxtList.Rows.Add()
                    TxtList.Item("tsno", Rowno).Value = Rowno
                    TxtList.Item("TLedger", Rowno).Value = "     " & cmbGroups.Items(i).ToString
                    TxtList.Item("Topdr", Rowno).Value = FormatNumber(opdr, ErpDecimalPlaces)
                    TxtList.Item("Topcr", Rowno).Value = FormatNumber(opCr, ErpDecimalPlaces)
                    TxtList.Item("tprimary", Rowno).Value = 0
                    TxtList.Item("TDr", Rowno).Value = FormatNumber(tdr - opdr, ErpDecimalPlaces)
                    TxtList.Item("TCr", Rowno).Value = FormatNumber(tcr - opCr, ErpDecimalPlaces)
                    If tdr > tcr Then
                        TxtList.Item("tclosing", Rowno).Value = FormatNumber(tdr - tcr, ErpDecimalPlaces).ToString
                        TxtList.Item("tCloCr", Rowno).Value = ErpZeroValue()
                    Else
                        TxtList.Item("tclosing", Rowno).Value = ErpZeroValue()
                        TxtList.Item("tCloCr", Rowno).Value = FormatNumber(tcr - tdr, ErpDecimalPlaces).ToString
                    End If
                Next

            End If
        End If

        TxtOpDr.Text = FormatNumber(opdrTotal, ErpDecimalPlaces)
        TxtOpCr.Text = FormatNumber(opCrTotal, ErpDecimalPlaces)
        TxtTdr.Text = FormatNumber(tdrTotal, ErpDecimalPlaces)
        TxtTCr.Text = FormatNumber(tcrTotal, ErpDecimalPlaces)

        'If tdrTotal > tcrTotal Then
        '    TxtClosingBalanceCr.Text = FormatNumber(tdrTotal - tcrTotal, 2) & " Dr"
        'Else
        '    TxtClosingBalanceCr.Text = FormatNumber(tcrTotal - tdrTotal, 2) & " Cr"
        'End If
        Dim CtotalDr As Double = 0
        Dim CtotalCr As Double = 0
        For i As Integer = 0 To TxtList.RowCount - 1
            If TxtList.Item("tprimary", i).Value = "1" Then
                CtotalDr = CtotalDr + CDbl(TxtList.Item("tclosing", i).Value)
                CtotalCr = CtotalCr + CDbl(TxtList.Item("tCloCr", i).Value)
            End If
        Next

        TxtClosingBalanceDr.Text = FormatNumber(CtotalDr, ErpDecimalPlaces)
        TxtClosingBalanceCr.Text = FormatNumber(CtotalCr, ErpDecimalPlaces)

       
      


        supressZeros()
        MainForm.Cursor = Cursors.Default
    End Sub
    Sub loaddata()
        MainForm.Cursor = Cursors.WaitCursor
        Dim SqlStr As String = ""
        Dim opdr As Double = 0
        Dim opCr As Double = 0
        Dim tdr As Double = 0
        Dim tcr As Double = 0
        Dim cdr As Double = 0
        Dim ccr As Double = 0

        Dim opdrTotal As Double = 0
        Dim opCrTotal As Double = 0
        Dim tdrTotal As Double = 0
        Dim tcrTotal As Double = 0
        Dim cdrTotal As Double = 0
        Dim ccrTotal As Double = 0

        Dim Rowno As Integer = 0



        'CALCULATE THE OPENING STOCK VALUES
        'StockValue = SQLGetNumericFieldValue("select sum(stockrate*totalqty/unitcon) as tot from stockdbf", "tot")
        StockValue = 0
        OpeningStockvalue = SQLGetNumericFieldValue("select sum(opstockrate*optotalqty/unitcon) as tot from stockdbf", "tot")
        'END OF CALCULATE THE OPENING STOCK VALUES

        ''CALCULATE THE Current Assets  VALUES 
        TxtList.Rows.Clear()

        SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CurrentAssets & "')))"
        opdr = SQLGetNumericFieldValue("select sum(dr) as tot from ledgerbook where isdeleted=0 and transcode=0 and ledgername in " & SqlStr, "tot")
        opCr = SQLGetNumericFieldValue("select sum(cr) as tot from ledgerbook where isdeleted=0 and transcode=0 and ledgername in " & SqlStr, "tot")
        ' opdr = opdr + OpeningStockvalue
        tdr = SQLGetNumericFieldValue("select sum(dr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
        tcr = SQLGetNumericFieldValue("select sum(cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")


        If TxtShowWithOpeningStock.Checked = True Then
            If OpeningStockvalue > 0 Then
                tdr = tdr + OpeningStockvalue
            Else
                tcr = tcr + OpeningStockvalue
            End If

            opdrTotal = opdr
            opCrTotal = opCr
            tdrTotal = tdr
            tcrTotal = tcr
            Rowno = TxtList.Rows.Add()
            TxtList.Rows(Rowno).DefaultCellStyle.ForeColor = Color.Blue

            TxtList.Item("tsno", Rowno).Value = Rowno
            TxtList.Item("tprimary", Rowno).Value = 1
            TxtList.Item("TLedger", Rowno).Value = AccountGroupNames.CurrentAssets
            TxtList.Item("Topdr", Rowno).Value = FormatNumber(opdr, ErpDecimalPlaces)
            TxtList.Item("Topcr", Rowno).Value = FormatNumber(opCr, ErpDecimalPlaces)

            TxtList.Item("TDr", Rowno).Value = FormatNumber(tdr - opdr, ErpDecimalPlaces)
            TxtList.Item("TCr", Rowno).Value = FormatNumber(tcr - opCr, ErpDecimalPlaces)
            If tdr > tcr Then
                TxtList.Item("tclosing", Rowno).Value = FormatNumber(tdr - tcr, ErpDecimalPlaces).ToString
                TxtList.Item("tCloCr", Rowno).Value = ErpZeroValue()
            Else
                TxtList.Item("tclosing", Rowno).Value = ErpZeroValue()
                TxtList.Item("tCloCr", Rowno).Value = FormatNumber(tcr - tdr, ErpDecimalPlaces).ToString
            End If
            TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font(TxtList.Font, FontStyle.Bold)
        Else
            opdrTotal = opdr
            opCrTotal = opCr
            tdrTotal = tdr
            tcrTotal = tcr
            Rowno = TxtList.Rows.Add()
            TxtList.Rows(Rowno).DefaultCellStyle.ForeColor = Color.Blue

            TxtList.Item("tsno", Rowno).Value = Rowno
            TxtList.Item("tprimary", Rowno).Value = 1
            TxtList.Item("TLedger", Rowno).Value = AccountGroupNames.CurrentAssets
            TxtList.Item("Topdr", Rowno).Value = FormatNumber(opdr, ErpDecimalPlaces)
            TxtList.Item("Topcr", Rowno).Value = FormatNumber(opCr, ErpDecimalPlaces)

            TxtList.Item("TDr", Rowno).Value = FormatNumber(tdr - opdr, ErpDecimalPlaces)
            TxtList.Item("TCr", Rowno).Value = FormatNumber(tcr - opCr, ErpDecimalPlaces)
            If tdr > tcr Then
                TxtList.Item("tclosing", Rowno).Value = FormatNumber(tdr - tcr, ErpDecimalPlaces).ToString
                TxtList.Item("tCloCr", Rowno).Value = ErpZeroValue()
            Else
                TxtList.Item("tclosing", Rowno).Value = ErpZeroValue()
                TxtList.Item("tCloCr", Rowno).Value = FormatNumber(tcr - tdr, ErpDecimalPlaces).ToString
            End If
            TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font(TxtList.Font, FontStyle.Bold)
        End If




        'END OF CALCULATE CURRENT ASSETS VALUES
        If IsDetailedView = True Then
            If OpeningStockvalue > 0 Then
                Rowno = TxtList.Rows.Add()
                TxtList.Item("tsno", Rowno).Value = Rowno
                TxtList.Item("TLedger", Rowno).Value = "     Opening Stock"
                TxtList.Item("Topdr", Rowno).Value = FormatNumber(OpeningStockvalue, ErpDecimalPlaces)
                TxtList.Item("Topcr", Rowno).Value = ErpZeroValue()
                TxtList.Item("tprimary", Rowno).Value = 0
                TxtList.Item("TDr", Rowno).Value = ErpZeroValue()
                TxtList.Item("TCr", Rowno).Value = ErpZeroValue()
                If OpeningStockvalue > 0 Then
                    TxtList.Item("tclosing", Rowno).Value = FormatNumber(OpeningStockvalue, ErpDecimalPlaces).ToString
                    TxtList.Item("tCloCr", Rowno).Value = ErpZeroValue()
                Else
                    TxtList.Item("tclosing", Rowno).Value = ErpZeroValue()
                    TxtList.Item("tCloCr", Rowno).Value = FormatNumber(OpeningStockvalue * -1, ErpDecimalPlaces).ToString
                End If
            End If


            Dim cmbGroups As New ComboBox
            If TxtShowAllGroups.Checked = True Then
                LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CurrentAssets & "' and subgroup<>'" & AccountGroupNames.CurrentAssets & "'", cmbGroups, "subgroup")
            Else
                LoadDataIntoComboBox("select groupname from AccountGroups where grouproot=N'" & AccountGroupNames.CurrentAssets & "'", cmbGroups, "groupname")
            End If
            '  LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'Current Assets' and subgroup<>'Current Assets'", cmbGroups, "subgroup")
            For i As Integer = 0 To cmbGroups.Items.Count - 1
                'For Opening Stock


                SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & cmbGroups.Items(i).ToString & "')))"
                opdr = SQLGetNumericFieldValue("select sum(dr) as tot from ledgerbook where isdeleted=0 and transcode=0 and ledgername in " & SqlStr, "tot")
                opCr = SQLGetNumericFieldValue("select sum(cr) as tot from ledgerbook where isdeleted=0 and transcode=0 and ledgername in " & SqlStr, "tot")
                tdr = SQLGetNumericFieldValue("select sum(dr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
                tcr = SQLGetNumericFieldValue("select sum(cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
                Rowno = TxtList.Rows.Add()
                TxtList.Item("tsno", Rowno).Value = Rowno
                TxtList.Item("TLedger", Rowno).Value = "     " & cmbGroups.Items(i).ToString
                TxtList.Item("Topdr", Rowno).Value = FormatNumber(opdr, ErpDecimalPlaces)
                TxtList.Item("Topcr", Rowno).Value = FormatNumber(opCr, ErpDecimalPlaces)
                TxtList.Item("tprimary", Rowno).Value = 0
                TxtList.Item("TDr", Rowno).Value = FormatNumber(tdr - opdr, ErpDecimalPlaces)
                TxtList.Item("TCr", Rowno).Value = FormatNumber(tcr - opCr, ErpDecimalPlaces)
                If tdr > tcr Then
                    TxtList.Item("tclosing", Rowno).Value = FormatNumber(tdr - tcr, ErpDecimalPlaces).ToString
                    TxtList.Item("tCloCr", Rowno).Value = ErpZeroValue()
                Else
                    TxtList.Item("tclosing", Rowno).Value = ErpZeroValue()
                    TxtList.Item("tCloCr", Rowno).Value = FormatNumber(tcr - tdr, ErpDecimalPlaces).ToString
                End If
            Next
        End If
        'END OF CALCULATE ALL ASSETS

        'START CALCULATE REMAINING GROUP  VALUES
        Dim CmbMainGroups As New ComboBox
        LoadDataIntoComboBox("select groupname from AccountGroups where grouplevel=0 and groupname<>'" & AccountGroupNames.CurrentAssets & "'", CmbMainGroups, "groupname")

        For m As Integer = 0 To CmbMainGroups.Items.Count - 1

            SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & CmbMainGroups.Items(m).ToString & "')))"
            opdr = SQLGetNumericFieldValue("select sum(dr) as tot from ledgerbook where isdeleted=0 and transcode=0 and ledgername in " & SqlStr, "tot")
            opCr = SQLGetNumericFieldValue("select sum(cr) as tot from ledgerbook where isdeleted=0 and transcode=0 and ledgername in " & SqlStr, "tot")
            tdr = SQLGetNumericFieldValue("select sum(dr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
            tcr = SQLGetNumericFieldValue("select sum(cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
            If tcr > 0 Or tdr > 0 Then
                opdrTotal = opdrTotal + opdr
                opCrTotal = opCrTotal + opCr
                tdrTotal = tdrTotal + tdr
                tcrTotal = tcrTotal + tcr

                Rowno = TxtList.Rows.Add()
                TxtList.Rows(Rowno).DefaultCellStyle.ForeColor = Color.Blue
                TxtList.Item("tsno", Rowno).Value = Rowno
                TxtList.Item("tprimary", Rowno).Value = 1
                TxtList.Item("TLedger", Rowno).Value = CmbMainGroups.Items(m).ToString
                TxtList.Item("Topdr", Rowno).Value = FormatNumber(opdr, ErpDecimalPlaces)
                TxtList.Item("Topcr", Rowno).Value = FormatNumber(opCr, ErpDecimalPlaces)

                TxtList.Item("TDr", Rowno).Value = FormatNumber(tdr - opdr, ErpDecimalPlaces)
                TxtList.Item("TCr", Rowno).Value = FormatNumber(tcr - opCr, ErpDecimalPlaces)
                If tdr > tcr Then
                    TxtList.Item("tclosing", Rowno).Value = FormatNumber(tdr - tcr, ErpDecimalPlaces).ToString
                    TxtList.Item("tCloCr", Rowno).Value = ErpZeroValue()
                Else
                    TxtList.Item("tclosing", Rowno).Value = ErpZeroValue()
                    TxtList.Item("tCloCr", Rowno).Value = FormatNumber(tcr - tdr, ErpDecimalPlaces).ToString
                End If
                TxtList.Rows(Rowno).DefaultCellStyle.Font = New Font(TxtList.Font, FontStyle.Bold)
                If IsDetailedView = True Then
                    Dim cmbGroups As New ComboBox

                    If TxtShowAllGroups.Checked = True Then
                        LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & CmbMainGroups.Items(m).ToString & "' and subgroup<>N'" & CmbMainGroups.Items(m).ToString & "'", cmbGroups, "subgroup")
                    Else
                        LoadDataIntoComboBox("select groupname from AccountGroups where grouproot=N'" & CmbMainGroups.Items(m).ToString & "'", cmbGroups, "groupname")
                    End If

                    '  LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & CmbMainGroups.Items(m).ToString & "' and subgroup<>N'" & CmbMainGroups.Items(m).ToString & "'", cmbGroups, "subgroup")
                    For i As Integer = 0 To cmbGroups.Items.Count - 1

                        SqlStr = "(SELECT ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & cmbGroups.Items(i).ToString & "')))"
                        opdr = SQLGetNumericFieldValue("select sum(dr) as tot from ledgerbook where isdeleted=0 and transcode=0 and ledgername in " & SqlStr, "tot")
                        opCr = SQLGetNumericFieldValue("select sum(cr) as tot from ledgerbook where isdeleted=0 and transcode=0 and ledgername in " & SqlStr, "tot")
                        tdr = SQLGetNumericFieldValue("select sum(dr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
                        tcr = SQLGetNumericFieldValue("select sum(cr) as tot from ledgerbook where isdeleted=0  and ledgername in " & SqlStr, "tot")
                        Rowno = TxtList.Rows.Add()
                        TxtList.Item("tsno", Rowno).Value = Rowno
                        TxtList.Item("TLedger", Rowno).Value = "     " & cmbGroups.Items(i).ToString
                        TxtList.Item("Topdr", Rowno).Value = FormatNumber(opdr, ErpDecimalPlaces)
                        TxtList.Item("Topcr", Rowno).Value = FormatNumber(opCr, ErpDecimalPlaces)
                        TxtList.Item("tprimary", Rowno).Value = 0
                        TxtList.Item("TDr", Rowno).Value = FormatNumber(tdr - opdr, ErpDecimalPlaces)
                        TxtList.Item("TCr", Rowno).Value = FormatNumber(tcr - opCr, ErpDecimalPlaces)
                        If tdr > tcr Then
                            TxtList.Item("tclosing", Rowno).Value = FormatNumber(tdr - tcr, ErpDecimalPlaces).ToString
                            TxtList.Item("tCloCr", Rowno).Value = ErpZeroValue()
                        Else
                            TxtList.Item("tclosing", Rowno).Value = ErpZeroValue()
                            TxtList.Item("tCloCr", Rowno).Value = FormatNumber(tcr - tdr, ErpDecimalPlaces).ToString
                        End If
                    Next
                End If

            End If
        Next

        'END OF Fixed Assets VALUES

        TxtOpDr.Text = FormatNumber(opdrTotal, ErpDecimalPlaces)
        TxtOpCr.Text = FormatNumber(opCrTotal, ErpDecimalPlaces)
        TxtTdr.Text = FormatNumber(tdrTotal, ErpDecimalPlaces)
        TxtTCr.Text = FormatNumber(tcrTotal, ErpDecimalPlaces)

        'If tdrTotal > tcrTotal Then
        '    TxtClosingBalanceCr.Text = FormatNumber(tdrTotal - tcrTotal, 2) & " Dr"
        'Else
        '    TxtClosingBalanceCr.Text = FormatNumber(tcrTotal - tdrTotal, 2) & " Cr"
        'End If
        If opdrTotal > opCrTotal Then
            'TxtList
            Rowno = TxtList.Rows.Add()
            If TxtShowWithOpeningStock.Checked = True Then
                TxtList.Item("tprimary", Rowno).Value = 1
            End If
            TxtList.Item("tCloCr", Rowno).Value = FormatNumber(opdrTotal - opCrTotal, ErpDecimalPlaces)
            TxtList.Item("TLedger", Rowno).Value = " Diff in Opening Balances"

        ElseIf opCrTotal > opdrTotal Then
            'TxtList
            Rowno = TxtList.Rows.Add()
            If TxtShowWithOpeningStock.Checked = True Then
                TxtList.Item("tprimary", Rowno).Value = 1
            End If
            TxtList.Item("tclosing", Rowno).Value = FormatNumber(opCrTotal - opdrTotal, ErpDecimalPlaces)
            TxtList.Item("TLedger", Rowno).Value = " Diff in Opening Balances"
        End If





        Dim CtotalDr As Double = 0
        Dim CtotalCr As Double = 0
        For i As Integer = 0 To TxtList.RowCount - 1
            If TxtList.Item("tprimary", i).Value = "1" Then
                CtotalDr = CtotalDr + CDbl(TxtList.Item("tclosing", i).Value)
                CtotalCr = CtotalCr + CDbl(TxtList.Item("tCloCr", i).Value)
            End If
        Next
        TxtClosingBalanceDr.Text = FormatNumber(CtotalDr, ErpDecimalPlaces)
        TxtClosingBalanceCr.Text = FormatNumber(CtotalCr, ErpDecimalPlaces)



        supressZeros()

        MainForm.Cursor = Cursors.Default
    End Sub

    Private Sub DetailedToolStrimMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailedToolStrimMenuItem.Click
        If IsDetailedView = True Then
            IsDetailedView = False
        Else
            IsDetailedView = True
        End If
        If FormLevel = 1 Then
            loaddata()
        Else

        End If

    End Sub

    Private Sub TrailBalanceSheet_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub TrailBalanceSheet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If FormLevel = 1 Then
            loaddata()
        Else

        End If
        On Error Resume Next
        ValidateCtrlPositions()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        If FormLevel = 1 Then
            Me.Close()
        Else
            FormLevel = 1
            loaddata()
        End If

    End Sub



    Private Sub TxtList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellDoubleClick

        If TxtList.Item("tprimary", TxtList.CurrentRow.Index).Value = 1 And FormLevel = 1 Then
            FormLevel = 2
            LoadSelctedGroupData(TxtList.Item("TLedger", TxtList.CurrentRow.Index).Value)
        Else

        End If


    End Sub

    Private Sub TxtShowDetailed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShowDetailed.CheckedChanged
        If FormLevel = 2 Then Exit Sub
        If TxtShowDetailed.Checked = True Then
            IsDetailedView = True
        Else
            IsDetailedView = False
        End If
        loaddata()
    End Sub

    Private Sub TxtShowAllGroups_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShowAllGroups.CheckedChanged
        If FormLevel = 1 Then
            loaddata()
        ElseIf FormLevel = 2 Then
            LoadSelctedGroupData(SelectedGroupname)
        End If

    End Sub

    Private Sub TxtShowOpeiningBalances_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShowOpeiningBalances.CheckedChanged
        On Error Resume Next
       ValidateCtrlPositions()
    End Sub

    Private Sub ShowNetTransactions_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowNetTransactions.CheckedChanged
        On Error Resume Next
       
        ValidateCtrlPositions()
    End Sub
    Sub ValidateCtrlPositions()
        On Error Resume Next
        If ShowNetTransactions.Checked = True And TxtShowOpeiningBalances.Checked = True Then
            lblOp1.Visible = True
            lblop2.Visible = True
            lblop3.Visible = True
            TxtOpCr.Visible = True
            TxtOpDr.Visible = True
            TxtList.Columns("Topdr").Visible = True
            TxtList.Columns("TopCr").Visible = True
            lblOp1.Text = "Opening Balances"
            lblt1.Text = "Transactions Balances"
            lblt1.Visible = True
            lblt2.Visible = True
            lblt3.Visible = True
            TxtTCr.Visible = True
            TxtTdr.Visible = True
            TxtList.Columns("TDr").Visible = True
            TxtList.Columns("TCr").Visible = True

        ElseIf ShowNetTransactions.Checked = False And TxtShowOpeiningBalances.Checked = False Then
            lblt1.Visible = False
            lblt2.Visible = False
            lblt3.Visible = False
            TxtTCr.Visible = False
            TxtTdr.Visible = False
            TxtList.Columns("TDr").Visible = False
            TxtList.Columns("TCr").Visible = False
            lblOp1.Text = "Opening Balances"
            lblt1.Text = "Transactions Balances"
            lblOp1.Visible = False
            lblop2.Visible = False
            lblop3.Visible = False
            TxtOpCr.Visible = False
            TxtOpDr.Visible = False
            TxtList.Columns("Topdr").Visible = False
            TxtList.Columns("TopCr").Visible = False

        ElseIf ShowNetTransactions.Checked = True And TxtShowOpeiningBalances.Checked = False Then

            lblt1.Visible = True
            lblt2.Visible = True
            lblt3.Visible = True
            TxtTCr.Visible = True
            TxtTdr.Visible = True
            TxtList.Columns("TDr").Visible = True
            TxtList.Columns("TCr").Visible = True
            lblt1.Text = "Transactions Balances"


            lblOp1.Text = "Opening Balances"
            lblOp1.Visible = False
            lblop2.Visible = False
            lblop3.Visible = False
            TxtOpCr.Visible = False
            TxtOpDr.Visible = False
            TxtList.Columns("Topdr").Visible = False
            TxtList.Columns("TopCr").Visible = False

        ElseIf ShowNetTransactions.Checked = False And TxtShowOpeiningBalances.Checked = True Then
            lblt1.Visible = True
            lblt2.Visible = True
            lblt3.Visible = True
            TxtTCr.Visible = True
            TxtTdr.Visible = True
            TxtList.Columns("TDr").Visible = False
            TxtList.Columns("TCr").Visible = False
            lblt1.Text = "Opening Balances"


            lblOp1.Text = "Opening Balances"
            lblOp1.Visible = False
            lblop2.Visible = False
            lblop3.Visible = False
            TxtOpCr.Visible = False
            TxtOpDr.Visible = False
            TxtList.Columns("Topdr").Visible = True
            TxtList.Columns("TopCr").Visible = True
        End If
    End Sub
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New TrailBalanceSheetDataset
        ds.Clear()
        For i As Integer = 0 To TxtList.RowCount - 1
            Dim row As DataRow
            row = ds.Tables(0).NewRow
            For k As Integer = 0 To TxtList.ColumnCount - 1
                Try
                    row(TxtList.Columns(k).Name) = TxtList.Item(k, i).Value
                Catch ex As Exception
                    row(TxtList.Columns(k).Name) = 0
                End Try

            Next
            ds.Tables(0).Rows.Add(row)
        Next
        Dim objRpt As New TrailBalanceSheetCrReport
     
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "TRIAL BALANCE SHEET"
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "TRIAL BALANCE SHEET"

        End If


        CType(objRpt.Section4.ReportObjects.Item("LBLOP4"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtOpDr.Text
        CType(objRpt.Section4.ReportObjects.Item("lblop5"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtOpCr.Text
        CType(objRpt.Section4.ReportObjects.Item("lbltdr"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtTdr.Text
        CType(objRpt.Section4.ReportObjects.Item("lbltcr"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtTCr.Text
        ' CType(objRpt.Section4.ReportObjects.Item("lblclosing"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtClosingBalanceCr.Text




        If TxtShowOpeiningBalances.Checked = False Then
            CType(objRpt.Section4.ReportObjects.Item("LBLOP1"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section4.ReportObjects.Item("LBLOP2"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section4.ReportObjects.Item("LBLOP3"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section4.ReportObjects.Item("Topdr1"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section4.ReportObjects.Item("Topcr1"), CrystalDecisions.CrystalReports.Engine.FieldObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section4.ReportObjects.Item("LBLOP4"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableSuppress = True
            CType(objRpt.Section4.ReportObjects.Item("lblop5"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableSuppress = True

        End If
        '

        objRpt.SetDataSource(ds)
        Dim FRM As New ReportCommonForm(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cursor = Cursors.Default
        FRM.ShowDialog()
        FRM.Dispose()
        objRpt.Dispose()
        ds.Dispose()
    End Sub

    Private Sub TxtSupressZeros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSupressZeros.CheckedChanged
        supressZeros()
    End Sub
    Sub supressZeros()
        On Error Resume Next
        If TxtSupressZeros.Checked = True Then
            For i As Integer = 0 To TxtList.RowCount - 1
                If TxtList.Item("Topdr", i).Value = ErpZeroValue() Then
                    TxtList.Item("Topdr", i).Value = ""
                End If
                If TxtList.Item("Topcr", i).Value = ErpZeroValue() Then
                    TxtList.Item("Topcr", i).Value = ""
                End If
                If TxtList.Item("TDr", i).Value = ErpZeroValue() Then
                    TxtList.Item("TDr", i).Value = ""
                End If
                If TxtList.Item("TCr", i).Value = ErpZeroValue() Then
                    TxtList.Item("TCr", i).Value = ""
                End If
                If TxtList.Item("tclosing", i).Value = ErpZeroValue() Then
                    TxtList.Item("tclosing", i).Value = ""
                End If

                If TxtList.Item("tCloCr", i).Value = ErpZeroValue() Then
                    TxtList.Item("tCloCr", i).Value = ""
                End If
               
            Next
        Else
            For i As Integer = 0 To TxtList.RowCount - 1
                If TxtList.Item("Topdr", i).Value.ToString = "" Then
                    TxtList.Item("Topdr", i).Value = ErpZeroValue()
                End If
                If TxtList.Item("Topcr", i).Value.ToString = "" Then
                    TxtList.Item("Topcr", i).Value = ErpZeroValue()
                End If
                If TxtList.Item("TDr", i).Value.ToString = "" Then
                    TxtList.Item("TDr", i).Value = ErpZeroValue()
                End If
                If TxtList.Item("TCr", i).Value.ToString = "" Then
                    TxtList.Item("TCr", i).Value = ErpZeroValue()
                End If
                If TxtList.Item("tclosing", i).Value.ToString = "" Then
                    TxtList.Item("tclosing", i).Value = ErpZeroValue()
                End If
                If TxtList.Item("tCloCr", i).Value.ToString = "" Then
                    TxtList.Item("tCloCr", i).Value = ErpZeroValue()
                End If

            Next
        End If
      
    End Sub

    Private Sub TxtShowWithOpeningStock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShowWithOpeningStock.CheckedChanged
        If FormLevel = 1 Then
            loaddata()
        ElseIf FormLevel = 2 Then
            LoadSelctedGroupData(SelectedGroupname)
        End If
    End Sub
End Class