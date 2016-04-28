<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FundFlowFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FundFlowFrm))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.TxtShowDrCrStyle = New System.Windows.Forms.CheckBox()
        Me.TxtNetTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtCrTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.txtDrTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnPrint = New JyothiPharmaERPSystem3.IMSButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.IsCrDrChart = New System.Windows.Forms.CheckBox()
        Me.TxtCharType = New System.Windows.Forms.ComboBox()
        Me.TxtMethod = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.TxtHeading = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtShowDrCrStyle
        '
        Me.TxtShowDrCrStyle.AutoSize = True
        Me.TxtShowDrCrStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShowDrCrStyle.Location = New System.Drawing.Point(5, 16)
        Me.TxtShowDrCrStyle.Name = "TxtShowDrCrStyle"
        Me.TxtShowDrCrStyle.Size = New System.Drawing.Size(124, 17)
        Me.TxtShowDrCrStyle.TabIndex = 8
        Me.TxtShowDrCrStyle.Text = "Show Dr/Cr Style"
        Me.TxtShowDrCrStyle.UseVisualStyleBackColor = True
        '
        'TxtNetTotal
        '
        Me.TxtNetTotal.AllowToolTip = True
        Me.TxtNetTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNetTotal.BackColor = System.Drawing.Color.White
        Me.TxtNetTotal.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtNetTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNetTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNetTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtNetTotal.IsAllowDigits = True
        Me.TxtNetTotal.IsAllowSpace = True
        Me.TxtNetTotal.IsAllowSplChars = True
        Me.TxtNetTotal.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNetTotal.Location = New System.Drawing.Point(529, 4)
        Me.TxtNetTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNetTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtNetTotal.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtNetTotal.MaxLength = 75
        Me.TxtNetTotal.Name = "TxtNetTotal"
        Me.TxtNetTotal.ReadOnly = True
        Me.TxtNetTotal.SetToolTip = Nothing
        Me.TxtNetTotal.Size = New System.Drawing.Size(150, 20)
        Me.TxtNetTotal.SpecialCharList = "&-/@"
        Me.TxtNetTotal.TabIndex = 1
        Me.TxtNetTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNetTotal.UseFunctionKeys = False
        '
        'TxtCrTotal
        '
        Me.TxtCrTotal.AllowToolTip = True
        Me.TxtCrTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCrTotal.BackColor = System.Drawing.Color.White
        Me.TxtCrTotal.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtCrTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCrTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCrTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCrTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtCrTotal.IsAllowDigits = True
        Me.TxtCrTotal.IsAllowSpace = True
        Me.TxtCrTotal.IsAllowSplChars = True
        Me.TxtCrTotal.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCrTotal.Location = New System.Drawing.Point(378, 4)
        Me.TxtCrTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCrTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtCrTotal.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtCrTotal.MaxLength = 75
        Me.TxtCrTotal.Name = "TxtCrTotal"
        Me.TxtCrTotal.ReadOnly = True
        Me.TxtCrTotal.SetToolTip = Nothing
        Me.TxtCrTotal.Size = New System.Drawing.Size(150, 20)
        Me.TxtCrTotal.SpecialCharList = "&-/@"
        Me.TxtCrTotal.TabIndex = 1
        Me.TxtCrTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtCrTotal.UseFunctionKeys = False
        '
        'txtDrTotal
        '
        Me.txtDrTotal.AllowToolTip = True
        Me.txtDrTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDrTotal.BackColor = System.Drawing.Color.White
        Me.txtDrTotal.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.txtDrTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDrTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtDrTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtDrTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtDrTotal.IsAllowDigits = True
        Me.txtDrTotal.IsAllowSpace = True
        Me.txtDrTotal.IsAllowSplChars = True
        Me.txtDrTotal.LFocusBackColor = System.Drawing.Color.White
        Me.txtDrTotal.Location = New System.Drawing.Point(227, 4)
        Me.txtDrTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtDrTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.txtDrTotal.Margin = New System.Windows.Forms.Padding(0)
        Me.txtDrTotal.MaxLength = 75
        Me.txtDrTotal.Name = "txtDrTotal"
        Me.txtDrTotal.ReadOnly = True
        Me.txtDrTotal.SetToolTip = Nothing
        Me.txtDrTotal.Size = New System.Drawing.Size(150, 20)
        Me.txtDrTotal.SpecialCharList = "&-/@"
        Me.txtDrTotal.TabIndex = 1
        Me.txtDrTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDrTotal.UseFunctionKeys = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TxtNetTotal)
        Me.Panel3.Controls.Add(Me.TxtCrTotal)
        Me.Panel3.Controls.Add(Me.txtDrTotal)
        Me.Panel3.Controls.Add(Me.ImSlabel1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 269)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(684, 29)
        Me.Panel3.TabIndex = 5
        '
        'ImSlabel1
        '
        Me.ImSlabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(139, 7)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(80, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "Grand Totals"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
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
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.10067!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.56376!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.09549!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.03714!))
        Me.TableLayoutPanel2.Controls.Add(Me.BtnClose, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnPrint, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.MenuStrip1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 437)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(684, 42)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(103, 0)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(146, 41)
        Me.BtnClose.TabIndex = 0
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'BtnPrint
        '
        Me.BtnPrint.AllowToolTip = True
        Me.BtnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrint.BackColor = System.Drawing.Color.White
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(411, 0)
        Me.BtnPrint.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPrint.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.SetToolTip = ""
        Me.BtnPrint.Size = New System.Drawing.Size(147, 41)
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
        Me.MenuStrip1.Size = New System.Drawing.Size(110, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(5, 275)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(65, 13)
        Me.ImSlabel3.TabIndex = 2
        Me.ImSlabel3.Text = "Chat Style"
        '
        'IsCrDrChart
        '
        Me.IsCrDrChart.AutoSize = True
        Me.IsCrDrChart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsCrDrChart.Location = New System.Drawing.Point(5, 323)
        Me.IsCrDrChart.Name = "IsCrDrChart"
        Me.IsCrDrChart.Size = New System.Drawing.Size(145, 17)
        Me.IsCrDrChart.TabIndex = 7
        Me.IsCrDrChart.Text = "Show Both Cr and Dr"
        Me.IsCrDrChart.UseVisualStyleBackColor = True
        '
        'TxtCharType
        '
        Me.TxtCharType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtCharType.FormattingEnabled = True
        Me.TxtCharType.Items.AddRange(New Object() {"Point", "FastPoint", "Bubble", "Line", "Spline", "StepLine", "FastLine", "Bar", "StackedBar", "StackedBar100", "Column", "StackedColumn", "StackedColumn100", "Area", "SplineArea", "StackedArea", "StackedArea100", "Pie", "Doughnut", "Stock", "Candlestick", "Range", "SplineRange", "RangeBar", "RangeColumn", "Radar", "Polar", "ErrorBar", "BoxPlot", "Renko", "ThreeLineBreak", "Kagi", "PointAndFigure", "Funnel", "Pyramid"})
        Me.TxtCharType.Location = New System.Drawing.Point(5, 291)
        Me.TxtCharType.Name = "TxtCharType"
        Me.TxtCharType.Size = New System.Drawing.Size(133, 21)
        Me.TxtCharType.TabIndex = 6
        '
        'TxtMethod
        '
        Me.TxtMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtMethod.FormattingEnabled = True
        Me.TxtMethod.Items.AddRange(New Object() {"Montly", "Yearly"})
        Me.TxtMethod.Location = New System.Drawing.Point(5, 122)
        Me.TxtMethod.Name = "TxtMethod"
        Me.TxtMethod.Size = New System.Drawing.Size(139, 21)
        Me.TxtMethod.TabIndex = 5
        Me.TxtMethod.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtShowDrCrStyle)
        Me.Panel1.Controls.Add(Me.IsCrDrChart)
        Me.Panel1.Controls.Add(Me.TxtCharType)
        Me.Panel1.Controls.Add(Me.TxtMethod)
        Me.Panel1.Controls.Add(Me.ImSlabel3)
        Me.Panel1.Controls.Add(Me.ImSlabel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(687, 30)
        Me.Panel1.Name = "Panel1"
        Me.TableLayoutPanel1.SetRowSpan(Me.Panel1, 3)
        Me.Panel1.Size = New System.Drawing.Size(174, 404)
        Me.Panel1.TabIndex = 3
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(5, 106)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(87, 13)
        Me.ImSlabel2.TabIndex = 2
        Me.ImSlabel2.Text = "Group Method"
        Me.ImSlabel2.Visible = False
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.TxtList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtList.DefaultCellStyle = DataGridViewCellStyle4
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.GridColor = System.Drawing.Color.Gray
        Me.TxtList.Location = New System.Drawing.Point(0, 0)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(684, 242)
        Me.TxtList.TabIndex = 0
        '
        'TxtHeading
        '
        Me.TxtHeading.BackColor = System.Drawing.Color.DarkOrange
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtHeading, 2)
        Me.TxtHeading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHeading.ForeColor = System.Drawing.Color.White
        Me.TxtHeading.Location = New System.Drawing.Point(0, 0)
        Me.TxtHeading.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtHeading.Name = "TxtHeading"
        Me.TxtHeading.Size = New System.Drawing.Size(864, 27)
        Me.TxtHeading.TabIndex = 0
        Me.TxtHeading.Text = "FUND FLOW REPORT"
        Me.TxtHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtList)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 27)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(684, 242)
        Me.Panel2.TabIndex = 2
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtHeading, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Chart1, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.54983!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.45016!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(864, 479)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Chart1
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(3, 301)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(678, 133)
        Me.Chart1.SuppressExceptions = True
        Me.Chart1.TabIndex = 6
        Me.Chart1.Text = "Chart1"
        '
        'FundFlowFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(864, 479)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FundFlowFrm"
        Me.Text = "Funds Flow Report"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtShowDrCrStyle As System.Windows.Forms.CheckBox
    Friend WithEvents TxtNetTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtCrTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents txtDrTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnPrint As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents IsCrDrChart As System.Windows.Forms.CheckBox
    Friend WithEvents TxtCharType As System.Windows.Forms.ComboBox
    Friend WithEvents TxtMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtHeading As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
End Class
