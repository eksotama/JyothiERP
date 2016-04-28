<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RenewVehicleIDs
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtIdNo = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtExpiry = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtIssuedBy = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtIDType = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtVhname = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Olive
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(432, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "RENEW VECHILE ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnCreate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 247)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(426, 50)
        Me.Panel1.TabIndex = 1
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(22, 5)
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
        Me.BtnCreate.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.Save__1_
        Me.BtnCreate.Location = New System.Drawing.Point(219, 4)
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
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.TxtIdNo)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.TxtExpiry)
        Me.Panel2.Controls.Add(Me.TxtIssuedBy)
        Me.Panel2.Controls.Add(Me.TxtIDType)
        Me.Panel2.Controls.Add(Me.TxtVhname)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(3, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(426, 212)
        Me.Panel2.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "ID Number"
        '
        'TxtIdNo
        '
        Me.TxtIdNo.AllowToolTip = True
        Me.TxtIdNo.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtIdNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtIdNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtIdNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtIdNo.IsAllowDigits = True
        Me.TxtIdNo.IsAllowSpace = True
        Me.TxtIdNo.IsAllowSplChars = True
        Me.TxtIdNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtIdNo.Location = New System.Drawing.Point(109, 81)
        Me.TxtIdNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtIdNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtIdNo.MaxLength = 40
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.Size = New System.Drawing.Size(263, 20)
        Me.TxtIdNo.SpecialCharList = "&-/@"
        Me.TxtIdNo.TabIndex = 28
        Me.TxtIdNo.UseFunctionKeys = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Expiry"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 117)
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
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Vehicle Name"
        '
        'TxtExpiry
        '
        Me.TxtExpiry.Location = New System.Drawing.Point(109, 150)
        Me.TxtExpiry.Name = "TxtExpiry"
        Me.TxtExpiry.Size = New System.Drawing.Size(263, 20)
        Me.TxtExpiry.TabIndex = 4
        '
        'TxtIssuedBy
        '
        Me.TxtIssuedBy.AllowToolTip = True
        Me.TxtIssuedBy.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtIssuedBy.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtIssuedBy.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtIssuedBy.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtIssuedBy.IsAllowDigits = True
        Me.TxtIssuedBy.IsAllowSpace = True
        Me.TxtIssuedBy.IsAllowSplChars = True
        Me.TxtIssuedBy.LFocusBackColor = System.Drawing.Color.White
        Me.TxtIssuedBy.Location = New System.Drawing.Point(109, 114)
        Me.TxtIssuedBy.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtIssuedBy.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtIssuedBy.MaxLength = 40
        Me.TxtIssuedBy.Name = "TxtIssuedBy"
        Me.TxtIssuedBy.Size = New System.Drawing.Size(263, 20)
        Me.TxtIssuedBy.SpecialCharList = "&-/@"
        Me.TxtIssuedBy.TabIndex = 3
        Me.TxtIssuedBy.UseFunctionKeys = False
        '
        'TxtIDType
        '
        Me.TxtIDType.AllowToolTip = True
        Me.TxtIDType.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
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
        Me.TxtIDType.Size = New System.Drawing.Size(263, 20)
        Me.TxtIDType.SpecialCharList = "&-/@"
        Me.TxtIDType.TabIndex = 1
        Me.TxtIDType.UseFunctionKeys = False
        '
        'TxtVhname
        '
        Me.TxtVhname.AllowToolTip = True
        Me.TxtVhname.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtVhname.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtVhname.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtVhname.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtVhname.IsAllowDigits = True
        Me.TxtVhname.IsAllowSpace = True
        Me.TxtVhname.IsAllowSplChars = True
        Me.TxtVhname.LFocusBackColor = System.Drawing.Color.White
        Me.TxtVhname.Location = New System.Drawing.Point(109, 19)
        Me.TxtVhname.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtVhname.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtVhname.MaxLength = 40
        Me.TxtVhname.Name = "TxtVhname"
        Me.TxtVhname.ReadOnly = True
        Me.TxtVhname.Size = New System.Drawing.Size(263, 20)
        Me.TxtVhname.SpecialCharList = "&-/@"
        Me.TxtVhname.TabIndex = 0
        Me.TxtVhname.UseFunctionKeys = False
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(432, 308)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'RenewVehicleIDs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 308)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RenewVehicleIDs"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Renew Vehicle IDs"
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
    Friend WithEvents TxtIDType As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtVhname As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtIdNo As JyothiPharmaERPSystem3.IMSTextBox

End Class
