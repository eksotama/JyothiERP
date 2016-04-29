<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AssignBarcodes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AssignBarcodes))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtABarcode = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.bcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.TxtItemName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtItemCode = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtBarcode = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(462, 478)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkOrange
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(462, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ASSIGN MULTIPLE BARCODES"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 399)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(456, 50)
        Me.Panel1.TabIndex = 1
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(136, 6)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(161, 43)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ImsButton1)
        Me.Panel2.Controls.Add(Me.TxtABarcode)
        Me.Panel2.Controls.Add(Me.TxtList)
        Me.Panel2.Controls.Add(Me.TxtItemName)
        Me.Panel2.Controls.Add(Me.TxtItemCode)
        Me.Panel2.Controls.Add(Me.TxtBarcode)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(456, 364)
        Me.Panel2.TabIndex = 2
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.BackColor = System.Drawing.Color.White
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = CType(resources.GetObject("ImsButton1.Image"), System.Drawing.Image)
        Me.ImsButton1.Location = New System.Drawing.Point(303, 75)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(133, 43)
        Me.ImsButton1.TabIndex = 1
        Me.ImsButton1.Text = "Add "
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = False
        '
        'TxtABarcode
        '
        Me.TxtABarcode.AllowToolTip = True
        Me.TxtABarcode.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtABarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtABarcode.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtABarcode.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtABarcode.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtABarcode.IsAllowDigits = True
        Me.TxtABarcode.IsAllowSpace = True
        Me.TxtABarcode.IsAllowSplChars = True
        Me.TxtABarcode.LFocusBackColor = System.Drawing.Color.White
        Me.TxtABarcode.Location = New System.Drawing.Point(113, 92)
        Me.TxtABarcode.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtABarcode.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtABarcode.MaxLength = 50
        Me.TxtABarcode.Name = "TxtABarcode"
        Me.TxtABarcode.SetToolTip = Nothing
        Me.TxtABarcode.Size = New System.Drawing.Size(184, 20)
        Me.TxtABarcode.SpecialCharList = "&-/@"
        Me.TxtABarcode.TabIndex = 3
        Me.TxtABarcode.UseFunctionKeys = False
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToOrderColumns = True
        Me.TxtList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.bcode, Me.bDelete})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtList.DefaultCellStyle = DataGridViewCellStyle2
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.Location = New System.Drawing.Point(12, 124)
        Me.TxtList.Name = "TxtList"
        Me.TxtList.Size = New System.Drawing.Size(424, 226)
        Me.TxtList.TabIndex = 2
        '
        'bcode
        '
        Me.bcode.HeaderText = "Barcodes"
        Me.bcode.Name = "bcode"
        '
        'bDelete
        '
        Me.bDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.bDelete.HeaderText = "Delete?"
        Me.bDelete.Name = "bDelete"
        Me.bDelete.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.bDelete.Width = 89
        '
        'TxtItemName
        '
        Me.TxtItemName.AllowToolTip = True
        Me.TxtItemName.BackColor = System.Drawing.Color.White
        Me.TxtItemName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtItemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtItemName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtItemName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtItemName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtItemName.IsAllowDigits = True
        Me.TxtItemName.IsAllowSpace = True
        Me.TxtItemName.IsAllowSplChars = True
        Me.TxtItemName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtItemName.Location = New System.Drawing.Point(94, 46)
        Me.TxtItemName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtItemName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtItemName.MaxLength = 75
        Me.TxtItemName.Name = "TxtItemName"
        Me.TxtItemName.ReadOnly = True
        Me.TxtItemName.SetToolTip = Nothing
        Me.TxtItemName.Size = New System.Drawing.Size(284, 20)
        Me.TxtItemName.SpecialCharList = "&-/@"
        Me.TxtItemName.TabIndex = 1
        Me.TxtItemName.UseFunctionKeys = False
        '
        'TxtItemCode
        '
        Me.TxtItemCode.AllowToolTip = True
        Me.TxtItemCode.BackColor = System.Drawing.Color.White
        Me.TxtItemCode.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtItemCode.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtItemCode.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtItemCode.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtItemCode.IsAllowDigits = True
        Me.TxtItemCode.IsAllowSpace = True
        Me.TxtItemCode.IsAllowSplChars = True
        Me.TxtItemCode.LFocusBackColor = System.Drawing.Color.White
        Me.TxtItemCode.Location = New System.Drawing.Point(94, 26)
        Me.TxtItemCode.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtItemCode.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtItemCode.MaxLength = 75
        Me.TxtItemCode.Name = "TxtItemCode"
        Me.TxtItemCode.ReadOnly = True
        Me.TxtItemCode.SetToolTip = Nothing
        Me.TxtItemCode.Size = New System.Drawing.Size(284, 20)
        Me.TxtItemCode.SpecialCharList = "&-/@"
        Me.TxtItemCode.TabIndex = 1
        Me.TxtItemCode.UseFunctionKeys = False
        '
        'TxtBarcode
        '
        Me.TxtBarcode.AllowToolTip = True
        Me.TxtBarcode.BackColor = System.Drawing.Color.White
        Me.TxtBarcode.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtBarcode.Enabled = False
        Me.TxtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtBarcode.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtBarcode.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtBarcode.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtBarcode.IsAllowDigits = True
        Me.TxtBarcode.IsAllowSpace = True
        Me.TxtBarcode.IsAllowSplChars = True
        Me.TxtBarcode.LFocusBackColor = System.Drawing.Color.White
        Me.TxtBarcode.Location = New System.Drawing.Point(94, 6)
        Me.TxtBarcode.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtBarcode.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtBarcode.MaxLength = 75
        Me.TxtBarcode.Name = "TxtBarcode"
        Me.TxtBarcode.ReadOnly = True
        Me.TxtBarcode.SetToolTip = Nothing
        Me.TxtBarcode.Size = New System.Drawing.Size(176, 20)
        Me.TxtBarcode.SpecialCharList = "&-/@"
        Me.TxtBarcode.TabIndex = 1
        Me.TxtBarcode.UseFunctionKeys = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Alternative Barcode"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Item Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Item Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Primary Barcode"
        '
        'TxtStatus
        '
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Green
        Me.TxtStatus.Location = New System.Drawing.Point(3, 452)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(456, 26)
        Me.TxtStatus.TabIndex = 0
        Me.TxtStatus.Text = "Status: Ready"
        '
        'AssignBarcodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(462, 478)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AssignBarcodes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AssignBarcodes"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtItemName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtItemCode As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtBarcode As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtStatus As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents bcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bDelete As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtABarcode As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
