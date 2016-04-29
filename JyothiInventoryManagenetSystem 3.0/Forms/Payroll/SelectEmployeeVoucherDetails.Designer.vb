<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectEmployeeVoucherDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectEmployeeVoucherDetails))
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ImSlabel12 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel9 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel10 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel11 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.PayList = New JyothiPharmaERPSystem3.PayrollVoucherControl()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtTotalPayLedgerName = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel13 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtCreditTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtNetTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtDebitTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnCancel = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnOk = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtTitle = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.PayList, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtTitle, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.Padding = New System.Windows.Forms.Padding(5)
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(697, 484)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Controls.Add(Me.ImSlabel12)
        Me.Panel2.Controls.Add(Me.ImSlabel8)
        Me.Panel2.Controls.Add(Me.ImSlabel9)
        Me.Panel2.Controls.Add(Me.ImSlabel10)
        Me.Panel2.Controls.Add(Me.ImSlabel11)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(8, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(681, 25)
        Me.Panel2.TabIndex = 23
        '
        'ImSlabel12
        '
        Me.ImSlabel12.AutoSize = True
        Me.ImSlabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel12.Location = New System.Drawing.Point(310, 5)
        Me.ImSlabel12.Name = "ImSlabel12"
        Me.ImSlabel12.Size = New System.Drawing.Size(46, 13)
        Me.ImSlabel12.TabIndex = 2
        Me.ImSlabel12.Text = "Details"
        '
        'ImSlabel8
        '
        Me.ImSlabel8.AutoSize = True
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(566, 5)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(40, 13)
        Me.ImSlabel8.TabIndex = 1
        Me.ImSlabel8.Text = "Credit"
        '
        'ImSlabel9
        '
        Me.ImSlabel9.AutoSize = True
        Me.ImSlabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel9.Location = New System.Drawing.Point(3, 5)
        Me.ImSlabel9.Name = "ImSlabel9"
        Me.ImSlabel9.Size = New System.Drawing.Size(38, 13)
        Me.ImSlabel9.TabIndex = 1
        Me.ImSlabel9.Text = "Dr/Cr"
        '
        'ImSlabel10
        '
        Me.ImSlabel10.AutoSize = True
        Me.ImSlabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel10.Location = New System.Drawing.Point(437, 5)
        Me.ImSlabel10.Name = "ImSlabel10"
        Me.ImSlabel10.Size = New System.Drawing.Size(37, 13)
        Me.ImSlabel10.TabIndex = 1
        Me.ImSlabel10.Text = "Debit"
        '
        'ImSlabel11
        '
        Me.ImSlabel11.AutoSize = True
        Me.ImSlabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel11.Location = New System.Drawing.Point(69, 4)
        Me.ImSlabel11.Name = "ImSlabel11"
        Me.ImSlabel11.Size = New System.Drawing.Size(103, 13)
        Me.ImSlabel11.TabIndex = 1
        Me.ImSlabel11.Text = "Ledger Accounts"
        '
        'PayList
        '
        Me.PayList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PayList.Location = New System.Drawing.Point(8, 67)
        Me.PayList.Name = "PayList"
        Me.PayList.Size = New System.Drawing.Size(681, 299)
        Me.PayList.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TxtTotalPayLedgerName)
        Me.Panel3.Controls.Add(Me.ImSlabel13)
        Me.Panel3.Controls.Add(Me.TxtCreditTotal)
        Me.Panel3.Controls.Add(Me.TxtNetTotal)
        Me.Panel3.Controls.Add(Me.TxtDebitTotal)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(5, 369)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(687, 55)
        Me.Panel3.TabIndex = 24
        '
        'TxtTotalPayLedgerName
        '
        Me.TxtTotalPayLedgerName.AutoSize = True
        Me.TxtTotalPayLedgerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalPayLedgerName.Location = New System.Drawing.Point(313, 36)
        Me.TxtTotalPayLedgerName.Name = "TxtTotalPayLedgerName"
        Me.TxtTotalPayLedgerName.Size = New System.Drawing.Size(79, 13)
        Me.TxtTotalPayLedgerName.TabIndex = 1
        Me.TxtTotalPayLedgerName.Text = "PayLedger : "
        '
        'ImSlabel13
        '
        Me.ImSlabel13.AutoSize = True
        Me.ImSlabel13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel13.Location = New System.Drawing.Point(369, 10)
        Me.ImSlabel13.Name = "ImSlabel13"
        Me.ImSlabel13.Size = New System.Drawing.Size(46, 13)
        Me.ImSlabel13.TabIndex = 1
        Me.ImSlabel13.Text = "Totals:"
        '
        'TxtCreditTotal
        '
        Me.TxtCreditTotal.AllowToolTip = True
        Me.TxtCreditTotal.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtCreditTotal.Enabled = False
        Me.TxtCreditTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtCreditTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCreditTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCreditTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtCreditTotal.IsAllowDigits = True
        Me.TxtCreditTotal.IsAllowSpace = True
        Me.TxtCreditTotal.IsAllowSplChars = True
        Me.TxtCreditTotal.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCreditTotal.Location = New System.Drawing.Point(557, 6)
        Me.TxtCreditTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCreditTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtCreditTotal.MaxLength = 75
        Me.TxtCreditTotal.Name = "TxtCreditTotal"
        Me.TxtCreditTotal.SetToolTip = Nothing
        Me.TxtCreditTotal.Size = New System.Drawing.Size(119, 20)
        Me.TxtCreditTotal.SpecialCharList = "&-/@"
        Me.TxtCreditTotal.TabIndex = 1
        Me.TxtCreditTotal.UseFunctionKeys = False
        '
        'TxtNetTotal
        '
        Me.TxtNetTotal.AllowToolTip = True
        Me.TxtNetTotal.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtNetTotal.Enabled = False
        Me.TxtNetTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtNetTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNetTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNetTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtNetTotal.IsAllowDigits = True
        Me.TxtNetTotal.IsAllowSpace = True
        Me.TxtNetTotal.IsAllowSplChars = True
        Me.TxtNetTotal.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNetTotal.Location = New System.Drawing.Point(557, 29)
        Me.TxtNetTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNetTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtNetTotal.MaxLength = 75
        Me.TxtNetTotal.Name = "TxtNetTotal"
        Me.TxtNetTotal.SetToolTip = Nothing
        Me.TxtNetTotal.Size = New System.Drawing.Size(119, 20)
        Me.TxtNetTotal.SpecialCharList = "&-/@"
        Me.TxtNetTotal.TabIndex = 2
        Me.TxtNetTotal.UseFunctionKeys = False
        '
        'TxtDebitTotal
        '
        Me.TxtDebitTotal.AllowToolTip = True
        Me.TxtDebitTotal.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtDebitTotal.Enabled = False
        Me.TxtDebitTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtDebitTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDebitTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDebitTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtDebitTotal.IsAllowDigits = True
        Me.TxtDebitTotal.IsAllowSpace = True
        Me.TxtDebitTotal.IsAllowSplChars = True
        Me.TxtDebitTotal.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDebitTotal.Location = New System.Drawing.Point(432, 7)
        Me.TxtDebitTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDebitTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtDebitTotal.MaxLength = 75
        Me.TxtDebitTotal.Name = "TxtDebitTotal"
        Me.TxtDebitTotal.SetToolTip = Nothing
        Me.TxtDebitTotal.Size = New System.Drawing.Size(119, 20)
        Me.TxtDebitTotal.SpecialCharList = "&-/@"
        Me.TxtDebitTotal.TabIndex = 0
        Me.TxtDebitTotal.UseFunctionKeys = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnCancel)
        Me.Panel1.Controls.Add(Me.BtnOk)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(5, 424)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(687, 55)
        Me.Panel1.TabIndex = 25
        '
        'BtnCancel
        '
        Me.BtnCancel.AllowToolTip = True
        Me.BtnCancel.BackColor = System.Drawing.Color.White
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(125, 6)
        Me.BtnCancel.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.SetToolTip = ""
        Me.BtnCancel.Size = New System.Drawing.Size(137, 41)
        Me.BtnCancel.TabIndex = 0
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseFunctionKeys = False
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'BtnOk
        '
        Me.BtnOk.AllowToolTip = True
        Me.BtnOk.BackColor = System.Drawing.Color.White
        Me.BtnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOk.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        Me.BtnOk.Location = New System.Drawing.Point(435, 6)
        Me.BtnOk.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.SetToolTip = ""
        Me.BtnOk.Size = New System.Drawing.Size(137, 44)
        Me.BtnOk.TabIndex = 0
        Me.BtnOk.Text = "&Save && Close"
        Me.BtnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnOk.UseFunctionKeys = False
        Me.BtnOk.UseVisualStyleBackColor = False
        '
        'TxtTitle
        '
        Me.TxtTitle.AutoSize = True
        Me.TxtTitle.BackColor = System.Drawing.Color.DarkOrange
        Me.TxtTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitle.ForeColor = System.Drawing.Color.White
        Me.TxtTitle.Location = New System.Drawing.Point(5, 5)
        Me.TxtTitle.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(687, 28)
        Me.TxtTitle.TabIndex = 26
        Me.TxtTitle.Text = "LEDGER ALLOCATION"
        Me.TxtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SelectEmployeeVoucherDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(697, 484)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SelectEmployeeVoucherDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "LEDGER ALLOCATION FOR THE EMPLOYEE PAY SLIP"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel12 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel9 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel10 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel11 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents PayList As JyothiPharmaERPSystem3.PayrollVoucherControl
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TxtTotalPayLedgerName As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel13 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtCreditTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtNetTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtDebitTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnCancel As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnOk As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtTitle As JyothiPharmaERPSystem3.IMSHeadingLabel
End Class
