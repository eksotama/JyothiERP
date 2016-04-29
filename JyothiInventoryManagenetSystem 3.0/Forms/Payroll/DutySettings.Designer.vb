<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DutySettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DutySettings))
        Me.TxtType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.BtnSave = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCancel = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtStartDate4 = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtStartDate3 = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtEStartDate2 = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtStartDate2 = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtEStartDate1 = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtStartDate1 = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtEndDate4 = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtEndDate3 = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtEENDDate2 = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtEndDate2 = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtEENDDate1 = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtEndDate1 = New JyothiPharmaERPSystem3.IMSDate()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.SuspendLayout()
        '
        'TxtType
        '
        Me.TxtType.AllowEmpty = True
        Me.TxtType.AllowOnlyListValues = False
        Me.TxtType.AllowToolTip = True
        Me.TxtType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtType.FormattingEnabled = True
        Me.TxtType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtType.IsAdvanceSearchWindow = False
        Me.TxtType.IsAllowDigits = True
        Me.TxtType.IsAllowSpace = True
        Me.TxtType.IsAllowSplChars = True
        Me.TxtType.IsAllowToolTip = True
        Me.TxtType.Items.AddRange(New Object() {"12 Hours", "6 Hours", "8 Hours", "Single Shift"})
        Me.TxtType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtType.Location = New System.Drawing.Point(183, 36)
        Me.TxtType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtType.Name = "TxtType"
        Me.TxtType.SetToolTip = Nothing
        Me.TxtType.Size = New System.Drawing.Size(267, 21)
        Me.TxtType.Sorted = True
        Me.TxtType.SpecialCharList = "&-/@"
        Me.TxtType.TabIndex = 19
        Me.TxtType.UseFunctionKeys = False
        '
        'BtnSave
        '
        Me.BtnSave.AllowToolTip = True
        Me.BtnSave.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(398, 273)
        Me.BtnSave.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.SetToolTip = ""
        Me.BtnSave.Size = New System.Drawing.Size(141, 53)
        Me.BtnSave.TabIndex = 17
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseFunctionKeys = False
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.AllowToolTip = True
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(42, 273)
        Me.BtnCancel.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.SetToolTip = ""
        Me.BtnCancel.Size = New System.Drawing.Size(141, 53)
        Me.BtnCancel.TabIndex = 18
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseFunctionKeys = False
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'TxtStartDate4
        '
        Me.TxtStartDate4.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate4.CustomFormat = "HH:mm"
        Me.TxtStartDate4.Enabled = False
        Me.TxtStartDate4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate4.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtStartDate4.Location = New System.Drawing.Point(183, 213)
        Me.TxtStartDate4.Name = "TxtStartDate4"
        Me.TxtStartDate4.ShowUpDown = True
        Me.TxtStartDate4.Size = New System.Drawing.Size(89, 24)
        Me.TxtStartDate4.TabIndex = 14
        '
        'TxtStartDate3
        '
        Me.TxtStartDate3.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate3.CustomFormat = "HH:mm"
        Me.TxtStartDate3.Enabled = False
        Me.TxtStartDate3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtStartDate3.Location = New System.Drawing.Point(183, 177)
        Me.TxtStartDate3.Name = "TxtStartDate3"
        Me.TxtStartDate3.ShowUpDown = True
        Me.TxtStartDate3.Size = New System.Drawing.Size(89, 24)
        Me.TxtStartDate3.TabIndex = 14
        '
        'TxtEStartDate2
        '
        Me.TxtEStartDate2.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEStartDate2.CustomFormat = "HH:mm"
        Me.TxtEStartDate2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEStartDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEStartDate2.Location = New System.Drawing.Point(381, 141)
        Me.TxtEStartDate2.Name = "TxtEStartDate2"
        Me.TxtEStartDate2.ShowUpDown = True
        Me.TxtEStartDate2.Size = New System.Drawing.Size(89, 24)
        Me.TxtEStartDate2.TabIndex = 14
        Me.TxtEStartDate2.Visible = False
        '
        'TxtStartDate2
        '
        Me.TxtStartDate2.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate2.CustomFormat = "HH:mm"
        Me.TxtStartDate2.Enabled = False
        Me.TxtStartDate2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtStartDate2.Location = New System.Drawing.Point(183, 141)
        Me.TxtStartDate2.Name = "TxtStartDate2"
        Me.TxtStartDate2.ShowUpDown = True
        Me.TxtStartDate2.Size = New System.Drawing.Size(89, 24)
        Me.TxtStartDate2.TabIndex = 14
        '
        'TxtEStartDate1
        '
        Me.TxtEStartDate1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEStartDate1.CustomFormat = "HH:mm"
        Me.TxtEStartDate1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEStartDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEStartDate1.Location = New System.Drawing.Point(381, 101)
        Me.TxtEStartDate1.Name = "TxtEStartDate1"
        Me.TxtEStartDate1.ShowUpDown = True
        Me.TxtEStartDate1.Size = New System.Drawing.Size(89, 24)
        Me.TxtEStartDate1.TabIndex = 14
        Me.TxtEStartDate1.Visible = False
        '
        'TxtStartDate1
        '
        Me.TxtStartDate1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate1.CustomFormat = "HH:mm"
        Me.TxtStartDate1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtStartDate1.Location = New System.Drawing.Point(183, 101)
        Me.TxtStartDate1.Name = "TxtStartDate1"
        Me.TxtStartDate1.ShowUpDown = True
        Me.TxtStartDate1.Size = New System.Drawing.Size(89, 24)
        Me.TxtStartDate1.TabIndex = 14
        '
        'TxtEndDate4
        '
        Me.TxtEndDate4.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate4.CustomFormat = "HH:mm"
        Me.TxtEndDate4.Enabled = False
        Me.TxtEndDate4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate4.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEndDate4.Location = New System.Drawing.Point(278, 213)
        Me.TxtEndDate4.Name = "TxtEndDate4"
        Me.TxtEndDate4.ShowUpDown = True
        Me.TxtEndDate4.Size = New System.Drawing.Size(89, 24)
        Me.TxtEndDate4.TabIndex = 15
        '
        'TxtEndDate3
        '
        Me.TxtEndDate3.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate3.CustomFormat = "HH:mm"
        Me.TxtEndDate3.Enabled = False
        Me.TxtEndDate3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEndDate3.Location = New System.Drawing.Point(278, 177)
        Me.TxtEndDate3.Name = "TxtEndDate3"
        Me.TxtEndDate3.ShowUpDown = True
        Me.TxtEndDate3.Size = New System.Drawing.Size(89, 24)
        Me.TxtEndDate3.TabIndex = 15
        '
        'TxtEENDDate2
        '
        Me.TxtEENDDate2.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEENDDate2.CustomFormat = "HH:mm"
        Me.TxtEENDDate2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEENDDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEENDDate2.Location = New System.Drawing.Point(476, 141)
        Me.TxtEENDDate2.Name = "TxtEENDDate2"
        Me.TxtEENDDate2.ShowUpDown = True
        Me.TxtEENDDate2.Size = New System.Drawing.Size(89, 24)
        Me.TxtEENDDate2.TabIndex = 15
        Me.TxtEENDDate2.Visible = False
        '
        'TxtEndDate2
        '
        Me.TxtEndDate2.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate2.CustomFormat = "HH:mm"
        Me.TxtEndDate2.Enabled = False
        Me.TxtEndDate2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEndDate2.Location = New System.Drawing.Point(278, 141)
        Me.TxtEndDate2.Name = "TxtEndDate2"
        Me.TxtEndDate2.ShowUpDown = True
        Me.TxtEndDate2.Size = New System.Drawing.Size(89, 24)
        Me.TxtEndDate2.TabIndex = 15
        '
        'TxtEENDDate1
        '
        Me.TxtEENDDate1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEENDDate1.CustomFormat = "HH:mm"
        Me.TxtEENDDate1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEENDDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEENDDate1.Location = New System.Drawing.Point(476, 101)
        Me.TxtEENDDate1.Name = "TxtEENDDate1"
        Me.TxtEENDDate1.ShowUpDown = True
        Me.TxtEENDDate1.Size = New System.Drawing.Size(89, 24)
        Me.TxtEENDDate1.TabIndex = 15
        Me.TxtEENDDate1.Visible = False
        '
        'TxtEndDate1
        '
        Me.TxtEndDate1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate1.CustomFormat = "HH:mm"
        Me.TxtEndDate1.Enabled = False
        Me.TxtEndDate1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEndDate1.Location = New System.Drawing.Point(278, 101)
        Me.TxtEndDate1.Name = "TxtEndDate1"
        Me.TxtEndDate1.ShowUpDown = True
        Me.TxtEndDate1.Size = New System.Drawing.Size(89, 24)
        Me.TxtEndDate1.TabIndex = 15
        '
        'ImsHeadingLabel1
        '
        Me.ImsHeadingLabel1.BackColor = System.Drawing.Color.Olive
        Me.ImsHeadingLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ImsHeadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsHeadingLabel1.ForeColor = System.Drawing.Color.White
        Me.ImsHeadingLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ImsHeadingLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsHeadingLabel1.Name = "ImsHeadingLabel1"
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(577, 24)
        Me.ImsHeadingLabel1.TabIndex = 11
        Me.ImsHeadingLabel1.Text = "DUTY SETTINGS"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(52, 219)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(73, 13)
        Me.ImSlabel4.TabIndex = 10
        Me.ImSlabel4.Text = "Fourth Shift"
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(52, 183)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(66, 13)
        Me.ImSlabel3.TabIndex = 10
        Me.ImSlabel3.Text = "Third Shift"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(52, 147)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(80, 13)
        Me.ImSlabel2.TabIndex = 10
        Me.ImSlabel2.Text = "Second Shift"
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(74, 39)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(99, 13)
        Me.ImSlabel5.TabIndex = 10
        Me.ImSlabel5.Text = "Auto Setting For"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(52, 107)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(61, 13)
        Me.ImSlabel1.TabIndex = 10
        Me.ImSlabel1.Text = "First Shift"
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(52, 72)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(107, 13)
        Me.ImSlabel6.TabIndex = 10
        Me.ImSlabel6.Text = "Note: 24H Format"
        '
        'DutySettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 350)
        Me.Controls.Add(Me.TxtType)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.TxtStartDate4)
        Me.Controls.Add(Me.TxtStartDate3)
        Me.Controls.Add(Me.TxtEStartDate2)
        Me.Controls.Add(Me.TxtStartDate2)
        Me.Controls.Add(Me.TxtEStartDate1)
        Me.Controls.Add(Me.TxtStartDate1)
        Me.Controls.Add(Me.TxtEndDate4)
        Me.Controls.Add(Me.TxtEndDate3)
        Me.Controls.Add(Me.TxtEENDDate2)
        Me.Controls.Add(Me.TxtEndDate2)
        Me.Controls.Add(Me.TxtEENDDate1)
        Me.Controls.Add(Me.TxtEndDate1)
        Me.Controls.Add(Me.ImsHeadingLabel1)
        Me.Controls.Add(Me.ImSlabel6)
        Me.Controls.Add(Me.ImSlabel4)
        Me.Controls.Add(Me.ImSlabel3)
        Me.Controls.Add(Me.ImSlabel2)
        Me.Controls.Add(Me.ImSlabel5)
        Me.Controls.Add(Me.ImSlabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DutySettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Duty Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnSave As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCancel As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtStartDate1 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtEndDate1 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtEndDate2 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtStartDate2 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtEndDate3 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtStartDate3 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtEndDate4 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtStartDate4 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtEENDDate1 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtEENDDate2 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtEStartDate1 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtEStartDate2 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel

End Class
