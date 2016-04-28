<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Payrollsettingsfrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Payrollsettingsfrm))
        Me.UserLabel2 = New UserLabel.UserLabel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.UserLabel4 = New UserLabel.UserLabel()
        Me.TxtPayrollVhPapersize = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UserLabel2
        '
        Me.UserLabel2.BackColor = System.Drawing.Color.DarkOrange
        Me.UserLabel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.UserLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel2.ForeColor = System.Drawing.Color.White
        Me.UserLabel2.Location = New System.Drawing.Point(0, 0)
        Me.UserLabel2.Name = "UserLabel2"
        Me.UserLabel2.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel2.Size = New System.Drawing.Size(571, 24)
        Me.UserLabel2.TabIndex = 15
        Me.UserLabel2.Text = "PAYROLL PRINTING SETTINGS"
        Me.UserLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.UserLabel2.TextEnglishCode = Nothing
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Image = CType(resources.GetObject("OK_Button.Image"), System.Drawing.Image)
        Me.OK_Button.Location = New System.Drawing.Point(226, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(171, 49)
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(90, 200)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(416, 55)
        Me.TableLayoutPanel1.TabIndex = 14
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Image = CType(resources.GetObject("Cancel_Button.Image"), System.Drawing.Image)
        Me.Cancel_Button.Location = New System.Drawing.Point(22, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(163, 49)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'UserLabel4
        '
        Me.UserLabel4.AutoSize = True
        Me.UserLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel4.Location = New System.Drawing.Point(13, 46)
        Me.UserLabel4.Name = "UserLabel4"
        Me.UserLabel4.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel4.Size = New System.Drawing.Size(181, 15)
        Me.UserLabel4.TabIndex = 17
        Me.UserLabel4.Text = "Payroll Voucher Paper Size"
        Me.UserLabel4.TextEnglishCode = Nothing
        '
        'TxtPayrollVhPapersize
        '
        Me.TxtPayrollVhPapersize.AllowEmpty = True
        Me.TxtPayrollVhPapersize.AllowOnlyListValues = False
        Me.TxtPayrollVhPapersize.AllowToolTip = True
        Me.TxtPayrollVhPapersize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtPayrollVhPapersize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtPayrollVhPapersize.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtPayrollVhPapersize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtPayrollVhPapersize.FormattingEnabled = True
        Me.TxtPayrollVhPapersize.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPayrollVhPapersize.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPayrollVhPapersize.IsAdvanceSearchWindow = False
        Me.TxtPayrollVhPapersize.IsAllowDigits = True
        Me.TxtPayrollVhPapersize.IsAllowSpace = True
        Me.TxtPayrollVhPapersize.IsAllowSplChars = True
        Me.TxtPayrollVhPapersize.IsAllowToolTip = True
        Me.TxtPayrollVhPapersize.Items.AddRange(New Object() {"A4", "A5"})
        Me.TxtPayrollVhPapersize.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPayrollVhPapersize.Location = New System.Drawing.Point(205, 44)
        Me.TxtPayrollVhPapersize.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPayrollVhPapersize.Name = "TxtPayrollVhPapersize"
        Me.TxtPayrollVhPapersize.SetToolTip = Nothing
        Me.TxtPayrollVhPapersize.Size = New System.Drawing.Size(101, 21)
        Me.TxtPayrollVhPapersize.Sorted = True
        Me.TxtPayrollVhPapersize.SpecialCharList = "&-/@"
        Me.TxtPayrollVhPapersize.TabIndex = 18
        Me.TxtPayrollVhPapersize.UseFunctionKeys = False
        '
        'Payrollsettingsfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(571, 267)
        Me.Controls.Add(Me.TxtPayrollVhPapersize)
        Me.Controls.Add(Me.UserLabel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.UserLabel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Payrollsettingsfrm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Payroll Settings"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UserLabel2 As UserLabel.UserLabel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents UserLabel4 As UserLabel.UserLabel
    Friend WithEvents TxtPayrollVhPapersize As JyothiPharmaERPSystem3.IMSComboBox

End Class
