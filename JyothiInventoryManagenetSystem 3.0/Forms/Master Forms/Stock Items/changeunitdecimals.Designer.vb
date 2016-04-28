<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class changeunitdecimals
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(changeunitdecimals))
        Me.TxtDecimals = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel2 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtUnitName = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.BtnCreate = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.SuspendLayout()
        '
        'TxtDecimals
        '
        Me.TxtDecimals.AllHelpText = True
        Me.TxtDecimals.AllowDecimal = False
        Me.TxtDecimals.AllowFormulas = False
        Me.TxtDecimals.AllowForQty = True
        Me.TxtDecimals.AllowNegative = False
        Me.TxtDecimals.AllowPerSign = False
        Me.TxtDecimals.AllowPlusSign = False
        Me.TxtDecimals.AllowToolTip = True
        Me.TxtDecimals.DecimalPlaces = CType(3, Short)
        Me.TxtDecimals.ExitOnEscKey = True
        Me.TxtDecimals.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtDecimals.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtDecimals.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtDecimals.HelpText = Nothing
        Me.TxtDecimals.LFocusBackColor = System.Drawing.Color.White
        Me.TxtDecimals.Location = New System.Drawing.Point(137, 57)
        Me.TxtDecimals.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtDecimals.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtDecimals.Max = CType(100000000000000, Long)
        Me.TxtDecimals.MaxLength = 12
        Me.TxtDecimals.Min = CType(0, Long)
        Me.TxtDecimals.Name = "TxtDecimals"
        Me.TxtDecimals.NextOnEnter = True
        Me.TxtDecimals.SetToolTip = Nothing
        Me.TxtDecimals.Size = New System.Drawing.Size(75, 20)
        Me.TxtDecimals.TabIndex = 0
        Me.TxtDecimals.Text = "0"
        Me.TxtDecimals.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtDecimals.ToolTip = Nothing
        Me.TxtDecimals.UseFunctionKeys = False
        Me.TxtDecimals.UseUpDownArrowKeys = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(41, 64)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(58, 13)
        Me.ImSlabel1.TabIndex = 1
        Me.ImSlabel1.Text = "Decimals"
        '
        'ImSlabel2
        '
        Me.ImSlabel2.AutoSize = True
        Me.ImSlabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel2.Location = New System.Drawing.Point(41, 27)
        Me.ImSlabel2.Name = "ImSlabel2"
        Me.ImSlabel2.Size = New System.Drawing.Size(66, 13)
        Me.ImSlabel2.TabIndex = 1
        Me.ImSlabel2.Text = "Unit Name"
        '
        'TxtUnitName
        '
        Me.TxtUnitName.AllowToolTip = True
        Me.TxtUnitName.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.Title
        Me.TxtUnitName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtUnitName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtUnitName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtUnitName.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtUnitName.IsAllowDigits = True
        Me.TxtUnitName.IsAllowSpace = True
        Me.TxtUnitName.IsAllowSplChars = True
        Me.TxtUnitName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtUnitName.Location = New System.Drawing.Point(137, 27)
        Me.TxtUnitName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtUnitName.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtUnitName.MaxLength = 75
        Me.TxtUnitName.Name = "TxtUnitName"
        Me.TxtUnitName.ReadOnly = True
        Me.TxtUnitName.SetToolTip = Nothing
        Me.TxtUnitName.Size = New System.Drawing.Size(176, 20)
        Me.TxtUnitName.SpecialCharList = "&-/@"
        Me.TxtUnitName.TabIndex = 2
        Me.TxtUnitName.UseFunctionKeys = False
        '
        'BtnCreate
        '
        Me.BtnCreate.AllowToolTip = True
        Me.BtnCreate.BackColor = System.Drawing.Color.White
        Me.BtnCreate.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnCreate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnCreate.Image = CType(resources.GetObject("BtnCreate.Image"), System.Drawing.Image)
        Me.BtnCreate.Location = New System.Drawing.Point(210, 97)
        Me.BtnCreate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.SetToolTip = ""
        Me.BtnCreate.Size = New System.Drawing.Size(147, 43)
        Me.BtnCreate.TabIndex = 3
        Me.BtnCreate.Text = "&Save"
        Me.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCreate.UseFunctionKeys = False
        Me.BtnCreate.UseVisualStyleBackColor = False
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(12, 97)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(133, 43)
        Me.BtnClose.TabIndex = 4
        Me.BtnClose.Text = "Cancel"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'changeunitdecimals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(369, 152)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnCreate)
        Me.Controls.Add(Me.TxtUnitName)
        Me.Controls.Add(Me.ImSlabel2)
        Me.Controls.Add(Me.ImSlabel1)
        Me.Controls.Add(Me.TxtDecimals)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "changeunitdecimals"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Unit Decimals"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtDecimals As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel2 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtUnitName As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents BtnCreate As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton

End Class
