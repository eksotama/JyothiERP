<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReadOpBatchNoExpiry
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReadOpBatchNoExpiry))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtMRP = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtBatchNo = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtExpiry = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtQty = New JyothiPharmaERPSystem3.IMSQTYE()
        Me.TxtLocation = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtRate = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnCancel = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtList, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ImsHeadingLabel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(708, 379)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 41)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(708, 40)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 7
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.95088!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.73118!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.02151!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.36149!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TxtMRP, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtBatchNo, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtExpiry, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtQty, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtLocation, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtRate, 5, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ImSlabel1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ImSlabel2, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ImSlabel3, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ImSlabel4, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ImSlabel5, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ImSlabel6, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton1, 6, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(708, 40)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'TxtMRP
        '
        Me.TxtMRP.AllHelpText = True
        Me.TxtMRP.AllowDecimal = True
        Me.TxtMRP.AllowFormulas = False
        Me.TxtMRP.AllowForQty = True
        Me.TxtMRP.AllowNegative = False
        Me.TxtMRP.AllowPerSign = False
        Me.TxtMRP.AllowPlusSign = False
        Me.TxtMRP.AllowToolTip = True
        Me.TxtMRP.DecimalPlaces = CType(3, Short)
        Me.TxtMRP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtMRP.ExitOnEscKey = True
        Me.TxtMRP.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtMRP.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtMRP.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtMRP.HelpText = Nothing
        Me.TxtMRP.LFocusBackColor = System.Drawing.Color.White
        Me.TxtMRP.Location = New System.Drawing.Point(452, 16)
        Me.TxtMRP.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtMRP.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtMRP.Max = CType(100000000000, Long)
        Me.TxtMRP.MaxLength = 12
        Me.TxtMRP.Min = CType(0, Long)
        Me.TxtMRP.Name = "TxtMRP"
        Me.TxtMRP.NextOnEnter = True
        Me.TxtMRP.SetToolTip = Nothing
        Me.TxtMRP.Size = New System.Drawing.Size(82, 20)
        Me.TxtMRP.TabIndex = 4
        Me.TxtMRP.Text = "0"
        Me.TxtMRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtMRP.ToolTip = Nothing
        Me.TxtMRP.UseFunctionKeys = False
        Me.TxtMRP.UseUpDownArrowKeys = False
        '
        'TxtBatchNo
        '
        Me.TxtBatchNo.AllowToolTip = True
        Me.TxtBatchNo.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtBatchNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtBatchNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtBatchNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtBatchNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtBatchNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtBatchNo.IsAllowDigits = True
        Me.TxtBatchNo.IsAllowSpace = True
        Me.TxtBatchNo.IsAllowSplChars = True
        Me.TxtBatchNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtBatchNo.Location = New System.Drawing.Point(115, 16)
        Me.TxtBatchNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtBatchNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtBatchNo.MaxLength = 35
        Me.TxtBatchNo.Name = "TxtBatchNo"
        Me.TxtBatchNo.SetToolTip = Nothing
        Me.TxtBatchNo.Size = New System.Drawing.Size(105, 20)
        Me.TxtBatchNo.SpecialCharList = "&-/@"
        Me.TxtBatchNo.TabIndex = 1
        Me.TxtBatchNo.UseFunctionKeys = False
        '
        'TxtExpiry
        '
        Me.TxtExpiry.CustomFormat = ""
        Me.TxtExpiry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtExpiry.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtExpiry.Location = New System.Drawing.Point(226, 16)
        Me.TxtExpiry.Name = "TxtExpiry"
        Me.TxtExpiry.Size = New System.Drawing.Size(111, 20)
        Me.TxtExpiry.TabIndex = 2
        Me.TxtExpiry.Value = New Date(2013, 3, 1, 0, 0, 0, 0)
        '
        'TxtQty
        '
        Me.TxtQty.AutoSize = True
        Me.TxtQty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtQty.Location = New System.Drawing.Point(343, 16)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(103, 21)
        Me.TxtQty.TabIndex = 3
        Me.TxtQty.VisibleLabels = True
        '
        'TxtLocation
        '
        Me.TxtLocation.AllowEmpty = False
        Me.TxtLocation.AllowOnlyListValues = False
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
        Me.TxtLocation.Location = New System.Drawing.Point(3, 16)
        Me.TxtLocation.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLocation.Name = "TxtLocation"
        Me.TxtLocation.SetToolTip = Nothing
        Me.TxtLocation.Size = New System.Drawing.Size(106, 21)
        Me.TxtLocation.Sorted = True
        Me.TxtLocation.SpecialCharList = "&-/@"
        Me.TxtLocation.TabIndex = 0
        Me.TxtLocation.UseFunctionKeys = False
        '
        'TxtRate
        '
        Me.TxtRate.AllHelpText = True
        Me.TxtRate.AllowDecimal = True
        Me.TxtRate.AllowFormulas = False
        Me.TxtRate.AllowForQty = True
        Me.TxtRate.AllowNegative = False
        Me.TxtRate.AllowPerSign = False
        Me.TxtRate.AllowPlusSign = False
        Me.TxtRate.AllowToolTip = True
        Me.TxtRate.DecimalPlaces = CType(3, Short)
        Me.TxtRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtRate.ExitOnEscKey = True
        Me.TxtRate.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtRate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtRate.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtRate.HelpText = Nothing
        Me.TxtRate.LFocusBackColor = System.Drawing.Color.White
        Me.TxtRate.Location = New System.Drawing.Point(540, 16)
        Me.TxtRate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtRate.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtRate.Max = CType(100000000000, Long)
        Me.TxtRate.MaxLength = 12
        Me.TxtRate.Min = CType(0, Long)
        Me.TxtRate.Name = "TxtRate"
        Me.TxtRate.NextOnEnter = True
        Me.TxtRate.SetToolTip = Nothing
        Me.TxtRate.Size = New System.Drawing.Size(75, 20)
        Me.TxtRate.TabIndex = 5
        Me.TxtRate.Text = "0"
        Me.TxtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtRate.ToolTip = Nothing
        Me.TxtRate.UseFunctionKeys = False
        Me.TxtRate.UseUpDownArrowKeys = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(3, 0)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(56, 13)
        Me.ImSlabel1.TabIndex = 7
        Me.ImSlabel1.Text = "Location"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(115, 0)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(60, 13)
        Me.ImSlabel2.TabIndex = 7
        Me.ImSlabel2.Text = "Batch No"
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(226, 0)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(41, 13)
        Me.ImSlabel3.TabIndex = 7
        Me.ImSlabel3.Text = "Expiry"
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(343, 0)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(26, 13)
        Me.ImSlabel4.TabIndex = 7
        Me.ImSlabel4.Text = "Qty"
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(452, 0)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(34, 13)
        Me.ImSlabel5.TabIndex = 7
        Me.ImSlabel5.Text = "MRP"
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(540, 0)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(34, 13)
        Me.ImSlabel6.TabIndex = 7
        Me.ImSlabel6.Text = "Rate"
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.BackColor = System.Drawing.Color.White
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = CType(resources.GetObject("ImsButton1.Image"), System.Drawing.Image)
        Me.ImsButton1.Location = New System.Drawing.Point(621, 3)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.TableLayoutPanel2.SetRowSpan(Me.ImsButton1, 2)
        Me.ImsButton1.SetToolTip = "Add to List "
        Me.ImsButton1.Size = New System.Drawing.Size(47, 34)
        Me.ImsButton1.TabIndex = 6
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = False
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tlocation, Me.tbatchno, Me.texpiry, Me.Tqtytext, Me.tmrp, Me.trate, Me.tvalue, Me.ttotalqty, Me.toldbatchno, Me.tmainunitqty, Me.tsubunitqty})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtList.DefaultCellStyle = DataGridViewCellStyle8
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.Location = New System.Drawing.Point(3, 84)
        Me.TxtList.Name = "TxtList"
        Me.TxtList.Size = New System.Drawing.Size(702, 233)
        Me.TxtList.TabIndex = 0
        '
        'tlocation
        '
        Me.tlocation.HeaderText = "Location"
        Me.tlocation.Name = "tlocation"
        Me.tlocation.ReadOnly = True
        '
        'tbatchno
        '
        Me.tbatchno.HeaderText = "Batch No"
        Me.tbatchno.Name = "tbatchno"
        '
        'texpiry
        '
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.texpiry.DefaultCellStyle = DataGridViewCellStyle6
        Me.texpiry.HeaderText = "Expiry"
        Me.texpiry.Name = "texpiry"
        Me.texpiry.ReadOnly = True
        '
        'Tqtytext
        '
        Me.Tqtytext.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Tqtytext.HeaderText = "Qty"
        Me.Tqtytext.Name = "Tqtytext"
        Me.Tqtytext.ReadOnly = True
        Me.Tqtytext.Width = 80
        '
        'tmrp
        '
        Me.tmrp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tmrp.HeaderText = "MRP"
        Me.tmrp.Name = "tmrp"
        Me.tmrp.ReadOnly = True
        Me.tmrp.Width = 85
        '
        'trate
        '
        Me.trate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.trate.HeaderText = "Rate"
        Me.trate.Name = "trate"
        Me.trate.ReadOnly = True
        Me.trate.Width = 84
        '
        'tvalue
        '
        Me.tvalue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.tvalue.DefaultCellStyle = DataGridViewCellStyle7
        Me.tvalue.HeaderText = "Value"
        Me.tvalue.Name = "tvalue"
        Me.tvalue.ReadOnly = True
        Me.tvalue.Width = 85
        '
        'ttotalqty
        '
        Me.ttotalqty.HeaderText = "totalQty"
        Me.ttotalqty.Name = "ttotalqty"
        Me.ttotalqty.ReadOnly = True
        Me.ttotalqty.Visible = False
        '
        'toldbatchno
        '
        Me.toldbatchno.HeaderText = "OldBatchno"
        Me.toldbatchno.Name = "toldbatchno"
        Me.toldbatchno.ReadOnly = True
        Me.toldbatchno.Visible = False
        '
        'tmainunitqty
        '
        Me.tmainunitqty.HeaderText = "Column1"
        Me.tmainunitqty.Name = "tmainunitqty"
        Me.tmainunitqty.ReadOnly = True
        Me.tmainunitqty.Visible = False
        '
        'tsubunitqty
        '
        Me.tsubunitqty.HeaderText = "Column1"
        Me.tsubunitqty.Name = "tsubunitqty"
        Me.tsubunitqty.ReadOnly = True
        Me.tsubunitqty.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnCancel)
        Me.Panel2.Controls.Add(Me.ImsButton2)
        Me.Panel2.Controls.Add(Me.ImSlabel7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 320)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(708, 59)
        Me.Panel2.TabIndex = 2
        '
        'BtnCancel
        '
        Me.BtnCancel.AllowToolTip = True
        Me.BtnCancel.BackColor = System.Drawing.Color.White
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(125, 14)
        Me.BtnCancel.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.SetToolTip = ""
        Me.BtnCancel.Size = New System.Drawing.Size(125, 39)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseFunctionKeys = False
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'ImsButton2
        '
        Me.ImsButton2.AllowToolTip = True
        Me.ImsButton2.BackColor = System.Drawing.Color.White
        Me.ImsButton2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton2.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.success32
        Me.ImsButton2.Location = New System.Drawing.Point(478, 14)
        Me.ImsButton2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton2.Name = "ImsButton2"
        Me.ImsButton2.SetToolTip = ""
        Me.ImsButton2.Size = New System.Drawing.Size(113, 39)
        Me.ImsButton2.TabIndex = 0
        Me.ImsButton2.Text = "Accept"
        Me.ImsButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton2.UseFunctionKeys = False
        Me.ImsButton2.UseVisualStyleBackColor = False
        '
        'ImSlabel7
        '
        Me.ImSlabel7.AutoSize = True
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(1, 0)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(294, 13)
        Me.ImSlabel7.TabIndex = 7
        Me.ImSlabel7.Text = "To Delete A Row: Select the Row and then Delete"
        '
        'ImsHeadingLabel1
        '
        Me.ImsHeadingLabel1.AutoSize = True
        Me.ImsHeadingLabel1.BackColor = System.Drawing.Color.DarkOrange
        Me.ImsHeadingLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsHeadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsHeadingLabel1.ForeColor = System.Drawing.Color.White
        Me.ImsHeadingLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ImsHeadingLabel1.Margin = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.ImsHeadingLabel1.Name = "ImsHeadingLabel1"
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(708, 31)
        Me.ImsHeadingLabel1.TabIndex = 3
        Me.ImsHeadingLabel1.Text = "BATCH NUMBER AND EXPIRY ALLOCATION"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ReadOpBatchNoExpiry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(708, 379)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReadOpBatchNoExpiry"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Openining Stock Details -Batch Number Wise"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtMRP As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtBatchNo As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtExpiry As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtQty As JyothiPharmaERPSystem3.IMSQTYE
    Friend WithEvents TxtLocation As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtRate As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnCancel As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton2 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
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
