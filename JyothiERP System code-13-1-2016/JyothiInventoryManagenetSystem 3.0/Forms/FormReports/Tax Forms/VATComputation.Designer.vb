<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VATComputation
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtVATRefund = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtDrTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.lblVATRefund = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtCrTotals = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtoutList = New JyothiPharmaERPSystem3.IMSList()
        Me.todetails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toamt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtInList = New JyothiPharmaERPSystem3.IMSList()
        Me.tidetails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tiamt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.titax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtVATPayble = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.lblVATPayble = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtHeading = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnPrint = New JyothiPharmaERPSystem3.IMSButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtEndDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtStartDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.ImSlabel9 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel3.SuspendLayout()
        CType(Me.TxtoutList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtInList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TxtVATRefund)
        Me.Panel3.Controls.Add(Me.TxtDrTotal)
        Me.Panel3.Controls.Add(Me.lblVATRefund)
        Me.Panel3.Controls.Add(Me.ImSlabel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 336)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(448, 43)
        Me.Panel3.TabIndex = 7
        '
        'TxtVATRefund
        '
        Me.TxtVATRefund.AllowToolTip = True
        Me.TxtVATRefund.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtVATRefund.BackColor = System.Drawing.Color.White
        Me.TxtVATRefund.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtVATRefund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVATRefund.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtVATRefund.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtVATRefund.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtVATRefund.IsAllowDigits = True
        Me.TxtVATRefund.IsAllowSpace = True
        Me.TxtVATRefund.IsAllowSplChars = True
        Me.TxtVATRefund.LFocusBackColor = System.Drawing.Color.White
        Me.TxtVATRefund.Location = New System.Drawing.Point(315, 23)
        Me.TxtVATRefund.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtVATRefund.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtVATRefund.MaxLength = 75
        Me.TxtVATRefund.Name = "TxtVATRefund"
        Me.TxtVATRefund.ReadOnly = True
        Me.TxtVATRefund.SetToolTip = Nothing
        Me.TxtVATRefund.Size = New System.Drawing.Size(133, 20)
        Me.TxtVATRefund.SpecialCharList = "&-/@"
        Me.TxtVATRefund.TabIndex = 18
        Me.TxtVATRefund.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtVATRefund.UseFunctionKeys = False
        Me.TxtVATRefund.Visible = False
        '
        'TxtDrTotal
        '
        Me.TxtDrTotal.AllowToolTip = True
        Me.TxtDrTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDrTotal.BackColor = System.Drawing.Color.White
        Me.TxtDrTotal.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtDrTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDrTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDrTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDrTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtDrTotal.IsAllowDigits = True
        Me.TxtDrTotal.IsAllowSpace = True
        Me.TxtDrTotal.IsAllowSplChars = True
        Me.TxtDrTotal.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDrTotal.Location = New System.Drawing.Point(315, 1)
        Me.TxtDrTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDrTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtDrTotal.MaxLength = 75
        Me.TxtDrTotal.Name = "TxtDrTotal"
        Me.TxtDrTotal.ReadOnly = True
        Me.TxtDrTotal.SetToolTip = Nothing
        Me.TxtDrTotal.Size = New System.Drawing.Size(133, 20)
        Me.TxtDrTotal.SpecialCharList = "&-/@"
        Me.TxtDrTotal.TabIndex = 18
        Me.TxtDrTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtDrTotal.UseFunctionKeys = False
        '
        'lblVATRefund
        '
        Me.lblVATRefund.AutoSize = True
        Me.lblVATRefund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVATRefund.Location = New System.Drawing.Point(12, 26)
        Me.lblVATRefund.Name = "lblVATRefund"
        Me.lblVATRefund.Size = New System.Drawing.Size(100, 13)
        Me.lblVATRefund.TabIndex = 16
        Me.lblVATRefund.Text = "VAT Refundable"
        Me.lblVATRefund.Visible = False
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(12, 3)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(42, 13)
        Me.ImSlabel5.TabIndex = 16
        Me.ImSlabel5.Text = "Totals"
        '
        'TxtCrTotals
        '
        Me.TxtCrTotals.AllowToolTip = True
        Me.TxtCrTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCrTotals.BackColor = System.Drawing.Color.White
        Me.TxtCrTotals.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtCrTotals.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCrTotals.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCrTotals.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCrTotals.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtCrTotals.IsAllowDigits = True
        Me.TxtCrTotals.IsAllowSpace = True
        Me.TxtCrTotals.IsAllowSplChars = True
        Me.TxtCrTotals.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCrTotals.Location = New System.Drawing.Point(313, 1)
        Me.TxtCrTotals.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCrTotals.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtCrTotals.MaxLength = 75
        Me.TxtCrTotals.Name = "TxtCrTotals"
        Me.TxtCrTotals.ReadOnly = True
        Me.TxtCrTotals.SetToolTip = Nothing
        Me.TxtCrTotals.Size = New System.Drawing.Size(133, 20)
        Me.TxtCrTotals.SpecialCharList = "&-/@"
        Me.TxtCrTotals.TabIndex = 21
        Me.TxtCrTotals.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtCrTotals.UseFunctionKeys = False
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(12, 3)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(42, 13)
        Me.ImSlabel6.TabIndex = 16
        Me.ImSlabel6.Text = "Totals"
        '
        'TxtoutList
        '
        Me.TxtoutList.AllowUserToAddRows = False
        Me.TxtoutList.AllowUserToDeleteRows = False
        Me.TxtoutList.AllowUserToOrderColumns = True
        Me.TxtoutList.AllowUserToResizeColumns = False
        Me.TxtoutList.AllowUserToResizeRows = False
        Me.TxtoutList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtoutList.BackgroundColor = System.Drawing.Color.White
        Me.TxtoutList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.TxtoutList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtoutList.ColumnHeadersVisible = False
        Me.TxtoutList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.todetails, Me.toamt, Me.totax})
        Me.TxtoutList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtoutList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtoutList.GridColor = System.Drawing.Color.White
        Me.TxtoutList.Location = New System.Drawing.Point(0, 30)
        Me.TxtoutList.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtoutList.MultiSelect = False
        Me.TxtoutList.Name = "TxtoutList"
        Me.TxtoutList.RowHeadersVisible = False
        Me.TxtoutList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtoutList.Size = New System.Drawing.Size(448, 306)
        Me.TxtoutList.TabIndex = 0
        '
        'todetails
        '
        Me.todetails.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.todetails.HeaderText = "Column1"
        Me.todetails.Name = "todetails"
        '
        'toamt
        '
        Me.toamt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N" & ErpDecimalPlaces
        DataGridViewCellStyle1.NullValue = Nothing
        Me.toamt.DefaultCellStyle = DataGridViewCellStyle1
        Me.toamt.HeaderText = "Column1"
        Me.toamt.Name = "toamt"
        '
        'totax
        '
        Me.totax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N" & ErpDecimalPlaces
        DataGridViewCellStyle2.NullValue = Nothing
        Me.totax.DefaultCellStyle = DataGridViewCellStyle2
        Me.totax.HeaderText = "Column1"
        Me.totax.Name = "totax"
        '
        'TxtInList
        '
        Me.TxtInList.AllowUserToAddRows = False
        Me.TxtInList.AllowUserToDeleteRows = False
        Me.TxtInList.AllowUserToOrderColumns = True
        Me.TxtInList.AllowUserToResizeColumns = False
        Me.TxtInList.AllowUserToResizeRows = False
        Me.TxtInList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtInList.BackgroundColor = System.Drawing.Color.White
        Me.TxtInList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.TxtInList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtInList.ColumnHeadersVisible = False
        Me.TxtInList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tidetails, Me.tiamt, Me.titax})
        Me.TxtInList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtInList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtInList.GridColor = System.Drawing.Color.White
        Me.TxtInList.Location = New System.Drawing.Point(448, 30)
        Me.TxtInList.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtInList.MultiSelect = False
        Me.TxtInList.Name = "TxtInList"
        Me.TxtInList.RowHeadersVisible = False
        Me.TxtInList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtInList.Size = New System.Drawing.Size(448, 306)
        Me.TxtInList.TabIndex = 5
        '
        'tidetails
        '
        Me.tidetails.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.tidetails.HeaderText = "Column1"
        Me.tidetails.Name = "tidetails"
        '
        'tiamt
        '
        Me.tiamt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N" & ErpDecimalPlaces
        DataGridViewCellStyle3.NullValue = Nothing
        Me.tiamt.DefaultCellStyle = DataGridViewCellStyle3
        Me.tiamt.HeaderText = "Column1"
        Me.tiamt.Name = "tiamt"
        '
        'titax
        '
        Me.titax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N" & ErpDecimalPlaces
        DataGridViewCellStyle4.NullValue = Nothing
        Me.titax.DefaultCellStyle = DataGridViewCellStyle4
        Me.titax.HeaderText = "Column1"
        Me.titax.Name = "titax"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtVATPayble)
        Me.Panel1.Controls.Add(Me.lblVATPayble)
        Me.Panel1.Controls.Add(Me.TxtCrTotals)
        Me.Panel1.Controls.Add(Me.ImSlabel6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(448, 336)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(448, 43)
        Me.Panel1.TabIndex = 8
        '
        'TxtVATPayble
        '
        Me.TxtVATPayble.AllowToolTip = True
        Me.TxtVATPayble.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtVATPayble.BackColor = System.Drawing.Color.White
        Me.TxtVATPayble.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TxtVATPayble.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVATPayble.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtVATPayble.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtVATPayble.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtVATPayble.IsAllowDigits = True
        Me.TxtVATPayble.IsAllowSpace = True
        Me.TxtVATPayble.IsAllowSplChars = True
        Me.TxtVATPayble.LFocusBackColor = System.Drawing.Color.White
        Me.TxtVATPayble.Location = New System.Drawing.Point(313, 23)
        Me.TxtVATPayble.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtVATPayble.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtVATPayble.MaxLength = 75
        Me.TxtVATPayble.Name = "TxtVATPayble"
        Me.TxtVATPayble.ReadOnly = True
        Me.TxtVATPayble.SetToolTip = Nothing
        Me.TxtVATPayble.Size = New System.Drawing.Size(133, 20)
        Me.TxtVATPayble.SpecialCharList = "&-/@"
        Me.TxtVATPayble.TabIndex = 21
        Me.TxtVATPayble.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtVATPayble.UseFunctionKeys = False
        Me.TxtVATPayble.Visible = False
        '
        'lblVATPayble
        '
        Me.lblVATPayble.AutoSize = True
        Me.lblVATPayble.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVATPayble.Location = New System.Drawing.Point(12, 25)
        Me.lblVATPayble.Name = "lblVATPayble"
        Me.lblVATPayble.Size = New System.Drawing.Size(73, 13)
        Me.lblVATPayble.TabIndex = 16
        Me.lblVATPayble.Text = "VAT Payble"
        Me.lblVATPayble.Visible = False
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(2, 5)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(133, 16)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "OUTPUT VAT (SALES)"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(3, 5)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(145, 16)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "INPUT VAT (PURCHASE)"
        '
        'TxtHeading
        '
        Me.TxtHeading.BackColor = System.Drawing.Color.Green
        Me.TxtHeading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHeading.ForeColor = System.Drawing.Color.White
        Me.TxtHeading.Location = New System.Drawing.Point(0, 0)
        Me.TxtHeading.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtHeading.Name = "TxtHeading"
        Me.TxtHeading.Size = New System.Drawing.Size(896, 21)
        Me.TxtHeading.TabIndex = 0
        Me.TxtHeading.Text = "VAT COMPUTATION"
        Me.TxtHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.09549!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.03714!))
        Me.TableLayoutPanel2.Controls.Add(Me.BtnClose, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnPrint, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.MenuStrip1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 430)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(896, 42)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(223, 0)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(150, 42)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.AllowToolTip = True
        Me.BtnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnPrint.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.print__1_
        Me.BtnPrint.Location = New System.Drawing.Point(571, 0)
        Me.BtnPrint.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPrint.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.SetToolTip = ""
        Me.BtnPrint.Size = New System.Drawing.Size(162, 42)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseFunctionKeys = False
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(249, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem, Me.PrintToolStripMenuItem, Me.RefreshToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        Me.MenuToolStripMenuItem.Visible = False
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(450, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 25)
        Me.Button1.TabIndex = 53
        Me.Button1.Text = "Load"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtHeading, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(896, 472)
        Me.TableLayoutPanel1.TabIndex = 13
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.TxtEndDate)
        Me.Panel2.Controls.Add(Me.TxtStartDate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 21)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(896, 30)
        Me.Panel2.TabIndex = 2
        '
        'TxtEndDate
        '
        Me.TxtEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndDate.Location = New System.Drawing.Point(297, 8)
        Me.TxtEndDate.Name = "TxtEndDate"
        Me.TxtEndDate.Size = New System.Drawing.Size(147, 20)
        Me.TxtEndDate.TabIndex = 51
        '
        'TxtStartDate
        '
        Me.TxtStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStartDate.Location = New System.Drawing.Point(144, 8)
        Me.TxtStartDate.Name = "TxtStartDate"
        Me.TxtStartDate.Size = New System.Drawing.Size(147, 20)
        Me.TxtStartDate.TabIndex = 50
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Panel1, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TxtoutList, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TxtInList, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel5, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 51)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(896, 379)
        Me.TableLayoutPanel3.TabIndex = 9
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.ImSlabel2)
        Me.Panel4.Controls.Add(Me.ImSlabel8)
        Me.Panel4.Controls.Add(Me.ImSlabel4)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(448, 30)
        Me.Panel4.TabIndex = 9
        '
        'ImSlabel8
        '
        Me.ImSlabel8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(269, 1)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(77, 30)
        Me.ImSlabel8.TabIndex = 16
        Me.ImSlabel8.Text = "Accessable Value"
        Me.ImSlabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ImSlabel4
        '
        Me.ImSlabel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(348, 0)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(100, 30)
        Me.ImSlabel4.TabIndex = 16
        Me.ImSlabel4.Text = "Tax Value"
        Me.ImSlabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.ImSlabel1)
        Me.Panel5.Controls.Add(Me.ImSlabel9)
        Me.Panel5.Controls.Add(Me.ImSlabel7)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(448, 0)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(448, 30)
        Me.Panel5.TabIndex = 10
        '
        'ImSlabel9
        '
        Me.ImSlabel9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel9.Location = New System.Drawing.Point(265, 1)
        Me.ImSlabel9.Name = "ImSlabel9"
        Me.ImSlabel9.Size = New System.Drawing.Size(77, 30)
        Me.ImSlabel9.TabIndex = 16
        Me.ImSlabel9.Text = "Accessable Value"
        Me.ImSlabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ImSlabel7
        '
        Me.ImSlabel7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(348, 1)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(100, 30)
        Me.ImSlabel7.TabIndex = 16
        Me.ImSlabel7.Text = "Tax Value"
        Me.ImSlabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'VATComputation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 472)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "VATComputation"
        Me.Text = "VAT Payble Computation"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.TxtoutList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtInList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TxtDrTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtCrTotals As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtoutList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TxtInList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtHeading As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnPrint As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtEndDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtStartDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblVATRefund As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel9 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents todetails As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents toamt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tidetails As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tiamt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents titax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtVATRefund As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtVATPayble As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents lblVATPayble As JyothiPharmaERPSystem3.IMSlabel
End Class
