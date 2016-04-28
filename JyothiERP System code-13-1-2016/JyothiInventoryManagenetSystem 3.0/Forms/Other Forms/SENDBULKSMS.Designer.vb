<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SENDBULKSMS
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.lblLedger = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtAccountGroup = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.txtmsg = New System.Windows.Forms.TextBox()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 336.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ImSlabel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ImSlabel3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtmsg, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtAccountGroup, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLedger, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ImsButton2, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.ImsButton1, 1, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 113.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(506, 256)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TableLayoutPanel1.SetColumnSpan(Me.ImSlabel1, 2)
        Me.ImSlabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(3, 0)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(500, 27)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "SEND BULK SMS"
        Me.ImSlabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLedger
        '
        Me.lblLedger.AutoSize = True
        Me.lblLedger.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLedger.Location = New System.Drawing.Point(3, 46)
        Me.lblLedger.Name = "lblLedger"
        Me.lblLedger.Size = New System.Drawing.Size(107, 13)
        Me.lblLedger.TabIndex = 1
        Me.lblLedger.Text = "Select The Group"
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(3, 82)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(57, 13)
        Me.ImSlabel3.TabIndex = 2
        Me.ImSlabel3.Text = "Message"
        '
        'TxtAccountGroup
        '
        Me.TxtAccountGroup.AllowEmpty = True
        Me.TxtAccountGroup.AllowOnlyListValues = False
        Me.TxtAccountGroup.AllowToolTip = True
        Me.TxtAccountGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtAccountGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtAccountGroup.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtAccountGroup.FormattingEnabled = True
        Me.TxtAccountGroup.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtAccountGroup.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtAccountGroup.IsAdvanceSearchWindow = False
        Me.TxtAccountGroup.IsAllowDigits = True
        Me.TxtAccountGroup.IsAllowSpace = True
        Me.TxtAccountGroup.IsAllowSplChars = True
        Me.TxtAccountGroup.IsAllowToolTip = True
        Me.TxtAccountGroup.LFocusBackColor = System.Drawing.Color.White
        Me.TxtAccountGroup.Location = New System.Drawing.Point(173, 49)
        Me.TxtAccountGroup.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtAccountGroup.Name = "TxtAccountGroup"
        Me.TxtAccountGroup.SetToolTip = Nothing
        Me.TxtAccountGroup.Size = New System.Drawing.Size(316, 24)
        Me.TxtAccountGroup.Sorted = True
        Me.TxtAccountGroup.SpecialCharList = "&-/@"
        Me.TxtAccountGroup.TabIndex = 3
        Me.TxtAccountGroup.UseFunctionKeys = False
        '
        'txtmsg
        '
        Me.txtmsg.Location = New System.Drawing.Point(172, 82)
        Me.txtmsg.Margin = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtmsg.MaxLength = 150
        Me.txtmsg.Multiline = True
        Me.txtmsg.Name = "txtmsg"
        Me.txtmsg.Size = New System.Drawing.Size(317, 70)
        Me.txtmsg.TabIndex = 4
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.up_icon
        Me.ImsButton1.Location = New System.Drawing.Point(275, 198)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(126, 42)
        Me.ImsButton1.TabIndex = 5
        Me.ImsButton1.Text = "Send"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = True
        '
        'ImsButton2
        '
        Me.ImsButton2.AllowToolTip = True
        Me.ImsButton2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ImsButton2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton2.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.ImsButton2.Location = New System.Drawing.Point(22, 198)
        Me.ImsButton2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton2.Name = "ImsButton2"
        Me.ImsButton2.SetToolTip = ""
        Me.ImsButton2.Size = New System.Drawing.Size(125, 42)
        Me.ImsButton2.TabIndex = 6
        Me.ImsButton2.Text = "Close"
        Me.ImsButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton2.UseFunctionKeys = False
        Me.ImsButton2.UseVisualStyleBackColor = True
        '
        'SENDBULKSMS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 256)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SENDBULKSMS"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SEND BULK SMS"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents lblLedger As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtAccountGroup As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents txtmsg As System.Windows.Forms.TextBox
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton2 As JyothiPharmaERPSystem3.IMSButton

End Class
