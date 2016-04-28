<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomBarcodeEntry
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
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtStockCode = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtStockName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtCat = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtGroup = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtLocation = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton4 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtList, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.13944!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.86056!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(957, 502)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToResizeRows = False
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.Location = New System.Drawing.Point(3, 72)
        Me.TxtList.Name = "TxtList"
        Me.TxtList.Size = New System.Drawing.Size(951, 381)
        Me.TxtList.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtStockCode)
        Me.Panel1.Controls.Add(Me.TxtStockName)
        Me.Panel1.Controls.Add(Me.ImSlabel5)
        Me.Panel1.Controls.Add(Me.TxtCat)
        Me.Panel1.Controls.Add(Me.ImSlabel4)
        Me.Panel1.Controls.Add(Me.ImSlabel3)
        Me.Panel1.Controls.Add(Me.TxtGroup)
        Me.Panel1.Controls.Add(Me.ImSlabel2)
        Me.Panel1.Controls.Add(Me.TxtLocation)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Controls.Add(Me.ImsHeadingLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(955, 67)
        Me.Panel1.TabIndex = 1
        '
        'TxtStockCode
        '
        Me.TxtStockCode.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtStockCode.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockCode.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockCode.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtStockCode.IsAllowDigits = True
        Me.TxtStockCode.IsAllowSpace = True
        Me.TxtStockCode.IsAllowSplChars = True
        Me.TxtStockCode.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockCode.Location = New System.Drawing.Point(757, 48)
        Me.TxtStockCode.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockCode.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtStockCode.MaxLength = 75
        Me.TxtStockCode.Name = "TxtStockCode"
        Me.TxtStockCode.Size = New System.Drawing.Size(136, 20)
        Me.TxtStockCode.SpecialCharList = "&-/@"
        Me.TxtStockCode.TabIndex = 3
        Me.TxtStockCode.UseFunctionKeys = False
        '
        'TxtStockName
        '
        Me.TxtStockName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtStockName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtStockName.IsAllowDigits = True
        Me.TxtStockName.IsAllowSpace = True
        Me.TxtStockName.IsAllowSplChars = True
        Me.TxtStockName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockName.Location = New System.Drawing.Point(610, 48)
        Me.TxtStockName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtStockName.MaxLength = 75
        Me.TxtStockName.Name = "TxtStockName"
        Me.TxtStockName.Size = New System.Drawing.Size(136, 20)
        Me.TxtStockName.SpecialCharList = "&-/@"
        Me.TxtStockName.TabIndex = 3
        Me.TxtStockName.UseFunctionKeys = False
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(755, 31)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(135, 13)
        Me.ImSlabel5.TabIndex = 1
        Me.ImSlabel5.Text = "Search By Stock Code"
        '
        'TxtCat
        '
        Me.TxtCat.AllowEmpty = True
        Me.TxtCat.AllowOnlyListValues = False
        Me.TxtCat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtCat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtCat.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtCat.FormattingEnabled = True
        Me.TxtCat.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCat.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCat.IsAllowDigits = True
        Me.TxtCat.IsAllowSpace = True
        Me.TxtCat.IsAllowSplChars = True
        Me.TxtCat.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCat.Location = New System.Drawing.Point(414, 48)
        Me.TxtCat.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCat.Name = "TxtCat"
        Me.TxtCat.Size = New System.Drawing.Size(190, 21)
        Me.TxtCat.Sorted = True
        Me.TxtCat.SpecialCharList = "&-/@"
        Me.TxtCat.TabIndex = 2
        Me.TxtCat.UseFunctionKeys = False
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(608, 31)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(138, 13)
        Me.ImSlabel4.TabIndex = 1
        Me.ImSlabel4.Text = "Search By Stock Name"
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(411, 32)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(107, 13)
        Me.ImSlabel3.TabIndex = 1
        Me.ImSlabel3.Text = "Filter By Catogery"
        '
        'TxtGroup
        '
        Me.TxtGroup.AllowEmpty = True
        Me.TxtGroup.AllowOnlyListValues = False
        Me.TxtGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtGroup.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtGroup.FormattingEnabled = True
        Me.TxtGroup.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtGroup.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtGroup.IsAllowDigits = True
        Me.TxtGroup.IsAllowSpace = True
        Me.TxtGroup.IsAllowSplChars = True
        Me.TxtGroup.LFocusBackColor = System.Drawing.Color.White
        Me.TxtGroup.Location = New System.Drawing.Point(196, 48)
        Me.TxtGroup.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtGroup.Name = "TxtGroup"
        Me.TxtGroup.Size = New System.Drawing.Size(201, 21)
        Me.TxtGroup.Sorted = True
        Me.TxtGroup.SpecialCharList = "&-/@"
        Me.TxtGroup.TabIndex = 2
        Me.TxtGroup.UseFunctionKeys = False
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(193, 32)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(91, 13)
        Me.ImSlabel2.TabIndex = 1
        Me.ImSlabel2.Text = "Filter By Group"
        '
        'TxtLocation
        '
        Me.TxtLocation.AllowEmpty = True
        Me.TxtLocation.AllowOnlyListValues = False
        Me.TxtLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtLocation.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtLocation.FormattingEnabled = True
        Me.TxtLocation.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLocation.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLocation.IsAllowDigits = True
        Me.TxtLocation.IsAllowSpace = True
        Me.TxtLocation.IsAllowSplChars = True
        Me.TxtLocation.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLocation.Location = New System.Drawing.Point(11, 48)
        Me.TxtLocation.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLocation.Name = "TxtLocation"
        Me.TxtLocation.Size = New System.Drawing.Size(165, 21)
        Me.TxtLocation.Sorted = True
        Me.TxtLocation.SpecialCharList = "&-/@"
        Me.TxtLocation.TabIndex = 2
        Me.TxtLocation.UseFunctionKeys = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(8, 32)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(106, 13)
        Me.ImSlabel1.TabIndex = 1
        Me.ImSlabel1.Text = "Filter By Location"
        '
        'ImsHeadingLabel1
        '
        Me.ImsHeadingLabel1.BackColor = System.Drawing.Color.Green
        Me.ImsHeadingLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ImsHeadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsHeadingLabel1.ForeColor = System.Drawing.Color.White
        Me.ImsHeadingLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ImsHeadingLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsHeadingLabel1.Name = "ImsHeadingLabel1"
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(955, 25)
        Me.ImsHeadingLabel1.TabIndex = 0
        Me.ImsHeadingLabel1.Text = "BARCODE  MAINTENANCE"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ImsButton1)
        Me.Panel2.Controls.Add(Me.ImsButton4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(1, 457)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(955, 44)
        Me.Panel2.TabIndex = 2
        '
        'ImsButton1
        '
        Me.ImsButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.ImsButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton1.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.ImsButton1.Location = New System.Drawing.Point(546, -1)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.Size = New System.Drawing.Size(182, 45)
        Me.ImsButton1.TabIndex = 1
        Me.ImsButton1.Text = "CLOSE"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = True
        '
        'ImsButton4
        '
        Me.ImsButton4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.ImsButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton4.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton4.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton4.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.print__1_
        Me.ImsButton4.Location = New System.Drawing.Point(178, -1)
        Me.ImsButton4.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton4.Name = "ImsButton4"
        Me.ImsButton4.Size = New System.Drawing.Size(198, 45)
        Me.ImsButton4.TabIndex = 2
        Me.ImsButton4.Text = "PRINT BARCODES"
        Me.ImsButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton4.UseFunctionKeys = False
        Me.ImsButton4.UseVisualStyleBackColor = True
        '
        'CustomBarcodeEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(957, 502)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CustomBarcodeEntry"
        Me.Text = "Custom Barcode Entry"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtStockName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtCat As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtGroup As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtLocation As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents TxtStockCode As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton4 As JyothiPharmaERPSystem3.IMSButton
End Class
