Public Class IMSTextBox
    Public AllowDigit As Boolean = True
    Public AllowSpecialChar As Boolean = True
    Public AllDigitsChars As String = "0123456789"
    Public AllowSpace As Boolean = True
    Public AllChars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz+*/-$#@!%^&*()_]{}[\></?""'"
    Public AllSplChars As String = "&-/@"
    Public ChangeCase As ChangCaseValues = 3
    Private timecount As Boolean = True
    Public OnlyListValue As Boolean = True
    Public TPos As Integer = 0
    Private GotFocusBackColor As Color = Color.Yellow
    Private m_allowToolTip As Boolean = True
    Private m_ToolTip As String
    Public BlinkColor As Color = Color.White
    Private LostFocusBackColor As Color = Color.White
    Private FunctionKeysOk As Boolean = False
    Private GotFontColor As Color = Color.Maroon
    Private LostFontColor As Color = Color.Blue
    Private LostSize As Font = New Font("Microsoft Sans Serif", FontForLostFocus, FontStyle.Regular)
    Private GotSize As Font = New Font("Microsoft Sans Serif", FontForGotFocus, FontStyle.Regular)
    Private IsCapitalAllow As Boolean = False
    Private IsShitPressed As Boolean = False
   
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
    Public Property GotFocusFontSize() As Font
        Get
            Return GotSize
        End Get
        Set(ByVal value As Font)
            GotSize = value
        End Set
    End Property
    Public Property LostFocusFontSize() As Font
        Get
            Return LostSize
        End Get
        Set(ByVal value As Font)
            LostSize = value
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
    Public Property IsAllowSpace() As Boolean
        Get
            Return AllowSpace
        End Get
        Set(ByVal value As Boolean)
            AllowSpace = value
        End Set
    End Property

    Public Property SpecialCharList() As String
        Get
            Return AllSplChars
        End Get
        Set(ByVal value As String)
            AllSplChars = value
        End Set
    End Property
    Public Property CharcterCase() As ChangCaseValues
        Get
            Return ChangeCase
        End Get
        Set(ByVal value As ChangCaseValues)
            ChangeCase = value
        End Set
    End Property
    Public Property IsAllowDigits() As Boolean
        Get
            Return AllowDigit
        End Get
        Set(ByVal value As Boolean)
            AllowDigit = value
        End Set
    End Property
    Public Property IsAllowSplChars() As Boolean
        Get
            Return AllowSpecialChar
        End Get
        Set(ByVal value As Boolean)
            AllowSpecialChar = value
        End Set
    End Property
    Public Property GFocusBackColor() As Color
        Get
            Return GotFocusBackColor
        End Get
        Set(ByVal value As Color)
            GotFocusBackColor = value
        End Set
    End Property
    Public Property LFocusBackColor() As Color
        Get
            Return LostFocusBackColor
        End Get
        Set(ByVal value As Color)
            LostFocusBackColor = value
        End Set
    End Property
    Public Enum ChangCaseValues
        UPPER = 1
        lower = 2
        Title = 3
        None = 4
        StrictlyTitle = 5
    End Enum
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Add your custom paint code here
    End Sub
    
    Protected Overridable Sub txtCombo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Timer1.Enabled = True
        Me.BackColor = GotFocusBackColor
        Me.ForeColor = GotFontColor

    End Sub

    Protected Overridable Sub txtCombo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        sender.text = Trim(sender.text)
        Me.BackColor = LostFocusBackColor
        Timer1.Enabled = False
        Me.ForeColor = LostFontColor
    End Sub


    Private Sub JyothiTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If InputLanguage.CurrentInputLanguage.Culture.EnglishName.Contains("English") = True Then
            If e.KeyChar = "'" Or e.KeyChar = """" Or e.KeyChar = "[" Or e.KeyChar = "]" Then
                e.Handled = True
                Exit Sub
            End If
        End If
       
        Dim TotChars As String = ""
        Dim EscKey As Boolean = False
        If e.KeyChar = Microsoft.VisualBasic.Chr(Keys.Escape) And IsExitOnEscKey = True Then
            Me.FindForm.Dispose()
            EscKey = True
            GoTo ExitLbl
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            If IsShitPressed = True Then Exit Sub
            Me.TopLevelControl.SelectNextControl(sender, True, True, True, True)
            Exit Sub
        End If

        If (e.KeyChar >= "A" And e.KeyChar <= "Z") And Me.Text.Length > 0 Then
            IsCapitalAllow = True
            ChangeCase = ChangCaseValues.None
        End If


        'TotChars = AllChars
        'If AllowSpace = True Then
        '    TotChars = TotChars + " "
        'End If
        'If AllowDigit = True Then
        '    TotChars = TotChars + AllDigitsChars
        'End If
        'If AllowSpecialChar = True Then
        '    TotChars = TotChars + AllSplChars
        'End If

        If sender.SelectionStart < 1 And e.KeyChar = Microsoft.VisualBasic.Chr(Keys.Space) Then
            e.Handled = True
        Else
            e.Handled = False
        End If


        Try
            If CType(sender, TextBox).SelectionStart = 0 And e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Space) Then
                e.Handled = True
            End If
            Dim textbox2 As New TextBox
            textbox2.Text = sender.Text
            textbox2.SelectionStart = sender.SelectionStart
            textbox2.SelectionLength = 0
            textbox2.SelectedText = e.KeyChar
            If textbox2.Text.Contains("  ") = True Then
                e.Handled = True
            End If
            textbox2 = Nothing
        Catch ex As Exception

        End Try

ExitLbl:

    End Sub


    Private Sub JyothiTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        sender.SuspendLayout()
        Dim k As Integer
        k = sender.SelectionStart

        If IsCapitalAllow = True And ChangeCase <> ChangCaseValues.StrictlyTitle Then
            sender.text = LTrim(sender.text)
        ElseIf ChangeCase = ChangCaseValues.StrictlyTitle Then
            sender.Text = StrConv(LTrim(sender.Text), VbStrConv.ProperCase)
        Else
            If ChangeCase = ChangCaseValues.lower Then
                sender.Text = StrConv(LTrim(sender.Text), VbStrConv.Lowercase)
            ElseIf ChangeCase = ChangCaseValues.None Then
                sender.Text = LTrim(sender.Text)
            ElseIf ChangeCase = ChangCaseValues.UPPER Then
                sender.Text = StrConv(LTrim(sender.Text), VbStrConv.Uppercase)
            Else
                sender.text = LTrim(sender.text)
            End If
        End If


        Try
            sender.SelectionStart = k
        Catch ex As Exception

        End Try
        sender.ResumeLayout()
    End Sub

    Private Sub JyothiTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Shift = True And e.KeyCode = Keys.Return Then
            IsShitPressed = True
            Me.TopLevelControl.SelectNextControl(sender, False, True, True, True)
            Exit Sub
        End If
        IsShitPressed = False
      

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
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.MaxLength = 75

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If timecount = True Then
            Me.BackColor = GotFocusBackColor
            timecount = False
        Else
            Me.BackColor = BlinkColor
            timecount = True
        End If
    End Sub
End Class
