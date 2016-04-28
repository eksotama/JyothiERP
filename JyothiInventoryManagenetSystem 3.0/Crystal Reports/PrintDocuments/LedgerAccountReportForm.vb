Imports System.Data.SqlClient

Public Class LedgerAccountReportForm
    Dim SendLedgerName As String = ""
    Dim SendGroupName As String = ""
    Sub New(Optional ByVal LedgerName As String = "", Optional ByVal AcGroupName As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        SendLedgerName = LedgerName
        SendGroupName = AcGroupName
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Dim CustSqlStr As String = ""
    Dim Crep As New LedgerReportsCRReport
    Dim CrepCur As New LedgerReportCrCurReports
    Dim groupIsOpen As Boolean = False
    Dim IsLoading As Boolean = True
    Dim ShowbyGroup As Boolean = False

    Sub LoadLedgerReport(ByVal ledgername As String)
        If IsLoading = True Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        groupIsOpen = False
        If TxtStartDate.Value > TxtEndDate.Value Then
            Dim ka As DateTimePicker
            ka = TxtStartDate
            TxtStartDate = TxtEndDate
            TxtEndDate = ka
        End If

        Dim dbf As New ADODB.Recordset
        '  Dim crep As New LedgerAccountBalanceRep1
        Dim myDataSet As New Ledgerbook
        myDataSet.Clear()
        Crep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter

        If IsLedgerCurrency.Checked = True Then
            'CrepCur
            CrepCur.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
            ExecuteSQLQuery(" update ledgerbook set ddr=dr*conrate,dcr=cr*conrate where ledgername=N'" & TxtLedgerName.Text & "'")
            If IsDateWiseOn.Checked = True Then
                CustSqlStr = "select * from ledgerbook where  ledgername=N'" & TxtLedgerName.Text & "' and isdeleted=0 and (transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  order by TransDate, InvoiceNo"
            Else
                CustSqlStr = "select * from ledgerbook where ledgername=N'" & TxtLedgerName.Text & "' and isdeleted=0   order by TransDate, InvoiceNo"
            End If
            Try
                Select Case txtView.SelectedIndex
                    Case 0

                        CrepCur.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""daily"")"
                        CrepCur.DataDefinition.Groups.Item(1).GroupOptions.Condition = 0
                    Case 1
                        CrepCur.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""weekly"")"
                        CrepCur.DataDefinition.Groups.Item(1).GroupOptions.Condition = 1
                    Case 2
                        CrepCur.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""biweekly"")"
                        CrepCur.DataDefinition.Groups.Item(1).GroupOptions.Condition = 2
                    Case 3
                        CrepCur.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""semimonthly"")"
                        CrepCur.DataDefinition.Groups.Item(1).GroupOptions.Condition = 3
                    Case 4
                        CrepCur.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""monthly"")"
                        CrepCur.DataDefinition.Groups.Item(1).GroupOptions.Condition = 4
                    Case 5
                        CrepCur.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""quarterly"")"
                        CrepCur.DataDefinition.Groups.Item(1).GroupOptions.Condition = 5
                    Case 6
                        CrepCur.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""semiannually"")"
                        CrepCur.DataDefinition.Groups.Item(1).GroupOptions.Condition = 6
                    Case 7
                        CrepCur.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""annually"")"
                        CrepCur.DataDefinition.Groups.Item(1).GroupOptions.Condition = 7

                End Select
            Catch ex As Exception

            End Try
            Dim cnn As SqlConnection
            cnn = New SqlConnection(ConnectionStrinG)
            cnn.Open()
            Dim dscmd As New SqlDataAdapter(CustSqlStr, cnn)
            dscmd.Fill(myDataSet, "ledgerbook")
            cnn.Close()

            If IsDateWiseOn.Checked = True Then

                CustSqlStr = "select sum(ddr) as dramt, sum(dcr) as cramt from ledgerbook where ledgername=N'" & TxtLedgerName.Text & "' and isdeleted=0 and transdatevalue<" & (CDbl(TxtStartDate.Value.Date.ToOADate))
                Dim dr As Double
                Dim cr As Double
                Dim datestr As String = ""
                ', sum(cr) as cramt 
                dr = SQLGetNumericFieldValue("select sum(ddr) as dramt from ledgerbook where ledgername=N'" & TxtLedgerName.Text & "' and isdeleted=0 and transdatevalue<" & (CDbl(TxtStartDate.Value.Date.ToOADate)), "dramt")
                cr = SQLGetNumericFieldValue("select sum(dcr) as cramt from ledgerbook where ledgername=N'" & TxtLedgerName.Text & "'  and isdeleted=0and transdatevalue<" & (CDbl(TxtStartDate.Value.Date.ToOADate)), "cramt")
                datestr = SQLGetStringFieldValue("select min(TransDate) as d from ledgerbook where ledgername=N'" & TxtLedgerName.Text & "' and isdeleted=0 and transdatevalue>=" & (CDbl(TxtStartDate.Value.Date.ToOADate)), "d")
                If datestr.Length = 0 Then
                    datestr = TxtStartDate.Value.Date.ToString
                End If
                If dr > 0 Or cr > 0 Then
                    If dr > cr Then
                        dr = dr - cr
                        cr = 0
                    Else
                        cr = cr - dr
                        dr = 0
                    End If
                    Dim row As DataRow
                    If datestr.Length = 0 Then
                        datestr = TxtStartDate.Value.Date.ToString
                    End If
                    row = myDataSet.Tables(0).NewRow
                    row("ledgername") = TxtLedgerName.Text
                    row("TransDate") = FormatDateTime(CDate(datestr), DateFormat.ShortDate)
                    row("transdatevalue") = CDate(FormatDateTime(CDate(datestr), DateFormat.ShortDate)).Date.ToOADate
                    row("Acledger") = "BF " & datestr 'FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate).ToString
                    row("ddr") = dr
                    row("dcr") = cr
                    myDataSet.Tables(0).Rows.InsertAt(row, 0)

                End If
            End If




            CrepCur.SetDataSource(myDataSet)
            CType(CrepCur.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = CompDetails.CompanyName
            CType(CrepCur.Section2.ReportObjects.Item("txtcurrency"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Figures in " & SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & TxtLedgerName.Text & "'", "currency")
            CType(CrepCur.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = CompDetails.Companystreet & ", " & CompDetails.Companystate
            'If ShowbyGroup = True Then
            '    CType(CrepCur.Section1.ReportObjects.Item("txtti"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtLedgerName.Text.ToString
            'End If

            If IsDateWiseOn.Checked = True Then
                CType(CrepCur.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Period :" & TxtStartDate.Value.Date & " To " & TxtEndDate.Value.Date
            Else
                CType(CrepCur.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ""
            End If
            If CheckBox1.Checked = True Then
                CrepCur.GroupFooterSection2.SectionFormat.EnableSuppress = True
            Else
                CrepCur.GroupFooterSection2.SectionFormat.EnableSuppress = True
            End If
            If CheckBox2.Checked = True Then
                CrepCur.GroupFooterSection1.SectionFormat.EnableNewPageAfter = True
            Else
                CrepCur.GroupFooterSection1.SectionFormat.EnableNewPageAfter = False
            End If
            Me.CrystalReportViewer1.ReportSource = CrepCur
            Me.CrystalReportViewer1.RefreshReport()
        Else
            If IsDateWiseOn.Checked = True Then
                CustSqlStr = "select * from ledgerbook where ledgername=N'" & TxtLedgerName.Text & "' and isdeleted=0 and (transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  order by TransDate, InvoiceNo"
            Else
                CustSqlStr = "select * from ledgerbook where ledgername=N'" & TxtLedgerName.Text & "' and isdeleted=0   order by TransDate, InvoiceNo"
            End If
            Try
                Select Case txtView.SelectedIndex
                    Case 0

                        Crep.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""daily"")"
                        Crep.DataDefinition.Groups.Item(1).GroupOptions.Condition = 0
                    Case 1
                        Crep.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""weekly"")"
                        Crep.DataDefinition.Groups.Item(1).GroupOptions.Condition = 1
                    Case 2
                        Crep.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""biweekly"")"
                        Crep.DataDefinition.Groups.Item(1).GroupOptions.Condition = 2
                    Case 3
                        Crep.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""semimonthly"")"
                        Crep.DataDefinition.Groups.Item(1).GroupOptions.Condition = 3
                    Case 4
                        Crep.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""monthly"")"
                        Crep.DataDefinition.Groups.Item(1).GroupOptions.Condition = 4
                    Case 5
                        Crep.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""quarterly"")"
                        Crep.DataDefinition.Groups.Item(1).GroupOptions.Condition = 5
                    Case 6
                        Crep.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""semiannually"")"
                        Crep.DataDefinition.Groups.Item(1).GroupOptions.Condition = 6
                    Case 7
                        Crep.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""annually"")"
                        Crep.DataDefinition.Groups.Item(1).GroupOptions.Condition = 7

                End Select
            Catch ex As Exception

            End Try
            Dim cnn As SqlConnection
            cnn = New SqlConnection(ConnectionStrinG)
            cnn.Open()
            Dim dscmd As New SqlDataAdapter(CustSqlStr, cnn)
            dscmd.Fill(myDataSet, "ledgerbook")
            cnn.Close()

            If IsDateWiseOn.Checked = True Then

                CustSqlStr = "select sum(dr) as dramt, sum(cr) as cramt from ledgerbook where ledgername=N'" & TxtLedgerName.Text & "' and isdeleted=0 and transdatevalue<" & (CDbl(TxtStartDate.Value.Date.ToOADate))
                Dim dr As Double
                Dim cr As Double
                Dim datestr As String = ""
                ', sum(cr) as cramt 
                dr = SQLGetNumericFieldValue("select sum(dr) as dramt from ledgerbook where ledgername=N'" & TxtLedgerName.Text & "' and isdeleted=0 and transdatevalue<" & (CDbl(TxtStartDate.Value.Date.ToOADate)), "dramt")
                cr = SQLGetNumericFieldValue("select sum(cr) as cramt from ledgerbook where ledgername=N'" & TxtLedgerName.Text & "' and isdeleted=0 and transdatevalue<" & (CDbl(TxtStartDate.Value.Date.ToOADate)), "cramt")
                datestr = SQLGetStringFieldValue("select min(TransDate) as d from ledgerbook where ledgername=N'" & TxtLedgerName.Text & "' and isdeleted=0 and transdatevalue>=" & (CDbl(TxtStartDate.Value.Date.ToOADate)), "d")
                If datestr.Length = 0 Then
                    datestr = TxtStartDate.Value.Date.ToString
                End If
                If dr > 0 Or cr > 0 Then
                    If dr > cr Then
                        dr = dr - cr
                        cr = 0
                    Else
                        cr = cr - dr
                        dr = 0
                    End If
                    Dim row As DataRow
                    If datestr.Length = 0 Then
                        datestr = TxtStartDate.Value.Date.ToString
                    End If
                    row = myDataSet.Tables(0).NewRow
                    row("ledgername") = TxtLedgerName.Text
                    row("TransDate") = FormatDateTime(CDate(datestr), DateFormat.ShortDate)
                    row("transdatevalue") = CDate(FormatDateTime(CDate(datestr), DateFormat.ShortDate)).Date.ToOADate
                    row("Acledger") = "BF " & datestr 'FormatDateTime(TxtStartDate.Value.Date, DateFormat.ShortDate).ToString
                    row("dr") = dr
                    row("cr") = cr
                    myDataSet.Tables(0).Rows.InsertAt(row, 0)

                End If
            End If




            Crep.SetDataSource(myDataSet)
            SetReportLogos(Crep.Section1.ReportObjects, Crep.DataDefinition, "txthead", "txtsubhead", "txttitle")
            If PrintOptionsforCR.IsPrintHeader = False Then
                CType(Crep.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
                CType(Crep.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
                CType(Crep.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtLedgerName.Text & "Report"
            Else

            End If
            'TxtPeriod
            If IsDateWiseOn.Checked = True Then
                CType(Crep.Section1.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Period :" & TxtStartDate.Value.Date & " To " & TxtEndDate.Value.Date
            Else
                CType(Crep.Section1.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ""
            End If
            If CheckBox1.Checked = True Then
                Crep.GroupFooterSection2.SectionFormat.EnableSuppress = True
            Else
                Crep.GroupFooterSection2.SectionFormat.EnableSuppress = True
            End If
            If CheckBox2.Checked = True Then
                Crep.GroupFooterSection1.SectionFormat.EnableNewPageAfter = True
            Else
                Crep.GroupFooterSection1.SectionFormat.EnableNewPageAfter = False
            End If
            Me.CrystalReportViewer1.ReportSource = Crep
            Me.CrystalReportViewer1.RefreshReport()
        End If

        Me.Cursor = Cursors.Default
    End Sub
    Sub LoadLedgerGroupReport(ByVal ledgername As String)
        If IsLoading = True Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        groupIsOpen = True
        If TxtStartDate.Value > TxtEndDate.Value Then
            Dim ka As DateTimePicker
            ka = TxtStartDate
            TxtStartDate = TxtEndDate
            TxtEndDate = ka
        End If


        Dim myDataSet As New DataSet

        Try
            myDataSet.Clear()
            myDataSet.Tables(0).Rows.Clear()

        Catch ex As Exception

        End Try
        Crep.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter


        If IsDateWiseOn.Checked = True Then
            '    CustSqlStr = "select * from ledgerbook where ledgername=N'" & TxtLedgerName.Text & "' and (transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  order by TransDate, transcode"
            If TxtGroupName.Text = "*All" Then
                CustSqlStr = "select * from ledgerbook where ledgername in (select distinct ledgername from ledgers where AccountGroup in (select subgroup from AccountGroupsList )) " & " and isdeleted=0 and (transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  order by TransDate, transcode"
            Else
                CustSqlStr = "select * from ledgerbook where ledgername in (select distinct ledgername from ledgers where AccountGroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtGroupName.Text & "')) " & " and isdeleted=0 and (transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")  order by TransDate, transcode"
            End If

        Else
            'CustSqlStr = "select * from ledgerbook where ledgername=N'" & TxtLedgerName.Text & "'   order by TransDate, transcode"
            If TxtGroupName.Text = "*All" Then
                CustSqlStr = "select * from ledgerbook where ledgername in (select distinct ledgername from ledgers where AccountGroup in (select subgroup from AccountGroupsList)) and isdeleted=0 "
            Else
                CustSqlStr = "select * from ledgerbook where ledgername in (select distinct ledgername from ledgers where AccountGroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtGroupName.Text & "')) and isdeleted=0 "
            End If

        End If

        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(CustSqlStr, cnn)
        dscmd.Fill(myDataSet, "ledgerbook")

        cnn.Close()



        If IsDateWiseOn.Checked = True Then

            If TxtGroupName.Text = "*All" Then
                'CustSqlStr = "select ledgername,sum(dr) as dramt, sum(cr) cramt,TransDatevlue,acledger from ledgerbook where ledgername in (select distinct sname from ledgers where AccountGroup in (select subgroup from AccountGroupsList )) " & " and transdatevalue<" & (CDbl(TxtStartDate.Value.Date.ToOADate)) & "  order by TransDate, transcode group by ledgername"
                CustSqlStr = "select ledgername,sum(dr)-sum(cr) as cramt  from ledgerbook where ledgername in (select distinct ledgername from ledgers where AccountGroup in (select subgroup from AccountGroupsList )) and isdeleted=0  and transdatevalue<" & (CDbl(TxtStartDate.Value.Date.ToOADate)) & "    group by ledgername"
            Else
                'CustSqlStr = "select ledgername,sum(dr) as dramt, sum(cr) cramt,TransDatevlue,acledger from ledgerbook where ledgername in (select distinct ledgername from ledgers where AccountGroup in (select subgroup from AccountGroupsList where groupname=N'" & txtGroupName.Text & "')) " & " and transdatevalue<" & (CDbl(TxtStartDate.Value.Date.ToOADate)) & "  order by TransDate, transcode group by ledgername"
                CustSqlStr = "select ledgername,sum(dr)-sum(cr) as cramt  from ledgerbook where ledgername in (select distinct ledgername from ledgers where AccountGroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtGroupName.Text & "' ))  and isdeleted=0 and transdatevalue<" & (CDbl(TxtStartDate.Value.Date.ToOADate)) & "    group by ledgername"
            End If
            Dim SqlConn As New SqlClient.SqlConnection
            Try
                SqlConn.ConnectionString = ConnectionStrinG
                SqlConn.Open()
                SqlFcmd.Connection = SqlConn
                SqlFcmd.CommandText = CustSqlStr
                SqlFcmd.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SqlFcmd.ExecuteReader
                While Sreader.Read()
                    Dim datestr As String = ""
                    ' dr = SQLGetNumericFieldValue("select sum(dr) as dramt from ledgerbook where ledgername=N'" & TxtLedgerName.Text & "' and transdatevalue<" & (CDbl(TxtStartDate.Value.Date.ToOADate)), "dramt")
                    ' cr = SQLGetNumericFieldValue("select sum(cr) as cramt from ledgerbook where ledgername=N'" & TxtLedgerName.Text & "' and transdatevalue<" & (CDbl(TxtStartDate.Value.Date.ToOADate)), "cramt")
                    If Sreader("cramt").ToString.Trim.Length > 0 Then
                        ' MsgBox(Sreader("cramt").ToString.Trim)
                        If CDbl(Sreader("cramt").ToString.Trim) > 0 Then
                            datestr = SQLGetStringFieldValue("select min(TransDate) as d  from ledgerbook where ledgername=N'" & Sreader("ledgername").ToString.Trim & "' and isdeleted=0  and transdatevalue>=" & (CDbl(TxtStartDate.Value.Date.ToOADate)), "d")
                            If datestr.Length = 0 Then
                                datestr = TxtStartDate.Value.Date.ToString
                            End If
                            Dim row As DataRow
                            row = myDataSet.Tables(0).NewRow
                            row("TransDate") = datestr
                            row("ledgername") = Sreader("ledgername").ToString.Trim
                            row("Acledger") = "BF " & datestr
                            row("dr") = Sreader("cramt")
                            row("cr") = 0
                            myDataSet.Tables(0).Rows.InsertAt(row, 0)
                        ElseIf CDbl(Sreader("cramt").ToString.Trim) < 0 Then
                            datestr = SQLGetStringFieldValue("select min(TransDate) as d  from ledgerbook where ledgername=N'" & Sreader("ledgername").ToString.Trim & "' and isdeleted=0  and transdatevalue>=" & (CDbl(TxtStartDate.Value.Date.ToOADate)), "d")
                            If datestr.Length = 0 Then
                                datestr = TxtStartDate.Value.Date.ToString
                            End If
                            Dim row As DataRow
                            row = myDataSet.Tables(0).NewRow
                            row("ledgername") = Sreader("ledgername").ToString.Trim
                            row("TransDate") = datestr
                            row("Acledger") = "BF " & datestr
                            row("dr") = 0
                            row("cr") = CDbl(Sreader("cramt")) * -1
                            myDataSet.Tables(0).Rows.InsertAt(row, 0)
                        End If

                    End If
                    

                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SqlConn.Close()

                SqlFcmd.Connection = Nothing
            End Try

        End If




        Crep.SetDataSource(myDataSet)



        Try
            Select Case txtView.SelectedIndex
                Case 0

                    Crep.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""daily"")"
                    Crep.DataDefinition.Groups.Item(1).GroupOptions.Condition = 0
                Case 1
                    Crep.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""weekly"")"
                    Crep.DataDefinition.Groups.Item(1).GroupOptions.Condition = 1
                Case 2
                    Crep.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""biweekly"")"
                    Crep.DataDefinition.Groups.Item(1).GroupOptions.Condition = 2
                Case 3
                    Crep.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""semimonthly"")"
                    Crep.DataDefinition.Groups.Item(1).GroupOptions.Condition = 3
                Case 4
                    Crep.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""monthly"")"
                    Crep.DataDefinition.Groups.Item(1).GroupOptions.Condition = 4
                Case 5
                    Crep.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""quarterly"")"
                    Crep.DataDefinition.Groups.Item(1).GroupOptions.Condition = 5
                Case 6
                    Crep.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""semiannually"")"
                    Crep.DataDefinition.Groups.Item(1).GroupOptions.Condition = 6
                Case 7
                    Crep.DataDefinition.FormulaFields.Item("vhdr").Text = "formula = GroupName ({LedgerBook.TransDate}, ""annually"")"
                    Crep.DataDefinition.Groups.Item(1).GroupOptions.Condition = 7

            End Select
        Catch ex As Exception

        End Try

        CType(Crep.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = CompDetails.CompanyName
        CType(Crep.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = CompDetails.Companystreet & ", " & CompDetails.Companystate
        'If ShowbyGroup = True Then
        '    CType(Crep.Section1.ReportObjects.Item("txtti"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtLedgerName.Text.ToString
        'End If

        If IsDateWiseOn.Checked = True Then
            CType(Crep.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "Period :" & TxtStartDate.Value.Date & " To " & TxtEndDate.Value.Date
        Else
            CType(Crep.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ""
        End If



        If CheckBox1.Checked = True Then
            Crep.GroupFooterSection2.SectionFormat.EnableSuppress = True
            Crep.GroupHeaderSection2.SectionFormat.EnableSuppress = True
        Else
            Crep.GroupFooterSection2.SectionFormat.EnableSuppress = True
            Crep.GroupHeaderSection2.SectionFormat.EnableSuppress = False
        End If
        If CheckBox2.Checked = True Then
            Crep.GroupFooterSection1.SectionFormat.EnableNewPageAfter = True
        Else
            Crep.GroupFooterSection1.SectionFormat.EnableNewPageAfter = False
        End If


        Me.CrystalReportViewer1.ReportSource = Crep
        Me.CrystalReportViewer1.RefreshReport()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub UserButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        If TxtLedgerName.Text.Length = 0 Then
            Exit Sub
        End If
        ShowbyGroup = False
        LoadLedgerReport(TxtLedgerName.Text)
    End Sub

    Private Sub UserButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        If TxtGroupName.Text.Length = 0 Then
            Exit Sub
        End If
        ShowbyGroup = True
        LoadLedgerGroupReport(TxtGroupName.Text)
    End Sub

    Private Sub LedgerAccountReportForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub AllLedgerReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        If My.Computer.Screen.WorkingArea.Width <= 1024 Then
            Me.Font = New Font(Me.Font.Name, 8, FontStyle.Regular)
        End If
        IsLoading = True

        If DefDepartment = "Sales" Then
            LoadDataIntoComboBox("Select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "' ", TxtGroupName, "subgroup", "*All")
            LoadDataIntoComboBox("SELECT LEDGERNAME FROM LEDGERS where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "'))", TxtLedgerName, "ledgername")
        ElseIf DefDepartment = "Purchase" Then
            LoadDataIntoComboBox("Select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "'", TxtGroupName, "subgroup", "*All")
            LoadDataIntoComboBox("SELECT LEDGERNAME FROM LEDGERS where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "'))", TxtLedgerName, "ledgername")
        ElseIf DefDepartment = "Inventory" Then
            LoadDataIntoComboBox("Select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CustomersAccounts & "' ", TxtGroupName, "subgroup", "*All")
            LoadDataIntoComboBox("SELECT LEDGERNAME FROM LEDGERS where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "' or groupname=N'" & AccountGroupNames.CustomersAccounts & "'))", TxtLedgerName, "ledgername")
        Else
            LoadDataIntoComboBox("select GroupName from AccountGroups ", TxtGroupName, "GroupName", "*All")
            LoadDataIntoComboBox("select ledgername from ledgers ", TxtLedgerName, "ledgername")
        End If

        txtView.Text = "For Each Month"

        If SendGroupName.Length > 0 Then
            ShowbyGroup = True
            TxtGroupName.Text = SendGroupName
            LoadLedgerGroupReport(SendGroupName)
        ElseIf SendLedgerName.Length > 0 Then
            ShowbyGroup = False
            TxtLedgerName.Text = SendLedgerName
            LoadLedgerReport(SendLedgerName)
        End If

        IsLoading = False
    End Sub

    Private Sub IsDateWiseOn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsDateWiseOn.CheckedChanged
        If IsDateWiseOn.Checked = True Then
            TxtStartDate.Enabled = True
            TxtEndDate.Enabled = True
        Else
            TxtStartDate.Enabled = False
            TxtEndDate.Enabled = False
        End If
    End Sub

    Private Sub UserButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        If groupIsOpen = True Then
            If TxtGroupName.Text.Length = 0 Then
                Exit Sub
            End If
            ShowbyGroup = True
            LoadLedgerGroupReport(TxtGroupName.Text)
        Else
            If TxtLedgerName.Text.Length = 0 Then
                Exit Sub
            End If
            ShowbyGroup = False
            LoadLedgerReport(TxtLedgerName.Text)
        End If
    End Sub



    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If groupIsOpen = True Then
            If TxtGroupName.Text.Length = 0 Then
                Exit Sub
            End If
            ShowbyGroup = True
            LoadLedgerGroupReport(TxtGroupName.Text)
        Else
            If TxtLedgerName.Text.Length = 0 Then
                Exit Sub
            End If
            ShowbyGroup = False
            LoadLedgerReport(TxtLedgerName.Text)
        End If
    End Sub

    Private Sub txtView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtView.SelectedIndexChanged
        If groupIsOpen = True Then
            If TxtGroupName.Text.Length = 0 Then
                Exit Sub
            End If
            ShowbyGroup = True
            LoadLedgerGroupReport(TxtGroupName.Text)
        Else
            If TxtLedgerName.Text.Length = 0 Then
                Exit Sub
            End If
            ShowbyGroup = False
            LoadLedgerReport(TxtLedgerName.Text)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If groupIsOpen = True Then
            If TxtGroupName.Text.Length = 0 Then
                Exit Sub
            End If
            ShowbyGroup = True
            LoadLedgerGroupReport(TxtGroupName.Text)
        Else
            If TxtLedgerName.Text.Length = 0 Then
                Exit Sub
            End If
            ShowbyGroup = False
            LoadLedgerReport(TxtLedgerName.Text)
        End If
    End Sub

   
    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsLedgerCurrency.CheckedChanged
        LoadLedgerReport(TxtLedgerName.Text)
    End Sub

    
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class