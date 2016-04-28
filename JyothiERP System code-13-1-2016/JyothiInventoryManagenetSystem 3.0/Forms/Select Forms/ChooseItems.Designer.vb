<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChooseItems
    Inherits System.Windows.Forms.Form
    Dim Bcode As ChooseItemClass
    Dim LocationName As String = ""
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
    Sub New(ByRef barcode As ChooseItemClass, Optional ByVal DefLocation As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        Bcode = barcode
        LocationName = DefLocation
        ' Add any initialization after the InitializeComponent() call.

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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.BtnCreate = New System.Windows.Forms.Button()
        Me.TxtOnlyServices = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtLocation = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtStockDes = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtStockName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtStockCode = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MmToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtList, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ImsButton1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.93291!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.06709!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(905, 530)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.BtnCreate)
        Me.Panel1.Controls.Add(Me.TxtOnlyServices)
        Me.Panel1.Controls.Add(Me.TxtLocation)
        Me.Panel1.Controls.Add(Me.TxtStockDes)
        Me.Panel1.Controls.Add(Me.TxtStockName)
        Me.Panel1.Controls.Add(Me.TxtStockCode)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(905, 78)
        Me.Panel1.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.Button2.Location = New System.Drawing.Point(763, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(120, 72)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Close"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'BtnCreate
        '
        Me.BtnCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCreate.Location = New System.Drawing.Point(640, 3)
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.Size = New System.Drawing.Size(120, 72)
        Me.BtnCreate.TabIndex = 4
        Me.BtnCreate.Text = "&Create New Item"
        Me.BtnCreate.UseVisualStyleBackColor = True
        '
        'TxtOnlyServices
        '
        Me.TxtOnlyServices.AllowEmpty = True
        Me.TxtOnlyServices.AllowOnlyListValues = False
        Me.TxtOnlyServices.AllowToolTip = True
        Me.TxtOnlyServices.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtOnlyServices.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtOnlyServices.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtOnlyServices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtOnlyServices.FormattingEnabled = True
        Me.TxtOnlyServices.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtOnlyServices.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtOnlyServices.IsAdvanceSearchWindow = False
        Me.TxtOnlyServices.IsAllowDigits = True
        Me.TxtOnlyServices.IsAllowSpace = True
        Me.TxtOnlyServices.IsAllowSplChars = True
        Me.TxtOnlyServices.IsAllowToolTip = True
        Me.TxtOnlyServices.Items.AddRange(New Object() {"*All", "Non-Stock", "Stock"})
        Me.TxtOnlyServices.LFocusBackColor = System.Drawing.Color.White
        Me.TxtOnlyServices.Location = New System.Drawing.Point(470, 13)
        Me.TxtOnlyServices.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtOnlyServices.Name = "TxtOnlyServices"
        Me.TxtOnlyServices.SetToolTip = Nothing
        Me.TxtOnlyServices.Size = New System.Drawing.Size(121, 21)
        Me.TxtOnlyServices.Sorted = True
        Me.TxtOnlyServices.SpecialCharList = "&-/@"
        Me.TxtOnlyServices.TabIndex = 3
        Me.TxtOnlyServices.UseFunctionKeys = False
        '
        'TxtLocation
        '
        Me.TxtLocation.AllowEmpty = True
        Me.TxtLocation.AllowOnlyListValues = False
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
        Me.TxtLocation.Location = New System.Drawing.Point(470, 50)
        Me.TxtLocation.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLocation.Name = "TxtLocation"
        Me.TxtLocation.SetToolTip = Nothing
        Me.TxtLocation.Size = New System.Drawing.Size(121, 21)
        Me.TxtLocation.Sorted = True
        Me.TxtLocation.SpecialCharList = "&-/@"
        Me.TxtLocation.TabIndex = 4
        Me.TxtLocation.UseFunctionKeys = False
        '
        'TxtStockDes
        '
        Me.TxtStockDes.AllowToolTip = True
        Me.TxtStockDes.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtStockDes.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockDes.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockDes.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtStockDes.IsAllowDigits = True
        Me.TxtStockDes.IsAllowSpace = True
        Me.TxtStockDes.IsAllowSplChars = True
        Me.TxtStockDes.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockDes.Location = New System.Drawing.Point(124, 52)
        Me.TxtStockDes.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockDes.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtStockDes.MaxLength = 75
        Me.TxtStockDes.Name = "TxtStockDes"
        Me.TxtStockDes.SetToolTip = Nothing
        Me.TxtStockDes.Size = New System.Drawing.Size(278, 20)
        Me.TxtStockDes.SpecialCharList = "&-/@"
        Me.TxtStockDes.TabIndex = 2
        Me.TxtStockDes.UseFunctionKeys = False
        '
        'TxtStockName
        '
        Me.TxtStockName.AllowToolTip = True
        Me.TxtStockName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtStockName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtStockName.IsAllowDigits = True
        Me.TxtStockName.IsAllowSpace = True
        Me.TxtStockName.IsAllowSplChars = True
        Me.TxtStockName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockName.Location = New System.Drawing.Point(124, 28)
        Me.TxtStockName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtStockName.MaxLength = 75
        Me.TxtStockName.Name = "TxtStockName"
        Me.TxtStockName.SetToolTip = Nothing
        Me.TxtStockName.Size = New System.Drawing.Size(278, 20)
        Me.TxtStockName.SpecialCharList = "&-/@"
        Me.TxtStockName.TabIndex = 1
        Me.TxtStockName.UseFunctionKeys = False
        '
        'TxtStockCode
        '
        Me.TxtStockCode.AllowToolTip = True
        Me.TxtStockCode.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtStockCode.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockCode.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockCode.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtStockCode.IsAllowDigits = True
        Me.TxtStockCode.IsAllowSpace = True
        Me.TxtStockCode.IsAllowSplChars = True
        Me.TxtStockCode.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockCode.Location = New System.Drawing.Point(124, 4)
        Me.TxtStockCode.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockCode.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtStockCode.MaxLength = 75
        Me.TxtStockCode.Name = "TxtStockCode"
        Me.TxtStockCode.SetToolTip = Nothing
        Me.TxtStockCode.Size = New System.Drawing.Size(278, 20)
        Me.TxtStockCode.SpecialCharList = "&-/@"
        Me.TxtStockCode.TabIndex = 0
        Me.TxtStockCode.UseFunctionKeys = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Search By Description"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Search By Stock Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(427, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(411, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Locations"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Search by Stock Code"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MmToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(905, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'MmToolStripMenuItem
        '
        Me.MmToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NameToolStripMenuItem, Me.CodeToolStripMenuItem})
        Me.MmToolStripMenuItem.Name = "MmToolStripMenuItem"
        Me.MmToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.MmToolStripMenuItem.Text = "mm"
        Me.MmToolStripMenuItem.Visible = False
        '
        'NameToolStripMenuItem
        '
        Me.NameToolStripMenuItem.Name = "NameToolStripMenuItem"
        Me.NameToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.NameToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.NameToolStripMenuItem.Text = "name"
        '
        'CodeToolStripMenuItem
        '
        Me.CodeToolStripMenuItem.Name = "CodeToolStripMenuItem"
        Me.CodeToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.CodeToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.CodeToolStripMenuItem.Text = "code"
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtList.DefaultCellStyle = DataGridViewCellStyle2
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.Location = New System.Drawing.Point(3, 81)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.RowHeadersVisible = False
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(899, 406)
        Me.TxtList.TabIndex = 0
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.success32
        Me.ImsButton1.Location = New System.Drawing.Point(3, 493)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(899, 34)
        Me.ImsButton1.TabIndex = 1
        Me.ImsButton1.Text = "&SELECT"
        Me.ImsButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = True
        '
        'ChooseItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.Button2
        Me.ClientSize = New System.Drawing.Size(905, 530)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChooseItems"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Choose Items"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TxtStockDes As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtStockName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtStockCode As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtLocation As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtOnlyServices As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnCreate As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MmToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
