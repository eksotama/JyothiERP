<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddMoreDet
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtOtherRef = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtPaymentTerm = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtDdestination = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtDthrough = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtDaddress = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtDTo = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtBTax = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtBaddress = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtBname = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel9 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnCancel = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnOk = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ImsHeadingLabel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(506, 394)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ImsHeadingLabel1
        '
        Me.ImsHeadingLabel1.BackColor = System.Drawing.Color.Green
        Me.ImsHeadingLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsHeadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsHeadingLabel1.ForeColor = System.Drawing.Color.White
        Me.ImsHeadingLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ImsHeadingLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsHeadingLabel1.Name = "ImsHeadingLabel1"
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(506, 25)
        Me.ImsHeadingLabel1.TabIndex = 0
        Me.ImsHeadingLabel1.Text = "BUYERS DETAILS"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtOtherRef)
        Me.Panel1.Controls.Add(Me.TxtPaymentTerm)
        Me.Panel1.Controls.Add(Me.TxtDdestination)
        Me.Panel1.Controls.Add(Me.TxtDthrough)
        Me.Panel1.Controls.Add(Me.TxtDaddress)
        Me.Panel1.Controls.Add(Me.TxtDTo)
        Me.Panel1.Controls.Add(Me.TxtBTax)
        Me.Panel1.Controls.Add(Me.TxtBaddress)
        Me.Panel1.Controls.Add(Me.TxtBname)
        Me.Panel1.Controls.Add(Me.ImSlabel9)
        Me.Panel1.Controls.Add(Me.ImSlabel8)
        Me.Panel1.Controls.Add(Me.ImSlabel7)
        Me.Panel1.Controls.Add(Me.ImSlabel6)
        Me.Panel1.Controls.Add(Me.ImSlabel5)
        Me.Panel1.Controls.Add(Me.ImSlabel4)
        Me.Panel1.Controls.Add(Me.ImSlabel3)
        Me.Panel1.Controls.Add(Me.ImSlabel2)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(500, 310)
        Me.Panel1.TabIndex = 1
        '
        'TxtOtherRef
        '
        Me.TxtOtherRef.AllowToolTip = True
        Me.TxtOtherRef.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtOtherRef.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtOtherRef.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtOtherRef.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtOtherRef.IsAllowDigits = True
        Me.TxtOtherRef.IsAllowSpace = True
        Me.TxtOtherRef.IsAllowSplChars = True
        Me.TxtOtherRef.LFocusBackColor = System.Drawing.Color.White
        Me.TxtOtherRef.Location = New System.Drawing.Point(170, 267)
        Me.TxtOtherRef.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtOtherRef.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtOtherRef.MaxLength = 75
        Me.TxtOtherRef.Name = "TxtOtherRef"
        Me.TxtOtherRef.SetToolTip = Nothing
        Me.TxtOtherRef.Size = New System.Drawing.Size(282, 20)
        Me.TxtOtherRef.SpecialCharList = "&-/@"
        Me.TxtOtherRef.TabIndex = 8
        Me.TxtOtherRef.UseFunctionKeys = False
        '
        'TxtPaymentTerm
        '
        Me.TxtPaymentTerm.AllowToolTip = True
        Me.TxtPaymentTerm.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtPaymentTerm.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPaymentTerm.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPaymentTerm.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtPaymentTerm.IsAllowDigits = True
        Me.TxtPaymentTerm.IsAllowSpace = True
        Me.TxtPaymentTerm.IsAllowSplChars = True
        Me.TxtPaymentTerm.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPaymentTerm.Location = New System.Drawing.Point(170, 239)
        Me.TxtPaymentTerm.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPaymentTerm.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtPaymentTerm.MaxLength = 75
        Me.TxtPaymentTerm.Name = "TxtPaymentTerm"
        Me.TxtPaymentTerm.SetToolTip = Nothing
        Me.TxtPaymentTerm.Size = New System.Drawing.Size(282, 20)
        Me.TxtPaymentTerm.SpecialCharList = "&-/@"
        Me.TxtPaymentTerm.TabIndex = 7
        Me.TxtPaymentTerm.UseFunctionKeys = False
        '
        'TxtDdestination
        '
        Me.TxtDdestination.AllowToolTip = True
        Me.TxtDdestination.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtDdestination.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDdestination.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDdestination.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtDdestination.IsAllowDigits = True
        Me.TxtDdestination.IsAllowSpace = True
        Me.TxtDdestination.IsAllowSplChars = True
        Me.TxtDdestination.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDdestination.Location = New System.Drawing.Point(170, 207)
        Me.TxtDdestination.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDdestination.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtDdestination.MaxLength = 75
        Me.TxtDdestination.Name = "TxtDdestination"
        Me.TxtDdestination.SetToolTip = Nothing
        Me.TxtDdestination.Size = New System.Drawing.Size(282, 20)
        Me.TxtDdestination.SpecialCharList = "&-/@"
        Me.TxtDdestination.TabIndex = 6
        Me.TxtDdestination.UseFunctionKeys = False
        '
        'TxtDthrough
        '
        Me.TxtDthrough.AllowToolTip = True
        Me.TxtDthrough.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtDthrough.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDthrough.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDthrough.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtDthrough.IsAllowDigits = True
        Me.TxtDthrough.IsAllowSpace = True
        Me.TxtDthrough.IsAllowSplChars = True
        Me.TxtDthrough.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDthrough.Location = New System.Drawing.Point(170, 175)
        Me.TxtDthrough.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDthrough.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtDthrough.MaxLength = 75
        Me.TxtDthrough.Name = "TxtDthrough"
        Me.TxtDthrough.SetToolTip = Nothing
        Me.TxtDthrough.Size = New System.Drawing.Size(282, 20)
        Me.TxtDthrough.SpecialCharList = "&-/@"
        Me.TxtDthrough.TabIndex = 5
        Me.TxtDthrough.UseFunctionKeys = False
        '
        'TxtDaddress
        '
        Me.TxtDaddress.AllowToolTip = True
        Me.TxtDaddress.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtDaddress.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDaddress.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDaddress.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtDaddress.IsAllowDigits = True
        Me.TxtDaddress.IsAllowSpace = True
        Me.TxtDaddress.IsAllowSplChars = True
        Me.TxtDaddress.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDaddress.Location = New System.Drawing.Point(170, 143)
        Me.TxtDaddress.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDaddress.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtDaddress.MaxLength = 75
        Me.TxtDaddress.Name = "TxtDaddress"
        Me.TxtDaddress.SetToolTip = Nothing
        Me.TxtDaddress.Size = New System.Drawing.Size(282, 20)
        Me.TxtDaddress.SpecialCharList = "&-/@"
        Me.TxtDaddress.TabIndex = 4
        Me.TxtDaddress.UseFunctionKeys = False
        '
        'TxtDTo
        '
        Me.TxtDTo.AllowToolTip = True
        Me.TxtDTo.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtDTo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDTo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDTo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtDTo.IsAllowDigits = True
        Me.TxtDTo.IsAllowSpace = True
        Me.TxtDTo.IsAllowSplChars = True
        Me.TxtDTo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDTo.Location = New System.Drawing.Point(170, 111)
        Me.TxtDTo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDTo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtDTo.MaxLength = 75
        Me.TxtDTo.Name = "TxtDTo"
        Me.TxtDTo.SetToolTip = Nothing
        Me.TxtDTo.Size = New System.Drawing.Size(282, 20)
        Me.TxtDTo.SpecialCharList = "&-/@"
        Me.TxtDTo.TabIndex = 3
        Me.TxtDTo.UseFunctionKeys = False
        '
        'TxtBTax
        '
        Me.TxtBTax.AllowToolTip = True
        Me.TxtBTax.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtBTax.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtBTax.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtBTax.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtBTax.IsAllowDigits = True
        Me.TxtBTax.IsAllowSpace = True
        Me.TxtBTax.IsAllowSplChars = True
        Me.TxtBTax.LFocusBackColor = System.Drawing.Color.White
        Me.TxtBTax.Location = New System.Drawing.Point(170, 79)
        Me.TxtBTax.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtBTax.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtBTax.MaxLength = 75
        Me.TxtBTax.Name = "TxtBTax"
        Me.TxtBTax.SetToolTip = Nothing
        Me.TxtBTax.Size = New System.Drawing.Size(282, 20)
        Me.TxtBTax.SpecialCharList = "&-/@"
        Me.TxtBTax.TabIndex = 2
        Me.TxtBTax.UseFunctionKeys = False
        '
        'TxtBaddress
        '
        Me.TxtBaddress.AllowToolTip = True
        Me.TxtBaddress.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtBaddress.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtBaddress.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtBaddress.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtBaddress.IsAllowDigits = True
        Me.TxtBaddress.IsAllowSpace = True
        Me.TxtBaddress.IsAllowSplChars = True
        Me.TxtBaddress.LFocusBackColor = System.Drawing.Color.White
        Me.TxtBaddress.Location = New System.Drawing.Point(170, 43)
        Me.TxtBaddress.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtBaddress.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtBaddress.MaxLength = 75
        Me.TxtBaddress.Name = "TxtBaddress"
        Me.TxtBaddress.SetToolTip = Nothing
        Me.TxtBaddress.Size = New System.Drawing.Size(282, 20)
        Me.TxtBaddress.SpecialCharList = "&-/@"
        Me.TxtBaddress.TabIndex = 1
        Me.TxtBaddress.UseFunctionKeys = False
        '
        'TxtBname
        '
        Me.TxtBname.AllowToolTip = True
        Me.TxtBname.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtBname.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtBname.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtBname.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtBname.IsAllowDigits = True
        Me.TxtBname.IsAllowSpace = True
        Me.TxtBname.IsAllowSplChars = True
        Me.TxtBname.LFocusBackColor = System.Drawing.Color.White
        Me.TxtBname.Location = New System.Drawing.Point(170, 15)
        Me.TxtBname.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtBname.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtBname.MaxLength = 75
        Me.TxtBname.Name = "TxtBname"
        Me.TxtBname.SetToolTip = Nothing
        Me.TxtBname.Size = New System.Drawing.Size(282, 20)
        Me.TxtBname.SpecialCharList = "&-/@"
        Me.TxtBname.TabIndex = 0
        Me.TxtBname.UseFunctionKeys = False
        '
        'ImSlabel9
        '
        Me.ImSlabel9.AutoSize = True
        Me.ImSlabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel9.Location = New System.Drawing.Point(21, 274)
        Me.ImSlabel9.Name = "ImSlabel9"
        Me.ImSlabel9.Size = New System.Drawing.Size(107, 13)
        Me.ImSlabel9.TabIndex = 0
        Me.ImSlabel9.Text = "Other References"
        '
        'ImSlabel8
        '
        Me.ImSlabel8.AutoSize = True
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(21, 242)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(87, 13)
        Me.ImSlabel8.TabIndex = 0
        Me.ImSlabel8.Text = "Payment Term"
        '
        'ImSlabel7
        '
        Me.ImSlabel7.AutoSize = True
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(20, 210)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(71, 13)
        Me.ImSlabel7.TabIndex = 0
        Me.ImSlabel7.Text = "Destination"
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(20, 178)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(112, 13)
        Me.ImSlabel6.TabIndex = 0
        Me.ImSlabel6.Text = "Despatch Through"
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(20, 146)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(110, 13)
        Me.ImSlabel5.TabIndex = 0
        Me.ImSlabel5.Text = "Despatch Address"
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(20, 114)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(80, 13)
        Me.ImSlabel4.TabIndex = 0
        Me.ImSlabel4.Text = "Despatch To"
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(20, 82)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(131, 13)
        Me.ImSlabel3.TabIndex = 0
        Me.ImSlabel3.Text = "Buyer Tax Information"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(20, 50)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(88, 13)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "Buyer Address"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(20, 18)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(75, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "Buyer Name"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnCancel)
        Me.Panel2.Controls.Add(Me.BtnOk)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 341)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(506, 53)
        Me.Panel2.TabIndex = 2
        '
        'BtnCancel
        '
        Me.BtnCancel.AllowToolTip = True
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCancel.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnCancel.Location = New System.Drawing.Point(58, 4)
        Me.BtnCancel.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.SetToolTip = ""
        Me.BtnCancel.Size = New System.Drawing.Size(139, 43)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseFunctionKeys = False
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnOk
        '
        Me.BtnOk.AllowToolTip = True
        Me.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOk.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnOk.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.success32
        Me.BtnOk.Location = New System.Drawing.Point(294, 4)
        Me.BtnOk.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.SetToolTip = ""
        Me.BtnOk.Size = New System.Drawing.Size(139, 43)
        Me.BtnOk.TabIndex = 0
        Me.BtnOk.Text = "OK"
        Me.BtnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnOk.UseFunctionKeys = False
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'AddMoreDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(506, 394)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddMoreDet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "More Details"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtOtherRef As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtPaymentTerm As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtDdestination As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtDthrough As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtDaddress As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtDTo As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtBTax As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtBaddress As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtBname As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel9 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnCancel As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnOk As JyothiPharmaERPSystem3.IMSButton

End Class
