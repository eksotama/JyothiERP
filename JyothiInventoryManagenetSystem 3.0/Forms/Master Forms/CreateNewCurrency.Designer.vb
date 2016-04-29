<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateNewCurrency
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateNewCurrency))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtCurCode = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtConRate = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtCurSym = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtcurName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(488, 283)
        Me.TableLayoutPanel1.TabIndex = 2
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
        Me.Label1.Size = New System.Drawing.Size(488, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CREATE NEW CURRENCY"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnCreate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 187)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(482, 67)
        Me.Panel1.TabIndex = 1
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(28, 13)
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
        Me.BtnCreate.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnCreate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCreate.Image = CType(resources.GetObject("BtnCreate.Image"), System.Drawing.Image)
        Me.BtnCreate.Location = New System.Drawing.Point(257, 13)
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
        Me.Panel2.Controls.Add(Me.TxtCurCode)
        Me.Panel2.Controls.Add(Me.TxtConRate)
        Me.Panel2.Controls.Add(Me.TxtCurSym)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.TxtcurName)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(482, 152)
        Me.Panel2.TabIndex = 0
        '
        'TxtCurCode
        '
        Me.TxtCurCode.AllowEmpty = True
        Me.TxtCurCode.AllowOnlyListValues = False
        Me.TxtCurCode.AllowToolTip = True
        Me.TxtCurCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtCurCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtCurCode.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.UPPER
        Me.TxtCurCode.FormattingEnabled = True
        Me.TxtCurCode.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCurCode.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCurCode.IsAdvanceSearchWindow = False
        Me.TxtCurCode.IsAllowDigits = True
        Me.TxtCurCode.IsAllowSpace = True
        Me.TxtCurCode.IsAllowSplChars = True
        Me.TxtCurCode.IsAllowToolTip = True
        Me.TxtCurCode.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCurCode.Location = New System.Drawing.Point(154, 9)
        Me.TxtCurCode.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCurCode.Name = "TxtCurCode"
        Me.TxtCurCode.SetToolTip = Nothing
        Me.TxtCurCode.Size = New System.Drawing.Size(121, 21)
        Me.TxtCurCode.Sorted = True
        Me.TxtCurCode.SpecialCharList = "&-/@"
        Me.TxtCurCode.TabIndex = 0
        Me.TxtCurCode.UseFunctionKeys = False
        '
        'TxtConRate
        '
        Me.TxtConRate.AllHelpText = True
        Me.TxtConRate.AllowDecimal = True
        Me.TxtConRate.AllowFormulas = False
        Me.TxtConRate.AllowForQty = True
        Me.TxtConRate.AllowNegative = False
        Me.TxtConRate.AllowPerSign = False
        Me.TxtConRate.AllowPlusSign = False
        Me.TxtConRate.AllowToolTip = True
        Me.TxtConRate.DecimalPlaces = CType(6, Short)
        Me.TxtConRate.ExitOnEscKey = True
        Me.TxtConRate.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtConRate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtConRate.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtConRate.HelpText = Nothing
        Me.TxtConRate.LFocusBackColor = System.Drawing.Color.White
        Me.TxtConRate.Location = New System.Drawing.Point(156, 117)
        Me.TxtConRate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtConRate.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtConRate.Max = CType(100000000000000, Long)
        Me.TxtConRate.MaxLength = 10
        Me.TxtConRate.Min = CType(0, Long)
        Me.TxtConRate.Name = "TxtConRate"
        Me.TxtConRate.NextOnEnter = True
        Me.TxtConRate.SetToolTip = Nothing
        Me.TxtConRate.Size = New System.Drawing.Size(128, 20)
        Me.TxtConRate.TabIndex = 3
        Me.TxtConRate.Text = "1"
        Me.TxtConRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtConRate.ToolTip = Nothing
        Me.TxtConRate.UseFunctionKeys = False
        Me.TxtConRate.UseUpDownArrowKeys = True
        '
        'TxtCurSym
        '
        Me.TxtCurSym.AllowToolTip = True
        Me.TxtCurSym.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtCurSym.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtCurSym.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCurSym.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCurSym.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtCurSym.IsAllowDigits = True
        Me.TxtCurSym.IsAllowSpace = False
        Me.TxtCurSym.IsAllowSplChars = True
        Me.TxtCurSym.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCurSym.Location = New System.Drawing.Point(155, 88)
        Me.TxtCurSym.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCurSym.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtCurSym.MaxLength = 8
        Me.TxtCurSym.Name = "TxtCurSym"
        Me.TxtCurSym.SetToolTip = Nothing
        Me.TxtCurSym.Size = New System.Drawing.Size(131, 20)
        Me.TxtCurSym.SpecialCharList = "&-/@()_"
        Me.TxtCurSym.TabIndex = 2
        Me.TxtCurSym.UseFunctionKeys = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(38, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Converstion Rate"
        '
        'TxtcurName
        '
        Me.TxtcurName.AllowToolTip = True
        Me.TxtcurName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtcurName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtcurName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtcurName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtcurName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtcurName.IsAllowDigits = True
        Me.TxtcurName.IsAllowSpace = True
        Me.TxtcurName.IsAllowSplChars = True
        Me.TxtcurName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtcurName.Location = New System.Drawing.Point(154, 56)
        Me.TxtcurName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtcurName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtcurName.MaxLength = 75
        Me.TxtcurName.Name = "TxtcurName"
        Me.TxtcurName.SetToolTip = Nothing
        Me.TxtcurName.Size = New System.Drawing.Size(264, 20)
        Me.TxtcurName.SpecialCharList = "&-/@()_"
        Me.TxtcurName.TabIndex = 1
        Me.TxtcurName.UseFunctionKeys = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(38, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Currency Symbol"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(152, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Ex: USD, INR"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Currency Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Currency Name"
        '
        'TxtStatus
        '
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Green
        Me.TxtStatus.Location = New System.Drawing.Point(3, 257)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(482, 26)
        Me.TxtStatus.TabIndex = 0
        Me.TxtStatus.Text = "Status: Ready"
        '
        'Timer1
        '
        '
        'CreateNewCurrency
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(488, 283)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CreateNewCurrency"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CreateNewCurrency"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtcurName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtStatus As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCurSym As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtConRate As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtCurCode As JyothiPharmaERPSystem3.IMSComboBox

End Class
