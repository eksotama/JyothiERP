﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvBalanceSheet
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.IsDateWiseOn = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtShowWithOpeningStock = New System.Windows.Forms.CheckBox()
        Me.txtwithcapitcalac = New System.Windows.Forms.CheckBox()
        Me.IsSubDetails = New System.Windows.Forms.CheckBox()
        Me.IsDetailedView = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.tadetails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tasubvalues = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tavalues = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ts1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtList1 = New JyothiPharmaERPSystem3.IMSList()
        Me.tldetails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tlsubvalues = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tlvalues = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ts2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TxtHeading = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnPrint = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtCrTotals = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtDrTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtUserWise = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtLocationWise = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.TxtList1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.09549!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.03714!))
        Me.TableLayoutPanel2.Controls.Add(Me.BtnClose, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnPrint, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.MenuStrip1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 457)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(810, 42)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(242, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem, Me.PrintToolStripMenuItem, Me.RefreshToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        Me.MenuToolStripMenuItem.Visible = False
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(450, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 34)
        Me.Button1.TabIndex = 53
        Me.Button1.Text = "Load"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtEndDate
        '
        Me.TxtEndDate.Enabled = False
        Me.TxtEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate.Location = New System.Drawing.Point(297, 8)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(147, 20)
        Me.TxtEndDate.TabIndex = 51
        '
        'TxtStartDate
        '
        Me.TxtStartDate.Enabled = False
        Me.TxtStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate.Location = New System.Drawing.Point(144, 8)
        Me.TxtStartDate.Name = "TxtStartDate"
        Me.TxtStartDate.Size = New System.Drawing.Size(147, 20)
        Me.TxtStartDate.TabIndex = 50
        '
        'IsDateWiseOn
        '
        Me.IsDateWiseOn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IsDateWiseOn.AutoSize = True
        Me.IsDateWiseOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsDateWiseOn.Location = New System.Drawing.Point(6, 9)
        Me.IsDateWiseOn.Name = "IsDateWiseOn"
        Me.IsDateWiseOn.Size = New System.Drawing.Size(132, 19)
        Me.IsDateWiseOn.TabIndex = 52
        Me.IsDateWiseOn.Text = "Show By Date Wise"
        Me.IsDateWiseOn.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel2, 2)
        Me.Panel2.Controls.Add(Me.TxtShowWithOpeningStock)
        Me.Panel2.Controls.Add(Me.txtwithcapitcalac)
        Me.Panel2.Controls.Add(Me.IsSubDetails)
        Me.Panel2.Controls.Add(Me.IsDetailedView)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.TxtEndDate)
        Me.Panel2.Controls.Add(Me.TxtStartDate)
        Me.Panel2.Controls.Add(Me.IsDateWiseOn)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 23)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(999, 37)
        Me.Panel2.TabIndex = 2
        '
        'TxtShowWithOpeningStock
        '
        Me.TxtShowWithOpeningStock.AutoSize = True
        Me.TxtShowWithOpeningStock.Location = New System.Drawing.Point(805, 3)
        Me.TxtShowWithOpeningStock.Name = "TxtShowWithOpeningStock"
        Me.TxtShowWithOpeningStock.Size = New System.Drawing.Size(122, 17)
        Me.TxtShowWithOpeningStock.TabIndex = 54
        Me.TxtShowWithOpeningStock.Text = "With Opening Stock"
        Me.TxtShowWithOpeningStock.UseVisualStyleBackColor = True
        '
        'txtwithcapitcalac
        '
        Me.txtwithcapitcalac.AutoSize = True
        Me.txtwithcapitcalac.Checked = True
        Me.txtwithcapitcalac.CheckState = System.Windows.Forms.CheckState.Checked
        Me.txtwithcapitcalac.Location = New System.Drawing.Point(805, 19)
        Me.txtwithcapitcalac.Name = "txtwithcapitcalac"
        Me.txtwithcapitcalac.Size = New System.Drawing.Size(131, 17)
        Me.txtwithcapitcalac.TabIndex = 54
        Me.txtwithcapitcalac.Text = "With Capital Accounts"
        Me.txtwithcapitcalac.UseVisualStyleBackColor = True
        '
        'IsSubDetails
        '
        Me.IsSubDetails.AutoSize = True
        Me.IsSubDetails.Location = New System.Drawing.Point(579, 19)
        Me.IsSubDetails.Name = "IsSubDetails"
        Me.IsSubDetails.Size = New System.Drawing.Size(91, 17)
        Me.IsSubDetails.TabIndex = 54
        Me.IsSubDetails.Text = "Detailed View"
        Me.IsSubDetails.UseVisualStyleBackColor = True
        '
        'IsDetailedView
        '
        Me.IsDetailedView.AutoSize = True
        Me.IsDetailedView.Location = New System.Drawing.Point(579, 3)
        Me.IsDetailedView.Name = "IsDetailedView"
        Me.IsDetailedView.Size = New System.Drawing.Size(81, 17)
        Me.IsDetailedView.TabIndex = 54
        Me.IsDetailedView.Text = "Group View"
        Me.IsDetailedView.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtHeading, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(999, 499)
        Me.TableLayoutPanel1.TabIndex = 12
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Panel1, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TxtList, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TxtList1, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.ImSlabel2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ImSlabel1, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 60)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(810, 397)
        Me.TableLayoutPanel3.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtCrTotals)
        Me.Panel1.Controls.Add(Me.ImSlabel6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(405, 377)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(405, 20)
        Me.Panel1.TabIndex = 8
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToOrderColumns = True
        Me.TxtList.AllowUserToResizeColumns = False
        Me.TxtList.AllowUserToResizeRows = False
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtList.BackgroundColor = System.Drawing.Color.White
        Me.TxtList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.ColumnHeadersVisible = False
        Me.TxtList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tadetails, Me.tasubvalues, Me.tavalues, Me.Ts1})
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.GridColor = System.Drawing.Color.White
        Me.TxtList.Location = New System.Drawing.Point(0, 14)
        Me.TxtList.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.RowHeadersVisible = False
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(405, 363)
        Me.TxtList.TabIndex = 0
        '
        'tadetails
        '
        Me.tadetails.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.tadetails.HeaderText = "Particulars"
        Me.tadetails.Name = "tadetails"
        '
        'tasubvalues
        '
        Me.tasubvalues.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.NullValue = Nothing
        Me.tasubvalues.DefaultCellStyle = DataGridViewCellStyle1
        Me.tasubvalues.HeaderText = "Column5"
        Me.tasubvalues.Name = "tasubvalues"
        Me.tasubvalues.Width = 90
        '
        'tavalues
        '
        Me.tavalues.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.NullValue = Nothing
        Me.tavalues.DefaultCellStyle = DataGridViewCellStyle2
        Me.tavalues.HeaderText = "Column2"
        Me.tavalues.Name = "tavalues"
        Me.tavalues.Width = 120
        '
        'Ts1
        '
        Me.Ts1.HeaderText = "Column5"
        Me.Ts1.Name = "Ts1"
        Me.Ts1.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TxtDrTotal)
        Me.Panel3.Controls.Add(Me.ImSlabel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 377)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(405, 20)
        Me.Panel3.TabIndex = 7
        '
        'TxtList1
        '
        Me.TxtList1.AllowUserToAddRows = False
        Me.TxtList1.AllowUserToDeleteRows = False
        Me.TxtList1.AllowUserToOrderColumns = True
        Me.TxtList1.AllowUserToResizeColumns = False
        Me.TxtList1.AllowUserToResizeRows = False
        Me.TxtList1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtList1.BackgroundColor = System.Drawing.Color.White
        Me.TxtList1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.TxtList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList1.ColumnHeadersVisible = False
        Me.TxtList1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tldetails, Me.tlsubvalues, Me.tlvalues, Me.ts2})
        Me.TxtList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList1.GridColor = System.Drawing.Color.White
        Me.TxtList1.Location = New System.Drawing.Point(405, 14)
        Me.TxtList1.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtList1.MultiSelect = False
        Me.TxtList1.Name = "TxtList1"
        Me.TxtList1.RowHeadersVisible = False
        Me.TxtList1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList1.Size = New System.Drawing.Size(405, 363)
        Me.TxtList1.TabIndex = 5
        '
        'tldetails
        '
        Me.tldetails.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.tldetails.HeaderText = "Column3"
        Me.tldetails.Name = "tldetails"
        '
        'tlsubvalues
        '
        Me.tlsubvalues.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N" & ErpDecimalPlaces
        DataGridViewCellStyle3.NullValue = Nothing
        Me.tlsubvalues.DefaultCellStyle = DataGridViewCellStyle3
        Me.tlsubvalues.HeaderText = "Column1"
        Me.tlsubvalues.Name = "tlsubvalues"
        Me.tlsubvalues.Width = 90
        '
        'tlvalues
        '
        Me.tlvalues.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N" & ErpDecimalPlaces
        DataGridViewCellStyle4.NullValue = Nothing
        Me.tlvalues.DefaultCellStyle = DataGridViewCellStyle4
        Me.tlvalues.HeaderText = "Column4"
        Me.tlvalues.Name = "tlvalues"
        Me.tlvalues.Width = 120
        '
        'ts2
        '
        Me.ts2.HeaderText = "Column5"
        Me.ts2.Name = "ts2"
        Me.ts2.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ImSlabel8)
        Me.GroupBox2.Controls.Add(Me.ImSlabel7)
        Me.GroupBox2.Controls.Add(Me.TxtUserWise)
        Me.GroupBox2.Controls.Add(Me.TxtLocationWise)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(813, 63)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(183, 391)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GroupBox2"
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(36, 152)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(120, 34)
        Me.Button3.TabIndex = 53
        Me.Button3.Text = "Load"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TxtHeading
        '
        Me.TxtHeading.BackColor = System.Drawing.Color.Green
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtHeading, 2)
        Me.TxtHeading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHeading.ForeColor = System.Drawing.Color.White
        Me.TxtHeading.Location = New System.Drawing.Point(0, 0)
        Me.TxtHeading.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtHeading.Name = "TxtHeading"
        Me.TxtHeading.Size = New System.Drawing.Size(999, 23)
        Me.TxtHeading.TabIndex = 0
        Me.TxtHeading.Text = "BALANCE SHEET"
        Me.TxtHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(202, 0)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(150, 42)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.AllowToolTip = True
        Me.BtnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnPrint.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.print__1_
        Me.BtnPrint.Location = New System.Drawing.Point(501, 0)
        Me.BtnPrint.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPrint.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.SetToolTip = ""
        Me.BtnPrint.Size = New System.Drawing.Size(162, 42)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseFunctionKeys = False
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'TxtCrTotals
        '
        Me.TxtCrTotals.AllowToolTip = True
        Me.TxtCrTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCrTotals.BackColor = System.Drawing.Color.White
        Me.TxtCrTotals.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtCrTotals.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCrTotals.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCrTotals.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCrTotals.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtCrTotals.IsAllowDigits = True
        Me.TxtCrTotals.IsAllowSpace = True
        Me.TxtCrTotals.IsAllowSplChars = True
        Me.TxtCrTotals.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCrTotals.Location = New System.Drawing.Point(270, 1)
        Me.TxtCrTotals.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCrTotals.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtCrTotals.MaxLength = 75
        Me.TxtCrTotals.Name = "TxtCrTotals"
        Me.TxtCrTotals.ReadOnly = True
        Me.TxtCrTotals.SetToolTip = Nothing
        Me.TxtCrTotals.Size = New System.Drawing.Size(133, 20)
        Me.TxtCrTotals.SpecialCharList = "&-/@"
        Me.TxtCrTotals.TabIndex = 21
        Me.TxtCrTotals.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtCrTotals.UseFunctionKeys = False
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(12, 3)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(42, 13)
        Me.ImSlabel6.TabIndex = 16
        Me.ImSlabel6.Text = "Totals"
        '
        'TxtDrTotal
        '
        Me.TxtDrTotal.AllowToolTip = True
        Me.TxtDrTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDrTotal.BackColor = System.Drawing.Color.White
        Me.TxtDrTotal.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtDrTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDrTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDrTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDrTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtDrTotal.IsAllowDigits = True
        Me.TxtDrTotal.IsAllowSpace = True
        Me.TxtDrTotal.IsAllowSplChars = True
        Me.TxtDrTotal.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDrTotal.Location = New System.Drawing.Point(272, 1)
        Me.TxtDrTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDrTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtDrTotal.MaxLength = 75
        Me.TxtDrTotal.Name = "TxtDrTotal"
        Me.TxtDrTotal.ReadOnly = True
        Me.TxtDrTotal.SetToolTip = Nothing
        Me.TxtDrTotal.Size = New System.Drawing.Size(133, 20)
        Me.TxtDrTotal.SpecialCharList = "&-/@"
        Me.TxtDrTotal.TabIndex = 18
        Me.TxtDrTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtDrTotal.UseFunctionKeys = False
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(12, 3)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(42, 13)
        Me.ImSlabel5.TabIndex = 16
        Me.ImSlabel5.Text = "Totals"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(3, 0)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(55, 14)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "ASSETS"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(408, 0)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(82, 14)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "LIABILITIES"
        '
        'ImSlabel8
        '
        Me.ImSlabel8.AutoSize = True
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(6, 94)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(125, 13)
        Me.ImSlabel8.TabIndex = 1
        Me.ImSlabel8.Text = "User/Employee Wise"
        '
        'ImSlabel7
        '
        Me.ImSlabel7.AutoSize = True
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(3, 36)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(99, 13)
        Me.ImSlabel7.TabIndex = 1
        Me.ImSlabel7.Text = "Location/Brach "
        '
        'TxtUserWise
        '
        Me.TxtUserWise.AllowEmpty = True
        Me.TxtUserWise.AllowOnlyListValues = False
        Me.TxtUserWise.AllowToolTip = True
        Me.TxtUserWise.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtUserWise.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtUserWise.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtUserWise.FormattingEnabled = True
        Me.TxtUserWise.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtUserWise.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtUserWise.IsAllowDigits = True
        Me.TxtUserWise.IsAllowSpace = True
        Me.TxtUserWise.IsAllowSplChars = True
        Me.TxtUserWise.IsAllowToolTip = True
        Me.TxtUserWise.LFocusBackColor = System.Drawing.Color.White
        Me.TxtUserWise.Location = New System.Drawing.Point(9, 110)
        Me.TxtUserWise.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtUserWise.Name = "TxtUserWise"
        Me.TxtUserWise.SetToolTip = Nothing
        Me.TxtUserWise.Size = New System.Drawing.Size(168, 21)
        Me.TxtUserWise.Sorted = True
        Me.TxtUserWise.SpecialCharList = "&-/@"
        Me.TxtUserWise.TabIndex = 0
        Me.TxtUserWise.UseFunctionKeys = False
        '
        'TxtLocationWise
        '
        Me.TxtLocationWise.AllowEmpty = True
        Me.TxtLocationWise.AllowOnlyListValues = False
        Me.TxtLocationWise.AllowToolTip = True
        Me.TxtLocationWise.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtLocationWise.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtLocationWise.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtLocationWise.FormattingEnabled = True
        Me.TxtLocationWise.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLocationWise.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLocationWise.IsAllowDigits = True
        Me.TxtLocationWise.IsAllowSpace = True
        Me.TxtLocationWise.IsAllowSplChars = True
        Me.TxtLocationWise.IsAllowToolTip = True
        Me.TxtLocationWise.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLocationWise.Location = New System.Drawing.Point(6, 52)
        Me.TxtLocationWise.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLocationWise.Name = "TxtLocationWise"
        Me.TxtLocationWise.SetToolTip = Nothing
        Me.TxtLocationWise.Size = New System.Drawing.Size(168, 21)
        Me.TxtLocationWise.Sorted = True
        Me.TxtLocationWise.SpecialCharList = "&-/@"
        Me.TxtLocationWise.TabIndex = 0
        Me.TxtLocationWise.UseFunctionKeys = False
        '
        'AdvBalanceSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(999, 499)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "AdvBalanceSheet"
        Me.Text = "Balance Sheet"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.TxtList1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TxtDrTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtCrTotals As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents tadetails As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tasubvalues As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tavalues As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ts1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtList1 As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents tldetails As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tlsubvalues As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tlvalues As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ts2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtHeading As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnPrint As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxtShowWithOpeningStock As System.Windows.Forms.CheckBox
    Friend WithEvents txtwithcapitcalac As System.Windows.Forms.CheckBox
    Friend WithEvents IsSubDetails As System.Windows.Forms.CheckBox
    Friend WithEvents IsDetailedView As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents IsDateWiseOn As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtUserWise As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtLocationWise As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
