<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewAppointment
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
        Me.Button4 = New System.Windows.Forms.Button()
        Me.IsWalkin = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtNotes = New System.Windows.Forms.TextBox()
        Me.TxtEndDate = New System.Windows.Forms.DateTimePicker()
        Me.TxtStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtServiceList = New System.Windows.Forms.DataGridView()
        Me.tsno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbarcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tprice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tmins = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtTotalMins = New System.Windows.Forms.Label()
        Me.ImsButton2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnSave = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtLength = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtEmployeeName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtConfirmby = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtCustomerName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.IsItLock = New System.Windows.Forms.CheckBox()
        CType(Me.TxtServiceList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(485, 24)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 32)
        Me.Button4.TabIndex = 36
        Me.Button4.Text = "New"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'IsWalkin
        '
        Me.IsWalkin.AutoSize = True
        Me.IsWalkin.Location = New System.Drawing.Point(133, 58)
        Me.IsWalkin.Name = "IsWalkin"
        Me.IsWalkin.Size = New System.Drawing.Size(80, 17)
        Me.IsWalkin.TabIndex = 24
        Me.IsWalkin.Text = "Walk in ?"
        Me.IsWalkin.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel1.Location = New System.Drawing.Point(133, 410)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(94, 27)
        Me.Panel1.TabIndex = 32
        '
        'TxtNotes
        '
        Me.TxtNotes.Location = New System.Drawing.Point(133, 362)
        Me.TxtNotes.MaxLength = 250
        Me.TxtNotes.Multiline = True
        Me.TxtNotes.Name = "TxtNotes"
        Me.TxtNotes.Size = New System.Drawing.Size(324, 42)
        Me.TxtNotes.TabIndex = 31
        '
        'TxtEndDate
        '
        Me.TxtEndDate.CustomFormat = "MM/dd/yyyy hh:mm tt"
        Me.TxtEndDate.Enabled = False
        Me.TxtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEndDate.Location = New System.Drawing.Point(326, 267)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(226, 20)
        Me.TxtEndDate.TabIndex = 23
        Me.TxtEndDate.Value = New Date(2014, 11, 4, 0, 0, 0, 0)
        '
        'TxtStartDate
        '
        Me.TxtStartDate.CustomFormat = "MM/dd/yyyy hh:mm tt"
        Me.TxtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtStartDate.Location = New System.Drawing.Point(133, 267)
        Me.TxtStartDate.Name = "TxtStartDate"
        Me.TxtStartDate.Size = New System.Drawing.Size(178, 20)
        Me.TxtStartDate.TabIndex = 27
        Me.TxtStartDate.Value = New Date(2014, 11, 4, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 415)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Color"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 361)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Notes"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 239)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Employee Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 91)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Services"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Customer Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 271)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Start Time"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(223, 299)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "in Mins"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(19, 333)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Confirm By"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 300)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Length"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(699, 20)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "CREATE APPOINTMENT"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtServiceList
        '
        Me.TxtServiceList.AllowUserToAddRows = False
        Me.TxtServiceList.AllowUserToDeleteRows = False
        Me.TxtServiceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtServiceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtServiceList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tsno, Me.tbarcode, Me.tname, Me.tprice, Me.tmins})
        Me.TxtServiceList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtServiceList.Location = New System.Drawing.Point(133, 85)
        Me.TxtServiceList.Name = "TxtServiceList"
        Me.TxtServiceList.RowHeadersVisible = False
        Me.TxtServiceList.Size = New System.Drawing.Size(432, 126)
        Me.TxtServiceList.TabIndex = 38
        '
        'tsno
        '
        Me.tsno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tsno.HeaderText = "SNo"
        Me.tsno.Name = "tsno"
        Me.tsno.Width = 40
        '
        'tbarcode
        '
        Me.tbarcode.HeaderText = "Barcode"
        Me.tbarcode.Name = "tbarcode"
        Me.tbarcode.Visible = False
        '
        'tname
        '
        Me.tname.HeaderText = "Service Name"
        Me.tname.Name = "tname"
        '
        'tprice
        '
        Me.tprice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tprice.HeaderText = "Price"
        Me.tprice.Name = "tprice"
        '
        'tmins
        '
        Me.tmins.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tmins.HeaderText = "Mins"
        Me.tmins.Name = "tmins"
        Me.tmins.Width = 50
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(581, 94)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(106, 32)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "ADD"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(581, 132)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(106, 32)
        Me.Button2.TabIndex = 36
        Me.Button2.Text = "DELETE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(581, 170)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(106, 32)
        Me.Button3.TabIndex = 36
        Me.Button3.Text = "CLEAR ALL"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(411, 214)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Total Mins"
        '
        'TxtTotalMins
        '
        Me.TxtTotalMins.ForeColor = System.Drawing.Color.Blue
        Me.TxtTotalMins.Location = New System.Drawing.Point(499, 214)
        Me.TxtTotalMins.Name = "TxtTotalMins"
        Me.TxtTotalMins.Size = New System.Drawing.Size(66, 13)
        Me.TxtTotalMins.TabIndex = 17
        Me.TxtTotalMins.Text = "00"
        Me.TxtTotalMins.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ImsButton2
        '
        Me.ImsButton2.AllowToolTip = True
        Me.ImsButton2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton2.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.ImsButton2.Location = New System.Drawing.Point(160, 449)
        Me.ImsButton2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton2.Name = "ImsButton2"
        Me.ImsButton2.SetToolTip = ""
        Me.ImsButton2.Size = New System.Drawing.Size(184, 43)
        Me.ImsButton2.TabIndex = 37
        Me.ImsButton2.Text = "Close"
        Me.ImsButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton2.UseFunctionKeys = False
        Me.ImsButton2.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.AllowToolTip = True
        Me.BtnSave.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnSave.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.Save__1_
        Me.BtnSave.Location = New System.Drawing.Point(414, 449)
        Me.BtnSave.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.SetToolTip = ""
        Me.BtnSave.Size = New System.Drawing.Size(184, 43)
        Me.BtnSave.TabIndex = 37
        Me.BtnSave.Text = "Save"
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseFunctionKeys = False
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'TxtLength
        '
        Me.TxtLength.AllHelpText = True
        Me.TxtLength.AllowDecimal = False
        Me.TxtLength.AllowFormulas = False
        Me.TxtLength.AllowForQty = True
        Me.TxtLength.AllowNegative = False
        Me.TxtLength.AllowPerSign = False
        Me.TxtLength.AllowPlusSign = False
        Me.TxtLength.AllowToolTip = True
        Me.TxtLength.DecimalPlaces = CType(3, Short)
        Me.TxtLength.ExitOnEscKey = True
        Me.TxtLength.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLength.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLength.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtLength.HelpText = Nothing
        Me.TxtLength.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLength.Location = New System.Drawing.Point(133, 295)
        Me.TxtLength.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLength.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtLength.Max = CType(900, Long)
        Me.TxtLength.MaxLength = 12
        Me.TxtLength.Min = CType(0, Long)
        Me.TxtLength.Name = "TxtLength"
        Me.TxtLength.NextOnEnter = True
        Me.TxtLength.SetToolTip = Nothing
        Me.TxtLength.Size = New System.Drawing.Size(80, 20)
        Me.TxtLength.TabIndex = 28
        Me.TxtLength.Text = "0"
        Me.TxtLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtLength.ToolTip = Nothing
        Me.TxtLength.UseFunctionKeys = False
        Me.TxtLength.UseUpDownArrowKeys = False
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
        Me.TxtEmployeeName.Location = New System.Drawing.Point(133, 236)
        Me.TxtEmployeeName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtEmployeeName.Name = "TxtEmployeeName"
        Me.TxtEmployeeName.SetToolTip = Nothing
        Me.TxtEmployeeName.Size = New System.Drawing.Size(324, 21)
        Me.TxtEmployeeName.Sorted = True
        Me.TxtEmployeeName.SpecialCharList = "&-/@"
        Me.TxtEmployeeName.TabIndex = 26
        Me.TxtEmployeeName.UseFunctionKeys = False
        '
        'TxtConfirmby
        '
        Me.TxtConfirmby.AllowEmpty = True
        Me.TxtConfirmby.AllowOnlyListValues = False
        Me.TxtConfirmby.AllowToolTip = True
        Me.TxtConfirmby.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtConfirmby.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtConfirmby.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtConfirmby.FormattingEnabled = True
        Me.TxtConfirmby.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtConfirmby.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtConfirmby.IsAdvanceSearchWindow = False
        Me.TxtConfirmby.IsAllowDigits = True
        Me.TxtConfirmby.IsAllowSpace = True
        Me.TxtConfirmby.IsAllowSplChars = True
        Me.TxtConfirmby.IsAllowToolTip = True
        Me.TxtConfirmby.Items.AddRange(New Object() {"Direct", "Email", "Phone"})
        Me.TxtConfirmby.LFocusBackColor = System.Drawing.Color.White
        Me.TxtConfirmby.Location = New System.Drawing.Point(133, 331)
        Me.TxtConfirmby.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtConfirmby.Name = "TxtConfirmby"
        Me.TxtConfirmby.SetToolTip = Nothing
        Me.TxtConfirmby.Size = New System.Drawing.Size(324, 21)
        Me.TxtConfirmby.Sorted = True
        Me.TxtConfirmby.SpecialCharList = "&-/@"
        Me.TxtConfirmby.TabIndex = 29
        Me.TxtConfirmby.UseFunctionKeys = False
        '
        'TxtCustomerName
        '
        Me.TxtCustomerName.AllowEmpty = True
        Me.TxtCustomerName.AllowOnlyListValues = True
        Me.TxtCustomerName.AllowToolTip = True
        Me.TxtCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtCustomerName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtCustomerName.FormattingEnabled = True
        Me.TxtCustomerName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCustomerName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCustomerName.IsAdvanceSearchWindow = False
        Me.TxtCustomerName.IsAllowDigits = True
        Me.TxtCustomerName.IsAllowSpace = True
        Me.TxtCustomerName.IsAllowSplChars = True
        Me.TxtCustomerName.IsAllowToolTip = True
        Me.TxtCustomerName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCustomerName.Location = New System.Drawing.Point(133, 31)
        Me.TxtCustomerName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCustomerName.Name = "TxtCustomerName"
        Me.TxtCustomerName.SetToolTip = Nothing
        Me.TxtCustomerName.Size = New System.Drawing.Size(324, 21)
        Me.TxtCustomerName.Sorted = True
        Me.TxtCustomerName.SpecialCharList = "&-/@"
        Me.TxtCustomerName.TabIndex = 21
        Me.TxtCustomerName.UseFunctionKeys = False
        '
        'IsItLock
        '
        Me.IsItLock.AutoSize = True
        Me.IsItLock.Location = New System.Drawing.Point(485, 239)
        Me.IsItLock.Name = "IsItLock"
        Me.IsItLock.Size = New System.Drawing.Size(69, 17)
        Me.IsItLock.TabIndex = 39
        Me.IsItLock.Text = "Lock  ?"
        Me.IsItLock.UseVisualStyleBackColor = True
        '
        'NewAppointment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 504)
        Me.Controls.Add(Me.IsItLock)
        Me.Controls.Add(Me.TxtServiceList)
        Me.Controls.Add(Me.ImsButton2)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.TxtLength)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.IsWalkin)
        Me.Controls.Add(Me.TxtEmployeeName)
        Me.Controls.Add(Me.TxtConfirmby)
        Me.Controls.Add(Me.TxtCustomerName)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxtNotes)
        Me.Controls.Add(Me.TxtEndDate)
        Me.Controls.Add(Me.TxtStartDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtTotalMins)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewAppointment"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Appointment"
        CType(Me.TxtServiceList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtLength As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents IsWalkin As System.Windows.Forms.CheckBox
    Friend WithEvents TxtEmployeeName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtConfirmby As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtCustomerName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtNotes As System.Windows.Forms.TextBox
    Friend WithEvents TxtEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnSave As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton2 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtServiceList As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalMins As System.Windows.Forms.Label
    Friend WithEvents tsno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tbarcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tprice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tmins As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsItLock As System.Windows.Forms.CheckBox

End Class
