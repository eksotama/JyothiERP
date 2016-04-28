<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserLogInfo
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserLogInfo))
        Me.ReloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DELETEaLLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnDelete = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton4 = New JyothiPharmaERPSystem3.IMSButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtUserName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.UserButton2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtIsPeriod = New System.Windows.Forms.CheckBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReloadToolStripMenuItem
        '
        Me.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem"
        Me.ReloadToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.ReloadToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.ReloadToolStripMenuItem.Text = "Reload "
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.CloseToolStripMenuItem.Text = "close"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.PrintToolStripMenuItem.Text = "print"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        Me.EditToolStripMenuItem.Visible = False
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.PrintToolStripMenuItem, Me.CloseToolStripMenuItem, Me.ReloadToolStripMenuItem, Me.DELETEaLLToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        Me.MenuToolStripMenuItem.Visible = False
        '
        'DELETEaLLToolStripMenuItem
        '
        Me.DELETEaLLToolStripMenuItem.Name = "DELETEaLLToolStripMenuItem"
        Me.DELETEaLLToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.DELETEaLLToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.DELETEaLLToolStripMenuItem.Text = "dELETEaLL"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkOrange
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(912, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "USER LOG FILE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TxtList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtList.DefaultCellStyle = DataGridViewCellStyle6
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.Location = New System.Drawing.Point(3, 83)
        Me.TxtList.Name = "TxtList"
        Me.TxtList.ReadOnly = True
        Me.TxtList.RowHeadersWidth = 30
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(906, 323)
        Me.TxtList.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 9
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.60563!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.859157!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.60564!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.859157!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.60564!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.859157!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.60564!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton2, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnDelete, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton4, 3, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 412)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(906, 56)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.BackColor = System.Drawing.Color.White
        Me.ImsButton1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton1.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = CType(resources.GetObject("ImsButton1.Image"), System.Drawing.Image)
        Me.ImsButton1.Location = New System.Drawing.Point(23, 3)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(141, 50)
        Me.ImsButton1.TabIndex = 0
        Me.ImsButton1.Text = "CLOSE"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = False
        '
        'ImsButton2
        '
        Me.ImsButton2.AllowToolTip = True
        Me.ImsButton2.BackColor = System.Drawing.Color.White
        Me.ImsButton2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton2.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton2.Image = CType(resources.GetObject("ImsButton2.Image"), System.Drawing.Image)
        Me.ImsButton2.Location = New System.Drawing.Point(481, 3)
        Me.ImsButton2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton2.Name = "ImsButton2"
        Me.ImsButton2.SetToolTip = ""
        Me.ImsButton2.Size = New System.Drawing.Size(141, 50)
        Me.ImsButton2.TabIndex = 0
        Me.ImsButton2.Text = "DELETE SELECTED"
        Me.ImsButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton2.UseFunctionKeys = False
        Me.ImsButton2.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.AllowToolTip = True
        Me.BtnDelete.BackColor = System.Drawing.Color.White
        Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.Navy
        Me.BtnDelete.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
        Me.BtnDelete.Location = New System.Drawing.Point(710, 3)
        Me.BtnDelete.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.SetToolTip = ""
        Me.BtnDelete.Size = New System.Drawing.Size(141, 50)
        Me.BtnDelete.TabIndex = 0
        Me.BtnDelete.Text = "DELETE LIST"
        Me.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDelete.UseFunctionKeys = False
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'ImsButton4
        '
        Me.ImsButton4.AllowToolTip = True
        Me.ImsButton4.BackColor = System.Drawing.Color.White
        Me.ImsButton4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton4.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton4.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton4.Image = CType(resources.GetObject("ImsButton4.Image"), System.Drawing.Image)
        Me.ImsButton4.Location = New System.Drawing.Point(252, 3)
        Me.ImsButton4.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton4.Name = "ImsButton4"
        Me.ImsButton4.SetToolTip = ""
        Me.ImsButton4.Size = New System.Drawing.Size(141, 50)
        Me.ImsButton4.TabIndex = 0
        Me.ImsButton4.Text = "PRINT"
        Me.ImsButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton4.UseFunctionKeys = False
        Me.ImsButton4.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(639, 13)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(202, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtList, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.982543!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.71394!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.44009!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(912, 471)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtUserName)
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Controls.Add(Me.UserButton2)
        Me.Panel1.Controls.Add(Me.TxtEndDate)
        Me.Panel1.Controls.Add(Me.TxtStartDate)
        Me.Panel1.Controls.Add(Me.TxtIsPeriod)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 28)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(912, 52)
        Me.Panel1.TabIndex = 3
        '
        'TxtUserName
        '
        Me.TxtUserName.AllowEmpty = True
        Me.TxtUserName.AllowOnlyListValues = False
        Me.TxtUserName.AllowToolTip = True
        Me.TxtUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtUserName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtUserName.FormattingEnabled = True
        Me.TxtUserName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtUserName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtUserName.IsAdvanceSearchWindow = False
        Me.TxtUserName.IsAllowDigits = True
        Me.TxtUserName.IsAllowSpace = True
        Me.TxtUserName.IsAllowSplChars = True
        Me.TxtUserName.IsAllowToolTip = True
        Me.TxtUserName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtUserName.Location = New System.Drawing.Point(12, 23)
        Me.TxtUserName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtUserName.Name = "TxtUserName"
        Me.TxtUserName.SetToolTip = Nothing
        Me.TxtUserName.Size = New System.Drawing.Size(275, 21)
        Me.TxtUserName.Sorted = True
        Me.TxtUserName.SpecialCharList = "&-/@"
        Me.TxtUserName.TabIndex = 48
        Me.TxtUserName.UseFunctionKeys = False
        '
        'UserButton2
        '
        Me.UserButton2.AllowToolTip = True
        Me.UserButton2.BackColor = System.Drawing.Color.White
        Me.UserButton2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.UserButton2.Image = CType(resources.GetObject("UserButton2.Image"), System.Drawing.Image)
        Me.UserButton2.Location = New System.Drawing.Point(702, 13)
        Me.UserButton2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.UserButton2.Name = "UserButton2"
        Me.UserButton2.SetToolTip = ""
        Me.UserButton2.Size = New System.Drawing.Size(87, 34)
        Me.UserButton2.TabIndex = 47
        Me.UserButton2.Text = "Load"
        Me.UserButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.UserButton2.UseFunctionKeys = False
        Me.UserButton2.UseVisualStyleBackColor = False
        '
        'TxtEndDate
        '
        Me.TxtEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEndDate.Location = New System.Drawing.Point(511, 27)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(156, 20)
        Me.TxtEndDate.TabIndex = 46
        '
        'TxtStartDate
        '
        Me.TxtStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtStartDate.Location = New System.Drawing.Point(349, 27)
        Me.TxtStartDate.Name = "TxtStartDate"
        Me.TxtStartDate.Size = New System.Drawing.Size(156, 20)
        Me.TxtStartDate.TabIndex = 45
        '
        'TxtIsPeriod
        '
        Me.TxtIsPeriod.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIsPeriod.AutoSize = True
        Me.TxtIsPeriod.Checked = True
        Me.TxtIsPeriod.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TxtIsPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsPeriod.Location = New System.Drawing.Point(336, 7)
        Me.TxtIsPeriod.Name = "TxtIsPeriod"
        Me.TxtIsPeriod.Size = New System.Drawing.Size(132, 19)
        Me.TxtIsPeriod.TabIndex = 44
        Me.TxtIsPeriod.Text = "Show By Date Wise"
        Me.TxtIsPeriod.UseVisualStyleBackColor = True
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(12, 7)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(115, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "Filter By UserName"
        '
        'UserLogInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(912, 471)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "UserLogInfo"
        Me.Text = "User Log File"
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ReloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnDelete As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ImsButton4 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtUserName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents UserButton2 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtIsPeriod As System.Windows.Forms.CheckBox
    Friend WithEvents DELETEaLLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImsButton2 As JyothiPharmaERPSystem3.IMSButton
End Class
