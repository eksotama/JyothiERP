<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockUnitImportExport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockUnitImportExport))
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtListI = New JyothiPharmaERPSystem3.IMSList()
        Me.tmainunit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsubunit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tcon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tdecimals = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsimple = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnImport = New JyothiPharmaERPSystem3.IMSButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtListE = New JyothiPharmaERPSystem3.IMSList()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.IsWithHeadings = New System.Windows.Forms.CheckBox()
        Me.BtnExport = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.TxtListI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.TxtListE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnClose, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ImsHeadingLabel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(979, 525)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.AllowToolTip = True
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(415, 481)
        Me.btnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnClose.Name = "btnClose"
        Me.btnClose.SetToolTip = ""
        Me.btnClose.Size = New System.Drawing.Size(148, 41)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseFunctionKeys = False
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'ImsHeadingLabel1
        '
        Me.ImsHeadingLabel1.AutoSize = True
        Me.ImsHeadingLabel1.BackColor = System.Drawing.Color.DarkOrange
        Me.ImsHeadingLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsHeadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsHeadingLabel1.ForeColor = System.Drawing.Color.White
        Me.ImsHeadingLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ImsHeadingLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsHeadingLabel1.Name = "ImsHeadingLabel1"
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(979, 26)
        Me.ImsHeadingLabel1.TabIndex = 0
        Me.ImsHeadingLabel1.Text = "STOCK UNIT IMPORT && EXPORT"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 29)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(973, 446)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(965, 420)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Import Stock Units"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 249.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TxtListI, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 461.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(959, 414)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'TxtListI
        '
        Me.TxtListI.AllowUserToAddRows = False
        Me.TxtListI.AllowUserToDeleteRows = False
        Me.TxtListI.AllowUserToResizeRows = False
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtListI.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle16
        Me.TxtListI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TxtListI.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.TxtListI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtListI.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tmainunit, Me.tsubunit, Me.tcon, Me.tname, Me.tdecimals, Me.tsimple})
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtListI.DefaultCellStyle = DataGridViewCellStyle18
        Me.TxtListI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtListI.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtListI.Location = New System.Drawing.Point(252, 3)
        Me.TxtListI.MultiSelect = False
        Me.TxtListI.Name = "TxtListI"
        Me.TxtListI.ReadOnly = True
        Me.TxtListI.RowHeadersWidth = 30
        Me.TxtListI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtListI.Size = New System.Drawing.Size(704, 455)
        Me.TxtListI.TabIndex = 2
        '
        'tmainunit
        '
        Me.tmainunit.HeaderText = "MainUnitName"
        Me.tmainunit.Name = "tmainunit"
        Me.tmainunit.ReadOnly = True
        '
        'tsubunit
        '
        Me.tsubunit.HeaderText = "SubUnit"
        Me.tsubunit.Name = "tsubunit"
        Me.tsubunit.ReadOnly = True
        '
        'tcon
        '
        Me.tcon.HeaderText = "Conversion Value"
        Me.tcon.Name = "tcon"
        Me.tcon.ReadOnly = True
        '
        'tname
        '
        Me.tname.HeaderText = "Formal Name"
        Me.tname.Name = "tname"
        Me.tname.ReadOnly = True
        '
        'tdecimals
        '
        Me.tdecimals.HeaderText = "Decimals"
        Me.tdecimals.Name = "tdecimals"
        Me.tdecimals.ReadOnly = True
        '
        'tsimple
        '
        Me.tsimple.HeaderText = "Is Simple Unit"
        Me.tsimple.Name = "tsimple"
        Me.tsimple.ReadOnly = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.CheckBox1)
        Me.Panel2.Controls.Add(Me.ImsButton1)
        Me.Panel2.Controls.Add(Me.BtnImport)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(243, 455)
        Me.Panel2.TabIndex = 3
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(31, 96)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(135, 17)
        Me.CheckBox1.TabIndex = 10
        Me.CheckBox1.Text = "Has Row Heading?"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.BackColor = System.Drawing.Color.White
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = CType(resources.GetObject("ImsButton1.Image"), System.Drawing.Image)
        Me.ImsButton1.Location = New System.Drawing.Point(21, 249)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(175, 42)
        Me.ImsButton1.TabIndex = 9
        Me.ImsButton1.Text = "Update Now"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = False
        '
        'BtnImport
        '
        Me.BtnImport.AllowToolTip = True
        Me.BtnImport.BackColor = System.Drawing.Color.White
        Me.BtnImport.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnImport.Image = CType(resources.GetObject("BtnImport.Image"), System.Drawing.Image)
        Me.BtnImport.Location = New System.Drawing.Point(21, 39)
        Me.BtnImport.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.SetToolTip = ""
        Me.BtnImport.Size = New System.Drawing.Size(175, 42)
        Me.BtnImport.TabIndex = 9
        Me.BtnImport.Text = "Select Excel File"
        Me.BtnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnImport.UseFunctionKeys = False
        Me.BtnImport.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(965, 420)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Export Stock Units"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TxtListE, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.635974!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.36403!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(959, 414)
        Me.TableLayoutPanel3.TabIndex = 4
        '
        'TxtListE
        '
        Me.TxtListE.AllowUserToAddRows = False
        Me.TxtListE.AllowUserToDeleteRows = False
        Me.TxtListE.AllowUserToResizeRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtListE.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TxtListE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.TxtListE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtListE.DefaultCellStyle = DataGridViewCellStyle15
        Me.TxtListE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtListE.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtListE.Location = New System.Drawing.Point(3, 42)
        Me.TxtListE.MultiSelect = False
        Me.TxtListE.Name = "TxtListE"
        Me.TxtListE.ReadOnly = True
        Me.TxtListE.RowHeadersWidth = 30
        Me.TxtListE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtListE.Size = New System.Drawing.Size(953, 369)
        Me.TxtListE.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.IsWithHeadings)
        Me.Panel1.Controls.Add(Me.BtnExport)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(959, 39)
        Me.Panel1.TabIndex = 3
        '
        'IsWithHeadings
        '
        Me.IsWithHeadings.AutoSize = True
        Me.IsWithHeadings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsWithHeadings.Location = New System.Drawing.Point(36, 16)
        Me.IsWithHeadings.Name = "IsWithHeadings"
        Me.IsWithHeadings.Size = New System.Drawing.Size(175, 17)
        Me.IsWithHeadings.TabIndex = 8
        Me.IsWithHeadings.Text = "Export with Row Headings"
        Me.IsWithHeadings.UseVisualStyleBackColor = True
        '
        'BtnExport
        '
        Me.BtnExport.AllowToolTip = True
        Me.BtnExport.BackColor = System.Drawing.Color.White
        Me.BtnExport.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnExport.Image = CType(resources.GetObject("BtnExport.Image"), System.Drawing.Image)
        Me.BtnExport.Location = New System.Drawing.Point(242, 0)
        Me.BtnExport.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.SetToolTip = ""
        Me.BtnExport.Size = New System.Drawing.Size(148, 42)
        Me.BtnExport.TabIndex = 6
        Me.BtnExport.Text = "Export "
        Me.BtnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnExport.UseFunctionKeys = False
        Me.BtnExport.UseVisualStyleBackColor = False
        '
        'StockUnitImportExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(979, 525)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "StockUnitImportExport"
        Me.Text = "Stock Unit Import And Export Options"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.TxtListI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.TxtListE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtListE As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents IsWithHeadings As System.Windows.Forms.CheckBox
    Friend WithEvents BtnExport As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtListI As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnImport As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents tmainunit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tsubunit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tcon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tdecimals As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tsimple As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnClose As JyothiPharmaERPSystem3.IMSButton
End Class
