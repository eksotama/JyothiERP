<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockTransferFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockTransferFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtInvNo = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtQutoNo = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchStockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtTTotalAmount = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtTotalValue = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnDelete = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton4 = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnNew = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnEdit = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnSave = New JyothiPharmaERPSystem3.IMSButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtToList = New JyothiPharmaERPSystem3.IMSGrid()
        Me.stSno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StBarCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stcustbarcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stbatchno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stExpiry = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stQtyText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stprice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stamount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stprate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.strateper = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtStockSize = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtStockCode = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtBarCode = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.BtnEditCancel = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtmAdd = New JyothiPharmaERPSystem3.IMSButton()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TxtStockName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtStockValue = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtStockDisc = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtRatePer = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtStockRate = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtStockQty = New JyothiPharmaERPSystem3.IMSQtyBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TxtBatchNo = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtTOstockrate = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtToStockDisc = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtToStockValue = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtToRatePer = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtToStockQty = New JyothiPharmaERPSystem3.IMSQtyBox()
        Me.TxtToStockSize = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtToStockCode = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtToBarcode = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.BtnToCancel = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnToAdd = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtFromList = New JyothiPharmaERPSystem3.IMSGrid()
        Me.sfsno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sflocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfitemcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfitemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfbarcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfcustbarcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfsize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfbatchno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfexpiry = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfqtytext = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfprice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfamount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfprate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfrateper = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtLocationTo = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtLocationFrom = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.TxtToList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.TxtFromList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(523, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.TxtDate)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TxtInvNo)
        Me.Panel1.Controls.Add(Me.TxtQutoNo)
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 30)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 31)
        Me.Panel1.TabIndex = 8
        '
        'TxtDate
        '
        Me.TxtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtDate.Location = New System.Drawing.Point(563, 6)
        Me.TxtDate.Name = "TxtDate"
        Me.TxtDate.Size = New System.Drawing.Size(151, 20)
        Me.TxtDate.TabIndex = 1
        '
        'TxtInvNo
        '
        Me.TxtInvNo.AllowToolTip = True
        Me.TxtInvNo.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtInvNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtInvNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtInvNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtInvNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtInvNo.IsAllowDigits = True
        Me.TxtInvNo.IsAllowSpace = True
        Me.TxtInvNo.IsAllowSplChars = True
        Me.TxtInvNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtInvNo.Location = New System.Drawing.Point(86, 5)
        Me.TxtInvNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtInvNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtInvNo.MaxLength = 75
        Me.TxtInvNo.Name = "TxtInvNo"
        Me.TxtInvNo.SetToolTip = Nothing
        Me.TxtInvNo.Size = New System.Drawing.Size(132, 20)
        Me.TxtInvNo.SpecialCharList = "&-/@"
        Me.TxtInvNo.TabIndex = 0
        Me.TxtInvNo.UseFunctionKeys = False
        '
        'TxtQutoNo
        '
        Me.TxtQutoNo.AllowToolTip = True
        Me.TxtQutoNo.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtQutoNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtQutoNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtQutoNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtQutoNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtQutoNo.IsAllowDigits = True
        Me.TxtQutoNo.IsAllowSpace = True
        Me.TxtQutoNo.IsAllowSplChars = True
        Me.TxtQutoNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtQutoNo.Location = New System.Drawing.Point(313, 5)
        Me.TxtQutoNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtQutoNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtQutoNo.MaxLength = 75
        Me.TxtQutoNo.Name = "TxtQutoNo"
        Me.TxtQutoNo.SetToolTip = Nothing
        Me.TxtQutoNo.Size = New System.Drawing.Size(146, 20)
        Me.TxtQutoNo.SpecialCharList = "&-/@"
        Me.TxtQutoNo.TabIndex = 0
        Me.TxtQutoNo.UseFunctionKeys = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(804, 8)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(202, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.PrintToolStripMenuItem, Me.CloseToolStripMenuItem, Me.SearchStockToolStripMenuItem, Me.ReloadToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        Me.MenuToolStripMenuItem.Visible = False
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.PrintToolStripMenuItem.Text = "print"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.CloseToolStripMenuItem.Text = "close"
        '
        'SearchStockToolStripMenuItem
        '
        Me.SearchStockToolStripMenuItem.Name = "SearchStockToolStripMenuItem"
        Me.SearchStockToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.SearchStockToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.SearchStockToolStripMenuItem.Text = "Search Stock"
        Me.SearchStockToolStripMenuItem.Visible = False
        '
        'ReloadToolStripMenuItem
        '
        Me.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem"
        Me.ReloadToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.ReloadToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ReloadToolStripMenuItem.Text = "Reload "
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(12, 8)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 13)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Journal No"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(260, 8)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Ref No"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "BARCODE"
        Me.Label3.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(-126, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(1, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "More Info"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(-240, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Price"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(-175, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Rate Per"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(-107, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(1, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Discount"
        Me.Label8.Visible = False
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(-107, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(1, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Value"
        Me.Label9.Visible = False
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(1, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Item Code"
        '
        'Label21
        '
        Me.Label21.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(-248, 8)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(72, 13)
        Me.Label21.TabIndex = 14
        Me.Label21.Text = "Total Value"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label21)
        Me.Panel3.Controls.Add(Me.TxtTTotalAmount)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(1008, 480)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1, 30)
        Me.Panel3.TabIndex = 9
        '
        'TxtTTotalAmount
        '
        Me.TxtTTotalAmount.AllHelpText = True
        Me.TxtTTotalAmount.AllowDecimal = True
        Me.TxtTTotalAmount.AllowFormulas = False
        Me.TxtTTotalAmount.AllowForQty = True
        Me.TxtTTotalAmount.AllowNegative = False
        Me.TxtTTotalAmount.AllowPerSign = False
        Me.TxtTTotalAmount.AllowPlusSign = False
        Me.TxtTTotalAmount.AllowToolTip = True
        Me.TxtTTotalAmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTTotalAmount.DecimalPlaces = CType(3, Short)
        Me.TxtTTotalAmount.ExitOnEscKey = True
        Me.TxtTTotalAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTTotalAmount.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTTotalAmount.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTTotalAmount.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtTTotalAmount.HelpText = Nothing
        Me.TxtTTotalAmount.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTTotalAmount.Location = New System.Drawing.Point(-176, 3)
        Me.TxtTTotalAmount.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTTotalAmount.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtTTotalAmount.Max = CType(100000000000, Long)
        Me.TxtTTotalAmount.MaxLength = 12
        Me.TxtTTotalAmount.Min = CType(0, Long)
        Me.TxtTTotalAmount.Name = "TxtTTotalAmount"
        Me.TxtTTotalAmount.NextOnEnter = True
        Me.TxtTTotalAmount.ReadOnly = True
        Me.TxtTTotalAmount.SetToolTip = Nothing
        Me.TxtTTotalAmount.Size = New System.Drawing.Size(167, 21)
        Me.TxtTTotalAmount.TabIndex = 15
        Me.TxtTTotalAmount.Text = "0"
        Me.TxtTTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTTotalAmount.ToolTip = Nothing
        Me.TxtTTotalAmount.UseFunctionKeys = False
        Me.TxtTTotalAmount.UseUpDownArrowKeys = False
        '
        'Label20
        '
        Me.Label20.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(759, 8)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 13)
        Me.Label20.TabIndex = 14
        Me.Label20.Text = "Total Value"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.TxtTotalValue)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 480)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1008, 30)
        Me.Panel2.TabIndex = 9
        '
        'TxtTotalValue
        '
        Me.TxtTotalValue.AllHelpText = True
        Me.TxtTotalValue.AllowDecimal = True
        Me.TxtTotalValue.AllowFormulas = False
        Me.TxtTotalValue.AllowForQty = True
        Me.TxtTotalValue.AllowNegative = False
        Me.TxtTotalValue.AllowPerSign = False
        Me.TxtTotalValue.AllowPlusSign = False
        Me.TxtTotalValue.AllowToolTip = True
        Me.TxtTotalValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotalValue.DecimalPlaces = CType(3, Short)
        Me.TxtTotalValue.ExitOnEscKey = True
        Me.TxtTotalValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalValue.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTotalValue.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTotalValue.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtTotalValue.HelpText = Nothing
        Me.TxtTotalValue.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTotalValue.Location = New System.Drawing.Point(831, 3)
        Me.TxtTotalValue.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTotalValue.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtTotalValue.Max = CType(100000000000, Long)
        Me.TxtTotalValue.MaxLength = 12
        Me.TxtTotalValue.Min = CType(0, Long)
        Me.TxtTotalValue.Name = "TxtTotalValue"
        Me.TxtTotalValue.NextOnEnter = True
        Me.TxtTotalValue.ReadOnly = True
        Me.TxtTotalValue.SetToolTip = Nothing
        Me.TxtTotalValue.Size = New System.Drawing.Size(167, 21)
        Me.TxtTotalValue.TabIndex = 15
        Me.TxtTotalValue.Text = "0"
        Me.TxtTotalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTotalValue.ToolTip = Nothing
        Me.TxtTotalValue.UseFunctionKeys = False
        Me.TxtTotalValue.UseUpDownArrowKeys = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 6
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel3, 2)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.BtnDelete, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ImsButton4, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnClose, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnNew, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnEdit, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnSave, 5, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 510)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1008, 52)
        Me.TableLayoutPanel3.TabIndex = 7
        '
        'BtnDelete
        '
        Me.BtnDelete.AllowToolTip = True
        Me.BtnDelete.BackColor = System.Drawing.Color.White
        Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.Navy
        Me.BtnDelete.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
        Me.BtnDelete.Location = New System.Drawing.Point(337, 3)
        Me.BtnDelete.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.SetToolTip = ""
        Me.BtnDelete.Size = New System.Drawing.Size(161, 46)
        Me.BtnDelete.TabIndex = 3
        Me.BtnDelete.Text = "DELETE"
        Me.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDelete.UseFunctionKeys = False
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'ImsButton4
        '
        Me.ImsButton4.AllowToolTip = True
        Me.ImsButton4.BackColor = System.Drawing.Color.White
        Me.ImsButton4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton4.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton4.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton4.Image = CType(resources.GetObject("ImsButton4.Image"), System.Drawing.Image)
        Me.ImsButton4.Location = New System.Drawing.Point(170, 3)
        Me.ImsButton4.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton4.Name = "ImsButton4"
        Me.ImsButton4.SetToolTip = ""
        Me.ImsButton4.Size = New System.Drawing.Size(161, 46)
        Me.ImsButton4.TabIndex = 4
        Me.ImsButton4.Text = "PRINT"
        Me.ImsButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton4.UseFunctionKeys = False
        Me.ImsButton4.UseVisualStyleBackColor = False
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.Navy
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(3, 3)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(161, 46)
        Me.BtnClose.TabIndex = 5
        Me.BtnClose.Text = "CLOSE"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'BtnNew
        '
        Me.BtnNew.AllowToolTip = True
        Me.BtnNew.BackColor = System.Drawing.Color.White
        Me.BtnNew.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNew.ForeColor = System.Drawing.Color.Navy
        Me.BtnNew.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnNew.Image = CType(resources.GetObject("BtnNew.Image"), System.Drawing.Image)
        Me.BtnNew.Location = New System.Drawing.Point(671, 3)
        Me.BtnNew.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.SetToolTip = ""
        Me.BtnNew.Size = New System.Drawing.Size(161, 46)
        Me.BtnNew.TabIndex = 5
        Me.BtnNew.Text = "NEW"
        Me.BtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnNew.UseFunctionKeys = False
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'BtnEdit
        '
        Me.BtnEdit.AllowToolTip = True
        Me.BtnEdit.BackColor = System.Drawing.Color.White
        Me.BtnEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.ForeColor = System.Drawing.Color.Navy
        Me.BtnEdit.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnEdit.Image = CType(resources.GetObject("BtnEdit.Image"), System.Drawing.Image)
        Me.BtnEdit.Location = New System.Drawing.Point(504, 3)
        Me.BtnEdit.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.SetToolTip = ""
        Me.BtnEdit.Size = New System.Drawing.Size(161, 46)
        Me.BtnEdit.TabIndex = 2
        Me.BtnEdit.Text = "OPEN"
        Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnEdit.UseFunctionKeys = False
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.AllowToolTip = True
        Me.BtnSave.BackColor = System.Drawing.Color.White
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.Navy
        Me.BtnSave.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(838, 3)
        Me.BtnSave.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.SetToolTip = ""
        Me.BtnSave.Size = New System.Drawing.Size(167, 46)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "SAVE"
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseFunctionKeys = False
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkOrange
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 2)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1008, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "STOCK TRANSFER "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtToList, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtFromList, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1008, 562)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'TxtToList
        '
        Me.TxtToList.AllowDrop = True
        Me.TxtToList.AllowUserToAddRows = False
        Me.TxtToList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtToList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.TxtToList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtToList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtToList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.stSno, Me.STLocation, Me.STItemCode, Me.StItemName, Me.StBarCode, Me.stcustbarcode, Me.StSize, Me.Stbatchno, Me.stExpiry, Me.StQty, Me.stQtyText, Me.stprice, Me.stamount, Me.stprate, Me.strateper})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtToList.DefaultCellStyle = DataGridViewCellStyle3
        Me.TxtToList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtToList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtToList.Enabled = False
        Me.TxtToList.HasSerialNumber = True
        Me.TxtToList.Location = New System.Drawing.Point(1011, 163)
        Me.TxtToList.MultiSelect = False
        Me.TxtToList.Name = "TxtToList"
        Me.TxtToList.RowHeadersWidth = 33
        Me.TxtToList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtToList.SerialNumberColName = "stSno"
        Me.TxtToList.Size = New System.Drawing.Size(1, 314)
        Me.TxtToList.TabIndex = 0
        '
        'stSno
        '
        Me.stSno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.stSno.HeaderText = "S.No"
        Me.stSno.Name = "stSno"
        Me.stSno.Width = 40
        '
        'STLocation
        '
        Me.STLocation.HeaderText = "Location"
        Me.STLocation.Name = "STLocation"
        '
        'STItemCode
        '
        Me.STItemCode.HeaderText = "Item Code"
        Me.STItemCode.Name = "STItemCode"
        '
        'StItemName
        '
        Me.StItemName.HeaderText = "Item Name"
        Me.StItemName.Name = "StItemName"
        Me.StItemName.Visible = False
        '
        'StBarCode
        '
        Me.StBarCode.HeaderText = "Barcode"
        Me.StBarCode.Name = "StBarCode"
        Me.StBarCode.Visible = False
        '
        'stcustbarcode
        '
        Me.stcustbarcode.HeaderText = "Barcode"
        Me.stcustbarcode.Name = "stcustbarcode"
        Me.stcustbarcode.Visible = False
        '
        'StSize
        '
        Me.StSize.HeaderText = "More Info"
        Me.StSize.Name = "StSize"
        '
        'Stbatchno
        '
        Me.Stbatchno.HeaderText = "Batch No"
        Me.Stbatchno.Name = "Stbatchno"
        Me.Stbatchno.Visible = False
        '
        'stExpiry
        '
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.stExpiry.DefaultCellStyle = DataGridViewCellStyle2
        Me.stExpiry.HeaderText = "Expiry"
        Me.stExpiry.Name = "stExpiry"
        Me.stExpiry.Visible = False
        '
        'StQty
        '
        Me.StQty.HeaderText = "Qty"
        Me.StQty.Name = "StQty"
        Me.StQty.Visible = False
        '
        'stQtyText
        '
        Me.stQtyText.HeaderText = "Qty"
        Me.stQtyText.Name = "stQtyText"
        '
        'stprice
        '
        Me.stprice.HeaderText = "Price"
        Me.stprice.Name = "stprice"
        '
        'stamount
        '
        Me.stamount.HeaderText = "Amount"
        Me.stamount.Name = "stamount"
        Me.stamount.Visible = False
        '
        'stprate
        '
        Me.stprate.HeaderText = "PRate"
        Me.stprate.Name = "stprate"
        Me.stprate.Visible = False
        '
        'strateper
        '
        Me.strateper.HeaderText = "RatePer"
        Me.strateper.Name = "strateper"
        Me.strateper.Visible = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 12
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label11, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label13, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtStockSize, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtStockCode, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtBarCode, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnEditCancel, 11, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtmAdd, 10, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label23, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtStockName, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label18, 9, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label17, 8, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label16, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label15, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtStockValue, 9, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtStockDisc, 8, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtRatePer, 7, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtStockRate, 6, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtStockQty, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label24, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtBatchNo, 4, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 113)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.81633!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.18367!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1008, 47)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(1, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "BARCODE"
        Me.Label11.Visible = False
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(301, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Size"
        '
        'TxtStockSize
        '
        Me.TxtStockSize.AllowToolTip = True
        Me.TxtStockSize.BackColor = System.Drawing.Color.White
        Me.TxtStockSize.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtStockSize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStockSize.Enabled = False
        Me.TxtStockSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtStockSize.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockSize.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockSize.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtStockSize.IsAllowDigits = True
        Me.TxtStockSize.IsAllowSpace = True
        Me.TxtStockSize.IsAllowSplChars = True
        Me.TxtStockSize.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockSize.Location = New System.Drawing.Point(301, 22)
        Me.TxtStockSize.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockSize.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtStockSize.MaxLength = 75
        Me.TxtStockSize.Name = "TxtStockSize"
        Me.TxtStockSize.ReadOnly = True
        Me.TxtStockSize.SetToolTip = Nothing
        Me.TxtStockSize.Size = New System.Drawing.Size(143, 20)
        Me.TxtStockSize.SpecialCharList = "&-/@"
        Me.TxtStockSize.TabIndex = 2
        Me.TxtStockSize.UseFunctionKeys = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Item Code"
        '
        'TxtStockCode
        '
        Me.TxtStockCode.AllowToolTip = True
        Me.TxtStockCode.BackColor = System.Drawing.Color.White
        Me.TxtStockCode.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtStockCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStockCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtStockCode.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockCode.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockCode.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtStockCode.IsAllowDigits = True
        Me.TxtStockCode.IsAllowSpace = True
        Me.TxtStockCode.IsAllowSplChars = True
        Me.TxtStockCode.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockCode.Location = New System.Drawing.Point(3, 22)
        Me.TxtStockCode.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockCode.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtStockCode.MaxLength = 75
        Me.TxtStockCode.Name = "TxtStockCode"
        Me.TxtStockCode.SetToolTip = Nothing
        Me.TxtStockCode.Size = New System.Drawing.Size(143, 20)
        Me.TxtStockCode.SpecialCharList = "&-/@"
        Me.TxtStockCode.TabIndex = 0
        Me.TxtStockCode.UseFunctionKeys = False
        '
        'TxtBarCode
        '
        Me.TxtBarCode.AllowToolTip = True
        Me.TxtBarCode.BackColor = System.Drawing.Color.White
        Me.TxtBarCode.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtBarCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtBarCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtBarCode.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtBarCode.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtBarCode.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtBarCode.IsAllowDigits = True
        Me.TxtBarCode.IsAllowSpace = True
        Me.TxtBarCode.IsAllowSplChars = True
        Me.TxtBarCode.LFocusBackColor = System.Drawing.Color.White
        Me.TxtBarCode.Location = New System.Drawing.Point(3, 22)
        Me.TxtBarCode.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtBarCode.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtBarCode.MaxLength = 20
        Me.TxtBarCode.Name = "TxtBarCode"
        Me.TxtBarCode.SetToolTip = Nothing
        Me.TxtBarCode.Size = New System.Drawing.Size(1, 20)
        Me.TxtBarCode.SpecialCharList = "&-/@"
        Me.TxtBarCode.TabIndex = 0
        Me.TxtBarCode.UseFunctionKeys = False
        Me.TxtBarCode.Visible = False
        '
        'BtnEditCancel
        '
        Me.BtnEditCancel.AllowToolTip = True
        Me.BtnEditCancel.BackColor = System.Drawing.Color.White
        Me.BtnEditCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnEditCancel.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnEditCancel.Image = CType(resources.GetObject("BtnEditCancel.Image"), System.Drawing.Image)
        Me.BtnEditCancel.Location = New System.Drawing.Point(935, 3)
        Me.BtnEditCancel.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnEditCancel.Name = "BtnEditCancel"
        Me.TableLayoutPanel2.SetRowSpan(Me.BtnEditCancel, 2)
        Me.BtnEditCancel.SetToolTip = ""
        Me.BtnEditCancel.Size = New System.Drawing.Size(70, 41)
        Me.BtnEditCancel.TabIndex = 6
        Me.BtnEditCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnEditCancel.UseFunctionKeys = False
        Me.BtnEditCancel.UseVisualStyleBackColor = False
        Me.BtnEditCancel.Visible = False
        '
        'BtmAdd
        '
        Me.BtmAdd.AllowToolTip = True
        Me.BtmAdd.BackColor = System.Drawing.Color.White
        Me.BtmAdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtmAdd.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtmAdd.Image = CType(resources.GetObject("BtmAdd.Image"), System.Drawing.Image)
        Me.BtmAdd.Location = New System.Drawing.Point(865, 3)
        Me.BtmAdd.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtmAdd.Name = "BtmAdd"
        Me.TableLayoutPanel2.SetRowSpan(Me.BtmAdd, 2)
        Me.BtmAdd.SetToolTip = ""
        Me.BtmAdd.Size = New System.Drawing.Size(64, 41)
        Me.BtmAdd.TabIndex = 5
        Me.BtmAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtmAdd.UseFunctionKeys = False
        Me.BtmAdd.UseVisualStyleBackColor = False
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(152, 6)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(67, 13)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Item Name"
        '
        'TxtStockName
        '
        Me.TxtStockName.AllowToolTip = True
        Me.TxtStockName.BackColor = System.Drawing.Color.White
        Me.TxtStockName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtStockName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStockName.Enabled = False
        Me.TxtStockName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtStockName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtStockName.IsAllowDigits = True
        Me.TxtStockName.IsAllowSpace = True
        Me.TxtStockName.IsAllowSplChars = True
        Me.TxtStockName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockName.Location = New System.Drawing.Point(152, 22)
        Me.TxtStockName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtStockName.MaxLength = 75
        Me.TxtStockName.Name = "TxtStockName"
        Me.TxtStockName.ReadOnly = True
        Me.TxtStockName.SetToolTip = Nothing
        Me.TxtStockName.Size = New System.Drawing.Size(143, 20)
        Me.TxtStockName.SpecialCharList = "&-/@"
        Me.TxtStockName.TabIndex = 1
        Me.TxtStockName.UseFunctionKeys = False
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(865, 6)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(1, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Value"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(865, 6)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(1, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Discount"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(865, 6)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(1, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Rate Per"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(756, 6)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 13)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Price"
        '
        'TxtStockValue
        '
        Me.TxtStockValue.AllHelpText = True
        Me.TxtStockValue.AllowDecimal = False
        Me.TxtStockValue.AllowFormulas = False
        Me.TxtStockValue.AllowForQty = True
        Me.TxtStockValue.AllowNegative = False
        Me.TxtStockValue.AllowPerSign = False
        Me.TxtStockValue.AllowPlusSign = False
        Me.TxtStockValue.AllowToolTip = True
        Me.TxtStockValue.DecimalPlaces = CType(3, Short)
        Me.TxtStockValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStockValue.ExitOnEscKey = True
        Me.TxtStockValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStockValue.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockValue.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockValue.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtStockValue.HelpText = Nothing
        Me.TxtStockValue.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockValue.Location = New System.Drawing.Point(865, 22)
        Me.TxtStockValue.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockValue.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtStockValue.Max = CType(100000000000000, Long)
        Me.TxtStockValue.MaxLength = 12
        Me.TxtStockValue.Min = CType(0, Long)
        Me.TxtStockValue.Name = "TxtStockValue"
        Me.TxtStockValue.NextOnEnter = True
        Me.TxtStockValue.ReadOnly = True
        Me.TxtStockValue.SetToolTip = Nothing
        Me.TxtStockValue.Size = New System.Drawing.Size(1, 20)
        Me.TxtStockValue.TabIndex = 6
        Me.TxtStockValue.TabStop = False
        Me.TxtStockValue.Text = "0"
        Me.TxtStockValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtStockValue.ToolTip = Nothing
        Me.TxtStockValue.UseFunctionKeys = False
        Me.TxtStockValue.UseUpDownArrowKeys = False
        '
        'TxtStockDisc
        '
        Me.TxtStockDisc.AllHelpText = True
        Me.TxtStockDisc.AllowDecimal = False
        Me.TxtStockDisc.AllowFormulas = False
        Me.TxtStockDisc.AllowForQty = True
        Me.TxtStockDisc.AllowNegative = False
        Me.TxtStockDisc.AllowPerSign = False
        Me.TxtStockDisc.AllowPlusSign = False
        Me.TxtStockDisc.AllowToolTip = True
        Me.TxtStockDisc.DecimalPlaces = CType(3, Short)
        Me.TxtStockDisc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStockDisc.Enabled = False
        Me.TxtStockDisc.ExitOnEscKey = True
        Me.TxtStockDisc.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockDisc.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockDisc.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtStockDisc.HelpText = Nothing
        Me.TxtStockDisc.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockDisc.Location = New System.Drawing.Point(865, 22)
        Me.TxtStockDisc.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockDisc.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtStockDisc.Max = CType(100000000000000, Long)
        Me.TxtStockDisc.MaxLength = 12
        Me.TxtStockDisc.Min = CType(0, Long)
        Me.TxtStockDisc.Name = "TxtStockDisc"
        Me.TxtStockDisc.NextOnEnter = True
        Me.TxtStockDisc.SetToolTip = Nothing
        Me.TxtStockDisc.Size = New System.Drawing.Size(1, 20)
        Me.TxtStockDisc.TabIndex = 5
        Me.TxtStockDisc.TabStop = False
        Me.TxtStockDisc.Text = "0"
        Me.TxtStockDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtStockDisc.ToolTip = Nothing
        Me.TxtStockDisc.UseFunctionKeys = False
        Me.TxtStockDisc.UseUpDownArrowKeys = False
        '
        'TxtRatePer
        '
        Me.TxtRatePer.AllowEmpty = True
        Me.TxtRatePer.AllowOnlyListValues = True
        Me.TxtRatePer.AllowToolTip = True
        Me.TxtRatePer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtRatePer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtRatePer.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtRatePer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtRatePer.Enabled = False
        Me.TxtRatePer.FormattingEnabled = True
        Me.TxtRatePer.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtRatePer.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtRatePer.IsAdvanceSearchWindow = False
        Me.TxtRatePer.IsAllowDigits = True
        Me.TxtRatePer.IsAllowSpace = True
        Me.TxtRatePer.IsAllowSplChars = True
        Me.TxtRatePer.IsAllowToolTip = True
        Me.TxtRatePer.LFocusBackColor = System.Drawing.Color.White
        Me.TxtRatePer.Location = New System.Drawing.Point(865, 22)
        Me.TxtRatePer.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtRatePer.Name = "TxtRatePer"
        Me.TxtRatePer.SetToolTip = Nothing
        Me.TxtRatePer.Size = New System.Drawing.Size(1, 21)
        Me.TxtRatePer.Sorted = True
        Me.TxtRatePer.SpecialCharList = "&-/@"
        Me.TxtRatePer.TabIndex = 4
        Me.TxtRatePer.UseFunctionKeys = False
        '
        'TxtStockRate
        '
        Me.TxtStockRate.AllHelpText = True
        Me.TxtStockRate.AllowDecimal = True
        Me.TxtStockRate.AllowFormulas = False
        Me.TxtStockRate.AllowForQty = True
        Me.TxtStockRate.AllowNegative = False
        Me.TxtStockRate.AllowPerSign = False
        Me.TxtStockRate.AllowPlusSign = False
        Me.TxtStockRate.AllowToolTip = True
        Me.TxtStockRate.DecimalPlaces = CType(3, Short)
        Me.TxtStockRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStockRate.ExitOnEscKey = True
        Me.TxtStockRate.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockRate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockRate.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStockRate.HelpText = Nothing
        Me.TxtStockRate.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockRate.Location = New System.Drawing.Point(756, 22)
        Me.TxtStockRate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockRate.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStockRate.Max = CType(100000000000000, Long)
        Me.TxtStockRate.MaxLength = 12
        Me.TxtStockRate.Min = CType(0, Long)
        Me.TxtStockRate.Name = "TxtStockRate"
        Me.TxtStockRate.NextOnEnter = True
        Me.TxtStockRate.SetToolTip = Nothing
        Me.TxtStockRate.Size = New System.Drawing.Size(103, 20)
        Me.TxtStockRate.TabIndex = 5
        Me.TxtStockRate.Text = "0"
        Me.TxtStockRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtStockRate.ToolTip = Nothing
        Me.TxtStockRate.UseFunctionKeys = False
        Me.TxtStockRate.UseUpDownArrowKeys = False
        '
        'TxtStockQty
        '
        Me.TxtStockQty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStockQty.LabelColor = System.Drawing.SystemColors.ControlText
        Me.TxtStockQty.Location = New System.Drawing.Point(599, 3)
        Me.TxtStockQty.Name = "TxtStockQty"
        Me.TableLayoutPanel2.SetRowSpan(Me.TxtStockQty, 2)
        Me.TxtStockQty.Size = New System.Drawing.Size(151, 41)
        Me.TxtStockQty.TabIndex = 4
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(450, 6)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(56, 13)
        Me.Label24.TabIndex = 1
        Me.Label24.Text = "BatchNo"
        '
        'TxtBatchNo
        '
        Me.TxtBatchNo.AllowEmpty = True
        Me.TxtBatchNo.AllowOnlyListValues = True
        Me.TxtBatchNo.AllowToolTip = True
        Me.TxtBatchNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtBatchNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtBatchNo.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtBatchNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtBatchNo.FormattingEnabled = True
        Me.TxtBatchNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtBatchNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtBatchNo.IsAdvanceSearchWindow = False
        Me.TxtBatchNo.IsAllowDigits = True
        Me.TxtBatchNo.IsAllowSpace = True
        Me.TxtBatchNo.IsAllowSplChars = True
        Me.TxtBatchNo.IsAllowToolTip = True
        Me.TxtBatchNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtBatchNo.Location = New System.Drawing.Point(450, 22)
        Me.TxtBatchNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtBatchNo.Name = "TxtBatchNo"
        Me.TxtBatchNo.SetToolTip = Nothing
        Me.TxtBatchNo.Size = New System.Drawing.Size(143, 21)
        Me.TxtBatchNo.Sorted = True
        Me.TxtBatchNo.SpecialCharList = "&-/@"
        Me.TxtBatchNo.TabIndex = 3
        Me.TxtBatchNo.UseFunctionKeys = False
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 11
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.96296!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.03704!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label5, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label6, 4, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label7, 5, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label8, 6, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label9, 7, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TxtTOstockrate, 4, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.TxtToStockDisc, 6, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.TxtToStockValue, 7, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.TxtToRatePer, 5, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.TxtToStockQty, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TxtToStockSize, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label10, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TxtToStockCode, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.TxtToBarcode, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.BtnToCancel, 10, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.BtnToAdd, 9, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Enabled = False
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(1008, 113)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.81633!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.18367!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1, 47)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'TxtTOstockrate
        '
        Me.TxtTOstockrate.AllHelpText = True
        Me.TxtTOstockrate.AllowDecimal = True
        Me.TxtTOstockrate.AllowFormulas = False
        Me.TxtTOstockrate.AllowForQty = True
        Me.TxtTOstockrate.AllowNegative = False
        Me.TxtTOstockrate.AllowPerSign = False
        Me.TxtTOstockrate.AllowPlusSign = False
        Me.TxtTOstockrate.AllowToolTip = True
        Me.TxtTOstockrate.DecimalPlaces = CType(3, Short)
        Me.TxtTOstockrate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTOstockrate.ExitOnEscKey = True
        Me.TxtTOstockrate.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtTOstockrate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtTOstockrate.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTOstockrate.HelpText = Nothing
        Me.TxtTOstockrate.LFocusBackColor = System.Drawing.Color.White
        Me.TxtTOstockrate.Location = New System.Drawing.Point(-240, 22)
        Me.TxtTOstockrate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtTOstockrate.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTOstockrate.Max = CType(100000000000000, Long)
        Me.TxtTOstockrate.MaxLength = 12
        Me.TxtTOstockrate.Min = CType(0, Long)
        Me.TxtTOstockrate.Name = "TxtTOstockrate"
        Me.TxtTOstockrate.NextOnEnter = True
        Me.TxtTOstockrate.SetToolTip = Nothing
        Me.TxtTOstockrate.Size = New System.Drawing.Size(59, 20)
        Me.TxtTOstockrate.TabIndex = 3
        Me.TxtTOstockrate.Text = "0"
        Me.TxtTOstockrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTOstockrate.ToolTip = Nothing
        Me.TxtTOstockrate.UseFunctionKeys = False
        Me.TxtTOstockrate.UseUpDownArrowKeys = False
        '
        'TxtToStockDisc
        '
        Me.TxtToStockDisc.AllHelpText = True
        Me.TxtToStockDisc.AllowDecimal = False
        Me.TxtToStockDisc.AllowFormulas = False
        Me.TxtToStockDisc.AllowForQty = True
        Me.TxtToStockDisc.AllowNegative = False
        Me.TxtToStockDisc.AllowPerSign = False
        Me.TxtToStockDisc.AllowPlusSign = False
        Me.TxtToStockDisc.AllowToolTip = True
        Me.TxtToStockDisc.DecimalPlaces = CType(3, Short)
        Me.TxtToStockDisc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtToStockDisc.ExitOnEscKey = True
        Me.TxtToStockDisc.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtToStockDisc.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtToStockDisc.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtToStockDisc.HelpText = Nothing
        Me.TxtToStockDisc.LFocusBackColor = System.Drawing.Color.White
        Me.TxtToStockDisc.Location = New System.Drawing.Point(-107, 22)
        Me.TxtToStockDisc.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtToStockDisc.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtToStockDisc.Max = CType(100000000000000, Long)
        Me.TxtToStockDisc.MaxLength = 12
        Me.TxtToStockDisc.Min = CType(0, Long)
        Me.TxtToStockDisc.Name = "TxtToStockDisc"
        Me.TxtToStockDisc.NextOnEnter = True
        Me.TxtToStockDisc.SetToolTip = Nothing
        Me.TxtToStockDisc.Size = New System.Drawing.Size(1, 20)
        Me.TxtToStockDisc.TabIndex = 1
        Me.TxtToStockDisc.TabStop = False
        Me.TxtToStockDisc.Text = "0"
        Me.TxtToStockDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtToStockDisc.ToolTip = Nothing
        Me.TxtToStockDisc.UseFunctionKeys = False
        Me.TxtToStockDisc.UseUpDownArrowKeys = False
        '
        'TxtToStockValue
        '
        Me.TxtToStockValue.AllHelpText = True
        Me.TxtToStockValue.AllowDecimal = False
        Me.TxtToStockValue.AllowFormulas = False
        Me.TxtToStockValue.AllowForQty = True
        Me.TxtToStockValue.AllowNegative = False
        Me.TxtToStockValue.AllowPerSign = False
        Me.TxtToStockValue.AllowPlusSign = False
        Me.TxtToStockValue.AllowToolTip = True
        Me.TxtToStockValue.DecimalPlaces = CType(3, Short)
        Me.TxtToStockValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtToStockValue.ExitOnEscKey = True
        Me.TxtToStockValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtToStockValue.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtToStockValue.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtToStockValue.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtToStockValue.HelpText = Nothing
        Me.TxtToStockValue.LFocusBackColor = System.Drawing.Color.White
        Me.TxtToStockValue.Location = New System.Drawing.Point(-107, 22)
        Me.TxtToStockValue.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtToStockValue.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtToStockValue.Max = CType(100000000000000, Long)
        Me.TxtToStockValue.MaxLength = 12
        Me.TxtToStockValue.Min = CType(0, Long)
        Me.TxtToStockValue.Name = "TxtToStockValue"
        Me.TxtToStockValue.NextOnEnter = True
        Me.TxtToStockValue.ReadOnly = True
        Me.TxtToStockValue.SetToolTip = Nothing
        Me.TxtToStockValue.Size = New System.Drawing.Size(1, 20)
        Me.TxtToStockValue.TabIndex = 7
        Me.TxtToStockValue.TabStop = False
        Me.TxtToStockValue.Text = "0"
        Me.TxtToStockValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtToStockValue.ToolTip = Nothing
        Me.TxtToStockValue.UseFunctionKeys = False
        Me.TxtToStockValue.UseUpDownArrowKeys = False
        '
        'TxtToRatePer
        '
        Me.TxtToRatePer.AllowEmpty = True
        Me.TxtToRatePer.AllowOnlyListValues = True
        Me.TxtToRatePer.AllowToolTip = True
        Me.TxtToRatePer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtToRatePer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtToRatePer.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtToRatePer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtToRatePer.FormattingEnabled = True
        Me.TxtToRatePer.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtToRatePer.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtToRatePer.IsAdvanceSearchWindow = False
        Me.TxtToRatePer.IsAllowDigits = True
        Me.TxtToRatePer.IsAllowSpace = True
        Me.TxtToRatePer.IsAllowSplChars = True
        Me.TxtToRatePer.IsAllowToolTip = True
        Me.TxtToRatePer.LFocusBackColor = System.Drawing.Color.White
        Me.TxtToRatePer.Location = New System.Drawing.Point(-175, 22)
        Me.TxtToRatePer.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtToRatePer.Name = "TxtToRatePer"
        Me.TxtToRatePer.SetToolTip = Nothing
        Me.TxtToRatePer.Size = New System.Drawing.Size(62, 21)
        Me.TxtToRatePer.Sorted = True
        Me.TxtToRatePer.SpecialCharList = "&-/@"
        Me.TxtToRatePer.TabIndex = 0
        Me.TxtToRatePer.UseFunctionKeys = False
        '
        'TxtToStockQty
        '
        Me.TxtToStockQty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtToStockQty.LabelColor = System.Drawing.SystemColors.ControlText
        Me.TxtToStockQty.Location = New System.Drawing.Point(-126, 3)
        Me.TxtToStockQty.Name = "TxtToStockQty"
        Me.TableLayoutPanel4.SetRowSpan(Me.TxtToStockQty, 2)
        Me.TxtToStockQty.Size = New System.Drawing.Size(1, 41)
        Me.TxtToStockQty.TabIndex = 2
        '
        'TxtToStockSize
        '
        Me.TxtToStockSize.AllowToolTip = True
        Me.TxtToStockSize.BackColor = System.Drawing.Color.White
        Me.TxtToStockSize.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtToStockSize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtToStockSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtToStockSize.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtToStockSize.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtToStockSize.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtToStockSize.IsAllowDigits = True
        Me.TxtToStockSize.IsAllowSpace = True
        Me.TxtToStockSize.IsAllowSplChars = True
        Me.TxtToStockSize.LFocusBackColor = System.Drawing.Color.White
        Me.TxtToStockSize.Location = New System.Drawing.Point(-126, 22)
        Me.TxtToStockSize.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtToStockSize.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtToStockSize.MaxLength = 75
        Me.TxtToStockSize.Name = "TxtToStockSize"
        Me.TxtToStockSize.ReadOnly = True
        Me.TxtToStockSize.SetToolTip = Nothing
        Me.TxtToStockSize.Size = New System.Drawing.Size(1, 20)
        Me.TxtToStockSize.SpecialCharList = "&-/@"
        Me.TxtToStockSize.TabIndex = 1
        Me.TxtToStockSize.UseFunctionKeys = False
        '
        'TxtToStockCode
        '
        Me.TxtToStockCode.AllowToolTip = True
        Me.TxtToStockCode.BackColor = System.Drawing.Color.White
        Me.TxtToStockCode.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtToStockCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtToStockCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtToStockCode.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtToStockCode.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtToStockCode.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtToStockCode.IsAllowDigits = True
        Me.TxtToStockCode.IsAllowSpace = True
        Me.TxtToStockCode.IsAllowSplChars = True
        Me.TxtToStockCode.LFocusBackColor = System.Drawing.Color.White
        Me.TxtToStockCode.Location = New System.Drawing.Point(3, 22)
        Me.TxtToStockCode.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtToStockCode.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtToStockCode.MaxLength = 75
        Me.TxtToStockCode.Name = "TxtToStockCode"
        Me.TxtToStockCode.ReadOnly = True
        Me.TxtToStockCode.SetToolTip = Nothing
        Me.TxtToStockCode.Size = New System.Drawing.Size(1, 20)
        Me.TxtToStockCode.SpecialCharList = "&-/@"
        Me.TxtToStockCode.TabIndex = 0
        Me.TxtToStockCode.UseFunctionKeys = False
        '
        'TxtToBarcode
        '
        Me.TxtToBarcode.AllowToolTip = True
        Me.TxtToBarcode.BackColor = System.Drawing.Color.White
        Me.TxtToBarcode.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtToBarcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtToBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtToBarcode.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtToBarcode.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtToBarcode.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtToBarcode.IsAllowDigits = True
        Me.TxtToBarcode.IsAllowSpace = True
        Me.TxtToBarcode.IsAllowSplChars = True
        Me.TxtToBarcode.LFocusBackColor = System.Drawing.Color.White
        Me.TxtToBarcode.Location = New System.Drawing.Point(3, 22)
        Me.TxtToBarcode.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtToBarcode.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtToBarcode.MaxLength = 20
        Me.TxtToBarcode.Name = "TxtToBarcode"
        Me.TxtToBarcode.SetToolTip = Nothing
        Me.TxtToBarcode.Size = New System.Drawing.Size(1, 20)
        Me.TxtToBarcode.SpecialCharList = "&-/@"
        Me.TxtToBarcode.TabIndex = 0
        Me.TxtToBarcode.UseFunctionKeys = False
        Me.TxtToBarcode.Visible = False
        '
        'BtnToCancel
        '
        Me.BtnToCancel.AllowToolTip = True
        Me.BtnToCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnToCancel.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnToCancel.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnToCancel.Location = New System.Drawing.Point(-57, 3)
        Me.BtnToCancel.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnToCancel.Name = "BtnToCancel"
        Me.TableLayoutPanel4.SetRowSpan(Me.BtnToCancel, 2)
        Me.BtnToCancel.SetToolTip = ""
        Me.BtnToCancel.Size = New System.Drawing.Size(56, 41)
        Me.BtnToCancel.TabIndex = 6
        Me.BtnToCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnToCancel.UseFunctionKeys = False
        Me.BtnToCancel.UseVisualStyleBackColor = True
        Me.BtnToCancel.Visible = False
        '
        'BtnToAdd
        '
        Me.BtnToAdd.AllowToolTip = True
        Me.BtnToAdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnToAdd.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnToAdd.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.add1_32
        Me.BtnToAdd.Location = New System.Drawing.Point(-107, 3)
        Me.BtnToAdd.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnToAdd.Name = "BtnToAdd"
        Me.TableLayoutPanel4.SetRowSpan(Me.BtnToAdd, 2)
        Me.BtnToAdd.SetToolTip = ""
        Me.BtnToAdd.Size = New System.Drawing.Size(44, 41)
        Me.BtnToAdd.TabIndex = 5
        Me.BtnToAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnToAdd.UseFunctionKeys = False
        Me.BtnToAdd.UseVisualStyleBackColor = True
        '
        'TxtFromList
        '
        Me.TxtFromList.AllowDrop = True
        Me.TxtFromList.AllowUserToAddRows = False
        Me.TxtFromList.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFromList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.TxtFromList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtFromList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtFromList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sfsno, Me.sflocation, Me.sfitemcode, Me.sfitemname, Me.sfbarcode, Me.sfcustbarcode, Me.sfsize, Me.sfbatchno, Me.sfexpiry, Me.sfqty, Me.sfqtytext, Me.sfprice, Me.sfamount, Me.sfprate, Me.sfrateper})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TxtFromList.DefaultCellStyle = DataGridViewCellStyle6
        Me.TxtFromList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtFromList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtFromList.HasSerialNumber = True
        Me.TxtFromList.Location = New System.Drawing.Point(3, 163)
        Me.TxtFromList.MultiSelect = False
        Me.TxtFromList.Name = "TxtFromList"
        Me.TxtFromList.RowHeadersWidth = 33
        Me.TxtFromList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtFromList.SerialNumberColName = "stSno"
        Me.TxtFromList.Size = New System.Drawing.Size(1002, 314)
        Me.TxtFromList.TabIndex = 0
        '
        'sfsno
        '
        Me.sfsno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.sfsno.HeaderText = "S.No"
        Me.sfsno.Name = "sfsno"
        Me.sfsno.Width = 40
        '
        'sflocation
        '
        Me.sflocation.HeaderText = "Location"
        Me.sflocation.Name = "sflocation"
        '
        'sfitemcode
        '
        Me.sfitemcode.HeaderText = "Item Code"
        Me.sfitemcode.Name = "sfitemcode"
        '
        'sfitemname
        '
        Me.sfitemname.HeaderText = "Item Name"
        Me.sfitemname.Name = "sfitemname"
        '
        'sfbarcode
        '
        Me.sfbarcode.HeaderText = "Barcode"
        Me.sfbarcode.Name = "sfbarcode"
        Me.sfbarcode.Visible = False
        '
        'sfcustbarcode
        '
        Me.sfcustbarcode.HeaderText = "Barcode"
        Me.sfcustbarcode.Name = "sfcustbarcode"
        Me.sfcustbarcode.Visible = False
        '
        'sfsize
        '
        Me.sfsize.HeaderText = "More Info"
        Me.sfsize.Name = "sfsize"
        '
        'sfbatchno
        '
        Me.sfbatchno.HeaderText = "Batch No"
        Me.sfbatchno.Name = "sfbatchno"
        '
        'sfexpiry
        '
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.sfexpiry.DefaultCellStyle = DataGridViewCellStyle5
        Me.sfexpiry.HeaderText = "Expiry"
        Me.sfexpiry.Name = "sfexpiry"
        '
        'sfqty
        '
        Me.sfqty.HeaderText = "Qty"
        Me.sfqty.Name = "sfqty"
        Me.sfqty.Visible = False
        '
        'sfqtytext
        '
        Me.sfqtytext.HeaderText = "Qty"
        Me.sfqtytext.Name = "sfqtytext"
        '
        'sfprice
        '
        Me.sfprice.HeaderText = "Price"
        Me.sfprice.Name = "sfprice"
        '
        'sfamount
        '
        Me.sfamount.HeaderText = "Amount"
        Me.sfamount.Name = "sfamount"
        Me.sfamount.Visible = False
        '
        'sfprate
        '
        Me.sfprate.HeaderText = "PRate"
        Me.sfprate.Name = "sfprate"
        Me.sfprate.Visible = False
        '
        'sfrateper
        '
        Me.sfrateper.HeaderText = "RatePer"
        Me.sfrateper.Name = "sfrateper"
        Me.sfrateper.Visible = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.ImsButton1)
        Me.Panel4.Controls.Add(Me.TxtLocationTo)
        Me.Panel4.Controls.Add(Me.TxtLocationFrom)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 61)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1008, 52)
        Me.Panel4.TabIndex = 10
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.BackColor = System.Drawing.Color.White
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361187183_Open
        Me.ImsButton1.Location = New System.Drawing.Point(500, 6)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(153, 38)
        Me.ImsButton1.TabIndex = 2
        Me.ImsButton1.Text = "PullData"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = False
        '
        'TxtLocationTo
        '
        Me.TxtLocationTo.AllowEmpty = True
        Me.TxtLocationTo.AllowOnlyListValues = False
        Me.TxtLocationTo.AllowToolTip = True
        Me.TxtLocationTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtLocationTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtLocationTo.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtLocationTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtLocationTo.FormattingEnabled = True
        Me.TxtLocationTo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLocationTo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLocationTo.IsAdvanceSearchWindow = False
        Me.TxtLocationTo.IsAllowDigits = True
        Me.TxtLocationTo.IsAllowSpace = True
        Me.TxtLocationTo.IsAllowSplChars = True
        Me.TxtLocationTo.IsAllowToolTip = True
        Me.TxtLocationTo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLocationTo.Location = New System.Drawing.Point(189, 30)
        Me.TxtLocationTo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLocationTo.Name = "TxtLocationTo"
        Me.TxtLocationTo.SetToolTip = Nothing
        Me.TxtLocationTo.Size = New System.Drawing.Size(248, 21)
        Me.TxtLocationTo.Sorted = True
        Me.TxtLocationTo.SpecialCharList = "&-/@"
        Me.TxtLocationTo.TabIndex = 1
        Me.TxtLocationTo.UseFunctionKeys = False
        '
        'TxtLocationFrom
        '
        Me.TxtLocationFrom.AllowEmpty = True
        Me.TxtLocationFrom.AllowOnlyListValues = False
        Me.TxtLocationFrom.AllowToolTip = True
        Me.TxtLocationFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtLocationFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtLocationFrom.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtLocationFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TxtLocationFrom.FormattingEnabled = True
        Me.TxtLocationFrom.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLocationFrom.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLocationFrom.IsAdvanceSearchWindow = False
        Me.TxtLocationFrom.IsAllowDigits = True
        Me.TxtLocationFrom.IsAllowSpace = True
        Me.TxtLocationFrom.IsAllowSplChars = True
        Me.TxtLocationFrom.IsAllowToolTip = True
        Me.TxtLocationFrom.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLocationFrom.Location = New System.Drawing.Point(189, 6)
        Me.TxtLocationFrom.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLocationFrom.Name = "TxtLocationFrom"
        Me.TxtLocationFrom.SetToolTip = Nothing
        Me.TxtLocationFrom.Size = New System.Drawing.Size(248, 21)
        Me.TxtLocationFrom.Sorted = True
        Me.TxtLocationFrom.SpecialCharList = "&-/@"
        Me.TxtLocationFrom.TabIndex = 1
        Me.TxtLocationFrom.UseFunctionKeys = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(94, 32)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(22, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "To"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(94, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Location From"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StockTransferFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1008, 562)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "StockTransferFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Item Transfer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.TxtToList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        CType(Me.TxtFromList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtQutoNo As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnDelete As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton4 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnNew As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnEdit As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnSave As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtToList As JyothiPharmaERPSystem3.IMSGrid
    Friend WithEvents stSno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StBarCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stcustbarcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Stbatchno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stExpiry As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stQtyText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stprice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stamount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stprate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents strateper As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtStockRate As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtStockDisc As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtStockValue As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtRatePer As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtStockQty As JyothiPharmaERPSystem3.IMSQtyBox
    Friend WithEvents TxtStockSize As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtStockCode As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtBarCode As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents BtnEditCancel As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtmAdd As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtTOstockrate As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtToStockDisc As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtToStockValue As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtToRatePer As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtToStockQty As JyothiPharmaERPSystem3.IMSQtyBox
    Friend WithEvents TxtToStockSize As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtToStockCode As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtToBarcode As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents BtnToCancel As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnToAdd As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtFromList As JyothiPharmaERPSystem3.IMSGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalValue As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TxtTTotalAmount As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtInvNo As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents TxtLocationTo As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtLocationFrom As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TxtStockName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TxtBatchNo As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents sfsno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sflocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfitemcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfitemname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfbarcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfcustbarcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfsize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfbatchno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfexpiry As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfqtytext As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfprice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfamount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfprate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfrateper As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SearchStockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
End Class
