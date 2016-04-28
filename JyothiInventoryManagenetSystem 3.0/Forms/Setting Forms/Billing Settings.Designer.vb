<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Billing_Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Billing_Settings))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtInvoicePostFix = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtInvoicePreFix = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtInvoicenoStart = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtAllowDuplicates = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtInvoiceMethod = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtPreview = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtTitle = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblAllowDuplicates = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtLocation = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtSelectedSettings = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtStatus, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(496, 458)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TxtStatus
        '
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Green
        Me.TxtStatus.Location = New System.Drawing.Point(3, 427)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(490, 31)
        Me.TxtStatus.TabIndex = 4
        Me.TxtStatus.Text = "Status: Ready"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.BtnClose)
        Me.Panel3.Controls.Add(Me.BtnCreate)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 373)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(490, 51)
        Me.Panel3.TabIndex = 3
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(32, 3)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(161, 43)
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
        Me.BtnCreate.Location = New System.Drawing.Point(271, 3)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(175, 43)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "&Save"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.DarkOrange
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(496, 30)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "INVOICE BILLING FORMAT SETTINGS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.TxtLocation)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.TxtSelectedSettings)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 33)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(490, 334)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtInvoicePostFix)
        Me.Panel2.Controls.Add(Me.TxtInvoicePreFix)
        Me.Panel2.Controls.Add(Me.TxtInvoicenoStart)
        Me.Panel2.Controls.Add(Me.TxtAllowDuplicates)
        Me.Panel2.Controls.Add(Me.TxtInvoiceMethod)
        Me.Panel2.Controls.Add(Me.TxtPreview)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.TxtTitle)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.lblAllowDuplicates)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Enabled = False
        Me.Panel2.Location = New System.Drawing.Point(34, 86)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(389, 223)
        Me.Panel2.TabIndex = 15
        '
        'TxtInvoicePostFix
        '
        Me.TxtInvoicePostFix.AllowToolTip = True
        Me.TxtInvoicePostFix.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtInvoicePostFix.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtInvoicePostFix.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtInvoicePostFix.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtInvoicePostFix.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtInvoicePostFix.IsAllowDigits = True
        Me.TxtInvoicePostFix.IsAllowSpace = True
        Me.TxtInvoicePostFix.IsAllowSplChars = True
        Me.TxtInvoicePostFix.LFocusBackColor = System.Drawing.Color.White
        Me.TxtInvoicePostFix.Location = New System.Drawing.Point(205, 182)
        Me.TxtInvoicePostFix.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtInvoicePostFix.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtInvoicePostFix.MaxLength = 75
        Me.TxtInvoicePostFix.Name = "TxtInvoicePostFix"
        Me.TxtInvoicePostFix.SetToolTip = Nothing
        Me.TxtInvoicePostFix.Size = New System.Drawing.Size(176, 20)
        Me.TxtInvoicePostFix.SpecialCharList = "&-/@"
        Me.TxtInvoicePostFix.TabIndex = 21
        Me.TxtInvoicePostFix.UseFunctionKeys = False
        '
        'TxtInvoicePreFix
        '
        Me.TxtInvoicePreFix.AllowToolTip = True
        Me.TxtInvoicePreFix.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtInvoicePreFix.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtInvoicePreFix.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtInvoicePreFix.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtInvoicePreFix.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtInvoicePreFix.IsAllowDigits = True
        Me.TxtInvoicePreFix.IsAllowSpace = True
        Me.TxtInvoicePreFix.IsAllowSplChars = True
        Me.TxtInvoicePreFix.LFocusBackColor = System.Drawing.Color.White
        Me.TxtInvoicePreFix.Location = New System.Drawing.Point(205, 147)
        Me.TxtInvoicePreFix.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtInvoicePreFix.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtInvoicePreFix.MaxLength = 75
        Me.TxtInvoicePreFix.Name = "TxtInvoicePreFix"
        Me.TxtInvoicePreFix.SetToolTip = Nothing
        Me.TxtInvoicePreFix.Size = New System.Drawing.Size(176, 20)
        Me.TxtInvoicePreFix.SpecialCharList = "&-/@"
        Me.TxtInvoicePreFix.TabIndex = 22
        Me.TxtInvoicePreFix.UseFunctionKeys = False
        '
        'TxtInvoicenoStart
        '
        Me.TxtInvoicenoStart.AllHelpText = True
        Me.TxtInvoicenoStart.AllowDecimal = False
        Me.TxtInvoicenoStart.AllowFormulas = False
        Me.TxtInvoicenoStart.AllowForQty = True
        Me.TxtInvoicenoStart.AllowNegative = False
        Me.TxtInvoicenoStart.AllowPerSign = False
        Me.TxtInvoicenoStart.AllowPlusSign = False
        Me.TxtInvoicenoStart.AllowToolTip = True
        Me.TxtInvoicenoStart.DecimalPlaces = CType(3, Short)
        Me.TxtInvoicenoStart.ExitOnEscKey = True
        Me.TxtInvoicenoStart.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtInvoicenoStart.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtInvoicenoStart.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtInvoicenoStart.HelpText = Nothing
        Me.TxtInvoicenoStart.LFocusBackColor = System.Drawing.Color.White
        Me.TxtInvoicenoStart.Location = New System.Drawing.Point(205, 116)
        Me.TxtInvoicenoStart.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtInvoicenoStart.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtInvoicenoStart.Max = CType(100000000000000, Long)
        Me.TxtInvoicenoStart.MaxLength = 12
        Me.TxtInvoicenoStart.Min = CType(0, Long)
        Me.TxtInvoicenoStart.Name = "TxtInvoicenoStart"
        Me.TxtInvoicenoStart.NextOnEnter = True
        Me.TxtInvoicenoStart.SetToolTip = Nothing
        Me.TxtInvoicenoStart.Size = New System.Drawing.Size(178, 20)
        Me.TxtInvoicenoStart.TabIndex = 20
        Me.TxtInvoicenoStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtInvoicenoStart.ToolTip = Nothing
        Me.TxtInvoicenoStart.UseFunctionKeys = False
        Me.TxtInvoicenoStart.UseUpDownArrowKeys = False
        '
        'TxtAllowDuplicates
        '
        Me.TxtAllowDuplicates.AllowEmpty = True
        Me.TxtAllowDuplicates.AllowOnlyListValues = True
        Me.TxtAllowDuplicates.AllowToolTip = True
        Me.TxtAllowDuplicates.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtAllowDuplicates.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtAllowDuplicates.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtAllowDuplicates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtAllowDuplicates.FormattingEnabled = True
        Me.TxtAllowDuplicates.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtAllowDuplicates.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtAllowDuplicates.IsAdvanceSearchWindow = False
        Me.TxtAllowDuplicates.IsAllowDigits = True
        Me.TxtAllowDuplicates.IsAllowSpace = True
        Me.TxtAllowDuplicates.IsAllowSplChars = True
        Me.TxtAllowDuplicates.IsAllowToolTip = True
        Me.TxtAllowDuplicates.Items.AddRange(New Object() {"NO", "YES"})
        Me.TxtAllowDuplicates.LFocusBackColor = System.Drawing.Color.White
        Me.TxtAllowDuplicates.Location = New System.Drawing.Point(203, 88)
        Me.TxtAllowDuplicates.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtAllowDuplicates.Name = "TxtAllowDuplicates"
        Me.TxtAllowDuplicates.SetToolTip = Nothing
        Me.TxtAllowDuplicates.Size = New System.Drawing.Size(178, 21)
        Me.TxtAllowDuplicates.Sorted = True
        Me.TxtAllowDuplicates.SpecialCharList = "&-/@"
        Me.TxtAllowDuplicates.TabIndex = 19
        Me.TxtAllowDuplicates.UseFunctionKeys = False
        '
        'TxtInvoiceMethod
        '
        Me.TxtInvoiceMethod.AllowEmpty = True
        Me.TxtInvoiceMethod.AllowOnlyListValues = True
        Me.TxtInvoiceMethod.AllowToolTip = True
        Me.TxtInvoiceMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtInvoiceMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtInvoiceMethod.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtInvoiceMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtInvoiceMethod.FormattingEnabled = True
        Me.TxtInvoiceMethod.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtInvoiceMethod.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtInvoiceMethod.IsAdvanceSearchWindow = False
        Me.TxtInvoiceMethod.IsAllowDigits = True
        Me.TxtInvoiceMethod.IsAllowSpace = True
        Me.TxtInvoiceMethod.IsAllowSplChars = True
        Me.TxtInvoiceMethod.IsAllowToolTip = True
        Me.TxtInvoiceMethod.Items.AddRange(New Object() {"Automatic", "Manual"})
        Me.TxtInvoiceMethod.LFocusBackColor = System.Drawing.Color.White
        Me.TxtInvoiceMethod.Location = New System.Drawing.Point(205, 56)
        Me.TxtInvoiceMethod.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtInvoiceMethod.Name = "TxtInvoiceMethod"
        Me.TxtInvoiceMethod.SetToolTip = Nothing
        Me.TxtInvoiceMethod.Size = New System.Drawing.Size(178, 21)
        Me.TxtInvoiceMethod.Sorted = True
        Me.TxtInvoiceMethod.SpecialCharList = "&-/@"
        Me.TxtInvoiceMethod.TabIndex = 19
        Me.TxtInvoiceMethod.UseFunctionKeys = False
        '
        'TxtPreview
        '
        Me.TxtPreview.AutoSize = True
        Me.TxtPreview.Location = New System.Drawing.Point(6, 221)
        Me.TxtPreview.Name = "TxtPreview"
        Me.TxtPreview.Size = New System.Drawing.Size(0, 13)
        Me.TxtPreview.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Invoice Post Fix"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Invoice Pre Fix"
        '
        'TxtTitle
        '
        Me.TxtTitle.BackColor = System.Drawing.Color.DarkOrange
        Me.TxtTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitle.ForeColor = System.Drawing.Color.White
        Me.TxtTitle.Location = New System.Drawing.Point(6, 16)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(375, 19)
        Me.TxtTitle.TabIndex = 17
        Me.TxtTitle.Text = "SALES "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(174, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Method of Invoice Numbering"
        '
        'lblAllowDuplicates
        '
        Me.lblAllowDuplicates.AutoSize = True
        Me.lblAllowDuplicates.Location = New System.Drawing.Point(6, 88)
        Me.lblAllowDuplicates.Name = "lblAllowDuplicates"
        Me.lblAllowDuplicates.Size = New System.Drawing.Size(172, 13)
        Me.lblAllowDuplicates.TabIndex = 15
        Me.lblAllowDuplicates.Text = "Allow duplicates Invoice No?"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(175, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Invoice Number Starting From"
        '
        'TxtLocation
        '
        Me.TxtLocation.AllowEmpty = True
        Me.TxtLocation.AllowOnlyListValues = False
        Me.TxtLocation.AllowToolTip = True
        Me.TxtLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtLocation.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLocation.FormattingEnabled = True
        Me.TxtLocation.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLocation.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLocation.IsAdvanceSearchWindow = False
        Me.TxtLocation.IsAllowDigits = True
        Me.TxtLocation.IsAllowSpace = True
        Me.TxtLocation.IsAllowSplChars = True
        Me.TxtLocation.IsAllowToolTip = True
        Me.TxtLocation.Items.AddRange(New Object() {"CONTRA", "JOURNAL", "PAYMENT", "POS", "PURCHASE", "PURCHASE ENQUIRY", "PURCHASE GOODS RECEIVED", "PURCHASE ORDERS", "PURCHASE RETURN VOUCHER", "PURCHASE RETURNS", "PURCHASE VOUCHER", "RECEIPT", "SALES", "SALES DELIVERY NOTE", "SALES ORDERS", "SALES QUOTATION", "SALES RETURN VOUCHER", "SALES RETURNS", "SALES VOUCHER", "STOCK JOURNAL"})
        Me.TxtLocation.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLocation.Location = New System.Drawing.Point(207, 13)
        Me.TxtLocation.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLocation.Name = "TxtLocation"
        Me.TxtLocation.SetToolTip = Nothing
        Me.TxtLocation.Size = New System.Drawing.Size(206, 23)
        Me.TxtLocation.Sorted = True
        Me.TxtLocation.SpecialCharList = "&-/@"
        Me.TxtLocation.TabIndex = 14
        Me.TxtLocation.UseFunctionKeys = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(29, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(172, 15)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Select Branch or Location"
        '
        'TxtSelectedSettings
        '
        Me.TxtSelectedSettings.AllowEmpty = True
        Me.TxtSelectedSettings.AllowOnlyListValues = False
        Me.TxtSelectedSettings.AllowToolTip = True
        Me.TxtSelectedSettings.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtSelectedSettings.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtSelectedSettings.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtSelectedSettings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtSelectedSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSelectedSettings.FormattingEnabled = True
        Me.TxtSelectedSettings.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSelectedSettings.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSelectedSettings.IsAdvanceSearchWindow = False
        Me.TxtSelectedSettings.IsAllowDigits = True
        Me.TxtSelectedSettings.IsAllowSpace = True
        Me.TxtSelectedSettings.IsAllowSplChars = True
        Me.TxtSelectedSettings.IsAllowToolTip = True
        Me.TxtSelectedSettings.Items.AddRange(New Object() {"CASH PURCHASE", "CASH SALES", "CONTRA", "CREDIT PURCHASE", "CREDIT SALES", "JOURNAL", "PAYMENT", "POS", "PURCHASE", "PURCHASE ENQUIRY", "PURCHASE GOODS RECEIVED", "PURCHASE ORDERS", "PURCHASE RETURN VOUCHER", "PURCHASE RETURNS", "PURCHASE VOUCHER", "RECEIPT", "SALES", "SALES DELIVERY NOTE", "SALES FORM8", "SALES FORM8B", "SALES FORM8D", "SALES ORDERS", "SALES QUOTATION", "SALES RETURN VOUCHER", "SALES RETURNS", "SALES RETURNS FORM8", "SALES RETURNS FORM8B", "SALES RETURNS FORM8D", "SALES VOUCHER", "STOCK JOURNAL"})
        Me.TxtSelectedSettings.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSelectedSettings.Location = New System.Drawing.Point(126, 54)
        Me.TxtSelectedSettings.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSelectedSettings.Name = "TxtSelectedSettings"
        Me.TxtSelectedSettings.SetToolTip = Nothing
        Me.TxtSelectedSettings.Size = New System.Drawing.Size(287, 23)
        Me.TxtSelectedSettings.Sorted = True
        Me.TxtSelectedSettings.SpecialCharList = "&-/@"
        Me.TxtSelectedSettings.TabIndex = 14
        Me.TxtSelectedSettings.UseFunctionKeys = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(29, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Settings For"
        '
        'Timer1
        '
        '
        'Billing_Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 458)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Billing_Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Billing Settings"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtSelectedSettings As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtInvoicePostFix As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtInvoicePreFix As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtInvoicenoStart As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtInvoiceMethod As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtTitle As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtStatus As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TxtAllowDuplicates As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents lblAllowDuplicates As System.Windows.Forms.Label
    Friend WithEvents TxtPreview As System.Windows.Forms.Label
    Friend WithEvents TxtLocation As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
