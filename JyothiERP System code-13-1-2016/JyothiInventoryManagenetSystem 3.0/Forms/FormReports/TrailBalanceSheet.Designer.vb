<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrailBalanceSheet
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetailedToolStrimMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtOpDr = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtOpCr = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtTdr = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtTCr = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtClosingBalanceDr = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtClosingBalanceCr = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.tPrimary = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TLedger = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Topdr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.topcr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TDr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tcr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tclosing = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tCloCr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtHeading = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.lblop3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.lblt3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.lblop2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.lblt2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.lblOp1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.lblt1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtShowWithOpeningStock = New System.Windows.Forms.CheckBox()
        Me.ShowNetTransactions = New System.Windows.Forms.CheckBox()
        Me.TxtSupressZeros = New System.Windows.Forms.CheckBox()
        Me.TxtShowOpeiningBalances = New System.Windows.Forms.CheckBox()
        Me.TxtShowAllGroups = New System.Windows.Forms.CheckBox()
        Me.TxtShowDetailed = New System.Windows.Forms.CheckBox()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnPrint = New JyothiPharmaERPSystem3.IMSButton()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(118, 3)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(58, 24)
        Me.MenuStrip1.TabIndex = 1
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
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TxtOpDr)
        Me.Panel3.Controls.Add(Me.TxtOpCr)
        Me.Panel3.Controls.Add(Me.TxtTdr)
        Me.Panel3.Controls.Add(Me.TxtTCr)
        Me.Panel3.Controls.Add(Me.TxtClosingBalanceDr)
        Me.Panel3.Controls.Add(Me.TxtClosingBalanceCr)
        Me.Panel3.Controls.Add(Me.ImSlabel1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 475)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(865, 27)
        Me.Panel3.TabIndex = 5
        '
        'TxtOpDr
        '
        Me.TxtOpDr.AllowToolTip = True
        Me.TxtOpDr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtOpDr.BackColor = System.Drawing.Color.White
        Me.TxtOpDr.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtOpDr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOpDr.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtOpDr.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtOpDr.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtOpDr.IsAllowDigits = True
        Me.TxtOpDr.IsAllowSpace = True
        Me.TxtOpDr.IsAllowSplChars = True
        Me.TxtOpDr.LFocusBackColor = System.Drawing.Color.White
        Me.TxtOpDr.Location = New System.Drawing.Point(145, 4)
        Me.TxtOpDr.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtOpDr.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtOpDr.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtOpDr.MaxLength = 75
        Me.TxtOpDr.Name = "TxtOpDr"
        Me.TxtOpDr.ReadOnly = True
        Me.TxtOpDr.SetToolTip = Nothing
        Me.TxtOpDr.Size = New System.Drawing.Size(120, 20)
        Me.TxtOpDr.SpecialCharList = "&-/@"
        Me.TxtOpDr.TabIndex = 1
        Me.TxtOpDr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtOpDr.UseFunctionKeys = False
        '
        'TxtOpCr
        '
        Me.TxtOpCr.AllowToolTip = True
        Me.TxtOpCr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtOpCr.BackColor = System.Drawing.Color.White
        Me.TxtOpCr.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtOpCr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOpCr.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtOpCr.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtOpCr.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtOpCr.IsAllowDigits = True
        Me.TxtOpCr.IsAllowSpace = True
        Me.TxtOpCr.IsAllowSplChars = True
        Me.TxtOpCr.LFocusBackColor = System.Drawing.Color.White
        Me.TxtOpCr.Location = New System.Drawing.Point(265, 4)
        Me.TxtOpCr.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtOpCr.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtOpCr.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtOpCr.MaxLength = 75
        Me.TxtOpCr.Name = "TxtOpCr"
        Me.TxtOpCr.ReadOnly = True
        Me.TxtOpCr.SetToolTip = Nothing
        Me.TxtOpCr.Size = New System.Drawing.Size(120, 20)
        Me.TxtOpCr.SpecialCharList = "&-/@"
        Me.TxtOpCr.TabIndex = 1
        Me.TxtOpCr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtOpCr.UseFunctionKeys = False
        '
        'TxtTdr
        '
        Me.TxtTdr.AllowToolTip = True
        Me.TxtTdr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTdr.BackColor = System.Drawing.Color.White
        Me.TxtTdr.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtTdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTdr.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTdr.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTdr.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtTdr.IsAllowDigits = True
        Me.TxtTdr.IsAllowSpace = True
        Me.TxtTdr.IsAllowSplChars = True
        Me.TxtTdr.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTdr.Location = New System.Drawing.Point(385, 4)
        Me.TxtTdr.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTdr.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtTdr.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtTdr.MaxLength = 75
        Me.TxtTdr.Name = "TxtTdr"
        Me.TxtTdr.ReadOnly = True
        Me.TxtTdr.SetToolTip = Nothing
        Me.TxtTdr.Size = New System.Drawing.Size(120, 20)
        Me.TxtTdr.SpecialCharList = "&-/@"
        Me.TxtTdr.TabIndex = 1
        Me.TxtTdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTdr.UseFunctionKeys = False
        '
        'TxtTCr
        '
        Me.TxtTCr.AllowToolTip = True
        Me.TxtTCr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTCr.BackColor = System.Drawing.Color.White
        Me.TxtTCr.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtTCr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTCr.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTCr.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTCr.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtTCr.IsAllowDigits = True
        Me.TxtTCr.IsAllowSpace = True
        Me.TxtTCr.IsAllowSplChars = True
        Me.TxtTCr.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTCr.Location = New System.Drawing.Point(504, 4)
        Me.TxtTCr.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTCr.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtTCr.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtTCr.MaxLength = 75
        Me.TxtTCr.Name = "TxtTCr"
        Me.TxtTCr.ReadOnly = True
        Me.TxtTCr.SetToolTip = Nothing
        Me.TxtTCr.Size = New System.Drawing.Size(120, 20)
        Me.TxtTCr.SpecialCharList = "&-/@"
        Me.TxtTCr.TabIndex = 1
        Me.TxtTCr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTCr.UseFunctionKeys = False
        '
        'TxtClosingBalanceDr
        '
        Me.TxtClosingBalanceDr.AllowToolTip = True
        Me.TxtClosingBalanceDr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtClosingBalanceDr.BackColor = System.Drawing.Color.White
        Me.TxtClosingBalanceDr.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtClosingBalanceDr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClosingBalanceDr.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtClosingBalanceDr.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtClosingBalanceDr.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtClosingBalanceDr.IsAllowDigits = True
        Me.TxtClosingBalanceDr.IsAllowSpace = True
        Me.TxtClosingBalanceDr.IsAllowSplChars = True
        Me.TxtClosingBalanceDr.LFocusBackColor = System.Drawing.Color.White
        Me.TxtClosingBalanceDr.Location = New System.Drawing.Point(623, 4)
        Me.TxtClosingBalanceDr.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtClosingBalanceDr.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtClosingBalanceDr.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtClosingBalanceDr.MaxLength = 75
        Me.TxtClosingBalanceDr.Name = "TxtClosingBalanceDr"
        Me.TxtClosingBalanceDr.ReadOnly = True
        Me.TxtClosingBalanceDr.SetToolTip = Nothing
        Me.TxtClosingBalanceDr.Size = New System.Drawing.Size(120, 20)
        Me.TxtClosingBalanceDr.SpecialCharList = "&-/@"
        Me.TxtClosingBalanceDr.TabIndex = 1
        Me.TxtClosingBalanceDr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtClosingBalanceDr.UseFunctionKeys = False
        '
        'TxtClosingBalanceCr
        '
        Me.TxtClosingBalanceCr.AllowToolTip = True
        Me.TxtClosingBalanceCr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtClosingBalanceCr.BackColor = System.Drawing.Color.White
        Me.TxtClosingBalanceCr.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtClosingBalanceCr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClosingBalanceCr.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtClosingBalanceCr.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtClosingBalanceCr.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtClosingBalanceCr.IsAllowDigits = True
        Me.TxtClosingBalanceCr.IsAllowSpace = True
        Me.TxtClosingBalanceCr.IsAllowSplChars = True
        Me.TxtClosingBalanceCr.LFocusBackColor = System.Drawing.Color.White
        Me.TxtClosingBalanceCr.Location = New System.Drawing.Point(742, 4)
        Me.TxtClosingBalanceCr.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtClosingBalanceCr.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtClosingBalanceCr.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtClosingBalanceCr.MaxLength = 75
        Me.TxtClosingBalanceCr.Name = "TxtClosingBalanceCr"
        Me.TxtClosingBalanceCr.ReadOnly = True
        Me.TxtClosingBalanceCr.SetToolTip = Nothing
        Me.TxtClosingBalanceCr.Size = New System.Drawing.Size(120, 20)
        Me.TxtClosingBalanceCr.SpecialCharList = "&-/@"
        Me.TxtClosingBalanceCr.TabIndex = 1
        Me.TxtClosingBalanceCr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtClosingBalanceCr.UseFunctionKeys = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(2, 7)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(80, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "Grand Totals"
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToResizeColumns = False
        Me.TxtList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tPrimary, Me.tsno, Me.TLedger, Me.Topdr, Me.topcr, Me.TDr, Me.tcr, Me.tclosing, Me.tCloCr})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtList.DefaultCellStyle = DataGridViewCellStyle8
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.Location = New System.Drawing.Point(0, 0)
        Me.TxtList.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.RowHeadersVisible = False
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(865, 411)
        Me.TxtList.TabIndex = 0
        '
        'tPrimary
        '
        Me.tPrimary.HeaderText = "Primary"
        Me.tPrimary.Name = "tPrimary"
        Me.tPrimary.Visible = False
        '
        'tsno
        '
        Me.tsno.HeaderText = "sno"
        Me.tsno.Name = "tsno"
        Me.tsno.Visible = False
        '
        'TLedger
        '
        Me.TLedger.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TLedger.HeaderText = "Particulars"
        Me.TLedger.Name = "TLedger"
        '
        'Topdr
        '
        Me.Topdr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Topdr.DefaultCellStyle = DataGridViewCellStyle2
        Me.Topdr.HeaderText = "Opening Dr"
        Me.Topdr.Name = "Topdr"
        Me.Topdr.Width = 120
        '
        'topcr
        '
        Me.topcr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.topcr.DefaultCellStyle = DataGridViewCellStyle3
        Me.topcr.HeaderText = "Opening Cr"
        Me.topcr.Name = "topcr"
        Me.topcr.Width = 120
        '
        'TDr
        '
        Me.TDr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.TDr.DefaultCellStyle = DataGridViewCellStyle4
        Me.TDr.HeaderText = "Transaction Dr"
        Me.TDr.Name = "TDr"
        Me.TDr.Width = 120
        '
        'tcr
        '
        Me.tcr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.tcr.DefaultCellStyle = DataGridViewCellStyle5
        Me.tcr.HeaderText = "Transaction Cr"
        Me.tcr.Name = "tcr"
        Me.tcr.Width = 120
        '
        'tclosing
        '
        Me.tclosing.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.tclosing.DefaultCellStyle = DataGridViewCellStyle6
        Me.tclosing.HeaderText = "Closing Balance"
        Me.tclosing.Name = "tclosing"
        Me.tclosing.Width = 120
        '
        'tCloCr
        '
        Me.tCloCr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.tCloCr.DefaultCellStyle = DataGridViewCellStyle7
        Me.tCloCr.HeaderText = "Closingcr"
        Me.tCloCr.Name = "tCloCr"
        Me.tCloCr.Width = 120
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtList)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 64)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(865, 411)
        Me.Panel2.TabIndex = 2
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtHeading, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1014, 502)
        Me.TableLayoutPanel1.TabIndex = 1
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
        Me.TxtHeading.Size = New System.Drawing.Size(1014, 27)
        Me.TxtHeading.TabIndex = 0
        Me.TxtHeading.Text = "TRIAL BALANCE SHEET"
        Me.TxtHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.ImSlabel2)
        Me.Panel4.Controls.Add(Me.lblop3)
        Me.Panel4.Controls.Add(Me.ImSlabel4)
        Me.Panel4.Controls.Add(Me.lblt3)
        Me.Panel4.Controls.Add(Me.ImSlabel3)
        Me.Panel4.Controls.Add(Me.lblop2)
        Me.Panel4.Controls.Add(Me.lblt2)
        Me.Panel4.Controls.Add(Me.MenuStrip1)
        Me.Panel4.Controls.Add(Me.lblOp1)
        Me.Panel4.Controls.Add(Me.lblt1)
        Me.Panel4.Controls.Add(Me.ImSlabel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 27)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(865, 37)
        Me.Panel4.TabIndex = 6
        '
        'ImSlabel2
        '
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(3, 17)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(112, 16)
        Me.ImSlabel2.TabIndex = 6
        Me.ImSlabel2.Text = "Particulars"
        '
        'lblop3
        '
        Me.lblop3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblop3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblop3.Location = New System.Drawing.Point(265, 19)
        Me.lblop3.Name = "lblop3"
        Me.lblop3.Size = New System.Drawing.Size(120, 16)
        Me.lblop3.TabIndex = 6
        Me.lblop3.Text = "Credit"
        Me.lblop3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ImSlabel4
        '
        Me.ImSlabel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(744, 19)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(120, 16)
        Me.ImSlabel4.TabIndex = 6
        Me.ImSlabel4.Text = "Credit"
        Me.ImSlabel4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblt3
        '
        Me.lblt3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblt3.Location = New System.Drawing.Point(505, 19)
        Me.lblt3.Name = "lblt3"
        Me.lblt3.Size = New System.Drawing.Size(120, 16)
        Me.lblt3.TabIndex = 6
        Me.lblt3.Text = "Credit"
        Me.lblt3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ImSlabel3
        '
        Me.ImSlabel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(624, 19)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(120, 16)
        Me.ImSlabel3.TabIndex = 6
        Me.ImSlabel3.Text = "Debit"
        Me.ImSlabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblop2
        '
        Me.lblop2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblop2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblop2.Location = New System.Drawing.Point(145, 19)
        Me.lblop2.Name = "lblop2"
        Me.lblop2.Size = New System.Drawing.Size(120, 16)
        Me.lblop2.TabIndex = 6
        Me.lblop2.Text = "Debit"
        Me.lblop2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblt2
        '
        Me.lblt2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblt2.Location = New System.Drawing.Point(385, 19)
        Me.lblt2.Name = "lblt2"
        Me.lblt2.Size = New System.Drawing.Size(120, 16)
        Me.lblt2.TabIndex = 6
        Me.lblt2.Text = "Debit"
        Me.lblt2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOp1
        '
        Me.lblOp1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOp1.Location = New System.Drawing.Point(145, 3)
        Me.lblOp1.Name = "lblOp1"
        Me.lblOp1.Size = New System.Drawing.Size(240, 16)
        Me.lblOp1.TabIndex = 6
        Me.lblOp1.Text = "Opening Balances"
        Me.lblOp1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblt1
        '
        Me.lblt1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblt1.Location = New System.Drawing.Point(385, 3)
        Me.lblt1.Name = "lblt1"
        Me.lblt1.Size = New System.Drawing.Size(240, 16)
        Me.lblt1.TabIndex = 6
        Me.lblt1.Text = "Transactions Balances"
        Me.lblt1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ImSlabel5
        '
        Me.ImSlabel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(630, 4)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(227, 15)
        Me.ImSlabel5.TabIndex = 6
        Me.ImSlabel5.Text = "Closing Balances"
        Me.ImSlabel5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtShowWithOpeningStock)
        Me.Panel1.Controls.Add(Me.ShowNetTransactions)
        Me.Panel1.Controls.Add(Me.TxtSupressZeros)
        Me.Panel1.Controls.Add(Me.TxtShowOpeiningBalances)
        Me.Panel1.Controls.Add(Me.TxtShowAllGroups)
        Me.Panel1.Controls.Add(Me.TxtShowDetailed)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnPrint)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(865, 64)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(149, 411)
        Me.Panel1.TabIndex = 7
        '
        'TxtShowWithOpeningStock
        '
        Me.TxtShowWithOpeningStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShowWithOpeningStock.Location = New System.Drawing.Point(8, 210)
        Me.TxtShowWithOpeningStock.Name = "TxtShowWithOpeningStock"
        Me.TxtShowWithOpeningStock.Size = New System.Drawing.Size(122, 35)
        Me.TxtShowWithOpeningStock.TabIndex = 55
        Me.TxtShowWithOpeningStock.Text = "With Opening Stock Value"
        Me.TxtShowWithOpeningStock.UseVisualStyleBackColor = True
        '
        'ShowNetTransactions
        '
        Me.ShowNetTransactions.Checked = True
        Me.ShowNetTransactions.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowNetTransactions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShowNetTransactions.Location = New System.Drawing.Point(8, 126)
        Me.ShowNetTransactions.Name = "ShowNetTransactions"
        Me.ShowNetTransactions.Size = New System.Drawing.Size(119, 31)
        Me.ShowNetTransactions.TabIndex = 1
        Me.ShowNetTransactions.Text = "Show Net Trasactions"
        Me.ShowNetTransactions.UseVisualStyleBackColor = True
        '
        'TxtSupressZeros
        '
        Me.TxtSupressZeros.Checked = True
        Me.TxtSupressZeros.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TxtSupressZeros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSupressZeros.Location = New System.Drawing.Point(8, 163)
        Me.TxtSupressZeros.Name = "TxtSupressZeros"
        Me.TxtSupressZeros.Size = New System.Drawing.Size(119, 31)
        Me.TxtSupressZeros.TabIndex = 1
        Me.TxtSupressZeros.Text = "Suppress Zeros"
        Me.TxtSupressZeros.UseVisualStyleBackColor = True
        '
        'TxtShowOpeiningBalances
        '
        Me.TxtShowOpeiningBalances.Checked = True
        Me.TxtShowOpeiningBalances.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TxtShowOpeiningBalances.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShowOpeiningBalances.Location = New System.Drawing.Point(8, 89)
        Me.TxtShowOpeiningBalances.Name = "TxtShowOpeiningBalances"
        Me.TxtShowOpeiningBalances.Size = New System.Drawing.Size(119, 31)
        Me.TxtShowOpeiningBalances.TabIndex = 1
        Me.TxtShowOpeiningBalances.Text = "Show Opening Balances"
        Me.TxtShowOpeiningBalances.UseVisualStyleBackColor = True
        '
        'TxtShowAllGroups
        '
        Me.TxtShowAllGroups.AutoSize = True
        Me.TxtShowAllGroups.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShowAllGroups.Location = New System.Drawing.Point(8, 57)
        Me.TxtShowAllGroups.Name = "TxtShowAllGroups"
        Me.TxtShowAllGroups.Size = New System.Drawing.Size(119, 17)
        Me.TxtShowAllGroups.TabIndex = 1
        Me.TxtShowAllGroups.Text = "Show All Groups"
        Me.TxtShowAllGroups.UseVisualStyleBackColor = True
        '
        'TxtShowDetailed
        '
        Me.TxtShowDetailed.AutoSize = True
        Me.TxtShowDetailed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShowDetailed.Location = New System.Drawing.Point(8, 21)
        Me.TxtShowDetailed.Name = "TxtShowDetailed"
        Me.TxtShowDetailed.Size = New System.Drawing.Size(104, 17)
        Me.TxtShowDetailed.TabIndex = 1
        Me.TxtShowDetailed.Text = "Detailed View"
        Me.TxtShowDetailed.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(11, 358)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(135, 42)
        Me.BtnClose.TabIndex = 0
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.AllowToolTip = True
        Me.BtnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnPrint.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.print__1_
        Me.BtnPrint.Location = New System.Drawing.Point(12, 295)
        Me.BtnPrint.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPrint.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.SetToolTip = ""
        Me.BtnPrint.Size = New System.Drawing.Size(135, 42)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseFunctionKeys = False
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'TrailBalanceSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 502)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "TrailBalanceSheet"
        Me.Text = "TrialBalanceSheet"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TxtClosingBalanceCr As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnPrint As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TxtHeading As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents lblop3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents lblt3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents lblop2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents lblt2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents lblOp1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents lblt1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtOpDr As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtOpCr As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtTdr As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtTCr As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents DetailedToolStrimMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtShowDetailed As System.Windows.Forms.CheckBox
    Friend WithEvents TxtShowAllGroups As System.Windows.Forms.CheckBox
    Friend WithEvents TxtShowOpeiningBalances As System.Windows.Forms.CheckBox
    Friend WithEvents ShowNetTransactions As System.Windows.Forms.CheckBox
    Friend WithEvents TxtSupressZeros As System.Windows.Forms.CheckBox
    Friend WithEvents TxtClosingBalanceDr As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents tPrimary As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tsno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TLedger As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Topdr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents topcr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TDr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tcr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tclosing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tCloCr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtShowWithOpeningStock As System.Windows.Forms.CheckBox
End Class
