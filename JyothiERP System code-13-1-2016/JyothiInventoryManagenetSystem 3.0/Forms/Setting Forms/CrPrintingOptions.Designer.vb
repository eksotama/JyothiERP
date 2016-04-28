<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CrPrintingOptions
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ispagenumbers = New System.Windows.Forms.CheckBox()
        Me.IsTitle = New System.Windows.Forms.CheckBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.UserButton3 = New UserButton.UserButton()
        Me.txtfooter = New System.Windows.Forms.PictureBox()
        Me.IsCompanyAddress = New System.Windows.Forms.CheckBox()
        Me.IscompanyName = New System.Windows.Forms.CheckBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.UserButton2 = New UserButton.UserButton()
        Me.TxtHeder = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.UserButton1 = New UserButton.UserButton()
        Me.TxtRightLogo = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnselectleftlogo = New UserButton.UserButton()
        Me.txtleftlogobox = New System.Windows.Forms.PictureBox()
        Me.chkfooter = New System.Windows.Forms.CheckBox()
        Me.chkheader = New System.Windows.Forms.CheckBox()
        Me.chkright = New System.Windows.Forms.CheckBox()
        Me.chkleft = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.txtfooter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.TxtHeder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.TxtRightLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.txtleftlogobox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.BtnClose)
        Me.Panel3.Controls.Add(Me.BtnCreate)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 476)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(768, 54)
        Me.Panel3.TabIndex = 3
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(111, 3)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(161, 51)
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
        Me.BtnCreate.Location = New System.Drawing.Point(495, 3)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(175, 51)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "Save"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(774, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "PRINTING OPTIONS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ispagenumbers)
        Me.Panel1.Controls.Add(Me.IsTitle)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.IsCompanyAddress)
        Me.Panel1.Controls.Add(Me.IscompanyName)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.chkfooter)
        Me.Panel1.Controls.Add(Me.chkheader)
        Me.Panel1.Controls.Add(Me.chkright)
        Me.Panel1.Controls.Add(Me.chkleft)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 23)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(774, 450)
        Me.Panel1.TabIndex = 2
        '
        'ispagenumbers
        '
        Me.ispagenumbers.AutoSize = True
        Me.ispagenumbers.Location = New System.Drawing.Point(597, 269)
        Me.ispagenumbers.Name = "ispagenumbers"
        Me.ispagenumbers.Size = New System.Drawing.Size(145, 17)
        Me.ispagenumbers.TabIndex = 11
        Me.ispagenumbers.Text = "Print Page Numbers?"
        Me.ispagenumbers.UseVisualStyleBackColor = True
        '
        'IsTitle
        '
        Me.IsTitle.AutoSize = True
        Me.IsTitle.Location = New System.Drawing.Point(597, 360)
        Me.IsTitle.Name = "IsTitle"
        Me.IsTitle.Size = New System.Drawing.Size(138, 17)
        Me.IsTitle.TabIndex = 11
        Me.IsTitle.Text = "Print  Report Title ?"
        Me.IsTitle.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.UserButton3)
        Me.Panel6.Controls.Add(Me.txtfooter)
        Me.Panel6.Enabled = False
        Me.Panel6.Location = New System.Drawing.Point(44, 144)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(718, 92)
        Me.Panel6.TabIndex = 10
        '
        'UserButton3
        '
        Me.UserButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserButton3.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.UserButton3.Location = New System.Drawing.Point(599, 29)
        Me.UserButton3.LostFocusFontColor = System.Drawing.Color.Blue
        Me.UserButton3.Name = "UserButton3"
        Me.UserButton3.Size = New System.Drawing.Size(99, 32)
        Me.UserButton3.TabIndex = 10
        Me.UserButton3.Text = "Select"
        Me.UserButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.UserButton3.UseFunctionKeys = False
        Me.UserButton3.UseVisualStyleBackColor = True
        '
        'txtfooter
        '
        Me.txtfooter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.txtfooter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtfooter.Location = New System.Drawing.Point(5, 13)
        Me.txtfooter.Name = "txtfooter"
        Me.txtfooter.Size = New System.Drawing.Size(557, 64)
        Me.txtfooter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.txtfooter.TabIndex = 9
        Me.txtfooter.TabStop = False
        '
        'IsCompanyAddress
        '
        Me.IsCompanyAddress.AutoSize = True
        Me.IsCompanyAddress.Location = New System.Drawing.Point(597, 330)
        Me.IsCompanyAddress.Name = "IsCompanyAddress"
        Me.IsCompanyAddress.Size = New System.Drawing.Size(167, 17)
        Me.IsCompanyAddress.TabIndex = 11
        Me.IsCompanyAddress.Text = "Print Company Address ?"
        Me.IsCompanyAddress.UseVisualStyleBackColor = True
        '
        'IscompanyName
        '
        Me.IscompanyName.AutoSize = True
        Me.IscompanyName.Location = New System.Drawing.Point(597, 300)
        Me.IscompanyName.Name = "IscompanyName"
        Me.IscompanyName.Size = New System.Drawing.Size(150, 17)
        Me.IscompanyName.TabIndex = 11
        Me.IscompanyName.Text = "Print Company Name?"
        Me.IscompanyName.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.UserButton2)
        Me.Panel5.Controls.Add(Me.TxtHeder)
        Me.Panel5.Enabled = False
        Me.Panel5.Location = New System.Drawing.Point(46, 23)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(718, 92)
        Me.Panel5.TabIndex = 10
        '
        'UserButton2
        '
        Me.UserButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserButton2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.UserButton2.Location = New System.Drawing.Point(599, 29)
        Me.UserButton2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.UserButton2.Name = "UserButton2"
        Me.UserButton2.Size = New System.Drawing.Size(99, 32)
        Me.UserButton2.TabIndex = 10
        Me.UserButton2.Text = "Select"
        Me.UserButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.UserButton2.UseFunctionKeys = False
        Me.UserButton2.UseVisualStyleBackColor = True
        '
        'TxtHeder
        '
        Me.TxtHeder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TxtHeder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtHeder.Location = New System.Drawing.Point(5, 13)
        Me.TxtHeder.Name = "TxtHeder"
        Me.TxtHeder.Size = New System.Drawing.Size(557, 64)
        Me.TxtHeder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TxtHeder.TabIndex = 9
        Me.TxtHeder.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.UserButton1)
        Me.Panel4.Controls.Add(Me.TxtRightLogo)
        Me.Panel4.Enabled = False
        Me.Panel4.Location = New System.Drawing.Point(309, 269)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(218, 121)
        Me.Panel4.TabIndex = 10
        '
        'UserButton1
        '
        Me.UserButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.UserButton1.Location = New System.Drawing.Point(111, 44)
        Me.UserButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.UserButton1.Name = "UserButton1"
        Me.UserButton1.Size = New System.Drawing.Size(99, 32)
        Me.UserButton1.TabIndex = 10
        Me.UserButton1.Text = "Select"
        Me.UserButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.UserButton1.UseFunctionKeys = False
        Me.UserButton1.UseVisualStyleBackColor = True
        '
        'TxtRightLogo
        '
        Me.TxtRightLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TxtRightLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtRightLogo.Location = New System.Drawing.Point(5, 13)
        Me.TxtRightLogo.Name = "TxtRightLogo"
        Me.TxtRightLogo.Size = New System.Drawing.Size(100, 100)
        Me.TxtRightLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TxtRightLogo.TabIndex = 9
        Me.TxtRightLogo.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnselectleftlogo)
        Me.Panel2.Controls.Add(Me.txtleftlogobox)
        Me.Panel2.Enabled = False
        Me.Panel2.Location = New System.Drawing.Point(46, 269)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(218, 121)
        Me.Panel2.TabIndex = 10
        '
        'btnselectleftlogo
        '
        Me.btnselectleftlogo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnselectleftlogo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnselectleftlogo.Location = New System.Drawing.Point(111, 44)
        Me.btnselectleftlogo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnselectleftlogo.Name = "btnselectleftlogo"
        Me.btnselectleftlogo.Size = New System.Drawing.Size(99, 32)
        Me.btnselectleftlogo.TabIndex = 10
        Me.btnselectleftlogo.Text = "Select"
        Me.btnselectleftlogo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnselectleftlogo.UseFunctionKeys = False
        Me.btnselectleftlogo.UseVisualStyleBackColor = True
        '
        'txtleftlogobox
        '
        Me.txtleftlogobox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.txtleftlogobox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtleftlogobox.Location = New System.Drawing.Point(5, 13)
        Me.txtleftlogobox.Name = "txtleftlogobox"
        Me.txtleftlogobox.Size = New System.Drawing.Size(100, 100)
        Me.txtleftlogobox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.txtleftlogobox.TabIndex = 9
        Me.txtleftlogobox.TabStop = False
        '
        'chkfooter
        '
        Me.chkfooter.AutoSize = True
        Me.chkfooter.Location = New System.Drawing.Point(27, 121)
        Me.chkfooter.Name = "chkfooter"
        Me.chkfooter.Size = New System.Drawing.Size(270, 17)
        Me.chkfooter.TabIndex = 8
        Me.chkfooter.Text = "Print Footer Banner (Size : 750 x 80 Pixels)"
        Me.chkfooter.UseVisualStyleBackColor = True
        '
        'chkheader
        '
        Me.chkheader.AutoSize = True
        Me.chkheader.Location = New System.Drawing.Point(27, 3)
        Me.chkheader.Name = "chkheader"
        Me.chkheader.Size = New System.Drawing.Size(275, 17)
        Me.chkheader.TabIndex = 8
        Me.chkheader.Text = "Print Header Banner (Size : 750 x 80 Pixels)"
        Me.chkheader.UseVisualStyleBackColor = True
        '
        'chkright
        '
        Me.chkright.AutoSize = True
        Me.chkright.Location = New System.Drawing.Point(294, 249)
        Me.chkright.Name = "chkright"
        Me.chkright.Size = New System.Drawing.Size(249, 17)
        Me.chkright.TabIndex = 8
        Me.chkright.Text = "Print Right Logo  (Size : 80 x 80 Pixels)"
        Me.chkright.UseVisualStyleBackColor = True
        '
        'chkleft
        '
        Me.chkleft.AutoSize = True
        Me.chkleft.Location = New System.Drawing.Point(27, 250)
        Me.chkleft.Name = "chkleft"
        Me.chkleft.Size = New System.Drawing.Size(237, 17)
        Me.chkleft.TabIndex = 8
        Me.chkleft.Text = "Print Left Logo (Size : 80 x 80 Pixels)"
        Me.chkleft.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(774, 533)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'CrPrintingOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 533)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CrPrintingOptions"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Printing Options"
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        CType(Me.txtfooter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        CType(Me.TxtHeder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.TxtRightLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.txtleftlogobox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents chkfooter As System.Windows.Forms.CheckBox
    Friend WithEvents chkheader As System.Windows.Forms.CheckBox
    Friend WithEvents chkright As System.Windows.Forms.CheckBox
    Friend WithEvents chkleft As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtleftlogobox As System.Windows.Forms.PictureBox
    Friend WithEvents ispagenumbers As System.Windows.Forms.CheckBox
    Friend WithEvents IsTitle As System.Windows.Forms.CheckBox
    Friend WithEvents IsCompanyAddress As System.Windows.Forms.CheckBox
    Friend WithEvents IscompanyName As System.Windows.Forms.CheckBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents UserButton2 As UserButton.UserButton
    Friend WithEvents TxtHeder As System.Windows.Forms.PictureBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents UserButton1 As UserButton.UserButton
    Friend WithEvents TxtRightLogo As System.Windows.Forms.PictureBox
    Friend WithEvents btnselectleftlogo As UserButton.UserButton
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents UserButton3 As UserButton.UserButton
    Friend WithEvents txtfooter As System.Windows.Forms.PictureBox

End Class
