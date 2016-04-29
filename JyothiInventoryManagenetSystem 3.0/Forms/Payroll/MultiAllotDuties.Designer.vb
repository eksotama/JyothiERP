<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultiAllotDuties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MultiAllotDuties))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TxtEEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtMEnddate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtMStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtEStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtShiftName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtEmployeeName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.BtnSave = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCancel = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.TxtList = New System.Windows.Forms.DataGridView()
        Me.ImSlabel9 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel10 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.FilterBy = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtFilterBy = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtBreak2Text = New System.Windows.Forms.TextBox()
        Me.TxtBreak1Text = New System.Windows.Forms.TextBox()
        Me.txtmealText = New System.Windows.Forms.TextBox()
        Me.TxtBreak2Color = New System.Windows.Forms.Panel()
        Me.TxtBreak1Color = New System.Windows.Forms.Panel()
        Me.TxtMealColor = New System.Windows.Forms.Panel()
        Me.Txtbreak2min = New System.Windows.Forms.NumericUpDown()
        Me.Txtbreak1min = New System.Windows.Forms.NumericUpDown()
        Me.TxtMealMins = New System.Windows.Forms.NumericUpDown()
        Me.TxtTeaBreakTime2 = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtTeaBreakTime1 = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtMealBreakTime = New JyothiPharmaERPSystem3.IMSDate()
        Me.ImSlabel17 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel16 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel11 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel13 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel12 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel14 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel1.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txtbreak2min, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txtbreak1min, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMealMins, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtEEndDate
        '
        Me.TxtEEndDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEEndDate.CustomFormat = "HH:mm"
        Me.TxtEEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEEndDate.Location = New System.Drawing.Point(222, 51)
        Me.TxtEEndDate.Name = "TxtEEndDate"
        Me.TxtEEndDate.ShowUpDown = True
        Me.TxtEEndDate.Size = New System.Drawing.Size(89, 24)
        Me.TxtEEndDate.TabIndex = 3
        Me.TxtEEndDate.Visible = False
        '
        'TxtMEnddate
        '
        Me.TxtMEnddate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMEnddate.CustomFormat = "HH:mm"
        Me.TxtMEnddate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMEnddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtMEnddate.Location = New System.Drawing.Point(222, 21)
        Me.TxtMEnddate.Name = "TxtMEnddate"
        Me.TxtMEnddate.ShowUpDown = True
        Me.TxtMEnddate.Size = New System.Drawing.Size(89, 24)
        Me.TxtMEnddate.TabIndex = 1
        '
        'TxtMStartDate
        '
        Me.TxtMStartDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMStartDate.CustomFormat = "HH:mm"
        Me.TxtMStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtMStartDate.Location = New System.Drawing.Point(116, 21)
        Me.TxtMStartDate.Name = "TxtMStartDate"
        Me.TxtMStartDate.ShowUpDown = True
        Me.TxtMStartDate.Size = New System.Drawing.Size(89, 24)
        Me.TxtMStartDate.TabIndex = 0
        '
        'TxtEStartDate
        '
        Me.TxtEStartDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEStartDate.CustomFormat = "HH:mm"
        Me.TxtEStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEStartDate.Location = New System.Drawing.Point(116, 51)
        Me.TxtEStartDate.Name = "TxtEStartDate"
        Me.TxtEStartDate.ShowUpDown = True
        Me.TxtEStartDate.Size = New System.Drawing.Size(89, 24)
        Me.TxtEStartDate.TabIndex = 2
        Me.TxtEStartDate.Visible = False
        '
        'ImSlabel8
        '
        Me.ImSlabel8.AutoSize = True
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(219, 5)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(58, 13)
        Me.ImSlabel8.TabIndex = 42
        Me.ImSlabel8.Text = "Time Out"
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
        Me.Panel1.Location = New System.Drawing.Point(353, 198)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(387, 97)
        Me.Panel1.TabIndex = 51
        '
        'ImSlabel7
        '
        Me.ImSlabel7.AutoSize = True
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(113, 5)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(49, 13)
        Me.ImSlabel7.TabIndex = 42
        Me.ImSlabel7.Text = "Time In"
        '
        'TxtEndDate
        '
        Me.TxtEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEndDate.Location = New System.Drawing.Point(468, 167)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(200, 20)
        Me.TxtEndDate.TabIndex = 4
        '
        'TxtStartDate
        '
        Me.TxtStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtStartDate.Location = New System.Drawing.Point(468, 131)
        Me.TxtStartDate.Name = "TxtStartDate"
        Me.TxtStartDate.Size = New System.Drawing.Size(200, 20)
        Me.TxtStartDate.TabIndex = 3
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
        Me.TxtShiftName.Location = New System.Drawing.Point(468, 98)
        Me.TxtShiftName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtShiftName.Name = "TxtShiftName"
        Me.TxtShiftName.SetToolTip = Nothing
        Me.TxtShiftName.Size = New System.Drawing.Size(257, 21)
        Me.TxtShiftName.Sorted = True
        Me.TxtShiftName.SpecialCharList = "&-/@"
        Me.TxtShiftName.TabIndex = 2
        Me.TxtShiftName.UseFunctionKeys = False
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
        Me.TxtEmployeeName.Location = New System.Drawing.Point(637, 49)
        Me.TxtEmployeeName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtEmployeeName.Name = "TxtEmployeeName"
        Me.TxtEmployeeName.SetToolTip = Nothing
        Me.TxtEmployeeName.Size = New System.Drawing.Size(124, 21)
        Me.TxtEmployeeName.Sorted = True
        Me.TxtEmployeeName.SpecialCharList = "&-/@"
        Me.TxtEmployeeName.TabIndex = 1
        Me.TxtEmployeeName.UseFunctionKeys = False
        Me.TxtEmployeeName.Visible = False
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(316, 167)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(53, 13)
        Me.ImSlabel4.TabIndex = 43
        Me.ImSlabel4.Text = "Date To"
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(316, 136)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(65, 13)
        Me.ImSlabel3.TabIndex = 44
        Me.ImSlabel3.Text = "Date From"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(316, 106)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(109, 13)
        Me.ImSlabel2.TabIndex = 45
        Me.ImSlabel2.Text = "Select Shift Name"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(605, 33)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(137, 13)
        Me.ImSlabel1.TabIndex = 46
        Me.ImSlabel1.Text = "Select Employee Name"
        Me.ImSlabel1.Visible = False
        '
        'BtnSave
        '
        Me.BtnSave.AllowToolTip = True
        Me.BtnSave.BackColor = System.Drawing.Color.White
        Me.BtnSave.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(673, 503)
        Me.BtnSave.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.SetToolTip = ""
        Me.BtnSave.Size = New System.Drawing.Size(168, 53)
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
        Me.BtnCancel.Location = New System.Drawing.Point(423, 503)
        Me.BtnCancel.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.SetToolTip = ""
        Me.BtnCancel.Size = New System.Drawing.Size(188, 53)
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
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(896, 24)
        Me.ImsHeadingLabel1.TabIndex = 40
        Me.ImsHeadingLabel1.Text = "DUTY SETTINGS"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToResizeRows = False
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TxtList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.Location = New System.Drawing.Point(5, 94)
        Me.TxtList.Name = "TxtList"
        Me.TxtList.ReadOnly = True
        Me.TxtList.RowHeadersWidth = 30
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(283, 450)
        Me.TxtList.TabIndex = 0
        '
        'ImSlabel9
        '
        Me.ImSlabel9.AutoSize = True
        Me.ImSlabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel9.Location = New System.Drawing.Point(2, 78)
        Me.ImSlabel9.Name = "ImSlabel9"
        Me.ImSlabel9.Size = New System.Drawing.Size(143, 13)
        Me.ImSlabel9.TabIndex = 45
        Me.ImSlabel9.Text = "Select Employee Names"
        '
        'ImSlabel10
        '
        Me.ImSlabel10.AutoSize = True
        Me.ImSlabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel10.Location = New System.Drawing.Point(2, 33)
        Me.ImSlabel10.Name = "ImSlabel10"
        Me.ImSlabel10.Size = New System.Drawing.Size(35, 13)
        Me.ImSlabel10.TabIndex = 45
        Me.ImSlabel10.Text = "Filter"
        '
        'FilterBy
        '
        Me.FilterBy.AllowEmpty = True
        Me.FilterBy.AllowOnlyListValues = True
        Me.FilterBy.AllowToolTip = True
        Me.FilterBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.FilterBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.FilterBy.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.FilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FilterBy.FormattingEnabled = True
        Me.FilterBy.GFocusBackColor = System.Drawing.Color.Yellow
        Me.FilterBy.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.FilterBy.IsAdvanceSearchWindow = False
        Me.FilterBy.IsAllowDigits = True
        Me.FilterBy.IsAllowSpace = True
        Me.FilterBy.IsAllowSplChars = True
        Me.FilterBy.IsAllowToolTip = True
        Me.FilterBy.Items.AddRange(New Object() {"Filter By Department", "Filter By Team"})
        Me.FilterBy.LFocusBackColor = System.Drawing.Color.White
        Me.FilterBy.Location = New System.Drawing.Point(5, 49)
        Me.FilterBy.LostFocusFontColor = System.Drawing.Color.Blue
        Me.FilterBy.Name = "FilterBy"
        Me.FilterBy.SetToolTip = Nothing
        Me.FilterBy.Size = New System.Drawing.Size(161, 21)
        Me.FilterBy.Sorted = True
        Me.FilterBy.SpecialCharList = "&-/@"
        Me.FilterBy.TabIndex = 1
        Me.FilterBy.UseFunctionKeys = False
        '
        'TxtFilterBy
        '
        Me.TxtFilterBy.AllowEmpty = True
        Me.TxtFilterBy.AllowOnlyListValues = True
        Me.TxtFilterBy.AllowToolTip = True
        Me.TxtFilterBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtFilterBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtFilterBy.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtFilterBy.FormattingEnabled = True
        Me.TxtFilterBy.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtFilterBy.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtFilterBy.IsAdvanceSearchWindow = False
        Me.TxtFilterBy.IsAllowDigits = True
        Me.TxtFilterBy.IsAllowSpace = True
        Me.TxtFilterBy.IsAllowSplChars = True
        Me.TxtFilterBy.IsAllowToolTip = True
        Me.TxtFilterBy.LFocusBackColor = System.Drawing.Color.White
        Me.TxtFilterBy.Location = New System.Drawing.Point(172, 49)
        Me.TxtFilterBy.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtFilterBy.Name = "TxtFilterBy"
        Me.TxtFilterBy.SetToolTip = Nothing
        Me.TxtFilterBy.Size = New System.Drawing.Size(233, 21)
        Me.TxtFilterBy.Sorted = True
        Me.TxtFilterBy.SpecialCharList = "&-/@"
        Me.TxtFilterBy.TabIndex = 1
        Me.TxtFilterBy.UseFunctionKeys = False
        '
        'TxtBreak2Text
        '
        Me.TxtBreak2Text.Location = New System.Drawing.Point(704, 422)
        Me.TxtBreak2Text.MaxLength = 40
        Me.TxtBreak2Text.Name = "TxtBreak2Text"
        Me.TxtBreak2Text.Size = New System.Drawing.Size(162, 20)
        Me.TxtBreak2Text.TabIndex = 69
        Me.TxtBreak2Text.Text = "TEA BREAK"
        '
        'TxtBreak1Text
        '
        Me.TxtBreak1Text.Location = New System.Drawing.Point(704, 385)
        Me.TxtBreak1Text.MaxLength = 40
        Me.TxtBreak1Text.Name = "TxtBreak1Text"
        Me.TxtBreak1Text.Size = New System.Drawing.Size(162, 20)
        Me.TxtBreak1Text.TabIndex = 70
        Me.TxtBreak1Text.Text = "TEA BREAK"
        '
        'txtmealText
        '
        Me.txtmealText.Location = New System.Drawing.Point(704, 350)
        Me.txtmealText.MaxLength = 40
        Me.txtmealText.Name = "txtmealText"
        Me.txtmealText.Size = New System.Drawing.Size(162, 20)
        Me.txtmealText.TabIndex = 71
        Me.txtmealText.Text = "MEAL BREAK"
        '
        'TxtBreak2Color
        '
        Me.TxtBreak2Color.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtBreak2Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtBreak2Color.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TxtBreak2Color.Location = New System.Drawing.Point(645, 422)
        Me.TxtBreak2Color.Name = "TxtBreak2Color"
        Me.TxtBreak2Color.Size = New System.Drawing.Size(36, 20)
        Me.TxtBreak2Color.TabIndex = 66
        '
        'TxtBreak1Color
        '
        Me.TxtBreak1Color.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtBreak1Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtBreak1Color.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TxtBreak1Color.Location = New System.Drawing.Point(645, 385)
        Me.TxtBreak1Color.Name = "TxtBreak1Color"
        Me.TxtBreak1Color.Size = New System.Drawing.Size(36, 20)
        Me.TxtBreak1Color.TabIndex = 67
        '
        'TxtMealColor
        '
        Me.TxtMealColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtMealColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtMealColor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TxtMealColor.Location = New System.Drawing.Point(645, 350)
        Me.TxtMealColor.Name = "TxtMealColor"
        Me.TxtMealColor.Size = New System.Drawing.Size(36, 20)
        Me.TxtMealColor.TabIndex = 68
        '
        'Txtbreak2min
        '
        Me.Txtbreak2min.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Txtbreak2min.Location = New System.Drawing.Point(552, 422)
        Me.Txtbreak2min.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Txtbreak2min.Name = "Txtbreak2min"
        Me.Txtbreak2min.Size = New System.Drawing.Size(53, 20)
        Me.Txtbreak2min.TabIndex = 63
        '
        'Txtbreak1min
        '
        Me.Txtbreak1min.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Txtbreak1min.Location = New System.Drawing.Point(552, 385)
        Me.Txtbreak1min.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Txtbreak1min.Name = "Txtbreak1min"
        Me.Txtbreak1min.Size = New System.Drawing.Size(53, 20)
        Me.Txtbreak1min.TabIndex = 64
        '
        'TxtMealMins
        '
        Me.TxtMealMins.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtMealMins.Location = New System.Drawing.Point(552, 350)
        Me.TxtMealMins.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.TxtMealMins.Name = "TxtMealMins"
        Me.TxtMealMins.Size = New System.Drawing.Size(53, 20)
        Me.TxtMealMins.TabIndex = 65
        '
        'TxtTeaBreakTime2
        '
        Me.TxtTeaBreakTime2.CustomFormat = "hh:mm tt"
        Me.TxtTeaBreakTime2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTeaBreakTime2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtTeaBreakTime2.Location = New System.Drawing.Point(447, 422)
        Me.TxtTeaBreakTime2.Name = "TxtTeaBreakTime2"
        Me.TxtTeaBreakTime2.ShowUpDown = True
        Me.TxtTeaBreakTime2.Size = New System.Drawing.Size(94, 21)
        Me.TxtTeaBreakTime2.TabIndex = 62
        Me.TxtTeaBreakTime2.Value = New Date(2014, 5, 12, 9, 0, 0, 0)
        '
        'TxtTeaBreakTime1
        '
        Me.TxtTeaBreakTime1.CustomFormat = "hh:mm tt"
        Me.TxtTeaBreakTime1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTeaBreakTime1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtTeaBreakTime1.Location = New System.Drawing.Point(447, 385)
        Me.TxtTeaBreakTime1.Name = "TxtTeaBreakTime1"
        Me.TxtTeaBreakTime1.ShowUpDown = True
        Me.TxtTeaBreakTime1.Size = New System.Drawing.Size(94, 21)
        Me.TxtTeaBreakTime1.TabIndex = 60
        Me.TxtTeaBreakTime1.Value = New Date(2014, 5, 12, 9, 0, 0, 0)
        '
        'TxtMealBreakTime
        '
        Me.TxtMealBreakTime.CustomFormat = "hh:mm tt"
        Me.TxtMealBreakTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMealBreakTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtMealBreakTime.Location = New System.Drawing.Point(447, 350)
        Me.TxtMealBreakTime.Name = "TxtMealBreakTime"
        Me.TxtMealBreakTime.ShowUpDown = True
        Me.TxtMealBreakTime.Size = New System.Drawing.Size(94, 21)
        Me.TxtMealBreakTime.TabIndex = 61
        Me.TxtMealBreakTime.Value = New Date(2014, 5, 12, 9, 0, 0, 0)
        '
        'ImSlabel17
        '
        Me.ImSlabel17.AutoSize = True
        Me.ImSlabel17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel17.ForeColor = System.Drawing.Color.Blue
        Me.ImSlabel17.Location = New System.Drawing.Point(444, 309)
        Me.ImSlabel17.Name = "ImSlabel17"
        Me.ImSlabel17.Size = New System.Drawing.Size(73, 15)
        Me.ImSlabel17.TabIndex = 54
        Me.ImSlabel17.Text = "Start Time"
        '
        'ImSlabel16
        '
        Me.ImSlabel16.AutoSize = True
        Me.ImSlabel16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel16.ForeColor = System.Drawing.Color.Blue
        Me.ImSlabel16.Location = New System.Drawing.Point(318, 309)
        Me.ImSlabel16.Name = "ImSlabel16"
        Me.ImSlabel16.Size = New System.Drawing.Size(87, 15)
        Me.ImSlabel16.TabIndex = 55
        Me.ImSlabel16.Text = "Break Times"
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(318, 426)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(108, 13)
        Me.ImSlabel5.TabIndex = 52
        Me.ImSlabel5.Text = "Tea Break Time 2"
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(318, 389)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(108, 13)
        Me.ImSlabel6.TabIndex = 53
        Me.ImSlabel6.Text = "Tea Break Time 1"
        '
        'ImSlabel11
        '
        Me.ImSlabel11.AutoSize = True
        Me.ImSlabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel11.ForeColor = System.Drawing.Color.Blue
        Me.ImSlabel11.Location = New System.Drawing.Point(701, 309)
        Me.ImSlabel11.Name = "ImSlabel11"
        Me.ImSlabel11.Size = New System.Drawing.Size(85, 15)
        Me.ImSlabel11.TabIndex = 58
        Me.ImSlabel11.Text = "Display Text"
        '
        'ImSlabel13
        '
        Me.ImSlabel13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel13.ForeColor = System.Drawing.Color.Blue
        Me.ImSlabel13.Location = New System.Drawing.Point(642, 309)
        Me.ImSlabel13.Name = "ImSlabel13"
        Me.ImSlabel13.Size = New System.Drawing.Size(50, 38)
        Me.ImSlabel13.TabIndex = 59
        Me.ImSlabel13.Text = "Color Code"
        '
        'ImSlabel12
        '
        Me.ImSlabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel12.ForeColor = System.Drawing.Color.Blue
        Me.ImSlabel12.Location = New System.Drawing.Point(549, 309)
        Me.ImSlabel12.Name = "ImSlabel12"
        Me.ImSlabel12.Size = New System.Drawing.Size(81, 38)
        Me.ImSlabel12.TabIndex = 56
        Me.ImSlabel12.Text = "Length In Minutes"
        '
        'ImSlabel14
        '
        Me.ImSlabel14.AutoSize = True
        Me.ImSlabel14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel14.Location = New System.Drawing.Point(318, 354)
        Me.ImSlabel14.Name = "ImSlabel14"
        Me.ImSlabel14.Size = New System.Drawing.Size(102, 13)
        Me.ImSlabel14.TabIndex = 57
        Me.ImSlabel14.Text = "Meal Break Time"
        '
        'MultiAllotDuties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(896, 583)
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
        Me.Controls.Add(Me.ImSlabel17)
        Me.Controls.Add(Me.ImSlabel16)
        Me.Controls.Add(Me.ImSlabel5)
        Me.Controls.Add(Me.ImSlabel6)
        Me.Controls.Add(Me.ImSlabel11)
        Me.Controls.Add(Me.ImSlabel13)
        Me.Controls.Add(Me.ImSlabel12)
        Me.Controls.Add(Me.ImSlabel14)
        Me.Controls.Add(Me.TxtList)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxtEndDate)
        Me.Controls.Add(Me.TxtStartDate)
        Me.Controls.Add(Me.TxtShiftName)
        Me.Controls.Add(Me.TxtFilterBy)
        Me.Controls.Add(Me.FilterBy)
        Me.Controls.Add(Me.TxtEmployeeName)
        Me.Controls.Add(Me.ImSlabel4)
        Me.Controls.Add(Me.ImSlabel3)
        Me.Controls.Add(Me.ImSlabel10)
        Me.Controls.Add(Me.ImSlabel9)
        Me.Controls.Add(Me.ImSlabel2)
        Me.Controls.Add(Me.ImSlabel1)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.ImsHeadingLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MultiAllotDuties"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AllotDuties For Employees"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txtbreak2min, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txtbreak1min, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMealMins, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtEEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtMEnddate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtMStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtEStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtShiftName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtEmployeeName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents BtnSave As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCancel As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents TxtList As System.Windows.Forms.DataGridView
    Friend WithEvents ImSlabel9 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel10 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents FilterBy As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtFilterBy As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtBreak2Text As System.Windows.Forms.TextBox
    Friend WithEvents TxtBreak1Text As System.Windows.Forms.TextBox
    Friend WithEvents txtmealText As System.Windows.Forms.TextBox
    Friend WithEvents TxtBreak2Color As System.Windows.Forms.Panel
    Friend WithEvents TxtBreak1Color As System.Windows.Forms.Panel
    Friend WithEvents TxtMealColor As System.Windows.Forms.Panel
    Friend WithEvents Txtbreak2min As System.Windows.Forms.NumericUpDown
    Friend WithEvents Txtbreak1min As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtMealMins As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtTeaBreakTime2 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtTeaBreakTime1 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtMealBreakTime As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents ImSlabel17 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel16 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel11 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel13 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel12 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel14 As JyothiPharmaERPSystem3.IMSlabel

End Class
