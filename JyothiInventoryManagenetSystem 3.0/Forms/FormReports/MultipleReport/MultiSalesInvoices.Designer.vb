<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultiSalesInvoices
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MultiSalesInvoices))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtZoom = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtEdInvoiceNo = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtStInvoiceNo = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.IsInvoiceNoWise = New System.Windows.Forms.CheckBox()
        Me.IsDateWise = New System.Windows.Forms.CheckBox()
        Me.TxtVoucherType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtLedgerName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtEdDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtStDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnPrint = New JyothiPharmaERPSystem3.IMSButton()
        Me.PrintGroup = New System.Windows.Forms.Panel()
        Me.PrintPreviewControl1 = New System.Windows.Forms.PrintPreviewControl()
        Me.TxtOpMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NextPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreviousPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrtDoc = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PrintGroup.SuspendLayout()
        Me.TxtOpMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 249.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ImsHeadingLabel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.PrintGroup, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(907, 559)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtZoom)
        Me.Panel1.Controls.Add(Me.TxtEdInvoiceNo)
        Me.Panel1.Controls.Add(Me.TxtStInvoiceNo)
        Me.Panel1.Controls.Add(Me.ImsButton1)
        Me.Panel1.Controls.Add(Me.IsInvoiceNoWise)
        Me.Panel1.Controls.Add(Me.IsDateWise)
        Me.Panel1.Controls.Add(Me.TxtVoucherType)
        Me.Panel1.Controls.Add(Me.TxtLedgerName)
        Me.Panel1.Controls.Add(Me.TxtEdDate)
        Me.Panel1.Controls.Add(Me.ImSlabel3)
        Me.Panel1.Controls.Add(Me.ImSlabel2)
        Me.Panel1.Controls.Add(Me.TxtStDate)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(658, 27)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.TableLayoutPanel1.SetRowSpan(Me.Panel1, 2)
        Me.Panel1.Size = New System.Drawing.Size(249, 532)
        Me.Panel1.TabIndex = 0
        '
        'TxtZoom
        '
        Me.TxtZoom.AllowEmpty = True
        Me.TxtZoom.AllowOnlyListValues = True
        Me.TxtZoom.AllowToolTip = True
        Me.TxtZoom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtZoom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtZoom.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtZoom.FormattingEnabled = True
        Me.TxtZoom.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtZoom.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtZoom.IsAdvanceSearchWindow = False
        Me.TxtZoom.IsAllowDigits = True
        Me.TxtZoom.IsAllowSpace = True
        Me.TxtZoom.IsAllowSplChars = True
        Me.TxtZoom.IsAllowToolTip = True
        Me.TxtZoom.Items.AddRange(New Object() {"100%", "25%", "50%", "75%", "AUTO"})
        Me.TxtZoom.LFocusBackColor = System.Drawing.Color.White
        Me.TxtZoom.Location = New System.Drawing.Point(27, 432)
        Me.TxtZoom.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtZoom.Name = "TxtZoom"
        Me.TxtZoom.SetToolTip = Nothing
        Me.TxtZoom.Size = New System.Drawing.Size(121, 21)
        Me.TxtZoom.Sorted = True
        Me.TxtZoom.SpecialCharList = "&-/@"
        Me.TxtZoom.TabIndex = 7
        Me.TxtZoom.UseFunctionKeys = False
        '
        'TxtEdInvoiceNo
        '
        Me.TxtEdInvoiceNo.AllowToolTip = True
        Me.TxtEdInvoiceNo.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtEdInvoiceNo.Enabled = False
        Me.TxtEdInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtEdInvoiceNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtEdInvoiceNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtEdInvoiceNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtEdInvoiceNo.IsAllowDigits = True
        Me.TxtEdInvoiceNo.IsAllowSpace = True
        Me.TxtEdInvoiceNo.IsAllowSplChars = True
        Me.TxtEdInvoiceNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtEdInvoiceNo.Location = New System.Drawing.Point(33, 199)
        Me.TxtEdInvoiceNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtEdInvoiceNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtEdInvoiceNo.MaxLength = 75
        Me.TxtEdInvoiceNo.Name = "TxtEdInvoiceNo"
        Me.TxtEdInvoiceNo.SetToolTip = Nothing
        Me.TxtEdInvoiceNo.Size = New System.Drawing.Size(124, 20)
        Me.TxtEdInvoiceNo.SpecialCharList = "&-/@"
        Me.TxtEdInvoiceNo.TabIndex = 6
        Me.TxtEdInvoiceNo.UseFunctionKeys = False
        '
        'TxtStInvoiceNo
        '
        Me.TxtStInvoiceNo.AllowToolTip = True
        Me.TxtStInvoiceNo.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtStInvoiceNo.Enabled = False
        Me.TxtStInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtStInvoiceNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStInvoiceNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStInvoiceNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtStInvoiceNo.IsAllowDigits = True
        Me.TxtStInvoiceNo.IsAllowSpace = True
        Me.TxtStInvoiceNo.IsAllowSplChars = True
        Me.TxtStInvoiceNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStInvoiceNo.Location = New System.Drawing.Point(33, 173)
        Me.TxtStInvoiceNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStInvoiceNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtStInvoiceNo.MaxLength = 75
        Me.TxtStInvoiceNo.Name = "TxtStInvoiceNo"
        Me.TxtStInvoiceNo.SetToolTip = Nothing
        Me.TxtStInvoiceNo.Size = New System.Drawing.Size(124, 20)
        Me.TxtStInvoiceNo.SpecialCharList = "&-/@"
        Me.TxtStInvoiceNo.TabIndex = 6
        Me.TxtStInvoiceNo.UseFunctionKeys = False
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.BackColor = System.Drawing.Color.White
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.refresh2
        Me.ImsButton1.Location = New System.Drawing.Point(33, 335)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(142, 42)
        Me.ImsButton1.TabIndex = 1
        Me.ImsButton1.Text = "Load Report"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = False
        '
        'IsInvoiceNoWise
        '
        Me.IsInvoiceNoWise.AutoSize = True
        Me.IsInvoiceNoWise.Location = New System.Drawing.Point(6, 146)
        Me.IsInvoiceNoWise.Name = "IsInvoiceNoWise"
        Me.IsInvoiceNoWise.Size = New System.Drawing.Size(137, 17)
        Me.IsInvoiceNoWise.TabIndex = 5
        Me.IsInvoiceNoWise.Text = "Invoice No Range wise"
        Me.IsInvoiceNoWise.UseVisualStyleBackColor = True
        '
        'IsDateWise
        '
        Me.IsDateWise.AutoSize = True
        Me.IsDateWise.Checked = True
        Me.IsDateWise.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IsDateWise.Location = New System.Drawing.Point(6, 64)
        Me.IsDateWise.Name = "IsDateWise"
        Me.IsDateWise.Size = New System.Drawing.Size(73, 17)
        Me.IsDateWise.TabIndex = 5
        Me.IsDateWise.Text = "Date wise"
        Me.IsDateWise.UseVisualStyleBackColor = True
        '
        'TxtVoucherType
        '
        Me.TxtVoucherType.AllowEmpty = True
        Me.TxtVoucherType.AllowOnlyListValues = False
        Me.TxtVoucherType.AllowToolTip = True
        Me.TxtVoucherType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtVoucherType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtVoucherType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtVoucherType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtVoucherType.FormattingEnabled = True
        Me.TxtVoucherType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtVoucherType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtVoucherType.IsAdvanceSearchWindow = False
        Me.TxtVoucherType.IsAllowDigits = True
        Me.TxtVoucherType.IsAllowSpace = True
        Me.TxtVoucherType.IsAllowSplChars = True
        Me.TxtVoucherType.IsAllowToolTip = True
        Me.TxtVoucherType.Items.AddRange(New Object() {"All Sales", "Delivery Note", "POS", "Sales Invoice", "Sales Orders"})
        Me.TxtVoucherType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtVoucherType.Location = New System.Drawing.Point(6, 257)
        Me.TxtVoucherType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtVoucherType.Name = "TxtVoucherType"
        Me.TxtVoucherType.SetToolTip = Nothing
        Me.TxtVoucherType.Size = New System.Drawing.Size(231, 21)
        Me.TxtVoucherType.Sorted = True
        Me.TxtVoucherType.SpecialCharList = "&-/@"
        Me.TxtVoucherType.TabIndex = 4
        Me.TxtVoucherType.UseFunctionKeys = False
        '
        'TxtLedgerName
        '
        Me.TxtLedgerName.AllowEmpty = True
        Me.TxtLedgerName.AllowOnlyListValues = False
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
        Me.TxtLedgerName.Location = New System.Drawing.Point(6, 30)
        Me.TxtLedgerName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLedgerName.Name = "TxtLedgerName"
        Me.TxtLedgerName.SetToolTip = Nothing
        Me.TxtLedgerName.Size = New System.Drawing.Size(231, 21)
        Me.TxtLedgerName.Sorted = True
        Me.TxtLedgerName.SpecialCharList = "&-/@"
        Me.TxtLedgerName.TabIndex = 4
        Me.TxtLedgerName.UseFunctionKeys = False
        '
        'TxtEdDate
        '
        Me.TxtEdDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtEdDate.Location = New System.Drawing.Point(16, 113)
        Me.TxtEdDate.Name = "TxtEdDate"
        Me.TxtEdDate.Size = New System.Drawing.Size(180, 20)
        Me.TxtEdDate.TabIndex = 3
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(24, 416)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(38, 13)
        Me.ImSlabel3.TabIndex = 0
        Me.ImSlabel3.Text = "Zoom"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(3, 241)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(92, 13)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "Voucher Types"
        '
        'TxtStDate
        '
        Me.TxtStDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtStDate.Location = New System.Drawing.Point(16, 87)
        Me.TxtStDate.Name = "TxtStDate"
        Me.TxtStDate.Size = New System.Drawing.Size(180, 20)
        Me.TxtStDate.TabIndex = 3
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(3, 14)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(137, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "Select Ledger Account"
        '
        'ImsHeadingLabel1
        '
        Me.ImsHeadingLabel1.AutoSize = True
        Me.ImsHeadingLabel1.BackColor = System.Drawing.Color.DarkOrange
        Me.TableLayoutPanel1.SetColumnSpan(Me.ImsHeadingLabel1, 2)
        Me.ImsHeadingLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsHeadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsHeadingLabel1.ForeColor = System.Drawing.Color.White
        Me.ImsHeadingLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ImsHeadingLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsHeadingLabel1.Name = "ImsHeadingLabel1"
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(907, 27)
        Me.ImsHeadingLabel1.TabIndex = 1
        Me.ImsHeadingLabel1.Text = "MULTI SALES INVOICE REPORTS"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.LinkLabel2)
        Me.Panel2.Controls.Add(Me.LinkLabel1)
        Me.Panel2.Controls.Add(Me.BtnClose)
        Me.Panel2.Controls.Add(Me.BtnPrint)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 483)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(652, 73)
        Me.Panel2.TabIndex = 2
        '
        'LinkLabel2
        '
        Me.LinkLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.Location = New System.Drawing.Point(613, 4)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(33, 13)
        Me.LinkLabel2.TabIndex = 2
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Next"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(510, 4)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(36, 13)
        Me.LinkLabel1.TabIndex = 2
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Back"
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(89, 23)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(123, 42)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'BtnPrint
        '
        Me.BtnPrint.AllowToolTip = True
        Me.BtnPrint.BackColor = System.Drawing.Color.White
        Me.BtnPrint.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(306, 23)
        Me.BtnPrint.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.SetToolTip = ""
        Me.BtnPrint.Size = New System.Drawing.Size(123, 42)
        Me.BtnPrint.TabIndex = 1
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseFunctionKeys = False
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'PrintGroup
        '
        Me.PrintGroup.Controls.Add(Me.PrintPreviewControl1)
        Me.PrintGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrintGroup.Location = New System.Drawing.Point(3, 30)
        Me.PrintGroup.Name = "PrintGroup"
        Me.PrintGroup.Size = New System.Drawing.Size(652, 447)
        Me.PrintGroup.TabIndex = 3
        '
        'PrintPreviewControl1
        '
        Me.PrintPreviewControl1.ContextMenuStrip = Me.TxtOpMenu
        Me.PrintPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrintPreviewControl1.Location = New System.Drawing.Point(0, 0)
        Me.PrintPreviewControl1.Name = "PrintPreviewControl1"
        Me.PrintPreviewControl1.Size = New System.Drawing.Size(652, 447)
        Me.PrintPreviewControl1.TabIndex = 3
        '
        'TxtOpMenu
        '
        Me.TxtOpMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NextPageToolStripMenuItem, Me.PreviousPageToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.TxtOpMenu.Name = "TxtOpMenu"
        Me.TxtOpMenu.Size = New System.Drawing.Size(203, 70)
        '
        'NextPageToolStripMenuItem
        '
        Me.NextPageToolStripMenuItem.Name = "NextPageToolStripMenuItem"
        Me.NextPageToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Right), System.Windows.Forms.Keys)
        Me.NextPageToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.NextPageToolStripMenuItem.Text = "&Next Page"
        '
        'PreviousPageToolStripMenuItem
        '
        Me.PreviousPageToolStripMenuItem.Name = "PreviousPageToolStripMenuItem"
        Me.PreviousPageToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Left), System.Windows.Forms.Keys)
        Me.PreviousPageToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.PreviousPageToolStripMenuItem.Text = "Pre&vious Page"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.PrintToolStripMenuItem.Text = "&Print"
        '
        'PrtDoc
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'MultiSalesInvoices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(907, 559)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "MultiSalesInvoices"
        Me.Text = "Multi Sales Invoice Report"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PrintGroup.ResumeLayout(False)
        Me.TxtOpMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtEdInvoiceNo As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtStInvoiceNo As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents IsInvoiceNoWise As System.Windows.Forms.CheckBox
    Friend WithEvents IsDateWise As System.Windows.Forms.CheckBox
    Friend WithEvents TxtLedgerName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtEdDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtStDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnPrint As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents PrintPreviewControl1 As System.Windows.Forms.PrintPreviewControl
    Friend WithEvents TxtOpMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NextPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreviousPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrtDoc As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents TxtVoucherType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents PrintGroup As System.Windows.Forms.Panel
    Friend WithEvents TxtZoom As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
End Class
