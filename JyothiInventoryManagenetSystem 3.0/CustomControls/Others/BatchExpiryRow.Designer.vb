<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BatchExpiryRow
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtStockRate = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtBatchNo = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtExpiry = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtQty = New JyothiPharmaERPSystem3.IMSQTYE()
        Me.TxtLocation = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtTotalValue = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtBatchList = New JyothiPharmaERPSystem3.IMSList()
        Me.tlocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbatchno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.texpiry = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tqtytext = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tmrp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ttotalqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toldbatchno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tmainunitqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsubunitqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.TxtBatchList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.70849!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.29151!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtStockRate, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtBatchNo, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtExpiry, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtQty, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtLocation, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtTotalValue, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtBatchList, 7, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(558, 27)
        Me.TableLayoutPanel1.TabIndex = 3
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
        Me.TxtStockRate.DecimalPlaces = CType(3, Short)
        Me.TxtStockRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStockRate.ExitOnEscKey = True
        Me.TxtStockRate.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockRate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockRate.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtStockRate.HelpText = Nothing
        Me.TxtStockRate.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockRate.Location = New System.Drawing.Point(265, 3)
        Me.TxtStockRate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockRate.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtStockRate.Max = CType(100000000000, Long)
        Me.TxtStockRate.MaxLength = 12
        Me.TxtStockRate.Min = CType(0, Long)
        Me.TxtStockRate.Name = "TxtStockRate"
        Me.TxtStockRate.NextOnEnter = True
        Me.TxtStockRate.SetToolTip = Nothing
        Me.TxtStockRate.Size = New System.Drawing.Size(105, 20)
        Me.TxtStockRate.TabIndex = 6
        Me.TxtStockRate.Text = "0"
        Me.TxtStockRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtStockRate.ToolTip = Nothing
        Me.TxtStockRate.UseFunctionKeys = False
        Me.TxtStockRate.UseUpDownArrowKeys = False
        '
        'TxtBatchNo
        '
        Me.TxtBatchNo.AllowToolTip = True
        Me.TxtBatchNo.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtBatchNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtBatchNo.Enabled = False
        Me.TxtBatchNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtBatchNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtBatchNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtBatchNo.IsAllowDigits = True
        Me.TxtBatchNo.IsAllowSpace = True
        Me.TxtBatchNo.IsAllowSplChars = True
        Me.TxtBatchNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtBatchNo.Location = New System.Drawing.Point(131, 3)
        Me.TxtBatchNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtBatchNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtBatchNo.MaxLength = 45
        Me.TxtBatchNo.Name = "TxtBatchNo"
        Me.TxtBatchNo.SetToolTip = Nothing
        Me.TxtBatchNo.Size = New System.Drawing.Size(1, 20)
        Me.TxtBatchNo.SpecialCharList = "&-/@"
        Me.TxtBatchNo.TabIndex = 1
        Me.TxtBatchNo.UseFunctionKeys = False
        '
        'TxtExpiry
        '
        Me.TxtExpiry.CustomFormat = "MM/yyyy"
        Me.TxtExpiry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtExpiry.Enabled = False
        Me.TxtExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtExpiry.Location = New System.Drawing.Point(131, 3)
        Me.TxtExpiry.Name = "TxtExpiry"
        Me.TxtExpiry.Size = New System.Drawing.Size(1, 20)
        Me.TxtExpiry.TabIndex = 2
        Me.TxtExpiry.Value = New Date(2013, 3, 1, 0, 0, 0, 0)
        '
        'TxtQty
        '
        Me.TxtQty.AutoSize = True
        Me.TxtQty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtQty.Location = New System.Drawing.Point(131, 3)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(128, 21)
        Me.TxtQty.TabIndex = 3
        Me.TxtQty.VisibleLabels = True
        '
        'TxtLocation
        '
        Me.TxtLocation.AllowEmpty = False
        Me.TxtLocation.AllowOnlyListValues = True
        Me.TxtLocation.AllowToolTip = True
        Me.TxtLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtLocation.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtLocation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.TxtLocation.Enabled = False
        Me.TxtLocation.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TxtLocation.FormattingEnabled = True
        Me.TxtLocation.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLocation.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLocation.IsAdvanceSearchWindow = False
        Me.TxtLocation.IsAllowDigits = True
        Me.TxtLocation.IsAllowSpace = False
        Me.TxtLocation.IsAllowSplChars = True
        Me.TxtLocation.IsAllowToolTip = True
        Me.TxtLocation.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLocation.Location = New System.Drawing.Point(3, 3)
        Me.TxtLocation.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLocation.Name = "TxtLocation"
        Me.TxtLocation.SetToolTip = Nothing
        Me.TxtLocation.Size = New System.Drawing.Size(122, 21)
        Me.TxtLocation.Sorted = True
        Me.TxtLocation.SpecialCharList = "&-/@"
        Me.TxtLocation.TabIndex = 0
        Me.TxtLocation.UseFunctionKeys = False
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
        Me.TxtTotalValue.DecimalPlaces = CType(3, Short)
        Me.TxtTotalValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTotalValue.Enabled = False
        Me.TxtTotalValue.ExitOnEscKey = True
        Me.TxtTotalValue.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTotalValue.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTotalValue.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtTotalValue.HelpText = Nothing
        Me.TxtTotalValue.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTotalValue.Location = New System.Drawing.Point(376, 3)
        Me.TxtTotalValue.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTotalValue.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtTotalValue.Max = CType(100000000000, Long)
        Me.TxtTotalValue.MaxLength = 12
        Me.TxtTotalValue.Min = CType(0, Long)
        Me.TxtTotalValue.Name = "TxtTotalValue"
        Me.TxtTotalValue.NextOnEnter = True
        Me.TxtTotalValue.SetToolTip = Nothing
        Me.TxtTotalValue.Size = New System.Drawing.Size(83, 20)
        Me.TxtTotalValue.TabIndex = 6
        Me.TxtTotalValue.Text = "0"
        Me.TxtTotalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTotalValue.ToolTip = Nothing
        Me.TxtTotalValue.UseFunctionKeys = False
        Me.TxtTotalValue.UseUpDownArrowKeys = False
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.Location = New System.Drawing.Point(462, 0)
        Me.Button1.Margin = New System.Windows.Forms.Padding(0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 27)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Batch Nos"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtBatchList
        '
        Me.TxtBatchList.AllowUserToAddRows = False
        Me.TxtBatchList.AllowUserToDeleteRows = False
        Me.TxtBatchList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtBatchList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtBatchList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tlocation, Me.tbatchno, Me.texpiry, Me.Tqtytext, Me.tmrp, Me.trate, Me.tvalue, Me.ttotalqty, Me.toldbatchno, Me.tmainunitqty, Me.tsubunitqty})
        Me.TxtBatchList.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtBatchList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtBatchList.Enabled = False
        Me.TxtBatchList.Location = New System.Drawing.Point(551, 3)
        Me.TxtBatchList.Name = "TxtBatchList"
        Me.TxtBatchList.Size = New System.Drawing.Size(4, 20)
        Me.TxtBatchList.TabIndex = 21
        Me.TxtBatchList.Visible = False
        '
        'tlocation
        '
        Me.tlocation.HeaderText = "Location"
        Me.tlocation.Name = "tlocation"
        '
        'tbatchno
        '
        Me.tbatchno.HeaderText = "Batch No"
        Me.tbatchno.Name = "tbatchno"
        '
        'texpiry
        '
        Me.texpiry.HeaderText = "Expiry"
        Me.texpiry.Name = "texpiry"
        '
        'Tqtytext
        '
        Me.Tqtytext.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Tqtytext.HeaderText = "Qty"
        Me.Tqtytext.Name = "Tqtytext"
        Me.Tqtytext.Width = 80
        '
        'tmrp
        '
        Me.tmrp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tmrp.HeaderText = "MRP"
        Me.tmrp.Name = "tmrp"
        Me.tmrp.Width = 85
        '
        'trate
        '
        Me.trate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.trate.HeaderText = "Rate"
        Me.trate.Name = "trate"
        Me.trate.Width = 84
        '
        'tvalue
        '
        Me.tvalue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.tvalue.DefaultCellStyle = DataGridViewCellStyle1
        Me.tvalue.HeaderText = "Value"
        Me.tvalue.Name = "tvalue"
        Me.tvalue.Width = 85
        '
        'ttotalqty
        '
        Me.ttotalqty.HeaderText = "totalQty"
        Me.ttotalqty.Name = "ttotalqty"
        Me.ttotalqty.Visible = False
        '
        'toldbatchno
        '
        Me.toldbatchno.HeaderText = "OldBatchno"
        Me.toldbatchno.Name = "toldbatchno"
        Me.toldbatchno.Visible = False
        '
        'tmainunitqty
        '
        Me.tmainunitqty.HeaderText = "Column1"
        Me.tmainunitqty.Name = "tmainunitqty"
        Me.tmainunitqty.Visible = False
        '
        'tsubunitqty
        '
        Me.tsubunitqty.HeaderText = "Column1"
        Me.tsubunitqty.Name = "tsubunitqty"
        Me.tsubunitqty.Visible = False
        '
        'BatchExpiryRow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "BatchExpiryRow"
        Me.Size = New System.Drawing.Size(558, 27)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.TxtBatchList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtExpiry As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtQty As JyothiPharmaERPSystem3.IMSQTYE
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtBatchNo As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtLocation As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtStockRate As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtTotalValue As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtBatchList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents tlocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tbatchno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents texpiry As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tqtytext As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tmrp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents trate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ttotalqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents toldbatchno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tmainunitqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tsubunitqty As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
