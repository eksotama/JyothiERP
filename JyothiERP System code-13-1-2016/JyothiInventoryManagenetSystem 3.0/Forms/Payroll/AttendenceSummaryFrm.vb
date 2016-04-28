Public Class AttendenceSummaryFrm
    
    Sub LoadMonthlyData(ByVal tdate As DateTimePicker)

        Dim Employeeslist As New ComboBox
        If TxtDepartmentName.Text.Length = 0 Or TxtDepartmentName.Text = "*All" Then
            LoadDataIntoComboBox("Select empname from employees ", Employeeslist, "Empname")
        Else
            LoadDataIntoComboBox("Select empname from employees where depname=N'" & TxtDepartmentName.Text & "'", Employeeslist, "Empname")
        End If
        MainForm.Cursor = Cursors.WaitCursor
        TxtList.Rows.Clear()
        For emprowno As Integer = 0 To Employeeslist.Items.Count - 1
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

            TxtpresentDate.Value = New Date(TxtCurrentDate.Value.Year, TxtCurrentDate.Value.Date.Month, 1)

            rno = TxtList.Rows.Add

            tdp.Value = TxtpresentDate.Value.Date.AddDays(-(TxtpresentDate.Value.Date.Day - 1))
            TxtList.Item("tmonth", rno).Value = Employeeslist.Items(emprowno).ToString
            For i As Integer = 1 To Date.DaysInMonth(tdate.Value.Year, tdate.Value.Month)
                'TxtDepartmentName.Text
                If SQLIsFieldExists("select fromdatevalue from companyleaves where (" & tdp.Value.Date.ToOADate & " between fromdatevalue and todatevalue)") = True Then
                    totalCmpHoldays = totalCmpHoldays + 1
                Else
                    LeaveCode = SQLGetStringFieldValue("select LeaveCode from empleaves where empname=N'" & Employeeslist.Items(emprowno).ToString & "' and (fromdatevalue<=" & tdp.Value.Date.ToOADate & " and " & tdp.Value.Date.ToOADate & "<=todatevalue)", "LeaveCode")
                    If LeaveCode.Length > 0 Then
                        totall = totall + 1
                    ElseIf SQLIsFieldExists("SELECT empname FROM EmpAttend where empname=N'" & Employeeslist.Items(emprowno).ToString & "' and Transdatevalue=" & tdp.Value.Date.ToOADate) = True Then
                        Dim totvalue As Double = 0

                        totvalue = SQLGetNumericFieldValue("select TickCount  FROM EmpAttend where empname=N'" & Employeeslist.Items(emprowno).ToString & "' and Transdatevalue=" & tdp.Value.Date.ToOADate, "TickCount")
                        If totvalue = 1 Then
                            totalp = totalp + 1
                        ElseIf totvalue = 0.5 Then
                            totalp = totalp + 1 / 2
                            totala = totala + 1 / 2
                        End If
                        'totvalue = SQLGetNumericFieldValue("SELECT COUNT(*) AS TOT FROM EmpAttend where empname=N'" & Employeeslist.Items(emprowno).ToString & "' and Transdatevalue=" & tdp.Value.Date.ToOADate, "TOT")
                        'If totvalue = 2 Then
                        '    totalp = totalp + 1
                        'ElseIf totvalue = 1 Then
                        '    If SQLIsFieldExists("SELECT empname FROM EmpAttend where period='M' and  empname=N'" & Employeeslist.Items(emprowno).ToString & "' and Transdatevalue=" & tdp.Value.Date.ToOADate) = True Then
                        '        totalp = totalp + 1 / 2
                        '        totala = totala + 1 / 2
                        '    ElseIf SQLIsFieldExists("SELECT empname FROM EmpAttend where  period='E' and empname=N'" & Employeeslist.Items(emprowno).ToString & "' and Transdatevalue=" & tdp.Value.Date.ToOADate) = True Then
                        '        totalp = totalp + 1 / 2
                        '        totala = totala + 1 / 2
                        '    End If
                        'End If


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

            otvalue = SQLGetNumericFieldValue("select sum(ot) as tot from EmpAttend where  period='M' and empname=N'" & Employeeslist.Items(emprowno).ToString & "' and ( Transdatevalue between " & startdate.Value.Date.ToOADate & " and " & enddate.Value.Date.ToOADate & ")", "tot")
            TxtList.Item("tot", rno).Value = otvalue / DefDutyHours
            If TxtIsIncludeHolydays.Checked = True Then
                TxtList.Item("tnetdays", rno).Value = totalp + totalCmpHoldays + otvalue / DefDutyHours
            Else
                TxtList.Item("tnetdays", rno).Value = totalp + otvalue / DefDutyHours
            End If

        Next
        MainForm.Cursor = Cursors.Default
    End Sub

    Private Sub TxtDepartmentName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDepartmentName.SelectedIndexChanged
        LoadMonthlyData(TxtCurrentDate)
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        LoadMonthlyData(TxtCurrentDate)
    End Sub

    Private Sub AttendenceSummaryFrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub AttendenceSummaryFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("SELECT  DepName FROM DepartmentGroups", TxtDepartmentName, "DepName", "*All")
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click, PrintToolStripMenuItem.Click
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


        Dim objRpt As New AttendenceSummaryCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = " ATTENDENCE SUMMARY REPORT FOR  " & UCase(TxtCurrentDate.Text)
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = " ATTENDENCE SUMMARY REPORT FOR " & UCase(TxtCurrentDate.Text)
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

    Private Sub TxtIsIncludeHolydays_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles TxtIsIncludeHolydays.CheckedChanged
        LoadMonthlyData(TxtCurrentDate)
    End Sub
End Class