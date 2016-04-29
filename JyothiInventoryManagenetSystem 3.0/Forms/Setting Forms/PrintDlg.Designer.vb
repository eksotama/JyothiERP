<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintDlg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrintDlg))
        Me.IsPrintPreview = New System.Windows.Forms.CheckBox()
        Me.UserLabel2 = New UserLabel.UserLabel()
        Me.UserLabel3 = New UserLabel.UserLabel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.UserLabel1 = New UserLabel.UserLabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TxtSelectedSchemeName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtNoOfCopies = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtDuplicateInvoice = New System.Windows.Forms.CheckBox()
        Me.UserLabel4 = New UserLabel.UserLabel()
        Me.TxtPrinterName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IsPrintPreview
        '
        Me.IsPrintPreview.AutoSize = True
        Me.IsPrintPreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsPrintPreview.Location = New System.Drawing.Point(273, 133)
        Me.IsPrintPreview.Name = "IsPrintPreview"
        Me.IsPrintPreview.Size = New System.Drawing.Size(181, 19)
        Me.IsPrintPreview.TabIndex = 10
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
        Me.UserLabel2.Size = New System.Drawing.Size(507, 24)
        Me.UserLabel2.TabIndex = 6
        Me.UserLabel2.Text = "PRINTING"
        Me.UserLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.UserLabel2.TextEnglishCode = Nothing
        '
        'UserLabel3
        '
        Me.UserLabel3.AutoSize = True
        Me.UserLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel3.Location = New System.Drawing.Point(6, 89)
        Me.UserLabel3.Name = "UserLabel3"
        Me.UserLabel3.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel3.Size = New System.Drawing.Size(155, 15)
        Me.UserLabel3.TabIndex = 7
        Me.UserLabel3.Text = "Printing Scheme Name"
        Me.UserLabel3.TextEnglishCode = Nothing
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Image = CType(resources.GetObject("OK_Button.Image"), System.Drawing.Image)
        Me.OK_Button.Location = New System.Drawing.Point(226, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(171, 49)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "&OK"
        Me.OK_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'UserLabel1
        '
        Me.UserLabel1.AutoSize = True
        Me.UserLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel1.Location = New System.Drawing.Point(16, 137)
        Me.UserLabel1.Name = "UserLabel1"
        Me.UserLabel1.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel1.Size = New System.Drawing.Size(95, 15)
        Me.UserLabel1.TabIndex = 8
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(43, 205)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(416, 55)
        Me.TableLayoutPanel1.TabIndex = 5
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
        'TxtSelectedSchemeName
        '
        Me.TxtSelectedSchemeName.AllowEmpty = True
        Me.TxtSelectedSchemeName.AllowOnlyListValues = False
        Me.TxtSelectedSchemeName.AllowToolTip = True
        Me.TxtSelectedSchemeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtSelectedSchemeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtSelectedSchemeName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtSelectedSchemeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtSelectedSchemeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSelectedSchemeName.FormattingEnabled = True
        Me.TxtSelectedSchemeName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSelectedSchemeName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSelectedSchemeName.IsAdvanceSearchWindow = False
        Me.TxtSelectedSchemeName.IsAllowDigits = True
        Me.TxtSelectedSchemeName.IsAllowSpace = True
        Me.TxtSelectedSchemeName.IsAllowSplChars = True
        Me.TxtSelectedSchemeName.IsAllowToolTip = True
        Me.TxtSelectedSchemeName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSelectedSchemeName.Location = New System.Drawing.Point(12, 106)
        Me.TxtSelectedSchemeName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSelectedSchemeName.Name = "TxtSelectedSchemeName"
        Me.TxtSelectedSchemeName.SetToolTip = Nothing
        Me.TxtSelectedSchemeName.Size = New System.Drawing.Size(431, 21)
        Me.TxtSelectedSchemeName.Sorted = True
        Me.TxtSelectedSchemeName.SpecialCharList = "&-/@"
        Me.TxtSelectedSchemeName.TabIndex = 11
        Me.TxtSelectedSchemeName.UseFunctionKeys = False
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
        Me.TxtNoOfCopies.Location = New System.Drawing.Point(112, 137)
        Me.TxtNoOfCopies.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNoOfCopies.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtNoOfCopies.Max = CType(100, Long)
        Me.TxtNoOfCopies.MaxLength = 12
        Me.TxtNoOfCopies.Min = CType(0, Long)
        Me.TxtNoOfCopies.Name = "TxtNoOfCopies"
        Me.TxtNoOfCopies.NextOnEnter = True
        Me.TxtNoOfCopies.SetToolTip = Nothing
        Me.TxtNoOfCopies.Size = New System.Drawing.Size(86, 21)
        Me.TxtNoOfCopies.TabIndex = 12
        Me.TxtNoOfCopies.Text = "1"
        Me.TxtNoOfCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNoOfCopies.ToolTip = Nothing
        Me.TxtNoOfCopies.UseFunctionKeys = False
        Me.TxtNoOfCopies.UseUpDownArrowKeys = False
        '
        'TxtDuplicateInvoice
        '
        Me.TxtDuplicateInvoice.AutoSize = True
        Me.TxtDuplicateInvoice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDuplicateInvoice.Location = New System.Drawing.Point(112, 164)
        Me.TxtDuplicateInvoice.Name = "TxtDuplicateInvoice"
        Me.TxtDuplicateInvoice.Size = New System.Drawing.Size(156, 17)
        Me.TxtDuplicateInvoice.TabIndex = 13
        Me.TxtDuplicateInvoice.Text = "Print Duplicate Invoice"
        Me.TxtDuplicateInvoice.UseVisualStyleBackColor = True
        Me.TxtDuplicateInvoice.Visible = False
        '
        'UserLabel4
        '
        Me.UserLabel4.AutoSize = True
        Me.UserLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel4.Location = New System.Drawing.Point(13, 31)
        Me.UserLabel4.Name = "UserLabel4"
        Me.UserLabel4.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel4.Size = New System.Drawing.Size(92, 15)
        Me.UserLabel4.TabIndex = 7
        Me.UserLabel4.Text = "Printer Name"
        Me.UserLabel4.TextEnglishCode = Nothing
        '
        'TxtPrinterName
        '
        Me.TxtPrinterName.AllowEmpty = True
        Me.TxtPrinterName.AllowOnlyListValues = False
        Me.TxtPrinterName.AllowToolTip = True
        Me.TxtPrinterName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtPrinterName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtPrinterName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtPrinterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtPrinterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrinterName.FormattingEnabled = True
        Me.TxtPrinterName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPrinterName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPrinterName.IsAdvanceSearchWindow = False
        Me.TxtPrinterName.IsAllowDigits = True
        Me.TxtPrinterName.IsAllowSpace = True
        Me.TxtPrinterName.IsAllowSplChars = True
        Me.TxtPrinterName.IsAllowToolTip = True
        Me.TxtPrinterName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPrinterName.Location = New System.Drawing.Point(12, 49)
        Me.TxtPrinterName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPrinterName.Name = "TxtPrinterName"
        Me.TxtPrinterName.SetToolTip = Nothing
        Me.TxtPrinterName.Size = New System.Drawing.Size(431, 21)
        Me.TxtPrinterName.Sorted = True
        Me.TxtPrinterName.SpecialCharList = "&-/@"
        Me.TxtPrinterName.TabIndex = 11
        Me.TxtPrinterName.UseFunctionKeys = False
        '
        'PrintDlg
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(507, 269)
        Me.Controls.Add(Me.TxtDuplicateInvoice)
        Me.Controls.Add(Me.TxtNoOfCopies)
        Me.Controls.Add(Me.TxtPrinterName)
        Me.Controls.Add(Me.TxtSelectedSchemeName)
        Me.Controls.Add(Me.IsPrintPreview)
        Me.Controls.Add(Me.UserLabel4)
        Me.Controls.Add(Me.UserLabel2)
        Me.Controls.Add(Me.UserLabel3)
        Me.Controls.Add(Me.UserLabel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PrintDlg"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Print Options"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents IsPrintPreview As System.Windows.Forms.CheckBox
    Friend WithEvents UserLabel2 As UserLabel.UserLabel
    Friend WithEvents UserLabel3 As UserLabel.UserLabel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents UserLabel1 As UserLabel.UserLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TxtSelectedSchemeName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtNoOfCopies As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtDuplicateInvoice As System.Windows.Forms.CheckBox
    Friend WithEvents UserLabel4 As UserLabel.UserLabel
    Friend WithEvents TxtPrinterName As JyothiPharmaERPSystem3.IMSComboBox

End Class
