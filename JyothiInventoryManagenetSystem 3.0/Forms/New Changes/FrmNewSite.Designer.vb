<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNewSite
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNewSite))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtContactno1 = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtContactno2 = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtDesc = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtAddress = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtSiteName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.DarkOrange
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(518, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "CREATE NEW SITE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtContactno1
        '
        Me.TxtContactno1.AllowToolTip = True
        Me.TxtContactno1.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtContactno1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtContactno1.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtContactno1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtContactno1.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtContactno1.IsAllowDigits = True
        Me.TxtContactno1.IsAllowSpace = True
        Me.TxtContactno1.IsAllowSplChars = True
        Me.TxtContactno1.LFocusBackColor = System.Drawing.Color.White
        Me.TxtContactno1.Location = New System.Drawing.Point(183, 117)
        Me.TxtContactno1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtContactno1.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtContactno1.MaxLength = 20
        Me.TxtContactno1.Name = "TxtContactno1"
        Me.TxtContactno1.SetToolTip = Nothing
        Me.TxtContactno1.Size = New System.Drawing.Size(282, 20)
        Me.TxtContactno1.SpecialCharList = "&-/@"
        Me.TxtContactno1.TabIndex = 2
        Me.TxtContactno1.UseFunctionKeys = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtContactno2)
        Me.Panel1.Controls.Add(Me.TxtContactno1)
        Me.Panel1.Controls.Add(Me.TxtDesc)
        Me.Panel1.Controls.Add(Me.TxtAddress)
        Me.Panel1.Controls.Add(Me.TxtSiteName)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(512, 256)
        Me.Panel1.TabIndex = 2
        '
        'TxtContactno2
        '
        Me.TxtContactno2.AllowToolTip = True
        Me.TxtContactno2.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtContactno2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtContactno2.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtContactno2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtContactno2.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtContactno2.IsAllowDigits = True
        Me.TxtContactno2.IsAllowSpace = True
        Me.TxtContactno2.IsAllowSplChars = True
        Me.TxtContactno2.LFocusBackColor = System.Drawing.Color.White
        Me.TxtContactno2.Location = New System.Drawing.Point(183, 143)
        Me.TxtContactno2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtContactno2.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtContactno2.MaxLength = 20
        Me.TxtContactno2.Name = "TxtContactno2"
        Me.TxtContactno2.SetToolTip = Nothing
        Me.TxtContactno2.Size = New System.Drawing.Size(282, 20)
        Me.TxtContactno2.SpecialCharList = "&-/@"
        Me.TxtContactno2.TabIndex = 3
        Me.TxtContactno2.UseFunctionKeys = False
        '
        'TxtDesc
        '
        Me.TxtDesc.AllowToolTip = True
        Me.TxtDesc.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtDesc.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDesc.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDesc.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtDesc.IsAllowDigits = True
        Me.TxtDesc.IsAllowSpace = True
        Me.TxtDesc.IsAllowSplChars = True
        Me.TxtDesc.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDesc.Location = New System.Drawing.Point(183, 178)
        Me.TxtDesc.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDesc.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtDesc.MaxLength = 150
        Me.TxtDesc.Multiline = True
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.SetToolTip = Nothing
        Me.TxtDesc.Size = New System.Drawing.Size(282, 67)
        Me.TxtDesc.SpecialCharList = "&-/@"
        Me.TxtDesc.TabIndex = 4
        Me.TxtDesc.UseFunctionKeys = False
        '
        'TxtAddress
        '
        Me.TxtAddress.AllowToolTip = True
        Me.TxtAddress.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtAddress.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtAddress.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtAddress.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtAddress.IsAllowDigits = True
        Me.TxtAddress.IsAllowSpace = True
        Me.TxtAddress.IsAllowSplChars = True
        Me.TxtAddress.LFocusBackColor = System.Drawing.Color.White
        Me.TxtAddress.Location = New System.Drawing.Point(183, 45)
        Me.TxtAddress.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtAddress.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtAddress.MaxLength = 150
        Me.TxtAddress.Multiline = True
        Me.TxtAddress.Name = "TxtAddress"
        Me.TxtAddress.SetToolTip = Nothing
        Me.TxtAddress.Size = New System.Drawing.Size(282, 67)
        Me.TxtAddress.SpecialCharList = "&-/@"
        Me.TxtAddress.TabIndex = 1
        Me.TxtAddress.UseFunctionKeys = False
        '
        'TxtSiteName
        '
        Me.TxtSiteName.AllowToolTip = True
        Me.TxtSiteName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtSiteName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtSiteName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSiteName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSiteName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtSiteName.IsAllowDigits = True
        Me.TxtSiteName.IsAllowSpace = True
        Me.TxtSiteName.IsAllowSplChars = True
        Me.TxtSiteName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSiteName.Location = New System.Drawing.Point(183, 12)
        Me.TxtSiteName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSiteName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtSiteName.MaxLength = 50
        Me.TxtSiteName.Name = "TxtSiteName"
        Me.TxtSiteName.SetToolTip = Nothing
        Me.TxtSiteName.Size = New System.Drawing.Size(282, 20)
        Me.TxtSiteName.SpecialCharList = "&-/@"
        Me.TxtSiteName.TabIndex = 0
        Me.TxtSiteName.UseFunctionKeys = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Contact Number2"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 178)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Description"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Contact Number1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Address"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Site Name"
        '
        'BtnCreate
        '
        Me.BtnCreate.AllowToolTip = True
        Me.BtnCreate.BackColor = System.Drawing.Color.White
        Me.BtnCreate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCreate.Image = CType(resources.GetObject("BtnCreate.Image"), System.Drawing.Image)
        Me.BtnCreate.Location = New System.Drawing.Point(318, 7)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(159, 50)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "&Create"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtStatus, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(518, 376)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'TxtStatus
        '
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Green
        Me.TxtStatus.Location = New System.Drawing.Point(3, 351)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(512, 25)
        Me.TxtStatus.TabIndex = 4
        Me.TxtStatus.Text = "Status: Ready"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnClose)
        Me.Panel2.Controls.Add(Me.BtnCreate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 288)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(512, 60)
        Me.Panel2.TabIndex = 3
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(27, 7)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(159, 50)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'FrmNewSite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(518, 376)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmNewSite"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Create New Site"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtContactno1 As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtAddress As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtSiteName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtStatus As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TxtContactno2 As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtDesc As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
