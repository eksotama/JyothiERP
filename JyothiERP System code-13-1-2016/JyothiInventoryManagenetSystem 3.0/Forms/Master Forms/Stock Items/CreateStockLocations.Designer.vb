<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateStockLocations
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtemailid = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.txtcontactno = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.txtpname = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.txtaddress = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.txtcity = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.TxtStockLocation = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.79352!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtStatus, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(507, 404)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(507, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CREATE STOCK LOCATIONS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnCreate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 313)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(501, 62)
        Me.Panel1.TabIndex = 1
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(28, 13)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(161, 43)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnCreate
        '
        Me.BtnCreate.AllowToolTip = True
        Me.BtnCreate.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnCreate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCreate.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361186619_document_new
        Me.BtnCreate.Location = New System.Drawing.Point(268, 13)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(175, 43)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "&Create"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtemailid)
        Me.Panel2.Controls.Add(Me.txtcontactno)
        Me.Panel2.Controls.Add(Me.txtpname)
        Me.Panel2.Controls.Add(Me.txtaddress)
        Me.Panel2.Controls.Add(Me.txtcity)
        Me.Panel2.Controls.Add(Me.TxtStockLocation)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(501, 278)
        Me.Panel2.TabIndex = 2
        '
        'txtemailid
        '
        Me.txtemailid.AllowToolTip = True
        Me.txtemailid.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.txtemailid.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtemailid.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtemailid.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtemailid.IsAllowDigits = True
        Me.txtemailid.IsAllowSpace = True
        Me.txtemailid.IsAllowSplChars = True
        Me.txtemailid.LFocusBackColor = System.Drawing.Color.White
        Me.txtemailid.Location = New System.Drawing.Point(196, 204)
        Me.txtemailid.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtemailid.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtemailid.MaxLength = 90
        Me.txtemailid.Name = "txtemailid"
        Me.txtemailid.SetToolTip = Nothing
        Me.txtemailid.Size = New System.Drawing.Size(251, 20)
        Me.txtemailid.SpecialCharList = "&-/@"
        Me.txtemailid.TabIndex = 7
        Me.txtemailid.UseFunctionKeys = False
        '
        'txtcontactno
        '
        Me.txtcontactno.AllowToolTip = True
        Me.txtcontactno.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.txtcontactno.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtcontactno.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtcontactno.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtcontactno.IsAllowDigits = True
        Me.txtcontactno.IsAllowSpace = True
        Me.txtcontactno.IsAllowSplChars = True
        Me.txtcontactno.LFocusBackColor = System.Drawing.Color.White
        Me.txtcontactno.Location = New System.Drawing.Point(196, 169)
        Me.txtcontactno.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtcontactno.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtcontactno.MaxLength = 22
        Me.txtcontactno.Name = "txtcontactno"
        Me.txtcontactno.SetToolTip = Nothing
        Me.txtcontactno.Size = New System.Drawing.Size(251, 20)
        Me.txtcontactno.SpecialCharList = "&-/@"
        Me.txtcontactno.TabIndex = 4
        Me.txtcontactno.UseFunctionKeys = False
        '
        'txtpname
        '
        Me.txtpname.AllowToolTip = True
        Me.txtpname.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.txtpname.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtpname.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtpname.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtpname.IsAllowDigits = True
        Me.txtpname.IsAllowSpace = True
        Me.txtpname.IsAllowSplChars = True
        Me.txtpname.LFocusBackColor = System.Drawing.Color.White
        Me.txtpname.Location = New System.Drawing.Point(196, 138)
        Me.txtpname.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtpname.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtpname.MaxLength = 74
        Me.txtpname.Name = "txtpname"
        Me.txtpname.SetToolTip = Nothing
        Me.txtpname.Size = New System.Drawing.Size(251, 20)
        Me.txtpname.SpecialCharList = "&-/@"
        Me.txtpname.TabIndex = 3
        Me.txtpname.UseFunctionKeys = False
        '
        'txtaddress
        '
        Me.txtaddress.AllowToolTip = True
        Me.txtaddress.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.txtaddress.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtaddress.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtaddress.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtaddress.IsAllowDigits = True
        Me.txtaddress.IsAllowSpace = True
        Me.txtaddress.IsAllowSplChars = True
        Me.txtaddress.LFocusBackColor = System.Drawing.Color.White
        Me.txtaddress.Location = New System.Drawing.Point(196, 44)
        Me.txtaddress.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtaddress.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtaddress.MaxLength = 120
        Me.txtaddress.Multiline = True
        Me.txtaddress.Name = "txtaddress"
        Me.txtaddress.SetToolTip = Nothing
        Me.txtaddress.Size = New System.Drawing.Size(251, 51)
        Me.txtaddress.SpecialCharList = "&-/@"
        Me.txtaddress.TabIndex = 1
        Me.txtaddress.UseFunctionKeys = False
        '
        'txtcity
        '
        Me.txtcity.AllowToolTip = True
        Me.txtcity.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.txtcity.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtcity.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtcity.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtcity.IsAllowDigits = True
        Me.txtcity.IsAllowSpace = True
        Me.txtcity.IsAllowSplChars = True
        Me.txtcity.LFocusBackColor = System.Drawing.Color.White
        Me.txtcity.Location = New System.Drawing.Point(196, 106)
        Me.txtcity.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtcity.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtcity.MaxLength = 49
        Me.txtcity.Name = "txtcity"
        Me.txtcity.SetToolTip = Nothing
        Me.txtcity.Size = New System.Drawing.Size(251, 20)
        Me.txtcity.SpecialCharList = "&-/@"
        Me.txtcity.TabIndex = 2
        Me.txtcity.UseFunctionKeys = False
        '
        'TxtStockLocation
        '
        Me.TxtStockLocation.AllowToolTip = True
        Me.TxtStockLocation.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtStockLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStockLocation.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtStockLocation.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtStockLocation.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxtStockLocation.IsAllowDigits = True
        Me.TxtStockLocation.IsAllowSpace = True
        Me.TxtStockLocation.IsAllowSplChars = True
        Me.TxtStockLocation.LFocusBackColor = System.Drawing.Color.White
        Me.TxtStockLocation.Location = New System.Drawing.Point(196, 13)
        Me.TxtStockLocation.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtStockLocation.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtStockLocation.MaxLength = 22
        Me.TxtStockLocation.Name = "TxtStockLocation"
        Me.TxtStockLocation.SetToolTip = Nothing
        Me.TxtStockLocation.Size = New System.Drawing.Size(252, 20)
        Me.TxtStockLocation.SpecialCharList = "&-/@()_"
        Me.TxtStockLocation.TabIndex = 0
        Me.TxtStockLocation.UseFunctionKeys = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(26, 204)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Email ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(26, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Contact Numbers"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Contact Person"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "City"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Address"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Enter Stock Location Name"
        '
        'TxtStatus
        '
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Green
        Me.TxtStatus.Location = New System.Drawing.Point(3, 378)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(501, 26)
        Me.TxtStatus.TabIndex = 0
        Me.TxtStatus.Text = "Status: Ready"
        '
        'Timer1
        '
        '
        'CreateStockLocations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(507, 404)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CreateStockLocations"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Create Stock Locations"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtStockLocation As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtStatus As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtemailid As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents txtcontactno As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents txtpname As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents txtaddress As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents txtcity As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
