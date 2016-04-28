<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RenewEmpExpiry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RenewEmpExpiry))
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtExpiry = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtIssuedBy = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtIDType = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtEmployeeName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtIdNo = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(22, 5)
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
        'BtnCreate
        '
        Me.BtnCreate.AllowToolTip = True
        Me.BtnCreate.BackColor = System.Drawing.Color.White
        Me.BtnCreate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCreate.Image = CType(resources.GetObject("BtnCreate.Image"), System.Drawing.Image)
        Me.BtnCreate.Location = New System.Drawing.Point(219, 4)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(175, 43)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "&Save"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = False
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
        Me.Label1.Size = New System.Drawing.Size(421, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "RENEW EMPLOYEES ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnCreate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 261)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(415, 50)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.TxtExpiry)
        Me.Panel2.Controls.Add(Me.TxtIssuedBy)
        Me.Panel2.Controls.Add(Me.TxtIDType)
        Me.Panel2.Controls.Add(Me.TxtEmployeeName)
        Me.Panel2.Controls.Add(Me.TxtIdNo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(3, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(415, 226)
        Me.Panel2.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Expiry"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Issued By"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "ID Type"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Employee Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "ID Number"
        '
        'TxtExpiry
        '
        Me.TxtExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtExpiry.Location = New System.Drawing.Point(109, 175)
        Me.TxtExpiry.Name = "TxtExpiry"
        Me.TxtExpiry.Size = New System.Drawing.Size(263, 20)
        Me.TxtExpiry.TabIndex = 4
        '
        'TxtIssuedBy
        '
        Me.TxtIssuedBy.AllowToolTip = True
        Me.TxtIssuedBy.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtIssuedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtIssuedBy.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtIssuedBy.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtIssuedBy.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtIssuedBy.IsAllowDigits = True
        Me.TxtIssuedBy.IsAllowSpace = True
        Me.TxtIssuedBy.IsAllowSplChars = True
        Me.TxtIssuedBy.LFocusBackColor = System.Drawing.Color.White
        Me.TxtIssuedBy.Location = New System.Drawing.Point(109, 132)
        Me.TxtIssuedBy.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtIssuedBy.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtIssuedBy.MaxLength = 40
        Me.TxtIssuedBy.Name = "TxtIssuedBy"
        Me.TxtIssuedBy.SetToolTip = Nothing
        Me.TxtIssuedBy.Size = New System.Drawing.Size(263, 20)
        Me.TxtIssuedBy.SpecialCharList = "&-/@"
        Me.TxtIssuedBy.TabIndex = 3
        Me.TxtIssuedBy.UseFunctionKeys = False
        '
        'TxtIDType
        '
        Me.TxtIDType.AllowToolTip = True
        Me.TxtIDType.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtIDType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtIDType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtIDType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtIDType.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtIDType.IsAllowDigits = True
        Me.TxtIDType.IsAllowSpace = True
        Me.TxtIDType.IsAllowSplChars = True
        Me.TxtIDType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtIDType.Location = New System.Drawing.Point(109, 45)
        Me.TxtIDType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtIDType.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtIDType.MaxLength = 40
        Me.TxtIDType.Name = "TxtIDType"
        Me.TxtIDType.ReadOnly = True
        Me.TxtIDType.SetToolTip = Nothing
        Me.TxtIDType.Size = New System.Drawing.Size(263, 20)
        Me.TxtIDType.SpecialCharList = "&-/@"
        Me.TxtIDType.TabIndex = 1
        Me.TxtIDType.UseFunctionKeys = False
        '
        'TxtEmployeeName
        '
        Me.TxtEmployeeName.AllowToolTip = True
        Me.TxtEmployeeName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtEmployeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtEmployeeName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtEmployeeName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtEmployeeName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtEmployeeName.IsAllowDigits = True
        Me.TxtEmployeeName.IsAllowSpace = True
        Me.TxtEmployeeName.IsAllowSplChars = True
        Me.TxtEmployeeName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtEmployeeName.Location = New System.Drawing.Point(109, 19)
        Me.TxtEmployeeName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtEmployeeName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtEmployeeName.MaxLength = 40
        Me.TxtEmployeeName.Name = "TxtEmployeeName"
        Me.TxtEmployeeName.ReadOnly = True
        Me.TxtEmployeeName.SetToolTip = Nothing
        Me.TxtEmployeeName.Size = New System.Drawing.Size(263, 20)
        Me.TxtEmployeeName.SpecialCharList = "&-/@"
        Me.TxtEmployeeName.TabIndex = 0
        Me.TxtEmployeeName.UseFunctionKeys = False
        '
        'TxtIdNo
        '
        Me.TxtIdNo.AllowToolTip = True
        Me.TxtIdNo.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtIdNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtIdNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtIdNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtIdNo.IsAllowDigits = True
        Me.TxtIdNo.IsAllowSpace = True
        Me.TxtIdNo.IsAllowSplChars = True
        Me.TxtIdNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtIdNo.Location = New System.Drawing.Point(109, 90)
        Me.TxtIdNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtIdNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtIdNo.MaxLength = 40
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.SetToolTip = Nothing
        Me.TxtIdNo.Size = New System.Drawing.Size(263, 20)
        Me.TxtIdNo.SpecialCharList = "&-/@"
        Me.TxtIdNo.TabIndex = 2
        Me.TxtIdNo.UseFunctionKeys = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.79352!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(421, 322)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'RenewEmpExpiry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(421, 322)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RenewEmpExpiry"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Renew Employee"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtExpiry As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtIssuedBy As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtIdNo As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtIDType As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtEmployeeName As JyothiPharmaERPSystem3.IMSTextBox

End Class
