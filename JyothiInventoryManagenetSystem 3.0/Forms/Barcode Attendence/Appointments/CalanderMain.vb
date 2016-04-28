Public Class CalanderMain
    Public Enum TimeScale
        FiveMin = 12
        SixMin = 10
        TenMin = 6
        FifteenMin = 4
        TwentyMin = 3
        ThiryMin = 2
        Onehour = 1
        OneMin = 60
        twomin = 30
    End Enum
    Public ViewStart As Integer = 1
    Private TimeUnitValuePerRow As Double = 0
    Public ViewEnd As Integer = 2
    Private CalanderStartDate As DateTime = New DateTime(2014, 11, 1)
    Private CalanderEndDate As DateTime = New DateTime(2014, 12, 24)
    Private CalanderColumnWidth As Integer = 300
    Private StartTime As DateTime = New DateTime(2014, 12, 12, 9, 0, 0)
    Private EndTime As DateTime = New DateTime(2014, 12, 12, 20, 0, 0)
    Public IsDisplySunday As Boolean = False
    Public IsDisplySaturday As Boolean = False
    Public ShowOnlyStartEndTimeScale As Boolean = True
    Private LeftGap As Integer = 0
    Private TopGap As Integer = 0
    Public DaysList As New ListBox
    Private FormatDateString As String = "dddd, dd MMMM yyyy"
    Public EmployeeList As New ComboBox
    Public ListAsEmployeeNamesForColuns As Boolean = False
    Private TimeUnits As Integer = 10
    Private TimeScaleRowHeight As Integer = 30
    Public VerticalEmpDisply As Boolean = True
    Private SelectRectX1 As Integer = 0
    Private SelectRectX2 As Integer = 0
    Private SelectRectY1 As Integer = 0
    Private SelectRectY2 As Integer = 0
    Public Property setDateFormatString() As String
        Get
            Return FormatDateString
        End Get
        Set(value As String)
            FormatDateString = value
            LoadDays()
            Me.Invalidate()
        End Set
    End Property
   
    Public Property SetCaladerColumwidht() As Integer
        Get
            Return CalanderColumnWidth
        End Get
        Set(value As Integer)
            CalanderColumnWidth = value
            Me.Invalidate()
        End Set
    End Property
    Sub RearrangeBox(ct As CalanderBox)
        If ListAsEmployeeNamesForColuns = True Then
            If EmployeeList.Items.IndexOf(ct.EmployeeID) < 0 Then
                Me.Controls(ct.Name).Dispose()
                Exit Sub
            End If
        Else
            If DaysList.Items.IndexOf(ct.StartTime.Value.Date.ToString(FormatDateString)) < 0 Then
                Me.Controls(ct.Name).Dispose()
                Exit Sub
            End If
        End If
        If VerticalEmpDisply = True Then
            If ct.StartTime.Value.Date >= CalanderStartDate And ct.EndTime.Value.Date <= CalanderEndDate Then
                Dim colno As Integer = 0
                If ListAsEmployeeNamesForColuns = True Then
                    colno = EmployeeList.Items.IndexOf(ct.EmployeeID)
                Else
                    colno = DaysList.Items.IndexOf(ct.StartTime.Value.Date.ToString(FormatDateString))
                End If

                Dim MinVal As Double = 0
                If TimeUnits = 1 Then
                    MinVal = TimeScaleRowHeight / 60
                    TimeUnitValuePerRow = 60
                ElseIf TimeUnits = 2 Then
                    MinVal = TimeScaleRowHeight / 30
                    TimeUnitValuePerRow = 30
                ElseIf TimeUnits = 4 Then
                    MinVal = TimeScaleRowHeight / 15
                    TimeUnitValuePerRow = 15
                ElseIf TimeUnits = 10 Then
                    MinVal = TimeScaleRowHeight / 6
                    TimeUnitValuePerRow = 6
                ElseIf TimeUnits = 12 Then
                    MinVal = TimeScaleRowHeight / 5
                    TimeUnitValuePerRow = 5
                ElseIf TimeUnits = 30 Then
                    MinVal = TimeScaleRowHeight / 2
                    TimeUnitValuePerRow = 2
                ElseIf TimeUnits = 6 Then
                    MinVal = TimeScaleRowHeight / 10
                    TimeUnitValuePerRow = 10
                ElseIf TimeUnits = 3 Then
                    MinVal = TimeScaleRowHeight / 20
                    TimeUnitValuePerRow = 20
                ElseIf TimeUnits = 20 Then
                    MinVal = TimeScaleRowHeight / 3
                    TimeUnitValuePerRow = 3
                ElseIf TimeUnits = 60 Then
                    MinVal = TimeScaleRowHeight / 1
                    TimeUnitValuePerRow = 1
                End If

                Dim NewYpos As Integer = 0
                Dim totalmin As Integer = 0
                Dim totalendmin As Integer = 0
                If ShowOnlyStartEndTimeScale = False Then
                    Dim t As New DateTimePicker
                    t.Value = New DateTime(2014, 1, 1, 0, 0, 0, 0)
                    totalmin = DateDiff(DateInterval.Minute, t.Value.Date, ct.StartTime.Value.Date)
                Else
                    Dim t1 As DateTime = New DateTime(ct.StartTime.Value.Year, ct.StartTime.Value.Month, ct.StartTime.Value.Day, StartTime.Hour, StartTime.Minute, 0)
                    Dim t2 As DateTime = New DateTime(ct.StartTime.Value.Year, ct.StartTime.Value.Month, ct.StartTime.Value.Day, ct.StartTime.Value.Hour, ct.StartTime.Value.Minute, 0)
                    totalmin = DateDiff(DateInterval.Minute, t1, t2)
                    t1 = New DateTime(ct.StartTime.Value.Year, ct.StartTime.Value.Month, ct.StartTime.Value.Day, ct.StartTime.Value.Hour, ct.StartTime.Value.Minute, 0)
                    t2 = New DateTime(ct.EndTime.Value.Year, ct.EndTime.Value.Month, ct.EndTime.Value.Day, ct.EndTime.Value.Hour, ct.EndTime.Value.Minute, 0)
                    totalendmin = DateDiff(DateInterval.Minute, t1, t2)

                    'Dim t1 As DateTime = New DateTime(StartDate.Value.Year, StartDate.Value.Month, StartDate.Value.Day, StartTime.Hour, StartTime.Minute, 0)
                    'Dim t2 As DateTime = New DateTime(StartDate.Value.Year, StartDate.Value.Month, StartDate.Value.Day, StartDate.Value.Hour, StartDate.Value.Minute, 0)
                    'totalmin = DateDiff(DateInterval.Minute, t1, t2)
                    't1 = New DateTime(StartDate.Value.Year, StartDate.Value.Month, StartDate.Value.Day, StartDate.Value.Hour, StartDate.Value.Minute, 0)
                    't2 = New DateTime(Enddate.Value.Year, Enddate.Value.Month, Enddate.Value.Day, Enddate.Value.Hour, Enddate.Value.Minute, 0)
                    'totalendmin = DateDiff(DateInterval.Minute, t1, t2)
                End If

                ct.Location = New Point(totalmin * MinVal + 25, colno * 35)
                ct.Width = totalendmin * MinVal

            End If
        Else
            If ct.StartTime.Value.Date >= CalanderStartDate And ct.EndTime.Value.Date <= CalanderEndDate Then
                Dim colno As Integer = 0
                If ListAsEmployeeNamesForColuns = True Then
                    colno = EmployeeList.Items.IndexOf(ct.EmployeeID)
                Else
                    colno = DaysList.Items.IndexOf(ct.StartTime.Value.Date.ToString(FormatDateString))
                End If

                Dim MinVal As Double = 0
                If TimeUnits = 1 Then
                    MinVal = TimeScaleRowHeight / 60
                    TimeUnitValuePerRow = 60
                ElseIf TimeUnits = 2 Then
                    MinVal = TimeScaleRowHeight / 30
                    TimeUnitValuePerRow = 30
                ElseIf TimeUnits = 4 Then
                    MinVal = TimeScaleRowHeight / 15
                    TimeUnitValuePerRow = 15
                ElseIf TimeUnits = 10 Then
                    MinVal = TimeScaleRowHeight / 6
                    TimeUnitValuePerRow = 6
                ElseIf TimeUnits = 12 Then
                    MinVal = TimeScaleRowHeight / 5
                    TimeUnitValuePerRow = 5
                ElseIf TimeUnits = 30 Then
                    MinVal = TimeScaleRowHeight / 2
                    TimeUnitValuePerRow = 2
                ElseIf TimeUnits = 6 Then
                    MinVal = TimeScaleRowHeight / 10
                    TimeUnitValuePerRow = 10
                ElseIf TimeUnits = 3 Then
                    MinVal = TimeScaleRowHeight / 20
                    TimeUnitValuePerRow = 20
                ElseIf TimeUnits = 20 Then
                    MinVal = TimeScaleRowHeight / 3
                    TimeUnitValuePerRow = 3
                ElseIf TimeUnits = 60 Then
                    MinVal = TimeScaleRowHeight / 1
                    TimeUnitValuePerRow = 1
                End If

                Dim NewYpos As Integer = 0
                Dim totalmin As Integer = 0
                Dim totalendmin As Integer = 0
                If ShowOnlyStartEndTimeScale = False Then
                    Dim t As New DateTimePicker
                    t.Value = New DateTime(2014, 1, 1, 0, 0, 0, 0)
                    totalmin = DateDiff(DateInterval.Minute, t.Value.Date, ct.StartTime.Value.Date)
                Else
                    Dim t1 As DateTime = New DateTime(ct.StartTime.Value.Year, ct.StartTime.Value.Month, ct.StartTime.Value.Day, StartTime.Hour, StartTime.Minute, 0)
                    Dim t2 As DateTime = New DateTime(ct.StartTime.Value.Year, ct.StartTime.Value.Month, ct.StartTime.Value.Day, ct.StartTime.Value.Hour, ct.StartTime.Value.Minute, 0)
                    totalmin = DateDiff(DateInterval.Minute, t1, t2)
                    t1 = New DateTime(ct.StartTime.Value.Year, ct.StartTime.Value.Month, ct.StartTime.Value.Day, ct.StartTime.Value.Hour, ct.StartTime.Value.Minute, 0)
                    t2 = New DateTime(ct.EndTime.Value.Year, ct.EndTime.Value.Month, ct.EndTime.Value.Day, ct.EndTime.Value.Hour, ct.EndTime.Value.Minute, 0)
                    totalendmin = DateDiff(DateInterval.Minute, t1, t2)

                    'Dim t1 As DateTime = New DateTime(StartDate.Value.Year, StartDate.Value.Month, StartDate.Value.Day, StartTime.Hour, StartTime.Minute, 0)
                    'Dim t2 As DateTime = New DateTime(StartDate.Value.Year, StartDate.Value.Month, StartDate.Value.Day, StartDate.Value.Hour, StartDate.Value.Minute, 0)
                    'totalmin = DateDiff(DateInterval.Minute, t1, t2)
                    't1 = New DateTime(StartDate.Value.Year, StartDate.Value.Month, StartDate.Value.Day, StartDate.Value.Hour, StartDate.Value.Minute, 0)
                    't2 = New DateTime(Enddate.Value.Year, Enddate.Value.Month, Enddate.Value.Day, Enddate.Value.Hour, Enddate.Value.Minute, 0)
                    'totalendmin = DateDiff(DateInterval.Minute, t1, t2)
                End If

                ct.Location = New Point(colno * CalanderColumnWidth + 15, totalmin * MinVal)
                ct.Height = totalendmin * MinVal + 15

            End If
        End If
    End Sub
    Sub RearrangeCtrols()
        For i As Integer = 0 To Me.Controls.Count - 1
            RearrangeBox(CType(Me.Controls(i), CalanderBox))
        Next
    End Sub
  
    Public Sub NewAppointment(id As Long, TextVal As String, StartDate As DateTimePicker, Enddate As DateTimePicker, imagepath As String, colorname As Color, pattercolor As Color, patterstyle As System.Drawing.Drawing2D.HatchStyle, IsBrakTime As Boolean, ServiceList As String, EmplyeeName As String, IsLocked As Boolean)
        If ListAsEmployeeNamesForColuns = True Then
            If EmployeeList.Items.IndexOf(EmplyeeName) < 0 Then Exit Sub
        Else
            If DaysList.Items.IndexOf(StartDate.Value.Date.ToString(FormatDateString)) < 0 Then Exit Sub
        End If

        If VerticalEmpDisply = True Then
            If StartDate.Value.Date >= CalanderStartDate And Enddate.Value.Date <= CalanderEndDate Then
                Dim calappoint As New CalanderBox
                calappoint.ID = id
                calappoint.EmployeeID = EmplyeeName
                calappoint.Servicelist = ServiceList
                calappoint.Name = "APP" & Me.Controls.Count.ToString
                calappoint.BackColor = colorname
                calappoint.IsBreakTime = IsBrakTime
                calappoint.TextVal = TextVal
                calappoint.PatterColor = pattercolor
                calappoint.PatterStyle = patterstyle
                calappoint.IsLoked = IsLocked
                calappoint.DutyStartDate.Value = StartTime
                calappoint.DutyEndDate.Value = EndTime
                calappoint.CalanderStartDate.Value = CalStartTimeForRows
                calappoint.CalanderEnddate.Value = CalEndTimeForRows
                calappoint.CustName = SQLGetStringFieldValue("select LedgerName from Appointmentdb where AppID=" & id, "LedgerName")
                Try
                    calappoint.Imagepath = imagepath
                Catch ex As Exception

                End Try
                calappoint.StartTime.Value = StartDate.Value
                calappoint.EndTime.Value = Enddate.Value
                Dim colno As Integer = 0


                If ListAsEmployeeNamesForColuns = True Then
                    colno = EmployeeList.Items.IndexOf(EmplyeeName)
                Else
                    colno = DaysList.Items.IndexOf(StartDate.Value.Date.ToString(FormatDateString))
                End If
                Dim MinVal As Double = 0

                If TimeUnits = 1 Then
                    MinVal = TimeScaleRowHeight / 60
                    TimeUnitValuePerRow = 60
                ElseIf TimeUnits = 2 Then
                    MinVal = TimeScaleRowHeight / 30
                    TimeUnitValuePerRow = 30
                ElseIf TimeUnits = 4 Then
                    MinVal = TimeScaleRowHeight / 15
                    TimeUnitValuePerRow = 15
                ElseIf TimeUnits = 10 Then
                    MinVal = TimeScaleRowHeight / 6
                    TimeUnitValuePerRow = 6
                ElseIf TimeUnits = 12 Then
                    MinVal = TimeScaleRowHeight / 5
                    TimeUnitValuePerRow = 5
                ElseIf TimeUnits = 30 Then
                    MinVal = TimeScaleRowHeight / 2
                    TimeUnitValuePerRow = 2
                ElseIf TimeUnits = 6 Then
                    MinVal = TimeScaleRowHeight / 10
                    TimeUnitValuePerRow = 10
                ElseIf TimeUnits = 3 Then
                    MinVal = TimeScaleRowHeight / 20
                    TimeUnitValuePerRow = 20
                ElseIf TimeUnits = 20 Then
                    MinVal = TimeScaleRowHeight / 3
                    TimeUnitValuePerRow = 3
                ElseIf TimeUnits = 60 Then
                    MinVal = TimeScaleRowHeight / 1
                    TimeUnitValuePerRow = 1
                End If

                Dim NewYpos As Integer = 0
                Dim totalmin As Integer = 0
                Dim totalendmin As Integer = 0
                If ShowOnlyStartEndTimeScale = False Then
                    Dim t As New DateTimePicker
                    t.Value = New DateTime(2014, 1, 1, 0, 0, 0, 0)
                    totalmin = DateDiff(DateInterval.Minute, t.Value.Date, StartDate.Value.Date)
                Else
                    Dim t1 As DateTime = New DateTime(StartDate.Value.Year, StartDate.Value.Month, StartDate.Value.Day, StartTime.Hour, StartTime.Minute, 0)
                    Dim t2 As DateTime = New DateTime(StartDate.Value.Year, StartDate.Value.Month, StartDate.Value.Day, StartDate.Value.Hour, StartDate.Value.Minute, 0)
                    totalmin = DateDiff(DateInterval.Minute, t1, t2)
                    t1 = New DateTime(StartDate.Value.Year, StartDate.Value.Month, StartDate.Value.Day, StartDate.Value.Hour, StartDate.Value.Minute, 0)
                    t2 = New DateTime(Enddate.Value.Year, Enddate.Value.Month, Enddate.Value.Day, Enddate.Value.Hour, Enddate.Value.Minute, 0)
                    totalendmin = DateDiff(DateInterval.Minute, t1, t2)
                End If
                'calappoint.BackColor = Color.Red
                calappoint.Location = New Point(totalmin * MinVal + 25, colno * 100)
                calappoint.Width = totalmin * MinVal
                calappoint.Visible = True
                calappoint.Show()
                calappoint.Height = 35
                Me.Controls.Add(calappoint)
                AddHandler calappoint.SizeChangedby, AddressOf CtlSizeChanged
                AddHandler calappoint.CalanderBoxClick, AddressOf ClickAppointMent
                AddHandler calappoint.CalanderBoxDoubleClick, AddressOf DoubleClickAppointMent
                AddHandler calappoint.CalanderDeletePressed, AddressOf DeleteAppointMent
                RearrangeCtrols()
            End If
            'end of verical
        Else
            If StartDate.Value.Date >= CalanderStartDate And Enddate.Value.Date <= CalanderEndDate Then
                Dim calappoint As New CalanderBox
                calappoint.ID = id
                calappoint.EmployeeID = EmplyeeName
                calappoint.Servicelist = ServiceList
                calappoint.Name = "APP" & Me.Controls.Count.ToString
                calappoint.BackColor = colorname
                calappoint.IsBreakTime = IsBrakTime
                calappoint.TextVal = TextVal
                calappoint.PatterColor = pattercolor
                calappoint.PatterStyle = patterstyle
                calappoint.IsLoked = IsLocked
                calappoint.DutyStartDate.Value = StartTime
                calappoint.DutyEndDate.Value = EndTime
                calappoint.CalanderStartDate.Value = CalStartTimeForRows
                calappoint.CalanderEnddate.Value = CalEndTimeForRows
                calappoint.CustName = SQLGetStringFieldValue("select LedgerName from Appointmentdb where AppID=" & id, "LedgerName")
                Try
                    calappoint.Imagepath = imagepath
                Catch ex As Exception

                End Try
                calappoint.StartTime.Value = StartDate.Value
                calappoint.EndTime.Value = Enddate.Value
                Dim colno As Integer = 0


                If ListAsEmployeeNamesForColuns = True Then
                    colno = EmployeeList.Items.IndexOf(EmplyeeName)
                Else
                    colno = DaysList.Items.IndexOf(StartDate.Value.Date.ToString(FormatDateString))
                End If
                Dim MinVal As Double = 0

                If TimeUnits = 1 Then
                    MinVal = TimeScaleRowHeight / 60
                    TimeUnitValuePerRow = 60
                ElseIf TimeUnits = 2 Then
                    MinVal = TimeScaleRowHeight / 30
                    TimeUnitValuePerRow = 30
                ElseIf TimeUnits = 4 Then
                    MinVal = TimeScaleRowHeight / 15
                    TimeUnitValuePerRow = 15
                ElseIf TimeUnits = 10 Then
                    MinVal = TimeScaleRowHeight / 6
                    TimeUnitValuePerRow = 6
                ElseIf TimeUnits = 12 Then
                    MinVal = TimeScaleRowHeight / 5
                    TimeUnitValuePerRow = 5
                ElseIf TimeUnits = 30 Then
                    MinVal = TimeScaleRowHeight / 2
                    TimeUnitValuePerRow = 2
                ElseIf TimeUnits = 6 Then
                    MinVal = TimeScaleRowHeight / 10
                    TimeUnitValuePerRow = 10
                ElseIf TimeUnits = 3 Then
                    MinVal = TimeScaleRowHeight / 20
                    TimeUnitValuePerRow = 20
                ElseIf TimeUnits = 20 Then
                    MinVal = TimeScaleRowHeight / 3
                    TimeUnitValuePerRow = 3
                ElseIf TimeUnits = 60 Then
                    MinVal = TimeScaleRowHeight / 1
                    TimeUnitValuePerRow = 1
                End If

                Dim NewYpos As Integer = 0
                Dim totalmin As Integer = 0
                Dim totalendmin As Integer = 0
                If ShowOnlyStartEndTimeScale = False Then
                    Dim t As New DateTimePicker
                    t.Value = New DateTime(2014, 1, 1, 0, 0, 0, 0)
                    totalmin = DateDiff(DateInterval.Minute, t.Value.Date, StartDate.Value.Date)
                Else
                    Dim t1 As DateTime = New DateTime(StartDate.Value.Year, StartDate.Value.Month, StartDate.Value.Day, StartTime.Hour, StartTime.Minute, 0)
                    Dim t2 As DateTime = New DateTime(StartDate.Value.Year, StartDate.Value.Month, StartDate.Value.Day, StartDate.Value.Hour, StartDate.Value.Minute, 0)
                    totalmin = DateDiff(DateInterval.Minute, t1, t2)
                    t1 = New DateTime(StartDate.Value.Year, StartDate.Value.Month, StartDate.Value.Day, StartDate.Value.Hour, StartDate.Value.Minute, 0)
                    t2 = New DateTime(Enddate.Value.Year, Enddate.Value.Month, Enddate.Value.Day, Enddate.Value.Hour, Enddate.Value.Minute, 0)
                    totalendmin = DateDiff(DateInterval.Minute, t1, t2)
                End If
                'calappoint.BackColor = Color.Red
                calappoint.Location = New Point(colno * CalanderColumnWidth + 5, totalmin * MinVal)
                calappoint.Width = CalanderColumnWidth - 10
                calappoint.Visible = True
                calappoint.Show()
                calappoint.Height = totalendmin * MinVal
                Me.Controls.Add(calappoint)
                AddHandler calappoint.SizeChangedby, AddressOf CtlSizeChanged
                AddHandler calappoint.CalanderBoxClick, AddressOf ClickAppointMent
                AddHandler calappoint.CalanderBoxDoubleClick, AddressOf DoubleClickAppointMent
                AddHandler calappoint.CalanderDeletePressed, AddressOf DeleteAppointMent
            End If
        End If
    End Sub
    Sub CtlSizeChanged(sender As CalanderBox, NewValues As Integer)
        'If ShowOnlyStartEndTimeScale = False Then
        '    Dim min As Integer
        '    Dim hour As Integer
        '    hour = CInt(sender.Location.Y / TimeScaleRowHeight * TimeUnitValuePerRow) \ 60
        '    min = CInt(sender.Location.Y / TimeScaleRowHeight * TimeUnitValuePerRow) Mod 60
        '    sender.StartTime.Value = New DateTime(sender.StartTime.Value.Year, sender.StartTime.Value.Month, sender.StartTime.Value.Day, hour, min, 0)
        '    hour = CInt((sender.Location.Y + sender.Height) / TimeScaleRowHeight * TimeUnitValuePerRow) \ 60
        '    min = CInt((sender.Location.Y + sender.Height) / TimeScaleRowHeight * TimeUnitValuePerRow) Mod 60
        '    sender.EndTime.Value = New DateTime(sender.EndTime.Value.Year, sender.EndTime.Value.Month, sender.EndTime.Value.Day, hour, min, 0)
        'Else
        '    Dim dt As New DateTimePicker
        '    dt.Value = New DateTime(StartTime.Year, StartTime.Month, StartTime.Day, 0, 0, 0)
        '    Dim difertime As Integer = 0
        '    difertime = DateDiff(DateInterval.Minute, dt.Value, StartTime)

        '    Dim min As Integer
        '    Dim hour As Integer
        '    Dim val As Integer = 0
        '    val = CInt(sender.Location.Y / TimeScaleRowHeight * TimeUnitValuePerRow) + difertime
        '    hour = val \ 60
        '    min = val Mod 60
        '    sender.StartTime.Value = New DateTime(sender.StartTime.Value.Year, sender.StartTime.Value.Month, sender.StartTime.Value.Day, hour, min, 0)
        '    val = CInt(sender.Location.Y / TimeScaleRowHeight * TimeUnitValuePerRow) + difertime
        '    val = CInt((sender.Location.Y + sender.Height) / TimeScaleRowHeight * TimeUnitValuePerRow) + difertime
        '    '  MsgBox(val)
        '    hour = CLng(val) \ 60
        '    min = CInt(val) Mod 60
        '    sender.EndTime.Value = New DateTime(sender.EndTime.Value.Year, sender.EndTime.Value.Month, sender.EndTime.Value.Day, hour, min, 0)
        '    If sender.StartTime.Value > StartTime Then

        '    End If
        '    Me.Parent.Parent.Controls("tstatus").Text = "Date Time : " & sender.StartTime.Value.ToString & "   TO  " & sender.EndTime.Value.ToString

        'End If
    End Sub
  
    Public Property CalEndDate() As DateTime
        Get
            Return CalanderEndDate
        End Get
        Set(value As DateTime)
            CalanderEndDate = value
            Me.Invalidate()
        End Set
    End Property
    Public Property CalStartDate() As DateTime
        Get
            Return CalanderStartDate
        End Get
        Set(value As DateTime)
            CalanderStartDate = value
            Me.Invalidate()
        End Set
    End Property
    Public Property CalStartTimeForRows() As DateTime
        Get
            Return StartTime
        End Get
        Set(value As DateTime)
            StartTime = value
            Me.Invalidate()
        End Set
    End Property
    Public Property CalEndTimeForRows() As DateTime
        Get
            Return EndTime
        End Get
        Set(value As DateTime)
            EndTime = value
            Me.Invalidate()
        End Set
    End Property
    Public Property TimeScaleValues() As Integer
        Get
            Return TimeUnits
        End Get
        Set(value As Integer)
            TimeUnits = value
            Me.Height = TimeScaleRowHeight * TimeUnits * 24
            Me.Width = TimeScaleRowHeight * TimeUnits * 24 + 38
            If value = 1 Or value = 2 Then
                TimeScaleRowHeight = 30
            Else
                TimeScaleRowHeight = 30
            End If
            LoadDays()
            RearrangeCtrols()
            Me.Invalidate()
        End Set
    End Property
    Sub LoadDays()
        DaysList.Items.Clear()
        DaysList.Sorted = False
         If ListAsEmployeeNamesForColuns = False Then
            Dim tcol As Integer = 0
            tcol = DateDiff(DateInterval.Day, CalanderStartDate, CalanderEndDate)
            Dim PosVal As Integer = 1
            Dim DontShow As Boolean = False
            For i As Integer = 1 To tcol
                DontShow = False
                If CalanderStartDate.AddDays(i - 1).DayOfWeek = DayOfWeek.Sunday Then
                    If IsDisplySunday = False Then
                        DontShow = True
                    Else
                        DontShow = False
                    End If
                End If
                If CalanderStartDate.AddDays(i - 1).DayOfWeek = DayOfWeek.Saturday Then
                    If IsDisplySaturday = False Then
                        DontShow = True
                    Else
                        DontShow = False
                    End If
                End If
                If DontShow = False Then
                    DaysList.Items.Add(CalanderStartDate.AddDays(i - 1).ToString(FormatDateString))
                    PosVal = PosVal + 1
                End If
            Next
        Else

        End If


    End Sub
    Private Sub me_Click(sender As Object, e As System.EventArgs) Handles Me.Click
        Dim pt As Point = Me.PointToClient(Cursor.Position)
        Dim p1 As Long = 0
        p1 = CLng(CLng(pt.X - LeftGap) \ CLng(CalanderColumnWidth))
        SelectRectX1 = p1 * CalanderColumnWidth + LeftGap
        p1 = CLng(CLng(pt.Y) \ CLng(TimeScaleRowHeight))
        SelectRectY1 = p1 * TimeScaleRowHeight
        SelectRectX2 = pt.X + CalanderColumnWidth + LeftGap
        SelectRectY2 = pt.Y + TimeScaleRowHeight + TopGap
        Me.Focus()
        Me.Invalidate()

    End Sub

    Private Sub me_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.Clear(Me.BackColor)
        DoubleBuffered = True
        DrawHLines(sender, e)
        DrawVLines(sender, e)
        DrawSelectRect(sender, e)
        Me.ResumeLayout()

    End Sub

    Private Sub DrawSelectRect(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        If SelectRectY1 >= 0 And SelectRectY1 < Me.Width Then
            DoubleBuffered = True
            e.Graphics.FillRectangle(Brushes.WhiteSmoke, SelectRectX1, SelectRectY1, CalanderColumnWidth, TimeScaleRowHeight)
        End If


    End Sub
    Private Sub DrawHLines(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        DoubleBuffered = True
        Dim sf As New System.Drawing.StringFormat
        sf.Alignment = StringAlignment.Near
        Dim HeadPen As New Pen(Brushes.Blue, 2)

        '   e.Graphics.DrawLine(HeadPen, LeftGap, TimeScaleRowHeight, Me.Width, TimeScaleRowHeight)
        If VerticalEmpDisply = True Then
            TopGap = TimeScaleRowHeight
            For i As Integer = 0 To EmployeeList.Items.Count
                e.Graphics.DrawLine(Pens.LightBlue, 0, i * 20, Me.Width, i * 20)
            Next
            Me.Height = (EmployeeList.Items.Count + 1) * 20 + 50
        Else
            TopGap = TimeScaleRowHeight
            If ShowOnlyStartEndTimeScale = False Then

                '  e.Graphics.DrawString("00:00 AM", New Font("Arial", 10, FontStyle.Bold), Brushes.Green, 3, TimeScaleRowHeight - 9, sf)
                Dim t As New DateTimePicker
                t.Value = New DateTime(2014, 1, 1, 0, 0, 0, 0)

                For i As Integer = 1 To (24 * TimeUnits)
                    'inner grid lines
                    If TimeUnits = 1 Then
                        t.Value = t.Value.AddHours(1)
                    ElseIf TimeUnits = 2 Then
                        t.Value = t.Value.AddMinutes(30)
                    ElseIf TimeUnits = 4 Then
                        t.Value = t.Value.AddMinutes(15)
                    ElseIf TimeUnits = 10 Then
                        t.Value = t.Value.AddMinutes(6)
                    ElseIf TimeUnits = 12 Then
                        t.Value = t.Value.AddMinutes(5)
                    ElseIf TimeUnits = 30 Then
                        t.Value = t.Value.AddMinutes(2)
                    ElseIf TimeUnits = 6 Then
                        t.Value = t.Value.AddMinutes(10)
                    ElseIf TimeUnits = 3 Then
                        t.Value = t.Value.AddMinutes(20)
                    ElseIf TimeUnits = 20 Then
                        t.Value = t.Value.AddMinutes(3)
                    ElseIf TimeUnits = 60 Then
                        t.Value = t.Value.AddMinutes(1)

                    End If

                    If (i Mod TimeUnits) = 0 Then
                        e.Graphics.DrawLine(Pens.Red, LeftGap, TimeScaleRowHeight * i, Me.Width, TimeScaleRowHeight * i)
                        ' e.Graphics.DrawString(t.Value.ToString("hh:mm tt"), New Font("Arial", 10, FontStyle.Bold), Brushes.Green, 3, TimeScaleRowHeight * (i + 1) - 9, sf)
                    Else
                        e.Graphics.DrawLine(Pens.LightBlue, LeftGap + 10, TimeScaleRowHeight * i, Me.Width, TimeScaleRowHeight * i)
                        '  e.Graphics.DrawString(t.Value.ToString("hh:mm tt"), New Font("Arial", 7, FontStyle.Bold), Brushes.LightSeaGreen, 15, TimeScaleRowHeight * (i + 1) - 6, sf)
                    End If

                Next
            Else
                Dim t As New DateTimePicker
                t.Value = StartTime
                Dim totalmin = DateDiff(DateInterval.Minute, StartTime, EndTime)
                Dim countval As Integer = 0
                If TimeUnits = 1 Then
                    countval = 60
                ElseIf TimeUnits = 2 Then
                    countval = 30
                ElseIf TimeUnits = 4 Then
                    countval = 15
                ElseIf TimeUnits = 10 Then
                    countval = 6
                ElseIf TimeUnits = 12 Then
                    countval = 5
                ElseIf TimeUnits = 30 Then
                    countval = 2
                ElseIf TimeUnits = 6 Then
                    countval = 10
                ElseIf TimeUnits = 3 Then
                    countval = 20
                ElseIf TimeUnits = 20 Then
                    countval = 3
                ElseIf TimeUnits = 60 Then
                    countval = 1
                End If

                For i As Integer = 1 To totalmin / countval + 1
                    If (t.Value.Hour * 60 + t.Value.Minute) Mod 60 = 0 Then
                        e.Graphics.DrawLine(Pens.Red, LeftGap, TimeScaleRowHeight * (i - 1), Me.Width, TimeScaleRowHeight * (i - 1))
                        '  e.Graphics.DrawString(t.Value.ToString("hh:mm tt"), New Font("Arial", 10, FontStyle.Bold), Brushes.Green, 3, TimeScaleRowHeight * i - 9, sf)
                    Else
                        e.Graphics.DrawLine(Pens.LightBlue, LeftGap + 10, TimeScaleRowHeight * (i - 1), Me.Width, TimeScaleRowHeight * (i - 1))
                        '  e.Graphics.DrawString(t.Value.ToString("hh:mm tt"), New Font("Arial", 7, FontStyle.Bold), Brushes.LightSeaGreen, 15, TimeScaleRowHeight * i - 6, sf)

                    End If
                    If TimeUnits = 1 Then
                        t.Value = t.Value.AddHours(1)
                    ElseIf TimeUnits = 2 Then
                        t.Value = t.Value.AddMinutes(30)
                    ElseIf TimeUnits = 4 Then
                        t.Value = t.Value.AddMinutes(15)
                    ElseIf TimeUnits = 10 Then
                        t.Value = t.Value.AddMinutes(6)
                    ElseIf TimeUnits = 12 Then
                        t.Value = t.Value.AddMinutes(5)
                    ElseIf TimeUnits = 30 Then
                        t.Value = t.Value.AddMinutes(2)
                    ElseIf TimeUnits = 6 Then
                        t.Value = t.Value.AddMinutes(10)
                    ElseIf TimeUnits = 3 Then
                        t.Value = t.Value.AddMinutes(20)
                    ElseIf TimeUnits = 20 Then
                        t.Value = t.Value.AddMinutes(3)
                    ElseIf TimeUnits = 60 Then
                        t.Value = t.Value.AddMinutes(1)

                    End If
                Next
                Me.Height = DateDiff(DateInterval.Minute, StartTime, EndTime) / countval * TimeScaleRowHeight + 3
            End If
        End If


    End Sub
    Private Sub DrawVLines(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        DoubleBuffered = True
        Dim Kwidht = LeftGap
        e.Graphics.DrawLine(Pens.Blue, LeftGap, 0, LeftGap, Me.Height)

        Dim sf As New System.Drawing.StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        If VerticalEmpDisply = True Then
            Dim t As New DateTimePicker
            t.Value = StartTime
            Dim totalmin = DateDiff(DateInterval.Minute, StartTime, EndTime)
            Dim countval As Integer = 0
            If TimeUnits = 1 Then
                countval = 60
            ElseIf TimeUnits = 2 Then
                countval = 30
            ElseIf TimeUnits = 4 Then
                countval = 15
            ElseIf TimeUnits = 10 Then
                countval = 6
            ElseIf TimeUnits = 12 Then
                countval = 5
            ElseIf TimeUnits = 30 Then
                countval = 2
            ElseIf TimeUnits = 6 Then
                countval = 10
            ElseIf TimeUnits = 3 Then
                countval = 20
            ElseIf TimeUnits = 20 Then
                countval = 3
            ElseIf TimeUnits = 60 Then
                countval = 1
            End If
            Dim RowWidth As Integer = 0
            RowWidth = TimeScaleRowHeight + 10
            For i As Integer = 1 To totalmin / countval + 20
                ' e.Graphics.DrawLine(Pens.LightBlue, RowWidth * (i - 1) - 3, 0, RowWidth * (i - 1), Me.Height)
                If TimeUnits = 1 Then
                    t.Value = t.Value.AddHours(1)
                ElseIf TimeUnits = 2 Then
                    t.Value = t.Value.AddMinutes(30)
                ElseIf TimeUnits = 4 Then
                    t.Value = t.Value.AddMinutes(15)
                ElseIf TimeUnits = 10 Then
                    t.Value = t.Value.AddMinutes(6)
                ElseIf TimeUnits = 12 Then
                    t.Value = t.Value.AddMinutes(5)
                ElseIf TimeUnits = 30 Then
                    t.Value = t.Value.AddMinutes(2)
                ElseIf TimeUnits = 6 Then
                    t.Value = t.Value.AddMinutes(10)
                ElseIf TimeUnits = 3 Then
                    t.Value = t.Value.AddMinutes(20)
                ElseIf TimeUnits = 20 Then
                    t.Value = t.Value.AddMinutes(3)
                ElseIf TimeUnits = 60 Then
                    t.Value = t.Value.AddMinutes(1)

                End If
            Next
            Me.Width = DateDiff(DateInterval.Minute, StartTime, EndTime) / countval * TimeScaleRowHeight + 900
        Else
            If ListAsEmployeeNamesForColuns = False Then
                Dim tcol As Integer = 0
                tcol = DateDiff(DateInterval.Day, CalanderStartDate, CalanderEndDate)
                Dim PosVal As Integer = 1
                Dim DontShow As Boolean = False
                For i As Integer = 1 To tcol
                    DontShow = False
                    If CalanderStartDate.AddDays(i - 1).DayOfWeek = DayOfWeek.Sunday Then
                        If IsDisplySunday = False Then
                            DontShow = True
                        Else
                            DontShow = False
                        End If
                    End If
                    If CalanderStartDate.AddDays(i - 1).DayOfWeek = DayOfWeek.Saturday Then
                        If IsDisplySaturday = False Then
                            DontShow = True
                        Else
                            DontShow = False
                        End If
                    End If
                    If DontShow = False Then
                        Dim rect1 As New RectangleF(CInt(CalanderColumnWidth * (PosVal - 1) + LeftGap) / 2, 0, CalanderColumnWidth * (PosVal) + LeftGap, TimeScaleRowHeight)
                        e.Graphics.DrawLine(Pens.Blue, CalanderColumnWidth * PosVal + LeftGap, 0, CalanderColumnWidth * PosVal + LeftGap, Me.Height)
                        '   e.Graphics.DrawString(CalanderStartDate.AddDays(i - 1).ToString(FormatDateString), New Font("Arial", 10, FontStyle.Bold), Brushes.Green, rect1, sf)

                        Kwidht = Kwidht + CalanderColumnWidth
                        PosVal = PosVal + 1
                    End If

                Next
            Else
                For i As Integer = 1 To EmployeeList.Items.Count
                    Dim rect1 As New RectangleF(CInt(CalanderColumnWidth * (i - 1) + LeftGap) / 2, 0, CalanderColumnWidth * (i) + LeftGap, TimeScaleRowHeight)
                    e.Graphics.DrawLine(Pens.Blue, CalanderColumnWidth * i + LeftGap, 0, CalanderColumnWidth * i + LeftGap, Me.Height)
                    '  e.Graphics.DrawString(EmployeeList.Items(i - 1).ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Green, rect1, sf)
                    Kwidht = Kwidht + CalanderColumnWidth
                Next

            End If
            Me.Width = Kwidht + 3
        End If
    End Sub





    Private Sub Calanderctrl_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Calanderctrl_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel

    End Sub

   
    Sub DeleteAppointMent(sender As CalanderBox)
        Me.Controls(sender.Name).Dispose()

    End Sub
    Sub ClickAppointMent(sender As CalanderBox)
        Me.Parent.Parent.Controls("tstatus").Text = "Date Time : " & sender.StartTime.Value.ToString & "   TO  " & sender.EndTime.Value.ToString & ", ID: " & sender.ID & ", Customer Name: " & sender.CustName & Chr(13) & ", Text: " & sender.TextVal
    End Sub
    Sub DoubleClickAppointMent(sender As CalanderBox)
        RearrangeBox(Me.Controls(sender.Name))
    End Sub
    Sub ChangeDatesAppointMent(sender As CalanderBox)

    End Sub
End Class
