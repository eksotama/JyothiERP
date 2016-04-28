<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Daybook
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Daybook))
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TxtOtherReports = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtIsPeriod = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtNarrationAslo = New System.Windows.Forms.CheckBox()
        Me.TxtDetailedView = New System.Windows.Forms.CheckBox()
        Me.TxtIsVouchers = New System.Windows.Forms.CheckBox()
        Me.UserButton4 = New JyothiPharmaERPSystem3.IMSButton()
        Me.UserButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.UserButton3 = New JyothiPharmaERPSystem3.IMSButton()
        Me.UserButton2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.txtvoucher = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtReportOptions = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtByLedger = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(3, 11)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(592, 527)
        Me.CrystalReportViewer1.TabIndex = 1
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CrystalReportViewer1.ToolPanelWidth = 100
        '
        'TxtOtherReports
        '
        Me.TxtOtherReports.AllowEmpty = True
        Me.TxtOtherReports.AllowOnlyListValues = False
        Me.TxtOtherReports.AllowToolTip = True
        Me.TxtOtherReports.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtOtherReports.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtOtherReports.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtOtherReports.FormattingEnabled = True
        Me.TxtOtherReports.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtOtherReports.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtOtherReports.IsAllowDigits = True
        Me.TxtOtherReports.IsAllowSpace = True
        Me.TxtOtherReports.IsAllowSplChars = True
        Me.TxtOtherReports.IsAllowToolTip = True
        Me.TxtOtherReports.LFocusBackColor = System.Drawing.Color.White
        Me.TxtOtherReports.Location = New System.Drawing.Point(14, 508)
        Me.TxtOtherReports.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtOtherReports.Name = "TxtOtherReports"
        Me.TxtOtherReports.Size = New System.Drawing.Size(198, 21)
        Me.TxtOtherReports.Sorted = True
        Me.TxtOtherReports.SpecialCharList = "&-/@"
        Me.TxtOtherReports.TabIndex = 39
        Me.TxtOtherReports.UseFunctionKeys = False
        Me.TxtOtherReports.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 388)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 15)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Sort/Arrange By"
        '
        'TxtEndDate
        '
        Me.TxtEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate.Location = New System.Drawing.Point(67, 68)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(156, 20)
        Me.TxtEndDate.TabIndex = 33
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 15)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Ending"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 15)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Starting"
        '
        'TxtStartDate
        '
        Me.TxtStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate.Location = New System.Drawing.Point(67, 42)
        Me.TxtStartDate.Name = "TxtStartDate"
        Me.TxtStartDate.Size = New System.Drawing.Size(156, 20)
        Me.TxtStartDate.TabIndex = 32
        '
        'TxtIsPeriod
        '
        Me.TxtIsPeriod.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIsPeriod.AutoSize = True
        Me.TxtIsPeriod.Checked = True
        Me.TxtIsPeriod.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TxtIsPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsPeriod.Location = New System.Drawing.Point(6, 17)
        Me.TxtIsPeriod.Name = "TxtIsPeriod"
        Me.TxtIsPeriod.Size = New System.Drawing.Size(132, 19)
        Me.TxtIsPeriod.TabIndex = 31
        Me.TxtIsPeriod.Text = "Show By Date Wise"
        Me.TxtIsPeriod.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtByLedger)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtNarrationAslo)
        Me.GroupBox1.Controls.Add(Me.TxtDetailedView)
        Me.GroupBox1.Controls.Add(Me.TxtIsVouchers)
        Me.GroupBox1.Controls.Add(Me.UserButton4)
        Me.GroupBox1.Controls.Add(Me.UserButton1)
        Me.GroupBox1.Controls.Add(Me.UserButton3)
        Me.GroupBox1.Controls.Add(Me.UserButton2)
        Me.GroupBox1.Controls.Add(Me.txtvoucher)
        Me.GroupBox1.Controls.Add(Me.TxtReportOptions)
        Me.GroupBox1.Controls.Add(Me.TxtOtherReports)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtEndDate)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtStartDate)
        Me.GroupBox1.Controls.Add(Me.TxtIsPeriod)
        Me.GroupBox1.Controls.Add(Me.MenuStrip1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(599, 9)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.TableLayoutPanel1.SetRowSpan(Me.GroupBox1, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(263, 575)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Options"
        '
        'TxtNarrationAslo
        '
        Me.TxtNarrationAslo.AutoSize = True
        Me.TxtNarrationAslo.Location = New System.Drawing.Point(14, 154)
        Me.TxtNarrationAslo.Name = "TxtNarrationAslo"
        Me.TxtNarrationAslo.Size = New System.Drawing.Size(127, 17)
        Me.TxtNarrationAslo.TabIndex = 44
        Me.TxtNarrationAslo.Text = "Show Narrations Also"
        Me.TxtNarrationAslo.UseVisualStyleBackColor = True
        '
        'TxtDetailedView
        '
        Me.TxtDetailedView.AutoSize = True
        Me.TxtDetailedView.Location = New System.Drawing.Point(14, 134)
        Me.TxtDetailedView.Name = "TxtDetailedView"
        Me.TxtDetailedView.Size = New System.Drawing.Size(121, 17)
        Me.TxtDetailedView.TabIndex = 43
        Me.TxtDetailedView.Text = "Show Detailed View"
        Me.TxtDetailedView.UseVisualStyleBackColor = True
        '
        'TxtIsVouchers
        '
        Me.TxtIsVouchers.AutoSize = True
        Me.TxtIsVouchers.Location = New System.Drawing.Point(14, 288)
        Me.TxtIsVouchers.Name = "TxtIsVouchers"
        Me.TxtIsVouchers.Size = New System.Drawing.Size(101, 17)
        Me.TxtIsVouchers.TabIndex = 42
        Me.TxtIsVouchers.Text = "Show Vouchers"
        Me.TxtIsVouchers.UseVisualStyleBackColor = True
        '
        'UserButton4
        '
        Me.UserButton4.AllowToolTip = True
        Me.UserButton4.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.UserButton4.Image = CType(resources.GetObject("UserButton4.Image"), System.Drawing.Image)
        Me.UserButton4.Location = New System.Drawing.Point(82, 433)
        Me.UserButton4.LostFocusFontColor = System.Drawing.Color.Blue
        Me.UserButton4.Name = "UserButton4"
        Me.UserButton4.SetToolTip = ""
        Me.UserButton4.Size = New System.Drawing.Size(87, 34)
        Me.UserButton4.TabIndex = 41
        Me.UserButton4.Text = "Load"
        Me.UserButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.UserButton4.UseFunctionKeys = False
        Me.UserButton4.UseVisualStyleBackColor = True
        '
        'UserButton1
        '
        Me.UserButton1.AllowToolTip = True
        Me.UserButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.UserButton1.Image = CType(resources.GetObject("UserButton1.Image"), System.Drawing.Image)
        Me.UserButton1.Location = New System.Drawing.Point(82, 535)
        Me.UserButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.UserButton1.Name = "UserButton1"
        Me.UserButton1.SetToolTip = ""
        Me.UserButton1.Size = New System.Drawing.Size(87, 34)
        Me.UserButton1.TabIndex = 41
        Me.UserButton1.Text = "Load"
        Me.UserButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.UserButton1.UseFunctionKeys = False
        Me.UserButton1.UseVisualStyleBackColor = True
        Me.UserButton1.Visible = False
        '
        'UserButton3
        '
        Me.UserButton3.AllowToolTip = True
        Me.UserButton3.Enabled = False
        Me.UserButton3.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.UserButton3.Image = CType(resources.GetObject("UserButton3.Image"), System.Drawing.Image)
        Me.UserButton3.Location = New System.Drawing.Point(82, 338)
        Me.UserButton3.LostFocusFontColor = System.Drawing.Color.Blue
        Me.UserButton3.Name = "UserButton3"
        Me.UserButton3.SetToolTip = ""
        Me.UserButton3.Size = New System.Drawing.Size(87, 34)
        Me.UserButton3.TabIndex = 41
        Me.UserButton3.Text = "Load"
        Me.UserButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.UserButton3.UseFunctionKeys = False
        Me.UserButton3.UseVisualStyleBackColor = True
        '
        'UserButton2
        '
        Me.UserButton2.AllowToolTip = True
        Me.UserButton2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.UserButton2.Image = CType(resources.GetObject("UserButton2.Image"), System.Drawing.Image)
        Me.UserButton2.Location = New System.Drawing.Point(82, 94)
        Me.UserButton2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.UserButton2.Name = "UserButton2"
        Me.UserButton2.SetToolTip = ""
        Me.UserButton2.Size = New System.Drawing.Size(87, 34)
        Me.UserButton2.TabIndex = 41
        Me.UserButton2.Text = "Load"
        Me.UserButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.UserButton2.UseFunctionKeys = False
        Me.UserButton2.UseVisualStyleBackColor = True
        '
        'txtvoucher
        '
        Me.txtvoucher.AllowEmpty = True
        Me.txtvoucher.AllowOnlyListValues = False
        Me.txtvoucher.AllowToolTip = True
        Me.txtvoucher.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtvoucher.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtvoucher.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.txtvoucher.Enabled = False
        Me.txtvoucher.FormattingEnabled = True
        Me.txtvoucher.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtvoucher.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtvoucher.IsAllowDigits = True
        Me.txtvoucher.IsAllowSpace = True
        Me.txtvoucher.IsAllowSplChars = True
        Me.txtvoucher.IsAllowToolTip = True
        Me.txtvoucher.LFocusBackColor = System.Drawing.Color.White
        Me.txtvoucher.Location = New System.Drawing.Point(15, 311)
        Me.txtvoucher.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtvoucher.Name = "txtvoucher"
        Me.txtvoucher.Size = New System.Drawing.Size(206, 21)
        Me.txtvoucher.Sorted = True
        Me.txtvoucher.SpecialCharList = "&-/@"
        Me.txtvoucher.TabIndex = 39
        Me.txtvoucher.UseFunctionKeys = False
        '
        'TxtReportOptions
        '
        Me.TxtReportOptions.AllowEmpty = True
        Me.TxtReportOptions.AllowOnlyListValues = False
        Me.TxtReportOptions.AllowToolTip = True
        Me.TxtReportOptions.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtReportOptions.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtReportOptions.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtReportOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtReportOptions.FormattingEnabled = True
        Me.TxtReportOptions.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtReportOptions.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtReportOptions.IsAllowDigits = True
        Me.TxtReportOptions.IsAllowSpace = True
        Me.TxtReportOptions.IsAllowSplChars = True
        Me.TxtReportOptions.IsAllowToolTip = True
        Me.TxtReportOptions.Items.AddRange(New Object() {"Alphabetical (Decreasing)", "Alphabetical (Increasing)", "Amount-Wise (Decreasing)", "Amount-Wise (Increasing)", "Date-Wise (Decreasing)", "Date-Wise (Increasing)", "Default", "Voucher-Number (Decreasing)", "Voucher-Number (Increasing)", "Voucher-Wise (Decreasing)", "Voucher-Wise (Increasing)"})
        Me.TxtReportOptions.LFocusBackColor = System.Drawing.Color.White
        Me.TxtReportOptions.Location = New System.Drawing.Point(14, 406)
        Me.TxtReportOptions.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtReportOptions.Name = "TxtReportOptions"
        Me.TxtReportOptions.Size = New System.Drawing.Size(198, 21)
        Me.TxtReportOptions.Sorted = True
        Me.TxtReportOptions.SpecialCharList = "&-/@"
        Me.TxtReportOptions.TabIndex = 39
        Me.TxtReportOptions.UseFunctionKeys = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 490)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 15)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Other Reports"
        Me.Label2.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(14, 475)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(202, 24)
        Me.MenuStrip1.TabIndex = 45
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem, Me.RefreshToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        Me.MenuToolStripMenuItem.Visible = False
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)), System.Windows.Forms.Keys)
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 265.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CrystalReportViewer1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ImsButton1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(863, 585)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.ImsButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.ImsButton1.Location = New System.Drawing.Point(226, 541)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(146, 44)
        Me.ImsButton1.TabIndex = 2
        Me.ImsButton1.Text = "Close"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = True
        '
        'TxtByLedger
        '
        Me.TxtByLedger.AllowEmpty = True
        Me.TxtByLedger.AllowOnlyListValues = False
        Me.TxtByLedger.AllowToolTip = True
        Me.TxtByLedger.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtByLedger.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtByLedger.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtByLedger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtByLedger.FormattingEnabled = True
        Me.TxtByLedger.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtByLedger.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtByLedger.IsAllowDigits = True
        Me.TxtByLedger.IsAllowSpace = True
        Me.TxtByLedger.IsAllowSplChars = True
        Me.TxtByLedger.IsAllowToolTip = True
        Me.TxtByLedger.Items.AddRange(New Object() {"Alphabetical (Decreasing)", "Alphabetical (Increasing)", "Amount-Wise (Decreasing)", "Amount-Wise (Increasing)", "Date-Wise (Decreasing)", "Date-Wise (Increasing)", "Default", "Voucher-Number (Decreasing)", "Voucher-Number (Increasing)", "Voucher-Wise (Decreasing)", "Voucher-Wise (Increasing)"})
        Me.TxtByLedger.LFocusBackColor = System.Drawing.Color.White
        Me.TxtByLedger.Location = New System.Drawing.Point(15, 223)
        Me.TxtByLedger.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtByLedger.Name = "TxtByLedger"
        Me.TxtByLedger.Size = New System.Drawing.Size(206, 21)
        Me.TxtByLedger.Sorted = True
        Me.TxtByLedger.SpecialCharList = "&-/@"
        Me.TxtByLedger.TabIndex = 51
        Me.TxtByLedger.UseFunctionKeys = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(13, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 15)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "By Ledger Account"
        '
        'Daybook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 585)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Daybook"
        Me.Text = "Daybook"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents UserButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents UserButton3 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents UserButton2 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtOtherReports As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtIsPeriod As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtNarrationAslo As System.Windows.Forms.CheckBox
    Friend WithEvents TxtDetailedView As System.Windows.Forms.CheckBox
    Friend WithEvents TxtIsVouchers As System.Windows.Forms.CheckBox
    Friend WithEvents txtvoucher As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents UserButton4 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtReportOptions As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtByLedger As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
