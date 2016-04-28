<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeImportAndExport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeImportAndExport))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtErrorBox = New System.Windows.Forms.RichTextBox()
        Me.BtnError = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtSelectedFileName = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.BtnImportBrowse = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnImportUpdate = New JyothiPharmaERPSystem3.IMSButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.IsWithHeadings = New System.Windows.Forms.CheckBox()
        Me.BtnExport = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtDepartment = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtIList = New JyothiPharmaERPSystem3.IMSList()
        Me.Panel2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.TxtIList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ImsButton1)
        Me.Panel2.Controls.Add(Me.TxtErrorBox)
        Me.Panel2.Controls.Add(Me.BtnError)
        Me.Panel2.Controls.Add(Me.TxtSelectedFileName)
        Me.Panel2.Controls.Add(Me.ImSlabel2)
        Me.Panel2.Controls.Add(Me.BtnImportBrowse)
        Me.Panel2.Controls.Add(Me.BtnImportUpdate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1000, 51)
        Me.Panel2.TabIndex = 0
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.BackColor = System.Drawing.Color.White
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.excel
        Me.ImsButton1.Location = New System.Drawing.Point(642, 7)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(129, 42)
        Me.ImsButton1.TabIndex = 12
        Me.ImsButton1.Text = "Create Empty Form"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = False
        '
        'TxtErrorBox
        '
        Me.TxtErrorBox.Location = New System.Drawing.Point(1063, 22)
        Me.TxtErrorBox.Name = "TxtErrorBox"
        Me.TxtErrorBox.Size = New System.Drawing.Size(11, 20)
        Me.TxtErrorBox.TabIndex = 11
        Me.TxtErrorBox.Text = ""
        Me.TxtErrorBox.Visible = False
        '
        'BtnError
        '
        Me.BtnError.AllowToolTip = True
        Me.BtnError.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.BtnError.BackColor = System.Drawing.Color.White
        Me.BtnError.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnError.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.warning
        Me.BtnError.Location = New System.Drawing.Point(832, 6)
        Me.BtnError.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnError.Name = "BtnError"
        Me.BtnError.SetToolTip = ""
        Me.BtnError.Size = New System.Drawing.Size(114, 39)
        Me.BtnError.TabIndex = 8
        Me.BtnError.Text = "Error Log"
        Me.BtnError.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnError.UseFunctionKeys = False
        Me.BtnError.UseVisualStyleBackColor = False
        Me.BtnError.Visible = False
        '
        'TxtSelectedFileName
        '
        Me.TxtSelectedFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSelectedFileName.Location = New System.Drawing.Point(259, 6)
        Me.TxtSelectedFileName.Name = "TxtSelectedFileName"
        Me.TxtSelectedFileName.Size = New System.Drawing.Size(184, 42)
        Me.TxtSelectedFileName.TabIndex = 8
        Me.TxtSelectedFileName.Text = "  "
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(8, 22)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(128, 13)
        Me.ImSlabel2.TabIndex = 8
        Me.ImSlabel2.Text = "Select The Excel File"
        '
        'BtnImportBrowse
        '
        Me.BtnImportBrowse.AllowToolTip = True
        Me.BtnImportBrowse.BackColor = System.Drawing.Color.White
        Me.BtnImportBrowse.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnImportBrowse.Image = CType(resources.GetObject("BtnImportBrowse.Image"), System.Drawing.Image)
        Me.BtnImportBrowse.Location = New System.Drawing.Point(142, 6)
        Me.BtnImportBrowse.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnImportBrowse.Name = "BtnImportBrowse"
        Me.BtnImportBrowse.SetToolTip = "Select Excel File to Import (Import from 2nd Row )"
        Me.BtnImportBrowse.Size = New System.Drawing.Size(111, 42)
        Me.BtnImportBrowse.TabIndex = 7
        Me.BtnImportBrowse.Text = "Browse"
        Me.BtnImportBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnImportBrowse.UseFunctionKeys = False
        Me.BtnImportBrowse.UseVisualStyleBackColor = False
        '
        'BtnImportUpdate
        '
        Me.BtnImportUpdate.AllowToolTip = True
        Me.BtnImportUpdate.BackColor = System.Drawing.Color.White
        Me.BtnImportUpdate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnImportUpdate.Image = CType(resources.GetObject("BtnImportUpdate.Image"), System.Drawing.Image)
        Me.BtnImportUpdate.Location = New System.Drawing.Point(449, 6)
        Me.BtnImportUpdate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnImportUpdate.Name = "BtnImportUpdate"
        Me.BtnImportUpdate.SetToolTip = ""
        Me.BtnImportUpdate.Size = New System.Drawing.Size(122, 42)
        Me.BtnImportUpdate.TabIndex = 7
        Me.BtnImportUpdate.Text = "Update"
        Me.BtnImportUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnImportUpdate.UseFunctionKeys = False
        Me.BtnImportUpdate.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1000, 465)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Export Employees"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TxtList, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.52632!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.47369!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1000, 465)
        Me.TableLayoutPanel3.TabIndex = 4
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TxtList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtList.DefaultCellStyle = DataGridViewCellStyle9
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.Location = New System.Drawing.Point(3, 51)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.ReadOnly = True
        Me.TxtList.RowHeadersWidth = 30
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.TxtList.Size = New System.Drawing.Size(994, 411)
        Me.TxtList.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.IsWithHeadings)
        Me.Panel1.Controls.Add(Me.BtnExport)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Controls.Add(Me.TxtDepartment)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 48)
        Me.Panel1.TabIndex = 3
        '
        'IsWithHeadings
        '
        Me.IsWithHeadings.AutoSize = True
        Me.IsWithHeadings.Checked = True
        Me.IsWithHeadings.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IsWithHeadings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsWithHeadings.Location = New System.Drawing.Point(663, 16)
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
        Me.BtnExport.Location = New System.Drawing.Point(509, 2)
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
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(33, 15)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(96, 13)
        Me.ImSlabel1.TabIndex = 5
        Me.ImSlabel1.Text = "By Departments"
        '
        'TxtDepartment
        '
        Me.TxtDepartment.AllowEmpty = True
        Me.TxtDepartment.AllowOnlyListValues = False
        Me.TxtDepartment.AllowToolTip = True
        Me.TxtDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtDepartment.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtDepartment.FormattingEnabled = True
        Me.TxtDepartment.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDepartment.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDepartment.IsAdvanceSearchWindow = False
        Me.TxtDepartment.IsAllowDigits = True
        Me.TxtDepartment.IsAllowSpace = True
        Me.TxtDepartment.IsAllowSplChars = True
        Me.TxtDepartment.IsAllowToolTip = True
        Me.TxtDepartment.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDepartment.Location = New System.Drawing.Point(147, 12)
        Me.TxtDepartment.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDepartment.Name = "TxtDepartment"
        Me.TxtDepartment.SetToolTip = Nothing
        Me.TxtDepartment.Size = New System.Drawing.Size(217, 21)
        Me.TxtDepartment.Sorted = True
        Me.TxtDepartment.SpecialCharList = "&-/@"
        Me.TxtDepartment.TabIndex = 4
        Me.TxtDepartment.UseFunctionKeys = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.BtnClose, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ImsHeadingLabel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1008, 562)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(430, 520)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(148, 39)
        Me.BtnClose.TabIndex = 8
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = False
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
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(1008, 26)
        Me.ImsHeadingLabel1.TabIndex = 0
        Me.ImsHeadingLabel1.Text = "EMPLOYEE MASTERS IMPORT AND EXPORT"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 26)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1008, 491)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1000, 465)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Import Employees"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TxtIList, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1000, 465)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'TxtIList
        '
        Me.TxtIList.AllowUserToAddRows = False
        Me.TxtIList.AllowUserToResizeRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TxtIList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.TxtIList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtIList.DefaultCellStyle = DataGridViewCellStyle12
        Me.TxtIList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtIList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtIList.Location = New System.Drawing.Point(3, 54)
        Me.TxtIList.MultiSelect = False
        Me.TxtIList.Name = "TxtIList"
        Me.TxtIList.ReadOnly = True
        Me.TxtIList.RowHeadersWidth = 30
        Me.TxtIList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.TxtIList.Size = New System.Drawing.Size(994, 408)
        Me.TxtIList.TabIndex = 2
        '
        'EmployeeImportAndExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1008, 562)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "EmployeeImportAndExport"
        Me.Text = "Employees Import And Export"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.TxtIList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtDepartment As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtErrorBox As System.Windows.Forms.RichTextBox
    Friend WithEvents BtnError As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtSelectedFileName As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents BtnImportBrowse As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnImportUpdate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents IsWithHeadings As System.Windows.Forms.CheckBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtIList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents BtnExport As JyothiPharmaERPSystem3.IMSButton
End Class
