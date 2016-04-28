Public Class CalanderTopBar
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
    Private FormatDateString As String = "dddd, dd MMMM yyyy"
    Public ViewEnd As Integer = 2
    Private CalanderStartDate As DateTime = New DateTime(2014, 11, 1)
    Private CalanderEndDate As DateTime = New DateTime(2014, 12, 24)
    Private CalanderColumnWidth As Integer = 300
    Public StartTime As DateTime = New DateTime(2014, 12, 12, 9, 0, 0)
    Public EndTime As DateTime = New DateTime(2014, 12, 12, 20, 0, 0)
    Public IsDisplySunday As Boolean = False
    Public IsDisplySaturday As Boolean = False
    Public ShowOnlyStartEndTimeScale As Boolean = True
    Private LeftGap As Integer = 65
    Private TopGap As Integer = 30
    Public DaysList As New ListBox
    Public EmployeeList As New ComboBox
    Public ListAsEmployeeNamesForColuns As Boolean = False
    Private ShowEmployeeImages As Boolean = False
    Private TimeUnits As Integer = 2
    Private TimeScaleRowHeight = 20
    Public VerticalEmpDisply As Boolean = True
    Private SelectRectX1 As Integer = 0
    Private SelectRectX2 As Integer = 0
    Private SelectRectY1 As Integer = 0
    Private SelectRectY2 As Integer = 0
    Public Property IsShowEmployeeImages() As Boolean
        Get
            Return ShowEmployeeImages
        End Get
        Set(value As Boolean)
            ShowEmployeeImages = value
            Me.Validate()
        End Set
    End Property
    Public Property IsAllowToShowEmployeeImages() As Boolean
        Get
            Return ShowEmployeeImages
        End Get
        Set(value As Boolean)
            ShowEmployeeImages = value
            Me.Invalidate()
        End Set
    End Property
    Public Property setDateFormatString() As String
        Get
            Return FormatDateString
        End Get
        Set(value As String)
            FormatDateString = value
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
    Public Property TimeScaleValues() As Integer
        Get
            Return TimeUnits
        End Get
        Set(value As Integer)
            TimeUnits = value
            Me.Height = TimeScaleRowHeight * TimeUnits * 24 + 38
            Me.Width = TimeScaleRowHeight * TimeUnits * 24 + 38
            If value = 1 Or value = 2 Then
                TimeScaleRowHeight = 30
            Else
                TimeScaleRowHeight = 20
            End If
            Me.Invalidate()
        End Set
    End Property
    Sub LoadDays()
        DaysList.Items.Clear()
        If ShowOnlyStartEndTimeScale = False Then
            Dim t As New DateTimePicker
            t.Value = New DateTime(2014, 1, 1, 0, 0, 0, 0)
            For i As Integer = ViewStart To (24 * TimeUnits)
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
                DaysList.Items.Add(t.Value.ToString("hh:mm tt"))
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
                DaysList.Items.Add(t.Value.ToString("hh:mm tt"))
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
        Me.Invalidate()
    End Sub

    Private Sub me_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.Clear(Me.BackColor)
        DoubleBuffered = True
        '  DrawHLines(sender, e)
        DrawVLines(sender, e)
        '   DrawSelectRect(sender, e)
        Me.ResumeLayout()

    End Sub

    Private Sub DrawSelectRect(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        If SelectRectY1 > 20 Then
            DoubleBuffered = True
            e.Graphics.FillRectangle(Brushes.LightSeaGreen, SelectRectX1, SelectRectY1, CalanderColumnWidth, TimeScaleRowHeight)
        End If


    End Sub
    Private Sub DrawHLines(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        DoubleBuffered = True
        Dim sf As New System.Drawing.StringFormat
        sf.Alignment = StringAlignment.Near
        Dim HeadPen As New Pen(Brushes.Blue, 2)

        e.Graphics.DrawLine(HeadPen, LeftGap, TimeScaleRowHeight, Me.Width, TimeScaleRowHeight)
        TopGap = TimeScaleRowHeight
        If ShowOnlyStartEndTimeScale = False Then

            e.Graphics.DrawString("00:00 AM", New Font("Arial", 10, FontStyle.Bold), Brushes.Green, 3, TimeScaleRowHeight - 9, sf)
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
                    e.Graphics.DrawLine(Pens.Red, LeftGap, TimeScaleRowHeight * (i + 1), Me.Width, TimeScaleRowHeight * (i + 1))
                    e.Graphics.DrawString(t.Value.ToString("hh:mm tt"), New Font("Arial", 10, FontStyle.Bold), Brushes.Green, 3, TimeScaleRowHeight * (i + 1) - 9, sf)

                Else
                    e.Graphics.DrawLine(Pens.LightBlue, LeftGap + 10, TimeScaleRowHeight * (i + 1), Me.Width, TimeScaleRowHeight * (i + 1))
                    e.Graphics.DrawString(t.Value.ToString("hh:mm tt"), New Font("Arial", 7, FontStyle.Bold), Brushes.LightSeaGreen, 15, TimeScaleRowHeight * (i + 1) - 6, sf)

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
                    e.Graphics.DrawLine(Pens.Red, LeftGap, TimeScaleRowHeight * (i), Me.Width, TimeScaleRowHeight * i)
                    e.Graphics.DrawString(t.Value.ToString("hh:mm tt"), New Font("Arial", 10, FontStyle.Bold), Brushes.Green, 3, TimeScaleRowHeight * i - 9, sf)
                Else
                    e.Graphics.DrawLine(Pens.LightBlue, LeftGap + 10, TimeScaleRowHeight * i, Me.Width, TimeScaleRowHeight * i)
                    e.Graphics.DrawString(t.Value.ToString("hh:mm tt"), New Font("Arial", 7, FontStyle.Bold), Brushes.LightSeaGreen, 15, TimeScaleRowHeight * i - 6, sf)

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
            Me.Height = DateDiff(DateInterval.Minute, StartTime, EndTime) / countval * TimeScaleRowHeight + 75
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
            If ShowOnlyStartEndTimeScale = False Then

                e.Graphics.DrawString("00:00 AM", New Font("Arial", 10, FontStyle.Bold), Brushes.Green, 3, TimeScaleRowHeight - 9, sf)
                Dim t As New DateTimePicker
                t.Value = New DateTime(2014, 1, 1, 0, 0, 0, 0)

                For i As Integer = 1 To (24 * TimeUnits) + 1
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
                        e.Graphics.DrawLine(Pens.Red, LeftGap, TimeScaleRowHeight * (i + 1), Me.Width, TimeScaleRowHeight * (i + 1))
                        e.Graphics.DrawString(t.Value.ToString("hh:mm tt"), New Font("Arial", 10, FontStyle.Bold), Brushes.Green, TimeScaleRowHeight * (i + 1) - 9, 3, sf)

                    Else
                        e.Graphics.DrawLine(Pens.LightBlue, LeftGap + 10, TimeScaleRowHeight * (i + 1), Me.Width, TimeScaleRowHeight * (i + 1))
                        e.Graphics.DrawString(t.Value.ToString("hh:mm tt"), New Font("Arial", 7, FontStyle.Bold), Brushes.LightSeaGreen, TimeScaleRowHeight * (i + 1) - 6, 15, sf)

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
                Dim RowWidth As Integer = 0
                RowWidth = TimeScaleRowHeight + 10
                For i As Integer = 1 To totalmin / countval + 1
                    Dim rect1 As New Rectangle(CInt(RowWidth * (i - 1) + LeftGap), 0, 30, 40)
                    'e.Graphics.DrawLine(Pens.Blue, CalanderColumnWidth * i + LeftGap, 0, CalanderColumnWidth * i + LeftGap, Me.Height)
                    'e.Graphics.DrawString(EmployeeList.Items(i - 1).ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Green, rect1, sf)

                    If (t.Value.Hour * 60 + t.Value.Minute) Mod 60 = 0 Then
                        ' e.Graphics.DrawLine(Pens.Red, RowWidth * (i - 1), 0, RowWidth * (i - 1), Me.Height)
                        e.Graphics.DrawLine(Pens.LightBlue, RowWidth * (i - 1), 0, RowWidth * (i - 1), Me.Height)
                        e.Graphics.DrawString(t.Value.ToString("hh:mm tt"), New Font("Arial", 10, FontStyle.Bold), Brushes.Green, rect1, sf)
                    Else
                        e.Graphics.DrawLine(Pens.LightBlue, RowWidth * (i - 1), 0, RowWidth * (i - 1), Me.Height)
                        e.Graphics.DrawString(t.Value.ToString("hh:mm tt"), New Font("Arial", 7, FontStyle.Bold), Brushes.LightSeaGreen, rect1, sf)

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
                Me.Width = DateDiff(DateInterval.Minute, StartTime, EndTime) / countval * TimeScaleRowHeight + 900
                ' Me.Width = Kwidht + 3
            End If
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
                        e.Graphics.DrawString(CalanderStartDate.AddDays(i - 1).ToString(FormatDateString), New Font("Arial", 10, FontStyle.Bold), Brushes.Green, rect1, sf)
                        Kwidht = Kwidht + CalanderColumnWidth
                        PosVal = PosVal + 1
                    End If

                Next
            Else
                If EmployeeList.Items.Count > 0 Then
                    For i As Integer = 1 To EmployeeList.Items.Count
                        Dim rect1 As New Rectangle(CInt(CalanderColumnWidth * (i - 1) + LeftGap), 0, CalanderColumnWidth, 40)
                        e.Graphics.DrawLine(Pens.Blue, CalanderColumnWidth * i + LeftGap, 0, CalanderColumnWidth * i + LeftGap, Me.Height)
                        e.Graphics.DrawString(EmployeeList.Items(i - 1).ToString, New Font("Arial", 10, FontStyle.Bold), Brushes.Green, rect1, sf)
                        Kwidht = Kwidht + CalanderColumnWidth
                        If IsShowEmployeeImages = True Then
                            Dim img As Image = GetImageFromDatabase("ImageData", "SELECT TOP 1  IMAGEDATA FROM IMAGES where bcode=N'EMP" & SQLGetStringFieldValue("select EmpID from employees where empname=N'" & EmployeeList.Items(i - 1).ToString & "'", "EmpID") & "'")
                            Dim destRect As New Rectangle(CInt((CalanderColumnWidth * (i - 1) + LeftGap)) + CInt(CalanderColumnWidth / 4), 40, CInt(CalanderColumnWidth / 2), 90)
                            ' Dim srcRect As New Rectangle(50, 50, 150, 150)
                            Dim units As GraphicsUnit = GraphicsUnit.Pixel

                            e.Graphics.DrawImage(img, CInt((CalanderColumnWidth * (i - 1) + LeftGap)) + CInt(CalanderColumnWidth / 4), 40, CInt(CalanderColumnWidth / 2), 90)
                            e.Graphics.DrawRectangle(Pens.Green, destRect)

                        End If
                    Next
                End If


            End If
            Me.Width = Kwidht + 3
        End If
        

    End Sub

End Class
