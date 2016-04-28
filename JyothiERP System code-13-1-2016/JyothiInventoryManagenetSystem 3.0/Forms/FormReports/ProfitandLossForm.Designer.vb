<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProfitandLossForm
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtHeading = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.TLDetails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TLSubAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TLAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ts1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtList1 = New JyothiPharmaERPSystem3.IMSList()
        Me.TRDetails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TRSubAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TRAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ts2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ISDetailedView = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.IsDateWiseOn = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnPrint = New JyothiPharmaERPSystem3.IMSButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtList1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(488, 0)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(67, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "Particulars"
        '
        'TxtHeading
        '
        Me.TxtHeading.BackColor = System.Drawing.Color.Green
        Me.TxtHeading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHeading.ForeColor = System.Drawing.Color.White
        Me.TxtHeading.Location = New System.Drawing.Point(0, 0)
        Me.TxtHeading.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtHeading.Name = "TxtHeading"
        Me.TxtHeading.Size = New System.Drawing.Size(971, 23)
        Me.TxtHeading.TabIndex = 0
        Me.TxtHeading.Text = "PROFIT && LOSS A/C"
        Me.TxtHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TxtList, 0, 1)
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
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(971, 391)
        Me.TableLayoutPanel3.TabIndex = 9
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToOrderColumns = True
        Me.TxtList.AllowUserToResizeColumns = False
        Me.TxtList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtList.BackgroundColor = System.Drawing.Color.White
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.ColumnHeadersVisible = False
        Me.TxtList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TLDetails, Me.TLSubAmount, Me.TLAmount, Me.Ts1})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtList.DefaultCellStyle = DataGridViewCellStyle4
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.GridColor = System.Drawing.Color.White
        Me.TxtList.Location = New System.Drawing.Point(0, 14)
        Me.TxtList.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.RowHeadersVisible = False
        Me.TableLayoutPanel3.SetRowSpan(Me.TxtList, 2)
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(485, 377)
        Me.TxtList.TabIndex = 0
        '
        'TLDetails
        '
        Me.TLDetails.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TLDetails.HeaderText = "Particulars"
        Me.TLDetails.Name = "TLDetails"
        '
        'TLSubAmount
        '
        Me.TLSubAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.Format = "N3"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.TLSubAmount.DefaultCellStyle = DataGridViewCellStyle2
        Me.TLSubAmount.HeaderText = "Column1"
        Me.TLSubAmount.Name = "TLSubAmount"
        '
        'TLAmount
        '
        Me.TLAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N3"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.TLAmount.DefaultCellStyle = DataGridViewCellStyle3
        Me.TLAmount.HeaderText = "Column2"
        Me.TLAmount.Name = "TLAmount"
        Me.TLAmount.Width = 120
        '
        'Ts1
        '
        Me.Ts1.HeaderText = "Column5"
        Me.Ts1.Name = "Ts1"
        Me.Ts1.Visible = False
        '
        'TxtList1
        '
        Me.TxtList1.AllowUserToAddRows = False
        Me.TxtList1.AllowUserToDeleteRows = False
        Me.TxtList1.AllowUserToOrderColumns = True
        Me.TxtList1.AllowUserToResizeColumns = False
        Me.TxtList1.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.TxtList1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtList1.BackgroundColor = System.Drawing.Color.White
        Me.TxtList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList1.ColumnHeadersVisible = False
        Me.TxtList1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TRDetails, Me.TRSubAmount, Me.TRAmount, Me.ts2})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtList1.DefaultCellStyle = DataGridViewCellStyle8
        Me.TxtList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList1.GridColor = System.Drawing.Color.White
        Me.TxtList1.Location = New System.Drawing.Point(485, 14)
        Me.TxtList1.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtList1.MultiSelect = False
        Me.TxtList1.Name = "TxtList1"
        Me.TxtList1.RowHeadersVisible = False
        Me.TableLayoutPanel3.SetRowSpan(Me.TxtList1, 2)
        Me.TxtList1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList1.Size = New System.Drawing.Size(486, 377)
        Me.TxtList1.TabIndex = 5
        '
        'TRDetails
        '
        Me.TRDetails.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TRDetails.HeaderText = "Column3"
        Me.TRDetails.Name = "TRDetails"
        '
        'TRSubAmount
        '
        Me.TRSubAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle6.Format = "N3"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.TRSubAmount.DefaultCellStyle = DataGridViewCellStyle6
        Me.TRSubAmount.HeaderText = "Column1"
        Me.TRSubAmount.Name = "TRSubAmount"
        '
        'TRAmount
        '
        Me.TRAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N3"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.TRAmount.DefaultCellStyle = DataGridViewCellStyle7
        Me.TRAmount.HeaderText = "Column4"
        Me.TRAmount.Name = "TRAmount"
        Me.TRAmount.Width = 120
        '
        'ts2
        '
        Me.ts2.HeaderText = "Column5"
        Me.ts2.Name = "ts2"
        Me.ts2.Visible = False
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(3, 0)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(67, 13)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "Particulars"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtHeading, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(971, 493)
        Me.TableLayoutPanel1.TabIndex = 13
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ISDetailedView)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.TxtEndDate)
        Me.Panel2.Controls.Add(Me.TxtStartDate)
        Me.Panel2.Controls.Add(Me.IsDateWiseOn)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 23)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(971, 37)
        Me.Panel2.TabIndex = 2
        '
        'ISDetailedView
        '
        Me.ISDetailedView.AutoSize = True
        Me.ISDetailedView.Location = New System.Drawing.Point(570, 8)
        Me.ISDetailedView.Name = "ISDetailedView"
        Me.ISDetailedView.Size = New System.Drawing.Size(100, 17)
        Me.ISDetailedView.TabIndex = 54
        Me.ISDetailedView.Text = "Detailed View ?"
        Me.ISDetailedView.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(450, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 53
        Me.Button1.Text = "Load"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtEndDate
        '
        Me.TxtEndDate.Enabled = False
        Me.TxtEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEndDate.Location = New System.Drawing.Point(297, 8)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(147, 20)
        Me.TxtEndDate.TabIndex = 51
        '
        'TxtStartDate
        '
        Me.TxtStartDate.Enabled = False
        Me.TxtStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
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
        Me.IsDateWiseOn.Location = New System.Drawing.Point(6, 8)
        Me.IsDateWiseOn.Name = "IsDateWiseOn"
        Me.IsDateWiseOn.Size = New System.Drawing.Size(132, 19)
        Me.IsDateWiseOn.TabIndex = 52
        Me.IsDateWiseOn.Text = "Show By Date Wise"
        Me.IsDateWiseOn.UseVisualStyleBackColor = True
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 451)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(971, 42)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(242, 0)
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
        Me.BtnPrint.Location = New System.Drawing.Point(633, 0)
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
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(225, 24)
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
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'ProfitandLossForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 493)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ProfitandLossForm"
        Me.Text = "Profit & Loss Form"
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtList1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtHeading As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TLDetails As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TLSubAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TLAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ts1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtList1 As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TRDetails As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TRSubAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TRAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ts2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ISDetailedView As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents IsDateWiseOn As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnPrint As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
