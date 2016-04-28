<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DefaultLedgerSettingsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DefaultLedgerSettingsForm))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtPOSPayment = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtSalesRet = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtSales = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtpurchaseRet = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtPurchase = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtCommisionLedger = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtRoundOffLedger = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtPurchaseDiscountLedger = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtSalesDiscountLedger = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtCashAccount = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel10 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel9 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel13 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel12 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel11 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnClose)
        Me.Panel2.Controls.Add(Me.BtnCreate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 437)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(587, 53)
        Me.Panel2.TabIndex = 3
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(45, 3)
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
        Me.BtnCreate.Location = New System.Drawing.Point(324, 3)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(150, 43)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "Save"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = False
        '
        'TxtStatus
        '
        Me.TxtStatus.AutoSize = True
        Me.TxtStatus.BackColor = System.Drawing.Color.White
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Green
        Me.TxtStatus.Location = New System.Drawing.Point(3, 493)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(587, 24)
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
        Me.Label1.Size = New System.Drawing.Size(587, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "DEFAULT LEDGER ACCOUNTS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtPOSPayment)
        Me.Panel1.Controls.Add(Me.TxtSalesRet)
        Me.Panel1.Controls.Add(Me.TxtSales)
        Me.Panel1.Controls.Add(Me.TxtpurchaseRet)
        Me.Panel1.Controls.Add(Me.TxtPurchase)
        Me.Panel1.Controls.Add(Me.TxtCommisionLedger)
        Me.Panel1.Controls.Add(Me.TxtRoundOffLedger)
        Me.Panel1.Controls.Add(Me.TxtPurchaseDiscountLedger)
        Me.Panel1.Controls.Add(Me.TxtSalesDiscountLedger)
        Me.Panel1.Controls.Add(Me.TxtCashAccount)
        Me.Panel1.Controls.Add(Me.ImSlabel7)
        Me.Panel1.Controls.Add(Me.ImSlabel10)
        Me.Panel1.Controls.Add(Me.ImSlabel6)
        Me.Panel1.Controls.Add(Me.ImSlabel5)
        Me.Panel1.Controls.Add(Me.ImSlabel9)
        Me.Panel1.Controls.Add(Me.ImSlabel13)
        Me.Panel1.Controls.Add(Me.ImSlabel4)
        Me.Panel1.Controls.Add(Me.ImSlabel8)
        Me.Panel1.Controls.Add(Me.ImSlabel3)
        Me.Panel1.Controls.Add(Me.ImSlabel12)
        Me.Panel1.Controls.Add(Me.ImSlabel11)
        Me.Panel1.Controls.Add(Me.ImSlabel2)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(587, 399)
        Me.Panel1.TabIndex = 2
        '
        'TxtPOSPayment
        '
        Me.TxtPOSPayment.AllowEmpty = True
        Me.TxtPOSPayment.AllowOnlyListValues = True
        Me.TxtPOSPayment.AllowToolTip = True
        Me.TxtPOSPayment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtPOSPayment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtPOSPayment.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtPOSPayment.FormattingEnabled = True
        Me.TxtPOSPayment.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPOSPayment.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPOSPayment.IsAdvanceSearchWindow = False
        Me.TxtPOSPayment.IsAllowDigits = True
        Me.TxtPOSPayment.IsAllowSpace = True
        Me.TxtPOSPayment.IsAllowSplChars = True
        Me.TxtPOSPayment.IsAllowToolTip = True
        Me.TxtPOSPayment.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPOSPayment.Location = New System.Drawing.Point(178, 230)
        Me.TxtPOSPayment.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPOSPayment.Name = "TxtPOSPayment"
        Me.TxtPOSPayment.SetToolTip = "Press Alt+C, To Create New "
        Me.TxtPOSPayment.Size = New System.Drawing.Size(340, 21)
        Me.TxtPOSPayment.Sorted = True
        Me.TxtPOSPayment.SpecialCharList = "&-/@"
        Me.TxtPOSPayment.TabIndex = 5
        Me.TxtPOSPayment.UseFunctionKeys = False
        '
        'TxtSalesRet
        '
        Me.TxtSalesRet.AllowEmpty = True
        Me.TxtSalesRet.AllowOnlyListValues = True
        Me.TxtSalesRet.AllowToolTip = True
        Me.TxtSalesRet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtSalesRet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtSalesRet.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtSalesRet.FormattingEnabled = True
        Me.TxtSalesRet.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSalesRet.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSalesRet.IsAdvanceSearchWindow = False
        Me.TxtSalesRet.IsAllowDigits = True
        Me.TxtSalesRet.IsAllowSpace = True
        Me.TxtSalesRet.IsAllowSplChars = True
        Me.TxtSalesRet.IsAllowToolTip = True
        Me.TxtSalesRet.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSalesRet.Location = New System.Drawing.Point(178, 188)
        Me.TxtSalesRet.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSalesRet.Name = "TxtSalesRet"
        Me.TxtSalesRet.SetToolTip = "Press Alt+C, To Create New "
        Me.TxtSalesRet.Size = New System.Drawing.Size(340, 21)
        Me.TxtSalesRet.Sorted = True
        Me.TxtSalesRet.SpecialCharList = "&-/@"
        Me.TxtSalesRet.TabIndex = 4
        Me.TxtSalesRet.UseFunctionKeys = False
        '
        'TxtSales
        '
        Me.TxtSales.AllowEmpty = True
        Me.TxtSales.AllowOnlyListValues = True
        Me.TxtSales.AllowToolTip = True
        Me.TxtSales.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtSales.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtSales.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtSales.FormattingEnabled = True
        Me.TxtSales.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSales.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSales.IsAdvanceSearchWindow = False
        Me.TxtSales.IsAllowDigits = True
        Me.TxtSales.IsAllowSpace = True
        Me.TxtSales.IsAllowSplChars = True
        Me.TxtSales.IsAllowToolTip = True
        Me.TxtSales.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSales.Location = New System.Drawing.Point(178, 143)
        Me.TxtSales.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSales.Name = "TxtSales"
        Me.TxtSales.SetToolTip = "Press Alt+C, To Create New "
        Me.TxtSales.Size = New System.Drawing.Size(340, 21)
        Me.TxtSales.Sorted = True
        Me.TxtSales.SpecialCharList = "&-/@"
        Me.TxtSales.TabIndex = 3
        Me.TxtSales.UseFunctionKeys = False
        '
        'TxtpurchaseRet
        '
        Me.TxtpurchaseRet.AllowEmpty = True
        Me.TxtpurchaseRet.AllowOnlyListValues = True
        Me.TxtpurchaseRet.AllowToolTip = True
        Me.TxtpurchaseRet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtpurchaseRet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtpurchaseRet.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtpurchaseRet.FormattingEnabled = True
        Me.TxtpurchaseRet.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtpurchaseRet.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtpurchaseRet.IsAdvanceSearchWindow = False
        Me.TxtpurchaseRet.IsAllowDigits = True
        Me.TxtpurchaseRet.IsAllowSpace = True
        Me.TxtpurchaseRet.IsAllowSplChars = True
        Me.TxtpurchaseRet.IsAllowToolTip = True
        Me.TxtpurchaseRet.LFocusBackColor = System.Drawing.Color.White
        Me.TxtpurchaseRet.Location = New System.Drawing.Point(178, 99)
        Me.TxtpurchaseRet.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtpurchaseRet.Name = "TxtpurchaseRet"
        Me.TxtpurchaseRet.SetToolTip = "Press Alt+C, To Create New "
        Me.TxtpurchaseRet.Size = New System.Drawing.Size(340, 21)
        Me.TxtpurchaseRet.Sorted = True
        Me.TxtpurchaseRet.SpecialCharList = "&-/@"
        Me.TxtpurchaseRet.TabIndex = 2
        Me.TxtpurchaseRet.UseFunctionKeys = False
        '
        'TxtPurchase
        '
        Me.TxtPurchase.AllowEmpty = True
        Me.TxtPurchase.AllowOnlyListValues = True
        Me.TxtPurchase.AllowToolTip = True
        Me.TxtPurchase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtPurchase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtPurchase.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtPurchase.FormattingEnabled = True
        Me.TxtPurchase.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPurchase.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPurchase.IsAdvanceSearchWindow = False
        Me.TxtPurchase.IsAllowDigits = True
        Me.TxtPurchase.IsAllowSpace = True
        Me.TxtPurchase.IsAllowSplChars = True
        Me.TxtPurchase.IsAllowToolTip = True
        Me.TxtPurchase.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPurchase.Location = New System.Drawing.Point(178, 59)
        Me.TxtPurchase.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPurchase.Name = "TxtPurchase"
        Me.TxtPurchase.SetToolTip = "Press Alt+C, To Create New "
        Me.TxtPurchase.Size = New System.Drawing.Size(340, 21)
        Me.TxtPurchase.Sorted = True
        Me.TxtPurchase.SpecialCharList = "&-/@"
        Me.TxtPurchase.TabIndex = 1
        Me.TxtPurchase.UseFunctionKeys = False
        '
        'TxtCommisionLedger
        '
        Me.TxtCommisionLedger.AllowEmpty = True
        Me.TxtCommisionLedger.AllowOnlyListValues = True
        Me.TxtCommisionLedger.AllowToolTip = True
        Me.TxtCommisionLedger.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtCommisionLedger.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtCommisionLedger.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtCommisionLedger.FormattingEnabled = True
        Me.TxtCommisionLedger.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCommisionLedger.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCommisionLedger.IsAdvanceSearchWindow = False
        Me.TxtCommisionLedger.IsAllowDigits = True
        Me.TxtCommisionLedger.IsAllowSpace = True
        Me.TxtCommisionLedger.IsAllowSplChars = True
        Me.TxtCommisionLedger.IsAllowToolTip = True
        Me.TxtCommisionLedger.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCommisionLedger.Location = New System.Drawing.Point(178, 365)
        Me.TxtCommisionLedger.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCommisionLedger.Name = "TxtCommisionLedger"
        Me.TxtCommisionLedger.SetToolTip = "Press Alt+C, To Create New "
        Me.TxtCommisionLedger.Size = New System.Drawing.Size(340, 21)
        Me.TxtCommisionLedger.Sorted = True
        Me.TxtCommisionLedger.SpecialCharList = "&-/@"
        Me.TxtCommisionLedger.TabIndex = 8
        Me.TxtCommisionLedger.UseFunctionKeys = False
        '
        'TxtRoundOffLedger
        '
        Me.TxtRoundOffLedger.AllowEmpty = True
        Me.TxtRoundOffLedger.AllowOnlyListValues = True
        Me.TxtRoundOffLedger.AllowToolTip = True
        Me.TxtRoundOffLedger.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtRoundOffLedger.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtRoundOffLedger.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtRoundOffLedger.FormattingEnabled = True
        Me.TxtRoundOffLedger.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtRoundOffLedger.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtRoundOffLedger.IsAdvanceSearchWindow = False
        Me.TxtRoundOffLedger.IsAllowDigits = True
        Me.TxtRoundOffLedger.IsAllowSpace = True
        Me.TxtRoundOffLedger.IsAllowSplChars = True
        Me.TxtRoundOffLedger.IsAllowToolTip = True
        Me.TxtRoundOffLedger.LFocusBackColor = System.Drawing.Color.White
        Me.TxtRoundOffLedger.Location = New System.Drawing.Point(178, 333)
        Me.TxtRoundOffLedger.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtRoundOffLedger.Name = "TxtRoundOffLedger"
        Me.TxtRoundOffLedger.SetToolTip = "Press Alt+C, To Create New "
        Me.TxtRoundOffLedger.Size = New System.Drawing.Size(340, 21)
        Me.TxtRoundOffLedger.Sorted = True
        Me.TxtRoundOffLedger.SpecialCharList = "&-/@"
        Me.TxtRoundOffLedger.TabIndex = 8
        Me.TxtRoundOffLedger.UseFunctionKeys = False
        '
        'TxtPurchaseDiscountLedger
        '
        Me.TxtPurchaseDiscountLedger.AllowEmpty = True
        Me.TxtPurchaseDiscountLedger.AllowOnlyListValues = True
        Me.TxtPurchaseDiscountLedger.AllowToolTip = True
        Me.TxtPurchaseDiscountLedger.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtPurchaseDiscountLedger.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtPurchaseDiscountLedger.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtPurchaseDiscountLedger.FormattingEnabled = True
        Me.TxtPurchaseDiscountLedger.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPurchaseDiscountLedger.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPurchaseDiscountLedger.IsAdvanceSearchWindow = False
        Me.TxtPurchaseDiscountLedger.IsAllowDigits = True
        Me.TxtPurchaseDiscountLedger.IsAllowSpace = True
        Me.TxtPurchaseDiscountLedger.IsAllowSplChars = True
        Me.TxtPurchaseDiscountLedger.IsAllowToolTip = True
        Me.TxtPurchaseDiscountLedger.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPurchaseDiscountLedger.Location = New System.Drawing.Point(178, 301)
        Me.TxtPurchaseDiscountLedger.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPurchaseDiscountLedger.Name = "TxtPurchaseDiscountLedger"
        Me.TxtPurchaseDiscountLedger.SetToolTip = "Press Alt+C, To Create New "
        Me.TxtPurchaseDiscountLedger.Size = New System.Drawing.Size(340, 21)
        Me.TxtPurchaseDiscountLedger.Sorted = True
        Me.TxtPurchaseDiscountLedger.SpecialCharList = "&-/@"
        Me.TxtPurchaseDiscountLedger.TabIndex = 7
        Me.TxtPurchaseDiscountLedger.UseFunctionKeys = False
        '
        'TxtSalesDiscountLedger
        '
        Me.TxtSalesDiscountLedger.AllowEmpty = True
        Me.TxtSalesDiscountLedger.AllowOnlyListValues = True
        Me.TxtSalesDiscountLedger.AllowToolTip = True
        Me.TxtSalesDiscountLedger.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtSalesDiscountLedger.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtSalesDiscountLedger.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtSalesDiscountLedger.FormattingEnabled = True
        Me.TxtSalesDiscountLedger.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSalesDiscountLedger.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSalesDiscountLedger.IsAdvanceSearchWindow = False
        Me.TxtSalesDiscountLedger.IsAllowDigits = True
        Me.TxtSalesDiscountLedger.IsAllowSpace = True
        Me.TxtSalesDiscountLedger.IsAllowSplChars = True
        Me.TxtSalesDiscountLedger.IsAllowToolTip = True
        Me.TxtSalesDiscountLedger.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSalesDiscountLedger.Location = New System.Drawing.Point(178, 263)
        Me.TxtSalesDiscountLedger.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSalesDiscountLedger.Name = "TxtSalesDiscountLedger"
        Me.TxtSalesDiscountLedger.SetToolTip = "Press Alt+C, To Create New "
        Me.TxtSalesDiscountLedger.Size = New System.Drawing.Size(340, 21)
        Me.TxtSalesDiscountLedger.Sorted = True
        Me.TxtSalesDiscountLedger.SpecialCharList = "&-/@"
        Me.TxtSalesDiscountLedger.TabIndex = 6
        Me.TxtSalesDiscountLedger.UseFunctionKeys = False
        '
        'TxtCashAccount
        '
        Me.TxtCashAccount.AllowEmpty = True
        Me.TxtCashAccount.AllowOnlyListValues = True
        Me.TxtCashAccount.AllowToolTip = True
        Me.TxtCashAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtCashAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtCashAccount.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtCashAccount.FormattingEnabled = True
        Me.TxtCashAccount.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCashAccount.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCashAccount.IsAdvanceSearchWindow = False
        Me.TxtCashAccount.IsAllowDigits = True
        Me.TxtCashAccount.IsAllowSpace = True
        Me.TxtCashAccount.IsAllowSplChars = True
        Me.TxtCashAccount.IsAllowToolTip = True
        Me.TxtCashAccount.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCashAccount.Location = New System.Drawing.Point(178, 26)
        Me.TxtCashAccount.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCashAccount.Name = "TxtCashAccount"
        Me.TxtCashAccount.SetToolTip = "Press Alt+C, To Create New "
        Me.TxtCashAccount.Size = New System.Drawing.Size(340, 21)
        Me.TxtCashAccount.Sorted = True
        Me.TxtCashAccount.SpecialCharList = "&-/@"
        Me.TxtCashAccount.TabIndex = 0
        Me.TxtCashAccount.UseFunctionKeys = False
        '
        'ImSlabel7
        '
        Me.ImSlabel7.AutoSize = True
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(10, 231)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(159, 13)
        Me.ImSlabel7.TabIndex = 0
        Me.ImSlabel7.Text = "Default Payment Option for POS"
        '
        'ImSlabel10
        '
        Me.ImSlabel10.AutoSize = True
        Me.ImSlabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel10.Location = New System.Drawing.Point(11, 203)
        Me.ImSlabel10.Name = "ImSlabel10"
        Me.ImSlabel10.Size = New System.Drawing.Size(66, 13)
        Me.ImSlabel10.TabIndex = 0
        Me.ImSlabel10.Text = "(Credit Note)"
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(11, 188)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(116, 13)
        Me.ImSlabel6.TabIndex = 0
        Me.ImSlabel6.Text = "Sales Returns Account"
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(11, 146)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(117, 13)
        Me.ImSlabel5.TabIndex = 0
        Me.ImSlabel5.Text = "Sales Ledger Accounts"
        '
        'ImSlabel9
        '
        Me.ImSlabel9.AutoSize = True
        Me.ImSlabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel9.Location = New System.Drawing.Point(11, 112)
        Me.ImSlabel9.Name = "ImSlabel9"
        Me.ImSlabel9.Size = New System.Drawing.Size(64, 13)
        Me.ImSlabel9.TabIndex = 0
        Me.ImSlabel9.Text = "(Debit Note)"
        '
        'ImSlabel13
        '
        Me.ImSlabel13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel13.Location = New System.Drawing.Point(11, 365)
        Me.ImSlabel13.Name = "ImSlabel13"
        Me.ImSlabel13.Size = New System.Drawing.Size(120, 21)
        Me.ImSlabel13.TabIndex = 0
        Me.ImSlabel13.Text = "Commision Ledger"
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(11, 99)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(135, 13)
        Me.ImSlabel4.TabIndex = 0
        Me.ImSlabel4.Text = "Purchase Returns Account"
        '
        'ImSlabel8
        '
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(11, 333)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(120, 21)
        Me.ImSlabel8.TabIndex = 0
        Me.ImSlabel8.Text = "Round Off Ledger"
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(11, 62)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(136, 13)
        Me.ImSlabel3.TabIndex = 0
        Me.ImSlabel3.Text = "Purchase Ledger Accounts"
        '
        'ImSlabel12
        '
        Me.ImSlabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel12.Location = New System.Drawing.Point(11, 301)
        Me.ImSlabel12.Name = "ImSlabel12"
        Me.ImSlabel12.Size = New System.Drawing.Size(120, 34)
        Me.ImSlabel12.TabIndex = 0
        Me.ImSlabel12.Text = "Discounct Ledger for Purchase Invoice"
        '
        'ImSlabel11
        '
        Me.ImSlabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel11.Location = New System.Drawing.Point(11, 263)
        Me.ImSlabel11.Name = "ImSlabel11"
        Me.ImSlabel11.Size = New System.Drawing.Size(120, 34)
        Me.ImSlabel11.TabIndex = 0
        Me.ImSlabel11.Text = "Discount Ledger For Sales Invoice"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(11, 26)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(110, 13)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "Cash Ledger Account"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(33, 0)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(511, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "Select the Ledger Account for Default Ledger Accounts (To Create Ledger, Press Al" & _
    "t+C )"
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(593, 517)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'DefaultLedgerSettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(593, 517)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DefaultLedgerSettingsForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Default Ledger Accounts"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtSalesRet As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtSales As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtpurchaseRet As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtPurchase As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtCashAccount As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel10 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel9 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtPOSPayment As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtPurchaseDiscountLedger As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtSalesDiscountLedger As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel12 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel11 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtRoundOffLedger As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtCommisionLedger As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel13 As JyothiPharmaERPSystem3.IMSlabel

End Class
