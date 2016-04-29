<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewPayAddDeductions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewPayAddDeductions))
        Me.BtnSave = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCancel = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.txtperlbl = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtMethod = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtOrderNo = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtPer = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel9 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtLedger = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtPayLedger = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.SuspendLayout()
        '
        'BtnSave
        '
        Me.BtnSave.AllowToolTip = True
        Me.BtnSave.BackColor = System.Drawing.Color.White
        Me.BtnSave.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(265, 332)
        Me.BtnSave.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.SetToolTip = ""
        Me.BtnSave.Size = New System.Drawing.Size(141, 53)
        Me.BtnSave.TabIndex = 5
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseFunctionKeys = False
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnCancel
        '
        Me.BtnCancel.AllowToolTip = True
        Me.BtnCancel.BackColor = System.Drawing.Color.White
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(42, 332)
        Me.BtnCancel.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.SetToolTip = ""
        Me.BtnCancel.Size = New System.Drawing.Size(141, 53)
        Me.BtnCancel.TabIndex = 6
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseFunctionKeys = False
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'ImsHeadingLabel1
        '
        Me.ImsHeadingLabel1.BackColor = System.Drawing.Color.DarkOrange
        Me.ImsHeadingLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ImsHeadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsHeadingLabel1.ForeColor = System.Drawing.Color.White
        Me.ImsHeadingLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ImsHeadingLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsHeadingLabel1.Name = "ImsHeadingLabel1"
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(491, 24)
        Me.ImsHeadingLabel1.TabIndex = 25
        Me.ImsHeadingLabel1.Text = "NEW ALLOWANCES && DEDUCTIONS"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(30, 165)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(131, 13)
        Me.ImSlabel4.TabIndex = 23
        Me.ImSlabel4.Text = "Method of Calculation"
        '
        'txtperlbl
        '
        Me.txtperlbl.AutoSize = True
        Me.txtperlbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtperlbl.Location = New System.Drawing.Point(30, 129)
        Me.txtperlbl.Name = "txtperlbl"
        Me.txtperlbl.Size = New System.Drawing.Size(85, 13)
        Me.txtperlbl.TabIndex = 22
        Me.txtperlbl.Text = "Percentage %"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(30, 93)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(39, 13)
        Me.ImSlabel2.TabIndex = 21
        Me.ImSlabel2.Text = "Name"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(30, 53)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(35, 13)
        Me.ImSlabel1.TabIndex = 20
        Me.ImSlabel1.Text = "Type"
        '
        'TxtName
        '
        Me.TxtName.AllowToolTip = True
        Me.TxtName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtName.IsAllowDigits = True
        Me.TxtName.IsAllowSpace = True
        Me.TxtName.IsAllowSplChars = True
        Me.TxtName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtName.Location = New System.Drawing.Point(184, 90)
        Me.TxtName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtName.MaxLength = 75
        Me.TxtName.Name = "TxtName"
        Me.TxtName.SetToolTip = Nothing
        Me.TxtName.Size = New System.Drawing.Size(222, 20)
        Me.TxtName.SpecialCharList = "-@"
        Me.TxtName.TabIndex = 1
        Me.TxtName.UseFunctionKeys = False
        '
        'TxtType
        '
        Me.TxtType.AllowEmpty = True
        Me.TxtType.AllowOnlyListValues = False
        Me.TxtType.AllowToolTip = True
        Me.TxtType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtType.FormattingEnabled = True
        Me.TxtType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtType.IsAdvanceSearchWindow = False
        Me.TxtType.IsAllowDigits = True
        Me.TxtType.IsAllowSpace = True
        Me.TxtType.IsAllowSplChars = True
        Me.TxtType.IsAllowToolTip = True
        Me.TxtType.Items.AddRange(New Object() {"Allowances", "Deductions"})
        Me.TxtType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtType.Location = New System.Drawing.Point(184, 50)
        Me.TxtType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtType.Name = "TxtType"
        Me.TxtType.SetToolTip = Nothing
        Me.TxtType.Size = New System.Drawing.Size(222, 21)
        Me.TxtType.Sorted = True
        Me.TxtType.SpecialCharList = "&-/@"
        Me.TxtType.TabIndex = 0
        Me.TxtType.UseFunctionKeys = False
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(30, 222)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(58, 13)
        Me.ImSlabel5.TabIndex = 20
        Me.ImSlabel5.Text = "Order No"
        '
        'TxtMethod
        '
        Me.TxtMethod.AllowEmpty = True
        Me.TxtMethod.AllowOnlyListValues = True
        Me.TxtMethod.AllowToolTip = True
        Me.TxtMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtMethod.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMethod.FormattingEnabled = True
        Me.TxtMethod.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtMethod.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtMethod.IsAdvanceSearchWindow = False
        Me.TxtMethod.IsAllowDigits = True
        Me.TxtMethod.IsAllowSpace = True
        Me.TxtMethod.IsAllowSplChars = True
        Me.TxtMethod.IsAllowToolTip = True
        Me.TxtMethod.Items.AddRange(New Object() {"Fixed", "On Basic", "On Gross", "On Total"})
        Me.TxtMethod.LFocusBackColor = System.Drawing.Color.White
        Me.TxtMethod.Location = New System.Drawing.Point(184, 162)
        Me.TxtMethod.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtMethod.Name = "TxtMethod"
        Me.TxtMethod.SetToolTip = Nothing
        Me.TxtMethod.Size = New System.Drawing.Size(222, 21)
        Me.TxtMethod.Sorted = True
        Me.TxtMethod.SpecialCharList = "&-/@"
        Me.TxtMethod.TabIndex = 3
        Me.TxtMethod.UseFunctionKeys = False
        '
        'TxtOrderNo
        '
        Me.TxtOrderNo.AllHelpText = True
        Me.TxtOrderNo.AllowDecimal = False
        Me.TxtOrderNo.AllowFormulas = False
        Me.TxtOrderNo.AllowForQty = True
        Me.TxtOrderNo.AllowNegative = False
        Me.TxtOrderNo.AllowPerSign = False
        Me.TxtOrderNo.AllowPlusSign = False
        Me.TxtOrderNo.AllowToolTip = True
        Me.TxtOrderNo.DecimalPlaces = CType(3, Short)
        Me.TxtOrderNo.ExitOnEscKey = True
        Me.TxtOrderNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOrderNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtOrderNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtOrderNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtOrderNo.HelpText = Nothing
        Me.TxtOrderNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtOrderNo.Location = New System.Drawing.Point(186, 218)
        Me.TxtOrderNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtOrderNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtOrderNo.Max = CType(1000, Long)
        Me.TxtOrderNo.MaxLength = 8
        Me.TxtOrderNo.Min = CType(0, Long)
        Me.TxtOrderNo.Name = "TxtOrderNo"
        Me.TxtOrderNo.NextOnEnter = True
        Me.TxtOrderNo.SetToolTip = Nothing
        Me.TxtOrderNo.Size = New System.Drawing.Size(100, 20)
        Me.TxtOrderNo.TabIndex = 4
        Me.TxtOrderNo.Text = "1"
        Me.TxtOrderNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtOrderNo.ToolTip = Nothing
        Me.TxtOrderNo.UseFunctionKeys = False
        Me.TxtOrderNo.UseUpDownArrowKeys = False
        '
        'TxtPer
        '
        Me.TxtPer.AllHelpText = True
        Me.TxtPer.AllowDecimal = True
        Me.TxtPer.AllowFormulas = False
        Me.TxtPer.AllowForQty = True
        Me.TxtPer.AllowNegative = False
        Me.TxtPer.AllowPerSign = False
        Me.TxtPer.AllowPlusSign = False
        Me.TxtPer.AllowToolTip = True
        Me.TxtPer.DecimalPlaces = CType(3, Short)
        Me.TxtPer.ExitOnEscKey = True
        Me.TxtPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPer.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPer.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPer.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtPer.HelpText = Nothing
        Me.TxtPer.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPer.Location = New System.Drawing.Point(186, 126)
        Me.TxtPer.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPer.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtPer.Max = CType(10000000, Long)
        Me.TxtPer.MaxLength = 10
        Me.TxtPer.Min = CType(0, Long)
        Me.TxtPer.Name = "TxtPer"
        Me.TxtPer.NextOnEnter = True
        Me.TxtPer.SetToolTip = Nothing
        Me.TxtPer.Size = New System.Drawing.Size(100, 20)
        Me.TxtPer.TabIndex = 2
        Me.TxtPer.Text = "0"
        Me.TxtPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtPer.ToolTip = Nothing
        Me.TxtPer.UseFunctionKeys = False
        Me.TxtPer.UseUpDownArrowKeys = False
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(181, 186)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(204, 13)
        Me.ImSlabel6.TabIndex = 20
        Me.ImSlabel6.Text = "Calculate % on Basic and On Total"
        '
        'ImSlabel8
        '
        Me.ImSlabel8.AutoSize = True
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(30, 256)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(106, 13)
        Me.ImSlabel8.TabIndex = 20
        Me.ImSlabel8.Text = "Allocation Ledger"
        '
        'ImSlabel9
        '
        Me.ImSlabel9.AutoSize = True
        Me.ImSlabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel9.Location = New System.Drawing.Point(30, 286)
        Me.ImSlabel9.Name = "ImSlabel9"
        Me.ImSlabel9.Size = New System.Drawing.Size(73, 13)
        Me.ImSlabel9.TabIndex = 20
        Me.ImSlabel9.Text = "Payment By"
        Me.ImSlabel9.Visible = False
        '
        'TxtLedger
        '
        Me.TxtLedger.AllowEmpty = True
        Me.TxtLedger.AllowOnlyListValues = True
        Me.TxtLedger.AllowToolTip = True
        Me.TxtLedger.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtLedger.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtLedger.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtLedger.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLedger.FormattingEnabled = True
        Me.TxtLedger.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLedger.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLedger.IsAdvanceSearchWindow = False
        Me.TxtLedger.IsAllowDigits = True
        Me.TxtLedger.IsAllowSpace = True
        Me.TxtLedger.IsAllowSplChars = True
        Me.TxtLedger.IsAllowToolTip = True
        Me.TxtLedger.Items.AddRange(New Object() {"On Basic", "On Total"})
        Me.TxtLedger.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLedger.Location = New System.Drawing.Point(186, 256)
        Me.TxtLedger.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLedger.Name = "TxtLedger"
        Me.TxtLedger.SetToolTip = Nothing
        Me.TxtLedger.Size = New System.Drawing.Size(222, 21)
        Me.TxtLedger.Sorted = True
        Me.TxtLedger.SpecialCharList = "&-/@"
        Me.TxtLedger.TabIndex = 3
        Me.TxtLedger.UseFunctionKeys = False
        '
        'TxtPayLedger
        '
        Me.TxtPayLedger.AllowEmpty = True
        Me.TxtPayLedger.AllowOnlyListValues = True
        Me.TxtPayLedger.AllowToolTip = True
        Me.TxtPayLedger.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtPayLedger.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtPayLedger.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtPayLedger.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPayLedger.FormattingEnabled = True
        Me.TxtPayLedger.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPayLedger.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPayLedger.IsAdvanceSearchWindow = False
        Me.TxtPayLedger.IsAllowDigits = True
        Me.TxtPayLedger.IsAllowSpace = True
        Me.TxtPayLedger.IsAllowSplChars = True
        Me.TxtPayLedger.IsAllowToolTip = True
        Me.TxtPayLedger.Items.AddRange(New Object() {"On Basic", "On Total"})
        Me.TxtPayLedger.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPayLedger.Location = New System.Drawing.Point(186, 286)
        Me.TxtPayLedger.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPayLedger.Name = "TxtPayLedger"
        Me.TxtPayLedger.SetToolTip = Nothing
        Me.TxtPayLedger.Size = New System.Drawing.Size(222, 21)
        Me.TxtPayLedger.Sorted = True
        Me.TxtPayLedger.SpecialCharList = "&-/@"
        Me.TxtPayLedger.TabIndex = 3
        Me.TxtPayLedger.UseFunctionKeys = False
        Me.TxtPayLedger.Visible = False
        '
        'NewPayAddDeductions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(491, 410)
        Me.Controls.Add(Me.TxtPer)
        Me.Controls.Add(Me.TxtOrderNo)
        Me.Controls.Add(Me.TxtPayLedger)
        Me.Controls.Add(Me.TxtLedger)
        Me.Controls.Add(Me.TxtMethod)
        Me.Controls.Add(Me.TxtType)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.ImsHeadingLabel1)
        Me.Controls.Add(Me.ImSlabel4)
        Me.Controls.Add(Me.txtperlbl)
        Me.Controls.Add(Me.ImSlabel2)
        Me.Controls.Add(Me.ImSlabel6)
        Me.Controls.Add(Me.ImSlabel9)
        Me.Controls.Add(Me.ImSlabel8)
        Me.Controls.Add(Me.ImSlabel5)
        Me.Controls.Add(Me.ImSlabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewPayAddDeductions"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Pay Options"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnSave As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCancel As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents txtperlbl As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtMethod As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtOrderNo As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtPer As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel9 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtLedger As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtPayLedger As JyothiPharmaERPSystem3.IMSComboBox

End Class
