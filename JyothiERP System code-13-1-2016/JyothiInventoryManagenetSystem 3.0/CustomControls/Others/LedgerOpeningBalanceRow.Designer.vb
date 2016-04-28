<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LedgerOpeningBalanceRow
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
        Me.TxtDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtRefNo = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtVoucher = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtDr = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtCr = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.65217!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.78261!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.91961!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.29549!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.29549!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtDate, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtRefNo, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtVoucher, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtDr, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtCr, 4, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(1)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(575, 26)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TxtDate
        '
        Me.TxtDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtDate.Location = New System.Drawing.Point(3, 3)
        Me.TxtDate.Name = "TxtDate"
        Me.TxtDate.Size = New System.Drawing.Size(84, 20)
        Me.TxtDate.TabIndex = 0
        '
        'TxtRefNo
        '
        Me.TxtRefNo.AllowToolTip = True
        Me.TxtRefNo.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtRefNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtRefNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtRefNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtRefNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtRefNo.IsAllowDigits = True
        Me.TxtRefNo.IsAllowSpace = True
        Me.TxtRefNo.IsAllowSplChars = True
        Me.TxtRefNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtRefNo.Location = New System.Drawing.Point(93, 3)
        Me.TxtRefNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtRefNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtRefNo.MaxLength = 45
        Me.TxtRefNo.Name = "TxtRefNo"
        Me.TxtRefNo.SetToolTip = Nothing
        Me.TxtRefNo.Size = New System.Drawing.Size(148, 20)
        Me.TxtRefNo.SpecialCharList = "&-/@"
        Me.TxtRefNo.TabIndex = 1
        Me.TxtRefNo.UseFunctionKeys = False
        '
        'TxtVoucher
        '
        Me.TxtVoucher.AllowToolTip = True
        Me.TxtVoucher.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtVoucher.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtVoucher.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtVoucher.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtVoucher.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtVoucher.IsAllowDigits = True
        Me.TxtVoucher.IsAllowSpace = True
        Me.TxtVoucher.IsAllowSplChars = True
        Me.TxtVoucher.LFocusBackColor = System.Drawing.Color.White
        Me.TxtVoucher.Location = New System.Drawing.Point(247, 3)
        Me.TxtVoucher.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtVoucher.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtVoucher.MaxLength = 40
        Me.TxtVoucher.Name = "TxtVoucher"
        Me.TxtVoucher.SetToolTip = Nothing
        Me.TxtVoucher.Size = New System.Drawing.Size(125, 20)
        Me.TxtVoucher.SpecialCharList = "&-/@"
        Me.TxtVoucher.TabIndex = 2
        Me.TxtVoucher.UseFunctionKeys = False
        '
        'TxtDr
        '
        Me.TxtDr.AllHelpText = True
        Me.TxtDr.AllowDecimal = True
        Me.TxtDr.AllowFormulas = False
        Me.TxtDr.AllowForQty = True
        Me.TxtDr.AllowNegative = False
        Me.TxtDr.AllowPerSign = False
        Me.TxtDr.AllowPlusSign = False
        Me.TxtDr.AllowToolTip = True
        Me.TxtDr.DecimalPlaces = CType(3, Short)
        Me.TxtDr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtDr.ExitOnEscKey = True
        Me.TxtDr.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDr.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDr.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtDr.HelpText = Nothing
        Me.TxtDr.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDr.Location = New System.Drawing.Point(378, 3)
        Me.TxtDr.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDr.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtDr.Max = CType(100000000000000, Long)
        Me.TxtDr.MaxLength = 12
        Me.TxtDr.Min = CType(0, Long)
        Me.TxtDr.Name = "TxtDr"
        Me.TxtDr.NextOnEnter = True
        Me.TxtDr.SetToolTip = Nothing
        Me.TxtDr.Size = New System.Drawing.Size(93, 20)
        Me.TxtDr.TabIndex = 3
        Me.TxtDr.Text = "0"
        Me.TxtDr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtDr.ToolTip = Nothing
        Me.TxtDr.UseFunctionKeys = False
        Me.TxtDr.UseUpDownArrowKeys = False
        '
        'TxtCr
        '
        Me.TxtCr.AllHelpText = True
        Me.TxtCr.AllowDecimal = True
        Me.TxtCr.AllowFormulas = False
        Me.TxtCr.AllowForQty = True
        Me.TxtCr.AllowNegative = False
        Me.TxtCr.AllowPerSign = False
        Me.TxtCr.AllowPlusSign = False
        Me.TxtCr.AllowToolTip = True
        Me.TxtCr.DecimalPlaces = CType(3, Short)
        Me.TxtCr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtCr.ExitOnEscKey = True
        Me.TxtCr.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCr.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCr.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtCr.HelpText = Nothing
        Me.TxtCr.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCr.Location = New System.Drawing.Point(477, 3)
        Me.TxtCr.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCr.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtCr.Max = CType(100000000000000, Long)
        Me.TxtCr.MaxLength = 12
        Me.TxtCr.Min = CType(0, Long)
        Me.TxtCr.Name = "TxtCr"
        Me.TxtCr.NextOnEnter = True
        Me.TxtCr.SetToolTip = Nothing
        Me.TxtCr.Size = New System.Drawing.Size(95, 20)
        Me.TxtCr.TabIndex = 4
        Me.TxtCr.Text = "0"
        Me.TxtCr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtCr.ToolTip = Nothing
        Me.TxtCr.UseFunctionKeys = False
        Me.TxtCr.UseUpDownArrowKeys = False
        '
        'LedgerOpeningBalanceRow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "LedgerOpeningBalanceRow"
        Me.Size = New System.Drawing.Size(575, 26)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtRefNo As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtVoucher As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtDr As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtCr As JyothiPharmaERPSystem3.IMSNumericTextBox

End Class
