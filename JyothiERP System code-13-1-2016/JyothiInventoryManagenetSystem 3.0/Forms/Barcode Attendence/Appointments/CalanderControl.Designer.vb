<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalanderControl
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tstatus = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TimeScaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HourToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MinsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MinToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MinutesToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MinutesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MinutesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MinutesToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.CalanderLeftBar1 = New JyothiPharmaERPSystem3.CalanderLeftBar()
        Me.CalanderTopBar1 = New JyothiPharmaERPSystem3.CalanderTopBar()
        Me.CalanderMain1 = New JyothiPharmaERPSystem3.CalanderMain()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Azure
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tstatus, 1, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(745, 465)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Azure
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(68, 20)
        Me.Panel4.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.CalanderLeftBar1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 43)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0, 0, 0, 15)
        Me.Panel2.Name = "Panel2"
        Me.TableLayoutPanel1.SetRowSpan(Me.Panel2, 3)
        Me.Panel2.Size = New System.Drawing.Size(68, 407)
        Me.Panel2.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.CalanderTopBar1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(68, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0, 0, 15, 0)
        Me.Panel3.Name = "Panel3"
        Me.TableLayoutPanel1.SetRowSpan(Me.Panel3, 2)
        Me.Panel3.Size = New System.Drawing.Size(662, 53)
        Me.Panel3.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.CalanderMain1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(68, 53)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(677, 380)
        Me.Panel1.TabIndex = 3
        '
        'tstatus
        '
        Me.tstatus.AutoSize = True
        Me.tstatus.Location = New System.Drawing.Point(71, 433)
        Me.tstatus.Name = "tstatus"
        Me.tstatus.Size = New System.Drawing.Size(0, 13)
        Me.tstatus.TabIndex = 6
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TimeScaleToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(129, 48)
        '
        'TimeScaleToolStripMenuItem
        '
        Me.TimeScaleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HourToolStripMenuItem, Me.MinsToolStripMenuItem, Me.MinToolStripMenuItem, Me.MinutesToolStripMenuItem3, Me.MinutesToolStripMenuItem, Me.MinutesToolStripMenuItem1, Me.MinutesToolStripMenuItem2})
        Me.TimeScaleToolStripMenuItem.Name = "TimeScaleToolStripMenuItem"
        Me.TimeScaleToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.TimeScaleToolStripMenuItem.Text = "&TimeScale"
        '
        'HourToolStripMenuItem
        '
        Me.HourToolStripMenuItem.Name = "HourToolStripMenuItem"
        Me.HourToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.HourToolStripMenuItem.Text = "1 Hour"
        '
        'MinsToolStripMenuItem
        '
        Me.MinsToolStripMenuItem.Name = "MinsToolStripMenuItem"
        Me.MinsToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.MinsToolStripMenuItem.Text = "30 Minutes"
        '
        'MinToolStripMenuItem
        '
        Me.MinToolStripMenuItem.Name = "MinToolStripMenuItem"
        Me.MinToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.MinToolStripMenuItem.Text = "20 Minutes"
        '
        'MinutesToolStripMenuItem3
        '
        Me.MinutesToolStripMenuItem3.Name = "MinutesToolStripMenuItem3"
        Me.MinutesToolStripMenuItem3.Size = New System.Drawing.Size(132, 22)
        Me.MinutesToolStripMenuItem3.Text = "15 Minutes"
        '
        'MinutesToolStripMenuItem
        '
        Me.MinutesToolStripMenuItem.Name = "MinutesToolStripMenuItem"
        Me.MinutesToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.MinutesToolStripMenuItem.Text = "10 Minutes"
        '
        'MinutesToolStripMenuItem1
        '
        Me.MinutesToolStripMenuItem1.Name = "MinutesToolStripMenuItem1"
        Me.MinutesToolStripMenuItem1.Size = New System.Drawing.Size(132, 22)
        Me.MinutesToolStripMenuItem1.Text = "6 Minutes"
        '
        'MinutesToolStripMenuItem2
        '
        Me.MinutesToolStripMenuItem2.Name = "MinutesToolStripMenuItem2"
        Me.MinutesToolStripMenuItem2.Size = New System.Drawing.Size(132, 22)
        Me.MinutesToolStripMenuItem2.Text = "5 Minutes"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.PrintToolStripMenuItem.Text = "&Print"
        '
        'PrintDocument1
        '
        '
        'CalanderLeftBar1
        '
        Me.CalanderLeftBar1.BackColor = System.Drawing.Color.Azure
        Me.CalanderLeftBar1.CalEndDate = New Date(2014, 12, 24, 0, 0, 0, 0)
        Me.CalanderLeftBar1.CalEndTimeForRows = New Date(2014, 12, 12, 20, 0, 0, 0)
        Me.CalanderLeftBar1.CalStartDate = New Date(2014, 11, 1, 0, 0, 0, 0)
        Me.CalanderLeftBar1.CalStartTimeForRows = New Date(2014, 12, 12, 9, 0, 0, 0)
        Me.CalanderLeftBar1.Location = New System.Drawing.Point(0, -10)
        Me.CalanderLeftBar1.Margin = New System.Windows.Forms.Padding(0)
        Me.CalanderLeftBar1.Name = "CalanderLeftBar1"
        Me.CalanderLeftBar1.SetCaladerColumwidht = 300
        Me.CalanderLeftBar1.setDateFormatString = "dddd, dd MMMM yyyy"
        Me.CalanderLeftBar1.Size = New System.Drawing.Size(170, 7260)
        Me.CalanderLeftBar1.TabIndex = 0
        Me.CalanderLeftBar1.TimeScaleValues = 10
        '
        'CalanderTopBar1
        '
        Me.CalanderTopBar1.BackColor = System.Drawing.Color.Azure
        Me.CalanderTopBar1.CalEndDate = New Date(2014, 12, 24, 0, 0, 0, 0)
        Me.CalanderTopBar1.CalStartDate = New Date(2014, 11, 1, 0, 0, 0, 0)
        Me.CalanderTopBar1.IsAllowToShowEmployeeImages = False
        Me.CalanderTopBar1.IsShowEmployeeImages = False
        Me.CalanderTopBar1.Location = New System.Drawing.Point(-65, 0)
        Me.CalanderTopBar1.Margin = New System.Windows.Forms.Padding(3, 5, 0, 0)
        Me.CalanderTopBar1.Name = "CalanderTopBar1"
        Me.CalanderTopBar1.SetCaladerColumwidht = 300
        Me.CalanderTopBar1.setDateFormatString = "dddd, dd MMMM yyyy"
        Me.CalanderTopBar1.Size = New System.Drawing.Size(3100, 4838)
        Me.CalanderTopBar1.TabIndex = 1
        Me.CalanderTopBar1.TimeScaleValues = 10
        '
        'CalanderMain1
        '
        Me.CalanderMain1.AutoScroll = True
        Me.CalanderMain1.BackColor = System.Drawing.Color.Linen
        Me.CalanderMain1.CalEndDate = New Date(2014, 12, 24, 0, 0, 0, 0)
        Me.CalanderMain1.CalEndTimeForRows = New Date(2014, 12, 12, 20, 0, 0, 0)
        Me.CalanderMain1.CalStartDate = New Date(2014, 11, 1, 0, 0, 0, 0)
        Me.CalanderMain1.CalStartTimeForRows = New Date(2014, 12, 12, 9, 0, 0, 0)
        Me.CalanderMain1.Location = New System.Drawing.Point(0, 0)
        Me.CalanderMain1.Margin = New System.Windows.Forms.Padding(0)
        Me.CalanderMain1.Name = "CalanderMain1"
        Me.CalanderMain1.SetCaladerColumwidht = 300
        Me.CalanderMain1.setDateFormatString = "dddd, dd MMMM yyyy"
        Me.CalanderMain1.Size = New System.Drawing.Size(4200, 70)
        Me.CalanderMain1.TabIndex = 2
        Me.CalanderMain1.TimeScaleValues = 10
        '
        'CalanderControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CalanderControl"
        Me.Size = New System.Drawing.Size(745, 465)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CalanderLeftBar1 As JyothiPharmaERPSystem3.CalanderLeftBar
    Friend WithEvents CalanderTopBar1 As JyothiPharmaERPSystem3.CalanderTopBar
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TimeScaleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HourToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MinsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MinToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MinutesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MinutesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MinutesToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MinutesToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CalanderMain1 As JyothiPharmaERPSystem3.CalanderMain
    Friend WithEvents tstatus As System.Windows.Forms.Label
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument

End Class
