<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BarcodePrintingfrm
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PrintGroup = New System.Windows.Forms.GroupBox()
        Me.PrintPreviewControl1 = New System.Windows.Forms.PrintPreviewControl()
        Me.PrtDoc = New System.Drawing.Printing.PrintDocument()
        Me.TxtList = New System.Windows.Forms.DataGridView()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtpriceSysmbol = New System.Windows.Forms.TextBox()
        Me.TxtPriceLevel = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel10 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel9 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.StockCodeOnButtom = New System.Windows.Forms.RadioButton()
        Me.StockCodeOnTop = New System.Windows.Forms.RadioButton()
        Me.IsPrintStockCodewithPrice = New System.Windows.Forms.CheckBox()
        Me.IsPrintStockCodeAlso = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BarcodeonButtom = New System.Windows.Forms.RadioButton()
        Me.BarcodeOnTop = New System.Windows.Forms.RadioButton()
        Me.TxtIsPrintLabel = New System.Windows.Forms.CheckBox()
        Me.IsFirstBarcode = New System.Windows.Forms.CheckBox()
        Me.UserButton6 = New UserButton.UserButton()
        Me.UserButton5 = New UserButton.UserButton()
        Me.TxtZoom = New System.Windows.Forms.ComboBox()
        Me.TxtBarcodeType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtPaperSize = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtNoofCopies = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.txtheight = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtWidth = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtCustomBarcode = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TxtCat = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtGroup = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ImsButton2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ImsButton4 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton3 = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnPreview = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNoOfColumns = New System.Windows.Forms.NumericUpDown()
        Me.TxtTopGap = New System.Windows.Forms.NumericUpDown()
        Me.TxtLeftGap = New System.Windows.Forms.NumericUpDown()
        Me.TxtHGap = New System.Windows.Forms.NumericUpDown()
        Me.TxtVGap = New System.Windows.Forms.NumericUpDown()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.PrintGroup.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TxtNoOfColumns, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTopGap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtLeftGap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtHGap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtVGap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 319.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PrintGroup, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ImsHeadingLabel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 119.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1212, 602)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'PrintGroup
        '
        Me.PrintGroup.BackColor = System.Drawing.Color.DarkGray
        Me.PrintGroup.Controls.Add(Me.PrintPreviewControl1)
        Me.PrintGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrintGroup.Location = New System.Drawing.Point(319, 145)
        Me.PrintGroup.Margin = New System.Windows.Forms.Padding(0)
        Me.PrintGroup.Name = "PrintGroup"
        Me.PrintGroup.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.PrintGroup.Size = New System.Drawing.Size(893, 404)
        Me.PrintGroup.TabIndex = 5
        Me.PrintGroup.TabStop = False
        '
        'PrintPreviewControl1
        '
        Me.PrintPreviewControl1.AutoZoom = False
        Me.PrintPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrintPreviewControl1.Document = Me.PrtDoc
        Me.PrintPreviewControl1.Location = New System.Drawing.Point(3, 13)
        Me.PrintPreviewControl1.Name = "PrintPreviewControl1"
        Me.PrintPreviewControl1.Size = New System.Drawing.Size(887, 388)
        Me.PrintPreviewControl1.TabIndex = 0
        Me.PrintPreviewControl1.UseAntiAlias = True
        Me.PrintPreviewControl1.Zoom = 1.0R
        '
        'PrtDoc
        '
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToResizeRows = False
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.Location = New System.Drawing.Point(3, 55)
        Me.TxtList.Name = "TxtList"
        Me.TxtList.Size = New System.Drawing.Size(307, 340)
        Me.TxtList.TabIndex = 0
        '
        'ImsHeadingLabel1
        '
        Me.ImsHeadingLabel1.AutoSize = True
        Me.ImsHeadingLabel1.BackColor = System.Drawing.Color.Green
        Me.TableLayoutPanel1.SetColumnSpan(Me.ImsHeadingLabel1, 2)
        Me.ImsHeadingLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsHeadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsHeadingLabel1.ForeColor = System.Drawing.Color.White
        Me.ImsHeadingLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ImsHeadingLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsHeadingLabel1.Name = "ImsHeadingLabel1"
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(1212, 26)
        Me.ImsHeadingLabel1.TabIndex = 0
        Me.ImsHeadingLabel1.Text = "BARCODE PRINING"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.IsFirstBarcode)
        Me.Panel1.Controls.Add(Me.UserButton6)
        Me.Panel1.Controls.Add(Me.UserButton5)
        Me.Panel1.Controls.Add(Me.TxtZoom)
        Me.Panel1.Controls.Add(Me.TxtBarcodeType)
        Me.Panel1.Controls.Add(Me.TxtPaperSize)
        Me.Panel1.Controls.Add(Me.TxtNoofCopies)
        Me.Panel1.Controls.Add(Me.txtheight)
        Me.Panel1.Controls.Add(Me.TxtWidth)
        Me.Panel1.Controls.Add(Me.TxtCustomBarcode)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.ImSlabel8)
        Me.Panel1.Controls.Add(Me.ImSlabel7)
        Me.Panel1.Controls.Add(Me.ImSlabel6)
        Me.Panel1.Controls.Add(Me.ImSlabel5)
        Me.Panel1.Controls.Add(Me.ImSlabel4)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 26)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1212, 119)
        Me.Panel1.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtpriceSysmbol)
        Me.GroupBox2.Controls.Add(Me.TxtPriceLevel)
        Me.GroupBox2.Controls.Add(Me.ImSlabel10)
        Me.GroupBox2.Controls.Add(Me.ImSlabel9)
        Me.GroupBox2.Controls.Add(Me.StockCodeOnButtom)
        Me.GroupBox2.Controls.Add(Me.StockCodeOnTop)
        Me.GroupBox2.Controls.Add(Me.IsPrintStockCodewithPrice)
        Me.GroupBox2.Controls.Add(Me.IsPrintStockCodeAlso)
        Me.GroupBox2.Location = New System.Drawing.Point(729, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(365, 84)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        '
        'txtpriceSysmbol
        '
        Me.txtpriceSysmbol.Location = New System.Drawing.Point(274, 57)
        Me.txtpriceSysmbol.MaxLength = 6
        Me.txtpriceSysmbol.Name = "txtpriceSysmbol"
        Me.txtpriceSysmbol.Size = New System.Drawing.Size(59, 20)
        Me.txtpriceSysmbol.TabIndex = 10
        '
        'TxtPriceLevel
        '
        Me.TxtPriceLevel.AllowEmpty = True
        Me.TxtPriceLevel.AllowOnlyListValues = True
        Me.TxtPriceLevel.AllowToolTip = True
        Me.TxtPriceLevel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtPriceLevel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtPriceLevel.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtPriceLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtPriceLevel.FormattingEnabled = True
        Me.TxtPriceLevel.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPriceLevel.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPriceLevel.IsAllowDigits = True
        Me.TxtPriceLevel.IsAllowSpace = True
        Me.TxtPriceLevel.IsAllowSplChars = True
        Me.TxtPriceLevel.IsAllowToolTip = True
        Me.TxtPriceLevel.Items.AddRange(New Object() {"Custom", "Retail", "Wholesale"})
        Me.TxtPriceLevel.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPriceLevel.Location = New System.Drawing.Point(250, 33)
        Me.TxtPriceLevel.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPriceLevel.Name = "TxtPriceLevel"
        Me.TxtPriceLevel.SetToolTip = Nothing
        Me.TxtPriceLevel.Size = New System.Drawing.Size(109, 21)
        Me.TxtPriceLevel.Sorted = True
        Me.TxtPriceLevel.SpecialCharList = "&-/@"
        Me.TxtPriceLevel.TabIndex = 9
        Me.TxtPriceLevel.UseFunctionKeys = False
        '
        'ImSlabel10
        '
        Me.ImSlabel10.AutoSize = True
        Me.ImSlabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel10.Location = New System.Drawing.Point(202, 58)
        Me.ImSlabel10.Name = "ImSlabel10"
        Me.ImSlabel10.Size = New System.Drawing.Size(68, 13)
        Me.ImSlabel10.TabIndex = 8
        Me.ImSlabel10.Text = "Price Symbol"
        '
        'ImSlabel9
        '
        Me.ImSlabel9.AutoSize = True
        Me.ImSlabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel9.Location = New System.Drawing.Point(202, 38)
        Me.ImSlabel9.Name = "ImSlabel9"
        Me.ImSlabel9.Size = New System.Drawing.Size(50, 13)
        Me.ImSlabel9.TabIndex = 8
        Me.ImSlabel9.Text = "Price List"
        '
        'StockCodeOnButtom
        '
        Me.StockCodeOnButtom.AutoSize = True
        Me.StockCodeOnButtom.Checked = True
        Me.StockCodeOnButtom.Location = New System.Drawing.Point(97, 36)
        Me.StockCodeOnButtom.Name = "StockCodeOnButtom"
        Me.StockCodeOnButtom.Size = New System.Drawing.Size(99, 17)
        Me.StockCodeOnButtom.TabIndex = 7
        Me.StockCodeOnButtom.TabStop = True
        Me.StockCodeOnButtom.Text = "Print On Buttom"
        Me.StockCodeOnButtom.UseVisualStyleBackColor = True
        '
        'StockCodeOnTop
        '
        Me.StockCodeOnTop.AutoSize = True
        Me.StockCodeOnTop.Location = New System.Drawing.Point(6, 36)
        Me.StockCodeOnTop.Name = "StockCodeOnTop"
        Me.StockCodeOnTop.Size = New System.Drawing.Size(85, 17)
        Me.StockCodeOnTop.TabIndex = 7
        Me.StockCodeOnTop.Text = "Print On Top"
        Me.StockCodeOnTop.UseVisualStyleBackColor = True
        '
        'IsPrintStockCodewithPrice
        '
        Me.IsPrintStockCodewithPrice.Location = New System.Drawing.Point(116, 9)
        Me.IsPrintStockCodewithPrice.Name = "IsPrintStockCodewithPrice"
        Me.IsPrintStockCodewithPrice.Size = New System.Drawing.Size(172, 27)
        Me.IsPrintStockCodewithPrice.TabIndex = 6
        Me.IsPrintStockCodewithPrice.Text = "Print Stock Code With Price"
        Me.IsPrintStockCodewithPrice.UseVisualStyleBackColor = True
        '
        'IsPrintStockCodeAlso
        '
        Me.IsPrintStockCodeAlso.Location = New System.Drawing.Point(6, 9)
        Me.IsPrintStockCodeAlso.Name = "IsPrintStockCodeAlso"
        Me.IsPrintStockCodeAlso.Size = New System.Drawing.Size(172, 27)
        Me.IsPrintStockCodeAlso.TabIndex = 6
        Me.IsPrintStockCodeAlso.Text = "Print Stock Code"
        Me.IsPrintStockCodeAlso.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BarcodeonButtom)
        Me.GroupBox1.Controls.Add(Me.BarcodeOnTop)
        Me.GroupBox1.Controls.Add(Me.TxtIsPrintLabel)
        Me.GroupBox1.Location = New System.Drawing.Point(512, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(211, 64)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'BarcodeonButtom
        '
        Me.BarcodeonButtom.AutoSize = True
        Me.BarcodeonButtom.Checked = True
        Me.BarcodeonButtom.Location = New System.Drawing.Point(97, 36)
        Me.BarcodeonButtom.Name = "BarcodeonButtom"
        Me.BarcodeonButtom.Size = New System.Drawing.Size(99, 17)
        Me.BarcodeonButtom.TabIndex = 7
        Me.BarcodeonButtom.TabStop = True
        Me.BarcodeonButtom.Text = "Print On Buttom"
        Me.BarcodeonButtom.UseVisualStyleBackColor = True
        '
        'BarcodeOnTop
        '
        Me.BarcodeOnTop.AutoSize = True
        Me.BarcodeOnTop.Location = New System.Drawing.Point(6, 36)
        Me.BarcodeOnTop.Name = "BarcodeOnTop"
        Me.BarcodeOnTop.Size = New System.Drawing.Size(85, 17)
        Me.BarcodeOnTop.TabIndex = 7
        Me.BarcodeOnTop.Text = "Print On Top"
        Me.BarcodeOnTop.UseVisualStyleBackColor = True
        '
        'TxtIsPrintLabel
        '
        Me.TxtIsPrintLabel.AutoSize = True
        Me.TxtIsPrintLabel.Location = New System.Drawing.Point(6, 13)
        Me.TxtIsPrintLabel.Name = "TxtIsPrintLabel"
        Me.TxtIsPrintLabel.Size = New System.Drawing.Size(93, 17)
        Me.TxtIsPrintLabel.TabIndex = 6
        Me.TxtIsPrintLabel.Text = "Print Barcode "
        Me.TxtIsPrintLabel.UseVisualStyleBackColor = True
        '
        'IsFirstBarcode
        '
        Me.IsFirstBarcode.Checked = True
        Me.IsFirstBarcode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IsFirstBarcode.Location = New System.Drawing.Point(1100, 19)
        Me.IsFirstBarcode.Name = "IsFirstBarcode"
        Me.IsFirstBarcode.Size = New System.Drawing.Size(109, 37)
        Me.IsFirstBarcode.TabIndex = 6
        Me.IsFirstBarcode.Text = "Print Barcode in First Position"
        Me.IsFirstBarcode.UseVisualStyleBackColor = True
        '
        'UserButton6
        '
        Me.UserButton6.BackColor = System.Drawing.SystemColors.Control
        Me.UserButton6.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.UserButton6.Location = New System.Drawing.Point(791, 95)
        Me.UserButton6.LostFocusFontColor = System.Drawing.Color.Blue
        Me.UserButton6.Name = "UserButton6"
        Me.UserButton6.Size = New System.Drawing.Size(75, 23)
        Me.UserButton6.TabIndex = 10
        Me.UserButton6.Text = "Next"
        Me.UserButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.UserButton6.UseFunctionKeys = False
        Me.UserButton6.UseVisualStyleBackColor = False
        '
        'UserButton5
        '
        Me.UserButton5.BackColor = System.Drawing.SystemColors.Control
        Me.UserButton5.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.UserButton5.Location = New System.Drawing.Point(710, 95)
        Me.UserButton5.LostFocusFontColor = System.Drawing.Color.Blue
        Me.UserButton5.Name = "UserButton5"
        Me.UserButton5.Size = New System.Drawing.Size(75, 23)
        Me.UserButton5.TabIndex = 9
        Me.UserButton5.Text = "Previous"
        Me.UserButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.UserButton5.UseFunctionKeys = False
        Me.UserButton5.UseVisualStyleBackColor = False
        '
        'TxtZoom
        '
        Me.TxtZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtZoom.FormattingEnabled = True
        Me.TxtZoom.Items.AddRange(New Object() {"Auto", "25%", "50%", "75%", "100%", "200%"})
        Me.TxtZoom.Location = New System.Drawing.Point(599, 97)
        Me.TxtZoom.Name = "TxtZoom"
        Me.TxtZoom.Size = New System.Drawing.Size(100, 21)
        Me.TxtZoom.TabIndex = 8
        '
        'TxtBarcodeType
        '
        Me.TxtBarcodeType.AllowEmpty = True
        Me.TxtBarcodeType.AllowOnlyListValues = False
        Me.TxtBarcodeType.AllowToolTip = True
        Me.TxtBarcodeType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtBarcodeType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtBarcodeType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtBarcodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtBarcodeType.FormattingEnabled = True
        Me.TxtBarcodeType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtBarcodeType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtBarcodeType.IsAllowDigits = True
        Me.TxtBarcodeType.IsAllowSpace = True
        Me.TxtBarcodeType.IsAllowSplChars = True
        Me.TxtBarcodeType.IsAllowToolTip = True
        Me.TxtBarcodeType.Items.AddRange(New Object() {"CODE-128", "CODE-39", "ENA-13"})
        Me.TxtBarcodeType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtBarcodeType.Location = New System.Drawing.Point(416, 92)
        Me.TxtBarcodeType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtBarcodeType.Name = "TxtBarcodeType"
        Me.TxtBarcodeType.SetToolTip = Nothing
        Me.TxtBarcodeType.Size = New System.Drawing.Size(90, 21)
        Me.TxtBarcodeType.Sorted = True
        Me.TxtBarcodeType.SpecialCharList = "&-/@"
        Me.TxtBarcodeType.TabIndex = 7
        Me.TxtBarcodeType.UseFunctionKeys = False
        '
        'TxtPaperSize
        '
        Me.TxtPaperSize.AllowEmpty = True
        Me.TxtPaperSize.AllowOnlyListValues = False
        Me.TxtPaperSize.AllowToolTip = True
        Me.TxtPaperSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtPaperSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtPaperSize.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtPaperSize.FormattingEnabled = True
        Me.TxtPaperSize.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPaperSize.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPaperSize.IsAllowDigits = True
        Me.TxtPaperSize.IsAllowSpace = True
        Me.TxtPaperSize.IsAllowSplChars = True
        Me.TxtPaperSize.IsAllowToolTip = True
        Me.TxtPaperSize.Items.AddRange(New Object() {"A4", "Legal", "Letter", "RollPaper"})
        Me.TxtPaperSize.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPaperSize.Location = New System.Drawing.Point(416, 68)
        Me.TxtPaperSize.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPaperSize.Name = "TxtPaperSize"
        Me.TxtPaperSize.SetToolTip = Nothing
        Me.TxtPaperSize.Size = New System.Drawing.Size(90, 21)
        Me.TxtPaperSize.Sorted = True
        Me.TxtPaperSize.SpecialCharList = "&-/@"
        Me.TxtPaperSize.TabIndex = 5
        Me.TxtPaperSize.UseFunctionKeys = False
        '
        'TxtNoofCopies
        '
        Me.TxtNoofCopies.AllHelpText = True
        Me.TxtNoofCopies.AllowDecimal = False
        Me.TxtNoofCopies.AllowFormulas = False
        Me.TxtNoofCopies.AllowForQty = True
        Me.TxtNoofCopies.AllowNegative = False
        Me.TxtNoofCopies.AllowPerSign = False
        Me.TxtNoofCopies.AllowPlusSign = False
        Me.TxtNoofCopies.AllowToolTip = True
        Me.TxtNoofCopies.DecimalPlaces = CType(3, Short)
        Me.TxtNoofCopies.ExitOnEscKey = True
        Me.TxtNoofCopies.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNoofCopies.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNoofCopies.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtNoofCopies.HelpText = Nothing
        Me.TxtNoofCopies.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNoofCopies.Location = New System.Drawing.Point(416, 47)
        Me.TxtNoofCopies.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNoofCopies.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtNoofCopies.Max = CType(9999, Long)
        Me.TxtNoofCopies.MaxLength = 12
        Me.TxtNoofCopies.Min = CType(1, Long)
        Me.TxtNoofCopies.Name = "TxtNoofCopies"
        Me.TxtNoofCopies.NextOnEnter = True
        Me.TxtNoofCopies.SetToolTip = Nothing
        Me.TxtNoofCopies.Size = New System.Drawing.Size(90, 20)
        Me.TxtNoofCopies.TabIndex = 4
        Me.TxtNoofCopies.Text = "1"
        Me.TxtNoofCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNoofCopies.ToolTip = Nothing
        Me.TxtNoofCopies.UseFunctionKeys = False
        Me.TxtNoofCopies.UseUpDownArrowKeys = False
        '
        'txtheight
        '
        Me.txtheight.AllHelpText = True
        Me.txtheight.AllowDecimal = False
        Me.txtheight.AllowFormulas = False
        Me.txtheight.AllowForQty = True
        Me.txtheight.AllowNegative = False
        Me.txtheight.AllowPerSign = False
        Me.txtheight.AllowPlusSign = False
        Me.txtheight.AllowToolTip = True
        Me.txtheight.DecimalPlaces = CType(3, Short)
        Me.txtheight.ExitOnEscKey = True
        Me.txtheight.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtheight.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtheight.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtheight.HelpText = Nothing
        Me.txtheight.LFocusBackColor = System.Drawing.Color.White
        Me.txtheight.Location = New System.Drawing.Point(416, 25)
        Me.txtheight.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtheight.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtheight.Max = CType(300, Long)
        Me.txtheight.MaxLength = 12
        Me.txtheight.Min = CType(10, Long)
        Me.txtheight.Name = "txtheight"
        Me.txtheight.NextOnEnter = True
        Me.txtheight.SetToolTip = Nothing
        Me.txtheight.Size = New System.Drawing.Size(90, 20)
        Me.txtheight.TabIndex = 3
        Me.txtheight.Text = "75"
        Me.txtheight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtheight.ToolTip = Nothing
        Me.txtheight.UseFunctionKeys = False
        Me.txtheight.UseUpDownArrowKeys = False
        '
        'TxtWidth
        '
        Me.TxtWidth.AllHelpText = True
        Me.TxtWidth.AllowDecimal = False
        Me.TxtWidth.AllowFormulas = False
        Me.TxtWidth.AllowForQty = True
        Me.TxtWidth.AllowNegative = False
        Me.TxtWidth.AllowPerSign = False
        Me.TxtWidth.AllowPlusSign = False
        Me.TxtWidth.AllowToolTip = True
        Me.TxtWidth.DecimalPlaces = CType(3, Short)
        Me.TxtWidth.ExitOnEscKey = True
        Me.TxtWidth.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtWidth.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtWidth.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtWidth.HelpText = Nothing
        Me.TxtWidth.LFocusBackColor = System.Drawing.Color.White
        Me.TxtWidth.Location = New System.Drawing.Point(416, 3)
        Me.TxtWidth.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtWidth.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtWidth.Max = CType(450, Long)
        Me.TxtWidth.MaxLength = 12
        Me.TxtWidth.Min = CType(10, Long)
        Me.TxtWidth.Name = "TxtWidth"
        Me.TxtWidth.NextOnEnter = True
        Me.TxtWidth.SetToolTip = Nothing
        Me.TxtWidth.Size = New System.Drawing.Size(90, 20)
        Me.TxtWidth.TabIndex = 2
        Me.TxtWidth.Text = "200"
        Me.TxtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtWidth.ToolTip = Nothing
        Me.TxtWidth.UseFunctionKeys = False
        Me.TxtWidth.UseUpDownArrowKeys = False
        '
        'TxtCustomBarcode
        '
        Me.TxtCustomBarcode.Location = New System.Drawing.Point(1155, 89)
        Me.TxtCustomBarcode.MaxLength = 30
        Me.TxtCustomBarcode.Name = "TxtCustomBarcode"
        Me.TxtCustomBarcode.Size = New System.Drawing.Size(45, 20)
        Me.TxtCustomBarcode.TabIndex = 8
        Me.TxtCustomBarcode.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(1045, 92)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(104, 17)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "Custom Barcode"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'TxtCat
        '
        Me.TxtCat.AllowEmpty = True
        Me.TxtCat.AllowOnlyListValues = False
        Me.TxtCat.AllowToolTip = True
        Me.TxtCat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtCat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtCat.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtCat.FormattingEnabled = True
        Me.TxtCat.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCat.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCat.IsAllowDigits = True
        Me.TxtCat.IsAllowSpace = True
        Me.TxtCat.IsAllowSplChars = True
        Me.TxtCat.IsAllowToolTip = True
        Me.TxtCat.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCat.Location = New System.Drawing.Point(100, 26)
        Me.TxtCat.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCat.Name = "TxtCat"
        Me.TxtCat.SetToolTip = Nothing
        Me.TxtCat.Size = New System.Drawing.Size(201, 21)
        Me.TxtCat.Sorted = True
        Me.TxtCat.SpecialCharList = "&-/@"
        Me.TxtCat.TabIndex = 1
        Me.TxtCat.UseFunctionKeys = False
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(1, 31)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(89, 13)
        Me.ImSlabel3.TabIndex = 3
        Me.ImSlabel3.Text = "Filter By Catogery"
        '
        'TxtGroup
        '
        Me.TxtGroup.AllowEmpty = True
        Me.TxtGroup.AllowOnlyListValues = False
        Me.TxtGroup.AllowToolTip = True
        Me.TxtGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtGroup.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtGroup.FormattingEnabled = True
        Me.TxtGroup.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtGroup.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtGroup.IsAllowDigits = True
        Me.TxtGroup.IsAllowSpace = True
        Me.TxtGroup.IsAllowSplChars = True
        Me.TxtGroup.IsAllowToolTip = True
        Me.TxtGroup.LFocusBackColor = System.Drawing.Color.White
        Me.TxtGroup.Location = New System.Drawing.Point(100, 1)
        Me.TxtGroup.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtGroup.Name = "TxtGroup"
        Me.TxtGroup.SetToolTip = Nothing
        Me.TxtGroup.Size = New System.Drawing.Size(201, 21)
        Me.TxtGroup.Sorted = True
        Me.TxtGroup.SpecialCharList = "&-/@"
        Me.TxtGroup.TabIndex = 0
        Me.TxtGroup.UseFunctionKeys = False
        '
        'ImSlabel8
        '
        Me.ImSlabel8.AutoSize = True
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(329, 96)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(74, 13)
        Me.ImSlabel8.TabIndex = 4
        Me.ImSlabel8.Text = "Barcode Type"
        '
        'ImSlabel7
        '
        Me.ImSlabel7.AutoSize = True
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(559, 102)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(34, 13)
        Me.ImSlabel7.TabIndex = 4
        Me.ImSlabel7.Text = "Zoom"
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(328, 73)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(58, 13)
        Me.ImSlabel6.TabIndex = 4
        Me.ImSlabel6.Text = "Paper Size"
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(328, 50)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(67, 13)
        Me.ImSlabel5.TabIndex = 4
        Me.ImSlabel5.Text = "No.of copies"
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(329, 28)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(81, 13)
        Me.ImSlabel4.TabIndex = 4
        Me.ImSlabel4.Text = "Barcode Height"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(329, 6)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(75, 13)
        Me.ImSlabel1.TabIndex = 4
        Me.ImSlabel1.Text = "Barcode width"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(2, 4)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(76, 13)
        Me.ImSlabel2.TabIndex = 4
        Me.ImSlabel2.Text = "Filter By Group"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ImsButton2)
        Me.Panel2.Controls.Add(Me.ImsButton1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 549)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(319, 53)
        Me.Panel2.TabIndex = 6
        '
        'ImsButton2
        '
        Me.ImsButton2.AllowToolTip = True
        Me.ImsButton2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton2.Location = New System.Drawing.Point(146, 3)
        Me.ImsButton2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton2.Name = "ImsButton2"
        Me.ImsButton2.SetToolTip = ""
        Me.ImsButton2.Size = New System.Drawing.Size(85, 23)
        Me.ImsButton2.TabIndex = 0
        Me.ImsButton2.Text = "Deselect All"
        Me.ImsButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton2.UseFunctionKeys = False
        Me.ImsButton2.UseVisualStyleBackColor = True
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Location = New System.Drawing.Point(11, 2)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(88, 24)
        Me.ImsButton1.TabIndex = 1
        Me.ImsButton1.Text = "Select All"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ImsButton4)
        Me.Panel3.Controls.Add(Me.ImsButton3)
        Me.Panel3.Controls.Add(Me.BtnPreview)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(319, 549)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(893, 53)
        Me.Panel3.TabIndex = 7
        '
        'ImsButton4
        '
        Me.ImsButton4.AllowToolTip = True
        Me.ImsButton4.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton4.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.print__1_
        Me.ImsButton4.Location = New System.Drawing.Point(472, 9)
        Me.ImsButton4.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton4.Name = "ImsButton4"
        Me.ImsButton4.SetToolTip = ""
        Me.ImsButton4.Size = New System.Drawing.Size(139, 39)
        Me.ImsButton4.TabIndex = 2
        Me.ImsButton4.Text = "Print"
        Me.ImsButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton4.UseFunctionKeys = False
        Me.ImsButton4.UseVisualStyleBackColor = True
        '
        'ImsButton3
        '
        Me.ImsButton3.AllowToolTip = True
        Me.ImsButton3.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton3.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.ImsButton3.Location = New System.Drawing.Point(34, 9)
        Me.ImsButton3.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton3.Name = "ImsButton3"
        Me.ImsButton3.SetToolTip = ""
        Me.ImsButton3.Size = New System.Drawing.Size(139, 39)
        Me.ImsButton3.TabIndex = 1
        Me.ImsButton3.Text = "Close"
        Me.ImsButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton3.UseFunctionKeys = False
        Me.ImsButton3.UseVisualStyleBackColor = True
        '
        'BtnPreview
        '
        Me.BtnPreview.AllowToolTip = True
        Me.BtnPreview.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnPreview.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.refresh2
        Me.BtnPreview.Location = New System.Drawing.Point(263, 9)
        Me.BtnPreview.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPreview.Name = "BtnPreview"
        Me.BtnPreview.SetToolTip = ""
        Me.BtnPreview.Size = New System.Drawing.Size(139, 39)
        Me.BtnPreview.TabIndex = 0
        Me.BtnPreview.Text = "Preview"
        Me.BtnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPreview.UseFunctionKeys = False
        Me.BtnPreview.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtList, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 148)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(313, 398)
        Me.TableLayoutPanel2.TabIndex = 8
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.TxtCat)
        Me.Panel4.Controls.Add(Me.ImSlabel2)
        Me.Panel4.Controls.Add(Me.TxtGroup)
        Me.Panel4.Controls.Add(Me.ImSlabel3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(313, 52)
        Me.Panel4.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TxtVGap)
        Me.GroupBox3.Controls.Add(Me.TxtHGap)
        Me.GroupBox3.Controls.Add(Me.TxtLeftGap)
        Me.GroupBox3.Controls.Add(Me.TxtTopGap)
        Me.GroupBox3.Controls.Add(Me.TxtNoOfColumns)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(308, 113)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Roll Paper Settings (in Pixels (1 Inch=100pi)"
        Me.GroupBox3.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No Of Columns"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Horizontal Gap"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Vertical Gap"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Top Gap"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Left Gap"
        '
        'TxtNoOfColumns
        '
        Me.TxtNoOfColumns.Location = New System.Drawing.Point(95, 15)
        Me.TxtNoOfColumns.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.TxtNoOfColumns.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtNoOfColumns.Name = "TxtNoOfColumns"
        Me.TxtNoOfColumns.Size = New System.Drawing.Size(82, 20)
        Me.TxtNoOfColumns.TabIndex = 1
        Me.TxtNoOfColumns.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'TxtTopGap
        '
        Me.TxtTopGap.Location = New System.Drawing.Point(95, 34)
        Me.TxtTopGap.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.TxtTopGap.Name = "TxtTopGap"
        Me.TxtTopGap.Size = New System.Drawing.Size(82, 20)
        Me.TxtTopGap.TabIndex = 1
        Me.TxtTopGap.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'TxtLeftGap
        '
        Me.TxtLeftGap.Location = New System.Drawing.Point(95, 53)
        Me.TxtLeftGap.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.TxtLeftGap.Name = "TxtLeftGap"
        Me.TxtLeftGap.Size = New System.Drawing.Size(82, 20)
        Me.TxtLeftGap.TabIndex = 1
        Me.TxtLeftGap.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'TxtHGap
        '
        Me.TxtHGap.Location = New System.Drawing.Point(95, 72)
        Me.TxtHGap.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.TxtHGap.Name = "TxtHGap"
        Me.TxtHGap.Size = New System.Drawing.Size(82, 20)
        Me.TxtHGap.TabIndex = 1
        Me.TxtHGap.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'TxtVGap
        '
        Me.TxtVGap.Location = New System.Drawing.Point(95, 93)
        Me.TxtVGap.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.TxtVGap.Name = "TxtVGap"
        Me.TxtVGap.Size = New System.Drawing.Size(82, 20)
        Me.TxtVGap.TabIndex = 1
        Me.TxtVGap.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'BarcodePrintingfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MintCream
        Me.ClientSize = New System.Drawing.Size(1212, 602)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "BarcodePrintingfrm"
        Me.Text = "BarcodePrintingfrm"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.PrintGroup.ResumeLayout(False)
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.TxtNoOfColumns, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTopGap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtLeftGap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtHGap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtVGap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtList As System.Windows.Forms.DataGridView
    Friend WithEvents TxtCat As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtGroup As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents PrintGroup As System.Windows.Forms.GroupBox
    Friend WithEvents PrintPreviewControl1 As System.Windows.Forms.PrintPreviewControl
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TxtPaperSize As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtNoofCopies As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents txtheight As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtWidth As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtCustomBarcode As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImsButton2 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtIsPrintLabel As System.Windows.Forms.CheckBox
    Friend WithEvents PrtDoc As System.Drawing.Printing.PrintDocument
    Friend WithEvents BtnPreview As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtZoom As System.Windows.Forms.ComboBox
    Friend WithEvents ImsButton4 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton3 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents UserButton6 As UserButton.UserButton
    Friend WithEvents UserButton5 As UserButton.UserButton
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtBarcodeType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BarcodeonButtom As System.Windows.Forms.RadioButton
    Friend WithEvents BarcodeOnTop As System.Windows.Forms.RadioButton
    Friend WithEvents IsPrintStockCodeAlso As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents StockCodeOnButtom As System.Windows.Forms.RadioButton
    Friend WithEvents StockCodeOnTop As System.Windows.Forms.RadioButton
    Friend WithEvents IsFirstBarcode As System.Windows.Forms.CheckBox
    Friend WithEvents IsPrintStockCodewithPrice As System.Windows.Forms.CheckBox
    Friend WithEvents ImSlabel9 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtPriceLevel As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents txtpriceSysmbol As System.Windows.Forms.TextBox
    Friend WithEvents ImSlabel10 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtVGap As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtHGap As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtLeftGap As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtTopGap As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtNoOfColumns As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
