<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecoverPassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecoverPassword))
        Me.BtnQ = New System.Windows.Forms.RadioButton()
        Me.BtnEmailID = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnOk = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCancle = New JyothiPharmaERPSystem3.IMSButton()
        Me.pannel = New System.Windows.Forms.Panel()
        Me.P1 = New System.Windows.Forms.Panel()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.p3 = New System.Windows.Forms.Panel()
        Me.ImSlabel9 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.PanelCode = New System.Windows.Forms.Panel()
        Me.TxtCode = New System.Windows.Forms.TextBox()
        Me.TxtEmailId = New System.Windows.Forms.TextBox()
        Me.P2 = New System.Windows.Forms.Panel()
        Me.ImSlabel14 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel13 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel12 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel11 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel10 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtA1 = New System.Windows.Forms.TextBox()
        Me.TxtUserID = New System.Windows.Forms.TextBox()
        Me.TxtQ1 = New System.Windows.Forms.TextBox()
        Me.TxtA2 = New System.Windows.Forms.TextBox()
        Me.TxtQ2 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.Panel2.SuspendLayout()
        Me.pannel.SuspendLayout()
        Me.P1.SuspendLayout()
        Me.p3.SuspendLayout()
        Me.P2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnQ
        '
        Me.BtnQ.AutoSize = True
        Me.BtnQ.Location = New System.Drawing.Point(21, 111)
        Me.BtnQ.Name = "BtnQ"
        Me.BtnQ.Size = New System.Drawing.Size(212, 17)
        Me.BtnQ.TabIndex = 0
        Me.BtnQ.Text = "Recover By Security Questions ?"
        Me.BtnQ.UseVisualStyleBackColor = True
        '
        'BtnEmailID
        '
        Me.BtnEmailID.AutoSize = True
        Me.BtnEmailID.Checked = True
        Me.BtnEmailID.Location = New System.Drawing.Point(21, 16)
        Me.BtnEmailID.Name = "BtnEmailID"
        Me.BtnEmailID.Size = New System.Drawing.Size(148, 17)
        Me.BtnEmailID.TabIndex = 0
        Me.BtnEmailID.TabStop = True
        Me.BtnEmailID.Text = "Recover by Email ID?"
        Me.BtnEmailID.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnOk)
        Me.Panel2.Controls.Add(Me.BtnCancle)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 359)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(608, 60)
        Me.Panel2.TabIndex = 1
        '
        'BtnOk
        '
        Me.BtnOk.AllowToolTip = True
        Me.BtnOk.BackColor = System.Drawing.Color.White
        Me.BtnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOk.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        Me.BtnOk.Location = New System.Drawing.Point(342, 5)
        Me.BtnOk.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.SetToolTip = ""
        Me.BtnOk.Size = New System.Drawing.Size(147, 50)
        Me.BtnOk.TabIndex = 0
        Me.BtnOk.Text = "&Next"
        Me.BtnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnOk.UseFunctionKeys = False
        Me.BtnOk.UseVisualStyleBackColor = False
        '
        'BtnCancle
        '
        Me.BtnCancle.AllowToolTip = True
        Me.BtnCancle.BackColor = System.Drawing.Color.White
        Me.BtnCancle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancle.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCancle.Image = CType(resources.GetObject("BtnCancle.Image"), System.Drawing.Image)
        Me.BtnCancle.Location = New System.Drawing.Point(60, 5)
        Me.BtnCancle.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCancle.Name = "BtnCancle"
        Me.BtnCancle.SetToolTip = ""
        Me.BtnCancle.Size = New System.Drawing.Size(156, 50)
        Me.BtnCancle.TabIndex = 0
        Me.BtnCancle.Text = "Cancel"
        Me.BtnCancle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancle.UseFunctionKeys = False
        Me.BtnCancle.UseVisualStyleBackColor = False
        '
        'pannel
        '
        Me.pannel.Controls.Add(Me.P1)
        Me.pannel.Controls.Add(Me.P2)
        Me.pannel.Controls.Add(Me.BtnQ)
        Me.pannel.Controls.Add(Me.BtnEmailID)
        Me.pannel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pannel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pannel.Location = New System.Drawing.Point(0, 0)
        Me.pannel.Margin = New System.Windows.Forms.Padding(0)
        Me.pannel.Name = "pannel"
        Me.pannel.Size = New System.Drawing.Size(602, 328)
        Me.pannel.TabIndex = 0
        '
        'P1
        '
        Me.P1.Controls.Add(Me.ImSlabel8)
        Me.P1.Controls.Add(Me.p3)
        Me.P1.Controls.Add(Me.TxtEmailId)
        Me.P1.Location = New System.Drawing.Point(39, 39)
        Me.P1.Name = "P1"
        Me.P1.Size = New System.Drawing.Size(554, 66)
        Me.P1.TabIndex = 2
        '
        'ImSlabel8
        '
        Me.ImSlabel8.AutoSize = True
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(15, 8)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(54, 13)
        Me.ImSlabel8.TabIndex = 4
        Me.ImSlabel8.Text = "Email ID"
        '
        'p3
        '
        Me.p3.Controls.Add(Me.ImSlabel9)
        Me.p3.Controls.Add(Me.PanelCode)
        Me.p3.Controls.Add(Me.TxtCode)
        Me.p3.Location = New System.Drawing.Point(9, 33)
        Me.p3.Margin = New System.Windows.Forms.Padding(0)
        Me.p3.Name = "p3"
        Me.p3.Size = New System.Drawing.Size(452, 29)
        Me.p3.TabIndex = 3
        Me.p3.Visible = False
        '
        'ImSlabel9
        '
        Me.ImSlabel9.AutoSize = True
        Me.ImSlabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel9.Location = New System.Drawing.Point(99, 9)
        Me.ImSlabel9.Name = "ImSlabel9"
        Me.ImSlabel9.Size = New System.Drawing.Size(94, 13)
        Me.ImSlabel9.TabIndex = 4
        Me.ImSlabel9.Text = "Recovery Code"
        '
        'PanelCode
        '
        Me.PanelCode.Location = New System.Drawing.Point(9, 33)
        Me.PanelCode.Margin = New System.Windows.Forms.Padding(0)
        Me.PanelCode.Name = "PanelCode"
        Me.PanelCode.Size = New System.Drawing.Size(452, 29)
        Me.PanelCode.TabIndex = 3
        Me.PanelCode.Visible = False
        '
        'TxtCode
        '
        Me.TxtCode.Location = New System.Drawing.Point(198, 5)
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Size = New System.Drawing.Size(124, 20)
        Me.TxtCode.TabIndex = 0
        '
        'TxtEmailId
        '
        Me.TxtEmailId.Location = New System.Drawing.Point(111, 5)
        Me.TxtEmailId.Name = "TxtEmailId"
        Me.TxtEmailId.Size = New System.Drawing.Size(268, 20)
        Me.TxtEmailId.TabIndex = 0
        '
        'P2
        '
        Me.P2.Controls.Add(Me.ImSlabel14)
        Me.P2.Controls.Add(Me.ImSlabel13)
        Me.P2.Controls.Add(Me.ImSlabel12)
        Me.P2.Controls.Add(Me.ImSlabel11)
        Me.P2.Controls.Add(Me.ImSlabel10)
        Me.P2.Controls.Add(Me.TxtA1)
        Me.P2.Controls.Add(Me.TxtUserID)
        Me.P2.Controls.Add(Me.TxtQ1)
        Me.P2.Controls.Add(Me.TxtA2)
        Me.P2.Controls.Add(Me.TxtQ2)
        Me.P2.Location = New System.Drawing.Point(36, 134)
        Me.P2.Name = "P2"
        Me.P2.Size = New System.Drawing.Size(557, 154)
        Me.P2.TabIndex = 2
        '
        'ImSlabel14
        '
        Me.ImSlabel14.AutoSize = True
        Me.ImSlabel14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel14.Location = New System.Drawing.Point(11, 123)
        Me.ImSlabel14.Name = "ImSlabel14"
        Me.ImSlabel14.Size = New System.Drawing.Size(48, 13)
        Me.ImSlabel14.TabIndex = 4
        Me.ImSlabel14.Text = "Answer"
        '
        'ImSlabel13
        '
        Me.ImSlabel13.AutoSize = True
        Me.ImSlabel13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel13.Location = New System.Drawing.Point(9, 65)
        Me.ImSlabel13.Name = "ImSlabel13"
        Me.ImSlabel13.Size = New System.Drawing.Size(48, 13)
        Me.ImSlabel13.TabIndex = 4
        Me.ImSlabel13.Text = "Answer"
        '
        'ImSlabel12
        '
        Me.ImSlabel12.AutoSize = True
        Me.ImSlabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel12.Location = New System.Drawing.Point(11, 97)
        Me.ImSlabel12.Name = "ImSlabel12"
        Me.ImSlabel12.Size = New System.Drawing.Size(68, 13)
        Me.ImSlabel12.TabIndex = 4
        Me.ImSlabel12.Text = "Question 2"
        '
        'ImSlabel11
        '
        Me.ImSlabel11.AutoSize = True
        Me.ImSlabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel11.Location = New System.Drawing.Point(9, 35)
        Me.ImSlabel11.Name = "ImSlabel11"
        Me.ImSlabel11.Size = New System.Drawing.Size(68, 13)
        Me.ImSlabel11.TabIndex = 4
        Me.ImSlabel11.Text = "Question 1"
        '
        'ImSlabel10
        '
        Me.ImSlabel10.AutoSize = True
        Me.ImSlabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel10.Location = New System.Drawing.Point(9, 9)
        Me.ImSlabel10.Name = "ImSlabel10"
        Me.ImSlabel10.Size = New System.Drawing.Size(50, 13)
        Me.ImSlabel10.TabIndex = 4
        Me.ImSlabel10.Text = "User ID"
        '
        'TxtA1
        '
        Me.TxtA1.Location = New System.Drawing.Point(114, 58)
        Me.TxtA1.Name = "TxtA1"
        Me.TxtA1.Size = New System.Drawing.Size(414, 20)
        Me.TxtA1.TabIndex = 2
        '
        'TxtUserID
        '
        Me.TxtUserID.Location = New System.Drawing.Point(114, 6)
        Me.TxtUserID.Name = "TxtUserID"
        Me.TxtUserID.Size = New System.Drawing.Size(133, 20)
        Me.TxtUserID.TabIndex = 0
        '
        'TxtQ1
        '
        Me.TxtQ1.BackColor = System.Drawing.Color.White
        Me.TxtQ1.Location = New System.Drawing.Point(114, 32)
        Me.TxtQ1.Name = "TxtQ1"
        Me.TxtQ1.ReadOnly = True
        Me.TxtQ1.Size = New System.Drawing.Size(414, 20)
        Me.TxtQ1.TabIndex = 1
        '
        'TxtA2
        '
        Me.TxtA2.BackColor = System.Drawing.Color.White
        Me.TxtA2.Location = New System.Drawing.Point(114, 120)
        Me.TxtA2.Name = "TxtA2"
        Me.TxtA2.Size = New System.Drawing.Size(414, 20)
        Me.TxtA2.TabIndex = 4
        '
        'TxtQ2
        '
        Me.TxtQ2.BackColor = System.Drawing.Color.White
        Me.TxtQ2.Location = New System.Drawing.Point(114, 94)
        Me.TxtQ2.Name = "TxtQ2"
        Me.TxtQ2.ReadOnly = True
        Me.TxtQ2.Size = New System.Drawing.Size(414, 20)
        Me.TxtQ2.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pannel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(602, 328)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ImsHeadingLabel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.963789!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.03621!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(608, 419)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'ImsHeadingLabel1
        '
        Me.ImsHeadingLabel1.AutoSize = True
        Me.ImsHeadingLabel1.BackColor = System.Drawing.Color.DarkOrange
        Me.ImsHeadingLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsHeadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsHeadingLabel1.ForeColor = System.Drawing.Color.White
        Me.ImsHeadingLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ImsHeadingLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsHeadingLabel1.Name = "ImsHeadingLabel1"
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(608, 25)
        Me.ImsHeadingLabel1.TabIndex = 2
        Me.ImsHeadingLabel1.Text = "PASSWORD RECOVERY OPTIONS"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RecoverPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(608, 419)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RecoverPassword"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Recover Password"
        Me.Panel2.ResumeLayout(False)
        Me.pannel.ResumeLayout(False)
        Me.pannel.PerformLayout()
        Me.P1.ResumeLayout(False)
        Me.P1.PerformLayout()
        Me.p3.ResumeLayout(False)
        Me.p3.PerformLayout()
        Me.P2.ResumeLayout(False)
        Me.P2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnQ As System.Windows.Forms.RadioButton
    Friend WithEvents BtnEmailID As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnOk As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCancle As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents pannel As System.Windows.Forms.Panel
    Friend WithEvents P1 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtEmailId As System.Windows.Forms.TextBox
    Friend WithEvents P2 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtUserID As System.Windows.Forms.TextBox
    Friend WithEvents TxtA2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtQ2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtA1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtQ1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtHeading As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents p3 As System.Windows.Forms.Panel
    Friend WithEvents TxtCode As System.Windows.Forms.TextBox
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents PanelCode As System.Windows.Forms.Panel
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel9 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel14 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel13 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel12 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel11 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel10 As JyothiPharmaERPSystem3.IMSlabel

End Class
