<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmpGratuityCalculationMethods
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmpGratuityCalculationMethods))
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.TxtMethod = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.BtnDelete = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnAdd = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtStartyear = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtYears = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtValue = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.BtnNewMethod = New JyothiPharmaERPSystem3.IMSButton()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TxtList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.Location = New System.Drawing.Point(383, 107)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.ReadOnly = True
        Me.TxtList.RowHeadersWidth = 30
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.TxtList.Size = New System.Drawing.Size(464, 323)
        Me.TxtList.TabIndex = 4
        '
        'TxtMethod
        '
        Me.TxtMethod.AllowEmpty = False
        Me.TxtMethod.AllowOnlyListValues = True
        Me.TxtMethod.AllowToolTip = True
        Me.TxtMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtMethod.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtMethod.FormattingEnabled = True
        Me.TxtMethod.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtMethod.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtMethod.IsAdvanceSearchWindow = False
        Me.TxtMethod.IsAllowDigits = True
        Me.TxtMethod.IsAllowSpace = True
        Me.TxtMethod.IsAllowSplChars = True
        Me.TxtMethod.IsAllowToolTip = True
        Me.TxtMethod.Items.AddRange(New Object() {"Method 1", "Method 2"})
        Me.TxtMethod.LFocusBackColor = System.Drawing.Color.White
        Me.TxtMethod.Location = New System.Drawing.Point(119, 35)
        Me.TxtMethod.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtMethod.Name = "TxtMethod"
        Me.TxtMethod.SetToolTip = Nothing
        Me.TxtMethod.Size = New System.Drawing.Size(215, 21)
        Me.TxtMethod.Sorted = True
        Me.TxtMethod.SpecialCharList = "&-/@"
        Me.TxtMethod.TabIndex = 2
        Me.TxtMethod.UseFunctionKeys = False
        '
        'ImSlabel7
        '
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(12, 285)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(299, 59)
        Me.ImSlabel7.TabIndex = 19
        Me.ImSlabel7.Text = "Example: For  Gratuity 21 Days for less than 5 years, The Gratuity is calculated " & _
    "on 21/30 for less than 5 years"
        Me.ImSlabel7.Visible = False
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(27, 38)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(89, 13)
        Me.ImSlabel3.TabIndex = 19
        Me.ImSlabel3.Text = "Select Method"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(28, 150)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(91, 26)
        Me.ImSlabel2.TabIndex = 19
        Me.ImSlabel2.Text = "For Years between"
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(380, 85)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(124, 13)
        Me.ImSlabel4.TabIndex = 19
        Me.ImSlabel4.Text = "Existing Calculations"
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(28, 86)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(200, 13)
        Me.ImSlabel5.TabIndex = 19
        Me.ImSlabel5.Text = "Add Gratuity Calculation Methods "
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(28, 114)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(83, 13)
        Me.ImSlabel1.TabIndex = 19
        Me.ImSlabel1.Text = "Gratuity Days"
        '
        'BtnDelete
        '
        Me.BtnDelete.AllowToolTip = True
        Me.BtnDelete.BackColor = System.Drawing.Color.White
        Me.BtnDelete.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
        Me.BtnDelete.Location = New System.Drawing.Point(587, 62)
        Me.BtnDelete.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.SetToolTip = ""
        Me.BtnDelete.Size = New System.Drawing.Size(141, 39)
        Me.BtnDelete.TabIndex = 3
        Me.BtnDelete.Text = "Delete"
        Me.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDelete.UseFunctionKeys = False
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnAdd
        '
        Me.BtnAdd.AllowToolTip = True
        Me.BtnAdd.BackColor = System.Drawing.Color.White
        Me.BtnAdd.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(121, 220)
        Me.BtnAdd.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.SetToolTip = ""
        Me.BtnAdd.Size = New System.Drawing.Size(140, 44)
        Me.BtnAdd.TabIndex = 3
        Me.BtnAdd.Text = "Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseFunctionKeys = False
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.BackColor = System.Drawing.Color.White
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = CType(resources.GetObject("ImsButton1.Image"), System.Drawing.Image)
        Me.ImsButton1.Location = New System.Drawing.Point(357, 445)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(164, 53)
        Me.ImsButton1.TabIndex = 5
        Me.ImsButton1.Text = "Close"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = False
        '
        'TxtStartyear
        '
        Me.TxtStartyear.AllHelpText = True
        Me.TxtStartyear.AllowDecimal = True
        Me.TxtStartyear.AllowFormulas = False
        Me.TxtStartyear.AllowForQty = True
        Me.TxtStartyear.AllowNegative = False
        Me.TxtStartyear.AllowPerSign = False
        Me.TxtStartyear.AllowPlusSign = False
        Me.TxtStartyear.AllowToolTip = True
        Me.TxtStartyear.DecimalPlaces = CType(3, Short)
        Me.TxtStartyear.Enabled = False
        Me.TxtStartyear.ExitOnEscKey = True
        Me.TxtStartyear.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStartyear.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStartyear.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtStartyear.HelpText = Nothing
        Me.TxtStartyear.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStartyear.Location = New System.Drawing.Point(125, 152)
        Me.TxtStartyear.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStartyear.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtStartyear.Max = CType(100, Long)
        Me.TxtStartyear.MaxLength = 6
        Me.TxtStartyear.Min = CType(0, Long)
        Me.TxtStartyear.Name = "TxtStartyear"
        Me.TxtStartyear.NextOnEnter = True
        Me.TxtStartyear.SetToolTip = Nothing
        Me.TxtStartyear.Size = New System.Drawing.Size(53, 20)
        Me.TxtStartyear.TabIndex = 1
        Me.TxtStartyear.Text = "1"
        Me.TxtStartyear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtStartyear.ToolTip = Nothing
        Me.TxtStartyear.UseFunctionKeys = False
        Me.TxtStartyear.UseUpDownArrowKeys = False
        '
        'TxtYears
        '
        Me.TxtYears.AllHelpText = True
        Me.TxtYears.AllowDecimal = True
        Me.TxtYears.AllowFormulas = False
        Me.TxtYears.AllowForQty = True
        Me.TxtYears.AllowNegative = False
        Me.TxtYears.AllowPerSign = False
        Me.TxtYears.AllowPlusSign = False
        Me.TxtYears.AllowToolTip = True
        Me.TxtYears.DecimalPlaces = CType(3, Short)
        Me.TxtYears.ExitOnEscKey = True
        Me.TxtYears.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtYears.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtYears.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtYears.HelpText = Nothing
        Me.TxtYears.LFocusBackColor = System.Drawing.Color.White
        Me.TxtYears.Location = New System.Drawing.Point(184, 152)
        Me.TxtYears.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtYears.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtYears.Max = CType(100, Long)
        Me.TxtYears.MaxLength = 6
        Me.TxtYears.Min = CType(0, Long)
        Me.TxtYears.Name = "TxtYears"
        Me.TxtYears.NextOnEnter = True
        Me.TxtYears.SetToolTip = Nothing
        Me.TxtYears.Size = New System.Drawing.Size(53, 20)
        Me.TxtYears.TabIndex = 1
        Me.TxtYears.Text = "1"
        Me.TxtYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtYears.ToolTip = Nothing
        Me.TxtYears.UseFunctionKeys = False
        Me.TxtYears.UseUpDownArrowKeys = False
        '
        'TxtValue
        '
        Me.TxtValue.AllHelpText = True
        Me.TxtValue.AllowDecimal = True
        Me.TxtValue.AllowFormulas = False
        Me.TxtValue.AllowForQty = True
        Me.TxtValue.AllowNegative = False
        Me.TxtValue.AllowPerSign = False
        Me.TxtValue.AllowPlusSign = False
        Me.TxtValue.AllowToolTip = True
        Me.TxtValue.DecimalPlaces = CType(3, Short)
        Me.TxtValue.ExitOnEscKey = True
        Me.TxtValue.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtValue.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtValue.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtValue.HelpText = Nothing
        Me.TxtValue.LFocusBackColor = System.Drawing.Color.White
        Me.TxtValue.Location = New System.Drawing.Point(126, 111)
        Me.TxtValue.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtValue.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtValue.Max = CType(1000, Long)
        Me.TxtValue.MaxLength = 6
        Me.TxtValue.Min = CType(0, Long)
        Me.TxtValue.Name = "TxtValue"
        Me.TxtValue.NextOnEnter = True
        Me.TxtValue.SetToolTip = Nothing
        Me.TxtValue.Size = New System.Drawing.Size(111, 20)
        Me.TxtValue.TabIndex = 0
        Me.TxtValue.Text = "1"
        Me.TxtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtValue.ToolTip = Nothing
        Me.TxtValue.UseFunctionKeys = False
        Me.TxtValue.UseUpDownArrowKeys = False
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
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(876, 23)
        Me.ImsHeadingLabel1.TabIndex = 11
        Me.ImsHeadingLabel1.Text = "GRATUITY CALCULATION SETTINGS"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnNewMethod
        '
        Me.BtnNewMethod.AllowToolTip = True
        Me.BtnNewMethod.BackColor = System.Drawing.Color.White
        Me.BtnNewMethod.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnNewMethod.Image = CType(resources.GetObject("BtnNewMethod.Image"), System.Drawing.Image)
        Me.BtnNewMethod.Location = New System.Drawing.Point(336, 22)
        Me.BtnNewMethod.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnNewMethod.Name = "BtnNewMethod"
        Me.BtnNewMethod.SetToolTip = ""
        Me.BtnNewMethod.Size = New System.Drawing.Size(86, 44)
        Me.BtnNewMethod.TabIndex = 3
        Me.BtnNewMethod.Text = "Add"
        Me.BtnNewMethod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnNewMethod.UseFunctionKeys = False
        Me.BtnNewMethod.UseVisualStyleBackColor = False
        '
        'EmpGratuityCalculationMethods
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(876, 504)
        Me.Controls.Add(Me.TxtList)
        Me.Controls.Add(Me.TxtMethod)
        Me.Controls.Add(Me.ImSlabel7)
        Me.Controls.Add(Me.ImSlabel3)
        Me.Controls.Add(Me.ImSlabel2)
        Me.Controls.Add(Me.ImSlabel4)
        Me.Controls.Add(Me.ImSlabel5)
        Me.Controls.Add(Me.ImSlabel1)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnNewMethod)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.ImsButton1)
        Me.Controls.Add(Me.TxtStartyear)
        Me.Controls.Add(Me.TxtYears)
        Me.Controls.Add(Me.TxtValue)
        Me.Controls.Add(Me.ImsHeadingLabel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EmpGratuityCalculationMethods"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gratuity Calculation Settings"
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnAdd As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtValue As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtYears As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtMethod As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents BtnDelete As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtStartyear As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents BtnNewMethod As JyothiPharmaERPSystem3.IMSButton

End Class
