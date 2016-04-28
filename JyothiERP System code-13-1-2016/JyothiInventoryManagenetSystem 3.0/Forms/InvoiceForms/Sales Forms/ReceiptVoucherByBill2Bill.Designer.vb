<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReceiptVoucherByBill2Bill
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtPayLedgerName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtPaidAmount = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.BtnChequeDetails = New System.Windows.Forms.Panel()
        Me.TxtChequeDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtPrintName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtChequeNo = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel11 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel10 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel12 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.BtnClose2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnSave2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtNarration2 = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtDate2 = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtLedgerName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtRefNo = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtVoucherNo2 = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel9 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.VhTitle3 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PostDatedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.BtnChequeDetails.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtPayLedgerName)
        Me.Panel1.Controls.Add(Me.TxtPaidAmount)
        Me.Panel1.Controls.Add(Me.BtnChequeDetails)
        Me.Panel1.Controls.Add(Me.BtnClose2)
        Me.Panel1.Controls.Add(Me.BtnSave2)
        Me.Panel1.Controls.Add(Me.TxtNarration2)
        Me.Panel1.Controls.Add(Me.TxtDate2)
        Me.Panel1.Controls.Add(Me.TxtLedgerName)
        Me.Panel1.Controls.Add(Me.TxtRefNo)
        Me.Panel1.Controls.Add(Me.TxtVoucherNo2)
        Me.Panel1.Controls.Add(Me.ImSlabel3)
        Me.Panel1.Controls.Add(Me.ImSlabel5)
        Me.Panel1.Controls.Add(Me.ImSlabel4)
        Me.Panel1.Controls.Add(Me.ImSlabel6)
        Me.Panel1.Controls.Add(Me.ImSlabel2)
        Me.Panel1.Controls.Add(Me.ImSlabel9)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Controls.Add(Me.VhTitle3)
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(598, 409)
        Me.Panel1.TabIndex = 2
        '
        'TxtPayLedgerName
        '
        Me.TxtPayLedgerName.AllowEmpty = True
        Me.TxtPayLedgerName.AllowOnlyListValues = False
        Me.TxtPayLedgerName.AllowToolTip = True
        Me.TxtPayLedgerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtPayLedgerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtPayLedgerName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtPayLedgerName.FormattingEnabled = True
        Me.TxtPayLedgerName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPayLedgerName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPayLedgerName.IsAllowDigits = True
        Me.TxtPayLedgerName.IsAllowSpace = True
        Me.TxtPayLedgerName.IsAllowSplChars = True
        Me.TxtPayLedgerName.IsAllowToolTip = True
        Me.TxtPayLedgerName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPayLedgerName.Location = New System.Drawing.Point(125, 149)
        Me.TxtPayLedgerName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPayLedgerName.Name = "TxtPayLedgerName"
        Me.TxtPayLedgerName.SetToolTip = Nothing
        Me.TxtPayLedgerName.Size = New System.Drawing.Size(263, 21)
        Me.TxtPayLedgerName.Sorted = True
        Me.TxtPayLedgerName.SpecialCharList = "&-/@"
        Me.TxtPayLedgerName.TabIndex = 4
        Me.TxtPayLedgerName.UseFunctionKeys = False
        '
        'TxtPaidAmount
        '
        Me.TxtPaidAmount.AllHelpText = True
        Me.TxtPaidAmount.AllowDecimal = False
        Me.TxtPaidAmount.AllowFormulas = False
        Me.TxtPaidAmount.AllowForQty = True
        Me.TxtPaidAmount.AllowNegative = False
        Me.TxtPaidAmount.AllowPerSign = False
        Me.TxtPaidAmount.AllowPlusSign = False
        Me.TxtPaidAmount.AllowToolTip = True
        Me.TxtPaidAmount.DecimalPlaces = CType(3, Short)
        Me.TxtPaidAmount.ExitOnEscKey = True
        Me.TxtPaidAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPaidAmount.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPaidAmount.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPaidAmount.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtPaidAmount.HelpText = Nothing
        Me.TxtPaidAmount.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPaidAmount.Location = New System.Drawing.Point(125, 118)
        Me.TxtPaidAmount.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPaidAmount.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtPaidAmount.Max = CType(100000000000000, Long)
        Me.TxtPaidAmount.MaxLength = 30
        Me.TxtPaidAmount.Min = CType(0, Long)
        Me.TxtPaidAmount.Name = "TxtPaidAmount"
        Me.TxtPaidAmount.NextOnEnter = True
        Me.TxtPaidAmount.SetToolTip = Nothing
        Me.TxtPaidAmount.Size = New System.Drawing.Size(107, 20)
        Me.TxtPaidAmount.TabIndex = 3
        Me.TxtPaidAmount.Text = "0"
        Me.TxtPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtPaidAmount.ToolTip = Nothing
        Me.TxtPaidAmount.UseFunctionKeys = False
        Me.TxtPaidAmount.UseUpDownArrowKeys = False
        '
        'BtnChequeDetails
        '
        Me.BtnChequeDetails.Controls.Add(Me.TxtChequeDate)
        Me.BtnChequeDetails.Controls.Add(Me.TxtPrintName)
        Me.BtnChequeDetails.Controls.Add(Me.TxtChequeNo)
        Me.BtnChequeDetails.Controls.Add(Me.ImSlabel11)
        Me.BtnChequeDetails.Controls.Add(Me.ImSlabel10)
        Me.BtnChequeDetails.Controls.Add(Me.ImSlabel12)
        Me.BtnChequeDetails.Location = New System.Drawing.Point(3, 176)
        Me.BtnChequeDetails.Name = "BtnChequeDetails"
        Me.BtnChequeDetails.Size = New System.Drawing.Size(367, 73)
        Me.BtnChequeDetails.TabIndex = 5
        Me.BtnChequeDetails.Visible = False
        '
        'TxtChequeDate
        '
        Me.TxtChequeDate.Location = New System.Drawing.Point(121, 49)
        Me.TxtChequeDate.Name = "TxtChequeDate"
        Me.TxtChequeDate.Size = New System.Drawing.Size(190, 20)
        Me.TxtChequeDate.TabIndex = 2
        '
        'TxtPrintName
        '
        Me.TxtPrintName.AllowToolTip = True
        Me.TxtPrintName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtPrintName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPrintName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPrintName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtPrintName.IsAllowDigits = True
        Me.TxtPrintName.IsAllowSpace = True
        Me.TxtPrintName.IsAllowSplChars = True
        Me.TxtPrintName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPrintName.Location = New System.Drawing.Point(121, 28)
        Me.TxtPrintName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPrintName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtPrintName.MaxLength = 75
        Me.TxtPrintName.Name = "TxtPrintName"
        Me.TxtPrintName.SetToolTip = Nothing
        Me.TxtPrintName.Size = New System.Drawing.Size(190, 20)
        Me.TxtPrintName.SpecialCharList = "&-/@"
        Me.TxtPrintName.TabIndex = 1
        Me.TxtPrintName.UseFunctionKeys = False
        '
        'TxtChequeNo
        '
        Me.TxtChequeNo.AllowToolTip = True
        Me.TxtChequeNo.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtChequeNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtChequeNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtChequeNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtChequeNo.IsAllowDigits = True
        Me.TxtChequeNo.IsAllowSpace = True
        Me.TxtChequeNo.IsAllowSplChars = True
        Me.TxtChequeNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtChequeNo.Location = New System.Drawing.Point(121, 7)
        Me.TxtChequeNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtChequeNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtChequeNo.MaxLength = 49
        Me.TxtChequeNo.Name = "TxtChequeNo"
        Me.TxtChequeNo.SetToolTip = Nothing
        Me.TxtChequeNo.Size = New System.Drawing.Size(190, 20)
        Me.TxtChequeNo.SpecialCharList = "&-/@"
        Me.TxtChequeNo.TabIndex = 0
        Me.TxtChequeNo.UseFunctionKeys = False
        '
        'ImSlabel11
        '
        Me.ImSlabel11.AutoSize = True
        Me.ImSlabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel11.Location = New System.Drawing.Point(10, 49)
        Me.ImSlabel11.Name = "ImSlabel11"
        Me.ImSlabel11.Size = New System.Drawing.Size(34, 13)
        Me.ImSlabel11.TabIndex = 0
        Me.ImSlabel11.Text = "Date"
        '
        'ImSlabel10
        '
        Me.ImSlabel10.AutoSize = True
        Me.ImSlabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel10.Location = New System.Drawing.Point(10, 28)
        Me.ImSlabel10.Name = "ImSlabel10"
        Me.ImSlabel10.Size = New System.Drawing.Size(39, 13)
        Me.ImSlabel10.TabIndex = 0
        Me.ImSlabel10.Text = "Name"
        '
        'ImSlabel12
        '
        Me.ImSlabel12.AutoSize = True
        Me.ImSlabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel12.Location = New System.Drawing.Point(10, 8)
        Me.ImSlabel12.Name = "ImSlabel12"
        Me.ImSlabel12.Size = New System.Drawing.Size(70, 13)
        Me.ImSlabel12.TabIndex = 0
        Me.ImSlabel12.Text = "Cheque No"
        '
        'BtnClose2
        '
        Me.BtnClose2.AllowToolTip = True
        Me.BtnClose2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose2.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose2.Location = New System.Drawing.Point(263, 341)
        Me.BtnClose2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose2.Name = "BtnClose2"
        Me.BtnClose2.SetToolTip = ""
        Me.BtnClose2.Size = New System.Drawing.Size(141, 46)
        Me.BtnClose2.TabIndex = 7
        Me.BtnClose2.Text = "Close"
        Me.BtnClose2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose2.UseFunctionKeys = False
        Me.BtnClose2.UseVisualStyleBackColor = True
        '
        'BtnSave2
        '
        Me.BtnSave2.AllowToolTip = True
        Me.BtnSave2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnSave2.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.Save__1_
        Me.BtnSave2.Location = New System.Drawing.Point(426, 341)
        Me.BtnSave2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnSave2.Name = "BtnSave2"
        Me.BtnSave2.SetToolTip = ""
        Me.BtnSave2.Size = New System.Drawing.Size(141, 46)
        Me.BtnSave2.TabIndex = 6
        Me.BtnSave2.Text = "Save"
        Me.BtnSave2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave2.UseFunctionKeys = False
        Me.BtnSave2.UseVisualStyleBackColor = True
        '
        'TxtNarration2
        '
        Me.TxtNarration2.AllowToolTip = True
        Me.TxtNarration2.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtNarration2.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNarration2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNarration2.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtNarration2.IsAllowDigits = True
        Me.TxtNarration2.IsAllowSpace = True
        Me.TxtNarration2.IsAllowSplChars = True
        Me.TxtNarration2.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNarration2.Location = New System.Drawing.Point(19, 289)
        Me.TxtNarration2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNarration2.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtNarration2.MaxLength = 75
        Me.TxtNarration2.Multiline = True
        Me.TxtNarration2.Name = "TxtNarration2"
        Me.TxtNarration2.SetToolTip = Nothing
        Me.TxtNarration2.Size = New System.Drawing.Size(245, 46)
        Me.TxtNarration2.SpecialCharList = "&-/@"
        Me.TxtNarration2.TabIndex = 5
        Me.TxtNarration2.UseFunctionKeys = False
        '
        'TxtDate2
        '
        Me.TxtDate2.Location = New System.Drawing.Point(394, 31)
        Me.TxtDate2.Name = "TxtDate2"
        Me.TxtDate2.Size = New System.Drawing.Size(162, 20)
        Me.TxtDate2.TabIndex = 1
        '
        'TxtLedgerName
        '
        Me.TxtLedgerName.AllowToolTip = True
        Me.TxtLedgerName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtLedgerName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLedgerName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLedgerName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtLedgerName.IsAllowDigits = True
        Me.TxtLedgerName.IsAllowSpace = True
        Me.TxtLedgerName.IsAllowSplChars = True
        Me.TxtLedgerName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLedgerName.Location = New System.Drawing.Point(124, 84)
        Me.TxtLedgerName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLedgerName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtLedgerName.MaxLength = 50
        Me.TxtLedgerName.Name = "TxtLedgerName"
        Me.TxtLedgerName.ReadOnly = True
        Me.TxtLedgerName.SetToolTip = Nothing
        Me.TxtLedgerName.Size = New System.Drawing.Size(264, 20)
        Me.TxtLedgerName.SpecialCharList = "&-/@"
        Me.TxtLedgerName.TabIndex = 2
        Me.TxtLedgerName.UseFunctionKeys = False
        '
        'TxtRefNo
        '
        Me.TxtRefNo.AllowToolTip = True
        Me.TxtRefNo.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtRefNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtRefNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtRefNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtRefNo.IsAllowDigits = True
        Me.TxtRefNo.IsAllowSpace = True
        Me.TxtRefNo.IsAllowSplChars = True
        Me.TxtRefNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtRefNo.Location = New System.Drawing.Point(125, 57)
        Me.TxtRefNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtRefNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtRefNo.MaxLength = 50
        Me.TxtRefNo.Name = "TxtRefNo"
        Me.TxtRefNo.SetToolTip = Nothing
        Me.TxtRefNo.Size = New System.Drawing.Size(100, 20)
        Me.TxtRefNo.SpecialCharList = "&-/@"
        Me.TxtRefNo.TabIndex = 2
        Me.TxtRefNo.UseFunctionKeys = False
        '
        'TxtVoucherNo2
        '
        Me.TxtVoucherNo2.AllowToolTip = True
        Me.TxtVoucherNo2.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtVoucherNo2.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtVoucherNo2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtVoucherNo2.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtVoucherNo2.IsAllowDigits = True
        Me.TxtVoucherNo2.IsAllowSpace = True
        Me.TxtVoucherNo2.IsAllowSplChars = True
        Me.TxtVoucherNo2.LFocusBackColor = System.Drawing.Color.White
        Me.TxtVoucherNo2.Location = New System.Drawing.Point(125, 31)
        Me.TxtVoucherNo2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtVoucherNo2.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtVoucherNo2.MaxLength = 50
        Me.TxtVoucherNo2.Name = "TxtVoucherNo2"
        Me.TxtVoucherNo2.SetToolTip = Nothing
        Me.TxtVoucherNo2.Size = New System.Drawing.Size(100, 20)
        Me.TxtVoucherNo2.SpecialCharList = "&-/@"
        Me.TxtVoucherNo2.TabIndex = 0
        Me.TxtVoucherNo2.UseFunctionKeys = False
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(303, 34)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(85, 13)
        Me.ImSlabel3.TabIndex = 1
        Me.ImSlabel3.Text = "Voucher Date"
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(12, 152)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(72, 13)
        Me.ImSlabel5.TabIndex = 1
        Me.ImSlabel5.Text = "By Account"
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(12, 121)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(107, 13)
        Me.ImSlabel4.TabIndex = 1
        Me.ImSlabel4.Text = "Received Amount"
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(13, 87)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(89, 13)
        Me.ImSlabel6.TabIndex = 1
        Me.ImSlabel6.Text = "For Customer :"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(12, 60)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(47, 13)
        Me.ImSlabel2.TabIndex = 1
        Me.ImSlabel2.Text = "Ref No"
        '
        'ImSlabel9
        '
        Me.ImSlabel9.AutoSize = True
        Me.ImSlabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel9.Location = New System.Drawing.Point(16, 270)
        Me.ImSlabel9.Name = "ImSlabel9"
        Me.ImSlabel9.Size = New System.Drawing.Size(65, 13)
        Me.ImSlabel9.TabIndex = 1
        Me.ImSlabel9.Text = "Narrations"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(12, 35)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(105, 13)
        Me.ImSlabel1.TabIndex = 1
        Me.ImSlabel1.Text = "Voucher Number:"
        '
        'VhTitle3
        '
        Me.VhTitle3.BackColor = System.Drawing.Color.Green
        Me.VhTitle3.Dock = System.Windows.Forms.DockStyle.Top
        Me.VhTitle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VhTitle3.ForeColor = System.Drawing.Color.White
        Me.VhTitle3.Location = New System.Drawing.Point(0, 0)
        Me.VhTitle3.Margin = New System.Windows.Forms.Padding(0)
        Me.VhTitle3.Name = "VhTitle3"
        Me.VhTitle3.Size = New System.Drawing.Size(598, 25)
        Me.VhTitle3.TabIndex = 0
        Me.VhTitle3.Text = "RECEIPT VOUCHER"
        Me.VhTitle3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.VhTitle3.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(238, 50)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(202, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.CloseToolStripMenuItem, Me.SaveToolStripMenuItem, Me.PostDatedToolStripMenuItem, Me.ClearListToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        Me.MenuToolStripMenuItem.Visible = False
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.CloseToolStripMenuItem.Text = "close"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'PostDatedToolStripMenuItem
        '
        Me.PostDatedToolStripMenuItem.Name = "PostDatedToolStripMenuItem"
        Me.PostDatedToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
                    Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PostDatedToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.PostDatedToolStripMenuItem.Text = "PostDated"
        '
        'ClearListToolStripMenuItem
        '
        Me.ClearListToolStripMenuItem.Name = "ClearListToolStripMenuItem"
        Me.ClearListToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
                    Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.ClearListToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ClearListToolStripMenuItem.Text = "ClearList"
        '
        'ReceiptVoucherByBill2Bill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose2
        Me.ClientSize = New System.Drawing.Size(598, 409)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReceiptVoucherByBill2Bill"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ReceiptVoucherByBill2Bill"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.BtnChequeDetails.ResumeLayout(False)
        Me.BtnChequeDetails.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnChequeDetails As System.Windows.Forms.Panel
    Friend WithEvents TxtChequeDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtPrintName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtChequeNo As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel11 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel10 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel12 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PostDatedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnClose2 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnSave2 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtNarration2 As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtDate2 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtRefNo As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtVoucherNo2 As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel9 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents VhTitle3 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtPaidAmount As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtPayLedgerName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtLedgerName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel

End Class
