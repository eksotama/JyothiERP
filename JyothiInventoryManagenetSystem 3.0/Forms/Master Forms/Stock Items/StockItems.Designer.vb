<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockItems
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockItems))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IMPORTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnDelete = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton4 = New JyothiPharmaERPSystem3.IMSButton()
        Me.btnActivate = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnImport = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnNew = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnEdit = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtShowImages = New System.Windows.Forms.CheckBox()
        Me.TxtSearchbyStockName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtSearchByStockItem = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtFilterBy = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtFilters = New System.Windows.Forms.ComboBox()
        Me.TxtShowBatchExpiryAlso = New System.Windows.Forms.CheckBox()
        Me.TxtListGridMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowInwardDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowOutWardDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowProfitOnThisItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowInwardAndOutwardDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TxtListGridMenu.SuspendLayout()
        Me.SuspendLayout()
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
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.PrintToolStripMenuItem, Me.CloseToolStripMenuItem, Me.ReloadToolStripMenuItem, Me.IMPORTToolStripMenuItem})
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
        'IMPORTToolStripMenuItem
        '
        Me.IMPORTToolStripMenuItem.Name = "IMPORTToolStripMenuItem"
        Me.IMPORTToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.IMPORTToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.IMPORTToolStripMenuItem.Text = "IMPORT"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkOrange
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1049, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "STOCK ITEMS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToOrderColumns = True
        Me.TxtList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TxtList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtList.DefaultCellStyle = DataGridViewCellStyle3
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.Location = New System.Drawing.Point(3, 75)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.ReadOnly = True
        Me.TxtList.RowHeadersWidth = 30
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(1043, 324)
        Me.TxtList.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 7
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnDelete, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton4, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnActivate, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnImport, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnNew, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnEdit, 5, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 405)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1043, 56)
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
        Me.ImsButton1.Location = New System.Drawing.Point(3, 3)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(142, 50)
        Me.ImsButton1.TabIndex = 6
        Me.ImsButton1.Text = "CLOSE"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = False
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
        Me.BtnDelete.Location = New System.Drawing.Point(447, 3)
        Me.BtnDelete.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.SetToolTip = ""
        Me.BtnDelete.Size = New System.Drawing.Size(142, 50)
        Me.BtnDelete.TabIndex = 4
        Me.BtnDelete.Text = "DELETE"
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
        Me.ImsButton4.Location = New System.Drawing.Point(299, 3)
        Me.ImsButton4.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton4.Name = "ImsButton4"
        Me.ImsButton4.SetToolTip = ""
        Me.ImsButton4.Size = New System.Drawing.Size(142, 50)
        Me.ImsButton4.TabIndex = 4
        Me.ImsButton4.Text = "PRINT"
        Me.ImsButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton4.UseFunctionKeys = False
        Me.ImsButton4.UseVisualStyleBackColor = False
        '
        'btnActivate
        '
        Me.btnActivate.AllowToolTip = True
        Me.btnActivate.BackColor = System.Drawing.Color.White
        Me.btnActivate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnActivate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActivate.ForeColor = System.Drawing.Color.Navy
        Me.btnActivate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnActivate.Image = CType(resources.GetObject("btnActivate.Image"), System.Drawing.Image)
        Me.btnActivate.Location = New System.Drawing.Point(151, 3)
        Me.btnActivate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnActivate.Name = "btnActivate"
        Me.btnActivate.SetToolTip = ""
        Me.btnActivate.Size = New System.Drawing.Size(142, 50)
        Me.btnActivate.TabIndex = 5
        Me.btnActivate.Text = "DeActivate"
        Me.btnActivate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnActivate.UseFunctionKeys = False
        Me.btnActivate.UseVisualStyleBackColor = False
        '
        'BtnImport
        '
        Me.BtnImport.AllowToolTip = True
        Me.BtnImport.BackColor = System.Drawing.Color.White
        Me.BtnImport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnImport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImport.ForeColor = System.Drawing.Color.Navy
        Me.BtnImport.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnImport.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.excel
        Me.BtnImport.Location = New System.Drawing.Point(595, 3)
        Me.BtnImport.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.SetToolTip = ""
        Me.BtnImport.Size = New System.Drawing.Size(142, 50)
        Me.BtnImport.TabIndex = 2
        Me.BtnImport.Text = "IMPORT"
        Me.BtnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnImport.UseFunctionKeys = False
        Me.BtnImport.UseVisualStyleBackColor = False
        '
        'BtnNew
        '
        Me.BtnNew.AllowToolTip = True
        Me.BtnNew.BackColor = System.Drawing.Color.White
        Me.BtnNew.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNew.ForeColor = System.Drawing.Color.Navy
        Me.BtnNew.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnNew.Image = CType(resources.GetObject("BtnNew.Image"), System.Drawing.Image)
        Me.BtnNew.Location = New System.Drawing.Point(891, 3)
        Me.BtnNew.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.SetToolTip = ""
        Me.BtnNew.Size = New System.Drawing.Size(149, 50)
        Me.BtnNew.TabIndex = 0
        Me.BtnNew.Text = "NEW"
        Me.BtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnNew.UseFunctionKeys = False
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'BtnEdit
        '
        Me.BtnEdit.AllowToolTip = True
        Me.BtnEdit.BackColor = System.Drawing.Color.White
        Me.BtnEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.ForeColor = System.Drawing.Color.Navy
        Me.BtnEdit.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnEdit.Image = CType(resources.GetObject("BtnEdit.Image"), System.Drawing.Image)
        Me.BtnEdit.Location = New System.Drawing.Point(743, 3)
        Me.BtnEdit.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.SetToolTip = ""
        Me.BtnEdit.Size = New System.Drawing.Size(142, 50)
        Me.BtnEdit.TabIndex = 1
        Me.BtnEdit.Text = "EDIT"
        Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnEdit.UseFunctionKeys = False
        Me.BtnEdit.UseVisualStyleBackColor = False
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
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.721393!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.18905!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.08955!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1049, 464)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtShowImages)
        Me.Panel1.Controls.Add(Me.TxtSearchbyStockName)
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Controls.Add(Me.TxtSearchByStockItem)
        Me.Panel1.Controls.Add(Me.ImSlabel3)
        Me.Panel1.Controls.Add(Me.ImSlabel4)
        Me.Panel1.Controls.Add(Me.ImSlabel2)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Controls.Add(Me.TxtFilterBy)
        Me.Panel1.Controls.Add(Me.TxtFilters)
        Me.Panel1.Controls.Add(Me.TxtShowBatchExpiryAlso)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(1, 24)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1047, 47)
        Me.Panel1.TabIndex = 3
        '
        'TxtShowImages
        '
        Me.TxtShowImages.AutoSize = True
        Me.TxtShowImages.Location = New System.Drawing.Point(811, 24)
        Me.TxtShowImages.Name = "TxtShowImages"
        Me.TxtShowImages.Size = New System.Drawing.Size(90, 17)
        Me.TxtShowImages.TabIndex = 4
        Me.TxtShowImages.Text = "Show Images"
        Me.TxtShowImages.UseVisualStyleBackColor = True
        '
        'TxtSearchbyStockName
        '
        Me.TxtSearchbyStockName.AllowToolTip = True
        Me.TxtSearchbyStockName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtSearchbyStockName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtSearchbyStockName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSearchbyStockName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSearchbyStockName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtSearchbyStockName.IsAllowDigits = True
        Me.TxtSearchbyStockName.IsAllowSpace = True
        Me.TxtSearchbyStockName.IsAllowSplChars = True
        Me.TxtSearchbyStockName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSearchbyStockName.Location = New System.Drawing.Point(138, 21)
        Me.TxtSearchbyStockName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSearchbyStockName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtSearchbyStockName.MaxLength = 75
        Me.TxtSearchbyStockName.Name = "TxtSearchbyStockName"
        Me.TxtSearchbyStockName.SetToolTip = Nothing
        Me.TxtSearchbyStockName.Size = New System.Drawing.Size(129, 20)
        Me.TxtSearchbyStockName.SpecialCharList = "&-/@"
        Me.TxtSearchbyStockName.TabIndex = 1
        Me.TxtSearchbyStockName.UseFunctionKeys = False
        '
        'TxtSearchByStockItem
        '
        Me.TxtSearchByStockItem.AllowToolTip = True
        Me.TxtSearchByStockItem.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtSearchByStockItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtSearchByStockItem.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSearchByStockItem.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSearchByStockItem.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtSearchByStockItem.IsAllowDigits = True
        Me.TxtSearchByStockItem.IsAllowSpace = True
        Me.TxtSearchByStockItem.IsAllowSplChars = True
        Me.TxtSearchByStockItem.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSearchByStockItem.Location = New System.Drawing.Point(11, 21)
        Me.TxtSearchByStockItem.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSearchByStockItem.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtSearchByStockItem.MaxLength = 75
        Me.TxtSearchByStockItem.Name = "TxtSearchByStockItem"
        Me.TxtSearchByStockItem.SetToolTip = Nothing
        Me.TxtSearchByStockItem.Size = New System.Drawing.Size(120, 20)
        Me.TxtSearchByStockItem.SpecialCharList = "&-/@"
        Me.TxtSearchByStockItem.TabIndex = 0
        Me.TxtSearchByStockItem.UseFunctionKeys = False
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(461, 6)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(76, 13)
        Me.ImSlabel3.TabIndex = 5
        Me.ImSlabel3.Text = "Search Text"
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(137, 5)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(120, 13)
        Me.ImSlabel4.TabIndex = 5
        Me.ImSlabel4.Text = "Search Stock Name"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(280, 4)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(65, 13)
        Me.ImSlabel2.TabIndex = 5
        Me.ImSlabel2.Text = "Search By"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(10, 5)
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
        Me.TxtFilterBy.IsAdvanceSearchWindow = False
        Me.TxtFilterBy.IsAllowDigits = True
        Me.TxtFilterBy.IsAllowSpace = True
        Me.TxtFilterBy.IsAllowSplChars = True
        Me.TxtFilterBy.IsAllowToolTip = True
        Me.TxtFilterBy.LFocusBackColor = System.Drawing.Color.White
        Me.TxtFilterBy.Location = New System.Drawing.Point(464, 20)
        Me.TxtFilterBy.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtFilterBy.Name = "TxtFilterBy"
        Me.TxtFilterBy.SetToolTip = Nothing
        Me.TxtFilterBy.Size = New System.Drawing.Size(181, 21)
        Me.TxtFilterBy.Sorted = True
        Me.TxtFilterBy.SpecialCharList = "&-/@"
        Me.TxtFilterBy.TabIndex = 3
        Me.TxtFilterBy.UseFunctionKeys = False
        '
        'TxtFilters
        '
        Me.TxtFilters.BackColor = System.Drawing.SystemColors.Control
        Me.TxtFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TxtFilters.FormattingEnabled = True
        Me.TxtFilters.Items.AddRange(New Object() {"Filter By Location", "Filter By Brand", "Filter By Group", "Filter By Category"})
        Me.TxtFilters.Location = New System.Drawing.Point(283, 20)
        Me.TxtFilters.Name = "TxtFilters"
        Me.TxtFilters.Size = New System.Drawing.Size(168, 21)
        Me.TxtFilters.TabIndex = 2
        '
        'TxtShowBatchExpiryAlso
        '
        Me.TxtShowBatchExpiryAlso.AutoSize = True
        Me.TxtShowBatchExpiryAlso.Location = New System.Drawing.Point(811, 5)
        Me.TxtShowBatchExpiryAlso.Name = "TxtShowBatchExpiryAlso"
        Me.TxtShowBatchExpiryAlso.Size = New System.Drawing.Size(166, 17)
        Me.TxtShowBatchExpiryAlso.TabIndex = 3
        Me.TxtShowBatchExpiryAlso.Text = "Show With Batch No && Expiry"
        Me.TxtShowBatchExpiryAlso.UseVisualStyleBackColor = True
        Me.TxtShowBatchExpiryAlso.Visible = False
        '
        'TxtListGridMenu
        '
        Me.TxtListGridMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowInwardDetailsToolStripMenuItem, Me.ShowOutWardDetailsToolStripMenuItem, Me.ShowProfitOnThisItemToolStripMenuItem, Me.ShowInwardAndOutwardDetailsToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExportToExcelToolStripMenuItem})
        Me.TxtListGridMenu.Name = "ContextMenuStrip1"
        Me.TxtListGridMenu.Size = New System.Drawing.Size(253, 120)
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
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(249, 6)
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.ExportToExcelToolStripMenuItem.Text = "Export to Excel"
        '
        'StockItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1049, 464)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "StockItems"
        Me.Text = "Stock Items"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TxtListGridMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnNew As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnEdit As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnDelete As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton4 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnActivate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtShowBatchExpiryAlso As System.Windows.Forms.CheckBox
    Friend WithEvents TxtFilters As System.Windows.Forms.ComboBox
    Friend WithEvents TxtFilterBy As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtSearchByStockItem As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtShowImages As System.Windows.Forms.CheckBox
    Friend WithEvents BtnImport As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents IMPORTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxtSearchbyStockName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtListGridMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowInwardDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowOutWardDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowProfitOnThisItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowInwardAndOutwardDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExportToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
