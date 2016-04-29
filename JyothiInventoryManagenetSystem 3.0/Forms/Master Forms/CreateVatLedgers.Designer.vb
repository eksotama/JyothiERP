<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateVatLedgers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateVatLedgers))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ServiceTaxPanel = New System.Windows.Forms.Panel()
        Me.ImSlabel10 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel11 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtServiceTaxname = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel12 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtServiceTaxAmt = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtServiceTaxLedger = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtTaxType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel9 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.VatTaxPanel = New System.Windows.Forms.Panel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtVatName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtVatTax = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtSalesLedger = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Txtpurchaseledger = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtOutPutvat = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtInputVat = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ServiceTaxPanel.SuspendLayout()
        Me.VatTaxPanel.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(46, 10)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(138, 43)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'BtnCreate
        '
        Me.BtnCreate.AllowToolTip = True
        Me.BtnCreate.BackColor = System.Drawing.Color.White
        Me.BtnCreate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCreate.Image = CType(resources.GetObject("BtnCreate.Image"), System.Drawing.Image)
        Me.BtnCreate.Location = New System.Drawing.Point(337, 10)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(150, 43)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "&Create"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnClose)
        Me.Panel2.Controls.Add(Me.BtnCreate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 326)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(527, 61)
        Me.Panel2.TabIndex = 3
        '
        'TxtStatus
        '
        Me.TxtStatus.AutoSize = True
        Me.TxtStatus.BackColor = System.Drawing.Color.White
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Green
        Me.TxtStatus.Location = New System.Drawing.Point(3, 390)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(527, 24)
        Me.TxtStatus.TabIndex = 0
        Me.TxtStatus.Text = "Status: Ready"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.DarkOrange
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(527, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "VAT CLAUSES"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ServiceTaxPanel)
        Me.Panel1.Controls.Add(Me.TxtTaxType)
        Me.Panel1.Controls.Add(Me.ImSlabel9)
        Me.Panel1.Controls.Add(Me.VatTaxPanel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(527, 288)
        Me.Panel1.TabIndex = 2
        '
        'ServiceTaxPanel
        '
        Me.ServiceTaxPanel.Controls.Add(Me.ImSlabel10)
        Me.ServiceTaxPanel.Controls.Add(Me.ImSlabel11)
        Me.ServiceTaxPanel.Controls.Add(Me.TxtServiceTaxname)
        Me.ServiceTaxPanel.Controls.Add(Me.ImSlabel12)
        Me.ServiceTaxPanel.Controls.Add(Me.TxtServiceTaxAmt)
        Me.ServiceTaxPanel.Controls.Add(Me.TxtServiceTaxLedger)
        Me.ServiceTaxPanel.Location = New System.Drawing.Point(9, 28)
        Me.ServiceTaxPanel.Name = "ServiceTaxPanel"
        Me.ServiceTaxPanel.Size = New System.Drawing.Size(482, 235)
        Me.ServiceTaxPanel.TabIndex = 10
        '
        'ImSlabel10
        '
        Me.ImSlabel10.AutoSize = True
        Me.ImSlabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel10.Location = New System.Drawing.Point(13, 15)
        Me.ImSlabel10.Name = "ImSlabel10"
        Me.ImSlabel10.Size = New System.Drawing.Size(75, 13)
        Me.ImSlabel10.TabIndex = 0
        Me.ImSlabel10.Text = "Service Tax"
        '
        'ImSlabel11
        '
        Me.ImSlabel11.AutoSize = True
        Me.ImSlabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel11.Location = New System.Drawing.Point(13, 42)
        Me.ImSlabel11.Name = "ImSlabel11"
        Me.ImSlabel11.Size = New System.Drawing.Size(41, 13)
        Me.ImSlabel11.TabIndex = 0
        Me.ImSlabel11.Text = "Tax %"
        '
        'TxtServiceTaxname
        '
        Me.TxtServiceTaxname.AllowToolTip = True
        Me.TxtServiceTaxname.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtServiceTaxname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtServiceTaxname.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtServiceTaxname.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtServiceTaxname.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtServiceTaxname.IsAllowDigits = True
        Me.TxtServiceTaxname.IsAllowSpace = True
        Me.TxtServiceTaxname.IsAllowSplChars = True
        Me.TxtServiceTaxname.LFocusBackColor = System.Drawing.Color.White
        Me.TxtServiceTaxname.Location = New System.Drawing.Point(159, 12)
        Me.TxtServiceTaxname.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtServiceTaxname.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtServiceTaxname.MaxLength = 40
        Me.TxtServiceTaxname.Name = "TxtServiceTaxname"
        Me.TxtServiceTaxname.SetToolTip = Nothing
        Me.TxtServiceTaxname.Size = New System.Drawing.Size(170, 20)
        Me.TxtServiceTaxname.SpecialCharList = "&-/@"
        Me.TxtServiceTaxname.TabIndex = 0
        Me.TxtServiceTaxname.UseFunctionKeys = False
        '
        'ImSlabel12
        '
        Me.ImSlabel12.AutoSize = True
        Me.ImSlabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel12.Location = New System.Drawing.Point(13, 68)
        Me.ImSlabel12.Name = "ImSlabel12"
        Me.ImSlabel12.Size = New System.Drawing.Size(118, 13)
        Me.ImSlabel12.TabIndex = 0
        Me.ImSlabel12.Text = "Service Tax Ledger"
        '
        'TxtServiceTaxAmt
        '
        Me.TxtServiceTaxAmt.AllHelpText = True
        Me.TxtServiceTaxAmt.AllowDecimal = True
        Me.TxtServiceTaxAmt.AllowFormulas = False
        Me.TxtServiceTaxAmt.AllowForQty = True
        Me.TxtServiceTaxAmt.AllowNegative = False
        Me.TxtServiceTaxAmt.AllowPerSign = False
        Me.TxtServiceTaxAmt.AllowPlusSign = False
        Me.TxtServiceTaxAmt.AllowToolTip = True
        Me.TxtServiceTaxAmt.DecimalPlaces = CType(3, Short)
        Me.TxtServiceTaxAmt.ExitOnEscKey = True
        Me.TxtServiceTaxAmt.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtServiceTaxAmt.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtServiceTaxAmt.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtServiceTaxAmt.HelpText = Nothing
        Me.TxtServiceTaxAmt.LFocusBackColor = System.Drawing.Color.White
        Me.TxtServiceTaxAmt.Location = New System.Drawing.Point(159, 38)
        Me.TxtServiceTaxAmt.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtServiceTaxAmt.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtServiceTaxAmt.Max = CType(100000000000000, Long)
        Me.TxtServiceTaxAmt.MaxLength = 12
        Me.TxtServiceTaxAmt.Min = CType(0, Long)
        Me.TxtServiceTaxAmt.Name = "TxtServiceTaxAmt"
        Me.TxtServiceTaxAmt.NextOnEnter = True
        Me.TxtServiceTaxAmt.SetToolTip = Nothing
        Me.TxtServiceTaxAmt.Size = New System.Drawing.Size(100, 20)
        Me.TxtServiceTaxAmt.TabIndex = 1
        Me.TxtServiceTaxAmt.Text = "0"
        Me.TxtServiceTaxAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtServiceTaxAmt.ToolTip = Nothing
        Me.TxtServiceTaxAmt.UseFunctionKeys = False
        Me.TxtServiceTaxAmt.UseUpDownArrowKeys = False
        '
        'TxtServiceTaxLedger
        '
        Me.TxtServiceTaxLedger.AllowEmpty = True
        Me.TxtServiceTaxLedger.AllowOnlyListValues = True
        Me.TxtServiceTaxLedger.AllowToolTip = True
        Me.TxtServiceTaxLedger.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtServiceTaxLedger.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtServiceTaxLedger.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtServiceTaxLedger.FormattingEnabled = True
        Me.TxtServiceTaxLedger.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtServiceTaxLedger.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtServiceTaxLedger.IsAdvanceSearchWindow = False
        Me.TxtServiceTaxLedger.IsAllowDigits = True
        Me.TxtServiceTaxLedger.IsAllowSpace = True
        Me.TxtServiceTaxLedger.IsAllowSplChars = True
        Me.TxtServiceTaxLedger.IsAllowToolTip = True
        Me.TxtServiceTaxLedger.LFocusBackColor = System.Drawing.Color.White
        Me.TxtServiceTaxLedger.Location = New System.Drawing.Point(159, 65)
        Me.TxtServiceTaxLedger.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtServiceTaxLedger.Name = "TxtServiceTaxLedger"
        Me.TxtServiceTaxLedger.SetToolTip = Nothing
        Me.TxtServiceTaxLedger.Size = New System.Drawing.Size(308, 21)
        Me.TxtServiceTaxLedger.Sorted = True
        Me.TxtServiceTaxLedger.SpecialCharList = "&-/@"
        Me.TxtServiceTaxLedger.TabIndex = 2
        Me.TxtServiceTaxLedger.UseFunctionKeys = False
        '
        'TxtTaxType
        '
        Me.TxtTaxType.AllowEmpty = True
        Me.TxtTaxType.AllowOnlyListValues = True
        Me.TxtTaxType.AllowToolTip = True
        Me.TxtTaxType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtTaxType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtTaxType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtTaxType.FormattingEnabled = True
        Me.TxtTaxType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTaxType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTaxType.IsAdvanceSearchWindow = False
        Me.TxtTaxType.IsAllowDigits = True
        Me.TxtTaxType.IsAllowSpace = True
        Me.TxtTaxType.IsAllowSplChars = True
        Me.TxtTaxType.IsAllowToolTip = True
        Me.TxtTaxType.Items.AddRange(New Object() {"CST", "Service Tax", "VAT"})
        Me.TxtTaxType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTaxType.Location = New System.Drawing.Point(168, 3)
        Me.TxtTaxType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTaxType.Name = "TxtTaxType"
        Me.TxtTaxType.SetToolTip = Nothing
        Me.TxtTaxType.Size = New System.Drawing.Size(166, 21)
        Me.TxtTaxType.Sorted = True
        Me.TxtTaxType.SpecialCharList = "&-/@"
        Me.TxtTaxType.TabIndex = 0
        Me.TxtTaxType.UseFunctionKeys = False
        '
        'ImSlabel9
        '
        Me.ImSlabel9.AutoSize = True
        Me.ImSlabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel9.Location = New System.Drawing.Point(18, 6)
        Me.ImSlabel9.Name = "ImSlabel9"
        Me.ImSlabel9.Size = New System.Drawing.Size(60, 13)
        Me.ImSlabel9.TabIndex = 0
        Me.ImSlabel9.Text = "Tax Type"
        '
        'VatTaxPanel
        '
        Me.VatTaxPanel.Controls.Add(Me.ImSlabel1)
        Me.VatTaxPanel.Controls.Add(Me.ImSlabel2)
        Me.VatTaxPanel.Controls.Add(Me.TxtVatName)
        Me.VatTaxPanel.Controls.Add(Me.ImSlabel3)
        Me.VatTaxPanel.Controls.Add(Me.TxtVatTax)
        Me.VatTaxPanel.Controls.Add(Me.ImSlabel4)
        Me.VatTaxPanel.Controls.Add(Me.ImSlabel5)
        Me.VatTaxPanel.Controls.Add(Me.TxtSalesLedger)
        Me.VatTaxPanel.Controls.Add(Me.ImSlabel7)
        Me.VatTaxPanel.Controls.Add(Me.Txtpurchaseledger)
        Me.VatTaxPanel.Controls.Add(Me.TxtOutPutvat)
        Me.VatTaxPanel.Controls.Add(Me.TxtInputVat)
        Me.VatTaxPanel.Location = New System.Drawing.Point(9, 28)
        Me.VatTaxPanel.Name = "VatTaxPanel"
        Me.VatTaxPanel.Size = New System.Drawing.Size(501, 232)
        Me.VatTaxPanel.TabIndex = 9
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(13, 11)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(109, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "VAT Clause Name"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(13, 45)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(44, 13)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "VAT %"
        '
        'TxtVatName
        '
        Me.TxtVatName.AllowToolTip = True
        Me.TxtVatName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtVatName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtVatName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtVatName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtVatName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtVatName.IsAllowDigits = True
        Me.TxtVatName.IsAllowSpace = True
        Me.TxtVatName.IsAllowSplChars = True
        Me.TxtVatName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtVatName.Location = New System.Drawing.Point(157, 8)
        Me.TxtVatName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtVatName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtVatName.MaxLength = 40
        Me.TxtVatName.Name = "TxtVatName"
        Me.TxtVatName.SetToolTip = Nothing
        Me.TxtVatName.Size = New System.Drawing.Size(310, 20)
        Me.TxtVatName.SpecialCharList = "&-/@"
        Me.TxtVatName.TabIndex = 0
        Me.TxtVatName.UseFunctionKeys = False
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(13, 79)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(107, 13)
        Me.ImSlabel3.TabIndex = 0
        Me.ImSlabel3.Text = "Input VAT Ledger"
        '
        'TxtVatTax
        '
        Me.TxtVatTax.AllHelpText = True
        Me.TxtVatTax.AllowDecimal = True
        Me.TxtVatTax.AllowFormulas = False
        Me.TxtVatTax.AllowForQty = True
        Me.TxtVatTax.AllowNegative = False
        Me.TxtVatTax.AllowPerSign = False
        Me.TxtVatTax.AllowPlusSign = False
        Me.TxtVatTax.AllowToolTip = True
        Me.TxtVatTax.DecimalPlaces = CType(3, Short)
        Me.TxtVatTax.ExitOnEscKey = True
        Me.TxtVatTax.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtVatTax.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtVatTax.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtVatTax.HelpText = Nothing
        Me.TxtVatTax.LFocusBackColor = System.Drawing.Color.White
        Me.TxtVatTax.Location = New System.Drawing.Point(158, 39)
        Me.TxtVatTax.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtVatTax.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtVatTax.Max = CType(100000000000000, Long)
        Me.TxtVatTax.MaxLength = 12
        Me.TxtVatTax.Min = CType(0, Long)
        Me.TxtVatTax.Name = "TxtVatTax"
        Me.TxtVatTax.NextOnEnter = True
        Me.TxtVatTax.SetToolTip = Nothing
        Me.TxtVatTax.Size = New System.Drawing.Size(100, 20)
        Me.TxtVatTax.TabIndex = 1
        Me.TxtVatTax.Text = "0"
        Me.TxtVatTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtVatTax.ToolTip = Nothing
        Me.TxtVatTax.UseFunctionKeys = False
        Me.TxtVatTax.UseUpDownArrowKeys = False
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(13, 113)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(116, 13)
        Me.ImSlabel4.TabIndex = 0
        Me.ImSlabel4.Text = "Output VAT Ledger"
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(13, 147)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(103, 13)
        Me.ImSlabel5.TabIndex = 0
        Me.ImSlabel5.Text = "Purchase Ledger"
        '
        'TxtSalesLedger
        '
        Me.TxtSalesLedger.AllowEmpty = True
        Me.TxtSalesLedger.AllowOnlyListValues = True
        Me.TxtSalesLedger.AllowToolTip = True
        Me.TxtSalesLedger.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtSalesLedger.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtSalesLedger.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtSalesLedger.FormattingEnabled = True
        Me.TxtSalesLedger.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSalesLedger.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSalesLedger.IsAdvanceSearchWindow = False
        Me.TxtSalesLedger.IsAllowDigits = True
        Me.TxtSalesLedger.IsAllowSpace = True
        Me.TxtSalesLedger.IsAllowSplChars = True
        Me.TxtSalesLedger.IsAllowToolTip = True
        Me.TxtSalesLedger.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSalesLedger.Location = New System.Drawing.Point(159, 181)
        Me.TxtSalesLedger.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSalesLedger.Name = "TxtSalesLedger"
        Me.TxtSalesLedger.SetToolTip = Nothing
        Me.TxtSalesLedger.Size = New System.Drawing.Size(308, 21)
        Me.TxtSalesLedger.Sorted = True
        Me.TxtSalesLedger.SpecialCharList = "&-/@"
        Me.TxtSalesLedger.TabIndex = 5
        Me.TxtSalesLedger.UseFunctionKeys = False
        '
        'ImSlabel7
        '
        Me.ImSlabel7.AutoSize = True
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(13, 184)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(81, 13)
        Me.ImSlabel7.TabIndex = 0
        Me.ImSlabel7.Text = "Sales Ledger"
        '
        'Txtpurchaseledger
        '
        Me.Txtpurchaseledger.AllowEmpty = True
        Me.Txtpurchaseledger.AllowOnlyListValues = True
        Me.Txtpurchaseledger.AllowToolTip = True
        Me.Txtpurchaseledger.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Txtpurchaseledger.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Txtpurchaseledger.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.Txtpurchaseledger.FormattingEnabled = True
        Me.Txtpurchaseledger.GFocusBackColor = System.Drawing.Color.Yellow
        Me.Txtpurchaseledger.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.Txtpurchaseledger.IsAdvanceSearchWindow = False
        Me.Txtpurchaseledger.IsAllowDigits = True
        Me.Txtpurchaseledger.IsAllowSpace = True
        Me.Txtpurchaseledger.IsAllowSplChars = True
        Me.Txtpurchaseledger.IsAllowToolTip = True
        Me.Txtpurchaseledger.LFocusBackColor = System.Drawing.Color.White
        Me.Txtpurchaseledger.Location = New System.Drawing.Point(159, 144)
        Me.Txtpurchaseledger.LostFocusFontColor = System.Drawing.Color.Blue
        Me.Txtpurchaseledger.Name = "Txtpurchaseledger"
        Me.Txtpurchaseledger.SetToolTip = Nothing
        Me.Txtpurchaseledger.Size = New System.Drawing.Size(308, 21)
        Me.Txtpurchaseledger.Sorted = True
        Me.Txtpurchaseledger.SpecialCharList = "&-/@"
        Me.Txtpurchaseledger.TabIndex = 4
        Me.Txtpurchaseledger.UseFunctionKeys = False
        '
        'TxtOutPutvat
        '
        Me.TxtOutPutvat.AllowEmpty = True
        Me.TxtOutPutvat.AllowOnlyListValues = True
        Me.TxtOutPutvat.AllowToolTip = True
        Me.TxtOutPutvat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtOutPutvat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtOutPutvat.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtOutPutvat.FormattingEnabled = True
        Me.TxtOutPutvat.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtOutPutvat.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtOutPutvat.IsAdvanceSearchWindow = False
        Me.TxtOutPutvat.IsAllowDigits = True
        Me.TxtOutPutvat.IsAllowSpace = True
        Me.TxtOutPutvat.IsAllowSplChars = True
        Me.TxtOutPutvat.IsAllowToolTip = True
        Me.TxtOutPutvat.LFocusBackColor = System.Drawing.Color.White
        Me.TxtOutPutvat.Location = New System.Drawing.Point(159, 110)
        Me.TxtOutPutvat.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtOutPutvat.Name = "TxtOutPutvat"
        Me.TxtOutPutvat.SetToolTip = Nothing
        Me.TxtOutPutvat.Size = New System.Drawing.Size(308, 21)
        Me.TxtOutPutvat.Sorted = True
        Me.TxtOutPutvat.SpecialCharList = "&-/@"
        Me.TxtOutPutvat.TabIndex = 3
        Me.TxtOutPutvat.UseFunctionKeys = False
        '
        'TxtInputVat
        '
        Me.TxtInputVat.AllowEmpty = True
        Me.TxtInputVat.AllowOnlyListValues = True
        Me.TxtInputVat.AllowToolTip = True
        Me.TxtInputVat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtInputVat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtInputVat.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtInputVat.FormattingEnabled = True
        Me.TxtInputVat.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtInputVat.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtInputVat.IsAdvanceSearchWindow = False
        Me.TxtInputVat.IsAllowDigits = True
        Me.TxtInputVat.IsAllowSpace = True
        Me.TxtInputVat.IsAllowSplChars = True
        Me.TxtInputVat.IsAllowToolTip = True
        Me.TxtInputVat.LFocusBackColor = System.Drawing.Color.White
        Me.TxtInputVat.Location = New System.Drawing.Point(159, 76)
        Me.TxtInputVat.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtInputVat.Name = "TxtInputVat"
        Me.TxtInputVat.SetToolTip = Nothing
        Me.TxtInputVat.Size = New System.Drawing.Size(308, 21)
        Me.TxtInputVat.Sorted = True
        Me.TxtInputVat.SpecialCharList = "&-/@"
        Me.TxtInputVat.TabIndex = 2
        Me.TxtInputVat.UseFunctionKeys = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtStatus, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(533, 414)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'CreateVatLedgers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(533, 414)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CreateVatLedgers"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CreateVatLedgers"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ServiceTaxPanel.ResumeLayout(False)
        Me.ServiceTaxPanel.PerformLayout()
        Me.VatTaxPanel.ResumeLayout(False)
        Me.VatTaxPanel.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtStatus As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtVatName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtVatTax As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtSalesLedger As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Txtpurchaseledger As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtOutPutvat As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtInputVat As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtTaxType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel9 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents VatTaxPanel As System.Windows.Forms.Panel
    Friend WithEvents ServiceTaxPanel As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel10 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel11 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtServiceTaxname As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel12 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtServiceTaxAmt As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtServiceTaxLedger As JyothiPharmaERPSystem3.IMSComboBox

End Class
