<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CurrentStockItemReport
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TxtShowImages = New System.Windows.Forms.CheckBox()
        Me.TxtSearchByStockItem = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtFilterBy = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtShowBatchExpiryAlso = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtSearchbyStockName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TxtFilters = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImsButton4 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtListGridMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowInwardDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowOutWardDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowProfitOnThisItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowInwardAndOutwardDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TxtListGridMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtShowImages
        '
        Me.TxtShowImages.AutoSize = True
        Me.TxtShowImages.Location = New System.Drawing.Point(871, 26)
        Me.TxtShowImages.Name = "TxtShowImages"
        Me.TxtShowImages.Size = New System.Drawing.Size(90, 17)
        Me.TxtShowImages.TabIndex = 7
        Me.TxtShowImages.Text = "Show Images"
        Me.TxtShowImages.UseVisualStyleBackColor = True
        '
        'TxtSearchByStockItem
        '
        Me.TxtSearchByStockItem.AllowToolTip = True
        Me.TxtSearchByStockItem.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtSearchByStockItem.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSearchByStockItem.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSearchByStockItem.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtSearchByStockItem.IsAllowDigits = True
        Me.TxtSearchByStockItem.IsAllowSpace = True
        Me.TxtSearchByStockItem.IsAllowSplChars = True
        Me.TxtSearchByStockItem.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSearchByStockItem.Location = New System.Drawing.Point(13, 24)
        Me.TxtSearchByStockItem.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSearchByStockItem.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtSearchByStockItem.MaxLength = 75
        Me.TxtSearchByStockItem.Name = "TxtSearchByStockItem"
        Me.TxtSearchByStockItem.SetToolTip = Nothing
        Me.TxtSearchByStockItem.Size = New System.Drawing.Size(168, 20)
        Me.TxtSearchByStockItem.SpecialCharList = "&-/@"
        Me.TxtSearchByStockItem.TabIndex = 6
        Me.TxtSearchByStockItem.UseFunctionKeys = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(10, 9)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(112, 13)
        Me.ImSlabel1.TabIndex = 5
        Me.ImSlabel1.Text = "Search Stock Item"
        '
        'TxtFilterBy
        '
        Me.TxtFilterBy.AllowEmpty = True
        Me.TxtFilterBy.AllowOnlyListValues = False
        Me.TxtFilterBy.AllowToolTip = True
        Me.TxtFilterBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtFilterBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtFilterBy.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtFilterBy.FormattingEnabled = True
        Me.TxtFilterBy.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtFilterBy.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtFilterBy.IsAllowDigits = True
        Me.TxtFilterBy.IsAllowSpace = True
        Me.TxtFilterBy.IsAllowSplChars = True
        Me.TxtFilterBy.IsAllowToolTip = True
        Me.TxtFilterBy.LFocusBackColor = System.Drawing.Color.White
        Me.TxtFilterBy.Location = New System.Drawing.Point(657, 21)
        Me.TxtFilterBy.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtFilterBy.Name = "TxtFilterBy"
        Me.TxtFilterBy.SetToolTip = Nothing
        Me.TxtFilterBy.Size = New System.Drawing.Size(193, 21)
        Me.TxtFilterBy.Sorted = True
        Me.TxtFilterBy.SpecialCharList = "&-/@"
        Me.TxtFilterBy.TabIndex = 4
        Me.TxtFilterBy.UseFunctionKeys = False
        '
        'TxtShowBatchExpiryAlso
        '
        Me.TxtShowBatchExpiryAlso.AutoSize = True
        Me.TxtShowBatchExpiryAlso.Location = New System.Drawing.Point(871, 6)
        Me.TxtShowBatchExpiryAlso.Name = "TxtShowBatchExpiryAlso"
        Me.TxtShowBatchExpiryAlso.Size = New System.Drawing.Size(166, 17)
        Me.TxtShowBatchExpiryAlso.TabIndex = 2
        Me.TxtShowBatchExpiryAlso.Text = "Show With Batch No && Expiry"
        Me.TxtShowBatchExpiryAlso.UseVisualStyleBackColor = True
        Me.TxtShowBatchExpiryAlso.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtSearchbyStockName)
        Me.Panel1.Controls.Add(Me.ImSlabel4)
        Me.Panel1.Controls.Add(Me.TxtShowImages)
        Me.Panel1.Controls.Add(Me.TxtSearchByStockItem)
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Controls.Add(Me.TxtFilterBy)
        Me.Panel1.Controls.Add(Me.TxtFilters)
        Me.Panel1.Controls.Add(Me.TxtShowBatchExpiryAlso)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(1, 32)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1079, 47)
        Me.Panel1.TabIndex = 3
        '
        'TxtSearchbyStockName
        '
        Me.TxtSearchbyStockName.AllowToolTip = True
        Me.TxtSearchbyStockName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtSearchbyStockName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSearchbyStockName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSearchbyStockName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtSearchbyStockName.IsAllowDigits = True
        Me.TxtSearchbyStockName.IsAllowSpace = True
        Me.TxtSearchbyStockName.IsAllowSplChars = True
        Me.TxtSearchbyStockName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSearchbyStockName.Location = New System.Drawing.Point(198, 23)
        Me.TxtSearchbyStockName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSearchbyStockName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtSearchbyStockName.MaxLength = 75
        Me.TxtSearchbyStockName.Name = "TxtSearchbyStockName"
        Me.TxtSearchbyStockName.SetToolTip = Nothing
        Me.TxtSearchbyStockName.Size = New System.Drawing.Size(195, 20)
        Me.TxtSearchbyStockName.SpecialCharList = "&-/@"
        Me.TxtSearchbyStockName.TabIndex = 8
        Me.TxtSearchbyStockName.UseFunctionKeys = False
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(197, 7)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(120, 13)
        Me.ImSlabel4.TabIndex = 9
        Me.ImSlabel4.Text = "Search Stock Name"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(39, 8)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(202, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.PrintToolStripMenuItem, Me.CloseToolStripMenuItem, Me.ReloadToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        Me.MenuToolStripMenuItem.Visible = False
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        Me.EditToolStripMenuItem.Visible = False
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.PrintToolStripMenuItem.Text = "print"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.CloseToolStripMenuItem.Text = "close"
        '
        'ReloadToolStripMenuItem
        '
        Me.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem"
        Me.ReloadToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.ReloadToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ReloadToolStripMenuItem.Text = "Reload "
        '
        'TxtFilters
        '
        Me.TxtFilters.BackColor = System.Drawing.SystemColors.Control
        Me.TxtFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TxtFilters.FormattingEnabled = True
        Me.TxtFilters.Items.AddRange(New Object() {"Filter By Location", "Filter By Brand", "Filter By Group", "Filter By Category"})
        Me.TxtFilters.Location = New System.Drawing.Point(463, 21)
        Me.TxtFilters.Name = "TxtFilters"
        Me.TxtFilters.Size = New System.Drawing.Size(188, 21)
        Me.TxtFilters.TabIndex = 3
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.86475!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.26164!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1081, 513)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1081, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "STOCK ITEMS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToResizeRows = False
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
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
        Me.TxtList.Location = New System.Drawing.Point(3, 83)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.ReadOnly = True
        Me.TxtList.RowHeadersWidth = 30
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(1075, 365)
        Me.TxtList.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 7
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton4, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton1, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 454)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1075, 56)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'ImsButton4
        '
        Me.ImsButton4.AllowToolTip = True
        Me.ImsButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton4.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton4.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton4.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.print__1_
        Me.ImsButton4.Location = New System.Drawing.Point(626, 3)
        Me.ImsButton4.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton4.Name = "ImsButton4"
        Me.ImsButton4.SetToolTip = ""
        Me.ImsButton4.Size = New System.Drawing.Size(148, 50)
        Me.ImsButton4.TabIndex = 0
        Me.ImsButton4.Text = "PRINT"
        Me.ImsButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton4.UseFunctionKeys = False
        Me.ImsButton4.UseVisualStyleBackColor = True
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton1.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.ImsButton1.Location = New System.Drawing.Point(224, 3)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(148, 50)
        Me.ImsButton1.TabIndex = 0
        Me.ImsButton1.Text = "CLOSE"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = True
        '
        'TxtListGridMenu
        '
        Me.TxtListGridMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowInwardDetailsToolStripMenuItem, Me.ShowOutWardDetailsToolStripMenuItem, Me.ShowProfitOnThisItemToolStripMenuItem, Me.ShowInwardAndOutwardDetailsToolStripMenuItem})
        Me.TxtListGridMenu.Name = "ContextMenuStrip1"
        Me.TxtListGridMenu.Size = New System.Drawing.Size(253, 114)
        '
        'ShowInwardDetailsToolStripMenuItem
        '
        Me.ShowInwardDetailsToolStripMenuItem.Name = "ShowInwardDetailsToolStripMenuItem"
        Me.ShowInwardDetailsToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.ShowInwardDetailsToolStripMenuItem.Text = "Show Inward Details"
        '
        'ShowOutWardDetailsToolStripMenuItem
        '
        Me.ShowOutWardDetailsToolStripMenuItem.Name = "ShowOutWardDetailsToolStripMenuItem"
        Me.ShowOutWardDetailsToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.ShowOutWardDetailsToolStripMenuItem.Text = "Show Outward Details"
        '
        'ShowProfitOnThisItemToolStripMenuItem
        '
        Me.ShowProfitOnThisItemToolStripMenuItem.Name = "ShowProfitOnThisItemToolStripMenuItem"
        Me.ShowProfitOnThisItemToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.ShowProfitOnThisItemToolStripMenuItem.Text = "Show Profit On this Item"
        '
        'ShowInwardAndOutwardDetailsToolStripMenuItem
        '
        Me.ShowInwardAndOutwardDetailsToolStripMenuItem.Name = "ShowInwardAndOutwardDetailsToolStripMenuItem"
        Me.ShowInwardAndOutwardDetailsToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.ShowInwardAndOutwardDetailsToolStripMenuItem.Text = "Show Inward and Outward Details"
        '
        'CurrentStockItemReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1081, 513)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CurrentStockItemReport"
        Me.Text = "Current Stock Position"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TxtListGridMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtShowImages As System.Windows.Forms.CheckBox
    Friend WithEvents TxtSearchByStockItem As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtFilterBy As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtShowBatchExpiryAlso As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxtFilters As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton4 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtSearchbyStockName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtListGridMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowInwardDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowOutWardDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowProfitOnThisItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowInwardAndOutwardDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
