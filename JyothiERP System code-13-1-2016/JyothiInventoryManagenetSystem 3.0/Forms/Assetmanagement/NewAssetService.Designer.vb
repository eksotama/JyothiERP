<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewAssetService
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewAssetService))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.TxtFileList = New JyothiPharmaERPSystem3.IMSList()
        Me.ImsNumericTextBox3 = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.ImsNumericTextBox2 = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.ImsNumericTextBox1 = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.ImsTextBox2 = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImsTextBox1 = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtAssetName = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtNotes = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtNoteNo = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtNetAmount = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.IsPosted = New System.Windows.Forms.CheckBox()
        Me.tsno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tfilename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tisnew = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tisdelete = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.TxtFileList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Green
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(620, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SERVICE ENTRY"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtStatus
        '
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Green
        Me.TxtStatus.Location = New System.Drawing.Point(3, 390)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(614, 19)
        Me.TxtStatus.TabIndex = 4
        Me.TxtStatus.Text = "Status: Ready"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnClose)
        Me.Panel2.Controls.Add(Me.BtnCreate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 331)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(620, 59)
        Me.Panel2.TabIndex = 3
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(66, 3)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(159, 50)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnCreate
        '
        Me.BtnCreate.AllowToolTip = True
        Me.BtnCreate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCreate.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361186619_document_new
        Me.BtnCreate.Location = New System.Drawing.Point(400, 6)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(159, 50)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "&Save"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 236)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Note"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtStatus, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(620, 409)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.IsPosted)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.TxtNetAmount)
        Me.Panel1.Controls.Add(Me.ImsNumericTextBox3)
        Me.Panel1.Controls.Add(Me.ImsNumericTextBox2)
        Me.Panel1.Controls.Add(Me.ImsNumericTextBox1)
        Me.Panel1.Controls.Add(Me.ImsTextBox2)
        Me.Panel1.Controls.Add(Me.ImsTextBox1)
        Me.Panel1.Controls.Add(Me.TxtAssetName)
        Me.Panel1.Controls.Add(Me.TxtNotes)
        Me.Panel1.Controls.Add(Me.TxtDate)
        Me.Panel1.Controls.Add(Me.TxtNoteNo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(614, 302)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ToolStrip1)
        Me.GroupBox1.Controls.Add(Me.TxtFileList)
        Me.GroupBox1.Location = New System.Drawing.Point(292, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(304, 212)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "File Attachments"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton4, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 16)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(298, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(45, 22)
        Me.ToolStripButton1.Text = "Add    "
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(61, 22)
        Me.ToolStripButton2.Text = "Delete    "
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(82, 22)
        Me.ToolStripButton3.Text = "Undo Delete"
        Me.ToolStripButton3.Visible = False
        '
        'TxtFileList
        '
        Me.TxtFileList.AllowUserToAddRows = False
        Me.TxtFileList.AllowUserToDeleteRows = False
        Me.TxtFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtFileList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tsno, Me.tfilename, Me.tisnew, Me.tisdelete, Me.tpath})
        Me.TxtFileList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtFileList.Location = New System.Drawing.Point(6, 45)
        Me.TxtFileList.Name = "TxtFileList"
        Me.TxtFileList.RowHeadersVisible = False
        Me.TxtFileList.Size = New System.Drawing.Size(292, 161)
        Me.TxtFileList.TabIndex = 1
        '
        'ImsNumericTextBox3
        '
        Me.ImsNumericTextBox3.AllHelpText = True
        Me.ImsNumericTextBox3.AllowDecimal = False
        Me.ImsNumericTextBox3.AllowFormulas = False
        Me.ImsNumericTextBox3.AllowForQty = True
        Me.ImsNumericTextBox3.AllowNegative = False
        Me.ImsNumericTextBox3.AllowPerSign = False
        Me.ImsNumericTextBox3.AllowPlusSign = False
        Me.ImsNumericTextBox3.AllowToolTip = True
        Me.ImsNumericTextBox3.DecimalPlaces = CType(2, Short)
        Me.ImsNumericTextBox3.ExitOnEscKey = True
        Me.ImsNumericTextBox3.GFocusBackColor = System.Drawing.Color.Yellow
        Me.ImsNumericTextBox3.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsNumericTextBox3.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.ImsNumericTextBox3.HelpText = Nothing
        Me.ImsNumericTextBox3.LFocusBackColor = System.Drawing.Color.White
        Me.ImsNumericTextBox3.Location = New System.Drawing.Point(108, 181)
        Me.ImsNumericTextBox3.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsNumericTextBox3.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ImsNumericTextBox3.Max = CType(100000000000000, Long)
        Me.ImsNumericTextBox3.MaxLength = 12
        Me.ImsNumericTextBox3.Min = CType(0, Long)
        Me.ImsNumericTextBox3.Name = "ImsNumericTextBox3"
        Me.ImsNumericTextBox3.NextOnEnter = True
        Me.ImsNumericTextBox3.SetToolTip = Nothing
        Me.ImsNumericTextBox3.Size = New System.Drawing.Size(163, 20)
        Me.ImsNumericTextBox3.TabIndex = 5
        Me.ImsNumericTextBox3.Text = "0"
        Me.ImsNumericTextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ImsNumericTextBox3.ToolTip = Nothing
        Me.ImsNumericTextBox3.UseFunctionKeys = False
        Me.ImsNumericTextBox3.UseUpDownArrowKeys = False
        '
        'ImsNumericTextBox2
        '
        Me.ImsNumericTextBox2.AllHelpText = True
        Me.ImsNumericTextBox2.AllowDecimal = False
        Me.ImsNumericTextBox2.AllowFormulas = False
        Me.ImsNumericTextBox2.AllowForQty = True
        Me.ImsNumericTextBox2.AllowNegative = False
        Me.ImsNumericTextBox2.AllowPerSign = False
        Me.ImsNumericTextBox2.AllowPlusSign = False
        Me.ImsNumericTextBox2.AllowToolTip = True
        Me.ImsNumericTextBox2.DecimalPlaces = CType(2, Short)
        Me.ImsNumericTextBox2.ExitOnEscKey = True
        Me.ImsNumericTextBox2.GFocusBackColor = System.Drawing.Color.Yellow
        Me.ImsNumericTextBox2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsNumericTextBox2.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.ImsNumericTextBox2.HelpText = Nothing
        Me.ImsNumericTextBox2.LFocusBackColor = System.Drawing.Color.White
        Me.ImsNumericTextBox2.Location = New System.Drawing.Point(108, 149)
        Me.ImsNumericTextBox2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsNumericTextBox2.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ImsNumericTextBox2.Max = CType(100000000000000, Long)
        Me.ImsNumericTextBox2.MaxLength = 12
        Me.ImsNumericTextBox2.Min = CType(0, Long)
        Me.ImsNumericTextBox2.Name = "ImsNumericTextBox2"
        Me.ImsNumericTextBox2.NextOnEnter = True
        Me.ImsNumericTextBox2.SetToolTip = Nothing
        Me.ImsNumericTextBox2.Size = New System.Drawing.Size(163, 20)
        Me.ImsNumericTextBox2.TabIndex = 4
        Me.ImsNumericTextBox2.Text = "0"
        Me.ImsNumericTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ImsNumericTextBox2.ToolTip = Nothing
        Me.ImsNumericTextBox2.UseFunctionKeys = False
        Me.ImsNumericTextBox2.UseUpDownArrowKeys = False
        '
        'ImsNumericTextBox1
        '
        Me.ImsNumericTextBox1.AllHelpText = True
        Me.ImsNumericTextBox1.AllowDecimal = False
        Me.ImsNumericTextBox1.AllowFormulas = False
        Me.ImsNumericTextBox1.AllowForQty = True
        Me.ImsNumericTextBox1.AllowNegative = False
        Me.ImsNumericTextBox1.AllowPerSign = False
        Me.ImsNumericTextBox1.AllowPlusSign = False
        Me.ImsNumericTextBox1.AllowToolTip = True
        Me.ImsNumericTextBox1.DecimalPlaces = CType(2, Short)
        Me.ImsNumericTextBox1.ExitOnEscKey = True
        Me.ImsNumericTextBox1.GFocusBackColor = System.Drawing.Color.Yellow
        Me.ImsNumericTextBox1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsNumericTextBox1.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.ImsNumericTextBox1.HelpText = Nothing
        Me.ImsNumericTextBox1.LFocusBackColor = System.Drawing.Color.White
        Me.ImsNumericTextBox1.Location = New System.Drawing.Point(108, 120)
        Me.ImsNumericTextBox1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsNumericTextBox1.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ImsNumericTextBox1.Max = CType(100000000000000, Long)
        Me.ImsNumericTextBox1.MaxLength = 12
        Me.ImsNumericTextBox1.Min = CType(0, Long)
        Me.ImsNumericTextBox1.Name = "ImsNumericTextBox1"
        Me.ImsNumericTextBox1.NextOnEnter = True
        Me.ImsNumericTextBox1.SetToolTip = Nothing
        Me.ImsNumericTextBox1.Size = New System.Drawing.Size(163, 20)
        Me.ImsNumericTextBox1.TabIndex = 3
        Me.ImsNumericTextBox1.Text = "0"
        Me.ImsNumericTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ImsNumericTextBox1.ToolTip = Nothing
        Me.ImsNumericTextBox1.UseFunctionKeys = False
        Me.ImsNumericTextBox1.UseUpDownArrowKeys = False
        '
        'ImsTextBox2
        '
        Me.ImsTextBox2.AllowToolTip = True
        Me.ImsTextBox2.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.ImsTextBox2.GFocusBackColor = System.Drawing.Color.Yellow
        Me.ImsTextBox2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsTextBox2.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.ImsTextBox2.IsAllowDigits = True
        Me.ImsTextBox2.IsAllowSpace = True
        Me.ImsTextBox2.IsAllowSplChars = True
        Me.ImsTextBox2.LFocusBackColor = System.Drawing.Color.White
        Me.ImsTextBox2.Location = New System.Drawing.Point(108, 207)
        Me.ImsTextBox2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsTextBox2.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ImsTextBox2.MaxLength = 75
        Me.ImsTextBox2.Name = "ImsTextBox2"
        Me.ImsTextBox2.SetToolTip = Nothing
        Me.ImsTextBox2.Size = New System.Drawing.Size(166, 20)
        Me.ImsTextBox2.SpecialCharList = "&-/@"
        Me.ImsTextBox2.TabIndex = 6
        Me.ImsTextBox2.UseFunctionKeys = False
        '
        'ImsTextBox1
        '
        Me.ImsTextBox1.AllowToolTip = True
        Me.ImsTextBox1.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.ImsTextBox1.GFocusBackColor = System.Drawing.Color.Yellow
        Me.ImsTextBox1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsTextBox1.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.ImsTextBox1.IsAllowDigits = True
        Me.ImsTextBox1.IsAllowSpace = True
        Me.ImsTextBox1.IsAllowSplChars = True
        Me.ImsTextBox1.LFocusBackColor = System.Drawing.Color.White
        Me.ImsTextBox1.Location = New System.Drawing.Point(108, 57)
        Me.ImsTextBox1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsTextBox1.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ImsTextBox1.MaxLength = 75
        Me.ImsTextBox1.Name = "ImsTextBox1"
        Me.ImsTextBox1.SetToolTip = Nothing
        Me.ImsTextBox1.Size = New System.Drawing.Size(166, 20)
        Me.ImsTextBox1.SpecialCharList = "&-/@"
        Me.ImsTextBox1.TabIndex = 1
        Me.ImsTextBox1.UseFunctionKeys = False
        '
        'TxtAssetName
        '
        Me.TxtAssetName.AutoSize = True
        Me.TxtAssetName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAssetName.Location = New System.Drawing.Point(108, 5)
        Me.TxtAssetName.Name = "TxtAssetName"
        Me.TxtAssetName.Size = New System.Drawing.Size(0, 13)
        Me.TxtAssetName.TabIndex = 4
        '
        'TxtNotes
        '
        Me.TxtNotes.AllowToolTip = True
        Me.TxtNotes.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtNotes.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNotes.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNotes.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtNotes.IsAllowDigits = True
        Me.TxtNotes.IsAllowSpace = True
        Me.TxtNotes.IsAllowSplChars = True
        Me.TxtNotes.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNotes.Location = New System.Drawing.Point(108, 233)
        Me.TxtNotes.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNotes.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtNotes.MaxLength = 249
        Me.TxtNotes.Multiline = True
        Me.TxtNotes.Name = "TxtNotes"
        Me.TxtNotes.SetToolTip = Nothing
        Me.TxtNotes.Size = New System.Drawing.Size(491, 38)
        Me.TxtNotes.SpecialCharList = "&-/@"
        Me.TxtNotes.TabIndex = 7
        Me.TxtNotes.UseFunctionKeys = False
        '
        'TxtDate
        '
        Me.TxtDate.Location = New System.Drawing.Point(108, 87)
        Me.TxtDate.Name = "TxtDate"
        Me.TxtDate.Size = New System.Drawing.Size(168, 20)
        Me.TxtDate.TabIndex = 2
        '
        'TxtNoteNo
        '
        Me.TxtNoteNo.AllHelpText = True
        Me.TxtNoteNo.AllowDecimal = False
        Me.TxtNoteNo.AllowFormulas = False
        Me.TxtNoteNo.AllowForQty = True
        Me.TxtNoteNo.AllowNegative = False
        Me.TxtNoteNo.AllowPerSign = False
        Me.TxtNoteNo.AllowPlusSign = False
        Me.TxtNoteNo.AllowToolTip = True
        Me.TxtNoteNo.DecimalPlaces = CType(2, Short)
        Me.TxtNoteNo.ExitOnEscKey = True
        Me.TxtNoteNo.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNoteNo.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNoteNo.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtNoteNo.HelpText = Nothing
        Me.TxtNoteNo.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNoteNo.Location = New System.Drawing.Point(108, 30)
        Me.TxtNoteNo.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNoteNo.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtNoteNo.Max = CType(100000000000000, Long)
        Me.TxtNoteNo.MaxLength = 12
        Me.TxtNoteNo.Min = CType(0, Long)
        Me.TxtNoteNo.Name = "TxtNoteNo"
        Me.TxtNoteNo.NextOnEnter = True
        Me.TxtNoteNo.ReadOnly = True
        Me.TxtNoteNo.SetToolTip = Nothing
        Me.TxtNoteNo.Size = New System.Drawing.Size(168, 20)
        Me.TxtNoteNo.TabIndex = 0
        Me.TxtNoteNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNoteNo.ToolTip = Nothing
        Me.TxtNoteNo.UseFunctionKeys = False
        Me.TxtNoteNo.UseUpDownArrowKeys = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 181)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Other Charges"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 149)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Labor Charges"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 121)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Service Charges"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 211)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Location"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Service Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Service Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Asset Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Service No"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(42, 22)
        Me.ToolStripButton4.Text = "Show"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 280)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Posting to Account"
        '
        'TxtNetAmount
        '
        Me.TxtNetAmount.AllHelpText = True
        Me.TxtNetAmount.AllowDecimal = False
        Me.TxtNetAmount.AllowFormulas = False
        Me.TxtNetAmount.AllowForQty = True
        Me.TxtNetAmount.AllowNegative = False
        Me.TxtNetAmount.AllowPerSign = False
        Me.TxtNetAmount.AllowPlusSign = False
        Me.TxtNetAmount.AllowToolTip = True
        Me.TxtNetAmount.DecimalPlaces = CType(2, Short)
        Me.TxtNetAmount.ExitOnEscKey = True
        Me.TxtNetAmount.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtNetAmount.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtNetAmount.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtNetAmount.HelpText = Nothing
        Me.TxtNetAmount.LFocusBackColor = System.Drawing.Color.White
        Me.TxtNetAmount.Location = New System.Drawing.Point(108, 277)
        Me.TxtNetAmount.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtNetAmount.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtNetAmount.Max = CType(100000000000000, Long)
        Me.TxtNetAmount.MaxLength = 12
        Me.TxtNetAmount.Min = CType(0, Long)
        Me.TxtNetAmount.Name = "TxtNetAmount"
        Me.TxtNetAmount.NextOnEnter = True
        Me.TxtNetAmount.ReadOnly = True
        Me.TxtNetAmount.SetToolTip = Nothing
        Me.TxtNetAmount.Size = New System.Drawing.Size(163, 20)
        Me.TxtNetAmount.TabIndex = 5
        Me.TxtNetAmount.Text = "0"
        Me.TxtNetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNetAmount.ToolTip = Nothing
        Me.TxtNetAmount.UseFunctionKeys = False
        Me.TxtNetAmount.UseUpDownArrowKeys = False
        '
        'IsPosted
        '
        Me.IsPosted.AutoSize = True
        Me.IsPosted.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsPosted.Location = New System.Drawing.Point(282, 279)
        Me.IsPosted.Name = "IsPosted"
        Me.IsPosted.Size = New System.Drawing.Size(86, 19)
        Me.IsPosted.TabIndex = 8
        Me.IsPosted.Text = "Post Now"
        Me.IsPosted.UseVisualStyleBackColor = True
        '
        'tsno
        '
        Me.tsno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tsno.HeaderText = "SNo"
        Me.tsno.Name = "tsno"
        Me.tsno.Width = 50
        '
        'tfilename
        '
        Me.tfilename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.tfilename.HeaderText = "File Name"
        Me.tfilename.Name = "tfilename"
        '
        'tisnew
        '
        Me.tisnew.HeaderText = "Isnew"
        Me.tisnew.Name = "tisnew"
        Me.tisnew.Visible = False
        '
        'tisdelete
        '
        Me.tisdelete.HeaderText = "Column1"
        Me.tisdelete.Name = "tisdelete"
        Me.tisdelete.Visible = False
        '
        'tpath
        '
        Me.tpath.HeaderText = "Column1"
        Me.tpath.Name = "tpath"
        Me.tpath.Visible = False
        '
        'NewAssetService
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 409)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewAssetService"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "NewAssetService"
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.TxtFileList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtAssetName As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtStatus As System.Windows.Forms.Label
    Friend WithEvents TxtNotes As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtNoteNo As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ImsTextBox1 As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtFileList As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents ImsNumericTextBox3 As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents ImsNumericTextBox2 As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents ImsNumericTextBox1 As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents ImsTextBox2 As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents IsPosted As System.Windows.Forms.CheckBox
    Friend WithEvents TxtNetAmount As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tsno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tfilename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tisnew As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tisdelete As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tpath As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
