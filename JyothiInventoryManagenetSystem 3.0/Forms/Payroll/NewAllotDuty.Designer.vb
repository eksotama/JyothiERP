<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewAllotDuty
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewAllotDuty))
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.BtnSave = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCancel = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtEmployeeName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtShiftName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtEEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtMEnddate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtMStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtEStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel9 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtMealBreakTime = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtTeaBreakTime1 = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtTeaBreakTime2 = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtMealMins = New System.Windows.Forms.NumericUpDown()
        Me.ImSlabel10 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Txtbreak1min = New System.Windows.Forms.NumericUpDown()
        Me.Txtbreak2min = New System.Windows.Forms.NumericUpDown()
        Me.ImSlabel13 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtMealColor = New System.Windows.Forms.Panel()
        Me.TxtBreak1Color = New System.Windows.Forms.Panel()
        Me.TxtBreak2Color = New System.Windows.Forms.Panel()
        Me.txtmealText = New System.Windows.Forms.TextBox()
        Me.TxtBreak1Text = New System.Windows.Forms.TextBox()
        Me.TxtBreak2Text = New System.Windows.Forms.TextBox()
        Me.ImSlabel16 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel17 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel11 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel1.SuspendLayout()
        CType(Me.TxtMealMins, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txtbreak1min, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txtbreak2min, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(773, 24)
        Me.ImsHeadingLabel1.TabIndex = 25
        Me.ImsHeadingLabel1.Text = "DUTY SETTINGS"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnSave
        '
        Me.BtnSave.AllowToolTip = True
        Me.BtnSave.BackColor = System.Drawing.Color.White
        Me.BtnSave.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(416, 367)
        Me.BtnSave.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.SetToolTip = ""
        Me.BtnSave.Size = New System.Drawing.Size(141, 53)
        Me.BtnSave.TabIndex = 34
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
        Me.BtnCancel.Location = New System.Drawing.Point(199, 367)
        Me.BtnCancel.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.SetToolTip = ""
        Me.BtnCancel.Size = New System.Drawing.Size(141, 53)
        Me.BtnCancel.TabIndex = 35
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseFunctionKeys = False
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(12, 52)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(137, 13)
        Me.ImSlabel1.TabIndex = 36
        Me.ImSlabel1.Text = "Select Employee Name"
        '
        'TxtEmployeeName
        '
        Me.TxtEmployeeName.AllowEmpty = True
        Me.TxtEmployeeName.AllowOnlyListValues = True
        Me.TxtEmployeeName.AllowToolTip = True
        Me.TxtEmployeeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtEmployeeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtEmployeeName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtEmployeeName.FormattingEnabled = True
        Me.TxtEmployeeName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtEmployeeName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtEmployeeName.IsAdvanceSearchWindow = False
        Me.TxtEmployeeName.IsAllowDigits = True
        Me.TxtEmployeeName.IsAllowSpace = True
        Me.TxtEmployeeName.IsAllowSplChars = True
        Me.TxtEmployeeName.IsAllowToolTip = True
        Me.TxtEmployeeName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtEmployeeName.Location = New System.Drawing.Point(149, 52)
        Me.TxtEmployeeName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtEmployeeName.Name = "TxtEmployeeName"
        Me.TxtEmployeeName.SetToolTip = Nothing
        Me.TxtEmployeeName.Size = New System.Drawing.Size(257, 21)
        Me.TxtEmployeeName.Sorted = True
        Me.TxtEmployeeName.SpecialCharList = "&-/@"
        Me.TxtEmployeeName.TabIndex = 37
        Me.TxtEmployeeName.UseFunctionKeys = False
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(12, 88)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(109, 13)
        Me.ImSlabel2.TabIndex = 36
        Me.ImSlabel2.Text = "Select Shift Name"
        '
        'TxtShiftName
        '
        Me.TxtShiftName.AllowEmpty = True
        Me.TxtShiftName.AllowOnlyListValues = True
        Me.TxtShiftName.AllowToolTip = True
        Me.TxtShiftName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtShiftName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtShiftName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtShiftName.FormattingEnabled = True
        Me.TxtShiftName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtShiftName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtShiftName.IsAdvanceSearchWindow = False
        Me.TxtShiftName.IsAllowDigits = True
        Me.TxtShiftName.IsAllowSpace = True
        Me.TxtShiftName.IsAllowSplChars = True
        Me.TxtShiftName.IsAllowToolTip = True
        Me.TxtShiftName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtShiftName.Location = New System.Drawing.Point(149, 85)
        Me.TxtShiftName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtShiftName.Name = "TxtShiftName"
        Me.TxtShiftName.SetToolTip = Nothing
        Me.TxtShiftName.Size = New System.Drawing.Size(257, 21)
        Me.TxtShiftName.Sorted = True
        Me.TxtShiftName.SpecialCharList = "&-/@"
        Me.TxtShiftName.TabIndex = 37
        Me.TxtShiftName.UseFunctionKeys = False
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(12, 124)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(65, 13)
        Me.ImSlabel3.TabIndex = 36
        Me.ImSlabel3.Text = "Date From"
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(12, 160)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(53, 13)
        Me.ImSlabel4.TabIndex = 36
        Me.ImSlabel4.Text = "Date To"
        '
        'TxtStartDate
        '
        Me.TxtStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtStartDate.Location = New System.Drawing.Point(149, 117)
        Me.TxtStartDate.Name = "TxtStartDate"
        Me.TxtStartDate.Size = New System.Drawing.Size(200, 21)
        Me.TxtStartDate.TabIndex = 38
        '
        'TxtEndDate
        '
        Me.TxtEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEndDate.Location = New System.Drawing.Point(149, 154)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(200, 21)
        Me.TxtEndDate.TabIndex = 38
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtEEndDate)
        Me.Panel1.Controls.Add(Me.TxtMEnddate)
        Me.Panel1.Controls.Add(Me.TxtMStartDate)
        Me.Panel1.Controls.Add(Me.TxtEStartDate)
        Me.Panel1.Controls.Add(Me.ImSlabel8)
        Me.Panel1.Controls.Add(Me.ImSlabel7)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(441, 49)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(304, 97)
        Me.Panel1.TabIndex = 39
        '
        'TxtEEndDate
        '
        Me.TxtEEndDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEEndDate.CustomFormat = "HH:mm"
        Me.TxtEEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEEndDate.Location = New System.Drawing.Point(133, 53)
        Me.TxtEEndDate.Name = "TxtEEndDate"
        Me.TxtEEndDate.ShowUpDown = True
        Me.TxtEEndDate.Size = New System.Drawing.Size(89, 24)
        Me.TxtEEndDate.TabIndex = 43
        Me.TxtEEndDate.Visible = False
        '
        'TxtMEnddate
        '
        Me.TxtMEnddate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMEnddate.CustomFormat = "HH:mm"
        Me.TxtMEnddate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMEnddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtMEnddate.Location = New System.Drawing.Point(133, 23)
        Me.TxtMEnddate.Name = "TxtMEnddate"
        Me.TxtMEnddate.ShowUpDown = True
        Me.TxtMEnddate.Size = New System.Drawing.Size(89, 24)
        Me.TxtMEnddate.TabIndex = 43
        '
        'TxtMStartDate
        '
        Me.TxtMStartDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMStartDate.CustomFormat = "HH:mm"
        Me.TxtMStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtMStartDate.Location = New System.Drawing.Point(27, 23)
        Me.TxtMStartDate.Name = "TxtMStartDate"
        Me.TxtMStartDate.ShowUpDown = True
        Me.TxtMStartDate.Size = New System.Drawing.Size(89, 24)
        Me.TxtMStartDate.TabIndex = 43
        '
        'TxtEStartDate
        '
        Me.TxtEStartDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEStartDate.CustomFormat = "HH:mm"
        Me.TxtEStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEStartDate.Location = New System.Drawing.Point(27, 53)
        Me.TxtEStartDate.Name = "TxtEStartDate"
        Me.TxtEStartDate.ShowUpDown = True
        Me.TxtEStartDate.Size = New System.Drawing.Size(89, 24)
        Me.TxtEStartDate.TabIndex = 44
        Me.TxtEStartDate.Visible = False
        '
        'ImSlabel8
        '
        Me.ImSlabel8.AutoSize = True
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(130, 7)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(58, 13)
        Me.ImSlabel8.TabIndex = 42
        Me.ImSlabel8.Text = "Time Out"
        '
        'ImSlabel7
        '
        Me.ImSlabel7.AutoSize = True
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(24, 7)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(49, 13)
        Me.ImSlabel7.TabIndex = 42
        Me.ImSlabel7.Text = "Time In"
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(12, 238)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(102, 13)
        Me.ImSlabel5.TabIndex = 36
        Me.ImSlabel5.Text = "Meal Break Time"
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(12, 273)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(108, 13)
        Me.ImSlabel6.TabIndex = 36
        Me.ImSlabel6.Text = "Tea Break Time 1"
        '
        'ImSlabel9
        '
        Me.ImSlabel9.AutoSize = True
        Me.ImSlabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel9.Location = New System.Drawing.Point(12, 310)
        Me.ImSlabel9.Name = "ImSlabel9"
        Me.ImSlabel9.Size = New System.Drawing.Size(108, 13)
        Me.ImSlabel9.TabIndex = 36
        Me.ImSlabel9.Text = "Tea Break Time 2"
        '
        'TxtMealBreakTime
        '
        Me.TxtMealBreakTime.CustomFormat = "hh:mm tt"
        Me.TxtMealBreakTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMealBreakTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtMealBreakTime.Location = New System.Drawing.Point(149, 234)
        Me.TxtMealBreakTime.Name = "TxtMealBreakTime"
        Me.TxtMealBreakTime.ShowUpDown = True
        Me.TxtMealBreakTime.Size = New System.Drawing.Size(94, 21)
        Me.TxtMealBreakTime.TabIndex = 40
        Me.TxtMealBreakTime.Value = New Date(2014, 5, 12, 9, 0, 0, 0)
        '
        'TxtTeaBreakTime1
        '
        Me.TxtTeaBreakTime1.CustomFormat = "hh:mm tt"
        Me.TxtTeaBreakTime1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTeaBreakTime1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtTeaBreakTime1.Location = New System.Drawing.Point(149, 269)
        Me.TxtTeaBreakTime1.Name = "TxtTeaBreakTime1"
        Me.TxtTeaBreakTime1.ShowUpDown = True
        Me.TxtTeaBreakTime1.Size = New System.Drawing.Size(94, 21)
        Me.TxtTeaBreakTime1.TabIndex = 40
        Me.TxtTeaBreakTime1.Value = New Date(2014, 5, 12, 9, 0, 0, 0)
        '
        'TxtTeaBreakTime2
        '
        Me.TxtTeaBreakTime2.CustomFormat = "hh:mm tt"
        Me.TxtTeaBreakTime2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTeaBreakTime2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtTeaBreakTime2.Location = New System.Drawing.Point(149, 306)
        Me.TxtTeaBreakTime2.Name = "TxtTeaBreakTime2"
        Me.TxtTeaBreakTime2.ShowUpDown = True
        Me.TxtTeaBreakTime2.Size = New System.Drawing.Size(94, 21)
        Me.TxtTeaBreakTime2.TabIndex = 40
        Me.TxtTeaBreakTime2.Value = New Date(2014, 5, 12, 9, 0, 0, 0)
        '
        'TxtMealMins
        '
        Me.TxtMealMins.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtMealMins.Location = New System.Drawing.Point(277, 234)
        Me.TxtMealMins.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.TxtMealMins.Name = "TxtMealMins"
        Me.TxtMealMins.Size = New System.Drawing.Size(53, 20)
        Me.TxtMealMins.TabIndex = 41
        '
        'ImSlabel10
        '
        Me.ImSlabel10.AutoSize = True
        Me.ImSlabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel10.ForeColor = System.Drawing.Color.Blue
        Me.ImSlabel10.Location = New System.Drawing.Point(274, 203)
        Me.ImSlabel10.Name = "ImSlabel10"
        Me.ImSlabel10.Size = New System.Drawing.Size(122, 15)
        Me.ImSlabel10.TabIndex = 36
        Me.ImSlabel10.Text = "Length In Minutes"
        '
        'Txtbreak1min
        '
        Me.Txtbreak1min.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Txtbreak1min.Location = New System.Drawing.Point(277, 269)
        Me.Txtbreak1min.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Txtbreak1min.Name = "Txtbreak1min"
        Me.Txtbreak1min.Size = New System.Drawing.Size(53, 20)
        Me.Txtbreak1min.TabIndex = 41
        '
        'Txtbreak2min
        '
        Me.Txtbreak2min.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Txtbreak2min.Location = New System.Drawing.Point(277, 306)
        Me.Txtbreak2min.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Txtbreak2min.Name = "Txtbreak2min"
        Me.Txtbreak2min.Size = New System.Drawing.Size(53, 20)
        Me.Txtbreak2min.TabIndex = 41
        '
        'ImSlabel13
        '
        Me.ImSlabel13.AutoSize = True
        Me.ImSlabel13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel13.ForeColor = System.Drawing.Color.Blue
        Me.ImSlabel13.Location = New System.Drawing.Point(406, 203)
        Me.ImSlabel13.Name = "ImSlabel13"
        Me.ImSlabel13.Size = New System.Drawing.Size(78, 15)
        Me.ImSlabel13.TabIndex = 36
        Me.ImSlabel13.Text = "Color Code"
        '
        'TxtMealColor
        '
        Me.TxtMealColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtMealColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtMealColor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TxtMealColor.Location = New System.Drawing.Point(409, 234)
        Me.TxtMealColor.Name = "TxtMealColor"
        Me.TxtMealColor.Size = New System.Drawing.Size(36, 20)
        Me.TxtMealColor.TabIndex = 42
        '
        'TxtBreak1Color
        '
        Me.TxtBreak1Color.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtBreak1Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtBreak1Color.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TxtBreak1Color.Location = New System.Drawing.Point(409, 269)
        Me.TxtBreak1Color.Name = "TxtBreak1Color"
        Me.TxtBreak1Color.Size = New System.Drawing.Size(36, 20)
        Me.TxtBreak1Color.TabIndex = 42
        '
        'TxtBreak2Color
        '
        Me.TxtBreak2Color.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtBreak2Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtBreak2Color.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TxtBreak2Color.Location = New System.Drawing.Point(409, 306)
        Me.TxtBreak2Color.Name = "TxtBreak2Color"
        Me.TxtBreak2Color.Size = New System.Drawing.Size(36, 20)
        Me.TxtBreak2Color.TabIndex = 42
        '
        'txtmealText
        '
        Me.txtmealText.Location = New System.Drawing.Point(526, 234)
        Me.txtmealText.MaxLength = 40
        Me.txtmealText.Name = "txtmealText"
        Me.txtmealText.Size = New System.Drawing.Size(186, 20)
        Me.txtmealText.TabIndex = 43
        Me.txtmealText.Text = "MEAL BREAK"
        '
        'TxtBreak1Text
        '
        Me.TxtBreak1Text.Location = New System.Drawing.Point(526, 269)
        Me.TxtBreak1Text.MaxLength = 40
        Me.TxtBreak1Text.Name = "TxtBreak1Text"
        Me.TxtBreak1Text.Size = New System.Drawing.Size(186, 20)
        Me.TxtBreak1Text.TabIndex = 43
        Me.TxtBreak1Text.Text = "TEA BREAK"
        '
        'TxtBreak2Text
        '
        Me.TxtBreak2Text.Location = New System.Drawing.Point(526, 306)
        Me.TxtBreak2Text.MaxLength = 40
        Me.TxtBreak2Text.Name = "TxtBreak2Text"
        Me.TxtBreak2Text.Size = New System.Drawing.Size(186, 20)
        Me.TxtBreak2Text.TabIndex = 43
        Me.TxtBreak2Text.Text = "TEA BREAK"
        '
        'ImSlabel16
        '
        Me.ImSlabel16.AutoSize = True
        Me.ImSlabel16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel16.ForeColor = System.Drawing.Color.Blue
        Me.ImSlabel16.Location = New System.Drawing.Point(12, 203)
        Me.ImSlabel16.Name = "ImSlabel16"
        Me.ImSlabel16.Size = New System.Drawing.Size(87, 15)
        Me.ImSlabel16.TabIndex = 36
        Me.ImSlabel16.Text = "Break Times"
        '
        'ImSlabel17
        '
        Me.ImSlabel17.AutoSize = True
        Me.ImSlabel17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel17.ForeColor = System.Drawing.Color.Blue
        Me.ImSlabel17.Location = New System.Drawing.Point(146, 203)
        Me.ImSlabel17.Name = "ImSlabel17"
        Me.ImSlabel17.Size = New System.Drawing.Size(73, 15)
        Me.ImSlabel17.TabIndex = 36
        Me.ImSlabel17.Text = "Start Time"
        '
        'ImSlabel11
        '
        Me.ImSlabel11.AutoSize = True
        Me.ImSlabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel11.ForeColor = System.Drawing.Color.Blue
        Me.ImSlabel11.Location = New System.Drawing.Point(523, 203)
        Me.ImSlabel11.Name = "ImSlabel11"
        Me.ImSlabel11.Size = New System.Drawing.Size(85, 15)
        Me.ImSlabel11.TabIndex = 36
        Me.ImSlabel11.Text = "Display Text"
        '
        'NewAllotDuty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(773, 452)
        Me.Controls.Add(Me.TxtBreak2Text)
        Me.Controls.Add(Me.TxtBreak1Text)
        Me.Controls.Add(Me.txtmealText)
        Me.Controls.Add(Me.TxtBreak2Color)
        Me.Controls.Add(Me.TxtBreak1Color)
        Me.Controls.Add(Me.TxtMealColor)
        Me.Controls.Add(Me.Txtbreak2min)
        Me.Controls.Add(Me.Txtbreak1min)
        Me.Controls.Add(Me.TxtMealMins)
        Me.Controls.Add(Me.TxtTeaBreakTime2)
        Me.Controls.Add(Me.TxtTeaBreakTime1)
        Me.Controls.Add(Me.TxtMealBreakTime)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxtEndDate)
        Me.Controls.Add(Me.TxtStartDate)
        Me.Controls.Add(Me.TxtShiftName)
        Me.Controls.Add(Me.TxtEmployeeName)
        Me.Controls.Add(Me.ImSlabel17)
        Me.Controls.Add(Me.ImSlabel16)
        Me.Controls.Add(Me.ImSlabel4)
        Me.Controls.Add(Me.ImSlabel9)
        Me.Controls.Add(Me.ImSlabel6)
        Me.Controls.Add(Me.ImSlabel11)
        Me.Controls.Add(Me.ImSlabel13)
        Me.Controls.Add(Me.ImSlabel10)
        Me.Controls.Add(Me.ImSlabel5)
        Me.Controls.Add(Me.ImSlabel3)
        Me.Controls.Add(Me.ImSlabel2)
        Me.Controls.Add(Me.ImSlabel1)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.ImsHeadingLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewAllotDuty"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Allot Duty"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TxtMealMins, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txtbreak1min, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txtbreak2min, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnSave As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCancel As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtEmployeeName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtShiftName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtEEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtMEnddate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtMStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtEStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel9 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtMealBreakTime As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtTeaBreakTime1 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtTeaBreakTime2 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtMealMins As System.Windows.Forms.NumericUpDown
    Friend WithEvents ImSlabel10 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Txtbreak1min As System.Windows.Forms.NumericUpDown
    Friend WithEvents Txtbreak2min As System.Windows.Forms.NumericUpDown
    Friend WithEvents ImSlabel13 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtMealColor As System.Windows.Forms.Panel
    Friend WithEvents TxtBreak1Color As System.Windows.Forms.Panel
    Friend WithEvents TxtBreak2Color As System.Windows.Forms.Panel
    Friend WithEvents txtmealText As System.Windows.Forms.TextBox
    Friend WithEvents TxtBreak1Text As System.Windows.Forms.TextBox
    Friend WithEvents TxtBreak2Text As System.Windows.Forms.TextBox
    Friend WithEvents ImSlabel16 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel17 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel11 As JyothiPharmaERPSystem3.IMSlabel

End Class
