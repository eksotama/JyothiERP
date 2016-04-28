Public Class CalanderControl

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
    Private CalanderStartDate As DateTime = New DateTime(2014, 11, 1)
    Private CalanderEndDate As DateTime = New DateTime(2014, 12, 24)
    Private CalanderColumnWidth As Integer = 300
    Private ShowEmployeeImages As Boolean = False
    Public StartTime As DateTime = New DateTime(2014, 12, 12, 9, 0, 0)
    Public EndTime As DateTime = New DateTime(2014, 12, 12, 20, 0, 0)
    Public IsDisplySunday As Boolean = False
    Public IsDisplySaturday As Boolean = False
    Public ShowOnlyStartEndTimeScale As Boolean = True
    Private LeftGap As Integer = 0
    Private TopGap As Integer = 0
    Public DaysList As New ListBox
    Public EmployeeList As New ComboBox
    Public ListAsEmployeeNamesForColuns As Boolean = False
    Private VerticalEmpDisply As Boolean = True
    Private TimeUnits As Integer = 10
    Private TimeScaleRowHeight = 30
    Private SelectRectX1 As Integer = 0
    Private SelectRectX2 As Integer = 0
    Private SelectRectY1 As Integer = 0
    Private SelectRectY2 As Integer = 0
    Private FormatDateString As String = "dd MMMM yyyy"
    Public Sub ClearAllAppointMent()
        For i As Integer = 0 To CalanderMain1.Controls().Count - 1
            CalanderMain1.Controls(0).Dispose()
        Next
    End Sub
    Public Property IsVerticalLayout() As Boolean
        Get
            Return FormatDateString
        End Get
        Set(value As Boolean)
            VerticalEmpDisply = value
            If value = True Then
                HourToolStripMenuItem.Enabled = False
                MinsToolStripMenuItem.Enabled = False
                TableLayoutPanel1.ColumnStyles(0).Width = 175
                ' TableLayoutPanel1.RowStyles(0).Height = 50
            Else
                HourToolStripMenuItem.Enabled = True
                MinsToolStripMenuItem.Enabled = True
                TableLayoutPanel1.ColumnStyles(0).Width = 65
                '  TableLayoutPanel1.RowStyles(0).Height = 40
            End If
            CalanderLeftBar1.VerticalEmpDisply = value
            CalanderTopBar1.VerticalEmpDisply = value
            CalanderMain1.VerticalEmpDisply = value

            Panel1.Invalidate()
            'TimeScaleValues = 4
        End Set
    End Property
    Public Property setDateFormatString() As String
        Get
            Return FormatDateString
        End Get
        Set(value As String)
            FormatDateString = value
            CalanderLeftBar1.setDateFormatString = value
            CalanderTopBar1.setDateFormatString = value
            CalanderMain1.setDateFormatString = value
            Panel1.Invalidate()
        End Set
    End Property
    Public Property SetCaladerColumwidht() As Integer
        Get
            Return CalanderColumnWidth
        End Get
        Set(value As Integer)
            CalanderColumnWidth = value
            CalanderLeftBar1.SetCaladerColumwidht = value
            CalanderTopBar1.SetCaladerColumwidht = value
            CalanderMain1.SetCaladerColumwidht = value
            Me.Invalidate()
        End Set
    End Property
    Public Property CalStartTimeForRows() As DateTime
        Get
            Return StartTime
        End Get
        Set(value As DateTime)
            StartTime = value
            CalanderMain1.CalStartTimeForRows = value
            CalanderTopBar1.StartTime = value
            CalanderLeftBar1.CalStartTimeForRows = value
            Me.Invalidate()
        End Set
    End Property
    Public Property CalEndTimeForRows() As DateTime
        Get
            Return EndTime
        End Get
        Set(value As DateTime)
            EndTime = value
            CalanderMain1.CalEndTimeForRows = value
            CalanderTopBar1.EndTime = value
            CalanderLeftBar1.CalEndTimeForRows = value
            Me.Invalidate()
        End Set
    End Property
    Public Property IsShowEmployeeImages() As Boolean
        Get
            Return ShowEmployeeImages
        End Get
        Set(value As Boolean)
            ShowEmployeeImages = value
            CalanderTopBar1.IsShowEmployeeImages = value
            If value = True Then
                TableLayoutPanel1.RowStyles.Item(0).Height = 130

            Else
                TableLayoutPanel1.RowStyles.Item(0).Height = 30
            End If
        End Set
    End Property
    Public Property CalEndDate() As DateTime
        Get
            Return CalanderEndDate
        End Get
        Set(value As DateTime)
            CalanderEndDate = value
            CalanderMain1.CalEndDate = value
            CalanderTopBar1.CalEndDate = value
            CalanderLeftBar1.CalEndDate = value
            CalanderMain1.RearrangeCtrols()
            Me.Invalidate()
        End Set
    End Property
    Public Property CalStartDate() As DateTime
        Get
            Return CalanderStartDate
        End Get
        Set(value As DateTime)
            CalanderStartDate = value
            CalanderMain1.CalStartDate = value
            CalanderTopBar1.CalStartDate = value
            CalanderLeftBar1.CalStartDate = value
            CalanderMain1.RearrangeCtrols()
            Me.Invalidate()
        End Set
    End Property
    Public Property TimeScaleValues() As Integer
        Get
            Return TimeUnits
        End Get
        Set(value As Integer)
            TimeUnits = value
            CalanderLeftBar1.Location = New Point(CalanderLeftBar1.Location.X, CalanderMain1.Location.Y - 20)
            CalanderTopBar1.Location = New Point(CalanderMain1.Location.X - 65, CalanderTopBar1.Location.Y)
            CalanderMain1.TimeScaleValues = value
            CalanderTopBar1.TimeScaleValues = value
            CalanderLeftBar1.TimeScaleValues = value

            If value = 1 Or value = 2 Then
                TimeScaleRowHeight = 30
            Else
                TimeScaleRowHeight = 30
            End If
          
            Me.Invalidate()
        End Set
    End Property

    Private Sub CalanderMain1_LocationChanged(sender As Object, e As System.EventArgs) Handles CalanderMain1.LocationChanged
     
        CalanderLeftBar1.Location = New Point(CalanderLeftBar1.Location.X, CalanderMain1.Location.Y - 20)
        CalanderTopBar1.Location = New Point(CalanderMain1.Location.X - 65, CalanderTopBar1.Location.Y)
    End Sub

    Private Sub CalanderLeftBar1_Load(sender As System.Object, e As System.EventArgs) Handles CalanderLeftBar1.Load
        TimeScaleValues = 4
    End Sub

    

    Private Sub CalanderMain1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles CalanderMain1.MouseUp
        If e.Button = MouseButtons.Right Then
            ContextMenuStrip1.Show(CalanderMain1, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub HourToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HourToolStripMenuItem.Click
        TimeScaleValues = 1

    End Sub

    

    Private Sub MinsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MinsToolStripMenuItem.Click
        TimeScaleValues = 2
    End Sub

    Private Sub MinToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MinToolStripMenuItem.Click
        TimeScaleValues = 3
    End Sub

    Private Sub MinutesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MinutesToolStripMenuItem.Click
        TimeScaleValues = 6
    End Sub

    Private Sub MinutesToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles MinutesToolStripMenuItem3.Click
        TimeScaleValues = 4
    End Sub

    Private Sub MinutesToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles MinutesToolStripMenuItem1.Click
        TimeScaleValues = 10
    End Sub

    Private Sub MinutesToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles MinutesToolStripMenuItem2.Click
        TimeScaleValues = 12
    End Sub

    Private Sub CalanderControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        setDateFormatString = "dd MMMM yyyy"
        SetCaladerColumwidht = 200

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim b As New Bitmap(CalanderMain1.Width, CalanderMain1.Height)
        CalanderMain1.DrawToBitmap(b, New Rectangle(0, 0, CalanderMain1.Width, CalanderMain1.Height))
        e.Graphics.DrawImage(b, New Point(0, 0))
        b.Dispose()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        PrintDocument1.Print()
    End Sub

    Private Sub CalanderMain1_Load(sender As System.Object, e As System.EventArgs) Handles CalanderMain1.Load

    End Sub
End Class
