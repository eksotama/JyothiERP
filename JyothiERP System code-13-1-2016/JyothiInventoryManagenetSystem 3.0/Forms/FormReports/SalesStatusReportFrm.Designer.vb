﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesStatusReportFrm
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
        Me.PrtDoc = New System.Drawing.Printing.PrintDocument()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtSalesArea = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtSalesPerson = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtLedgerName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtTitle = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.panel222 = New System.Windows.Forms.Panel()
        Me.TxtShowDetailed = New System.Windows.Forms.CheckBox()
        Me.ImsButton4 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton3 = New JyothiPharmaERPSystem3.IMSButton()
        Me.IsShowPendingsOnly = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel222.SuspendLayout()
        Me.SuspendLayout()
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.CloseToolStripMenuItem.Text = "close"
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
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.PrintToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        Me.MenuToolStripMenuItem.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(434, 14)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(58, 24)
        Me.MenuStrip1.TabIndex = 51
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Controls.Add(Me.ImsButton1)
        Me.Panel1.Controls.Add(Me.TxtSalesArea)
        Me.Panel1.Controls.Add(Me.TxtSalesPerson)
        Me.Panel1.Controls.Add(Me.TxtLedgerName)
        Me.Panel1.Controls.Add(Me.ImSlabel4)
        Me.Panel1.Controls.Add(Me.TxtEndDate)
        Me.Panel1.Controls.Add(Me.ImSlabel3)
        Me.Panel1.Controls.Add(Me.TxtStartDate)
        Me.Panel1.Controls.Add(Me.ImSlabel2)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(1, 27)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(970, 53)
        Me.Panel1.TabIndex = 1
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361188212_Binoculars
        Me.ImsButton1.Location = New System.Drawing.Point(278, 13)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(63, 35)
        Me.ImsButton1.TabIndex = 3
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = True
        '
        'TxtSalesArea
        '
        Me.TxtSalesArea.AllowEmpty = True
        Me.TxtSalesArea.AllowOnlyListValues = False
        Me.TxtSalesArea.AllowToolTip = True
        Me.TxtSalesArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtSalesArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtSalesArea.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtSalesArea.FormattingEnabled = True
        Me.TxtSalesArea.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSalesArea.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSalesArea.IsAllowDigits = True
        Me.TxtSalesArea.IsAllowSpace = True
        Me.TxtSalesArea.IsAllowSplChars = True
        Me.TxtSalesArea.IsAllowToolTip = True
        Me.TxtSalesArea.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSalesArea.Location = New System.Drawing.Point(741, 24)
        Me.TxtSalesArea.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSalesArea.Name = "TxtSalesArea"
        Me.TxtSalesArea.Size = New System.Drawing.Size(182, 21)
        Me.TxtSalesArea.Sorted = True
        Me.TxtSalesArea.SpecialCharList = "&-/@"
        Me.TxtSalesArea.TabIndex = 2
        Me.TxtSalesArea.UseFunctionKeys = False
        '
        'TxtSalesPerson
        '
        Me.TxtSalesPerson.AllowEmpty = True
        Me.TxtSalesPerson.AllowOnlyListValues = False
        Me.TxtSalesPerson.AllowToolTip = True
        Me.TxtSalesPerson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtSalesPerson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtSalesPerson.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtSalesPerson.FormattingEnabled = True
        Me.TxtSalesPerson.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSalesPerson.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSalesPerson.IsAllowDigits = True
        Me.TxtSalesPerson.IsAllowSpace = True
        Me.TxtSalesPerson.IsAllowSplChars = True
        Me.TxtSalesPerson.IsAllowToolTip = True
        Me.TxtSalesPerson.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSalesPerson.Location = New System.Drawing.Point(542, 24)
        Me.TxtSalesPerson.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSalesPerson.Name = "TxtSalesPerson"
        Me.TxtSalesPerson.Size = New System.Drawing.Size(182, 21)
        Me.TxtSalesPerson.Sorted = True
        Me.TxtSalesPerson.SpecialCharList = "&-/@"
        Me.TxtSalesPerson.TabIndex = 2
        Me.TxtSalesPerson.UseFunctionKeys = False
        '
        'TxtLedgerName
        '
        Me.TxtLedgerName.AllowEmpty = True
        Me.TxtLedgerName.AllowOnlyListValues = False
        Me.TxtLedgerName.AllowToolTip = True
        Me.TxtLedgerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtLedgerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtLedgerName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtLedgerName.FormattingEnabled = True
        Me.TxtLedgerName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLedgerName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLedgerName.IsAllowDigits = True
        Me.TxtLedgerName.IsAllowSpace = True
        Me.TxtLedgerName.IsAllowSplChars = True
        Me.TxtLedgerName.IsAllowToolTip = True
        Me.TxtLedgerName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLedgerName.Location = New System.Drawing.Point(353, 23)
        Me.TxtLedgerName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLedgerName.Name = "TxtLedgerName"
        Me.TxtLedgerName.Size = New System.Drawing.Size(182, 21)
        Me.TxtLedgerName.Sorted = True
        Me.TxtLedgerName.SpecialCharList = "&-/@"
        Me.TxtLedgerName.TabIndex = 2
        Me.TxtLedgerName.UseFunctionKeys = False
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(745, 7)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(83, 13)
        Me.ImSlabel4.TabIndex = 0
        Me.ImSlabel4.Text = "Filter By Area"
        '
        'TxtEndDate
        '
        Me.TxtEndDate.Location = New System.Drawing.Point(147, 25)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(125, 20)
        Me.TxtEndDate.TabIndex = 1
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(546, 7)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(131, 13)
        Me.ImSlabel3.TabIndex = 0
        Me.ImSlabel3.Text = "Filter By Sales Person"
        '
        'TxtStartDate
        '
        Me.TxtStartDate.Location = New System.Drawing.Point(16, 25)
        Me.TxtStartDate.Name = "TxtStartDate"
        Me.TxtStartDate.Size = New System.Drawing.Size(125, 20)
        Me.TxtStartDate.TabIndex = 1
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(357, 6)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(145, 13)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "Filter By Customer Name"
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
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170.0!))
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(972, 466)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'TxtTitle
        '
        Me.TxtTitle.BackColor = System.Drawing.Color.Green
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtTitle, 2)
        Me.TxtTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitle.ForeColor = System.Drawing.Color.White
        Me.TxtTitle.Location = New System.Drawing.Point(0, 0)
        Me.TxtTitle.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(972, 26)
        Me.TxtTitle.TabIndex = 0
        Me.TxtTitle.Text = "SALES COLLECTION REPORT"
        Me.TxtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToResizeRows = False
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.Location = New System.Drawing.Point(3, 84)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(796, 379)
        Me.TxtList.TabIndex = 2
        '
        'panel222
        '
        Me.panel222.Controls.Add(Me.TxtShowDetailed)
        Me.panel222.Controls.Add(Me.ImsButton4)
        Me.panel222.Controls.Add(Me.ImsButton3)
        Me.panel222.Controls.Add(Me.IsShowPendingsOnly)
        Me.panel222.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel222.Location = New System.Drawing.Point(805, 84)
        Me.panel222.Name = "panel222"
        Me.panel222.Size = New System.Drawing.Size(164, 379)
        Me.panel222.TabIndex = 3
        '
        'TxtShowDetailed
        '
        Me.TxtShowDetailed.AutoSize = True
        Me.TxtShowDetailed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShowDetailed.Location = New System.Drawing.Point(4, 86)
        Me.TxtShowDetailed.Name = "TxtShowDetailed"
        Me.TxtShowDetailed.Size = New System.Drawing.Size(137, 17)
        Me.TxtShowDetailed.TabIndex = 6
        Me.TxtShowDetailed.Text = "Print salesman wise"
        Me.TxtShowDetailed.UseVisualStyleBackColor = True
        '
        'ImsButton4
        '
        Me.ImsButton4.AllowToolTip = True
        Me.ImsButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton4.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton4.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton4.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.print__1_
        Me.ImsButton4.Location = New System.Drawing.Point(3, 109)
        Me.ImsButton4.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton4.Name = "ImsButton4"
        Me.ImsButton4.SetToolTip = ""
        Me.ImsButton4.Size = New System.Drawing.Size(161, 46)
        Me.ImsButton4.TabIndex = 5
        Me.ImsButton4.Text = "PRINT"
        Me.ImsButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton4.UseFunctionKeys = False
        Me.ImsButton4.UseVisualStyleBackColor = True
        '
        'ImsButton3
        '
        Me.ImsButton3.AllowToolTip = True
        Me.ImsButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton3.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton3.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton3.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.ImsButton3.Location = New System.Drawing.Point(0, 218)
        Me.ImsButton3.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton3.Name = "ImsButton3"
        Me.ImsButton3.SetToolTip = ""
        Me.ImsButton3.Size = New System.Drawing.Size(161, 46)
        Me.ImsButton3.TabIndex = 4
        Me.ImsButton3.Text = "CLOSE"
        Me.ImsButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton3.UseFunctionKeys = False
        Me.ImsButton3.UseVisualStyleBackColor = True
        '
        'IsShowPendingsOnly
        '
        Me.IsShowPendingsOnly.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsShowPendingsOnly.Location = New System.Drawing.Point(3, 14)
        Me.IsShowPendingsOnly.Name = "IsShowPendingsOnly"
        Me.IsShowPendingsOnly.Size = New System.Drawing.Size(152, 41)
        Me.IsShowPendingsOnly.TabIndex = 0
        Me.IsShowPendingsOnly.Text = "Show Only PDC Pendings"
        Me.IsShowPendingsOnly.UseVisualStyleBackColor = True
        Me.IsShowPendingsOnly.Visible = False
        '
        'SalesStatusReportFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 466)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "SalesStatusReportFrm"
        Me.Text = "Sales Collection Report"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel222.ResumeLayout(False)
        Me.panel222.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PrtDoc As System.Drawing.Printing.PrintDocument
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtSalesArea As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtSalesPerson As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtLedgerName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtTitle As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents panel222 As System.Windows.Forms.Panel
    Friend WithEvents ImsButton3 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents IsShowPendingsOnly As System.Windows.Forms.CheckBox
    Friend WithEvents ImsButton4 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtShowDetailed As System.Windows.Forms.CheckBox
End Class
