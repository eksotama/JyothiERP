<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DoubleShiftDuties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DoubleShiftDuties))
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.txtealyinasOT = New System.Windows.Forms.CheckBox()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtShiftName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.txtearlyout = New JyothiPharmaERPSystem3.IMSDate()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.txt1stOuttime = New JyothiPharmaERPSystem3.IMSDate()
        Me.breaktimefrom = New JyothiPharmaERPSystem3.IMSDate()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.breaktimeto = New JyothiPharmaERPSystem3.IMSDate()
        Me.txtlateoutasOT = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ImSlabel9 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel11 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.txt2ndouttime = New JyothiPharmaERPSystem3.IMSDate()
        Me.BtnSave = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCancel = New JyothiPharmaERPSystem3.IMSButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtEarlyIn = New JyothiPharmaERPSystem3.IMSDate()
        Me.Txt2ndInTime = New JyothiPharmaERPSystem3.IMSDate()
        Me.Txt1stInTime = New JyothiPharmaERPSystem3.IMSDate()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.TxtTotalHours = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(17, 39)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(88, 13)
        Me.ImSlabel2.TabIndex = 35
        Me.ImSlabel2.Text = "Early Late Out"
        '
        'txtealyinasOT
        '
        Me.txtealyinasOT.AutoSize = True
        Me.txtealyinasOT.Checked = True
        Me.txtealyinasOT.CheckState = System.Windows.Forms.CheckState.Checked
        Me.txtealyinasOT.Location = New System.Drawing.Point(117, 62)
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
        Me.ImSlabel3.Location = New System.Drawing.Point(17, 38)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(63, 13)
        Me.ImSlabel3.TabIndex = 35
        Me.ImSlabel3.Text = "Earliest in"
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(268, 39)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(58, 13)
        Me.ImSlabel4.TabIndex = 35
        Me.ImSlabel4.Text = "Out Time"
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
        Me.TxtShiftName.Location = New System.Drawing.Point(154, 32)
        Me.TxtShiftName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtShiftName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtShiftName.MaxLength = 19
        Me.TxtShiftName.Name = "TxtShiftName"
        Me.TxtShiftName.SetToolTip = Nothing
        Me.TxtShiftName.Size = New System.Drawing.Size(239, 20)
        Me.TxtShiftName.SpecialCharList = "&-/@"
        Me.TxtShiftName.TabIndex = 40
        Me.TxtShiftName.UseFunctionKeys = False
        '
        'txtearlyout
        '
        Me.txtearlyout.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtearlyout.CustomFormat = "HH:mm"
        Me.txtearlyout.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtearlyout.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtearlyout.Location = New System.Drawing.Point(117, 33)
        Me.txtearlyout.Name = "txtearlyout"
        Me.txtearlyout.Size = New System.Drawing.Size(89, 24)
        Me.txtearlyout.TabIndex = 28
        Me.txtearlyout.Value = New Date(2014, 1, 29, 0, 5, 0, 0)
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(268, 38)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(49, 13)
        Me.ImSlabel1.TabIndex = 35
        Me.ImSlabel1.Text = "In Time"
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
        'txt1stOuttime
        '
        Me.txt1stOuttime.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt1stOuttime.CustomFormat = "HH:mm"
        Me.txt1stOuttime.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt1stOuttime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txt1stOuttime.Location = New System.Drawing.Point(360, 33)
        Me.txt1stOuttime.Name = "txt1stOuttime"
        Me.txt1stOuttime.Size = New System.Drawing.Size(89, 24)
        Me.txt1stOuttime.TabIndex = 28
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ImSlabel6)
        Me.GroupBox3.Controls.Add(Me.breaktimefrom)
        Me.GroupBox3.Controls.Add(Me.breaktimeto)
        Me.GroupBox3.Location = New System.Drawing.Point(20, 254)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(587, 64)
        Me.GroupBox3.TabIndex = 47
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Break Time"
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
        'txtlateoutasOT
        '
        Me.txtlateoutasOT.AutoSize = True
        Me.txtlateoutasOT.Checked = True
        Me.txtlateoutasOT.CheckState = System.Windows.Forms.CheckState.Checked
        Me.txtlateoutasOT.Location = New System.Drawing.Point(116, 63)
        Me.txtlateoutasOT.Name = "txtlateoutasOT"
        Me.txtlateoutasOT.Size = New System.Drawing.Size(127, 17)
        Me.txtlateoutasOT.TabIndex = 36
        Me.txtlateoutasOT.Text = "Treate late out as OT"
        Me.txtlateoutasOT.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtlateoutasOT)
        Me.GroupBox2.Controls.Add(Me.ImSlabel2)
        Me.GroupBox2.Controls.Add(Me.ImSlabel9)
        Me.GroupBox2.Controls.Add(Me.ImSlabel11)
        Me.GroupBox2.Controls.Add(Me.ImSlabel4)
        Me.GroupBox2.Controls.Add(Me.txtearlyout)
        Me.GroupBox2.Controls.Add(Me.txt2ndouttime)
        Me.GroupBox2.Controls.Add(Me.txt1stOuttime)
        Me.GroupBox2.Location = New System.Drawing.Point(20, 151)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(587, 88)
        Me.GroupBox2.TabIndex = 46
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Out Time"
        '
        'ImSlabel9
        '
        Me.ImSlabel9.AutoSize = True
        Me.ImSlabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel9.Location = New System.Drawing.Point(470, 16)
        Me.ImSlabel9.Name = "ImSlabel9"
        Me.ImSlabel9.Size = New System.Drawing.Size(104, 13)
        Me.ImSlabel9.TabIndex = 35
        Me.ImSlabel9.Text = "Second Shift Out"
        '
        'ImSlabel11
        '
        Me.ImSlabel11.AutoSize = True
        Me.ImSlabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel11.Location = New System.Drawing.Point(357, 17)
        Me.ImSlabel11.Name = "ImSlabel11"
        Me.ImSlabel11.Size = New System.Drawing.Size(85, 13)
        Me.ImSlabel11.TabIndex = 35
        Me.ImSlabel11.Text = "First Shift Out"
        '
        'txt2ndouttime
        '
        Me.txt2ndouttime.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt2ndouttime.CustomFormat = "HH:mm"
        Me.txt2ndouttime.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt2ndouttime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txt2ndouttime.Location = New System.Drawing.Point(473, 33)
        Me.txt2ndouttime.Name = "txt2ndouttime"
        Me.txt2ndouttime.Size = New System.Drawing.Size(89, 24)
        Me.txt2ndouttime.TabIndex = 28
        '
        'BtnSave
        '
        Me.BtnSave.AllowToolTip = True
        Me.BtnSave.BackColor = System.Drawing.Color.White
        Me.BtnSave.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(380, 334)
        Me.BtnSave.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.SetToolTip = ""
        Me.BtnSave.Size = New System.Drawing.Size(141, 53)
        Me.BtnSave.TabIndex = 41
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
        Me.BtnCancel.Location = New System.Drawing.Point(137, 334)
        Me.BtnCancel.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.SetToolTip = ""
        Me.BtnCancel.Size = New System.Drawing.Size(141, 53)
        Me.BtnCancel.TabIndex = 42
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseFunctionKeys = False
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtealyinasOT)
        Me.GroupBox1.Controls.Add(Me.ImSlabel3)
        Me.GroupBox1.Controls.Add(Me.ImSlabel8)
        Me.GroupBox1.Controls.Add(Me.ImSlabel7)
        Me.GroupBox1.Controls.Add(Me.ImSlabel1)
        Me.GroupBox1.Controls.Add(Me.TxtEarlyIn)
        Me.GroupBox1.Controls.Add(Me.Txt2ndInTime)
        Me.GroupBox1.Controls.Add(Me.Txt1stInTime)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(587, 87)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "In Time"
        '
        'ImSlabel8
        '
        Me.ImSlabel8.AutoSize = True
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(470, 16)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(95, 13)
        Me.ImSlabel8.TabIndex = 35
        Me.ImSlabel8.Text = "Second Shift In"
        '
        'ImSlabel7
        '
        Me.ImSlabel7.AutoSize = True
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(357, 16)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(76, 13)
        Me.ImSlabel7.TabIndex = 35
        Me.ImSlabel7.Text = "First Shift In"
        '
        'TxtEarlyIn
        '
        Me.TxtEarlyIn.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEarlyIn.CustomFormat = "HH:mm"
        Me.TxtEarlyIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEarlyIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEarlyIn.Location = New System.Drawing.Point(117, 32)
        Me.TxtEarlyIn.Name = "TxtEarlyIn"
        Me.TxtEarlyIn.Size = New System.Drawing.Size(89, 24)
        Me.TxtEarlyIn.TabIndex = 28
        Me.TxtEarlyIn.Value = New Date(2014, 1, 29, 0, 5, 0, 0)
        '
        'Txt2ndInTime
        '
        Me.Txt2ndInTime.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt2ndInTime.CustomFormat = "HH:mm"
        Me.Txt2ndInTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt2ndInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Txt2ndInTime.Location = New System.Drawing.Point(473, 32)
        Me.Txt2ndInTime.Name = "Txt2ndInTime"
        Me.Txt2ndInTime.Size = New System.Drawing.Size(89, 24)
        Me.Txt2ndInTime.TabIndex = 28
        '
        'Txt1stInTime
        '
        Me.Txt1stInTime.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt1stInTime.CustomFormat = "HH:mm"
        Me.Txt1stInTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt1stInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Txt1stInTime.Location = New System.Drawing.Point(360, 32)
        Me.Txt1stInTime.Name = "Txt1stInTime"
        Me.Txt1stInTime.Size = New System.Drawing.Size(89, 24)
        Me.Txt1stInTime.TabIndex = 28
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
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(651, 24)
        Me.ImsHeadingLabel1.TabIndex = 45
        Me.ImsHeadingLabel1.Text = "DUTY SETTINGS"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TxtTotalHours
        '
        Me.TxtTotalHours.AutoSize = True
        Me.TxtTotalHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalHours.Location = New System.Drawing.Point(280, 242)
        Me.TxtTotalHours.Name = "TxtTotalHours"
        Me.TxtTotalHours.Size = New System.Drawing.Size(69, 13)
        Me.TxtTotalHours.TabIndex = 43
        Me.TxtTotalHours.Text = "Shift Name"
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(61, 35)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(69, 13)
        Me.ImSlabel5.TabIndex = 44
        Me.ImSlabel5.Text = "Shift Name"
        '
        'DoubleShiftDuties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(651, 391)
        Me.Controls.Add(Me.TxtShiftName)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ImsHeadingLabel1)
        Me.Controls.Add(Me.TxtTotalHours)
        Me.Controls.Add(Me.ImSlabel5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DoubleShiftDuties"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DoubleShiftDuties"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents txtealyinasOT As System.Windows.Forms.CheckBox
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtShiftName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents txtearlyout As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents txt1stOuttime As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents breaktimefrom As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents breaktimeto As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents txtlateoutasOT As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnSave As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCancel As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtEarlyIn As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents Txt1stInTime As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents TxtTotalHours As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel9 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel11 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents txt2ndouttime As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Txt2ndInTime As JyothiPharmaERPSystem3.IMSDate

End Class
