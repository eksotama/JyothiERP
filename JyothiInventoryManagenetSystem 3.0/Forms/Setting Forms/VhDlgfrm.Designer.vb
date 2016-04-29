<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VhDlgfrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VhDlgfrm))
        Me.TxtDuplicateInvoice = New System.Windows.Forms.CheckBox()
        Me.IsPrintPreview = New System.Windows.Forms.CheckBox()
        Me.UserLabel2 = New UserLabel.UserLabel()
        Me.UserLabel1 = New UserLabel.UserLabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TxtNoOfCopies = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtPrinterName = New System.Windows.Forms.ComboBox()
        Me.UserLabel3 = New UserLabel.UserLabel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtDuplicateInvoice
        '
        Me.TxtDuplicateInvoice.AutoSize = True
        Me.TxtDuplicateInvoice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDuplicateInvoice.Location = New System.Drawing.Point(256, 99)
        Me.TxtDuplicateInvoice.Name = "TxtDuplicateInvoice"
        Me.TxtDuplicateInvoice.Size = New System.Drawing.Size(156, 17)
        Me.TxtDuplicateInvoice.TabIndex = 2
        Me.TxtDuplicateInvoice.Text = "Print Duplicate Invoice"
        Me.TxtDuplicateInvoice.UseVisualStyleBackColor = True
        Me.TxtDuplicateInvoice.Visible = False
        '
        'IsPrintPreview
        '
        Me.IsPrintPreview.AutoSize = True
        Me.IsPrintPreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsPrintPreview.Location = New System.Drawing.Point(144, 137)
        Me.IsPrintPreview.Name = "IsPrintPreview"
        Me.IsPrintPreview.Size = New System.Drawing.Size(181, 19)
        Me.IsPrintPreview.TabIndex = 3
        Me.IsPrintPreview.Text = "Show With Print Preview"
        Me.IsPrintPreview.UseVisualStyleBackColor = True
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
        Me.UserLabel2.Size = New System.Drawing.Size(499, 24)
        Me.UserLabel2.TabIndex = 15
        Me.UserLabel2.Text = "PRINTING"
        Me.UserLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.UserLabel2.TextEnglishCode = Nothing
        '
        'UserLabel1
        '
        Me.UserLabel1.AutoSize = True
        Me.UserLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel1.Location = New System.Drawing.Point(2, 99)
        Me.UserLabel1.Name = "UserLabel1"
        Me.UserLabel1.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel1.Size = New System.Drawing.Size(95, 15)
        Me.UserLabel1.TabIndex = 17
        Me.UserLabel1.Text = "No Of Copies:"
        Me.UserLabel1.TextEnglishCode = Nothing
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(54, 184)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(416, 55)
        Me.TableLayoutPanel1.TabIndex = 14
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
        'TxtNoOfCopies
        '
        Me.TxtNoOfCopies.AllHelpText = True
        Me.TxtNoOfCopies.AllowDecimal = False
        Me.TxtNoOfCopies.AllowFormulas = False
        Me.TxtNoOfCopies.AllowForQty = True
        Me.TxtNoOfCopies.AllowNegative = False
        Me.TxtNoOfCopies.AllowPerSign = False
        Me.TxtNoOfCopies.AllowPlusSign = False
        Me.TxtNoOfCopies.AllowToolTip = True
        Me.TxtNoOfCopies.DecimalPlaces = CType(3, Short)
        Me.TxtNoOfCopies.ExitOnEscKey = True
        Me.TxtNoOfCopies.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoOfCopies.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNoOfCopies.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNoOfCopies.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtNoOfCopies.HelpText = Nothing
        Me.TxtNoOfCopies.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNoOfCopies.Location = New System.Drawing.Point(144, 95)
        Me.TxtNoOfCopies.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNoOfCopies.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtNoOfCopies.Max = CType(100, Long)
        Me.TxtNoOfCopies.MaxLength = 12
        Me.TxtNoOfCopies.Min = CType(0, Long)
        Me.TxtNoOfCopies.Name = "TxtNoOfCopies"
        Me.TxtNoOfCopies.NextOnEnter = True
        Me.TxtNoOfCopies.SetToolTip = Nothing
        Me.TxtNoOfCopies.Size = New System.Drawing.Size(86, 21)
        Me.TxtNoOfCopies.TabIndex = 1
        Me.TxtNoOfCopies.Text = "1"
        Me.TxtNoOfCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNoOfCopies.ToolTip = Nothing
        Me.TxtNoOfCopies.UseFunctionKeys = False
        Me.TxtNoOfCopies.UseUpDownArrowKeys = False
        '
        'TxtPrinterName
        '
        Me.TxtPrinterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrinterName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtPrinterName.FormattingEnabled = True
        Me.TxtPrinterName.Location = New System.Drawing.Point(144, 50)
        Me.TxtPrinterName.Name = "TxtPrinterName"
        Me.TxtPrinterName.Size = New System.Drawing.Size(268, 21)
        Me.TxtPrinterName.Sorted = True
        Me.TxtPrinterName.TabIndex = 0
        '
        'UserLabel3
        '
        Me.UserLabel3.AutoSize = True
        Me.UserLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel3.Location = New System.Drawing.Point(2, 51)
        Me.UserLabel3.Name = "UserLabel3"
        Me.UserLabel3.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel3.Size = New System.Drawing.Size(136, 15)
        Me.UserLabel3.TabIndex = 22
        Me.UserLabel3.Text = "Select Printer Name"
        Me.UserLabel3.TextEnglishCode = Nothing
        '
        'VhDlgfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(499, 251)
        Me.Controls.Add(Me.TxtPrinterName)
        Me.Controls.Add(Me.UserLabel3)
        Me.Controls.Add(Me.TxtDuplicateInvoice)
        Me.Controls.Add(Me.IsPrintPreview)
        Me.Controls.Add(Me.UserLabel2)
        Me.Controls.Add(Me.UserLabel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.TxtNoOfCopies)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "VhDlgfrm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Voucher Printing"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtDuplicateInvoice As System.Windows.Forms.CheckBox
    Friend WithEvents IsPrintPreview As System.Windows.Forms.CheckBox
    Friend WithEvents UserLabel2 As UserLabel.UserLabel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents UserLabel1 As UserLabel.UserLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TxtNoOfCopies As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtPrinterName As System.Windows.Forms.ComboBox
    Friend WithEvents UserLabel3 As UserLabel.UserLabel

End Class
