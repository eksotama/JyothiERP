Public Class IMSButton
    Private FunctionKeysOk As Boolean = False
    Private GotFontColor As Color = Color.Maroon
    Private LostFontColor As Color = Color.Blue
    Private m_allowToolTip As Boolean = True
    Private m_ToolTip As String = ""
    Private IsShitPressed As Boolean = False
    Private FontSizeGotFocus As Single = FontForGotFocus
    Private FontSizeLoseFocus As Single = FontForLostFocus
    Public Property AllowToolTip() As Boolean
        Get
            Return m_allowToolTip
        End Get
        Set(ByVal value As Boolean)
            m_allowToolTip = value
            Invalidate()
        End Set
    End Property
    Public Property SetToolTip() As String
        Get
            Return m_ToolTip
        End Get
        Set(ByVal value As String)
            m_ToolTip = value
            TxtToolTip.SetToolTip(Me, m_ToolTip)
        End Set
    End Property
    Public Property GotFocusFontColor() As Color
        Get
            Return GotFontColor
        End Get
        Set(ByVal value As Color)
            GotFontColor = value
        End Set
    End Property
    Public Property LostFocusFontColor() As Color
        Get
            Return LostFontColor
        End Get
        Set(ByVal value As Color)
            LostFontColor = value
        End Set
    End Property
    Public Property UseFunctionKeys() As Boolean
        Get
            Return FunctionKeysOk
        End Get

        Set(ByVal value As Boolean)
            FunctionKeysOk = value
        End Set
    End Property

    
    
    Protected Overridable Sub txtCombo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.Font = New Font(Me.Font.Name, 10, FontStyle.Regular)
        Me.ForeColor = GotFontColor
    End Sub

    Protected Overridable Sub txtCombo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.Font = New Font(Me.Font.Name, 8.25, FontStyle.Bold)
        Me.ForeColor = LostFontColor
    End Sub

    Private Sub JyothiTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Shift = True And e.KeyCode = Keys.Return Then

            Me.TopLevelControl.SelectNextControl(sender, False, True, True, True)
            Exit Sub
        End If
        If FunctionKeysOk = True Then
            Dim Ary(4) As Object
            If e.KeyValue = 112 Or e.KeyValue = 113 Or e.KeyValue = 114 Or e.KeyValue = 115 Or e.KeyValue = 116 Or e.KeyValue = 117 Or e.KeyValue = 118 Or e.KeyValue = 119 Or e.KeyValue = 120 Or e.KeyValue = 121 Or e.KeyValue = 122 Or e.KeyValue = 123 Then
                e.Handled = True
                Ary(0) = e.KeyValue
                Ary(1) = e.Alt
                Ary(2) = e.Control
                Ary(3) = e.Shift
                CallByName(Me.TopLevelControl, "FunctionKeysDown", CallType.Method, Ary)
            End If
        End If

    End Sub

    Private Sub UserButton_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Me.Font = New Font(Me.Font.Name, FontSizeGotFocus, FontStyle.Bold)
        Me.ForeColor = GotFontColor
    End Sub

    Private Sub UserButton_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        Me.Font = New Font(Me.Font.Name, FontSizeLoseFocus, FontStyle.Bold)
        Me.ForeColor = LostFontColor
    End Sub

    Private Sub IMSButton_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(Keys.Escape) And IsExitOnEscKey = True Then

            Me.FindForm.Dispose()
        End If
    End Sub
End Class
