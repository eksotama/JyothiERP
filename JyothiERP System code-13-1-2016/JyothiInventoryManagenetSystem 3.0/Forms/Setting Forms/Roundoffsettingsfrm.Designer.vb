<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Roundoffsettingsfrm
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
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TxtHeading = New UserLabel.UserLabel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.inPI = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.InPG = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.inPR = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.inPOS = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.inSI = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.inSD = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.inSR = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.Cancel_Button.Location = New System.Drawing.Point(11, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(133, 42)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'TxtHeading
        '
        Me.TxtHeading.BackColor = System.Drawing.Color.Green
        Me.TxtHeading.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHeading.ForeColor = System.Drawing.Color.White
        Me.TxtHeading.Location = New System.Drawing.Point(0, 0)
        Me.TxtHeading.Name = "TxtHeading"
        Me.TxtHeading.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHeading.Size = New System.Drawing.Size(435, 24)
        Me.TxtHeading.TabIndex = 34
        Me.TxtHeading.Text = "INVOICE ROUNDOFF SETTINGS"
        Me.TxtHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.TxtHeading.TextEnglishCode = Nothing
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.success32
        Me.OK_Button.Location = New System.Drawing.Point(166, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(133, 42)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "&Save"
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(65, 259)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(310, 49)
        Me.TableLayoutPanel1.TabIndex = 33
        '
        'inPI
        '
        Me.inPI.AllowEmpty = True
        Me.inPI.AllowOnlyListValues = False
        Me.inPI.AllowToolTip = True
        Me.inPI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.inPI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.inPI.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.inPI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.inPI.FormattingEnabled = True
        Me.inPI.GFocusBackColor = System.Drawing.Color.Yellow
        Me.inPI.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.inPI.IsAdvanceSearchWindow = False
        Me.inPI.IsAllowDigits = True
        Me.inPI.IsAllowSpace = True
        Me.inPI.IsAllowSplChars = True
        Me.inPI.IsAllowToolTip = True
        Me.inPI.Items.AddRange(New Object() {"NO", "YES"})
        Me.inPI.LFocusBackColor = System.Drawing.Color.White
        Me.inPI.Location = New System.Drawing.Point(248, 167)
        Me.inPI.LostFocusFontColor = System.Drawing.Color.Blue
        Me.inPI.Name = "inPI"
        Me.inPI.SetToolTip = Nothing
        Me.inPI.Size = New System.Drawing.Size(93, 21)
        Me.inPI.Sorted = True
        Me.inPI.SpecialCharList = "&-/@"
        Me.inPI.TabIndex = 35
        Me.inPI.UseFunctionKeys = False
        Me.inPI.Visible = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(29, 171)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(166, 13)
        Me.ImSlabel1.TabIndex = 36
        Me.ImSlabel1.Text = "Allow In Purchase Invoice ?"
        Me.ImSlabel1.Visible = False
        '
        'InPG
        '
        Me.InPG.AllowEmpty = True
        Me.InPG.AllowOnlyListValues = False
        Me.InPG.AllowToolTip = True
        Me.InPG.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.InPG.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.InPG.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.InPG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.InPG.FormattingEnabled = True
        Me.InPG.GFocusBackColor = System.Drawing.Color.Yellow
        Me.InPG.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.InPG.IsAdvanceSearchWindow = False
        Me.InPG.IsAllowDigits = True
        Me.InPG.IsAllowSpace = True
        Me.InPG.IsAllowSplChars = True
        Me.InPG.IsAllowToolTip = True
        Me.InPG.Items.AddRange(New Object() {"NO", "YES"})
        Me.InPG.LFocusBackColor = System.Drawing.Color.White
        Me.InPG.Location = New System.Drawing.Point(248, 194)
        Me.InPG.LostFocusFontColor = System.Drawing.Color.Blue
        Me.InPG.Name = "InPG"
        Me.InPG.SetToolTip = Nothing
        Me.InPG.Size = New System.Drawing.Size(93, 21)
        Me.InPG.Sorted = True
        Me.InPG.SpecialCharList = "&-/@"
        Me.InPG.TabIndex = 35
        Me.InPG.UseFunctionKeys = False
        Me.InPG.Visible = False
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(29, 198)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(182, 13)
        Me.ImSlabel2.TabIndex = 36
        Me.ImSlabel2.Text = "Allow In Goods Receipt Note ?"
        Me.ImSlabel2.Visible = False
        '
        'inPR
        '
        Me.inPR.AllowEmpty = True
        Me.inPR.AllowOnlyListValues = False
        Me.inPR.AllowToolTip = True
        Me.inPR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.inPR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.inPR.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.inPR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.inPR.FormattingEnabled = True
        Me.inPR.GFocusBackColor = System.Drawing.Color.Yellow
        Me.inPR.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.inPR.IsAdvanceSearchWindow = False
        Me.inPR.IsAllowDigits = True
        Me.inPR.IsAllowSpace = True
        Me.inPR.IsAllowSplChars = True
        Me.inPR.IsAllowToolTip = True
        Me.inPR.Items.AddRange(New Object() {"NO", "YES"})
        Me.inPR.LFocusBackColor = System.Drawing.Color.White
        Me.inPR.Location = New System.Drawing.Point(248, 221)
        Me.inPR.LostFocusFontColor = System.Drawing.Color.Blue
        Me.inPR.Name = "inPR"
        Me.inPR.SetToolTip = Nothing
        Me.inPR.Size = New System.Drawing.Size(93, 21)
        Me.inPR.Sorted = True
        Me.inPR.SpecialCharList = "&-/@"
        Me.inPR.TabIndex = 35
        Me.inPR.UseFunctionKeys = False
        Me.inPR.Visible = False
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(29, 225)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(156, 13)
        Me.ImSlabel3.TabIndex = 36
        Me.ImSlabel3.Text = "Allow in Purchase Returns"
        Me.ImSlabel3.Visible = False
        '
        'inPOS
        '
        Me.inPOS.AllowEmpty = True
        Me.inPOS.AllowOnlyListValues = False
        Me.inPOS.AllowToolTip = True
        Me.inPOS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.inPOS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.inPOS.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.inPOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.inPOS.FormattingEnabled = True
        Me.inPOS.GFocusBackColor = System.Drawing.Color.Yellow
        Me.inPOS.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.inPOS.IsAdvanceSearchWindow = False
        Me.inPOS.IsAllowDigits = True
        Me.inPOS.IsAllowSpace = True
        Me.inPOS.IsAllowSplChars = True
        Me.inPOS.IsAllowToolTip = True
        Me.inPOS.Items.AddRange(New Object() {"NO", "YES"})
        Me.inPOS.LFocusBackColor = System.Drawing.Color.White
        Me.inPOS.Location = New System.Drawing.Point(248, 55)
        Me.inPOS.LostFocusFontColor = System.Drawing.Color.Blue
        Me.inPOS.Name = "inPOS"
        Me.inPOS.SetToolTip = Nothing
        Me.inPOS.Size = New System.Drawing.Size(93, 21)
        Me.inPOS.Sorted = True
        Me.inPOS.SpecialCharList = "&-/@"
        Me.inPOS.TabIndex = 35
        Me.inPOS.UseFunctionKeys = False
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(29, 59)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(91, 13)
        Me.ImSlabel5.TabIndex = 36
        Me.ImSlabel5.Text = "Allow in POS ?"
        '
        'inSI
        '
        Me.inSI.AllowEmpty = True
        Me.inSI.AllowOnlyListValues = False
        Me.inSI.AllowToolTip = True
        Me.inSI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.inSI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.inSI.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.inSI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.inSI.FormattingEnabled = True
        Me.inSI.GFocusBackColor = System.Drawing.Color.Yellow
        Me.inSI.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.inSI.IsAdvanceSearchWindow = False
        Me.inSI.IsAllowDigits = True
        Me.inSI.IsAllowSpace = True
        Me.inSI.IsAllowSplChars = True
        Me.inSI.IsAllowToolTip = True
        Me.inSI.Items.AddRange(New Object() {"NO", "YES"})
        Me.inSI.LFocusBackColor = System.Drawing.Color.White
        Me.inSI.Location = New System.Drawing.Point(248, 82)
        Me.inSI.LostFocusFontColor = System.Drawing.Color.Blue
        Me.inSI.Name = "inSI"
        Me.inSI.SetToolTip = Nothing
        Me.inSI.Size = New System.Drawing.Size(93, 21)
        Me.inSI.Sorted = True
        Me.inSI.SpecialCharList = "&-/@"
        Me.inSI.TabIndex = 35
        Me.inSI.UseFunctionKeys = False
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(29, 86)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(139, 13)
        Me.ImSlabel6.TabIndex = 36
        Me.ImSlabel6.Text = "Allow in Sales Invoice?"
        '
        'inSD
        '
        Me.inSD.AllowEmpty = True
        Me.inSD.AllowOnlyListValues = False
        Me.inSD.AllowToolTip = True
        Me.inSD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.inSD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.inSD.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.inSD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.inSD.FormattingEnabled = True
        Me.inSD.GFocusBackColor = System.Drawing.Color.Yellow
        Me.inSD.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.inSD.IsAdvanceSearchWindow = False
        Me.inSD.IsAllowDigits = True
        Me.inSD.IsAllowSpace = True
        Me.inSD.IsAllowSplChars = True
        Me.inSD.IsAllowToolTip = True
        Me.inSD.Items.AddRange(New Object() {"NO", "YES"})
        Me.inSD.LFocusBackColor = System.Drawing.Color.White
        Me.inSD.Location = New System.Drawing.Point(248, 109)
        Me.inSD.LostFocusFontColor = System.Drawing.Color.Blue
        Me.inSD.Name = "inSD"
        Me.inSD.SetToolTip = Nothing
        Me.inSD.Size = New System.Drawing.Size(93, 21)
        Me.inSD.Sorted = True
        Me.inSD.SpecialCharList = "&-/@"
        Me.inSD.TabIndex = 35
        Me.inSD.UseFunctionKeys = False
        '
        'ImSlabel7
        '
        Me.ImSlabel7.AutoSize = True
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(29, 113)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(139, 13)
        Me.ImSlabel7.TabIndex = 36
        Me.ImSlabel7.Text = "Allow in Delivery Note?"
        '
        'inSR
        '
        Me.inSR.AllowEmpty = True
        Me.inSR.AllowOnlyListValues = False
        Me.inSR.AllowToolTip = True
        Me.inSR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.inSR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.inSR.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.inSR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.inSR.FormattingEnabled = True
        Me.inSR.GFocusBackColor = System.Drawing.Color.Yellow
        Me.inSR.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.inSR.IsAdvanceSearchWindow = False
        Me.inSR.IsAllowDigits = True
        Me.inSR.IsAllowSpace = True
        Me.inSR.IsAllowSplChars = True
        Me.inSR.IsAllowToolTip = True
        Me.inSR.Items.AddRange(New Object() {"NO", "YES"})
        Me.inSR.LFocusBackColor = System.Drawing.Color.White
        Me.inSR.Location = New System.Drawing.Point(248, 136)
        Me.inSR.LostFocusFontColor = System.Drawing.Color.Blue
        Me.inSR.Name = "inSR"
        Me.inSR.SetToolTip = Nothing
        Me.inSR.Size = New System.Drawing.Size(93, 21)
        Me.inSR.Sorted = True
        Me.inSR.SpecialCharList = "&-/@"
        Me.inSR.TabIndex = 35
        Me.inSR.UseFunctionKeys = False
        '
        'ImSlabel8
        '
        Me.ImSlabel8.AutoSize = True
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(29, 140)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(145, 13)
        Me.ImSlabel8.TabIndex = 36
        Me.ImSlabel8.Text = "Allow in Sales Returns ?"
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.ForeColor = System.Drawing.Color.Maroon
        Me.ImSlabel4.Location = New System.Drawing.Point(29, 30)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(218, 13)
        Me.ImSlabel4.TabIndex = 36
        Me.ImSlabel4.Text = "Turn on or off the roundoff in Invoice"
        '
        'Roundoffsettingsfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 333)
        Me.Controls.Add(Me.ImSlabel8)
        Me.Controls.Add(Me.ImSlabel7)
        Me.Controls.Add(Me.ImSlabel6)
        Me.Controls.Add(Me.ImSlabel5)
        Me.Controls.Add(Me.ImSlabel3)
        Me.Controls.Add(Me.ImSlabel2)
        Me.Controls.Add(Me.ImSlabel4)
        Me.Controls.Add(Me.ImSlabel1)
        Me.Controls.Add(Me.inSR)
        Me.Controls.Add(Me.inSD)
        Me.Controls.Add(Me.inSI)
        Me.Controls.Add(Me.inPOS)
        Me.Controls.Add(Me.inPR)
        Me.Controls.Add(Me.InPG)
        Me.Controls.Add(Me.inPI)
        Me.Controls.Add(Me.TxtHeading)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Roundoffsettingsfrm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Roundoff Settings"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TxtHeading As UserLabel.UserLabel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents inPI As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents InPG As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents inPR As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents inPOS As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents inSI As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents inSD As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents inSR As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel

End Class
