Public Class EmployeeAttendenceSheet
    Dim Isonloading As Boolean = True

    Private Sub EmployeeAttendenceSheet_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub Attendence_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("SELECT  DepName FROM DepartmentGroups", TxtDepartmentName, "DepName", "*All")

        TxtpresentDate.MinDate = CompDetails.AccDateFrom
        TxtpresentDate.MaxDate = CompDetails.AccDateTo
        TxtpresentDate.Value = Today

    End Sub

    'Private Sub TxtList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles TxtList.CellFormatting
    '    On Error Resume Next
    '    TxtList.SuspendLayout()
    '    If TxtList.Item(e.ColumnIndex, e.RowIndex).Value = "A" Or TxtList.Item(e.ColumnIndex, e.RowIndex).Value = "P" Then
    '    Else
    '        If e.ColumnIndex = 0 Or e.ColumnIndex = TxtList.ColumnCount - 1 Or e.ColumnIndex = TxtList.ColumnCount - 2 Or e.ColumnIndex = TxtList.ColumnCount - 3 Then
    '        Else
    '            TxtList.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.Crimson
    '        End If

    '    End If
    '    TxtList.ResumeLayout()
    'End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Private Sub TxtpresentDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtpresentDate.ValueChanged

        LoadData()
    End Sub
    Sub LoadData()
        MainForm.Cursor = Cursors.WaitCursor
        Dim tdp As New DateTimePicker
        Dim Sqlstr As String = ""
        Dim DATESTR As String = ""
        Sqlstr = ""
        tdp.Value = New Date(TxtpresentDate.Value.Year, TxtpresentDate.Value.Month, 1)
        For i As Integer = 0 To Date.DaysInMonth(TxtpresentDate.Value.Date.Year, TxtpresentDate.Value.Date.Month) - 1
            DATESTR = tdp.Value.Year & "-" & tdp.Value.Month & "-" & tdp.Value.Day

            Sqlstr = Sqlstr & ", (CASE WHEN (SELECT TOP (1) Status FROM EmpAttend AS T WHERE (T.TransDate = '" & DATESTR & "') AND (T.EmpName = EMPATTEND.EMPNAME)) IS NOT NULL THEN 'P' " _
                & " WHEN (SELECT TOP (1) LeaveName FROM CompanyLeaves WHERE (" & tdp.Value.Date.ToOADate & " BETWEEN FromDateValue AND ToDateValue)) IS NOT NULL THEN 'HD' " _
                & " WHEN (SELECT LeaveCode FROM empleaves WHERE empname = EMPATTEND.EMPNAME AND (fromdatevalue <= " & tdp.Value.Date.ToOADate & " AND " & tdp.Value.Date.ToOADate & " <= todatevalue)) IS NOT NULL " _
                & " THEN (SELECT LeaveCode FROM empleaves WHERE empname = EMPATTEND.EMPNAME AND (fromdatevalue <= " & tdp.Value.Date.ToOADate & " AND " & tdp.Value.Date.ToOADate & " <= todatevalue)) ELSE 'A' END) AS [" & tdp.Value.Date.ToString("dd") & "- " & tdp.Value.Date.ToString("ddd") & "]"

            tdp.Value = tdp.Value.AddDays(1)
        Next

        Sqlstr = "  SELECT EMPNAME " & Sqlstr & ", 0 as [Total Leaves], 0 as [Total Presents], 0 as [Total Absense] FROM   EmpAttend  "

        If TxtIsShowAll.Checked = True Then
            If TxtDepartmentName.Text.Length = 0 Or TxtDepartmentName.Text = "*All" Then

            Else
                Sqlstr = Sqlstr & " where ( empname in (Select empname from employees where depname=N'" & TxtDepartmentName.Text & "') )"
            End If

        Else
            If TxtDepartmentName.Text.Length = 0 Or TxtDepartmentName.Text = "*All" Then
                Sqlstr = Sqlstr & " where empname in ( select distinct empname from Duties  where  (DutyType in (SELECT shiftname FROM dutysettings WHERE issingleshift='True')) ) "
            Else
                Sqlstr = Sqlstr & " where (empname in ( select distinct empname from Duties  where  (DutyType in (SELECT shiftname FROM dutysettings WHERE issingleshift='True')))) and ( empname in (Select empname from employees where depname=N'" & TxtDepartmentName.Text & "') ) "
            End If
        End If
       

        Sqlstr = Sqlstr & " GROUP BY EMPNAME  ORDER BY EMPNAME "
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns(0).Width = 120
            For I As Integer = 1 To TxtList.ColumnCount - 4
                TxtList.Columns(I).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                TxtList.Columns(I).Width = 35
            Next
            TxtList.Columns(TxtList.ColumnCount - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns(TxtList.ColumnCount - 1).Width = 80

            TxtList.Columns(TxtList.ColumnCount - 3).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns(TxtList.ColumnCount - 3).Width = 80

            TxtList.Columns(TxtList.ColumnCount - 2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns(TxtList.ColumnCount - 2).Width = 80


        Catch ex As Exception

        End Try
        For i As Integer = 0 To TxtList.RowCount - 1
            Dim totabsent As Double = 0
            Dim totholidays As Double = 0
            Dim totpresents As Double = 0
            For j As Integer = 1 To TxtList.ColumnCount - 4
                If TxtList.Item(j, i).Value = "P" Then
                    totpresents = totpresents + 1
                ElseIf TxtList.Item(j, i).Value = "A" Then
                    totabsent = totabsent + 1
                Else
                    totholidays = totholidays + 1
                End If

            Next
            '[Total Leaves], 0 as [Total Presents], 0 as [Total Absense]
            TxtList.Item("Total Leaves", i).Value = totholidays
            TxtList.Item("Total Presents", i).Value = totpresents
            TxtList.Item("Total Absense", i).Value = totabsent
        Next

        MainForm.Cursor = Cursors.Default
    End Sub
    Private Sub TxtDepartmentName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDepartmentName.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnLeaves_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLeaves.Click, GrantToolStripMenuItem1.Click
        Dim k As New GrantLeave
        k.ShowDialog()
        LoadData()
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click, PrintToolStripMenuItem.Click

    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click, ReloadToolStripMenuItem.Click
        LoadData()
    End Sub

    Private Sub TxtIsShowAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles TxtIsShowAll.CheckedChanged
        LoadData()
    End Sub
End Class