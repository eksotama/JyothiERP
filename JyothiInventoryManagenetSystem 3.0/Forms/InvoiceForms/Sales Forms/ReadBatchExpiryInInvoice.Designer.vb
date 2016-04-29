<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReadBatchExpiryInInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReadBatchExpiryInInvoice))
        Me.txtbatchno = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.txtexpirydate = New JyothiPharmaERPSystem3.IMSDate()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.txtmrp = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtMonth = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtYear = New JyothiPharmaERPSystem3.IMSDate()
        Me.SuspendLayout()
        '
        'txtbatchno
        '
        Me.txtbatchno.AllowToolTip = True
        Me.txtbatchno.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.txtbatchno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbatchno.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtbatchno.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtbatchno.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtbatchno.IsAllowDigits = True
        Me.txtbatchno.IsAllowSpace = True
        Me.txtbatchno.IsAllowSplChars = True
        Me.txtbatchno.LFocusBackColor = System.Drawing.Color.White
        Me.txtbatchno.Location = New System.Drawing.Point(144, 12)
        Me.txtbatchno.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtbatchno.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtbatchno.MaxLength = 25
        Me.txtbatchno.Name = "txtbatchno"
        Me.txtbatchno.SetToolTip = Nothing
        Me.txtbatchno.Size = New System.Drawing.Size(149, 21)
        Me.txtbatchno.SpecialCharList = "&-/@"
        Me.txtbatchno.TabIndex = 0
        Me.txtbatchno.UseFunctionKeys = False
        '
        'txtexpirydate
        '
        Me.txtexpirydate.CustomFormat = "MM/yyyy"
        Me.txtexpirydate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtexpirydate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtexpirydate.Location = New System.Drawing.Point(12, 129)
        Me.txtexpirydate.Name = "txtexpirydate"
        Me.txtexpirydate.Size = New System.Drawing.Size(281, 21)
        Me.txtexpirydate.TabIndex = 2
        Me.txtexpirydate.TabStop = False
        Me.txtexpirydate.Visible = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(24, 15)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(89, 13)
        Me.ImSlabel1.TabIndex = 3
        Me.ImSlabel1.Text = "New Batch No"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(24, 68)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(104, 13)
        Me.ImSlabel2.TabIndex = 3
        Me.ImSlabel2.Text = "Expiry Date(M/Y)"
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnClose.Location = New System.Drawing.Point(50, 90)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(103, 33)
        Me.BtnClose.TabIndex = 5
        Me.BtnClose.Text = "Cancel"
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
        Me.BtnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCreate.Location = New System.Drawing.Point(190, 90)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(103, 33)
        Me.BtnCreate.TabIndex = 4
        Me.BtnCreate.Text = "Create"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = False
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(24, 41)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(34, 13)
        Me.ImSlabel3.TabIndex = 3
        Me.ImSlabel3.Text = "MRP"
        '
        'txtmrp
        '
        Me.txtmrp.AllHelpText = True
        Me.txtmrp.AllowDecimal = True
        Me.txtmrp.AllowFormulas = False
        Me.txtmrp.AllowForQty = True
        Me.txtmrp.AllowNegative = False
        Me.txtmrp.AllowPerSign = False
        Me.txtmrp.AllowPlusSign = False
        Me.txtmrp.AllowToolTip = True
        Me.txtmrp.DecimalPlaces = CType(3, Short)
        Me.txtmrp.ExitOnEscKey = True
        Me.txtmrp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmrp.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtmrp.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtmrp.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtmrp.HelpText = Nothing
        Me.txtmrp.LFocusBackColor = System.Drawing.Color.White
        Me.txtmrp.Location = New System.Drawing.Point(144, 38)
        Me.txtmrp.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtmrp.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtmrp.Max = CType(100000000000000, Long)
        Me.txtmrp.MaxLength = 12
        Me.txtmrp.Min = CType(0, Long)
        Me.txtmrp.Name = "txtmrp"
        Me.txtmrp.NextOnEnter = True
        Me.txtmrp.SetToolTip = Nothing
        Me.txtmrp.Size = New System.Drawing.Size(149, 21)
        Me.txtmrp.TabIndex = 1
        Me.txtmrp.Text = "0"
        Me.txtmrp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtmrp.ToolTip = Nothing
        Me.txtmrp.UseFunctionKeys = False
        Me.txtmrp.UseUpDownArrowKeys = False
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(298, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(22, 19)
        Me.Panel1.TabIndex = 5
        '
        'TxtMonth
        '
        Me.TxtMonth.CustomFormat = "MM"
        Me.TxtMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtMonth.Location = New System.Drawing.Point(146, 62)
        Me.TxtMonth.Name = "TxtMonth"
        Me.TxtMonth.ShowUpDown = True
        Me.TxtMonth.Size = New System.Drawing.Size(60, 21)
        Me.TxtMonth.TabIndex = 2
        '
        'TxtYear
        '
        Me.TxtYear.CustomFormat = "yyyy"
        Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtYear.Location = New System.Drawing.Point(226, 62)
        Me.TxtYear.Name = "TxtYear"
        Me.TxtYear.ShowUpDown = True
        Me.TxtYear.Size = New System.Drawing.Size(67, 21)
        Me.TxtYear.TabIndex = 3
        '
        'ReadBatchExpiryInInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(332, 126)
        Me.Controls.Add(Me.TxtYear)
        Me.Controls.Add(Me.TxtMonth)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtmrp)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnCreate)
        Me.Controls.Add(Me.ImSlabel3)
        Me.Controls.Add(Me.ImSlabel2)
        Me.Controls.Add(Me.ImSlabel1)
        Me.Controls.Add(Me.txtexpirydate)
        Me.Controls.Add(Me.txtbatchno)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReadBatchExpiryInInvoice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Enter Batch No and Expiry Date"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtbatchno As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents txtexpirydate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents txtmrp As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtMonth As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtYear As JyothiPharmaERPSystem3.IMSDate

End Class
