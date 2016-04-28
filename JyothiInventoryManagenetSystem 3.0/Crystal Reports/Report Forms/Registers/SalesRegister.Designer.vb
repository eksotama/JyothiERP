<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesRegister
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalesRegister))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtSalesAc = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtStockGroup = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtShowItemDetails = New System.Windows.Forms.CheckBox()
        Me.IsLedgerCurrency = New System.Windows.Forms.CheckBox()
        Me.TxtBySaleForm = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtSalesPerson = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtLedgerName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.UserButton2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtIsPeriod = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtGrid = New JyothiPharmaERPSystem3.IMSList()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TxtTotals = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnPrint = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnEdit = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.TxtGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ImsHeadingLabel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1104, 532)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ImsHeadingLabel1
        '
        Me.ImsHeadingLabel1.BackColor = System.Drawing.Color.DarkOrange
        Me.ImsHeadingLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsHeadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsHeadingLabel1.ForeColor = System.Drawing.Color.White
        Me.ImsHeadingLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ImsHeadingLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsHeadingLabel1.Name = "ImsHeadingLabel1"
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(1104, 28)
        Me.ImsHeadingLabel1.TabIndex = 0
        Me.ImsHeadingLabel1.Text = "SALES REGISTER"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtSalesAc)
        Me.Panel1.Controls.Add(Me.TxtStockGroup)
        Me.Panel1.Controls.Add(Me.TxtShowItemDetails)
        Me.Panel1.Controls.Add(Me.IsLedgerCurrency)
        Me.Panel1.Controls.Add(Me.TxtBySaleForm)
        Me.Panel1.Controls.Add(Me.TxtSalesPerson)
        Me.Panel1.Controls.Add(Me.ImSlabel6)
        Me.Panel1.Controls.Add(Me.ImSlabel2)
        Me.Panel1.Controls.Add(Me.TxtLedgerName)
        Me.Panel1.Controls.Add(Me.ImSlabel5)
        Me.Panel1.Controls.Add(Me.ImSlabel4)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Controls.Add(Me.UserButton2)
        Me.Panel1.Controls.Add(Me.TxtEndDate)
        Me.Panel1.Controls.Add(Me.TxtStartDate)
        Me.Panel1.Controls.Add(Me.TxtIsPeriod)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 28)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1104, 78)
        Me.Panel1.TabIndex = 1
        '
        'TxtSalesAc
        '
        Me.TxtSalesAc.AllowEmpty = True
        Me.TxtSalesAc.AllowOnlyListValues = False
        Me.TxtSalesAc.AllowToolTip = True
        Me.TxtSalesAc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtSalesAc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtSalesAc.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtSalesAc.FormattingEnabled = True
        Me.TxtSalesAc.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSalesAc.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSalesAc.IsAdvanceSearchWindow = False
        Me.TxtSalesAc.IsAllowDigits = True
        Me.TxtSalesAc.IsAllowSpace = True
        Me.TxtSalesAc.IsAllowSplChars = True
        Me.TxtSalesAc.IsAllowToolTip = True
        Me.TxtSalesAc.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSalesAc.Location = New System.Drawing.Point(651, 31)
        Me.TxtSalesAc.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSalesAc.Name = "TxtSalesAc"
        Me.TxtSalesAc.SetToolTip = Nothing
        Me.TxtSalesAc.Size = New System.Drawing.Size(173, 21)
        Me.TxtSalesAc.Sorted = True
        Me.TxtSalesAc.SpecialCharList = "&-/@"
        Me.TxtSalesAc.TabIndex = 51
        Me.TxtSalesAc.UseFunctionKeys = False
        '
        'TxtStockGroup
        '
        Me.TxtStockGroup.AllowEmpty = True
        Me.TxtStockGroup.AllowOnlyListValues = False
        Me.TxtStockGroup.AllowToolTip = True
        Me.TxtStockGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtStockGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtStockGroup.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtStockGroup.FormattingEnabled = True
        Me.TxtStockGroup.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockGroup.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockGroup.IsAdvanceSearchWindow = False
        Me.TxtStockGroup.IsAllowDigits = True
        Me.TxtStockGroup.IsAllowSpace = True
        Me.TxtStockGroup.IsAllowSplChars = True
        Me.TxtStockGroup.IsAllowToolTip = True
        Me.TxtStockGroup.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockGroup.Location = New System.Drawing.Point(650, 6)
        Me.TxtStockGroup.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockGroup.Name = "TxtStockGroup"
        Me.TxtStockGroup.SetToolTip = Nothing
        Me.TxtStockGroup.Size = New System.Drawing.Size(173, 21)
        Me.TxtStockGroup.Sorted = True
        Me.TxtStockGroup.SpecialCharList = "&-/@"
        Me.TxtStockGroup.TabIndex = 51
        Me.TxtStockGroup.UseFunctionKeys = False
        '
        'TxtShowItemDetails
        '
        Me.TxtShowItemDetails.AutoSize = True
        Me.TxtShowItemDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShowItemDetails.Location = New System.Drawing.Point(830, 10)
        Me.TxtShowItemDetails.Name = "TxtShowItemDetails"
        Me.TxtShowItemDetails.Size = New System.Drawing.Size(117, 17)
        Me.TxtShowItemDetails.TabIndex = 50
        Me.TxtShowItemDetails.Text = "Show Item Wise"
        Me.TxtShowItemDetails.UseVisualStyleBackColor = True
        '
        'IsLedgerCurrency
        '
        Me.IsLedgerCurrency.AutoSize = True
        Me.IsLedgerCurrency.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsLedgerCurrency.Location = New System.Drawing.Point(830, 32)
        Me.IsLedgerCurrency.Name = "IsLedgerCurrency"
        Me.IsLedgerCurrency.Size = New System.Drawing.Size(169, 17)
        Me.IsLedgerCurrency.TabIndex = 50
        Me.IsLedgerCurrency.Text = "Show In Ledger Currency"
        Me.IsLedgerCurrency.UseVisualStyleBackColor = True
        '
        'TxtBySaleForm
        '
        Me.TxtBySaleForm.AllowEmpty = True
        Me.TxtBySaleForm.AllowOnlyListValues = True
        Me.TxtBySaleForm.AllowToolTip = True
        Me.TxtBySaleForm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtBySaleForm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtBySaleForm.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtBySaleForm.FormattingEnabled = True
        Me.TxtBySaleForm.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtBySaleForm.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtBySaleForm.IsAdvanceSearchWindow = False
        Me.TxtBySaleForm.IsAllowDigits = True
        Me.TxtBySaleForm.IsAllowSpace = True
        Me.TxtBySaleForm.IsAllowSplChars = True
        Me.TxtBySaleForm.IsAllowToolTip = True
        Me.TxtBySaleForm.LFocusBackColor = System.Drawing.Color.White
        Me.TxtBySaleForm.Location = New System.Drawing.Point(364, 54)
        Me.TxtBySaleForm.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtBySaleForm.Name = "TxtBySaleForm"
        Me.TxtBySaleForm.SetToolTip = Nothing
        Me.TxtBySaleForm.Size = New System.Drawing.Size(178, 21)
        Me.TxtBySaleForm.Sorted = True
        Me.TxtBySaleForm.SpecialCharList = "&-/@"
        Me.TxtBySaleForm.TabIndex = 49
        Me.TxtBySaleForm.UseFunctionKeys = False
        '
        'TxtSalesPerson
        '
        Me.TxtSalesPerson.AllowEmpty = True
        Me.TxtSalesPerson.AllowOnlyListValues = True
        Me.TxtSalesPerson.AllowToolTip = True
        Me.TxtSalesPerson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtSalesPerson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtSalesPerson.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtSalesPerson.FormattingEnabled = True
        Me.TxtSalesPerson.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSalesPerson.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSalesPerson.IsAdvanceSearchWindow = False
        Me.TxtSalesPerson.IsAllowDigits = True
        Me.TxtSalesPerson.IsAllowSpace = True
        Me.TxtSalesPerson.IsAllowSplChars = True
        Me.TxtSalesPerson.IsAllowToolTip = True
        Me.TxtSalesPerson.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSalesPerson.Location = New System.Drawing.Point(364, 30)
        Me.TxtSalesPerson.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSalesPerson.Name = "TxtSalesPerson"
        Me.TxtSalesPerson.SetToolTip = Nothing
        Me.TxtSalesPerson.Size = New System.Drawing.Size(178, 21)
        Me.TxtSalesPerson.Sorted = True
        Me.TxtSalesPerson.SpecialCharList = "&-/@"
        Me.TxtSalesPerson.TabIndex = 49
        Me.TxtSalesPerson.UseFunctionKeys = False
        '
        'ImSlabel6
        '
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(279, 56)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(86, 17)
        Me.ImSlabel6.TabIndex = 48
        Me.ImSlabel6.Text = "By Voucher"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(279, 34)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(86, 17)
        Me.ImSlabel2.TabIndex = 48
        Me.ImSlabel2.Text = "By Salesman"
        '
        'TxtLedgerName
        '
        Me.TxtLedgerName.AllowEmpty = True
        Me.TxtLedgerName.AllowOnlyListValues = True
        Me.TxtLedgerName.AllowToolTip = True
        Me.TxtLedgerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtLedgerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtLedgerName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtLedgerName.FormattingEnabled = True
        Me.TxtLedgerName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLedgerName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLedgerName.IsAdvanceSearchWindow = False
        Me.TxtLedgerName.IsAllowDigits = True
        Me.TxtLedgerName.IsAllowSpace = True
        Me.TxtLedgerName.IsAllowSplChars = True
        Me.TxtLedgerName.IsAllowToolTip = True
        Me.TxtLedgerName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLedgerName.Location = New System.Drawing.Point(364, 9)
        Me.TxtLedgerName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLedgerName.Name = "TxtLedgerName"
        Me.TxtLedgerName.SetToolTip = Nothing
        Me.TxtLedgerName.Size = New System.Drawing.Size(178, 21)
        Me.TxtLedgerName.Sorted = True
        Me.TxtLedgerName.SpecialCharList = "&-/@"
        Me.TxtLedgerName.TabIndex = 49
        Me.TxtLedgerName.UseFunctionKeys = False
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(548, 33)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(81, 13)
        Me.ImSlabel5.TabIndex = 48
        Me.ImSlabel5.Text = "By Sales A/c"
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(548, 10)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(96, 13)
        Me.ImSlabel4.TabIndex = 48
        Me.ImSlabel4.Text = "By Stock Group"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(279, 10)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(77, 13)
        Me.ImSlabel1.TabIndex = 48
        Me.ImSlabel1.Text = "By Customer"
        '
        'UserButton2
        '
        Me.UserButton2.AllowToolTip = True
        Me.UserButton2.BackColor = System.Drawing.Color.White
        Me.UserButton2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.UserButton2.Image = CType(resources.GetObject("UserButton2.Image"), System.Drawing.Image)
        Me.UserButton2.Location = New System.Drawing.Point(167, 18)
        Me.UserButton2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.UserButton2.Name = "UserButton2"
        Me.UserButton2.SetToolTip = ""
        Me.UserButton2.Size = New System.Drawing.Size(106, 43)
        Me.UserButton2.TabIndex = 47
        Me.UserButton2.Text = "Reload"
        Me.UserButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.UserButton2.UseFunctionKeys = False
        Me.UserButton2.UseVisualStyleBackColor = False
        '
        'TxtEndDate
        '
        Me.TxtEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEndDate.Location = New System.Drawing.Point(12, 41)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(149, 20)
        Me.TxtEndDate.TabIndex = 46
        '
        'TxtStartDate
        '
        Me.TxtStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtStartDate.Location = New System.Drawing.Point(12, 21)
        Me.TxtStartDate.Name = "TxtStartDate"
        Me.TxtStartDate.Size = New System.Drawing.Size(149, 20)
        Me.TxtStartDate.TabIndex = 45
        '
        'TxtIsPeriod
        '
        Me.TxtIsPeriod.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIsPeriod.AutoSize = True
        Me.TxtIsPeriod.Checked = True
        Me.TxtIsPeriod.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TxtIsPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsPeriod.Location = New System.Drawing.Point(12, 3)
        Me.TxtIsPeriod.Name = "TxtIsPeriod"
        Me.TxtIsPeriod.Size = New System.Drawing.Size(149, 19)
        Me.TxtIsPeriod.TabIndex = 44
        Me.TxtIsPeriod.Text = "Show By Date Wise"
        Me.TxtIsPeriod.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtGrid)
        Me.Panel2.Controls.Add(Me.TxtList)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 106)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1104, 353)
        Me.Panel2.TabIndex = 2
        '
        'TxtGrid
        '
        Me.TxtGrid.AllowUserToAddRows = False
        Me.TxtGrid.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.TxtGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtGrid.DefaultCellStyle = DataGridViewCellStyle2
        Me.TxtGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtGrid.Location = New System.Drawing.Point(423, 29)
        Me.TxtGrid.Name = "TxtGrid"
        Me.TxtGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtGrid.Size = New System.Drawing.Size(277, 179)
        Me.TxtGrid.TabIndex = 1
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtList.DefaultCellStyle = DataGridViewCellStyle4
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.Location = New System.Drawing.Point(51, 29)
        Me.TxtList.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(260, 169)
        Me.TxtList.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.MenuStrip1)
        Me.Panel3.Controls.Add(Me.TxtTotals)
        Me.Panel3.Controls.Add(Me.ImSlabel3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 459)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1104, 28)
        Me.Panel3.TabIndex = 3
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(463, 2)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(202, 24)
        Me.MenuStrip1.TabIndex = 50
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.PrintToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        Me.MenuToolStripMenuItem.Visible = False
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.PrintToolStripMenuItem.Text = "print"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.CloseToolStripMenuItem.Text = "close"
        '
        'TxtTotals
        '
        Me.TxtTotals.AllowToolTip = True
        Me.TxtTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotals.BackColor = System.Drawing.Color.White
        Me.TxtTotals.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtTotals.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotals.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTotals.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTotals.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtTotals.IsAllowDigits = True
        Me.TxtTotals.IsAllowSpace = True
        Me.TxtTotals.IsAllowSplChars = True
        Me.TxtTotals.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTotals.Location = New System.Drawing.Point(930, 3)
        Me.TxtTotals.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTotals.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtTotals.MaxLength = 75
        Me.TxtTotals.Name = "TxtTotals"
        Me.TxtTotals.ReadOnly = True
        Me.TxtTotals.SetToolTip = Nothing
        Me.TxtTotals.Size = New System.Drawing.Size(162, 21)
        Me.TxtTotals.SpecialCharList = "&-/@"
        Me.TxtTotals.TabIndex = 49
        Me.TxtTotals.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTotals.UseFunctionKeys = False
        '
        'ImSlabel3
        '
        Me.ImSlabel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(877, 6)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(42, 13)
        Me.ImSlabel3.TabIndex = 48
        Me.ImSlabel3.Text = "Totals"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 7
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.76826!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.77489!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.87879!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.77489!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.93074!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.77489!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.76826!))
        Me.TableLayoutPanel2.Controls.Add(Me.BtnClose, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnPrint, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnEdit, 5, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 487)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1104, 45)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(144, 3)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(179, 39)
        Me.BtnClose.TabIndex = 0
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.AllowToolTip = True
        Me.BtnPrint.BackColor = System.Drawing.Color.White
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(471, 3)
        Me.BtnPrint.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.SetToolTip = ""
        Me.BtnPrint.Size = New System.Drawing.Size(179, 39)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseFunctionKeys = False
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'BtnEdit
        '
        Me.BtnEdit.AllowToolTip = True
        Me.BtnEdit.BackColor = System.Drawing.Color.White
        Me.BtnEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnEdit.Image = CType(resources.GetObject("BtnEdit.Image"), System.Drawing.Image)
        Me.BtnEdit.Location = New System.Drawing.Point(777, 3)
        Me.BtnEdit.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.SetToolTip = ""
        Me.BtnEdit.Size = New System.Drawing.Size(179, 39)
        Me.BtnEdit.TabIndex = 0
        Me.BtnEdit.Text = "Edit"
        Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnEdit.UseFunctionKeys = False
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'SalesRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1104, 532)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "SalesRegister"
        Me.Text = "Sales Register"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.TxtGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TxtLedgerName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents UserButton2 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtIsPeriod As System.Windows.Forms.CheckBox
    Friend WithEvents TxtSalesPerson As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents IsLedgerCurrency As System.Windows.Forms.CheckBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TxtTotals As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnPrint As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnEdit As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxtShowItemDetails As System.Windows.Forms.CheckBox
    Friend WithEvents TxtGrid As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtStockGroup As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtSalesAc As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtBySaleForm As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
End Class
