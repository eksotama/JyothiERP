<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CostCenterRow
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
        Me.TxtValue = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtCostName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtValue, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtCostName, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(411, 22)
        Me.TableLayoutPanel1.TabIndex = 0
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
        Me.TxtValue.DecimalPlaces = CType(3, Short)
        Me.TxtValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtValue.ExitOnEscKey = True
        Me.TxtValue.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtValue.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtValue.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtValue.HelpText = Nothing
        Me.TxtValue.LFocusBackColor = System.Drawing.Color.White
        Me.TxtValue.Location = New System.Drawing.Point(288, 1)
        Me.TxtValue.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtValue.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtValue.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtValue.Max = CType(100000000000, Long)
        Me.TxtValue.MaxLength = 12
        Me.TxtValue.Min = CType(0, Long)
        Me.TxtValue.Name = "TxtValue"
        Me.TxtValue.NextOnEnter = True
        Me.TxtValue.SetToolTip = Nothing
        Me.TxtValue.Size = New System.Drawing.Size(122, 20)
        Me.TxtValue.TabIndex = 1
        Me.TxtValue.Text = "0"
        Me.TxtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtValue.ToolTip = Nothing
        Me.TxtValue.UseFunctionKeys = False
        Me.TxtValue.UseUpDownArrowKeys = False
        '
        'TxtCostName
        '
        Me.TxtCostName.AllowEmpty = False
        Me.TxtCostName.AllowOnlyListValues = True
        Me.TxtCostName.AllowToolTip = True
        Me.TxtCostName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtCostName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtCostName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtCostName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtCostName.FormattingEnabled = True
        Me.TxtCostName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCostName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCostName.IsAllowDigits = True
        Me.TxtCostName.IsAllowSpace = True
        Me.TxtCostName.IsAllowSplChars = True
        Me.TxtCostName.IsAllowToolTip = True
        Me.TxtCostName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCostName.Location = New System.Drawing.Point(1, 1)
        Me.TxtCostName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCostName.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtCostName.Name = "TxtCostName"
        Me.TxtCostName.SetToolTip = Nothing
        Me.TxtCostName.Size = New System.Drawing.Size(285, 21)
        Me.TxtCostName.Sorted = True
        Me.TxtCostName.SpecialCharList = "&-/@"
        Me.TxtCostName.TabIndex = 0
        Me.TxtCostName.UseFunctionKeys = False
        '
        'CostCenterRow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "CostCenterRow"
        Me.Size = New System.Drawing.Size(411, 22)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtValue As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtCostName As JyothiPharmaERPSystem3.IMSComboBox

End Class
