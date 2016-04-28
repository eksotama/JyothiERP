<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DefineFormulafrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DefineFormulafrm))
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TxtHeading = New UserLabel.UserLabel()
        Me.UserLabel1 = New UserLabel.UserLabel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtFieldNames = New System.Windows.Forms.ComboBox()
        Me.UserLabel3 = New UserLabel.UserLabel()
        Me.txtFormulaName = New System.Windows.Forms.TextBox()
        Me.UserLabel2 = New UserLabel.UserLabel()
        Me.TxtName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Image = CType(resources.GetObject("Cancel_Button.Image"), System.Drawing.Image)
        Me.Cancel_Button.Location = New System.Drawing.Point(62, 3)
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
        Me.TxtHeading.Size = New System.Drawing.Size(618, 24)
        Me.TxtHeading.TabIndex = 27
        Me.TxtHeading.Text = "DEFINE FORMULA"
        Me.TxtHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.TxtHeading.TextEnglishCode = Nothing
        '
        'UserLabel1
        '
        Me.UserLabel1.AutoSize = True
        Me.UserLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel1.Location = New System.Drawing.Point(24, 92)
        Me.UserLabel1.Name = "UserLabel1"
        Me.UserLabel1.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel1.Size = New System.Drawing.Size(98, 15)
        Me.UserLabel1.TabIndex = 28
        Me.UserLabel1.Text = "Enter Formula"
        Me.UserLabel1.TextEnglishCode = Nothing
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Image = CType(resources.GetObject("OK_Button.Image"), System.Drawing.Image)
        Me.OK_Button.Location = New System.Drawing.Point(319, 3)
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(63, 279)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(515, 49)
        Me.TableLayoutPanel1.TabIndex = 26
        '
        'TxtFieldNames
        '
        Me.TxtFieldNames.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFieldNames.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtFieldNames.FormattingEnabled = True
        Me.TxtFieldNames.Location = New System.Drawing.Point(155, 60)
        Me.TxtFieldNames.Name = "TxtFieldNames"
        Me.TxtFieldNames.Size = New System.Drawing.Size(283, 21)
        Me.TxtFieldNames.Sorted = True
        Me.TxtFieldNames.TabIndex = 1
        '
        'UserLabel3
        '
        Me.UserLabel3.AutoSize = True
        Me.UserLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel3.Location = New System.Drawing.Point(24, 61)
        Me.UserLabel3.Name = "UserLabel3"
        Me.UserLabel3.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel3.Size = New System.Drawing.Size(125, 15)
        Me.UserLabel3.TabIndex = 29
        Me.UserLabel3.Text = "Select Field Name"
        Me.UserLabel3.TextEnglishCode = Nothing
        '
        'txtFormulaName
        '
        Me.txtFormulaName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFormulaName.Location = New System.Drawing.Point(155, 92)
        Me.txtFormulaName.MaxLength = 230
        Me.txtFormulaName.Multiline = True
        Me.txtFormulaName.Name = "txtFormulaName"
        Me.txtFormulaName.Size = New System.Drawing.Size(410, 161)
        Me.txtFormulaName.TabIndex = 2
        '
        'UserLabel2
        '
        Me.UserLabel2.AutoSize = True
        Me.UserLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel2.Location = New System.Drawing.Point(24, 32)
        Me.UserLabel2.Name = "UserLabel2"
        Me.UserLabel2.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel2.Size = New System.Drawing.Size(102, 15)
        Me.UserLabel2.TabIndex = 29
        Me.UserLabel2.Text = "Formula Name"
        Me.UserLabel2.TextEnglishCode = Nothing
        '
        'TxtName
        '
        Me.TxtName.AllowToolTip = True
        Me.TxtName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtName.IsAllowDigits = True
        Me.TxtName.IsAllowSpace = True
        Me.TxtName.IsAllowSplChars = True
        Me.TxtName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtName.Location = New System.Drawing.Point(155, 32)
        Me.TxtName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtName.MaxLength = 40
        Me.TxtName.Name = "TxtName"
        Me.TxtName.SetToolTip = Nothing
        Me.TxtName.Size = New System.Drawing.Size(170, 20)
        Me.TxtName.SpecialCharList = "&-/@"
        Me.TxtName.TabIndex = 0
        Me.TxtName.UseFunctionKeys = False
        '
        'DefineFormulafrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(618, 356)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.txtFormulaName)
        Me.Controls.Add(Me.TxtHeading)
        Me.Controls.Add(Me.UserLabel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.TxtFieldNames)
        Me.Controls.Add(Me.UserLabel2)
        Me.Controls.Add(Me.UserLabel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DefineFormulafrm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DefineFormulafrm"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TxtHeading As UserLabel.UserLabel
    Friend WithEvents UserLabel1 As UserLabel.UserLabel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtFieldNames As System.Windows.Forms.ComboBox
    Friend WithEvents UserLabel3 As UserLabel.UserLabel
    Friend WithEvents txtFormulaName As System.Windows.Forms.TextBox
    Friend WithEvents UserLabel2 As UserLabel.UserLabel
    Friend WithEvents TxtName As JyothiPharmaERPSystem3.IMSTextBox

End Class
