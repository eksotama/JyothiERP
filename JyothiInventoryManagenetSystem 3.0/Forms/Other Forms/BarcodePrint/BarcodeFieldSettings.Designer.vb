<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BarcodeFieldSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BarcodeFieldSettings))
        Me.IsShowFiled = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtFLFontColor = New System.Windows.Forms.TextBox()
        Me.TxtFLFontSize = New System.Windows.Forms.TextBox()
        Me.TxtFLBackColor = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.IsCommaSep = New System.Windows.Forms.CheckBox()
        Me.TxtFLStyleU = New System.Windows.Forms.CheckBox()
        Me.TxtFLSytleI = New System.Windows.Forms.CheckBox()
        Me.TxtFLStyleB = New System.Windows.Forms.CheckBox()
        Me.TxtFLSample = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TxtCase = New System.Windows.Forms.ComboBox()
        Me.TxtFLAlign = New System.Windows.Forms.ComboBox()
        Me.TxtFLFont = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TxtBarcodeRotation = New System.Windows.Forms.ComboBox()
        Me.TxtFLHeight = New System.Windows.Forms.NumericUpDown()
        Me.TxtFLWidth = New System.Windows.Forms.NumericUpDown()
        Me.TxtFLtop = New System.Windows.Forms.NumericUpDown()
        Me.TxtFLLeft = New System.Windows.Forms.NumericUpDown()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.lblbarcoderotation = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtFLtext = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtFieldNames = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImsButton5 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton6 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtFont = New System.Windows.Forms.FontDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TxtFLHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFLWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFLtop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFLLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IsShowFiled
        '
        Me.IsShowFiled.AutoSize = True
        Me.IsShowFiled.Location = New System.Drawing.Point(121, 60)
        Me.IsShowFiled.Name = "IsShowFiled"
        Me.IsShowFiled.Size = New System.Drawing.Size(113, 17)
        Me.IsShowFiled.TabIndex = 1
        Me.IsShowFiled.Text = " Show This Object"
        Me.IsShowFiled.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtFLFontColor)
        Me.GroupBox2.Controls.Add(Me.TxtFLFontSize)
        Me.GroupBox2.Controls.Add(Me.TxtFLBackColor)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.IsCommaSep)
        Me.GroupBox2.Controls.Add(Me.TxtFLStyleU)
        Me.GroupBox2.Controls.Add(Me.TxtFLSytleI)
        Me.GroupBox2.Controls.Add(Me.TxtFLStyleB)
        Me.GroupBox2.Controls.Add(Me.TxtFLSample)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.TxtCase)
        Me.GroupBox2.Controls.Add(Me.TxtFLAlign)
        Me.GroupBox2.Controls.Add(Me.TxtFLFont)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(25, 195)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(412, 223)
        Me.GroupBox2.TabIndex = 49
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Label Settings"
        '
        'TxtFLFontColor
        '
        Me.TxtFLFontColor.Location = New System.Drawing.Point(84, 117)
        Me.TxtFLFontColor.Name = "TxtFLFontColor"
        Me.TxtFLFontColor.ReadOnly = True
        Me.TxtFLFontColor.Size = New System.Drawing.Size(72, 20)
        Me.TxtFLFontColor.TabIndex = 8
        '
        'TxtFLFontSize
        '
        Me.TxtFLFontSize.Location = New System.Drawing.Point(84, 86)
        Me.TxtFLFontSize.Name = "TxtFLFontSize"
        Me.TxtFLFontSize.ReadOnly = True
        Me.TxtFLFontSize.Size = New System.Drawing.Size(72, 20)
        Me.TxtFLFontSize.TabIndex = 8
        Me.TxtFLFontSize.Text = "8"
        '
        'TxtFLBackColor
        '
        Me.TxtFLBackColor.Location = New System.Drawing.Point(224, 115)
        Me.TxtFLBackColor.Name = "TxtFLBackColor"
        Me.TxtFLBackColor.ReadOnly = True
        Me.TxtFLBackColor.Size = New System.Drawing.Size(87, 20)
        Me.TxtFLBackColor.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(330, 114)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Select Color"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(263, 15)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(97, 23)
        Me.Button4.TabIndex = 1
        Me.Button4.Text = "Set Font"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'IsCommaSep
        '
        Me.IsCommaSep.AutoSize = True
        Me.IsCommaSep.Location = New System.Drawing.Point(84, 63)
        Me.IsCommaSep.Name = "IsCommaSep"
        Me.IsCommaSep.Size = New System.Drawing.Size(171, 17)
        Me.IsCommaSep.TabIndex = 4
        Me.IsCommaSep.Text = "Comma Separator for Number?"
        Me.IsCommaSep.UseVisualStyleBackColor = True
        '
        'TxtFLStyleU
        '
        Me.TxtFLStyleU.AutoSize = True
        Me.TxtFLStyleU.Enabled = False
        Me.TxtFLStyleU.Location = New System.Drawing.Point(201, 40)
        Me.TxtFLStyleU.Name = "TxtFLStyleU"
        Me.TxtFLStyleU.Size = New System.Drawing.Size(75, 17)
        Me.TxtFLStyleU.TabIndex = 4
        Me.TxtFLStyleU.Text = "&UnderLine"
        Me.TxtFLStyleU.UseVisualStyleBackColor = True
        '
        'TxtFLSytleI
        '
        Me.TxtFLSytleI.AutoSize = True
        Me.TxtFLSytleI.Enabled = False
        Me.TxtFLSytleI.Location = New System.Drawing.Point(140, 40)
        Me.TxtFLSytleI.Name = "TxtFLSytleI"
        Me.TxtFLSytleI.Size = New System.Drawing.Size(48, 17)
        Me.TxtFLSytleI.TabIndex = 3
        Me.TxtFLSytleI.Text = "&Italic"
        Me.TxtFLSytleI.UseVisualStyleBackColor = True
        '
        'TxtFLStyleB
        '
        Me.TxtFLStyleB.AutoSize = True
        Me.TxtFLStyleB.Enabled = False
        Me.TxtFLStyleB.Location = New System.Drawing.Point(84, 40)
        Me.TxtFLStyleB.Name = "TxtFLStyleB"
        Me.TxtFLStyleB.Size = New System.Drawing.Size(47, 17)
        Me.TxtFLStyleB.TabIndex = 2
        Me.TxtFLStyleB.Text = "&Bold"
        Me.TxtFLStyleB.UseVisualStyleBackColor = True
        '
        'TxtFLSample
        '
        Me.TxtFLSample.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtFLSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFLSample.Location = New System.Drawing.Point(84, 173)
        Me.TxtFLSample.Name = "TxtFLSample"
        Me.TxtFLSample.Size = New System.Drawing.Size(254, 33)
        Me.TxtFLSample.TabIndex = 3
        Me.TxtFLSample.Text = "sample"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(162, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Case"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(15, 149)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Alignment:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(15, 173)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(45, 13)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Preview"
        '
        'TxtCase
        '
        Me.TxtCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtCase.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtCase.FormattingEnabled = True
        Me.TxtCase.Items.AddRange(New Object() {"UPPERCASE", "lowercase", "None", "Title Case"})
        Me.TxtCase.Location = New System.Drawing.Point(224, 146)
        Me.TxtCase.Name = "TxtCase"
        Me.TxtCase.Size = New System.Drawing.Size(87, 21)
        Me.TxtCase.TabIndex = 2
        '
        'TxtFLAlign
        '
        Me.TxtFLAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtFLAlign.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtFLAlign.FormattingEnabled = True
        Me.TxtFLAlign.Items.AddRange(New Object() {"Left", "Right", "Centre"})
        Me.TxtFLAlign.Location = New System.Drawing.Point(84, 146)
        Me.TxtFLAlign.Name = "TxtFLAlign"
        Me.TxtFLAlign.Size = New System.Drawing.Size(74, 21)
        Me.TxtFLAlign.TabIndex = 2
        '
        'TxtFLFont
        '
        Me.TxtFLFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.TxtFLFont.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtFLFont.FormattingEnabled = True
        Me.TxtFLFont.Location = New System.Drawing.Point(84, 15)
        Me.TxtFLFont.Name = "TxtFLFont"
        Me.TxtFLFont.Size = New System.Drawing.Size(173, 23)
        Me.TxtFLFont.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(159, 119)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Back Color"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(15, 120)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(55, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Font Color"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(15, 40)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(57, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Font Style:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(15, 89)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(54, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Font Size:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(15, 18)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(31, 13)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Font:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TxtBarcodeRotation)
        Me.GroupBox3.Controls.Add(Me.TxtFLHeight)
        Me.GroupBox3.Controls.Add(Me.TxtFLWidth)
        Me.GroupBox3.Controls.Add(Me.TxtFLtop)
        Me.GroupBox3.Controls.Add(Me.TxtFLLeft)
        Me.GroupBox3.Controls.Add(Me.Label33)
        Me.GroupBox3.Controls.Add(Me.Label56)
        Me.GroupBox3.Controls.Add(Me.Label57)
        Me.GroupBox3.Controls.Add(Me.Label58)
        Me.GroupBox3.Controls.Add(Me.lblbarcoderotation)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.txtFLtext)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(25, 84)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(412, 105)
        Me.GroupBox3.TabIndex = 48
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Lable Title/Caption/Text"
        '
        'TxtBarcodeRotation
        '
        Me.TxtBarcodeRotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtBarcodeRotation.FormattingEnabled = True
        Me.TxtBarcodeRotation.Location = New System.Drawing.Point(117, 71)
        Me.TxtBarcodeRotation.Name = "TxtBarcodeRotation"
        Me.TxtBarcodeRotation.Size = New System.Drawing.Size(185, 21)
        Me.TxtBarcodeRotation.TabIndex = 6
        '
        'TxtFLHeight
        '
        Me.TxtFLHeight.DecimalPlaces = 2
        Me.TxtFLHeight.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.TxtFLHeight.Location = New System.Drawing.Point(316, 39)
        Me.TxtFLHeight.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        Me.TxtFLHeight.Name = "TxtFLHeight"
        Me.TxtFLHeight.Size = New System.Drawing.Size(59, 20)
        Me.TxtFLHeight.TabIndex = 3
        Me.TxtFLHeight.Value = New Decimal(New Integer() {600, 0, 0, 0})
        '
        'TxtFLWidth
        '
        Me.TxtFLWidth.DecimalPlaces = 2
        Me.TxtFLWidth.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.TxtFLWidth.Location = New System.Drawing.Point(316, 13)
        Me.TxtFLWidth.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        Me.TxtFLWidth.Name = "TxtFLWidth"
        Me.TxtFLWidth.Size = New System.Drawing.Size(59, 20)
        Me.TxtFLWidth.TabIndex = 1
        Me.TxtFLWidth.Value = New Decimal(New Integer() {600, 0, 0, 0})
        '
        'TxtFLtop
        '
        Me.TxtFLtop.DecimalPlaces = 2
        Me.TxtFLtop.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.TxtFLtop.Location = New System.Drawing.Point(195, 39)
        Me.TxtFLtop.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        Me.TxtFLtop.Name = "TxtFLtop"
        Me.TxtFLtop.Size = New System.Drawing.Size(60, 20)
        Me.TxtFLtop.TabIndex = 2
        Me.TxtFLtop.Value = New Decimal(New Integer() {600, 0, 0, 0})
        '
        'TxtFLLeft
        '
        Me.TxtFLLeft.DecimalPlaces = 2
        Me.TxtFLLeft.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.TxtFLLeft.Location = New System.Drawing.Point(195, 13)
        Me.TxtFLLeft.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        Me.TxtFLLeft.Name = "TxtFLLeft"
        Me.TxtFLLeft.Size = New System.Drawing.Size(60, 20)
        Me.TxtFLLeft.TabIndex = 0
        Me.TxtFLLeft.Value = New Decimal(New Integer() {600, 0, 0, 0})
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(267, 39)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(38, 13)
        Me.Label33.TabIndex = 3
        Me.Label33.Text = "&Height"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(150, 39)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(26, 13)
        Me.Label56.TabIndex = 2
        Me.Label56.Text = "&Top"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(267, 15)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(35, 13)
        Me.Label57.TabIndex = 4
        Me.Label57.Text = "&Width"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(150, 15)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(28, 13)
        Me.Label58.TabIndex = 5
        Me.Label58.Text = "&Left:"
        '
        'lblbarcoderotation
        '
        Me.lblbarcoderotation.AutoSize = True
        Me.lblbarcoderotation.Location = New System.Drawing.Point(15, 75)
        Me.lblbarcoderotation.Name = "lblbarcoderotation"
        Me.lblbarcoderotation.Size = New System.Drawing.Size(93, 13)
        Me.lblbarcoderotation.TabIndex = 0
        Me.lblbarcoderotation.Text = "Barcode Rotation "
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(9, 15)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 13)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Label to Print:"
        '
        'txtFLtext
        '
        Me.txtFLtext.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txtFLtext.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtFLtext.FormattingEnabled = True
        Me.txtFLtext.Location = New System.Drawing.Point(12, 31)
        Me.txtFLtext.Name = "txtFLtext"
        Me.txtFLtext.Size = New System.Drawing.Size(132, 20)
        Me.txtFLtext.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(22, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 13)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "Select Field Name"
        '
        'TxtFieldNames
        '
        Me.TxtFieldNames.AllowEmpty = False
        Me.TxtFieldNames.AllowOnlyListValues = True
        Me.TxtFieldNames.AllowToolTip = True
        Me.TxtFieldNames.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtFieldNames.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtFieldNames.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtFieldNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtFieldNames.FormattingEnabled = True
        Me.TxtFieldNames.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtFieldNames.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtFieldNames.IsAdvanceSearchWindow = False
        Me.TxtFieldNames.IsAllowDigits = True
        Me.TxtFieldNames.IsAllowSpace = True
        Me.TxtFieldNames.IsAllowSplChars = True
        Me.TxtFieldNames.IsAllowToolTip = True
        Me.TxtFieldNames.Items.AddRange(New Object() {"Barcode", "BarcodeText", "CompanyName", "ItemName", "MRP", "Price"})
        Me.TxtFieldNames.LFocusBackColor = System.Drawing.Color.White
        Me.TxtFieldNames.Location = New System.Drawing.Point(121, 33)
        Me.TxtFieldNames.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtFieldNames.Name = "TxtFieldNames"
        Me.TxtFieldNames.SetToolTip = Nothing
        Me.TxtFieldNames.Size = New System.Drawing.Size(202, 21)
        Me.TxtFieldNames.Sorted = True
        Me.TxtFieldNames.SpecialCharList = "&-/@"
        Me.TxtFieldNames.TabIndex = 0
        Me.TxtFieldNames.UseFunctionKeys = False
        '
        'ImsButton5
        '
        Me.ImsButton5.AllowToolTip = True
        Me.ImsButton5.BackColor = System.Drawing.Color.White
        Me.ImsButton5.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton5.Image = CType(resources.GetObject("ImsButton5.Image"), System.Drawing.Image)
        Me.ImsButton5.Location = New System.Drawing.Point(64, 422)
        Me.ImsButton5.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton5.Name = "ImsButton5"
        Me.ImsButton5.SetToolTip = ""
        Me.ImsButton5.Size = New System.Drawing.Size(140, 41)
        Me.ImsButton5.TabIndex = 3
        Me.ImsButton5.Text = "Close"
        Me.ImsButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton5.UseFunctionKeys = False
        Me.ImsButton5.UseVisualStyleBackColor = False
        '
        'ImsButton6
        '
        Me.ImsButton6.AllowToolTip = True
        Me.ImsButton6.BackColor = System.Drawing.Color.White
        Me.ImsButton6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ImsButton6.ForeColor = System.Drawing.Color.Blue
        Me.ImsButton6.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton6.Image = CType(resources.GetObject("ImsButton6.Image"), System.Drawing.Image)
        Me.ImsButton6.Location = New System.Drawing.Point(245, 422)
        Me.ImsButton6.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton6.Name = "ImsButton6"
        Me.ImsButton6.SetToolTip = ""
        Me.ImsButton6.Size = New System.Drawing.Size(140, 41)
        Me.ImsButton6.TabIndex = 2
        Me.ImsButton6.Text = "Save"
        Me.ImsButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton6.UseFunctionKeys = False
        Me.ImsButton6.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtFont
        '
        Me.txtFont.Color = System.Drawing.SystemColors.ControlText
        Me.txtFont.ShowColor = True
        Me.txtFont.ShowHelp = True
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
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(454, 25)
        Me.ImsHeadingLabel1.TabIndex = 51
        Me.ImsHeadingLabel1.Text = "BARCODE FILED SETTINGS"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BarcodeFieldSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(454, 471)
        Me.Controls.Add(Me.ImsHeadingLabel1)
        Me.Controls.Add(Me.IsShowFiled)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtFieldNames)
        Me.Controls.Add(Me.ImsButton5)
        Me.Controls.Add(Me.ImsButton6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BarcodeFieldSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "BarcodeFieldSettings"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.TxtFLHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFLWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFLtop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFLLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents IsShowFiled As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtFLFontColor As System.Windows.Forms.TextBox
    Friend WithEvents TxtFLFontSize As System.Windows.Forms.TextBox
    Friend WithEvents TxtFLBackColor As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TxtFLStyleU As System.Windows.Forms.CheckBox
    Friend WithEvents TxtFLSytleI As System.Windows.Forms.CheckBox
    Friend WithEvents TxtFLStyleB As System.Windows.Forms.CheckBox
    Friend WithEvents TxtFLSample As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TxtFLAlign As System.Windows.Forms.ComboBox
    Friend WithEvents TxtFLFont As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtFLHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtFLWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtFLtop As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtFLLeft As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtFLtext As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtFieldNames As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImsButton5 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton6 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtFont As System.Windows.Forms.FontDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCase As System.Windows.Forms.ComboBox
    Friend WithEvents lblbarcoderotation As System.Windows.Forms.Label
    Friend WithEvents TxtBarcodeRotation As System.Windows.Forms.ComboBox
    Friend WithEvents IsCommaSep As System.Windows.Forms.CheckBox

End Class
