<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectStockJornalInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectStockJornalInvoice))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnOk = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSGrid()
        Me.ImsButton2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtInvoice = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImsButton3 = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.BtnOk)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 402)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(482, 41)
        Me.Panel3.TabIndex = 2
        '
        'BtnOk
        '
        Me.BtnOk.AllowToolTip = True
        Me.BtnOk.BackColor = System.Drawing.Color.White
        Me.BtnOk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnOk.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        Me.BtnOk.Location = New System.Drawing.Point(0, 0)
        Me.BtnOk.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.SetToolTip = ""
        Me.BtnOk.Size = New System.Drawing.Size(482, 41)
        Me.BtnOk.TabIndex = 0
        Me.BtnOk.Text = "&Open"
        Me.BtnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnOk.UseFunctionKeys = False
        Me.BtnOk.UseVisualStyleBackColor = False
        '
        'TxtList
        '
        Me.TxtList.AllowDrop = True
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtList.DefaultCellStyle = DataGridViewCellStyle8
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.HasSerialNumber = False
        Me.TxtList.Location = New System.Drawing.Point(3, 25)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.RowHeadersWidth = 33
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.SerialNumberColName = "stSno"
        Me.TxtList.Size = New System.Drawing.Size(476, 374)
        Me.TxtList.TabIndex = 3
        '
        'ImsButton2
        '
        Me.ImsButton2.AllowToolTip = True
        Me.ImsButton2.BackColor = System.Drawing.Color.White
        Me.ImsButton2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton2.Image = CType(resources.GetObject("ImsButton2.Image"), System.Drawing.Image)
        Me.ImsButton2.Location = New System.Drawing.Point(56, 76)
        Me.ImsButton2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton2.Name = "ImsButton2"
        Me.ImsButton2.SetToolTip = ""
        Me.ImsButton2.Size = New System.Drawing.Size(75, 37)
        Me.ImsButton2.TabIndex = 6
        Me.ImsButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton2.UseFunctionKeys = False
        Me.ImsButton2.UseVisualStyleBackColor = False
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.BackColor = System.Drawing.Color.White
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = CType(resources.GetObject("ImsButton1.Image"), System.Drawing.Image)
        Me.ImsButton1.Location = New System.Drawing.Point(40, 213)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(75, 37)
        Me.ImsButton1.TabIndex = 6
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = False
        '
        'TxtInvoice
        '
        Me.TxtInvoice.AllowToolTip = True
        Me.TxtInvoice.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtInvoice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtInvoice.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtInvoice.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtInvoice.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtInvoice.IsAllowDigits = True
        Me.TxtInvoice.IsAllowSpace = True
        Me.TxtInvoice.IsAllowSplChars = True
        Me.TxtInvoice.LFocusBackColor = System.Drawing.Color.White
        Me.TxtInvoice.Location = New System.Drawing.Point(10, 187)
        Me.TxtInvoice.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtInvoice.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtInvoice.MaxLength = 75
        Me.TxtInvoice.Name = "TxtInvoice"
        Me.TxtInvoice.SetToolTip = Nothing
        Me.TxtInvoice.Size = New System.Drawing.Size(156, 20)
        Me.TxtInvoice.SpecialCharList = "&-/@"
        Me.TxtInvoice.TabIndex = 5
        Me.TxtInvoice.UseFunctionKeys = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.BackColor = System.Drawing.Color.DarkOrange
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.ForeColor = System.Drawing.Color.White
        Me.ImSlabel1.Location = New System.Drawing.Point(3, 0)
        Me.ImSlabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(647, 22)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "SELECT INVOICES"
        Me.ImSlabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(482, 22)
        Me.Panel1.TabIndex = 0
        '
        'TxtEndDate
        '
        Me.TxtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEndDate.Location = New System.Drawing.Point(12, 50)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(154, 20)
        Me.TxtEndDate.TabIndex = 1
        '
        'TxtStartDate
        '
        Me.TxtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtStartDate.Location = New System.Drawing.Point(12, 29)
        Me.TxtStartDate.Name = "TxtStartDate"
        Me.TxtStartDate.Size = New System.Drawing.Size(154, 20)
        Me.TxtStartDate.TabIndex = 1
        '
        'ImSlabel8
        '
        Me.ImSlabel8.AutoSize = True
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(8, 166)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(158, 13)
        Me.ImSlabel8.TabIndex = 0
        Me.ImSlabel8.Text = "Search By Invoice Number"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(9, 13)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(84, 13)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "Filter By Date"
        '
        'ImsButton3
        '
        Me.ImsButton3.AllowToolTip = True
        Me.ImsButton3.BackColor = System.Drawing.Color.White
        Me.ImsButton3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ImsButton3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsButton3.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton3.Image = CType(resources.GetObject("ImsButton3.Image"), System.Drawing.Image)
        Me.ImsButton3.Location = New System.Drawing.Point(482, 402)
        Me.ImsButton3.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton3.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsButton3.Name = "ImsButton3"
        Me.ImsButton3.SetToolTip = ""
        Me.ImsButton3.Size = New System.Drawing.Size(189, 41)
        Me.ImsButton3.TabIndex = 8
        Me.ImsButton3.Text = "Close"
        Me.ImsButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton3.UseFunctionKeys = False
        Me.ImsButton3.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ImsButton2)
        Me.Panel2.Controls.Add(Me.ImsButton1)
        Me.Panel2.Controls.Add(Me.TxtInvoice)
        Me.Panel2.Controls.Add(Me.TxtEndDate)
        Me.Panel2.Controls.Add(Me.TxtStartDate)
        Me.Panel2.Controls.Add(Me.ImSlabel8)
        Me.Panel2.Controls.Add(Me.ImSlabel2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(482, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.TableLayoutPanel1.SetRowSpan(Me.Panel2, 2)
        Me.Panel2.Size = New System.Drawing.Size(189, 402)
        Me.Panel2.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ImsButton3, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtList, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(671, 443)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'SelectStockJornalInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(671, 443)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SelectStockJornalInvoice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Journal Invoice"
        Me.Panel3.ResumeLayout(False)
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents BtnOk As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSGrid
    Friend WithEvents ImsButton2 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtInvoice As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImsButton3 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel

End Class
