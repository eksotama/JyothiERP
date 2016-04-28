<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RenewDueDays
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtDueDays = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtExpiry = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtEmployeeName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Apply From"
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(22, 5)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(161, 43)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtDueDays)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.TxtExpiry)
        Me.Panel2.Controls.Add(Me.TxtEmployeeName)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(3, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(396, 130)
        Me.Panel2.TabIndex = 2
        '
        'TxtDueDays
        '
        Me.TxtDueDays.AllHelpText = True
        Me.TxtDueDays.AllowDecimal = False
        Me.TxtDueDays.AllowFormulas = False
        Me.TxtDueDays.AllowForQty = True
        Me.TxtDueDays.AllowNegative = False
        Me.TxtDueDays.AllowPerSign = False
        Me.TxtDueDays.AllowPlusSign = False
        Me.TxtDueDays.AllowToolTip = True
        Me.TxtDueDays.DecimalPlaces = CType(3, Short)
        Me.TxtDueDays.ExitOnEscKey = True
        Me.TxtDueDays.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDueDays.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDueDays.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtDueDays.HelpText = Nothing
        Me.TxtDueDays.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDueDays.Location = New System.Drawing.Point(113, 52)
        Me.TxtDueDays.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDueDays.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtDueDays.Max = CType(100000000000000, Long)
        Me.TxtDueDays.MaxLength = 12
        Me.TxtDueDays.Min = CType(0, Long)
        Me.TxtDueDays.Name = "TxtDueDays"
        Me.TxtDueDays.NextOnEnter = True
        Me.TxtDueDays.SetToolTip = Nothing
        Me.TxtDueDays.Size = New System.Drawing.Size(100, 20)
        Me.TxtDueDays.TabIndex = 28
        Me.TxtDueDays.Text = "0"
        Me.TxtDueDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtDueDays.ToolTip = Nothing
        Me.TxtDueDays.UseFunctionKeys = False
        Me.TxtDueDays.UseUpDownArrowKeys = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Due Days"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Employee Name"
        '
        'TxtExpiry
        '
        Me.TxtExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtExpiry.Location = New System.Drawing.Point(113, 85)
        Me.TxtExpiry.Name = "TxtExpiry"
        Me.TxtExpiry.Size = New System.Drawing.Size(263, 20)
        Me.TxtExpiry.TabIndex = 4
        '
        'TxtEmployeeName
        '
        Me.TxtEmployeeName.AllowToolTip = True
        Me.TxtEmployeeName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtEmployeeName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtEmployeeName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtEmployeeName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtEmployeeName.IsAllowDigits = True
        Me.TxtEmployeeName.IsAllowSpace = True
        Me.TxtEmployeeName.IsAllowSplChars = True
        Me.TxtEmployeeName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtEmployeeName.Location = New System.Drawing.Point(113, 19)
        Me.TxtEmployeeName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtEmployeeName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtEmployeeName.MaxLength = 40
        Me.TxtEmployeeName.Name = "TxtEmployeeName"
        Me.TxtEmployeeName.ReadOnly = True
        Me.TxtEmployeeName.SetToolTip = Nothing
        Me.TxtEmployeeName.Size = New System.Drawing.Size(263, 20)
        Me.TxtEmployeeName.SpecialCharList = "&-/@"
        Me.TxtEmployeeName.TabIndex = 0
        Me.TxtEmployeeName.UseFunctionKeys = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnCreate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 165)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(396, 50)
        Me.Panel1.TabIndex = 1
        '
        'BtnCreate
        '
        Me.BtnCreate.AllowToolTip = True
        Me.BtnCreate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCreate.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.Save__1_
        Me.BtnCreate.Location = New System.Drawing.Point(219, 4)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(175, 43)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "&Save"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Olive
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(402, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "RENEW EMPLOYEES ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.79352!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(402, 226)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'RenewDueDays
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 226)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RenewDueDays"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RenewDueDays"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtDueDays As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtExpiry As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtEmployeeName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel

End Class
