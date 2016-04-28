<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockAgingReportFrm
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
        Me.TxtList = New JyothiPharmaERPSystem3.IMSList()
        Me.TxtHeading = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Txt4value = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.Txt3SValue = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.Txt3Fvalue = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.Txt2Svalue = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.Txt2Fvalue = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtFirstS = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.btnreloadqty = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtStockLocation = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel4 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtStockGroup = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImSlabel6 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel5 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel3 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnPrint = New JyothiPharmaERPSystem3.IMSButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.Location = New System.Drawing.Point(0, 80)
        Me.TxtList.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtList.MultiSelect = False
        Me.TxtList.Name = "TxtList"
        Me.TxtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtList.Size = New System.Drawing.Size(1014, 314)
        Me.TxtList.TabIndex = 0
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
        Me.TxtHeading.Size = New System.Drawing.Size(1014, 23)
        Me.TxtHeading.TabIndex = 0
        Me.TxtHeading.Text = "STOCK AGING REPORT"
        Me.TxtHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Txt4value)
        Me.Panel2.Controls.Add(Me.Txt3SValue)
        Me.Panel2.Controls.Add(Me.Txt3Fvalue)
        Me.Panel2.Controls.Add(Me.Txt2Svalue)
        Me.Panel2.Controls.Add(Me.Txt2Fvalue)
        Me.Panel2.Controls.Add(Me.TxtFirstS)
        Me.Panel2.Controls.Add(Me.btnreloadqty)
        Me.Panel2.Controls.Add(Me.TxtStockLocation)
        Me.Panel2.Controls.Add(Me.ImSlabel4)
        Me.Panel2.Controls.Add(Me.TxtStockGroup)
        Me.Panel2.Controls.Add(Me.ImSlabel6)
        Me.Panel2.Controls.Add(Me.ImSlabel5)
        Me.Panel2.Controls.Add(Me.ImSlabel3)
        Me.Panel2.Controls.Add(Me.ImSlabel2)
        Me.Panel2.Controls.Add(Me.ImSlabel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 23)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1014, 57)
        Me.Panel2.TabIndex = 2
        '
        'Txt4value
        '
        Me.Txt4value.AllHelpText = True
        Me.Txt4value.AllowDecimal = False
        Me.Txt4value.AllowFormulas = False
        Me.Txt4value.AllowForQty = True
        Me.Txt4value.AllowNegative = False
        Me.Txt4value.AllowPerSign = False
        Me.Txt4value.AllowPlusSign = False
        Me.Txt4value.AllowToolTip = True
        Me.Txt4value.DecimalPlaces = CType(ErpDecimalPlaces, Short)
        Me.Txt4value.ExitOnEscKey = True
        Me.Txt4value.GFocusBackColor = System.Drawing.Color.Yellow
        Me.Txt4value.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.Txt4value.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Txt4value.HelpText = Nothing
        Me.Txt4value.LFocusBackColor = System.Drawing.Color.White
        Me.Txt4value.Location = New System.Drawing.Point(930, 17)
        Me.Txt4value.LostFocusFontColor = System.Drawing.Color.Blue
        Me.Txt4value.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Txt4value.Max = CType(100000000000000, Long)
        Me.Txt4value.MaxLength = 12
        Me.Txt4value.Min = CType(0, Long)
        Me.Txt4value.Name = "Txt4value"
        Me.Txt4value.NextOnEnter = True
        Me.Txt4value.Size = New System.Drawing.Size(43, 20)
        Me.Txt4value.TabIndex = 50
        Me.Txt4value.Text = "180"
        Me.Txt4value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt4value.ToolTip = Nothing
        Me.Txt4value.UseFunctionKeys = False
        Me.Txt4value.UseUpDownArrowKeys = False
        '
        'Txt3SValue
        '
        Me.Txt3SValue.AllHelpText = True
        Me.Txt3SValue.AllowDecimal = False
        Me.Txt3SValue.AllowFormulas = False
        Me.Txt3SValue.AllowForQty = True
        Me.Txt3SValue.AllowNegative = False
        Me.Txt3SValue.AllowPerSign = False
        Me.Txt3SValue.AllowPlusSign = False
        Me.Txt3SValue.AllowToolTip = True
        Me.Txt3SValue.DecimalPlaces = CType(ErpDecimalPlaces, Short)
        Me.Txt3SValue.ExitOnEscKey = True
        Me.Txt3SValue.GFocusBackColor = System.Drawing.Color.Yellow
        Me.Txt3SValue.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.Txt3SValue.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Txt3SValue.HelpText = Nothing
        Me.Txt3SValue.LFocusBackColor = System.Drawing.Color.White
        Me.Txt3SValue.Location = New System.Drawing.Point(788, 17)
        Me.Txt3SValue.LostFocusFontColor = System.Drawing.Color.Blue
        Me.Txt3SValue.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Txt3SValue.Max = CType(100000000000000, Long)
        Me.Txt3SValue.MaxLength = 12
        Me.Txt3SValue.Min = CType(0, Long)
        Me.Txt3SValue.Name = "Txt3SValue"
        Me.Txt3SValue.NextOnEnter = True
        Me.Txt3SValue.Size = New System.Drawing.Size(43, 20)
        Me.Txt3SValue.TabIndex = 50
        Me.Txt3SValue.Text = "180"
        Me.Txt3SValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt3SValue.ToolTip = Nothing
        Me.Txt3SValue.UseFunctionKeys = False
        Me.Txt3SValue.UseUpDownArrowKeys = False
        '
        'Txt3Fvalue
        '
        Me.Txt3Fvalue.AllHelpText = True
        Me.Txt3Fvalue.AllowDecimal = False
        Me.Txt3Fvalue.AllowFormulas = False
        Me.Txt3Fvalue.AllowForQty = True
        Me.Txt3Fvalue.AllowNegative = False
        Me.Txt3Fvalue.AllowPerSign = False
        Me.Txt3Fvalue.AllowPlusSign = False
        Me.Txt3Fvalue.AllowToolTip = True
        Me.Txt3Fvalue.DecimalPlaces = CType(ErpDecimalPlaces, Short)
        Me.Txt3Fvalue.ExitOnEscKey = True
        Me.Txt3Fvalue.GFocusBackColor = System.Drawing.Color.Yellow
        Me.Txt3Fvalue.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.Txt3Fvalue.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Txt3Fvalue.HelpText = Nothing
        Me.Txt3Fvalue.LFocusBackColor = System.Drawing.Color.White
        Me.Txt3Fvalue.Location = New System.Drawing.Point(739, 17)
        Me.Txt3Fvalue.LostFocusFontColor = System.Drawing.Color.Blue
        Me.Txt3Fvalue.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Txt3Fvalue.Max = CType(100000000000000, Long)
        Me.Txt3Fvalue.MaxLength = 12
        Me.Txt3Fvalue.Min = CType(0, Long)
        Me.Txt3Fvalue.Name = "Txt3Fvalue"
        Me.Txt3Fvalue.NextOnEnter = True
        Me.Txt3Fvalue.Size = New System.Drawing.Size(43, 20)
        Me.Txt3Fvalue.TabIndex = 50
        Me.Txt3Fvalue.Text = "90"
        Me.Txt3Fvalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt3Fvalue.ToolTip = Nothing
        Me.Txt3Fvalue.UseFunctionKeys = False
        Me.Txt3Fvalue.UseUpDownArrowKeys = False
        '
        'Txt2Svalue
        '
        Me.Txt2Svalue.AllHelpText = True
        Me.Txt2Svalue.AllowDecimal = False
        Me.Txt2Svalue.AllowFormulas = False
        Me.Txt2Svalue.AllowForQty = True
        Me.Txt2Svalue.AllowNegative = False
        Me.Txt2Svalue.AllowPerSign = False
        Me.Txt2Svalue.AllowPlusSign = False
        Me.Txt2Svalue.AllowToolTip = True
        Me.Txt2Svalue.DecimalPlaces = CType(ErpDecimalPlaces, Short)
        Me.Txt2Svalue.ExitOnEscKey = True
        Me.Txt2Svalue.GFocusBackColor = System.Drawing.Color.Yellow
        Me.Txt2Svalue.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.Txt2Svalue.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Txt2Svalue.HelpText = Nothing
        Me.Txt2Svalue.LFocusBackColor = System.Drawing.Color.White
        Me.Txt2Svalue.Location = New System.Drawing.Point(639, 17)
        Me.Txt2Svalue.LostFocusFontColor = System.Drawing.Color.Blue
        Me.Txt2Svalue.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Txt2Svalue.Max = CType(100000000000000, Long)
        Me.Txt2Svalue.MaxLength = 12
        Me.Txt2Svalue.Min = CType(0, Long)
        Me.Txt2Svalue.Name = "Txt2Svalue"
        Me.Txt2Svalue.NextOnEnter = True
        Me.Txt2Svalue.Size = New System.Drawing.Size(47, 20)
        Me.Txt2Svalue.TabIndex = 50
        Me.Txt2Svalue.Text = "90"
        Me.Txt2Svalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt2Svalue.ToolTip = Nothing
        Me.Txt2Svalue.UseFunctionKeys = False
        Me.Txt2Svalue.UseUpDownArrowKeys = False
        '
        'Txt2Fvalue
        '
        Me.Txt2Fvalue.AllHelpText = True
        Me.Txt2Fvalue.AllowDecimal = False
        Me.Txt2Fvalue.AllowFormulas = False
        Me.Txt2Fvalue.AllowForQty = True
        Me.Txt2Fvalue.AllowNegative = False
        Me.Txt2Fvalue.AllowPerSign = False
        Me.Txt2Fvalue.AllowPlusSign = False
        Me.Txt2Fvalue.AllowToolTip = True
        Me.Txt2Fvalue.DecimalPlaces = CType(ErpDecimalPlaces, Short)
        Me.Txt2Fvalue.ExitOnEscKey = True
        Me.Txt2Fvalue.GFocusBackColor = System.Drawing.Color.Yellow
        Me.Txt2Fvalue.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.Txt2Fvalue.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Txt2Fvalue.HelpText = Nothing
        Me.Txt2Fvalue.LFocusBackColor = System.Drawing.Color.White
        Me.Txt2Fvalue.Location = New System.Drawing.Point(590, 17)
        Me.Txt2Fvalue.LostFocusFontColor = System.Drawing.Color.Blue
        Me.Txt2Fvalue.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Txt2Fvalue.Max = CType(100000000000000, Long)
        Me.Txt2Fvalue.MaxLength = 12
        Me.Txt2Fvalue.Min = CType(0, Long)
        Me.Txt2Fvalue.Name = "Txt2Fvalue"
        Me.Txt2Fvalue.NextOnEnter = True
        Me.Txt2Fvalue.Size = New System.Drawing.Size(43, 20)
        Me.Txt2Fvalue.TabIndex = 50
        Me.Txt2Fvalue.Text = "30"
        Me.Txt2Fvalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt2Fvalue.ToolTip = Nothing
        Me.Txt2Fvalue.UseFunctionKeys = False
        Me.Txt2Fvalue.UseUpDownArrowKeys = False
        '
        'TxtFirstS
        '
        Me.TxtFirstS.AllHelpText = True
        Me.TxtFirstS.AllowDecimal = False
        Me.TxtFirstS.AllowFormulas = False
        Me.TxtFirstS.AllowForQty = True
        Me.TxtFirstS.AllowNegative = False
        Me.TxtFirstS.AllowPerSign = False
        Me.TxtFirstS.AllowPlusSign = False
        Me.TxtFirstS.AllowToolTip = True
        Me.TxtFirstS.DecimalPlaces = CType(ErpDecimalPlaces, Short)
        Me.TxtFirstS.ExitOnEscKey = True
        Me.TxtFirstS.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtFirstS.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtFirstS.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtFirstS.HelpText = Nothing
        Me.TxtFirstS.LFocusBackColor = System.Drawing.Color.White
        Me.TxtFirstS.Location = New System.Drawing.Point(479, 17)
        Me.TxtFirstS.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtFirstS.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtFirstS.Max = CType(100000000000000, Long)
        Me.TxtFirstS.MaxLength = 12
        Me.TxtFirstS.Min = CType(0, Long)
        Me.TxtFirstS.Name = "TxtFirstS"
        Me.TxtFirstS.NextOnEnter = True
        Me.TxtFirstS.Size = New System.Drawing.Size(43, 20)
        Me.TxtFirstS.TabIndex = 50
        Me.TxtFirstS.Text = "30"
        Me.TxtFirstS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtFirstS.ToolTip = Nothing
        Me.TxtFirstS.UseFunctionKeys = False
        Me.TxtFirstS.UseUpDownArrowKeys = False
        '
        'btnreloadqty
        '
        Me.btnreloadqty.AllowToolTip = True
        Me.btnreloadqty.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnreloadqty.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.document_inspector
        Me.btnreloadqty.Location = New System.Drawing.Point(333, 6)
        Me.btnreloadqty.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnreloadqty.Name = "btnreloadqty"
        Me.btnreloadqty.SetToolTip = ""
        Me.btnreloadqty.Size = New System.Drawing.Size(107, 43)
        Me.btnreloadqty.TabIndex = 49
        Me.btnreloadqty.Text = "Reload"
        Me.btnreloadqty.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnreloadqty.UseFunctionKeys = False
        Me.btnreloadqty.UseVisualStyleBackColor = True
        '
        'TxtStockLocation
        '
        Me.TxtStockLocation.AllowEmpty = True
        Me.TxtStockLocation.AllowOnlyListValues = True
        Me.TxtStockLocation.AllowToolTip = True
        Me.TxtStockLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtStockLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtStockLocation.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtStockLocation.FormattingEnabled = True
        Me.TxtStockLocation.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockLocation.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockLocation.IsAllowDigits = True
        Me.TxtStockLocation.IsAllowSpace = True
        Me.TxtStockLocation.IsAllowSplChars = True
        Me.TxtStockLocation.IsAllowToolTip = True
        Me.TxtStockLocation.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockLocation.Location = New System.Drawing.Point(133, 29)
        Me.TxtStockLocation.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockLocation.Name = "TxtStockLocation"
        Me.TxtStockLocation.Size = New System.Drawing.Size(197, 21)
        Me.TxtStockLocation.Sorted = True
        Me.TxtStockLocation.SpecialCharList = "&-/@"
        Me.TxtStockLocation.TabIndex = 1
        Me.TxtStockLocation.UseFunctionKeys = False
        '
        'ImSlabel4
        '
        Me.ImSlabel4.AutoSize = True
        Me.ImSlabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel4.Location = New System.Drawing.Point(19, 30)
        Me.ImSlabel4.Name = "ImSlabel4"
        Me.ImSlabel4.Size = New System.Drawing.Size(74, 13)
        Me.ImSlabel4.TabIndex = 0
        Me.ImSlabel4.Text = "By Location"
        '
        'TxtStockGroup
        '
        Me.TxtStockGroup.AllowEmpty = True
        Me.TxtStockGroup.AllowOnlyListValues = True
        Me.TxtStockGroup.AllowToolTip = True
        Me.TxtStockGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtStockGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtStockGroup.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtStockGroup.FormattingEnabled = True
        Me.TxtStockGroup.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockGroup.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockGroup.IsAllowDigits = True
        Me.TxtStockGroup.IsAllowSpace = True
        Me.TxtStockGroup.IsAllowSplChars = True
        Me.TxtStockGroup.IsAllowToolTip = True
        Me.TxtStockGroup.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockGroup.Location = New System.Drawing.Point(133, 3)
        Me.TxtStockGroup.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockGroup.Name = "TxtStockGroup"
        Me.TxtStockGroup.Size = New System.Drawing.Size(197, 21)
        Me.TxtStockGroup.Sorted = True
        Me.TxtStockGroup.SpecialCharList = "&-/@"
        Me.TxtStockGroup.TabIndex = 1
        Me.TxtStockGroup.UseFunctionKeys = False
        '
        'ImSlabel6
        '
        Me.ImSlabel6.AutoSize = True
        Me.ImSlabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel6.Location = New System.Drawing.Point(909, 3)
        Me.ImSlabel6.Name = "ImSlabel6"
        Me.ImSlabel6.Size = New System.Drawing.Size(65, 13)
        Me.ImSlabel6.TabIndex = 0
        Me.ImSlabel6.Text = "4th Period"
        '
        'ImSlabel5
        '
        Me.ImSlabel5.AutoSize = True
        Me.ImSlabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel5.Location = New System.Drawing.Point(758, 3)
        Me.ImSlabel5.Name = "ImSlabel5"
        Me.ImSlabel5.Size = New System.Drawing.Size(65, 13)
        Me.ImSlabel5.TabIndex = 0
        Me.ImSlabel5.Text = "3rd Period"
        '
        'ImSlabel3
        '
        Me.ImSlabel3.AutoSize = True
        Me.ImSlabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel3.Location = New System.Drawing.Point(609, 3)
        Me.ImSlabel3.Name = "ImSlabel3"
        Me.ImSlabel3.Size = New System.Drawing.Size(68, 13)
        Me.ImSlabel3.TabIndex = 0
        Me.ImSlabel3.Text = "2nd Period"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(467, 3)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(64, 13)
        Me.ImSlabel2.TabIndex = 0
        Me.ImSlabel2.Text = "1st Period"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(19, 6)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(96, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "By Stock Group"
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 417)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1014, 52)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(253, 0)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(144, 49)
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
        Me.BtnPrint.Location = New System.Drawing.Point(677, 0)
        Me.BtnPrint.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPrint.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.SetToolTip = ""
        Me.BtnPrint.Size = New System.Drawing.Size(154, 49)
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
        Me.MenuStrip1.Size = New System.Drawing.Size(254, 24)
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
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 394)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1014, 23)
        Me.Panel1.TabIndex = 5
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtList, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtHeading, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1014, 469)
        Me.TableLayoutPanel1.TabIndex = 12
        '
        'StockAgingReportFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 469)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "StockAgingReportFrm"
        Me.Text = "StockAgingReportFrm"
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents TxtHeading As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnreloadqty As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtStockLocation As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel4 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtStockGroup As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnPrint As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Txt4value As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents Txt3SValue As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents Txt3Fvalue As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents Txt2Svalue As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents Txt2Fvalue As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtFirstS As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents ImSlabel6 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel5 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel3 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
End Class
