Public Class AppointmentsDashBoard
    Dim IsDoubleShift As Boolean = False
    Private Sub AppointmentsDashBoard_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        CalanderControl1.IsVerticalLayout = False
        CalanderControl1.ListAsEmployeeNamesForColuns = False
        LoadDataIntoComboBox("select ShiftName from DutySettings ", TxtShiftName, "ShiftName")
        If TxtShiftName.Items.Count > 0 Then
               TxtShiftName.SelectedIndex = 0
        End If
    End Sub

    
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        'Dim st As New DateTimePicker
        'Dim ed As New DateTimePicker
        'st.Value = New DateTime(ImsDate1.Value.Year, ImsDate1.Value.Month, ImsDate1.Value.Day, ImsDate2.Value.Hour, ImsDate2.Value.Minute, 0)
        'ed.Value = New DateTime(ImsDate1.Value.Year, ImsDate1.Value.Month, ImsDate1.Value.Day, ImsDate3.Value.Hour, ImsDate3.Value.Minute, 0)
        'CalanderControl1.CalanderMain1.NewAppointment(1, "nothing", st, ed, "", Color.AliceBlue, Color.Aquamarine, Drawing2D.HatchStyle.BackwardDiagonal, False, ImsColorBox1.Text)
    End Sub

    Private Sub ImsDate1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtDashBoardDate.ValueChanged
       SetDefValuesforCalander
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        CalanderControl1.CalanderTopBar1.IsAllowToShowEmployeeImages = CheckBox1.Checked

        CalanderControl1.IsShowEmployeeImages = CheckBox1.Checked
    End Sub
    Sub loaddata()
        CalanderControl1.ClearAllAppointMent()
        Dim OFFDUTYTIMESTART As New DateTimePicker
        Dim OFFDUTYTIMEEND As New DateTimePicker

        If SQLIsFieldExists("SELECT ShiftName FROM Dutysettings WHERE ShiftName=N'" & TxtShiftName.Text & "' AND issingleshift=1") = True Then
            CalanderControl1.CalStartTimeForRows = SQLGetDateTimeFieldValue("select Timein from DutySettings where ShiftName=N'" & TxtShiftName.Text & "'", "timein").Value
            CalanderControl1.CalEndTimeForRows = SQLGetDateTimeFieldValue("select timeout from DutySettings where ShiftName=N'" & TxtShiftName.Text & "'", "timeout").Value
            IsDoubleShift = False
        Else
            CalanderControl1.CalStartTimeForRows = SQLGetDateTimeFieldValue("select Timein from DutySettings where ShiftName=N'" & TxtShiftName.Text & "'", "timein").Value
            CalanderControl1.CalEndTimeForRows = SQLGetDateTimeFieldValue("select ETimeOut from DutySettings where ShiftName=N'" & TxtShiftName.Text & "'", "ETimeOut").Value
            IsDoubleShift = True
            OFFDUTYTIMESTART.Value = SQLGetDateTimeFieldValue("select timeout from DutySettings where ShiftName=N'" & TxtShiftName.Text & "'", "timeout").Value
            OFFDUTYTIMEEND.Value = SQLGetDateTimeFieldValue("select ETimein from DutySettings where ShiftName=N'" & TxtShiftName.Text & "'", "Etimein").Value
            OFFDUTYTIMESTART.Value = New DateTime(TxtDashBoardDate.Value.Year, TxtDashBoardDate.Value.Month, TxtDashBoardDate.Value.Day, OFFDUTYTIMESTART.Value.Hour, OFFDUTYTIMESTART.Value.Minute, 0)
            OFFDUTYTIMEEND.Value = New DateTime(TxtDashBoardDate.Value.Year, TxtDashBoardDate.Value.Month, TxtDashBoardDate.Value.Day, OFFDUTYTIMEEND.Value.Hour, OFFDUTYTIMEEND.Value.Minute, 0)


        End If

        'FIND THE BREAKTIMES FOR THIS SELECTED DAY FOR EACH EMPLOYEE
        For I As Integer = 0 To CalanderControl1.CalanderMain1.EmployeeList.Items.Count - 1
            Dim SqlConn As New SqlClient.SqlConnection
            Dim Sqlcmmd As New SqlClient.SqlCommand

            Try
                SqlConn.ConnectionString = ConnectionStrinG
                SqlConn.Open()
                Sqlcmmd.Connection = SqlConn
                Sqlcmmd.CommandText = "SELECT * FROM Duties WHERE empname=N'" & CalanderControl1.CalanderMain1.EmployeeList.Items(I).ToString & "' AND (" & TxtDashBoardDate.Value.Date.ToOADate & " between datefromvalue and datetovalue)"
                Sqlcmmd.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = Sqlcmmd.ExecuteReader
                While Sreader.Read()
                    Dim dt1 As New DateTimePicker
                    Dim dt2 As New DateTimePicker
                    Dim totmin As Long = 0
                    'MEAL BREAK
                    dt1.Value = Sreader("MealTime")
                    dt2.Value = Sreader("MealDuration")
                    dt1.Value = New DateTime(TxtDashBoardDate.Value.Year, TxtDashBoardDate.Value.Month, TxtDashBoardDate.Value.Day, dt1.Value.Hour, dt1.Value.Minute, 0)
                    dt2.Value = New DateTime(TxtDashBoardDate.Value.Year, TxtDashBoardDate.Value.Month, TxtDashBoardDate.Value.Day, dt2.Value.Hour, dt2.Value.Minute, 0)

                    totmin = DateDiff(DateInterval.Minute, dt1.Value, dt2.Value)
                    If totmin > 0 Then
                        'add break
                        Dim c As New Color
                        c = Color.FromArgb(Sreader("MealTimeColorR"), Sreader("MealTimeColorG"), Sreader("MealTimeColorB"))
                        CalanderControl1.CalanderMain1.NewAppointment(-1, Sreader("MealTimeText"), dt1, dt2, "", c, Color.Empty, Drawing2D.HatchStyle.Divot, True, "", CalanderControl1.CalanderMain1.EmployeeList.Items(I).ToString, True)
                    End If

                    'TEA BREAK1
                    dt1.Value = Sreader("breaktime1")
                    dt2.Value = Sreader("breakDuration1")
                    dt1.Value = New DateTime(TxtDashBoardDate.Value.Year, TxtDashBoardDate.Value.Month, TxtDashBoardDate.Value.Day, dt1.Value.Hour, dt1.Value.Minute, 0)
                    dt2.Value = New DateTime(TxtDashBoardDate.Value.Year, TxtDashBoardDate.Value.Month, TxtDashBoardDate.Value.Day, dt2.Value.Hour, dt2.Value.Minute, 0)

                    totmin = DateDiff(DateInterval.Minute, dt1.Value, dt2.Value)
                    If totmin > 0 Then
                        'add break
                        Dim c As New Color
                        c = Color.FromArgb(Sreader("Break1Colorr"), Sreader("Break1ColorG"), Sreader("Break1ColorB"))
                        CalanderControl1.CalanderMain1.NewAppointment(-1, Sreader("Break1Text"), dt1, dt2, "", c, Color.Empty, Drawing2D.HatchStyle.Divot, True, "", CalanderControl1.CalanderMain1.EmployeeList.Items(I).ToString, True)

                    End If

                    'TEA BREAK2
                    dt1.Value = Sreader("BreakTime2")
                    dt2.Value = Sreader("BreakDuration2")
                    dt1.Value = New DateTime(TxtDashBoardDate.Value.Year, TxtDashBoardDate.Value.Month, TxtDashBoardDate.Value.Day, dt1.Value.Hour, dt1.Value.Minute, 0)
                    dt2.Value = New DateTime(TxtDashBoardDate.Value.Year, TxtDashBoardDate.Value.Month, TxtDashBoardDate.Value.Day, dt2.Value.Hour, dt2.Value.Minute, 0)

                    totmin = DateDiff(DateInterval.Minute, dt1.Value, dt2.Value)
                    If totmin > 0 Then
                        'add break

                        Dim c As New Color
                        c = Color.FromArgb(Sreader("Break2ColorR"), Sreader("Break2ColorG"), Sreader("Break2ColorB"))
                        CalanderControl1.CalanderMain1.NewAppointment(-1, Sreader("Break2Text"), dt1, dt2, "", c, Color.Empty, Drawing2D.HatchStyle.Divot, True, "", CalanderControl1.CalanderMain1.EmployeeList.Items(I).ToString, True)
                    End If
                    If IsDoubleShift = True Then
                        CalanderControl1.CalanderMain1.NewAppointment(-1, "OFF DUTY", OFFDUTYTIMESTART, OFFDUTYTIMEEND, "", Color.IndianRed, Color.Empty, Drawing2D.HatchStyle.Divot, True, "", CalanderControl1.CalanderMain1.EmployeeList.Items(I).ToString, True)
                    End If
                End While
                Sreader.Close()
                Sreader = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SqlConn.Close()
                SqlConn.Dispose()
                Sqlcmmd.Connection = Nothing
            End Try
        Next

        Dim SqlConn2 As New SqlClient.SqlConnection
        Dim Sqlcmmd2 As New SqlClient.SqlCommand

        Try
            SqlConn2.ConnectionString = ConnectionStrinG
            SqlConn2.Open()
            Sqlcmmd2.Connection = SqlConn2
            Sqlcmmd2.CommandText = "SELECT * FROM Appointmentdb WHERE dateValue=" & TxtDashBoardDate.Value.Date.ToOADate
            Sqlcmmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd2.ExecuteReader
            While Sreader.Read()
                Dim dt1 As New DateTimePicker
                Dim dt2 As New DateTimePicker
                Dim c As New Color
                Dim patc As New Color
                c = Color.FromArgb(Sreader("ColorR"), Sreader("ColorG"), Sreader("ColorB"))
                If Sreader("PatterColorR") = 0 And Sreader("PatterColorg") = 0 And Sreader("PatterColorb") = 0 Then
                    patc = Color.Empty
                Else
                    patc = Color.FromArgb(Sreader("PatterColorR"), Sreader("PatterColorG"), Sreader("PatterColorB"))
                End If

                dt1.Value = Sreader("DateStart")
                dt2.Value = Sreader("DateEnd")
                CalanderControl1.CalanderMain1.NewAppointment(Sreader("AppID"), Sreader("Note"), dt1, dt2, "", c, patc, Sreader("PatterStyle"), False, GetServiceLists(Sreader("appid")), Sreader("EmpName"), Sreader("IsOrderConfirm"))
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn2.Close()
            SqlConn2.Dispose()
            Sqlcmmd2.Connection = Nothing
        End Try

    End Sub

    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click
        Me.Close()
    End Sub

    Private Sub ImsButton3_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton3.Click
        If TxtShiftName.Text.Length = 0 Then
            MsgBox("please Select the Shift Name ", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim stdt As New DateTimePicker
        Dim eddt As New DateTimePicker
        Dim tempd As New DateTime
        tempd = CalanderControl1.CalStartTimeForRows
        stdt.Value = New DateTime(tempd.Year, tempd.Month, tempd.Day, tempd.Hour, tempd.Minute, tempd.Second)
        tempd = CalanderControl1.CalEndTimeForRows
        eddt.Value = New DateTime(tempd.Year, tempd.Month, tempd.Day, tempd.Hour, tempd.Minute, tempd.Second)
        Dim frm As New NewAppointment(stdt, eddt, IsDoubleShift)
        frm.ShowDialog()
        loaddata()
    End Sub

    Private Sub TxtShiftName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtShiftName.SelectedIndexChanged
        SetDefValuesforCalander()
    End Sub

    Sub SetDefValuesforCalander()
        LoadDataIntoComboBox("SELECT DISTINCT EmpName FROM Duties where DutyType=N'" & TxtShiftName.Text & "'", CalanderControl1.CalanderTopBar1.EmployeeList, "EmpName")
        LoadDataIntoComboBox("SELECT DISTINCT EmpName FROM Duties where DutyType=N'" & TxtShiftName.Text & "'", CalanderControl1.CalanderMain1.EmployeeList, "EmpName")
        LoadDataIntoComboBox("SELECT DISTINCT EmpName FROM Duties where DutyType=N'" & TxtShiftName.Text & "'", CalanderControl1.CalanderLeftBar1.EmployeeList, "EmpName")
        If SQLIsFieldExists("SELECT ShiftName FROM Dutysettings WHERE ShiftName=N'" & TxtShiftName.Text & "' AND issingleshift=1") = True Then
            CalanderControl1.CalStartTimeForRows = SQLGetDateTimeFieldValue("select Timein from DutySettings where ShiftName=N'" & TxtShiftName.Text & "'", "timein").Value
            CalanderControl1.CalEndTimeForRows = SQLGetDateTimeFieldValue("select timeout from DutySettings where ShiftName=N'" & TxtShiftName.Text & "'", "timeout").Value
        Else
            CalanderControl1.CalStartTimeForRows = SQLGetDateTimeFieldValue("select Timein from DutySettings where ShiftName=N'" & TxtShiftName.Text & "'", "timein").Value
            CalanderControl1.CalEndTimeForRows = SQLGetDateTimeFieldValue("select ETimeOut from DutySettings where ShiftName=N'" & TxtShiftName.Text & "'", "ETimeOut").Value
        End If
        
        CalanderControl1.CalanderMain1.ShowOnlyStartEndTimeScale = True
        CalanderControl1.CalanderMain1.CalStartDate = TxtDashBoardDate.Value.Date
        CalanderControl1.CalanderMain1.CalEndDate = TxtDashBoardDate.Value.Date
        CalanderControl1.CalanderTopBar1.ListAsEmployeeNamesForColuns = True
        CalanderControl1.CalanderMain1.ListAsEmployeeNamesForColuns = True
        CalanderControl1.IsShowEmployeeImages = True
        CalanderControl1.CalanderTopBar1.IsAllowToShowEmployeeImages = CheckBox1.Checked
        CalanderControl1.IsShowEmployeeImages = CheckBox1.Checked


        loaddata()
    End Sub
    

   
    Private Sub ImsButton2_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton4.Click
        MainForm.Cursor = Cursors.WaitCursor
        SERVICEREPORT.SuspendLayout()
        SERVICEREPORT.MdiParent = MainForm
        SERVICEREPORT.Dock = DockStyle.Fill
        SERVICEREPORT.Show()
        SERVICEREPORT.WindowState = FormWindowState.Maximized
        SERVICEREPORT.BringToFront()
        SERVICEREPORT.ResumeLayout()
        MainForm.Cursor = Cursors.Default
    End Sub

    Private Sub ImsButton2_Click_1(sender As System.Object, e As System.EventArgs) Handles ImsButton2.Click
        MainForm.Cursor = Cursors.WaitCursor
        dailyservicereportfrm.SuspendLayout()
        dailyservicereportfrm.MdiParent = MainForm
        dailyservicereportfrm.Dock = DockStyle.Fill
        dailyservicereportfrm.Show()
        dailyservicereportfrm.WindowState = FormWindowState.Maximized
        dailyservicereportfrm.BringToFront()
        dailyservicereportfrm.ResumeLayout()
        MainForm.Cursor = Cursors.Default
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            CheckBox1.Checked = False
            CheckBox1.Enabled = False
        Else

            CheckBox1.Enabled = True
        End If
        CalanderControl1.IsVerticalLayout = CheckBox2.Checked
        SetDefValuesforCalander()
    End Sub
End Class