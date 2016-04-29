<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportPrintSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportPrintSettings))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtPrinterName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.UserLabel4 = New UserLabel.UserLabel()
        Me.UserLabel2 = New UserLabel.UserLabel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.UserLabel1 = New UserLabel.UserLabel()
        Me.TxtFileType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.UserLabel3 = New UserLabel.UserLabel()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(47, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(163, 49)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Cancel"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
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
        Me.TxtPrinterName.Location = New System.Drawing.Point(116, 58)
        Me.TxtPrinterName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPrinterName.Name = "TxtPrinterName"
        Me.TxtPrinterName.SetToolTip = Nothing
        Me.TxtPrinterName.Size = New System.Drawing.Size(431, 21)
        Me.TxtPrinterName.Sorted = True
        Me.TxtPrinterName.SpecialCharList = "&-/@"
        Me.TxtPrinterName.TabIndex = 20
        Me.TxtPrinterName.UseFunctionKeys = False
        '
        'UserLabel4
        '
        Me.UserLabel4.AutoSize = True
        Me.UserLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel4.Location = New System.Drawing.Point(18, 58)
        Me.UserLabel4.Name = "UserLabel4"
        Me.UserLabel4.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel4.Size = New System.Drawing.Size(92, 15)
        Me.UserLabel4.TabIndex = 16
        Me.UserLabel4.Text = "Printer Name"
        Me.UserLabel4.TextEnglishCode = Nothing
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
        Me.UserLabel2.Size = New System.Drawing.Size(585, 24)
        Me.UserLabel2.TabIndex = 15
        Me.UserLabel2.Text = "EXPORT PRINTER SETTINGS"
        Me.UserLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.UserLabel2.TextEnglishCode = Nothing
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(302, 11)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(171, 49)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "&SAVE"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Button2, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Button1, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(56, 159)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(517, 71)
        Me.TableLayoutPanel2.TabIndex = 14
        '
        'UserLabel1
        '
        Me.UserLabel1.AutoSize = True
        Me.UserLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel1.Location = New System.Drawing.Point(18, 95)
        Me.UserLabel1.Name = "UserLabel1"
        Me.UserLabel1.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel1.Size = New System.Drawing.Size(37, 15)
        Me.UserLabel1.TabIndex = 16
        Me.UserLabel1.Text = "Type"
        Me.UserLabel1.TextEnglishCode = Nothing
        '
        'TxtFileType
        '
        Me.TxtFileType.AllowEmpty = True
        Me.TxtFileType.AllowOnlyListValues = False
        Me.TxtFileType.AllowToolTip = True
        Me.TxtFileType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtFileType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtFileType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtFileType.FormattingEnabled = True
        Me.TxtFileType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtFileType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtFileType.IsAdvanceSearchWindow = False
        Me.TxtFileType.IsAllowDigits = True
        Me.TxtFileType.IsAllowSpace = True
        Me.TxtFileType.IsAllowSplChars = True
        Me.TxtFileType.IsAllowToolTip = True
        Me.TxtFileType.Items.AddRange(New Object() {"PDF", "XPS"})
        Me.TxtFileType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtFileType.Location = New System.Drawing.Point(122, 91)
        Me.TxtFileType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtFileType.Name = "TxtFileType"
        Me.TxtFileType.SetToolTip = Nothing
        Me.TxtFileType.Size = New System.Drawing.Size(121, 21)
        Me.TxtFileType.Sorted = True
        Me.TxtFileType.SpecialCharList = "&-/@"
        Me.TxtFileType.TabIndex = 21
        Me.TxtFileType.UseFunctionKeys = False
        '
        'UserLabel3
        '
        Me.UserLabel3.AutoSize = True
        Me.UserLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel3.Location = New System.Drawing.Point(18, 28)
        Me.UserLabel3.Name = "UserLabel3"
        Me.UserLabel3.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel3.Size = New System.Drawing.Size(279, 15)
        Me.UserLabel3.TabIndex = 16
        Me.UserLabel3.Text = "This Setting for Custom Paper Invoice Only"
        Me.UserLabel3.TextEnglishCode = Nothing
        '
        'ExportPrintSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(585, 260)
        Me.Controls.Add(Me.TxtFileType)
        Me.Controls.Add(Me.TxtPrinterName)
        Me.Controls.Add(Me.UserLabel1)
        Me.Controls.Add(Me.UserLabel3)
        Me.Controls.Add(Me.UserLabel4)
        Me.Controls.Add(Me.UserLabel2)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ExportPrintSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ExportPrintSettings"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtPrinterName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents UserLabel4 As UserLabel.UserLabel
    Friend WithEvents UserLabel2 As UserLabel.UserLabel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents UserLabel1 As UserLabel.UserLabel
    Friend WithEvents TxtFileType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents UserLabel3 As UserLabel.UserLabel

End Class
