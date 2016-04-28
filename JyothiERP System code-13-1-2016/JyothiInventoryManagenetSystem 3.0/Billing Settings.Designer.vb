<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Billing_Settings
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiInventoryManagenetSystem_3._0.IMSButton()
        Me.BtnCreate = New JyothiInventoryManagenetSystem_3._0.IMSButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtInvoicePostFix = New JyothiInventoryManagenetSystem_3._0.IMSTextBox()
        Me.TxtInvoicePreFix = New JyothiInventoryManagenetSystem_3._0.IMSTextBox()
        Me.TxtInvoicenoStart = New JyothiInventoryManagenetSystem_3._0.IMSNumericTextBox()
        Me.TxtAllowDuplicates = New JyothiInventoryManagenetSystem_3._0.IMSComboBox()
        Me.TxtInvoiceMethod = New JyothiInventoryManagenetSystem_3._0.IMSComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtTitle = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblAllowDuplicates = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtSelectedSettings = New JyothiInventoryManagenetSystem_3._0.IMSComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtStatus, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(496, 418)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TxtStatus
        '
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Green
        Me.TxtStatus.Location = New System.Drawing.Point(3, 387)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(490, 31)
        Me.TxtStatus.TabIndex = 4
        Me.TxtStatus.Text = "Status: Ready"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.BtnClose)
        Me.Panel3.Controls.Add(Me.BtnCreate)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 333)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(490, 51)
        Me.Panel3.TabIndex = 3
        '
        'BtnClose
        '
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiInventoryManagenetSystem_3._0.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(32, 3)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(161, 43)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnCreate
        '
        Me.BtnCreate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCreate.Image = Global.JyothiInventoryManagenetSystem_3._0.My.Resources.Resources.Save__1_
        Me.BtnCreate.Location = New System.Drawing.Point(271, 3)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.Size = New System.Drawing.Size(175, 43)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "Save"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(496, 40)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "INVOICE BILLING SETTINGS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.TxtSelectedSettings)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 43)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(490, 284)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtInvoicePostFix)
        Me.Panel2.Controls.Add(Me.TxtInvoicePreFix)
        Me.Panel2.Controls.Add(Me.TxtInvoicenoStart)
        Me.Panel2.Controls.Add(Me.TxtAllowDuplicates)
        Me.Panel2.Controls.Add(Me.TxtInvoiceMethod)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.TxtTitle)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.lblAllowDuplicates)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Enabled = False
        Me.Panel2.Location = New System.Drawing.Point(34, 47)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(389, 234)
        Me.Panel2.TabIndex = 15
        '
        'TxtInvoicePostFix
        '
        Me.TxtInvoicePostFix.CharcterCase = JyothiInventoryManagenetSystem_3._0.IMSTextBox.ChangCaseValues.Title
        Me.TxtInvoicePostFix.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtInvoicePostFix.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtInvoicePostFix.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtInvoicePostFix.IsAllowDigits = True
        Me.TxtInvoicePostFix.IsAllowSpace = True
        Me.TxtInvoicePostFix.IsAllowSplChars = True
        Me.TxtInvoicePostFix.LFocusBackColor = System.Drawing.Color.White
        Me.TxtInvoicePostFix.Location = New System.Drawing.Point(205, 182)
        Me.TxtInvoicePostFix.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtInvoicePostFix.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtInvoicePostFix.MaxLength = 75
        Me.TxtInvoicePostFix.Name = "TxtInvoicePostFix"
        Me.TxtInvoicePostFix.Size = New System.Drawing.Size(176, 20)
        Me.TxtInvoicePostFix.SpecialCharList = "&-/@"
        Me.TxtInvoicePostFix.TabIndex = 21
        Me.TxtInvoicePostFix.UseFunctionKeys = False
        '
        'TxtInvoicePreFix
        '
        Me.TxtInvoicePreFix.CharcterCase = JyothiInventoryManagenetSystem_3._0.IMSTextBox.ChangCaseValues.Title
        Me.TxtInvoicePreFix.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtInvoicePreFix.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtInvoicePreFix.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtInvoicePreFix.IsAllowDigits = True
        Me.TxtInvoicePreFix.IsAllowSpace = True
        Me.TxtInvoicePreFix.IsAllowSplChars = True
        Me.TxtInvoicePreFix.LFocusBackColor = System.Drawing.Color.White
        Me.TxtInvoicePreFix.Location = New System.Drawing.Point(205, 147)
        Me.TxtInvoicePreFix.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtInvoicePreFix.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtInvoicePreFix.MaxLength = 75
        Me.TxtInvoicePreFix.Name = "TxtInvoicePreFix"
        Me.TxtInvoicePreFix.Size = New System.Drawing.Size(176, 20)
        Me.TxtInvoicePreFix.SpecialCharList = "&-/@"
        Me.TxtInvoicePreFix.TabIndex = 22
        Me.TxtInvoicePreFix.UseFunctionKeys = False
        '
        'TxtInvoicenoStart
        '
        Me.TxtInvoicenoStart.AllHelpText = True
        Me.TxtInvoicenoStart.AllowDecimal = False
        Me.TxtInvoicenoStart.AllowFormulas = False
        Me.TxtInvoicenoStart.AllowForQty = True
        Me.TxtInvoicenoStart.AllowNegative = False
        Me.TxtInvoicenoStart.AllowPerSign = False
        Me.TxtInvoicenoStart.AllowPlusSign = False
        Me.TxtInvoicenoStart.AllowToolTip = True
        Me.TxtInvoicenoStart.DecimalPlaces = CType(2, Short)
        Me.TxtInvoicenoStart.ExitOnEscKey = True
        Me.TxtInvoicenoStart.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtInvoicenoStart.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtInvoicenoStart.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtInvoicenoStart.HelpText = Nothing
        Me.TxtInvoicenoStart.LFocusBackColor = System.Drawing.Color.White
        Me.TxtInvoicenoStart.Location = New System.Drawing.Point(205, 116)
        Me.TxtInvoicenoStart.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtInvoicenoStart.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtInvoicenoStart.Max = CType(100000000000000, Long)
        Me.TxtInvoicenoStart.Min = CType(0, Long)
        Me.TxtInvoicenoStart.Name = "TxtInvoicenoStart"
        Me.TxtInvoicenoStart.NextOnEnter = True
        Me.TxtInvoicenoStart.Size = New System.Drawing.Size(178, 20)
        Me.TxtInvoicenoStart.TabIndex = 20
        Me.TxtInvoicenoStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtInvoicenoStart.ToolTip = Nothing
        Me.TxtInvoicenoStart.UseFunctionKeys = False
        Me.TxtInvoicenoStart.UseUpDownArrowKeys = False
        '
        'TxtAllowDuplicates
        '
        Me.TxtAllowDuplicates.AllowEmpty = True
        Me.TxtAllowDuplicates.AllowOnlyListValues = True
        Me.TxtAllowDuplicates.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtAllowDuplicates.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtAllowDuplicates.CharcterCase = JyothiInventoryManagenetSystem_3._0.IMSComboBox.ChangCaseValues.Title
        Me.TxtAllowDuplicates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtAllowDuplicates.FormattingEnabled = True
        Me.TxtAllowDuplicates.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtAllowDuplicates.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtAllowDuplicates.IsAllowDigits = True
        Me.TxtAllowDuplicates.IsAllowSpace = True
        Me.TxtAllowDuplicates.IsAllowSplChars = True
        Me.TxtAllowDuplicates.Items.AddRange(New Object() {"NO", "YES"})
        Me.TxtAllowDuplicates.LFocusBackColor = System.Drawing.Color.White
        Me.TxtAllowDuplicates.Location = New System.Drawing.Point(203, 88)
        Me.TxtAllowDuplicates.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtAllowDuplicates.Name = "TxtAllowDuplicates"
        Me.TxtAllowDuplicates.Size = New System.Drawing.Size(178, 21)
        Me.TxtAllowDuplicates.Sorted = True
        Me.TxtAllowDuplicates.SpecialCharList = "&-/@"
        Me.TxtAllowDuplicates.TabIndex = 19
        Me.TxtAllowDuplicates.UseFunctionKeys = False
        '
        'TxtInvoiceMethod
        '
        Me.TxtInvoiceMethod.AllowEmpty = True
        Me.TxtInvoiceMethod.AllowOnlyListValues = True
        Me.TxtInvoiceMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtInvoiceMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtInvoiceMethod.CharcterCase = JyothiInventoryManagenetSystem_3._0.IMSComboBox.ChangCaseValues.Title
        Me.TxtInvoiceMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtInvoiceMethod.FormattingEnabled = True
        Me.TxtInvoiceMethod.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtInvoiceMethod.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtInvoiceMethod.IsAllowDigits = True
        Me.TxtInvoiceMethod.IsAllowSpace = True
        Me.TxtInvoiceMethod.IsAllowSplChars = True
        Me.TxtInvoiceMethod.Items.AddRange(New Object() {"Automatic", "Manual"})
        Me.TxtInvoiceMethod.LFocusBackColor = System.Drawing.Color.White
        Me.TxtInvoiceMethod.Location = New System.Drawing.Point(205, 56)
        Me.TxtInvoiceMethod.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtInvoiceMethod.Name = "TxtInvoiceMethod"
        Me.TxtInvoiceMethod.Size = New System.Drawing.Size(178, 21)
        Me.TxtInvoiceMethod.Sorted = True
        Me.TxtInvoiceMethod.SpecialCharList = "&-/@"
        Me.TxtInvoiceMethod.TabIndex = 19
        Me.TxtInvoiceMethod.UseFunctionKeys = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Invoice Post Fix"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Invoice Pre Fix"
        '
        'TxtTitle
        '
        Me.TxtTitle.BackColor = System.Drawing.Color.Green
        Me.TxtTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitle.ForeColor = System.Drawing.Color.White
        Me.TxtTitle.Location = New System.Drawing.Point(6, 16)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(375, 19)
        Me.TxtTitle.TabIndex = 17
        Me.TxtTitle.Text = "SALES "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(174, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Method of Invoice Numbering"
        '
        'lblAllowDuplicates
        '
        Me.lblAllowDuplicates.AutoSize = True
        Me.lblAllowDuplicates.Location = New System.Drawing.Point(6, 88)
        Me.lblAllowDuplicates.Name = "lblAllowDuplicates"
        Me.lblAllowDuplicates.Size = New System.Drawing.Size(175, 13)
        Me.lblAllowDuplicates.TabIndex = 15
        Me.lblAllowDuplicates.Text = "Invoice Number Starting From"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(175, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Invoice Number Starting From"
        '
        'TxtSelectedSettings
        '
        Me.TxtSelectedSettings.AllowEmpty = True
        Me.TxtSelectedSettings.AllowOnlyListValues = False
        Me.TxtSelectedSettings.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtSelectedSettings.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtSelectedSettings.CharcterCase = JyothiInventoryManagenetSystem_3._0.IMSComboBox.ChangCaseValues.Title
        Me.TxtSelectedSettings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtSelectedSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSelectedSettings.FormattingEnabled = True
        Me.TxtSelectedSettings.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSelectedSettings.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSelectedSettings.IsAllowDigits = True
        Me.TxtSelectedSettings.IsAllowSpace = True
        Me.TxtSelectedSettings.IsAllowSplChars = True
        Me.TxtSelectedSettings.Items.AddRange(New Object() {"CONTRA", "JOURNAL", "PAYMENT", "PURCHASE", "PURCHASE GOODS RECEIVED", "PURCHASE ORDERS", "PURCHASE QUTO", "PURCHASE RETURN VOUCHER", "PURCHASE RETURNS", "PURCHASE VOUCHER", "RECEIPT", "SALES", "SALES DELAVERY NOTE", "SALES ORDERS", "SALES QUTO", "SALES RETURNS", "SALES RETURUN VOUCHER", "SALES VOUCHER"})
        Me.TxtSelectedSettings.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSelectedSettings.Location = New System.Drawing.Point(126, 15)
        Me.TxtSelectedSettings.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSelectedSettings.Name = "TxtSelectedSettings"
        Me.TxtSelectedSettings.Size = New System.Drawing.Size(287, 23)
        Me.TxtSelectedSettings.Sorted = True
        Me.TxtSelectedSettings.SpecialCharList = "&-/@"
        Me.TxtSelectedSettings.TabIndex = 14
        Me.TxtSelectedSettings.UseFunctionKeys = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(29, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Settings For"
        '
        'Timer1
        '
        '
        'Billing_Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 418)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Billing_Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Billing Settings"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtSelectedSettings As JyothiInventoryManagenetSystem_3._0.IMSComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtInvoicePostFix As JyothiInventoryManagenetSystem_3._0.IMSTextBox
    Friend WithEvents TxtInvoicePreFix As JyothiInventoryManagenetSystem_3._0.IMSTextBox
    Friend WithEvents TxtInvoicenoStart As JyothiInventoryManagenetSystem_3._0.IMSNumericTextBox
    Friend WithEvents TxtInvoiceMethod As JyothiInventoryManagenetSystem_3._0.IMSComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtTitle As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents BtnClose As JyothiInventoryManagenetSystem_3._0.IMSButton
    Friend WithEvents BtnCreate As JyothiInventoryManagenetSystem_3._0.IMSButton
    Friend WithEvents TxtStatus As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TxtAllowDuplicates As JyothiInventoryManagenetSystem_3._0.IMSComboBox
    Friend WithEvents lblAllowDuplicates As System.Windows.Forms.Label
End Class
