<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PosSettingfrm
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
        Me.TxtNewAfterSave = New System.Windows.Forms.ComboBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxPaymentMethod = New System.Windows.Forms.ComboBox()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtPrintAfterSave = New System.Windows.Forms.ComboBox()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtPrinterName = New System.Windows.Forms.ComboBox()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtPrintDialog = New System.Windows.Forms.ComboBox()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtAllowPrice = New System.Windows.Forms.ComboBox()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Txtzerotax = New System.Windows.Forms.ComboBox()
        Me.ImSlabel9 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtChangeDiscount = New System.Windows.Forms.ComboBox()
        Me.ImSlabel10 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtNewItem = New System.Windows.Forms.ComboBox()
        Me.ImSlabel11 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtPriceListName = New System.Windows.Forms.ComboBox()
        Me.ImSlabel12 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Txtshowkeyboard = New System.Windows.Forms.ComboBox()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.TxtNoOfCopies = New System.Windows.Forms.NumericUpDown()
        Me.ImSlabel13 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtAllowtoChangeDate = New System.Windows.Forms.ComboBox()
        Me.ImSlabel14 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtAllowCreditSales = New System.Windows.Forms.ComboBox()
        Me.ImSlabel15 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtAllowCurrencies = New System.Windows.Forms.ComboBox()
        Me.ImSlabel16 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtGridView = New System.Windows.Forms.ComboBox()
        Me.ImSlabel17 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtDefCash = New System.Windows.Forms.ComboBox()
        Me.ImSlabel18 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtDefCreditCard = New System.Windows.Forms.ComboBox()
        Me.ImSlabel19 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtDefCheque = New System.Windows.Forms.ComboBox()
        Me.ImSlabel20 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtDefGift = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.TxtNoOfCopies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtNewAfterSave
        '
        Me.TxtNewAfterSave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtNewAfterSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TxtNewAfterSave.FormattingEnabled = True
        Me.TxtNewAfterSave.Items.AddRange(New Object() {"YES", "NO"})
        Me.TxtNewAfterSave.Location = New System.Drawing.Point(185, 32)
        Me.TxtNewAfterSave.Name = "TxtNewAfterSave"
        Me.TxtNewAfterSave.Size = New System.Drawing.Size(68, 21)
        Me.TxtNewAfterSave.TabIndex = 0
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(12, 36)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(126, 13)
        Me.ImSlabel1.TabIndex = 1
        Me.ImSlabel1.Text = "New Invoice After Save?"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(12, 64)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(126, 13)
        Me.ImSlabel2.TabIndex = 1
        Me.ImSlabel2.Text = "Allow Payment Methods?"
        '
        'TxPaymentMethod
        '
        Me.TxPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxPaymentMethod.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TxPaymentMethod.FormattingEnabled = True
        Me.TxPaymentMethod.Items.AddRange(New Object() {"YES", "NO"})
        Me.TxPaymentMethod.Location = New System.Drawing.Point(185, 60)
        Me.TxPaymentMethod.Name = "TxPaymentMethod"
        Me.TxPaymentMethod.Size = New System.Drawing.Size(68, 21)
        Me.TxPaymentMethod.TabIndex = 1
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(12, 92)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(87, 13)
        Me.ImSlabel3.TabIndex = 1
        Me.ImSlabel3.Text = "Print After Save?"
        '
        'TxtPrintAfterSave
        '
        Me.TxtPrintAfterSave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtPrintAfterSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TxtPrintAfterSave.FormattingEnabled = True
        Me.TxtPrintAfterSave.Items.AddRange(New Object() {"YES", "NO"})
        Me.TxtPrintAfterSave.Location = New System.Drawing.Point(185, 88)
        Me.TxtPrintAfterSave.Name = "TxtPrintAfterSave"
        Me.TxtPrintAfterSave.Size = New System.Drawing.Size(68, 21)
        Me.TxtPrintAfterSave.TabIndex = 2
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(327, 148)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(105, 13)
        Me.ImSlabel4.TabIndex = 1
        Me.ImSlabel4.Text = "Default Printer Name"
        '
        'TxtPrinterName
        '
        Me.TxtPrinterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtPrinterName.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TxtPrinterName.FormattingEnabled = True
        Me.TxtPrinterName.Items.AddRange(New Object() {"YES", "NO"})
        Me.TxtPrinterName.Location = New System.Drawing.Point(511, 144)
        Me.TxtPrinterName.Name = "TxtPrinterName"
        Me.TxtPrinterName.Size = New System.Drawing.Size(224, 21)
        Me.TxtPrinterName.TabIndex = 14
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(12, 120)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(110, 13)
        Me.ImSlabel5.TabIndex = 1
        Me.ImSlabel5.Text = "Direct Print to Printer?"
        '
        'TxtPrintDialog
        '
        Me.TxtPrintDialog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtPrintDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TxtPrintDialog.FormattingEnabled = True
        Me.TxtPrintDialog.Items.AddRange(New Object() {"YES", "NO"})
        Me.TxtPrintDialog.Location = New System.Drawing.Point(185, 116)
        Me.TxtPrintDialog.Name = "TxtPrintDialog"
        Me.TxtPrintDialog.Size = New System.Drawing.Size(68, 21)
        Me.TxtPrintDialog.TabIndex = 3
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(12, 148)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(94, 13)
        Me.ImSlabel6.TabIndex = 1
        Me.ImSlabel6.Text = "No Of Print Copies"
        '
        'ImSlabel7
        '
        Me.ImSlabel7.AutoSize = True
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(12, 175)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(142, 13)
        Me.ImSlabel7.TabIndex = 1
        Me.ImSlabel7.Text = "Allow User to Change Price?"
        '
        'TxtAllowPrice
        '
        Me.TxtAllowPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtAllowPrice.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TxtAllowPrice.FormattingEnabled = True
        Me.TxtAllowPrice.Items.AddRange(New Object() {"YES", "NO"})
        Me.TxtAllowPrice.Location = New System.Drawing.Point(185, 171)
        Me.TxtAllowPrice.Name = "TxtAllowPrice"
        Me.TxtAllowPrice.Size = New System.Drawing.Size(68, 21)
        Me.TxtAllowPrice.TabIndex = 5
        '
        'ImSlabel8
        '
        Me.ImSlabel8.AutoSize = True
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(12, 259)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(81, 13)
        Me.ImSlabel8.TabIndex = 1
        Me.ImSlabel8.Text = "Zero Tax POS?"
        '
        'Txtzerotax
        '
        Me.Txtzerotax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Txtzerotax.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Txtzerotax.FormattingEnabled = True
        Me.Txtzerotax.Items.AddRange(New Object() {"YES", "NO"})
        Me.Txtzerotax.Location = New System.Drawing.Point(185, 255)
        Me.Txtzerotax.Name = "Txtzerotax"
        Me.Txtzerotax.Size = New System.Drawing.Size(68, 21)
        Me.Txtzerotax.TabIndex = 8
        '
        'ImSlabel9
        '
        Me.ImSlabel9.AutoSize = True
        Me.ImSlabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel9.Location = New System.Drawing.Point(12, 203)
        Me.ImSlabel9.Name = "ImSlabel9"
        Me.ImSlabel9.Size = New System.Drawing.Size(160, 13)
        Me.ImSlabel9.TabIndex = 1
        Me.ImSlabel9.Text = "Allow User to Change Discount?"
        '
        'TxtChangeDiscount
        '
        Me.TxtChangeDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtChangeDiscount.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TxtChangeDiscount.FormattingEnabled = True
        Me.TxtChangeDiscount.Items.AddRange(New Object() {"YES", "NO"})
        Me.TxtChangeDiscount.Location = New System.Drawing.Point(185, 199)
        Me.TxtChangeDiscount.Name = "TxtChangeDiscount"
        Me.TxtChangeDiscount.Size = New System.Drawing.Size(68, 21)
        Me.TxtChangeDiscount.TabIndex = 6
        '
        'ImSlabel10
        '
        Me.ImSlabel10.AutoSize = True
        Me.ImSlabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel10.Location = New System.Drawing.Point(12, 231)
        Me.ImSlabel10.Name = "ImSlabel10"
        Me.ImSlabel10.Size = New System.Drawing.Size(157, 13)
        Me.ImSlabel10.TabIndex = 1
        Me.ImSlabel10.Text = "Allow User to Create New Item?"
        '
        'TxtNewItem
        '
        Me.TxtNewItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtNewItem.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TxtNewItem.FormattingEnabled = True
        Me.TxtNewItem.Items.AddRange(New Object() {"YES", "NO"})
        Me.TxtNewItem.Location = New System.Drawing.Point(185, 227)
        Me.TxtNewItem.Name = "TxtNewItem"
        Me.TxtNewItem.Size = New System.Drawing.Size(68, 21)
        Me.TxtNewItem.TabIndex = 7
        '
        'ImSlabel11
        '
        Me.ImSlabel11.AutoSize = True
        Me.ImSlabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel11.Location = New System.Drawing.Point(327, 175)
        Me.ImSlabel11.Name = "ImSlabel11"
        Me.ImSlabel11.Size = New System.Drawing.Size(118, 13)
        Me.ImSlabel11.TabIndex = 1
        Me.ImSlabel11.Text = "Default Price List Name"
        '
        'TxtPriceListName
        '
        Me.TxtPriceListName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtPriceListName.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TxtPriceListName.FormattingEnabled = True
        Me.TxtPriceListName.Items.AddRange(New Object() {"YES", "NO"})
        Me.TxtPriceListName.Location = New System.Drawing.Point(511, 171)
        Me.TxtPriceListName.Name = "TxtPriceListName"
        Me.TxtPriceListName.Size = New System.Drawing.Size(224, 21)
        Me.TxtPriceListName.TabIndex = 15
        '
        'ImSlabel12
        '
        Me.ImSlabel12.AutoSize = True
        Me.ImSlabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel12.Location = New System.Drawing.Point(12, 287)
        Me.ImSlabel12.Name = "ImSlabel12"
        Me.ImSlabel12.Size = New System.Drawing.Size(142, 13)
        Me.ImSlabel12.TabIndex = 1
        Me.ImSlabel12.Text = "Show On Screen Keyboard?"
        '
        'Txtshowkeyboard
        '
        Me.Txtshowkeyboard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Txtshowkeyboard.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Txtshowkeyboard.FormattingEnabled = True
        Me.Txtshowkeyboard.Items.AddRange(New Object() {"YES", "NO"})
        Me.Txtshowkeyboard.Location = New System.Drawing.Point(185, 283)
        Me.Txtshowkeyboard.Name = "Txtshowkeyboard"
        Me.Txtshowkeyboard.Size = New System.Drawing.Size(68, 21)
        Me.Txtshowkeyboard.TabIndex = 9
        '
        'BtnCancel
        '
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnCancel.Location = New System.Drawing.Point(126, 355)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(164, 43)
        Me.BtnCancel.TabIndex = 21
        Me.BtnCancel.Text = "&Close"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.Save__1_
        Me.BtnSave.Location = New System.Drawing.Point(432, 355)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(171, 43)
        Me.BtnSave.TabIndex = 20
        Me.BtnSave.Text = "&Save Changes"
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'ImsHeadingLabel1
        '
        Me.ImsHeadingLabel1.BackColor = System.Drawing.Color.Green
        Me.ImsHeadingLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ImsHeadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsHeadingLabel1.ForeColor = System.Drawing.Color.White
        Me.ImsHeadingLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ImsHeadingLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsHeadingLabel1.Name = "ImsHeadingLabel1"
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(789, 25)
        Me.ImsHeadingLabel1.TabIndex = 32
        Me.ImsHeadingLabel1.Text = "POS SETTINGS"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtNoOfCopies
        '
        Me.TxtNoOfCopies.Location = New System.Drawing.Point(185, 144)
        Me.TxtNoOfCopies.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.TxtNoOfCopies.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtNoOfCopies.Name = "TxtNoOfCopies"
        Me.TxtNoOfCopies.Size = New System.Drawing.Size(68, 20)
        Me.TxtNoOfCopies.TabIndex = 4
        Me.TxtNoOfCopies.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ImSlabel13
        '
        Me.ImSlabel13.AutoSize = True
        Me.ImSlabel13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel13.Location = New System.Drawing.Point(327, 36)
        Me.ImSlabel13.Name = "ImSlabel13"
        Me.ImSlabel13.Size = New System.Drawing.Size(126, 13)
        Me.ImSlabel13.TabIndex = 1
        Me.ImSlabel13.Text = "Is Allow to change Date?"
        '
        'TxtAllowtoChangeDate
        '
        Me.TxtAllowtoChangeDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtAllowtoChangeDate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TxtAllowtoChangeDate.FormattingEnabled = True
        Me.TxtAllowtoChangeDate.Items.AddRange(New Object() {"YES", "NO"})
        Me.TxtAllowtoChangeDate.Location = New System.Drawing.Point(511, 32)
        Me.TxtAllowtoChangeDate.Name = "TxtAllowtoChangeDate"
        Me.TxtAllowtoChangeDate.Size = New System.Drawing.Size(69, 21)
        Me.TxtAllowtoChangeDate.TabIndex = 10
        '
        'ImSlabel14
        '
        Me.ImSlabel14.AutoSize = True
        Me.ImSlabel14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel14.Location = New System.Drawing.Point(327, 64)
        Me.ImSlabel14.Name = "ImSlabel14"
        Me.ImSlabel14.Size = New System.Drawing.Size(120, 13)
        Me.ImSlabel14.TabIndex = 1
        Me.ImSlabel14.Text = "Allow Credit Sales Also?"
        '
        'TxtAllowCreditSales
        '
        Me.TxtAllowCreditSales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtAllowCreditSales.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TxtAllowCreditSales.FormattingEnabled = True
        Me.TxtAllowCreditSales.Items.AddRange(New Object() {"YES", "NO"})
        Me.TxtAllowCreditSales.Location = New System.Drawing.Point(511, 60)
        Me.TxtAllowCreditSales.Name = "TxtAllowCreditSales"
        Me.TxtAllowCreditSales.Size = New System.Drawing.Size(69, 21)
        Me.TxtAllowCreditSales.TabIndex = 11
        '
        'ImSlabel15
        '
        Me.ImSlabel15.AutoSize = True
        Me.ImSlabel15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel15.Location = New System.Drawing.Point(327, 92)
        Me.ImSlabel15.Name = "ImSlabel15"
        Me.ImSlabel15.Size = New System.Drawing.Size(130, 13)
        Me.ImSlabel15.TabIndex = 1
        Me.ImSlabel15.Text = "Allow Multiple Currencies?"
        Me.ImSlabel15.Visible = False
        '
        'TxtAllowCurrencies
        '
        Me.TxtAllowCurrencies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtAllowCurrencies.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TxtAllowCurrencies.FormattingEnabled = True
        Me.TxtAllowCurrencies.Items.AddRange(New Object() {"YES", "NO"})
        Me.TxtAllowCurrencies.Location = New System.Drawing.Point(511, 88)
        Me.TxtAllowCurrencies.Name = "TxtAllowCurrencies"
        Me.TxtAllowCurrencies.Size = New System.Drawing.Size(69, 21)
        Me.TxtAllowCurrencies.TabIndex = 12
        Me.TxtAllowCurrencies.Visible = False
        '
        'ImSlabel16
        '
        Me.ImSlabel16.AutoSize = True
        Me.ImSlabel16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel16.Location = New System.Drawing.Point(327, 120)
        Me.ImSlabel16.Name = "ImSlabel16"
        Me.ImSlabel16.Size = New System.Drawing.Size(129, 13)
        Me.ImSlabel16.TabIndex = 1
        Me.ImSlabel16.Text = "Show Items as Grid view?"
        Me.ImSlabel16.Visible = False
        '
        'TxtGridView
        '
        Me.TxtGridView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtGridView.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TxtGridView.FormattingEnabled = True
        Me.TxtGridView.Items.AddRange(New Object() {"YES", "NO"})
        Me.TxtGridView.Location = New System.Drawing.Point(511, 116)
        Me.TxtGridView.Name = "TxtGridView"
        Me.TxtGridView.Size = New System.Drawing.Size(69, 21)
        Me.TxtGridView.TabIndex = 13
        Me.TxtGridView.Visible = False
        '
        'ImSlabel17
        '
        Me.ImSlabel17.AutoSize = True
        Me.ImSlabel17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel17.Location = New System.Drawing.Point(327, 203)
        Me.ImSlabel17.Name = "ImSlabel17"
        Me.ImSlabel17.Size = New System.Drawing.Size(125, 13)
        Me.ImSlabel17.TabIndex = 1
        Me.ImSlabel17.Text = "Default Cash Ledger A/c"
        '
        'TxtDefCash
        '
        Me.TxtDefCash.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtDefCash.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TxtDefCash.FormattingEnabled = True
        Me.TxtDefCash.Items.AddRange(New Object() {"YES", "NO"})
        Me.TxtDefCash.Location = New System.Drawing.Point(511, 199)
        Me.TxtDefCash.Name = "TxtDefCash"
        Me.TxtDefCash.Size = New System.Drawing.Size(224, 21)
        Me.TxtDefCash.TabIndex = 16
        '
        'ImSlabel18
        '
        Me.ImSlabel18.AutoSize = True
        Me.ImSlabel18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel18.Location = New System.Drawing.Point(327, 231)
        Me.ImSlabel18.Name = "ImSlabel18"
        Me.ImSlabel18.Size = New System.Drawing.Size(181, 13)
        Me.ImSlabel18.TabIndex = 1
        Me.ImSlabel18.Text = "Default Credit Bank Card Ledger A/c"
        '
        'TxtDefCreditCard
        '
        Me.TxtDefCreditCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtDefCreditCard.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TxtDefCreditCard.FormattingEnabled = True
        Me.TxtDefCreditCard.Items.AddRange(New Object() {"YES", "NO"})
        Me.TxtDefCreditCard.Location = New System.Drawing.Point(511, 227)
        Me.TxtDefCreditCard.Name = "TxtDefCreditCard"
        Me.TxtDefCreditCard.Size = New System.Drawing.Size(224, 21)
        Me.TxtDefCreditCard.TabIndex = 17
        '
        'ImSlabel19
        '
        Me.ImSlabel19.AutoSize = True
        Me.ImSlabel19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel19.Location = New System.Drawing.Point(327, 259)
        Me.ImSlabel19.Name = "ImSlabel19"
        Me.ImSlabel19.Size = New System.Drawing.Size(166, 13)
        Me.ImSlabel19.TabIndex = 1
        Me.ImSlabel19.Text = "Default Cheque Bank Ledger A/c"
        '
        'TxtDefCheque
        '
        Me.TxtDefCheque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtDefCheque.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TxtDefCheque.FormattingEnabled = True
        Me.TxtDefCheque.Items.AddRange(New Object() {"YES", "NO"})
        Me.TxtDefCheque.Location = New System.Drawing.Point(511, 255)
        Me.TxtDefCheque.Name = "TxtDefCheque"
        Me.TxtDefCheque.Size = New System.Drawing.Size(224, 21)
        Me.TxtDefCheque.TabIndex = 18
        '
        'ImSlabel20
        '
        Me.ImSlabel20.AutoSize = True
        Me.ImSlabel20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel20.Location = New System.Drawing.Point(327, 287)
        Me.ImSlabel20.Name = "ImSlabel20"
        Me.ImSlabel20.Size = New System.Drawing.Size(142, 13)
        Me.ImSlabel20.TabIndex = 1
        Me.ImSlabel20.Text = "Default Gift Card Ledger A/c"
        '
        'TxtDefGift
        '
        Me.TxtDefGift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtDefGift.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TxtDefGift.FormattingEnabled = True
        Me.TxtDefGift.Items.AddRange(New Object() {"YES", "NO"})
        Me.TxtDefGift.Location = New System.Drawing.Point(511, 283)
        Me.TxtDefGift.Name = "TxtDefGift"
        Me.TxtDefGift.Size = New System.Drawing.Size(224, 21)
        Me.TxtDefGift.TabIndex = 19
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(610, 305)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 33)
        Me.Button1.TabIndex = 33
        Me.Button1.Text = "Create Ledgers"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PosSettingfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 421)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TxtNoOfCopies)
        Me.Controls.Add(Me.ImsHeadingLabel1)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.TxtDefGift)
        Me.Controls.Add(Me.ImSlabel20)
        Me.Controls.Add(Me.TxtDefCheque)
        Me.Controls.Add(Me.ImSlabel19)
        Me.Controls.Add(Me.TxtDefCreditCard)
        Me.Controls.Add(Me.ImSlabel18)
        Me.Controls.Add(Me.TxtDefCash)
        Me.Controls.Add(Me.ImSlabel17)
        Me.Controls.Add(Me.TxtGridView)
        Me.Controls.Add(Me.ImSlabel16)
        Me.Controls.Add(Me.TxtAllowCurrencies)
        Me.Controls.Add(Me.ImSlabel15)
        Me.Controls.Add(Me.TxtAllowCreditSales)
        Me.Controls.Add(Me.ImSlabel14)
        Me.Controls.Add(Me.TxtAllowtoChangeDate)
        Me.Controls.Add(Me.ImSlabel13)
        Me.Controls.Add(Me.Txtshowkeyboard)
        Me.Controls.Add(Me.ImSlabel12)
        Me.Controls.Add(Me.Txtzerotax)
        Me.Controls.Add(Me.ImSlabel8)
        Me.Controls.Add(Me.TxtPrinterName)
        Me.Controls.Add(Me.TxtPriceListName)
        Me.Controls.Add(Me.TxtNewItem)
        Me.Controls.Add(Me.ImSlabel11)
        Me.Controls.Add(Me.TxtChangeDiscount)
        Me.Controls.Add(Me.ImSlabel10)
        Me.Controls.Add(Me.TxtAllowPrice)
        Me.Controls.Add(Me.ImSlabel9)
        Me.Controls.Add(Me.ImSlabel4)
        Me.Controls.Add(Me.ImSlabel7)
        Me.Controls.Add(Me.TxtPrintAfterSave)
        Me.Controls.Add(Me.ImSlabel3)
        Me.Controls.Add(Me.ImSlabel6)
        Me.Controls.Add(Me.TxPaymentMethod)
        Me.Controls.Add(Me.TxtPrintDialog)
        Me.Controls.Add(Me.ImSlabel2)
        Me.Controls.Add(Me.ImSlabel5)
        Me.Controls.Add(Me.TxtNewAfterSave)
        Me.Controls.Add(Me.ImSlabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PosSettingfrm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "POS Settings"
        CType(Me.TxtNoOfCopies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtNewAfterSave As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxPaymentMethod As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtPrintAfterSave As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtPrinterName As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtPrintDialog As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtAllowPrice As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Txtzerotax As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel9 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtChangeDiscount As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel10 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtNewItem As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel11 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtPriceListName As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel12 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Txtshowkeyboard As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents TxtNoOfCopies As System.Windows.Forms.NumericUpDown
    Friend WithEvents ImSlabel13 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtAllowtoChangeDate As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel14 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtAllowCreditSales As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel15 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtAllowCurrencies As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel16 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtGridView As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel17 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtDefCash As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel18 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtDefCreditCard As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel19 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtDefCheque As System.Windows.Forms.ComboBox
    Friend WithEvents ImSlabel20 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtDefGift As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
