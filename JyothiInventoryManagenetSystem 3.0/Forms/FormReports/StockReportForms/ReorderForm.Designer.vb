<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReorderForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReorderForm))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnPrint = New JyothiPharmaERPSystem3.IMSButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.TxtShowAll = New System.Windows.Forms.CheckBox()
        Me.TxtMaxQty = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.txtminqty = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.btnreloadqty = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtShowTailUnit = New System.Windows.Forms.CheckBox()
        Me.TxtStockLocation = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtStockGroup = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.TxtHeading = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem, Me.PrintToolStripMenuItem, Me.RefreshToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        Me.MenuToolStripMenuItem.Visible = False
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'BtnPrint
        '
        Me.BtnPrint.AllowToolTip = True
        Me.BtnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrint.BackColor = System.Drawing.Color.White
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(680, 0)
        Me.BtnPrint.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPrint.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.SetToolTip = ""
        Me.BtnPrint.Size = New System.Drawing.Size(154, 49)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseFunctionKeys = False
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(259, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'TxtShowAll
        '
        Me.TxtShowAll.AutoSize = True
        Me.TxtShowAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShowAll.Location = New System.Drawing.Point(874, 14)
        Me.TxtShowAll.Name = "TxtShowAll"
        Me.TxtShowAll.Size = New System.Drawing.Size(127, 17)
        Me.TxtShowAll.TabIndex = 51
        Me.TxtShowAll.Text = "Remove Qty Filter"
        Me.TxtShowAll.UseVisualStyleBackColor = True
        Me.TxtShowAll.Visible = False
        '
        'TxtMaxQty
        '
        Me.TxtMaxQty.AllHelpText = True
        Me.TxtMaxQty.AllowDecimal = True
        Me.TxtMaxQty.AllowFormulas = False
        Me.TxtMaxQty.AllowForQty = False
        Me.TxtMaxQty.AllowNegative = True
        Me.TxtMaxQty.AllowPerSign = False
        Me.TxtMaxQty.AllowPlusSign = False
        Me.TxtMaxQty.AllowToolTip = True
        Me.TxtMaxQty.DecimalPlaces = CType(3, Short)
        Me.TxtMaxQty.ExitOnEscKey = True
        Me.TxtMaxQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMaxQty.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtMaxQty.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtMaxQty.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtMaxQty.HelpText = Nothing
        Me.TxtMaxQty.LFocusBackColor = System.Drawing.Color.White
        Me.TxtMaxQty.Location = New System.Drawing.Point(644, 18)
        Me.TxtMaxQty.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtMaxQty.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtMaxQty.Max = CType(100000000000000, Long)
        Me.TxtMaxQty.MaxLength = 15
        Me.TxtMaxQty.Min = CType(-100000000000000, Long)
        Me.TxtMaxQty.Name = "TxtMaxQty"
        Me.TxtMaxQty.NextOnEnter = True
        Me.TxtMaxQty.SetToolTip = Nothing
        Me.TxtMaxQty.Size = New System.Drawing.Size(78, 20)
        Me.TxtMaxQty.TabIndex = 50
        Me.TxtMaxQty.Text = "0"
        Me.TxtMaxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtMaxQty.ToolTip = Nothing
        Me.TxtMaxQty.UseFunctionKeys = False
        Me.TxtMaxQty.UseUpDownArrowKeys = False
        '
        'txtminqty
        '
        Me.txtminqty.AllHelpText = True
        Me.txtminqty.AllowDecimal = False
        Me.txtminqty.AllowFormulas = False
        Me.txtminqty.AllowForQty = False
        Me.txtminqty.AllowNegative = True
        Me.txtminqty.AllowPerSign = False
        Me.txtminqty.AllowPlusSign = False
        Me.txtminqty.AllowToolTip = True
        Me.txtminqty.DecimalPlaces = CType(3, Short)
        Me.txtminqty.ExitOnEscKey = True
        Me.txtminqty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtminqty.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtminqty.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtminqty.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtminqty.HelpText = Nothing
        Me.txtminqty.LFocusBackColor = System.Drawing.Color.White
        Me.txtminqty.Location = New System.Drawing.Point(560, 18)
        Me.txtminqty.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtminqty.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.txtminqty.Max = CType(100000000000000, Long)
        Me.txtminqty.MaxLength = 15
        Me.txtminqty.Min = CType(-100000000000000, Long)
        Me.txtminqty.Name = "txtminqty"
        Me.txtminqty.NextOnEnter = True
        Me.txtminqty.SetToolTip = Nothing
        Me.txtminqty.Size = New System.Drawing.Size(78, 20)
        Me.txtminqty.TabIndex = 50
        Me.txtminqty.Text = "1"
        Me.txtminqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtminqty.ToolTip = Nothing
        Me.txtminqty.UseFunctionKeys = False
        Me.txtminqty.UseUpDownArrowKeys = False
        '
        'btnreloadqty
        '
        Me.btnreloadqty.AllowToolTip = True
        Me.btnreloadqty.BackColor = System.Drawing.Color.White
        Me.btnreloadqty.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnreloadqty.Image = CType(resources.GetObject("btnreloadqty.Image"), System.Drawing.Image)
        Me.btnreloadqty.Location = New System.Drawing.Point(728, 0)
        Me.btnreloadqty.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnreloadqty.Name = "btnreloadqty"
        Me.btnreloadqty.SetToolTip = ""
        Me.btnreloadqty.Size = New System.Drawing.Size(116, 43)
        Me.btnreloadqty.TabIndex = 49
        Me.btnreloadqty.Text = "Reload"
        Me.btnreloadqty.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnreloadqty.UseFunctionKeys = False
        Me.btnreloadqty.UseVisualStyleBackColor = False
        '
        'TxtShowTailUnit
        '
        Me.TxtShowTailUnit.AutoSize = True
        Me.TxtShowTailUnit.Checked = True
        Me.TxtShowTailUnit.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TxtShowTailUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShowTailUnit.Location = New System.Drawing.Point(363, 5)
        Me.TxtShowTailUnit.Name = "TxtShowTailUnit"
        Me.TxtShowTailUnit.Size = New System.Drawing.Size(130, 17)
        Me.TxtShowTailUnit.TabIndex = 48
        Me.TxtShowTailUnit.Text = "Show In Tail Units"
        Me.TxtShowTailUnit.UseVisualStyleBackColor = True
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
        Me.TxtStockLocation.Location = New System.Drawing.Point(133, 29)
        Me.TxtStockLocation.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockLocation.Name = "TxtStockLocation"
        Me.TxtStockLocation.SetToolTip = Nothing
        Me.TxtStockLocation.Size = New System.Drawing.Size(197, 21)
        Me.TxtStockLocation.Sorted = True
        Me.TxtStockLocation.SpecialCharList = "&-/@"
        Me.TxtStockLocation.TabIndex = 1
        Me.TxtStockLocation.UseFunctionKeys = False
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(254, 0)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(144, 49)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = False
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 455)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1018, 52)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(557, 2)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(127, 13)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "Reorder Qty between"
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
        Me.TxtStockGroup.Location = New System.Drawing.Point(133, 3)
        Me.TxtStockGroup.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockGroup.Name = "TxtStockGroup"
        Me.TxtStockGroup.SetToolTip = Nothing
        Me.TxtStockGroup.Size = New System.Drawing.Size(197, 21)
        Me.TxtStockGroup.Sorted = True
        Me.TxtStockGroup.SpecialCharList = "&-/@"
        Me.TxtStockGroup.TabIndex = 1
        Me.TxtStockGroup.UseFunctionKeys = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(19, 6)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(96, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "By Stock Group"
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
        Me.TxtList.Location = New System.Drawing.Point(0, 80)
        Me.TxtList.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(1018, 352)
        Me.TxtList.TabIndex = 0
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
        Me.TxtHeading.Size = New System.Drawing.Size(1018, 23)
        Me.TxtHeading.TabIndex = 0
        Me.TxtHeading.Text = "REORDER SUMMARY"
        Me.TxtHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtShowAll)
        Me.Panel2.Controls.Add(Me.TxtMaxQty)
        Me.Panel2.Controls.Add(Me.txtminqty)
        Me.Panel2.Controls.Add(Me.btnreloadqty)
        Me.Panel2.Controls.Add(Me.TxtShowTailUnit)
        Me.Panel2.Controls.Add(Me.TxtStockLocation)
        Me.Panel2.Controls.Add(Me.ImSlabel2)
        Me.Panel2.Controls.Add(Me.ImSlabel4)
        Me.Panel2.Controls.Add(Me.TxtStockGroup)
        Me.Panel2.Controls.Add(Me.ImSlabel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 23)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1018, 57)
        Me.Panel2.TabIndex = 2
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(19, 30)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(74, 13)
        Me.ImSlabel4.TabIndex = 0
        Me.ImSlabel4.Text = "By Location"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtList, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtHeading, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1018, 507)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 432)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1018, 23)
        Me.Panel1.TabIndex = 5
        '
        'ReorderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1018, 507)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ReorderForm"
        Me.Text = "Reorder Summary"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnPrint As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents TxtShowAll As System.Windows.Forms.CheckBox
    Friend WithEvents TxtMaxQty As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents txtminqty As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents btnreloadqty As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtShowTailUnit As System.Windows.Forms.CheckBox
    Friend WithEvents TxtStockLocation As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtStockGroup As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TxtHeading As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
   
End Class
