<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SMSSettingForm
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.IsSetAsDefault = New System.Windows.Forms.CheckBox()
        Me.GSMPanel = New System.Windows.Forms.Panel()
        Me.TxtBaudRate = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtServiceNO = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtPortName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.APIPanel = New System.Windows.Forms.Panel()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtAPIURL = New System.Windows.Forms.TextBox()
        Me.TxtSMSTYPE = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtUserName = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1.SuspendLayout()
        Me.GSMPanel.SuspendLayout()
        Me.APIPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ImsButton1)
        Me.Panel1.Controls.Add(Me.IsSetAsDefault)
        Me.Panel1.Controls.Add(Me.GSMPanel)
        Me.Panel1.Controls.Add(Me.APIPanel)
        Me.Panel1.Controls.Add(Me.TxtSMSTYPE)
        Me.Panel1.Controls.Add(Me.ImSlabel4)
        Me.Panel1.Controls.Add(Me.TxtUserName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(796, 249)
        Me.Panel1.TabIndex = 2
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Location = New System.Drawing.Point(590, 200)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(171, 32)
        Me.ImsButton1.TabIndex = 7
        Me.ImsButton1.Text = "SMS MESSAGE SETTINGS"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = True
        '
        'IsSetAsDefault
        '
        Me.IsSetAsDefault.AutoSize = True
        Me.IsSetAsDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsSetAsDefault.Location = New System.Drawing.Point(38, 187)
        Me.IsSetAsDefault.Name = "IsSetAsDefault"
        Me.IsSetAsDefault.Size = New System.Drawing.Size(116, 19)
        Me.IsSetAsDefault.TabIndex = 6
        Me.IsSetAsDefault.Text = "Set As Default"
        Me.IsSetAsDefault.UseVisualStyleBackColor = True
        '
        'GSMPanel
        '
        Me.GSMPanel.Controls.Add(Me.TxtBaudRate)
        Me.GSMPanel.Controls.Add(Me.TxtServiceNO)
        Me.GSMPanel.Controls.Add(Me.ImSlabel8)
        Me.GSMPanel.Controls.Add(Me.ImSlabel7)
        Me.GSMPanel.Controls.Add(Me.ImSlabel1)
        Me.GSMPanel.Controls.Add(Me.TxtPortName)
        Me.GSMPanel.Location = New System.Drawing.Point(9, 36)
        Me.GSMPanel.Name = "GSMPanel"
        Me.GSMPanel.Size = New System.Drawing.Size(407, 134)
        Me.GSMPanel.TabIndex = 5
        '
        'TxtBaudRate
        '
        Me.TxtBaudRate.AllHelpText = True
        Me.TxtBaudRate.AllowDecimal = False
        Me.TxtBaudRate.AllowFormulas = False
        Me.TxtBaudRate.AllowForQty = True
        Me.TxtBaudRate.AllowNegative = False
        Me.TxtBaudRate.AllowPerSign = False
        Me.TxtBaudRate.AllowPlusSign = False
        Me.TxtBaudRate.AllowToolTip = True
        Me.TxtBaudRate.DecimalPlaces = CType(3, Short)
        Me.TxtBaudRate.ExitOnEscKey = True
        Me.TxtBaudRate.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtBaudRate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtBaudRate.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtBaudRate.HelpText = Nothing
        Me.TxtBaudRate.LFocusBackColor = System.Drawing.Color.White
        Me.TxtBaudRate.Location = New System.Drawing.Point(175, 59)
        Me.TxtBaudRate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtBaudRate.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtBaudRate.Max = CType(100000000000000, Long)
        Me.TxtBaudRate.MaxLength = 12
        Me.TxtBaudRate.Min = CType(0, Long)
        Me.TxtBaudRate.Name = "TxtBaudRate"
        Me.TxtBaudRate.NextOnEnter = True
        Me.TxtBaudRate.SetToolTip = Nothing
        Me.TxtBaudRate.Size = New System.Drawing.Size(170, 20)
        Me.TxtBaudRate.TabIndex = 2
        Me.TxtBaudRate.Text = "9600"
        Me.TxtBaudRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtBaudRate.ToolTip = Nothing
        Me.TxtBaudRate.UseFunctionKeys = False
        Me.TxtBaudRate.UseUpDownArrowKeys = False
        '
        'TxtServiceNO
        '
        Me.TxtServiceNO.AllowToolTip = True
        Me.TxtServiceNO.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtServiceNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtServiceNO.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtServiceNO.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtServiceNO.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtServiceNO.IsAllowDigits = True
        Me.TxtServiceNO.IsAllowSpace = True
        Me.TxtServiceNO.IsAllowSplChars = True
        Me.TxtServiceNO.LFocusBackColor = System.Drawing.Color.White
        Me.TxtServiceNO.Location = New System.Drawing.Point(175, 34)
        Me.TxtServiceNO.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtServiceNO.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtServiceNO.MaxLength = 75
        Me.TxtServiceNO.Name = "TxtServiceNO"
        Me.TxtServiceNO.SetToolTip = Nothing
        Me.TxtServiceNO.Size = New System.Drawing.Size(170, 20)
        Me.TxtServiceNO.SpecialCharList = "&-/@+ "
        Me.TxtServiceNO.TabIndex = 1
        Me.TxtServiceNO.UseFunctionKeys = False
        '
        'ImSlabel8
        '
        Me.ImSlabel8.AutoSize = True
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(14, 59)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(63, 13)
        Me.ImSlabel8.TabIndex = 1
        Me.ImSlabel8.Text = "BaudRate"
        '
        'ImSlabel7
        '
        Me.ImSlabel7.AutoSize = True
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(14, 34)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(151, 13)
        Me.ImSlabel7.TabIndex = 1
        Me.ImSlabel7.Text = "Message Service Number"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(14, 9)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(66, 13)
        Me.ImSlabel1.TabIndex = 1
        Me.ImSlabel1.Text = "Port Name"
        '
        'TxtPortName
        '
        Me.TxtPortName.AllowEmpty = True
        Me.TxtPortName.AllowOnlyListValues = False
        Me.TxtPortName.AllowToolTip = True
        Me.TxtPortName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtPortName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtPortName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtPortName.FormattingEnabled = True
        Me.TxtPortName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPortName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPortName.IsAdvanceSearchWindow = False
        Me.TxtPortName.IsAllowDigits = True
        Me.TxtPortName.IsAllowSpace = True
        Me.TxtPortName.IsAllowSplChars = True
        Me.TxtPortName.IsAllowToolTip = True
        Me.TxtPortName.Items.AddRange(New Object() {"COM1", "COM2", "COM3", "COM4", "COM5", "COM6"})
        Me.TxtPortName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPortName.Location = New System.Drawing.Point(175, 6)
        Me.TxtPortName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPortName.Name = "TxtPortName"
        Me.TxtPortName.SetToolTip = Nothing
        Me.TxtPortName.Size = New System.Drawing.Size(173, 21)
        Me.TxtPortName.Sorted = True
        Me.TxtPortName.SpecialCharList = "&-/@"
        Me.TxtPortName.TabIndex = 0
        Me.TxtPortName.UseFunctionKeys = False
        '
        'APIPanel
        '
        Me.APIPanel.Controls.Add(Me.ImSlabel6)
        Me.APIPanel.Controls.Add(Me.ImSlabel5)
        Me.APIPanel.Controls.Add(Me.ImSlabel3)
        Me.APIPanel.Controls.Add(Me.ImSlabel2)
        Me.APIPanel.Controls.Add(Me.TxtAPIURL)
        Me.APIPanel.Location = New System.Drawing.Point(17, 33)
        Me.APIPanel.Name = "APIPanel"
        Me.APIPanel.Size = New System.Drawing.Size(745, 149)
        Me.APIPanel.TabIndex = 4
        '
        'ImSlabel6
        '
        Me.ImSlabel6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(12, 102)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(604, 47)
        Me.ImSlabel6.TabIndex = 1
        Me.ImSlabel6.Text = "Ex:  http://127.0.0.1:9501/api?action=sendmessage&username=admin&password=abc123&" & _
    " recipient=@MOBILENO@&messagetype=SMS:TEXT&messagedata=@MSG@"
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(12, 77)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(149, 13)
        Me.ImSlabel5.TabIndex = 1
        Me.ImSlabel5.Text = "Message Code: @MSG@"
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(12, 55)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(200, 13)
        Me.ImSlabel3.TabIndex = 1
        Me.ImSlabel3.Text = "Mobile No Code = @MOBILENO@"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(12, 12)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(56, 13)
        Me.ImSlabel2.TabIndex = 1
        Me.ImSlabel2.Text = "API URL"
        '
        'TxtAPIURL
        '
        Me.TxtAPIURL.Location = New System.Drawing.Point(74, 12)
        Me.TxtAPIURL.MaxLength = 250
        Me.TxtAPIURL.Multiline = True
        Me.TxtAPIURL.Name = "TxtAPIURL"
        Me.TxtAPIURL.Size = New System.Drawing.Size(653, 40)
        Me.TxtAPIURL.TabIndex = 0
        '
        'TxtSMSTYPE
        '
        Me.TxtSMSTYPE.AllowEmpty = True
        Me.TxtSMSTYPE.AllowOnlyListValues = False
        Me.TxtSMSTYPE.AllowToolTip = True
        Me.TxtSMSTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtSMSTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtSMSTYPE.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtSMSTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtSMSTYPE.FormattingEnabled = True
        Me.TxtSMSTYPE.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSMSTYPE.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSMSTYPE.IsAdvanceSearchWindow = False
        Me.TxtSMSTYPE.IsAllowDigits = True
        Me.TxtSMSTYPE.IsAllowSpace = True
        Me.TxtSMSTYPE.IsAllowSplChars = True
        Me.TxtSMSTYPE.IsAllowToolTip = True
        Me.TxtSMSTYPE.Items.AddRange(New Object() {"API", "GSM Mobile"})
        Me.TxtSMSTYPE.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSMSTYPE.Location = New System.Drawing.Point(170, 4)
        Me.TxtSMSTYPE.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSMSTYPE.Name = "TxtSMSTYPE"
        Me.TxtSMSTYPE.SetToolTip = Nothing
        Me.TxtSMSTYPE.Size = New System.Drawing.Size(173, 21)
        Me.TxtSMSTYPE.Sorted = True
        Me.TxtSMSTYPE.SpecialCharList = "&-/@"
        Me.TxtSMSTYPE.TabIndex = 0
        Me.TxtSMSTYPE.UseFunctionKeys = False
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(29, 6)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(109, 13)
        Me.ImSlabel4.TabIndex = 1
        Me.ImSlabel4.Text = "SMS Device Type"
        '
        'TxtUserName
        '
        Me.TxtUserName.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUserName.ForeColor = System.Drawing.Color.Maroon
        Me.TxtUserName.Location = New System.Drawing.Point(0, 0)
        Me.TxtUserName.Name = "TxtUserName"
        Me.TxtUserName.Size = New System.Drawing.Size(796, 24)
        Me.TxtUserName.TabIndex = 0
        Me.TxtUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(796, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "SMS CONFIGURATION"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnClose)
        Me.Panel2.Controls.Add(Me.BtnCreate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 287)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(796, 63)
        Me.Panel2.TabIndex = 3
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(79, 10)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(176, 43)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnCreate
        '
        Me.BtnCreate.AllowToolTip = True
        Me.BtnCreate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCreate.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.Save__1_
        Me.BtnCreate.Location = New System.Drawing.Point(379, 10)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(175, 43)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "&Save"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(802, 361)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'SMSSettingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 361)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SMSSettingForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SMS Setting"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GSMPanel.ResumeLayout(False)
        Me.GSMPanel.PerformLayout()
        Me.APIPanel.ResumeLayout(False)
        Me.APIPanel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtAPIURL As System.Windows.Forms.TextBox
    Friend WithEvents TxtUserName As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtSMSTYPE As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents APIPanel As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents GSMPanel As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtBaudRate As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtServiceNO As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtPortName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents IsSetAsDefault As System.Windows.Forms.CheckBox
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton

End Class
