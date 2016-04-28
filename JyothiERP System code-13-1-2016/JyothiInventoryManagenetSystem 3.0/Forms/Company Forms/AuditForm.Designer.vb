<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AuditForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AuditForm))
        Me.ReloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnConfirm = New JyothiPharmaERPSystem3.IMSButton()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCLose = New JyothiPharmaERPSystem3.IMSButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnUnConfirm = New JyothiPharmaERPSystem3.IMSButton()
        Me.btnAuto = New JyothiPharmaERPSystem3.IMSButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UserButton2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtIsPeriod = New System.Windows.Forms.CheckBox()
        Me.TxtShowPendings = New System.Windows.Forms.CheckBox()
        Me.TxtFilterBy = New JyothiPharmaERPSystem3.IMSComboBox()
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
        Me.ReloadToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)), System.Windows.Forms.Keys)
        Me.ReloadToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.ReloadToolStripMenuItem.Text = "Reload "
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.PrintToolStripMenuItem.Text = "print"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        Me.EditToolStripMenuItem.Visible = False
        '
        'BtnConfirm
        '
        Me.BtnConfirm.AllowToolTip = True
        Me.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnConfirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConfirm.ForeColor = System.Drawing.Color.Navy
        Me.BtnConfirm.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnConfirm.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361188505_file_edit
        Me.BtnConfirm.Location = New System.Drawing.Point(315, 3)
        Me.BtnConfirm.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.SetToolTip = ""
        Me.BtnConfirm.Size = New System.Drawing.Size(140, 50)
        Me.BtnConfirm.TabIndex = 0
        Me.BtnConfirm.Text = "CONFIRM"
        Me.BtnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnConfirm.UseFunctionKeys = False
        Me.BtnConfirm.UseVisualStyleBackColor = True
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.PrintToolStripMenuItem, Me.CloseToolStripMenuItem, Me.ReloadToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        Me.MenuToolStripMenuItem.Visible = False
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.CloseToolStripMenuItem.Text = "close"
        '
        'btnCLose
        '
        Me.btnCLose.AllowToolTip = True
        Me.btnCLose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCLose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCLose.ForeColor = System.Drawing.Color.Navy
        Me.btnCLose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnCLose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.btnCLose.Location = New System.Drawing.Point(153, 3)
        Me.btnCLose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnCLose.Name = "btnCLose"
        Me.btnCLose.SetToolTip = ""
        Me.btnCLose.Size = New System.Drawing.Size(156, 50)
        Me.btnCLose.TabIndex = 0
        Me.btnCLose.Text = "CLOSE"
        Me.btnCLose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCLose.UseFunctionKeys = False
        Me.btnCLose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(935, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ACCOUNTS AUDIT"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToResizeRows = False
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TxtList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.Location = New System.Drawing.Point(3, 82)
        Me.TxtList.Name = "TxtList"
        Me.TxtList.RowHeadersWidth = 30
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(935, 359)
        Me.TxtList.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 8
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.87696!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.45638!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.23937!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.09396!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnCLose, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnConfirm, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnUnConfirm, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnAuto, 5, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 447)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(935, 56)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'BtnUnConfirm
        '
        Me.BtnUnConfirm.AllowToolTip = True
        Me.BtnUnConfirm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnUnConfirm.Enabled = False
        Me.BtnUnConfirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUnConfirm.ForeColor = System.Drawing.Color.Navy
        Me.BtnUnConfirm.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnUnConfirm.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361188505_file_edit
        Me.BtnUnConfirm.Location = New System.Drawing.Point(461, 3)
        Me.BtnUnConfirm.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnUnConfirm.Name = "BtnUnConfirm"
        Me.BtnUnConfirm.SetToolTip = ""
        Me.BtnUnConfirm.Size = New System.Drawing.Size(140, 50)
        Me.BtnUnConfirm.TabIndex = 0
        Me.BtnUnConfirm.Text = "UNCONFIRM"
        Me.BtnUnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnUnConfirm.UseFunctionKeys = False
        Me.BtnUnConfirm.UseVisualStyleBackColor = True
        '
        'btnAuto
        '
        Me.btnAuto.AllowToolTip = True
        Me.btnAuto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAuto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAuto.ForeColor = System.Drawing.Color.Navy
        Me.btnAuto.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnAuto.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361188505_file_edit
        Me.btnAuto.Location = New System.Drawing.Point(607, 3)
        Me.btnAuto.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnAuto.Name = "btnAuto"
        Me.btnAuto.SetToolTip = ""
        Me.btnAuto.Size = New System.Drawing.Size(163, 50)
        Me.btnAuto.TabIndex = 0
        Me.btnAuto.Text = "AUTO CONFIRM"
        Me.btnAuto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAuto.UseFunctionKeys = False
        Me.btnAuto.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(26, 69)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(202, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.756757!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.03604!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.20721!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(941, 506)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UserButton2)
        Me.Panel1.Controls.Add(Me.TxtEndDate)
        Me.Panel1.Controls.Add(Me.TxtStartDate)
        Me.Panel1.Controls.Add(Me.TxtIsPeriod)
        Me.Panel1.Controls.Add(Me.TxtShowPendings)
        Me.Panel1.Controls.Add(Me.TxtFilterBy)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 30)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(941, 49)
        Me.Panel1.TabIndex = 3
        '
        'UserButton2
        '
        Me.UserButton2.AllowToolTip = True
        Me.UserButton2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.UserButton2.Image = CType(resources.GetObject("UserButton2.Image"), System.Drawing.Image)
        Me.UserButton2.Location = New System.Drawing.Point(529, 7)
        Me.UserButton2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.UserButton2.Name = "UserButton2"
        Me.UserButton2.SetToolTip = ""
        Me.UserButton2.Size = New System.Drawing.Size(106, 39)
        Me.UserButton2.TabIndex = 45
        Me.UserButton2.Text = "Load"
        Me.UserButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.UserButton2.UseFunctionKeys = False
        Me.UserButton2.UseVisualStyleBackColor = True
        '
        'TxtEndDate
        '
        Me.TxtEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate.Location = New System.Drawing.Point(365, 20)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(156, 20)
        Me.TxtEndDate.TabIndex = 44
        '
        'TxtStartDate
        '
        Me.TxtStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate.Location = New System.Drawing.Point(203, 20)
        Me.TxtStartDate.Name = "TxtStartDate"
        Me.TxtStartDate.Size = New System.Drawing.Size(156, 20)
        Me.TxtStartDate.TabIndex = 43
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
        Me.TxtIsPeriod.Location = New System.Drawing.Point(203, 0)
        Me.TxtIsPeriod.Name = "TxtIsPeriod"
        Me.TxtIsPeriod.Size = New System.Drawing.Size(132, 19)
        Me.TxtIsPeriod.TabIndex = 42
        Me.TxtIsPeriod.Text = "Show By Date Wise"
        Me.TxtIsPeriod.UseVisualStyleBackColor = True
        '
        'TxtShowPendings
        '
        Me.TxtShowPendings.AutoSize = True
        Me.TxtShowPendings.Checked = True
        Me.TxtShowPendings.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TxtShowPendings.Location = New System.Drawing.Point(654, 17)
        Me.TxtShowPendings.Name = "TxtShowPendings"
        Me.TxtShowPendings.Size = New System.Drawing.Size(100, 17)
        Me.TxtShowPendings.TabIndex = 6
        Me.TxtShowPendings.Text = "Show Pendings"
        Me.TxtShowPendings.UseVisualStyleBackColor = True
        '
        'TxtFilterBy
        '
        Me.TxtFilterBy.AllowEmpty = True
        Me.TxtFilterBy.AllowOnlyListValues = True
        Me.TxtFilterBy.AllowToolTip = True
        Me.TxtFilterBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtFilterBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtFilterBy.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtFilterBy.FormattingEnabled = True
        Me.TxtFilterBy.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtFilterBy.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtFilterBy.IsAllowDigits = True
        Me.TxtFilterBy.IsAllowSpace = True
        Me.TxtFilterBy.IsAllowSplChars = True
        Me.TxtFilterBy.IsAllowToolTip = True
        Me.TxtFilterBy.Items.AddRange(New Object() {"Inventory", "Payroll", "Vouchers"})
        Me.TxtFilterBy.LFocusBackColor = System.Drawing.Color.White
        Me.TxtFilterBy.Location = New System.Drawing.Point(12, 19)
        Me.TxtFilterBy.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtFilterBy.Name = "TxtFilterBy"
        Me.TxtFilterBy.Size = New System.Drawing.Size(164, 21)
        Me.TxtFilterBy.Sorted = True
        Me.TxtFilterBy.SpecialCharList = "&-/@"
        Me.TxtFilterBy.TabIndex = 5
        Me.TxtFilterBy.UseFunctionKeys = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(9, 3)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(53, 13)
        Me.ImSlabel1.TabIndex = 4
        Me.ImSlabel1.Text = "Filter By"
        '
        'AuditForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 506)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "AuditForm"
        Me.Text = "Audit Form"
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnConfirm As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCLose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnUnConfirm As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents btnAuto As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtFilterBy As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtShowPendings As System.Windows.Forms.CheckBox
    Friend WithEvents UserButton2 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtIsPeriod As System.Windows.Forms.CheckBox
End Class
