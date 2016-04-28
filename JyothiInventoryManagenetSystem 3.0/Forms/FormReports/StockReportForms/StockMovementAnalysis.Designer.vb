<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockMovementAnalysis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockMovementAnalysis))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtStockLocation = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtStockCode = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtHeading = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.BtnPrint = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtStockGroup = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.BtnSuppliersOnly = New System.Windows.Forms.RadioButton()
        Me.BtnBoth = New System.Windows.Forms.RadioButton()
        Me.btnCustomersOnly = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.IsDateWiseOn = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtTotal4 = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtTotal5 = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtTotal6 = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtTotal1 = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtTotal2 = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtTotal3 = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtList1 = New JyothiPharmaERPSystem3.IMSList()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.CrystalReportViewer2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.TxtList1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(251, 0)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(150, 42)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'TxtStockLocation
        '
        Me.TxtStockLocation.AllowEmpty = True
        Me.TxtStockLocation.AllowOnlyListValues = True
        Me.TxtStockLocation.AllowToolTip = True
        Me.TxtStockLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtStockLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtStockLocation.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtStockLocation.FormattingEnabled = True
        Me.TxtStockLocation.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockLocation.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockLocation.IsAdvanceSearchWindow = False
        Me.TxtStockLocation.IsAllowDigits = True
        Me.TxtStockLocation.IsAllowSpace = True
        Me.TxtStockLocation.IsAllowSplChars = True
        Me.TxtStockLocation.IsAllowToolTip = True
        Me.TxtStockLocation.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockLocation.Location = New System.Drawing.Point(612, 30)
        Me.TxtStockLocation.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockLocation.Name = "TxtStockLocation"
        Me.TxtStockLocation.SetToolTip = Nothing
        Me.TxtStockLocation.Size = New System.Drawing.Size(167, 21)
        Me.TxtStockLocation.Sorted = True
        Me.TxtStockLocation.SpecialCharList = "&-/@"
        Me.TxtStockLocation.TabIndex = 1
        Me.TxtStockLocation.UseFunctionKeys = False
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(520, 33)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(74, 13)
        Me.ImSlabel4.TabIndex = 0
        Me.ImSlabel4.Text = "By Location"
        '
        'TxtStockCode
        '
        Me.TxtStockCode.AllowEmpty = True
        Me.TxtStockCode.AllowOnlyListValues = False
        Me.TxtStockCode.AllowToolTip = True
        Me.TxtStockCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtStockCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtStockCode.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtStockCode.FormattingEnabled = True
        Me.TxtStockCode.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockCode.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockCode.IsAdvanceSearchWindow = False
        Me.TxtStockCode.IsAllowDigits = True
        Me.TxtStockCode.IsAllowSpace = True
        Me.TxtStockCode.IsAllowSplChars = True
        Me.TxtStockCode.IsAllowToolTip = True
        Me.TxtStockCode.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockCode.Location = New System.Drawing.Point(612, 5)
        Me.TxtStockCode.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockCode.Name = "TxtStockCode"
        Me.TxtStockCode.SetToolTip = Nothing
        Me.TxtStockCode.Size = New System.Drawing.Size(167, 21)
        Me.TxtStockCode.Sorted = True
        Me.TxtStockCode.SpecialCharList = "&-/@"
        Me.TxtStockCode.TabIndex = 1
        Me.TxtStockCode.UseFunctionKeys = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(520, 8)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(91, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "By Stock Code"
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
        Me.TxtHeading.Size = New System.Drawing.Size(1008, 23)
        Me.TxtHeading.TabIndex = 0
        Me.TxtHeading.Text = "STOCK ITEM MOVEMENT ANALYSIS"
        Me.TxtHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnPrint
        '
        Me.BtnPrint.AllowToolTip = True
        Me.BtnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrint.BackColor = System.Drawing.Color.White
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(663, 0)
        Me.BtnPrint.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPrint.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.SetToolTip = ""
        Me.BtnPrint.Size = New System.Drawing.Size(162, 42)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseFunctionKeys = False
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtHeading, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1008, 508)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtStockGroup)
        Me.Panel2.Controls.Add(Me.ImSlabel8)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.TxtEndDate)
        Me.Panel2.Controls.Add(Me.TxtStartDate)
        Me.Panel2.Controls.Add(Me.IsDateWiseOn)
        Me.Panel2.Controls.Add(Me.TxtStockLocation)
        Me.Panel2.Controls.Add(Me.ImSlabel4)
        Me.Panel2.Controls.Add(Me.TxtStockCode)
        Me.Panel2.Controls.Add(Me.ImSlabel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 23)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1008, 56)
        Me.Panel2.TabIndex = 2
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
        Me.TxtStockGroup.Location = New System.Drawing.Point(354, 5)
        Me.TxtStockGroup.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockGroup.Name = "TxtStockGroup"
        Me.TxtStockGroup.SetToolTip = Nothing
        Me.TxtStockGroup.Size = New System.Drawing.Size(155, 21)
        Me.TxtStockGroup.Sorted = True
        Me.TxtStockGroup.SpecialCharList = "&-/@"
        Me.TxtStockGroup.TabIndex = 58
        Me.TxtStockGroup.UseFunctionKeys = False
        '
        'ImSlabel8
        '
        Me.ImSlabel8.AutoSize = True
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(256, 8)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(96, 13)
        Me.ImSlabel8.TabIndex = 55
        Me.ImSlabel8.Text = "By Stock Group"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.BtnSuppliersOnly)
        Me.Panel4.Controls.Add(Me.BtnBoth)
        Me.Panel4.Controls.Add(Me.btnCustomersOnly)
        Me.Panel4.Location = New System.Drawing.Point(789, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(185, 46)
        Me.Panel4.TabIndex = 54
        '
        'BtnSuppliersOnly
        '
        Me.BtnSuppliersOnly.AutoSize = True
        Me.BtnSuppliersOnly.Location = New System.Drawing.Point(84, 4)
        Me.BtnSuppliersOnly.Name = "BtnSuppliersOnly"
        Me.BtnSuppliersOnly.Size = New System.Drawing.Size(92, 17)
        Me.BtnSuppliersOnly.TabIndex = 0
        Me.BtnSuppliersOnly.Text = "Suppliers Only"
        Me.BtnSuppliersOnly.UseVisualStyleBackColor = True
        '
        'BtnBoth
        '
        Me.BtnBoth.AutoSize = True
        Me.BtnBoth.Checked = True
        Me.BtnBoth.Location = New System.Drawing.Point(31, 13)
        Me.BtnBoth.Name = "BtnBoth"
        Me.BtnBoth.Size = New System.Drawing.Size(47, 17)
        Me.BtnBoth.TabIndex = 0
        Me.BtnBoth.TabStop = True
        Me.BtnBoth.Text = "Both"
        Me.BtnBoth.UseVisualStyleBackColor = True
        '
        'btnCustomersOnly
        '
        Me.btnCustomersOnly.AutoSize = True
        Me.btnCustomersOnly.Location = New System.Drawing.Point(84, 26)
        Me.btnCustomersOnly.Name = "btnCustomersOnly"
        Me.btnCustomersOnly.Size = New System.Drawing.Size(98, 17)
        Me.btnCustomersOnly.TabIndex = 0
        Me.btnCustomersOnly.Text = "Customers Only"
        Me.btnCustomersOnly.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(175, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 27)
        Me.Button1.TabIndex = 53
        Me.Button1.Text = "Load"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TxtEndDate
        '
        Me.TxtEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEndDate.Location = New System.Drawing.Point(23, 35)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(147, 20)
        Me.TxtEndDate.TabIndex = 51
        '
        'TxtStartDate
        '
        Me.TxtStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtStartDate.Location = New System.Drawing.Point(23, 14)
        Me.TxtStartDate.Name = "TxtStartDate"
        Me.TxtStartDate.Size = New System.Drawing.Size(147, 20)
        Me.TxtStartDate.TabIndex = 50
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
        Me.IsDateWiseOn.Location = New System.Drawing.Point(6, -2)
        Me.IsDateWiseOn.Name = "IsDateWiseOn"
        Me.IsDateWiseOn.Size = New System.Drawing.Size(132, 19)
        Me.IsDateWiseOn.TabIndex = 52
        Me.IsDateWiseOn.Text = "Show By Date Wise"
        Me.IsDateWiseOn.UseVisualStyleBackColor = True
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 466)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1008, 42)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(263, 24)
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 79)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1008, 387)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1000, 361)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "NORMAL VIEW                                       "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Panel1, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TxtList, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TxtList1, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.ImSlabel2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ImSlabel3, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(994, 355)
        Me.TableLayoutPanel3.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtTotal4)
        Me.Panel1.Controls.Add(Me.TxtTotal5)
        Me.Panel1.Controls.Add(Me.TxtTotal6)
        Me.Panel1.Controls.Add(Me.ImSlabel6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(497, 335)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(497, 20)
        Me.Panel1.TabIndex = 8
        '
        'TxtTotal4
        '
        Me.TxtTotal4.AllowToolTip = True
        Me.TxtTotal4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotal4.BackColor = System.Drawing.Color.White
        Me.TxtTotal4.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtTotal4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal4.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTotal4.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTotal4.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtTotal4.IsAllowDigits = True
        Me.TxtTotal4.IsAllowSpace = True
        Me.TxtTotal4.IsAllowSplChars = True
        Me.TxtTotal4.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTotal4.Location = New System.Drawing.Point(203, 1)
        Me.TxtTotal4.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTotal4.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtTotal4.MaxLength = 75
        Me.TxtTotal4.Name = "TxtTotal4"
        Me.TxtTotal4.ReadOnly = True
        Me.TxtTotal4.SetToolTip = Nothing
        Me.TxtTotal4.Size = New System.Drawing.Size(110, 20)
        Me.TxtTotal4.SpecialCharList = "&-/@"
        Me.TxtTotal4.TabIndex = 19
        Me.TxtTotal4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTotal4.UseFunctionKeys = False
        Me.TxtTotal4.Visible = False
        '
        'TxtTotal5
        '
        Me.TxtTotal5.AllowToolTip = True
        Me.TxtTotal5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotal5.BackColor = System.Drawing.Color.White
        Me.TxtTotal5.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtTotal5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal5.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTotal5.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTotal5.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtTotal5.IsAllowDigits = True
        Me.TxtTotal5.IsAllowSpace = True
        Me.TxtTotal5.IsAllowSplChars = True
        Me.TxtTotal5.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTotal5.Location = New System.Drawing.Point(315, 1)
        Me.TxtTotal5.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTotal5.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtTotal5.MaxLength = 75
        Me.TxtTotal5.Name = "TxtTotal5"
        Me.TxtTotal5.ReadOnly = True
        Me.TxtTotal5.SetToolTip = Nothing
        Me.TxtTotal5.Size = New System.Drawing.Size(90, 20)
        Me.TxtTotal5.SpecialCharList = "&-/@"
        Me.TxtTotal5.TabIndex = 20
        Me.TxtTotal5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTotal5.UseFunctionKeys = False
        '
        'TxtTotal6
        '
        Me.TxtTotal6.AllowToolTip = True
        Me.TxtTotal6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotal6.BackColor = System.Drawing.Color.White
        Me.TxtTotal6.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtTotal6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal6.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTotal6.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTotal6.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtTotal6.IsAllowDigits = True
        Me.TxtTotal6.IsAllowSpace = True
        Me.TxtTotal6.IsAllowSplChars = True
        Me.TxtTotal6.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTotal6.Location = New System.Drawing.Point(405, 1)
        Me.TxtTotal6.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTotal6.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtTotal6.MaxLength = 75
        Me.TxtTotal6.Name = "TxtTotal6"
        Me.TxtTotal6.ReadOnly = True
        Me.TxtTotal6.SetToolTip = Nothing
        Me.TxtTotal6.Size = New System.Drawing.Size(90, 20)
        Me.TxtTotal6.SpecialCharList = "&-/@"
        Me.TxtTotal6.TabIndex = 21
        Me.TxtTotal6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTotal6.UseFunctionKeys = False
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(12, 3)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(42, 13)
        Me.ImSlabel6.TabIndex = 16
        Me.ImSlabel6.Text = "Totals"
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
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
        Me.TxtList.Location = New System.Drawing.Point(0, 14)
        Me.TxtList.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(497, 321)
        Me.TxtList.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TxtTotal1)
        Me.Panel3.Controls.Add(Me.TxtTotal2)
        Me.Panel3.Controls.Add(Me.TxtTotal3)
        Me.Panel3.Controls.Add(Me.ImSlabel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 335)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(497, 20)
        Me.Panel3.TabIndex = 7
        '
        'TxtTotal1
        '
        Me.TxtTotal1.AllowToolTip = True
        Me.TxtTotal1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotal1.BackColor = System.Drawing.Color.White
        Me.TxtTotal1.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtTotal1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal1.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTotal1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTotal1.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtTotal1.IsAllowDigits = True
        Me.TxtTotal1.IsAllowSpace = True
        Me.TxtTotal1.IsAllowSplChars = True
        Me.TxtTotal1.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTotal1.Location = New System.Drawing.Point(205, 2)
        Me.TxtTotal1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTotal1.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtTotal1.MaxLength = 75
        Me.TxtTotal1.Name = "TxtTotal1"
        Me.TxtTotal1.ReadOnly = True
        Me.TxtTotal1.SetToolTip = Nothing
        Me.TxtTotal1.Size = New System.Drawing.Size(110, 20)
        Me.TxtTotal1.SpecialCharList = "&-/@"
        Me.TxtTotal1.TabIndex = 18
        Me.TxtTotal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTotal1.UseFunctionKeys = False
        Me.TxtTotal1.Visible = False
        '
        'TxtTotal2
        '
        Me.TxtTotal2.AllowToolTip = True
        Me.TxtTotal2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotal2.BackColor = System.Drawing.Color.White
        Me.TxtTotal2.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtTotal2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal2.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTotal2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTotal2.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtTotal2.IsAllowDigits = True
        Me.TxtTotal2.IsAllowSpace = True
        Me.TxtTotal2.IsAllowSplChars = True
        Me.TxtTotal2.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTotal2.Location = New System.Drawing.Point(315, 2)
        Me.TxtTotal2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTotal2.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtTotal2.MaxLength = 75
        Me.TxtTotal2.Name = "TxtTotal2"
        Me.TxtTotal2.ReadOnly = True
        Me.TxtTotal2.SetToolTip = Nothing
        Me.TxtTotal2.Size = New System.Drawing.Size(90, 20)
        Me.TxtTotal2.SpecialCharList = "&-/@"
        Me.TxtTotal2.TabIndex = 18
        Me.TxtTotal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTotal2.UseFunctionKeys = False
        '
        'TxtTotal3
        '
        Me.TxtTotal3.AllowToolTip = True
        Me.TxtTotal3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotal3.BackColor = System.Drawing.Color.White
        Me.TxtTotal3.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtTotal3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal3.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTotal3.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTotal3.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtTotal3.IsAllowDigits = True
        Me.TxtTotal3.IsAllowSpace = True
        Me.TxtTotal3.IsAllowSplChars = True
        Me.TxtTotal3.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTotal3.Location = New System.Drawing.Point(405, 2)
        Me.TxtTotal3.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTotal3.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtTotal3.MaxLength = 75
        Me.TxtTotal3.Name = "TxtTotal3"
        Me.TxtTotal3.ReadOnly = True
        Me.TxtTotal3.SetToolTip = Nothing
        Me.TxtTotal3.Size = New System.Drawing.Size(90, 20)
        Me.TxtTotal3.SpecialCharList = "&-/@"
        Me.TxtTotal3.TabIndex = 18
        Me.TxtTotal3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTotal3.UseFunctionKeys = False
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(12, 3)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(42, 13)
        Me.ImSlabel5.TabIndex = 16
        Me.ImSlabel5.Text = "Totals"
        '
        'TxtList1
        '
        Me.TxtList1.AllowUserToAddRows = False
        Me.TxtList1.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.TxtList1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtList1.DefaultCellStyle = DataGridViewCellStyle8
        Me.TxtList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList1.Location = New System.Drawing.Point(497, 14)
        Me.TxtList1.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtList1.MultiSelect = False
        Me.TxtList1.Name = "TxtList1"
        Me.TxtList1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList1.Size = New System.Drawing.Size(497, 321)
        Me.TxtList1.TabIndex = 5
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(3, 0)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(192, 13)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "Customers (Movement Outwards)"
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(500, 0)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(177, 13)
        Me.ImSlabel3.TabIndex = 0
        Me.ImSlabel3.Text = "Suppliers (Movement Inwards)"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.CrystalReportViewer1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1000, 361)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "DETAILED VIEW  INWARDS                 "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(3, 3)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(994, 355)
        Me.CrystalReportViewer1.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.CrystalReportViewer2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1000, 361)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "DETAILED VIEW  OUTWARDS                 "
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer2
        '
        Me.CrystalReportViewer2.ActiveViewIndex = -1
        Me.CrystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer2.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer2.Name = "CrystalReportViewer2"
        Me.CrystalReportViewer2.Size = New System.Drawing.Size(1000, 361)
        Me.CrystalReportViewer2.TabIndex = 1
        '
        'StockMovementAnalysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1008, 508)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "StockMovementAnalysis"
        Me.Text = "StockMovementAnalysis"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.TxtList1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtStockLocation As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtStockCode As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtHeading As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnPrint As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxtList1 As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents IsDateWiseOn As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TxtTotal3 As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtTotal4 As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtTotal5 As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtTotal6 As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtTotal1 As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtTotal2 As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents BtnSuppliersOnly As System.Windows.Forms.RadioButton
    Friend WithEvents BtnBoth As System.Windows.Forms.RadioButton
    Friend WithEvents btnCustomersOnly As System.Windows.Forms.RadioButton
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtStockGroup As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Private WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Private WithEvents CrystalReportViewer2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
