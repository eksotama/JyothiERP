<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BillwiseDetailsEntryForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillwiseDetailsEntryForm))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtPaidList = New JyothiPharmaERPSystem3.IMSList()
        Me.ttype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tref = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tamt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.TxtHeading = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnAdd = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtAmount = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtRefNo = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtRefType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ImsButton2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton3 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.TxtPaidList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtPaidList, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtList, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtHeading, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 5)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(845, 527)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TxtPaidList
        '
        Me.TxtPaidList.AllowUserToAddRows = False
        Me.TxtPaidList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPaidList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.TxtPaidList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TxtPaidList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.TxtPaidList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtPaidList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ttype, Me.tcode, Me.tref, Me.tamt})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtPaidList.DefaultCellStyle = DataGridViewCellStyle3
        Me.TxtPaidList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtPaidList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtPaidList.Location = New System.Drawing.Point(3, 262)
        Me.TxtPaidList.MultiSelect = False
        Me.TxtPaidList.Name = "TxtPaidList"
        Me.TxtPaidList.ReadOnly = True
        Me.TxtPaidList.RowHeadersWidth = 30
        Me.TxtPaidList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtPaidList.Size = New System.Drawing.Size(839, 167)
        Me.TxtPaidList.TabIndex = 3
        '
        'ttype
        '
        Me.ttype.HeaderText = "Bill Type"
        Me.ttype.Name = "ttype"
        Me.ttype.ReadOnly = True
        '
        'tcode
        '
        Me.tcode.HeaderText = "TransCode"
        Me.tcode.Name = "tcode"
        Me.tcode.ReadOnly = True
        '
        'tref
        '
        Me.tref.HeaderText = "Ref No"
        Me.tref.Name = "tref"
        Me.tref.ReadOnly = True
        '
        'tamt
        '
        Me.tamt.HeaderText = "Amount"
        Me.tamt.Name = "tamt"
        Me.tamt.ReadOnly = True
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TxtList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtList.DefaultCellStyle = DataGridViewCellStyle6
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.Location = New System.Drawing.Point(3, 27)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.ReadOnly = True
        Me.TxtList.RowHeadersWidth = 30
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(839, 167)
        Me.TxtList.TabIndex = 2
        '
        'TxtHeading
        '
        Me.TxtHeading.BackColor = System.Drawing.Color.DarkOrange
        Me.TxtHeading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHeading.ForeColor = System.Drawing.Color.White
        Me.TxtHeading.Location = New System.Drawing.Point(0, 0)
        Me.TxtHeading.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtHeading.Name = "TxtHeading"
        Me.TxtHeading.Size = New System.Drawing.Size(845, 24)
        Me.TxtHeading.TabIndex = 0
        Me.TxtHeading.Text = "BILL WISE DETAILS"
        Me.TxtHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnAdd)
        Me.Panel1.Controls.Add(Me.TxtAmount)
        Me.Panel1.Controls.Add(Me.TxtRefNo)
        Me.Panel1.Controls.Add(Me.ImSlabel4)
        Me.Panel1.Controls.Add(Me.ImSlabel3)
        Me.Panel1.Controls.Add(Me.ImSlabel2)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Controls.Add(Me.TxtRefType)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 197)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(845, 62)
        Me.Panel1.TabIndex = 4
        '
        'BtnAdd
        '
        Me.BtnAdd.AllowToolTip = True
        Me.BtnAdd.BackColor = System.Drawing.Color.White
        Me.BtnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnAdd.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.add1_32
        Me.BtnAdd.Location = New System.Drawing.Point(501, 17)
        Me.BtnAdd.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.SetToolTip = ""
        Me.BtnAdd.Size = New System.Drawing.Size(123, 42)
        Me.BtnAdd.TabIndex = 3
        Me.BtnAdd.Text = "Add to List"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseFunctionKeys = False
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'TxtAmount
        '
        Me.TxtAmount.AllHelpText = True
        Me.TxtAmount.AllowDecimal = False
        Me.TxtAmount.AllowFormulas = False
        Me.TxtAmount.AllowForQty = True
        Me.TxtAmount.AllowNegative = False
        Me.TxtAmount.AllowPerSign = False
        Me.TxtAmount.AllowPlusSign = False
        Me.TxtAmount.AllowToolTip = True
        Me.TxtAmount.DecimalPlaces = CType(3, Short)
        Me.TxtAmount.ExitOnEscKey = True
        Me.TxtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAmount.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtAmount.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtAmount.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtAmount.HelpText = Nothing
        Me.TxtAmount.LFocusBackColor = System.Drawing.Color.White
        Me.TxtAmount.Location = New System.Drawing.Point(333, 37)
        Me.TxtAmount.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtAmount.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtAmount.Max = CType(100000000000000, Long)
        Me.TxtAmount.MaxLength = 12
        Me.TxtAmount.Min = CType(0, Long)
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.NextOnEnter = True
        Me.TxtAmount.SetToolTip = Nothing
        Me.TxtAmount.Size = New System.Drawing.Size(100, 22)
        Me.TxtAmount.TabIndex = 2
        Me.TxtAmount.Text = "0"
        Me.TxtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtAmount.ToolTip = Nothing
        Me.TxtAmount.UseFunctionKeys = False
        Me.TxtAmount.UseUpDownArrowKeys = False
        '
        'TxtRefNo
        '
        Me.TxtRefNo.AllowEmpty = True
        Me.TxtRefNo.AllowOnlyListValues = False
        Me.TxtRefNo.AllowToolTip = True
        Me.TxtRefNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtRefNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtRefNo.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtRefNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRefNo.FormattingEnabled = True
        Me.TxtRefNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtRefNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtRefNo.IsAdvanceSearchWindow = False
        Me.TxtRefNo.IsAllowDigits = True
        Me.TxtRefNo.IsAllowSpace = True
        Me.TxtRefNo.IsAllowSplChars = True
        Me.TxtRefNo.IsAllowToolTip = True
        Me.TxtRefNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtRefNo.Location = New System.Drawing.Point(168, 37)
        Me.TxtRefNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtRefNo.Name = "TxtRefNo"
        Me.TxtRefNo.SetToolTip = Nothing
        Me.TxtRefNo.Size = New System.Drawing.Size(121, 24)
        Me.TxtRefNo.Sorted = True
        Me.TxtRefNo.SpecialCharList = "&-/@"
        Me.TxtRefNo.TabIndex = 0
        Me.TxtRefNo.UseFunctionKeys = False
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.ForeColor = System.Drawing.Color.Maroon
        Me.ImSlabel4.Location = New System.Drawing.Point(12, 0)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(434, 13)
        Me.ImSlabel4.TabIndex = 1
        Me.ImSlabel4.Text = "Select the Reference from the above list, then Enter amount and add to list"
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(330, 21)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(120, 13)
        Me.ImSlabel3.TabIndex = 1
        Me.ImSlabel3.Text = "Amount to be Effect"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(165, 21)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(108, 13)
        Me.ImSlabel2.TabIndex = 1
        Me.ImSlabel2.Text = "For Reference No"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(23, 21)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(35, 13)
        Me.ImSlabel1.TabIndex = 1
        Me.ImSlabel1.Text = "Type"
        '
        'TxtRefType
        '
        Me.TxtRefType.AllowEmpty = True
        Me.TxtRefType.AllowOnlyListValues = True
        Me.TxtRefType.AllowToolTip = True
        Me.TxtRefType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtRefType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtRefType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtRefType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRefType.FormattingEnabled = True
        Me.TxtRefType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtRefType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtRefType.IsAdvanceSearchWindow = False
        Me.TxtRefType.IsAllowDigits = True
        Me.TxtRefType.IsAllowSpace = True
        Me.TxtRefType.IsAllowSplChars = True
        Me.TxtRefType.IsAllowToolTip = True
        Me.TxtRefType.Items.AddRange(New Object() {"Against", "New"})
        Me.TxtRefType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtRefType.Location = New System.Drawing.Point(26, 37)
        Me.TxtRefType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtRefType.Name = "TxtRefType"
        Me.TxtRefType.SetToolTip = Nothing
        Me.TxtRefType.Size = New System.Drawing.Size(121, 24)
        Me.TxtRefType.Sorted = True
        Me.TxtRefType.SpecialCharList = "&-/@"
        Me.TxtRefType.TabIndex = 0
        Me.TxtRefType.UseFunctionKeys = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtTotal)
        Me.Panel2.Controls.Add(Me.ImSlabel5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 432)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(845, 38)
        Me.Panel2.TabIndex = 5
        '
        'TxtTotal
        '
        Me.TxtTotal.AllowToolTip = True
        Me.TxtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotal.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtTotal.Enabled = False
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtTotal.IsAllowDigits = True
        Me.TxtTotal.IsAllowSpace = True
        Me.TxtTotal.IsAllowSplChars = True
        Me.TxtTotal.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTotal.Location = New System.Drawing.Point(717, 3)
        Me.TxtTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.MaxLength = 12
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.SetToolTip = Nothing
        Me.TxtTotal.Size = New System.Drawing.Size(116, 20)
        Me.TxtTotal.SpecialCharList = "&-/@"
        Me.TxtTotal.TabIndex = 1
        Me.TxtTotal.Text = "0"
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTotal.UseFunctionKeys = False
        '
        'ImSlabel5
        '
        Me.ImSlabel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(662, 8)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(42, 13)
        Me.ImSlabel5.TabIndex = 0
        Me.ImSlabel5.Text = "Totals"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ImsButton2)
        Me.Panel3.Controls.Add(Me.ImsButton3)
        Me.Panel3.Controls.Add(Me.ImsButton1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 473)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(839, 51)
        Me.Panel3.TabIndex = 6
        '
        'ImsButton2
        '
        Me.ImsButton2.AllowToolTip = True
        Me.ImsButton2.BackColor = System.Drawing.Color.White
        Me.ImsButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton2.Image = CType(resources.GetObject("ImsButton2.Image"), System.Drawing.Image)
        Me.ImsButton2.Location = New System.Drawing.Point(593, 3)
        Me.ImsButton2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton2.Name = "ImsButton2"
        Me.ImsButton2.SetToolTip = ""
        Me.ImsButton2.Size = New System.Drawing.Size(143, 45)
        Me.ImsButton2.TabIndex = 0
        Me.ImsButton2.Text = "Save"
        Me.ImsButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton2.UseFunctionKeys = False
        Me.ImsButton2.UseVisualStyleBackColor = False
        '
        'ImsButton3
        '
        Me.ImsButton3.AllowToolTip = True
        Me.ImsButton3.BackColor = System.Drawing.Color.White
        Me.ImsButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton3.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton3.Location = New System.Drawing.Point(355, 3)
        Me.ImsButton3.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton3.Name = "ImsButton3"
        Me.ImsButton3.SetToolTip = ""
        Me.ImsButton3.Size = New System.Drawing.Size(143, 45)
        Me.ImsButton3.TabIndex = 0
        Me.ImsButton3.Text = "Not Applicable"
        Me.ImsButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton3.UseFunctionKeys = False
        Me.ImsButton3.UseVisualStyleBackColor = False
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.BackColor = System.Drawing.Color.White
        Me.ImsButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ImsButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.ImsButton1.Location = New System.Drawing.Point(118, 3)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(143, 45)
        Me.ImsButton1.TabIndex = 0
        Me.ImsButton1.Text = "Close"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = False
        '
        'BillwiseDetailsEntryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(845, 527)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BillwiseDetailsEntryForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Bill Wise Allocation"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.TxtPaidList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtHeading As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents TxtPaidList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnAdd As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtAmount As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtRefNo As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtRefType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ttype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tamt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ImsButton2 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton3 As JyothiPharmaERPSystem3.IMSButton

End Class
