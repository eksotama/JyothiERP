<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalanderBox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TagColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GreenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.YellowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.patternToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.diagonalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.verticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.horizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.hatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.noneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateBillToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DELETEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TagColorToolStripMenuItem, Me.patternToolStripMenuItem, Me.EditToolStripMenuItem, Me.GenerateBillToolStripMenuItem, Me.DELETEToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 136)
        '
        'TagColorToolStripMenuItem
        '
        Me.TagColorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RedToolStripMenuItem, Me.GreenToolStripMenuItem, Me.BlueToolStripMenuItem, Me.YellowToolStripMenuItem, Me.MoreToolStripMenuItem})
        Me.TagColorToolStripMenuItem.Name = "TagColorToolStripMenuItem"
        Me.TagColorToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TagColorToolStripMenuItem.Text = "Tag Color"
        '
        'RedToolStripMenuItem
        '
        Me.RedToolStripMenuItem.Name = "RedToolStripMenuItem"
        Me.RedToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.RedToolStripMenuItem.Text = "Red"
        '
        'GreenToolStripMenuItem
        '
        Me.GreenToolStripMenuItem.Name = "GreenToolStripMenuItem"
        Me.GreenToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.GreenToolStripMenuItem.Text = "Green"
        '
        'BlueToolStripMenuItem
        '
        Me.BlueToolStripMenuItem.Name = "BlueToolStripMenuItem"
        Me.BlueToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.BlueToolStripMenuItem.Text = "Blue"
        '
        'YellowToolStripMenuItem
        '
        Me.YellowToolStripMenuItem.Name = "YellowToolStripMenuItem"
        Me.YellowToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.YellowToolStripMenuItem.Text = "Yellow"
        '
        'MoreToolStripMenuItem
        '
        Me.MoreToolStripMenuItem.Name = "MoreToolStripMenuItem"
        Me.MoreToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.MoreToolStripMenuItem.Text = "More.."
        '
        'patternToolStripMenuItem
        '
        Me.patternToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.diagonalToolStripMenuItem, Me.verticalToolStripMenuItem, Me.horizontalToolStripMenuItem, Me.hatchToolStripMenuItem, Me.toolStripMenuItem3, Me.noneToolStripMenuItem})
        Me.patternToolStripMenuItem.Name = "patternToolStripMenuItem"
        Me.patternToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.patternToolStripMenuItem.Text = "Pattern"
        '
        'diagonalToolStripMenuItem
        '
        Me.diagonalToolStripMenuItem.Name = "diagonalToolStripMenuItem"
        Me.diagonalToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.diagonalToolStripMenuItem.Text = "Diagonal"
        '
        'verticalToolStripMenuItem
        '
        Me.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem"
        Me.verticalToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.verticalToolStripMenuItem.Text = "Vertical"
        '
        'horizontalToolStripMenuItem
        '
        Me.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem"
        Me.horizontalToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.horizontalToolStripMenuItem.Text = "Horizontal"
        '
        'hatchToolStripMenuItem
        '
        Me.hatchToolStripMenuItem.Name = "hatchToolStripMenuItem"
        Me.hatchToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.hatchToolStripMenuItem.Text = "Cross"
        '
        'toolStripMenuItem3
        '
        Me.toolStripMenuItem3.Name = "toolStripMenuItem3"
        Me.toolStripMenuItem3.Size = New System.Drawing.Size(126, 6)
        '
        'noneToolStripMenuItem
        '
        Me.noneToolStripMenuItem.Name = "noneToolStripMenuItem"
        Me.noneToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.noneToolStripMenuItem.Text = "None"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'GenerateBillToolStripMenuItem
        '
        Me.GenerateBillToolStripMenuItem.Name = "GenerateBillToolStripMenuItem"
        Me.GenerateBillToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.GenerateBillToolStripMenuItem.Text = "Generate Bill"
        '
        'DELETEToolStripMenuItem
        '
        Me.DELETEToolStripMenuItem.Name = "DELETEToolStripMenuItem"
        Me.DELETEToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DELETEToolStripMenuItem.Text = "Delete"
        '
        'ToolTip1
        '
        '
        'CalanderBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "CalanderBox"
        Me.Padding = New System.Windows.Forms.Padding(1, 5, 2, 5)
        Me.Size = New System.Drawing.Size(268, 125)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TagColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GreenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BlueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents YellowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Private WithEvents patternToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents diagonalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents verticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents horizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents hatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents noneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DELETEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateBillToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
