<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CurrencyExchageRates
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton4 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton3 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton5 = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TxtCurCode = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtFilterByCurName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.6383!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.44681!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(813, 477)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(813, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "EXCHANGE RATES FOR CURRIENCIES"
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
        Me.TxtList.Location = New System.Drawing.Point(3, 76)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.RowHeadersWidth = 30
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.TxtList.Size = New System.Drawing.Size(807, 342)
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
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton4, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton2, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton3, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton5, 5, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 424)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(807, 50)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'ImsButton1
        '
        Me.ImsButton1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton1.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.ImsButton1.Location = New System.Drawing.Point(23, 3)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.Size = New System.Drawing.Size(144, 44)
        Me.ImsButton1.TabIndex = 0
        Me.ImsButton1.Text = "ESC-CLOSE"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = True
        '
        'ImsButton4
        '
        Me.ImsButton4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton4.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton4.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton4.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.print__1_
        Me.ImsButton4.Location = New System.Drawing.Point(173, 3)
        Me.ImsButton4.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton4.Name = "ImsButton4"
        Me.ImsButton4.Size = New System.Drawing.Size(144, 44)
        Me.ImsButton4.TabIndex = 0
        Me.ImsButton4.Text = "PRINT"
        Me.ImsButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton4.UseFunctionKeys = False
        Me.ImsButton4.UseVisualStyleBackColor = True
        '
        'ImsButton2
        '
        Me.ImsButton2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton2.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton2.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.delete__2_
        Me.ImsButton2.Location = New System.Drawing.Point(323, 3)
        Me.ImsButton2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton2.Name = "ImsButton2"
        Me.ImsButton2.Size = New System.Drawing.Size(144, 44)
        Me.ImsButton2.TabIndex = 0
        Me.ImsButton2.Text = "DELETE"
        Me.ImsButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton2.UseFunctionKeys = False
        Me.ImsButton2.UseVisualStyleBackColor = True
        '
        'ImsButton3
        '
        Me.ImsButton3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton3.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton3.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton3.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361188505_file_edit
        Me.ImsButton3.Location = New System.Drawing.Point(473, 3)
        Me.ImsButton3.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton3.Name = "ImsButton3"
        Me.ImsButton3.Size = New System.Drawing.Size(144, 44)
        Me.ImsButton3.TabIndex = 0
        Me.ImsButton3.Text = "EDIT"
        Me.ImsButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton3.UseFunctionKeys = False
        Me.ImsButton3.UseVisualStyleBackColor = True
        '
        'ImsButton5
        '
        Me.ImsButton5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsButton5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton5.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton5.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton5.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361186619_document_new
        Me.ImsButton5.Location = New System.Drawing.Point(623, 3)
        Me.ImsButton5.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton5.Name = "ImsButton5"
        Me.ImsButton5.Size = New System.Drawing.Size(144, 44)
        Me.ImsButton5.TabIndex = 0
        Me.ImsButton5.Text = "NEW"
        Me.ImsButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton5.UseFunctionKeys = False
        Me.ImsButton5.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Controls.Add(Me.TxtCurCode)
        Me.Panel1.Controls.Add(Me.ImSlabel2)
        Me.Panel1.Controls.Add(Me.TxtFilterByCurName)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 29)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(813, 44)
        Me.Panel1.TabIndex = 3
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(725, 4)
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
        Me.NewToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.PrintToolStripMenuItem.Text = "print"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.CloseToolStripMenuItem.Text = "close"
        '
        'ReloadToolStripMenuItem
        '
        Me.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem"
        Me.ReloadToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.ReloadToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.ReloadToolStripMenuItem.Text = "Reload "
        '
        'TxtCurCode
        '
        Me.TxtCurCode.AllowToolTip = True
        Me.TxtCurCode.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtCurCode.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCurCode.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCurCode.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtCurCode.IsAllowDigits = True
        Me.TxtCurCode.IsAllowSpace = True
        Me.TxtCurCode.IsAllowSplChars = True
        Me.TxtCurCode.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCurCode.Location = New System.Drawing.Point(528, 12)
        Me.TxtCurCode.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCurCode.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtCurCode.MaxLength = 75
        Me.TxtCurCode.Name = "TxtCurCode"
        Me.TxtCurCode.Size = New System.Drawing.Size(166, 20)
        Me.TxtCurCode.SpecialCharList = "&-/@"
        Me.TxtCurCode.TabIndex = 1
        Me.TxtCurCode.UseFunctionKeys = False
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(425, 16)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(97, 13)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "Search by Code"
        '
        'TxtFilterByCurName
        '
        Me.TxtFilterByCurName.AllowToolTip = True
        Me.TxtFilterByCurName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtFilterByCurName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtFilterByCurName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtFilterByCurName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtFilterByCurName.IsAllowDigits = True
        Me.TxtFilterByCurName.IsAllowSpace = True
        Me.TxtFilterByCurName.IsAllowSplChars = True
        Me.TxtFilterByCurName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtFilterByCurName.Location = New System.Drawing.Point(178, 12)
        Me.TxtFilterByCurName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtFilterByCurName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtFilterByCurName.MaxLength = 75
        Me.TxtFilterByCurName.Name = "TxtFilterByCurName"
        Me.TxtFilterByCurName.Size = New System.Drawing.Size(177, 20)
        Me.TxtFilterByCurName.SpecialCharList = "&-/@"
        Me.TxtFilterByCurName.TabIndex = 1
        Me.TxtFilterByCurName.UseFunctionKeys = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(12, 15)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(155, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "Search By Currency Name"
        '
        'CurrencyExchageRates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 477)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CurrencyExchageRates"
        Me.Text = "Currency Exchage Rates"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton4 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtFilterByCurName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtCurCode As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImsButton2 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton3 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton5 As JyothiPharmaERPSystem3.IMSButton
End Class
