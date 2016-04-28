<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class payrollsubRow
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
        Me.TxtAmount = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtDrCr = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtCurRate = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.CostList = New JyothiPharmaERPSystem3.IMSList()
        Me.tcostname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tCostno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tamount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tmore = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtCurrentbalance = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.CostList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 285.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtLedgerName, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtAmount, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtDrCr, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtCurRate, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CostList, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtCurrentbalance, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(653, 28)
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
        Me.TxtLedgerName.IsAllowDigits = True
        Me.TxtLedgerName.IsAllowSpace = True
        Me.TxtLedgerName.IsAllowSplChars = True
        Me.TxtLedgerName.IsAllowToolTip = True
        Me.TxtLedgerName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLedgerName.Location = New System.Drawing.Point(58, 3)
        Me.TxtLedgerName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLedgerName.Name = "TxtLedgerName"
        Me.TxtLedgerName.SetToolTip = "Press Alt+C, To Create New "
        Me.TxtLedgerName.Size = New System.Drawing.Size(279, 21)
        Me.TxtLedgerName.Sorted = True
        Me.TxtLedgerName.SpecialCharList = "&-/@"
        Me.TxtLedgerName.TabIndex = 1
        Me.TxtLedgerName.UseFunctionKeys = False
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
        Me.TxtAmount.DecimalPlaces = CType(ErpDecimalPlaces, Short)
        Me.TxtAmount.ExitOnEscKey = True
        Me.TxtAmount.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtAmount.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtAmount.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAmount.HelpText = Nothing
        Me.TxtAmount.LFocusBackColor = System.Drawing.Color.White
        Me.TxtAmount.Location = New System.Drawing.Point(343, 3)
        Me.TxtAmount.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtAmount.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtAmount.Max = CType(100000000000000, Long)
        Me.TxtAmount.MaxLength = 12
        Me.TxtAmount.Min = CType(0, Long)
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.NextOnEnter = True
        Me.TxtAmount.SetToolTip = Nothing
        Me.TxtAmount.Size = New System.Drawing.Size(100, 20)
        Me.TxtAmount.TabIndex = 2
        Me.TxtAmount.Text = "0"
        Me.TxtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtAmount.ToolTip = Nothing
        Me.TxtAmount.UseFunctionKeys = False
        Me.TxtAmount.UseUpDownArrowKeys = False
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
        Me.TxtDrCr.Size = New System.Drawing.Size(49, 21)
        Me.TxtDrCr.Sorted = True
        Me.TxtDrCr.SpecialCharList = "&-/@"
        Me.TxtDrCr.TabIndex = 0
        Me.TxtDrCr.UseFunctionKeys = False
        '
        'TxtCurRate
        '
        Me.TxtCurRate.AllHelpText = True
        Me.TxtCurRate.AllowDecimal = True
        Me.TxtCurRate.AllowFormulas = False
        Me.TxtCurRate.AllowForQty = True
        Me.TxtCurRate.AllowNegative = False
        Me.TxtCurRate.AllowPerSign = False
        Me.TxtCurRate.AllowPlusSign = False
        Me.TxtCurRate.AllowToolTip = True
        Me.TxtCurRate.DecimalPlaces = CType(5, Short)
        Me.TxtCurRate.ExitOnEscKey = True
        Me.TxtCurRate.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCurRate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCurRate.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtCurRate.HelpText = Nothing
        Me.TxtCurRate.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCurRate.Location = New System.Drawing.Point(343, 28)
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
        Me.TxtCurRate.Text = "1"
        Me.TxtCurRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtCurRate.ToolTip = Nothing
        Me.TxtCurRate.UseFunctionKeys = False
        Me.TxtCurRate.UseUpDownArrowKeys = False
        Me.TxtCurRate.Visible = False
        '
        'CostList
        '
        Me.CostList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CostList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tcostname, Me.tCostno, Me.tsno, Me.tamount, Me.tmore})
        Me.CostList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.CostList.Location = New System.Drawing.Point(3, 28)
        Me.CostList.Name = "CostList"
        Me.CostList.Size = New System.Drawing.Size(44, 1)
        Me.CostList.TabIndex = 7
        Me.CostList.Visible = False
        '
        'tcostname
        '
        Me.tcostname.HeaderText = "CostName"
        Me.tcostname.Name = "tcostname"
        '
        'tCostno
        '
        Me.tCostno.HeaderText = "CostNo"
        Me.tCostno.Name = "tCostno"
        '
        'tsno
        '
        Me.tsno.HeaderText = "Sno"
        Me.tsno.Name = "tsno"
        '
        'tamount
        '
        Me.tamount.HeaderText = "Amount"
        Me.tamount.Name = "tamount"
        '
        'tmore
        '
        Me.tmore.HeaderText = "More"
        Me.tmore.Name = "tmore"
        '
        'TxtCurrentbalance
        '
        Me.TxtCurrentbalance.AutoSize = True
        Me.TxtCurrentbalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCurrentbalance.Location = New System.Drawing.Point(494, 0)
        Me.TxtCurrentbalance.Name = "TxtCurrentbalance"
        Me.TxtCurrentbalance.Size = New System.Drawing.Size(102, 13)
        Me.TxtCurrentbalance.TabIndex = 5
        Me.TxtCurrentbalance.Text = "Current Balance:"
        '
        'payrollsubRow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "payrollsubRow"
        Me.Size = New System.Drawing.Size(653, 28)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.CostList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtLedgerName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtAmount As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtDrCr As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtCurRate As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents CostList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents tcostname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tCostno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tsno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tamount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tmore As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtCurrentbalance As JyothiPharmaERPSystem3.IMSlabel

End Class
