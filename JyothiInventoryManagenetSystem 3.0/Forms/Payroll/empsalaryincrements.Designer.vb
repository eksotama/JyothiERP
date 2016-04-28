<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class empsalaryincrements
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(empsalaryincrements))
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.tempid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tempname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tcurrentsalary = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tincrement = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tnewsalary = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ImsButton5 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton4 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton3 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtPer = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtDesignation = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.txtTeamname = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtDepartment = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnSAVE = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnEdit = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnDelete = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnReport = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtVhNo = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToResizeRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TxtList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tempid, Me.tempname, Me.tcurrentsalary, Me.tincrement, Me.tnewsalary})
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtList.DefaultCellStyle = DataGridViewCellStyle18
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.Location = New System.Drawing.Point(3, 106)
        Me.TxtList.Name = "TxtList"
        Me.TxtList.RowHeadersWidth = 30
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.TxtList.Size = New System.Drawing.Size(984, 255)
        Me.TxtList.TabIndex = 2
        '
        'tempid
        '
        Me.tempid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tempid.HeaderText = "Emp ID"
        Me.tempid.Name = "tempid"
        Me.tempid.ReadOnly = True
        Me.tempid.Width = 150
        '
        'tempname
        '
        Me.tempname.HeaderText = "Employee Name"
        Me.tempname.Name = "tempname"
        Me.tempname.ReadOnly = True
        '
        'tcurrentsalary
        '
        Me.tcurrentsalary.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle15.Format = "N3"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.tcurrentsalary.DefaultCellStyle = DataGridViewCellStyle15
        Me.tcurrentsalary.HeaderText = "Current Salary"
        Me.tcurrentsalary.Name = "tcurrentsalary"
        Me.tcurrentsalary.ReadOnly = True
        Me.tcurrentsalary.Width = 120
        '
        'tincrement
        '
        Me.tincrement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle16.Format = "N3"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.tincrement.DefaultCellStyle = DataGridViewCellStyle16
        Me.tincrement.HeaderText = "Increment Amount"
        Me.tincrement.Name = "tincrement"
        '
        'tnewsalary
        '
        Me.tnewsalary.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle17.Format = "N3"
        DataGridViewCellStyle17.NullValue = "0"
        Me.tnewsalary.DefaultCellStyle = DataGridViewCellStyle17
        Me.tnewsalary.HeaderText = "New Salary"
        Me.tnewsalary.Name = "tnewsalary"
        Me.tnewsalary.Width = 120
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkOrange
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(990, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "EMPLOYEE SALARY INCREMENTS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ImsButton5)
        Me.Panel1.Controls.Add(Me.ImsButton4)
        Me.Panel1.Controls.Add(Me.ImsButton3)
        Me.Panel1.Controls.Add(Me.ImsButton1)
        Me.Panel1.Controls.Add(Me.TxtPer)
        Me.Panel1.Controls.Add(Me.TxtDesignation)
        Me.Panel1.Controls.Add(Me.txtTeamname)
        Me.Panel1.Controls.Add(Me.TxtDepartment)
        Me.Panel1.Controls.Add(Me.ImSlabel7)
        Me.Panel1.Controls.Add(Me.ImSlabel6)
        Me.Panel1.Controls.Add(Me.ImSlabel8)
        Me.Panel1.Controls.Add(Me.ImSlabel5)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 50)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(990, 53)
        Me.Panel1.TabIndex = 1
        '
        'ImsButton5
        '
        Me.ImsButton5.AllowToolTip = True
        Me.ImsButton5.BackColor = System.Drawing.Color.White
        Me.ImsButton5.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton5.Image = CType(resources.GetObject("ImsButton5.Image"), System.Drawing.Image)
        Me.ImsButton5.Location = New System.Drawing.Point(609, 27)
        Me.ImsButton5.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton5.Name = "ImsButton5"
        Me.ImsButton5.SetToolTip = ""
        Me.ImsButton5.Size = New System.Drawing.Size(55, 23)
        Me.ImsButton5.TabIndex = 5
        Me.ImsButton5.Text = "Load"
        Me.ImsButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton5.UseFunctionKeys = False
        Me.ImsButton5.UseVisualStyleBackColor = False
        '
        'ImsButton4
        '
        Me.ImsButton4.AllowToolTip = True
        Me.ImsButton4.BackColor = System.Drawing.Color.White
        Me.ImsButton4.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton4.Image = CType(resources.GetObject("ImsButton4.Image"), System.Drawing.Image)
        Me.ImsButton4.Location = New System.Drawing.Point(380, 26)
        Me.ImsButton4.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton4.Name = "ImsButton4"
        Me.ImsButton4.SetToolTip = ""
        Me.ImsButton4.Size = New System.Drawing.Size(55, 23)
        Me.ImsButton4.TabIndex = 5
        Me.ImsButton4.Text = "Load"
        Me.ImsButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton4.UseFunctionKeys = False
        Me.ImsButton4.UseVisualStyleBackColor = False
        '
        'ImsButton3
        '
        Me.ImsButton3.AllowToolTip = True
        Me.ImsButton3.BackColor = System.Drawing.Color.White
        Me.ImsButton3.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton3.Image = CType(resources.GetObject("ImsButton3.Image"), System.Drawing.Image)
        Me.ImsButton3.Location = New System.Drawing.Point(180, 26)
        Me.ImsButton3.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton3.Name = "ImsButton3"
        Me.ImsButton3.SetToolTip = ""
        Me.ImsButton3.Size = New System.Drawing.Size(55, 23)
        Me.ImsButton3.TabIndex = 5
        Me.ImsButton3.Text = "Load"
        Me.ImsButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton3.UseFunctionKeys = False
        Me.ImsButton3.UseVisualStyleBackColor = False
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.BackColor = System.Drawing.Color.White
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = CType(resources.GetObject("ImsButton1.Image"), System.Drawing.Image)
        Me.ImsButton1.Location = New System.Drawing.Point(866, 3)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(82, 41)
        Me.ImsButton1.TabIndex = 4
        Me.ImsButton1.Text = "Apply"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = False
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
        Me.TxtPer.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPer.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPer.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtPer.HelpText = Nothing
        Me.TxtPer.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPer.Location = New System.Drawing.Point(801, 24)
        Me.TxtPer.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPer.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtPer.Max = CType(100000000000000, Long)
        Me.TxtPer.MaxLength = 12
        Me.TxtPer.Min = CType(0, Long)
        Me.TxtPer.Name = "TxtPer"
        Me.TxtPer.NextOnEnter = True
        Me.TxtPer.SetToolTip = Nothing
        Me.TxtPer.Size = New System.Drawing.Size(59, 20)
        Me.TxtPer.TabIndex = 3
        Me.TxtPer.Text = "0"
        Me.TxtPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtPer.ToolTip = Nothing
        Me.TxtPer.UseFunctionKeys = False
        Me.TxtPer.UseUpDownArrowKeys = False
        '
        'TxtDesignation
        '
        Me.TxtDesignation.AllowEmpty = True
        Me.TxtDesignation.AllowOnlyListValues = False
        Me.TxtDesignation.AllowToolTip = True
        Me.TxtDesignation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtDesignation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtDesignation.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtDesignation.FormattingEnabled = True
        Me.TxtDesignation.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDesignation.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDesignation.IsAdvanceSearchWindow = False
        Me.TxtDesignation.IsAllowDigits = True
        Me.TxtDesignation.IsAllowSpace = True
        Me.TxtDesignation.IsAllowSplChars = True
        Me.TxtDesignation.IsAllowToolTip = True
        Me.TxtDesignation.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDesignation.Location = New System.Drawing.Point(441, 29)
        Me.TxtDesignation.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDesignation.Name = "TxtDesignation"
        Me.TxtDesignation.SetToolTip = Nothing
        Me.TxtDesignation.Size = New System.Drawing.Size(164, 21)
        Me.TxtDesignation.Sorted = True
        Me.TxtDesignation.SpecialCharList = "&-/@"
        Me.TxtDesignation.TabIndex = 2
        Me.TxtDesignation.UseFunctionKeys = False
        '
        'txtTeamname
        '
        Me.txtTeamname.AllowEmpty = True
        Me.txtTeamname.AllowOnlyListValues = False
        Me.txtTeamname.AllowToolTip = True
        Me.txtTeamname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtTeamname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtTeamname.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.txtTeamname.FormattingEnabled = True
        Me.txtTeamname.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtTeamname.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtTeamname.IsAdvanceSearchWindow = False
        Me.txtTeamname.IsAllowDigits = True
        Me.txtTeamname.IsAllowSpace = True
        Me.txtTeamname.IsAllowSplChars = True
        Me.txtTeamname.IsAllowToolTip = True
        Me.txtTeamname.LFocusBackColor = System.Drawing.Color.White
        Me.txtTeamname.Location = New System.Drawing.Point(241, 29)
        Me.txtTeamname.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtTeamname.Name = "txtTeamname"
        Me.txtTeamname.SetToolTip = Nothing
        Me.txtTeamname.Size = New System.Drawing.Size(141, 21)
        Me.txtTeamname.Sorted = True
        Me.txtTeamname.SpecialCharList = "&-/@"
        Me.txtTeamname.TabIndex = 1
        Me.txtTeamname.UseFunctionKeys = False
        '
        'TxtDepartment
        '
        Me.TxtDepartment.AllowEmpty = True
        Me.TxtDepartment.AllowOnlyListValues = False
        Me.TxtDepartment.AllowToolTip = True
        Me.TxtDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtDepartment.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtDepartment.FormattingEnabled = True
        Me.TxtDepartment.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDepartment.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDepartment.IsAdvanceSearchWindow = False
        Me.TxtDepartment.IsAllowDigits = True
        Me.TxtDepartment.IsAllowSpace = True
        Me.TxtDepartment.IsAllowSplChars = True
        Me.TxtDepartment.IsAllowToolTip = True
        Me.TxtDepartment.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDepartment.Location = New System.Drawing.Point(3, 29)
        Me.TxtDepartment.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDepartment.Name = "TxtDepartment"
        Me.TxtDepartment.SetToolTip = Nothing
        Me.TxtDepartment.Size = New System.Drawing.Size(176, 21)
        Me.TxtDepartment.Sorted = True
        Me.TxtDepartment.SpecialCharList = "&-/@"
        Me.TxtDepartment.TabIndex = 0
        Me.TxtDepartment.UseFunctionKeys = False
        '
        'ImSlabel7
        '
        Me.ImSlabel7.AutoSize = True
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(441, 13)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(74, 13)
        Me.ImSlabel7.TabIndex = 1
        Me.ImSlabel7.Text = "Designation"
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(238, 13)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(38, 13)
        Me.ImSlabel6.TabIndex = 1
        Me.ImSlabel6.Text = "Team"
        '
        'ImSlabel8
        '
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(670, 11)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(125, 39)
        Me.ImSlabel8.TabIndex = 1
        Me.ImSlabel8.Text = "Increment Percentage on Current Basic Salary"
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(3, 17)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(72, 13)
        Me.ImSlabel5.TabIndex = 1
        Me.ImSlabel5.Text = "Department"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(3, 5)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(125, 13)
        Me.ImSlabel1.TabIndex = 1
        Me.ImSlabel1.Text = "Select Employees By"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtList, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(990, 441)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.BtnClose, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnSAVE, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnEdit, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnDelete, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnReport, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton2, 4, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 392)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(990, 49)
        Me.TableLayoutPanel2.TabIndex = 7
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.Navy
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(3, 3)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(158, 43)
        Me.BtnClose.TabIndex = 5
        Me.BtnClose.Text = "CLOSE"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'BtnSAVE
        '
        Me.BtnSAVE.AllowToolTip = True
        Me.BtnSAVE.BackColor = System.Drawing.Color.White
        Me.BtnSAVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSAVE.ForeColor = System.Drawing.Color.Navy
        Me.BtnSAVE.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnSAVE.Image = CType(resources.GetObject("BtnSAVE.Image"), System.Drawing.Image)
        Me.BtnSAVE.Location = New System.Drawing.Point(823, 3)
        Me.BtnSAVE.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnSAVE.Name = "BtnSAVE"
        Me.BtnSAVE.SetToolTip = ""
        Me.BtnSAVE.Size = New System.Drawing.Size(159, 43)
        Me.BtnSAVE.TabIndex = 0
        Me.BtnSAVE.Text = "SAVE"
        Me.BtnSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSAVE.UseFunctionKeys = False
        Me.BtnSAVE.UseVisualStyleBackColor = False
        '
        'BtnEdit
        '
        Me.BtnEdit.AllowToolTip = True
        Me.BtnEdit.BackColor = System.Drawing.Color.White
        Me.BtnEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.ForeColor = System.Drawing.Color.Navy
        Me.BtnEdit.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnEdit.Image = CType(resources.GetObject("BtnEdit.Image"), System.Drawing.Image)
        Me.BtnEdit.Location = New System.Drawing.Point(495, 3)
        Me.BtnEdit.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.SetToolTip = ""
        Me.BtnEdit.Size = New System.Drawing.Size(158, 43)
        Me.BtnEdit.TabIndex = 2
        Me.BtnEdit.Text = "OPEN"
        Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnEdit.UseFunctionKeys = False
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.AllowToolTip = True
        Me.BtnDelete.BackColor = System.Drawing.Color.White
        Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.Navy
        Me.BtnDelete.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
        Me.BtnDelete.Location = New System.Drawing.Point(331, 3)
        Me.BtnDelete.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.SetToolTip = ""
        Me.BtnDelete.Size = New System.Drawing.Size(158, 43)
        Me.BtnDelete.TabIndex = 3
        Me.BtnDelete.Text = "DELETE"
        Me.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDelete.UseFunctionKeys = False
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnReport
        '
        Me.BtnReport.AllowToolTip = True
        Me.BtnReport.BackColor = System.Drawing.Color.White
        Me.BtnReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReport.ForeColor = System.Drawing.Color.Navy
        Me.BtnReport.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnReport.Image = CType(resources.GetObject("BtnReport.Image"), System.Drawing.Image)
        Me.BtnReport.Location = New System.Drawing.Point(167, 3)
        Me.BtnReport.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnReport.Name = "BtnReport"
        Me.BtnReport.SetToolTip = ""
        Me.BtnReport.Size = New System.Drawing.Size(158, 43)
        Me.BtnReport.TabIndex = 4
        Me.BtnReport.Text = "PRINT"
        Me.BtnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnReport.UseFunctionKeys = False
        Me.BtnReport.UseVisualStyleBackColor = False
        '
        'ImsButton2
        '
        Me.ImsButton2.AllowToolTip = True
        Me.ImsButton2.BackColor = System.Drawing.Color.White
        Me.ImsButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton2.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton2.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361186619_document_new
        Me.ImsButton2.Location = New System.Drawing.Point(659, 3)
        Me.ImsButton2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton2.Name = "ImsButton2"
        Me.ImsButton2.SetToolTip = ""
        Me.ImsButton2.Size = New System.Drawing.Size(158, 43)
        Me.ImsButton2.TabIndex = 1
        Me.ImsButton2.Text = "NEW"
        Me.ImsButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton2.UseFunctionKeys = False
        Me.ImsButton2.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtDate)
        Me.Panel2.Controls.Add(Me.TxtVhNo)
        Me.Panel2.Controls.Add(Me.ImSlabel3)
        Me.Panel2.Controls.Add(Me.ImSlabel2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 22)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(990, 28)
        Me.Panel2.TabIndex = 5
        '
        'TxtDate
        '
        Me.TxtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtDate.Location = New System.Drawing.Point(440, 7)
        Me.TxtDate.Name = "TxtDate"
        Me.TxtDate.Size = New System.Drawing.Size(216, 20)
        Me.TxtDate.TabIndex = 1
        '
        'TxtVhNo
        '
        Me.TxtVhNo.AllowToolTip = True
        Me.TxtVhNo.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtVhNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtVhNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtVhNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtVhNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtVhNo.IsAllowDigits = True
        Me.TxtVhNo.IsAllowSpace = True
        Me.TxtVhNo.IsAllowSplChars = True
        Me.TxtVhNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtVhNo.Location = New System.Drawing.Point(92, 5)
        Me.TxtVhNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtVhNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtVhNo.MaxLength = 75
        Me.TxtVhNo.Name = "TxtVhNo"
        Me.TxtVhNo.SetToolTip = Nothing
        Me.TxtVhNo.Size = New System.Drawing.Size(131, 20)
        Me.TxtVhNo.SpecialCharList = "&-/@"
        Me.TxtVhNo.TabIndex = 0
        Me.TxtVhNo.UseFunctionKeys = False
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(325, 10)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(109, 13)
        Me.ImSlabel3.TabIndex = 1
        Me.ImSlabel3.Text = "Date of Increment"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(12, 8)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(47, 13)
        Me.ImSlabel2.TabIndex = 1
        Me.ImSlabel2.Text = "Ref No"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TxtTotal)
        Me.Panel3.Controls.Add(Me.ImSlabel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 364)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(990, 28)
        Me.Panel3.TabIndex = 6
        '
        'TxtTotal
        '
        Me.TxtTotal.AllowToolTip = True
        Me.TxtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotal.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.ForeColor = System.Drawing.Color.Green
        Me.TxtTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtTotal.IsAllowDigits = True
        Me.TxtTotal.IsAllowSpace = True
        Me.TxtTotal.IsAllowSplChars = True
        Me.TxtTotal.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTotal.Location = New System.Drawing.Point(856, 3)
        Me.TxtTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtTotal.MaxLength = 75
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.SetToolTip = Nothing
        Me.TxtTotal.Size = New System.Drawing.Size(131, 22)
        Me.TxtTotal.SpecialCharList = "&-/@"
        Me.TxtTotal.TabIndex = 2
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTotal.UseFunctionKeys = False
        '
        'ImSlabel4
        '
        Me.ImSlabel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(754, 5)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(96, 13)
        Me.ImSlabel4.TabIndex = 1
        Me.ImSlabel4.Text = "Total Increment"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "&Delete"
        '
        'empsalaryincrements
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(990, 441)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "empsalaryincrements"
        Me.Text = "Employee Increments"
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtDesignation As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents txtTeamname As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtDepartment As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtVhNo As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TxtTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnSAVE As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnEdit As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnDelete As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnReport As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtPer As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImsButton2 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents tempid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tempname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tcurrentsalary As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tincrement As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tnewsalary As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImsButton5 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton4 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton3 As JyothiPharmaERPSystem3.IMSButton
End Class
