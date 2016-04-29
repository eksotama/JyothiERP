<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeEMailSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeEMailSettings))
        Me.TxtType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.BtnSave = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCancel = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TXTMSG = New System.Windows.Forms.RichTextBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtSubject = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.SuspendLayout()
        '
        'TxtType
        '
        Me.TxtType.AllowEmpty = True
        Me.TxtType.AllowOnlyListValues = False
        Me.TxtType.AllowToolTip = True
        Me.TxtType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtType.FormattingEnabled = True
        Me.TxtType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtType.IsAdvanceSearchWindow = False
        Me.TxtType.IsAllowDigits = True
        Me.TxtType.IsAllowSpace = True
        Me.TxtType.IsAllowSplChars = True
        Me.TxtType.IsAllowToolTip = True
        Me.TxtType.Items.AddRange(New Object() {"Air Ticket Expiry", "BirthDay", "Emirates Expiry", "Labour Card Expiry", "Leave Salary Expiry", "Medical Card Expiry", "Passport Expiry", "Visa Expiry"})
        Me.TxtType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtType.Location = New System.Drawing.Point(144, 30)
        Me.TxtType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtType.Name = "TxtType"
        Me.TxtType.SetToolTip = Nothing
        Me.TxtType.Size = New System.Drawing.Size(267, 21)
        Me.TxtType.Sorted = True
        Me.TxtType.SpecialCharList = "&-/@"
        Me.TxtType.TabIndex = 41
        Me.TxtType.UseFunctionKeys = False
        '
        'BtnSave
        '
        Me.BtnSave.AllowToolTip = True
        Me.BtnSave.BackColor = System.Drawing.Color.White
        Me.BtnSave.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(604, 350)
        Me.BtnSave.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.SetToolTip = ""
        Me.BtnSave.Size = New System.Drawing.Size(141, 53)
        Me.BtnSave.TabIndex = 39
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseFunctionKeys = False
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnCancel
        '
        Me.BtnCancel.AllowToolTip = True
        Me.BtnCancel.BackColor = System.Drawing.Color.White
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(317, 350)
        Me.BtnCancel.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.SetToolTip = ""
        Me.BtnCancel.Size = New System.Drawing.Size(141, 53)
        Me.BtnCancel.TabIndex = 40
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseFunctionKeys = False
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'ImsHeadingLabel1
        '
        Me.ImsHeadingLabel1.BackColor = System.Drawing.Color.DarkOrange
        Me.ImsHeadingLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ImsHeadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsHeadingLabel1.ForeColor = System.Drawing.Color.White
        Me.ImsHeadingLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ImsHeadingLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsHeadingLabel1.Name = "ImsHeadingLabel1"
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(798, 24)
        Me.ImsHeadingLabel1.TabIndex = 26
        Me.ImsHeadingLabel1.Text = "EMPLOYEE EMAIL SETTINGS"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(22, 33)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(109, 13)
        Me.ImSlabel5.TabIndex = 24
        Me.ImSlabel5.Text = "Select Email Type"
        '
        'TXTMSG
        '
        Me.TXTMSG.Location = New System.Drawing.Point(25, 109)
        Me.TXTMSG.Name = "TXTMSG"
        Me.TXTMSG.Size = New System.Drawing.Size(761, 161)
        Me.TXTMSG.TabIndex = 42
        Me.TXTMSG.Text = ""
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(22, 93)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(165, 13)
        Me.ImSlabel1.TabIndex = 24
        Me.ImSlabel1.Text = "Message Text (HTML Code)"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(25, 298)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(234, 141)
        Me.RichTextBox1.TabIndex = 43
        Me.RichTextBox1.Text = "@EmpName@" & Global.Microsoft.VisualBasic.ChrW(10) & "@DateofBirth@" & Global.Microsoft.VisualBasic.ChrW(10) & "@DateofJoining@" & Global.Microsoft.VisualBasic.ChrW(10) & "@Designation@" & Global.Microsoft.VisualBasic.ChrW(10) & "@DepName@" & Global.Microsoft.VisualBasic.ChrW(10) & "@address@" & Global.Microsoft.VisualBasic.ChrW(10) & "@contac" & _
    "tno@" & Global.Microsoft.VisualBasic.ChrW(10) & "@expirydate@" & Global.Microsoft.VisualBasic.ChrW(10) & "@expiryindays@"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(22, 282)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(221, 13)
        Me.ImSlabel2.TabIndex = 24
        Me.ImSlabel2.Text = "Fields (Will be replace by the values )"
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(22, 63)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(50, 13)
        Me.ImSlabel3.TabIndex = 24
        Me.ImSlabel3.Text = "Subject"
        '
        'TxtSubject
        '
        Me.TxtSubject.AllowToolTip = True
        Me.TxtSubject.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtSubject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtSubject.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSubject.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSubject.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtSubject.IsAllowDigits = True
        Me.TxtSubject.IsAllowSpace = True
        Me.TxtSubject.IsAllowSplChars = True
        Me.TxtSubject.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSubject.Location = New System.Drawing.Point(146, 57)
        Me.TxtSubject.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSubject.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtSubject.MaxLength = 150
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.SetToolTip = Nothing
        Me.TxtSubject.Size = New System.Drawing.Size(495, 20)
        Me.TxtSubject.SpecialCharList = "&-/@"
        Me.TxtSubject.TabIndex = 44
        Me.TxtSubject.UseFunctionKeys = False
        '
        'EmployeeEMailSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(798, 451)
        Me.Controls.Add(Me.TxtSubject)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.TXTMSG)
        Me.Controls.Add(Me.TxtType)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.ImsHeadingLabel1)
        Me.Controls.Add(Me.ImSlabel3)
        Me.Controls.Add(Me.ImSlabel1)
        Me.Controls.Add(Me.ImSlabel2)
        Me.Controls.Add(Me.ImSlabel5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EmployeeEMailSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Employee EMail Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents BtnSave As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCancel As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TXTMSG As System.Windows.Forms.RichTextBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtSubject As JyothiPharmaERPSystem3.IMSTextBox

End Class
