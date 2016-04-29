<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DiscountInvoiceWise
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DiscountInvoiceWise))
        Me.TxtValueType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtDateTo = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtDateFrom = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtPer = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtDisName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.SuspendLayout()
        '
        'TxtValueType
        '
        Me.TxtValueType.AllowEmpty = True
        Me.TxtValueType.AllowOnlyListValues = False
        Me.TxtValueType.AllowToolTip = True
        Me.TxtValueType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtValueType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtValueType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtValueType.FormattingEnabled = True
        Me.TxtValueType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtValueType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtValueType.IsAdvanceSearchWindow = False
        Me.TxtValueType.IsAllowDigits = True
        Me.TxtValueType.IsAllowSpace = True
        Me.TxtValueType.IsAllowSplChars = True
        Me.TxtValueType.IsAllowToolTip = True
        Me.TxtValueType.Items.AddRange(New Object() {"PERCENTAGE", "VALUE"})
        Me.TxtValueType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtValueType.Location = New System.Drawing.Point(237, 63)
        Me.TxtValueType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtValueType.Name = "TxtValueType"
        Me.TxtValueType.SetToolTip = Nothing
        Me.TxtValueType.Size = New System.Drawing.Size(104, 21)
        Me.TxtValueType.Sorted = True
        Me.TxtValueType.SpecialCharList = "&-/@"
        Me.TxtValueType.TabIndex = 12
        Me.TxtValueType.UseFunctionKeys = False
        '
        'TxtDateTo
        '
        Me.TxtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtDateTo.Location = New System.Drawing.Point(137, 121)
        Me.TxtDateTo.Name = "TxtDateTo"
        Me.TxtDateTo.Size = New System.Drawing.Size(144, 20)
        Me.TxtDateTo.TabIndex = 14
        '
        'TxtDateFrom
        '
        Me.TxtDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtDateFrom.Location = New System.Drawing.Point(137, 93)
        Me.TxtDateFrom.Name = "TxtDateFrom"
        Me.TxtDateFrom.Size = New System.Drawing.Size(144, 20)
        Me.TxtDateFrom.TabIndex = 13
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
        Me.TxtPer.DecimalPlaces = CType(6, Short)
        Me.TxtPer.ExitOnEscKey = True
        Me.TxtPer.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPer.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPer.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtPer.HelpText = Nothing
        Me.TxtPer.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPer.Location = New System.Drawing.Point(137, 63)
        Me.TxtPer.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPer.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtPer.Max = CType(50, Long)
        Me.TxtPer.MaxLength = 5
        Me.TxtPer.Min = CType(0, Long)
        Me.TxtPer.Name = "TxtPer"
        Me.TxtPer.NextOnEnter = True
        Me.TxtPer.SetToolTip = Nothing
        Me.TxtPer.Size = New System.Drawing.Size(94, 20)
        Me.TxtPer.TabIndex = 11
        Me.TxtPer.Text = "1"
        Me.TxtPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtPer.ToolTip = Nothing
        Me.TxtPer.UseFunctionKeys = False
        Me.TxtPer.UseUpDownArrowKeys = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Period To"
        '
        'TxtDisName
        '
        Me.TxtDisName.AllowToolTip = True
        Me.TxtDisName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtDisName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtDisName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDisName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDisName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtDisName.IsAllowDigits = True
        Me.TxtDisName.IsAllowSpace = True
        Me.TxtDisName.IsAllowSplChars = True
        Me.TxtDisName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDisName.Location = New System.Drawing.Point(137, 35)
        Me.TxtDisName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDisName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtDisName.MaxLength = 45
        Me.TxtDisName.Name = "TxtDisName"
        Me.TxtDisName.SetToolTip = Nothing
        Me.TxtDisName.Size = New System.Drawing.Size(221, 20)
        Me.TxtDisName.SpecialCharList = "&-/@()_"
        Me.TxtDisName.TabIndex = 6
        Me.TxtDisName.UseFunctionKeys = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Period From"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Discount Name/Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Percentage"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkOrange
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(447, 26)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "CREATE NEW INVOICE WISE DISCOUNT"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(23, 177)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(161, 43)
        Me.BtnClose.TabIndex = 17
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
        Me.BtnCreate.Location = New System.Drawing.Point(251, 177)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(175, 43)
        Me.BtnCreate.TabIndex = 16
        Me.BtnCreate.Text = "&Save"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = False
        '
        'DiscountInvoiceWise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(447, 247)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnCreate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtValueType)
        Me.Controls.Add(Me.TxtDateTo)
        Me.Controls.Add(Me.TxtDateFrom)
        Me.Controls.Add(Me.TxtPer)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtDisName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DiscountInvoiceWise"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = " Invoice wise Discount"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtValueType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtDateTo As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtDateFrom As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtPer As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtDisName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton

End Class
