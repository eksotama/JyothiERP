<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CostCenterReportForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CostCenterReportForm))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtBalance = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtTotal1 = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtTotal2 = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtHeading = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtIsDetailed = New System.Windows.Forms.CheckBox()
        Me.TxtCostGroups = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtPrimaryGroups = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtAccountGroups = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtLedgername = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.IsDateWiseOn = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnPrint = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TxtSubTitle = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TxtBalance)
        Me.Panel3.Controls.Add(Me.TxtTotal1)
        Me.Panel3.Controls.Add(Me.TxtTotal2)
        Me.Panel3.Controls.Add(Me.ImSlabel3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 490)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(690, 27)
        Me.Panel3.TabIndex = 6
        '
        'TxtBalance
        '
        Me.TxtBalance.AllowToolTip = True
        Me.TxtBalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBalance.BackColor = System.Drawing.Color.White
        Me.TxtBalance.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBalance.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtBalance.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtBalance.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtBalance.IsAllowDigits = True
        Me.TxtBalance.IsAllowSpace = True
        Me.TxtBalance.IsAllowSplChars = True
        Me.TxtBalance.LFocusBackColor = System.Drawing.Color.White
        Me.TxtBalance.Location = New System.Drawing.Point(519, 2)
        Me.TxtBalance.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtBalance.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtBalance.MaxLength = 75
        Me.TxtBalance.Name = "TxtBalance"
        Me.TxtBalance.ReadOnly = True
        Me.TxtBalance.SetToolTip = Nothing
        Me.TxtBalance.Size = New System.Drawing.Size(160, 21)
        Me.TxtBalance.SpecialCharList = "&-/@"
        Me.TxtBalance.TabIndex = 17
        Me.TxtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtBalance.UseFunctionKeys = False
        '
        'TxtTotal1
        '
        Me.TxtTotal1.AllowToolTip = True
        Me.TxtTotal1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotal1.BackColor = System.Drawing.Color.White
        Me.TxtTotal1.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtTotal1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal1.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTotal1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTotal1.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtTotal1.IsAllowDigits = True
        Me.TxtTotal1.IsAllowSpace = True
        Me.TxtTotal1.IsAllowSplChars = True
        Me.TxtTotal1.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTotal1.Location = New System.Drawing.Point(187, 3)
        Me.TxtTotal1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTotal1.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtTotal1.MaxLength = 75
        Me.TxtTotal1.Name = "TxtTotal1"
        Me.TxtTotal1.ReadOnly = True
        Me.TxtTotal1.SetToolTip = Nothing
        Me.TxtTotal1.Size = New System.Drawing.Size(160, 21)
        Me.TxtTotal1.SpecialCharList = "&-/@"
        Me.TxtTotal1.TabIndex = 17
        Me.TxtTotal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTotal1.UseFunctionKeys = False
        '
        'TxtTotal2
        '
        Me.TxtTotal2.AllowToolTip = True
        Me.TxtTotal2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotal2.BackColor = System.Drawing.Color.White
        Me.TxtTotal2.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtTotal2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal2.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTotal2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTotal2.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtTotal2.IsAllowDigits = True
        Me.TxtTotal2.IsAllowSpace = True
        Me.TxtTotal2.IsAllowSplChars = True
        Me.TxtTotal2.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTotal2.Location = New System.Drawing.Point(353, 3)
        Me.TxtTotal2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTotal2.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtTotal2.MaxLength = 75
        Me.TxtTotal2.Name = "TxtTotal2"
        Me.TxtTotal2.ReadOnly = True
        Me.TxtTotal2.SetToolTip = Nothing
        Me.TxtTotal2.Size = New System.Drawing.Size(160, 21)
        Me.TxtTotal2.SpecialCharList = "&-/@"
        Me.TxtTotal2.TabIndex = 18
        Me.TxtTotal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTotal2.UseFunctionKeys = False
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(12, 6)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(42, 13)
        Me.ImSlabel3.TabIndex = 16
        Me.ImSlabel3.Text = "Totals"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 223.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtHeading, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtSubTitle, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(913, 563)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'TxtHeading
        '
        Me.TxtHeading.BackColor = System.Drawing.Color.Green
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtHeading, 2)
        Me.TxtHeading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHeading.ForeColor = System.Drawing.Color.White
        Me.TxtHeading.Location = New System.Drawing.Point(0, 0)
        Me.TxtHeading.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtHeading.Name = "TxtHeading"
        Me.TxtHeading.Size = New System.Drawing.Size(913, 25)
        Me.TxtHeading.TabIndex = 0
        Me.TxtHeading.Text = "COST CENTER SUMMARY REPORT"
        Me.TxtHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtList)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 54)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(690, 436)
        Me.Panel2.TabIndex = 2
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
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
        Me.TxtList.Size = New System.Drawing.Size(690, 436)
        Me.TxtList.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtIsDetailed)
        Me.Panel1.Controls.Add(Me.TxtCostGroups)
        Me.Panel1.Controls.Add(Me.TxtPrimaryGroups)
        Me.Panel1.Controls.Add(Me.TxtAccountGroups)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TxtLedgername)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.ImsButton1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TxtEndDate)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TxtStartDate)
        Me.Panel1.Controls.Add(Me.IsDateWiseOn)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(693, 57)
        Me.Panel1.Name = "Panel1"
        Me.TableLayoutPanel1.SetRowSpan(Me.Panel1, 2)
        Me.Panel1.Size = New System.Drawing.Size(217, 457)
        Me.Panel1.TabIndex = 0
        '
        'TxtIsDetailed
        '
        Me.TxtIsDetailed.AutoSize = True
        Me.TxtIsDetailed.Location = New System.Drawing.Point(6, 144)
        Me.TxtIsDetailed.Name = "TxtIsDetailed"
        Me.TxtIsDetailed.Size = New System.Drawing.Size(91, 17)
        Me.TxtIsDetailed.TabIndex = 45
        Me.TxtIsDetailed.Text = "Detailed View"
        Me.TxtIsDetailed.UseVisualStyleBackColor = True
        '
        'TxtCostGroups
        '
        Me.TxtCostGroups.AllowEmpty = True
        Me.TxtCostGroups.AllowOnlyListValues = True
        Me.TxtCostGroups.AllowToolTip = True
        Me.TxtCostGroups.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtCostGroups.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtCostGroups.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtCostGroups.FormattingEnabled = True
        Me.TxtCostGroups.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCostGroups.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCostGroups.IsAdvanceSearchWindow = False
        Me.TxtCostGroups.IsAllowDigits = True
        Me.TxtCostGroups.IsAllowSpace = True
        Me.TxtCostGroups.IsAllowSplChars = True
        Me.TxtCostGroups.IsAllowToolTip = True
        Me.TxtCostGroups.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCostGroups.Location = New System.Drawing.Point(6, 270)
        Me.TxtCostGroups.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCostGroups.Name = "TxtCostGroups"
        Me.TxtCostGroups.SetToolTip = Nothing
        Me.TxtCostGroups.Size = New System.Drawing.Size(204, 21)
        Me.TxtCostGroups.Sorted = True
        Me.TxtCostGroups.SpecialCharList = "&-/@"
        Me.TxtCostGroups.TabIndex = 3
        Me.TxtCostGroups.UseFunctionKeys = False
        '
        'TxtPrimaryGroups
        '
        Me.TxtPrimaryGroups.AllowEmpty = True
        Me.TxtPrimaryGroups.AllowOnlyListValues = True
        Me.TxtPrimaryGroups.AllowToolTip = True
        Me.TxtPrimaryGroups.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtPrimaryGroups.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtPrimaryGroups.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtPrimaryGroups.FormattingEnabled = True
        Me.TxtPrimaryGroups.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPrimaryGroups.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPrimaryGroups.IsAdvanceSearchWindow = False
        Me.TxtPrimaryGroups.IsAllowDigits = True
        Me.TxtPrimaryGroups.IsAllowSpace = True
        Me.TxtPrimaryGroups.IsAllowSplChars = True
        Me.TxtPrimaryGroups.IsAllowToolTip = True
        Me.TxtPrimaryGroups.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPrimaryGroups.Location = New System.Drawing.Point(3, 210)
        Me.TxtPrimaryGroups.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPrimaryGroups.Name = "TxtPrimaryGroups"
        Me.TxtPrimaryGroups.SetToolTip = Nothing
        Me.TxtPrimaryGroups.Size = New System.Drawing.Size(204, 21)
        Me.TxtPrimaryGroups.Sorted = True
        Me.TxtPrimaryGroups.SpecialCharList = "&-/@"
        Me.TxtPrimaryGroups.TabIndex = 3
        Me.TxtPrimaryGroups.UseFunctionKeys = False
        '
        'TxtAccountGroups
        '
        Me.TxtAccountGroups.AllowEmpty = True
        Me.TxtAccountGroups.AllowOnlyListValues = True
        Me.TxtAccountGroups.AllowToolTip = True
        Me.TxtAccountGroups.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtAccountGroups.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtAccountGroups.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtAccountGroups.FormattingEnabled = True
        Me.TxtAccountGroups.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtAccountGroups.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtAccountGroups.IsAdvanceSearchWindow = False
        Me.TxtAccountGroups.IsAllowDigits = True
        Me.TxtAccountGroups.IsAllowSpace = True
        Me.TxtAccountGroups.IsAllowSplChars = True
        Me.TxtAccountGroups.IsAllowToolTip = True
        Me.TxtAccountGroups.LFocusBackColor = System.Drawing.Color.White
        Me.TxtAccountGroups.Location = New System.Drawing.Point(7, 344)
        Me.TxtAccountGroups.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtAccountGroups.Name = "TxtAccountGroups"
        Me.TxtAccountGroups.SetToolTip = Nothing
        Me.TxtAccountGroups.Size = New System.Drawing.Size(204, 21)
        Me.TxtAccountGroups.Sorted = True
        Me.TxtAccountGroups.SpecialCharList = "&-/@"
        Me.TxtAccountGroups.TabIndex = 3
        Me.TxtAccountGroups.UseFunctionKeys = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 252)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 15)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "By Cost Names"
        '
        'TxtLedgername
        '
        Me.TxtLedgername.AllowEmpty = True
        Me.TxtLedgername.AllowOnlyListValues = True
        Me.TxtLedgername.AllowToolTip = True
        Me.TxtLedgername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtLedgername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtLedgername.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtLedgername.FormattingEnabled = True
        Me.TxtLedgername.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLedgername.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLedgername.IsAdvanceSearchWindow = False
        Me.TxtLedgername.IsAllowDigits = True
        Me.TxtLedgername.IsAllowSpace = True
        Me.TxtLedgername.IsAllowSplChars = True
        Me.TxtLedgername.IsAllowToolTip = True
        Me.TxtLedgername.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLedgername.Location = New System.Drawing.Point(7, 405)
        Me.TxtLedgername.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLedgername.Name = "TxtLedgername"
        Me.TxtLedgername.SetToolTip = Nothing
        Me.TxtLedgername.Size = New System.Drawing.Size(204, 21)
        Me.TxtLedgername.Sorted = True
        Me.TxtLedgername.SpecialCharList = "&-/@"
        Me.TxtLedgername.TabIndex = 3
        Me.TxtLedgername.UseFunctionKeys = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(154, 15)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "By Primary Cost Cotegories"
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = CType(resources.GetObject("ImsButton1.Image"), System.Drawing.Image)
        Me.ImsButton1.Location = New System.Drawing.Point(53, 80)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(155, 45)
        Me.ImsButton1.TabIndex = 2
        Me.ImsButton1.Text = "Load"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 326)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 15)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "By Account Groups"
        '
        'TxtEndDate
        '
        Me.TxtEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEndDate.Location = New System.Drawing.Point(65, 54)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(147, 20)
        Me.TxtEndDate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 387)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 15)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "By Ledger Accounts"
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
        Me.TxtStartDate.Size = New System.Drawing.Size(147, 20)
        Me.TxtStartDate.TabIndex = 0
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
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.09549!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.03714!))
        Me.TableLayoutPanel2.Controls.Add(Me.BtnPrint, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnClose, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.MenuStrip1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 517)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(690, 46)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'BtnPrint
        '
        Me.BtnPrint.AllowToolTip = True
        Me.BtnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnPrint.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.print__1_
        Me.BtnPrint.Location = New System.Drawing.Point(411, 0)
        Me.BtnPrint.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPrint.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.SetToolTip = ""
        Me.BtnPrint.Size = New System.Drawing.Size(154, 46)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseFunctionKeys = False
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(172, 0)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(144, 46)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(176, 24)
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
        'TxtSubTitle
        '
        Me.TxtSubTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtSubTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubTitle.Location = New System.Drawing.Point(3, 25)
        Me.TxtSubTitle.Name = "TxtSubTitle"
        Me.TxtSubTitle.Size = New System.Drawing.Size(684, 29)
        Me.TxtSubTitle.TabIndex = 7
        Me.TxtSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CostCenterReportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 563)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CostCenterReportForm"
        Me.Text = "Cost Center Report"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtTotal1 As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TxtTotal2 As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtHeading As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtLedgername As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents IsDateWiseOn As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnPrint As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxtCostGroups As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtPrimaryGroups As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtAccountGroups As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtIsDetailed As System.Windows.Forms.CheckBox
    Friend WithEvents TxtBalance As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtSubTitle As JyothiPharmaERPSystem3.IMSlabel
End Class
