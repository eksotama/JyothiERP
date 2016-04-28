Public Class IMSNumericTextBox
    Private m_AllowDecimal As Boolean = False
    Private m_AllowNegative As Boolean = False
    Private m_AllowPluseSign As Boolean = False
    Private m_Maxlength As Long = 15
    Private m_Max As Long = 100000000000000
    Private m_Min As Long = 0
    Public BlinkColor As Color = Color.White
    Private timecount As Boolean = True
    Private m_SelectAll As Boolean
    Public IsCurrencyRateBox As Boolean = False
    Private m_Decimals As Short = ErpDecimalPlaces
    Private m_allowToolTip As Boolean = True
    Private m_ToolTip As String
    Private m_NextOnEnter As Boolean = True
    Private m_AllowHelpText As Boolean = True
    Private m_HelpText As String
    Private m_AllowExitonEcs As Boolean = True
    Private IsEscKey As Boolean = True
    Private AllowUpDownKeys As Boolean = False
    Private IsQtyText As Boolean = False
    Private GotFocusBackColor As Color = Color.Yellow
    Private LostFocusBackColor As Color = Color.White
    Private LostSize As Font = New Font("Microsoft Sans Serif", FontForLostFocus, FontStyle.Regular)
    Private GotSize As Font = New Font("Microsoft Sans Serif", FontForGotFocus, FontStyle.Regular)
    Private FunctionKeysOk As Boolean = False
    Private GotFontColor As Color = Color.Maroon
    Private LostFontColor As Color = Color.Blue
    Private CalValue As Decimal = 0
    Private AllowSpecialChar As Boolean = False
    Private m_AllowPerSign As Boolean = False
    Private IsShitPressed As Boolean = False
   

    Public Property AllowPerSign() As Boolean
        Get
            Return m_AllowPerSign
        End Get
        Set(ByVal value As Boolean)
            m_AllowPerSign = value
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
    Public Property SetToolTip() As String
        Get
            Return m_ToolTip
        End Get
        Set(ByVal value As String)
            m_ToolTip = value
            TxtToolTip.SetToolTip(Me, m_ToolTip)
        End Set
    End Property
    Public Property AllowFormulas() As Boolean
        Get
            Return AllowSpecialChar
        End Get
        Set(ByVal value As Boolean)
            AllowSpecialChar = value
            If value = True Then
                Me.MaxLength = 35
            Else
                Me.MaxLength = 12
            End If
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
    Public ReadOnly Property GetCaseValue() As Double
        Get
            If CBool(InStr(Me.Text, "-")) = True Then
                Dim Len As Integer
                Len = InStr(Me.Text, "-")
                Return CDbl(Me.Text.Substring(0, Len - 1))
            Else
                Return CDbl(Me.Text)
            End If

        End Get
    End Property
    Public ReadOnly Property GetUnitValue() As Double
        Get
            If CBool(InStr(Me.Text, "-")) = True Then
                Dim Len As Integer
                Len = InStr(Me.Text, "-")
                Return CDbl(Me.Text.Substring(Len, Me.Text.Length - Len))
            Else
                Return 0

            End If

        End Get
    End Property
    Public Property AllowForQty() As Boolean
        Get
            Return IsQtyText
        End Get
        Set(ByVal value As Boolean)
            IsQtyText = value
            If value = True Then
                AllowUpDownKeys = False
            Else
                AllowUpDownKeys = True
            End If
        End Set
    End Property
    Public Property ExitOnEscKey()
        Get
            Return IsEscKey
        End Get
        Set(ByVal value)
            IsEscKey = value
        End Set
    End Property
    Public Property UseUpDownArrowKeys() As Boolean
        Get
            Return AllowUpDownKeys
        End Get
        Set(ByVal value As Boolean)
            AllowUpDownKeys = value
        End Set
    End Property
    Public Property NextOnEnter() As Boolean
        Get
            Return m_NextOnEnter
        End Get
        Set(ByVal value As Boolean)
            m_NextOnEnter = value
        End Set
    End Property

    Public Property HelpText() As String
        Get
            Return m_HelpText
        End Get
        Set(ByVal value As String)
            m_HelpText = value
        End Set
    End Property
    Public Property AllHelpText() As Boolean
        Get
            Return m_AllowHelpText
        End Get
        Set(ByVal value As Boolean)
            m_AllowHelpText = value
            Invalidate()
        End Set
    End Property
    Public Property DecimalPlaces() As Short
        Get
            Return m_Decimals
        End Get
        Set(ByVal value As Short)
            m_Decimals = value
            Invalidate()
        End Set
    End Property

    Public Property AllowToolTip() As Boolean
        Get
            Return m_allowToolTip
        End Get
        Set(ByVal value As Boolean)
            m_allowToolTip = value
            Invalidate()
        End Set
    End Property

    Public Property ToolTip() As String
        Get
            Return m_ToolTip
        End Get
        Set(ByVal value As String)
            m_ToolTip = value
        End Set
    End Property


    Public Property Max() As Long
        Get
            Return m_Max
        End Get
        Set(ByVal Value As Long)
            m_Max = Value
            '   Invalidate()
        End Set
    End Property


    Public Property Min() As Long
        Get
            Return m_Min
        End Get
        Set(ByVal Value As Long)
            m_Min = Value
            Invalidate()
        End Set
    End Property

    Public Property AllowNegative() As Boolean
        Get
            Return m_AllowNegative
        End Get
        Set(ByVal Value As Boolean)
            m_AllowNegative = Value

            If Value = True Then
                m_Min = -100000000000000
                IsQtyText = False
            Else
                m_Min = 0
                IsQtyText = True
            End If

        End Set
    End Property


    Public Property AllowPlusSign() As Boolean
        Get
            Return m_AllowPluseSign
        End Get
        Set(ByVal Value As Boolean)
            m_AllowPluseSign = Value
            Invalidate(True)
        End Set
    End Property

    Public Property AllowDecimal() As Boolean
        Get
            Return m_AllowDecimal
        End Get
        Set(ByVal Value As Boolean)
            m_AllowDecimal = Value
            Invalidate()
        End Set
    End Property



    Private Sub sender_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Chr(Keys.Back) Then Exit Sub
        Dim EscKey As Boolean = False
        If e.KeyChar = Microsoft.VisualBasic.Chr(Keys.Escape) And IsExitOnEscKey = True Then
            Me.FindForm.Dispose()
            EscKey = True
            GoTo ExitLbl
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If IsShitPressed = True Then Exit Sub
            sender.TopLevelControl.SelectNextControl(sender, True, True, True, True)
        End If

        If AllowSpecialChar = True Then

            If e.KeyChar = "+" Or e.KeyChar = "-" Or e.KeyChar = "/" Or e.KeyChar = "*" Or e.KeyChar = "(" Or e.KeyChar = ")" Then
                e.Handled = False
                Exit Sub
            ElseIf m_AllowPerSign = True Then
                If e.KeyChar = "%" Then
                    e.Handled = False
                    Exit Sub
                End If
            End If

        End If
        If sender.SelectionLength = Len(sender.text) Then
            If AllowNegative Then
                e.Handled = Not (IsNumeric(e.KeyChar) Or (e.KeyChar = "." And Not CBool(InStr(sender.Text, "."))) Xor (e.KeyChar = "-" And Not CBool(InStr(sender.Text, "-")) And sender.SelectionStart = 0))
                GoTo ExitLbl
            Else
                e.Handled = Not (IsNumeric(e.KeyChar) Or (e.KeyChar = "." And Not CBool(InStr(sender.Text, "."))))
            End If
            If AllowForQty Then
                e.Handled = Not (IsNumeric(e.KeyChar) Or (e.KeyChar = "." And Not CBool(InStr(sender.Text, "."))) Xor (e.KeyChar = "-" And Not CBool(InStr(sender.Text, "-")) And sender.SelectionStart <> 0))
            Else
                e.Handled = Not IsNumeric(e.KeyChar)
            End If
            Exit Sub
        End If
        '  Recently added start

        If AllowDecimal = True And sender.text.ToString.Contains(".") = True And IsContainSplCha(sender) = False And sender.SelectionStart > sender.text.ToString.IndexOf(".") Then

            If IsCurrencyRateBox = True Then
                If Len(sender.text.ToString.Substring(sender.text.ToString.IndexOf(".") + 1)) >= m_Decimals Then
                    e.Handled = True
                    Exit Sub
                End If
            Else
                If Len(sender.text.ToString.Substring(sender.text.ToString.IndexOf(".") + 1)) >= ErpDecimalPlaces Then
                    e.Handled = True
                    Exit Sub
                End If
            End If

            
        ElseIf IsContainSplCha(sender) = True Then
            If AllowDecimal = False Then
                If AllowNegative Then
                    e.Handled = Not (IsNumeric(e.KeyChar) Or (e.KeyChar = "-" And Not CBool(InStr(sender.Text, "-")) And sender.SelectionStart = 0))
                    GoTo ExitLbl
                Else
                    e.Handled = Not IsNumeric(e.KeyChar)
                End If
                If AllowForQty Then

                    e.Handled = Not (IsNumeric(e.KeyChar) Or (e.KeyChar = "-" And Not CBool(InStr(sender.Text, "-")) And sender.SelectionStart <> 0))
                Else
                    e.Handled = Not IsNumeric(e.KeyChar)
                End If
            Else
                If AllowNegative Then
                    e.Handled = Not (IsNumeric(e.KeyChar) Or (e.KeyChar = "." And Not CBool(InStr(sender.Text, "."))) Xor (e.KeyChar = "-" And Not CBool(InStr(sender.Text, "-")) And sender.SelectionStart <> 0))
                    GoTo ExitLbl
                Else
                    e.Handled = Not (IsNumeric(e.KeyChar) Or (e.KeyChar = "." And Not CBool(InStr(sender.Text, "."))))
                End If
                If AllowForQty Then
                    e.Handled = Not (IsNumeric(e.KeyChar) Or (e.KeyChar = "." And Not CBool(InStr(sender.Text, "."))) Xor (e.KeyChar = "-" And Not CBool(InStr(sender.Text, "-")) And sender.SelectionStart = 0))
                Else
                    e.Handled = Not IsNumeric(e.KeyChar)
                End If

                If e.KeyChar = "." Then e.Handled = False

            End If
        Else

            If AllowDecimal = False Then
                If AllowNegative Then
                    GoTo ExitLbl
                    e.Handled = Not (IsNumeric(e.KeyChar) Or (e.KeyChar = "-" And Not CBool(InStr(sender.Text, "-")) And sender.SelectionStart = 0))
                Else
                    e.Handled = Not IsNumeric(e.KeyChar)
                End If
                If AllowForQty Then

                    e.Handled = Not (IsNumeric(e.KeyChar) Or (e.KeyChar = "-" And Not CBool(InStr(sender.Text, "-")) And sender.SelectionStart <> 0))
                Else
                    e.Handled = Not IsNumeric(e.KeyChar)
                End If
            Else
                If AllowNegative Then
                    e.Handled = Not (IsNumeric(e.KeyChar) Or (e.KeyChar = "." And Not CBool(InStr(sender.Text, "."))) Xor (e.KeyChar = "-" And Not CBool(InStr(sender.Text, "-")) And sender.SelectionStart = 0))
                    GoTo ExitLbl
                Else
                    e.Handled = Not (IsNumeric(e.KeyChar) Or (e.KeyChar = "." And Not CBool(InStr(sender.Text, "."))))
                End If
                If AllowForQty Then
                    e.Handled = Not (IsNumeric(e.KeyChar) Or (e.KeyChar = "." And Not CBool(InStr(sender.Text, "."))) Xor (e.KeyChar = "-" And Not CBool(InStr(sender.Text, "-")) And sender.SelectionStart <> 0))
                Else
                    e.Handled = Not IsNumeric(e.KeyChar)
                End If

            End If
        End If



        If AllowPlusSign = True And e.KeyChar = "+" Then
            e.Handled = sender.SelectionStart And CBool(InStr(sender.Text, "+"))
        End If

        If e.KeyChar = Chr(&H8) Then e.Handled = False
        If Len(sender.Text) > MaxLength Then e.Handled = False



        Invalidate()
ExitLbl:

    End Sub

    Private Sub NumbarTextBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        If AllowForQty = True Then
            Exit Sub
        End If
        If Val(Me.Text) > Max Then Me.Text = Max
        If Val(Me.Text) < Min Then Me.Text = Min
    End Sub

    Private Sub me_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If AllowUpDownKeys = False Then
            Exit Sub
        End If
        If e.KeyCode = Keys.Delete And Me.Text = "" Then Me.Text = 0

        Select Case e.KeyCode
            Case Keys.Up : Me.Text = Me.Text + 1
                If Me.Text > Max Then Me.Text = Max
            Case Keys.Down : Me.Text = Me.Text - 1
                If Me.Text < Min Then Me.Text = Min
        End Select
        Me.Invalidate()
    End Sub
    Function IsContainSplCha(ByVal sender As Object) As Boolean
        Dim k As Boolean = False
        If sender.text.ToString.Contains("(") = True Then
            k = True
        ElseIf sender.text.ToString.Contains(")") = True Then
            k = True
        ElseIf sender.text.ToString.Contains("+") = True Then
            k = True
        ElseIf sender.text.ToString.Contains("-") = True Then
            k = True
        ElseIf sender.text.ToString.Contains("*") = True Then
            k = True
        ElseIf sender.text.ToString.Contains("/") = True Then
            k = True
        End If
        Return k
    End Function
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
    Protected Overridable Sub txtCombo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.BackColor = GotFocusBackColor
        Me.Font = GotSize
        Me.ForeColor = GotFontColor
        Me.SelectAll()
        Try
            Timer1.Enabled = True
        Catch ex As Exception

        End Try


    End Sub

    Protected Overridable Sub txtCombo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.BackColor = LostFocusBackColor
        Me.Font = LostSize
        Me.ForeColor = LostFontColor
        If Me.Text.Length <= 0 Then
            Me.Text = "0"
        End If
        If CBool(InStr(Me.Text, "-")) = True Then
            If Me.Text.Length = 1 Then
                Me.Text = "0"
            End If
        End If

        Timer1.Enabled = False
        Try
            If IsCurrencyRateBox = True Then
                If AllowDecimal = True Then sender.text = FormatNumber(sender.text, m_Decimals, , , TriState.False)
            Else
                If AllowDecimal = True Then sender.text = FormatNumber(sender.text, ErpDecimalPlaces, , , TriState.False)
            End If

        Catch ex As Exception

        End Try

        Me.ForeColor = LostFontColor

    End Sub
#Region "Event Handlers"


#End Region


   
    Private Sub JyothiTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Shift = True And e.KeyCode = Keys.Return Then
            IsShitPressed = True
            Me.TopLevelControl.SelectNextControl(sender, False, True, True, True)
            Exit Sub
        Else
            IsShitPressed = False
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
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Add your custom paint code here
    End Sub

    Private Sub UserCalNumericTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
        If Me.Text.Length = 0 Then
            Me.Text = "0"
        End If
        If Calculate(sender.Text) = -99999999999 Then
            MsgBox("Invalid  Expression, Please Try Again......                   ", MsgBoxStyle.Information, "Error Information")
            e.Cancel = True
        Else
            sender.Text = CalValue
        End If
        
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
    Public Function Calculate(ByVal Value As String) As Decimal
        If Me.Text.Length = 0 Then
            Me.Text = "0"
        End If
        Try
            CalValue = CDec(Value)
            Return CalValue
            Exit Function
        Catch ex As Exception
        End Try
        Value = Replace(Value, ",", "")
        If Value = Nothing Then
            Value = ""
        End If
        If Value.Contains(".") = False Then
            Value = Value & ".0"
        End If

        Dim StrSql As String = "select (" & Value & ")  as Val from DuMMY"
        CalValue = FormatNumber(SQLGetNumericFieldValueForNumericTextBox(StrSql, "Val"), ErpDecimalPlaces, , , TriState.False)
        If CalValue = -999999999 Then
            Me.Focus()
            CalValue = 0
            Return 0
        Else
            Return (CalValue)
        End If


    End Function

    Private Sub TxtToolTip_Popup(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PopupEventArgs) Handles TxtToolTip.Popup

    End Sub
End Class
