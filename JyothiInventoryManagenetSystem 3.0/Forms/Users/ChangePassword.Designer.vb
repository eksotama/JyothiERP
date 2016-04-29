<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangePassword))
        Me.TxtTitle = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtPassword1 = New System.Windows.Forms.TextBox()
        Me.TxtPassword2 = New System.Windows.Forms.TextBox()
        Me.BtnOk = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCancle = New JyothiPharmaERPSystem3.IMSButton()
        Me.SuspendLayout()
        '
        'TxtTitle
        '
        Me.TxtTitle.AutoSize = True
        Me.TxtTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitle.Location = New System.Drawing.Point(24, 23)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(155, 13)
        Me.TxtTitle.TabIndex = 0
        Me.TxtTitle.Text = "Change Password User ID"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(72, 63)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(90, 13)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "New Password"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(72, 98)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(107, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "Confirm Password"
        '
        'TxtPassword1
        '
        Me.TxtPassword1.Location = New System.Drawing.Point(200, 60)
        Me.TxtPassword1.Name = "TxtPassword1"
        Me.TxtPassword1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword1.Size = New System.Drawing.Size(133, 20)
        Me.TxtPassword1.TabIndex = 0
        '
        'TxtPassword2
        '
        Me.TxtPassword2.Location = New System.Drawing.Point(200, 95)
        Me.TxtPassword2.Name = "TxtPassword2"
        Me.TxtPassword2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword2.Size = New System.Drawing.Size(133, 20)
        Me.TxtPassword2.TabIndex = 1
        '
        'BtnOk
        '
        Me.BtnOk.AllowToolTip = True
        Me.BtnOk.BackColor = System.Drawing.Color.White
        Me.BtnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOk.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        Me.BtnOk.Location = New System.Drawing.Point(264, 158)
        Me.BtnOk.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.SetToolTip = ""
        Me.BtnOk.Size = New System.Drawing.Size(149, 49)
        Me.BtnOk.TabIndex = 2
        Me.BtnOk.Text = "Save"
        Me.BtnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnOk.UseFunctionKeys = False
        Me.BtnOk.UseVisualStyleBackColor = False
        '
        'BtnCancle
        '
        Me.BtnCancle.AllowToolTip = True
        Me.BtnCancle.BackColor = System.Drawing.Color.White
        Me.BtnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancle.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCancle.Image = CType(resources.GetObject("BtnCancle.Image"), System.Drawing.Image)
        Me.BtnCancle.Location = New System.Drawing.Point(27, 158)
        Me.BtnCancle.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCancle.Name = "BtnCancle"
        Me.BtnCancle.SetToolTip = ""
        Me.BtnCancle.Size = New System.Drawing.Size(153, 49)
        Me.BtnCancle.TabIndex = 3
        Me.BtnCancle.Text = "Cancel"
        Me.BtnCancle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancle.UseFunctionKeys = False
        Me.BtnCancle.UseVisualStyleBackColor = False
        '
        'ChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(441, 219)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.BtnCancle)
        Me.Controls.Add(Me.TxtPassword2)
        Me.Controls.Add(Me.TxtPassword1)
        Me.Controls.Add(Me.ImSlabel1)
        Me.Controls.Add(Me.ImSlabel2)
        Me.Controls.Add(Me.TxtTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChangePassword"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtTitle As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtPassword1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtPassword2 As System.Windows.Forms.TextBox
    Friend WithEvents BtnOk As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCancle As JyothiPharmaERPSystem3.IMSButton

End Class
