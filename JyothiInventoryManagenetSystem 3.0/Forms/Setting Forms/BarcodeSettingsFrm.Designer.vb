<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BarcodeSettingsFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BarcodeSettingsFrm))
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TxtHeading = New UserLabel.UserLabel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.UserLabel3 = New UserLabel.UserLabel()
        Me.UserLabel1 = New UserLabel.UserLabel()
        Me.UserLabel2 = New UserLabel.UserLabel()
        Me.UserLabel4 = New UserLabel.UserLabel()
        Me.TxtBarcodeLength = New System.Windows.Forms.NumericUpDown()
        Me.IsFixedLength = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.IsAutoFill = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.IsLeadingZeros = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.UserLabel5 = New UserLabel.UserLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.TxtBarcodeLength, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Image = CType(resources.GetObject("Cancel_Button.Image"), System.Drawing.Image)
        Me.Cancel_Button.Location = New System.Drawing.Point(11, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(133, 42)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
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
        Me.TxtHeading.Size = New System.Drawing.Size(374, 24)
        Me.TxtHeading.TabIndex = 27
        Me.TxtHeading.Text = "BARCODE SETTINGS"
        Me.TxtHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.TxtHeading.TextEnglishCode = Nothing
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Image = CType(resources.GetObject("OK_Button.Image"), System.Drawing.Image)
        Me.OK_Button.Location = New System.Drawing.Point(166, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(133, 42)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "&OK"
        Me.OK_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(17, 206)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(310, 49)
        Me.TableLayoutPanel1.TabIndex = 26
        '
        'UserLabel3
        '
        Me.UserLabel3.AutoSize = True
        Me.UserLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel3.Location = New System.Drawing.Point(16, 12)
        Me.UserLabel3.Name = "UserLabel3"
        Me.UserLabel3.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel3.Size = New System.Drawing.Size(108, 15)
        Me.UserLabel3.TabIndex = 29
        Me.UserLabel3.Text = "Barcode Length"
        Me.UserLabel3.TextEnglishCode = Nothing
        '
        'UserLabel1
        '
        Me.UserLabel1.AutoSize = True
        Me.UserLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel1.Location = New System.Drawing.Point(16, 46)
        Me.UserLabel1.Name = "UserLabel1"
        Me.UserLabel1.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel1.Size = New System.Drawing.Size(125, 15)
        Me.UserLabel1.TabIndex = 29
        Me.UserLabel1.Text = "Is It Fixed length ?"
        Me.UserLabel1.TextEnglishCode = Nothing
        '
        'UserLabel2
        '
        Me.UserLabel2.AutoSize = True
        Me.UserLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel2.Location = New System.Drawing.Point(16, 82)
        Me.UserLabel2.Name = "UserLabel2"
        Me.UserLabel2.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel2.Size = New System.Drawing.Size(109, 15)
        Me.UserLabel2.TabIndex = 29
        Me.UserLabel2.Text = "Allow Auto Fill ?"
        Me.UserLabel2.TextEnglishCode = Nothing
        '
        'UserLabel4
        '
        Me.UserLabel4.AutoSize = True
        Me.UserLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel4.Location = New System.Drawing.Point(15, 116)
        Me.UserLabel4.Name = "UserLabel4"
        Me.UserLabel4.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel4.Size = New System.Drawing.Size(111, 15)
        Me.UserLabel4.TabIndex = 29
        Me.UserLabel4.Text = "Leading Zeros ?"
        Me.UserLabel4.TextEnglishCode = Nothing
        '
        'TxtBarcodeLength
        '
        Me.TxtBarcodeLength.Location = New System.Drawing.Point(176, 12)
        Me.TxtBarcodeLength.Maximum = New Decimal(New Integer() {40, 0, 0, 0})
        Me.TxtBarcodeLength.Minimum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.TxtBarcodeLength.Name = "TxtBarcodeLength"
        Me.TxtBarcodeLength.Size = New System.Drawing.Size(81, 20)
        Me.TxtBarcodeLength.TabIndex = 30
        Me.TxtBarcodeLength.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'IsFixedLength
        '
        Me.IsFixedLength.AllowEmpty = True
        Me.IsFixedLength.AllowOnlyListValues = False
        Me.IsFixedLength.AllowToolTip = True
        Me.IsFixedLength.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.IsFixedLength.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.IsFixedLength.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.IsFixedLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.IsFixedLength.FormattingEnabled = True
        Me.IsFixedLength.GFocusBackColor = System.Drawing.Color.Yellow
        Me.IsFixedLength.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.IsFixedLength.IsAdvanceSearchWindow = False
        Me.IsFixedLength.IsAllowDigits = True
        Me.IsFixedLength.IsAllowSpace = True
        Me.IsFixedLength.IsAllowSplChars = True
        Me.IsFixedLength.IsAllowToolTip = True
        Me.IsFixedLength.Items.AddRange(New Object() {"NO", "YES"})
        Me.IsFixedLength.LFocusBackColor = System.Drawing.Color.White
        Me.IsFixedLength.Location = New System.Drawing.Point(176, 45)
        Me.IsFixedLength.LostFocusFontColor = System.Drawing.Color.Blue
        Me.IsFixedLength.Name = "IsFixedLength"
        Me.IsFixedLength.SetToolTip = Nothing
        Me.IsFixedLength.Size = New System.Drawing.Size(81, 21)
        Me.IsFixedLength.Sorted = True
        Me.IsFixedLength.SpecialCharList = "&-/@"
        Me.IsFixedLength.TabIndex = 31
        Me.IsFixedLength.UseFunctionKeys = False
        '
        'IsAutoFill
        '
        Me.IsAutoFill.AllowEmpty = True
        Me.IsAutoFill.AllowOnlyListValues = False
        Me.IsAutoFill.AllowToolTip = True
        Me.IsAutoFill.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.IsAutoFill.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.IsAutoFill.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.IsAutoFill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.IsAutoFill.FormattingEnabled = True
        Me.IsAutoFill.GFocusBackColor = System.Drawing.Color.Yellow
        Me.IsAutoFill.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.IsAutoFill.IsAdvanceSearchWindow = False
        Me.IsAutoFill.IsAllowDigits = True
        Me.IsAutoFill.IsAllowSpace = True
        Me.IsAutoFill.IsAllowSplChars = True
        Me.IsAutoFill.IsAllowToolTip = True
        Me.IsAutoFill.Items.AddRange(New Object() {"NO", "YES"})
        Me.IsAutoFill.LFocusBackColor = System.Drawing.Color.White
        Me.IsAutoFill.Location = New System.Drawing.Point(176, 76)
        Me.IsAutoFill.LostFocusFontColor = System.Drawing.Color.Blue
        Me.IsAutoFill.Name = "IsAutoFill"
        Me.IsAutoFill.SetToolTip = Nothing
        Me.IsAutoFill.Size = New System.Drawing.Size(81, 21)
        Me.IsAutoFill.Sorted = True
        Me.IsAutoFill.SpecialCharList = "&-/@"
        Me.IsAutoFill.TabIndex = 31
        Me.IsAutoFill.UseFunctionKeys = False
        '
        'IsLeadingZeros
        '
        Me.IsLeadingZeros.AllowEmpty = True
        Me.IsLeadingZeros.AllowOnlyListValues = False
        Me.IsLeadingZeros.AllowToolTip = True
        Me.IsLeadingZeros.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.IsLeadingZeros.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.IsLeadingZeros.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.IsLeadingZeros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.IsLeadingZeros.FormattingEnabled = True
        Me.IsLeadingZeros.GFocusBackColor = System.Drawing.Color.Yellow
        Me.IsLeadingZeros.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.IsLeadingZeros.IsAdvanceSearchWindow = False
        Me.IsLeadingZeros.IsAllowDigits = True
        Me.IsLeadingZeros.IsAllowSpace = True
        Me.IsLeadingZeros.IsAllowSplChars = True
        Me.IsLeadingZeros.IsAllowToolTip = True
        Me.IsLeadingZeros.Items.AddRange(New Object() {"NO", "YES"})
        Me.IsLeadingZeros.LFocusBackColor = System.Drawing.Color.White
        Me.IsLeadingZeros.Location = New System.Drawing.Point(176, 110)
        Me.IsLeadingZeros.LostFocusFontColor = System.Drawing.Color.Blue
        Me.IsLeadingZeros.Name = "IsLeadingZeros"
        Me.IsLeadingZeros.SetToolTip = Nothing
        Me.IsLeadingZeros.Size = New System.Drawing.Size(81, 21)
        Me.IsLeadingZeros.Sorted = True
        Me.IsLeadingZeros.SpecialCharList = "&-/@"
        Me.IsLeadingZeros.TabIndex = 31
        Me.IsLeadingZeros.UseFunctionKeys = False
        '
        'UserLabel5
        '
        Me.UserLabel5.AutoSize = True
        Me.UserLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel5.Location = New System.Drawing.Point(18, 154)
        Me.UserLabel5.Name = "UserLabel5"
        Me.UserLabel5.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel5.Size = New System.Drawing.Size(155, 15)
        Me.UserLabel5.TabIndex = 29
        Me.UserLabel5.Text = "Note: Onetime Settings"
        Me.UserLabel5.TextEnglishCode = Nothing
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UserLabel3)
        Me.Panel1.Controls.Add(Me.IsLeadingZeros)
        Me.Panel1.Controls.Add(Me.UserLabel5)
        Me.Panel1.Controls.Add(Me.IsAutoFill)
        Me.Panel1.Controls.Add(Me.UserLabel1)
        Me.Panel1.Controls.Add(Me.IsFixedLength)
        Me.Panel1.Controls.Add(Me.UserLabel2)
        Me.Panel1.Controls.Add(Me.TxtBarcodeLength)
        Me.Panel1.Controls.Add(Me.UserLabel4)
        Me.Panel1.Location = New System.Drawing.Point(12, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(323, 181)
        Me.Panel1.TabIndex = 32
        '
        'BarcodeSettingsFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(374, 279)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxtHeading)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BarcodeSettingsFrm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "BarcodeSettings"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.TxtBarcodeLength, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TxtHeading As UserLabel.UserLabel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents UserLabel3 As UserLabel.UserLabel
    Friend WithEvents UserLabel1 As UserLabel.UserLabel
    Friend WithEvents UserLabel2 As UserLabel.UserLabel
    Friend WithEvents UserLabel4 As UserLabel.UserLabel
    Friend WithEvents TxtBarcodeLength As System.Windows.Forms.NumericUpDown
    Friend WithEvents IsFixedLength As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents IsAutoFill As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents IsLeadingZeros As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents UserLabel5 As UserLabel.UserLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
