<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PhysicalStockAdj
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
        Me.miniToolStrip = New System.Windows.Forms.MenuStrip()
        Me.sfprate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfamount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfprice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfqtytext = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfexpiry = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfbatchno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfsize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfcustbarcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfrateper = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfbarcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfitemcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sflocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sfsno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtFromList = New JyothiPharmaERPSystem3.IMSGrid()
        Me.sfitemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtInvNo = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtQutoNo = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchStockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtTotalValue = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnDelete = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton4 = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnNew = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnSave = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnEdit = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TxtStockDisc = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtStockValue = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtStockQty = New JyothiPharmaERPSystem3.IMSQtyBox()
        Me.TxtStockSize = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtStockCode = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtBarCode = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.BtmAdd = New JyothiPharmaERPSystem3.IMSButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtRatePer = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtStockRate = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.ImsQtyBox1 = New JyothiPharmaERPSystem3.IMSQtyBox()
        Me.BtnEditCancel = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.TxtFromList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'miniToolStrip
        '
        Me.miniToolStrip.AutoSize = False
        Me.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.miniToolStrip.Location = New System.Drawing.Point(65, 27)
        Me.miniToolStrip.Name = "miniToolStrip"
        Me.miniToolStrip.Size = New System.Drawing.Size(58, 24)
        Me.miniToolStrip.TabIndex = 3
        Me.miniToolStrip.Visible = False
        '
        'sfprate
        '
        Me.sfprate.HeaderText = "PRate"
        Me.sfprate.Name = "sfprate"
        Me.sfprate.Visible = False
        '
        'sfamount
        '
        Me.sfamount.HeaderText = "Amount"
        Me.sfamount.Name = "sfamount"
        Me.sfamount.Visible = False
        '
        'sfprice
        '
        Me.sfprice.HeaderText = "Price"
        Me.sfprice.Name = "sfprice"
        '
        'sfqtytext
        '
        Me.sfqtytext.HeaderText = "Qty"
        Me.sfqtytext.Name = "sfqtytext"
        '
        'sfqty
        '
        Me.sfqty.HeaderText = "Qty"
        Me.sfqty.Name = "sfqty"
        Me.sfqty.Visible = False
        '
        'sfexpiry
        '
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.sfexpiry.DefaultCellStyle = DataGridViewCellStyle1
        Me.sfexpiry.HeaderText = "Expiry"
        Me.sfexpiry.Name = "sfexpiry"
        Me.sfexpiry.Visible = False
        '
        'sfbatchno
        '
        Me.sfbatchno.HeaderText = "Batch No"
        Me.sfbatchno.Name = "sfbatchno"
        Me.sfbatchno.Visible = False
        '
        'sfsize
        '
        Me.sfsize.HeaderText = "More Info"
        Me.sfsize.Name = "sfsize"
        '
        'sfcustbarcode
        '
        Me.sfcustbarcode.HeaderText = "Barcode"
        Me.sfcustbarcode.Name = "sfcustbarcode"
        Me.sfcustbarcode.Visible = False
        '
        'sfrateper
        '
        Me.sfrateper.HeaderText = "RatePer"
        Me.sfrateper.Name = "sfrateper"
        Me.sfrateper.Visible = False
        '
        'sfbarcode
        '
        Me.sfbarcode.HeaderText = "Barcode"
        Me.sfbarcode.Name = "sfbarcode"
        Me.sfbarcode.Visible = False
        '
        'sfitemcode
        '
        Me.sfitemcode.HeaderText = "Item Code"
        Me.sfitemcode.Name = "sfitemcode"
        '
        'sflocation
        '
        Me.sflocation.HeaderText = "Location"
        Me.sflocation.Name = "sflocation"
        '
        'sfsno
        '
        Me.sfsno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.sfsno.HeaderText = "S.No"
        Me.sfsno.Name = "sfsno"
        Me.sfsno.Width = 40
        '
        'TxtFromList
        '
        Me.TxtFromList.AllowDrop = True
        Me.TxtFromList.AllowUserToAddRows = False
        Me.TxtFromList.AllowUserToResizeRows = False
        Me.TxtFromList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtFromList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtFromList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sfsno, Me.sflocation, Me.sfitemcode, Me.sfitemname, Me.sfbarcode, Me.sfcustbarcode, Me.sfsize, Me.sfbatchno, Me.sfexpiry, Me.sfqty, Me.sfqtytext, Me.sfprice, Me.sfamount, Me.sfprate, Me.sfrateper})
        Me.TxtFromList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtFromList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtFromList.HasSerialNumber = True
        Me.TxtFromList.Location = New System.Drawing.Point(3, 141)
        Me.TxtFromList.MultiSelect = False
        Me.TxtFromList.Name = "TxtFromList"
        Me.TxtFromList.RowHeadersWidth = 33
        Me.TxtFromList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtFromList.SerialNumberColName = "stSno"
        Me.TxtFromList.Size = New System.Drawing.Size(940, 235)
        Me.TxtFromList.TabIndex = 0
        '
        'sfitemname
        '
        Me.sfitemname.HeaderText = "Item Name"
        Me.sfitemname.Name = "sfitemname"
        Me.sfitemname.Visible = False
        '
        'Panel1
        '
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
        Me.Panel1.Size = New System.Drawing.Size(946, 31)
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
        'TxtInvNo
        '
        Me.TxtInvNo.AllowToolTip = True
        Me.TxtInvNo.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
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
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.PrintToolStripMenuItem, Me.CloseToolStripMenuItem, Me.ReloadToolStripMenuItem, Me.SearchStockToolStripMenuItem, Me.SaveToolStripMenuItem})
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
        'ReloadToolStripMenuItem
        '
        Me.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem"
        Me.ReloadToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.ReloadToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ReloadToolStripMenuItem.Text = "Reload "
        '
        'SearchStockToolStripMenuItem
        '
        Me.SearchStockToolStripMenuItem.Name = "SearchStockToolStripMenuItem"
        Me.SearchStockToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.SearchStockToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.SearchStockToolStripMenuItem.Text = "Search Stock"
        Me.SearchStockToolStripMenuItem.Visible = False
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
        'Label20
        '
        Me.Label20.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(697, 8)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 13)
        Me.Label20.TabIndex = 14
        Me.Label20.Text = "Total Value"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.TxtTotalValue.Location = New System.Drawing.Point(769, 3)
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
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.TxtTotalValue)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 379)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(946, 30)
        Me.Panel2.TabIndex = 9
        '
        'BtnDelete
        '
        Me.BtnDelete.AllowToolTip = True
        Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.Navy
        Me.BtnDelete.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnDelete.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.delete__2_
        Me.BtnDelete.Location = New System.Drawing.Point(303, 3)
        Me.BtnDelete.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.SetToolTip = ""
        Me.BtnDelete.Size = New System.Drawing.Size(138, 46)
        Me.BtnDelete.TabIndex = 3
        Me.BtnDelete.Text = "DELETE"
        Me.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDelete.UseFunctionKeys = False
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'ImsButton4
        '
        Me.ImsButton4.AllowToolTip = True
        Me.ImsButton4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsButton4.ForeColor = System.Drawing.Color.Navy
        Me.ImsButton4.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton4.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.print__1_
        Me.ImsButton4.Location = New System.Drawing.Point(159, 3)
        Me.ImsButton4.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton4.Name = "ImsButton4"
        Me.ImsButton4.SetToolTip = ""
        Me.ImsButton4.Size = New System.Drawing.Size(138, 46)
        Me.ImsButton4.TabIndex = 4
        Me.ImsButton4.Text = "PRINT"
        Me.ImsButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton4.UseFunctionKeys = False
        Me.ImsButton4.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.Navy
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(15, 3)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(138, 46)
        Me.BtnClose.TabIndex = 5
        Me.BtnClose.Text = "CLOSE"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnNew
        '
        Me.BtnNew.AllowToolTip = True
        Me.BtnNew.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNew.ForeColor = System.Drawing.Color.Navy
        Me.BtnNew.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnNew.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361186619_document_new
        Me.BtnNew.Location = New System.Drawing.Point(591, 3)
        Me.BtnNew.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.SetToolTip = ""
        Me.BtnNew.Size = New System.Drawing.Size(138, 46)
        Me.BtnNew.TabIndex = 5
        Me.BtnNew.Text = "NEW"
        Me.BtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnNew.UseFunctionKeys = False
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.AllowToolTip = True
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.Navy
        Me.BtnSave.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnSave.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.Save__1_
        Me.BtnSave.Location = New System.Drawing.Point(735, 3)
        Me.BtnSave.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.SetToolTip = ""
        Me.BtnSave.Size = New System.Drawing.Size(138, 46)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "SAVE"
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseFunctionKeys = False
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 8
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.BtnDelete, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ImsButton4, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnClose, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnNew, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnEdit, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnSave, 6, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 409)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(946, 52)
        Me.TableLayoutPanel3.TabIndex = 7
        '
        'BtnEdit
        '
        Me.BtnEdit.AllowToolTip = True
        Me.BtnEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.ForeColor = System.Drawing.Color.Navy
        Me.BtnEdit.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnEdit.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361188505_file_edit
        Me.BtnEdit.Location = New System.Drawing.Point(447, 3)
        Me.BtnEdit.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.SetToolTip = ""
        Me.BtnEdit.Size = New System.Drawing.Size(138, 46)
        Me.BtnEdit.TabIndex = 2
        Me.BtnEdit.Text = "OPEN"
        Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnEdit.UseFunctionKeys = False
        Me.BtnEdit.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtFromList, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(946, 461)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(946, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "STOCK ADJUSTMENT VOUCHER"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 12
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.78131!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.21869!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label11, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label13, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label17, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label18, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtStockDisc, 6, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtStockValue, 7, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtStockQty, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtStockSize, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtStockCode, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtBarCode, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.BtmAdd, 10, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label16, 9, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtRatePer, 9, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label15, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtStockRate, 5, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ImsQtyBox1, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnEditCancel, 11, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 90)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.42553!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.57447!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(946, 48)
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
        Me.Label13.Location = New System.Drawing.Point(349, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(1, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "More Info"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(753, 6)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(1, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Discount"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(753, 6)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(1, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Value"
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
        Me.TxtStockDisc.ExitOnEscKey = True
        Me.TxtStockDisc.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockDisc.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockDisc.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtStockDisc.HelpText = Nothing
        Me.TxtStockDisc.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockDisc.Location = New System.Drawing.Point(753, 22)
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
        Me.TxtStockValue.Location = New System.Drawing.Point(753, 22)
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
        'TxtStockQty
        '
        Me.TxtStockQty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStockQty.LabelColor = System.Drawing.SystemColors.ControlText
        Me.TxtStockQty.Location = New System.Drawing.Point(349, 3)
        Me.TxtStockQty.Name = "TxtStockQty"
        Me.TableLayoutPanel2.SetRowSpan(Me.TxtStockQty, 2)
        Me.TxtStockQty.Size = New System.Drawing.Size(143, 42)
        Me.TxtStockQty.TabIndex = 2
        '
        'TxtStockSize
        '
        Me.TxtStockSize.AllowToolTip = True
        Me.TxtStockSize.BackColor = System.Drawing.Color.White
        Me.TxtStockSize.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtStockSize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStockSize.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockSize.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockSize.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtStockSize.IsAllowDigits = True
        Me.TxtStockSize.IsAllowSpace = True
        Me.TxtStockSize.IsAllowSplChars = True
        Me.TxtStockSize.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockSize.Location = New System.Drawing.Point(349, 22)
        Me.TxtStockSize.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockSize.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtStockSize.MaxLength = 75
        Me.TxtStockSize.Name = "TxtStockSize"
        Me.TxtStockSize.ReadOnly = True
        Me.TxtStockSize.SetToolTip = Nothing
        Me.TxtStockSize.Size = New System.Drawing.Size(1, 20)
        Me.TxtStockSize.SpecialCharList = "&-/@"
        Me.TxtStockSize.TabIndex = 1
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
        Me.TxtStockCode.ReadOnly = True
        Me.TxtStockCode.SetToolTip = Nothing
        Me.TxtStockCode.Size = New System.Drawing.Size(340, 20)
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
        'BtmAdd
        '
        Me.BtmAdd.AllowToolTip = True
        Me.BtmAdd.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtmAdd.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.add1_32
        Me.BtmAdd.Location = New System.Drawing.Point(838, 3)
        Me.BtmAdd.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtmAdd.Name = "BtmAdd"
        Me.TableLayoutPanel2.SetRowSpan(Me.BtmAdd, 2)
        Me.BtmAdd.SetToolTip = ""
        Me.BtmAdd.Size = New System.Drawing.Size(44, 42)
        Me.BtmAdd.TabIndex = 5
        Me.BtmAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtmAdd.UseFunctionKeys = False
        Me.BtmAdd.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(753, 6)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Rate Per"
        '
        'TxtRatePer
        '
        Me.TxtRatePer.AllowEmpty = True
        Me.TxtRatePer.AllowOnlyListValues = True
        Me.TxtRatePer.AllowToolTip = True
        Me.TxtRatePer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtRatePer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtRatePer.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtRatePer.FormattingEnabled = True
        Me.TxtRatePer.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtRatePer.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtRatePer.IsAdvanceSearchWindow = False
        Me.TxtRatePer.IsAllowDigits = True
        Me.TxtRatePer.IsAllowSpace = True
        Me.TxtRatePer.IsAllowSplChars = True
        Me.TxtRatePer.IsAllowToolTip = True
        Me.TxtRatePer.LFocusBackColor = System.Drawing.Color.White
        Me.TxtRatePer.Location = New System.Drawing.Point(753, 22)
        Me.TxtRatePer.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtRatePer.Name = "TxtRatePer"
        Me.TxtRatePer.SetToolTip = Nothing
        Me.TxtRatePer.Size = New System.Drawing.Size(69, 21)
        Me.TxtRatePer.Sorted = True
        Me.TxtRatePer.SpecialCharList = "&-/@"
        Me.TxtRatePer.TabIndex = 4
        Me.TxtRatePer.UseFunctionKeys = False
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(632, 6)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 13)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Price"
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
        Me.TxtStockRate.ExitOnEscKey = True
        Me.TxtStockRate.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockRate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockRate.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStockRate.HelpText = Nothing
        Me.TxtStockRate.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockRate.Location = New System.Drawing.Point(632, 22)
        Me.TxtStockRate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockRate.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStockRate.Max = CType(100000000000000, Long)
        Me.TxtStockRate.MaxLength = 12
        Me.TxtStockRate.Min = CType(0, Long)
        Me.TxtStockRate.Name = "TxtStockRate"
        Me.TxtStockRate.NextOnEnter = True
        Me.TxtStockRate.SetToolTip = Nothing
        Me.TxtStockRate.Size = New System.Drawing.Size(115, 20)
        Me.TxtStockRate.TabIndex = 3
        Me.TxtStockRate.Text = "0"
        Me.TxtStockRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtStockRate.ToolTip = Nothing
        Me.TxtStockRate.UseFunctionKeys = False
        Me.TxtStockRate.UseUpDownArrowKeys = False
        '
        'ImsQtyBox1
        '
        Me.ImsQtyBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsQtyBox1.LabelColor = System.Drawing.SystemColors.ControlText
        Me.ImsQtyBox1.Location = New System.Drawing.Point(498, 3)
        Me.ImsQtyBox1.Name = "ImsQtyBox1"
        Me.TableLayoutPanel2.SetRowSpan(Me.ImsQtyBox1, 2)
        Me.ImsQtyBox1.Size = New System.Drawing.Size(128, 42)
        Me.ImsQtyBox1.TabIndex = 2
        '
        'BtnEditCancel
        '
        Me.BtnEditCancel.AllowToolTip = True
        Me.BtnEditCancel.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnEditCancel.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnEditCancel.Location = New System.Drawing.Point(890, 3)
        Me.BtnEditCancel.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnEditCancel.Name = "BtnEditCancel"
        Me.TableLayoutPanel2.SetRowSpan(Me.BtnEditCancel, 2)
        Me.BtnEditCancel.SetToolTip = ""
        Me.BtnEditCancel.Size = New System.Drawing.Size(45, 42)
        Me.BtnEditCancel.TabIndex = 6
        Me.BtnEditCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnEditCancel.UseFunctionKeys = False
        Me.BtnEditCancel.UseVisualStyleBackColor = True
        Me.BtnEditCancel.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 61)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(946, 29)
        Me.Panel3.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(512, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "DECREASE (-) QTY"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(353, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "INCREASE (+) QTY"
        '
        'PhysicalStockAdj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "PhysicalStockAdj"
        Me.Text = "Stock Adjustment"
        CType(Me.TxtFromList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents miniToolStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents sfprate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfamount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfprice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfqtytext As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfexpiry As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfbatchno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfsize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfcustbarcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfrateper As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfbarcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfitemcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sflocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sfsno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtFromList As JyothiPharmaERPSystem3.IMSGrid
    Friend WithEvents sfitemname As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalValue As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtInvNo As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents TxtQutoNo As JyothiPharmaERPSystem3.IMSTextBox
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
    Friend WithEvents ImsQtyBox1 As JyothiPharmaERPSystem3.IMSQtyBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SearchStockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
