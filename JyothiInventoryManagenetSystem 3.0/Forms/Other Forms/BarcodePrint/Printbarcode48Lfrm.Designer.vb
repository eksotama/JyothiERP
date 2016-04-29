<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Printbarcode48Lfrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Printbarcode48Lfrm))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtList = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtLeft = New System.Windows.Forms.NumericUpDown()
        Me.TxtTop = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCmpName = New System.Windows.Forms.TextBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ImsButton3 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtBarcode = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtStockName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtStockCode = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel17 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel16 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImsButton5 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton6 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton4 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TxtLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 324.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtList, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ImsHeadingLabel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1216, 684)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToOrderColumns = True
        Me.TxtList.AllowUserToResizeRows = False
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.Location = New System.Drawing.Point(3, 36)
        Me.TxtList.Name = "TxtList"
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(886, 582)
        Me.TxtList.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(895, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(318, 582)
        Me.Panel1.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtLeft)
        Me.GroupBox2.Controls.Add(Me.TxtTop)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TxtCmpName)
        Me.GroupBox2.Controls.Add(Me.CheckBox3)
        Me.GroupBox2.Controls.Add(Me.CheckBox2)
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(299, 140)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Print Option"
        '
        'TxtLeft
        '
        Me.TxtLeft.DecimalPlaces = 3
        Me.TxtLeft.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.TxtLeft.Location = New System.Drawing.Point(104, 173)
        Me.TxtLeft.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.TxtLeft.Name = "TxtLeft"
        Me.TxtLeft.Size = New System.Drawing.Size(74, 20)
        Me.TxtLeft.TabIndex = 3
        Me.TxtLeft.Value = New Decimal(New Integer() {300, 0, 0, 196608})
        Me.TxtLeft.Visible = False
        '
        'TxtTop
        '
        Me.TxtTop.DecimalPlaces = 3
        Me.TxtTop.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.TxtTop.Location = New System.Drawing.Point(104, 147)
        Me.TxtTop.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.TxtTop.Name = "TxtTop"
        Me.TxtTop.Size = New System.Drawing.Size(74, 20)
        Me.TxtTop.TabIndex = 3
        Me.TxtTop.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(67, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Left"
        Me.Label3.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(218, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Units in mm"
        Me.Label4.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(67, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Top"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 166)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Margins"
        Me.Label1.Visible = False
        '
        'TxtCmpName
        '
        Me.TxtCmpName.Location = New System.Drawing.Point(52, 89)
        Me.TxtCmpName.MaxLength = 30
        Me.TxtCmpName.Name = "TxtCmpName"
        Me.TxtCmpName.Size = New System.Drawing.Size(233, 20)
        Me.TxtCmpName.TabIndex = 1
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox3.Location = New System.Drawing.Point(24, 67)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(199, 17)
        Me.CheckBox3.TabIndex = 0
        Me.CheckBox3.Text = "Print With Heading (Company Name)"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(24, 44)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(170, 17)
        Me.CheckBox2.TabIndex = 0
        Me.CheckBox2.Text = "Print with WRP (Default: DRP)"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(24, 19)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(236, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Print with Stock Code (Default: Stock Name)"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ImsButton3)
        Me.GroupBox1.Controls.Add(Me.ImsButton2)
        Me.GroupBox1.Controls.Add(Me.TxtBarcode)
        Me.GroupBox1.Controls.Add(Me.ImsButton1)
        Me.GroupBox1.Controls.Add(Me.TxtStockName)
        Me.GroupBox1.Controls.Add(Me.ImSlabel1)
        Me.GroupBox1.Controls.Add(Me.TxtStockCode)
        Me.GroupBox1.Controls.Add(Me.ImSlabel17)
        Me.GroupBox1.Controls.Add(Me.ImSlabel16)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 185)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(305, 233)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search"
        '
        'ImsButton3
        '
        Me.ImsButton3.AllowToolTip = True
        Me.ImsButton3.BackColor = System.Drawing.Color.White
        Me.ImsButton3.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton3.Image = CType(resources.GetObject("ImsButton3.Image"), System.Drawing.Image)
        Me.ImsButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ImsButton3.Location = New System.Drawing.Point(188, 176)
        Me.ImsButton3.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton3.Name = "ImsButton3"
        Me.ImsButton3.SetToolTip = ""
        Me.ImsButton3.Size = New System.Drawing.Size(97, 29)
        Me.ImsButton3.TabIndex = 11
        Me.ImsButton3.Text = "Search"
        Me.ImsButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton3.UseFunctionKeys = False
        Me.ImsButton3.UseVisualStyleBackColor = False
        '
        'ImsButton2
        '
        Me.ImsButton2.AllowToolTip = True
        Me.ImsButton2.BackColor = System.Drawing.Color.White
        Me.ImsButton2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton2.Image = CType(resources.GetObject("ImsButton2.Image"), System.Drawing.Image)
        Me.ImsButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ImsButton2.Location = New System.Drawing.Point(188, 115)
        Me.ImsButton2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton2.Name = "ImsButton2"
        Me.ImsButton2.SetToolTip = ""
        Me.ImsButton2.Size = New System.Drawing.Size(97, 29)
        Me.ImsButton2.TabIndex = 11
        Me.ImsButton2.Text = "Search"
        Me.ImsButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton2.UseFunctionKeys = False
        Me.ImsButton2.UseVisualStyleBackColor = False
        '
        'TxtBarcode
        '
        Me.TxtBarcode.AllowToolTip = True
        Me.TxtBarcode.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtBarcode.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtBarcode.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtBarcode.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtBarcode.IsAllowDigits = True
        Me.TxtBarcode.IsAllowSpace = True
        Me.TxtBarcode.IsAllowSplChars = True
        Me.TxtBarcode.LFocusBackColor = System.Drawing.Color.White
        Me.TxtBarcode.Location = New System.Drawing.Point(24, 150)
        Me.TxtBarcode.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtBarcode.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtBarcode.MaxLength = 75
        Me.TxtBarcode.Name = "TxtBarcode"
        Me.TxtBarcode.SetToolTip = Nothing
        Me.TxtBarcode.Size = New System.Drawing.Size(261, 20)
        Me.TxtBarcode.SpecialCharList = "&-/@"
        Me.TxtBarcode.TabIndex = 10
        Me.TxtBarcode.UseFunctionKeys = False
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.BackColor = System.Drawing.Color.White
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = CType(resources.GetObject("ImsButton1.Image"), System.Drawing.Image)
        Me.ImsButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ImsButton1.Location = New System.Drawing.Point(188, 58)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(97, 28)
        Me.ImsButton1.TabIndex = 11
        Me.ImsButton1.Text = "Search"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = False
        '
        'TxtStockName
        '
        Me.TxtStockName.AllowToolTip = True
        Me.TxtStockName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtStockName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtStockName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtStockName.IsAllowDigits = True
        Me.TxtStockName.IsAllowSpace = True
        Me.TxtStockName.IsAllowSplChars = True
        Me.TxtStockName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockName.Location = New System.Drawing.Point(24, 89)
        Me.TxtStockName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtStockName.MaxLength = 75
        Me.TxtStockName.Name = "TxtStockName"
        Me.TxtStockName.SetToolTip = Nothing
        Me.TxtStockName.Size = New System.Drawing.Size(261, 20)
        Me.TxtStockName.SpecialCharList = "&-/@"
        Me.TxtStockName.TabIndex = 10
        Me.TxtStockName.UseFunctionKeys = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(18, 135)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(99, 13)
        Me.ImSlabel1.TabIndex = 7
        Me.ImSlabel1.Text = "Search By Barcode"
        '
        'TxtStockCode
        '
        Me.TxtStockCode.AllowToolTip = True
        Me.TxtStockCode.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtStockCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtStockCode.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockCode.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockCode.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtStockCode.IsAllowDigits = True
        Me.TxtStockCode.IsAllowSpace = True
        Me.TxtStockCode.IsAllowSplChars = True
        Me.TxtStockCode.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockCode.Location = New System.Drawing.Point(24, 32)
        Me.TxtStockCode.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockCode.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtStockCode.MaxLength = 75
        Me.TxtStockCode.Name = "TxtStockCode"
        Me.TxtStockCode.SetToolTip = Nothing
        Me.TxtStockCode.Size = New System.Drawing.Size(261, 20)
        Me.TxtStockCode.SpecialCharList = "&-/@"
        Me.TxtStockCode.TabIndex = 9
        Me.TxtStockCode.UseFunctionKeys = False
        '
        'ImSlabel17
        '
        Me.ImSlabel17.AutoSize = True
        Me.ImSlabel17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel17.Location = New System.Drawing.Point(18, 74)
        Me.ImSlabel17.Name = "ImSlabel17"
        Me.ImSlabel17.Size = New System.Drawing.Size(87, 13)
        Me.ImSlabel17.TabIndex = 7
        Me.ImSlabel17.Text = "Search By Name"
        '
        'ImSlabel16
        '
        Me.ImSlabel16.AutoSize = True
        Me.ImSlabel16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel16.Location = New System.Drawing.Point(18, 16)
        Me.ImSlabel16.Name = "ImSlabel16"
        Me.ImSlabel16.Size = New System.Drawing.Size(84, 13)
        Me.ImSlabel16.TabIndex = 8
        Me.ImSlabel16.Text = "Search By Code"
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
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(1216, 33)
        Me.ImsHeadingLabel1.TabIndex = 2
        Me.ImsHeadingLabel1.Text = " BARCODE PRINTING"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel2, 2)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 624)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1210, 57)
        Me.Panel2.TabIndex = 3
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton5, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton6, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton4, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1210, 57)
        Me.TableLayoutPanel2.TabIndex = 12
        '
        'ImsButton5
        '
        Me.ImsButton5.AllowToolTip = True
        Me.ImsButton5.BackColor = System.Drawing.Color.White
        Me.ImsButton5.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton5.Image = CType(resources.GetObject("ImsButton5.Image"), System.Drawing.Image)
        Me.ImsButton5.Location = New System.Drawing.Point(245, 3)
        Me.ImsButton5.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton5.Name = "ImsButton5"
        Me.ImsButton5.SetToolTip = ""
        Me.ImsButton5.Size = New System.Drawing.Size(191, 50)
        Me.ImsButton5.TabIndex = 11
        Me.ImsButton5.Text = "Close"
        Me.ImsButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton5.UseFunctionKeys = False
        Me.ImsButton5.UseVisualStyleBackColor = False
        '
        'ImsButton6
        '
        Me.ImsButton6.AllowToolTip = True
        Me.ImsButton6.BackColor = System.Drawing.Color.White
        Me.ImsButton6.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton6.Image = CType(resources.GetObject("ImsButton6.Image"), System.Drawing.Image)
        Me.ImsButton6.Location = New System.Drawing.Point(729, 3)
        Me.ImsButton6.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton6.Name = "ImsButton6"
        Me.ImsButton6.SetToolTip = ""
        Me.ImsButton6.Size = New System.Drawing.Size(191, 50)
        Me.ImsButton6.TabIndex = 11
        Me.ImsButton6.Text = "Print 24L"
        Me.ImsButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton6.UseFunctionKeys = False
        Me.ImsButton6.UseVisualStyleBackColor = False
        '
        'ImsButton4
        '
        Me.ImsButton4.AllowToolTip = True
        Me.ImsButton4.BackColor = System.Drawing.Color.White
        Me.ImsButton4.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton4.Image = CType(resources.GetObject("ImsButton4.Image"), System.Drawing.Image)
        Me.ImsButton4.Location = New System.Drawing.Point(487, 3)
        Me.ImsButton4.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton4.Name = "ImsButton4"
        Me.ImsButton4.SetToolTip = ""
        Me.ImsButton4.Size = New System.Drawing.Size(191, 50)
        Me.ImsButton4.TabIndex = 11
        Me.ImsButton4.Text = "Print 48L "
        Me.ImsButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton4.UseFunctionKeys = False
        Me.ImsButton4.UseVisualStyleBackColor = False
        '
        'Printbarcode48Lfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1216, 684)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Printbarcode48Lfrm"
        Me.Text = " BARCODE PRINTING"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TxtLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtList As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ImsButton2 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtStockName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtStockCode As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel17 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel16 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ImsButton3 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtBarcode As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImsButton5 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton4 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton6 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtCmpName As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents TxtLeft As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtTop As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
