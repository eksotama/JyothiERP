<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DutySettingForME
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
        Me.BtnSave = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCancel = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtEStartDate1 = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtStartDate1 = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtEENDDate1 = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtEndDate1 = New JyothiPharmaERPSystem3.IMSDate()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImsDate1 = New JyothiPharmaERPSystem3.IMSDate()
        Me.ImsDate2 = New JyothiPharmaERPSystem3.IMSDate()
        Me.LblEmployeeName = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.SuspendLayout()
        '
        'BtnSave
        '
        Me.BtnSave.AllowToolTip = True
        Me.BtnSave.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnSave.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.Save__1_
        Me.BtnSave.Location = New System.Drawing.Point(310, 282)
        Me.BtnSave.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.SetToolTip = ""
        Me.BtnSave.Size = New System.Drawing.Size(141, 53)
        Me.BtnSave.TabIndex = 38
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseFunctionKeys = False
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.AllowToolTip = True
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCancel.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnCancel.Location = New System.Drawing.Point(64, 282)
        Me.BtnCancel.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.SetToolTip = ""
        Me.BtnCancel.Size = New System.Drawing.Size(141, 53)
        Me.BtnCancel.TabIndex = 39
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseFunctionKeys = False
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'TxtEStartDate1
        '
        Me.TxtEStartDate1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEStartDate1.CustomFormat = "HH:mm"
        Me.TxtEStartDate1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEStartDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEStartDate1.Location = New System.Drawing.Point(215, 215)
        Me.TxtEStartDate1.Name = "TxtEStartDate1"
        Me.TxtEStartDate1.ShowUpDown = True
        Me.TxtEStartDate1.Size = New System.Drawing.Size(89, 24)
        Me.TxtEStartDate1.TabIndex = 30
        Me.TxtEStartDate1.Visible = False
        '
        'TxtStartDate1
        '
        Me.TxtStartDate1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate1.CustomFormat = "HH:mm"
        Me.TxtStartDate1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtStartDate1.Location = New System.Drawing.Point(215, 164)
        Me.TxtStartDate1.Name = "TxtStartDate1"
        Me.TxtStartDate1.ShowUpDown = True
        Me.TxtStartDate1.Size = New System.Drawing.Size(89, 24)
        Me.TxtStartDate1.TabIndex = 31
        '
        'TxtEENDDate1
        '
        Me.TxtEENDDate1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEENDDate1.CustomFormat = "HH:mm"
        Me.TxtEENDDate1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEENDDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEENDDate1.Location = New System.Drawing.Point(310, 215)
        Me.TxtEENDDate1.Name = "TxtEENDDate1"
        Me.TxtEENDDate1.ShowUpDown = True
        Me.TxtEENDDate1.Size = New System.Drawing.Size(89, 24)
        Me.TxtEENDDate1.TabIndex = 37
        Me.TxtEENDDate1.Visible = False
        '
        'TxtEndDate1
        '
        Me.TxtEndDate1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate1.CustomFormat = "HH:mm"
        Me.TxtEndDate1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtEndDate1.Location = New System.Drawing.Point(310, 164)
        Me.TxtEndDate1.Name = "TxtEndDate1"
        Me.TxtEndDate1.ShowUpDown = True
        Me.TxtEndDate1.Size = New System.Drawing.Size(89, 24)
        Me.TxtEndDate1.TabIndex = 32
        '
        'ImsHeadingLabel1
        '
        Me.ImsHeadingLabel1.BackColor = System.Drawing.Color.Olive
        Me.ImsHeadingLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ImsHeadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsHeadingLabel1.ForeColor = System.Drawing.Color.White
        Me.ImsHeadingLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ImsHeadingLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsHeadingLabel1.Name = "ImsHeadingLabel1"
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(520, 24)
        Me.ImsHeadingLabel1.TabIndex = 25
        Me.ImsHeadingLabel1.Text = "DUTY SETTINGS"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(84, 170)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(82, 13)
        Me.ImSlabel1.TabIndex = 20
        Me.ImSlabel1.Text = "Morning Shift"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(84, 224)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(83, 13)
        Me.ImSlabel2.TabIndex = 20
        Me.ImSlabel2.Text = "Evening Shift"
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(85, 127)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(53, 13)
        Me.ImSlabel3.TabIndex = 20
        Me.ImSlabel3.Text = "Date To"
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(85, 85)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(65, 13)
        Me.ImSlabel4.TabIndex = 20
        Me.ImSlabel4.Text = "Date From"
        '
        'ImsDate1
        '
        Me.ImsDate1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsDate1.Location = New System.Drawing.Point(215, 79)
        Me.ImsDate1.Name = "ImsDate1"
        Me.ImsDate1.Size = New System.Drawing.Size(184, 20)
        Me.ImsDate1.TabIndex = 40
        '
        'ImsDate2
        '
        Me.ImsDate2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsDate2.Location = New System.Drawing.Point(215, 120)
        Me.ImsDate2.Name = "ImsDate2"
        Me.ImsDate2.Size = New System.Drawing.Size(184, 20)
        Me.ImsDate2.TabIndex = 40
        '
        'LblEmployeeName
        '
        Me.LblEmployeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmployeeName.Location = New System.Drawing.Point(2, 36)
        Me.LblEmployeeName.Name = "LblEmployeeName"
        Me.LblEmployeeName.Size = New System.Drawing.Size(518, 25)
        Me.LblEmployeeName.TabIndex = 20
        Me.LblEmployeeName.Text = "For Employee"
        Me.LblEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(84, 256)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(107, 13)
        Me.ImSlabel6.TabIndex = 41
        Me.ImSlabel6.Text = "Note: 24H Format"
        '
        'DutySettingForME
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 358)
        Me.Controls.Add(Me.ImSlabel6)
        Me.Controls.Add(Me.ImsDate2)
        Me.Controls.Add(Me.ImsDate1)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.TxtEStartDate1)
        Me.Controls.Add(Me.TxtStartDate1)
        Me.Controls.Add(Me.TxtEENDDate1)
        Me.Controls.Add(Me.TxtEndDate1)
        Me.Controls.Add(Me.ImsHeadingLabel1)
        Me.Controls.Add(Me.ImSlabel2)
        Me.Controls.Add(Me.LblEmployeeName)
        Me.Controls.Add(Me.ImSlabel4)
        Me.Controls.Add(Me.ImSlabel3)
        Me.Controls.Add(Me.ImSlabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DutySettingForME"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DutySetting For Morning and Evening "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnSave As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCancel As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtEStartDate1 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtStartDate1 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtEENDDate1 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtEndDate1 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImsDate1 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents ImsDate2 As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents LblEmployeeName As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel

End Class
