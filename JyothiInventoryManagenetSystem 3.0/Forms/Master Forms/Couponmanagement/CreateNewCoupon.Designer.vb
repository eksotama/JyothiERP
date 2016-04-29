<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateNewCoupon
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateNewCoupon))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtIsMultiCoupon = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtPrefix = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtEndNo = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtStartNo = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtDateTo = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtDateFrom = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtMaxValue = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtPer = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCouponName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.79352!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtStatus, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(757, 319)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkOrange
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(757, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CREATE NEW COUPON"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnCreate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 223)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(751, 67)
        Me.Panel1.TabIndex = 1
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(93, 13)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(161, 43)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
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
        Me.BtnCreate.Location = New System.Drawing.Point(409, 13)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(175, 43)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "&Save"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtIsMultiCoupon)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.TxtDateTo)
        Me.Panel2.Controls.Add(Me.TxtDateFrom)
        Me.Panel2.Controls.Add(Me.TxtMaxValue)
        Me.Panel2.Controls.Add(Me.TxtPer)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtCouponName)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(751, 188)
        Me.Panel2.TabIndex = 0
        '
        'TxtIsMultiCoupon
        '
        Me.TxtIsMultiCoupon.AutoSize = True
        Me.TxtIsMultiCoupon.Location = New System.Drawing.Point(433, 6)
        Me.TxtIsMultiCoupon.Name = "TxtIsMultiCoupon"
        Me.TxtIsMultiCoupon.Size = New System.Drawing.Size(138, 17)
        Me.TxtIsMultiCoupon.TabIndex = 6
        Me.TxtIsMultiCoupon.Text = "Create Muliple Coupons"
        Me.TxtIsMultiCoupon.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtPrefix)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TxtEndNo)
        Me.GroupBox1.Controls.Add(Me.TxtStartNo)
        Me.GroupBox1.Location = New System.Drawing.Point(433, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(309, 149)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Setting "
        Me.GroupBox1.Visible = False
        '
        'TxtPrefix
        '
        Me.TxtPrefix.AllowToolTip = True
        Me.TxtPrefix.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtPrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtPrefix.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPrefix.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPrefix.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtPrefix.IsAllowDigits = True
        Me.TxtPrefix.IsAllowSpace = True
        Me.TxtPrefix.IsAllowSplChars = True
        Me.TxtPrefix.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPrefix.Location = New System.Drawing.Point(100, 15)
        Me.TxtPrefix.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPrefix.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtPrefix.MaxLength = 45
        Me.TxtPrefix.Name = "TxtPrefix"
        Me.TxtPrefix.SetToolTip = Nothing
        Me.TxtPrefix.Size = New System.Drawing.Size(175, 20)
        Me.TxtPrefix.SpecialCharList = "&-/@()_"
        Me.TxtPrefix.TabIndex = 0
        Me.TxtPrefix.UseFunctionKeys = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 70)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Coupon End To"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Coupon Start From"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Coupon Prefix"
        '
        'TxtEndNo
        '
        Me.TxtEndNo.AllHelpText = True
        Me.TxtEndNo.AllowDecimal = False
        Me.TxtEndNo.AllowFormulas = False
        Me.TxtEndNo.AllowForQty = True
        Me.TxtEndNo.AllowNegative = False
        Me.TxtEndNo.AllowPerSign = False
        Me.TxtEndNo.AllowPlusSign = False
        Me.TxtEndNo.AllowToolTip = True
        Me.TxtEndNo.DecimalPlaces = CType(6, Short)
        Me.TxtEndNo.ExitOnEscKey = True
        Me.TxtEndNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtEndNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtEndNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtEndNo.HelpText = Nothing
        Me.TxtEndNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtEndNo.Location = New System.Drawing.Point(100, 67)
        Me.TxtEndNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtEndNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtEndNo.Max = CType(9999999, Long)
        Me.TxtEndNo.MaxLength = 7
        Me.TxtEndNo.Min = CType(0, Long)
        Me.TxtEndNo.Name = "TxtEndNo"
        Me.TxtEndNo.NextOnEnter = True
        Me.TxtEndNo.SetToolTip = Nothing
        Me.TxtEndNo.Size = New System.Drawing.Size(102, 20)
        Me.TxtEndNo.TabIndex = 2
        Me.TxtEndNo.Text = "1"
        Me.TxtEndNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtEndNo.ToolTip = Nothing
        Me.TxtEndNo.UseFunctionKeys = False
        Me.TxtEndNo.UseUpDownArrowKeys = False
        '
        'TxtStartNo
        '
        Me.TxtStartNo.AllHelpText = True
        Me.TxtStartNo.AllowDecimal = False
        Me.TxtStartNo.AllowFormulas = False
        Me.TxtStartNo.AllowForQty = True
        Me.TxtStartNo.AllowNegative = False
        Me.TxtStartNo.AllowPerSign = False
        Me.TxtStartNo.AllowPlusSign = False
        Me.TxtStartNo.AllowToolTip = True
        Me.TxtStartNo.DecimalPlaces = CType(6, Short)
        Me.TxtStartNo.ExitOnEscKey = True
        Me.TxtStartNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStartNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStartNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtStartNo.HelpText = Nothing
        Me.TxtStartNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStartNo.Location = New System.Drawing.Point(100, 41)
        Me.TxtStartNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStartNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtStartNo.Max = CType(9999999, Long)
        Me.TxtStartNo.MaxLength = 7
        Me.TxtStartNo.Min = CType(0, Long)
        Me.TxtStartNo.Name = "TxtStartNo"
        Me.TxtStartNo.NextOnEnter = True
        Me.TxtStartNo.SetToolTip = Nothing
        Me.TxtStartNo.Size = New System.Drawing.Size(102, 20)
        Me.TxtStartNo.TabIndex = 1
        Me.TxtStartNo.Text = "1"
        Me.TxtStartNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtStartNo.ToolTip = Nothing
        Me.TxtStartNo.UseFunctionKeys = False
        Me.TxtStartNo.UseUpDownArrowKeys = False
        '
        'TxtDateTo
        '
        Me.TxtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtDateTo.Location = New System.Drawing.Point(154, 108)
        Me.TxtDateTo.Name = "TxtDateTo"
        Me.TxtDateTo.Size = New System.Drawing.Size(144, 20)
        Me.TxtDateTo.TabIndex = 3
        '
        'TxtDateFrom
        '
        Me.TxtDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtDateFrom.Location = New System.Drawing.Point(154, 76)
        Me.TxtDateFrom.Name = "TxtDateFrom"
        Me.TxtDateFrom.Size = New System.Drawing.Size(144, 20)
        Me.TxtDateFrom.TabIndex = 2
        '
        'TxtMaxValue
        '
        Me.TxtMaxValue.AllHelpText = True
        Me.TxtMaxValue.AllowDecimal = True
        Me.TxtMaxValue.AllowFormulas = False
        Me.TxtMaxValue.AllowForQty = True
        Me.TxtMaxValue.AllowNegative = False
        Me.TxtMaxValue.AllowPerSign = False
        Me.TxtMaxValue.AllowPlusSign = False
        Me.TxtMaxValue.AllowToolTip = True
        Me.TxtMaxValue.DecimalPlaces = CType(6, Short)
        Me.TxtMaxValue.ExitOnEscKey = True
        Me.TxtMaxValue.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtMaxValue.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtMaxValue.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtMaxValue.HelpText = Nothing
        Me.TxtMaxValue.LFocusBackColor = System.Drawing.Color.White
        Me.TxtMaxValue.Location = New System.Drawing.Point(154, 148)
        Me.TxtMaxValue.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtMaxValue.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtMaxValue.Max = CType(100000000000000, Long)
        Me.TxtMaxValue.MaxLength = 10
        Me.TxtMaxValue.Min = CType(0, Long)
        Me.TxtMaxValue.Name = "TxtMaxValue"
        Me.TxtMaxValue.NextOnEnter = True
        Me.TxtMaxValue.SetToolTip = Nothing
        Me.TxtMaxValue.Size = New System.Drawing.Size(128, 20)
        Me.TxtMaxValue.TabIndex = 4
        Me.TxtMaxValue.Text = "0"
        Me.TxtMaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtMaxValue.ToolTip = Nothing
        Me.TxtMaxValue.UseFunctionKeys = False
        Me.TxtMaxValue.UseUpDownArrowKeys = False
        '
        'TxtPer
        '
        Me.TxtPer.AllHelpText = True
        Me.TxtPer.AllowDecimal = True
        Me.TxtPer.AllowFormulas = False
        Me.TxtPer.AllowForQty = True
        Me.TxtPer.AllowNegative = False
        Me.TxtPer.AllowPerSign = False
        Me.TxtPer.AllowPlusSign = False
        Me.TxtPer.AllowToolTip = True
        Me.TxtPer.DecimalPlaces = CType(6, Short)
        Me.TxtPer.ExitOnEscKey = True
        Me.TxtPer.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPer.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPer.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtPer.HelpText = Nothing
        Me.TxtPer.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPer.Location = New System.Drawing.Point(154, 42)
        Me.TxtPer.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPer.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtPer.Max = CType(50, Long)
        Me.TxtPer.MaxLength = 5
        Me.TxtPer.Min = CType(0, Long)
        Me.TxtPer.Name = "TxtPer"
        Me.TxtPer.NextOnEnter = True
        Me.TxtPer.SetToolTip = Nothing
        Me.TxtPer.Size = New System.Drawing.Size(128, 20)
        Me.TxtPer.TabIndex = 1
        Me.TxtPer.Text = "1"
        Me.TxtPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtPer.ToolTip = Nothing
        Me.TxtPer.UseFunctionKeys = False
        Me.TxtPer.UseUpDownArrowKeys = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(305, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Fixed"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(305, 151)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Zero for Full Discount"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Max Value"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(38, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Period To"
        '
        'txtCouponName
        '
        Me.txtCouponName.AllowToolTip = True
        Me.txtCouponName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.txtCouponName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCouponName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtCouponName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtCouponName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txtCouponName.IsAllowDigits = True
        Me.txtCouponName.IsAllowSpace = True
        Me.txtCouponName.IsAllowSplChars = True
        Me.txtCouponName.LFocusBackColor = System.Drawing.Color.White
        Me.txtCouponName.Location = New System.Drawing.Point(154, 13)
        Me.txtCouponName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtCouponName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.txtCouponName.MaxLength = 45
        Me.txtCouponName.Name = "txtCouponName"
        Me.txtCouponName.SetToolTip = Nothing
        Me.txtCouponName.Size = New System.Drawing.Size(221, 20)
        Me.txtCouponName.SpecialCharList = "&-/@()_"
        Me.txtCouponName.TabIndex = 0
        Me.txtCouponName.UseFunctionKeys = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(38, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Period From"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Coupon Name/Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Percentage"
        '
        'TxtStatus
        '
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Green
        Me.TxtStatus.Location = New System.Drawing.Point(3, 293)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(751, 26)
        Me.TxtStatus.TabIndex = 0
        Me.TxtStatus.Text = "Status: Ready"
        '
        'CreateNewCoupon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(757, 319)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CreateNewCoupon"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CreateNewCoupon"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtDateTo As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtDateFrom As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtMaxValue As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtPer As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCouponName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtStatus As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtIsMultiCoupon As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrefix As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtEndNo As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtStartNo As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label

End Class
