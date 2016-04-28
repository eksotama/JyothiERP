<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LedgerTransactionsReportForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LedgerTransactionsReportForm))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtNetDrTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtNetCrTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtOpCrTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtOpDrTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtCrTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.txtDrTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtCurrencyName = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtIsCurrency = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnPrint = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtUserWise = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtLocationWise = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.btnsendemail = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.IsDateWiseOn = New System.Windows.Forms.CheckBox()
        Me.TxtLedgerName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.lblGroupWise = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtShowNarration = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtHeading = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(179, 24)
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
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TxtNetDrTotal)
        Me.Panel3.Controls.Add(Me.TxtNetCrTotal)
        Me.Panel3.Controls.Add(Me.TxtOpCrTotal)
        Me.Panel3.Controls.Add(Me.TxtOpDrTotal)
        Me.Panel3.Controls.Add(Me.TxtCrTotal)
        Me.Panel3.Controls.Add(Me.txtDrTotal)
        Me.Panel3.Controls.Add(Me.TxtCurrencyName)
        Me.Panel3.Controls.Add(Me.ImSlabel3)
        Me.Panel3.Controls.Add(Me.ImSlabel2)
        Me.Panel3.Controls.Add(Me.ImSlabel1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 418)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(684, 66)
        Me.Panel3.TabIndex = 5
        '
        'TxtNetDrTotal
        '
        Me.TxtNetDrTotal.AllowToolTip = True
        Me.TxtNetDrTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNetDrTotal.BackColor = System.Drawing.Color.White
        Me.TxtNetDrTotal.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtNetDrTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetDrTotal.ForeColor = System.Drawing.Color.Black
        Me.TxtNetDrTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNetDrTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNetDrTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtNetDrTotal.IsAllowDigits = True
        Me.TxtNetDrTotal.IsAllowSpace = True
        Me.TxtNetDrTotal.IsAllowSplChars = True
        Me.TxtNetDrTotal.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNetDrTotal.Location = New System.Drawing.Point(362, 42)
        Me.TxtNetDrTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNetDrTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtNetDrTotal.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtNetDrTotal.MaxLength = 75
        Me.TxtNetDrTotal.Name = "TxtNetDrTotal"
        Me.TxtNetDrTotal.ReadOnly = True
        Me.TxtNetDrTotal.SetToolTip = Nothing
        Me.TxtNetDrTotal.Size = New System.Drawing.Size(150, 20)
        Me.TxtNetDrTotal.SpecialCharList = "&-/@"
        Me.TxtNetDrTotal.TabIndex = 1
        Me.TxtNetDrTotal.Text = "0"
        Me.TxtNetDrTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNetDrTotal.UseFunctionKeys = False
        '
        'TxtNetCrTotal
        '
        Me.TxtNetCrTotal.AllowToolTip = True
        Me.TxtNetCrTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNetCrTotal.BackColor = System.Drawing.Color.White
        Me.TxtNetCrTotal.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtNetCrTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetCrTotal.ForeColor = System.Drawing.Color.Black
        Me.TxtNetCrTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNetCrTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNetCrTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtNetCrTotal.IsAllowDigits = True
        Me.TxtNetCrTotal.IsAllowSpace = True
        Me.TxtNetCrTotal.IsAllowSplChars = True
        Me.TxtNetCrTotal.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNetCrTotal.Location = New System.Drawing.Point(512, 42)
        Me.TxtNetCrTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNetCrTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtNetCrTotal.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtNetCrTotal.MaxLength = 75
        Me.TxtNetCrTotal.Name = "TxtNetCrTotal"
        Me.TxtNetCrTotal.ReadOnly = True
        Me.TxtNetCrTotal.SetToolTip = Nothing
        Me.TxtNetCrTotal.Size = New System.Drawing.Size(150, 20)
        Me.TxtNetCrTotal.SpecialCharList = "&-/@"
        Me.TxtNetCrTotal.TabIndex = 1
        Me.TxtNetCrTotal.Text = "0"
        Me.TxtNetCrTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNetCrTotal.UseFunctionKeys = False
        '
        'TxtOpCrTotal
        '
        Me.TxtOpCrTotal.AllowToolTip = True
        Me.TxtOpCrTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtOpCrTotal.BackColor = System.Drawing.Color.White
        Me.TxtOpCrTotal.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtOpCrTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOpCrTotal.ForeColor = System.Drawing.Color.Black
        Me.TxtOpCrTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtOpCrTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtOpCrTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtOpCrTotal.IsAllowDigits = True
        Me.TxtOpCrTotal.IsAllowSpace = True
        Me.TxtOpCrTotal.IsAllowSplChars = True
        Me.TxtOpCrTotal.LFocusBackColor = System.Drawing.Color.White
        Me.TxtOpCrTotal.Location = New System.Drawing.Point(512, 1)
        Me.TxtOpCrTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtOpCrTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtOpCrTotal.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtOpCrTotal.MaxLength = 75
        Me.TxtOpCrTotal.Name = "TxtOpCrTotal"
        Me.TxtOpCrTotal.ReadOnly = True
        Me.TxtOpCrTotal.SetToolTip = Nothing
        Me.TxtOpCrTotal.Size = New System.Drawing.Size(150, 20)
        Me.TxtOpCrTotal.SpecialCharList = "&-/@"
        Me.TxtOpCrTotal.TabIndex = 1
        Me.TxtOpCrTotal.Text = "0"
        Me.TxtOpCrTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtOpCrTotal.UseFunctionKeys = False
        '
        'TxtOpDrTotal
        '
        Me.TxtOpDrTotal.AllowToolTip = True
        Me.TxtOpDrTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtOpDrTotal.BackColor = System.Drawing.Color.White
        Me.TxtOpDrTotal.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtOpDrTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOpDrTotal.ForeColor = System.Drawing.Color.Black
        Me.TxtOpDrTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtOpDrTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtOpDrTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtOpDrTotal.IsAllowDigits = True
        Me.TxtOpDrTotal.IsAllowSpace = True
        Me.TxtOpDrTotal.IsAllowSplChars = True
        Me.TxtOpDrTotal.LFocusBackColor = System.Drawing.Color.White
        Me.TxtOpDrTotal.Location = New System.Drawing.Point(362, 1)
        Me.TxtOpDrTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtOpDrTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtOpDrTotal.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtOpDrTotal.MaxLength = 75
        Me.TxtOpDrTotal.Name = "TxtOpDrTotal"
        Me.TxtOpDrTotal.ReadOnly = True
        Me.TxtOpDrTotal.SetToolTip = Nothing
        Me.TxtOpDrTotal.Size = New System.Drawing.Size(150, 20)
        Me.TxtOpDrTotal.SpecialCharList = "&-/@"
        Me.TxtOpDrTotal.TabIndex = 1
        Me.TxtOpDrTotal.Text = "0"
        Me.TxtOpDrTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtOpDrTotal.UseFunctionKeys = False
        '
        'TxtCrTotal
        '
        Me.TxtCrTotal.AllowToolTip = True
        Me.TxtCrTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCrTotal.BackColor = System.Drawing.Color.White
        Me.TxtCrTotal.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtCrTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCrTotal.ForeColor = System.Drawing.Color.Black
        Me.TxtCrTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCrTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCrTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtCrTotal.IsAllowDigits = True
        Me.TxtCrTotal.IsAllowSpace = True
        Me.TxtCrTotal.IsAllowSplChars = True
        Me.TxtCrTotal.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCrTotal.Location = New System.Drawing.Point(512, 22)
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
        Me.TxtCrTotal.Text = "0"
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
        Me.txtDrTotal.ForeColor = System.Drawing.Color.Black
        Me.txtDrTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtDrTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtDrTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtDrTotal.IsAllowDigits = True
        Me.txtDrTotal.IsAllowSpace = True
        Me.txtDrTotal.IsAllowSplChars = True
        Me.txtDrTotal.LFocusBackColor = System.Drawing.Color.White
        Me.txtDrTotal.Location = New System.Drawing.Point(362, 22)
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
        Me.txtDrTotal.Text = "0"
        Me.txtDrTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDrTotal.UseFunctionKeys = False
        '
        'TxtCurrencyName
        '
        Me.TxtCurrencyName.AutoSize = True
        Me.TxtCurrencyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCurrencyName.Location = New System.Drawing.Point(12, 24)
        Me.TxtCurrencyName.Name = "TxtCurrencyName"
        Me.TxtCurrencyName.Size = New System.Drawing.Size(80, 13)
        Me.TxtCurrencyName.TabIndex = 0
        Me.TxtCurrencyName.Text = "Grand Totals"
        '
        'ImSlabel3
        '
        Me.ImSlabel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(258, 4)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(104, 13)
        Me.ImSlabel3.TabIndex = 0
        Me.ImSlabel3.Text = "Opening Balance"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(258, 44)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(98, 13)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "Closing Balance"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(258, 24)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(81, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "Current Total"
        '
        'TxtIsCurrency
        '
        Me.TxtIsCurrency.AutoSize = True
        Me.TxtIsCurrency.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsCurrency.Location = New System.Drawing.Point(14, 413)
        Me.TxtIsCurrency.Name = "TxtIsCurrency"
        Me.TxtIsCurrency.Size = New System.Drawing.Size(143, 17)
        Me.TxtIsCurrency.TabIndex = 0
        Me.TxtIsCurrency.Text = "Show Currency Wise"
        Me.TxtIsCurrency.UseVisualStyleBackColor = True
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 484)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(684, 38)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(170, 0)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(148, 38)
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
        Me.BtnPrint.Location = New System.Drawing.Point(405, 0)
        Me.BtnPrint.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPrint.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.SetToolTip = ""
        Me.BtnPrint.Size = New System.Drawing.Size(154, 38)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseFunctionKeys = False
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ImSlabel8)
        Me.Panel1.Controls.Add(Me.ImSlabel7)
        Me.Panel1.Controls.Add(Me.TxtUserWise)
        Me.Panel1.Controls.Add(Me.TxtLocationWise)
        Me.Panel1.Controls.Add(Me.btnsendemail)
        Me.Panel1.Controls.Add(Me.ImsButton1)
        Me.Panel1.Controls.Add(Me.TxtEndDate)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TxtStartDate)
        Me.Panel1.Controls.Add(Me.IsDateWiseOn)
        Me.Panel1.Controls.Add(Me.TxtLedgerName)
        Me.Panel1.Controls.Add(Me.lblGroupWise)
        Me.Panel1.Controls.Add(Me.TxtShowNarration)
        Me.Panel1.Controls.Add(Me.TxtIsCurrency)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(687, 30)
        Me.Panel1.Name = "Panel1"
        Me.TableLayoutPanel1.SetRowSpan(Me.Panel1, 3)
        Me.Panel1.Size = New System.Drawing.Size(229, 489)
        Me.Panel1.TabIndex = 3
        '
        'ImSlabel8
        '
        Me.ImSlabel8.AutoSize = True
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(12, 242)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(125, 13)
        Me.ImSlabel8.TabIndex = 60
        Me.ImSlabel8.Text = "User/Employee Wise"
        '
        'ImSlabel7
        '
        Me.ImSlabel7.AutoSize = True
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(12, 193)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(99, 13)
        Me.ImSlabel7.TabIndex = 61
        Me.ImSlabel7.Text = "Location/Brach "
        '
        'TxtUserWise
        '
        Me.TxtUserWise.AllowEmpty = True
        Me.TxtUserWise.AllowOnlyListValues = True
        Me.TxtUserWise.AllowToolTip = True
        Me.TxtUserWise.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtUserWise.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtUserWise.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtUserWise.FormattingEnabled = True
        Me.TxtUserWise.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtUserWise.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtUserWise.IsAdvanceSearchWindow = False
        Me.TxtUserWise.IsAllowDigits = True
        Me.TxtUserWise.IsAllowSpace = True
        Me.TxtUserWise.IsAllowSplChars = True
        Me.TxtUserWise.IsAllowToolTip = True
        Me.TxtUserWise.LFocusBackColor = System.Drawing.Color.White
        Me.TxtUserWise.Location = New System.Drawing.Point(13, 258)
        Me.TxtUserWise.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtUserWise.Name = "TxtUserWise"
        Me.TxtUserWise.SetToolTip = Nothing
        Me.TxtUserWise.Size = New System.Drawing.Size(207, 21)
        Me.TxtUserWise.Sorted = True
        Me.TxtUserWise.SpecialCharList = "&-/@"
        Me.TxtUserWise.TabIndex = 58
        Me.TxtUserWise.UseFunctionKeys = False
        '
        'TxtLocationWise
        '
        Me.TxtLocationWise.AllowEmpty = True
        Me.TxtLocationWise.AllowOnlyListValues = True
        Me.TxtLocationWise.AllowToolTip = True
        Me.TxtLocationWise.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtLocationWise.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtLocationWise.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtLocationWise.FormattingEnabled = True
        Me.TxtLocationWise.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLocationWise.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLocationWise.IsAdvanceSearchWindow = False
        Me.TxtLocationWise.IsAllowDigits = True
        Me.TxtLocationWise.IsAllowSpace = True
        Me.TxtLocationWise.IsAllowSplChars = True
        Me.TxtLocationWise.IsAllowToolTip = True
        Me.TxtLocationWise.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLocationWise.Location = New System.Drawing.Point(13, 209)
        Me.TxtLocationWise.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLocationWise.Name = "TxtLocationWise"
        Me.TxtLocationWise.SetToolTip = Nothing
        Me.TxtLocationWise.Size = New System.Drawing.Size(207, 21)
        Me.TxtLocationWise.Sorted = True
        Me.TxtLocationWise.SpecialCharList = "&-/@"
        Me.TxtLocationWise.TabIndex = 59
        Me.TxtLocationWise.UseFunctionKeys = False
        '
        'btnsendemail
        '
        Me.btnsendemail.AllowToolTip = True
        Me.btnsendemail.BackColor = System.Drawing.Color.White
        Me.btnsendemail.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnsendemail.Image = CType(resources.GetObject("btnsendemail.Image"), System.Drawing.Image)
        Me.btnsendemail.Location = New System.Drawing.Point(25, 328)
        Me.btnsendemail.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnsendemail.Name = "btnsendemail"
        Me.btnsendemail.SetToolTip = ""
        Me.btnsendemail.Size = New System.Drawing.Size(132, 31)
        Me.btnsendemail.TabIndex = 48
        Me.btnsendemail.Text = "Send Mail"
        Me.btnsendemail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnsendemail.UseFunctionKeys = False
        Me.btnsendemail.UseVisualStyleBackColor = False
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.BackColor = System.Drawing.Color.White
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
        Me.ImsButton1.UseVisualStyleBackColor = False
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
        Me.TxtLedgerName.Location = New System.Drawing.Point(13, 162)
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
        Me.lblGroupWise.Location = New System.Drawing.Point(10, 146)
        Me.lblGroupWise.Name = "lblGroupWise"
        Me.lblGroupWise.Size = New System.Drawing.Size(140, 13)
        Me.lblGroupWise.TabIndex = 2
        Me.lblGroupWise.Text = "Filter By Account Name"
        '
        'TxtShowNarration
        '
        Me.TxtShowNarration.AutoSize = True
        Me.TxtShowNarration.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShowNarration.Location = New System.Drawing.Point(15, 390)
        Me.TxtShowNarration.Name = "TxtShowNarration"
        Me.TxtShowNarration.Size = New System.Drawing.Size(113, 17)
        Me.TxtShowNarration.TabIndex = 0
        Me.TxtShowNarration.Text = "Show Narration"
        Me.TxtShowNarration.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtList)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 27)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(684, 391)
        Me.Panel2.TabIndex = 2
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
        Me.TxtList.Location = New System.Drawing.Point(0, 0)
        Me.TxtList.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(684, 391)
        Me.TxtList.TabIndex = 0
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(919, 522)
        Me.TableLayoutPanel1.TabIndex = 1
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
        Me.TxtHeading.Size = New System.Drawing.Size(919, 27)
        Me.TxtHeading.TabIndex = 0
        Me.TxtHeading.Text = "TRANSACTIONS SUMMARY"
        Me.TxtHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LedgerTransactionsReportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(919, 522)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "LedgerTransactionsReportForm"
        Me.Text = "Account Trasactions"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxtLedgerName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TxtNetCrTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtCrTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents txtDrTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents lblGroupWise As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtIsCurrency As System.Windows.Forms.CheckBox
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnPrint As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TxtHeading As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtShowNarration As System.Windows.Forms.CheckBox
    Friend WithEvents TxtCurrencyName As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents IsDateWiseOn As System.Windows.Forms.CheckBox
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtNetDrTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtOpCrTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtOpDrTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents btnsendemail As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtUserWise As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtLocationWise As JyothiPharmaERPSystem3.IMSComboBox
End Class
