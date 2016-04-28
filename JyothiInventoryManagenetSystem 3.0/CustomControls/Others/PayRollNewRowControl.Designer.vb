<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PayRollNewRowControl
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
        Me.TxtPayRollLedgerName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtValue = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtDrCr = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtBalanceVal = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 218.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtPayRollLedgerName, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtValue, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtDrCr, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtBalanceVal, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(668, 22)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'TxtPayRollLedgerName
        '
        Me.TxtPayRollLedgerName.AllowEmpty = False
        Me.TxtPayRollLedgerName.AllowOnlyListValues = True
        Me.TxtPayRollLedgerName.AllowToolTip = True
        Me.TxtPayRollLedgerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtPayRollLedgerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtPayRollLedgerName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtPayRollLedgerName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtPayRollLedgerName.FormattingEnabled = True
        Me.TxtPayRollLedgerName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPayRollLedgerName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPayRollLedgerName.IsAllowDigits = True
        Me.TxtPayRollLedgerName.IsAllowSpace = True
        Me.TxtPayRollLedgerName.IsAllowSplChars = True
        Me.TxtPayRollLedgerName.IsAllowToolTip = True
        Me.TxtPayRollLedgerName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPayRollLedgerName.Location = New System.Drawing.Point(1, 1)
        Me.TxtPayRollLedgerName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPayRollLedgerName.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtPayRollLedgerName.Name = "TxtPayRollLedgerName"
        Me.TxtPayRollLedgerName.SetToolTip = "Press Alt+C, To Create New "
        Me.TxtPayRollLedgerName.Size = New System.Drawing.Size(275, 21)
        Me.TxtPayRollLedgerName.Sorted = True
        Me.TxtPayRollLedgerName.SpecialCharList = "&-/@"
        Me.TxtPayRollLedgerName.TabIndex = 0
        Me.TxtPayRollLedgerName.UseFunctionKeys = False
        '
        'TxtValue
        '
        Me.TxtValue.AllHelpText = True
        Me.TxtValue.AllowDecimal = True
        Me.TxtValue.AllowFormulas = False
        Me.TxtValue.AllowForQty = True
        Me.TxtValue.AllowNegative = False
        Me.TxtValue.AllowPerSign = False
        Me.TxtValue.AllowPlusSign = False
        Me.TxtValue.AllowToolTip = True
        Me.TxtValue.DecimalPlaces = CType(ErpDecimalPlaces, Short)
        Me.TxtValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtValue.ExitOnEscKey = True
        Me.TxtValue.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtValue.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtValue.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtValue.HelpText = Nothing
        Me.TxtValue.LFocusBackColor = System.Drawing.Color.White
        Me.TxtValue.Location = New System.Drawing.Point(278, 1)
        Me.TxtValue.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtValue.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtValue.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtValue.Max = CType(100000000000, Long)
        Me.TxtValue.MaxLength = 12
        Me.TxtValue.Min = CType(0, Long)
        Me.TxtValue.Name = "TxtValue"
        Me.TxtValue.NextOnEnter = True
        Me.TxtValue.SetToolTip = Nothing
        Me.TxtValue.Size = New System.Drawing.Size(113, 20)
        Me.TxtValue.TabIndex = 1
        Me.TxtValue.Text = "0"
        Me.TxtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtValue.ToolTip = Nothing
        Me.TxtValue.UseFunctionKeys = False
        Me.TxtValue.UseUpDownArrowKeys = False
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
        Me.TxtDrCr.FormattingEnabled = True
        Me.TxtDrCr.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDrCr.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDrCr.IsAllowDigits = True
        Me.TxtDrCr.IsAllowSpace = True
        Me.TxtDrCr.IsAllowSplChars = True
        Me.TxtDrCr.IsAllowToolTip = True
        Me.TxtDrCr.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDrCr.Location = New System.Drawing.Point(392, 0)
        Me.TxtDrCr.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDrCr.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtDrCr.Name = "TxtDrCr"
        Me.TxtDrCr.SetToolTip = Nothing
        Me.TxtDrCr.Size = New System.Drawing.Size(58, 21)
        Me.TxtDrCr.Sorted = True
        Me.TxtDrCr.SpecialCharList = "&-/@"
        Me.TxtDrCr.TabIndex = 2
        Me.TxtDrCr.UseFunctionKeys = False
        '
        'TxtBalanceVal
        '
        Me.TxtBalanceVal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtBalanceVal.AutoSize = True
        Me.TxtBalanceVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBalanceVal.Location = New System.Drawing.Point(453, 0)
        Me.TxtBalanceVal.Name = "TxtBalanceVal"
        Me.TxtBalanceVal.Size = New System.Drawing.Size(14, 22)
        Me.TxtBalanceVal.TabIndex = 3
        Me.TxtBalanceVal.Text = "0"
        Me.TxtBalanceVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TxtBalanceVal.Visible = False
        '
        'PayRollNewRowControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "PayRollNewRowControl"
        Me.Size = New System.Drawing.Size(668, 22)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtValue As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtPayRollLedgerName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtDrCr As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtBalanceVal As JyothiPharmaERPSystem3.IMSlabel

End Class
