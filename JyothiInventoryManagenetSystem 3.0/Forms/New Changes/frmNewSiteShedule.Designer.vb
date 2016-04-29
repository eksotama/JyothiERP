<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewSiteShedule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewSiteShedule))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtIsTransport = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtIsAccom = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.txttotalworkinghours = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtRate = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtRateType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtIsfood = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtWorkType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtSponsorship = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtEmployeeName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtSite = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtClientName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Label2.Size = New System.Drawing.Size(520, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Create New Site Shedule"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtEndDate)
        Me.Panel1.Controls.Add(Me.TxtStartDate)
        Me.Panel1.Controls.Add(Me.TxtIsTransport)
        Me.Panel1.Controls.Add(Me.TxtIsAccom)
        Me.Panel1.Controls.Add(Me.txttotalworkinghours)
        Me.Panel1.Controls.Add(Me.TxtRate)
        Me.Panel1.Controls.Add(Me.TxtRateType)
        Me.Panel1.Controls.Add(Me.TxtIsfood)
        Me.Panel1.Controls.Add(Me.TxtWorkType)
        Me.Panel1.Controls.Add(Me.TxtSponsorship)
        Me.Panel1.Controls.Add(Me.TxtEmployeeName)
        Me.Panel1.Controls.Add(Me.TxtSite)
        Me.Panel1.Controls.Add(Me.TxtClientName)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(514, 372)
        Me.Panel1.TabIndex = 2
        '
        'TxtEndDate
        '
        Me.TxtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEndDate.Location = New System.Drawing.Point(140, 254)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(282, 20)
        Me.TxtEndDate.TabIndex = 10
        '
        'TxtStartDate
        '
        Me.TxtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtStartDate.Location = New System.Drawing.Point(140, 228)
        Me.TxtStartDate.Name = "TxtStartDate"
        Me.TxtStartDate.Size = New System.Drawing.Size(282, 20)
        Me.TxtStartDate.TabIndex = 9
        '
        'TxtIsTransport
        '
        Me.TxtIsTransport.AllowEmpty = True
        Me.TxtIsTransport.AllowOnlyListValues = False
        Me.TxtIsTransport.AllowToolTip = True
        Me.TxtIsTransport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtIsTransport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtIsTransport.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtIsTransport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtIsTransport.FormattingEnabled = True
        Me.TxtIsTransport.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtIsTransport.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtIsTransport.IsAdvanceSearchWindow = False
        Me.TxtIsTransport.IsAllowDigits = True
        Me.TxtIsTransport.IsAllowSpace = True
        Me.TxtIsTransport.IsAllowSplChars = True
        Me.TxtIsTransport.IsAllowToolTip = True
        Me.TxtIsTransport.Items.AddRange(New Object() {"NO", "YES"})
        Me.TxtIsTransport.LFocusBackColor = System.Drawing.Color.White
        Me.TxtIsTransport.Location = New System.Drawing.Point(140, 198)
        Me.TxtIsTransport.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtIsTransport.Name = "TxtIsTransport"
        Me.TxtIsTransport.SetToolTip = Nothing
        Me.TxtIsTransport.Size = New System.Drawing.Size(104, 21)
        Me.TxtIsTransport.Sorted = True
        Me.TxtIsTransport.SpecialCharList = "&-/@"
        Me.TxtIsTransport.TabIndex = 8
        Me.TxtIsTransport.UseFunctionKeys = False
        '
        'TxtIsAccom
        '
        Me.TxtIsAccom.AllowEmpty = True
        Me.TxtIsAccom.AllowOnlyListValues = False
        Me.TxtIsAccom.AllowToolTip = True
        Me.TxtIsAccom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtIsAccom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtIsAccom.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtIsAccom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtIsAccom.FormattingEnabled = True
        Me.TxtIsAccom.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtIsAccom.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtIsAccom.IsAdvanceSearchWindow = False
        Me.TxtIsAccom.IsAllowDigits = True
        Me.TxtIsAccom.IsAllowSpace = True
        Me.TxtIsAccom.IsAllowSplChars = True
        Me.TxtIsAccom.IsAllowToolTip = True
        Me.TxtIsAccom.Items.AddRange(New Object() {"NO", "YES"})
        Me.TxtIsAccom.LFocusBackColor = System.Drawing.Color.White
        Me.TxtIsAccom.Location = New System.Drawing.Point(140, 171)
        Me.TxtIsAccom.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtIsAccom.Name = "TxtIsAccom"
        Me.TxtIsAccom.SetToolTip = Nothing
        Me.TxtIsAccom.Size = New System.Drawing.Size(104, 21)
        Me.TxtIsAccom.Sorted = True
        Me.TxtIsAccom.SpecialCharList = "&-/@"
        Me.TxtIsAccom.TabIndex = 7
        Me.TxtIsAccom.UseFunctionKeys = False
        '
        'txttotalworkinghours
        '
        Me.txttotalworkinghours.AllHelpText = True
        Me.txttotalworkinghours.AllowDecimal = False
        Me.txttotalworkinghours.AllowFormulas = False
        Me.txttotalworkinghours.AllowForQty = True
        Me.txttotalworkinghours.AllowNegative = False
        Me.txttotalworkinghours.AllowPerSign = False
        Me.txttotalworkinghours.AllowPlusSign = False
        Me.txttotalworkinghours.AllowToolTip = True
        Me.txttotalworkinghours.DecimalPlaces = CType(3, Short)
        Me.txttotalworkinghours.ExitOnEscKey = True
        Me.txttotalworkinghours.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txttotalworkinghours.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txttotalworkinghours.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txttotalworkinghours.HelpText = Nothing
        Me.txttotalworkinghours.LFocusBackColor = System.Drawing.Color.White
        Me.txttotalworkinghours.Location = New System.Drawing.Point(139, 280)
        Me.txttotalworkinghours.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txttotalworkinghours.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txttotalworkinghours.Max = CType(100000000000000, Long)
        Me.txttotalworkinghours.MaxLength = 12
        Me.txttotalworkinghours.Min = CType(0, Long)
        Me.txttotalworkinghours.Name = "txttotalworkinghours"
        Me.txttotalworkinghours.NextOnEnter = True
        Me.txttotalworkinghours.SetToolTip = Nothing
        Me.txttotalworkinghours.Size = New System.Drawing.Size(105, 20)
        Me.txttotalworkinghours.TabIndex = 11
        Me.txttotalworkinghours.Text = "0"
        Me.txttotalworkinghours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txttotalworkinghours.ToolTip = Nothing
        Me.txttotalworkinghours.UseFunctionKeys = False
        Me.txttotalworkinghours.UseUpDownArrowKeys = False
        '
        'TxtRate
        '
        Me.TxtRate.AllHelpText = True
        Me.TxtRate.AllowDecimal = False
        Me.TxtRate.AllowFormulas = False
        Me.TxtRate.AllowForQty = True
        Me.TxtRate.AllowNegative = False
        Me.TxtRate.AllowPerSign = False
        Me.TxtRate.AllowPlusSign = False
        Me.TxtRate.AllowToolTip = True
        Me.TxtRate.DecimalPlaces = CType(3, Short)
        Me.TxtRate.ExitOnEscKey = True
        Me.TxtRate.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtRate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtRate.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtRate.HelpText = Nothing
        Me.TxtRate.LFocusBackColor = System.Drawing.Color.White
        Me.TxtRate.Location = New System.Drawing.Point(140, 118)
        Me.TxtRate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtRate.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtRate.Max = CType(100000000000000, Long)
        Me.TxtRate.MaxLength = 12
        Me.TxtRate.Min = CType(0, Long)
        Me.TxtRate.Name = "TxtRate"
        Me.TxtRate.NextOnEnter = True
        Me.TxtRate.SetToolTip = Nothing
        Me.TxtRate.Size = New System.Drawing.Size(105, 20)
        Me.TxtRate.TabIndex = 4
        Me.TxtRate.Text = "0"
        Me.TxtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtRate.ToolTip = Nothing
        Me.TxtRate.UseFunctionKeys = False
        Me.TxtRate.UseUpDownArrowKeys = False
        '
        'TxtRateType
        '
        Me.TxtRateType.AllowEmpty = True
        Me.TxtRateType.AllowOnlyListValues = False
        Me.TxtRateType.AllowToolTip = True
        Me.TxtRateType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtRateType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtRateType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtRateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtRateType.FormattingEnabled = True
        Me.TxtRateType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtRateType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtRateType.IsAdvanceSearchWindow = False
        Me.TxtRateType.IsAllowDigits = True
        Me.TxtRateType.IsAllowSpace = True
        Me.TxtRateType.IsAllowSplChars = True
        Me.TxtRateType.IsAllowToolTip = True
        Me.TxtRateType.Items.AddRange(New Object() {"Daily", "Hourly", "Monthly"})
        Me.TxtRateType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtRateType.Location = New System.Drawing.Point(251, 117)
        Me.TxtRateType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtRateType.Name = "TxtRateType"
        Me.TxtRateType.SetToolTip = Nothing
        Me.TxtRateType.Size = New System.Drawing.Size(104, 21)
        Me.TxtRateType.Sorted = True
        Me.TxtRateType.SpecialCharList = "&-/@"
        Me.TxtRateType.TabIndex = 5
        Me.TxtRateType.UseFunctionKeys = False
        '
        'TxtIsfood
        '
        Me.TxtIsfood.AllowEmpty = True
        Me.TxtIsfood.AllowOnlyListValues = False
        Me.TxtIsfood.AllowToolTip = True
        Me.TxtIsfood.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtIsfood.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtIsfood.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtIsfood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtIsfood.FormattingEnabled = True
        Me.TxtIsfood.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtIsfood.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtIsfood.IsAdvanceSearchWindow = False
        Me.TxtIsfood.IsAllowDigits = True
        Me.TxtIsfood.IsAllowSpace = True
        Me.TxtIsfood.IsAllowSplChars = True
        Me.TxtIsfood.IsAllowToolTip = True
        Me.TxtIsfood.Items.AddRange(New Object() {"NO", "YES"})
        Me.TxtIsfood.LFocusBackColor = System.Drawing.Color.White
        Me.TxtIsfood.Location = New System.Drawing.Point(140, 144)
        Me.TxtIsfood.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtIsfood.Name = "TxtIsfood"
        Me.TxtIsfood.SetToolTip = Nothing
        Me.TxtIsfood.Size = New System.Drawing.Size(104, 21)
        Me.TxtIsfood.Sorted = True
        Me.TxtIsfood.SpecialCharList = "&-/@"
        Me.TxtIsfood.TabIndex = 6
        Me.TxtIsfood.UseFunctionKeys = False
        '
        'TxtWorkType
        '
        Me.TxtWorkType.AllowEmpty = True
        Me.TxtWorkType.AllowOnlyListValues = False
        Me.TxtWorkType.AllowToolTip = True
        Me.TxtWorkType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtWorkType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtWorkType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtWorkType.FormattingEnabled = True
        Me.TxtWorkType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtWorkType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtWorkType.IsAdvanceSearchWindow = False
        Me.TxtWorkType.IsAllowDigits = True
        Me.TxtWorkType.IsAllowSpace = True
        Me.TxtWorkType.IsAllowSplChars = True
        Me.TxtWorkType.IsAllowToolTip = True
        Me.TxtWorkType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtWorkType.Location = New System.Drawing.Point(140, 91)
        Me.TxtWorkType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtWorkType.Name = "TxtWorkType"
        Me.TxtWorkType.SetToolTip = Nothing
        Me.TxtWorkType.Size = New System.Drawing.Size(282, 21)
        Me.TxtWorkType.Sorted = True
        Me.TxtWorkType.SpecialCharList = "&-/@"
        Me.TxtWorkType.TabIndex = 3
        Me.TxtWorkType.UseFunctionKeys = False
        '
        'TxtSponsorship
        '
        Me.TxtSponsorship.AllowEmpty = True
        Me.TxtSponsorship.AllowOnlyListValues = False
        Me.TxtSponsorship.AllowToolTip = True
        Me.TxtSponsorship.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtSponsorship.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtSponsorship.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtSponsorship.FormattingEnabled = True
        Me.TxtSponsorship.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSponsorship.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSponsorship.IsAdvanceSearchWindow = False
        Me.TxtSponsorship.IsAllowDigits = True
        Me.TxtSponsorship.IsAllowSpace = True
        Me.TxtSponsorship.IsAllowSplChars = True
        Me.TxtSponsorship.IsAllowToolTip = True
        Me.TxtSponsorship.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSponsorship.Location = New System.Drawing.Point(139, 306)
        Me.TxtSponsorship.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSponsorship.Name = "TxtSponsorship"
        Me.TxtSponsorship.SetToolTip = Nothing
        Me.TxtSponsorship.Size = New System.Drawing.Size(282, 21)
        Me.TxtSponsorship.Sorted = True
        Me.TxtSponsorship.SpecialCharList = "&-/@"
        Me.TxtSponsorship.TabIndex = 12
        Me.TxtSponsorship.UseFunctionKeys = False
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
        Me.TxtEmployeeName.Location = New System.Drawing.Point(140, 63)
        Me.TxtEmployeeName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtEmployeeName.Name = "TxtEmployeeName"
        Me.TxtEmployeeName.SetToolTip = Nothing
        Me.TxtEmployeeName.Size = New System.Drawing.Size(282, 21)
        Me.TxtEmployeeName.Sorted = True
        Me.TxtEmployeeName.SpecialCharList = "&-/@"
        Me.TxtEmployeeName.TabIndex = 2
        Me.TxtEmployeeName.UseFunctionKeys = False
        '
        'TxtSite
        '
        Me.TxtSite.AllowEmpty = True
        Me.TxtSite.AllowOnlyListValues = True
        Me.TxtSite.AllowToolTip = True
        Me.TxtSite.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtSite.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtSite.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtSite.FormattingEnabled = True
        Me.TxtSite.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSite.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSite.IsAdvanceSearchWindow = False
        Me.TxtSite.IsAllowDigits = True
        Me.TxtSite.IsAllowSpace = True
        Me.TxtSite.IsAllowSplChars = True
        Me.TxtSite.IsAllowToolTip = True
        Me.TxtSite.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSite.Location = New System.Drawing.Point(140, 36)
        Me.TxtSite.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSite.Name = "TxtSite"
        Me.TxtSite.SetToolTip = Nothing
        Me.TxtSite.Size = New System.Drawing.Size(282, 21)
        Me.TxtSite.Sorted = True
        Me.TxtSite.SpecialCharList = "&-/@"
        Me.TxtSite.TabIndex = 1
        Me.TxtSite.UseFunctionKeys = False
        '
        'TxtClientName
        '
        Me.TxtClientName.AllowEmpty = True
        Me.TxtClientName.AllowOnlyListValues = True
        Me.TxtClientName.AllowToolTip = True
        Me.TxtClientName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtClientName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtClientName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtClientName.FormattingEnabled = True
        Me.TxtClientName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtClientName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtClientName.IsAdvanceSearchWindow = False
        Me.TxtClientName.IsAllowDigits = True
        Me.TxtClientName.IsAllowSpace = True
        Me.TxtClientName.IsAllowSplChars = True
        Me.TxtClientName.IsAllowToolTip = True
        Me.TxtClientName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtClientName.Location = New System.Drawing.Point(140, 12)
        Me.TxtClientName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtClientName.Name = "TxtClientName"
        Me.TxtClientName.SetToolTip = Nothing
        Me.TxtClientName.Size = New System.Drawing.Size(282, 21)
        Me.TxtClientName.Sorted = True
        Me.TxtClientName.SpecialCharList = "&-/@"
        Me.TxtClientName.TabIndex = 0
        Me.TxtClientName.UseFunctionKeys = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Food ?"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(32, 283)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Total Working Hours"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(32, 260)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "End Date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(32, 228)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Start Date"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(32, 201)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Transport?"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 171)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Accommodation?"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Rate"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(31, 309)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Sponsorship By"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(32, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Work Type"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(32, 39)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Site Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Employee Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Client Name"
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(520, 492)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'TxtStatus
        '
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Green
        Me.TxtStatus.Location = New System.Drawing.Point(3, 467)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(514, 25)
        Me.TxtStatus.TabIndex = 4
        Me.TxtStatus.Text = "Status: Ready"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnClose)
        Me.Panel2.Controls.Add(Me.BtnCreate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 404)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(514, 60)
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
        Me.BtnCreate.Text = "&Save"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = False
        '
        'frmNewSiteShedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(520, 492)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewSiteShedule"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Site Shedule"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtRate As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtStatus As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtIsTransport As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtIsAccom As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtIsfood As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtWorkType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtEmployeeName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtClientName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txttotalworkinghours As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtRateType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtSponsorship As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtSite As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label

End Class
