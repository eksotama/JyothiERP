<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PriceList
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.IsStockCatWise = New System.Windows.Forms.CheckBox()
        Me.IsStockGroupWise = New System.Windows.Forms.CheckBox()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtStockCat = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtStockGroup = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtPriceListName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.test = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ImsHeadingLabel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtList, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(978, 531)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ImsHeadingLabel1
        '
        Me.ImsHeadingLabel1.BackColor = System.Drawing.Color.Green
        Me.TableLayoutPanel1.SetColumnSpan(Me.ImsHeadingLabel1, 2)
        Me.ImsHeadingLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsHeadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsHeadingLabel1.ForeColor = System.Drawing.Color.White
        Me.ImsHeadingLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ImsHeadingLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsHeadingLabel1.Name = "ImsHeadingLabel1"
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(978, 26)
        Me.ImsHeadingLabel1.TabIndex = 0
        Me.ImsHeadingLabel1.Text = "PRICE LISTS"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.IsStockCatWise)
        Me.Panel1.Controls.Add(Me.IsStockGroupWise)
        Me.Panel1.Controls.Add(Me.ImsButton1)
        Me.Panel1.Controls.Add(Me.ImsButton2)
        Me.Panel1.Controls.Add(Me.TxtStockCat)
        Me.Panel1.Controls.Add(Me.TxtStockGroup)
        Me.Panel1.Controls.Add(Me.TxtPriceListName)
        Me.Panel1.Controls.Add(Me.test)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 26)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(978, 70)
        Me.Panel1.TabIndex = 1
        '
        'IsStockCatWise
        '
        Me.IsStockCatWise.AutoSize = True
        Me.IsStockCatWise.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsStockCatWise.Location = New System.Drawing.Point(366, 38)
        Me.IsStockCatWise.Name = "IsStockCatWise"
        Me.IsStockCatWise.Size = New System.Drawing.Size(135, 17)
        Me.IsStockCatWise.TabIndex = 5
        Me.IsStockCatWise.Text = "For Stock Category"
        Me.IsStockCatWise.UseVisualStyleBackColor = True
        '
        'IsStockGroupWise
        '
        Me.IsStockGroupWise.AutoSize = True
        Me.IsStockGroupWise.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsStockGroupWise.Location = New System.Drawing.Point(10, 40)
        Me.IsStockGroupWise.Name = "IsStockGroupWise"
        Me.IsStockGroupWise.Size = New System.Drawing.Size(119, 17)
        Me.IsStockGroupWise.TabIndex = 5
        Me.IsStockGroupWise.Text = "For Stock Group"
        Me.IsStockGroupWise.UseVisualStyleBackColor = True
        '
        'ImsButton1
        '
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Location = New System.Drawing.Point(366, 4)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.Size = New System.Drawing.Size(135, 23)
        Me.ImsButton1.TabIndex = 2
        Me.ImsButton1.Text = "New Price List"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = True
        '
        'ImsButton2
        '
        Me.ImsButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton2.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.back24
        Me.ImsButton2.Location = New System.Drawing.Point(760, 11)
        Me.ImsButton2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton2.Name = "ImsButton2"
        Me.ImsButton2.Size = New System.Drawing.Size(138, 46)
        Me.ImsButton2.TabIndex = 3
        Me.ImsButton2.Text = "Import "
        Me.ImsButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton2.UseFunctionKeys = False
        Me.ImsButton2.UseVisualStyleBackColor = True
        '
        'TxtStockCat
        '
        Me.TxtStockCat.AllowEmpty = True
        Me.TxtStockCat.AllowOnlyListValues = False
        Me.TxtStockCat.AllowToolTip = True
        Me.TxtStockCat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtStockCat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtStockCat.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtStockCat.FormattingEnabled = True
        Me.TxtStockCat.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockCat.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockCat.IsAllowDigits = True
        Me.TxtStockCat.IsAllowSpace = True
        Me.TxtStockCat.IsAllowSplChars = True
        Me.TxtStockCat.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockCat.Location = New System.Drawing.Point(509, 36)
        Me.TxtStockCat.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockCat.Name = "TxtStockCat"
        Me.TxtStockCat.Size = New System.Drawing.Size(205, 21)
        Me.TxtStockCat.Sorted = True
        Me.TxtStockCat.SpecialCharList = "&-/@"
        Me.TxtStockCat.TabIndex = 1
        Me.TxtStockCat.UseFunctionKeys = False
        '
        'TxtStockGroup
        '
        Me.TxtStockGroup.AllowEmpty = True
        Me.TxtStockGroup.AllowOnlyListValues = False
        Me.TxtStockGroup.AllowToolTip = True
        Me.TxtStockGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtStockGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtStockGroup.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtStockGroup.FormattingEnabled = True
        Me.TxtStockGroup.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockGroup.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockGroup.IsAllowDigits = True
        Me.TxtStockGroup.IsAllowSpace = True
        Me.TxtStockGroup.IsAllowSplChars = True
        Me.TxtStockGroup.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockGroup.Location = New System.Drawing.Point(132, 36)
        Me.TxtStockGroup.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockGroup.Name = "TxtStockGroup"
        Me.TxtStockGroup.Size = New System.Drawing.Size(229, 21)
        Me.TxtStockGroup.Sorted = True
        Me.TxtStockGroup.SpecialCharList = "&-/@"
        Me.TxtStockGroup.TabIndex = 1
        Me.TxtStockGroup.UseFunctionKeys = False
        '
        'TxtPriceListName
        '
        Me.TxtPriceListName.AllowEmpty = True
        Me.TxtPriceListName.AllowOnlyListValues = True
        Me.TxtPriceListName.AllowToolTip = True
        Me.TxtPriceListName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtPriceListName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtPriceListName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtPriceListName.FormattingEnabled = True
        Me.TxtPriceListName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPriceListName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPriceListName.IsAllowDigits = True
        Me.TxtPriceListName.IsAllowSpace = True
        Me.TxtPriceListName.IsAllowSplChars = True
        Me.TxtPriceListName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPriceListName.Location = New System.Drawing.Point(131, 8)
        Me.TxtPriceListName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPriceListName.Name = "TxtPriceListName"
        Me.TxtPriceListName.Size = New System.Drawing.Size(229, 21)
        Me.TxtPriceListName.Sorted = True
        Me.TxtPriceListName.SpecialCharList = "&-/@"
        Me.TxtPriceListName.TabIndex = 1
        Me.TxtPriceListName.UseFunctionKeys = False
        '
        'test
        '
        Me.test.AutoSize = True
        Me.test.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.test.Location = New System.Drawing.Point(536, 8)
        Me.test.Name = "test"
        Me.test.Size = New System.Drawing.Size(96, 13)
        Me.test.TabIndex = 0
        Me.test.Text = "Price List Name"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(12, 11)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(96, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "Price List Name"
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.Location = New System.Drawing.Point(3, 99)
        Me.TxtList.Name = "TxtList"
        Me.TxtList.Size = New System.Drawing.Size(956, 429)
        Me.TxtList.TabIndex = 2
        '
        'PriceList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 531)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "PriceList"
        Me.Text = "Price List"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtPriceListName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtStockCat As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtStockGroup As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents IsStockCatWise As System.Windows.Forms.CheckBox
    Friend WithEvents IsStockGroupWise As System.Windows.Forms.CheckBox
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents test As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImsButton2 As JyothiPharmaERPSystem3.IMSButton
End Class
