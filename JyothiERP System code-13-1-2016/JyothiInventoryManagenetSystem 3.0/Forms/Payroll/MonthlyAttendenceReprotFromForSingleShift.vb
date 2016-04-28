Public Class MonthlyAttendenceReprotFromForSingleShift

    Private Sub MonthlyAttendenceReprotFromForSingleShift_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub MonthlyAttendenceReportFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtPresentYear.Items.Clear()
        For i As Integer = CompDetails.AccDateFrom.Date.Year To CompDetails.AccDateTo.Date.Year
            TxtPresentYear.Items.Add(i)
        Next
        LoadDataIntoComboBox("Select empname from employees ", TxtEmployeeName, "empname")

    End Sub
    Sub LoadMonthlyData(ByVal tdate As DateTimePicker, ByVal month As Integer)
        Dim SqlStr As String = ""
        Dim TxtpresentDate As New DateTimePicker
        Dim totalp As Double = 0
        Dim totala As Double = 0
        Dim totall As Double = 0
        Dim totalCmpHoldays As Integer = 0
        Dim rno As Integer = 0
        Dim LeaveCode As String = ""
        Dim tdp As New DateTimePicker
        totalp = 0
        totala = 0
        totall = 0

        TxtpresentDate.Value = New Date(TxtPresentYear.Text, month, 1)

        rno = TxtList.Rows.Add

        tdp.Value = TxtpresentDate.Value.Date.AddDays(-(TxtpresentDate.Value.Date.Day - 1))
        TxtList.Item("tmonth", rno).Value = tdp.Value.ToString("MMMMM")
        For i As Integer = 1 To Date.DaysInMonth(tdate.Value.Year, tdate.Value.Month)
            'TxtDepartmentName.Text
            If SQLIsFieldExists("select fromdatevalue from companyleaves where (" & tdp.Value.Date.ToOADate & " between fromdatevalue and todatevalue)") = True Then
                totalCmpHoldays = totalCmpHoldays + 1
            Else
                LeaveCode = SQLGetStringFieldValue("select LeaveCode from empleaves where empname=N'" & TxtEmployeeName.Text & "' and (fromdatevalue<=" & tdp.Value.Date.ToOADate & " and " & tdp.Value.Date.ToOADate & "<=todatevalue)", "LeaveCode")
                If LeaveCode.Length > 0 Then
                    totall = totall + 1
                ElseIf SQLIsFieldExists("SELECT empname FROM EmpAttend where empname=N'" & TxtEmployeeName.Text & "' and Transdatevalue=" & tdp.Value.Date.ToOADate) = True Then
                    Dim totvalue As Double = 0
                    totvalue = SQLGetNumericFieldValue("select TickCount  FROM EmpAttend where empname=N'" & TxtEmployeeName.Text & "' and Transdatevalue=" & tdp.Value.Date.ToOADate, "TickCount")
                    If totvalue = 1 Then
                        totalp = totalp + 1
                    ElseIf totvalue = 0.5 Then
                        totalp = totalp + 1 / 2
                        totala = totala + 1 / 2
                    End If
                ElseIf tdp.Value.Date <= Today.Date Then
                    totala = totala + 1
                Else
                    totala = totala + 1
                End If
            End If
            tdp.Value = tdp.Value.AddDays(1)

        Next
        If TxtIsIncludeHolydays.Checked = True Then
            TxtList.Item("ttworkingdays", rno).Value = Date.DaysInMonth(tdate.Value.Year, tdate.Value.Month) - totalCmpHoldays
            TxtList.Item("tpresent", rno).Value = totalp + totalCmpHoldays
            TxtList.Item("tleaves", rno).Value = totall
            TxtList.Item("tabsents", rno).Value = totala
            TxtList.Item("tcmpleaves", rno).Value = totalCmpHoldays
        Else
            TxtList.Item("ttworkingdays", rno).Value = Date.DaysInMonth(tdate.Value.Year, tdate.Value.Month) - totalCmpHoldays
            TxtList.Item("tpresent", rno).Value = totalp
            TxtList.Item("tleaves", rno).Value = totall
            TxtList.Item("tabsents", rno).Value = totala
            TxtList.Item("tcmpleaves", rno).Value = totalCmpHoldays
        End If


        'totalCmpHoldays
        Dim startdate As New DateTimePicker
        Dim enddate As New DateTimePicker
        startdate.Value = TxtpresentDate.Value.Date.AddDays(-(TxtpresentDate.Value.Date.Day - 1))
        enddate.Value = TxtpresentDate.Value.Date.AddDays(Date.DaysInMonth(TxtpresentDate.Value.Date.Year, TxtpresentDate.Value.Date.Month) - TxtpresentDate.Value.Date.Day)
        Dim otvalue As Integer = 0

        otvalue = SQLGetNumericFieldValue("select sum(ot) as tot from EmpAttend where  empname=N'" & TxtEmployeeName.Text & "' and ( Transdatevalue between " & startdate.Value.Date.ToOADate & " and " & enddate.Value.Date.ToOADate & ")", "tot")
        TxtList.Item("tot", rno).Value = otvalue / DefDutyHours
        If TxtIsIncludeHolydays.Checked = True Then
            TxtList.Item("tnetdays", rno).Value = totalp + totalCmpHoldays + otvalue / DefDutyHours
        Else
            TxtList.Item("tnetdays", rno).Value = totalp + otvalue / DefDutyHours
        End If



    End Sub

    Private Sub TxtEmployeeName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEmployeeName.SelectedIndexChanged, TxtPresentYear.SelectedIndexChanged
        LoaddatabyEmployee()
    End Sub
    Sub LoaddatabyEmployee()

        If TxtPresentYear.Text.Length = 0 Then
            MsgBox("Please select the Year..                 ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtEmployeeName.Text.Length = 0 Then
            MsgBox("Please Select the Employee Name ...       ", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim txtDate As New DateTimePicker
        TxtList.Rows.Clear()
        MainForm.Cursor = Cursors.WaitCursor
        For i As Integer = 1 To 12
            txtDate.Value = New Date(TxtPresentYear.Text, i, 1)
            LoadMonthlyData(txtDate, i)
        Next
        MainForm.Cursor = Cursors.Default
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New EmpAttendenceRepDataSet
        ds.Clear()
        For i As Integer = 0 To TxtList.RowCount - 1
            Dim row As DataRow
            row = ds.Tables("Datatable1").NewRow
            For k As Integer = 0 To TxtList.ColumnCount - 1
                Try
                    row(TxtList.Columns(k).Name) = TxtList.Item(k, i).Value
                Catch ex As Exception
                    row(TxtList.Columns(k).Name) = 0
                End Try
            Next
            ds.Tables("Datatable1").Rows.Add(row)
        Next


        Dim objRpt As New AttendenceMonthlyCrReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(TxtEmployeeName.Text) & " MONTHLY ATTENDENCE REPORT "
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(TxtEmployeeName.Text) & " MONTHLY ATTENDENCE REPORT "
        End If
        objRpt.SetDataSource(ds)
        Dim FRM As New ReportCommonForm(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cursor = Cursors.Default
        FRM.ShowDialog()
        FRM.Dispose()
        objRpt.Dispose()
        ds.Dispose()
    End Sub
End Class