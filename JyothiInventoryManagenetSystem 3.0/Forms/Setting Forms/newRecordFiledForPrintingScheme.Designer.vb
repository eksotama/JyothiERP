<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class newRecordFiledForPrintingScheme
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(newRecordFiledForPrintingScheme))
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TxtHeading = New UserLabel.UserLabel()
        Me.UserLabel1 = New UserLabel.UserLabel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.TxtRecFiledNames = New System.Windows.Forms.ComboBox()
        Me.UserLabel3 = New UserLabel.UserLabel()
        Me.TxtFieldName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.txtdatatype = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Image = CType(resources.GetObject("Cancel_Button.Image"), System.Drawing.Image)
        Me.Cancel_Button.Location = New System.Drawing.Point(41, 151)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(133, 42)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Close"
        Me.Cancel_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'TxtHeading
        '
        Me.TxtHeading.BackColor = System.Drawing.Color.DarkOrange
        Me.TxtHeading.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHeading.ForeColor = System.Drawing.Color.White
        Me.TxtHeading.Location = New System.Drawing.Point(0, 0)
        Me.TxtHeading.Name = "TxtHeading"
        Me.TxtHeading.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHeading.Size = New System.Drawing.Size(435, 24)
        Me.TxtHeading.TabIndex = 27
        Me.TxtHeading.Text = "ADD NEW RECORD FIELD"
        Me.TxtHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.TxtHeading.TextEnglishCode = Nothing
        '
        'UserLabel1
        '
        Me.UserLabel1.AutoSize = True
        Me.UserLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel1.Location = New System.Drawing.Point(12, 83)
        Me.UserLabel1.Name = "UserLabel1"
        Me.UserLabel1.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel1.Size = New System.Drawing.Size(117, 15)
        Me.UserLabel1.TabIndex = 28
        Me.UserLabel1.Text = "Additional Name "
        Me.UserLabel1.TextEnglishCode = Nothing
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Image = CType(resources.GetObject("OK_Button.Image"), System.Drawing.Image)
        Me.OK_Button.Location = New System.Drawing.Point(265, 151)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(133, 42)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Add"
        Me.OK_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'TxtRecFiledNames
        '
        Me.TxtRecFiledNames.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRecFiledNames.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtRecFiledNames.FormattingEnabled = True
        Me.TxtRecFiledNames.Location = New System.Drawing.Point(180, 49)
        Me.TxtRecFiledNames.Name = "TxtRecFiledNames"
        Me.TxtRecFiledNames.Size = New System.Drawing.Size(241, 21)
        Me.TxtRecFiledNames.TabIndex = 31
        '
        'UserLabel3
        '
        Me.UserLabel3.AutoSize = True
        Me.UserLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel3.Location = New System.Drawing.Point(11, 50)
        Me.UserLabel3.Name = "UserLabel3"
        Me.UserLabel3.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel3.Size = New System.Drawing.Size(163, 15)
        Me.UserLabel3.TabIndex = 29
        Me.UserLabel3.Text = "Select the Record Name"
        Me.UserLabel3.TextEnglishCode = Nothing
        '
        'TxtFieldName
        '
        Me.TxtFieldName.AllowToolTip = True
        Me.TxtFieldName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtFieldName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtFieldName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtFieldName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtFieldName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtFieldName.IsAllowDigits = True
        Me.TxtFieldName.IsAllowSpace = True
        Me.TxtFieldName.IsAllowSplChars = True
        Me.TxtFieldName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtFieldName.Location = New System.Drawing.Point(182, 77)
        Me.TxtFieldName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtFieldName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtFieldName.MaxLength = 25
        Me.TxtFieldName.Name = "TxtFieldName"
        Me.TxtFieldName.SetToolTip = Nothing
        Me.TxtFieldName.Size = New System.Drawing.Size(162, 20)
        Me.TxtFieldName.SpecialCharList = "&-/@"
        Me.TxtFieldName.TabIndex = 32
        Me.TxtFieldName.UseFunctionKeys = False
        '
        'txtdatatype
        '
        Me.txtdatatype.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdatatype.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtdatatype.FormattingEnabled = True
        Me.txtdatatype.Location = New System.Drawing.Point(375, 22)
        Me.txtdatatype.Name = "txtdatatype"
        Me.txtdatatype.Size = New System.Drawing.Size(23, 21)
        Me.txtdatatype.TabIndex = 31
        Me.txtdatatype.Visible = False
        '
        'newRecordFiledForPrintingScheme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(435, 227)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.TxtFieldName)
        Me.Controls.Add(Me.TxtHeading)
        Me.Controls.Add(Me.UserLabel1)
        Me.Controls.Add(Me.txtdatatype)
        Me.Controls.Add(Me.TxtRecFiledNames)
        Me.Controls.Add(Me.UserLabel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "newRecordFiledForPrintingScheme"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add New Record Field"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TxtHeading As UserLabel.UserLabel
    Friend WithEvents UserLabel1 As UserLabel.UserLabel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents TxtRecFiledNames As System.Windows.Forms.ComboBox
    Friend WithEvents UserLabel3 As UserLabel.UserLabel
    Friend WithEvents TxtFieldName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents txtdatatype As System.Windows.Forms.ComboBox

End Class
