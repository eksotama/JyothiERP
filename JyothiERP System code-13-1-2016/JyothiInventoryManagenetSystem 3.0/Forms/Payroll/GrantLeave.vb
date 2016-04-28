Imports System.Windows.Forms

Public Class GrantLeave
    Dim IsAlterMode As Boolean = False
    Dim OpenedTranscode As Double = 0
    Sub LoadDefs()
        LoadDataIntoComboBox("select EmpName from Employees where isactive=1 and isdelete=0 ", TxtEmployeeName, "EmpName")
        LoadDataIntoComboBox("select leavename from leaves ", TxtLeaveType, "leavename")
        TxtStartDate.Value = Today.Date
        TxtEndDate.Value = Today.Date
        TxtLeaveDays.Text = "1"
        TxtForYear.Items.Add(Today.Date.Year)
        TxtForYear.Items.Add(Today.Date.Year + 1)

        TxtRemDays.Text = "0"
        TxtLeaveDays.Text = "0"
        TxtNarration.Text = ""
    End Sub

    Private Sub GrantLeave_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtEmployeeName.Focus()
    End Sub
   

    Private Sub GrantLeave_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDefs()
        TxtLeaveDays.Text = "1"
    End Sub

    Private Sub TxtEmployeeName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEmployeeName.SelectedIndexChanged
        TxtDepartment.Text = ""
        If TxtEmployeeName.Text.Length = 0 Then Exit Sub
        TxtDepartment.Text = SQLGetStringFieldValue("select DepName from employees where EmpName=N'" & TxtEmployeeName.Text & "'", "depname")

    End Sub

    Private Sub TxtLeaveType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLeaveType.SelectedIndexChanged
        TxtRemDays.Text = "0"

        If TxtEmployeeName.Text.Length = 0 Then
            MsgBox("Please Select the Employee Name .....     ", MsgBoxStyle.Information)
            TxtEmployeeName.Focus()
            Exit Sub
        End If
        If TxtLeaveType.Text.Length = 0 Then
            MsgBox("Please select the Leave type .....        ", MsgBoxStyle.Information)
            TxtLeaveType.Focus()
            Exit Sub
        End If
        If TxtForYear.Text.Length = 0 Then
            MsgBox("Please select the Year .....         ", MsgBoxStyle.Information)
            TxtForYear.Focus()
            Exit Sub
        End If
        Dim rdays As Integer = 0
        Dim useddays As Integer = 0
        rdays = SQLGetNumericFieldValue("select maxno from leaves where leavename=N'" & TxtLeaveType.Text & "'", "maxno")
        useddays = SQLGetNumericFieldValue("select sum(LeaveDays) as tot from empleaves where EmpName=N'" & TxtEmployeeName.Text & "' and LeaveName=N'" & TxtLeaveType.Text & "' and foryear=" & TxtForYear.Text, "tot")
        TxtRemDays.Text = rdays - useddays


        ' and foryear=" & TxtForYear.Text


    End Sub

    Private Sub TxtStartDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStartDate.ValueChanged, TxtEndDate.ValueChanged
        TxtLeaveDays.Text = DateDiff(DateInterval.Day, TxtStartDate.Value.Date, TxtEndDate.Value.Date) + 1
    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtEmployeeName.Text.Length = 0 Then
            MsgBox("Please select the Employee name ...", MsgBoxStyle.Information)
            TxtEmployeeName.Focus()
            Exit Sub
        End If
        If TxtForYear.Text.Length = 0 Then
            MsgBox("Please Select the Year... ", MsgBoxStyle.Information)
            TxtForYear.Focus()
            Exit Sub
        End If
        If TxtLeaveType.Text.Length = 0 Then
            MsgBox("Please select the Type of Leave ..... ", MsgBoxStyle.Information)
            TxtLeaveType.Focus()
            Exit Sub
        End If
        If SQLIsFieldExists("SELECT TOP 1 1 from   empleaves where empname=N'" & TxtEmployeeName.Text & "' and ( fromdatevalue>=" & TxtStartDate.Value.Date.ToOADate & " and " & TxtStartDate.Value.Date.ToOADate & "<=todatevalue )") = True Then
            MsgBox("The Leave is already granted for the selected date values....", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If SQLIsFieldExists("SELECT TOP 1 1 from   empleaves where empname=N'" & TxtEmployeeName.Text & "' and ( fromdatevalue>=" & TxtEndDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & "<=todatevalue )") = True Then
            MsgBox("The Leave is already granted for the selected date values....", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If SQLIsFieldExists("SELECT TOP 1 1 from   empleaves where empname=N'" & TxtEmployeeName.Text & "' and ( fromdatevalue>=" & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ">=todatevalue )") = True Then
            MsgBox("The Leave is already granted for the selected date values....", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim rdays As Integer = 0
        Dim useddays As Integer = 0
        rdays = SQLGetNumericFieldValue("select maxno from leaves where leavename=N'" & TxtLeaveType.Text & "'", "maxno")
        useddays = SQLGetNumericFieldValue("select sum(LeaveDays) as tot from empleaves where EmpName=N'" & TxtEmployeeName.Text & "' and LeaveName=N'" & TxtLeaveType.Text & "' and foryear=" & TxtForYear.Text, "tot")
        TxtRemDays.Text = rdays - useddays
        If CDbl(TxtLeaveDays.Text) <= 0 Then
            MsgBox("Please Select the Valid date range .. .", MsgBoxStyle.Information)
            TxtEndDate.Focus()
            Exit Sub
        End If

        If CDbl(TxtRemDays.Text) < CDbl(TxtLeaveDays.Text) Then
            MsgBox("The Leaves are not avialable......Maximum leaves exceeds ", MsgBoxStyle.Information)
            TxtEndDate.Focus()
            Exit Sub
        End If

        If MsgBox("Do you want to grant the Leave ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If IMSBEGINTRANSACTION() = False Then
                IMSENDTRANSACTION()
                '  MsgBox("The server is too busy or ERP Server may be shutdown, Please Run the ERP Server .....Please Try again")
                Exit Sub
            End If
            OpenedTranscode = GetAndSetIDCode(EnumIDType.TransCode)
            Dim SqlStr As String = ""
            SqlStr = "INSERT INTO [EmpLeaves] ([EmpName],[LeaveDays],[FromDate],[FromDateValue],[ToDate],[ToDateValue],[Narration],[LeaveName],[TransDate],[TransDateValue],[UserName],[ForYear],[n1],[TransCode],[leavecode])  " _
                & "VALUES (@EmpName,@LeaveDays,@FromDate,@FromDateValue,@ToDate,@ToDateValue,@Narration,@LeaveName,@TransDate,@TransDateValue,@UserName,@ForYear,@n1,@TransCode,@leavecode) "
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()

            Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBF.Parameters
                .AddWithValue("EmpName", TxtEmployeeName.Text)
                .AddWithValue("LeaveDays", TxtLeaveDays.Text)
                .AddWithValue("FromDate", TxtStartDate.Value.Date)
                .AddWithValue("FromDateValue", TxtStartDate.Value.Date.ToOADate)
                .AddWithValue("ToDate", TxtEndDate.Value.Date)
                .AddWithValue("ToDateValue", TxtEndDate.Value.Date.ToOADate)
                .AddWithValue("Narration", TxtNarration.Text)
                .AddWithValue("LeaveName", TxtLeaveType.Text)
                .AddWithValue("TransDate", Today.Date)
                .AddWithValue("TransDateValue", Today.Date.ToOADate)
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("ForYear", TxtForYear.Text)
                .AddWithValue("n1", 0)
                .AddWithValue("TransCode", OpenedTranscode)
                .AddWithValue("leavecode", SQLGetStringFieldValue("select leavecode from leaves where leavename=N'" & TxtLeaveType.Text & "'", "Leavecode"))
            End With

            DBF.ExecuteNonQuery()
            MAINCON.Close()
            IMSENDTRANSACTION()
            Me.Close()
        End If

    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
End Class
