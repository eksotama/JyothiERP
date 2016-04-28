<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VoucherPrintDlg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VoucherPrintDlg))
        Me.IsPrintPreview = New System.Windows.Forms.CheckBox()
        Me.TxtNoOfCopies = New UserNumericTextBox.UserNumericTextBox()
        Me.TxtHeading = New UserLabel.UserLabel()
        Me.UserLabel1 = New UserLabel.UserLabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.UserLabel3 = New UserLabel.UserLabel()
        Me.TxtPrinterName = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IsPrintPreview
        '
        Me.IsPrintPreview.AutoSize = True
        Me.IsPrintPreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsPrintPreview.Location = New System.Drawing.Point(158, 127)
        Me.IsPrintPreview.Name = "IsPrintPreview"
        Me.IsPrintPreview.Size = New System.Drawing.Size(181, 19)
        Me.IsPrintPreview.TabIndex = 17
        Me.IsPrintPreview.Text = "Show With Print Preview"
        Me.IsPrintPreview.UseVisualStyleBackColor = True
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
        Me.TxtNoOfCopies.ForeColor = System.Drawing.Color.Navy
        Me.TxtNoOfCopies.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNoOfCopies.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNoOfCopies.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtNoOfCopies.HelpText = Nothing
        Me.TxtNoOfCopies.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNoOfCopies.Location = New System.Drawing.Point(158, 90)
        Me.TxtNoOfCopies.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNoOfCopies.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtNoOfCopies.Max = CType(100, Long)
        Me.TxtNoOfCopies.MaxLength = 2
        Me.TxtNoOfCopies.Min = CType(1, Long)
        Me.TxtNoOfCopies.Name = "TxtNoOfCopies"
        Me.TxtNoOfCopies.NextOnEnter = True
        Me.TxtNoOfCopies.Size = New System.Drawing.Size(70, 21)
        Me.TxtNoOfCopies.TabIndex = 16
        Me.TxtNoOfCopies.Text = "1"
        Me.TxtNoOfCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtNoOfCopies.ToolTip = Nothing
        Me.TxtNoOfCopies.UseFunctionKeys = False
        Me.TxtNoOfCopies.UseUpDownArrowKeys = False
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
        Me.TxtHeading.Size = New System.Drawing.Size(481, 24)
        Me.TxtHeading.TabIndex = 13
        Me.TxtHeading.Text = "VOUCHER PRINTING"
        Me.TxtHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.TxtHeading.TextEnglishCode = Nothing
        '
        'UserLabel1
        '
        Me.UserLabel1.AutoSize = True
        Me.UserLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel1.Location = New System.Drawing.Point(57, 90)
        Me.UserLabel1.Name = "UserLabel1"
        Me.UserLabel1.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel1.Size = New System.Drawing.Size(95, 15)
        Me.UserLabel1.TabIndex = 15
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(10, 161)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(459, 60)
        Me.TableLayoutPanel1.TabIndex = 12
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Image = CType(resources.GetObject("OK_Button.Image"), System.Drawing.Image)
        Me.OK_Button.Location = New System.Drawing.Point(277, 9)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(133, 42)
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
        Me.Cancel_Button.Location = New System.Drawing.Point(48, 9)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(133, 42)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'UserLabel3
        '
        Me.UserLabel3.AutoSize = True
        Me.UserLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel3.Location = New System.Drawing.Point(16, 52)
        Me.UserLabel3.Name = "UserLabel3"
        Me.UserLabel3.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel3.Size = New System.Drawing.Size(136, 15)
        Me.UserLabel3.TabIndex = 15
        Me.UserLabel3.Text = "Select Printer Name"
        Me.UserLabel3.TextEnglishCode = Nothing
        '
        'TxtPrinterName
        '
        Me.TxtPrinterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrinterName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtPrinterName.FormattingEnabled = True
        Me.TxtPrinterName.Location = New System.Drawing.Point(158, 51)
        Me.TxtPrinterName.Name = "TxtPrinterName"
        Me.TxtPrinterName.Size = New System.Drawing.Size(268, 21)
        Me.TxtPrinterName.Sorted = True
        Me.TxtPrinterName.TabIndex = 18
        '
        'VoucherPrintDlg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(481, 240)
        Me.Controls.Add(Me.TxtPrinterName)
        Me.Controls.Add(Me.IsPrintPreview)
        Me.Controls.Add(Me.TxtNoOfCopies)
        Me.Controls.Add(Me.TxtHeading)
        Me.Controls.Add(Me.UserLabel3)
        Me.Controls.Add(Me.UserLabel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "VoucherPrintDlg"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Voucher Printing"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents IsPrintPreview As System.Windows.Forms.CheckBox
    Friend WithEvents TxtNoOfCopies As UserNumericTextBox.UserNumericTextBox
    Friend WithEvents TxtHeading As UserLabel.UserLabel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents UserLabel1 As UserLabel.UserLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents UserLabel3 As UserLabel.UserLabel
    Friend WithEvents TxtPrinterName As System.Windows.Forms.ComboBox

End Class
