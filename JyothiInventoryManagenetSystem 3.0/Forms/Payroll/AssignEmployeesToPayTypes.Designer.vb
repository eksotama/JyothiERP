<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AssignEmployeesToPayTypes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AssignEmployeesToPayTypes))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtOnlyUnassigned = New System.Windows.Forms.CheckBox()
        Me.TxtPayslipType = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtFilterByDep = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.BtnRemove = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnAdd = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtEmpList = New System.Windows.Forms.ListBox()
        Me.TxtAssigedList = New System.Windows.Forms.ListBox()
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
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(663, 498)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkOrange
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(663, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ASSIGN PAY SLIP TYPES"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnCreate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 443)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(657, 52)
        Me.Panel1.TabIndex = 1
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(100, 3)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(161, 43)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Cancel"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'BtnCreate
        '
        Me.BtnCreate.AllowToolTip = True
        Me.BtnCreate.BackColor = System.Drawing.Color.White
        Me.BtnCreate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCreate.Image = CType(resources.GetObject("BtnCreate.Image"), System.Drawing.Image)
        Me.BtnCreate.Location = New System.Drawing.Point(429, 3)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(175, 43)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "&Save"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtOnlyUnassigned)
        Me.Panel2.Controls.Add(Me.TxtPayslipType)
        Me.Panel2.Controls.Add(Me.ImSlabel2)
        Me.Panel2.Controls.Add(Me.ImSlabel1)
        Me.Panel2.Controls.Add(Me.TxtFilterByDep)
        Me.Panel2.Controls.Add(Me.BtnRemove)
        Me.Panel2.Controls.Add(Me.BtnAdd)
        Me.Panel2.Controls.Add(Me.TxtEmpList)
        Me.Panel2.Controls.Add(Me.TxtAssigedList)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(657, 408)
        Me.Panel2.TabIndex = 2
        '
        'TxtOnlyUnassigned
        '
        Me.TxtOnlyUnassigned.AutoSize = True
        Me.TxtOnlyUnassigned.Location = New System.Drawing.Point(394, 61)
        Me.TxtOnlyUnassigned.Name = "TxtOnlyUnassigned"
        Me.TxtOnlyUnassigned.Size = New System.Drawing.Size(188, 17)
        Me.TxtOnlyUnassigned.TabIndex = 4
        Me.TxtOnlyUnassigned.Text = "Show Only unassigned Employees"
        Me.TxtOnlyUnassigned.UseVisualStyleBackColor = True
        '
        'TxtPayslipType
        '
        Me.TxtPayslipType.AutoSize = True
        Me.TxtPayslipType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPayslipType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtPayslipType.Location = New System.Drawing.Point(15, 4)
        Me.TxtPayslipType.Name = "TxtPayslipType"
        Me.TxtPayslipType.Size = New System.Drawing.Size(141, 16)
        Me.TxtPayslipType.TabIndex = 3
        Me.TxtPayslipType.Text = "PayslipType Name"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(13, 65)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(122, 13)
        Me.ImSlabel2.TabIndex = 3
        Me.ImSlabel2.Text = "Assigned Employees"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(391, 6)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(122, 13)
        Me.ImSlabel1.TabIndex = 3
        Me.ImSlabel1.Text = "Filter By Department"
        '
        'TxtFilterByDep
        '
        Me.TxtFilterByDep.AllowEmpty = True
        Me.TxtFilterByDep.AllowOnlyListValues = False
        Me.TxtFilterByDep.AllowToolTip = True
        Me.TxtFilterByDep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtFilterByDep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtFilterByDep.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtFilterByDep.FormattingEnabled = True
        Me.TxtFilterByDep.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtFilterByDep.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtFilterByDep.IsAdvanceSearchWindow = False
        Me.TxtFilterByDep.IsAllowDigits = True
        Me.TxtFilterByDep.IsAllowSpace = True
        Me.TxtFilterByDep.IsAllowSplChars = True
        Me.TxtFilterByDep.IsAllowToolTip = True
        Me.TxtFilterByDep.LFocusBackColor = System.Drawing.Color.White
        Me.TxtFilterByDep.Location = New System.Drawing.Point(394, 23)
        Me.TxtFilterByDep.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtFilterByDep.Name = "TxtFilterByDep"
        Me.TxtFilterByDep.SetToolTip = Nothing
        Me.TxtFilterByDep.Size = New System.Drawing.Size(241, 21)
        Me.TxtFilterByDep.Sorted = True
        Me.TxtFilterByDep.SpecialCharList = "&-/@"
        Me.TxtFilterByDep.TabIndex = 2
        Me.TxtFilterByDep.UseFunctionKeys = False
        '
        'BtnRemove
        '
        Me.BtnRemove.AllowToolTip = True
        Me.BtnRemove.BackColor = System.Drawing.Color.White
        Me.BtnRemove.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnRemove.Image = CType(resources.GetObject("BtnRemove.Image"), System.Drawing.Image)
        Me.BtnRemove.Location = New System.Drawing.Point(274, 259)
        Me.BtnRemove.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.SetToolTip = ""
        Me.BtnRemove.Size = New System.Drawing.Size(107, 43)
        Me.BtnRemove.TabIndex = 1
        Me.BtnRemove.Text = "REMOVE"
        Me.BtnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRemove.UseFunctionKeys = False
        Me.BtnRemove.UseVisualStyleBackColor = False
        '
        'BtnAdd
        '
        Me.BtnAdd.AllowToolTip = True
        Me.BtnAdd.BackColor = System.Drawing.Color.White
        Me.BtnAdd.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(274, 123)
        Me.BtnAdd.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.SetToolTip = ""
        Me.BtnAdd.Size = New System.Drawing.Size(107, 43)
        Me.BtnAdd.TabIndex = 1
        Me.BtnAdd.Text = "ADD"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseFunctionKeys = False
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'TxtEmpList
        '
        Me.TxtEmpList.FormattingEnabled = True
        Me.TxtEmpList.Location = New System.Drawing.Point(394, 81)
        Me.TxtEmpList.Name = "TxtEmpList"
        Me.TxtEmpList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.TxtEmpList.Size = New System.Drawing.Size(243, 316)
        Me.TxtEmpList.TabIndex = 0
        '
        'TxtAssigedList
        '
        Me.TxtAssigedList.FormattingEnabled = True
        Me.TxtAssigedList.Location = New System.Drawing.Point(16, 81)
        Me.TxtAssigedList.Name = "TxtAssigedList"
        Me.TxtAssigedList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.TxtAssigedList.Size = New System.Drawing.Size(243, 316)
        Me.TxtAssigedList.TabIndex = 0
        '
        'AssignEmployeesToPayTypes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(663, 498)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AssignEmployeesToPayTypes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Assign Employees PaySlip Type"
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
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TxtEmpList As System.Windows.Forms.ListBox
    Friend WithEvents TxtAssigedList As System.Windows.Forms.ListBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtFilterByDep As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents BtnRemove As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnAdd As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtPayslipType As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtOnlyUnassigned As System.Windows.Forms.CheckBox

End Class
