<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportPriceList
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
        Me.IsBarcodeImport = New System.Windows.Forms.CheckBox()
        Me.ImsButton4 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtPriceListName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.tbarcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tlocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tstockcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tstocksize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbatchno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImsButton2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton3 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ImsHeadingLabel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtList, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1082, 507)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'ImsHeadingLabel1
        '
        Me.ImsHeadingLabel1.BackColor = System.Drawing.Color.Green
        Me.ImsHeadingLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsHeadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsHeadingLabel1.ForeColor = System.Drawing.Color.White
        Me.ImsHeadingLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ImsHeadingLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsHeadingLabel1.Name = "ImsHeadingLabel1"
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(1082, 26)
        Me.ImsHeadingLabel1.TabIndex = 0
        Me.ImsHeadingLabel1.Text = "IMPORT PRICE LIST FROM EXCEL FILE"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.IsBarcodeImport)
        Me.Panel1.Controls.Add(Me.ImsButton4)
        Me.Panel1.Controls.Add(Me.ImsButton1)
        Me.Panel1.Controls.Add(Me.TxtPriceListName)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 26)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1082, 51)
        Me.Panel1.TabIndex = 1
        '
        'IsBarcodeImport
        '
        Me.IsBarcodeImport.AutoSize = True
        Me.IsBarcodeImport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsBarcodeImport.Location = New System.Drawing.Point(317, 18)
        Me.IsBarcodeImport.Name = "IsBarcodeImport"
        Me.IsBarcodeImport.Size = New System.Drawing.Size(155, 17)
        Me.IsBarcodeImport.TabIndex = 3
        Me.IsBarcodeImport.Text = "Update Using BarCode"
        Me.IsBarcodeImport.UseVisualStyleBackColor = True
        '
        'ImsButton4
        '
        Me.ImsButton4.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton4.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361187183_Open
        Me.ImsButton4.Location = New System.Drawing.Point(806, 4)
        Me.ImsButton4.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton4.Name = "ImsButton4"
        Me.ImsButton4.Size = New System.Drawing.Size(193, 45)
        Me.ImsButton4.TabIndex = 2
        Me.ImsButton4.Text = "Export Stock List"
        Me.ImsButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton4.UseFunctionKeys = False
        Me.ImsButton4.UseVisualStyleBackColor = True
        '
        'ImsButton1
        '
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.excel
        Me.ImsButton1.Location = New System.Drawing.Point(478, 3)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.Size = New System.Drawing.Size(193, 45)
        Me.ImsButton1.TabIndex = 2
        Me.ImsButton1.Text = "Select Excel File"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = True
        '
        'TxtPriceListName
        '
        Me.TxtPriceListName.AllowEmpty = True
        Me.TxtPriceListName.AllowOnlyListValues = True
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
        Me.TxtPriceListName.Location = New System.Drawing.Point(15, 17)
        Me.TxtPriceListName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPriceListName.Name = "TxtPriceListName"
        Me.TxtPriceListName.Size = New System.Drawing.Size(229, 21)
        Me.TxtPriceListName.Sorted = True
        Me.TxtPriceListName.SpecialCharList = "&-/@"
        Me.TxtPriceListName.TabIndex = 1
        Me.TxtPriceListName.UseFunctionKeys = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(12, 4)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(96, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "Price List Name"
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tbarcode, Me.tlocation, Me.tstockcode, Me.tstocksize, Me.tbatchno, Me.tPrice, Me.tStatus})
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.Location = New System.Drawing.Point(3, 80)
        Me.TxtList.Name = "TxtList"
        Me.TxtList.Size = New System.Drawing.Size(1076, 367)
        Me.TxtList.TabIndex = 2
        '
        'tbarcode
        '
        Me.tbarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tbarcode.HeaderText = "Barcode"
        Me.tbarcode.Name = "tbarcode"
        Me.tbarcode.Width = 150
        '
        'tlocation
        '
        Me.tlocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tlocation.HeaderText = "Location"
        Me.tlocation.Name = "tlocation"
        Me.tlocation.Width = 120
        '
        'tstockcode
        '
        Me.tstockcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.tstockcode.HeaderText = "Stock Code"
        Me.tstockcode.Name = "tstockcode"
        '
        'tstocksize
        '
        Me.tstocksize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.tstocksize.HeaderText = "Stock Size"
        Me.tstocksize.Name = "tstocksize"
        '
        'tbatchno
        '
        Me.tbatchno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tbatchno.HeaderText = "BatchNo"
        Me.tbatchno.Name = "tbatchno"
        Me.tbatchno.Width = 174
        '
        'tPrice
        '
        Me.tPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tPrice.HeaderText = "Price"
        Me.tPrice.Name = "tPrice"
        Me.tPrice.Width = 173
        '
        'tStatus
        '
        Me.tStatus.HeaderText = "Status"
        Me.tStatus.Name = "tStatus"
        Me.tStatus.Visible = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 7
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton2, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ImsButton3, 4, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 453)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1076, 51)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'ImsButton2
        '
        Me.ImsButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton2.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.ImsButton2.Location = New System.Drawing.Point(309, 3)
        Me.ImsButton2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton2.Name = "ImsButton2"
        Me.ImsButton2.Size = New System.Drawing.Size(147, 45)
        Me.ImsButton2.TabIndex = 0
        Me.ImsButton2.Text = "Close"
        Me.ImsButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton2.UseFunctionKeys = False
        Me.ImsButton2.UseVisualStyleBackColor = True
        '
        'ImsButton3
        '
        Me.ImsButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton3.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton3.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361188505_file_edit
        Me.ImsButton3.Location = New System.Drawing.Point(615, 3)
        Me.ImsButton3.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton3.Name = "ImsButton3"
        Me.ImsButton3.Size = New System.Drawing.Size(147, 45)
        Me.ImsButton3.TabIndex = 0
        Me.ImsButton3.Text = "Update"
        Me.ImsButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton3.UseFunctionKeys = False
        Me.ImsButton3.UseVisualStyleBackColor = True
        '
        'ImportPriceList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1082, 507)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ImportPriceList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Price List"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtPriceListName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents IsBarcodeImport As System.Windows.Forms.CheckBox
    Friend WithEvents ImsButton2 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton3 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents tbarcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tlocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tstockcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tstocksize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tbatchno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImsButton4 As JyothiPharmaERPSystem3.IMSButton
End Class
