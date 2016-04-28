<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateSalesPersons
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtCommisition = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtGender = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtEmail = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtContactno = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtCity = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtAddress = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Green
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(558, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "CREATE A SALES PERSONS"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(558, 392)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'TxtStatus
        '
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Green
        Me.TxtStatus.Location = New System.Drawing.Point(3, 367)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(552, 25)
        Me.TxtStatus.TabIndex = 4
        Me.TxtStatus.Text = "Status: Ready"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnClose)
        Me.Panel2.Controls.Add(Me.BtnCreate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 304)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(552, 60)
        Me.Panel2.TabIndex = 3
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(27, 7)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(159, 50)
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
        Me.BtnCreate.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361186619_document_new
        Me.BtnCreate.Location = New System.Drawing.Point(318, 7)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(159, 50)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "&Create"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtCommisition)
        Me.Panel1.Controls.Add(Me.TxtGender)
        Me.Panel1.Controls.Add(Me.TxtEmail)
        Me.Panel1.Controls.Add(Me.TxtContactno)
        Me.Panel1.Controls.Add(Me.TxtCity)
        Me.Panel1.Controls.Add(Me.TxtAddress)
        Me.Panel1.Controls.Add(Me.TxtName)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(552, 272)
        Me.Panel1.TabIndex = 2
        '
        'TxtCommisition
        '
        Me.TxtCommisition.AllHelpText = True
        Me.TxtCommisition.AllowDecimal = True
        Me.TxtCommisition.AllowFormulas = False
        Me.TxtCommisition.AllowForQty = True
        Me.TxtCommisition.AllowNegative = False
        Me.TxtCommisition.AllowPerSign = False
        Me.TxtCommisition.AllowPlusSign = False
        Me.TxtCommisition.AllowToolTip = True
        Me.TxtCommisition.DecimalPlaces = CType(ErpDecimalPlaces, Short)
        Me.TxtCommisition.ExitOnEscKey = True
        Me.TxtCommisition.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCommisition.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCommisition.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtCommisition.HelpText = Nothing
        Me.TxtCommisition.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCommisition.Location = New System.Drawing.Point(183, 234)
        Me.TxtCommisition.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCommisition.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtCommisition.Max = CType(90, Long)
        Me.TxtCommisition.MaxLength = 6
        Me.TxtCommisition.Min = CType(0, Long)
        Me.TxtCommisition.Name = "TxtCommisition"
        Me.TxtCommisition.NextOnEnter = True
        Me.TxtCommisition.SetToolTip = Nothing
        Me.TxtCommisition.Size = New System.Drawing.Size(74, 20)
        Me.TxtCommisition.TabIndex = 6
        Me.TxtCommisition.Text = "0"
        Me.TxtCommisition.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtCommisition.ToolTip = Nothing
        Me.TxtCommisition.UseFunctionKeys = False
        Me.TxtCommisition.UseUpDownArrowKeys = False
        '
        'TxtGender
        '
        Me.TxtGender.AllowEmpty = True
        Me.TxtGender.AllowOnlyListValues = False
        Me.TxtGender.AllowToolTip = True
        Me.TxtGender.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtGender.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtGender.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtGender.FormattingEnabled = True
        Me.TxtGender.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtGender.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtGender.IsAllowDigits = True
        Me.TxtGender.IsAllowSpace = True
        Me.TxtGender.IsAllowSplChars = True
        Me.TxtGender.IsAllowToolTip = True
        Me.TxtGender.Items.AddRange(New Object() {"Female", "Male"})
        Me.TxtGender.LFocusBackColor = System.Drawing.Color.White
        Me.TxtGender.Location = New System.Drawing.Point(183, 81)
        Me.TxtGender.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtGender.Name = "TxtGender"
        Me.TxtGender.SetToolTip = Nothing
        Me.TxtGender.Size = New System.Drawing.Size(121, 21)
        Me.TxtGender.Sorted = True
        Me.TxtGender.SpecialCharList = "&-/@"
        Me.TxtGender.TabIndex = 2
        Me.TxtGender.UseFunctionKeys = False
        '
        'TxtEmail
        '
        Me.TxtEmail.AllowToolTip = True
        Me.TxtEmail.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtEmail.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtEmail.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtEmail.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtEmail.IsAllowDigits = True
        Me.TxtEmail.IsAllowSpace = True
        Me.TxtEmail.IsAllowSplChars = True
        Me.TxtEmail.LFocusBackColor = System.Drawing.Color.White
        Me.TxtEmail.Location = New System.Drawing.Point(183, 193)
        Me.TxtEmail.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtEmail.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtEmail.MaxLength = 50
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.SetToolTip = Nothing
        Me.TxtEmail.Size = New System.Drawing.Size(282, 20)
        Me.TxtEmail.SpecialCharList = "&-/@"
        Me.TxtEmail.TabIndex = 5
        Me.TxtEmail.UseFunctionKeys = False
        '
        'TxtContactno
        '
        Me.TxtContactno.AllowToolTip = True
        Me.TxtContactno.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtContactno.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtContactno.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtContactno.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtContactno.IsAllowDigits = True
        Me.TxtContactno.IsAllowSpace = True
        Me.TxtContactno.IsAllowSplChars = True
        Me.TxtContactno.LFocusBackColor = System.Drawing.Color.White
        Me.TxtContactno.Location = New System.Drawing.Point(183, 156)
        Me.TxtContactno.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtContactno.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtContactno.MaxLength = 20
        Me.TxtContactno.Name = "TxtContactno"
        Me.TxtContactno.SetToolTip = Nothing
        Me.TxtContactno.Size = New System.Drawing.Size(282, 20)
        Me.TxtContactno.SpecialCharList = "&-/@"
        Me.TxtContactno.TabIndex = 4
        Me.TxtContactno.UseFunctionKeys = False
        '
        'TxtCity
        '
        Me.TxtCity.AllowToolTip = True
        Me.TxtCity.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtCity.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCity.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCity.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtCity.IsAllowDigits = True
        Me.TxtCity.IsAllowSpace = True
        Me.TxtCity.IsAllowSplChars = True
        Me.TxtCity.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCity.Location = New System.Drawing.Point(183, 119)
        Me.TxtCity.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCity.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtCity.MaxLength = 25
        Me.TxtCity.Name = "TxtCity"
        Me.TxtCity.SetToolTip = Nothing
        Me.TxtCity.Size = New System.Drawing.Size(282, 20)
        Me.TxtCity.SpecialCharList = "&-/@"
        Me.TxtCity.TabIndex = 3
        Me.TxtCity.UseFunctionKeys = False
        '
        'TxtAddress
        '
        Me.TxtAddress.AllowToolTip = True
        Me.TxtAddress.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
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
        Me.TxtAddress.MaxLength = 50
        Me.TxtAddress.Name = "TxtAddress"
        Me.TxtAddress.SetToolTip = Nothing
        Me.TxtAddress.Size = New System.Drawing.Size(282, 20)
        Me.TxtAddress.SpecialCharList = "&-/@"
        Me.TxtAddress.TabIndex = 1
        Me.TxtAddress.UseFunctionKeys = False
        '
        'TxtName
        '
        Me.TxtName.AllowToolTip = True
        Me.TxtName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtName.IsAllowDigits = True
        Me.TxtName.IsAllowSpace = True
        Me.TxtName.IsAllowSplChars = True
        Me.TxtName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtName.Location = New System.Drawing.Point(183, 12)
        Me.TxtName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtName.MaxLength = 50
        Me.TxtName.Name = "TxtName"
        Me.TxtName.SetToolTip = Nothing
        Me.TxtName.Size = New System.Drawing.Size(282, 20)
        Me.TxtName.SpecialCharList = "&-/@"
        Me.TxtName.TabIndex = 0
        Me.TxtName.UseFunctionKeys = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 237)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Commision %"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 200)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Email ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Gender"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 163)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Contact Number"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "City"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Address"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sales Person Name"
        '
        'Timer1
        '
        '
        'CreateSalesPersons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(558, 392)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CreateSalesPersons"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Create Sales Persons"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtGender As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtEmail As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtContactno As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtCity As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtAddress As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtStatus As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtCommisition As JyothiPharmaERPSystem3.IMSNumericTextBox

End Class
