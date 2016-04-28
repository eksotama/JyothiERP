<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateNewDiscountfrm
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
        Me.TxtPer = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtDiscType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtStockGroup = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtValueType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtDateTo = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtDateFrom = New JyothiPharmaERPSystem3.IMSDate()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtDisName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtPer
        '
        Me.TxtPer.AllHelpText = True
        Me.TxtPer.AllowDecimal = True
        Me.TxtPer.AllowFormulas = False
        Me.TxtPer.AllowForQty = True
        Me.TxtPer.AllowNegative = False
        Me.TxtPer.AllowPerSign = False
        Me.TxtPer.AllowPlusSign = False
        Me.TxtPer.AllowToolTip = True
        Me.TxtPer.DecimalPlaces = CType(6, Short)
        Me.TxtPer.ExitOnEscKey = True
        Me.TxtPer.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPer.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPer.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtPer.HelpText = Nothing
        Me.TxtPer.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPer.Location = New System.Drawing.Point(154, 42)
        Me.TxtPer.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPer.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtPer.Max = CType(50, Long)
        Me.TxtPer.MaxLength = 5
        Me.TxtPer.Min = CType(0, Long)
        Me.TxtPer.Name = "TxtPer"
        Me.TxtPer.NextOnEnter = True
        Me.TxtPer.SetToolTip = Nothing
        Me.TxtPer.Size = New System.Drawing.Size(94, 20)
        Me.TxtPer.TabIndex = 1
        Me.TxtPer.Text = "1"
        Me.TxtPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtPer.ToolTip = Nothing
        Me.TxtPer.UseFunctionKeys = False
        Me.TxtPer.UseUpDownArrowKeys = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.79352!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtStatus, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(541, 370)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(541, 26)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "CREATE NEW DISCOUNT"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnCreate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 274)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(535, 67)
        Me.Panel1.TabIndex = 1
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(63, 11)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(161, 43)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnCreate
        '
        Me.BtnCreate.AllowToolTip = True
        Me.BtnCreate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCreate.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361186619_document_new
        Me.BtnCreate.Location = New System.Drawing.Point(286, 11)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(175, 43)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "&Save"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtDiscType)
        Me.Panel2.Controls.Add(Me.TxtStockGroup)
        Me.Panel2.Controls.Add(Me.TxtValueType)
        Me.Panel2.Controls.Add(Me.TxtDateTo)
        Me.Panel2.Controls.Add(Me.TxtDateFrom)
        Me.Panel2.Controls.Add(Me.TxtPer)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.TxtDisName)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(535, 239)
        Me.Panel2.TabIndex = 0
        '
        'TxtDiscType
        '
        Me.TxtDiscType.AllowEmpty = True
        Me.TxtDiscType.AllowOnlyListValues = False
        Me.TxtDiscType.AllowToolTip = True
        Me.TxtDiscType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtDiscType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtDiscType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtDiscType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtDiscType.FormattingEnabled = True
        Me.TxtDiscType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDiscType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDiscType.IsAdvanceSearchWindow = False
        Me.TxtDiscType.IsAllowDigits = True
        Me.TxtDiscType.IsAllowSpace = True
        Me.TxtDiscType.IsAllowSplChars = True
        Me.TxtDiscType.IsAllowToolTip = True
        Me.TxtDiscType.Items.AddRange(New Object() {"DISCOUNT % ", "ON BILL TOTAL", "ON ITEM PRICE"})
        Me.TxtDiscType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDiscType.Location = New System.Drawing.Point(154, 72)
        Me.TxtDiscType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDiscType.Name = "TxtDiscType"
        Me.TxtDiscType.SetToolTip = Nothing
        Me.TxtDiscType.Size = New System.Drawing.Size(204, 21)
        Me.TxtDiscType.Sorted = True
        Me.TxtDiscType.SpecialCharList = "&-/@"
        Me.TxtDiscType.TabIndex = 3
        Me.TxtDiscType.UseFunctionKeys = False
        '
        'TxtStockGroup
        '
        Me.TxtStockGroup.AllowEmpty = True
        Me.TxtStockGroup.AllowOnlyListValues = False
        Me.TxtStockGroup.AllowToolTip = True
        Me.TxtStockGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtStockGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtStockGroup.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtStockGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtStockGroup.FormattingEnabled = True
        Me.TxtStockGroup.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockGroup.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockGroup.IsAdvanceSearchWindow = False
        Me.TxtStockGroup.IsAllowDigits = True
        Me.TxtStockGroup.IsAllowSpace = True
        Me.TxtStockGroup.IsAllowSplChars = True
        Me.TxtStockGroup.IsAllowToolTip = True
        Me.TxtStockGroup.Items.AddRange(New Object() {"PERCENTAGE", "VALUE"})
        Me.TxtStockGroup.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockGroup.Location = New System.Drawing.Point(154, 173)
        Me.TxtStockGroup.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockGroup.Name = "TxtStockGroup"
        Me.TxtStockGroup.SetToolTip = Nothing
        Me.TxtStockGroup.Size = New System.Drawing.Size(204, 21)
        Me.TxtStockGroup.Sorted = True
        Me.TxtStockGroup.SpecialCharList = "&-/@"
        Me.TxtStockGroup.TabIndex = 6
        Me.TxtStockGroup.UseFunctionKeys = False
        '
        'TxtValueType
        '
        Me.TxtValueType.AllowEmpty = True
        Me.TxtValueType.AllowOnlyListValues = False
        Me.TxtValueType.AllowToolTip = True
        Me.TxtValueType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtValueType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtValueType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtValueType.FormattingEnabled = True
        Me.TxtValueType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtValueType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtValueType.IsAdvanceSearchWindow = False
        Me.TxtValueType.IsAllowDigits = True
        Me.TxtValueType.IsAllowSpace = True
        Me.TxtValueType.IsAllowSplChars = True
        Me.TxtValueType.IsAllowToolTip = True
        Me.TxtValueType.Items.AddRange(New Object() {"PERCENTAGE", "VALUE"})
        Me.TxtValueType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtValueType.Location = New System.Drawing.Point(254, 41)
        Me.TxtValueType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtValueType.Name = "TxtValueType"
        Me.TxtValueType.SetToolTip = Nothing
        Me.TxtValueType.Size = New System.Drawing.Size(104, 21)
        Me.TxtValueType.Sorted = True
        Me.TxtValueType.SpecialCharList = "&-/@"
        Me.TxtValueType.TabIndex = 2
        Me.TxtValueType.UseFunctionKeys = False
        '
        'TxtDateTo
        '
        Me.TxtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtDateTo.Location = New System.Drawing.Point(154, 141)
        Me.TxtDateTo.Name = "TxtDateTo"
        Me.TxtDateTo.Size = New System.Drawing.Size(144, 20)
        Me.TxtDateTo.TabIndex = 5
        '
        'TxtDateFrom
        '
        Me.TxtDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtDateFrom.Location = New System.Drawing.Point(154, 109)
        Me.TxtDateFrom.Name = "TxtDateFrom"
        Me.TxtDateFrom.Size = New System.Drawing.Size(144, 20)
        Me.TxtDateFrom.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(373, 177)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Stock Groups"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Allow Only for "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(38, 148)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Period To"
        '
        'TxtDisName
        '
        Me.TxtDisName.AllowToolTip = True
        Me.TxtDisName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtDisName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtDisName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDisName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDisName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtDisName.IsAllowDigits = True
        Me.TxtDisName.IsAllowSpace = True
        Me.TxtDisName.IsAllowSplChars = True
        Me.TxtDisName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDisName.Location = New System.Drawing.Point(154, 13)
        Me.TxtDisName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDisName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtDisName.MaxLength = 45
        Me.TxtDisName.Name = "TxtDisName"
        Me.TxtDisName.SetToolTip = Nothing
        Me.TxtDisName.Size = New System.Drawing.Size(221, 20)
        Me.TxtDisName.SpecialCharList = "&-/@()_"
        Me.TxtDisName.TabIndex = 0
        Me.TxtDisName.UseFunctionKeys = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(38, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Period From"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Discount Name/Code"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(39, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "DiscountType"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Percentage"
        '
        'TxtStatus
        '
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Green
        Me.TxtStatus.Location = New System.Drawing.Point(3, 344)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(535, 26)
        Me.TxtStatus.TabIndex = 0
        Me.TxtStatus.Text = "Status: Ready"
        '
        'CreateNewDiscountfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 370)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CreateNewDiscountfrm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CreateNewDiscount"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtPer As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtDateTo As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtDateFrom As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtDisName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtStatus As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TxtValueType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtStockGroup As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtDiscType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
