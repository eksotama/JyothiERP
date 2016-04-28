Public Class EmployeeIDMonitor
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Dim Sqlstr As String
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtEmpIDList.DataError

    End Sub
    Sub loaddata()


        Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY empid) as [Sno], empid as [Employee ID],EmpName as [Employee Name],contractexpirydate as [Contract Expiry], " _
            & " passportexpire as [Passport Expiry],visaexpire as [VISA Expiry],Emiratesexpire as [Emirate Expiry],Labourcardexpire as [Labour Card Expiry]," _
            & " Medicalexpire as [Medical Expiry],leavesalaryduedays AS [Leave Salary Due] ,airticketduedays as [Air Ticket Due]  from Employees where isdelete=0 "
        If TxtDepartmentName.Text.Length = 0 Or TxtDepartmentName.Text = "*All" Then
        Else
            Sqlstr = Sqlstr & " and depname=N'" & TxtDepartmentName.Text & "'"
        End If

        Dim TempBS As New BindingSource
        '   Me.TxtList.Rows.Clear()
        With Me.TxtEmpIDList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Me.TxtEmpIDList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtEmpIDList.Columns(0).Width = 45
        Me.TxtEmpIDList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtEmpIDList.Columns(1).Width = 40
        Me.TxtEmpIDList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtEmpIDList.Columns(2).Width = 120

        For i As Integer = 0 To TxtEmpIDList.RowCount - 1
            'Leave Salary Due
            'Air Ticket Due
            Dim totat As Long = 0
            If CheckBox1.Checked = True Then
                totat = Math.Round(SQLGetNumericFieldValue("select Sum((TotalworkingMin-lt+ot)/TotalworkingMin) as tt from EmpAttend where status='P' and  empname=N'" & TxtEmpIDList.Item("Employee Name", i).Value & "' and Transdatevalue >= (select leavesalaryfrom from Employees where empname=N'" & TxtEmpIDList.Item("Employee Name", i).Value & "')", "tt"))
            Else
                totat = Math.Round(SQLGetNumericFieldValue("select Sum((TotalworkingMin-lt)/TotalworkingMin) as tt from EmpAttend where status='P' and  empname=N'" & TxtEmpIDList.Item("Employee Name", i).Value & "' and Transdatevalue >= (select leavesalaryfrom from Employees where empname=N'" & TxtEmpIDList.Item("Employee Name", i).Value & "')", "tt"))
            End If

            TxtEmpIDList.Item("Leave Salary Due", i).Value = CLng(TxtEmpIDList.Item("Leave Salary Due", i).Value) - totat
            totat = 0
            If CheckBox1.Checked = True Then
                totat = Math.Round(SQLGetNumericFieldValue("select Sum((TotalworkingMin-lt+ot)/TotalworkingMin) as tt from EmpAttend where status='P' and  empname=N'" & TxtEmpIDList.Item("Employee Name", i).Value & "' and Transdatevalue >= (select airticketfrom from Employees where empname=N'" & TxtEmpIDList.Item("Employee Name", i).Value & "')", "tt"))
            Else
                totat = Math.Round(SQLGetNumericFieldValue("select Sum((TotalworkingMin-lt)/TotalworkingMin) as tt from EmpAttend where status='P' and  empname=N'" & TxtEmpIDList.Item("Employee Name", i).Value & "' and Transdatevalue >= (select airticketfrom from Employees where empname=N'" & TxtEmpIDList.Item("Employee Name", i).Value & "')", "tt"))
            End If
            TxtEmpIDList.Item("Air Ticket Due", i).Value = CLng(TxtEmpIDList.Item("Air Ticket Due", i).Value) - totat
        Next

    End Sub

    Private Sub EmployeeIDMonitor_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub EmployeeIDMonitor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("SELECT  DepName FROM DepartmentGroups", TxtDepartmentName, "DepName", "*All")
        loaddata()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub TxtList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtEmpIDList.CellDoubleClick
        If TxtEmpIDList.RowCount = 0 Then Exit Sub
        If TxtEmpIDList.CurrentRow.Index < 0 Then Exit Sub
        'Contract Expiry
        'Passport Expiry
        'VISA Expiry
        'Emirate Expiry
        'Labour Card Expiry
        'Medical Expiry
        RENEWIDS()

    End Sub

    Private Sub TxtList_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles TxtEmpIDList.CellPainting
        Dim expDate As New Date
        Dim Days As Integer = 0
        For i As Integer = 0 To TxtEmpIDList.Rows.Count - 1
            'Passport Expiry
            'VISA Expiry
            'Emirate Expiry
            'Labour Card Expiry
            'Medical Expiry
            expDate = TxtEmpIDList.Item("VISA Expiry", i).Value
            Days = DateDiff(DateInterval.Day, Today.Date, expDate)

            If Days <= 0 Then
                TxtEmpIDList.Item("VISA Expiry", i).Style.BackColor = Color.IndianRed
            ElseIf Days < 60 Then
                TxtEmpIDList.Item("VISA Expiry", i).Style.BackColor = Color.LightGoldenrodYellow
            Else
                TxtEmpIDList.Item("VISA Expiry", i).Style.BackColor = Color.LightGreen
            End If

            expDate = TxtEmpIDList.Item("Contract Expiry", i).Value
            Days = DateDiff(DateInterval.Day, Today.Date, expDate)

            If Days <= 0 Then
                TxtEmpIDList.Item("Contract Expiry", i).Style.BackColor = Color.IndianRed
            ElseIf Days <= 60 Then
                TxtEmpIDList.Item("Contract Expiry", i).Style.BackColor = Color.LightGoldenrodYellow
            Else
                TxtEmpIDList.Item("Contract Expiry", i).Style.BackColor = Color.LightGreen
            End If

            expDate = TxtEmpIDList.Item("Passport Expiry", i).Value
            Days = DateDiff(DateInterval.Day, Today.Date, expDate)

            If Days <= 0 Then
                TxtEmpIDList.Item("Passport Expiry", i).Style.BackColor = Color.IndianRed
            ElseIf Days <= 60 Then
                TxtEmpIDList.Item("Passport Expiry", i).Style.BackColor = Color.LightGoldenrodYellow
            Else
                TxtEmpIDList.Item("Passport Expiry", i).Style.BackColor = Color.LightGreen
            End If


            expDate = TxtEmpIDList.Item("Medical Expiry", i).Value
            Days = DateDiff(DateInterval.Day, Today.Date, expDate)

            If Days <= 0 Then
                TxtEmpIDList.Item("Medical Expiry", i).Style.BackColor = Color.IndianRed
            ElseIf Days <= 60 Then
                TxtEmpIDList.Item("Medical Expiry", i).Style.BackColor = Color.LightGoldenrodYellow
            Else
                TxtEmpIDList.Item("Medical Expiry", i).Style.BackColor = Color.LightGreen
            End If


            expDate = TxtEmpIDList.Item("Labour Card Expiry", i).Value
            Days = DateDiff(DateInterval.Day, Today.Date, expDate)

            If Days <= 0 Then
                TxtEmpIDList.Item("Labour Card Expiry", i).Style.BackColor = Color.IndianRed
            ElseIf Days <= 60 Then
                TxtEmpIDList.Item("Labour Card Expiry", i).Style.BackColor = Color.LightGoldenrodYellow
            Else
                TxtEmpIDList.Item("Labour Card Expiry", i).Style.BackColor = Color.LightGreen
            End If

            expDate = TxtEmpIDList.Item("Emirate Expiry", i).Value
            Days = DateDiff(DateInterval.Day, Today.Date, expDate)

            If Days <= 0 Then
                TxtEmpIDList.Item("Emirate Expiry", i).Style.BackColor = Color.IndianRed
            ElseIf Days <= 60 Then
                TxtEmpIDList.Item("Emirate Expiry", i).Style.BackColor = Color.LightGoldenrodYellow
            Else
                TxtEmpIDList.Item("Emirate Expiry", i).Style.BackColor = Color.LightGreen
            End If

            If CInt(TxtEmpIDList.Item("Air Ticket Due", i).Value) > 0 Then
                TxtEmpIDList.Item("Air Ticket Due", i).Style.BackColor = Color.LightGreen
            Else
                TxtEmpIDList.Item("Air Ticket Due", i).Style.BackColor = Color.IndianRed
            End If
            If CInt(TxtEmpIDList.Item("Leave Salary Due", i).Value) > 0 Then
                TxtEmpIDList.Item("Leave Salary Due", i).Style.BackColor = Color.LightGreen
            Else
                TxtEmpIDList.Item("Leave Salary Due", i).Style.BackColor = Color.IndianRed
            End If
        Next

    End Sub

    Private Sub TxtDepartmentName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDepartmentName.SelectedIndexChanged
        loaddata()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, RenewToolStripMenuItem.Click
        If TxtEmpIDList.RowCount = 0 Then Exit Sub
        If TxtEmpIDList.CurrentRow.Index < 0 Then Exit Sub
        'Contract Expiry
        'Passport Expiry
        'VISA Expiry
        'Emirate Expiry
        'Labour Card Expiry
        'Medical Expiry
        'Air Ticket Due
        'Leave Salary Due
        RENEWIDS()
    End Sub

    Sub RENEWIDS()
        Dim Expdate As New Date
        Dim Days As Integer = 0
        If TxtEmpIDList.Columns(TxtEmpIDList.CurrentCell.ColumnIndex).Name = "Contract Expiry" Then
            Expdate = TxtEmpIDList.Item(TxtEmpIDList.CurrentCell.ColumnIndex, TxtEmpIDList.CurrentCell.RowIndex).Value
            Days = DateDiff(DateInterval.Day, Today.Date, Expdate)
            If Days <= 0 Then
                If MsgBox("Do you want to Renewal ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim k As New RenewEmpExpiry(TxtEmpIDList.Item("Employee Name", TxtEmpIDList.CurrentRow.Index).Value, "Contract Expiry")
                    k.TxtExpiry.MinDate = Expdate.AddDays(1)
                    k.ShowDialog()
                    loaddata()
                End If
            End If


        ElseIf TxtEmpIDList.Columns(TxtEmpIDList.CurrentCell.ColumnIndex).Name = "Passport Expiry" Then
            Expdate = TxtEmpIDList.Item(TxtEmpIDList.CurrentCell.ColumnIndex, TxtEmpIDList.CurrentCell.RowIndex).Value
            Days = DateDiff(DateInterval.Day, Today.Date, Expdate)
            If Days <= 0 Then
                If MsgBox("Do you want to Renewal ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim k As New RenewEmpExpiry(TxtEmpIDList.Item("Employee Name", TxtEmpIDList.CurrentRow.Index).Value, "Passport Expiry")
                    k.TxtExpiry.MinDate = Expdate.AddDays(1)
                    k.ShowDialog()
                    loaddata()
                End If
            End If

        ElseIf TxtEmpIDList.Columns(TxtEmpIDList.CurrentCell.ColumnIndex).Name = "VISA Expiry" Then
            Expdate = TxtEmpIDList.Item(TxtEmpIDList.CurrentCell.ColumnIndex, TxtEmpIDList.CurrentCell.RowIndex).Value
            Days = DateDiff(DateInterval.Day, Today.Date, Expdate)
            If Days <= 0 Then
                If MsgBox("Do you want to Renewal ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim k As New RenewEmpExpiry(TxtEmpIDList.Item("Employee Name", TxtEmpIDList.CurrentRow.Index).Value, "VISA Expiry")
                    k.TxtExpiry.MinDate = Expdate.AddDays(1)
                    k.ShowDialog()
                    loaddata()
                End If
            End If
        ElseIf TxtEmpIDList.Columns(TxtEmpIDList.CurrentCell.ColumnIndex).Name = "Emirate Expiry" Then
            Expdate = TxtEmpIDList.Item(TxtEmpIDList.CurrentCell.ColumnIndex, TxtEmpIDList.CurrentCell.RowIndex).Value
            Days = DateDiff(DateInterval.Day, Today.Date, Expdate)
            If Days <= 0 Then
                If MsgBox("Do you want to Renewal ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim k As New RenewEmpExpiry(TxtEmpIDList.Item("Employee Name", TxtEmpIDList.CurrentRow.Index).Value, "Emirate Expiry")
                    k.TxtExpiry.MinDate = Expdate.AddDays(1)
                    k.ShowDialog()
                    loaddata()
                End If
            End If
        ElseIf TxtEmpIDList.Columns(TxtEmpIDList.CurrentCell.ColumnIndex).Name = "Labour Card Expiry" Then
            Expdate = TxtEmpIDList.Item(TxtEmpIDList.CurrentCell.ColumnIndex, TxtEmpIDList.CurrentCell.RowIndex).Value
            Days = DateDiff(DateInterval.Day, Today.Date, Expdate)
            If Days <= 0 Then
                If MsgBox("Do you want to Renewal ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim k As New RenewEmpExpiry(TxtEmpIDList.Item("Employee Name", TxtEmpIDList.CurrentRow.Index).Value, "Labour Card Expiry")
                    k.TxtExpiry.MinDate = Expdate.AddDays(1)
                    k.ShowDialog()
                    loaddata()
                End If
            End If
        ElseIf TxtEmpIDList.Columns(TxtEmpIDList.CurrentCell.ColumnIndex).Name = "Medical Expiry" Then
            Expdate = TxtEmpIDList.Item(TxtEmpIDList.CurrentCell.ColumnIndex, TxtEmpIDList.CurrentCell.RowIndex).Value
            Days = DateDiff(DateInterval.Day, Today.Date, Expdate)
            If Days <= 0 Then
                If MsgBox("Do you want to Renewal ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim k As New RenewEmpExpiry(TxtEmpIDList.Item("Employee Name", TxtEmpIDList.CurrentRow.Index).Value, "Medical Expiry")
                    k.TxtExpiry.MinDate = Expdate.AddDays(1)
                    k.ShowDialog()
                    loaddata()
                End If
            End If
            'Air Ticket Due
            'Leave Salary Due
        ElseIf TxtEmpIDList.Columns(TxtEmpIDList.CurrentCell.ColumnIndex).Name = "Air Ticket Due" Then
            If CInt(TxtEmpIDList.Item(TxtEmpIDList.CurrentCell.ColumnIndex, TxtEmpIDList.CurrentCell.RowIndex).Value) < 1 Then
                If MsgBox("Do you want to Renewal ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim k As New RenewDueDays(TxtEmpIDList.Item("Employee Name", TxtEmpIDList.CurrentRow.Index).Value, False)

                    k.ShowDialog()
                    loaddata()
                End If
            End If

        ElseIf TxtEmpIDList.Columns(TxtEmpIDList.CurrentCell.ColumnIndex).Name = "Leave Salary Due" Then
            If CInt(TxtEmpIDList.Item(TxtEmpIDList.CurrentCell.ColumnIndex, TxtEmpIDList.CurrentCell.RowIndex).Value) < 1 Then
                If MsgBox("Do you want to Renewal ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim k As New RenewDueDays(TxtEmpIDList.Item("Employee Name", TxtEmpIDList.CurrentRow.Index).Value, True)

                    k.ShowDialog()
                    loaddata()
                End If
            End If
        End If
    End Sub

    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        loaddata()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        loaddata()
    End Sub


    Private Sub BtnPrint2_Click(sender As Object, e As System.EventArgs) Handles BtnPrint2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New EmployeIDMonitorDataSet
        ds.Clear()
        ds.Tables(0).Rows.Clear()
        For i As Integer = 0 To TxtEmpIDList.RowCount - 1
            Dim row As DataRow
            row = ds.Tables("Datatable1").NewRow
            For k As Integer = 0 To TxtEmpIDList.ColumnCount - 1
                row(TxtEmpIDList.Columns(k).Name) = TxtEmpIDList.Item(k, i).Value
            Next
            ds.Tables("Datatable1").Rows.Add(row)
        Next

        Dim objRpt As New EmployeeIDMonitorCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EMPLOYEE ID MONITOR " & IIf(TxtDepartmentName.Text = "" Or TxtDepartmentName.Text = "*All", "", " FOR DEPARTMENT: " & TxtDepartmentName.Text.ToUpper)
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EMPLOYEE ID MONITOR " & IIf(TxtDepartmentName.Text = "" Or TxtDepartmentName.Text = "*All", "", " FOR DEPARTMENT: " & TxtDepartmentName.Text.ToUpper)
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

    Private Sub BTNSENDEMAIL_Click(sender As System.Object, e As System.EventArgs) Handles btnEmailSettings.Click
        Dim frm As New EmployeeEMailSettings
        frm.ShowDialog()
    End Sub

    Private Sub BTNSENDEMAIL_Click_1(sender As System.Object, e As System.EventArgs) Handles BTNSENDEMAIL.Click
        Dim frm As New SendemailToEmployees
        frm.ShowDialog()
    End Sub
End Class