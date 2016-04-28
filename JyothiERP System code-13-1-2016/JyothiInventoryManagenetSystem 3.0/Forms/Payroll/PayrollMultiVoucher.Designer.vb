<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PayrollMultiVoucher
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnNew = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnoPEN = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnDelete = New JyothiPharmaERPSystem3.IMSButton()
        Me.btnprint = New JyothiPharmaERPSystem3.IMSButton()
        Me.btnsave = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtvoucherno = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtVoucherDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnCal = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtPayMethod = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtSalaryMonth = New JyothiPharmaERPSystem3.IMSDate()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtAccList = New JyothiPharmaERPSystem3.IMSList()
        Me.tlname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tamt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnAddPay = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtpayAmount = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtLedger = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TxtTempList = New JyothiPharmaERPSystem3.IMSList()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtTotalAllocationAmount = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtpayHeadLedgerList = New JyothiPharmaERPSystem3.IMSList()
        Me.tpayname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tledgername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtNetPaybleTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.txtnarration = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.TxtAccList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.TxtTempList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtpayHeadLedgerList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.ImsHeadingLabel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtnarration, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1092, 572)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 2)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnClose, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnNew, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnoPEN, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnDelete, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnprint, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnsave, 5, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 521)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1092, 51)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'btnClose
        '
        Me.btnClose.AllowToolTip = True
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Navy
        Me.btnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.btnClose.Location = New System.Drawing.Point(3, 3)
        Me.btnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnClose.Name = "btnClose"
        Me.btnClose.SetToolTip = ""
        Me.btnClose.Size = New System.Drawing.Size(175, 45)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "CLOSE"
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseFunctionKeys = False
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'BtnNew
        '
        Me.BtnNew.AllowToolTip = True
        Me.BtnNew.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNew.ForeColor = System.Drawing.Color.Navy
        Me.BtnNew.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnNew.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361186619_document_new
        Me.BtnNew.Location = New System.Drawing.Point(727, 3)
        Me.BtnNew.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.SetToolTip = ""
        Me.BtnNew.Size = New System.Drawing.Size(175, 45)
        Me.BtnNew.TabIndex = 0
        Me.BtnNew.Text = "NEW"
        Me.BtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnNew.UseFunctionKeys = False
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'BtnoPEN
        '
        Me.BtnoPEN.AllowToolTip = True
        Me.BtnoPEN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnoPEN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnoPEN.ForeColor = System.Drawing.Color.Navy
        Me.BtnoPEN.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnoPEN.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361188505_file_edit
        Me.BtnoPEN.Location = New System.Drawing.Point(546, 3)
        Me.BtnoPEN.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnoPEN.Name = "BtnoPEN"
        Me.BtnoPEN.SetToolTip = ""
        Me.BtnoPEN.Size = New System.Drawing.Size(175, 45)
        Me.BtnoPEN.TabIndex = 1
        Me.BtnoPEN.Text = "OPEN"
        Me.BtnoPEN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnoPEN.UseFunctionKeys = False
        Me.BtnoPEN.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.AllowToolTip = True
        Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.Navy
        Me.BtnDelete.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnDelete.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.delete__2_
        Me.BtnDelete.Location = New System.Drawing.Point(365, 3)
        Me.BtnDelete.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.SetToolTip = ""
        Me.BtnDelete.Size = New System.Drawing.Size(175, 45)
        Me.BtnDelete.TabIndex = 4
        Me.BtnDelete.Text = "DELETE"
        Me.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDelete.UseFunctionKeys = False
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'btnprint
        '
        Me.btnprint.AllowToolTip = True
        Me.btnprint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnprint.ForeColor = System.Drawing.Color.Navy
        Me.btnprint.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnprint.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.print__1_
        Me.btnprint.Location = New System.Drawing.Point(184, 3)
        Me.btnprint.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnprint.Name = "btnprint"
        Me.btnprint.SetToolTip = ""
        Me.btnprint.Size = New System.Drawing.Size(175, 45)
        Me.btnprint.TabIndex = 4
        Me.btnprint.Text = "PRINT"
        Me.btnprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnprint.UseFunctionKeys = False
        Me.btnprint.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.AllowToolTip = True
        Me.btnsave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnsave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.ForeColor = System.Drawing.Color.Navy
        Me.btnsave.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnsave.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.Save__1_
        Me.btnsave.Location = New System.Drawing.Point(908, 3)
        Me.btnsave.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnsave.Name = "btnsave"
        Me.btnsave.SetToolTip = ""
        Me.btnsave.Size = New System.Drawing.Size(181, 45)
        Me.btnsave.TabIndex = 0
        Me.btnsave.Text = "SAVE"
        Me.btnsave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnsave.UseFunctionKeys = False
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'ImsHeadingLabel1
        '
        Me.ImsHeadingLabel1.AutoSize = True
        Me.ImsHeadingLabel1.BackColor = System.Drawing.Color.Olive
        Me.TableLayoutPanel1.SetColumnSpan(Me.ImsHeadingLabel1, 2)
        Me.ImsHeadingLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsHeadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsHeadingLabel1.ForeColor = System.Drawing.Color.White
        Me.ImsHeadingLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ImsHeadingLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsHeadingLabel1.Name = "ImsHeadingLabel1"
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(1092, 26)
        Me.ImsHeadingLabel1.TabIndex = 0
        Me.ImsHeadingLabel1.Text = "PAYROLL VOUCHER"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtvoucherno)
        Me.Panel1.Controls.Add(Me.TxtVoucherDate)
        Me.Panel1.Controls.Add(Me.ImSlabel2)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 26)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(546, 57)
        Me.Panel1.TabIndex = 1
        '
        'txtvoucherno
        '
        Me.txtvoucherno.AllowToolTip = True
        Me.txtvoucherno.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.txtvoucherno.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtvoucherno.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtvoucherno.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtvoucherno.IsAllowDigits = True
        Me.txtvoucherno.IsAllowSpace = True
        Me.txtvoucherno.IsAllowSplChars = True
        Me.txtvoucherno.LFocusBackColor = System.Drawing.Color.White
        Me.txtvoucherno.Location = New System.Drawing.Point(99, 4)
        Me.txtvoucherno.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtvoucherno.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtvoucherno.MaxLength = 75
        Me.txtvoucherno.Name = "txtvoucherno"
        Me.txtvoucherno.ReadOnly = True
        Me.txtvoucherno.SetToolTip = Nothing
        Me.txtvoucherno.Size = New System.Drawing.Size(100, 20)
        Me.txtvoucherno.SpecialCharList = "&-/@"
        Me.txtvoucherno.TabIndex = 2
        Me.txtvoucherno.UseFunctionKeys = False
        '
        'TxtVoucherDate
        '
        Me.TxtVoucherDate.Location = New System.Drawing.Point(99, 29)
        Me.TxtVoucherDate.Name = "TxtVoucherDate"
        Me.TxtVoucherDate.Size = New System.Drawing.Size(219, 20)
        Me.TxtVoucherDate.TabIndex = 1
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(3, 29)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(34, 13)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "Date"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(3, 7)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(74, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "Voucher No"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnCal)
        Me.Panel2.Controls.Add(Me.TxtPayMethod)
        Me.Panel2.Controls.Add(Me.TxtSalaryMonth)
        Me.Panel2.Controls.Add(Me.ImSlabel4)
        Me.Panel2.Controls.Add(Me.ImSlabel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(546, 26)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(546, 57)
        Me.Panel2.TabIndex = 1
        '
        'BtnCal
        '
        Me.BtnCal.AllowToolTip = True
        Me.BtnCal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCal.Location = New System.Drawing.Point(344, 24)
        Me.BtnCal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCal.Name = "BtnCal"
        Me.BtnCal.SetToolTip = ""
        Me.BtnCal.Size = New System.Drawing.Size(83, 25)
        Me.BtnCal.TabIndex = 3
        Me.BtnCal.Text = "Calculate"
        Me.BtnCal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCal.UseFunctionKeys = False
        Me.BtnCal.UseVisualStyleBackColor = True
        '
        'TxtPayMethod
        '
        Me.TxtPayMethod.AllowEmpty = True
        Me.TxtPayMethod.AllowOnlyListValues = True
        Me.TxtPayMethod.AllowToolTip = True
        Me.TxtPayMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtPayMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtPayMethod.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtPayMethod.FormattingEnabled = True
        Me.TxtPayMethod.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPayMethod.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPayMethod.IsAllowDigits = True
        Me.TxtPayMethod.IsAllowSpace = True
        Me.TxtPayMethod.IsAllowSplChars = True
        Me.TxtPayMethod.IsAllowToolTip = True
        Me.TxtPayMethod.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPayMethod.Location = New System.Drawing.Point(116, 27)
        Me.TxtPayMethod.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPayMethod.Name = "TxtPayMethod"
        Me.TxtPayMethod.SetToolTip = Nothing
        Me.TxtPayMethod.Size = New System.Drawing.Size(222, 21)
        Me.TxtPayMethod.Sorted = True
        Me.TxtPayMethod.SpecialCharList = "&-/@"
        Me.TxtPayMethod.TabIndex = 2
        Me.TxtPayMethod.UseFunctionKeys = False
        '
        'TxtSalaryMonth
        '
        Me.TxtSalaryMonth.Location = New System.Drawing.Point(116, 4)
        Me.TxtSalaryMonth.Name = "TxtSalaryMonth"
        Me.TxtSalaryMonth.Size = New System.Drawing.Size(222, 20)
        Me.TxtSalaryMonth.TabIndex = 1
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(3, 35)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(96, 13)
        Me.ImSlabel4.TabIndex = 0
        Me.ImSlabel4.Text = "PayRoll Method"
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(3, 10)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(86, 13)
        Me.ImSlabel3.TabIndex = 0
        Me.ImSlabel3.Text = "For the Month"
        '
        'TabControl1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TabControl1, 2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 83)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1092, 399)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TxtList)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1084, 373)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "PaySlip Details"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TxtList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.Location = New System.Drawing.Point(3, 3)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.ReadOnly = True
        Me.TxtList.RowHeadersWidth = 30
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.TxtList.Size = New System.Drawing.Size(1078, 367)
        Me.TxtList.TabIndex = 3
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1084, 373)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Payment Details"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.37347!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.62653!))
        Me.TableLayoutPanel3.Controls.Add(Me.TxtAccList, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel5, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TxtpayHeadLedgerList, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1078, 367)
        Me.TableLayoutPanel3.TabIndex = 5
        '
        'TxtAccList
        '
        Me.TxtAccList.AllowUserToAddRows = False
        Me.TxtAccList.AllowUserToResizeRows = False
        Me.TxtAccList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TxtAccList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.TxtAccList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtAccList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tlname, Me.tamt})
        Me.TxtAccList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtAccList.Location = New System.Drawing.Point(489, 0)
        Me.TxtAccList.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtAccList.MultiSelect = False
        Me.TxtAccList.Name = "TxtAccList"
        Me.TxtAccList.RowHeadersWidth = 30
        Me.TxtAccList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtAccList.Size = New System.Drawing.Size(589, 330)
        Me.TxtAccList.TabIndex = 4
        '
        'tlname
        '
        Me.tlname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.tlname.HeaderText = "Pay Ledger  Account"
        Me.tlname.Name = "tlname"
        Me.tlname.ReadOnly = True
        '
        'tamt
        '
        Me.tamt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N" & ErpDecimalPlaces
        DataGridViewCellStyle4.NullValue = Nothing
        Me.tamt.DefaultCellStyle = DataGridViewCellStyle4
        Me.tamt.HeaderText = "Amount"
        Me.tamt.Name = "tamt"
        Me.tamt.Width = 120
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnAddPay)
        Me.Panel4.Controls.Add(Me.TxtpayAmount)
        Me.Panel4.Controls.Add(Me.TxtLedger)
        Me.Panel4.Controls.Add(Me.ImSlabel7)
        Me.Panel4.Controls.Add(Me.ImSlabel6)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(483, 324)
        Me.Panel4.TabIndex = 5
        '
        'btnAddPay
        '
        Me.btnAddPay.AllowToolTip = True
        Me.btnAddPay.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnAddPay.Location = New System.Drawing.Point(130, 83)
        Me.btnAddPay.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnAddPay.Name = "btnAddPay"
        Me.btnAddPay.SetToolTip = ""
        Me.btnAddPay.Size = New System.Drawing.Size(126, 38)
        Me.btnAddPay.TabIndex = 6
        Me.btnAddPay.Text = "ADD"
        Me.btnAddPay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAddPay.UseFunctionKeys = False
        Me.btnAddPay.UseVisualStyleBackColor = True
        '
        'TxtpayAmount
        '
        Me.TxtpayAmount.AllHelpText = True
        Me.TxtpayAmount.AllowDecimal = True
        Me.TxtpayAmount.AllowFormulas = False
        Me.TxtpayAmount.AllowForQty = True
        Me.TxtpayAmount.AllowNegative = False
        Me.TxtpayAmount.AllowPerSign = False
        Me.TxtpayAmount.AllowPlusSign = False
        Me.TxtpayAmount.AllowToolTip = True
        Me.TxtpayAmount.DecimalPlaces = CType(ErpDecimalPlaces, Short)
        Me.TxtpayAmount.ExitOnEscKey = True
        Me.TxtpayAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtpayAmount.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtpayAmount.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtpayAmount.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtpayAmount.HelpText = Nothing
        Me.TxtpayAmount.LFocusBackColor = System.Drawing.Color.White
        Me.TxtpayAmount.Location = New System.Drawing.Point(89, 40)
        Me.TxtpayAmount.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtpayAmount.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtpayAmount.Max = CType(100000000000000, Long)
        Me.TxtpayAmount.MaxLength = 12
        Me.TxtpayAmount.Min = CType(0, Long)
        Me.TxtpayAmount.Name = "TxtpayAmount"
        Me.TxtpayAmount.NextOnEnter = True
        Me.TxtpayAmount.SetToolTip = Nothing
        Me.TxtpayAmount.Size = New System.Drawing.Size(140, 22)
        Me.TxtpayAmount.TabIndex = 5
        Me.TxtpayAmount.Text = "0"
        Me.TxtpayAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtpayAmount.ToolTip = Nothing
        Me.TxtpayAmount.UseFunctionKeys = False
        Me.TxtpayAmount.UseUpDownArrowKeys = False
        '
        'TxtLedger
        '
        Me.TxtLedger.AllowEmpty = True
        Me.TxtLedger.AllowOnlyListValues = True
        Me.TxtLedger.AllowToolTip = True
        Me.TxtLedger.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtLedger.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtLedger.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtLedger.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLedger.FormattingEnabled = True
        Me.TxtLedger.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLedger.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLedger.IsAllowDigits = True
        Me.TxtLedger.IsAllowSpace = True
        Me.TxtLedger.IsAllowSplChars = True
        Me.TxtLedger.IsAllowToolTip = True
        Me.TxtLedger.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLedger.Location = New System.Drawing.Point(89, 13)
        Me.TxtLedger.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLedger.Name = "TxtLedger"
        Me.TxtLedger.SetToolTip = Nothing
        Me.TxtLedger.Size = New System.Drawing.Size(264, 21)
        Me.TxtLedger.Sorted = True
        Me.TxtLedger.SpecialCharList = "&-/@"
        Me.TxtLedger.TabIndex = 4
        Me.TxtLedger.UseFunctionKeys = False
        '
        'ImSlabel7
        '
        Me.ImSlabel7.AutoSize = True
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(3, 43)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(49, 13)
        Me.ImSlabel7.TabIndex = 0
        Me.ImSlabel7.Text = "Amount"
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(3, 13)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(73, 13)
        Me.ImSlabel6.TabIndex = 0
        Me.ImSlabel6.Text = "Payment By"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.TxtTempList)
        Me.Panel5.Controls.Add(Me.ImSlabel8)
        Me.Panel5.Controls.Add(Me.TxtTotalAllocationAmount)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(489, 330)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(589, 37)
        Me.Panel5.TabIndex = 6
        '
        'TxtTempList
        '
        Me.TxtTempList.AllowUserToAddRows = False
        Me.TxtTempList.AllowUserToDeleteRows = False
        Me.TxtTempList.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtTempList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TxtTempList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.TxtTempList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtTempList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtTempList.Location = New System.Drawing.Point(20, 5)
        Me.TxtTempList.MultiSelect = False
        Me.TxtTempList.Name = "TxtTempList"
        Me.TxtTempList.ReadOnly = True
        Me.TxtTempList.RowHeadersWidth = 30
        Me.TxtTempList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.TxtTempList.Size = New System.Drawing.Size(68, 20)
        Me.TxtTempList.TabIndex = 7
        Me.TxtTempList.Visible = False
        '
        'ImSlabel8
        '
        Me.ImSlabel8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel8.AutoSize = True
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(253, 16)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(146, 13)
        Me.ImSlabel8.TabIndex = 0
        Me.ImSlabel8.Text = "Total Allocation Amount:"
        '
        'TxtTotalAllocationAmount
        '
        Me.TxtTotalAllocationAmount.AllowToolTip = True
        Me.TxtTotalAllocationAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotalAllocationAmount.BackColor = System.Drawing.Color.White
        Me.TxtTotalAllocationAmount.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtTotalAllocationAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalAllocationAmount.ForeColor = System.Drawing.Color.Maroon
        Me.TxtTotalAllocationAmount.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTotalAllocationAmount.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTotalAllocationAmount.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtTotalAllocationAmount.IsAllowDigits = True
        Me.TxtTotalAllocationAmount.IsAllowSpace = True
        Me.TxtTotalAllocationAmount.IsAllowSplChars = True
        Me.TxtTotalAllocationAmount.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTotalAllocationAmount.Location = New System.Drawing.Point(417, 5)
        Me.TxtTotalAllocationAmount.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTotalAllocationAmount.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalAllocationAmount.MaxLength = 75
        Me.TxtTotalAllocationAmount.Name = "TxtTotalAllocationAmount"
        Me.TxtTotalAllocationAmount.ReadOnly = True
        Me.TxtTotalAllocationAmount.SetToolTip = Nothing
        Me.TxtTotalAllocationAmount.Size = New System.Drawing.Size(167, 29)
        Me.TxtTotalAllocationAmount.SpecialCharList = "&-/@"
        Me.TxtTotalAllocationAmount.TabIndex = 2
        Me.TxtTotalAllocationAmount.Text = "0"
        Me.TxtTotalAllocationAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTotalAllocationAmount.UseFunctionKeys = False
        '
        'TxtpayHeadLedgerList
        '
        Me.TxtpayHeadLedgerList.AllowUserToAddRows = False
        Me.TxtpayHeadLedgerList.AllowUserToDeleteRows = False
        Me.TxtpayHeadLedgerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtpayHeadLedgerList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tpayname, Me.tledgername})
        Me.TxtpayHeadLedgerList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtpayHeadLedgerList.Location = New System.Drawing.Point(3, 333)
        Me.TxtpayHeadLedgerList.Name = "TxtpayHeadLedgerList"
        Me.TxtpayHeadLedgerList.ReadOnly = True
        Me.TxtpayHeadLedgerList.Size = New System.Drawing.Size(401, 31)
        Me.TxtpayHeadLedgerList.TabIndex = 7
        Me.TxtpayHeadLedgerList.Visible = False
        '
        'tpayname
        '
        Me.tpayname.HeaderText = "Payname"
        Me.tpayname.Name = "tpayname"
        Me.tpayname.ReadOnly = True
        '
        'tledgername
        '
        Me.tledgername.HeaderText = "LedgerName"
        Me.tledgername.Name = "tledgername"
        Me.tledgername.ReadOnly = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TxtNetPaybleTotal)
        Me.Panel3.Controls.Add(Me.ImSlabel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(546, 482)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(546, 39)
        Me.Panel3.TabIndex = 6
        '
        'TxtNetPaybleTotal
        '
        Me.TxtNetPaybleTotal.AllowToolTip = True
        Me.TxtNetPaybleTotal.BackColor = System.Drawing.Color.White
        Me.TxtNetPaybleTotal.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtNetPaybleTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetPaybleTotal.ForeColor = System.Drawing.Color.Maroon
        Me.TxtNetPaybleTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNetPaybleTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNetPaybleTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtNetPaybleTotal.IsAllowDigits = True
        Me.TxtNetPaybleTotal.IsAllowSpace = True
        Me.TxtNetPaybleTotal.IsAllowSplChars = True
        Me.TxtNetPaybleTotal.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNetPaybleTotal.Location = New System.Drawing.Point(277, 1)
        Me.TxtNetPaybleTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNetPaybleTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetPaybleTotal.MaxLength = 75
        Me.TxtNetPaybleTotal.Name = "TxtNetPaybleTotal"
        Me.TxtNetPaybleTotal.ReadOnly = True
        Me.TxtNetPaybleTotal.SetToolTip = Nothing
        Me.TxtNetPaybleTotal.Size = New System.Drawing.Size(167, 29)
        Me.TxtNetPaybleTotal.SpecialCharList = "&-/@"
        Me.TxtNetPaybleTotal.TabIndex = 2
        Me.TxtNetPaybleTotal.Text = "0"
        Me.TxtNetPaybleTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNetPaybleTotal.UseFunctionKeys = False
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(161, 6)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(110, 13)
        Me.ImSlabel5.TabIndex = 0
        Me.ImSlabel5.Text = "Net Total Payble :"
        '
        'txtnarration
        '
        Me.txtnarration.AllowToolTip = True
        Me.txtnarration.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.txtnarration.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtnarration.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtnarration.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtnarration.IsAllowDigits = True
        Me.txtnarration.IsAllowSpace = True
        Me.txtnarration.IsAllowSplChars = True
        Me.txtnarration.LFocusBackColor = System.Drawing.Color.White
        Me.txtnarration.Location = New System.Drawing.Point(3, 485)
        Me.txtnarration.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtnarration.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtnarration.MaxLength = 220
        Me.txtnarration.Multiline = True
        Me.txtnarration.Name = "txtnarration"
        Me.txtnarration.SetToolTip = "Narration"
        Me.txtnarration.Size = New System.Drawing.Size(447, 33)
        Me.txtnarration.SpecialCharList = "&-/@"
        Me.txtnarration.TabIndex = 7
        Me.txtnarration.UseFunctionKeys = False
        '
        'PayrollMultiVoucher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1092, 572)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "PayrollMultiVoucher"
        Me.Text = "Payroll Voucher"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.TxtAccList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.TxtTempList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtpayHeadLedgerList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents txtvoucherno As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtVoucherDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents BtnCal As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtPayMethod As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtSalaryMonth As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TxtAccList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnNew As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnoPEN As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnDelete As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents btnprint As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents btnsave As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TxtNetPaybleTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnAddPay As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtpayAmount As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtLedger As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtTotalAllocationAmount As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents txtnarration As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtpayHeadLedgerList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents tpayname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tledgername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tlname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tamt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtTempList As JyothiPharmaERPSystem3.IMSList
End Class
