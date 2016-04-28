<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PayRollVoucherRow
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtLedgerName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtCurrentbalance = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtDrCr = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtAmount = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtNarration = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtCurRate = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtLedgerName, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtCurrentbalance, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtDrCr, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtAmount, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtNarration, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtCurRate, 3, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(433, 46)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'TxtLedgerName
        '
        Me.TxtLedgerName.AllowEmpty = False
        Me.TxtLedgerName.AllowOnlyListValues = True
        Me.TxtLedgerName.AllowToolTip = True
        Me.TxtLedgerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtLedgerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtLedgerName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtLedgerName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtLedgerName.FormattingEnabled = True
        Me.TxtLedgerName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLedgerName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLedgerName.IsAdvanceSearchWindow = False
        Me.TxtLedgerName.IsAllowDigits = True
        Me.TxtLedgerName.IsAllowSpace = True
        Me.TxtLedgerName.IsAllowSplChars = True
        Me.TxtLedgerName.IsAllowToolTip = True
        Me.TxtLedgerName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLedgerName.Location = New System.Drawing.Point(53, 3)
        Me.TxtLedgerName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLedgerName.Name = "TxtLedgerName"
        Me.TxtLedgerName.SetToolTip = "Press Alt+C, To Create New "
        Me.TxtLedgerName.Size = New System.Drawing.Size(203, 21)
        Me.TxtLedgerName.Sorted = True
        Me.TxtLedgerName.SpecialCharList = "&-/@"
        Me.TxtLedgerName.TabIndex = 1
        Me.TxtLedgerName.UseFunctionKeys = False
        '
        'TxtCurrentbalance
        '
        Me.TxtCurrentbalance.AutoSize = True
        Me.TxtCurrentbalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCurrentbalance.Location = New System.Drawing.Point(53, 25)
        Me.TxtCurrentbalance.Name = "TxtCurrentbalance"
        Me.TxtCurrentbalance.Size = New System.Drawing.Size(102, 13)
        Me.TxtCurrentbalance.TabIndex = 5
        Me.TxtCurrentbalance.Text = "Current Balance:"
        '
        'TxtDrCr
        '
        Me.TxtDrCr.AllowEmpty = False
        Me.TxtDrCr.AllowOnlyListValues = True
        Me.TxtDrCr.AllowToolTip = True
        Me.TxtDrCr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtDrCr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtDrCr.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtDrCr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtDrCr.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TxtDrCr.FormattingEnabled = True
        Me.TxtDrCr.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDrCr.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDrCr.IsAdvanceSearchWindow = False
        Me.TxtDrCr.IsAllowDigits = True
        Me.TxtDrCr.IsAllowSpace = True
        Me.TxtDrCr.IsAllowSplChars = True
        Me.TxtDrCr.IsAllowToolTip = True
        Me.TxtDrCr.Items.AddRange(New Object() {"Cr", "Dr"})
        Me.TxtDrCr.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDrCr.Location = New System.Drawing.Point(3, 3)
        Me.TxtDrCr.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDrCr.Name = "TxtDrCr"
        Me.TxtDrCr.SetToolTip = Nothing
        Me.TxtDrCr.Size = New System.Drawing.Size(44, 21)
        Me.TxtDrCr.Sorted = True
        Me.TxtDrCr.SpecialCharList = "&-/@"
        Me.TxtDrCr.TabIndex = 0
        Me.TxtDrCr.UseFunctionKeys = False
        '
        'TxtAmount
        '
        Me.TxtAmount.AllHelpText = True
        Me.TxtAmount.AllowDecimal = True
        Me.TxtAmount.AllowFormulas = False
        Me.TxtAmount.AllowForQty = True
        Me.TxtAmount.AllowNegative = False
        Me.TxtAmount.AllowPerSign = False
        Me.TxtAmount.AllowPlusSign = False
        Me.TxtAmount.AllowToolTip = True
        Me.TxtAmount.DecimalPlaces = CType(3, Short)
        Me.TxtAmount.ExitOnEscKey = True
        Me.TxtAmount.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtAmount.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtAmount.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtAmount.HelpText = Nothing
        Me.TxtAmount.LFocusBackColor = System.Drawing.Color.White
        Me.TxtAmount.Location = New System.Drawing.Point(262, 3)
        Me.TxtAmount.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtAmount.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtAmount.Max = CType(100000000000000, Long)
        Me.TxtAmount.MaxLength = 12
        Me.TxtAmount.Min = CType(0, Long)
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.NextOnEnter = True
        Me.TxtAmount.SetToolTip = Nothing
        Me.TxtAmount.Size = New System.Drawing.Size(100, 20)
        Me.TxtAmount.TabIndex = 3
        Me.TxtAmount.Text = "0"
        Me.TxtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtAmount.ToolTip = Nothing
        Me.TxtAmount.UseFunctionKeys = False
        Me.TxtAmount.UseUpDownArrowKeys = False
        '
        'TxtNarration
        '
        Me.TxtNarration.AllowToolTip = True
        Me.TxtNarration.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtNarration.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtNarration.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNarration.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNarration.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtNarration.IsAllowDigits = True
        Me.TxtNarration.IsAllowSpace = True
        Me.TxtNarration.IsAllowSplChars = True
        Me.TxtNarration.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNarration.Location = New System.Drawing.Point(262, 3)
        Me.TxtNarration.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNarration.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtNarration.MaxLength = 120
        Me.TxtNarration.Name = "TxtNarration"
        Me.TxtNarration.SetToolTip = Nothing
        Me.TxtNarration.Size = New System.Drawing.Size(1, 20)
        Me.TxtNarration.SpecialCharList = "&-/@"
        Me.TxtNarration.TabIndex = 2
        Me.TxtNarration.UseFunctionKeys = False
        Me.TxtNarration.Visible = False
        '
        'TxtCurRate
        '
        Me.TxtCurRate.AllHelpText = True
        Me.TxtCurRate.AllowDecimal = False
        Me.TxtCurRate.AllowFormulas = False
        Me.TxtCurRate.AllowForQty = True
        Me.TxtCurRate.AllowNegative = False
        Me.TxtCurRate.AllowPerSign = False
        Me.TxtCurRate.AllowPlusSign = False
        Me.TxtCurRate.AllowToolTip = True
        Me.TxtCurRate.DecimalPlaces = CType(3, Short)
        Me.TxtCurRate.ExitOnEscKey = True
        Me.TxtCurRate.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCurRate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCurRate.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtCurRate.HelpText = Nothing
        Me.TxtCurRate.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCurRate.Location = New System.Drawing.Point(262, 28)
        Me.TxtCurRate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCurRate.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtCurRate.Max = CType(100000000000000, Long)
        Me.TxtCurRate.MaxLength = 12
        Me.TxtCurRate.Min = CType(0, Long)
        Me.TxtCurRate.Name = "TxtCurRate"
        Me.TxtCurRate.NextOnEnter = True
        Me.TxtCurRate.SetToolTip = Nothing
        Me.TxtCurRate.Size = New System.Drawing.Size(100, 20)
        Me.TxtCurRate.TabIndex = 6
        Me.TxtCurRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtCurRate.ToolTip = Nothing
        Me.TxtCurRate.UseFunctionKeys = False
        Me.TxtCurRate.UseUpDownArrowKeys = False
        Me.TxtCurRate.Visible = False
        '
        'PayRollVoucherRow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "PayRollVoucherRow"
        Me.Size = New System.Drawing.Size(433, 46)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtLedgerName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtAmount As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtCurrentbalance As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtDrCr As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtCurRate As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtNarration As JyothiPharmaERPSystem3.IMSTextBox

End Class
