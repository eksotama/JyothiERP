Public Class IMSComboBox
    Public AllowDigit As Boolean = True
    Public AllowSpecialChar As Boolean = True
    Public AllDigitsChars As String = "0123456789"
    Public AllowSpace As Boolean = True
    Public AllowEmptyval As Boolean = True
    Public AllChars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz+*/-$#@!%^&*()_]{}[\></?""'"
    Public AllSplChars As String = "&-/@"
    Public ChangeCase As ChangCaseValues = 3
    Public OnlyListValue As Boolean = False
    Public TPos As Integer = 0
    Private GotFocusBackColor As Color = Color.Yellow
    Private LostFocusBackColor As Color = Color.White
    Private FunctionKeysOk As Boolean = False
    Private GotFontColor As Color = Color.Maroon
    Private LostFontColor As Color = Color.Blue
    Private IsInvalidEntry As Boolean = False
    Private IsCapitalAllow As Boolean = False
    Private m_allowToolTip As Boolean = True
    Private m_ToolTip As String
    Private IsShitPressed As Boolean = False
    Private M_IsAdvanceFilter As Boolean = False
    Public SetLedgerFilterType As New SelectedLedgerNameClass.LedgerTypeEnum
    Private IspressedAltc As Boolean = False
    Public IsValidated As Boolean = True
   
    Public Property IsAdvanceSearchWindow() As Boolean
        Get
            Return M_IsAdvanceFilter
        End Get
        Set(ByVal value As Boolean)
            M_IsAdvanceFilter = value
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

    Public Property IsAllowToolTip() As Boolean
        Get
            Return m_allowToolTip
        End Get
        Set(ByVal value As Boolean)
            m_allowToolTip = value
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
    Public Property GotFocusFontColor() As Color
        Get
            Return GotFontColor
        End Get
        Set(ByVal value As Color)
            GotFontColor = value
        End Set
    End Property
    Public Property AllowEmpty() As Boolean

        Get
            Return AllowEmptyval
        End Get
        Set(ByVal value As Boolean)
            AllowEmptyval = value
        End Set
    End Property

    Public Property AllowOnlyListValues() As Boolean
        Get
            Return OnlyListValue
        End Get
        Set(ByVal value As Boolean)
            OnlyListValue = value
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

    Protected Overridable Sub txtCombo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.BackColor = GotFocusBackColor
        Me.ForeColor = GotFontColor
        Me.SelectAll()
    End Sub

    Protected Overridable Sub txtCombo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus

        Try
            sender.text = Trim(sender.text)
            Me.BackColor = LostFocusBackColor
            Me.ForeColor = LostFontColor
        Catch ex As Exception

        End Try
      
    End Sub


    Private Sub JyothiTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If M_IsAdvanceFilter = True And Char.IsLetterOrDigit(e.KeyChar) = True And IspressedAltc = False Then
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then Exit Sub
            e.Handled = True
            Dim sval As New SelectedLedgerNameClass
            sval.LedgerType = SetLedgerFilterType
            sval.SelectedLedgerName = ""
            sval.CurrentChar = e.KeyChar
            Dim frm As New SelectLedgerNameForm(sval)
            frm.ShowDialog()
            If sval.SelectedLedgerName.Length > 0 Then
                sender.text = sval.SelectedLedgerName
            End If
        Else
            If e.KeyChar = "'" Or e.KeyChar = """" Or e.KeyChar = "[" Or e.KeyChar = "]" Then
                e.Handled = True
                Exit Sub
            End If
            Dim TotChars As String
            Dim EscKey As Boolean = False

            If e.KeyChar = Microsoft.VisualBasic.Chr(Keys.Escape) And IsExitOnEscKey = True Then
                Me.FindForm.Dispose()
                EscKey = True
                GoTo ExitLbl
            End If

            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
                If IsShitPressed = True Then Exit Sub
                Me.TopLevelControl.SelectNextControl(sender, True, True, True, True)
                GoTo ExitLbl
            End If
            If (e.KeyChar >= "A" And e.KeyChar <= "Z") And Me.Text.Length > 0 Then
                IsCapitalAllow = True
                ChangeCase = ChangCaseValues.None
            End If
            TotChars = AllChars
            If AllowSpace = True Then
                TotChars = TotChars + " "
            End If
            If AllowDigit = True Then
                TotChars = TotChars + AllDigitsChars
            End If
            If AllowSpecialChar = True Then
                TotChars = TotChars + AllSplChars
            End If

            If sender.SelectionStart < 1 And e.KeyChar = Microsoft.VisualBasic.Chr(Keys.Space) Then
                e.Handled = True
            Else
                e.Handled = False
            End If


            Try
                If CType(sender, ComboBox).SelectionStart = 0 And e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Space) Then
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

        End If
       
    End Sub


    Private Sub JyothiTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        Dim k As Integer
        Try
            If sender.dropdownstyle = ComboBoxStyle.DropDownList Then
                Exit Sub
            End If
            sender.SuspendLayout()

            k = sender.SelectionStart
            If IsCapitalAllow = True And ChangeCase <> ChangCaseValues.StrictlyTitle Then
                sender.text = LTrim(sender.text)
            ElseIf ChangeCase = ChangCaseValues.StrictlyTitle Then
                sender.Text = StrConv(LTrim(sender.Text), VbStrConv.ProperCase)
            Else
                If ChangeCase = ChangCaseValues.lower Then
                    sender.Text = StrConv(LTrim(sender.Text), VbStrConv.Lowercase)
                ElseIf ChangeCase = ChangCaseValues.None Then
                    sender.Text = LTrim(sender.text)
                ElseIf ChangeCase = ChangCaseValues.UPPER Then
                    sender.Text = StrConv(LTrim(sender.Text), VbStrConv.Uppercase)
                Else
                    sender.text = LTrim(sender.text)
                End If
            End If
        Catch ex2 As Exception
            Exit Sub
        End Try
        Try
            sender.SelectionStart = k
        Catch ex As Exception

        End Try
        sender.ResumeLayout()
    End Sub

    Private Sub JyothiTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            IspressedAltc = True
        Else
            IspressedAltc = False
        End If
        If e.Shift = True And e.KeyCode = Keys.Return Then
            IsShitPressed = True
            Me.TopLevelControl.SelectNextControl(sender, False, True, True, True)
            Exit Sub
        Else
            IsShitPressed = False
        End If

        If e.Control = True And e.KeyCode = Keys.V Then
            DirectCast(Me, ComboBox).SelectedText = Clipboard.GetText
            Exit Sub
        End If



        If e.KeyValue = Keys.Return Then
            sender.TopLevelControl.SelectNextControl(sender, True, True, True, True)
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
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Add your custom paint code here
    End Sub

    Private Sub UserComboBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
        IsValidated = True
        Try
            If MainForm.ActiveMdiChild.Equals(Me.FindForm) = False Then
                e.Cancel = False

            End If
        Catch ex As Exception

        End Try
        If OnlyListValue = True Then
            If AllowEmptyval = True And sender.Text.Length = 0 Then Exit Sub
            If Me.FindStringExact(sender.Text) > -1 Then
                e.Cancel = False
                Exit Sub
            Else
                Try
                    sender.FindForm().BringToFront()
                Catch ex As Exception

                End Try
                Beep()
                e.Cancel = True
                IsValidated = False
                If MsgBox("Invalid Selection, Do you want to Try again ", MsgBoxStyle.RetryCancel + MsgBoxStyle.Critical) = MsgBoxResult.Abort Then
                    sender.Text = ""
                    sender.Focus()
                Else
                    sender.Select(0, Me.Text.Length)
                    sender.Focus()
                End If
                Exit Sub
            End If
        End If
        If AllowEmptyval = True And String.IsNullOrEmpty(Me.Text) = True Then
            e.Cancel = False
            IsInvalidEntry = False
        ElseIf AllowEmptyval = False And String.IsNullOrEmpty(Me.Text) = True Then
            e.Cancel = True
            Beep()
            IsValidated = False
            Try
                sender.FindForm().BringToFront()
            Catch ex As Exception

            End Try
            If MsgBox("Invalid Selection, Do you want to Try again ", MsgBoxStyle.RetryCancel + MsgBoxStyle.Critical) = MsgBoxResult.Abort Then
                sender.Text = ""
            Else
                sender.Focus()
                sender.Select(0, Me.Text.Length)
            End If
        End If

        If Me.Text.Length = 0 Then
            Exit Sub
        End If


    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

   
   
End Class
