﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Coupons
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActivateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TxtLedgerName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnNew = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnEdit = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnDelete = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton4 = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnActivate = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(946, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "COUPONS MANAGEMENT"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtList, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.17849!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.610984!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.21053!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(952, 491)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Controls.Add(Me.TxtLedgerName)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 26)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(952, 41)
        Me.Panel1.TabIndex = 4
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(835, 4)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(202, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.PrintToolStripMenuItem, Me.CloseToolStripMenuItem, Me.ReloadToolStripMenuItem, Me.ActivateToolStripMenuItem})
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
        Me.EditToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
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
        Me.ReloadToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.ReloadToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ReloadToolStripMenuItem.Text = "Reload "
        '
        'ActivateToolStripMenuItem
        '
        Me.ActivateToolStripMenuItem.Name = "ActivateToolStripMenuItem"
        Me.ActivateToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.ActivateToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ActivateToolStripMenuItem.Text = "Activate"
        '
        'TxtLedgerName
        '
        Me.TxtLedgerName.AllowToolTip = True
        Me.TxtLedgerName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtLedgerName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLedgerName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLedgerName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtLedgerName.IsAllowDigits = True
        Me.TxtLedgerName.IsAllowSpace = True
        Me.TxtLedgerName.IsAllowSplChars = True
        Me.TxtLedgerName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLedgerName.Location = New System.Drawing.Point(117, 7)
        Me.TxtLedgerName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLedgerName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtLedgerName.MaxLength = 75
        Me.TxtLedgerName.Name = "TxtLedgerName"
        Me.TxtLedgerName.SetToolTip = Nothing
        Me.TxtLedgerName.Size = New System.Drawing.Size(197, 20)
        Me.TxtLedgerName.SpecialCharList = "&-/@"
        Me.TxtLedgerName.TabIndex = 3
        Me.TxtLedgerName.UseFunctionKeys = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(12, 11)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(101, 13)
        Me.ImSlabel1.TabIndex = 2
        Me.ImSlabel1.Text = "Search By Name"
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
        Me.TxtList.Location = New System.Drawing.Point(3, 70)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.RowHeadersWidth = 30
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(946, 356)
        Me.TxtList.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnNew, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnEdit, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnDelete, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton4, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnActivate, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 432)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(946, 56)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton1.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.ImsButton1.Location = New System.Drawing.Point(3, 3)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(151, 50)
        Me.ImsButton1.TabIndex = 0
        Me.ImsButton1.Text = "CLOSE"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = True
        '
        'BtnNew
        '
        Me.BtnNew.AllowToolTip = True
        Me.BtnNew.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNew.ForeColor = System.Drawing.Color.Navy
        Me.BtnNew.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnNew.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361186619_document_new
        Me.BtnNew.Location = New System.Drawing.Point(788, 3)
        Me.BtnNew.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.SetToolTip = ""
        Me.BtnNew.Size = New System.Drawing.Size(155, 50)
        Me.BtnNew.TabIndex = 0
        Me.BtnNew.Text = "NEW"
        Me.BtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnNew.UseFunctionKeys = False
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'BtnEdit
        '
        Me.BtnEdit.AllowToolTip = True
        Me.BtnEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.ForeColor = System.Drawing.Color.Navy
        Me.BtnEdit.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnEdit.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361188505_file_edit
        Me.BtnEdit.Location = New System.Drawing.Point(631, 3)
        Me.BtnEdit.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.SetToolTip = ""
        Me.BtnEdit.Size = New System.Drawing.Size(151, 50)
        Me.BtnEdit.TabIndex = 0
        Me.BtnEdit.Text = "EDIT"
        Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnEdit.UseFunctionKeys = False
        Me.BtnEdit.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.AllowToolTip = True
        Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.Navy
        Me.BtnDelete.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnDelete.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.delete__2_
        Me.BtnDelete.Location = New System.Drawing.Point(474, 3)
        Me.BtnDelete.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.SetToolTip = ""
        Me.BtnDelete.Size = New System.Drawing.Size(151, 50)
        Me.BtnDelete.TabIndex = 0
        Me.BtnDelete.Text = "DELETE"
        Me.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDelete.UseFunctionKeys = False
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'ImsButton4
        '
        Me.ImsButton4.AllowToolTip = True
        Me.ImsButton4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton4.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton4.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton4.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.print__1_
        Me.ImsButton4.Location = New System.Drawing.Point(317, 3)
        Me.ImsButton4.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton4.Name = "ImsButton4"
        Me.ImsButton4.SetToolTip = ""
        Me.ImsButton4.Size = New System.Drawing.Size(151, 50)
        Me.ImsButton4.TabIndex = 0
        Me.ImsButton4.Text = "PRINT"
        Me.ImsButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton4.UseFunctionKeys = False
        Me.ImsButton4.UseVisualStyleBackColor = True
        '
        'BtnActivate
        '
        Me.BtnActivate.AllowToolTip = True
        Me.BtnActivate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnActivate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnActivate.ForeColor = System.Drawing.Color.Navy
        Me.BtnActivate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnActivate.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.key
        Me.BtnActivate.Location = New System.Drawing.Point(160, 3)
        Me.BtnActivate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnActivate.Name = "BtnActivate"
        Me.BtnActivate.SetToolTip = ""
        Me.BtnActivate.Size = New System.Drawing.Size(151, 50)
        Me.BtnActivate.TabIndex = 0
        Me.BtnActivate.Text = "DeActivate"
        Me.BtnActivate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnActivate.UseFunctionKeys = False
        Me.BtnActivate.UseVisualStyleBackColor = True
        '
        'Coupons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 491)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Coupons"
        Me.Text = "COUPONS MANAGEMENT"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActivateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxtLedgerName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnNew As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnEdit As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnDelete As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton4 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnActivate As JyothiPharmaERPSystem3.IMSButton
End Class
