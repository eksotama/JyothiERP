<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonthlyPurchaseRegisterFrm
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MonthlyPurchaseRegisterFrm))
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TxtCharType = New System.Windows.Forms.ComboBox()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetailedToolStrimMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TxtSalesPerson = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtSalesAc = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtStockGroup = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtLedgerName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.UserButton2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtIsPeriod = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnPrint = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtTotals = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(433, 3)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(425, 319)
        Me.Chart1.TabIndex = 1
        Me.Chart1.Text = "Chart1"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.TxtCharType)
        Me.Panel4.Controls.Add(Me.ImSlabel6)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(430, 325)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(431, 26)
        Me.Panel4.TabIndex = 2
        '
        'TxtCharType
        '
        Me.TxtCharType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCharType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtCharType.FormattingEnabled = True
        Me.TxtCharType.Items.AddRange(New Object() {"Point", "FastPoint", "Bubble", "Line", "Spline", "StepLine", "FastLine", "Bar", "StackedBar", "StackedBar100", "Column", "StackedColumn", "StackedColumn100", "Area", "SplineArea", "StackedArea", "StackedArea100", "Pie", "Doughnut", "Stock", "Candlestick", "Range", "SplineRange", "RangeBar", "RangeColumn", "Radar", "Polar", "ErrorBar", "BoxPlot", "Renko", "ThreeLineBreak", "Kagi", "PointAndFigure", "Funnel", "Pyramid"})
        Me.TxtCharType.Location = New System.Drawing.Point(143, 4)
        Me.TxtCharType.Name = "TxtCharType"
        Me.TxtCharType.Size = New System.Drawing.Size(133, 21)
        Me.TxtCharType.TabIndex = 52
        '
        'ImSlabel6
        '
        Me.ImSlabel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(72, 8)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(65, 13)
        Me.ImSlabel6.TabIndex = 51
        Me.ImSlabel6.Text = "Chat Style"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ImsHeadingLabel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(867, 498)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'ImsHeadingLabel1
        '
        Me.ImsHeadingLabel1.BackColor = System.Drawing.Color.Green
        Me.ImsHeadingLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsHeadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsHeadingLabel1.ForeColor = System.Drawing.Color.White
        Me.ImsHeadingLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ImsHeadingLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsHeadingLabel1.Name = "ImsHeadingLabel1"
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(867, 28)
        Me.ImsHeadingLabel1.TabIndex = 0
        Me.ImsHeadingLabel1.Text = "MONTLY PURCHASE REGISTER"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Controls.Add(Me.TxtSalesPerson)
        Me.Panel1.Controls.Add(Me.TxtSalesAc)
        Me.Panel1.Controls.Add(Me.TxtStockGroup)
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
        Me.Panel1.Size = New System.Drawing.Size(867, 68)
        Me.Panel1.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(404, 22)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(58, 24)
        Me.MenuStrip1.TabIndex = 54
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem, Me.PrintToolStripMenuItem, Me.RefreshToolStripMenuItem, Me.DetailedToolStrimMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        Me.MenuToolStripMenuItem.Visible = False
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'DetailedToolStrimMenuItem
        '
        Me.DetailedToolStrimMenuItem.Name = "DetailedToolStrimMenuItem"
        Me.DetailedToolStrimMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.DetailedToolStrimMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.DetailedToolStrimMenuItem.Text = "DetailedView"
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
        Me.TxtSalesPerson.IsAllowDigits = True
        Me.TxtSalesPerson.IsAllowSpace = True
        Me.TxtSalesPerson.IsAllowSplChars = True
        Me.TxtSalesPerson.IsAllowToolTip = True
        Me.TxtSalesPerson.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSalesPerson.Location = New System.Drawing.Point(335, 51)
        Me.TxtSalesPerson.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSalesPerson.Name = "TxtSalesPerson"
        Me.TxtSalesPerson.Size = New System.Drawing.Size(10, 21)
        Me.TxtSalesPerson.Sorted = True
        Me.TxtSalesPerson.SpecialCharList = "&-/@"
        Me.TxtSalesPerson.TabIndex = 53
        Me.TxtSalesPerson.UseFunctionKeys = False
        Me.TxtSalesPerson.Visible = False
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
        Me.TxtSalesAc.IsAllowDigits = True
        Me.TxtSalesAc.IsAllowSpace = True
        Me.TxtSalesAc.IsAllowSplChars = True
        Me.TxtSalesAc.IsAllowToolTip = True
        Me.TxtSalesAc.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSalesAc.Location = New System.Drawing.Point(653, 36)
        Me.TxtSalesAc.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSalesAc.Name = "TxtSalesAc"
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
        Me.TxtStockGroup.IsAllowDigits = True
        Me.TxtStockGroup.IsAllowSpace = True
        Me.TxtStockGroup.IsAllowSplChars = True
        Me.TxtStockGroup.IsAllowToolTip = True
        Me.TxtStockGroup.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockGroup.Location = New System.Drawing.Point(653, 6)
        Me.TxtStockGroup.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockGroup.Name = "TxtStockGroup"
        Me.TxtStockGroup.Size = New System.Drawing.Size(173, 21)
        Me.TxtStockGroup.Sorted = True
        Me.TxtStockGroup.SpecialCharList = "&-/@"
        Me.TxtStockGroup.TabIndex = 51
        Me.TxtStockGroup.UseFunctionKeys = False
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
        Me.TxtLedgerName.IsAllowDigits = True
        Me.TxtLedgerName.IsAllowSpace = True
        Me.TxtLedgerName.IsAllowSplChars = True
        Me.TxtLedgerName.IsAllowToolTip = True
        Me.TxtLedgerName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLedgerName.Location = New System.Drawing.Point(294, 30)
        Me.TxtLedgerName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLedgerName.Name = "TxtLedgerName"
        Me.TxtLedgerName.Size = New System.Drawing.Size(233, 21)
        Me.TxtLedgerName.Sorted = True
        Me.TxtLedgerName.SpecialCharList = "&-/@"
        Me.TxtLedgerName.TabIndex = 49
        Me.TxtLedgerName.UseFunctionKeys = False
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(548, 41)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(103, 13)
        Me.ImSlabel5.TabIndex = 48
        Me.ImSlabel5.Text = "By Purchase A/c"
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
        Me.ImSlabel1.Location = New System.Drawing.Point(291, 10)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(77, 13)
        Me.ImSlabel1.TabIndex = 48
        Me.ImSlabel1.Text = "By Suppliers"
        '
        'UserButton2
        '
        Me.UserButton2.AllowToolTip = True
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
        Me.UserButton2.UseVisualStyleBackColor = True
        '
        'TxtEndDate
        '
        Me.TxtEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate.Location = New System.Drawing.Point(12, 41)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(149, 20)
        Me.TxtEndDate.TabIndex = 46
        '
        'TxtStartDate
        '
        Me.TxtStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.TxtIsPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsPeriod.Location = New System.Drawing.Point(12, 3)
        Me.TxtIsPeriod.Name = "TxtIsPeriod"
        Me.TxtIsPeriod.Size = New System.Drawing.Size(149, 19)
        Me.TxtIsPeriod.TabIndex = 44
        Me.TxtIsPeriod.Text = "Show By Date Wise"
        Me.TxtIsPeriod.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 7
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.63549!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.57811!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.188098!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.43358!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.30287!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.77489!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.76826!))
        Me.TableLayoutPanel2.Controls.Add(Me.BtnClose, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnPrint, 4, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 453)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(867, 45)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(199, 3)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(138, 39)
        Me.BtnClose.TabIndex = 0
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.AllowToolTip = True
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnPrint.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.print__1_
        Me.BtnPrint.Location = New System.Drawing.Point(478, 3)
        Me.BtnPrint.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.SetToolTip = ""
        Me.BtnPrint.Size = New System.Drawing.Size(127, 39)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseFunctionKeys = False
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TxtList, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Chart1, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel4, 1, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 99)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(861, 351)
        Me.TableLayoutPanel3.TabIndex = 5
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.Location = New System.Drawing.Point(0, 0)
        Me.TxtList.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(430, 325)
        Me.TxtList.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtTotals)
        Me.Panel2.Controls.Add(Me.ImSlabel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 325)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(430, 26)
        Me.Panel2.TabIndex = 2
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
        Me.TxtTotals.Location = New System.Drawing.Point(265, 3)
        Me.TxtTotals.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTotals.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtTotals.MaxLength = 75
        Me.TxtTotals.Name = "TxtTotals"
        Me.TxtTotals.ReadOnly = True
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
        Me.ImSlabel3.Location = New System.Drawing.Point(212, 6)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(42, 13)
        Me.ImSlabel3.TabIndex = 48
        Me.ImSlabel3.Text = "Totals"
        '
        'MonthlyPurchaseRegisterFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 498)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "MonthlyPurchaseRegisterFrm"
        Me.Text = "Montly PurchaseRegister "
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents TxtCharType As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtSalesAc As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtStockGroup As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtLedgerName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents UserButton2 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtIsPeriod As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnPrint As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtTotals As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtSalesPerson As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetailedToolStrimMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
