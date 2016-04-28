<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BatchExpQtyRowCtrol
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
        Me.TxtQty = New JyothiPharmaERPSystem3.IMSQTYE()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtStockRate = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtBatchNo = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtExpiry = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtTotalValue = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtQty
        '
        Me.TxtQty.AutoSize = True
        Me.TxtQty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtQty.Location = New System.Drawing.Point(259, 3)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(154, 21)
        Me.TxtQty.TabIndex = 2
        Me.TxtQty.VisibleLabels = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtStockRate, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtBatchNo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtExpiry, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtQty, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtTotalValue, 4, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(618, 27)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'TxtStockRate
        '
        Me.TxtStockRate.AllHelpText = True
        Me.TxtStockRate.AllowDecimal = True
        Me.TxtStockRate.AllowFormulas = False
        Me.TxtStockRate.AllowForQty = True
        Me.TxtStockRate.AllowNegative = False
        Me.TxtStockRate.AllowPerSign = False
        Me.TxtStockRate.AllowPlusSign = False
        Me.TxtStockRate.AllowToolTip = True
        Me.TxtStockRate.DecimalPlaces = CType(2, Short)
        Me.TxtStockRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStockRate.ExitOnEscKey = True
        Me.TxtStockRate.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockRate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockRate.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtStockRate.HelpText = Nothing
        Me.TxtStockRate.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockRate.Location = New System.Drawing.Point(419, 3)
        Me.TxtStockRate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockRate.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtStockRate.Max = CType(100000000000, Long)
        Me.TxtStockRate.MaxLength = 12
        Me.TxtStockRate.Min = CType(0, Long)
        Me.TxtStockRate.Name = "TxtStockRate"
        Me.TxtStockRate.NextOnEnter = True
        Me.TxtStockRate.SetToolTip = Nothing
        Me.TxtStockRate.Size = New System.Drawing.Size(94, 20)
        Me.TxtStockRate.TabIndex = 3
        Me.TxtStockRate.Text = "0"
        Me.TxtStockRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtStockRate.ToolTip = Nothing
        Me.TxtStockRate.UseFunctionKeys = False
        Me.TxtStockRate.UseUpDownArrowKeys = False
        '
        'TxtBatchNo
        '
        Me.TxtBatchNo.AllowToolTip = True
        Me.TxtBatchNo.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtBatchNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtBatchNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtBatchNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtBatchNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtBatchNo.IsAllowDigits = True
        Me.TxtBatchNo.IsAllowSpace = True
        Me.TxtBatchNo.IsAllowSplChars = True
        Me.TxtBatchNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtBatchNo.Location = New System.Drawing.Point(3, 3)
        Me.TxtBatchNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtBatchNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtBatchNo.MaxLength = 35
        Me.TxtBatchNo.Name = "TxtBatchNo"
        Me.TxtBatchNo.SetToolTip = Nothing
        Me.TxtBatchNo.Size = New System.Drawing.Size(139, 20)
        Me.TxtBatchNo.SpecialCharList = "&-/@"
        Me.TxtBatchNo.TabIndex = 0
        Me.TxtBatchNo.UseFunctionKeys = False
        '
        'TxtExpiry
        '
        Me.TxtExpiry.CustomFormat = ""
        Me.TxtExpiry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtExpiry.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtExpiry.Location = New System.Drawing.Point(148, 3)
        Me.TxtExpiry.Name = "TxtExpiry"
        Me.TxtExpiry.Size = New System.Drawing.Size(105, 20)
        Me.TxtExpiry.TabIndex = 1
        Me.TxtExpiry.Value = New Date(2013, 3, 1, 0, 0, 0, 0)
        '
        'TxtTotalValue
        '
        Me.TxtTotalValue.AllHelpText = True
        Me.TxtTotalValue.AllowDecimal = False
        Me.TxtTotalValue.AllowFormulas = False
        Me.TxtTotalValue.AllowForQty = True
        Me.TxtTotalValue.AllowNegative = False
        Me.TxtTotalValue.AllowPerSign = False
        Me.TxtTotalValue.AllowPlusSign = False
        Me.TxtTotalValue.AllowToolTip = True
        Me.TxtTotalValue.DecimalPlaces = CType(2, Short)
        Me.TxtTotalValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTotalValue.Enabled = False
        Me.TxtTotalValue.ExitOnEscKey = True
        Me.TxtTotalValue.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTotalValue.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTotalValue.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtTotalValue.HelpText = Nothing
        Me.TxtTotalValue.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTotalValue.Location = New System.Drawing.Point(519, 3)
        Me.TxtTotalValue.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTotalValue.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtTotalValue.Max = CType(100000000000, Long)
        Me.TxtTotalValue.MaxLength = 12
        Me.TxtTotalValue.Min = CType(0, Long)
        Me.TxtTotalValue.Name = "TxtTotalValue"
        Me.TxtTotalValue.NextOnEnter = True
        Me.TxtTotalValue.SetToolTip = Nothing
        Me.TxtTotalValue.Size = New System.Drawing.Size(96, 20)
        Me.TxtTotalValue.TabIndex = 4
        Me.TxtTotalValue.Text = "0"
        Me.TxtTotalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTotalValue.ToolTip = Nothing
        Me.TxtTotalValue.UseFunctionKeys = False
        Me.TxtTotalValue.UseUpDownArrowKeys = False
        '
        'BatchExpQtyRowCtrol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "BatchExpQtyRowCtrol"
        Me.Size = New System.Drawing.Size(618, 27)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtQty As JyothiPharmaERPSystem3.IMSQTYE
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtStockRate As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtBatchNo As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtExpiry As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtTotalValue As JyothiPharmaERPSystem3.IMSNumericTextBox

End Class
