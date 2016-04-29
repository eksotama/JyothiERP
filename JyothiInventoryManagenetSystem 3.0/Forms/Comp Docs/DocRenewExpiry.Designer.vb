<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocRenewExpiry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocRenewExpiry))
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtExpiry = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtIssuedBy = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtDocType = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtDocumentName = New JyothiPharmaERPSystem3.IMSTextBox()
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
        Me.Label1.Size = New System.Drawing.Size(430, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "RENEW DOCUMENTS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnCreate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 225)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(424, 50)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.TxtExpiry)
        Me.Panel2.Controls.Add(Me.TxtIssuedBy)
        Me.Panel2.Controls.Add(Me.TxtDocType)
        Me.Panel2.Controls.Add(Me.TxtDocumentName)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(3, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(424, 190)
        Me.Panel2.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Expiry"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 87)
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
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "IDName Name"
        '
        'TxtExpiry
        '
        Me.TxtExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtExpiry.Location = New System.Drawing.Point(109, 127)
        Me.TxtExpiry.Name = "TxtExpiry"
        Me.TxtExpiry.Size = New System.Drawing.Size(263, 20)
        Me.TxtExpiry.TabIndex = 1
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
        Me.TxtIssuedBy.Location = New System.Drawing.Point(109, 84)
        Me.TxtIssuedBy.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtIssuedBy.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtIssuedBy.MaxLength = 40
        Me.TxtIssuedBy.Name = "TxtIssuedBy"
        Me.TxtIssuedBy.SetToolTip = Nothing
        Me.TxtIssuedBy.Size = New System.Drawing.Size(263, 20)
        Me.TxtIssuedBy.SpecialCharList = "&-/@"
        Me.TxtIssuedBy.TabIndex = 0
        Me.TxtIssuedBy.UseFunctionKeys = False
        '
        'TxtDocType
        '
        Me.TxtDocType.AllowToolTip = True
        Me.TxtDocType.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtDocType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtDocType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDocType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDocType.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtDocType.IsAllowDigits = True
        Me.TxtDocType.IsAllowSpace = True
        Me.TxtDocType.IsAllowSplChars = True
        Me.TxtDocType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDocType.Location = New System.Drawing.Point(109, 45)
        Me.TxtDocType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDocType.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtDocType.MaxLength = 40
        Me.TxtDocType.Name = "TxtDocType"
        Me.TxtDocType.ReadOnly = True
        Me.TxtDocType.SetToolTip = Nothing
        Me.TxtDocType.Size = New System.Drawing.Size(263, 20)
        Me.TxtDocType.SpecialCharList = "&-/@"
        Me.TxtDocType.TabIndex = 1
        Me.TxtDocType.UseFunctionKeys = False
        '
        'TxtDocumentName
        '
        Me.TxtDocumentName.AllowToolTip = True
        Me.TxtDocumentName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtDocumentName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtDocumentName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDocumentName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDocumentName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtDocumentName.IsAllowDigits = True
        Me.TxtDocumentName.IsAllowSpace = True
        Me.TxtDocumentName.IsAllowSplChars = True
        Me.TxtDocumentName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDocumentName.Location = New System.Drawing.Point(109, 19)
        Me.TxtDocumentName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDocumentName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtDocumentName.MaxLength = 40
        Me.TxtDocumentName.Name = "TxtDocumentName"
        Me.TxtDocumentName.ReadOnly = True
        Me.TxtDocumentName.SetToolTip = Nothing
        Me.TxtDocumentName.Size = New System.Drawing.Size(263, 20)
        Me.TxtDocumentName.SpecialCharList = "&-/@"
        Me.TxtDocumentName.TabIndex = 0
        Me.TxtDocumentName.UseFunctionKeys = False
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(430, 286)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'DocRenewExpiry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(430, 286)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DocRenewExpiry"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Document Renew"
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtExpiry As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtIssuedBy As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtDocType As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtDocumentName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel

End Class
