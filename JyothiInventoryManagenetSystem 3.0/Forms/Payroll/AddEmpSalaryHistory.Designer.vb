<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddEmpSalaryHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddEmpSalaryHistory))
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtSalary = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtIncremet = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtEmpName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.BtnCancel = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnSave = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtcurrentSalary = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.SuspendLayout()
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(27, 45)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(97, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "Employee Name"
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
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(474, 23)
        Me.ImsHeadingLabel1.TabIndex = 1
        Me.ImsHeadingLabel1.Text = "EMPLOYEE SALARY HISTORY "
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(27, 80)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(65, 13)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "Date From"
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(27, 115)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(53, 13)
        Me.ImSlabel3.TabIndex = 0
        Me.ImSlabel3.Text = "Date To"
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(27, 215)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(71, 13)
        Me.ImSlabel4.TabIndex = 0
        Me.ImSlabel4.Text = "New Salary"
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(27, 190)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(63, 13)
        Me.ImSlabel5.TabIndex = 0
        Me.ImSlabel5.Text = "Increment"
        Me.ImSlabel5.Visible = False
        '
        'TxtSalary
        '
        Me.TxtSalary.AllHelpText = True
        Me.TxtSalary.AllowDecimal = True
        Me.TxtSalary.AllowFormulas = False
        Me.TxtSalary.AllowForQty = False
        Me.TxtSalary.AllowNegative = True
        Me.TxtSalary.AllowPerSign = False
        Me.TxtSalary.AllowPlusSign = False
        Me.TxtSalary.AllowToolTip = True
        Me.TxtSalary.DecimalPlaces = CType(3, Short)
        Me.TxtSalary.ExitOnEscKey = True
        Me.TxtSalary.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSalary.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSalary.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtSalary.HelpText = Nothing
        Me.TxtSalary.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSalary.Location = New System.Drawing.Point(143, 213)
        Me.TxtSalary.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSalary.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtSalary.Max = CType(100000000000000, Long)
        Me.TxtSalary.MaxLength = 12
        Me.TxtSalary.Min = CType(0, Long)
        Me.TxtSalary.Name = "TxtSalary"
        Me.TxtSalary.NextOnEnter = True
        Me.TxtSalary.SetToolTip = Nothing
        Me.TxtSalary.Size = New System.Drawing.Size(160, 20)
        Me.TxtSalary.TabIndex = 2
        Me.TxtSalary.Text = "0"
        Me.TxtSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtSalary.ToolTip = Nothing
        Me.TxtSalary.UseFunctionKeys = False
        Me.TxtSalary.UseUpDownArrowKeys = True
        '
        'TxtIncremet
        '
        Me.TxtIncremet.AllHelpText = True
        Me.TxtIncremet.AllowDecimal = True
        Me.TxtIncremet.AllowFormulas = False
        Me.TxtIncremet.AllowForQty = False
        Me.TxtIncremet.AllowNegative = True
        Me.TxtIncremet.AllowPerSign = False
        Me.TxtIncremet.AllowPlusSign = False
        Me.TxtIncremet.AllowToolTip = True
        Me.TxtIncremet.DecimalPlaces = CType(3, Short)
        Me.TxtIncremet.Enabled = False
        Me.TxtIncremet.ExitOnEscKey = True
        Me.TxtIncremet.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtIncremet.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtIncremet.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtIncremet.HelpText = Nothing
        Me.TxtIncremet.LFocusBackColor = System.Drawing.Color.White
        Me.TxtIncremet.Location = New System.Drawing.Point(143, 187)
        Me.TxtIncremet.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtIncremet.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtIncremet.Max = CType(100000000000000, Long)
        Me.TxtIncremet.MaxLength = 12
        Me.TxtIncremet.Min = CType(0, Long)
        Me.TxtIncremet.Name = "TxtIncremet"
        Me.TxtIncremet.NextOnEnter = True
        Me.TxtIncremet.SetToolTip = Nothing
        Me.TxtIncremet.Size = New System.Drawing.Size(160, 20)
        Me.TxtIncremet.TabIndex = 2
        Me.TxtIncremet.Text = "0"
        Me.TxtIncremet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtIncremet.ToolTip = Nothing
        Me.TxtIncremet.UseFunctionKeys = False
        Me.TxtIncremet.UseUpDownArrowKeys = True
        Me.TxtIncremet.Visible = False
        '
        'TxtEndDate
        '
        Me.TxtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEndDate.Location = New System.Drawing.Point(143, 115)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(160, 20)
        Me.TxtEndDate.TabIndex = 3
        '
        'TxtStartDate
        '
        Me.TxtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtStartDate.Location = New System.Drawing.Point(143, 80)
        Me.TxtStartDate.Name = "TxtStartDate"
        Me.TxtStartDate.Size = New System.Drawing.Size(160, 20)
        Me.TxtStartDate.TabIndex = 3
        '
        'TxtEmpName
        '
        Me.TxtEmpName.AllowToolTip = True
        Me.TxtEmpName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtEmpName.Enabled = False
        Me.TxtEmpName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtEmpName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtEmpName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtEmpName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtEmpName.IsAllowDigits = True
        Me.TxtEmpName.IsAllowSpace = True
        Me.TxtEmpName.IsAllowSplChars = True
        Me.TxtEmpName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtEmpName.Location = New System.Drawing.Point(143, 45)
        Me.TxtEmpName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtEmpName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtEmpName.MaxLength = 75
        Me.TxtEmpName.Name = "TxtEmpName"
        Me.TxtEmpName.SetToolTip = Nothing
        Me.TxtEmpName.Size = New System.Drawing.Size(307, 20)
        Me.TxtEmpName.SpecialCharList = "&-/@"
        Me.TxtEmpName.TabIndex = 4
        Me.TxtEmpName.UseFunctionKeys = False
        '
        'BtnCancel
        '
        Me.BtnCancel.AllowToolTip = True
        Me.BtnCancel.BackColor = System.Drawing.Color.White
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(51, 262)
        Me.BtnCancel.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.SetToolTip = ""
        Me.BtnCancel.Size = New System.Drawing.Size(141, 53)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseFunctionKeys = False
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.AllowToolTip = True
        Me.BtnSave.BackColor = System.Drawing.Color.White
        Me.BtnSave.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(266, 262)
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
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(27, 155)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(87, 13)
        Me.ImSlabel6.TabIndex = 0
        Me.ImSlabel6.Text = "Current Salary"
        Me.ImSlabel6.Visible = False
        '
        'TxtcurrentSalary
        '
        Me.TxtcurrentSalary.AllHelpText = True
        Me.TxtcurrentSalary.AllowDecimal = True
        Me.TxtcurrentSalary.AllowFormulas = False
        Me.TxtcurrentSalary.AllowForQty = False
        Me.TxtcurrentSalary.AllowNegative = True
        Me.TxtcurrentSalary.AllowPerSign = False
        Me.TxtcurrentSalary.AllowPlusSign = False
        Me.TxtcurrentSalary.AllowToolTip = True
        Me.TxtcurrentSalary.DecimalPlaces = CType(3, Short)
        Me.TxtcurrentSalary.Enabled = False
        Me.TxtcurrentSalary.ExitOnEscKey = True
        Me.TxtcurrentSalary.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtcurrentSalary.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtcurrentSalary.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtcurrentSalary.HelpText = Nothing
        Me.TxtcurrentSalary.LFocusBackColor = System.Drawing.Color.White
        Me.TxtcurrentSalary.Location = New System.Drawing.Point(143, 150)
        Me.TxtcurrentSalary.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtcurrentSalary.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtcurrentSalary.Max = CType(100000000000000, Long)
        Me.TxtcurrentSalary.MaxLength = 12
        Me.TxtcurrentSalary.Min = CType(0, Long)
        Me.TxtcurrentSalary.Name = "TxtcurrentSalary"
        Me.TxtcurrentSalary.NextOnEnter = True
        Me.TxtcurrentSalary.ReadOnly = True
        Me.TxtcurrentSalary.SetToolTip = Nothing
        Me.TxtcurrentSalary.Size = New System.Drawing.Size(160, 20)
        Me.TxtcurrentSalary.TabIndex = 2
        Me.TxtcurrentSalary.Text = "0"
        Me.TxtcurrentSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtcurrentSalary.ToolTip = Nothing
        Me.TxtcurrentSalary.UseFunctionKeys = False
        Me.TxtcurrentSalary.UseUpDownArrowKeys = True
        Me.TxtcurrentSalary.Visible = False
        '
        'AddEmpSalaryHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(474, 327)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.TxtEmpName)
        Me.Controls.Add(Me.TxtStartDate)
        Me.Controls.Add(Me.TxtEndDate)
        Me.Controls.Add(Me.TxtcurrentSalary)
        Me.Controls.Add(Me.TxtIncremet)
        Me.Controls.Add(Me.TxtSalary)
        Me.Controls.Add(Me.ImSlabel6)
        Me.Controls.Add(Me.ImsHeadingLabel1)
        Me.Controls.Add(Me.ImSlabel5)
        Me.Controls.Add(Me.ImSlabel4)
        Me.Controls.Add(Me.ImSlabel3)
        Me.Controls.Add(Me.ImSlabel2)
        Me.Controls.Add(Me.ImSlabel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddEmpSalaryHistory"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Employee Salary History Period"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtSalary As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtIncremet As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtEmpName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents BtnCancel As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnSave As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtcurrentSalary As JyothiPharmaERPSystem3.IMSNumericTextBox

End Class
