<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POS
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POS))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtPaymentList = New JyothiPharmaERPSystem3.IMSList()
        Me.spsno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stchequno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stchequedate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchStockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideorUnhidePanelTooltip = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlaceFocusOnQtyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlaceFocusOnQtyToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarcodefocusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CashReceivedfocusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SAVE2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OPEN2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendSMSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtReceivedCash = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtDiscPer = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtDiscountTotal = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtCashtoPay = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtNetTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.lblchangetopay = New JyothiPharmaERPSystem3.IMSlabel()
        Me.lblcahsreceived = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel12 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel11 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtTaxTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel10 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtSubTotal = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel9 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnRough = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtBarcode = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtList = New JyothiPharmaERPSystem3.IMSList()
        Me.stsno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stbarcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stcustbarcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stitemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stbatchno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stmrp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stDisc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stTax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stnetrate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stissimpleunit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sttaxvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ststockvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stlocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stsize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stExpiry = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STUNITNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ImsButton3 = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnMinus5 = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnAdd5 = New JyothiPharmaERPSystem3.IMSButton()
        Me.btnMinus = New JyothiPharmaERPSystem3.IMSButton()
        Me.btnPlus = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.TxtTotalQty = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel7 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtNarration = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtAmountinWords = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImsButton6 = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnPrint = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnSave = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnEdit = New JyothiPharmaERPSystem3.IMSButton()
        Me.btnOpen = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnSendSMS = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtPriceLevel = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel8 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtQutoNo = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.LblMultiCurrencyLabel = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtCurrency = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel13 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtBillType = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtMobileNo = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.lblcustomername = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtCustomerName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.lblledgername = New JyothiPharmaERPSystem3.IMSlabel()
        Me.txtLedgerName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.PrtDoc = New System.Drawing.Printing.PrintDocument()
        Me.TxtToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.TxtPaymentList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.txtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 330.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ImsHeadingLabel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1038, 662)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ImsHeadingLabel1
        '
        Me.ImsHeadingLabel1.AutoSize = True
        Me.ImsHeadingLabel1.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.TableLayoutPanel1.SetColumnSpan(Me.ImsHeadingLabel1, 2)
        Me.ImsHeadingLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsHeadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsHeadingLabel1.ForeColor = System.Drawing.Color.White
        Me.ImsHeadingLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ImsHeadingLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsHeadingLabel1.Name = "ImsHeadingLabel1"
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(1038, 19)
        Me.ImsHeadingLabel1.TabIndex = 0
        Me.ImsHeadingLabel1.Text = "POINT OF SALES ( POS)"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Beige
        Me.Panel2.Controls.Add(Me.TxtPaymentList)
        Me.Panel2.Controls.Add(Me.MenuStrip1)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.TxtReceivedCash)
        Me.Panel2.Controls.Add(Me.TxtDiscPer)
        Me.Panel2.Controls.Add(Me.TxtDiscountTotal)
        Me.Panel2.Controls.Add(Me.TxtCashtoPay)
        Me.Panel2.Controls.Add(Me.TxtNetTotal)
        Me.Panel2.Controls.Add(Me.lblchangetopay)
        Me.Panel2.Controls.Add(Me.lblcahsreceived)
        Me.Panel2.Controls.Add(Me.ImSlabel12)
        Me.Panel2.Controls.Add(Me.ImSlabel11)
        Me.Panel2.Controls.Add(Me.TxtTaxTotal)
        Me.Panel2.Controls.Add(Me.ImSlabel10)
        Me.Panel2.Controls.Add(Me.TxtSubTotal)
        Me.Panel2.Controls.Add(Me.ImSlabel9)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(708, 19)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.TableLayoutPanel1.SetRowSpan(Me.Panel2, 4)
        Me.Panel2.Size = New System.Drawing.Size(330, 643)
        Me.Panel2.TabIndex = 1
        '
        'TxtPaymentList
        '
        Me.TxtPaymentList.AllowUserToAddRows = False
        Me.TxtPaymentList.AllowUserToResizeColumns = False
        Me.TxtPaymentList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPaymentList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.TxtPaymentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtPaymentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtPaymentList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.spsno, Me.stType, Me.stAmount, Me.stchequno, Me.stchequedate})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtPaymentList.DefaultCellStyle = DataGridViewCellStyle2
        Me.TxtPaymentList.Location = New System.Drawing.Point(295, 324)
        Me.TxtPaymentList.Name = "TxtPaymentList"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TxtPaymentList.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.TxtPaymentList.RowHeadersVisible = False
        Me.TxtPaymentList.RowTemplate.Height = 25
        Me.TxtPaymentList.Size = New System.Drawing.Size(23, 92)
        Me.TxtPaymentList.TabIndex = 5
        Me.TxtPaymentList.Visible = False
        '
        'spsno
        '
        Me.spsno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.spsno.HeaderText = "Sno"
        Me.spsno.Name = "spsno"
        Me.spsno.Width = 50
        '
        'stType
        '
        Me.stType.HeaderText = "Type"
        Me.stType.Name = "stType"
        '
        'stAmount
        '
        Me.stAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.stAmount.HeaderText = "Amount"
        Me.stAmount.Name = "stAmount"
        Me.stAmount.Width = 120
        '
        'stchequno
        '
        Me.stchequno.HeaderText = "CheckNO"
        Me.stchequno.Name = "stchequno"
        Me.stchequno.Visible = False
        '
        'stchequedate
        '
        Me.stchequedate.HeaderText = "ChequeDate"
        Me.stchequedate.Name = "stchequedate"
        Me.stchequedate.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(20, 3)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(202, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem1, Me.NewToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.PrintToolStripMenuItem, Me.SearchStockToolStripMenuItem, Me.CloseToolStripMenuItem, Me.ReloadToolStripMenuItem, Me.CopyStripMenuItem1, Me.HideorUnhidePanelTooltip, Me.PlaceFocusOnQtyToolStripMenuItem, Me.PlaceFocusOnQtyToolStripMenuItem1, Me.BarcodefocusToolStripMenuItem, Me.CashReceivedfocusToolStripMenuItem, Me.SAVE2ToolStripMenuItem, Me.OPEN2ToolStripMenuItem, Me.SendSMSToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        Me.MenuToolStripMenuItem.Visible = False
        '
        'SaveToolStripMenuItem1
        '
        Me.SaveToolStripMenuItem1.Name = "SaveToolStripMenuItem1"
        Me.SaveToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem1.Size = New System.Drawing.Size(258, 22)
        Me.SaveToolStripMenuItem1.Text = "Save"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.PrintToolStripMenuItem.Text = "print"
        '
        'SearchStockToolStripMenuItem
        '
        Me.SearchStockToolStripMenuItem.Name = "SearchStockToolStripMenuItem"
        Me.SearchStockToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.SearchStockToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.SearchStockToolStripMenuItem.Text = "Search Stock"
        Me.SearchStockToolStripMenuItem.Visible = False
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.CloseToolStripMenuItem.Text = "close"
        '
        'ReloadToolStripMenuItem
        '
        Me.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem"
        Me.ReloadToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.ReloadToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.ReloadToolStripMenuItem.Text = "Reload "
        '
        'CopyStripMenuItem1
        '
        Me.CopyStripMenuItem1.Name = "CopyStripMenuItem1"
        Me.CopyStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.CopyStripMenuItem1.Size = New System.Drawing.Size(258, 22)
        Me.CopyStripMenuItem1.Text = "ToolStripMenuItem1"
        '
        'HideorUnhidePanelTooltip
        '
        Me.HideorUnhidePanelTooltip.Name = "HideorUnhidePanelTooltip"
        Me.HideorUnhidePanelTooltip.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.HideorUnhidePanelTooltip.Size = New System.Drawing.Size(258, 22)
        Me.HideorUnhidePanelTooltip.Text = "HideorUnhidePanelTooltip"
        '
        'PlaceFocusOnQtyToolStripMenuItem
        '
        Me.PlaceFocusOnQtyToolStripMenuItem.Name = "PlaceFocusOnQtyToolStripMenuItem"
        Me.PlaceFocusOnQtyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.PlaceFocusOnQtyToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.PlaceFocusOnQtyToolStripMenuItem.Text = "PlaceFocusOnRate"
        '
        'PlaceFocusOnQtyToolStripMenuItem1
        '
        Me.PlaceFocusOnQtyToolStripMenuItem1.Name = "PlaceFocusOnQtyToolStripMenuItem1"
        Me.PlaceFocusOnQtyToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.PlaceFocusOnQtyToolStripMenuItem1.Size = New System.Drawing.Size(258, 22)
        Me.PlaceFocusOnQtyToolStripMenuItem1.Text = "PlaceFocusOnQty"
        '
        'BarcodefocusToolStripMenuItem
        '
        Me.BarcodefocusToolStripMenuItem.Name = "BarcodefocusToolStripMenuItem"
        Me.BarcodefocusToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BarcodefocusToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.BarcodefocusToolStripMenuItem.Text = "barcodefocus"
        '
        'CashReceivedfocusToolStripMenuItem
        '
        Me.CashReceivedfocusToolStripMenuItem.Name = "CashReceivedfocusToolStripMenuItem"
        Me.CashReceivedfocusToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.CashReceivedfocusToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.CashReceivedfocusToolStripMenuItem.Text = "CashReceivedfocus"
        '
        'SAVE2ToolStripMenuItem
        '
        Me.SAVE2ToolStripMenuItem.Name = "SAVE2ToolStripMenuItem"
        Me.SAVE2ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.SAVE2ToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.SAVE2ToolStripMenuItem.Text = "sAVE2"
        '
        'OPEN2ToolStripMenuItem
        '
        Me.OPEN2ToolStripMenuItem.Name = "OPEN2ToolStripMenuItem"
        Me.OPEN2ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.OPEN2ToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.OPEN2ToolStripMenuItem.Text = "oPEN2"
        '
        'SendSMSToolStripMenuItem
        '
        Me.SendSMSToolStripMenuItem.Name = "SendSMSToolStripMenuItem"
        Me.SendSMSToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.SendSMSToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.SendSMSToolStripMenuItem.Text = "Send SMS"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.Label20)
        Me.Panel5.Controls.Add(Me.Label14)
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Controls.Add(Me.Label19)
        Me.Panel5.Controls.Add(Me.Label18)
        Me.Panel5.Controls.Add(Me.Label17)
        Me.Panel5.Controls.Add(Me.Label13)
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Controls.Add(Me.Label12)
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Location = New System.Drawing.Point(2, 15)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(328, 302)
        Me.Panel5.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(5, 179)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 51)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "0"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.White
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label20.Location = New System.Drawing.Point(199, 65)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(63, 51)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "-"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.White
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.Control
        Me.Label14.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.BACKSPACE
        Me.Label14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label14.Location = New System.Drawing.Point(199, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 51)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "B"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(5, 235)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(320, 52)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "ENTER"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.White
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.Control
        Me.Label19.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.Arrows_Down_icon
        Me.Label19.Location = New System.Drawing.Point(263, 179)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 51)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "D"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.White
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.Control
        Me.Label18.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.Arrows_Up_icon
        Me.Label18.Location = New System.Drawing.Point(263, 122)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 51)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "U"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.White
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.Control
        Me.Label17.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.Arrows_Right_icon1
        Me.Label17.Location = New System.Drawing.Point(263, 65)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(63, 51)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "R"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.White
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.Control
        Me.Label13.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.Arrows_Left_icon1
        Me.Label13.Location = New System.Drawing.Point(263, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 51)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "L"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.White
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(199, 122)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 51)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "TAB"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(199, 179)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 51)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "DEL"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(134, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 51)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "9"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(69, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 51)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "8"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(5, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 51)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "7"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(134, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 51)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "6"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(69, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 51)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "5"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(5, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 51)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "4"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(134, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 51)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "3"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(69, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 51)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "2"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(5, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 51)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "1"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Bauhaus 93", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(134, 179)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 51)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TxtReceivedCash
        '
        Me.TxtReceivedCash.AllHelpText = True
        Me.TxtReceivedCash.AllowDecimal = True
        Me.TxtReceivedCash.AllowFormulas = False
        Me.TxtReceivedCash.AllowForQty = True
        Me.TxtReceivedCash.AllowNegative = False
        Me.TxtReceivedCash.AllowPerSign = False
        Me.TxtReceivedCash.AllowPlusSign = False
        Me.TxtReceivedCash.AllowToolTip = True
        Me.TxtReceivedCash.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtReceivedCash.DecimalPlaces = CType(3, Short)
        Me.TxtReceivedCash.ExitOnEscKey = True
        Me.TxtReceivedCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReceivedCash.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtReceivedCash.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtReceivedCash.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReceivedCash.HelpText = Nothing
        Me.TxtReceivedCash.LFocusBackColor = System.Drawing.Color.White
        Me.TxtReceivedCash.Location = New System.Drawing.Point(111, 537)
        Me.TxtReceivedCash.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtReceivedCash.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtReceivedCash.Max = CType(100000000000000, Long)
        Me.TxtReceivedCash.MaxLength = 12
        Me.TxtReceivedCash.Min = CType(0, Long)
        Me.TxtReceivedCash.Name = "TxtReceivedCash"
        Me.TxtReceivedCash.NextOnEnter = True
        Me.TxtReceivedCash.SetToolTip = Nothing
        Me.TxtReceivedCash.Size = New System.Drawing.Size(166, 29)
        Me.TxtReceivedCash.TabIndex = 1
        Me.TxtReceivedCash.Text = "0"
        Me.TxtReceivedCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtReceivedCash.ToolTip = Nothing
        Me.TxtReceivedCash.UseFunctionKeys = False
        Me.TxtReceivedCash.UseUpDownArrowKeys = False
        '
        'TxtDiscPer
        '
        Me.TxtDiscPer.AllHelpText = True
        Me.TxtDiscPer.AllowDecimal = True
        Me.TxtDiscPer.AllowFormulas = False
        Me.TxtDiscPer.AllowForQty = True
        Me.TxtDiscPer.AllowNegative = False
        Me.TxtDiscPer.AllowPerSign = False
        Me.TxtDiscPer.AllowPlusSign = False
        Me.TxtDiscPer.AllowToolTip = True
        Me.TxtDiscPer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtDiscPer.DecimalPlaces = CType(3, Short)
        Me.TxtDiscPer.ExitOnEscKey = True
        Me.TxtDiscPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDiscPer.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDiscPer.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDiscPer.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDiscPer.HelpText = Nothing
        Me.TxtDiscPer.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDiscPer.Location = New System.Drawing.Point(48, 434)
        Me.TxtDiscPer.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDiscPer.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtDiscPer.Max = CType(100000000000000, Long)
        Me.TxtDiscPer.MaxLength = 12
        Me.TxtDiscPer.Min = CType(0, Long)
        Me.TxtDiscPer.Name = "TxtDiscPer"
        Me.TxtDiscPer.NextOnEnter = True
        Me.TxtDiscPer.SetToolTip = Nothing
        Me.TxtDiscPer.Size = New System.Drawing.Size(48, 22)
        Me.TxtDiscPer.TabIndex = 1
        Me.TxtDiscPer.Text = "0"
        Me.TxtDiscPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtDiscPer.ToolTip = Nothing
        Me.TxtDiscPer.UseFunctionKeys = False
        Me.TxtDiscPer.UseUpDownArrowKeys = False
        '
        'TxtDiscountTotal
        '
        Me.TxtDiscountTotal.AllHelpText = True
        Me.TxtDiscountTotal.AllowDecimal = True
        Me.TxtDiscountTotal.AllowFormulas = False
        Me.TxtDiscountTotal.AllowForQty = False
        Me.TxtDiscountTotal.AllowNegative = True
        Me.TxtDiscountTotal.AllowPerSign = False
        Me.TxtDiscountTotal.AllowPlusSign = False
        Me.TxtDiscountTotal.AllowToolTip = True
        Me.TxtDiscountTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtDiscountTotal.DecimalPlaces = CType(3, Short)
        Me.TxtDiscountTotal.ExitOnEscKey = True
        Me.TxtDiscountTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDiscountTotal.ForeColor = System.Drawing.Color.Green
        Me.TxtDiscountTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDiscountTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDiscountTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDiscountTotal.HelpText = Nothing
        Me.TxtDiscountTotal.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDiscountTotal.Location = New System.Drawing.Point(102, 432)
        Me.TxtDiscountTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDiscountTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDiscountTotal.Max = CType(100000000000000, Long)
        Me.TxtDiscountTotal.MaxLength = 12
        Me.TxtDiscountTotal.Min = CType(-100000000000000, Long)
        Me.TxtDiscountTotal.Name = "TxtDiscountTotal"
        Me.TxtDiscountTotal.NextOnEnter = True
        Me.TxtDiscountTotal.SetToolTip = Nothing
        Me.TxtDiscountTotal.Size = New System.Drawing.Size(175, 26)
        Me.TxtDiscountTotal.TabIndex = 1
        Me.TxtDiscountTotal.Text = "0"
        Me.TxtDiscountTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtDiscountTotal.ToolTip = Nothing
        Me.TxtDiscountTotal.UseFunctionKeys = False
        Me.TxtDiscountTotal.UseUpDownArrowKeys = False
        '
        'TxtCashtoPay
        '
        Me.TxtCashtoPay.AllowToolTip = True
        Me.TxtCashtoPay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtCashtoPay.BackColor = System.Drawing.Color.White
        Me.TxtCashtoPay.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtCashtoPay.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCashtoPay.ForeColor = System.Drawing.Color.Maroon
        Me.TxtCashtoPay.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCashtoPay.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCashtoPay.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtCashtoPay.IsAllowDigits = True
        Me.TxtCashtoPay.IsAllowSpace = True
        Me.TxtCashtoPay.IsAllowSplChars = True
        Me.TxtCashtoPay.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCashtoPay.Location = New System.Drawing.Point(111, 569)
        Me.TxtCashtoPay.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCashtoPay.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtCashtoPay.MaxLength = 75
        Me.TxtCashtoPay.Name = "TxtCashtoPay"
        Me.TxtCashtoPay.ReadOnly = True
        Me.TxtCashtoPay.SetToolTip = Nothing
        Me.TxtCashtoPay.Size = New System.Drawing.Size(166, 31)
        Me.TxtCashtoPay.SpecialCharList = "&-/@"
        Me.TxtCashtoPay.TabIndex = 0
        Me.TxtCashtoPay.Text = "0"
        Me.TxtCashtoPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtCashtoPay.UseFunctionKeys = False
        '
        'TxtNetTotal
        '
        Me.TxtNetTotal.AllowToolTip = True
        Me.TxtNetTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtNetTotal.BackColor = System.Drawing.Color.White
        Me.TxtNetTotal.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtNetTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetTotal.ForeColor = System.Drawing.Color.Maroon
        Me.TxtNetTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNetTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNetTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtNetTotal.IsAllowDigits = True
        Me.TxtNetTotal.IsAllowSpace = True
        Me.TxtNetTotal.IsAllowSplChars = True
        Me.TxtNetTotal.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNetTotal.Location = New System.Drawing.Point(102, 466)
        Me.TxtNetTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNetTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtNetTotal.MaxLength = 75
        Me.TxtNetTotal.Name = "TxtNetTotal"
        Me.TxtNetTotal.ReadOnly = True
        Me.TxtNetTotal.SetToolTip = Nothing
        Me.TxtNetTotal.Size = New System.Drawing.Size(175, 31)
        Me.TxtNetTotal.SpecialCharList = "&-/@"
        Me.TxtNetTotal.TabIndex = 0
        Me.TxtNetTotal.Text = "0"
        Me.TxtNetTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNetTotal.UseFunctionKeys = False
        '
        'lblchangetopay
        '
        Me.lblchangetopay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblchangetopay.AutoSize = True
        Me.lblchangetopay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblchangetopay.Location = New System.Drawing.Point(12, 580)
        Me.lblchangetopay.Name = "lblchangetopay"
        Me.lblchangetopay.Size = New System.Drawing.Size(92, 13)
        Me.lblchangetopay.TabIndex = 0
        Me.lblchangetopay.Text = "Cash to Return"
        '
        'lblcahsreceived
        '
        Me.lblcahsreceived.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblcahsreceived.AutoSize = True
        Me.lblcahsreceived.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcahsreceived.Location = New System.Drawing.Point(12, 542)
        Me.lblcahsreceived.Name = "lblcahsreceived"
        Me.lblcahsreceived.Size = New System.Drawing.Size(93, 13)
        Me.lblcahsreceived.TabIndex = 0
        Me.lblcahsreceived.Text = "Cash &Received"
        '
        'ImSlabel12
        '
        Me.ImSlabel12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel12.AutoSize = True
        Me.ImSlabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel12.Location = New System.Drawing.Point(10, 478)
        Me.ImSlabel12.Name = "ImSlabel12"
        Me.ImSlabel12.Size = New System.Drawing.Size(60, 13)
        Me.ImSlabel12.TabIndex = 0
        Me.ImSlabel12.Text = "Net Total"
        '
        'ImSlabel11
        '
        Me.ImSlabel11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel11.AutoSize = True
        Me.ImSlabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel11.Location = New System.Drawing.Point(10, 439)
        Me.ImSlabel11.Name = "ImSlabel11"
        Me.ImSlabel11.Size = New System.Drawing.Size(32, 13)
        Me.ImSlabel11.TabIndex = 0
        Me.ImSlabel11.Text = "Disc"
        '
        'TxtTaxTotal
        '
        Me.TxtTaxTotal.AllowToolTip = True
        Me.TxtTaxTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtTaxTotal.BackColor = System.Drawing.Color.White
        Me.TxtTaxTotal.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtTaxTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTaxTotal.ForeColor = System.Drawing.Color.Green
        Me.TxtTaxTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTaxTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTaxTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTaxTotal.IsAllowDigits = True
        Me.TxtTaxTotal.IsAllowSpace = True
        Me.TxtTaxTotal.IsAllowSplChars = True
        Me.TxtTaxTotal.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTaxTotal.Location = New System.Drawing.Point(102, 403)
        Me.TxtTaxTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTaxTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTaxTotal.MaxLength = 75
        Me.TxtTaxTotal.Name = "TxtTaxTotal"
        Me.TxtTaxTotal.ReadOnly = True
        Me.TxtTaxTotal.SetToolTip = Nothing
        Me.TxtTaxTotal.Size = New System.Drawing.Size(175, 26)
        Me.TxtTaxTotal.SpecialCharList = "&-/@"
        Me.TxtTaxTotal.TabIndex = 0
        Me.TxtTaxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTaxTotal.UseFunctionKeys = False
        '
        'ImSlabel10
        '
        Me.ImSlabel10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel10.AutoSize = True
        Me.ImSlabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel10.Location = New System.Drawing.Point(10, 409)
        Me.ImSlabel10.Name = "ImSlabel10"
        Me.ImSlabel10.Size = New System.Drawing.Size(61, 13)
        Me.ImSlabel10.TabIndex = 0
        Me.ImSlabel10.Text = "Tax Total"
        '
        'TxtSubTotal
        '
        Me.TxtSubTotal.AllowToolTip = True
        Me.TxtSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtSubTotal.BackColor = System.Drawing.Color.White
        Me.TxtSubTotal.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtSubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubTotal.ForeColor = System.Drawing.Color.Green
        Me.TxtSubTotal.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSubTotal.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSubTotal.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubTotal.IsAllowDigits = True
        Me.TxtSubTotal.IsAllowSpace = True
        Me.TxtSubTotal.IsAllowSplChars = True
        Me.TxtSubTotal.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSubTotal.Location = New System.Drawing.Point(102, 373)
        Me.TxtSubTotal.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSubTotal.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubTotal.MaxLength = 75
        Me.TxtSubTotal.Name = "TxtSubTotal"
        Me.TxtSubTotal.ReadOnly = True
        Me.TxtSubTotal.SetToolTip = Nothing
        Me.TxtSubTotal.Size = New System.Drawing.Size(175, 26)
        Me.TxtSubTotal.SpecialCharList = "&-/@"
        Me.TxtSubTotal.TabIndex = 0
        Me.TxtSubTotal.Text = "45000"
        Me.TxtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtSubTotal.UseFunctionKeys = False
        '
        'ImSlabel9
        '
        Me.ImSlabel9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel9.AutoSize = True
        Me.ImSlabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel9.Location = New System.Drawing.Point(10, 379)
        Me.ImSlabel9.Name = "ImSlabel9"
        Me.ImSlabel9.Size = New System.Drawing.Size(62, 13)
        Me.ImSlabel9.TabIndex = 0
        Me.ImSlabel9.Text = "Sub Total"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel3.Controls.Add(Me.BtnRough)
        Me.Panel3.Controls.Add(Me.ImsButton1)
        Me.Panel3.Controls.Add(Me.TxtBarcode)
        Me.Panel3.Controls.Add(Me.ImSlabel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 101)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(708, 39)
        Me.Panel3.TabIndex = 1
        '
        'BtnRough
        '
        Me.BtnRough.AllowToolTip = True
        Me.BtnRough.BackColor = System.Drawing.Color.White
        Me.BtnRough.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnRough.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnRough.Image = CType(resources.GetObject("BtnRough.Image"), System.Drawing.Image)
        Me.BtnRough.Location = New System.Drawing.Point(495, 2)
        Me.BtnRough.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnRough.Name = "BtnRough"
        Me.BtnRough.SetToolTip = ""
        Me.BtnRough.Size = New System.Drawing.Size(211, 38)
        Me.BtnRough.TabIndex = 1
        Me.BtnRough.Text = "    Rough Notes"
        Me.BtnRough.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRough.UseFunctionKeys = False
        Me.BtnRough.UseVisualStyleBackColor = False
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.BackColor = System.Drawing.Color.White
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = CType(resources.GetObject("ImsButton1.Image"), System.Drawing.Image)
        Me.ImsButton1.Location = New System.Drawing.Point(263, 2)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(226, 38)
        Me.ImsButton1.TabIndex = 1
        Me.ImsButton1.Text = "Search By Item Code (F1)"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = False
        '
        'TxtBarcode
        '
        Me.TxtBarcode.AllowToolTip = True
        Me.TxtBarcode.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBarcode.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtBarcode.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtBarcode.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtBarcode.IsAllowDigits = True
        Me.TxtBarcode.IsAllowSpace = True
        Me.TxtBarcode.IsAllowSplChars = True
        Me.TxtBarcode.LFocusBackColor = System.Drawing.Color.White
        Me.TxtBarcode.Location = New System.Drawing.Point(73, 9)
        Me.TxtBarcode.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtBarcode.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtBarcode.MaxLength = 75
        Me.TxtBarcode.Name = "TxtBarcode"
        Me.TxtBarcode.SetToolTip = Nothing
        Me.TxtBarcode.Size = New System.Drawing.Size(173, 24)
        Me.TxtBarcode.SpecialCharList = "&-/@"
        Me.TxtBarcode.TabIndex = 0
        Me.TxtBarcode.UseFunctionKeys = False
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(6, 15)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(54, 13)
        Me.ImSlabel5.TabIndex = 0
        Me.ImSlabel5.Text = "&Barcode"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.txtList, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel4, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel7, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 140)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(708, 474)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'txtList
        '
        Me.txtList.AllowUserToAddRows = False
        Me.txtList.AllowUserToDeleteRows = False
        Me.txtList.AllowUserToOrderColumns = True
        Me.txtList.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.txtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.txtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.txtList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.stsno, Me.stbarcode, Me.stcustbarcode, Me.stitemname, Me.stbatchno, Me.stmrp, Me.stQty, Me.stRate, Me.stDisc, Me.stTax, Me.stTotal, Me.stnetrate, Me.stissimpleunit, Me.sttaxvalue, Me.ststockvalue, Me.stlocation, Me.STItemCode, Me.stsize, Me.stExpiry, Me.STUNITNAME})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.txtList.DefaultCellStyle = DataGridViewCellStyle14
        Me.txtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtList.Location = New System.Drawing.Point(0, 0)
        Me.txtList.Margin = New System.Windows.Forms.Padding(0)
        Me.txtList.Name = "txtList"
        Me.txtList.RowHeadersVisible = False
        Me.txtList.RowTemplate.Height = 27
        Me.txtList.Size = New System.Drawing.Size(641, 428)
        Me.txtList.TabIndex = 2
        '
        'stsno
        '
        Me.stsno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.stsno.DefaultCellStyle = DataGridViewCellStyle5
        Me.stsno.HeaderText = "SNo"
        Me.stsno.Name = "stsno"
        Me.stsno.Width = 35
        '
        'stbarcode
        '
        Me.stbarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.stbarcode.DefaultCellStyle = DataGridViewCellStyle6
        Me.stbarcode.HeaderText = "Barcode"
        Me.stbarcode.Name = "stbarcode"
        Me.stbarcode.ReadOnly = True
        Me.stbarcode.Visible = False
        Me.stbarcode.Width = 95
        '
        'stcustbarcode
        '
        Me.stcustbarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.stcustbarcode.HeaderText = "BarCode"
        Me.stcustbarcode.Name = "stcustbarcode"
        Me.stcustbarcode.Width = 90
        '
        'stitemname
        '
        Me.stitemname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.stitemname.DefaultCellStyle = DataGridViewCellStyle7
        Me.stitemname.HeaderText = "Description"
        Me.stitemname.Name = "stitemname"
        Me.stitemname.ReadOnly = True
        '
        'stbatchno
        '
        Me.stbatchno.HeaderText = "BatchNo"
        Me.stbatchno.Name = "stbatchno"
        Me.stbatchno.Visible = False
        '
        'stmrp
        '
        Me.stmrp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.stmrp.HeaderText = "MRP"
        Me.stmrp.Name = "stmrp"
        Me.stmrp.Width = 75
        '
        'stQty
        '
        Me.stQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.stQty.DefaultCellStyle = DataGridViewCellStyle8
        Me.stQty.HeaderText = "Qty"
        Me.stQty.Name = "stQty"
        Me.stQty.Width = 80
        '
        'stRate
        '
        Me.stRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.stRate.DefaultCellStyle = DataGridViewCellStyle9
        Me.stRate.HeaderText = "Rate"
        Me.stRate.Name = "stRate"
        Me.stRate.Width = 75
        '
        'stDisc
        '
        Me.stDisc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.stDisc.DefaultCellStyle = DataGridViewCellStyle10
        Me.stDisc.HeaderText = "Disc%"
        Me.stDisc.Name = "stDisc"
        Me.stDisc.Width = 40
        '
        'stTax
        '
        Me.stTax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        Me.stTax.DefaultCellStyle = DataGridViewCellStyle11
        Me.stTax.HeaderText = "Tax"
        Me.stTax.Name = "stTax"
        Me.stTax.ReadOnly = True
        Me.stTax.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.stTax.Width = 40
        '
        'stTotal
        '
        Me.stTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.stTotal.DefaultCellStyle = DataGridViewCellStyle12
        Me.stTotal.HeaderText = "Total"
        Me.stTotal.Name = "stTotal"
        Me.stTotal.ReadOnly = True
        Me.stTotal.Width = 95
        '
        'stnetrate
        '
        Me.stnetrate.HeaderText = "NetRate"
        Me.stnetrate.Name = "stnetrate"
        Me.stnetrate.Visible = False
        '
        'stissimpleunit
        '
        Me.stissimpleunit.HeaderText = "isSimpleUnit"
        Me.stissimpleunit.Name = "stissimpleunit"
        Me.stissimpleunit.Visible = False
        '
        'sttaxvalue
        '
        Me.sttaxvalue.HeaderText = "TaxVal"
        Me.sttaxvalue.Name = "sttaxvalue"
        Me.sttaxvalue.Visible = False
        '
        'ststockvalue
        '
        Me.ststockvalue.HeaderText = "StockValue"
        Me.ststockvalue.Name = "ststockvalue"
        Me.ststockvalue.Visible = False
        '
        'stlocation
        '
        Me.stlocation.HeaderText = "Location"
        Me.stlocation.Name = "stlocation"
        Me.stlocation.Visible = False
        '
        'STItemCode
        '
        Me.STItemCode.HeaderText = "Stockcode"
        Me.STItemCode.Name = "STItemCode"
        Me.STItemCode.Visible = False
        '
        'stsize
        '
        Me.stsize.HeaderText = "size"
        Me.stsize.Name = "stsize"
        Me.stsize.Visible = False
        '
        'stExpiry
        '
        DataGridViewCellStyle13.Format = "d"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.stExpiry.DefaultCellStyle = DataGridViewCellStyle13
        Me.stExpiry.HeaderText = "Expiry"
        Me.stExpiry.Name = "stExpiry"
        Me.stExpiry.Visible = False
        '
        'STUNITNAME
        '
        Me.STUNITNAME.HeaderText = "UNITNAME"
        Me.STUNITNAME.Name = "STUNITNAME"
        Me.STUNITNAME.Visible = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.ImsButton3)
        Me.Panel4.Controls.Add(Me.BtnMinus5)
        Me.Panel4.Controls.Add(Me.BtnAdd5)
        Me.Panel4.Controls.Add(Me.btnMinus)
        Me.Panel4.Controls.Add(Me.btnPlus)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(641, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(67, 428)
        Me.Panel4.TabIndex = 3
        '
        'ImsButton3
        '
        Me.ImsButton3.AllowToolTip = True
        Me.ImsButton3.BackColor = System.Drawing.Color.White
        Me.ImsButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton3.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton3.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.delete16
        Me.ImsButton3.Location = New System.Drawing.Point(0, 279)
        Me.ImsButton3.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton3.Name = "ImsButton3"
        Me.ImsButton3.SetToolTip = ""
        Me.ImsButton3.Size = New System.Drawing.Size(67, 51)
        Me.ImsButton3.TabIndex = 0
        Me.ImsButton3.Text = "Delete Row"
        Me.ImsButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton3.UseFunctionKeys = False
        Me.ImsButton3.UseVisualStyleBackColor = False
        '
        'BtnMinus5
        '
        Me.BtnMinus5.AllowToolTip = True
        Me.BtnMinus5.BackColor = System.Drawing.Color.White
        Me.BtnMinus5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMinus5.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnMinus5.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.down_icon
        Me.BtnMinus5.Location = New System.Drawing.Point(0, 205)
        Me.BtnMinus5.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnMinus5.Name = "BtnMinus5"
        Me.BtnMinus5.SetToolTip = ""
        Me.BtnMinus5.Size = New System.Drawing.Size(67, 51)
        Me.BtnMinus5.TabIndex = 0
        Me.BtnMinus5.Text = "-5"
        Me.BtnMinus5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnMinus5.UseFunctionKeys = False
        Me.BtnMinus5.UseVisualStyleBackColor = False
        '
        'BtnAdd5
        '
        Me.BtnAdd5.AllowToolTip = True
        Me.BtnAdd5.BackColor = System.Drawing.Color.White
        Me.BtnAdd5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd5.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnAdd5.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.up_icon
        Me.BtnAdd5.Location = New System.Drawing.Point(0, 155)
        Me.BtnAdd5.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnAdd5.Name = "BtnAdd5"
        Me.BtnAdd5.SetToolTip = ""
        Me.BtnAdd5.Size = New System.Drawing.Size(67, 51)
        Me.BtnAdd5.TabIndex = 0
        Me.BtnAdd5.Text = "+5"
        Me.BtnAdd5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd5.UseFunctionKeys = False
        Me.BtnAdd5.UseVisualStyleBackColor = False
        '
        'btnMinus
        '
        Me.btnMinus.AllowToolTip = True
        Me.btnMinus.BackColor = System.Drawing.Color.White
        Me.btnMinus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMinus.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnMinus.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.down_icon
        Me.btnMinus.Location = New System.Drawing.Point(0, 75)
        Me.btnMinus.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnMinus.Name = "btnMinus"
        Me.btnMinus.SetToolTip = ""
        Me.btnMinus.Size = New System.Drawing.Size(67, 51)
        Me.btnMinus.TabIndex = 0
        Me.btnMinus.Text = "-1"
        Me.btnMinus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMinus.UseFunctionKeys = False
        Me.btnMinus.UseVisualStyleBackColor = False
        '
        'btnPlus
        '
        Me.btnPlus.AllowToolTip = True
        Me.btnPlus.BackColor = System.Drawing.Color.White
        Me.btnPlus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlus.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnPlus.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.up_icon
        Me.btnPlus.Location = New System.Drawing.Point(0, 28)
        Me.btnPlus.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnPlus.Name = "btnPlus"
        Me.btnPlus.SetToolTip = ""
        Me.btnPlus.Size = New System.Drawing.Size(67, 51)
        Me.btnPlus.TabIndex = 0
        Me.btnPlus.Text = "+1"
        Me.btnPlus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPlus.UseFunctionKeys = False
        Me.btnPlus.UseVisualStyleBackColor = False
        '
        'Panel7
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Panel7, 2)
        Me.Panel7.Controls.Add(Me.TxtTotalQty)
        Me.Panel7.Controls.Add(Me.ImSlabel7)
        Me.Panel7.Controls.Add(Me.TxtNarration)
        Me.Panel7.Controls.Add(Me.TxtAmountinWords)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 428)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(708, 46)
        Me.Panel7.TabIndex = 5
        '
        'TxtTotalQty
        '
        Me.TxtTotalQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotalQty.AutoSize = True
        Me.TxtTotalQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalQty.Location = New System.Drawing.Point(184, 4)
        Me.TxtTotalQty.Name = "TxtTotalQty"
        Me.TxtTotalQty.Size = New System.Drawing.Size(87, 16)
        Me.TxtTotalQty.TabIndex = 6
        Me.TxtTotalQty.Text = "Total Qty: 0"
        '
        'ImSlabel7
        '
        Me.ImSlabel7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImSlabel7.AutoSize = True
        Me.ImSlabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel7.Location = New System.Drawing.Point(384, 4)
        Me.ImSlabel7.Name = "ImSlabel7"
        Me.ImSlabel7.Size = New System.Drawing.Size(59, 13)
        Me.ImSlabel7.TabIndex = 6
        Me.ImSlabel7.Text = "Narration"
        '
        'TxtNarration
        '
        Me.TxtNarration.AllowToolTip = True
        Me.TxtNarration.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNarration.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtNarration.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.TxtNarration.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNarration.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNarration.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtNarration.IsAllowDigits = True
        Me.TxtNarration.IsAllowSpace = True
        Me.TxtNarration.IsAllowSplChars = True
        Me.TxtNarration.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNarration.Location = New System.Drawing.Point(449, 4)
        Me.TxtNarration.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNarration.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtNarration.MaxLength = 75
        Me.TxtNarration.Multiline = True
        Me.TxtNarration.Name = "TxtNarration"
        Me.TxtNarration.SetToolTip = Nothing
        Me.TxtNarration.Size = New System.Drawing.Size(256, 31)
        Me.TxtNarration.SpecialCharList = "&-/@"
        Me.TxtNarration.TabIndex = 5
        Me.TxtNarration.UseFunctionKeys = False
        '
        'TxtAmountinWords
        '
        Me.TxtAmountinWords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAmountinWords.Location = New System.Drawing.Point(3, 23)
        Me.TxtAmountinWords.Name = "TxtAmountinWords"
        Me.TxtAmountinWords.Size = New System.Drawing.Size(486, 23)
        Me.TxtAmountinWords.TabIndex = 4
        Me.TxtAmountinWords.Text = "amount in words:"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 614)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(708, 48)
        Me.Panel6.TabIndex = 4
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 6
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.Controls.Add(Me.ImsButton6, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnPrint, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnSave, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnEdit, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnOpen, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnSendSMS, 2, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(708, 48)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'ImsButton6
        '
        Me.ImsButton6.AllowToolTip = True
        Me.ImsButton6.BackColor = System.Drawing.Color.White
        Me.ImsButton6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsButton6.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton6.Image = CType(resources.GetObject("ImsButton6.Image"), System.Drawing.Image)
        Me.ImsButton6.Location = New System.Drawing.Point(3, 3)
        Me.ImsButton6.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton6.Name = "ImsButton6"
        Me.ImsButton6.SetToolTip = ""
        Me.ImsButton6.Size = New System.Drawing.Size(111, 42)
        Me.ImsButton6.TabIndex = 0
        Me.ImsButton6.Text = "Close (Ctrl+w)"
        Me.ImsButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton6.UseFunctionKeys = False
        Me.ImsButton6.UseVisualStyleBackColor = False
        '
        'BtnPrint
        '
        Me.BtnPrint.AllowToolTip = True
        Me.BtnPrint.BackColor = System.Drawing.Color.White
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnPrint.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(120, 3)
        Me.BtnPrint.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.SetToolTip = "Ctrl+P"
        Me.BtnPrint.Size = New System.Drawing.Size(111, 42)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print (Ctrl+P)"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseFunctionKeys = False
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.AllowToolTip = True
        Me.BtnSave.BackColor = System.Drawing.Color.White
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnSave.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(588, 3)
        Me.BtnSave.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.SetToolTip = "Ctrl+S or F2"
        Me.BtnSave.Size = New System.Drawing.Size(117, 42)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Save && Print (F2)"
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseFunctionKeys = False
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnEdit
        '
        Me.BtnEdit.AllowToolTip = True
        Me.BtnEdit.BackColor = System.Drawing.Color.White
        Me.BtnEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnEdit.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnEdit.Image = CType(resources.GetObject("BtnEdit.Image"), System.Drawing.Image)
        Me.BtnEdit.Location = New System.Drawing.Point(471, 3)
        Me.BtnEdit.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.SetToolTip = "Ctrl+N"
        Me.BtnEdit.Size = New System.Drawing.Size(111, 42)
        Me.BtnEdit.TabIndex = 0
        Me.BtnEdit.Text = "NEW (Ctrl+N)"
        Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnEdit.UseFunctionKeys = False
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'btnOpen
        '
        Me.btnOpen.AllowToolTip = True
        Me.btnOpen.BackColor = System.Drawing.Color.White
        Me.btnOpen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnOpen.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnOpen.Image = CType(resources.GetObject("btnOpen.Image"), System.Drawing.Image)
        Me.btnOpen.Location = New System.Drawing.Point(354, 3)
        Me.btnOpen.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.SetToolTip = "Ctrl+O or F3"
        Me.btnOpen.Size = New System.Drawing.Size(111, 42)
        Me.btnOpen.TabIndex = 0
        Me.btnOpen.Text = "OPEN ( F3)"
        Me.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOpen.UseFunctionKeys = False
        Me.btnOpen.UseVisualStyleBackColor = False
        '
        'BtnSendSMS
        '
        Me.BtnSendSMS.AllowToolTip = True
        Me.BtnSendSMS.BackColor = System.Drawing.Color.White
        Me.BtnSendSMS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnSendSMS.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnSendSMS.Image = CType(resources.GetObject("BtnSendSMS.Image"), System.Drawing.Image)
        Me.BtnSendSMS.Location = New System.Drawing.Point(237, 3)
        Me.BtnSendSMS.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnSendSMS.Name = "BtnSendSMS"
        Me.BtnSendSMS.SetToolTip = "Ctrl+P"
        Me.BtnSendSMS.Size = New System.Drawing.Size(111, 42)
        Me.BtnSendSMS.TabIndex = 0
        Me.BtnSendSMS.Text = "Send SMS"
        Me.BtnSendSMS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSendSMS.UseFunctionKeys = False
        Me.BtnSendSMS.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 6
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.5!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.TxtPriceLevel, 5, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.ImSlabel4, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.ImSlabel3, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.ImSlabel8, 4, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TxtDate, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TxtQutoNo, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.LblMultiCurrencyLabel, 4, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.TxtCurrency, 5, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.ImSlabel13, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.TxtBillType, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.ImSlabel2, 2, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.TxtMobileNo, 3, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.lblcustomername, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.TxtCustomerName, 3, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.lblledgername, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.txtLedgerName, 3, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 22)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(702, 76)
        Me.TableLayoutPanel4.TabIndex = 5
        '
        'TxtPriceLevel
        '
        Me.TxtPriceLevel.AllowEmpty = True
        Me.TxtPriceLevel.AllowOnlyListValues = False
        Me.TxtPriceLevel.AllowToolTip = True
        Me.TxtPriceLevel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtPriceLevel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtPriceLevel.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtPriceLevel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtPriceLevel.FormattingEnabled = True
        Me.TxtPriceLevel.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPriceLevel.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPriceLevel.IsAdvanceSearchWindow = False
        Me.TxtPriceLevel.IsAllowDigits = True
        Me.TxtPriceLevel.IsAllowSpace = True
        Me.TxtPriceLevel.IsAllowSplChars = True
        Me.TxtPriceLevel.IsAllowToolTip = True
        Me.TxtPriceLevel.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPriceLevel.Location = New System.Drawing.Point(603, 3)
        Me.TxtPriceLevel.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPriceLevel.Name = "TxtPriceLevel"
        Me.TxtPriceLevel.SetToolTip = Nothing
        Me.TxtPriceLevel.Size = New System.Drawing.Size(96, 21)
        Me.TxtPriceLevel.Sorted = True
        Me.TxtPriceLevel.SpecialCharList = "&-/@"
        Me.TxtPriceLevel.TabIndex = 5
        Me.TxtPriceLevel.UseFunctionKeys = False
        '
        'ImSlabel4
        '
        Me.ImSlabel4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(3, 6)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(55, 13)
        Me.ImSlabel4.TabIndex = 0
        Me.ImSlabel4.Text = "Bill Date"
        '
        'ImSlabel3
        '
        Me.ImSlabel3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(3, 31)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(44, 13)
        Me.ImSlabel3.TabIndex = 0
        Me.ImSlabel3.Text = "Bill No"
        '
        'ImSlabel8
        '
        Me.ImSlabel8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ImSlabel8.AutoSize = True
        Me.ImSlabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel8.Location = New System.Drawing.Point(518, 6)
        Me.ImSlabel8.Name = "ImSlabel8"
        Me.ImSlabel8.Size = New System.Drawing.Size(56, 13)
        Me.ImSlabel8.TabIndex = 0
        Me.ImSlabel8.Text = "PriceList"
        '
        'TxtDate
        '
        Me.TxtDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtDate.Location = New System.Drawing.Point(79, 3)
        Me.TxtDate.Name = "TxtDate"
        Me.TxtDate.Size = New System.Drawing.Size(120, 20)
        Me.TxtDate.TabIndex = 0
        '
        'TxtQutoNo
        '
        Me.TxtQutoNo.AllowToolTip = True
        Me.TxtQutoNo.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtQutoNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtQutoNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.TxtQutoNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtQutoNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtQutoNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtQutoNo.IsAllowDigits = True
        Me.TxtQutoNo.IsAllowSpace = True
        Me.TxtQutoNo.IsAllowSplChars = True
        Me.TxtQutoNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtQutoNo.Location = New System.Drawing.Point(79, 28)
        Me.TxtQutoNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtQutoNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtQutoNo.MaxLength = 75
        Me.TxtQutoNo.Name = "TxtQutoNo"
        Me.TxtQutoNo.SetToolTip = Nothing
        Me.TxtQutoNo.Size = New System.Drawing.Size(120, 20)
        Me.TxtQutoNo.SpecialCharList = "&-/@"
        Me.TxtQutoNo.TabIndex = 1
        Me.TxtQutoNo.UseFunctionKeys = False
        '
        'LblMultiCurrencyLabel
        '
        Me.LblMultiCurrencyLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LblMultiCurrencyLabel.AutoSize = True
        Me.LblMultiCurrencyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMultiCurrencyLabel.Location = New System.Drawing.Point(518, 56)
        Me.LblMultiCurrencyLabel.Name = "LblMultiCurrencyLabel"
        Me.LblMultiCurrencyLabel.Size = New System.Drawing.Size(78, 13)
        Me.LblMultiCurrencyLabel.TabIndex = 0
        Me.LblMultiCurrencyLabel.Text = "Bill Currency"
        '
        'TxtCurrency
        '
        Me.TxtCurrency.AllowEmpty = False
        Me.TxtCurrency.AllowOnlyListValues = True
        Me.TxtCurrency.AllowToolTip = True
        Me.TxtCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtCurrency.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtCurrency.FormattingEnabled = True
        Me.TxtCurrency.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCurrency.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCurrency.IsAdvanceSearchWindow = False
        Me.TxtCurrency.IsAllowDigits = True
        Me.TxtCurrency.IsAllowSpace = True
        Me.TxtCurrency.IsAllowSplChars = True
        Me.TxtCurrency.IsAllowToolTip = True
        Me.TxtCurrency.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCurrency.Location = New System.Drawing.Point(603, 53)
        Me.TxtCurrency.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCurrency.Name = "TxtCurrency"
        Me.TxtCurrency.SetToolTip = Nothing
        Me.TxtCurrency.Size = New System.Drawing.Size(91, 21)
        Me.TxtCurrency.Sorted = True
        Me.TxtCurrency.SpecialCharList = "&-/@"
        Me.TxtCurrency.TabIndex = 6
        Me.TxtCurrency.UseFunctionKeys = False
        '
        'ImSlabel13
        '
        Me.ImSlabel13.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ImSlabel13.AutoSize = True
        Me.ImSlabel13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel13.Location = New System.Drawing.Point(3, 56)
        Me.ImSlabel13.Name = "ImSlabel13"
        Me.ImSlabel13.Size = New System.Drawing.Size(56, 13)
        Me.ImSlabel13.TabIndex = 0
        Me.ImSlabel13.Text = "Bill Type"
        '
        'TxtBillType
        '
        Me.TxtBillType.AllowEmpty = False
        Me.TxtBillType.AllowOnlyListValues = True
        Me.TxtBillType.AllowToolTip = True
        Me.TxtBillType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtBillType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtBillType.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtBillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtBillType.FormattingEnabled = True
        Me.TxtBillType.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtBillType.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtBillType.IsAdvanceSearchWindow = False
        Me.TxtBillType.IsAllowDigits = True
        Me.TxtBillType.IsAllowSpace = True
        Me.TxtBillType.IsAllowSplChars = True
        Me.TxtBillType.IsAllowToolTip = True
        Me.TxtBillType.Items.AddRange(New Object() {"Cash Bill", "Retail Bill"})
        Me.TxtBillType.LFocusBackColor = System.Drawing.Color.White
        Me.TxtBillType.Location = New System.Drawing.Point(79, 53)
        Me.TxtBillType.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtBillType.Name = "TxtBillType"
        Me.TxtBillType.SetToolTip = Nothing
        Me.TxtBillType.Size = New System.Drawing.Size(108, 21)
        Me.TxtBillType.Sorted = True
        Me.TxtBillType.SpecialCharList = "&-/@"
        Me.TxtBillType.TabIndex = 6
        Me.TxtBillType.UseFunctionKeys = False
        '
        'ImSlabel2
        '
        Me.ImSlabel2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(205, 56)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(71, 13)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "Contact No"
        '
        'TxtMobileNo
        '
        Me.TxtMobileNo.AllowToolTip = True
        Me.TxtMobileNo.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtMobileNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtMobileNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.TxtMobileNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtMobileNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtMobileNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtMobileNo.IsAllowDigits = True
        Me.TxtMobileNo.IsAllowSpace = True
        Me.TxtMobileNo.IsAllowSplChars = True
        Me.TxtMobileNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtMobileNo.Location = New System.Drawing.Point(308, 53)
        Me.TxtMobileNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtMobileNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtMobileNo.MaxLength = 75
        Me.TxtMobileNo.Name = "TxtMobileNo"
        Me.TxtMobileNo.SetToolTip = Nothing
        Me.TxtMobileNo.Size = New System.Drawing.Size(204, 20)
        Me.TxtMobileNo.SpecialCharList = "&-/@"
        Me.TxtMobileNo.TabIndex = 3
        Me.TxtMobileNo.UseFunctionKeys = False
        '
        'lblcustomername
        '
        Me.lblcustomername.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblcustomername.AutoSize = True
        Me.lblcustomername.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcustomername.Location = New System.Drawing.Point(205, 31)
        Me.lblcustomername.Name = "lblcustomername"
        Me.lblcustomername.Size = New System.Drawing.Size(95, 13)
        Me.lblcustomername.TabIndex = 0
        Me.lblcustomername.Text = "Customer Name"
        '
        'TxtCustomerName
        '
        Me.TxtCustomerName.AllowToolTip = True
        Me.TxtCustomerName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtCustomerName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.TxtCustomerName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCustomerName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCustomerName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtCustomerName.IsAllowDigits = True
        Me.TxtCustomerName.IsAllowSpace = True
        Me.TxtCustomerName.IsAllowSplChars = True
        Me.TxtCustomerName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCustomerName.Location = New System.Drawing.Point(308, 28)
        Me.TxtCustomerName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCustomerName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtCustomerName.MaxLength = 75
        Me.TxtCustomerName.Name = "TxtCustomerName"
        Me.TxtCustomerName.SetToolTip = Nothing
        Me.TxtCustomerName.Size = New System.Drawing.Size(204, 20)
        Me.TxtCustomerName.SpecialCharList = "&-/@"
        Me.TxtCustomerName.TabIndex = 3
        Me.TxtCustomerName.UseFunctionKeys = False
        '
        'lblledgername
        '
        Me.lblledgername.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblledgername.AutoSize = True
        Me.lblledgername.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblledgername.Location = New System.Drawing.Point(205, 6)
        Me.lblledgername.Name = "lblledgername"
        Me.lblledgername.Size = New System.Drawing.Size(95, 13)
        Me.lblledgername.TabIndex = 0
        Me.lblledgername.Text = "Customer Name"
        Me.lblledgername.Visible = False
        '
        'txtLedgerName
        '
        Me.txtLedgerName.AllowEmpty = True
        Me.txtLedgerName.AllowOnlyListValues = True
        Me.txtLedgerName.AllowToolTip = True
        Me.txtLedgerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtLedgerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtLedgerName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.txtLedgerName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLedgerName.Enabled = False
        Me.txtLedgerName.FormattingEnabled = True
        Me.txtLedgerName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtLedgerName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtLedgerName.IsAdvanceSearchWindow = True
        Me.txtLedgerName.IsAllowDigits = True
        Me.txtLedgerName.IsAllowSpace = True
        Me.txtLedgerName.IsAllowSplChars = True
        Me.txtLedgerName.IsAllowToolTip = True
        Me.txtLedgerName.LFocusBackColor = System.Drawing.Color.White
        Me.txtLedgerName.Location = New System.Drawing.Point(308, 3)
        Me.txtLedgerName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtLedgerName.Name = "txtLedgerName"
        Me.txtLedgerName.SetToolTip = Nothing
        Me.txtLedgerName.Size = New System.Drawing.Size(204, 21)
        Me.txtLedgerName.Sorted = True
        Me.txtLedgerName.SpecialCharList = "&-/@"
        Me.txtLedgerName.TabIndex = 2
        Me.txtLedgerName.UseFunctionKeys = False
        Me.txtLedgerName.Visible = False
        '
        'PrtDoc
        '
        '
        'TxtToolTip
        '
        Me.TxtToolTip.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TxtToolTip.ToolTipTitle = "Help"
        '
        'POS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1038, 662)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "POS"
        Me.Text = "POS"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.TxtPaymentList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.txtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents lblcustomername As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents txtLedgerName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtCustomerName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtQutoNo As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtBarcode As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtPriceLevel As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel8 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ImsButton3 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents btnMinus As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents btnPlus As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtNetTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel12 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel11 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtTaxTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel10 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtSubTotal As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImSlabel9 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtDiscPer As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtDiscountTotal As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents BtnMinus5 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnAdd5 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtReceivedCash As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtCashtoPay As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents lblchangetopay As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents lblcahsreceived As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnEdit As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnSave As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents btnOpen As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton6 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtAmountinWords As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents PrtDoc As System.Drawing.Printing.PrintDocument
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchStockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideorUnhidePanelTooltip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxtMobileNo As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel7 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtNarration As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalQty As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents BtnRough As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents PlaceFocusOnQtyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlaceFocusOnQtyToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarcodefocusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CashReceivedfocusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents SAVE2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OPEN2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblMultiCurrencyLabel As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtCurrency As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel13 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtBillType As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents lblledgername As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtPaymentList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents spsno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stchequno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stchequedate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnPrint As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnSendSMS As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents SendSMSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxtToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents stsno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stbarcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stcustbarcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stitemname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stbatchno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stmrp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stDisc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stTax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stnetrate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stissimpleunit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sttaxvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ststockvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stlocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stsize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stExpiry As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STUNITNAME As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
