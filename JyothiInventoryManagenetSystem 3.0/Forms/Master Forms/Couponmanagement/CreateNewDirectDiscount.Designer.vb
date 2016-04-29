<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateNewDirectDiscount
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateNewDirectDiscount))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtValueType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtDateTo = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtDateFrom = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtPer = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtDisName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.STSNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stitemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stItemSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stDis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnsearchbyitem = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnAddGroup = New JyothiPharmaERPSystem3.IMSButton()
        Me.btnAddCat = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtLocation = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtStockCat = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtStockGroup = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(863, 26)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "CREATE NEW DIRECT ITEM WISE DISCOUNT"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TxtStatus
        '
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Green
        Me.TxtStatus.Location = New System.Drawing.Point(3, 602)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(857, 20)
        Me.TxtStatus.TabIndex = 0
        Me.TxtStatus.Text = "Status: Ready"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnCreate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 549)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(857, 50)
        Me.Panel1.TabIndex = 1
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(154, 4)
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
        Me.BtnCreate.Location = New System.Drawing.Point(425, 5)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(175, 43)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "&Save"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtStatus, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtList, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(863, 622)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtValueType)
        Me.Panel2.Controls.Add(Me.TxtDateTo)
        Me.Panel2.Controls.Add(Me.TxtDateFrom)
        Me.Panel2.Controls.Add(Me.TxtPer)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.TxtDisName)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(857, 74)
        Me.Panel2.TabIndex = 0
        '
        'TxtValueType
        '
        Me.TxtValueType.AllowEmpty = True
        Me.TxtValueType.AllowOnlyListValues = False
        Me.TxtValueType.AllowToolTip = True
        Me.TxtValueType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtValueType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtValueType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtValueType.FormattingEnabled = True
        Me.TxtValueType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtValueType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtValueType.IsAdvanceSearchWindow = False
        Me.TxtValueType.IsAllowDigits = True
        Me.TxtValueType.IsAllowSpace = True
        Me.TxtValueType.IsAllowSplChars = True
        Me.TxtValueType.IsAllowToolTip = True
        Me.TxtValueType.Items.AddRange(New Object() {"PERCENTAGE", "VALUE"})
        Me.TxtValueType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtValueType.Location = New System.Drawing.Point(254, 41)
        Me.TxtValueType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtValueType.Name = "TxtValueType"
        Me.TxtValueType.SetToolTip = Nothing
        Me.TxtValueType.Size = New System.Drawing.Size(104, 21)
        Me.TxtValueType.Sorted = True
        Me.TxtValueType.SpecialCharList = "&-/@"
        Me.TxtValueType.TabIndex = 2
        Me.TxtValueType.UseFunctionKeys = False
        '
        'TxtDateTo
        '
        Me.TxtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtDateTo.Location = New System.Drawing.Point(507, 41)
        Me.TxtDateTo.Name = "TxtDateTo"
        Me.TxtDateTo.Size = New System.Drawing.Size(144, 20)
        Me.TxtDateTo.TabIndex = 5
        '
        'TxtDateFrom
        '
        Me.TxtDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtDateFrom.Location = New System.Drawing.Point(507, 13)
        Me.TxtDateFrom.Name = "TxtDateFrom"
        Me.TxtDateFrom.Size = New System.Drawing.Size(144, 20)
        Me.TxtDateFrom.TabIndex = 4
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
        Me.TxtPer.DecimalPlaces = CType(6, Short)
        Me.TxtPer.ExitOnEscKey = True
        Me.TxtPer.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPer.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPer.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtPer.HelpText = Nothing
        Me.TxtPer.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPer.Location = New System.Drawing.Point(154, 41)
        Me.TxtPer.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPer.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtPer.Max = CType(50, Long)
        Me.TxtPer.MaxLength = 5
        Me.TxtPer.Min = CType(0, Long)
        Me.TxtPer.Name = "TxtPer"
        Me.TxtPer.NextOnEnter = True
        Me.TxtPer.SetToolTip = Nothing
        Me.TxtPer.Size = New System.Drawing.Size(94, 20)
        Me.TxtPer.TabIndex = 1
        Me.TxtPer.Text = "1"
        Me.TxtPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtPer.ToolTip = Nothing
        Me.TxtPer.UseFunctionKeys = False
        Me.TxtPer.UseUpDownArrowKeys = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(391, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Period To"
        '
        'TxtDisName
        '
        Me.TxtDisName.AllowToolTip = True
        Me.TxtDisName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtDisName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtDisName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDisName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDisName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtDisName.IsAllowDigits = True
        Me.TxtDisName.IsAllowSpace = True
        Me.TxtDisName.IsAllowSplChars = True
        Me.TxtDisName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDisName.Location = New System.Drawing.Point(154, 13)
        Me.TxtDisName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDisName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtDisName.MaxLength = 45
        Me.TxtDisName.Name = "TxtDisName"
        Me.TxtDisName.SetToolTip = Nothing
        Me.TxtDisName.Size = New System.Drawing.Size(221, 20)
        Me.TxtDisName.SpecialCharList = "&-/@()_"
        Me.TxtDisName.TabIndex = 0
        Me.TxtDisName.UseFunctionKeys = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(391, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Period From"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Discount Name/Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Percentage"
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.STSNO, Me.stitemID, Me.StLocation, Me.StItemCode, Me.stItemSize, Me.stDis})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtList.DefaultCellStyle = DataGridViewCellStyle2
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.Location = New System.Drawing.Point(3, 175)
        Me.TxtList.Name = "TxtList"
        Me.TxtList.Size = New System.Drawing.Size(857, 368)
        Me.TxtList.TabIndex = 3
        '
        'STSNO
        '
        Me.STSNO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.STSNO.HeaderText = "Sno"
        Me.STSNO.Name = "STSNO"
        Me.STSNO.ReadOnly = True
        Me.STSNO.Width = 50
        '
        'stitemID
        '
        Me.stitemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.stitemID.HeaderText = "ItemID"
        Me.stitemID.Name = "stitemID"
        Me.stitemID.ReadOnly = True
        '
        'StLocation
        '
        Me.StLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.StLocation.HeaderText = "Location"
        Me.StLocation.Name = "StLocation"
        Me.StLocation.ReadOnly = True
        Me.StLocation.Width = 150
        '
        'StItemCode
        '
        Me.StItemCode.HeaderText = "ItemCode"
        Me.StItemCode.Name = "StItemCode"
        Me.StItemCode.ReadOnly = True
        '
        'stItemSize
        '
        Me.stItemSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.stItemSize.HeaderText = "ItemSize"
        Me.stItemSize.Name = "stItemSize"
        Me.stItemSize.ReadOnly = True
        Me.stItemSize.Width = 131
        '
        'stDis
        '
        Me.stDis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.stDis.HeaderText = "Discount"
        Me.stDis.Name = "stDis"
        Me.stDis.Width = 150
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnsearchbyitem)
        Me.Panel3.Controls.Add(Me.BtnAddGroup)
        Me.Panel3.Controls.Add(Me.btnAddCat)
        Me.Panel3.Controls.Add(Me.TxtLocation)
        Me.Panel3.Controls.Add(Me.TxtStockCat)
        Me.Panel3.Controls.Add(Me.TxtStockGroup)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 106)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(863, 66)
        Me.Panel3.TabIndex = 4
        '
        'btnsearchbyitem
        '
        Me.btnsearchbyitem.AllowToolTip = True
        Me.btnsearchbyitem.BackColor = System.Drawing.Color.White
        Me.btnsearchbyitem.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnsearchbyitem.Image = CType(resources.GetObject("btnsearchbyitem.Image"), System.Drawing.Image)
        Me.btnsearchbyitem.Location = New System.Drawing.Point(643, 7)
        Me.btnsearchbyitem.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnsearchbyitem.Name = "btnsearchbyitem"
        Me.btnsearchbyitem.SetToolTip = ""
        Me.btnsearchbyitem.Size = New System.Drawing.Size(208, 49)
        Me.btnsearchbyitem.TabIndex = 5
        Me.btnsearchbyitem.Text = "Search By Item Code"
        Me.btnsearchbyitem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnsearchbyitem.UseFunctionKeys = False
        Me.btnsearchbyitem.UseVisualStyleBackColor = False
        '
        'BtnAddGroup
        '
        Me.BtnAddGroup.AllowToolTip = True
        Me.BtnAddGroup.BackColor = System.Drawing.Color.White
        Me.BtnAddGroup.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnAddGroup.Image = CType(resources.GetObject("BtnAddGroup.Image"), System.Drawing.Image)
        Me.BtnAddGroup.Location = New System.Drawing.Point(532, 14)
        Me.BtnAddGroup.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnAddGroup.Name = "BtnAddGroup"
        Me.BtnAddGroup.SetToolTip = ""
        Me.BtnAddGroup.Size = New System.Drawing.Size(61, 27)
        Me.BtnAddGroup.TabIndex = 4
        Me.BtnAddGroup.Text = "ADD"
        Me.BtnAddGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAddGroup.UseFunctionKeys = False
        Me.BtnAddGroup.UseVisualStyleBackColor = False
        '
        'btnAddCat
        '
        Me.btnAddCat.AllowToolTip = True
        Me.btnAddCat.BackColor = System.Drawing.Color.White
        Me.btnAddCat.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnAddCat.Image = CType(resources.GetObject("btnAddCat.Image"), System.Drawing.Image)
        Me.btnAddCat.Location = New System.Drawing.Point(292, 14)
        Me.btnAddCat.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnAddCat.Name = "btnAddCat"
        Me.btnAddCat.SetToolTip = ""
        Me.btnAddCat.Size = New System.Drawing.Size(61, 27)
        Me.btnAddCat.TabIndex = 4
        Me.btnAddCat.Text = "ADD"
        Me.btnAddCat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAddCat.UseFunctionKeys = False
        Me.btnAddCat.UseVisualStyleBackColor = False
        '
        'TxtLocation
        '
        Me.TxtLocation.AllowEmpty = True
        Me.TxtLocation.AllowOnlyListValues = True
        Me.TxtLocation.AllowToolTip = True
        Me.TxtLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtLocation.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtLocation.FormattingEnabled = True
        Me.TxtLocation.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLocation.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLocation.IsAdvanceSearchWindow = False
        Me.TxtLocation.IsAllowDigits = True
        Me.TxtLocation.IsAllowSpace = True
        Me.TxtLocation.IsAllowSplChars = True
        Me.TxtLocation.IsAllowToolTip = True
        Me.TxtLocation.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLocation.Location = New System.Drawing.Point(6, 18)
        Me.TxtLocation.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLocation.Name = "TxtLocation"
        Me.TxtLocation.SetToolTip = Nothing
        Me.TxtLocation.Size = New System.Drawing.Size(128, 21)
        Me.TxtLocation.Sorted = True
        Me.TxtLocation.SpecialCharList = "&-/@"
        Me.TxtLocation.TabIndex = 1
        Me.TxtLocation.UseFunctionKeys = False
        '
        'TxtStockCat
        '
        Me.TxtStockCat.AllowEmpty = True
        Me.TxtStockCat.AllowOnlyListValues = True
        Me.TxtStockCat.AllowToolTip = True
        Me.TxtStockCat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtStockCat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtStockCat.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtStockCat.FormattingEnabled = True
        Me.TxtStockCat.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockCat.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockCat.IsAdvanceSearchWindow = False
        Me.TxtStockCat.IsAllowDigits = True
        Me.TxtStockCat.IsAllowSpace = True
        Me.TxtStockCat.IsAllowSplChars = True
        Me.TxtStockCat.IsAllowToolTip = True
        Me.TxtStockCat.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockCat.Location = New System.Drawing.Point(156, 18)
        Me.TxtStockCat.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockCat.Name = "TxtStockCat"
        Me.TxtStockCat.SetToolTip = Nothing
        Me.TxtStockCat.Size = New System.Drawing.Size(135, 21)
        Me.TxtStockCat.Sorted = True
        Me.TxtStockCat.SpecialCharList = "&-/@"
        Me.TxtStockCat.TabIndex = 1
        Me.TxtStockCat.UseFunctionKeys = False
        '
        'TxtStockGroup
        '
        Me.TxtStockGroup.AllowEmpty = True
        Me.TxtStockGroup.AllowOnlyListValues = True
        Me.TxtStockGroup.AllowToolTip = True
        Me.TxtStockGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtStockGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtStockGroup.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtStockGroup.FormattingEnabled = True
        Me.TxtStockGroup.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockGroup.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockGroup.IsAdvanceSearchWindow = False
        Me.TxtStockGroup.IsAllowDigits = True
        Me.TxtStockGroup.IsAllowSpace = True
        Me.TxtStockGroup.IsAllowSplChars = True
        Me.TxtStockGroup.IsAllowToolTip = True
        Me.TxtStockGroup.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockGroup.Location = New System.Drawing.Point(372, 18)
        Me.TxtStockGroup.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockGroup.Name = "TxtStockGroup"
        Me.TxtStockGroup.SetToolTip = Nothing
        Me.TxtStockGroup.Size = New System.Drawing.Size(160, 21)
        Me.TxtStockGroup.Sorted = True
        Me.TxtStockGroup.SpecialCharList = "&-/@"
        Me.TxtStockGroup.TabIndex = 1
        Me.TxtStockGroup.UseFunctionKeys = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "For Location/Store"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(153, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "By Stock Category"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(375, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "By Stock Group"
        '
        'CreateNewDirectDiscount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(863, 622)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CreateNewDirectDiscount"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CreateNewDirectDiscount"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtStatus As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtValueType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtDateTo As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtDateFrom As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtPer As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtDisName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TxtLocation As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtStockCat As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtStockGroup As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnAddGroup As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents btnAddCat As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents btnsearchbyitem As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents STSNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stitemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stItemSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stDis As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
