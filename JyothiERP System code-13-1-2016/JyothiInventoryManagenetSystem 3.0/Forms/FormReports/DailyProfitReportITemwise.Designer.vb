<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DailyProfitReportITemwise
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DailyProfitReportITemwise))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtOnCurrentPrice = New System.Windows.Forms.CheckBox()
        Me.TxtStockGroup = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.IsDateWiseOn = New System.Windows.Forms.CheckBox()
        Me.TxtLedgerName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.lblGroupWise = New JyothiPharmaERPSystem3.IMSlabel()
        Me.BtnPrint = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtHeading = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtNetSalesAmount = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.txtSoldProfit = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtReturnProfit = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtNetProfit = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtCurrencyName = New JyothiPharmaERPSystem3.IMSlabel()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = CType(resources.GetObject("ImsButton1.Image"), System.Drawing.Image)
        Me.ImsButton1.Location = New System.Drawing.Point(65, 80)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(155, 45)
        Me.ImsButton1.TabIndex = 47
        Me.ImsButton1.Text = "Load"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(170, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem, Me.PrintToolStripMenuItem, Me.RefreshToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        Me.MenuToolStripMenuItem.Visible = False
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'TxtEndDate
        '
        Me.TxtEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEndDate.Location = New System.Drawing.Point(65, 54)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(156, 20)
        Me.TxtEndDate.TabIndex = 46
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 15)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Ending"
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(198, 0)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(148, 38)
        Me.BtnClose.TabIndex = 0
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtOnCurrentPrice)
        Me.Panel1.Controls.Add(Me.TxtStockGroup)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Controls.Add(Me.ImsButton1)
        Me.Panel1.Controls.Add(Me.TxtEndDate)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TxtStartDate)
        Me.Panel1.Controls.Add(Me.IsDateWiseOn)
        Me.Panel1.Controls.Add(Me.TxtLedgerName)
        Me.Panel1.Controls.Add(Me.lblGroupWise)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(799, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(229, 346)
        Me.Panel1.TabIndex = 3
        '
        'TxtOnCurrentPrice
        '
        Me.TxtOnCurrentPrice.AutoSize = True
        Me.TxtOnCurrentPrice.Checked = True
        Me.TxtOnCurrentPrice.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TxtOnCurrentPrice.Location = New System.Drawing.Point(10, 255)
        Me.TxtOnCurrentPrice.Name = "TxtOnCurrentPrice"
        Me.TxtOnCurrentPrice.Size = New System.Drawing.Size(143, 17)
        Me.TxtOnCurrentPrice.TabIndex = 50
        Me.TxtOnCurrentPrice.Text = "Based On Current Price?"
        Me.TxtOnCurrentPrice.UseVisualStyleBackColor = True
        '
        'TxtStockGroup
        '
        Me.TxtStockGroup.AllowEmpty = True
        Me.TxtStockGroup.AllowOnlyListValues = True
        Me.TxtStockGroup.AllowToolTip = True
        Me.TxtStockGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtStockGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtStockGroup.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtStockGroup.FormattingEnabled = True
        Me.TxtStockGroup.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockGroup.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockGroup.IsAdvanceSearchWindow = False
        Me.TxtStockGroup.IsAllowDigits = True
        Me.TxtStockGroup.IsAllowSpace = True
        Me.TxtStockGroup.IsAllowSplChars = True
        Me.TxtStockGroup.IsAllowToolTip = True
        Me.TxtStockGroup.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockGroup.Location = New System.Drawing.Point(3, 157)
        Me.TxtStockGroup.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockGroup.Name = "TxtStockGroup"
        Me.TxtStockGroup.SetToolTip = Nothing
        Me.TxtStockGroup.Size = New System.Drawing.Size(197, 21)
        Me.TxtStockGroup.Sorted = True
        Me.TxtStockGroup.SpecialCharList = "&-/@"
        Me.TxtStockGroup.TabIndex = 49
        Me.TxtStockGroup.UseFunctionKeys = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(3, 141)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(96, 13)
        Me.ImSlabel1.TabIndex = 48
        Me.ImSlabel1.Text = "By Stock Group"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 15)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Starting"
        '
        'TxtStartDate
        '
        Me.TxtStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtStartDate.Location = New System.Drawing.Point(65, 28)
        Me.TxtStartDate.Name = "TxtStartDate"
        Me.TxtStartDate.Size = New System.Drawing.Size(156, 20)
        Me.TxtStartDate.TabIndex = 45
        '
        'IsDateWiseOn
        '
        Me.IsDateWiseOn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IsDateWiseOn.AutoSize = True
        Me.IsDateWiseOn.Checked = True
        Me.IsDateWiseOn.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IsDateWiseOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsDateWiseOn.Location = New System.Drawing.Point(4, 3)
        Me.IsDateWiseOn.Name = "IsDateWiseOn"
        Me.IsDateWiseOn.Size = New System.Drawing.Size(132, 19)
        Me.IsDateWiseOn.TabIndex = 44
        Me.IsDateWiseOn.Text = "Show By Date Wise"
        Me.IsDateWiseOn.UseVisualStyleBackColor = True
        '
        'TxtLedgerName
        '
        Me.TxtLedgerName.AllowEmpty = True
        Me.TxtLedgerName.AllowOnlyListValues = True
        Me.TxtLedgerName.AllowToolTip = True
        Me.TxtLedgerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtLedgerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtLedgerName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtLedgerName.FormattingEnabled = True
        Me.TxtLedgerName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLedgerName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLedgerName.IsAdvanceSearchWindow = False
        Me.TxtLedgerName.IsAllowDigits = True
        Me.TxtLedgerName.IsAllowSpace = True
        Me.TxtLedgerName.IsAllowSplChars = True
        Me.TxtLedgerName.IsAllowToolTip = True
        Me.TxtLedgerName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLedgerName.Location = New System.Drawing.Point(6, 211)
        Me.TxtLedgerName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLedgerName.Name = "TxtLedgerName"
        Me.TxtLedgerName.SetToolTip = Nothing
        Me.TxtLedgerName.Size = New System.Drawing.Size(207, 21)
        Me.TxtLedgerName.Sorted = True
        Me.TxtLedgerName.SpecialCharList = "&-/@"
        Me.TxtLedgerName.TabIndex = 4
        Me.TxtLedgerName.UseFunctionKeys = False
        '
        'lblGroupWise
        '
        Me.lblGroupWise.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGroupWise.AutoSize = True
        Me.lblGroupWise.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupWise.Location = New System.Drawing.Point(3, 195)
        Me.lblGroupWise.Name = "lblGroupWise"
        Me.lblGroupWise.Size = New System.Drawing.Size(136, 13)
        Me.lblGroupWise.TabIndex = 2
        Me.lblGroupWise.Text = "Filer By Account Name"
        '
        'BtnPrint
        '
        Me.BtnPrint.AllowToolTip = True
        Me.BtnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnPrint.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.print__1_
        Me.BtnPrint.Location = New System.Drawing.Point(497, 0)
        Me.BtnPrint.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPrint.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.SetToolTip = ""
        Me.BtnPrint.Size = New System.Drawing.Size(154, 38)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseFunctionKeys = False
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 235.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtHeading, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1031, 442)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'TxtHeading
        '
        Me.TxtHeading.BackColor = System.Drawing.Color.Green
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtHeading, 2)
        Me.TxtHeading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHeading.ForeColor = System.Drawing.Color.White
        Me.TxtHeading.Location = New System.Drawing.Point(0, 0)
        Me.TxtHeading.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtHeading.Name = "TxtHeading"
        Me.TxtHeading.Size = New System.Drawing.Size(1031, 27)
        Me.TxtHeading.TabIndex = 0
        Me.TxtHeading.Text = "DAILY PROFIT REPORT"
        Me.TxtHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtList)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 27)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(796, 352)
        Me.Panel2.TabIndex = 2
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtList.DefaultCellStyle = DataGridViewCellStyle2
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.Location = New System.Drawing.Point(0, 0)
        Me.TxtList.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(796, 352)
        Me.TxtList.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.09549!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.03714!))
        Me.TableLayoutPanel2.Controls.Add(Me.BtnClose, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnPrint, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.MenuStrip1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 404)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(796, 38)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TxtNetSalesAmount)
        Me.Panel3.Controls.Add(Me.txtSoldProfit)
        Me.Panel3.Controls.Add(Me.TxtReturnProfit)
        Me.Panel3.Controls.Add(Me.TxtNetProfit)
        Me.Panel3.Controls.Add(Me.TxtCurrencyName)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 379)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(796, 25)
        Me.Panel3.TabIndex = 5
        '
        'TxtNetSalesAmount
        '
        Me.TxtNetSalesAmount.AllowToolTip = True
        Me.TxtNetSalesAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNetSalesAmount.BackColor = System.Drawing.Color.White
        Me.TxtNetSalesAmount.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtNetSalesAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetSalesAmount.ForeColor = System.Drawing.Color.Black
        Me.TxtNetSalesAmount.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNetSalesAmount.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNetSalesAmount.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtNetSalesAmount.IsAllowDigits = True
        Me.TxtNetSalesAmount.IsAllowSpace = True
        Me.TxtNetSalesAmount.IsAllowSplChars = True
        Me.TxtNetSalesAmount.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNetSalesAmount.Location = New System.Drawing.Point(292, 0)
        Me.TxtNetSalesAmount.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNetSalesAmount.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtNetSalesAmount.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtNetSalesAmount.MaxLength = 75
        Me.TxtNetSalesAmount.Name = "TxtNetSalesAmount"
        Me.TxtNetSalesAmount.ReadOnly = True
        Me.TxtNetSalesAmount.SetToolTip = Nothing
        Me.TxtNetSalesAmount.Size = New System.Drawing.Size(100, 20)
        Me.TxtNetSalesAmount.SpecialCharList = "&-/@"
        Me.TxtNetSalesAmount.TabIndex = 1
        Me.TxtNetSalesAmount.Text = "0"
        Me.TxtNetSalesAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNetSalesAmount.UseFunctionKeys = False
        '
        'txtSoldProfit
        '
        Me.txtSoldProfit.AllowToolTip = True
        Me.txtSoldProfit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSoldProfit.BackColor = System.Drawing.Color.White
        Me.txtSoldProfit.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.txtSoldProfit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSoldProfit.ForeColor = System.Drawing.Color.Black
        Me.txtSoldProfit.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtSoldProfit.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtSoldProfit.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtSoldProfit.IsAllowDigits = True
        Me.txtSoldProfit.IsAllowSpace = True
        Me.txtSoldProfit.IsAllowSplChars = True
        Me.txtSoldProfit.LFocusBackColor = System.Drawing.Color.White
        Me.txtSoldProfit.Location = New System.Drawing.Point(397, 0)
        Me.txtSoldProfit.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtSoldProfit.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.txtSoldProfit.Margin = New System.Windows.Forms.Padding(0)
        Me.txtSoldProfit.MaxLength = 75
        Me.txtSoldProfit.Name = "txtSoldProfit"
        Me.txtSoldProfit.ReadOnly = True
        Me.txtSoldProfit.SetToolTip = Nothing
        Me.txtSoldProfit.Size = New System.Drawing.Size(100, 20)
        Me.txtSoldProfit.SpecialCharList = "&-/@"
        Me.txtSoldProfit.TabIndex = 1
        Me.txtSoldProfit.Text = "0"
        Me.txtSoldProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSoldProfit.UseFunctionKeys = False
        '
        'TxtReturnProfit
        '
        Me.TxtReturnProfit.AllowToolTip = True
        Me.TxtReturnProfit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtReturnProfit.BackColor = System.Drawing.Color.White
        Me.TxtReturnProfit.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtReturnProfit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReturnProfit.ForeColor = System.Drawing.Color.Black
        Me.TxtReturnProfit.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtReturnProfit.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtReturnProfit.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtReturnProfit.IsAllowDigits = True
        Me.TxtReturnProfit.IsAllowSpace = True
        Me.TxtReturnProfit.IsAllowSplChars = True
        Me.TxtReturnProfit.LFocusBackColor = System.Drawing.Color.White
        Me.TxtReturnProfit.Location = New System.Drawing.Point(591, 0)
        Me.TxtReturnProfit.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtReturnProfit.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtReturnProfit.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtReturnProfit.MaxLength = 75
        Me.TxtReturnProfit.Name = "TxtReturnProfit"
        Me.TxtReturnProfit.ReadOnly = True
        Me.TxtReturnProfit.SetToolTip = Nothing
        Me.TxtReturnProfit.Size = New System.Drawing.Size(100, 20)
        Me.TxtReturnProfit.SpecialCharList = "&-/@"
        Me.TxtReturnProfit.TabIndex = 1
        Me.TxtReturnProfit.Text = "0"
        Me.TxtReturnProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtReturnProfit.UseFunctionKeys = False
        '
        'TxtNetProfit
        '
        Me.TxtNetProfit.AllowToolTip = True
        Me.TxtNetProfit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNetProfit.BackColor = System.Drawing.Color.White
        Me.TxtNetProfit.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtNetProfit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetProfit.ForeColor = System.Drawing.Color.Black
        Me.TxtNetProfit.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNetProfit.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNetProfit.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtNetProfit.IsAllowDigits = True
        Me.TxtNetProfit.IsAllowSpace = True
        Me.TxtNetProfit.IsAllowSplChars = True
        Me.TxtNetProfit.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNetProfit.Location = New System.Drawing.Point(695, 0)
        Me.TxtNetProfit.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNetProfit.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtNetProfit.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtNetProfit.MaxLength = 75
        Me.TxtNetProfit.Name = "TxtNetProfit"
        Me.TxtNetProfit.ReadOnly = True
        Me.TxtNetProfit.SetToolTip = Nothing
        Me.TxtNetProfit.Size = New System.Drawing.Size(100, 20)
        Me.TxtNetProfit.SpecialCharList = "&-/@"
        Me.TxtNetProfit.TabIndex = 1
        Me.TxtNetProfit.Text = "0"
        Me.TxtNetProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNetProfit.UseFunctionKeys = False
        '
        'TxtCurrencyName
        '
        Me.TxtCurrencyName.AutoSize = True
        Me.TxtCurrencyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCurrencyName.Location = New System.Drawing.Point(12, 4)
        Me.TxtCurrencyName.Name = "TxtCurrencyName"
        Me.TxtCurrencyName.Size = New System.Drawing.Size(80, 13)
        Me.TxtCurrencyName.TabIndex = 0
        Me.TxtCurrencyName.Text = "Grand Totals"
        '
        'DailyProfitReportITemwise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1031, 442)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "DailyProfitReportITemwise"
        Me.Text = "Daily Profit Report Itemwise"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents IsDateWiseOn As System.Windows.Forms.CheckBox
    Friend WithEvents TxtLedgerName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents lblGroupWise As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents BtnPrint As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtHeading As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TxtNetProfit As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtCurrencyName As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents txtSoldProfit As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtReturnProfit As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtNetSalesAmount As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtStockGroup As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtOnCurrentPrice As System.Windows.Forms.CheckBox
End Class
