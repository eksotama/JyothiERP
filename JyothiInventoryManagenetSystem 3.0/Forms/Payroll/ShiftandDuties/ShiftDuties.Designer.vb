<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShiftDuties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ShiftDuties))
        Me.TxtShiftName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.BtnSave = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCancel = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtTimein = New JyothiPharmaERPSystem3.IMSDate()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtealyinasOT = New System.Windows.Forms.CheckBox()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtEarlyIn = New JyothiPharmaERPSystem3.IMSDate()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtlateoutasOT = New System.Windows.Forms.CheckBox()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.txtearlyout = New JyothiPharmaERPSystem3.IMSDate()
        Me.txtouttime = New JyothiPharmaERPSystem3.IMSDate()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.breaktimefrom = New JyothiPharmaERPSystem3.IMSDate()
        Me.breaktimeto = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtTotalHours = New JyothiPharmaERPSystem3.IMSlabel()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtShiftName
        '
        Me.TxtShiftName.AllowToolTip = True
        Me.TxtShiftName.BackColor = System.Drawing.Color.White
        Me.TxtShiftName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtShiftName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtShiftName.ForeColor = System.Drawing.Color.Blue
        Me.TxtShiftName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtShiftName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtShiftName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtShiftName.IsAllowDigits = True
        Me.TxtShiftName.IsAllowSpace = True
        Me.TxtShiftName.IsAllowSplChars = True
        Me.TxtShiftName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtShiftName.Location = New System.Drawing.Point(154, 44)
        Me.TxtShiftName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtShiftName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtShiftName.MaxLength = 19
        Me.TxtShiftName.Name = "TxtShiftName"
        Me.TxtShiftName.SetToolTip = Nothing
        Me.TxtShiftName.Size = New System.Drawing.Size(239, 20)
        Me.TxtShiftName.SpecialCharList = "&-/@"
        Me.TxtShiftName.TabIndex = 27
        Me.TxtShiftName.UseFunctionKeys = False
        '
        'BtnSave
        '
        Me.BtnSave.AllowToolTip = True
        Me.BtnSave.BackColor = System.Drawing.Color.White
        Me.BtnSave.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(325, 331)
        Me.BtnSave.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.SetToolTip = ""
        Me.BtnSave.Size = New System.Drawing.Size(141, 53)
        Me.BtnSave.TabIndex = 32
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
        Me.BtnCancel.Location = New System.Drawing.Point(64, 331)
        Me.BtnCancel.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.SetToolTip = ""
        Me.BtnCancel.Size = New System.Drawing.Size(141, 53)
        Me.BtnCancel.TabIndex = 33
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseFunctionKeys = False
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'TxtTimein
        '
        Me.TxtTimein.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTimein.CustomFormat = "HH:mm"
        Me.TxtTimein.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTimein.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtTimein.Location = New System.Drawing.Point(372, 19)
        Me.TxtTimein.Name = "TxtTimein"
        Me.TxtTimein.Size = New System.Drawing.Size(89, 24)
        Me.TxtTimein.TabIndex = 28
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
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(545, 24)
        Me.ImsHeadingLabel1.TabIndex = 37
        Me.ImsHeadingLabel1.Text = "DUTY SETTINGS"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(61, 47)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(69, 13)
        Me.ImSlabel5.TabIndex = 36
        Me.ImSlabel5.Text = "Shift Name"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(280, 25)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(49, 13)
        Me.ImSlabel1.TabIndex = 35
        Me.ImSlabel1.Text = "In Time"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtealyinasOT)
        Me.GroupBox1.Controls.Add(Me.ImSlabel3)
        Me.GroupBox1.Controls.Add(Me.ImSlabel1)
        Me.GroupBox1.Controls.Add(Me.TxtEarlyIn)
        Me.GroupBox1.Controls.Add(Me.TxtTimein)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(513, 77)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "In Time"
        '
        'txtealyinasOT
        '
        Me.txtealyinasOT.AutoSize = True
        Me.txtealyinasOT.Checked = True
        Me.txtealyinasOT.CheckState = System.Windows.Forms.CheckState.Checked
        Me.txtealyinasOT.Location = New System.Drawing.Point(117, 49)
        Me.txtealyinasOT.Name = "txtealyinasOT"
        Me.txtealyinasOT.Size = New System.Drawing.Size(126, 17)
        Me.txtealyinasOT.TabIndex = 36
        Me.txtealyinasOT.Text = "Treate Early in as OT"
        Me.txtealyinasOT.UseVisualStyleBackColor = True
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(17, 25)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(63, 13)
        Me.ImSlabel3.TabIndex = 35
        Me.ImSlabel3.Text = "Earliest in"
        '
        'TxtEarlyIn
        '
        Me.TxtEarlyIn.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEarlyIn.CustomFormat = "HH:mm"
        Me.TxtEarlyIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEarlyIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEarlyIn.Location = New System.Drawing.Point(117, 19)
        Me.TxtEarlyIn.Name = "TxtEarlyIn"
        Me.TxtEarlyIn.Size = New System.Drawing.Size(89, 24)
        Me.TxtEarlyIn.TabIndex = 28
        Me.TxtEarlyIn.Value = New Date(2014, 1, 29, 0, 5, 0, 0)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtlateoutasOT)
        Me.GroupBox2.Controls.Add(Me.ImSlabel2)
        Me.GroupBox2.Controls.Add(Me.ImSlabel4)
        Me.GroupBox2.Controls.Add(Me.txtearlyout)
        Me.GroupBox2.Controls.Add(Me.txtouttime)
        Me.GroupBox2.Location = New System.Drawing.Point(20, 154)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(513, 77)
        Me.GroupBox2.TabIndex = 39
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Out Time"
        '
        'txtlateoutasOT
        '
        Me.txtlateoutasOT.AutoSize = True
        Me.txtlateoutasOT.Checked = True
        Me.txtlateoutasOT.CheckState = System.Windows.Forms.CheckState.Checked
        Me.txtlateoutasOT.Location = New System.Drawing.Point(116, 54)
        Me.txtlateoutasOT.Name = "txtlateoutasOT"
        Me.txtlateoutasOT.Size = New System.Drawing.Size(127, 17)
        Me.txtlateoutasOT.TabIndex = 36
        Me.txtlateoutasOT.Text = "Treate late out as OT"
        Me.txtlateoutasOT.UseVisualStyleBackColor = True
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(17, 25)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(88, 13)
        Me.ImSlabel2.TabIndex = 35
        Me.ImSlabel2.Text = "Early Late Out"
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(280, 25)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(58, 13)
        Me.ImSlabel4.TabIndex = 35
        Me.ImSlabel4.Text = "Out Time"
        '
        'txtearlyout
        '
        Me.txtearlyout.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtearlyout.CustomFormat = "HH:mm"
        Me.txtearlyout.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtearlyout.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtearlyout.Location = New System.Drawing.Point(117, 19)
        Me.txtearlyout.Name = "txtearlyout"
        Me.txtearlyout.Size = New System.Drawing.Size(89, 24)
        Me.txtearlyout.TabIndex = 28
        Me.txtearlyout.Value = New Date(2014, 1, 29, 0, 5, 0, 0)
        '
        'txtouttime
        '
        Me.txtouttime.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtouttime.CustomFormat = "HH:mm"
        Me.txtouttime.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtouttime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtouttime.Location = New System.Drawing.Point(372, 16)
        Me.txtouttime.Name = "txtouttime"
        Me.txtouttime.Size = New System.Drawing.Size(89, 24)
        Me.txtouttime.TabIndex = 28
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ImSlabel6)
        Me.GroupBox3.Controls.Add(Me.breaktimefrom)
        Me.GroupBox3.Controls.Add(Me.breaktimeto)
        Me.GroupBox3.Location = New System.Drawing.Point(20, 251)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(513, 64)
        Me.GroupBox3.TabIndex = 39
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Break Time"
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(18, 31)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(75, 13)
        Me.ImSlabel6.TabIndex = 35
        Me.ImSlabel6.Text = "Break Time "
        '
        'breaktimefrom
        '
        Me.breaktimefrom.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.breaktimefrom.CustomFormat = "HH:mm"
        Me.breaktimefrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.breaktimefrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.breaktimefrom.Location = New System.Drawing.Point(118, 25)
        Me.breaktimefrom.Name = "breaktimefrom"
        Me.breaktimefrom.Size = New System.Drawing.Size(89, 24)
        Me.breaktimefrom.TabIndex = 28
        Me.breaktimefrom.Value = New Date(2014, 1, 29, 0, 5, 0, 0)
        '
        'breaktimeto
        '
        Me.breaktimeto.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.breaktimeto.CustomFormat = "HH:mm"
        Me.breaktimeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.breaktimeto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.breaktimeto.Location = New System.Drawing.Point(213, 25)
        Me.breaktimeto.Name = "breaktimeto"
        Me.breaktimeto.Size = New System.Drawing.Size(89, 24)
        Me.breaktimeto.TabIndex = 28
        '
        'TxtTotalHours
        '
        Me.TxtTotalHours.AutoSize = True
        Me.TxtTotalHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalHours.Location = New System.Drawing.Point(280, 235)
        Me.TxtTotalHours.Name = "TxtTotalHours"
        Me.TxtTotalHours.Size = New System.Drawing.Size(69, 13)
        Me.TxtTotalHours.TabIndex = 36
        Me.TxtTotalHours.Text = "Shift Name"
        '
        'ShiftDuties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(545, 396)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TxtShiftName)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.ImsHeadingLabel1)
        Me.Controls.Add(Me.TxtTotalHours)
        Me.Controls.Add(Me.ImSlabel5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ShiftDuties"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ShiftDuties"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtShiftName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents BtnSave As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCancel As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtTimein As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtealyinasOT As System.Windows.Forms.CheckBox
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtEarlyIn As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtlateoutasOT As System.Windows.Forms.CheckBox
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents txtearlyout As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents txtouttime As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents breaktimefrom As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents breaktimeto As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtTotalHours As JyothiPharmaERPSystem3.IMSlabel

End Class
