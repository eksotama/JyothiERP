<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class createnewserialnumbers
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
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtNote = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtDesc = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtSerialNo = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtStockSize = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtStockCode = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtSuffix = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtPrefix = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtEndWith = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtStartFrom = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.ImSlabel10 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel9 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.IsAutoRange = New System.Windows.Forms.CheckBox()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtStatus, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(661, 479)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(655, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "NEW SERIAL NUMBERS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtNote)
        Me.Panel1.Controls.Add(Me.TxtDesc)
        Me.Panel1.Controls.Add(Me.TxtSerialNo)
        Me.Panel1.Controls.Add(Me.TxtStockSize)
        Me.Panel1.Controls.Add(Me.TxtStockCode)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.IsAutoRange)
        Me.Panel1.Controls.Add(Me.ImSlabel6)
        Me.Panel1.Controls.Add(Me.ImSlabel5)
        Me.Panel1.Controls.Add(Me.ImSlabel4)
        Me.Panel1.Controls.Add(Me.ImSlabel3)
        Me.Panel1.Controls.Add(Me.ImSlabel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 29)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(661, 363)
        Me.Panel1.TabIndex = 2
        '
        'TxtNote
        '
        Me.TxtNote.AllowToolTip = True
        Me.TxtNote.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtNote.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNote.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNote.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtNote.IsAllowDigits = True
        Me.TxtNote.IsAllowSpace = True
        Me.TxtNote.IsAllowSplChars = True
        Me.TxtNote.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNote.Location = New System.Drawing.Point(148, 163)
        Me.TxtNote.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNote.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtNote.MaxLength = 140
        Me.TxtNote.Multiline = True
        Me.TxtNote.Name = "TxtNote"
        Me.TxtNote.SetToolTip = Nothing
        Me.TxtNote.Size = New System.Drawing.Size(358, 45)
        Me.TxtNote.SpecialCharList = "&-/@"
        Me.TxtNote.TabIndex = 4
        Me.TxtNote.UseFunctionKeys = False
        '
        'TxtDesc
        '
        Me.TxtDesc.AllowToolTip = True
        Me.TxtDesc.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtDesc.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDesc.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDesc.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtDesc.IsAllowDigits = True
        Me.TxtDesc.IsAllowSpace = True
        Me.TxtDesc.IsAllowSplChars = True
        Me.TxtDesc.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDesc.Location = New System.Drawing.Point(149, 128)
        Me.TxtDesc.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDesc.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtDesc.MaxLength = 75
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.SetToolTip = Nothing
        Me.TxtDesc.Size = New System.Drawing.Size(358, 20)
        Me.TxtDesc.SpecialCharList = "&-/@"
        Me.TxtDesc.TabIndex = 3
        Me.TxtDesc.UseFunctionKeys = False
        '
        'TxtSerialNo
        '
        Me.TxtSerialNo.AllowToolTip = True
        Me.TxtSerialNo.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtSerialNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSerialNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSerialNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtSerialNo.IsAllowDigits = True
        Me.TxtSerialNo.IsAllowSpace = True
        Me.TxtSerialNo.IsAllowSplChars = True
        Me.TxtSerialNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSerialNo.Location = New System.Drawing.Point(148, 93)
        Me.TxtSerialNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSerialNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtSerialNo.MaxLength = 49
        Me.TxtSerialNo.Name = "TxtSerialNo"
        Me.TxtSerialNo.SetToolTip = Nothing
        Me.TxtSerialNo.Size = New System.Drawing.Size(358, 20)
        Me.TxtSerialNo.SpecialCharList = "&-/@"
        Me.TxtSerialNo.TabIndex = 2
        Me.TxtSerialNo.UseFunctionKeys = False
        '
        'TxtStockSize
        '
        Me.TxtStockSize.AllowEmpty = True
        Me.TxtStockSize.AllowOnlyListValues = True
        Me.TxtStockSize.AllowToolTip = True
        Me.TxtStockSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtStockSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtStockSize.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtStockSize.FormattingEnabled = True
        Me.TxtStockSize.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockSize.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockSize.IsAdvanceSearchWindow = False
        Me.TxtStockSize.IsAllowDigits = True
        Me.TxtStockSize.IsAllowSpace = True
        Me.TxtStockSize.IsAllowSplChars = True
        Me.TxtStockSize.IsAllowToolTip = True
        Me.TxtStockSize.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockSize.Location = New System.Drawing.Point(150, 57)
        Me.TxtStockSize.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockSize.Name = "TxtStockSize"
        Me.TxtStockSize.SetToolTip = Nothing
        Me.TxtStockSize.Size = New System.Drawing.Size(357, 21)
        Me.TxtStockSize.Sorted = True
        Me.TxtStockSize.SpecialCharList = "&-/@"
        Me.TxtStockSize.TabIndex = 1
        Me.TxtStockSize.UseFunctionKeys = False
        '
        'TxtStockCode
        '
        Me.TxtStockCode.AllowEmpty = False
        Me.TxtStockCode.AllowOnlyListValues = False
        Me.TxtStockCode.AllowToolTip = True
        Me.TxtStockCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtStockCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtStockCode.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtStockCode.FormattingEnabled = True
        Me.TxtStockCode.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockCode.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockCode.IsAdvanceSearchWindow = False
        Me.TxtStockCode.IsAllowDigits = True
        Me.TxtStockCode.IsAllowSpace = True
        Me.TxtStockCode.IsAllowSplChars = True
        Me.TxtStockCode.IsAllowToolTip = True
        Me.TxtStockCode.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockCode.Location = New System.Drawing.Point(150, 21)
        Me.TxtStockCode.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockCode.Name = "TxtStockCode"
        Me.TxtStockCode.SetToolTip = Nothing
        Me.TxtStockCode.Size = New System.Drawing.Size(357, 21)
        Me.TxtStockCode.Sorted = True
        Me.TxtStockCode.SpecialCharList = "&-/@"
        Me.TxtStockCode.TabIndex = 0
        Me.TxtStockCode.UseFunctionKeys = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TxtSuffix)
        Me.Panel3.Controls.Add(Me.TxtPrefix)
        Me.Panel3.Controls.Add(Me.TxtEndWith)
        Me.Panel3.Controls.Add(Me.TxtStartFrom)
        Me.Panel3.Controls.Add(Me.ImSlabel10)
        Me.Panel3.Controls.Add(Me.ImSlabel9)
        Me.Panel3.Controls.Add(Me.ImSlabel8)
        Me.Panel3.Controls.Add(Me.ImSlabel7)
        Me.Panel3.Location = New System.Drawing.Point(70, 251)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(435, 111)
        Me.Panel3.TabIndex = 2
        Me.Panel3.Visible = False
        '
        'TxtSuffix
        '
        Me.TxtSuffix.AllowToolTip = True
        Me.TxtSuffix.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtSuffix.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSuffix.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSuffix.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtSuffix.IsAllowDigits = True
        Me.TxtSuffix.IsAllowSpace = True
        Me.TxtSuffix.IsAllowSplChars = True
        Me.TxtSuffix.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSuffix.Location = New System.Drawing.Point(79, 80)
        Me.TxtSuffix.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSuffix.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtSuffix.MaxLength = 15
        Me.TxtSuffix.Name = "TxtSuffix"
        Me.TxtSuffix.SetToolTip = Nothing
        Me.TxtSuffix.Size = New System.Drawing.Size(146, 20)
        Me.TxtSuffix.SpecialCharList = "&-/@"
        Me.TxtSuffix.TabIndex = 3
        Me.TxtSuffix.UseFunctionKeys = False
        '
        'TxtPrefix
        '
        Me.TxtPrefix.AllowToolTip = True
        Me.TxtPrefix.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtPrefix.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPrefix.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPrefix.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtPrefix.IsAllowDigits = True
        Me.TxtPrefix.IsAllowSpace = True
        Me.TxtPrefix.IsAllowSplChars = True
        Me.TxtPrefix.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPrefix.Location = New System.Drawing.Point(80, 7)
        Me.TxtPrefix.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPrefix.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtPrefix.MaxLength = 15
        Me.TxtPrefix.Name = "TxtPrefix"
        Me.TxtPrefix.SetToolTip = Nothing
        Me.TxtPrefix.Size = New System.Drawing.Size(146, 20)
        Me.TxtPrefix.SpecialCharList = "&-/@"
        Me.TxtPrefix.TabIndex = 0
        Me.TxtPrefix.UseFunctionKeys = False
        '
        'TxtEndWith
        '
        Me.TxtEndWith.AllHelpText = True
        Me.TxtEndWith.AllowDecimal = False
        Me.TxtEndWith.AllowFormulas = False
        Me.TxtEndWith.AllowForQty = True
        Me.TxtEndWith.AllowNegative = False
        Me.TxtEndWith.AllowPerSign = False
        Me.TxtEndWith.AllowPlusSign = False
        Me.TxtEndWith.AllowToolTip = True
        Me.TxtEndWith.DecimalPlaces = CType(3, Short)
        Me.TxtEndWith.ExitOnEscKey = True
        Me.TxtEndWith.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtEndWith.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtEndWith.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtEndWith.HelpText = Nothing
        Me.TxtEndWith.LFocusBackColor = System.Drawing.Color.White
        Me.TxtEndWith.Location = New System.Drawing.Point(79, 54)
        Me.TxtEndWith.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtEndWith.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtEndWith.Max = CType(100000000000000, Long)
        Me.TxtEndWith.MaxLength = 12
        Me.TxtEndWith.Min = CType(0, Long)
        Me.TxtEndWith.Name = "TxtEndWith"
        Me.TxtEndWith.NextOnEnter = True
        Me.TxtEndWith.SetToolTip = Nothing
        Me.TxtEndWith.Size = New System.Drawing.Size(146, 20)
        Me.TxtEndWith.TabIndex = 2
        Me.TxtEndWith.Text = "0"
        Me.TxtEndWith.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtEndWith.ToolTip = Nothing
        Me.TxtEndWith.UseFunctionKeys = False
        Me.TxtEndWith.UseUpDownArrowKeys = False
        '
        'TxtStartFrom
        '
        Me.TxtStartFrom.AllHelpText = True
        Me.TxtStartFrom.AllowDecimal = False
        Me.TxtStartFrom.AllowFormulas = False
        Me.TxtStartFrom.AllowForQty = True
        Me.TxtStartFrom.AllowNegative = False
        Me.TxtStartFrom.AllowPerSign = False
        Me.TxtStartFrom.AllowPlusSign = False
        Me.TxtStartFrom.AllowToolTip = True
        Me.TxtStartFrom.DecimalPlaces = CType(3, Short)
        Me.TxtStartFrom.ExitOnEscKey = True
        Me.TxtStartFrom.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStartFrom.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStartFrom.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtStartFrom.HelpText = Nothing
        Me.TxtStartFrom.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStartFrom.Location = New System.Drawing.Point(79, 31)
        Me.TxtStartFrom.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStartFrom.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtStartFrom.Max = CType(100000000000000, Long)
        Me.TxtStartFrom.MaxLength = 12
        Me.TxtStartFrom.Min = CType(0, Long)
        Me.TxtStartFrom.Name = "TxtStartFrom"
        Me.TxtStartFrom.NextOnEnter = True
        Me.TxtStartFrom.SetToolTip = Nothing
        Me.TxtStartFrom.Size = New System.Drawing.Size(146, 20)
        Me.TxtStartFrom.TabIndex = 1
        Me.TxtStartFrom.Text = "0"
        Me.TxtStartFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtStartFrom.ToolTip = Nothing
        Me.TxtStartFrom.UseFunctionKeys = False
        Me.TxtStartFrom.UseUpDownArrowKeys = False
        '
        'ImSlabel10
        '
        Me.ImSlabel10.AutoSize = True
        Me.ImSlabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel10.Location = New System.Drawing.Point(8, 57)
        Me.ImSlabel10.Name = "ImSlabel10"
        Me.ImSlabel10.Size = New System.Drawing.Size(59, 13)
        Me.ImSlabel10.TabIndex = 0
        Me.ImSlabel10.Text = "End With"
        '
        'ImSlabel9
        '
        Me.ImSlabel9.AutoSize = True
        Me.ImSlabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel9.Location = New System.Drawing.Point(8, 34)
        Me.ImSlabel9.Name = "ImSlabel9"
        Me.ImSlabel9.Size = New System.Drawing.Size(65, 13)
        Me.ImSlabel9.TabIndex = 0
        Me.ImSlabel9.Text = "Start From"
        '
        'ImSlabel8
        '
        Me.ImSlabel8.AutoSize = True
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(8, 11)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(39, 13)
        Me.ImSlabel8.TabIndex = 0
        Me.ImSlabel8.Text = "Prefix"
        '
        'ImSlabel7
        '
        Me.ImSlabel7.AutoSize = True
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(8, 80)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(39, 13)
        Me.ImSlabel7.TabIndex = 0
        Me.ImSlabel7.Text = "Suffix"
        '
        'IsAutoRange
        '
        Me.IsAutoRange.AutoSize = True
        Me.IsAutoRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsAutoRange.Location = New System.Drawing.Point(47, 228)
        Me.IsAutoRange.Name = "IsAutoRange"
        Me.IsAutoRange.Size = New System.Drawing.Size(122, 17)
        Me.IsAutoRange.TabIndex = 1
        Me.IsAutoRange.Text = "Create By Range"
        Me.IsAutoRange.UseVisualStyleBackColor = True
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(48, 166)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(34, 13)
        Me.ImSlabel6.TabIndex = 0
        Me.ImSlabel6.Text = "Note"
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(44, 131)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(71, 13)
        Me.ImSlabel5.TabIndex = 0
        Me.ImSlabel5.Text = "Description"
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(44, 93)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(86, 13)
        Me.ImSlabel4.TabIndex = 0
        Me.ImSlabel4.Text = "Serial Number"
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(44, 60)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(68, 13)
        Me.ImSlabel3.TabIndex = 0
        Me.ImSlabel3.Text = "Stock Size"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(44, 24)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(73, 13)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "Stock Code"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnClose)
        Me.Panel2.Controls.Add(Me.BtnCreate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 395)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(655, 57)
        Me.Panel2.TabIndex = 3
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(127, 10)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(138, 43)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnCreate
        '
        Me.BtnCreate.AllowToolTip = True
        Me.BtnCreate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCreate.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361186619_document_new
        Me.BtnCreate.Location = New System.Drawing.Point(395, 10)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(150, 43)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "&Create"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = True
        '
        'TxtStatus
        '
        Me.TxtStatus.AutoSize = True
        Me.TxtStatus.BackColor = System.Drawing.Color.White
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Green
        Me.TxtStatus.Location = New System.Drawing.Point(3, 455)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(655, 24)
        Me.TxtStatus.TabIndex = 0
        Me.TxtStatus.Text = "Status: Ready"
        '
        'createnewserialnumbers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(661, 479)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "createnewserialnumbers"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "NEW SERIAL NUMBERS"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtStatus As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents IsAutoRange As System.Windows.Forms.CheckBox
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtNote As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtDesc As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtSerialNo As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtStockSize As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtStockCode As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtSuffix As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtPrefix As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtEndWith As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtStartFrom As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents ImSlabel10 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel9 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel

End Class
