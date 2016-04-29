<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreatePayslipType
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreatePayslipType))
        Me.BtnSave = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCancel = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.TxtName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtPayLedger = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel9 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.SuspendLayout()
        '
        'BtnSave
        '
        Me.BtnSave.AllowToolTip = True
        Me.BtnSave.BackColor = System.Drawing.Color.White
        Me.BtnSave.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(294, 128)
        Me.BtnSave.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.SetToolTip = ""
        Me.BtnSave.Size = New System.Drawing.Size(141, 53)
        Me.BtnSave.TabIndex = 2
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
        Me.BtnCancel.Location = New System.Drawing.Point(68, 128)
        Me.BtnCancel.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.SetToolTip = ""
        Me.BtnCancel.Size = New System.Drawing.Size(141, 53)
        Me.BtnCancel.TabIndex = 3
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
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(491, 24)
        Me.ImsHeadingLabel1.TabIndex = 26
        Me.ImsHeadingLabel1.Text = "PAY SLIP TYPES / GROUPS"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TxtName
        '
        Me.TxtName.AllowToolTip = True
        Me.TxtName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtName.IsAllowDigits = True
        Me.TxtName.IsAllowSpace = True
        Me.TxtName.IsAllowSplChars = True
        Me.TxtName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtName.Location = New System.Drawing.Point(191, 43)
        Me.TxtName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtName.MaxLength = 50
        Me.TxtName.Name = "TxtName"
        Me.TxtName.SetToolTip = Nothing
        Me.TxtName.Size = New System.Drawing.Size(268, 20)
        Me.TxtName.SpecialCharList = "&-/@"
        Me.TxtName.TabIndex = 0
        Me.TxtName.UseFunctionKeys = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(29, 44)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(156, 13)
        Me.ImSlabel1.TabIndex = 42
        Me.ImSlabel1.Text = "Name Of the PaySlip Type"
        '
        'TxtPayLedger
        '
        Me.TxtPayLedger.AllowEmpty = True
        Me.TxtPayLedger.AllowOnlyListValues = True
        Me.TxtPayLedger.AllowToolTip = True
        Me.TxtPayLedger.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtPayLedger.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtPayLedger.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtPayLedger.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPayLedger.FormattingEnabled = True
        Me.TxtPayLedger.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPayLedger.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPayLedger.IsAdvanceSearchWindow = False
        Me.TxtPayLedger.IsAllowDigits = True
        Me.TxtPayLedger.IsAllowSpace = True
        Me.TxtPayLedger.IsAllowSplChars = True
        Me.TxtPayLedger.IsAllowToolTip = True
        Me.TxtPayLedger.Items.AddRange(New Object() {"On Basic", "On Total"})
        Me.TxtPayLedger.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPayLedger.Location = New System.Drawing.Point(191, 78)
        Me.TxtPayLedger.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPayLedger.Name = "TxtPayLedger"
        Me.TxtPayLedger.SetToolTip = Nothing
        Me.TxtPayLedger.Size = New System.Drawing.Size(268, 21)
        Me.TxtPayLedger.Sorted = True
        Me.TxtPayLedger.SpecialCharList = "&-/@"
        Me.TxtPayLedger.TabIndex = 1
        Me.TxtPayLedger.UseFunctionKeys = False
        '
        'ImSlabel9
        '
        Me.ImSlabel9.AutoSize = True
        Me.ImSlabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel9.Location = New System.Drawing.Point(29, 86)
        Me.ImSlabel9.Name = "ImSlabel9"
        Me.ImSlabel9.Size = New System.Drawing.Size(73, 13)
        Me.ImSlabel9.TabIndex = 44
        Me.ImSlabel9.Text = "Payment By"
        '
        'CreatePayslipType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(491, 201)
        Me.Controls.Add(Me.TxtPayLedger)
        Me.Controls.Add(Me.ImSlabel9)
        Me.Controls.Add(Me.ImSlabel1)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.ImsHeadingLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CreatePayslipType"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CreatePayslipType"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnSave As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCancel As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents TxtName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtPayLedger As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel9 As JyothiPharmaERPSystem3.IMSlabel

End Class
