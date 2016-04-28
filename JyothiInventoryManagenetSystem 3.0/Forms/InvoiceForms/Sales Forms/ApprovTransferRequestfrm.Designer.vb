<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ApprovTransferRequestfrm
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ApprovTransferRequestfrm))
        Me.TxtTitle = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtLocation = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.panel222 = New System.Windows.Forms.Panel()
        Me.BtnApprove = New JyothiPharmaERPSystem3.IMSButton()
        Me.btnDisply = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnPrint = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton3 = New JyothiPharmaERPSystem3.IMSButton()
        Me.IsShowPendingsOnly = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.panel222.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtTitle
        '
        Me.TxtTitle.BackColor = System.Drawing.Color.DarkOrange
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtTitle, 2)
        Me.TxtTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitle.ForeColor = System.Drawing.Color.White
        Me.TxtTitle.Location = New System.Drawing.Point(0, 0)
        Me.TxtTitle.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(919, 26)
        Me.TxtTitle.TabIndex = 0
        Me.TxtTitle.Text = "APPROVE TRANSFER REQUEST"
        Me.TxtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.CloseToolStripMenuItem.Text = "close"
        '
        'TxtEndDate
        '
        Me.TxtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEndDate.Location = New System.Drawing.Point(147, 25)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(125, 20)
        Me.TxtEndDate.TabIndex = 1
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
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
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
        Me.TxtList.Location = New System.Drawing.Point(3, 84)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(746, 413)
        Me.TxtList.TabIndex = 2
        '
        'TxtStartDate
        '
        Me.TxtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtStartDate.Location = New System.Drawing.Point(16, 25)
        Me.TxtStartDate.Name = "TxtStartDate"
        Me.TxtStartDate.Size = New System.Drawing.Size(125, 20)
        Me.TxtStartDate.TabIndex = 1
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Controls.Add(Me.ImsButton1)
        Me.Panel1.Controls.Add(Me.TxtLocation)
        Me.Panel1.Controls.Add(Me.TxtEndDate)
        Me.Panel1.Controls.Add(Me.TxtStartDate)
        Me.Panel1.Controls.Add(Me.ImSlabel2)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(1, 27)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(917, 53)
        Me.Panel1.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(417, 14)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(202, 24)
        Me.MenuStrip1.TabIndex = 51
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.PrintToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        Me.MenuToolStripMenuItem.Visible = False
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.BackColor = System.Drawing.Color.White
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = CType(resources.GetObject("ImsButton1.Image"), System.Drawing.Image)
        Me.ImsButton1.Location = New System.Drawing.Point(278, 13)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(63, 35)
        Me.ImsButton1.TabIndex = 3
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = False
        '
        'TxtLocation
        '
        Me.TxtLocation.AllowEmpty = True
        Me.TxtLocation.AllowOnlyListValues = False
        Me.TxtLocation.AllowToolTip = True
        Me.TxtLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtLocation.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtLocation.FormattingEnabled = True
        Me.TxtLocation.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLocation.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLocation.IsAdvanceSearchWindow = True
        Me.TxtLocation.IsAllowDigits = True
        Me.TxtLocation.IsAllowSpace = True
        Me.TxtLocation.IsAllowSplChars = True
        Me.TxtLocation.IsAllowToolTip = True
        Me.TxtLocation.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLocation.Location = New System.Drawing.Point(353, 23)
        Me.TxtLocation.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLocation.Name = "TxtLocation"
        Me.TxtLocation.SetToolTip = Nothing
        Me.TxtLocation.Size = New System.Drawing.Size(280, 21)
        Me.TxtLocation.Sorted = True
        Me.TxtLocation.SpecialCharList = "&-/@"
        Me.TxtLocation.TabIndex = 2
        Me.TxtLocation.UseFunctionKeys = False
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(357, 6)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(105, 13)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "Filter by Location"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(18, 9)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(87, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "Date Between"
        '
        'panel222
        '
        Me.panel222.Controls.Add(Me.BtnApprove)
        Me.panel222.Controls.Add(Me.btnDisply)
        Me.panel222.Controls.Add(Me.BtnPrint)
        Me.panel222.Controls.Add(Me.ImsButton3)
        Me.panel222.Controls.Add(Me.IsShowPendingsOnly)
        Me.panel222.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel222.Location = New System.Drawing.Point(755, 84)
        Me.panel222.Name = "panel222"
        Me.panel222.Size = New System.Drawing.Size(161, 413)
        Me.panel222.TabIndex = 3
        '
        'BtnApprove
        '
        Me.BtnApprove.AllowToolTip = True
        Me.BtnApprove.BackColor = System.Drawing.Color.White
        Me.BtnApprove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnApprove.ForeColor = System.Drawing.Color.Navy
        Me.BtnApprove.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnApprove.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.key
        Me.BtnApprove.Location = New System.Drawing.Point(3, 66)
        Me.BtnApprove.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnApprove.Name = "BtnApprove"
        Me.BtnApprove.SetToolTip = ""
        Me.BtnApprove.Size = New System.Drawing.Size(153, 39)
        Me.BtnApprove.TabIndex = 5
        Me.BtnApprove.Text = "APPROVE"
        Me.BtnApprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnApprove.UseFunctionKeys = False
        Me.BtnApprove.UseVisualStyleBackColor = False
        '
        'btnDisply
        '
        Me.btnDisply.AllowToolTip = True
        Me.btnDisply.BackColor = System.Drawing.Color.White
        Me.btnDisply.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDisply.ForeColor = System.Drawing.Color.Navy
        Me.btnDisply.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnDisply.Image = CType(resources.GetObject("btnDisply.Image"), System.Drawing.Image)
        Me.btnDisply.Location = New System.Drawing.Point(3, 133)
        Me.btnDisply.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnDisply.Name = "btnDisply"
        Me.btnDisply.SetToolTip = ""
        Me.btnDisply.Size = New System.Drawing.Size(153, 39)
        Me.btnDisply.TabIndex = 5
        Me.btnDisply.Text = "Show Details"
        Me.btnDisply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDisply.UseFunctionKeys = False
        Me.btnDisply.UseVisualStyleBackColor = False
        '
        'BtnPrint
        '
        Me.BtnPrint.AllowToolTip = True
        Me.BtnPrint.BackColor = System.Drawing.Color.White
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.Navy
        Me.BtnPrint.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(3, 201)
        Me.BtnPrint.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.SetToolTip = ""
        Me.BtnPrint.Size = New System.Drawing.Size(153, 39)
        Me.BtnPrint.TabIndex = 5
        Me.BtnPrint.Text = "PRINT"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseFunctionKeys = False
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'ImsButton3
        '
        Me.ImsButton3.AllowToolTip = True
        Me.ImsButton3.BackColor = System.Drawing.Color.White
        Me.ImsButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton3.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton3.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton3.Image = CType(resources.GetObject("ImsButton3.Image"), System.Drawing.Image)
        Me.ImsButton3.Location = New System.Drawing.Point(3, 264)
        Me.ImsButton3.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton3.Name = "ImsButton3"
        Me.ImsButton3.SetToolTip = ""
        Me.ImsButton3.Size = New System.Drawing.Size(153, 39)
        Me.ImsButton3.TabIndex = 4
        Me.ImsButton3.Text = "CLOSE"
        Me.ImsButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton3.UseFunctionKeys = False
        Me.ImsButton3.UseVisualStyleBackColor = False
        '
        'IsShowPendingsOnly
        '
        Me.IsShowPendingsOnly.AutoSize = True
        Me.IsShowPendingsOnly.Checked = True
        Me.IsShowPendingsOnly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IsShowPendingsOnly.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsShowPendingsOnly.Location = New System.Drawing.Point(3, 14)
        Me.IsShowPendingsOnly.Name = "IsShowPendingsOnly"
        Me.IsShowPendingsOnly.Size = New System.Drawing.Size(142, 17)
        Me.IsShowPendingsOnly.TabIndex = 0
        Me.IsShowPendingsOnly.Text = "Show Only Pendings"
        Me.IsShowPendingsOnly.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtTitle, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtList, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.panel222, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(919, 500)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'ApprovTransferRequestfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(919, 500)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ApprovTransferRequestfrm"
        Me.Text = "ApprovTransferRequestfrm"
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.panel222.ResumeLayout(False)
        Me.panel222.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtTitle As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtLocation As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents panel222 As System.Windows.Forms.Panel
    Friend WithEvents BtnApprove As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnPrint As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton3 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents IsShowPendingsOnly As System.Windows.Forms.CheckBox
    Friend WithEvents btnDisply As JyothiPharmaERPSystem3.IMSButton
End Class
