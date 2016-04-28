<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNewClient
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNewClient))
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.TxtContactno2 = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtContactno1 = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtPeriod = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtContractType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtEmailID = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtContactPerson = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtDesc = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtAddress = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtClientName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnCreate
        '
        Me.BtnCreate.AllowToolTip = True
        Me.BtnCreate.BackColor = System.Drawing.Color.White
        Me.BtnCreate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCreate.Image = CType(resources.GetObject("BtnCreate.Image"), System.Drawing.Image)
        Me.BtnCreate.Location = New System.Drawing.Point(318, 7)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(159, 50)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "&Create"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = False
        '
        'TxtStatus
        '
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Green
        Me.TxtStatus.Location = New System.Drawing.Point(3, 412)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(487, 25)
        Me.TxtStatus.TabIndex = 4
        Me.TxtStatus.Text = "Status: Ready"
        '
        'TxtContactno2
        '
        Me.TxtContactno2.AllowToolTip = True
        Me.TxtContactno2.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtContactno2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtContactno2.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtContactno2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtContactno2.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtContactno2.IsAllowDigits = True
        Me.TxtContactno2.IsAllowSpace = True
        Me.TxtContactno2.IsAllowSplChars = True
        Me.TxtContactno2.LFocusBackColor = System.Drawing.Color.White
        Me.TxtContactno2.Location = New System.Drawing.Point(183, 115)
        Me.TxtContactno2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtContactno2.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtContactno2.MaxLength = 20
        Me.TxtContactno2.Name = "TxtContactno2"
        Me.TxtContactno2.SetToolTip = Nothing
        Me.TxtContactno2.Size = New System.Drawing.Size(282, 20)
        Me.TxtContactno2.SpecialCharList = "&-/@"
        Me.TxtContactno2.TabIndex = 3
        Me.TxtContactno2.UseFunctionKeys = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnClose)
        Me.Panel2.Controls.Add(Me.BtnCreate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 349)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(487, 60)
        Me.Panel2.TabIndex = 3
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(27, 7)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(159, 50)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'TxtContactno1
        '
        Me.TxtContactno1.AllowToolTip = True
        Me.TxtContactno1.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtContactno1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtContactno1.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtContactno1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtContactno1.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtContactno1.IsAllowDigits = True
        Me.TxtContactno1.IsAllowSpace = True
        Me.TxtContactno1.IsAllowSplChars = True
        Me.TxtContactno1.LFocusBackColor = System.Drawing.Color.White
        Me.TxtContactno1.Location = New System.Drawing.Point(183, 89)
        Me.TxtContactno1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtContactno1.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtContactno1.MaxLength = 20
        Me.TxtContactno1.Name = "TxtContactno1"
        Me.TxtContactno1.SetToolTip = Nothing
        Me.TxtContactno1.Size = New System.Drawing.Size(282, 20)
        Me.TxtContactno1.SpecialCharList = "&-/@"
        Me.TxtContactno1.TabIndex = 2
        Me.TxtContactno1.UseFunctionKeys = False
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(493, 437)
        Me.TableLayoutPanel1.TabIndex = 4
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
        Me.Label2.Size = New System.Drawing.Size(493, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "CREATE NEW CLIENT"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtPeriod)
        Me.Panel1.Controls.Add(Me.TxtContractType)
        Me.Panel1.Controls.Add(Me.TxtEmailID)
        Me.Panel1.Controls.Add(Me.TxtContactPerson)
        Me.Panel1.Controls.Add(Me.TxtContactno2)
        Me.Panel1.Controls.Add(Me.TxtContactno1)
        Me.Panel1.Controls.Add(Me.TxtDesc)
        Me.Panel1.Controls.Add(Me.TxtAddress)
        Me.Panel1.Controls.Add(Me.TxtClientName)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(487, 317)
        Me.Panel1.TabIndex = 2
        '
        'TxtPeriod
        '
        Me.TxtPeriod.AllHelpText = True
        Me.TxtPeriod.AllowDecimal = False
        Me.TxtPeriod.AllowFormulas = False
        Me.TxtPeriod.AllowForQty = True
        Me.TxtPeriod.AllowNegative = False
        Me.TxtPeriod.AllowPerSign = False
        Me.TxtPeriod.AllowPlusSign = False
        Me.TxtPeriod.AllowToolTip = True
        Me.TxtPeriod.DecimalPlaces = CType(3, Short)
        Me.TxtPeriod.ExitOnEscKey = True
        Me.TxtPeriod.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPeriod.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPeriod.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtPeriod.HelpText = Nothing
        Me.TxtPeriod.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPeriod.Location = New System.Drawing.Point(183, 193)
        Me.TxtPeriod.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPeriod.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtPeriod.Max = CType(100000000000000, Long)
        Me.TxtPeriod.MaxLength = 12
        Me.TxtPeriod.Min = CType(0, Long)
        Me.TxtPeriod.Name = "TxtPeriod"
        Me.TxtPeriod.NextOnEnter = True
        Me.TxtPeriod.SetToolTip = Nothing
        Me.TxtPeriod.Size = New System.Drawing.Size(94, 20)
        Me.TxtPeriod.TabIndex = 6
        Me.TxtPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtPeriod.ToolTip = Nothing
        Me.TxtPeriod.UseFunctionKeys = False
        Me.TxtPeriod.UseUpDownArrowKeys = False
        '
        'TxtContractType
        '
        Me.TxtContractType.AllowEmpty = True
        Me.TxtContractType.AllowOnlyListValues = False
        Me.TxtContractType.AllowToolTip = True
        Me.TxtContractType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtContractType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtContractType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtContractType.FormattingEnabled = True
        Me.TxtContractType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtContractType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtContractType.IsAdvanceSearchWindow = False
        Me.TxtContractType.IsAllowDigits = True
        Me.TxtContractType.IsAllowSpace = True
        Me.TxtContractType.IsAllowSplChars = True
        Me.TxtContractType.IsAllowToolTip = True
        Me.TxtContractType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtContractType.Location = New System.Drawing.Point(182, 167)
        Me.TxtContractType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtContractType.Name = "TxtContractType"
        Me.TxtContractType.SetToolTip = Nothing
        Me.TxtContractType.Size = New System.Drawing.Size(282, 21)
        Me.TxtContractType.Sorted = True
        Me.TxtContractType.SpecialCharList = "&-/@"
        Me.TxtContractType.TabIndex = 5
        Me.TxtContractType.UseFunctionKeys = False
        '
        'TxtEmailID
        '
        Me.TxtEmailID.AllowToolTip = True
        Me.TxtEmailID.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtEmailID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtEmailID.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtEmailID.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtEmailID.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtEmailID.IsAllowDigits = True
        Me.TxtEmailID.IsAllowSpace = True
        Me.TxtEmailID.IsAllowSplChars = True
        Me.TxtEmailID.LFocusBackColor = System.Drawing.Color.White
        Me.TxtEmailID.Location = New System.Drawing.Point(183, 144)
        Me.TxtEmailID.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtEmailID.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtEmailID.MaxLength = 150
        Me.TxtEmailID.Name = "TxtEmailID"
        Me.TxtEmailID.SetToolTip = Nothing
        Me.TxtEmailID.Size = New System.Drawing.Size(282, 20)
        Me.TxtEmailID.SpecialCharList = "&-/@"
        Me.TxtEmailID.TabIndex = 4
        Me.TxtEmailID.UseFunctionKeys = False
        '
        'TxtContactPerson
        '
        Me.TxtContactPerson.AllowToolTip = True
        Me.TxtContactPerson.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtContactPerson.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtContactPerson.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtContactPerson.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtContactPerson.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtContactPerson.IsAllowDigits = True
        Me.TxtContactPerson.IsAllowSpace = True
        Me.TxtContactPerson.IsAllowSplChars = True
        Me.TxtContactPerson.LFocusBackColor = System.Drawing.Color.White
        Me.TxtContactPerson.Location = New System.Drawing.Point(183, 221)
        Me.TxtContactPerson.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtContactPerson.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtContactPerson.MaxLength = 70
        Me.TxtContactPerson.Name = "TxtContactPerson"
        Me.TxtContactPerson.SetToolTip = Nothing
        Me.TxtContactPerson.Size = New System.Drawing.Size(282, 20)
        Me.TxtContactPerson.SpecialCharList = "&-/@"
        Me.TxtContactPerson.TabIndex = 7
        Me.TxtContactPerson.UseFunctionKeys = False
        '
        'TxtDesc
        '
        Me.TxtDesc.AllowToolTip = True
        Me.TxtDesc.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtDesc.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDesc.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDesc.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtDesc.IsAllowDigits = True
        Me.TxtDesc.IsAllowSpace = True
        Me.TxtDesc.IsAllowSplChars = True
        Me.TxtDesc.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDesc.Location = New System.Drawing.Point(183, 251)
        Me.TxtDesc.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDesc.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtDesc.MaxLength = 150
        Me.TxtDesc.Multiline = True
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.SetToolTip = Nothing
        Me.TxtDesc.Size = New System.Drawing.Size(282, 54)
        Me.TxtDesc.SpecialCharList = "&-/@"
        Me.TxtDesc.TabIndex = 8
        Me.TxtDesc.UseFunctionKeys = False
        '
        'TxtAddress
        '
        Me.TxtAddress.AllowToolTip = True
        Me.TxtAddress.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtAddress.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtAddress.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtAddress.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtAddress.IsAllowDigits = True
        Me.TxtAddress.IsAllowSpace = True
        Me.TxtAddress.IsAllowSplChars = True
        Me.TxtAddress.LFocusBackColor = System.Drawing.Color.White
        Me.TxtAddress.Location = New System.Drawing.Point(183, 40)
        Me.TxtAddress.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtAddress.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtAddress.MaxLength = 150
        Me.TxtAddress.Multiline = True
        Me.TxtAddress.Name = "TxtAddress"
        Me.TxtAddress.SetToolTip = Nothing
        Me.TxtAddress.Size = New System.Drawing.Size(282, 42)
        Me.TxtAddress.SpecialCharList = "&-/@"
        Me.TxtAddress.TabIndex = 1
        Me.TxtAddress.UseFunctionKeys = False
        '
        'TxtClientName
        '
        Me.TxtClientName.AllowToolTip = True
        Me.TxtClientName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtClientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtClientName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtClientName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtClientName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtClientName.IsAllowDigits = True
        Me.TxtClientName.IsAllowSpace = True
        Me.TxtClientName.IsAllowSplChars = True
        Me.TxtClientName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtClientName.Location = New System.Drawing.Point(183, 12)
        Me.TxtClientName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtClientName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtClientName.MaxLength = 50
        Me.TxtClientName.Name = "TxtClientName"
        Me.TxtClientName.SetToolTip = Nothing
        Me.TxtClientName.Size = New System.Drawing.Size(282, 20)
        Me.TxtClientName.SpecialCharList = "&-/@"
        Me.TxtClientName.TabIndex = 0
        Me.TxtClientName.UseFunctionKeys = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Contact Number2"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 251)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Description"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 224)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Contact Person"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 194)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Period in Months"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 169)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Contract type"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Email ID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Contact Number1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Address"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Client Name"
        '
        'FrmNewClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(493, 437)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmNewClient"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FrmNewClient"
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtStatus As System.Windows.Forms.Label
    Friend WithEvents TxtContactno2 As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtContactno1 As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtPeriod As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtContractType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtEmailID As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtContactPerson As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtDesc As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtAddress As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtClientName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
