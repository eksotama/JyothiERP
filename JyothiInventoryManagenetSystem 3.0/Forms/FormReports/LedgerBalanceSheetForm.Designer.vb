<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LedgerBalanceSheetForm
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LedgerBalanceSheetForm))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtHeading = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtUserWise = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtLocationWise = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TxtGroupName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtOrderBy = New System.Windows.Forms.ComboBox()
        Me.TxtSearchOption = New System.Windows.Forms.ComboBox()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.lblGroupWise = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtSearchBy = New System.Windows.Forms.TextBox()
        Me.TxtIsCurrency = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnPrint = New JyothiPharmaERPSystem3.IMSButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtCurrencyName = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtNetTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtCrTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.txtDrTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1007, 526)
        Me.TableLayoutPanel1.TabIndex = 0
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
        Me.TxtHeading.Size = New System.Drawing.Size(1007, 27)
        Me.TxtHeading.TabIndex = 0
        Me.TxtHeading.Text = "CUSTOMERS BALANCE REPORT"
        Me.TxtHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtList)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 27)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(807, 423)
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
        Me.TxtList.Size = New System.Drawing.Size(807, 423)
        Me.TxtList.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ImSlabel8)
        Me.Panel1.Controls.Add(Me.ImSlabel7)
        Me.Panel1.Controls.Add(Me.TxtUserWise)
        Me.Panel1.Controls.Add(Me.TxtLocationWise)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.TxtGroupName)
        Me.Panel1.Controls.Add(Me.TxtOrderBy)
        Me.Panel1.Controls.Add(Me.TxtSearchOption)
        Me.Panel1.Controls.Add(Me.ImSlabel4)
        Me.Panel1.Controls.Add(Me.lblGroupWise)
        Me.Panel1.Controls.Add(Me.ImSlabel3)
        Me.Panel1.Controls.Add(Me.ImSlabel2)
        Me.Panel1.Controls.Add(Me.TxtSearchBy)
        Me.Panel1.Controls.Add(Me.TxtIsCurrency)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(810, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(194, 417)
        Me.Panel1.TabIndex = 3
        '
        'ImSlabel8
        '
        Me.ImSlabel8.AutoSize = True
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(3, 104)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(125, 13)
        Me.ImSlabel8.TabIndex = 56
        Me.ImSlabel8.Text = "User/Employee Wise"
        '
        'ImSlabel7
        '
        Me.ImSlabel7.AutoSize = True
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(3, 55)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(99, 13)
        Me.ImSlabel7.TabIndex = 57
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
        Me.TxtUserWise.Location = New System.Drawing.Point(4, 120)
        Me.TxtUserWise.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtUserWise.Name = "TxtUserWise"
        Me.TxtUserWise.SetToolTip = Nothing
        Me.TxtUserWise.Size = New System.Drawing.Size(187, 21)
        Me.TxtUserWise.Sorted = True
        Me.TxtUserWise.SpecialCharList = "&-/@"
        Me.TxtUserWise.TabIndex = 54
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
        Me.TxtLocationWise.Location = New System.Drawing.Point(4, 71)
        Me.TxtLocationWise.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLocationWise.Name = "TxtLocationWise"
        Me.TxtLocationWise.SetToolTip = Nothing
        Me.TxtLocationWise.Size = New System.Drawing.Size(187, 21)
        Me.TxtLocationWise.Sorted = True
        Me.TxtLocationWise.SpecialCharList = "&-/@"
        Me.TxtLocationWise.TabIndex = 55
        Me.TxtLocationWise.UseFunctionKeys = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(31, 147)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(120, 34)
        Me.Button3.TabIndex = 58
        Me.Button3.Text = "Load"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'TxtGroupName
        '
        Me.TxtGroupName.AllowEmpty = True
        Me.TxtGroupName.AllowOnlyListValues = True
        Me.TxtGroupName.AllowToolTip = True
        Me.TxtGroupName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtGroupName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtGroupName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtGroupName.FormattingEnabled = True
        Me.TxtGroupName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtGroupName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtGroupName.IsAdvanceSearchWindow = False
        Me.TxtGroupName.IsAllowDigits = True
        Me.TxtGroupName.IsAllowSpace = True
        Me.TxtGroupName.IsAllowSplChars = True
        Me.TxtGroupName.IsAllowToolTip = True
        Me.TxtGroupName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtGroupName.Location = New System.Drawing.Point(4, 24)
        Me.TxtGroupName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtGroupName.Name = "TxtGroupName"
        Me.TxtGroupName.SetToolTip = Nothing
        Me.TxtGroupName.Size = New System.Drawing.Size(187, 21)
        Me.TxtGroupName.Sorted = True
        Me.TxtGroupName.SpecialCharList = "&-/@"
        Me.TxtGroupName.TabIndex = 4
        Me.TxtGroupName.UseFunctionKeys = False
        '
        'TxtOrderBy
        '
        Me.TxtOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtOrderBy.FormattingEnabled = True
        Me.TxtOrderBy.Items.AddRange(New Object() {"Dr Amount Ascending", "Dr Amount Descending", "Cr Amount Ascending", "Cr Amount Descending", "Balance Ascending", "Balance Descending", "Name Ascending", "Name Descending"})
        Me.TxtOrderBy.Location = New System.Drawing.Point(7, 345)
        Me.TxtOrderBy.Name = "TxtOrderBy"
        Me.TxtOrderBy.Size = New System.Drawing.Size(178, 21)
        Me.TxtOrderBy.TabIndex = 3
        '
        'TxtSearchOption
        '
        Me.TxtSearchOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtSearchOption.FormattingEnabled = True
        Me.TxtSearchOption.Items.AddRange(New Object() {"Begin with", "End With", "Contain"})
        Me.TxtSearchOption.Location = New System.Drawing.Point(88, 231)
        Me.TxtSearchOption.Name = "TxtSearchOption"
        Me.TxtSearchOption.Size = New System.Drawing.Size(97, 21)
        Me.TxtSearchOption.TabIndex = 3
        '
        'ImSlabel4
        '
        Me.ImSlabel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(4, 329)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(69, 13)
        Me.ImSlabel4.TabIndex = 2
        Me.ImSlabel4.Text = "Arrange By"
        '
        'lblGroupWise
        '
        Me.lblGroupWise.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGroupWise.AutoSize = True
        Me.lblGroupWise.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupWise.Location = New System.Drawing.Point(3, 8)
        Me.lblGroupWise.Name = "lblGroupWise"
        Me.lblGroupWise.Size = New System.Drawing.Size(123, 13)
        Me.lblGroupWise.TabIndex = 2
        Me.lblGroupWise.Text = "Filer By Group Name"
        '
        'ImSlabel3
        '
        Me.ImSlabel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(2, 234)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(88, 13)
        Me.ImSlabel3.TabIndex = 2
        Me.ImSlabel3.Text = "Search Option"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(5, 257)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(65, 13)
        Me.ImSlabel2.TabIndex = 2
        Me.ImSlabel2.Text = "Search By"
        '
        'TxtSearchBy
        '
        Me.TxtSearchBy.Location = New System.Drawing.Point(8, 273)
        Me.TxtSearchBy.Name = "TxtSearchBy"
        Me.TxtSearchBy.Size = New System.Drawing.Size(151, 20)
        Me.TxtSearchBy.TabIndex = 1
        '
        'TxtIsCurrency
        '
        Me.TxtIsCurrency.AutoSize = True
        Me.TxtIsCurrency.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsCurrency.Location = New System.Drawing.Point(8, 372)
        Me.TxtIsCurrency.Name = "TxtIsCurrency"
        Me.TxtIsCurrency.Size = New System.Drawing.Size(143, 17)
        Me.TxtIsCurrency.TabIndex = 0
        Me.TxtIsCurrency.Text = "Show Currency Wise"
        Me.TxtIsCurrency.UseVisualStyleBackColor = True
        Me.TxtIsCurrency.Visible = False
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 477)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(807, 49)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(201, 0)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(146, 49)
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
        Me.BtnPrint.Location = New System.Drawing.Point(513, 0)
        Me.BtnPrint.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPrint.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.SetToolTip = ""
        Me.BtnPrint.Size = New System.Drawing.Size(147, 49)
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
        Me.Panel3.Controls.Add(Me.TxtCurrencyName)
        Me.Panel3.Controls.Add(Me.TxtNetTotal)
        Me.Panel3.Controls.Add(Me.TxtCrTotal)
        Me.Panel3.Controls.Add(Me.txtDrTotal)
        Me.Panel3.Controls.Add(Me.ImSlabel1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 450)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(807, 27)
        Me.Panel3.TabIndex = 5
        '
        'TxtCurrencyName
        '
        Me.TxtCurrencyName.AutoSize = True
        Me.TxtCurrencyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCurrencyName.Location = New System.Drawing.Point(12, 7)
        Me.TxtCurrencyName.Name = "TxtCurrencyName"
        Me.TxtCurrencyName.Size = New System.Drawing.Size(80, 13)
        Me.TxtCurrencyName.TabIndex = 2
        Me.TxtCurrencyName.Text = "Grand Totals"
        Me.TxtCurrencyName.Visible = False
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
        Me.TxtNetTotal.Location = New System.Drawing.Point(607, 4)
        Me.TxtNetTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNetTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetTotal.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtNetTotal.MaxLength = 75
        Me.TxtNetTotal.Name = "TxtNetTotal"
        Me.TxtNetTotal.ReadOnly = True
        Me.TxtNetTotal.SetToolTip = Nothing
        Me.TxtNetTotal.Size = New System.Drawing.Size(200, 20)
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
        Me.TxtCrTotal.Location = New System.Drawing.Point(407, 4)
        Me.TxtCrTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCrTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCrTotal.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtCrTotal.MaxLength = 75
        Me.TxtCrTotal.Name = "TxtCrTotal"
        Me.TxtCrTotal.ReadOnly = True
        Me.TxtCrTotal.SetToolTip = Nothing
        Me.TxtCrTotal.Size = New System.Drawing.Size(200, 20)
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
        Me.txtDrTotal.Location = New System.Drawing.Point(207, 4)
        Me.txtDrTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtDrTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDrTotal.Margin = New System.Windows.Forms.Padding(0)
        Me.txtDrTotal.MaxLength = 75
        Me.txtDrTotal.Name = "txtDrTotal"
        Me.txtDrTotal.ReadOnly = True
        Me.txtDrTotal.SetToolTip = Nothing
        Me.txtDrTotal.Size = New System.Drawing.Size(200, 20)
        Me.txtDrTotal.SpecialCharList = "&-/@"
        Me.txtDrTotal.TabIndex = 1
        Me.txtDrTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDrTotal.UseFunctionKeys = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(124, 7)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(80, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "Grand Totals"
        '
        'LedgerBalanceSheetForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1007, 526)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "LedgerBalanceSheetForm"
        Me.Text = "Accounts Balance Summary"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtHeading As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtIsCurrency As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnPrint As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TxtNetTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtCrTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents txtDrTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtSearchBy As System.Windows.Forms.TextBox
    Friend WithEvents TxtSearchOption As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtOrderBy As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtGroupName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents lblGroupWise As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtCurrencyName As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtUserWise As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtLocationWise As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
