<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateUnits
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateUnits))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtSimplePanel = New System.Windows.Forms.Panel()
        Me.TxtDecimals = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtFormalName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtSimpleUnitName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtCompoundpanel = New System.Windows.Forms.Panel()
        Me.TxtSubUnit = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtMainUnitName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtConversion = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtUnitType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TxtSimplePanel.SuspendLayout()
        Me.TxtCompoundpanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtStatus, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(534, 281)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.DarkOrange
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(528, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "UNIT OF MEASUREMENTS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtSimplePanel)
        Me.Panel1.Controls.Add(Me.TxtCompoundpanel)
        Me.Panel1.Controls.Add(Me.TxtUnitType)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(528, 155)
        Me.Panel1.TabIndex = 2
        '
        'TxtSimplePanel
        '
        Me.TxtSimplePanel.Controls.Add(Me.TxtDecimals)
        Me.TxtSimplePanel.Controls.Add(Me.TxtFormalName)
        Me.TxtSimplePanel.Controls.Add(Me.TxtSimpleUnitName)
        Me.TxtSimplePanel.Controls.Add(Me.Label6)
        Me.TxtSimplePanel.Controls.Add(Me.Label5)
        Me.TxtSimplePanel.Controls.Add(Me.Label3)
        Me.TxtSimplePanel.Location = New System.Drawing.Point(23, 40)
        Me.TxtSimplePanel.Name = "TxtSimplePanel"
        Me.TxtSimplePanel.Size = New System.Drawing.Size(371, 93)
        Me.TxtSimplePanel.TabIndex = 2
        '
        'TxtDecimals
        '
        Me.TxtDecimals.AllHelpText = True
        Me.TxtDecimals.AllowDecimal = False
        Me.TxtDecimals.AllowFormulas = False
        Me.TxtDecimals.AllowForQty = True
        Me.TxtDecimals.AllowNegative = False
        Me.TxtDecimals.AllowPerSign = False
        Me.TxtDecimals.AllowPlusSign = False
        Me.TxtDecimals.AllowToolTip = True
        Me.TxtDecimals.DecimalPlaces = CType(3, Short)
        Me.TxtDecimals.ExitOnEscKey = True
        Me.TxtDecimals.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDecimals.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDecimals.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtDecimals.HelpText = Nothing
        Me.TxtDecimals.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDecimals.Location = New System.Drawing.Point(128, 68)
        Me.TxtDecimals.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDecimals.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtDecimals.Max = CType(100000000000000, Long)
        Me.TxtDecimals.MaxLength = 6
        Me.TxtDecimals.Min = CType(0, Long)
        Me.TxtDecimals.Name = "TxtDecimals"
        Me.TxtDecimals.NextOnEnter = True
        Me.TxtDecimals.SetToolTip = Nothing
        Me.TxtDecimals.Size = New System.Drawing.Size(72, 20)
        Me.TxtDecimals.TabIndex = 2
        Me.TxtDecimals.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtDecimals.ToolTip = Nothing
        Me.TxtDecimals.UseFunctionKeys = False
        Me.TxtDecimals.UseUpDownArrowKeys = False
        '
        'TxtFormalName
        '
        Me.TxtFormalName.AllowToolTip = True
        Me.TxtFormalName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtFormalName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtFormalName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtFormalName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtFormalName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtFormalName.IsAllowDigits = True
        Me.TxtFormalName.IsAllowSpace = True
        Me.TxtFormalName.IsAllowSplChars = True
        Me.TxtFormalName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtFormalName.Location = New System.Drawing.Point(126, 37)
        Me.TxtFormalName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtFormalName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtFormalName.MaxLength = 35
        Me.TxtFormalName.Name = "TxtFormalName"
        Me.TxtFormalName.SetToolTip = Nothing
        Me.TxtFormalName.Size = New System.Drawing.Size(171, 20)
        Me.TxtFormalName.SpecialCharList = "&-/@"
        Me.TxtFormalName.TabIndex = 1
        Me.TxtFormalName.UseFunctionKeys = False
        '
        'TxtSimpleUnitName
        '
        Me.TxtSimpleUnitName.AllowToolTip = True
        Me.TxtSimpleUnitName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtSimpleUnitName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtSimpleUnitName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSimpleUnitName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSimpleUnitName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtSimpleUnitName.IsAllowDigits = True
        Me.TxtSimpleUnitName.IsAllowSpace = False
        Me.TxtSimpleUnitName.IsAllowSplChars = True
        Me.TxtSimpleUnitName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSimpleUnitName.Location = New System.Drawing.Point(126, 8)
        Me.TxtSimpleUnitName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSimpleUnitName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtSimpleUnitName.MaxLength = 25
        Me.TxtSimpleUnitName.Name = "TxtSimpleUnitName"
        Me.TxtSimpleUnitName.SetToolTip = Nothing
        Me.TxtSimpleUnitName.Size = New System.Drawing.Size(171, 20)
        Me.TxtSimpleUnitName.SpecialCharList = "&-/@"
        Me.TxtSimpleUnitName.TabIndex = 0
        Me.TxtSimpleUnitName.UseFunctionKeys = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "No of Decimals"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Formal Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Unit Name"
        '
        'TxtCompoundpanel
        '
        Me.TxtCompoundpanel.Controls.Add(Me.TxtSubUnit)
        Me.TxtCompoundpanel.Controls.Add(Me.TxtMainUnitName)
        Me.TxtCompoundpanel.Controls.Add(Me.TxtConversion)
        Me.TxtCompoundpanel.Controls.Add(Me.Label8)
        Me.TxtCompoundpanel.Controls.Add(Me.Label7)
        Me.TxtCompoundpanel.Controls.Add(Me.Label4)
        Me.TxtCompoundpanel.Location = New System.Drawing.Point(22, 43)
        Me.TxtCompoundpanel.Name = "TxtCompoundpanel"
        Me.TxtCompoundpanel.Size = New System.Drawing.Size(490, 63)
        Me.TxtCompoundpanel.TabIndex = 2
        '
        'TxtSubUnit
        '
        Me.TxtSubUnit.AllowEmpty = True
        Me.TxtSubUnit.AllowOnlyListValues = True
        Me.TxtSubUnit.AllowToolTip = True
        Me.TxtSubUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TxtSubUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtSubUnit.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtSubUnit.FormattingEnabled = True
        Me.TxtSubUnit.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSubUnit.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSubUnit.IsAdvanceSearchWindow = False
        Me.TxtSubUnit.IsAllowDigits = True
        Me.TxtSubUnit.IsAllowSpace = True
        Me.TxtSubUnit.IsAllowSplChars = True
        Me.TxtSubUnit.IsAllowToolTip = True
        Me.TxtSubUnit.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSubUnit.Location = New System.Drawing.Point(278, 32)
        Me.TxtSubUnit.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSubUnit.MaxLength = 50
        Me.TxtSubUnit.Name = "TxtSubUnit"
        Me.TxtSubUnit.SetToolTip = Nothing
        Me.TxtSubUnit.Size = New System.Drawing.Size(186, 21)
        Me.TxtSubUnit.Sorted = True
        Me.TxtSubUnit.SpecialCharList = "&-/@"
        Me.TxtSubUnit.TabIndex = 2
        Me.TxtSubUnit.UseFunctionKeys = False
        '
        'TxtMainUnitName
        '
        Me.TxtMainUnitName.AllowEmpty = True
        Me.TxtMainUnitName.AllowOnlyListValues = True
        Me.TxtMainUnitName.AllowToolTip = True
        Me.TxtMainUnitName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TxtMainUnitName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtMainUnitName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtMainUnitName.FormattingEnabled = True
        Me.TxtMainUnitName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtMainUnitName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtMainUnitName.IsAdvanceSearchWindow = False
        Me.TxtMainUnitName.IsAllowDigits = True
        Me.TxtMainUnitName.IsAllowSpace = True
        Me.TxtMainUnitName.IsAllowSplChars = True
        Me.TxtMainUnitName.IsAllowToolTip = True
        Me.TxtMainUnitName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtMainUnitName.Location = New System.Drawing.Point(8, 32)
        Me.TxtMainUnitName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtMainUnitName.Name = "TxtMainUnitName"
        Me.TxtMainUnitName.SetToolTip = Nothing
        Me.TxtMainUnitName.Size = New System.Drawing.Size(186, 21)
        Me.TxtMainUnitName.Sorted = True
        Me.TxtMainUnitName.SpecialCharList = "&-/@"
        Me.TxtMainUnitName.TabIndex = 0
        Me.TxtMainUnitName.UseFunctionKeys = False
        '
        'TxtConversion
        '
        Me.TxtConversion.AllHelpText = True
        Me.TxtConversion.AllowDecimal = False
        Me.TxtConversion.AllowFormulas = False
        Me.TxtConversion.AllowForQty = True
        Me.TxtConversion.AllowNegative = False
        Me.TxtConversion.AllowPerSign = False
        Me.TxtConversion.AllowPlusSign = False
        Me.TxtConversion.AllowToolTip = True
        Me.TxtConversion.DecimalPlaces = CType(3, Short)
        Me.TxtConversion.ExitOnEscKey = True
        Me.TxtConversion.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtConversion.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtConversion.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtConversion.HelpText = Nothing
        Me.TxtConversion.LFocusBackColor = System.Drawing.Color.White
        Me.TxtConversion.Location = New System.Drawing.Point(200, 32)
        Me.TxtConversion.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtConversion.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtConversion.Max = CType(100000000000000, Long)
        Me.TxtConversion.MaxLength = 12
        Me.TxtConversion.Min = CType(0, Long)
        Me.TxtConversion.Name = "TxtConversion"
        Me.TxtConversion.NextOnEnter = True
        Me.TxtConversion.SetToolTip = Nothing
        Me.TxtConversion.Size = New System.Drawing.Size(72, 20)
        Me.TxtConversion.TabIndex = 1
        Me.TxtConversion.Text = "0"
        Me.TxtConversion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtConversion.ToolTip = Nothing
        Me.TxtConversion.UseFunctionKeys = False
        Me.TxtConversion.UseUpDownArrowKeys = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(278, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Sub Unit"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(198, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Converstion"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Unit Name"
        '
        'TxtUnitType
        '
        Me.TxtUnitType.AllowEmpty = True
        Me.TxtUnitType.AllowOnlyListValues = False
        Me.TxtUnitType.AllowToolTip = True
        Me.TxtUnitType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TxtUnitType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtUnitType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtUnitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtUnitType.FormattingEnabled = True
        Me.TxtUnitType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtUnitType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtUnitType.IsAdvanceSearchWindow = False
        Me.TxtUnitType.IsAllowDigits = True
        Me.TxtUnitType.IsAllowSpace = True
        Me.TxtUnitType.IsAllowSplChars = True
        Me.TxtUnitType.IsAllowToolTip = True
        Me.TxtUnitType.Items.AddRange(New Object() {"Compound", "Simple"})
        Me.TxtUnitType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtUnitType.Location = New System.Drawing.Point(92, 13)
        Me.TxtUnitType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtUnitType.Name = "TxtUnitType"
        Me.TxtUnitType.SetToolTip = Nothing
        Me.TxtUnitType.Size = New System.Drawing.Size(165, 21)
        Me.TxtUnitType.Sorted = True
        Me.TxtUnitType.SpecialCharList = "&-/@"
        Me.TxtUnitType.TabIndex = 0
        Me.TxtUnitType.UseFunctionKeys = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Unit Type"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnClose)
        Me.Panel2.Controls.Add(Me.BtnCreate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 193)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(528, 61)
        Me.Panel2.TabIndex = 3
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(46, 10)
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
        Me.BtnCreate.Location = New System.Drawing.Point(337, 10)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(150, 43)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "&Create"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = False
        '
        'TxtStatus
        '
        Me.TxtStatus.AutoSize = True
        Me.TxtStatus.BackColor = System.Drawing.Color.White
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Green
        Me.TxtStatus.Location = New System.Drawing.Point(3, 257)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(528, 24)
        Me.TxtStatus.TabIndex = 0
        Me.TxtStatus.Text = "Status: Ready"
        '
        'Timer1
        '
        '
        'CreateUnits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(534, 281)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CreateUnits"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Create Units"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TxtSimplePanel.ResumeLayout(False)
        Me.TxtSimplePanel.PerformLayout()
        Me.TxtCompoundpanel.ResumeLayout(False)
        Me.TxtCompoundpanel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCompoundpanel As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtSimplePanel As System.Windows.Forms.Panel
    Friend WithEvents TxtSimpleUnitName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtUnitType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtDecimals As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtFormalName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtConversion As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtSubUnit As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtMainUnitName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtStatus As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
