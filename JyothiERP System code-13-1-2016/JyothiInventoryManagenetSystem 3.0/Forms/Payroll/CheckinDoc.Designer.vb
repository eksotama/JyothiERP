<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckinDoc
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtno = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtDays = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtEmpname = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtDocName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txttype = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtNotes = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.txtcheckinnotes = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txtindate = New JyothiPharmaERPSystem3.IMSDate()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.txtcheckinnotes)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Txtindate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(546, 360)
        Me.Panel2.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtno)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtDays)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtEmpname)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtDocName)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txttype)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TxtDate)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtNotes)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(503, 246)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CHECK IN DETAILS"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Issue No"
        '
        'txtno
        '
        Me.txtno.AllowToolTip = True
        Me.txtno.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.txtno.Enabled = False
        Me.txtno.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtno.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtno.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtno.IsAllowDigits = True
        Me.txtno.IsAllowSpace = True
        Me.txtno.IsAllowSplChars = True
        Me.txtno.LFocusBackColor = System.Drawing.Color.White
        Me.txtno.Location = New System.Drawing.Point(124, 13)
        Me.txtno.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtno.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtno.MaxLength = 75
        Me.txtno.Name = "txtno"
        Me.txtno.SetToolTip = Nothing
        Me.txtno.Size = New System.Drawing.Size(165, 20)
        Me.txtno.SpecialCharList = "&-/@"
        Me.txtno.TabIndex = 0
        Me.txtno.UseFunctionKeys = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Issue Type"
        '
        'TxtDays
        '
        Me.TxtDays.AllHelpText = True
        Me.TxtDays.AllowDecimal = False
        Me.TxtDays.AllowFormulas = False
        Me.TxtDays.AllowForQty = True
        Me.TxtDays.AllowNegative = False
        Me.TxtDays.AllowPerSign = False
        Me.TxtDays.AllowPlusSign = False
        Me.TxtDays.AllowToolTip = True
        Me.TxtDays.DecimalPlaces = CType(3, Short)
        Me.TxtDays.Enabled = False
        Me.TxtDays.ExitOnEscKey = True
        Me.TxtDays.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDays.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDays.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtDays.HelpText = Nothing
        Me.TxtDays.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDays.Location = New System.Drawing.Point(123, 167)
        Me.TxtDays.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDays.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtDays.Max = CType(100000000000000, Long)
        Me.TxtDays.MaxLength = 12
        Me.TxtDays.Min = CType(0, Long)
        Me.TxtDays.Name = "TxtDays"
        Me.TxtDays.NextOnEnter = True
        Me.TxtDays.SetToolTip = Nothing
        Me.TxtDays.Size = New System.Drawing.Size(57, 20)
        Me.TxtDays.TabIndex = 5
        Me.TxtDays.Text = "1"
        Me.TxtDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtDays.ToolTip = Nothing
        Me.TxtDays.UseFunctionKeys = False
        Me.TxtDays.UseUpDownArrowKeys = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 169)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Expiry in"
        '
        'TxtEmpname
        '
        Me.TxtEmpname.AllowEmpty = True
        Me.TxtEmpname.AllowOnlyListValues = False
        Me.TxtEmpname.AllowToolTip = True
        Me.TxtEmpname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtEmpname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtEmpname.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtEmpname.Enabled = False
        Me.TxtEmpname.FormattingEnabled = True
        Me.TxtEmpname.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtEmpname.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtEmpname.IsAdvanceSearchWindow = False
        Me.TxtEmpname.IsAllowDigits = True
        Me.TxtEmpname.IsAllowSpace = True
        Me.TxtEmpname.IsAllowSplChars = True
        Me.TxtEmpname.IsAllowToolTip = True
        Me.TxtEmpname.Items.AddRange(New Object() {"Documents", "Vehicles"})
        Me.TxtEmpname.LFocusBackColor = System.Drawing.Color.White
        Me.TxtEmpname.Location = New System.Drawing.Point(124, 99)
        Me.TxtEmpname.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtEmpname.Name = "TxtEmpname"
        Me.TxtEmpname.SetToolTip = Nothing
        Me.TxtEmpname.Size = New System.Drawing.Size(304, 21)
        Me.TxtEmpname.Sorted = True
        Me.TxtEmpname.SpecialCharList = "&-/@"
        Me.TxtEmpname.TabIndex = 3
        Me.TxtEmpname.UseFunctionKeys = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Enabled = False
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(186, 170)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Days"
        '
        'TxtDocName
        '
        Me.TxtDocName.AllowEmpty = True
        Me.TxtDocName.AllowOnlyListValues = False
        Me.TxtDocName.AllowToolTip = True
        Me.TxtDocName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtDocName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtDocName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtDocName.Enabled = False
        Me.TxtDocName.FormattingEnabled = True
        Me.TxtDocName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDocName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDocName.IsAdvanceSearchWindow = False
        Me.TxtDocName.IsAllowDigits = True
        Me.TxtDocName.IsAllowSpace = True
        Me.TxtDocName.IsAllowSplChars = True
        Me.TxtDocName.IsAllowToolTip = True
        Me.TxtDocName.Items.AddRange(New Object() {"Documents", "Vehicles"})
        Me.TxtDocName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDocName.Location = New System.Drawing.Point(124, 72)
        Me.TxtDocName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDocName.Name = "TxtDocName"
        Me.TxtDocName.SetToolTip = Nothing
        Me.TxtDocName.Size = New System.Drawing.Size(304, 21)
        Me.TxtDocName.Sorted = True
        Me.TxtDocName.SpecialCharList = "&-/@"
        Me.TxtDocName.TabIndex = 2
        Me.TxtDocName.UseFunctionKeys = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Document"
        '
        'txttype
        '
        Me.txttype.AllowEmpty = False
        Me.txttype.AllowOnlyListValues = False
        Me.txttype.AllowToolTip = True
        Me.txttype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txttype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txttype.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.txttype.Enabled = False
        Me.txttype.FormattingEnabled = True
        Me.txttype.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txttype.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txttype.IsAdvanceSearchWindow = False
        Me.txttype.IsAllowDigits = True
        Me.txttype.IsAllowSpace = True
        Me.txttype.IsAllowSplChars = True
        Me.txttype.IsAllowToolTip = True
        Me.txttype.Items.AddRange(New Object() {"Documents", "Vehicles"})
        Me.txttype.LFocusBackColor = System.Drawing.Color.White
        Me.txttype.Location = New System.Drawing.Point(124, 45)
        Me.txttype.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txttype.Name = "txttype"
        Me.txttype.SetToolTip = Nothing
        Me.txttype.Size = New System.Drawing.Size(184, 21)
        Me.txttype.Sorted = True
        Me.txttype.SpecialCharList = "&-/@"
        Me.txttype.TabIndex = 1
        Me.txttype.UseFunctionKeys = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Employee Name"
        '
        'TxtDate
        '
        Me.TxtDate.CustomFormat = "dd/MM/yyyy hh:mm tt"
        Me.TxtDate.Enabled = False
        Me.TxtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtDate.Location = New System.Drawing.Point(124, 138)
        Me.TxtDate.Name = "TxtDate"
        Me.TxtDate.Size = New System.Drawing.Size(304, 20)
        Me.TxtDate.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Date Of Issue"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 198)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Notes"
        '
        'TxtNotes
        '
        Me.TxtNotes.AllowToolTip = True
        Me.TxtNotes.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtNotes.Enabled = False
        Me.TxtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNotes.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNotes.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNotes.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtNotes.IsAllowDigits = True
        Me.TxtNotes.IsAllowSpace = True
        Me.TxtNotes.IsAllowSplChars = True
        Me.TxtNotes.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNotes.Location = New System.Drawing.Point(124, 193)
        Me.TxtNotes.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNotes.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtNotes.MaxLength = 145
        Me.TxtNotes.Multiline = True
        Me.TxtNotes.Name = "TxtNotes"
        Me.TxtNotes.SetToolTip = Nothing
        Me.TxtNotes.Size = New System.Drawing.Size(305, 39)
        Me.TxtNotes.SpecialCharList = "&-/@()_"
        Me.TxtNotes.TabIndex = 6
        Me.TxtNotes.UseFunctionKeys = False
        '
        'txtcheckinnotes
        '
        Me.txtcheckinnotes.AllowToolTip = True
        Me.txtcheckinnotes.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.txtcheckinnotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcheckinnotes.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtcheckinnotes.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtcheckinnotes.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txtcheckinnotes.IsAllowDigits = True
        Me.txtcheckinnotes.IsAllowSpace = True
        Me.txtcheckinnotes.IsAllowSplChars = True
        Me.txtcheckinnotes.LFocusBackColor = System.Drawing.Color.White
        Me.txtcheckinnotes.Location = New System.Drawing.Point(139, 298)
        Me.txtcheckinnotes.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtcheckinnotes.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.txtcheckinnotes.MaxLength = 145
        Me.txtcheckinnotes.Multiline = True
        Me.txtcheckinnotes.Name = "txtcheckinnotes"
        Me.txtcheckinnotes.SetToolTip = Nothing
        Me.txtcheckinnotes.Size = New System.Drawing.Size(305, 39)
        Me.txtcheckinnotes.SpecialCharList = "&-/@()_"
        Me.txtcheckinnotes.TabIndex = 1
        Me.txtcheckinnotes.UseFunctionKeys = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(23, 272)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Check In Date"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(23, 296)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Check In Notes"
        '
        'Txtindate
        '
        Me.Txtindate.CustomFormat = "dd/MM/yyyy hh:mm tt"
        Me.Txtindate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Txtindate.Location = New System.Drawing.Point(140, 272)
        Me.Txtindate.Name = "Txtindate"
        Me.Txtindate.Size = New System.Drawing.Size(304, 20)
        Me.Txtindate.TabIndex = 0
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(53, 8)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(161, 43)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnCreate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 395)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(546, 60)
        Me.Panel1.TabIndex = 1
        '
        'BtnCreate
        '
        Me.BtnCreate.AllowToolTip = True
        Me.BtnCreate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCreate.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.back24
        Me.BtnCreate.Location = New System.Drawing.Point(325, 8)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(175, 43)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "&Check In"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Olive
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(552, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CHECK IN DOCUMENTS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.79352!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(552, 458)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'CheckinDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 458)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CheckinDoc"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CheckinDoc"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtno As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtDays As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtEmpname As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtDocName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents txttype As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtNotes As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtcheckinnotes As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txtindate As JyothiPharmaERPSystem3.IMSDate

End Class
