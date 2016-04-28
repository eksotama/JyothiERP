Imports System.Drawing.Drawing2D

Public Class CalanderBox
    Declare Function SetCursorPos& Lib "user32" (ByVal p As Point)
    Private mMouseDown As Boolean = False
    Private mEdge As EdgeEnum = EdgeEnum.None
    Private mWidth As Integer = 4
    Private mOutlineDrawn As Boolean = False
    Public ID As Long = 0
    Public Imagepath As String = ""
    Public StartTime As New DateTimePicker
    Public EndTime As New DateTimePicker
    Public CalanderStartDate As New DateTimePicker
    Public CalanderEnddate As New DateTimePicker
    Public DutyStartDate As New DateTimePicker
    Public DutyEndDate As New DateTimePicker
    Public PatterStyle As HatchStyle
    Public PatterColor As Color = Color.Empty
    Public EmployeeID As String = ""
    Public TextVal As String = ""
    Public IsBreakTime As Boolean = False
    Public IsLoked As Boolean = False
    Public Servicelist As String = ""
    Public Event SizeChangedby(sender As CalanderBox, NewValues As Integer)
    Public Event CalanderBoxClick(sender As CalanderBox)
    Public Event CalanderBoxDoubleClick(sender As CalanderBox)
    Public Event CalanderDeletePressed(sender As CalanderBox)
    Public Event SelectedCalander(sender As CalanderBox)
    Private IsFocused As Boolean = False
    Public CustName As String = ""
    Private Enum EdgeEnum
        None
        Right
        Left
        Top
        Bottom
        TopLeft
    End Enum

    Private Sub CalanderBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If IsBreakTime = True Then Exit Sub
        If IsLoked = True Then Exit Sub
        If e.KeyCode = Keys.Delete Then
            deletethisApp()
        End If
    End Sub

    Private Sub CalanderBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub


    'Private Sub me_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
    '    If e.Button = Windows.Forms.MouseButtons.Left Then
    '        mMouseDown = True
    '    End If
    'End Sub

    'Private Sub me_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
    '    mMouseDown = False
    'End Sub



    'Private Sub me_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
    '    If IsBreakTime = True Then Exit Sub
    '    Dim c As Control = CType(sender, Control)
    '    Dim g As Graphics = c.CreateGraphics
    '    Dim bp As Pen = New Pen(Me.BackColor)


    '    Select Case mEdge
    '        Case EdgeEnum.TopLeft
    '            '   g.FillRectangle(Brushes.Fuchsia, 0, 0, mWidth * 2, mWidth * 2)
    '            mOutlineDrawn = True
    '        Case EdgeEnum.Left
    '            '    g.FillRectangle(Brushes.Fuchsia, 0, 0, mWidth, c.Height)
    '            mOutlineDrawn = True
    '        Case EdgeEnum.Right
    '            '     g.FillRectangle(Brushes.Fuchsia, c.Width - mWidth, 0, c.Width, c.Height)

    '            mOutlineDrawn = True
    '        Case EdgeEnum.Top
    '            g.DrawRectangle(bp, 0, 0, c.Width, mWidth)
    '            mOutlineDrawn = True
    '        Case EdgeEnum.Bottom
    '            g.DrawRectangle(bp, 0, c.Height - mWidth, c.Width, mWidth)
    '            mOutlineDrawn = True
    '        Case EdgeEnum.None
    '            If mOutlineDrawn Then
    '                c.Refresh()
    '                mOutlineDrawn = False
    '            End If
    '    End Select

    '    If mMouseDown And mEdge <> EdgeEnum.None Then
    '        If e.Y Mod 15 = 0 Then
    '            c.SuspendLayout()
    '            Select Case mEdge
    '                Case EdgeEnum.TopLeft
    '                    ' c.SetBounds(c.Left + e.X, c.Top + e.Y, c.Width, c.Height)
    '                Case EdgeEnum.Left
    '                    '  c.SetBounds(c.Left + e.X, c.Top, c.Width - e.X, c.Height)
    '                Case EdgeEnum.Right
    '                    '  c.SetBounds(c.Left, c.Top, c.Width - (c.Width - e.X), c.Height)
    '                Case EdgeEnum.Top
    '                    If c.Height - e.Y > 0 Then
    '                        c.SetBounds(c.Left, c.Top + e.Y, c.Width, c.Height - e.Y)
    '                    End If

    '                Case EdgeEnum.Bottom
    '                    c.SetBounds(c.Left, c.Top, c.Width, c.Height - (c.Height - e.Y))
    '            End Select
    '            c.ResumeLayout()
    '        End If

    '    Else
    '        Select Case True
    '            Case e.X <= (mWidth * 4) And e.Y <= (mWidth * 4) 'top left corner
    '                c.Cursor = Cursors.Default
    '                mEdge = EdgeEnum.TopLeft
    '            Case e.X <= mWidth 'left edge
    '                c.Cursor = Cursors.Default
    '                mEdge = EdgeEnum.Left
    '            Case e.X > c.Width - (mWidth + 1) 'right edge
    '                c.Cursor = Cursors.Default
    '                mEdge = EdgeEnum.Right
    '            Case e.Y <= mWidth 'top edge
    '                c.Cursor = Cursors.SizeNS
    '                mEdge = EdgeEnum.Top
    '            Case e.Y > c.Height - (mWidth + 1) 'bottom edge
    '                c.Cursor = Cursors.SizeNS
    '                mEdge = EdgeEnum.Bottom
    '            Case Else 'no edge
    '                c.Cursor = Cursors.Default
    '                mEdge = EdgeEnum.None
    '        End Select
    '    End If
    'End Sub

    'Private Sub me_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
    '    If IsBreakTime = True Then Exit Sub
    '    Dim c As Control = CType(sender, Control)
    '    mEdge = EdgeEnum.None
    '    c.Refresh()
    'End Sub

    Private Sub TextBox1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If IsBreakTime = True Then Exit Sub
        If IsLoked = True Then Exit Sub
        If e.Button = MouseButtons.Right Then
            ContextMenuStrip1.Show(Me, New Point(e.X, e.Y))
        End If
    End Sub


    Private Sub MoreToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MoreToolStripMenuItem.Click
        If IsBreakTime = True Then Exit Sub
        If IsLoked = True Then Exit Sub
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            Me.BackColor = ColorDialog1.Color
            ExecuteSQLQuery("update Appointmentdb set ColorR=" & Me.BackColor.R & ",ColorG=" & Me.BackColor.G & ",ColorB=" & Me.BackColor.B & " where appid=" & Me.ID)
        End If
    End Sub

    Private Sub RedToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RedToolStripMenuItem.Click
        Me.BackColor = Color.Tomato
        ExecuteSQLQuery("update Appointmentdb set ColorR=" & Me.BackColor.R & ",ColorG=" & Me.BackColor.G & ",ColorB=" & Me.BackColor.B & " where appid=" & Me.ID)
    End Sub

    Private Sub GreenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GreenToolStripMenuItem.Click
        Me.BackColor = Color.PaleGreen
        ExecuteSQLQuery("update Appointmentdb set ColorR=" & Me.BackColor.R & ",ColorG=" & Me.BackColor.G & ",ColorB=" & Me.BackColor.B & " where appid=" & Me.ID)
    End Sub

    Private Sub BlueToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BlueToolStripMenuItem.Click
        Me.BackColor = Color.DeepSkyBlue
        ExecuteSQLQuery("update Appointmentdb set ColorR=" & Me.BackColor.R & ",ColorG=" & Me.BackColor.G & ",ColorB=" & Me.BackColor.B & " where appid=" & Me.ID)
    End Sub

    Private Sub YellowToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles YellowToolStripMenuItem.Click
        Me.BackColor = Color.Yellow
        ExecuteSQLQuery("update Appointmentdb set ColorR=" & Me.BackColor.R & ",ColorG=" & Me.BackColor.G & ",ColorB=" & Me.BackColor.B & " where appid=" & Me.ID)
    End Sub



    Private Sub CalanderBox_SizeChanged(sender As Object, e As System.EventArgs) Handles Me.SizeChanged
        If IsBreakTime = True Then Exit Sub
        If IsLoked = True Then Exit Sub
        Me.Invalidate()
        RaiseEvent SizeChangedby(Me, Me.Height)
    End Sub

    Private Sub CalanderBox_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If IsBreakTime = True Then
           
            Dim rect2 As New Rectangle(0, 0, Me.Width, Me.Height)
            Dim r1 As New GraphicsPath
            r1.AddRectangle(rect2)
            Dim b As New LinearGradientBrush(rect2, Color.White, Me.BackColor, 90)
            e.Graphics.FillPath(b, r1)
            e.Graphics.FillRectangle(Brushes.Purple, 0, 0, 8, Me.Height)
            Dim rect As New Rectangle(10, 0, Me.Width - 10, Me.Height - 5)
            e.Graphics.DrawString(TextVal, New Font("Arial", 8.25, FontStyle.Regular), Brushes.Black, rect)

        Else
            Dim rect2 As New Rectangle(0, 0, Me.Width, Me.Height)
            Dim r1 As New GraphicsPath
            r1.AddRectangle(rect2)
            If IsLoked = True Then
                Dim b As New LinearGradientBrush(rect2, Color.Green, Color.Green, 90)
                e.Graphics.FillPath(b, r1)
            Else
                Dim b As New LinearGradientBrush(rect2, Color.White, Me.BackColor, 90)
                e.Graphics.FillPath(b, r1)
            End If
          


            If IsFocused = True Then
                Dim rect1 As New Rectangle(2, 2, Me.Width - 6, Me.Height - 6)
                e.Graphics.DrawRectangle(Pens.Blue, rect1)
                Dim pen As New Pen(Brushes.Blue, 2)
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
                e.Graphics.DrawRectangle(pen, 0, 0, 4, 4)
                e.Graphics.DrawRectangle(pen, Me.Width - 4, 0, 2, 2)
            Else

            End If




            If PatterColor <> Color.Empty Then
                Dim rect3 As New Rectangle(8, 0, Me.Width, Me.Height)
                Dim r As New GraphicsPath
                r.AddRectangle(rect3)
                Dim brush As New HatchBrush(PatterStyle, PatterColor, Color.Transparent)
                e.Graphics.FillPath(brush, r)
            End If
            If Imagepath.Length > 0 Then
                Try
                    Dim img As Image
                    img = Image.FromFile(Imagepath)

                    e.Graphics.DrawImage(img, 2, 2, 30, 30)
                Catch ex As Exception

                End Try
            End If
            e.Graphics.FillRectangle(Brushes.Purple, 0, 0, 8, Me.Height)
            Dim rect As New Rectangle(10, 0, Me.Width - 10, Me.Height - 5)

            e.Graphics.DrawString(CustName & Chr(10) & Chr(13) & TextVal, New Font("Arial", 8.25, FontStyle.Regular), Brushes.Black, rect)
        End If
        
    End Sub




    Private Sub CalanderBox_LostFocus(sender As Object, e As System.EventArgs) Handles Me.LostFocus
        IsFocused = False
        Me.Invalidate()
    End Sub

    Private Sub CalanderBox_GotFocus(sender As Object, e As System.EventArgs) Handles Me.GotFocus
        IsFocused = True
        Me.Invalidate()
    End Sub

    Private Sub CalanderBox_DoubleClick(sender As Object, e As System.EventArgs) Handles Me.DoubleClick, EditToolStripMenuItem.Click
        If IsBreakTime = True Then Exit Sub
        If IsLoked = True Then Exit Sub
        If MsgBox("Do you want to Edit ? ...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim frm As New EditCalander(Me, CalanderStartDate, CalanderEnddate)
            frm.ShowDialog()
            Me.ToolTip1.SetToolTip(Me, "Timigs: " & Me.StartTime.Value & " To " & Me.EndTime.Value & Chr(13) & ", Customer Name: " & CustName & Chr(13) & Servicelist & Chr(13) & TextVal)
            RaiseEvent CalanderBoxDoubleClick(Me)
        End If

    End Sub
    Private Sub CalanderBox_Click(sender As Object, e As System.EventArgs) Handles Me.Click
        RaiseEvent CalanderBoxClick(sender)
    End Sub
    'CalanderDeletePressed

    Private Sub CalanderBox_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.ToolTip1.SetToolTip(Me, TextVal)
    End Sub

    Private Sub CalanderBox_LocationChanged(sender As Object, e As System.EventArgs) Handles Me.LocationChanged
        Me.Invalidate()
        RaiseEvent SizeChangedby(Me, Me.Height)
    End Sub

    Private Sub diagonalToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles diagonalToolStripMenuItem.Click
        Me.PatterStyle = System.Drawing.Drawing2D.HatchStyle.ForwardDiagonal
        ExecuteSQLQuery("update Appointmentdb set PatterStyle=" & System.Drawing.Drawing2D.HatchStyle.ForwardDiagonal & " Where appid=" & Me.ID)
        ExecuteSQLQuery("UPDATE Appointmentdb set PatterColorR=" & Me.PatterColor.R & ",PatterColorg=" & Me.PatterColor.G & ",PatterColorb=" & Me.PatterColor.B & " Where appid=" & Me.ID)
        Me.PatterColor = Color.Red
        Me.Invalidate()
    End Sub

    Private Sub verticalToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles verticalToolStripMenuItem.Click
        Me.PatterStyle = System.Drawing.Drawing2D.HatchStyle.Vertical
        Me.PatterColor = Color.Red
        ExecuteSQLQuery("update Appointmentdb set PatterStyle=" & System.Drawing.Drawing2D.HatchStyle.Vertical & " Where appid=" & Me.ID)
        ExecuteSQLQuery("UPDATE Appointmentdb set PatterColorR=" & Me.PatterColor.R & ",PatterColorg=" & Me.PatterColor.G & ",PatterColorb=" & Me.PatterColor.B & " Where appid=" & Me.ID)
        Me.Invalidate()
    End Sub

    Private Sub horizontalToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles horizontalToolStripMenuItem.Click
        Me.PatterStyle = System.Drawing.Drawing2D.HatchStyle.Horizontal
        ExecuteSQLQuery("update Appointmentdb set PatterStyle=" & System.Drawing.Drawing2D.HatchStyle.Horizontal & " Where appid=" & Me.ID)
        Me.PatterColor = Color.Red
        ExecuteSQLQuery("UPDATE Appointmentdb set PatterColorR=" & Me.PatterColor.R & ",PatterColorg=" & Me.PatterColor.G & ",PatterColorb=" & Me.PatterColor.B & " Where appid=" & Me.ID)
        Me.Invalidate()
    End Sub

    Private Sub hatchToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles hatchToolStripMenuItem.Click
        Me.PatterStyle = System.Drawing.Drawing2D.HatchStyle.DiagonalCross
        ExecuteSQLQuery("update Appointmentdb set PatterStyle=" & System.Drawing.Drawing2D.HatchStyle.DiagonalCross & " Where appid=" & Me.ID)
        Me.PatterColor = Color.Red
        ExecuteSQLQuery("UPDATE Appointmentdb set PatterColorR=" & Me.PatterColor.R & ",PatterColorg=" & Me.PatterColor.G & ",PatterColorb=" & Me.PatterColor.B & " Where appid=" & Me.ID)
        Me.Invalidate()
    End Sub

    Private Sub noneToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles noneToolStripMenuItem.Click
        Me.PatterStyle = System.Drawing.Drawing2D.HatchStyle.DiagonalCross
        ExecuteSQLQuery("update Appointmentdb set PatterStyle=" & System.Drawing.Drawing2D.HatchStyle.DiagonalCross & " Where appid=" & Me.ID)
        ExecuteSQLQuery("UPDATE Appointmentdb set PatterColorR=0,PatterColorg=0,PatterColorb=0 Where appid=" & Me.ID)
        Me.PatterColor = Color.Empty
        Me.Invalidate()
    End Sub

    Private Sub DELETEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DELETEToolStripMenuItem.Click
        DeleteThisAPP()
    End Sub
    Sub DeleteThisAPP()
        If MsgBox("Do you want to delete ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ExecuteSQLQuery("DELETE Appointmentdb WHERE APPID=" & ID)
            ExecuteSQLQuery("DELETE AppointmentRows WHERE APPID=" & ID)
            RaiseEvent CalanderDeletePressed(Me)
        End If
    End Sub

    Private Sub ToolTip1_Popup(sender As System.Object, e As System.Windows.Forms.PopupEventArgs) Handles ToolTip1.Popup

    End Sub

    'Private Sub GenerateBillToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GenerateBillToolStripMenuItem.Click
    '    If MsgBox("Do you want to Generate the Appointment ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

    '        Dim frm As New InvoiceAlterForm
    '        frm.TxtTitle.Text = "POS FOR SERVICES"
    '        Dim K As New SalesControlAll("POS")
    '        K.BtnNew.Enabled = False
    '        K.BtnOpen.Enabled = False
    '        K.AppID = Me.ID
    '        frm.TxtList.Controls.Add(K)
    '        frm.TxtList.Controls(0).Dock = DockStyle.Fill
    '        frm.WindowState = FormWindowState.Maximized

    '        frm.ShowDialog()
    '        frm.Dispose()
    '        K.Dispose()
    '        If SQLGetBooleanFieldValue("SELECT IsOrderConfirm  FROM Appointmentdb   WHERE  APPID=" & Me.ID, "IsOrderConfirm") = True Then
    '            Me.IsLoked = True
    '        End If


    '    End If
    'End Sub
End Class
