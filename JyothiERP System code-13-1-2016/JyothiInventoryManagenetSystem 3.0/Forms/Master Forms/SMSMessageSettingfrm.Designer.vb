<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SmsMessageSettingForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SmsMessageSettingForm))
        Me.TxtMsgType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.BtnSave = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtMsg = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TxtPremsg = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtMsgType
        '
        Me.TxtMsgType.AllowEmpty = True
        Me.TxtMsgType.AllowOnlyListValues = False
        Me.TxtMsgType.AllowToolTip = True
        Me.TxtMsgType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtMsgType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtMsgType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtMsgType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtMsgType.FormattingEnabled = True
        Me.TxtMsgType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtMsgType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtMsgType.IsAdvanceSearchWindow = False
        Me.TxtMsgType.IsAllowDigits = True
        Me.TxtMsgType.IsAllowSpace = True
        Me.TxtMsgType.IsAllowSplChars = True
        Me.TxtMsgType.IsAllowToolTip = True
        Me.TxtMsgType.Items.AddRange(New Object() {"CONTRA", "JOURNAL", "PAYMENT", "RECEIPT", "SALES", "SALES RETURNS", "SALES VOUCHER", "SALESRETURNS"})
        Me.TxtMsgType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtMsgType.Location = New System.Drawing.Point(128, 12)
        Me.TxtMsgType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtMsgType.Name = "TxtMsgType"
        Me.TxtMsgType.SetToolTip = Nothing
        Me.TxtMsgType.Size = New System.Drawing.Size(316, 21)
        Me.TxtMsgType.Sorted = True
        Me.TxtMsgType.SpecialCharList = "&-/@"
        Me.TxtMsgType.TabIndex = 16
        Me.TxtMsgType.UseFunctionKeys = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(8, 16)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(106, 13)
        Me.ImSlabel1.TabIndex = 15
        Me.ImSlabel1.Text = "Mail Message For"
        '
        'BtnSave
        '
        Me.BtnSave.AllowToolTip = True
        Me.BtnSave.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnSave.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.Save__1_
        Me.BtnSave.Location = New System.Drawing.Point(304, 192)
        Me.BtnSave.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.SetToolTip = ""
        Me.BtnSave.Size = New System.Drawing.Size(143, 43)
        Me.BtnSave.TabIndex = 14
        Me.BtnSave.Text = "Save"
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseFunctionKeys = False
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'TxtMsg
        '
        Me.TxtMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMsg.Location = New System.Drawing.Point(3, 6)
        Me.TxtMsg.MaxLength = 500
        Me.TxtMsg.Multiline = True
        Me.TxtMsg.Name = "TxtMsg"
        Me.TxtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtMsg.Size = New System.Drawing.Size(428, 107)
        Me.TxtMsg.TabIndex = 0
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Location = New System.Drawing.Point(32, 296)
        Me.TextBox2.MaxLength = 1200
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(165, 137)
        Me.TextBox2.TabIndex = 11
        Me.TextBox2.Text = resources.GetString("TextBox2.Text")
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(19, 192)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(143, 43)
        Me.BtnClose.TabIndex = 13
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox4.Location = New System.Drawing.Point(203, 296)
        Me.TextBox4.MaxLength = 1200
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(170, 168)
        Me.TextBox4.TabIndex = 10
        Me.TextBox4.Text = resources.GetString("TextBox4.Text")
        '
        'TextBox3
        '
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Location = New System.Drawing.Point(32, 261)
        Me.TextBox3.MaxLength = 1200
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(412, 38)
        Me.TextBox3.TabIndex = 9
        Me.TextBox3.Text = "USE THIS CODE  WITHOUT SPACES TO REPLACE THE FILEDS( CAPS ONLY)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FILED           " & _
    "                                                 CODE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(15, 41)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(449, 145)
        Me.TabControl1.TabIndex = 17
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TxtMsg)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(441, 119)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Message"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TxtPremsg)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(441, 119)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Preview"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TxtPremsg
        '
        Me.TxtPremsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPremsg.Location = New System.Drawing.Point(6, 7)
        Me.TxtPremsg.MaxLength = 500
        Me.TxtPremsg.Multiline = True
        Me.TxtPremsg.Name = "TxtPremsg"
        Me.TxtPremsg.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtPremsg.Size = New System.Drawing.Size(428, 106)
        Me.TxtPremsg.TabIndex = 1
        '
        'SmsMessageSettingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 461)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TxtMsgType)
        Me.Controls.Add(Me.ImSlabel1)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Name = "SmsMessageSettingForm"
        Me.Text = "SMS Message Setting"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtMsgType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents BtnSave As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtMsg As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TxtPremsg As System.Windows.Forms.TextBox
End Class
