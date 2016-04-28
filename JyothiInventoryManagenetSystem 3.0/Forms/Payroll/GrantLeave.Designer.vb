<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GrantLeave
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GrantLeave))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtRemDays = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtForYear = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtLeaveType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtNarration = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtLeaveDays = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtDepartment = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtEmployeeName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtEndDate)
        Me.Panel1.Controls.Add(Me.TxtStartDate)
        Me.Panel1.Controls.Add(Me.TxtRemDays)
        Me.Panel1.Controls.Add(Me.TxtForYear)
        Me.Panel1.Controls.Add(Me.TxtLeaveType)
        Me.Panel1.Controls.Add(Me.TxtNarration)
        Me.Panel1.Controls.Add(Me.TxtLeaveDays)
        Me.Panel1.Controls.Add(Me.TxtDepartment)
        Me.Panel1.Controls.Add(Me.TxtEmployeeName)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(609, 380)
        Me.Panel1.TabIndex = 2
        '
        'TxtEndDate
        '
        Me.TxtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEndDate.Location = New System.Drawing.Point(160, 216)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(217, 20)
        Me.TxtEndDate.TabIndex = 6
        '
        'TxtStartDate
        '
        Me.TxtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtStartDate.Location = New System.Drawing.Point(160, 180)
        Me.TxtStartDate.Name = "TxtStartDate"
        Me.TxtStartDate.Size = New System.Drawing.Size(217, 20)
        Me.TxtStartDate.TabIndex = 5
        '
        'TxtRemDays
        '
        Me.TxtRemDays.AllowToolTip = True
        Me.TxtRemDays.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtRemDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtRemDays.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtRemDays.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtRemDays.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtRemDays.IsAllowDigits = True
        Me.TxtRemDays.IsAllowSpace = True
        Me.TxtRemDays.IsAllowSplChars = True
        Me.TxtRemDays.LFocusBackColor = System.Drawing.Color.White
        Me.TxtRemDays.Location = New System.Drawing.Point(160, 145)
        Me.TxtRemDays.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtRemDays.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtRemDays.MaxLength = 75
        Me.TxtRemDays.Name = "TxtRemDays"
        Me.TxtRemDays.ReadOnly = True
        Me.TxtRemDays.SetToolTip = Nothing
        Me.TxtRemDays.Size = New System.Drawing.Size(226, 20)
        Me.TxtRemDays.SpecialCharList = "&-/@"
        Me.TxtRemDays.TabIndex = 4
        Me.TxtRemDays.UseFunctionKeys = False
        '
        'TxtForYear
        '
        Me.TxtForYear.AllowEmpty = True
        Me.TxtForYear.AllowOnlyListValues = False
        Me.TxtForYear.AllowToolTip = True
        Me.TxtForYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtForYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtForYear.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtForYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtForYear.FormattingEnabled = True
        Me.TxtForYear.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtForYear.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtForYear.IsAdvanceSearchWindow = False
        Me.TxtForYear.IsAllowDigits = True
        Me.TxtForYear.IsAllowSpace = True
        Me.TxtForYear.IsAllowSplChars = True
        Me.TxtForYear.IsAllowToolTip = True
        Me.TxtForYear.LFocusBackColor = System.Drawing.Color.White
        Me.TxtForYear.Location = New System.Drawing.Point(160, 77)
        Me.TxtForYear.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtForYear.Name = "TxtForYear"
        Me.TxtForYear.SetToolTip = Nothing
        Me.TxtForYear.Size = New System.Drawing.Size(226, 21)
        Me.TxtForYear.Sorted = True
        Me.TxtForYear.SpecialCharList = "&-/@"
        Me.TxtForYear.TabIndex = 2
        Me.TxtForYear.UseFunctionKeys = False
        '
        'TxtLeaveType
        '
        Me.TxtLeaveType.AllowEmpty = True
        Me.TxtLeaveType.AllowOnlyListValues = True
        Me.TxtLeaveType.AllowToolTip = True
        Me.TxtLeaveType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtLeaveType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtLeaveType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtLeaveType.FormattingEnabled = True
        Me.TxtLeaveType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLeaveType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLeaveType.IsAdvanceSearchWindow = False
        Me.TxtLeaveType.IsAllowDigits = True
        Me.TxtLeaveType.IsAllowSpace = True
        Me.TxtLeaveType.IsAllowSplChars = True
        Me.TxtLeaveType.IsAllowToolTip = True
        Me.TxtLeaveType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLeaveType.Location = New System.Drawing.Point(160, 112)
        Me.TxtLeaveType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLeaveType.Name = "TxtLeaveType"
        Me.TxtLeaveType.SetToolTip = Nothing
        Me.TxtLeaveType.Size = New System.Drawing.Size(344, 21)
        Me.TxtLeaveType.Sorted = True
        Me.TxtLeaveType.SpecialCharList = "&-/@"
        Me.TxtLeaveType.TabIndex = 3
        Me.TxtLeaveType.UseFunctionKeys = False
        '
        'TxtNarration
        '
        Me.TxtNarration.AllowToolTip = True
        Me.TxtNarration.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtNarration.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtNarration.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNarration.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNarration.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtNarration.IsAllowDigits = True
        Me.TxtNarration.IsAllowSpace = True
        Me.TxtNarration.IsAllowSplChars = True
        Me.TxtNarration.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNarration.Location = New System.Drawing.Point(160, 290)
        Me.TxtNarration.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNarration.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtNarration.MaxLength = 198
        Me.TxtNarration.Multiline = True
        Me.TxtNarration.Name = "TxtNarration"
        Me.TxtNarration.SetToolTip = Nothing
        Me.TxtNarration.Size = New System.Drawing.Size(344, 61)
        Me.TxtNarration.SpecialCharList = "&-/@"
        Me.TxtNarration.TabIndex = 8
        Me.TxtNarration.UseFunctionKeys = False
        '
        'TxtLeaveDays
        '
        Me.TxtLeaveDays.AllowToolTip = True
        Me.TxtLeaveDays.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtLeaveDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtLeaveDays.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLeaveDays.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLeaveDays.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtLeaveDays.IsAllowDigits = True
        Me.TxtLeaveDays.IsAllowSpace = True
        Me.TxtLeaveDays.IsAllowSplChars = True
        Me.TxtLeaveDays.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLeaveDays.Location = New System.Drawing.Point(160, 255)
        Me.TxtLeaveDays.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLeaveDays.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtLeaveDays.MaxLength = 75
        Me.TxtLeaveDays.Name = "TxtLeaveDays"
        Me.TxtLeaveDays.ReadOnly = True
        Me.TxtLeaveDays.SetToolTip = Nothing
        Me.TxtLeaveDays.Size = New System.Drawing.Size(226, 20)
        Me.TxtLeaveDays.SpecialCharList = "&-/@"
        Me.TxtLeaveDays.TabIndex = 7
        Me.TxtLeaveDays.UseFunctionKeys = False
        '
        'TxtDepartment
        '
        Me.TxtDepartment.AllowToolTip = True
        Me.TxtDepartment.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtDepartment.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDepartment.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDepartment.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtDepartment.IsAllowDigits = True
        Me.TxtDepartment.IsAllowSpace = True
        Me.TxtDepartment.IsAllowSplChars = True
        Me.TxtDepartment.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDepartment.Location = New System.Drawing.Point(160, 46)
        Me.TxtDepartment.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDepartment.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtDepartment.MaxLength = 50
        Me.TxtDepartment.Name = "TxtDepartment"
        Me.TxtDepartment.ReadOnly = True
        Me.TxtDepartment.SetToolTip = Nothing
        Me.TxtDepartment.Size = New System.Drawing.Size(226, 20)
        Me.TxtDepartment.SpecialCharList = "&-/@"
        Me.TxtDepartment.TabIndex = 1
        Me.TxtDepartment.UseFunctionKeys = False
        '
        'TxtEmployeeName
        '
        Me.TxtEmployeeName.AllowEmpty = True
        Me.TxtEmployeeName.AllowOnlyListValues = True
        Me.TxtEmployeeName.AllowToolTip = True
        Me.TxtEmployeeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtEmployeeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtEmployeeName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtEmployeeName.FormattingEnabled = True
        Me.TxtEmployeeName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtEmployeeName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtEmployeeName.IsAdvanceSearchWindow = False
        Me.TxtEmployeeName.IsAllowDigits = True
        Me.TxtEmployeeName.IsAllowSpace = True
        Me.TxtEmployeeName.IsAllowSplChars = True
        Me.TxtEmployeeName.IsAllowToolTip = True
        Me.TxtEmployeeName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtEmployeeName.Location = New System.Drawing.Point(160, 15)
        Me.TxtEmployeeName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtEmployeeName.Name = "TxtEmployeeName"
        Me.TxtEmployeeName.SetToolTip = Nothing
        Me.TxtEmployeeName.Size = New System.Drawing.Size(344, 21)
        Me.TxtEmployeeName.Sorted = True
        Me.TxtEmployeeName.SpecialCharList = "&-/@"
        Me.TxtEmployeeName.TabIndex = 0
        Me.TxtEmployeeName.UseFunctionKeys = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 255)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Grant Leave  Days "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 290)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Reasons"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 220)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Date To"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 185)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Date From"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Remaing Leave Days"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(23, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "For The Year"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Department"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Leave Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Employee Name"
        '
        'TxtStatus
        '
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Green
        Me.TxtStatus.Location = New System.Drawing.Point(3, 479)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(609, 25)
        Me.TxtStatus.TabIndex = 4
        Me.TxtStatus.Text = "Status: Ready"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnClose)
        Me.Panel2.Controls.Add(Me.BtnCreate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 416)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(609, 60)
        Me.Panel2.TabIndex = 3
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(87, 7)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(138, 43)
        Me.BtnClose.TabIndex = 1
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
        Me.BtnCreate.Location = New System.Drawing.Point(343, 7)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(150, 43)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "Grant"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtStatus, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(615, 504)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.DarkOrange
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(615, 27)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "GRANT LEAVE FOR EMPLOYEE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GrantLeave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(615, 504)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GrantLeave"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Grant Leave"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtRemDays As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtLeaveType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtNarration As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtLeaveDays As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtDepartment As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtEmployeeName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtStatus As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtForYear As JyothiPharmaERPSystem3.IMSComboBox

End Class
