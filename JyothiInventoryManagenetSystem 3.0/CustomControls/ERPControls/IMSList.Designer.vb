<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMSList
    Inherits System.Windows.Forms.DataGridView

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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuCopyCell = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuCopyRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuCopyColumn = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuCopyAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuExporttoExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.TollStripMenuAutoSize = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuCopyCell, Me.ToolStripMenuCopyRow, Me.ToolStripMenuCopyColumn, Me.ToolStripMenuCopyAll, Me.ToolStripMenuExporttoExcel, Me.TollStripMenuAutoSize})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(216, 136)
        '
        'ToolStripMenuCopyCell
        '
        Me.ToolStripMenuCopyCell.Name = "ToolStripMenuCopyCell"
        Me.ToolStripMenuCopyCell.Size = New System.Drawing.Size(215, 22)
        Me.ToolStripMenuCopyCell.Text = "Copy Cell"
        '
        'ToolStripMenuCopyRow
        '
        Me.ToolStripMenuCopyRow.Name = "ToolStripMenuCopyRow"
        Me.ToolStripMenuCopyRow.Size = New System.Drawing.Size(215, 22)
        Me.ToolStripMenuCopyRow.Text = "Copy Row"
        '
        'ToolStripMenuCopyColumn
        '
        Me.ToolStripMenuCopyColumn.Name = "ToolStripMenuCopyColumn"
        Me.ToolStripMenuCopyColumn.Size = New System.Drawing.Size(215, 22)
        Me.ToolStripMenuCopyColumn.Text = "Copy Column"
        '
        'ToolStripMenuCopyAll
        '
        Me.ToolStripMenuCopyAll.Name = "ToolStripMenuCopyAll"
        Me.ToolStripMenuCopyAll.Size = New System.Drawing.Size(215, 22)
        Me.ToolStripMenuCopyAll.Text = "Copy All"
        '
        'ToolStripMenuExporttoExcel
        '
        Me.ToolStripMenuExporttoExcel.Name = "ToolStripMenuExporttoExcel"
        Me.ToolStripMenuExporttoExcel.Size = New System.Drawing.Size(215, 22)
        Me.ToolStripMenuExporttoExcel.Text = "Export To Excel"
        '
        'TollStripMenuAutoSize
        '
        Me.TollStripMenuAutoSize.Name = "TollStripMenuAutoSize"
        Me.TollStripMenuAutoSize.Size = New System.Drawing.Size(215, 22)
        Me.TollStripMenuAutoSize.Text = "Turn on Free Columns Size"
        '
        'IMSList
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DefaultCellStyle = DataGridViewCellStyle4
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuCopyCell As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuCopyRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuCopyColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuCopyAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuExporttoExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TollStripMenuAutoSize As System.Windows.Forms.ToolStripMenuItem

End Class
