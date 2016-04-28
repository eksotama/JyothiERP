<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateNewLeave
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateNewLeave))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtColorCode = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtCode = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtMaxNos = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtLeaveType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtLeaveName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.79352!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtStatus, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(478, 317)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkOrange
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(478, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CREATE LEAVES"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnCreate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 221)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(472, 67)
        Me.Panel1.TabIndex = 1
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(28, 13)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(161, 43)
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
        Me.BtnCreate.Location = New System.Drawing.Point(268, 13)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(175, 43)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "&Create"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.TxtColorCode)
        Me.Panel2.Controls.Add(Me.TxtCode)
        Me.Panel2.Controls.Add(Me.TxtMaxNos)
        Me.Panel2.Controls.Add(Me.TxtLeaveType)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.TxtLeaveName)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(472, 186)
        Me.Panel2.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Location = New System.Drawing.Point(142, 149)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(64, 22)
        Me.Panel3.TabIndex = 5
        '
        'TxtColorCode
        '
        Me.TxtColorCode.AllowEmpty = True
        Me.TxtColorCode.AllowOnlyListValues = False
        Me.TxtColorCode.AllowToolTip = True
        Me.TxtColorCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtColorCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtColorCode.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtColorCode.FormattingEnabled = True
        Me.TxtColorCode.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtColorCode.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtColorCode.IsAdvanceSearchWindow = False
        Me.TxtColorCode.IsAllowDigits = True
        Me.TxtColorCode.IsAllowSpace = True
        Me.TxtColorCode.IsAllowSplChars = True
        Me.TxtColorCode.IsAllowToolTip = True
        Me.TxtColorCode.LFocusBackColor = System.Drawing.Color.White
        Me.TxtColorCode.Location = New System.Drawing.Point(212, 150)
        Me.TxtColorCode.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtColorCode.Name = "TxtColorCode"
        Me.TxtColorCode.SetToolTip = Nothing
        Me.TxtColorCode.Size = New System.Drawing.Size(112, 21)
        Me.TxtColorCode.Sorted = True
        Me.TxtColorCode.SpecialCharList = "&-/@"
        Me.TxtColorCode.TabIndex = 4
        Me.TxtColorCode.UseFunctionKeys = False
        '
        'TxtCode
        '
        Me.TxtCode.AllowToolTip = True
        Me.TxtCode.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.UPPER
        Me.TxtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtCode.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCode.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCode.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtCode.IsAllowDigits = False
        Me.TxtCode.IsAllowSpace = False
        Me.TxtCode.IsAllowSplChars = False
        Me.TxtCode.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCode.Location = New System.Drawing.Point(140, 17)
        Me.TxtCode.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCode.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtCode.MaxLength = 3
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.SetToolTip = Nothing
        Me.TxtCode.Size = New System.Drawing.Size(100, 20)
        Me.TxtCode.SpecialCharList = ""
        Me.TxtCode.TabIndex = 0
        Me.TxtCode.UseFunctionKeys = False
        '
        'TxtMaxNos
        '
        Me.TxtMaxNos.AllHelpText = True
        Me.TxtMaxNos.AllowDecimal = False
        Me.TxtMaxNos.AllowFormulas = False
        Me.TxtMaxNos.AllowForQty = True
        Me.TxtMaxNos.AllowNegative = False
        Me.TxtMaxNos.AllowPerSign = False
        Me.TxtMaxNos.AllowPlusSign = False
        Me.TxtMaxNos.AllowToolTip = True
        Me.TxtMaxNos.DecimalPlaces = CType(3, Short)
        Me.TxtMaxNos.ExitOnEscKey = True
        Me.TxtMaxNos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMaxNos.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtMaxNos.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtMaxNos.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtMaxNos.HelpText = Nothing
        Me.TxtMaxNos.LFocusBackColor = System.Drawing.Color.White
        Me.TxtMaxNos.Location = New System.Drawing.Point(140, 114)
        Me.TxtMaxNos.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtMaxNos.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtMaxNos.Max = CType(100000000000000, Long)
        Me.TxtMaxNos.MaxLength = 3
        Me.TxtMaxNos.Min = CType(0, Long)
        Me.TxtMaxNos.Name = "TxtMaxNos"
        Me.TxtMaxNos.NextOnEnter = True
        Me.TxtMaxNos.SetToolTip = Nothing
        Me.TxtMaxNos.Size = New System.Drawing.Size(112, 21)
        Me.TxtMaxNos.TabIndex = 3
        Me.TxtMaxNos.Text = "0"
        Me.TxtMaxNos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtMaxNos.ToolTip = Nothing
        Me.TxtMaxNos.UseFunctionKeys = False
        Me.TxtMaxNos.UseUpDownArrowKeys = False
        '
        'TxtLeaveType
        '
        Me.TxtLeaveType.AllowEmpty = True
        Me.TxtLeaveType.AllowOnlyListValues = True
        Me.TxtLeaveType.AllowToolTip = True
        Me.TxtLeaveType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtLeaveType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtLeaveType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtLeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtLeaveType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLeaveType.FormattingEnabled = True
        Me.TxtLeaveType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLeaveType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLeaveType.IsAdvanceSearchWindow = False
        Me.TxtLeaveType.IsAllowDigits = True
        Me.TxtLeaveType.IsAllowSpace = True
        Me.TxtLeaveType.IsAllowSplChars = True
        Me.TxtLeaveType.IsAllowToolTip = True
        Me.TxtLeaveType.Items.AddRange(New Object() {"EARNED LEAVE", "PAID LEAVE", "UNPAID LEAVE"})
        Me.TxtLeaveType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLeaveType.Location = New System.Drawing.Point(140, 80)
        Me.TxtLeaveType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLeaveType.Name = "TxtLeaveType"
        Me.TxtLeaveType.SetToolTip = Nothing
        Me.TxtLeaveType.Size = New System.Drawing.Size(184, 23)
        Me.TxtLeaveType.Sorted = True
        Me.TxtLeaveType.SpecialCharList = "&-/@"
        Me.TxtLeaveType.TabIndex = 2
        Me.TxtLeaveType.UseFunctionKeys = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 28)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Maximum Leaves Per Employee"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Leave Type"
        '
        'TxtLeaveName
        '
        Me.TxtLeaveName.AllowToolTip = True
        Me.TxtLeaveName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtLeaveName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLeaveName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLeaveName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLeaveName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtLeaveName.IsAllowDigits = True
        Me.TxtLeaveName.IsAllowSpace = True
        Me.TxtLeaveName.IsAllowSplChars = True
        Me.TxtLeaveName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLeaveName.Location = New System.Drawing.Point(140, 46)
        Me.TxtLeaveName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLeaveName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtLeaveName.MaxLength = 35
        Me.TxtLeaveName.Name = "TxtLeaveName"
        Me.TxtLeaveName.SetToolTip = Nothing
        Me.TxtLeaveName.Size = New System.Drawing.Size(184, 21)
        Me.TxtLeaveName.SpecialCharList = "&-/@()_"
        Me.TxtLeaveName.TabIndex = 1
        Me.TxtLeaveName.UseFunctionKeys = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Leave Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(25, 153)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Color Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(25, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Leave Code"
        '
        'TxtStatus
        '
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Green
        Me.TxtStatus.Location = New System.Drawing.Point(3, 291)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(472, 26)
        Me.TxtStatus.TabIndex = 0
        Me.TxtStatus.Text = "Status: Ready"
        '
        'CreateNewLeave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(478, 317)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CreateNewLeave"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Create New Leave"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtLeaveType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtLeaveName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtStatus As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TxtMaxNos As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCode As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtColorCode As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel

End Class
